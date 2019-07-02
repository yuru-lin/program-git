Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 營業訂單V103   '20150522
    Dim DataAdapterDGV As SqlDataAdapter
    Dim KsDataSet As DataSet = New DataSet
    Dim KsDataSetDGV As DataSet = New DataSet

    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable
    Dim 暫時Tab As DataSet = New DataSet


    Dim TP客戶作業 As String = "TP客戶"
    Dim TP客戶查詢 As String = ""

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
        LA生產.Text = "N"

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

    Private Sub TP客戶查詢載入()
        If T1客戶明細.RowCount > 0 Then : KsDataSetDGV.Tables("客戶明細").Clear() : End If '清除 客戶明細 資料
        Dim SQLQuery As String = ""
        Select Case TP客戶查詢      'Replace(Replace(TB2品名1.Text, "*", "%"), " ", "")
            Case "查詢"
                If TB1客編0.Text = "" And TB1名稱1.Text = "" And TB1名稱2.Text = "" And TB1名稱3.Text = "" Then
                    MsgBox("未輸入查詢資料!!" & vbCrLf & "無法查詢：", 16, "錯誤") : Exit Sub
                End If

                Dim WHA0客編 As String = "" : Dim WHA1名稱 As String = "" : Dim WHA2名稱 As String = "" : Dim WHA3名稱 As String = ""
                Dim WHB0客編 As String = "ALL" : Dim WHB1名稱 As String = "ALL" : Dim WHB2名稱 As String = "ALL" : Dim WHB3名稱 As String = "ALL"

                If TB1客編0.Text <> "" Then : WHB0客編 = TB1客編0.Text : End If
                If TB1名稱1.Text <> "" Then : WHB1名稱 = TB1名稱1.Text : End If
                If TB1名稱2.Text <> "" Then : WHB2名稱 = TB1名稱2.Text : End If
                If TB1名稱3.Text <> "" Then : WHB3名稱 = TB1名稱3.Text : End If

                If TB1客編0.Text <> "" Then : WHA0客編 += " AND T0.[CardCode] Like '%" & Replace(Replace(TB1客編0.Text, "*", "%"), " ", "") & "%' " : End If
                If TB1名稱1.Text <> "" Then : WHA1名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(TB1名稱1.Text, "*", "%"), " ", "") & "%' " : End If
                If TB1名稱2.Text <> "" Then : WHA2名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(TB1名稱2.Text, "*", "%"), " ", "") & "%' " : End If
                If TB1名稱3.Text <> "" Then : WHA3名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(TB1名稱3.Text, "*", "%"), " ", "") & "%' " : End If

                SQLQuery = " SELECT T0.[CardCode] AS '客戶編號', T0.[CardName] AS '客戶名稱' FROM [OCRD] T0 "
                SQLQuery += " WHERE T0.[CardType] = 'C' "
                SQLQuery += WHA0客編 & WHA1名稱 & WHA2名稱 & WHA3名稱
                SQLQuery += "   AND T0.[CardCode] NOT IN ('A101048002','A101048000','A101048001','A101048004','A101048005','A101292000','A101292001','A101292002','A101292003','A101292004','A101292005','A101292006','A101292007','A101292008','A101292009','A102001000','A103015002','A106039001','A102069000','A101312000','A102134001','A102134000','A106038001','A106025000','A102143000') "

            Case "常用" : Exit Sub
                'SQLQuery = ""
            Case "超市" : Exit Sub
                'SQLQuery = ""
            Case "10大"
                SQLQuery = " SELECT [CardCode] AS '客戶編號', [CardName] AS '客戶名稱' FROM [OCRD] "
                SQLQuery += " WHERE [CardType] = 'C' AND [CardCode] IN ('A101048002','A101048000','A101048001','A101048004','A101048005','A101292000','A101292001','A101292002','A101292003','A101292004','A101292005','A101292006','A101292007','A101292008','A101292009','A102001000','A103015002','A106039001','A102069000','A101312000','A102134001','A102134000','A106038001','A106025000','A102143000') "
            Case Else : SQLQuery = ""
        End Select

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

    End Sub

    Private Sub Bu1確定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1確定.Click
        If TB客編.Text = "" Or TB名稱.Text = "" Then : Exit Sub : End If
        TP客戶作業 = "TP品項"
        Me.TabControl1.TabPages.Add(TP品項)
        Me.TabControl1.SelectedTab = Me.TP品項
        Me.TabControl1.TabPages.Remove(TP客戶)

        訂單明細查詢() : 訂單備註查詢()

    End Sub

    Private Sub 訂單明細查詢()
        If T2訂單明細.RowCount > 0 Then : KsDataSetDGV.Tables("訂單明細").Clear() : End If '清除 訂單明細 資料

        Dim SQLQuery As String = ""
        SQLQuery = "    SELECT Distinct T0.[ItemCode] AS '存編', T0.[Dscription] AS '品名', CAST(T0.[U_P8] AS NUMERIC(20)) AS '單價', T0.[U_P7] AS '計價單位', '0' AS '小單位數量', CAST(T1.[SalPackUn] AS NUMERIC(20)) AS '小單位數量2', CAST(T1.[OnHand] AS NUMERIC(20)) AS '庫存量', '0' AS '訂單數量', T1.[SalPackMsr] AS '小單位2', T3.[FldValue] AS '小單位', CASE SUBSTRING(T0.[ItemCode],1,3) WHEN '252' THEN 'Y' ELSE 'N' END AS '是否生產' "
        SQLQuery += "     FROM [RDR1] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLQuery += "                    INNER JOIN (SELECT TOP 10 T0.[DocNum] FROM [ORDR] T0 WHERE T0.[CardCode] = '" & TB客編.Text & "' ORDER BY 1 DESC) R0 ON R0.[DocNum] = T0.[DocEntry] "
        SQLQuery += "                    INNER JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] "
        SQLQuery += "    WHERE T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9'  "
        SQLQuery += " ORDER BY 1 "

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

        Try
            Dim DBConn As SqlConnection = Login.DBConn
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
        oDraft.DocDueDate = DocDueDate.Value.Date

        'oDraft.Comments = Now & " 接單者：" & vbCrLf & TB2備註.Text
        oDraft.Comments = TB2備註.Text

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
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            'ClearAll()
            Exit Sub
        End If

        Dim 草稿單號 As Integer
        草稿單號 = Login.oCompany.GetNewObjectKey()
        MsgBox("新增至B1完成!!" & vbCrLf & "草稿單號：" & 草稿單號, 64, "完成")

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