Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_AUTO_ORDR
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Public Source As String '員購則帶入Welfare EC則帶入EC
    Public KEY As String '編號
    Public CardCode As String '客戶編號
    Public CardName As String '客戶名稱
    Public strSaleGroupType As String '群組編號
    Public strAtttibuteType As String '商品屬性 0.生鮮品-未稅 1.調理品=含稅
    Public strOrderSource As String 'EC訂單來源
    Public strOrderName As String 'EC訂單類型
    Public strOrderType As String 'EC訂單代碼

    Private Sub A_AUTO_ORDR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        A_Welfare_List.MdiParent = MainForm
        A_Welfare_List.Show()

    End Sub


    Private Sub A_AUTO_ORDR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If

        ItemU_P3cob.SelectedIndex = 1      '是否生產 預設 = 否
        ItemU_P7cob.SelectedIndex = 1      '計價單位 預設 = KG
        ItemU_P3_Order.SelectedIndex = 1   '生產訂單 預設 = 否

        Select Case Source
            Case "Welfare"
                Label2.Visible = True
                ddlKeepName.Visible = True
                ddlKeepName.SelectedIndex = 0      '溫層 預設 = X
                laOrderSource.Text = ""
                laOrderSource.Visible = False
            Case "EC"
                Label2.Visible = False
                ddlKeepName.Visible = False
                'laOrderSource.Text = "訂單來源： " + strOrderSource
                laOrderSource.Visible = True
        End Select


        SelectItemU_P6cob()
        SelectU_CarDr()
        SelectOwner()

        Select Case Source
            Case "Welfare"
                DocDueDate.Value = KEY
                Label20.Text = "員購日期："
                DocDueDate.Enabled = False

            Case "EC"
                DocDueDate.MinDate = DateTime.Today
                Label20.Text = "交貨日期："
                DocDueDate.Enabled = True

        End Select

        laCardCode.Text = CardCode
        laCardName.Text = CardName

        GetDav1Data()
        GetDav3Data()
    End Sub
    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()

    End Sub

    Private Sub ItemNameTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()

    End Sub

    Private Sub ItemU_P82Txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemU_P8Txt.LostFocus
        'SelectItemU_P8()

    End Sub
    Private Sub SelectItemCode()

        If ItemCodeTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope




            If strAtttibuteType = "0" Or strAtttibuteType = "" Then '生鮮
                sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"
            ElseIf strAtttibuteType = "1" Then '調理
                sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) = '3'"
            End If

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()

                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "ORDR"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemNameTxt.Text = sqlReader.Item("ItemName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemName()

        If ItemNameTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            If strAtttibuteType = "0" Or strAtttibuteType = "" Then '生鮮
                sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemNameTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"
            ElseIf strAtttibuteType = "1" Then '調理
                sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemNameTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) = '3'"
            End If


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "ORDR"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemCodeTxt.Text = sqlReader.Item("ItemCode")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub


    Private Sub ItemCodeTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ItemCodeTxt.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 2 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub ItemNameTxt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ItemNameTxt.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 2 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub GetDav1Data()

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String = String.Empty
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            Select Case Source
                Case "Welfare"
                    sql = " SELECT T0.[ProCode] AS 'ItemCode', T0.[ProName] AS 'Dscription', T0.[Price] AS 'U_P8', T0.[U_P7] "
                    sql += "    , T1.SalPackUn AS 'U_P4', T1.[OnHand] AS 'OnHand', Count(T0.Num) AS '本次數量'"
                    sql += "    , Case SUBSTRING(T0.[ProCode],1,3) When '253' Then T1.[SalUnitMsr] Else  T1.SalPackMsr  End AS 'U_P6'"
                    sql += "    , 'N' AS 'U_P3'"
                    sql += "    , Case SUBSTRING(T0.[ProCode],1,3) When '253' Then ISNULL(T4.[FldValue],0) Else  ISNULL(T3.[FldValue],0)  End AS 'U_P62' "
                    sql += "    , T0.KeepName "
                    sql += " FROM [KS_Z_Welfare] T0 INNER JOIN [OITM] T1 ON T0.[ProCode] = T1.[ItemCode] "
                    sql += " LEFT JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] AND T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9' "
                    sql += " LEFT JOIN [UFD1] T4 ON T1.[SalUnitMsr] = T4.[Descr] AND T4.[TableID] = 'RDR1' AND T4.[FieldID] = '9' "
                    sql += " WHERE Convert(varchar,T0. AddDate,111)='" + KEY + "' AND T0.SaleGroupType='" + strSaleGroupType + "' AND T0.state='2' "
                    sql += " Group By T0.[ProCode], T0.[ProName], T0.[Price],  T0.[U_P7], T1.[SalPackUn], T1.[OnHand] "
                    sql += " , T1.[SalUnitMsr], T1.SalPackMsr, T4.[FldValue], T3.[FldValue], T0.[KeepName] "
                    sql += " ORDER BY 1 DESC "
                Case "EC"
                    sql = " SELECT T1.[ItemCode] AS 'ItemCode', T1.[ItemName] AS 'Dscription' "
                    sql += "    , CASE T0.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END AS 'AtttibuteType' "
                    sql += "    , CASE E.OrderType When '1' Then '常態' When '2' Then '活動' When '3' Then '缺料' END AS 'OrderType' "
                    sql += "    , CASE ISNULL(EP.Price,0) WHEN '0' THEN '0' ELSE EP.Price END AS 'U_P8', '1' AS 'U_P7'"
                    sql += "    , T1.SalPackUn AS 'U_P4', T1.[OnHand] AS 'OnHand', Sum(T0.[Count]) AS '本次數量' "
                    sql += "    , Case SUBSTRING(T1.[ItemCode],1,3) When '253' Then T1.[SalUnitMsr] Else  T1.SalPackMsr  End AS 'U_P6' "
                    sql += "    , 'N' AS 'U_P3' "
                    sql += "    , Case SUBSTRING(T1.[ItemCode],1,3) When '253' Then ISNULL(T4.[FldValue],0) Else  ISNULL(T3.[FldValue],0)  End   AS 'U_P62'  "
                    sql += " FROM [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] T0 INNER JOIN [OITM] T1 ON T0.[ProtModel] = T1.[ItemCode]  "
                    sql += " INNER JOIN  [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON T0.ID=E.ID "
                    sql += " LEFT JOIN  KS_A_ECPrice EP ON T0.ProtModel=EP.ProCode AND E.OrderType=EP.PriceType AND EP.Examine='2' "
                    sql += " LEFT JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] AND T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9'  "
                    sql += " LEFT JOIN [UFD1] T4 ON T1.[SalUnitMsr] = T4.[Descr] AND T4.[TableID] = 'RDR1' AND T4.[FieldID] = '9'  "
                    sql += " WHERE Convert(varchar,E.AddDate,111)='" + KEY + "'  AND T0.AtttibuteType='" + strAtttibuteType + "' AND T0.state='0' AND E.OrderType='" + strOrderType + "'"
                    sql += " Group By T1.[ItemCode], T1.[ItemName], T0.AtttibuteType,E.OrderType, T1.SalPackUn, T1.[OnHand], T1.[SalUnitMsr], T1.SalPackMsr, T4.[FldValue], T3.[FldValue],EP.Price "
                    sql += " ORDER BY 1 DESC  "
            End Select



            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")



            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV1Display()

    End Sub
    'DGV2
    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn2.Click

        If DGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String = String.Empty
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            If strAtttibuteType = "0" Or strAtttibuteType = "" Then '生鮮
                sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.ItemName AS 'Dscription', T0.[OnHand], T0.SalPackUn AS 'U_P4', T0.SalPackMsr AS 'U_P6' FROM [OITM] T0 WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') AND T0.[ItemName] Not Like '%XXX%' AND  T0.[ItemName] Not Like '%領改%' AND T0.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[ItemName] Like '%" & TextBox2.Text & "%'  AND T0.[ItemName] Like '%" & TextBox3.Text & "%' "
            ElseIf strAtttibuteType = "1" Then '調理
                sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.ItemName AS 'Dscription', T0.[OnHand], "
                sql += " T0.SalPackUn AS 'U_P4', T0.SalUnitMsr AS 'U_P6'  "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                sql += " AND SUBSTRING(T0.[ItemCode],4,1) ='3' AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                sql += " AND  T0.[ItemName] Not Like '%領改%'   "
                sql += " AND LEN(T0.[ItemCode])=15 "
                sql += " AND T0.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[ItemName] Like '%" & TextBox2.Text & "%'  AND T0.[ItemName] Like '%" & TextBox3.Text & "%' "
            End If

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "DT1")

            DGV2.DataSource = ks2DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV2Display()

    End Sub

    Private Sub GetDav3Data()

        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        Dim sql As String = String.Empty
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            Select Case Source
                Case "Welfare"
                    sql = "    Select ProCode AS '存編', ProName AS '品名', Num AS '數量', EmpID AS '員工編號', EmpName AS '員工姓名'    "
                    sql += "   , Barcode AS '條碼', Weight AS '重量', Convert(varchar,AddDate,111) AS '下單日期', Convert(varchar,MnfDate,111) AS '製造日期', KeepName AS 溫層 "
                    sql += "   From KS_Z_Welfare "
                    sql += "   Where convert(varchar,AddDate,111)='" & KEY & "' AND SaleGroupType='" + strSaleGroupType + "' AND state='2' "
                    sql += "   ORDER BY 存編 DESC, 員工編號 DESC, AddDate DESC"
                Case "EC"
                    sql = " Select ED.ID AS '訂單編號', ProtModel AS '商品型號', ProName AS '通路商品名稱', Count AS '數量',MEMO AS '訂單備註', "
                    sql += " SourceName AS '來源', PayClass AS '付款方式', OrderName AS '訂購人姓名', OrderTel AS '訂購人聯絡電話', "
                    sql += " GetName AS '送貨取件姓名', GetTel AS '送貨聯絡電話', GetAddress AS '送貨地址', "
                    sql += " AddDate AS '訂購時間' "
                    sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
                    sql += " INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
                    sql += " Where Convert(varchar,E.AddDate,111)='" & KEY & "' AND ED.state='0' AND ED.AtttibuteType='" + strAtttibuteType + "' AND E.OrderType='" + strOrderType + "'"
                    sql += " ORDER BY ProtModel DESC "
            End Select



            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")

            DGV3.DataSource = ks1DataSetDGV.Tables("DT3")
            TransactionMonitor.Complete()
        End Using
        DGV3Display()

    End Sub


    Private Sub DGV1Display()
        Select Case Source
            Case "Welfare"
                For Each column As DataGridViewColumn In DGV1.Columns
                    column.Visible = True

                    Select Case column.Name
                        Case "ItemCode"
                            column.HeaderText = "產品編號"
                            column.DisplayIndex = 0
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 110
                        Case "Dscription"
                            column.HeaderText = "產品名稱"
                            column.DisplayIndex = 1
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 180
                        Case "KeepName"
                            column.HeaderText = "溫層"
                            column.DisplayIndex = 2
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                        Case "U_P8"
                            column.HeaderText = "單價"
                            column.DisplayIndex = 3
                            'column.ReadOnly = True
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.DefaultCellStyle.Format = "#0.0000"
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 60
                        Case "OnHand"
                            column.HeaderText = "庫存量"
                            column.DisplayIndex = 4
                            column.ReadOnly = True
                            column.DefaultCellStyle.Format = "#0.##"
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 50
                        Case "本次數量"
                            column.HeaderText = " 訂購數量"
                            column.DisplayIndex = 5
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 70
                            column.ReadOnly = True
                        Case "U_P7"
                            column.HeaderText = "計價單位"
                            column.DisplayIndex = 6
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Visible = False
                        Case "U_P4"
                            column.HeaderText = "小單位數量"
                            column.DisplayIndex = 7
                            'column.ReadOnly = True
                            column.DefaultCellStyle.Format = "#0.##"
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 80
                        Case "U_P6"
                            column.HeaderText = "小單位"   '中文
                            column.DisplayIndex = 8
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Visible = False
                        Case "U_P62"
                            column.HeaderText = "小單位2"   '
                            column.DisplayIndex = 9
                            column.ReadOnly = True
                            column.Visible = False
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                        Case "U_P3"
                            column.HeaderText = "是否生產"
                            column.DisplayIndex = 10
                            'column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 80
                        Case Else
                            column.Visible = False
                    End Select
                Next
            Case "EC"
                For Each column As DataGridViewColumn In DGV1.Columns
                    column.Visible = True

                    Select Case column.Name
                        Case "ItemCode"
                            column.HeaderText = "產品編號"
                            column.DisplayIndex = 0
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 110
                        Case "Dscription"
                            column.HeaderText = "產品名稱"
                            column.DisplayIndex = 1
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 180
                        Case "AtttibuteType"
                            column.HeaderText = "商品屬性"
                            column.DisplayIndex = 2
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 70
                        Case "OrderType"
                            column.HeaderText = "訂單類型"
                            column.DisplayIndex = 3
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 70
                        Case "U_P8"
                            column.HeaderText = "單價"
                            column.DisplayIndex = 4
                            'column.ReadOnly = True
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.DefaultCellStyle.Format = "#0.0000"
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 60
                        Case "OnHand"
                            column.HeaderText = "庫存量"
                            column.DisplayIndex = 5
                            column.ReadOnly = True
                            column.DefaultCellStyle.Format = "#0.##"
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 50
                        Case "本次數量"
                            column.HeaderText = " 訂購數量"
                            column.DisplayIndex = 6
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 70
                            column.ReadOnly = True
                        Case "U_P7"
                            column.HeaderText = "計價單位"
                            column.DisplayIndex = 7
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Visible = False
                        Case "U_P4"
                            column.HeaderText = "小單位數量"
                            column.DisplayIndex = 8
                            'column.ReadOnly = True
                            column.DefaultCellStyle.Format = "#0.##"
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 80
                        Case "U_P6"
                            column.HeaderText = "小單位"   '中文
                            column.DisplayIndex = 9
                            column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Visible = False
                        Case "U_P62"
                            column.HeaderText = "小單位2"   '
                            column.DisplayIndex = 10
                            column.ReadOnly = True
                            column.Visible = False
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                        Case "U_P3"
                            column.HeaderText = "是否生產"
                            column.DisplayIndex = 11
                            'column.ReadOnly = True
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.Width = 80
                        Case Else
                            column.Visible = False
                    End Select
                Next
        End Select


        'Next

        '=============================================================自動產生DGV控制項 BEGIN======================================================================
        Dim 刪除 As New DataGridViewButtonColumn()
        刪除.Name = "刪除"
        刪除.HeaderText = ""
        刪除.DisplayIndex = 0
        刪除.Width = 40
        刪除.Text = "刪除"
        刪除.UseColumnTextForButtonValue = True
        DGV1.Columns.Add(刪除)

        Dim 計價單位 As New DataGridViewComboBoxColumn()
        計價單位.Name = "計價單位"
        計價單位.HeaderText = "計價單位"
        計價單位.Width = 70
        計價單位.Items.Add("庫存單位")
        計價單位.Items.Add("KG")
        計價單位.Items.Add("小單位")
        計價單位.Items.Add("重整")



        Dim 小單位 As New DataGridViewComboBoxColumn()
        小單位.Name = "小單位"
        小單位.HeaderText = "小單位"
        小單位.Width = 70

        Select Case Source
            Case "Welfare"
                計價單位.DisplayIndex = 5
                小單位.DisplayIndex = 7
            Case "EC"
                計價單位.DisplayIndex = 6
                小單位.DisplayIndex = 9
        End Select

        DGV1.Columns.Add(計價單位)

        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = " SELECT T0.[FldValue], T0.[Descr] FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' Order by T0.[IndexID] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        小單位.DataSource = ksSelectDataSet.Tables("DT1")
        小單位.DisplayMember = "Descr"

        DGV1.Columns.Add(小單位)
        '=============================================================自動產生DGV控制項 END=======================================================================
        'DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV2Display()

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "產品編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "Dscription"
                    column.HeaderText = "產品名稱"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    'Case "U_P8"
                    '    column.HeaderText = "單價1"
                    '    column.DisplayIndex = 2
                    '    'column.ReadOnly = True
                    '    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.DefaultCellStyle.Format = "#0.##"
                    'Case "本次數量"
                    '    column.HeaderText = " 訂購數量"
                    '    column.DisplayIndex = 4
                    '    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    'Case "U_P7"
                    '    column.HeaderText = "計價單位"
                    '    column.DisplayIndex = 5
                    '    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Case "U_P4"
                    column.HeaderText = "小單位數量"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.DefaultCellStyle.Format = "##.##"
                Case "U_P6"
                    column.HeaderText = "小單位"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                    'Case "U_P62"
                    '    column.HeaderText = "小單位"
                    '    column.DisplayIndex = 5
                    '    column.ReadOnly = True
                    '    column.Visible = False

                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub DGV3Display()

        Select Case Source
            Case "Welfare"
                For Each column As DataGridViewColumn In DGV3.Columns
                    column.Visible = True

                    Select Case column.Name
                        Case "存編"
                            column.HeaderText = "存編"
                            column.DisplayIndex = 0
                            column.ReadOnly = True
                            column.Width = 110
                        Case "品名"
                            column.HeaderText = "品名"
                            column.DisplayIndex = 1
                            column.ReadOnly = True
                            column.Width = 180
                        Case "溫層"
                            column.HeaderText = "溫層"
                            column.DisplayIndex = 2
                            column.ReadOnly = True
                        Case "數量"
                            column.HeaderText = "數量"
                            column.DisplayIndex = 3
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.Width = 40
                        Case "員工編號"
                            column.HeaderText = "員工編號"
                            column.DisplayIndex = 4
                            column.ReadOnly = True
                            column.Width = 80
                        Case "員工姓名"
                            column.HeaderText = "員工姓名"
                            column.DisplayIndex = 5
                            column.ReadOnly = True
                            column.Width = 80
                        Case "條碼"
                            column.HeaderText = " 條碼"
                            column.DisplayIndex = 6
                            column.ReadOnly = True
                            column.Width = 110
                        Case "重量"
                            column.HeaderText = "重量"
                            column.DisplayIndex = 7
                            column.ReadOnly = True
                        Case "下單日期"
                            column.HeaderText = "下單日期"
                            column.DisplayIndex = 8
                            column.ReadOnly = True
                        Case "製造日期"
                            column.HeaderText = "製造日期"
                            column.DisplayIndex = 9
                            column.ReadOnly = True
                        Case Else
                            column.Visible = False
                    End Select
                Next
            Case "EC"
                For Each column As DataGridViewColumn In DGV3.Columns
                    column.Visible = True

                    Select Case column.Name
                        Case "訂單編號"
                            column.HeaderText = "訂單編號"
                            column.DisplayIndex = 0
                            column.ReadOnly = True
                            column.Width = 110
                        Case "通路商品型號"
                            column.HeaderText = "通路商品型號"
                            column.DisplayIndex = 1
                            column.ReadOnly = True
                            column.Width = 110
                        Case "通路商品名稱"
                            column.HeaderText = "通路商品名稱"
                            column.DisplayIndex = 2
                            column.ReadOnly = True
                            column.Width = 180
                        Case "數量"
                            column.HeaderText = "數量"
                            column.DisplayIndex = 3
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                            column.Width = 40
                        Case "訂單備註"
                            column.HeaderText = "訂單備註"
                            column.DisplayIndex = 4
                            column.ReadOnly = True
                        Case "來源"
                            column.HeaderText = "來源"
                            column.DisplayIndex = 5
                            column.ReadOnly = True
                        Case "付款方式"
                            column.HeaderText = " 付款方式"
                            column.DisplayIndex = 6
                            column.ReadOnly = True
                        Case "訂購人姓名"
                            column.HeaderText = "訂購人姓名"
                            column.DisplayIndex = 7
                            column.ReadOnly = True
                        Case "訂購人聯絡電話"
                            column.HeaderText = "訂購人聯絡電話"
                            column.DisplayIndex = 8
                            column.ReadOnly = True
                        Case "送貨取件姓名"
                            column.HeaderText = "送貨取件姓名"
                            column.DisplayIndex = 9
                            column.ReadOnly = True
                        Case "送貨聯絡電話"
                            column.HeaderText = "送貨聯絡電話"
                            column.DisplayIndex = 10
                            column.ReadOnly = True
                        Case "送貨地址"
                            column.HeaderText = "送貨地址"
                            column.DisplayIndex = 11
                            column.ReadOnly = True
                        Case "訂購時間"
                            column.HeaderText = "訂購時間"
                            column.DisplayIndex = 12
                            column.ReadOnly = True
                        Case Else
                            column.Visible = False
                    End Select
                Next
        End Select


    End Sub

