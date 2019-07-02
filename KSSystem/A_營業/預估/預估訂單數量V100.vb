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
'

Public Class 預估訂單數量V100
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet

    Private Sub 預估訂單數量_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cb客戶.SelectedIndex = -1
        DGV日期載入()
    End Sub

    Private Sub DGV日期載入()
        If DGV日期.RowCount > 0 Then : 顯示資料.Tables("日期載入").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = "  DECLARE @DATE1 DATE "
        SQLQuery += " DECLARE @DATE2 DATE "
        SQLQuery += " SET NOCOUNT ON "
        SQLQuery += " SET @DATE1 = GETDATE() "
        SQLQuery += " SET @DATE2 = DATEADD(D,+14,@DATE1) "
        SQLQuery += " SET @DATE1 = DATEADD(D,-60,@DATE1) "

        SQLQuery += "    SELECT DATEADD(D,ROWS - 1,@DATE1) AS '日期開始',DATEADD(D,ROWS + 6,@DATE1) AS '日期結束' "
        SQLQuery += "      FROM (SELECT ID,ROW_NUMBER()OVER(ORDER BY ID) ROWS "
        SQLQuery += "              FROM SYSOBJECTS )TMP "
        SQLQuery += "     WHERE (TMP.ROWS <= DATEDIFF(D,@DATE1, @DATE2) + 1) AND DATEPART(WEEKDAY,DATEADD(D,ROWS - 1,@DATE1)) = 6 "
        SQLQuery += "  ORDER BY 1 DESC "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "日期載入")
            DGV日期.DataSource = 顯示資料.Tables("日期載入")
            DGV日期.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("日期載入：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Bu選擇_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu選擇.Click
        If Cb客戶.SelectedIndex = -1 Then : MsgBox("客戶未選擇") : Exit Sub : End If
        Cb客戶.Enabled = False
        Bu選擇.Enabled = False
    End Sub

    Private Sub DGV日期_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV日期.CellClick
        If Cb客戶.SelectedIndex <> -1 And Bu選擇.Enabled = False Then
            預估數量載入()
        End If

    End Sub

    Private Sub 預估數量載入()
        If 預估數量.RowCount > 0 Then : 顯示資料.Tables("預估數量").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_預估數量01v] '" & DGV日期.CurrentRow.Cells("日期開始").Value & "','" & Cb客戶.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "預估數量")
            預估數量.DataSource = 顯示資料.Tables("預估數量")
            預估數量.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("預估數量：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    'Private Sub 預估數量_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 預估數量.CellEndEdit
    '    ' 由編輯資料列時 計算結果
    '    'If 預估數量.RowCount = 0 And Bu選擇.Enabled = True Then : Exit Sub : End If
    '    Dim 數量 As Single = 0
    '    Dim 數量1 As Single = 0 : Dim 數量2 As Single = 0 : Dim 數量3 As Single = 0 : Dim 數量4 As Single = 0
    '    Dim 數量5 As Single = 0 : Dim 數量6 As Single = 0 : Dim 數量7 As Single = 0 : Dim 數量8 As Single = 0

    '    If e.ColumnIndex = CType(sender, DataGridView).Columns("簡稱").Index Then
    '        MsgBox(e.ColumnIndex)
    '        'If CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("退貨數量").Value) > CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("數量").Value) Then
    '        '    CType(sender, DataGridView).Rows(e.RowIndex).Cells("退貨數量").Value = 0
    '        '    MsgBox("退貨數量不可大於可退數量")
    '        '    Exit Sub
    '        'End If
    '        '數量1 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期五").Value)
    '        '數量2 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期六").Value)
    '        '數量3 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期日").Value)
    '        '數量4 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期一").Value)
    '        '數量5 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期二").Value)
    '        '數量6 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期三").Value)
    '        '數量7 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期四").Value)
    '        '數量8 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期五.").Value)
    '        '數量 = (CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期五").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期六").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期日").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期一").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期二").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期三").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期四").Value) + CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期五.").Value))
    '        '數量 = 數量1 + 數量2 + 數量3 + 數量4 + 數量5 + 數量6 + 數量7 + 數量8
    '        數量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("星期五").Value)
    '        CType(sender, DataGridView).Rows(e.RowIndex).Cells("總數量").Value = Math.Round(數量)
    '    End If
    '    'MsgBox(數量 & "," & 數量1)


    'End Sub



    Private Sub Bu存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu存檔.Click
        If 預估數量.RowCount = 0 Then : Exit Sub : End If

        'Dim 數量 As Integer = 0
        'For i As Integer = 0 To 預估數量.RowCount - 1
        '    數量 = 數量 + 預估數量.Rows(i).Cells("總數量").Value
        'Next

        'If 數量 <> 0 Then
        預估數量存檔()
        If 預估數量.RowCount > 0 Then : 顯示資料.Tables("預估數量").Clear() : End If '清除資料
        Cb客戶.Enabled = True
        Bu選擇.Enabled = True
        'Else
        'MsgBox("總數量 = 0 無法存檔")
        'End If

    End Sub

    Private Sub 預估數量存檔()
        Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        '修正_先作廢
        SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[營_預估數量] "
        SQLADD1 += "    SET [啟用否]     = 'N', "
        SQLADD1 += "        [修改時間] = GETDATE() "
        SQLADD1 += "  WHERE [日期開始] = '" & DGV日期.CurrentRow.Cells("日期開始").Value & "' AND [廠商簡稱] = '" & Cb客戶.Text & "' AND [啟用否] = 'Y' " & vbCrLf
        For i As Integer = 0 To 預估數量.RowCount - 1
            SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[營_預估數量] "
            SQLADD2 += " ([日期開始],[日期結束],[廠商簡稱],[排列順序],[ItemCode],[品名簡稱],[星期五],[星期六],[星期日],[星期一],[星期二],[星期三],[星期四],[星期五2],[新增時間],[新增人員],[啟用否]) VALUES "
            SQLADD2 += " ('" & DGV日期.CurrentRow.Cells("日期開始").Value & "', "
            SQLADD2 += "  '" & DGV日期.CurrentRow.Cells("日期結束").Value & "', "
            SQLADD2 += "  '" & Cb客戶.Text & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("排列順序").Value & "', "
            SQLADD2 += "  '', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("品名簡稱").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期五").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期六").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期日").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期一").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期二").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期三").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期四").Value & "', "
            SQLADD2 += "  '" & 預估數量.Rows(i).Cells("星期五.").Value & "', "
            SQLADD2 += "  GETDATE(),'','Y' ) " & vbCrLf

        Next
        ''修正_先作廢
        'SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[品_退貨明細] "
        'SQLADD1 += "    SET [啟用]     = 'N', "
        'SQLADD1 += "        [修改時間] = GETDATE() "
        'SQLADD1 += "  WHERE [單號] = '" & 單號 & "' AND 啟用 = 'Y' " & vbCrLf

        'For i As Integer = 0 To T4退貨記錄.RowCount - 1
        '    SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[品_退貨明細] "
        '    SQLADD2 += " ([單號],[IDSave],[存貨編號],[品_退貨數量],[品_退貨原因],[品_相符],[品_退貨情況],[品_退貨結果],[品_補充說明],[啟用],[新增時間]) VALUES "
        '    SQLADD2 += " ('" & 單號 & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("IDS").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("存貨編號").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("確認數量").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("原因代碼").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("相符代碼").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("情況代碼").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("結果代碼").Value & "', "
        '    SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("補充說明").Value & "', "
        '    SQLADD2 += "  'Y',GETDATE() ) "
        'Next
        ''MsgBox(SQLADD1 + SQLADD2)

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub Bu放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu放棄.Click
        If 預估數量.RowCount = 0 Then : Exit Sub : End If
        If 預估數量.RowCount > 0 Then : 顯示資料.Tables("預估數量").Clear() : End If '清除資料
        Cb客戶.SelectedIndex = -1
        Cb客戶.Enabled = True
        Bu選擇.Enabled = True
    End Sub
End Class