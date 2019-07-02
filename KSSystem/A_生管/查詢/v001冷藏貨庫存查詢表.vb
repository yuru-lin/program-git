Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Drawing.Printing

Public Class v001冷藏貨庫存查詢表

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub v001冷藏貨庫存查詢表_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub GetDGV1Data()  '取得DGV1資料

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Using TransactionMonitor As New System.Transactions.TransactionScope

        sql = " EXEC [dbo].[預_冷藏貨庫存表] '" & 日期1.Value.Date & "' , '" & 日期2.Value.Date & "' , '" & 品名1.Text & "' , '" & 品名2.Text & "' , '" & 品名3.Text & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        'TransactionMonitor.Complete()
        'End Using

        DGV1Display()

    End Sub

    Private Sub DGV1Display()  '載入DGV1資料畫面

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1
                Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 2
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3
                Case "製造日期" : column.HeaderText = "製造日期" : column.DisplayIndex = 4
                Case "未入庫數量" : column.HeaderText = "未入庫數量" : column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub PrintReport()

        Z_ReportViewer.MdiParent = MainForm
        Z_ReportViewer.Source = "冷藏貨庫存表"
        Z_ReportViewer.strPara(0) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("製造日期").ToString()
        Z_ReportViewer.strPara(1) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("製造日期").ToString()

        Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT_Print")
        Z_ReportViewer.Show()

    End Sub

    Private Sub 列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印.Click

        If Not ks1DataSetDGV.Tables("DT_Print") Is Nothing Then
            ks1DataSetDGV.Tables("DT_Print").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Using TransactionMonitor As New System.Transactions.TransactionScope

        sql = " EXEC [dbo].[預_冷藏貨庫存表] '" & 日期1.Value.Date & "' , '" & 日期2.Value.Date & "' , '" & 品名1.Text & "' , '" & 品名2.Text & "' , '" & 品名3.Text & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT_Print")
        'TransactionMonitor.Complete()
        'End Using

        PrintReport()

    End Sub

    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click

        DataToExcel(DGV1, "")

    End Sub
End Class