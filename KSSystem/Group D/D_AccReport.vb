Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_AccReport
    Dim ksDataSetDGV2 As DataSet = New DataSet

    Private Sub D_AccReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub DocType_SelectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DocType.SelectedIndexChanged
        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        If DocType.SelectedIndex <= -1 Then
            MsgBox("請選擇文件類型!")
            DocType.Focus()
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "exec L20110923 '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "' ,'" & DocType.SelectedIndex & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandTimeout = 6000
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT1")

        DGV1.DataSource = ksDataSetDGV2.Tables("DT1")

        setDGV1Display()
    End Sub

    Private Sub setDGV1Display()


        Dim DocNum As String
        Dim LineNum As String
        Dim TransID As String
        Dim LineID As Integer

        Dim Emp As String = ""

        For i As Integer = 0 To DGV1.RowCount - 1
            If i = 0 Then
                DocNum = DGV1.Rows(i).Cells("文件號碼").Value
                LineNum = DGV1.Rows(i).Cells("LineNum").Value
                If IsDBNull(DGV1.Rows(i).Cells("TransId").Value) Then
                Else
                    TransID = DGV1.Rows(i).Cells("TransId").Value
                    LineID = CInt(DGV1.Rows(i).Cells("Line_ID").Value)
                End If


                Continue For
            End If
            If DGV1.Rows(i).Cells("文件號碼").Value = DocNum Then
                DGV1.Rows(i).Cells("過帳日期").Value = Emp
                If DGV1.Rows(i).Cells("LineNum").Value = LineNum Then
                    DGV1.Rows(i).Cells("LineNum").Value = Emp
                    DGV1.Rows(i).Cells("數量").Value = Emp
                    DGV1.Rows(i).Cells("重量").Value = Emp
                    DGV1.Rows(i).Cells("列總計").Value = Emp
                Else
                    LineNum = DGV1.Rows(i).Cells("LineNum").Value
                End If

                If IsDBNull(DGV1.Rows(i).Cells("TransId").Value) Then
                Else
                    If DGV1.Rows(i).Cells("TransId").Value = TransID Then
                        DGV1.Rows(i).Cells("TransId").Value = Emp
                        If CInt(DGV1.Rows(i).Cells("Line_ID").Value) > LineID Then
                            LineID = CInt(DGV1.Rows(i).Cells("Line_ID").Value)
                        Else
                            DGV1.Rows(i).Cells("Line_ID").Value = Emp
                            DGV1.Rows(i).Cells("借項金額").Value = Emp
                            DGV1.Rows(i).Cells("貸項金額").Value = Emp
                            LineID += 1
                        End If
                    Else
                        TransID = DGV1.Rows(i).Cells("TransId").Value
                    End If
                End If

            Else
                DocNum = DGV1.Rows(i).Cells("文件號碼").Value
                LineNum = DGV1.Rows(i).Cells("LineNum").Value

                If IsDBNull(DGV1.Rows(i).Cells("TransId").Value) Then
                Else
                    TransID = DGV1.Rows(i).Cells("TransId").Value
                    LineID = CInt(DGV1.Rows(i).Cells("Line_ID").Value)
                End If


                Continue For
            End If

        Next


        '文件號碼	過帳日期	LineNum	項目號碼	項目/服務說明	數量	列總計	TransId	Line_ID	科目代碼	科目名稱	借項金額	貸項金額


        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "文件號碼"
                    column.DisplayIndex = 0
                Case "過帳日期"
                    column.DisplayIndex = 1
                Case "項目號碼"
                    column.DisplayIndex = 2
                Case "項目/服務說明"
                    column.DisplayIndex = 3
                Case "庫存單位"
                    column.DisplayIndex = 4
                Case "數量"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "重量"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "列總計"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "倉別"
                    column.DisplayIndex = 8
                Case "科目代碼"
                    column.DisplayIndex = 9
                Case "科目名稱"
                    column.DisplayIndex = 10
                Case "借項金額"
                    column.DisplayIndex = 11
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "貸項金額"
                    column.DisplayIndex = 12
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()



    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click        
        Dim str As String = DocType.Text
        DataToExcel(DGV1, str)
    End Sub
End Class