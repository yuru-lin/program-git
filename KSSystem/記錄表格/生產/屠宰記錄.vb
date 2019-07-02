Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 屠宰記錄
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim YesNo As Boolean

    Private Sub 屠宰記錄_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Login.LogonUserName = "MANAGER" Or Login.LogonUserName = "manager" Then
            Panel1.Visible = True
        End If

        '品管
        If Login.LogonUserName = "QC" Or Login.LogonUserName = "qc" Then
            TextBox12.Text = "UB03"
            'Button5.Visible = True
            F12.Text = "雞 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(一)出冷卻槽雞隻：  ℃ " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(二)分級槽雞隻(  kg)：  ℃"
        End If
        '生產
        If Login.LogonUserName = "KS51" Or Login.LogonUserName = "KS14" Or _
           Login.LogonUserName = "ks51" Or Login.LogonUserName = "ks14" Then
            TextBox12.Text = "UE01"
        End If
        '倉儲
        If Login.LogonUserName = "KS09" Or Login.LogonUserName = "KS10" Or Login.LogonUserName = "KS16" Or _
           Login.LogonUserName = "ks09" Or Login.LogonUserName = "ks10" Or Login.LogonUserName = "ks10" Then
            TextBox12.Text = "UE05"
        End If

        TextBox10.Text = System.Net.Dns.GetHostName()
        TextBox11.Text = Login.LogonUserName
        'GetUserName()
        Sid_Update()
        If Login.LogonUserName = "MANAGER" Or Login.LogonUserName = "manager" Or Login.LogonUserName = "MARK" Or Login.LogonUserName = "mark" Then
            查詢所有DGV1()
        Else
            查詢DGV1()
        End If
        F03.Text = 0
        F04.Text = 0


        Button1.Enabled = True    '開啟新增
        Button2.Enabled = True    '開啟修改
        Button3.Enabled = False   '關閉更新
        Button4.Enabled = True    '開啟資料

    End Sub

    Private Sub GetUserName()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader1 As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "Select U_NAME from OUSR where USER_CODE = '" & Login.LogonUserName & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            sqlReader1 = SQLCmd.ExecuteReader
            sqlReader1.Read()
            If Not sqlReader1.HasRows() Then
                TextBox11.Text = Login.LogonUserName
                sqlReader1.Close()
            Else
                TextBox11.Text = sqlReader1.Item("U_NAME")
                sqlReader1.Close()
            End If

            If sqlReader1.IsClosed = False Then
                sqlReader1.Close()
            End If
            TransactionMonitor.Complete()
        End Using

    End Sub



    Private Function Sid_Add()
        '產生Sid
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [Sid] FROM [Z_KS_Record_01] ORDER BY [Sid] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Sid") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub Sid_Update()
        '更新Sid
        Dim i As Integer
        i = Sid_Add()
        If i = 0 Then
            MsgBox("載入Sid資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        TextBox9.Text = i

    End Sub

    Private Sub Button0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button0.Click
        '--查詢資料按鈕

        Button1.Enabled = True    '開啟新增
        Button2.Enabled = True    '開啟修改
        Button3.Enabled = False   '關閉更新
        Button4.Enabled = True    '開啟資料

        F01.Text = ""
        F02.Text = ""
        F03.Text = 0
        F04.Text = 0
        F05.Text = ""
        F06.Text = ""
        F07.Text = ""
        F08.Text = ""
        F09.Text = ""
        F10.Text = ""
        F11.Text = ""
        F12.Text = ""

        Sid_Update()
        '查詢DGV1()
        If Login.LogonUserName = "MANAGER" Or Login.LogonUserName = "manager" Or Login.LogonUserName = "MARK" Or Login.LogonUserName = "mark" Then
            查詢所有DGV1()
        Else
            查詢DGV1()
        End If

    End Sub

    Private Sub 查詢DGV1()
        '--查詢資料程式
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "    SELECT [Sid] AS 'Sid', (CASE [Kid2] WHEN 'UE01' THEN '生產' WHEN 'UB03' THEN '品管' WHEN 'UE05' THEN '倉儲' ELSE '??單位' END) AS '單位', [F01] AS '製造單號', [F02] AS '記錄時間', [F03] AS '水溫', [F04] AS '品溫', [F05] AS '開始時間', [F06] AS '結束日期', [F07] AS '結束時間', [F08] AS '設備異常', [F09] AS '機械次級率', [F10] AS '雞隻狀況', [F11] AS '生產異常', [F12] AS '異常說明' "
            sql += "     FROM [Z_KS_Record_01] "

            If Login.LogonUserName = "MANAGER" Or Login.LogonUserName = "manager" Or Login.LogonUserName = "MARK" Or Login.LogonUserName = "mark" Then
                sql += "    WHERE [DocDate] = '" & DatePicker1.Value.Date & "' AND [Cancel] = 'Y'"
            Else
                sql += "    WHERE [DocDate] = '" & DatePicker1.Value.Date & "' AND [Kid2] = '" & TextBox12.Text & "' AND [Cancel] = 'Y'"
            End If


            'sql += "    WHERE [DocDate] = '" & DatePicker1.Value.Date & "' AND [Kid2] = '" & TextBox12.Text & "' AND [Cancel] = 'Y' "
            sql += " ORDER BY 1 "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")
            TransactionMonitor.Complete()
        End Using
        查詢DGV1Display()

    End Sub

    Private Sub 查詢DGV1Display()
        '--載入資料畫面
        For Each column As DataGridViewColumn In DGV1.Columns

            column.ReadOnly = True  'DataGridView 設定單元格不可編輯
            column.Visible = True

            Select Case column.Name
                Case "Sid" : column.HeaderText = "Sid"
                    column.DisplayIndex = 0 : column.Visible = False
                Case "單位" : column.HeaderText = "單位"
                    column.DisplayIndex = 1 : column.Visible = True
                    'If Login.LogonUserName = "MANAGER" Or Login.LogonUserName = "manager" Or Login.LogonUserName = "MARK" Or Login.LogonUserName = "mark" Or Login.LogonUserName = "QC" Or Login.LogonUserName = "qc" Then
                    '    column.DisplayIndex = 1 : column.Visible = True
                    'Else
                    '    column.DisplayIndex = 1 : column.Visible = False
                    'End If

                Case "製造單號" : column.HeaderText = "製造單號"
                    column.DisplayIndex = 2 : column.Visible = True
                Case "記錄時間" : column.HeaderText = "記錄時間"
                    column.DisplayIndex = 3 : column.Visible = True
                Case "水溫" : column.HeaderText = "水溫"
                    column.DisplayIndex = 4 : column.Visible = True
                Case "品溫" : column.HeaderText = "品溫"
                    column.DisplayIndex = 5 : column.Visible = True
                Case "開始時間" : column.HeaderText = "開始時間"
                    column.DisplayIndex = 7 : column.Visible = True
                Case "結束日期" : column.HeaderText = "結束日期"
                    column.DisplayIndex = 6 : column.Visible = True
                Case "結束時間" : column.HeaderText = "結束時間"
                    column.DisplayIndex = 8 : column.Visible = True
                Case "設備異常" : column.HeaderText = "設備異常"
                    column.DisplayIndex = 9 : column.Visible = True
                Case "機械次級率" : column.HeaderText = "機械次級率"
                    column.DisplayIndex = 10 : column.Visible = True
                Case "雞隻狀況" : column.HeaderText = "雞隻狀況"
                    column.DisplayIndex = 11 : column.Visible = True
                Case "生產異常" : column.HeaderText = "生產異常"
                    column.DisplayIndex = 12 : column.Visible = True
                Case "異常說明" : column.HeaderText = "異常說明"
                    column.DisplayIndex = 13 : column.Visible = True

                Case Else

                    column.Visible = False

            End Select
        Next

        DGV1.AutoResizeColumns()

        DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯
    End Sub

    Private Sub 檢討日期()

        Dim a01 As Long = DateDiff(DateInterval.Day, Date.Now, DatePicker1.Value.Date)   '輸入日期和本日日期差異
        Dim a02 As Integer = Weekday(Now()) '判定星期幾

        'a02 = Weekday(Now())
        YesNo = True

        If Login.LogonUserName = "MANAGER" Or Login.LogonUserName = "manager" Or Login.LogonUserName = "MARK" Or Login.LogonUserName = "mark" Then

        Else

            If a02 = 2 Or a02 = 3 Then  '一 = 2, 二 = 3    
                If a01 < -45 Then        '-4
                    YesNo = False
                    MsgBox("超過3天無法新增&修改&刪除!", 48, "警告")
                    DatePicker1.Text = Today()
                    Exit Sub
                End If
            Else
                If a01 < -45 Then        '-2
                    YesNo = False
                    MsgBox("超過3天無法新增&修改&刪除!", 48, "警告")
                    DatePicker1.Text = Today()
                    Exit Sub
                End If
            End If

        End If

        'If a02 = 2 Or a02 = 3 Then  '一 = 2, 二 = 3
        '    If a01 < -4 Then
        '        YesNo = False
        '        MsgBox("超過3天無法新增&修改&刪除!", 48, "警告")
        '        DatePicker1.Text = Today()
        '        Exit Sub
        '    End If
        'Else
        '    If a01 < -2 Then
        '        YesNo = False
        '        MsgBox("超過3天無法新增&修改&刪除!", 48, "警告")
        '        DatePicker1.Text = Today()
        '        Exit Sub
        '    End If
        'End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '--新增資料

        If TextBox12.Text = "" Then
            MsgBox("非生產及品管單位無法新增!", 16, "錯誤")
            Exit Sub
        End If

        檢討日期()

        If YesNo = False Then
            Exit Sub
        End If


        Dim Row As DataRow
        Row = ks1DataSetDGV.Tables("DGV1").NewRow
        Row.Item("Sid") = TextBox9.Text
        Row.Item("製造單號") = F01.Text
        Row.Item("記錄時間") = F02.Text
        Row.Item("水溫") = F03.Text
        Row.Item("品溫") = F04.Text
        Row.Item("開始時間") = F05.Text
        Row.Item("結束日期") = F06.Text
        Row.Item("結束時間") = F07.Text
        Row.Item("設備異常") = F08.Text
        Row.Item("機械次級率") = F09.Text
        Row.Item("雞隻狀況") = F10.Text
        Row.Item("生產異常") = F11.Text
        Row.Item("異常說明") = F12.Text

        ks1DataSetDGV.Tables("DGV1").Rows.Add(Row)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim Cancel As String = "Y"
        Try
            sql = " INSERT INTO [Z_KS_Record_01] ([DocDate],[Pid],[Kid1],[Kid2],[STime1],[F01],[F02],[F03],[F04],[F05],[F06],[F07],[F08],[F09],[F10],[F11],[F12],[Cancel]) VALUES "
            'sql += " ('" & TextBox9.Text & "'         ,"    'Sid
            sql += " ('" & DatePicker1.Value.Date & "' ,"    'DocDate
            sql += "  '" & TextBox10.Text & "'         ,"    'Pid
            sql += "  '" & TextBox11.Text & "'         ,"    'Kid1
            sql += "  '" & TextBox12.Text & "'         ,"    'Kid2
            sql += "  getdate()                        ,"    'STime1
            sql += "  '" & F01.Text & "'               ,"    'F01
            sql += "  '" & F02.Text & "'               ,"    'F02
            sql += "  '" & F03.Text & "'               ,"    'F03
            sql += "  '" & F04.Text & "'               ,"    'F04
            sql += "  '" & F05.Text & "'               ,"    'F05
            sql += "  '" & F06.Text & "'               ,"    'F06
            sql += "  '" & F07.Text & "'               ,"    'F07
            sql += "  '" & F08.Text & "'               ,"    'F08
            sql += "  '" & F09.Text & "'               ,"    'F09
            sql += "  '" & F10.Text & "'               ,"    'F10
            sql += "  '" & F11.Text & "'               ,"    'F11
            sql += "  '" & F12.Text & "'               ,"    'F12
            sql += "  'Y'                              )"    'Cancel
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("新增項目完成!", 64, "成功")

        F01.Text = ""
        F02.Text = ""
        F03.Text = 0
        F04.Text = 0
        F05.Text = ""
        F06.Text = ""
        F07.Text = ""
        F08.Text = ""
        F09.Text = ""
        F10.Text = ""
        F11.Text = ""
        'F12.Text = ""
        '品管
        If Login.LogonUserName = "QC" Or Login.LogonUserName = "qc" Then
            F12.Text = "雞 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(一)出冷卻槽雞隻：  ℃ " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(二)分級槽雞隻(  kg)：  ℃"
        Else
            F12.Text = ""
        End If



        Sid_Update()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '修改資料

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可修改!", 16, "錯誤")
            Exit Sub
        End If

        If TextBox12.Text = "" Then
            MsgBox("非生產及品管單位無法修改!", 16, "錯誤")
            Exit Sub
        End If

        'Dim ans As Long = DateDiff(DateInterval.Day, Date.Now, DatePicker1.Value.Date)

        'If ans < -2 Then
        '    MsgBox("超過3天無法修改!", 48, "警告")
        '    DatePicker1.Text = Today()
        '    Exit Sub
        'End If

        檢討日期()

        If YesNo = False Then
            Exit Sub
        End If

        Button1.Enabled = False   '關閉新增
        Button2.Enabled = False   '關閉修改
        Button3.Enabled = True    '開啟更新
        Button4.Enabled = False   '關閉資料

        F01.Enabled = False

        F01.Text = ""
        F02.Text = ""
        F03.Text = 0
        F04.Text = 0
        F05.Text = ""
        F06.Text = ""
        F07.Text = ""
        F08.Text = ""
        F09.Text = ""
        F10.Text = ""
        F11.Text = ""
        F12.Text = ""

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '更新資料

        If F01.Text = "" Then
            MsgBox("未選擇修改資料!", 16, "錯誤")
            Exit Sub
        End If

        DGV1_Update()
        DB_Update()

        F01.Enabled = True
        Sid_Update()

        Button1.Enabled = True    '開啟新增
        Button2.Enabled = True    '開啟修改
        Button3.Enabled = False   '關閉更新
        Button4.Enabled = True    '開啟資料

        F01.Text = ""
        F02.Text = ""
        F03.Text = 0
        F04.Text = 0
        F05.Text = ""
        F06.Text = ""
        F07.Text = ""
        F08.Text = ""
        F09.Text = ""
        F10.Text = ""
        F11.Text = ""
        'F12.Text = ""
        '品管
        If Login.LogonUserName = "QC" Or Login.LogonUserName = "qc" Then
            F12.Text = "雞 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(一)出冷卻槽雞隻：  ℃ " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(二)分級槽雞隻(  kg)：  ℃"
        Else
            F12.Text = ""
        End If

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        If Button2.Enabled = False Then

            F01.Text = DGV1.CurrentRow.Cells("製造單號").Value
            F02.Text = DGV1.CurrentRow.Cells("記錄時間").Value
            F03.Text = DGV1.CurrentRow.Cells("水溫").Value
            F04.Text = DGV1.CurrentRow.Cells("品溫").Value
            F05.Text = DGV1.CurrentRow.Cells("開始時間").Value
            F06.Text = DGV1.CurrentRow.Cells("結束日期").Value
            F07.Text = DGV1.CurrentRow.Cells("結束時間").Value
            F08.Text = DGV1.CurrentRow.Cells("設備異常").Value
            F09.Text = DGV1.CurrentRow.Cells("機械次級率").Value
            F10.Text = DGV1.CurrentRow.Cells("雞隻狀況").Value
            F11.Text = DGV1.CurrentRow.Cells("生產異常").Value
            F12.Text = DGV1.CurrentRow.Cells("異常說明").Value

        End If

    End Sub


    Private Sub DGV1_Update()

        DGV1.CurrentRow.Cells("記錄時間").Value = F02.Text
        DGV1.CurrentRow.Cells("水溫").Value = F03.Text
        DGV1.CurrentRow.Cells("品溫").Value = F04.Text
        DGV1.CurrentRow.Cells("開始時間").Value = F05.Text
        DGV1.CurrentRow.Cells("結束日期").Value = F06.Text
        DGV1.CurrentRow.Cells("結束時間").Value = F07.Text
        DGV1.CurrentRow.Cells("設備異常").Value = F08.Text
        DGV1.CurrentRow.Cells("機械次級率").Value = F09.Text
        DGV1.CurrentRow.Cells("雞隻狀況").Value = F10.Text
        DGV1.CurrentRow.Cells("生產異常").Value = F11.Text
        DGV1.CurrentRow.Cells("異常說明").Value = F12.Text

    End Sub

    Private Sub DB_Update()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            '    For i As Integer = 0 To DGV1.RowCount - 1

            sql = " UPDATE [Z_KS_Record_01] SET "
            sql += "       [F02] = '" & F02.Text & "' , "
            sql += "       [F03] = '" & F03.Text & "' , "
            sql += "       [F04] = '" & F04.Text & "' , "
            sql += "       [F05] = '" & F05.Text & "' , "
            sql += "       [F06] = '" & F06.Text & "' , "
            sql += "       [F07] = '" & F07.Text & "' , "
            sql += "       [F08] = '" & F08.Text & "' , "
            sql += "       [F09] = '" & F09.Text & "' , "
            sql += "       [F10] = '" & F10.Text & "' , "
            sql += "       [F11] = '" & F11.Text & "' , "
            sql += "       [F12] = '" & F12.Text & "'   "
            sql += " WHERE [Sid] = '" & DGV1.CurrentRow.Cells("Sid").Value & "' AND [Cancel]  = 'Y' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            'Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        'MsgBox("更新至資料庫完成!", 64, "成功")
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        '刪除資料

        If TextBox12.Text = "" Then
            MsgBox("非生產及品管單位無法刪除!", 16, "錯誤")
            Exit Sub
        End If

        檢討日期()

        If YesNo = False Then
            Exit Sub
        End If

        Button4.Enabled = False

        If Button4.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                刪除資料()
                查詢DGV1()

            End If
        End If

        Button4.Enabled = True

    End Sub

    Private Sub 刪除資料()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            '    For Each oRow As DataGridViewRow In DGV1.SelectedRows

            sql = " UPDATE [Z_KS_Record_01] SET [Cancel] = 'D' "
            sql += " WHERE [Sid] = '" & DGV1.CurrentRow.Cells("Sid").Value & "' AND [Cancel]  = 'Y' "
            'sql += " WHERE [Sid] = '" & oRow.Cells("Sid").Value & "' AND [Cancel]  = 'Y' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            'Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("刪除項目完成!", 64, "成功")
    End Sub

    Private Sub 查詢所有_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢所有.Click

        Button1.Enabled = False   '關閉新增
        Button2.Enabled = False   '關閉修改
        Button3.Enabled = False   '關閉更新
        Button4.Enabled = False   '關閉資料

        查詢所有DGV1()
    End Sub

    Private Sub 查詢所有DGV1()
        '--查詢資料程式
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "    SELECT [Sid] AS 'Sid', (CASE [Kid2] WHEN 'UE01' THEN '生產' WHEN 'UB03' THEN '品管' WHEN 'UE05' THEN '倉儲' ELSE '??單位' END) AS '單位', [F01] AS '製造單號', [F02] AS '記錄時間', [F03] AS '水溫', [F04] AS '品溫', [F05] AS '開始時間', [F06] AS '結束日期', [F07] AS '結束時間', [F08] AS '設備異常', [F09] AS '機械次級率', [F10] AS '雞隻狀況', [F11] AS '生產異常', [F12] AS '異常說明' "
            sql += "     FROM [Z_KS_Record_01] "
            sql += "    WHERE [DocDate] = '" & DatePicker1.Value.Date & "' AND [Cancel] = 'Y' "
            sql += " ORDER BY 1 "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")
            TransactionMonitor.Complete()
        End Using
        查詢DGV1Display()

    End Sub


End Class