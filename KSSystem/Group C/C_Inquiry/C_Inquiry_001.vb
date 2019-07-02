Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_Inquiry_001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub C_Inquiry_001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '查詢生產單資料

        SelectDGV1()

    End Sub

    Private Sub SelectDGV1()
        '取得生產單項目統計

        '清空DGV1內容
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "    SELECT [FI107] AS '存編',[FI108] AS '品名',COUNT([FI107]) AS '數量' "
            'sql += "     FROM [@FinishItem1] "
            'sql += "    WHERE [FI105] = '" & FI105.Value.Date & "' AND "
            'sql += "          [FI101] = '" & FI101.Text & "'       AND "
            'sql += "          [FI103] in ('1','2','3','4') "
            'sql += " GROUP BY [FI107],[FI108] "
            'sql += " ORDER BY 1 "


            sql = "    SELECT T0.[FI107] AS '存編', T0.[FI108] AS '品名', COUNT(T0.[FI107]) AS '數量' "
            sql += "     FROM [@FinishItem1] T0"
            sql += "    WHERE T0.[FI105] = '" & FI105.Value.Date & "' AND "
            sql += "          T0.[FI103] IN ('1','2','3','4')         AND "
            sql += "          SUBSTRING(T0.[FI107],1,4) in ('2511','2512','3111','3112')"
            sql += " GROUP BY T0.[FI107],T0.[FI108]"
            sql += " ORDER BY 1"




            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "PDT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("PDT1")
            TransactionMonitor.Complete()

            DGV1.AutoResizeColumns()

            DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataToExcel(DGV1, "")
    End Sub

End Class