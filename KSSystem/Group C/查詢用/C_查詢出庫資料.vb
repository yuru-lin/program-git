Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class C_查詢出庫資料
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_查詢出庫資料_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        LoadSourceMain()

    End Sub

    '依作業類別載入欲入庫製單號, 並指派給dgvSourceMain
    Private Sub LoadSourceMain()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        'If RB1.Checked = True Then
        '    'sql = "SELECT T1.FI101 as '生產單號', T1.FI102 as '製單單號',T1.FI107 as '存貨編號',T1.FI108 as '品名',T1.FI106 as '條碼',T1.FI105 as '文件日期' FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.FI101 = T1.FI101 WHERE (T0.FI103 = '3') AND (T1.FI103 < '4')"
        '    'sql = "exec zHLnvetoryThan '" & TextBox1.Text & "','" & TextBox2.Text & "' "
        '    sql = "exec zHLnvetoryThan '" & Format(Date1.Value.Date, "yyyy/MM/dd") & "','" & Format(Date2.Value.Date, "yyyy/MM/dd") & "' "

        'End If

        'sql = "   IF (OBJECT_ID('tempdb..#OO11Tmp') IS NOT NULL)  DROP TABLE #OO11Tmp; "
        'sql += "  IF (OBJECT_ID('tempdb..#OO12Tmp') IS NOT NULL)  DROP TABLE #OO12Tmp; "
        ''--暫存開始
        'sql += " SELECT T1.[DocEntry], T2.[ItemCode], T1.[DocDate], T2.[SysNumber], T2.[MdAbsEntry], T1.[DocType] "
        'sql += "   INTO #OO11Tmp "
        'sql += "   FROM [OITL] T1 INNER JOIN [ITL1] T2 ON T1.[LogEntry] = T2.[LogEntry] "
        'sql += "  WHERE T1.[DocType] IN ('15','60') AND LEFT(T2.[ItemCode],2) = '25' AND T1.[DocDate] BETWEEN '" & Format(Date1.Value.Date, "yyyy/MM/dd") & "' AND '" & Format(Date2.Value.Date, "yyyy/MM/dd") & "' "

        'sql += " SELECT O3.[DocEntry], O0.[ItemCode], O0.[DistNumber], O3.[DocType], O0.[U_M2], O0.[MnfDate], O3.[DocDate], ISNULL(DATEDIFF(DAY,O0.[MnfDate], O3.[DocDate])+1, 0) AS '天數', O1.[Quantity] AS '數量' "
        'sql += "   INTO #OO12Tmp "
        'sql += "   FROM [OSRN] O0 INNER JOIN [OSRQ] O1 ON O0.[ItemCode] = O1.[ItemCode] AND O0.[SysNumber] = O1.[SysNumber] AND O0.[AbsEntry] = O1.[MdAbsEntry] "
        'sql += "                  INNER JOIN(SELECT * FROM #OO11Tmp "
        'sql += "                            )       O3 ON O0.[ItemCode] = O3.[ItemCode] AND O0.[SysNumber] = O3.[SysNumber] AND O0.[AbsEntry] = O3.[MdAbsEntry] "
        ''--暫存結束
        'sql += "   SELECT O0.[ItemCode] AS '存編', O3.[ItemName] AS '品名', CONVERT(CHAR(10),O0.[DocDate], 120) AS '出庫日期', ISNULL(O1.[庫區],'1號') AS '庫區', "
        'sql += "          COUNT(O0.[DistNumber]) AS '數量', O0.[U_M2] AS '儲位', CONVERT(CHAR(10),O0.[MnfDate], 120) AS '製造日期', O0.[天數], "
        'sql += "          CASE WHEN O0.[天數] > 365 THEN '大於365' ELSE '小於365' END  AS '天數2' "
        'sql += "     FROM #OO12Tmp O0 LEFT  JOIN (SELECT '2號' AS '庫區', T1.[InvSto] FROM [z_NO2] T1 )O1 ON O0.[DistNumber] = O1.[InvSto] "
        'sql += "                      INNER JOIN [OITM] O3 ON O0.[ItemCode] = O3.[ItemCode] "
        'sql += " GROUP BY O0.[ItemCode], O3.[ItemName], O0.[DocDate], ISNULL(O1.[庫區],'1號'), O0.[U_M2], O0.[MnfDate], O0.[天數] "
        'sql += " ORDER BY 3, 4, 9 DESC "

        'sql += "  IF (OBJECT_ID('tempdb..#OO11Tmp') IS NOT NULL)  DROP TABLE #OO11Tmp; "
        'sql += "  IF (OBJECT_ID('tempdb..#OO12Tmp') IS NOT NULL)  DROP TABLE #OO12Tmp; "

        sql = "   IF (OBJECT_ID('tempdb..#OO11Tmp') IS NOT NULL)  DROP TABLE #OO11Tmp; "
        sql += "  IF (OBJECT_ID('tempdb..#OO12Tmp') IS NOT NULL)  DROP TABLE #OO12Tmp; "
        '--暫存開始
        sql += " SELECT T1.[DocEntry], T2.[ItemCode], T1.[DocDate], T2.[SysNumber], T2.[MdAbsEntry], T1.[DocType] "
        sql += "   INTO #OO11Tmp "
        sql += "   FROM [OITL] T1 INNER JOIN [ITL1] T2 ON T1.[LogEntry] = T2.[LogEntry] "
        sql += "  WHERE T1.[DocType] IN ('15','60') AND LEFT(T2.[ItemCode],2) IN ('25','21','31') AND T1.[DocDate] BETWEEN '" & Format(Date1.Value.Date, "yyyy/MM/dd") & "' AND '" & Format(Date2.Value.Date, "yyyy/MM/dd") & "' "

        sql += " SELECT O3.[DocEntry], O0.[ItemCode], O0.[DistNumber], O3.[DocType], O0.[U_M2], O0.[MnfDate], O3.[DocDate], ISNULL(DATEDIFF(DAY,O0.[MnfDate], O3.[DocDate])+1, 0) AS '天數', O1.[Quantity] AS '數量', O4.[U_CK01] "
        sql += "   INTO #OO12Tmp "
        sql += "   FROM [OSRN] O0 INNER JOIN [OSRQ] O1 ON O0.[ItemCode] = O1.[ItemCode] AND O0.[SysNumber] = O1.[SysNumber] AND O0.[AbsEntry] = O1.[MdAbsEntry] "
        sql += "                  INNER JOIN(SELECT * FROM #OO11Tmp "
        sql += "                            )       O3 ON O0.[ItemCode] = O3.[ItemCode] AND O0.[SysNumber] = O3.[SysNumber] AND O0.[AbsEntry] = O3.[MdAbsEntry] "
        sql += "                  LEFT  JOIN  OIGE  O4 ON O3.[DocEntry] = O4.[DocEntry]  "
        '--暫存結束
        sql += "   SELECT CASE O0.[DocType] WHEN '15' THEN '出貨' WHEN '60' THEN '領料' END AS '類別', "
        sql += "          CASE O0.[DocType] WHEN '60' THEN (CASE O0.U_CK01 WHEN '0' THEN '一般出貨/調動' WHEN '1' THEN '送樣出貨' WHEN '2' THEN '送禮' WHEN '3' THEN '研發領用' "
        sql += "                            WHEN '4' THEN '委外加工出貨' WHEN '5' THEN '生產領料' WHEN '6' THEN '總務領用' WHEN '7' THEN '報廢' WHEN '8' THEN '盤差發貨' "
        sql += "                            WHEN '9' THEN '試吃領用' WHEN '10' THEN '展覽領用 'WHEN '11' THEN '委外分切出貨' WHEN '12' THEN '代工\代宰品發貨' WHEN '13' THEN '異常發貨' "
        sql += "                            WHEN '14' THEN '生產調整' WHEN '15' THEN '不列入成本計算之調整' WHEN '16' THEN '委外飼料代工領料' WHEN '17' THEN '營業訂單領用' END) END AS '說明', "
        sql += "          O0.[ItemCode] AS '存編',O3.[ItemName] AS '品名', CONVERT(CHAR(10),O0.[DocDate], 120) AS '出庫日期', ISNULL(O1.[庫區],'1號') AS '庫區', "
        sql += "          COUNT(O0.[DistNumber]) AS '數量', O0.[U_M2] AS '儲位', CONVERT(CHAR(10),O0.[MnfDate], 120) AS '製造日期', O0.[天數], "
        sql += "          CASE WHEN O0.[天數] > 365 THEN '大於365' ELSE '小於365' END  AS '天數2' "
        sql += "     FROM #OO12Tmp O0 LEFT  JOIN (SELECT '2號' AS '庫區', T1.[InvSto] FROM [z_NO2] T1 )O1 ON O0.[DistNumber] = O1.[InvSto] "
        sql += "                      INNER JOIN [OITM] O3 ON O0.[ItemCode] = O3.[ItemCode] "
        sql += " GROUP BY O0.[ItemCode], O3.[ItemName], O0.[DocDate], ISNULL(O1.[庫區],'1號'), O0.[U_M2], O0.[MnfDate], O0.[天數], O0.[DocType], O0.[U_CK01] "
        sql += " ORDER BY 5, 6, 11 DESC "

        sql += "  IF (OBJECT_ID('tempdb..#OO11Tmp') IS NOT NULL)  DROP TABLE #OO11Tmp; "
        sql += "  IF (OBJECT_ID('tempdb..#OO12Tmp') IS NOT NULL)  DROP TABLE #OO12Tmp; "



        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")
        dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")

        dgvSourceMain.AutoResizeColumns()
    End Sub



    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(dgvSourceMain, "")
    End Sub
End Class