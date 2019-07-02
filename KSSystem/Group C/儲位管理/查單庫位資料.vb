Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 查單庫位

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 查單庫位_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        品項數.Text = 0
        查單庫位()

    End Sub

    Private Sub UM2s_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UM2s.TextChanged
        查單庫位()

    End Sub

    Private Sub 查單庫位()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = " DECLARE @FromDate DateTime "
            'SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            SQLCmd.CommandText = " DECLARE @UM2 varchar(20) "
            SQLCmd.CommandText += "SET NOCOUNT ON "
            'SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            'SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @UM2 = '" & UM2s.Text & "' "

            If Login.LogonCompanyDB = "KaiShing" Then
                SQLCmd.CommandText += "  SELECT '生鮮' AS'類別', T0.[ItemCode]   AS '存編', T0.[ItemName] AS '品名', T1.[WhsCode] AS '倉庫', T2.[U_M2] AS '儲位',COUNT(T2.[U_M2]) AS '件數', "
                SQLCmd.CommandText += "         dbo.getRoundN(SUM(ISNULL(T1.[Quantity],0)),0) AS '數量',T0.[InvntryUom] AS '單位', dbo.getRoundN(SUM(CAST(ISNULL(T2.[U_M1],0) AS float)),2) AS '重量',  "
                SQLCmd.CommandText += "         T2.[MnfDate] AS '製造日期', DATEDIFF(DAY,T2.[MnfDate],GETDATE()) AS '天數', T2.[U_M8] AS '製單編號', ISNULL(T3.[M_NO],'') AS 'G1', "
                SQLCmd.CommandText += "         ISNULL(CASE WHEN T2.[MnfDate]='2010.12.11' THEN '烏' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2009.11.06' THEN '土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2009.12.05' THEN '土'     WHEN T2.[MnfDate]='2010.04.28' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.07.24' THEN '土'     WHEN T2.[MnfDate]='2010.07.26' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.08.02' THEN '土'     WHEN T2.[MnfDate]='2010.08.20' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.08.25' THEN '土'     WHEN T2.[MnfDate]='2010.08.31' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.09.06' THEN '土'     WHEN T2.[MnfDate]='2010.10.23' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.11.01' THEN '土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2009.06.15' THEN '人土'   WHEN T2.[MnfDate]='2009.11.17' THEN '人土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.07.23' THEN '人土'   WHEN T2.[MnfDate]='2010.07.27' THEN '人土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.10.14' THEN '白露花' WHEN T2.[MnfDate]='2010.10.26' THEN '白露花' "
                SQLCmd.CommandText += "                     ELSE NULL END,'') AS 'G2' "
                SQLCmd.CommandText += "    FROM [OSRN] T2 INNER JOIN [OSRQ]       T1 ON T2.[SysNumber] = T1.[SysNumber] AND T2.[ItemCode] = T1.[ItemCode] AND T2.[AbsEntry] = T1.[MdAbsEntry] "
                SQLCmd.CommandText += "                   INNER JOIN [OITM]       T0 ON T2.[ItemCode]  = T0.[ItemCode] "
                SQLCmd.CommandText += "                   LEFT  JOIN [z_format_G] T3 ON T2.[U_M8]      = T3.[M_NO] "
                'SQLCmd.CommandText += "   WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate )"
                ''SQLCmd.CommandText += "   WHERE T2.[U_M2] = @UM2 AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate )"
                SQLCmd.CommandText += "   WHERE T2.[U_M2] = @UM2 AND T1.[Quantity] > 0 "
                SQLCmd.CommandText += "GROUP BY T0.[ItemCode], T0.[ItemName], T1.[WhsCode], T2.[U_M2], T0.[InvntryUom], T2.[MnfDate], T2.[U_M8], T3.[M_NO] "
                SQLCmd.CommandText += "UNION "
            End If

            SQLCmd.CommandText += "  SELECT '調理' AS'類別', T0.[ItemCode]   AS '存編', T0.[ItemName] AS '品名', T1.[WhsCode] AS '倉庫', T2.[U_M2] AS '儲位',COUNT(T2.[U_M2]) AS '件數', "
            SQLCmd.CommandText += "         dbo.getRoundN(SUM(ISNULL(T1.[Quantity],0)),0) AS '數量', T0.[InvntryUom] AS '單位', dbo.getRoundN(SUM(CAST(ISNULL(T2.[U_M1],0) AS float)),2) AS '重量', "
            SQLCmd.CommandText += "         T2.[MnfDate] AS '製造日期', DATEDIFF(DAY,T2.[MnfDate],GETDATE()) AS '天數', ISNULL(T2.[U_M8],'') AS '製單編號', '' AS 'G1', '' AS 'G2' "
            SQLCmd.CommandText += "    FROM [OBTN] T2 INNER JOIN [OBTQ] T1 ON T2.[SysNumber] = T1.[SysNumber] AND T2.[ItemCode] = T1.[ItemCode] AND T2.[AbsEntry] = T1.[MdAbsEntry] "
            SQLCmd.CommandText += "                   INNER JOIN [OITM] T0 ON T2.[ItemCode]  = T0.[ItemCode] "
            'SQLCmd.CommandText += "   WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate ) AND T1.[WhsCode] IN ('S01','S04','S06') "
            ''SQLCmd.CommandText += "   WHERE T2.[U_M2] = @UM2 AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate ) AND T1.[WhsCode] IN ('S01','S04','S06') "
            SQLCmd.CommandText += "   WHERE T2.[U_M2] = @UM2 AND T1.[Quantity] > 0 AND T1.[WhsCode] IN ('S01','S04','S06') "
            SQLCmd.CommandText += "GROUP BY T0.[ItemCode], T0.[ItemName], T1.[WhsCode], T2.[U_M2], T0.[InvntryUom], T2.[MnfDate], T2.[U_M8] "
            SQLCmd.CommandText += "ORDER BY 5, 2"

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

        品項數.Text = DGV2.RowCount

    End Sub


End Class