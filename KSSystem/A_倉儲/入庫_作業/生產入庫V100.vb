Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 生產入庫V100
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

    Dim Tx1s As String = ""
    Dim Tx2s As String = ""


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

    Private Sub 生產入庫_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceList.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LoginType = 2 Then : btnToB1.Enabled = False : End If '未SAP權限登入無法執行入庫

        ''設定可回傳日期 manager 90天前、一般使用者 10天_Phil_20140303
        If UCase(Login.LogonUserName) = "MANAGER" Or UCase(GetHostName()) = "KS-F1" Then
            Datess1 = -90 : Datess2 = 90
        Else
            Datess1 = -10 : Datess2 = 10
        End If

        ''隱藏設定 非manager 無法看見
        If UCase(Login.LogonUserName) = "MANAGER" Then
            LP01_del.Visible = True
            TP01_del.Visible = True
            BP01_del.Visible = True
            TP01_del.Text = ""
            btnForError.Visible = True
        End If

        'Select Case UCase(Login.LogonUserName)
        '    Case "MANAGER"
        '        待轉入區.Visible = True
        '        '查詢製單.Visible = True
        '    Case "MANAGER", "KS09", (UCase(GetHostName()) = "KS-F1")
        '        LP01_del.Visible = True : TP01_del.Visible = True : BP01_del.Visible = True : TP01_del.Text = ""
        '    Case "MANAGER", (UCase(GetHostName()) = "KS-F1")
        '        btnForError.Visible = True
        '        'Datess1 = -90 : Datess2 = 90
        '    Case (UCase(GetHostName()) = "KS-F1")
        '    Case Else
        '        'Datess1 = -10 : Datess2 = 10
        'End Select


        If UCase(Login.LogonUserName) = "KS09" Or UCase(GetHostName()) = "KS-F1" Then
            btnForError.Visible = True
        End If

        cobSelectType.SelectedIndex = 0

        '初始化
        入庫件數.Text = "件數：  0" : 入庫重量.Text = "重量：  0" : 入庫包數.Text = "包數：  0" : 明細件數.Text = "明細件數：  0"

    End Sub

    Private Sub 待轉入區_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 待轉入區.Click
        'A_PDA上傳轉入.MdiParent = MainForm
        'A_PDA上傳轉入.Show()
        PDA同步V101.MdiParent = MainForm
        PDA同步V101.Show()
        Me.Hide()
    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged
        ClearAll()
    End Sub

    'Private Sub cobSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSelectType.SelectedIndexChanged
    '    Select Case cobSelectType.SelectedIndex
    '        Case "0"
    '            InType = "1"
    '        Case "1"
    '            InType = "12"
    '        Case Else
    '            InType = "1"
    '    End Select
    'End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click

        ClearAll()
        LoadSourceMain()

        If RB1.Checked = True Then
            入庫包數.Visible = False
        Else
            入庫包數.Visible = True
        End If


    End Sub

    '依作業類別載入欲入庫製單號, 並指派給dgvSourceMain
    Private Sub LoadSourceMain()
        btnToB1禁用()
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If RB1.Checked = True Then
                If Login.LogonCompanyDB = "zDouliou" Then
                    sql = "  SELECT DISTINCT T0.[FI102] "
                    sql += "   FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.[FI101] = T1.[FI101] "
                    sql += "  WHERE (T0.[FI103] = '3') AND T1.[FI103] = '3' "
                Else
                    '依製單為主_Phil_20140305
                    sql = "  SELECT DISTINCT T0.[FI102] "
                    sql += "   FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.[FI101] = T1.[FI101] "
                    sql += "  WHERE (T0.[FI103] = '3') AND T1.[FI103] = '3' AND (SUBSTRING(T0.[FI102],8,2) <> '99') AND SUBSTRING(T1.[FI102],8,2) <> '99' "
                End If
            End If

            If RB2.Checked = True Then
                sql = "  SELECT DISTINCT T0.[FI102] "
                sql += "   FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.[FI101] = T1.[FI101] "
                sql += "  WHERE (T0.[FI103] = '3') AND T1.[FI103] = '3' "

            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                '停用_Phil_20140305
                'Case "FI101"   
                '    column.HeaderText = "生產單號"
                '    column.DisplayIndex = 0
                Case "FI102"
                    column.HeaderText = "製單單號"
                    column.DisplayIndex = 0
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvSourceMain.AutoResizeColumns()
        If dgvSourceMain.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub btnToB1禁用()
        btnToB1.Enabled = False
    End Sub


    Private Sub dgvSourceMain_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick

        '建立生產明細單
        If dgvSourceMain.RowCount = 0 Then
            Exit Sub
        End If

        btnToB1禁用()

        dteStart = Now  ''...要計算執行時間的程式區段 ...

        If 表身內容.RowCount > 0 Then     '表身_內容_Phil_20140307
            ks1DataSet.Tables("DT3").Clear()
        End If

        If dgvSourceList.RowCount > 0 Then      '表身_明細
            ks1DataSet.Tables("DT2").Clear()
        End If

        Dim FI102 As String = dgvSourceMain.CurrentRow.Cells("FI102").Value
        'If Microsoft.VisualBasic.Left(FI102, 1) = "D" Then
        '    ckbWhs.Checked = True
        'Else
        '    ckbWhs.Checked = False
        'End If

        'If Mid(dgvSourceMain.CurrentRow.Cells("FI102").Value, 1, 1) = "C" Then  '修改為FI102,原為FI101_Phil_20140305   -20140715_停用
        '    cobSelectType.SelectedIndex = 1
        'Else
        '    cobSelectType.SelectedIndex = 0
        'End If

        '修改為FI102,原為FI101_Phil_20140305
        Dim a As Date = DateSerial("20" + Microsoft.VisualBasic.Mid(dgvSourceMain.CurrentRow.Cells("FI102").Value, 2, 2), Microsoft.VisualBasic.Mid(dgvSourceMain.CurrentRow.Cells("FI102").Value, 4, 2), Microsoft.VisualBasic.Mid(dgvSourceMain.CurrentRow.Cells("FI102").Value, 6, 2))

        DocDate.Text = a
        Label7.Visible = False
        Label7.Text = "查詢完成"

        LoadSourceLists()              '載入選取製單之生產單品項    表身_內容_Phil_20140307
        LoadSourceList()               '載入選取製單之生產明細單    表身_明細
        ListSum()

        Dim TS3s As String = "0.00"
        Dim TS3 As TimeSpan = Now.Subtract(dteStart)
        TS3s = "查詢完成  " & Format(TS3.TotalSeconds, "###0.00")
        Label7.Text = TS3s

        If LsCnt <> LtCnt Then
            MsgBox("入庫數量不付，請檢查條碼是否重覆")
        End If

        If Login.LoginType = 2 Then : btnToB1.Enabled = False : Else : btnToB1.Enabled = True : End If '未SAP權限登入無法執行入庫

    End Sub

    Private Sub ListSum()

        LsCnt = 0 : LsXnt = 0 : LsQnt = 0

        For i As Integer = 0 To 表身內容.RowCount - 1
            If 表身內容.Rows(i).Cells("件數").Value <> 0 Then
                LsCnt += 表身內容.Rows(i).Cells("件數").Value
                LsXnt += Format(CSng(表身內容.Rows(i).Cells("重量").Value), "####0.00")
                LsQnt += Format(CSng(表身內容.Rows(i).Cells("包數").Value), "####0")
            End If
        Next

        入庫件數.Text = "件數：  " & Format(LsCnt, "####0")
        入庫重量.Text = "重量：  " & Format(LsXnt, "####0.00")
        入庫包數.Text = "包數：  " & Format(LsQnt, "####0")

    End Sub

    '載入點選製單之明細資料至Dataset並設定為dgvSourceLists 顯示來源_Phil_20140307
    Private Sub LoadSourceLists()

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If RB1.Checked = True Then
                '_Phil_20140307 _20150519 增加 AND T2.[FI103] IN ('3','4') 顯示已完工方可入庫
                sql = "    SELECT T0.[FI107] AS '存編', T0.[FI108] AS '品名', COUNT(T0.[FI107])AS '件數', SUM(ISNULL(T0.[FI118],0)) AS '重量', SUM(ISNULL(T0.[FI117],0)) AS '包數', T3.[DfltWH] AS '庫位' "
                sql += "     FROM [@FinishItem1] T0 LEFT  JOIN (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '11' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                sql += "                            INNER JOIN [@FI1Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                sql += "                            LEFT  JOIN [OITM]     T3 ON T0.[FI107] = T3.[ItemCode] "
                sql += "    WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT(T1.[PDA02],2) = '11' AND T2.[FI103] IN ('3','4') "
                'sql += "    WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' "
                sql += " GROUP BY T0.[FI107], T0.[FI108], T3.[DfltWH] "
            End If

            If RB2.Checked = True Then
                sql = "    SELECT T0.[FI107] AS '存編', T0.[FI108] AS '品名', COUNT(T0.[FI107])AS '件數', SUM(ISNULL(T0.[FI118],0)) AS '重量', SUM(ISNULL(T0.[FI117],0)) AS '包數', T3.[DfltWH] AS '庫位' "
                sql += "     FROM [@FinishItem2] T0 LEFT  JOIN (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '12' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                'sql += "                            INNER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                sql += "                            INNER JOIN (SELECT DISTINCT [FI101],[FI102],[FI103],[FI104],[FI105] FROM [KaiShing].[dbo].[@FI2Main]) T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "

                sql += "                            LEFT  JOIN [OITM]     T3 ON T0.[FI107] = T3.[ItemCode] "
                sql += "    WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT(T1.[PDA02],2) = '12' AND T2.[FI103] IN ('3','4') "
                'sql += "    WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' "
                sql += " GROUP BY T0.[FI107], T0.[FI108], T3.[DfltWH] "
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT3")
            表身內容.DataSource = ks1DataSet.Tables("DT3")
        Catch ex As Exception
            MsgBox("表身_內容: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In 表身內容.Columns
            column.Visible = True
            Select Case column.HeaderText
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1
                Case "件數" : column.HeaderText = "件數" : column.DisplayIndex = 2
                Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 3
                Case "包數" : column.HeaderText = "包數" : column.DisplayIndex = 4
                Case "庫位" : column.HeaderText = "庫位" : column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next
        表身內容.Refresh()
        表身內容.AutoResizeColumns()
        '

        'Label3.Text = dgvSourceList.RowCount
        If 表身內容.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        Else
            'Label7.Visible = True
        End If

    End Sub

    '載入點選製單之明細資料至Dataset並設定為dgvSourceList顯示來源
    Private Sub LoadSourceList()

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            If RB1.Checked = True Then
                '修改為FI102,原為FI101_Phil_20140305
                sql = "     SELECT DISTINCT T0.[FI101], T0.[FI102], '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) , "
                sql += "           T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI110], T0.[FI111], T0.[FI117], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], "
                sql += "           CASE T0.[FI103] WHEN '3' THEN '已清點' WHEN '4' THEN '已入庫' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[PDA04] "
                'sql += "          ,CASE T2.[FI103] WHEN '1' THEN '進行中' WHEN '3' THEN '已完工' WHEN '4' THEN '已入庫' ELSE '異常' END AS '狀態2' "
                sql += "      FROM [@FinishItem1] T0 LEFT  JOIN "
                sql += "   (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03], T1.[PDA04] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '11' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                sql += "                             INNER JOIN [@FI1Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
                sql += "     WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND T2.[FI103] IN ('3','4') "
                sql += "  ORDER BY T0.[FI101], T0.[FI106] "
                'sql = "    SELECT DISTINCT T0.[FI101], T0.[FI102], T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI111], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], T0.[FI117], "
                'sql += "          CASE T0.[FI103] WHEN '3' THEN '已清點' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[PDA04], "
                'sql += "          '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) "
                'sql += "     FROM [@FinishItem1] T0 INNER JOIN [@ksPDAIn] T1 ON T0.[FI106] = T1.[PDA03] "
                'sql += "    WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT(T1.[PDA02],1) = '1' "
                'sql += " ORDER BY 1, 3 "
            End If

            If RB2.Checked = True Then
                sql = "     SELECT DISTINCT T0.[FI101], T0.[FI102], '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) , "
                sql += "           T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI110], T0.[FI111], T0.[FI117], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], "
                sql += "           CASE T0.[FI103] WHEN '3' THEN '已清點' WHEN '4' THEN '已入庫' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[PDA04] "
                'sql += "          ,CASE T2.[FI103] WHEN '1' THEN '進行中' WHEN '3' THEN '已完工' WHEN '4' THEN '已入庫' ELSE '異常' END AS '狀態2' "
                sql += "      FROM [@FinishItem2] T0 LEFT  JOIN "
                sql += "   (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03], T1.[PDA04] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '12' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                'sql += "                             INNER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] AND T2.[FI103] IN ('3','4') "
                sql += "                             INNER JOIN (SELECT DISTINCT [FI101],[FI102],[FI103],[FI104],[FI105] FROM [KaiShing].[dbo].[@FI2Main]) T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] AND T2.[FI103] IN ('3','4') "

                sql += "     WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' "
                sql += "  ORDER BY T0.[FI101], T0.[FI106] "
                'sql = "    SELECT DISTINCT T0.[FI101], T0.[FI102], T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI111], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], T0.[FI117], "
                'sql += "          CASE T0.[FI103] WHEN '3' THEN '已清點' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[PDA04], "
                'sql += "          '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) "
                'sql += "     FROM [@FinishItem2] T0 INNER JOIN [@ksPDAIn] T1 ON T0.[FI106] = T1.[PDA03] "
                'sql += "    WHERE T0.[FI102] = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' AND T0.[FI103] = '3' AND LEFT(T1.[PDA02],1) = '2' "
                'sql += " ORDER BY 1, 3 "
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT2")
            dgvSourceList.DataSource = ks1DataSet.Tables("DT2")
            查詢單據_Play()
            dgvSourceList.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("表身_明細: " & ex.Message) : Exit Sub
            'End
        End Try

        'For Each column As DataGridViewColumn In dgvSourceList.Columns
        '    column.Visible = True
        '    Select Case column.HeaderText
        '        Case "FI106", "條碼"
        '            column.HeaderText = "條碼"
        '            column.DisplayIndex = 2
        '            'column.Frozen = True
        '        Case "FI107", "存編"
        '            column.HeaderText = "存編"
        '            column.DisplayIndex = 3
        '            'column.Frozen = True
        '        Case "FI108", "品名"
        '            column.HeaderText = "品名"
        '            column.DisplayIndex = 4
        '            'column.Frozen = True
        '        Case "狀態", "狀態"
        '            column.HeaderText = "狀態"
        '            column.DisplayIndex = 5
        '        Case "PDA04", "儲位"
        '            column.HeaderText = "儲位"
        '            column.DisplayIndex = 6
        '        Case "FI118", "重量"
        '            column.HeaderText = "重量"
        '            column.DisplayIndex = 7
        '        Case "FI117", "包裝數"
        '            column.HeaderText = "包裝數"
        '            column.DisplayIndex = 8
        '        Case "狀態2", "狀態2"
        '            column.HeaderText = "狀態2"
        '            column.DisplayIndex = 9
        '        Case "FI101", "生產單號"
        '            column.HeaderText = "生產單號"
        '            column.DisplayIndex = 0
        '        Case "列號", "列號"
        '            column.HeaderText = "列號"
        '            column.DisplayIndex = 1
        '        Case Else
        '            column.Visible = False
        '    End Select
        'Next
        'dgvSourceList.Refresh()
        'dgvSourceList.AutoResizeColumns()
        LtCnt = dgvSourceList.RowCount
        明細件數.Text = "明細件數：  " & LtCnt
        If dgvSourceList.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        Else
            Label7.Visible = True
        End If
        dgvSourceList_Sorted1()

    End Sub

    Private Sub 查詢單據_Play()
        For Each column As DataGridViewColumn In dgvSourceList.Columns
            column.Visible = True
            Select Case column.HeaderText
                Case "FI106", "條碼"
                    column.HeaderText = "條碼"
                    column.DisplayIndex = 2
                    'column.Frozen = True
                Case "FI107", "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 3
                    'column.Frozen = True
                Case "FI108", "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 4
                    'column.Frozen = True
                Case "狀態", "狀態"
                    column.HeaderText = "狀態"
                    column.DisplayIndex = 5
                Case "PDA04", "儲位"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 6
                Case "FI118", "重量"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 7
                Case "FI117", "包裝數"
                    column.HeaderText = "包裝數"
                    column.DisplayIndex = 8
                    'Case "狀態2", "狀態2"
                    '    column.HeaderText = "狀態2"
                    '    column.DisplayIndex = 9
                Case "FI101", "生產單號"
                    column.HeaderText = "生產單號"
                    column.DisplayIndex = 0
                Case "列號", "列號"
                    column.HeaderText = "列號"
                    column.DisplayIndex = 1
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub


    Private Sub dgvSourceList_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSourceList.Sorted
        dgvSourceList_Sorted1()
    End Sub

    Private Sub dgvSourceList_Sorted1()

        儲位異常.Text = "儲位異常：  0" : 異常條碼.Text = "異常條碼：  0" : Red = 0 : Re1 = 0

        If dgvSourceList.RowCount > 0 Then
            For i As Integer = 0 To dgvSourceList.RowCount - 1
                If Len(dgvSourceList.Rows(i).Cells("PDA04").Value) > 10 Then
                    dgvSourceList.Rows(i).Cells("PDA04").Style.BackColor = Color.Red
                    Red += 1
                End If
                'If dgvSourceList.Rows(i).Cells("狀態2").Value = "進行中" Or dgvSourceList.Rows(i).Cells("狀態2").Value = "異常" Then
                '    'dgvSourceList.Rows(i).Cells("PDA04").Style.BackColor = Color.Red
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

        If dgvSourceList.RowCount = 0 Then
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

        Dim Str As String = dgvSourceMain.CurrentRow.Cells("FI102").Value

        If Str.Substring(3, 2) <> Format(DocDate.Value.Date, "MM") Then
            Dim oAns As Integer
            oAns = MsgBox("此製單並不是當月製單!" & vbCrLf & "此製單將會入到今日，並請至B1內回填原因。" & vbCrLf & "確認要轉入B1 ?", 36, "警告")
            If oAns = MsgBoxResult.No Then
                Exit Sub
            Else
                If UCase(Login.LogonUserName) = "MANAGER" Or UCase(GetHostName()) = "KS-F1" Then

                Else
                    'If UCase(GetHostName()) <> "KS-F1" Then
                    DocDate.Value = Today
                    'End If
                End If
            End If
        End If
        PBar1.Minimum = 0
        'PBar1.Maximum = dgvSourceList.Rows.Count - 1
        PBar1.Maximum = 表身內容.Rows.Count - 1
        SyncToSAP()
    End Sub

    Private Sub SyncToSAP()
        '生產入庫
        Dim RetVal As Long : Dim ErrCode As Long : Dim ErrMsg As String : Dim Codess As String = ""
        Dim vDoc As SAPbobsCOM.Documents
        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
        '表頭_內容
        vDoc.UserFields.Fields.Item("U_CK02").Value = dgvSourceMain.CurrentRow.Cells("FI102").Value '製單號
        vDoc.UserFields.Fields.Item("U_CK06").Value = InType '收貨目地
        vDoc.DocDate = DocDate.Value.Date '文件日期

        '表身_內容 dgvSourceLists
        If RB1.Checked = True Then  '電宰
            For i As Integer = 0 To 表身內容.RowCount - 1
                Codess = ""
                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = Format(Trim(表身內容.Rows(i).Cells("存編").Value), "")                                 '項目號碼
                Tx1s = Trim(表身內容.Rows(i).Cells("存編").Value)
                'SyncSRN1()
                vDoc.Lines.Quantity = 表身內容.Rows(i).Cells("件數").FormattedValue                              '件數_回傳包數
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = 表身內容.Rows(i).Cells("重量").FormattedValue  '重量

                If ckbWhs.Checked = True Then  '指定庫別, 無指定時入預設庫別
                    vDoc.Lines.WarehouseCode = tbxWhsCode.Text
                Else
                    vDoc.Lines.WarehouseCode = 表身內容.Rows(i).Cells("庫位").FormattedValue
                End If

                '列出錯誤
                Codess = Trim(表身內容.Rows(i).Cells("存編").Value)   '錯誤項目號碼
                'Txx1 = Codess.ToString
                'MsgBox(Codess)
                '表身_明細 dgvSourceList
                Dim Cnt0 As Integer = 0
                For j As Integer = 0 To dgvSourceList.RowCount - 1
                    'If Trim(dgvSourceList.Rows(j).Cells("FI107").Value) = Codess Then
                    If Trim(dgvSourceList.Rows(j).Cells("FI107").Value) = Format(Trim(表身內容.Rows(i).Cells("存編").Value), "") Then
                        vDoc.Lines.SerialNumbers.SetCurrentLine(Cnt0)
                        vDoc.Lines.SerialNumbers.InternalSerialNumber = dgvSourceList.Rows(j).Cells("FI106").Value '條碼
                        Tx2s = dgvSourceList.Rows(j).Cells("FI106").Value '條碼
                        'SyncSRN1()
                        'ReceptionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        vDoc.Lines.SerialNumbers.ReceptionDate = dgvSourceList.Rows(j).Cells("FI109").Value        '磅入&製單日期 InDate    SAP_許可
                        vDoc.Lines.SerialNumbers.ManufactureDate = dgvSourceList.Rows(j).Cells("FI110").Value      '生產日期 MnfDate            製造
                        vDoc.Lines.SerialNumbers.ExpiryDate = dgvSourceList.Rows(j).Cells("FI111").Value           '有效日期 ExpDate            到期
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
            For ix As Integer = 0 To 表身內容.RowCount - 1
                vDoc.Lines.SetCurrentLine(ix)
                vDoc.Lines.ItemCode = 表身內容.Rows(ix).Cells("存編").Value '項目號碼
                vDoc.Lines.Quantity = 表身內容.Rows(ix).Cells("包數").Value '件數_回傳包數
                '列出錯誤
                Codess = 表身內容.Rows(ix).Cells("存編").Value '錯誤項目號碼
                'MsgBox(Codess)
                '表身_明細 dgvSourceList
                Dim Cnt1 As Integer = 0
                For jx As Integer = 0 To dgvSourceList.RowCount - 1
                    If dgvSourceList.Rows(jx).Cells("FI107").Value = Codess Then
                        vDoc.Lines.BatchNumbers.SetCurrentLine(Cnt1)
                        vDoc.Lines.BatchNumbers.BatchNumber = dgvSourceList.Rows(jx).Cells("FI106").Value       '條碼
                        'AddmisionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        vDoc.Lines.BatchNumbers.AddmisionDate = dgvSourceList.Rows(jx).Cells("FI109").Value     '磅入&製單日期 InDate
                        vDoc.Lines.BatchNumbers.ManufacturingDate = dgvSourceList.Rows(jx).Cells("FI110").Value '生產日期 MnfDate
                        vDoc.Lines.BatchNumbers.ExpiryDate = dgvSourceList.Rows(jx).Cells("FI111").Value        '有效日期 ExpDate
                        vDoc.Lines.BatchNumbers.Quantity = dgvSourceList.Rows(jx).Cells("FI117").Value          '數量_回傳包數
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

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        Label7.Visible = False

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

        ClearAll()
        LoadSourceMain()
    End Sub
    'Private Sub SyncSRN1()
    '    Txx1.Text = Tx1s
    '    'Txx2.Text = Tx2s
    '    MsgBox(Txx1.Text)
    'End Sub



    Private Sub SyncSRN()
        SyncAns = False
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        '修改加快回傳方式_Phil_20140305
        'Dim DrfNums1 As String = ""

        DrfNums1 = ""
        For i As Integer = 0 To dgvSourceList.RowCount - 1
            If DrfNums1 = "" Then
                DrfNums1 = DrfNums1 + Format(dgvSourceList.Rows(i).Cells("FI106").Value, "")
            Else
                DrfNums1 = DrfNums1 + "','" + Format(dgvSourceList.Rows(i).Cells("FI106").Value, "")
            End If
        Next

        If DrfNums1 = "" Then
            MsgBox("空白資料")
            Exit Sub
        End If

        Try
            If RB1.Checked = True Then
                '修改加快回傳方式_Phil_20140305
                'sql = "  UPDATE [OSRN] SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T2.[PDA04], [U_MC] = T1.[FI119] "
                'sql += "   FROM [OSRN] T0 INNER JOIN [@FinishItem1] T1 ON T0.[DistNumber] = T1.[FI106] "
                'sql += "                  INNER JOIN [@ksPDAIn]     T2 ON T0.[DistNumber] = T2.[PDA03] "
                'sql += "  WHERE [DistNumber] IN ('" & DrfNums1 & "') "
                'sql += " UPDATE [@FinishItem1] SET [FI103] = '4' WHERE [FI106] IN ('" & DrfNums1 & "') "
                'sql += " UPDATE [@ksPDAIn]     SET [PDA06] = '4' WHERE [PDA03] IN ('" & DrfNums1 & "') "

                '修改加快回傳方式_Phil_20150304
                Dim Intmp8 As String = "" : Dim Intmp9 As String = ""
                Intmp8 = Format(Replace(Replace("#Intmp8" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '初始
                Intmp9 = Format(Replace(Replace("#Intmp9" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '整合

                sql = "  IF (OBJECT_ID('tempdb.." & Intmp8 & "') IS NOT NULL)  DROP TABLE " & Intmp8 & " "
                sql += " IF (OBJECT_ID('tempdb.." & Intmp9 & "') IS NOT NULL)  DROP TABLE " & Intmp9 & " "

                sql += " DECLARE @FI102 nvarchar(20)"
                sql += " SET @FI102 = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "'"

                sql += "     SELECT DISTINCT T0.[FI101], T0.[FI102], '列號' = ROW_NUMBER() OVER (PARTITION BY T0.[FI101] ORDER BY T0.[FI101], T0.[FI106]) , "
                sql += "            T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI111], T0.[FI117], ISNULL(T0.[FI118],0) AS 'FI118', T0.[FI119], "
                sql += "            CASE T0.[FI103] WHEN '3' THEN '已清點' WHEN '4' THEN '已入庫' ELSE '未清點' END AS '狀態', T0.[FI103], T1.[PDA04] INTO " & Intmp8 & " "
                sql += "       FROM [@FinishItem1] T0 INNER JOIN "
                'sql += "    (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03], T1.[PDA04] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '11' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                'sql += "      WHERE T0.[FI102] = @FI102 AND T0.[FI103] = '3' "
                sql += "    (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03], T1.[PDA04] FROM [@ksPDAIn] T1 WHERE [PDA03] IN ('" & DrfNums1 & "') AND LEFT(T1.[PDA02],2) = '11' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                sql += "      WHERE T0.[FI106] IN ('" & DrfNums1 & "') AND T0.[FI102] = @FI102 AND T0.[FI103] = '3' "
                sql += "   ORDER BY T0.[FI101], T0.[FI106] "

                sql += "     SELECT T3.[FI106], T3.[FI107], T3.[FI108], T1.[DistNumber]  INTO " & Intmp9 & " "
                sql += "       FROM " & Intmp8 & " T3 INNER JOIN [OSRN] T1 ON T3.[FI107]    = T1.[ItemCode] AND T3.[FI106]     = T1.[DistNumber] "
                sql += "                              INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                sql += "      WHERE T3.[FI102] = @FI102 AND T3.[FI103] = '3' "
                sql += "   ORDER BY T3.[FI101], T3.[FI106] "

                'sql += "     SELECT * FROM #tmpmis03"

                sql += "  UPDATE [OSRN] SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T2.[PDA04], [U_MC] = T1.[FI119] "
                sql += "    FROM [OSRN] T0 INNER JOIN [@FinishItem1] T1 ON T0.[DistNumber] = T1.[FI106] "
                sql += "                   LEFT  JOIN [@ksPDAIn]     T2 ON T0.[DistNumber] = T2.[PDA03] "
                sql += "                   INNER JOIN " & Intmp9 & " T3 ON T0.[DistNumber] = T3.[DistNumber] "
                sql += "  UPDATE [@FinishItem1] SET [FI103] = '4' "
                sql += "    FROM [@FinishItem1] T0 INNER JOIN " & Intmp9 & " T3 ON T0.[FI106] = T3.[DistNumber] "
                sql += "  UPDATE [@ksPDAIn]     SET [PDA06] = '4' "
                sql += "    FROM [@ksPDAIn]     T0 INNER JOIN " & Intmp9 & " T3 ON T0.[PDA03] = T3.[DistNumber] "

                sql += " IF (OBJECT_ID('tempdb.." & Intmp8 & "') IS NOT NULL)  DROP TABLE " & Intmp8 & " "
                sql += " IF (OBJECT_ID('tempdb.." & Intmp9 & "') IS NOT NULL)  DROP TABLE " & Intmp9 & " "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.CommandTimeout = 100000
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

            End If

            If RB2.Checked = True Then
                sql = "  UPDATE [OBTN] SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T2.[PDA04], [U_MC] = T1.[FI119] "
                sql += "   FROM [OBTN] T0 INNER JOIN [@FinishItem2] T1 ON T0.[DistNumber] = T1.[FI106] "
                sql += "                  INNER JOIN [@ksPDAIn]     T2 ON T0.[DistNumber] = T2.[PDA03] "
                sql += "  WHERE [DistNumber] IN ('" & DrfNums1 & "') "
                sql += " UPDATE [@FinishItem2] SET [FI103] = '4' WHERE [FI106] IN ('" & DrfNums1 & "') "
                sql += " UPDATE [@ksPDAIn]     SET [PDA06] = '4' WHERE [PDA03] IN ('" & DrfNums1 & "') "
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.CommandTimeout = 100000
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

            End If

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Dim oAns As Integer
            oAns = MsgBox("是否要重新更新條碼重量?", 36, "警告")
            If oAns = MsgBoxResult.No Then
                SyncAns = False
                Exit Sub
            Else
                SyncSRN()
            End If
        End Try

        SyncAns = True

    End Sub

    Private Sub 記錄存檔()  '存入冷凍庫之品項

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            sql = " INSERT INTO [Z_KS_Record_021] ([DocDate],[DocDate2],[F01],[F02],[F03],[F04],[F05],[F06]) "
            sql += "  SELECT TOP 100 getdate() AS 'DocDate', '" & DocDate2.Value.Date & "' AS 'DocDate2', "
            sql += "         T0.[FI102], T0.[FI101], T0.[FI106], T0.[FI107], T0.[FI108], T1.[PDA04] "
            sql += "    FROM [@FinishItem1] T0 INNER JOIN [@ksPDAIn] T1 ON T0.[FI106] = T1.[PDA03] "
            sql += "   WHERE T0.[FI106] IN ('" & DrfNums1 & "') AND T1.[PDA04] IN ('J011','J012','J013','J014','J015') "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

    End Sub


    Private Sub btnForError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForError.Click
        If dgvSourceMain.RowCount <= 0 Then
            Exit Sub
        End If

        If dgvSourceList.RowCount <= 0 Then
            Exit Sub
        End If

        SyncSRN()

        MsgBox("更新完成!", 64, "成功")

        ClearAll()
        LoadSourceMain()

    End Sub

    Private Sub ClearAll()
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        If 表身內容.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        '初始化
        LsCnt = 0 : LsXnt = 0
        入庫件數.Text = "件數：  0" : 入庫重量.Text = "重量：  0" : 入庫包數.Text = "包數：  0" : 明細件數.Text = "明細件數：  0"

    End Sub

    '----
    Private Sub BP01_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BP01_del.Click
        P01_del()
        TP01_del.Text = ""
        ks1DataSet.Tables("DT2").Clear()
        ks1DataSet.Tables("DT3").Clear()

        'LoadSourceList()
    End Sub

    Private Sub P01_del()

        'Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim tran As SqlTransaction = DBConn.BeginTransaction()
        'Try

        '    For i As Integer = 0 To dgvSourceList.RowCount - 1

        '        sql = "DELETE FROM [@ksPDAIn] WHERE [PDA03] = '" & dgvSourceList.Rows(i).Cells("FI106").Value & "' AND [PDA04] = '" & TP01_del.Text & "' "

        '        SQLCmd.Connection = DBConn
        '        SQLCmd.CommandText = sql
        '        SQLCmd.Transaction = tran
        '        SQLCmd.ExecuteNonQuery()

        '        PBar1.Value = i
        '    Next

        '    tran.Commit()
        'Catch ex As Exception
        '    tran.Rollback()
        '    MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        '    Exit Sub
        'End Try

        'MsgBox("刪除完成!", 64, "成功")
        Dim sql As String = ""
        For i As Integer = 0 To dgvSourceList.RowCount - 1
            If dgvSourceList.Rows(i).Cells("PDA04").Value = TP01_del.Text Then
                sql += "DELETE FROM [@ksPDAIn] WHERE [PDA03] = '" & dgvSourceList.Rows(i).Cells("FI106").Value & "' AND [PDA04] = '" & TP01_del.Text & "' " & vbCrLf
            End If
            PBar1.Value = i
        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = sql : SQLCmd.CommandTimeout = 100000
            'SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        End Try
        MsgBox("刪除完成!", 64, "成功")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        記錄存檔()
    End Sub


End Class