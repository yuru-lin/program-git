Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 未入庫清單
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 未入庫清單_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        未入庫清單()
    End Sub


    Private Sub 未入庫清單()

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If


        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = " DECLARE @F1 varchar(5) "
            'SQLCmd.CommandText += "SET NOCOUNT ON	"
            'SQLCmd.CommandText += "SET @F1 = '" & Label10.Text & "' "

            'SQLCmd.CommandText += "   SELECT T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', T0.[F2] AS '條碼', T1.[U_M1] AS '重量', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN ISNULL(T2.[Quantity],'9999') = '9999' THEN '未入庫' ELSE CASE WHEN T2.[Quantity] = 0 THEN '出庫' ELSE CASE  WHEN T2.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態' "
            'SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN] T1 ON T0.[F2]        = T1.[DistNumber] "
            'SQLCmd.CommandText += "                            LEFT JOIN [OSRQ] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[ItemCode] = T2.[ItemCode] "
            'SQLCmd.CommandText += "                            LEFT JOIN [OITM] T3 ON T1.[ItemCode]  = T3.[ItemCode] "
            'SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE TX.[F1] = @F1 AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND T0.[F1] = @F1 AND T0.[Del] = 'N' "
            'SQLCmd.CommandText += " GROUP BY T1.[ItemCode], T3.[ItemName], T2.[Quantity], T1.[MnfDate], T0.[F2], T1.[U_M1], T1.[U_M2], T1.[U_M8] "
            'SQLCmd.CommandText += " ORDER BY COUNT(T0.[F2]) DESC ,T0.[F2] "


            SQLCmd.CommandText = "   SELECT  T4.[FI107]    AS '存編', T4.[FI108]    AS '品名', T0.[F2] AS '條碼', T4.[FI118] AS '重量', T0.[F1] AS '區別', T4.[FI109] AS '製造日期', T4.[FI102] AS '製造單號', (CASE WHEN COUNT(ISNULL(T0.[F2],0)) > 1 THEN '重覆' ELSE CASE WHEN ISNULL(T2.[Quantity],'9999') = '9999' THEN '未入庫' ELSE CASE WHEN T2.[Quantity] = 0 THEN '出庫' ELSE CASE WHEN T2.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END END) AS '狀態' "
            SQLCmd.CommandText += "     FROM [Z_KS_Barcode] T0 LEFT JOIN [OSRN]         T1 ON T0.[F2]        = T1.[DistNumber] "
            SQLCmd.CommandText += "                            LEFT JOIN [OSRQ]         T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[ItemCode] = T2.[ItemCode]  "
            SQLCmd.CommandText += "                            LEFT JOIN [@FinishItem1] T4 ON T0.[F2] = [FI106]"
            SQLCmd.CommandText += "    WHERE EXISTS( SELECT TX.[F2] FROM [Z_KS_Barcode] TX WHERE SUBSTRING(TX.[F1],1,1) = 'A' AND T0.[F2] = TX.[F2] AND TX.[Del] = 'N' ) AND ISNULL(T1.[DistNumber],'') = '' "
            SQLCmd.CommandText += " GROUP BY T4.[FI107], [FI108], T2.[Quantity], T4.[FI109], T0.[F2], T4.[FI118], T0.[F1], T4.[FI102]"
            SQLCmd.CommandText += " ORDER BY COUNT(T0.[F2]) DESC ,T0.[F2]"




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



End Class