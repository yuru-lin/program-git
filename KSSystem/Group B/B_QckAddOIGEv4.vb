Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QckAddOIGEv4
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_QckAddOIGEv4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '查詢生產單資料

        SelectDGV1()
        'FI102.Text = FI101.Text

        'FI102.Text = FI101.Text

        'Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2)
        SelectDGV2()

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

            sql = "    SELECT '' AS '選擇', [FI101] AS '生產單號', [FI106] AS '領料製單'"
            sql += "     FROM [@FI1Main]"
            sql += "    WHERE [FI104] = 'Y' "
            sql += " ORDER BY 2 "


            'sql = "    SELECT [FI102] AS '製單', [FI107] AS '存編', [FI108] AS '品名', COUNT([FI107]) AS '數量' "
            'sql += "     FROM [@FinishItem1] "
            'sql += "    WHERE [FI105] = '" & FI105.Value.Date & "' AND "
            'sql += "          [FI101] = '" & FI101.Text & "'       AND "
            'sql += "          [FI103] in ('1','2','3','4') "
            'sql += " GROUP BY [FI102],[FI107],[FI108] "
            'sql += " ORDER BY 2 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "PDT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("PDT1")

            For Each column As DataGridViewColumn In DGV1.Columns
                column.Visible = True
                Select Case column.HeaderText
                    Case "選擇", "選擇"
                        column.HeaderText = "選擇"
                        column.DisplayIndex = 0

                    Case "生產單號", "生產單號"
                        column.HeaderText = "生產單號"
                        column.DisplayIndex = 1
                        column.ReadOnly = True
                    Case "領料製單", "領料製單"
                        column.HeaderText = "領料製單"
                        column.DisplayIndex = 2
                        ''Case "狀態"
                        ''    column.HeaderText = "狀態"
                        ''    column.DisplayIndex = 4
                        ''Case "PDA04", "儲位"
                        ''    column.HeaderText = "儲位"
                        ''    column.DisplayIndex = 5
                        ''Case "FI117", "重量"
                        ''    column.HeaderText = "重量"
                        ''    column.DisplayIndex = 6
                    Case Else
                        column.Visible = False
                End Select
            Next

            TransactionMonitor.Complete()

            DGV1.AutoResizeColumns()

            DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using
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

            sql = "    SELECT [FI107] AS '存編',[FI108] AS '品名',COUNT([FI107]) AS '數量' "
            sql += "     FROM [@FinishItem1] "
            sql += "    WHERE [FI105] = '" & FI105.Value.Date & "' AND "
            sql += "          [FI101] = '" & FI101.Text & "'       AND "
            sql += "          [FI103] in ('1','2','3','4') "
            sql += " GROUP BY [FI107],[FI108] "
            sql += " ORDER BY 1 "

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


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '存檔

    End Sub

    'Private Sub SyncToSAP()

    '    Dim RetVal As Long
    '    Dim ErrCode As Long
    '    Dim ErrMsg As String
    '    Dim vDoc As SAPbobsCOM.Documents
    '    vDoc = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)

    '    vDoc.UserFields.Fields.Item("U_CK02").Value = dgvSourceMain.CurrentRow.Cells("FI102").Value '製單號
    '    vDoc.UserFields.Fields.Item("U_CK06").Value = InType
    '    vDoc.DocDate = FI105.Value.Date

    '    For i As Integer = 0 To dgvSourceList.RowCount - 1
    '        vDoc.Lines.SetCurrentLine(i)
    '        vDoc.Lines.ItemCode = dgvSourceList.Rows(i).Cells("FI107").Value '項目號碼
    '        vDoc.Lines.Quantity = 1
    '        If ckbWhs.Checked = True Then
    '            vDoc.Lines.WarehouseCode = tbxWhsCode.Text
    '        End If
    '        If IsDBNull(dgvSourceList.Rows(i).Cells("FI118").FormattedValue) Then
    '        Else
    '            vDoc.Lines.UserFields.Fields.Item("U_p2").Value = dgvSourceList.Rows(i).Cells("FI118").FormattedValue
    '        End If
    '        vDoc.Lines.SerialNumbers.SetCurrentLine(0)
    '        vDoc.Lines.SerialNumbers.InternalSerialNumber = dgvSourceList.Rows(i).Cells("FI106").Value '條碼
    '        vDoc.Lines.SerialNumbers.ManufactureDate = dgvSourceList.Rows(i).Cells("FI109").Value '實際製造日期 
    '        vDoc.Lines.SerialNumbers.ExpiryDate = dgvSourceList.Rows(i).Cells("FI111").Value '有效日期
    '        vDoc.Lines.SerialNumbers.Add()
    '        vDoc.Lines.Add()
    '        PBar1.Value = i
    '    Next

    '    RetVal = vDoc.Add

    '    'Check the result
    '    If RetVal <> 0 Then
    '        ErrCode = Login.oCompany.GetLastErrorCode()
    '        ErrMsg = Login.oCompany.GetLastErrorDescription()
    '        MsgBox("製單轉入B1收貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
    '        Exit Sub
    '    Else
    '        '回存製單及重量
    '        SyncSRN()
    '    End If

    '    Dim DocNum As Integer
    '    DocNum = Login.oCompany.GetNewObjectKey()
    '    If SyncAns = True Then
    '        MsgBox("新增至B1收貨單完成!!" + vbCrLf + "收貨單單號：" & DocNum, 64, "完成")
    '    Else
    '        MsgBox("資料已至B1收貨單!" + vbCrLf + "收貨單單號：" & DocNum & vbCrLf & "但是條碼重量未更新!!" & vbCrLf & "請洽資訊室協助更新!!", 16, "未完成")
    '    End If

    '    ClearAll()
    '    LoadSourceMain()

    'End Sub






End Class


