Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_OSPdata
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Dim ks3DataSetDGV As DataSet = New DataSet

    Dim ks3DataSet As DataSet = New DataSet
    Dim ks3DataAdapter As SqlDataAdapter

    Private Sub B_OrderPicking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '--開啟程式預設值
        Floor.SelectedIndex = -1
        CategoryName_2.SelectedIndex = -1
        AgainSearch.Enabled = False  '關閉重查資料按鈕

        '--第1分頁起--
        AddBut_0.Enabled = False     '關閉新增按鈕
        MdyBut_0.Enabled = False     '關閉修改按鈕
        UpdateBut_0.Enabled = False  '關閉更新按鈕
        DelBut_0.Enabled = False     '關閉刪除按鈕

        'LineNum_0.Enabled = False    '永不開啟
        Order_0.Enabled = False
        CardCode_0.Enabled = False
        CardName_0.Enabled = False

        LineNum_0.Text = ""
        Order_0.Text = ""
        CardCode_0.Text = ""
        CardName_0.Text = ""
        '--第1分頁止--
        '----第2分頁起--
        AddBut_1.Enabled = False     '關閉新增按鈕
        MdyBut_1.Enabled = False     '關閉修改按鈕
        UpdateBut_1.Enabled = False  '關閉更新按鈕
        DelBut_1.Enabled = False     '關閉刪除按鈕

        'LineNum_1.Enabled = False    '永不開啟
        Order_1.Enabled = False
        CategoryName_1.Enabled = False

        LineNum_1.Text = ""
        Order_1.Text = ""
        CategoryName_1.Text = ""
        '----第2分頁止--
        '------第3分頁起--
        AddBut_2.Enabled = False     '關閉新增按鈕
        MdyBut_2.Enabled = False     '關閉修改按鈕
        UpdateBut_2.Enabled = False  '關閉更新按鈕
        DelBut_2.Enabled = False     '關閉刪除按鈕

        'LineNum_0.Enabled = False   '永不開啟
        CategoryName_2.Enabled = False
        Order_2.Enabled = False
        ItemCode_2.Enabled = False
        ItemName_2.Enabled = False
        Plate_H_2.Enabled = False
        Weight_2.Enabled = False

        ItemCode_2.Text = ""
        ItemName_2.Text = ""
        Plate_H_2.Text = ""
        Weight_2.Text = ""
        '------第3分頁止--
    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        '查詢資料按鈕

        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        Search.Enabled = False       '關閉查詢資料按鈕
        Floor.Enabled = False        '關閉樓層選擇
        AgainSearch.Enabled = True   '開啟重查資料按鈕

        '--第1分頁起--
        AddBut_0.Enabled = True      '開啟新增按鈕
        MdyBut_0.Enabled = True      '開啟修改按鈕
        UpdateBut_0.Enabled = False  '關閉更新按鈕
        DelBut_0.Enabled = True      '開啟刪除按鈕

        'LineNum_0.Enabled = False   '永不開啟
        Order_0.Enabled = True
        CardCode_0.Enabled = True
        CardName_0.Enabled = True

        CardCode_0.Text = ""
        CardName_0.Text = ""
        '--第1分頁止--
        '----第2分頁起--
        AddBut_1.Enabled = True      '開啟新增按鈕
        MdyBut_1.Enabled = True      '開啟修改按鈕
        UpdateBut_1.Enabled = False  '關閉更新按鈕
        DelBut_1.Enabled = True      '開啟刪除按鈕

        'LineNum_0.Enabled = False   '永不開啟
        Order_1.Enabled = True
        CategoryName_1.Enabled = True

        CategoryName_1.Text = ""
        '----第2分頁止--
        '------第3分頁起--
        AddBut_2.Enabled = True      '開啟新增按鈕
        MdyBut_2.Enabled = True      '開啟修改按鈕
        UpdateBut_2.Enabled = False  '關閉更新按鈕
        DelBut_2.Enabled = True      '開啟刪除按鈕

        'LineNum_0.Enabled = False   '永不開啟
        CategoryName_2.Enabled = True
        Order_2.Enabled = True
        ItemCode_2.Enabled = True
        ItemName_2.Enabled = True
        Plate_H_2.Enabled = True
        Weight_2.Enabled = True

        SPdata2CategoryName()
        ItemCode_2.Text = ""
        ItemName_2.Text = ""
        Plate_H_2.Text = ""
        Weight_2.Text = ""
        '------第3分頁止--

        CategoryName_2.SelectedIndex = 0

        SQLSPdata0Display()          '查詢客戶
        SQLSPdata1Display()          '查詢類別
        SQLSPdata2Display()          '查詢類別

        SPdata0LO() '第1分頁更新類別列號順序
        SPdata1LO() '第2分頁更新類別列號順序
        SPdata2LO() '第3分頁更新類別列號順序
 

    End Sub

    Private Sub AgainSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgainSearch.Click
        '重查資料按鈕
        Search.Enabled = True        '開啟查詢資料按鈕
        Floor.Enabled = True         '開啟樓層選擇
        AgainSearch.Enabled = False  '關閉重查資料按鈕
        Floor.SelectedIndex = -1

        '--第1分頁起--
        AddBut_0.Enabled = False     '關閉新增按鈕
        MdyBut_0.Enabled = False     '關閉修改按鈕
        UpdateBut_0.Enabled = False  '關閉更新按鈕
        DelBut_0.Enabled = False     '關閉刪除按鈕

        'LineNum_0.Enabled = False    '永不開啟
        Order_0.Enabled = False
        CardCode_0.Enabled = False
        CardName_0.Enabled = False

        LineNum_0.Text = ""
        Order_0.Text = ""
        CardCode_0.Text = ""
        CardName_0.Text = ""
        '--第1分頁止--
        '----第2分頁起--
        AddBut_1.Enabled = False     '關閉新增按鈕
        MdyBut_1.Enabled = False     '關閉修改按鈕
        UpdateBut_1.Enabled = False  '關閉更新按鈕
        DelBut_1.Enabled = False     '關閉刪除按鈕

        'LineNum_0.Enabled = False    '永不開啟
        Order_1.Enabled = False
        CategoryName_1.Enabled = False

        LineNum_1.Text = ""
        Order_1.Text = ""
        CategoryName_1.Text = ""
        '----第2分頁止--
        '------第3分頁起--
        AddBut_2.Enabled = False     '關閉新增按鈕
        MdyBut_2.Enabled = False     '關閉修改按鈕
        UpdateBut_2.Enabled = False  '關閉更新按鈕
        DelBut_2.Enabled = False     '關閉刪除按鈕

        'LineNum_0.Enabled = False   '永不開啟
        CategoryName_2.Enabled = False
        Order_2.Enabled = False
        ItemCode_2.Enabled = False
        ItemName_2.Enabled = False
        Plate_H_2.Enabled = False
        Weight_2.Enabled = False

        ItemCode_2.Text = ""
        ItemName_2.Text = ""
        Plate_H_2.Text = ""
        Weight_2.Text = ""
        '------第3分頁止--


        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If DGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("DT2").Clear()
        End If

        If DGV3.RowCount > 0 Then
            ks3DataSetDGV.Tables("DT3").Clear()
        End If

    End Sub

    '--第1分頁起--

    Private Sub AddBut_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBut_0.Click
        '第1分頁新增按鈕

        If Order_0.Text = "" Then
            MsgBox("順序未輸入!", 16, "錯誤")
            Order_0.Focus()
            Exit Sub
        End If

        If CardCode_0.Text = "" Then
            MsgBox("客編未輸入!", 16, "錯誤")
            CardCode_0.Focus()
            Exit Sub
        End If

        If CardName_0.Text = "" Then
            MsgBox("客戶未輸入!", 16, "錯誤")
            CardName_0.Focus()
            Exit Sub
        End If

        If AliasName_0.Text = "" Then
            MsgBox("別名未輸入!", 16, "錯誤")
            AliasName_0.Focus()
            Exit Sub
        End If



        Dim Row As DataRow
        Row = ks1DataSetDGV.Tables("DT1").NewRow
        Row.Item("編號") = SidT0.Text
        Row.Item("列號") = LineNum_0.Text
        Row.Item("順序") = Order_0.Text
        Row.Item("客編") = CardCode_0.Text
        Row.Item("客戶") = CardName_0.Text
        Row.Item("別名") = AliasName_0.Text

        ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            sql = "INSERT INTO [Z_KS_SPdata0] ([Floor] ,[LineNum] ,[Order] ,[CardCode] ,[CardName] ,[Cancel] ,[AliasName]) VALUES " & _
                  " ('4','" & LineNum_0.Text & "','" & Order_0.Text & "','" & CardCode_0.Text & "', '" & CardName_0.Text & "', 'Y', '" & AliasName_0.Text & "' )"
            '" ('" & Floor.SelectedIndex & "','" & LineNum_0.Text & "','" & Order_0.Text & "','" & CardCode_0.Text & "', '" & CardName_0.Text & "', 'Y' )"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '清空資料
        'LineNum_0.Text = ""
        'Order_0.Text = ""
        CardCode_0.Text = ""
        CardName_0.Text = ""
        AliasName_0.Text = ""

        SPdata0LO()

    End Sub

    Private Sub MdyBut_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MdyBut_0.Click
        '第1分頁修改按鈕
        AddBut_0.Enabled = False     '關閉新增按鈕
        MdyBut_0.Enabled = False     '關閉修改按鈕
        UpdateBut_0.Enabled = True   '開啟更新按鈕
        DelBut_0.Enabled = False     '關閉刪除按鈕

    End Sub

    Private Sub UpdateBut_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBut_0.Click
        '第1分頁更新按鈕

        If Order_0.Text = "" Then
            MsgBox("順序未輸入!", 16, "錯誤")
            Order_0.Focus()
            Exit Sub
        End If

        If CardCode_0.Text = "" Then
            MsgBox("客編未輸入!", 16, "錯誤")
            CardCode_0.Focus()
            Exit Sub
        End If

        If CardName_0.Text = "" Then
            MsgBox("客戶未輸入!", 16, "錯誤")
            CardName_0.Focus()
            Exit Sub
        End If

        If AliasName_0.Text = "" Then
            MsgBox("別名未輸入!", 16, "錯誤")
            AliasName_0.Focus()
            Exit Sub
        End If

        UpdateSPdata0DGV()
        UpdateSPdata0DB()

        AddBut_0.Enabled = True      '開啟新增按鈕
        MdyBut_0.Enabled = True      '開啟修改按鈕
        UpdateBut_0.Enabled = False  '關閉更新按鈕
        DelBut_0.Enabled = True      '開啟刪除按鈕


        '清空資料
        'LineNum_0.Text = ""
        'Order_0.Text = ""
        CardCode_0.Text = ""
        CardName_0.Text = ""
        AliasName_0.Text = ""

        SPdata0LO()

    End Sub

    Private Sub DelBut_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelBut_0.Click
        '第1分頁刪除按鈕

        DelBut_0.Enabled = False

        If DelBut_0.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                DelSPdata0()
                SQLSPdata0Display()

            End If
        End If

        DelBut_0.Enabled = True

    End Sub

    Private Sub SQLSPdata0Display()
        '--查詢客戶程式
        '清空PDGV1內容
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [LineNum] AS '列號',[Order] AS '順序', [CardCode] AS '客編', [CardName] AS '客戶', [AliasName] AS '別名' FROM [Z_KS_SPdata0] WHERE [Floor] = '1' AND [Cancel] = 'Y' ORDER BY 1 "

            sql = "    SELECT [Sid] AS '編號', [LineNum] AS '列號', [Order] AS '順序', [CardCode] AS '客編', [CardName] AS '客戶', [AliasName] AS '別名' "
            sql += "     FROM [Z_KS_SPdata0] "
            sql += "    WHERE [Floor] IN ('4') AND [Cancel] = 'Y' "
            sql += " ORDER BY 1 "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")

            For Each column As DataGridViewColumn In DGV1.Columns
                column.Visible = True
                Select Case column.HeaderText

                    Case "編號" : column.HeaderText = "編號" : column.DisplayIndex = 0 : column.Visible = False
                    Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 1 : column.Visible = False
                    Case "順序" : column.HeaderText = "順序" : column.DisplayIndex = 2
                    Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 3
                    Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 4
                    Case "別名" : column.HeaderText = "別名" : column.DisplayIndex = 5

                        'Case "選擇"     : column.HeaderText = "選擇"     : column.DisplayIndex = 0 : column.ReadOnly = True
                        'Case "生產單號" : column.HeaderText = "生產單號" : column.DisplayIndex = 0
                        'Case "領料製單" : column.HeaderText = "領料製單" : column.DisplayIndex = 1
                        'Case "入庫單號" : column.HeaderText = "入庫單號" : column.DisplayIndex = 2
                        'Case "出庫單號" : column.HeaderText = "出庫單號" : column.DisplayIndex = 3
                        'Case "是否入庫" : column.HeaderText = "是否入庫" : column.DisplayIndex = 4 : column.Visible = False

                    Case Else
                        column.Visible = False
                End Select
            Next

            TransactionMonitor.Complete()

            DGV1.AutoResizeColumns()

            DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub

    Private Sub DGV1Mdy_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        '
        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        If MdyBut_0.Enabled = False Then

            SidT0.Text = DGV1.CurrentRow.Cells("編號").Value
            LineNum_0.Text = DGV1.CurrentRow.Cells("列號").Value
            Order_0.Text = DGV1.CurrentRow.Cells("順序").Value
            CardCode_0.Text = DGV1.CurrentRow.Cells("客編").Value
            CardName_0.Text = DGV1.CurrentRow.Cells("客戶").Value
            ''AliasName_0.Text = DGV1.CurrentRow.Cells("別名").Value

            If DGV1.CurrentRow.Cells("別名").Value.ToString = vbNullString Then
                AliasName_0.Text = ""
            Else
                AliasName_0.Text = DGV1.CurrentRow.Cells("別名").Value
            End If


        End If

    End Sub

    Private Sub UpdateSPdata0DGV()

        DGV1.CurrentRow.Cells("編號").Value = SidT0.Text
        DGV1.CurrentRow.Cells("列號").Value = LineNum_0.Text
        DGV1.CurrentRow.Cells("順序").Value = Order_0.Text
        DGV1.CurrentRow.Cells("客編").Value = CardCode_0.Text
        DGV1.CurrentRow.Cells("客戶").Value = CardName_0.Text
        DGV1.CurrentRow.Cells("別名").Value = AliasName_0.Text

    End Sub

    Private Sub UpdateSPdata0DB()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            For i As Integer = 0 To DGV1.RowCount - 1

                'sql = "UPDATE [Z_KS_SPdata0] SET [Order] = '" & DGV1.Rows(i).Cells("順序").Value & "', [CardCode] = '" & DGV1.Rows(i).Cells("客編").Value & "', [CardName] = '" & DGV1.Rows(i).Cells("客戶").Value & "' WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [LineNum] = '" & DGV1.Rows(i).Cells("列號").Value & "' and [Cancel] = 'Y' "
                'sql = " UPDATE [Z_KS_SPdata0] SET [Order]     = '" & DGV1.Rows(i).Cells("順序").Value & "', "
                'sql += "                          [CardCode]  = '" & DGV1.Rows(i).Cells("客編").Value & "', "
                'sql += "                          [CardName]  = '" & DGV1.Rows(i).Cells("客戶").Value & "', "
                'sql += "                          [AliasName] = '" & DGV1.Rows(i).Cells("別名").Value & "'  "
                'sql += " WHERE [Floor] = '4' AND  [LineNum]   = '" & DGV1.Rows(i).Cells("列號").Value & "' AND [Cancel] = 'Y' "

                sql = " UPDATE [Z_KS_SPdata0] SET [Order]     = '" & Order_0.Text & "'     ,"
                sql += "                          [CardCode]  = '" & CardCode_0.Text & "'  ,"
                sql += "                          [CardName]  = '" & CardName_0.Text & "'  ,"
                sql += "                          [AliasName] = '" & AliasName_0.Text & "'  "
                sql += " WHERE [Floor] = '4' AND  [Sid]       = '" & SidT0.Text & "' AND [Cancel] = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        'MsgBox("更新至資料庫完成!", 64, "成功")
    End Sub

    Private Sub DelSPdata0()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            'sql = "UPDATE [Z_KS_SPdata0] SET [Cancel] = 'N' WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [LineNum] = '" & DGV1.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
            'sql = "UPDATE [Z_KS_SPdata0] SET [Cancel] = 'N' WHERE [Floor] = '1' AND [LineNum] = '" & DGV1.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
            'sql = "UPDATE [Z_KS_SPdata0] SET [Cancel] = 'N' WHERE [LineNum] = '" & DGV1.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "

            sql = "UPDATE [Z_KS_SPdata0] SET [Cancel] = 'N' WHERE [Sid] = '" & DGV1.CurrentRow.Cells("編號").Value & "' and [Cancel] = 'Y' "


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

        MsgBox("刪除項目完成!", 64, "成功")

    End Sub

    Private Function SPdata0Sid()
        '更新客戶列號
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        'sql = " SELECT TOP 1 [LineNum] FROM [Z_KS_SPdata0] WHERE [Floor] = '" & Floor.SelectedIndex & "' ORDER BY [LineNum] DESC "
        sql = " SELECT TOP 1 [Sid] FROM [Z_KS_SPdata0] WHERE [Floor] = '4' ORDER BY [Sid] DESC "

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


    Private Function SPdata0LineNum()
        '更新客戶列號
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        'sql = " SELECT TOP 1 [LineNum] FROM [Z_KS_SPdata0] WHERE [Floor] = '" & Floor.SelectedIndex & "' ORDER BY [LineNum] DESC "
        sql = " SELECT TOP 1 [LineNum] FROM [Z_KS_SPdata0] WHERE [Floor] = '4' ORDER BY [LineNum] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("LineNum") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Function SPdata0Order()
        '更新客戶列號
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        'sql = " SELECT TOP 1 [Order] FROM [Z_KS_SPdata0] WHERE [Floor] = '" & Floor.SelectedIndex & "' ORDER BY [Order] DESC "
        sql = " SELECT TOP 1 [Order] FROM [Z_KS_SPdata0] WHERE [Floor] = '4' ORDER BY [Order] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Order") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub SPdata0LO()
        '第1分頁更新客戶列號順序

        Dim x As Integer
        x = SPdata0Sid()
        If x = 0 Then
            MsgBox("載入FindSid資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        Dim i As Integer
        i = SPdata0LineNum()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        Dim j As Integer
        j = SPdata0Order()
        If j = 0 Then
            MsgBox("載入FindOrder資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        SidT0.Text = x
        LineNum_0.Text = i
        Order_0.Text = j

    End Sub



    '--第1分頁止--
    '------------------------------------------------------------------------------------------------------------
    '----第2分頁起--

    Private Sub AddBut_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBut_1.Click
        '第2分頁新增按鈕

        If CategoryName_1.Text = "" Then
            MsgBox("類別未輸入!", 16, "錯誤")
            CategoryName_1.Focus()
            Exit Sub
        End If

        If Order_1.Text = "" Then
            MsgBox("順序未輸入!", 16, "錯誤")
            Order_1.Focus()
            Exit Sub
        End If

        Dim Row As DataRow
        Row = ks2DataSetDGV.Tables("DT2").NewRow
        Row.Item("列號") = LineNum_1.Text
        Row.Item("順序") = Order_1.Text
        Row.Item("類別") = CategoryName_1.Text

        ks2DataSetDGV.Tables("DT2").Rows.Add(Row)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        'Dim Cancel As String = "Y"
        Try
            sql = "INSERT INTO [Z_KS_SPdata1] ([Floor] ,[LineNum] ,[Order] ,[CategoryName] ,[Cancel]) VALUES " & _
                  " ('" & Floor.SelectedIndex & "','" & LineNum_1.Text & "','" & Order_1.Text & "','" & CategoryName_1.Text & "' , 'Y' )"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '清空資料
        'LineNum_1.Text = ""
        'Order_1.Text = ""
        CategoryName_1.Text = ""

        SPdata1LO()
        SPdata2CategoryName()

    End Sub

    Private Sub MdyBut_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MdyBut_1.Click
        '第2分頁修改按鈕
        AddBut_1.Enabled = False     '關閉新增按鈕
        MdyBut_1.Enabled = False     '關閉修改按鈕
        UpdateBut_1.Enabled = True   '開啟更新按鈕
        DelBut_1.Enabled = False     '關閉刪除按鈕
    End Sub

    Private Sub UpdateBut_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBut_1.Click
        '第2分頁更新按鈕

        If CategoryName_1.Text = "" Then
            MsgBox("類別未輸入!", 16, "錯誤")
            CategoryName_1.Focus()
            Exit Sub
        End If

        If Order_1.Text = "" Then
            MsgBox("順序未輸入!", 16, "錯誤")
            Order_1.Focus()
            Exit Sub
        End If

        UpdateSPdata1DGV()
        UpdateSPdata1DB()

        AddBut_1.Enabled = True      '開啟新增按鈕
        MdyBut_1.Enabled = True      '開啟修改按鈕
        UpdateBut_1.Enabled = False  '關閉更新按鈕
        DelBut_1.Enabled = True      '開啟刪除按鈕

        '清空資料
        'LineNum_1.Text = ""
        'Order_1.Text = ""
        CategoryName_1.Text = ""

        SPdata1LO()

    End Sub

    Private Sub DelBut_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelBut_1.Click
        '第2分頁刪除按鈕

        DelBut_1.Enabled = False

        If DelBut_1.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                DelSPdata1()
                SQLSPdata1Display()

            End If
        End If

        DelBut_1.Enabled = True

        SPdata2CategoryName()

    End Sub

    Private Sub SQLSPdata1Display()
        '--查詢類別程式
        '清空PDGV2內容
        If DGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [LineNum] AS '列號',[Order] AS '順序', [CategoryName] AS '類別' FROM [Z_KS_SPdata1] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 3 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "DT2")
            DGV2.DataSource = ks2DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()

            DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub

    Private Sub DGV2Mdy_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        '
        If DGV2.RowCount = -1 Then
            Exit Sub
        End If

        If MdyBut_1.Enabled = False Then

            LineNum_1.Text = DGV2.CurrentRow.Cells("列號").Value
            Order_1.Text = DGV2.CurrentRow.Cells("順序").Value
            CategoryName_1.Text = DGV2.CurrentRow.Cells("類別").Value

        End If

    End Sub

    Private Sub UpdateSPdata1DGV()

        DGV2.CurrentRow.Cells("列號").Value = LineNum_1.Text
        DGV2.CurrentRow.Cells("順序").Value = Order_1.Text
        DGV2.CurrentRow.Cells("類別").Value = CategoryName_1.Text

    End Sub

    Private Sub UpdateSPdata1DB()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            For i As Integer = 0 To DGV2.RowCount - 1

                sql = "UPDATE [Z_KS_SPdata1] SET [Order] = '" & DGV2.Rows(i).Cells("順序").Value & "', [CategoryName] = '" & DGV2.Rows(i).Cells("類別").Value & "' WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [LineNum] = '" & DGV2.Rows(i).Cells("列號").Value & "' and [Cancel] = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        'MsgBox("更新至資料庫完成!", 64, "成功")
    End Sub

    Private Sub DelSPdata1()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [Z_KS_SPdata1] SET [Cancel] = 'N' WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [LineNum] = '" & DGV2.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
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

        MsgBox("刪除項目完成!", 64, "成功")

    End Sub

    Private Function SPdata1LineNum()
        '更新類別列號
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [LineNum] FROM [Z_KS_SPdata1] WHERE [Floor] = '" & Floor.SelectedIndex & "' ORDER BY [LineNum] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("LineNum") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Function SPdata1Order()
        '更新類別順序
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [Order] FROM [Z_KS_SPdata1] WHERE [Floor] = '" & Floor.SelectedIndex & "' ORDER BY [Order] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Order") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub SPdata1LO()
        '第2分頁更新類別列號順序
        Dim i1 As Integer
        i1 = SPdata1LineNum()
        If i1 = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        Dim j1 As Integer
        j1 = SPdata1Order()
        If j1 = 0 Then
            MsgBox("載入FindOrder資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum_1.Text = i1
        Order_1.Text = j1

    End Sub



    '----第2分頁止--
    '------------------------------------------------------------------------------------------------------------
    '------第3分頁起--

    Private Sub AddBut_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBut_2.Click
        '第3分頁新增按鈕

        If CategoryName_2.Text = "" Then
            MsgBox("類別未輸入!", 16, "錯誤")
            CategoryName_2.Focus()
            Exit Sub
        End If

        If Order_2.Text = "" Then
            MsgBox("順序未輸入!", 16, "錯誤")
            Order_2.Focus()
            Exit Sub
        End If

        If ItemName_2.Text = "" Then
            MsgBox("品名未輸入!", 16, "錯誤")
            ItemName_2.Focus()
            Exit Sub
        End If

        If Plate_H_2.Text = "" Then
            MsgBox("工時未輸入!", 16, "錯誤")
            Plate_H_2.Focus()
            Exit Sub
        End If

        If Weight_2.Text = "" Then
            MsgBox("重量未輸入!", 16, "錯誤")
            Weight_2.Focus()
            Exit Sub
        End If

        If Microsoft.VisualBasic.Left(ItemCode_2.Text, 2) = "21" Then
            MsgBox("原料品項不得新增!", 16, "錯誤")
            ItemCode_2.Text = "" : ItemCode_2.Focus()
            Exit Sub
        End If



        Dim Row As DataRow
        Row = ks3DataSetDGV.Tables("DT3").NewRow
        Row.Item("類別") = CategoryName_2.Text
        Row.Item("列號") = LineNum_2.Text
        Row.Item("順序") = Order_2.Text
        Row.Item("存編") = ItemCode_2.Text
        Row.Item("品名") = ItemName_2.Text
        Row.Item("工時") = Plate_H_2.Text
        Row.Item("重量") = Weight_2.Text

        ks3DataSetDGV.Tables("DT3").Rows.Add(Row)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        'Dim Cancel As String = "Y"
        Try
            sql = "INSERT INTO [Z_KS_SPdata2] ([Floor] ,[CategoryName] ,[LineNum] ,[Order] ,[ItemCode] ,[ItemName] ,[Plate_H] ,[Weight] ,[Remarks] ,[Cancel]) VALUES " & _
                  " ('" & Floor.SelectedIndex & "', '" & CategoryName_2.Text & "', '" & LineNum_2.Text & "', '" & Order_2.Text & "', '" & ItemCode_2.Text & "', '" & ItemName_2.Text & "', '" & Plate_H_2.Text & "', '" & Weight_2.Text & "', '" & Remarks_2.Text & "', 'Y' )"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '清空資料
        ItemCode_2.Text = ""
        ItemName_2.Text = ""
        Plate_H_2.Text = ""
        Weight_2.Text = ""
        Remarks_2.Text = ""
        'CategoryName_2.Text = ""

        SPdata2LO()

    End Sub

    Private Sub MdyBut_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MdyBut_2.Click
        '第3分頁修改按鈕
        AddBut_2.Enabled = False     '關閉新增按鈕
        MdyBut_2.Enabled = False     '關閉修改按鈕
        UpdateBut_2.Enabled = True   '開啟更新按鈕
        DelBut_2.Enabled = False     '關閉刪除按鈕
    End Sub

    Private Sub UpdateBut_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBut_2.Click
        '第3分頁更新按鈕

        If CategoryName_2.Text = "" Then
            MsgBox("類別未輸入!", 16, "錯誤")
            CategoryName_2.Focus()
            Exit Sub
        End If

        If Order_2.Text = "" Then
            MsgBox("順序未輸入!", 16, "錯誤")
            Order_2.Focus()
            Exit Sub
        End If

        If ItemName_2.Text = "" Then
            MsgBox("品名未輸入!", 16, "錯誤")
            ItemName_2.Focus()
            Exit Sub
        End If

        If Plate_H_2.Text = "" Then
            MsgBox("工時未輸入!", 16, "錯誤")
            Plate_H_2.Focus()
            Exit Sub
        End If

        If Weight_2.Text = "" Then
            MsgBox("重量未輸入!", 16, "錯誤")
            Weight_2.Focus()
            Exit Sub
        End If


        UpdateSPdata2DGV()
        UpdateSPdata2DB()

        AddBut_2.Enabled = True      '開啟新增按鈕
        MdyBut_2.Enabled = True      '開啟修改按鈕
        UpdateBut_2.Enabled = False  '關閉更新按鈕
        DelBut_2.Enabled = True      '開啟刪除按鈕

        '清空資料
        ItemName_2.Text = ""
        Plate_H_2.Text = ""
        Weight_2.Text = ""
        Remarks_2.Text = ""
        'LineNum_2.Text = ""
        'Order_2.Text = ""
        'CategoryName_2.Text = ""

        SPdata2LO()

    End Sub

    Private Sub DelBut_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelBut_2.Click
        '第3分頁刪除按鈕

        DelBut_2.Enabled = False

        If DelBut_2.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                DelSPdata2()
                SQLSPdata2Display()

            End If
        End If

        DelBut_2.Enabled = True

    End Sub

    Private Sub CategoryName_2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryName_2.SelectedIndexChanged

        SQLSPdata2Display()
        SPdata2LO()

    End Sub

    Private Sub SQLSPdata2Display()
        '--查詢類別程式
        '清空DGV3內容
        If DGV3.RowCount > 0 Then
            ks3DataSetDGV.Tables("DT3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [LineNum] AS '列號', [Order] AS '順序', [ItemCode] AS '存編', [ItemName] AS '品名', [Plate_H] AS '工時', [Weight] AS '重量', ISNULL([Remarks],'') AS '備註', [CategoryName] AS '類別' FROM [Z_KS_SPdata2] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [CategoryName] = '" & CategoryName_2.Text & "' AND [Cancel] = 'Y' ORDER BY 1 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks3DataSetDGV, "DT3")
            DGV3.DataSource = ks3DataSetDGV.Tables("DT3")
            TransactionMonitor.Complete()

            DGV3.AutoResizeColumns()

            DGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub

    Private Sub DGV3Mdy_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellClick
        '
        If DGV3.RowCount = -1 Then
            Exit Sub
        End If

        If MdyBut_2.Enabled = False Then

            CategoryName_2.Text = DGV3.CurrentRow.Cells("類別").Value
            LineNum_2.Text = DGV3.CurrentRow.Cells("列號").Value
            Order_2.Text = DGV3.CurrentRow.Cells("順序").Value
            ItemCode_2.Text = DGV3.CurrentRow.Cells("存編").Value
            ItemName_2.Text = DGV3.CurrentRow.Cells("品名").Value
            Plate_H_2.Text = DGV3.CurrentRow.Cells("工時").Value
            Weight_2.Text = DGV3.CurrentRow.Cells("重量").Value
            Remarks_2.Text = DGV3.CurrentRow.Cells("備註").Value

        End If

    End Sub

    Private Sub UpdateSPdata2DGV()
        DGV3.CurrentRow.Cells("類別").Value = CategoryName_2.Text
        DGV3.CurrentRow.Cells("列號").Value = LineNum_2.Text
        DGV3.CurrentRow.Cells("順序").Value = Order_2.Text
        DGV3.CurrentRow.Cells("存編").Value = ItemCode_2.Text
        DGV3.CurrentRow.Cells("品名").Value = ItemName_2.Text
        DGV3.CurrentRow.Cells("工時").Value = Plate_H_2.Text
        DGV3.CurrentRow.Cells("重量").Value = Weight_2.Text
        DGV3.CurrentRow.Cells("備註").Value = Remarks_2.Text

    End Sub

    Private Sub UpdateSPdata2DB()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            For i As Integer = 0 To DGV3.RowCount - 1

                sql = "UPDATE [Z_KS_SPdata2] SET [Order] = '" & DGV3.Rows(i).Cells("順序").Value & "', [ItemCode] = '" & DGV3.Rows(i).Cells("存編").Value & "', [ItemName] = '" & DGV3.Rows(i).Cells("品名").Value & "', [Plate_H] = '" & DGV3.Rows(i).Cells("工時").Value & "', [Weight] = '" & DGV3.Rows(i).Cells("重量").Value & "' , [Remarks] = '" & DGV3.Rows(i).Cells("備註").Value & "' WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [CategoryName] = '" & CategoryName_2.Text & "' AND [LineNum] = '" & DGV3.Rows(i).Cells("列號").Value & "' and [Cancel] = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        'MsgBox("更新至資料庫完成!", 64, "成功")
    End Sub

    Private Sub DelSPdata2()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [Z_KS_SPdata2] SET [Cancel] = 'N' WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [CategoryName] = '" & CategoryName_2.Text & "' AND [LineNum] = '" & DGV3.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
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

        MsgBox("刪除項目完成!", 64, "成功")

    End Sub

    Private Function SPdata2LineNum()
        '更新類別列號
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [LineNum] FROM [Z_KS_SPdata2] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [CategoryName] = '" & CategoryName_2.Text & "' ORDER BY [LineNum] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("LineNum") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Function SPdata2Order()
        '更新類別順序
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [Order] FROM [Z_KS_SPdata2] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [CategoryName] = '" & CategoryName_2.Text & "' ORDER BY [Order] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Order") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub SPdata2LO()
        '第3分頁更新類別列號順序
        Dim i2 As Integer
        i2 = SPdata2LineNum()
        If i2 = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        Dim j2 As Integer
        j2 = SPdata2Order()
        If j2 = 0 Then
            MsgBox("載入FindOrder資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum_2.Text = i2
        Order_2.Text = j2

    End Sub

    Private Sub SPdata2CategoryName()
        '類別資訊載入SPdata1
        Try
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            sql = "select [Order], [CategoryName] from [Z_KS_SPdata1] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2"

            If ks3DataSet.Tables.Contains("CategoryName") Then

                CategoryName_2.SelectedIndex = -1
                ks3DataSet.Tables("CategoryName").Clear()

            End If

            ks3DataAdapter = New SqlDataAdapter(sql, DBConn)
            ks3DataAdapter.Fill(ks3DataSet, "CategoryName")

            CategoryName_2.DataSource = ks3DataSet.Tables("CategoryName")
            CategoryName_2.DisplayMember = "CategoryName"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        CategoryName_2.SelectedIndex = -1

    End Sub


    '------第3分頁止--

End Class