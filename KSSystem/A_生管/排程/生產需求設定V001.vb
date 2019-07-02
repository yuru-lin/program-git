Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 生產需求設定V001
    Dim MSSQL作業 As SqlDataAdapter
    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable
    'Dim DataAdapterDGV As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet

    Private Sub 生產需求設定_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PL設定.Location = New Point(2, 2)   '移到正確位置
        'DGV1.RowHeadersWidth = 0    '不顯示列首設定
        'DGV2.RowHeadersWidth = 0    '不顯示列首設定
        需求存編載入()
        L1日期.Text = ""
        Bu1新增.Enabled = False : Bu1修改.Enabled = False : Bu1刪除.Enabled = False
        初始載入()

    End Sub

    Private Sub 初始載入()
        L1存編.Text = ""
        L1品名.Text = ""
        L1單位.Text = "" : L1代碼.Text = ""
        T1需求.Text = ""
        L1ID.Text = ""
    End Sub

    Private Sub Bu設定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1設定.Click
        'PL設定.Visible = True
        DGV2.Visible = True
        L1日期.Text = Format(日期.Value.Date, "yyyy-MM-dd")
        需求存編載入() : 需求明細載入() ': 明細存編比對()
        If DGV1.RowCount > 0 Then : 明細存編比對() : End If
        Bu1新增.Enabled = True : Bu1修改.Enabled = True : Bu1刪除.Enabled = True

    End Sub

    Private Sub 需求存編載入()
        If DGV2.RowCount > 0 Or DGV1.RowCount > 0 Then : 顯示資料.Tables("需求存編").Clear() : dt1.Clear() : dt2.Clear() : End If '清除DGV2資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""
        SQLQuery = "   SELECT T1.[ItemName] AS '品名',[存編],CASE T0.[單位] WHEN '0' THEN '公斤' WHEN '1' THEN '件數' WHEN '2' THEN '小單位'ELSE '異常' END AS '單位',T0.[單位] AS '代碼' "
        SQLQuery += "    FROM [KaiShingPlug].[dbo].[生_需求存編] T0 INNER JOIN [OITM] T1 ON T0.[存編] = T1.[ItemCode] "
        SQLQuery += "   WHERE T0.[啟用否] = 'Y' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            MSSQL作業 = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            MSSQL作業.Fill(顯示資料, "需求存編") ': DGV2.DataSource = 顯示資料.Tables("需求存編").Copy : DGV2.AutoResizeColumns()
            dt1 = 顯示資料.Tables("需求存編").Copy
            dt2 = 顯示資料.Tables("需求存編").Copy
            DGV2.DataSource = dt1
            DGV2.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("需求存編載入：" & ex.Message)
        End Try
    End Sub

    Private Sub 需求明細載入()
        If DGV1.RowCount > 0 Then : 顯示資料.Tables("需求明細").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""
        SQLQuery = "   SELECT T1.[ItemName] AS '品名',T0.[存編],T0.[數量], "
        SQLQuery += "         CASE T0.[單位] WHEN '0' THEN '公斤' WHEN '1' THEN '件數' WHEN '2' THEN '小單位'ELSE '異常' END AS '單位',T0.[單位] AS '代碼',T0.[ID] "
        SQLQuery += "    FROM [KaiShingPlug].[dbo].[生_需求設定] T0 INNER JOIN [OITM] T1 ON T0.[存編] = T1.[ItemCode] "
        SQLQuery += "   WHERE T0.[日期] = '" & L1日期.Text & "' AND T0.[啟用否] = 'Y' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            MSSQL作業 = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            MSSQL作業.Fill(顯示資料, "需求明細") : DGV1.DataSource = 顯示資料.Tables("需求明細") : DGV1.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("需求明細載入：" & ex.Message)
        End Try
    End Sub

    Private Sub DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount <> 0 Then
            L1存編.Text = DGV2.CurrentRow.Cells("存編").Value
            L1品名.Text = DGV2.CurrentRow.Cells("品名").Value
            L1單位.Text = DGV2.CurrentRow.Cells("單位").Value
            L1代碼.Text = DGV2.CurrentRow.Cells("代碼").Value
            'T1需求.Text = ""
        End If

    End Sub

    Private Sub Bu1新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1新增.Click
        If T1需求.Text = "" And L1存編.Text = "" Then : MsgBox("資料不完整無法新增資料") : Exit Sub : End If
        Select Case Bu1新增.Text
            Case "新增"
                'Dim Row As DataRow
                'Row = 顯示資料.Tables("需求明細").NewRow
                'Row.Item("存編") = L1存編.Text
                'Row.Item("品名") = L1品名.Text
                'Row.Item("數量") = T1需求.Text
                'Row.Item("單位") = L1單位.Text
                'Row.Item("代碼") = L1代碼.Text
                '顯示資料.Tables("需求明細").Rows.Add(Row)
                明細存編存檔("1") : 需求明細載入() : 明細存編比對()
            Case "存檔"
                明細存編存檔("1") : 需求明細載入()
                Bu1修改.Text = "修改" : Bu1新增.Text = "新增" : DGV2.Visible = True : Bu1刪除.Enabled = True : DGV1.Location = New Point(6, 287)   '移到正確位置
                Bu1設定.Enabled = True
            Case Else
        End Select
        初始載入()

    End Sub

    Private Sub 明細存編存檔(ByVal T As String)
        Dim SQLADD As String = ""
        Select Case T
            Case "1"    '新增&存檔
                Select Case Bu1新增.Text
                    Case "新增"
                        SQLADD = "  INSERT INTO [KaiShingPlug].[dbo].[生_需求設定] "
                        SQLADD += "  ([日期],[存編],[單位],[數量],[新增時間],[啟用否]) VALUES "
                        SQLADD += "  ('" & L1日期.Text & "', '" & L1存編.Text & "', '" & L1代碼.Text & "', '" & T1需求.Text & "', GETDATE(), 'Y' )"
                    Case "存檔"
                        SQLADD = " UPDATE [KaiShingPlug].[dbo].[生_需求設定] SET [數量] = '" & T1需求.Text & "',[修改時間] = GETDATE() WHERE [ID] = '" & L1ID.Text & "' "
                    Case Else
                End Select
            Case "2"    '刪除
                SQLADD = " UPDATE [KaiShingPlug].[dbo].[生_需求設定] SET [啟用否] = 'N' WHERE [ID] = '" & DGV1.CurrentRow.Cells("ID").Value & "' "
            Case Else
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 明細存編比對()
        If DGV2.RowCount > 0 Then : dt1.Clear() : End If '清除dt1資料
        dt1 = dt2.Copy : DGV2.DataSource = dt1

        Dim counti As Integer = DGV1.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim countx As Integer = DGV2.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If DGV1.Rows(i).Cells("存編").Value = DGV2.Rows(x).Cells("存編").Value Then
                    DGV2.Rows.Remove(DGV2.Rows(x))
                End If
            Next
        Next

    End Sub

    Private Sub Bu1修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1修改.Click
        If DGV1.RowCount = 0 Then : MsgBox("無資料可修改") : Exit Sub : End If
        Select Case Bu1修改.Text
            Case "修改" : Bu1修改.Text = "放棄" : Bu1新增.Text = "存檔" : DGV2.Visible = False : Bu1刪除.Enabled = False : DGV1.Location = New Point(6, 105)   '移到正確位置
                Bu1設定.Enabled = False
            Case "放棄" : Bu1修改.Text = "修改" : Bu1新增.Text = "新增" : DGV2.Visible = True : Bu1刪除.Enabled = True : DGV1.Location = New Point(6, 287)   '移到正確位置
                Bu1設定.Enabled = True
            Case Else
        End Select
        初始載入()
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        Select Case Bu1修改.Text
            'Case "修改"
            '    If DGV1.RowCount <> 0 Then
            '        L1存編.Text = DGV1.CurrentRow.Cells("存編").Value
            '        L1品名.Text = DGV1.CurrentRow.Cells("品名").Value
            '        L1單位.Text = DGV1.CurrentRow.Cells("單位").Value
            '        L1代碼.Text = DGV1.CurrentRow.Cells("代碼").Value
            '        T1需求.Text = DGV1.CurrentRow.Cells("需求").Value
            '    End If
            Case "放棄"
                If DGV1.RowCount <> 0 Then
                    L1存編.Text = DGV1.CurrentRow.Cells("存編").Value
                    L1品名.Text = DGV1.CurrentRow.Cells("品名").Value
                    L1單位.Text = DGV1.CurrentRow.Cells("單位").Value
                    L1代碼.Text = DGV1.CurrentRow.Cells("代碼").Value
                    T1需求.Text = DGV1.CurrentRow.Cells("數量").Value
                    L1ID.Text = DGV1.CurrentRow.Cells("ID").Value
                End If
            Case Else
        End Select
    End Sub

    Private Sub Bu1刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1刪除.Click
        If DGV1.RowCount = 0 Then : MsgBox("未查詢或無資料可以刪除", 16, "錯誤") : Exit Sub : End If
        Dim oAns As Integer
        oAns = MsgBox("是否執行" & DGV1.CurrentRow.Cells("品名").Value & DGV1.CurrentRow.Cells("存編").Value & " 刪除需求", MsgBoxStyle.YesNo, "刪除需求")
        If oAns = MsgBoxResult.Yes Then  'Yes執行區
            明細存編存檔("2") : 需求明細載入() : 明細存編比對()
        End If

    End Sub
End Class