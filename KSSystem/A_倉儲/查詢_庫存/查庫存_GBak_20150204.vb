Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 查庫存_G_Bak
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 查庫存_G_Bak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" Then
            MsgBox("未KEY查詢項目", 48, "警告")
            TextBox1.Focus()
            Exit Sub
        End If

        查庫存()
    End Sub

    Private Sub 查庫存()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            Dim x4xx As String = Format(Replace(TextBox6.Text, ",", "','"), "")
            Dim x5xx As String = Format(Replace(TextBox4.Text, ",", "','"), "")
            Dim x7x8 As String = Format(Replace(TextBox5.Text, ",", "','"), "")

            'x5 = "'" + Format(Replace(TextBox4.Text, ",", "','"), "") + "'"
            'Format(Replace(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 4), " ", ""), "")


            'SQLCmd.CommandText = " DECLARE @DocEntry varchar(10) "
            'SQLCmd.CommandText += "DECLARE @FromDate DateTime "
            'SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            'SQLCmd.CommandText += "SET NOCOUNT ON "
            'SQLCmd.CommandText += "SET @DocEntry = '" & DrfNum.Text & "' "
            'SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            'SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "


            SQLCmd.CommandText = " DECLARE @code NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @name NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @um2  NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @FromDate DateTime "
            SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            'SQLCmd.CommandText += "SET NOCOUNT ON "
            SQLCmd.CommandText += "SET @code     = '" & Format(TextBox1.Text, "") & "' "
            SQLCmd.CommandText += "SET @name     = '" & Format(TextBox2.Text, "") & "' "
            If TextBox3.Text <> "" Then
                SQLCmd.CommandText += "SET @um2  = '" & Format(TextBox3.Text, "") & "%' "
            Else
                SQLCmd.CommandText += "SET @um2  = '' "
            End If
            SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "

            SQLCmd.CommandText += "DECLARE @ALL1 NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @ALL2 NVARCHAR(20) "
            SQLCmd.CommandText += "SET     @ALL1 = 'NO' "
            SQLCmd.CommandText += "SET     @ALL2 = 'NO' "

            SQLCmd.CommandText += "IF @code = '' OR @code = NULL SET @ALL1 = 'ALL' "
            SQLCmd.CommandText += "IF @um2  = '' OR @um2  = NULL SET @ALL2 = 'ALL' "

            ' ''SQLCmd.CommandText += "   SELECT T0.[ItemCode] AS '存編',T0.[ItemName] AS '品名',T1.[WhsCode] AS '倉庫',T2.[U_M2] AS '儲位',sum(T1.[Quantity]) AS '數量',"
            ' ''SQLCmd.CommandText += "          T0.[InvntryUom] AS '單位',cast(sum(cast(T2.[U_M1] AS float)) AS nvarchar) AS '重量',"
            ' ''SQLCmd.CommandText += "          T2.[MnfDate] AS '製造日期',DATEDIFF(DAY,T2.[MnfDate],GETDATE()) AS '天數',T2.[U_M8] AS '製單編號', T3.[M_NO] AS 'G1',"
            ' ''SQLCmd.CommandText += "          CASE when T2.[MnfDate]='2010.12.11' then '烏' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2009.11.06' then '土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2009.12.05' then '土'     when T2.[MnfDate]='2010.04.28' then '土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.07.24' then '土'     when T2.[MnfDate]='2010.07.26' then '土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.08.02' then '土'     when T2.[MnfDate]='2010.08.20' then '土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.08.25' then '土'     when T2.[MnfDate]='2010.08.31' then '土'  "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.09.06' then '土'     when T2.[MnfDate]='2010.10.23' then '土'"
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.11.01' then '土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2009.06.15' then '人土'   when T2.[MnfDate]='2009.11.17' then '人土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.07.23' then '人土'   when T2.[MnfDate]='2010.07.27' then '人土' "
            ' ''SQLCmd.CommandText += "               when T2.[MnfDate]='2010.10.14' then '白露花' when T2.[MnfDate]='2010.10.26' then '白露花' "
            ' ''SQLCmd.CommandText += "               else NULL end AS 'G2'"
            ' ''SQLCmd.CommandText += "    FROM [OITM] T0 INNER JOIN [OSRQ]       T1 ON T0.[ItemCode]   = T1.[ItemCode] "
            ' ''SQLCmd.CommandText += "                   INNER JOIN [OSRN]       T2 ON T1.[MdAbsEntry] = T2.[AbsEntry] "
            ' ''SQLCmd.CommandText += "                   LEFT  JOIN [z_format_G] T3 ON T2.[U_M8]       = T3.[M_NO]     "
            ' ''SQLCmd.CommandText += "   WHERE T1.[Quantity] > 0 "
            ' ''If TextBox5.Text <> "" Then
            ' ''    SQLCmd.CommandText += " AND SUBSTRING(T0.[ItemCode],4,1) IN ('" & x4xx & "')"
            ' ''End If
            ' ''If TextBox4.Text <> "" Then
            ' ''    SQLCmd.CommandText += " AND SUBSTRING(T0.[ItemCode],5,1) IN ('" & x5xx & "')"
            ' ''Else
            ' ''    SQLCmd.CommandText += " AND (T0.[ItemCode] = @code OR @ALL1 = 'ALL') "
            ' ''End If
            ' ''If TextBox5.Text <> "" Then
            ' ''    SQLCmd.CommandText += " AND SUBSTRING(T0.[ItemCode],7,2) IN ('" & x7x8 & "')"
            ' ''End If

            ' ''SQLCmd.CommandText += "  AND (T0.[ItemName] LIKE '%'+@name+'%') AND (T2.[U_M2] = @um2 OR @ALL2 = 'ALL') AND (T2.[MnfDate] BETWEEN @FromDate AND @ToDate) "
            '' ''If TextBox4.Text <> "" Then
            '' ''    SQLCmd.CommandText += " WHERE T1.[Quantity] > 0 AND SUBSTRING(T0.[ItemCode],5,1) IN ('" & x5xx & "') AND SUBSTRING(T0.[ItemCode],7,2) IN ('" & x7x8 & "') AND (T0.[ItemName] LIKE '%'+@name+'%') AND (T2.[U_M2] = @um2 OR @ALL2 = 'ALL') AND (T2.[MnfDate] Between @FromDate AND @ToDate ) "
            '' ''    If TextBox5.Text <> "" Then
            '' ''    End If
            '' ''Else
            '' ''    SQLCmd.CommandText += " WHERE T1.[Quantity] > 0 AND (T0.[ItemCode] = @code OR @ALL1 = 'ALL') AND (T0.[ItemName] LIKE '%'+@name+'%') AND (T2.[U_M2] = @um2 OR @ALL2 = 'ALL') AND (T2.[MnfDate] Between @FromDate AND @ToDate ) "
            '' ''End If
            '' ''SQLCmd.CommandText += "   WHERE T1.[Quantity] > 0 AND (T0.[ItemCode] = @code OR @ALL1 = 'ALL') AND (T0.[ItemName] LIKE '%'+@name+'%') AND (T2.[U_M2] = @um2 OR @ALL2 = 'ALL')"
            ' ''SQLCmd.CommandText += "GROUP BY T0.[ItemCode], T0.[ItemName], T1.[WhsCode], T2.[U_M2], T0.[InvntryUom], T2.[MnfDate], T2.[U_M8], T3.[M_NO] "
            ' ''SQLCmd.CommandText += "ORDER BY T2.[MnfDate] "

            '' ''SQLCmd.CommandText = "    SELECT [F1] AS '區別', [F4] AS '草稿單號', COUNT([F2]) AS '條碼數'"
            '' ''SQLCmd.CommandText += "     FROM [Z_KS_Barcode] "
            '' ''SQLCmd.CommandText += "    WHERE [F3] = 'A' AND [Del] = 'N'"
            '' ''SQLCmd.CommandText += " GROUP BY [F1], [F4] "


            SQLCmd.CommandText += "   SELECT '生鮮' AS'類別', TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], SUM(ISNULL(TX.[數量],0)) AS '數量', TX.[單位], SUM(ISNULL(TX.[重量],0)) AS '重量', TX.[製造日期], TX.[天數], TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK], SUM(ISNULL(TX.[數量2],0)) AS '2號庫數量', SUM(ISNULL(TX.[重量2],0)) AS '2號庫重量' "
            SQLCmd.CommandText += "     FROM ( "
            SQLCmd.CommandText += "           SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[WhsCode] AS '倉庫', T0.[U_M2] AS '儲位', "
            SQLCmd.CommandText += "                  T0.[Quantity] AS '數量', T0.[InvntryUom] as '單位', T0.[U_M1] AS '重量', "
            SQLCmd.CommandText += "                  T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.[MnfDate], getdate())+1  AS '天數', T0.[DistNumber] AS '條碼', "
            SQLCmd.CommandText += "                  ISNULL(T0.[U_M8],'') AS '製造單號', ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
            SQLCmd.CommandText += "                  CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[U_M1] END AS '重量2' "
            SQLCmd.CommandText += "             FROM ( "
            SQLCmd.CommandText += "                   SELECT T0.[ItemCode] AS 'ItemCode', T2.[ItemName] AS 'ItemName', T1.[WhsCode] AS 'WhsCode', T0.[U_M2] AS 'U_M2', "
            SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T1.[Quantity],0) AS INT))           AS 'Quantity', T2.[InvntryUom] as 'InvntryUom', "
            SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T0.[U_M1],0)     AS NUMERIC(19,2))) AS 'U_M1',CONVERT(CHAR(10),T0.[MnfDate], 120) AS 'MnfDate',  "
            SQLCmd.CommandText += "                          T0.[DistNumber], CAST(T0.[U_M8] AS NVARCHAR(12)) AS 'U_M8' "
            SQLCmd.CommandText += "                     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[DistNumber] NOT LIKE '2013%' "
            SQLCmd.CommandText += "                                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "
            ' SQLCmd.CommandText += "                    WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T0.[MnfDate] Between @FromDate AND @ToDate ) "

            SQLCmd.CommandText += "                    WHERE T1.[Quantity] > 0 AND (T0.[U_M2] Like @um2 OR @ALL2 = 'ALL') AND (T0.[MnfDate] BETWEEN @FromDate AND @ToDate) "
            'If TextBox6.Text <> "" Then
            '    'SQLCmd.CommandText += "                  AND SUBSTRING(T0.[ItemCode],4,1) IN ('" & x4xx & "')"
            '    Select Case TextBox6.Text
            '        Case 1
            '            SQLCmd.CommandText += "          AND SUBSTRING(T0.[ItemCode],4,1) IN ('" & x4xx & "')"
            '        Case 2
            '            SQLCmd.CommandText += "          AND SUBSTRING(T0.[ItemCode],4,1) IN ('" & x4xx & "')"
            '    End Select
            'End If
            'If TextBox3.Text <> "" Then
            '    SQLCmd.CommandText += "                  AND (T0.[U_M2] Like @um2 OR @ALL2 = 'ALL') "
            'End If
            If TextBox1.Text <> "" Then
                SQLCmd.CommandText += "                  AND (T0.[ItemCode] = @code OR @ALL1 = 'ALL') "
            End If
            If TextBox2.Text <> "" Then
                SQLCmd.CommandText += "                  AND (T2.[ItemName] LIKE '%'+@name+'%') "
            End If
            'If TextBox4.Text <> "" Then
            '    SQLCmd.CommandText += "                  AND SUBSTRING(T0.[ItemCode],5,1) IN ('" & x5xx & "') "
            'Else
            '    'SQLCmd.CommandText += "                  AND (T0.[ItemCode] = @code OR @ALL1 = 'ALL') "
            'End If
            'If TextBox5.Text <> "" Then
            '    SQLCmd.CommandText += "                  AND SUBSTRING(T0.[ItemCode],7,2) IN ('" & x7x8 & "') "
            'End If
            'If TextBox6.Text <> "" Then
            '    SQLCmd.CommandText += "                  AND SUBSTRING(T0.[ItemCode],4,1) IN ('" & x4xx & "') "
            'End If
            'SQLCmd.CommandText += "                      AND (T0.[U_M2] = @um2 OR @ALL2 = 'ALL') AND (T0.[MnfDate] BETWEEN @FromDate AND @ToDate) "

            SQLCmd.CommandText += "                 GROUP BY T0.[ItemCode], T2.[ItemName], T1.[WhsCode], T0.[U_M2], T2.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8] "
            SQLCmd.CommandText += "                  ) T0 "
            SQLCmd.CommandText += "                       LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
            SQLCmd.CommandText += "                       LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
            SQLCmd.CommandText += "                       LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
            SQLCmd.CommandText += "                       LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
            SQLCmd.CommandText += "        GROUP BY T0.[ItemCode], T0.[ItemName], T0.[WhsCode], T0.[U_M2], T0.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[Quantity], T0.[U_M1], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto] "
            SQLCmd.CommandText += "          ) TX "
            SQLCmd.CommandText += "GROUP BY TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], TX.[單位], TX.[製造日期], TX.[天數], TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK] "
            SQLCmd.CommandText += "  HAVING ([儲位] Like @um2 OR @ALL2 = 'ALL') "

            If TextBox6.Text <> "" Then
                SQLCmd.CommandText += " AND SUBSTRING([存編],4,1) IN ('" & x4xx & "') "
            End If
            If TextBox4.Text <> "" Then
                SQLCmd.CommandText += " AND SUBSTRING([存編],5,1) IN ('" & x5xx & "') "
            End If
            If TextBox5.Text <> "" Then
                SQLCmd.CommandText += " AND SUBSTRING([存編],7,2) IN ('" & x7x8 & "') "
            End If





            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

            DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub 轉出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉出Excel.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub 查庫位_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查庫位.Click

        Dim UM2 As String = ""
        UM2 = Format(DGV1.CurrentRow.Cells("儲位").Value, "")

        If UM2 = "" Then
            MsgBox("請選擇儲位")
            Exit Sub
        End If

        查單庫位.MdiParent = MainForm
        查單庫位.UM2s.Text = UM2
        查單庫位.Show()

    End Sub

End Class