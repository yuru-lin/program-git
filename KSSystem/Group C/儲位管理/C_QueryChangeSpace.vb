Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QueryChangeSpace
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QueryChangeSpace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        TxtBox1.Focus()
        BtnExl1.Enabled = False
        BtnExl2.Enabled = False
    End Sub

    Private Sub QuyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuyBtn.Click
        Quy()
    End Sub

    Private Sub Quy()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter

        Try
            sql = "SELECT T0.Part ,T0.ChgDate ,T0.DocNum ,T0.ItemCode ,T0.ItemName ,T0.FromLoc ,T0.ToLoc , Count(T0.DocNum)as 'CntNum' FROM [@ChgLocMgn] T0 Where T0.DocNum <> '' "

            If cbxDate.Checked = True Then
                sql += " and (T0.ChgDate between '" & DTP1.Value.Date & "' and '" & DTP2.Value.Date & "') "
            End If

            If cbxDoc.Checked = True Then
                sql += " and T0.DocNum = '" & TxtBox1.Text & "' "
            End If

            If cbxItemCode.Checked = True Then
                sql += " and T0.ItemCode = '" & ItemCode.Text & "' "
            End If

            If cbxLocCode.Checked = True Then
                sql += " and T0.ToLoc = '" & LocCode.Text & "' "
            End If

            sql += " Group by T0.Part ,T0.ChgDate ,T0.DocNum ,T0.ItemCode ,T0.ItemName ,T0.FromLoc ,T0.ToLoc order by T0.DocNum ,T0.Part ,T0.ItemCode "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            If DGV1.RowCount > 0 Then
                ks1DataSet.Tables("DT1").Clear()
                ks1DataSet.Tables("DT2").Clear()
                BtnExl2.Enabled = False
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")

            DGV1.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            Exit Sub
        End Try

        DGV1Display()

    End Sub

    Private Sub DGV1Display()

        If DGV1.RowCount <= 0 Then
            MsgBox("查不到資料!請確認條碼是否正確!")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "Part"
                    column.HeaderText = "區別"
                    column.DisplayIndex = 0
                Case "ChgDate"
                    column.HeaderText = "調整日期"
                    column.DisplayIndex = 1
                Case "DocNum"
                    column.HeaderText = "調整單號"
                    column.DisplayIndex = 2
                Case "ItemCode"
                    column.HeaderText = "存貨編號"
                    column.DisplayIndex = 3
                Case "ItemName"
                    column.HeaderText = "品名規格"
                    column.DisplayIndex = 4
                Case "FromLoc"
                    column.HeaderText = "原本庫位"
                    column.DisplayIndex = 5
                Case "ToLoc"
                    column.HeaderText = "目的庫位"
                    column.DisplayIndex = 6
                Case "CntNum"
                    column.HeaderText = "箱數"
                    column.DisplayIndex = 7
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        BtnExl1.Enabled = True

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If DGV1.RowCount = 0 Then
            Exit Sub
        End If

        If DGV2.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        QuyMore()

    End Sub

    Private Sub QuyMore()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter

        sql = "SELECT T0.DocNum as '調整單號',T0.Part as '區別',T0.ItemCode as '存貨編號',T0.ItemName as '品名規格',T0.DistNumber as '條碼',T0.FromLoc as '原本庫位',T0.ToLoc as '目的庫位',T0.ChgDate as '調整日期'" _
        & "FROM [@ChgLocMgn] T0  " _
        & "WHERE T0.DocNum = '" & DGV1.CurrentRow.Cells("DocNum").Value & "' and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT2")

        DGV2.DataSource = ks1DataSet.Tables("DT2")
        DGV2.AutoResizeColumns()
        If DGV2.RowCount > 0 Then
            BtnExl2.Enabled = True
        End If

    End Sub

    Private Sub BtnExl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExl1.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub BtnExl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExl2.Click
        DataToExcel(DGV2, "")
    End Sub

    Private Sub cbxDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDate.CheckedChanged
        cbxChange()
    End Sub

    Private Sub cbxDoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDoc.CheckedChanged
        cbxChange()
    End Sub

    Private Sub cbxItemCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxItemCode.CheckedChanged
        cbxChange()
    End Sub

    Private Sub cbxLocCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxLocCode.CheckedChanged
        cbxChange()
    End Sub

    Private Sub cbxChange()
        If cbxDate.Checked = True Then
            DTP1.Enabled = True
            DTP2.Enabled = True
        Else
            DTP1.Enabled = False
            DTP2.Enabled = False
        End If

        If cbxDoc.Checked = True Then
            TxtBox1.Enabled = True
        Else
            TxtBox1.Enabled = False
        End If

        If cbxItemCode.Checked = True Then
            ItemCode.Enabled = True
        Else
            ItemCode.Enabled = False
        End If

        If cbxLocCode.Checked = True Then
            LocCode.Enabled = True
        Else
            LocCode.Enabled = False
        End If

    End Sub
End Class