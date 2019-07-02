Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QueryAllocateWplace
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QueryAllocateWplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        TextBox1.Focus()
        BtnExl1.Enabled = False
        BtnExl2.Enabled = False
    End Sub

    Private Sub QuyBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuyBtn.Click
        If TextBox1.Text = "" Then
            MsgBox("請輸入存編!", 16, "錯誤")
            Exit Sub
        End If

        Dim Ans As Boolean
        Ans = chkItemCode(TextBox1.Text)
        If Ans = False Then
            MsgBox("存編錯誤!請重新輸入!", 16, "錯誤")
            TextBox1.Text = ""
            TextBox1.Focus()
            Exit Sub
        End If

        Quy()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Return Then
            If TextBox1.Text = "" Then
                MsgBox("請輸入存編!", 16, "錯誤")
                Exit Sub
            End If

            Dim Ans As Boolean
            Ans = chkItemCode(TextBox1.Text)
            If Ans = False Then
                MsgBox("存編錯誤!請重新輸入!", 16, "錯誤")
                TextBox1.Text = ""
                TextBox1.Focus()
                Exit Sub
            End If

            Quy()
        End If
    End Sub

    Private Sub Quy()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter

        sql = "exec  L201105181 '" & TextBox1.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        DGV1.DataSource = ks1DataSet.Tables("DT1")
        DGV1Display()

    End Sub

    Private Function chkItemCode(ByVal Itemcode As String)
        Dim oAns As Boolean

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT T0.ItemCode FROM OITM T0 WHERE T0.ItemCode = '" & Itemcode & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            oAns = False
        Else
            oAns = True
        End If

        sqlReader.Close()
        Return oAns
    End Function

    Private Sub DGV1Display()

        If DGV1.RowCount <= 0 Then
            MsgBox("查不到資料!請確認條碼是否正確!")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "m1"
                    column.HeaderText = "存貨編號"
                    column.DisplayIndex = 0
                Case "m2"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                Case "m3"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 2
                Case "m4"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 3
                Case "m5"
                    column.HeaderText = "製造日期"
                    column.DisplayIndex = 4
                Case "m6"
                    column.HeaderText = "儲位總數"
                    column.DisplayIndex = 5
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

        sql = "select T0.ItemCode as '存貨編號',T2.ItemName as '品名' , COUNT (T0.ItemCode) as '數量',T0.MnfDate  as '製造日期' from OSRN T0  left join OSRQ T1 ON T0.ItemCode = T1.ItemCode AND T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.ItemCode = T2.ItemCode where T1.Quantity > 0 and T0.U_M2 = '" & DGV1.CurrentRow.Cells("m3").Value & "' Group by T0.ItemCode,T2.ItemName ,T0.MnfDate"

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
End Class