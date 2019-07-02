Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_AllJournal
    Dim ksDataSetDGV2 As DataSet = New DataSet

    Private Sub D_AllJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub
    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click


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

        sql = "exec L20110921_1 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' "

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
                Case "會計科代"
                    column.DisplayIndex = 0
                Case "會計科目"
                    column.DisplayIndex = 1
                Case "借項前期"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項前期"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "借項金額"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項金額"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "借項餘額"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項餘額"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "累計淨額"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select

        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = 0 Then
            Exit Sub
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


        sql = "exec L20110921_2 '" & FromDate.Value.Date & "','" & ToDate.Value.Date & "','" & DGV1.CurrentRow.Cells("會計科代").Value & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")
        setDGV2Display()

    End Sub

    Private Sub setDGV2Display()
        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "傳票號碼"
                    column.DisplayIndex = 0
                Case "傳票日期"
                    column.DisplayIndex = 1
                Case "摘要"
                    column.DisplayIndex = 2
                Case "借項金額"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項金額"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "部門"
                    column.DisplayIndex = 5
                Case "部門名稱"
                    column.DisplayIndex = 6
                Case "業務夥伴代碼"
                    column.DisplayIndex = 7
                Case "業務夥伴名稱"
                    column.DisplayIndex = 8

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

        If IsDBNull(DGV2.CurrentRow.Cells("傳票號碼").Value) = True Then
            If DGV3.RowCount > 0 Then
                ksDataSetDGV2.Tables("DT3").Clear()
            End If
            Exit Sub
        End If

        If DGV2.CurrentRow.Cells("傳票號碼").Value = "0000000000" Then
            If DGV3.RowCount > 0 Then
                ksDataSetDGV2.Tables("DT3").Clear()
            End If
            Exit Sub
        End If

        If DGV3.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT3").Clear()
        End If


        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.[TransId] as '文件號碼',T0.[RefDate] as '日期', T1.[Account] as '會計科代', T2.[AcctName] as '會計科目', T1.[Debit] as '借項', T1.[Credit] as '貸項', T1.[LineMemo] as '備註' FROM OJDT T0  INNER JOIN JDT1 T1 ON T0.TransId = T1.TransId INNER JOIN OACT T2 ON T1.Account = T2.AcctCode WHERE T0.[U_A0] = '" & DGV2.CurrentRow.Cells("傳票號碼").Value & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql


        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT3")

        DGV3.DataSource = ksDataSetDGV2.Tables("DT3")
        setDGV3Display()

    End Sub

    Private Sub setDGV3Display()
        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True
            Select Case column.Name
                Case "文件號碼"
                    column.DisplayIndex = 0
                Case "日期"
                    column.DisplayIndex = 1
                Case "會計科代"
                    column.DisplayIndex = 2
                Case "會計科目"
                    column.DisplayIndex = 3
                Case "借項"
                    column.DisplayIndex = 4
                    column.HeaderText = "借項金額"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "貸項"
                    column.DisplayIndex = 5
                    column.HeaderText = "貸項金額"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case "備註"
                    column.DisplayIndex = 6
                    column.HeaderText = "備註"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV3.Refresh()
        DGV3.AutoResizeColumns()

    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        Dim str As String = "總分類帳資料"
        DataToExcel(DGV1, str)
    End Sub

    Private Sub ToExcelBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn2.Click
        Dim str As String = "總分類帳明細"
        DataToExcel(DGV2, str)
    End Sub

    Private Sub ToExcelBtn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn3.Click
        Dim str As String = "總分類帳分錄"
        DataToExcel(DGV3, str)
    End Sub
End Class