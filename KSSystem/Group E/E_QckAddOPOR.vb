Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class E_QckAddOPOR
    Dim ksDataSet As DataSet = New DataSet
    Dim dsPDAIn As New DataTable

    Private Sub E_QckAddOPOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If

        cobU_P7.SelectedIndex = 1
        cobU_Omoney.SelectedIndex = 2
        cobDateType.SelectedIndex = 0
        AddColumn()
        SelectOwner()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        QueryTransport()
    End Sub

    Private Sub QueryTransport()
        If DGV1.RowCount > 0 Then
            ksDataSet.Tables("DT1").Clear()
        End If      

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter

        sql = "exec L20111125 '" & dateDocDate.Value.Date & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ksDataSet, "DT1")

        DGV1.DataSource = ksDataSet.Tables("DT1")
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub CardCodet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardCode.LostFocus
        SelectCardCode()
   
    End Sub

    Private Sub CardName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardName.LostFocus
        SelectCardName()
      
    End Sub

    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()

    End Sub

    Private Sub ItemNameTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()

    End Sub

    Private Sub txtU_M1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU_M1.TextChanged
        CalcU_M5()

    End Sub

    Private Sub txtU_M2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU_M2.TextChanged
        CalcU_M5()

    End Sub

    Private Sub txtU_M4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU_M4.TextChanged
        CalcU_M5()

    End Sub

    Private Sub txtU_P2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU_P2.TextChanged
        CalcU_M5()
        CalcTotal()
    End Sub

    Private Sub txtU_P8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtU_P8.TextChanged
        CalcU_M5()
        CalcTotal()
    End Sub

    Private Sub cobDateType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobDateType.SelectedIndexChanged
        DateTypeChange()
    End Sub

    Private Sub DateTypeChange()
        Dim AddYear, AddMonth As Integer
        Select Case cobDateType.SelectedIndex
            Case 1
                dateDosDueDate.Value = dateDocDate.Value.AddDays(40)
            Case 2                
                AddYear = dateDocDate.Value.AddMonths(2).Year.ToString
                AddMonth = dateDocDate.Value.AddMonths(2).Month.ToString
                If dateDocDate.Value.Day <= 7 Then
                    Dim dateInMay As New DateTime(AddYear, AddMonth, 7)
                    dateDosDueDate.Value = dateInMay
                End If
                If dateDocDate.Value.Day > 7 And dateDocDate.Value.Day <= 17 Then
                    Dim dateInMay As New DateTime(AddYear, AddMonth, 17)
                    dateDosDueDate.Value = dateInMay
                End If
                If dateDocDate.Value.Day > 17 Then
                    Dim dateInMay As New DateTime(AddYear, AddMonth, 27)
                    dateDosDueDate.Value = dateInMay
                End If

            Case Else
                dateDosDueDate.Value = dateDocDate.Value
        End Select
    End Sub

    Private Sub SelectOwner()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.[empID], T0.[lastName] FROM OHEM T0 WHERE T0.[dept] ='13' and T0.[status] = '1'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksSelectDataSet, "DT1")

        cobOwner.DataSource = ksSelectDataSet.Tables("DT1")
        cobOwner.DisplayMember = "lastName"
        cobOwner.ValueMember = "empID"
        cobOwner.SelectedIndex = -1

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
            sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'S' and [CardCode] = '" & CardCode.Text & "'"

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

            sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'S' and [CardName] = '" & CardName.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectName.getCardName = CardName.Text
                SelectName.getCardCode = CardCode.Text
                SelectName.Source = "OPOR"
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

            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,4) = '2100'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "OPOR"
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
            sql = "SELECT [ItemCode]  FROM [OITM] WHERE [ItemName] = '" & ItemNameTxt.Text & "' and left(ItemCode,4) = '2100' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "OPOR"
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

    Private Sub CalcU_M5()
        Dim P2, M1, M2, M4, M5 As Double

        If txtU_P2.Text = "" Then
            P2 = 0
        Else
            P2 = CDbl(Trim(txtU_P2.Text))
        End If

        If txtU_M1.Text = "" Then
            M1 = 0
        Else
            M1 = CDbl(Trim(txtU_M1.Text))
        End If

        If txtU_M2.Text = "" Then
            M2 = 0
        Else
            M2 = CDbl(Trim(txtU_M2.Text))
        End If

        If txtU_M4.Text = "" Then
            M4 = 0
        Else
            M4 = CDbl(Trim(txtU_M4.Text))
        End If


        M5 = P2 * M1 + M2 + M4

        txtU_M5.Text = M5
    End Sub

    Private Sub CalcTotal()
        Dim P2, P8, M2, M4 As Double
        Dim Total As Integer

        If txtU_P2.Text = "" Then
            P2 = 0
        Else
            P2 = CDbl(Trim(txtU_P2.Text))
        End If

        If txtU_P8.Text = "" Then
            P8 = 0
        Else
            P8 = CDbl(Trim(txtU_P8.Text))
        End If

        If txtU_M2.Text = "" Then
            M2 = 0
        Else
            M2 = CDbl(Trim(txtU_M2.Text))
        End If

        If txtU_M4.Text = "" Then
            M4 = 0
        Else
            M4 = CDbl(Trim(txtU_M4.Text))
        End If

        '
        'Total = P2 * P8 + M2 + M4
        Total = P2 * P8

        txtTotal.Text = Total
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress

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

    Private Sub txtU_P2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_P2.KeyPress

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

    Private Sub txtU_P8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_P8.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 4 Then
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

    Private Sub txtU_M1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_M1.KeyPress

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

    Private Sub txtU_M2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_M2.KeyPress

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

    Private Sub txtU_M4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_M4.KeyPress

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

    Private Sub txtU_GetMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_GetMT.KeyPress

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

    Private Sub txtU_TpMoney_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtU_TpMoney.KeyPress

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

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        Select Case DGV1.CurrentRow.Cells("品名").Value
            Case "黃金雞", "黃金雞公", "黃金雞母"
                ItemCodeTxt.Text = "2100K00000002"

            Case "土雞", "土雞公", "土雞母"
                ItemCodeTxt.Text = "2100100000002"

            Case "烏骨雞", "烏骨雞公", "烏骨雞母"
                ItemCodeTxt.Text = "2100200000002"

            Case "人家土", "人家土公", "人家土母"
                ItemCodeTxt.Text = "2100400000002"

            Case "香草雞", "香草雞公", "香草雞母"
                ItemCodeTxt.Text = "2100P00000002"

            Case "古早雞", "古早雞公", "古早雞母"
                ItemCodeTxt.Text = "2100E00000003"

            Case "黑羽土", "黑羽土公", "黑羽土母"
                ItemCodeTxt.Text = "2100N00000002"

            Case "三黃雞", "三黃雞公", "三黃雞母"
                ItemCodeTxt.Text = "2100D00000002"

            Case "土種雞", "土種雞公", "土種雞母"
                ItemCodeTxt.Text = "2100500000002"

            Case "白露花"
                ItemCodeTxt.Text = "2100300000002"

            Case Else
                ItemCodeTxt.Text = ""
                ItemNameTxt.Text = ""
        End Select
        SelectItemCode()

        txtQuantity.Text = DGV1.CurrentRow.Cells("磅單羽數").Value
        txtU_P2.Text = DGV1.CurrentRow.Cells("磅單重").Value
        txtU_P8.Text = DGV1.CurrentRow.Cells("公斤單價").Value
        txtU_CK02.Text = DGV1.CurrentRow.Cells("製造單號").Value
        txtComments.Text = "(" & DGV1.CurrentRow.Cells("車牌號").Value & "-" & DGV1.CurrentRow.Cells("平均重").Value & ")"

        If DGV1.CurrentRow.Cells("來源").Value = "契養" Then
            CardName.Text = DGV1.CurrentRow.Cells("牧場名稱").Value
            txtU_Cnum.Text = DGV1.CurrentRow.Cells("牧場代號").Value
            SelectCardName()
        Else
            CardName.Text = ""
            CardCode.Text = ""
            txtU_Cnum.Text = ""
        End If
    End Sub

    '加入欄位
    Private Sub AddColumn()
        'declaring a column named Name
        Dim ItemCode As DataColumn = New DataColumn("存編")
        Dim ItemName As DataColumn = New DataColumn("品名")
        Dim Quantity As DataColumn = New DataColumn("數量")
        Dim U_P2 As DataColumn = New DataColumn("重量")
        Dim U_P8 As DataColumn = New DataColumn("未稅單價")
        Dim cobU_P7 As DataColumn = New DataColumn("計價單位")
        Dim Total As DataColumn = New DataColumn("總計")
        Dim cobU_Omoney As DataColumn = New DataColumn("付款方法")
        Dim U_M1 As DataColumn = New DataColumn("係數")
        Dim U_M2 As DataColumn = New DataColumn("過縣費")
        Dim U_M4 As DataColumn = New DataColumn("合車")
        Dim U_M5 As DataColumn = New DataColumn("運費")

        ItemCode.DataType = System.Type.GetType("System.String")
        ItemName.DataType = System.Type.GetType("System.String")
        Quantity.DataType = System.Type.GetType("System.Double")
        U_P2.DataType = System.Type.GetType("System.Double")
        U_P8.DataType = System.Type.GetType("System.Double")
        cobU_P7.DataType = System.Type.GetType("System.String")
        Total.DataType = System.Type.GetType("System.Double")
        cobU_Omoney.DataType = System.Type.GetType("System.String")
        U_M1.DataType = System.Type.GetType("System.Double")
        U_M2.DataType = System.Type.GetType("System.Double")
        U_M4.DataType = System.Type.GetType("System.Double")
        U_M5.DataType = System.Type.GetType("System.Double")

        dsPDAIn.Columns.Add(ItemCode)
        dsPDAIn.Columns.Add(ItemName)
        dsPDAIn.Columns.Add(Quantity)
        dsPDAIn.Columns.Add(U_P2)
        dsPDAIn.Columns.Add(U_P8)
        dsPDAIn.Columns.Add(cobU_P7)
        dsPDAIn.Columns.Add(Total)
        dsPDAIn.Columns.Add(cobU_Omoney)
        dsPDAIn.Columns.Add(U_M1)
        dsPDAIn.Columns.Add(U_M2)
        dsPDAIn.Columns.Add(U_M4)
        dsPDAIn.Columns.Add(U_M5)

    End Sub

    Private Sub btnAddToDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDetail.Click

        If ItemCodeTxt.Text = "" Then
            MsgBox("存編未填!", 16, "錯誤")
            Exit Sub
        End If

        AddItemDetail()
        CalcGetMT()

    End Sub

    Private Sub AddItemDetail()

        Dim Rows As DataRow
        Rows = dsPDAIn.NewRow

        Rows.Item("存編") = ItemCodeTxt.Text
        Rows.Item("品名") = ItemNameTxt.Text
        Rows.Item("數量") = txtQuantity.Text
        Rows.Item("重量") = txtU_P2.Text
        Rows.Item("未稅單價") = txtU_P8.Text
        Rows.Item("計價單位") = cobU_P7.SelectedIndex
        Rows.Item("總計") = txtTotal.Text
        Rows.Item("付款方法") = cobU_Omoney.SelectedIndex + 1
        Rows.Item("係數") = txtU_M1.Text
        Rows.Item("過縣費") = txtU_M2.Text
        Rows.Item("合車") = txtU_M4.Text
        Rows.Item("運費") = txtU_M5.Text
       
        dsPDAIn.Rows.Add(Rows)

        DGV2.DataSource = dsPDAIn
        DGV2.AutoResizeColumns()
        CleanBody2()
    End Sub

    Private Sub CleanBody2()
        'If DGV2.RowCount > 0 Then
        '    dsPDAIn.Clear()
        'End If
        txtU_M1.Text = 0
        txtU_M2.Text = 0
        txtU_M4.Text = 0
        'txtU_M5.Text = 0
    End Sub

    Private Sub CalcGetMT()
        If DGV2.RowCount <= 0 Then
            Exit Sub
        End If

        Dim TotalTpMoney As Integer = 0
        Dim TotalGetMT As Integer = 0

        For i As Integer = 0 To DGV2.RowCount - 1
            If DGV2.Rows(i).Cells("運費").Value > 0 Then
                TotalTpMoney = TotalTpMoney + DGV2.Rows(i).Cells("運費").Value
            Else
                TotalGetMT = TotalGetMT + DGV2.Rows(i).Cells("總計").Value
            End If
        Next

        txtU_GetMT.Text = TotalGetMT
        txtU_TpMoney.Text = TotalTpMoney
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If CardCode.Text = "" Then
            MsgBox("客編未填!", 16, "錯誤")
            Exit Sub
        End If

        If DGV2.RowCount <= 0 Then
            MsgBox("無項目!", 16, "錯誤")
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

        oDraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oPurchaseOrders

        oDraft.DocDate = dateDocDate.Value.Date
        oDraft.DocDueDate = dateDosDueDate.Value.Date

        oDraft.CardCode = CardCode.Text
        oDraft.Comments = txtComments.Text

        oDraft.UserFields.Fields.Item("U_CK02").Value = txtU_CK02.Text
        oDraft.UserFields.Fields.Item("U_Cnum").Value = txtU_Cnum.Text
        oDraft.UserFields.Fields.Item("U_GetMT").Value = txtU_GetMT.Text
        oDraft.UserFields.Fields.Item("U_TpMoney").Value = txtU_TpMoney.Text

        If cobOwner.SelectedIndex > -1 Then
            oDraft.DocumentsOwner = cobOwner.SelectedValue
        End If

        For i As Integer = 0 To DGV2.RowCount - 1

            oDraft.Lines.SetCurrentLine(i)
            oDraft.Lines.ItemCode = DGV2.Rows(i).Cells("存編").FormattedValue   '項目號碼
            oDraft.Lines.Quantity = DGV2.Rows(i).Cells("數量").FormattedValue

            oDraft.Lines.UserFields.Fields.Item("U_p2").Value = DGV2.Rows(i).Cells("重量").FormattedValue
            oDraft.Lines.UserFields.Fields.Item("U_P8").Value = DGV2.Rows(i).Cells("未稅單價").FormattedValue
            oDraft.Lines.UserFields.Fields.Item("U_P7").Value = DGV2.Rows(i).Cells("計價單位").FormattedValue


            Select Case DGV2.Rows(i).Cells("計價單位").Value
                Case "0"                    
                    oDraft.Lines.UnitPrice = DGV2.Rows(i).Cells("未稅單價").Value
                Case "1"                    
                    'oDraft.Lines.UnitPrice = ((DGV2.Rows(i).Cells("未稅單價").Value * DGV2.Rows(i).Cells("重量").FormattedValue) + DGV2.Rows(i).Cells("過縣費").FormattedValue + DGV2.Rows(i).Cells("合車").FormattedValue) / DGV2.Rows(i).Cells("數量").Value
                    oDraft.Lines.UnitPrice = (DGV2.Rows(i).Cells("未稅單價").Value * DGV2.Rows(i).Cells("重量").FormattedValue) / DGV2.Rows(i).Cells("數量").Value

            End Select


            'oDraft.Lines.LineTotal = DGV2.Rows(i).Cells("總計").FormattedValue

            oDraft.Lines.UserFields.Fields.Item("U_Omoney").Value = DGV2.Rows(i).Cells("付款方法").FormattedValue

            oDraft.Lines.UserFields.Fields.Item("U_m1").Value = DGV2.Rows(i).Cells("係數").FormattedValue
            oDraft.Lines.UserFields.Fields.Item("U_m2").Value = DGV2.Rows(i).Cells("過縣費").FormattedValue
            oDraft.Lines.UserFields.Fields.Item("U_m4").Value = DGV2.Rows(i).Cells("合車").FormattedValue
            oDraft.Lines.UserFields.Fields.Item("U_m5").Value = DGV2.Rows(i).Cells("運費").FormattedValue

            oDraft.Lines.ShipDate = dateDocDate.Value.Date

            oDraft.Lines.Add()

        Next

        RetVal = oDraft.Add()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            CleanBody()
            CleanHead()
            Exit Sub
        End If

        Dim OQUTDocNum As Integer
        OQUTDocNum = Login.oCompany.GetNewObjectKey()
        MsgBox("新增至B1完成!!" + vbCrLf + "草稿單號：" & OQUTDocNum, 64, "完成")
        CleanBody()
        CleanHead()
    End Sub

    Private Sub CleanBody()
        If DGV2.RowCount > 0 Then
            dsPDAIn.Clear()
        End If
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        txtQuantity.Text = 0
        txtU_P2.Text = 0
        txtU_P8.Text = 0
        cobU_P7.SelectedIndex = 1
        txtTotal.Text = 0
        cobU_Omoney.SelectedIndex = 2
        txtU_M1.Text = 0
        txtU_M2.Text = 0
        txtU_M4.Text = 0
        txtU_M5.Text = 0
    End Sub

    Private Sub CleanHead()
        CardCode.Text = ""
        CardName.Text = ""
        txtU_CK02.Text = ""
        txtU_Cnum.Text = ""
        txtComments.Text = ""
        txtU_GetMT.Text = 0
        txtU_TpMoney.Text = 0
        cobDateType.SelectedIndex = 0
        dateDosDueDate.Value = Today()
        cobOwner.SelectedIndex = -1
    End Sub

    Private Sub btnCleanBody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleanBody.Click
        CleanBody()
    End Sub

    Private Sub btnCleanAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCleanAll.Click
        CleanBody()
        CleanHead()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim P2, M5, P8, P81 As Double

        If txtU_P2.Text = "" Then
            P2 = 0
        Else
            P2 = CDbl(Trim(txtU_P2.Text))
        End If

        If txtU_M5.Text = "" Then
            M5 = 0
        Else
            M5 = CDbl(Trim(txtU_M5.Text))
        End If

        P8 = M5 / P2

        P81 = Math.Round(P8, 4)

        txtU_P8.Text = P81


    End Sub
End Class