Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class publicFunction
    Public ksDBConn As SqlConnection
    Public ksParameter(10) As String    '0:SQL Server IP, 1:資料庫名稱, 2:機台代碼, 3:登入帳號

    Public Sub ConnDB()

        ksDBConn = New SqlConnection("user id=" & ksParameter(4) & ";password=" & ksParameter(5) & ";initial catalog=" & ksParameter(1) & ";data source=" & ksParameter(0) & ";connect timeout = 10")
        ksDBConn.Open()

    End Sub

    Public Sub getParameters()
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ks.dat")
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim i As Integer = 0
                    For Each currentField In currentRow
                        ksParameter(i) = currentField
                        i += 1
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("讀取系統參數錯誤! (錯誤訊息: " & ex.Message & ")")
                End Try
            End While
        End Using

    End Sub

    Public Function encyPwd(ByVal oPWD As String) As String
        Dim ePWD As String = ""

        For i As Integer = 1 To Len(oPWD)
            ePWD = ePWD & Chr(Asc(Mid(oPWD, i, 1)) + 7 + i)
        Next

        Return ePWD
    End Function

End Class
