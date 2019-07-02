Public Class B_QckAddOWOR
    Dim DocNum As Integer
    Dim StrM01, StrM03, ICode, IName As String


    Private Sub B_QckAddOWOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TaxDate.Value = DocDate.Value.Date.AddDays(1)
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
    End Sub

    Private Sub ProductType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductType.SelectedIndexChanged
        SelectType()
    End Sub

    Private Sub SelectType()

        Select Case Microsoft.VisualBasic.Left(ProductType.Text, 3)
            Case "2-1"
                ICode = "252210000000000"
                IName = "分切-土雞"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case "2-2"
                ICode = "252220000000000"
                IName = "分切-烏骨雞"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "002"
            Case "2-3"
                ICode = "252240000000000"
                IName = "分切-人家土雞"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "003"
            Case "3-1"
                ICode = "252110000000000"
                IName = "領改-土雞"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case "3-2"
                ICode = "252120000000000"
                IName = "領改-烏骨雞"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "002"
            Case "3-3"
                ICode = "252140000000000"
                IName = "領改-人家土雞"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "003"
            Case "D-1"
                ICode = "252220000000000"
                IName = "分切-烏骨雞"
                StrM01 = "D"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case "2-7"
                ICode = "252230000000000"
                IName = "分切-白露花"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "007"
            Case "3-5"
                ICode = "252130000000000"
                IName = "領改-白露花"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "005"
            Case "3-7"
                ICode = "2521K0000000000"
                IName = "領改-黃金雞"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "007"
            Case "5-1"
                ICode = "3122P0000000000"
                IName = "代分切-香草雞"
                StrM01 = "5"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case "6-1"
                ICode = "3121P0000000000"
                IName = "代領改-香草雞"
                StrM01 = "6"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case "4-1"
                ICode = "3301P00000001"
                IName = "代宰香草雞毛雞"
                StrM01 = "4"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "001"
            Case "2-4"
                ICode = "252210000000000"
                IName = "分切-土雞"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "004"
            Case "3-4"
                ICode = "2521Q0000000000"
                IName = "領改-桂丁土雞"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "004"
            Case "2-8"
                ICode = "2522Q0000000000"
                IName = "分切-桂丁土"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "008"
            Case "2-6"
                ICode = "252270000000000"
                IName = "分切-肉雞"
                StrM01 = "2"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "006"
            Case "3-6"
                ICode = "252170000000000"
                IName = "領改-肉雞"
                StrM01 = "3"
                StrM03 = StrM01 + Format(TaxDate.Value.Date, "yyMMdd") + "006"
            Case ""
                ClearAll()
                Exit Sub
        End Select

        txtItemCode.Text = ICode
        txtItemName.Text = IName
        M03.Text = StrM03
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click

        If ProductType.SelectedIndex = -1 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If M03.Text = "" Then
            MsgBox("無製單單號資料!", 16, "錯誤")
            Exit Sub
        End If

        If MyLen(M03.Text) <> 10 Then
            MsgBox("製單單號錯誤!", 16, "錯誤")
            Exit Sub
        End If

        If txtItemCode.Text = "" Then
            MsgBox("無產品資料!", 16, "錯誤")
            Exit Sub
        End If

        If txtPlanQty.Text = "" Then
            MsgBox("無數量資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oProductionOrders As SAPbobsCOM.ProductionOrders
        Dim RetVal As Long

        oProductionOrders = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders)

        oProductionOrders.ProductionOrderType = SAPbobsCOM.BoProductionOrderTypeEnum.bopotDisassembly        
        oProductionOrders.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposPlanned
        oProductionOrders.ItemNo = txtItemCode.Text
        oProductionOrders.PlannedQuantity = txtPlanQty.Text
        oProductionOrders.PostingDate = DocDate.Value.Date
        oProductionOrders.DueDate = TaxDate.Value.Date
        oProductionOrders.UserFields.Fields.Item("U_M01").Value = StrM01
        oProductionOrders.UserFields.Fields.Item("U_M03").Value = M03.Text
        oProductionOrders.UserFields.Fields.Item("U_M04").Value = "Y"

        RetVal = oProductionOrders.Add()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        DocNum = Login.oCompany.GetNewObjectKey()
        updateOWOR()
        MsgBox("新增至B1完成!!" & vbCrLf & "單號：" & DocNum, 64, "完成")

        ClearAll()
    End Sub

    Private Sub updateOWOR()
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oProductionOrders As SAPbobsCOM.ProductionOrders
        Dim X As Integer = 0
        Dim RetVal As Long

        oProductionOrders = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders)
        oProductionOrders.GetByKey(DocNum)
        oProductionOrders.ProductionOrderStatus = SAPbobsCOM.BoProductionOrderStatusEnum.boposReleased

        RetVal = oProductionOrders.Update()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("更新訂單狀態錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            'ClearAll()
            Exit Sub
        End If

    End Sub

    Private Sub ClearAll()
        ProductType.SelectedIndex = -1
        txtItemCode.Text = ""
        txtItemName.Text = ""
        M03.Text = ""
        txtPlanQty.Text = "9999999"
        DocDate.Value = Today
        TaxDate.Value = DocDate.Value.Date.AddDays(1)
    End Sub

End Class