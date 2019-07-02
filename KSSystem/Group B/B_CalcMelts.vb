Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class B_CalcMelts
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_CalcMelts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If cmbType.SelectedIndex < 0 Then
            MsgBox("未選類型!", 16, "錯誤")
            Exit Sub
        End If

        Quy()
    End Sub

    Private Sub Quy()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
            txtSumOfTotal.Text = ""
            txtSumOfTime.Text = ""
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope
            Try
                Select Case cmbType.SelectedIndex
                    Case "0"
                        sql = "SELECT T0.[U_M03] as '製造單號',T0.[PostDate] as '日期',T2.[ItemCode] as '存貨編號',T2.[Dscription] as '品名規格',T2.[unitMsr] as '單位',cast(dbo.getRoundN(T2.[Quantity],2) as float)  as '產出合計',cast(dbo.getRoundN(T0.[U_M07],2) as float) as '入料合計' ,cast(dbo.getRoundN((T2.[Quantity] / T0.[U_M07] * 100),2) as float)as '製成率',cast(T0.[U_T01] as float) as '工時數' FROM OWOR T0 inner join OIGN T1 ON T0.U_M03 = T1.U_CK02 INNER JOIN IGN1 T2 ON T1.DocEntry = T2.DocEntry WHERE (left(T0.U_M03,1) = 'B') AND (T1.[JrnlMemo] = '生產收貨') AND  (T0.[PostDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') AND T1.U_CK06 = '1' "
                    Case "1"
                        'sql = "SELECT T0.U_M03 as '製造單號',T0.[PostDate] as '日期',T2.[ItemCode] as '存貨編號',T2.[Dscription] as '品名規格',  T2.[unitMsr] as '單位', cast(dbo.getRoundN(T0.[PlannedQty],2) as float) as '預產數', cast(dbo.getRoundN(T2.[Quantity],2) as float) as '產出數',cast(dbo.getRoundN((T0.[PlannedQty] / T2.[Quantity] * 100),2) as float) as '製成率',cast(T0.[U_T01] as float) as '工時數' FROM OWOR T0 inner join OIGN T1 ON T0.U_M03 = T1.U_CK02 INNER JOIN IGN1 T2 ON T1.DocEntry = T2.DocEntry WHERE (left(T0.U_M03,1) = 'A') AND  (T0.[PostDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') AND T1.U_CK06 = 1"
                        sql = "SELECT T0.[U_M03] as '製造單號',T0.[PostDate] as '日期',T2.[ItemCode] as '存貨編號',T2.[Dscription] as '品名規格',T2.[unitMsr] as '單位',cast(dbo.getRoundN(T0.[PlannedQty],2) as float) as '預產數' ,cast(dbo.getRoundN(T2.[Quantity],2) as float) as '產出數',cast(SUM(CASE WHEN T3.[unitMsr] IN ('G','g') THEN (T3.[Quantity]/1000) ELSE T3.[Quantity] END)as decimal (10,2)) as '領料數',cast(dbo.getRoundN((T2.[Quantity] / SUM(CASE WHEN T3.[unitMsr] IN ('G','g') THEN (T3.[Quantity]/1000) ELSE T3.[Quantity] END) * 100),2) as float) as '製成率',cast(T0.[U_T01] as float) as '工時數' FROM OWOR T0 inner join OIGN T1 ON T0.[U_M03] = T1.[U_CK02] INNER JOIN IGN1 T2 ON T1.[DocEntry] = T2.[DocEntry] inner join IGE1 T3 ON T0.[DocNum] = T3.[BaseRef] WHERE (left(T0.[U_M03],1) = 'A') AND (T0.[PostDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') AND T1.[U_CK06] = '1' GROUP BY T0.[U_M03], T0.[PostDate], T2.[ItemCode], T2.[Dscription], T2.[unitMsr], T0.[PlannedQty], T2.[Quantity], T0.[U_T01] "
                End Select

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql

                DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
                DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

                DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
                TransactionMonitor.Complete()
            Catch ex As Exception               
                MsgBox("Quy失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                Exit Sub
            End Try
        End Using

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
            Exit Sub
        Else
            DGV1Display()
        End If
    End Sub

    Private Sub DGV1Display()

        DGV1.AutoResizeColumns()
        Dim SumOfTotal As Double = 0
        Dim SumOfTime As Double = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            Select Case cmbType.SelectedIndex
                Case "0"
                    SumOfTotal += DGV1.Rows(i).Cells("產出合計").Value
                    SumOfTime += DGV1.Rows(i).Cells("工時數").Value
                Case "1"
                    SumOfTotal += DGV1.Rows(i).Cells("產出數").Value
                    SumOfTime += DGV1.Rows(i).Cells("工時數").Value
            End Select
        Next
        txtSumOfTotal.Text = SumOfTotal
        txtSumOfTime.Text = SumOfTime

    End Sub

    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click
        Select Case cmbType.SelectedIndex
            Case "0"
                B_ReportViewer.MdiParent = MainForm
                B_ReportViewer.Source = "Melts"
                B_ReportViewer.dt = ks1DataSetDGV.Tables("DT1")
                B_ReportViewer.strPara(0) = Format(FromDate.Value.Date, "yyyy/MM/dd")
                B_ReportViewer.strPara(1) = Format(ToDate.Value.Date, "yyyy/MM/dd")
                B_ReportViewer.strPara(2) = txtSumOfTotal.Text
                B_ReportViewer.strPara(3) = txtSumOfTime.Text
                B_ReportViewer.Show()
            Case "1"
                B_ReportViewer.MdiParent = MainForm
                B_ReportViewer.Source = "Feeding"
                B_ReportViewer.dt = ks1DataSetDGV.Tables("DT1")
                B_ReportViewer.strPara(0) = FromDate.Value.Date
                B_ReportViewer.strPara(1) = ToDate.Value.Date
                B_ReportViewer.strPara(2) = txtSumOfTotal.Text
                B_ReportViewer.strPara(3) = txtSumOfTime.Text
                B_ReportViewer.Show()
        End Select
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
            txtSumOfTotal.Text = ""
            txtSumOfTime.Text = ""
        End If
    End Sub
End Class