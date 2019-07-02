Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QueryFIMainStatus
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QueryFIMainStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If enterFI102.Text = "" Then
            MsgBox("請輸入生產單號", 48, "警告")
            Exit Sub
        End If

        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        LoadSourceMain()
    End Sub

    '依作業類別載入欲入庫製單號, 並指派給dgvSourceMain
    Private Sub LoadSourceMain()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If RB1.Checked = True Then
                sql = "SELECT top 10 FI101 as '生產單號', case FI103 when '1' then '進行中' when '2' then'已產生列印' when '3' then'已完工確認' when '4' then'已入B1' end  as '狀態' FROM [@FI1Main]  where FI101 = '" & enterFI102.Text & "'"
            End If

            If RB2.Checked = True Then
                sql = "SELECT top 10 FI101 as '生產單號', case FI103 when '1' then '進行中' when '2' then'已產生列印' when '3' then'已完工確認' when '4' then'已入B1' end  as '狀態' FROM [@FI1Main]  where FI101 = '" & enterFI102.Text & "'"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try
        dgvSourceMain.AutoResizeColumns()

    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(dgvSourceMain, "")
    End Sub
End Class