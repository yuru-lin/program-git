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


Public Class 分時領料V001
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim 目前作業 As String = ""
    Dim 選擇作業 As String = "Y"
    Dim 列印後續 As String = "Y"
    Dim PrinterName As String '列印機選擇


    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl1.Selected
        'MsgBox(TabControl1.SelectedTab.Text)
        Select Case 目前作業
            Case "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
            Case "領料作業" : Me.TabControl1.SelectedTab = Me.TP領料作業
                'Case "退貨入庫" : Me.TabControl1.SelectedTab = Me.TP退貨入庫
            Case Else
        End Select

    End Sub

    Private Sub 分時領料_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Remove(TP領料作業)
        目前作業 = "單據查詢" : Lt作業.Text = "單據查詢"
        Me.Size = New Size(1200, 680)
        Cb印表機()
        時段載入()
        La1派次.Text = ""
        La領料.Text = ""
        '條碼列印V100.Show()
        '條碼列印V100.Hide()
        '條碼列印V100.Close()

    End Sub

    Private Sub Cb印表機()
        Dim 預設印表機 As New PrintDocument()
        'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName
        Dim i As Integer : Dim 所有印表機 As String = ""
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
            'If 所有印表機 Like "*[!TTP-243]*" Or 所有印表機 Like "*[!TTP-247]*" Then
            Cb1印表機.Items.Add(所有印表機)
            'End If
        Next
        'Cb1印表機.SelectedIndex = 0
        Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName
    End Sub

    Private Sub 時段載入()
        Dim SQLQuery As String = ""
        'SQLQuery = " SELECT [ID] AS '代碼',[TimePeriod] AS '類別' FROM [KaiShingPlug].[dbo].[UB07_TimePeriod] ORDER BY [ID] "
        SQLQuery = PM_Lists.Schedule_Lists()

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn) : MSSQL作業.Fill(顯示資料, "時段資料")

            Cb時段.DataSource = 顯示資料.Tables("時段資料").Copy
            Cb時段.DisplayMember = "類別"    '名稱
            Cb時段.ValueMember = "代碼A"      '編號
            Cb時段.SelectedIndex = -1
            Cb數層.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("時段資料: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    'Private Sub Cb時段_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb時段.SelectedIndexChanged
    '    If Cb時段.SelectedIndex <> -1 Then
    '        領料時段載入()
    '    End If
    'End Sub

    Private Sub 領料時段載入()
        Dim dt As DataTable = 顯示資料.Tables("時段資料").Copy
        '2-建立條件
        Dim oCriteria As String = "代碼A = '" & Cb時段.SelectedValue & "' "
        '3-建立新陣列表 DataRow
        Dim FoundRow() As DataRow
        '4-Select * Form DataTables Where 條件
        FoundRow = dt.Select(oCriteria)
        La領料.Text = Format(FoundRow(0)("領料"), "")
    End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click

        Select Case Bu查詢.Text
            Case "查詢製單"
                派次載入()
                T1分時領料載入() : T1分時領料明細顯示() : T1已派領料載入() : 領料時段載入()
                Dt日期.Enabled = False : Cb數層.Enabled = False : Cb時段.Enabled = False
                Bu查詢.Text = "重新查詢"

            Case "重新查詢"
                If T1派工明細.RowCount > 0 Then : 顯示資料.Tables("分時領料").Clear() : End If '清除資料
                If T1已派明細.RowCount > 0 Then : 顯示資料.Tables("已派領料").Clear() : End If '清除資料
                Dt日期.Enabled = True : Cb數層.Enabled = True : Cb時段.Enabled = True
                Bu查詢.Text = "查詢製單"

        End Select

        'If T1派工明細.RowCount > 0 Then : T1派工明細.CurrentCell = T1派工明細.Rows(0).Cells(0) : End If
    End Sub

    Private Sub 派次載入()
        If La1派次.Text <> "" Then : 顯示資料.Tables("派次").Clear() : End If
        Dim SQLADD As String = ""
        SQLADD = "  SELECT TOP 1 ISNULL(MAX([派次]),0) AS '派次' FROM [KaiShingPlug].[dbo].[倉_分時領料] "
        SQLADD += "  WHERE [日期] = '" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "' AND "
        SQLADD += "        [樓層代碼] = '" & (Cb數層.SelectedIndex + 1) & "' AND "
        SQLADD += "        [時段代碼] = '" & Cb時段.SelectedValue & "' "

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000 : SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MSSQL作業 = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            MSSQL作業.Fill(顯示資料, "派次")

            La1派次.Text = 顯示資料.Tables("派次").Rows(0).Item("派次")
            'If 顯示資料.Tables("派次").Rows(0).Item("條碼") = "" Then
            '    待用條碼 = TB單號.Text & "001"
            'Else
            '    新條碼(顯示資料.Tables("派次").Rows(0).Item("條碼"))
            'End If
            'La2條碼.Text = 待用條碼

        Catch ex As Exception
            MsgBox("派次載入: " & ex.Message)
        End Try

    End Sub


    Private Sub T1分時領料載入()
        If T1派工明細.RowCount > 0 Then : 顯示資料.Tables("分時領料").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_分時領料明細01v] 'AA','" & (Cb數層.SelectedIndex + 1) & "','" & Cb時段.SelectedValue & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "',NULL "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "分時領料")
            T1派工明細.DataSource = 顯示資料.Tables("分時領料")
            T1派工明細.AutoResizeColumns()

            If 選擇作業 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                checkBoxColumn.Width = 30
                T1派工明細.Columns.Insert(0, checkBoxColumn)
            End If
            選擇作業 = "N"
            T1分時領料載入False()
            'T1分時領料明細顯示()

        Catch ex As Exception
            MsgBox("分時領料：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Bu1全選_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1全選.Click
        T1分時領料載入True()
    End Sub

    Private Sub Bu1取消_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1取消.Click
        T1分時領料載入False()
    End Sub

    Private Sub T1分時領料載入True()
        Dim count As Integer = T1派工明細.Rows.Count
        For i As Integer = 0 To count - 1
            T1派工明細.Rows(i).Cells("選擇").Value = True
        Next
    End Sub

    Private Sub T1分時領料載入False()
        Dim count As Integer = T1派工明細.Rows.Count
        For i As Integer = 0 To count - 1
            T1派工明細.Rows(i).Cells("選擇").Value = False
        Next
    End Sub

    Private Sub T1分時領料明細顯示()
        For Each column As DataGridViewColumn In T1派工明細.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True : column.ReadOnly = False
                Case "樓層" : column.HeaderText = "樓層" : column.DisplayIndex = 1 : column.Frozen = True ': column.ReadOnly = False
                Case "排程時間" : column.HeaderText = "排程時間" : column.DisplayIndex = 2 : column.Frozen = True ': column.ReadOnly = False
                Case "領料時間" : column.HeaderText = "領料時間" : column.DisplayIndex = 3 : column.Frozen = True ': column.ReadOnly = False
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 4 : column.Frozen = True ': column.ReadOnly = False
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 5 : column.Frozen = True ': column.ReadOnly = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 6 : column.Frozen = True ': column.ReadOnly = False
                Case "派工數量" : column.HeaderText = "派工數量" : column.DisplayIndex = 7 : column.ReadOnly = False
                Case "已派數量" : column.HeaderText = "已派數量" : column.DisplayIndex = 8 ': column.ReadOnly = False
                Case "差異數量" : column.HeaderText = "差異數量" : column.DisplayIndex = 9 ': column.ReadOnly = False

                Case "分時領料單" : column.HeaderText = "分時領料單" : column.DisplayIndex = 10 : column.Visible = False ': column.ReadOnly = False
                Case "樓層代碼" : column.HeaderText = "樓層代碼" : column.DisplayIndex = 11 : column.Visible = False ': column.ReadOnly = False
                Case "時段代碼" : column.HeaderText = "時段代碼" : column.DisplayIndex = 12 : column.Visible = False ': column.ReadOnly = False

                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T1已派領料載入()
        If T1已派明細.RowCount > 0 Then : 顯示資料.Tables("已派領料").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_分時領料明細01v] 'AB','" & (Cb數層.SelectedIndex + 1) & "','" & Cb時段.SelectedValue & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "',NULL "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "已派領料")
            T1已派明細.DataSource = 顯示資料.Tables("已派領料")
            T1已派明細.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("已派領料：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Bu1派工_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1派工.Click
        T1分時領料存檔()
        If 列印後續 = "Y" Then
            'If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    PrinterName = PrintDialog.PrinterSettings.PrinterName
            'End If
            T1派工列印載入() : T1分時領料列印()
            T1分時領料載入() : T1分時領料明細顯示() : T1已派領料載入() : 派次載入()
        End If

    End Sub

    Private Sub T1分時領料存檔()

        Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        For Each oRow As DataGridViewRow In T1派工明細.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected = True Then
                SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[倉_分時領料] "
                SQLADD2 += " ([日期],[派次],[分時領料單],[樓層],[樓層代碼],[排程時間],[領料時間],[時段代碼],[製單],[存編],[品名],[派工數量],[啟用否],[新增時間]) VALUES "
                SQLADD2 += " ('" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "' , "
                SQLADD2 += "  '" & CInt(La1派次.Text) + 1 & "' , "
                SQLADD2 += "  '" & oRow.Cells("分時領料單").Value & "' , "
                SQLADD2 += "  '" & oRow.Cells("樓層").Value & "'     , "
                SQLADD2 += "  '" & oRow.Cells("樓層代碼").Value & "' , "
                SQLADD2 += "  '" & oRow.Cells("排程時間").Value & "' , "
                SQLADD2 += "  '" & oRow.Cells("領料時間").Value & "' , "
                SQLADD2 += "  '" & oRow.Cells("時段代碼").Value & "' , "
                SQLADD2 += "  '" & oRow.Cells("製單").Value & "'     , "
                SQLADD2 += "  '" & oRow.Cells("存編").Value & "'     , "
                SQLADD2 += "  '" & oRow.Cells("品名").Value & "'     , "
                SQLADD2 += "  '" & oRow.Cells("派工數量").Value & "' , "
                SQLADD2 += "  'Y', GETDATE() ) " & vbCrLf
              
            End If
        Next

        If SQLADD1 + SQLADD2 = "" Then : 列印後續 = "N" : MsgBox("無資料可派工") : Exit Sub : End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            'T1分時領料資料移除()
            'T1分時領料列印()
            列印後續 = "Y"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T1派工列印載入()
        If T1派工列印.RowCount > 0 Then : 顯示資料.Tables("派工列印").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_分時領料明細01v] 'AC','" & (Cb數層.SelectedIndex + 1) & "','" & Cb時段.SelectedValue & "','" & Format(Dt日期.Value.Date, "yyyy-MM-dd") & "','" & CInt(La1派次.Text) + 1 & "' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "派工列印")
            T1派工列印.DataSource = 顯示資料.Tables("派工列印")
            T1派工列印.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("派工列印：" & ex.Message)
            Exit Sub
        End Try
    End Sub


    'Private Sub T1分時領料資料移除()
    '    'Dim count As Integer = T1派工明細.Rows.Count
    '    'For i As Integer = 0 To count - 1
    '    '    Dim isSelected As Boolean = Convert.ToBoolean(T1派工明細.Rows(i).Cells("選擇").Value)
    '    '    If isSelected = False Then
    '    '        T1派工明細.Rows.Remove(T1派工明細.Rows(i))
    '    '    End If
    '    'Next
    '    Dim count As Integer = T1派工明細.Rows.Count
    '    For i As Integer = count - 1 To 0 Step -1
    '        Dim isSelected As Boolean = Convert.ToBoolean(T1派工明細.Rows(i).Cells("選擇").Value)
    '        If isSelected = False Then
    '            T1派工明細.Rows.Remove(T1派工明細.Rows(i))
    '        End If
    '    Next


    'End Sub

    Private Sub T1分時領料列印()

        Dim printDoc As New PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        If 顯示資料.Tables("派工列印").Rows.Count > 0 Then

            Dim newRpt As 列印Print = New 列印Print
            newRpt.strPara(0) = Format(Dt日期.Value.Date, "yyyy-MM-dd")
            newRpt.strPara(1) = Cb數層.Text
            newRpt.strPara(2) = CStr(Cb時段.Text)
            newRpt.strPara(3) = CStr(La領料.Text)

            newRpt.StartupPath = "\A_倉儲\報表\派工列印.rdlc"
            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            newRpt.高 = "14cm"
            'newRpt.高 = "29.7cm"
            newRpt.TYPE = "3"
            'newRpt.紙張 = "Letter"
            '中一刀2()    22.86cm,13.97cm

            newRpt.dt = 顯示資料.Tables("派工列印")
            'newRpt.printerName = printDoc.PrinterSettings.PrinterName
            newRpt.printerName = Cb1印表機.Text
            'newRpt.printerName = PrinterName
            'newRpt.printerName = "Microsoft XPS Document Writer"
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無明細!", MsgBoxStyle.OkOnly, "派工列印")
        End If


    End Sub

    Private Sub Bu1刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1刪除.Click
        If T1已派明細.CurrentRow.Cells("狀態").Value = "正常" Then
            Dim oAns As Integer
            oAns = MsgBox("確定作廢此分時領料單?" & Chr(13) & vbCrLf & T1已派明細.CurrentRow.Cells("分時領料單").Value, MsgBoxStyle.OkCancel + 16, "分時領料單作廢")
            If oAns = MsgBoxResult.Ok Then
                T1移除單據條碼明細()
                T1已派領料載入()
                'T1查詢單據條碼件數()
                '移除作業T1.Text = "" : 移除草稿T1.Text = ""
                'If T1DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV3").Clear() : End If '清除T1DGV3資料
            End If
        End If
    End Sub

    Private Sub T1移除單據條碼明細()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[倉_分時領料] SET [啟用否] = 'D',[刪除時間] = GETDATE() FROM [KaiShingPlug].[dbo].[倉_分時領料] WHERE [分時領料單] = '" & T1已派明細.CurrentRow.Cells("分時領料單").Value & "' AND [啟用否] = 'Y' "

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



End Class