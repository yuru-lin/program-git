Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_CostcoPayment
    Dim AT1_RecordType, AT1_MessageFunction, AT1_RetailerID, AT1_OrderNo, AT1_DeliveryCode, AT1_PlaceOfDelivery, AT1_OrderDate, AT1_BatchNp, AT1_DeliveryDate, AT1_DeadLine, AT1_SupplierCode, AT1_DeptCode, AT1_RespPeople, AT1_TimeStamp As String
    Dim AT2_RecordType, AT2_SeqNo, AT2_Barcode, AT2_ProductCode, AT2_ProductName, AT2_ProductSpec, AT2_UnitPrice, AT2_OrderQty, AT2_Unit, AT2_PackUnit, AT2_PackBox, AT2_PackQty, AT2_SalesAmount, AT2_FreeGoods, AT2_Reserved As String
    Dim BT1_RecordType, BT1_FormCode, BT1_DeductType, BT1_InvoiceType, BT1_InvoiceStat, BT1_InvoiceNo, BT1_CheckDigit, BT1_InvoiceDate, BT1_SalesAmout, BT1_VATType, BT1_VATAmount, BT1_InvoiceAmout, BT1_invoiceBAN, BT1_StoreNo, BT1_InvoiceName, BT1_InvoiceAddress, BT1_InvoiceContact, BT1_CWMark, BT1_ReferenceQualifier1, BT1_Reference1, BT1_ReferenceQualifier2, BT1_Reference2, BT1_InvoiceReport, BT1_Remarks, BT1_Reserved, BT1_SellerBAN, BT1_SellerEAN, BT1_SellerName, BT1_SellerAddress, BT1_SelleTel, BT1_SellerRep, BT1_Seller, BT1_DigitalApprovalAgency, BT1_DigitalApprovalDate, BT1_DigitalApprovalDoc As String
    Dim BT2_RecordType, BT2_SeqNo, BT2_BuyerProductCode, BT2_SellerProductCode, BT2_Barcode, BT2_ProductName, BT2_QTY, BT2_Unit, BT2_UnitPrice, BT2_Amout, BT2_Reserved As String

    Private Sub D_CostcoPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub InputTxtBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputTxtBtn.Click

        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "Text files(*.txt)|*.txt"    '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        If FromTxt.Text <> "" Then
            FromTxt.Text = ""
        End If

        If ToTxt.Text <> "" Then
            ToTxt.Text = ""
        End If

        Dim sr As StreamReader = New StreamReader(openfile.FileName, System.Text.Encoding.Default)
        Dim line As String


        Do While sr.Peek() >= 0
            line = sr.ReadLine()
            FromTxt.Text += line + vbCrLf

            If Microsoft.VisualBasic.Left(line, 2) = "T1" Then
                AT1_RecordType = MyMid(line, 1, 2)
                AT1_MessageFunction = MyMid(line, 3, 1)
                AT1_RetailerID = MyMid(line, 4, 20)
                AT1_OrderNo = MyMid(line, 24, 20)
                AT1_DeliveryCode = MyMid(line, 44, 20)
                AT1_PlaceOfDelivery = MyMid(line, 64, 50)
                AT1_OrderDate = MyMid(line, 114, 8)
                AT1_BatchNp = MyMid(line, 122, 4)
                AT1_DeliveryDate = MyMid(line, 126, 12)
                AT1_DeadLine = MyMid(line, 138, 12)
                AT1_SupplierCode = MyMid(line, 150, 20)
                AT1_DeptCode = MyMid(line, 170, 10)
                AT1_RespPeople = MyMid(line, 180, 20)
                AT1_TimeStamp = MyMid(line, 200, 14)
                T1()
            End If

            If Microsoft.VisualBasic.Left(line, 2) = "T2" Then
                AT2_RecordType = MyMid(line, 1, 2)
                AT2_SeqNo = MyMid(line, 3, 4)
                AT2_Barcode = MyMid(line, 7, 20)
                AT2_ProductCode = MyMid(line, 27, 20)
                AT2_ProductName = MyMid(line, 47, 150)
                AT2_ProductSpec = MyMid(line, 197, 60)
                AT2_UnitPrice = MyMid(line, 257, 12)
                AT2_OrderQty = MyMid(line, 269, 12)
                AT2_Unit = MyMid(line, 281, 15)
                AT2_PackUnit = MyMid(line, 296, 15)
                AT2_PackBox = MyMid(line, 311, 12)
                AT2_PackQty = MyMid(line, 323, 12)
                AT2_SalesAmount = MyMid(line, 335, 14)
                AT2_FreeGoods = MyMid(line, 349, 12)
                AT2_Reserved = MyMid(line, 361, 40)
                T2()
            End If
        Loop
        sr.Close()
    End Sub
    Private Sub T1()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT T0.[U_I_num], T0.[U_AR_code], T0.[DocDate],cast((T0.[DocTotal] -  T0.[DiscSum] - T0.[VatSum]) as int) as 'SalesAmout' ,T0.[U_Tax_type], cast(T0.[VatSum] as int) as 'VatSum', cast(T0.[DocTotal] as int ) as 'DocTotal', T0.[LicTradNum], T0.[CardName], T1.[StreetB] FROM OINV T0  INNER JOIN INV12 T1 ON T0.DocEntry = T1.DocEntry  WHERE T0.[U_COSCO] = '" & AT1_OrderNo & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            Dim Err As String = "單據：" + AT1_OrderNo + "有誤!"
            ToTxt.Text += Err + vbCrLf

            'Dim iPos As Integer

            'iPos = ToTxt.Find(Err)
            'Do While iPos > 0
            '    ToTxt.SelectionStart = iPos
            '    ToTxt.SelectionLength = Err.Length
            '    ToTxt.SelectionColor = Color.Red

            '    iPos = ToTxt.Find(Err, iPos + 1, )
            'Loop

            ToTxt.Find(Err)
            'ToTxt.Select(ToTxt.Text.Length - Err.Length, Err.Length)
            ToTxt.SelectionStart = ToTxt.Text.Length - Err.Length
            ToTxt.SelectionLength = Err.Length
            ToTxt.SelectionColor = Color.Red
            'ToTxt.SelectionColor = Color.Red
            Exit Sub
        End If

        BT1_RecordType = "T1"
        BT1_FormCode = "31"
        BT1_DeductType = "1"
        BT1_InvoiceType = "1"
        BT1_InvoiceStat = "O"
        BT1_InvoiceNo = sqlReader.Item("U_I_num")
        BT1_CheckDigit = sqlReader.Item("U_AR_code")
        BT1_CheckDigit = BT1_CheckDigit.PadRight(5)
        Dim DF As DateTime
        DF = sqlReader.Item("DocDate")
        BT1_InvoiceDate = Format(DF, "yyyyMMdd")
        BT1_SalesAmout = sqlReader.Item("SalesAmout")
        BT1_SalesAmout = BT1_SalesAmout.PadLeft(12)
        BT1_VATType = sqlReader.Item("U_Tax_type")
        BT1_VATAmount = sqlReader.Item("VatSum")
        BT1_VATAmount = BT1_VATAmount.PadLeft(10)
        BT1_InvoiceAmout = sqlReader.Item("DocTotal")
        BT1_InvoiceAmout = BT1_InvoiceAmout.PadLeft(12)
        BT1_invoiceBAN = sqlReader.Item("LicTradNum")
        BT1_StoreNo = "             "

        BT1_InvoiceName = sqlReader.Item("CardName")
        Dim CntInvName As Integer = MyLen(BT1_InvoiceName)
        Dim CntInvNameNeed As Integer = 60 - CntInvName
        Dim InvNameNeed As String = ""
        InvNameNeed = InvNameNeed.PadRight(CntInvNameNeed)
        BT1_InvoiceName = BT1_InvoiceName + InvNameNeed

        BT1_InvoiceAddress = sqlReader.Item("StreetB")
        Dim CntInvAdd As Integer = MyLen(BT1_InvoiceAddress)
        Dim CntInvAddNeed As Integer = 70 - CntInvAdd
        Dim InvAddNeed As String = ""
        InvAddNeed = InvAddNeed.PadRight(CntInvAddNeed)
        BT1_InvoiceAddress = BT1_InvoiceAddress + InvAddNeed

        BT1_InvoiceContact = "                    "
        BT1_CWMark = " "
        BT1_ReferenceQualifier1 = "PO "
        BT1_Reference1 = AT1_OrderNo
        BT1_ReferenceQualifier2 = "   "
        BT1_Reference2 = "                    "
        BT1_InvoiceReport = "            "
        BT1_Remarks = "                                                                                                    "
        BT1_Reserved = "                                                                                                    "
        BT1_SellerBAN = "86220637"
        BT1_SellerEAN = "4560-00      "
        BT1_SellerName = "凱馨實業股份有限公司                                        "
        BT1_SellerAddress = "斗六市八德里引善路196號                                               "
        BT1_SelleTel = "(05)5347888         "
        BT1_SellerRep = "鄧進得    "
        BT1_Seller = "                    "
        BT1_DigitalApprovalAgency = "          "
        BT1_DigitalApprovalDate = "        "
        BT1_DigitalApprovalDoc = "                    "

        ToTxt.Text += BT1_RecordType + BT1_FormCode + BT1_DeductType + BT1_InvoiceType + BT1_InvoiceStat + BT1_InvoiceNo + BT1_CheckDigit + BT1_InvoiceDate + BT1_SalesAmout + BT1_VATType + BT1_VATAmount + BT1_InvoiceAmout + BT1_invoiceBAN + BT1_StoreNo + BT1_InvoiceName + BT1_InvoiceAddress + BT1_InvoiceContact + BT1_CWMark + BT1_ReferenceQualifier1 + BT1_Reference1 + BT1_ReferenceQualifier2 + BT1_Reference2 + BT1_InvoiceReport + BT1_Remarks + BT1_Reserved + BT1_SellerBAN + BT1_SellerEAN + BT1_SellerName + BT1_SellerAddress + BT1_SelleTel + BT1_SellerRep + BT1_Seller + BT1_DigitalApprovalAgency + BT1_DigitalApprovalDate + BT1_DigitalApprovalDoc + vbCrLf

        sqlReader.Close()

    End Sub

    Private Sub T2()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT T2.[CodeBars], T2.[FrgnName], cast(T1.[U_P4] as int) as 'U_P4', T2.[SalPackMsr], cast(T1.[U_P8] as int) as 'U_P8', cast(T1.[LineTotal] as int) as 'LineTotal' FROM OINV T0  INNER JOIN INV1 T1 ON T0.DocEntry = T1.DocEntry INNER JOIN OITM T2 ON T1.ItemCode = T2.ItemCode WHERE T0.[U_COSCO]  = '" & AT1_OrderNo & "' and T2.[CodeBars] = '" & Trim(AT2_Barcode) & "' "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            Dim Err As String = "項次：" + AT2_SeqNo + "有誤!"
            ToTxt.Text += Err + vbCrLf
            ToTxt.Find(Err)
            ToTxt.SelectionColor = Color.Red
            Exit Sub
        End If

        BT2_RecordType = "T2"
        BT2_SeqNo = AT2_SeqNo
        BT2_BuyerProductCode = sqlReader.Item("CodeBars")
        BT2_BuyerProductCode = BT2_BuyerProductCode.PadRight(20)
        BT2_SellerProductCode = "                    "
        BT2_Barcode = sqlReader.Item("CodeBars")
        BT2_Barcode = BT2_Barcode.PadRight(20)

        BT2_ProductName = sqlReader.Item("FrgnName")
        Dim CntProductName As Integer = MyLen(BT2_ProductName)
        Dim CntProductNameNeed As Integer = 70 - CntProductName
        Dim ProductNameNeed As String = ""
        ProductNameNeed = ProductNameNeed.PadRight(CntProductNameNeed)
        BT2_ProductName = BT2_ProductName + ProductNameNeed
        BT2_QTY = sqlReader.Item("U_P4")
        BT2_QTY = BT2_QTY.PadLeft(11)
        BT2_Unit = sqlReader.Item("SalPackMsr")
        Dim CntUnit As Integer = MyLen(BT2_Unit)
        Dim CntUnitNeed As Integer = 6 - CntUnit
        Dim UnitNeed As String = ""
        UnitNeed = UnitNeed.PadRight(CntUnitNeed)
        BT2_Unit = BT2_Unit + UnitNeed
        BT2_UnitPrice = sqlReader.Item("U_P8")
        BT2_UnitPrice = BT2_UnitPrice.PadLeft(15)
        BT2_Amout = sqlReader.Item("LineTotal")
        BT2_Amout = BT2_Amout.PadLeft(12)
        BT2_Reserved = "                                        "


        If BT2_QTY.Trim() <> AT2_OrderQty.Trim() Then
            Dim Err As String = "項次：" + AT2_SeqNo + "的數量有誤!"
            ToTxt.Text += Err + vbCrLf
            ToTxt.Find(Err)
            ToTxt.SelectionColor = Color.Red
        ElseIf BT2_Amout.Trim() <> Fix(AT2_SalesAmount) Then
            Dim Err As String = "項次：" + AT2_SeqNo + "的金額有誤!"
            ToTxt.Text += Err + vbCrLf
            ToTxt.Find(Err)
            ToTxt.SelectionColor = Color.Red
        Else
            ToTxt.Text += BT2_RecordType + BT2_SeqNo + BT2_BuyerProductCode + BT2_SellerProductCode + BT2_Barcode + BT2_ProductName + BT2_QTY + BT2_Unit + BT2_UnitPrice + BT2_Amout + BT2_Reserved + vbCrLf
        End If

        sqlReader.Close()
    End Sub

    Private Sub OutputBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutputBtn.Click


        Dim Dt As String = Format(Now(), "yyMMddhhmmss")
        Dim Name As String = "O-86220637-" + Dt

        Dim kk As New SaveFileDialog()
        kk.Title = "儲存TXT文件"
        kk.Filter = "TXT文件(*.txt) |*.txt |所有文件(*.*) |*.*"
        kk.FilterIndex = 1
        kk.InitialDirectory = "C:\Program Files\SEPower\InvText\"
        kk.FileName = Name


        If kk.ShowDialog() = DialogResult.OK Then
            Dim FileName As String = kk.FileName ' + ".txt"
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If

            'Dim f As New FileInfo(FileName)
            Dim sw As New StreamWriter(FileName, False, System.Text.Encoding.GetEncoding(950))

            sw.Write(ToTxt.Text)
            sw.Flush()
            sw.Close()

            MessageBox.Show(Me, "儲存TXT成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class