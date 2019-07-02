Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_AccMainFrom

    Private Sub D_AccMainFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub AccType_SelectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccType.SelectedIndexChanged

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Select Case AccType.SelectedIndex
            Case 0
                sql = " select T0.AcctCode ,T0.AcctName , (T0.AcctCode + '-' + T0.AcctName) as 'Acct' from [OACT] T0 where T0.AcctCode in ('1141001','2143001','2178001','1151001','2153001','2178004') "
            Case 1
                sql = " select T0.AcctCode ,T0.AcctName , (T0.AcctCode + '-' + T0.AcctName) as 'Acct' from [OACT] T0 where T0.AcctCode in ('1121001','2121001','1131001','2131001') "
            Case 2
                sql = " select T0.AcctCode ,T0.AcctName , (T0.AcctCode + '-' + T0.AcctName) as 'Acct' from [OACT] T0 where T0.AcctCode in ('1262002','2261002','2261003','1261003') "
            Case 3
                sql = " select T0.AcctCode ,T0.AcctName , (T0.AcctCode + '-' + T0.AcctName) as 'Acct' from [OACT] T0 where T0.AcctCode in ('1261001','2261001') "
            Case 4
                sql = " select T0.AcctCode ,T0.AcctName , (T0.AcctCode + '-' + T0.AcctName) as 'Acct' from [OACT] T0 where T0.AcctCode in ('2144001','2154001') "
        End Select

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        AccNum.DataSource = ksDataSet.Tables("DT1")
        AccNum.DisplayMember = "Acct"
        AccNum.ValueMember = "AcctCode"
        AccNum.SelectedIndex = -1


    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If AccType.SelectedIndex = -1 Then
            MsgBox("請選擇科目類型!")
            AccType.Focus()
            Exit Sub
        End If

        If AccNum.SelectedIndex = -1 Then
            MsgBox("請選擇總帳科目!")
            AccNum.Focus()
            Exit Sub
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Select Case AccType.SelectedIndex
            Case 0
                sql = "exec L20110716_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & AccNum.SelectedValue & "'"
            Case 1
                If AccNum.SelectedValue = "1121001" Then
                    sql = "exec L20110716_2 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "
                ElseIf AccNum.SelectedValue = "2121001" Then
                    sql = "exec L20110716_3 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "
                ElseIf AccNum.SelectedValue = "1131001" Then
                    sql = "exec L20110716_6 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "
                ElseIf AccNum.SelectedValue = "2131001" Then
                    sql = "exec L20110716_7 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "
                End If
            Case 2
                sql = "exec L20110716_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & AccNum.SelectedValue & "'"
            Case 3
                sql = "exec L20110716_4 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & AccNum.SelectedValue & "'"
            Case 4
                If AccNum.SelectedValue = "2144001" Then
                    sql = "exec L20110716_5 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "
                ElseIf AccNum.SelectedValue = "2154001" Then
                    sql = "exec L20110716_8 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "
                End If
        End Select

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        DGV1.DataSource = ksDataSet.Tables("DT1")

        Dim TotalSum As Long = 0
        Dim Open_Sum As Long = 0
        Dim Add_Sum As Long = 0
        Dim Sub_Sum As Long = 0

        For i As Integer = 0 To DGV1.RowCount - 1
            TotalSum = TotalSum + DGV1.Rows(i).Cells("期末餘額").Value
            Open_Sum = Open_Sum + DGV1.Rows(i).Cells("期初金額").Value
            Add_Sum = Add_Sum + DGV1.Rows(i).Cells("本期增加").Value
            Sub_Sum = Sub_Sum + DGV1.Rows(i).Cells("本期減少").Value
        Next

        AccSum.Text = Format(TotalSum, "###,##0")
        OpeningSum.Text = Format(Open_Sum, "###,##0")
        AddSum.Text = Format(Add_Sum, "###,##0")
        SubSum.Text = Format(Sub_Sum, "###,##0")

        setDGV1Display()
    End Sub
    Private Sub setDGV1Display()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "客戶編號"
                    column.DisplayIndex = 0
                Case "客戶名稱"
                    column.DisplayIndex = 1
                Case "期初金額"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "本期增加"
                    column.DisplayIndex = 3
                    column.HeaderText = "本期借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "本期減少"
                    column.DisplayIndex = 4
                    column.HeaderText = "本期貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "期末餘額"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()

        For i As Integer = 0 To DGV1.RowCount - 1
            Select Case Microsoft.VisualBasic.Left(AccNum.SelectedValue, 1)
                Case "1"
                    If DGV1.Rows(i).Cells("期末餘額").Value < 0 Then
                        DGV1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(238, 79, 159)
                    End If

                Case "2"
                    If DGV1.Rows(i).Cells("期末餘額").Value > 0 Then
                        DGV1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(238, 79, 159)
                    End If
            End Select
        Next

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = 0 Then
            Exit Sub
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        NameTab.Text = DGV1.CurrentRow.Cells("客戶編號").Value + " - " + DGV1.CurrentRow.Cells("客戶名稱").Value

        Select Case AccType.SelectedIndex
            Case 0
                sql = "exec L20110716_1_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & AccNum.SelectedValue & "','" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
            Case 1

                If AccNum.SelectedValue = "1121001" Then
                    sql = "exec L20110716_2_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
                ElseIf AccNum.SelectedValue = "2121001" Then
                    sql = "exec L20110716_3_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
                ElseIf AccNum.SelectedValue = "1131001" Then
                    sql = "exec L20110716_6_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
                ElseIf AccNum.SelectedValue = "2131001" Then
                    sql = "exec L20110716_7_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
                End If
            Case 2
                sql = "exec L20110716_1_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & AccNum.SelectedValue & "','" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
            Case 3
                sql = "exec L20110716_4_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & AccNum.SelectedValue & "','" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
            Case 4
                If AccNum.SelectedValue = "2144001" Then
                    sql = "exec L20110716_5_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
                ElseIf AccNum.SelectedValue = "2154001" Then
                    sql = "exec L20110716_8_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DGV1.CurrentRow.Cells("客戶編號").Value & "'"
                End If
        End Select

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        DGV2.DataSource = ksDataSet.Tables("DT1")
        setDGV2Display()

    End Sub

    Private Sub setDGV2Display()
        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "傳票編號"
                    column.DisplayIndex = 0
                Case "傳票日期"
                    column.DisplayIndex = 1
                Case "摘要"
                    column.DisplayIndex = 2
                Case "借項"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "結存金額"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.Refresh()
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount = 0 Then
            Exit Sub
        End If

        If IsDBNull(DGV2.CurrentRow.Cells("傳票編號").Value) = True Then
            Exit Sub
        End If

        If DGV2.CurrentRow.Cells("傳票編號").Value = "0000000000" Then
            Exit Sub
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.[TransId], T1.[Account], T2.[AcctName], T1.[Debit], T1.[Credit], T1.[LineMemo] FROM OJDT T0  INNER JOIN JDT1 T1 ON T0.TransId = T1.TransId INNER JOIN OACT T2 ON T1.Account = T2.AcctCode WHERE T0.[U_A0] = '" & DGV2.CurrentRow.Cells("傳票編號").Value & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql


        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        DGV3.DataSource = ksDataSet.Tables("DT1")
        setDGV3Display()

    End Sub

    Private Sub setDGV3Display()
        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True
            Select Case column.Name
                Case "TransId"
                    column.DisplayIndex = 0
                    column.HeaderText = "分錄號碼"
                Case "Account"
                    column.DisplayIndex = 1
                    column.HeaderText = "科目代碼"
                Case "AcctName"
                    column.DisplayIndex = 2
                    column.HeaderText = "科目名稱"
                Case "Debit"
                    column.DisplayIndex = 3
                    column.HeaderText = "借項金額"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "Credit"
                    column.DisplayIndex = 4
                    column.HeaderText = "貸項金額"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "LineMemo"
                    column.DisplayIndex = 5
                    column.HeaderText = "摘要"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV3.Refresh()
        DGV3.AutoResizeColumns()

    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        Dim str As String = AccType.Text & AccNum.Text & "資料"
        DataToExcel(DGV1, str)
    End Sub

    Private Sub ToExcelBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn2.Click
        Dim str As String = AccType.Text & AccNum.Text & "明細"
        DataToExcel(DGV2, str)
    End Sub

    Private Sub ToExcelBtn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn3.Click
        Dim str As String = AccType.Text & AccNum.Text & "分錄"
        DataToExcel(DGV3, str)
    End Sub
End Class