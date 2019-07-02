Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_JournalCheck
    Dim ksDataSetDGV2 As DataSet = New DataSet

    Private Sub D_JournalCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub DocType_SelectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DocType.SelectedIndexChanged
        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If
        If DGV2.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT2").Clear()
        End If
        If DGV3.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT3").Clear()
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If DocType.SelectedIndex = -1 Then
            MsgBox("請選擇文件類型!")
            DocType.Focus()
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If
        If DGV2.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT2").Clear()
        End If
        If DGV3.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT3").Clear()
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Select Case DocType.SelectedIndex
            Case 0
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM OPDN T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 1
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM OIGN T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 2
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM OIGE T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 3
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM ODLN T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 4
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM ORDN T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 5
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM ORIN T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 6
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM ORPD T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 7
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM ORPC T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum]"
            Case 8
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum] + T0.[DpmAmnt]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM OPCH T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum],  T0.[DpmAmnt]"
            Case 9
                sql = "SELECT T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期', (T0.[DocTotal] - T0.[VatSum] - T0.[DiscSum] + T0.[DpmAmnt]) as '稅前總計', T0.[VatSum] as '稅',T0.[DiscSum] as '折扣', T0.[DocTotal] as '金額',T1.[TransId] as '分錄號碼', T1.[RefDate] as '日期',case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end as '借項',case isnull(sum(T2.[Credit]),0) when 0 then 0 else sum(T2.[Credit]) end as  '貸項',((T0.[DocTotal]) - case isnull(sum(T2.[Debit]),0) when 0 then 0 else sum(T2.[Debit]) end) as '差異' FROM OINV T0  LEFT JOIN OJDT T1 ON T0.TransId = T1.TransId LEFT JOIN JDT1 T2 ON T1.TransId = T2.TransId WHERE T0.[DocDate] between '" & FromDate.Value.Date & "' and  '" & ToDate.Value.Date & "' GROUP BY T0.[DocNum], T0.[DocDate], T0.[DocTotal],T1.[TransId], T1.[RefDate], T0.[VatSum], T0.[DiscSum],  T0.[DpmAmnt]"
        End Select

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT1")

        DGV1.DataSource = ksDataSetDGV2.Tables("DT1")

        setDGV1Display()
    End Sub

    Private Sub setDGV1Display()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "文件號碼"
                    column.DisplayIndex = 0
                Case "過帳日期"
                    column.DisplayIndex = 1
                Case "稅前總計"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "稅"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "折扣"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "金額"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "分錄號碼"
                    column.DisplayIndex = 6
                Case "日期"
                    column.DisplayIndex = 7
                Case "借項"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項"
                    column.DisplayIndex = 9
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "差異"
                    column.DisplayIndex = 10
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select

        Next

        If DocType.SelectedIndex = 8 Or DocType.SelectedIndex = 9 Or DocType.SelectedIndex = 5 Or DocType.SelectedIndex = 7 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Rows(i).Cells("金額").Value <> DGV1.Rows(i).Cells("借項").Value Or DGV1.Rows(i).Cells("金額").Value <> DGV1.Rows(i).Cells("貸項").Value Then
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
        Else
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Rows(i).Cells("稅前總計").Value <> DGV1.Rows(i).Cells("借項").Value Or DGV1.Rows(i).Cells("稅前總計").Value <> DGV1.Rows(i).Cells("貸項").Value Then
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Next
        End If

        Dim Sum_1 As Integer = 0
        Dim Sum_2 As Integer = 0
        Dim Sum_3 As Integer = 0
        Dim Sum_4 As Integer = 0
        Dim Sum_5 As Integer = 0
        Dim Sum_6 As Integer = 0


        For i As Integer = 0 To DGV1.RowCount - 1
            Sum_1 = Sum_1 + DGV1.Rows(i).Cells("稅前總計").Value
            Sum_2 = Sum_2 + DGV1.Rows(i).Cells("稅").Value
            Sum_3 = Sum_3 + DGV1.Rows(i).Cells("折扣").Value
            Sum_4 = Sum_4 + DGV1.Rows(i).Cells("金額").Value
            Sum_5 = Sum_5 + DGV1.Rows(i).Cells("借項").Value
            Sum_6 = Sum_6 + DGV1.Rows(i).Cells("貸項").Value
        Next

        Sum1.Text = Format(Sum_1, "###,##0")
        Sum2.Text = Format(Sum_2, "###,##0")
        Sum3.Text = Format(Sum_3, "###,##0")
        Sum4.Text = Format(Sum_4, "###,##0")
        Sum5.Text = Format(Sum_5, "###,##0")
        Sum6.Text = Format(Sum_6, "###,##0")


        DGV1.Refresh()
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick


        If DGV2.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT2").Clear()
        End If

        If DGV3.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT3").Clear()
        End If


        DocDetail()
        JournalDetail()

    End Sub

    Private Sub DocDetail()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        Select Case DocType.SelectedIndex
            Case 0
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From OPDN T0 inner join PDN1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 1
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From OIGN T0 inner join IGN1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 2
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From OIGE T0 inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 3
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From ODLN T0 inner join DLN1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 4
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From ORDN T0 inner join RDN1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 5
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From ORIN T0 inner join RIN1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 6
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From ORPD T0 inner join RPD1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 7
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From ORPC T0 inner join RPC1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 8
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From OPCH T0 inner join PCH1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
            Case 9
                sql = "SELECT  T0.[DocNum] as '文件號碼', T0.[DocDate] as '過帳日期',T1.ItemCode as '存編',T1.Dscription as '品名',T1.[Quantity] as '數量',T1.[U_p2] as '重量',T1.[LineTotal] as '列總計', T1.[VatSum] as '稅總計',  T1.[GTotal] as '含稅總計' From OINV T0 inner join INV1 T1 ON T0.DocEntry = T1.DocEntry Where T0.DocNum =  '" & DGV1.CurrentRow.Cells("文件號碼").Value & "'"
        End Select

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "文件號碼"
                    column.DisplayIndex = 0
                Case "過帳日期"
                    column.DisplayIndex = 1
                Case "存編"
                    column.DisplayIndex = 2
                Case "品名"
                    column.DisplayIndex = 3
                Case "數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "重量"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "列總計"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "稅總計"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "含稅總計"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.Refresh()
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub JournalDetail()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.[BaseRef] as '文件號碼',T0.[TransId] as '分錄號碼', T0.[RefDate] as '日期',T1.[ShortName] as '科目/業務夥伴', T1.[Account] as '控制科目', T2.[AcctName] as '科目名稱', T1.[Debit] as '借項', T1.[Credit]as  '貸項' , T1.[LineMemo] as  '備註' FROM OJDT T0  INNER JOIN JDT1 T1 ON T0.TransId = T1.TransId INNER JOIN OACT T2 ON T1.Account = T2.AcctCode WHERE T0.[TransId] = '" & DGV1.CurrentRow.Cells("分錄號碼").Value & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT3")

        DGV3.DataSource = ksDataSetDGV2.Tables("DT3")

        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True
            Select Case column.Name
                Case "文件號碼"
                    column.DisplayIndex = 0
                Case "分錄號碼"
                    column.DisplayIndex = 1
                Case "日期"
                    column.DisplayIndex = 2
                Case "'科目/業務夥伴"
                    column.DisplayIndex = 3
                Case "控制科目"
                    column.DisplayIndex = 4
                Case "科目名稱"
                    column.DisplayIndex = 5
                Case "借項"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "備註"
                    column.DisplayIndex = 8
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV3.Refresh()
        DGV3.AutoResizeColumns()

    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        Dim str As String = DocType.Text & "資料"
        DataToExcel(DGV1, str)
    End Sub

    Private Sub ToExcelBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn2.Click
        Dim str As String = DocType.Text & "明細"
        DataToExcel(DGV2, str)
    End Sub

    Private Sub ToExcelBtn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn3.Click
        Dim str As String = DocType.Text & "分錄"
        DataToExcel(DGV3, str)
    End Sub
End Class