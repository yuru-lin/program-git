Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 比對表_v100
    Dim DataAdapterDGV As SqlDataAdapter
    'Dim 下拉明細 As DataSet = New DataSet
    Dim 顯示資料 As DataSet = New DataSet
    Dim 單位 As String = ""
    Dim 資料 As String = "無"

    Private Sub 比對表_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lt2日期.Text = ""
        項目.SelectedIndex = 0
    End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        比對表查詢()
        Lt2日期.Text = Format(日期.Value.Date, "yyyy-MM-dd")
    End Sub

    Private Sub 比對表查詢()
        'If CB時段.Checked = True Then : Exit Sub : End If
        If DGV1.RowCount > 0 Then : 顯示資料.Tables("比對表").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = "" ': Dim SQLQuery2 As String = ""

        'SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_時段比對01v2] "
        'SQLQuery += " N'" & Lt2日期.Text & "',N'" & Lt2樓層.Text & "',N'" & Lt2時段.Text & "' "


        'SQLQuery = " EXEC [KaiShing].[dbo].[預_比對表_v100] "
        SQLQuery = " EXEC [dbo].[預_比對表_v101] "
        SQLQuery += " N'" & Format(日期.Value.Date, "yyyy-MM-dd") & "',N'" & 項目.SelectedIndex & "',N'%" & ItemName.Text & "%' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "比對表") : DGV1.DataSource = 顯示資料.Tables("比對表") : DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("比對表記錄查詢：" & ex.Message)
        End Try
    End Sub
End Class