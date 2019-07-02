Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class Z_ReportViewer
    Public dt As DataTable
    Public strPara(50) As String
    Public intPara(50) As Integer
    Public Source As String
    Public CardName As String '客戶名稱

    Private Sub Z_ReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        Select Case Source
            Case "StockApply" : rvStockApply.Visible = True : StockApply()
            Case "Welfare" : rvWelfare.Visible = True : Welfare()
            Case "加工原料肉領料單" : rv加工原料肉領料單.Visible = True : 加工原料肉領料單()
            Case "冷藏貨庫存表" : rv冷藏貨庫存表.Visible = True : 冷藏貨庫存表()

                'Case Else
        End Select

    End Sub

    Private Sub StockApply()

        Dim parass(2) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        parass(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))

        Me.rvStockApply.LocalReport.SetParameters(parass)
        Me.rvStockApply.LocalReport.DataSources(0).Value = dt

        Me.rvStockApply.RefreshReport()


    End Sub


    Private Sub Welfare()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))


        Me.rvWelfare.LocalReport.SetParameters(parass)
        Me.rvWelfare.LocalReport.DataSources(0).Value = dt

        Me.rvWelfare.RefreshReport()


    End Sub

    Private Sub 加工原料肉領料單()

        Dim parass(4) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        parass(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        parass(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        parass(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))


        Me.rv加工原料肉領料單.LocalReport.SetParameters(parass)
        Me.rv加工原料肉領料單.LocalReport.DataSources(0).Value = dt

        Me.rv加工原料肉領料單.RefreshReport()


    End Sub

    Private Sub 冷藏貨庫存表()

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))


        Me.rv冷藏貨庫存表.LocalReport.SetParameters(parass)
        Me.rv冷藏貨庫存表.LocalReport.DataSources(0).Value = dt

        Me.rv冷藏貨庫存表.RefreshReport()


    End Sub
End Class