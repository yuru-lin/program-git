Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class Z_OQUT 
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim OQUTDocNum As Integer

    Private Sub Z_OQUT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        CardCode.Focus()
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
    End Sub

    Private Sub CardCodet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardCode.LostFocus
        SelectCardCode()
        If DGV1.RowCount > 0 Then
            ClearAll()
        End If
    End Sub

    Private Sub CardName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardName.LostFocus
        SelectCardName()
        If DGV1.RowCount > 0 Then
            ClearAll()
        End If
    End Sub

    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()

    End Sub

    Private Sub ItemNameTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()

    End Sub

    Private Sub KSEmpID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles KSEmpID.LostFocus
        SelectKSEmpID()
    End Sub

    Private Sub SelectCardCode()

        If CardCode.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'C' and [CardCode] = '" & CardCode.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無此人", 16, "錯誤")
                CardName.Text = ""
                CardCode.Text = ""
                CardCode.Focus()
            Else
                CardName.Text = sqlReader.Item("CardName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectCardName()

        If CardName.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'C' and [CardName] = '" & CardName.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectName.getCardName = CardName.Text
                SelectName.getCardCode = CardCode.Text
                SelectName.Source = "Z_OQUT"
                SelectName.MdiParent = MainForm
                SelectName.Show()
            Else
                CardCode.Text = sqlReader.Item("CardCode")
                sqlReader.Close()
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemCode()

        If ItemCodeTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "Z_OQUT"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemNameTxt.Text = sqlReader.Item("ItemName")
                sqlReader.Close()
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemName()

        If ItemNameTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [ItemCode]  FROM [OITM] WHERE [ItemName] = '" & ItemNameTxt.Text & "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "Z_OQUT"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemCodeTxt.Text = sqlReader.Item("ItemCode")
                sqlReader.Close()
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectKSEmpID()

        If KSEmpID.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [lastName],[empID] FROM [OHEM] WHERE [pager] = '" & KSEmpID.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無此人", 16, "錯誤")
                EmpName.Text = ""
                sapEmpId.Text = ""
                KSEmpID.Text = ""
                KSEmpID.Focus()
            Else
                EmpName.Text = sqlReader.Item("lastName")
                sapEmpId.Text = sqlReader.Item("empID")
                sqlReader.Close()
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        If CardCode.Text = "" Then
            MsgBox("客戶編號未填!", 16, "錯誤")
            CardCode.Focus()
            Exit Sub
        End If
        If CardName.Text = "" Then
            MsgBox("客戶名稱未填!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT distinct T1.[ItemCode], T1.[Dscription], '0' as '本次數量' FROM ODLN T0  INNER JOIN DLN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocStatus] = 'C' and  T0.[CardCode] = '" & CardCode.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV1Display()

    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "產品編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "Dscription"
                    column.HeaderText = "產品名稱"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "本次數量"
                    column.HeaderText = "件數"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If KSEmpID.Text = "" Then
            MsgBox("員工編號未填!", 16, "錯誤")
            KSEmpID.Focus()
            Exit Sub
        End If

        If DGV1.RowCount <= 0 Then
            MsgBox("無銷售資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim Cnt As Integer = 0
        For j As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(j).Cells("本次數量").Value > 0 Then
                Cnt = Cnt + 1
            End If
        Next

        If Cnt = 0 Then
            MsgBox("銷售數量為0!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oQuot As SAPbobsCOM.Documents
        Dim X As Integer = 0
        Dim RetVal As Long

        oQuot = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oQuotations)

        oQuot.CardCode = CardCode.Text
        oQuot.Comments = Now + " 接單者：" + EmpName.Text + vbCrLf + CommentsTxt.Text

        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("本次數量").Value > 0 Then
                oQuot.Lines.SetCurrentLine(X)
                oQuot.Lines.ItemCode = DGV1.Rows(i).Cells("ItemCode").Value '項目號碼
                oQuot.Lines.Quantity = DGV1.Rows(i).Cells("本次數量").Value
                oQuot.Lines.Add()
                X = X + 1
            End If

        Next
        RetVal = oQuot.Add

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        MsgBox("新增至B1完成!!", 64, "完成")

        OQUTDocNum = Login.oCompany.GetNewObjectKey()
        SendMsg()
        ClearAll()

    End Sub

    Private Sub SendMsg()
        Dim oCmpSrv As SAPbobsCOM.CompanyService
        Dim oMessageService As SAPbobsCOM.MessagesService

        oCmpSrv = Login.oCompany.GetCompanyService
        'get msg service
        oMessageService = oCmpSrv.GetBusinessService(SAPbobsCOM.ServiceTypes.MessagesService)

        Dim oMessage As SAPbobsCOM.Message
        Dim pMessageDataColumns As SAPbobsCOM.MessageDataColumns
        Dim pMessageDataColumn As SAPbobsCOM.MessageDataColumn
        Dim oLines As SAPbobsCOM.MessageDataLines
        Dim oLine As SAPbobsCOM.MessageDataLine
        Dim oRecipientCollection As SAPbobsCOM.RecipientCollection

        Try
            'get the data interface for the new message
            oMessage = oMessageService.GetDataInterface(SAPbobsCOM.MessagesServiceDataInterfaces.msdiMessage)
            'fill subject
            oMessage.Subject = "已新增一筆報價單，請查收。" '主旨
            oMessage.Text = Now + " 接單者：" + EmpName.Text + vbCrLf + CommentsTxt.Text  '內文
            'Add Recipient 
            oRecipientCollection = oMessage.RecipientCollection
            oRecipientCollection.Add()
            'send internal message
            oRecipientCollection.Item(0).SendInternal = SAPbobsCOM.BoYesNoEnum.tYES
            'add existing user name
            oRecipientCollection.Item(0).UserCode = "KS08" ' 收件者
            'get columns data
            pMessageDataColumns = oMessage.MessageDataColumns
            'get column
            pMessageDataColumn = pMessageDataColumns.Add()
            'set column name
            pMessageDataColumn.ColumnName = "報價單號" '欄位名稱
            'set link to a real object in the application
            pMessageDataColumn.Link = SAPbobsCOM.BoYesNoEnum.tYES
            'get lines
            oLines = pMessageDataColumn.MessageDataLines()
            'add new line
            oLine = oLines.Add()
            'set the line value
            oLine.Value = OQUTDocNum ' 欄位內容
            'set the link to BusinessPartner (the object type for Bp is 2)
            oLine.Object = 23 '文件類型 23=報價單
            'set the Bp code
            oLine.ObjectKey = OQUTDocNum '文件號碼
            '第二欄
            pMessageDataColumn = pMessageDataColumns.Add()
            'set column name
            pMessageDataColumn.ColumnName = "客戶編號" '欄位名稱
            'set link to a real object in the application
            pMessageDataColumn.Link = SAPbobsCOM.BoYesNoEnum.tNO
            'get lines
            oLines = pMessageDataColumn.MessageDataLines()
            'add new line
            oLine = oLines.Add()
            'set the line value
            oLine.Value = CardCode.Text ' 欄位內容   
            '第三欄
            pMessageDataColumn = pMessageDataColumns.Add()
            'set column name
            pMessageDataColumn.ColumnName = "客戶名稱" '欄位名稱
            'set link to a real object in the application
            pMessageDataColumn.Link = SAPbobsCOM.BoYesNoEnum.tNO
            'get lines
            oLines = pMessageDataColumn.MessageDataLines()
            'add new line
            oLine = oLines.Add()
            'set the line value
            oLine.Value = CardName.Text ' 欄位內容  
            'send the message
            oMessageService.SendMessage(oMessage)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearAll()
        CardName.Text = ""
        CardCode.Text = ""
        CommentsTxt.Text = ""
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        ks1DataSetDGV.Tables("DT1").Clear()
    End Sub

    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("未有銷售資料!", 16, "錯誤")
            Exit Sub
        End If

        If ItemCodeTxt.Text = "" Then
            MsgBox("項目編號未填!", 16, "錯誤")
            ItemCodeTxt.Focus()
            Exit Sub
        End If

        If ItemNameTxt.Text = "" Then
            MsgBox("項目名稱未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If


        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("輸入的項目編號有誤!", 16, "錯誤")
                ItemCodeTxt.Focus()
                Exit Sub
            End If

            Dim Row As DataRow
            Row = ks1DataSetDGV.Tables("DT1").NewRow
            Row.Item("ItemCode") = ItemCodeTxt.Text
            Row.Item("Dscription") = ItemNameTxt.Text
            Row.Item("本次數量") = 0

            ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

            ItemCodeTxt.Text = ""
            ItemNameTxt.Text = ""

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

   
End Class