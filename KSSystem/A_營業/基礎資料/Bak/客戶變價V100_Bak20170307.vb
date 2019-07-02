Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 客戶變價V100_Bak20170307   '20150618   980, 680
    Dim DataAdapterDGV As SqlDataAdapter
    Dim KsDataSet As DataSet = New DataSet
    Dim KsDataSetDGV As DataSet = New DataSet

    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable

    Dim TP客戶查詢 As String = ""
    Dim TP切換限制 As String = "Y"
    Dim TP客編 As String = "" : Dim TP客名 As String = ""

    Dim 新增CB存編Up As String = "Y" : Dim 新增CB存編 As String = "Y"


    Private Sub 客戶變價_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UCase(Login.LogonUserName) = "MANAGER" Then : TP切換限制 = "Y" : End If
        TabContro初始化()

        If TP切換限制 = "Y" Then
            Me.TabControl1.TabPages.Remove(TP品項)
            Me.TabControl1.TabPages.Remove(TP預設)
            Me.TabControl1.TabPages.Remove(TP品組)
            Me.TabControl1.TabPages.Remove(TP客組)
            Me.TabControl1.TabPages.Remove(TP單號)
        End If

        Bu110大.PerformClick()

    End Sub

    Private Sub TabContro初始化()   'TP客戶,TP品項,TP預設,TP品組,TP客組
        Me.TabControl1.SelectedTab = Me.TP品項  '設定群組品項
        '單號存編2明細View()
        'T2品項項目View()
        'T2品項新增View()
        'T2品項項目Play()
        'T2品項新增Play()
        文字初始化()
        Me.TabControl1.SelectedTab = Me.TP預設  '設定客戶預設品項
        Me.TabControl1.SelectedTab = Me.TP品組  '設定客戶品項群組
        Me.TabControl1.SelectedTab = Me.TP客組  '設定客戶群組
        Me.TabControl1.SelectedTab = Me.TP客戶  '選擇預設定客戶
        Me.TabControl1.SelectedTab = Me.TP單號  '選擇單號
        單號存編2明細View()

        變價類別.SelectedIndex = 0
    End Sub

    Private Sub 文字初始化()
        CB2保存.Items.Add("不分") : CB2保存.Items.Add("冷凍") : CB2保存.Items.Add("冷藏") ': CB2保存.Items.Add("常溫")
        CB2製程.Items.Add("不分") : CB2製程.Items.Add("全雞") : CB2製程.Items.Add("分切") : CB2製程.Items.Add("全雞解凍肉") : CB2製程.Items.Add("分切解凍肉")
        CB2保存.SelectedIndex = 0 : CB2製程.SelectedIndex = 0

    End Sub

    Private Sub 單號存編2明細View() '單號存編2
        單號存編2.AutoGenerateColumns = False                                  ' 由於我們要自訂各個資料行型別，因此必須將 AutoGenerateColumns 屬性設定成 False。
        單號存編2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro  ' 設定奇數資料列的背景色。
        'T2品項項目.SelectionMode = DataGridViewSelectionMode.CellSelect         ' 設定採用儲存格選取模式。


        '選擇
        Dim 訂單明細選擇 As New DataGridViewCheckBoxColumn()
        訂單明細選擇.DataPropertyName = "選擇"
        訂單明細選擇.HeaderText = "選擇"
        訂單明細選擇.Name = "選擇"
        訂單明細選擇.Frozen = True
        '訂單明細選擇.ReadOnly = False
        單號存編2.Columns.Add(訂單明細選擇)

        '存編
        Dim 訂單明細存編 As New DataGridViewTextBoxColumn()
        訂單明細存編.DataPropertyName = "存編"
        訂單明細存編.HeaderText = "存編"
        訂單明細存編.Name = "存編"
        訂單明細存編.Frozen = True
        訂單明細存編.ReadOnly = True
        單號存編2.Columns.Add(訂單明細存編)

        '品名
        Dim 訂單明細品名 As New DataGridViewTextBoxColumn()
        訂單明細品名.DataPropertyName = "品名"
        訂單明細品名.HeaderText = "品名"
        訂單明細品名.Name = "品名"
        訂單明細品名.Frozen = True
        訂單明細品名.ReadOnly = True
        單號存編2.Columns.Add(訂單明細品名)

        '單價
        Dim 訂單明細單價 As New DataGridViewTextBoxColumn()
        訂單明細單價.DataPropertyName = "單價"
        訂單明細單價.HeaderText = "單價"
        訂單明細單價.Name = "單價"
        單號存編2.Columns.Add(訂單明細單價)

    End Sub

    Private Sub T2品項項目View()
        T2品項項目.AutoGenerateColumns = False                                  ' 由於我們要自訂各個資料行型別，因此必須將 AutoGenerateColumns 屬性設定成 False。
        T2品項項目.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro  ' 設定奇數資料列的背景色。
        'T2品項項目.SelectionMode = DataGridViewSelectionMode.CellSelect         ' 設定採用儲存格選取模式。

        '選擇
        Dim 品項項目01 As New DataGridViewCheckBoxColumn()
        品項項目01.DataPropertyName = "選擇"
        品項項目01.HeaderText = "選擇"
        品項項目01.Name = "選擇"
        品項項目01.Frozen = True
        '品項項目01.ReadOnly = False
        T2品項項目.Columns.Add(品項項目01)

        '順序
        Dim 品項項目02 As New DataGridViewTextBoxColumn()
        品項項目02.DataPropertyName = "順序"
        品項項目02.HeaderText = "順序"
        品項項目02.Name = "順序"
        品項項目02.Frozen = True
        '品項項目02.ReadOnly = False
        T2品項項目.Columns.Add(品項項目02)

        '品名
        Dim 品項項目03 As New DataGridViewTextBoxColumn()
        品項項目03.DataPropertyName = "品名"
        品項項目03.HeaderText = "品名"
        品項項目03.Name = "品名"
        '品項項目03.Frozen = True
        '品項項目03.ReadOnly = True
        T2品項項目.Columns.Add(品項項目03)

        '存編
        Dim 品項項目04 As New DataGridViewTextBoxColumn()
        品項項目04.DataPropertyName = "存編"
        品項項目04.HeaderText = "存編"
        品項項目04.Name = "存編"
        '品項項目04.Frozen = True
        '品項項目04.ReadOnly = True
        T2品項項目.Columns.Add(品項項目04)

        '編號
        Dim 品項項目05 As New DataGridViewTextBoxColumn()
        品項項目05.DataPropertyName = "編號"
        品項項目05.HeaderText = "編號"
        品項項目05.Name = "編號"
        '品項項目04.Frozen = True
        '品項項目05.ReadOnly = True
        T2品項項目.Columns.Add(品項項目05)

        '新增
        Dim 品項項目06 As New DataGridViewTextBoxColumn()
        品項項目06.DataPropertyName = "新增"
        品項項目06.HeaderText = "新增"
        品項項目06.Name = "新增"
        '品項項目06.Frozen = True
        '品項項目06.ReadOnly = True
        T2品項項目.Columns.Add(品項項目06)

    End Sub

    Private Sub T2品項項目Play()
        For Each column As DataGridViewColumn In T2品項項目.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.ReadOnly = False
                Case "順序" : column.HeaderText = "順序" : column.DisplayIndex = 1 : column.ReadOnly = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2 : column.ReadOnly = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 3 : column.ReadOnly = True
                Case "編號" : column.HeaderText = "編號" : column.DisplayIndex = 4 : column.ReadOnly = True : column.Visible = False ': column.Width = 70 : column.Visible = False
                Case "新增" : column.HeaderText = "新增" : column.DisplayIndex = 5 : column.ReadOnly = True ' : column.Visible = False ': column.Width = 70
                Case Else
                    column.Visible = False
            End Select
        Next
        T2品項項目.AutoResizeColumns()

    End Sub

    Private Sub T2品項新增View()
        T2品項新增.AutoGenerateColumns = False                                  ' 由於我們要自訂各個資料行型別，因此必須將 AutoGenerateColumns 屬性設定成 False。
        T2品項新增.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro  ' 設定奇數資料列的背景色。
        'T2品項新增.SelectionMode = DataGridViewSelectionMode.CellSelect         ' 設定採用儲存格選取模式。

        '選擇
        Dim 品項項目01 As New DataGridViewCheckBoxColumn()
        品項項目01.DataPropertyName = "選擇"
        品項項目01.HeaderText = "選擇"
        品項項目01.Name = "選擇"
        品項項目01.Frozen = True
        '品項項目01.ReadOnly = False
        T2品項新增.Columns.Add(品項項目01)

        '品名
        Dim 品項項目03 As New DataGridViewTextBoxColumn()
        品項項目03.DataPropertyName = "品名"
        品項項目03.HeaderText = "品名"
        品項項目03.Name = "品名"
        '品項項目03.Frozen = True
        '品項項目03.ReadOnly = True
        T2品項新增.Columns.Add(品項項目03)


        '存編
        Dim 品項項目04 As New DataGridViewTextBoxColumn()
        品項項目04.DataPropertyName = "存編"
        品項項目04.HeaderText = "存編"
        品項項目04.Name = "存編"
        '品項項目04.Frozen = True
        '品項項目04.ReadOnly = True
        T2品項新增.Columns.Add(品項項目04)

    End Sub

    Private Sub T2品項新增Play()
        For Each column As DataGridViewColumn In T2品項新增.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.ReadOnly = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1 : column.ReadOnly = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2 : column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
        T2品項新增.AutoResizeColumns()

    End Sub

    Private Sub Bu1查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1查詢.Click, TB1客編.LostFocus, TB1名稱.LostFocus
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

    Private Sub TP客戶查詢載入()
        If T1客戶明細.RowCount > 0 Then : KsDataSetDGV.Tables("客戶明細").Clear() : End If '清除 客戶明細 資料
        Dim SQLQuery As String = ""
        Select Case TP客戶查詢      'Replace(Replace(TB2品名1.Text, "*", "%"), " ", "")
            Case "查詢"
                If TB1客編.Text = "" And TB1名稱.Text = "" Then
                    MsgBox("未輸入查詢資料!!" & vbCrLf & "無法查詢：", 16, "錯誤") : Exit Sub
                End If

                Dim WHA0客編 As String = "" : Dim WHA1名稱 As String = "" ': Dim WHA2名稱 As String = "" : Dim WHA3名稱 As String = ""
                Dim WHB0客編 As String = "ALL" : Dim WHB1名稱 As String = "ALL" ': Dim WHB2名稱 As String = "ALL" : Dim WHB3名稱 As String = "ALL"

                If TB1客編.Text <> "" Then : WHB0客編 = TB1客編.Text : End If
                If TB1名稱.Text <> "" Then : WHB1名稱 = TB1名稱.Text : End If
                'If TB1名稱2.Text <> "" Then : WHB2名稱 = TB1名稱2.Text : End If
                'If TB1名稱3.Text <> "" Then : WHB3名稱 = TB1名稱3.Text : End If

                If TB1客編.Text <> "" Then : WHA0客編 += " AND T0.[CardCode] Like '%" & Replace(Replace(TB1客編.Text, "*", "%"), " ", "") & "%' " : End If
                If TB1名稱.Text <> "" Then : WHA1名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(TB1名稱.Text, "*", "%"), " ", "") & "%' " : End If
                'If TB1名稱2.Text <> "" Then : WHA2名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(TB1名稱2.Text, "*", "%"), " ", "") & "%' " : End If
                'If TB1名稱3.Text <> "" Then : WHA3名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(TB1名稱3.Text, "*", "%"), " ", "") & "%' " : End If

                SQLQuery = " SELECT T0.[CardCode] AS '客戶編號', T0.[CardName] AS '客戶名稱' FROM [OCRD] T0 "
                SQLQuery += " WHERE T0.[CardType] = 'C' "
                SQLQuery += WHA0客編 & WHA1名稱
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

    Private Sub TB1確定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB1確定.Click
        If TB客編.Text = "" Or TB名稱.Text = " Then" Then : Exit Sub : End If
        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(TP品項) : Me.TabControl1.TabPages.Remove(TP客戶) : End If
        Me.TabControl1.SelectedTab = Me.TP品項
        T2品項群組.MinimumSize = New Size(475, 475)

        Tab2文字初始化()
        TP客戶群品載入()
        'TP客戶載入分頁()
        'TP品項查詢載入()

    End Sub

    Private Sub Tab2文字初始化()
        TB2群名.Text = ""
        La2編碼.Text = ""
        La2群名.Text = ""
        TB2品名1.Text = ""
        CB2保存.SelectedIndex = -1
        CB2製程.SelectedIndex = -1
        CB2包含查詢.Checked = False
        'TB2品名1.MinimumSize = New Size(330, 23)
        TB2品名2.Visible = False
        TB2品名3.Visible = False
        Me.TabControl2.TabPages.Remove(TP查詢)
        If T2品項群組.RowCount > 0 Then : KsDataSetDGV.Tables("品項群組").Clear() : End If '清除
        If T2品項項目.RowCount > 0 Then : KsDataSetDGV.Tables("品項項目").Clear() : End If '清除
        If T2品項新增.RowCount > 0 Then : KsDataSetDGV.Tables("品項新增").Clear() : End If '清除

        Bu2新增.Visible = False
        T2品項新增.Visible = False

    End Sub

    Private Sub TP客戶群品載入()
        'If T2品項群組.RowCount > 0 Then : KsDataSetDGV.Tables("品項群組").Clear() : End If '清除
        Dim SQLQuery As String = ""

        SQLQuery = " SELECT [ItemNameGroup] AS '群品名稱', [FG2ID] AS '編號ID' "
        SQLQuery += "  FROM [KaiShingPlug].[dbo].[KS_FnGp2] "
        SQLQuery += " WHERE [Department] = '1' AND [YesDel] = 'Y' AND [CardCode] = '" & TB客編.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "品項群組")
            T2品項群組.DataSource = KsDataSetDGV.Tables("品項群組")
            T2品項群組.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("品項群組：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T2品項群組_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2品項群組.CellClick
        La2編碼.Text = T2品項群組.CurrentRow.Cells("編號ID").Value
        La2群名.Text = T2品項群組.CurrentRow.Cells("群品名稱").Value
        TP客戶群品品項載入()

    End Sub

    Private Sub TP客戶群品品項載入()
        If T2品項項目.RowCount > 0 Then : KsDataSetDGV.Tables("品項項目").Clear() : End If '清除
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT 'False' AS '選擇', T0.[Priorities] AS '順序', T0.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[FG2DID] AS '編號', '正常' AS '新增' "
        SQLQuery += "  FROM [KaiShingPlug].[dbo].[KS_FnGp2Ds] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLQuery += " WHERE T0.[FG2ID] = '" & La2編碼.Text & "' AND T0.[YesDel] = 'Y' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "品項項目")
            T2品項項目.DataSource = KsDataSetDGV.Tables("品項項目")
            T2品項項目.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("品項項目：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub Bu2品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2品項.Click
        If TB2群名.Text = "" Then : MsgBox("組合品名稱空白", 16, "錯誤") : Exit Sub : End If
        TP客戶群品新增()
        TP客戶群品載入()
        T2品項項目Play()
        TB2群名.Text = ""

    End Sub

    Private Sub TP客戶群品新增()
        Dim SQLADD As String = ""
        SQLADD = "   INSERT INTO [KaiShingPlug].[dbo].[KS_FnGp2] ([YesDel],[Department],[CardCode],[ItemNameGroup],[DateAdd]) VALUES "
        SQLADD += "                                                         ('Y', '1', '" & TB客編.Text & "', '" & TB2群名.Text & "', GETDATE()) "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("組合品名稱" & TB2群名.Text & "新增完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Bu2設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2設定.Click
        If La2編碼.Text = "" Then : Exit Sub : End If

        Me.TabControl2.TabPages.Add(TP查詢)
        Me.TabControl2.TabPages.Remove(TP新增)
        Me.TabControl2.SelectedTab = Me.TP查詢

        T2品項群組.Visible = False
        Bu2新增.Visible = True
        T2品項新增.Visible = True

    End Sub

    Private Sub Bu2查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2查詢.Click

        品項明細查詢()
        T2品項新增Play()

    End Sub

    Private Sub 品項明細查詢()
        If T2品項新增.RowCount > 0 Then : KsDataSetDGV.Tables("品項新增").Clear() : End If '清除 品項明細 資料
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
        If TB2品名1.Text <> "" Then : WHERE11A = Replace(TB2品名1.Text, " ", "") : End If
        If TB2品名2.Text <> "" Then : WHERE12A = Replace(TB2品名2.Text, " ", "") : End If
        If TB2品名3.Text <> "" Then : WHERE13A = Replace(TB2品名3.Text, " ", "") : End If

        If CB2包含查詢.Checked Then

            WHERE11 += " AND  T0.[ItemName] Like '%" & Replace(WHERE11A, "*", "%") & "%' "
            WHERE12 += " AND (T0.[ItemName] Like '%" & Replace(WHERE12A, "*", "%' OR T0.[ItemName] Like '%") & "%'  "
            WHERE13 += " OR   T0.[ItemName] Like '%" & Replace(WHERE13A, "*", "%' OR T0.[ItemName] Like '%") & "%') "
        Else

            If TB2品名1.Text <> "" Then : WHERE11 += " AND T0.[ItemName] Like '%" & Replace(Replace(TB2品名1.Text, "*", "%"), " ", "") & "%' " : End If
            If TB2品名2.Text <> "" Then : WHERE12 += " AND T0.[ItemName] Like '%" & Replace(Replace(TB2品名2.Text, "*", "%"), " ", "") & "%' " : End If
            If TB2品名3.Text <> "" Then : WHERE13 += " AND T0.[ItemName] Like '%" & Replace(Replace(TB2品名3.Text, "*", "%"), " ", "") & "%' " : End If
        End If

        'MsgBox(WHERE11 & WHERE12 & WHERE13)

        Dim SQLQuery As String = ""
        SQLQuery = "       SELECT 'False' AS '選擇', T0.[ItemCode] AS  '存編', T0.[ItemName] AS '品名'"
        SQLQuery += "        FROM [OITM] T0"
        SQLQuery += "       WHERE SUBSTRING(T0.[ItemCode],1,2) = '25'  AND T0.[ItemCode] NOT LIKE '%-%' "
        SQLQuery += WHERE01 & WHERE02 & WHERE11 & WHERE12 & WHERE13
        SQLQuery += "    ORDER BY 1 "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "品項新增")
            T2品項新增.DataSource = KsDataSetDGV.Tables("品項新增")
            dt1 = KsDataSetDGV.Tables("品項新增")
            dt2 = KsDataSetDGV.Tables("品項新增").Copy

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 品項明細查詢比對()
        If T2品項新增.RowCount > 0 Then : dt1.Clear() : End If '清除dt1資料
        dt1 = dt2.Copy : T2品項新增.DataSource = dt1

        Dim counti As Integer = T2品項項目.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim countx As Integer = T2品項新增.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If T2品項項目.Rows(i).Cells("存編").Value = T2品項新增.Rows(x).Cells("存編").Value Then
                    T2品項新增.Rows.Remove(T2品項新增.Rows(x))
                End If
            Next
        Next

        T2品項新增.AutoResizeColumns()
        T2品項項目.AutoResizeColumns()
    End Sub

    Private Sub CB2包含查詢_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB2包含查詢.CheckedChanged
        If CB2包含查詢.Checked = True Then
            'TB2品名1.MinimumSize = New Size(130, 23)
            TB2品名2.Visible = True
            TB2品名3.Visible = True
        Else
            'TB2品名1.MinimumSize = New Size(330, 23)
            TB2品名2.Visible = False
            TB2品名3.Visible = False
        End If
    End Sub

    Private Sub Bu2新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2新增.Click
        品項新增()
        品項明細查詢比對()

    End Sub

    Private Sub 品項新增()
        Dim Cnt0 As Integer = 0
        For Each oRow As DataGridViewRow In T2品項新增.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            Dim Row As DataRow
            Row = KsDataSetDGV.Tables("品項項目").NewRow
            If isSelected Then
                Row.Item("選擇") = False
                Row.Item("品名") = oRow.Cells("品名").Value
                Row.Item("存編") = oRow.Cells("存編").Value
                'Row.Item("編號") = La2編碼.Text
                Row.Item("新增") = "新增"
                KsDataSetDGV.Tables("品項項目").Rows.Add(Row)
                Cnt0 += 0 + 1
            End If
            oRow.Cells("選擇").Value = False
        Next
        MsgBox("新增 " & Cnt0 & "筆品項", , "新增品項")

    End Sub

    Private Sub Bu2移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2移除.Click
        Dim oAns As Integer : oAns = MsgBox("確認要品項移除嗎?", 36, "品項移除") : If oAns = MsgBoxResult.No Then : Exit Sub : End If
        品項移除()
        品項明細查詢比對()

    End Sub

    Private Sub 品項移除()
        Dim 待刪編號 As String = ""

        Dim count As Integer = T2品項項目.Rows.Count
        For i As Integer = count - 1 To 0 Step -1
            Dim isSelected As Boolean = Convert.ToBoolean(T2品項項目.Rows(i).Cells("選擇").Value)
            If isSelected Then
                'T2品項項目.Rows(i).Cells("新增").Value = "刪除"
                If T2品項項目.Rows(i).Cells("編號").Value <> "" Then
                    If 待刪編號 = "" Then
                        待刪編號 = T2品項項目.Rows(i).Cells("編號").Value
                        If 待刪編號 = "" Then
                            待刪編號 = 待刪編號 & "','" & T2品項項目.Rows(i).Cells("編號").Value
                        End If : End If : End If

                T2品項項目.Rows.Remove(T2品項項目.Rows(i))
            End If
            T2品項項目.Rows(i).Cells("選擇").Value = False
        Next
        MsgBox(待刪編號)
        'Dim SQLDel As String = ""



    End Sub

    Private Sub Bu2存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2存檔.Click

    End Sub

    Private Sub TB客編_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB客編.TextChanged
        If TB客編.Text = "" Then : Exit Sub : End If
        TB客編單號載入()
    End Sub
    Private Sub TB客編單號載入()

        If T1變價單號.RowCount > 0 Then : KsDataSetDGV.Tables("變價單號").Clear() : End If '清除
        Dim SQLQuery As String = ""
        'SQLQuery = " SELECT 'False' AS '選擇', T0.[Priorities] AS '順序', T0.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[FG2DID] AS '編號', '正常' AS '新增' "
        'SQLQuery += "  FROM [KaiShingPlug].[dbo].[KS_FnGp2Ds] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        'SQLQuery += " WHERE T0.[FG2ID] = '" & La2編碼.Text & "' AND T0.[YesDel] = 'Y' "
        SQLQuery = "  SELECT [單號],[單號日期],[日期起始],[日期結束],ISNULL([客戶群組],'') AS '客戶群組',[客戶編號],[客戶名稱],[類別],[備註],"
        SQLQuery += "        [啟用],[輸入者],[修改時間],[簽核者],[簽核時間],[ID]"
        SQLQuery += "   FROM [KaiShingPlug].[dbo].[營_報價表頭] "
        SQLQuery += "  WHERE [客戶編號] = '" & TB客編.Text & "' "


        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "變價單號")
            T1變價單號.DataSource = KsDataSetDGV.Tables("變價單號")
            T1變價單號.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("變價單號：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub T1新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1新增.Click
        If TB客編.Text = "" Or TB名稱.Text = "" Then : Exit Sub : End If
        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(TP單號) : Me.TabControl1.TabPages.Remove(TP客戶) : End If
        Me.TabControl1.SelectedTab = Me.TP單號
        單號存編2存編載入_空()

    End Sub

    Private Sub T1變價單號_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1變價單號.CellClick
        TB單號.Text = T1變價單號.CurrentRow.Cells("單號").Value

    End Sub

    Private Sub T1修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1修改.Click
        If TB客編.Text = "" Or TB名稱.Text = "" Or TB單號.Text = "" Then : Exit Sub : End If
        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(TP單號) : Me.TabControl1.TabPages.Remove(TP客戶) : End If
        Me.TabControl1.SelectedTab = Me.TP單號

    End Sub


    Private Sub Bu歷史_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu歷史.Click
        歷史訂單存編載入()
        新增CB存編 = "N"
        存編資料比對()
    End Sub

    Private Sub 歷史訂單存編載入()

        If 單號存編1.RowCount > 0 Then : KsDataSetDGV.Tables("單號存編一").Clear() : End If '清除
        If 單號存編1.RowCount > 0 Then : KsDataSetDGV.Tables("單號存編一s").Clear() : End If

        Dim SQLQuery As String = ""
        SQLQuery = "    SELECT DISTINCT R1.[ItemName] AS '品名',T0.[ItemCode] AS '存編'  "
        SQLQuery += "     FROM [RDR1] T0 INNER JOIN [ORDR] R0 ON R0.[DocNum]   = T0.[DocEntry] "
        SQLQuery += "                    INNER JOIN [OITM] R1 ON T0.[ItemCode] = R1.[ItemCode] "
        SQLQuery += "    WHERE R0.[CardCode] = '" & TB客編.Text & "' AND SUBSTRING(T0.[ItemCode],1,2) = '25' AND T0.[ItemCode] NOT LIKE '%-%'"
        SQLQuery += " ORDER BY 1 "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "單號存編一")
            DataAdapterDGV.Fill(KsDataSetDGV, "單號存編一s")
            dt1 = KsDataSetDGV.Tables("單號存編一")
            dt2 = KsDataSetDGV.Tables("單號存編一s")
            單號存編1.DataSource = dt1

            If 新增CB存編 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                單號存編1.Columns.Insert(0, checkBoxColumn)
            End If


            單號存編1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("單號存編一：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub 單號存編2存編載入_空()

        If 單號存編2.RowCount > 0 Then : KsDataSetDGV.Tables("單號存編二").Clear() : End If '清除
        Dim SQLQuery As String = ""
        SQLQuery = "    SELECT '' AS '存編', '' AS '存編', '' AS '品名', '' AS '單價' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "單號存編二")
            單號存編2.DataSource = KsDataSetDGV.Tables("單號存編二")
            單號存編2.AutoResizeColumns()
            KsDataSetDGV.Tables("單號存編二").Clear()

        Catch ex As Exception
            MsgBox("單號存編二：" & ex.Message)
            Exit Sub
        End Try

    End Sub


    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim counti As Integer = 單號存編1.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim isSelected As Boolean = Convert.ToBoolean(單號存編1.Rows(i).Cells("選擇").Value)
            If isSelected Then

                Dim Row As DataRow
                'Row = ks1DataSetDGV.Tables("DT1").NewRow
                Row = KsDataSetDGV.Tables("單號存編二").NewRow
                'Row.Item("選擇") = False
                Row.Item("存編") = 單號存編1.Rows(i).Cells("存編").Value
                Row.Item("品名") = 單號存編1.Rows(i).Cells("品名").Value
                Row.Item("單價") = 0
                KsDataSetDGV.Tables("單號存編二").Rows.Add(Row)
            End If

        Next

        單號存編2.AutoResizeColumns()
        存編資料比對()

    End Sub

    Private Sub 存編資料比對()
        'If 存編.RowCount = 0 Then : Exit Sub : End If '清除dt1資料
        If 單號存編1.RowCount > 0 Then : dt1.Clear() : End If '清除dt1資料
        dt1 = dt2.Copy : 單號存編1.DataSource = dt1

        Dim counti As Integer = 單號存編1.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim countx As Integer = 單號存編2.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If 單號存編1.Rows(i).Cells("存編").Value = 單號存編2.Rows(x).Cells("存編").Value Then

                    'If IsDBNull(dgvSourceList.Rows(i).Cells("FI118").FormattedValue) Then '重為空白或NULL時
                    'Else
                    '    vDoc.Lines.UserFields.Fields.Item("U_p2").Value = dgvSourceList.Rows(i).Cells("FI118").FormattedValue  '重量
                    'End If

                    單號存編1.Rows.Remove(單號存編1.Rows(i))
                End If
            Next
        Next
        '查詢存編DGV_Play()

    End Sub


    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        存編載入()
        新增CB存編 = "N"
        存編資料比對()
    End Sub

    Private Sub 存編載入()
        If 單號存編1.RowCount > 0 Then : KsDataSetDGV.Tables("單號存編一").Clear() : End If
        If 單號存編1.RowCount > 0 Then : KsDataSetDGV.Tables("單號存編一s").Clear() : End If

        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = "" : Dim strWHERE4 As String = ""
        Dim str品W1 As String = "ALL" : Dim str品W2 As String = "ALL" : Dim str品W3 As String = "ALL"
        If 品W1.Text <> "" Then : str品W1 = 品W1.Text : End If
        If 品W2.Text <> "" Then : str品W2 = 品W2.Text : End If
        If 品W3.Text <> "" Then : str品W3 = 品W3.Text : End If

        If 包含查詢.Checked Then

            strWHERE1 += " AND (T0.[ItemName] Like '%" & str品W1 & "%'  "
            strWHERE2 += " OR   T0.[ItemName] Like '%" & str品W2 & "%'  "
            strWHERE3 += " OR   T0.[ItemName] Like '%" & str品W3 & "%') "
        Else

            If 品W1.Text <> "" Then : strWHERE1 += " AND T0.[ItemName] Like '%" & 品W1.Text & "%' " : End If
            If 品W2.Text <> "" Then : strWHERE2 += " AND T0.[ItemName] Like '%" & 品W2.Text & "%' " : End If
            If 品W3.Text <> "" Then : strWHERE3 += " AND T0.[ItemName] Like '%" & 品W3.Text & "%' " : End If
        End If

        'Dim sql As String
        Dim SQLQuery As String = ""

        SQLQuery = "  SELECT T0.[ItemName] AS '品名',T0.[ItemCode] AS '存編' "
        SQLQuery += "   FROM [OITM] T0 "
        SQLQuery += "  WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') AND T0.[ItemName] Not Like '%XXX%' AND  T0.[ItemName] Not Like '%領改%' "
        SQLQuery += strWHERE1 + strWHERE2 + strWHERE3

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(KsDataSetDGV, "單號存編一")
            DataAdapterDGV.Fill(KsDataSetDGV, "單號存編一s")
            dt1 = KsDataSetDGV.Tables("單號存編一")
            dt2 = KsDataSetDGV.Tables("單號存編一s")
            單號存編1.DataSource = dt1

            If 新增CB存編 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                單號存編1.Columns.Insert(0, checkBoxColumn)
            End If

            單號存編1.AutoResizeColumns()

            'DataAdapterDGV.Fill(KsDataSetDGV, "單號存編一")
            '單號存編1.DataSource = KsDataSetDGV.Tables("單號存編一")
            'DGV2Display()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Bu存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu存檔.Click
        If 單號存編2.RowCount = 0 Then : Exit Sub : End If
        Dim 單號序號 As Integer : 單號序號 = 存檔1_取變價單號() : TB單號.Text = 單號序號
        存檔2_變價資料()


    End Sub

    Private Function 存檔1_取變價單號()
        Dim SQL As String
        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        SQL = " EXEC [KaiShingPlug].[dbo].[預_取報價單號] '" & Format(Now(), "yyyy-MM-dd") & "' "

        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQL
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("單號")
        Else
            oReturn = 0
        End If

        sqlReader.Close()

        Return oReturn
    End Function









    'Private Sub 存檔2_變價資料()
    '    Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

    '    Dim counti As Integer = 單號存編2.Rows.Count
    '    For i As Integer = counti - 1 To 0 Step -1
    '        Dim isSelected As Boolean = Convert.ToBoolean(單號存編2.Rows(i).Cells("選擇").Value)
    '        If isSelected Then
    '            'SQLADD += "   INSERT INTO [KaiShingPlug].[dbo].[Z_KS_ScaleOITMList] ([U_CK02],[Frozen],[Category],[OrderNum],[ItemCode],[Cancel],[Site]) VALUES "
    '            'SQLADD += " ('" & 製造單號.Text & "', "
    '            'SQLADD += "  '" & Wr凍藏代.Text & "', "
    '            'SQLADD += "  '" & Wr類別.Text & "', "
    '            'SQLADD += "  '" & 機台代碼 & "', "
    '            'SQLADD += "  '" & 存編.Rows(i).Cells("存編").Value & "', "
    '            'SQLADD += "  'Y', '" & 廠別代碼 & "' ) " & vbCrLf
    '        End If

    '    Next

    '    'For Each oRow As DataGridViewRow In 存編.Rows
    '    '    Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
    '    '    If isSelected Then
    '    '        SQLADD += "  '" & oRow.Cells("存編").Value & "' , "
    '    '    End If
    '    'Next

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand

    '    Try
    '        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
    '        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
    '        MsgBox("單號存編")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    'End Sub



End Class