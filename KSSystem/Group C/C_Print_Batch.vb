Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_Print_Batch

    Dim PrinterName As String

    Private Declare Sub openport Lib "tsclib.dll" (ByVal PrinterName As String)
    Private Declare Sub closeport Lib "tsclib.dll" ()
    Private Declare Sub sendcommand Lib "tsclib.dll" (ByVal command_Renamed As String)
    Private Declare Sub setup Lib "tsclib.dll" (ByVal LabelWidth As String, ByVal LabelHeight As String, ByVal Speed As String, ByVal Density As String, ByVal Sensor As String, ByVal Vertical As String, ByVal Offset As String)
    Private Declare Sub downloadpcx Lib "tsclib.dll" (ByVal Filename As String, ByVal ImageName As String)
    Private Declare Sub barcode Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal CodeType As String, ByVal Height_Renamed As String, ByVal Readable As String, ByVal rotation As String, ByVal Narrow As String, ByVal Wide As String, ByVal Code As String)
    Private Declare Sub printerfont Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal FontName As String, ByVal rotation As String, ByVal Xmul As String, ByVal Ymul As String, ByVal Content As String)
    Private Declare Sub clearbuffer Lib "tsclib.dll" ()
    Private Declare Sub printlabel Lib "tsclib.dll" (ByVal NumberOfSet As String, ByVal NumberOfCopy As String)
    Private Declare Sub formfeed Lib "tsclib.dll" ()
    Private Declare Sub nobackfeed Lib "tsclib.dll" ()
    Private Declare Sub windowsfont Lib "tsclib.dll" (ByVal X As Short, ByVal Y As Short, ByVal fontheight_Renamed As Short, ByVal rotation As Short, ByVal fontstyle As Short, ByVal fontunderline As Short, ByVal FaceName As String, ByVal TextContent As String)

    Dim dsPDAIn As New DataSet
    Dim ks1DataSet As DataSet = New DataSet

    Structure LabeData1  '電宰標籤
        Dim PQty As Integer
        Dim Itemname As String
        Dim Barcode As String
        Dim Weight As String
        Dim Qty As String
        Dim Unit As String
        Dim MDate As String
        Dim DDate As String
    End Structure

    Structure LabeData2  '加工標籤
        Dim PntQty As Integer
        Dim Itemname As String
        Dim Barcode As String
        Dim Qty As String
        Dim Unit As String
        Dim MDate As String
        Dim DDate As String
    End Structure

    Private Sub C_Print_Batch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvFromExcel.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
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

        dataAdapter.Fill(ks1DataSet, "DT0")
        dgvFromExcel.DataSource = ks1DataSet.Tables("DT0")

        ' dispose used objects
        ks1DataSet.Tables("DT0").Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        setdgvDisplay()
        LoadSourceMain()
        setdgvSourceMainDisplay()

    End Sub


    '依作業類別載入欲入庫製單號, 並指派給dgvSourceMain
    Private Sub LoadSourceMain()
        Dim DataAdapter1 As SqlDataAdapter

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn

        For i As Integer = 0 To dgvFromExcel.RowCount - 1
            Try
                If rb01.Checked = True Then
                    sql = "SELECT OSRN.DistNumber, OITM.FrgnName, OSRN.U_M1, OITM.SalPackUn, OITM.SalPackMsr FROM OSRN INNER JOIN OITM ON OSRN.ItemCode = OITM.ItemCode where OSRN.DistNumber = '" & dgvFromExcel.Rows(i).Cells("F1").FormattedValue & "'"
                Else
                    sql = "SELECT OITM.FrgnName, OIBT.BatchNum, OIBT.Quantity, OITM.SalUnitMsr FROM OITM INNER JOIN OIBT ON OITM.ItemCode = OIBT.ItemCode where OIBT.BatchNum='" & dgvFromExcel.Rows(i).Cells("F1").FormattedValue & "'"
                End If

                DataAdapter1 = New SqlDataAdapter(sql, DBConn)
                DataAdapter1.Fill(ks1DataSet, "DT1")
                dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")
            Catch ex As Exception
                MsgBox("LoadSourceMain: " & ex.Message)
                End
            End Try
        Next
    End Sub

    '設定dgvSourceMain顯示
    Private Sub setdgvSourceMainDisplay()

        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True

            Select Case rb01.Checked
                Case "True"
                    Select Case column.Name
                        Case "DistNumber"
                            column.HeaderText = "條碼"
                            column.DisplayIndex = 0
                        Case "FrgnName"
                            column.HeaderText = "品名"
                            column.DisplayIndex = 1
                        Case "U_M1"
                            column.HeaderText = "重量"
                            column.DisplayIndex = 2
                        Case "SalPackUn"
                            column.HeaderText = "數量"
                            column.DisplayIndex = 3
                        Case "SalPackMsr"
                            column.HeaderText = "單位"
                            column.DisplayIndex = 4
                        Case Else
                            column.Visible = False
                    End Select
                Case "False"
                    Select Case column.Name
                        Case "BatchNum"
                            column.HeaderText = "條碼"
                            column.DisplayIndex = 0
                        Case "FrgnName"
                            column.HeaderText = "品名"
                            column.DisplayIndex = 1
                        Case "Quantity"
                            column.HeaderText = "數量"
                            column.DisplayIndex = 2
                        Case "SalUnitMsr"
                            column.HeaderText = "單位"
                            column.DisplayIndex = 3
                        Case Else
                            column.Visible = False
                    End Select
            End Select

        Next
        dgvSourceMain.AutoResizeColumns()

    End Sub
    '設定dgvSourceMain顯示
    Private Sub setdgvDisplay()

        For Each column As DataGridViewColumn In dgvFromExcel.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "條碼"
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvFromExcel.AutoResizeColumns()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Dim dtPDAIn As DataTable = dsPDAIn.Tables("DBPDAIn")

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrinterName = PrintDialog1.PrinterSettings.PrinterName
        End If

        '1.將PDA資料同步至資料庫, 並進行必要資料更新
        '因為最後會多一個空的所以-2
        For i As Integer = 0 To dgvSourceMain.RowCount - 1

            Select Case rb01.Checked
                Case "True"
                    Dim olabel As LabeData1 = New LabeData1
                    Dim SalPackUn As Integer = dgvSourceMain.Rows(i).Cells("SalPackUn").Value
                    With olabel

                        .PQty = 1
                        .Itemname = dgvSourceMain.Rows(i).Cells("FrgnName").Value
                        .Barcode = dgvSourceMain.Rows(i).Cells("DistNumber").Value
                        .Weight = dgvSourceMain.Rows(i).Cells("U_M1").Value & "Kg"
                        .Qty = SalPackUn & dgvSourceMain.Rows(i).Cells("SalPackMsr").Value

                        If ckbMDate.Checked = True Then
                            .MDate = "製造日期：" & MDate.Value.Date
                        Else
                            .MDate = ""
                        End If

                        If ckbDDate.Checked = True Then
                            .DDate = "有效日期：" & DDate.Value.Date
                        Else
                            .DDate = ""
                        End If

                    End With
                    SentToPrinter1(olabel)
                Case "False"
                    Dim olabel As LabeData2 = New LabeData2
                    Dim Quantity As Integer = dgvSourceMain.Rows(i).Cells("Quantity").Value
                    With olabel

                        .PntQty = 1
                        .Itemname = dgvSourceMain.Rows(i).Cells("FrgnName").Value
                        .Barcode = dgvSourceMain.Rows(i).Cells("BatchNum").Value
                        .Qty = Quantity
                        .Unit = dgvSourceMain.Rows(i).Cells("SalUnitMsr").Value

                        If ckbMDate.Checked = True Then
                            .MDate = "製造日期：" & MDate.Value.Date
                        Else
                            .MDate = ""
                        End If

                        If ckbDDate.Checked = True Then
                            .DDate = "有效日期：" & DDate.Value.Date
                        Else
                            .DDate = ""
                        End If

                    End With
                    SentToPrinter2(olabel)
            End Select

        Next

        MsgBox("條碼列印完畢!")

    End Sub

    Private Sub rb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb01.CheckedChanged
        If dgvFromExcel.RowCount > 0 Then
            ks1DataSet.Tables("DT0").Clear()
        End If

        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If
    End Sub

    '驅動列印電宰標籤
    Private Sub SentToPrinter1(ByVal olabel As LabeData1)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = ""
            Dim Itemname2 As String = ""
            Dim Counter As Integer = 0

            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then
                    Itemname1 = Itemname1 & Chr
                Else
                    Itemname2 = Itemname2 & Chr
                End If
            Next

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1)
            '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "135", "128", "50", "1", "0", "3", "3", olabel.Barcode)
        '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        'Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode)


        '3.重量 
        Call windowsfont(44, 210, 40, 0, 2, 0, "新細明體", olabel.Weight)
        '4.數量
        Call windowsfont(290, 185, 70, 0, 2, 0, "新細明體", olabel.Qty)
        '5.製造日期
        If olabel.MDate = "" Then

        Else
            Call windowsfont(45, 250, 25, 0, 2, 0, "新細明體", olabel.MDate)
        End If
        '6.有效日期
        If olabel.DDate = "" Then

        Else
            Call windowsfont(45, 275, 25, 0, 2, 0, "新細明體", olabel.DDate)
        End If

        '定義列印張數
        Call printlabel("1", olabel.PQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub

    '驅動列印加工標籤
    Private Sub SentToPrinter2(ByVal olabel As LabeData2)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = ""
            Dim Itemname2 As String = ""
            Dim Counter As Integer = 0

            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then
                    Itemname1 = Itemname1 & Chr
                Else
                    Itemname2 = Itemname2 & Chr
                End If
            Next

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1)
            '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "135", "128", "50", "1", "0", "3", "3", olabel.Barcode)
        '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        'Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode)

        '4.數量
        Call windowsfont(290, 185, 70, 0, 2, 0, "新細明體", olabel.Qty)
        '5.有效日期
        If olabel.MDate = "" Then

        Else
            Call windowsfont(45, 250, 25, 0, 2, 0, "新細明體", olabel.MDate)
        End If
        '6.製造日期
        If olabel.DDate = "" Then

        Else
            Call windowsfont(45, 275, 25, 0, 2, 0, "新細明體", olabel.DDate)
        End If

        '定義列印張數
        Call printlabel("1", olabel.PntQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged
        DateChange()
    End Sub

    Private Sub RB2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB2.CheckedChanged
        DateChange()
    End Sub

    Private Sub RB3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB3.CheckedChanged
        DateChange()
    End Sub

    Private Sub DateChange()
        If RB1.Checked = True Then
            DDate.Value = Today
        End If

        If RB2.Checked = True Then
            DDate.Value = Today
            DDate.Value = DDate.Value.Date.AddDays(5)
        End If

        If RB3.Checked = True Then
            DDate.Value = Today
            DDate.Value = DDate.Value.Date.AddDays(6)
        End If
    End Sub
End Class