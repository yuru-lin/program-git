Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class v001檢查記錄

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub v001檢查記錄_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

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

            sql = "  SELECT T0.[BID] AS '區域編號', T0.[BName] AS '區域名稱', T1.[DID] AS '編碼', T1.[DName] AS '項目名稱', "
            sql += "        T2.[RYN] AS '合格否', T2.[RCheck] AS '確認', T2.[RDate] AS '記錄日期', T2.[RTime] AS '記錄時間', T2.[RMEMO] AS '備註' "
            sql += " FROM [kaiShingQC].[dbo].[KST_QC702301T06M] T0 INNER JOIN "
            sql += "      [kaiShingQC].[dbo].[KST_QC702301T06D] T1 ON T0.BID = T1.BID INNER JOIN "
            sql += "      [kaiShingQC].[dbo].[KST_QC702301T06R] T2 ON T1.BID = T2.BID AND T1.DID = T2.DID "
            sql += " WHERE T0.[BDelete] = 'N' AND T1.[DDelete] = 'N' AND (T2.[RDate] >= '" & 日期1.Value.Date & "' AND T2.[RDate] <= '" & 日期2.Value.Date & "') "

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
                Case "區域編號" : column.HeaderText = "區域編號" : column.DisplayIndex = 0
                Case "區域名稱" : column.HeaderText = "區域名稱" : column.DisplayIndex = 1
                Case "編碼" : column.HeaderText = "編碼" : column.DisplayIndex = 2
                Case "項目名稱" : column.HeaderText = "項目名稱" : column.DisplayIndex = 3
                Case "合格否" : column.HeaderText = "合格否" : column.DisplayIndex = 4
                Case "確認" : column.HeaderText = "確認" : column.DisplayIndex = 5
                Case "記錄日期" : column.HeaderText = "記錄日期" : column.DisplayIndex = 6
                Case "記錄時間" : column.HeaderText = "記錄時間" : column.DisplayIndex = 7
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 8
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub
End Class