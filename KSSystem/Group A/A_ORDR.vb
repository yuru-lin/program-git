Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_ORDR
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Dim T1新增CB As String = "Y"


    Private Sub A_ORDR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        CardCode.Focus()
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If

        ItemU_P3cob.SelectedIndex = 1      '是否生產 預設 = 否
        ItemU_P7cob.SelectedIndex = 1      '計價單位 預設 = KG
        'ItemU_P6cob.SelectedIndex = 0      '小單位   預設 = X
        ItemU_P3_Order.SelectedIndex = 1   '生產訂單 預設 = 否


        SelectItemU_P6cob()
        SelectU_CarDr()
        SelectFixedCustList()
        SelectOwner()
    End Sub

    Private Sub CardCodet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardCode.LostFocus
        SelectCardCode()
        If DGV1.RowCount > 0 Then
            ClearAll()
        End If
    End Sub

    Private Sub CardName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardName.LostFocus
        SelectCardName()
        If DGV1.RowCount > 0 Then
            ClearAll()
        End If
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
    'Private Sub U_P8Txtt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles U_P8Txt.LostFocus
    '    SelectU_P8()

    'End Sub

    Private Sub ClearAll()

        CardName.Text = ""
        CardCode.Text = ""
        CommentsTxt.Text = ""
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        ItemU_P4Txt.Text = 0
        ItemU_P8Txt.Text = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
        U_CarDr1.SelectedIndex = -1
        U_CarDr2.SelectedIndex = -1
        U_CarDr3.SelectedIndex = -1
        ItemU_P3_Order.SelectedIndex = 1
        FixedCust.SelectedIndex = -1



        'U_P8Txt.Text = ""
        'ks1DataSetDGV.Tables("DT1").Clear()
    End Sub

    Private Sub SelectCardCode()

        If CardCode.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'C' and [CardCode] = '" & CardCode.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無此人", 16, "錯誤")
                CardName.Text = ""
                CardCode.Text = ""
                CardCode.Focus()
            Else
                CardName.Text = sqlReader.Item("CardName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

    End Sub

    Private Sub SelectCardName()

        If CardName.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'C' and [CardName] = '" & CardName.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectName.getCardName = CardName.Text
                SelectName.getCardCode = CardCode.Text
                SelectName.Source = "ORDR"
                SelectName.MdiParent = MainForm
                SelectName.Show()
            Else
                CardCode.Text = sqlReader.Item("CardCode")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
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

            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"
            'sql = " SELECT T0.[ItemCode], T0.ItemName, ISNULL(T1.U_P8,0) AS 'U_P82' FROM [OITM] T0 LEFT JOIN (SELECT TOP 1 Z0.[DocEntry], Z0.[ItemCode], Z0.[U_P8] FROM [INV1] Z0 INNER JOIN [OINV] Z1 ON Z0.[DocEntry] = Z1.[DocNum] WHERE Z1.[CardCode] = '" & CardCode.Text & "' AND Z0.[ItemCode] = '" + ItemCodeTxt.Text + "'  ORDER BY 1 DESC ) T1 ON T0.[ItemCode] = T1.ItemCode WHERE T0.[ItemCode] = '" + ItemCodeTxt.Text + "' AND left(T0.[ItemCode],2) = '25' AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') "


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
            sql = "SELECT [ItemCode]  FROM [OITM] WHERE [ItemName] = '" & ItemNameTxt.Text & "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

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

    Private Sub 載入雞種_初始化()
        If ks1DataSetDGV.Tables.Contains("庫存單位") Then : ks1DataSetDGV.Tables("庫存單位").Clear() : End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Try
            SQLCmd.CommandText = "    SELECT T0.[FldValue] AS 'U_P7' ,T0.[Descr] AS '庫存單位' FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '10' ORDER BY 1 "
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "庫存單位")
            If ks1DataSetDGV.Tables("庫存單位").Rows.Count > 0 Then
                '雞種s.DataSource = DataSetDGV.Tables("雞種代號sALL")
                '雞種s.DisplayMember = "雞種"
                '雞種s.SelectedIndex = -1

            Else

                MsgBox("無庫存單位資料")
            End If
        Catch ex As Exception
            MsgBox("載入庫存單位: " & ex.Message)
            Exit Sub
        End Try
    End Sub


    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        If CardCode.Text = "" Then
            MsgBox("客戶編號未填!", 16, "錯誤")
            CardCode.Focus()
            Exit Sub
        End If
        If CardName.Text = "" Then
            MsgBox("客戶名稱未填!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If
        作業01_派單新增_單據查詢()
        'If DGV1.RowCount > 0 Then
        '    ks1DataSetDGV.Tables("DT1").Clear()
        'End If

        'Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'Using TransactionMonitor As New System.Transactions.TransactionScope

        '    'sql = "SELECT distinct T1.[ItemCode], T1.[Dscription], '0' as '本次數量' FROM ODLN T0  INNER JOIN DLN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocStatus] = 'C' and  T0.[CardCode] = '" & CardCode.Text & "'"
        '    sql = "    SELECT Distinct T0.[ItemCode] AS 'ItemCode', T0.[Dscription] AS 'Dscription', T0.[U_P8] AS 'U_P8', T0.[U_P7] AS 'U_P7', T1.SalPackUn AS 'U_P4', T1.[OnHand] AS 'OnHand', '0' AS '本次數量', T1.SalPackMsr AS 'U_P6', 'N' AS 'U_P3', T3.[FldValue] AS 'U_P62' "
        '    sql += "     FROM [RDR1] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        '    sql += "                    INNER JOIN (SELECT TOP 10 T0.[DocNum] FROM [ORDR] T0 WHERE T0.[CardCode] = '" & CardCode.Text & "' ORDER BY 1 DESC) R0 ON R0.[DocNum] = T0.[DocEntry] "
        '    sql += "                    INNER JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] "
        '    sql += "    WHERE T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9'  "
        '    sql += " ORDER BY 1 "


        '    SQLCmd.Connection = DBConn
        '    SQLCmd.CommandText = sql

        '    DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        '    DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        '    DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        '    TransactionMonitor.Complete()
        'End Using

        'If T1新增CB = "Y" Then
        '    載入雞種_初始化()
        '    Dim combo As New DataGridViewComboBoxColumn
        '    combo.DataSource = ks1DataSetDGV.Tables("庫存單位")
        '    combo.DataPropertyName = "U_P7"
        '    combo.DisplayMember = "庫存單位"
        '    combo.ValueMember = "U_P7"
        '    combo.HeaderText = "庫存單位"
        '    combo.Width = 200
        '    DGV1.Columns.Insert(7, combo)
        '    DGV1.Columns.Add(combo)
        '    T1新增CB = "N"
        'End If






        'DGV1Display()

    End Sub

    Private Sub 作業01_派單新增_單據查詢()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("DT1").Clear() : End If '清除DT1資料
        Dim sql As String = ""

        sql = "    SELECT Distinct T0.[ItemCode] AS 'ItemCode', T0.[Dscription] AS 'Dscription', T0.[U_P8] AS 'U_P8', T0.[U_P7] AS 'U_P7', T1.SalPackUn AS 'U_P4', T1.[OnHand] AS 'OnHand', '0' AS '本次數量', T1.SalPackMsr AS 'U_P6', 'N' AS 'U_P3', T3.[FldValue] AS 'U_P62' "
        sql += "     FROM [RDR1] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        sql += "                    INNER JOIN (SELECT TOP 10 T0.[DocNum] FROM [ORDR] T0 WHERE T0.[CardCode] = '" & CardCode.Text & "' ORDER BY 1 DESC) R0 ON R0.[DocNum] = T0.[DocEntry] "
        sql += "                    INNER JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] "
        sql += "    WHERE T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9'  "
        sql += " ORDER BY 1 "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = sql : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")

            DGV1Display()


            If T1新增CB = "Y" Then
                載入雞種_初始化()
                Dim combo As New DataGridViewComboBoxColumn
                combo.DataSource = ks1DataSetDGV.Tables("庫存單位")
                combo.DataPropertyName = "U_P7"
                combo.DisplayMember = "庫存單位"
                combo.ValueMember = "U_P7"
                combo.HeaderText = "庫存單位"
                combo.Width = 100
                DGV1.Columns.Insert(5, combo)
                DGV1.Columns.Add(combo)
                T1新增CB = "N"
            End If




        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        ''Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'Using TransactionMonitor As New System.Transactions.TransactionScope

        '    'sql = "SELECT distinct T1.[ItemCode], T1.[Dscription], '0' as '本次數量' FROM ODLN T0  INNER JOIN DLN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocStatus] = 'C' and  T0.[CardCode] = '" & CardCode.Text & "'"
        '    sql = "    SELECT Distinct T0.[ItemCode] AS 'ItemCode', T0.[Dscription] AS 'Dscription', T0.[U_P8] AS 'U_P8', T0.[U_P7] AS 'U_P7', T1.SalPackUn AS 'U_P4', T1.[OnHand] AS 'OnHand', '0' AS '本次數量', T1.SalPackMsr AS 'U_P6', 'N' AS 'U_P3', T3.[FldValue] AS 'U_P62' "
        '    sql += "     FROM [RDR1] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        '    sql += "                    INNER JOIN (SELECT TOP 10 T0.[DocNum] FROM [ORDR] T0 WHERE T0.[CardCode] = '" & CardCode.Text & "' ORDER BY 1 DESC) R0 ON R0.[DocNum] = T0.[DocEntry] "
        '    sql += "                    INNER JOIN [UFD1] T3 ON T1.[SalPackMsr] = T3.[Descr] "
        '    sql += "    WHERE T3.[TableID] = 'RDR1' AND T3.[FieldID] = '9'  "
        '    sql += " ORDER BY 1 "


        '    SQLCmd.Connection = DBConn
        '    SQLCmd.CommandText = sql

        '    DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        '    DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        '    DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        '    TransactionMonitor.Complete()
        'End Using

        'If T1新增CB = "Y" Then
        '    載入雞種_初始化()
        '    Dim combo As New DataGridViewComboBoxColumn
        '    combo.DataSource = ks1DataSetDGV.Tables("庫存單位")
        '    combo.DataPropertyName = "U_P7"
        '    combo.DisplayMember = "庫存單位"
        '    combo.ValueMember = "U_P7"
        '    combo.HeaderText = "庫存單位"
        '    combo.Width = 200
        '    DGV1.Columns.Insert(7, combo)
        '    DGV1.Columns.Add(combo)
        '    T1新增CB = "N"
        'End If









        'If T1DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV1").Clear() : End If '清除T1DGV1資料
        'Dim SQLADD As String = ""

        ''SQLADD = "     SELECT [PW00] AS '單號', [PW01] AS '日期', [PW05] AS '樓層', [PW06] AS '人數', [PW0ID] AS 'ID' FROM [KaiShingPlug].[dbo].[PB_PieceWork00] "
        'SQLADD = "     SELECT [PW00] AS '單號', [PW01] AS '日期', [PW05] AS '樓層', [PW06] AS '人數', [PW0ID] AS 'ID', '0' AS '代號' FROM [KaiShingPlug].[dbo].[PB_PieceWork00] "
        'SQLADD += "     WHERE [PW90] = 'Y' AND [PW91] = 'N' AND [PW05] = '" & La作業樓層.Text & "' ORDER BY 2 ,1 "

        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand

        'Try
        '    SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
        '    SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        '    DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        '    DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV1")
        '    T1DGV1.DataSource = ks1DataSetDGV.Tables("T1DGV1")
        '    If T1新增CB = "Y" Then
        '        'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        '        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        '        checkBoxColumn.Name = "選擇"
        '        checkBoxColumn.Width = 30
        '        T1DGV1.Columns.Insert(0, checkBoxColumn)
        '        '---測試
        '        'Dim column As New DataGridViewComboBoxColumn()
        '        'column.Name = "下拉"
        '        'T1DGV1.Columns.Insert(6, checkBoxColumn2)
        '        ''Dim col2 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        '        ''col2.HeaderText = "下拉"
        '        ''T1DGV1.Columns.Insert(1, col2)
        '        ''T1DGV1.Columns.Add(col2)
        '        'checkBoxColumn2.Items.Add(21)
        '        'checkBoxColumn2.Items.Add(22)
        '        載入雞種_初始化()
        '        ' ''    'Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
        '        Dim combo As New DataGridViewComboBoxColumn
        '        combo.DataSource = ks1DataSetDGV.Tables("雞種代號sALL")
        '        combo.DataPropertyName = "代號"
        '        combo.DisplayMember = "雞種"
        '        combo.ValueMember = "代號"
        '        combo.HeaderText = "雞種"
        '        combo.Width = 200
        '        T1DGV1.Columns.Insert(7, combo)
        '        T1DGV1.Columns.Add(combo)
        '        ' ''    '---
        '    End If
        '    作業01_派單新增_單據查詢_Play()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub



    'DGV2
    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn2.Click

        'If CardCode.Text = "" Then
        '    MsgBox("客戶編號未填!", 16, "錯誤")
        '    CardCode.Focus()
        '    Exit Sub
        'End If
        'If CardName.Text = "" Then
        '    MsgBox("客戶名稱未填!", 16, "錯誤")
        '    CardName.Focus()
        '    Exit Sub
        'End If

        If DGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "SELECT distinct T1.[ItemCode], T1.[Dscription], '0' as '本次數量' FROM ODLN T0  INNER JOIN DLN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocStatus] = 'C' and  T0.[CardCode] = '" & CardCode.Text & "'"
            'sql = " SELECT Distinct T0.[ItemCode] AS 'ItemCode', T0.[Dscription] AS 'Dscription', T0.[U_P8] AS 'U_P8', T0.[U_P7] AS 'U_P7', T1.SalPackUn AS 'U_P6', T1.[OnHand] AS 'OnHand', '0' AS '本次數量' FROM [RDR1] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] INNER JOIN (SELECT TOP 10 T0.[DocNum] FROM [ORDR] T0 WHERE T0.[CardCode] = '" & TextBox2.Text & "' ORDER BY 1 DESC) R0 ON R0.[DocNum] = T0.[DocEntry] ORDER BY 1"
            sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.ItemName AS 'Dscription', T0.[OnHand], T0.SalPackUn AS 'U_P4', T0.SalPackMsr AS 'U_P6' FROM [OITM] T0 WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') AND T0.[ItemName] Not Like '%XXX%' AND  T0.[ItemName] Not Like '%領改%' AND T0.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[ItemName] Like '%" & TextBox2.Text & "%'  AND T0.[ItemName] Like '%" & TextBox3.Text & "%' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "DT1")

            DGV2.DataSource = ks2DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV2Display()

    End Sub


    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            'For Each column2 As DataGridViewComboBoxColumn In DGV1.Columns
            column.Visible = True
            'column2.Visible = True

            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "產品編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "Dscription"
                    column.HeaderText = "產品名稱"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "U_P8"
                    column.HeaderText = "單價"
                    column.DisplayIndex = 2
                    'column.ReadOnly = True
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.DefaultCellStyle.Format = "#0.0000"
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.DefaultCellStyle.Format = "#0.##"
                Case "本次數量"
                    column.HeaderText = " 訂購數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Case "U_P7"
                    column.HeaderText = "計價單位2"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.Visible = False
                    'column2.HeaderText = "計價單位"
                    'column2.DisplayIndex = 5
                    'column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    'column2.C = DataGridViewComboBoxColumn
                Case "U_P4"
                    column.HeaderText = "小單位數量"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                    column.DefaultCellStyle.Format = "#0.##"
                Case "U_P6"
                    column.HeaderText = "小單位"   '中文
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case "U_P62"
                    column.HeaderText = "小單位2"   '
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                    column.Visible = False
                Case "U_P3"
                    column.HeaderText = "是否生產"
                    column.DisplayIndex = 9
                    'column.ReadOnly = True


                Case Else



                    column.Visible = False
            End Select
        Next
        'Next
        DGV1.AutoResizeColumns()

    End Sub
    'DGV2Display
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

    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("未有銷售資料!", 16, "錯誤")
            Exit Sub
        End If

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

            'sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "'"
            sql = " SELECT T0.[ItemCode], T0.ItemName, ISNULL(T1.U_P8,0) AS 'U_P82' FROM [OITM] T0 LEFT JOIN (SELECT TOP 1 Z0.[DocEntry], Z0.[ItemCode], Z0.[U_P8] FROM [INV1] Z0 INNER JOIN [OINV] Z1 ON Z0.[DocEntry] = Z1.[DocNum] WHERE Z1.[CardCode] = '" & CardCode.Text & "' AND Z0.[ItemCode] = '" + ItemCodeTxt.Text + "'  ORDER BY 1 DESC ) T1 ON T0.[ItemCode] = T1.ItemCode WHERE T0.[ItemCode] = '" + ItemCodeTxt.Text + "' "

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

            'Row.Item("U_P82") = ItemU_P82Txt.Text
            Row.Item("本次數量") = Quantity.Text

            ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

            ItemCodeTxt.Text = ""
            ItemNameTxt.Text = ""
            ItemU_P4Txt.Text = 0
            ItemU_P8Txt.Text = 0
            ItemU_P7cob.SelectedIndex = 1
            Quantity.Text = 0


            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click


        If DGV1.RowCount <= 0 Then
            MsgBox("無銷售資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim Cnt As Integer = 0
        For j As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(j).Cells("本次數量").Value > 0 Then
                Cnt = Cnt + 1
            End If
        Next

        If Cnt = 0 Then
            MsgBox("銷售數量為0!", 16, "錯誤")
            Exit Sub
        End If

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

        '回存銷售訂單正式--起
        oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oOrders)
        '回存銷售訂單正式--止

        ''回存銷售訂單草稿--起
        'oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        'oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oOrders
        ''回存銷售訂單草稿--止

        oDraft.CardCode = CardCode.Text
        oDraft.DocDueDate = DocDueDate.Value.Date

        oDraft.Comments = Now & " 接單者：" & vbCrLf & CommentsTxt.Text

        oDraft.UserFields.Fields.Item("U_P3_Order").Value = ItemU_P3_Order.Text     '生產訂單
        oDraft.UserFields.Fields.Item("U_CarDr1").Value = U_CarDr1.Text
        oDraft.UserFields.Fields.Item("U_CarDr2").Value = U_CarDr2.Text
        oDraft.UserFields.Fields.Item("U_CarDr3").Value = U_CarDr3.Text

        If cobOwner.SelectedIndex > -1 Then
            oDraft.DocumentsOwner = cobOwner.SelectedValue
        End If

        '表身
        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("本次數量").Value > 0 Then
                oDraft.Lines.SetCurrentLine(X)
                oDraft.Lines.ItemCode = DGV1.Rows(i).Cells("ItemCode").Value '項目號碼
                oDraft.Lines.Quantity = DGV1.Rows(i).Cells("本次數量").Value '銷售數量

                'U_P8 = Val(DGV1.Rows(i).Cells("U_P8").Value)
                'MsgBox("U_P8=" & U_P8.ToString & "U_P8.LENGTH=" & U_P8.ToString.Length.ToString, 36, "XX")

                'Select Case DGV1.Rows(i).Cells("U_P3").Value        '是否生產
                '    Case "N"
                '        oDraft.Lines.UserFields.Fields.Item("U_P3").Value = "N"
                '    Case "Y"
                '        oDraft.Lines.UserFields.Fields.Item("U_P3").Value = "Y"
                'End Select

                oDraft.Lines.UserFields.Fields.Item("U_P3").Value = DGV1.Rows(i).Cells("U_P3").Value        '是否生產
                oDraft.Lines.UserFields.Fields.Item("U_P4").Value = (DGV1.Rows(i).Cells("U_P4").Value * DGV1.Rows(i).Cells("本次數量").Value)   '小單位總數
                oDraft.Lines.UserFields.Fields.Item("U_P6").Value = DGV1.Rows(i).Cells("U_P62").Value       '小單位
                oDraft.Lines.UserFields.Fields.Item("U_P7").Value = DGV1.Rows(i).Cells("U_P7").Value        '計價單位
                oDraft.Lines.UserFields.Fields.Item("U_P8").Value = Val(DGV1.Rows(i).Cells("U_P8").Value)   '銷售單價
                oDraft.Lines.UserFields.Fields.Item("U_P3_Quantity").Value = (DGV1.Rows(i).Cells("U_P4").Value * DGV1.Rows(i).Cells("本次數量").Value)    '生產數量

                Select Case DGV1.Rows(i).Cells("U_P7").Value
                    Case "0"
                        oDraft.Lines.UnitPrice = DGV1.Rows(i).Cells("U_P8").Value
                    Case "1"
                        oDraft.Lines.UnitPrice = 0
                    Case "2"
                        'U_P62 = (DGV1.Rows(i).Cells("U_P6").Value * DGV1.Rows(i).Cells("本次數量").Value)
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
            ClearAll()
            Exit Sub
        End If

        Dim OQUTDocNum As Integer
        OQUTDocNum = Login.oCompany.GetNewObjectKey()
        MsgBox("新增至B1完成!!" + vbCrLf + "草稿單號：" & OQUTDocNum, 64, "完成")


        ClearAll()
    End Sub




    Private Sub SelectFixedCustList()
        Dim DataAdapter1 As SqlDataAdapter
        Dim DS As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer
        Using TransactionMonitor As New System.Transactions.TransactionScope
            'sql = "SELECT [U_CardCode],[U_CardName],[U_AddID] FROM [@FIXEDCUST]"
            sql = "SELECT [U_CardCode],[U_CardName] FROM [@FIXEDCUST]"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(DS, "DT1")

            FixedCust.DataSource = DS.Tables("DT1")
            FixedCust.DisplayMember = "U_CardName"
            FixedCust.ValueMember = "U_CardCode"
            FixedCust.SelectedIndex = -1

            TransactionMonitor.Complete()
        End Using
        AddHandler FixedCust.SelectedIndexChanged, AddressOf FixedCust_SelectedIndexChanged


    End Sub

    Private Sub FixedCust_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [U_CardCode],[U_CardName] FROM [@FIXEDCUST] WHERE [U_CardCode] = '" & FixedCust.SelectedValue & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
            Else
                CardCode.Text = sqlReader.Item("U_CardCode")
                CardName.Text = sqlReader.Item("U_CardName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
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

    'Private Sub U_CarDr1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim sql As String
    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Dim sqlReader As SqlDataReader
    '    Using TransactionMonitor As New System.Transactions.TransactionScope
    '        'sql = "SELECT [U_CardCode],[U_CardName],[U_AddID] FROM [@FIXEDCUST] WHERE [U_CardCode] = '" & FixedCust.SelectedValue & "'"
    '        'sql = " SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號',T1.[roleID] FROM [OHEM] T0  INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y' AND T0.[lastName] = '" & U_CarDr1.Text & "'"
    '        sql = " SELECT * FROM (SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號', T1.[roleID] FROM [OHEM] T0 INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y') T0 WHERE T0.司機 = '" & U_CarDr1.Text & "' "

    '        SQLCmd.Connection = DBConn
    '        SQLCmd.CommandText = sql

    '        sqlReader = SQLCmd.ExecuteReader
    '        sqlReader.Read()

    '        If Not sqlReader.HasRows() Then
    '            sqlReader.Close()
    '        Else
    '            U_CarDr1Txt.Text = sqlReader.Item("編號")
    '            'CardName.Text = sqlReader.Item("U_CardName")
    '            sqlReader.Close()
    '        End If

    '        If sqlReader.IsClosed = False Then
    '            sqlReader.Close()
    '        End If
    '        TransactionMonitor.Complete()
    '    End Using

    'End Sub

    'Private Sub U_CarDr2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim sql As String
    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Dim sqlReader As SqlDataReader
    '    Using TransactionMonitor As New System.Transactions.TransactionScope
    '        'sql = "SELECT [U_CardCode],[U_CardName],[U_AddID] FROM [@FIXEDCUST] WHERE [U_CardCode] = '" & FixedCust.SelectedValue & "'"
    '        'sql = " SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號',T1.[roleID] FROM [OHEM] T0  INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y' AND T0.[lastName] = '" & U_CarDr1.Text & "'"
    '        sql = " SELECT * FROM (SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號', T1.[roleID] FROM [OHEM] T0 INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y') T0 WHERE T0.司機 = '" & U_CarDr2.Text & "' "

    '        SQLCmd.Connection = DBConn
    '        SQLCmd.CommandText = sql

    '        sqlReader = SQLCmd.ExecuteReader
    '        sqlReader.Read()

    '        If Not sqlReader.HasRows() Then
    '            sqlReader.Close()
    '        Else
    '            U_CarDr2Txt.Text = sqlReader.Item("編號")
    '            'CardName.Text = sqlReader.Item("U_CardName")
    '            sqlReader.Close()
    '        End If

    '        If sqlReader.IsClosed = False Then
    '            sqlReader.Close()
    '        End If
    '        TransactionMonitor.Complete()
    '    End Using

    'End Sub

    'Private Sub U_CarDr3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim sql As String
    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Dim sqlReader As SqlDataReader
    '    Using TransactionMonitor As New System.Transactions.TransactionScope
    '        'sql = "SELECT [U_CardCode],[U_CardName],[U_AddID] FROM [@FIXEDCUST] WHERE [U_CardCode] = '" & FixedCust.SelectedValue & "'"
    '        'sql = " SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號',T1.[roleID] FROM [OHEM] T0  INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y' AND T0.[lastName] = '" & U_CarDr1.Text & "'"
    '        sql = " SELECT * FROM (SELECT T0.[lastName] AS '司機', Cast(T0.EMPID as nvarchar(10)) AS '編號', T1.[roleID] FROM [OHEM] T0 INNER JOIN HEM6 T1 ON T0.empID = T1.empID  WHERE T1.[roleID]=1 and T0.status=1 UNION ALL SELECT T0.cardname, T0.cardcode, T0.lictradnum FROM [OCRD] T0 WHERE T0.QryGroup20='Y') T0 WHERE T0.司機 = '" & U_CarDr3.Text & "' "

    '        SQLCmd.Connection = DBConn
    '        SQLCmd.CommandText = sql

    '        sqlReader = SQLCmd.ExecuteReader
    '        sqlReader.Read()

    '        If Not sqlReader.HasRows() Then
    '            sqlReader.Close()
    '        Else
    '            U_CarDr3Txt.Text = sqlReader.Item("編號")
    '            'CardName.Text = sqlReader.Item("U_CardName")
    '            sqlReader.Close()
    '        End If

    '        If sqlReader.IsClosed = False Then
    '            sqlReader.Close()
    '        End If
    '        TransactionMonitor.Complete()
    '    End Using

    'End Sub


    Private Sub FixedCust_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedCust.SelectedIndexChanged

    End Sub
End Class