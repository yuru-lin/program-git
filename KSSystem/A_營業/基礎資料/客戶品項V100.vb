Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 客戶品項V100   '20150618   980, 680
    Dim DataAdapterDGV As SqlDataAdapter
    Dim KsDataSet As DataSet = New DataSet
    Dim KsDataSetDGV As DataSet = New DataSet

    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable

    Dim TP客戶查詢 As String = ""
    Dim TP切換限制 As String = "Y"
    Dim TP客編 As String = "" : Dim TP客名 As String = ""

    Private Sub 客戶品項_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UCase(Login.LogonUserName) = "MANAGER" Then : TP切換限制 = "Y" : End If
        TabContro初始化()

        If TP切換限制 = "Y" Then
            Me.TabControl1.TabPages.Remove(TP品項)
            Me.TabControl1.TabPages.Remove(TP預設)
            Me.TabControl1.TabPages.Remove(TP品組)
            Me.TabControl1.TabPages.Remove(TP客組)
        End If

        Bu110大.PerformClick()

    End Sub

    Private Sub TabContro初始化()   'TP客戶,TP品項,TP預設,TP品組,TP客組
        Me.TabControl1.SelectedTab = Me.TP品項  '設定群組品項
        T2品項項目View()
        T2品項新增View()
        T2品項項目Play()
        T2品項新增Play()
        文字初始化()
        Me.TabControl1.SelectedTab = Me.TP預設  '設定客戶預設品項
        Me.TabControl1.SelectedTab = Me.TP品組  '設定客戶品項群組
        Me.TabControl1.SelectedTab = Me.TP客組  '設定客戶群組
        Me.TabControl1.SelectedTab = Me.TP客戶  '選擇預設定客戶

    End Sub

    Private Sub 文字初始化()
        CB2保存.Items.Add("不分") : CB2保存.Items.Add("冷凍") : CB2保存.Items.Add("冷藏") ': CB2保存.Items.Add("常溫")
        CB2製程.Items.Add("不分") : CB2製程.Items.Add("全雞") : CB2製程.Items.Add("分切") : CB2製程.Items.Add("全雞解凍肉") : CB2製程.Items.Add("分切解凍肉")
        CB2保存.SelectedIndex = 0 : CB2製程.SelectedIndex = 0

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






End Class