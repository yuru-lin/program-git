Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class 列印Print
    'Public Class PrintRpt
    Implements IDisposable
    'Dim TYPE As Integer
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Public dt As DataTable
    Public printerName As String
    Public strPara(50) As String
    Public TYPE As String

    Public StartupPath As String
    Public 高 As String

    Public Sub Run()

        Dim report As LocalReport = New LocalReport()
        'report.ReportPath = "c:\vispark\Report1.rdlc"
        'report.ReportPath = (Application.StartupPath & "\報表\Report1.rdlc")
        'report.ReportPath = (Application.StartupPath & "\1.人事作業\出勤管理\手工計薪\手工計薪.rdlc")
        report.ReportPath = (Application.StartupPath & StartupPath)
        report.DataSources.Add(New ReportDataSource("DataSet1_DataTable1", dt))

        Dim parass(15) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))
        parass(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strPara(2))
        parass(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strPara(3))
        parass(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strPara(4))
        parass(5) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_5", strPara(5))
        parass(6) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_6", strPara(6))
        parass(7) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_7", strPara(7))
        parass(8) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_8", strPara(8))
        parass(9) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_9", strPara(9))
        parass(10) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_10", strPara(10))
        parass(11) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_11", strPara(11))
        parass(12) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_12", strPara(12))
        parass(13) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_13", strPara(13))
        parass(14) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_14", strPara(14))
        parass(15) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_15", strPara(15))


        report.SetParameters(parass)

        Export(report)

        m_currentPageIndex = 0
        Print()
    End Sub

    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = ""

        '中一刀2()    22.86cm,13.97cm

        If TYPE = "1" Then '直式列印    '高29.7
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>23cm</PageWidth>" + _
              "  <PageHeight>" & 高 & "</PageHeight>" + _
              "  <MarginTop>1cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>0.2cm</MarginBottom>" + _
              "</DeviceInfo>"
        ElseIf TYPE = "2" Then '橫式列印
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>29.7cm</PageWidth>" + _
              "  <PageHeight>23cm</PageHeight>" + _
              "  <MarginTop>1cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>0.2cm</MarginBottom>" + _
              "</DeviceInfo>"
        ElseIf TYPE = "3" Then '直式列印    '高14
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>23cm</PageWidth>" + _
              "  <PageHeight>" & 高 & "</PageHeight>" + _
              "  <MarginTop>0.5cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>0.2cm</MarginBottom>" + _
              "</DeviceInfo>"
        ElseIf TYPE = "4" Then '直式列印A4  高29.7
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>21.00cm</PageWidth>" + _
              "  <PageHeight>" & 高 & "</PageHeight>" + _
              "  <MarginTop>0.5cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>0.5cm</MarginBottom>" + _
              "</DeviceInfo>"
        ElseIf TYPE = "5" Then '橫式列印A5  高21.00
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>14.8cm</PageWidth>" + _
              "  <PageHeight>" & 高 & "</PageHeight>" + _
              "  <MarginTop>0.5cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>0.5cm</MarginBottom>" + _
              "</DeviceInfo>"
        End If

        Dim warnings() As Warning = Nothing
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As Stream
        For Each stream In m_streams
            stream.Position = 0
        Next

        '寬度   Width
        '高度   Height
        '頂     Top
        '左     Left
        '右     Right
        '底部   Bottom

    End Sub

    Private Sub Print()
        'Const printerName As String = "Microsoft Office Document Image Writer"

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New PrintDocument()
        If TYPE = "1" Or TYPE = "3" Or TYPE = "4" Then 'A4直式列印
            printDoc.DefaultPageSettings.Landscape = False '直式列印
        ElseIf TYPE = "2" Or TYPE = "5" Then 'A4橫式列印
            printDoc.DefaultPageSettings.Landscape = True '橫式列印
        End If

        printDoc.PrinterSettings.PrinterName = printerName

        If Not printDoc.PrinterSettings.IsValid Then
            Dim msg As String = String.Format( _
                "Can't find printer ""{0}"".", printerName)
            'Console.WriteLine(msg)
            MsgBox("沒有安裝印表機!", MsgBoxStyle.OkOnly, "列印錯誤")
            Return
        End If
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        printDoc.Print()
    End Sub

    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
        'ev.Graphics.DrawImage(pageImage, ev.PageBounds)
        ev.Graphics.DrawImage(pageImage, 0, 0, CInt(pageImage.Width * 1.04), CInt(pageImage.Height * 1.04))

        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
    End Sub

    Private Function CreateStream(ByVal name As String, _
   ByVal fileNameExtension As String, _
   ByVal encoding As System.Text.Encoding, ByVal mimeType As String, _
   ByVal willSeek As Boolean) As Stream

        'Dim stream As Stream = New FileStream(Application.StartupPath & "\1.人事作業\出勤管理\手工計薪\" + name + "." + fileNameExtension, FileMode.Create)
        'Dim stream As Stream = New FileStream(Application.StartupPath & "%TEMP%" + name + "." + fileNameExtension, FileMode.Create)
        Dim stream As Stream = New FileStream(Environ("TEMP") & "\" & name & "." & fileNameExtension, FileMode.Create)
        'Path.GetTempPath()
        m_streams.Add(stream)
        Return stream
    End Function



    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        If Not (m_streams Is Nothing) Then
            Dim stream As Stream
            For Each stream In m_streams
                stream.Close()
            Next
            m_streams = Nothing
        End If
    End Sub
End Class
