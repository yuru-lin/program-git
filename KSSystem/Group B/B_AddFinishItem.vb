Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_AddFinishItem

    Private Sub B_AddFinishItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvFI1Main.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvFinishItem1.ContextMenuStrip = MainForm.ContextMenuStrip1
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
        Dim strSQL2 As String = "SELECT * FROM [Sheet2$]"
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dbCommand2 As OleDbCommand = New OleDbCommand(strSQL2, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)
        Dim dataAdapter2 As OleDbDataAdapter = New OleDbDataAdapter(dbCommand2)

        ' create data table
        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

        Dim dTable2 As DataTable = New DataTable()
        dataAdapter2.Fill(dTable2)

        ' bind the datasource
        'dataBingingSrc.DataSource = dTable
        ' assign the dataBindingSrc to the DataGridView
        'DataGridView1.DataSource = dataBingingSrc
        dgvFI1Main.DataSource = dTable
        dgvFinishItem1.DataSource = dTable2
        ' dispose used objects
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()

        dTable2.Dispose()
        dataAdapter2.Dispose()
        dbCommand2.Dispose()

        excelConnection.Close()
        excelConnection.Dispose()
        setdgvFI1MainDisplay()
        setdgvFinishItem1Display()
    End Sub

    Private Sub setdgvFI1MainDisplay()
        For Each column As DataGridViewColumn In dgvFI1Main.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "生產單號"
                Case "F2"
                    column.HeaderText = "製單號"
                Case "F3"
                    column.HeaderText = "狀態"
                Case "F4"
                    column.HeaderText = "生產單列印"
                Case "F5"
                    column.HeaderText = "文件日期"
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvFI1Main.AutoResizeColumns()
    End Sub

    Private Sub setdgvFinishItem1Display()
        For Each column As DataGridViewColumn In dgvFinishItem1.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "生產單號"
                Case "F2"
                    column.HeaderText = "製單號"
                Case "F3"
                    column.HeaderText = "狀態"
                Case "F4"
                    column.HeaderText = "生產單列印"
                Case "F5"
                    column.HeaderText = "文件日期"
                Case "F6"
                    column.HeaderText = "條碼"
                Case "F7"
                    column.HeaderText = "存貨編號"
                Case "F8"
                    column.HeaderText = "品名"
                Case "F9"
                    column.HeaderText = "實際製造日期"
                Case "F10"
                    column.HeaderText = "標示製造日期"
                Case "F11"
                    column.HeaderText = "有效日期"
                Case "F12"
                    column.HeaderText = "存貨/代工"
                Case "F13"
                    column.HeaderText = "冷凍/冷藏"
                Case "F14"
                    column.HeaderText = "類別"
                Case "F15"
                    column.HeaderText = "保存天數"
                Case "F16"
                    column.HeaderText = "包裝方式"
                Case "F17"
                    column.HeaderText = "隻數"
                Case "F18"
                    column.HeaderText = "重量"
                Case "F19"
                    column.HeaderText = "客戶代碼"
                Case "F20"
                    column.HeaderText = "印製造日期"
                Case "F21"
                    column.HeaderText = "印製造日期"
                Case "F22"
                    column.HeaderText = "印定重品"
                Case "F23"
                    column.HeaderText = "單位"
                Case "F24"
                    column.HeaderText = "作業人員"
                Case "F25"
                    column.HeaderText = "註記作廢人員"
                Case "F26"
                    column.HeaderText = "取消/確認作廢人員"
                Case "F27"
                    column.HeaderText = "標簽列印名稱"
                Case "F28"
                    column.HeaderText = "客戶簡稱"
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvFinishItem1.AutoResizeColumns()
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If dgvFI1Main.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If
        If dgvFinishItem1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增至資料庫 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            AddToFI1Main()            
        End If


    End Sub

    Private Sub AddToFI1Main()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()        

        Try
            For i As Integer = 0 To dgvFI1Main.RowCount - 1
                sql = "INSERT INTO [@FI1Main] VALUES " & "('" & dgvFI1Main.Rows(i).Cells("F1").Value & "', '" & dgvFI1Main.Rows(i).Cells("F2").Value & "', '3', '" & dgvFI1Main.Rows(i).Cells("F4").Value & "', '" & dgvFI1Main.Rows(i).Cells("F5").Value & "')"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            For i As Integer = 0 To dgvFinishItem1.RowCount - 1
                sql = "INSERT INTO [@FinishItem1] VALUES " & "('" & dgvFinishItem1.Rows(i).Cells("F1").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F2").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F3").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F4").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F5").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F6").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F7").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F8").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F9").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F10").Value & "', '" & dgvFinishItem1.Rows(i).Cells("F11").Value & "','" & dgvFinishItem1.Rows(i).Cells("F12").Value & "','" & dgvFinishItem1.Rows(i).Cells("F13").Value & "','" & dgvFinishItem1.Rows(i).Cells("F14").Value & "','" & dgvFinishItem1.Rows(i).Cells("F15").Value & "','" & dgvFinishItem1.Rows(i).Cells("F16").Value & "','" & dgvFinishItem1.Rows(i).Cells("F17").Value & "','" & dgvFinishItem1.Rows(i).Cells("F18").Value & "','" & dgvFinishItem1.Rows(i).Cells("F19").Value & "','" & dgvFinishItem1.Rows(i).Cells("F20").Value & "','" & dgvFinishItem1.Rows(i).Cells("F21").Value & "','" & dgvFinishItem1.Rows(i).Cells("F22").Value & "','" & dgvFinishItem1.Rows(i).Cells("F23").Value & "','" & dgvFinishItem1.Rows(i).Cells("F24").Value & "','" & dgvFinishItem1.Rows(i).Cells("F25").Value & "','" & dgvFinishItem1.Rows(i).Cells("F26").Value & "','" & dgvFinishItem1.Rows(i).Cells("F27").Value & "','" & dgvFinishItem1.Rows(i).Cells("F28").Value & "')"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("新增至資料庫已確認完成!", 64, "成功")
    End Sub

   
End Class