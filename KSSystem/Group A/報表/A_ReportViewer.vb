Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class A_ReportViewer
    Public dt, dt1, dt2, dt3, dt4, dt5 As DataTable
    Public strPara(50) As String
    Public intPara(50) As Integer
    Public Source As String

    Private Sub A_ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case Source
            Case "OutDetail"
                rvOutDetail.Visible = True
                OutDetail()
            Case "OutStatistic"
                rvOutStatistic.Visible = True
                OutStatistic()
            Case "InDetail"
                rvInDetail.Visible = True
                InDetail()
            Case "InStatistic"
                rvInStatistic.Visible = True
                InStatistic()
            Case "AdjustDetail"
                rvAdjustDetail.Visible = True
                AdjustDetail()
            Case "AdjustStatistic"
                rvAdjustStatistic.Visible = True
                AdjustStatistic()
            Case "CarDrDetail"
                rvCarDrDetail.Visible = True
                CarDrDetail()
            Case "CarDrStatistic"
                rvCarDrStatistic.Visible = True
                CarDrStatistic()
            Case "EBStatistic"
                rvEBStatistic.Visible = True
                EBStatistic()
            Case "EBStatement"
                rvEBStatement.Visible = True
                EBStatement()
            Case "ContractSettlement"
                rvContractSettlement.Visible = True
                ContractSettlement()
            Case "EC" 'EC檢貨單
                rvEC.Visible = True
                EC()
            Case "EC_Get" 'EC提貨單
                rvEC_Get.Visible = True
                EC_Get()
            Case "EC_Order" 'EC出貨單
                rvECOrder.Visible = True
                ECOrder()
            Case "EC_Delivery" 'EC宅配單
                rvEC_Delivery.Visible = True
                EC_Delivery()

        End Select

    End Sub

    Private Sub OutDetail()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvOutDetail.LocalReport.SetParameters(paras)
        Me.rvOutDetail.LocalReport.DataSources(0).Value = dt
        Me.rvOutDetail.RefreshReport()
    End Sub

    Private Sub OutStatistic()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvOutStatistic.LocalReport.SetParameters(paras)
        Me.rvOutStatistic.LocalReport.DataSources(0).Value = dt
        Me.rvOutStatistic.RefreshReport()
    End Sub

    Private Sub InDetail()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvInDetail.LocalReport.SetParameters(paras)
        Me.rvInDetail.LocalReport.DataSources(0).Value = dt
        Me.rvInDetail.RefreshReport()
    End Sub

    Private Sub InStatistic()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvInStatistic.LocalReport.SetParameters(paras)
        Me.rvInStatistic.LocalReport.DataSources(0).Value = dt
        Me.rvInStatistic.RefreshReport()
    End Sub

    Private Sub AdjustDetail()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvAdjustDetail.LocalReport.SetParameters(paras)
        Me.rvAdjustDetail.LocalReport.DataSources(0).Value = dt
        Me.rvAdjustDetail.RefreshReport()
    End Sub

    Private Sub AdjustStatistic()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvAdjustStatistic.LocalReport.SetParameters(paras)
        Me.rvAdjustStatistic.LocalReport.DataSources(0).Value = dt
        Me.rvAdjustStatistic.RefreshReport()
    End Sub

    Private Sub CarDrDetail()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvCarDrDetail.LocalReport.SetParameters(paras)
        Me.rvCarDrDetail.LocalReport.DataSources(0).Value = dt
        Me.rvCarDrDetail.RefreshReport()
    End Sub

    Private Sub CarDrStatistic()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvCarDrStatistic.LocalReport.SetParameters(paras)
        Me.rvCarDrStatistic.LocalReport.DataSources(0).Value = dt
        Me.rvCarDrStatistic.RefreshReport()
    End Sub

    Private Sub EBStatistic()               
        Me.rvEBStatistic.LocalReport.DataSources(0).Value = dt
        Me.rvEBStatistic.RefreshReport()
    End Sub

    Private Sub EBStatement()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvEBStatement.LocalReport.SetParameters(paras)
        Me.rvEBStatement.LocalReport.DataSources(0).Value = dt
        Me.rvEBStatement.RefreshReport()
    End Sub

    Private Sub ContractSettlement()
        Dim paras(1) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        Me.rvContractSettlement.LocalReport.SetParameters(paras)
        Me.rvContractSettlement.LocalReport.DataSources(0).Value = dt1
        Me.rvContractSettlement.LocalReport.DataSources(1).Value = dt2
        Me.rvContractSettlement.LocalReport.DataSources(2).Value = dt3
        Me.rvContractSettlement.LocalReport.DataSources(3).Value = dt4
        Me.rvContractSettlement.LocalReport.DataSources(4).Value = dt5
        Me.rvContractSettlement.RefreshReport()
    End Sub

    Private Sub EC()
        Dim paras(2) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        Me.rvEC.LocalReport.SetParameters(paras)
        Me.rvEC.LocalReport.DataSources(0).Value = dt
        Me.rvEC.RefreshReport()
    End Sub

    Private Sub ECOrder()
        Dim paras(4) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        paras(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))
        Me.rvECOrder.LocalReport.SetParameters(paras)
        Me.rvECOrder.LocalReport.DataSources(0).Value = dt
        Me.rvECOrder.RefreshReport()
    End Sub

    Private Sub EC_Get()
        Dim paras(3) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        Me.rvEC_Get.LocalReport.SetParameters(paras)
        Me.rvEC_Get.LocalReport.DataSources(0).Value = dt
        Me.rvEC_Get.RefreshReport()
    End Sub

    Private Sub EC_Delivery()
        Dim paras(4) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        paras(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))
        Me.rvEC_Delivery.LocalReport.SetParameters(paras)
        Me.rvEC_Delivery.RefreshReport()

    End Sub
End Class