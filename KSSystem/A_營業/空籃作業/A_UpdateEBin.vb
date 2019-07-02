Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_UpdateEBin
    Dim DataAdapter1 As SqlDataAdapter
    Dim ksDataSet As DataSet = New DataSet
    Dim ksDataSet2 As DataSet = New DataSet

    Private Sub A_UpdateEBin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        SelectCarDr()

        'SendBtn.Enabled = False
        'Button2.Enabled = False

    End Sub

    Private Sub SelectCarDr()
        'Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer

        'sql = "SELECT T0.[lastName] FROM OHEM T0 INNER JOIN HEM6 T1 ON T0.empID = T1.empID where(T1.[roleID] = 1 And T0.status = 1) union all  select T0.cardname from OCRD T0 where T0.QryGroup20='Y'"
        sql = " SELECT T0.[pager] AS 'Code' ,T0.[lastName] AS 'Name' FROM [OHEM] T0 INNER JOIN [HEM6] T1 ON T0.[empID] = T1.[empID] WHERE (T1.[roleID] = 1 And T0.[status] = 1) Union All SELECT T0.[CardCode] AS 'Code',T0.[cardname] AS 'Name' FROM [OCRD] T0 WHERE T0.[QryGroup20] = 'Y' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet2, "DT1")
        SelectU_CarDr1.DataSource = ksDataSet2.Tables("DT1")
        SelectU_CarDr1.DisplayMember = "Name"
        SelectU_CarDr1.ValueMember = "Name"

        DataAdapter1.Fill(ksDataSet2, "DT2")
        U_CarDr1.DataSource = ksDataSet2.Tables("DT2")
        U_CarDr1.DisplayMember = "Name"
        U_CarDr1.ValueMember = "Name"


        'SelectU_CarDr1.SelectedIndex = -1
        U_CarDr1.SelectedIndex = -1

        'Try
        '    Dim dt As DataTable = ksDataSet2.Tables("DT1")
        '    Dim oCriteria As String = "Name='" & Trim(SelectU_CarDr1.Text) & "'"
        '    Dim foundRow() As DataRow

        '    foundRow = dt.Select(oCriteria)
        '    SelectCU_CarDr1.Text = foundRow(0)("Code")

        'Catch ex As Exception
        '    MsgBox("司機姓名錯誤!!" & ex.Message)
        'End Try

    End Sub

    'Private Sub SelectU_CarDr1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectU_CarDr1.SelectionChangeCommitted
    '    If SelectU_CarDr1.SelectedIndex = -1 Or SelectU_CarDr1.Text = "" Then
    '        Exit Sub
    '    End If

    '    Try
    '        Dim dt As DataTable = ksDataSet2.Tables("DT1")
    '        Dim oCriteria As String = "Name='" & Trim(SelectU_CarDr1.Text) & "'"
    '        Dim foundRow() As DataRow

    '        foundRow = dt.Select(oCriteria)
    '        SelectCU_CarDr1.Text = foundRow(0)("Code")

    '    Catch ex As Exception
    '        MsgBox("司機姓名錯誤!!" & ex.Message)
    '    End Try
    'End Sub

    'Private Sub U_CarDr1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CarDr1.SelectionChangeCommitted

    '    If Button1.Enabled = False Then
    '        If U_CarDr1.SelectedIndex = -1 Then
    '            Exit Sub
    '        End If

    '        Try
    '            Dim dt As DataTable = ksDataSet2.Tables("DT2")
    '            Dim oCriteria As String = "Name='" & Trim(U_CarDr1.Text) & "'"
    '            Dim foundRow() As DataRow

    '            foundRow = dt.Select(oCriteria)
    '            CU_CarDr1.Text = foundRow(0)("Code")

    '        Catch ex As Exception
    '            MsgBox("司機姓名錯誤!!" & ex.Message)
    '        End Try

    '    End If

    'End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadSourceMain()
    End Sub

    Private Sub LoadSourceMain()
        If dgvSourceMain.RowCount > 0 Then
            ksDataSet.Tables("DT1").Clear()
        End If

        'Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand
        'Dim X As Integer

        Try
            sql = "SELECT * FROM [@EBin] WHERE sid > 0 "

            If CheckBox1.Checked = True Then
                sql += " AND DocDate = '" & SelectDocDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " AND DocNum = '" & SelectDocNum.Text & "'  "
            End If

            If CheckBox3.Checked = True Then
                sql += " AND CU_CarDr1 = '" & SelectCU_CarDr1.Text & "' "
            End If

            sql += " Order by DocNum desc"

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT1")
            dgvSourceMain.DataSource = ksDataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            Exit Sub
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
                    'Case "CU_CarDr1"
                    '    column.HeaderText = "司機編號"
                    '    column.DisplayIndex = 4
                Case "U_CarDr1"
                    column.HeaderText = "司機姓名"
                    column.DisplayIndex = 5
                Case "InNum"
                    column.HeaderText = "回收數量"
                    column.DisplayIndex = 6
                Case "Bonus"
                    column.HeaderText = "特殊獎金"
                    column.DisplayIndex = 7
                Case "Descr"
                    column.HeaderText = "說明"
                    column.DisplayIndex = 8

                Case Else

                    column.Visible = False
            End Select
        Next
        dgvSourceMain.AutoResizeColumns()

    End Sub

    Private Sub dgvSourceMain_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick

        DocNum.Text = dgvSourceMain.CurrentRow.Cells("DocNum").Value
        DocDate.Text = dgvSourceMain.CurrentRow.Cells("DocDate").Value
        CardCode.Text = dgvSourceMain.CurrentRow.Cells("CardCode").Value
        AddID.Text = dgvSourceMain.CurrentRow.Cells("AddID").Value
        'CU_CarDr1.Text = dgvSourceMain.CurrentRow.Cells("CU_CarDr1").Value
        U_CarDr1.Text = dgvSourceMain.CurrentRow.Cells("U_CarDr1").Value
        InNum.Text = dgvSourceMain.CurrentRow.Cells("InNum").Value
        Bonus.Text = dgvSourceMain.CurrentRow.Cells("Bonus").Value
        Descr.Text = dgvSourceMain.CurrentRow.Cells("Descr").Value

    End Sub

    Private Sub SendBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendBtn.Click
        '存檔
        SendUppdate()
        'SendBtn.Enabled = False
        'Button1.Enabled = True
        'Button2.Enabled = False
        'dgvSourceMain.Enabled = True

        'U_CarDr1.DropDownStyle = ComboBoxStyle.DropDown
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    '修改
    '    SendBtn.Enabled = True
    '    Button1.Enabled = False
    '    Button2.Enabled = True
    '    dgvSourceMain.Enabled = False

    '    'U_CarDr1.DropDownStyle = ComboBoxStyle.DropDownList
    '    'U_CarDr1.SelectedIndex = -1
    '    'CU_CarDr1.Text = ""

    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    '取消
    '    SendBtn.Enabled = False
    '    Button1.Enabled = True
    '    Button2.Enabled = False
    '    dgvSourceMain.Enabled = True

    '    'U_CarDr1.DropDownStyle = ComboBoxStyle.DropDown
    'End Sub

    Private Sub SendUppdate()
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
            sql = " UPDATE [@EBin] SET DocNum    = '" & DocNum.Text & "'        ,"
            sql += "                   DocDate   = '" & DocDate.Value.Date & "' ,"
            sql += "                   CardCode  = '" & CardCode.Text & "'      ,"
            sql += "                   AddID     = '" & AddID.Text & "'         ,"
            sql += "                   U_CarDr1  = '" & U_CarDr1.Text & "'      ,"
            sql += "                   InNum     = '" & InNum.Text & "'         ,"
            sql += "                   Bonus     = '" & BounsNull & "'          ,"
            sql += "                   Descr     = '" & Descr.Text & "'         ,"
            sql += "                   TypeUser  = '" & Login.LogonUserName & "' "
            sql += "WHERE Sid = '" & dgvSourceMain.CurrentRow.Cells("sid").Value & "' "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            ClearAll()
            Exit Sub
        End Try        

        MsgBox("回收單更新完畢!", MsgBoxStyle.OkOnly, "更新成功")
        ClearAll()

    End Sub

    Private Sub ClearAll()
        DocNum.Clear()
        DocDate.Value = Today
        InNum.Clear()
        Bonus.Clear()
        Descr.Clear()
        LoadSourceMain()        
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






End Class