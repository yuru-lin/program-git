﻿Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Dns

'停用原因：修改程式可能無需SAP相關程式方可開啟，為20141002停用
Friend Class Login
    Public DBConn As SqlConnection
    Public oCompany As SAPbobsCOM.Company = New SAPbobsCOM.Company
    Public ksParameter(10) As String
    Public pFunction = New publicFunction
    Public LoginType As Integer
    Public LogonUserName As String
    Public LogonUserName2 As String
    Public LogonUserUnit As String
    Public LogonCompanyName As String
    Public LogonCompanyDB As String
    Public LogonCompanySr As String
    'Public oCmpSrv As SAPbobsCOM.CompanyService
    'Public oMessageService As New SAPbobsCOM.MessagesService

    Public sErrMsg As String
    Public lErrCode As Integer
    Public lRetCode As Integer

    Public catalog As String

    Public DBServer As String
    Dim DBUser As String
    Dim DBPass As String
    Dim oUserName As String
    Dim oUserName2 As String
    Dim oUserPass As String

    'EC
    'Dim ECDBServer As String
    'Dim ECDBUser As String
    'Dim ECDBPass As String
    'Dim ECDBs As String

    Private oRecordSet As SAPbobsCOM.Recordset

    Private Sub Frame1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbVersion1.Text = "版本：" + FileVersionInfo.GetVersionInfo(Application.StartupPath & "\" & "KSSystem.exe").FileVersion
        lbVersion2.Text = "時間：" + Format(FileDateTime(Application.StartupPath & "\" & "KSSystem.exe"), "MM/dd-hh:mm")

        Label6.Text = UCase(GetHostName())

        MainForm.MainFormMenu.Enabled = False
        getParameters()     '讀取ks.txt 主機IP

        DBServer = ksParameter(0)
        DBUser = "sa"
        DBPass = "vispark"

        GetCompanyList()

        cobType.SelectedIndex = 0

        ConnDB()
        ChkVersion()
    End Sub

    Private Sub MainFormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If MessageBox.Show("確定要離開系統?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            Closeing()
        End If

    End Sub

    Private Sub getParameters()     '讀取ks.txt 主機IP
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(Application.StartupPath & "\ks.dat")
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

    Public Sub ConnDB()
        catalog = CompanyDGV.CurrentRow.Cells("資料庫").Value
        DBConn = New SqlConnection("user id=" & DBUser & ";password=" & DBPass & ";initial catalog=" & CompanyDGV.CurrentRow.Cells("資料庫").Value & ";data source=" & DBServer & ";Connection Timeout = 0")
        DBConn.Open()
    End Sub

    'Public Sub ConnDB_EC()
    '    catalog = CompanyDGV.CurrentRow.Cells("資料庫").Value
    '    DBConn = New SqlConnection("user id=" & DBUser & ";password=" & DBPass & ";initial catalog=" & ECDBs & ";data source=" & ECDBServer & ";Connection Timeout = 0")
    '    DBConn.Open()
    'End Sub

    Public Sub InitializeCompany()

        '// Initialize the Company Object.
        '// Create a new company object
        'oCompany = New SAPbobsCOM.Company

        '// Set the mandatory properties for the connection to the database.
        '// here I bring only 2 of the 5 mandatory fields.
        '// To use a remote Db Server enter his name instead of the string "(local)"
        '// This string is used to work on a DB installed on your local machine
        '// the other mandatory fields are CompanyDB, UserName and Password
        '// I am setting those fields in the ChooseCompany Form

        oCompany.Server = DBServer
        oCompany.language = SAPbobsCOM.BoSuppLangs.ln_TrdtnlChinese_Hk


    End Sub

    Public Sub Closeing()
        If Me.oCompany.Connected = True Then
            Me.oCompany.Disconnect()
            Me.oCompany = Nothing
        End If
        Me.DBConn.Close()
        Me.DBConn.Dispose()
        Me.DBConn = Nothing
        End
    End Sub

    Private Sub GetCompanyList()
        Dim dt As New DataTable
        Dim ComName As DataColumn = New DataColumn("公司名稱")
        Dim DBName As DataColumn = New DataColumn("資料庫")
        ComName.DataType = System.Type.GetType("System.String")
        DBName.DataType = System.Type.GetType("System.String")
        dt.Columns.Add(ComName)
        dt.Columns.Add(DBName)

        'oCompany = New SAPbobsCOM.Company
        oCompany.Server = DBServer
        oCompany.language = SAPbobsCOM.BoSuppLangs.ln_TrdtnlChinese_Hk

        oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008
        oCompany.UseTrusted = False
        oCompany.DbUserName = DBUser
        oCompany.DbPassword = DBPass


        '// once the Server property of the Company is set
        '// we may query for a list of companies to choos from
        '// this method returns a Recordset object
        Try
            'oRecordSet = oCompany.GetCompanyList
            oRecordSet = oCompany.GetCompanyList

            '// Use GetLastError method directly after a function
            '// which doesn't have a return code
            '// you may also use the On Error GoTo.
            '// functions with no return codes throws exceptions

            oCompany.GetLastError(lErrCode, sErrMsg)

            If lErrCode <> 0 Then
                MsgBox(sErrMsg)
            Else
                If oCompany.Connected = False Then
                    '// Load the available company DB names to the combo box
                    '// the returned Recordset containds 4 fields:
                    '// dbName - represents the database name
                    '// cmpName - represents the company name
                    '// versStr - represents the version number of the company database
                    '// dbUser - represents the database owner
                    '// we are interested in the first filed (mandatory property)

                    '// Clear the company list
                    dt.Clear()

                    '// Go through the Recordset and extract the dbname
                    Do Until oRecordSet.EoF = True
                        '// add the value of the first field of the Recordset

                        Dim Row As DataRow
                        Row = dt.NewRow
                        Row.Item("公司名稱") = oRecordSet.Fields.Item(1).Value
                        Row.Item("資料庫") = oRecordSet.Fields.Item(0).Value
                        dt.Rows.Add(Row)
                        '// move the record pointer to the next row
                        oRecordSet.MoveNext()
                    Loop

                    ' Enable controls
                    Label1.Enabled = True
                    Label2.Enabled = True
                    Label3.Enabled = True

                    Text1.Enabled = True
                    Text2.Enabled = True
                    Command1.Enabled = True
                    CompanyDGV.DataSource = dt
                    CompanyDGV.AutoResizeColumns()
                End If

            End If

            If oCompany.Connected = True Then
                '// if the company object is allreay connected to a DB
                '// you must first Disconnect it before connecting it
                '// to a different DB
                '// bare in mind that by disconnecting the company object
                '// you lose all of the properties (Server, Language)
                Command1.Enabled = False
                'Combo1.SelectedText = oCompany.CompanyDB
                'DGV1.CurrentRow.Cells("存編").Value
                CompanyDGV.SelectedCells.Item("資料庫").Value = oCompany.CompanyDB

                Text1.Text = oCompany.UserName
                Text2.Text = oCompany.Password
                Me.Text = Me.Text & ": Connected"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            InitializeCompany()
        End Try


    End Sub

    Public Function SyncInit(ByVal index As Integer) As Integer
        Select Case index
            Case 1
                MainForm.ToolStripStatusLabel1.Text = "登入中，請稍候!"
            Case 2
                MainForm.ToolStripStatusLabel1.Text = "登入失敗!"
            Case 3
                MainForm.ToolStripStatusLabel1.Text = "登入成功!"

        End Select
        Return Nothing

    End Function

    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click

        If Text1.Text = "" Then
            MsgBox("使用者帳號未填!", 16, "錯誤")
            Text1.Focus()
            Exit Sub
        Else
            oUserName = Trim(Text1.Text)
        End If

        If Text2.Text = "" Then
            MsgBox("使用者密碼未填!", 16, "錯誤")
            Text2.Focus()
            Exit Sub
        Else
            oUserPass = Trim(Text2.Text)
        End If

        Timer1.Interval = 10
        Timer1.Enabled = True
        SyncInit(1)

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Select Case cobType.SelectedIndex
            Case 0
                ConnSap()
            Case 1      '內部系統   2013/10/02修改
                ConnNonSap2()
            Case 2
                ConnNonSap()
        End Select
    End Sub

    Private Sub ConnSap()
        'SAP權限登入
        '傳送資料至 MainMenuList
        '// setting the rest of the mandatory properties
        'MainForm.ToolStripStatusLabel1.Text = "登入中，請稍候!"
        'SyncInit(1)
        oCompany.CompanyDB = CompanyDGV.CurrentRow.Cells("資料庫").Value
        oCompany.UserName = oUserName
        oCompany.Password = oUserPass

        IDNumber = oUserName

        oCompany.language = SAPbobsCOM.BoSuppLangs.ln_TrdtnlChinese_Hk
        '// Connecting to a company DB
        lRetCode = oCompany.Connect

        If lRetCode <> 0 Then
            Timer1.Enabled = False
            oCompany.GetLastError(lErrCode, sErrMsg)
            MsgBox(sErrMsg, 16, "錯誤")
            SyncInit(2)
            Timer1.Enabled = False
        Else
            'MsgBox("Connected to " & oCompany.CompanyName)
            Me.Text = Me.Text & ": Connected"
            SyncInit(3)
            ' Disable controls
            Label1.Enabled = False
            Label2.Enabled = False
            Label3.Enabled = False

            Text1.Enabled = False
            Text2.Enabled = False
            Command1.Enabled = False
            LogonCompanySr = DBServer
            LogonUserName = oCompany.UserName
            LogonCompanyName = oCompany.CompanyName
            LogonCompanyDB = oCompany.CompanyDB
            ConnDB()
            MainMenuList.MdiParent = MainForm
            MainMenuList.Show()
            MainForm.MainFormMenu.Enabled = True
            Me.Hide()
        End If
    End Sub

    ' ''------>轉換密碼<------
    ''Public Function encyPwd(ByVal oPWD As String) As String
    ''    Dim ePWD As String = ""

    ''    For i As Integer = 1 To Len(oPWD)
    ''        ePWD = ePWD & Chr(Asc(Mid(oPWD, i, 1)) + 7 + i)
    ''    Next

    ''    Return ePWD
    ''End Function


    Private Sub ConnNonSap()
        '非SAP權限登入
        ConnDB()
        Dim sql As String
        Dim sqlCmd As New SqlCommand
        Dim DBConn1 As SqlConnection = DBConn
        Dim sqlReader As SqlDataReader

        Dim pwd = pFunction.encyPwd(oUserPass)
        'Dim pwd = encyPwd(oUserPass)
        'MsgBox(pwd)
        'sql = "select * from [@kslogin] where LOG01='" & oUserName & "' and LOG02='" & pwd & "'"
        sql = "SELECT * FROM [@kslogin] WHERE [LOG01] = '" & oUserName & "' AND [LOG02] = '" & pwd & "' AND [LOG08] IN ('0','9') "

        sqlCmd.Connection = DBConn1
        sqlCmd.CommandText = sql
        sqlReader = sqlCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            MsgBox("帳號或密碼錯誤, 請重新輸入!", , "登入錯誤")
            SyncInit(2)
            sqlReader.Close()
            Exit Sub
        Else
            Dim oIDValidate As String = sqlReader.Item("LOG05")
            Dim oAuthorization As String = sqlReader.Item("LOG06")
            Dim oUserName2 As String = sqlReader.Item("LOG07")

            IDNumber = sqlReader.Item("LOG01")
            IDName = sqlReader.Item("LOG07")
            IDLog08 = sqlReader.Item("LOG08") 'ID筆一層功能區
            IDLog06 = sqlReader.Item("LOG06") 'ID筆二層功能區
            If sqlReader.Item("LOG09").ToString = vbNullString Then : IDLog09 = "" : Else : IDLog09 = sqlReader.Item("LOG09") : End If

            If oIDValidate = "N" Then
                MsgBox("帳號鎖住或權限不足!", , "登入錯誤")
                sqlReader.Close()
                SyncInit(2)
                Exit Sub
            Else
                sqlReader.Close()

                Me.Text = Me.Text & ": Connected"
                SyncInit(3)
                LogonCompanySr = DBServer
                LogonUserName = oUserName
                LogonUserName2 = oUserName2

                LogonCompanyName = CompanyDGV.CurrentRow.Cells("公司名稱").Value
                LogonCompanyDB = CompanyDGV.CurrentRow.Cells("資料庫").Value
                MainMenuList.MdiParent = MainForm
                MainMenuList.Show()
                MainForm.MainFormMenu.Enabled = True
                Me.Hide()

            End If
        End If


    End Sub

    Private Sub ConnNonSap2()
        '非SAP權限登入  內部系統
        ConnDB()
        Dim sql As String
        Dim sqlCmd As New SqlCommand
        Dim DBConn1 As SqlConnection = DBConn
        Dim sqlReader As SqlDataReader

        Dim pwd = pFunction.encyPwd(oUserPass)
        'Dim pwd = encyPwd(oUserPass)
        'MsgBox(pwd)
        sql = "SELECT * FROM [@kslogin] WHERE [LOG01] = '" & oUserName & "' AND [LOG02] = '" & pwd & "' AND [LOG08] IN ('1','2','9')"
        sqlCmd.Connection = DBConn1
        sqlCmd.CommandText = sql
        sqlReader = sqlCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            MsgBox("帳號或密碼錯誤, 請重新輸入!", , "登入錯誤")
            SyncInit(2)
            sqlReader.Close()
            Exit Sub
        Else
            Dim oIDValidate As String = sqlReader.Item("LOG05")
            Dim oAuthorization As String = sqlReader.Item("LOG06")
            Dim oUserName2 As String = sqlReader.Item("LOG07")

            IDNumber = sqlReader.Item("LOG01")
            IDName = sqlReader.Item("LOG07")

            IDLog08 = sqlReader.Item("LOG08") 'ID筆一層功能區
            IDLog06 = sqlReader.Item("LOG06") 'ID筆二層功能區
            If sqlReader.Item("LOG09").ToString = vbNullString Then : IDLog09 = "" : Else : IDLog09 = sqlReader.Item("LOG09") : End If


            If oIDValidate = "N" Then
                MsgBox("帳號鎖住或權限不足!", , "登入錯誤")
                sqlReader.Close()
                SyncInit(2)
                Exit Sub
            Else
                sqlReader.Close()

                Me.Text = Me.Text & ": Connected"
                SyncInit(3)
                LogonCompanySr = DBServer
                LogonUserName = oUserName
                LogonUserName2 = oUserName2

                LogonCompanyName = CompanyDGV.CurrentRow.Cells("公司名稱").Value
                LogonCompanyDB = CompanyDGV.CurrentRow.Cells("資料庫").Value
                MainMenuList.MdiParent = MainForm
                MainMenuList.Show()
                MainForm.MainFormMenu.Enabled = True
                Me.Hide()

            End If
        End If


    End Sub


    Private Sub lbVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbVersion1.Click
        If MessageBox.Show("確定要更新版本?" & vbCrLf & "更新完後須重新開啟程式。", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            If AutoUpdate.UpdateFiles() Then
                Closeing()
            Else
                MsgBox("沒有新版本")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cobType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobType.SelectedIndexChanged

        If DBServer = "192.168.0.110" Or DBServer = "ks-sap" Or DBServer = "KS-SAP" Then

            Select Case cobType.SelectedIndex
                Case 0
                    Text1.Text = ""
                    Text2.Text = ""
                    'Text1.Enabled = True
                    'Text2.Enabled = True
                    LoginType = 0
                Case 1
                    Text1.Text = ""
                    Text2.Text = ""
                    'Text1.Text = "KS21"
                    'Text2.Text = "5347888"
                    'Text1.Enabled = False
                    'Text2.Enabled = False
                    LoginType = 1
                Case 2
                    Text1.Text = ""
                    Text2.Text = ""
                    'Text1.Enabled = True
                    'Text2.Enabled = True
                    LoginType = 2
            End Select

        Else

            Select Case cobType.SelectedIndex
                Case 0
                    Text1.Text = "manager"
                    Text2.Text = "ks&sap"
                    'Text1.Enabled = True
                    'Text2.Enabled = True
                    LoginType = 0
                Case 1
                    Text1.Text = ""
                    Text2.Text = ""
                    'Text1.Text = "KS21"
                    'Text2.Text = "5347888"
                    'Text1.Enabled = False
                    'Text2.Enabled = False
                    LoginType = 1
                Case 2
                    Text1.Text = "manager"
                    Text2.Text = "ks&sap"
                    'Text1.Enabled = True
                    'Text2.Enabled = True
                    LoginType = 2
            End Select

        End If
    End Sub

    Private Sub ChkVersion()
        Dim oAns As Boolean = chkFiles()

        If oAns = True Then
            If MessageBox.Show("有新版本!是否要更新版本?", "更新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            Else
                If AutoUpdate.UpdateFiles() Then
                    Closeing()
                Else
                    MsgBox("沒有新版本")
                    Exit Sub
                End If
            End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        'cobType.SelectedIndex = 2
        Text1.Text = "manager"
        Text2.Text = "ks&sap"
    End Sub

 
End Class