Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_UpdateEBadjust

    Private Sub A_UpdateEBadjust_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub ClearAll()
        DocNum.Clear()
        DocDate.Value = Today
        AmtNum.Clear()
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
    Private Sub AmtNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AmtNum.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub SendBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendBtn.Click

        SendUppdate()
      
    End Sub

    Private Sub SendUppdate()
        If AmtNum.Text = "" Then
            MsgBox("請輸入數量")
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            sql = "UPDATE [@EBadjust] SET DocNum = " & DocNum.Text & " ,DocDate = '" & DocDate.Value.Date & "',CardCode = '" & CardCode.Text & "' ,AddID = '" & AddID.Text & "',IncDec = '" & IncDec.Text & "' ,AMtNum = " & AmtNum.Text & " ,Descr = '" & Descr.Text & "' ,TypeUser = '" & Login.LogonUserName & "' where sid = '" & dgvSourceMain.CurrentRow.Cells("sid").Value & "'"
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

        MsgBox("調整單更新完畢!", MsgBoxStyle.OkOnly, "更新成功")
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
            sql = "SELECT * FROM [@EBadjust] where sid > 0 "

            If CheckBox1.Checked = True Then
                sql += " and docdate = '" & SelectDocDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and DocNum = '" & SelectDocNum.Text & "'  "
            End If

            sql += " Order by DocNum desc"
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

    Private Sub dgvSourceMain_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick

        DocNum.Text = dgvSourceMain.CurrentRow.Cells("DocNum").Value
        DocDate.Text = dgvSourceMain.CurrentRow.Cells("DocDate").Value
        CardCode.Text = dgvSourceMain.CurrentRow.Cells("CardCode").Value
        AddID.Text = dgvSourceMain.CurrentRow.Cells("AddID").Value
        IncDec.Text = dgvSourceMain.CurrentRow.Cells("IncDec").Value
        AmtNum.Text = dgvSourceMain.CurrentRow.Cells("AmtNum").Value
        Descr.Text = dgvSourceMain.CurrentRow.Cells("Descr").Value

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        LoadSourceMain()
    End Sub

End Class