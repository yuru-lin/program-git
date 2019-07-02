Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_特殊入庫
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim dTable As DataTable = New DataTable()
    Dim SyncAns As Boolean
    Dim InType As String

    Private Sub C_特殊入庫_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        locView.ContextMenuStrip = MainForm.ContextMenuStrip1

        btnToB1.Enabled = False

        If Login.LoginType = 2 Then
            btnToB1.Enabled = False
        End If

        If Login.LogonUserName = "manager" Then
            btnForError.Visible = True
        End If

        cobSelectType.SelectedIndex = 0
    End Sub

    Private Sub cobSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSelectType.SelectedIndexChanged
        Select Case cobSelectType.SelectedIndex
            Case "0"
                InType = "8"
                Label12.Visible = True
            Case "1"
                InType = "2"
                Label12.Visible = False
                btnToB1.Enabled = True
            Case Else
                InType = "8"
                Label12.Visible = True
        End Select

        ClearAll()
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


        dataAdapter.Fill(dTable)

        locView.DataSource = dTable

        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        If InType = 8 Then
            joinAllTable()
        End If
        DGVDetail()
    End Sub

    Private Sub joinAllTable()

        Dim Q2 As Integer = 0
        PBar1.Minimum = 0
        PBar1.Maximum = locView.Rows.Count - 1

        If locView.Rows.Count > 0 Then
            For i As Integer = 0 To locView.RowCount - 1
                Select Case Microsoft.VisualBasic.Left(locView.Rows(i).Cells("F2").FormattedValue, 2)
                    Case "25"
                        locView.Rows(i).Cells("F2").Value = Replace(locView.Rows(i).Cells("F2").FormattedValue, Microsoft.VisualBasic.Left(locView.Rows(i).Cells("F2").FormattedValue, 2), "61", 1, 1)
                        locView.Rows(i).Cells("F5").Value = locView.Rows(i).Cells("F5").Value + "A"

                        Dim sql As String
                        Dim DBConn As SqlConnection = Login.DBConn
                        Dim SQLCmd As SqlCommand = New SqlCommand
                        Dim sqlReader1 As SqlDataReader

                        sql = "select T0.ItemCode from OITM T0 where T0.ItemCode = '" & locView.Rows(i).Cells("F2").Value & "'"

                        SQLCmd.Connection = DBConn
                        SQLCmd.CommandText = sql

                        sqlReader1 = SQLCmd.ExecuteReader
                        sqlReader1.Read()

                        If sqlReader1.HasRows() Then
                            locView.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                            sqlReader1.Close()
                        Else
                            Q2 = Q2 + 1
                            locView.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            sqlReader1.Close()
                        End If
                    Case "31"
                        locView.Rows(i).Cells("F2").Value = Replace(locView.Rows(i).Cells("F2").FormattedValue, Microsoft.VisualBasic.Left(locView.Rows(i).Cells("F2").FormattedValue, 2), "61", 1, 1)
                        locView.Rows(i).Cells("F5").Value = locView.Rows(i).Cells("F5").Value + "A"

                        Dim sql As String
                        Dim DBConn As SqlConnection = Login.DBConn
                        Dim SQLCmd As SqlCommand = New SqlCommand
                        Dim sqlReader1 As SqlDataReader

                        sql = "select T0.ItemCode from OITM T0 where T0.ItemCode = '" & locView.Rows(i).Cells("F2").Value & "'"

                        SQLCmd.Connection = DBConn
                        SQLCmd.CommandText = sql

                        sqlReader1 = SQLCmd.ExecuteReader
                        sqlReader1.Read()

                        If sqlReader1.HasRows() Then
                            locView.Rows(i).DefaultCellStyle.BackColor = Color.Green
                            sqlReader1.Close()
                        Else
                            Q2 = Q2 + 1
                            locView.Rows(i).DefaultCellStyle.BackColor = Color.Red
                            sqlReader1.Close()
                        End If
                    Case Else
                        'locView.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                        locView.Rows(i).DefaultCellStyle.BackColor = Color.SkyBlue

                        Q2 = Q2 + 1
                End Select
                PBar1.Value = i
            Next

            lb0.Text = locView.RowCount
            lb2.Text = Q2

            If Q2 = 0 Then
                btnToB1.Enabled = True
            End If
        End If
    End Sub

    Private Sub DGVDetail()
        For Each column As DataGridViewColumn In locView.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "製造單號"
                    column.DisplayIndex = 0
                Case "F2"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 1
                Case "F3"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 2
                Case "F4"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 3
                Case "F5"
                    column.HeaderText = "條碼"
                    column.DisplayIndex = 4
                Case "F6"
                    column.HeaderText = "製造日期"
                    column.DisplayIndex = 5
                Case "F7"
                    column.HeaderText = "有效日期"
                    column.DisplayIndex = 6
                Case "F8"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 7
                Case "F9"
                    column.HeaderText = "客戶代碼"
                    column.DisplayIndex = 8
                Case Else
                    column.Visible = False
            End Select
        Next
        locView.AutoResizeColumns()
        locView.Refresh()
        If locView.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If
    End Sub

    Private Sub btnToB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToB1.Click
        If locView.RowCount = 0 Then
            MsgBox("沒有任何條碼可以傳!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        If cobSelectType.SelectedIndex = 1 Then
            If U_CK02.Text = "" Then
                MsgBox("生產退料需填製造單號!", 48, "警告")
                Exit Sub
            End If
        End If
        PBar1.Minimum = 0
        PBar1.Maximum = locView.Rows.Count - 1
        SyncToSAP()
    End Sub

    Private Sub SyncToSAP()

        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim vDoc As SAPbobsCOM.Documents

        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)

        vDoc.UserFields.Fields.Item("U_CK02").Value = U_CK02.Text  '製單號
        vDoc.UserFields.Fields.Item("U_CK06").Value = InType
        vDoc.DocDate = DocDate.Value.Date

        For i As Integer = 0 To locView.RowCount - 1
            vDoc.Lines.SetCurrentLine(i)
            vDoc.Lines.ItemCode = locView.Rows(i).Cells("F2").Value '項目號碼
            vDoc.Lines.Quantity = 1
            If ckbWhs.Checked = True Then
                vDoc.Lines.WarehouseCode = tbxWhsCode.Text
            End If
            If IsDBNull(locView.Rows(i).Cells("F4").FormattedValue) Then
            Else
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = locView.Rows(i).Cells("F4").FormattedValue
            End If
            vDoc.Lines.SerialNumbers.SetCurrentLine(0)
            vDoc.Lines.SerialNumbers.InternalSerialNumber = locView.Rows(i).Cells("F5").Value '條碼
            vDoc.Lines.SerialNumbers.ManufactureDate = locView.Rows(i).Cells("F6").Value '實際製造日期 
            vDoc.Lines.SerialNumbers.ExpiryDate = locView.Rows(i).Cells("F7").Value '有效日期
            vDoc.Lines.SerialNumbers.Add()
            vDoc.Lines.Add()
            PBar1.Value = i
        Next

        RetVal = vDoc.Add

        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("製單轉入B1收貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        Else
            SyncSRN()
        End If

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        If SyncAns = True Then
            MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum, 64, "完成")
        Else
            MsgBox("資料已至B1收貨單!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "但是條碼重量未更新!!" & vbCrLf & "請洽資訊室協助更新!!", 16, "未完成")
        End If
        ClearAll()
    End Sub

    Private Sub SyncSRN()
        SyncAns = False
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            For i As Integer = 0 To locView.RowCount - 1
                sql = "Update OSRN set U_M8 = '" & locView.Rows(i).Cells("F1").FormattedValue & "',U_M1 = '" & locView.Rows(i).Cells("F4").FormattedValue & "', U_M2 = '" & locView.Rows(i).Cells("F8").FormattedValue & "', U_MC = '" & locView.Rows(i).Cells("F9").FormattedValue & "' where DistNumber = '" & locView.Rows(i).Cells("F5").Value & "'"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
                PBar1.Value = i
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Dim oAns As Integer
            oAns = MsgBox("是否要重新更新條碼重量?", 36, "警告")
            If oAns = MsgBoxResult.No Then
                SyncAns = False
                Exit Sub
            Else
                SyncSRN()
            End If
        End Try
        SyncAns = True
    End Sub

    Private Sub btnForError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForError.Click
        If locView.RowCount <= 0 Then
            Exit Sub
        End If

        SyncSRN()
        ClearAll()
    End Sub

    Private Sub ClearAll()
        If locView.RowCount > 0 Then
            dTable.Clear()
        End If
        DocDate.Value = Today
    End Sub
End Class