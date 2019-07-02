Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Drawing.Printing

Imports System.Drawing.Imaging
'Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
'Imports System.IO
Imports System.IO.Stream

Imports System.Windows.Forms
Imports System.Net.Dns


Public Class v001發票作廢作業

    Inherits System.Windows.Forms.Form

    Private stringToPrint As String

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim 選擇列印CB As String = "Y"
    Dim 是否列印CB As String = "不印發票"

    Dim fileToPrint As System.IO.StreamReader
    Dim printFont2 As System.Drawing.Font

    Private Sub 發票作廢作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        上傳.Visible = False
        修改為已上傳.Visible = False
        重新上傳.Visible = False


    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub GetDGV1Data()  '取得DGV1資料

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Dim Type As String = ""
            Dim Type2 As String = ""

            If 未上傳.Checked = True Then
                上傳.Visible = True
                修改為已上傳.Visible = True
                重新上傳.Visible = False
                Type = "="
            End If

            If 已上傳.Checked = True Then
                上傳.Visible = False
                修改為已上傳.Visible = False
                重新上傳.Visible = True
                Type = "<>"
                Type2 = " AND [是否修改] = 'N' "
            End If


            sql = "  SELECT T0.[DocNum] AS '作廢單號', "
            sql += " CONVERT(VARCHAR(10),T0.[DocDate],112) AS '作廢日期', "
            sql += " T0.[LicTradNum] AS '買方統編', "
            sql += " T0.[CardName] AS '買方名稱', "
            sql += " T0.[U_I_num] AS '作廢發票號碼' "
            sql += " FROM OINV T0 INNER JOIN"
            sql += "      ORIN T1 ON T0.[U_I_num] = T1.[U_I_num] LEFT JOIN "
            sql += "     [KaiShingPlug].[dbo].[發票記錄] T2 ON T2.[類別] = '發票作廢' AND T0.[DocNum] = T2.[文件號碼] "
            sql += " WHERE T0.[U_AR_type] = '99' AND (T0.[DocDate] BETWEEN '" & 起始日.Value.Date & "' AND '" & 結束日.Value.Date & "') AND "
            sql += "       T0.[CardName] NOT LIKE '%好市多%' AND T0.[CardName] NOT LIKE '%善美的%' AND ISNULL(T2.分類,'') " & Type & " '' " & Type2 & " "
            sql += " ORDER BY T0.[DocNum] DESC "



            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()


            '當 選擇列印CB = "Y" 時，新增一欄 '勾選' 欄位
            If 選擇列印CB = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                checkBoxColumn.Width = 30
                DGV1.Columns.Insert(0, checkBoxColumn)
            End If

            '新增完後關閉(才不會重覆出現)
            選擇列印CB = "N"

        End Using

        DGV1Display()

    End Sub

    Private Sub DGV1Display()  '載入DGV1資料畫面

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True : column.ReadOnly = True

            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.ReadOnly = False
                Case "作廢單號" : column.HeaderText = "作廢單號" : column.DisplayIndex = 1 : column.ReadOnly = True
                Case "作廢日期" : column.HeaderText = "作廢日期" : column.DisplayIndex = 2 : column.ReadOnly = True
                Case "買方統編" : column.HeaderText = "買方統編" : column.DisplayIndex = 3 : column.ReadOnly = True
                Case "買方名稱" : column.HeaderText = "買方名稱" : column.DisplayIndex = 4 : column.ReadOnly = True
                Case "作廢發票號碼" : column.HeaderText = "作廢發票號碼" : column.DisplayIndex = 5 : column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick '點選DGV1時

        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("作廢單號").Clear()
        End If

        'If DGV1.CurrentRow.Cells("統一編號").Value = "" Then
        '    列印模式選擇.Visible = False
        'Else
        '    列印模式選擇.Visible = True
        'End If

        '列印模式選擇

        DocNum.Text = DGV1.CurrentRow.Cells("作廢單號").Value
        GetDGV2Data2(DGV1.CurrentRow.Cells("作廢單號").Value)
        '載入文件號碼之明細
        'GetDGV2Data()

    End Sub

    Private Sub GetDGV2Data2(ByVal DGV2號碼 As String)

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("作廢單號").Clear()
        End If

        'If 列印模式選擇.Text = True Then
        '    是否列印CB = "不印發票"
        'Else
        '    是否列印CB = "列印發票"
        'End If

        'Dim 列印模式 As String = "" : 列印模式 = ""
        'If DGV1.CurrentRow.Cells("統一編號").Value <> "" Then
        '    Select Case 列印模式選擇.Text
        '        Case "發票列印"
        '            列印模式 = ""
        '        Case "只印證明聯"
        '            列印模式 = "ESC900001"
        '        Case "發票不印"
        '            列印模式 = "發票不列印"
        '    End Select
        'Else
        '    列印模式 = ""
        'End If


        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " SELECT T0.[DocNum] AS '作廢單號', "
            sql += " 'ESC100005' + CAST((CAST(DATEPART(YEAR,T0.[DocDate]) AS NUMERIC(4))-1911) AS VARCHAR(3)) + "
            sql += " SUBSTRING(CONVERT(VARCHAR(10),T0.[DocDate],112),5,2) + T0.[U_I_num] AS '作業發票' "
            sql += " FROM OINV T0 INNER JOIN "
            sql += " ORIN T1 ON T0.[U_I_num] = T1.[U_I_num] "
            sql += " WHERE T0.[U_AR_type] = '99' AND T0.[DocNum] = '" & DGV2號碼 & "' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "作廢單號")
            DGV2.DataSource = ks1DataSetDGV.Tables("作廢單號")
            TransactionMonitor.Complete()
            DGV2.AutoResizeColumns()

        End Using

        DGV2Display()

    End Sub

    Private Sub DGV2Display()  '載入DGV2資料畫面

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            DGV2.ColumnHeadersVisible = False  '表頭不顯示
            Select Case column.Name
                Case "作廢單號" : column.HeaderText = "作廢單號" : column.DisplayIndex = 0 : column.Visible = False
                Case "作業發票" : column.HeaderText = "作業發票" : column.DisplayIndex = 1
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub ToText(ByVal m_DataView As DataGridView, ByVal FileName As String) '將DGV2明細資料存檔成txt檔

        Dim objFileStream As FileStream : Dim objStreamWriter As StreamWriter

        '檔案存檔位置
        objFileStream = New FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write)

        '檔案存檔編碼：ASNI = GetEncoding(950)
        'objStreamWriter = New StreamWriter(objFileStream, System.Text.Encoding.GetEncoding(950))
        objStreamWriter = New StreamWriter(objFileStream, System.Text.Encoding.Default)

        '寫入明細資料
        For i = 0 To m_DataView.Rows.Count - 1
            For j = 1 To m_DataView.Columns.Count - 1
                objStreamWriter.WriteLine(m_DataView.Rows(i).Cells(j).Value.ToString)
            Next j
        Next i

        objStreamWriter.Close() : objFileStream.Close()

    End Sub


    Private Sub 上傳_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上傳.Click

        Dim int As Integer = 0

        Dim count As Integer = DGV1.Rows.Count

        For r As Integer = count - 1 To 0 Step -1

            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(r).Cells("選擇").Value) 'And DGV1.Rows(r).Cells("AR銷項種類").Value <> "發票作廢"

            If isSelected Then

                GetDGV2Data2(DGV1.Rows(r).Cells("作廢單號").Value)

                '將DGV2明細資料存檔成txt檔
                ToText(DGV2, "D:\發票作廢.txt")


                '讀取、列印 D:\發票列印.txt
                'Dim PrintPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                fileToPrint = New System.IO.StreamReader("D:\發票作廢.txt", System.Text.Encoding.Default)
                'printFont2 = New System.Drawing.Font(TextBox2.Text, TextBox1.Text)
                printFont2 = New System.Drawing.Font("微軟正黑體", 12)
                'printFont2 = New System.Drawing.Font("標楷體", 12)
                If UCase(GetHostName()) = "KS-D5" Then
                    PrintDocument1.PrinterSettings.PrinterName = "電子發票機"
                Else
                    PrintDocument1.PrinterSettings.PrinterName = "\\ks-d-06\電子發票機"
                End If

                PrintDocument1.Print()
                fileToPrint.Close()

                '刪除D:\發票列印.txt
                My.Computer.FileSystem.DeleteFile("D:\發票作廢.txt")
                int = int + 1
                System.Threading.Thread.Sleep(5000)
            End If
        Next

        If int > 0 Then
            DGV1資料回寫記錄Table()
            查詢.PerformClick()
        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim line As String = Nothing
        linesPerPage = e.MarginBounds.Height / printFont2.GetHeight(e.Graphics)
        While count < linesPerPage
            line = fileToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = count * printFont2.GetHeight(e.Graphics)
            e.Graphics.DrawString(line, printFont2, Brushes.Black, 0, yPos, New StringFormat())
            count += 1
        End While
        If Not (line Is Nothing) Then
            e.HasMorePages = True
        End If

    End Sub

    Private Sub DGV1資料回寫記錄Table()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLADD As String = ""

        For i = 0 To DGV1.RowCount - 1
            '類別: 發票作廢             分類: 1.已列印  2.未列印
            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(i).Cells("選擇").Value) 'And DGV1.Rows(i).Cells("AR銷項種類").Value <> "發票作廢"
            If isSelected Then
                SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[發票記錄] ([類別] ,[分類] ,[過帳日期] ,[文件號碼] ,[客戶名稱] ,[記錄時間] ,[是否修改])  "
                SQLADD += " VALUES ('發票作廢' , '1' , '" & DGV1.Rows(i).Cells("作廢日期").Value & "', '" & DGV1.Rows(i).Cells("作廢單號").Value & "', '" & DGV1.Rows(i).Cells("買方名稱").Value & "', GETDATE() , 'N') "
            End If
        Next

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub 重新上傳_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重新上傳.Click

        Dim int As Integer = 0

        Dim count As Integer = DGV1.Rows.Count

        For r As Integer = count - 1 To 0 Step -1

            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(r).Cells("選擇").Value) 'And DGV1.Rows(r).Cells("AR銷項種類").Value <> "發票作廢"
            If isSelected Then

                GetDGV2Data2(DGV1.Rows(r).Cells("作廢單號").Value)

                '將DGV2明細資料存檔成txt檔
                ToText(DGV2, "D:\發票作廢.txt")

                '讀取、列印 D:\發票列印.txt
                'Dim PrintPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                fileToPrint = New System.IO.StreamReader("D:\發票作廢.txt", System.Text.Encoding.Default)
                'printFont2 = New System.Drawing.Font(TextBox2.Text, TextBox1.Text)
                printFont2 = New System.Drawing.Font("微軟正黑體", 12)
                'printFont2 = New System.Drawing.Font("標楷體", 12)
                If UCase(GetHostName()) = "KS-D5" Then
                    PrintDocument1.PrinterSettings.PrinterName = "電子發票機"
                Else
                    PrintDocument1.PrinterSettings.PrinterName = "\\ks-d-06\電子發票機"
                End If

                PrintDocument1.Print()
                fileToPrint.Close()

                '刪除D:\發票列印.txt
                My.Computer.FileSystem.DeleteFile("D:\發票作廢.txt")
                int = int + 1
                System.Threading.Thread.Sleep(5000)
            End If
        Next

        If int > 0 Then
            DGV1資料回寫記錄Table2()
            查詢.PerformClick()
        End If

    End Sub

    Private Sub DGV1資料回寫記錄Table2()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLADD As String = ""

        For i = 0 To DGV1.RowCount - 1
            '類別: 發票作廢             分類: 1.已列印  2.未列印
            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(i).Cells("選擇").Value) 'And DGV1.Rows(i).Cells("AR銷項種類").Value <> "發票作廢"
            If isSelected Then
                SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[發票記錄] ([類別] ,[分類] ,[過帳日期] ,[文件號碼] ,[客戶名稱] ,[記錄時間] ,[修改時間] ,[是否修改])  "
                SQLADD += " VALUES ('發票作廢' , '1' , '" & DGV1.Rows(i).Cells("作廢日期").Value & "', '" & DGV1.Rows(i).Cells("作廢單號").Value & "', '" & DGV1.Rows(i).Cells("買方名稱").Value & "', GETDATE(), GETDATE() , 'S') "
            End If
        Next

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub 修改為已上傳_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改為已上傳.Click

        Dim int As Integer = 0

        Dim count As Integer = DGV1.Rows.Count

        For r As Integer = count - 1 To 0 Step -1

            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(r).Cells("選擇").Value) 'And DGV1.Rows(r).Cells("AR銷項種類").Value <> "發票作廢"

            If isSelected Then
                GetDGV2Data2(DGV1.Rows(r).Cells("作廢單號").Value)
                int = int + 1
            End If
        Next

        If int > 0 Then
            DGV1資料回寫記錄Table()
            查詢.PerformClick()
        End If

    End Sub

    Private Sub 全選_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全選.Click

        Dim count As Integer = DGV1.Rows.Count
        For i As Integer = count - 1 To 0 Step -1
            DGV1.Rows(i).Cells("選擇").Value = True
        Next

    End Sub

    Private Sub 取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 取消.Click

        Dim count As Integer = DGV1.Rows.Count
        For i As Integer = count - 1 To 0 Step -1
            DGV1.Rows(i).Cells("選擇").Value = False
        Next

    End Sub
End Class