Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_出庫
    Dim DataAdapter1, DataAdapter2, DataAdapter3, DataAdapter4 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim oSelectQty As Integer  '己挑選條碼數量
    Dim oTotalQty As Integer   '應挑選條碼數量
    Dim TypeSelect As String
    Dim oBorS As String

    Private Sub C_出庫_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceList.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvBarcode.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LoginType = 2 Then
            btnToB1.Enabled = False
        End If

        cobSelectType.SelectedIndex = 0
    End Sub

    Private Sub cobSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSelectType.SelectedIndexChanged
        '1:領料出庫, 2:銷售出庫, 3:存貨領用, 4:寄庫品出庫, 5.委外代工出庫 ,6:採購入庫 ,7.生產調整
        Select Case cobSelectType.SelectedIndex
            Case "0" : TypeSelect = "1"
            Case "1" : TypeSelect = "2"
            Case "2" : TypeSelect = "3"
            Case "3" : TypeSelect = "4"
            Case "4" : TypeSelect = "5"
            Case "5" : TypeSelect = "7"
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
                sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('5') AND T0.DocStatus = 'O' "
            Case "1"
                sql = " SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
                sql += " WHERE T0.ObjType='15' and T1.WhsCode not in ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.DocStatus = 'O'"
            Case "2"
                sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE ObjType = '60' AND U_CK01 in ('0','1','2','3','4') AND T0.DocStatus = 'O'"
            Case "3"
                sql = "  SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
                sql += "  WHERE T0.ObjType='15' and (T1.WhsCode='O01' or T1.WhsCode='K05' OR T1.WhsCode='S05') AND T0.DocStatus = 'O'"
            Case "4"
                sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('11') AND T0.DocStatus = 'O' "
            Case "5"
                sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('14') AND T0.DocStatus = 'O' "
        End Select

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")
        dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")

        Select Case cobSelectType.SelectedIndex
            Case "0" : setdgvSourceMainDisplayType1()
            Case "1" : setdgvSourceMainDisplayType2()
            Case "2" : setdgvSourceMainDisplayType1()
            Case "3" : setdgvSourceMainDisplayType2()
            Case "4" : setdgvSourceMainDisplayType1()
            Case "5" : setdgvSourceMainDisplayType1()
        End Select

        dgvSourceMain.AutoResizeColumns()
        If dgvSourceMain.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub setdgvSourceMainDisplayType1()
        '存貨發貨
        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                Case "DocEntry"
                    column.HeaderText = "草稿號"
                    column.DisplayIndex = 0
                Case "DocDueDate"
                    column.HeaderText = "文件日期"
                    column.DisplayIndex = 1
                Case "Comments"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 2
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

    Private Sub setdgvSourceMainDisplayType2()  '營業交貨
        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                Case "U_Dnum"
                    column.HeaderText = "提單號"
                    column.DisplayIndex = 0
                Case "DocEntry"
                    column.HeaderText = "草稿號"
                    column.DisplayIndex = 1
                Case "CardName"
                    column.HeaderText = "客戶"
                    column.DisplayIndex = 2
                Case "DocDueDate"
                    column.HeaderText = "到期日"
                    column.DisplayIndex = 3
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

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn

        Select Case cobSelectType.SelectedIndex
            Case "0"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, Quantity, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            Case "1"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6, U_P7, U_P8, U_P1, U_Cdate, U_Omoney, U_P3, BaseType, BaseRef, BaseEntry, BaseLine, Price, LineTotal from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' order by LineNum"
            Case "2"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            Case "3"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, U_p2, U_P5, U_P4, U_P6, U_P7, U_P8, U_P1, U_Cdate, U_Omoney, U_P3, BaseType, BaseRef, BaseEntry, BaseLine, Price, LineTotal from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' order by LineNum"
            Case "4"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, Quantity, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
            Case "5"
                sql = "SELECT DocEntry, LineNum, ItemCode, Dscription, Quantity, WhsCode, Quantity, U_p2, U_P4, U_P5, U_P6 from DRF1 WHERE DocEntry = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "'"
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
            Dim sql As String

            'Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
            '檢查點選項目採用批次或序號管理
            oBorS = ChkBorS(dgvSourceList.CurrentRow.Cells("ItemCode").Value)
            '載入點選明細資料項目之已選取條碼清單至ks1DataSet("DT3")
            If oBorS = "B" Then
                sql = " SELECT T0.OB03, T0.OB04, T0.OB05, T0.OB11, T0.OB14, T1.MnfDate "
                sql += "  FROM [@ksOBList] AS T0 INNER JOIN OBTN AS T1 ON T0.OB03 = T1.DistNumber "
                sql += " WHERE T0.OB07 = '" & TypeSelect & "'                                       AND "
                sql += "       T0.OB08 = '" & dgvSourceList.CurrentRow.Cells("DocEntry").Value & "' AND "
                sql += "       T0.OB09 = '" & dgvSourceList.CurrentRow.Cells("LineNum").Value & "'  AND "
                sql += "       T0.OB10 = '3' ORDER BY T0.OB04 "

            ElseIf oBorS = "S" Then
                sql = " SELECT T0.OB03, T0.OB04, T0.OB05, T0.OB11, T0.OB14, T1.MnfDate "
                sql += "  FROM [@ksOBList] AS T0 INNER JOIN OSRN AS T1 ON T0.OB03 = T1.DistNumber "
                sql += " WHERE T0.OB07 = '" & TypeSelect & "'                                       AND "
                sql += "       T0.OB08 = '" & dgvSourceList.CurrentRow.Cells("DocEntry").Value & "' AND "
                sql += "       T0.OB09 = '" & dgvSourceList.CurrentRow.Cells("LineNum").Value & "'  AND "
                sql += "       T0.OB10 = '3' ORDER BY T0.OB04 "

            ElseIf oBorS = "F" Then
                MsgBox("項目基本資料主檔中不是序號或批號管理 ", MsgBoxStyle.OkOnly, "資料錯誤")
                Exit Sub
            End If

            'sql += " T0.OB07 = '" & TypeSelect & "'                                       AND "
            'sql += " T0.OB08 = '" & dgvSourceList.CurrentRow.Cells("DocEntry").Value & "' AND "
            'sql += " T0.OB09 = '" & dgvSourceList.CurrentRow.Cells("LineNum").Value & "'  AND "
            'sql += " T0.OB10 = '3' ORDER BY T0.OB04 "
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
                Case "MnfDate"
                    column.HeaderText = "製造日期"
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
        'Dim oBorS As String
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        sql = "select [ManSerNum], [ManBtchNum] from [OITM] where [ItemCode] = '" & ItemCode & "'"
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

        'MsgBox(oBorS)

        Return oBorS
    End Function

    Private Sub btnToB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToB1.Click
        Select Case cobSelectType.SelectedIndex
            Case "0" : SyncToSAPInventoryGenExit()
            Case "1" : SyncToSAPDeliveryNotes()
            Case "2" : SyncToSAPInventoryGenExit()
            Case "3" : SyncToSAPDeliveryNotes()
            Case "4" : SyncToSAPInventoryGenExit()
            Case "5" : SyncToSAPInventoryGenExit()
        End Select
    End Sub

    Private Sub SyncToSAPDeliveryNotes()

        'Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
        Dim DBConn As SqlConnection = Login.DBConn
        Dim sql As String
        Dim sql2 As String
        Dim sqlCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim odraft As SAPbobsCOM.Documents
        Dim oDelv As SAPbobsCOM.Documents

        oDelv = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDeliveryNotes)

        '文件開始
        oDelv.CardCode = dgvSourceMain.CurrentRow.Cells("CardCode").Value
        oDelv.DocDueDate = dgvSourceMain.CurrentRow.Cells("DocDueDate").Value
        oDelv.DocDate = dgvSourceMain.CurrentRow.Cells("DocDueDate").Value

        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_Dnum").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_Dnum").Value = dgvSourceMain.CurrentRow.Cells("U_Dnum").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("Comments").Value) Then
        Else
            oDelv.Comments = dgvSourceMain.CurrentRow.Cells("Comments").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_attachment").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_attachment").Value = dgvSourceMain.CurrentRow.Cells("U_attachment").Value
        End If
        oDelv.UserFields.Fields.Item("U_CK01").Value = dgvSourceMain.CurrentRow.Cells("U_CK01").Value
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_Cnum").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_Cnum").Value = dgvSourceMain.CurrentRow.Cells("U_Cnum").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_N1").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_N1").Value = dgvSourceMain.CurrentRow.Cells("U_N1").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_N2").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_N2").Value = dgvSourceMain.CurrentRow.Cells("U_N2").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_N3").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_N3").Value = dgvSourceMain.CurrentRow.Cells("U_N3").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CarDr1").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_CarDr1").Value = dgvSourceMain.CurrentRow.Cells("U_CarDr1").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CarDr2").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_CarDr2").Value = dgvSourceMain.CurrentRow.Cells("U_CarDr2").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CarDr3").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_CarDr3").Value = dgvSourceMain.CurrentRow.Cells("U_CarDr3").Value
        End If
        oDelv.UserFields.Fields.Item("U_Dlst").Value = dgvSourceMain.CurrentRow.Cells("U_Dlst").Value
        oDelv.UserFields.Fields.Item("U_updnum").Value = dgvSourceMain.CurrentRow.Cells("U_updnum").Value
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_TpMoney").Value) Then
        Else
            oDelv.UserFields.Fields.Item("U_TpMoney").Value = dgvSourceMain.CurrentRow.Cells("U_TpMoney").Value
        End If

        '內容
        For i As Integer = 0 To dgvSourceList.RowCount - 1

            Dim p2Value As Single = 0
            oDelv.Lines.SetCurrentLine(i)
            oDelv.Lines.ItemCode = dgvSourceList.Rows(i).Cells("ItemCode").Value
            oDelv.Lines.Quantity = dgvSourceList.Rows(i).Cells("Quantity").Value
            oDelv.Lines.BaseType = dgvSourceList.Rows(i).Cells("BaseType").Value
            If IsDBNull(dgvSourceList.Rows(i).Cells("BaseEntry").Value) Then
            Else
                oDelv.Lines.BaseEntry = dgvSourceList.Rows(i).Cells("BaseEntry").Value
            End If
            If IsDBNull(dgvSourceList.Rows(i).Cells("BaseLine").Value) Then
            Else
                oDelv.Lines.BaseLine = dgvSourceList.Rows(i).Cells("BaseLine").Value
            End If

            If IsDBNull(dgvSourceList.Rows(i).Cells("U_P1").Value) Then
            Else
                oDelv.Lines.UserFields.Fields.Item("U_P1").Value = dgvSourceList.Rows(i).Cells("U_P1").Value
            End If

            If ckbWhs.Checked = True Then
                oDelv.Lines.WarehouseCode = tbxWhsCode.Text
            End If

            oDelv.Lines.UserFields.Fields.Item("U_P3").Value = dgvSourceList.Rows(i).Cells("U_P3").Value
            oDelv.Lines.UserFields.Fields.Item("U_P4").Value = dgvSourceList.Rows(i).Cells("U_P4").FormattedValue
            oDelv.Lines.UserFields.Fields.Item("U_P5").Value = dgvSourceList.Rows(i).Cells("U_P5").Value
            oDelv.Lines.UserFields.Fields.Item("U_P6").Value = dgvSourceList.Rows(i).Cells("U_P6").Value
            oDelv.Lines.UserFields.Fields.Item("U_P7").Value = dgvSourceList.Rows(i).Cells("U_P7").Value
            oDelv.Lines.UserFields.Fields.Item("U_P8").Value = dgvSourceList.Rows(i).Cells("U_P8").FormattedValue
            If IsDBNull(dgvSourceList.Rows(i).Cells("U_Cdate").Value) Then
            Else
                oDelv.Lines.UserFields.Fields.Item("U_Cdate").Value = dgvSourceList.Rows(i).Cells("U_Cdate").Value
            End If
            oDelv.Lines.UserFields.Fields.Item("U_Omoney").Value = dgvSourceList.Rows(i).Cells("U_Omoney").Value

            oBorS = ChkBorS(dgvSourceList.Rows(i).Cells("ItemCode").Value)

            '紀錄條碼是屬於第幾行
            Dim ks2DataSet As DataSet = New DataSet
            sql2 = "SELECT DISTINCT * FROM [@ksOBList] WHERE OB07='" & TypeSelect & "' and OB08='" & dgvSourceList.Rows(i).Cells("DocEntry").Value & "' and OB09='" & dgvSourceList.Rows(i).Cells("LineNum").Value & "' and OB10='3'"
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
                    DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
                Next
            ElseIf oBorS = "S" Then
                '序號
                For j As Integer = 0 To DataGridView1.RowCount - 1
                    oDelv.Lines.SerialNumbers.SetCurrentLine(j)
                    oDelv.Lines.SerialNumbers.InternalSerialNumber = DataGridView1.Rows(j).Cells("OB03").Value '條碼
                    oDelv.Lines.SerialNumbers.Add()
                    '選條碼~把數量總和
                    sql = "select U_M1 from OSRN where DistNumber = '" & DataGridView1.Rows(j).Cells("OB03").Value & "' "
                    sqlCmd = New SqlCommand(sql, DBConn)
                    sqlReader = sqlCmd.ExecuteReader
                    sqlReader.Read()
                    p2Value = p2Value + sqlReader.Item("U_M1")
                    sqlReader.Close()
                    '清除條碼()
                    DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
                Next
            End If

            Select Case TypeSelect
                Case "2"
                    '根據計價單位運算金額
                    Select Case dgvSourceList.Rows(i).Cells("U_P7").Value
                        Case "0"
                            oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                            oDelv.Lines.UnitPrice = dgvSourceList.Rows(i).Cells("U_P8").Value
                        Case "1"
                            oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                            oDelv.Lines.UnitPrice = (dgvSourceList.Rows(i).Cells("U_P8").Value * p2Value) / dgvSourceList.Rows(i).Cells("Quantity").Value
                        Case "2"
                            oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                            oDelv.Lines.UnitPrice = (dgvSourceList.Rows(i).Cells("U_P8").Value * dgvSourceList.Rows(i).Cells("U_P4").Value) / dgvSourceList.Rows(i).Cells("Quantity").Value
                    End Select
                Case "4"
                    oDelv.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
                    If IsDBNull(dgvSourceList.Rows(i).Cells("U_P8").Value) Then
                    Else
                        oDelv.Lines.UnitPrice = dgvSourceList.Rows(i).Cells("U_P8").Value
                    End If
            End Select
            'Add行
            oDelv.Lines.Add()
        Next
        'Add文件
        RetVal = oDelv.Add
        'Check the result
        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("B1交貨單錯誤!" & vbCrLf & "錯誤代碼： " & ErrCode & vbCrLf & "錯誤訊息： " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        '文件完成才移除草稿
        odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
        odraft.Remove()

        MsgBox("新增至B1交貨單完成!!" + vbCrLf + "交貨單單號：" & DocNum, 64, "完成")
        ClearAll()
        LoaddgvSourceMain()
    End Sub

    Private Sub SyncToSAPInventoryGenExit()
        'Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
        Dim DBConn As SqlConnection = Login.DBConn
        Dim sql As String
        Dim sql2 As String
        Dim sqlCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        Dim RetVal As Long
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim odraft As SAPbobsCOM.Documents
        Dim oGoodIss As SAPbobsCOM.Documents

        oGoodIss = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)

        '文件開始
        oGoodIss.UserFields.Fields.Item("U_CK01").Value = dgvSourceMain.CurrentRow.Cells("U_CK01").Value
        oGoodIss.TaxDate = dgvSourceMain.CurrentRow.Cells("TaxDate").Value
        oGoodIss.DocDate = dgvSourceMain.CurrentRow.Cells("DocDate").Value

        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_CK02").Value) Then
        Else
            oGoodIss.UserFields.Fields.Item("U_CK02").Value = dgvSourceMain.CurrentRow.Cells("U_CK02").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_Cnum").Value) Then
        Else
            oGoodIss.UserFields.Fields.Item("U_Cnum").Value = dgvSourceMain.CurrentRow.Cells("U_Cnum").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_Gnum").Value) Then
        Else
            oGoodIss.UserFields.Fields.Item("U_Gnum").Value = dgvSourceMain.CurrentRow.Cells("U_Gnum").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("U_TpMoney").Value) Then
        Else
            oGoodIss.UserFields.Fields.Item("U_TpMoney").Value = dgvSourceMain.CurrentRow.Cells("U_TpMoney").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("Comments").Value) Then
        Else
            oGoodIss.Comments = dgvSourceMain.CurrentRow.Cells("Comments").Value
        End If
        If IsDBNull(dgvSourceMain.CurrentRow.Cells("JrnlMemo").Value) Then
        Else
            oGoodIss.JournalMemo = dgvSourceMain.CurrentRow.Cells("JrnlMemo").Value
        End If

        '內容
        For i As Integer = 0 To dgvSourceList.RowCount - 1
            Dim p2Value As Single = 0
            oGoodIss.Lines.SetCurrentLine(i)
            oGoodIss.Lines.ItemCode = dgvSourceList.Rows(i).Cells("ItemCode").Value
            oGoodIss.Lines.Quantity = dgvSourceList.Rows(i).Cells("Quantity").Value
            If ckbWhs.Checked = True Then
                oGoodIss.Lines.WarehouseCode = tbxWhsCode.Text
            End If
            oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = dgvSourceList.Rows(i).Cells("U_p2").FormattedValue
            oGoodIss.Lines.UserFields.Fields.Item("U_P4").Value = dgvSourceList.Rows(i).Cells("U_P4").FormattedValue
            oGoodIss.Lines.UserFields.Fields.Item("U_P5").Value = dgvSourceList.Rows(i).Cells("U_P5").Value
            oGoodIss.Lines.UserFields.Fields.Item("U_P6").Value = dgvSourceList.Rows(i).Cells("U_P6").Value
            '檢查點選項目採用批次或序號管理
            oBorS = ChkBorS(dgvSourceList.Rows(i).Cells("ItemCode").Value)

            '紀錄條碼是屬於第幾行
            Dim ks2DataSet As DataSet = New DataSet
            sql2 = "SELECT DISTINCT * FROM [@ksOBList] WHERE OB07='" & TypeSelect & "' and OB08='" & dgvSourceList.Rows(i).Cells("DocEntry").Value & "' and OB09='" & dgvSourceList.Rows(i).Cells("LineNum").Value & "' and OB10='3'"
            DataAdapter4 = New SqlDataAdapter(sql2, DBConn)
            DataAdapter4.Fill(ks2DataSet, "DT4")
            DataGridView1.DataSource = ks2DataSet.Tables("DT4")

            If oBorS = "B" Then
                '批號
                For j As Integer = 0 To DataGridView1.RowCount - 1
                    oGoodIss.Lines.BatchNumbers.SetCurrentLine(j)
                    oGoodIss.Lines.BatchNumbers.BatchNumber = DataGridView1.Rows(j).Cells("OB03").Value '條碼
                    oGoodIss.Lines.BatchNumbers.Quantity = DataGridView1.Rows(j).Cells("OB05").FormattedValue  '數量
                    oGoodIss.Lines.BatchNumbers.Add()

                    '清除條碼
                    DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
                Next
            ElseIf oBorS = "S" Then
                '序號
                For j As Integer = 0 To DataGridView1.RowCount - 1
                    oGoodIss.Lines.SerialNumbers.SetCurrentLine(j)
                    oGoodIss.Lines.SerialNumbers.InternalSerialNumber = DataGridView1.Rows(j).Cells("OB03").Value '條碼
                    oGoodIss.Lines.SerialNumbers.Add()

                    '選條碼~把數量總和
                    sql = "select U_M1 from OSRN where DistNumber = '" & DataGridView1.Rows(j).Cells("OB03").Value & "' "
                    sqlCmd = New SqlCommand(sql, DBConn)
                    sqlReader = sqlCmd.ExecuteReader
                    sqlReader.Read()
                    p2Value = p2Value + sqlReader.Item("U_M1")
                    sqlReader.Close()

                    '清除條碼
                    DelOBList(DataGridView1.Rows(j).Cells("OBID").Value)
                Next
            End If
            oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = p2Value
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


        '暫時停上領料發貨移除草稿   0.領料出庫 1.銷售出庫 2.存貨領用 3.寄庫品出庫 4.委外代工出庫 5.生產調整
        Select Case cobSelectType.SelectedIndex
            Case "0"

                If Login.LogonCompanyDB = "KaiShing" Then

                    Dim DBConn2 As SqlConnection = Login.DBConn
                    Dim SQLCmd2 As SqlCommand = New SqlCommand

                    SQLCmd2.Connection = DBConn2
                    SQLCmd2.CommandText = "  INSERT INTO [Z_KS_OIGEXX] (DocEntry, DocNum, DocDate, TaxDate, U_CK01, U_CK02, ItemCode, Dscription, Quantity, unitMsr, Comments) SELECT T1.[DocEntry], '" & DocNum & "', T0.[DocDate], T0.[TaxDate], T0.[U_CK01], T0.[U_CK02], T1.[ItemCode], T1.[Dscription], T1.[Quantity], T1.[unitMsr], T0.[Comments] FROM [ODRF] T0 INNER JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] WHERE T1.[DocEntry] = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' "
                    SQLCmd2.CommandText += " UPDATE [Z_KS_ODRFMain] SET [DocNum]  = '" & DocNum & "' WHERE [DocEntry] = '" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value & "' AND [Cancel] = 'S' AND [OutLy] = 'Y' "
                    SQLCmd2.ExecuteNonQuery()

                End If

                'MsgBox("新增草稿到已發貨" & dgvSourceMain.CurrentRow.Cells("DocEntry").Value, 32, "完成")
                'MsgBox("發貨單單號：" & DocNum, 64, "完成")
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
                odraft.Remove()
            Case "1"
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
                odraft.Remove()
            Case "2"
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
                odraft.Remove()
            Case "3"
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
                odraft.Remove()
            Case "4"
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
                odraft.Remove()
            Case "5"
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
                odraft.Remove()
        End Select

        '文件完成才移除草稿
        'odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
        'odraft.GetByKey(dgvSourceMain.CurrentRow.Cells("DocEntry").Value)
        'odraft.Remove()

        MsgBox("新增至B1發貨單完成!!" + vbCrLf + "發貨單單號：" & DocNum, 64, "完成")
        ClearAll()
        LoaddgvSourceMain()
    End Sub

    Private Sub DelOBList(ByVal OBID As String)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            sql = "Delete from [@ksOBList] where OBID=" & OBID
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            DelOBList(OBID)
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

End Class