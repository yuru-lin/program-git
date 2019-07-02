Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Linq

Public Class 生產需求統計v001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet

    Private Sub 生產需求統計_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        排程All()
    End Sub

    Private Sub 排程All()
        If DGV2.RowCount > 0 Then : DataSetDGV.Tables("TDT2").Clear() : End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "exec z_SPdataAll2 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "
            'sql = "exec z_SPdataAll3 '2016-01-01' , '1' "
            'sql = "exec z_SPdataAll3 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            sql = "  DECLARE @DocNum VARCHAR(20) "
            sql += " SET @DocNum = '" & dateDocDate.Value.Date & "' "

            sql += " SELECT  T1.廠商,T1.[FrgnName] AS '品名', SUM(T1.[需生產數量]) AS '需生產數量',T1.[單位] "
            sql += " FROM ( "
            sql += "    SELECT T0.[CardName] AS '廠商', T2.[FrgnName], SUM(T1.[U_P3_Quantity]) AS '需生產數量', T2.[SalPackMsr] AS '單位' "
            sql += "      FROM [ODRF] T0 inner join "
            sql += " 	      [DRF1] T1 ON T0.DocEntry = T1.DocEntry left join"
            sql += " 	      [OITM] T2 ON T1.ItemCode = T2.ItemCode "
            sql += "     WHERE T0.[DocDueDate] = @DocNum and (T0.WddStatus ='Y' OR T0.WddStatus ='W' )and T0.DocStatus = 'O' and T0.ObjType = '17' and T0.CANCELED = 'N' and T0.U_P3_Order = 'Y' and T1.U_P3 = 'Y' "
            sql += "  GROUP BY T0.[CardName], T2.[FrgnName], T2.[SalPackMsr] "
            sql += " UNION ALL "
            sql += "    SELECT T0.[CardName] AS '廠商', T2.[FrgnName], SUM(T1.[U_P3_Quantity]) AS '需生產數量', T2.[SalPackMsr] AS '單位' "
            sql += "      FROM [ORDR] T0 inner join "
            sql += "           [RDR1] T1 ON T0.DocEntry = T1.DocEntry left join  "
            sql += "           [OITM] T2 ON T1.ItemCode = T2.ItemCode "
            sql += "     WHERE T0.[DocDueDate] = @DocNum and T0.DocStatus = 'O' and T0.CANCELED = 'N' and T0.U_P3_Order = 'Y' and T1.U_P3 = 'Y' "
            sql += "  GROUP BY T0.[CardName], T2.[FrgnName], T2.[SalPackMsr]) T1 "

            sql += "  GROUP BY  T1.廠商,T1.[FrgnName], T1.[單位] "
            sql += "  ORDER BY 1,2 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "TDT2")
            DGV2.DataSource = DataSetDGV.Tables("TDT2")
            TransactionMonitor.Complete()

            DGV2.Refresh()
            DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'Label28.Text = Floor.Text
        'Label27.Text = TimeOfDay.ToShortTimeString
        '查詢單據_Play()
        MsgBox("查詢完成")
    End Sub

End Class



