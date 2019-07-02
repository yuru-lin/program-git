Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_InB1ByPurchase
    Dim DataAdapter1, DataAdapter2, DataAdapter3, DataAdapter4 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim oSelectQty As Integer  '己挑選條碼數量
    Dim oTotalQty As Integer   '應挑選條碼數量
    Dim TypeSelect As String
    Dim SyncAns As Boolean

    Private Sub C_InB1ByPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceList.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvBarcode.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LoginType = 2 Then
            btnToB1.Enabled = False
        End If

        cobSelectType.SelectedIndex = 0

    End Sub


    '6:採購入庫

    Private Sub cobSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSelectType.SelectedIndexChanged
        Select Case cobSelectType.SelectedIndex
            Case "0"
                TypeSelect = "6"
            Case "1"
                TypeSelect = "7"
        End Select
        ClearAll()


    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        LoaddgvSourceMain()
    End Sub

    Private Sub LoaddgvSourceMain()
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        Select Case cobSelectType.SelectedIndex
            Case "0"
                sql = "SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK06, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry " _
                    & "WHERE T0.ObjType='20' and T0.DocStatus = 'O' and T0.U_CK06 = '16'"
                'sql = "SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK06, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry " _
                '    & " WHERE T0.ObjType='20' "
            Case "1"
                sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE ObjType = '60' AND U_CK01 in ('0','1','2','3','4') AND T0.DocStatus = 'O'"
        End Select

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")
        dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")

        Select Case cobSelectType.SelectedIndex
            Case "0"
                setdgvSourceMainDisplayType1()
            Case "1"
                setdgvSourceMainDisplayType1()
        End Select

        dgvSourceMain.AutoResizeColumns()
        If dgvSourceMain.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub setdgvSourceMainDisplayType1()
        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                Case "DocEntry" : column.HeaderText = "草稿號" : column.DisplayIndex = 0
                Case "CardName" : column.HeaderText = "客戶" : column.DisplayIndex = 1
                Case "U_Dnum" : column.HeaderText = "提單號" : column.DisplayIndex = 2
                Case "DocDueDate" : column.HeaderText = "到期日" : column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

    '點選作業單後, 顯示明細資料在dgvSourceList
    Private Sub dgvSourceMain_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick
        '建立生產明細單下之條碼資料與元件
        If dgvSourceMain.RowCount = 0 Then
            Exit Sub
        End If

        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        LoadSourceList()               '載入選取製單之生產明細單      
    End Sub

    Private Sub LoadSourceList()

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        Select Case cobSelectType.SelectedIndex
            Case "0"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6, U_P7, U_P8, U_P1, U_Cdate, U_Omoney, U_P3, BaseType, BaseRef, BaseEntry, BaseLine, Price, LineTotal from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' order by LineNum"
            Case "1"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
        End Select
        DataAdapter2 = New SqlDataAdapter(sql, DBConn)
        DataAdapter2.Fill(ks1DataSet, "DT2")
        dgvSourceList.DataSource = ks1DataSet.Tables("DT2")

        For Each column As DataGridViewColumn In dgvSourceList.Columns
            column.Visible = True
            Select Case column.HeaderText
                Case "ItemCode", "存編"
                    column.HeaderText = "存編"
                    column.Width = 145
                Case "Dscription", "品名"
                    column.HeaderText = "品名"
                    column.Width = 300
                Case "Quantity", "數量"
                    column.HeaderText = "數量"
                    column.DefaultCellStyle.Format = "###0.00"
                    column.Width = 80
                Case Else
                    column.Visible = False
            End Select
        Next
        dgvSourceList.Refresh()
        dgvSourceList.AutoResizeColumns()
    End Sub

    '點選作業單明細項目後, 顯示可用之條碼在dgvBarcode
    Private Sub dgvSourceList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceList.CellClick
        '建立生產明細單下之條碼資料與元件
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        If dgvSourceList.RowCount > 0 Then
            LoadBarCode()               '載入點選待出庫項目之可挑選條碼清單          
        End If
    End Sub

    '載入點選明細資料項之可用條碼至Dataset並設定為dgvBarcode顯示來源
    Private Sub LoadBarCode()
        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim sql As String = ""

            Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
            '檢查點選項目採用批次或序號管理
            oBorS = ChkBorS(dgvSourceList.CurrentRow.Cells("ItemCode").Value)
            '載入點選明細資料項目之已選取條碼清單至ks1DataSet("DT3")
            If oBorS = "B" Then
                sql = "SELECT T0.OB03, T0.OB04, T0.OB05, T0.OB11, T0.OB14, T1.MnfDate FROM [@ksOBList] AS T0 INNER JOIN OBTN AS T1 ON T0.OB03 = T1.DistNumber where "
            ElseIf oBorS = "S" Then
                'sql = "SELECT T0.OB03, T0.OB04, T0.OB05, T0.OB11, T0.OB14, T1.MnfDate FROM [@ksOBList] AS T0 INNER JOIN OSRN AS T1 ON T0.OB03 = T1.DistNumber where "
                sql = "SELECT T0.OB02, T0.OB03, T0.OB04, T0.OB05, T0.OB11, T0.OB14, T1.FI109, T1.FI111, T1.FI118 FROM [@ksOBList] AS T0 INNER JOIN [@FinishItem3] AS T1 ON T0.OB03 = T1.FI106 where "
            ElseIf oBorS = "F" Then
                MsgBox("項目基本資料主檔中不是序號或批號管理 ", MsgBoxStyle.OkOnly, "資料錯誤")
                Exit Sub
            End If

            sql = sql & " T0.OB07='" & TypeSelect & "' and " _
                      & " T0.OB08='" & dgvSourceList.CurrentRow.Cells("DocEntry").Value & "' and " _
                      & " T0.OB09='" & dgvSourceList.CurrentRow.Cells("LineNum").Value & "' and" _
                      & " T0.OB10='3' " _
                      & " ORDER BY T0.OB04"

            DataAdapter3 = New SqlDataAdapter(sql, DBConn)
            DataAdapter3.Fill(ks1DataSet, "DT3")
            dgvBarcode.DataSource = ks1DataSet.Tables("DT3")
        Catch ex As Exception
            MsgBox("LoadBarCode: " & ex.Message)
            End
        End Try

        For Each column As DataGridViewColumn In dgvBarcode.Columns
            column.Visible = True
            Select Case column.Name
                Case "OB03"
                    column.HeaderText = "條碼"
                    column.DisplayIndex = 0
                Case "OB14"
                    column.HeaderText = "倉庫"
                    column.DisplayIndex = 1
                Case "OB04"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 2
                Case "OB02"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 3
                Case "OB05"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Format = "###0.00"
                Case Else
                    column.Visible = False
            End Select
        Next

        dgvBarcode.Refresh()
        dgvBarcode.AutoResizeColumns()
        Label8.Text = dgvBarcode.RowCount
    End Sub

    Private Function ChkBorS(ByVal ItemCode As String)
        Dim oBorS As String
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        sql = "select ManSerNum, ManBtchNum from OITM where ItemCode='" & ItemCode & "'"
        SQLCmd = New SqlCommand(sql, DBConn)
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()
        If sqlReader.HasRows() Then
            If sqlReader.Item("ManSerNum") = "Y" Then   '序號管理
                oBorS = "S"
            ElseIf sqlReader.Item("ManBtchNum") = "Y" Then  '批次管理
                oBorS = "B"
            Else
                sqlReader.Close()
                oBorS = "F"
            End If
            sqlReader.Close()
        Else
            sqlReader.Close()
            oBorS = "F"
        End If

        Return oBorS
    End Function

    Private Sub btnToB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToB1.Click
        Select Case cobSelectType.SelectedIndex
            Case "0"
                SyncToSAPPurchaseDeliveryNotes()
            Case "1"
                SyncToSAPPurchaseDeliveryNotes()
                'SyncToSAPInventoryGenExit()
        End Select
    End Sub

    Private Sub SyncToSAPPurchaseDeliveryNotes()

        Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
        Dim DBConn As SqlConnection = Login.DBConn
        'Dim sql As String
        Dim sql2 As String
        'Dim sqlCmd As SqlCommand
        'Dim sqlReader As SqlDataReader
        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim odraft As SAPbobsCOM.Documents
        Dim oDelv As SAPbobsCOM.Documents

        oDelv = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes)
        'oDelv = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oCreditNotes)


        '15 交貨單      (SAPbobsCOM.BoObjectTypes.oDeliveryNotes)
        '20 採購收貨單  (SAPbobsCOM.BoObjectTypes.oPurchaseDeliveryNotes)
        '59 收貨單      (SAPbobsCOM.BoObjectTypes.oInventoryGenEntry)
        '60 發貨單      (SAPbobsCOM.BoObjectTypes.oInventoryGenExit)

        '文件開始
        oDelv.CardCode = dgvSourceMain.CurrentRow.Cells("CardCode").Value               '業務夥伴代碼
        oDelv.DocDueDate = dgvSourceMain.CurrentRow.Cells("DocDueDate").Value           '到期日
        oDelv.DocDate = dgvSourceMain.CurrentRow.Cells("DocDate").Value                 '過帳日期

        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_Dnum").Value) Then    '提貨單號
        Else
            oDelv.UserFields.Fields.Item("U_Dnum").Value = dgvSourceMain.CurrentRow.Cells("U_Dnum").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("Comments").Value) Then  '備註
        Else
            oDelv.Comments = dgvSourceMain.CurrentRow.Cells("Comments").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_attachment").Value) Then  '附件
        Else
            oDelv.UserFields.Fields.Item("U_attachment").Value = dgvSourceMain.CurrentRow.Cells("U_attachment").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CK06").Value) Then  '收貨目的
        Else
            oDelv.UserFields.Fields.Item("U_CK06").Value = dgvSourceMain.CurrentRow.Cells("U_CK06").Value
        End If
        'oDelv.UserFields.Fields.Item("U_CK06").Value = dgvSourceMain.CurrentRow.Cells("U_CK06").Value   '發貨目的
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_Cnum").Value) Then    '契養批號
        'Else
        '    oDelv.UserFields.Fields.Item("U_Cnum").Value = dgvSourceMain.CurrentRow.Cells("U_Cnum").Value
        'End If
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_N1").Value) Then  '前期空籃
        'Else
        '    oDelv.UserFields.Fields.Item("U_N1").Value = dgvSourceMain.CurrentRow.Cells("U_N1").Value
        'End If
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_N2").Value) Then  '本期空籃
        'Else
        '    oDelv.UserFields.Fields.Item("U_N2").Value = dgvSourceMain.CurrentRow.Cells("U_N2").Value
        'End If
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_N3").Value) Then  '本期收回
        'Else
        '    oDelv.UserFields.Fields.Item("U_N3").Value = dgvSourceMain.CurrentRow.Cells("U_N3").Value
        'End If
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CarDr1").Value) Then  '司機1
        'Else
        '    oDelv.UserFields.Fields.Item("U_CarDr1").Value = dgvSourceMain.CurrentRow.Cells("U_CarDr1").Value
        'End If
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CarDr2").Value) Then  '司機2
        'Else
        '    oDelv.UserFields.Fields.Item("U_CarDr2").Value = dgvSourceMain.CurrentRow.Cells("U_CarDr2").Value
        'End If
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CarDr3").Value) Then  '司機3
        'Else
        '    oDelv.UserFields.Fields.Item("U_CarDr3").Value = dgvSourceMain.CurrentRow.Cells("U_CarDr3").Value
        'End If
        'oDelv.UserFields.Fields.Item("U_Dlst").Value = dgvSourceMain.CurrentRow.Cells("U_Dlst").Value   '出貨單回簽否
        'oDelv.UserFields.Fields.Item("U_updnum").Value = dgvSourceMain.CurrentRow.Cells("U_updnum").Value   '更新空籃數
        'If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_TpMoney").Value) Then     '運費
        'Else
        '    oDelv.UserFields.Fields.Item("U_TpMoney").Value = dgvSourceMain.CurrentRow.Cells("U_TpMoney").Value
        'End If

        '內容
        For i As Integer = 0 To dgvSourceList.RowCount - 1

            Dim p2Value As Single = 0
            oDelv.Lines.SetCurrentLine(i)
            oDelv.Lines.ItemCode = dgvSourceList.Rows(i).Cells("ItemCode").Value    '項目號碼
            oDelv.Lines.Quantity = dgvSourceList.Rows(i).Cells("Quantity").Value    '數量
            oDelv.Lines.BaseType = dgvSourceList.Rows(i).Cells("BaseType").Value    '基礎文件類型
            If IsDBNull(dgvSourceList.Rows(i).Cells("BaseEntry").Value) Then        '基礎文件內部 ID
            Else
                oDelv.Lines.BaseEntry = dgvSourceList.Rows(i).Cells("BaseEntry").Value
            End If
            If IsDBNull(dgvSourceList.Rows(i).Cells("BaseLine").Value) Then         '基礎列
            Else
                oDelv.Lines.BaseLine = dgvSourceList.Rows(i).Cells("BaseLine").Value
            End If

            'If IsDBNull(dgvSourceList.Rows(i).Cells("U_P1").Value) Then             '員工姓名
            'Else
            '    oDelv.Lines.UserFields.Fields.Item("U_P1").Value = dgvSourceList.Rows(i).Cells("U_P1").Value
            'End If

            If ckbWhs.Checked = True Then
                oDelv.Lines.WarehouseCode = tbxWhsCode.Text
            End If

            'oDelv.Lines.UserFields.Fields.Item("U_P3").Value = dgvSourceList.Rows(i).Cells("U_P3").Value            '生產否
            'oDelv.Lines.UserFields.Fields.Item("U_P4").Value = dgvSourceList.Rows(i).Cells("U_P4").FormattedValue   '單位2數量
            'oDelv.Lines.UserFields.Fields.Item("U_P5").Value = dgvSourceList.Rows(i).Cells("U_P5").Value            '單位1KG
            'oDelv.Lines.UserFields.Fields.Item("U_P6").Value = dgvSourceList.Rows(i).Cells("U_P6").Value            '小單位
            oDelv.Lines.UserFields.Fields.Item("U_P7").Value = dgvSourceList.Rows(i).Cells("U_P7").Value            '計價單位
            oDelv.Lines.UserFields.Fields.Item("U_P8").Value = dgvSourceList.Rows(i).Cells("U_P8").FormattedValue   '銷售金額

            'If IsDBNull(dgvSourceList.Rows(i).Cells("U_Cdate").Value) Then                                          '入雛日
            'Else
            '    oDelv.Lines.UserFields.Fields.Item("U_Cdate").Value = dgvSourceList.Rows(i).Cells("U_Cdate").Value
            'End If
            oDelv.Lines.UserFields.Fields.Item("U_Omoney").Value = dgvSourceList.Rows(i).Cells("U_Omoney").Value    '付款方法

            oBorS = ChkBorS(dgvSourceList.Rows(i).Cells("ItemCode").Value)                                          '項目號碼

            '紀錄條碼是屬於第幾行
            Dim ks2DataSet As DataSet = New DataSet
            sql2 = "SELECT DISTINCT * FROM [@ksOBList] AS T0 INNER JOIN [@FinishItem3] AS T1 ON T0.OB03 = T1.FI106 WHERE T0.OB07='" & TypeSelect & "' and T0.OB08='" & dgvSourceList.Rows(i).Cells("DocEntry").Value & "' and T0.OB09='" & dgvSourceList.Rows(i).Cells("LineNum").Value & "' and T0.OB10='3'"

            DataAdapter4 = New SqlDataAdapter(sql2, DBConn)
            DataAdapter4.Fill(ks2DataSet, "DT4")
            DataGridView1.DataSource = ks2DataSet.Tables("DT4")

            If oBorS = "B" Then
                '批號
                For j As Integer = 0 To DataGridView1.RowCount - 1
                    oDelv.Lines.BatchNumbers.SetCurrentLine(j)
                    oDelv.Lines.BatchNumbers.BatchNumber = DataGridView1.Rows(j).Cells("OB03").Value '條碼
                    oDelv.Lines.BatchNumbers.Quantity = DataGridView1.Rows(j).Cells("OB05").FormattedValue  '數量
                    oDelv.Lines.BatchNumbers.Add()
                    '清除條碼
                    'DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
                Next
            ElseIf oBorS = "S" Then
                '序號
                For j As Integer = 0 To DataGridView1.RowCount - 1

                    oDelv.Lines.SerialNumbers.SetCurrentLine(j)
                    oDelv.Lines.SerialNumbers.InternalSerialNumber = DataGridView1.Rows(j).Cells("OB03").Value & "A"     '條碼
                    oDelv.Lines.SerialNumbers.ManufactureDate = DataGridView1.Rows(j).Cells("FI109").Value               '實際製造日期 
                    oDelv.Lines.SerialNumbers.ExpiryDate = DataGridView1.Rows(j).Cells("FI111").Value                    '有效日期
                    'sqlCmd = "UPDATE [OSRN] set U_M1 = " & DataGridView1.Rows(j).Cells("FI118").Value                   '重量
                    'oDelv.UserFields.Fields.Item("U_M2").Value("OSRN") = DataGridView1.Rows(j).Cells("OB04").Value                          '儲位
                    oDelv.Lines.SerialNumbers.Add()
                Next
            End If

            'Add行
            oDelv.Lines.Add()

        Next
        'Add文件
        RetVal = oDelv.Add
        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("B1採購收貨單錯誤!" & vbCrLf & "錯誤代碼： " & ErrCode & vbCrLf & "錯誤訊息： " & ErrMsg, 16, "錯誤")
            Exit Sub
        Else
            '更新重量及儲位
            SyncSRN(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
            '清除條碼
            DelOBListByDocEntry(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
        End If


        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        '文件完成才移除草稿
        odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
        odraft.Remove()

        MsgBox("新增至B1採購收貨單完成!!" + vbCrLf + "採購收貨單：" & DocNum, 64, "完成")
        ClearAll()
        LoaddgvSourceMain()
    End Sub

    Private Sub SyncSRN(ByVal DocEntry As String)
        SyncAns = False
        Dim sql As String

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            sql = "UPDATE [OSRN] set U_M1 = T0.OB16, U_M2 = T0.OB04 FROM [@ksOBList] T0 WHERE T0.OB08 = '" & DocEntry & "' and T0.OB03 + 'A' = [OSRN].DistNumber "
            'sql = " UPDATE [OSRN] set U_M1 = '" & DataGridView1.Rows(j).Cells("OB16").Value & "' ,U_M2 = '" & DataGridView1.Rows(j).Cells("OB04").Value "' _
            '& "WHERE ItemCode = '" & DataGridView1.Rows(j).Cells("OB01").Value & "' and DistNumber = '" & DataGridView1.Rows(j).Cells("OB03").Value & "A8" & "' "
            'MsgBox(sql, 64, "sql update 內容觀察")
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

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
                SyncSRN(DocEntry)
            End If
        End Try

        SyncAns = True

    End Sub

    '程序SyncToSAPInventoryGenExit()起
    '程序SyncToSAPInventoryGenExit()止

    Private Sub DelOBListByDocEntry(ByVal DocEntry As String)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try

            sql = "Delete from [@ksOBList] where OB08=" & DocEntry
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            DelOBListByDocEntry(DocEntry)
        End Try
    End Sub

    Private Sub ClearAll()
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If
        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If
    End Sub

    'Private Sub dgvSourceList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceList.CellContentClick

    'End Sub
End Class