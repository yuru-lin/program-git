Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class SelectName
    Public getCardName As String
    Public getCardCode As String   
    Public Source As String

    Private Sub SelectName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Case "AddSchedule"
                    sql = "SELECT [CardCode] as '客戶編號',[CardName] as '客戶名稱',[AddID] as '簡稱' ,[QryGroup7] as '電宰客戶', [QryGroup8] as '代工客戶'  FROM [OCRD] WHERE [CardType] = 'C' and ([QryGroup7] = 'Y' OR [QryGroup8] = 'Y') and [CardName] like '%" + getCardName + "%'"
                Case "E_PaymentForm", "OPOR"
                    sql = "SELECT [CardCode] as '客戶編號',[CardName] as '客戶名稱',[AddID] as '簡稱' FROM [OCRD] WHERE [CardType] = 'S' and [CardName] like '%" + getCardName + "%'"
                Case Else
                    sql = "SELECT [CardCode] as '客戶編號',[CardName] as '客戶名稱',[AddID] as '簡稱' FROM [OCRD] WHERE [CardType] = 'C' and [CardName] like '%" + getCardName + "%'"
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

        If DGVName.CurrentRow.Cells("客戶編號").Selected = False Then
            MsgBox("尚未選取資料!", 16, "錯誤")
            Exit Sub
        Else
            Select Case Source
                Case "ORDR"
                    A_ORDR.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    A_ORDR.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "A_營業_訂單輸入"
                    A_營業_訂單輸入.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    A_營業_訂單輸入.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "Z_OQUT"
                    Z_OQUT.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    Z_OQUT.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "AddSchedule"
                    B_AddSchedule.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    B_AddSchedule.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "UpdateSchedule"
                    B_UpdateSchedule.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    B_UpdateSchedule.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "QueryODLN"
                    A_QueryODLN.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    A_QueryODLN.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "E_PaymentForm"
                    E_PaymentForm.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    E_PaymentForm.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
                Case "OPOR"
                    E_QckAddOPOR.CardCode.Text = DGVName.CurrentRow.Cells("客戶編號").Value
                    E_QckAddOPOR.CardName.Text = DGVName.CurrentRow.Cells("客戶名稱").Value
            End Select
        End If

        Me.Close()
    End Sub

End Class