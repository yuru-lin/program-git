Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QueryOutside

    Private Sub B_QueryOutside_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDetail.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub ExcelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelBtn.Click
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
        'setdgvFI1MainDisplay()
        AnalyzeExcel()
    End Sub

    Private Sub AnalyzeExcel()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Dim dsPDAIn As New DataTable   

        Dim CK02 As DataColumn = New DataColumn("製單單號")
        CK02.DataType = System.Type.GetType("System.String")
        dsPDAIn.Columns.Add(CK02)

        Dim DocEntry As DataColumn = New DataColumn("草稿單號")
        DocEntry.DataType = System.Type.GetType("System.String")
        dsPDAIn.Columns.Add(DocEntry)

        Dim BarCode As DataColumn = New DataColumn("條碼")
        BarCode.DataType = System.Type.GetType("System.String")
        dsPDAIn.Columns.Add(BarCode)

        Dim ICode As DataColumn = New DataColumn("存編")
        ICode.DataType = System.Type.GetType("System.String")
        dsPDAIn.Columns.Add(ICode)

        Dim IName As DataColumn = New DataColumn("品名")
        IName.DataType = System.Type.GetType("System.String")
        dsPDAIn.Columns.Add(IName)


        Try
            For i As Integer = 0 To dgvExcel.RowCount - 1
                sql = "select T0.DistNumber , T0.ItemCode ,T1.ItemName From OSRN T0 left join OITM T1 ON T0.ItemCode = T1.ItemCode Where T0.DistNumber = '" & dgvExcel.Rows(i).Cells("F2").Value & "'"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                sqlReader = SQLCmd.ExecuteReader
                sqlReader.Read()

                If sqlReader.HasRows() Then

                    Dim Row(i) As DataRow
                    Row(i) = dsPDAIn.NewRow
                    Row(i).Item("製單單號") = dgvExcel.Rows(i).Cells("F1").FormattedValue
                    Row(i).Item("草稿單號") = dgvExcel.Rows(i).Cells("F3").FormattedValue
                    Row(i).Item("條碼") = dgvExcel.Rows(i).Cells("F2").FormattedValue
                    Row(i).Item("存編") = sqlReader.Item("ItemCode")
                    Row(i).Item("品名") = sqlReader.Item("ItemName")
                    dsPDAIn.Rows.Add(Row(i))

                    sqlReader.Close()
                Else
                    sqlReader.Close()
                End If
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("AnalyzeExcel失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        dgvDetail.DataSource = dsPDAIn
        dgvDetail.AutoResizeColumns()
        Label2.Text = dgvExcel.RowCount & "筆"
    End Sub

   
End Class