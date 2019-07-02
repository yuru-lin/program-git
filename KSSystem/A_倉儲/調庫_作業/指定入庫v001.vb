Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
Imports Microsoft.Reporting.WinForms

Public Class 指定入庫v001
    'Public DBConn As SqlConnection           'xxx
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim DGV調整儲位Dt As New DataTable

    Dim DGV調整儲位Dt2 As New DataTable

    Dim 目前作業 As String = ""
    Dim 選擇作業 As String = "Y"
    Dim 列印後續 As String = "Y"
    Dim 列印中止 As String = "N"
    Dim 列印連續 As String = "N"
    Dim 列印機台 As String = ""
    Dim 調庫單號 As String = ""
    Dim 新增單號 As String = ""
    Dim 數量限制 As Integer = 49

    Dim TimeA As DateTime

    Dim PrinterName As String '列印機選擇
    Dim DGV派工列印Dt As New DataTable


    'Public Sub ConnDB() 'xxx
    '    DBConn = New SqlConnection("Data Source = " & DBServer & "; Initial Catalog = " & DBName & "; User ID = " & DBUser & "; Password = " & DBPass & "; Connection Timeout = 5")
    '    DBConn.Open()   '開啟連線
    '    'DBConn.Close() '結束連線
    'End Sub


    Private Sub 指定入庫_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ConnDB()    'xxx
        目前作業 = "查詢作業"
        Tb存編.Text = "" : Tb品名.Text = "" : Tb簡稱.Text = "" : Tb數量.Text = 0 : Tb板數.Text = 0 : Tb零散.Text = 0
        Tb儲位.Text = "" : Tb可放.Text = 0 : Tx可放.Text = 0 : Tb未排.Text = 0 : Tb來源.Text = ""

        Cb急速庫.SelectedIndex = 0
        AddDGV調整儲位Dt()
        T1調整儲位.DataSource = DGV調整儲位Dt

        'Dt日期.Value = "2018-08-14"    'xxx

    End Sub

    Private Sub AddDGV調整儲位Dt()
        'Dim 選擇 As DataColumn = New DataColumn("選擇") : 選擇.DataType = System.Type.GetType("System.Boolean") : DGV調整儲位Dt.Columns.Add(選擇)
        'Dim 日期 As DataColumn = New DataColumn("日期") : 日期.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(日期)
        'Dim 調庫日期 As DataColumn = New DataColumn("調庫日期") : 調庫日期.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(調庫日期)
        Dim 存編 As DataColumn = New DataColumn("存編") : 存編.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(存編)
        Dim 品名 As DataColumn = New DataColumn("品名") : 品名.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(品名)
        Dim 簡稱 As DataColumn = New DataColumn("簡稱") : 簡稱.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(簡稱)
        Dim 出庫數量 As DataColumn = New DataColumn("出庫數量") : 出庫數量.DataType = System.Type.GetType("System.Int16") : DGV調整儲位Dt.Columns.Add(出庫數量)
        Dim 儲位 As DataColumn = New DataColumn("儲位") : 儲位.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(儲位)
        Dim 數量 As DataColumn = New DataColumn("數量") : 數量.DataType = System.Type.GetType("System.Int16") : DGV調整儲位Dt.Columns.Add(數量)
        Dim 來源 As DataColumn = New DataColumn("來源") : 來源.DataType = System.Type.GetType("System.String") : DGV調整儲位Dt.Columns.Add(來源)

    End Sub

    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl1.Selected
        La分頁.Text = TabControl1.SelectedTab.Text
        If TabControl1.SelectedTab.Text <> "現有儲位-明細" Then

        End If
    End Sub

    Private Sub TabControl2_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl2.Selected

        Select Case 目前作業
            Case "查詢作業" : Me.TabControl2.SelectedTab = Me.Tp2查詢
                'If TabControl2.SelectedTab.Text = "查詢單據" Then
                '    Me.TabControl2.SelectedTab = Me.Tp2查詢
                'Else
                '    Me.TabControl2.SelectedTab = Me.Tp2查詢 : Me.TabControl2.SelectedTab = Me.Tp2查單
                'End If
            Case "調庫作業" : Me.TabControl2.SelectedTab = Me.Tp2調庫
                'Case "查詢單據" : Me.TabControl2.SelectedTab = Me.Tp2查單
            Case Else
        End Select
        'MsgBox(TabControl2.SelectedTab.Text)
    End Sub

    'Private Sub Bu回查_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu回查.Click
    '    Me.TabControl2.SelectedTab = Me.Tp2查詢
    'End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click

        Select Case Bu查詢.Text
            Case "查詢"
                T1急速統計載入() : Dt日期.Enabled = False : Cb急速庫.Enabled = False
                Bu查詢.Text = "重查"
                If T1急速統計.RowCount = 0 Then : 轉Excel.Visible = False : Else : 轉Excel.Visible = True : End If
                Dt調庫.Value = Dt日期.Value.Date.AddDays(2)
            Case "重查"
                If T1急速統計.RowCount > 0 Then : 顯示資料.Tables("急速統計").Clear() : End If '清除資料
                If T1急速明細.RowCount > 0 Then : 顯示資料.Tables("急速明細").Clear() : End If '清除資料
                If T1現有儲位.RowCount > 0 Then : 顯示資料.Tables("現有儲位").Clear() : End If '清除資料
                If T1空件儲位.RowCount > 0 Then : 顯示資料.Tables("空件儲位").Clear() : End If '清除資料
                If T1調整儲位.RowCount > 0 Then : DGV調整儲位Dt.Clear() : End If
                Dt日期.Enabled = True : Cb急速庫.Enabled = True
                Bu查詢.Text = "查詢"
                轉Excel.Visible = False
        End Select


    End Sub

    Private Sub 轉Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉Excel.Click
        DataToExcel(T1急速統計, "出急速統計" & Format(Dt日期.Value.Date, "yyyy-MM-dd"))
    End Sub

    Private Sub T1急速統計載入()
        If T1急速統計.RowCount > 0 Then : 顯示資料.Tables("急速統計").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AA','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','" & Cb急速庫.Text & "','' "
        TimeA = Now()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "急速統計")
            T1急速統計.DataSource = 顯示資料.Tables("急速統計")
            T1急速統計.AutoResizeColumns()
            T1Time1.Text = Format((Now() - TimeA).TotalSeconds, "0.##")

        Catch ex As Exception
            MsgBox("急速統計：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub T1急速統計_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1急速統計.CellClick
        If T1急速統計.CurrentRow.Cells("已排").Value > 0 Then : MsgBox("已有排定請重新選擇") : Exit Sub : End If
        If T1急速統計.RowCount > 0 Then
            Dim oAns As Integer
            oAns = MsgBox("更換查詢品項?" & Chr(13) & vbCrLf & Tb存編.Text & vbCrLf & T1急速統計.CurrentRow.Cells("存編").Value, MsgBoxStyle.OkCancel + 16, "更換查詢品項")
            If oAns = MsgBoxResult.Ok Then
                T1現有儲位載入() : T1急速明細載入() : T1空件儲位載入()
                Tb存編.Text = T1急速統計.CurrentRow.Cells("存編").Value
                Tb品名.Text = T1急速統計.CurrentRow.Cells("品名").Value
                Tb簡稱.Text = T1急速統計.CurrentRow.Cells("簡稱").Value
                Tb數量.Text = T1急速統計.CurrentRow.Cells("數量").Value
                Tb板數.Text = T1急速統計.CurrentRow.Cells("板數").Value
                Tb零散.Text = T1急速統計.CurrentRow.Cells("零散").Value
                Tb未排.Text = T1急速統計.CurrentRow.Cells("數量").Value
                目前作業 = "調庫作業" : Me.TabControl2.SelectedTab = Me.Tp2調庫
                If T1急速統計.CurrentRow.Cells("板數").Value > 0 Then
                    Me.TabControl1.SelectedTab = Me.Tp空位
                Else
                    Me.TabControl1.SelectedTab = Me.Tp現有
                End If
                T1急速明細.AutoResizeColumns()
                T1現有儲位.AutoResizeColumns()
                T1空件儲位.AutoResizeColumns()
                T1調整儲位.AutoResizeColumns()
            Else : Exit Sub

            End If

        End If

    End Sub

    Private Sub T1急速明細載入()
        If T1急速明細.RowCount > 0 Then : 顯示資料.Tables("急速明細").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AB','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','" & Cb急速庫.Text & "','" & T1急速統計.CurrentRow.Cells("存編").Value & "' "

        TimeA = Now()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "急速明細")
            T1急速明細.DataSource = 顯示資料.Tables("急速明細")
            T1急速明細.AutoResizeColumns()
            T2Time1.Text = Format((Now() - TimeA).TotalSeconds, "0.##")

        Catch ex As Exception
            MsgBox("急速明細：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub T1空件儲位載入()
        If T1空件儲位.RowCount > 0 Then : 顯示資料.Tables("空件儲位").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AC','','','' "

        TimeA = Now()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "空件儲位")
            T1空件儲位.DataSource = 顯示資料.Tables("空件儲位")
            T1空件儲位.AutoResizeColumns()
            T2Time2.Text = Format((Now() - TimeA).TotalSeconds, "0.##")

        Catch ex As Exception
            MsgBox("空件儲位：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub T1現有儲位載入()
        If T1現有儲位.RowCount > 0 Then : T1現有儲位.DataSource = Nothing : 顯示資料.Tables("現有儲位").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AD','','','" & T1急速統計.CurrentRow.Cells("存編").Value & "' "

        TimeA = Now()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "現有儲位")
            T1現有儲位.DataSource = 顯示資料.Tables("現有儲位")
            T1現有儲位.AutoResizeColumns()
            T2Time3.Text = Format((Now() - TimeA).TotalSeconds, "0.##")

        Catch ex As Exception
            MsgBox("現有儲位：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub Bu明細_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu明細.Click
        If T1現有儲位.RowCount > 0 And Tb儲位.Text <> "" Then
            Me.TabControl1.SelectedTab = Me.Tp明細
            T1現有儲位明細載入()

        End If

    End Sub

    Private Sub T1現有儲位明細載入()
        If T1儲位明細.RowCount > 0 Then : 顯示資料.Tables("儲位明細").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'ABA',NULL,'" & Tb儲位.Text & "',NULL "

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "儲位明細")
            T1儲位明細.DataSource = 顯示資料.Tables("儲位明細")
            T1儲位明細.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("儲位明細：" & ex.Message) : Exit Sub
        End Try

    End Sub

    ''儲位選擇-開始
    Private Sub T1現有儲位_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1現有儲位.CellClick
        If T1現有儲位.CurrentRow.Cells("可放數量").Value = 0 Then : MsgBox("已無數量可以排入，請重選儲位") : Exit Sub : End If
        If T1現有儲位.RowCount > 0 Then
            If Cb自定.Checked = False Then
                Tb來源.Text = "現有" : Tb儲位.Text = T1現有儲位.CurrentRow.Cells("儲位").Value : Tx可放.Text = T1現有儲位.CurrentRow.Cells("可放數量").Value
            Else
                Tb來源.Text = "自定" : Tb儲位.Text = T1現有儲位.CurrentRow.Cells("儲位").Value : Tx可放.Text = T1現有儲位.CurrentRow.Cells("可放數量").Value
            End If

        End If
    End Sub

    Private Sub T1空件儲位_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1空件儲位.CellClick
        If T1空件儲位.CurrentRow.Cells("最大數量").Value = 0 Then : MsgBox("已無數量可以排入，請重選儲位") : Exit Sub : End If
        If T1空件儲位.RowCount > 0 Then
            Tb來源.Text = "空位" : Tb儲位.Text = T1空件儲位.CurrentRow.Cells("儲位").Value : Tx可放.Text = T1空件儲位.CurrentRow.Cells("最大數量").Value
            'Tb可放.Text = T1空件儲位.CurrentRow.Cells("最大數量").Value

        End If
    End Sub
    ''儲位選擇-結束

    Private Sub Cb解除_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb解除.CheckedChanged
        If Cb解除.Checked = False Then
            數量限制 = 49
        Else
            數量限制 = 101
        End If

    End Sub

    Private Sub Bu新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu新增.Click


        If Cb自定.Checked = False Then
            If Tb儲位.Text = "" Then : MsgBox("未選擇儲位，無法新增") : Exit Sub : End If
            If CInt(Tb未排.Text) = 0 Then : MsgBox("已無數量可以排入，無法新增") : Exit Sub : End If
            If CInt(Tb可放.Text) = 0 Then : MsgBox("放置數量為 0，無法新增") : Exit Sub : End If
            If CInt(Tb可放.Text) >= 數量限制 Then : MsgBox("放置數量超過" & (數量限制 - 1) & "件，無法新增") : Exit Sub : End If
            If CInt(Tb未排.Text) < CInt(Tb可放.Text) Then : MsgBox("放置數量超過剩餘可放置數量，無法新增") : Exit Sub : End If
            If CInt(Tx可放.Text) < CInt(Tb可放.Text) And Cb解除.Checked = False Then : MsgBox("放置數量超過可放置數量，無法新增") : Exit Sub : End If

            If Tb可放.Text <> "" Or Tb可放.Text > 0 Then
                DGV線上撿貨Dt項目新增()
                Select Case Tb來源.Text
                    Case "現有"
                        T1現有儲位.CurrentRow.Cells("可放數量").Value = T1現有儲位.CurrentRow.Cells("可放數量").Value - CInt(Tb可放.Text)
                    Case "空位"
                        T1空件儲位.CurrentRow.Cells("最大數量").Value = T1空件儲位.CurrentRow.Cells("最大數量").Value - CInt(Tb可放.Text)
                    Case Else
                End Select
            End If
        Else
            If Tb儲位.Text = "" Then : MsgBox("未選擇儲位，無法新增") : Exit Sub : End If
            If CInt(Tb可放.Text) >= 數量限制 Then : MsgBox("放置數量超過" & (數量限制 - 1) & "件，無法新增") : Exit Sub : End If
            If CInt(Tx可放.Text) < CInt(Tb可放.Text) And Cb解除.Checked = False Then : MsgBox("放置數量超過可放置數量，無法新增") : Exit Sub : End If
            DGV線上撿貨Dt項目新增()
        End If
        DGVTb未排數量計算() : Cb自定.Checked = False : Cb解除.Checked = False
        If Bu品名.Text = "查詢放棄" Then : Bu品名.PerformClick() : End If
        Tb來源.Text = "" : Tb儲位.Text = "" : Tb可放.Text = 0 : Tx可放.Text = 0

    End Sub

    Private Sub DGVTb未排數量計算()
        Dim Ints As Integer = 0
        Dim countx As Integer = T1調整儲位.Rows.Count
        For x As Integer = countx - 1 To 0 Step -1
            If T1調整儲位.Rows(x).Cells("存編").Value = Tb存編.Text Then
                Ints = Ints + T1調整儲位.Rows(x).Cells("數量").Value
            End If
        Next
        Tb未排.Text = CInt(Tb數量.Text) - Ints

    End Sub

    Private Sub DGV線上撿貨Dt項目新增()
        Dim Row As DataRow
        Row = DGV調整儲位Dt.NewRow
        'Row.Item("日期") = Format(Dt日期.Value.Date, "yyyy-MM-dd")
        'Row.Item("調庫日期") = Format(Today(), "yyyy-MM-dd")
        Row.Item("存編") = Tb存編.Text
        Row.Item("品名") = Tb品名.Text
        Row.Item("簡稱") = Tb簡稱.Text
        Row.Item("出庫數量") = Tb數量.Text
        Row.Item("儲位") = Tb儲位.Text
        Row.Item("數量") = Tb可放.Text
        Row.Item("來源") = Tb來源.Text
        DGV調整儲位Dt.Rows.Add(Row)

        T1調整儲位.DataSource = DGV調整儲位Dt
        T1調整儲位.AutoResizeColumns()
        'T1已排項目明細顯示()
        'T1已排項目載入False()

    End Sub


    Private Sub Bu存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu存檔.Click
        If T1調整儲位.RowCount = 0 Then : MsgBox("無排調庫無法存檔") : Exit Sub : End If
        '取得新調庫單號()
        '新增調庫單存檔()
        新調庫明細存檔()
        Cb自定.Checked = False : Cb解除.Checked = False
        If Bu品名.Text = "查詢放棄" Then : Bu品名.PerformClick() : End If
        T1急速統計.CurrentRow.Cells("已排").Value = Tb數量.Text
        T2結束作業()
        Bu已排.PerformClick()

    End Sub

    Private Sub 取得新調庫單號()
        Dim SQLADD As String = "" : 調庫單號 = "" : 新增單號 = ""
        'SQLADD = " SELECT TOP 1 ISNULL(MAX([單號]),'') AS '單號' FROM [KaiShingPlug].[dbo].[倉_指定入庫Main] WHERE [日期] = '" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "' "
        'SQLADD = " SELECT TOP 1 ISNULL(MAX([單號]),'') AS '單號' FROM [KaiShingPlug].[dbo].[倉_指定入庫Main] WHERE [調庫日期] = '" & Format(Today.Date, "yyyy-MM-dd") & "' "
        SQLADD = " SELECT TOP 1 ISNULL(MAX([單號]),'') AS '單號' FROM [KaiShingPlug].[dbo].[倉_指定入庫Main] WHERE [調庫日期] = '" & Format(Dt調庫.Value.Date, "yyyy-MM-dd") & "'  "
        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim sqlCmd As SqlCommand : Dim sqlReader As SqlDataReader
            sqlCmd = New SqlCommand(SQLADD, DBConn) : sqlReader = sqlCmd.ExecuteReader : sqlReader.Read()
            If sqlReader.HasRows() Then : 調庫單號 = sqlReader.Item("單號") : End If
            'MsgBox(sqlReader.Item("單號")) : MsgBox(調庫單號)

            sqlReader.Close()
            If 調庫單號 = "" Then
                'T2Tb單號.Text = Format(Dt日期.Value.Date, "yyMMdd") & "001"
                'T2Tb單號.Text = "G" & Format(Dt調庫.Value.Date, "yyMMdd") & "001"
                新增單號 = "G" & Format(Dt調庫.Value.Date, "yyMMdd") & "001"
                T2Tb單號.Text = 新增單號
            Else
                Dim nextCode As String = CStr(CInt(Microsoft.VisualBasic.Right(調庫單號, 3)) + 1)
                If Len(nextCode) < 3 Then : For i As Integer = 1 To 3 - Len(nextCode) : nextCode = "0" & nextCode : Next : End If
                'T2Tb單號.Text = Mid(調庫單號, 1, Microsoft.VisualBasic.Len(調庫單號) - 3) & nextCode
                新增單號 = Mid(調庫單號, 1, Microsoft.VisualBasic.Len(調庫單號) - 3) & nextCode
                T2Tb單號.Text = 新增單號
            End If

        Catch ex As Exception
            MsgBox("取得調庫單號: " & ex.Message)
        End Try

    End Sub

    Private Sub 新增調庫單存檔()
        Dim SQLADD As String = ""
        SQLADD = "  INSERT INTO [KaiShingPlug].[dbo].[倉_指定入庫Main] "
        SQLADD += " ([單號],[日期],[調庫日期],[啟用],[新增時間],[輸入者]) VALUES "
        'SQLADD += " ('" & T2Tb單號.Text & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','" & Format(Dt調庫.Value.Date, "yyyy-MM-dd") & "', "
        SQLADD += " ('" & 新增單號 & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','" & Format(Dt調庫.Value.Date, "yyyy-MM-dd") & "', "
        SQLADD += "  'Y',GETDATE(),'" & UCase(GetHostName()) & "') "
        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("新增調庫單存檔: " & ex.Message)
        End Try

    End Sub

    Private Sub 新調庫明細存檔()
        Dim SQLADD As String = ""
        For i = 0 To T1調整儲位.RowCount - 1
            取得新調庫單號()
            新增調庫單存檔()
            SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[倉_指定入庫List] "
            SQLADD += " ([單號],[日期],[存編],[品名],[簡稱],[出庫數量],[儲位],[數量],[啟用],[新增時間]) VALUES "
            'SQLADD += " ('" & T2Tb單號.Text & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "', "
            SQLADD += " ('" & 新增單號 & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "', "
            SQLADD += "  '" & T1調整儲位.Rows(i).Cells("存編").Value & "','" & T1調整儲位.Rows(i).Cells("品名").Value & "', "
            SQLADD += "  '" & T1調整儲位.Rows(i).Cells("簡稱").Value & "','" & T1調整儲位.Rows(i).Cells("出庫數量").Value & "', "
            SQLADD += "  '" & T1調整儲位.Rows(i).Cells("儲位").Value & "','" & T1調整儲位.Rows(i).Cells("數量").Value & "', "
            SQLADD += "  'Y',GETDATE() ) "
        Next

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("新調庫明細存檔: " & ex.Message)
        End Try

    End Sub


    Private Sub T2結束作業()
        If T1現有儲位.RowCount > 0 Then : 顯示資料.Tables("現有儲位").Clear() : End If '清除資料
        If T1空件儲位.RowCount > 0 Then : 顯示資料.Tables("空件儲位").Clear() : End If '清除資料
        If T1儲位明細.RowCount > 0 Then : 顯示資料.Tables("儲位明細").Clear() : End If '清除資料
        If T1急速明細.RowCount > 0 Then : 顯示資料.Tables("急速明細").Clear() : End If '清除資料
        If T1調整儲位.RowCount > 0 Then : DGV調整儲位Dt.Clear() : End If : T1調整儲位.DataSource = DGV調整儲位Dt

        T2Tb單號.Text = ""
        Tb存編.Text = "" : Tb品名.Text = "" : Tb簡稱.Text = "" : Tb數量.Text = 0 : Tb板數.Text = 0 : Tb零散.Text = 0 : Tb儲位.Text = "" : Tb未排.Text = 0 : Tx可放.Text = 0 : Tb來源.Text = "" : Tb可放.Text = 0

        目前作業 = "查詢作業" : Me.TabControl2.SelectedTab = Me.Tp2查詢
    End Sub


































    Private Sub Bu刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu刪除.Click
        If T1已排明細.RowCount > 0 Then
            Dim oAns As Integer
            oAns = MsgBox("確定作廢此指定調庫單?" & Chr(13) & vbCrLf & T1已排明細.CurrentRow.Cells("單號").Value, MsgBoxStyle.OkCancel + 16, "指定調庫單作廢")
            If oAns = MsgBoxResult.Ok Then
                作廢指定調庫單() : T1急速統計載入() : Bu已排.PerformClick()
            End If
        End If
    End Sub

    Private Sub 作廢指定調庫單()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[倉_指定入庫List] SET [啟用] = 'D',[修改時間] = GETDATE() "
            SQLCmd.CommandText += "  FROM [KaiShingPlug].[dbo].[倉_指定入庫List] WHERE [單號] = '" & T1已排明細.CurrentRow.Cells("單號").Value & "' AND [啟用] = 'Y' "

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Bu已排_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu已排.Click
        T1已排明細載入("AE")
        T1已排明細_Sorted()
        If T1已排明細.RowCount = 0 Then : 轉Excel2.Visible = False : Else : 轉Excel2.Visible = True : End If

    End Sub

    Private Sub 轉Excel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉Excel2.Click
        DataToExcel(T1已排明細, "已排明細" & Format(Dt日期.Value.Date, "yyyy-MM-dd"))

    End Sub

    Private Sub T1已排明細_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles T1已排明細.Sorted
        T1已排明細_Sorted()

    End Sub

    Private Sub T1已排明細_Sorted()
        If T1已排明細.RowCount > 0 Then
            'Dim Red As Integer = 0
            For i As Integer = 0 To T1已排明細.RowCount - 1
                If T1已排明細.Rows(i).Cells("處理情況").Value = "待處理" Then
                    T1已排明細.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    'Red += 1
                End If
                If T1已排明細.Rows(i).Cells("處理情況").Value = "刪除" Then
                    T1已排明細.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        End If

    End Sub



    Private Sub BuT3查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuT3查詢.Click
        T1已排明細載入("AEB")
    End Sub

    Private Sub T1已排明細載入(ByVal T As String)

        Select Case T
            Case "AE"
                If T1已排明細.RowCount > 0 Then : 顯示資料.Tables("已排明細").Clear() : End If '清除資料
                Dim SQLQuery As String = ""
                SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AE','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','','' "

                Try
                    Dim DBConn As SqlConnection = Login.DBConn  'Login.  DBConn
                    MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
                    MSSQL作業.Fill(顯示資料, "已排明細")
                    T1已排明細.DataSource = 顯示資料.Tables("已排明細")
                    For i As Integer = 0 To T1已排明細.ColumnCount - 1
                        T1已排明細.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    Next
                    T1已排明細.AutoResizeColumns()

                Catch ex As Exception
                    MsgBox("已排明細：" & ex.Message) : Exit Sub
                End Try

            Case "AEB"
                If T3單據未處理.RowCount > 0 Then : 顯示資料.Tables("單據未處理").Clear() : End If '清除資料
                Dim SQLQuery As String = ""
                SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AEB','','','' "

                Try
                    Dim DBConn As SqlConnection = Login.DBConn  'Login.  DBConn
                    MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
                    MSSQL作業.Fill(顯示資料, "單據未處理")
                    T3單據未處理.DataSource = 顯示資料.Tables("單據未處理")
                    'For i As Integer = 0 To T3單據未處理.ColumnCount - 1
                    '    T3單據未處理.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                    'Next
                    T3單據未處理.AutoResizeColumns()

                Catch ex As Exception
                    MsgBox("單據未處理：" & ex.Message) : Exit Sub
                End Try

            Case Else
        End Select


    End Sub


    Private Sub Bu印全_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu印全.Click
        If T1已排明細.RowCount = 0 Then : MsgBox("無資料可列印") : Exit Sub : End If
        If DGV調整儲位Dt2.Rows.Count > 0 Then : DGV調整儲位Dt2.Clear() : End If
        T1已排明細載入2()
        列印連續 = "N"
        If T1已排明細.RowCount > 0 Then
            If RbA5.Checked = True Then
                DGV調整儲位Dt2 = T1已排明細.DataSource.Copy
                Dim countx As Integer = T1已排明細.Rows.Count
                For x As Integer = countx - 1 To 0 Step -1
                    If T1已排明細.Rows(x).Cells("處理情況").Value <> "待處理" Then
                        DGV調整儲位Dt2.Rows.Remove(DGV調整儲位Dt2.Rows(x))
                    End If
                    'If T1已排明細.CurrentRow.Cells("處理情況").Value <> "待處理" Then : MsgBox("錯誤無列印") : Exit Sub : End If
                Next
                If DGV調整儲位Dt2.Rows.Count > 0 Then : 列印線上撿貨單() : End If
                '列印線上撿貨單()

            Else
                Dim counti As Integer = T1已排統計.Rows.Count
                For i As Integer = 0 To counti - 1

                    If DGV調整儲位Dt2.Rows.Count > 0 Then : DGV調整儲位Dt2.Clear() : End If
                    DGV調整儲位Dt2 = T1已排明細.DataSource.Copy

                    Dim countx As Integer = T1已排明細.Rows.Count
                    For x As Integer = countx - 1 To 0 Step -1
                        If T1已排明細.Rows(x).Cells("單號").Value <> T1已排統計.Rows(i).Cells("單號").Value Or T1已排明細.Rows(x).Cells("處理情況").Value <> "待處理" Then
                            DGV調整儲位Dt2.Rows.Remove(DGV調整儲位Dt2.Rows(x))
                        End If
                    Next
                    If DGV調整儲位Dt2.Rows.Count > 0 Then : 列印線上撿貨單() : 列印連續 = "Y" : End If
                Next

            End If
        End If

            '列印線上撿貨單()
    End Sub

    Private Sub Bu印單_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu印單.Click
        If T1已排明細.RowCount = 0 Then : MsgBox("無資料可列印") : Exit Sub : End If
        If T1已排明細.CurrentRow.Cells("處理情況").Value <> "待處理" Then : MsgBox("錯誤無列印") : Exit Sub : End If
        If DGV調整儲位Dt2.Rows.Count > 0 Then : DGV調整儲位Dt2.Clear() : End If
        列印連續 = "N"
        If T1已排明細.RowCount > 0 Then
            If DGV調整儲位Dt2.Rows.Count > 0 Then : DGV調整儲位Dt2.Clear() : End If
            DGV調整儲位Dt2 = T1已排明細.DataSource.Copy
            Dim countx As Integer = T1已排明細.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If T1已排明細.Rows(x).Cells("單號").Value <> T1已排明細.CurrentRow.Cells("單號").Value Then
                    DGV調整儲位Dt2.Rows.Remove(DGV調整儲位Dt2.Rows(x))
                End If
            Next
            If DGV調整儲位Dt2.Rows.Count > 0 Then : 列印線上撿貨單() : 列印連續 = "N" : End If

        End If

    End Sub


    Private Sub T1已排明細載入2()
        If T1已排統計.Rows.Count > 0 Then : 顯示資料.Tables("已排明細2").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'AEA','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','','' "

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "已排明細2")
            T1已排統計.DataSource = 顯示資料.Tables("已排明細2")
            T1已排統計.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("已排明細2：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub 列印線上撿貨單()
        列印中止 = "N"

        If T1已排明細.RowCount > 0 Then

            Dim newRpt As 列印Print = New 列印Print
            'newRpt.StartupPath = "\報表\急速調庫-中.rdlc"   'xxx
            'newRpt.StartupPath = "\報表\急速調庫.rdlc"      'xxx
            If RbNA4.Checked = True Then
                newRpt.StartupPath = "\A_倉儲\報表\急速調庫-中.rdlc"
                newRpt.高 = "14cm"
                newRpt.TYPE = "3"
            End If

            If RbA4.Checked = True Then
                newRpt.StartupPath = "\A_倉儲\報表\急速調庫.rdlc"
                newRpt.高 = "29.70cm"  'A4 21cm 29.7cm
                newRpt.TYPE = "4"
            End If

            If RbA5.Checked = True Then
                newRpt.StartupPath = "\A_倉儲\報表\急速調庫A5.rdlc"
                newRpt.高 = "29.70cm"  'A4 21cm 29.7cm
                newRpt.TYPE = "4"
                'newRpt.高 = "21.00cm"  'A5 
                'newRpt.TYPE = "5"
            End If


            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            'newRpt.dt = 顯示資料.Tables("派工列印")
            'newRpt.dt = T1已排明細.DataSource   'DGV

            newRpt.dt = DGV調整儲位Dt2


            If 列印連續 = "N" Then
                If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    newRpt.printerName = PrintDialog.PrinterSettings.PrinterName
                    列印連續 = "Y"
                    列印機台 = newRpt.printerName
                Else
                    列印中止 = "Y" : Exit Sub
                End If
            Else
                newRpt.printerName = 列印機台
            End If
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無明細!", MsgBoxStyle.OkOnly, "出急速調庫單")
        End If

    End Sub

    Private Sub Bu放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu放棄.Click
        T2結束作業()
    End Sub

    Private Sub Cb自定_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb自定.CheckedChanged
        If Cb自定.Checked = True Then
            'Panel2.Location = New Point(3, 363) '984, 66
            Tb儲位.ReadOnly = False : Bu自定.Visible = True
            Tb來源.Text = "自定" : Tb儲位.Text = "" : Tb可放.Text = 0 : Tx可放.Text = 0
        Else
            Tb儲位.ReadOnly = True : Bu自定.Visible = False
            Tb來源.Text = "" : Tb儲位.Text = "" : Tb可放.Text = 0 : Tx可放.Text = 0
            T1現有儲位.DataSource = Nothing : T1現有儲位.DataSource = 顯示資料.Tables("現有儲位")
        End If

    End Sub

    Private Sub Bu自定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu自定.Click
        If Tb儲位.Text <> "" Then
            T1自定儲位載入()
            Me.TabControl1.SelectedTab = Me.Tp現有
            If T1現有儲位.RowCount > 0 Then
                Tx可放.Text = T1現有儲位.CurrentRow.Cells("可放數量").Value
            Else
                Tx可放.Text = 0
            End If

        End If
    End Sub

    Private Sub T1自定儲位載入()
        T1現有儲位.DataSource = Nothing
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'ADA','','" & Tb儲位.Text & "','' "

        TimeA = Now()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "自定儲位")
            T1現有儲位.DataSource = 顯示資料.Tables("自定儲位").Copy
            T1現有儲位.AutoResizeColumns()
            顯示資料.Tables("自定儲位").Clear()
            T2Time3.Text = Format((Now() - TimeA).TotalSeconds, "0.##")

        Catch ex As Exception
            MsgBox("自定儲位：" & ex.Message) : Exit Sub
        End Try
    End Sub


    Private Sub Bu品名_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu品名.Click

        Select Case Bu品名.Text
            Case "查詢品名"
                Cb自定.Checked = False : Cb自定.Visible = False
                Tb來源.Text = "" : Tb儲位.Text = "" : Tb可放.Text = 0 : Tx可放.Text = 0
                T1品名儲位載入()
                Bu品名.Text = "查詢放棄"
            Case "查詢放棄"
                Cb自定.Checked = False : Cb自定.Visible = True
                Tb來源.Text = "" : Tb儲位.Text = "" : Tb可放.Text = 0 : Tx可放.Text = 0
                T1現有儲位.DataSource = Nothing : T1現有儲位.DataSource = 顯示資料.Tables("現有儲位")
                Bu品名.Text = "查詢品名"
        End Select






    End Sub

    Private Sub T1品名儲位載入()
        T1現有儲位.DataSource = Nothing
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_出急速調庫01v] 'ADB','','','" & Tb品名.Text & "' "

        TimeA = Now()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "品名儲位")
            T1現有儲位.DataSource = 顯示資料.Tables("品名儲位").Copy
            T1現有儲位.AutoResizeColumns()
            顯示資料.Tables("品名儲位").Clear()
            T2Time3.Text = Format((Now() - TimeA).TotalSeconds, "0.##")

        Catch ex As Exception
            MsgBox("品名儲位：" & ex.Message) : Exit Sub
        End Try
    End Sub







End Class