Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 快速回填生產訂單v001
    Dim DataAdapterDGV, DataAdapter1 As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim 查詢 As String = "N"


    Private Sub B_QckUpdateOWOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
        SelectU_M1()

        Select Case IDNumber.ToUpper()
            Case "KS13" ', "MANAGER"
                Me.TabControl1.SelectedTab = Me.TabPage2
            Case Else
                Me.TabControl1.SelectedTab = Me.TabPage1
        End Select

        lbM03.Text = ""
        lbDocNum.Text = ""
        Lt日期.Text = ""

    End Sub

    Private Sub txtM8_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtM8.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtM9_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtM9.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtM12_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtM12.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        SearchQry()
        If cmbU_M01.Text = "領改-工" Then
            Gb領改日期.Visible = True
            查詢 = "Y"
        Else
            Gb領改日期.Visible = False
            查詢 = "N"
        End If
        lbM03.Text = ""
        lbDocNum.Text = ""
        Lt日期.Text = ""
    End Sub

    Private Sub lbM03_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbM03.TextChanged
        If 查詢 = "Y" And lbM03.Text <> "" Then
            DGV2查詢()
            DGV2作業1()
            DGV2.AutoResizeColumns()
        End If
    End Sub

    Private Sub DGV2查詢()
        If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("明細").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = "" : Dim Type As String = ""
        SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_製單查詢01v] '4','','" & lbM03.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "明細") : DGV2.DataSource = ks1DataSetDGV.Tables("明細")
            For i As Integer = 0 To DGV2.ColumnCount - 1
                DGV2.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        Catch ex As Exception
            MsgBox("查詢異常：" & ex.Message)
        End Try

    End Sub

    Private Sub DGV2作業1()
        If DGV2.RowCount > 0 Then
            '資料 = "有"
            DGV2.CurrentCell = DGV2.Rows(0).Cells(0)
            DGV2作業2()
        Else
            Lt日期.Text = ""
        End If

    End Sub

    Private Sub DGV2作業2()
        Lt日期.Text = DGV2.CurrentRow.Cells("生產日期").Value
    End Sub

    Private Sub Bu回存日期_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu回存日期.Click
        If Lt日期.Text <> "" Then
            回存日期()
        End If
    End Sub

    Private Sub 回存日期()

        Dim SQLUPDATE As String = ""
        SQLUPDATE = "  UPDATE [OWOR] SET [U_M13] = '" & Lt日期.Text & "' "
        SQLUPDATE += "  WHERE [DocNum] = '" & lbDocNum.Text & "' AND [U_M03] = '" & lbM03.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLUPDATE : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("回存日期錯誤： " & ex.Message)
            Exit Sub
        End Try
        DGV1.CurrentRow.Cells("領改日期").Value = Lt日期.Text

    End Sub

    Private Sub SearchQry()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If cmbU_M01.SelectedIndex < 0 Then
            MsgBox("未選生產選項!", 16, "錯誤")
            Exit Sub
        End If

        Dim strU_M1 As String = cmbU_M01.SelectedValue.ToString

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT T0.[DocNum], T0.[DueDate], T1.Descr as '生產選項', T0.[U_M03],case T0.[U_M04] when 'Y' then '是' when 'N' then '否' end as '隱藏製單' ,T0.[U_M07], T0.[U_M08], T0.[U_M09], T0.[U_M10], T0.[U_M12],T0.[PlannedQty] FROM OWOR T0 left join UFD1 T1 ON T0.U_M01 = T1.FldValue and T1.TableID = 'OWOR' and T1.FieldID = '0' WHERE T0.[U_M01] = ('" & strU_M1 & "') and  T0.[DueDate] = '" & DocDate.Value.Date & "'"
            sql = " SELECT T0.[DocNum], T0.[DueDate], T1.[Descr] AS '生產選項', T0.[U_M03], CASE T0.[U_M04] WHEN 'Y' THEN '是' WHEN 'N' THEN '否' END AS '隱藏製單' , "
            sql += "       T0.[U_M07], T0.[U_M08], T0.[U_M09], T0.[U_M10], T0.[U_M12], T0.[PlannedQty], T2.[MOQ], T0.[U_Cnum] AS '契養批號', "
            sql += "       T0.[U_M13] AS '領改日期' "
            sql += "  FROM [OWOR] T0 LEFT JOIN [UFD1] T1 ON T0.[U_M01] = T1.[FldValue] and T1.[TableID] = 'OWOR' and T1.[FieldID] = '0' "
            sql += "                 LEFT JOIN (SELECT T0.[FI102], COUNT (T0.[FI106]) AS 'MOQ' FROM [@FinishItem1] T0 "
            sql += "                             WHERE SUBSTRING(T0.[FI102],1,1) = ('" & strU_M1 & "') AND SUBSTRING(T0.[FI107],1,2) IN ('25','31') AND T0.[FI103] IN ('1','2','3','4') "
            sql += "                             GROUP BY T0.[FI102]) T2 ON T0.[U_M03] = T2.[FI102] "
            sql += " WHERE T0.[Status] IN ('R','L') AND T0.[U_M01] = ('" & strU_M1 & "') AND T0.[DueDate] = '" & DocDate.Value.Date & "'"
            sql += " ORDER BY T0.[U_M03] "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

        Select Case IDNumber.ToUpper()
            Case "KS13"
                DGV1Display1()
            Case Else
                DGV1Display()
        End Select

    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "DocNum"
                    column.HeaderText = "文件號碼"
                    column.DisplayIndex = 0

                Case "DueDate"
                    column.HeaderText = "到期日"
                    column.DisplayIndex = 1

                Case "生產選項"
                    column.HeaderText = "生產選項"
                    column.DisplayIndex = 2

                Case "U_M03"
                    column.HeaderText = "製單編號"
                    column.DisplayIndex = 3

                Case "隱藏製單"
                    column.HeaderText = "隱藏製單"
                    column.DisplayIndex = 4

                Case "U_M07"
                    column.HeaderText = "投入重量"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.##"
                Case "U_M08"
                    column.HeaderText = "死亡隻數"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                Case "U_M09"
                    column.HeaderText = "廢棄隻數"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                Case "U_M10"
                    column.HeaderText = "會磅重量"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.##"
                Case "U_M12"
                    column.HeaderText = "投入隻數"
                    column.DisplayIndex = 9
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                Case "PlannedQty"
                    column.HeaderText = "計劃數量"
                    column.DisplayIndex = 10
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                Case "MOQ"
                    column.HeaderText = "件數"
                    column.DisplayIndex = 11
                Case "契養批號"
                    column.HeaderText = "契養批號"
                    column.DisplayIndex = 12
                    column.Visible = False

                Case "領改日期"
                    column.HeaderText = "領改日期"
                    column.DisplayIndex = 13
                    If cmbU_M01.Text = "領改-工" Then
                        column.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
        End If

    End Sub

    Private Sub DGV1Display1()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "DocNum"
                    column.HeaderText = "文件號碼"
                    column.DisplayIndex = 0

                Case "DueDate"
                    column.HeaderText = "到期日"
                    column.DisplayIndex = 1

                Case "生產選項"
                    column.HeaderText = "生產選項"
                    column.DisplayIndex = 2

                Case "U_M03"
                    column.HeaderText = "製單編號"
                    column.DisplayIndex = 3

                Case "契養批號"
                    column.HeaderText = "契養批號"
                    column.DisplayIndex = 4

                Case "隱藏製單"
                    column.HeaderText = "隱藏製單"
                    column.DisplayIndex = 5
                    column.Visible = False

                Case "U_M07"
                    column.HeaderText = "投入重量"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.##"
                    column.Visible = False
                Case "U_M08"
                    column.HeaderText = "死亡隻數"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                    column.Visible = False
                Case "U_M09"
                    column.HeaderText = "廢棄隻數"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                    column.Visible = False
                Case "U_M10"
                    column.HeaderText = "會磅重量"
                    column.DisplayIndex = 9
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.##"
                    column.Visible = False
                Case "U_M12"
                    column.HeaderText = "投入隻數"
                    column.DisplayIndex = 10
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                    column.Visible = False
                Case "PlannedQty"
                    column.HeaderText = "計劃數量"
                    column.DisplayIndex = 11
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###"
                    column.Visible = False
                Case "MOQ"
                    column.HeaderText = "件數"
                    column.DisplayIndex = 12
                    column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
        End If

    End Sub

    Private Sub DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        lbDocNum.Text = DGV1.CurrentRow.Cells("DocNum").Value
        lbM03.Text = DGV1.CurrentRow.Cells("U_M03").Value
        txtM7.Text = DGV1.CurrentRow.Cells("U_M07").FormattedValue
        txtM8.Text = DGV1.CurrentRow.Cells("U_M08").FormattedValue
        txtM9.Text = DGV1.CurrentRow.Cells("U_M09").FormattedValue
        txtM10.Text = DGV1.CurrentRow.Cells("U_M10").FormattedValue
        txtM12.Text = DGV1.CurrentRow.Cells("U_M12").FormattedValue
        txtPlannedQty.Text = DGV1.CurrentRow.Cells("PlannedQty").FormattedValue
        CalcBtn.Text = "計算" & DGV1.CurrentRow.Cells("U_M03").Value & "產出率"
        txtM02.Text = DGV1.CurrentRow.Cells("MOQ").FormattedValue

        If DGV1.CurrentRow.Cells("隱藏製單").FormattedValue = "是" Then
            CkBoxM04.Checked = True
        Else
            CkBoxM04.Checked = False
        End If

    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If lbM03.Text = "" Then
            MsgBox("資料未選!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要更新至SAP B1 ?" & vbCrLf & "單號：" & lbDocNum.Text + vbCrLf & "製單：" & lbM03.Text, 36, "更新")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oProductionOrders As SAPbobsCOM.ProductionOrders
        Dim RetVal As Long

        oProductionOrders = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders)

        oProductionOrders.GetByKey(lbDocNum.Text)
        oProductionOrders.UserFields.Fields.Item("U_M02").Value = txtM02.Text
        oProductionOrders.UserFields.Fields.Item("U_M07").Value = txtM7.Text
        oProductionOrders.UserFields.Fields.Item("U_M08").Value = txtM8.Text
        oProductionOrders.UserFields.Fields.Item("U_M09").Value = txtM9.Text
        oProductionOrders.UserFields.Fields.Item("U_M10").Value = txtM10.Text
        oProductionOrders.UserFields.Fields.Item("U_M12").Value = txtM12.Text
        oProductionOrders.PlannedQuantity = txtPlannedQty.Text

        If CkBoxM04.Checked = True Then
            oProductionOrders.UserFields.Fields.Item("U_M04").Value = "Y"
        Else
            oProductionOrders.UserFields.Fields.Item("U_M04").Value = "N"
        End If

        RetVal = oProductionOrders.Update()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("更新至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        'MsgBox("更新至B1完成!!" & vbCrLf & "單號：" & lbDocNum.Text, 64, "完成")

        ClearAll()
        SearchQry()
    End Sub

    Private Sub SaveBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn2.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If lbM03.Text = "" Then
            MsgBox("製單未選!", 16, "錯誤")
            Exit Sub
        End If

        If UCnum.Text = "" Then
            MsgBox("契養批號未輸入!", 16, "錯誤")
            Exit Sub
        End If

        UPDATE契養批號()

        lbDocNum.Text = ""
        lbM03.Text = ""
        UCnum.Text = ""
    End Sub

    Private Sub ClearAll()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
        lbDocNum.Text = ""
        lbM03.Text = ""
        txtM02.Text = ""
        txtM7.Text = ""
        txtM8.Text = ""
        txtM9.Text = ""
        txtM10.Text = ""
        txtM12.Text = ""
        txtPlannedQty.Text = ""
        CkBoxM04.Checked = False
        CalcBtn.Text = "計算產出率"
    End Sub

    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcBtn.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If
        If lbM03.Text = "" Then
            MsgBox("資料未選!", 16, "錯誤")
            Exit Sub
        End If

        Select Case cmbU_M01.SelectedValue
            Case "1", "4"
                計算產出率v001.Source = "QckUpdateOWOR"
            Case "2", "3", "5", "6", "D", "X"
                計算產出率v001.Source = "QckUpdateOWOR2"
            Case Else
                MsgBox("該生產選項無法在此計算產出率!", 16, "錯誤")
                Exit Sub
        End Select
        計算產出率v001.MdiParent = MainForm
        計算產出率v001.txtM03.Text = lbM03.Text
        計算產出率v001.Show()

    End Sub

    Private Sub SelectU_M1()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "select T0.FldValue , T0.Descr From UFD1 T0 Where T0.TableID = 'OWOR' and T0.FieldID = '0'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSetDGV, "U_M1")

        cmbU_M01.DataSource = ks1DataSetDGV.Tables("U_M1")
        cmbU_M01.DisplayMember = "Descr"
        cmbU_M01.ValueMember = "FldValue"
        cmbU_M01.SelectedIndex = -1

    End Sub

    Private Sub cmbU_M01_SelectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbU_M01.SelectedIndexChanged
        ClearAll()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If lbM03.Text = "" Then
            MsgBox("資料未選!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要更新至SAP B1 ?" & vbCrLf & "單號：" & lbDocNum.Text + vbCrLf & "製單：" & lbM03.Text, 36, "更新")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        UPDATE製單啟用()

    End Sub

    Private Sub UPDATE契養批號()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Dim strSET1 As String = ""
        Dim strSET2 As String = ""

        Try
            strSET1 += "[U_Cnum] = '" & UCnum.Text & "' " : strSET2 = UCnum.Text

            sql = "  UPDATE [OWOR] SET "
            sql += strSET1
            sql += "  WHERE [DocNum] = '" & lbDocNum.Text & "' AND [U_M03] = '" & lbM03.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新契養批號失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        DGV1.CurrentRow.Cells("契養批號").Value = strSET2
        MsgBox("更新契養批號完成!", 64, "成功")
    End Sub

    Private Sub UPDATE製單啟用()
        'UPDATE製單啟用
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Dim strSET1 As String = ""
        Dim strSET2 As String = ""

        Try
            If CkBoxM04.Checked = True Then '  'Y' = '是', 'N' = '否
                strSET1 += "[U_M04] = 'Y'" : strSET2 = "是"
            Else
                strSET1 += "[U_M04] = 'N'" : strSET2 = "否"
            End If

            sql = "  UPDATE [OWOR] SET "
            sql += strSET1
            sql += "  WHERE [DocNum] = '" & lbDocNum.Text & "' AND [U_M03] = '" & lbM03.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        DGV1.CurrentRow.Cells("隱藏製單").Value = strSET2
        MsgBox("更新完成!", 64, "成功")
    End Sub



End Class