Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class E_ReportViewer
    Public dt, dt1, dt2, dt3, dt4, dt5 As DataTable
    Public strPara(50) As String
    Public intPara(50) As Integer
    Public Source As String

    Private Sub E_ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case Source
            Case "PaymentForm"
                rvPaymentType1.Visible = True
                PaymentForm()

        End Select

    End Sub

    Private Sub PaymentForm()


        Dim paras(4) As Microsoft.Reporting.WinForms.ReportParameter
        paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        paras(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))

        Me.rvPaymentType1.LocalReport.SetParameters(paras)
        Me.rvPaymentType1.LocalReport.DataSources(0).Value = dt1
        Me.rvPaymentType1.LocalReport.DataSources(1).Value = dt2
        Me.rvPaymentType1.LocalReport.DataSources(2).Value = dt3
        Me.rvPaymentType1.RefreshReport()

    End Sub

    Private Sub dtPayment1BindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class