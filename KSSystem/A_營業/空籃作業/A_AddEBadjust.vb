Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_AddEBadjust

    Private Sub A_AddEBadjust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        OnLoadData()
    End Sub

    Private Sub ClearBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBtn.Click
        ClearAll()
    End Sub

    Private Sub ClearAll()
        DocNum.Clear()
        DocDate.Value = Today
        AmtNum.Clear()
        Descr.Clear()
        
        OnLoadData()

    End Sub

    Private Sub OnLoadData()
        IncDec.SelectedIndex = 0
        SelectDocNum()
        SelectCardCode()
        SelectAddID()
        LoadSourceMain()
    End Sub   

    Private Sub SelectDocNum()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim DocNumInt As Integer

        sql = "SELECT top 1 T0.DocNum FROM [@EBadjust] T0 Order by T0.DocNum desc"

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
        'Dim X As Integer

        sql = "SELECT T0.[AddID] FROM OCRD T0 WHERE T0.[CardCode] = '" & CardCode.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
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

        ' AddHandler AddID.SelectedIndexChanged, AddressOf AddID_SelectedIndexChanged

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
    Private Sub DocNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DocNum.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub AmtNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AmtNum.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub SendBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendBtn.Click
       
        SendAdd()

    End Sub

    Private Sub SendAdd()
        If AmtNum.Text = "" Then
            MsgBox("請輸入數量")
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            sql = "Insert into [@EBadjust] (DocNum,DocDate,CardCode,AddID,IncDec,AmtNum,Descr,TypeUser) Values (" & DocNum.Text & ",'" & DocDate.Value.Date & "','" & CardCode.Text & "','" & AddID.Text & "','" & IncDec.Text & "'," & AmtNum.Text & ",'" & Descr.Text & "','" & Login.LogonUserName & "')"
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

        MsgBox("調整單新增完畢!", MsgBoxStyle.OkOnly, "新增成功")
        ClearAll()
    End Sub

    Private Sub LoadSourceMain()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        'Dim X As Integer

        Try
            sql = "SELECT top 50 * FROM [@EBadjust]  Order by DocNum desc"

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
                    column.HeaderText = "調整單號"
                    column.DisplayIndex = 0
                Case "DocDate"
                    column.HeaderText = "調整日期"
                    column.DisplayIndex = 1
                Case "CardCode"
                    column.HeaderText = "客戶編號"
                    column.DisplayIndex = 2
                Case "AddID"
                    column.HeaderText = "客戶簡稱"
                    column.DisplayIndex = 3
                Case "IncDec"
                    column.HeaderText = "增減"
                    column.DisplayIndex = 4
                Case "AmtNum"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 5
                Case "Descr"
                    column.HeaderText = "調整原因"
                    column.DisplayIndex = 6
                Case Else

                    column.Visible = False
            End Select
        Next
        dgvSourceMain.AutoResizeColumns()

    End Sub

    
End Class