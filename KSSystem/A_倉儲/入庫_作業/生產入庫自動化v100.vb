Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 生產入庫自動化v100
    Dim DataAdapterDGV As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet


    '暫存資料庫名
    Dim INPDA1 As String = ""
    Dim INPDA2 As String = ""
    Dim INPDA3 As String = ""

    '作業需求
    'Dim Cnt0 As Integer = 0     '未入庫數
    'Dim Cnt1 As Integer = 0     '已出庫數
    'Dim Cnt2 As Integer = 0     '作廢數量
    'Dim Cnt3 As Integer = 0     '查無條碼
    'Dim Cnt4 As Integer = 0     '重複條碼
    Dim 收貨類型Type As String = "1"
    Dim DocNum2 As Integer
    Dim SyncAns As Boolean
    Dim 中止 As Boolean = False
    Dim 執行自動入庫 As Boolean = True


    Dim 入庫代碼 As String = ""     'PDA入庫代碼 '11','12' = 電宰及加工入庫 : '13' = 採購入庫

    Dim DGV1選擇 As String = "Y"
    Dim 同步檢查 As String = "N"

    '統計
    Dim LsCnt As Integer = 0      '表身_內容_入庫件數
    Dim LsXnt As Single = 0       '表身_內容_入庫重量
    Dim LsQnt As Single = 0       '表身_內容_入庫包數
    Dim LtCnt As Integer = 0      '表身_明細_入庫件數
    Dim LtXnt As Single = 0       '表身_明細_入庫重量
    Dim LtQnt As Single = 0       '表身_明細_入庫包數
    Dim Red As Integer = 0 : Dim Re1 As Integer = 0

    '設定可回傳日期_Phil_20140303
    Dim btnToB1FT As String = "False"
    Dim Datess1 As Integer
    Dim Datess2 As Integer

    '記算時間
    Dim dteStart As DateTime


    Private Sub 生產入庫自動化v100_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated



        即時時間.Enabled = True
        即時時間.Interval = 100

        'La作業.Text = "入庫"
        INPDA1 = Format(Replace(Replace("#INPDAtmp1" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '初始
        INPDA2 = Format(Replace(Replace("#INPDAtmp2" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '整合
        INPDA3 = Format(Replace(Replace("#INPDAtmp3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '結果

        收貨類型.SelectedIndex = 0

        'If UCase(Login.LogonUserName) = "MANAGER" Or UCase(GetHostName()) = "KS-F1" Then
        '    Datess1 = -90 : Datess2 = 90
        'Else
        Datess1 = -10 : Datess2 = 10
        'End If

    End Sub

    Private Sub 生產入庫自動化v100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Login.LoginType = 1 Or Login.LoginType = 2 Then
            '查詢.Enabled = False
            '自動開啟.Checked = False
            '自動開啟.Enabled = False
            執行自動入庫 = False
            MsgBox("未SAP權限登入無法執行") ': Me.Close()
        End If '未SAP權限登入無法執行入庫

        TabControl1.TabPages.Remove(PDA轉入)

        '初始化
        入庫件數.Text = "入庫件數：  0" : 入庫重量.Text = "入庫重量：  0" : 入庫包數.Text = "入庫包數：  0" : 明細件數.Text = "明細件數：  0"

        入庫單號.Text = ""

        If UCase(Login.LogonUserName) = "MANAGER" Then
            序號批次選擇.Visible = True
        End If


    End Sub

    Private Sub 即時時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 即時時間.Tick
        '電腦時間.Text = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        電腦時間.Text = Now()

        Select Case Format(Now(), "mm") '依分鐘為單位
            'Case "00", "15", "30", "45", "41"
            Case "05", "20", "35", "50"
                If 執行自動入庫 = True And 自動開啟.Checked = True Then : 執行作業() : End If

        End Select

    End Sub

    Private Sub 自動開啟_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 自動開啟.CheckedChanged
        If 執行自動入庫 = False Then
            自動開啟.Checked = False
        End If
    End Sub


    Private Sub 執行作業()
        待入庫條碼載入作業()
        If 入庫條碼.RowCount <> 0 Then
            If 自動開啟.Checked = True Then : 製單載入作業(1) : End If
            If 自動開啟.Checked = False Then
                If RB序號.Checked = True Then : 製單載入作業(2) : End If
                If RB批次.Checked = True Then : 製單載入作業(3) : End If
            End If
            自動入庫條碼作業_選擇製單()
            清空資料作業()
        Else
            'MsgBox("無入庫條碼")
            Exit Sub
        End If


    End Sub

    Private Sub 自動入庫條碼作業_選擇製單()

        If 製單.RowCount = 0 Then : 清空資料作業() : Exit Sub : End If
        For i As Integer = 0 To 製單.RowCount - 1   '正
            'For i As Integer = 0 To 1 - 1   '正
            中止 = False
            製單.CurrentCell = 製單.Rows(i).Cells(0)
            作業製單.Text = "作業製單：" & 製單.CurrentRow.Cells("製單編號").Value
            資料載入作業()
            If 中止 = False Then
                回存SAP入庫()
            End If
            'MsgBox(製單.CurrentRow.Cells("製單編號").Value)
        Next
    End Sub

    Private Sub 資料載入作業()
        Dim a As String = 製單.CurrentRow.Cells("製單編號").Value
        Dim 日期 As Date = DateSerial("20" + Microsoft.VisualBasic.Mid(a, 2, 2), Microsoft.VisualBasic.Mid(a, 4, 2), Microsoft.VisualBasic.Mid(a, 6, 2))
        過帳日期.Text = 日期
        表身載入作業()
        明細載入作業()
        資料整合()
        Select Case 收貨類型.SelectedIndex
            Case "0" : 收貨類型Type = "1"
            Case "1" : 收貨類型Type = "12"
            Case Else : 收貨類型Type = "1"
        End Select

    End Sub
    Private Sub 清空資料作業()
        If 入庫條碼.RowCount > 0 Then : 顯示資料.Tables("入庫條碼").Clear() : End If '清除DGV資料
        If 製單.RowCount > 0 Then : 顯示資料.Tables("製單").Clear() : End If '清除DGV資料
        If 表身.RowCount > 0 Then : 顯示資料.Tables("表身").Clear() : End If '清除DGV資料
        If 明細.RowCount > 0 Then : 顯示資料.Tables("明細").Clear() : End If '清除DGV資料
    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click
        If 執行自動入庫 = False And 自動開啟.Checked = False Then : 執行作業() : End If
    End Sub

    Private Sub 待入庫條碼載入作業()
        If 入庫條碼.RowCount > 0 Then : 顯示資料.Tables("入庫條碼").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""

        'SQLQuery = "  IF (OBJECT_ID('tempdb..#入庫暫存1') IS NOT NULL) DROP TABLE #入庫暫存1 "
        SQLQuery = "  IF (OBJECT_ID('tempdb.." & INPDA1 & "') IS NOT NULL)  DROP TABLE " & INPDA1 & " "

        SQLQuery += " CREATE TABLE [" & INPDA1 & "] (  "
        SQLQuery += " 入庫管理 NVARCHAR(2),入庫條碼 NVARCHAR(20),處理 NVARCHAR(10),入庫庫位 NVARCHAR(20),儲位碼數 NVARCHAR(6),上傳時間 DATETIME,管理 NVARCHAR(10),生產日期 DATE,日期 NVARCHAR(20), "
        SQLQuery += " 製單編號 NVARCHAR(20),生產單號 NVARCHAR(20),製單狀態 NVARCHAR(10),條碼 NVARCHAR(20),條碼狀態 NVARCHAR(10),存編 NVARCHAR(20),品名 NVARCHAR(500),客戶代碼 NVARCHAR(20), "
        SQLQuery += " 製單日期 DATE,製造日期 DATE,有效日期 DATE,預設儲位 NVARCHAR(20),數量 FLOAT(53),單位數量 FLOAT(53),單位 NVARCHAR(10),標示重量 NUMERIC(20,2),實際重量 NUMERIC(20,2), "
        SQLQuery += " 是否定重 NVARCHAR(2),排程時段 NVARCHAR(6),組別 NVARCHAR(6),狀態 NVARCHAR(10),補單 NVARCHAR(2),補單製單 NVARCHAR(20),補單入庫 INT,補單發貨 INT, "
        SQLQuery += " 生產時間 DATETIME,SAP庫位 NVARCHAR(10),SAP儲位 NVARCHAR(10),庫存數量 FLOAT(53),庫存狀態 NVARCHAR(10),重覆 NVARCHAR(10)) "
        SQLQuery += " INSERT INTO [" & INPDA1 & "] EXEC [dbo].[預_自動入庫01v] " & Datess1 & " "
        SQLQuery += " SELECT * FROM [" & INPDA1 & "] "
        'SQLQuery += " SELECT * FROM [" & INPDA1 & "] WHERE 生產日期 >= CONVERT(VARCHAR(10),DATEADD(DAY," & Datess1 & ",GETDATE()),120) "


        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand ': Dim SQLCmd2 As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = SQLQuery
            SQLCmd.CommandTimeout = 300000
            'DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV = New SqlDataAdapter(SQLCmd)
            DataAdapterDGV.Fill(顯示資料, "入庫條碼")
            入庫條碼.DataSource = 顯示資料.Tables("入庫條碼")
        Catch ex As Exception
            MsgBox("入庫條碼載入異常：" & ex.Message)
        End Try

    End Sub

    Private Sub 製單_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 製單.CellClick
        If 自動開啟.Checked = False Then
            資料載入作業()
        End If

    End Sub

    Private Sub 製單載入作業(ByVal 作業 As String)
        If 製單.RowCount > 0 Then : 顯示資料.Tables("製單").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""

        SQLQuery = "     SELECT DISTINCT [製單編號],[入庫管理],COUNT(入庫條碼) AS '件數' "
        SQLQuery += "      FROM [" & INPDA1 & "] "
        SQLQuery += "     WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
        Select Case 作業
            Case "2" : SQLQuery += " AND [入庫管理] = 'S' "
            Case "3" : SQLQuery += " AND [入庫管理] = 'B' "
        End Select
        'SQLQuery += "       AND [生產日期] >= CONVERT(VARCHAR(10),DATEADD(DAY," & Datess1 & ",GETDATE()),120) "
        SQLQuery += "  GROUP BY [製單編號],[入庫管理] "
        SQLQuery += "  ORDER BY [製單編號] "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "製單")
            製單.DataSource = 顯示資料.Tables("製單")
            製單.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("製單載入異常：" & ex.Message)
        End Try

    End Sub

    'Private Sub 表身_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 表身.CellClick
    '    表身載入作業()
    'End Sub

    Private Sub 表身載入作業()
        If 表身.RowCount > 0 Then : 顯示資料.Tables("表身").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = "" ': Dim 作業 As String = "1"
        'If RB序號.Checked = True Then : 作業 = 2 : End If : If RB批次.Checked = True Then : 作業 = 3 : End If

        SQLQuery = "     SELECT DISTINCT [存編],[品名],SUM(CASE [入庫管理] WHEN 'S' THEN 1 WHEN 'B' THEN [數量] END) AS '數量',SUM([數量]) AS '單位數量', "
        'SQLQuery += "           SUM([標示重量]) AS '重量',SUM([實際重量]) AS '實際重量',[預設儲位]  "
        SQLQuery += "           SUM([標示重量]) AS '重量',[預設儲位] "
        SQLQuery += "      FROM [" & INPDA1 & "] "
        SQLQuery += "     WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
        SQLQuery += "       AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
        SQLQuery += "       AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "
        'SQLQuery += "       AND [生產日期] >= CONVERT(VARCHAR(10),DATEADD(DAY," & Datess1 & ",GETDATE()),120) "
        SQLQuery += "  GROUP BY [存編],[品名],[入庫管理],[預設儲位]  "
        SQLQuery += "  ORDER BY [存編] "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "表身")
            表身.DataSource = 顯示資料.Tables("表身")
            表身.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("表身載入異常：" & ex.Message)
            中止 = True
        End Try

    End Sub

    'Private Sub 明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 明細.CellClick
    '    明細載入作業()
    'End Sub

    Private Sub 明細載入作業()
        If 明細.RowCount > 0 Then : 顯示資料.Tables("明細").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = "" ': Dim 作業 As String = "1"
        'If RB序號.Checked = True Then : 作業 = 2 : End If : If RB批次.Checked = True Then : 作業 = 3 : End If

        SQLQuery = "     SELECT 製單編號,生產單號,'列號' = ROW_NUMBER() OVER (PARTITION BY 生產單號 ORDER BY 生產單號, 入庫條碼),入庫條碼,存編,品名,製單日期,製造日期,有效日期, "
        SQLQuery += "           數量,單位數量,標示重量,客戶代碼,條碼狀態,入庫庫位,庫存狀態,重覆 "
        SQLQuery += "      FROM [" & INPDA1 & "] T0 "
        SQLQuery += "     WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
        SQLQuery += "       AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
        SQLQuery += "       AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "明細")
            明細.DataSource = 顯示資料.Tables("明細")
            明細.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("明細載入異常：" & ex.Message)
            中止 = True
        End Try

    End Sub

    Private Sub 資料整合()
        LsCnt = 0 : LsXnt = 0 : LsQnt = 0
        For i As Integer = 0 To 表身.RowCount - 1
            If 表身.Rows(i).Cells("數量").Value <> 0 Then
                LsCnt += 表身.Rows(i).Cells("數量").Value
                LsXnt += Format(CSng(表身.Rows(i).Cells("重量").Value), "####0.00")
                LsQnt += Format(CSng(表身.Rows(i).Cells("單位數量").Value), "####0")
            End If
        Next

        入庫件數.Text = "入庫件數：  " & Format(LsCnt, "####0")
        入庫重量.Text = "入庫重量：  " & Format(LsXnt, "####0.00")
        入庫包數.Text = "入庫包數：  " & Format(LsQnt, "####0")
        明細件數.Text = "明細件數：  " & 明細.RowCount

    End Sub

    Private Sub 過帳日期_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 過帳日期.ValueChanged

        Dim ans As Long = DateDiff(DateInterval.Day, Date.Now, 過帳日期.Value.Date)
        'btnToB1FT = "True"
        If ans < Datess1 Then
            MsgBox("日期不能小於 " & Datess2 & "天!", 48, "警告")
            過帳日期.Value = Today()
            過帳日期.Focus()
            'btnToB1FT = "False"
        End If
    End Sub

    Private Sub 回存入庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 回存入庫.Click

    End Sub

    Private Sub 回存SAP入庫()
        '生產入庫
        Dim RetVal As Long : Dim ErrCode As Long : Dim ErrMsg As String : Dim Codess As String = ""
        Dim vDoc As SAPbobsCOM.Documents
        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
        '表頭_內容
        vDoc.UserFields.Fields.Item("U_CK02").Value = 製單.CurrentRow.Cells("製單編號").Value '製單號
        vDoc.UserFields.Fields.Item("U_CK06").Value = 收貨類型Type '收貨目地
        vDoc.DocDate = 過帳日期.Value.Date '文件日期

        '表身RB序號
        'If RB序號.Checked = True Then  '電宰
        If 製單.CurrentRow.Cells("入庫管理").Value = "S" Then  '電宰
            '製單.CurrentRow.Cells("入庫管理").Value
            For i As Integer = 0 To 表身.RowCount - 1
                Codess = ""
                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = Trim(表身.Rows(i).Cells("存編").Value)                                 '項目號碼
                vDoc.Lines.Quantity = 表身.Rows(i).Cells("數量").FormattedValue                              '件數
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = 表身.Rows(i).Cells("重量").FormattedValue  '重量
                vDoc.Lines.WarehouseCode = CStr(表身.Rows(i).Cells("預設儲位").FormattedValue)                     '預設儲位
                '列出錯誤
                Codess = Trim(表身.Rows(i).Cells("存編").Value) & " S"   '錯誤項目號碼
                'MsgBox(Codess)

                '明細
                Dim Cnt0 As Integer = 0
                For j As Integer = 0 To 明細.RowCount - 1
                    'If Trim(dgvSourceList.Rows(j).Cells("FI107").Value) = Codess Then
                    If Trim(明細.Rows(j).Cells("存編").Value) = Trim(表身.Rows(i).Cells("存編").Value) Then
                        vDoc.Lines.SerialNumbers.SetCurrentLine(Cnt0)
                        vDoc.Lines.SerialNumbers.InternalSerialNumber = 明細.Rows(j).Cells("入庫條碼").Value '條碼
                        'ReceptionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        vDoc.Lines.SerialNumbers.ReceptionDate = 明細.Rows(j).Cells("製單日期").Value        '製單日期 InDate
                        vDoc.Lines.SerialNumbers.ManufactureDate = 明細.Rows(j).Cells("製造日期").Value      '生產日期 MnfDate
                        vDoc.Lines.SerialNumbers.ExpiryDate = 明細.Rows(j).Cells("有效日期").Value           '有效日期 ExpDate
                        vDoc.Lines.SerialNumbers.Add()
                        'MsgBox(Cnt0)   '顯示執行列數
                        Cnt0 += 0 + 1
                    End If
                Next

                vDoc.Lines.Add()
                'PBar1.Value = i
            Next
        End If

        '表身RB批次
        'If RB批次.Checked = True Then  '加工
        If 製單.CurrentRow.Cells("入庫管理").Value = "B" Then
            For ix As Integer = 0 To 表身.RowCount - 1
                vDoc.Lines.SetCurrentLine(ix)
                vDoc.Lines.ItemCode = 表身.Rows(ix).Cells("存編").Value '項目號碼
                vDoc.Lines.Quantity = 表身.Rows(ix).Cells("數量").Value '件數_回傳包數
                vDoc.Lines.WarehouseCode = CStr(表身.Rows(ix).Cells("預設儲位").FormattedValue)                     '預設儲位
                '列出錯誤
                Codess = Trim(表身.Rows(ix).Cells("存編").Value) & " B" '錯誤項目號碼
                'MsgBox(Codess)

                '明細 
                Dim Cnt1 As Integer = 0
                For jx As Integer = 0 To 明細.RowCount - 1
                    If 明細.Rows(jx).Cells("存編").Value = Trim(表身.Rows(ix).Cells("存編").Value) Then
                        vDoc.Lines.BatchNumbers.SetCurrentLine(Cnt1)
                        vDoc.Lines.BatchNumbers.BatchNumber = 明細.Rows(jx).Cells("入庫條碼").Value       '條碼
                        'AddmisionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        vDoc.Lines.BatchNumbers.AddmisionDate = 明細.Rows(jx).Cells("製單日期").Value     '製單日期 InDate
                        vDoc.Lines.BatchNumbers.ManufacturingDate = 明細.Rows(jx).Cells("製造日期").Value '生產日期 MnfDate
                        vDoc.Lines.BatchNumbers.ExpiryDate = 明細.Rows(jx).Cells("有效日期").Value        '有效日期 ExpDate
                        vDoc.Lines.BatchNumbers.Quantity = 明細.Rows(jx).Cells("單位數量").Value          '數量_回傳包數
                        vDoc.Lines.BatchNumbers.Add()
                        'MsgBox(Cnt0)   '顯示執行列數
                        Cnt1 += 0 + 1
                    End If
                Next

                vDoc.Lines.Add()
                'PBar1.Value = ix
            Next
        End If

        RetVal = vDoc.Add
        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            Dim TS As TimeSpan = Now.Subtract(dteStart)
            MsgBox("製單轉入B1收貨單錯誤! " & Codess & vbCrLf & ErrCode & vbCrLf & ErrMsg, 16, "錯誤")
            Exit Sub
        Else
            'SyncSRN()  '更新資料
            '記錄存檔() '記錄急速
        End If

        DocNum2 = 0

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        DocNum2 = DocNum

        SyncSRN()  '更新資料
        '記錄存檔() '記錄急速
        Dim Doc As String = ""
        If SyncAns = False Then
            Doc = "x"
        End If

        入庫單號.Text = ""
        If 入庫單號.Text = "" Then
            入庫單號.Text = DocNum2 & Doc
        Else
            入庫單號.Text += "," & DocNum2 & Doc
        End If

        'If SyncAns = True Then
        '    'MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "SAP時間: " & TS1s & " 秒" & vbCrLf & "完成時間: " & TS2s & " 秒", 64, "完成")
        '    MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum, 64, "完成")
        'Else
        '    MsgBox("資料已至B1收貨單!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "但是條碼重量未更新!!" & vbCrLf & "請洽資訊室協助更新!!", 16, "未完成")
        'End If

    End Sub

    Private Sub SyncSRN()
        SyncAns = False
        Dim SQLQuery As String = ""
        Select Case 製單.CurrentRow.Cells("入庫管理").Value
            Case "S"
                SQLQuery = "  UPDATE [OSRN]                             SET [U_M8] = T1.[製單編號], [U_M1] = T1.[標示重量], [U_M2] = T1.[入庫庫位], [U_MC] = T1.[客戶代碼] "
                SQLQuery += "   FROM [OSRN] T0 INNER JOIN [" & INPDA1 & "] T1 ON T0.[DistNumber] = T1.[入庫條碼] COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "

                SQLQuery += " UPDATE [@FinishItem1]                        SET [FI103] = '4' "
                SQLQuery += "   FROM [@FinishItem1] T0 INNER JOIN [" & INPDA1 & "] T1 ON T0.[FI106] = T1.[入庫條碼] COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "

                SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA07] = '" & DocNum2 & "', [PDA06] = '4' ,[PDA05] = GETDATE() "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN [" & INPDA1 & "] S1 ON S0.[PDA03] = S1.[入庫條碼]  COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' AND LEFT(S0.[PDA02],2) COLLATE Chinese_PRC_CI_AS = '11' "

                SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA07] = '" & DocNum2 & "', [PDA06] = '4' ,[PDA05] = GETDATE() "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN [" & INPDA1 & "] S1 ON S0.[PDA03] = S1.[入庫條碼]  COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' AND LEFT(S0.[PDA02],2) COLLATE Chinese_PRC_CI_AS = '1A' "

            Case "B"
                SQLQuery = "  UPDATE [OBTN]                             SET [U_M8] = T1.[製單編號], [U_M1] = T1.[標示重量], [U_M2] = T1.[入庫庫位], [U_MC] = T1.[客戶代碼] "
                SQLQuery += "   FROM [OBTN] T0 INNER JOIN [" & INPDA1 & "] T1 ON T0.[DistNumber] = T1.[入庫條碼] COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "

                SQLQuery += " UPDATE [@FinishItem2]                        SET [FI103] = '4' "
                SQLQuery += "   FROM [@FinishItem2] T0 INNER JOIN [" & INPDA1 & "] T1 ON T0.[FI106] = T1.[入庫條碼] COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "

                SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA07] = '" & DocNum2 & "', [PDA06] = '4' ,[PDA05] = GETDATE() "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN [" & INPDA1 & "] S1 ON S0.[PDA03] = S1.[入庫條碼] COLLATE Chinese_PRC_CI_AS "
                SQLQuery += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
                SQLQuery += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
                SQLQuery += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' AND LEFT(S0.[PDA02],2) COLLATE Chinese_PRC_CI_AS = '12' "
                'SQLQuery = "  UPDATE [OBTN]                                SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T1.[IN04], [U_MC] = T1.[FI119] "
                'SQLQuery += "   FROM [OBTN] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[DistNumber] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                'SQLQuery += " UPDATE [@FinishItem2]                        SET [FI103] = '4' "
                'SQLQuery += "   FROM [@FinishItem2] T0 INNER JOIN " & Intmp2 & " T1 ON T0.[FI106] = T1.[FI106] AND T1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
                'SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData_SAP] SET [IN07] = '" & DocNum2 & "', [IN06] = '4' "
                'SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData_SAP] S0 INNER JOIN " & Intmp2 & " S1 ON S0.[IN02] = S1.[FI106] AND S1.[FI102] = '" & 製單DGV.CurrentRow.Cells("FI102").Value & "' "
        End Select

        'SQLQuery += " EXEC  [dbo].[預_SAP磅秤更新01v] "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            'MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            'Dim oAns As Integer
            'oAns = MsgBox("是否要重新更新條碼重量?", 36, "警告")
            'If oAns = MsgBoxResult.Yes Then
            '    SyncSRN()

            'Else
            SyncAns = False
            'Exit Sub
            'End If
        End Try

        SyncAns = True

    End Sub








    'Private Sub 文字初始化()
    '    La數量.Text = "0筆"
    '    La入庫.Text = "0筆"
    '    La出庫.Text = "0筆"
    '    La作廢.Text = "0筆"
    '    La異常.Text = "0筆"
    '    La重複.Text = "0筆"
    '    La時間.Text = "查詢時間 0.00 秒"

    '    'CB作業別.Items.Clear()
    '    'CB顯示鮮享.Visible = False

    '    'Select Case La作業.Text
    '    '    Case "入庫"
    '    '        CB作業別.Visible = True
    '    '        Bu更換.Visible = True
    '    '        Bu勾選.Visible = False
    '    '        CB作業別.Items.Add("")
    '    '        CB作業別.Items.Add("11.電宰入庫")
    '    '        CB作業別.Items.Add("12.加工入庫")

    '    '    Case "出庫"
    '    '        CB作業別.Visible = False
    '    '        Bu更換.Visible = False
    '    '        Bu勾選.Visible = True
    '    '        CB作業別.Items.Add("")
    '    '        'CB作業別.Items.Add("")
    '    '        'CB作業別.Items.Add("")
    '    '        CB顯示鮮享.Visible = True

    '    '    Case "單據入庫"
    '    '        CB作業別.Visible = False
    '    '        Bu更換.Visible = False
    '    '        Bu勾選.Visible = False
    '    '        CB作業別.Items.Add("")
    '    '        'CB作業別.Items.Add("")
    '    '        'CB作業別.Items.Add("")

    '    'End Select

    'End Sub

    'Private Sub 清除暫存()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = "    IF (OBJECT_ID('tempdb.." & SyncPDA1 & "') IS NOT NULL)  DROP TABLE " & SyncPDA1 & " "
    '    SQLQuery += "   IF (OBJECT_ID('tempdb.." & SyncPDA2 & "') IS NOT NULL)  DROP TABLE " & SyncPDA2 & " "
    '    SQLQuery += "   IF (OBJECT_ID('tempdb.." & SyncPDA3 & "') IS NOT NULL)  DROP TABLE " & SyncPDA3 & " "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Try
    '        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
    '        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub


    ''PDA作業開始
    'Private Sub Bu讀取_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu讀取.Click
    '    dteStart = Now  ''...要計算執行時間的程式區段 ...
    '    清除暫存()

    '    Select Case La作業.Text
    '        Case "入庫"
    '            ''入庫代碼 = "'11','12'"
    '            '讀取條碼入庫() : DGV1選擇 = "N"
    '            '讀取條碼儲位()
    '            'DGV1_入庫檢查資料()
    '        Case "出庫"
    '            '讀取條碼出庫() : DGV1選擇 = "N"
    '            'DGV1_出庫檢查資料()
    '        Case "單據入庫"
    '            ''入庫代碼 = "'13'"
    '            '讀取條碼入庫()
    '            '讀取條碼儲位()
    '            'DGV1_入庫檢查資料()
    '    End Select

    '    Dim 執行時間s As String = "0.00"
    '    Dim 執行時間a As TimeSpan = Now.Subtract(dteStart)
    '    執行時間s = "查詢時間 " & Format(執行時間a.TotalSeconds, "###0.00" & " 秒")
    '    La時間.Text = 執行時間s

    '    DGV1.AutoResizeColumns()
    'End Sub

    Private Sub Bu更新資料_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu更新資料.Click
        Dim SQLQuery As String = ""
        SQLQuery += " EXEC  [dbo].[預_SAP磅秤更新01v] "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            'MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        End Try
        MsgBox("更新條碼完成")
    End Sub
End Class