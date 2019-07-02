Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class A_ContractSettlement
    Dim ksDataSet As DataSet = New DataSet

    Private Sub A_ContractSettlement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV4.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV5.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub txtFarmName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFarmName.Click
        If txtFarmName.Text = "" Then
            SelectFarmName.Source = "Settlement"
            SelectFarmName.MdiParent = MainForm
            SelectFarmName.Show()
        End If
    End Sub

    Private Sub txtFarmID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFarmID.Click
        If txtFarmID.Text = "" Then
            SelectFarmName.Source = "Settlement"
            SelectFarmName.MdiParent = MainForm
            SelectFarmName.Show()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtFarmName.Text = "" Then
            MsgBox("契養名稱未填!", 16, "錯誤")
            Exit Sub
        End If
        If txtFarmID.Text = "" Then
            MsgBox("契養批號未填!", 16, "錯誤")
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ksDataSet.Tables("DT1").Clear()
        End If
        If DGV2.RowCount > 0 Then
            ksDataSet.Tables("DT2").Clear()
        End If
        If DGV3.RowCount > 0 Then
            ksDataSet.Tables("DT3").Clear()
        End If
        If DGV4.RowCount > 0 Then
            ksDataSet.Tables("DT4").Clear()
        End If
        If DGV5.RowCount > 0 Then
            ksDataSet.Tables("DT5").Clear()
        End If

        LoadDGV1()
        LoadDGV2()
        LoadDGV3()
        LoadDGV4()
        LoadDGV5()
    End Sub

    Private Sub LoadDGV1()
        Dim DataAdapter1 As SqlDataAdapter        
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            sql = "exec MKS912V2401B '" & txtFarmID.Text & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT1")
            DGV1.DataSource = ksDataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadDGV1: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "過帳日期"
                    column.DisplayIndex = 0
                Case "代碼"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "數量"
                    column.DisplayIndex = 3
                Case "單價"
                    column.DisplayIndex = 4
                Case "金額"
                    column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.AutoResizeColumns()
    End Sub

    Private Sub LoadDGV2()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            sql = "exec MKS912V2401C '" & txtFarmID.Text & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT2")
            DGV2.DataSource = ksDataSet.Tables("DT2")
        Catch ex As Exception
            MsgBox("LoadDGV2: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "過帳日期"
                    column.DisplayIndex = 0
                Case "代碼"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "數量"
                    column.DisplayIndex = 3
                Case "單價"
                    column.DisplayIndex = 4
                Case "金額"
                    column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.AutoResizeColumns()
    End Sub

    Private Sub LoadDGV3()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            sql = "exec MKS912V2401D '" & txtFarmID.Text & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT3")
            DGV3.DataSource = ksDataSet.Tables("DT3")
        Catch ex As Exception
            MsgBox("LoadDGV3: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True
            Select Case column.Name
                Case "過帳日期"
                    column.DisplayIndex = 0
                Case "代碼"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "隻數"
                    column.DisplayIndex = 3                    
                Case "毛重"
                    column.DisplayIndex = 4
                Case "單價"
                    column.DisplayIndex = 5
                Case "金額"
                    column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV3.AutoResizeColumns()
    End Sub

    Private Sub LoadDGV4()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            sql = "exec MKS912V2401E '" & txtFarmID.Text & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT4")
            DGV4.DataSource = ksDataSet.Tables("DT4")
        Catch ex As Exception
            MsgBox("LoadDGV4: " & ex.Message)
            End
        End Try
        For Each column As DataGridViewColumn In DGV4.Columns
            column.Visible = True
            Select Case column.Name
                Case "過帳日期"
                    column.DisplayIndex = 0
                Case "代碼"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "數量"
                    column.DisplayIndex = 3
                Case "單價"
                    column.DisplayIndex = 4
                Case "金額"
                    column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV4.AutoResizeColumns()
    End Sub

    Private Sub LoadDGV5()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            sql = "exec MKS912V2401F '" & txtFarmID.Text & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT5")
            DGV5.DataSource = ksDataSet.Tables("DT5")
        Catch ex As Exception
            MsgBox("LoadDGV5: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In DGV5.Columns
            column.Visible = True
            Select Case column.Name
                Case "過帳日期"
                    column.DisplayIndex = 0
                Case "代碼"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "數量"
                    column.DisplayIndex = 3
                Case "單價"
                    column.DisplayIndex = 4
                Case "金額"
                    column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV5.AutoResizeColumns()
    End Sub

    Private Sub btnToReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToReport.Click
        A_ReportViewer.MdiParent = MainForm

        A_ReportViewer.Source = "ContractSettlement"
        A_ReportViewer.strPara(0) = txtFarmName.Text
        A_ReportViewer.strPara(1) = txtFarmID.Text

        A_ReportViewer.dt1 = ksDataSet.Tables("DT1")
        A_ReportViewer.dt2 = ksDataSet.Tables("DT2")
        A_ReportViewer.dt3 = ksDataSet.Tables("DT3")
        A_ReportViewer.dt4 = ksDataSet.Tables("DT4")
        A_ReportViewer.dt5 = ksDataSet.Tables("DT5")
       
        A_ReportViewer.Show()
    End Sub
End Class