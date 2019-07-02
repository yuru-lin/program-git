Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QueryWplaceStatus

    Private Sub C_QueryWplaceStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView2.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub Quy()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim ks1DataSet As DataSet = New DataSet
        Dim DataAdapter1 As SqlDataAdapter

        sql = "exec  mks801013A "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        DataGridView1.DataSource = ks1DataSet.Tables("DT1")
        DGV1Display()

    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DataGridView1.Columns
            column.Visible = True
            Select Case column.Name
                Case "儲位" : column.HeaderText = "儲位" : column.DisplayIndex = 0
                Case "說明" : column.HeaderText = "說明" : column.DisplayIndex = 1
                Case Else
                    column.Visible = False
            End Select
        Next
        DataGridView1.AutoResizeColumns()
        Label4.Text = DataGridView1.RowCount

    End Sub
    Private Sub Quy2()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim ks1DataSet As DataSet = New DataSet
        Dim DataAdapter1 As SqlDataAdapter

        sql = "exec  mks801013B "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        DataGridView2.DataSource = ks1DataSet.Tables("DT1")
        DGV1Display2()

    End Sub

    Private Sub DGV1Display2()

        For Each column As DataGridViewColumn In DataGridView2.Columns
            column.Visible = True
            Select Case column.Name
                Case "儲位"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 0
                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 1
                Case Else
                    column.Visible = False
            End Select
        Next
        DataGridView2.AutoResizeColumns()
        Label7.Text = DataGridView2.RowCount

    End Sub

    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch1.Click
        Quy()
    End Sub

    Private Sub btnSearch2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch2.Click
        Quy2()
    End Sub

    Private Sub btnToExcel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel1.Click
        DataToExcel(DataGridView1, "")
    End Sub

    Private Sub btnToExcel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel2.Click
        DataToExcel(DataGridView2, "")
    End Sub

   
End Class