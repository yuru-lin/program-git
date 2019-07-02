Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class 產程明細列印Print

    'Public Class PrintRpt
    Implements IDisposable
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Public dt As DataTable
    Public printerName As String
    Public strPara(50) As String
    Public TYPE As String
    Public 紙張 As String
    Public StartupPath As String

    Public Sub Run()

        Dim report As LocalReport = New LocalReport()
        'report.ReportPath = "c:\vispark\Report1.rdlc"
        'report.ReportPath = (Application.StartupPath & "\報表\Report1.rdlc")
        'report.ReportPath = (Application.StartupPath & "\1.人事作業\出勤管理\手工計薪\手工計薪.rdlc")
        report.ReportPath = (Application.StartupPath & StartupPath)
        report.DataSources.Add(New ReportDataSource("DataSet1_DataTable1", dt))

        Dim parass(1) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))
        parass(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strPara(1))

        report.SetParameters(parass)

        Export(report)

        m_currentPageIndex = 0
        Print()

    End Sub

    Private Sub Export(ByVal report As LocalReport)

        Dim deviceInfo As String = ""
        Dim Width As String = ""
        Dim Height As String = ""

        Select Case 紙張
            Case "Letter" : Width = "23cm" : Height = "28cm"
            Case "A4" : Width = "21cm" : Height = "29.7cm"
            Case Else
        End Select

        If TYPE = "1" Then 'A4直式列印
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>" & Width & "</PageWidth>" + _
              "  <PageHeight>" & Height & "</PageHeight>" + _
              "  <MarginTop>0.5cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>1cm</MarginBottom>" + _
              "</DeviceInfo>"
        ElseIf TYPE = "2" Then 'A4橫式列印
            deviceInfo = _
              "<DeviceInfo>" + _
              "  <OutputFormat>EMF</OutputFormat>" + _
              "  <PageWidth>" & Height & "</PageWidth>" + _
              "  <PageHeight>" & Width & "</PageHeight>" + _
              "  <MarginTop>0.5cm</MarginTop>" + _
              "  <MarginLeft>0.5cm</MarginLeft>" + _
              "  <MarginRight>0.5cm</MarginRight>" + _
              "  <MarginBottom>1cm</MarginBottom>" + _
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
        If TYPE = "1" Then '直式列印
            printDoc.DefaultPageSettings.Landscape = False '直式列印
        ElseIf TYPE = "2" Then '橫式列印
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
