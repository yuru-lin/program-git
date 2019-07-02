Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QuerySchedule
    Dim DataAdapterDGV, DataAdapter1 As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_QuerySchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvDetail.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub SearchData()

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "Select T0.[sid] as '編號',T0.[CardCode] as '客編',T0.[CardName] as '客名',T0.[ItemCode] as '存編',T0.[ItemName] as '品名',T0.[FromDate] as '開始日期',T0.[ToDate] as '結束日期' ,T0.[NeedQuantity] as '需求數',count(T1.FI106) as '生產數',(T0.[NeedQuantity] - count(T1.FI106)) as '缺數' From [@ProduceSchedule] T0 left join [@FinishItem1] T1 ON T0.[CardCode] = T1.FI119 and T0.[ItemCode] = T1.FI107 and (T1.FI105 between T0.[FromDate] and T0.[ToDate]) and T1.FI103 < 5 Where T0.[CurrentStatus] = 'O' and T0.ToDate >= CONVERT(varchar(12),GETDATE(),102) Group by T0.[sid],T0.[CardCode],T0.[CardName],T0.[ItemCode],T0.[ItemName],T0.[NeedQuantity],T0.[FromDate],T0.[ToDate]"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        DGV1Display()
    End Sub

    Private Sub DGV1Display()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "編號"
                    column.DisplayIndex = 0
                Case "客名"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "結束日期"
                    column.DisplayIndex = 3
                Case "需求數"
                    column.DisplayIndex = 4
                Case "生產數"
                    column.DisplayIndex = 5
                Case "缺數"
                    column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If dgvDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        SearchDetail()
    End Sub

    Private Sub SearchDetail()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.FI128 as '客名' , T0.FI108 as '品名' , T0.FI105 as '日期' ,COUNT(T0.FI106)as '數量' FROM [@FinishItem1] T0 Where T0.FI103 < 5 and T0.FI119 = '" & DGV1.CurrentRow.Cells("客編").Value & "' and   T0.FI107 = '" & DGV1.CurrentRow.Cells("存編").Value & "' and (T0.FI105 between '" & DGV1.CurrentRow.Cells("開始日期").Value & "' and '" & DGV1.CurrentRow.Cells("結束日期").Value & "') Group By T0.FI128,T0.FI108,T0.FI105 order by FI105"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")

        dgvDetail.DataSource = ks1DataSetDGV.Tables("DT2")
        dgvDetail.AutoResizeColumns()
        'DGV1Display()
    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub ToExcelBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn2.Click
        DataToExcel(dgvDetail, "")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If dgvDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If
        SearchData()
    End Sub
End Class