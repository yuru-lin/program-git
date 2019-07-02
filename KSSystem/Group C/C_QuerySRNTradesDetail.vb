Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class C_QuerySRNTradesDetail

    Private Sub C_QuerySRNTradesDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDetail.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub btnReadExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadExcel.Click
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "Excel files(*.xls)|*.xls"    '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        ' if you don't want to sho the header row (first row) in the grid
        ' use 'HDR=NO' in the string

        Dim strSQL As String = "SELECT * FROM [Sheet1$]"
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        ' create data table
        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

        ' bind the datasource
        'dataBingingSrc.DataSource = dTable
        ' assign the dataBindingSrc to the DataGridView
        'DataGridView1.DataSource = dataBingingSrc
        dgvExcel.DataSource = dTable
        ' dispose used objects
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()

        joinAllTable()
    End Sub

    Private Sub joinAllTable()
        If dgvExcel.Rows.Count < 0 Then
            MsgBox("無資料", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter
        Dim ks1DataSetDGV As DataSet = New DataSet

        PBar1.Minimum = 0
        PBar1.Maximum = dgvExcel.Rows.Count - 1
        For i As Integer = 0 To dgvExcel.RowCount - 1
            sql = "exec L2011110201 '" & dgvExcel.Rows(i).Cells("F1").FormattedValue & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            dgvDetail.DataSource = ks1DataSetDGV.Tables("DT1")
            PBar1.Value = i
        Next

        dgvDetail.AutoResizeColumns()
        Label2.Text = dgvDetail.RowCount

    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        DataToExcel(dgvDetail, "")
    End Sub
    
End Class