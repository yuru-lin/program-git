Imports System.IO
Imports System.Net
Imports System.Diagnostics

Public Module AutoUpdate
    Private m_RemotePath As String = "\\ad7\共享目錄\KSSystem\"
    Private m_UpdateFileName As String = "Update.txt"
    Private m_ErrorMessage As String = "自動更新錯誤!!"

    ' <File Name>;<Version>   [' comments    ]
    ' <File Name>[;<Version>] [' comments    ]  
    ' <File Name>[;?]         [' comments    ]
    ' <File Name>[;delete]    [' comments    ]
    ' ...
    ' Blank lines and comments are ignored
    ' The first line should be the current program/version
    ' from the second line to the end the second parameter is optional
    ' if the second parameter is not specified the file is updated.
    ' if the version is specified the update checks the version
    ' if the second parameter is an interrogation mark (?) the update checks if the 
    ' file alredy exists and "don't" upgrade if exists.
    ' if the second parameter is "delete" the system try to delete the file
    ' "'" (chr(39)) start a line comment (like vb)

    ' Function Return Value
    ' True means that the program needs to exit because: the autoupdate did the update
    ' or there was an error during the update
    ' False - nothing was done

    Public Function chkFiles(Optional ByVal RemotePath As String = "") As Boolean
        If RemotePath = "" Then RemotePath = m_RemotePath Else m_RemotePath = RemotePath
        Dim Ret As Boolean = False
        Dim AssemblyName As String = System.Reflection.Assembly.GetEntryAssembly.GetName.Name
        Dim RemoteUri As String = RemotePath & AssemblyName & "/"
        Dim MyWebClient As New WebClient
        Try

            Dim Contents As String = MyWebClient.DownloadString(RemoteUri & UpdateFileName)
            Contents = Replace(Contents, Chr(Keys.LineFeed), "")
            Dim FileList() As String = Split(Contents, Chr(Keys.Return))
            Contents = ""

            For Each F As String In FileList
                If InStr(F, "'") <> 0 Then F = Strings.Left(F, InStr(F, "'") - 1)
                If F.Trim <> "" Then
                    If Contents <> "" Then Contents += Chr(Keys.Return)
                    Contents += F.Trim
                End If
            Next

            FileList = Split(Contents, Chr(Keys.Return))
            Dim Info() As String = Split(FileList(0), ";")

            If Application.StartupPath.ToLower & "\" & Info(0).ToLower = Application.ExecutablePath.ToLower AndAlso _
               GetVersion(Info(1)) > GetVersion(Application.ProductVersion) Then
                Ret = True
            End If

        Catch ex As Exception
            Ret = False
        End Try
        'Ret = True
        Return Ret
    End Function


    Public Function UpdateFiles(Optional ByVal RemotePath As String = "") As Boolean
        If RemotePath = "" Then RemotePath = m_RemotePath Else m_RemotePath = RemotePath

        Dim Ret As Boolean = False
        Dim AssemblyName As String = System.Reflection.Assembly.GetEntryAssembly.GetName.Name
        Dim ToDeleteExtension As String = ".ToDelete"
        Dim RemoteUri As String = RemotePath & AssemblyName & "/"
        Dim MyWebClient As New WebClient
        Try
            ' try to delete old files if exist
            Dim s As String = Dir(Application.StartupPath & "\*" & ToDeleteExtension)
            'MsgBox(AssemblyName)
            Do While s <> ""
                Try
                    File.Delete(Application.StartupPath & "\" & s)
                Catch ex As Exception
                End Try
                s = Dir()
            Loop
            ' get the update file content
            Dim Contents As String = MyWebClient.DownloadString(RemoteUri & UpdateFileName)
            ' Process the autoupdate
            ' get rid of the line feeds if exists
            Contents = Replace(Contents, Chr(Keys.LineFeed), "")
            Dim FileList() As String = Split(Contents, Chr(Keys.Return))
            Contents = ""
            ' Remove all comments and blank lines
            For Each F As String In FileList
                If InStr(F, "'") <> 0 Then F = Strings.Left(F, InStr(F, "'") - 1)
                If F.Trim <> "" Then
                    If Contents <> "" Then Contents += Chr(Keys.Return)
                    Contents += F.Trim
                End If
            Next
            ' rebuild the file list
            FileList = Split(Contents, Chr(Keys.Return))
            Dim Info() As String = Split(FileList(0), ";")
            ' if the name is correct and it is a new version
            If Application.StartupPath.ToLower & "\" & Info(0).ToLower = Application.ExecutablePath.ToLower AndAlso _
               GetVersion(Info(1)) > GetVersion(Application.ProductVersion) Then
                ' process files in the list
                For Each F As String In FileList
                    Info = Split(F, ";")
                    Dim isToDelete As Boolean = False
                    Dim isToUpgrade As Boolean = False
                    Dim TempFileName As String = Application.StartupPath & "\" & Now.TimeOfDay.TotalMilliseconds
                    Dim FileName As String = Application.StartupPath & "\" & Info(0).Trim
                    Dim FileExists As Boolean = File.Exists(FileName)
                    If Info.Length = 1 Then
                        ' Just the file as parameter always upgrade
                        isToUpgrade = True
                        isToDelete = FileExists
                    ElseIf Info(1).Trim = "delete" Then
                        ' second parameter is "delete"
                        isToDelete = FileExists
                    ElseIf Info(1).Trim = "?" Then
                        ' second parameter is "?" (check if file exists and don't upgrade if exists)
                        isToUpgrade = Not FileExists
                    ElseIf FileExists Then
                        ' verify the file version
                        Dim fv As FileVersionInfo = FileVersionInfo.GetVersionInfo(FileName)
                        isToUpgrade = (GetVersion(Info(1).Trim) > GetVersion(fv.FileMajorPart & "." & fv.FileMinorPart & "." & fv.FileBuildPart & "." & fv.FilePrivatePart))
                        isToDelete = isToUpgrade
                    Else
                        ' the second parameter exists as version number and the file doesn't exists
                        isToUpgrade = True
                    End If
                    Debug.Print(TempFileName)
                    ' download the new file
                    If isToUpgrade Then MyWebClient.DownloadFile(RemoteUri & Info(0), TempFileName)
                    ' rename the existent file to be deleted in the future
                    If isToDelete Then File.Move(FileName, TempFileName & ToDeleteExtension)
                    ' rename the downloaded file to the real name
                    If isToUpgrade Then File.Move(TempFileName, FileName)
                    ' try to delete the file
                Next
                ' call the new version
                System.Diagnostics.Process.Start(Application.ExecutablePath, Microsoft.VisualBasic.Command())
                Ret = True
            End If

        Catch ex As Exception
            Ret = True
            MsgBox(m_ErrorMessage & vbCr & ex.Message & vbCr & "Assembly: " & AssemblyName, MsgBoxStyle.Critical, Application.ProductName)
        End Try
        Return Ret
    End Function

    Public Property RemotePath() As String
        Get
            Return m_RemotePath
        End Get
        Set(ByVal value As String)
            m_RemotePath = value
        End Set
    End Property

    Public Property UpdateFileName() As String
        Get
            Return m_UpdateFileName
        End Get
        Set(ByVal value As String)
            m_UpdateFileName = value
        End Set
    End Property

    Public Property ErrorMessage() As String
        Get
            Return m_ErrorMessage
        End Get
        Set(ByVal value As String)
            m_ErrorMessage = value
        End Set
    End Property

    Private Function GetVersion(ByVal Version As String) As String
        Dim x() As String = Split(Version, ".")
        Return String.Format("{0:00000}{1:00000}{2:00000}{3:00000}", Int(x(0)), Int(x(1)), Int(x(2)), Int(x(3)))
    End Function

End Module