Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_生產入庫舊
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim SyncAns As Boolean
    Dim InType As String
    '設定可回傳日期_Phil_20140303
    Dim btnToB1FT As String = "False"
    Dim Datess1 As Integer
    Dim Datess2 As Integer


    Private Sub C_生產入庫舊_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceList.ContextMenuStrip = MainForm.ContextMenuStrip1

        收貨類型.Text = ""

        If Login.LoginType = 2 Then
            btnToB1.Enabled = False
        End If

        '設定可回傳日期 manager 90天前、一般使用者 10天_Phil_20140303
        If UCase(Login.LogonUserName) = "MANAGER" Then
            Datess1 = -90 : Datess2 = 90
        Else
            Datess1 = -10 : Datess2 = 10
        End If

        '隱藏設定 非manager 無法看見
        If UCase(Login.LogonUserName) = "MANAGER" Then
            LP01_del.Visible = True : TP01_del.Visible = True : BP01_del.Visible = True : TP01_del.Text = ""
            btnForError.Visible = True
        End If
        If UCase(Login.LogonUserName) = "KS09" Then
            LP01_del.Visible = True : TP01_del.Visible = True : BP01_del.Visible = True : TP01_del.Text = ""
        End If

        cobSelectType.SelectedIndex = 0
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged
        ClearAll()
    End Sub

    Private Sub cobSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSelectType.SelectedIndexChanged
        Select Case cobSelectType.SelectedIndex
            Case "0"
                InType = "1"
                收貨類型.Text = "生產收貨"
            Case "1"
                InType = "12"
                收貨類型.Text = "委外加工收貨"
            Case Else
                InType = "1"
                收貨類型.Text = "生產收貨"
        End Select
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        ClearAll()

        LoadSourceMain()
    End Sub

    '依作業類別載入欲入庫製單號, 並指派給dgvSourceMain
    Private Sub LoadSourceMain()
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If RB1.Checked = True Then
                If Login.LogonCompanyDB = "zDouliou" Then
                    sql = "SELECT distinct [@FI1Main].[FI101], [@FI1Main].[FI102] FROM [@FI1Main] INNER JOIN [@FinishItem1] ON [@FI1Main].[FI101] = [@FinishItem1].[FI101] WHERE ([@FI1Main].[FI103] = '3') AND [@FinishItem1].[FI103] = '3' "
                Else
                    sql = "SELECT distinct [@FI1Main].[FI101], [@FI1Main].[FI102] FROM [@FI1Main] INNER JOIN [@FinishItem1] ON [@FI1Main].[FI101] = [@FinishItem1].[FI101] WHERE ([@FI1Main].[FI103] = '3') AND [@FinishItem1].[FI103] = '3' AND (SUBSTRING([@FI1Main].[FI102],8,2) <> '99') AND SUBSTRING([@FinishItem1].[FI102],8,2) <> '99' "
                End If
            End If

            If RB2.Checked = True Then
                sql = "SELECT distinct [@FI2Main].FI101, [@FI2Main].FI102 FROM [@FI2Main] INNER JOIN [@FinishItem2] ON [@FI2Main].FI101 = [@FinishItem2].FI101 WHERE ([@FI2Main].FI103 = '3') and [@FinishItem2].FI103 = '3'"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                Case "FI102"
                    column.HeaderText = "製單單號"
                    column.DisplayIndex = 1
                Case "FI101"
                    column.HeaderText = "生產單號"
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvSourceMain.AutoResizeColumns()
        If dgvSourceMain.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub dgvSourceMain_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick
        '建立生產明細單
        If dgvSourceMain.RowCount = 0 Then
            Exit Sub
        End If

        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        Dim FI102 As String = dgvSourceMain.CurrentRow.Cells("FI102").Value
        'If Microsoft.VisualBasic.Left(FI102, 1) = "D" Then
        '    ckbWhs.Checked = True
        'Else
        '    ckbWhs.Checked = False
        'End If

        'If Mid(dgvSourceMain.CurrentRow.Cells("FI102").Value, 1, 1) = "C" Then   -20140715_停用
        '    cobSelectType.SelectedIndex = 1
        'Else
        '    cobSelectType.SelectedIndex = 0
        'End If

        Dim a As Date = DateSerial("20" + Microsoft.VisualBasic.Mid(dgvSourceMain.CurrentRow.Cells("FI101").Value, 3, 2), Microsoft.VisualBasic.Mid(dgvSourceMain.CurrentRow.Cells("FI101").Value, 5, 2), Microsoft.VisualBasic.Mid(dgvSourceMain.CurrentRow.Cells("FI101").Value, 7, 2))

        DocDate.Text = a
        Label7.Visible = False

        LoadSourceList()               '載入選取製單之生產明細單        
    End Sub

    '載入點選製單之明細資料至Dataset並設定為dgvSourceList顯示來源
    Private Sub LoadSourceList()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            If RB1.Checked = True Then
                'sql = "SELECT distinct [@FinishItem1].[FI102], [@FinishItem1].[FI106], [@FinishItem1].[FI107], [@FinishItem1].[FI108], [@FinishItem1].[FI109], [@FinishItem1].[FI111], [@FinishItem1].[FI118], [@FinishItem1].[FI119], [@FinishItem1].[FI117], case [@FinishItem1].[FI103] when '3' then '已清點' else '未清點' end 狀態, [@FinishItem1].[FI103], [@ksPDAIn].[PDA04] from [@FinishItem1] INNER JOIN [@ksPDAIn] ON [@FinishItem1].[FI106] = [@ksPDAIn].[PDA03] WHERE [@FinishItem1].[FI101] = '" & dgvSourceMain.CurrentRow.Cells("FI101").Value & "' AND [@FinishItem1].[FI103] = '3' AND left([@ksPDAIn].[PDA02],2) = '11' "
                sql = "     SELECT DISTINCT T0.[FI102], T0.[FI106], T0.[FI107], T0.[FI108], T0.[FI109], T0.[FI111], T0.[FI118], T0.[FI119], T0.[FI117] , "
                sql += "           CASE T0.[FI103] WHEN '3' THEN '已清點' ELSE '未清點' END '狀態' ,T0.[FI103], T1.[PDA04] "
                sql += "      FROM [@FinishItem1] T0 INNER JOIN"
                sql += "   (SELECT DISTINCT LEFT(T1.[PDA02],2) AS 'PDA02', T1.[PDA03], T1.[PDA04] FROM [@ksPDAIn] T1 WHERE LEFT(T1.[PDA02],2) = '11' AND [PDA06] = '2') T1 ON T0.[FI106] = T1.[PDA03] "
                sql += "     WHERE T0.[FI101] = '" & dgvSourceMain.CurrentRow.Cells("FI101").Value & "' AND T0.[FI103] = '3'"
            End If

            If RB2.Checked = True Then
                sql = "SELECT distinct [@FinishItem2].[FI102], [@FinishItem2].[FI106], [@FinishItem2].[FI107], [@FinishItem2].[FI108], [@FinishItem2].[FI109], [@FinishItem2].[FI111], [@FinishItem2].[FI118], [@FinishItem2].[FI119], [@FinishItem2].[FI117], case [@FinishItem2].[FI103] when '3' then '已清點' else '未清點' end 狀態, [@FinishItem2].[FI103], [@ksPDAIn].[PDA04] from [@FinishItem2] INNER JOIN [@ksPDAIn] ON [@FinishItem2].[FI106] = [@ksPDAIn].[PDA03] WHERE [@FinishItem2].[FI101] = '" & dgvSourceMain.CurrentRow.Cells("FI101").Value & "' AND [@FinishItem2].[FI103] = '3' AND left([@ksPDAIn].[PDA02],2) = '12' "
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT2")
            dgvSourceList.DataSource = ks1DataSet.Tables("DT2")
        Catch ex As Exception
            MsgBox("LoadSourceList: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In dgvSourceList.Columns
            column.Visible = True
            Select Case column.HeaderText
                Case "FI106", "條碼"
                    column.HeaderText = "條碼"
                    column.DisplayIndex = 1
                Case "FI107", "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 2
                Case "FI108", "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 3
                Case "狀態"
                    column.HeaderText = "狀態"
                    column.DisplayIndex = 4
                Case "PDA04", "儲位"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 5
                Case "FI117", "重量"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvSourceList.Refresh()
        dgvSourceList.AutoResizeColumns()
        Label3.Text = dgvSourceList.RowCount
        If dgvSourceList.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        Else
            Label7.Visible = True
        End If

    End Sub

    Private Sub DocDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocDate.ValueChanged

        Dim ans As Long = DateDiff(DateInterval.Day, Date.Now, DocDate.Value.Date)

        '設定可回傳日期_Phil_20140303
        btnToB1FT = "True"
        If ans < Datess1 Then
            MsgBox("日期不能小於 " & Datess2 & "天!", 48, "警告")
            DocDate.Value = Today()
            DocDate.Focus()
            btnToB1FT = "False"
        End If
    End Sub

    Private Sub btnToB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToB1.Click

        '設定可回傳日期_Phil_20140303
        If btnToB1FT = "False" Then
            MsgBox("日期不能小於 " & Datess2 & "天!無法回傳", 48, "警告")
            Exit Sub
        End If

        If dgvSourceList.RowCount = 0 Then
            MsgBox("沒有任何條碼可以傳!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        Dim Str As String = dgvSourceMain.CurrentRow.Cells("FI102").Value

        If Mid(dgvSourceMain.CurrentRow.Cells("FI102").Value, 1, 1) = "C" Then

        Else
            If Str.Substring(3, 2) <> Format(DocDate.Value.Date, "MM") Then
                Dim oAns As Integer
                oAns = MsgBox("此製單並不是當月製單!" & vbCrLf & "此製單將會入到今日，並請至B1內回填原因。" & vbCrLf & "確認要轉入B1 ?", 36, "警告")
                If oAns = MsgBoxResult.No Then
                    Exit Sub
                Else
                    'DocDate.Value = Today
                End If
            End If
        End If

        PBar1.Minimum = 0
        PBar1.Maximum = dgvSourceList.Rows.Count - 1
        SyncToSAP()
    End Sub

    Private Sub SyncToSAP()

        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim Codess As String = ""

        Dim vDoc As SAPbobsCOM.Documents
        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)

        vDoc.UserFields.Fields.Item("U_CK02").Value = dgvSourceMain.CurrentRow.Cells("FI102").Value '製單號
        vDoc.UserFields.Fields.Item("U_CK06").Value = InType '收貨目地
        vDoc.DocDate = DocDate.Value.Date

        If RB1.Checked = True Then
            For i As Integer = 0 To dgvSourceList.RowCount - 1
                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = dgvSourceList.Rows(i).Cells("FI107").Value '項目號碼
                Codess = dgvSourceList.Rows(i).Cells("FI107").Value '錯誤項目號碼
                vDoc.Lines.Quantity = 1

                If ckbWhs.Checked = True Then  '指定庫別, 無指定時入預設庫別
                    vDoc.Lines.WarehouseCode = tbxWhsCode.Text
                End If

                If IsDBNull(dgvSourceList.Rows(i).Cells("FI118").FormattedValue) Then '重為空白或NULL時
                Else
                    vDoc.Lines.UserFields.Fields.Item("U_p2").Value = dgvSourceList.Rows(i).Cells("FI118").FormattedValue  '重量
                End If

                vDoc.Lines.SerialNumbers.SetCurrentLine(0)
                vDoc.Lines.SerialNumbers.InternalSerialNumber = dgvSourceList.Rows(i).Cells("FI106").Value '條碼
                vDoc.Lines.SerialNumbers.ManufactureDate = dgvSourceList.Rows(i).Cells("FI109").Value '實際製造日期 
                vDoc.Lines.SerialNumbers.ExpiryDate = dgvSourceList.Rows(i).Cells("FI111").Value '有效日期
                vDoc.Lines.SerialNumbers.Add()
                vDoc.Lines.Add()

                PBar1.Value = i
            Next
        End If

        If RB2.Checked = True Then
            For i As Integer = 0 To dgvSourceList.RowCount - 1
                vDoc.Lines.SetCurrentLine(i)
                vDoc.Lines.ItemCode = dgvSourceList.Rows(i).Cells("FI107").Value '項目號碼
                vDoc.Lines.Quantity = dgvSourceList.Rows(i).Cells("FI117").Value '數量
                vDoc.Lines.BatchNumbers.SetCurrentLine(0)
                vDoc.Lines.BatchNumbers.BatchNumber = dgvSourceList.Rows(i).Cells("FI106").Value '條碼
                vDoc.Lines.BatchNumbers.ManufacturingDate = dgvSourceList.Rows(i).Cells("FI109").Value '實際製造日期
                vDoc.Lines.BatchNumbers.ExpiryDate = dgvSourceList.Rows(i).Cells("FI111").Value '有效日期
                vDoc.Lines.BatchNumbers.Quantity = dgvSourceList.Rows(i).Cells("FI117").Value '數量
                vDoc.Lines.BatchNumbers.Add()
                vDoc.Lines.Add()
                PBar1.Value = i
            Next
        End If

        RetVal = vDoc.Add

        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("製單轉入B1收貨單錯誤! " & Codess & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        Else
            SyncSRN()
            記錄存檔()
        End If

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        If SyncAns = True Then
            Label7.Visible = False
            MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum, 64, "完成")
        Else
            Label7.Visible = False
            MsgBox("資料已至B1收貨單!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "但是條碼重量未更新!!" & vbCrLf & "請洽資訊室協助更新!!", 16, "未完成")
        End If

        ClearAll()
        LoadSourceMain()


    End Sub

    Private Sub 記錄存檔()  '存入冷凍庫之品項

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To dgvSourceList.RowCount - 1
                If dgvSourceList.Rows(i).Cells("PDA04").Value = "J011" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J012" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J013" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J014" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J015" Then

                    sql = " INSERT INTO [Z_KS_Record_021] ([DocDate],[DocDate2],[F01],[F02],[F03],[F04],[F05],[F06]) VALUES "
                    sql += " ( getdate()                                              ,"
                    sql += "  '" & DocDate2.Value.Date & "'                           ,"
                    sql += "  '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "' ,"
                    sql += "  '" & dgvSourceMain.CurrentRow.Cells("FI101").Value & "' ,"
                    sql += "  '" & dgvSourceList.Rows(i).Cells("FI106").Value & "'    ,"
                    sql += "  '" & dgvSourceList.Rows(i).Cells("FI107").Value & "'    ,"
                    sql += "  '" & dgvSourceList.Rows(i).Cells("FI108").Value & "'    ,"
                    sql += "  '" & dgvSourceList.Rows(i).Cells("PDA04").Value & "'    )"

                    'sql = " INSERT INTO [Z_KS_ODRFCode2] ([DocNum],[DocDate],[DocTime],[Floor],[Period],[U_CK02],[U_De],[ItemCode],[ItemName],[Quantity],[Cancel],[Cancel2],[DocNum2]) VALUES "
                    'sql += " ('" & DGV3.CurrentRow.Cells("製單").Value & "' + '" & TextBox2.Text & "' ,"
                    'sql += "  '" & dateDocDate.Value.Date & "'               ,"
                    'sql += "  getdate()                                      ,"
                    'sql += "  '" & Floor.SelectedIndex & "'                  ,"
                    'sql += "  '" & Period2.SelectedIndex & "'                ,"
                    'sql += "  '" & DGV3.CurrentRow.Cells("製單").Value & "'  ,"
                    'sql += "  '" & TextBox2.Text & "'                        ,"
                    'sql += "  '" & DGV1.Rows(i).Cells("存編").Value & "'     ,"
                    'sql += "  '" & DGV1.Rows(i).Cells("品名").Value & "'     ,"
                    'sql += "  '" & DGV1.Rows(i).Cells("差異").Value & "'     ,"
                    'sql += "  'Y'                                            ,"
                    'sql += "  'N'                                            ,"
                    'sql += "  '" & 單號2.Text & "'                           )"

                End If

                If dgvSourceList.Rows(i).Cells("PDA04").Value = "J011" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J012" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J013" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J014" Or _
                   dgvSourceList.Rows(i).Cells("PDA04").Value = "J015" Then

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                End If
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

    End Sub

    Private Sub SyncSRN()
        SyncAns = False
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        '修改加快回傳方式_Phil_20140305
        Dim DrfNums1 As String = ""
        For i As Integer = 0 To dgvSourceList.RowCount - 1
            If DrfNums1 = "" Then
                DrfNums1 = DrfNums1 + Format(dgvSourceList.Rows(i).Cells("FI106").Value, "")
            Else
                DrfNums1 = DrfNums1 + "','" + Format(dgvSourceList.Rows(i).Cells("FI106").Value, "")
            End If
        Next

        If DrfNums1 = "" Then
            MsgBox("空白資料")
            Exit Sub
        End If

        Try
            For i As Integer = 0 To dgvSourceList.RowCount - 1
                If RB1.Checked = True Then
                    sql = "Update OSRN set U_M8 = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "',U_M1 = '" & dgvSourceList.Rows(i).Cells("FI118").FormattedValue & "', U_M2 = '" & dgvSourceList.Rows(i).Cells("PDA04").FormattedValue & "', U_MC = '" & dgvSourceList.Rows(i).Cells("FI119").FormattedValue & "' where DistNumber = '" & dgvSourceList.Rows(i).Cells("FI106").Value & "'"
                    '修改加快回傳方式_Phil_20140305
                    'sql = "  UPDATE [OSRN] SET [U_M8] = T1.[FI102], [U_M1] = T1.[FI118], [U_M2] = T2.[PDA04], [U_MC] = T1.[FI119] "
                    'sql += "   FROM [OSRN] T0 INNER JOIN [@FinishItem1] T1 ON T0.[DistNumber] = T1.[FI106] "
                    'sql += "                  INNER JOIN [@ksPDAIn]     T2 ON T0.[DistNumber] = T2.[PDA03] "
                    'sql += "  WHERE [DistNumber] IN ('" & DrfNums1 & "') "
                    'sql += " UPDATE [@FinishItem1] SET [FI103] = '4' WHERE [FI106] IN ('" & DrfNums1 & "') "
                    '下方執行
                    'sql += " UPDATE [@ksPDAIn]     SET [PDA06] = '4' WHERE [PDA03] IN ('" & DrfNums1 & "') "

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                    sql = "Update [@FinishItem1] set [FI103] = '4' where [FI106] = '" & dgvSourceList.Rows(i).Cells("FI106").FormattedValue & "'"
                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                End If

                If RB2.Checked = True Then
                    sql = "Update OBTN set U_M8 = '" & dgvSourceMain.CurrentRow.Cells("FI102").Value & "',U_M2 = '" & dgvSourceList.Rows(i).Cells("PDA04").Value & "' where DistNumber = '" & dgvSourceList.Rows(i).Cells("FI106").Value & "'"
                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                    sql = "Update [@FinishItem2] set [FI103] = '4' where [FI106] = '" & dgvSourceList.Rows(i).Cells("FI106").Value & "'"
                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                End If

                sql = "Update [@ksPDAIn] set [PDA06] = '4' where [PDA03] = '" & dgvSourceList.Rows(i).Cells("FI106").FormattedValue & "'"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
                PBar1.Value = i
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Dim oAns As Integer
            oAns = MsgBox("是否要重新更新條碼重量?", 36, "警告")
            If oAns = MsgBoxResult.No Then
                SyncAns = False
                Exit Sub
            Else
                SyncSRN()
            End If
        End Try

        SyncAns = True

    End Sub

    Private Sub btnForError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForError.Click
        If dgvSourceMain.RowCount <= 0 Then
            Exit Sub
        End If

        If dgvSourceList.RowCount <= 0 Then
            Exit Sub
        End If

        SyncSRN()

        MsgBox("更新完成!", 64, "成功")

    End Sub

    Private Sub ClearAll()
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        'DocDate.Value = Today
    End Sub

    '----

    Private Sub BP01_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BP01_del.Click
        P01_del()
        TP01_del.Text = ""
        ks1DataSet.Tables("DT2").Clear()
        LoadSourceList()
    End Sub

    Private Sub P01_del()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try

            For i As Integer = 0 To dgvSourceList.RowCount - 1

                sql = "DELETE FROM [@ksPDAIn] WHERE [PDA03] = '" & dgvSourceList.Rows(i).Cells("FI106").Value & "' AND [PDA04] = '" & TP01_del.Text & "' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
                PBar1.Value = i
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("刪除完成!", 64, "成功")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        記錄存檔()
    End Sub
End Class