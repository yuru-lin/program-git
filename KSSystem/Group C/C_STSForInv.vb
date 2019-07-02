Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_STSForInv
    Dim ksDataSetDGV2 As DataSet = New DataSet

    Private Sub C_STSForInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemCode.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            If txtItemCode.TextLength > 1 Then
                If Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemCode.TextChanged
        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If


        Loading.Show()
        MsgBox("由於資料龐大，請耐心等待。", 64, "貼心提醒")
        setDGV1Load()
    End Sub

    Private Sub setDGV1Load()
        Dim ic As String
        ic = txtItemCode.Text

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql, sql2 As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        sql = "L20111229_STSForInv"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.CommandTimeout = 100000
        SQLCmd.Parameters.Add(New SqlParameter("@FromDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ToDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ic", SqlDbType.NVarChar))
        SQLCmd.Parameters("@FromDate").Value = FromDate.Value.Date
        SQLCmd.Parameters("@ToDate").Value = ToDate.Value.Date
        SQLCmd.Parameters("@ic").Value = ic
        SQLCmd.ExecuteNonQuery()

        sql2 = "Select T0.m1 as '存編',T0.m2 as '品名',T0.m3 as '批序號管理',T0.m4 as '庫存單位',T0.m5 as '收貨採購單數量',T0.m6 as '收貨採購單重量',T0.m7 as '收貨單數量',T0.m8 as '收貨單重量',T0.m9 as '發貨單數量',T0.m10 as '發貨單重量',T0.m11 as '交貨單數量',T0.m12 as '交貨單重量',T0.m13 as '銷售退貨單數量',T0.m14 as '銷售退貨單重量',T0.m15 as 'AR貸項通知單數量',T0.m16 as 'AR貸項通知單重量',T0.m17 as '採購退貨單數量',T0.m18 as '採購退貨單重量',T0.m19 as 'AP貸項通知單數量',T0.m20 as 'AP貸項通知單重量',T0.m21 as '期末數量',T0.m22 as '期末重量' From [@STSForInv] T0"

        SQLCmd2.Connection = DBConn
        SQLCmd2.CommandText = sql2

        DataAdapter1 = New SqlDataAdapter(sql2, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT1")

        DGV1.DataSource = ksDataSetDGV2.Tables("DT1")

        setDGV1Display()
    End Sub

    Private Sub setDGV1Display()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "存編"
                    column.DisplayIndex = 0
                    column.Frozen = True
                Case "品名"
                    column.DisplayIndex = 1
                    column.Frozen = True
                    column.DividerWidth = 3
                Case "批序號管理"
                    column.DisplayIndex = 2
                Case "庫存單位"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Case "收貨採購單數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "收貨採購單重量"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"

                Case "收貨單數量"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "收貨單重量"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"

                Case "發貨單數量"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "發貨單重量"
                    column.DisplayIndex = 9
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"

                Case "交貨單數量"
                    column.DisplayIndex = 10
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "交貨單重量"
                    column.DisplayIndex = 11
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"


                Case "銷售退貨單數量"
                    column.DisplayIndex = 12
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "銷售退貨單重量"
                    column.DisplayIndex = 13
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"

                Case "AR貸項通知單數量"
                    column.DisplayIndex = 14
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "AR貸項通知單重量"
                    column.DisplayIndex = 15
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"

                Case "採購退貨單數量"
                    column.DisplayIndex = 16
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "採購退貨單重量"
                    column.DisplayIndex = 17
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"


                Case "AP貸項通知單數量"
                    column.DisplayIndex = 18
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "AP貸項通知單重量"
                    column.DisplayIndex = 19
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"


                Case "期末數量"
                    column.DisplayIndex = 20
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
                Case "期末重量"
                    column.DisplayIndex = 21
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.####"
              

                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()


        Loading.Close()
        MsgBox("查詢已完成，謝謝您的耐心等候!!", 64, "貼心提醒")


    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged
        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If

        If RB1.Checked = True Then
            FromDate.Enabled = False
            FromDate.Value = "2010.12.31"
        Else
            FromDate.Enabled = True
            FromDate.Value = Today.Date
        End If
    End Sub
End Class