#Region "DGV1觸發事件"
    Private Sub DGV1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick
        If e.RowIndex <> -1 Then
            If DGV1.Columns(e.ColumnIndex).Name = "刪除" Then
                DGV1.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub DGV1_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DGV1.DataBindingComplete
        Try
            For i As Integer = 0 To DGV1.RowCount - 1
                Dim 計價單位 As DataGridViewComboBoxCell = DirectCast(DGV1.Rows(i).Cells("計價單位"), DataGridViewComboBoxCell)
                Dim 小單位 As DataGridViewComboBoxCell = DirectCast(DGV1.Rows(i).Cells("小單位"), DataGridViewComboBoxCell)

                If 計價單位.Value = "" Then
                    Dim ItemU_P7 As String = String.Empty

                    Select Case DGV1.Rows(i).Cells("U_P7").Value
                        Case "0"
                            ItemU_P7 = "庫存單位"
                        Case "1"
                            ItemU_P7 = "KG"
                        Case "2"
                            ItemU_P7 = "小單位"
                        Case "3"
                            ItemU_P7 = "重整"
                    End Select

                    計價單位.Value = ItemU_P7
                End If

                Select Case Source
                    Case "Welfare"
                        If 小單位.Value = "" Then
                            小單位.Value = DGV1.Rows(i).Cells("U_P6").Value
                        End If
                    Case "EC"
                        小單位.Value = "X"
                End Select


            Next
        Catch ex As Exception
            ' MsgBox("ERROR: " & ex.Message)
        End Try

    End Sub
