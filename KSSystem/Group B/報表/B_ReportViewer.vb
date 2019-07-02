Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class B_ReportViewer
    Public dt, dt1, dt2 As DataTable
    Public strPara(50) As String
    Public intPara(50) As Integer
    Public Source As String

    Private Sub viewReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case Source
            Case "Throughput" : rvThroghput.Visible = True : Throughput()
            Case "Melts" : rvMelts.Visible = True : Melts()
            Case "Feeding" : rvFeeding.Visible = True : Feeding()
            Case "Transport" : rvTransport.Visible = True : Transport()
            Case "OrderPicking" : rvOrderPicking.Visible = True : OrderPicking()
            Case "SPicking1" : rvSPicking1.Visible = True : SPicking1()
            Case "SPicking2" : rvSPicking2.Visible = True : SPicking2()
            Case "SPicking3" : rvSPicking3.Visible = True : SPicking3()
            Case "SPicking4" : rvSPicking4.Visible = True : SPicking4()
            Case "SPicking5" : rvSPicking5.Visible = True : SPicking5()
            Case "SPicking6" : rvSPicking6.Visible = True : SPicking6()
            Case "SPicking7" : rvSPicking7.Visible = True : SPicking7()
            Case "SPicking8" : rvSPicking8.Visible = True : SPicking8()
            Case "SPicking9" : rvSPicking9.Visible = True : SPicking9()
            Case "Dispatching" : rvDispatching.Visible = True : Dispatching()
        End Select

        'Me.rvOrderPicking.RefreshReport()
    End Sub

    Private Sub Throughput()

        '定義兩個參數(陣列形式 0-1)
        Dim paras(22) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        paras(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))
        paras(5) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_5", strPara(5))
        paras(6) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_6", strPara(6))
        paras(7) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_7", strPara(7))
        paras(8) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_8", strPara(8))
        paras(9) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_9", strPara(9))
        paras(10) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_10", strPara(10))
        paras(11) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_11", strPara(11))
        paras(12) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_12", strPara(12))
        paras(13) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_13", strPara(13))
        paras(14) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_14", strPara(14))
        paras(15) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_15", strPara(15))
        paras(16) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_16", strPara(16))
        paras(17) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_17", strPara(17))
        paras(18) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_18", strPara(18))
        paras(19) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_19", strPara(19))
        paras(20) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_20", strPara(20))
        paras(21) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_21", strPara(21))
        paras(22) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_22", strPara(22))

        '透過SetParemeters將參數填入報表中

        Me.rvThroghput.LocalReport.SetParameters(paras)
        Me.rvThroghput.LocalReport.DataSources(0).Value = dt
        Me.rvThroghput.RefreshReport()
    End Sub

    Private Sub Melts()

        Dim AAS, AAD As String
        AAS = strPara(0)
        AAD = strPara(1)
        MsgBox(AAS)
        MsgBox(AAD)


        Dim paras(3) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))

        Me.rvMelts.LocalReport.SetParameters(paras)
        Me.rvMelts.LocalReport.DataSources(0).Value = dt
        Me.rvMelts.RefreshReport()
    End Sub

    Private Sub Feeding()

        Dim paras(3) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))

        Me.rvFeeding.LocalReport.SetParameters(paras)
        Me.rvFeeding.LocalReport.DataSources(1).Value = dt
        Me.rvFeeding.RefreshReport()
    End Sub

    Private Sub Transport()

        Dim paras(0) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))

        Me.rvTransport.LocalReport.SetParameters(paras)
        Me.rvTransport.LocalReport.DataSources(0).Value = dt
        Me.rvTransport.RefreshReport()
    End Sub

    Private Sub OrderPicking()

        Dim parass(5) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        parass(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        parass(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        parass(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))
        parass(5) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_5", strPara(5))


        Me.rvOrderPicking.LocalReport.SetParameters(parass)
        Me.rvOrderPicking.LocalReport.DataSources(0).Value = dt1
        Me.rvOrderPicking.LocalReport.DataSources(1).Value = dt2
        Me.rvOrderPicking.RefreshReport()


    End Sub

    Private Sub SPicking1()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking1.LocalReport.SetParameters(parass)
        Me.rvSPicking1.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking1.RefreshReport()

    End Sub

    Private Sub SPicking2()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking2.LocalReport.SetParameters(parass)
        Me.rvSPicking2.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking2.RefreshReport()

    End Sub

    Private Sub SPicking3()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking3.LocalReport.SetParameters(parass)
        Me.rvSPicking3.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking3.RefreshReport()

    End Sub

    Private Sub SPicking4()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking4.LocalReport.SetParameters(parass)
        Me.rvSPicking4.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking4.RefreshReport()

    End Sub

    Private Sub SPicking5()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking5.LocalReport.SetParameters(parass)
        Me.rvSPicking5.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking5.RefreshReport()

    End Sub

    Private Sub SPicking6()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking6.LocalReport.SetParameters(parass)
        Me.rvSPicking6.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking6.RefreshReport()

    End Sub

    Private Sub SPicking7()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking7.LocalReport.SetParameters(parass)
        Me.rvSPicking7.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking7.RefreshReport()

    End Sub

    Private Sub SPicking8()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking8.LocalReport.SetParameters(parass)
        Me.rvSPicking8.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking8.RefreshReport()

    End Sub

    Private Sub SPicking9()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        Me.rvSPicking9.LocalReport.SetParameters(parass)
        Me.rvSPicking9.LocalReport.DataSources(0).Value = dt
        Me.rvSPicking9.RefreshReport()

    End Sub

    Private Sub Dispatching()

        Dim parass(4) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        parass(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        parass(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        parass(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))

        'Me.rvDispatching..Width.ToString("21.59")
        'Me.rvDispatching.Height.ToString("13.97")
        'Me.rvDispatching.

        'Me.pdDispatching.PageSettings.PaperSize.Width.ToString()
        'Me.pdDispatching.PageSettings.PaperSize.Height.ToString()

        Me.rvDispatching.LocalReport.SetParameters(parass)
        Me.rvDispatching.LocalReport.DataSources(0).Value = dt
        Me.rvDispatching.RefreshReport()

    End Sub




End Class