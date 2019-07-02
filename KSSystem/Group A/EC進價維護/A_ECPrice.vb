Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_ECPrice

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Public Source As String
    Public ID As String

    Private Sub A_ECPrice_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Select Case Source
            Case "EDIT"
                ''
            Case "ADD"
                A_ECPriceList.MdiParent = MainForm
                A_ECPriceList.Show()
        End Select
    End Sub

    Private Sub A_ECPrice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        SaveBtn.Enabled = False '送審按鈕先不給按
        txtPrice.Text = 0

        GetDGV1Data()

        初始化()

    End Sub

    Private Sub 初始化()
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        txtPrice.Text = 0
        RB_活動.Checked = False
        RB_常態.Checked = False
    End Sub

#Region "按鈕動作"
    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click '新增項目

        If ItemCodeTxt.Text = "" Then
            MsgBox("項目編號未填!", 16, "錯誤")
            ItemCodeTxt.Focus()
            Exit Sub
        End If

        If ItemNameTxt.Text = "" Then
            MsgBox("項目名稱未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If

        If txtPrice.Text = "" Then
            MsgBox("價格未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If

        If Not RB_常態.Checked And Not RB_活動.Checked Then
            MsgBox("請選擇價格類型!", 16, "錯誤")
            Exit Sub
        End If


        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemCode], ItemName FROM [OITM]  WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("輸入的項目編號有誤!", 16, "錯誤")
                ItemCodeTxt.Focus()
                Exit Sub
            End If

            Dim Type As String = String.Empty
            Dim U_P7 As String = String.Empty


            If ItemCodeTxt.Text.Substring(0, 2) = "25" Then
                If ItemCodeTxt.Text.Substring(3, 1) = "1" Or ItemCodeTxt.Text.Substring(3, 1) = "2" Then
                    Type = "生鮮品"
                ElseIf ItemCodeTxt.Text.Substring(3, 1) = "3" Then
                    Type = "調理品"
                End If
            End If

            Dim 價格類型 As String = String.Empty
            If RB_活動.Checked Then
                價格類型 = "活動"
            ElseIf RB_常態.Checked Then
                價格類型 = "常態"
            End If



            Dim Row As DataRow

            Row = ks1DataSetDGV.Tables("DT1").NewRow
            Row.Item("存貨編號") = ItemCodeTxt.Text
            Row.Item("品名") = ItemNameTxt.Text
            Row.Item("價格類型") = 價格類型
            Row.Item("價格") = txtPrice.Text
            Row.Item("類型") = Type

            ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

        SaveBtn.Enabled = True '開放按鈕
    End Sub

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn2.Click '查詢商品
        Dim sWhere_1 As String = String.Empty
        Dim sWhere_2 As String = String.Empty
        Dim sWhere_3 As String = String.Empty

        If DGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("DT1").Clear()
        End If

        If TextBox1.Text <> "" Then
            sWhere_1 = " AND T0.[ItemName] Like '%" & TextBox1.Text & "%' "
        End If

        If TextBox2.Text <> "" Then
            sWhere_2 = " AND T0.[ItemName] Like '%" & TextBox2.Text & "%'  "
        End If

        If TextBox3.Text <> "" Then
            sWhere_3 = " AND T0.[ItemName] Like '%" & TextBox3.Text & "%' "
        End If

        Dim sql As String = String.Empty
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Dim 價格類型 As String = String.Empty
            If RB_活動.Checked Then
                價格類型 = "活動"
            ElseIf RB_常態.Checked Then
                價格類型 = "常態"
            End If

            If RB1.Checked = True Then '生鮮
                sql = " SELECT T0.[ItemCode] AS '存貨編號', T0.ItemName AS '品名' "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                sql += " AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                sql += " AND T0.[ItemName] Not Like '%領改%'   "
                sql += " AND T0.[OnHand] > 0 "
                sql += " AND T0.[ItemCode] NOT IN ( SELECT ProCode FROM KS_A_ECPrice WHERE Examine<>'9' AND PriceType<>'" + 價格類型 + "' AND Type='1' )"
                sql += sWhere_1
                sql += sWhere_2
                sql += sWhere_3
            End If

            If RB2.Checked = True Then '調理
                sql = " SELECT T0.[ItemCode] AS '存貨編號', T0.ItemName AS '品名' "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                sql += " AND SUBSTRING(T0.[ItemCode],4,1) ='3' AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                sql += " AND  T0.[ItemName] Not Like '%領改%'   "
                sql += " AND T0.[OnHand]>0 "
                sql += " AND LEN(T0.[ItemCode])=15 "
                sql += " AND T0.[ItemCode] NOT IN ( SELECT ProCode FROM KS_A_ECPrice WHERE Examine<>'9' AND PriceType<>'" + 價格類型 + "' AND Type='2' )"
                sql += sWhere_1
                sql += sWhere_2
                sql += sWhere_3
            End If


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "DT1")

            DGV2.DataSource = ks2DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV2Display()
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click '按下送出申請


        If DGV1.RowCount <= 0 Then
            MsgBox("無新增任何項目資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer

        oAns = MsgBox("確認要送審 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        '鎖住按鈕
        SaveBtn.Enabled = False

        Select Case Source
            Case "EDIT" '修改
                'EditData()
            Case "ADD" '新增
                InsertData()
        End Select


    End Sub

    Private Sub InsertData()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        '===========================================寫入資料庫作業Begin===============================================

        Dim Type As Integer '類型
        Dim PriceType As Integer '價格類型
        For i As Integer = 0 To DGV1.RowCount - 1

            If Convert.ToInt32(DGV1.Rows(i).Cells("價格").Value) = 0 Then
                MsgBox("第" + Convert.ToString(i + 1) + "筆，價格為0!", 16, "錯誤")
                SaveBtn.Enabled = True
                Exit Sub
            End If

            If DGV1.Rows(i).Cells("存貨編號").Value.Substring(0, 2) = "25" Then
                If DGV1.Rows(i).Cells("存貨編號").Value.Substring(3, 1) = "1" Or DGV1.Rows(i).Cells("存貨編號").Value.Substring(3, 1) = "2" Then
                    Type = 1 '生鮮
                ElseIf DGV1.Rows(i).Cells("存貨編號").Value.Substring(3, 1) = "3" Then
                    Type = 2 '調理
                End If
            End If

            Select Case DGV1.Rows(i).Cells("價格類型").Value
                Case "常態"
                    PriceType = 1
                Case "活動"
                    PriceType = 2
            End Select

            SQLCmd.CommandText = String.Format(" INSERT INTO [KS_A_ECPrice] ([ProCode],[ProName] " & _
             ",[Price],[Examine],[Type],[PriceType],[AddDate],[AddUser]) VALUES ('{0}','{1}',{2},'1','{3}','{4}', getdate(), '{5}') " _
            , DGV1.Rows(i).Cells("存貨編號").Value _
            , DGV1.Rows(i).Cells("品名").Value _
            , DGV1.Rows(i).Cells("價格").Value _
            , Type _
            , PriceType _
            , Login.LogonUserName)



            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Next

        MsgBox("員購價設定送審成功!!", 64, "完成")
        ks1DataSetDGV.Tables("DT1").Clear()
        GetDGV1Data()

        '===========================================寫入資料庫作業END===============================================
    End Sub

    Private Sub DGV2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount <= 0 Then
            Exit Sub
        End If

        ItemCodeTxt.Text = DGV2.CurrentRow.Cells("存貨編號").Value
        ItemNameTxt.Text = DGV2.CurrentRow.Cells("品名").Value
        SelectItemCode()

        txtPrice.Text = 0      '價格
    End Sub

    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()

    End Sub

    Private Sub ItemNameTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()

    End Sub

    Private Sub SelectItemCode()

        If ItemCodeTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2','3')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                'sqlReader.Close()

                'SelectItem.getItemName = ItemNameTxt.Text
                'SelectItem.getItemCode = ItemCodeTxt.Text
                'SelectItem.Source = "ORDR"
                'SelectItem.MdiParent = MainForm
                'SelectItem.Show()
                MsgBox("輸入的項目編號有誤!", 16, "錯誤")
            Else
                ItemNameTxt.Text = sqlReader.Item("ItemName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemName()

        If ItemNameTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [ItemCode]  FROM [OITM] WHERE [ItemName] = '" & ItemNameTxt.Text & "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "ORDR"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemCodeTxt.Text = sqlReader.Item("ItemCode")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub
#End Region

#Region "取得DataGridView資料"
    Private Sub GetDGV1Data()


        If DGV1.RowCount > 0 Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select ProCode AS '存貨編號', ProName AS '品名', Price AS '價格', PriceType AS '價格類型', Type AS '類型' From KS_A_ECPrice WHERE  Examine='0' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV1Display()
    End Sub


    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "存貨編號"
                    column.HeaderText = "存貨編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 110
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 180
                Case "價格"
                    column.HeaderText = " 價格"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.DefaultCellStyle.Format = "#0.0000"
                    column.Width = 60
                Case "價格類型"
                    column.HeaderText = "價格類型"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "類型"
                    column.HeaderText = "類型"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next





    End Sub

    Private Sub DGV2Display()

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "存貨編號"
                    column.HeaderText = "存貨編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 110
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 180
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub
#End Region


End Class