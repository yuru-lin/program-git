Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QckUpdateTransPrice

    Private Sub B_QckUpdateTransPrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvTransport.ContextMenuStrip = MainForm.ContextMenuStrip1
        dateDocDate.Value = dateDocDate.Value.Date.AddDays(1)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        QueryTransport()
    End Sub

    Private Sub QueryTransport()     
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter
        Dim ks1DataSetDGV As DataSet = New DataSet

        sql = "SELECT T0.[CarEntry] as '單號',T1.[LineNum] as '列號',T1.[CarOrder] as '順序',T0.[DocDate] as '日期',T1.[FarmName] as '牧場名稱',T1.[TypeName] as '品名',T1.[PricePerTWKG] as '台斤單價',T1.[PricePerKG] as '公斤單價' FROM [@Transportation] T0 inner join [@Transportation1] T1 ON T0.CarEntry = T1.CarEntry Where T0.[DocDate] = '" & dateDocDate.Value.Date & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        dgvTransport.DataSource = ks1DataSetDGV.Tables("DT1")
        dgvTransport.AutoResizeColumns()

    End Sub

    Private Sub dgvTransport_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTransport.CellClick

        lblEntry.Text = "單號：" & dgvTransport.CurrentRow.Cells("單號").Value & " 順序：" & dgvTransport.CurrentRow.Cells("順序").Value
        txtPricePerTWKG.Text = dgvTransport.CurrentRow.Cells("台斤單價").Value
        txtPricePerKG.Text = dgvTransport.CurrentRow.Cells("公斤單價").Value
       
    End Sub

    Private Sub txtPricePerTWKG_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPricePerTWKG.TextChanged
        CalcPricePerKG()
    End Sub

    '計算公斤單價
    Private Sub CalcPricePerKG()
        Dim PricePerTWKG As Double

        If txtPricePerTWKG.Text = "" Then
            PricePerTWKG = 0
        Else
            PricePerTWKG = CDbl(Trim(txtPricePerTWKG.Text))
        End If

        If PricePerTWKG = 0 Then
            Exit Sub
        End If

        txtPricePerKG.Text = Format(CDbl(PricePerTWKG / 0.6), "#0.####")
    End Sub

    Private Sub btnAddToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDB.Click
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            sql = "UPDATE [@Transportation1] SET PricePerTWKG = " & txtPricePerTWKG.Text & ",PricePerKG = " & txtPricePerKG.Text & " Where [CarEntry] = '" & dgvTransport.CurrentRow.Cells("單號").Value & "' and [LineNum] = '" & dgvTransport.CurrentRow.Cells("列號").Value & "' "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("更新至資料庫完成!", 64, "成功")
        txtPricePerTWKG.Text = "0"
        txtPricePerKG.Text = "0"
        QueryTransport()
    End Sub

    '限制輸入數字並只到小數點後2位
    Private Sub txtPricePerTWKG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerTWKG.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 2 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    '限制輸入數字並只到小數點後4位
    Private Sub txtPricePerKG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerKG.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 4 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub BtnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToExcel.Click
        DataToExcel(dgvTransport, "")
    End Sub

End Class