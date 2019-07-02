Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Text
Imports System.Drawing
Public Class AutoPrint
#Region "報表列印相關"
    Public Sub Export(ByVal report As LocalReport)
        Dim deviceInfo = "<DeviceInfo>" & _
            "<OutputFormat>EMF</OutputFormat>" & _
            "<PageWidth>8.3in</PageWidth>" & _
            "<PageHeight>11.7in</PageHeight>" & _
            "<MarginTop>0.25in</MarginTop>" & _
            "<MarginLeft>0.25in</MarginLeft>" & _
            "<MarginRight>0.25in</MarginRight>" & _
            "<MarginBottom>0.25in</MarginBottom>" & _
            "</DeviceInfo>"
        Dim warnings As Warning() = Nothing
        m_streams = New List(Of Stream)()
        report.Render("Image", deviceInfo, AddressOf CreateStream, warnings)
        For Each stream As Stream In m_streams
            stream.Position = 0
        Next
    End Sub
    Private Function CreateStream(ByVal name As String, ByVal fileNameExtension As String, ByVal encoding As System.Text.Encoding, ByVal mimeType As String, ByVal willSeek As Boolean) As Stream
        Dim stream As Stream = New MemoryStream()
        m_streams.Add(stream)
        Return stream
    End Function
    Private m_currentPageIndex As Integer
    Private m_streams As IList(Of Stream)
    Private Sub PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
        Dim adjustedRect As New Rectangle(ev.PageBounds.Left - CInt(ev.PageSettings.HardMarginX), _
                                          ev.PageBounds.Top - CInt(ev.PageSettings.HardMarginY), _
                                          ev.PageBounds.Width, _
                                          ev.PageBounds.Height)
        ev.Graphics.FillRectangle(Brushes.White, adjustedRect)
        ev.Graphics.DrawImage(pageImage, adjustedRect)
        m_currentPageIndex += 1
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count)
        ev.HasMorePages = False
    End Sub

    Public Sub Print()

        If m_streams Is Nothing OrElse m_streams.Count = 0 Then
            Throw New Exception("Error: no stream to print.")
        End If
        Dim printDoc As New PrintDocument()
        If Not printDoc.PrinterSettings.IsValid Then
            Throw New Exception("Error: cannot find the default printer.")
        Else
            AddHandler printDoc.PrintPage, AddressOf PrintPage
            m_currentPageIndex = 0
            ' printDoc.PrinterSettings.PrinterName = "TSC TTP/TDP-243(E)"
            printDoc.Print()
        End If

    End Sub
#End Region
End Class
