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
'
'
'
Public Class 退貨記錄V100
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    '多重使用
    Dim 退貨明細 As DataTable = New DataTable
    'Dim 退貨明細_原 As DataTable = New DataTable

    Dim TP切換限制 As String = "Y"
    Dim 情況載入 As String = "N"
    Dim 初始載入 As String = "Y"
    'Dim 作業項目 As String = ""
    'Dim T2單號明細_選擇 As String = "Y"
    ''Dim T4單號空白 As String = ""
    'Dim T4DGV清空 As String = "Y"

    Private Sub 退貨記錄_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TB客編.Text = "" : TB名稱.Text = "" : TB單號.Text = ""
        載入Cb初始()
        Load初始化()
        'If UCase(Login.LogonUserName) = "MANAGER" Then : TP切換限制 = "Y" : Gb表頭資料.Visible = False : End If '解除管理者一開始移除分頁限制,Y=限制/N=解除
        ''If UCase(Login.LogonUserName) = "MANAGER" Then : TP切換限制 = "N" : Gb表頭資料.Visible = True : End If
        If TP切換限制 = "Y" Then
            'Me.TabControl1.TabPages.Remove(Tp退貨作業)
            Me.TabControl1.TabPages.Remove(Tp退單選擇)
            Me.TabControl1.TabPages.Remove(Tp退貨輸入)
            Me.TabControl1.TabPages.Remove(Tp退貨數量)
        End If

        ''If UCase(Login.LogonUserName) = "MANAGER" Then            '品管人員
        ''    Bu1新增.Visible = False
        ''    Bu1修改.Visible = False
        ''    Bu1刪除.Visible = False
        ''    Rb1日期.Checked = True
        ''Else

        Bu1查詢.PerformClick()
        ''End If



    End Sub

    Private Sub 載入Cb初始()
        T4Cb1類別載入()
        T4Cb1原因載入()
        T4Cb2相符載入()
        T4Cb2結果載入()
        Cb印表機()
    End Sub

    Private Sub T4Cb1類別載入()
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '類別' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '1' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T4Cb1類別")

            T4Cb1類別.DataSource = 顯示資料.Tables("T4Cb1類別")
            T4Cb1類別.DisplayMember = "類別" '名稱
            T4Cb1類別.ValueMember = "代碼"      '編號
            T4Cb1類別.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("T4Cb1類別: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T4Cb1原因載入()
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '原因' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '2' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T4Cb1原因")

            T4Cb1原因.DataSource = 顯示資料.Tables("T4Cb1原因").Copy
            T4Cb1原因.DisplayMember = "原因" '名稱
            T4Cb1原因.ValueMember = "代碼"   '編號
            T4Cb1原因.SelectedIndex = -1

            T4Cb2原因.DataSource = 顯示資料.Tables("T4Cb1原因").Copy
            T4Cb2原因.DisplayMember = "原因" '名稱
            T4Cb2原因.ValueMember = "代碼"   '編號
            T4Cb2原因.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("T4Cb原因: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T4Cb2情況載入()
        Dim SQLQuery As String = ""
        Dim 功能 As String = "0"
        Select Case T4Cb1類別.SelectedValue
            Case "1" : 功能 = 4
            Case "2" : 功能 = 5
        End Select
        SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '情況' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '" & 功能 & "' AND [對應1] = '" & T4Cb2原因.SelectedValue & "' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

        'T4Cb2情況.Items.Clear()
        If 初始載入 = "N" Then
            顯示資料.Tables("T4Cb1情況").Clear()
        End If
        'MsgBox(T4Cb2情況.Items.Count.ToString)


        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T4Cb1情況")


            T4Cb2情況.DataSource = 顯示資料.Tables("T4Cb1情況")
            T4Cb2情況.DisplayMember = "情況" '名稱
            T4Cb2情況.ValueMember = "代碼"      '編號
            T4Cb2情況.SelectedIndex = -1
            初始載入 = "N"
        Catch ex As Exception
            MsgBox("T4Cb1情況: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T4Cb2相符載入()
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '相符' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '3' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T4Cb1相符")

            T4Cb2相符.DataSource = 顯示資料.Tables("T4Cb1相符")
            T4Cb2相符.DisplayMember = "相符" '名稱
            T4Cb2相符.ValueMember = "代碼"      '編號
            T4Cb2相符.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("T4Cb1相符: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub T4Cb2結果載入()
        Dim SQLQuery As String = ""
        SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '結果' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '6' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "T4Cb1結果")

            T4Cb2結果.DataSource = 顯示資料.Tables("T4Cb1結果")
            T4Cb2結果.DisplayMember = "結果" '名稱
            T4Cb2結果.ValueMember = "代碼"      '編號
            T4Cb2結果.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("T4Cb1結果: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Cb印表機()
        Dim 預設印表機 As New PrintDocument()
        Dim i As Integer : Dim 所有印表機 As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
            Cb1印表機.Items.Add(所有印表機)
        Next
        Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName

    End Sub

    Private Sub Load初始化()
        TB客編.Text = "" : TB名稱.Text = "" : TB單號.Text = ""
    End Sub

    Private Sub Bu1查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1查詢.Click
        TB客編.Text = "" : TB名稱.Text = ""
        TP客戶查詢載入()
    End Sub

    Private Sub TP客戶查詢載入()
        If T1退貨記錄.RowCount > 0 Then
            If Rb1日期.Checked = False Then
                顯示資料.Tables("客戶明細").Clear() : End If '清除 客戶明細 資料
        End If
        Dim SQLQuery As String = ""
        If Rb1客戶1.Checked = True Then
            If Tb1客編.Text = "" And Tb1名稱.Text = "" Then
                MsgBox("未輸入查詢資料!!" & vbCrLf & "無法查詢：", 16, "錯誤") : Exit Sub
            End If

            Dim WHA0客編 As String = "" : Dim WHA1名稱 As String = ""
            Dim WHB0客編 As String = "ALL" : Dim WHB1名稱 As String = "ALL"

            If Tb1客編.Text <> "" Then : WHB0客編 = Tb1客編.Text : End If
            If Tb1名稱.Text <> "" Then : WHB1名稱 = Tb1名稱.Text : End If

            If Tb1客編.Text <> "" Then : WHA0客編 += " AND T0.[CardCode] Like '%" & Replace(Replace(Tb1客編.Text, "*", "%"), " ", "") & "%' " : End If
            If Tb1名稱.Text <> "" Then : WHA1名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(Tb1名稱.Text, "*", "%"), " ", "") & "%' " : End If

            SQLQuery = " SELECT T0.[CardName] AS '客戶名稱', T0.[CardCode] AS '客戶編號' FROM [OCRD] T0 "
            SQLQuery += " WHERE T0.[CardType] = 'C' "
            SQLQuery += WHA0客編 & WHA1名稱

        End If

        'If Rb1客戶2.Checked = True Then
        '    Select Case Cb1客戶名單.Text
        '        Case "10大客戶"
        '            SQLQuery = " SELECT [CardName] AS '客戶名稱', [CardCode] AS '客戶編號' FROM [OCRD] "
        '            SQLQuery += " WHERE [CardType] = 'C' AND [CardCode] IN ('A101048002','A101048000','A101048001','A101048004','A101048005','A101292000','A101292001','A101292002','A101292003','A101292004','A101292005','A101292006','A101292007','A101292008','A101292009','A102001000','A103015002','A106039001','A102069000','A101312000','A102134001','A102134000','A106038001','A106025000','A102143000') "
        '    End Select
        'End If

        If Rb1日期.Checked = True Then

            T1退貨單號載入()
        End If

        If Rb1日期.Checked = False Then
            Dim DBConn As SqlConnection = Login.DBConn
            Try
                MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
                MSSQL作業.Fill(顯示資料, "客戶明細")
                T1退貨記錄.DataSource = 顯示資料.Tables("客戶明細")
                T1退貨記錄.AutoResizeColumns()

            Catch ex As Exception
                MsgBox("客戶明細：" & ex.Message)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub T1退貨單號載入()
        If T1退貨單號.RowCount > 0 Then : 顯示資料.Tables("退貨單號").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = "    SELECT [單號] AS '退貨單號',[單號日期],[退貨日期],[客戶編號],[客戶名稱],[文件單號],[發票號碼],[發票日期],[責任單位],[聯絡人],[電話],[傳真],[地址], "
        SQLQuery += "          [處理方式],[退貨代碼],[退貨原因],[司機代碼],[運輸司機], "
        SQLQuery += "          ISNULL(CASE [來源] WHEN 'AR發票' THEN (SELECT [Comments] FROM [KaiShing].[dbo].[OINV] WHERE [DocNum] = T0.[文件單號] AND [ObjType] = '13') "
        SQLQuery += "                             WHEN '交貨單' THEN (SELECT [Comments] FROM [KaiShing].[dbo].[ODLN] WHERE [DocNum] = T0.[文件單號] AND [ObjType] = '15') "
        SQLQuery += "          END, '') AS '備註1',"
        SQLQuery += "          [備註] AS '備註2',[啟用],[輸入者],[來源],[類別],[稅額],[總計],[列印否],[列印次數] "
        SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表頭] T0 LEFT JOIN "
        SQLQuery += "          (SELECT [FldValue] AS '代碼',[Descr] AS '退貨原因' FROM [KaiShing].[dbo].[UFD1] WHERE [TableID] = 'OINV' AND [FieldID] = '112') T2 ON [退貨代碼] = [代碼] "
        SQLQuery += "                                                LEFT JOIN "
        SQLQuery += "          (SELECT [司機] AS '運輸司機',[編號] FROM [KaiShingPlug].[dbo].[檢_凱馨司機]) T3 ON [司機代碼] = [編號] "
        SQLQuery += "    WHERE ([單號日期] BETWEEN '" & Format(De1開始.Value.Date, "yyyy-MM-dd") & "' AND '" & Format(De1結束.Value.Date, "yyyy-MM-dd") & "' ) AND [啟用] = 'Y' "
        SQLQuery += " ORDER BY [單號日期] DESC, [單號] DESC "

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
        TB客編.Text = T1退貨單號.CurrentRow.Cells("客戶編號").Value
        TB名稱.Text = T1退貨單號.CurrentRow.Cells("客戶名稱").Value
        TB單號.Text = T1退貨單號.CurrentRow.Cells("退貨單號").Value
        'Bu1新增.Visible = False : Bu1修改.Visible = True : Bu1刪除.Visible = True : Bu1列印.Visible = True
        Bu1新增.Visible = True : Bu1列印.Visible = True
        T1退貨明細載入()
        T4退貨記錄載入(2)
        T1退貨明細.AutoResizeColumns()
        T1退貨記錄.AutoResizeColumns()

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


    Private Sub Bu1新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1新增.Click
        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨數量) : Me.TabControl1.TabPages.Remove(Tp退貨作業) : End If
        Me.TabControl1.SelectedTab = Me.Tp退貨數量

        T4退貨數量載入()
        T4退貨記錄載入(1)
        T4輸入資料.AutoResizeColumns()
        T4退貨記錄.AutoResizeColumns()

        T4分頁Load初始化()

        Dim 數量1 As Double = 0
        Dim count1 As Integer = T4輸入資料.Rows.Count
        For i As Integer = count1 - 1 To 0 Step -1
            數量1 += CDbl(T4輸入資料.Rows(i).Cells("退貨數量").Value)
        Next
        Lt4合計2.Text = 數量1


    End Sub

    Private Sub T4退貨數量載入()
        If T4輸入資料.RowCount > 0 Then : 顯示資料.Tables("退貨數量").Clear() : End If '清除資料
        Dim SQLQuery As String = ""

        SQLQuery = "     SELECT [ID],[單號],[存貨編號],[存編名稱],[退貨數量],[營_類別] AS '類別代碼',T2.[類別],[營_退貨原因] AS '原因代碼',T3.[原因], "
        SQLQuery += "           [營_補充說明] AS '補充說明',[列號] "
        SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折明細] T1 LEFT JOIN "
        SQLQuery += "     (SELECT [優先順序] AS '代碼',[對應2] AS '類別' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '1' AND [啟用否] = 'Y' "
        SQLQuery += "     ) T2 ON T1.[營_類別] = T2.[代碼]           LEFT JOIN "
        SQLQuery += "     (SELECT [優先順序] AS '代碼',[對應2] AS '原因' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '2' AND [啟用否] = 'Y' "
        SQLQuery += "     ) T3 ON T1.[營_類別] = T3.[代碼]    "
        SQLQuery += "     WHERE [單號] = '" & TB單號.Text & "' AND [啟用] = 'Y' "
        SQLQuery += "  ORDER BY [ID] "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "退貨數量")
            T4輸入資料.DataSource = 顯示資料.Tables("退貨數量")
            T4退貨數量顯示()

        Catch ex As Exception
            MsgBox("退貨數量：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub T4退貨數量顯示()
        For Each column As DataGridViewColumn In T4輸入資料.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 0
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 : column.Visible = False
                Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 2
                Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 3
                Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 4
                Case "類別代碼" : column.HeaderText = "類別代碼" : column.DisplayIndex = 5 : column.Visible = False
                Case "類別" : column.HeaderText = "類別" : column.DisplayIndex = 6
                Case "原因代碼" : column.HeaderText = "原因代碼" : column.DisplayIndex = 7 : column.Visible = False
                Case "原因" : column.HeaderText = "原因" : column.DisplayIndex = 8
                Case "補充說明" : column.HeaderText = "補充說明" : column.DisplayIndex = 9
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 10 : column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T4輸入資料_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T4輸入資料.CellClick
        情況載入 = "Y"
        Lt4ID.Text = T4輸入資料.CurrentRow.Cells("ID").Value
        Lt4存編.Text = T4輸入資料.CurrentRow.Cells("存貨編號").Value
        Lt4名稱.Text = T4輸入資料.CurrentRow.Cells("存編名稱").Value
        T4Cb1類別.SelectedValue = T4輸入資料.CurrentRow.Cells("類別代碼").Value
        T4Cb1原因.SelectedValue = T4輸入資料.CurrentRow.Cells("原因代碼").Value
        T4Cb2原因.SelectedValue = T4輸入資料.CurrentRow.Cells("原因代碼").Value
        Lt4數量.Text = T4輸入資料.CurrentRow.Cells("退貨數量").Value
        T4Lt1說明.Text = T4輸入資料.CurrentRow.Cells("補充說明").Value
        T4退貨記錄合計更新()

    End Sub

    Private Sub T4退貨記錄載入(ByVal 作業 As String)
        Select Case 作業
            Case "1"
                If T4退貨記錄.RowCount > 0 Then : 顯示資料.Tables("退貨記錄").Clear() : End If '清除資料
            Case "2"
                If T1退貨記錄.RowCount > 0 Then : 顯示資料.Tables("記錄顯示").Clear() : End If '清除資料
        End Select

        'If T4退貨記錄.RowCount > 0 Then : 顯示資料.Tables("退貨記錄").Clear() : End If '清除資料
        Dim SQLQuery As String = ""

        SQLQuery = "     SELECT T1.[ID],T1.[單號],T1.[存貨編號],T2.[存編名稱],T2.[營_類別] AS '類別代碼',T1.[品_相符] AS '相符代碼'"
        SQLQuery += "          ,(SELECT [對應2] FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '3' AND [優先順序] = T1.[品_相符]     AND [啟用否] = 'Y') AS '相符'"
        SQLQuery += "          ,T1.[品_退貨原因] AS '原因代碼'"
        SQLQuery += "          ,(SELECT [對應2] FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '2' AND [優先順序] = T1.[品_退貨原因] AND [啟用否] = 'Y') AS '原因'"
        SQLQuery += "          ,T1.[品_退貨情況] AS '情況代碼'"
        SQLQuery += "          ,(SELECT [對應2]FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = (CASE T2.[營_類別] WHEN 1 THEN 4 ELSE 5 END) AND [對應1] = T1.[品_退貨原因] AND [優先順序] = T1.[品_退貨情況] AND [啟用否] = 'Y') AS '情況'"
        SQLQuery += "          ,T1.[品_退貨結果] AS '結果代碼'"
        SQLQuery += "          ,(SELECT [對應2] FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '6' AND [優先順序] = T1.[品_退貨結果] AND [啟用否] = 'Y') AS '結果'"
        SQLQuery += "          ,T1.[品_退貨數量] AS '確認數量',T1.[品_補充說明] AS '補充說明',T1.[IDSave] AS 'IDS' "
        SQLQuery += "      FROM [KaiShingPlug].[dbo].[品_退貨明細] T1 LEFT JOIN [KaiShingPlug].[dbo].[營_退折明細] T2 ON T1.[單號] = T2.[單號] AND T1.[IDSave] = T2.[ID] AND T2.[啟用] = 'Y'"
        SQLQuery += "     WHERE T1.[單號] = '" & TB單號.Text & "' AND T1.[啟用] = 'Y'"
        SQLQuery += "  ORDER BY [ID] "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            Select Case 作業
                Case "1"
                    MSSQL作業.Fill(顯示資料, "退貨記錄")
                    T4退貨記錄.DataSource = 顯示資料.Tables("退貨記錄")
                    T4退貨記錄顯示(1)
                Case "2"
                    MSSQL作業.Fill(顯示資料, "記錄顯示")
                    T1退貨記錄.DataSource = 顯示資料.Tables("記錄顯示")
                    T4退貨記錄顯示(2)
            End Select

            'T4退貨數量合計更新()
        Catch ex As Exception
            MsgBox("退貨記錄：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub T4退貨記錄顯示(ByVal 顯示 As String)
        Select Case 顯示
            Case "1" ': 顯示2 = T4退貨記錄.Columns
                For Each column As DataGridViewColumn In T4退貨記錄.Columns
                    column.Visible = True : column.ReadOnly = True
                    Select Case column.Name
                        Case "IDS" : column.HeaderText = "IDS" : column.DisplayIndex = 0
                        Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 : column.Visible = False
                        Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 2
                        Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 3
                        Case "確認數量" : column.HeaderText = "確認數量" : column.DisplayIndex = 4
                        Case "類別代碼" : column.HeaderText = "類別代碼" : column.DisplayIndex = 5 : column.Visible = False
                        Case "相符代碼" : column.HeaderText = "相符代碼" : column.DisplayIndex = 6 : column.Visible = False
                        Case "相符" : column.HeaderText = "相符" : column.DisplayIndex = 7
                        Case "原因代碼" : column.HeaderText = "原因代碼" : column.DisplayIndex = 8 : column.Visible = False
                        Case "原因" : column.HeaderText = "原因" : column.DisplayIndex = 9
                        Case "情況代碼" : column.HeaderText = "情況代碼" : column.DisplayIndex = 10 : column.Visible = False
                        Case "情況" : column.HeaderText = "情況" : column.DisplayIndex = 11
                        Case "結果代碼" : column.HeaderText = "結果代碼" : column.DisplayIndex = 12 : column.Visible = False
                        Case "結果" : column.HeaderText = "結果" : column.DisplayIndex = 13
                        Case "補充說明" : column.HeaderText = "補充說明" : column.DisplayIndex = 14
                        Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 15 : column.Visible = False '
                        Case Else
                            column.Visible = False
                    End Select
                Next

            Case "2" ': 顯示2 = T1退貨記錄.Columns
                For Each column As DataGridViewColumn In T1退貨記錄.Columns
                    column.Visible = True : column.ReadOnly = True
                    Select Case column.Name
                        Case "IDS" : column.HeaderText = "IDS" : column.DisplayIndex = 0
                        Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 : column.Visible = False
                        Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 2
                        Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 3
                        Case "確認數量" : column.HeaderText = "確認數量" : column.DisplayIndex = 4
                        Case "類別代碼" : column.HeaderText = "類別代碼" : column.DisplayIndex = 5 : column.Visible = False
                        Case "相符代碼" : column.HeaderText = "相符代碼" : column.DisplayIndex = 6 : column.Visible = False
                        Case "相符" : column.HeaderText = "相符" : column.DisplayIndex = 7
                        Case "原因代碼" : column.HeaderText = "原因代碼" : column.DisplayIndex = 8 : column.Visible = False
                        Case "原因" : column.HeaderText = "原因" : column.DisplayIndex = 9
                        Case "情況代碼" : column.HeaderText = "情況代碼" : column.DisplayIndex = 10 : column.Visible = False
                        Case "情況" : column.HeaderText = "情況" : column.DisplayIndex = 11
                        Case "結果代碼" : column.HeaderText = "結果代碼" : column.DisplayIndex = 12 : column.Visible = False
                        Case "結果" : column.HeaderText = "結果" : column.DisplayIndex = 13
                        Case "補充說明" : column.HeaderText = "補充說明" : column.DisplayIndex = 14
                        Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 15 : column.Visible = False '
                        Case Else
                            column.Visible = False
                    End Select
                Next
        End Select



    End Sub

    Private Sub T4Cb2原因_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4Cb2原因.SelectedIndexChanged
        If 情況載入 = "Y" Then
            T4Cb2情況載入()
            T4Cb2情況.SelectedIndex = -1
        End If

    End Sub

    Private Sub Bu4輸入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4輸入.Click
        If CDbl(Lt4數量.Text) < (CDbl(Lt4合計.Text) + CDbl(Lt42數量.Text)) Then
            MsgBox("錯誤!!大於退貨數量")
            Lt42數量.Text = ""
            Exit Sub
        End If

        If T4Cb2相符.SelectedIndex = -1 And T4Cb2原因.SelectedIndex = -1 And T4Cb2情況.SelectedIndex = -1 And T4Cb2結果.SelectedIndex = -1 Then
            MsgBox("錯誤!!有異常選項未選擇") : Exit Sub
        End If

        If CStr(Lt42數量.Text) = "" Or CDbl(Lt42數量.Text) <> 0 Then
            Dim Row As DataRow
            Row = 顯示資料.Tables("退貨記錄").NewRow
            Row.Item("ID") = "0"
            Row.Item("單號") = ""
            Row.Item("存貨編號") = Lt4存編.Text
            Row.Item("存編名稱") = Lt4名稱.Text
            Row.Item("類別代碼") = ""
            Row.Item("相符代碼") = T4Cb2相符.SelectedValue.ToString
            Row.Item("相符") = T4Cb2相符.Text
            Row.Item("原因代碼") = T4Cb2原因.SelectedValue.ToString
            Row.Item("原因") = T4Cb2原因.Text
            Row.Item("情況代碼") = T4Cb2情況.SelectedValue.ToString
            Row.Item("情況") = T4Cb2情況.Text
            Row.Item("結果代碼") = T4Cb2結果.SelectedValue.ToString
            Row.Item("結果") = T4Cb2結果.Text
            Row.Item("確認數量") = Lt42數量.Text
            Row.Item("補充說明") = T4Lt2說明.Text
            Row.Item("IDS") = Lt4ID.Text

            顯示資料.Tables("退貨記錄").Rows.Add(Row)
            T4退貨記錄合計更新()

            Lt42數量.Text = ""
            T4Lt2說明.Text = ""
        Else
            MsgBox("輸入錯誤資料")
        End If
        T4輸入資料.AutoResizeColumns()

        Dim 數量2 As Double = 0
        Dim count2 As Integer = T4退貨記錄.Rows.Count
        For i As Integer = count2 - 1 To 0 Step -1
            數量2 += CDbl(T4退貨記錄.Rows(i).Cells("確認數量").Value)
        Next
        Lt4合計1.Text = 數量2


    End Sub

    Private Sub T4退貨記錄合計更新()
        Dim 數量 As Double = 0
        Dim count As Integer = T4退貨記錄.Rows.Count
        For i As Integer = count - 1 To 0 Step -1
            'If T4退貨記錄.Rows(i).Cells("存貨編號").Value = Lt4存編.Text Then
            '    數量 = +數量 + T4退貨記錄.Rows(i).Cells("確認數量").Value
            'End If
            If T4退貨記錄.Rows(i).Cells("IDS").Value = Lt4ID.Text Then
                數量 = +數量 + T4退貨記錄.Rows(i).Cells("確認數量").Value
            End If
        Next
        Lt4合計.Text = Format(數量, "#0.#")
        T4退貨記錄.AutoResizeColumns()

    End Sub

    Private Sub Bu4移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4移除.Click
        If Lt4存編.Text = T4退貨記錄.CurrentRow.Cells("存貨編號").Value Then
            Dim i As Integer = 0
            i = T4退貨記錄.CurrentCell.RowIndex()   '
            Dim oAns As Integer
            oAns = MsgBox("是否確定刪除選定資料  ID" & T4退貨記錄.CurrentRow.Cells("IDS").Value & vbCrLf & T4退貨記錄.CurrentRow.Cells("存貨編號").Value, MsgBoxStyle.YesNo, "刪除選定資料")
            If oAns = MsgBoxResult.Yes Then  'Yes執行區
                T4退貨記錄.Rows.Remove(T4退貨記錄.Rows(i))  '移除
                T4退貨記錄合計更新()

            End If
        Else
            MsgBox("品項不同無法移除")
        End If
    End Sub

    Private Sub Bu4存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4存檔.Click
        If T4退貨記錄.RowCount = 0 Then : MsgBox("無退貨品項") : Exit Sub : End If

        'If T4退貨總數合計更新() = 0 Then : Else : MsgBox("輸入數量不平，請檢查正常後方可存檔") : Exit Sub : End If
        If (CDbl(Lt4合計1.Text) - CDbl(Lt4合計2.Text)) = 0 Then
            : Else : MsgBox("輸入數量不平，請檢查正常後方可存檔") : Exit Sub : End If

        T4存檔(TB單號.Text)

        If T4輸入資料.RowCount > 0 Then : 顯示資料.Tables("退貨數量").Clear() : End If '清除資料
        If T4退貨記錄.RowCount > 0 Then : 顯示資料.Tables("退貨記錄").Clear() : End If '清除資料
        情況載入 = "N"

        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨作業) : Me.TabControl1.TabPages.Remove(Tp退貨數量) : End If
        Me.TabControl1.SelectedTab = Me.Tp退貨作業

        T4退貨記錄載入(2)
        T1退貨記錄.AutoResizeColumns()

        Load初始化()

    End Sub

    Private Function T4退貨總數合計更新()
        Dim 數量1 As Double = 0 : Dim 數量2 As Double = 0 : Dim oReturn As Integer = 0
        Dim count1 As Integer = T4輸入資料.Rows.Count
        For i As Integer = count1 - 1 To 0 Step -1
            數量1 += CDbl(T4輸入資料.Rows(i).Cells("退貨數量").Value)
        Next
        Dim count2 As Integer = T4退貨記錄.Rows.Count
        For i As Integer = count2 - 1 To 0 Step -1
            數量2 += CDbl(T4退貨記錄.Rows(i).Cells("確認數量").Value)
        Next
        MsgBox(數量1 & "," & 數量2 & "," & (數量1 - 數量2))
        If (數量1 - 數量2) = 0 Then
            oReturn = 0
        Else
            oReturn = 1
        End If

        Return oReturn
    End Function

    Private Sub T4存檔(ByVal 單號 As String)
        Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        '修正_先作廢
        SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[品_退貨明細] "
        SQLADD1 += "    SET [啟用]     = 'N', "
        SQLADD1 += "        [修改時間] = GETDATE() "
        SQLADD1 += "  WHERE [單號] = '" & 單號 & "' AND 啟用 = 'Y' " & vbCrLf

        For i As Integer = 0 To T4退貨記錄.RowCount - 1
            SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[品_退貨明細] "
            SQLADD2 += " ([單號],[IDSave],[存貨編號],[品_退貨數量],[品_退貨原因],[品_相符],[品_退貨情況],[品_退貨結果],[品_補充說明],[啟用],[新增時間]) VALUES "
            SQLADD2 += " ('" & 單號 & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("IDS").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("存貨編號").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("確認數量").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("原因代碼").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("相符代碼").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("情況代碼").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("結果代碼").Value & "', "
            SQLADD2 += "  '" & T4退貨記錄.Rows(i).Cells("補充說明").Value & "', "
            SQLADD2 += "  'Y',GETDATE() )"
        Next
        'MsgBox(SQLADD1 + SQLADD2)

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T4分頁Load初始化()
        '營業
        T4Cb1類別.SelectedIndex = -1
        T4Cb1原因.SelectedIndex = -1
        Lt4數量.Text = ""
        Lt4ID.Text = ""
        T4Lt1說明.Text = ""

        '品管
        T4Cb2相符.SelectedIndex = -1
        T4Cb2原因.SelectedIndex = -1
        T4Cb2情況.SelectedIndex = -1
        T4Cb2結果.SelectedIndex = -1
        Lt42數量.Text = ""
        Lt4合計.Text = 0
        Lt4合計1.Text = 0
        Lt4合計2.Text = 0
        T4Lt2說明.Text = ""

    End Sub

    Private Sub Bu4放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4放棄.Click

        If T4輸入資料.RowCount > 0 Then : 顯示資料.Tables("退貨數量").Clear() : End If '清除資料
        If T4退貨記錄.RowCount > 0 Then : 顯示資料.Tables("退貨記錄").Clear() : End If '清除資料
        T4分頁Load初始化()

        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨作業) : Me.TabControl1.TabPages.Remove(Tp退貨數量) : End If
        Me.TabControl1.SelectedTab = Me.Tp退貨作業

        Load初始化()

    End Sub




