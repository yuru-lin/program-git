Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Drawing.Printing

Public Class v001產程明細表

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub v001產程明細表_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        載入Cb初始()

    End Sub

    Private Sub 載入Cb初始()

        Cb印表機()

    End Sub

    Private Sub Cb印表機()

        Dim 預設印表機 As New PrintDocument()
        'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName
        Dim i As Integer : Dim 所有印表機 As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
            Cb1印表機.Items.Add(所有印表機)
        Next
        Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub GetDGV1Data()  '取得DGV1資料

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " EXEC [dbo].[產程明細表] '" & 日期1.Value.Date & "' , '" & 日期2.Value.Date & "' , '" & 製單類別.Text & "'  "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

        DGV1Display()

    End Sub

    Private Sub DGV1Display()  '載入DGV1資料畫面

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0
                Case "牧場" : column.HeaderText = "牧場" : column.DisplayIndex = 1
                Case "品種" : column.HeaderText = "品種" : column.DisplayIndex = 2
                Case "平均重" : column.HeaderText = "平均重" : column.DisplayIndex = 3
                Case "磅單重" : column.HeaderText = "磅單重" : column.DisplayIndex = 4
                Case "製單總重量" : column.HeaderText = "製單總重量" : column.DisplayIndex = 5
                Case "屠宰隻數" : column.HeaderText = "屠宰隻數" : column.DisplayIndex = 6
                Case "主產品比例" : column.HeaderText = "主產品比例" : column.DisplayIndex = 7
                Case "副產品比例" : column.HeaderText = "副產品比例" : column.DisplayIndex = 8
                Case "產成率" : column.HeaderText = "產成率" : column.DisplayIndex = 9
                Case "心產成率" : column.HeaderText = "心產成率" : column.DisplayIndex = 10
                Case "肫產成率" : column.HeaderText = "肫產成率" : column.DisplayIndex = 11
                Case "佛產成率" : column.HeaderText = "佛產成率" : column.DisplayIndex = 12
                Case "次級率" : column.HeaderText = "次級率" : column.DisplayIndex = 13
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印.Click

        Dim printDoc As New PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        If ks1DataSetDGV.Tables("DT1").Rows.Count > 0 Then

            Dim newRpt As 產程明細列印Print = New 產程明細列印Print
            newRpt.strPara(0) = 日期1.Text
            newRpt.strPara(1) = 日期2.Text

            newRpt.TYPE = "1"
            newRpt.紙張 = "Letter"

            newRpt.StartupPath = "\A_生管\報表\產程明細列印.rdlc"
            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If


            'newRpt.高 = "14cm"
            newRpt.dt = ks1DataSetDGV.Tables("DT1")
            'newRpt.printerName = printDoc.PrinterSettings.PrinterName
            newRpt.printerName = Cb1印表機.Text
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無明細!", MsgBoxStyle.OkOnly, "DT1")
        End If

    End Sub

    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click

        DataToExcel(DGV1, "")

    End Sub
End Class