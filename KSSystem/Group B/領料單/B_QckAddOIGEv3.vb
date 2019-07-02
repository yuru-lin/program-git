Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QckAddOIGEv3
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    'Dim ks2DataSetDGV As DataSet = New DataSet
    'Dim ks3DataSetDGV As DataSet = New DataSet

    Dim F1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet

    Dim dsPDAInGood As New DataTable
    Dim AnsHasRow As Boolean
    Dim Errors As Boolean
    Dim Errors1 As Byte

    Private Sub B_QckAddOIGEv3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Login.LogonUserName = "manager" Or Login.LogonUserName = "ks06" Or Login.LogonUserName = "KS06" Then
            T1Sid.Visible = True
            T1Quantity_2.Visible = True
            T1Quantity_3.Visible = True
            'T1DGV3_1.Visible = True
            T2Sid.Visible = True
            T2RB1.Visible = True
            T2RB2.Visible = True
            'T2SaveOut.Visible = True
            T2SaveODRF.Visible = True
            C2Mdy.Visible = True

            Label15.Visible = True
            TextBox1.Visible = True


        End If

        '倉儲
        If Login.LogonUserName = "ks09" Or Login.LogonUserName = "ks10" Or Login.LogonUserName = "ks16" Or _
           Login.LogonUserName = "KS09" Or Login.LogonUserName = "KS10" Or Login.LogonUserName = "KS16" Then
            T2RB2.Checked = True
            T2SaveOut.Visible = True
        End If

        '生產
        'If Login.LogonUserName = "ks06" Or Login.LogonUserName = "KS06" Or _
        If Login.LogonUserName = "ks14" Or Login.LogonUserName = "KS14" Then
            T2RB1.Checked = True
            T1Search.Enabled = False
            ExcelBut.Enabled = False
            T1Del.Enabled = False
            DocDate.Enabled = False
            Floor.Enabled = False
            Period.Enabled = False
            T1CB_F1.Enabled = False
            T2SaveODRF.Visible = True
            C2Mdy.Visible = True
        End If

        Label10.Text = ""    '是否重覆
        T1Sid.Text = ""
        T1OPDocNum.Text = ""
        T1U_CK02.Text = ""
        T1Quantity_1.Text = ""
        T1Quantity_2.Text = ""
        T1Quantity_3.Text = ""

        T1Save.Enabled = False


        T2Sid.Text = ""
        T2OPDocNum.Text = ""
        T2U_CK02.Text = ""


        'T1DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        'T1DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1   'Excel


        ExcelAddColumn()
        '列出區別
        T1CB_F1_All()
    End Sub

    Private Sub BtnToExcel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel1.Click

        DataToExcel(T1DGV3, "")

    End Sub


    Private Sub ExcelAddColumn()
        '--讀Excel檔   初始設定
        Dim NameGoodF1 As DataColumn = New DataColumn("F1")
        Dim NameGoodF2 As DataColumn = New DataColumn("F2")

        NameGoodF1.DataType = System.Type.GetType("System.String")
        NameGoodF2.DataType = System.Type.GetType("System.String")

        dsPDAInGood.Columns.Add(NameGoodF1)
        dsPDAInGood.Columns.Add(NameGoodF2)

    End Sub

    Private Sub T1DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV1.CellContentClick
        'DGV1內選取列資料 同步至 編輯區
        Dim C_OPDocNum As String
        Dim CU_CK02 As String

        If T1DGV1.RowCount = -1 Then
            Exit Sub
        End If

        T1U_CK02.Text = T1DGV1.CurrentRow.Cells("製單").Value

        C_OPDocNum = T1OPDocNum.Text
        CU_CK02 = T1U_CK02.Text

        T1_Check(C_OPDocNum, CU_CK02)

        T1DGV2_ListCnt2()

    End Sub

    Private Sub T1DGV2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV2.CellContentClick
        '
        T1DGV2_ListStatus()

    End Sub

    Private Sub T1DGV3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV3.CellContentClick
        '
        T1DGV3_ListStatus()

    End Sub

    Private Sub T1DGV1_DocNumCK02()
        '
        'T1OPDocNum.Text = ""
        'T1U_CK02.Text = ""
        If T1OPDocNum.Text <> "" And T1U_CK02.Text <> "" Then


        End If


    End Sub






    '--第一分頁
    Private Sub T1Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Search.Click
        '查詢製單
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        If Period.SelectedIndex = -1 Then
            MsgBox("請選擇時段!", 16, "錯誤")
            Period.Focus()
            Exit Sub
        End If

        T1DGV1_All()
        T1Sid_Update()

        '分時領料單號
        T1OPDocNum.Text = "領05" + Format(DocDate.Value.Date, "yyMMdd") + Format(Floor.SelectedIndex + 1, "0#") + Format(Period.SelectedIndex + 1, "0#")

    End Sub

    Private Function T1Sid_Add()
        '產生Sid
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [Sid] FROM [Z_KS_ODRFMain] ORDER BY [Sid] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Sid") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub T1Sid_Update()
        '更新Sid
        Dim i As Integer
        i = T1Sid_Add()
        If i = 0 Then
            MsgBox("載入Sid資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        T1Sid.Text = i

    End Sub


    Private Sub T1DGV1_All()
        '--查詢領料製單
        If T1DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("T1DGV1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT T0.[U_CK02] AS '製單', T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', SUM(T0.[Quantity]) AS '數量' "
            sql += "  FROM [Z_KS_SPicking] T0 "
            sql += " WHERE [DocDate] = '" & DocDate.Value.Date & "'   AND [Floor]  = '" & Floor.SelectedIndex & "' AND "
            sql += "       [Period]  = '" & Period.SelectedIndex & "' AND [Cancel] = 'Y' "
            sql += " GROUP BY T0.[U_CK02], T0.[ItemCode], T0.[ItemName] "
            sql += " ORDER BY 1, 2, 3 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV1")
            T1DGV1.DataSource = ks1DataSetDGV.Tables("T1DGV1")
            TransactionMonitor.Complete()

            T1DGV1_Display()

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub T1DGV1_Display()
        For Each column As DataGridViewColumn In T1DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next

        T1DGV1.AutoResizeColumns()
        T1DGV1.AllowUserToAddRows = False       'DataGridView 設定單元格不可新增
        T1DGV1.AllowUserToDeleteRows = False    'DataGridView 設定單元格不可刪除
        T1DGV1.ReadOnly = True                  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub ExcelBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelBut.Click
        '讀取Excel
        T1DGVExcel_In()


    End Sub

    Private Sub T1DGVExcel_In()
        '抓取Excel檔
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "Excel files(*.xls)|*.xls"    '只抓Excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        ' if you don't want to sho the header row (first row) in the grid
        ' use 'HDR=NO' in the string

        Dim strSQL As String = "SELECT * FROM [Sheet1$] "
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

        T1DGVExcel.DataSource = dTable
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()

        T1DGVExcelUP_Reloc2()
        T1CB_F1_All()

    End Sub

    Private Sub T1DGVExcelUP_Reloc2()
        '上傳 Excel 資料至 Z_KS_Reloc2
        Try

            Dim ksDataSet As DataSet = New DataSet

            Dim F1 As String
            Dim F2 As String

            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            SQLCmd.Connection = DBConn
            'SQLCmd.CommandText = "DELETE FROM [Z_KS_Reloc2] "
            'SQLCmd.ExecuteNonQuery()

            SQLCmd.CommandText = "INSERT INTO [Z_KS_Reloc2] (F1,F2) VALUES (@str_1,@str_2) "

            For i As Integer = 0 To T1DGVExcel.RowCount - 1
                F1 = T1DGVExcel.Rows(i).Cells("F1").Value
                F2 = T1DGVExcel.Rows(i).Cells("F2").Value

                SQLCmd.Parameters.Clear()
                SQLCmd.Parameters.AddWithValue("@str_1", F1)
                SQLCmd.Parameters.AddWithValue("@str_2", F2)
                SQLCmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub T1CB_F1_All()
        '列出區別
        Try
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            sql = " SELECT [F1] FROM [Z_KS_Reloc2] "
            sql += " GROUP BY [F1] "

            If ks1DataSet.Tables.Contains("F1") Then

                ks1DataSet.Tables("F1").Clear()

            End If

            F1 = New SqlDataAdapter(sql, DBConn)
            F1.Fill(ks1DataSet, "F1")
            T1CB_F1.DataSource = ks1DataSet.Tables("F1")
            T1CB_F1.DisplayMember = "F1"

            T1CB_F1.SelectedIndex = -1

            SQLCmd.Clone()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T1CB_F1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1CB_F1.SelectionChangeCommitted
        '選取區別
        T1DGV2_List()
        T1DGV3_Code()

        T1DGV2_ListStatus()
        T1DGV3_ListStatus()
        T1DGV2_ListCnt()

    End Sub

    Private Sub T1DGV2_List()
        '
        If T1DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("T1DGV2").Clear()
        End If
        Try

            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " SELECT T0.[F1] AS '區別',T1.[ItemCode] AS '存編',T3.[ItemName] AS '品名',SUM(T2.[Quantity]) AS '數量' ,COUNT(T2.[Quantity]) AS '件數' "
            SQLCmd.CommandText += "  FROM [Z_KS_Reloc2] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            SQLCmd.CommandText += "                        LEFT JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[ItemCode] = T2.[ItemCode] "
            SQLCmd.CommandText += "                        LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            SQLCmd.CommandText += " WHERE T0.[F1] = '" & T1CB_F1.Text & "' "
            SQLCmd.CommandText += " GROUP BY T0.[F1], T1.[ItemCode], T3.[ItemName], T2.[Quantity] "


            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            ' ''Dim sql As String
            ' ''Dim DBConn As SqlConnection = Login.DBConn
            ' ''Dim SQLCmd As SqlCommand = New SqlCommand
            '' ''Dim value As Integer = 3000

            '' ''Using TransactionMonitor As New System.Transactions.TransactionScope

            ' ''sql = " SELECT T0.[F1] AS '區別',T1.[ItemCode] AS '存編',T3.[ItemName] AS '品名',SUM(T2.[Quantity]) AS '數量' ,COUNT(T2.[Quantity]) AS '件數' "
            ' ''sql += "  FROM [Z_KS_Reloc2] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            ' ''sql += "                        LEFT JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[ItemCode] = T2.[ItemCode] "
            ' ''sql += "                        LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            ' ''sql += " WHERE T0.[F1] = '" & T1CB_F1.Text & "' "
            ' ''sql += " GROUP BY T0.[F1], T1.[ItemCode], T3.[ItemName], T2.[Quantity] "


            ' ''SQLCmd.Connection = DBConn
            '' 'SQLCmd.CommandTimeout = 800000
            ' ''SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV2")
            T1DGV2.DataSource = ks1DataSetDGV.Tables("T1DGV2")

            'TransactionMonitor.Complete()
            T1DGV2.AutoResizeColumns()
            T1DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T1DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T1DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯
            'End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub T1DGV2_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles T1DGV2.Sorted
        T1DGV2_ListStatus()
    End Sub

    Private Sub T1DGV2_ListStatus()
        '
        For i As Integer = 0 To T1DGV2.RowCount - 1

            If T1DGV2.Rows(i).Cells("數量").Value = 0 Then
                '標記數量 = 0 以黃底顯示
                T1DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

            ''Select Case T1DGV2.Rows(i).Cells("數量").Value
            ''    Case "0"    '標記作廢項目以黃底顯示
            ''        T1DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            ''        'Case "6"    '確認作廢項目以紅底顯示
            ''        '    T1DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
            ''End Select
        Next
        T1DGV2.ClearSelection()

    End Sub

    Private Sub T1DGV3_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles T1DGV3.Sorted
        T1DGV3_ListStatus()
    End Sub

    Private Sub T1DGV3_ListStatus()
        '
        For i As Integer = 0 To T1DGV3.RowCount - 1

            If T1DGV3.Rows(i).Cells("數量").Value = 0 Then
                '標記數量 = 0 以黃底顯示
                T1DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If

        Next
        T1DGV3.ClearSelection()

    End Sub


    Private Sub T1DGV2_ListCnt()
        '
        Dim Cnt As Integer = 0
        For i As Integer = 0 To T1DGV2.RowCount - 1
            If T1DGV2.Rows(i).Cells("數量").Value = 0 Then
                Cnt += 0 + 1
            End If
        Next

        Dim Cnt1 As Integer = 0
        For i As Integer = 0 To T1DGV2.RowCount - 1
            If T1DGV2.Rows(i).Cells("數量").Value > 0 Then
                Cnt1 += 0 + 1
            End If
        Next

        T1Quantity_1.Text = Cnt
        T1Quantity_2.Text = Cnt1
        T1Quantity_3.Text = T1DGV2.RowCount
        T1DGV3_1.Text = T1DGV3.RowCount

        T1DGV2_ListCnt2()

    End Sub

    Private Sub T1DGV2_ListCnt2()

        If T1Quantity_1.Text <> "" Then
            If T1Quantity_1.Text <> 0 Then
                T1Save.Enabled = False
                MsgBox("項目條碼有異常!", 16, "錯誤")
            Else
                'If AnsHasRow = False Then
                T1Save.Enabled = True
                'Else
                '    T1Save.Enabled = False
                'End If
            End If
        End If
    End Sub

    Private Sub T1DGV3_Code()
        '
        If T1DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("T1DGV3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            'Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT T1.[ItemCode] AS '存編',T3.[ItemName] AS '品名',T0.[F2] AS '條碼',T2.[Quantity] AS '數量' ,T1.[MnfDate] AS '製造日期' "
            sql += "  FROM [Z_KS_Reloc2] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            sql += "                        LEFT JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber]  AND T1.[ItemCode]  = T2.[ItemCode] "
            sql += "                        LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            sql += " WHERE T0.[F1] = '" & T1CB_F1.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV3")
            T1DGV3.DataSource = ks1DataSetDGV.Tables("T1DGV3")

            'TransactionMonitor.Complete()
            T1DGV3.AutoResizeColumns()
            T1DGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T1DGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T1DGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯
            'End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub T1Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Save.Click
        '
        If T1OPDocNum.Text = "" Then
            MsgBox("無排程單號無法存檔!", 16, "錯誤")
            Exit Sub
        End If

        If T1U_CK02.Text = "" Then
            MsgBox("無製造單號無法存檔!", 16, "錯誤")
            Exit Sub
        End If

        T1Save_UpDB()
        T1Sid_Update()

        T1Save.Enabled = False

    End Sub

    Private Sub T1Save_UpDB()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try

            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " INSERT INTO [Z_KS_ODRFMain] ([OPDocNum],[U_CK01],[U_CK02],[DocDate],[TaxDate],[OutLy],[Cancel]) VALUES ('" & T1OPDocNum.Text & "','5','" & T1U_CK02.Text & "','" & DocDate.Value.Date & "','" & DocDate.Value.Date & "','N','Y' ) "
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            'Try
            For i As Integer = 0 To T1DGV3.RowCount - 1

                SQLCmd.CommandText = " INSERT INTO [Z_KS_ODRFCode] ([SidNum],[OPDocNum],[U_CK02],[ItemCode],[ItemName],[DistNumber],[Quantity],[Cancel]) VALUES ('" & T1Sid.Text & "','" & T1OPDocNum.Text & "','" & T1U_CK02.Text & "','" & T1DGV3.Rows(i).Cells("存編").Value & "','" & T1DGV3.Rows(i).Cells("品名").Value & "','" & T1DGV3.Rows(i).Cells("條碼").Value & "','" & T1DGV3.Rows(i).Cells("數量").Value & "','Y' ) "
                SQLCmd.Parameters.Clear()
                SQLCmd.ExecuteNonQuery()

            Next
            'Catch ex As Exception
            'End Try

        Catch ex As Exception

            If MessageBox.Show("更新失敗：" & vbCrLf & ex.Message & vbCrLf & "是否要重試?", "錯誤", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then

                T1Save_UpDB()

            Else
                SQLCmd.CommandText = "  DELETE FROM [Z_KS_ODRFMain] WHERE [OPDocNum] = '" & T1OPDocNum.Text & "' AND [U_CK02] = '" & T1U_CK02.Text & "' AND [Cancel] = 'Y' "
                SQLCmd.CommandText += " DELETE FROM [Z_KS_ODRFCode] WHERE [OPDocNum] = '" & T1OPDocNum.Text & "' AND [U_CK02] = '" & T1U_CK02.Text & "' AND [Cancel] = 'Y' "
                SQLCmd.Parameters.Clear()
                SQLCmd.ExecuteNonQuery()
                MsgBox("更新失敗", 16, "失敗")

                Exit Sub

            End If
            Exit Sub
        End Try

        'SQLCmd.CommandText += "DELETE FROM [Z_KS_Reloc2] WHERE [F1] = '" & T1CB_F1.Text & "' "
        'SQLCmd.Parameters.Clear()
        'SQLCmd.ExecuteNonQuery()

        T1Del_CBF1()

        T1CB_F1_All()
        ks1DataSetDGV.Tables("T1DGV2").Clear()
        ks1DataSetDGV.Tables("T1DGV3").Clear()
        T1U_CK02.Text = ""
        T1Quantity_1.Text = ""

        'MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate, MsgBoxStyle.OkOnly, "成功")
    End Sub


    Private Function T1_Check(ByVal C_OPDocNum As String, ByVal CU_CK02 As String)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = " SELECT * FROM [Z_KS_ODRFMain] WHERE [OPDocNum] = '" & C_OPDocNum & "' AND [U_CK02] = '" & CU_CK02 & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            AnsHasRow = True
        Else
            AnsHasRow = False
        End If

        If AnsHasRow = True Then
            Label10.Text = "單號已上傳"
            Label10.ForeColor = Color.Red
        Else
            Label10.Text = ""
        End If

        sqlReader.Close()

        Return AnsHasRow

    End Function

    Private Sub T1Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Del.Click

        If T1CB_F1.SelectedIndex = -1 Then
            MsgBox("尚無選擇區別!", 16, "錯誤")
            Exit Sub
        End If

        T1Del.Enabled = False

        If T1Del.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區
                T1Del_CBF1()

            End If
        End If

        T1Del.Enabled = True
        T1CB_F1_All()
        ks1DataSetDGV.Tables("T1DGV2").Clear()
        ks1DataSetDGV.Tables("T1DGV3").Clear()
        T1Quantity_1.Text = ""


    End Sub

    Private Sub T1Del_CBF1()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "DELETE FROM [Z_KS_Reloc2] WHERE [F1] = '" & T1CB_F1.Text & "' "
        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

    End Sub








































    '第二頁


    Private Sub T2RB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2RB1.CheckedChanged, T2RB2.CheckedChanged
        '選擇單位
        If T2RB1.Checked = True Then
            Label9.Text = "生產"
            T2SaveODRF.Visible = True
            T2SaveOut.Visible = False
        Else
            Label9.Text = "倉儲"
            T2SaveODRF.Visible = False
            T2SaveOut.Visible = True
        End If

    End Sub

    Private Sub T2DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2DGV1.CellClick    ', T2DGV1.CellContentClick
        '查詢明細
        Dim Periods As Byte
        Dim DocEntry As String

        If T2DGV1.RowCount = -1 Then
            Exit Sub
        End If

        T2Sid.Text = T2DGV1.CurrentRow.Cells("Sid").Value
        T2OPDocNum.Text = T2DGV1.CurrentRow.Cells("排單").Value
        T2U_CK02.Text = T2DGV1.CurrentRow.Cells("製單").Value
        T2DocDate.Text = T2DGV1.CurrentRow.Cells("過帳").Value

        Periods = Microsoft.VisualBasic.Right(T2OPDocNum.Text, 2) - 1
        T2Period.SelectedIndex = Periods

        If T2DGV1.CurrentRow.Cells("草稿").Value.ToString = vbNullString Then
            DocEntry = ""
        Else
            DocEntry = T2DGV1.CurrentRow.Cells("草稿").Value
        End If

        ''T2Comments.Text = Format(T2DocDate.Value.Date, "MM/dd") + "  " + T2DGV1.CurrentRow.Cells("排單").Value + "  " + T2DGV1.CurrentRow.Cells("製單").Value

        If T2RB1.Checked = True Then
            '生產
            T2DGV2_All()
            If DocEntry <> "" Then
                T2SaveODRF.Enabled = False
            Else
                T2SaveODRF.Enabled = True
            End If

        Else
            '倉儲
            T2DGV2_All()
            T2DGV3_All()
            If DocEntry <> "" Then
                T2SaveOut.Enabled = True
            Else
                T2SaveOut.Enabled = False
            End If

        End If

        C2Mdy_Erorr()


        MsgBox("查詢完成")

    End Sub

    Private Sub T2Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Search.Click
        '查詢待轉草稿單
        T2DGV1_All()

        If T2DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV2").Clear()
        End If

        If T2DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV3").Clear()
        End If


        MsgBox("查詢完成")

    End Sub

    Private Sub T2SaveODRF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2SaveODRF.Click
        '回存待轉草稿單至 B1

        Editor_Error()

        If Errors = False Then
            Select Case Errors1
                Case "1" : MsgBox("無排程單號無法存檔!", 16, "錯誤")
                Case "2" : MsgBox("無製造單號無法存檔!", 16, "錯誤")
                Case Else
            End Select

            Exit Sub
        End If

        T2DGV2_Save()

    End Sub

    Private Sub T2SaveOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2SaveOut.Click
        '回存草稿單條碼至 待出庫條碼區

        If T2DGV3.RowCount = 0 Then
            MsgBox("沒有任何條碼可以上傳!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        Editor_Error()

        If Errors = False Then
            Select Case Errors1
                Case "1" : MsgBox("無排程單號無法存檔!", 16, "錯誤")
                Case "2" : MsgBox("無製造單號無法存檔!", 16, "錯誤")
                Case Else
            End Select

            Exit Sub
        End If

        T2DGV3_Save()

    End Sub

    Private Sub Editor_Error()

        Errors = False

        If T2OPDocNum.Text = "" Then
            Errors1 = "1"
            'MsgBox("無排程單號無法存檔!", 16, "錯誤")
            Exit Sub
        End If

        If T2U_CK02.Text = "" Then
            Errors1 = "2"
            'MsgBox("無製造單號無法存檔!", 16, "錯誤")
            Exit Sub
        End If

        Errors = True

    End Sub






    Private Sub T2DGV1_All()
        '--查詢
        If T2DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " SELECT [Sid] AS 'Sid',[OPDocNum] AS '排單',[U_CK02] AS '製單',[DocEntry] AS '草稿',[DocDate] AS '過帳',[TaxDate] AS '文件',[Comments] AS '備註' ,[Cancel] AS 'Cancel' "
            sql += "  FROM [Z_KS_ODRFMain] "
            sql += " WHERE [OutLy] = 'N' AND [Cancel] In ('Y','S') "

            'If T2RB1.Checked = True Then
            '    '生產
            '    sql += " WHERE [OutLy] = 'N' AND [Cancel] = 'Y' "
            'Else
            '    '倉儲
            '    sql += " WHERE [OutLy] = 'N' AND [Cancel] = 'S' "
            'End If

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV1")
            T2DGV1.DataSource = ks1DataSetDGV.Tables("T2DGV1")
            TransactionMonitor.Complete()

            T2DGV1_Display()

        End Using

        'MsgBox("查詢完成")

    End Sub

    Private Sub T2DGV1_Display()
        For Each column As DataGridViewColumn In T2DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "Sid" : column.HeaderText = "Sid" : column.DisplayIndex = 0 ': column.Visible = False
                Case "排單" : column.HeaderText = "排單" : column.DisplayIndex = 1
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 2
                Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 3
                Case "過帳" : column.HeaderText = "過帳" : column.DisplayIndex = 4 : column.Visible = False
                Case "文件" : column.HeaderText = "文件" : column.DisplayIndex = 5 : column.Visible = False
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 6 : column.Visible = False
                Case "Cancel" : column.HeaderText = "Cancel" : column.DisplayIndex = 7 : column.Visible = False

                Case Else
                    column.Visible = False
            End Select
        Next

        T2DGV1.AutoResizeColumns()
        T2DGV1.AllowUserToAddRows = False       'DataGridView 設定單元格不可新增
        T2DGV1.AllowUserToDeleteRows = False    'DataGridView 設定單元格不可刪除
        T2DGV1.ReadOnly = True                  'DataGridView 設定單元格不可編輯

    End Sub


    Private Sub T2DGV2_All()
        '--查詢表身
        If T2DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [SidNum] AS 'Sid',[ItemCode] AS '存編',[ItemName] AS '品名',SUM([Quantity]) AS '數量' "
            sql += "  FROM [Z_KS_ODRFCode] "
            sql += " WHERE [SidNum] = '" & T2DGV1.CurrentRow.Cells("Sid").Value & "' AND [OPDocNum] = '" & T2DGV1.CurrentRow.Cells("排單").Value & "' AND [U_CK02] = '" & T2DGV1.CurrentRow.Cells("製單").Value & "' AND [Cancel] = 'Y' "
            sql += " GROUP BY [SidNum] ,[ItemCode] ,[ItemName] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV2")
            T2DGV2.DataSource = ks1DataSetDGV.Tables("T2DGV2")
            TransactionMonitor.Complete()

            T2DGV2_Display()

        End Using

        'MsgBox("查詢完成")

    End Sub

    Private Sub T2DGV2_Display()
        For Each column As DataGridViewColumn In T2DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "Sid" : column.HeaderText = "Sid" : column.DisplayIndex = 0
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next

        T2DGV2.AutoResizeColumns()
        T2DGV2.AllowUserToAddRows = False       'DataGridView 設定單元格不可新增
        T2DGV2.AllowUserToDeleteRows = False    'DataGridView 設定單元格不可刪除
        T2DGV2.ReadOnly = True                  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub T2DGV3_All()
        '--查詢明細
        If T2DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [ItemCode] AS '存編',[ItemName] AS '品名',SUM([Quantity]) AS '數量' "
            'sql += "  FROM [Z_KS_ODRFCode] "
            'sql += " WHERE [OPDocNum] = '" & T2DGV1.CurrentRow.Cells("排單").Value & "' AND [U_CK02] = '" & T2DGV1.CurrentRow.Cells("製單").Value & "' AND [Cancel] = 'Y' "
            'sql += " GROUP BY [ItemCode] ,[ItemName] "

            sql = " SELECT S0.[ItemCode] AS 'OB01', T0.[ItemName] AS 'OB02', T0.[DistNumber] AS 'OB03', T1.[U_M2] AS 'OB04', S0.[LineNum]  AS 'OB09' "
            sql += "  FROM [DRF1] S0 INNER JOIN [Z_KS_ODRFCode] T0 ON S0.[ItemCode]   = T0.[ItemCode]   "
            sql += "                 INNER JOIN [OSRN]          T1 ON T0.[DistNumber] = T1.[DistNumber] "
            sql += "                 INNER JOIN [OSRQ]          T2 ON T0.[ItemCode]   = T2.[ItemCode]    AND T1.[SysNumber] = T2.[SysNumber]"
            sql += "  WHERE S0.[DocEntry] = '" & T2DGV1.CurrentRow.Cells("草稿").Value & "' AND "
            sql += "        T0.[SidNum]   = '" & T2DGV1.CurrentRow.Cells("Sid").Value & "'  AND "
            sql += "        T0.[OPDocNum] = '" & T2DGV1.CurrentRow.Cells("排單").Value & "' AND "
            sql += "        T0.[U_CK02]   = '" & T2DGV1.CurrentRow.Cells("製單").Value & "' AND [Cancel] = 'Y' "
            sql += "  ORDER BY 5, 3 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV3")
            T2DGV3.DataSource = ks1DataSetDGV.Tables("T2DGV3")
            TransactionMonitor.Complete()

            T2DGV3_Display()

        End Using

        'MsgBox("查詢完成")

    End Sub

    Private Sub T2DGV3_Display()
        For Each column As DataGridViewColumn In T2DGV3.Columns
            column.Visible = True

            Select Case column.Name
                Case "OB01" : column.HeaderText = "OB01" : column.DisplayIndex = 0
                Case "OB02" : column.HeaderText = "OB02" : column.DisplayIndex = 1
                Case "OB03" : column.HeaderText = "OB03" : column.DisplayIndex = 2
                Case "OB04" : column.HeaderText = "OB04" : column.DisplayIndex = 3
                Case "OB09" : column.HeaderText = "OB09" : column.DisplayIndex = 4
                Case Else
                    column.Visible = False
            End Select
        Next

        T2DGV3.AutoResizeColumns()
        T2DGV3.AllowUserToAddRows = False       'DataGridView 設定單元格不可新增
        T2DGV3.AllowUserToDeleteRows = False    'DataGridView 設定單元格不可刪除
        T2DGV3.ReadOnly = True                  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub T2DGV2_Save()
        '回存草稿
        If T2DGV2.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oDraft As SAPbobsCOM.Documents
        Dim X As Integer = 0
        Dim RetVal As Long

        oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)

        oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oInventoryGenExit
        oDraft.DocDate = T2DocDate.Value.Date
        oDraft.TaxDate = T2DocDate.Value.Date
        oDraft.UserFields.Fields.Item("U_CK01").Value = "5"
        oDraft.UserFields.Fields.Item("U_CK02").Value = T2U_CK02.Text
        oDraft.Comments = T2OPDocNum.Text + "  " + T2Period.Text + "  " + T2Comments.Text

        For i As Integer = 0 To T2DGV2.RowCount - 1
            If T2DGV2.Rows(i).Cells("數量").Value > 0 Then
                oDraft.Lines.SetCurrentLine(X)
                oDraft.Lines.ItemCode = T2DGV2.Rows(i).Cells("存編").FormattedValue   '存編
                oDraft.Lines.Quantity = T2DGV2.Rows(i).Cells("數量").FormattedValue   '數量
                oDraft.Lines.Add()
                X = X + 1
            End If

        Next
        RetVal = oDraft.Add()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        Dim DocEntry As Integer
        DocEntry = Login.oCompany.GetNewObjectKey()

        '回存 草稿單號 至 [Z_KS_ODRFMain].[DocEntry]
        Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        SQLCmd2.Connection = DBConn2
        SQLCmd2.CommandText = " UPDATE [Z_KS_ODRFMain] SET [DocEntry] = '" & DocEntry & "', [Cancel] = 'S' WHERE [Sid] = '" & T2Sid.Text & "' "
        SQLCmd2.ExecuteNonQuery()

        '重新查詢
        T2DGV1_All()
        ks1DataSetDGV.Tables("T2DGV2").Clear()
        T2Sid.Text = ""
        T2OPDocNum.Text = ""
        T2U_CK02.Text = ""
        T2Sid.Text = ""

        T2Period.SelectedIndex = -1

        MsgBox("新增至B1完成!!" + vbCrLf + "草稿單號：" & DocEntry, 64, "完成")

    End Sub

    Private Sub T2DGV3_Save()
        '回存條碼
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim OB12Date As Date = Today

        Try
            For i As Integer = 0 To T2DGV3.RowCount - 1

                'OB05(數量)     = 1  
                'OB07(單別)     = 1 :領料出庫  
                'OB08(草稿單號) = T2DGV1.CurrentRow.Cells("草稿").Value  
                'OB10(狀態)     = 3 :已清點
                'OB12(清點時期) = 上傳日期 Dim OB12Date As Date = Today 系統日期

                sql = "  INSERT INTO [@ksOBList] ([OB01],[OB02],[OB03],[OB04],[OB05],[OB07],[OB08],[OB09],[OB10],[OB12]) VALUES ("
                sql += " '" & T2DGV3.Rows(i).Cells("OB01").Value & "'    , " ' 1
                sql += " '" & T2DGV3.Rows(i).Cells("OB02").Value & "'    , " ' 2
                sql += " '" & T2DGV3.Rows(i).Cells("OB03").Value & "'    , " ' 3
                sql += " '" & T2DGV3.Rows(i).Cells("OB04").Value & "'    , " ' 4
                sql += " '1'                                             , " ' 5
                sql += " '1'                                             , " ' 7
                sql += " '" & T2DGV1.CurrentRow.Cells("草稿").Value & "' , " ' 8
                sql += " '" & T2DGV3.Rows(i).Cells("OB09").Value & "'    , " ' 9
                sql += " '3'                                             , " '10
                sql += " '" & OB12Date & "'                              ) " '12
                'sql += " WHERE [DocDate] = '" & T2DGV3.Value.Date & "' AND [Sid] = '" & T1DGV1.Rows(i).Cells("Sid").Value & "' AND [Cancel] = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("存檔失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '[Z_KS_ODRFCode].[Cancel] = S 上傳至 [@ksOBList]
        Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        SQLCmd2.Connection = DBConn2
        SQLCmd2.CommandText = "  UPDATE [Z_KS_ODRFMain] SET [OutLy]  = 'Y' WHERE [Sid]    = '" & T2Sid.Text & "' "
        SQLCmd2.CommandText += " UPDATE [Z_KS_ODRFCode] SET [Cancel] = 'S' WHERE [SidNum] = '" & T2Sid.Text & "' AND [OPDocNum] = '" & T2DGV1.CurrentRow.Cells("排單").Value & "' AND [U_CK02] = '" & T2DGV1.CurrentRow.Cells("製單").Value & "' AND [Cancel] = 'Y' "
        SQLCmd2.ExecuteNonQuery()

        '重新查詢
        T2DGV1_All()
        ks1DataSetDGV.Tables("T2DGV2").Clear()
        ks1DataSetDGV.Tables("T2DGV3").Clear()
        T2OPDocNum.Text = ""
        T2U_CK02.Text = ""
        T2Sid.Text = ""

        MsgBox("存檔完成!", 64, "成功")

    End Sub




    'Private Sub ClearAll()
    '    ProductType.SelectedIndex = -1
    '    CK02.Text = ""
    '    Comm.Text = ""
    '    DocDate.Value = Today
    '    TaxDate.Value = DocDate.Value.Date.AddDays(1)
    '    If DGV1.RowCount > 0 Then
    '        dTable.Clear()
    '    End If
    'End Sub


    'Private Sub C2Mdy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C2Mdy.CheckedChanged

    'End Sub

    Private Sub C2Mdy_Erorr()

        If T2DGV1.RowCount <= 0 Then
            MsgBox("無資料!，無法修改!!", 16, "錯誤")
            C2Mdy.Checked = False
            Exit Sub
        End If

        Dim T2草稿 As String
        If T2DGV1.CurrentRow.Cells("草稿").Value.ToString = vbNullString Then
            T2草稿 = ""
        Else
            T2草稿 = "1"
        End If

        'T2草稿 = T2DGV1.CurrentRow.Cells("草稿").Value

        If T2草稿 = "" Then
            'C2Mdy.Enabled = True
            If C2Mdy.Checked = True Then
                Label13.Visible = True
                Label14.Visible = True
                TB2OPDocNum.Visible = True
                TB2U_CK02.Visible = True
                T2Save.Visible = True

                TB2OPDocNum.Text = T2DGV1.CurrentRow.Cells("排單").Value
                TB2U_CK02.Text = T2DGV1.CurrentRow.Cells("製單").Value

            Else
                Label13.Visible = False
                Label14.Visible = False
                TB2OPDocNum.Visible = False
                TB2U_CK02.Visible = False
                T2Save.Visible = False
            End If
        Else

            Label13.Visible = False
            Label14.Visible = False
            TB2OPDocNum.Visible = False
            TB2U_CK02.Visible = False
            T2Save.Visible = False
            'C2Mdy.Enabled = False
        End If


    End Sub

    Private Sub T2Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Save.Click

        Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        SQLCmd2.Connection = DBConn2
        SQLCmd2.CommandText = "  UPDATE [Z_KS_ODRFMain] SET [OPDocNum]  = '" & TB2OPDocNum.Text & "' ,[U_CK02] = '" & TB2U_CK02.Text & "' WHERE [Sid]    = '" & T2Sid.Text & "' AND [Cancel] = 'Y' "
        SQLCmd2.CommandText += " UPDATE [Z_KS_ODRFCode] SET [OPDocNum]  = '" & TB2OPDocNum.Text & "' ,[U_CK02] = '" & TB2U_CK02.Text & "' WHERE [SidNum] = '" & T2Sid.Text & "' AND [Cancel] = 'Y' "
        SQLCmd2.ExecuteNonQuery()

        T2DGV1_All()

        If T2DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV2").Clear()
        End If

        T2Sid.Text = ""
        T2OPDocNum.Text = ""
        T2U_CK02.Text = ""


    End Sub


    Private Sub T2Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Del.Click

        If T2DGV1.CurrentRow.Cells("草稿").Value.ToString = vbNullString Or Login.LogonUserName = "manager" Then

            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                Dim DBConn2 As SqlConnection = Login.DBConn
                Dim SQLCmd2 As SqlCommand = New SqlCommand

                SQLCmd2.Connection = DBConn2
                SQLCmd2.CommandText = "  UPDATE [Z_KS_ODRFMain] SET [Cancel] = 'D' WHERE [Sid]    = '" & T2Sid.Text & "' AND [Cancel] = 'Y' "
                SQLCmd2.CommandText += " UPDATE [Z_KS_ODRFCode] SET [Cancel] = 'D' WHERE [SidNum] = '" & T2Sid.Text & "' AND [Cancel] = 'Y' "
                SQLCmd2.ExecuteNonQuery()
                T2DGV1_All()

                If T2DGV2.RowCount > 0 Then
                    ks1DataSetDGV.Tables("T2DGV2").Clear()
                End If

                T2Sid.Text = ""
                T2OPDocNum.Text = ""
                T2U_CK02.Text = ""

            End If
        Else
            MsgBox("資料已上傳!，無法刪除!!", 16, "錯誤")
            Exit Sub
        End If
    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '
        T2DGV31_Save()

    End Sub

    Private Sub T2DGV31_Save()
        '回存條碼
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "  DECLARE @DocEntry varchar(10)"
        sql += " DECLARE @SidNum   varchar(10)"
        sql += " set nocount on	"
        sql += " set @DocEntry = '" & TextBox1.Text & "'"

        sql += " SELECT @SidNum = [Sid]"
        sql += "   FROM [Z_KS_ODRFMain]"
        sql += "  WHERE [DocEntry] = @DocEntry"

        sql += " UPDATE [Z_KS_ODRFMain] SET [OutLy]  = 'N' WHERE [DocEntry] = @DocEntry"
        sql += " UPDATE [Z_KS_ODRFCode] SET [Cancel] = 'Y' WHERE [SidNum]   = @SidNum"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.ExecuteNonQuery()

        T2DGV1_All()

        If T2DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV2").Clear()
        End If

        If T2DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("T2DGV3").Clear()
        End If

        TextBox1.Text = ""

        MsgBox("更新完成，請重新回存條碼!", 64, "成功")

    End Sub




    '' ''Private Sub T2DGV11_All()
    '' ''    '--查詢
    '' ''    If T2DGV1.RowCount > 0 Then
    '' ''        ks1DataSetDGV.Tables("T2DGV1").Clear()
    '' ''    End If

    '' ''    Dim sql As String
    '' ''    Dim DBConn As SqlConnection = Login.DBConn
    '' ''    Dim SQLCmd As SqlCommand = New SqlCommand
    '' ''    Using TransactionMonitor As New System.Transactions.TransactionScope


    '' ''        sql = " SELECT [Sid] AS 'Sid',[OPDocNum] AS '排單',[U_CK02] AS '製單',[DocEntry] AS '草稿',[DocDate] AS '過帳',[TaxDate] AS '文件',[Comments] AS '備註' ,[Cancel] AS 'Cancel' "
    '' ''        sql += "  FROM [Z_KS_ODRFMain] "
    '' ''        sql += " WHERE [OutLy] = 'N' AND [Cancel] In ('Y','S') "

    '' ''        'If T2RB1.Checked = True Then
    '' ''        '    '生產
    '' ''        '    sql += " WHERE [OutLy] = 'N' AND [Cancel] = 'Y' "
    '' ''        'Else
    '' ''        '    '倉儲
    '' ''        '    sql += " WHERE [OutLy] = 'N' AND [Cancel] = 'S' "
    '' ''        'End If

    '' ''        SQLCmd.Connection = DBConn
    '' ''        SQLCmd.CommandText = sql

    '' ''        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
    '' ''        DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV1")
    '' ''        T2DGV1.DataSource = ks1DataSetDGV.Tables("T2DGV1")
    '' ''        TransactionMonitor.Complete()

    '' ''        T2DGV1_Display()

    '' ''    End Using

    '' ''    'MsgBox("查詢完成")

    '' ''End Sub

    '' ''Private Sub T2DGV11_Display()
    '' ''    For Each column As DataGridViewColumn In T2DGV1.Columns
    '' ''        column.Visible = True

    '' ''        Select Case column.Name
    '' ''            Case "Sid" : column.HeaderText = "Sid" : column.DisplayIndex = 0 ': column.Visible = False
    '' ''            Case "排單" : column.HeaderText = "排單" : column.DisplayIndex = 1
    '' ''            Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 2
    '' ''            Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 3
    '' ''            Case "過帳" : column.HeaderText = "過帳" : column.DisplayIndex = 4 : column.Visible = False
    '' ''            Case "文件" : column.HeaderText = "文件" : column.DisplayIndex = 5 : column.Visible = False
    '' ''            Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 6 : column.Visible = False
    '' ''            Case "Cancel" : column.HeaderText = "Cancel" : column.DisplayIndex = 7 : column.Visible = False

    '' ''            Case Else
    '' ''                column.Visible = False
    '' ''        End Select
    '' ''    Next

    '' ''    T2DGV1.AutoResizeColumns()
    '' ''    T2DGV1.AllowUserToAddRows = False       'DataGridView 設定單元格不可新增
    '' ''    T2DGV1.AllowUserToDeleteRows = False    'DataGridView 設定單元格不可刪除
    '' ''    T2DGV1.ReadOnly = True                  'DataGridView 設定單元格不可編輯

    '' ''End Sub


 
End Class


