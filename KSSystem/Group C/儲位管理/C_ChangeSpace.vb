Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class C_ChangeSpace


    Dim DataAdapter1 As SqlDataAdapter
    Dim ksDataSet As DataSet = New DataSet
    Dim ks1DataSet As DataSet = New DataSet
    Dim ADate As String
    Dim dsPDAIn As New DataSet
    Dim dsPDAInGood As New DataTable
    Dim SSS As String



    Private Sub C_ChangeSpace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label4.Text = System.Net.Dns.GetHostName()

        locView.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView3.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView4.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        AddColumn()

        Label2.Text = "條碼：  " + Format(locView.RowCount, "") + "  筆"
        Label14.Text = "正確：  " + Format(DataGridView2.RowCount, "") + "  筆"
        Label9.Text = "錯誤：  " + Format(DataGridView1.RowCount, "") + "  筆"

        SSS = 0

    End Sub
    Private Sub AddColumn()
        Dim NameGoodF1 As DataColumn = New DataColumn("F1")
        Dim NameGoodF2 As DataColumn = New DataColumn("F2")
        Dim NameGoodF3 As DataColumn = New DataColumn("F3")
        Dim NameGoodF4 As DataColumn = New DataColumn("F4")
        Dim NameGoodF5 As DataColumn = New DataColumn("F5")

        NameGoodF1.DataType = System.Type.GetType("System.String")
        NameGoodF2.DataType = System.Type.GetType("System.String")
        NameGoodF3.DataType = System.Type.GetType("System.String")
        NameGoodF4.DataType = System.Type.GetType("System.String")
        NameGoodF5.DataType = System.Type.GetType("System.String")

        dsPDAInGood.Columns.Add(NameGoodF1)
        dsPDAInGood.Columns.Add(NameGoodF2)
        dsPDAInGood.Columns.Add(NameGoodF3)
        dsPDAInGood.Columns.Add(NameGoodF4)
        dsPDAInGood.Columns.Add(NameGoodF5)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        SSS = 0

        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "Excel files(*.xls)|*.xls"    '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        ' if you don't want to sho the header row (first row) in the grid
        ' use 'HDR=NO' in the string

        Dim strSQL As String = "SELECT * FROM [Sheet1$]"
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        ' create data table
        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

        locView.DataSource = dTable
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        setdgvDisplay()

        uploadMSSQL()

        joinAllTable3()

        ''查詢現有預轉入庫位數
        ''If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then
        If DataGridView2.RowCount > 0 Then
            ChkLoc()
        End If

        ' ''joinAllTable()

        ' ''joinAllTable1()

    End Sub
    '設定dgvSourceMain顯示
    Private Sub uploadMSSQL()

        Dim ksDataSet As DataSet = New DataSet

        Dim F1 As String
        Dim F2 As String
        Dim F3 As String '原本儲位
        Dim F4 As String '條碼序號
        Dim F5 As String '新儲位

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "DELETE FROM [Z_KS_Reloc] WHERE [F6] = '" & Label4.Text & "' "
        SQLCmd.ExecuteNonQuery()


        SQLCmd.CommandText = "INSERT INTO [Z_KS_Reloc] (F1,F2,F3,F4,F5,F6) VALUES (@str_1,@str_2,@str_3,@str_4,@str_5,'" & Label4.Text & "')"

        For i As Integer = 0 To locView.RowCount - 1
            F1 = locView.Rows(i).Cells("F1").Value
            F2 = locView.Rows(i).Cells("F2").Value

            If locView.Rows(i).Cells("F3").Value.ToString = vbNullString Then
                F3 = "0"
            Else
                F3 = locView.Rows(i).Cells("F3").Value
            End If

            F4 = locView.Rows(i).Cells("F4").Value
            F5 = locView.Rows(i).Cells("F5").Value
            SQLCmd.Parameters.Clear()
            SQLCmd.Parameters.AddWithValue("@str_1", F1)
            SQLCmd.Parameters.AddWithValue("@str_2", F2)
            SQLCmd.Parameters.AddWithValue("@str_3", F3)
            SQLCmd.Parameters.AddWithValue("@str_4", F4)
            SQLCmd.Parameters.AddWithValue("@str_5", F5)
            SQLCmd.ExecuteNonQuery()

        Next

        '序號
        'SQLCmd.CommandText = "Update [Z_KS_Reloc] set [F3] = [OSRN].[U_M2] FROM [OSRN] WHERE [Z_KS_Reloc].[F4] = [OSRN].[DistNumber] AND  [Z_KS_Reloc].[F1] = '1' "
        SQLCmd.CommandText = " exec L20111221A_2 '" & Label4.Text & "' "
        'SQLCmd.CommandType = CommandType.StoredProcedure
        'SQLCmd.CommandTimeout = 100000
        SQLCmd.ExecuteNonQuery()


        'SQLCmd.Connection = DBConn
        ''SQLCmd.CommandText = Sql
        'SQLCmd.CommandType = CommandType.StoredProcedure
        'SQLCmd.CommandTimeout = 100000



        '批次
        'SQLCmd.CommandText = "Update [Z_KS_Reloc] set [F3] = [OBTN].[U_M2] FROM [OBTN] WHERE [Z_KS_Reloc].[F4] = [OBTN].[DistNumber] AND  [Z_KS_Reloc].[F1] = '2' "
        'SQLCmd.ExecuteNonQuery()

        'MsgBox("完成1", 48, "警告")
    End Sub

    '設定dgvSourceMain顯示
    Private Sub setdgvDisplay()

        For Each column As DataGridViewColumn In locView.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "作業別"

                Case "F2"
                    column.HeaderText = "區別"

                Case "F3"
                    column.HeaderText = "原先儲位"

                Case "F4"
                    column.HeaderText = "條碼序號"

                Case "F5"
                    column.HeaderText = "目的儲位"

                Case Else
                    column.Visible = False
            End Select
        Next
        locView.AutoResizeColumns()
        'Label2.Text = locView.RowCount
        Label2.Text = "條碼：  " + Format(locView.RowCount, "") + "  筆"

    End Sub

    Private Sub joinAllTable3()

        If locView.Rows.Count > 0 Or SSS = 1 Then
            dsPDAInGood = New DataTable
            AddColumn()
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Dim sqlReader1 As SqlDataReader
            Dim dsPDAIn As New DataTable

            Dim Q As Integer = 0
            Dim QGood As Integer = 0
            Dim Name As DataColumn = New DataColumn("條碼")
            Dim Name1 As DataColumn = New DataColumn("區別")
            Dim Name0 As DataColumn = New DataColumn("作業別")
            Name.DataType = System.Type.GetType("System.String")
            Name1.DataType = System.Type.GetType("System.String")
            Name0.DataType = System.Type.GetType("System.String")
            dsPDAIn.Columns.Add(Name)
            dsPDAIn.Columns.Add(Name1)
            dsPDAIn.Columns.Add(Name0)

            If DataGridView1.RowCount > 0 Then
                dsPDAIn.Clear()
                DataGridView1.DataSource = dsPDAIn
            End If
            If DataGridView2.RowCount > 0 Then
                dsPDAInGood.Clear()
                DataGridView2.DataSource = dsPDAInGood
            End If

            If SSS = 0 Then
                PBar1.Minimum = 0
                PBar1.Maximum = locView.Rows.Count - 1
            End If


            SQLCmd.Connection = DBConn


            SQLCmd.CommandText = " DECLARE @F6 varchar(10) "
            SQLCmd.CommandText += "SET NOCOUNT ON	"
            SQLCmd.CommandText += "SET @F6 = '" & Label4.Text & "' "

            '------查詢錯誤條碼區
            'SQLCmd.CommandText = "  SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber, q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.[F5] FROM [Z_KS_Reloc] z LEFT JOIN [OSRN] n ON z.[F4] = n.[DistNumber] LEFT JOIN [OSRQ] q ON n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] WHERE z.[F1] = '1' AND ISNULL(q.[Quantity],0) = 0 AND z.[F6] = '" & Label4.Text & "' "
            SQLCmd.CommandText += "   SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber, q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.F5 "
            SQLCmd.CommandText += "     FROM [Z_KS_Reloc] z LEFT JOIN [OSRN] n on z.[F4]       = n.[DistNumber] "
            'SQLCmd.CommandText += "                         LEFT JOIN [OSRQ] q on n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] "
            SQLCmd.CommandText += "                         LEFT JOIN [OSRQ] q on n.[ItemCode] = q.[ItemCode] AND n.[SysNumber] = q.[SysNumber] AND n.[AbsEntry] = q.[MdAbsEntry] "
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT * FROM [Z_KS_Reloc] z WHERE z.[F1] = '1' AND z.[F6] = @F6 AND z.[F4] = z.[F4] ) AND z.[F6] = @F6 "
            SQLCmd.CommandText += " GROUP BY n.[DistNumber], n.[U_M2], n.[DistNumber], q.[ItemCode], z.[F1], z.[F2], z.[F3], z.[F4], z.F5 "
            SQLCmd.CommandText += "   HAVING ISNULL(SUM(Q.[Quantity]), 0) = 0 "
            SQLCmd.CommandText += "    UNION "
            'SQLCmd.CommandText += " SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber, q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.[F5] FROM [Z_KS_Reloc] z LEFT JOIN [OBTN] n ON z.[F4] = n.[DistNumber] LEFT JOIN [OBTQ] q ON n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] WHERE z.[F1] = '2' AND ISNULL(q.[Quantity],0) = 0 AND z.[F6] = '" & Label4.Text & "' "
            SQLCmd.CommandText += "   SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber, q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.F5 "
            SQLCmd.CommandText += "     FROM [Z_KS_Reloc] z LEFT JOIN [OBTN] n on z.[F4]       = n.[DistNumber] "
            'SQLCmd.CommandText += "                         LEFT JOIN [OBTQ] q on n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] "
            SQLCmd.CommandText += "                         LEFT JOIN [OBTQ] q on n.[ItemCode] = q.[ItemCode] AND n.[SysNumber] = q.[SysNumber] AND n.[AbsEntry] = q.[MdAbsEntry] "
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT * FROM [Z_KS_Reloc] z WHERE z.[F1] = '2' AND z.[F6] = @F6 AND z.[F4] = z.[F4] ) AND z.[F6] = @F6 "
            SQLCmd.CommandText += " GROUP BY n.[DistNumber], n.[U_M2], n.[DistNumber], q.[ItemCode], z.[F1], z.[F2], z.[F3], z.[F4], z.F5 "
            SQLCmd.CommandText += "   HAVING ISNULL(SUM(Q.[Quantity]), 0) = 0 "
            'SQLCmd.CommandType = CommandType.StoredProcedure
            SQLCmd.CommandTimeout = 100000
            sqlReader1 = SQLCmd.ExecuteReader

            Do While (sqlReader1.Read())
                Q = Q + 1
                Dim Row(Q) As DataRow
                Row(Q) = dsPDAIn.NewRow
                Row(Q).Item("區別") = sqlReader1.Item("F2")
                Row(Q).Item("條碼") = sqlReader1.Item("F4")
                Row(Q).Item("作業別") = sqlReader1.Item("F1")
                dsPDAIn.Rows.Add(Row(Q))   '錯誤區
            Loop

            sqlReader1.Close()
            '------查詢錯誤條碼區

            '------查詢正確條碼區

            SQLCmd.CommandText = " DECLARE @F6 varchar(10) "
            SQLCmd.CommandText += "SET NOCOUNT ON	"
            SQLCmd.CommandText += "SET @F6 = '" & Label4.Text & "' "

            'SQLCmd.CommandText = "  SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber,q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.[F5] FROM [Z_KS_Reloc] z LEFT JOIN [OSRN] n ON z.[F4]= n.[DistNumber] LEFT JOIN [OSRQ] q ON n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] WHERE z.[F1]='1' AND ISNULL(z.[F5],'') <> '' AND  ISNULL(q.[ItemCode],'') <> '' AND q.[Quantity] > '0' AND z.[F6] = '" & Label4.Text & "' "
            SQLCmd.CommandText += "   SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber,q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.[F5] "
            SQLCmd.CommandText += "     FROM [Z_KS_Reloc] z LEFT JOIN [OSRN] n on z.[F4]       = n.[DistNumber] "
            'SQLCmd.CommandText += "                         LEFT JOIN [OSRQ] q on n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] "
            SQLCmd.CommandText += "                         LEFT JOIN [OSRQ] q on n.[ItemCode] = q.[ItemCode] AND n.[SysNumber] = q.[SysNumber] AND n.[AbsEntry] = q.[MdAbsEntry] "
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT * FROM [Z_KS_Reloc] z WHERE z.[F1] = '1' AND z.[F6] = @F6 AND z.[F4] = z.[F4] ) AND ISNULL(z.[F5],'') <> '' AND ISNULL(q.[ItemCode],'') <> '' AND z.[F6] = @F6 "
            SQLCmd.CommandText += " GROUP BY n.[DistNumber], n.[U_M2], n.[DistNumber], q.[ItemCode], z.[F1], z.[F2], z.[F3], z.[F4], z.F5 "
            SQLCmd.CommandText += "   HAVING ISNULL(SUM(Q.[Quantity]), 0) > 0 "
            SQLCmd.CommandText += "    UNION "
            'SQLCmd.CommandText += " SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber,q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.[F5] FROM [Z_KS_Reloc] z LEFT JOIN [OBTN] n ON z.[F4]= n.[DistNumber] LEFT JOIN [OBTQ] q ON n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] WHERE z.[F1]='2' AND ISNULL(z.[F5],'') <> '' AND  ISNULL(q.[ItemCode],'') <> '' AND q.[Quantity] > '0' AND z.[F6] = '" & Label4.Text & "' "
            SQLCmd.CommandText += "   SELECT n.[DistNumber], n.[U_M2], n.[DistNumber] AS OSRN_DistNumber,q.[ItemCode] AS OSRQ_ItemCode, z.[F1], z.[F2], z.[F3], z.[F4], z.[F5] "
            SQLCmd.CommandText += "     FROM [Z_KS_Reloc] z LEFT JOIN [OBTN] n on z.[F4]       = n.[DistNumber] "
            'SQLCmd.CommandText += "                         LEFT JOIN [OBTQ] q on n.[AbsEntry] = q.[MdAbsEntry] AND n.[SysNumber] = q.[SysNumber] "
            SQLCmd.CommandText += "                         LEFT JOIN [OBTQ] q on n.[ItemCode] = q.[ItemCode] AND n.[SysNumber] = q.[SysNumber] AND n.[AbsEntry] = q.[MdAbsEntry] "
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT * FROM [Z_KS_Reloc] z WHERE z.[F1] = '2' AND z.[F6] = @F6 AND z.[F4] = z.[F4] ) AND ISNULL(z.[F5],'') <> '' AND ISNULL(q.[ItemCode],'') <> '' AND z.[F6] = @F6 "
            SQLCmd.CommandText += " GROUP BY n.[DistNumber], n.[U_M2], n.[DistNumber], q.[ItemCode], z.[F1], z.[F2], z.[F3], z.[F4], z.F5 "
            SQLCmd.CommandText += "   HAVING ISNULL(SUM(Q.[Quantity]), 0) > 0 "
            'SQLCmd.CommandType = CommandType.StoredProcedure
            SQLCmd.CommandTimeout = 100000
            sqlReader1 = SQLCmd.ExecuteReader

            Do While (sqlReader1.Read())

                QGood = QGood + 1
                Dim Row(QGood) As DataRow
                Row(QGood) = dsPDAInGood.NewRow
                Row(QGood).Item("F1") = sqlReader1.Item("F1")
                Row(QGood).Item("F2") = sqlReader1.Item("F2")
                Row(QGood).Item("F3") = sqlReader1.Item("F3")
                Row(QGood).Item("F4") = sqlReader1.Item("F4")
                Row(QGood).Item("F5") = sqlReader1.Item("F5")
                dsPDAInGood.Rows.Add(Row(QGood))  '正確區
            Loop

            sqlReader1.Close()
            '------查詢正確條碼區


            If Q > 0 Then
                Button2.Enabled = False
                Button4.Enabled = True
                Button5.Enabled = True

                If DGV2.RowCount > 0 Then
                    ksDataSet.Tables("DT5").Clear()
                End If

                MsgBox("條碼有錯誤!請檢查!")
            ElseIf Q = 0 Then
                Button2.Enabled = True
            End If

            If QGood > 0 Then
                Button2.Enabled = True
            End If

            DataGridView1.DataSource = dsPDAIn
            DataGridView2.DataSource = dsPDAInGood
            'Label9.Text = DataGridView1.RowCount
            Label9.Text = "錯誤：  " + Format(DataGridView1.RowCount, "") + "  筆"
            'Label14.Text = DataGridView2.RowCount
            Label14.Text = "正確：  " + Format(DataGridView2.RowCount, "") + "  筆"


            DataGridView1.AutoResizeColumns()
            DataGridView2.AutoResizeColumns()

            ''If DataGridView2.RowCount > 0 Then
            ''    ChkLoc()
            ''End If
        End If

        ''查詢現有預轉入庫位數
        ''If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then
        'If DataGridView2.RowCount > 0 Then
        '    ChkLoc()
        'End If

        'MsgBox("完成2", 48, "警告")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'If locView.RowCount = -1 Or SSS <> 1 Then
        '    MsgBox("無資料可查詢", 48, "警告")
        '    Exit Sub
        'End If

        SSS = 1

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = " exec L20111221A_2 '" & Label4.Text & "' "
        'SQLCmd.CommandType = CommandType.StoredProcedure
        'SQLCmd.CommandTimeout = 100000
        SQLCmd.ExecuteNonQuery()

        joinAllTable3()
        ChkLoc()

        SSS = 0

    End Sub

    Private Sub ChkLoc()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV2.RowCount > 0 Then
            ksDataSet.Tables("DT5").Clear()
        End If

        Try
            sql = " exec L20111221A_1 '" & Label4.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure
            SQLCmd.CommandTimeout = 100000

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT5")
            DGV2.DataSource = ksDataSet.Tables("DT5")


        Catch ex As Exception
            MsgBox("ChkLoc: " & ex.Message)
            End
        End Try

        'If Label9.Text <> 0 Then
        '    MsgBox("條碼有錯誤!請檢查!")
        'End If

        If DGV2.RowCount > 0 Then
            Dim Red As Integer = 0
            For i As Integer = 0 To DGV2.RowCount - 1
                If (CInt(DGV2.Rows(i).Cells("目前儲位數").Value) + CInt(DGV2.Rows(i).Cells("現調庫數").Value)) > DGV2.Rows(i).Cells("最大數").Value Then
                    DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Red += 1
                End If
            Next

            If Red > 0 Then
                MsgBox("數量已大於該儲位最大數!", 48, "警告")
            End If
        End If

        DGV2.AutoResizeColumns()
    End Sub

    Private Sub DGV2_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV2.Sorted
        DGV2_Sorted()
    End Sub

    Private Sub DGV2_Sorted()

        If DGV2.RowCount > 0 Then
            Dim Red As Integer = 0
            For i As Integer = 0 To DGV2.RowCount - 1
                If (CInt(DGV2.Rows(i).Cells("目前儲位數").Value) + CInt(DGV2.Rows(i).Cells("現調庫數").Value)) > DGV2.Rows(i).Cells("最大數").Value Then
                    DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Red += 1
                End If
            Next
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView2.Rows.Count > 0 Then
            QryAdate()
            DoingSQL()
        End If
    End Sub

    Private Sub QryAdate()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        ADate = Format(Now, "yyyyMMdd")

        sql = "SELECT TOP 1 T0.DocNum FROM [@ChgLocMgn] T0 Order by T0.DocNum DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            If ADate = Microsoft.VisualBasic.Left(sqlReader.Item("DocNum"), 8) Then
                ADate = sqlReader.Item("DocNum") + 1
            Else
                ADate = ADate + "0001"
            End If
        Else
            ADate = ADate + "0001"
        End If
        sqlReader.Close()
    End Sub

    Private Sub DoingSQL()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        PBar1.Minimum = 0
        PBar1.Maximum = DataGridView2.Rows.Count - 1

        Try
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = "Update OSRN set U_M2 = (SELECT F5 FROM Z_KS_Reloc r WHERE OSRN.DistNumber = r.F4 AND r.F1='1') WHERE EXISTS (SELECT * FROM Z_KS_Reloc r WHERE OSRN.DistNumber = r.F4 AND r.F1='1')"
            SQLCmd.CommandText = "  UPDATE [OSRN] set [U_M2] = "
            SQLCmd.CommandText += "  (SELECT [F5] FROM [Z_KS_Reloc] r WHERE [OSRN].[DistNumber] = r.[F4] AND r.[F1]='1' AND ISNULL(r.[F3],0) <> '0' AND r.[F6] = '" & Label4.Text & "' ) WHERE EXISTS "
            SQLCmd.CommandText += "  (SELECT *    FROM [Z_KS_Reloc] r WHERE [OSRN].[DistNumber] = r.[F4] AND r.[F1]='1' AND ISNULL(r.[F3],0) <> '0' AND r.[F6] = '" & Label4.Text & "' )"
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            'SQLCmd.CommandText = " INSERT INTO [@ChgLocMgn] (DocNum,SRNType,Part,FromLoc,DistNumber,ItemCode,ItemName,ToLoc) SELECT @ADate, z.F1,z.F2,z.F3,z.F4,T1.ItemCode,T2.ItemName,z.F5 From  OSRN T1 inner join Z_KS_Reloc z ON T1.DistNumber = z.F4 AND z.F1='1' left join OITM T2 ON T1.ItemCode = T2.ItemCode "
            SQLCmd.CommandText = "  INSERT INTO [@ChgLocMgn] ([DocNum],[SRNType],[Part],[FromLoc],[DistNumber],[ItemCode],[ItemName],[ToLoc]) "
            SQLCmd.CommandText += " SELECT @ADate, z.[F1],z.[F2],z.[F3],z.[F4],T1.[ItemCode],T2.[ItemName],z.[F5] "
            SQLCmd.CommandText += "   FROM [OSRN] T1 INNER JOIN [Z_KS_Reloc] z  ON T1.[DistNumber] = z.[F4] AND z.[F1]='1' AND ISNULL(z.[F3],0) <> '0' AND z.[F6] = '" & Label4.Text & "' "
            SQLCmd.CommandText += "                  LEFT  JOIN [OITM]       T2 ON T1.[ItemCode] = T2.[ItemCode] "
            SQLCmd.Parameters.Clear()
            SQLCmd.Parameters.AddWithValue("@ADate", ADate)
            SQLCmd.ExecuteNonQuery()

            'SQLCmd.CommandText = "Update OBTN set U_M2 = (SELECT F5 FROM Z_KS_Reloc r WHERE OBTN.DistNumber = r.F4 AND r.F1='2') WHERE EXISTS (SELECT * FROM Z_KS_Reloc r WHERE OBTN.DistNumber = r.F4 AND r.F1='2')"
            SQLCmd.CommandText = "  UPDATE [OBTN] set [U_M2] = "
            SQLCmd.CommandText += "  (SELECT [F5] FROM [Z_KS_Reloc] r WHERE [OBTN].[DistNumber] = r.[F4] AND r.[F1]='2' AND ISNULL(r.[F3],0) <> '0' AND r.[F6] = '" & Label4.Text & "' ) WHERE EXISTS "
            SQLCmd.CommandText += "  (SELECT *    FROM [Z_KS_Reloc] r WHERE [OBTN].[DistNumber] = r.[F4] AND r.[F1]='2' AND ISNULL(r.[F3],0) <> '0' AND r.[F6] = '" & Label4.Text & "' )"

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            'SQLCmd.CommandText = " INSERT INTO [@ChgLocMgn] (DocNum,SRNType,Part,FromLoc,DistNumber,ItemCode,ItemName,ToLoc) SELECT @ADate, z.F1,z.F2,z.F3,z.F4,T1.ItemCode,T2.ItemName,z.F5 From  OBTN T1 inner join Z_KS_Reloc z ON T1.DistNumber = z.F4 AND z.F1='2' left join OITM T2 ON T1.ItemCode = T2.ItemCode "
            SQLCmd.CommandText = "  INSERT INTO [@ChgLocMgn] ([DocNum],[SRNType],[Part],[FromLoc],[DistNumber],[ItemCode],[ItemName],[ToLoc]) "
            SQLCmd.CommandText += " SELECT @ADate, z.[F1],z.[F2],z.[F3],z.[F4],T1.[ItemCode],T2.[ItemName],z.[F5] "
            SQLCmd.CommandText += "   FROM [OBTN] T1 INNER JOIN [Z_KS_Reloc] z  ON T1.[DistNumber] = z.[F4] AND z.[F1]='2' AND ISNULL(z.[F3],0) <> '0' AND z.[F6] = '" & Label4.Text & "' "
            SQLCmd.CommandText += "                  LEFT  JOIN [OITM]       T2 ON T1.[ItemCode] = T2.[ItemCode] "

            SQLCmd.Parameters.Clear()
            SQLCmd.Parameters.AddWithValue("@ADate", ADate)
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception

            If MessageBox.Show("更新失敗：" & vbCrLf & ex.Message & vbCrLf & "是否要重試?", "錯誤", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then
                DoingSQL()
            Else
                MsgBox("更新失敗", 16, "失敗")
                Exit Sub
            End If
            Exit Sub
        End Try

        MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate, MsgBoxStyle.OkOnly, "成功")

        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "DELETE FROM [Z_KS_Reloc] WHERE [F6] = '" & Label4.Text & "' "
        SQLCmd.ExecuteNonQuery()


        'dTable.Clear()
        'If locView.RowCount > 0 Then
        '    dTable.Clear()
        '    'DataGridView1.DataSource = dsPDAIn
        'End If
        If DataGridView1.RowCount > 0 Then
            dsPDAIn.Clear()
            'DataGridView1.DataSource = dsPDAIn
        End If
        If DataGridView2.RowCount > 0 Then
            dsPDAInGood.Clear()
            'DataGridView2.DataSource = dsPDAInGood
        End If
        ksDataSet.Tables("DT5").Clear()

        Button2.Enabled = False

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader1 As SqlDataReader
        Dim dsPDAIn01 As New DataTable
        Dim dsPDAIn02 As New DataTable
        Dim Q1 As Integer = 0
        Dim Q2 As Integer = 0
        Dim Name01 As DataColumn = New DataColumn("條碼")
        Dim Name02 As DataColumn = New DataColumn("條碼")
        Name01.DataType = System.Type.GetType("System.String")
        Name02.DataType = System.Type.GetType("System.String")
        dsPDAIn01.Columns.Add(Name01)
        dsPDAIn02.Columns.Add(Name02)

        PBar1.Minimum = 0
        PBar1.Maximum = DataGridView1.Rows.Count - 1

        For i As Integer = 0 To DataGridView1.RowCount - 1
            Try
                Select Case DataGridView1.Rows(i).Cells("作業別").Value
                    Case "1"
                        sql = "SELECT T0.DistNumber FROM [OSRN] T0 where T0.DistNumber = '" & DataGridView1.Rows(i).Cells("條碼").FormattedValue & "' "
                    Case "2"
                        sql = "SELECT T0.DistNumber FROM [OBTN] T0 where T0.DistNumber = '" & DataGridView1.Rows(i).Cells("條碼").FormattedValue & "' "
                End Select

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql

                sqlReader1 = SQLCmd.ExecuteReader
                sqlReader1.Read()

                If sqlReader1.HasRows() Then
                    Select Case DataGridView1.Rows(i).Cells("作業別").Value
                        Case "1"
                            Q1 = Q1 + 1
                            Dim Row(Q1) As DataRow
                            Row(Q1) = dsPDAIn01.NewRow
                            Row(Q1).Item("條碼") = DataGridView1.Rows(i).Cells("條碼").FormattedValue
                            dsPDAIn01.Rows.Add(Row(Q1))
                        Case "2"
                            Q1 = Q1 + 1
                            Dim Row(Q1) As DataRow
                            Row(Q1) = dsPDAIn01.NewRow
                            Row(Q1).Item("條碼") = DataGridView1.Rows(i).Cells("條碼").FormattedValue
                            dsPDAIn01.Rows.Add(Row(Q1))
                    End Select

                    sqlReader1.Close()
                Else
                    sqlReader1.Close()
                    Q2 = Q2 + 1
                    Dim Row(Q2) As DataRow
                    Row(Q2) = dsPDAIn02.NewRow
                    Row(Q2).Item("條碼") = DataGridView1.Rows(i).Cells("條碼").FormattedValue
                    dsPDAIn02.Rows.Add(Row(Q2))
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
                End
            End Try
            PBar1.Value = i
        Next
        DataGridView3.DataSource = dsPDAIn01
        DataGridView4.DataSource = dsPDAIn02

        Label12.Visible = True
        Label13.Visible = True
        DataGridView3.Visible = True
        DataGridView4.Visible = True
        Button5.Enabled = False

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataToExcel(DataGridView1, "")
    End Sub


    Private Sub 刪除暫存條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 刪除暫存條碼.Click
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "DELETE FROM [Z_KS_Reloc] WHERE [F6] = '" & Label4.Text & "' "
        SQLCmd.ExecuteNonQuery()

        MsgBox("完成")


    End Sub
End Class