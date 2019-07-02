Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class v001驗收及領料及加工庫存查詢

    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim DataAdapterDGV As SqlDataAdapter

    Private Sub v001驗收及領料及加工庫存查詢_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        P1DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        P2DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        P3DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        P4DGV4.ContextMenuStrip = MainForm.ContextMenuStrip1
        P5DGV5.ContextMenuStrip = MainForm.ContextMenuStrip1
        P6DGV6.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub 驗收_查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 驗收_查詢.Click

        If P1DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If P2DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If


        If TabPage驗收明細.CanFocus = True Then
            GetP1DGV1Data()
        End If

        If TabPage毛雞扣帳核對.CanFocus = True Then
            GetP2DGV2Data()
        End If

    End Sub

    Private Sub GetP1DGV1Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = "  SELECT T0.[DocNum] AS '文件號碼', T0.[DocDate] AS '過帳日期', T0.[CardCode] AS '客戶/供應商代碼', "
        sql += "        T0.[CardName] AS '客戶/供應商名稱', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名', "
        sql += "        (CASE T1.[U_P7] WHEN '0' THEN T1.[unitMsr] WHEN '1' THEN (CASE T1.[U_P5] WHEN '1' THEN 'KG' END) WHEN '2' THEN "
        sql += "        (CASE T1.[U_P6] WHEN '1' THEN 'KG' WHEN '2' THEN '隻'  WHEN '3' THEN '盒'  WHEN '4' THEN '包' WHEN '5' THEN '件' END) END) AS '單位', "
        sql += "        T1.[Quantity] AS '數量', CAST(CAST(T1.[U_p2] AS NUMERIC(19,2))AS NVARCHAR) AS '重量', CONVERT(VARCHAR(12),T0.[DocDueDate],111) AS '到期日' "
        sql += " FROM OPDN T0 INNER JOIN PDN1 T1 ON T0.[DocEntry] = T1.[DocEntry] "
        sql += " WHERE (T0.[DocDate] >= '" & 驗收_日期1.Value.Date & "' AND T0.[DocDate] <= '" & 驗收_日期2.Value.Date & "') "


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
        P1DGV1.DataSource = ks1DataSetDGV.Tables("DT1")

        P1DGV1.AutoResizeColumns()

    End Sub

    Private Sub GetP2DGV2Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = "  SELECT T0.[DocNum] AS '文件號碼', T0.[U_M03] AS '製單編號', T0.[ItemCode] AS '存編', T4.[ItemName] AS '品名', "
        sql += "        (CASE ISNULL(T0.[U_M12],0) WHEN 0 THEN '未更新' ELSE dbo.getRoundN(T0.[U_M12],2) END) AS '領料隻數', "
        sql += "        (CASE ISNULL(T0.[U_M07],0) WHEN 0 THEN '未更新' ELSE dbo.getRoundN(T0.[U_M07],2) END) AS '領料重量', "
        sql += "        SUM(ISNULL(T3.[Quantity],0)) AS '發貨隻數', SUM(ISNULL(T3.[U_p2],0)) AS '發貨重量', "
        sql += "        (ISNULL(T0.[U_M12],0))-(SUM(ISNULL(T3.[Quantity],0))) AS '差異隻數', (ISNULL(T0.[U_M07],0))-(SUM(ISNULL(T3.[U_p2],0))) AS '差異重量', "
        sql += "        CASE ISNULL(T0.[U_M12],0) WHEN 0 THEN '未發貨' ELSE (CASE ISNULL(T0.[U_M07],0) WHEN 0 THEN '未發貨' ELSE "
        sql += "        (CASE ((ISNULL(T0.[U_M12],0))-(SUM(ISNULL(T3.[Quantity],0))))+((ISNULL(T0.[U_M07],0))-(SUM(ISNULL(T3.[U_p2],0)))) WHEN 0 THEN '已發貨' ELSE '未發貨' END) END) END AS '發貨結果' "
        sql += " FROM OWOR T0 INNER JOIN "
        sql += "      WOR1 T1 ON T0.[DocEntry] = T1.[DocEntry] INNER JOIN "
        sql += "      OITM T4 ON T0.[ItemCode] = T4.[ItemCode] LEFT JOIN "
        sql += "      OIGE T2 ON T0.[DueDate]  = T2.[DocDate] AND T0.[U_M03] = T2.[U_CK02] LEFT JOIN "
        sql += "      IGE1 T3 ON T2.[DocEntry] = T3.[DocEntry] AND T0.[ItemCode] = T3.[ItemCode] "
        sql += " WHERE T0.[U_M01] IN('1','4') AND (T0.[DueDate] BETWEEN '" & 驗收_日期1.Value.Date & "' AND '" & 驗收_日期2.Value.Date & "') AND T4.[ItemName] LIKE '%毛雞%' "
        sql += " GROUP BY T0.[DocNum], T0.[U_M03], T0.[ItemCode], T4.[ItemName], T0.[U_M12], T0.[U_M07] "
        sql += " ORDER BY T0.[U_M03] "


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")
        P2DGV2.DataSource = ks1DataSetDGV.Tables("DT2")

        P2DGV2.AutoResizeColumns()

    End Sub

    Private Sub 驗收_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 驗收_Excel.Click

        If TabPage驗收明細.CanFocus = True Then
            DataToExcel(P1DGV1, "")
        End If

        If TabPage毛雞扣帳核對.CanFocus = True Then
            DataToExcel(P2DGV2, "")
        End If

    End Sub

    Private Sub 領料_查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 領料_查詢.Click

        If P3DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        If P4DGV4.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT4").Clear()
        End If


        If TabPage電宰.CanFocus = True Then
            GetP3DGV3Data()
        End If

        If TabPage加工.CanFocus = True Then
            GetP4DGV4Data()
        End If

    End Sub

    Private Sub GetP3DGV3Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = "  SELECT T0.[DocNum] AS '文件號碼', T0.[U_CK02] AS '製單編號', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名', T1.[Quantity] AS '數量', T1.[U_p2] AS '重量(公斤)', "
        sql += "        CASE T0.[U_CK01] WHEN '0' THEN '一般出貨/調動' WHEN '1' THEN '送樣出貨' WHEN '2' THEN '送禮' WHEN '3' THEN '研發領用' WHEN '4' THEN '委外加工出貨' "
        sql += "                         WHEN '5' THEN '生產領料' WHEN '6' THEN '總務領用' WHEN '7' THEN '報廢' WHEN '8' THEN '盤差發貨' WHEN '9' THEN '試吃領用' "
        sql += "                         WHEN '10' THEN '展覽領用' WHEN '11' THEN '委外分切出貨' WHEN '12' THEN '代工\代宰品發貨' WHEN '13' THEN '異常發貨' "
        sql += "                         WHEN '14' THEN '生產調整' WHEN '15' THEN '不列入成本計算之調整' WHEN '16' THEN '委外飼料代工領料' "
        sql += "                         WHEN '17' THEN '營業訂單領用' END AS '發貨目的', T0.[Comments] AS '備註' "
        sql += " FROM OIGE T0 INNER JOIN IGE1 T1 ON T0.[DocEntry] = T1.[DocEntry] "
        sql += " WHERE (LEFT(T0.[U_CK02],1) BETWEEN '1' AND '6' OR LEFT(T0.[U_CK02],1) = 'X') AND "
        'sql += "       ((T0.[U_CK02] = '" & 領料_製單.Text & "' AND T0.[U_CK02] > '') OR (T0.[DocDate] >= '" & 領料_日期1.Value.Date & "' AND T0.[DocDate] <= '" & 領料_日期2.Value.Date & "')) "
        If 領料_製單.Text = "" Then
            sql += " (T0.[DocDate] >= '" & 領料_日期1.Value.Date & "' AND T0.[DocDate] <= '" & 領料_日期2.Value.Date & "') "
        Else
            sql += " (T0.[U_CK02] = '" & 領料_製單.Text & "' AND T0.[U_CK02] > '')"
        End If


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")
        P3DGV3.DataSource = ks1DataSetDGV.Tables("DT3")

        P3DGV3.AutoResizeColumns()

    End Sub

    Private Sub GetP4DGV4Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = "  SELECT T0.[DocNum] AS '文件號碼', T0.[U_CK02] AS '製單編號', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名', T1.[Quantity] AS '數量', T1.[U_p2] AS '重量(公斤)', "
        sql += " CASE T0.[U_CK01] WHEN '0' THEN '一般出貨/調動' WHEN '1' THEN '送樣出貨' WHEN '2' THEN '送禮' WHEN '3' THEN '研發領用' WHEN '4' THEN '委外加工出貨' "
        sql += "                  WHEN '5' THEN '生產領料' WHEN '6' THEN '總務領用' WHEN '7' THEN '報廢' WHEN '8' THEN '盤差發貨' WHEN '9' THEN '試吃領用' "
        sql += "                  WHEN '10' THEN '展覽領用' WHEN '11' THEN '委外分切出貨' WHEN '12' THEN '代工\代宰品發貨' WHEN '13' THEN '異常發貨' "
        sql += "                  WHEN '14' THEN '生產調整' WHEN '15' THEN '不列入成本計算之調整' WHEN '16' THEN '委外飼料代工領料' "
        sql += "                  WHEN '17' THEN '營業訂單領用' END AS '發貨目的', T0.[Comments] AS '備註'"
        sql += " FROM OIGE T0 INNER JOIN IGE1 T1 ON T0.[DocEntry] = T1.[DocEntry] "
        sql += " WHERE (LEFT(T0.[U_CK02],1) BETWEEN '7' AND '9' ) AND "
        'sql += "       ((T0.[U_CK02] = '" & 領料_製單.Text & "' AND T0.[U_CK02] > '') OR (T0.[DocDate] >= '" & 領料_日期1.Value.Date & "' AND T0.[DocDate] <= '" & 領料_日期2.Value.Date & "'))"
        If 領料_製單.Text = "" Then
            sql += " (T0.[DocDate] >= '" & 領料_日期1.Value.Date & "' AND T0.[DocDate] <= '" & 領料_日期2.Value.Date & "') "
        Else
            sql += " (T0.[U_CK02] = '" & 領料_製單.Text & "' AND T0.[U_CK02] > '')"
        End If


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT4")
        P4DGV4.DataSource = ks1DataSetDGV.Tables("DT4")

        P4DGV4.AutoResizeColumns()

    End Sub

    Private Sub 領料_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 領料_Excel.Click

        If TabPage電宰.CanFocus = True Then
            DataToExcel(P3DGV3, "")
        End If

        If TabPage加工.CanFocus = True Then
            DataToExcel(P4DGV4, "")
        End If

    End Sub

    Private Sub 加工庫存_查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 加工庫存_查詢.Click

        If P5DGV5.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT5").Clear()
        End If

        If P6DGV6.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT6").Clear()
        End If


        If TabPage統計.CanFocus = True Then
            GetP5DGV5Data()
        End If

        If TabPage明細.CanFocus = True Then
            GetP6DGV6Data()
        End If

    End Sub

    Private Sub GetP5DGV5Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = " EXEC [dbo].[M1020602_summery2] '" & 加工庫存_存編.Text & "' , '" & 加工庫存_品名.Text & "' , '" & 加工庫存_儲位.Text & "' "


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT5")
        P5DGV5.DataSource = ks1DataSetDGV.Tables("DT5")

        P5DGV5.AutoResizeColumns()

    End Sub

    Private Sub GetP6DGV6Data()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = " EXEC [dbo].[M1020602_Detail2] '" & 加工庫存_存編.Text & "' , '" & 加工庫存_品名.Text & "' , '" & 加工庫存_儲位.Text & "' "


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT6")
        P6DGV6.DataSource = ks1DataSetDGV.Tables("DT6")

        P6DGV6.AutoResizeColumns()

    End Sub

    Private Sub 加工庫存_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 加工庫存_Excel.Click

        If TabPage統計.CanFocus = True Then
            DataToExcel(P5DGV5, "")
        End If

        If TabPage明細.CanFocus = True Then
            DataToExcel(P6DGV6, "")
        End If

    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click

        If TabPage驗收.CanFocus = False Then
            If P1DGV1.RowCount > 0 Then
                ks1DataSetDGV.Tables("DT1").Clear()
            End If
            If P2DGV2.RowCount > 0 Then
                ks1DataSetDGV.Tables("DT2").Clear()
            End If
        End If

        If TabPage領料.CanFocus = False Then
            領料_製單.Text = ""
            If P3DGV3.RowCount > 0 Then
                ks1DataSetDGV.Tables("DT3").Clear()
            End If
            If P4DGV4.RowCount > 0 Then
                ks1DataSetDGV.Tables("DT4").Clear()
            End If
        End If

        If TabPage加工庫存.CanFocus = False Then
            加工庫存_存編.Text = ""
            加工庫存_品名.Text = ""
            加工庫存_儲位.Text = ""
            If P5DGV5.RowCount > 0 Then
                ks1DataSetDGV.Tables("DT5").Clear()
            End If
            If P6DGV6.RowCount > 0 Then
                ks1DataSetDGV.Tables("DT6").Clear()
            End If
        End If

    End Sub
End Class