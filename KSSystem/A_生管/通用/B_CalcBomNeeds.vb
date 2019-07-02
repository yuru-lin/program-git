Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Linq

Public Class B_CalcBomNeeds
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ItemMainDt As New DataTable
    Dim SumAll As New DataTable

    Private Sub B_CalcBomNeeds_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        AddDTItemMainDt()
        AddDTSumAll()
    End Sub

    Private Sub AddDTItemMainDt()
        Dim ItemCodeDc As DataColumn = New DataColumn("產品號碼")
        Dim ItemNameDc As DataColumn = New DataColumn("產品說明")
        Dim ItemQuty As DataColumn = New DataColumn("數量")
        ItemCodeDc.DataType = System.Type.GetType("System.String")
        ItemNameDc.DataType = System.Type.GetType("System.String")
        ItemQuty.DataType = System.Type.GetType("System.Decimal")
        ItemMainDt.Columns.Add(ItemCodeDc)
        ItemMainDt.Columns.Add(ItemNameDc)
        ItemMainDt.Columns.Add(ItemQuty)
    End Sub

    Private Sub AddDTSumAll()
        Dim ItemCodeDc As DataColumn = New DataColumn("ItemCode")
        Dim ItemNameDc As DataColumn = New DataColumn("ItemName")
        Dim QutDc As DataColumn = New DataColumn("Qut")
        Dim InvntryUomDc As DataColumn = New DataColumn("InvntryUom")
        Dim OnHandDc As DataColumn = New DataColumn("OnHand")
        Dim NeedsDc As DataColumn = New DataColumn("Needs")
        ItemCodeDc.DataType = System.Type.GetType("System.String")
        ItemNameDc.DataType = System.Type.GetType("System.String")
        QutDc.DataType = System.Type.GetType("System.Decimal")
        InvntryUomDc.DataType = System.Type.GetType("System.String")
        OnHandDc.DataType = System.Type.GetType("System.Decimal")
        NeedsDc.DataType = System.Type.GetType("System.Decimal")
        SumAll.Columns.Add(ItemCodeDc)
        SumAll.Columns.Add(ItemNameDc)
        SumAll.Columns.Add(QutDc)
        SumAll.Columns.Add(InvntryUomDc)
        SumAll.Columns.Add(OnHandDc)
        SumAll.Columns.Add(NeedsDc)
    End Sub

    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()
    End Sub

    Private Sub ItemName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()
    End Sub

    Private Sub Quty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Quty.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub SelectItemCode()

        If ItemCodeTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT T1.[ItemName] FROM  OITT T0  INNER JOIN OITM T1 ON T0.Code = T1.ItemCode WHERE T0.[Code] = '" & ItemCodeTxt.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            SelectItem.getItemName = ItemNameTxt.Text
            SelectItem.getItemCode = ItemCodeTxt.Text
            SelectItem.Source = "B_CalcBomNeeds"
            SelectItem.MdiParent = MainForm
            SelectItem.Show()
        Else
            ItemNameTxt.Text = sqlReader.Item("ItemName")
            sqlReader.Close()
        End If

    End Sub

    Private Sub SelectItemName()

        If ItemNameTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT T0.[Code] FROM OITT T0  INNER JOIN OITM T1 ON T0.Code = T1.ItemCode WHERE T1.[ItemName] = '" & ItemNameTxt.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            SelectItem.getItemName = ItemNameTxt.Text
            SelectItem.getItemCode = ItemCodeTxt.Text
            SelectItem.Source = "B_CalcBomNeeds"
            SelectItem.MdiParent = MainForm
            SelectItem.Show()
        Else
            ItemCodeTxt.Text = sqlReader.Item("Code")
            sqlReader.Close()
        End If

    End Sub

    Private Sub AddBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBtn.Click

        If ItemCodeTxt.Text = "" Then
            MsgBox("產品號碼未填!", 16, "錯誤")
            ItemCodeTxt.Focus()
            Exit Sub
        End If
        If ItemNameTxt.Text = "" Then
            MsgBox("產品說明未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If
        If Quty.Text = "" Then
            MsgBox("數量未填!", 16, "錯誤")
            Quty.Focus()
            Exit Sub
        End If

        '加到ItemMainDt
        Dim Row As DataRow
        Row = ItemMainDt.NewRow
        Row.Item("產品號碼") = ItemCodeTxt.Text
        Row.Item("產品說明") = ItemNameTxt.Text
        Row.Item("數量") = Quty.Text
        ItemMainDt.Rows.Add(Row)

        DGV1.DataSource = ItemMainDt
        DGV1.AutoResizeColumns()

        '加到ItemDetail
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = " SELECT T1.[Code] ,T2.[ItemName], (T1.[Quantity] * '" & Quty.Text & "' ) as 'Qut', T2.[InvntryUom], T2.[OnHand] FROM OITT T0  INNER JOIN ITT1 T1 ON T0.Code = T1.Father left join OITM T2 ON T1.Code = T2.ItemCode WHERE T0.[Code] = '" & ItemCodeTxt.Text & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        DGV2.DataSource = ks1DataSetDGV.Tables("DT1")
        SetItemDetailDisplay()

        '清空
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        Quty.Text = ""

    End Sub
    Private Sub SetItemDetailDisplay()

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "Code"
                    column.HeaderText = "產品號碼"
                    column.DisplayIndex = 0
                Case "ItemName"
                    column.HeaderText = "產品說明"
                    column.DisplayIndex = 1
                Case "Qut"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Format = "0.0000"
                Case "InvntryUom"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 3
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Format = "0.0000"
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub CalBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalBtn.Click

        If DGV2.RowCount <= 0 Then
            Exit Sub
        End If

        Dim orders As DataTable = ks1DataSetDGV.Tables("DT1")

        Dim Q1 As Integer = 0

        'LinQ 的 Group By Sum
        Dim Ans = From Tb In orders.AsEnumerable() _
                  Group Tb By _
                  Code = Tb.Field(Of String)("Code"), _
                  ItemName = Tb.Field(Of String)("ItemName"), _
                  InvntryUom = Tb.Field(Of String)("InvntryUom"), _
                  OnHand = Tb.Field(Of Decimal)("OnHand") _
                  Into g = Group _
                  Select New With _
                  { _
                  .Code = Code, _
                  .ItemName = ItemName, _
                  .InvntryUom = InvntryUom, _
                  .OnHand = OnHand, _
                  .TotalDue = g.Sum(Function(order) order.Field(Of Decimal)("Qut")) _
                  }

        '一列一列的寫入DataTable
        For Each order In Ans

            Q1 = Q1 + 1
            Dim Row(Q1) As DataRow
            Row(Q1) = SumAll.NewRow
            Row(Q1).Item("ItemCode") = order.Code
            Row(Q1).Item("ItemName") = order.ItemName
            Row(Q1).Item("InvntryUom") = order.InvntryUom
            Row(Q1).Item("OnHand") = order.OnHand
            Row(Q1).Item("Qut") = order.TotalDue

            If order.TotalDue > order.OnHand Then
                Row(Q1).Item("Needs") = order.TotalDue - order.OnHand
            Else
                Row(Q1).Item("Needs") = 0
            End If

            SumAll.Rows.Add(Row(Q1))

        Next

        DGV3.DataSource = SumAll
        SetSumdetailDisplay()

    End Sub

    Private Sub SetSumdetailDisplay()

        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True

            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "產品號碼"
                    column.DisplayIndex = 0
                Case "ItemName"
                    column.HeaderText = "產品說明"
                    column.DisplayIndex = 1
                Case "Qut"
                    column.HeaderText = "總數量"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Format = "0.0000"
                Case "InvntryUom"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 3
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Format = "0.0000"
                Case "Needs"
                    column.HeaderText = "須請購量"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Format = "0.0000"
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV3.AutoResizeColumns()

    End Sub

    Private Sub ClearBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBtn.Click

        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        Quty.Text = ""

        ItemMainDt.Clear()
        SumAll.Clear()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

    End Sub

    Private Sub ToExcelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn.Click
        If DGV3.RowCount <= 0 Then
            Exit Sub
        End If
        DataToExcel(DGV3, "")
    End Sub
End Class