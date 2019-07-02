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
'
Public Class 退貨入庫V100
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim 目前作業 As String = ""
    Dim 待用條碼 As String = ""
    Dim DocNum As Integer = 0

    '------>條碼機列印資訊_開始 <------
    Private Declare Sub openport Lib "TSCLib.dll" (ByVal PrinterName As String)
    Private Declare Sub closeport Lib "TSCLib.dll" ()
    Private Declare Sub sendcommand Lib "TSCLib.dll" (ByVal command_Renamed As String)
    Private Declare Sub setup Lib "TSCLib.dll" (ByVal LabelWidth As String, ByVal LabelHeight As String, ByVal Speed As String, ByVal Density As String, ByVal Sensor As String, ByVal Vertical As String, ByVal Offset As String)
    Private Declare Sub downloadpcx Lib "TSCLib.dll" (ByVal Filename As String, ByVal ImageName As String)
    Private Declare Sub barcode Lib "TSCLib.dll" (ByVal X As String, ByVal Y As String, ByVal CodeType As String, ByVal Height_Renamed As String, ByVal Readable As String, ByVal rotation As String, ByVal Narrow As String, ByVal Wide As String, ByVal Code As String)
    Private Declare Sub printerfont Lib "TSCLib.dll" (ByVal X As String, ByVal Y As String, ByVal FontName As String, ByVal rotation As String, ByVal Xmul As String, ByVal Ymul As String, ByVal Content As String)
    Private Declare Sub clearbuffer Lib "TSCLib.dll" ()
    Private Declare Sub printlabel Lib "TSCLib.dll" (ByVal NumberOfSet As String, ByVal NumberOfCopy As String)
    Private Declare Sub formfeed Lib "TSCLib.dll" ()
    Private Declare Sub nobackfeed Lib "TSCLib.dll" ()
    Private Declare Sub windowsfont Lib "TSCLib.dll" (ByVal X As Short, ByVal Y As Short, ByVal fontheight_Renamed As Short, ByVal rotation As Short, ByVal fontstyle As Short, ByVal fontunderline As Short, ByVal FaceName As String, ByVal TextContent As String)

    Structure LabeData  '列印標籤
        Dim PQty As Integer : Dim Itemname As String : Dim Barcode As String : Dim Weight As String : Dim Qty As String : Dim Unit As String : Dim MDate As String : Dim DDate As String
    End Structure
    '------>條碼機列印資訊__結束 <------

    Private Sub 退貨入庫_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        目前作業 = "單據查詢" : Lt作業.Text = "單據查詢"
        Me.Size = New Size(1200, 680)
        Cb印表機()
        T2初始化()

    End Sub

    Private Sub Cb印表機()
        Dim 預設印表機 As New PrintDocument()
        'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName
        Dim i As Integer : Dim 所有印表機 As String = ""
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
            If 所有印表機 Like "*TTP-243*" Or 所有印表機 Like "*TTP-247*" Then
                Cb1印表機.Items.Add(所有印表機)
                Cb3印表機.Items.Add(所有印表機)
            End If
        Next
        Cb1印表機.SelectedIndex = 0
        Cb3印表機.SelectedIndex = 0
        'Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName
    End Sub


    Private Sub T1初始化()
        TB客編.Text = "" : TB名稱.Text = "" : TB單號.Text = ""

    End Sub

    Private Sub T2初始化()
        La2存編.Text = "" : La2品名.Text = "" : La2小單位.Text = "" : La2條碼.Text = ""
        Tb2退貨.Text = "" : Tb2重量.Text = ""

    End Sub

    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As TabControlEventArgs) Handles TabControl1.Selected
        'MsgBox(TabControl1.SelectedTab.Text)
        Select Case 目前作業
            Case "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
            Case "退貨條碼" : Me.TabControl1.SelectedTab = Me.TP退貨條碼
            Case "退貨入庫" : Me.TabControl1.SelectedTab = Me.TP退貨入庫
            Case Else
        End Select

    End Sub

    Private Sub Bu1查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1查詢.Click
        T1退貨單號載入()
    End Sub

    Private Sub T1退貨單號載入()
        If T1退貨單號.RowCount > 0 Then : 顯示資料.Tables("退貨單號").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = "    SELECT [單號] AS '退貨單號',[客戶名稱],[客戶編號] "
        SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表頭] T0 "
        SQLQuery += "    WHERE ([單號日期] BETWEEN '" & Format(De1開始.Value.Date, "yyyy-MM-dd") & "' AND '" & Format(De1結束.Value.Date, "yyyy-MM-dd") & "' ) AND [啟用] = 'Y' "
        SQLQuery += " ORDER BY [單號] DESC "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "退貨單號")
            T1退貨單號.DataSource = 顯示資料.Tables("退貨單號")
            T1退貨單號.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("單號查詢：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T1退貨單號_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1退貨單號.CellClick
        If T1退貨單號.RowCount > 0 Then
            TB客編.Text = T1退貨單號.CurrentRow.Cells("客戶編號").Value
            TB名稱.Text = T1退貨單號.CurrentRow.Cells("客戶名稱").Value
            TB單號.Text = T1退貨單號.CurrentRow.Cells("退貨單號").Value

            T1退貨明細載入()
            T1退貨條碼載入()
        End If

    End Sub

    Private Sub T1退貨明細載入()
        If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        'SQLQuery = 載入來源資料(Cb2退單來源.Text, T2選擇單號.CurrentRow.Cells("文件單號").Value)

        SQLQuery = "    SELECT [存貨編號],[存編名稱],[退貨數量],[數量],[出貨重量],[單位], "
        SQLQuery += "          [數量2],REPLACE([小單位],' ','') AS '小單位',CAST([單價] AS NUMERIC(15,4)) AS '單價',[計價],[金額], "
        SQLQuery += "          [倉別],[稅碼],[列號],[備註] "
        SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表身] "
        SQLQuery += "    WHERE [單號] = '" & TB單號.Text & "' AND [啟用] = 'Y' "
        SQLQuery += " ORDER BY [列號] "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T1退貨明細")
            T1退貨明細.DataSource = 顯示資料.Tables("T1退貨明細")
            T1退貨明細顯示()
            T1退貨明細.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("退貨明細：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T1退貨明細顯示()
        For Each column As DataGridViewColumn In T1退貨明細.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 0 : column.Frozen = True
                Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
                Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 2
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3 : column.Visible = False
                Case "出貨重量" : column.HeaderText = "出貨重量" : column.DisplayIndex = 4
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5
                Case "數量2" : column.HeaderText = "數量2" : column.DisplayIndex = 6
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 7
                Case "單價" : column.HeaderText = "單價" : column.DisplayIndex = 8
                Case "計價" : column.HeaderText = "計價" : column.DisplayIndex = 9
                Case "金額" : column.HeaderText = "金額" : column.DisplayIndex = 10
                Case "倉別" : column.HeaderText = "倉別" : column.DisplayIndex = 11
                Case "稅碼" : column.HeaderText = "稅碼" : column.DisplayIndex = 12 : column.Visible = False
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 13 : column.Visible = False
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 14
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T1退貨條碼載入()
        If T1退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T1退貨條碼").Clear() : End If '清除資料
        Dim SQLQuery As String = ""

        SQLQuery += "      SELECT [存貨編號],[存編名稱],[入庫單號],[條碼],[退貨數量] AS '小單位數量',[小單位],[退貨重量], "
        SQLQuery += "             CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN '無管理'   WHEN [ManSerNum] = 'Y' THEN '序號' WHEN [ManBtchNum] = 'Y' THEN '批次' END AS '類別', "
        SQLQuery += "             CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN [退貨數量] WHEN [ManSerNum] = 'Y' THEN 1      WHEN [ManBtchNum] = 'Y' THEN [退貨數量] END AS '退貨數量',[入庫否],[FrgnName] AS '簡稱' "
        SQLQuery += "        FROM [KaiShingPlug].[dbo].[倉_退貨條碼] X0 LEFT  JOIN [OITM] X1 ON [存貨編號] = [ItemCode] "
        SQLQuery += "       WHERE [單號] = '" & TB單號.Text & "' AND [啟用否] = 'Y' AND [入庫否] IN ('Y','N') "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T1退貨條碼")
            T1退貨條碼.DataSource = 顯示資料.Tables("T1退貨條碼")
            'T2退貨條碼顯示()
            T1退貨條碼.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("T1入庫退貨條碼：" & ex.Message)
            Exit Sub
        End Try

    End Sub


    Private Sub Bu1新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1新增.Click
        If TB單號.Text = "" Then : MsgBox("未選擇單據") : Exit Sub : End If
        目前作業 = "退貨條碼" : Lt作業.Text = "退貨條碼" : Me.TabControl1.SelectedTab = Me.TP退貨條碼
        T2退貨明細.DataSource = 顯示資料.Tables("T1退貨明細")
        T2退貨明細顯示()
        T2退貨明細.AutoResizeColumns()
        T2退貨條碼載入()
        T2初始化()
        條碼載入()

    End Sub

    Private Sub 條碼載入()
        Dim SQLADD As String = ""
        SQLADD = " SELECT TOP 1 ISNULL(MAX([條碼]),'') AS '條碼' FROM [KaiShingPlug].[dbo].[倉_退貨條碼] WHERE [單號] = '" & TB單號.Text & "' "

        Try
            '取得資料庫最後一筆條碼
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000 : SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MSSQL作業 = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            MSSQL作業.Fill(顯示資料, "條碼明細")

            If 顯示資料.Tables("條碼明細").Rows(0).Item("條碼") = "" Then
                待用條碼 = TB單號.Text & "001"
            Else
                新條碼(顯示資料.Tables("條碼明細").Rows(0).Item("條碼"))
            End If
            La2條碼.Text = 待用條碼

        Catch ex As Exception
            MsgBox("待用條碼: " & ex.Message)
        End Try

    End Sub

    '依傳入之條碼產生下一條碼
    Sub 新條碼(ByVal lastBarCode As String)
        Dim nextCode As String = CStr(CInt(Microsoft.VisualBasic.Right(lastBarCode, 3)) + 1)
        If Len(nextCode) < 3 Then
            For i As Integer = 1 To 3 - Len(nextCode)
                nextCode = "0" & nextCode
            Next
        End If
        待用條碼 = Mid(lastBarCode, 1, Microsoft.VisualBasic.Len(lastBarCode) - 3) & nextCode

    End Sub

    Private Sub T2退貨明細顯示()
        For Each column As DataGridViewColumn In T2退貨明細.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 0 : column.Frozen = True
                Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
                Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 2
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3 : column.Visible = False
                Case "出貨重量" : column.HeaderText = "出貨重量" : column.DisplayIndex = 4 : column.Visible = False
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5
                Case "數量2" : column.HeaderText = "數量2" : column.DisplayIndex = 6 : column.Visible = False
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 7
                Case "單價" : column.HeaderText = "單價" : column.DisplayIndex = 8 : column.Visible = False
                Case "計價" : column.HeaderText = "計價" : column.DisplayIndex = 9 : column.Visible = False
                Case "金額" : column.HeaderText = "金額" : column.DisplayIndex = 10 : column.Visible = False
                Case "倉別" : column.HeaderText = "倉別" : column.DisplayIndex = 11
                Case "稅碼" : column.HeaderText = "稅碼" : column.DisplayIndex = 12 : column.Visible = False
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 13 : column.Visible = False
                Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 14
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T2退貨明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2退貨明細.CellClick
        La2存編.Text = T2退貨明細.CurrentRow.Cells("存貨編號").Value
        La2品名.Text = T2退貨明細.CurrentRow.Cells("存編名稱").Value
        La2小單位.Text = T2退貨明細.CurrentRow.Cells("小單位").Value
       
    End Sub

    Private Sub T2退貨條碼載入()
        If T2退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T2退貨條碼").Clear() : End If '清除資料
        Dim SQLQuery As String = ""

        SQLQuery = "    SELECT CAST([ID] AS VARCHAR(50)) AS 'ID',[單號],[存貨編號],[存編名稱],[條碼],[退貨數量],[小單位],[退貨重量],[入庫否],[入庫單號],[啟用否],'正常' AS '使用情況' "
        SQLQuery += "     FROM [KaiShingPlug].[dbo].[倉_退貨條碼] "
        SQLQuery += "    WHERE [單號] = '" & TB單號.Text & "' AND [啟用否] = 'Y' "
        SQLQuery += " ORDER BY [存貨編號] "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T2退貨條碼")
            T2退貨條碼.DataSource = 顯示資料.Tables("T2退貨條碼")
            T2退貨條碼顯示()
            T2退貨條碼.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("退貨條碼：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub T2退貨條碼顯示()
        For Each column As DataGridViewColumn In T2退貨條碼.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 0 : column.Frozen = True
                Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
                Case "條碼" : column.HeaderText = "條碼" : column.DisplayIndex = 2
                Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 3
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 4
                Case "退貨重量" : column.HeaderText = "退貨重量" : column.DisplayIndex = 5
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 6 : column.Visible = False
                Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 7
                Case "入庫否" : column.HeaderText = "入庫否" : column.DisplayIndex = 8
                Case "入庫單號" : column.HeaderText = "入庫單號" : column.DisplayIndex = 9 : column.Visible = False
                Case "啟用否" : column.HeaderText = "啟用否" : column.DisplayIndex = 10 : column.Visible = False
                Case "使用情況" : column.HeaderText = "使用情況" : column.DisplayIndex = 11
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub Bu2新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2新增.Click
        If La2存編.Text <> "" Then
            If CStr(Tb2退貨.Text) = "" Or CDbl(Tb2重量.Text) <> 0 Then
                Dim Row As DataRow
                Row = 顯示資料.Tables("T2退貨條碼").NewRow
                Row.Item("ID") = ""
                Row.Item("單號") = TB單號.Text
                Row.Item("存貨編號") = La2存編.Text
                Row.Item("存編名稱") = La2品名.Text
                Row.Item("條碼") = La2條碼.Text
                Row.Item("退貨數量") = Tb2退貨.Text
                Row.Item("小單位") = La2小單位.Text
                Row.Item("退貨重量") = Tb2重量.Text
                Row.Item("入庫否") = "N"
                Row.Item("入庫否") = "N"
                Row.Item("入庫單號") = 0
                Row.Item("啟用否") = "Y"
                Row.Item("使用情況") = "新增"

                顯示資料.Tables("T2退貨條碼").Rows.Add(Row)
                Tb2退貨.Text = ""
                Tb2重量.Text = ""
                新條碼(La2條碼.Text)
                La2條碼.Text = 待用條碼

            Else
                MsgBox("輸入錯誤資料")
            End If
        Else
            MsgBox("未選擇資料")
        End If

        T2退貨條碼.AutoResizeColumns()

    End Sub

    Private Sub Bu2刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2刪除.Click
        If T2退貨條碼.CurrentRow.Cells("入庫否").Value = "Y" Then : MsgBox("已入庫無法移除") : Exit Sub : End If
        If T2退貨條碼.CurrentRow.Cells("使用情況").Value = "刪除" Then : MsgBox("已刪除") : Exit Sub : End If

        Dim i As Integer = 0
        i = T2退貨條碼.CurrentCell.RowIndex()   '
        Dim oAns As Integer
        'oAns = MsgBox("是否確定刪除選定資料  " & (T4輸入資料.CurrentCell.RowIndex() + 1), MsgBoxStyle.YesNo, "刪除選定資料")
        oAns = MsgBox("是否確定刪除選定資料  列" & (T2退貨條碼.CurrentCell.RowIndex() + 1) & vbCrLf & T2退貨條碼.CurrentRow.Cells("存編名稱").Value, MsgBoxStyle.YesNo, "刪除選定資料")
        If oAns = MsgBoxResult.Yes Then  'Yes執行區
            If T2退貨條碼.CurrentRow.Cells("入庫否").Value = "N" Then
                If T2退貨條碼.CurrentRow.Cells("ID").Value = "" Then
                    T2退貨條碼.Rows.Remove(T2退貨條碼.Rows(i))  '移除
                Else
                    T2退貨條碼.CurrentRow.Cells("啟用否").Value = "D"
                    T2退貨條碼.CurrentRow.Cells("使用情況").Value = "刪除"
                End If
                'T4退貨數量合計更新()
            End If
        End If

    End Sub

    Private Sub Bu2放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2放棄.Click
        If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
        If T1退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T1退貨條碼").Clear() : End If '清除資料
        If T2退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
        If T2退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T2退貨條碼").Clear() : End If '清除資料
        目前作業 = "單據查詢" : Lt作業.Text = "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
        T1初始化()

    End Sub

    Private Sub Bu2存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2存檔.Click
        T2退畫面退出作業()
        目前作業 = "單據查詢" : Lt作業.Text = "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
        T1初始化()

    End Sub

    Private Sub Bu2入庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2入庫.Click
        If T2退貨條碼.RowCount = 0 Then : Exit Sub : MsgBox("無資料可存檔") : End If
        Dim A1 As Integer = 0
        For i As Integer = 0 To T2退貨條碼.RowCount - 1
            If T2退貨條碼.Rows(i).Cells("入庫否").Value = "N" And (T2退貨條碼.Rows(i).Cells("使用情況").Value = "正常" Or T2退貨條碼.Rows(i).Cells("使用情況").Value = "新增") Then
                A1 = A1 + 1
            End If
        Next
        If A1 = 0 Then : MsgBox("無可入庫條碼")
            T2退畫面退出作業()
            目前作業 = "單據查詢" : Lt作業.Text = "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
            T1初始化()
            Exit Sub
        End If

        T2退畫面退出作業()
        目前作業 = "退貨入庫" : Lt作業.Text = "退貨入庫" : Me.TabControl1.SelectedTab = Me.TP退貨入庫
        T3退貨明細載入() : T3退貨條碼載入()
        T3過帳日期.Value = CDate("20" & Mid(TB單號.Text, 1, 2) & "-" & Mid(TB單號.Text, 3, 2) & "-" & Mid(TB單號.Text, 5, 2))
        DocNum = 0
    End Sub

    Private Sub Bu1入庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1入庫.Click
        If T1退貨條碼.RowCount = 0 Then : Exit Sub : MsgBox("無資料可存檔") : End If
        Dim A1 As Integer = 0
        For i As Integer = 0 To T1退貨條碼.RowCount - 1
            If T1退貨條碼.Rows(i).Cells("入庫否").Value = "N" Then
                A1 = A1 + 1
            End If
        Next
        If A1 = 0 Then : Exit Sub : MsgBox("無可入庫條碼") : End If

        If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
        If T1退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T1退貨條碼").Clear() : End If '清除資料
        目前作業 = "退貨入庫" : Lt作業.Text = "退貨入庫" : Me.TabControl1.SelectedTab = Me.TP退貨入庫
        T3退貨明細載入() : T3退貨條碼載入()
        T3過帳日期.Value = CDate("20" & Mid(TB單號.Text, 1, 2) & "-" & Mid(TB單號.Text, 3, 2) & "-" & Mid(TB單號.Text, 5, 2))
        DocNum = 0
    End Sub


    Private Sub T2退畫面退出作業()
        If T2退貨條碼.RowCount = 0 Then : Exit Sub : MsgBox("無資料可存檔") : End If
        T2退貨條碼存檔()
        If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
        If T1退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T1退貨條碼").Clear() : End If '清除資料
        If T2退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
        If T2退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T2退貨條碼").Clear() : End If '清除資料
    End Sub


    Private Sub T2退貨條碼存檔()
        Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        For i As Integer = 0 To T2退貨條碼.RowCount - 1
            If T2退貨條碼.Rows(i).Cells("使用情況").Value.ToString = "新增" Then
                SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[倉_退貨條碼] "
                SQLADD2 += " ([單號],[存貨編號],[存編名稱],[條碼],[退貨數量],[小單位],[退貨重量],[啟用否],[新增時間],[入庫否],[入庫單號]) VALUES "
                SQLADD2 += " ('" & T2退貨條碼.Rows(i).Cells("單號").Value & "'    , "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("存貨編號").Value & "', "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("存編名稱").Value & "', "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("條碼").Value & "', "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("退貨數量").Value & "', "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("小單位").Value & "', "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("退貨重量").Value & "', "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("啟用否").Value & "'  , "
                SQLADD2 += "  GETDATE()    , "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("入庫否").Value & "'  , "
                SQLADD2 += "  '" & T2退貨條碼.Rows(i).Cells("入庫單號").Value & "') " & vbCrLf
            End If

            If T2退貨條碼.Rows(i).Cells("使用情況").Value.ToString = "刪除" And T2退貨條碼.Rows(i).Cells("ID").Value.ToString <> "" Then
                SQLADD1 += " UPDATE [KaiShingPlug].[dbo].[倉_退貨條碼] "
                SQLADD1 += "    SET [啟用否]     = 'D', "
                SQLADD1 += "        [刪除時間] = GETDATE() "
                SQLADD1 += "  WHERE [ID] = '" & T2退貨條碼.Rows(i).Cells("ID").Value.ToString & "' AND [啟用否] = 'Y' " & vbCrLf
            End If

        Next
        'MsgBox(SQLADD1 + SQLADD2)
        If SQLADD1 + SQLADD2 = "" Then : Exit Sub : End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub T3退貨明細載入()
        If T3退貨明細.RowCount > 0 Then : 顯示資料.Tables("T3退貨明細").Clear() : End If '清除資料
        Dim SQLQuery As String = ""

        'SQLQuery = "    SELECT CAST([ID] AS VARCHAR(50)) AS 'ID',[單號],[存貨編號],[存編名稱],[退貨數量],[退貨重量],[入庫否],[啟用否],'正常' AS '使用情況' "
        'SQLQuery += "     FROM [KaiShingPlug].[dbo].[倉_退貨條碼] "
        'SQLQuery += "    WHERE [單號] = '" & TB單號.Text & "' AND [啟用否] = 'Y' "
        'SQLQuery += " ORDER BY [存貨編號] "
        SQLQuery += "       SELECT [存貨編號],[存編名稱],SUM([退貨數量]) AS '小單位數量',SUM([退貨重量]) AS 退貨重量, "
        SQLQuery += "              CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN '無管理'   WHEN [ManSerNum] = 'Y' THEN '序號' WHEN [ManBtchNum] = 'Y' THEN '批次' END AS '類別', "
        SQLQuery += "          SUM(CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN [退貨數量] WHEN [ManSerNum] = 'Y' THEN 1      WHEN [ManBtchNum] = 'Y' THEN [退貨數量] END) AS '退貨數量' "
        SQLQuery += "         FROM [KaiShingPlug].[dbo].[倉_退貨條碼] X0 LEFT  JOIN [OITM] X1 ON [存貨編號] = [ItemCode] "
        SQLQuery += "        WHERE [單號] = '" & TB單號.Text & "' AND [啟用否] = 'Y' AND [入庫否] = 'N' "
        SQLQuery += "     GROUP BY [存貨編號],[存編名稱],CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN '無管理'   WHEN [ManSerNum] = 'Y' THEN '序號' WHEN [ManBtchNum] = 'Y' THEN '批次' END "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T3退貨明細")
            T3退貨明細.DataSource = 顯示資料.Tables("T3退貨明細")
            'T2退貨條碼顯示()
            T3退貨明細.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("入庫退貨明細：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub T3退貨條碼載入()
        If T3退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T3退貨條碼").Clear() : End If '清除資料
        Dim SQLQuery As String = ""

        SQLQuery += "      SELECT [存貨編號],[存編名稱],[條碼],[退貨數量] AS '小單位數量',[小單位],[退貨重量], "
        SQLQuery += "             CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN '無管理'   WHEN [ManSerNum] = 'Y' THEN '序號' WHEN [ManBtchNum] = 'Y' THEN '批次' END AS '類別', "
        SQLQuery += "             CASE WHEN [ManSerNum]  = 'N' AND [ManBtchNum] = 'N' THEN [退貨數量] WHEN [ManSerNum] = 'Y' THEN 1      WHEN [ManBtchNum] = 'Y' THEN [退貨數量] END AS '退貨數量', "
        SQLQuery += "             [ID],[FrgnName] AS '簡稱' "
        SQLQuery += "        FROM [KaiShingPlug].[dbo].[倉_退貨條碼] X0 LEFT  JOIN [OITM] X1 ON [存貨編號] = [ItemCode] "
        SQLQuery += "       WHERE [單號] = '" & TB單號.Text & "' AND [啟用否] = 'Y' AND [入庫否] = 'N' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T3退貨條碼")
            T3退貨條碼.DataSource = 顯示資料.Tables("T3退貨條碼")
            T3退貨條碼顯示()
            T3退貨條碼.AutoResizeColumns()
        Catch ex As Exception
            MsgBox("入庫退貨條碼：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub T3退貨條碼顯示()
        For Each column As DataGridViewColumn In T3退貨條碼.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 0 : column.Frozen = True
                Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
                Case "條碼" : column.HeaderText = "條碼" : column.DisplayIndex = 2
                Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 3
                Case "退貨重量" : column.HeaderText = "退貨重量" : column.DisplayIndex = 4
                Case "類別" : column.HeaderText = "類別" : column.DisplayIndex = 5
                Case "小單位數量" : column.HeaderText = "小單位數量" : column.DisplayIndex = 6
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 7
                Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 8 : column.Visible = False
                Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 9 : column.Visible = False

                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub 回存入庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 回存入庫.Click
        If TB3儲位.Text = "" Then : MsgBox("儲位未輸入") : Exit Sub : End If

        回存SAP入庫()
        條碼列印資訊("3")

        If T3退貨明細.RowCount > 0 Then : 顯示資料.Tables("T3退貨明細").Clear() : End If '清除資料
        If T3退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T3退貨條碼").Clear() : End If '清除資料
        目前作業 = "單據查詢" : Lt作業.Text = "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
        T1初始化()

    End Sub

    Private Sub Bu3放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu3放棄.Click
        If T3退貨明細.RowCount > 0 Then : 顯示資料.Tables("T3退貨明細").Clear() : End If '清除資料
        If T3退貨條碼.RowCount > 0 Then : 顯示資料.Tables("T3退貨條碼").Clear() : End If '清除資料
        目前作業 = "單據查詢" : Lt作業.Text = "單據查詢" : Me.TabControl1.SelectedTab = Me.TP單據查詢
        T1初始化()

    End Sub

    Private Sub 回存SAP入庫()
        '生產入庫
        Dim RetVal As Long : Dim ErrCode As Long : Dim ErrMsg As String : Dim Codess As String = ""
        Dim vDoc As SAPbobsCOM.Documents
        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
        '表頭_內容
        'vDoc.UserFields.Fields.Item("U_CK02").Value = 製單.CurrentRow.Cells("製單編號").Value '製單號
        'vDoc.UserFields.Fields.Item("U_CK06").Value = 收貨類型Type '收貨目地
        vDoc.UserFields.Fields.Item("U_CK06").Value = "7" '收貨目地
        vDoc.DocDate = T3過帳日期.Value.Date '文件日期
        vDoc.Comments = "退貨單號：" & TB單號.Text & vbCrLf & TB名稱.Text & vbCrLf & TB3備註.Text

        For i As Integer = 0 To T3退貨明細.RowCount - 1
            Codess = ""
            If T3退貨明細.CurrentRow.Cells("類別").Value = "序號" Then

                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = Trim(T3退貨明細.Rows(i).Cells("存貨編號").Value)                                 '項目號碼
                vDoc.Lines.Quantity = T3退貨明細.Rows(i).Cells("退貨數量").FormattedValue                              '件數
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = T3退貨明細.Rows(i).Cells("退貨重量").FormattedValue  '重量
                vDoc.Lines.UserFields.Fields.Item("U_P4").Value = T3退貨明細.Rows(i).Cells("小單位數量").FormattedValue  '小單位數量
                'vDoc.Lines.WarehouseCode = CStr(T3退貨明細.Rows(i).Cells("預設儲位").FormattedValue)                     '預設儲位
                vDoc.Lines.WarehouseCode = "K10-1"                   '預設儲位
                '列出錯誤
                Codess = Trim(T3退貨明細.Rows(i).Cells("存貨編號").Value) & " S"   '錯誤項目號碼
                'MsgBox(Codess)

                '明細
                Dim Cnt0 As Integer = 0
                For j As Integer = 0 To T3退貨條碼.RowCount - 1
                    'If Trim(dgvSourceList.Rows(j).Cells("FI107").Value) = Codess Then
                    If Trim(T3退貨條碼.Rows(j).Cells("存貨編號").Value) = Trim(T3退貨明細.Rows(i).Cells("存貨編號").Value) Then
                        vDoc.Lines.SerialNumbers.SetCurrentLine(Cnt0)
                        vDoc.Lines.SerialNumbers.InternalSerialNumber = T3退貨條碼.Rows(j).Cells("條碼").Value '條碼
                        'ReceptionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        'vDoc.Lines.SerialNumbers.ReceptionDate = T3退貨條碼.Rows(j).Cells("製單日期").Value        '製單日期 InDate
                        'vDoc.Lines.SerialNumbers.ManufactureDate = T3退貨條碼.Rows(j).Cells("製造日期").Value      '生產日期 MnfDate
                        'vDoc.Lines.SerialNumbers.ExpiryDate = T3退貨條碼.Rows(j).Cells("有效日期").Value           '有效日期 ExpDate
                        vDoc.Lines.SerialNumbers.Add()
                        'MsgBox(Cnt0)   '顯示執行列數
                        Cnt0 += 0 + 1
                    End If
                Next

                vDoc.Lines.Add()

            End If

            If T3退貨明細.CurrentRow.Cells("類別").Value = "批次" Then
                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = T3退貨明細.Rows(i).Cells("存貨編號").Value '項目號碼
                vDoc.Lines.Quantity = T3退貨明細.Rows(i).Cells("退貨數量").Value '件數_回傳包數
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = T3退貨明細.Rows(i).Cells("退貨重量").FormattedValue  '重量
                'vDoc.Lines.WarehouseCode = CStr(T3退貨明細.Rows(i).Cells("預設儲位").FormattedValue)                     '預設儲位
                vDoc.Lines.WarehouseCode = "S10-1"                   '預設儲位
                '列出錯誤
                Codess = Trim(T3退貨明細.Rows(i).Cells("存貨編號").Value) & " B" '錯誤項目號碼
                'MsgBox(Codess)

                '明細 
                Dim Cnt1 As Integer = 0
                For jx As Integer = 0 To T3退貨條碼.RowCount - 1
                    If T3退貨條碼.Rows(jx).Cells("存貨編號").Value = Trim(T3退貨明細.Rows(i).Cells("存貨編號").Value) Then
                        vDoc.Lines.BatchNumbers.SetCurrentLine(Cnt1)
                        vDoc.Lines.BatchNumbers.BatchNumber = T3退貨條碼.Rows(jx).Cells("條碼").Value       '條碼
                        'AddmisionDate  ManufactureDate     ExpiryDate
                        'InDate         MnfDate             ExpDate
                        'vDoc.Lines.BatchNumbers.AddmisionDate = 明細.Rows(jx).Cells("製單日期").Value     '製單日期 InDate
                        'vDoc.Lines.BatchNumbers.ManufacturingDate = 明細.Rows(jx).Cells("製造日期").Value '生產日期 MnfDate
                        'vDoc.Lines.BatchNumbers.ExpiryDate = 明細.Rows(jx).Cells("有效日期").Value        '有效日期 ExpDate
                        vDoc.Lines.BatchNumbers.Quantity = T3退貨條碼.Rows(jx).Cells("退貨數量").Value          '數量_回傳包數
                        vDoc.Lines.BatchNumbers.Add()
                        'MsgBox(Cnt0)   '顯示執行列數
                        Cnt1 += 0 + 1
                    End If
                Next

                vDoc.Lines.Add()
            End If

        Next

        RetVal = vDoc.Add
        'Check the result
        If RetVal <> 0 Then     '轉入失敗
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("製單轉入B1收貨單錯誤! " & Codess & vbCrLf & ErrCode & vbCrLf & ErrMsg, 16, "錯誤")
            Exit Sub
        End If
        DocNum = Login.oCompany.GetNewObjectKey()
        If DocNum <> 0 Then
            T3退貨條碼更新()
        End If
        MsgBox("退貨入庫完成，退貨單號" & DocNum)

    End Sub

    Private Sub T3退貨條碼更新()
        Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""
        '[ID],[單號],[存貨編號],[存編名稱],[條碼],[退貨數量],[退貨重量],[啟用否],[新增時間],[入庫否],[入庫單號],[入庫時間],[刪除時間]
        For i As Integer = 0 To T3退貨條碼.RowCount - 1
            SQLADD1 += " UPDATE [KaiShingPlug].[dbo].[倉_退貨條碼] "
            SQLADD1 += "    SET [入庫否]     = 'Y'           , "
            SQLADD1 += "        [入庫單號] = '" & DocNum & "', "
            SQLADD1 += "        [入庫時間] = GETDATE()         "
            SQLADD1 += "  WHERE [ID] = '" & T3退貨條碼.Rows(i).Cells("ID").Value.ToString & "' AND [啟用否] = 'Y' AND [入庫否] = 'N' " & vbCrLf

            If T3退貨明細.CurrentRow.Cells("類別").Value = "序號" Then
                SQLADD1 += " UPDATE [OSRN] "
                SQLADD1 += "    SET [U_M1] = '" & T3退貨條碼.Rows(i).Cells("退貨重量").Value.ToString & "', "
                SQLADD1 += "        [U_M2] = '" & TB3儲位.Text & "'  "
                'SQLADD1 += "    SET [U_M8] = T1.[製單編號], "
                'SQLADD1 += "        [U_M1] = T1.[標示重量], "
                'SQLADD1 += "        [U_M2] = T1.[入庫庫位], "
                'SQLADD1 += "        [U_MC] = T1.[客戶代碼]  "
                SQLADD1 += "   FROM [OSRN] T0  "
                SQLADD1 += "  WHERE T0.[DistNumber] = '" & T3退貨條碼.Rows(i).Cells("條碼").Value.ToString & "' " & vbCrLf

            End If


            'SQLADD1 += " UPDATE [OSRN]                             SET [U_M8] = T1.[製單編號], [U_M1] = T1.[標示重量], [U_M2] = T1.[入庫庫位], [U_MC] = T1.[客戶代碼] "
            'SQLADD1 += "   FROM [OSRN] T0 INNER JOIN [" & INPDA1 & "] T1 ON T0.[DistNumber] = T1.[入庫條碼] COLLATE Chinese_PRC_CI_AS "
            'SQLADD1 += "  WHERE [儲位碼數] = '正常' AND [狀態] = '正常' AND [庫存狀態] = '未入' AND [補單] = 'N' AND [重覆] = '' "
            'SQLADD1 += "    AND [製單編號] = '" & 製單.CurrentRow.Cells("製單編號").Value & "' "
            'SQLADD1 += "    AND [入庫管理] = '" & 製單.CurrentRow.Cells("入庫管理").Value & "' "


        Next
        'MsgBox(SQLADD1 + SQLADD2)
        If SQLADD1 + SQLADD2 = "" Then : MsgBox("異常無資料更新") : Exit Sub : End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Bu1列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1列印.Click
        If T1退貨條碼.RowCount = 0 Then : Exit Sub : MsgBox("無資料可列印") : End If
        條碼列印資訊("1")
        MsgBox("列印完成")
    End Sub

    Private Sub 條碼列印資訊(ByVal 作業 As String)
        Try '列印條碼標籤, 把資料填入LabeData變數中傳給printLabel()列印
            Dim olabel As LabeData = New LabeData
            If 作業 = "1" Then
                With olabel
                    .PQty = "1"
                    .Itemname = T1退貨條碼.CurrentRow.Cells("簡稱").Value
                    .Barcode = T1退貨條碼.CurrentRow.Cells("條碼").Value
                    .Weight = Format(CSng(T1退貨條碼.CurrentRow.Cells("退貨重量").Value), "###0.00") & "Kg"
                    .Qty = CInt(T1退貨條碼.CurrentRow.Cells("小單位數量").Value) & T1退貨條碼.CurrentRow.Cells("小單位").Value.ToString
                    .Unit = T1退貨條碼.CurrentRow.Cells("小單位").Value
                    .MDate = ""
                    .DDate = ""
                    'If CB製造日期.Checked Then : .MDate = "製造日期：" & Format(De製造日期.Value, "yyyy/MM/dd") : Else : .MDate = "  " : End If
                    'If CB有效日期.Checked Then : .DDate = "有效日期：" & Format(De有效日期.Value, "yyyy/MM/dd") : Else : .DDate = "  " : End If
                End With
                'printlabel(olabel)
                SentToPrinter(olabel)

                'For j As Integer = 0 To T1退貨條碼.RowCount - 1
                '    With olabel
                '        .PQty = "1"
                '        .Itemname = T1退貨條碼.Rows(j).Cells("簡稱").Value.ToString
                '        .Barcode = T1退貨條碼.Rows(j).Cells("條碼").Value.ToString
                '        .Weight = Format(CSng(T1退貨條碼.Rows(j).Cells("退貨重量").Value), "###0.00") & "Kg"
                '        .Qty = CInt(T1退貨條碼.Rows(j).Cells("小單位數量").Value.ToString) & T1退貨條碼.Rows(j).Cells("小單位").Value.ToString
                '        .Unit = T1退貨條碼.Rows(j).Cells("小單位").Value.ToString
                '        .MDate = ""
                '        .DDate = ""
                '        'If CB製造日期.Checked Then : .MDate = "製造日期：" & Format(De製造日期.Value, "yyyy/MM/dd") : Else : .MDate = "  " : End If
                '        'If CB有效日期.Checked Then : .DDate = "有效日期：" & Format(De有效日期.Value, "yyyy/MM/dd") : Else : .DDate = "  " : End If
                '    End With
                '    'printlabel(olabel)
                '    SentToPrinter(olabel)
                'Next
            End If

            If 作業 = "3" Then
                For j As Integer = 0 To T3退貨條碼.RowCount - 1
                    With olabel
                        .PQty = "1"
                        .Itemname = T3退貨條碼.Rows(j).Cells("簡稱").Value.ToString
                        .Barcode = T3退貨條碼.Rows(j).Cells("條碼").Value.ToString
                        .Weight = Format(CSng(T3退貨條碼.Rows(j).Cells("退貨重量").Value), "###0.00") & "Kg"
                        .Qty = CInt(T3退貨條碼.Rows(j).Cells("小單位數量").Value.ToString) & T3退貨條碼.Rows(j).Cells("小單位").Value.ToString
                        .Unit = T3退貨條碼.Rows(j).Cells("小單位").Value.ToString
                        .MDate = ""
                        .DDate = ""
                        'If CB製造日期.Checked Then : .MDate = "製造日期：" & Format(De製造日期.Value, "yyyy/MM/dd") : Else : .MDate = "  " : End If
                        'If CB有效日期.Checked Then : .DDate = "有效日期：" & Format(De有效日期.Value, "yyyy/MM/dd") : Else : .DDate = "  " : End If
                    End With
                    'printlabel(olabel)
                    SentToPrinter(olabel)
                Next
            End If



        Catch ex As Exception
            MsgBox("列印標籤 (" & ex.Message & ")")
            End
        End Try
    End Sub

    'Private Sub printLabel(ByVal olabel As LabeData)
    '    If 列印條碼 <> "Y" Then '不列印標籤 產生標籤列印文字檔
    '        Dim labelData As String
    '        labelData = Trim(T2列印張數.Text) & "," & olabel.Itemname & "," & olabel.Barcode & "," & olabel.Weight & "," & Trim(olabel.Qty) & Trim(olabel.Unit) & "," _
    '                    & Trim(olabel.MDate) & "," & Trim(olabel.DDate)
    '        'My.Computer.FileSystem.WriteAllText("C:\vispark\label.txt", labelData, False, System.Text.Encoding.Default)
    '        My.Computer.FileSystem.WriteAllText((Application.StartupPath & "\報表\label.txt"), labelData, False, System.Text.Encoding.Default)
    '        '(Application.StartupPath & "\vispark\label.txt")
    '    Else
    '        If (Microsoft.VisualBasic.Left(S2存編.Text, 4) = "2511" Or Microsoft.VisualBasic.Left(S2存編.Text, 4) = "2512") And Microsoft.VisualBasic.Mid(S2存編.Text, 12, 2) = "03" Then
    '            olabel.PQty = CInt(1)
    '        Else
    '            olabel.PQty = CInt(T2列印張數.Text)
    '        End If
    '        olabel.Qty = olabel.Qty & Trim(olabel.Unit)
    '        SentToPrinter(olabel)
    '    End If

    'End Sub




    '驅動列印標籤 TSC TTP-243E & TSC TTP-247
    Private Sub SentToPrinter(ByVal olabel As LabeData)
        Dim baseLine As Integer = 0
        'Select Case Bu切換.Text     '指定電腦端的輸出埠
        '    Case "冷藏" : Call openport(條碼機01)
        '    Case "冷凍" : Call openport(條碼機02)
        'End Select
        If Lt作業.Text = "單據查詢" Then : Call openport(Cb1印表機.Text) : End If
        If Lt作業.Text = "退貨入庫" Then : Call openport(Cb3印表機.Text) : End If

        'Call openport("TSC TTP-243E") '指定電腦端的輸出埠
        Call setup("60", "42", "7.0", "4", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        'endcommand(“QRCODE 80,80,L,4,A,0,M2,S7,”"this is qrcode”"”)

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = ""
            Dim Itemname2 As String = ""
            Dim Counter As Integer = 0

            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then
                    Itemname1 = Itemname1 & Chr
                Else
                    Itemname2 = Itemname2 & Chr
                End If
            Next

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1) '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode) '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬,條碼內容 以點(point)表示
        '3.重量 
        Call windowsfont(44, 228, 40, 0, 2, 0, "新細明體", olabel.Weight)
        '4.數量
        Call windowsfont(290, 200, 70, 0, 2, 0, "新細明體", olabel.Qty)
        '5.有效日期
        Call windowsfont(45, 270, 25, 0, 2, 0, "新細明體", olabel.MDate)
        '6.製造日期
        Call windowsfont(45, 295, 25, 0, 2, 0, "新細明體", olabel.DDate)
        '定義列印張數
        Call printlabel("1", olabel.PQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub





End Class