Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QckAddOIGE
    Dim StrComment, StrCK02, StrCK01 As String
    Dim dTable As DataTable = New DataTable()

    Private Sub B_QckAddOIGE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        TaxDate.Value = DocDate.Value.Date.AddDays(1)
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
    End Sub

    Private Sub ProductType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductType.SelectedIndexChanged
        SelectExcel()
    End Sub

    Private Sub SelectExcel()
        If DGV1.RowCount > 0 Then
            dTable.Clear()
        End If

        Dim openfile As String

        If ProductType.SelectedIndex = 7 Then
            Dim openfileDg As New OpenFileDialog()
            openfileDg.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
            openfileDg.Filter = "Excel files(*.xls)|*.xls"    '只抓excel檔   
            openfileDg.ShowDialog()

            If openfileDg.FileName = "" Then
                Exit Sub
            End If
            openfile = openfileDg.FileName

        Else
            openfile = Application.StartupPath & "\QuickOIGE.xls"
            '"D:\KSSystem\凱馨外掛系統\QuickOIGE.xls"
            'Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Application.StartupPath & "\ks.dat")
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        ' if you don't want to sho the header row (first row) in the grid
        ' use 'HDR=NO' in the string

        Dim strSQL As String

        Select Case ProductType.SelectedIndex
            Case 0
                strSQL = "SELECT * FROM [Sheet1$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單1-全領"
                StrCK01 = "5"
                StrCK02 = "2" + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case 1
                strSQL = "SELECT * FROM [Sheet2$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單2-前五項全領.其超市用*"
                StrCK01 = "5"
                StrCK02 = "2" + Format(TaxDate.Value.Date, "yyMMdd") + "002"
            Case 2
                strSQL = "SELECT * FROM [Sheet3$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單3-前兩項全領.其超市用*"
                StrCK01 = "5"
                StrCK02 = "2" + Format(TaxDate.Value.Date, "yyMMdd") + "003"
            Case 3
                strSQL = "SELECT * FROM [Sheet4$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單4-全領(凍可)"
                StrCK01 = "5"
                StrCK02 = "3" + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case 4
                strSQL = "SELECT * FROM [Sheet5$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單5-全領(凍可)"
                StrCK01 = "5"
                StrCK02 = "3" + Format(TaxDate.Value.Date, "yyMMdd") + "002"
            Case 5
                strSQL = "SELECT * FROM [Sheet6$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單6-好市多*"
                StrCK01 = "5"
                StrCK02 = "2" + Format(TaxDate.Value.Date, "yyMMdd") + "002"
            Case 6
                strSQL = "SELECT * FROM [Sheet7$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "委外領料單"
                StrCK01 = "11"
                StrCK02 = "D" + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case 7
                strSQL = "SELECT * FROM [Sheet1$]"
                StrCK01 = "5"
                StrCK02 = ""
            Case 8
                strSQL = "SELECT * FROM [Sheet8$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單-好市多*"
                StrCK01 = "5"
                StrCK02 = "3" + Format(TaxDate.Value.Date, "yyMMdd") + "003"
            Case 9
                strSQL = "SELECT * FROM [Sheet9$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單-廣之鄕*"
                StrCK01 = "5"
                StrCK02 = "2" + Format(TaxDate.Value.Date, "yyMMdd") + "002"
            Case 10
                strSQL = "SELECT * FROM [Sheet10$]"
                StrComment = Format(TaxDate.Value.Date, "M/d") + "預領單-超市用*"
                StrCK01 = "5"
                StrCK02 = "2" + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case -1
                ClearAll()
                Exit Sub
        End Select

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

        dataAdapter.Fill(dTable)

        ' bind the datasource
        'dataBingingSrc.DataSource = dTable
        ' assign the dataBindingSrc to the DataGridView
        'DataGridView1.DataSource = dataBingingSrc
        DGV1.DataSource = dTable
        ' dispose used objects
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        setdgvDisplay()
    End Sub

    Private Sub setdgvDisplay()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "存編"
                    column.ReadOnly = True
                Case "F2"
                    column.HeaderText = "品名"
                    column.ReadOnly = True
                Case "F3"
                    column.HeaderText = "數量"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        CK02.Text = StrCK02
        Comm.Text = StrComment

    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim Cnt As Integer = 0
        For j As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(j).Cells("F3").Value > 0 Then
                Cnt = Cnt + 1
            End If
        Next

        If Cnt = 0 Then
            MsgBox("數量全為0!", 16, "錯誤")
            Exit Sub
        End If

        If CK02.Text = "" Then
            MsgBox("製單編號未填!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oDraft As SAPbobsCOM.Documents
        Dim X As Integer = 0
        Dim RetVal As Long

        oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)

        oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oInventoryGenExit
        oDraft.DocDate = DocDate.Value.Date
        oDraft.TaxDate = TaxDate.Value.Date
        oDraft.UserFields.Fields.Item("U_CK01").Value = StrCK01
        oDraft.UserFields.Fields.Item("U_CK02").Value = CK02.Text
        oDraft.Comments = Comm.Text

        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("F3").Value > 0 Then
                oDraft.Lines.SetCurrentLine(X)
                oDraft.Lines.ItemCode = DGV1.Rows(i).Cells("F1").FormattedValue   '項目號碼
                oDraft.Lines.Quantity = DGV1.Rows(i).Cells("F3").FormattedValue
                oDraft.Lines.Add()
                X = X + 1
            End If

        Next
        RetVal = oDraft.Add()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        Dim OQUTDocNum As Integer
        OQUTDocNum = Login.oCompany.GetNewObjectKey()
        MsgBox("新增至B1完成!!" + vbCrLf + "草稿單號：" & OQUTDocNum, 64, "完成")
        ClearAll()
    End Sub

    Private Sub ClearAll()
        ProductType.SelectedIndex = -1
        CK02.Text = ""
        Comm.Text = ""        
        DocDate.Value = Today
        TaxDate.Value = DocDate.Value.Date.AddDays(1)
        If DGV1.RowCount > 0 Then
            dTable.Clear()
        End If
    End Sub

    
End Class