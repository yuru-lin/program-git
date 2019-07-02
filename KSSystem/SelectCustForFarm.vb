Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class SelectCustForFarm
    Private Sub SelectCustForFarm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGVName.ContextMenuStrip = MainForm.ContextMenuStrip1
        SelectCName()
    End Sub

    Private Sub SelectCName()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet

        sql = "SELECT [CardCode] as '客戶編號',[CardName] as '客戶名稱',[AddID] as '簡稱' FROM [OCRD] WHERE [CardType] = 'C' and left([CardCode],2) = 'A2' and [CardName] like '%" + A_ContractFarms.CardName.Text + "%'"
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        DGVName.DataSource = ks1DataSet.Tables("DT1")
        DGVName.AutoResizeColumns()
    End Sub

    Private Sub FinalSelectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinalSelectBtn.Click
        'A_ContractFarms.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
        'A_ContractFarms.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
        '新增空值判斷!
        If DGVName.SelectedCells.Count > 0 Then
            A_ContractFarms.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
            A_ContractFarms.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub
End Class