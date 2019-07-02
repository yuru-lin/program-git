Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms

Public Class FdCkReportView
    '=====================================連線======================================
    Public strPara(50) As String
    Dim ds_Settle As New DataSet
    Dim adapter As SqlDataAdapter
    Dim changes As DataSet
    Dim sql As String
    Dim i As Int32
    Dim cmdBuilder As SqlCommandBuilder

    Private Sub FdCkReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '==================================契養報表列印開始==========================================
        'Dim connection As SqlConnection = pFunction.ksPlugDBConn
        Dim connection As SqlConnection = Login.DBConn
        Dim DataAdapterDGV As SqlDataAdapter
        Dim ks1DataSetDGV As DataSet = New DataSet
        Dim SeaialID As String
        SeaialID = FdCkSettle.FD10.Text
       
        Dim sql As String
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "Select * from [KaiShingPlug].[dbo].[V_FdCk] where SerialID = '" + SeaialID + "'"
            SQLCmd.Connection = connection
            SQLCmd.CommandText = sql
            DataAdapterDGV = New SqlDataAdapter(sql, connection)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            TransactionMonitor.Complete()
            ReportViewer1.LocalReport.DataSources(0).Value = ks1DataSetDGV.Tables("DT1")
            ReportViewer1.RefreshReport()
        End Using
        'Exit Sub
        connection.Close()

    End Sub
End Class
