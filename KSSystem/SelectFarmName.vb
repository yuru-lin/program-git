Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class SelectFarmName
    Public Source As String

    Private Sub SelectFarmName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGVName.ContextMenuStrip = MainForm.ContextMenuStrip1
        SelectCName()
    End Sub

    Private Sub SelectCName()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet

        sql = "SELECT T0.[CstmrCode] as '客編', T0.[CstmrName] as '名稱', T0.[U_C02] as '契養批號' FROM OCTR T0 WHERE T0.[Status] = 'D'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        DGVName.DataSource = ks1DataSet.Tables("DT1")
        DGVName.AutoResizeColumns()

        If DGVName.RowCount = 0 Then
            MsgBox("查無相關資料!請重新檢查查詢關鍵字!", 16, "錯誤")
            FinalSelectBtn.Enabled = False
            Exit Sub
        End If

    End Sub

    Private Sub FinalSelectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinalSelectBtn.Click

        If DGVName.CurrentRow.Cells("客編").Selected = False Then
            MsgBox("尚未選取資料!", 16, "錯誤")
            Exit Sub
        Else
            Select Case Source
                Case "Add"
                    B_AddTransportation.txtFarmName.Text = DGVName.CurrentRow.Cells("名稱").Value
                    B_AddTransportation.txtFarmID.Text = DGVName.CurrentRow.Cells("契養批號").Value
                Case "Update"
                    B_UpdateTransportation.txtFarmName.Text = DGVName.CurrentRow.Cells("名稱").Value
                    B_UpdateTransportation.txtFarmID.Text = DGVName.CurrentRow.Cells("契養批號").Value
                Case "Settlement"
                    A_ContractSettlement.txtFarmName.Text = DGVName.CurrentRow.Cells("名稱").Value
                    A_ContractSettlement.txtFarmID.Text = DGVName.CurrentRow.Cells("契養批號").Value
            End Select
            
        End If

        Me.Close()
    End Sub
End Class