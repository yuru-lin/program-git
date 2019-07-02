Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 排程改
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Dim ks3DataSetDGV As DataSet = New DataSet
    'Tab5
    Dim ks5DataSetDGV As DataSet = New DataSet

    Dim idBindingSource As BindingSource = New BindingSource

    Dim poDataAdapter, po2DataAdapter, fiDataAdapter, fimDataAdapter, bpDataAdapter, pkDataAdapter, wgDataAdapter, csDataAdapter As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim ks2DataSet As DataSet = New DataSet


    Dim dsPDAIn As New DataTable
    Dim LPT As Boolean

    Private Sub 排程改_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PDGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        PDGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        'PDGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        '--開啟程式預設值

        '移除分頁
        TabControl1.TabPages.Remove(TabPage5)

        '基數
        LTextBox_Wh.Text = 0
        LTextBox_Rm.Text = 0

        '總數
        LSum_Wh.Text = 0


        Button_02.Enabled = False    '關閉更新查詢

        U_CK02.Enabled = False       '關閉製單
        U_CK021.Enabled = False      '關閉製單下拉
        CardName.Enabled = False     '關閉客戶下拉
        Category.Enabled = False     '關閉類別下拉
        ItemName.Enabled = False     '關閉品名下拉
        Quantity.Enabled = False     '關閉數量
        Number.Enabled = False       '關閉人數

        '排程按鈕----'關閉新增,修改,刪除,更新
        AddItemBtn.Enabled = False
        MdyItemBtn.Enabled = False
        DelItemBtn.Enabled = False
        SaveItemBtn.Enabled = False

        '領料按鈕----'關閉查詢排程,新增,修改,刪除,更新
        SearchScheduling.Enabled = False
        PAddItemBtn.Enabled = False
        PMdyItemBtn.Enabled = False
        PDelItemBtn.Enabled = False
        PSaveItemBtn.Enabled = False

        '排程清空資料
        U_CK021.SelectedIndex = -1
        U_CK02.Text = ""
        CardName.SelectedIndex = -1
        Category.SelectedIndex = -1
        ItemName.SelectedIndex = -1
        Quantity.Text = ""

        '領料清空資料
        PLineNum.Text = ""
        PItemName.Text = ""
        PQuantity.Text = ""
        PWeight.Text = ""
        P2LineNum.Text = ""
        Label15.Text = 0

        '領料目前查詢那個儲位
        Label10.Text = ""

        '鎖定是否清空排程編輯區資料
        'CheckBox2.Visible = False

        '列印分時單
        PrintBtn.Enabled = False

        Label21.Text = ""
        Label26.Text = ""
        Label28.Text = ""
        Label27.Text = ""

        Tab5T5DGV1Copy.Enabled = True

        'ks1DataSetDGV.Tables("DGV_IN").Clear()


    End Sub


    Private Sub Button_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_01.Click
        '--查詢訂單按鈕

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

        '排程下拉式選單載入----'客戶,類別,品項
        If CheckBox2.Checked = False Then
            CardName_cb()
            Category_cb()
            ' ''ItemName_cb()
        End If

        '上層選擇----'關閉查詢,重新查詢,關閉日期,關閉樓層,關閉時段
        Button_01.Enabled = False
        Button_02.Enabled = True
        dateDocDate.Enabled = False
        Floor.Enabled = False
        Period.Enabled = False

        '排程編輯區----'製單,客戶,類別,關閉品名,關閉數量,人數
        U_CK021.Enabled = True
        U_CK02.Enabled = True
        CardName.Enabled = True
        Category.Enabled = True
        ItemName.Enabled = False
        Number.Enabled = True

        If CheckBox2.Checked = False Then
            U_CK02.Text = ""
            U_CK021.SelectedIndex = -1
            CardName.SelectedIndex = -1
        End If

        If CheckBox2.Checked = False Then
            Quantity.Enabled = False
        Else
            Quantity.Enabled = True
        End If


        '排程按鈕----'新增,修改,刪除,關閉更新
        AddItemBtn.Enabled = True
        MdyItemBtn.Enabled = True
        DelItemBtn.Enabled = True
        'SaveItemBtn.Enabled = False

        '領料按鈕----'查詢排程,新增,修改,刪除,關閉更新
        SearchScheduling.Enabled = True
        PAddItemBtn.Enabled = True
        PMdyItemBtn.Enabled = True
        PDelItemBtn.Enabled = True
        'PSaveItemBtn.Enabled = False       


        SQLDGV1Display()

        '更新列號
        Dim i As Integer
        i = setCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum.Text = i

        '列印分時單
        PrintBtn.Enabled = True

        Tab5T5DGV1Copy.Enabled = False

        '排程單號
        T1OPDocNum.Text = "排" + Format(dateDocDate.Value.Date, "yyMMdd") + Format(Floor.SelectedIndex + 1, "#") + Format(Period.SelectedIndex + 1, "0#")

        If DGV_IN.RowCount > 0 Then
            ks1DataSetDGV.Tables("T1DGV_IN").Clear()
        End If

    End Sub

    Private Sub Button_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_02.Click
        '--更新查詢按鈕

        'Floor.SelectedIndex = -1
        '時段自動+1
        Dim Pi As Byte = Period.SelectedIndex
        'Period.SelectedIndex = Pi + 1

        If (Pi + 1) = 36 Then
            Period.SelectedIndex = 0
        Else
            Period.SelectedIndex = Pi + 1
        End If


        '上層選擇----'開啟查詢,關閉重新查詢,開啟日期,開啟樓層,關閉時段
        Button_01.Enabled = True
        Button_02.Enabled = False
        dateDocDate.Enabled = True
        Floor.Enabled = True
        Period.Enabled = True

        '排程編輯區----'關閉製單,客戶,類別,品名,數量,人數
        U_CK021.Enabled = False
        U_CK02.Enabled = False
        CardName.Enabled = False
        Category.Enabled = False
        ' ''ItemName.Enabled = False
        Quantity.Enabled = False
        Number.Enabled = False

        '排程按鈕----'關閉新增,修改,刪除,更新
        AddItemBtn.Enabled = False
        MdyItemBtn.Enabled = False
        DelItemBtn.Enabled = False
        SaveItemBtn.Enabled = False

        '領料按鈕----'關閉查詢排程,新增,修改,刪除,更新
        SearchScheduling.Enabled = False
        PAddItemBtn.Enabled = False
        PMdyItemBtn.Enabled = False
        PDelItemBtn.Enabled = False
        PSaveItemBtn.Enabled = False

        If CheckBox2.Checked = False Then

            '排程清空資料 CheckBox2 = False 執行清空
            U_CK021.SelectedIndex = -1
            U_CK02.Text = ""
            CardCode.Text = ""              '清空選擇客編
            CardName.SelectedIndex = -1
            Category.SelectedIndex = -1

            ItemCode.Text = ""              '清空選擇存編
            ItemName2.Text = ""             '清空選擇品項
            ' ''ItemName.SelectedIndex = -1
            Quantity.Text = ""

            '基數
            LTextBox_Wh.Text = 0
            LTextBox_Rm.Text = 0

        End If

        '領料清空資料
        T1OPDocNum.Text = ""            '清空選擇排程

        PLineNum.Text = ""
        PItemName.Text = ""
        PWeight.Text = ""
        P2LineNum.Text = ""
        PQuantity.Text = ""
        Label15.Text = 0

        CheckBox1.Checked = False

        '清空DGV內容
        ks1DataSetDGV.Tables("DT1").Clear()

        If PDGV1.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT1").Clear()
        End If

        If PDGV3.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT3").Clear()
        End If

        If DGV_IN.RowCount > 0 Then
            ks1DataSetDGV.Tables("T1DGV_IN").Clear()
        End If

        '總數
        LSum_Wh.Text = 0

        '列印分時單
        PrintBtn.Enabled = False

        Panel2.Visible = False

        Tab5T5DGV1Copy.Enabled = True

    End Sub

    Private Sub SQLDGV1Display()
        '--查詢訂單程式
        '清空DGV1內容
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT '' as '製單', '' as '客戶', T2.[FrgnName] as '品名', SUM(T1.[U_P3_Quantity]) as '數量', '' as '人數', T1.[U_P6] as '單位', '' as '工時', '' as '原料' FROM ORDR T0  INNER JOIN RDR1 T1 ON T0.DocEntry = T1.DocEntry INNER JOIN OITM T2 ON T1.ItemCode = T2.ItemCode WHERE T1.[U_P3] = 'Y' and  T0.[DocDueDate]  = '" & dateDocDate.Value.Date & "' GROUP BY T2.[FrgnName], T1.[U_P6] "
            sql = "    SELECT [Sid] AS '列號', [OPDocNum] AS '排程', [U_CK02] AS '製單', [CardCode] AS '客編', [CardName] AS '客戶', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity] AS '數量', [Number] AS '人數', [Time] AS '工時', [Weight] AS '重量', [ItemSid] AS 'ItemSid' "
            sql += "     FROM [Z_KS_Scheduling] "
            sql += "    WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND "
            sql += "          [Floor]   = '" & Floor.SelectedIndex & "'    AND "
            sql += "          [Period]  = '" & Period.SelectedIndex & "'   AND "
            sql += "          [Cancel]  = 'Y' "
            sql += " ORDER BY 1 "

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
        '--載入資料畫面
        For Each column As DataGridViewColumn In DGV1.Columns

            DGV1.AllowUserToAddRows = False
            DGV1.AllowUserToDeleteRows = False

            column.ReadOnly = True  'DataGridView 設定單元格不可編輯
            column.Visible = True

            Select Case column.Name
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 0                          'column.ReadOnly = True
                Case "排程" : column.HeaderText = "排程" : column.DisplayIndex = 1 : column.Visible = False 'column.ReadOnly = True
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 2                          'column.ReadOnly = True : column.Visible = False
                Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 3 : column.Visible = False 'column.ReadOnly = True
                Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 4                          'column.ReadOnly = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 5 : column.Visible = False 'column.ReadOnly = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 6                          'column.ReadOnly = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 7
                    'column.ReadOnly = False
                    'column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    'column.DefaultCellStyle.Format = "#0"
                Case "人數" : column.HeaderText = "人數" : column.DisplayIndex = 8
                    'column.ReadOnly = True
                Case "工時" : column.HeaderText = "工時" : column.DisplayIndex = 9
                    'column.ReadOnly = True
                Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 10
                    'column.ReadOnly = True
                    'column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    'column.DefaultCellStyle.Format = "#0"[ItemSid]
                Case "ItemSid" : column.HeaderText = "ItemSid" : column.DisplayIndex = 11 : column.Visible = False
                Case Else

                    column.Visible = False

            End Select
        Next

        DGV1.AutoResizeColumns()
        SumDGV1Wh()

    End Sub

    Private Function setCarEntry()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        'sql = " SELECT  TOP 1 [Sid] FROM [Z_KS_Scheduling] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period.SelectedIndex & "' ORDER BY [LineNum] DESC "
        sql = " SELECT  TOP 1 [Sid] FROM [Z_KS_Scheduling] ORDER BY [Sid] DESC "

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

    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click
        '--新增資料至 DGV1 畫面
        'If DGV1.RowCount <= 0 Then
        '    MsgBox("未有銷售資料!", 16, "錯誤")
        '    Exit Sub
        'End If

        If U_CK02.Text = "" Then
            MsgBox("製單未選擇!", 16, "錯誤")
            U_CK02.Focus()
            Exit Sub
        End If

        If CardName.Text = "" Then
            MsgBox("客戶未選擇!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If

        If ItemName2.Text = "" Then
            MsgBox("品項未選擇!", 16, "錯誤")
            'ItemName.Focus()
            Exit Sub
        End If

        If Quantity.Text = "" Then
            MsgBox("數量未填!", 16, "錯誤")
            Quantity.Focus()
            Exit Sub
        End If

        If Number.Text = "" Then
            MsgBox("人數未填!", 16, "錯誤")
            Number.Focus()
            Exit Sub
        End If

        'If TextBox3.Text = "" Then
        '    MsgBox("項目訂購數量未填!", 16, "錯誤")
        '    'ItemU_P8Txt.Focus()                      '移至未輸入的欄位
        '    Exit Sub
        'End If

        Dim Row As DataRow
        'Row = ks1DataSetDGV.Tables("DT1").NewRow
        Row = ks1DataSetDGV.Tables("DT1").NewRow
        Row.Item("列號") = LineNum.Text
        Row.Item("排程") = T1OPDocNum.Text
        Row.Item("製單") = U_CK02.Text
        Row.Item("客編") = CardCode.Text
        Row.Item("客戶") = CardName.Text
        Row.Item("ItemSid") = T1ItemSid.Text
        Row.Item("存編") = ItemCode.Text
        Row.Item("品名") = ItemName2.Text
        Row.Item("數量") = Quantity.Text
        Row.Item("人數") = Number.Text
        Row.Item("工時") = Time.Text
        Row.Item("重量") = Weight.Text

        ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim Cancel As String = "Y"
        Try
            sql = " INSERT INTO [Z_KS_Scheduling] ([DocDate],[Floor],[Period],[LineNum],[OPDocNum],[U_CK02],[CardCode],[CardName],[ItemSid],[ItemCode],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel]) VALUES "
            sql += " ('" & dateDocDate.Value.Date & "',"
            sql += "  '" & Floor.SelectedIndex & "'   ,"
            sql += "  '" & Period.SelectedIndex & "'  ,"
            sql += "  '" & LineNum.Text & "'          ,"
            sql += "  '" & T1OPDocNum.Text & "'       ,"
            sql += "  '" & U_CK02.Text & "'           ,"
            sql += "  '" & CardCode.Text & "'         ,"
            sql += "  '" & CardName.Text & "'         ,"
            sql += "  '" & T1ItemSid.Text & "'        ,"
            sql += "  '" & ItemCode.Text & "'         ,"
            sql += "  '" & ItemName2.Text & "'        ,"
            sql += "  '" & Quantity.Text & "'         ,"
            sql += "  '" & Number.Text & "'           ,"
            sql += "  '" & Time.Text & "'             ,"
            sql += "  '" & Weight.Text & "'           ,"
            sql += "  '" & Cancel & "'                )"
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

        'MsgBox("新增項目完成!", 64, "成功")

        If CheckBox2.Checked = False Then

            '清空資料
            ' ''U_CK021.SelectedIndex = -1      '重新選擇製單
            ' ''T1OPDocNum.Text = ""            '清空選擇排程
            ' ''U_CK02.Text = ""                '清空選擇製單
            ' ''CardCode.Text = ""              '清空選擇客編
            ' ''CardName.SelectedIndex = -1     '重新選擇客戶
            ' ''Category.SelectedIndex = -1     '重新選擇類別
            ItemCode.Text = ""              '清空選擇存編
            ItemName2.Text = ""             '清空選擇品項
            ' ''ItemName.Enabled = False        '關閉品項選擇
            ' ''ItemName.SelectedIndex = -1     '重新選擇品項
            Quantity.Text = ""              '清空數量
            Quantity.Enabled = False        '關閉數量

        End If

        '更新列號
        Dim i As Integer
        i = setCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum.Text = i

        '基數
        LTextBox_Wh.Text = 0
        LTextBox_Rm.Text = 0

        SumDGV1Wh()                     '計算總工時數

        If SearchScheduling.Enabled = False Then
            SQLPDGV1Display()
        End If

    End Sub

    Private Sub MdyItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MdyItemBtn.Click
        '修改資料至 DGV1 畫面

        'ItemBtn
        AddItemBtn.Enabled = False   '關閉新增
        MdyItemBtn.Enabled = False   '關閉修改
        SaveItemBtn.Enabled = True   '開啟更新

        Quantity.Enabled = True

    End Sub

    Private Sub DelItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelItemBtn.Click
        '刪除資料

        DelItemBtn.Enabled = False

        If DelItemBtn.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                'UpdateToDB()
                DelItemDetail()
                CodDelItemDetail()
                SQLDGV1Display()
                SumDGV1Wh()                     '計算總工時數

                If SearchScheduling.Enabled = False Then
                    SQLPDGV1Display()
                    SQLPDGV3Display()
                End If

            End If
        End If

        DelItemBtn.Enabled = True

    End Sub

    Private Sub DelItemDetail()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For Each oRow As DataGridViewRow In DGV1.SelectedRows

                'sql = "UPDATE [Z_KS_Scheduling] SET [Cancel] = 'N' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & DGV1.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
                sql = " UPDATE [Z_KS_Scheduling] SET [Cancel] = 'N' "
                sql += " WHERE [DocDate] = '" & dateDocDate.Value.Date & "'   and "
                sql += "       [Floor]   = '" & Floor.SelectedIndex & "'      and "
                sql += "       [Period]  = '" & Period.SelectedIndex & "'     and "
                'sql += "       [LineNum] = '" & oRow.Cells("列號").Value & "' and "
                sql += "       [Sid]     = '" & oRow.Cells("列號").Value & "' and "
                sql += "       [Cancel]  = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("刪除項目完成!", 64, "成功")
    End Sub


    Private Sub SaveItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveItemBtn.Click
        '更新資料

        If CardName.Text = "" Then
            MsgBox("客戶未選擇!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If

        If ItemName2.Text = "" Then
            MsgBox("品項未選擇!", 16, "錯誤")
            'ItemName.Focus()
            Exit Sub
        End If

        If Quantity.Text = "" Then
            MsgBox("數量未填!", 16, "錯誤")
            Quantity.Focus()
            Exit Sub
        End If

        If Number.Text = "" Then
            MsgBox("人數未填!", 16, "錯誤")
            Number.Focus()
            Exit Sub
        End If

        'ItemBtn
        AddItemBtn.Enabled = True     '開啟新增
        MdyItemBtn.Enabled = True     '關閉修改
        'DelItemBtn.Enabled = False   '關閉刪除
        SaveItemBtn.Enabled = False   '關閉更新

        UpdateItemDetail()

        '清空資料
        U_CK021.SelectedIndex = -1      '重新選擇製單
        ' ''T1OPDocNum.Text = ""            '清空選擇排程
        U_CK02.Text = ""                '清空選擇製單
        CardCode.Text = ""              '清空選擇客編
        CardName.SelectedIndex = -1     '重新選擇客戶
        Category.SelectedIndex = -1     '重新選擇類別
        ItemCode.Text = ""              '清空選擇存編
        ItemName2.Text = ""             '清空選擇品項
        ' ''ItemName.Enabled = False        '關閉品項選擇
        ' ''ItemName.SelectedIndex = -1     '重新選擇品項
        Quantity.Text = ""              '清空數量
        Quantity.Enabled = False        '關閉數量


        '' ''清空資料
        ' ''U_CK021.SelectedIndex = -1       '重新選擇製單
        ' ''U_CK02.Text = ""                '清空製單
        ' ''CardName.SelectedIndex = -1     '重新選擇客戶
        ' ''Category.SelectedIndex = -1     '重新選擇類別
        ' ''ItemName.Enabled = False        '關閉品項選擇
        ' ''ItemName.SelectedIndex = -1     '重新選擇品項
        ' ''Quantity.Text = ""              '清空數量
        ' ''Quantity.Enabled = False        '關閉數量

        '更新列號
        Dim i As Integer
        i = setCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum.Text = i

        SumDGV1Wh()                     '計算總工時數

        UpdateToDB()

        If SearchScheduling.Enabled = False Then
            SQLPDGV1Display()
        End If

    End Sub

    Private Sub UpdateItemDetail()
        DGV1.CurrentRow.Cells("列號").Value = LineNum.Text
        DGV1.CurrentRow.Cells("製單").Value = U_CK02.Text
        DGV1.CurrentRow.Cells("客編").Value = CardCode.Text
        DGV1.CurrentRow.Cells("客戶").Value = CardName.Text
        DGV1.CurrentRow.Cells("存編").Value = ItemCode.Text
        DGV1.CurrentRow.Cells("品名").Value = ItemName2.Text
        DGV1.CurrentRow.Cells("數量").Value = Quantity.Text
        DGV1.CurrentRow.Cells("人數").Value = Number.Text
        DGV1.CurrentRow.Cells("工時").Value = Time.Text
        DGV1.CurrentRow.Cells("重量").Value = Weight.Text

    End Sub

    Private Sub UpdateToDB()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            For i As Integer = 0 To DGV1.RowCount - 1

                sql = " UPDATE [Z_KS_Scheduling] SET "
                sql += "       [U_CK02]   = '" & DGV1.Rows(i).Cells("製單").Value & "', "
                sql += "       [CardCode] = '" & DGV1.Rows(i).Cells("客編").Value & "', "
                sql += "       [CardName] = '" & DGV1.Rows(i).Cells("客戶").Value & "', "
                sql += "       [ItemCode] = '" & DGV1.Rows(i).Cells("存編").Value & "', "
                sql += "       [ItemName] = '" & DGV1.Rows(i).Cells("品名").Value & "', "
                sql += "       [Quantity] = '" & DGV1.Rows(i).Cells("數量").Value & "', "
                sql += "       [Number]   = '" & DGV1.Rows(i).Cells("人數").Value & "', "
                sql += "       [Time]     = '" & DGV1.Rows(i).Cells("工時").Value & "', "
                sql += "       [Weight]   = '" & DGV1.Rows(i).Cells("重量").Value & "'  "
                sql += " WHERE [DocDate]  = '" & dateDocDate.Value.Date & "'           and "
                sql += "       [Floor]    = '" & Floor.SelectedIndex & "'              and "
                sql += "       [Period]   = '" & Period.SelectedIndex & "'             and "
                'sql += "       [LineNum]  = '" & DGV1.Rows(i).Cells("列號").Value & "' and "
                sql += "       [Sid]      = '" & DGV1.Rows(i).Cells("列號").Value & "' and "
                sql += "       [Cancel]   = 'Y' "

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


    Private Sub EmptyItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmptyItemBtn.Click
        '清空資料

        CardName.SelectedIndex = -1
        Category.SelectedIndex = -1
        ItemName2.Text = ""
        ' ''ItemName.SelectedIndex = -1

        ' ''ItemName.Enabled = False        '關閉品項選擇
        Quantity.Enabled = False        '關閉數量

        Quantity.Text = ""              '清空數量


    End Sub

    Private Sub Category_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category.SelectionChangeCommitted
        'Private Sub Category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category.SelectedIndexChanged

        '回傳 -1時停止動作
        If Category.SelectedIndex = -1 Then
            Exit Sub
        End If

        If DGV_IN.RowCount > 0 Then
            ks1DataSetDGV.Tables("T1DGV_IN").Clear()
        End If


        '類別更換，品項異動
        Try
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            'sql = " SELECT [ItemName],[ItemCode],[Plate_H],[Weight] "
            'sql += "  FROM [Z_KS_SPdata2] "
            'sql += " WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [CategoryName] = '" & Category.Text & "' AND [Cancel] = 'Y' ORDER BY 1"

            sql = " SELECT [ItemName],[ItemCode],[Plate_H],[Weight],[Sid] "
            sql += "  FROM [Z_KS_SPdata2] "
            sql += " WHERE [Floor] = '4' AND [CategoryName] = '" & Category.Text & "' AND [Cancel] = 'Y' ORDER BY 2"


            ' ''If ks1DataSet.Tables.Contains("ItemNamecb") Then

            ' ''    'tbx78_2.Text = ""
            ' ''    ItemName.SelectedIndex = -1
            ' ''    ks1DataSet.Tables("ItemNamecb").Clear()

            ' ''End If

            ' ''poDataAdapter = New SqlDataAdapter(sql, DBConn)
            ' ''poDataAdapter.Fill(ks1DataSet, "ItemNamecb")
            ' ''ItemName.DataSource = ks1DataSet.Tables("ItemNamecb")
            ' ''ItemName.DisplayMember = "ItemName"

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV_IN")
            DGV_IN.DataSource = ks1DataSetDGV.Tables("T1DGV_IN")

            DGV_IN.AutoResizeColumns()
            DGV_IN.AllowUserToAddRows = False       'DataGridView 設定單元格不可新增
            DGV_IN.AllowUserToDeleteRows = False    'DataGridView 設定單元格不可刪除
            DGV_IN.ReadOnly = True                  'DataGridView 設定單元格不可編輯


            '' ''清空資料
            ' ''ItemName.Enabled = True         '開啟品項選擇
            ' ''ItemName.SelectedIndex = -1     '重新選擇品項

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV_IN_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_IN.CellClick

        ItemName2.Text = DGV_IN.CurrentRow.Cells("ItemName").Value

        If DGV_IN.CurrentRow.Cells("ItemCode").Value.ToString = vbNullString Then
            ItemCode.Text = ""
        Else
            ItemCode.Text = DGV_IN.CurrentRow.Cells("ItemCode").Value
        End If

        LTextBox_Wh.Text = DGV_IN.CurrentRow.Cells("Plate_H").Value     '盤/時基數
        LTextBox_Rm.Text = DGV_IN.CurrentRow.Cells("Weight").Value      '原料基數
        T1ItemSid.Text = DGV_IN.CurrentRow.Cells("Sid").Value           'Sid

        Quantity.Enabled = True        '開啟數量
        TextBox3_Quy()

    End Sub


    ' ''Private Sub ItemName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemName.SelectedIndexChanged
    ' ''    '--選擇品項
    ' ''    '回傳 -1時停止動作
    ' ''    If ItemName.SelectedIndex = -1 Then
    ' ''        Exit Sub
    ' ''    End If

    ' ''    ItemName_cb2()                 '載入品項其他資料
    ' ''    Quantity.Enabled = True        '開啟數量

    ' ''    TextBox3_Quy()

    ' ''End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quantity.TextChanged, Number.TextChanged
        'Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave, TextBox4.Leave
        '數量及人數輸入

        TextBox3_Quy()

    End Sub

    Private Sub CardName_cb()
        '客戶資訊載入
        Try
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            'sql = "select * from [Z_KS_SPdata0] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 4"
            sql = "select * from [Z_KS_SPdata0] WHERE [Floor] = '4' AND [Cancel] = 'Y' ORDER BY 4"

            If ks1DataSet.Tables.Contains("CardName") Then
                CardCode.Text = ""
                CardName.SelectedIndex = -1
                P2CardName.SelectedIndex = -1
                ks1DataSet.Tables("CardName").Clear()
            End If

            poDataAdapter = New SqlDataAdapter(sql, DBConn)
            poDataAdapter.Fill(ks1DataSet, "CardName")

            CardName.DataSource = ks1DataSet.Tables("CardName")
            CardName.DisplayMember = "CardName"

            P2CardName.DataSource = ks1DataSet.Tables("CardName")
            P2CardName.DisplayMember = "CardName"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        CardCode.Text = ""
        CardName.SelectedIndex = -1
        P2CardName.SelectedIndex = -1

    End Sub

    Private Sub CardName_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardName.SelectionChangeCommitted
        '回傳 -1時停止動作
        If CardName.SelectedIndex = -1 Then
            Exit Sub
        End If

        CardName_cb2()
    End Sub


    Private Sub CardName_cb2()
        '回傳 -1時停止動作
        If CardName.SelectedIndex = -1 Then
            Exit Sub
        End If

        Try
            Dim dt As DataTable = ks1DataSet.Tables("CardName")
            Dim oCriteria As String = "CardName='" & Trim(CardName.Text) & "'"
            Dim foundRow() As DataRow

            foundRow = dt.Select(oCriteria)
            CardCode.Text = foundRow(0)("CardCode")
            AliasName.Text = foundRow(0)("AliasName")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Category_cb()

    End Sub


    Private Sub Category_cb()
        '類別資訊載入
        Try
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            'sql = "select * from [Z_KS_SPdata1] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 1"

            sql = "SELECT * FROM [Z_KS_SPdata1] WHERE [Floor] = '4' AND [CategoryName] Like '%" & AliasName.Text & "%' AND [Cancel] = 'Y' ORDER BY 4"


            If ks1DataSet.Tables.Contains("Categorycb") Then

                Category.SelectedIndex = -1
                ks1DataSet.Tables("Categorycb").Clear()

            End If

            poDataAdapter = New SqlDataAdapter(sql, DBConn)
            poDataAdapter.Fill(ks1DataSet, "Categorycb")
            Category.DataSource = ks1DataSet.Tables("Categorycb")
            Category.DisplayMember = "CategoryName"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Category.SelectedIndex = -1

    End Sub

    ' ''Private Sub ItemName_cb()
    ' ''    '品項資訊載入
    ' ''    Try
    ' ''        Dim sql As String
    ' ''        Dim DBConn As SqlConnection = Login.DBConn
    ' ''        Dim SQLCmd As SqlCommand = New SqlCommand

    ' ''        sql = "select * from [Z_KS_SPdata2] WHERE [Floor] = '" & Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 1"

    ' ''        If ks1DataSet.Tables.Contains("ItemNamecb") Then

    ' ''            ItemName.SelectedIndex = -1
    ' ''            ks1DataSet.Tables("ItemNamecb").Clear()

    ' ''        End If

    ' ''        poDataAdapter = New SqlDataAdapter(sql, DBConn)
    ' ''        poDataAdapter.Fill(ks1DataSet, "ItemNamecb")
    ' ''        ItemName.DataSource = ks1DataSet.Tables("ItemNamecb")
    ' ''        ItemName.DisplayMember = "ItemName"

    ' ''    Catch ex As Exception
    ' ''        MsgBox(ex.Message)
    ' ''    End Try

    ' ''    ItemName.SelectedIndex = -1

    ' ''End Sub

    ' ''Private Sub ItemName_cb2()
    ' ''    '--載入品項其他資料 ItemCode=存編, Plate_H=盤/時, Quy=盤/需求原料重
    ' ''    '回傳 -1時停止動作
    ' ''    If ItemName.SelectedIndex = -1 Then
    ' ''        Exit Sub
    ' ''    End If

    ' ''    Try
    ' ''        Dim dt As DataTable = ks1DataSet.Tables("ItemNamecb")
    ' ''        Dim oCriteria As String = "ItemName='" & Trim(ItemName.Text) & "'"
    ' ''        Dim foundRow() As DataRow

    ' ''        foundRow = dt.Select(oCriteria)
    ' ''        ItemCode.Text = foundRow(0)("ItemCode")
    ' ''        LTextBox_Wh.Text = foundRow(0)("Plate_H")   '盤/時基數
    ' ''        LTextBox_Rm.Text = foundRow(0)("Weight")       '原料基數

    ' ''    Catch ex As Exception
    ' ''        MsgBox(ex.Message)
    ' ''    End Try

    ' ''End Sub

    Private Sub TextBox3_Quy()
        '計算總工時及原料 P1=數量 P2=人數 S1=工時Wh S2=原料Rm M1=工時基數 M2=原料基數

        If Quantity.Text = "" Or Quantity.Text = "0" Then

            Time.Text = ""
            Weight.Text = ""

        Else
            If Number.Text = "" Or Number.Text = "0" Then

                Time.Text = ""
                Weight.Text = ""

            Else

                Dim P1, P2, S1, S11, S2, M1, M2 As Double

                If Quantity.Text = "" Then
                    P1 = 0
                Else
                    P1 = CDbl(Trim(Quantity.Text))
                End If

                If Number.Text = "" Then
                    P2 = 0
                Else
                    P2 = CDbl(Trim(Number.Text))
                End If

                If LTextBox_Wh.Text = "" Then
                    M1 = 0
                Else
                    M1 = CDbl(Trim(LTextBox_Wh.Text))
                End If

                If LTextBox_Rm.Text = "" Then
                    M2 = 0
                Else
                    M2 = CDbl(Trim(LTextBox_Rm.Text))
                End If


                If M1 = 0 Then
                    S1 = 0
                Else
                    S1 = (60 / M1) * P1 / P2
                End If

                If M2 = 0 Then
                    S2 = 0
                Else
                    S2 = M2 * P1
                End If


                S11 = Math.Round(S1, 2)

                Time.Text = S11
                Weight.Text = S2

            End If

        End If

    End Sub

    Private Sub SumDGV1Wh()
        '計算總工時數
        DGV1.AutoResizeColumns()
        Dim SumWh As Double
        'Dim SumWh2 As Double

        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("工時").Value = False Then
                SumWh = "0"
            Else
                SumWh += DGV1.Rows(i).Cells("工時").Value
            End If

        Next

        LSum_Wh.Text = SumWh
        'LSum_Wh2.Text = DGV1.RowCount

    End Sub



    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        If MdyItemBtn.Enabled = True Then

        Else

            ' ''ItemName_cb()
            ' ''ItemName.Enabled = False        '關閉品項選擇

            LineNum.Text = DGV1.CurrentRow.Cells("列號").Value
            U_CK02.Text = DGV1.CurrentRow.Cells("製單").Value

            ''CardCode.Text = DGV1.CurrentRow.Cells("客編").Value
            If DGV1.CurrentRow.Cells("客編").Value.ToString = vbNullString Then
                CardCode.Text = ""
            Else
                CardCode.Text = DGV1.CurrentRow.Cells("客編").Value
            End If

            CardName.Text = DGV1.CurrentRow.Cells("客戶").Value

            ''ItemCode.Text = DGV1.CurrentRow.Cells("存編").Value
            If DGV1.CurrentRow.Cells("存編").Value.ToString = vbNullString Then
                ItemCode.Text = ""
            Else
                ItemCode.Text = DGV1.CurrentRow.Cells("存編").Value
            End If

            ItemName2.Text = DGV1.CurrentRow.Cells("品名").Value
            Quantity.Text = DGV1.CurrentRow.Cells("數量").Value
            Number.Text = DGV1.CurrentRow.Cells("人數").Value

            TextBox3_Quy()
        End If

        ''If DGV_IN.CurrentRow.Cells("ItemCode").Value.ToString = vbNullString Then
        ''    ItemCode.Text = ""
        ''Else
        ''    ItemCode.Text = DGV_IN.CurrentRow.Cells("ItemCode").Value
        ''End If


    End Sub

















    '領料分頁
    Private Sub 領料分頁()

    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        '查庫位資2
        If ComboBox1.Text = "" Then
            MsgBox("未選擇儲位!", 16, "錯誤")
            ComboBox1.Focus()
            Exit Sub
        End If

        'SQLPDGV2Display()
        SQLPDGV22Display()



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        SQLPDGV21Display()

    End Sub


    Private Sub SearchScheduling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchScheduling.Click
        '查詢排程及領料

        CheckBox1.Checked = False           '關閉列號鎖定
        SearchScheduling.Enabled = False    '關閉查詢排程及領料

        SQLPDGV1Display()
        SQLPDGV3Display()

        '更新列號
        Dim i As Integer
        i = PsetCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        P2LineNum.Text = i

    End Sub

    Private Sub SQLPDGV1Display()
        '--查詢訂單程式
        '清空PDGV1內容
        If PDGV1.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [LineNum] AS '列號', [ItemName] AS '品名',[Quantity] AS '數量', [Weight] AS '重量', [U_CK02] AS '製單', [CardName] AS '客戶' FROM [Z_KS_Scheduling] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 1 "
            'sql = " SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] LEFT JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] WHERE T1.[Quantity] > 0 and T0.[U_M2] = '" & ComboBox1.Text & "' or (T1.[Quantity] > 0 and T0.[U_M2] like '" & ComboBox1.Text & "' ) GROUP BY T0.[ItemCode], T2.[ItemName], T0.[MnfDate] ORDER BY T0.[ItemCode], T0.[MnfDate] "

            sql = " SELECT T0.[LineNum] AS '列號', T0.[ItemName] AS '品名', T0.[Quantity] AS '數量', T0.[Weight] AS '重量', T0.[U_CK02] AS '製單', T0.[CardName] AS '客戶' , ISNULL(T1.[Remarks],'') AS '需求', T0.[ItemCode] AS '存編'  FROM [Z_KS_Scheduling] T0 LEFT JOIN [Z_KS_SPdata2] T1 ON T0.[ItemName] = T1.[ItemName] AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND T0.[Period] = '" & Period.SelectedIndex & "' AND T0.[Cancel] = 'Y' ORDER BY 1 "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT1")
            PDGV1.DataSource = ks2DataSetDGV.Tables("PDT1")
            TransactionMonitor.Complete()

            PDGV1.AutoResizeColumns()

            PDGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            PDGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            PDGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub

    Private Sub PDGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PDGV1.CellClick
        '--選擇生產品

        'ListBox1.Text = ""
        'ListBox1.

        If PDGV1.RowCount = -1 Then
            Exit Sub
        End If

        PLineNum.Text = PDGV1.CurrentRow.Cells("列號").Value
        P2U_CK02.Text = PDGV1.CurrentRow.Cells("製單").Value
        P2CardName.Text = PDGV1.CurrentRow.Cells("客戶").Value
        PItemName.Text = PDGV1.CurrentRow.Cells("品名").Value
        PWeight.Text = PDGV1.CurrentRow.Cells("重量").Value
        PQuantity.Text = PDGV1.CurrentRow.Cells("數量").Value
        TextBox4.Text = PDGV1.CurrentRow.Cells("需求").Value
        Label40.Text = PDGV1.CurrentRow.Cells("存編").Value

        SumPDGV1_Weight()
        'PDGV1_Remarks()

        If CheckBox1.Checked Then

            SQLPDGV3Display()

        End If

    End Sub

    Private Sub SumPDGV1_Weight()
        '計算需求原料件數

        Dim P1, S1, S11 As Double

        If PWeight.Text = "" Then
            P1 = 0
        Else
            P1 = CDbl(Trim(PWeight.Text))
        End If

        If P1 = 0 Then
            S1 = 0
        Else
            S1 = ((P1 / 15) + 0.5)
        End If

        S11 = Math.Round(S1, 0)
        Label15.Text = S11

    End Sub

    Private Sub SQLPDGV2Display()
        '--儲位查詢  -------/**--- 不使用20121225 改用SQLPDGV22Display() ---**/---------
        '清空PDGV2內容
        If PDGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] LEFT JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] WHERE T1.[Quantity] > 0 AND T2.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T1.[Quantity] > 0 and T0.[U_M2] Like '&" & ComboBox1.Text & "&' AND T2.[ItemName] Like '%" & TextBox1.Text & "%' ) GROUP BY T0.[ItemCode], T2.[ItemName], T0.[MnfDate] ORDER BY T0.[ItemCode], T0.[MnfDate] "

            'sql = "  SELECT K01.[存編], K03.[品名], (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0' ELSE K01.[庫存量] END) AS '庫存量', K01.[重量], (CASE ISNULL(K02.[預領量],'--') WHEN '--' THEN '--' ELSE K02.[預領量] END) AS '預領量', (CASE ISNULL((CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)),'0') WHEN '0' THEN '0' ELSE (CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)) END) AS '差異數', K01.[製造日期], K01.[天數]  "

            sql = "   SELECT DISTINCT K01.[存編], K03.[品名], "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN 'J211'    ELSE CASE K01.[庫位] WHEN 'J211' THEN '成品區' WHEN 'J211-1' THEN '移倉區' WHEN 'J211-2' THEN '退料區' WHEN 'J211-3' THEN '原料區' WHEN 'J211-4' THEN '微凍區' WHEN 'J211-11' THEN '移倉區-一' WHEN 'J211-12' THEN '移倉區-二' WHEN 'J211-13' THEN '移倉區-三' WHEN 'J211-14' THEN '移倉區-四' WHEN 'J211-15' THEN '移倉區-五' WHEN 'J211-16' THEN '移倉區-六' WHEN 'J211-17' THEN '移倉區-日' ELSE '不知區' END END) AS '庫位',"
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0'       ELSE K01.[庫存量]   END) AS '庫存量', "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0'       ELSE K01.[重量]     END) AS '重量'  , (CASE ISNULL(K02.[預領量],'--') WHEN '--' THEN '--' ELSE K02.[預領量] END) AS '預領量', "
            sql += "        (CASE ISNULL((CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)),'0') WHEN '0' THEN '0' ELSE (CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)) END) AS '差異數', "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN CONVERT(varchar(12),getdate(),120) ELSE CONVERT(varchar(12),K01.[製造日期],120) END) AS '製造日期', "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0'       ELSE K01.[天數]     END) AS '天數' "
            sql += "   FROM (SELECT T0.[U_M2] AS '庫位', T0.[ItemCode] AS '存編', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '庫存量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數' "
            sql += "           FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "          WHERE T0.[U_M2] = '" & ComboBox1.Text & "' "
            'sql += "          WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T0.[U_M2] Like '%" & ComboBox1.Text & "%') "
            sql += "       GROUP BY T0.[ItemCode], T0.[MnfDate], T0.[U_M2]) K01                           LEFT JOIN "

            sql += "        (SELECT T0.[ItemCode] AS '存編', dbo.getRoundN(SUM(T0.[Quantity]),0) AS '預領量' "
            sql += "           FROM [Z_KS_SPicking] T0 "
            sql += "          WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Cancel] = 'Y' "
            sql += "       GROUP BY T0.[ItemCode])                         K02 ON K01.[存編] = K02.[存編] LEFT JOIN "

            sql += "        (SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名' "
            sql += "           FROM [OITM] T0)                             K03 ON K01.[存編] = K03.[存編] "

            ''sql += "    WHERE K03.[ItemName] Like '%" & TextBox1.Text & "%' AND "
            ''sql += "          K02.[預領量] >= 0 or K01.[庫存量] > 0 AND (K01.[庫存量] > 0 or K02.[預領量] >= 0) AND K03.[ItemName] Like '%" & TextBox1.Text & "%' "
            ''sql += " ORDER BY 1"


            '' ''sql = " SELECT K01.[ItemCode] AS '存編', K03.[ItemName] AS '品名', (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0' ELSE K01.[庫存量] END) AS '庫存量', (CASE ISNULL(K04.[重量],'0') WHEN '0' THEN '0' ELSE K04.[重量] END) AS '重量', (CASE ISNULL(K02.[預領量],'--') WHEN '--' THEN '--' ELSE K02.[預領量] END) AS '預領量', (CASE ISNULL(CAST(CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)AS varchar),'0') WHEN '0' THEN '' ELSE CAST(CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)AS varchar) END) AS '差異數' "
            '' ''sql += " FROM (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T1.[Quantity]),0) AS '庫存量' FROM [OSRN] T0 LEFT OUTER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T0.[U_M2] Like '%" & ComboBox1.Text & "%') GROUP BY T0.[ItemCode]) K01 LEFT OUTER JOIN "
            '' ''sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T0.[Quantity]),0) AS '預領量' FROM [Z_KS_SPicking] T0 WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Cancel] = 'Y' GROUP BY T0.[ItemCode]) K02 ON K01.[ItemCode] = K02.[ItemCode] LEFT OUTER JOIN "
            '' ''sql += "      (SELECT T0.[ItemCode], T0.[ItemName] FROM [OITM] T0) K03 ON K01.[ItemCode] = K03.[ItemCode]  LEFT OUTER JOIN "
            '' ''sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(CAST(T0.[U_M1] AS numeric(19, 4))),2) as '重量' FROM [OSRN] T0 LEFT OUTER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' AND T1.[Quantity]  > 0 or (T1.[Quantity]  > 0 AND T0.[U_M2] Like '%" & ComboBox1.Text & "%') GROUP BY T0.[ItemCode]) K04 ON K01.[ItemCode] = K04.[ItemCode] "
            ' '' ''sql += " WHERE K03.[ItemName] Like '%" & TextBox1.Text & "%' AND ( K03.[ItemName] Like '%" & TextBox2.Text & "%' or K03.[ItemName] Like '%" & TextBox3.Text & "%') AND K02.[預領量] >= 0 or K01.[庫存量] >  0  and  "
            ' '' ''sql += "      (K01.[庫存量] >  0 or K02.[預領量] >= 0) AND K03.[ItemName] Like '%" & TextBox1.Text & "%' AND ( K03.[ItemName] Like '%" & TextBox2.Text & "%' or K03.[ItemName] Like '%" & TextBox3.Text & "%' ) ORDER BY 1 "


            If CheckBox3.Checked Then
                If TextBox1.Text <> "" And TextBox2.Text = "" And TextBox3.Text = "" Then
                    '1.
                    'sql += " WHERE K03.[品名] Like '%" & TextBox1.Text & "%' AND K02.[預領量] >= 0 or K01.[庫存量] > 0 AND "
                    'sql += "      (K01.[庫存量] > 0 or K02.[預領量] >= 0)    AND K03.[品名] Like '%" & TextBox1.Text & "%' ORDER BY 1 "
                    sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND K03.[品名] Like '%" & TextBox1.Text & "%' "
                    sql += " ORDER BY 8, 1 "

                Else

                    If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text = "" Then
                        '2.
                        'sql += " WHERE K03.[品名] Like '%" & TextBox1.Text & "%' AND  K03.[品名] Like '%" & TextBox2.Text & "%' AND K02.[預領量] >= 0 OR K01.[庫存量] > 0 AND "
                        'sql += "      (K01.[庫存量] > 0 or K02.[預領量] >= 0)    AND (K03.[品名] Like '%" & TextBox1.Text & "%' or  K03.[品名] Like '%" & TextBox2.Text & "%') ORDER BY 1 "
                        sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND (K03.[品名] Like '%" & TextBox1.Text & "%' OR  K03.[品名] Like '%" & TextBox2.Text & "%') "
                        sql += " ORDER BY 8, 1 "

                    Else

                        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                            '3.
                            'sql += " WHERE K03.[品名] Like '%" & TextBox1.Text & "%' or       K03.[品名] Like '%" & TextBox2.Text & "%' or   K03.[品名] Like '%" & TextBox3.Text & "%' AND K02.[預領量] >= 0 or K01.[庫存量] > 0 AND "
                            'sql += "      (K01.[庫存量] >  0 or K02.[預領量] >= 0)       AND (K03.[品名] Like '%" & TextBox1.Text & "%' AND (K03.[品名] Like '%" & TextBox2.Text & "%' or  K03.[品名] Like '%" & TextBox3.Text & "%') ORDER BY 1 "
                            sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND (K03.[品名] Like '%" & TextBox1.Text & "%' OR K03.[品名] Like '%" & TextBox2.Text & "%' OR  K03.[品名] Like '%" & TextBox3.Text & "%') "
                            sql += " ORDER BY 8, 1 "

                        End If
                    End If
                End If
            Else

                'sql += " WHERE K03.[品名] Like '%" & TextBox1.Text & "%' AND K03.[品名] Like '%" & TextBox2.Text & "%' AND K03.[品名] Like '%" & TextBox3.Text & "%' AND K02.[預領量] >= 0 or K01.[庫存量] >  0 AND  "
                'sql += "      (K01.[庫存量] >  0 or K02.[預領量] >= 0)   AND K03.[品名] Like '%" & TextBox1.Text & "%' AND K03.[品名] Like '%" & TextBox2.Text & "%' AND K03.[品名] Like '%" & TextBox3.Text & "%' ORDER BY 1 "
                sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND K03.[品名] Like '%" & TextBox1.Text & "%' AND K03.[品名] Like '%" & TextBox2.Text & "%' AND K03.[品名] Like '%" & TextBox3.Text & "%' "
                sql += " ORDER BY 8, 1 "

            End If


            'sql += " WHERE K03.[ItemName] Like '%" & TextBox1.Text & "%' AND ( K03.[ItemName] Like '%" & TextBox2.Text & "%' or K03.[ItemName] Like '%" & TextBox3.Text & "%') AND K02.[預領量] >= 0 or K01.[庫存量] >  0  and  "
            'sql += "      (K01.[庫存量] >  0 or K02.[預領量] >= 0) AND K03.[ItemName] Like '%" & TextBox1.Text & "%' AND ( K03.[ItemName] Like '%" & TextBox2.Text & "%' or K03.[ItemName] Like '%" & TextBox3.Text & "%' ) ORDER BY 1 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT2")
            PDGV2.DataSource = ks2DataSetDGV.Tables("PDT2")
            TransactionMonitor.Complete()

            PDGV2.AutoResizeColumns()

            PDGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            PDGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            PDGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

            'If PDGV2.RowCount > 0 Then
            '    Dim Red As Integer = 0

            '    For i As Integer = 0 To PDGV2.RowCount - 1

            '        'Dim Qut As Single = "" = 0

            '        'Qut = CInt(PDGV2.Rows(i).Cells("差異數").Value)

            '        If CInt(PDGV2.Rows(i).Cells("差異數").Value) < 0 Then
            '            PDGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
            '            Red += 1
            '        End If
            '    Next
            'End If


        End Using

        Label10.Text = ComboBox1.Text
        'P2Source.Text = ComboBox1.Text
        MsgBox("查詢完成")

    End Sub

    Private Sub SQLPDGV22Display()
        '--儲位查詢
        '清空PDGV2內容
        If PDGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "   SELECT DISTINCT K01.[存編], K03.[品名], "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN 'J211'    ELSE CASE K01.[庫位] WHEN 'J211' THEN '成品區' WHEN 'J211-1' THEN '移倉區' WHEN 'J211-2' THEN '退料區' WHEN 'J211-3' THEN '原料區' WHEN 'J211-4' THEN '微凍區' WHEN 'J211-11' THEN '移倉區-一' WHEN 'J211-12' THEN '移倉區-二' WHEN 'J211-13' THEN '移倉區-三' WHEN 'J211-14' THEN '移倉區-四' WHEN 'J211-15' THEN '移倉區-五' WHEN 'J211-16' THEN '移倉區-六' WHEN 'J211-17' THEN '移倉區-日' ELSE '不知區' END END) AS '庫位',"
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0'       ELSE K01.[庫存量]   END) AS '庫存量', "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0'       ELSE K01.[重量]     END) AS '重量'  , (CASE ISNULL(K02.[預領量],'--') WHEN '--' THEN '--' ELSE K02.[預領量] END) AS '預領量', "
            sql += "        (CASE ISNULL((CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)),'0') WHEN '0' THEN '0' ELSE (CAST(K01.[庫存量] AS NUMERIC)-CAST(K02.[預領量]AS NUMERIC)) END) AS '差異數', "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN CONVERT(varchar(12),getdate(),120) ELSE CONVERT(varchar(12),K01.[製造日期],120) END) AS '製造日期', "
            sql += "        (CASE ISNULL(K01.[庫存量],'0') WHEN '0' THEN '0'       ELSE K01.[天數]     END) AS '天數' "
            sql += "   FROM (SELECT T0.[U_M2] AS '庫位', T0.[ItemCode] AS '存編', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '庫存量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數' "
            sql += "           FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "          WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' "
            sql += "       GROUP BY T0.[ItemCode], T0.[MnfDate], T0.[U_M2]) K01                           LEFT JOIN "
            sql += "        (SELECT T0.[ItemCode] AS '存編', dbo.getRoundN(SUM(T0.[Quantity]),0) AS '預領量' "
            sql += "           FROM [Z_KS_SPicking] T0 "
            sql += "          WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Cancel] = 'Y' "
            sql += "       GROUP BY T0.[ItemCode])                         K02 ON K01.[存編] = K02.[存編] LEFT JOIN "
            sql += "        (SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名' "
            sql += "           FROM [OITM] T0)                             K03 ON K01.[存編] = K03.[存編] "

            If CheckBox3.Checked Then
                If TextBox1.Text <> "" And TextBox2.Text = "" And TextBox3.Text = "" Then
                    '1.
                    sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND K03.[品名] Like '%" & TextBox1.Text & "%' "
                    sql += " ORDER BY 8, 1 "
                Else
                    If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text = "" Then
                        '2.
                        sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND (K03.[品名] Like '%" & TextBox1.Text & "%' OR  K03.[品名] Like '%" & TextBox2.Text & "%') "
                        sql += " ORDER BY 8, 1 "
                    Else
                        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
                            '3.
                            sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND (K03.[品名] Like '%" & TextBox1.Text & "%' OR K03.[品名] Like '%" & TextBox2.Text & "%' OR  K03.[品名] Like '%" & TextBox3.Text & "%') "
                            sql += " ORDER BY 8, 1 "
                        End If
                    End If
                End If
            Else
                sql += "    WHERE (ISNULL(K01.[庫存量],0) <> 0 OR ISNULL(K02.[預領量],0) <> 0) AND K03.[品名] Like '%" & TextBox1.Text & "%' AND K03.[品名] Like '%" & TextBox2.Text & "%' AND K03.[品名] Like '%" & TextBox3.Text & "%' "
                sql += " ORDER BY 8, 1 "
            End If

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT2")
            PDGV2.DataSource = ks2DataSetDGV.Tables("PDT2")
            TransactionMonitor.Complete()

            PDGV2.AutoResizeColumns()

            PDGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            PDGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            PDGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        Label10.Text = ComboBox1.Text
        PDGV2_Sorted()
        MsgBox("查詢完成")

    End Sub



    Private Sub SQLPDGV2Display2()
        '--儲位查詢   -------/**--- 查詢 PDGV2 存編 -- 製造日期 ---**/---------
        '清空PDGV22內容
        If PDGV22.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT4").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] LEFT JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] WHERE T1.[Quantity] > 0 AND T2.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T1.[Quantity] > 0 and T0.[U_M2] Like '&" & ComboBox1.Text & "&' AND T2.[ItemName] Like '%" & TextBox1.Text & "%' ) GROUP BY T0.[ItemCode], T2.[ItemName], T0.[MnfDate] ORDER BY T0.[ItemCode], T0.[MnfDate] "
            sql = "    SELECT T0.[MnfDate] AS '製造日期', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & PDGV2.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] Like '%" & Label10.Text & "%' "
            sql += " GROUP BY T0.[MnfDate] ORDER BY T0.[MnfDate] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT4")
            PDGV22.DataSource = ks2DataSetDGV.Tables("PDT4")
            TransactionMonitor.Complete()

            PDGV22.AutoResizeColumns()

            PDGV22.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            PDGV22.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            PDGV22.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'MsgBox("查詢完成")

    End Sub

    Private Sub SQLPDGV21Display()
        '--查詢預解        清空PDGV2內容
        If PDGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', '' AS '庫位', "
            sql += "      (CASE ISNULL(T2.[庫存量],'0')  WHEN '0'  THEN '0'  ELSE T2.[庫存量] END) AS '庫存量', "
            sql += "      (CASE ISNULL(T3.[重量],'0')    WHEN '0'  THEN '0'  ELSE T3.[重量]   END) AS '重量', "
            sql += "      (CASE ISNULL(T1.[預領量],'--') WHEN '--' THEN '--' ELSE T1.[預領量] END) AS '預領量',"
            'sql += "      (CASE ISNULL(CAST(CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量] AS NUMERIC) AS varchar),'0') WHEN '0' THEN '' ELSE CAST(CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)AS varchar) END) AS '差異數', '' AS '製造日期', '0' AS '天數' "
            sql += "      (CASE ISNULL((CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)),'0') WHEN '0' THEN '0' ELSE (CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)) END) AS '差異數', '' AS '製造日期', '0' AS '天數' "
            sql += "  FROM [Z_KS_SPdata2] T0 LEFT OUTER JOIN"
            sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T0.[Quantity]),0) AS '預領量' "
            sql += "         FROM [Z_KS_SPicking] T0 "
            sql += "        WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Cancel] = 'Y'"
            sql += "     GROUP BY T0.[ItemCode]) T1 ON T0.[ItemCode] = T1.[ItemCode] LEFT OUTER JOIN"
            sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T1.[Quantity]),0) AS '庫存量' "
            sql += "         FROM [OSRN] T0 LEFT OUTER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "        WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T0.[U_M2] Like '%" & ComboBox1.Text & "%') "
            sql += "     GROUP BY T0.[ItemCode]) T2 ON T0.[ItemCode] = T2.[ItemCode] LEFT OUTER JOIN"
            sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(CAST(T0.[U_M1] AS numeric(19, 4))),2) as '重量' "
            sql += "         FROM [OSRN] T0 LEFT OUTER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "        WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' AND T1.[Quantity]  > 0 or (T1.[Quantity]  > 0 AND T0.[U_M2] Like '%" & ComboBox1.Text & "%') "
            sql += "     GROUP BY T0.[ItemCode]) T3 ON T0.[ItemCode] = T3.[ItemCode]"
            sql += " WHERE T0.[Floor]    = '3' AND "
            sql += "       T0.[ItemName] Like '%" & TextBox1.Text & "%' "
            sql += " ORDER BY 1 "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT2")
            PDGV2.DataSource = ks2DataSetDGV.Tables("PDT2")
            TransactionMonitor.Complete()

            PDGV2.AutoResizeColumns()

            PDGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            PDGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            PDGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

            'If PDGV2.RowCount > 0 Then
            '    Dim Red As Integer = 0

            '    For i As Integer = 0 To PDGV2.RowCount - 1

            '        'Dim Qut As Single = "" = 0

            '        'Qut = CInt(PDGV2.Rows(i).Cells("差異數").Value)

            '        If CInt(PDGV2.Rows(i).Cells("差異數").Value) < 0 Then
            '            PDGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
            '            Red += 1
            '        End If
            '    Next
            'End If


        End Using
        Label10.Text = "預解"
        'PDGV2_Sorted()
        'P2Source.Text = "預解"
        MsgBox("查詢完成")

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        If ComboBox1.Text = "" Then
            MsgBox("未選擇儲位!", 16, "錯誤")
            ComboBox1.Focus()
            Exit Sub
        End If

        If PItemName.Text = "" Then
            MsgBox("未選擇品項!", 16, "錯誤")
            'ComboBox1.Focus()
            Exit Sub
        End If

        SQLPDGV212Display()

    End Sub

    Private Sub SQLPDGV212Display()
        '--儲位查詢
        '清空PDGV2內容
        If PDGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            ''sql = "    SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', '--' AS '庫存量', '--' AS '重量', "
            ''sql += "          (CASE ISNULL(T1.[預領量],'--') WHEN '--' THEN '--' ELSE T1.[預領量] END) AS '預領量', '--' AS '預領量', '--' AS '差異數'"
            ''sql += "     FROM [Z_KS_SPdata2] T0 LEFT JOIN"
            ''sql += "          (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T0.[Quantity]),0) AS '預領量' "
            ''sql += "             FROM [Z_KS_SPicking] T0 "
            ''sql += "            WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Cancel] = 'Y' "
            ''sql += " GROUP BY T0.[ItemCode]) T1 ON T0.[ItemCode] = T1.[ItemCode]"
            ''sql += "    WHERE T0.[Floor] = '3'"


            sql = " SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', '' AS '庫位', "
            sql += "      (CASE ISNULL(T2.[庫存量],'0')  WHEN '0'  THEN '0'  ELSE T2.[庫存量] END) AS '庫存量', "
            sql += "      (CASE ISNULL(T3.[重量],'0')    WHEN '0'  THEN '0'  ELSE T3.[重量]   END) AS '重量', "
            sql += "      (CASE ISNULL(T1.[預領量],'--') WHEN '--' THEN '--' ELSE T1.[預領量] END) AS '預領量',"
            'sql += "      (CASE ISNULL(CAST(CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)AS varchar),'0') WHEN '0' THEN '' ELSE CAST(CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)AS varchar) END) AS '差異數', '' AS '製造日期', '0' AS '天數' "
            sql += "      (CASE ISNULL((CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)),'0') WHEN '0' THEN '0' ELSE (CAST(T2.[庫存量] AS NUMERIC)-CAST(T1.[預領量]AS NUMERIC)) END) AS '差異數', '' AS '製造日期', '0' AS '天數' "
            sql += "  FROM (SELECT DISTINCT T1.[ItemCode] AS 'ItemCode', T1.[ItemName] AS 'ItemName'"
            'sql += "         FROM [Z_KS_Scheduling] T0 LEFT  JOIN [Z_KS_SPicking] T1 ON T0.[LineNum] = T1.[CodLineNum] AND T0.[DocDate] = T1.[DocDate] AND  T0.[Floor]   = T1.[Floor] AND T0.[Period]  = T1.[Period]"
            sql += "         FROM [Z_KS_Scheduling] T0 LEFT  JOIN [Z_KS_SPicking] T1 ON T0.[Sid] = T1.[CodLineNum] AND T0.[DocDate] = T1.[DocDate] AND  T0.[Floor]   = T1.[Floor] AND T0.[Period]  = T1.[Period]"
            sql += "        WHERE T0.[ItemCode] = '" & Label40.Text & "' AND T0.[Cancel] = 'Y' AND T1.[Cancel] = 'Y') T0 LEFT OUTER JOIN"
            sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T0.[Quantity]),0) AS '預領量' "
            sql += "         FROM [Z_KS_SPicking] T0 "
            sql += "        WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Cancel] = 'Y'"
            sql += "     GROUP BY T0.[ItemCode]) T1 ON T0.[ItemCode] = T1.[ItemCode] LEFT OUTER JOIN"
            sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(T1.[Quantity]),0) AS '庫存量' "
            sql += "         FROM [OSRN] T0 LEFT OUTER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "        WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T0.[U_M2] Like '%" & ComboBox1.Text & "%') "
            sql += "     GROUP BY T0.[ItemCode]) T2 ON T0.[ItemCode] = T2.[ItemCode] LEFT OUTER JOIN"
            sql += "      (SELECT T0.[ItemCode], dbo.getRoundN(SUM(CAST(T0.[U_M1] AS numeric(19, 4))),2) as '重量' "
            sql += "         FROM [OSRN] T0 LEFT OUTER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "        WHERE T0.[U_M2] Like '%" & ComboBox1.Text & "%' AND T1.[Quantity]  > 0 or (T1.[Quantity]  > 0 AND T0.[U_M2] Like '%" & ComboBox1.Text & "%') "
            sql += "     GROUP BY T0.[ItemCode]) T3 ON T0.[ItemCode] = T3.[ItemCode]"
            'sql += " WHERE T0.[Floor]    = '3' AND "
            'sql += "       T0.[ItemName] Like '%" & TextBox1.Text & "%' "
            sql += " ORDER BY 1 "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT2")
            PDGV2.DataSource = ks2DataSetDGV.Tables("PDT2")
            TransactionMonitor.Complete()

            PDGV2.AutoResizeColumns()

            PDGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            PDGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            PDGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

            'If PDGV2.RowCount > 0 Then
            '    Dim Red As Integer = 0

            '    For i As Integer = 0 To PDGV2.RowCount - 1

            '        'Dim Qut As Single = "" = 0

            '        'Qut = CInt(PDGV2.Rows(i).Cells("差異數").Value)

            '        If CInt(PDGV2.Rows(i).Cells("差異數").Value) < 0 Then
            '            PDGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
            '            Red += 1
            '        End If
            '    Next
            'End If


        End Using
        Label10.Text = ""
        'PDGV2_Sorted()
        'P2Source.Text = "預解"
        MsgBox("查詢完成")

    End Sub



    Private Sub PDGV2_Sorted()

        If PDGV2.RowCount > 0 Then
            Dim Red As Integer = 0
            Dim Yellow As Integer = 0

            For i As Integer = 0 To PDGV2.RowCount - 1
                If PDGV2.Rows(i).Cells("庫位").Value = "退料區" Then
                    PDGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Red += 1
                End If
            Next

            For x As Integer = 0 To PDGV2.RowCount - 1
                If CInt(PDGV2.Rows(x).Cells("天數").Value) >= 3 Then
                    PDGV2.Rows(x).Cells("天數").Style.BackColor = Color.Yellow
                    Yellow += 1
                End If
            Next

        End If

    End Sub


    Private Sub PDGV2_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles PDGV2.Sorted
        PDGV2_Sorted()
    End Sub


    Private Sub PDGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PDGV2.CellClick
        '選擇領料品項
        If PDGV2.RowCount = -1 Then
            Exit Sub
        End If

        P2ItemCode.Text = PDGV2.CurrentRow.Cells("存編").Value
        P2ItemName.Text = PDGV2.CurrentRow.Cells("品名").Value
        P2Source.Text = Label10.Text

        'P2Source.Text = ComboBox1.Text

        '點選作業單後, 顯示明細資料在PDGV22

        '20121102停用
        '' ''If PDGV22.RowCount > 0 Then
        '' ''    ks2DataSetDGV.Tables("PDT4").Clear()
        '' ''End If

        '' ''SQLPDGV2Display2()              '載入選取製單之生產明細單 

        PDGV2_Sorted()

    End Sub

    Private Sub SQLPDGV3Display()
        '--查詢領料品項
        '清空PDGV3內容
        If PDGV3.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [LineNum]  AS '列號', [CodLineNum]  AS '對應', [U_CK02] AS '製單', [CardName] AS '客戶', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity] AS '數量',[Source] AS '來源', [Remarks] AS '備註' FROM [Z_KS_SPicking] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period.SelectedIndex & "' "

            If CheckBox1.Checked Then
                sql += "AND [CodLineNum] = '" & PLineNum.Text & "'"
            End If

            sql += "AND [Cancel] = 'Y' ORDER BY 2 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "PDT3")
            PDGV3.DataSource = ks2DataSetDGV.Tables("PDT3")
            TransactionMonitor.Complete()

            'PDGV3.AutoResizeColumns()

            'PDGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'PDGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'PDGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯

            SQLPDGV31Display()
        End Using

    End Sub

    Private Sub SQLPDGV31Display()
        '--載入資料畫面
        For Each column As DataGridViewColumn In PDGV3.Columns

            PDGV3.AllowUserToAddRows = False
            PDGV3.AllowUserToDeleteRows = False

            column.ReadOnly = True  'DataGridView 設定單元格不可編輯
            column.Visible = True

            Select Case column.Name
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 0 : column.Visible = False 'column.ReadOnly = True
                Case "對應" : column.HeaderText = "對應" : column.DisplayIndex = 1 : column.Visible = True  'column.ReadOnly = True
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 2 : column.Visible = True  'column.ReadOnly = True
                Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 7 : column.Visible = False 'column.ReadOnly = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 3 : column.Visible = True  'column.ReadOnly = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 4 : column.Visible = True  'column.ReadOnly = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 5 : column.Visible = True  'column.ReadOnly = False 'column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight 'column.DefaultCellStyle.Format = "#0"
                Case "來源" : column.HeaderText = "來源" : column.DisplayIndex = 6 : column.Visible = True  'column.ReadOnly = True
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 8 : column.Visible = True  'column.ReadOnly = True

                Case Else

                    column.Visible = False

            End Select
        Next

        PDGV3.AutoResizeColumns()

        PDGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        PDGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        PDGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯
    End Sub

    Private Function PsetCarEntry()
        '領料品項之列號
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT  TOP 1 [LineNum] FROM [Z_KS_SPicking] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period.SelectedIndex & "' ORDER BY [LineNum] DESC "

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

    Private Sub PAddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAddItemBtn.Click
        '新增領料品項
        If PLineNum.Text = "" Then
            MsgBox("對應未選擇!", 16, "錯誤")
            'CardName.Focus()
            Exit Sub
        End If

        If P2ItemCode.Text = "" Then
            MsgBox("存編未選擇!", 16, "錯誤")
            P2ItemCode.Focus()
            Exit Sub
        End If

        If P2ItemName.Text = "" Then
            MsgBox("品名未選擇!", 16, "錯誤")
            P2ItemName.Focus()
            Exit Sub
        End If

        If P2Quantity.Text = "" Then
            MsgBox("數量未選擇!", 16, "錯誤")
            P2Quantity.Focus()
            Exit Sub
        End If

        Dim Row As DataRow
        Row = ks2DataSetDGV.Tables("PDT3").NewRow
        Row.Item("列號") = P2LineNum.Text
        Row.Item("對應") = PLineNum.Text
        Row.Item("製單") = P2U_CK02.Text
        Row.Item("客戶") = P2CardName.Text
        Row.Item("存編") = P2ItemCode.Text
        Row.Item("品名") = P2ItemName.Text
        Row.Item("數量") = P2Quantity.Text
        Row.Item("來源") = P2Source.Text
        Row.Item("備註") = P2Remarks.Text
        'Row.Item("重量") = Weight.Text

        ks2DataSetDGV.Tables("PDT3").Rows.Add(Row)

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim Cancel As String = "Y"
        Try
            sql = "INSERT INTO [Z_KS_SPicking] ([DocDate], [Floor], [Period], [LineNum], [CodLineNum], [U_CK02], [CardName], [ItemCode], [ItemName], [Quantity], [Source], [Remarks], [Cancel], [CodOPDocNum]) VALUES " & _
                  " ('" & dateDocDate.Value.Date & "','" & Floor.SelectedIndex & "','" & Period.SelectedIndex & "','" & P2LineNum.Text & "','" & PLineNum.Text & "','" & P2U_CK02.Text & "','" & P2CardName.Text & "', '" & P2ItemCode.Text & "', '" & P2ItemName.Text & "', '" & P2Quantity.Text & "', '" & P2Source.Text & "', '" & P2Remarks.Text & "', '" & Cancel & "', '" & T1OPDocNum.Text & "' )"
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

        'MsgBox("新增項目完成!", 64, "成功")

        '清空資  
        'PLineNum.Text = ""
        'PItemName.Text = ""
        'PWeight.Text = ""
        'Label15.Text = 0

        'P2LineNum.Text = ""
        'P2U_CK02.SelectedIndex = -1       '重新選擇製單
        P2ItemCode.Text = ""
        P2ItemName.Text = ""
        'P2CardName.SelectedIndex = -1     '重新選擇客戶料
        P2Source.Text = ""
        P2Quantity.Text = ""
        P2Remarks.Text = ""

        '更新列號
        Dim i As Integer
        i = PsetCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        P2LineNum.Text = i

    End Sub

    Private Sub PMdyItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PMdyItemBtn.Click
        '修改資料至 PDGV3 畫面

        'ItemBtn
        PAddItemBtn.Enabled = False   '關閉新增
        PMdyItemBtn.Enabled = False   '關閉修改
        PSaveItemBtn.Enabled = True   '開啟更新
        PDelItemBtn.Enabled = False   '關閉刪除

        CheckBox1.Checked = True

        If PDGV3.RowCount > 0 Then
            ks2DataSetDGV.Tables("PDT3").Clear()
        End If

    End Sub

    Private Sub PSaveItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSaveItemBtn.Click
        '更新資料

        If P2U_CK02.Text = "" Then
            MsgBox("製單未選擇!", 16, "錯誤")
            P2U_CK02.Focus()
            Exit Sub
        End If

        If P2CardName.Text = "" Then
            MsgBox("客戶未選擇!", 16, "錯誤")
            P2CardName.Focus()
            Exit Sub
        End If

        If P2ItemCode.Text = "" Then
            MsgBox("存編未輸入!", 16, "錯誤")
            P2ItemCode.Focus()
            Exit Sub
        End If

        If P2ItemName.Text = "" Then
            MsgBox("品項未輸入!", 16, "錯誤")
            P2ItemName.Focus()
            Exit Sub
        End If

        If P2Quantity.Text = "" Then
            MsgBox("數量未輸入!", 16, "錯誤")
            P2Quantity.Focus()
            Exit Sub
        End If

        'If Number.Text = "" Then
        '    MsgBox("人數未填!", 16, "錯誤")
        '    Number.Focus()
        '    Exit Sub
        'End If

        'ItemBtn
        PAddItemBtn.Enabled = True     '開啟新增
        PMdyItemBtn.Enabled = True     '開啟修改
        PDelItemBtn.Enabled = True     '開啟刪除
        PSaveItemBtn.Enabled = False   '關閉更新

        PUpdateItemDetail()

        PUpdateToDB()

        SQLPDGV3Display()

        '清空資料
        P2ItemCode.Text = ""
        P2ItemName.Text = ""
        P2Source.Text = ""
        P2Quantity.Text = ""

        '更新列號
        Dim i As Integer
        i = PsetCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        P2LineNum.Text = i



    End Sub

    Private Sub PDGV3_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles PDGV3.CellClick
        'If DGV1.RowCount <= 0 Then
        '    Exit Sub
        'End If

        If PDGV3.RowCount = -1 Then
            Exit Sub
        End If

        If PMdyItemBtn.Enabled = False Then

            'LineNum.Text = DGV1.AutoGenerateColumns.ToString
            P2LineNum.Text = PDGV3.CurrentRow.Cells("列號").Value
            'P2U_CK02.Text = PDGV3.CurrentRow.Cells("製單").Value
            P2CardName.Text = PDGV3.CurrentRow.Cells("客戶").Value
            P2ItemCode.Text = PDGV3.CurrentRow.Cells("存編").Value
            P2ItemName.Text = PDGV3.CurrentRow.Cells("品名").Value
            P2Source.Text = PDGV3.CurrentRow.Cells("來源").Value
            P2Quantity.Text = PDGV3.CurrentRow.Cells("數量").Value

        End If

    End Sub

    Private Sub PUpdateItemDetail()
        'PDGV3.CurrentRow.Cells("列號").Value = LineNum.Text
        PDGV3.CurrentRow.Cells("製單").Value = P2U_CK02.Text
        PDGV3.CurrentRow.Cells("客戶").Value = P2CardName.Text
        PDGV3.CurrentRow.Cells("存編").Value = P2ItemCode.Text
        PDGV3.CurrentRow.Cells("品名").Value = P2ItemName.Text
        PDGV3.CurrentRow.Cells("來源").Value = P2Source.Text
        PDGV3.CurrentRow.Cells("數量").Value = P2Quantity.Text

    End Sub

    Private Sub PUpdateToDB()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            For i As Integer = 0 To PDGV3.RowCount - 1

                sql = "UPDATE [Z_KS_SPicking] SET [U_CK02] = '" & PDGV3.Rows(i).Cells("製單").Value & "', [CardName] = '" & PDGV3.Rows(i).Cells("客戶").Value & "', [ItemCode] = '" & PDGV3.Rows(i).Cells("存編").Value & "', [ItemName] = '" & PDGV3.Rows(i).Cells("品名").Value & "', [Source] =  '" & PDGV3.Rows(i).Cells("來源").Value & "', [Quantity] = '" & PDGV3.Rows(i).Cells("數量").Value & "', [CodOPDocNum] = '" & T1OPDocNum.Text & "' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & PDGV3.Rows(i).Cells("列號").Value & "' and [Cancel] = 'Y' "
                'sql = "UPDATE [Z_KS_Scheduling] SET [U_CK02] = '" & P2U_CK02.Text & "', [CardName] = '" & P2CardName.Text & "', [ItemCode] = '" & P2ItemCode.Text & "', [ItemName] = '" & P2ItemName.Text & "', [Source] =  '" & P2Source.Text & "', [Quantity] = '" & P2Quantity.Text & "' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & P2LineNum.Text & "' and [Cancel] = 'Y' "

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
    Private Sub PDelItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDelItemBtn.Click
        '刪除領料項目按鈕
        PDelItemDetail()
        SQLPDGV3Display()

        '更新列號
        Dim i As Integer
        i = PsetCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        P2LineNum.Text = i

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then

            SQLPDGV3Display()

        End If
    End Sub

    Private Sub CodDelItemDetail()
        '由排程刪除生產品項連動刪除領料項目
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [Z_KS_SPicking] SET [Cancel] = 'N' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [CodLineNum] = '" & DGV1.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
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

        MsgBox("刪除領料項目完成!", 64, "成功")
    End Sub

    Private Sub PDelItemDetail()
        '刪除領料項目
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [Z_KS_SPicking] SET [Cancel] = 'N' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & PDGV3.CurrentRow.Cells("列號").Value & "' and [Cancel] = 'Y' "
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

        MsgBox("刪除領料項目完成!", 64, "成功")
    End Sub

    Private Sub SQLTDGV1()
        '--查詢類別程式
        '清空PDGV2內容
        If TDGV1.RowCount > 0 Then
            ks3DataSetDGV.Tables("TDT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "exec z_SPdataAll '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks3DataSetDGV, "TDT1")
            TDGV1.DataSource = ks3DataSetDGV.Tables("TDT1")
            TransactionMonitor.Complete()

            TDGV1.AutoResizeColumns()

            TDGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            TDGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            TDGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub T3SearchAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3SearchAll.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = False
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = False
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = False

        SQLTDGV16085()
        'SQLTDGV1()

    End Sub

    Private Sub T3Search_00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_00.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = False
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = False

        SQLTDGV16085()

    End Sub

    Private Sub T3Search_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_01.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = False
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = True
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = False

        SQLTDGV16085()

    End Sub

    Private Sub T3Search_02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_02.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = False
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = True
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = False

        SQLTDGV16085()

    End Sub

    Private Sub T3Search_03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_03.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = False
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = True
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = False

        SQLTDGV16085()

    End Sub

    Private Sub T3Search_04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_04.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = False
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = True
        'Button6.Enabled = False
        'Button7.Enabled = False

        SQLTDGV16085()

    End Sub

    Private Sub T3Search_05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_05.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = False
        T3Search_06.Enabled = True
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = True
        'Button7.Enabled = False

        SQLTDGV16085()

    End Sub

    Private Sub T3Search_06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_06.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = False
        T3Search_07.Enabled = True

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = True

        SQLTDGV16085()
    End Sub

    Private Sub T3Search_07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search_07.Click
        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '查詢
        T3SearchAll.Enabled = True
        T3Search_00.Enabled = True
        T3Search_01.Enabled = True
        T3Search_02.Enabled = True
        T3Search_03.Enabled = True
        T3Search_04.Enabled = True
        T3Search_05.Enabled = True
        T3Search_06.Enabled = True
        T3Search_07.Enabled = False

        '列印
        Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
        'Button7.Enabled = True

        SQLTDGV16085()
    End Sub




    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SQLTDGV16085()
    End Sub


    Private Sub SQLTDGV16085()
        '--查詢類別程式
        '清空PDGV2內容
        If TDGV1.RowCount > 0 Then
            ks3DataSetDGV.Tables("TDT1").Clear()
        End If

        'Dim M01, M02, P00, P01, P02, P03, P04, P05, P06 As Byte
        'Dim S00, S01, S02, S03, S04, S05, S06 As String


        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'Dim M01, M02, P01, P02, P03, P04, P05, P06 As String

            Dim M01, M02, M03, P00, P01, P02, P03, P04, P05, P06, P07, S00, S01, S02, S03, S04, S05, S06, S07 As String

            M01 = "" : M02 = "" : M03 = ""
            P00 = "" : P01 = "" : P02 = "" : P03 = "" : P04 = "" : P05 = "" : P06 = "" : P07 = ""
            S00 = "" : S01 = "" : S02 = "" : S03 = "" : S04 = "" : S05 = "" : S06 = "" : S07 = ""

            If T3Search_00.Enabled = False Then
                M01 = "0" : M02 = "6" : M03 = "7"
                P00 = "0" : P01 = "1" : P02 = "2" : P03 = "3" : P04 = "4" : P05 = "5" : P06 = "6"
                S00 = "0630" : S01 = "0700" : S02 = "0730" : S03 = "0800" : S04 = "0830" : S05 = "0900" : S06 = "0930"
            End If

            If T3Search_01.Enabled = False Then
                M01 = "7" : M02 = "10" : M03 = "4"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = "7" : P04 = "8" : P05 = "9" : P06 = "10"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1000" : S04 = "1030" : S05 = "1100" : S06 = "1130"
            End If

            If T3Search_02.Enabled = False Then
                M01 = "11" : M02 = "14" : M03 = "4"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = "11" : P04 = "12" : P05 = "13" : P06 = "14"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1200" : S04 = "1230" : S05 = "1300" : S06 = "1330"
            End If

            If T3Search_03.Enabled = False Then
                M01 = "15" : M02 = "18" : M03 = "4"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = "15" : P04 = "16" : P05 = "17" : P06 = "18"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1400" : S04 = "1430" : S05 = "1500" : S06 = "1530"
            End If

            If T3Search_04.Enabled = False Then
                M01 = "19" : M02 = "22" : M03 = "4"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = "19" : P04 = "20" : P05 = "21" : P06 = "22"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1600" : S04 = "1630" : S05 = "1700" : S06 = "1730"
            End If

            If T3Search_05.Enabled = False Then
                M01 = "23" : M02 = "26" : M03 = "4"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = "23" : P04 = "24" : P05 = "25" : P06 = "26"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1800" : S04 = "1830" : S05 = "1900" : S06 = "1930"
            End If

            If T3Search_06.Enabled = False Then
                M01 = "27" : M02 = "30" : M03 = "4"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = " 27" : P04 = "28" : P05 = "29" : P06 = "30"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "2000" : S04 = "2030" : S05 = "2100" : S06 = "2130"
            End If

            If T3Search_07.Enabled = False Then
                M01 = "31" : M02 = "35" : M03 = "5"
                P00 = "無" : P01 = "無" : P02 = "無" : P03 = "31" : P04 = "32" : P05 = "33" : P06 = "34" : P07 = "35"
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "2200" : S04 = "2230" : S05 = "2300" : S06 = "2330" : S07 = "2400"
            End If

            'Dim MX03 As String = "5"

            If T3SearchAll.Enabled = False Then

                sql = "exec z_SPdataAll '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            Else

                sql = "  SELECT A.[U_CK02] AS '製單', A.[ItemCode] AS '存編', A.[ItemName] AS '品名', A.[數量] AS '總數量', "

                If T3Search_00.Enabled = False Then
                    sql += "  (CASE ISNULL(B.[" & S00 & "],0) WHEN '0' THEN '' ELSE B.[" & S00 & "] END) AS '" & S00 & "', "
                    sql += "  (CASE ISNULL(C.[" & S01 & "],0) WHEN '0' THEN '' ELSE C.[" & S01 & "] END) AS '" & S01 & "', "
                    sql += "  (CASE ISNULL(D.[" & S02 & "],0) WHEN '0' THEN '' ELSE D.[" & S02 & "] END) AS '" & S02 & "', "
                End If

                sql += "      (CASE ISNULL(E.[" & S03 & "],0) WHEN '0' THEN '' ELSE E.[" & S03 & "] END) AS '" & S03 & "', "
                sql += "      (CASE ISNULL(F.[" & S04 & "],0) WHEN '0' THEN '' ELSE F.[" & S04 & "] END) AS '" & S04 & "', "
                sql += "      (CASE ISNULL(G.[" & S05 & "],0) WHEN '0' THEN '' ELSE G.[" & S05 & "] END) AS '" & S05 & "', "

                If T3Search_07.Enabled = False Then
                    sql += "  (CASE ISNULL(H.[" & S06 & "],0) WHEN '0' THEN '' ELSE H.[" & S06 & "] END) AS '" & S06 & "', "
                    sql += "  (CASE ISNULL(I.[" & S07 & "],0) WHEN '0' THEN '' ELSE I.[" & S07 & "] END) AS '" & S07 & "'  "
                Else
                    sql += "  (CASE ISNULL(H.[" & S06 & "],0) WHEN '0' THEN '' ELSE H.[" & S06 & "] END) AS '" & S06 & "'  "
                End If

                sql += " FROM (SELECT T0.[DocDate],T0.[Floor],T0.[U_CK02],T0.[ItemCode],T0.[ItemName],SUM(T0.[Quantity]) AS '數量' FROM [Z_KS_SPicking] T0 WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND ([Period] Between '" & M01 & "' AND '" & M02 & "') AND T0.[Cancel] = 'Y' GROUP BY T0.[DocDate],T0.[Floor],T0.[U_CK02],T0.[ItemCode],T0.[ItemName]) A LEFT JOIN "

                If T3Search_00.Enabled = False Then
                    sql += "  (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S00 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P00 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) B ON A.[U_CK02] = B.[U_CK02] AND A.[ItemCode] = B.[ItemCode] LEFT JOIN "
                    sql += "  (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S01 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P01 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) C ON A.[U_CK02] = C.[U_CK02] AND A.[ItemCode] = C.[ItemCode] LEFT JOIN "
                    sql += "  (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S02 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P02 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) D ON A.[U_CK02] = D.[U_CK02] AND A.[ItemCode] = D.[ItemCode] LEFT JOIN "
                End If

                sql += "      (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S03 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P03 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) E ON A.[U_CK02] = E.[U_CK02] AND A.[ItemCode] = E.[ItemCode] LEFT JOIN "
                sql += "      (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S04 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P04 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) F ON A.[U_CK02] = F.[U_CK02] AND A.[ItemCode] = F.[ItemCode] LEFT JOIN "
                sql += "      (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S05 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P05 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) G ON A.[U_CK02] = G.[U_CK02] AND A.[ItemCode] = G.[ItemCode] LEFT JOIN "

                If T3Search_07.Enabled = False Then
                    sql += "  (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S06 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P06 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) H ON A.[U_CK02] = H.[U_CK02] AND A.[ItemCode] = H.[ItemCode] LEFT JOIN "
                    sql += "  (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S07 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P07 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) I ON A.[U_CK02] = I.[U_CK02] AND A.[ItemCode] = I.[ItemCode] "
                Else
                    sql += "  (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],CAST(SUM(T1.[Quantity])AS varchar) AS '" & S06 & "'    FROM [Z_KS_SPicking] T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '" & P06 & "' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) H ON A.[U_CK02] = H.[U_CK02] AND A.[ItemCode] = H.[ItemCode] "
                End If

                sql += " ORDER BY 1, 3, 2 "



                'sql += " ORDER BY 1 "

                'If LPT = False Then
                '    sql += " ORDER BY 1, 3, 2 "
                'Else
                '    sql += " ORDER BY 1 "
                'End If

            End If

            'sql = "  SELECT A.[U_CK02] AS '製單', A.[ItemCode] AS '存編', A.[ItemName] AS '品名', A.[數量] AS '總數量', "
            'sql += " (CASE ISNULL(B.[0630],0) WHEN '0' THEN '0' ELSE B.[0630] END) AS '0630', "
            'sql += " (CASE ISNULL(C.[0700],0) WHEN '0' THEN '0' ELSE C.[0700] END) AS '0700', "
            'sql += " (CASE ISNULL(D.[0730],0) WHEN '0' THEN '0' ELSE D.[0730] END) AS '0730', "
            'sql += " (CASE ISNULL(E.[0800],0) WHEN '0' THEN '0' ELSE E.[0800] END) AS '0800', "
            'sql += " (CASE ISNULL(F.[0830],0) WHEN '0' THEN '0' ELSE F.[0830] END) AS '0830', "
            'sql += " (CASE ISNULL(G.[0900],0) WHEN '0' THEN '0' ELSE G.[0900] END) AS '0900'  "
            'sql += " FROM (SELECT T0.[DocDate],T0.[Floor],T0.[U_CK02],T0.[ItemCode],T0.[ItemName],SUM(T0.[Quantity]) AS '數量' FROM Z_KS_SPicking T0 WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND ([Period] Between '0' AND '5') AND T0.[Cancel] = 'Y' GROUP BY T0.[DocDate],T0.[Floor],T0.[U_CK02],T0.[ItemCode],T0.[ItemName]) A LEFT JOIN "
            'sql += " (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],SUM(T1.[Quantity]) AS '0630' FROM Z_KS_SPicking T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '0' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) B ON A.U_CK02 = B.U_CK02 AND A.ItemCode = B.ItemCode LEFT JOIN "
            'sql += " (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],SUM(T1.[Quantity]) AS '0700' FROM Z_KS_SPicking T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '1' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) C ON A.U_CK02 = C.U_CK02 AND A.ItemCode = C.ItemCode LEFT JOIN "
            'sql += " (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],SUM(T1.[Quantity]) AS '0730' FROM Z_KS_SPicking T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '2' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) D ON A.U_CK02 = D.U_CK02 AND A.ItemCode = D.ItemCode LEFT JOIN "
            'sql += " (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],SUM(T1.[Quantity]) AS '0800' FROM Z_KS_SPicking T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '3' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) E ON A.U_CK02 = E.U_CK02 AND A.ItemCode = E.ItemCode LEFT JOIN "
            'sql += " (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],SUM(T1.[Quantity]) AS '0830' FROM Z_KS_SPicking T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '4' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) F ON A.U_CK02 = F.U_CK02 AND A.ItemCode = F.ItemCode LEFT JOIN "
            'sql += " (SELECT T1.[U_CK02],T1.[ItemCode],T1.[Period],SUM(T1.[Quantity]) AS '0900' FROM Z_KS_SPicking T1 WHERE T1.[DocDate] = '" & dateDocDate.Value.Date & "' AND T1.[Floor] = '" & Floor.SelectedIndex & "' AND T1.[Cancel] = 'Y' AND T1.[Period] = '5' GROUP BY T1.[U_CK02],T1.[ItemCode],T1.[Period]) G ON A.U_CK02 = G.U_CK02 AND A.ItemCode = G.ItemCode ORDER BY 3 "



            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks3DataSetDGV, "TDT1")
            TDGV1.DataSource = ks3DataSetDGV.Tables("TDT1")
            TransactionMonitor.Complete()

            'TDGV1.Refresh()
            'TDGV1.AutoResizeColumns()

            'TDGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'TDGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'TDGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

            SQLTDGV160852()
            Label21.Text = Floor.Text
            Label26.Text = TimeOfDay.ToShortTimeString

        End Using

        'LPT = True

        MsgBox("查詢完成")

    End Sub

    Private Sub SQLTDGV160852()

        For Each column As DataGridViewColumn In TDGV1.Columns

            'Dim M01, M02, P00, P01, P02, P03, P04, P05, P06, S00, S01, S02, S03, S04, S05, S06 As String
            Dim S00, S01, S02, S03, S04, S05, S06, S07 As String

            S00 = "" : S01 = "" : S02 = "" : S03 = "" : S04 = "" : S05 = "" : S06 = "" : S07 = ""

            If T3Search_00.Enabled = False Then
                'M01 = 0 : M02 = 6
                'P00 = 0 : P01 = 1 : P02 = 2 : P03 = 3 : P04 = 4 : P05 = 5 : P06 = 6
                S00 = "0630" : S01 = "0700" : S02 = "0730" : S03 = "0800" : S04 = "0830" : S05 = "0900" : S06 = "0930"
            End If

            If T3Search_01.Enabled = False Then
                'M01 = 7 : M02 = 10
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 7 : P04 = 8 : P05 = 9 : P06 = 10
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1000" : S04 = "1030" : S05 = "1100" : S06 = "1130"
            End If

            If T3Search_02.Enabled = False Then
                'M01 = 11 : M02 = 14
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 11 : P04 = 12 : P05 = 13 : P06 = 14
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1200" : S04 = "1230" : S05 = "1300" : S06 = "1330"
            End If

            If T3Search_03.Enabled = False Then
                'M01 = 15 : M02 = 18
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 15 : P04 = 16 : P05 = 17 : P06 = 18
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1400" : S04 = "1430" : S05 = "1500" : S06 = "1530"
            End If

            If T3Search_04.Enabled = False Then
                'M01 = 19 : M02 = 22
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 19 : P04 = 20 : P05 = 21 : P06 = 22
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1600" : S04 = "1630" : S05 = "1700" : S06 = "1730"
            End If

            If T3Search_05.Enabled = False Then
                'M01 = 23 : M02 = 26
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 23 : P04 = 24 : P05 = 25 : P06 = 26
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "1800" : S04 = "1830" : S05 = "1900" : S06 = "1930"
            End If

            If T3Search_06.Enabled = False Then
                'M01 = 27 : M02 = 30
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 27 : P04 = 28 : P05 = 29 : P06 = 30
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "2000" : S04 = "2030" : S05 = "2100" : S06 = "2130"
            End If

            If T3Search_07.Enabled = False Then
                'M01 = 31 : M02 = 35 : M03 = 5
                'P00 = "無" : P01 = "無" : P02 = "無" : P03 = 31 : P04 = 32 : P05 = 33 : P06 = 34 : P07 = 35
                S00 = "無" : S01 = "無" : S02 = "無" : S03 = "2200" : S04 = "2230" : S05 = "2300" : S06 = "2330" : S07 = "2400"
            End If



            column.Visible = True

            If T3SearchAll.Enabled = False Then

                Select Case column.Name
                    Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                    Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 3
                        'Case "0600" : column.HeaderText = "0600" : column.DisplayIndex = 4 : column.Visible = False      '01
                    Case "0630" : column.HeaderText = "0630" : column.DisplayIndex = 4      '01
                    Case "0700" : column.HeaderText = "0700" : column.DisplayIndex = 5      '02
                    Case "0730" : column.HeaderText = "0730" : column.DisplayIndex = 6      '03
                    Case "0800" : column.HeaderText = "0800" : column.DisplayIndex = 7      '04
                    Case "0830" : column.HeaderText = "0830" : column.DisplayIndex = 8      '05
                    Case "0900" : column.HeaderText = "0900" : column.DisplayIndex = 9      '06
                    Case "0930" : column.HeaderText = "0930" : column.DisplayIndex = 10     '07
                    Case "1000" : column.HeaderText = "1000" : column.DisplayIndex = 11     '08
                    Case "1030" : column.HeaderText = "1030" : column.DisplayIndex = 12     '09
                    Case "1100" : column.HeaderText = "1100" : column.DisplayIndex = 13     '10
                    Case "1130" : column.HeaderText = "1130" : column.DisplayIndex = 14     '11
                    Case "1200" : column.HeaderText = "1200" : column.DisplayIndex = 15     '12
                    Case "1230" : column.HeaderText = "1230" : column.DisplayIndex = 16     '13
                    Case "1300" : column.HeaderText = "1300" : column.DisplayIndex = 17     '14
                    Case "1330" : column.HeaderText = "1330" : column.DisplayIndex = 18     '15
                    Case "1400" : column.HeaderText = "1400" : column.DisplayIndex = 19     '16
                    Case "1430" : column.HeaderText = "1430" : column.DisplayIndex = 20     '17
                    Case "1500" : column.HeaderText = "1500" : column.DisplayIndex = 21     '18
                    Case "1530" : column.HeaderText = "1530" : column.DisplayIndex = 22     '19
                    Case "1600" : column.HeaderText = "1600" : column.DisplayIndex = 23     '20
                    Case "1630" : column.HeaderText = "1630" : column.DisplayIndex = 24     '21
                    Case "1700" : column.HeaderText = "1700" : column.DisplayIndex = 25     '22
                    Case "1730" : column.HeaderText = "1730" : column.DisplayIndex = 26     '23
                    Case "1800" : column.HeaderText = "1800" : column.DisplayIndex = 27     '24
                    Case "1830" : column.HeaderText = "1830" : column.DisplayIndex = 28     '25
                    Case "1900" : column.HeaderText = "1900" : column.DisplayIndex = 29     '26
                    Case "1930" : column.HeaderText = "1930" : column.DisplayIndex = 30     '27
                    Case "2000" : column.HeaderText = "2000" : column.DisplayIndex = 31     '28
                    Case "2030" : column.HeaderText = "2030" : column.DisplayIndex = 32     '29
                    Case "2100" : column.HeaderText = "2100" : column.DisplayIndex = 33     '30
                    Case "2130" : column.HeaderText = "2130" : column.DisplayIndex = 34     '31
                    Case "2200" : column.HeaderText = "2200" : column.DisplayIndex = 35     '32
                    Case "2230" : column.HeaderText = "2230" : column.DisplayIndex = 36     '33
                    Case "2300" : column.HeaderText = "2300" : column.DisplayIndex = 37     '34
                    Case "2330" : column.HeaderText = "2330" : column.DisplayIndex = 38     '35
                    Case "2400" : column.HeaderText = "2400" : column.DisplayIndex = 39     '36

                    Case Else

                        column.Visible = False

                End Select

            ElseIf T3Search_00.Enabled = False Then
                '
                Select Case column.Name
                    Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                    Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 3
                    Case S00 : column.HeaderText = S00 : column.DisplayIndex = 4
                    Case S01 : column.HeaderText = S01 : column.DisplayIndex = 5
                    Case S02 : column.HeaderText = S02 : column.DisplayIndex = 6
                    Case S03 : column.HeaderText = S03 : column.DisplayIndex = 7
                    Case S04 : column.HeaderText = S04 : column.DisplayIndex = 8
                    Case S05 : column.HeaderText = S05 : column.DisplayIndex = 9
                    Case S06 : column.HeaderText = S06 : column.DisplayIndex = 10
                    Case Else

                        column.Visible = False

                End Select

            ElseIf T3Search_01.Enabled = False Or T3Search_02.Enabled = False Or T3Search_03.Enabled = False Or T3Search_04.Enabled = False Or T3Search_05.Enabled = False Or T3Search_06.Enabled = False Then
                '
                Select Case column.Name
                    Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                    Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 3
                    Case S03 : column.HeaderText = S03 : column.DisplayIndex = 4
                    Case S04 : column.HeaderText = S04 : column.DisplayIndex = 5
                    Case S05 : column.HeaderText = S05 : column.DisplayIndex = 6
                    Case S06 : column.HeaderText = S06 : column.DisplayIndex = 7
                    Case Else

                        column.Visible = False

                End Select

            ElseIf T3Search_07.Enabled = False Then
                '
                Select Case column.Name
                    Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                    Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 3
                    Case S03 : column.HeaderText = S03 : column.DisplayIndex = 4
                    Case S04 : column.HeaderText = S04 : column.DisplayIndex = 5
                    Case S05 : column.HeaderText = S05 : column.DisplayIndex = 6
                    Case S06 : column.HeaderText = S06 : column.DisplayIndex = 7
                    Case S07 : column.HeaderText = S07 : column.DisplayIndex = 8
                    Case Else

                        column.Visible = False

                End Select

            End If
            'End If
        Next

        TDGV1.AutoResizeColumns()
        TDGV1.AllowUserToAddRows = False
        TDGV1.AllowUserToDeleteRows = False
        TDGV1.ReadOnly = True  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub BtnToExcel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel1.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub BtnToExcel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel2.Click
        DataToExcel(PDGV3, "")
    End Sub

    Private Sub BtnToExcel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel3.Click
        DataToExcel(TDGV1, "")
    End Sub

    Private Sub Floor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Floor.SelectedIndexChanged

        'If Floor.SelectedIndex = 1 Then
        '    CheckBox2.Visible = False
        '    CheckBox2.Checked = False
        'Else
        '    CheckBox2.Visible = True
        'End If

    End Sub



    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click

        Report_1()

        'MsgBox("請確認各樓層是否已有列印")

    End Sub

    Private Sub Report_1()

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可列印")
            Exit Sub
        End If

        '-------
        CheckBox1.Checked = False           '關閉列號鎖定
        SearchScheduling.Enabled = False    '關閉查詢排程及領料

        SQLPDGV1Display()
        SQLPDGV3Display()

        '更新列號
        Dim i As Integer
        i = PsetCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        P2LineNum.Text = i
        '-------
        Dim Period_1 As String = ""

        Select Case Period.SelectedIndex
            Case 0 : Period_1 = "06:20"
            Case 1 : Period_1 = "06:50"
            Case 2 : Period_1 = "07:20"
            Case 3 : Period_1 = "07:50"
            Case 4 : Period_1 = "08:20"
            Case 5 : Period_1 = "08:50"
            Case 6 : Period_1 = "09:20"
            Case 7 : Period_1 = "09:50"
            Case 8 : Period_1 = "10:20"
            Case 9 : Period_1 = "10:50"
            Case 10 : Period_1 = "11:20"
            Case 11 : Period_1 = "11:50"
            Case 12 : Period_1 = "12:20"
            Case 13 : Period_1 = "12:50"
            Case 14 : Period_1 = "13:20"
            Case 15 : Period_1 = "13:50"
            Case 16 : Period_1 = "14:20"
            Case 17 : Period_1 = "14:50"
            Case 18 : Period_1 = "15:20"
            Case 19 : Period_1 = "15:50"
            Case 20 : Period_1 = "16:20"
            Case 21 : Period_1 = "16:50"
            Case 22 : Period_1 = "17:20"
            Case 23 : Period_1 = "17:50"
            Case 24 : Period_1 = "18:20"
            Case 25 : Period_1 = "18:50"
            Case 26 : Period_1 = "19:20"
            Case 27 : Period_1 = "19:50"
            Case 28 : Period_1 = "20:20"
            Case 29 : Period_1 = "20:50"
            Case 30 : Period_1 = "21:20"
            Case 31 : Period_1 = "21:50"
            Case 32 : Period_1 = "22:20"
            Case 33 : Period_1 = "22:50"
            Case 34 : Period_1 = "23:20"
            Case 35 : Period_1 = "23:50"
                'Case 36 : Period_1 = "24:20"

        End Select

        'MsgBox(dateDocDate.Value.Date)
        'MsgBox(Floor.Text)
        'Dim Date_Doc As String = Format(dateDocDate.Value.Date, "MM月dd日")

        B_ReportViewer.MdiParent = MainForm
        B_ReportViewer.Source = "OrderPicking"
        B_ReportViewer.strPara(0) = Format(dateDocDate.Value.Date, "MM月dd日")
        B_ReportViewer.strPara(1) = Floor.Text
        B_ReportViewer.strPara(2) = Format(Period.Text).ToString
        B_ReportViewer.strPara(3) = Period_1
        B_ReportViewer.strPara(4) = LSum_Wh.Text

        B_ReportViewer.dt1 = ks1DataSetDGV.Tables("DT1")
        B_ReportViewer.dt2 = ks2DataSetDGV.Tables("PDT3")


        B_ReportViewer.Show()

    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        LPT = False


        If TDGV1.RowCount = 0 Then
            MsgBox("無資料可列印")
            Exit Sub
        End If

        B_ReportViewer.MdiParent = MainForm

        Select Case TDGV1.RowCount <> 0
            Case T3Search_00.Enabled = False : B_ReportViewer.Source = "SPicking1"
            Case T3Search_01.Enabled = False : B_ReportViewer.Source = "SPicking2"
            Case T3Search_02.Enabled = False : B_ReportViewer.Source = "SPicking3"
            Case T3Search_03.Enabled = False : B_ReportViewer.Source = "SPicking4"
            Case T3Search_04.Enabled = False : B_ReportViewer.Source = "SPicking5"
            Case T3Search_05.Enabled = False : B_ReportViewer.Source = "SPicking6"
            Case T3Search_06.Enabled = False : B_ReportViewer.Source = "SPicking7"
            Case T3Search_07.Enabled = False : B_ReportViewer.Source = "SPicking8"
        End Select

        B_ReportViewer.strPara(0) = Format(dateDocDate.Value.Date, "MM月dd日")
        B_ReportViewer.strPara(1) = Label21.Text
        B_ReportViewer.dt = ks3DataSetDGV.Tables("TDT1")
        B_ReportViewer.Show()

    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    '    If TDGV1.RowCount = 0 Then
    '        MsgBox("無資料可列印")
    '        Exit Sub
    '    End If

    '    B_ReportViewer.MdiParent = MainForm
    '    B_ReportViewer.Source = "SPicking2"
    '    B_ReportViewer.strPara(0) = Format(dateDocDate.Value.Date, "MM月dd日")
    '    B_ReportViewer.strPara(1) = Floor.Text
    '    B_ReportViewer.dt = ks3DataSetDGV.Tables("TDT1")
    '    B_ReportViewer.Show()

    'End Sub



    Private Sub U_CK021_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CK021.SelectedIndexChanged

        Select Case U_CK021.SelectedIndex
            Case 0
            Case 1 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
            Case 2 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "002"
            Case 3 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "003"
            Case 4 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "004"
            Case 5 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "005"
            Case 6 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "006"
            Case 7 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "007"
            Case 8 : U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "008"
            Case 9 : U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
            Case 10 : U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "002"
            Case 11 : U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "003"
            Case 12 : U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "004"
            Case 13 : U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "005"
            Case 14 : U_CK02.Text = "5" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
            Case 15 : U_CK02.Text = "6" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
        End Select
    End Sub

    Private Sub P2U_CK02_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles P2U_CK02.SelectedIndexChanged

        'Select Case P2U_CK02.SelectedIndex
        '    Case 0
        '    Case 1 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
        '    Case 2 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "002"
        '    Case 3 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "003"
        '    Case 4 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "004"
        '    Case 5 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "005"
        '    Case 6 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "006"
        '    Case 7 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "007"
        '    Case 8 : P2U_CK02.Text = "2" + Format(dateDocDate.Value.Date, "yyMMdd") + "008"
        '    Case 9 : P2U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
        '    Case 10 : P2U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "002"
        '    Case 11 : P2U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "003"
        '    Case 12 : P2U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "004"
        '    Case 13 : P2U_CK02.Text = "3" + Format(dateDocDate.Value.Date, "yyMMdd") + "005"
        '    Case 14 : P2U_CK02.Text = "5" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
        '    Case 15 : P2U_CK02.Text = "6" + Format(dateDocDate.Value.Date, "yyMMdd") + "001"
        'End Select
    End Sub

    Private Sub XXX()

    End Sub



    Private Sub Tab4But1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab4But1.Click
        Tab4ButAll()
    End Sub

    Private Sub Tab4ButAll()
        '--查詢類別程式
        '清空PDGV2內容
        If TDGV2.RowCount > 0 Then
            ks3DataSetDGV.Tables("TDT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "exec z_SPdataAll2 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks3DataSetDGV, "TDT2")
            TDGV2.DataSource = ks3DataSetDGV.Tables("TDT2")
            TransactionMonitor.Complete()

            TDGV2.Refresh()
            TDGV2.AutoResizeColumns()

            TDGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            TDGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            TDGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        Label28.Text = Floor.Text
        Label27.Text = TimeOfDay.ToShortTimeString

        MsgBox("查詢完成")


    End Sub



    Private Sub Tab5T5DGV1Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab5T5DGV1Search.Click

        If Tab5Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Tab5Floor.Focus()
            Exit Sub
        End If

        If Tab5RBPerild.Checked = True Then

            If Tab5Period.SelectedIndex = -1 Then
                MsgBox("請選擇時段!", 16, "錯誤")
                Tab5Period.Focus()
                Exit Sub
            End If

            If Tab5PeriodS.SelectedIndex = -1 Then
                MsgBox("請選擇至那一個時段!", 16, "錯誤")
                Tab5Period.Focus()
                Exit Sub
            End If

        End If

        Tab5Scheduling()
        Tab5Scheduling2()

    End Sub

    Private Sub Tab5Scheduling()
        '--查詢類別程式     清空T5DGV1內容

        If T5DGV1.RowCount > 0 Then
            ks5DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "exec z_SPdataAll2 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            If Tab5RBFloor.Checked = True Then

                sql = " SELECT [DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardName],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel] FROM [Z_KS_Scheduling] WHERE [DocDate] = '" & Tab5Date.Value.Date & "' AND [Floor] = '" & Tab5Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2, 3 "

            Else

                sql = " SELECT [DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardName],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel] FROM [Z_KS_Scheduling] WHERE [DocDate] = '" & Tab5Date.Value.Date & "' AND [Floor] = '" & Tab5Floor.SelectedIndex & "' AND [Period] = '" & Tab5Period.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2, 3 "

            End If
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks5DataSetDGV, "DT1")
            T5DGV1.DataSource = ks5DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()

            T5DGV1.Refresh()
            T5DGV1.AutoResizeColumns()

            T5DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T5DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T5DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'MsgBox("查詢完成")

    End Sub

    Private Sub Tab5Scheduling2()
        '--查詢類別程式     清空T5DGV2內容

        If T5DGV2.RowCount > 0 Then
            ks5DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "exec z_SPdataAll2 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            If Tab5RBFloor.Checked = True Then

                sql = " SELECT [DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardName],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel] FROM [Z_KS_Scheduling] WHERE [DocDate] = '" & Tab5DateS.Value.Date & "' AND [Floor] = '" & Tab5Floor.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2, 3 "

            Else

                sql = " SELECT [OPDocNum],[DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardCode],[CardName],[ItemCode],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel] FROM [Z_KS_Scheduling] WHERE [DocDate] = '" & Tab5DateS.Value.Date & "' AND [Floor] = '" & Tab5Floor.SelectedIndex & "' AND [Period] = '" & Tab5PeriodS.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2, 3 "

            End If
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks5DataSetDGV, "DT2")
            T5DGV2.DataSource = ks5DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()

            T5DGV2.Refresh()
            T5DGV2.AutoResizeColumns()

            T5DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T5DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T5DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        MsgBox("查詢完成")

    End Sub




    Private Sub Tab5T5DGV1Copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab5T5DGV1Copy.Click

        If T5DGV2.RowCount > 0 Then
            MsgBox("已有資料無法複製!", 16, "錯誤")
            Exit Sub
        End If

        Tab5SchedulingCopy()
        Tab5Scheduling2()

    End Sub


    Private Sub Tab5SchedulingCopy()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            For i As Integer = 0 To T5DGV1.RowCount - 1

                'sql = "UPDATE [Z_KS_Scheduling] SET [U_CK02] = '" & DGV1.Rows(i).Cells("製單").Value & "', [CardName] = '" & DGV1.Rows(i).Cells("客戶").Value & "', [ItemName] = '" & DGV1.Rows(i).Cells("品名").Value & "', [Quantity] = '" & DGV1.Rows(i).Cells("數量").Value & "', [Number] = '" & DGV1.Rows(i).Cells("人數").Value & "', [Time] =  '" & DGV1.Rows(i).Cells("工時").Value & "', [Weight] =  '" & DGV1.Rows(i).Cells("重量").Value & "' WHERE [DocDate] = '" & dateDocDate.Value.Date & "' and [Floor] = '" & Floor.SelectedIndex & "' and [Period] = '" & Period.SelectedIndex & "' and [LineNum] = '" & DGV1.Rows(i).Cells("列號").Value & "' and [Cancel] = 'Y' "
                '[LineNum],[U_CK02],[CardName],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel]
                '" & T5DGV1.Rows(i).Cells("LineNum").Value & "','" & T5DGV1.Rows(i).Cells("U_CK02").Value & "','" & T5DGV1.Rows(i).Cells("CardName").Value & "','" & T5DGV1.Rows(i).Cells("ItemName").Value & "','" & T5DGV1.Rows(i).Cells("Quantity").Value & "','" & T5DGV1.Rows(i).Cells("Number").Value & "','" & T5DGV1.Rows(i).Cells("Time").Value & "','" & T5DGV1.Rows(i).Cells("Weight").Value & "','" & T5DGV1.Rows(i).Cells("Cancel").Value & "'

                If Tab5RBFloor.Checked = True Then

                    sql = "INSERT INTO [Z_KS_Scheduling] ([DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardName],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel]) VALUES "
                    sql += " ('" & Tab5DateS.Value.Date & "','" & Tab5Floor.SelectedIndex & "','" & T5DGV1.Rows(i).Cells("Period").Value & "','" & T5DGV1.Rows(i).Cells("LineNum").Value & "','" & T5DGV1.Rows(i).Cells("U_CK02").Value & "','" & T5DGV1.Rows(i).Cells("CardName").Value & "','" & T5DGV1.Rows(i).Cells("ItemName").Value & "','" & T5DGV1.Rows(i).Cells("Quantity").Value & "','" & T5DGV1.Rows(i).Cells("Number").Value & "','" & T5DGV1.Rows(i).Cells("Time").Value & "','" & T5DGV1.Rows(i).Cells("Weight").Value & "','" & T5DGV1.Rows(i).Cells("Cancel").Value & "' ) "

                Else

                    sql = "INSERT INTO [Z_KS_Scheduling] ([OPDocNum],[DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardCode],[CardName],[ItemCode],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel]) VALUES "
                    sql += " ('" & Tab5DateS.Value.Date & "'                   ,"
                    sql += "  '" & Tab5Floor.SelectedIndex & "'                ,"
                    sql += "  '" & Tab5PeriodS.SelectedIndex & "'              ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("LineNum").Value & "'  ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("U_CK02").Value & "'   ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("CardCode").Value & "' ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("CardName").Value & "' ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("ItemCode").Value & "' ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("ItemName").Value & "' ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("Quantity").Value & "' ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("Number").Value & "'   ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("Time").Value & "'     ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("Weight").Value & "'   ,"
                    sql += "  '" & T5DGV1.Rows(i).Cells("Cancel").Value & "'   ) "

                End If
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

        'MsgBox("複製完成")
        'MsgBox("更新至資料庫完成!", 64, "成功")

    End Sub








    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        '--查詢生產排程按鈕

        ''If Floor.SelectedIndex = -1 Then
        ''    MsgBox("請選擇樓層!", 16, "錯誤")
        ''    Floor.Focus()
        ''    Exit Sub
        ''End If

        If T6Period.SelectedIndex = -1 Then
            MsgBox("請選擇時段!", 16, "錯誤")
            T6Period.Focus()
            Exit Sub
        End If

        Button4List1()
        Button4List2()

    End Sub

    Private Sub Button4List1()
        '--查詢生產排程程式   '清空DGV1內容
        If T6DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("T6DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT '' as '製單', '' as '客戶', T2.[FrgnName] as '品名', SUM(T1.[U_P3_Quantity]) as '數量', '' as '人數', T1.[U_P6] as '單位', '' as '工時', '' as '原料' FROM ORDR T0  INNER JOIN RDR1 T1 ON T0.DocEntry = T1.DocEntry INNER JOIN OITM T2 ON T1.ItemCode = T2.ItemCode WHERE T1.[U_P3] = 'Y' and  T0.[DocDueDate]  = '" & dateDocDate.Value.Date & "' GROUP BY T2.[FrgnName], T1.[U_P6] "
            ''sql = "    SELECT [LineNum] AS '列號', [OPDocNum] AS '排程', [U_CK02] AS '製單', [CardCode] AS '客編', [CardName] AS '客戶', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity] AS '數量', [Number] AS '人數', [Time] AS '工時', [Weight] AS '重量' "
            ''sql += "     FROM [Z_KS_Scheduling] "
            ''sql += "    WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND "
            ''sql += "          [Floor]   = '" & Floor.SelectedIndex & "'    AND "
            ''sql += "          [Period]  = '" & Period.SelectedIndex & "'   AND "
            ''sql += "          [Cancel]  = 'Y' "
            ''sql += " ORDER BY 1 "

            sql = "    SELECT (CASE WHEN [Floor] = '0' THEN '一樓' ELSE CASE WHEN [Floor] = '1' THEN '二樓' ELSE '三樓' END END) AS '樓層', [U_CK02] AS '製單', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity] AS '數量' "
            sql += "     FROM [Z_KS_Scheduling] "
            sql += "    WHERE [DocDate] = '" & T6Date.Value.Date & "' AND "
            'sql += "          [Floor]   = '" & Floor.SelectedIndex & "'    AND "
            sql += "          [Period]  = '" & T6Period.SelectedIndex & "'   AND "
            sql += "          [Cancel]  = 'Y' "
            sql += " ORDER BY [Floor] "



            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T6DT1")
            T6DGV1.DataSource = ks1DataSetDGV.Tables("T6DT1")
            TransactionMonitor.Complete()

            T6DGV1.Refresh()
            T6DGV1.AutoResizeColumns()

            T6DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T6DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T6DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub

    Private Sub Button4List2()
        '--查詢生產排程程式   '清空DGV1內容
        If T6DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("T6DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            Dim T6Period_1 As String = ""
            Dim T6Period_2 As String = ""
            Dim T6Daets1 As String = ""
            Dim T6Daets2 As String = ""
            Dim FI102s As String = ""

            Select Case T6Period.SelectedIndex
                Case 0 : T6Period_1 = "06:30" : T6Period_2 = "07:00"
                Case 1 : T6Period_1 = "07:00" : T6Period_2 = "07:30"
                Case 2 : T6Period_1 = "07:30" : T6Period_2 = "08:00"
                Case 3 : T6Period_1 = "08:00" : T6Period_2 = "08:30"
                Case 4 : T6Period_1 = "08:30" : T6Period_2 = "09:00"
                Case 5 : T6Period_1 = "09:00" : T6Period_2 = "09:30"
                Case 6 : T6Period_1 = "09:30" : T6Period_2 = "10:00"
                Case 7 : T6Period_1 = "10:00" : T6Period_2 = "10:30"
                Case 8 : T6Period_1 = "10:30" : T6Period_2 = "11:00"
                Case 9 : T6Period_1 = "11:00" : T6Period_2 = "11:30"
                Case 10 : T6Period_1 = "11:30" : T6Period_2 = "12:00"
                Case 11 : T6Period_1 = "12:00" : T6Period_2 = "12:30"
                Case 12 : T6Period_1 = "12:30" : T6Period_2 = "13:00"
                Case 13 : T6Period_1 = "13:00" : T6Period_2 = "13:30"
                Case 14 : T6Period_1 = "13:30" : T6Period_2 = "14:00"
                Case 15 : T6Period_1 = "14:00" : T6Period_2 = "14:30"
                Case 16 : T6Period_1 = "14:30" : T6Period_2 = "15:00"
                Case 17 : T6Period_1 = "15:00" : T6Period_2 = "15:30"
                Case 18 : T6Period_1 = "15:30" : T6Period_2 = "16:00"
                Case 19 : T6Period_1 = "16:00" : T6Period_2 = "16:30"
                Case 20 : T6Period_1 = "16:30" : T6Period_2 = "17:00"
                Case 21 : T6Period_1 = "17:00" : T6Period_2 = "17:30"
                Case 22 : T6Period_1 = "17:30" : T6Period_2 = "18:00"
                Case 23 : T6Period_1 = "18:00" : T6Period_2 = "18:30"
                Case 24 : T6Period_1 = "18:30" : T6Period_2 = "19:00"
                Case 25 : T6Period_1 = "19:00" : T6Period_2 = "19:30"
                Case 26 : T6Period_1 = "19:30" : T6Period_2 = "20:00"
                Case 27 : T6Period_1 = "20:00" : T6Period_2 = "20:30"
                Case 28 : T6Period_1 = "20:30" : T6Period_2 = "21:00"
                Case 29 : T6Period_1 = "21:00" : T6Period_2 = "21:30"
                Case 30 : T6Period_1 = "21:30" : T6Period_2 = "22:00"
                Case 31 : T6Period_1 = "22:00" : T6Period_2 = "22:30"
            End Select

            T6Daets1 = T6Date.Value.Date + " " + T6Period_1
            T6Daets2 = T6Date.Value.Date + " " + T6Period_2
            FI102s = Format(T6Date.Value.Date, "yyMMdd")

            'MsgBox(T6Period_1)

            'MsgBox(T6Period_2)

            'MsgBox(FI102s)

            'MsgBox(T6Daets1)

            'MsgBox(T6Daets2)


            'T1OPDocNum.Text = "排" + Format(T6Date.Value.Date, "yyMMdd") + Format(Floor.SelectedIndex + 1, "#") + Format(Period.SelectedIndex + 1, "0#")



            sql = "SELECT (CASE WHEN SUBSTRING([FI106],1,1) IN ('C','B','E','F','U','V') THEN '一樓' ELSE CASE WHEN SUBSTRING([FI106],1,1) IN ('N','M') THEN '二樓' ELSE '三樓' END END) AS '樓層', "
            sql += " [FI102] AS '製單', [FI107] AS '存編', [FI108] AS '品名', (COUNT([FI107])) AS '件數', SUM([FI117]) AS '數量', [FI123] AS '單位', SUM([FI118]) AS '重量' "
            sql += " FROM [@FinishItem1] "
            sql += "  WHERE SUBSTRING([FI102],1,1) IN ('2','3') AND SUBSTRING([FI102],2,6) = '" & FI102s & "' AND [FI103] IN ('1','2','3','4') AND [FI129] between '" & T6Daets1 & "' AND '" & T6Daets2 & "' "
            sql += "GROUP BY SUBSTRING([FI106],1,1),[FI102],[FI107],[FI108],[FI123] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T6DT2")
            T6DGV2.DataSource = ks1DataSetDGV.Tables("T6DT2")
            TransactionMonitor.Complete()

            T6DGV2.Refresh()
            T6DGV2.AutoResizeColumns()

            T6DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T6DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T6DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub

    Private Sub 開啟_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 開啟.Click

        If Button_01.Enabled = True Then
            MsgBox("未查詢資料是不可使用本作業哦!!", 48, "大大警告")
            Exit Sub
        End If

        Panel2.Visible = True
    End Sub

    Private Sub 結束_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 結束.Click
        Panel2.Visible = False
    End Sub





    '------>移動及複製<------
    ' Panel2 位置  3, 363

    Private Sub 移動_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 移動.Click



        If DGV1.RowCount = 0 Then
            MsgBox("無資料可用", 48, "警告")
            Exit Sub
        End If

        If Period2.SelectedIndex = -1 Then
            MsgBox("請選擇移轉時段!", 16, "錯誤")
            Period2.Focus()
            Exit Sub
        End If

        移動排程()

        SQLDGV1Display()

    End Sub

    Private Sub 移動排程()

        Dim 列號ss As String = "" : Dim 列號sx As String = ""

        For Each oRow As DataGridViewRow In DGV1.SelectedRows
            If 列號ss = "" Then
                列號ss = 列號ss + Format(oRow.Cells("列號").Value, "")
            Else
                列號ss = 列號ss + "," + Format(oRow.Cells("列號").Value, "")
            End If
        Next

        列號sx = Format(Replace(列號ss, ",", "','"), "")

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "  UPDATE [Z_KS_Scheduling] SET [Period]  = '" & Period2.SelectedIndex & "' "
            SQLCmd.CommandText += "  WHERE [LineNum]    IN ('" & 列號sx & "') AND "
            SQLCmd.CommandText += "        [Cancel]  = 'Y' "
            SQLCmd.CommandText += " UPDATE [Z_KS_SPicking]   SET [Period]  = '" & Period2.SelectedIndex & "' "
            SQLCmd.CommandText += "  WHERE [CodLineNum] IN ('" & 列號sx & "') AND "
            SQLCmd.CommandText += "        [Cancel]  = 'Y' "

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

 

        Catch ex As Exception
            MsgBox("移轉排程: " & ex.Message)
            Exit Sub
        End Try

        MsgBox("移轉排程完成", 48, "移轉排程")


    End Sub

    Private Sub 複製_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 複製.Click

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可用", 48, "警告")
            Exit Sub
        End If

        If Period3.SelectedIndex = -1 Then
            MsgBox("請選擇移轉時段!", 16, "錯誤")
            Period2.Focus()
            Exit Sub
        End If

        複製排程()

        '更新列號
        Dim i As Integer
        i = setCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum.Text = i

    End Sub

    Private Sub setCarEntry2()

        '更新列號
        Dim i As Integer
        i = setCarEntry()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        LineNum3.Text = i

    End Sub

    Private Sub 複製排程()

        T1OPDocNum3.Text = "排" + Format(DocDate3.Value.Date, "yyMMdd") + Format(Floor.SelectedIndex + 1, "#") + Format(Period3.SelectedIndex + 1, "0#")

        ''Dim 列號ss As String = "" : Dim 列號sx As String = ""

        ''For Each oRowo As DataGridViewRow In DGV1.SelectedRows
        ''    If 列號ss = "" Then
        ''        列號ss = 列號ss + Format(oRowo.Cells("列號").Value, "")
        ''    Else
        ''        列號ss = 列號ss + "," + Format(oRowo.Cells("列號").Value, "")
        ''    End If
        ''Next

        ''列號sx = Format(Replace(列號ss, ",", "','"), "")

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn
            For Each oRow As DataGridViewRow In DGV1.SelectedRows

                setCarEntry2()

                Dim 製單sx As String = Format(Microsoft.VisualBasic.Left(oRow.Cells("製單").Value, 1) & Format(DocDate3.Value.Date, "yyMMdd") & Microsoft.VisualBasic.Right(oRow.Cells("製單").Value, 3), "")

                SQLCmd.CommandText = " INSERT INTO [Z_KS_Scheduling] ([DocDate],[Floor],[Period],[LineNum],[OPDocNum],[U_CK02],[CardCode],[CardName],[ItemSid],[ItemCode],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel]) VALUES "
                SQLCmd.CommandText += " ('" & DocDate3.Value.Date & "'         ,"
                SQLCmd.CommandText += "  '" & Floor.SelectedIndex & "'         ,"
                SQLCmd.CommandText += "  '" & Period3.SelectedIndex & "'       ,"
                'SQLCmd.CommandText += "  '" & LineNum.Text & "'          ,"
                SQLCmd.CommandText += "  '" & LineNum3.Text & "'               ,"
                SQLCmd.CommandText += "  '" & T1OPDocNum3.Text & "'            ,"
                'SQLCmd.CommandText += "  '" & U_CK02.Text & "'           ,"
                SQLCmd.CommandText += "  '" & 製單sx & "'                      ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("客編").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("客戶").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("ItemSid").Value & "' ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("存編").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("品名").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("數量").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("人數").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("工時").Value & "'    ,"
                SQLCmd.CommandText += "  '" & oRow.Cells("重量").Value & "'    ,"
                SQLCmd.CommandText += "  'Y'                                   )"

                SQLCmd.Parameters.Clear()
                SQLCmd.ExecuteNonQuery()
            Next

        Catch ex As Exception
            MsgBox("複製排程：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("複製排程完成!", 64, "成功")
    End Sub

End Class