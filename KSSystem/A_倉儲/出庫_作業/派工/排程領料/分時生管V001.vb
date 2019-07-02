Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks.Printing
Imports Microsoft.Reporting.WinForms

Public Class 分時生管V001
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet

    Private Sub 分時生管_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Bu查詢.Text = "重新查詢" Then
            Bu查詢.PerformClick()
        End If
    End Sub

    Private Sub 分時生管_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 680)
        La單號.Text = ""
        La同意.Text = ""
        La發貨.Text = ""

    End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        Select Case Bu查詢.Text
            Case "查詢製單"
                T1同意領料載入()
                Dt日期.Enabled = False : Bu查詢.Text = "重新查詢"

            Case "重新查詢"
                If T1派工明細.RowCount > 0 Then : 顯示資料.Tables("同意").Clear() : End If '清除資料
                If T1項目明細A.RowCount > 0 Then : 顯示資料.Tables("項目明細").Clear() : End If '清除資料
                Dt日期.Enabled = True : Bu查詢.Text = "查詢製單"

        End Select
    End Sub

    Private Sub T1同意領料載入()
        If T1派工明細.RowCount > 0 Then : 顯示資料.Tables("同意").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery += " EXEC [dbo].[預_分時領料明細01v] 'AE',N'',N'','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "',NULL "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "同意")
            T1派工明細.DataSource = 顯示資料.Tables("同意")
            T1同意領料明細顯示()
            T1派工明細.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("分時領料：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T1同意領料明細顯示()
        For Each column As DataGridViewColumn In T1派工明細.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "分時領料單" : column.HeaderText = "分時領料單" : column.DisplayIndex = 0 : column.Frozen = True
                Case "排程時間" : column.HeaderText = "排程時間" : column.DisplayIndex = 1
                Case "同意" : column.HeaderText = "同意" : column.DisplayIndex = 2
                Case "同意代碼" : column.HeaderText = "同意代碼" : column.DisplayIndex = 3 : column.Visible = False
                Case "發貨單號" : column.HeaderText = "發貨單號" : column.DisplayIndex = 4
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T1派工明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1派工明細.CellClick
        If T1派工明細.RowCount = 0 Then : Exit Sub : End If
        La單號.Text = T1派工明細.CurrentRow.Cells("分時領料單").Value
        La同意.Text = T1派工明細.CurrentRow.Cells("同意").Value
        La發貨.Text = T1派工明細.CurrentRow.Cells("發貨單號").Value
        T1項目明細A載入()
        T1項目明細B載入()
    End Sub

    Private Sub T1項目明細A載入()
        If T1項目明細A.RowCount > 0 Then : 顯示資料.Tables("項目明細A").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery += " EXEC [dbo].[預_分時領料明細01v] 'ADB',N'" & La單號.Text & "',N'',NULL,NULL "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "項目明細A")
            T1項目明細A.DataSource = 顯示資料.Tables("項目明細A")
            'T1項目明細顯示()
            T1項目明細A.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("項目明細A：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T1項目明細B載入()
        If T1項目明細B.RowCount > 0 Then : 顯示資料.Tables("項目明細B").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        If La發貨.Text = "" Then
            SQLQuery += " EXEC [dbo].[預_分時領料明細01v] 'ADC',N'" & La單號.Text & "',N'',NULL,NULL "
        Else
            SQLQuery += " EXEC [dbo].[預_分時領料明細01v] 'ADD',N'" & La發貨.Text & "',N'',NULL,NULL "
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "項目明細B")
            T1項目明細B.DataSource = 顯示資料.Tables("項目明細B")
            'T1項目明細顯示()
            T1項目明細B.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("項目明細B：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Bu同意_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu同意.Click
        Select Case La同意.Text
            Case "未決"
                Dim oAns As Integer
                oAns = MsgBox("確定同意?" & Chr(13) & vbCrLf & La單號.Text, MsgBoxStyle.OkCancel + 16, "同意")
                If oAns = MsgBoxResult.Ok Then
                    同意項目明細() : T1同意領料載入()
                    If T1項目明細A.RowCount > 0 Then : 顯示資料.Tables("項目明細A").Clear() : End If '清除資料
                    If T1項目明細B.RowCount > 0 Then : 顯示資料.Tables("項目明細B").Clear() : End If '清除資料
                    MsgBox(La單號.Text & "單據已同意") : La單號.Text = "" : La同意.Text = ""
                End If
            Case "同意" : MsgBox("單據已同意無法修改")
            Case "不同意" : MsgBox("單據不同意無法修改")
            Case Else
        End Select

    End Sub

    Private Sub 同意項目明細()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[倉_分時項目確認] "
            SQLCmd.CommandText += "   SET [項目同意] = 'Y', "
            SQLCmd.CommandText += "       [同意時間] = GETDATE(), "
            SQLCmd.CommandText += "       [電腦代碼] = '" & System.Net.Dns.GetHostName() & "' "
            SQLCmd.CommandText += "  FROM [KaiShingPlug].[dbo].[倉_分時項目確認] WHERE [分時領料單] = '" & La單號.Text & "' AND [項目同意] = 'N' "

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class