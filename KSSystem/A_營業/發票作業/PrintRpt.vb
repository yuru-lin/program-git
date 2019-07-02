Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.IO.Stream

Public Class 發票列印PrintRpt
    'Public Class PrintRpt
    Implements IDisposable

    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Public dt As DataTable
    Public printerName As String
    Public strPara(50) As String

    Public Sub Run()

        Dim report As LocalReport = New LocalReport()
        'report.ReportPath = "c:\vispark\Report1.rdlc"
        'report.ReportPath = (Application.StartupPath & "\報表\Report1.rdlc")
        report.ReportPath = (Application.StartupPath & "\A_營業\發票作業\發票列印.rdlc")
        report.DataSources.Add(New ReportDataSource("DataSet1_DataTable1", dt))

        Dim parass(0) As Microsoft.Reporting.WinForms.ReportParameter
        parass(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strPara(0))

        report.SetParameters(parass)

        Export(report)

        m_currentPageIndex = 0
        Print()
    End Sub

    Private Sub Export(ByVal report As LocalReport)
        Dim deviceInfo As String = _
          "<DeviceInfo>" + _
          "  <OutputFormat>EMF</OutputFormat>" + _
          "  <PageWidth>23cm</PageWidth>" + _
          "  <PageHeight>28cm</PageHeight>" + _
          "  <MarginTop>1cm</MarginTop>" + _
          "  <MarginLeft>1cm</MarginLeft>" + _
          "  <MarginRight>0.2cm</MarginRight>" + _
          "  <MarginBottom>0.2cm</MarginBottom>" + _
          "</DeviceInfo>"
        Dim warnings() As Warning = Nothing
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)

        Dim stream As Stream
        For Each stream In m_streams
            stream.Position = 0
        Next
    End Sub

    Private Sub Print()
        'Const printerName As String = "Microsoft Office Document Image Writer"

        If m_streams Is Nothing Or m_streams.Count = 0 Then
            Return
        End If

        Dim printDoc As New PrintDocument()
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

        Dim stream As Stream = New FileStream(Application.StartupPath & "\A_營業\發票作業\" + name + "." + fileNameExtension, FileMode.Create)
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
