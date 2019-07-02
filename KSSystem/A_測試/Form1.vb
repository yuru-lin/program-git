Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Form1

    Dim file As New ArrayList
    Dim DataAdapterDGV, DataDGV5 As SqlDataAdapter
    Dim OldName, NewName As String  '更名使用_20140303_Phil


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label1.Text = ""
        'TextBox1.Text = "C:\Users\phil\Documents"
        TextBox1.Text = "C:\Users\phil\Desktop\log2"
        'TextBox1.Text = "I:\清山\新增資料夾\log2"
        'TextBox1.Text = "D:\Seed\Egg"
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()



        For Each filetmp As String In My.Computer.FileSystem.GetFiles(TextBox1.Text, FileIO.SearchOption.SearchTopLevelOnly, "*." & TextBox2.Text)
            file.Add(filetmp)
        Next
        For y = 0 To file.Count - 1
            Rename(file(y), file(y).replace(".log", ".txt"))
        Next

        Dim dTable As DataTable = New DataTable()

        For y = 0 To file.Count - 1
            ListBox1.Items.Add((file(y).replace(TextBox1.Text & "\", "")).replace(".log", ".txt"))

            Dim open1 As String = ((file(y).replace(TextBox1.Text & "\", "")).replace(".log", ".txt"))
            Dim open2 As String = TextBox1.Text & "\"

            Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + open2 + ";Extended Properties='text;HDR=NO;FMT=TabDelimited';"

            ' if you don't want to sho the header row (first row) in the grid
            ' use 'HDR=NO' in the string

            Dim strSQL As String = "SELECT '" & open1.Replace(".txt", " ") & "', * FROM " & open1
            Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)

            Try
                excelConnection.Open() ' this will open excel file
            Catch ex As Exception
                MsgBox(" " & ex.Message)
                Exit Sub
            End Try
            Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

            'Dim dTable As DataTable = New DataTable()
            dataAdapter.Fill(dTable)

            ExcelDGV.DataSource = dTable
            'dTable.Dispose()
            dataAdapter.Dispose()
            dbCommand.Dispose()
            'excelConnection.Close()
            'excelConnection.Dispose()

        Next
        dTable.Dispose()


        ''Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        'Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        'Dim dTable As DataTable = New DataTable()
        'dataAdapter.Fill(dTable)

        'ExcelDGV.DataSource = dTable
        'For y = 0 To file.Count - 1
        '    'ListBox1.Items.Add(file(y).replace(TextBox1.Text & "\", ""))
        '    ExcelDGV.DataSource.add = (file(y).replace(TextBox1.Text & "\", ""))
        'Next


        file.Clear()
        Label1.Text = ListBox1.Items.Count
        'If ListBox1.Items.Count <> 0 Then
        '    Label2.Text = ListBox1.SelectedItem.ToString
        'End If

        'Label3.Text = ListBox1.Items.ToString
        '讀取Excel()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'Label1.Text = ListBox1.SelectedItem
        If ListBox1.Items.Count <> 0 Then
            Label2.Text = ListBox1.SelectedItem.ToString
            Label3.Text = ListBox1.SelectedItem
        End If
    End Sub

    Private Sub 讀取Excel()
        'Dim openfile As New OpenFileDialog()
        ''openfile.InitialDirectory = "..\"                  '開啟時預設的資料夾路徑   
        'openfile.InitialDirectory = "%HOMEPATH%\Desktop\"   '開啟時預設的資料夾路徑   
        'openfile.Filter = "純文字 Files(*.txt)|*.txt"       '只抓excel檔   
        'openfile.ShowDialog()

        'If openfile.FileName = "" Then
        '    Exit Sub
        'End If

        'Dim open1 As String = openfile.SafeFileName
        'Dim open2 As String = Replace(openfile.FileName, openfile.SafeFileName, "")
        For i As Integer = 0 To ListBox1.Items.Count - 1

            Dim open1 As String = ListBox1.SelectedIndex
            Dim open2 As String = TextBox1.Text & "\"
            MsgBox(i & "-" & open1)
            'MsgBox(open2)

            'T2DGV.CurrentCell = T2DGV.Rows(0).Cells(0)
        Next

        'For i As Integer = 0 To ExcelDGV.RowCount - 1
        '    If ExcelDGV.Rows(i).Cells("F1").FormattedValue <> "" Then
        '        F1 = Format(Replace(Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 4), " ", ""), "")



        '        For i As Integer = 0 To ExcelDGV.RowCount - 1
        '            Dim open1 As String = ListBox1.Items.ToString
        '            Dim open2 As String = TextBox1.Text & "\"
        '            MsgBox(open1)
        '            MsgBox(open2)
        '        Next



        'Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + open2 + ";Extended Properties='text;HDR=NO;FMT=TabDelimited';"

        '' if you don't want to sho the header row (first row) in the grid
        '' use 'HDR=NO' in the string

        'Dim strSQL As String = "SELECT * FROM " & open1
        'Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)

        'Try
        '    excelConnection.Open() ' this will open excel file
        'Catch ex As Exception
        '    MsgBox(" " & ex.Message)
        '    Exit Sub
        'End Try
        'Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        'Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        'Dim dTable As DataTable = New DataTable()
        'dataAdapter.Fill(dTable)

        'ExcelDGV.DataSource = dTable
        'dTable.Dispose()
        'dataAdapter.Dispose()
        'dbCommand.Dispose()
        ''excelConnection.Close()
        ''excelConnection.Dispose()

        ''If 電宰Rb.Checked = True Then
        ''    上傳電宰條碼至MSSQL()
        ''Else
        ''    上傳加工條碼至MSSQL()
        ''End If


    End Sub











End Class



'Public Class Form1

'    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'        Me.Close()
'        'System.Diagnostics.Process.Start(Application.StartupPath & "\生產過磅系統.exe")
'    End Sub
'End Class
