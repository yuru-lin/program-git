Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 營業訂單V104   '20150522
    Dim DataAdapterDGV As SqlDataAdapter
    Dim KsDataSet As DataSet = New DataSet
    Dim KsDataSetDGV As DataSet = New DataSet

    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable
    Dim 暫時Tab As DataSet = New DataSet


    Dim TP客戶作業 As String = "TP客戶"
    Dim TP客戶查詢 As String = ""
    Dim 是否成功 As String = ""
    Dim 單號狀態 As String = ""
    Dim 錯誤資訊 As String = ""

    Private Sub 營業訂單_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabContro初始化()
        基礎資料載入()
        文字初始化()
        'Me.TabControl1.SelectedTab = Me.TP客戶
        Me.TabControl1.TabPages.Remove(TP品項)
        Me.TabControl1.TabPages.Remove(TP查詢)

        Bu110大.PerformClick()
    End Sub

    'Private Sub 營業訂單_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    'End Sub

    Private Sub TabContro初始化()
        Me.TabControl1.SelectedTab = Me.TP查詢
        Me.TabControl1.SelectedTab = Me.TP品項
        Me.TabControl1.SelectedTab = Me.TP客戶

    End Sub

    Private Sub 基礎資料載入()
        'Me.TabControl1.SelectedTab = Me.TP客戶
        基礎資料載入_司機()
        基礎資料載入_Key單人員()
        基礎資料載入_計價單位()
        基礎資料載入_小單位()

        'Me.TabControl1.SelectedTab = Me.TP品項
        T2訂單明細View()
        T2品項明細View()

    End Sub

    Private Sub 基礎資料載入_司機()
        Dim SQLQuery As String = ""
        SQLQuery = "  SELECT T0.[lastName] AS '司機', CAST(T0.EMPID AS nvarchar(10)) AS '編號', T1.[roleID]     FROM [OHEM] T0 INNER JOIN [HEM6] T1 ON T0.[empID] = T1.[empID] WHERE T1.[roleID] = 1 AND T0.[Status] = 1 "
        SQLQuery += " UNION ALL "
        SQLQuery += " SELECT T0.[CardName],           T0.[CardCode],                            T0.[lictradnum] FROM [OCRD] T0 WHERE T0.[QryGroup20] = 'Y' "
        SQLQuery += " UNION ALL "
        SQLQuery += " SELECT '' AS '司機', '' AS '編號', '' AS 'xxx' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSet, "司機明細")
            CB1司機.DataSource = KsDataSet.Tables("司機明細").Copy : CB1司機.DisplayMember = "司機" ': CB1司機.SelectedIndex = -1
            CB2司機.DataSource = KsDataSet.Tables("司機明細").Copy : CB2司機.DisplayMember = "司機" ': CB2司機.SelectedIndex = -1
            CB3司機.DataSource = KsDataSet.Tables("司機明細").Copy : CB3司機.DisplayMember = "司機" ': CB3司機.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("司機明細：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub 基礎資料載入_Key單人員()
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT T0.[empID], T0.[lastName] FROM [OHEM] T0 WHERE T0.[dept] = '5' AND T0.[status] = '1' AND T0.[position] NOT IN ('20') "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSet, "Key單人員")

            CB人員.DataSource = KsDataSet.Tables("Key單人員")
            CB人員.DisplayMember = "lastName"
            CB人員.ValueMember = "empID"
            CB人員.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("Key單人員: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub 基礎資料載入_計價單位()
        'If KsDataSet.Tables.Contains("計價單位") Then : KsDataSet.Tables("計價單位").Clear() : End If
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT T0.[FldValue] AS '計價代碼' ,T0.[Descr] AS '計價單位' FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '10' ORDER BY 1 "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSet, "計價單位")
            'If KsDataSet.Tables("計價單位").Rows.Count > 0 Then : Else : MsgBox("無庫存單位資料") : End If

        Catch ex As Exception
            MsgBox("計價單位: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub 基礎資料載入_小單位()
        'If KsDataSet.Tables.Contains("小單位") Then : KsDataSet.Tables("小單位").Clear() : End If
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT T0.[FldValue] AS '單位代碼', T0.[Descr] AS '單位名稱' FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' ORDER BY T0.[IndexID] "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSet, "小單位")
            'If KsDataSet.Tables("小單位").Rows.Count > 0 Then : Else : MsgBox("無小單位資料") : End If

        Catch ex As Exception
            MsgBox("小單位: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub 文字初始化()
        CB1司機.SelectedIndex = -1 : CB2司機.SelectedIndex = -1 : CB3司機.SelectedIndex = -1
        LA生產.Text = "N" : LA地點.Text = ""

        CB2保存.Items.Clear() : CB2製程.Items.Clear()
        CB2保存.Items.Add("不分") : CB2保存.Items.Add("冷凍") : CB2保存.Items.Add("冷藏") ': CB2保存.Items.Add("常溫")
        CB2製程.Items.Add("不分") : CB2製程.Items.Add("全雞") : CB2製程.Items.Add("分切") : CB2製程.Items.Add("全雞解凍肉") : CB2製程.Items.Add("分切解凍肉")
        CB2保存.SelectedIndex = 0 : CB2製程.SelectedIndex = 0
    End Sub

    Private Sub T2訂單明細View()
        ' 由於我們要自訂各個資料行型別，因此必須將 AutoGenerateColumns 屬性設定成 False。
        T2訂單明細.AutoGenerateColumns = False

        ' 設定奇數資料列的背景色。
        'T2訂單明細.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaptionText
        T2訂單明細.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro

        ' 設定採用儲存格選取模式。
        'T2訂單明細.SelectionMode = DataGridViewSelectionMode.CellSelect

        ' 將 DataGridView 控制項的資料來源設定成 BindingSource 元件     可先新增DGV欄位格式，後新增入資料
        'T2訂單明細.DataSource = BindingSource.DataSource
        'T2訂單明細.DataSource = KsDataSetDGV.Tables("訂單明細")

        '存編
        Dim 訂單明細存編 As New DataGridViewTextBoxColumn()
        訂單明細存編.DataPropertyName = "存編"
        訂單明細存編.HeaderText = "存編"
        訂單明細存編.Name = "存編"
        訂單明細存編.Frozen = True
        訂單明細存編.ReadOnly = True
        T2訂單明細.Columns.Add(訂單明細存編)

        '品名
        Dim 訂單明細品名 As New DataGridViewTextBoxColumn()
        訂單明細品名.DataPropertyName = "品名"
        訂單明細品名.HeaderText = "品名"
        訂單明細品名.Name = "品名"
        訂單明細品名.Frozen = True
        訂單明細品名.ReadOnly = True
        T2訂單明細.Columns.Add(訂單明細品名)

        '單價
        Dim 訂單明細單價 As New DataGridViewTextBoxColumn()
        訂單明細單價.DataPropertyName = "單價"
        訂單明細單價.HeaderText = "單價"
        訂單明細單價.Name = "單價"
        T2訂單明細.Columns.Add(訂單明細單價)

        '計價單位
        Dim 訂單明細計價單位 As New DataGridViewComboBoxColumn()
        訂單明細計價單位.DataSource = KsDataSet.Tables("計價單位")
        訂單明細計價單位.DataPropertyName = "計價單位"
        訂單明細計價單位.DisplayMember = "計價單位"
        訂單明細計價單位.ValueMember = "計價代碼"
        訂單明細計價單位.HeaderText = "計價單位"
        訂單明細計價單位.Name = "計價單位"
        T2訂單明細.Columns.Add(訂單明細計價單位)

        '庫存量
        Dim 訂單明細庫存量 As New DataGridViewTextBoxColumn()
        訂單明細庫存量.DataPropertyName = "庫存量"
        訂單明細庫存量.HeaderText = "庫存量"
        訂單明細庫存量.Name = "庫存量"
        訂單明細庫存量.ReadOnly = True
        T2訂單明細.Columns.Add(訂單明細庫存量)

        '訂單數量
        Dim 訂單明細訂單數量 As New DataGridViewTextBoxColumn()
        訂單明細訂單數量.DataPropertyName = "訂單數量"
        訂單明細訂單數量.HeaderText = "訂單數量"
        訂單明細訂單數量.Name = "訂單數量"
        T2訂單明細.Columns.Add(訂單明細訂單數量)

        '小單位數量
        Dim 訂單明細小單位數量 As New DataGridViewTextBoxColumn()
        訂單明細小單位數量.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        訂單明細小單位數量.HeaderText = "小單位數量"
        訂單明細小單位數量.Name = "小單位數量"
        訂單明細小單位數量.ReadOnly = True
        AddHandler T2訂單明細.CellValueNeeded, AddressOf 訂單明細小單位數量_CellValueNeeded
        T2訂單明細.Columns.Add(訂單明細小單位數量)

        Dim 訂單明細小單位數量2 As New DataGridViewTextBoxColumn()
        訂單明細小單位數量2.DataPropertyName = "小單位數量2"
        訂單明細小單位數量2.HeaderText = "小單位數量2"
        訂單明細小單位數量2.Name = "小單位數量2"
        訂單明細小單位數量2.Visible = False
        T2訂單明細.Columns.Add(訂單明細小單位數量2)

        '小單位
        Dim 訂單明細小單位 As New DataGridViewComboBoxColumn()
        訂單明細小單位.DataSource = KsDataSet.Tables("小單位")
        訂單明細小單位.DataPropertyName = "小單位"
        訂單明細小單位.DisplayMember = "單位名稱"
        訂單明細小單位.ValueMember = "單位代碼"
        訂單明細小單位.HeaderText = "小單位"
        訂單明細小單位.Name = "小單位"
        訂單明細小單位.ReadOnly = False
        T2訂單明細.Columns.Add(訂單明細小單位)

        '是否生產
        Dim 訂單明細是否生產 As New DataGridViewComboBoxColumn()
        '訂單明細是否生產.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        訂單明細是否生產.DataPropertyName = "是否生產"
        訂單明細是否生產.Items.AddRange(New String() {"Y", "N"})
        ' 排序下拉式清單方塊的內容。
        '訂單明細是否生產.Sorted = True
        ' 停用資料行的排序功能。
        '訂單明細是否生產.SortMode = DataGridViewColumnSortMode.NotSortable
        訂單明細是否生產.HeaderText = "是否生產"
        訂單明細是否生產.Name = "是否生產"
        訂單明細是否生產.ReadOnly = False
        T2訂單明細.Columns.Add(訂單明細是否生產)

        '小單位2
        Dim 訂單明細小單位2 As New DataGridViewTextBoxColumn()
        訂單明細小單位2.DataPropertyName = "小單位2"
        訂單明細小單位2.HeaderText = "小單位2"
        訂單明細小單位2.Name = "小單位2"
        '訂單明細小單位2.Visible = "小單位2"
        '訂單明細小單位2.ReadOnly = True
        T2訂單明細.Columns.Add(訂單明細小單位2)

        Dim 訂單明細異常 As New DataGridViewTextBoxColumn()
        訂單明細異常.DataPropertyName = "異常"
        訂單明細異常.HeaderText = "異常"
        訂單明細異常.Name = "異常"
        '訂單明細小單位2.Visible = "小單位2"
        '訂單明細小單位2.ReadOnly = True
        T2訂單明細.Columns.Add(訂單明細異常)

        'T2訂單明細.AutoResizeColumns()
    End Sub

    Private Sub T2訂單明細_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2訂單明細.CellEndEdit
        ' 由編輯資料列時 計算結果
        If e.ColumnIndex = CType(sender, DataGridView).Columns("訂單數量").Index Then
            Dim 數量 As Single
            數量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("小單位數量2").Value) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("訂單數量").Value)
            CType(sender, DataGridView).Rows(e.RowIndex).Cells("小單位數量").Value = 數量.ToString

        End If
        是否為需生產訂單()
    End Sub

    Private Sub 訂單明細小單位數量_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs)
        ' 由 SQL 轉出資料時 計算結果
        If e.ColumnIndex = CType(sender, DataGridView).Columns("小單位數量").Index Then
            Dim 數量 As Single
            數量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("小單位數量2").Value) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("訂單數量").Value)
            e.Value = 數量
        End If
    End Sub

    Private Sub T2品項明細View()
        ' 由於我們要自訂各個資料行型別，因此必須將 AutoGenerateColumns 屬性設定成 False。
        T2品項明細.AutoGenerateColumns = False

        ' 設定奇數資料列的背景色。
        'T2訂單明細.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.InactiveCaptionText
        T2品項明細.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro

        ' 設定採用儲存格選取模式。
        'T2訂單明細.SelectionMode = DataGridViewSelectionMode.CellSelect

        ' 將 DataGridView 控制項的資料來源設定成 BindingSource 元件     可先新增DGV欄位格式，後新增入資料
        'T2訂單明細.DataSource = BindingSource.DataSource
        'T2訂單明細.DataSource = KsDataSetDGV.Tables("訂單明細")

        '存編
        Dim 品項明細存編 As New DataGridViewTextBoxColumn()
        品項明細存編.DataPropertyName = "存編"
        品項明細存編.HeaderText = "存編"
        品項明細存編.Name = "存編"
        品項明細存編.Frozen = True
        品項明細存編.ReadOnly = True
        T2品項明細.Columns.Add(品項明細存編)

        '品名
        Dim 品項明細品名 As New DataGridViewTextBoxColumn()
        品項明細品名.DataPropertyName = "品名"
        品項明細品名.HeaderText = "品名"
        品項明細品名.Name = "品名"
        品項明細品名.Frozen = True
        品項明細品名.ReadOnly = True
        T2品項明細.Columns.Add(品項明細品名)

        '單價
        Dim 品項明細單價 As New DataGridViewTextBoxColumn()
        品項明細單價.DataPropertyName = "單價"
        品項明細單價.HeaderText = "單價"
        品項明細單價.Name = "單價"
        T2品項明細.Columns.Add(品項明細單價)

        '計價單位
        Dim 品項明細計價單位 As New DataGridViewComboBoxColumn()
        品項明細計價單位.DataSource = KsDataSet.Tables("計價單位")
        品項明細計價單位.DataPropertyName = "計價單位"
        品項明細計價單位.DisplayMember = "計價單位"
        品項明細計價單位.ValueMember = "計價代碼"
        品項明細計價單位.HeaderText = "計價單位"
        品項明細計價單位.Name = "計價單位"
        T2品項明細.Columns.Add(品項明細計價單位)

        '庫存量
        Dim 品項明細庫存量 As New DataGridViewTextBoxColumn()
        品項明細庫存量.DataPropertyName = "庫存量"
        品項明細庫存量.HeaderText = "庫存量"
        品項明細庫存量.Name = "庫存量"
        品項明細庫存量.ReadOnly = True
        T2品項明細.Columns.Add(品項明細庫存量)

        '訂單數量
        Dim 品項明細訂單數量 As New DataGridViewTextBoxColumn()
        品項明細訂單數量.DataPropertyName = "訂單數量"
        品項明細訂單數量.HeaderText = "訂單數量"
        品項明細訂單數量.Name = "訂單數量"
        T2品項明細.Columns.Add(品項明細訂單數量)

        '小單位數量
        Dim 品項明細小單位數量 As New DataGridViewTextBoxColumn()
        品項明細小單位數量.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        品項明細小單位數量.HeaderText = "小單位數量"
        品項明細小單位數量.Name = "小單位數量"
        品項明細小單位數量.ReadOnly = True
        AddHandler T2品項明細.CellValueNeeded, AddressOf 品項明細小單位數量_CellValueNeeded
        T2品項明細.Columns.Add(品項明細小單位數量)

        Dim 品項明細小單位數量2 As New DataGridViewTextBoxColumn()
        品項明細小單位數量2.DataPropertyName = "小單位數量2"
        品項明細小單位數量2.HeaderText = "小單位數量2"
        品項明細小單位數量2.Name = "小單位數量2"
        品項明細小單位數量2.Visible = False
        T2品項明細.Columns.Add(品項明細小單位數量2)

        '小單位
        Dim 品項明細小單位 As New DataGridViewComboBoxColumn()
        品項明細小單位.DataSource = KsDataSet.Tables("小單位")
        品項明細小單位.DataPropertyName = "小單位"
        品項明細小單位.DisplayMember = "單位名稱"
        品項明細小單位.ValueMember = "單位代碼"
        品項明細小單位.HeaderText = "小單位"
        品項明細小單位.Name = "小單位"
        品項明細小單位.ReadOnly = False
        T2品項明細.Columns.Add(品項明細小單位)

        '是否生產
        Dim 品項明細是否生產 As New DataGridViewComboBoxColumn()
        '訂單明細是否生產.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        品項明細是否生產.DataPropertyName = "是否生產"
        品項明細是否生產.Items.AddRange(New String() {"Y", "N"})
        ' 排序下拉式清單方塊的內容。
        '訂單明細是否生產.Sorted = True
        ' 停用資料行的排序功能。
        '訂單明細是否生產.SortMode = DataGridViewColumnSortMode.NotSortable
        品項明細是否生產.HeaderText = "是否生產"
        品項明細是否生產.Name = "是否生產"
        品項明細是否生產.ReadOnly = False
        T2品項明細.Columns.Add(品項明細是否生產)

        '小單位2
        Dim 品項明細小單位2 As New DataGridViewTextBoxColumn()
        品項明細小單位2.DataPropertyName = "小單位2"
        品項明細小單位2.HeaderText = "小單位2"
        品項明細小單位2.Name = "小單位2"
        '品項明細小單位2.Visible = "小單位2"
        '品項明細小單位2.ReadOnly = False
        T2品項明細.Columns.Add(品項明細小單位2)
        'T2訂單明細.AutoResizeColumns()
    End Sub

    Private Sub T2品項明細_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2品項明細.CellEndEdit
        ' 由編輯資料列時 計算結果
        If e.ColumnIndex = CType(sender, DataGridView).Columns("訂單數量").Index Then
            Dim 數量 As Single
            數量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("小單位數量2").Value) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("訂單數量").Value)
            CType(sender, DataGridView).Rows(e.RowIndex).Cells("小單位數量").Value = 數量.ToString

        End If
        '是否為需生產訂單()
    End Sub

    Private Sub 品項明細小單位數量_CellValueNeeded(ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs)
        ' 由 SQL 轉出資料時 計算結果
        If e.ColumnIndex = CType(sender, DataGridView).Columns("小單位數量").Index Then
            Dim 數量 As Single
            數量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("小單位數量2").Value) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("訂單數量").Value)
            e.Value = 數量
        End If
    End Sub

    'Private Sub 作業分頁控制(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click, TabControl1.DoubleClick, TabControl1.KeyDown
    '    Select Case TP客戶作業
    '        Case "TP客戶" : Me.TabControl1.SelectedTab = Me.TP客戶
    '        Case "TP品項" : Me.TabControl1.SelectedTab = Me.TP品項
    '        Case "TP查詢" : Me.TabControl1.SelectedTab = Me.TP查詢
    '    End Select

    'End Sub

    Private Sub Bu1查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1查詢.Click, TB1客編0.LostFocus, TB1名稱1.LostFocus, TB1名稱2.LostFocus, TB1名稱3.LostFocus
        TP客戶查詢 = "查詢" : TP客戶查詢載入()
        La客戶.Text = CB1客戶.Text
    End Sub

    Private Sub Bu1常用_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1常用.Click
        TP客戶查詢 = "常用" : TP客戶查詢載入()
    End Sub

    Private Sub Bu1超市_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1超市.Click
        TP客戶查詢 = "超市" : TP客戶查詢載入()
    End Sub

    Private Sub Bu110大_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu110大.Click
        TP客戶查詢 = "10大" : TP客戶查詢載入()
    End Sub

    'Private Sub TP客戶自定查詢(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1客編0.LostFocus, TB1名稱1.LostFocus, TB1名稱2.LostFocus, TB1名稱3.LostFocus
    '    TP客戶查詢 = "查詢" : TP客戶查詢載入()

    'End Sub

    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl1.Selected
        'MsgBox(TabControl1.SelectedTab.Text)
        Select Case TabControl1.SelectedTab.Text
            Case "輸入品項" : Bu回存草稿.Visible = True
            Case Else
                Bu回存草稿.Visible = False
        End Select
        'Select Case 目前作業
        '    Case "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
        '    Case "退貨條碼" : Me.TabControl1.SelectedTab = Me.TP退貨條碼
        '    Case "退貨入庫" : Me.TabControl1.SelectedTab = Me.TP退貨入庫
        '    Case Else
        'End Select

    End Sub

    Private Sub TP客戶查詢載入()
        If T1客戶明細.RowCount > 0 Then : KsDataSetDGV.Tables("客戶明細").Clear() : End If '清除 客戶明細 資料
        Dim SQLQuery As String = ""

        Select Case CB1客戶.Text
            Case "全聯"
                SQLQuery = "  SELECT DISTINCT T1.單號 AS '訂單單號',T2.對應2 AS '客戶編號',T3.CardName AS '客戶名稱', "
                SQLQuery += "        CONVERT(NVARCHAR(10),T1.訂貨日期,120) AS '訂貨日期', "
                SQLQuery += "        CONVERT(NVARCHAR(10),T1.到貨日期,120) AS '到貨日期', "
                SQLQuery += "        T1.處理狀態,'' AS '送貨地' "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[全聯訂單] T1 LEFT JOIN "
                SQLQuery += "        [KaiShingPlug].[dbo].[對應表]   T2 ON T2.作業功能 = '1' AND T2.作業說明 = '客戶對應' AND T1.營業所名稱 = T2.對應1 LEFT JOIN "
                SQLQuery += "                             [OCRD]     T3 ON T2.對應2 = T3.[CardCode] "
                SQLQuery += "  WHERE T1.到貨日期 = '" & DT1日期.Value.Date & "' AND T2.名稱 = '" & CB1客戶.Text & "' "
            Case "好市多"
                SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_訂單回存作業01v] 'AA',N'',N'','" & Format(DT1日期.Value.Date, "yyyy-MM-dd") & "' "
                'SQLQuery = "  SELECT [DocNo] AS '訂單單號',T2.[對應2] AS '客戶編號',T3.[CardName] AS '客戶名稱', "
                'SQLQuery += "        CONVERT(NVARCHAR(10),DATEADD(Day,-1,CAST([DocDate] AS Date)),120) AS '訂貨日期', "
                'SQLQuery += "        CONVERT(NVARCHAR(10),DATEADD(Day,-1,CAST([DocDate] AS Date)),120) AS '到貨日期', "
                'SQLQuery += "        CASE [YesNo] WHEN 'Y' THEN '未處理' WHEN 'D' THEN '刪除' WHEN 'S' THEN '已處理' ELSE '異常' END AS '處理狀態' "
                'SQLQuery += "   FROM [KaiShingPlug].[dbo].[營_訂單暫存] T0 LEFT JOIN "
                'SQLQuery += "             [KaiShingPlug].[dbo].[對應表]      T2 ON T2.[名稱] = '好市多' AND T2.[作業功能] = '1' AND T2.[啟用否] = 'Y' AND SUBSTRING([Text],66,3) = T2.[對應1] LEFT JOIN "
                'SQLQuery += "             [KaiShing].[dbo].[OCRD]            T3 ON T2.[對應2] = T3.[CardCode] "
                'SQLQuery += "  WHERE CONVERT(NVARCHAR(10),DATEADD(Day,-1,CAST([DocDate] AS Date)),120) = '" & Format(DT1日期.Value.Date, "yyyy-MM-dd") & "' AND T2.[名稱] = '好市多' AND "
                'SQLQuery += "        T0.[SID] = '0' AND [YesNo] IN ('Y','S') "
            Case "嘉珍香"
                SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_訂單回存作業01v] 'BA',N'',N'','" & Format(DT1日期.Value.Date, "yyyy-MM-dd") & "' "
                'SQLQuery = "  SELECT DISTINCT '' AS '訂單單號',T0.[CardCode] AS '客戶編號',T3.CardName AS '客戶名稱', "
                'SQLQuery += "        CONVERT(NVARCHAR(10),DATEADD(Day,-1,CAST([DocDate] AS Date)),120) AS '訂貨日期', "
                'SQLQuery += "        CONVERT(NVARCHAR(10),DATEADD(Day,-1,CAST([DocDate] AS Date)),120) AS '到貨日期', "
                'SQLQuery += "        CASE [YesNo] WHEN 'Y' THEN '未處理' WHEN 'D' THEN '刪除' WHEN 'S' THEN '已處理' ELSE '異常' END AS '處理狀態',[ShipToCode] AS '送貨地' "
                'SQLQuery += "  FROM [KaiShingPlug].[dbo].[營_訂單暫存] T0 LEFT JOIN [OCRD] T3 ON T0.[CardCode] = T3.[CardCode] "
                'SQLQuery += " WHERE T0.[DocDate] = '" & Format(DT1日期.Value.Date, "yyyy-MM-dd") & "' AND T0.[Client] = '嘉珍香' AND T0.[Quantity] <> 0 AND T0.[YesNo] = 'Y' "
                'SQLQuery += " ORDER BY 客戶編號 "
            Case Else
        End Select

        'MsgBox(SQLQuery)

        Dim DBConn As SqlConnection = Login.DBConn
                Try
                    DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
                    DataAdapterDGV.Fill(KsDataSetDGV, "客戶明細")
                    T1客戶明細.DataSource = KsDataSetDGV.Tables("客戶明細")
                    T1客戶明細.AutoResizeColumns()

                Catch ex As Exception
                    MsgBox("客戶明細：" & ex.Message)
                    Exit Sub
                End Try
    End Sub

    Private Sub T1客戶明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1客戶明細.CellClick
        TB客編.Text = T1客戶明細.CurrentRow.Cells("客戶編號").Value
        TB名稱.Text = T1客戶明細.CurrentRow.Cells("客戶名稱").Value
        TB訂單單號.Text = T1客戶明細.CurrentRow.Cells("訂單單號").Value
        DocDate.Text = T1客戶明細.CurrentRow.Cells("訂貨日期").Value
        DocDueDate.Text = T1客戶明細.CurrentRow.Cells("到貨日期").Value
        LA地點.Text = T1客戶明細.CurrentRow.Cells("送貨地").Value

    End Sub

    Private Sub Bu1確定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1確定.Click
        If TB客編.Text = "" Or TB名稱.Text = "" Then : Exit Sub : End If
        TP客戶作業 = "TP品項"
        Me.TabControl1.TabPages.Add(TP品項)
        Me.TabControl1.SelectedTab = Me.TP品項
        Me.TabControl1.TabPages.Remove(TP客戶)

        訂單明細查詢() ': 訂單備註查詢()

    End Sub

    Private Sub 訂單明細查詢()
        If T2訂單明細.RowCount > 0 Then : KsDataSetDGV.Tables("訂單明細").Clear() : End If '清除 訂單明細 資料

        Dim SQLQuery As String = ""

        'SQLQuery = "    SELECT Distinct T0.[ItemCode] AS '存編', T0.[Dscription] AS '品名', CAST(T0.[U_P8] AS NUMERIC(20)) AS '單價', T0.[U_P7] AS '計價單位', '0' AS '小單位數量', "
        'SQLQuery += "          CAST(T1.[SalPackUn] AS NUMERIC(20)) AS '小單位數量2', CAST(T1.[OnHand] AS NUMERIC(20)) AS '庫存量', '0' AS '訂單數量', "
        'SQLQuery += "          T1.[SalPackMsr] AS '小單位2', T3.[FldValue] AS '小單位', CASE SUBSTRING(T0.[ItemCode],1,3) WHEN '252' THEN 'Y' ELSE 'N' END AS '是否生產' "
        'SQLQuery += "     FROM [RDR1] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        'SQLQuery += "                    INNER JOIN (SELECT TOP 10 T0.[DocNum] FROM [ORDR] T0 WHERE T0.[CardCode] = '" & TB客編.Text & "' ORDER BY 1 DESC) R0 ON R0.[DocNum] = T0.[DocEntry] "
        'SQLQuery += "                    INNER JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] "
        'SQLQuery += "    WHERE T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9'  "
        'SQLQuery += " ORDER BY 1 "

        Select Case CB1客戶.Text
            Case "全聯"

                SQLQuery = " SELECT E.KS存編 AS '存編', E.KS品名 AS '品名', E.進價 AS '單價', '2' AS '計價單位', E.小單位數量, "
                SQLQuery += "       E.小單位數量2, E.庫存量, E.件數 AS '訂單數量', E.小單位2, E.[FldValue] AS '小單位', "
                SQLQuery += "       CASE SUBSTRING(E.KS存編,1,3) WHEN '252' THEN 'Y' ELSE 'N' END AS '是否生產', '正常' AS '異常' "
                SQLQuery += "FROM( "
                '--整件
                SQLQuery += "      SELECT M.序號, M.KS客戶存編, M.營業所名稱, M.單號, M.訂貨日期, M.到貨日期, M.KS存編, B.[ItemName] AS 'KS品名', M.箱件數, M.訂貨單位, M.進價, M.小單位數量, M.件數, "
                SQLQuery += "             CAST(B.[SalPackUn] AS NUMERIC(20)) AS '小單位數量2', CAST(B.[OnHand] AS NUMERIC(20)) AS '庫存量', B.[SalPackMsr] AS '小單位2', C.[FldValue] "
                SQLQuery += "      FROM( "
                SQLQuery += "            SELECT A.序號, A.KS客戶存編, A.營業所名稱, A.單號, A.訂貨日期, A.到貨日期, "
                SQLQuery += "                   CASE WHEN DatePart(WeekDay,A.到貨日期) = '2' THEN "
                SQLQuery += "                        (CASE WHEN LEFT(A.KS存編,4) = '2511' THEN A.KS存編 ELSE "
                SQLQuery += "                        (CASE WHEN LEFT(A.KS存編,4) = '2521' THEN '2525' + RIGHT(A.KS存編,11) "
                SQLQuery += "                              WHEN LEFT(A.KS存編,5) = '25221' THEN '25261' + RIGHT(A.KS存編,10) ELSE A.KS存編 END) + 'A' END) ELSE A.KS存編 END AS 'KS存編', "
                SQLQuery += "                   A.箱件數, A.訂貨單位, A.進價, CAST(A.箱件數 * FLOOR(A.訂貨量/A.箱件數) AS SMALLINT) AS '小單位數量', FLOOR(A.訂貨量/A.箱件數) AS '件數' "
                SQLQuery += "            FROM( "
                SQLQuery += "                  SELECT T1.序號, T1.營業所代號, T2.對應2 AS 'KS客戶存編', T1.營業所名稱, T1.單號, T1.訂貨日期, T1.到貨日期, T3.對應2 AS 'KS存編', "
                SQLQuery += "                        (SELECT TOP 1 CAST(T0.[SalPackUn] AS SMALLINT) FROM [OITM] T0 WHERE T0.[ItemCode] = T3.對應2 ORDER BY 1 desc) AS '箱件數', "
                SQLQuery += "                         T1.貨號, T1.呼出碼, T1.條碼, T1.品名, T1.規格, T1.訂貨單位, T1.售價, T1.進價, T1.訂貨量, T1.特賣註記, T1.出貨盒數, T1.出貨數量, "
                SQLQuery += "                         T1.指定出貨地點代號, T1.指定出貨地點名稱, T1.訂單備註, T1.路線名稱, T1.商品分類名稱 "
                SQLQuery += "                  FROM [KaiShingPlug].[dbo].[全聯訂單] T1 LEFT JOIN "
                SQLQuery += "                       [KaiShingPlug].[dbo].[對應表]   T2 ON T2.名稱 = '全聯' AND T2.作業功能 = '1' AND T1.營業所名稱 = T2.對應1 LEFT JOIN "
                SQLQuery += "                       [KaiShingPlug].[dbo].[對應表]   T3 ON T3.名稱 = '全聯' AND T3.作業功能 = '2' AND T1.貨號 = T3.對應1 "
                SQLQuery += "                  WHERE T1.單號 = '" & TB訂單單號.Text & "' "
                SQLQuery += "            ) A "
                SQLQuery += "            WHERE (FLOOR(A.訂貨量/A.箱件數) > 0) "
                SQLQuery += "      ) M LEFT JOIN [OITM] B ON M.KS存編 = B.[ItemCode] "
                SQLQuery += "          LEFT JOIN [UFD1] C ON C.[TableID] = 'RDR1' AND C.[FieldID] = '9' AND B.[SalPackMsr] = C.[Descr] "

                SQLQuery += "      UNION "
                '--零散
                SQLQuery += "      SELECT K.序號, K.KS客戶存編, K.營業所名稱, K.單號, K.訂貨日期, K.到貨日期, K.KS存編, C.[ItemName] AS 'KS品名', K.箱件數 , K.訂貨單位, K.進價, K.小單位數量, K.件數, "
                SQLQuery += "             CAST(C.[SalPackUn] AS NUMERIC(20)) AS '小單位數量2', CAST(C.[OnHand] AS NUMERIC(20)) AS '庫存量', C.[SalPackMsr] AS '小單位2', D.[FldValue] "
                SQLQuery += "      FROM( "
                SQLQuery += "            SELECT B.序號, B.KS客戶存編, B.營業所名稱, B.單號, B.訂貨日期, B.到貨日期, "
                SQLQuery += "                   CASE WHEN DatePart(WeekDay,B.到貨日期) = '2' THEN "
                SQLQuery += "                        (CASE WHEN LEFT(B.KS存編,4) = '2511' THEN LEFT(B.KS存編,13) + CAST(REPLICATE('0',2-(LEN(CAST(B.訂貨量%B.箱件數 AS SMALLINT)))) AS NVARCHAR(2)) + CAST(CAST(B.訂貨量%B.箱件數 AS SMALLINT) AS NVARCHAR(2)) ELSE "
                SQLQuery += "                              LEFT(CASE WHEN LEFT(B.KS存編,4) = '2521' THEN '2525' + RIGHT(B.KS存編,11) "
                SQLQuery += "                                        WHEN LEFT(B.KS存編,5) = '25221' THEN '25261' + RIGHT(B.KS存編,10) ELSE B.KS存編 END,13) + "
                SQLQuery += "                                        CAST(REPLICATE('0',2-(LEN(CAST(B.訂貨量%B.箱件數 AS SMALLINT)))) AS NVARCHAR(2)) + CAST(CAST(B.訂貨量%B.箱件數 AS SMALLINT) AS NVARCHAR(2)) + 'A' END) "
                SQLQuery += "                   ELSE LEFT(B.KS存編,13) + CAST(REPLICATE('0',2-(LEN(CAST(B.訂貨量%B.箱件數 AS SMALLINT)))) AS NVARCHAR(2)) + CAST(CAST(B.訂貨量%B.箱件數 AS SMALLINT) AS NVARCHAR(2)) END AS 'KS存編', "
                SQLQuery += "                   B.箱件數 , B.訂貨單位, B.進價, CAST(B.訂貨量%B.箱件數 AS SMALLINT) AS '小單位數量', 1 AS '件數' "
                SQLQuery += "            FROM( "
                SQLQuery += "                  SELECT T1.序號, T1.營業所代號, T2.對應2 AS 'KS客戶存編', T1.營業所名稱, T1.單號, T1.訂貨日期, T1.到貨日期, T3.對應2 AS 'KS存編', "
                SQLQuery += "                         (SELECT TOP 1 T0.[SalPackUn] FROM [OITM] T0 WHERE T0.[ItemCode] = T3.對應2 ORDER BY 1 desc) AS '箱件數', "
                SQLQuery += "                         T1.貨號, T1.呼出碼, T1.條碼, T1.品名, T1.規格, T1.訂貨單位, T1.售價, T1.進價, T1.訂貨量, T1.特賣註記, T1.出貨盒數, T1.出貨數量, "
                SQLQuery += "                         T1.指定出貨地點代號, T1.指定出貨地點名稱, T1.訂單備註, T1.路線名稱, T1.商品分類名稱 "
                SQLQuery += "                  FROM [KaiShingPlug].[dbo].[全聯訂單] T1 LEFT JOIN "
                SQLQuery += "                       [KaiShingPlug].[dbo].[對應表]   T2 ON T2.名稱 = '全聯' AND T2.作業功能 = '1' AND T1.營業所名稱 = T2.對應1 LEFT JOIN "
                SQLQuery += "                       [KaiShingPlug].[dbo].[對應表]   T3 ON T3.名稱 = '全聯' AND T3.作業功能 = '2' AND T1.貨號 = T3.對應1 "
                SQLQuery += "                  WHERE T1.單號 = '" & TB訂單單號.Text & "' "
                SQLQuery += "            ) B "
                SQLQuery += "            WHERE (B.訂貨量%B.箱件數) > 0 "
                SQLQuery += "      ) K LEFT JOIN [OITM] C ON K.KS存編 = C.[ItemCode] "
                SQLQuery += "          LEFT JOIN [UFD1] D ON D.[TableID] = 'RDR1' AND D.[FieldID] = '9' AND C.[SalPackMsr] = D.[Descr] "
                SQLQuery += ") E "
                SQLQuery += "ORDER BY E.序號, E.小單位數量 desc "

            Case "好市多"
                SQLQuery += "     SELECT E.[KS存編] AS '存編', E.[KS品名] AS '品名', E.[進價] AS '單價', '1' AS '計價單位', CAST(E.[訂貨量2] * E.[小單位數量2] AS NUMERIC(10,0)) AS '小單位數量', "
                SQLQuery += "            E.[小單位數量2], E.[庫存量], E.[訂貨量2] AS '訂單數量', E.[小單位2], E.[小單位], "
                SQLQuery += "            CASE SUBSTRING(E.KS存編,1,3) WHEN '252' THEN 'Y' ELSE 'N' END AS '是否生產', "
                SQLQuery += "            CASE WHEN E.KS存編 IN ('252140220552406','252540220552406') THEN '正常' ELSE E.[訂貨量問題] END AS '異常'  "
                'SQLQuery += "            CASE SUBSTRING(E.KS存編,1,3) WHEN '252' THEN 'Y' ELSE 'N' END AS '是否生產', E.[訂貨量問題] AS '異常' "
                SQLQuery += "       FROM ( "
                SQLQuery += "     SELECT T0.[DocNo] AS '單號',T0.[Client],SUBSTRING(T0.[Text],2,6)  AS '貨號',T2.[對應2] AS 'KS存編',T3.[ItemName] AS 'KS品名',SUBSTRING(T0.[Text],56,2)  AS '訂貨單位', "
                SQLQuery += "            CAST(REPLACE(SUBSTRING(T0.[Text],58,14),' ','') + '.' + SUBSTRING(T0.[Text],72,2) AS numeric(10, 2)) AS '進價', "
                SQLQuery += "            CAST(REPLACE(SUBSTRING(T0.[Text],40,8),' ','') AS NUMERIC(10,0))  AS '訂貨量', "
                SQLQuery += "            FLOOR(CAST(REPLACE(SUBSTRING(T0.[Text],40,8),' ','') AS NUMERIC(10,2)) / ISNULL(T3.[U_Weight],0)) AS '訂貨量2' , "

                SQLQuery += "            CASE WHEN (CAST(CAST(REPLACE(SUBSTRING(T0.[Text],40,8),' ','') AS NUMERIC(10,2)) / CAST(ISNULL(T3.[U_Weight],0) AS NUMERIC(10,2)) "
                SQLQuery += "                     -FLOOR(CAST(REPLACE(SUBSTRING(T0.[Text],40,8),' ','') AS NUMERIC(10,2)) / ISNULL(T3.[U_Weight],0)) AS NUMERIC(10,2))) = 0 "
                SQLQuery += "                 THEN '正常' ELSE '異常' END AS '訂貨量問題' , "

                SQLQuery += "            CAST(T3.[OnHand] AS NUMERIC(20)) AS '庫存量', CAST(T3.[SalPackUn] AS NUMERIC(10,2)) AS '小單位數量2', T3.[SalPackMsr] AS '小單位2', "
                SQLQuery += "            ISNULL(T3.[U_Weight],0) AS '固定重', T4.[FldValue] AS '小單位' "
                SQLQuery += "       FROM [KaiShingPlug].[dbo].[營_訂單暫存] T0 LEFT JOIN "
                SQLQuery += "            [KaiShingPlug].[dbo].[對應表]      T2 ON T2.[名稱] = '好市多' AND T2.[作業功能] = '2' AND T2.[優先順序] = '1' AND SUBSTRING(T0.[Text],2,6) = T2.[對應1] LEFT JOIN "
                SQLQuery += "            [KaiShing].[dbo].[OITM]            T3 ON T2.[對應2] = T3.[ItemCode] LEFT JOIN "
                SQLQuery += "            [KaiShing].[dbo].[UFD1]            T4 ON T4.[TableID] = 'RDR1' AND T4.[FieldID] = '9' AND T3.[SalPackMsr] = T4.[Descr] "
                'SQLQuery += "      WHERE CONVERT(NVARCHAR(10),DATEADD(Day,-1,CAST(T0.[DocDate] AS Date)),120) = '2017-07-10' AND T0.[Client] = '好市多' AND "
                SQLQuery += "      WHERE T0.[DocNo] = '" & TB訂單單號.Text & "' AND "
                SQLQuery += "            T0.[SID] <> '0' AND T0.[YesNo] IN ('Y','S') "
                SQLQuery += "            ) E "

            Case "嘉珍香"
                SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_訂單回存作業01v] N'BB',N'" & TB客編.Text & "',N'" & LA地點.Text & "',N'" & Format(DT1日期.Value.Date, "yyyy-MM-dd") & "' "


            Case Else



        End Select

                Dim DBConn As SqlConnection = Login.DBConn
                Try
                    DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
                    DataAdapterDGV.Fill(KsDataSetDGV, "訂單明細")
                    'BindingSource.DataSource = KsDataSetDGV.Tables("訂單明細")
                    T2訂單明細.DataSource = KsDataSetDGV.Tables("訂單明細")
                    T2訂單明細.AutoResizeColumns()
                    是否為需生產訂單()

                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try

    End Sub

    Private Sub 訂單備註查詢()
        'If 暫時Tab.Tables("訂單備註").Rows.Count > 0 Then : 暫時Tab.Tables("訂單備註").Clear() : End If '清除 訂單備註 資料

        Dim SQLQuery As String = ""
        SQLQuery = "  SELECT ISNULL(T0.[U_Notes],'') AS 'U_Notes' FROM [@DeliveryNote] T0 WHERE T0.[U_CardCode] = '" & TB客編.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(暫時Tab, "訂單備註")

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        If 暫時Tab.Tables("訂單備註").Rows.Count <> 0 Then
            TB2備註.Text = 暫時Tab.Tables("訂單備註").Rows(0).Item("U_Notes")
        End If
        暫時Tab.Tables("訂單備註").Clear()
    End Sub


    Private Sub T2訂單明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2訂單明細.CellClick

        For i As Integer = 0 To T2訂單明細.ColumnCount - 1
            T2訂單明細.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        TB2品名1.Text = T2訂單明細.CurrentRow.Cells("品名").Value
        'Label8.Text = T2訂單明細.CurrentRow.Cells("計價單位2").Value
        是否為需生產訂單()

    End Sub

    Private Sub 是否為需生產訂單()
        If T2訂單明細.RowCount = 0 Then : Exit Sub : End If
        Dim Cnt0 As Single = 0
        For i As Integer = 0 To T2訂單明細.RowCount - 1
            If T2訂單明細.Rows(i).Cells("訂單數量").Value > 0 Then
                Select Case T2訂單明細.Rows(i).Cells("是否生產").Value
                    Case "Y"
                        'T2訂單明細.Rows(i).DefaultCellStyle.BackColor = Color.Yellow  '以黃底顯示
                        Cnt0 += 0 + 1
                End Select
            End If
        Next
        If Cnt0 = 0 Then : LA生產.Text = "N" : Else : LA生產.Text = "Y" : End If

    End Sub

    Private Sub Bu2查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2查詢.Click
        品項明細查詢()
        品項明細查詢比對()

    End Sub

    Private Sub 品項明細查詢()
        If T2品項明細.RowCount > 0 Then : KsDataSetDGV.Tables("品項明細").Clear() : End If '清除 品項明細 資料
        Dim WHERE01 As String = "" : Dim WHERE02 As String = "" : Dim WHERE11 As String = "" : Dim WHERE12 As String = "" : Dim WHERE13 As String = ""
        Select Case CB2保存.Text    '        CB2保存.Items.Add("不分") : CB2保存.Items.Add("常溫") : CB2保存.Items.Add("冷凍") : CB2保存.Items.Add("冷藏")
            Case "不分" : WHERE01 += " AND SUBSTRING(T0.[ItemCode],3,1) IN ('1','2') "
            Case "冷凍" : WHERE01 += " AND SUBSTRING(T0.[ItemCode],3,1)  =  '1' "
            Case "冷藏" : WHERE01 += " AND SUBSTRING(T0.[ItemCode],3,1)  =  '2' "
        End Select

        Select Case CB2製程.Text
            Case "不分" : WHERE02 += " AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2','5','6') "
            Case "全雞" : WHERE02 += " AND SUBSTRING(T0.[ItemCode],4,1) =  '1' "
            Case "分切" : WHERE02 += " AND SUBSTRING(T0.[ItemCode],4,1) =  '2' "
            Case "全雞解凍肉" : WHERE02 += " AND SUBSTRING(T0.[ItemCode],4,1) =  '5' "
            Case "分切解凍肉" : WHERE02 += " AND SUBSTRING(T0.[ItemCode],4,1) =  '6' "
        End Select

        Dim WHERE11A As String = "ALL" : Dim WHERE12A As String = "ALL" : Dim WHERE13A As String = "ALL"
        If TB2品名1.Text <> "" Then : WHERE11A = TB2品名1.Text : End If
        If TB2品名2.Text <> "" Then : WHERE12A = TB2品名2.Text : End If
        If TB2品名3.Text <> "" Then : WHERE13A = TB2品名3.Text : End If

        If CB2包含查詢.Checked Then

            WHERE11 += " AND (T0.[ItemName] Like '%" & WHERE11A & "%'  "
            WHERE12 += " OR   T0.[ItemName] Like '%" & WHERE12A & "%'  "
            WHERE13 += " OR   T0.[ItemName] Like '%" & WHERE13A & "%') "
        Else

            If TB2品名1.Text <> "" Then : WHERE11 += " AND T0.[ItemName] Like '%" & Replace(Replace(TB2品名1.Text, "*", "%"), " ", "") & "%' " : End If
            If TB2品名2.Text <> "" Then : WHERE12 += " AND T0.[ItemName] Like '%" & Replace(Replace(TB2品名2.Text, "*", "%"), " ", "") & "%' " : End If
            If TB2品名3.Text <> "" Then : WHERE13 += " AND T0.[ItemName] Like '%" & Replace(Replace(TB2品名3.Text, "*", "%"), " ", "") & "%' " : End If
        End If


        Dim SQLQuery As String = ""
        SQLQuery = "       SELECT DISTINCT T0.[ItemCode] AS  '存編', T0.[ItemName] AS '品名', ISNULL(T1.[單價],0) AS '單價', ISNULL(T1.[計價單位],0) AS '計價單位', ISNULL(T1.[小單位數量],0) AS '小單位數量', CAST(T0.[SalPackUn] AS NUMERIC(20)) AS '小單位數量2', "
        SQLQuery += "             CAST(T0.[OnHand] AS NUMERIC(20)) AS '庫存量', '0' AS '訂單數量', T0.[SalPackMsr] AS '小單位2', T3.[FldValue] AS '小單位', CASE SUBSTRING(T0.[ItemCode],1,3) WHEN '252' THEN 'Y' ELSE 'N' END AS '是否生產' "
        SQLQuery += "        FROM [OITM] T0 LEFT  JOIN (SELECT * FROM "
        SQLQuery += "        (SELECT ROW_NUMBER() OVER (PARTITION BY T0.[ItemCode] ORDER BY T0.[ItemCode] ASC, R0.[DocDueDate] DESC) AS '列號', R0.[DocDueDate] AS '日期', T0.[ItemCode] AS 'ItemCode', CAST(T0.[U_P8] AS NUMERIC(20)) AS '單價', T0.[U_P7] AS '計價單位', '0' AS '小單位數量' "
        SQLQuery += "           FROM [RDR1] T0 INNER JOIN [ORDR] R0 ON R0.[DocNum] = T0.[DocEntry] WHERE R0.[CardCode] = '" & TB客編.Text & "') T0 WHERE T0.列號 = '1' ) T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLQuery += "                       INNER JOIN [UFD1] T3 ON T0.[SalPackMsr] = T3.[Descr] "
        SQLQuery += "       WHERE SUBSTRING(T0.[ItemCode],1,2) = '25'  AND T0.[ItemCode] NOT LIKE '%-%' "
        SQLQuery += WHERE01 & WHERE02 & WHERE11 & WHERE12 & WHERE13
        SQLQuery += "    ORDER BY 1 "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "品項明細")
            T2品項明細.DataSource = KsDataSetDGV.Tables("品項明細")
            dt1 = KsDataSetDGV.Tables("品項明細")
            dt2 = KsDataSetDGV.Tables("品項明細").Copy
            'T2品項明細.AutoResizeColumns()

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 品項明細查詢比對()
        If T2品項明細.RowCount > 0 Then : dt1.Clear() : End If '清除dt1資料
        dt1 = dt2.Copy : T2品項明細.DataSource = dt1

        Dim counti As Integer = T2訂單明細.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim countx As Integer = T2品項明細.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If T2訂單明細.Rows(i).Cells("存編").Value = T2品項明細.Rows(x).Cells("存編").Value Then
                    T2品項明細.Rows.Remove(T2品項明細.Rows(x))
                End If
            Next
        Next

        T2品項明細.AutoResizeColumns()
    End Sub

    Private Sub Bu2新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2新增.Click
        Dim Cnt0 As Integer = 0 : Dim Cnt1 As Integer = 0
        For i As Integer = 0 To T2品項明細.RowCount - 1
            If T2品項明細.Rows(i).Cells("訂單數量").Value > 0 And T2品項明細.Rows(i).Cells("計價單位").Value = 0 Then
                Cnt0 += 0 + 1 : End If
            If T2品項明細.Rows(i).Cells("訂單數量").Value > 0 Then
                Cnt1 += 0 + 1 : End If
        Next
        If Cnt0 > 0 Then : MsgBox("計價單位未選擇", 16, "計價單位未選擇") : Exit Sub : End If
        If Cnt1 = 0 Then : MsgBox("未有品項輸入訂購數量", 16, "未輸入訂購數量") : Exit Sub : Else : 品項新增() : 品項明細查詢比對() : 是否為需生產訂單() : End If

    End Sub

    Private Sub 品項新增()
        Dim Cnt0 As Integer = 0
        For i As Integer = 0 To T2品項明細.RowCount - 1
            If T2品項明細.Rows(i).Cells("訂單數量").Value > 0 Then
                Dim Row As DataRow
                Row = KsDataSetDGV.Tables("訂單明細").NewRow
                Row.Item("存編") = T2品項明細.Rows(i).Cells("存編").Value
                Row.Item("品名") = T2品項明細.Rows(i).Cells("品名").Value
                Row.Item("單價") = T2品項明細.Rows(i).Cells("單價").Value
                Row.Item("計價單位") = T2品項明細.Rows(i).Cells("計價單位").Value
                Row.Item("小單位數量") = T2品項明細.Rows(i).Cells("小單位數量").Value
                Row.Item("小單位數量2") = T2品項明細.Rows(i).Cells("小單位數量2").Value
                Row.Item("庫存量") = T2品項明細.Rows(i).Cells("庫存量").Value
                Row.Item("訂單數量") = T2品項明細.Rows(i).Cells("訂單數量").Value
                Row.Item("小單位2") = T2品項明細.Rows(i).Cells("小單位2").Value
                Row.Item("小單位") = T2品項明細.Rows(i).Cells("小單位").Value
                Row.Item("是否生產") = T2品項明細.Rows(i).Cells("是否生產").Value
                KsDataSetDGV.Tables("訂單明細").Rows.Add(Row)
                Cnt0 += 0 + 1
            End If
        Next
        MsgBox("新增 " & Cnt0 & "筆品項", , "新增品項")

        T2訂單明細.Sort(T2訂單明細.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

    End Sub

    Private Sub Bu回存草稿_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu回存草稿.Click
        If 登入系統 <> "0" Then : MsgBox("非SAP權限帳號登入無法作業!", 16, "錯誤") : Exit Sub : End If
        If (CB1司機.SelectedIndex = -1 Or CB1司機.Text = "") And (CB人員.SelectedIndex = -1 Or CB人員.Text = "") Then
            MsgBox("未輸入 司機1 或 Key單人員 無法作業!", 16, "錯誤") : Exit Sub : End If
        If T2訂單明細.RowCount <= 0 Then : MsgBox("無銷售資料!", 16, "錯誤") : Exit Sub : End If

        Dim Cnt0 As Integer = 0
        For j As Integer = 0 To T2訂單明細.RowCount - 1
            If T2訂單明細.Rows(j).Cells("訂單數量").Value > 0 Then
                Cnt0 = Cnt0 + 1
            End If : Next

        If Cnt0 = 0 Then : MsgBox("訂單數量全為 0 !", 16, "錯誤") : Exit Sub : End If
        Dim oAns As Integer : oAns = MsgBox("確認要新增至SAP B1 嗎?", 36, "新增") : If oAns = MsgBoxResult.No Then : Exit Sub : End If

        T2回存SAP草稿作業()

        Select Case 是否成功
            Case "Y"
                Select Case CB1客戶.Text
                    Case "全聯"
                        T1客戶處理狀態更新()
                    Case "好市多"
                    Case "嘉珍香"
                        T1客戶處理狀態更新()
                    Case Else
                End Select

                'MsgBox("SAP" & 單號狀態 & "單新增完成!!" & vbCrLf & "" & 單號狀態 & "訂單狀態：" & TB訂單單號.Text & "已處理" & vbCrLf, 64, "完成")
            Case "N"
                'MsgBox("SAP" & 單號狀態 & "單錯誤說明!!" & vbCrLf & "錯誤說明：" & 錯誤資訊 & vbCrLf, 16, "錯誤")
                Exit Sub
        End Select

        TP客戶作業 = "TP客戶"
        TB客編.Text = ""
        TB名稱.Text = ""
        TB訂單單號.Text = ""
        CB1司機.SelectedIndex = -1
        CB2司機.SelectedIndex = -1
        CB3司機.SelectedIndex = -1
        LA生產.Text = "N"
        CB人員.SelectedIndex = -1
        Me.TabControl1.TabPages.Add(TP客戶)
        Me.TabControl1.SelectedTab = Me.TP客戶
        Me.TabControl1.TabPages.Remove(TP品項)
        TP客戶查詢載入()

    End Sub

    Private Sub T2回存SAP草稿作業()

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oDraft As SAPbobsCOM.Documents
        Dim X As Integer = 0
        Dim RetVal As Long

        '回存銷售訂單正式--起
        'oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders)
        '回存銷售訂單正式--止

        '回存銷售訂單草稿--起
        oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oOrders
        '回存銷售訂單草稿--止

        ''回存出貨單草稿--起  測試
        'oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        'oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oDeliveryNotes
        ''回存出貨單草稿--止

        oDraft.CardCode = TB客編.Text
        oDraft.DocDueDate = DocDueDate.Value.Date '交貨日期
        oDraft.TaxDate = DocDueDate.Value.Date    '文件日期
        oDraft.DocDate = DocDate.Value.Date       '過帳日期

        'oDraft.Comments = Now & " 接單者：" & vbCrLf & TB2備註.Text
        oDraft.Comments = TB2備註.Text

        'If IsDBNull(T1DGV1.CurrentRow.Cells("好市多訂單編號").Value) Then : Else : oDelv.UserFields.Fields.Item("U_COSCO").Value = T1DGV1.CurrentRow.Cells("好市多訂單編號").Value : End If
        Select Case CB1客戶.Text
            Case "全聯", "好市多"
                oDraft.UserFields.Fields.Item("U_COSCO").Value = TB訂單單號.Text
            Case "嘉珍香"
                If LA地點.Text <> "" Then : oDraft.ShipToCode = LA地點.Text : End If     '送貨點
            Case Else
        End Select

        oDraft.UserFields.Fields.Item("U_P3_Order").Value = LA生產.Text     '生產訂單
        oDraft.UserFields.Fields.Item("U_CarDr1").Value = CB1司機.Text
        oDraft.UserFields.Fields.Item("U_CarDr2").Value = CB2司機.Text
        oDraft.UserFields.Fields.Item("U_CarDr3").Value = CB3司機.Text

        If CB人員.SelectedIndex > -1 Then
            oDraft.DocumentsOwner = CB人員.SelectedValue
        End If

        '表身  
        For i As Integer = 0 To T2訂單明細.RowCount - 1
            If T2訂單明細.Rows(i).Cells("訂單數量").Value > 0 Then
                oDraft.Lines.SetCurrentLine(X)  
                oDraft.Lines.ItemCode = T2訂單明細.Rows(i).Cells("存編").Value                                            '存編
                oDraft.Lines.Quantity = T2訂單明細.Rows(i).Cells("訂單數量").Value                                        '訂單數量

                oDraft.Lines.UserFields.Fields.Item("U_P6").Value = T2訂單明細.Rows(i).Cells("小單位").Value              '小單位
                oDraft.Lines.UserFields.Fields.Item("U_P7").Value = T2訂單明細.Rows(i).Cells("計價單位").Value            '計價單位
                oDraft.Lines.UserFields.Fields.Item("U_P8").Value = Val(T2訂單明細.Rows(i).Cells("單價").Value)           '單價

                oDraft.Lines.UserFields.Fields.Item("U_P4").Value = T2訂單明細.Rows(i).Cells("小單位數量").Value          '小單位總數 (T2訂單明細.Rows(i).Cells("U_P4").Value * T2訂單明細.Rows(i).Cells("訂單數量").Value)
                oDraft.Lines.UserFields.Fields.Item("U_P3_Quantity").Value = T2訂單明細.Rows(i).Cells("小單位數量").Value '生產數量 = 小單位數量 (T2訂單明細.Rows(i).Cells("U_P4").Value * T2訂單明細.Rows(i).Cells("訂單數量").Value)
                oDraft.Lines.UserFields.Fields.Item("U_P3").Value = T2訂單明細.Rows(i).Cells("是否生產").Value            '是否生產

                'oDraft.Lines.Price = "" '平均單價
                Select Case T2訂單明細.Rows(i).Cells("計價單位").Value
                    Case "0" : oDraft.Lines.UnitPrice = T2訂單明細.Rows(i).Cells("單價").Value
                    Case "1" : oDraft.Lines.UnitPrice = 0
                    Case "2" : oDraft.Lines.UnitPrice = (Val(T2訂單明細.Rows(i).Cells("單價").Value) * T2訂單明細.Rows(i).Cells("小單位數量").Value) / T2訂單明細.Rows(i).Cells("訂單數量").Value
                End Select

                oDraft.Lines.Add()
                X = X + 1
            End If
        Next

        RetVal = oDraft.Add


        If RetVal <> 0 Then
            是否成功 = "N"
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            'ClearAll()
            Exit Sub
        End If


        Dim 草稿單號 As Integer
        是否成功 = "Y"
        草稿單號 = Login.oCompany.GetNewObjectKey()
        MsgBox("新增至B1完成!!" & vbCrLf & "草稿單號：" & 草稿單號, 64, "完成")


    End Sub

    Private Sub T1客戶處理狀態更新()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            Select Case CB1客戶.Text
                Case "全聯"
                    'SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[全聯訂單] SET [處理狀態] = '已處理' "
                    'SQLCmd.CommandText += "  FROM [KaiShingPlug].[dbo].[全聯訂單] T0 "
                    'SQLCmd.CommandText += " WHERE T0.[單號] = '" & TB訂單單號.Text & "' "
                    SQLCmd.CommandText = " EXEC [KaiShingPlug].[dbo].[預_訂單回存作業01v] N'CC',N'" & TB訂單單號.Text & "',N'',N'' "
                Case "好市多"
                    SQLCmd.CommandText = " EXEC [KaiShingPlug].[dbo].[預_訂單回存作業01v] N'AC',N'" & TB訂單單號.Text & "',N'',N'' "
                Case "嘉珍香"
                    SQLCmd.CommandText = " EXEC [KaiShingPlug].[dbo].[預_訂單回存作業01v] N'BC',N'" & TB客編.Text & "',N'" & LA地點.Text & "',N'" & Format(DT1日期.Value.Date, "yyyy-MM-dd") & "' "
                Case Else
            End Select
        



            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Bu2放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2放棄.Click
        Dim oAns As Integer
        oAns = MsgBox("確定放棄此訂單?", MsgBoxStyle.OkCancel + 16, "放棄此訂單")
        If oAns = MsgBoxResult.Ok Then
            TP客戶作業 = "TP客戶"
            T2放棄初始作業()
            Me.TabControl1.TabPages.Add(TP客戶)
            Me.TabControl1.SelectedTab = Me.TP客戶
            Me.TabControl1.TabPages.Remove(TP品項)
        End If

    End Sub

    Private Sub T2放棄初始作業()
        If T2訂單明細.RowCount > 0 Then : KsDataSetDGV.Tables("訂單明細").Clear() : End If '清除 訂單明細 資料
        If T2品項明細.RowCount > 0 Then : KsDataSetDGV.Tables("品項明細").Clear() : End If '清除 品項明細 資料
        TB客編.Text = "" : TB名稱.Text = "" : CB1司機.SelectedIndex = -1 : CB2司機.SelectedIndex = -1 : CB3司機.SelectedIndex = -1 : LA生產.Text = "N"
        CB2保存.SelectedIndex = 0 : CB2製程.SelectedIndex = 0 : TB2品名1.Text = "" : TB2品名2.Text = "" : TB2品名3.Text = "" : TB2備註.Text = "" : CB2包含查詢.Checked = False

    End Sub
End Class