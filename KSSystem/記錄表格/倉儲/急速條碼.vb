Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 急速條碼
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet


    Private Sub 急速條碼_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        查詢條碼()
    End Sub

    Private Sub DocDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocDate.ValueChanged
        查詢條碼()
    End Sub

    Private Sub F01s_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles F01s.VisibleChanged
        查詢條碼()
    End Sub

    Private Sub 查詢條碼()

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        'Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'Using TransactionMonitor As New System.Transactions.TransactionScope
        '    sql = "    SELECT [Sid] AS 'Sid', (CASE [Kid2] WHEN 'UE01' THEN '生產' WHEN 'UB03' THEN '品管' WHEN 'UE05' THEN '倉儲' ELSE '??單位' END) AS '單位', [F01] AS '庫別', [F02] AS '條碼', [F03] AS '開機日期', [F04] AS '開機時間', [F05] AS '開機溫度', [F06] AS '關機時間', [F07] AS '關機日期', [F08] AS '關機溫度', [F09] AS '品溫', [F10] AS '搬貨日期', [F11] AS '搬貨時間', [F12] AS '搬完日期', [F13] AS '搬完時間', [F14] AS '異常狀況', [F15] AS '處置結果及說明' "
        '    sql += "     FROM [Z_KS_Record_02] "
        '    sql += "    WHERE [DocDate] = '" & DatePicker1.Value.Date & "' AND [Kid2] = '" & TextBox12.Text & "' AND [Cancel] = 'Y' "
        '    sql += " ORDER BY 1 "
        '    SQLCmd.Connection = DBConn
        '    SQLCmd.CommandText = sql

        '    DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        '    DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
        '    DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")
        '    TransactionMonitor.Complete()
        'End Using

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @F01 varchar(10) "
            SQLCmd.CommandText += "DECLARE @F06 varchar(10) "
            SQLCmd.CommandText += "SET @F01 = '" & Format(DocDate.Value.Date, "yyMMdd") & "' "
            SQLCmd.CommandText += "SET @F06 = '" & Format(F01s.Text, "") & "' "
            'SQLCmd.CommandText += "SET @F06 = 'J211' "

            SQLCmd.CommandText += "   SELECT [DocDate] AS '入庫時間', [F01] AS '製造單號', [F02] AS '生產單位', [F03] AS '條碼', [F04] AS '存編', [F05] AS '品名', [F06] AS '儲位' "
            SQLCmd.CommandText += "     FROM [Z_KS_Record_021] "
            SQLCmd.CommandText += "    WHERE SUBSTRING([F01],2,6) = @F01 AND [F06] = @F06 "
            SQLCmd.CommandText += " ORDER BY 2, 3, 5, 4 "



            'SQLCmd.CommandText = "    SELECT [F1] AS '區別', [F4] AS '草稿單號', COUNT([F2]) AS '條碼數'"
            'SQLCmd.CommandText += "     FROM [Z_KS_Barcode] "
            'SQLCmd.CommandText += "    WHERE [F3] = 'A' AND [Del] = 'N'"
            'SQLCmd.CommandText += " GROUP BY [F1], [F4] "

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