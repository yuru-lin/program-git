Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_EBin
    'Dim DataAdapter1 As SqlDataAdapter
    'Dim ksDataSet As DataSet = New DataSet

    Dim DataAdapter2 As SqlDataAdapter
    Dim ksDataSet2 As DataSet = New DataSet

    Private Sub A_EBin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        OnLoadData()

        CU_CarDr1.Text = ""
        'U_CarDr1.SelectedIndex = -1

    End Sub

    Private Sub ClearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBtn.Click
        ClearAll()
    End Sub

    Private Sub ClearAll()
        DocNum.Clear()
        DocDate.Value = Today
        InNum.Clear()
        Bonus.Clear()
        Descr.Clear()
       
        OnLoadData()  
    End Sub

    Private Sub OnLoadData()
        SelectDocNum()
        SelectCardCode()
        SelectAddID()
        SelectCarDr()
        LoadSourceMain()

    End Sub
    Private Sub OnLoadData2()
        'SelectDocNum()
        'SelectCardCode()
        'SelectAddID()
        'SelectCarDr()
        LoadSourceMain()
    End Sub

    Private Sub SelectDocNum()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim DocNumInt As Integer

        sql = "SELECT TOP 1 T0.DocNum FROM [@EBin] T0 Order by T0.DocNum desc"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            DocNumInt = sqlReader.Item("DocNum") + 1
        Else
            DocNumInt = "1"
        End If
        sqlReader.Close()
        DocNum.Text = DocNumInt

    End Sub

    Private Sub SelectCarDr()
        Try
            'Dim DataAdapter1 As SqlDataAdapter
            'Dim ksDataSet As DataSet = New DataSet

            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            'Dim X As Integer

            sql = " SELECT T0.[pager] AS 'Code' ,T0.[lastName] AS 'Name' FROM [OHEM] T0 INNER JOIN [HEM6] T1 ON T0.[empID] = T1.[empID] WHERE (T1.[roleID] = 1 And T0.[status] = 1) Union All SELECT T0.[CardCode] AS 'Code',T0.[cardname] AS 'Name' FROM [OCRD] T0 WHERE T0.[QryGroup20] = 'Y' "

            'SQLCmd.Connection = DBConn
            'SQLCmd.CommandText = sql
            If ksDataSet2.Tables.Contains("DT1") Then

                'U_CarDr1.SelectedIndex = -1
                'CU_CarDr1.Text = ""
                ksDataSet2.Tables("DT1").Clear()

            End If

            DataAdapter2 = New SqlDataAdapter(sql, DBConn)
            DataAdapter2.Fill(ksDataSet2, "DT1")

            U_CarDr1.DataSource = ksDataSet2.Tables("DT1")
            U_CarDr1.DisplayMember = "Name"
            U_CarDr1.ValueMember = "Name"

            'U_CarDr1.SelectedIndex = -1

            'If U_CarDr1.SelectedIndex = -1 Then
            '    CU_CarDr1.Text = ""
            '    Exit Sub
            'Else
            'Try
            '    Dim dt As DataTable = ksDataSet2.Tables("DT1")
            '    Dim oCriteria As String = "Name='" & Trim(U_CarDr1.Text) & "'"
            '    Dim foundRow() As DataRow

            '    foundRow = dt.Select(oCriteria)
            '    CU_CarDr1.Text = foundRow(0)("Code")

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    'Private Sub SelectCarDr_2()
    '    If U_CarDr1.SelectedIndex = -1 Then
    '        Exit Sub
    '    End If

    '    Try
    '        'Dim ksDataSet As DataSet = New DataSet

    '        Dim dt As DataTable = ksDataSet2.Tables("DT1")
    '        Dim oCriteria As String = "Name='" & Trim(U_CarDr1.Text) & "'"
    '        Dim foundRow() As DataRow

    '        foundRow = dt.Select(oCriteria)
    '        CU_CarDr1.Text = foundRow(0)("Code")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    'Private Sub U_CarDr1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CarDr1.SelectionChangeCommitted
    '    If U_CarDr1.SelectedIndex = -1 Then
    '        Exit Sub
    '    End If

    '    Try

    '        Dim dt As DataTable = ksDataSet2.Tables("DT1")
    '        Dim oCriteria As String = "Name='" & Trim(U_CarDr1.Text) & "'"
    '        Dim foundRow() As DataRow

    '        foundRow = dt.Select(oCriteria)
    '        CU_CarDr1.Text = foundRow(0)("Code")

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    'End Sub



    Private Sub SelectCardCode()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer

        sql = "SELECT T0.[CardCode] FROM OCRD T0 WHERE T0.[CardType] = 'C'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        CardCode.DataSource = ksDataSet.Tables("DT1")
        CardCode.DisplayMember = "CardCode"
        CardCode.ValueMember = "CardCode"

        AddHandler CardCode.SelectedIndexChanged, AddressOf CardCode_SelectedIndexChanged
        AddHandler CardCode.LostFocus, AddressOf CardCode_SelectedIndexChanged

    End Sub

    Private Sub CardCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        'Dim sqlCmdR As SqlCommand
        'Dim X As Integer

        sql = "SELECT T0.[AddID] FROM OCRD T0 WHERE T0.[CardCode] = '" & CardCode.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        'sqlCmdR = New SqlCommand(sql, DBConn)
        sqlReader = SQLCmd.ExecuteReader

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            AddID.Text = ""
            AddID.Enabled = False
            MsgBox("客戶編號錯誤!請重新輸入!", MsgBoxStyle.OkOnly, "錯誤訊息")
        Else
            sqlReader.Close()

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT1")

            AddID.DataSource = ksDataSet.Tables("DT1")
            AddID.DisplayMember = "AddID"
            AddID.ValueMember = "AddID"
            AddID.Enabled = True
        End If


    End Sub

    Private Sub SelectAddID()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer

        sql = "SELECT T0.[AddID] FROM OCRD T0 WHERE T0.[CardType] = 'C'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        AddID.DataSource = ksDataSet.Tables("DT1")
        AddID.DisplayMember = "AddID"
        AddID.ValueMember = "AddID"

        'AddHandler AddID.SelectedIndexChanged, AddressOf AddID_SelectedIndexChanged

    End Sub

    Private Sub AddID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer

        sql = "SELECT T0.[CardCode] FROM OCRD T0 WHERE T0.[AddID] = '" & AddID.SelectedValue & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        CardCode.DataSource = ksDataSet.Tables("DT1")
        CardCode.DisplayMember = "CardCode"
        CardCode.ValueMember = "CardCode"

    End Sub

    Private Sub SendBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendBtn.Click
       
        SendAdd()

    End Sub

    Private Sub SendAdd()
        Dim BounsNull As Integer

        If InNum.Text = "" Then
            MsgBox("請輸入回收數量")
            Exit Sub
        End If

        If Bonus.Text = "" Then
            BounsNull = 0
        Else
            BounsNull = Bonus.Text
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            'sql = "  INSERT INTO [@EBin] (DocNum,DocDate,CardCode,AddID,U_CarDr1,InNum,Bonus,Descr,TypeUser,CU_CarDr1) Values "
            'sql += " (" & DocNum.Text & ",'" & DocDate.Value.Date & "','" & CardCode.Text & "','" & AddID.Text & "','" & U_CarDr1.Text & "'," & InNum.Text & "," & BounsNull & ",'" & Descr.Text & "','" & Login.LogonUserName & "','" & CU_CarDr1.Text & "') "
            sql = "  INSERT INTO [@EBin] (DocNum,DocDate,CardCode,AddID,U_CarDr1,InNum,Bonus,Descr,TypeUser) Values "
            sql += " (" & DocNum.Text & ",'" & DocDate.Value.Date & "','" & CardCode.Text & "','" & AddID.Text & "','" & U_CarDr1.Text & "'," & InNum.Text & "," & BounsNull & ",'" & Descr.Text & "','" & Login.LogonUserName & "') "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MessageBox.Show("送出: 新增時錯誤!")
            ClearAll()
            Exit Sub
        End Try

        MsgBox("回收單新增完畢!", MsgBoxStyle.OkOnly, "新增成功")
        ClearAll()

    End Sub

    Private Sub DocNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DocNum.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub InNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles InNum.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Bonus_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Bonus.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub LoadSourceMain()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        'Dim X As Integer

        Try
            sql = "SELECT TOP 50 * FROM [@EBin]  Order BY DocNum DESC "

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT1")
            dgvSourceMain.DataSource = ksDataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        SourceMainDisplay()

    End Sub

    Private Sub SourceMainDisplay()
        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                Case "DocNum"
                    column.HeaderText = "回收單號"
                    column.DisplayIndex = 0
                Case "DocDate"
                    column.HeaderText = "回收日期"
                    column.DisplayIndex = 1
                Case "CardCode"
                    column.HeaderText = "客戶編號"
                    column.DisplayIndex = 2
                Case "AddID"
                    column.HeaderText = "客戶簡稱"
                    column.DisplayIndex = 3
                Case "U_CarDr1"
                    column.HeaderText = "司機"
                    column.DisplayIndex = 4
                Case "InNum"
                    column.HeaderText = "回收數量"
                    column.DisplayIndex = 5
                Case "Bonus"
                    column.HeaderText = "特殊獎金"
                    column.DisplayIndex = 6
                Case "Descr"
                    column.HeaderText = "說明"
                    column.DisplayIndex = 7
                Case Else

                    column.Visible = False
            End Select
        Next
        dgvSourceMain.AutoResizeColumns()

    End Sub

    


End Class