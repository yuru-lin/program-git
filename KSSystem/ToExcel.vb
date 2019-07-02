Imports System
Imports System.IO
Imports System.Data


Module ToExcel

    Public Sub CopyDGV(ByVal m_DataView As DataGridView)
        m_DataView.Select()
        Dim dataObj As DataObject = m_DataView.GetClipboardContent()
        Clipboard.SetDataObject(dataObj, True)
        m_DataView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
    End Sub

    Public Sub DataToExcel(ByVal m_DataView As DataGridView, ByVal oFileName As String)
        Dim kk As New SaveFileDialog()
        kk.Title = "儲存EXECL文件"
        kk.Filter = "EXECL文件(*.xls) |*.xls |文字檔(Tab 字元分隔)(*.txt) |*.txt |複製成EXECL文件(*.xls) |*.xls "
        kk.FilterIndex = 1
        kk.FileName = oFileName
        If kk.ShowDialog() = DialogResult.OK Then
            Dim FileName As String = kk.FileName ' + ".xls"
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If

            Select Case kk.FilterIndex
                Case "1"
                    Excel(m_DataView, FileName)
                Case "2"
                    Text(m_DataView, FileName)
                Case "3"
                    CopyToExcel(m_DataView, FileName)
            End Select

        End If
    End Sub

    'Public Sub DataToExcel(ByVal m_DataView As DataGridView, ByVal oFileName As String)
    '    Dim kk As New SaveFileDialog()
    '    kk.Title = "儲存EXECL文件"
    '    kk.Filter = "EXECL文件(*.xls) |*.xls |文字檔(Tab 字元分隔)(*.txt) |*.txt |複製成EXECL文件(*.xls) |*.xls "
    '    kk.FilterIndex = 1
    '    kk.FileName = oFileName
    '    If kk.ShowDialog() = DialogResult.OK Then
    '        Dim FileName As String = kk.FileName ' + ".xls"
    '        If File.Exists(FileName) Then
    '            File.Delete(FileName)
    '        End If

    '        Select Case kk.FilterIndex
    '            Case "1"
    '                Excel(m_DataView, FileName)
    '            Case "2"
    '                Text(m_DataView, FileName)
    '            Case "3"
    '                CopyToExcel(m_DataView, FileName)
    '        End Select

    '    End If
    'End Sub

    Private Sub Excel(ByVal m_DataView As DataGridView, ByVal FileName As String)

        Dim myExcel, myBook, myWorksheet As Object
        On Error Resume Next
        myExcel = CreateObject("Excel.Application")
        If Err.Number() <> 0 Then : MsgBox("電腦沒有安裝Excel") : Exit Sub : End If
        myBook = myExcel.Workbooks.add
        myWorksheet = myBook.worksheets(1)
        myExcel.Visible = False
        myWorksheet.Columns.NumberFormat = "@"

        For k As Integer = 0 To m_DataView.Columns.Count - 1
            If m_DataView.Columns(k).Visible = True Then
                myWorksheet.Cells(1, k + 1).value = m_DataView.Columns(k).HeaderText.ToString()
            End If
        Next

        For i As Integer = 1 To m_DataView.Rows.Count
            For j As Integer = 1 To m_DataView.Columns.Count
                myWorksheet.Cells(i + 1, j).value = m_DataView.Rows(i - 1).Cells(j - 1).FormattedValue.ToString()
            Next
        Next

        myExcel.ActiveWorkbook.SaveAs(FileName)
        myExcel.Quit()
        myExcel = Nothing
        MessageBox.Show("儲存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    'Private Sub Excel(ByVal m_DataView As DataGridView, ByVal FileName As String)

    '    Dim myExcel, myBook, myWorksheet As Object
    '    On Error Resume Next
    '    myExcel = CreateObject("Excel.Application")
    '    If Err.Number() <> 0 Then
    '        MsgBox("電腦沒有安裝Excel")
    '        Exit Sub
    '    End If
    '    myBook = myExcel.Workbooks.add
    '    myWorksheet = myBook.worksheets(1)
    '    myExcel.Visible = False
    '    myWorksheet.Columns.NumberFormat = "@"

    '    For k As Integer = 0 To m_DataView.Columns.Count - 1
    '        If m_DataView.Columns(k).Visible = True Then
    '            myWorksheet.Cells(1, k + 1).value = m_DataView.Columns(k).HeaderText.ToString()
    '        End If
    '    Next

    '    For i As Integer = 1 To m_DataView.Rows.Count
    '        For j As Integer = 1 To m_DataView.Columns.Count
    '            myWorksheet.Cells(i + 1, j).value = m_DataView.Rows(i - 1).Cells(j - 1).FormattedValue.ToString()
    '        Next
    '    Next

    '    myExcel.ActiveWorkbook.SaveAs(FileName)
    '    myExcel.Quit()
    '    myExcel = Nothing
    '    MessageBox.Show("儲存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    'End Sub

    Private Sub Text(ByVal m_DataView As DataGridView, ByVal FileName As String)
        Dim objFileStream As FileStream
        Dim objStreamWriter As StreamWriter
        Dim strLine As String = ""
        objFileStream = New FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write)
        'objFileStream = New FileStream("S", FileMode.OpenOrCreate, FileAccess.Write)
        objStreamWriter = New StreamWriter(objFileStream, System.Text.Encoding.Unicode)
        For i As Integer = 0 To m_DataView.Columns.Count - 1
            If m_DataView.Columns(i).Visible = True Then
                strLine = strLine + m_DataView.Columns(i).HeaderText.ToString() + Convert.ToChar(9)
            End If
        Next
        objStreamWriter.WriteLine(strLine)
        strLine = ""

        For i As Integer = 0 To m_DataView.Rows.Count - 1
            If m_DataView.Columns(0).Visible = True Then
                If m_DataView.Rows(i).Cells(0).Value Is Nothing Then
                    strLine = (strLine & " ") + Convert.ToChar(9)
                Else
                    strLine = strLine + m_DataView.Rows(i).Cells(0).Value.ToString() + Convert.ToChar(9)
                End If
            End If
            For j As Integer = 1 To m_DataView.Columns.Count - 1
                If m_DataView.Columns(j).Visible = True Then
                    If m_DataView.Rows(i).Cells(j).Value Is Nothing Then
                        strLine = (strLine & " ") + Convert.ToChar(9)
                    Else
                        Dim rowstr As String = ""
                        rowstr = m_DataView.Rows(i).Cells(j).Value.ToString()
                        If rowstr.IndexOf(vbCr & vbLf) > 0 Then
                            rowstr = rowstr.Replace(vbCr & vbLf, " ")
                        End If
                        If rowstr.IndexOf(vbLf) > 0 Then
                            rowstr = rowstr.Replace(vbLf, " ")
                        End If
                        If rowstr.IndexOf(vbTab) > 0 Then
                            rowstr = rowstr.Replace(vbTab, " ")
                        End If
                        strLine = strLine + rowstr + Convert.ToChar(9)

                    End If
                End If
            Next
            objStreamWriter.WriteLine(strLine)
            strLine = ""
        Next
        objStreamWriter.Close()
        objFileStream.Close()
        MessageBox.Show("儲存文字檔成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CopyToExcel(ByVal m_DataView As DataGridView, ByVal FileName As String)

        Dim myExcel, myBook, myWorksheet As Object
        On Error Resume Next
        myExcel = CreateObject("Excel.Application")
        If Err.Number() <> 0 Then
            MsgBox("電腦沒有安裝Excel")
            Exit Sub
        End If
        myBook = myExcel.Workbooks.add
        myWorksheet = myBook.worksheets(1)
        myExcel.Visible = False
        'myWorksheet.Columns.NumberFormat = "@"

        m_DataView.MultiSelect = True
        m_DataView.SelectAll()
        Dim dataObj As DataObject = m_DataView.GetClipboardContent()
        Clipboard.SetDataObject(dataObj, True)
        m_DataView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        m_DataView.RowHeadersVisible = False
        m_DataView.MultiSelect = False

        myWorksheet.PasteSpecial(Format:="文字", Link:=False, DisplayAsIcon:=False)
        myWorksheet.Columns.AutoFit()

        myExcel.ActiveWorkbook.SaveAs(FileName)
        myExcel.Quit()
        myExcel = Nothing
        MessageBox.Show("儲存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

















End Module
