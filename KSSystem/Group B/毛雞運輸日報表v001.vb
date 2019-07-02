Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 毛雞運輸日報表v001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_QueryTransportation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvTransport.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvTransportDetail.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvByM03.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvTransportALL.ContextMenuStrip = MainForm.ContextMenuStrip1
        dateDocDate.Value = dateDocDate.Value.Date.AddDays(1)
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        QueryTransport()
        QueryTransportAll()
        QueryByM03()
    End Sub

    Private Sub QueryTransport()
        If dgvTransport.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
        If dgvTransportDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter

        sql = "SELECT [CarEntry] as '單號',[DocDate] as '日期',[CarIDNumber] as '車牌號',[MeasuredByKS] as '公司會磅',[TotalWeight] as '車次磅單總重',[WeightDiff] as '磅差' FROM [@Transportation] Where [DocDate] = '" & dateDocDate.Value.Date & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        dgvTransport.DataSource = ks1DataSetDGV.Tables("DT1")
        dgvTransport.AutoResizeColumns()

    End Sub

    Private Sub dgvTransport_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransport.CellClick
        If dgvTransportDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter

        sql = "SELECT [LineNum] as '列號',[SourceFrom] as '來源',[FarmName] as '牧場名稱',[FarmID] as '牧場代號',[CarOrder] as '順序',[TypeName] as '品名',[TypeSpecial] as '特殊',[PreCntNumber] as '預抓羽數',[CatchCntNumber] as '磅單羽數',[RealCntNumber] as '實際羽數',[CntDiff] as '羽數差異',[PackNumber] as '包裝數',[DeathNumber] as '死亡數',[DeathWeight] as '死亡重',[DropNumber] as '廢棄數',[DropWeight] as '廢棄重',[RainPercent] as '含水%數',[RainWeight] as '含水重',[U_M03] as '製造單號',[AvgWeight] as '平均重',[RealAvgWeight] as '實際平均重',[MeasuredWeight] as '磅單重',[TotalRealWeight] as '實際總重',[RealWeightDiff] as '重量差異',[Comments] as '備註' FROM [@Transportation1] Where [DocDate] = '" & dateDocDate.Value.Date & "' and [CarEntry] = '" & dgvTransport.CurrentRow.Cells("單號").Value & "' and [Cancel] = 'N'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")

        dgvTransportDetail.DataSource = ks1DataSetDGV.Tables("DT2")
        dgvTransportDetail.AutoResizeColumns()
    End Sub

    Private Sub QueryByM03()
        If dgvByM03.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter


        sql = "SELECT T1.[U_M03] as '製造單號',sum(T0.MeasuredByKS) as '公司會磅',SUM(T1.[PreCntNumber]) as '預抓羽數',SUM(T1.[CatchCntNumber]) as '磅單羽數',SUM(T1.[RealCntNumber]) as '實際羽數',SUM(T1.[PackNumber]) as '包裝數',SUM(T1.[CntDiff]) as '羽數差異',SUM(T1.[DeathNumber]) as '死亡數',SUM(T1.[DeathWeight]) as '死亡重',SUM(T1.[DropNumber]) as '廢棄數',SUM(T1.[DropWeight]) as '廢棄重',SUM(T1.[RainWeight]) as '含水重',SUM(T1.[MeasuredWeight]) as '磅單重',SUM(T1.[TotalRealWeight]) as '實際總重',SUM(T1.[RealWeightDiff]) as '重量差異' FROM [@Transportation] T0 inner join [@Transportation1] T1 ON T0.CarEntry = T1.CarEntry Where T0.[DocDate] = '" & dateDocDate.Value.Date & "' and T1.[Cancel] = 'N' Group By T1.[U_M03]"
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")

        dgvByM03.DataSource = ks1DataSetDGV.Tables("DT3")
        dgvByM03.AutoResizeColumns()

    End Sub

    Private Sub QueryTransportAll()
        If dgvTransportALL.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT4").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter

        sql = "Select '' as '列',T0.[DocDate] as '日期',T0.[CarEntry] as '單號',T1.[CarOrder] as '順序',T1.[FarmName] as '牧場名稱',T1.[FarmID] as '牧場代號',T1.[RealAvgWeight] as '實際平均重',T1.[AvgWeight] as '平均重',T1.[SourceFrom] as '來源',T1.[TypeName] as '品名',T1.[TypeSpecial] as '特殊',T1.[PreCntNumber] as '預抓羽數',T1.[CatchCntNumber] as '磅單羽數',T1.[PackNumber] as '包裝數',T1.[DeathNumber] as '死亡數',T1.[DropNumber] as '廢棄數',T1.[U_M03] as '製造單號',T0.[CarIDNumber] as '車牌號',T0.[MeasuredByKS] as '公司會磅',T1.[MeasuredWeight] as '磅單重',T0.[WeightDiff] as '磅差',T1.[Comments] as '備註' From [@Transportation] T0 inner join [@Transportation1] T1 ON T0.CarEntry = T1.CarEntry Where T0.[DocDate] = '" & dateDocDate.Value.Date & "' and T1.[Cancel] = 'N' Order By T1.[CarOrder] , T1.[U_M03] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT4")

        dgvTransportALL.DataSource = ks1DataSetDGV.Tables("DT4")
        dgvTransportALL.AutoResizeColumns()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If dgvTransportALL.RowCount <= 0 Then
            MsgBox("無資料可列印!", 16, "錯誤")
            Exit Sub
        End If

        ks1DataSetDGV.Tables("DT4").DefaultView.Sort = "列 asc"
        Dim myDatatable2 As New DataTable
        myDatatable2 = ks1DataSetDGV.Tables("DT4").DefaultView.ToTable()

        B_ReportViewer.MdiParent = MainForm
        B_ReportViewer.Source = "Transport"
        'B_ReportViewer.dt = ks1DataSetDGV.Tables("DT4").DefaultView.ToTable()
        B_ReportViewer.dt = myDatatable2
        B_ReportViewer.strPara(0) = txtComment.Text
        B_ReportViewer.Show()
    End Sub

    Private Sub dgvByM03_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvByM03.CellClick
        If dgvByM03.RowCount <= 0 Then
            Exit Sub
        End If

        Dim result As Integer = chkM03(dgvByM03.CurrentRow.Cells("製造單號").Value)
        If result = 0 Then
            MsgBox("查不到該製造單號!", 16, "錯誤")
            Exit Sub
        ElseIf result = 2 Then
            MsgBox("該製造單號有複數!", 16, "錯誤")
            Exit Sub
        End If

        lbDocNum.Text = result
        lbM03.Text = dgvByM03.CurrentRow.Cells("製造單號").Value
        txtM7.Text = dgvByM03.CurrentRow.Cells("磅單重").FormattedValue
        txtM8.Text = dgvByM03.CurrentRow.Cells("死亡數").FormattedValue
        txtM9.Text = dgvByM03.CurrentRow.Cells("廢棄數").FormattedValue
        txtM10.Text = dgvByM03.CurrentRow.Cells("公司會磅").FormattedValue
        txtM12.Text = dgvByM03.CurrentRow.Cells("磅單羽數").FormattedValue
        'txtPlannedQty.Text = dgvByM03.CurrentRow.Cells("磅單羽數").FormattedValue - dgvByM03.CurrentRow.Cells("死亡數").FormattedValue - dgvByM03.CurrentRow.Cells("廢棄數").FormattedValue
        txtPlannedQty.Text = dgvByM03.CurrentRow.Cells("磅單羽數").FormattedValue

    End Sub

    Private Function chkM03(ByVal M03 As String)
        Dim AnsReturn As Integer
        '0 = 找不到
        '1 = 找到一個
        '2 = 找到多個

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "Select T0.[DocNum],T0.[U_M03] From OWOR T0 Where T0.[U_M03] = '" & M03 & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader

        If sqlReader.HasRows() Then
            Dim i As Integer = 0
            While sqlReader.Read()
                i += 1
                AnsReturn = sqlReader.Item("DocNum")
            End While

            If i > 1 Then
                AnsReturn = 2
            End If

        Else
            AnsReturn = 0
        End If

        sqlReader.Close()

        Return AnsReturn
    End Function

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If dgvByM03.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If lbM03.Text = "" Then
            MsgBox("資料未選!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要更新至SAP B1 ?" & vbCrLf & "單號：" & lbDocNum.Text + vbCrLf & "製單：" & lbM03.Text, 36, "更新")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oProductionOrders As SAPbobsCOM.ProductionOrders
        Dim RetVal As Long

        oProductionOrders = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders)

        oProductionOrders.GetByKey(lbDocNum.Text)
        oProductionOrders.UserFields.Fields.Item("U_M07").Value = txtM7.Text
        oProductionOrders.UserFields.Fields.Item("U_M08").Value = txtM8.Text
        oProductionOrders.UserFields.Fields.Item("U_M09").Value = txtM9.Text
        oProductionOrders.UserFields.Fields.Item("U_M10").Value = txtM10.Text
        oProductionOrders.UserFields.Fields.Item("U_M12").Value = txtM12.Text
        oProductionOrders.PlannedQuantity = txtPlannedQty.Text

        RetVal = oProductionOrders.Update()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("更新至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        MsgBox("更新至B1完成!!" & vbCrLf & "單號：" & lbDocNum.Text, 64, "完成")

        ClearAll()

    End Sub

    Private Sub ClearAll()

        lbDocNum.Text = ""
        lbM03.Text = ""
        txtM7.Text = ""
        txtM8.Text = ""
        txtM9.Text = ""
        txtM10.Text = ""
        txtM12.Text = ""
        txtPlannedQty.Text = ""

    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(dgvByM03, "")
    End Sub
End Class