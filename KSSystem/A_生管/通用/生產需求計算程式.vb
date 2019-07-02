Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Linq

Public Class 生產需求計算程式
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ItemMainDt As New DataTable
    Dim SumAll As New DataTable
    Dim 是否進入統計 As String = "N"


    Private Sub 生產需求計算程式_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        設定T1.Text = ""
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
        Dim CInvntryUom As DataColumn = New DataColumn("CInvntryUom")
        Dim OnHandDc As DataColumn = New DataColumn("OnHand")
        Dim InvntryUomDc As DataColumn = New DataColumn("InvntryUom")
        Dim NeedsDc As DataColumn = New DataColumn("Needs")
        ItemCodeDc.DataType = System.Type.GetType("System.String")
        ItemNameDc.DataType = System.Type.GetType("System.String")
        QutDc.DataType = System.Type.GetType("System.Decimal")
        CInvntryUom.DataType = System.Type.GetType("System.String")
        OnHandDc.DataType = System.Type.GetType("System.Decimal")
        InvntryUomDc.DataType = System.Type.GetType("System.String")
        NeedsDc.DataType = System.Type.GetType("System.Decimal")
        SumAll.Columns.Add(ItemCodeDc)
        SumAll.Columns.Add(ItemNameDc)
        SumAll.Columns.Add(QutDc)
        SumAll.Columns.Add(CInvntryUom)
        SumAll.Columns.Add(OnHandDc)
        SumAll.Columns.Add(InvntryUomDc)
        SumAll.Columns.Add(NeedsDc)
    End Sub

    'DGV執行區
    Private Sub DGVOITM_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVOITM.CellClick
        If DGVOITM.RowCount = -1 Then : Exit Sub : End If      '無資料不執行下方
        設定T1.Text = DGVOITM.CurrentRow.Cells("設定").Value
        ItemCode.Text = DGVOITM.CurrentRow.Cells("存編").Value
        ItemName.Text = DGVOITM.CurrentRow.Cells("品名").Value
        Quty2.Text = Format(CSng(DGVOITM.CurrentRow.Cells("包裝數").Value), "####0")
        SalPackMsr.Text = DGVOITM.CurrentRow.Cells("包裝單位").Value
        基數計算()
    End Sub

    Private Sub 查詢T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢T1.Click
        查詢DGVOITM存編()
    End Sub

    Private Sub 查詢DGVOITM存編()
        If DGVOITM.RowCount > 0 Then : ks1DataSetDGV.Tables("DGVOITM").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = "" : Dim strWHERE4 As String = ""
        Dim str品W1 As String = "ALL" : Dim str品W2 As String = "ALL" : Dim str品W3 As String = "ALL"
        If 品W1.Text <> "" Then : str品W1 = 品W1.Text : End If
        If 品W2.Text <> "" Then : str品W2 = 品W2.Text : End If
        If 品W3.Text <> "" Then : str品W3 = 品W3.Text : End If

        If 包含查詢.Checked Then

            strWHERE1 += " AND (T0.[ItemName] Like '%" & str品W1 & "%'  "
            strWHERE2 += " OR   T0.[ItemName] Like '%" & str品W2 & "%'  "
            strWHERE3 += " OR   T0.[ItemName] Like '%" & str品W3 & "%') "
        Else

            If 品W1.Text <> "" Then : strWHERE1 += " AND T0.[ItemName] Like '%" & 品W1.Text & "%' " : End If
            If 品W2.Text <> "" Then : strWHERE2 += " AND T0.[ItemName] Like '%" & 品W2.Text & "%' " : End If
            If 品W3.Text <> "" Then : strWHERE3 += " AND T0.[ItemName] Like '%" & 品W3.Text & "%' " : End If
        End If

        If 保存方式W.SelectedIndex > 0 Then
            strWHERE4 += "      AND SUBSTRING(T0.[ItemCode],3,1) = '" & Microsoft.VisualBasic.Left(保存方式W.Text, 1) & "' "
        End If

        Try
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = "    SELECT T0.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[SalPackUn] AS '包裝數', T0.[SalPackMsr] AS '包裝單位' "
            'SQLCmd.CommandText += "     FROM [OITM] T0 "
            SQLCmd.CommandText = "    SELECT CASE WHEN ISNULL(T1.[ItemCode],'') = ''   THEN '' ELSE 'V' END AS '設定', "
            SQLCmd.CommandText += "          T0.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[SalPackUn] AS '包裝數', T0.[SalPackMsr] AS '包裝單位' "
            SQLCmd.CommandText += "     FROM [OITM] T0 LEFT  JOIN [KaiShingPlug].[dbo].[KS_ITT0] T1 ON SUBSTRING(T0.[ItemCode],1,13) = SUBSTRING(T1.[ItemCode],1,13) "
            SQLCmd.CommandText += "    WHERE SUBSTRING(T0.[ItemCode],1,2) IN ('25','31') AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2')  AND T0.[ManSerNum] = 'Y' "
            SQLCmd.CommandText += "      AND T0.[ItemCode] NOT Like '%-1%'  AND T0.[ItemCode] NOT Like '%-2%' "
            SQLCmd.CommandText += "      AND T0.[ItemName] NOT Like '%xxx%' AND T0.[ItemName] NOT Like '%xx%' "
            SQLCmd.CommandText += strWHERE1 : SQLCmd.CommandText += strWHERE2 : SQLCmd.CommandText += strWHERE3 : SQLCmd.CommandText += strWHERE4
            SQLCmd.CommandText += " ORDER BY 1 DESC, 3, 2 "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGVOITM")
            DGVOITM.DataSource = ks1DataSetDGV.Tables("DGVOITM")
            DGVOITM.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Quty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quty.TextChanged
        基數計算()
    End Sub

    Private Sub 基數計算()
        Dim Quty3s As String

        If Quty.Text <> "" Or Quty2.Text <> "" Then
            If Quty.Text <> "" Then
                Quty3s = Quty2.Text * Quty.Text
                Quty3.Text = Format(CSng(Quty3s), "####0")
            Else
                Quty3.Text = ""
            End If
        End If
    End Sub

    Private Sub AddBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddBtn.Click
        If 設定T1.Text = "" Then : MsgBox("未設定BOM基本資料無法新增!", 16, "錯誤") : Exit Sub : End If
        If ItemCode.Text = "" Then : MsgBox("產品號碼未填!", 16, "錯誤") : ItemCode.Focus() : Exit Sub : End If
        If ItemName.Text = "" Then : MsgBox("產品說明未填!", 16, "錯誤") : ItemName.Focus() : Exit Sub : End If
        If Quty.Text = "" Then : MsgBox("數量未填!", 16, "錯誤") : Quty.Focus() : Exit Sub : End If

        '加到ItemMainDt
        Dim Row As DataRow
        Row = ItemMainDt.NewRow
        Row.Item("產品號碼") = ItemCode.Text
        Row.Item("產品說明") = ItemName.Text
        Row.Item("數量") = Quty3.Text
        ItemMainDt.Rows.Add(Row)

        ItemMain.DataSource = ItemMainDt
        ItemMain.AutoResizeColumns()

        是否進入統計 = "N"

        設定T1.Text = ""
        ItemCode.Text = ""
        ItemName.Text = ""
        Quty.Text = ""
        Quty2.Text = ""
        Quty3.Text = ""
        SalPackMsr.Text = ""
    End Sub

    Private Sub 列出明細_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列出明細.Click
        SetItemDetail()
    End Sub

    Private Sub SetItemDetail()

        If ItemDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            For j As Integer = 0 To ItemMain.RowCount - 1
                'sql = " SELECT T1.[Code], T2.[ItemName], (T1.[Quantity] * '" & ItemMain.Rows(j).Cells("數量").Value & "' ) AS 'Qut', T2.[InvntryUom], T2.[OnHand] "
                'sql += "   FROM [OITT] T0 INNER JOIN [ITT1] T1 ON T0.[Code] = T1.[Father] left join [OITM] T2 ON T1.[Code] = T2.[ItemCode] "
                'sql += "  WHERE T0.[Code] = '" & ItemMain.Rows(j).Cells("產品號碼").Value & "' "

                sql = "  SELECT T0.[CItemCode] AS 'Code', T1.[ItemName], CAST((CAST(T0.[CQuantity] AS Decimal(10, 4)) * '" & ItemMain.Rows(j).Cells("數量").Value & "' ) AS Decimal(10, 4)) AS 'Qut', T0.[CInvntryUom], T1.[OnHand], T1.[InvntryUom]"
                sql += "   FROM [KaiShingPlug].[dbo].[KS_ITT1] T0 INNER JOIN [OITM] T1 ON T0.[CItemCode] = T1.[ItemCode]"
                sql += "  WHERE T0.[ItemCode] = '" & Microsoft.VisualBasic.Left(ItemMain.Rows(j).Cells("產品號碼").Value, 13) & "' "

                DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
                DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            Next

            ItemDetail.DataSource = ks1DataSetDGV.Tables("DT1")

        Catch ex As Exception
            MsgBox("SetItemDetail: " & ex.Message)
            End
        End Try

        SetItemDetailDisplay()
        是否進入統計 = "Y"

    End Sub

    Private Sub SetItemDetailDisplay()

        For Each column As DataGridViewColumn In ItemDetail.Columns
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
                Case "CInvntryUom"
                    column.HeaderText = "領用單位"
                    column.DisplayIndex = 3
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Format = "0.0000"
                Case "InvntryUom"
                    column.HeaderText = "庫存單位"
                    column.DisplayIndex = 5
                Case Else
                    column.Visible = False
            End Select
        Next
        ItemDetail.AutoResizeColumns()

    End Sub

    Private Sub CalBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalBtn.Click

        SetItemDetail()

        If ItemDetail.RowCount <= 0 Then : Exit Sub : End If
        If 是否進入統計 = "N" Then : Exit Sub : End If

        Dim orders As DataTable = ks1DataSetDGV.Tables("DT1")

        Dim Q1 As Integer = 0

        'LinQ 的 Group By Sum
        Dim Ans = From Tb In orders.AsEnumerable() _
                  Group Tb By _
                  Code = Tb.Field(Of String)("Code"), _
                  ItemName = Tb.Field(Of String)("ItemName"), _
                  CInvntryUom = Tb.Field(Of String)("CInvntryUom"), _
                  OnHand = Tb.Field(Of Decimal)("OnHand"), _
                  InvntryUom = Tb.Field(Of String)("InvntryUom") _
                  Into g = Group _
                  Select New With _
                  { _
                  .Code = Code, _
                  .ItemName = ItemName, _
                  .CInvntryUom = CInvntryUom, _
                  .OnHand = OnHand, _
                  .InvntryUom = InvntryUom, _
                  .TotalDue = g.Sum(Function(order) order.Field(Of Decimal)("Qut")) _
                  }

        '一列一列的寫入DataTable
        For Each order In Ans

            Q1 = Q1 + 1
            Dim Row(Q1) As DataRow
            Row(Q1) = SumAll.NewRow
            Row(Q1).Item("ItemCode") = order.Code
            Row(Q1).Item("ItemName") = order.ItemName
            Row(Q1).Item("CInvntryUom") = order.CInvntryUom
            Row(Q1).Item("OnHand") = order.OnHand
            Row(Q1).Item("InvntryUom") = order.InvntryUom
            Row(Q1).Item("Qut") = order.TotalDue

            If order.TotalDue > order.OnHand Then
                Row(Q1).Item("Needs") = order.TotalDue - order.OnHand
            Else
                Row(Q1).Item("Needs") = 0
            End If

            SumAll.Rows.Add(Row(Q1))

        Next

        Sumdetail.DataSource = SumAll
        SetSumdetailDisplay()

        Sumdetail.AutoResizeColumns()

        Me.TabControl1.SelectedTab = Me.TabPage2
    End Sub

    Private Sub SetSumdetailDisplay()

        For Each column As DataGridViewColumn In Sumdetail.Columns
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
                Case "CInvntryUom"
                    column.HeaderText = "領用單位"
                    column.DisplayIndex = 3
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Format = "0.0000"
                Case "InvntryUom"
                    column.HeaderText = "庫存單位"
                    column.DisplayIndex = 5
                Case "Needs"
                    column.HeaderText = "須請購量"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Format = "0.0000"
                Case Else
                    column.Visible = False
            End Select
        Next

        'Sumdetail.AutoResizeColumns()

    End Sub

    Private Sub 離開T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 離開T2.Click

        'ItemMainDt.Clear()
        SumAll.Clear()
        If ItemDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub ClearBtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearBtn.Click

        ItemCode.Text = ""
        ItemName.Text = ""
        Quty.Text = ""
        Quty2.Text = ""
        Quty3.Text = ""

        ItemMainDt.Clear()
        SumAll.Clear()
        If ItemDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

    End Sub

    Private Sub DataToExcel(ByVal m_DataView As DataGridView)

        Dim kk As New SaveFileDialog()
        kk.Title = "儲存EXECL文件"
        kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*"
        kk.FilterIndex = 1
        If kk.ShowDialog() = DialogResult.OK Then
            Dim FileName As String = kk.FileName ' + ".xls"
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If

            Dim myExcel, myBook, myWorksheet As Object
            myExcel = CreateObject("Excel.Application")
            myBook = myExcel.Workbooks.add
            myWorksheet = myBook.worksheets(1)
            myExcel.Visible = False
            'myWorksheet.Columns.NumberFormat = "@"

            For k As Integer = 0 To m_DataView.Columns.Count - 1
                If m_DataView.Columns(k).Visible = True Then
                    myWorksheet.Cells(1, k + 1).value = m_DataView.Columns(k).HeaderText.ToString()
                End If
            Next

            For i As Integer = 1 To m_DataView.Rows.Count
                For j As Integer = 1 To m_DataView.Columns.Count
                    myWorksheet.Cells(i + 1, 1).NumberFormat = "@"
                    myWorksheet.Cells(i + 1, j).value = m_DataView.Rows(i - 1).Cells(j - 1).FormattedValue.ToString()
                Next
            Next

            myExcel.ActiveWorkbook.SaveAs(FileName)
            myExcel.Quit()
            myExcel = Nothing
            MessageBox.Show(Me, "儲存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub ToExcelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn.Click
        If Sumdetail.RowCount <= 0 Then
            Exit Sub
        End If
        DataToExcel(Sumdetail)
    End Sub








    'Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCode.LostFocus
    '    SelectItemCode()
    'End Sub

    'Private Sub ItemName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.LostFocus
    '    SelectItemName()
    'End Sub

    'Private Sub Quty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Quty.KeyPress

    '    'If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
    '    If e.KeyChar = "." Or Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If

    'End Sub

    ''Private Sub SelectItemCode()
    ''    If ItemCode.Text = "" Then : Exit Sub : End If '空白離開

    ''    Dim DBConn As SqlConnection = Login.DBConn
    ''    Dim SQLCmd As SqlCommand = New SqlCommand
    ''    Dim sqlReader As SqlDataReader

    ''    Try
    ''        SQLCmd.Connection = DBConn

    ''        SQLCmd.CommandText = "    SELECT T0.[ItemCode], T0.[ItemName], T0.[Qauntity] FROM [OITM] T0 "
    ''        SQLCmd.CommandText += "    WHERE T0.[ItemCode] = '" & ItemCode.Text & "'"
    ''        SQLCmd.CommandText += "      AND SUBSTRING(T0.[ItemCode],1,2) IN ('25','31') AND T0.[ManSerNum] = 'Y' AND SUBSTRING(T0.[ItemCode],16,2) <> '-1' "

    ''        '電宰
    ''        'SQLCmd.CommandText = "    SELECT T1.[ItemCode], T1.[ItemName], T0.[Qauntity] FROM [OITT] T0 INNER JOIN [OITM] T1 ON T0.[Code] = T1.[ItemCode] WHERE T0.[Code] = '" & ItemCode.Text & "'  "
    ''        '加工

    ''        SQLCmd.Parameters.Clear()
    ''        SQLCmd.ExecuteNonQuery()

    ''        sqlReader = SQLCmd.ExecuteReader
    ''        sqlReader.Read()

    ''        If Not sqlReader.HasRows() Then
    ''            sqlReader.Close()
    ''            MsgBox("查無此產品", 16, "錯誤")
    ''            ItemName.Text = "" : ItemCode.Text = ""
    ''            ItemCode.Focus()
    ''        Else
    ''            ItemName.Text = sqlReader.Item("ItemName")
    ''            Quty2.Text = Format(sqlReader.Item("Qauntity"), "####0.00")
    ''            sqlReader.Close()
    ''        End If

    ''    Catch ex As Exception
    ''        MsgBox(ex.Message)
    ''    End Try

    ''End Sub


    'Private Sub SelectItemCode()
    '    If ItemCode.Text = "" Then : Exit Sub : End If

    '    Dim sql As String
    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Dim sqlReader As SqlDataReader

    '    'sql = "SELECT T1.[ItemName], T0.[Qauntity] FROM [OITT] T0 INNER JOIN [OITM] T1 ON T0.[Code] = T1.[ItemCode] WHERE T0.[Code] = '" & ItemCode.Text & "'"
    '    sql = "    SELECT T0.[ItemName], T0.[Qauntity] FROM [OITM] T0 "
    '    sql += "    WHERE T0.[ItemCode] = '" & ItemCode.Text & "' " ' AND SUBSTRING(T0.[ItemCode],1,2) IN ('25','31') AND T0.[ManSerNum] = 'Y' AND SUBSTRING(T0.[ItemCode],16,2) <> '-1' "

    '    SQLCmd.Connection = DBConn
    '    SQLCmd.CommandText = sql
    '    sqlReader = SQLCmd.ExecuteReader
    '    sqlReader.Read()

    '    If Not sqlReader.HasRows() Then
    '        sqlReader.Close()
    '        MsgBox("查無此產品", 16, "錯誤")
    '        ItemName.Text = "" : ItemCode.Text = "" : ItemCode.Focus()
    '    Else
    '        ItemName.Text = sqlReader.Item("ItemName")
    '        Quty2.Text = Format(sqlReader.Item("Qauntity"), "####0.00")
    '        sqlReader.Close()
    '    End If

    'End Sub

    'Private Sub SelectItemName()
    '    If ItemName.Text = "" Then : Exit Sub : End If

    '    Dim sql As String
    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Dim sqlReader As SqlDataReader

    '    'sql = "SELECT T0.[Code], T0.[Qauntity] FROM [OITT] T0 INNER JOIN [OITM] T1 ON T0.[Code] = T1.[ItemCode] WHERE T1.[ItemName] = '" & ItemName.Text & "'"
    '    sql = "    SELECT T0.[ItemCode], T0.[Qauntity] FROM [OITM] T0 "
    '    sql += "    WHERE T0.[ItemName] = '" & ItemName.Text & "' AND SUBSTRING(T0.[ItemCode],1,2) IN ('25','31') AND T0.[ManSerNum] = 'Y' AND SUBSTRING(T0.[ItemCode],16,2) <> '-1' "

    '    SQLCmd.Connection = DBConn
    '    SQLCmd.CommandText = sql
    '    sqlReader = SQLCmd.ExecuteReader
    '    sqlReader.Read()

    '    If Not sqlReader.HasRows() Then
    '        sqlReader.Close()
    '        SelectItem.Show()
    '    Else
    '        ItemCode.Text = sqlReader.Item("Code")
    '        Quty2.Text = Format(sqlReader.Item("Qauntity"), "####0.00")
    '        sqlReader.Close()
    '    End If

    'End Sub


End Class
