Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 加工原料肉領料單

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 加工原料肉領料單_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

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

            sql = "  SELECT DISTINCT (CASE WHEN T0.[ObjType] = '60' THEN '發貨' END) AS '文件', T1.[DocEntry] AS '草稿單號', T0.[U_CK02] AS '製單編號', T0.[DocDate] AS '過帳日期', T0.[DocDueDate] AS '到期日', T0.[Comments] AS '備註', T0.[DocStatus] AS '文件狀態' "
            sql += " FROM ODRF T0 INNER JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
            sql += " WHERE T0.[ObjType] = '60' AND T0.[DocStatus] = 'O' AND T0.[U_CK01] = '5' AND "
            sql += " T0.[DocDate] BETWEEN '" & Date1.Value.Date & "' AND '" & Date2.Value.Date & "' "
            sql += " ORDER BY T1.[DocEntry] DESC "

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
                Case "文件"
                    column.HeaderText = "文件"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "草稿單號"
                    column.HeaderText = "草稿單號"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "製單編號"
                    column.HeaderText = " 製單編號"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "過帳日期"
                    column.HeaderText = "過帳日期"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "到期日"
                    column.HeaderText = "到期日"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "備註"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
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

        DocNum.Text = DGV1.CurrentRow.Cells("草稿單號").Value

        GetDGV2Data() '載入草稿單號之明細

    End Sub

    Private Sub GetDGV2Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  SELECT T1.[DocEntry] AS '草稿單號', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名', T1.[Quantity] AS '數量', T1.[WhsCode] AS '倉庫', T2.[OnHand] AS '庫存量', T1.[unitMsr] AS '庫存單位', T1.[U_p2] AS '重量(公斤)' "
            sql += " FROM ODRF T0 INNER JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry INNER JOIN OITM T2 ON T1.ItemCode = T2.ItemCode "
            sql += " WHERE T0.[ObjType] = '60' AND T0.[DocStatus] = 'O' AND T0.[U_CK01] = '5' AND T1.[DocEntry] = '" & DGV1.CurrentRow.Cells("草稿單號").Value & "' "
            sql += " ORDER BY T1.[LineNum] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()
        End Using

        DGV2Display()

    End Sub

    Private Sub DGV2Display()  '載入DGV2資料畫面

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "品名"
                    column.HeaderText = " 品名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "倉庫"
                    column.HeaderText = "倉庫"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "庫存量"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "庫存單位"
                    column.HeaderText = "庫存單位"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case "重量(公斤)"
                    column.HeaderText = "重量(公斤)"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub PrintReport()

        Z_ReportViewer.MdiParent = MainForm
        Z_ReportViewer.Source = "加工原料肉領料單"
        Z_ReportViewer.strPara(0) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("草稿單號").ToString()  '顯示在表頭，不重覆區域
        Z_ReportViewer.strPara(1) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("製單編號").ToString()
        Z_ReportViewer.strPara(2) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("過帳日期").ToString()
        Z_ReportViewer.strPara(3) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("文件日期").ToString()
        Z_ReportViewer.strPara(4) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("備註").ToString()

        Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT_Print")
        Z_ReportViewer.Show()

    End Sub

    Private Sub 列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印.Click

        If Not ks1DataSetDGV.Tables("DT_Print") Is Nothing Then
            ks1DataSetDGV.Tables("DT_Print").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  SELECT T1.[DocEntry] AS '草稿單號', T0.[U_CK02] AS '製單編號', T0.[Comments] AS '備註', CONVERT(VARCHAR(10),T0.[DocDate],102) AS '過帳日期', CONVERT(VARCHAR(10),T0.[TaxDate],102) AS '文件日期', "
            sql += " T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名', CAST(T1.[Quantity] AS FLOAT) AS '數量', T1.[unitMsr] AS '單位', CAST(SUM(T1.[Quantity]) AS FLOAT) AS '合計', T1.[LineNum] "
            sql += " FROM ODRF T0 INNER JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
            sql += " WHERE T0.[ObjType] = '60' AND T0.[DocStatus] = 'O' AND T0.[U_CK01] = '5' AND "
            sql += " T1.[DocEntry] = '" & DocNum.Text & "' "
            sql += " GROUP BY T1.[DocEntry], T0.[U_CK02], T0.[Comments], T0.[DocDate], T0.[TaxDate], T1.[ItemCode], T1.[Dscription], T1.[Quantity], T1.[unitMsr], T1.[LineNum] "
            sql += " ORDER BY T1.[LineNum] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT_Print")
            TransactionMonitor.Complete()
        End Using

        PrintReport()

    End Sub
End Class