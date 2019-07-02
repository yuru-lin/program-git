Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class v001存領單查詢

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub v001存領單查詢_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = "  Select Distinct K.[ID] AS '存領編號', UF.Descr AS '用途', "
            sql += "        CASE [DepartType] When '0'  then '營業'     When '1'  then '生管' When '2'  then '人事' When '3'  then '倉庫' When '4'  then '會計' When '5'  then '採購' "
            sql += "                          When '6'  then '總經理室' When '7'  then '研發' When '8'  then '設計' When '9'  then '品管' When '10' then '加工' When '11' then '資訊' When '12' Then '董事長室' End AS '部門', " '20190104增加董事長室
            sql += "        [lastName] AS '存領者', "
            sql += "        convert(varchar(10),KD.GetProDate,112) AS '取貨日期', CASE K.[Examine] When '1' then '申請中' When '2' then '已發貨' End AS '狀態' , "
            sql += "        K.[DocNum] AS '發貨編號', convert(varchar(10),K.[AddDate],112) AS '申請日期', convert(varchar(10),K.[AlterDate],112) AS '修改日期', K.[MEMO] AS '備註' "
            sql += " From KS_Z_StockApply K LEFT  JOIN [OHEM] K1 ON K.[AddUser] = K1.[pager] "
            sql += "      Left Join KS_Z_StockApply_Detail KD ON K.ID = KD.ID "
            sql += "      Left Join UFD1 UF ON K.IndexID = UF.IndexID AND UF.[FieldID] = '53' AND UF.[TableID] = 'OIGE' "
            sql += " WHERE K.[AddDate] >= '" & 日期1.Value.Date & "' AND K.[AddDate] <= '" & 日期2.Value.Date & "' AND '" & 部門別.Text & "' LIKE '%'+[DepartType]+'%' "
            sql += " ORDER BY 申請日期 DESC, 存領編號 DESC"


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
                Case "存領編號" : column.HeaderText = "存領編號" : column.DisplayIndex = 0
                Case "用途" : column.HeaderText = "用途" : column.DisplayIndex = 1
                Case "部門" : column.HeaderText = "部門" : column.DisplayIndex = 2
                Case "存領者" : column.HeaderText = "存領者" : column.DisplayIndex = 3
                Case "取貨日期" : column.HeaderText = "取貨日期" : column.DisplayIndex = 4
                Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 5
                Case "發貨編號" : column.HeaderText = "發貨編號" : column.DisplayIndex = 6
                Case "申請日期" : column.HeaderText = "申請日期" : column.DisplayIndex = 7
                Case "修改日期" : column.HeaderText = "修改日期" : column.DisplayIndex = 8
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 9
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

        存領編號.Text = DGV1.CurrentRow.Cells("存領編號").Value

        '載入存領編號之明細
        GetDGV2Data()

    End Sub

    Private Sub GetDGV2Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  SELECT T0.ProCode AS '存編', T0.ProName AS '品名', T0.Num AS '數量' ,[MEMO] AS '項目備註' "
            sql += " FROM KS_Z_StockApply_Detail T0 "
            sql += " WHERE [ID] = '" & DGV1.CurrentRow.Cells("存領編號").Value & "' "

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
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 2
                Case "項目備註" : column.HeaderText = "項目備註" : column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.AutoResizeColumns()

    End Sub
End Class