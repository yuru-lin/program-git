Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 生產入庫V101
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim SyncAns As Boolean
    Dim InType As String

    '設定可回傳日期_Phil_20140303
    Dim btnToB1FT As String = "False"
    Dim Datess1 As Integer
    Dim Datess2 As Integer

    '修改加快回傳方式_Phil_20140305
    Dim DrfNums1 As String = ""

    '暫存資料表名稱
    Dim Intmp1 As String = "" : Dim Intmp2 As String = "" : Dim Intmp3 As String = "" : Dim Intmp4 As String = ""

    '統計
    Dim LsCnt As Integer = 0      '表身_內容_入庫件數
    Dim LsXnt As Single = 0       '表身_內容_入庫重量
    Dim LsQnt As Single = 0       '表身_內容_入庫包數
    Dim LtCnt As Integer = 0      '表身_明細_入庫件數
    Dim LtXnt As Single = 0       '表身_明細_入庫重量
    Dim LtQnt As Single = 0       '表身_明細_入庫包數
    Dim Red As Integer = 0 : Dim Re1 As Integer = 0

    '時間
    Dim dteStart As DateTime      'SAP
    Dim DocNum2 As Integer

    Private Sub 生產入庫V101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        製單DGV.ContextMenuStrip = MainForm.ContextMenuStrip1
        明細DGV.ContextMenuStrip = MainForm.ContextMenuStrip1
        '待轉入區.Visible = False
        '查詢製單.Visible = False

        'If Login.LoginType = 2 Then : btnToB1.Enabled = False : End If '未SAP權限登入無法執行入庫

        '隱藏設定 非manager 無法看見
        Select Case UCase(Login.LogonUserName)
            Case "MANAGER"
                LP01_del.Visible = True
                待轉入區.Visible = True
                查詢製單.Visible = True
            Case "MANAGER", "KS09"
                錯誤儲位.Visible = True : 錯誤移除.Visible = True : 錯誤儲位.Text = ""
                'Case "MANAGER"
                btnForError.Visible = True      '重量更新
                Datess1 = -90 : Datess2 = 90
            Case Else
                Datess1 = -10 : Datess2 = 10
        End Select

        '設定可回傳日期 manager 90天前、一般使用者 10天_Phil_20140303
        'If UCase(Login.LogonUserName) = "MANAGER" Or UCase(GetHostName()) = "KS-F1" Then
        '    錯誤儲位.Visible = True : 錯誤移除.Visible = True : 錯誤儲位.Text = ""
        '    Datess1 = -90 : Datess2 = 90
        'Else
        '    Datess1 = -10 : Datess2 = 10
        'End If

        'If UCase(GetHostName()) = "KS-F1" Then
        'btnForError.Visible = True
        'End If

        cobSelectType.SelectedIndex = 0

        '初始化
        btnToB1禁用()
        目前作業.Text = "" : 完成時間.Text = ""
        入庫件數.Text = "件數：  0" : 入庫重量.Text = "重量：  0" : 入庫包數.Text = "包數：  0" : 明細件數.Text = "明細件數：  0"

        Intmp1 = Format(Replace(Replace("#Intmp1" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '初始
        Intmp2 = Format(Replace(Replace("#Intmp2" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '整合
        Intmp3 = Format(Replace(Replace("#Intmp3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '結果

    End Sub

    Private Sub 初始化()
        If 製單DGV.RowCount > 0 Then : ks1DataSet.Tables("DT1").Clear() : End If
        If 明細DGV.RowCount > 0 Then : ks1DataSet.Tables("DT2").Clear() : End If
        If 統計DGV.RowCount > 0 Then : ks1DataSet.Tables("DT3").Clear() : End If

        '初始化
        LsCnt = 0 : LsXnt = 0
        入庫件數.Text = "件數：  0" : 入庫重量.Text = "重量：  0" : 入庫包數.Text = "包數：  0" : 明細件數.Text = "明細件數：  0"

    End Sub

    Private Sub 待轉入區_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 待轉入區.Click
        PDA同步V103.La作業.Text = "入庫"
        PDA同步V103.MdiParent = MainForm
        PDA同步V103.Show()
        Me.Hide()
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢製單.Click
        If RB1.Checked = True Then : 目前作業.Text = "電宰" : End If
        If RB2.Checked = True Then : 目前作業.Text = "加工" : End If

        Select Case 目前作業.Text
            Case "電宰" : 入庫包數.Visible = False
            Case "加工" : 入庫包數.Visible = True
        End Select

        初始化()
        入庫條碼暫存作業()
        btnToB1禁用()
        製單DGV查詢()

    End Sub

    Private Sub 入庫條碼暫存作業()
        Dim SQLQuery As String = ""
        SQLQuery = "    IF (OBJECT_ID('tempdb.." & Intmp1 & "') IS NOT NULL)  DROP TABLE " & Intmp1 & " "
        Select Case 目前作業.Text
            Case "電宰"
                SQLQuery += " SELECT * INTO " & Intmp1 & " FROM [KaiShingPlug].[dbo].[PDA_InData_SAP] WHERE LEFT([IN01],2) = '11' AND [IN06] = '3' "
            Case "加工"
                SQLQuery += " SELECT * INTO " & Intmp1 & " FROM [KaiShingPlug].[dbo].[PDA_InData_SAP] WHERE LEFT([IN01],2) = '12' AND [IN06] = '3' "
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub 製單DGV查詢()
        Dim SQLQuery As String = ""

        Select Case 目前作業.Text
            Case "電宰"
                If Login.LogonCompanyDB = "zDouliou" Then
                    SQLQuery = "  SELECT DISTINCT T0.[FI102] "
                    SQLQuery += "   FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.[FI101] = T1.[FI101] "
                    SQLQuery += "  WHERE (T0.[FI103] = '3') AND T1.[FI103] = '3' "
                Else
                    SQLQuery = "  SELECT DISTINCT T0.[FI102] "
                    SQLQuery += "   FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.[FI101] = T1.[FI101] "
                    SQLQuery += "  WHERE (T0.[FI103] = '3') AND T1.[FI103] = '3' AND (SUBSTRING(T0.[FI102],8,2) <> '99') AND SUBSTRING(T1.[FI102],8,2) <> '99' "
                End If
            Case "加工"
                SQLQuery = "  SELECT DISTINCT T0.[FI102] "
                SQLQuery += "   FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.[FI101] = T1.[FI101] "
                SQLQuery += "  WHERE (T0.[FI103] = '3') AND T1.[FI103] = '3' "
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapter1 = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            製單DGV.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("製單單號: " & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In 製單DGV.Columns
            column.Visible = True
            Select Case column.Name
                Case "FI102" : column.HeaderText = "製單單號" : column.DisplayIndex = 0
                Case Else
                    column.Visible = False
            End Select
        Next

        製單DGV.AutoResizeColumns()

        If 製單DGV.RowCount <= 0 Then : MsgBox("查無資料。", 48, "警告") : End If

    End Sub

    Private Sub btnToB1禁用()
        btnToB1.Enabled = False
    End Sub


    Private Sub 製單DGV_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 製單DGV.CellClick

        '建立生產明細單
        If 製單DGV.RowCount = 0 Then : Exit Sub : End If : btnToB1禁用()

        dteStart = Now  ''...要計算執行時間的程式區段 ...

        If 統計DGV.RowCount > 0 Then : ks1DataSet.Tables("DT3").Clear() : End If
        If 明細DGV.RowCount > 0 Then : ks1DataSet.Tables("DT2").Clear() : End If

        Dim FI102 As String = 製單DGV.CurrentRow.Cells("FI102").Value
        'If Microsoft.VisualBasic.Left(FI102, 1) = "D" Then : ckbWhs.Checked = True : Else : ckbWhs.Checked = False : End If '指定庫位

        '修改為FI102,原為FI101_Phil_20140305
        Dim 時間 As Date = DateSerial("20" + Microsoft.VisualBasic.Mid(製單DGV.CurrentRow.Cells("FI102").Value, 2, 2), Microsoft.VisualBasic.Mid(製單DGV.CurrentRow.Cells("FI102").Value, 4, 2), Microsoft.VisualBasic.Mid(製單DGV.CurrentRow.Cells("FI102").Value, 6, 2))

        DocDate.Text = 時間
        完成時間.Visible = False : 完成時間.Text = "查詢完成"

        入庫條碼暫存作業()
        統計DGV查詢()   '載入選取製單之生產單品項    表身_內容_Phil_20140307
        明細DGV查詢()   '載入選取製單之生產明細單    表身_明細
        ListSum()
        明細DGV_Sorted1()

        LtCnt = 明細DGV.RowCount
        明細件數.Text = "明細件數：  " & LtCnt
        If 明細DGV.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        Else
            完成時間.Visible = True
        End If

        Dim TS3s As String = "0.00" : Dim TS3 As TimeSpan = Now.Subtract(dteStart)
        TS3s = "查詢完成  " & Format(TS3.TotalSeconds, "###0.00")
        完成時間.Text = TS3s

        If LsCnt <> LtCnt Then : MsgBox("入庫數量不符，請檢查條碼是否重覆") : End If
        If Login.LoginType = 2 Then : btnToB1.Enabled = False : Else : btnToB1.Enabled = True : End If '未SAP權限登入無法執行入庫

        統計DGV.AutoResizeColumns()
        明細DGV.AutoResizeColumns()

    End Sub

    Private Sub ListSum()

        LsCnt = 0 : LsXnt = 0 : LsQnt = 0

        For i As Integer = 0 To 統計DGV.RowCount - 1
            If 統計DGV.Rows(i).Cells("件數").Value <> 0 Then
                LsCnt += 統計DGV.Rows(i).Cells("件數").Value
                LsXnt += Format(CSng(統計DGV.Rows(i).Cells("重量").Value), "####0.00")
                LsQnt += Format(CSng(統計DGV.Rows(i).Cells("包數").Value), "####0")
            End If
        Next

        入庫件數.Text = "件數：  " & Format(LsCnt, "####0")
        入庫重量.Text = "重量：  " & Format(LsXnt, "####0.00")
        入庫包數.Text = "包數：  " & Format(LsQnt, "####0")

    End Sub

    Private Sub 統計DGV查詢()

        Dim SQLQuery As String = ""
        Select Case 目前作業.Text
            Case "電宰"
                SQLQuery = "    SELECT T0.[FI107] AS '存編', T0.[FI108] AS '品名', COUNT(T0.[FI107])AS '件數', SUM(ISNULL(T0.[FI118],0)) AS '重量', SUM(ISNULL(T0.[FI117],0)) AS '包數' "
                SQLQuery += "     FROM [@FinishItem1] T0 INNER JOIN ( SELECT DISTINCT * FROM " & Intmp1 & " WHERE LEFT([IN01],2) = '11') T1 ON T0.[FI106] = T1.[IN02] "
                SQLQuery += "                            INNER JOIN [@FI1Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                SQLQuery += "    WHERE T0.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT([IN01],2) = '11' AND T2.[FI103] IN ('3','4') "
                SQLQuery += " GROUP BY T0.[FI107], T0.[FI108] ORDER BY 1 "
            Case "加工"
                SQLQuery = "    SELECT T0.[FI107] AS '存編', T0.[FI108] AS '品名', COUNT(T0.[FI107])AS '件數', SUM(ISNULL(T0.[FI118],0)) AS '重量', SUM(ISNULL(T0.[FI117],0)) AS '包數' "
                SQLQuery += "     FROM [@FinishItem2] T0 INNER JOIN ( SELECT DISTINCT * FROM " & Intmp1 & " WHERE LEFT([IN01],2) = '12') T1 ON T0.[FI106] = T1.[IN02] "
                SQLQuery += "                            INNER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                SQLQuery += "    WHERE T0.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT([IN01],2) = '12' AND T2.[FI103] IN ('3','4') "
                SQLQuery += " GROUP BY T0.[FI107], T0.[FI108] ORDER BY 1 "
                'SQLQuery = "    SELECT T0.[FI107] AS '存編', T0.[FI108] AS '品名', COUNT(T0.[FI107])AS '件數', SUM(ISNULL(T0.[FI118],0)) AS '重量', SUM(ISNULL(T0.[FI117],0)) AS '包數' "
                'SQLQuery += "     FROM [@FinishItem2] T0 INNER JOIN (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '12') T1 ON T0.[FI106] = T1.[PDA03] "
                'SQLQuery += "    WHERE T0.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT(T1.[PDA02],2) = '12' "
                'SQLQuery += " GROUP BY T0.[FI107], T0.[FI108] "
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapter1 = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT3")
            統計DGV.DataSource = ks1DataSet.Tables("DT3")
        Catch ex As Exception
            MsgBox("表身_內容: " & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In 統計DGV.Columns
            column.Visible = True
            Select Case column.Name
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1
                Case "件數" : column.HeaderText = "件數" : column.DisplayIndex = 2
                Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 3
                Case "包數" : column.HeaderText = "包數" : column.DisplayIndex = 4
                Case Else
                    column.Visible = False
            End Select
        Next
        統計DGV.Refresh()
        '統計DGV.AutoResizeColumns()
        If 統計DGV.RowCount <= 0 Then : MsgBox("查無資料。", 48, "警告") : End If

    End Sub

    '載入點選製單之明細資料至Dataset並設定為dgvSourceList顯示來源
    Private Sub 明細DGV查詢()
        Dim SQLQuery As String = ""
        SQLQuery = "    IF (OBJECT_ID('tempdb.." & Intmp2 & "') IS NOT NULL)  DROP TABLE " & Intmp2 & " "
        Select Case 目前作業.Text
            Case "電宰"
                SQLQuery += "    SELECT DISTINCT T0.[FI101], T0.[FI102], '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) , "
                SQLQuery += "           T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI110], T0.[FI111], T0.[FI117], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], "
                SQLQuery += "           CASE T0.[FI103] WHEN '3' THEN '已清點' WHEN '4' THEN '已入庫' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[INID], T1.[IN04] "
                'SQLQuery += "          ,CASE T2.[FI103] WHEN '1' THEN '進行中' WHEN '3' THEN '已完工' WHEN '1' THEN '已入庫' ELSE '異常' END AS '狀態2' "
                SQLQuery += "           INTO " & Intmp2 & " "
                SQLQuery += "      FROM [@FinishItem1] T0 INNER JOIN ( SELECT * FROM " & Intmp1 & " WHERE LEFT([IN01],2) = '11') T1 ON T0.[FI106] = T1.[IN02] "
                SQLQuery += "                             INNER JOIN [@FI1Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                SQLQuery += "     WHERE T0.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND T2.[FI103] IN ('3','4') "
            Case "加工"
                SQLQuery += "    SELECT DISTINCT T0.[FI101], T0.[FI102], '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) , "
                SQLQuery += "           T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI110], T0.[FI111], T0.[FI117], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], "
                SQLQuery += "           CASE T0.[FI103] WHEN '3' THEN '已清點' WHEN '4' THEN '已入庫' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[INID], T1.[IN04] "
                'SQLQuery += "          ,CASE T2.[FI103] WHEN '1' THEN '進行中' WHEN '3' THEN '已完工' WHEN '1' THEN '已入庫' ELSE '異常' END AS '狀態2' "
                SQLQuery += "           INTO " & Intmp2 & " "
                SQLQuery += "      FROM [@FinishItem2] T0 INNER JOIN ( SELECT * FROM " & Intmp1 & " WHERE LEFT([IN01],2) = '12') T1 ON T0.[FI106] = T1.[IN02] "
                SQLQuery += "                             INNER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                SQLQuery += "     WHERE T0.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND T2.[FI103] IN ('3','4') "
                'sql = "     SELECT DISTINCT T0.[FI101], T0.[FI102], '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) , "
                'sql += "           T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI111], T0.[FI117], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], "
                'sql += "           CASE T0.[FI103] WHEN '3' THEN '已清點' WHEN '4' THEN '已入庫' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[PDA04] "
                'sql += "      FROM [@FinishItem2] T0 INNER JOIN "
                'sql += "   (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03], T1.[PDA04] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '12') T1 ON T0.[FI106] = T1.[PDA03] "
                'sql += "     WHERE T0.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' "
                'sql += "  ORDER BY T0.[FI101], T0.[FI106] "
        End Select
        SQLQuery += "    SELECT * FROM " & Intmp2 & " ORDER BY 1, 4 "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapter1 = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT2")
            明細DGV.DataSource = ks1DataSet.Tables("DT2")

        Catch ex As Exception
            MsgBox("表身_明細: " & ex.Message)
            Exit Sub
        End Try

        明細DGV.Refresh()
        查詢單據_Play()

    End Sub

    Private Sub 查詢單據_Play()
        For Each column As DataGridViewColumn In 明細DGV.Columns
            column.Visible = True
            Select Case column.Name
                Case "FI101" : column.HeaderText = "生產單號" : column.DisplayIndex = 0
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 1
                Case "FI106" : column.HeaderText = "條碼" : column.DisplayIndex = 2
                Case "FI107" : column.HeaderText = "存編" : column.DisplayIndex = 3
                Case "FI108" : column.HeaderText = "品名" : column.DisplayIndex = 4
                Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 5
                Case "IN04" : column.HeaderText = "儲位" : column.DisplayIndex = 6
                Case "FI118" : column.HeaderText = "重量" : column.DisplayIndex = 7
                Case "FI117" : column.HeaderText = "包裝數" : column.DisplayIndex = 8
                    'Case "狀態2" : column.HeaderText = "狀態2" : column.DisplayIndex = 9
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub 明細DGV_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles 明細DGV.Sorted
        明細DGV_Sorted1()
    End Sub

    Private Sub 明細DGV_Sorted1()

        儲位異常.Text = "儲位異常：  0" : 異常條碼.Text = "異常條碼：  0" : Red = 0 : Re1 = 0

        If 明細DGV.RowCount > 0 Then

            For i As Integer = 0 To 明細DGV.RowCount - 1
                If Len(明細DGV.Rows(i).Cells("IN04").Value) > 10 Then
                    明細DGV.Rows(i).Cells("IN04").Style.BackColor = Color.Red
                    Red += 1
                End If
                'If Len(明細DGV.Rows(i).Cells("狀態2").Value) = 1 Then
                '    '明細DGV.Rows(i).Cells("狀態2").Style.BackColor = Color.Red
                '    Re1 += 1
                'End If
            Next

            儲位異常.Text = "儲位異常：  " & Red : 異常條碼.Text = "異常條碼：  " & Re1
        End If
    End Sub

    Private Sub DocDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocDate.ValueChanged

        Dim ans As Long = DateDiff(DateInterval.Day, Date.Now, DocDate.Value.Date)
        '設定可回傳日期_Phil_20140303
        btnToB1FT = "True"
        If ans < Datess1 Then
            MsgBox("日期不能小於 " & Datess2 & "天!", 48, "警告")
            DocDate.Value = Today()
            DocDate.Focus()
            btnToB1FT = "False"
        End If
    End Sub

    Private Sub btnToB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToB1.Click

        'Dim dteStart As DateTime = Now
        dteStart = Now  ''...要計算執行時間的程式區段 ...

        '設定可回傳日期_Phil_20140303
        If btnToB1FT = "False" Then
            MsgBox("日期不能小於 " & Datess2 & "天!無法回傳", 48, "警告")
            Exit Sub
        End If

        If 明細DGV.RowCount = 0 Then
            MsgBox("沒有任何條碼可以傳!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        If Re1 <> 0 Then
            MsgBox("有未完工條碼!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        Select Case cobSelectType.SelectedIndex
            Case "0"
                InType = "1"
            Case "1"
                InType = "12"
            Case Else
                InType = "1"
        End Select

        Dim Str As String = 製單DGV.CurrentRow.Cells("FI102").Value

        If Str.Substring(3, 2) <> Format(DocDate.Value.Date, "MM") Then
            Dim oAns As Integer
            oAns = MsgBox("此製單並不是當月製單!" & vbCrLf & "此製單將會入到今日，並請至B1內回填原因。" & vbCrLf & "確認要轉入B1 ?", 36, "警告")
            If oAns = MsgBoxResult.No Then
                Exit Sub
            Else
                DocDate.Value = Today
            End If
        End If
        PBar1.Minimum = 0
        'PBar1.Maximum = dgvSourceList.Rows.Count - 1
        PBar1.Maximum = 統計DGV.Rows.Count - 1
        SyncToSAP()
    End Sub

    Private Sub SyncToSAP()
        '生產入庫
        Dim RetVal As Long : Dim ErrCode As Long : Dim ErrMsg As String : Dim Codess As String = ""
        Dim vDoc As SAPbobsCOM.Documents
        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
        '表頭_內容
        vDoc.UserFields.Fields.Item("U_CK02").Value = 製單DGV.CurrentRow.Cells("FI102").Value '製單號
        vDoc.UserFields.Fields.Item("U_CK06").Value = InType '收貨目地
        vDoc.DocDate = DocDate.Value.Date '文件日期

        '表身_內容 dgvSourceLists
        If RB1.Checked = True Then  '電宰
            For i As Integer = 0 To 統計DGV.RowCount - 1
                Codess = ""
                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = Trim(統計DGV.Rows(i).Cells("存編").Value)                                 '項目號碼
                vDoc.Lines.Quantity = 統計DGV.Rows(i).Cells("件數").FormattedValue                              '件數_回傳包數
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = 統計DGV.Rows(i).Cells("重量").FormattedValue  '重量

                If ckbWhs.Checked = True Then  '指定庫別, 無指定時入預設庫別
                    vDoc.Lines.WarehouseCode = tbxWhsCode.Text
                End If

                '列出錯誤
                Codess = Trim(統計DGV.Rows(i).Cells("存編").Value)   '錯誤項目號碼

                'MsgBox(Codess)
                '表身_明細 dgvSourceList
                Dim Cnt0 As Integer = 0
                For j As Integer = 0 To 明細DGV.RowCount - 1
                    'If Trim(dgvSourceList.Rows(j).Cells("FI107").Value) = Codess Then
                    If Trim(明細DGV.Rows(j).Cells("FI107").Value) = Trim(統計DGV.Rows(i).Cells("存編").Value) Then
                        vDoc.Lines.SerialNumbers.SetCurrentLine(Cnt0)
                        vDoc.Lines.SerialNumbers.InternalSerialNumber = 明細DGV.Rows(j).Cells("FI106").Value '條碼
                        'ReceptionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        vDoc.Lines.SerialNumbers.ReceptionDate = 明細DGV.Rows(j).Cells("FI109").Value        '製單日期 InDate
                        vDoc.Lines.SerialNumbers.ManufactureDate = 明細DGV.Rows(j).Cells("FI110").Value      '生產日期 MnfDate
                        vDoc.Lines.SerialNumbers.ExpiryDate = 明細DGV.Rows(j).Cells("FI111").Value           '有效日期 ExpDate

                        vDoc.Lines.SerialNumbers.Add()
                        'MsgBox(Cnt0)   '顯示執行列數
                        Cnt0 += 0 + 1
                    End If
                Next

                vDoc.Lines.Add()
                PBar1.Value = i
            Next
        End If

        If RB2.Checked = True Then  '加工
            For ix As Integer = 0 To 統計DGV.RowCount - 1
                vDoc.Lines.SetCurrentLine(ix)
                vDoc.Lines.ItemCode = 統計DGV.Rows(ix).Cells("存編").Value '項目號碼
                vDoc.Lines.Quantity = 統計DGV.Rows(ix).Cells("包數").Value '件數_回傳包數

                '列出錯誤
                Codess = Trim(統計DGV.Rows(ix).Cells("存編").Value) '錯誤項目號碼
                'MsgBox(Codess)
                '表身_明細 dgvSourceList
                Dim Cnt1 As Integer = 0
                For jx As Integer = 0 To 明細DGV.RowCount - 1
                    If 明細DGV.Rows(jx).Cells("FI107").Value = Trim(統計DGV.Rows(ix).Cells("存編").Value) Then
                        vDoc.Lines.BatchNumbers.SetCurrentLine(Cnt1)
                        vDoc.Lines.BatchNumbers.BatchNumber = 明細DGV.Rows(jx).Cells("FI106").Value       '條碼
                        'AddmisionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        vDoc.Lines.BatchNumbers.AddmisionDate = 明細DGV.Rows(jx).Cells("FI109").Value     '製單日期 InDate
                        vDoc.Lines.BatchNumbers.ManufacturingDate = 明細DGV.Rows(jx).Cells("FI110").Value '生產日期 MnfDate
                        vDoc.Lines.BatchNumbers.ExpiryDate = 明細DGV.Rows(jx).Cells("FI111").Value        '有效日期 ExpDate
                        vDoc.Lines.BatchNumbers.Quantity = 明細DGV.Rows(jx).Cells("FI117").Value          '數量_回傳包數
                        vDoc.Lines.BatchNumbers.Add()
                        'MsgBox(Cnt0)   '顯示執行列數
                        Cnt1 += 0 + 1
                    End If
                Next

                vDoc.Lines.Add()
                PBar1.Value = ix
            Next
        End If

        RetVal = vDoc.Add
        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            Dim TS As TimeSpan = Now.Subtract(dteStart)
            MsgBox("製單轉入B1收貨單錯誤! " & Codess & vbCrLf & ErrCode & vbCrLf & "執行時間: " & Format(TS.TotalSeconds, "###0.00") & " 秒" & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        Else
            'SyncSRN()  '更新資料
            '記錄存檔() '記錄急速
        End If

        DocNum2 = 0

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        DocNum2 = DocNum
        完成時間.Visible = False

        Dim TS1s As String = "0.00"
        Dim TS2s As String = "0.00"

        Dim TS1 As TimeSpan = Now.Subtract(dteStart)
        TS1s = Format(TS1.TotalSeconds, "###0.00")

        SyncSRN()  '更新資料
        記錄存檔() '記錄急速

        Dim TS2 As TimeSpan = Now.Subtract(dteStart)
        TS2s = Format(TS2.TotalSeconds, "###0.00")

        If SyncAns = True Then
            MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "SAP時間: " & TS1s & " 秒" & vbCrLf & "完成時間: " & TS2s & " 秒", 64, "完成")
        Else
            MsgBox("資料已至B1收貨單!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "但是條碼重量未更新!!" & vbCrLf & "請洽資訊室協助更新!!", 16, "未完成")
        End If

        查詢製單.PerformClick()
    End Sub

    Private Sub SyncSRN()
        SyncAns = False
        Dim SQLQuery As String = ""
        Select Case 目前作業.Text
            Case "電宰"
                SQLQuery = "  UPDATE [OSRN]                             SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T1.[IN04], [U_MC] = T1.[FI119] "
                SQLQuery += "   FROM [OSRN] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[DistNumber] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                SQLQuery += " UPDATE [@FinishItem1]                        SET [FI103] = '4' "
                SQLQuery += "   FROM [@FinishItem1] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[FI106] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData_SAP] SET [IN07] = '" & DocNum2 & "', [IN06] = '4' "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData_SAP] S0 INNER JOIN " & Intmp2 & " S1 ON S0.[IN02] = S1.[FI106] AND S1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
            Case "加工"
                SQLQuery = "  UPDATE [OBTN]                                SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T1.[IN04], [U_MC] = T1.[FI119] "
                SQLQuery += "   FROM [OBTN] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[DistNumber] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                SQLQuery += " UPDATE [@FinishItem2]                        SET [FI103] = '4' "
                SQLQuery += "   FROM [@FinishItem2] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[FI106] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData_SAP] SET [IN07] = '" & DocNum2 & "', [IN06] = '4' "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData_SAP] S0 INNER JOIN " & Intmp2 & " S1 ON S0.[IN02] = S1.[FI106] AND S1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Dim oAns As Integer
            oAns = MsgBox("是否要重新更新條碼重量?", 36, "警告")
            If oAns = MsgBoxResult.Yes Then
                SyncSRN()

            Else
                SyncAns = False
                Exit Sub
            End If
        End Try

        SyncAns = True

    End Sub

    Private Sub 記錄存檔()  '存入冷凍庫之品項
        Dim SQLQuery As String = ""
        Select Case 目前作業.Text
            Case "電宰"
                SQLQuery = "   INSERT INTO [Z_KS_Record_021] ([DocDate],[DocDate2],[F01],[F02],[F03],[F04],[F05],[F06]) "
                SQLQuery += "  SELECT Getdate() AS 'DocDate', '" & DocDate2.Value.Date & "' AS 'DocDate2', T0.[FI102], T0.[FI101], T0.[FI106], T0.[FI107], T0.[FI108], T1.[IN04] "
                SQLQuery += "    FROM [@FinishItem1] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[FI106] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                SQLQuery += "   WHERE T1.[IN04] IN ('J011','J012','J013','J014','J015') "
        End Select
        If SQLQuery <> "" Then
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Try
                SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
                SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            End Try
        End If

    End Sub


    Private Sub btnForError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForError.Click
        If 製單DGV.RowCount <= 0 Then : Exit Sub : End If
        If 明細DGV.RowCount <= 0 Then : Exit Sub : End If

        SyncSRN()

        MsgBox("更新完成!", 64, "成功")

        初始化()
        製單DGV查詢()

    End Sub

    Private Sub 錯誤移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 錯誤移除.Click
        錯誤儲位條碼移除()
        錯誤儲位.Text = ""
        ks1DataSet.Tables("DT2").Clear()
        ks1DataSet.Tables("DT3").Clear()

    End Sub

    Private Sub 錯誤儲位條碼移除()
        Dim 作廢條碼ID As String = "" : Dim 作業別 As String = ""
        For i As Integer = 0 To 明細DGV.RowCount - 1
            If Format(明細DGV.Rows(i).Cells("IN04").Value, "") = 錯誤儲位.Text Then
                If 作廢條碼ID = "" Then
                    作廢條碼ID = 作廢條碼ID + Format(明細DGV.Rows(i).Cells("INID").Value, "")
                Else
                    作廢條碼ID = 作廢條碼ID + "','" + Format(明細DGV.Rows(i).Cells("INID").Value, "")
                End If : End If
        Next

        If 作廢條碼ID = "" Then : MsgBox("無需移除條碼") : 錯誤儲位.Text = "" : Exit Sub : End If

        Select Case 目前作業.Text
            Case "電宰" : 作業別 = "11.電宰入庫"
            Case "加工" : 作業別 = "12.加工入庫"
        End Select

        Dim SQLQueryAd As String = "" : Dim SQLQueryUp As String = ""
        SQLQueryAd = " UPDATE [KaiShingPlug].[dbo].[PDA_InData_SAP] SET [IN06] = '6' "
        SQLQueryAd += " WHERE [IN01] = '" & 作業別 & "' AND [IN02] IN ('" & 作廢條碼ID & "') AND [IN06] = '3' "

        SQLQueryUp = " INSERT INTO [KaiShingPlug].[dbo].[PDA_Data_Log] (PDA02,PDA03,PDA04,PDA05,PDA13) VALUES ('SAP人庫作業','刪除錯誤儲位','" & UCase(GetHostName()) & "',GETDATE(),'" & Replace(SQLQueryAd, "'", ":") & "') "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQueryAd & vbCrLf & SQLQueryUp : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        End Try

        MsgBox("刪除完成!", 64, "成功")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        記錄存檔()
    End Sub


End Class