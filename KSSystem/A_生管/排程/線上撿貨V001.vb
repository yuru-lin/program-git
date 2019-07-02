Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks.Printing
Imports Microsoft.Reporting.WinForms

Public Class 線上撿貨V001
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim DGV線上撿貨Dt As New DataTable
    Dim DGV線上列印Dt As New DataTable
    Dim 目前作業 As String = ""
    Dim 選擇作業 As String = "Y"
    Dim 派單選擇 As String = "Y"
    Dim 列印中止 As String = "N"
    Dim PrinterName As String '列印機選擇
    Dim 撿貨單號 As String = ""
    Dim 下單時間 As DateTime

    Private Sub 線上撿貨_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 680)
        'T1Pa編輯.Location = New Point(0, 37)
        目前作業 = "派單作業" : Lt作業.Text = "派單作業" : Me.TabControl1.SelectedTab = Me.TP派單作業
        AddDGV線上撿貨Dt() : AddDGV線上列印Dt()
        T1已排項目.DataSource = DGV線上撿貨Dt
        T2Cb樓層.SelectedIndex = 0 : T2Tb單號.Text = "" : T2Tb日期.Text = "" : T2Tb樓層.Text = "" : T2Tb時間.Text = ""

        'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        'checkBoxColumn.Name = "選擇"
        'checkBoxColumn.Width = 30
        'T2複製明細.Columns.Insert(0, checkBoxColumn)

    End Sub

    Private Sub AddDGV線上撿貨Dt()
        Dim 選擇 As DataColumn = New DataColumn("選擇") : 選擇.DataType = System.Type.GetType("System.Boolean") : DGV線上撿貨Dt.Columns.Add(選擇)
        Dim 草稿 As DataColumn = New DataColumn("草稿") : 草稿.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(草稿)
        Dim 客編 As DataColumn = New DataColumn("客編") : 客編.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(客編)
        Dim 簡稱 As DataColumn = New DataColumn("簡稱") : 簡稱.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(簡稱)
        Dim 存編 As DataColumn = New DataColumn("存編") : 存編.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(存編)
        Dim 品名 As DataColumn = New DataColumn("品名") : 品名.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(品名)
        Dim 生產品項 As DataColumn = New DataColumn("生產品項") : 生產品項.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(生產品項)
        Dim 數量 As DataColumn = New DataColumn("數量") : 數量.DataType = System.Type.GetType("System.Int16") : DGV線上撿貨Dt.Columns.Add(數量)
        Dim 單位 As DataColumn = New DataColumn("單位") : 單位.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(單位)
        Dim 生管備註 As DataColumn = New DataColumn("生管備註") : 生管備註.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(生管備註)
        Dim 訂單備註 As DataColumn = New DataColumn("訂單備註") : 訂單備註.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(訂單備註)
        Dim 作業 As DataColumn = New DataColumn("作業") : 作業.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(作業)
        Dim 單號 As DataColumn = New DataColumn("單號") : 單號.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(單號)
        Dim 客戶 As DataColumn = New DataColumn("客戶") : 客戶.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(客戶)
        Dim 簡稱S As DataColumn = New DataColumn("簡稱S") : 簡稱S.DataType = System.Type.GetType("System.String") : DGV線上撿貨Dt.Columns.Add(簡稱S)

    End Sub

    Private Sub AddDGV線上列印Dt()
        Dim 單號 As DataColumn = New DataColumn("單號") : 單號.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(單號)
        Dim 生產日期 As DataColumn = New DataColumn("生產日期") : 生產日期.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(生產日期)
        Dim 樓層 As DataColumn = New DataColumn("樓層") : 樓層.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(樓層)
        Dim 時間 As DataColumn = New DataColumn("時間") : 時間.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(時間)
        Dim 簡稱 As DataColumn = New DataColumn("簡稱") : 簡稱.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(簡稱)
        Dim 品名 As DataColumn = New DataColumn("品名") : 品名.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(品名)
        Dim 生產品項 As DataColumn = New DataColumn("生產品項") : 生產品項.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(生產品項)
        Dim 數量 As DataColumn = New DataColumn("數量") : 數量.DataType = System.Type.GetType("System.Int16") : DGV線上列印Dt.Columns.Add(數量)
        Dim 單位 As DataColumn = New DataColumn("單位") : 單位.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(單位)
        Dim 生管備註 As DataColumn = New DataColumn("生管備註") : 生管備註.DataType = System.Type.GetType("System.String") : DGV線上列印Dt.Columns.Add(生管備註)

    End Sub

    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl1.Selected
        Select Case 目前作業
            Case "派單作業" : Me.TabControl1.SelectedTab = Me.TP派單作業
            Case "派單查詢" : Me.TabControl1.SelectedTab = Me.TP派單查詢
            Case Else
        End Select

    End Sub

    Private Sub RB作業切換(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB作業.CheckedChanged, RB查詢.CheckedChanged
        If RB作業.Checked = True Then : 目前作業 = "派單作業" : Lt作業.Text = "派單作業" : Me.TabControl1.SelectedTab = Me.TP派單作業 : End If
        If RB查詢.Checked = True Then : 目前作業 = "派單查詢" : Lt作業.Text = "派單查詢" : Me.TabControl1.SelectedTab = Me.TP派單查詢 : End If

    End Sub

    Private Sub T1Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu查詢.Click

        Select Case T1Bu查詢.Text
            Case "查詢"
                T1未排項目載入() : T1未排項目載入False() : T1未排項目明細顯示()
                T1Dt日期.Enabled = False
                T1Bu查詢.Text = "重查"
            Case "重查"
                If T1未排項目.RowCount > 0 Then : 顯示資料.Tables("未排項目").Clear() : End If '清除資料
                If T1已排項目.RowCount > 0 Then : DGV線上撿貨Dt.Clear() : End If
                T1未排項目.DataSource = Nothing
                T1已排項目.DataSource = DGV線上撿貨Dt
                'T1未排項目.DataSource = Nothing:T1已排項目.DataSource = Nothing
                T1Dt日期.Enabled = True
                T1Bu查詢.Text = "查詢"
        End Select


    End Sub

    Private Sub T1未排項目載入()
        If T1未排項目.RowCount > 0 Then : 顯示資料.Tables("未排項目").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_線上撿貨01v] 'AA','" & Format(T1Dt日期.Value.Date, "yyyy-MM-dd") & "','' "

        Try
            Dim DBConn As SqlConnection = Login.DBConn : MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "未排項目")
            T1未排項目.DataSource = 顯示資料.Tables("未排項目").Copy
            If 選擇作業 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                checkBoxColumn.Width = 30
                T1未排項目.Columns.Insert(0, checkBoxColumn)
            End If
            選擇作業 = "N"

        Catch ex As Exception
            MsgBox("未排項目：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T1未排項目載入False()
        Dim count As Integer = T1未排項目.Rows.Count
        For i As Integer = 0 To count - 1
            T1未排項目.Rows(i).Cells("選擇").Value = False
        Next
        If T1未排項目.Rows.Count > 0 Then : T1未排項目.CurrentCell = T1未排項目.Rows(0).Cells(6) : End If

    End Sub

    Private Sub T1未排項目明細顯示()
        For Each column As DataGridViewColumn In T1未排項目.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True : column.ReadOnly = False : column.Visible = True
                Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 1 : column.Frozen = True : column.Visible = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2 : column.Frozen = True : column.Visible = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3 : column.Visible = True
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 4 : column.Visible = True
                Case "生管備註" : column.HeaderText = "生管備註" : column.DisplayIndex = 5 : column.Visible = True
                Case "訂單備註" : column.HeaderText = "訂單備註" : column.DisplayIndex = 6 : column.Visible = True

                Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 7 : column.Visible = True
                Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 8 : column.Visible = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 9 : column.Visible = True

                Case "作業" : column.HeaderText = "作業" : column.DisplayIndex = 10 : column.Visible = False
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 11 : column.Visible = False
                Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 12 : column.Visible = True
                Case "簡稱S" : column.HeaderText = "簡稱S" : column.DisplayIndex = 13 : column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        T1未排項目.AutoResizeColumns()

    End Sub

    Private Sub DGV線上撿貨Dt暫存()
        If T1未排項目.RowCount > 0 Then   '加到DGV線上撿貨Dt
            For Each oRow As DataGridViewRow In T1未排項目.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
                If isSelected = True Then
                    Dim Row As DataRow
                    Row = DGV線上撿貨Dt.NewRow
                    Row.Item("草稿") = oRow.Cells("草稿").Value
                    Row.Item("客編") = oRow.Cells("客編").Value
                    Row.Item("簡稱") = oRow.Cells("簡稱").Value
                    Row.Item("存編") = oRow.Cells("存編").Value
                    Row.Item("品名") = oRow.Cells("品名").Value
                    Row.Item("生產品項") = ""
                    Row.Item("數量") = oRow.Cells("數量").Value
                    Row.Item("單位") = oRow.Cells("單位").Value
                    Row.Item("生管備註") = ""
                    Row.Item("訂單備註") = oRow.Cells("訂單備註").Value
                    Row.Item("作業") = oRow.Cells("作業").Value
                    Row.Item("單號") = oRow.Cells("單號").Value
                    Row.Item("客戶") = oRow.Cells("客戶").Value
                    Row.Item("簡稱S") = oRow.Cells("簡稱S").Value
                    DGV線上撿貨Dt.Rows.Add(Row)
                End If
            Next
        End If
        T1已排項目.DataSource = DGV線上撿貨Dt
        'T1已排項目.AutoResizeColumns()
        T1已排項目明細顯示()
        T1已排項目載入False()

    End Sub

    Private Sub T1已排項目明細顯示()
        For Each column As DataGridViewColumn In T1已排項目.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True : column.ReadOnly = False : column.Visible = True
                Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 1 : column.Frozen = True : column.Visible = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2 : column.Frozen = True : column.Visible = True
                Case "生產品項" : column.HeaderText = "生產品項" : column.DisplayIndex = 3 : column.Visible = True : column.ReadOnly = False
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 4 : column.Visible = True : column.ReadOnly = False
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5 : column.Visible = True
                Case "生管備註" : column.HeaderText = "生管備註" : column.DisplayIndex = 6 : column.Visible = True : column.ReadOnly = False
                Case "訂單備註" : column.HeaderText = "訂單備註" : column.DisplayIndex = 7 : column.Visible = True

                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 8 : column.Visible = True

                Case "作業" : column.HeaderText = "作業" : column.DisplayIndex = 9 : column.Visible = False
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 10 : column.Visible = False
                Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 11 : column.Visible = False
                Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 12 : column.Visible = False
                Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 13 : column.Visible = False
                Case "簡稱S" : column.HeaderText = "簡稱S" : column.DisplayIndex = 14 : column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        T1已排項目.AutoResizeColumns()
    End Sub

    Private Sub T1已排項目載入False()
        Dim count As Integer = T1已排項目.Rows.Count
        For i As Integer = 0 To count - 1
            T1已排項目.Rows(i).Cells("選擇").Value = False
        Next
        If T1已排項目.Rows.Count > 0 Then : T1已排項目.CurrentCell = T1已排項目.Rows(0).Cells(4) : End If
    End Sub

    Private Sub T1Bu撿貨_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu撿貨.Click
        Dim SN As Int16 = 0
        If T1未排項目.RowCount > 0 Then   '加到DGV線上撿貨Dt
            For Each oRow As DataGridViewRow In T1未排項目.Rows
                Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
                If isSelected = True Then
                    SN += +1
                End If
            Next
        End If
        If SN > 0 Then : DGV線上撿貨Dt暫存() : 撿貨項目比對() : Else : MsgBox("未選擇品項無法新增") : End If

    End Sub

    Private Sub 撿貨項目比對()
        If T1已排項目.RowCount > 0 Then
            Dim counti As Integer = T1已排項目.Rows.Count
            For i As Integer = counti - 1 To 0 Step -1
                Dim countx As Integer = T1未排項目.Rows.Count
                For x As Integer = countx - 1 To 0 Step -1
                    If T1已排項目.Rows(i).Cells("草稿").Value = T1未排項目.Rows(x).Cells("草稿").Value And _
                       T1已排項目.Rows(i).Cells("存編").Value = T1未排項目.Rows(x).Cells("存編").Value Then
                        T1未排項目.Rows.Remove(T1未排項目.Rows(x))
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub T1Bu移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu移除.Click

        If T1已排項目.RowCount > 0 Then   '加到DGV線上撿貨Dt
            Dim countx As Integer = T1已排項目.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                Dim isSelected As Boolean = T1已排項目.Rows(x).Cells("選擇").Value
                If isSelected = True Then
                    T1已排項目.Rows.Remove(T1已排項目.Rows(x))
                End If
            Next
        End If
        T1未排項目.DataSource = 顯示資料.Tables("未排項目").Copy : 撿貨項目比對()

    End Sub

    Private Sub T1Bu編輯_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu編輯.Click
        Select Case T1Bu編輯.Text
            Case "編輯"
                T1Bu查詢.Visible = False : T1Bu撿貨.Visible = False : T1Bu移除.Visible = False : T1未排項目.Visible = False
                T1Bu存檔.Visible = True
                'T1已排項目.Location = New Point(3, 37) : T1已排項目.Size = New Size(1160, 542)
                T1已排項目.Location = New Point(323, 37) : T1已排項目.Size = New Size(840, 542)
                Panel2.Visible = True : Panel2.Location = New Point(217, 3)
                T1Pa編輯.Visible = True : T1Pa編輯.Location = New Point(0, 0)
                T1Bu編輯.Text = "放棄"
            Case "放棄"
                T1Bu查詢.Visible = True : T1Bu撿貨.Visible = True : T1Bu移除.Visible = True : T1未排項目.Visible = True
                T1Bu存檔.Visible = False
                T1已排項目.Location = New Point(100, 315) : T1已排項目.Size = New Size(1063, 264)
                Panel2.Visible = False : Panel2.Location = New Point(217, 48)
                T1Pa編輯.Visible = False : T1Pa編輯.Location = New Point(0, 37)
                T1Bu編輯.Text = "編輯"
        End Select

    End Sub

    Private Sub T1Bu存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu存檔.Click
        If T1Cb樓層.SelectedIndex = -1 Or T1已排項目.RowCount = 0 Then : MsgBox("樓層未選擇或無項目可列印") : Exit Sub
        Else
            撿貨單號 = ""
            取得新撿貨單號()
            下單時間 = Now() : T1La時間.Text = Format(下單時間, "hh:mm")    '暫放測試
            列印線上撿貨單()
            '列印後作業
            If 列印中止 = "N" Then

                新撿貨單號存檔()
                新撿貨明細存檔()

                If T1已排項目.RowCount > 0 Then : DGV線上撿貨Dt.Clear() : End If : T1已排項目.DataSource = DGV線上撿貨Dt
                'T1未排項目.DataSource = Nothing
                'T1La單號.Text = "" : T1La時間.Text = "" : T1Cb樓層.SelectedIndex = -1
                T1Bu編輯.PerformClick() ': T1Bu查詢.PerformClick()
                'If T1未排項目.RowCount > 0 Then : 顯示資料.Tables("未排項目").Clear() : End If '清除資料
                T1未排項目載入() : T1未排項目載入False() : T1未排項目明細顯示()
            End If
            T1La單號.Text = "" : T1La時間.Text = "" : T1Cb樓層.SelectedIndex = -1
        End If

    End Sub

    Private Sub 取得新撿貨單號()
        Dim SQLADD As String = "" : 撿貨單號 = ""
        'SQLADD = " SELECT TOP 1 ISNULL(MAX([單號]),'" & T1Cb樓層.SelectedIndex + 1 & "F" & Format(T1Dt生產.Value.Date, "yyyyMMdd") & "001" & "') AS '單號' FROM [KaiShingPlug].[dbo].[生_線上撿貨Main] WHERE [日期] = '" & Format(T1Dt生產.Value.Date, "yyyy-MM-dd") & "' "
        SQLADD = " SELECT TOP 1 ISNULL(MAX([單號]),'') AS '單號' FROM [KaiShingPlug].[dbo].[生_線上撿貨Main] WHERE [生產日期] = '" & Format(T1Dt生產.Value.Date, "yyyy-MM-dd") & "' AND [樓層代碼] = '" & T1Cb樓層.SelectedIndex + 1 & "' "
        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim sqlCmd As SqlCommand : Dim sqlReader As SqlDataReader
            sqlCmd = New SqlCommand(SQLADD, DBConn) : sqlReader = sqlCmd.ExecuteReader : sqlReader.Read()
            If sqlReader.HasRows() Then : 撿貨單號 = sqlReader.Item("單號") : End If
            'MsgBox(sqlReader.Item("單號"))
            'MsgBox(撿貨單號)

            sqlReader.Close()
            If 撿貨單號 = "" Then
                T1La單號.Text = T1Cb樓層.SelectedIndex + 1 & "F" & Format(T1Dt生產.Value.Date, "yyyyMMdd") & "001"
            Else
                Dim nextCode As String = CStr(CInt(Microsoft.VisualBasic.Right(撿貨單號, 3)) + 1)
                'MsgBox(nextCode)
                If Len(nextCode) < 3 Then
                    For i As Integer = 1 To 3 - Len(nextCode)
                        nextCode = "0" & nextCode
                    Next
                End If
                'MsgBox(nextCode)
                T1La單號.Text = Mid(撿貨單號, 1, Microsoft.VisualBasic.Len(撿貨單號) - 3) & nextCode
                'MsgBox(Mid(撿貨單號, 1, Microsoft.VisualBasic.Len(撿貨單號) - 3) & nextCode)
                'T1La單號.Text = 撿貨單號
            End If

        Catch ex As Exception
            MsgBox("取得撿貨單號: " & ex.Message)
        End Try

    End Sub

    Private Sub 新撿貨單號存檔()
        Dim SQLADD As String = ""
        下單時間 = Now() : T1La時間.Text = Format(下單時間, "hh:mm")
        'T1La時間.Text = Format(下單時間, "yyyy-MM-dd hh:mm:ss.fff") & " " & Format(T1Dt日期.Value.Date, "MM月dd日")
        SQLADD = "  INSERT INTO [KaiShingPlug].[dbo].[生_線上撿貨Main] "
        SQLADD += " ([單號],[日期],[生產日期],[樓層],[樓層代碼],[下單時間],[啟用],[新增時間],[輸入者]) VALUES "
        SQLADD += " ('" & T1La單號.Text & "','" & Format(T1Dt日期.Value.Date, "yyyy-MM-dd") & "','" & Format(T1Dt生產.Value.Date, "yyyy-MM-dd") & "',"
        SQLADD += "  '" & T1Cb樓層.Text & "','" & T1Cb樓層.SelectedIndex + 1 & "',  "
        SQLADD += "  '" & Format(下單時間, "yyyy-MM-dd hh:mm:ss.fff") & "','Y',GETDATE(),'" & UCase(GetHostName()) & "') "

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("新撿貨單號存檔: " & ex.Message)
        End Try

    End Sub

    Private Sub 新撿貨明細存檔()
        Dim SQLADD As String = ""
        For i = 0 To T1已排項目.RowCount - 1
            SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[生_線上撿貨List] "
            SQLADD += " ([單號],[來源作業],[來源單號],[客編],[簡稱],[存編],[品名],[生產品項],[數量],[單位],[備註],[啟用],[新增時間]) VALUES "
            SQLADD += " ('" & T1La單號.Text & "', "
            SQLADD += "  '" & T1已排項目.Rows(i).Cells("作業").Value & "','" & T1已排項目.Rows(i).Cells("草稿").Value & "', "
            SQLADD += "  '" & T1已排項目.Rows(i).Cells("客編").Value & "','" & T1已排項目.Rows(i).Cells("簡稱").Value & "', "
            SQLADD += "  '" & T1已排項目.Rows(i).Cells("存編").Value & "','" & T1已排項目.Rows(i).Cells("品名").Value & "', "
            SQLADD += "  '" & T1已排項目.Rows(i).Cells("生產品項").Value & "','" & T1已排項目.Rows(i).Cells("數量").Value & "', "
            SQLADD += "  '" & T1已排項目.Rows(i).Cells("單位").Value & "','" & T1已排項目.Rows(i).Cells("生管備註").Value & "', "
            SQLADD += "  'Y',GETDATE() ) "
        Next

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("新撿貨明細存檔: " & ex.Message)
        End Try

    End Sub

    Private Sub 列印線上撿貨單()
        列印中止 = "N"
        'Dim printDoc As New PrintDocument()
        'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        'If 顯示資料.Tables("派工列印").Rows.Count > 0 Then
        If T1已排項目.RowCount > 0 Then

            Dim newRpt As 列印Print = New 列印Print
            newRpt.strPara(0) = T1La單號.Text
            newRpt.strPara(1) = T1Cb樓層.Text
            newRpt.strPara(2) = Format(T1Dt生產.Value.Date, "MM月dd日")
            newRpt.strPara(3) = T1La時間.Text

            newRpt.StartupPath = "\A_生管\報表\線上撿貨列印.rdlc"
            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            newRpt.高 = "14cm"
            'newRpt.高 = "29.7cm"
            newRpt.TYPE = "3"
            'newRpt.紙張 = "Letter"
            '中一刀2()    22.86cm,13.97cm

            'newRpt.dt = 顯示資料.Tables("派工列印")
            newRpt.dt = T1已排項目.DataSource
            'newRpt.dt = T1派工列印.DataSource
            'newRpt.printerName = printDoc.PrinterSettings.PrinterName
            If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                newRpt.printerName = PrintDialog.PrinterSettings.PrinterName
            Else
                列印中止 = "Y"
                Exit Sub
            End If
            'newRpt.printerName = Cb1印表機.Text
            'newRpt.printerName = PrinterName
            'newRpt.printerName = "Microsoft XPS Document Writer"
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無明細!", MsgBoxStyle.OkOnly, "派工列印")
        End If

    End Sub

    Private Sub T1Bu查詢品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu查詢品項.Click
        If T1Tb查1.Text = "" Then : MsgBox("無輸入資料") : Exit Sub : Else : 品項明細查詢() : End If

    End Sub

    Private Sub 品項明細查詢()
        If T1項目明細.RowCount > 0 Then : 顯示資料.Tables("項目明細").Clear() : End If
        Dim WHERE01 As String = "" : Dim WHERE02 As String = "" : Dim WHERE11 As String = "" : Dim WHERE12 As String = "" : Dim WHERE13 As String = ""

        Dim WHERE11A As String = "ALL" : Dim WHERE12A As String = "ALL" : Dim WHERE13A As String = "ALL"
        If T1Tb查1.Text <> "" Then : WHERE11A = T1Tb查1.Text : End If
        If T1Tb查2.Text <> "" Then : WHERE12A = T1Tb查2.Text : End If
        If T1Tb查3.Text <> "" Then : WHERE13A = T1Tb查3.Text : End If

        If T1Cx包含.Checked = True Then
            WHERE11 += " AND (T0.[ItemName] Like '%" & WHERE11A & "%'  "
            WHERE12 += " OR   T0.[ItemName] Like '%" & WHERE12A & "%'  "
            WHERE13 += " OR   T0.[ItemName] Like '%" & WHERE13A & "%') "
        Else

            If T1Tb查1.Text <> "" Then : WHERE11 += " AND T0.[ItemName] Like '%" & Replace(Replace(T1Tb查1.Text, "*", "%"), " ", "") & "%' " : End If
            If T1Tb查2.Text <> "" Then : WHERE12 += " AND T0.[ItemName] Like '%" & Replace(Replace(T1Tb查2.Text, "*", "%"), " ", "") & "%' " : End If
            If T1Tb查3.Text <> "" Then : WHERE13 += " AND T0.[ItemName] Like '%" & Replace(Replace(T1Tb查3.Text, "*", "%"), " ", "") & "%' " : End If
        End If

        Dim SQLQuery As String = ""
        SQLQuery = "       SELECT T0.[ItemName] AS '品名', T0.[ItemCode] AS  '存編' "
        SQLQuery += "        FROM [OITM] T0 "
        SQLQuery += "       WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2','5','6','7','8') AND T0.[ItemCode] NOT LIKE '%-%' "
        SQLQuery += WHERE01 & WHERE02 & WHERE11 & WHERE12 & WHERE13
        SQLQuery += "    ORDER BY 1 "
        'MsgBox(SQLQuery)
        Try
            Dim DBConn As SqlConnection = Login.DBConn : MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "項目明細")
            T1項目明細.DataSource = 顯示資料.Tables("項目明細")
            T1項目明細.AutoResizeColumns()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T1項目明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1項目明細.CellClick
        If T1項目明細.RowCount <= 0 Then : Exit Sub
        Else
            T1Tb存編.Text = T1項目明細.CurrentRow.Cells("存編").Value
            T1Tb品名.Text = T1項目明細.CurrentRow.Cells("品名").Value
        End If
    End Sub

    Private Sub T1Bu新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Bu新增.Click
        If T1Cb客戶.Text = "" Or T1Tb存編.Text = "" Or T1Tb數量.Text = "" Then : Exit Sub
        Else : DGV線上撿貨Dt項目新增() : End If
    End Sub

    Private Sub DGV線上撿貨Dt項目新增()
        Dim Row As DataRow
        Row = DGV線上撿貨Dt.NewRow
        Row.Item("草稿") = ""
        Row.Item("客編") = ""
        Row.Item("簡稱") = T1Cb客戶.Text
        Row.Item("存編") = T1Tb存編.Text
        Row.Item("品名") = T1Tb品名.Text
        Row.Item("生產品項") = T1Tb項目.Text
        Row.Item("數量") = CInt(T1Tb數量.Text)
        Row.Item("單位") = "件"
        Row.Item("生管備註") = T1Tb備註.Text
        Row.Item("訂單備註") = ""
        Row.Item("作業") = "自建"
        Row.Item("單號") = ""
        Row.Item("客戶") = ""
        Row.Item("簡稱S") = ""
        DGV線上撿貨Dt.Rows.Add(Row)
      
        T1已排項目.DataSource = DGV線上撿貨Dt
        T1已排項目明細顯示()
        T1已排項目載入False()

    End Sub

    Private Sub T2Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Bu查詢.Click
        Select Case T2Bu查詢.Text
            Case "查詢"
                T2線上明細載入()
            Case "排入撿貨"

        End Select
    End Sub

    Private Sub T2線上明細載入()
        If T2線上明細.RowCount > 0 Then : 顯示資料.Tables("線上明細").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_線上撿貨01v] 'AB','" & Format(T2Dt生產.Value.Date, "yyyy-MM-dd") & "','" & T2Cb樓層.SelectedIndex & "' "

        Try
            Dim DBConn As SqlConnection = Login.DBConn : MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "線上明細")
            T2線上明細.DataSource = 顯示資料.Tables("線上明細").Copy
            If 派單選擇 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                checkBoxColumn.Width = 30
                T2線上明細.Columns.Insert(0, checkBoxColumn)
            End If
            派單選擇 = "N"
            T2線上明細顯示()
            T2線上明細.AutoResizeColumns()
            T2線上明細載入False()
        Catch ex As Exception
            MsgBox("線上明細：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T2線上明細顯示()
        For Each column As DataGridViewColumn In T2線上明細.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True : column.ReadOnly = False
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 : column.Frozen = True
                Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 2 : column.Frozen = True
                Case "樓層" : column.HeaderText = "樓層" : column.DisplayIndex = 3 : column.Frozen = True
                Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 4 : column.Frozen = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5 : column.Frozen = True
                Case "生產品項" : column.HeaderText = "生產品項" : column.DisplayIndex = 6
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 7
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 8
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 9
                Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 10
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 11
                Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 12
                Case "下單時間" : column.HeaderText = "下單時間" : column.DisplayIndex = 13
                Case "新單號" : column.HeaderText = "新單號" : column.DisplayIndex = 14 ': column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        T2線上明細.AutoResizeColumns()
    End Sub

    Private Sub T2線上明細載入False()
        Dim count As Integer = T2線上明細.Rows.Count
        For i As Integer = 0 To count - 1
            T2線上明細.Rows(i).Cells("選擇").Value = False
        Next
        If T2線上明細.Rows.Count > 0 Then : T2線上明細.CurrentCell = T2線上明細.Rows(0).Cells(1) : End If

    End Sub


    Private Sub T2Bu複製_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Bu複製.Click
        If T2線上明細.RowCount = 0 Then : Exit Sub : End If
        Select Case T2Bu複製.Text
            Case "複製"
                Dim SN As Int16 = 0
                If T2線上明細.RowCount > 0 Then
                    For Each oRow As DataGridViewRow In T2線上明細.Rows
                        Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
                        If isSelected = True Then
                            SN += +1
                        End If
                    Next
                End If

                If SN > 0 Then
                    T2複製明細載入()
                    T2複製明細顯示()
                End If
                T2Dt生產.MinDate = DateTime.Today.AddDays(0)
                T2Dt生產.Value = Today()
            Case "存檔"
                取得單號()
                If T2複製明細.RowCount > 0 Then : T2複製明細.DataSource.Clear() : End If '清除資料
                T2線上明細載入False()
                T2線上明細.Visible = True : T2複製明細.Visible = False
                T2Tb單號.Visible = True : T2Bu列印.Visible = True : T2Bu查詢.Visible = True
                T2Bu複製.Text = "複製" : T2Bu刪除.Text = "刪除" ' : T2Bu查詢.Text = "查詢"
                T2Cb樓層.Enabled = True
                T2Bu查詢.PerformClick()
                T2Dt生產.MinDate = "1900/1/1"
                T2Tb單號.Text = ""
        End Select


    End Sub

    Private Sub 取得單號()
        Dim 樓層取得 As String = "" : Dim 代碼 As String = ""
        If T2複製明細.RowCount > 0 Then
            For Each oRow As DataGridViewRow In T2複製明細.Rows
                If 樓層取得 <> oRow.Cells("樓層").Value.ToString Then
                    'MsgBox("執行" & oRow.Cells("樓層").Value.ToString & "      " & oRow.Cells("品名").Value.ToString)
                    Select Case oRow.Cells("樓層").Value.ToString
                        Case "一樓" : 代碼 = "1" : Case "二樓" : 代碼 = "2" : Case "三樓" : 代碼 = "3" : Case Else : 代碼 = ""
                    End Select
                    複製取得新撿貨單號(代碼, oRow.Cells("樓層").Value.ToString)
                End If
                樓層取得 = oRow.Cells("樓層").Value.ToString
            Next
        End If

    End Sub

    Private Sub 複製取得新撿貨單號(ByVal 樓層代碼 As String, ByVal 樓層名稱 As String)
        Dim SQLADD As String = "" : 撿貨單號 = "" : Dim 新單號 As String = ""
        SQLADD = " SELECT TOP 1 ISNULL(MAX([單號]),'') AS '單號' FROM [KaiShingPlug].[dbo].[生_線上撿貨Main] WHERE [生產日期] = '" & Format(T2Dt生產.Value.Date, "yyyy-MM-dd") & "' AND [樓層代碼] = '" & 樓層代碼 & "' "
        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim sqlCmd As SqlCommand : Dim sqlReader As SqlDataReader
            sqlCmd = New SqlCommand(SQLADD, DBConn) : sqlReader = sqlCmd.ExecuteReader : sqlReader.Read()
            If sqlReader.HasRows() Then : 撿貨單號 = sqlReader.Item("單號") : End If

            sqlReader.Close()
            If 撿貨單號 = "" Then
                新單號 = 樓層代碼 & "F" & Format(T2Dt生產.Value.Date, "yyyyMMdd") & "001"
            Else
                Dim nextCode As String = CStr(CInt(Microsoft.VisualBasic.Right(撿貨單號, 3)) + 1)
                If Len(nextCode) < 3 Then
                    For i As Integer = 1 To 3 - Len(nextCode)
                        nextCode = "0" & nextCode
                    Next
                End If
                'T2La單號.Text = Mid(撿貨單號, 1, Microsoft.VisualBasic.Len(撿貨單號) - 3) & nextCode
                新單號 = Mid(撿貨單號, 1, Microsoft.VisualBasic.Len(撿貨單號) - 3) & nextCode
            End If
            'MsgBox(新單號 & "  " & 樓層代碼 & "  " & 樓層名稱)
            複製撿貨單存檔(新單號, 樓層代碼, 樓層名稱)
        Catch ex As Exception
            MsgBox("取得撿貨單號2: " & ex.Message)
        End Try

    End Sub

    Private Sub 複製撿貨單存檔(ByVal 單號 As String, ByVal 樓層代碼 As String, ByVal 樓層名稱 As String)
        Dim SQLADD As String = ""
        下單時間 = Now() : T1La時間.Text = Format(下單時間, "hh:mm")
        'T1La時間.Text = Format(下單時間, "yyyy-MM-dd hh:mm:ss.fff") & " " & Format(T1Dt日期.Value.Date, "MM月dd日")
        SQLADD = "  INSERT INTO [KaiShingPlug].[dbo].[生_線上撿貨Main] "
        SQLADD += " ([單號],[日期],[生產日期],[樓層],[樓層代碼],[下單時間],[啟用],[新增時間],[輸入者]) VALUES "
        SQLADD += " ('" & 單號 & "','" & Format(Today(), "yyyy-MM-dd") & "','" & Format(T2Dt生產.Value.Date, "yyyy-MM-dd") & "',"
        SQLADD += "  '" & 樓層名稱 & "','" & 樓層代碼 & "',  "
        SQLADD += "  '" & Format(下單時間, "yyyy-MM-dd hh:mm:ss.fff") & "','Y',GETDATE(),'" & UCase(GetHostName()) & "') "

        For i = 0 To T2複製明細.RowCount - 1
            If T2複製明細.Rows(i).Cells("樓層").Value = 樓層名稱 Then
                SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[生_線上撿貨List] "
                SQLADD += " ([單號],[來源作業],[來源單號],[客編],[簡稱],[存編],[品名],[生產品項],[數量],[單位],[備註],[啟用],[新增時間]) VALUES "
                SQLADD += " ('" & 單號 & "', "
                'SQLADD += "  '" & T2複製明細.Rows(i).Cells("作業").Value & "','" & T2複製明細.Rows(i).Cells("草稿").Value & "', "
                SQLADD += "  '複製','" & T2複製明細.Rows(i).Cells("單號").Value & "', "
                SQLADD += "  '" & T2複製明細.Rows(i).Cells("客編").Value & "','" & T2複製明細.Rows(i).Cells("簡稱").Value & "', "
                SQLADD += "  '" & T2複製明細.Rows(i).Cells("存編").Value & "','" & T2複製明細.Rows(i).Cells("品名").Value & "', "
                SQLADD += "  '" & T2複製明細.Rows(i).Cells("生產品項").Value & "','" & T2複製明細.Rows(i).Cells("數量").Value & "', "
                SQLADD += "  '" & T2複製明細.Rows(i).Cells("單位").Value & "','" & T2複製明細.Rows(i).Cells("備註").Value & "', "
                SQLADD += "  'Y',GETDATE() ) "
            End If
        Next

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("新撿貨單號存檔2: " & ex.Message)
        End Try

    End Sub

    'Private Sub 複製撿貨明細存檔()
    '    Dim SQLADD As String = ""
    '    For i = 0 To T1已排項目.RowCount - 1
    '        SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[生_線上撿貨List] "
    '        SQLADD += " ([單號],[來源作業],[來源單號],[客編],[簡稱],[存編],[品名],[生產品項],[數量],[單位],[備註],[啟用],[新增時間]) VALUES "
    '        SQLADD += " ('" & T1La單號.Text & "', "
    '        SQLADD += "  '" & T1已排項目.Rows(i).Cells("作業").Value & "','" & T1已排項目.Rows(i).Cells("草稿").Value & "', "
    '        SQLADD += "  '" & T1已排項目.Rows(i).Cells("客編").Value & "','" & T1已排項目.Rows(i).Cells("簡稱").Value & "', "
    '        SQLADD += "  '" & T1已排項目.Rows(i).Cells("存編").Value & "','" & T1已排項目.Rows(i).Cells("品名").Value & "', "
    '        SQLADD += "  '" & T1已排項目.Rows(i).Cells("生產品項").Value & "','" & T1已排項目.Rows(i).Cells("數量").Value & "', "
    '        SQLADD += "  '" & T1已排項目.Rows(i).Cells("單位").Value & "','" & T1已排項目.Rows(i).Cells("生管備註").Value & "', "
    '        SQLADD += "  'Y',GETDATE() ) "
    '    Next

    '    Try
    '        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
    '        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
    '        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox("新撿貨明細存檔: " & ex.Message)
    '    End Try

    'End Sub



    Private Sub T2複製明細載入()
        'Select Case T2Bu複製.Text
        '    Case "複製"

        If T2線上明細.RowCount > 0 Then
            T2複製明細.DataSource = 顯示資料.Tables("線上明細").Copy
            T2複製明細排除()
        End If
        T2線上明細.Visible = False : T2複製明細.Visible = True : T2複製明細.Size = New Size(1155, 542) : T2複製明細.Location = New Point(6, 37)
        T2Tb單號.Visible = False : T2Bu列印.Visible = False : T2Bu查詢.Visible = False
        T2Bu複製.Text = "存檔" : T2Bu刪除.Text = "放棄" ': T2Bu查詢.Text = "排入撿貨"
        T2Cb樓層.Enabled = False
        T2Dt生產.Value = Today()
        '    Case "存檔"

        'If T2複製明細.RowCount > 0 Then : T2複製明細.DataSource.Clear() : End If '清除資料
        'T2線上明細載入False()
        'T2線上明細.Visible = True : T2複製明細.Visible = False
        'T2Tb單號.Visible = True : T2Bu列印.Visible = True : T2Bu查詢.Visible = True
        'T2Bu複製.Text = "複製" : T2Bu刪除.Text = "刪除" ' : T2Bu查詢.Text = "查詢"
        'T2Cb樓層.Enabled = True
        'End Select

    End Sub

    Private Sub T2複製明細排除()
        If T2線上明細.RowCount > 0 Then   '加到DGV線上撿貨Dt
            Dim countx As Integer = T2線上明細.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                Dim isSelected As Boolean = T2線上明細.Rows(x).Cells("選擇").Value
                If isSelected = False Then
                    T2複製明細.Rows.Remove(T2複製明細.Rows(x))
                End If
                If isSelected = True Then
                    T2複製明細.Rows(x).Cells("生產品項").Value = ""
                    'T2複製明細.Rows(x).Cells("生產日期").Value = ""
                    'T2複製明細.Rows(x).Cells("下單時間").Value = ""
                End If

            Next
        End If
        'T2複製明細.AutoResizeColumns()
    End Sub

    Private Sub T2複製明細顯示()
        For Each column As DataGridViewColumn In T2複製明細.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                'Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 ': column.Frozen = True : column.ReadOnly = False
                'Case "新單號" : column.HeaderText = "新單號" : column.DisplayIndex = 0 ': column.Visible = False
                'Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 ': column.Frozen = True
                'Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 2 ': column.Frozen = True
                'Case "樓層" : column.HeaderText = "樓層" : column.DisplayIndex = 3 ': column.Frozen = True
                'Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 4 ': column.Frozen = True
                'Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5 ': column.Frozen = True
                'Case "生產品項" : column.HeaderText = "生產品項" : column.DisplayIndex = 6
                'Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 7
                'Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 8
                'Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 9
                'Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 10
                'Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 11
                'Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 12
                'Case "下單時間" : column.HeaderText = "下單時間" : column.DisplayIndex = 13
                Case "樓層" : column.HeaderText = "樓層" : column.DisplayIndex = 0 : column.Frozen = True
                Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 1 : column.Frozen = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2 : column.Frozen = True
                Case "生產品項" : column.HeaderText = "生產品項" : column.DisplayIndex = 3 : column.ReadOnly = False
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 4 : column.ReadOnly = False
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 6 : column.ReadOnly = False
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 7 : column.Visible = False
                Case "新單號" : column.HeaderText = "新單號" : column.DisplayIndex = 8 ': column.Visible = False
                Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 9 : column.Visible = False
                Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 10 : column.Visible = False
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 11 : column.Visible = False
                Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 12 : column.Visible = False
                Case "下單時間" : column.HeaderText = "下單時間" : column.DisplayIndex = 13 : column.Visible = False
                    'column.Frozen = 凍結,column.ReadOnly = 修改,column.Visible = 顯示
                Case Else
                    column.Visible = False
            End Select
        Next
        T2複製明細.AutoResizeColumns()
    End Sub


    Private Sub T2Bu刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Bu刪除.Click
        Select Case T2Bu刪除.Text
            Case "刪除"
                If T2線上明細.RowCount > 0 Then
                    Dim oAns As Integer
                    oAns = MsgBox("確定作廢此線上撿料單?" & Chr(13) & vbCrLf & T2線上明細.CurrentRow.Cells("單號").Value & vbCrLf & T2線上明細.CurrentRow.Cells("品名").Value, MsgBoxStyle.OkCancel + 16, "線上明細作廢")
                    If oAns = MsgBoxResult.Ok Then
                        T2移除單據條碼明細() : T2線上明細載入()
                    End If
                End If
            Case "放棄"

                If T2複製明細.RowCount > 0 Then : T2複製明細.DataSource.Clear() : End If '清除資料
                T2線上明細載入False()
                T2線上明細.Visible = True : T2複製明細.Visible = False
                T2Tb單號.Visible = True : T2Bu列印.Visible = True : T2Bu查詢.Visible = True
                T2Bu複製.Text = "複製" : T2Bu刪除.Text = "刪除" ' : T2Bu查詢.Text = "查詢"
                T2Cb樓層.Enabled = True
                T2Tb單號.Text = ""
        End Select
    End Sub

    Private Sub T2移除單據條碼明細()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[生_線上撿貨List] SET [啟用] = 'D',[修改時間] = GETDATE() "
            SQLCmd.CommandText += "  FROM [KaiShingPlug].[dbo].[生_線上撿貨List] WHERE [單號] = '" & T2線上明細.CurrentRow.Cells("單號").Value & "' AND [存編] = '" & T2線上明細.CurrentRow.Cells("存編").Value & "' AND [啟用] = 'Y' "

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T2Bu列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Bu列印.Click
        If T2線上明細.RowCount > 0 And T2Tb單號.Text <> "" Then
            DGV線上列印Dt暫存()
            列印線上撿貨單2()
            T2Tb單號.Text = "" : T2Tb日期.Text = "" : T2Tb樓層.Text = "" : T2Tb時間.Text = ""
        End If

    End Sub

    Private Sub T2線上明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2線上明細.CellClick
        If T2線上明細.RowCount > 0 Then
            T2Tb單號.Text = T2線上明細.CurrentRow.Cells("單號").Value
            T2Tb日期.Text = T2線上明細.CurrentRow.Cells("生產日期").Value
            T2Tb樓層.Text = T2線上明細.CurrentRow.Cells("樓層").Value
            T2Tb時間.Text = T2線上明細.CurrentRow.Cells("下單時間").Value
        Else : Exit Sub
        End If

    End Sub

    Private Sub DGV線上列印Dt暫存()
        If DGV線上列印Dt.Rows.Count > 0 Then : DGV線上列印Dt.Clear() : End If

        If T2線上明細.RowCount > 0 Then   '加到DGV線上列印Dt
            For Each oRow As DataGridViewRow In T2線上明細.Rows
                If oRow.Cells("單號").Value = T2Tb單號.Text Then
                    Dim Row As DataRow
                    Row = DGV線上列印Dt.NewRow
                    Row.Item("單號") = oRow.Cells("單號").Value
                    Row.Item("生產日期") = oRow.Cells("生產日期").Value '
                    Row.Item("樓層") = oRow.Cells("樓層").Value '
                    Row.Item("時間") = oRow.Cells("下單時間").Value '
                    Row.Item("簡稱") = oRow.Cells("簡稱").Value
                    Row.Item("品名") = oRow.Cells("品名").Value
                    Row.Item("生產品項") = oRow.Cells("生產品項").Value
                    Row.Item("數量") = oRow.Cells("數量").Value
                    Row.Item("單位") = oRow.Cells("單位").Value
                    Row.Item("生管備註") = oRow.Cells("備註").Value
                    DGV線上列印Dt.Rows.Add(Row)
                End If
            Next
        End If

    End Sub

    Private Sub 列印線上撿貨單2()
        If DGV線上列印Dt.Rows.Count > 0 Then
            Dim newRpt As 列印Print = New 列印Print
            newRpt.strPara(0) = T2Tb單號.Text
            newRpt.strPara(1) = T2Tb樓層.Text
            newRpt.strPara(2) = Format(CDate(T2Tb日期.Text), "MM月dd日")
            newRpt.strPara(3) = T2Tb時間.Text

            newRpt.StartupPath = "\A_生管\報表\線上撿貨列印.rdlc"
            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If
            newRpt.高 = "14cm" : newRpt.TYPE = "3"
            newRpt.dt = DGV線上列印Dt

            If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                newRpt.printerName = PrintDialog.PrinterSettings.PrinterName
            Else : Exit Sub
            End If
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無明細!", MsgBoxStyle.OkOnly, "派工列印")
        End If


    End Sub


End Class