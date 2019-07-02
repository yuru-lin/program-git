Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QckAddOIGEv5
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim SyncAns As Boolean
    Dim InType As String
    Dim DocNum As Integer
    Dim SyncAns2 As Boolean


    Private Sub B_QckAddOIGEv5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label5.Text = "" : Label6.Text = "" : Label7.Text = ""
        SyncAns2 = False
        Button5.Visible = True

        Select Case UCase(Login.LogonUserName)
            Case "MANAGER", "KS09", "KS10"
                CheckBox1.Visible = True
            Case "MANAGER"
                FI1052.Visible = True
        End Select

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '查詢生產單資料
        SelectDGV1()

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT2").Clear()
        End If

    End Sub

    Private Sub SelectDGV1()
        '取得生產單項目統計

        '清空DGV1內容
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "    SELECT '' AS '選擇', [FI101] AS '生產單號', [FI106] AS '領料製單', [FI107] AS '入庫單號', [FI109] AS '出庫單號' "

            'sql = "    SELECT [FI101] AS '生產單號', [FI106] AS '領料製單', [FI107] AS '入庫單號', [FI109] AS '出庫單號', [FI103] AS '是否入庫' "
            'sql += "     FROM [@FI1Main]"
            'sql += "    WHERE  [FI103] IN ('3','4') AND [FI104] = 'Y' AND [FI109] IS NULL "
            'sql += " ORDER BY 2 "

            'If CheckBox1.Checked = True Then
            sql = "    SELECT [FI101] AS '生產單號', [FI106] AS '領料製單', [FI107] AS '入庫單號', [FI109] AS '出庫單號', [FI103] AS '是否入庫' "
            sql += "     FROM [@FI1Main]"
            sql += "    WHERE  [FI103] IN ('3','4') AND [FI104] = 'Y' AND [FI109] IS NULL "
            'sql += "    WHERE  [FI103] IN ('3','4') AND ([FI104] = 'Y' OR RIGHT([FI101],1) = 'C') AND [FI109] IS NULL "
            'sql += "    WHERE  [FI103] IN ('3','4') AND ([FI104] = 'Y' OR RIGHT([FI101],1) = 'C') AND [FI109] IS NULL AND [FI105] <= '" & Format(FI1052.Value.Date, "yyyy/MM/dd") & "' "
            If CheckBox1.Checked = True Then
                sql += "  AND [FI105] <= '" & Format(FI1052.Value.Date, "yyyy/MM/dd") & "' "
            End If
            sql += " ORDER BY 2 "

            'Else
            '    sql = "    SELECT [FI101] AS '生產單號', [FI106] AS '領料製單', [FI107] AS '入庫單號', [FI109] AS '出庫單號', [FI103] AS '是否入庫' "
            '    sql += "     FROM [@FI1Main]"
            '    sql += "    WHERE  [FI103] IN ('3','4') AND ([FI104] = 'Y' OR RIGHT([FI101],1) = 'C' ) AND [FI109] IS NULL "
            '    sql += " ORDER BY 2 "

            'End If


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "PDT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("PDT1")

            For Each column As DataGridViewColumn In DGV1.Columns
                column.Visible = True
                Select Case column.HeaderText
                    'Case "選擇"     : column.HeaderText = "選擇"     : column.DisplayIndex = 0 : column.ReadOnly = True
                    Case "生產單號" : column.HeaderText = "生產單號" : column.DisplayIndex = 0
                    Case "領料製單" : column.HeaderText = "領料製單" : column.DisplayIndex = 1
                    Case "入庫單號" : column.HeaderText = "入庫單號" : column.DisplayIndex = 2
                    Case "出庫單號" : column.HeaderText = "出庫單號" : column.DisplayIndex = 3
                    Case "是否入庫" : column.HeaderText = "是否入庫" : column.DisplayIndex = 4 : column.Visible = False

                    Case Else
                        column.Visible = False
                End Select
            Next

            TransactionMonitor.Complete()

            DGV1.AutoResizeColumns()

            DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If RadioButton1.Checked = True Or RadioButton2.Checked = True Then
            If DGV1.RowCount = -1 Then
                Exit Sub
            End If
            FI101.Text = DGV1.CurrentRow.Cells("生產單號").Value
        End If

        If SyncAns2 = True Then

            Exit Sub
        End If

        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        If DGV1.CurrentRow.Cells("入庫單號").Value.ToString = vbNullString Then
            Label5.Text = ""
            Button2.Enabled = True
        Else
            Label5.Text = DGV1.CurrentRow.Cells("入庫單號").Value
            Button2.Enabled = False
            If DGV1.CurrentRow.Cells("是否入庫").Value.ToString = "4" Then
                Label7.Text = ""
                Button21.Enabled = False
            Else
                Label7.Text = "重量未上傳，請重新上傳"
                Button21.Enabled = True
            End If
        End If

        If DGV1.CurrentRow.Cells("入庫單號").Value.ToString <> vbNullString Or _
           DGV1.CurrentRow.Cells("入庫單號").Value.ToString <> "" Then

            If DGV1.CurrentRow.Cells("出庫單號").Value.ToString = vbNullString Then
                Label6.Text = ""
                Button3.Enabled = True
            Else
                Label6.Text = DGV1.CurrentRow.Cells("出庫單號").Value
                Button3.Enabled = False
            End If
        Else
            Button3.Enabled = False
        End If

        'If Microsoft.VisualBasic.Right(DGV1.CurrentRow.Cells("生產單號").Value, 1) = "C" Then
        '    Button2.Enabled = False
        '    Button3.Enabled = True
        'Else
        '    Button2.Enabled = True
        '    Button3.Enabled = False
        'End If


        'PLineNum.Text = DGV1.CurrentRow.Cells("生產單號").Value
        'P2U_CK02.Text = DGV1.CurrentRow.Cells("領料製單").Value
        'P2CardName.Text = DGV1.CurrentRow.Cells("入庫單號").Value
        'PItemName.Text = DGV1.CurrentRow.Cells("出庫單號").Value

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT2").Clear()
        End If

        'If DGV3.RowCount > 0 Then
        '    ks1DataSetDGV.Tables("PDT3").Clear()
        'End If

        SelectDGV2()
        'SelectDGV3()



        'Label8.Text = "20" + Microsoft.VisualBasic.Mid(DGV1.CurrentRow.Cells("生產單號").Value, 3, 6)

        Dim a As Date = DateSerial("20" + Microsoft.VisualBasic.Mid(DGV1.CurrentRow.Cells("生產單號").Value, 3, 2), Microsoft.VisualBasic.Mid(DGV1.CurrentRow.Cells("生產單號").Value, 5, 2), Microsoft.VisualBasic.Mid(DGV1.CurrentRow.Cells("生產單號").Value, 7, 2))

        FI105.Text = a





    End Sub

    Private Sub SelectDGV2()
        '取得生產單入庫明細

        '清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = "    SELECT [FI102],[FI106],[FI107],[FI108],[FI118],[FI109],[FI111],[FI119] "
            sql += "     FROM [@FinishItem1] "
            sql += "    WHERE [FI101] =  '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND "
            sql += "          [FI103] IN ('1','2','3','4') "
            sql += " ORDER BY 3 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "PDT2")
            DGV2.DataSource = ks1DataSetDGV.Tables("PDT2")
            TransactionMonitor.Complete()

            DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using
    End Sub

    Private Sub SelectDGV3()
        '取得生產單入庫明細

        '清空DGV3內容
        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            ''sql = "    SELECT [FI102],[FI106],[FI107],[FI108],[FI118],[FI109],[FI111],[FI119] "
            ''sql += "     FROM [@FinishItem1] "
            ''sql += "    WHERE [FI101] =  '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND "
            ''sql += "          [FI103] IN ('1','2','3','4') "
            ''sql += " ORDER BY 3 "

            sql = "    SELECT [FI107] AS '存編', [FI108] AS '品名', COUNT([FI107]) AS '數量', SUM([FI118]) AS '重量' "
            sql += "     FROM [@FinishItem1] "
            sql += "    WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND "
            sql += "          [FI103] IN ('1','2','3','4') "
            sql += " GROUP BY [FI107],[FI108] "
            sql += " ORDER BY 1 "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "PDT3")
            DGV3.DataSource = ks1DataSetDGV.Tables("PDT3")
            TransactionMonitor.Complete()

            DGV3.AutoResizeColumns()

            DGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '存檔
        If DGV2.RowCount = 0 Then
            MsgBox("沒有任何條碼可以傳!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        SyncToSAP()

    End Sub

    Private Sub SyncToSAP()

        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim vDoc As SAPbobsCOM.Documents
        vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)

        vDoc.UserFields.Fields.Item("U_CK02").Value = DGV2.CurrentRow.Cells("FI102").Value '製單號
        vDoc.UserFields.Fields.Item("U_CK06").Value = "1"
        vDoc.DocDate = FI105.Value.Date

        For i As Integer = 0 To DGV2.RowCount - 1
            vDoc.Lines.SetCurrentLine(i)
            vDoc.Lines.ItemCode = DGV2.Rows(i).Cells("FI107").Value '項目號碼
            vDoc.Lines.Quantity = 1

            If IsDBNull(DGV2.Rows(i).Cells("FI118").FormattedValue) Then
            Else
                vDoc.Lines.UserFields.Fields.Item("U_p2").Value = DGV2.Rows(i).Cells("FI118").FormattedValue
            End If

            vDoc.Lines.SerialNumbers.SetCurrentLine(0)
            vDoc.Lines.SerialNumbers.InternalSerialNumber = DGV2.Rows(i).Cells("FI106").Value '條碼
            vDoc.Lines.SerialNumbers.ManufactureDate = DGV2.Rows(i).Cells("FI109").Value '實際製造日期 
            vDoc.Lines.SerialNumbers.ExpiryDate = DGV2.Rows(i).Cells("FI111").Value '有效日期
            vDoc.Lines.SerialNumbers.Add()
            vDoc.Lines.Add()
        Next

        RetVal = vDoc.Add

        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("製單轉入B1收貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        'Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()

        '回存製單及重量
        SyncSRN()

        If SyncAns = True Then
            MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum, 64, "完成")
        Else
            MsgBox("資料已至B1收貨單!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "但是條碼重量未更新!!" & vbCrLf & "請洽資訊室協助更新!!", 16, "未完成")
        End If

        DGV1.CurrentRow.Cells("入庫單號").Value = DocNum
        Label5.Text = DocNum
        Button2.Enabled = False



    End Sub

    Private Sub SyncSRN()
        SyncAns = False
        'Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            For i As Integer = 0 To DGV2.RowCount - 1

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = "  UPDATE [OSRN]         SET [U_M8]  = '" & DGV2.CurrentRow.Cells("FI102").Value & "', [U_M1] = '" & DGV2.Rows(i).Cells("FI118").FormattedValue & "', [U_M2] = '" & U_M2.Text & "', [U_MC] = '" & DGV2.Rows(i).Cells("FI119").FormattedValue & "' WHERE [DistNumber] = '" & DGV2.Rows(i).Cells("FI106").Value & "'"
                SQLCmd.CommandText += " UPDATE [@FinishItem1] SET [FI103] = '4' WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] IN ('1','2','3') "
                SQLCmd.CommandText += " UPDATE [@FI1Main]     SET [FI103] = '4', [FI107] = '" & DocNum & "', [FI108] = getdate()  WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] = '3' AND [FI104] = 'Y' "

                'SQLCmd.CommandText += " UPDATE [@FI1Main]     SET [FI103] = '4', [FI107] = '" & DocNum & "', [FI108] = '" & Now() & "'  WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] = '3' AND [FI104] = 'Y' "

                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新條碼重量失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Dim oAns As Integer
            oAns = MsgBox("是否要重新更新條碼重量?", 36, "警告")
            If oAns = MsgBoxResult.No Then
                SyncAns = False

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = " UPDATE [@FI1Main]     SET [FI107] = '" & DocNum & "', [FI108] = getdate() WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] = '3' AND [FI104] = 'Y' "
                SQLCmd.ExecuteNonQuery()

                'DGV1.CurrentRow.Cells("是否入庫").Value = "3"
                Label7.Text = "重量未上傳，請重新上傳"

                Exit Sub
            Else
                SyncSRN()
            End If
        End Try

        SyncAns = True

        DGV1.CurrentRow.Cells("是否入庫").Value = "4"
        Label7.Text = ""

    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        SyncSRN2()
    End Sub

    Private Sub SyncSRN2()
        SyncAns = False
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            For i As Integer = 0 To DGV2.RowCount - 1

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = "  UPDATE [OSRN]         SET [U_M8]  = '" & DGV2.CurrentRow.Cells("FI102").Value & "', [U_M1] = '" & DGV2.Rows(i).Cells("FI118").FormattedValue & "', [U_M2] = '" & U_M2.Text & "', [U_MC] = '" & DGV2.Rows(i).Cells("FI119").FormattedValue & "' WHERE [DistNumber] = '" & DGV2.Rows(i).Cells("FI106").Value & "'"
                SQLCmd.CommandText += " UPDATE [@FinishItem1] SET [FI103] = '4' WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] IN ('1','2','3') "
                SQLCmd.CommandText += " UPDATE [@FI1Main]     SET [FI103] = '4' WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] = '3' AND [FI104] = 'Y' "

                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

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
                SyncSRN2()
            End If
        End Try

        SyncAns = True

        MsgBox("更新條碼重量完成")

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '發貨存檔

        If DGV2.RowCount = 0 Then
            MsgBox("沒有任何條碼可以傳!!請重新檢查!!", 48, "警告")
            Exit Sub
        End If

        SyncToSAP2()

    End Sub

    Private Sub SyncToSAP2()

        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim X As Integer = 0
        Dim oGoodIss As SAPbobsCOM.Documents

        oGoodIss = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)

        '文件開始 表頭
        oGoodIss.TaxDate = FI105.Value.Date
        oGoodIss.DocDate = FI105.Value.Date
        oGoodIss.UserFields.Fields.Item("U_CK01").Value = "5"
        oGoodIss.UserFields.Fields.Item("U_CK02").Value = DGV1.CurrentRow.Cells("領料製單").Value
        'oGoodIss.JournalMemo = "發貨"

        ''文件開始 表身
        ' ''For i As Integer = 0 To DGV3.RowCount - 1
        ' ''    If DGV3.Rows(i).Cells("數量").Value > 0 Then
        ' ''        oGoodIss.Lines.SetCurrentLine(X)
        ' ''        oGoodIss.Lines.ItemCode = DGV3.Rows(i).Cells("存編").FormattedValue   '存編
        ' ''        oGoodIss.Lines.Quantity = DGV3.Rows(i).Cells("數量").FormattedValue   '數量
        ' ''        oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = DGV3.Rows(i).Cells("重量").FormattedValue   '重量

        ' ''        For o As Integer = 0 To DGV2.RowCount - 1
        ' ''            oGoodIss.Lines.SerialNumbers.SetCurrentLine(X)
        ' ''            oGoodIss.Lines.SerialNumbers.InternalSerialNumber = DGV2.Rows(o).Cells("FI106").Value '條碼
        ' ''        Next
        ' ''        oGoodIss.Lines.SerialNumbers.Add()

        ' ''        oGoodIss.Lines.Add()
        ' ''        X = X + 1
        ' ''    End If
        ' ''Next

        For i As Integer = 0 To DGV2.RowCount - 1
            oGoodIss.Lines.SetCurrentLine(i)
            oGoodIss.Lines.ItemCode = DGV2.Rows(i).Cells("FI107").Value '項目號碼
            oGoodIss.Lines.Quantity = 1
            oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = DGV2.Rows(i).Cells("FI118").FormattedValue

            oGoodIss.Lines.SerialNumbers.SetCurrentLine(0)
            oGoodIss.Lines.SerialNumbers.InternalSerialNumber = DGV2.Rows(i).Cells("FI106").Value '條碼

            oGoodIss.Lines.SerialNumbers.Add()
            oGoodIss.Lines.Add()
        Next


        RetVal = oGoodIss.Add

        'Check the result
        If RetVal <> 0 Then

            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("B1發貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()

        Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        SQLCmd2.Connection = DBConn2
        SQLCmd2.CommandText = " UPDATE [@FI1Main]     SET [FI109] = '" & DocNum & "', [FI110] = getdate() WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' AND [FI103] = '4' AND [FI104] = 'Y' "
        SQLCmd2.ExecuteNonQuery()

        MsgBox("新增至B1發貨單完成!!" + vbCrLf + "發貨單單號：" & DocNum, 64, "完成")

        DGV1.CurrentRow.Cells("出庫單號").Value = DocNum
        Label6.Text = DocNum
        Button3.Enabled = False

        'Dim Row As DataRow
        'Row = ks1DataSetDGV.Tables("PDT1").NewRow
        'Row.Item("出庫單號") = DocNum
        'ks1DataSetDGV.Tables("PDT1").Rows.Add(Row)
        'DGV1.AutoResizeColumns()

    End Sub


    '' ''Private Sub SyncToSAPInventoryGenExit()
    '' ''    Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
    '' ''    Dim RetVal As Long
    '' ''    Dim ErrCode As Long
    '' ''    Dim ErrMsg As String
    '' ''    Dim odraft As SAPbobsCOM.Documents
    '' ''    Dim oGoodIss As SAPbobsCOM.Documents

    '' ''    '內容
    '' ''    For i As Integer = 0 To dgvSourceList.RowCount - 1
    '' ''        Dim p2Value As Single = 0
    '' ''        oGoodIss.Lines.SetCurrentLine(i)
    '' ''        oGoodIss.Lines.ItemCode = dgvSourceList.Rows(i).Cells("ItemCode").Value
    '' ''        oGoodIss.Lines.Quantity = dgvSourceList.Rows(i).Cells("Quantity").Value
    '' ''        If ckbWhs.Checked = True Then
    '' ''            oGoodIss.Lines.WarehouseCode = tbxWhsCode.Text
    '' ''        End If
    '' ''        oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = dgvSourceList.Rows(i).Cells("U_p2").FormattedValue
    '' ''        oGoodIss.Lines.UserFields.Fields.Item("U_P4").Value = dgvSourceList.Rows(i).Cells("U_P4").FormattedValue
    '' ''        oGoodIss.Lines.UserFields.Fields.Item("U_P5").Value = dgvSourceList.Rows(i).Cells("U_P5").Value
    '' ''        oGoodIss.Lines.UserFields.Fields.Item("U_P6").Value = dgvSourceList.Rows(i).Cells("U_P6").Value
    '' ''        '檢查點選項目採用批次或序號管理
    '' ''        oBorS = ChkBorS(dgvSourceList.Rows(i).Cells("ItemCode").Value)

    '' ''        '紀錄條碼是屬於第幾行
    '' ''        Dim ks2DataSet As DataSet = New DataSet
    '' ''        sql2 = "SELECT DISTINCT * FROM [@ksOBList] WHERE OB07='" & TypeSelect & "' and OB08='" & dgvSourceList.Rows(i).Cells("DocEntry").Value & "' and OB09='" & dgvSourceList.Rows(i).Cells("LineNum").Value & "' and OB10='3'"
    '' ''        DataAdapter4 = New SqlDataAdapter(sql2, DBConn)
    '' ''        DataAdapter4.Fill(ks2DataSet, "DT4")
    '' ''        DataGridView1.DataSource = ks2DataSet.Tables("DT4")

    '' ''        If oBorS = "B" Then
    '' ''            '批號
    '' ''            For j As Integer = 0 To DataGridView1.RowCount - 1
    '' ''                oGoodIss.Lines.BatchNumbers.SetCurrentLine(j)
    '' ''                oGoodIss.Lines.BatchNumbers.BatchNumber = DataGridView1.Rows(j).Cells("OB03").Value '條碼
    '' ''                oGoodIss.Lines.BatchNumbers.Quantity = DataGridView1.Rows(j).Cells("OB05").FormattedValue  '數量
    '' ''                oGoodIss.Lines.BatchNumbers.Add()

    '' ''                '清除條碼
    '' ''                DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
    '' ''            Next
    '' ''        ElseIf oBorS = "S" Then
    '' ''            '序號
    '' ''            For j As Integer = 0 To DataGridView1.RowCount - 1
    '' ''                oGoodIss.Lines.SerialNumbers.SetCurrentLine(j)
    '' ''                oGoodIss.Lines.SerialNumbers.InternalSerialNumber = DataGridView1.Rows(j).Cells("OB03").Value '條碼
    '' ''                oGoodIss.Lines.SerialNumbers.Add()

    '' ''                '選條碼~把數量總和
    '' ''                sql = "select U_M1 from OSRN where DistNumber = '" & DataGridView1.Rows(j).Cells("OB03").Value & "' "
    '' ''                sqlCmd = New SqlCommand(sql, DBConn)
    '' ''                sqlReader = sqlCmd.ExecuteReader
    '' ''                sqlReader.Read()
    '' ''                p2Value = p2Value + sqlReader.Item("U_M1")
    '' ''                sqlReader.Close()

    '' ''                '清除條碼
    '' ''                DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
    '' ''            Next
    '' ''        End If
    '' ''        oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
    '' ''        oGoodIss.Lines.Add()
    '' ''    Next

    '' ''    RetVal = oGoodIss.Add

    '' ''    'Check the result
    '' ''    If RetVal <> 0 Then

    '' ''        ErrCode = Login.oCompany.GetLastErrorCode()
    '' ''        ErrMsg = Login.oCompany.GetLastErrorDescription()
    '' ''        MsgBox("B1發貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
    '' ''        Exit Sub
    '' ''    End If

    '' ''    Dim DocNum As Integer
    '' ''    DocNum = Login.oCompany.GetNewObjectKey()



    '' ''    MsgBox("新增至B1發貨單完成!!" + vbCrLf + "發貨單單號：" & DocNum, 64, "完成")

    '' ''End Sub

    '' ''Private Sub T2DGV2_Save()
    '' ''    '回存草稿
    '' ''    If T2DGV2.RowCount <= 0 Then
    '' ''        MsgBox("無資料!", 16, "錯誤")
    '' ''        Exit Sub
    '' ''    End If

    '' ''    Dim oAns As Integer
    '' ''    oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
    '' ''    If oAns = MsgBoxResult.No Then
    '' ''        Exit Sub
    '' ''    End If

    '' ''    Dim ErrCode As Long
    '' ''    Dim ErrMsg As String
    '' ''    Dim oDraft As SAPbobsCOM.Documents
    '' ''    Dim X As Integer = 0
    '' ''    Dim RetVal As Long

    '' ''    'oDraft =   Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
    '' ''    'oGoodIss = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)


    '' ''    oDraft.DocObjectCode = SAPbobsCOM.BoObjectTypes.oInventoryGenExit
    '' ''    oDraft.DocDate = T2DocDate.Value.Date
    '' ''    oDraft.TaxDate = T2DocDate.Value.Date
    '' ''    oDraft.UserFields.Fields.Item("U_CK01").Value = "5"
    '' ''    oDraft.UserFields.Fields.Item("U_CK02").Value = T2U_CK02.Text
    '' ''    oDraft.Comments = T2Comments.Text

    '' ''    For i As Integer = 0 To T2DGV2.RowCount - 1
    '' ''        If T2DGV2.Rows(i).Cells("數量").Value > 0 Then
    '' ''            oDraft.Lines.SetCurrentLine(X)
    '' ''            oDraft.Lines.ItemCode = T2DGV2.Rows(i).Cells("存編").FormattedValue   '存編
    '' ''            oDraft.Lines.Quantity = T2DGV2.Rows(i).Cells("數量").FormattedValue   '數量
    '' ''            oDraft.Lines.Add()
    '' ''            X = X + 1
    '' ''        End If

    '' ''    Next
    '' ''    RetVal = oDraft.Add()

    '' ''    If RetVal <> 0 Then
    '' ''        ErrCode = Login.oCompany.GetLastErrorCode()
    '' ''        ErrMsg = Login.oCompany.GetLastErrorDescription()
    '' ''        MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
    '' ''        Exit Sub
    '' ''    End If

    '' ''    Dim DocEntry As Integer
    '' ''    DocEntry = Login.oCompany.GetNewObjectKey()

    '' ''    '回存 草稿單號 至 [Z_KS_ODRFMain].[DocEntry]
    '' ''    Dim DBConn2 As SqlConnection = Login.DBConn
    '' ''    Dim SQLCmd2 As SqlCommand = New SqlCommand

    '' ''    SQLCmd2.Connection = DBConn2
    '' ''    SQLCmd2.CommandText = " UPDATE [Z_KS_ODRFMain] SET [DocEntry] = '" & DocEntry & "', [Cancel] = 'S' WHERE [Sid] = '" & T2Sid.Text & "' "
    '' ''    SQLCmd2.ExecuteNonQuery()

    '' ''    '重新查詢
    '' ''    T2DGV1_All()
    '' ''    ks1DataSetDGV.Tables("T2DGV2").Clear()
    '' ''    T2Sid.Text = ""
    '' ''    T2OPDocNum.Text = ""
    '' ''    T2U_CK02.Text = ""
    '' ''    T2Sid.Text = ""

    '' ''    T2Period.SelectedIndex = -1

    '' ''    MsgBox("新增至B1完成!!" + vbCrLf + "草稿單號：" & DocEntry, 64, "完成")

    '' ''End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            Panel1.Visible = True
            Label2.Visible = True
            Label4.Visible = True
            FI101.Visible = True
            FI106.Visible = True
            Button4.Visible = True
            SyncAns2 = True
        Else
            Panel1.Visible = False
            Label2.Visible = False
            Label4.Visible = False
            FI101.Visible = False
            FI106.Visible = False
            Button4.Visible = False
            SyncAns2 = False
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged
        'RadioButton1 = 新增補條碼生產單 , RadioButton2 = 非補條碼生產單排除

        'If RadioButton1.Checked = True Then
        '    Label2.Visible = True
        '    Label4.Visible = True
        '    FI101.Visible = True
        '    FI106.Visible = True
        '    FI101.Text = ""
        '    FI106.Text = ""
        'Else
        '    Label2.Visible = True
        '    Label4.Visible = False
        '    FI101.Visible = True
        '    FI106.Visible = False
        '    FI101.Text = ""
        '    FI106.Text = ""
        'End If

        If CheckBox1.Checked = True Then

            If RadioButton1.Checked = True Then
                Label2.Visible = True
                Label4.Visible = True
                FI101.Visible = True
                FI106.Visible = True
                FI101.Text = ""
                FI106.Text = ""
            End If

            If RadioButton2.Checked = True Then
                Label2.Visible = True
                Label4.Visible = False
                FI101.Visible = True
                FI106.Visible = False
                FI101.Text = ""
                FI106.Text = ""
            End If

        End If

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'RadioButton1 = 新增補條碼生產單 , RadioButton2 = 非補條碼生產單排除

        If RadioButton1.Checked = True Then

            If FI101.Text = "" Then
                MsgBox("未輸入生產單號", 48, "警告")
                Exit Sub
            End If

            If FI106.Text = "" Then
                MsgBox("未輸入領料製單", 48, "警告")
                Exit Sub
            End If

            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [@FI1Main] SET [FI104] = 'Y', [FI106] = '" & FI106.Text & "' WHERE [FI101] = '" & FI101.Text & "' "
            SQLCmd.ExecuteNonQuery()

        End If

        If RadioButton2.Checked = True Then

            'If DGV2.RowCount <> 0 Then
            '    MsgBox("本生產明細單內有資料無法排除", 48, "警告")
            '    Exit Sub
            'End If

            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [@FI1Main] SET [FI104] = 'N', [FI106] = '' WHERE [FI101] = '" & FI101.Text & "' "
            SQLCmd.ExecuteNonQuery()

        End If

        FI101.Text = ""
        FI106.Text = ""
        CheckBox1.Checked = False

        SelectDGV1()

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT2").Clear()
        End If

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        'If FI101.Text = "" Then
        '    MsgBox("未輸入生產單號", 48, "警告")
        '    Exit Sub
        'End If

        UPDATEFI_NO()

        'FI101.Text = ""
        'FI106.Text = ""
        'CheckBox1.Checked = False

        SelectDGV1()

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT2").Clear()
        End If
    End Sub

    Private Sub UPDATEFI_NO()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        'SQLCmd.CommandText = "  UPDATE [@FI1Main] SET [FI104] = 'N' WHERE [FI101] = '" & FI101.Text & "' "  'DGV1.CurrentRow.Cells("生產單號").Value
        SQLCmd.CommandText = "  UPDATE [@FI1Main] SET [FI104] = 'N' WHERE [FI101] = '" & DGV1.CurrentRow.Cells("生產單號").Value & "' "
        SQLCmd.ExecuteNonQuery()

    End Sub

End Class


