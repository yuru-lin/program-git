Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class UP2Mgn
    Dim DataAdapter As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub UP2Mgn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        locView.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
        locView.DataSource = dTable
        ' dispose used objects
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        setdgvDisplay()


    End Sub

    '設定dgvSourceMain顯示
    Private Sub setdgvDisplay()

        For Each column As DataGridViewColumn In locView.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "單別"

                Case "F2"
                    column.HeaderText = "單號"

                Case "F3"
                    column.HeaderText = "列號碼"

                Case "F4"
                    column.HeaderText = "存編"

                Case "F5"
                    column.HeaderText = "品名"

                Case "F6"
                    column.HeaderText = "公斤數"

                Case Else
                    column.Visible = False
            End Select
        Next
        locView.AutoResizeColumns()

        Label2.Text = locView.RowCount
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim sql As String
        'Dim DBConn As SqlConnection = Login.pFunction.ksDBConn
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        PBar1.Minimum = 0
        PBar1.Maximum = locView.Rows.Count - 1

        Try
            For i As Integer = 0 To locView.RowCount - 1

                Select Case locView.Rows(i).Cells("F1").FormattedValue
                    Case "收貨採購單"
                        sql = "update PDN1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM PDN1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "收貨單"
                        sql = "update IGN1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM IGN1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "發貨單"
                        sql = "update IGE1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM IGE1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "交貨單"
                        sql = "update DLN1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM DLN1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "銷售退回"
                        sql = "update RDN1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM RDN1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "AR貸項"
                        sql = "update RIN1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM RIN1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "採購退貨"
                        sql = "update RPC1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM RPC1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                    Case "AP貸項"
                        sql = "update PCH1 set U_p2 = '" & locView.Rows(i).Cells("F6").FormattedValue & "' FROM PCH1 T1 WHERE T1.DocEntry  = '" & locView.Rows(i).Cells("F2").FormattedValue & "' and T1.LineNum = '" & locView.Rows(i).Cells("F3").FormattedValue & "' and T1.Itemcode = '" & locView.Rows(i).Cells("F4").FormattedValue & "'"

                End Select

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

                PBar1.Value = i

            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新U_p2重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        End Try
        MsgBox("更新U_p2重量成功!", MsgBoxStyle.OkOnly, "成功")


    End Sub

    Private Sub locViewButAll()
        '--查詢類別程式
        '清空PDGV2內容
        If locView.RowCount > 0 Then
            ks1DataSet.Tables("TDT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "exec z_SPdataAll2 '" & dateDocDate.Value.Date & "' , '" & DocEntry. & "' "
            'IGN1 收貨單, IGE1 發貨單

            sql = " SELECT [DocEntry] AS '單號', [LineNum] AS '列號', [ItemCode] AS '存編', [Dscription] AS '品名', [U_p2] AS '重量' FROM [IGE1] WHERE [DocEntry] = '" & DocEntry.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapter = New SqlDataAdapter(sql, DBConn)
            DataAdapter.Fill(ks1DataSet, "TDT1")
            locView.DataSource = ks1DataSet.Tables("TDT1")
            TransactionMonitor.Complete()

            locView.Refresh()
            locView.AutoResizeColumns()

            locView.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            locView.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            locView.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub locViewButMdy()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        'Try
        '    For Each oRow As DataGridViewRow In locView.SelectedRows

        'sql = "UPDATE [Z_KS_Scheduling] SET [Cancel] = 'N' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & DGV1.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
        'sql = "UPDATE [Z_KS_Scheduling] SET [Cancel] = 'N' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & oRow.Cells("列號").Value & "' and [Cancel] = 'Y' "

        sql = " UPDATE [IGE1] SET [U_p2] = '" & U_p2.Text & "' WHERE [DocEntry] = '" & DocEntry.Text & "' AND [LineNum] = '" & LineNum.Text & "' AND [ItemCode] = '" & ItemCode.Text & "' "


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.Transaction = tran
        SQLCmd.ExecuteNonQuery()

        'Next

        tran.Commit()
        'Catch ex As Exception
        'tran.Rollback()
        'MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        'Exit Sub
        'End Try


    End Sub



    Private Sub locViewMdy_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles locView.CellClick
        '
        If locView.RowCount = -1 Then
            Exit Sub
        End If

        LineNum.Text = locView.CurrentRow.Cells("列號").Value
        ItemCode.Text = locView.CurrentRow.Cells("存編").Value
        Dscription.Text = locView.CurrentRow.Cells("品名").Value
        U_p2.Text = locView.CurrentRow.Cells("重量").Value

    End Sub

    Private Sub locViewMdy()

        locView.CurrentRow.Cells("列號").Value = LineNum.Text
        locView.CurrentRow.Cells("存編").Value = ItemCode.Text
        locView.CurrentRow.Cells("品名").Value = Dscription.Text
        locView.CurrentRow.Cells("重量").Value = U_p2.Text

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        locViewButAll()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        locViewButMdy()
        locViewButAll()

        LineNum.Text = ""
        ItemCode.Text = ""
        Dscription.Text = ""
        U_p2.Text = ""

        MsgBox("更新項目完成!", 64, "成功")

    End Sub
End Class