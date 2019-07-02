Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 出庫作業v002
    Dim DataAdapterDGV, DataDGV5 As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim Excelds As DataSet

    Dim TypeSelect As String
    Dim oBorS As String         '
    Dim 區別F3 As String = ""

    Private Sub 出庫作業v002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LogonUserName = "manager" Then
            Panel2.Visible = True
        End If

        Label4.Text = 0                 '重覆
        Label5.Text = 0                 '未入庫
        Label6.Text = 0                 '出庫

        '異常條碼數量
        Label7.Text = 0                 '重覆
        Label8.Text = 0                 '未入庫
        Label9.Text = 0                 '出庫
        Label17.Text = 0                '草稿比對後異常數
        Label19.Text = 0                '差異數

        '初始化
        Label3.Text = ""                '目前作業
        區別.Text = ""                  '目前區別
        作業別.Text = ""                '目前作業別
        草稿.Text = ""                  '目前草稿
        作業別類.SelectedIndex = -1    '作業選項

    End Sub

    '-- 開始 --讀取 Excel 存入資料庫作業--[Z_KS_Barcode]
    Private Sub 存入條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存入條碼.Click

        讀取Excel()
        查詢條碼區別()
        Label5.Text = Format(DGV2.RowCount, "")
    End Sub

    Private Sub 讀取Excel()
        Dim openfile As New OpenFileDialog()
        'openfile.InitialDirectory = "..\"                  '開啟時預設的資料夾路徑   
        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"   '開啟時預設的資料夾路徑   
        openfile.Filter = "純文字 Files(*.txt)|*.txt"       '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim open1 As String = openfile.SafeFileName
        Dim open2 As String = Replace(openfile.FileName, openfile.SafeFileName, "")

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + open2 + ";Extended Properties='text;HDR=NO;FMT=TabDelimited';"

        ' if you don't want to sho the header row (first row) in the grid
        ' use 'HDR=NO' in the string

        Dim strSQL As String = "SELECT * FROM " & open1
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)

        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

        ExcelDGV.DataSource = dTable
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        'excelConnection.Close()
        'excelConnection.Dispose()

        If 電宰Rb.Checked = True Then
            上傳電宰條碼至MSSQL()
        Else
            上傳加工條碼至MSSQL()
        End If


    End Sub

    '電宰條碼上傳
    Private Sub 上傳電宰條碼至MSSQL()

        Dim F1 As String
        Dim F2 As String
        Dim F3 As String

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        'SQLCmd.CommandText = "INSERT INTO [Z_KS_Barcode] ([Del],[F1],[F2],[F3],[F4]) VALUES ('N',@str_1,@str_2,@str_3,'') "
        SQLCmd.CommandText = "INSERT INTO [Z_KS_Barcode] ([Del],[F1],[F2],[F3],[F4],[F7]) VALUES ('N', @str_1, @str_2, @str_3, '', '1' ) "


        For i As Integer = 0 To ExcelDGV.RowCount - 1
            If ExcelDGV.Rows(i).Cells("F1").FormattedValue <> "" Then
                F1 = Format(Replace(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 4), " ", ""), "")
                F2 = Format(Replace(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 6, 15), " ", ""), "")
                F3 = Format(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 1), "")
                SQLCmd.Parameters.Clear()
                SQLCmd.Parameters.AddWithValue("@str_1", F1)
                SQLCmd.Parameters.AddWithValue("@str_2", F2)
                SQLCmd.Parameters.AddWithValue("@str_3", F3)
                SQLCmd.ExecuteNonQuery()
            End If
        Next

        MsgBox("上傳完成  上傳 " + Format(ExcelDGV.RowCount, "") + " 筆")


    End Sub

    '加工條碼上傳
    Private Sub 上傳加工條碼至MSSQL()

        Dim F1 As String
        Dim F2 As String
        Dim F3 As String
        Dim F7 As Integer

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "INSERT INTO [Z_KS_Barcode] ([Del],[F1],[F2],[F3],[F4],[F7]) VALUES ('N', @str_1, @str_2, @str_3, '', @str_4 ) "

        For i As Integer = 0 To ExcelDGV.RowCount - 1
            If ExcelDGV.Rows(i).Cells("F1").FormattedValue <> "" Then
                F1 = Format(Replace(Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 4), " ", ""), "")
                F2 = Format(Replace(Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 6, 13), " ", ""), "")
                F3 = Format(Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 1), "")
                If Format(Replace(Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 19, 5 + 0), " ", ""), "") = vbNullString Then
                    F7 = 0
                Else
                    F7 = Format(Replace(Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 19, 5 + 0), " ", ""), "")
                End If

                SQLCmd.Parameters.Clear()
                SQLCmd.Parameters.AddWithValue("@str_1", F1)
                SQLCmd.Parameters.AddWithValue("@str_2", F2)
                SQLCmd.Parameters.AddWithValue("@str_3", F3)
                SQLCmd.Parameters.AddWithValue("@str_4", F7)
                SQLCmd.ExecuteNonQuery()
            End If
        Next

        MsgBox("上傳完成  上傳 " + Format(ExcelDGV.RowCount, "") + " 筆")

    End Sub

    '-- 結束 --讀取 Excel 存入資料庫作業--[Z_KS_Barcode]

    '-- 開始 --查詢文件草稿單號
    Private Sub 查詢文件草稿單號_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If 作業別類.SelectedIndex = -1 Then
            MsgBox("未選取查詢項目", 48, "警告")
            作業別類.Focus()
            Exit Sub
        End If

        Panel1.Visible = False

        查詢文件草稿單號()
        查詢條碼區別()
        '初始化
        區別.Text = ""               '目前區別
        草稿.Text = ""               '目前草稿
        Label3.Text = 作業別類.Text
        作業別.Text = 區別F3
        Label4.Text = Format(DGV1.RowCount, "")
        Label5.Text = Format(DGV2.RowCount, "")

    End Sub

    Private Sub 查詢文件草稿單號()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        '1:領料出庫,  5.委外代工出庫 ,6:採購入庫 ,7.生產調整
        'TypeSelect = 2:銷售出庫, TypeSelect = 4:寄庫品出庫, TypeSelect = 3:存貨領用, 

        Select Case 作業別類.SelectedIndex
            Case "0" : TypeSelect = "2" : 區別F3 = "A"      '銷售出庫
                sql = "     SELECT DISTINCT T0.[DocEntry], T0.[DocNum], T0.[CardCode], T0.[CardName], T0.[DocDate], T0.[TaxDate], T0.[DocDueDate], T0.[U_attachment], T0.[U_CK01], T0.[U_Cnum], T0.[U_N1], T0.[U_N2], T0.[U_N3], T0.[U_CarDr1], T0.[U_CarDr2], T0.[U_CarDr3], T0.[U_Dlst], T0.[U_updnum], T0.[U_TpMoney], T0.[Comments], T0.[U_Dnum] "
                sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O' "
                sql += "  ORDER BY T0.[U_Dnum] DESC "

            Case "1" : TypeSelect = "4" : 區別F3 = "A"     '寄庫品出庫
                sql = "     SELECT DISTINCT T0.[DocEntry], T0.[DocNum], T0.[CardCode], T0.[CardName], T0.[DocDate], T0.[TaxDate], T0.[DocDueDate], T0.[U_attachment], T0.[U_CK01], T0.[U_Cnum], T0.[U_N1], T0.[U_N2], T0.[U_N3], T0.[U_CarDr1], T0.[U_CarDr2], T0.[U_CarDr3], T0.[U_Dlst], T0.[U_updnum], T0.[U_TpMoney], T0.[Comments], T0.[U_Dnum] "
                sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                'sql += "     WHERE T0.[ObjType] = '15' AND (T1.[WhsCode] = 'O01' OR T1.[WhsCode] = 'K05' OR T1.[WhsCode] = 'S05')      AND T0.[DocStatus] = 'O' "
                sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] IN ('O01','K05','S05') AND T0.[DocStatus] = 'O' "
                sql += "  ORDER BY T0.[U_Dnum] DESC "

            Case "2" : TypeSelect = "3" : 區別F3 = "I"     '存領出庫
                sql = " Select Distinct K.[ID], "
                sql += " UF.IndexID, UF.Descr, "
                sql += "  CASE [DepartType]  "
                sql += "   When '0' then '營業' "
                sql += "   When '1' then '生管' "
                sql += "   When '2' then '人事' "
                sql += "   When '3' then '倉庫' "
                sql += "   When '4' then '會計' "
                sql += "   When '5' then '採購' "
                sql += "   When '6' then '總經理室' "
                sql += "   When '7' then '研發' "
                sql += "   When '8' then '設計' "
                sql += "   When '9' then '品管' "
                sql += "   When '10' then '加工' "
                sql += "   When '11' then '資訊' "
                sql += " End AS 'DepartName' , "
                sql += " convert(varchar(10),KD.GetProDate,112) AS GetProDate "
                sql += " From KS_Z_StockApply K "
                sql += " Left Join KS_Z_StockApply_Detail KD ON K.ID=KD.ID "
                sql += " Left Join UFD1 UF ON K.IndexID=UF.IndexID and UF.[FieldID] = '53' and UF.[TableID]='OIGE' "
                sql += " WHERE K.Examine='1' "

            Case "3" : TypeSelect = "2" : 區別F3 = "Z"     '銷售出庫_員購(福利社)出庫
                sql = "     SELECT DISTINCT T0.[DocEntry], T0.[DocNum], T0.[CardCode], T0.[CardName], T0.[DocDate], T0.[TaxDate], T0.[DocDueDate], T0.[U_attachment], T0.[U_CK01], T0.[U_Cnum], T0.[U_N1], T0.[U_N2], T0.[U_N3], T0.[U_CarDr1], T0.[U_CarDr2], T0.[U_CarDr3], T0.[U_Dlst], T0.[U_updnum], T0.[U_TpMoney], T0.[Comments], T0.[U_Dnum] "
                sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O' "
                sql += "     AND T0.[CardCode]  IN ('A0KS888889','A0KS888890','A0KS888892','A0KS888894')"
                sql += "  ORDER BY T0.[U_Dnum] DESC "
                'Case "4" : TypeSelect = "3" : 區別F3 = "B"     '領料出庫
                '    sql = "  SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum "
                '    sql = "    FROM ODRF T0 "
                '    sql = "   WHERE T0.ObjType = '60' AND T0.U_CK01 IN ('0','1','2','3','4') AND T0.DocStatus = 'O'"

        End Select

        '  0領料出庫  1銷售出庫  2存貨領用  3寄庫品出庫  4委外代工出庫  5生產調整
        ''    Case "1" ''    Case "3"
        ''    Case "0"''    Case "2"''    Case "4"''    Case "5"

        '' ''Case "1"
        '' ''    sql = " SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
        '' ''    sql += " WHERE T0.ObjType='15' and T1.WhsCode not in ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.DocStatus = 'O'"
        '' ''Case "3"
        '' ''    sql = "  SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
        '' ''    sql += "  WHERE T0.ObjType='15' and (T1.WhsCode='O01' or T1.WhsCode='K05' OR T1.WhsCode='S05') AND T0.DocStatus = 'O'"

        'Case "0"
        '    sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('5')  AND T0.DocStatus = 'O' "
        'Case "2"
        '    sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('0','1','2','3','4') AND T0.DocStatus = 'O'"
        'Case "4"
        '    sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('11') AND T0.DocStatus = 'O' "
        'Case "5"
        '    sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('14') AND T0.DocStatus = 'O' "


        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
        DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

        Select Case 作業別類.SelectedIndex
            Case "0" : 銷售出貨()   '銷售出庫
            Case "1" : 銷售出貨()   '寄庫品出庫
            Case "2" : 存領出貨()   '存領出貨
            Case "3" : 銷售出貨()   '銷售出庫_員購(福利社)出庫
                'Case "0" : setDGV1DisplayType1()
                'Case "1" : setDGV1DisplayType2()
                'Case "2" : setDGV1DisplayType1()
                'Case "3" : setDGV1DisplayType2()
                'Case "4" : setDGV1DisplayType1()
                'Case "5" : setDGV1DisplayType1()
        End Select

        DGV1.AutoResizeColumns()
        If DGV1.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 銷售出貨()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "U_Dnum"
                    column.HeaderText = "提單號"
                    column.DisplayIndex = 0
                Case "DocEntry"
                    column.HeaderText = "草稿單號"
                    column.DisplayIndex = 1
                Case "CardName"
                    column.HeaderText = "客戶"
                    column.DisplayIndex = 2
                Case "DocDueDate"
                    column.HeaderText = "到期日"
                    column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

    Private Sub 領料發貨()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "DocEntry"
                    column.HeaderText = "草稿單號"
                    column.DisplayIndex = 0
                Case "DocDueDate"
                    column.HeaderText = "文件日期"
                    column.DisplayIndex = 1
                Case "Comments"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 2
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub
    Private Sub 存領出貨()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "ID"
                    column.HeaderText = "存領編號"
                    column.DisplayIndex = 0
                Case "Descr"
                    column.HeaderText = "領用用途"
                    column.DisplayIndex = 1
                Case "DepartName"
                    column.HeaderText = "部門別"
                    column.DisplayIndex = 2
                Case "GetProDate"
                    column.HeaderText = "取貨日期"
                    column.DisplayIndex = 3
                Case "IndexID"
                    column.HeaderText = "領用用途(編號)"
                    column.DisplayIndex = 4
                    column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        Select Case 作業別類.SelectedIndex
            Case 0, 1, 3
                草稿.Text = DGV1.CurrentRow.Cells("DocEntry").Value
            Case 2
                草稿.Text = DGV1.CurrentRow.Cells("ID").Value
                'Case 3
                '    草稿.Text = DGV1.CurrentRow.Cells("草稿單號").Value
        End Select

    End Sub

    '-- 結束 --查詢文件草稿單號



    '-- 開始 -- 查詢條碼區別
    Private Sub 查詢條碼區別()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            Dim sWhere_1 As String = String.Empty

            If 區別F3 = "" Then
                sWhere_1 = "    WHERE [F3] IN ('A','B','I','Z') AND [Del] = 'N' "
            Else
                sWhere_1 = "    WHERE [F3]  = '" & 區別F3 & "'  AND [Del] = 'N' "
            End If

            SQLCmd.CommandText = "    SELECT [F1] AS '區別', [F4] AS '草稿單號', COUNT([F2]) AS '條碼數' "
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] "
            SQLCmd.CommandText += sWhere_1
            SQLCmd.CommandText += " GROUP BY [F1], [F4] "

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")

            DGV2.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount = -1 Then
            Exit Sub
        End If

        區別.Text = DGV2.CurrentRow.Cells("區別").Value

    End Sub

    Private Sub 查區別明細_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查區別明細.Click
        If 區別.Text = "" Then
            MsgBox("未選取查詢區別", 48, "警告")
            Exit Sub
        End If

        DGV3.Visible = True
        DGV4.Visible = False
        ComboBox2.SelectedIndex = -1

        Panel1.Visible = False

        查詢條碼區別明細()
        DGV3_ListStatus()

    End Sub

    Private Sub 查詢條碼區別明細()
        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @F1 varchar(5) "
            SQLCmd.CommandText += "DECLARE @F3 varchar(2) "
            SQLCmd.CommandText += "SET NOCOUNT ON "
            SQLCmd.CommandText += "SET @F1 = '" & 區別.Text & "' "
            SQLCmd.CommandText += "SET @F3 = '" & 區別F3 & "' "

            If 電宰Rb.Checked = True Then

                '暫時註解不用--加工扣帳使用
                'SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', '1' AS '出庫數量', CAST(ISNULL(T1.[Quantity],9999) AS NUMERIC(5,0)) AS '數量', T1.[U_M1] AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN ISNULL(T1.[Quantity],'9999') = '9999' THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態', ISNULL(T4.[M_NO],'') AS 'G1' "
                SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', CAST(ISNULL(T1.[Quantity],9999) AS NUMERIC(5,0)) AS '數量', ISNULL(T1.[U_M1],'異常') AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態', ISNULL(T4.[M_NO],'') AS 'G1' "
                SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT  JOIN "
                SQLCmd.CommandText += "         ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], SUM(ISNULL(T2.[Quantity],9999)) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate], T3.[SalPackUn] "
                SQLCmd.CommandText += "             FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLCmd.CommandText += "                            INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                SQLCmd.CommandText += "            WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = @F3 AND TX.[F1] = @F1 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
                SQLCmd.CommandText += "         GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate], T3.[SalPackUn] "
                SQLCmd.CommandText += "         )               T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "                            LEFT  JOIN [z_format_G] T4 ON T1.[U_M8] = T4.[M_NO] "
                SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE T0.[F3] = @F3 AND TX.[F1] = @F1 AND TX.[F2] = T0.[F2] AND T0.[Del] = 'N' ) "
                SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T1.[U_M1], T1.[U_M2], T1.[U_M8], T4.[M_NO] "
                SQLCmd.CommandText += " ORDER BY COUNT(T0.[F2]) DESC ,T0.[F2] "
            Else

                SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', T0.[F7] AS '出庫數量', CAST(ISNULL(T1.[Quantity],9999) AS NUMERIC(5,0)) AS '數量', ISNULL(T1.[U_M1],'異常') AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態', ''                    AS 'G1' "
                SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT  JOIN "
                SQLCmd.CommandText += "         ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], SUM(ISNULL(T2.[Quantity],9999)) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate], T3.[SalPackUn] "
                SQLCmd.CommandText += "             FROM [OBTN] T1 INNER JOIN [OBTQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLCmd.CommandText += "                            INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                SQLCmd.CommandText += "            WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = @F3 AND TX.[F1] = @F1 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
                SQLCmd.CommandText += "         GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate], T3.[SalPackUn] "
                SQLCmd.CommandText += "         )               T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE T0.[F3] = @F3 AND TX.[F1] = @F1 AND TX.[F2] = T0.[F2] AND T0.[Del] = 'N' ) "
                SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T1.[U_M1], T1.[U_M2], T1.[U_M8], T0.[F7] "
                SQLCmd.CommandText += " ORDER BY COUNT(T0.[F2]) DESC ,T0.[F2] "
            End If

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

            DGV3.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV3_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV3.Sorted
        DGV3_ListStatus()

    End Sub

    Private Sub DGV3_ListStatus()

        Dim Cnt0 As Integer = 0
        For i As Integer = 0 To DGV3.RowCount - 1   '以黃底顯示
            If DGV3.Rows(i).Cells("狀態").Value = "重覆" Then
                DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Cnt0 += 0 + 1
            End If
        Next

        Dim Cnt1 As Integer = 0
        For i As Integer = 0 To DGV3.RowCount - 1   '以紅底顯示
            If DGV3.Rows(i).Cells("狀態").Value = "未入庫" Then
                DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Red
                Cnt1 += 0 + 1
            End If
        Next

        Dim Cnt2 As Integer = 0
        For i As Integer = 0 To DGV3.RowCount - 1   '以Blue底顯示
            If DGV3.Rows(i).Cells("狀態").Value = "出庫" Then
                DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Blue
                Cnt2 += 0 + 1
            End If
        Next

        DGV3.ClearSelection()

        Label6.Text = Format(DGV3.RowCount, "")
        Label7.Text = Cnt0
        Label8.Text = Cnt1
        Label9.Text = Cnt2

    End Sub

    '-- 結束 -- 查詢條碼區別



    '-- 開始 -- 存草稿單號
    Private Sub 存草稿單號_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存草稿單號.Click

        If 草稿.Text = "" Then
            MsgBox("未選取草稿單號", 48, "警告")
            Exit Sub
        End If

        If 區別.Text = "" Then
            MsgBox("未選取存入區別", 48, "警告")
            Exit Sub
        End If

        存草稿單號至資料庫()

        MsgBox("完成")

    End Sub

    Private Sub 存草稿單號至資料庫()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "  UPDATE [Z_KS_Barcode] SET [F4] = '" & 草稿.Text & "' WHERE [F1] = '" & 區別.Text & "' AND [Del] = 'N' "
        SQLCmd.ExecuteNonQuery()

        DGV2.CurrentRow.Cells("草稿單號").Value = 草稿.Text


    End Sub

    Private Sub 清除單號_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除單號.Click
        If 區別.Text = "" Then
            MsgBox("未選取清除區別", 48, "警告")
            Exit Sub
        End If

        清除草稿單號至資料庫()

        MsgBox("完成")
    End Sub

    Private Sub 清除草稿單號至資料庫()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "  UPDATE [Z_KS_Barcode] SET [F4] = '' WHERE [F1] = '" & 區別.Text & "' AND [Del] = 'N' "
        SQLCmd.ExecuteNonQuery()

        DGV2.CurrentRow.Cells("草稿單號").Value = ""


    End Sub


    '-- 結束 -- 存草稿單號


    '-- 開始 -- 查異常條碼

    Private Sub 查異常條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查異常條碼.Click
        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("未選取查詢項目", 48, "警告")
            Exit Sub
        End If

        '比對前初始化
        DGV6.Visible = False
        Label17.Visible = False
        Label18.Visible = False
        Label19.Visible = False
        Label20.Visible = False
        發貨作業.Visible = False
        Panel1.Visible = False


        DGV3.Visible = False
        DGV4.Visible = True

        If ComboBox2.SelectedIndex <> 2 Then
            區別.Text = ""
        End If

        查詢異常條碼明細()

        If DGV4.RowCount = 0 Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If

        Label6.Text = Format(DGV4.RowCount, "")


    End Sub

    Private Sub 查詢異常條碼明細()
        If DGV4.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV4").Clear()
        End If


        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @F1 varchar(5) "
            SQLCmd.CommandText += "DECLARE @F3 varchar(2) "
            SQLCmd.CommandText += "SET NOCOUNT ON "
            SQLCmd.CommandText += "SET @F1 = '" & Format(Replace(區別.Text, " ", ""), "") & "' "
            SQLCmd.CommandText += "SET @F3 = '" & 區別F3 & "' "

            Select Case ComboBox2.SelectedIndex
                Case "0"    '重覆
                    'If 電宰Rb.Checked = True Then

                    SQLCmd.CommandText += "   SELECT T0.[Sid] AS 'Sid', T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', T0.[F1] AS '區別', T0.[F2] AS '條碼' "
                    SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]       = T1.[DistNumber] "
                    SQLCmd.CommandText += "                            LEFT JOIN [OBTN] T2 ON T0.[F2]       = T2.[DistNumber] "
                    SQLCmd.CommandText += "                            LEFT JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                    SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = @F3 AND TX.[F2] = T0.[F2] AND TX.[Del] = 'N' GROUP BY TX.[F2] HAVING COUNT(ISNULL(TX.[F2],0)) > 1 ) "
                    SQLCmd.CommandText += " ORDER BY T0.[F2] , T0.[Sid] "
                    'Else

                    'SQLCmd.CommandText += "   SELECT T0.[Sid] AS 'Sid', T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', T0.[F1] AS '區別', T0.[F2] AS '條碼' "
                    'SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OBTN] T1 ON T0.[F2]        = T1.[DistNumber] "
                    'SQLCmd.CommandText += "                            LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
                    'SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = @F3 AND TX.[F2] = T0.[F2] AND TX.[Del] = 'N' GROUP BY TX.[F2] HAVING COUNT(ISNULL(TX.[F2],0)) > 1 ) "
                    'SQLCmd.CommandText += " ORDER BY T0.[F2] , T0.[Sid] "
                    'End If
                Case "1"    '出庫

                    SQLCmd.CommandText += "    SELECT T0.[Sid] AS 'Sid', T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F1] AS '區別', T0.[F2] AS '條碼' "
                    SQLCmd.CommandText += "      FROM [Z_KS_Barcode] T0 LEFT JOIN "
                    SQLCmd.CommandText += "         ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], SUM(ISNULL(T2.[Quantity],9999)) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
                    SQLCmd.CommandText += "             FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                    SQLCmd.CommandText += "                            INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                    SQLCmd.CommandText += "            WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = @F3 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
                    SQLCmd.CommandText += "         GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
                    SQLCmd.CommandText += "         ) T1 ON T0.[F2] = T1.[DistNumber] "
                    SQLCmd.CommandText += "     WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE T0.[F2] = TX.[F2] AND T0.[F3] = @F3 AND T0.[Del] = 'N' ) AND T1.[Quantity] = 0 "
                    SQLCmd.CommandText += "  ORDER BY T0.[F2] , T0.[Sid] "
                Case "2"    '全部
                    If 區別.Text = "" Then
                        MsgBox("未選取查詢區別", 48, "警告")
                        Exit Sub
                    End If

                    SQLCmd.CommandText += "   SELECT T0.[Sid] AS 'Sid', T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F1] AS '區別', T0.[F2] AS '條碼' "
                    SQLCmd.CommandText += "      FROM [Z_KS_Barcode] T0 LEFT JOIN "
                    SQLCmd.CommandText += "         ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], SUM(ISNULL(T2.[Quantity],9999)) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
                    SQLCmd.CommandText += "             FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                    SQLCmd.CommandText += "                            INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                    SQLCmd.CommandText += "            WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F1] = @F1 AND TX.[F3] = @F3 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' )  "
                    SQLCmd.CommandText += "         GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
                    SQLCmd.CommandText += "         ) T1 ON T0.[F2] = T1.[DistNumber] "
                    SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F1] = @F1 AND TX.[F2] = T0.[F2] ) AND T0.[F3] = @F3 AND T0.[Del] = 'N' "
                    SQLCmd.CommandText += " ORDER BY T0.[F2] , T0.[Sid] "
            End Select

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV4")
            DGV4.DataSource = ks1DataSetDGV.Tables("DGV4")

            DGV4.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '-- 結束 -- 查異常條碼

    '-- 開始 -- 條碼比對

    Private Sub 草稿比對_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 草稿比對.Click

        If 草稿.Text = "" Then
            MsgBox("未選取草稿單號", 48, "警告")
            Exit Sub
        End If

        '比對前初始化
        稿號.Text = ""
        DGV3.Visible = True
        DGV4.Visible = False
        DGV6.Visible = False
        區別.Text = ""
        Label17.Visible = False
        Label18.Visible = False
        Label19.Visible = False
        Label20.Visible = False
        Label17.Text = 0
        Label19.Text = 0
        發貨作業.Visible = False
        ComboBox2.SelectedIndex = -1
        Panel1.Visible = False

        '開始比對
        查詢草稿比對()
        查詢草稿比對Columns()
        查詢比對非草稿上之品項()
        查詢條碼區別明細_草稿()
        DGV3_ListStatus()

        '比對有異常
        If DGV6.RowCount <> 0 Then
            DGV6.Visible = True
            Label17.Visible = True
            Label18.Visible = True
            Label17.Text = DGV6.RowCount
        End If


        'Dim SumWh As Integer = 0
        'For i As Integer = 0 To DGV5.RowCount - 1   '以黃底顯示
        '    If DGV5.Rows(i).Cells("差異數").Value <> 0 Then
        '        DGV5.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
        '        'SumWh += 0 + 1
        '    End If
        'Next

        Dim SumWh2 As Integer = 0
        For i As Integer = 0 To DGV5.RowCount - 1   '以黃底顯示
            If DGV5.Rows(i).Cells("預出數量").Value <> DGV5.Rows(i).Cells("出庫數量").Value Then
                DGV5.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                SumWh2 += 0 + 1
            End If
        Next


        If SumWh2 <> 0 Then
            Label19.Visible = True
            Label20.Visible = True
            Label19.Text = SumWh2
        End If

        If DGV3.RowCount = 0 Then
            MsgBox("無條碼可查詢", 48, "警告")
            Exit Sub
        End If

        If Label7.Text <> 0 Or Label8.Text <> 0 Or Label9.Text <> 0 Then
            MsgBox("出庫條碼有錯誤請修改", 48, "警告")
            Exit Sub
        End If

        If Label7.Text = 0 And Label8.Text = 0 And Label9.Text = 0 And Label17.Text = 0 And Label19.Text = 0 Then
            發貨作業.Visible = True
            'MsgBox("出庫條碼有錯誤請修改", 48, "警告")
            'Exit Sub
        End If

        稿號.Text = 草稿.Text

    End Sub

    Private Sub 查詢草稿比對()
        If DGV5.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV5").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @DocEntry varchar(15) "
            SQLCmd.CommandText += "SET NOCOUNT ON	"
            SQLCmd.CommandText += "SET @DocEntry = '" & 草稿.Text & "' "

            If 作業別類.SelectedIndex = "0" Or 作業別類.SelectedIndex = "1" Then
                'Case "0"    銷售出庫  Case "1"    寄庫品出庫

                SQLCmd.CommandText += "   SELECT S1.[DocEntry] AS '草稿單號', S1.[LineNum] AS '列號', S1.[ItemCode] AS '存編', S1.[Dscription] AS '品名', dbo.getRoundN(S1.[Quantity],0) AS '預出數量', ISNULL(S2.[Quantity],0) AS '出庫數量', dbo.getRoundN(S1.[Quantity] - ISNULL(S2.[Quantity],0),0) AS '差異數', S1.[WhsCode], S1.[U_p2], S1.[U_P5], S1.[U_P4], S1.[U_P6], S1.[U_P7], S1.[U_P8], S1.[U_P1], S1.[U_Cdate], S1.[U_Omoney], S1.[U_P3], S1.[BaseType], S1.[BaseRef], S1.[BaseEntry], S1.[BaseLine], S1.[Price], S1.[LineTotal] "
                SQLCmd.CommandText += "     FROM [DRF1] S1 LEFT JOIN "
                SQLCmd.CommandText += "        ( SELECT T1.[ItemCode] AS [ItemCode], COUNT(T0.[F2]) AS [Quantity] "
                SQLCmd.CommandText += "            FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "           WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F3] = 'A' AND T1.[DistNumber] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
                SQLCmd.CommandText += "        GROUP BY T1.[ItemCode] "
                SQLCmd.CommandText += "        ) S2 ON S1.[ItemCode] = S2.[ItemCode] "
                SQLCmd.CommandText += "    WHERE S1.[DocEntry] = @DocEntry "
                SQLCmd.CommandText += " ORDER BY 1 "
            ElseIf 作業別類.SelectedIndex = "2" Then
                'Case "2"    存領出庫
                SQLCmd.CommandText += "    SELECT S1.[ID] AS '存領編號', S1.[ProCode] AS '存編', S1.[ProName] AS '品名', "
                SQLCmd.CommandText += "          (Row_Number() OVER (partition by ID order by ID Asc, ProCode ASC) - 1) as '列號', "
                SQLCmd.CommandText += "    	      CASE S1.[Type] "
                SQLCmd.CommandText += "    	 	      WHEN '1' THEN '電宰品' "
                SQLCmd.CommandText += "    	          WHEN '2' THEN '加工品' "
                SQLCmd.CommandText += "    	          WHEN '3' THEN '其他品' "
                SQLCmd.CommandText += "          END '類型', dbo.getRoundN(S1.[Num],0) AS '預出數量', ISNULL(S2.[Quantity],0) AS '出庫數量', "
                SQLCmd.CommandText += "          dbo.getRoundN(S1.[Num] - ISNULL(S2.[Quantity],0),0) AS '差異數', T0.[Descr] AS '單位',  "
                SQLCmd.CommandText += "          convert(varchar(10),S1.[GetProDate],112) AS '取貨日期', S1.[MEMO] AS '備註'  "
                SQLCmd.CommandText += "     FROM [KS_Z_StockApply_Detail] S1 LEFT JOIN "
                SQLCmd.CommandText += "         (SELECT T1.[ItemCode] AS [ItemCode], COUNT(T0.[F2]) AS [Quantity] "
                SQLCmd.CommandText += "            FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "           WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F3] = 'A' AND T1.[DistNumber] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
                SQLCmd.CommandText += "        GROUP BY T1.[ItemCode] "
                SQLCmd.CommandText += "         ) S2 ON S1.[ProCode] = S2.[ItemCode] "
                SQLCmd.CommandText += "          LEFT JOIN UFD1 T0 ON S1.FldValue=T0.FldValue AND T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' "
                SQLCmd.CommandText += "    WHERE S1.[ID] = @DocEntry "
                SQLCmd.CommandText += " ORDER BY 1 "
            ElseIf 作業別類.SelectedIndex = "3" Then
                'Case "3"    員購(合作社)出庫
                SQLCmd.CommandText += "   SELECT S1.[DocEntry] AS '草稿單號', S1.[LineNum] AS '列號', S1.[ItemCode] AS '存編', S1.[Dscription] AS '品名', dbo.getRoundN(S1.[Quantity],0) AS '預出數量', ISNULL(S2.[Quantity],0) AS '出庫數量', dbo.getRoundN(S1.[Quantity] - ISNULL(S2.[Quantity],0),0) AS '差異數', S1.[WhsCode], S1.[U_p2], S1.[U_P5], S1.[U_P4], S1.[U_P6], S1.[U_P7], S1.[U_P8], S1.[U_P1], S1.[U_Cdate], S1.[U_Omoney], S1.[U_P3], S1.[BaseType], S1.[BaseRef], S1.[BaseEntry], S1.[BaseLine], S1.[Price], S1.[LineTotal] "
                SQLCmd.CommandText += "     FROM [DRF1] S1 LEFT JOIN "
                SQLCmd.CommandText += "        ( SELECT T1.[ItemCode] AS [ItemCode], COUNT(T0.[F2]) AS [Quantity] "
                SQLCmd.CommandText += "            FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "           WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F3] = 'Z' AND T1.[DistNumber] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
                SQLCmd.CommandText += "        GROUP BY T1.[ItemCode] "
                SQLCmd.CommandText += "        ) S2 ON S1.[ItemCode] = S2.[ItemCode] "
                SQLCmd.CommandText += "    WHERE S1.[DocEntry] = @DocEntry "
                SQLCmd.CommandText += " ORDER BY 1 "
            End If
            ''Select Case cobSelectType.SelectedIndex
            '  0領料出庫  1銷售出庫  2存貨領用  3寄庫品出庫  4委外代工出庫  5生產調整
            ''    Case "1" ''    Case "3"
            ''    Case "0"''    Case "2"''    Case "4"''    Case "5"


            ''    Case "1" ''    Case "3"
            ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6, U_P7, U_P8, U_P1, U_Cdate, U_Omoney, U_P3, BaseType, BaseRef, BaseEntry, BaseLine, Price, LineTotal from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' order by LineNum"
            ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6, U_P7, U_P8, U_P1, U_Cdate, U_Omoney, U_P3, BaseType, BaseRef, BaseEntry, BaseLine, Price, LineTotal from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' order by LineNum"

            '' ''    Case "2"
            '' ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"

            ''    Case "0"''    Case "2"''    Case "4"''    Case "5"
            ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"


            '' ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, Quantity, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            '' ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, Quantity, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            '' ''        Sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, Quantity, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            ''End Select


            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV5")
            DGV5.DataSource = ks1DataSetDGV.Tables("DGV5")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 查詢草稿比對Columns()
        Select Case 作業別類.SelectedIndex
            Case 0, 1, 3
                For Each column As DataGridViewColumn In DGV5.Columns
                    column.Visible = True
                    Select Case column.HeaderText

                        Case "草稿單號" : column.HeaderText = "草稿單號" : column.DisplayIndex = 0 : column.Visible = False
                        Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 1 : column.Visible = True
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2 : column.Visible = True
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3 : column.Visible = True
                        Case "預出數量" : column.HeaderText = "預出數量" : column.DisplayIndex = 4 : column.Visible = True
                        Case "出庫數量" : column.HeaderText = "出庫數量" : column.DisplayIndex = 5 : column.Visible = True
                        Case "差異數" : column.HeaderText = "差異數" : column.DisplayIndex = 6 : column.Visible = True
                        Case "WhsCode" : column.HeaderText = "WhsCode" : column.DisplayIndex = 7 : column.Visible = False
                        Case "U_p2" : column.HeaderText = "U_p2" : column.DisplayIndex = 8 : column.Visible = False
                        Case "U_P5" : column.HeaderText = "U_P5" : column.DisplayIndex = 9 : column.Visible = False
                        Case "U_P4" : column.HeaderText = "U_P4" : column.DisplayIndex = 10 : column.Visible = False
                        Case "U_P6" : column.HeaderText = "U_P6" : column.DisplayIndex = 11 : column.Visible = False
                        Case "U_P7" : column.HeaderText = "U_P7" : column.DisplayIndex = 12 : column.Visible = False
                        Case "U_P8" : column.HeaderText = "U_P8" : column.DisplayIndex = 13 : column.Visible = False
                        Case "U_P1" : column.HeaderText = "U_P1" : column.DisplayIndex = 14 : column.Visible = False
                        Case "U_Cdate" : column.HeaderText = "U_Cdate" : column.DisplayIndex = 15 : column.Visible = False
                        Case "U_Omoney" : column.HeaderText = "U_Omoney" : column.DisplayIndex = 16 : column.Visible = False
                        Case "U_P3" : column.HeaderText = "U_P3" : column.DisplayIndex = 17 : column.Visible = False
                        Case "BaseType" : column.HeaderText = "BaseType" : column.DisplayIndex = 18 : column.Visible = False
                        Case "BaseRef" : column.HeaderText = "BaseRef" : column.DisplayIndex = 19 : column.Visible = False
                        Case "BaseEntry" : column.HeaderText = "BaseEntry" : column.DisplayIndex = 20 : column.Visible = False
                        Case "BaseLine" : column.HeaderText = "BaseLine" : column.DisplayIndex = 21 : column.Visible = False
                        Case "Price" : column.HeaderText = "Price" : column.DisplayIndex = 22 : column.Visible = False
                        Case "LineTotal" : column.HeaderText = "LineTotal" : column.DisplayIndex = 23 : column.Visible = False

                        Case Else
                            column.Visible = False
                    End Select
                Next
            Case 2
                For Each column As DataGridViewColumn In DGV5.Columns
                    column.Visible = True
                    Select Case column.HeaderText

                        Case "存領編號" : column.HeaderText = "存領編號" : column.DisplayIndex = 0 : column.Visible = False
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1 : column.Visible = True
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2 : column.Visible = True
                        Case "類型" : column.HeaderText = "類型" : column.DisplayIndex = 3 : column.Visible = True
                        Case "預出數量" : column.HeaderText = "預出數量" : column.DisplayIndex = 4 : column.Visible = True
                        Case "出庫數量" : column.HeaderText = "出庫數量" : column.DisplayIndex = 5 : column.Visible = True
                        Case "差異數" : column.HeaderText = "差異數" : column.DisplayIndex = 6 : column.Visible = True
                        Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 7 : column.Visible = True
                        Case "取貨日期" : column.HeaderText = "取貨日期" : column.DisplayIndex = 8 : column.Visible = True
                        Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 9 : column.Visible = True
                        Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 10 : column.Visible = True
                        Case Else
                            column.Visible = False
                    End Select
                Next
                'Case 3
                '    For Each column As DataGridViewColumn In DGV5.Columns
                '        column.Visible = True
                '        Select Case column.HeaderText

                '            Case "草稿單號" : column.HeaderText = "草稿單號" : column.DisplayIndex = 0 : column.Visible = False
                '            Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 1 : column.Visible = True
                '            Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2 : column.Visible = True
                '            Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3 : column.Visible = True
                '            Case "條碼" : column.HeaderText = "條碼" : column.DisplayIndex = 4 : column.Visible = True
                '            Case "溫層" : column.HeaderText = "溫層" : column.DisplayIndex = 5 : column.Visible = True
                '            Case "預出數量" : column.HeaderText = "預出數量" : column.DisplayIndex = 6 : column.Visible = True
                '            Case "出庫數量" : column.HeaderText = "出庫數量" : column.DisplayIndex = 7 : column.Visible = True
                '            Case "差異數" : column.HeaderText = "差異數" : column.DisplayIndex = 8 : column.Visible = True
                '            Case "取貨日期" : column.HeaderText = "取貨日期" : column.DisplayIndex = 9 : column.Visible = True
                '            Case Else
                '                column.Visible = False
                '        End Select
                '    Next
        End Select


        DGV5.AutoResizeColumns()

    End Sub



    Private Sub 查詢比對非草稿上之品項()
        If DGV6.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV6").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = " DECLARE @DocEntry varchar(15) "
            'SQLCmd.CommandText += "SET NOCOUNT ON	"
            'SQLCmd.CommandText += "SET @DocEntry = '" & 草稿.Text & "' "

            SQLCmd.CommandText = " DECLARE @DocEntry varchar(15) "
            SQLCmd.CommandText += "DECLARE @F3       varchar(2) "
            SQLCmd.CommandText += "SET NOCOUNT ON	"
            SQLCmd.CommandText += "SET @DocEntry = '" & 草稿.Text & "' "
            SQLCmd.CommandText += "SET @F3       = '" & 區別F3 & "' "

            If 作業別類.SelectedIndex = "0" Or 作業別類.SelectedIndex = "1" Then
                'Case "0"    銷售出庫  Case "1"    寄庫品出庫
                SQLCmd.CommandText += "   SELECT T0.[F1] AS '區別', T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', COUNT(T0.[F2]) AS '件數' "
                SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "                            LEFT JOIN [DRF1] S1 ON T1.[ItemCode] = S1.[ItemCode] AND S1.[DocEntry] = @DocEntry "
                SQLCmd.CommandText += "                            LEFT JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode]     "
                SQLCmd.CommandText += "     WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND T0.[F3] = @F3 AND T1.[DistNumber] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' AND ISNULL(S1.[ItemCode],'') = '' "
                SQLCmd.CommandText += "  GROUP BY T0.[F1], T1.[ItemCode], T3.[ItemName] "
            ElseIf 作業別類.SelectedIndex = "2" Then
                'Case "2"    存領出庫
                SQLCmd.CommandText += "   SELECT T0.[F1] AS '區別', T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', COUNT(T0.[F2]) AS '件數' "
                SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "                            LEFT JOIN [KS_Z_StockApply_Detail] S1 ON T1.[ItemCode] = S1.[ProCode] AND S1.[ID] = @DocEntry "
                SQLCmd.CommandText += "                            LEFT JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode]     "
                SQLCmd.CommandText += "     WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND T0.[F3] = @F3 AND T1.[DistNumber] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' AND ISNULL(S1.[ProCode],'') = '' "
                SQLCmd.CommandText += "  GROUP BY T0.[F1], T1.[ItemCode], T3.[ItemName] "
            ElseIf 作業別類.SelectedIndex = "3" Then
                'Case "3"    員購(福利社)出庫
                SQLCmd.CommandText += "   SELECT T0.[F1] AS '區別', T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', COUNT(T0.[F2]) AS '件數' "
                SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
                SQLCmd.CommandText += "                            LEFT JOIN [DRF1] S1 ON T1.[ItemCode] = S1.[ItemCode] AND S1.[DocEntry] = @DocEntry "
                SQLCmd.CommandText += "                            LEFT JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode]     "
                SQLCmd.CommandText += "     WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND T0.[F3] = @F3 AND T1.[DistNumber] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' AND ISNULL(S1.[ItemCode],'') = '' "
                SQLCmd.CommandText += "  GROUP BY T0.[F1], T1.[ItemCode], T3.[ItemName] "
            End If

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV6")
            DGV6.DataSource = ks1DataSetDGV.Tables("DGV6")

            DGV6.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 查詢條碼區別明細_草稿()
        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @DocEntry varchar(15) "
            SQLCmd.CommandText += "DECLARE @F3       varchar(2) "
            SQLCmd.CommandText += "SET NOCOUNT ON	"
            SQLCmd.CommandText += "SET @DocEntry = '" & 草稿.Text & "' "
            SQLCmd.CommandText += "SET @F3       = '" & 區別F3 & "' "

            'If ComboBox1.SelectedIndex = "0" Or ComboBox1.SelectedIndex = "1" Or ComboBox1.SelectedIndex = "2" Or ComboBox1.SelectedIndex = "3" Then
            'Case "0"    銷售出庫  Case "1"    寄庫品出庫
            'SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼',                                                            T1.[U_M1] AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN ISNULL(T1.[Quantity],'9999') = '9999' THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態', ISNULL(T4.[M_NO],'') AS 'G1' "

            SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', CAST(ISNULL(T1.[Quantity],9999) AS NUMERIC(5,0)) AS '數量', ISNULL(T1.[U_M1],'異常') AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態', ISNULL(T4.[M_NO],'') AS 'G1' "
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT  JOIN "
            SQLCmd.CommandText += "         ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], SUM(ISNULL(T2.[Quantity],9999)) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            SQLCmd.CommandText += "             FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            SQLCmd.CommandText += "                            INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
            SQLCmd.CommandText += "            WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F3] = @F3 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
            SQLCmd.CommandText += "         GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            SQLCmd.CommandText += "         ) T1 ON T0.[F2] = T1.[DistNumber] "
            SQLCmd.CommandText += "                            LEFT  JOIN [z_format_G] T4 ON T1.[U_M8] = T4.[M_NO] "
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F2] = T0.[F2] ) AND T0.[F3] = @F3 AND T0.[Del] = 'N' "
            SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T1.[U_M1], T1.[U_M2], T1.[U_M8], T4.[M_NO] "
            SQLCmd.CommandText += " ORDER BY COUNT(T0.[F2]) DESC ,T0.[F2] "

            'ElseIf ComboBox1.SelectedIndex = "3" Then
            '    SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', T1.[U_M1] AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN ISNULL(T1.[Quantity],'9999') = '9999' THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態', ISNULL(T4.[M_NO],'') AS 'G1' "
            '    SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT  JOIN "
            '    SQLCmd.CommandText += "         ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], SUM(ISNULL(T2.[Quantity],9999)) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            '    SQLCmd.CommandText += "             FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            '    SQLCmd.CommandText += "                            INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
            '    SQLCmd.CommandText += "            WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F3] = @F3 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
            '    SQLCmd.CommandText += "         GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            '    SQLCmd.CommandText += "         )               T1 ON T0.[F2] = T1.[DistNumber] "
            '    SQLCmd.CommandText += "                            LEFT  JOIN [z_format_G] T4 ON T1.[U_M8] = T4.[M_NO] "
            '    SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND TX.[F2] = T0.[F2] ) AND T0.[F3] = @F3 AND T0.[Del] = 'N' "
            '    SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T1.[U_M1], T1.[U_M2], T1.[U_M8], T4.[M_NO] "
            '    SQLCmd.CommandText += " ORDER BY COUNT(T0.[F2]) DESC ,T0.[F2] "
            'End If
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

            DGV3.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    '-- 結束 -- 條碼比對



    '-- 開始 -- 發貨作業

    Private Sub 發貨作業_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 發貨作業.Click

        If 草稿.Text <> 稿號.Text Then
            MsgBox("作業草稿錯誤，請確認後重新作業")
            Exit Sub
        End If

        If 作業別類.SelectedIndex = "0" Or 作業別類.SelectedIndex = "1" Or 作業別類.SelectedIndex = "3" Then
            'Case "0"    銷售出庫  Case "1"    寄庫品出庫
            存條碼至待發貨區()
            SyncToSAPDeliveryNotes()
        ElseIf 作業別類.SelectedIndex = "2" Then '存領出庫
            存條碼至待發貨區_存領()
            SyncToSAP2()
            'ElseIf ComboBox1.SelectedIndex = "3" Then '員購(福利社)出庫
            '    存條碼至待發貨區_員購()
            '    SyncToSAP_員購()
        End If

        ''Select Case ComboBox1.SelectedIndex
        ''    Case "0"
        '存條碼至待發貨區()
        'SyncToSAPDeliveryNotes()

        '' ''Case "1" 
        '' ''Case "2" 
        '' ''Case "3" 
        '' ''Case "4" 
        '' ''Case "5"  
        ''End Select

        'SyncToSAPDeliveryNotes()
        'SyncToSAPInventoryGenExit()

        '存條碼至待發貨區()

        發貨作業.Visible = False

        查詢文件草稿單號()
        查詢條碼區別()
        Label4.Text = Format(DGV1.RowCount, "")
        Label5.Text = Format(DGV2.RowCount, "")

        稿號.Text = ""


    End Sub

    Private Sub 存條碼至待發貨區()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim OB12Date As Date = Today

        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = " DECLARE @DocEntry   varchar(10) "
        SQLCmd.CommandText += "DECLARE @TypeSelect varchar(2) "
        SQLCmd.CommandText += "SET NOCOUNT ON "
        SQLCmd.CommandText += "SET @DocEntry   = '" & 稿號.Text & "' "
        SQLCmd.CommandText += "SET @TypeSelect = '" & TypeSelect & "' "
        SQLCmd.CommandText += "DELETE FROM [@ksOBList] WHERE [OB08] = @DocEntry AND [OB07] = @TypeSelect "

        If 作業別類.SelectedIndex = "0" Or 作業別類.SelectedIndex = "1" Then      'Case "0"    銷售出庫  Case "1"    寄庫品出庫
            SQLCmd.CommandText += " INSERT INTO [@ksOBList] ([OB01],[OB02],[OB03],[OB04],[OB05],[OB07],[OB08],[OB09],[OB10],[OB12]) "
            SQLCmd.CommandText += " SELECT S1.[OB01], S1.[OB02], S1.[OB03], S1.[OB04], '1' AS 'OB05', @TypeSelect AS 'OB07', @DocEntry AS 'OB08', S0.[LineNum]  AS 'OB09', '3' AS 'OB10', '" & OB12Date & "' AS 'OB12' "
            SQLCmd.CommandText += "   FROM [DRF1] S0 INNER JOIN ( "
            SQLCmd.CommandText += "         SELECT T1.[ItemCode] AS 'OB01', T3.[ItemName] AS 'OB02', T0.[F2] AS 'OB03', T1.[U_M2] AS 'OB04' "
            SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            SQLCmd.CommandText += "                                  LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode]  "
            SQLCmd.CommandText += "          WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'A' AND TX.[F4] = @DocEntry AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F3] = 'A' AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
            SQLCmd.CommandText += "                            ) S1 ON S1.OB01 = S0.[ItemCode]"
            SQLCmd.CommandText += "  WHERE S0.[DocEntry] = @DocEntry "
        ElseIf 作業別類.SelectedIndex = "3" Then
            SQLCmd.CommandText += " INSERT INTO [@ksOBList] ([OB01],[OB02],[OB03],[OB04],[OB05],[OB07],[OB08],[OB09],[OB10],[OB12]) "
            SQLCmd.CommandText += " SELECT S1.[OB01], S1.[OB02], S1.[OB03], S1.[OB04], '1' AS 'OB05', @TypeSelect AS 'OB07', @DocEntry AS 'OB08', S0.[LineNum]  AS 'OB09', '3' AS 'OB10', '" & OB12Date & "' AS 'OB12' "
            SQLCmd.CommandText += "   FROM [DRF1] S0 INNER JOIN ( "
            SQLCmd.CommandText += "         SELECT T1.[ItemCode] AS 'OB01', T3.[ItemName] AS 'OB02', T0.[F2] AS 'OB03', T1.[U_M2] AS 'OB04' "
            SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            SQLCmd.CommandText += "                                  LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode]  "
            SQLCmd.CommandText += "          WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'Z' AND TX.[F4] = @DocEntry AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F3] = 'Z' AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
            SQLCmd.CommandText += "                            ) S1 ON S1.OB01 = S0.[ItemCode]"
            SQLCmd.CommandText += "  WHERE S0.[DocEntry] = @DocEntry "
        End If

        'Select Case ComboBox1.SelectedIndex
        '    Case "0"    '銷售出庫
        '        SQLCmd.CommandText += " INSERT INTO [@ksOBList] ([OB01],[OB02],[OB03],[OB04],[OB05],[OB07],[OB08],[OB09],[OB10],[OB12]) "
        '        SQLCmd.CommandText += " SELECT S1.[OB01], S1.[OB02], S1.[OB03], S1.[OB04], '1' AS 'OB05', @TypeSelect AS 'OB07', @DocEntry AS 'OB08', S0.[LineNum]  AS 'OB09', '3' AS 'OB10', '" & OB12Date & "' AS 'OB12' "
        '        SQLCmd.CommandText += "   FROM [DRF1] S0 INNER JOIN ( "
        '        SQLCmd.CommandText += "         SELECT T1.[ItemCode] AS 'OB01', T3.[ItemName] AS 'OB02', T0.[F2] AS 'OB03', T1.[U_M2] AS 'OB04' "
        '        SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
        '        SQLCmd.CommandText += "                                  LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode]  "
        '        SQLCmd.CommandText += "          WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F4] = @DocEntry AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
        '        SQLCmd.CommandText += "                            ) S1 ON S1.OB01 = S0.[ItemCode]"
        '        SQLCmd.CommandText += "  WHERE S0.[DocEntry] = @DocEntry "
        '        'SQLCmd.CommandText += " UPDATE [Z_KS_Barcode] SET [Del] = 'S' WHERE [F4] = @DocEntry AND [Del] = 'N' "
        'End Select

        SQLCmd.ExecuteNonQuery()

    End Sub

    Private Sub 存條碼至待發貨區_存領()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim OB12Date As Date = Today

        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = " DECLARE @DocEntry   varchar(15) "
        SQLCmd.CommandText += "DECLARE @TypeSelect varchar(2) "
        SQLCmd.CommandText += "SET NOCOUNT ON "
        SQLCmd.CommandText += "SET @DocEntry   = '" & 稿號.Text & "' "
        SQLCmd.CommandText += "SET @TypeSelect = '" & TypeSelect & "' "
        SQLCmd.CommandText += "DELETE FROM [@ksOBList] WHERE [OB08] = @DocEntry AND [OB07] = @TypeSelect "

        If 作業別類.SelectedIndex = "2" Then  '存領出庫
            SQLCmd.CommandText += " INSERT INTO [@ksOBList] ([OB01],[OB02],[OB03],[OB04],[OB05],[OB07],[OB08],[OB09],[OB10],[OB12]) "
            SQLCmd.CommandText += " SELECT S1.[OB01], S1.[OB02], S1.[OB03], S1.[OB04], '1' AS 'OB05', @TypeSelect AS 'OB07', @DocEntry AS 'OB08', S0.[LineNum]  AS 'OB09', '3' AS 'OB10', '" & OB12Date & "' AS 'OB12' "
            SQLCmd.CommandText += "   FROM (Select (Row_Number() OVER (partition by ID order by ID Asc, ProCode ASC) - 1) as LineNum,* from KS_Z_StockApply_Detail) S0 INNER JOIN ( "
            SQLCmd.CommandText += "         SELECT T1.[ItemCode] AS 'OB01', T3.[ItemName] AS 'OB02', T0.[F2] AS 'OB03', T1.[U_M2] AS 'OB04' "
            SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            SQLCmd.CommandText += "                                  LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode]  "
            SQLCmd.CommandText += "          WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'A' AND TX.[F4] = @DocEntry AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F3] = 'A' AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
            SQLCmd.CommandText += "                            ) S1 ON S1.OB01 = S0.[ProCode]"
            SQLCmd.CommandText += "  WHERE S0.[ID] = @DocEntry "
        End If

        SQLCmd.ExecuteNonQuery()

    End Sub

    Private Sub 存條碼至待發貨區_員購()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim OB12Date As Date = Today

        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = " DECLARE @DocEntry   varchar(15) "
        SQLCmd.CommandText += "DECLARE @TypeSelect varchar(2) "
        SQLCmd.CommandText += "SET NOCOUNT ON "
        SQLCmd.CommandText += "SET @DocEntry   = '" & 稿號.Text & "' "
        SQLCmd.CommandText += "SET @TypeSelect = '" & TypeSelect & "' "
        SQLCmd.CommandText += "DELETE FROM [@ksOBList] WHERE [OB08] = @DocEntry AND [OB07] = @TypeSelect "

        If 作業別類.SelectedIndex = "3" Then  '員購(福利社)出庫
            SQLCmd.CommandText += " INSERT INTO [@ksOBList] ([OB01],[OB02],[OB03],[OB04],[OB05],[OB07],[OB08],[OB09],[OB10],[OB12]) "
            SQLCmd.CommandText += " SELECT S1.[OB01], S1.[OB02], S1.[OB03], S1.[OB04], '1' AS 'OB05', @TypeSelect AS 'OB07', @DocEntry AS 'OB08', S0.[LineNum]  AS 'OB09', '3' AS 'OB10', '" & OB12Date & "' AS 'OB12' "
            SQLCmd.CommandText += "   FROM ( Select (Row_Number() OVER (partition by [OQUTDocNum] order by [OQUTDocNum] Asc, [ProCode] ASC, [KeepName] ASC ) - 1) as LineNum,* from [KS_Z_Welfare]) S0 INNER JOIN (  "
            SQLCmd.CommandText += "         SELECT T1.[ItemCode] AS 'OB01', T3.[ItemName] AS 'OB02', T0.[F2] AS 'OB03', T1.[U_M2] AS 'OB04' "
            SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2] = T1.[DistNumber] "
            SQLCmd.CommandText += "                                  LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode]  "
            SQLCmd.CommandText += "          WHERE EXISTS( SELECT * FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'Z' AND TX.[F4] = @DocEntry AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F3] = 'Z' AND T0.[F4] = @DocEntry AND T0.[Del] = 'N' "
            SQLCmd.CommandText += "                            ) S1 ON S1.OB01 = S0.[ProCode]"
            SQLCmd.CommandText += " WHERE S0.[OQUTDocNum] = @DocEntry "
        End If

        SQLCmd.ExecuteNonQuery()

    End Sub

    Private Function ChkBorS(ByVal 存編 As String)
        'Dim oBorS As String
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        sql = " SELECT [ManSerNum], [ManBtchNum] FROM [OITM] WHERE [ItemCode] = '" & 存編 & "'"
        SQLCmd = New SqlCommand(sql, DBConn)
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            If sqlReader.Item("ManSerNum") = "Y" Then   '序號管理
                oBorS = "S"
            ElseIf sqlReader.Item("ManBtchNum") = "Y" Then  '批次管理
                oBorS = "B"
            Else
                sqlReader.Close()
                oBorS = "F"
            End If
            sqlReader.Close()
        Else
            sqlReader.Close()
            oBorS = "F"
        End If

        'MsgBox(oBorS)

        Return oBorS
    End Function

    Private Sub SyncToSAPDeliveryNotes()

        'Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
        Dim DBConn As SqlConnection = Login.DBConn
        Dim sql As String
        Dim sql2 As String
        Dim sqlCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim odraft As SAPbobsCOM.Documents
        Dim oDelv As SAPbobsCOM.Documents
        Dim DocNum As Integer = 0

        oDelv = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDeliveryNotes)

        '文件開始
        oDelv.CardCode = DGV1.CurrentRow.Cells("CardCode").Value
        oDelv.DocDueDate = DGV1.CurrentRow.Cells("DocDueDate").Value
        oDelv.DocDate = DGV1.CurrentRow.Cells("DocDueDate").Value

        If IsDBNull(DGV1.CurrentRow.Cells("U_Dnum").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_Dnum").Value = DGV1.CurrentRow.Cells("U_Dnum").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("Comments").Value) Then
        Else
            oDelv.Comments = DGV1.CurrentRow.Cells("Comments").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_attachment").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_attachment").Value = DGV1.CurrentRow.Cells("U_attachment").Value
        End If
        oDelv.UserFields.Fields.Item("U_CK01").Value = DGV1.CurrentRow.Cells("U_CK01").Value
        If IsDBNull(DGV1.CurrentRow.Cells("U_Cnum").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_Cnum").Value = DGV1.CurrentRow.Cells("U_Cnum").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_N1").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_N1").Value = DGV1.CurrentRow.Cells("U_N1").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_N2").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_N2").Value = DGV1.CurrentRow.Cells("U_N2").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_N3").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_N3").Value = DGV1.CurrentRow.Cells("U_N3").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_CarDr1").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_CarDr1").Value = DGV1.CurrentRow.Cells("U_CarDr1").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_CarDr2").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_CarDr2").Value = DGV1.CurrentRow.Cells("U_CarDr2").Value
        End If
        If IsDBNull(DGV1.CurrentRow.Cells("U_CarDr3").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_CarDr3").Value = DGV1.CurrentRow.Cells("U_CarDr3").Value
        End If
        oDelv.UserFields.Fields.Item("U_Dlst").Value = DGV1.CurrentRow.Cells("U_Dlst").Value
        oDelv.UserFields.Fields.Item("U_updnum").Value = DGV1.CurrentRow.Cells("U_updnum").Value
        If IsDBNull(DGV1.CurrentRow.Cells("U_TpMoney").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_TpMoney").Value = DGV1.CurrentRow.Cells("U_TpMoney").Value
        End If

        '內容
        For i As Integer = 0 To DGV5.RowCount - 1

            Dim p2Value As Single = 0
            oDelv.Lines.SetCurrentLine(i)
            oDelv.Lines.ItemCode = DGV5.Rows(i).Cells("存編").Value
            oDelv.Lines.Quantity = DGV5.Rows(i).Cells("預出數量").Value
            oDelv.Lines.BaseType = DGV5.Rows(i).Cells("BaseType").Value
            If IsDBNull(DGV5.Rows(i).Cells("BaseEntry").Value) Then
            Else
                oDelv.Lines.BaseEntry = DGV5.Rows(i).Cells("BaseEntry").Value
            End If
            If IsDBNull(DGV5.Rows(i).Cells("BaseLine").Value) Then
            Else
                oDelv.Lines.BaseLine = DGV5.Rows(i).Cells("BaseLine").Value
            End If

            If IsDBNull(DGV5.Rows(i).Cells("U_P1").Value) Then
            Else
                oDelv.Lines.UserFields.Fields.Item("U_P1").Value = DGV5.Rows(i).Cells("U_P1").Value
            End If

            ''庫位
            ''If ckbWhs.Checked = True Then
            ''    oDelv.Lines.WarehouseCode = tbxWhsCode.Text
            ''End If

            oDelv.Lines.UserFields.Fields.Item("U_P3").Value = DGV5.Rows(i).Cells("U_P3").Value
            oDelv.Lines.UserFields.Fields.Item("U_P4").Value = DGV5.Rows(i).Cells("U_P4").FormattedValue
            oDelv.Lines.UserFields.Fields.Item("U_P5").Value = DGV5.Rows(i).Cells("U_P5").Value
            oDelv.Lines.UserFields.Fields.Item("U_P6").Value = DGV5.Rows(i).Cells("U_P6").Value
            oDelv.Lines.UserFields.Fields.Item("U_P7").Value = DGV5.Rows(i).Cells("U_P7").Value
            oDelv.Lines.UserFields.Fields.Item("U_P8").Value = DGV5.Rows(i).Cells("U_P8").FormattedValue
            If IsDBNull(DGV5.Rows(i).Cells("U_Cdate").Value) Then
            Else
                oDelv.Lines.UserFields.Fields.Item("U_Cdate").Value = DGV5.Rows(i).Cells("U_Cdate").Value
            End If
            oDelv.Lines.UserFields.Fields.Item("U_Omoney").Value = DGV5.Rows(i).Cells("U_Omoney").Value

            oBorS = ChkBorS(DGV5.Rows(i).Cells("存編").Value)

            '紀錄條碼是屬於第幾行
            Dim ks2DataSet As DataSet = New DataSet
            sql2 = "SELECT DISTINCT * FROM [@ksOBList] WHERE [OB07] = '" & TypeSelect & "' AND [OB08] = '" & DGV5.Rows(i).Cells("草稿單號").Value & "' AND [OB09] = '" & DGV5.Rows(i).Cells("列號").Value & "' AND [OB10] = '3'"
            DataDGV5 = New SqlDataAdapter(sql2, DBConn)
            DataDGV5.Fill(ks2DataSet, "DT4")
            DGV7.DataSource = ks2DataSet.Tables("DT4")

            If oBorS = "B" Then
                '批號
                For j As Integer = 0 To DGV7.RowCount - 1
                    oDelv.Lines.BatchNumbers.SetCurrentLine(j)
                    oDelv.Lines.BatchNumbers.BatchNumber = DGV7.Rows(j).Cells("OB03").Value '條碼
                    oDelv.Lines.BatchNumbers.Quantity = DGV7.Rows(j).Cells("OB05").FormattedValue  '數量
                    oDelv.Lines.BatchNumbers.Add()
                    '' '' ''清除條碼
                    ' '' ''DelOBList(DGV7.Rows(j).Cells("OBID").Value)
                Next
            ElseIf oBorS = "S" Then
                '序號
                For j As Integer = 0 To DGV7.RowCount - 1
                    oDelv.Lines.SerialNumbers.SetCurrentLine(j)
                    oDelv.Lines.SerialNumbers.InternalSerialNumber = DGV7.Rows(j).Cells("OB03").Value '條碼
                    oDelv.Lines.SerialNumbers.Add()
                    '選條碼~把數量總和
                    sql = "SELECT [U_M1] FROM [OSRN] WHERE [DistNumber] = '" & DGV7.Rows(j).Cells("OB03").Value & "' "
                    sqlCmd = New SqlCommand(sql, DBConn)
                    sqlReader = sqlCmd.ExecuteReader
                    sqlReader.Read()
                    p2Value = p2Value + sqlReader.Item("U_M1")
                    sqlReader.Close()
                    '' '' ''清除條碼
                    ' '' ''DelOBList(DGV7.Rows(j).Cells("OBID").Value)
                Next
            End If


            '根據計價單位運算金額
            Select Case TypeSelect
                Case "2"
                    Select Case DGV5.Rows(i).Cells("U_P7").Value
                        Case "0"
                            oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                            oDelv.Lines.UnitPrice = DGV5.Rows(i).Cells("U_P8").Value
                        Case "1"
                            oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                            oDelv.Lines.UnitPrice = (DGV5.Rows(i).Cells("U_P8").Value * p2Value) / DGV5.Rows(i).Cells("預出數量").Value
                        Case "2"
                            oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                            oDelv.Lines.UnitPrice = (DGV5.Rows(i).Cells("U_P8").Value * DGV5.Rows(i).Cells("U_P4").Value) / DGV5.Rows(i).Cells("預出數量").Value
                    End Select
                Case "4"
                    oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                    If IsDBNull(DGV5.Rows(i).Cells("U_P8").Value) Then
                    Else
                        oDelv.Lines.UnitPrice = DGV5.Rows(i).Cells("U_P8").Value
                    End If
            End Select


            'Add行
            oDelv.Lines.Add()
        Next

        'Add文件
        RetVal = oDelv.Add
        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("B1交貨單錯誤!" & vbCrLf & "錯誤代碼： " & ErrCode & vbCrLf & "錯誤訊息： " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        'Dim DocNum As Integer = 0
        DocNum = Login.oCompany.GetNewObjectKey()
        '文件完成才移除草稿
        odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        odraft.GetByKey(DGV1.CurrentRow.Cells("DocEntry").Value)
        odraft.Remove()

        'MsgBox("新增至B1交貨單完成!!" + vbCrLf + "交貨單單號：" & DocNum, 64, "完成")

        If RetVal = 0 Then
            Dim oAns1 As Integer
            oAns1 = MsgBox("新增至B1交貨單完成!!" + vbCrLf + "交貨單單號：" & DocNum, 64, "完成")    'MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns1 = MsgBoxResult.Ok Then
                'ok執行區

                If DGV3.RowCount > 0 Then
                    ks1DataSetDGV.Tables("DGV3").Clear()
                End If

                If DGV5.RowCount > 0 Then
                    ks1DataSetDGV.Tables("DGV5").Clear()
                End If

                If DocNum <> 0 Then
                    刪除完單條碼()
                End If

            End If
        End If

    End Sub

    Private Sub SyncToSAP2()

        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim X As Integer = 0
        Dim oGoodIss As SAPbobsCOM.Documents

        oGoodIss = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)

        '存貨領用取件日期
        Dim GetProDate As String = Convert.ToString(DGV1.CurrentRow.Cells("GetProDate").Value).Substring(0, 4) + "-" + Convert.ToString(DGV1.CurrentRow.Cells("GetProDate").Value).Substring(4, 2) + "-" + Convert.ToString(DGV1.CurrentRow.Cells("GetProDate").Value).Substring(6, 2) + " 00:00:00.000"

        '文件開始 表頭
        oGoodIss.TaxDate = GetProDate '文件日期
        oGoodIss.DocDate = GetProDate '過帳日期
        oGoodIss.UserFields.Fields.Item("U_CK01").Value = Convert.ToString(DGV1.CurrentRow.Cells("IndexID").Value) '領用用途

        '表身
        Dim ks2DataSet As DataSet = New DataSet
        Dim DBConn As SqlConnection = Login.DBConn
        Dim sql As String
        Dim sql2 As String
        Dim sqlCmd As SqlCommand
        Dim sqlReader As SqlDataReader

        For j As Integer = 0 To DGV5.RowCount - 1

            Dim p2Value As Single = 0
            oGoodIss.Lines.SetCurrentLine(j)
            oGoodIss.Lines.ItemCode = DGV5.Rows(j).Cells("存編").Value
            oGoodIss.Lines.Quantity = DGV5.Rows(j).Cells("預出數量").Value
            sql2 = "SELECT DISTINCT * FROM [@ksOBList] WHERE [OB07] = '" & TypeSelect & "' AND [OB08] = '" & DGV5.Rows(j).Cells("存領編號").Value & "' AND [OB09] = '" & DGV5.Rows(j).Cells("列號").Value & "' AND [OB10] = '3'"
            DataDGV5 = New SqlDataAdapter(sql2, DBConn)
            DataDGV5.Fill(ks2DataSet, "DT4")
            DGV7.DataSource = ks2DataSet.Tables("DT4")

            For i As Integer = 0 To DGV7.RowCount - 1

                oGoodIss.Lines.SerialNumbers.SetCurrentLine(j)
                oGoodIss.Lines.BatchNumbers.Quantity = DGV7.Rows(j).Cells("OB05").FormattedValue  '數量
                oGoodIss.Lines.SerialNumbers.InternalSerialNumber = DGV7.Rows(j).Cells("OB03").Value '條碼
                oGoodIss.Lines.SerialNumbers.Add()


                sql = "SELECT [U_M1] FROM [OSRN] WHERE [DistNumber] = '" & DGV7.Rows(j).Cells("OB03").Value & "' "
                sqlCmd = New SqlCommand(sql, DBConn)
                sqlReader = sqlCmd.ExecuteReader
                sqlReader.Read()
                p2Value = p2Value + sqlReader.Item("U_M1")
                sqlReader.Close()

            Next

            oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = p2Value '重量
            oGoodIss.Lines.Add()
        Next


        RetVal = oGoodIss.Add

        'Check the result
        If RetVal <> 0 Then '失敗

            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("B1發貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub

        ElseIf RetVal = 0 Then '成功
            Dim oAns1 As Integer

            Dim DocNum As Integer
            DocNum = Login.oCompany.GetNewObjectKey()

            Dim DBConn2 As SqlConnection = Login.DBConn
            Dim SQLCmd2 As SqlCommand = New SqlCommand

            SQLCmd2.Connection = DBConn2
            SQLCmd2.CommandText = " UPDATE [KS_Z_StockApply] SET [DocNum] = '" & DocNum & "', [Examine] = '2', [SendOutDate] = getdate() , SendOutUser='" + Login.LogonUserName + "' WHERE [ID] = '" & 草稿.Text & "'  AND [Examine] = '1' "
            SQLCmd2.ExecuteNonQuery()

            oAns1 = MsgBox("新增至B1發貨單完成!!" + vbCrLf + "發貨單單號：" & DocNum, 64, "完成")

            If oAns1 = MsgBoxResult.Ok Then
                'ok執行區

                If DGV3.RowCount > 0 Then
                    ks1DataSetDGV.Tables("DGV3").Clear()
                End If

                If DGV5.RowCount > 0 Then
                    ks1DataSetDGV.Tables("DGV5").Clear()
                End If

                If DocNum <> 0 Then
                    刪除完單條碼()
                End If

            End If
        End If



    End Sub

    Private Sub 刪除完單條碼()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "  DECLARE @DocEntry   varchar(15) "
        SQLCmd.CommandText += " DECLARE @TypeSelect varchar(2) "
        SQLCmd.CommandText += " SET NOCOUNT ON "
        SQLCmd.CommandText += " SET @DocEntry   = '" & 草稿.Text & "' "
        SQLCmd.CommandText += " SET @TypeSelect = '" & TypeSelect & "' "
        SQLCmd.CommandText += " DELETE FROM [@ksOBList]    WHERE [OB08] = @DocEntry AND [OB07] = @TypeSelect "
        SQLCmd.CommandText += " DELETE FROM [Z_KS_Barcode] WHERE [F4]   = @DocEntry "
        SQLCmd.ExecuteNonQuery()

    End Sub

    '-- 結束 -- 發貨作業

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'DGV1.Rows.Remove(DGV1.CurrentRow)           '移除列 Row
        'Label4.Text = Format(DGV1.RowCount, "")

        'DGV1.CurrentRow.Cells("DocEntry").Value

    End Sub


    Private Sub 刪除區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 刪除區別.Click
        If 區別.Text = "" Then
            MsgBox("未選取待刪除區別", 48, "警告")
            Exit Sub
        End If

        刪除區別.Enabled = False

        If 刪除區別.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?  區別 " + Format(區別.Text, ""), MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F1] = '" & 區別.Text & "' "
                SQLCmd.ExecuteNonQuery()

                查詢條碼區別()
                Label5.Text = Format(DGV2.RowCount, "")
                區別.Text = ""
                MsgBox("刪除完成", 48, "刪除完成")

            End If
        End If

        刪除區別.Enabled = True



    End Sub

    Private Sub 刪除條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 刪除條碼.Click

        刪除條碼.Enabled = False

        If 刪除條碼.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand

                For Each oRow As DataGridViewRow In DGV4.SelectedRows

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [Sid] = '" & oRow.Cells("Sid").Value & "'  AND [Del] = 'N' "
                    SQLCmd.ExecuteNonQuery()

                Next

                查詢異常條碼明細()
                MsgBox("刪除完成", 48, "刪除完成")

            End If
        End If

        刪除條碼.Enabled = True

    End Sub


    Private Sub 修改區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改區別.Click

        修改區別.Enabled = False

        If TextBox1.Text = "" Then
            MsgBox("無Key 區別", 48, "警告")
            修改區別.Enabled = True
            TextBox1.Focus()
            Exit Sub
        End If

        If 修改區別.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要修改?", MsgBoxStyle.YesNo, "確認修改")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand

                For Each oRow As DataGridViewRow In DGV4.SelectedRows

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = "UPDATE [Z_KS_Barcode] SET [F1] = '" & TextBox1.Text & "' WHERE [Sid] = '" & oRow.Cells("Sid").Value & "' AND [Del] = 'N' "
                    SQLCmd.ExecuteNonQuery()

                Next

                查詢異常條碼明細()
                查詢條碼區別()
                TextBox1.Text = ""
                MsgBox("修改完成", 48, "刪除完成")

            End If
        End If

        修改區別.Enabled = True

    End Sub



    Private Sub 未入庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 未入庫.Click


        '    Dim F01s As String = ""

        '    Select Case F01.SelectedIndex
        '        Case "0" : F01s = "J011"
        '        Case "1" : F01s = "J012"
        '        Case "2" : F01s = "J013"
        '        Case "3" : F01s = "J014"
        '        Case "4" : F01s = "J015"
        '    End Select


        未入庫清單.MdiParent = MainForm
        '    急速條碼.F01s.Text = F01s
        '    急速條碼.F01s中.Text = F01.Text
        '    急速條碼.DocDate.Text = DatePicker1.Value.Date
        未入庫清單.Show()

    End Sub

    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click
        If DGV3.RowCount = 0 Then
            MsgBox("無資料可匯出", 16, "失敗")
            Exit Sub
        End If

        DataToExcel(DGV3, "")
    End Sub


    Private Sub 查條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查條碼.Click

        If DGV3.RowCount = 0 Then
            MsgBox("無資料可查詢")
            Exit Sub
        End If

        Dim DistNumber As String = ""
        If Format(DGV3.CurrentRow.Cells("條碼").Value, "") = vbNullString Then
            DistNumber = ""
        Else
            DistNumber = Format(DGV3.CurrentRow.Cells("條碼").Value, "")
        End If

        If DistNumber = "" Then
            MsgBox("請選擇條碼")
            Exit Sub
        End If

        查條碼明細.MdiParent = MainForm
        查條碼明細.DistNumbers.Text = DistNumber
        查條碼明細.Show()

    End Sub
End Class