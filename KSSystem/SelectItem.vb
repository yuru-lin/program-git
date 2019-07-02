Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class SelectItem
    Public getItemName As String
    Public getItemCode As String
    Public Source As String

    Private Sub SelectItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load      
        DGVName.ContextMenuStrip = MainForm.ContextMenuStrip1
        SelectCName()
    End Sub

    Private Sub SelectCName()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet
        Using TransactionMonitor As New System.Transactions.TransactionScope
            Select Case Source
                Case "OPOR"
                    If getItemCode <> "" Then
                        sql = "SELECT [ItemCode] as '產品編號',[ItemName] as '產品名稱' FROM [OITM] WHERE [ItemCode] like '" + getItemCode + "%' and left(ItemCode,4) = '2100' "
                    End If

                    If getItemName <> "" Then
                        sql = "SELECT [ItemCode] as '產品編號',[ItemName] as '產品名稱' FROM [OITM] WHERE [ItemName] like '%" + getItemName + "%' and left(ItemCode,4) = '2100' "
                    End If
                Case Else
                    If getItemCode <> "" Then
                        sql = "SELECT [ItemCode] as '產品編號',[ItemName] as '產品名稱' FROM [OITM] WHERE [ItemCode] like '" + getItemCode + "%' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"
                    End If

                    If getItemName <> "" Then
                        sql = "SELECT [ItemCode] as '產品編號',[ItemName] as '產品名稱' FROM [OITM] WHERE [ItemName] like '%" + getItemName + "%' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"
                    End If
            End Select

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")

            DGVName.DataSource = ks1DataSet.Tables("DT1")
            DGVName.AutoResizeColumns()
            TransactionMonitor.Complete()
        End Using
        If DGVName.RowCount = 0 Then
            MsgBox("查無相關資料!請重新檢查查詢關鍵字!", 16, "錯誤")
            FinalSelectBtn.Enabled = False
            Exit Sub
        End If

    End Sub

    Private Sub FinalSelectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinalSelectBtn.Click

        If DGVName.CurrentRow.Cells("產品編號").Selected = False Then
            MsgBox("尚未選取資料!", 16, "錯誤")
            Exit Sub
        Else
            Select Case Source
                Case "ORDR"
                    A_ORDR.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    A_ORDR.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
                Case "Z_OQUT"
                    Z_OQUT.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    Z_OQUT.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
                Case "AddSchedule"
                    B_AddSchedule.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    B_AddSchedule.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
                Case "UpdateSchedule"
                    B_UpdateSchedule.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    B_UpdateSchedule.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
                Case "QueryODLN"
                    A_QueryODLN.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    A_QueryODLN.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
                Case "B_CalcBomNeeds"
                    B_CalcBomNeeds.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    B_CalcBomNeeds.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
                Case "OPOR"
                    E_QckAddOPOR.ItemCodeTxt.Text = DGVName.CurrentRow.Cells("產品編號").Value
                    E_QckAddOPOR.ItemNameTxt.Text = DGVName.CurrentRow.Cells("產品名稱").Value
            End Select
        End If

        Me.Close()
    End Sub

End Class