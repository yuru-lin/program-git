Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class 指定入庫
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub 指定入庫_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        BtnExl1.Enabled = False
        BtnExl2.Enabled = False
    End Sub

    Private Sub QuyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuyBtn.Click

        If DGV1.RowCount <> 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        QuyMore1()

    End Sub

    Private Sub QuyMore1()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter

        'sql = "Select T0.ItemCode , T2.ItemName , cast(SUM(T1.Quantity) as int) as '數量' , T0.U_M2 From OSRN T0 left join OSRQ T1 ON T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.ItemCode = T2.ItemCode Where T1.Quantity > 0 and T0.U_M2 in ('J011','J012','J013','J014','J015') and T0.MnfDate = '" & FromDate.Value.Date & "' Group By T0.ItemCode , T2.ItemName , T0.U_M2 "

        sql = "    SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', CAST(SUM(T1.Quantity) AS INT) AS '數量', T0.[U_M2] AS '儲位', CAST(SUM(T1.Quantity) / 48 AS INT) AS '板數', CAST(SUM(T1.Quantity) % 48 AS INT) AS '零散' "
        'sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
        sql += "     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry]  "
        sql += "                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "
        sql += "    WHERE T1.[Quantity] > 0 AND T0.[U_M2] IN ('J011','J012','J013','J014','J015') AND T0.[MnfDate] = '" & FromDate.Value.Date & "' "
        sql += " GROUP BY T0.[ItemCode], T2.[ItemName], T0.[U_M2] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        DGV1.DataSource = ks1DataSet.Tables("DT1")
        DGV1Display()

    End Sub




    Private Sub DGV1Display()

        If DGV1.RowCount <= 0 Then
            MsgBox("查不到資料!請確認條碼是否正確!")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 2
                Case "儲位"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 3
                Case "板數"
                    column.HeaderText = "板數"
                    column.DisplayIndex = 4
                Case "零散"
                    column.HeaderText = "零散"
                    column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        BtnExl1.Enabled = True

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If DGV1.RowCount = 0 Then
            Exit Sub
        End If

        If DGV2.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        QuyMore()

    End Sub

    Private Sub QuyMore()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter

        sql = "exec L20110819Q '" & DGV1.CurrentRow.Cells("存編").Value & "' , '" & DGV1.CurrentRow.Cells("數量").Value & "'"
        ''sql = "L20110819Q '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' , '" & DGV1.CurrentRow.Cells("數量").Value & "'"


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        ''SQLCmd.Connection = DBConn
        ''SQLCmd.CommandText = sql
        ''SQLCmd.CommandType = CommandType.StoredProcedure
        ''SQLCmd.CommandTimeout = 100000
        ''SQLCmd.Parameters.Add(New SqlParameter("@ic", SqlDbType.NVarChar))
        ''SQLCmd.Parameters.Add(New SqlParameter("@in", SqlDbType.Int))
        ''SQLCmd.Parameters("@ic").Value = DGV1.CurrentRow.Cells("ItemCode").Value
        ''SQLCmd.Parameters("@in").Value = DGV1.CurrentRow.Cells("數量").Value
        ''SQLCmd.ExecuteNonQuery()


        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT2")

        DGV2.DataSource = ks1DataSet.Tables("DT2")
        DGV2.AutoResizeColumns()
        If DGV2.RowCount > 0 Then
            BtnExl2.Enabled = True
        End If

    End Sub

    Private Sub BtnExl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExl1.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub BtnExl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExl2.Click
        DataToExcel(DGV2, "")
    End Sub

End Class