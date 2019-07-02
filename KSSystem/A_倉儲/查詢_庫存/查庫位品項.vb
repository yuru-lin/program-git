Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class 查庫位品項

    Dim DataAdapterDGV, DataDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet

    Private Sub 查庫位品項_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        選擇儲位.Text = ""
        選擇品項.Text = ""

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click
        查詢儲位1()

        DatePr2.Value = DatePr.Value.Date

    End Sub

    Private Sub 查詢儲位1()
        If DGV1.RowCount > 0 Then
            DataSetDGV.Tables("DGV1").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sWhere_1 As String = String.Empty

        Try
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = "    SELECT [F1] AS '區別', [F4] AS '調至庫位', COUNT([F2]) AS '條碼數'"
            'SQLCmd.CommandText += "     FROM [Z_KS_Barcode] "
            'SQLCmd.CommandText += "    WHERE [F3] = 'G' AND [Del] = 'N'"
            'SQLCmd.CommandText += " GROUP BY [F1], [F4] "


            If R大於.Checked = True Then
                sWhere_1 = "    HAVING SUM(S0.[品項t]) > '" & 數量2.Text & "' "
            Else
                sWhere_1 = "    HAVING SUM(S0.[品項t]) < '" & 數量2.Text & "' "
            End If

            SQLCmd.CommandText = "    SELECT S0.[儲位t] AS '儲位', SUM(S0.[品項t]) AS '品項' "
            SQLCmd.CommandText += "     FROM ( SELECT T0.[U_M2] AS '儲位t', CAST(COUNT(DISTINCT T0.[ItemCode]) AS INTEGER) AS '品項t' "
            SQLCmd.CommandText += "              FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] "
            SQLCmd.CommandText += "             WHERE ISNULL(T1.[Quantity],0) > 0 "
            If 不限日期.Checked = False Then
                SQLCmd.CommandText += "           AND EXISTS( SELECT DISTINCT TM.[ToLoc] FROM [@ChgLocMgn] TM WHERE TM.[ToLoc] = T0.[U_M2] AND TM.[ChgDate] = '" & DatePr.Value.Date & "') "
            End If
            SQLCmd.CommandText += "          GROUP BY T0.[U_M2], T0.[ItemCode] ) S0 "
            SQLCmd.CommandText += " GROUP BY S0.[儲位t], S0.[品項t] "
            SQLCmd.CommandText += sWhere_1
            SQLCmd.CommandText += " ORDER BY 2 DESC "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "DGV1")
            DGV1.DataSource = DataSetDGV.Tables("DGV1")

        Catch ex As Exception
            MsgBox("查詢:" & ex.Message)
        End Try

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        選擇儲位.Text = DGV1.CurrentRow.Cells("儲位").Value
        選擇品項.Text = DGV1.CurrentRow.Cells("品項").Value


    End Sub

    Private Sub 查詢儲位_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢儲位.Click
        If 選擇儲位.Text = "" Then
            MsgBox("未選擇儲位", 48, "異常")
            Exit Sub
        End If

        查詢儲位2()

    End Sub

    Private Sub 查詢儲位2()
        If DGV2.RowCount > 0 Then
            DataSetDGV.Tables("DGV2").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', T0.[U_M2] AS '儲位', COUNT(T0.[U_M2]) AS '數量' "
            SQLCmd.CommandText += "     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] "
            SQLCmd.CommandText += "                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode]"
            SQLCmd.CommandText += "    WHERE T0.[U_M2] = '" & 選擇儲位.Text & "' AND ISNULL(T1.[Quantity],0) > 0 "
            SQLCmd.CommandText += " GROUP BY T0.[ItemCode], T2.[ItemName], T0.[U_M2] ORDER BY SUBSTRING(T0.[ItemCode],5,1), 1 "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "DGV2")
            DGV2.DataSource = DataSetDGV.Tables("DGV2")

        Catch ex As Exception
            MsgBox("查詢儲位:" & ex.Message)
        End Try

        DGV2.AutoResizeColumns()

        Dim Sum As Integer = 0

        For i As Integer = 0 To DGV2.RowCount - 1
            Sum += DGV2.Rows(i).Cells("數量").Value
        Next

        目前儲位.Text = 選擇儲位.Text
        目前品項數.Text = 選擇品項.Text
        目前數量.Text = Sum


        選擇儲位.Text = ""
        選擇品項.Text = ""

    End Sub

    Private Sub 異常_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 異常.Click

    End Sub

    Private Sub DoingSQL2()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = "  UPDATE [OSRN] set [U_M2] = "
            'SQLCmd.CommandText += "   (SELECT [F4] FROM [Z_KS_Barcode] r WHERE [OSRN].[DistNumber] = r.[F2] AND r.[F1] IN ('" & 區別sx & "') AND [F5] = '1' AND [Del] = 'N') WHERE EXISTS "
            'SQLCmd.CommandText += "   (SELECT *    FROM [Z_KS_Barcode] r WHERE [OSRN].[DistNumber] = r.[F2] AND r.[F1] IN ('" & 區別sx & "') AND [F5] = '1' AND [Del] = 'N') "

            'SQLCmd.Parameters.Clear()
            'SQLCmd.ExecuteNonQuery()

            'SQLCmd.CommandText = "  INSERT INTO [@ChgLocMgn] ([DocNum],[SRNType],[Part],[FromLoc],[DistNumber],[ItemCode],[ItemName],[ToLoc],[ChgDate]) "
            'SQLCmd.CommandText += " SELECT @ADate, z.[F5], z.[F1], z.[F6], z.[F2], T1.[ItemCode], T2.[ItemName], z.[F4], '" & ADate2 & "' AS 'ChgDate' "
            'SQLCmd.CommandText += "   FROM [OSRN] T1 INNER JOIN [Z_KS_Barcode] z  ON T1.[DistNumber] = z.[F2] AND z.[F5] = '1' AND ISNULL(z.[F6],0) <> '0' AND z.[F1] IN ('" & 區別sx & "') AND z.[Del] = 'N' "
            'SQLCmd.CommandText += "                  LEFT  JOIN [OITM]         T2 ON T1.[ItemCode] = T2.[ItemCode] "
            'SQLCmd.Parameters.Clear()
            'SQLCmd.Parameters.AddWithValue("@ADate", ADate)
            'SQLCmd.ExecuteNonQuery()

            'SQLCmd.CommandText = "  INSERT INTO [@ChgLocMgn] ([DocNum],[SRNType],[Part],[FromLoc],[DistNumber],[ItemCode],[ItemName],[ToLoc],[ChgDate]) "
            SQLCmd.CommandText = "  INSERT INTO [Z_KS_UM2S] () "
            SQLCmd.CommandText += "   SELECT '" & DatePr2.Value.Date & "' AS '日期' T0.[U_M2] AS '儲位',, T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', COUNT(T0.[U_M2]) AS '數量', 'N' AS '完成否' "
            SQLCmd.CommandText += "     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] "
            SQLCmd.CommandText += "                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode]"
            SQLCmd.CommandText += "    WHERE T0.[U_M2] = '" & 選擇儲位.Text & "' AND ISNULL(T1.[Quantity],0) > 0 "
            SQLCmd.CommandText += " GROUP BY T0.[ItemCode], T2.[ItemName], T0.[U_M2] ORDER BY SUBSTRING(T0.[ItemCode],5,1), 1 "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("更新失敗", 16, "失敗")
            Exit Sub

            'If MessageBox.Show("更新失敗：" & vbCrLf & ex.Message & vbCrLf & "是否要重試?", "錯誤", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then
            '    DoingSQL()
            'Else
            '    MsgBox("更新失敗", 16, "失敗")
            '    Exit Sub
            'End If
            'Exit Sub
        End Try

        'MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate, MsgBoxStyle.OkOnly, "成功")

        'SQLCmd.Connection = DBConn
        'SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F1] IN ('" & 區別sx & "') AND [F3] = 'G' "
        'SQLCmd.ExecuteNonQuery()
        '查詢條碼區別()

        'ks1DataSetDGV.Tables("DGV1").Clear()
        'ks1DataSetDGV.Tables("DGV3").Clear()
        'ks1DataSetDGV.Tables("DGV5").Clear()

        '調庫.Visible = False
        '調庫2.Visible = False

    End Sub

    Private Sub 轉出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉出Excel.Click

        If ExcelRB1.Checked = True Then
            DataToExcel(DGV1, "")
        Else
            DataToExcel(DGV2, "")
        End If

    End Sub
End Class