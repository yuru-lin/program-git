Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 訂單自動比對V100
    Dim DataAdapterDGV As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet

    '暫存資料庫名
    Dim INPDA1 As String = ""
    Dim INPDA2 As String = ""
    Dim INPDA3 As String = ""

    Private Sub 訂單自動比對_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        即時時間.Enabled = True
        即時時間.Interval = 100
        比對作業()
    End Sub

    Private Sub 訂單自動比對_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 即時時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 即時時間.Tick
        '電腦時間.Text = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        電腦時間.Text = Now()

        Select Case Format(Now(), "mm") '依分鐘為單位
            Case "00", "15", "30", "45"
                比對作業()
        End Select

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click
        比對作業()
    End Sub

    Private Sub 比對作業()
        提單比對作業()
        異常比對作業1()
        異常比對作業2()
    End Sub


    Private Sub 提單比對作業()
        If 提單.RowCount > 0 Then : 顯示資料.Tables("提單").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = ""

        'SQLQuery = "    SELECT [草稿],[存編],[品名],[出貨數量],[刷入數量],[比對結果],[超過數量],[未達數量] "
        SQLQuery = "    SELECT [草稿],[品名],[出貨數量],[刷入數量],[比對結果],[超過數量],[未達數量] "
        SQLQuery += "     FROM [KaiShing].[dbo].[檢_交貨草稿結果] "
        'SQLQuery += "    WHERE [比對結果] = '未完成' "
        SQLQuery += " ORDER BY [草稿], [列號] "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "提單")
            提單.DataSource = 顯示資料.Tables("提單")
            提單.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("提單載入異常：" & ex.Message)
        End Try

    End Sub

    Private Sub 異常比對作業1()
        If 異常.RowCount > 0 Then : 顯示資料.Tables("異常").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = ""

        SQLQuery = "    SELECT T1.[交貨草稿], T1.[存編] "
        SQLQuery += "     FROM [檢_交貨草稿比對] T1, [檢_交貨草稿明細] T0 "
        SQLQuery += "    WHERE  T1.[交貨草稿] = T0.草稿 AND (T1.[數量] <> 0) AND T1.[存編] <> T0.存編 "
        SQLQuery += " GROUP BY T1.[交貨草稿], T1.[存編] "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "異常")
            異常.DataSource = 顯示資料.Tables("異常")
            異常.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("異常載入異常：" & ex.Message)
        End Try

    End Sub

    Private Sub 異常比對作業2()
        If 異常2.RowCount > 0 Then : 顯示資料.Tables("異常2").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = ""

        SQLQuery += "     SELECT T1.[交貨草稿], T1.[存編],T1.[品名],T1.[條碼] "
        SQLQuery += "     FROM [檢_交貨草稿比對] T1 "
        SQLQuery += "    WHERE (T1.[數量] = 0) "
        SQLQuery += " GROUP BY T1.[交貨草稿], T1.[存編],T1.[數量] "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "異常2")
            異常2.DataSource = 顯示資料.Tables("異常2")
            異常2.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("異常載入異常：" & ex.Message)
        End Try

    End Sub






End Class