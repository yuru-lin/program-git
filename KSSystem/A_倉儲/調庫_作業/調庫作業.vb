Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class 調庫作業
    Dim DataAdapterDGV, DataDGV5 As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim Excelds As DataSet
    'Dim TypeSelect As String
    'Dim oBorS As String
    Dim ADate As String
    Dim ADate2 As Date
    Dim 查詢錯誤 As Boolean = True
    Dim 新增客戶TF As Boolean = True
    Dim 區別ss As String
    Dim 區別sx As String
    Dim 儲位ss As String
    Dim 儲位sx As String

    '時間
    Dim dteStart As DateTime

    '修改加快回傳方式_Phil_20140307
    Dim DrfNums1 As String = ""

    Private Sub 調庫作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LogonUserName = "manager" Then
            Panel1.Visible = True
        End If

        初始化作業()

    End Sub

    Private Sub 初始化作業()

        條碼數量.Text = 0               '出庫 _條碼數量
        目前區別.Text = ""              '目前區別

        '異常條碼數量
        重覆.Text = 0                   '重覆
        未入庫.Text = 0                 '未入庫
        出庫.Text = 0                   '出庫

    End Sub

    '-- 開始 --讀取 Excel 存入資料庫作業--[Z_KS_Barcode]
    Private Sub 存入條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存入條碼.Click

        讀取Excel()
        查詢條碼區別()

    End Sub

    Private Sub 讀取Excel()
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "純文字 Files(*.txt)|*.txt"    '只抓excel檔   
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
        excelConnection.Close()
        excelConnection.Dispose()

        '上傳條碼至MSSQL()

    End Sub

    Private Sub 上傳條碼至MSSQL()

        Dim F1 As String
        Dim F2 As String
        Dim F3 As String

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "INSERT INTO [Z_KS_Barcode] ([Del],[F1],[F2],[F3],[F4]) VALUES ('N',@str_1,@str_2,@str_3,'') "

        For i As Integer = 0 To ExcelDGV.RowCount - 1
            If ExcelDGV.Rows(i).Cells("F1").FormattedValue <> "" Then
                F1 = Format(Replace(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 4), " ", ""), "")
                F2 = Format(Trim(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 6, 16)), "")
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

    '-- 結束 --讀取 Excel 存入資料庫作業--[Z_KS_Barcode]
    '------><------
    Private Sub 查詢條碼區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        查詢異常區別.Visible = False
        刪除條碼.Visible = False

        查詢條碼區別()
        '初始化
        目前區別.Text = ""               '目前區別
        更新資料.Enabled = False

    End Sub

    '-- 開始 -- 查詢條碼區別
    Private Sub 查詢條碼區別()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT [F1] AS '區別', [F4] AS '調至庫位', COUNT([F2]) AS '條碼數'"
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] "
            SQLCmd.CommandText += "    WHERE [F3] = 'G' AND [Del] = 'N'"
            SQLCmd.CommandText += " GROUP BY [F1], [F4] "

            SQLCmd.CommandTimeout = 100000

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

        目前區別.Text = DGV2.CurrentRow.Cells("區別").Value

        更新資料.Enabled = True

    End Sub

    Private Sub 查區別明細_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查區別明細.Click

        If 目前區別.Text = "" Then
            MsgBox("未選取查詢區別", 48, "警告")
            Exit Sub
        End If

        查詢條碼區別明細()
        DGV3_ListStatus()

    End Sub

    Private Sub 查詢條碼區別明細()
        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @F1 varchar(5) "
            SQLCmd.CommandText += "SET NOCOUNT ON	"
            SQLCmd.CommandText += "SET @F1 = '" & 目前區別.Text & "' "

            SQLCmd.CommandText += "   SELECT '電宰' AS '類別', T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', T0.[F1] AS '區別', T0.[F4] AS '調至儲位', T1.[U_M2] AS '原始儲位', "
            SQLCmd.CommandText += "           (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN CAST(SUM(ISNULL(T1.[Quantity],'9999')) AS INT) = '9999' THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態' "
            SQLCmd.CommandText += "          ,ISNULL(CONVERT(VARCHAR(19),T0.[InDaetTime],120),'') AS '時間' "
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN"
            SQLCmd.CommandText += "        ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], CAST(SUM(ISNULL(T2.[Quantity],'9999')) AS INT) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate]"
            SQLCmd.CommandText += "            FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] AND T1.[ItemCode] = T2.[ItemCode] "
            SQLCmd.CommandText += "                           INNER JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            SQLCmd.CommandText += "           WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'G' AND TX.[F1] = @F1 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
            SQLCmd.CommandText += "        GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            SQLCmd.CommandText += "        ) T1 ON T0.[F2] = T1.[DistNumber]"
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE T0.[F3] = 'G' AND TX.[F1] = @F1 AND TX.[F2] = T0.[F2] AND T0.[Del] = 'N' ) "
            SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T0.[F1], T0.[F4], T1.[U_M1], T1.[U_M2], T1.[U_M8] "
            SQLCmd.CommandText += " ORDER BY T0.[F1], T0.[F2], T1.[ItemCode], T0.[F4] "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

            DGV3.AutoResizeColumns()
            DGV3_ListStatus()

        Catch ex As Exception
            MsgBox("查詢明細:" & ex.Message)
            'Exit Sub
        End Try

    End Sub

    Private Sub 查詢調整區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢調整區別.Click

        'Dim dteStart As DateTime = Now
        dteStart = Now  ''...要計算執行時間的程式區段 ...
        Label1.Text = "0.00" : Label3.Text = "0.00" : Label4.Text = "0.00" : Label5.Text = "0.00"

        查詢異常區別.Visible = False
        刪除條碼.Visible = False

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可查詢", 48, "警告")
            Exit Sub
        End If

        調庫.Visible = False
        調庫2.Visible = False

        查詢錯誤 = True
        查詢調整區別SQL_前查()
        查詢調整區別SQL()
        If 查詢錯誤 = False Then
            Exit Sub
        End If

        查詢調整區別MU2UP()
        ChkLoc()

        Dim TS1 As TimeSpan = Now.Subtract(dteStart)
        Label1.Text = Format(TS1.TotalSeconds, "###0.00")

    End Sub

    Private Sub 查詢調整區別SQL_前查()
        If DGV4.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV4").Clear()
        End If

        區別ss = ""
        區別sx = ""

        For x As Integer = 0 To DGV1.RowCount - 1
            If 區別ss = "" Then
                區別ss = 區別ss + Format(DGV1.Rows(x).Cells("D4區別").Value, "")
            Else
                區別ss = 區別ss + "," + Format(DGV1.Rows(x).Cells("D4區別").Value, "")
            End If
        Next

        區別sx = Format(Replace(區別ss, ",", "','"), "")

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "   SELECT TX.[F2] AS '條碼' FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'G' AND TX.[F1] IN ('" & 區別sx & "') AND TX.[Del] = 'N' "
            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV4")
            DGV4.DataSource = ks1DataSetDGV.Tables("DGV4")

            DGV4.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("查詢明細_前查:" & ex.Message)
            'Exit Sub
        End Try

    End Sub

    Private Sub 查詢調整區別SQL()

        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        區別ss = ""
        區別sx = ""

        For x As Integer = 0 To DGV1.RowCount - 1
            If 區別ss = "" Then
                區別ss = 區別ss + Format(DGV1.Rows(x).Cells("D4區別").Value, "")
            Else
                區別ss = 區別ss + "," + Format(DGV1.Rows(x).Cells("D4區別").Value, "")
            End If
        Next

        區別sx = Format(Replace(區別ss, ",", "','"), "")
        ''區別sx = Format(區別ss, "")

        儲位ss = ""
        儲位sx = ""

        For x As Integer = 0 To DGV1.RowCount - 1
            If 儲位ss = "" Then
                儲位ss = 儲位ss + Format(DGV1.Rows(x).Cells("D4調至庫位").Value, "")
            Else
                儲位ss = 儲位ss + "," + Format(DGV1.Rows(x).Cells("D4調至庫位").Value, "")
            End If
        Next

        儲位sx = Format(Replace(儲位ss, ",", "','"), "")

        '修改加快回傳方式_Phil_20140307
        'Dim DrfNums1 As String = ""

        DrfNums1 = ""
        For i As Integer = 0 To DGV4.RowCount - 1
            If DrfNums1 = "" Then
                DrfNums1 = DrfNums1 + Format(DGV4.Rows(i).Cells("條碼").Value, "")
            Else
                DrfNums1 = DrfNums1 + "','" + Format(DGV4.Rows(i).Cells("條碼").Value, "")
            End If
        Next

        If DrfNums1 = "" Then
            MsgBox("空白資料")
            Exit Sub
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT '電宰' AS '類別', T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', T0.[F1] AS '區別', T0.[F4] AS '調至儲位', T1.[U_M2] AS '原始儲位', "
            SQLCmd.CommandText += "           (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN CAST(SUM(ISNULL(T1.[Quantity],'9999')) AS INT) = '9999' THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態' "
            SQLCmd.CommandText += "          ,CONVERT(VARCHAR(19),T0.[InDaetTime],120) AS '時間' "
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN"
            SQLCmd.CommandText += "        ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], CAST(SUM(ISNULL(T2.[Quantity],'9999')) AS INT) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate]"
            SQLCmd.CommandText += "            FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] AND T1.[ItemCode] = T2.[ItemCode] "
            SQLCmd.CommandText += "                           INNER JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            'SQLCmd.CommandText += "           WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'G' AND TX.[F1] = @F1 AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
            SQLCmd.CommandText += "           WHERE T1.[DistNumber] IN ('" & DrfNums1 & "') "
            SQLCmd.CommandText += "        GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            SQLCmd.CommandText += "        ) T1 ON T0.[F2] = T1.[DistNumber] "
            'SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE T0.[F3] = 'G' AND TX.[F1] = @F1 AND TX.[F2] = T0.[F2] AND T0.[Del] = 'N' ) "
            SQLCmd.CommandText += "    WHERE T0.[F2] IN ('" & DrfNums1 & "') "
            SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T0.[F1], T0.[F4], T1.[U_M1], T1.[U_M2], T1.[U_M8] "
            SQLCmd.CommandText += " ORDER BY T0.[F1], T0.[F2], T1.[ItemCode], T0.[F4] "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

        Catch ex As Exception
            MsgBox("查詢調整區: " & ex.Message)
            'Exit Sub
            '查詢錯誤 = False
        End Try

        DGV3.AutoResizeColumns()
        DGV3_ListStatus()

        If 條碼數量.Text <> 0 And 重覆.Text = 0 And 未入庫.Text = 0 And 出庫.Text = 0 Then
            調庫.Visible = True
            調庫2.Visible = True
            'MsgBox("")
        Else
            調庫.Visible = False
            調庫2.Visible = False
            查詢錯誤 = False
            MsgBox("資料有誤請檢查", 48, "警告")
            查詢異常區別.Visible = True
        End If

        Dim TS1 As TimeSpan = Now.Subtract(dteStart)
        Label3.Text = Format(TS1.TotalSeconds, "###0.00")

    End Sub

    Private Sub 查詢調整區別MU2UP()

        If 查詢錯誤 = False Then
            Exit Sub
        End If
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " UPDATE [Z_KS_Barcode] SET [F6] = ISNULL(T2.[U_M2],''), [F5] = '1' "
            SQLCmd.CommandText += "  FROM [Z_KS_Barcode] T1 INNER JOIN [OSRN] T2 ON T1.[F2] = T2.[DistNumber] AND T1.[F3] = 'G' "
            'SQLCmd.CommandText += "                         INNER JOIN [OITM] T3 ON T2.[ItemCode] = T3.[ItemCode] "
            SQLCmd.CommandText += " WHERE T1.[F2] IN ('" & DrfNums1 & "') AND T1.[Del] = 'N' "


            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("更新儲位異常: " & ex.Message)
            'Exit Sub
        End Try

        Dim TS1 As TimeSpan = Now.Subtract(dteStart)
        Label4.Text = Format(TS1.TotalSeconds, "###0.00")

    End Sub

    Private Sub ChkLoc()

        If DGV5.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV5").Clear()
        End If

        If 查詢錯誤 = False Then
            Exit Sub
        End If
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            Dim Tmps As String
            Tmps = Format(Replace(Replace("#PickingDebitTmp" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")

            SQLCmd.CommandText = "    IF (OBJECT_ID('tempdb.." & Tmps & "') IS NOT NULL)  DROP TABLE " & Tmps & " "

            SQLCmd.CommandText += "   SELECT T0.[U_M2] AS 'F4', COUNT(T0.[U_M2]) AS 'T2Q' "
            SQLCmd.CommandText += "    INTO " & Tmps & " "
            SQLCmd.CommandText += "     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[ItemCode] = T1.[ItemCode] "
            SQLCmd.CommandText += "    WHERE T0.[U_M2] IN ('" & 儲位sx & "') AND ISNULL(T1.[Quantity],0) > 0 "
            SQLCmd.CommandText += " GROUP BY T0.[U_M2]"

            SQLCmd.CommandText += "SELECT T0.[F4] AS '儲位', ISNULL(T0.[T0Q],0) AS '調整數量', ISNULL(T1.[T1Q],0) AS '重覆數量', ISNULL(T2.[T2Q],0) AS '目前數量', "
            SQLCmd.CommandText += "       ISNULL(T0.[T0Q],0) + ISNULL(T2.[T2Q],0) - ISNULL(T1.[T1Q],0) AS '調後數量', ISNULL(T3.[U_Pmaxnum],0) AS '最大數', "
            SQLCmd.CommandText += "      (ISNULL(T0.[T0Q],0) + ISNULL(T2.[T2Q],0) - ISNULL(T1.[T1Q],0)) - ISNULL(T3.[U_Pmaxnum],0) AS '超出數' "
            SQLCmd.CommandText += "  FROM ( SELECT DISTINCT T0.[F4] AS 'F4', COUNT(T0.[F2]) AS 'T0Q' "
            SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 "
            SQLCmd.CommandText += "          WHERE T0.[F5] = '1' AND T0.[F1] IN ('" & 區別sx & "') "
            SQLCmd.CommandText += "       GROUP BY T0.[F4] )   T0 LEFT JOIN "
            SQLCmd.CommandText += "       ( SELECT DISTINCT T0.[F4] AS 'F4', COUNT(T0.[F6]) AS 'T1Q' "
            SQLCmd.CommandText += "           FROM [Z_KS_Barcode] T0 "
            SQLCmd.CommandText += "          WHERE T0.[F5] = '1' AND T0.[F4] = T0.[F6] AND T0.[F1] IN ('" & 區別sx & "') "
            SQLCmd.CommandText += "       GROUP BY T0.[F4] )   T1 ON T0.[F4] = T1.[F4] LEFT JOIN"
            SQLCmd.CommandText += "       ( SELECT * FROM " & Tmps & " ) T2 ON T0.[F4] = T2.[F4] LEFT JOIN [@WPLACE] T3 ON T0.[F4] = T3.[U_Pcode] "

            SQLCmd.CommandText += "   IF (OBJECT_ID('tempdb.." & Tmps & "') IS NOT NULL)  DROP TABLE " & Tmps & " "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV5")
            DGV5.DataSource = ks1DataSetDGV.Tables("DGV5")

        Catch ex As Exception
            MsgBox("計算儲位數: " & ex.Message)
            'Exit Sub
        End Try

        Dim TS1 As TimeSpan = Now.Subtract(dteStart)
        Label5.Text = Format(TS1.TotalSeconds, "###0.00")

        If DGV5.RowCount > 0 Then
            Dim Red As Integer = 0
            For i As Integer = 0 To DGV5.RowCount - 1
                If CInt(DGV5.Rows(i).Cells("超出數").Value) > 0 Then
                    DGV5.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Red += 1
                End If
            Next

            If Red > 0 Then
                MsgBox("數量已大於該儲位最大數!", 48, "警告")
            End If
        End If

        DGV5.AutoResizeColumns()

    End Sub

    Private Sub DGV5_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV5.Sorted
        DGV5_Sorted()
    End Sub

    Private Sub DGV5_Sorted()

        If DGV5.RowCount > 0 Then
            Dim Red As Integer = 0
            For i As Integer = 0 To DGV5.RowCount - 1
                If CInt(DGV5.Rows(i).Cells("超出數").Value) > 0 Then
                    DGV5.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    Red += 1
                End If
            Next
        End If

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

        條碼數量.Text = Format(DGV3.RowCount, "")
        重覆.Text = Cnt0
        未入庫.Text = Cnt1
        出庫.Text = Cnt2

    End Sub

    '-- 結束 -- 查詢條碼區別

    '-- 開始 -- 存草稿單號
    Private Sub 更新庫位資料_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 更新資料.Click

        If Replace(目前區別.Text, " ", "") = "" Then
            MsgBox("未選取存入區別", 48, "警告")
            Exit Sub
        End If

        If Replace(調至庫位.Text, " ", "") = "" Then
            調至庫位.Text = ""
            調至庫位.Focus()
            MsgBox("調至庫位空白", 48, "警告")
            Exit Sub
        End If

        存草稿單號至資料庫()

        目前區別.Text = ""
        If 庫位鎖定.Checked = True Then
            '不清除至庫位
        Else
            調至庫位.Text = ""
        End If
        更新資料.Enabled = False

        MsgBox("完成")

    End Sub

    Private Sub 存草稿單號至資料庫()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "  UPDATE [Z_KS_Barcode] SET [F4] = '" & 調至庫位.Text & "' WHERE [F1] = '" & 目前區別.Text & "' AND [Del] = 'N' "
        SQLCmd.ExecuteNonQuery()

        DGV2.CurrentRow.Cells("調至庫位").Value = 調至庫位.Text

    End Sub


    '-- 結束 -- 存草稿單號

    Private Sub 增加調整區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 增加調整區別.Click

        If DGV1.RowCount = 0 Then
            新增客戶TF = False
            查詢客編T2DGV2()
        End If

        '修改_調至庫位 = 空白 不寫入DGV1_Phil_20140304
        For Each oRow As DataGridViewRow In DGV2.SelectedRows
            Dim Row As DataRow
            Row = ks1DataSetDGV.Tables("DGV1").NewRow
            If Trim(oRow.Cells("調至庫位").Value) <> "" Then
                Row.Item("區別") = oRow.Cells("區別").Value
                Row.Item("調至庫位") = oRow.Cells("調至庫位").Value
                ks1DataSetDGV.Tables("DGV1").Rows.Add(Row)
            End If
        Next
        DGV1.AutoResizeColumns()

        '修改_原始_Phil_20140301_停用
        'For Each oRow As DataGridViewRow In DGV2.SelectedRows
        '    Dim Row As DataRow
        '    Row = ks1DataSetDGV.Tables("DGV1").NewRow
        '    Row.Item("區別") = oRow.Cells("區別").Value
        '    Row.Item("調至庫位") = oRow.Cells("調至庫位").Value

        '    ks1DataSetDGV.Tables("DGV1").Rows.Add(Row)
        '    DGV1.AutoResizeColumns()
        'Next

        新增客戶TF = True
        調庫.Visible = False
        調庫2.Visible = False

    End Sub

    Private Sub 查詢客編T2DGV2()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "  SELECT [F1] AS '區別', '' AS '調至庫位' "
        SQLCmd.CommandText += "   FROM [Z_KS_Barcode] "
        SQLCmd.CommandText += "  WHERE [F1] = 'ZZZZZZZZZZ'"

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
        DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

        DGV1.AutoResizeColumns()

        If DGV1.RowCount = 0 And 新增客戶TF = True Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 清空調整區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清空調整區別.Click

        查詢異常區別.Visible = False
        刪除條碼.Visible = False

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可清空", 48, "警告")
            Exit Sub
        End If

        清空調整區別SQL()
        調庫.Visible = False
        調庫2.Visible = False

    End Sub

    Private Sub 清空調整區別SQL()

        清空調整區別.Enabled = False

        If 清空調整區別.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                If DGV1.RowCount > 0 Then
                    ks1DataSetDGV.Tables("DGV1").Clear()
                End If

                MsgBox("刪除完成", 48, "刪除完成")
            End If
        End If

        清空調整區別.Enabled = True

    End Sub

    Private Sub 調庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 調庫.Click

        Label1.Text = "0.00" : Label3.Text = "0.00" : Label4.Text = "0.00" : Label5.Text = "0.00"

        dteStart = Now  ''...要計算執行時間的程式區段 ...

        If DGV3.Rows.Count > 0 Then
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

        sql = "SELECT TOP 1 T0.[DocNum] FROM [@ChgLocMgn] T0 ORDER BY T0.[DocNum] DESC "

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

        Try

            SQLCmd.Connection = DBConn

            '修改回存語法_Phil_20140310
            SQLCmd.CommandText = "  UPDATE [OSRN] SET [U_M2] = T1.[F4] "
            SQLCmd.CommandText += "   FROM [OSRN] T0 INNER JOIN [Z_KS_Barcode] T1 ON T0.[DistNumber] = T1.[F2] "
            SQLCmd.CommandText += "  WHERE T1.[F5] = '1' AND T1.[Del] = 'N' AND T1.[F2] IN ('" & DrfNums1 & "') "
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            SQLCmd.CommandText = "  INSERT INTO [@ChgLocMgn] ([DocNum],[SRNType],[Part],[FromLoc],[DistNumber],[ItemCode],[ItemName],[ToLoc]) "
            SQLCmd.CommandText += " SELECT @ADate, z.[F5], z.[F1], z.[F6], z.[F2], T1.[ItemCode], T2.[ItemName], z.[F4] "
            SQLCmd.CommandText += "   FROM [OSRN] T1 INNER JOIN [Z_KS_Barcode] z  ON T1.[DistNumber] = z.[F2] AND z.[F5] = '1' AND ISNULL(z.[F6],0) <> '0' AND z.[F1] IN ('" & 區別sx & "') AND z.[Del] = 'N' "
            SQLCmd.CommandText += "                  LEFT  JOIN [OITM]         T2 ON T1.[ItemCode] = T2.[ItemCode] "
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

        Dim TS1s As String = "0.00"
        Dim TS1 As TimeSpan = Now.Subtract(dteStart)
        TS1s = Format(TS1.TotalSeconds, "###0.00")

        MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate & vbCrLf & "執行時間: " & TS1s & " 秒", MsgBoxStyle.OkOnly, "成功")

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F1] IN ('" & 區別sx & "') AND [F3] = 'G' "
        SQLCmd.ExecuteNonQuery()
        查詢條碼區別()

        ks1DataSetDGV.Tables("DGV1").Clear()
        ks1DataSetDGV.Tables("DGV3").Clear()
        ks1DataSetDGV.Tables("DGV5").Clear()

        調庫.Visible = False
        調庫2.Visible = False

    End Sub


    Private Sub 刪除區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 刪除區別.Click
        If 目前區別.Text = "" Then
            MsgBox("未選取待刪除區別", 48, "警告")
            Exit Sub
        End If

        刪除區別.Enabled = False

        If 刪除區別.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?  區別 " + Format(目前區別.Text, ""), MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區

                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F1] = '" & 目前區別.Text & "' AND [F3] = 'G'  "
                SQLCmd.ExecuteNonQuery()

                查詢條碼區別()
                目前區別.Text = ""
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

                For Each oRow As DataGridViewRow In DGV3.SelectedRows

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F2] = '" & oRow.Cells("條碼").Value & "'  AND [F1] = '" & oRow.Cells("區別").Value & "' AND [Del] = 'N' "
                    SQLCmd.ExecuteNonQuery()

                Next

                '查詢異常條碼明細()
                MsgBox("刪除完成", 48, "刪除完成")

            End If
        End If

        刪除條碼.Enabled = True
        '查詢調整區別錯誤條碼SQL()

        If DGV3.RowCount = 0 Then
            查詢異常區別.Visible = False
            刪除條碼.Visible = False
        End If


    End Sub

    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click
        If DGV3.RowCount = 0 Then
            MsgBox("無資料可匯出", 16, "失敗")
            Exit Sub
        End If

        DataToExcel(DGV3, "")
    End Sub

    Private Sub 查條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查條碼.Click

        Dim DistNumber As String
        DistNumber = Format(DGV3.CurrentRow.Cells("條碼").Value, "")

        If DistNumber = "" Then
            MsgBox("請選擇條碼")
            Exit Sub
        End If

        查條碼明細.MdiParent = MainForm
        查條碼明細.DistNumbers.Text = DistNumber
        查條碼明細.Show()

    End Sub

    Private Sub 查詢異常區別_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢異常區別.Click

        查詢調整區別錯誤條碼SQL()

    End Sub

    Private Sub 查詢調整區別錯誤條碼SQL()

        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        區別ss = ""
        區別sx = ""
        儲位ss = ""
        儲位sx = ""

        For x As Integer = 0 To DGV1.RowCount - 1
            If 區別ss = "" Then
                區別ss = 區別ss + Format(DGV1.Rows(x).Cells("D4區別").Value, "")
            Else
                區別ss = 區別ss + "," + Format(DGV1.Rows(x).Cells("D4區別").Value, "")
            End If
        Next

        區別sx = Format(Replace(區別ss, ",", "','"), "")
        '區別sx = Format(區別ss, "")

        For x As Integer = 0 To DGV1.RowCount - 1
            If 儲位ss = "" Then
                儲位ss = 儲位ss + Format(DGV1.Rows(x).Cells("D4調至庫位").Value, "")
            Else
                儲位ss = 儲位ss + "," + Format(DGV1.Rows(x).Cells("D4調至庫位").Value, "")
            End If
        Next

        儲位sx = Format(Replace(儲位ss, ",", "','"), "")

        'Dim sss As String

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT '電宰' AS '類別', T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[F2] AS '條碼', T0.[F1] AS '區別', T0.[F4] AS '調至儲位', T1.[U_M2] AS '原始儲位', "
            SQLCmd.CommandText += "           (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN CAST(SUM(ISNULL(T1.[Quantity],'9999')) AS INT) = '9999' THEN '未入庫' ELSE CASE WHEN T1.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態' "
            SQLCmd.CommandText += "          ,CONVERT(VARCHAR(19),T0.[InDaetTime],120) AS '時間' "
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN "
            SQLCmd.CommandText += "        ( SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], CAST(SUM(ISNULL(T2.[Quantity],'9999')) AS INT) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            SQLCmd.CommandText += "            FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] AND T1.[ItemCode] = T2.[ItemCode] "
            SQLCmd.CommandText += "                           INNER JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            SQLCmd.CommandText += "           WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F3] = 'G' AND TX.[F1] IN ('" & 區別sx & "') AND TX.[F2] = T1.[DistNumber] AND TX.[Del] = 'N' ) "
            SQLCmd.CommandText += "        GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
            SQLCmd.CommandText += "        ) T1 ON T0.[F2] = T1.[DistNumber] "
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE T0.[F3] = 'G' AND TX.[F1] IN ('" & 區別sx & "') AND TX.[F2] = T0.[F2] AND T0.[Del] = 'N' ) "
            SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T1.[ItemName], T1.[Quantity], T1.[MnfDate], T0.[F2], T0.[F1], T0.[F4], T1.[U_M1], T1.[U_M2], T1.[U_M8] "
            SQLCmd.CommandText += "   HAVING CAST(SUM(ISNULL(T1.[Quantity],'9999')) AS INT) <> 1  "
            SQLCmd.CommandText += " ORDER BY T0.[F1], T0.[F2], T1.[ItemCode], T0.[F4] "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

        Catch ex As Exception
            MsgBox("查詢調整區_錯誤: " & ex.Message)
            'Exit Sub
            '查詢錯誤 = False
        End Try

        DGV3.AutoResizeColumns()
        DGV3_ListStatus()

        If 條碼數量.Text <> 0 And 重覆.Text = 0 And 未入庫.Text = 0 And 出庫.Text = 0 Then
            調庫.Visible = True
            調庫2.Visible = True
            'MsgBox("")
        Else
            調庫.Visible = False
            調庫2.Visible = False
            查詢錯誤 = False
            'MsgBox("資料有誤請檢查", 48, "警告")
            刪除條碼.Visible = True
        End If

    End Sub


    '-----調庫2

    Private Sub 調庫2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 調庫2.Click
        If DGV3.Rows.Count > 0 Then
            QryAdate2()
            DoingSQL2()
        End If
    End Sub

    Private Sub QryAdate2()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        ADate = Format(DocDate.Value.Date, "yyyyMMdd")
        ADate2 = Format(DocDate.Value.Date, "yyyy-MM-dd")

        sql = "SELECT TOP 1 T0.[DocNum] FROM [@ChgLocMgn] T0 WHERE T0.[ChgDate] = '" & ADate2 & "' ORDER BY T0.[DocNum] DESC "

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

    Private Sub DoingSQL2()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "  UPDATE [OSRN] set [U_M2] = "
            SQLCmd.CommandText += "   (SELECT [F4] FROM [Z_KS_Barcode] r WHERE [OSRN].[DistNumber] = r.[F2] AND r.[F1] IN ('" & 區別sx & "') AND [F5] = '1' AND [Del] = 'N') WHERE EXISTS "
            SQLCmd.CommandText += "   (SELECT *    FROM [Z_KS_Barcode] r WHERE [OSRN].[DistNumber] = r.[F2] AND r.[F1] IN ('" & 區別sx & "') AND [F5] = '1' AND [Del] = 'N') "

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            SQLCmd.CommandText = "  INSERT INTO [@ChgLocMgn] ([DocNum],[SRNType],[Part],[FromLoc],[DistNumber],[ItemCode],[ItemName],[ToLoc],[ChgDate]) "
            SQLCmd.CommandText += " SELECT @ADate, z.[F5], z.[F1], z.[F6], z.[F2], T1.[ItemCode], T2.[ItemName], z.[F4], '" & ADate2 & "' AS 'ChgDate' "
            SQLCmd.CommandText += "   FROM [OSRN] T1 INNER JOIN [Z_KS_Barcode] z  ON T1.[DistNumber] = z.[F2] AND z.[F5] = '1' AND ISNULL(z.[F6],0) <> '0' AND z.[F1] IN ('" & 區別sx & "') AND z.[Del] = 'N' "
            SQLCmd.CommandText += "                  LEFT  JOIN [OITM]         T2 ON T1.[ItemCode] = T2.[ItemCode] "
            SQLCmd.Parameters.Clear()
            SQLCmd.Parameters.AddWithValue("@ADate", ADate)
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception

            If MessageBox.Show("更新失敗：" & vbCrLf & ex.Message & vbCrLf & "是否要重試?", "錯誤", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then
                DoingSQL()
            Else
                MsgBox("更新失敗", 16, "失敗")
                'Exit Sub
            End If
            'Exit Sub
        End Try

        MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate, MsgBoxStyle.OkOnly, "成功")

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F1] IN ('" & 區別sx & "') AND [F3] = 'G' "
        SQLCmd.ExecuteNonQuery()
        查詢條碼區別()

        ks1DataSetDGV.Tables("DGV1").Clear()
        ks1DataSetDGV.Tables("DGV3").Clear()
        ks1DataSetDGV.Tables("DGV5").Clear()

        調庫.Visible = False
        調庫2.Visible = False

    End Sub

End Class