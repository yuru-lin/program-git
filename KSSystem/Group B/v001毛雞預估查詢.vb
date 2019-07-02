Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Drawing.Printing

Public Class v001毛雞預估查詢

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub v001毛雞預估查詢_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

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

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

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


            sql = "  SELECT DISTINCT T0.[DocDate] AS '日期', T1.[U_M03] AS '製單單號'  "  ', T0.[CarIDNumber] AS '車牌號'
            sql += " FROM [@Transportation] T0 INNER JOIN [@Transportation1] T1 ON T0.[CarEntry] = T1.[CarEntry] "
            sql += " WHERE T0.[DocDate] = '" & 日期.Value.Date & "' "


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
            column.Visible = True : column.ReadOnly = True

            Select Case column.Name
                Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 0 : column.ReadOnly = True
                Case "製單單號" : column.HeaderText = "製單單號" : column.DisplayIndex = 1 : column.ReadOnly = True
                    'Case "車牌號" : column.HeaderText = "車牌號" : column.DisplayIndex = 2 : column.ReadOnly = True
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
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        DocNum.Text = DGV1.CurrentRow.Cells("製單單號").Value
        GetDGV2Data(DGV1.CurrentRow.Cells("製單單號").Value)

        'GetDGV2Data() '載入製單單號之明細

    End Sub

    Private Sub GetDGV2Data(ByVal DGV2預估 As String)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " EXEC [dbo].[毛雞預估] '" & 日期.Value.Date & "' , '" & DocNum.Text & "'    "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()
            DGV2.AutoResizeColumns()
        End Using

        DGV2Display()

    End Sub

    Private Sub DGV2Display()  '載入DGV2資料畫面

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 0
                Case "製單單號" : column.HeaderText = "製單單號" : column.DisplayIndex = 1
                Case "牧場名稱" : column.HeaderText = "牧場名稱" : column.DisplayIndex = 2
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3
                Case "平均重" : column.HeaderText = "平均重" : column.DisplayIndex = 4
                Case "規格範圍" : column.HeaderText = "規格範圍" : column.DisplayIndex = 5
                Case "隻數" : column.HeaderText = "隻數" : column.DisplayIndex = 6
                Case "件數" : column.HeaderText = "件數" : column.DisplayIndex = 7
                Case "零散數" : column.HeaderText = "零散數" : column.DisplayIndex = 8
                Case "規格" : column.HeaderText = "規格" : column.DisplayIndex = 9
                Case "實際數量" : column.HeaderText = "實際數量" : column.DisplayIndex = 10
                Case "安全庫存量" : column.HeaderText = "安全庫存量" : column.DisplayIndex = 11
                Case "低於安全庫存數" : column.HeaderText = "低於安全庫存數" : column.DisplayIndex = 12
                Case "高於安全庫存數" : column.HeaderText = "高於安全庫存數" : column.DisplayIndex = 13
                Case "建議" : column.HeaderText = "建議" : column.DisplayIndex = 14
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub 列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印.Click

        Dim printDoc As New PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        If ks1DataSetDGV.Tables("DT2").Rows.Count > 0 Then

            Dim newRpt As 列印Print = New 列印Print
            newRpt.strPara(0) = 日期.Text
            newRpt.strPara(1) = DocNum.Text

            newRpt.TYPE = "1"
            newRpt.高 = "29.7cm"

            newRpt.StartupPath = "\A_營業\毛雞預估作業\毛雞預估列印.rdlc"
            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            'newRpt.高 = "14cm"
            newRpt.dt = ks1DataSetDGV.Tables("DT2")
            'newRpt.printerName = printDoc.PrinterSettings.PrinterName
            newRpt.printerName = Cb1印表機.Text
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無明細!", MsgBoxStyle.OkOnly, "DT2")
        End If

    End Sub
End Class