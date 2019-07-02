Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 退貨統計V100

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 退貨統計V100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        '取得查詢資料
        GetDGV1Data()
        GetDGV2Data()

    End Sub

    Private Sub GetDGV1Data()  '取得DGV1資料

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  EXEC [KaiShingPlug].[dbo].[預_退貨整合01v] "
            sql += " @類別 = N'1', "
            sql += " @Dat1 = N'" & Format(日期1.Value.Date, "yyyy-MM-dd") & "', "
            sql += " @Dat2 = N'" & Format(日期2.Value.Date, "yyyy-MM-dd") & "', "
            sql += " @變數 = N'ALL'  "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV1.AutoResizeColumns()
        'DGV1Display()

    End Sub


    Private Sub GetDGV2Data()  '取得DGV1資料

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  DECLARE @Dat1 VARCHAR(10) "
            sql += " DECLARE @Dat2 VARCHAR(10) "
            sql += " SET @Dat1 = '" & Format(日期1.Value.Date, "yyyy-MM-dd") & "' "
            sql += " SET @Dat2 = '" & Format(日期2.Value.Date, "yyyy-MM-dd") & "' "
            sql += "    SELECT [單號],[退貨日期],[存貨編號] AS '存編',[ItemName] AS '品名',[退貨情況],[退貨說明],[營_退貨數量],[品_退貨數量],[相符說明],[結果說明],[品_補充說明] "
            sql += "      FROM [KaiShingPlug].[dbo].[品_退貨統計] "
            sql += "     WHERE [類別] = '1' AND ([退貨日期] BETWEEN @Dat1 AND @Dat2) "
            sql += "  ORDER BY 1,3 "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()
        End Using
        DGV2.AutoResizeColumns()
        'DGV1Display()

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

    Private Sub BtnToExcel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel3.Click
        Select Case TabControl1.SelectedTab.Text
            Case "統計" : DataToExcel(DGV1, "退貨統計")
            Case "明細" : DataToExcel(DGV2, "退貨明細")
            Case Else

        End Select
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Label3.Text = TabControl1.SelectedTab.Text
    End Sub

    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl1.Selected
        Label3.Text = TabControl1.SelectedTab.Text
    End Sub

End Class