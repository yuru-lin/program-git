Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 查條碼明細

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 查條碼明細_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        查單條碼()

    End Sub

    Private Sub DistNumbers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistNumbers.TextChanged
        查單條碼()

    End Sub

    Private Sub 查單條碼()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            ''SQLCmd.CommandText = " DECLARE @FromDate DateTime "
            ''SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            'SQLCmd.CommandText = " DECLARE @DistNumbers varchar(20) "
            'SQLCmd.CommandText += "SET NOCOUNT ON "
            ''SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            ''SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "
            'SQLCmd.CommandText += "SET @DistNumbers = '" & DistNumbers.Text & "' "

            SQLCmd.CommandText += "  SELECT X1.[日期], CASE WHEN X1.[類別2] = '14' THEN 'AR/貸項通知單' ELSE CASE WHEN X1.[類別2] = '15' THEN '交貨單' ELSE CASE WHEN X1.[類別2] = '16' THEN '銷售退回單' ELSE CASE WHEN X1.[類別2] = '20' THEN '收貨採購單' ELSE CASE WHEN X1.[類別2] = '59' THEN '收貨單' ELSE CASE WHEN X1.[類別2] = '60' THEN '發貨單' ELSE '未知' END END END END END END AS '類別', "
            SQLCmd.CommandText += "         X1.[文件單號], X1.[存編], X1.[品名], X1.[條碼], X1.[數量], "
            SQLCmd.CommandText += "         CASE WHEN X1.[類別2] = '15' THEN ISNULL(U2.[Descr],'') ELSE CASE WHEN X1.[類別2] = '60' THEN ISNULL(U5.[Descr],'') ELSE '' END END AS '發貨', "
            SQLCmd.CommandText += "         CASE WHEN X1.[類別2] = '20' THEN ISNULL(U3.[Descr],'') ELSE CASE WHEN X1.[類別2] = '59' THEN ISNULL(U4.[Descr],'') ELSE '' END END AS '收貨'  "
            SQLCmd.CommandText += "    FROM "
            SQLCmd.CommandText += "         ( SELECT CONVERT(CHAR(10),T3.[DocDate], 111) AS '日期', T3.[ApplyType] AS '類別2', T3.[ApplyEntry] AS '文件單號', T3.[ItemCode] AS '存編', T3.[ItemName] AS '品名', T0.[DistNumber] AS '條碼', CAST(ISNULL(T1.[Quantity],0) AS INT) AS '數量' "
            SQLCmd.CommandText += "            FROM [OSRN] T0 INNER JOIN [OSRQ]         T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] "
            SQLCmd.CommandText += "                           INNER JOIN [ITL1]         T2 ON T0.[ItemCode] = T2.[ItemCode] AND T0.[SysNumber] = T2.[SysNumber] AND T0.[AbsEntry] = T2.[MdAbsEntry] "
            SQLCmd.CommandText += "                           INNER JOIN [OITL]         T3 ON T2.[LogEntry] = T3.[LogEntry] "
            SQLCmd.CommandText += "           WHERE T0.[DistNumber] LIKE '%" & DistNumbers.Text & "%' "
            SQLCmd.CommandText += "          ) X1 "
            SQLCmd.CommandText += "               LEFT  JOIN [ODLN] X2 ON X2.[DocNum]  = X1.[文件單號] AND X2.[ObjType] = X1.[類別2] "
            SQLCmd.CommandText += "               LEFT  JOIN [UFD1] U2 ON U2.[TableID] = 'ODLN'        AND U2.[FieldID] = '53'       AND X2.[U_CK01] = U2.[IndexID] "
            SQLCmd.CommandText += "               LEFT  JOIN [OPDN] X3 ON X3.[DocNum]  = X1.[文件單號] AND X3.[ObjType] = X1.[類別2] "
            SQLCmd.CommandText += "               LEFT  JOIN [UFD1] U3 ON U3.[TableID] = 'OPDN'        AND U3.[FieldID] = '77'       AND X3.[U_CK06] = U3.[IndexID] "
            SQLCmd.CommandText += "               LEFT  JOIN [OIGN] X4 ON X4.[DocNum]  = X1.[文件單號] AND X4.[ObjType] = X1.[類別2] "
            SQLCmd.CommandText += "               LEFT  JOIN [UFD1] U4 ON U4.[TableID] = 'OIGN'        AND U4.[FieldID] = '77'       AND X4.[U_CK06] = U4.[IndexID] "
            SQLCmd.CommandText += "               LEFT  JOIN [OIGE] X5 ON X5.[DocNum]  = X1.[文件單號] AND X5.[ObjType] = X1.[類別2] "
            SQLCmd.CommandText += "               LEFT  JOIN [UFD1] U5 ON U5.[TableID] = 'OIGE'        AND U5.[FieldID] = '53'       AND X5.[U_CK01] = U5.[IndexID] "
            SQLCmd.CommandText += "ORDER BY 7, 1, 2 "

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



End Class