#End Region

#Region "DGV2觸發事件"
    '--新增存編
    Private Sub DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount <= 0 Then
            Exit Sub
        End If

        ItemCodeTxt.Text = DGV2.CurrentRow.Cells("ItemCode").Value
        ItemNameTxt.Text = DGV2.CurrentRow.Cells("Dscription").Value
        SelectItemCode()

        'ItemCodeTxt.Text = DGV2.CurrentRow.Cells("庫存量").Value
        ItemU_P4Txt.Text = DGV2.CurrentRow.Cells("U_P4").Value
        ItemU_P6cob.Text = DGV2.CurrentRow.Cells("U_P6").Value
        'ItemU_P6cob.SelectedIndex = DGV2.CurrentRow.Cells("U_P62").Value

        ItemU_P8Txt.Text = 0   '價格
        Quantity.Text = 0      '數量



    End Sub   ''---
#End Region

#Region "DGV3觸發事件"
    Private Sub DGV3_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellClick
        Select Case Source
            Case "Welfare"
                TextBox1.Text = DGV3.CurrentRow.Cells("品名").Value
            Case "EC"
                TextBox1.Text = DGV3.CurrentRow.Cells("通路商品名稱").Value
        End Select

    End Sub
#End Region



    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click
        'If DGV1.RowCount <= 0 Then
        '    MsgBox("未有銷售資料!", 16, "錯誤")
        '    Exit Sub
        'End If

        If ItemCodeTxt.Text = "" Then
            MsgBox("項目編號未填!", 16, "錯誤")
            ItemCodeTxt.Focus()
            Exit Sub
        End If

        If ItemNameTxt.Text = "" Then
            MsgBox("項目名稱未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If

        If ItemU_P8Txt.Text = "" Then
            MsgBox("項目價格未填!", 16, "錯誤")
            'ItemU_P8Txt.Focus()
            Exit Sub
        End If

        If Quantity.Text = "" Then
            MsgBox("項目訂購數量未填!", 16, "錯誤")
            'ItemU_P8Txt.Focus()
            Exit Sub
        End If



        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "'"
            'sql = " SELECT T0.[ItemCode], T0.ItemName, ISNULL(T1.U_P8,0) AS 'U_P82' FROM [OITM] T0 LEFT JOIN (SELECT TOP 1 Z0.[DocEntry], Z0.[ItemCode], Z0.[U_P8] FROM [INV1] Z0 INNER JOIN [OINV] Z1 ON Z0.[DocEntry] = Z1.[DocNum] WHERE Z1.[CardCode] = '" & CardCode.Text & "' AND Z0.[ItemCode] = '" + ItemCodeTxt.Text + "'  ORDER BY 1 DESC ) T1 ON T0.[ItemCode] = T1.ItemCode WHERE T0.[ItemCode] = '" + ItemCodeTxt.Text + "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("輸入的項目編號有誤!", 16, "錯誤")
                ItemCodeTxt.Focus()
                Exit Sub
            End If

            Dim Row As DataRow
            Row = ks1DataSetDGV.Tables("DT1").NewRow
            Row.Item("ItemCode") = ItemCodeTxt.Text
            Row.Item("Dscription") = ItemNameTxt.Text
            'Row.Item("U_P3") = ItemU_P3cob.SelectedIndex
            Row.Item("U_P3") = ItemU_P3cob.Text
            Row.Item("U_P4") = ItemU_P4Txt.Text
            Row.Item("U_P8") = ItemU_P8Txt.Text
            Row.Item("U_P6") = ItemU_P6cob.Text
            Row.Item("U_P62") = ItemU_P6cob.SelectedIndex
            Row.Item("U_P7") = ItemU_P7cob.SelectedIndex

            Dim AtttibuteName As String = String.Empty
            Select Case strAtttibuteType
                Case "0"
                    AtttibuteName = "生鮮品"
                Case "1"
                    AtttibuteName = "調理品"
            End Select

            Select Case Source
                Case "Welfare"
                    Row.Item("KeepName") = ddlKeepName.SelectedItem
                Case "EC"
                    Row.Item("AtttibuteType") = AtttibuteName
                    Row.Item("OrderType") = strOrderName
            End Select


            'Row.Item("U_P82") = ItemU_P82Txt.Text
            Row.Item("本次數量") = Quantity.Text

            ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

            ItemCodeTxt.Text = ""
            ItemNameTxt.Text = ""
            ItemU_P4Txt.Text = 0
            ItemU_P8Txt.Text = 0
            ItemU_P7cob.SelectedIndex = 1
            ddlKeepName.SelectedIndex = 0
            Quantity.Text = 0


            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn


        If DGV1.RowCount <= 0 Then
            MsgBox("無銷售資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim Cnt As Integer = 0

        For j As Integer = 0 To DGV1.RowCount - 1
            If Convert.ToInt32(DGV1.Rows(j).Cells("本次數量").Value) = 0 Then
                MsgBox("第" + Convert.ToString(j + 1) + "筆，銷售數量為0!", 16, "錯誤")
                Exit Sub
            End If

            If Convert.ToInt32(DGV1.Rows(j).Cells("U_P8").Value) = 0 Then
                MsgBox("第" + Convert.ToString(j + 1) + "筆，價格為0!", 16, "錯誤")
                Exit Sub
            End If
        Next

        Dim oAns As Integer

        oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oDraft As SAPbobsCOM.Documents
        Dim X As Integer = 0
        Dim RetVal As Long

        oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)

        'oRecordSet.DocObjectCode = SAPbobsCOM.BoObjectTypes.oOrders
        oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oOrders

        oDraft.CardCode = laCardCode.Text
        oDraft.DocDate = DocDueDate.Value.Date
        oDraft.DocDueDate = DocDueDate.Value.Date
        oDraft.TaxDate = DocDueDate.Value.Date

        oDraft.Comments = Now + " 接單者：" + vbCrLf + CommentsTxt.Text
        'oDraft.DocumentsOwner = "32"

        oDraft.UserFields.Fields.Item("U_P3_Order").Value = ItemU_P3_Order.Text     '生產訂單
        oDraft.UserFields.Fields.Item("U_CarDr1").Value = U_CarDr1.Text
        oDraft.UserFields.Fields.Item("U_CarDr2").Value = U_CarDr2.Text
        oDraft.UserFields.Fields.Item("U_CarDr3").Value = U_CarDr3.Text

        'ADD By Justin IN 2013.10.31 補充員購或EC的表單內容
        If Source = "Welfare" Then
            '備註
            oDraft.UserFields.Fields.Item("Comments").Value = "員購(福利社)"
        ElseIf Source = "EC" Then
            oDraft.UserFields.Fields.Item("U_ORDER2").Value = KEY
        End If

        'Key單者
        If cobOwner.SelectedIndex > -1 Then
            oDraft.DocumentsOwner = cobOwner.SelectedValue
        End If

        Dim Sql2 As String = ""
        '表身
        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("本次數量").Value > 0 Then

                Dim 計價單位 As DataGridViewComboBoxCell = DirectCast(DGV1.Rows(i).Cells("計價單位"), DataGridViewComboBoxCell)
                Dim 小單位 As DataGridViewComboBoxCell = DirectCast(DGV1.Rows(i).Cells("小單位"), DataGridViewComboBoxCell)


                Dim U_P7 As String = String.Empty

                Select Case 計價單位.Value
                    Case "庫存單位"
                        U_P7 = "0"
                    Case "KG"
                        U_P7 = "1"
                    Case "小單位"
                        U_P7 = "2"
                    Case "重整"
                        U_P7 = "3"
                End Select

                '取得小單位對應的FldValue
               

                Dim U_P6ID As String = String.Empty
                Dim oDT As DataTable = New DataTable

                Sql2 = " SELECT Top 1 T0.[FldValue], T0.[Descr] FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' AND T0.[Descr]='" + Convert.ToString(小單位.Value) + "'"
                SQLCmd.CommandText = Sql2

                DataAdapterDGV = New SqlDataAdapter(Sql2, DBConn)
                DataAdapterDGV.Fill(oDT)

                '判斷是否重設流水號
                If oDT.Rows.Count > 0 Then
                    U_P6ID = Convert.ToString(oDT.Rows(0).Item("FldValue"))
                Else
                    U_P6ID = "0"
                End If


                oDraft.Lines.SetCurrentLine(X)
                oDraft.Lines.ItemCode = DGV1.Rows(i).Cells("ItemCode").Value '項目號碼
                oDraft.Lines.Quantity = DGV1.Rows(i).Cells("本次數量").Value '銷售數量

                oDraft.Lines.UserFields.Fields.Item("U_P3").Value = DGV1.Rows(i).Cells("U_P3").Value        '是否生產
                oDraft.Lines.UserFields.Fields.Item("U_P4").Value = Convert.ToString(Convert.ToDouble(DGV1.Rows(i).Cells("U_P4").Value) * Convert.ToDouble(DGV1.Rows(i).Cells("本次數量").Value))   '小單位總數
                oDraft.Lines.UserFields.Fields.Item("U_P6").Value = U_P6ID      '小單位
                oDraft.Lines.UserFields.Fields.Item("U_P7").Value = U_P7       '計價單位
                oDraft.Lines.UserFields.Fields.Item("U_P8").Value = Val(DGV1.Rows(i).Cells("U_P8").Value)   '銷售單價
                oDraft.Lines.UserFields.Fields.Item("U_P3_Quantity").Value = Convert.ToString(Convert.ToDouble(DGV1.Rows(i).Cells("U_P4").Value) * Convert.ToDouble(DGV1.Rows(i).Cells("本次數量").Value))    '生產數量

                Select Case U_P7
                    Case "0"
                        oDraft.Lines.UnitPrice = DGV1.Rows(i).Cells("U_P8").Value
                    Case "1"
                        oDraft.Lines.UnitPrice = 0
                    Case "2"
                        oDraft.Lines.UnitPrice = (Val(DGV1.Rows(i).Cells("U_P8").Value) * (DGV1.Rows(i).Cells("U_P4").Value * DGV1.Rows(i).Cells("本次數量").Value)) / DGV1.Rows(i).Cells("本次數量").Value
                End Select

               

                oDraft.Lines.Add()
                X = X + 1
            End If

        Next
        RetVal = oDraft.Add

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        Dim OQUTDocNum As Integer
        OQUTDocNum = Login.oCompany.GetNewObjectKey()

        '回寫至福利社資料表
        '連線
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim Sql As String = ""
        Try

            '===========================================修改資料庫作業Begin===============================================

            '修改主Table
            Select Case Source
                Case "Welfare"
                    For i As Integer = 0 To DGV1.RowCount - 1
                        Sql += " UPDATE [KS_Z_Welfare] SET [State]= '3', [OQUTDocNum]='" + Convert.ToString(OQUTDocNum) + "'  WHERE Convert(Varchar, AddDate, 111)='" + KEY + "' AND State='2' AND ProCode='" + DGV1.Rows(i).Cells("ItemCode").Value + "' "
                    Next

                Case "EC"
                    For i As Integer = 0 To DGV1.RowCount - 1
                        Sql += " UPDATE EC SET [State]= '1', [OQUTDocNum]='" + Convert.ToString(OQUTDocNum) + "', EC.AlterDate=getdate(), EC.AlterUser='" + Login.LogonUserName + "' From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] EC INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON E.ID=EC.ID  WHERE  Convert(Varchar, AddDate, 111) ='" + KEY + "' AND State='0'   AND AtttibuteType='" + strAtttibuteType + "' AND E.OrderType='" + strOrderType + "'"
                    Next

            End Select

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = Sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新資料失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '===========================================修改資料庫作業END===============================================



        MsgBox("新增至B1完成!!" + vbCrLf + "草稿單號：" & OQUTDocNum, 64, "完成")

        A_Welfare_List.MdiParent = MainForm
        A_Welfare_List.Show()

        If Source = "EC" Then
            OrderGet_PrintReport()
        End If

        Me.Close()

    End Sub

    Private Sub SelectItemU_P6cob()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = " SELECT T0.[FldValue], T0.[Descr] FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' Order by T0.[IndexID] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ItemU_P6cob.DataSource = ksSelectDataSet.Tables("DT1")
        ItemU_P6cob.DisplayMember = "Descr"
        'ItemU_P6cob.ValueMember = "FldValue"


    End Sub

    Private Sub SelectOwner()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.[empID], T0.[lastName] FROM OHEM T0 WHERE T0.[dept] ='5' and T0.[status] = '1' and T0.[position] NOT IN ('20') "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksSelectDataSet, "DT1")

        cobOwner.DataSource = ksSelectDataSet.Tables("DT1")
        cobOwner.DisplayMember = "lastName"
        cobOwner.ValueMember = "empID"
        cobOwner.SelectedIndex = -1

    End Sub

    Private Sub SelectU_CarDr()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = " SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號',T1.[roleID] FROM [OHEM] T0  INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            DataAdapter = New SqlDataAdapter(sql, DBConn)
            DataAdapter.Fill(ksSelectDataSet, "UC1")
            DataAdapter.Fill(ksSelectDataSet, "UC2")
            DataAdapter.Fill(ksSelectDataSet, "UC3")

            U_CarDr1.DataSource = ksSelectDataSet.Tables("UC1")
            U_CarDr1.DisplayMember = "司機"

            U_CarDr2.DataSource = ksSelectDataSet.Tables("UC2")
            U_CarDr2.DisplayMember = "司機"

            U_CarDr3.DataSource = ksSelectDataSet.Tables("UC3")
            U_CarDr3.DisplayMember = "司機"

            U_CarDr1.SelectedIndex = -1
            U_CarDr2.SelectedIndex = -1
            U_CarDr3.SelectedIndex = -1
        End Using
        'AddHandler U_CarDr1.SelectedIndexChanged, AddressOf U_CarDr1_SelectedIndexChanged
        'AddHandler U_CarDr2.SelectedIndexChanged, AddressOf U_CarDr2_SelectedIndexChanged
        'AddHandler U_CarDr3.SelectedIndexChanged, AddressOf U_CarDr3_SelectedIndexChanged

    End Sub

    'Private Sub OrderPicking_PrintReport()

    '    Dim NewMDIChild As New A_ReportViewer
    '    NewMDIChild.MdiParent = MainForm
    '    NewMDIChild.Source = "EC"

    '    If DGV3.Rows.Count > 0 Then
    '        NewMDIChild.strPara(0) = DGV3.Rows(0).Cells("訂單編號").Value
    '        NewMDIChild.strPara(1) = CommentsTxt.Text '營業下的備註
    '    Else
    '        NewMDIChild.strPara(0) = ""
    '        NewMDIChild.strPara(1) = ""
    '    End If

    '    If DGV1.Rows.Count > 0 Then
    '        NewMDIChild.strPara(2) = DGV1.Rows(0).Cells("AtttibuteType").Value
    '    Else
    '        NewMDIChild.strPara(2) = ""
    '    End If

    '    NewMDIChild.dt = ks1DataSetDGV.Tables("DT1")
    '    NewMDIChild.Show()

    'End Sub

    'Private Sub Order_PrintReport()
    '    A_ReportViewer.MdiParent = MainForm
    '    A_ReportViewer.Source = "EC_Order"

    '    If DGV3.Rows.Count > 0 Then
    '        A_ReportViewer.strPara(0) = DGV3.Rows(0).Cells("訂單編號").Value
    '        A_ReportViewer.strPara(1) = DGV3.Rows(0).Cells("訂單備註").Value
    '        A_ReportViewer.strPara(2) = Convert.ToString(DGV3.Rows(0).Cells("送貨取件姓名").Value).Substring(0, 1) + " * * "
    '    Else
    '        A_ReportViewer.strPara(0) = ""
    '        A_ReportViewer.strPara(1) = ""
    '        A_ReportViewer.strPara(2) = ""
    '    End If

    '    If DGV1.Rows.Count > 0 Then
    '        A_ReportViewer.strPara(3) = DGV1.Rows(0).Cells("AtttibuteType").Value
    '    Else
    '        A_ReportViewer.strPara(3) = ""
    '    End If

    '    A_ReportViewer.dt = ks1DataSetDGV.Tables("DT3")
    '    A_ReportViewer.Show()

    'End Sub

    Private Sub OrderGet_PrintReport()

        Dim NewMDIChild As New A_ReportViewer
        NewMDIChild.MdiParent = MainForm
        NewMDIChild.Source = "EC_Get"

        If DGV3.Rows.Count > 0 Then
            NewMDIChild.strPara(0) = KEY
            NewMDIChild.strPara(1) = strOrderSource
            NewMDIChild.strPara(3) = CommentsTxt.Text '營業下的備註
        Else
            NewMDIChild.strPara(0) = ""
            NewMDIChild.strPara(1) = ""
            NewMDIChild.strPara(3) = ""
        End If

        If DGV1.Rows.Count > 0 Then
            NewMDIChild.strPara(2) = DGV1.Rows(0).Cells("AtttibuteType").Value
        Else
            NewMDIChild.strPara(2) = ""
        End If

        NewMDIChild.dt = ks1DataSetDGV.Tables("DT1")
        NewMDIChild.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OrderGet_PrintReport()
    End Sub
End Class