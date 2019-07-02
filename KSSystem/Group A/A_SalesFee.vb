Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_SalesFee
    Dim MoneyA_1, MoneyA_2, MoneyA_3, MoneyA_4, MoneySum_1, MoneySumAll As Integer

    Private Sub A_SalesFee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        SumAllDGV.ContextMenuStrip = MainForm.ContextMenuStrip1
        KSFeeDGV.ContextMenuStrip = MainForm.ContextMenuStrip1
        FSFeeDGV.ContextMenuStrip = MainForm.ContextMenuStrip1
        SelectOSLP()
    End Sub

    Private Sub Money2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money2.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money3.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money4.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money5.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money6.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money7.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money8_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money8.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money9_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money9.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Money10_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Money10.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub


    Private Sub SelectOSLP()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer

        sql = "Select SlpCode , SlpName  from OSLP where Memo = '業務'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        OSLPList.DataSource = ksDataSet.Tables("DT1")
        OSLPList.DisplayMember = "SlpName"
        OSLPList.ValueMember = "SlpName"
        OSLPList.SelectedIndex = -1

    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        If OSLPList.SelectedIndex = -1 Then
            MsgBox("未選擇業務人員!", 16, "錯誤")
            OSLPList.Focus()
            Exit Sub
        End If

        ClearAll()

        calcKSSalesFee()
        calcFSSalesFee()
        calcMoney1Fee()
        calcNewCust()
        calcdriverFee()
        calcMoneyAll()

        If OSLPList.SelectedValue = "張文壽" Then
            calcChang()
        End If

        showcalcKSFeeDGV()
        showcalcFSFeeDGV()
    End Sub

    Private Sub calcKSSalesFee()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "L20110812_1"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.Parameters.Add(New SqlParameter("@FromDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ToDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@U_CarDr1", SqlDbType.NVarChar))
        SQLCmd.Parameters("@FromDate").Value = FromDate.Value.Date
        SQLCmd.Parameters("@ToDate").Value = ToDate.Value.Date
        SQLCmd.Parameters("@U_CarDr1").Value = OSLPList.SelectedValue

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            MsgBox("查無資料!", 16, "錯誤")
            Exit Sub
        Else
            Money1_1.Text = Format(sqlReader.Item("Total"), "###,##0")
            sqlReader.Close()
        End If

    End Sub

    Private Sub Money1_1Changed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Money1_1.TextChanged

        If Money1_1.Text > 6000000 Then
            Money1_2.Text = Format(6000, "###,##0")
            MoneyA_1 = 6000

            Money1_3.Text = Format((((Money1_1.Text - 6000000) \ 1000000) * 1500), "###,##0")
            MoneyA_2 = (((Money1_1.Text - 6000000) \ 1000000) * 1500)

            Money1_4.Text = Format((((Money1_1.Text - 6000000) Mod 1000000) * 0.0015), "###,##0")
            MoneyA_3 = (((Money1_1.Text - 6000000) Mod 1000000) * 0.0015)

        End If

        If Money1_1.Text > 5000000 Then

            Money5.Text = (((Money1_1.Text - 5000000) \ 1000000) * 600)

        End If

    End Sub

    Private Sub calcFSSalesFee()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "L20110812_1A"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.Parameters.Add(New SqlParameter("@FromDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ToDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@U_CarDr1", SqlDbType.NVarChar))
        SQLCmd.Parameters("@FromDate").Value = FromDate.Value.Date
        SQLCmd.Parameters("@ToDate").Value = ToDate.Value.Date
        SQLCmd.Parameters("@U_CarDr1").Value = OSLPList.SelectedValue

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            Exit Sub
        Else
            Money1_5.Text = Format((sqlReader.Item("Total") * 20 * 0.0015), "###,##0")
            MoneyA_4 = (sqlReader.Item("Total") * 20 * 0.0015)
            sqlReader.Close()
        End If

    End Sub

    Private Sub calcChang()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "L20110812_1_C"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.Parameters.Add(New SqlParameter("@FromDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ToDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@U_CarDr1", SqlDbType.NVarChar))
        SQLCmd.Parameters("@FromDate").Value = FromDate.Value.Date
        SQLCmd.Parameters("@ToDate").Value = ToDate.Value.Date
        SQLCmd.Parameters("@U_CarDr1").Value = OSLPList.SelectedValue

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            Exit Sub
        Else
            Money1_6.Text = "豪龍(" + Format(sqlReader.Item("豪龍Total"), "###,##0") + ") + 裕益(" + Format(sqlReader.Item("裕益Total"), "###,##0") + ") / 2 = " + Format(sqlReader.Item("總Total"), "###,##0")

            sqlReader.Close()
        End If

    End Sub

    Private Sub calcMoney1Fee()

        MoneySum_1 = MoneyA_1 + MoneyA_2 + MoneyA_3 + MoneyA_4

        Money1.Text = Format(MoneySum_1, "###,##0")

    End Sub

    Private Sub calcNewCust()

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "exec L20110812_2 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' , '" & OSLPList.SelectedValue & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        DGV1.DataSource = ksDataSet.Tables("DT1")
        setDGV1Display()

        counttimes.Text = DGV1.RowCount
        Money2.Text = DGV1.RowCount * 600

    End Sub

    Private Sub setDGV1Display()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "客編"
                    column.DisplayIndex = 0
                Case "客名"
                    column.DisplayIndex = 1
                Case "月份"
                    column.DisplayIndex = 2
                Case "金額"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub calcdriverFee()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "L20110810B"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.Parameters.Add(New SqlParameter("@FromDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ToDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@U_CarDr1", SqlDbType.NVarChar))
        SQLCmd.Parameters("@FromDate").Value = FromDate.Value.Date
        SQLCmd.Parameters("@ToDate").Value = ToDate.Value.Date
        SQLCmd.Parameters("@U_CarDr1").Value = OSLPList.SelectedValue

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            Money6.Text = "0"
            Money7.Text = "0"
            Exit Sub
        Else
            Money6.Text = sqlReader.Item("空籃獎金")
            Money7.Text = sqlReader.Item("金額")
            sqlReader.Close()
        End If

    End Sub

    Private Sub calcMoneyAll()

        MoneySumAll = MoneySum_1 + Money2.Text + Money3.Text - Money4.Text + Money5.Text + Money6.Text + Money7.Text + Money8.Text + Money9.Text - Money10.Text

        MoneyAll.Text = Format(MoneySumAll, "###,##0")

    End Sub

    Private Sub calcSumAllBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calcSumAllBtn.Click
        calcMoneyAll()
    End Sub

    Private Sub ClearAll()

        Money1.Text = "0"
        Money2.Text = "0"
        Money3.Text = "0"
        Money4.Text = "0"
        Money5.Text = "0"
        Money6.Text = "0"
        Money7.Text = "0"
        Money8.Text = "0"
        Money9.Text = "0"
        Money10.Text = "0"
        MoneyAll.Text = "0"
        AddComm.Text = ""
        SubComm.Text = ""
        Money1_1.Text = "0"
        Money1_2.Text = "0"
        Money1_3.Text = "0"
        Money1_4.Text = "0"
        Money1_5.Text = "0"
        Money1_6.Text = ""
    End Sub

    Private Sub showcalcKSFeeDGV()

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "exec L20110812_1B '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        KSFeeDGV.DataSource = ksDataSet.Tables("DT1")

        For Each column As DataGridViewColumn In KSFeeDGV.Columns
            column.Visible = True

            Select Case column.Name
                Case "銷售人員名稱"
                    column.DisplayIndex = 0
                    column.HeaderText = "銷售人員名稱"
                Case "總計 A/R 發票"
                    column.DisplayIndex = 1
                    column.HeaderText = "總計A/R發票"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        Dim TotalSum As Integer = 0
        For i As Integer = 0 To KSFeeDGV.RowCount - 1
            TotalSum = TotalSum + KSFeeDGV.Rows(i).Cells("總計 A/R 發票").Value
        Next

        Dim Row As DataRow
        Row = ksDataSet.Tables("DT1").NewRow
        Row.Item("銷售人員名稱") = "總計"
        Row.Item("總計 A/R 發票") = TotalSum
        ksDataSet.Tables("DT1").Rows.Add(Row)

        KSFeeDGV.AutoResizeColumns()

    End Sub

    Private Sub showcalcFSFeeDGV()

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "exec L20110812_1C '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        FSFeeDGV.DataSource = ksDataSet.Tables("DT1")

        For Each column As DataGridViewColumn In FSFeeDGV.Columns
            column.Visible = True

            Select Case column.Name
                Case "銷售人員名稱"
                    column.DisplayIndex = 0
                    column.HeaderText = "銷售人員名稱"
                Case "總計 A/R 發票"
                    column.DisplayIndex = 1
                    column.HeaderText = "總計A/R發票"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        Dim TotalSum As Integer = 0
        For i As Integer = 0 To FSFeeDGV.RowCount - 1
            TotalSum = TotalSum + FSFeeDGV.Rows(i).Cells("總計 A/R 發票").Value
        Next

        Dim Row As DataRow
        Row = ksDataSet.Tables("DT1").NewRow
        Row.Item("銷售人員名稱") = "總計"
        Row.Item("總計 A/R 發票") = TotalSum
        ksDataSet.Tables("DT1").Rows.Add(Row)

        FSFeeDGV.AutoResizeColumns()

    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        If KSFeeDGV.RowCount <= 0 Then
            Exit Sub
        End If
        DataToExcel(KSFeeDGV, "")
    End Sub

    Private Sub ToExcelBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn2.Click
        If FSFeeDGV.RowCount <= 0 Then
            Exit Sub
        End If
        DataToExcel(FSFeeDGV, "")
    End Sub

    Private Sub ToExcelBtn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn3.Click
        If SumAllDGV.RowCount <= 0 Then
            Exit Sub
        End If
        DataToExcel(SumAllDGV, "")
    End Sub

    Private Sub GetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetData.Click
        Dim SumAllDt As New DataTable
        Dim Q As Integer = 0
        Dim Name As DataColumn = New DataColumn("項目")
        Dim Amt As DataColumn = New DataColumn("金額")
        'declaring a column named Name
        Name.DataType = System.Type.GetType("System.String")
        Amt.DataType = System.Type.GetType("System.String")
        'setting the datatype for the column
        SumAllDt.Columns.Add(Name)
        SumAllDt.Columns.Add(Amt)
        'adding the column to table

        Dim Row1, Row1_1, Row1_2, Row1_3, Row1_4, Row1_5, Row1_6, Row2, Row3, Row4, Row5, Row6, Row7, Row8, Row9, Row10, Row11 As DataRow

        Row1 = SumAllDt.NewRow
        Row1.Item("項目") = "1.業績獎金："
        Row1.Item("金額") = MoneySum_1
        SumAllDt.Rows.Add(Row1)

        Row1_1 = SumAllDt.NewRow
        Row1_1.Item("項目") = "1.1.月銷售總金額已扣退折："
        Row1_1.Item("金額") = Money1_1.Text
        SumAllDt.Rows.Add(Row1_1)

        If Money1_6.Text <> "" Then
            Row1_6 = SumAllDt.NewRow
            Row1_6.Item("項目") = Money1_6.Text
            'Row1_6.Item("金額") = Money1_5.Text
            SumAllDt.Rows.Add(Row1_6)
        End If

        Row1_2 = SumAllDt.NewRow
        Row1_2.Item("項目") = "1.2.超過600萬發6000元："
        Row1_2.Item("金額") = Money1_2.Text
        SumAllDt.Rows.Add(Row1_2)

        Row1_3 = SumAllDt.NewRow
        Row1_3.Item("項目") = "1.3.每增加100萬加1500元："
        Row1_3.Item("金額") = Money1_3.Text
        SumAllDt.Rows.Add(Row1_3)

        Row1_4 = SumAllDt.NewRow
        Row1_4.Item("項目") = "1.4.餘額*0.0015 ："
        Row1_4.Item("金額") = Money1_4.Text
        SumAllDt.Rows.Add(Row1_4)

        Row1_5 = SumAllDt.NewRow
        Row1_5.Item("項目") = "1.5.調禮品金額*20*0.0015："
        Row1_5.Item("金額") = Money1_5.Text
        SumAllDt.Rows.Add(Row1_5)

        Row2 = SumAllDt.NewRow
        Row2.Item("項目") = "2.新客戶獎金："
        Row2.Item("金額") = Money2.Text
        SumAllDt.Rows.Add(Row2)

        Row3 = SumAllDt.NewRow
        Row3.Item("項目") = "3.貨款回收獎金："
        Row3.Item("金額") = Money3.Text
        SumAllDt.Rows.Add(Row3)

        Row4 = SumAllDt.NewRow
        Row4.Item("項目") = "4.呆倒帳："
        Row4.Item("金額") = Money4.Text
        SumAllDt.Rows.Add(Row4)

        Row5 = SumAllDt.NewRow
        Row5.Item("項目") = "5.電話費補助："
        Row5.Item("金額") = Money5.Text
        SumAllDt.Rows.Add(Row5)

        Row6 = SumAllDt.NewRow
        Row6.Item("項目") = "6.回收空籃獎金："
        Row6.Item("金額") = Money6.Text
        SumAllDt.Rows.Add(Row6)

        Row7 = SumAllDt.NewRow
        Row7.Item("項目") = "7.代送貨運費補助："
        Row7.Item("金額") = Money7.Text
        SumAllDt.Rows.Add(Row7)

        Row8 = SumAllDt.NewRow
        Row8.Item("項目") = "8.油資補貼："
        Row8.Item("金額") = Money8.Text
        SumAllDt.Rows.Add(Row8)

        Row9 = SumAllDt.NewRow
        Row9.Item("項目") = "9.額外加項：" + AddComm.Text
        Row9.Item("金額") = Money9.Text
        SumAllDt.Rows.Add(Row9)

        Row10 = SumAllDt.NewRow
        Row10.Item("項目") = "10.額外扣項：" + SubComm.Text
        Row10.Item("金額") = Money10.Text
        SumAllDt.Rows.Add(Row10)

        Row11 = SumAllDt.NewRow
        Row11.Item("項目") = "本月應發獎金："
        Row11.Item("金額") = MoneySumAll
        SumAllDt.Rows.Add(Row11)

        SumAllDGV.DataSource = SumAllDt

        For Each column As DataGridViewColumn In SumAllDGV.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
            column.Visible = True

            Select Case column.Name
                Case "項目"
                    column.DisplayIndex = 0
                    column.HeaderText = "項目"
                Case "金額"
                    column.DisplayIndex = 1
                    column.HeaderText = "金額"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        SumAllDGV.AutoResizeColumns()

    End Sub
End Class