End Class






    'Private Sub 載入Cb初始()
    '    Key單人員載入()
    '    Cb3司機載入()
    '    Cb3退貨原因載入()
    '    T4Cb1類別載入()
    '    T4Cb1原因載入()
    '    Cb印表機()
    'End Sub

    'Private Sub Key單人員載入()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = " SELECT T0.[empID], T0.[lastName] FROM [OHEM] T0 WHERE T0.[dept] = '5' AND T0.[status] = '1' AND T0.[position] NOT IN ('20') "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "Key單人員")

    '        Cb3Key單人員.DataSource = 顯示資料.Tables("Key單人員")
    '        Cb3Key單人員.DisplayMember = "lastName" '名稱
    '        Cb3Key單人員.ValueMember = "empID"      '編號
    '        Cb3Key單人員.SelectedIndex = -1

    '    Catch ex As Exception
    '        MsgBox("Key單人員: " & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub Cb3司機載入()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = " SELECT [司機],[編號] FROM [KaiShingPlug].[dbo].[檢_凱馨司機] "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "司機明細")

    '        Cb3運輸司機.DataSource = 顯示資料.Tables("司機明細")
    '        Cb3運輸司機.DisplayMember = "司機"
    '        Cb3運輸司機.ValueMember = "編號"
    '        Cb3運輸司機.SelectedIndex = -1

    '    Catch ex As Exception
    '        MsgBox("司機明細：" & ex.Message)
    '        Exit Sub
    '    End Try

    'End Sub

    'Private Sub Cb3退貨原因載入()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = " SELECT [FldValue] AS '代碼',[Descr] AS '說明' FROM [KaiShing].[dbo].[UFD1] WHERE [TableID] = 'OINV' AND [FieldID] = '112' "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "退貨原因")

    '        Cb3退貨原因.DataSource = 顯示資料.Tables("退貨原因")
    '        Cb3退貨原因.DisplayMember = "說明"
    '        Cb3退貨原因.ValueMember = "代碼"
    '        Cb3退貨原因.SelectedIndex = 8

    '    Catch ex As Exception
    '        MsgBox("退貨原因: " & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub T4Cb1類別載入()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '類別' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '1' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "T4Cb1類別")

    '        T4Cb1類別.DataSource = 顯示資料.Tables("T4Cb1類別")
    '        T4Cb1類別.DisplayMember = "類別" '名稱
    '        T4Cb1類別.ValueMember = "代碼"      '編號
    '        T4Cb1類別.SelectedIndex = -1

    '    Catch ex As Exception
    '        MsgBox("T4Cb1類別: " & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub T4Cb1原因載入()
    '    Dim SQLQuery As String = ""
    '    SQLQuery = " SELECT [優先順序] AS '代碼',[對應2] AS '原因' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '2' AND [啟用否] = 'Y' ORDER BY CAST([優先順序] AS INT) "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "T4Cb1原因")

    '        T4Cb1原因.DataSource = 顯示資料.Tables("T4Cb1原因")
    '        T4Cb1原因.DisplayMember = "原因" '名稱
    '        T4Cb1原因.ValueMember = "代碼"      '編號
    '        T4Cb1原因.SelectedIndex = -1

    '    Catch ex As Exception
    '        MsgBox("T4Cb1原因: " & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub Cb印表機()
    '    Dim 預設印表機 As New PrintDocument()
    '    'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName
    '    Dim i As Integer : Dim 所有印表機 As String
    '    For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
    '        所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
    '        Cb1印表機.Items.Add(所有印表機)
    '    Next
    '    Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName

    'End Sub


    'Private Sub Load初始化()
    '    Lt作業.Text = ""

    '    '參數
    '    Lt文件單號.Text = "" : Lt過帳日期.Text = "" : Lt退貨日期.Text = ""
    '    Lt發票號碼.Text = "" : Lt發票日期.Text = "" : Lt責任單位.Text = ""
    '    Lt聯絡人.Text = "" : Lt電話.Text = "" : Lt傳真.Text = "" : Lt地址.Text = ""
    '    Lt處理方式.Text = "" : Lt備註1.Text = "" : Lt備註2.Text = ""
    '    Lt輸入者.Text = ""
    '    Lt退貨代碼.Text = "" : Lt退貨原因.Text = ""
    '    Lt司機代碼.Text = "" : Lt運輸司機.Text = ""
    '    Lt來源.Text = "" : Lt類別.Text = "" : Lt稅額.Text = "" : Lt總計.Text = ""
    '    Cb3Key單人員.SelectedIndex = -1

    '    'T1分頁
    '    Cb1客戶名單.SelectedIndex = 0
    '    Bu1新增.Visible = False : Bu1修改.Visible = False : Bu1刪除.Visible = False : Bu1列印.Visible = False

    '    'T2分頁
    '    Cb2退單來源.SelectedIndex = 0
    '    Lt2來源.Text = "" : Lt2單號.Text = ""
    '    Bu2選單.Visible = False

    '    'T3分頁
    '    Cb3折退類別.Enabled = True
    '    Cb3折退類別.SelectedIndex = -1
    '    Cb3責任單位.SelectedIndex = -1
    '    Cb3處理方式.SelectedIndex = 0
    '    Cb3退貨原因.SelectedIndex = 8
    '    Cb3運輸司機.SelectedIndex = -1
    '    Cb3Key單人員.SelectedIndex = -1
    '    Tb3稅額.Text = 0
    '    Tb3總計.Text = 0
    '    Tb3備註.Text = ""

    '    'T4分頁
    '    Lt3名稱.Text = ""
    '    Lt4存編.Text = ""
    '    Lt4名稱.Text = ""
    '    Lt4數量.Text = 0
    '    Lt4可退.Text = 0
    '    Lt4合計.Text = 0
    '    Lt4列號.Text = ""
    '    Lt4ID.Text = ""
    '    T4Cb1類別.SelectedIndex = -1
    '    T4Cb1原因.SelectedIndex = -1
    '    T4Lt4說明.Text = ""

    '    'T4單號空白 = ""

    'End Sub

    ''T1分頁作業開始
    'Private Sub Bu1查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1查詢.Click
    '    TB客編.Text = "" : TB名稱.Text = ""
    '    TP客戶查詢載入()
    'End Sub

    'Private Sub TP客戶查詢載入()
    '    If T1客戶明細.RowCount > 0 Then : 顯示資料.Tables("客戶明細").Clear() : End If '清除 客戶明細 資料
    '    Dim SQLQuery As String = ""
    '    If Rb1客戶1.Checked = True Then
    '        If Tb1客編.Text = "" And Tb1名稱.Text = "" Then
    '            MsgBox("未輸入查詢資料!!" & vbCrLf & "無法查詢：", 16, "錯誤") : Exit Sub
    '        End If

    '        Dim WHA0客編 As String = "" : Dim WHA1名稱 As String = ""
    '        Dim WHB0客編 As String = "ALL" : Dim WHB1名稱 As String = "ALL"

    '        If Tb1客編.Text <> "" Then : WHB0客編 = Tb1客編.Text : End If
    '        If Tb1名稱.Text <> "" Then : WHB1名稱 = Tb1名稱.Text : End If

    '        If Tb1客編.Text <> "" Then : WHA0客編 += " AND T0.[CardCode] Like '%" & Replace(Replace(Tb1客編.Text, "*", "%"), " ", "") & "%' " : End If
    '        If Tb1名稱.Text <> "" Then : WHA1名稱 += " AND T0.[CardName] Like '%" & Replace(Replace(Tb1名稱.Text, "*", "%"), " ", "") & "%' " : End If

    '        SQLQuery = " SELECT T0.[CardName] AS '客戶名稱', T0.[CardCode] AS '客戶編號' FROM [OCRD] T0 "
    '        SQLQuery += " WHERE T0.[CardType] = 'C' "
    '        SQLQuery += WHA0客編 & WHA1名稱
    '        'SQLQuery += "   AND T0.[CardCode] NOT IN ('A101048002','A101048000','A101048001','A101048004','A101048005','A101292000','A101292001','A101292002','A101292003','A101292004','A101292005','A101292006','A101292007','A101292008','A101292009','A102001000','A103015002','A106039001','A102069000','A101312000','A102134001','A102134000','A106038001','A106025000','A102143000') "

    '    End If

    '    If Rb1客戶2.Checked = True Then
    '        Select Case Cb1客戶名單.Text
    '            Case "10大客戶"
    '                SQLQuery = " SELECT [CardName] AS '客戶名稱', [CardCode] AS '客戶編號' FROM [OCRD] "
    '                SQLQuery += " WHERE [CardType] = 'C' AND [CardCode] IN ('A101048002','A101048000','A101048001','A101048004','A101048005','A101292000','A101292001','A101292002','A101292003','A101292004','A101292005','A101292006','A101292007','A101292008','A101292009','A102001000','A103015002','A106039001','A102069000','A101312000','A102134001','A102134000','A106038001','A106025000','A102143000') "
    '        End Select
    '    End If

    '    If Rb1日期.Checked = True Then

    '        T1退貨單號載入()
    '    End If

    '    If Rb1日期.Checked = False Then
    '        Dim DBConn As SqlConnection = Login.DBConn
    '        Try
    '            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '            MSSQL作業.Fill(顯示資料, "客戶明細")
    '            T1客戶明細.DataSource = 顯示資料.Tables("客戶明細")
    '            T1客戶明細.AutoResizeColumns()

    '        Catch ex As Exception
    '            MsgBox("客戶明細：" & ex.Message)
    '            Exit Sub
    '        End Try
    '    End If
    'End Sub

    'Private Sub T1客戶明細_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1客戶明細.CellClick
    '    TB客編.Text = T1客戶明細.CurrentRow.Cells("客戶編號").Value
    '    TB名稱.Text = T1客戶明細.CurrentRow.Cells("客戶名稱").Value
    '    TB單號.Text = ""
    '    Bu1新增.Visible = True : Bu1修改.Visible = False : Bu1刪除.Visible = False : Bu1列印.Visible = False
    '    T1退貨單號載入()

    '    'Dim i As Integer = 0
    '    'i = T1客戶明細.CurrentCell.RowIndex()
    '    'MsgBox(i)
    'End Sub

    'Private Sub T1退貨單號載入()
    '    If T1退貨單號.RowCount > 0 Then : 顯示資料.Tables("退貨單號").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    SQLQuery = "    SELECT [單號] AS '退貨單號',[單號日期],[退貨日期],[客戶編號],[客戶名稱],[文件單號],[發票號碼],[發票日期],[責任單位],[聯絡人],[電話],[傳真],[地址], "
    '    SQLQuery += "          [處理方式],[退貨代碼],[退貨原因],[司機代碼],[運輸司機], "
    '    SQLQuery += "          ISNULL(CASE [來源] WHEN 'AR發票' THEN (SELECT [Comments] FROM [KaiShing].[dbo].[OINV] WHERE [DocNum] = T0.[文件單號] AND [ObjType] = '13') "
    '    SQLQuery += "                             WHEN '交貨單' THEN (SELECT [Comments] FROM [KaiShing].[dbo].[ODLN] WHERE [DocNum] = T0.[文件單號] AND [ObjType] = '15') "
    '    SQLQuery += "          END, '') AS '備註1',"
    '    SQLQuery += "          [備註] AS '備註2',[啟用],[輸入者],[來源],[類別],[稅額],[總計],[列印否],[列印次數] "
    '    SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表頭] T0 LEFT JOIN "
    '    SQLQuery += "          (SELECT [FldValue] AS '代碼',[Descr] AS '退貨原因' FROM [KaiShing].[dbo].[UFD1] WHERE [TableID] = 'OINV' AND [FieldID] = '112') T2 ON [退貨代碼] = [代碼] "
    '    SQLQuery += "                                                LEFT JOIN "
    '    SQLQuery += "          (SELECT [司機] AS '運輸司機',[編號] FROM [KaiShingPlug].[dbo].[檢_凱馨司機]) T3 ON [司機代碼] = [編號] "

    '    If Rb1日期.Checked = True Then
    '        SQLQuery += "    WHERE ([單號日期] BETWEEN '" & Format(De1開始.Value.Date, "yyyy-MM-dd") & "' AND '" & Format(De1結束.Value.Date, "yyyy-MM-dd") & "' ) AND [啟用] = 'Y' "
    '    Else
    '        SQLQuery += "    WHERE [客戶編號] = '" & TB客編.Text & "' AND [啟用] = 'Y' "
    '    End If
    '    SQLQuery += " ORDER BY [單號日期] DESC, [單號] DESC "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "退貨單號")
    '        T1退貨單號.DataSource = 顯示資料.Tables("退貨單號")
    '        T1退貨單號.AutoResizeColumns()

    '    Catch ex As Exception
    '        MsgBox("單號查詢：" & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub


    'Private Sub T1退貨單號_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1退貨單號.CellClick
    '    TB客編.Text = T1退貨單號.CurrentRow.Cells("客戶編號").Value
    '    TB名稱.Text = T1退貨單號.CurrentRow.Cells("客戶名稱").Value
    '    TB單號.Text = T1退貨單號.CurrentRow.Cells("退貨單號").Value
    '    Lt文件單號.Text = T1退貨單號.CurrentRow.Cells("文件單號").Value
    '    Lt過帳日期.Text = T1退貨單號.CurrentRow.Cells("單號日期").Value
    '    Lt退貨日期.Text = T1退貨單號.CurrentRow.Cells("退貨日期").Value
    '    Lt發票號碼.Text = T1退貨單號.CurrentRow.Cells("發票號碼").Value
    '    Lt發票日期.Text = T1退貨單號.CurrentRow.Cells("發票日期").Value
    '    Lt責任單位.Text = T1退貨單號.CurrentRow.Cells("責任單位").Value
    '    Lt聯絡人.Text = T1退貨單號.CurrentRow.Cells("聯絡人").Value
    '    Lt電話.Text = T1退貨單號.CurrentRow.Cells("電話").Value
    '    Lt傳真.Text = T1退貨單號.CurrentRow.Cells("傳真").Value
    '    Lt地址.Text = T1退貨單號.CurrentRow.Cells("地址").Value
    '    Lt處理方式.Text = T1退貨單號.CurrentRow.Cells("處理方式").Value
    '    Lt退貨代碼.Text = T1退貨單號.CurrentRow.Cells("退貨代碼").Value
    '    Lt退貨原因.Text = T1退貨單號.CurrentRow.Cells("退貨原因").Value
    '    Lt司機代碼.Text = T1退貨單號.CurrentRow.Cells("司機代碼").Value
    '    Lt運輸司機.Text = T1退貨單號.CurrentRow.Cells("運輸司機").Value
    '    Lt備註1.Text = T1退貨單號.CurrentRow.Cells("備註1").Value
    '    Lt備註2.Text = T1退貨單號.CurrentRow.Cells("備註2").Value
    '    Lt輸入者.Text = T1退貨單號.CurrentRow.Cells("輸入者").Value
    '    Lt來源.Text = T1退貨單號.CurrentRow.Cells("來源").Value
    '    Lt類別.Text = T1退貨單號.CurrentRow.Cells("類別").Value
    '    Lt稅額.Text = T1退貨單號.CurrentRow.Cells("稅額").Value
    '    Lt總計.Text = T1退貨單號.CurrentRow.Cells("總計").Value

    '    Bu1新增.Visible = False : Bu1修改.Visible = True : Bu1刪除.Visible = True : Bu1列印.Visible = True
    '    T1退貨明細載入()

    'End Sub

    'Private Sub T1退貨明細載入()
    '    If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    'SQLQuery = 載入來源資料(Cb2退單來源.Text, T2選擇單號.CurrentRow.Cells("文件單號").Value)

    '    SQLQuery = "    SELECT [存貨編號],[存編名稱],[退貨數量],[數量],[出貨重量],[單位], "
    '    SQLQuery += "          [數量2],REPLACE([小單位],' ','') AS '小單位',CAST([單價] AS NUMERIC(15,4)) AS '單價',[計價],[金額], "
    '    SQLQuery += "          [倉別],[稅碼],[列號],[備註] "
    '    SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表身] "
    '    SQLQuery += "    WHERE [單號] = '" & TB單號.Text & "' AND [啟用] = 'Y' "
    '    SQLQuery += " ORDER BY [列號] "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "T1退貨明細")
    '        T1退貨明細.DataSource = 顯示資料.Tables("T1退貨明細")
    '        T1退貨明細顯示()
    '        T1退貨明細.AutoResizeColumns()
    '    Catch ex As Exception
    '        MsgBox("退貨明細：" & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub T1退貨明細顯示()
    '    For Each column As DataGridViewColumn In T1退貨明細.Columns
    '        column.Visible = True : column.ReadOnly = True
    '        Select Case column.Name
    '            Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 0 : column.Frozen = True
    '            Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
    '            Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 2
    '            Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3 : column.Visible = False
    '            Case "出貨重量" : column.HeaderText = "出貨重量" : column.DisplayIndex = 4
    '            Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5
    '            Case "數量2" : column.HeaderText = "數量2" : column.DisplayIndex = 6
    '            Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 7
    '            Case "單價" : column.HeaderText = "單價" : column.DisplayIndex = 8
    '            Case "計價" : column.HeaderText = "計價" : column.DisplayIndex = 9
    '            Case "金額" : column.HeaderText = "金額" : column.DisplayIndex = 10
    '            Case "倉別" : column.HeaderText = "倉別" : column.DisplayIndex = 11
    '            Case "稅碼" : column.HeaderText = "稅碼" : column.DisplayIndex = 12 : column.Visible = False
    '            Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 13 : column.Visible = False
    '            Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 14
    '            Case Else
    '                column.Visible = False
    '        End Select
    '    Next

    'End Sub

    'Private Sub Bu1新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1新增.Click
    '    If TB客編.Text = "" Or TB名稱.Text = "" Then : Exit Sub : End If
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退單選擇) : Me.TabControl1.TabPages.Remove(Tp退貨作業) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退單選擇
    '    載入前導作業("新增")
    'End Sub

    'Private Sub Bu1修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1修改.Click
    '    If TB客編.Text = "" Or TB名稱.Text = "" Or TB單號.Text = "" Then : Exit Sub : End If
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨輸入) : Me.TabControl1.TabPages.Remove(Tp退貨作業) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨輸入
    '    Lt作業.Text = "修改"
    '    載入前導作業("修改")
    '    T3退貨明細前導作業()
    'End Sub

    'Private Sub 載入前導作業(ByVal 作業 As String)
    '    Select Case 作業
    '        Case "新增" '由T2載入作業
    '            作業項目 = 作業
    '        Case "修改" '由T1載入作業
    '            作業項目 = 作業
    '            Cb3Key單人員.Text = Lt輸入者.Text
    '            Cb3運輸司機.Text = Lt運輸司機.Text
    '            Cb3折退類別.Text = Lt類別.Text
    '            'Cb3折退類別.Enabled = False
    '            Cb3責任單位.Text = Lt責任單位.Text
    '            Cb3處理方式.Text = Lt處理方式.Text
    '            Cb3退貨原因.SelectedValue = Lt退貨代碼.Text
    '            Cb3運輸司機.SelectedValue = Lt司機代碼.Text
    '            De3輸入.Text = Lt過帳日期.Text
    '            De3退貨.Text = Lt退貨日期.Text
    '            Tb3備註.Text = Lt備註2.Text
    '            Tb3稅額.Text = Lt稅額.Text : Tb3總計.Text = Lt總計.Text
    '            T3載入前導作業1("T1")
    '            T3載入前導作業2("T1")

    '    End Select
    'End Sub

    'Private Sub T3退貨明細前導作業()
    '    T3退貨明細.CurrentCell = T3退貨明細.Rows(0).Cells(1)
    'End Sub

    'Private Sub Bu1刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1刪除.Click
    '    If CStr(TB單號.Text) <> "" Then
    '        Dim oAns As Integer
    '        oAns = MsgBox("是否確定刪除資料" & TB單號.Text, MsgBoxStyle.YesNo, "刪除單號")
    '        If oAns = MsgBoxResult.Yes Then  'Yes執行區
    '            T1刪除(TB單號.Text)
    '            TB單號.Text = ""
    '            T1退貨單號載入()
    '            If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
    '        End If
    '    End If

    'End Sub

    'Private Sub T1刪除(ByVal 單號 As String)
    '    Dim SQLADD1 As String = ""
    '    SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[營_退折表頭] "
    '    SQLADD1 += "    SET [啟用]     = 'N', "
    '    SQLADD1 += "        [修改時間] = GETDATE() "
    '    SQLADD1 += "  WHERE [單號] = '" & 單號 & "' " & vbCrLf

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand

    '    Try
    '        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 : SQLCmd.CommandTimeout = 100000
    '        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
    '        MsgBox("單號：" & 單號 & "  刪除完成")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    'Private Sub Bu1列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu1列印.Click

    '    'Dim strPara12 As String = ""
    '    'strPara12 = "稅額 " & CStr(StrDup(10 - Len(CStr(Lt稅額.Text)), " ")) & CStr(Lt稅額.Text) & " NTD" & vbCrLf
    '    'strPara12 += "總計 " & CStr(StrDup(10 - Len(CStr(Lt總計.Text)), " ")) & CStr(Lt總計.Text) & " NTD"
    '    'MsgBox(strPara12)

    '    If CStr(TB單號.Text) <> "" Then
    '        Dim oAns As Integer
    '        oAns = MsgBox("是否確定列印資料" & TB單號.Text, MsgBoxStyle.YesNo, "列印單號")
    '        If oAns = MsgBoxResult.Yes Then  'Yes執行區
    '            Bu1列印作業()   '營業
    '        End If
    '    End If
    'End Sub

    'Private Sub Bu1列印作業()
    '    Dim printDoc As New PrintDocument()
    '    Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

    '    If 顯示資料.Tables("T1退貨明細").Rows.Count > 0 Then

    '        Dim newRpt As 列印Print = New 列印Print
    '        newRpt.strPara(0) = TB客編.Text
    '        newRpt.strPara(1) = TB名稱.Text
    '        newRpt.strPara(2) = Lt地址.Text
    '        newRpt.strPara(3) = Lt發票號碼.Text
    '        newRpt.strPara(4) = Lt責任單位.Text
    '        newRpt.strPara(5) = Lt過帳日期.Text
    '        newRpt.strPara(6) = Lt聯絡人.Text
    '        newRpt.strPara(7) = Lt電話.Text
    '        newRpt.strPara(8) = Lt傳真.Text
    '        newRpt.strPara(9) = Lt文件單號.Text & " - " & TB單號.Text
    '        Dim strPara9 As String = ""
    '        Select Case Lt類別.Text
    '            Case "折讓"
    '                strPara9 = "■折讓 □退貨 "
    '            Case "退貨"
    '                strPara9 = "□折讓 ■退貨 "
    '        End Select
    '        newRpt.strPara(10) = strPara9
    '        'newRpt.strPara(11) = Lt備註1.Text & vbCrLf & Lt退貨原因.Text & vbCrLf & Lt備註2.Text
    '        newRpt.strPara(11) = Lt退貨原因.Text & vbCrLf & Lt備註2.Text
    '        Dim strPara12 As String = ""
    '        'strPara12 = "稅額 " & CStr(StrDup(10 - Len(CStr(Lt稅額.Text)), " ")) & CStr(Lt稅額.Text) & " NTD" & vbCrLf
    '        'strPara12 += "總計 " & CStr(StrDup(10 - Len(CStr(Lt總計.Text)), " ")) & CStr(Lt總計.Text) & " NTD"
    '        strPara12 = CStr(Lt稅額.Text) & " NTD" & vbCrLf & CStr(Lt總計.Text) & " NTD"
    '        newRpt.strPara(12) = strPara12
    '        newRpt.strPara(13) = "製表：" & Lt輸入者.Text & vbCrLf & Format(Now(), "yyyy-MM-dd hh:mm")
    '        newRpt.strPara(14) = Lt處理方式.Text
    '        newRpt.strPara(15) = Lt運輸司機.Text

    '        'newRpt.strPara(0) = 主要介面.TS公司.Text
    '        'newRpt.strPara(1) = "單位：" & La部門.Text
    '        'newRpt.strPara(2) = "資料期間：" & Format(開始Date.Value, "yyyy-MM-dd") & Format(結束Date.Value, "yyyy-MM-dd")
    '        'newRpt.strPara(3) = "製表日期：" & Format(Now(), "yyyy-MM-dd")
    '        'newRpt.strPara(4) = "製表：" & 員工姓名

    '        newRpt.StartupPath = "\A_營業\退貨作業\退貨單列印.rdlc"
    '        If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("退貨單之報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

    '        newRpt.高 = "14cm"
    '        newRpt.dt = 顯示資料.Tables("T1退貨明細")
    '        'newRpt.printerName = printDoc.PrinterSettings.PrinterName
    '        newRpt.printerName = Cb1印表機.Text
    '        newRpt.Run()
    '        newRpt.Dispose()
    '    Else
    '        MsgBox("無退貨明細!", MsgBoxStyle.OkOnly, "T1退貨明細")
    '    End If
    'End Sub




    ''T2分頁作業開始
    'Private Sub Bu2查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2查詢.Click
    '    Lt2來源.Text = Cb2退單來源.Text
    '    T2單號查詢載入()
    'End Sub

    'Private Sub T2單號查詢載入()
    '    If T2選擇單號.RowCount > 0 Then : 顯示資料.Tables("單號查詢").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    Select Case Cb2退單來源.Text
    '        Case "AR發票"
    '            SQLQuery = "    SELECT T0.[DocNum] AS '文件單號',T0.[DocDate] AS '過帳日期',T0.[CardCode] AS '客戶編號',T0.[CardName] AS '客戶名稱',ISNULL(T0.[Address],'') AS '地址', "
    '            SQLQuery += "          T0.[NumAtCard] AS '發票號碼',ISNULL(T1.[CntctPrsn],'') AS '連絡人',ISNULL(T1.[Phone1],'') AS '電話',ISNULL(T1.[Fax],'') AS '傳真',T0.[Comments] AS '備註' "
    '            SQLQuery += "     FROM [KaiShing].[dbo].[OINV] T0 LEFT JOIN [KaiShing].[dbo].[OCRD] T1 ON T0.[CardCode] = T1.[CardCode] "
    '            SQLQuery += "    WHERE T0.[CardCode] = '" & TB客編.Text & "' AND "
    '            SQLQuery += "          (T0.[DocDate] BETWEEN '" & Format(De2日期1.Value.Date, "yyyy-MM-dd") & "' AND '" & Format(De2日期2.Value.Date, "yyyy-MM-dd") & "' ) AND "
    '            SQLQuery += "          T0.[ObjType] = '13' "
    '            SQLQuery += " ORDER BY T0.[DocNum] "
    '        Case "交貨單"
    '            SQLQuery += "   SELECT T0.[DocNum] AS '文件單號',T0.[DocDate] AS '過帳日期',T0.[CardCode] AS '客戶編號',T0.[CardName] AS '客戶名稱',REPLACE(ISNULL(T0.[Address],''),'台灣','') AS '地址', "
    '            SQLQuery += "          ISNULL(T0.[NumAtCard],'') AS '發票號碼',ISNULL(T1.[CntctPrsn],'') AS '連絡人',ISNULL(T1.[Phone1],'') AS '電話',ISNULL(T1.[Fax],'') AS '傳真',T0.[Comments] AS '備註' "
    '            SQLQuery += "     FROM [KaiShing].[dbo].[ODLN] T0 LEFT JOIN [KaiShing].[dbo].[OCRD] T1 ON T0.[CardCode] = T1.[CardCode] "
    '            SQLQuery += "    WHERE T0.[CardCode] = '" & TB客編.Text & "' AND "
    '            SQLQuery += "          (T0.[DocDate] BETWEEN '" & Format(De2日期1.Value.Date, "yyyy-MM-dd") & "' AND '" & Format(De2日期2.Value.Date, "yyyy-MM-dd") & "' ) AND "
    '            SQLQuery += "          T0.[ObjType] = '15' "
    '            SQLQuery += " ORDER BY T0.[DocNum] "
    '    End Select

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "單號查詢")
    '        T2選擇單號.DataSource = 顯示資料.Tables("單號查詢")
    '        T2選擇單號.AutoResizeColumns()

    '    Catch ex As Exception
    '        MsgBox("單號查詢：" & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub T2選擇單號_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T2選擇單號.CellClick
    '    Lt文件單號.Text = T2選擇單號.CurrentRow.Cells("文件單號").Value
    '    Lt過帳日期.Text = T2選擇單號.CurrentRow.Cells("過帳日期").Value
    '    'Lt退貨日期.Text = T2選擇單號.CurrentRow.Cells("退貨日期").Value
    '    Lt發票號碼.Text = T2選擇單號.CurrentRow.Cells("發票號碼").Value
    '    Lt發票日期.Text = T2選擇單號.CurrentRow.Cells("過帳日期").Value
    '    Lt責任單位.Text = ""
    '    Lt聯絡人.Text = T2選擇單號.CurrentRow.Cells("連絡人").Value
    '    Lt電話.Text = T2選擇單號.CurrentRow.Cells("電話").Value
    '    Lt傳真.Text = T2選擇單號.CurrentRow.Cells("傳真").Value
    '    Lt地址.Text = T2選擇單號.CurrentRow.Cells("地址").Value
    '    Lt處理方式.Text = ""
    '    Lt退貨代碼.Text = "" : Lt退貨原因.Text = ""
    '    Lt司機代碼.Text = "" : Lt運輸司機.Text = ""

    '    Lt備註1.Text = T2選擇單號.CurrentRow.Cells("備註").Value
    '    Lt備註2.Text = ""
    '    Lt輸入者.Text = ""
    '    Lt來源.Text = "" : Lt類別.Text = "" : Lt稅額.Text = "" : Lt總計.Text = ""

    '    Lt2單號.Text = T2選擇單號.CurrentRow.Cells("文件單號").Value

    '    T2單號明細載入()
    '    Bu2選單.Visible = True
    'End Sub

    'Private Sub T2單號明細載入()
    '    If T2單號明細.RowCount > 0 Then : 顯示資料.Tables("單號明細").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    SQLQuery = 載入來源資料(Cb2退單來源.Text, T2選擇單號.CurrentRow.Cells("文件單號").Value)

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "單號明細")
    '        T2單號明細.DataSource = 顯示資料.Tables("單號明細")
    '        T2單號明細顯示()
    '        T2單號明細.AutoResizeColumns()
    '    Catch ex As Exception
    '        MsgBox("單號明細：" & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Function 載入來源資料(ByVal 作業 As String, ByVal 單號 As String)
    '    Dim SQLQuery As String = ""

    '    Select Case 作業
    '        Case "AR發票"
    '            SQLQuery += "   SELECT [ItemCode] AS '存貨編號',[Dscription] AS '存編名稱', "
    '            SQLQuery += "          0.0 AS '退貨數量', "
    '            'SQLQuery += "          CAST(CAST(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] WHEN '1' THEN CAST(T1.[U_p2] AS NUMERIC(15,2)) WHEN '2' THEN T1.[U_P4] END AS FLOAT(53)) AS VARCHAR(15)) + "
    '            'SQLQuery += "          REPLICATE(' ',15-DATALENGTH(CAST(CAST(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] WHEN '1' THEN T1.[U_p2] WHEN '2' THEN T1.[U_P4] END AS FLOAT(53)) AS VARCHAR(15)))) AS '數量', "
    '            SQLQuery += "          CAST(CAST(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] "
    '            SQLQuery += "                                   WHEN '1' THEN CAST(CASE WHEN LEFT([ItemCode],4) = '2513' AND T2.[Descr] = 'KG' THEN T1.[U_P4] ELSE T1.[U_p2] END AS NUMERIC(15,2))"
    '            SQLQuery += "                                   WHEN '2' THEN T1.[U_P4] END AS FLOAT(53)) AS VARCHAR(15)) AS '數量',"

    '            SQLQuery += "          CAST([U_p2] AS NUMERIC(15,2)) AS '出貨重量','KS' AS '單位',CAST(T1.[U_P4] AS FLOAT(53)) AS '數量2',T3.[Descr] AS '小單位', "
    '            SQLQuery += "          [U_P8] AS '單價',T2.[Descr] AS '計價',[LineTotal] AS '金額',[WhsCode] AS '倉別',[VatGroup] AS '稅碼',[VisOrder] AS '列號','' AS '備註' " '[LineTotal] AS '金額'
    '            SQLQuery += "     FROM [INV1] T1 "
    '            SQLQuery += "          INNER JOIN [UFD1] T2 ON T2.[TableID] = 'INV1' AND T2.[FieldID] = '10' AND T1.[U_P7] = T2.[FldValue] "
    '            SQLQuery += "          INNER JOIN [UFD1] T3 ON T3.[TableID] = 'INV1' AND T3.[FieldID] = '9'  AND T1.[U_P6] = T3.[FldValue] "
    '            SQLQuery += "    WHERE [DocEntry] = '" & 單號 & "'  "
    '            SQLQuery += " ORDER BY [VisOrder] "
    '        Case "交貨單"
    '            SQLQuery += "   SELECT [ItemCode] AS '存貨編號',[Dscription] AS '存編名稱', "
    '            SQLQuery += "          0.0 AS '退貨數量', "
    '            'SQLQuery += "          CAST(CAST(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] WHEN '1' THEN CAST(T1.[U_p2] AS NUMERIC(15,2)) WHEN '2' THEN T1.[U_P4] END AS FLOAT(53)) AS VARCHAR(15)) + "
    '            'SQLQuery += "          REPLICATE(' ',15-DATALENGTH(CAST(CAST(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] WHEN '1' THEN T1.[U_p2] WHEN '2' THEN T1.[U_P4] END AS FLOAT(53)) AS VARCHAR(15)))) AS '數量', "
    '            SQLQuery += "          CAST(CAST(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] "
    '            SQLQuery += "                                   WHEN '1' THEN CAST(CASE WHEN LEFT([ItemCode],4) = '2513' AND T2.[Descr] = 'KG' THEN T1.[U_P4] ELSE T1.[U_p2] END AS NUMERIC(15,2))"
    '            SQLQuery += "                                   WHEN '2' THEN T1.[U_P4] END AS FLOAT(53)) AS VARCHAR(15)) AS '數量',"

    '            SQLQuery += "          CAST([U_p2] AS NUMERIC(15,2)) AS '出貨重量','KS' AS '單位',CAST(T1.[U_P4] AS FLOAT(53)) AS '數量2',T3.[Descr] AS '小單位', "
    '            SQLQuery += "          [U_P8] AS '單價',T2.[Descr] AS '計價',[LineTotal] AS '金額',[WhsCode] AS '倉別',[VatGroup] AS '稅碼',[VisOrder] AS '列號','' AS '備註' " '[LineTotal] AS '金額'
    '            SQLQuery += "     FROM [DLN1] T1 "
    '            SQLQuery += "          INNER JOIN [UFD1] T2 ON T2.[TableID] = 'DLN1' AND T2.[FieldID] = '10' AND T1.[U_P7] = T2.[FldValue] "
    '            SQLQuery += "          INNER JOIN [UFD1] T3 ON T3.[TableID] = 'DLN1' AND T3.[FieldID] = '9'  AND T1.[U_P6] = T3.[FldValue] "
    '            SQLQuery += "    WHERE [DocEntry] = '" & 單號 & "'  "
    '            SQLQuery += " ORDER BY [VisOrder] "
    '    End Select

    '    Dim oReturn As String = ""
    '    oReturn = SQLQuery
    '    Return oReturn
    'End Function

    'Private Sub T2單號明細顯示()
    '    For Each column As DataGridViewColumn In T2單號明細.Columns
    '        column.Visible = True : column.ReadOnly = True
    '        Select Case column.Name
    '            Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 0 : column.Frozen = True
    '            Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
    '            Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 2 : column.Visible = False
    '            Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3
    '            Case "出貨重量" : column.HeaderText = "出貨重量" : column.DisplayIndex = 4
    '            Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5
    '            Case "數量2" : column.HeaderText = "數量2" : column.DisplayIndex = 6
    '            Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 7
    '            Case "單價" : column.HeaderText = "單價" : column.DisplayIndex = 8
    '            Case "計價" : column.HeaderText = "計價" : column.DisplayIndex = 9
    '            Case "金額" : column.HeaderText = "金額" : column.DisplayIndex = 10
    '            Case "倉別" : column.HeaderText = "倉別" : column.DisplayIndex = 11
    '            Case "稅碼" : column.HeaderText = "稅碼" : column.DisplayIndex = 12 : column.Visible = False
    '            Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 13 : column.Visible = False
    '            Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 14
    '            Case Else
    '                column.Visible = False
    '        End Select
    '    Next

    'End Sub


    'Private Sub Bu2選單_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2選單.Click
    '    If Lt2單號.Text = "" Then : Exit Sub : End If '未選擇單據無動作
    '    If 查詢是否已有退貨單號() <> "0" Then

    '        MsgBox("錯誤已有退貨單號：" + CStr(查詢是否已有退貨單號()))
    '        Exit Sub
    '    End If

    '    'Lt來源.Text = Cb2退單來源.Text
    '    Lt作業.Text = "新增"
    '    Lt來源.Text = Lt2來源.Text
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨輸入) : Me.TabControl1.TabPages.Remove(Tp退單選擇) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨輸入

    '    T3載入前導作業1("T2")
    '    T3載入前導作業2("T2")

    'End Sub

    'Private Function 查詢是否已有退貨單號()
    '    Dim SQL As String = ""
    '    Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim sqlReader As SqlDataReader
    '    Dim oReturn As Integer

    '    SQL = " SELECT [單號] FROM [KaiShingPlug].[dbo].[營_退折表頭] WHERE [文件單號] = '" & Lt2單號.Text & "' AND [來源] = '" & Cb2退單來源.Text & "' AND [啟用] = 'Y' "

    '    SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQL
    '    sqlReader = SQLCmd.ExecuteReader
    '    sqlReader.Read()

    '    If sqlReader.HasRows() Then
    '        oReturn = sqlReader.Item("單號")
    '        'oReturn = 1
    '    Else
    '        oReturn = "0"
    '    End If

    '    sqlReader.Close()

    '    Return oReturn
    'End Function

    'Private Sub T3載入前導作業1(ByVal 作業 As String)
    '    Select Case 作業
    '        Case "T1"
    '            T3退貨明細載入()
    '            T3單號明細載入()
    '            T3退貨明細載入_選擇()
    '        Case "T2"
    '            T2轉T3退貨明細載入()
    '            For i As Integer = 0 To T3退貨明細.RowCount - 1
    '                T3退貨明細.Rows(i).Cells("退貨數量").Value = 0
    '                T3退貨明細.Rows(i).Cells("金額").Value = 0.0
    '            Next
    '            For i As Integer = 0 To T3單號明細.RowCount - 1
    '                T3單號明細.Rows(i).Cells("退貨數量").Value = 0
    '                T3單號明細.Rows(i).Cells("金額").Value = 0.0
    '            Next
    '    End Select

    'End Sub
    'Private Sub T3載入前導作業2(ByVal 作業 As String)
    '    T3退貨明細顯示()
    '    T3單號明細顯示()

    '    T3存編資料比對()

    '    For i As Integer = 0 To T3退貨明細.RowCount - 1
    '        T3退貨明細.Rows(i).Cells("選擇").Value = False
    '    Next
    '    For i As Integer = 0 To T3單號明細.RowCount - 1
    '        T3單號明細.Rows(i).Cells("選擇").Value = False
    '    Next

    'End Sub

    'Private Sub T2轉T3退貨明細載入()    '由T2執行載入資料
    '    If T3退貨明細.RowCount > 0 Then : 顯示資料.Tables("退貨明細_退").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    SQLQuery = 載入來源資料(Cb2退單來源.Text, T2選擇單號.CurrentRow.Cells("文件單號").Value)

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "退貨明細_退")
    '        MSSQL作業.Fill(顯示資料, "退貨明細_原")

    '        T3退貨明細.DataSource = 顯示資料.Tables("退貨明細_退")
    '        退貨明細_退 = 顯示資料.Tables("退貨明細_原")
    '        退貨明細_原 = 顯示資料.Tables("退貨明細_原")
    '        T3單號明細.DataSource = 退貨明細_退.Copy

    '        T3退貨明細載入_選擇()

    '    Catch ex As Exception
    '        MsgBox("退貨明細：" & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub T3退貨明細載入_選擇()
    '    If T2單號明細_選擇 = "Y" Then
    '        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
    '        checkBoxColumn.Name = "選擇"
    '        T3退貨明細.Columns.Insert(0, checkBoxColumn)
    '        Dim checkBoxColumn2 As New DataGridViewCheckBoxColumn()
    '        checkBoxColumn2.Name = "選擇"
    '        T3單號明細.Columns.Insert(0, checkBoxColumn2)
    '    End If
    '    T2單號明細_選擇 = "N"
    'End Sub

    'Private Sub T3退貨明細顯示()
    '    For Each column As DataGridViewColumn In T3退貨明細.Columns
    '        column.Visible = True : column.ReadOnly = True
    '        Select Case column.Name
    '            Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.ReadOnly = False : column.Frozen = True
    '            Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 1 : column.Frozen = True
    '            Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 2 : column.Frozen = True
    '                'Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 3 : column.ReadOnly = False : column.Frozen = True    '可修改
    '            Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 3 : column.ReadOnly = True : column.Frozen = True    '不可修改_20170524
    '            Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 4 : column.Frozen = True
    '            Case "出貨重量" : column.HeaderText = "出貨重量" : column.DisplayIndex = 5
    '            Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 6
    '            Case "數量2" : column.HeaderText = "數量2" : column.DisplayIndex = 7
    '            Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 8
    '            Case "單價" : column.HeaderText = "單價" : column.DisplayIndex = 9
    '            Case "計價" : column.HeaderText = "計價" : column.DisplayIndex = 10
    '            Case "金額" : column.HeaderText = "金額" : column.DisplayIndex = 11
    '            Case "倉別" : column.HeaderText = "倉別" : column.DisplayIndex = 12
    '            Case "稅碼" : column.HeaderText = "稅碼" : column.DisplayIndex = 13 : column.Visible = False
    '            Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 14 : column.Visible = False
    '            Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 14 : column.ReadOnly = False
    '            Case Else
    '                column.Visible = False
    '        End Select
    '    Next

    'End Sub

    'Private Sub T3單號明細顯示()
    '    For Each column As DataGridViewColumn In T3單號明細.Columns
    '        column.Visible = True : column.ReadOnly = True
    '        Select Case column.Name
    '            Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.ReadOnly = False : column.Frozen = True
    '            Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 1 : column.Frozen = True
    '            Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 2 : column.Frozen = True
    '            Case Else
    '                column.Visible = False
    '        End Select
    '    Next

    'End Sub

    'Private Sub T3存編資料比對()
    '    If T3單號明細.RowCount > 0 Then : 退貨明細_退.Clear() : End If '清除dt1資料
    '    T3單號明細.DataSource = 退貨明細_原
    '    '退貨明細_原 = 顯示資料.Tables("退貨明細_原").Copy : T3單號明細.DataSource = 退貨明細_原
    '    Dim counti As Integer = T3退貨明細.Rows.Count
    '    For i As Integer = counti - 1 To 0 Step -1
    '        Dim countx As Integer = T3單號明細.Rows.Count
    '        For x As Integer = countx - 1 To 0 Step -1
    '            If T3退貨明細.Rows(i).Cells("存貨編號").Value = T3單號明細.Rows(x).Cells("存貨編號").Value Then
    '                T3單號明細.Rows.Remove(T3單號明細.Rows(x))
    '            End If
    '        Next
    '    Next

    '    T3單號明細.AutoResizeColumns()
    '    T3退貨明細.AutoResizeColumns()

    'End Sub


    ''T3分頁作業開始

    'Private Sub T3退貨明細_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T3退貨明細.CellEndEdit
    '    ' 由編輯資料列時 計算結果

    '    If e.ColumnIndex = CType(sender, DataGridView).Columns("退貨數量").Index Then
    '        If CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("退貨數量").Value) > CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("數量").Value) Then
    '            CType(sender, DataGridView).Rows(e.RowIndex).Cells("退貨數量").Value = 0
    '            MsgBox("退貨數量不可大於可退數量")
    '            Exit Sub
    '        End If

    '        Dim 數量 As Single
    '        數量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("單價").Value) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("退貨數量").Value)
    '        CType(sender, DataGridView).Rows(e.RowIndex).Cells("金額").Value = Math.Round(數量)
    '    End If

    '    Dim 總計1 As Single = 0 : Dim 稅額1 As Single = 0 : Dim 稅額2 As String = "N"
    '    For i As Integer = 0 To T3退貨明細.RowCount - 1
    '        If T3退貨明細.Rows(i).Cells("退貨數量").Value <> 0 Then
    '            If T3退貨明細.Rows(i).Cells("稅碼").Value = "O5%" Then
    '                稅額2 = "Y"
    '            End If
    '            總計1 = 總計1 + T3退貨明細.Rows(i).Cells("金額").Value
    '        End If
    '    Next
    '    If 稅額2 = "Y" Then
    '        稅額1 = Math.Round(總計1 * 1.05) - 總計1
    '        Tb3稅額.Text = 稅額1
    '    End If

    '    Tb3總計.Text = 總計1 + 稅額1

    'End Sub

    'Private Sub Bu3存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu3存檔.Click
    '    If Cb3折退類別.SelectedIndex = -1 Or Cb3責任單位.SelectedIndex = -1 Or Cb3Key單人員.SelectedIndex = -1 Or Cb3退貨原因.SelectedIndex = -1 Or Cb3運輸司機.SelectedIndex = -1 Then
    '        MsgBox("選項有未輸入")
    '        Exit Sub
    '    End If
    '    If Cb3折退類別.SelectedIndex = 1 Then
    '        If Cb3處理方式.SelectedIndex = 0 Then
    '            MsgBox("選項有未輸入2")
    '            Exit Sub
    '        End If
    '    End If

    '    If T3退貨明細.RowCount = 0 Then
    '        MsgBox("無退貨品項")
    '        Exit Sub
    '    End If

    '    If T3退貨明細.RowCount = 0 Then : Exit Sub : End If
    '    Dim xx As Integer = 0
    '    For ix As Integer = 0 To T3退貨明細.RowCount - 1
    '        If T3退貨明細.Rows(ix).Cells("退貨數量").Value <> "0" Then
    '            xx = xx + 1
    '        End If
    '    Next
    '    If xx = 0 Then : MsgBox("未輸入退貨數量", 16) : Exit Sub : End If

    '    T3存檔執行作業()
    '    Select Case 作業項目
    '        Case "新增"
    '            Dim 單號序號 As String : 單號序號 = 存檔_取單據單號() : TB單號.Text = 單號序號
    '            T3存檔("新增", 單號序號)
    '            T4存檔(單號序號)
    '        Case "修改"
    '            T3存檔("修改", TB單號.Text)
    '            T4存檔(TB單號.Text)
    '    End Select

    '    結束後續作業()
    '    作業項目 = ""
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨作業) : Me.TabControl1.TabPages.Remove(Tp退貨輸入) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨作業
    '    T1退貨單號.AutoResizeColumns()

    'End Sub

    'Private Sub T3存檔執行作業()
    '    Lt輸入者.Text = Cb3Key單人員.Text()
    '    Lt類別.Text = Cb3折退類別.Text
    '    Lt責任單位.Text = Cb3責任單位.Text
    '    Lt稅額.Text = Tb3稅額.Text
    '    Lt總計.Text = Tb3總計.Text
    '    Lt處理方式.Text = Cb3處理方式.Text
    '    Lt退貨代碼.Text = Cb3退貨原因.SelectedValue.ToString
    '    Lt司機代碼.Text = Cb3運輸司機.SelectedValue.ToString
    '    Lt備註2.Text = Tb3備註.Text
    'End Sub

    'Private Function 存檔_取單據單號()
    '    Dim SQL As String = ""
    '    Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim sqlReader As SqlDataReader
    '    Dim oReturn As Integer

    '    'SQL = " EXEC [KaiShingPlug].[dbo].[預_取單據單號] '" & Format(Now(), "yyyy-MM-dd") & "','退折' "
    '    SQL = " EXEC [KaiShingPlug].[dbo].[預_取單據單號] '" & Format(De3輸入.Value.Date, "yyyy-MM-dd") & "','退折' "

    '    SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQL
    '    sqlReader = SQLCmd.ExecuteReader
    '    sqlReader.Read()

    '    If sqlReader.HasRows() Then
    '        oReturn = sqlReader.Item("單號")
    '    Else
    '        oReturn = 0
    '    End If

    '    sqlReader.Close()

    '    Return oReturn
    'End Function

    'Private Sub T3存檔(ByVal 作業 As String, ByVal 單號 As String)
    '    Dim SQLADD表頭 As String = "" : Dim SQLADD表身 As String = "" : Dim SQLADD1 As String = "" : Dim SQLADD2 As String = "" : Dim SQLUP As String = ""
    '    Select Case 作業
    '        Case "新增"
    '            SQLADD1 = "  INSERT INTO [KaiShingPlug].[dbo].[營_退折表頭] "
    '            SQLADD1 += "  ([單號],[單號日期],[退貨日期],[客戶編號],[客戶名稱],[文件單號], "
    '            SQLADD1 += "   [發票號碼], [發票日期], [責任單位], "
    '            SQLADD1 += "   [聯絡人],[電話],[傳真],[地址],[處理方式],[退貨代碼],[司機代碼],[備註],"
    '            SQLADD1 += "   [啟用],[新增時間],[輸入者],[來源],[類別],[稅額],[總計],[列印否],[列印次數]) VALUES "
    '            SQLADD1 += " ('" & 單號 & "','" & Format(De3輸入.Value.Date, "yyyy-MM-dd") & "','" & Format(De3退貨.Value.Date, "yyyy-MM-dd") & "','" & TB客編.Text & "','" & TB名稱.Text & "','" & Lt文件單號.Text & "', "
    '            SQLADD1 += "  '" & Lt發票號碼.Text & "','" & Lt發票日期.Text & "','" & Lt責任單位.Text & "', "
    '            SQLADD1 += "  '" & Lt聯絡人.Text & "','" & Lt電話.Text & "','" & Lt傳真.Text & "','" & Lt地址.Text & "','" & Lt處理方式.Text & "','" & Cb3退貨原因.SelectedValue.ToString & "','" & Cb3運輸司機.SelectedValue.ToString & "', "
    '            SQLADD1 += "  '" & Lt備註2.Text & "','Y',GETDATE(),'" & Lt輸入者.Text & "','" & Lt來源.Text & "',"
    '            SQLADD1 += "  '" & Lt類別.Text & "','" & Lt稅額.Text & "','" & Lt總計.Text & "','N',0 ) " & vbCrLf
    '            'Tb3備註.Text = Lt備註2.Text
    '        Case "修改"
    '            '表頭修正
    '            SQLADD表頭 = "  UPDATE [KaiShingPlug].[dbo].[營_退折表頭] "
    '            SQLADD表頭 += "    SET [單號日期] = '" & Format(De3輸入.Value.Date, "yyyy-MM-dd") & "', "
    '            SQLADD表頭 += "        [退貨日期] = '" & Format(De3退貨.Value.Date, "yyyy-MM-dd") & "', "
    '            SQLADD表頭 += "        [責任單位] = '" & Lt責任單位.Text & "', "
    '            SQLADD表頭 += "        [類別]     = '" & Lt類別.Text & "', "
    '            SQLADD表頭 += "        [稅額]     = '" & Lt稅額.Text & "', "
    '            SQLADD表頭 += "        [總計]     = '" & Lt總計.Text & "', "
    '            SQLADD表頭 += "        [處理方式] = '" & Lt處理方式.Text & "', "
    '            SQLADD表頭 += "        [退貨代碼] = '" & Cb3退貨原因.SelectedValue.ToString & "', "
    '            SQLADD表頭 += "        [司機代碼] = '" & Cb3運輸司機.SelectedValue.ToString & "', "
    '            SQLADD表頭 += "        [輸入者]   = '" & Lt輸入者.Text & "', "
    '            SQLADD表頭 += "        [備註]     = '" & Lt備註2.Text & "', "
    '            SQLADD表頭 += "        [修改時間] = GETDATE() "
    '            SQLADD表頭 += "  WHERE [單號] = '" & 單號 & "' " & vbCrLf
    '            '表身修正_先作廢
    '            SQLADD表身 = "  UPDATE [KaiShingPlug].[dbo].[營_退折表身] "
    '            SQLADD表身 += "    SET [啟用]     = 'N', "
    '            SQLADD表身 += "        [修改時間] = GETDATE() "
    '            SQLADD表身 += "  WHERE [單號] = '" & 單號 & "' " & vbCrLf

    '    End Select

    '    For i As Integer = 0 To T3退貨明細.RowCount - 1
    '        If T3退貨明細.Rows(i).Cells("退貨數量").Value <> 0 Then
    '            SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[營_退折表身] "
    '            SQLADD2 += " ([單號],[存貨編號],[存編名稱],[退貨數量],[數量],[出貨重量],[單位],[數量2],[小單位],[單價],[計價],[金額],[倉別],[稅碼],[列號],[備註],[啟用],[新增時間]) VALUES "
    '            SQLADD2 += " ('" & 單號 & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("存貨編號").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("存編名稱").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("退貨數量").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("數量").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("出貨重量").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("單位").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("數量2").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("小單位").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("單價").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("計價").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("金額").Value & "', "
    '            ''If Cb3折退類別.SelectedIndex = 0 Then
    '            ''    SQLADD2 += "  'ZDW', "
    '            ''Else
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("倉別").Value & "', "
    '            'End If
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("稅碼").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("列號").Value & "', "
    '            SQLADD2 += "  '" & T3退貨明細.Rows(i).Cells("備註").Value & "', "
    '            SQLADD2 += "  'Y',GETDATE() ) " & vbCrLf
    '        End If
    '    Next

    '    ''If T4單號空白 = "AAAAAAAA" Then
    '    'SQLUP = "  UPDATE [KaiShingPlug].[dbo].[營_退折明細] "
    '    ''SQLUP += "    SET [單號]     = '" & 單號 & "', "
    '    'SQLUP += "    SET [啟用]     = 'Y', "
    '    'SQLUP += "        [修改時間] = GETDATE() "
    '    'SQLUP += "  WHERE [單號] = 'AAAAAAAA' AND [啟用] = 'S' " & vbCrLf
    '    ''End If


    '    'MsgBox(SQLADD1 + SQLADD2)

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand

    '    Try
    '        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD表頭 + SQLADD表身 + SQLADD1 + SQLADD2 + SQLUP : SQLCmd.CommandTimeout = 100000
    '        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
    '        Select Case 作業
    '            Case "新增"
    '                MsgBox("單號：" & 單號 & "新增完成")
    '            Case "修改"
    '                MsgBox("單號：" & 單號 & "修改完成")
    '        End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    ''T3分頁已 作業項目 = "修改" 載入
    'Private Sub T3退貨明細載入()
    '    If T3退貨明細.RowCount > 0 Then : 顯示資料.Tables("退貨明細_退").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    SQLQuery = "    SELECT [存貨編號],[存編名稱],[退貨數量],[數量],[出貨重量],[單位],[數量2],[小單位],[單價],[計價],[金額],[倉別],[稅碼],[列號],[備註] "
    '    SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表身] "
    '    SQLQuery += "    WHERE [單號] = '" & TB單號.Text & "' AND [啟用] = 'Y' "
    '    SQLQuery += " ORDER BY [列號] "

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "退貨明細_退")
    '        T3退貨明細.DataSource = 顯示資料.Tables("退貨明細_退")
    '    Catch ex As Exception
    '        MsgBox("退貨明細：" & ex.Message)
    '        Exit Sub
    '    End Try

    'End Sub

    'Private Sub T3單號明細載入()
    '    If T3單號明細.RowCount > 0 Then : 顯示資料.Tables("退貨明細_原").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    SQLQuery = 載入來源資料(Lt來源.Text, Lt文件單號.Text)

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "退貨明細_原")

    '        退貨明細_退 = 顯示資料.Tables("退貨明細_原").Copy
    '        退貨明細_原 = 顯示資料.Tables("退貨明細_原").Copy
    '        T3單號明細.DataSource = 退貨明細_退.Copy

    '    Catch ex As Exception
    '        MsgBox("退貨明細2：" & ex.Message)
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub Bu2放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2放棄.Click
    '    結束後續作業()
    '    作業項目 = ""
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨作業) : Me.TabControl1.TabPages.Remove(Tp退單選擇) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨作業

    'End Sub

    'Private Sub Bu3放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu3放棄.Click
    '    'T3放棄()
    '    結束後續作業()
    '    作業項目 = ""
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨作業) : Me.TabControl1.TabPages.Remove(Tp退貨輸入) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨作業
    '    T1退貨單號.AutoResizeColumns()
    'End Sub

    ''Private Sub T3放棄()
    ''    Dim SQLUP As String = ""

    ''    '修正_先作廢
    ''    'SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[營_退折明細] "
    ''    'SQLADD1 += "    SET [啟用]     = 'N', "
    ''    'SQLADD1 += "        [修改時間] = GETDATE() "
    ''    'SQLADD1 += "  WHERE [單號] = '" & T4單號空白 & "' AND [存貨編號] = '" & Lt4存編.Text & "' " & vbCrLf

    ''    If T4單號空白 = "AAAAAAAA" Then
    ''        SQLUP = "  UPDATE [KaiShingPlug].[dbo].[營_退折明細] "
    ''        SQLUP += "    SET [啟用]     = 'N', "
    ''        SQLUP += "        [修改時間] = GETDATE() "
    ''        SQLUP += "  WHERE [單號] = 'AAAAAAAA' AND [啟用] = 'S' " & vbCrLf

    ''        Dim DBConn As SqlConnection = Login.DBConn
    ''        Dim SQLCmd As SqlCommand = New SqlCommand

    ''        Try
    ''            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLUP : SQLCmd.CommandTimeout = 100000
    ''            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

    ''        Catch ex As Exception
    ''            MsgBox(ex.Message)
    ''        End Try
    ''    End If

    ''End Sub

    'Private Sub 結束後續作業()
    '    Load初始化()

    '    T4DGV清空 = "Y"

    '    Select Case 作業項目
    '        Case "新增"
    '            'T2分頁
    '            If T2選擇單號.RowCount > 0 Then : 顯示資料.Tables("單號查詢").Clear() : End If '清除資料
    '            If T2單號明細.RowCount > 0 Then : 顯示資料.Tables("單號明細").Clear() : End If '清除資料
    '        Case "修改"
    '    End Select

    '    'T3分頁
    '    TB單號.Text = ""
    '    If T3退貨明細.RowCount <> 0 Then    '清除資料
    '        顯示資料.Tables("退貨明細_退").Clear()
    '        顯示資料.Tables("退貨明細_原").Clear()
    '        退貨明細_退.Clear()
    '        退貨明細_原.Clear()
    '        '顯示資料.Tables("T1退貨明細").Clear()
    '    End If
    '    T1退貨單號載入()

    '    If T1退貨明細.RowCount > 0 Then : 顯示資料.Tables("T1退貨明細").Clear() : End If '清除資料
    '    If T4輸入資料.RowCount > 0 Then : 顯示資料.Tables("退貨數量_退").Clear() : End If '清除資料


    'End Sub

    'Private Sub Bu3新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu3新增.Click
    '    Dim counti As Integer = T3單號明細.Rows.Count
    '    For i As Integer = counti - 1 To 0 Step -1
    '        Dim isSelected As Boolean = Convert.ToBoolean(T3單號明細.Rows(i).Cells("選擇").Value)
    '        If isSelected Then
    '            Dim Row As DataRow
    '            Row = 顯示資料.Tables("退貨明細_退").NewRow
    '            'Row.Item("選擇") = False
    '            Row.Item("存貨編號") = T3單號明細.Rows(i).Cells("存貨編號").Value
    '            Row.Item("存編名稱") = T3單號明細.Rows(i).Cells("存編名稱").Value
    '            Row.Item("退貨數量") = 0
    '            Row.Item("數量") = T3單號明細.Rows(i).Cells("數量").Value
    '            Row.Item("出貨重量") = T3單號明細.Rows(i).Cells("出貨重量").Value
    '            Row.Item("單位") = T3單號明細.Rows(i).Cells("單位").Value
    '            Row.Item("數量2") = T3單號明細.Rows(i).Cells("數量2").Value
    '            Row.Item("小單位") = T3單號明細.Rows(i).Cells("小單位").Value
    '            Row.Item("單價") = T3單號明細.Rows(i).Cells("單價").Value
    '            Row.Item("計價") = T3單號明細.Rows(i).Cells("計價").Value
    '            Row.Item("金額") = 0
    '            Row.Item("倉別") = T3單號明細.Rows(i).Cells("倉別").Value
    '            Row.Item("稅碼") = T3單號明細.Rows(i).Cells("稅碼").Value
    '            Row.Item("列號") = T3單號明細.Rows(i).Cells("列號").Value
    '            Row.Item("備註") = T3單號明細.Rows(i).Cells("備註").Value
    '            顯示資料.Tables("退貨明細_退").Rows.Add(Row)
    '        End If

    '    Next

    '    T3存編資料比對()
    'End Sub

    'Private Sub Bu3刪除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu3刪除.Click
    '    Dim count As Integer = T3退貨明細.Rows.Count
    '    For i As Integer = count - 1 To 0 Step -1
    '        Dim isSelected As Boolean = Convert.ToBoolean(T3單號明細.Rows(i).Cells("選擇").Value)
    '        If isSelected Then
    '            T3退貨明細.Rows.Remove(T3退貨明細.Rows(i))
    '        End If
    '    Next

    '    T3存編資料比對()
    'End Sub

    'Private Sub Cb3折退類別_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb3折退類別.TextChanged
    '    If Cb3折退類別.SelectedIndex <= 0 Then
    '        Cb3處理方式.SelectedIndex = 0
    '        Cb3處理方式.Enabled = False
    '    Else
    '        Cb3處理方式.SelectedIndex = 0
    '        Cb3處理方式.Enabled = True
    '    End If
    'End Sub

    ''Tp退貨數量_作業
    ''基本設定

    'Private Sub T3退貨明細_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T3退貨明細.CellClick
    '    Lt3名稱.Text = T3退貨明細.CurrentRow.Cells("存編名稱").Value

    '    Lt4存編.Text = T3退貨明細.CurrentRow.Cells("存貨編號").Value
    '    Lt4名稱.Text = T3退貨明細.CurrentRow.Cells("存編名稱").Value
    '    Lt4數量.Text = 0
    '    Lt4可退.Text = T3退貨明細.CurrentRow.Cells("數量").Value '數量
    '    Lt4列號.Text = T3退貨明細.CurrentRow.Cells("列號").Value
    '    Lt4合計.Text = 0

    'End Sub

    'Private Sub T4分頁Load初始化()
    '    '參數   T4分頁
    '    Lt3名稱.Text = ""
    '    Lt4存編.Text = ""
    '    Lt4名稱.Text = ""
    '    Lt4數量.Text = 0
    '    Lt4可退.Text = 0
    '    Lt4合計.Text = 0
    '    Lt4列號.Text = ""
    '    Lt4ID.Text = ""
    '    'T4Cb1類別.SelectedIndex = -1
    '    'T4Cb1原因.SelectedIndex = -1
    '    T4Lt4說明.Text = ""

    '    'If T4輸入資料.RowCount > 0 Then : 顯示資料.Tables("退貨數量_退").Clear() : End If '清除資料

    'End Sub


    ''Private Sub T4Cb類別_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4Cb1類別.SelectedIndexChanged

    ''    T4Cb1原因.Items.Clear()
    ''    Select Case T4Cb1類別.SelectedIndex
    ''        Case "0"
    ''            T4Cb1原因.Items.Add("01.品質不佳")
    ''            T4Cb1原因.Items.Add("02.異物")
    ''            T4Cb1原因.Items.Add("03.賣相不佳")
    ''            T4Cb1原因.Items.Add("04.包裝問題")
    ''            T4Cb1原因.Items.Add("05.真空度不佳")
    ''            T4Cb1原因.Items.Add("06.生產規格")
    ''            T4Cb1原因.Items.Add("07.標示相關")
    ''            T4Cb1原因.Items.Add("08.作業疏失")
    ''            T4Cb1原因.Items.Add("09.客戶相關")
    ''            T4Cb1原因.Items.Add("10.其他")
    ''        Case "1"
    ''            T4Cb1原因.Items.Add("01.品質不佳")
    ''            T4Cb1原因.Items.Add("02.異物")
    ''            T4Cb1原因.Items.Add("03.賣相不佳")
    ''            T4Cb1原因.Items.Add("04.包裝破損")
    ''            T4Cb1原因.Items.Add("05.真空度不佳")
    ''            T4Cb1原因.Items.Add("06.生產規格")
    ''            T4Cb1原因.Items.Add("07.標示相關")
    ''            T4Cb1原因.Items.Add("08.作業疏失")
    ''            T4Cb1原因.Items.Add("09.客戶相關")
    ''            T4Cb1原因.Items.Add("10.其他")
    ''    End Select
    ''    T4Cb1原因.SelectedIndex = -1

    ''End Sub

    ''Tp退貨數量_作業載入
    'Private Sub Bu3數量_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu3數量.Click
    '    If Lt3名稱.Text <> "" Then
    '        If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨數量) : Me.TabControl1.TabPages.Remove(Tp退貨輸入) : End If
    '        Me.TabControl1.SelectedTab = Me.Tp退貨數量
    '        If T4DGV清空 = "Y" Then
    '            T4退貨數量載入()
    '            T4輸入資料.AutoResizeColumns()
    '            T4Cb1類別.SelectedIndex = -1
    '            T4Cb1原因.SelectedIndex = -1
    '            T4DGV清空 = "N"
    '        End If

    '        'If TB單號.Text = "" Then
    '        '    T4單號空白 = "AAAAAAAAAA"
    '        'Else
    '        '    T4單號空白 = TB單號.Text
    '        'End If
    '    Else
    '        MsgBox("請先選擇退貨品項")
    '    End If


    'End Sub

    'Private Sub T4退貨數量載入()
    '    If T4輸入資料.RowCount > 0 Then : 顯示資料.Tables("退貨數量_退").Clear() : End If '清除資料
    '    Dim SQLQuery As String = ""
    '    'SQLQuery = "    SELECT [存貨編號],[存編名稱],[退貨數量],[數量],[出貨重量],[單位],[數量2],[小單位],[單價],[計價],[金額],[倉別],[稅碼],[列號],[備註] "
    '    'SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折表身] "
    '    'SQLQuery += "    WHERE [單號] = '" & TB單號.Text & "' AND [啟用] = 'Y' "
    '    'SQLQuery += " ORDER BY [列號] "

    '    'SQLQuery = "     SELECT CAST([ID] AS VARCHAR(20)) AS 'ID',[單號],[存貨編號],[存編名稱],[退貨數量],[營_類別],[營_退貨原因],[營_補充說明],[列號] "
    '    'SQLQuery += "      FROM [KaiShingPlug].[dbo].[營_退折明細] "

    '    SQLQuery = "     SELECT [ID],[單號],[存貨編號],[存編名稱],[退貨數量],[營_類別] AS '類別代碼',T2.[類別],[營_退貨原因] AS '原因代碼',T3.[原因], "
    '    SQLQuery += "           [營_補充說明] AS '補充說明',[列號] "
    '    SQLQuery += "     FROM [KaiShingPlug].[dbo].[營_退折明細] T1 LEFT JOIN "
    '    SQLQuery += "     (SELECT [優先順序] AS '代碼',[對應2] AS '類別' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '1' AND [啟用否] = 'Y' "
    '    SQLQuery += "     ) T2 ON T1.[營_類別] = T2.[代碼]           LEFT JOIN "
    '    SQLQuery += "     (SELECT [優先順序] AS '代碼',[對應2] AS '原因' FROM [KaiShingPlug].[dbo].[對應表] WHERE [名稱] = '退貨' AND [作業功能] = '2' AND [啟用否] = 'Y' "
    '    SQLQuery += "     ) T3 ON T1.[營_類別] = T3.[代碼]    "
    '    'SQLQuery += "     WHERE [單號] = '" & TB單號.Text & "' AND [存貨編號] = '" & Lt4存編.Text & "' AND [啟用] IN ('Y','S') "
    '    SQLQuery += "     WHERE [單號] = '" & TB單號.Text & "' AND [啟用] = 'Y' "
    '    SQLQuery += "  ORDER BY [ID] "


    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Try
    '        MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
    '        MSSQL作業.Fill(顯示資料, "退貨數量_退")
    '        T4輸入資料.DataSource = 顯示資料.Tables("退貨數量_退")
    '        T4退貨數量顯示()
    '        T4退貨數量合計更新()
    '    Catch ex As Exception
    '        MsgBox("退貨數量：" & ex.Message)
    '        Exit Sub
    '    End Try

    'End Sub

    'Private Sub T4退貨數量顯示()
    '    For Each column As DataGridViewColumn In T4輸入資料.Columns
    '        column.Visible = True : column.ReadOnly = True
    '        Select Case column.Name
    '            Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 0 : column.Visible = False ' : column.Frozen = True
    '            Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 : column.Visible = False ' : column.Frozen = True
    '            Case "存貨編號" : column.HeaderText = "存貨編號" : column.DisplayIndex = 2 ': column.Frozen = True
    '            Case "存編名稱" : column.HeaderText = "存編名稱" : column.DisplayIndex = 3 ': column.ReadOnly = True : column.Frozen = True    '可修改
    '            Case "退貨數量" : column.HeaderText = "退貨數量" : column.DisplayIndex = 4 ': column.Frozen = True
    '            Case "類別代碼" : column.HeaderText = "類別代碼" : column.DisplayIndex = 5 : column.Visible = False
    '            Case "類別" : column.HeaderText = "類別" : column.DisplayIndex = 6
    '            Case "原因代碼" : column.HeaderText = "原因代碼" : column.DisplayIndex = 7 : column.Visible = False
    '            Case "原因" : column.HeaderText = "原因" : column.DisplayIndex = 8
    '            Case "補充說明" : column.HeaderText = "補充說明" : column.DisplayIndex = 9
    '            Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 10 : column.Visible = False
    '            Case Else
    '                column.Visible = False
    '        End Select
    '    Next

    'End Sub

    'Private Sub Bu4輸入_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4輸入.Click
    '    If CDbl(Lt4數量.Text) <> 0 Then
    '        Dim Row As DataRow
    '        Row = 顯示資料.Tables("退貨數量_退").NewRow
    '        Row.Item("ID") = "0"
    '        Row.Item("單號") = ""
    '        Row.Item("存貨編號") = Lt4存編.Text
    '        Row.Item("存編名稱") = Lt4名稱.Text
    '        Row.Item("退貨數量") = Lt4數量.Text
    '        Row.Item("類別代碼") = T4Cb1類別.SelectedValue.ToString
    '        Row.Item("類別") = T4Cb1類別.Text
    '        Row.Item("原因代碼") = T4Cb1原因.SelectedValue.ToString
    '        Row.Item("原因") = T4Cb1原因.Text
    '        Row.Item("補充說明") = T4Lt4說明.Text
    '        Row.Item("列號") = Lt4列號.Text

    '        顯示資料.Tables("退貨數量_退").Rows.Add(Row)
    '        T4退貨數量合計更新()

    '        Lt4數量.Text = ""
    '        T4Lt4說明.Text = ""
    '    End If
    '    T4輸入資料.AutoResizeColumns()

    'End Sub

    'Private Sub Bu4移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4移除.Click
    '    Dim i As Integer = 0
    '    i = T4輸入資料.CurrentCell.RowIndex()   '
    '    Dim oAns As Integer
    '    oAns = MsgBox("是否確定刪除選定資料  " & (T4輸入資料.CurrentCell.RowIndex() + 1), MsgBoxStyle.YesNo, "刪除選定資料")
    '    If oAns = MsgBoxResult.Yes Then  'Yes執行區
    '        T4輸入資料.Rows.Remove(T4輸入資料.Rows(i))  '移除
    '        T4退貨數量合計更新()
    '    End If
    'End Sub

    'Private Sub T4退貨數量合計更新()
    '    Dim 數量 As Double = 0
    '    Dim count As Integer = T4輸入資料.Rows.Count
    '    For i As Integer = count - 1 To 0 Step -1
    '        If T4輸入資料.Rows(i).Cells("存貨編號").Value = Lt4存編.Text Then
    '            數量 = +數量 + T4輸入資料.Rows(i).Cells("退貨數量").Value
    '        End If
    '    Next
    '    Lt4合計.Text = Format(數量, "#0.00")

    'End Sub

    'Private Sub Bu4存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4存檔.Click
    '    If T3退貨明細.RowCount = 0 Then : MsgBox("無退貨品項") : Exit Sub : End If

    '    'T4存檔()

    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨輸入) : Me.TabControl1.TabPages.Remove(Tp退貨數量) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨輸入
    '    T3退貨明細.CurrentRow.Cells("退貨數量").Value = Lt4合計.Text

    '    T4分頁Load初始化()
    'End Sub

    'Private Sub T4存檔(ByVal 單號 As String)
    '    Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

    '    '修正_先作廢
    '    SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[營_退折明細] "
    '    SQLADD1 += "    SET [啟用]     = 'N', "
    '    SQLADD1 += "        [修改時間] = GETDATE() "
    '    'SQLADD1 += "  WHERE [單號] = '" & 單號 & "' AND [存貨編號] = '" & Lt4存編.Text & "' " & vbCrLf
    '    SQLADD1 += "  WHERE [單號] = '" & 單號 & "' AND 啟用 = 'Y' " & vbCrLf

    '    For i As Integer = 0 To T4輸入資料.RowCount - 1
    '        SQLADD2 += " INSERT INTO [KaiShingPlug].[dbo].[營_退折明細] "
    '        SQLADD2 += " ([單號],[存貨編號],[存編名稱],[退貨數量],[營_類別],[營_退貨原因],[營_補充說明],[列號],[啟用],[新增時間]) VALUES "
    '        SQLADD2 += " ('" & 單號 & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("存貨編號").Value & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("存編名稱").Value & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("退貨數量").Value & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("類別代碼").Value & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("原因代碼").Value & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("補充說明").Value & "', "
    '        SQLADD2 += "  '" & T4輸入資料.Rows(i).Cells("列號").Value & "'    , "
    '        SQLADD2 += "  'Y',GETDATE() )"
    '    Next
    '    'MsgBox(SQLADD1 + SQLADD2)

    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand

    '    Try
    '        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
    '        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

    '        'Select Case 作業
    '        '    Case "新增"
    '        '        MsgBox("單號：" & 單號 & "新增完成")
    '        '    Case "修改"
    '        '        MsgBox("單號：" & 單號 & "修改完成")
    '        'End Select
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub











    'Private Sub Bu4放棄_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4放棄.Click

    '    'T4放棄()
    '    If TP切換限制 = "Y" Then : Me.TabControl1.TabPages.Add(Tp退貨輸入) : Me.TabControl1.TabPages.Remove(Tp退貨數量) : End If
    '    Me.TabControl1.SelectedTab = Me.Tp退貨輸入

    '    T4分頁Load初始化()
    'End Sub

    ''Private Sub T4放棄()
    ''    Dim SQLADD1 As String = ""

    ''    '修正_先作廢
    ''    SQLADD1 = "  UPDATE [KaiShingPlug].[dbo].[營_退折明細] "
    ''    SQLADD1 += "    SET [啟用]     = 'N', "
    ''    SQLADD1 += "        [修改時間] = GETDATE() "
    ''    SQLADD1 += "  WHERE [單號] = '" & T4單號空白 & "' AND [存貨編號] = '" & Lt4存編.Text & "' " & vbCrLf

    ''    Dim DBConn As SqlConnection = Login.DBConn
    ''    Dim SQLCmd As SqlCommand = New SqlCommand

    ''    Try
    ''        SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 : SQLCmd.CommandTimeout = 100000
    ''        SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    End Try

    ''End Sub
