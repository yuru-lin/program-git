Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_WelfarePriceList

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub A_WelfarePriceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        ddlType.SelectedIndex = 0
        ddlExamine.SelectedIndex = 0
        ddlKeepName.SelectedIndex = 0

        GetDGV1Data()
        DGV1Display()
    End Sub

#Region "按鈕動作"

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click '查詢

        '取得查詢資料
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        GetDGV1Data()

    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click '新增
        A_WelfarePrice.Source = "ADD"
        A_WelfarePrice.MdiParent = MainForm
        A_WelfarePrice.Show()
        Me.Close()
    End Sub
#End Region

#Region "取得DataGridView資料"
    Private Sub GetDGV1Data()

        Dim strWhere As String = ""
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        '組Where條件
        '商品名稱(關鍵字)
        If txtProName.Text <> "" Then
            strWhere += " AND (ProName like '%" + txtProName.Text + "%') "
        End If

        '類型
        If ddlType.SelectedIndex <> 0 Then
            strWhere += " AND (Type='" + Convert.ToString(ddlType.SelectedIndex) + "') "
        End If

        '狀態
        If ddlExamine.SelectedIndex <> 0 Then
            strWhere += " AND (Examine='" + Convert.ToString(ddlExamine.SelectedIndex) + "') "
        End If

        '溫層
        If ddlKeepName.SelectedIndex <> 0 Then
            strWhere += " AND (KeepName='" + ddlKeepName.SelectedItem + "') "
        End If

        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select ProCode AS '存貨編號', ProName AS '品名', Price AS '單價', "
            sql += " CASE [Type] WHEN '1' THEN '電宰品' WHEN '2' THEN '加工品' END AS '類型',  "
            sql += " CASE Examine WHEN '1' THEN '送審中' WHEN '2' THEN '已覆核' WHEN '3' THEN '退回' END AS '狀態',   "
            sql += " CASE U_P7 WHEN '0' THEN '庫存單位' WHEN '1' THEN 'KG' WHEN '2' THEN '小單位' WHEN '3' THEN '重整' END AS '計價單位' "
            sql += " ,Reason AS '退回原因', KeepName AS '溫層'"
            sql += " From KS_A_WelfarePrice "
            sql += " Where Examine<>'9' "
            sql += strWhere
            'sql += " AND AddUser='" + Login.LogonUserName + "'"
            sql += " ORDER BY 存貨編號 DESC"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

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
                Case "狀態"
                    column.HeaderText = "狀態"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "退回原因"
                    column.HeaderText = "退回原因"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Width = 250
                Case "類型"
                    column.HeaderText = "類型"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "計價單位"
                    column.HeaderText = "計價單位"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next


        '=============================================================自動產生DGV控制項 BEGIN======================================================================
        Dim 刪除 As New DataGridViewButtonColumn()
        刪除.Name = "刪除"
        刪除.HeaderText = "功能1"
        刪除.DisplayIndex = 0
        刪除.Width = 70
        刪除.Text = "刪除"
        刪除.UseColumnTextForButtonValue = True
        DGV1.Columns.Add(刪除)

        Dim 送審 As New DataGridViewButtonColumn()
        送審.Name = "送審"
        送審.HeaderText = "功能2"
        送審.DisplayIndex = 1
        送審.Width = 70
        送審.Text = "重新送審"
        送審.UseColumnTextForButtonValue = True
        DGV1.Columns.Add(送審)

        '=================自動產生DGV控制項 END=======================================================================
    End Sub
#End Region

    Private Sub DGV1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick
        If e.RowIndex <> -1 Then
            If DGV1.Columns(e.ColumnIndex).Name = "刪除" Then

                Dim sql As String = ""
                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand
                Dim tran As SqlTransaction = DBConn.BeginTransaction()

                Try
                    sql += "   UPDATE KS_A_WelfarePrice  "
                    sql += "   SET Examine='9', DeleteDate=GETDATE(), DeleteUser='" + Login.LogonUserName + "' "
                    sql += "   WHERE ProCode='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("存貨編號").Value) + "' AND KeepName='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("溫層").Value) + "' "



                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()



                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                    Exit Sub
                End Try

                MsgBox("刪除成功!", 64, "成功")

                '重新取得資料
                GetDGV1Data()
            End If

            If DGV1.Columns(e.ColumnIndex).Name = "送審" Then
                Dim sql As String = ""
                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand
                Dim tran As SqlTransaction = DBConn.BeginTransaction()

                Try
                    sql += "   UPDATE KS_A_WelfarePrice  "
                    sql += "   SET Examine='1', Price=" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("單價").Value) + ", AlterDate=GETDATE(), AlterUser='" + Login.LogonUserName + "' "
                    sql += "   WHERE ProCode='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("存貨編號").Value) + "' AND Examine='3' AND KeepName='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("溫層").Value) + "' "



                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()



                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    MsgBox("重新送審失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                    Exit Sub
                End Try

                MsgBox("送審成功!", 64, "成功")

                '重新取得資料
                GetDGV1Data()
            End If
        End If

    End Sub

    Private Sub DGV1_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DGV1.DataBindingComplete
        Try
            For i As Integer = 0 To DGV1.RowCount - 1

                If Convert.ToString(DGV1.Rows(i).Cells("狀態").Value) <> "退回" Then
                    DGV1.Rows(i).Cells("送審") = New DataGridViewTextBoxCell()
                    DGV1.Rows(i).Cells("送審").Value = ""
                End If

            Next
        Catch ex As Exception
            ' MsgBox("ERROR: " & ex.Message)
        End Try
    End Sub
End Class