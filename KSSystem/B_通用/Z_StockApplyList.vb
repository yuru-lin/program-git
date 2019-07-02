Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class Z_StockApplyList

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub Z_StockApply_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '初次控制項管理
        初始化()

        ddldepart.SelectedIndex = 0
        SelectDescr()
        ddlPurpose.SelectedIndex = 0
        GetDGV1Data()
    End Sub
#Region "下拉式選單事件"

    Private Sub SelectDescr()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = " (Select '全選' as '用途','-1' as '編號') "
            sql += " Union "
            sql += " (Select Descr as '用途',IndexID as '編號' from UFD1 where [FieldID] = '53' and [TableID]='OIGE' )"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            DataAdapter = New SqlDataAdapter(sql, DBConn)
            DataAdapter.Fill(ksSelectDataSet, "ddlPurpose")

            ddlPurpose.DataSource = ksSelectDataSet.Tables("ddlPurpose")
            ddlPurpose.DisplayMember = "用途"

            ddlPurpose.SelectedIndex = -1
        End Using
    End Sub

   

#End Region

#Region "按鈕動作"
    
    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click '查詢

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click '新增
        Z_StockApply.Source = "ADD"
        Z_StockApply.MdiParent = MainForm
        Z_StockApply.Show()
        Me.Close()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click '修改
        If laID.Text = "" Or (laExamine.Text = "" Or laExamine.Text = "已發貨") Then
            MsgBox("請選擇欲修改之存領編號!!", 16, "錯誤")
            Exit Sub
        End If

        Z_StockApply.Source = "EDIT"
        Z_StockApply.ID = laID.Text
        Z_StockApply.MdiParent = MainForm
        Z_StockApply.Show()
        Me.Close()
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick '點選GV
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        laID.Text = DGV1.CurrentRow.Cells("存領編號").Value
        laExamine.Text = DGV1.CurrentRow.Cells("狀態").Value

        '20190528-增加
        If DGV1.CurrentRow.Cells("列印次數").Value Is DBNull.Value Then
            DGV1.CurrentRow.Cells("列印次數").Value = 0
            次數.Text = DGV1.CurrentRow.Cells("列印次數").Value
        Else   
            次數.Text = DGV1.CurrentRow.Cells("列印次數").Value
        End If


        If laExamine.Text = "已發貨" Then
            BtnEdit.Enabled = False
            btnDel.Enabled = False
            btnPrint.Enabled = False
        Else
            BtnEdit.Enabled = True
            btnDel.Enabled = True
            btnPrint.Enabled = True
        End If
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click '刪除

        '確認資料可刪除

        If laID.Text = "" Or (laExamine.Text = "" Or laExamine.Text = "已發貨") Then
            MsgBox("刪除失敗：請選擇欲刪除之存領編號!!", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            '將相關資料先寫入His
            'sql += "   INSERT INTO  KS_Z_StockApply_His "
            'sql += "   SELECT *, 'D', GETDATE(), '" + Login.LogonUserName + "' "
            'sql += "   FROM KS_Z_StockApply "
            'sql += "   WHERE ID='" + laID.Text + "' "

            '20190528-修改
            sql += "   INSERT INTO  KS_Z_StockApply_His "
            sql += "   SELECT [ID], [DepartType], [IndexID], [Examine], [SendOutDate], [SendOutUser], [Reason], "
            sql += "   [DocNum], [MEMO], [AddDate], [AddUser], [AlterDate], [AlterUser], "
            sql += "   'D', GETDATE(), '" + Login.LogonUserName + "', "
            sql += "   [PrintCount], [PrintLastTime] "
            sql += "   FROM KS_Z_StockApply "
            sql += "   WHERE ID='" + laID.Text + "' "

            sql += "   INSERT INTO  KS_Z_StockApply_Detail_His "
            sql += "   SELECT *, 'D', GETDATE(), '" + Login.LogonUserName + "' "
            sql += "   FROM KS_Z_StockApply_Detail "
            sql += "   WHERE ID='" + laID.Text + "' "

            '刪除資料
            sql += "   DELETE FROM [KS_Z_StockApply] "
            sql += "   WHERE ID='" + laID.Text + "' "

            sql += "   DELETE FROM [KS_Z_StockApply_Detail] "
            sql += "   WHERE ID='" + laID.Text + "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()



            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("刪除成功!", 64, "成功")

        '重新取得資料
        GetDGV1Data()
        初始化()
    End Sub

#End Region

#Region "取得DataGridView資料"
    Private Sub GetDGV1Data()

        Dim strWhere As String = ""
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        '組Where條件
        '部門
        If ddldepart.SelectedIndex <> 0 Then
            strWhere += " AND (K.DepartType='" + Convert.ToString(ddldepart.SelectedIndex - 1) + "') "
        End If

        '用途
        If ddlPurpose.SelectedIndex <> 0 Then
            strWhere += " AND (K.IndexID='" + Convert.ToString(ddlPurpose.SelectedValue(1)) + "') "
        End If

        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select Distinct K.[ID] AS '存領編號', "
            sql += " UF.Descr AS '用途', "
            sql += " CASE [DepartType]  "
            sql += "   When '0'  then '營業' "
            sql += "   When '1'  then '生管' "
            sql += "   When '2'  then '人事' "
            sql += "   When '3'  then '倉庫' "
            sql += "   When '4'  then '會計' "
            sql += "   When '5'  then '採購' "
            sql += "   When '6'  then '總經理室' "
            sql += "   When '7'  then '研發' "
            sql += "   When '8'  then '設計' "
            sql += "   When '9'  then '品管' "
            sql += "   When '10' then '加工' "
            sql += "   When '11' then '資訊' "
            sql += "   When '12' then '董事長室' "
            sql += " End AS '部門',  "
            sql += " convert(varchar(10),KD.GetProDate,112) AS '取貨日期' , "
            sql += " CASE K.[Examine]  "
            sql += "   When '1' then '申請中' "
            sql += "   When '2' then '已發貨' "
            sql += " End AS '狀態' , "
            sql += " K.[DocNum] AS '發貨編號', "
            sql += " convert(varchar(10),K.[AddDate],112) AS '申請日期', "
            sql += " convert(varchar(10),K.[AlterDate],112) AS '修改日期', "
            sql += " K.[PrintCount] AS '列印次數', "                             '20190528-增加
            sql += " K.[PrintLastTime] AS '列印的最後時間' "                     '20190528-增加
            sql += " From KS_Z_StockApply K "
            sql += " Left Join KS_Z_StockApply_Detail KD ON K.ID = KD.ID "
            sql += " Left Join UFD1 UF ON K.IndexID = UF.IndexID and UF.[FieldID] = '53' and UF.[TableID] = 'OIGE' "
            sql += " Where 1 = 1 "
            sql += strWhere
            sql += " AND AddUser = '" & Login.LogonUserName & "'"
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

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "存領編號"
                    column.HeaderText = "存領編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "用途"
                    column.HeaderText = "用途"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "部門"
                    column.HeaderText = " 部門"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "取貨日期"
                    column.HeaderText = "取貨日期"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "狀態"
                    column.HeaderText = "狀態"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "發貨編號"
                    column.HeaderText = "發貨編號"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case "申請日期"
                    column.HeaderText = "申請日期"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "修改日期"
                    column.HeaderText = "修改日期"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case "列印次數"                             '20190528-增加
                    column.HeaderText = "列印次數"
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                Case "列印的最後時間"                       '20190528-增加
                    column.HeaderText = "列印的最後時間"
                    column.DisplayIndex = 9
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

        'Dim column0 As New DataGridViewCheckBoxColumn()
        'column0.Name = "CheckBoxes"
        'column0.HeaderText = "核選方塊測試"
        'column0.DisplayIndex = 0
        'DGV1.Columns.Add(column0)
    End Sub
#End Region

    Private Sub 初始化()
        laID.Text = ""
        laExamine.Text = ""
        BtnEdit.Enabled = False
        btnDel.Enabled = False
        btnPrint.Enabled = False
    End Sub

    Private Sub PrintReport()

        Z_ReportViewer.MdiParent = MainForm
        Z_ReportViewer.Source = "StockApply"
        Z_ReportViewer.strPara(0) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("部門").ToString()
        Z_ReportViewer.strPara(1) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("用途").ToString()
        Z_ReportViewer.strPara(2) = ks1DataSetDGV.Tables("DT_Print").Rows(0).Item("ID").ToString()

        Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT_Print")
        Z_ReportViewer.Show()

        '        Dim p As New ReportParameter("myParameterName", param1.ToString())
        'rptViewer.LocalReport.SetParameters(New () {p})
        'So try to changing your last 2 lines to

        '        Dim param As New ReportParameter("yourReportParametername", rpfilled)
        'lr.LocalReport.SetParameters(New () {param})


    End Sub

   
   
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If laID.Text = "" Or (laExamine.Text = "" Or laExamine.Text = "已發貨") Then
            MsgBox("補印失敗：請選擇欲補印之存領編號!!", 16, "錯誤")
            Exit Sub
        End If

        If Not ks1DataSetDGV.Tables("DT_Print") Is Nothing Then
            ks1DataSetDGV.Tables("DT_Print").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "    SELECT ZS.[ID], "
            sql += "          CASE [DepartType] WHEN '0'  THEN '營業' WHEN '1'  THEN '生管'     WHEN '2'  THEN '人事' WHEN '3'  THEN '倉庫' WHEN '4'  THEN '會計'  "
            sql += "                            WHEN '5'  THEN '採購' WHEN '6'  THEN '總經理室' WHEN '7'  THEN '研發' WHEN '8'  THEN '設計' "
            sql += "                            WHEN '9'  THEN '品管' WHEN '10' THEN '加工'     WHEN '11' THEN '資訊' WHEN '12' THEN '董事長室' END AS '部門', " '20190104增加董事長室
            sql += "          UF.[Descr]+','+ZS.[MEMO] AS '用途', ProCode, [ProName], [Num], ZSD.[Fldvalue], T0.[Descr] AS 'FldName', "
            sql += "          CASE [TYPE] WHEN '1' THEN '電宰品' WHEN '2' THEN '加工品' ELSE '其他品' END AS 'TYPE', ZSD.[MEMO], [GetProDate], ISNULL(OM.[FrgnName],'') AS 'FrgnName' "
            sql += "     FROM [KS_Z_StockApply_Detail] ZSD "
            sql += "          INNER JOIN [KS_Z_StockApply] ZS ON ZSD.[ID]       = ZS.[ID] "
            sql += "          LEFT  JOIN [UFD1]            T0 ON ZSD.[Fldvalue] = T0.[FldValue] AND T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' "
            sql += "          LEFT  JOIN [UFD1]            UF ON ZS.[IndexID]   = UF.[IndexID]  AND UF.[TableID] = 'OIGE' AND UF.[FieldID] = '53' "
            sql += "          LEFT  JOIN [OITM]            OM ON ZSD.[ProCode]  = OM.[ItemCode]"
            sql += "    WHERE ZSD.[ID] = '" + laID.Text + "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT_Print")

            TransactionMonitor.Complete()
        End Using

        '20190528增加
        Dim i As Integer
        For i = 1 To i
            i = i + 1
        Next i
        次數.Text = 次數.Text + i

        '20190528增加
        EditData()
        DGV1RowUpdate()


        PrintReport()


    End Sub

    Private Sub EditData() '20190528增加
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim sql As String = ""
        Dim tran As SqlTransaction = DBConn.BeginTransaction()


        '修改資料庫作業(主Table)
        sql += String.Format(" UPDATE [KS_Z_StockApply] SET [PrintCount] = '{0}', [PrintLastTime] = GETDATE() " & _
         " WHERE ID = '" + laID.Text + "' " _
         , 次數.Text)

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.Transaction = tran
        SQLCmd.ExecuteNonQuery()

        tran.Commit()

    End Sub

    Private Sub DGV1RowUpdate() '20190528增加

        For i = 0 To DGV1.RowCount - 1

            If DGV1.Rows(i).Cells("存領編號").Value = laID.Text Then
                DGV1.CurrentRow.Cells("列印次數").Value = 次數.Text
                DGV1.CurrentRow.Cells("列印的最後時間").Value = Format(Now(), "yyyy-MM-dd HH:mm")
            End If

        Next

    End Sub
End Class