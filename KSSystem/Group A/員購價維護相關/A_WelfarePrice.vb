Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_WelfarePrice

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Public Source As String
    Public ID As String

    Private Sub A_WelfarePrice_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Select Case Source
            Case "EDIT"
                ''
            Case "ADD"
                A_WelfarePriceList.MdiParent = MainForm
                A_WelfarePriceList.Show()
        End Select
    End Sub

    Private Sub A_WelfarePrice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        RB_冷凍.Checked = False
        RB_冷藏.Checked = False
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
            MsgBox("單價未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If

        If Not RB_冷藏.Checked And Not RB_冷凍.Checked Then
            MsgBox("請選擇溫層!", 16, "錯誤")
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
                    Type = "電宰品"
                    U_P7 = "KG"
                ElseIf ItemCodeTxt.Text.Substring(3, 1) = "3" Then
                    Type = "加工品"
                    U_P7 = "小單位"
                End If
            End If

            Dim 溫層 As String = String.Empty
            If RB_冷凍.Checked Then
                溫層 = "冷凍"
            ElseIf RB_冷藏.Checked Then
                溫層 = "冷藏"
            End If



            Dim Row As DataRow

            Row = ks1DataSetDGV.Tables("DT1").NewRow
            Row.Item("存貨編號") = ItemCodeTxt.Text
            Row.Item("品名") = ItemNameTxt.Text
            Row.Item("溫層") = 溫層
            Row.Item("單價") = txtPrice.Text
            Row.Item("類型") = Type
            Row.Item("計價單位") = U_P7


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

            Dim 溫層 As String = String.Empty
            If RB_冷凍.Checked Then
                溫層 = "冷凍"
            ElseIf RB_冷藏.Checked Then
                溫層 = "冷藏"
            End If

            If RB1.Checked = True Then '電宰
                sql = " SELECT T0.[ItemCode] AS '存貨編號', T0.ItemName AS '品名' "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                sql += " AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                sql += " AND T0.[ItemName] Not Like '%領改%'   "
                sql += " AND T0.[OnHand] > 0 "
                sql += " AND T0.[ItemCode] NOT IN ( SELECT ProCode FROM KS_A_WelfarePrice WHERE Examine<>'9' AND KeepName<>'" + 溫層 + "' AND Type='1' )"
                sql += sWhere_1
                sql += sWhere_2
                sql += sWhere_3
            End If

            If RB2.Checked = True Then '加工
                sql = " SELECT T0.[ItemCode] AS '存貨編號', T0.ItemName AS '品名' "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                sql += " AND SUBSTRING(T0.[ItemCode],4,1) ='3' AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                sql += " AND  T0.[ItemName] Not Like '%領改%'   "
                sql += " AND T0.[OnHand]>0 "
                sql += " AND LEN(T0.[ItemCode])=15 "
                sql += " AND T0.[ItemCode] NOT IN ( SELECT ProCode FROM KS_A_WelfarePrice WHERE Examine<>'9' AND KeepName<>'" + 溫層 + "' AND Type='2' )"
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
        Dim U_P7 As Integer '計價單位
        For i As Integer = 0 To DGV1.RowCount - 1

            If Convert.ToInt32(DGV1.Rows(i).Cells("單價").Value) = 0 Then
                MsgBox("第" + Convert.ToString(i + 1) + "筆，單價為0!", 16, "錯誤")
                SaveBtn.Enabled = True
                Exit Sub
            End If

            If DGV1.Rows(i).Cells("存貨編號").Value.Substring(0, 2) = "25" Then
                If DGV1.Rows(i).Cells("存貨編號").Value.Substring(3, 1) = "1" Or DGV1.Rows(i).Cells("存貨編號").Value.Substring(3, 1) = "2" Then
                    Type = 1 '電宰
                    U_P7 = 1 'KG
                ElseIf DGV1.Rows(i).Cells("存貨編號").Value.Substring(3, 1) = "3" Then
                    Type = 2 '加工
                    U_P7 = 2 '小單位
                End If
            End If

            SQLCmd.CommandText = String.Format(" INSERT INTO [KS_A_WelfarePrice] ([ProCode],[ProName] " & _
             ",[Price],[Examine],[Type],[U_P7],[AddDate],[AddUser],[KeepName]) VALUES ('{0}','{1}',{2},'1','{3}','{4}', getdate(), '{5}', '{6}') " _
            , DGV1.Rows(i).Cells("存貨編號").Value _
            , DGV1.Rows(i).Cells("品名").Value _
            , DGV1.Rows(i).Cells("單價").Value _
            , Type _
            , U_P7 _
            , Login.LogonUserName _
            , DGV1.Rows(i).Cells("溫層").Value)


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

        txtPrice.Text = 0      '數量
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


            sql = " Select ProCode AS '存貨編號', ProName AS '品名', Price AS '單價', Type AS '類型', U_P7 AS '計價單位', KeepName AS '溫層' From KS_A_WelfarePrice WHERE  Examine='0' "


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
                Case "溫層"
                    column.HeaderText = "溫層"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "單價"
                    column.HeaderText = " 單價"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.DefaultCellStyle.Format = "#0.0000"
                    column.Width = 60
                Case "類型"
                    column.HeaderText = "類型"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "計價單位"
                    column.HeaderText = "計價單位"
                    column.DisplayIndex = 5
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