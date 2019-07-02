Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 上傳訂單統計V001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet

    Private Sub 上傳訂單統計V001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        Bu7查詢_作業()
    End Sub

    Private Sub Bu7查詢_作業()
        If DGV7.RowCount > 0 Then : 顯示資料.Tables("訂單統計").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = "" : Dim SQLUP1 As String = "" : Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        SQLQuery += " EXEC [KaiShingPlug].[dbo].[預_好市多統計01v1] "
        SQLQuery += " N'" & Format(D7日期1.Value, "yyyy-MM-dd") & "',N'" & Format(D7日期2.Value, "yyyy-MM-dd") & "' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "訂單統計") : DGV7.DataSource = 顯示資料.Tables("訂單統計") : DGV7.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("時段比對查詢異常：" & ex.Message)
        End Try


    End Sub

    Private Sub Bu7匯出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu7匯出.Click
        If DGV7.RowCount = 0 Then : Exit Sub : End If
        DataToExcel(DGV7, "好市多訂單統計" & Format(D7日期1.Value, "yyyy-MM-dd") & "-" & Format(D7日期2.Value, "yyyy-MM-dd"))
    End Sub

End Class