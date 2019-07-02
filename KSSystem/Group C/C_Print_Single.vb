Public Class C_Print_Single

    Dim PrinterName As String

    Private Declare Sub openport Lib "tsclib.dll" (ByVal PrinterName As String)
    Private Declare Sub closeport Lib "tsclib.dll" ()
    Private Declare Sub sendcommand Lib "tsclib.dll" (ByVal command_Renamed As String)
    Private Declare Sub setup Lib "tsclib.dll" (ByVal LabelWidth As String, ByVal LabelHeight As String, ByVal Speed As String, ByVal Density As String, ByVal Sensor As String, ByVal Vertical As String, ByVal Offset As String)
    Private Declare Sub downloadpcx Lib "tsclib.dll" (ByVal Filename As String, ByVal ImageName As String)
    Private Declare Sub barcode Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal CodeType As String, ByVal Height_Renamed As String, ByVal Readable As String, ByVal rotation As String, ByVal Narrow As String, ByVal Wide As String, ByVal Code As String)
    Private Declare Sub printerfont Lib "tsclib.dll" (ByVal X As String, ByVal Y As String, ByVal FontName As String, ByVal rotation As String, ByVal Xmul As String, ByVal Ymul As String, ByVal Content As String)
    Private Declare Sub clearbuffer Lib "tsclib.dll" ()
    Private Declare Sub printlabel Lib "tsclib.dll" (ByVal NumberOfSet As String, ByVal NumberOfCopy As String)
    Private Declare Sub formfeed Lib "tsclib.dll" ()
    Private Declare Sub nobackfeed Lib "tsclib.dll" ()
    Private Declare Sub windowsfont Lib "tsclib.dll" (ByVal X As Short, ByVal Y As Short, ByVal fontheight_Renamed As Short, ByVal rotation As Short, ByVal fontstyle As Short, ByVal fontunderline As Short, ByVal FaceName As String, ByVal TextContent As String)



    Private Sub C_Print_Single_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Structure LabeData1  '電宰標籤
        Dim PQty As Integer
        Dim Itemname As String
        Dim Barcode As String
        Dim Weight As String
        Dim Qty As String
        Dim Unit As String
        Dim MDate As String
        Dim DDate As String
    End Structure

    Structure LabeData2  '加工標籤
        Dim PntQty As Integer
        Dim Itemname As String
        Dim Barcode As String
        Dim Qty As String
        Dim Unit As String
        Dim MDate As String
        Dim DDate As String
    End Structure

    Structure LabeData3  '儲位標籤
        Dim PntQty As Integer
        Dim Barcode As String
    End Structure

    Structure LabeData4  '固定資產標籤
        Dim PntQty As Integer
        Dim Itemname As String
        Dim Barcode As String
    End Structure

    Private Sub btnPrint1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint1.Click
        '電宰條碼
        Dim oAns As Integer
        oAns = MsgBox("確定列印條碼嗎?", MsgBoxStyle.OkCancel, "確認列印")
        If oAns = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrinterName = PrintDialog1.PrinterSettings.PrinterName
        End If

        Dim labelData As String = ""
        
        Dim olabel As LabeData1 = New LabeData1
        With olabel
            .PQty = CInt(tbx1_1.Text)
            .Itemname = tbx1_2.Text
            .Barcode = tbx1_3.Text
            .Weight = tbx1_4.Text
            .Qty = tbx1_5.Text
            .DDate = tbx1_7.Text
            .MDate = tbx1_6.Text
        End With
        SentToPrinter1(olabel)

    End Sub

    Private Sub btnPrint2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint2.Click
        '加工條碼
        Dim oAns As Integer
        oAns = MsgBox("確定列印條碼嗎?", MsgBoxStyle.OkCancel, "確認列印")
        If oAns = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrinterName = PrintDialog1.PrinterSettings.PrinterName
        End If

        Dim labelData As String = ""

        Dim olabel As LabeData2 = New LabeData2
        With olabel
            .PntQty = CInt(tbx2_1.Text)
            .Itemname = tbx2_2.Text
            .Barcode = tbx2_3.Text
            .Qty = tbx2_4.Text
            .DDate = tbx2_6.Text
            .MDate = tbx2_5.Text
        End With
        SentToPrinter2(olabel)

    End Sub

    Private Sub btnPrint3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint3.Click
        '儲位
        Dim oAns As Integer
        oAns = MsgBox("確定列印條碼嗎?", MsgBoxStyle.OkCancel, "確認列印")
        If oAns = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrinterName = PrintDialog1.PrinterSettings.PrinterName
        End If

        Dim labelData As String = ""

        Dim olabel As LabeData3 = New LabeData3
        With olabel
            .PntQty = CInt(tbx3_1.Text)
            .Barcode = tbx3_2.Text
        End With
        SentToPrinter3(olabel)

    End Sub

    Private Sub btnPrint4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint4.Click
        '固定資產
        Dim oAns As Integer
        oAns = MsgBox("確定列印條碼嗎?", MsgBoxStyle.OkCancel, "確認列印")
        If oAns = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrinterName = PrintDialog1.PrinterSettings.PrinterName
        End If

        Dim labelData As String = ""

        Dim olabel As LabeData4 = New LabeData4
        With olabel
            .PntQty = CInt(tbx4_1.Text)
            .Itemname = tbx4_2.Text
            .Barcode = tbx4_3.Text
        End With
        SentToPrinter4(olabel)

    End Sub

    Private Sub SentToPrinter1(ByVal olabel As LabeData1)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = ""
            Dim Itemname2 As String = ""
            Dim Counter As Integer = 0

            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then
                    Itemname1 = Itemname1 & Chr
                Else
                    Itemname2 = Itemname2 & Chr
                End If
            Next

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1)
            '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "135", "128", "50", "1", "0", "3", "3", olabel.Barcode)
        '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        'Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode)

        '3.重量 
        Call windowsfont(44, 210, 40, 0, 2, 0, "新細明體", olabel.Weight)
        '4.數量
        Call windowsfont(290, 185, 70, 0, 2, 0, "新細明體", olabel.Qty)
        '5.有效日期
        If olabel.MDate = "" Then

        Else
            Call windowsfont(45, 250, 25, 0, 2, 0, "新細明體", olabel.MDate)
        End If
        '6.製造日期
        If olabel.DDate = "" Then

        Else
            Call windowsfont(45, 275, 25, 0, 2, 0, "新細明體", olabel.DDate)
        End If

        '定義列印張數
        Call printlabel("1", olabel.PQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub

    '驅動列印加工標籤

    Private Sub SentToPrinter2(ByVal olabel As LabeData2)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = ""
            Dim Itemname2 As String = ""
            Dim Counter As Integer = 0

            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then
                    Itemname1 = Itemname1 & Chr
                Else
                    Itemname2 = Itemname2 & Chr
                End If
            Next

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1)
            '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "135", "128", "50", "1", "0", "3", "3", olabel.Barcode)
        '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        'Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode)

        '4.數量
        Call windowsfont(290, 185, 70, 0, 2, 0, "新細明體", olabel.Qty)
        '5.有效日期
        If olabel.MDate = "" Then

        Else
            Call windowsfont(45, 250, 25, 0, 2, 0, "新細明體", olabel.MDate)
        End If
        '6.製造日期
        If olabel.DDate = "" Then

        Else
            Call windowsfont(45, 275, 25, 0, 2, 0, "新細明體", olabel.DDate)
        End If

        '定義列印張數
        Call printlabel("1", olabel.PntQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub

    Private Sub SentToPrinter3(ByVal olabel As LabeData3)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        'If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
        '    Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        'Else
        '    Dim Itemname1 As String = ""
        '    Dim Itemname2 As String = ""
        '    Dim Counter As Integer = 0

        'For Each Chr As Char In olabel.Itemname
        '    Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
        '    If Counter <= 14 Then
        '        Itemname1 = Itemname1 & Chr
        '    Else
        '        Itemname2 = Itemname2 & Chr
        '    End If
        'Next

        'Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1)
        ''列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
        'Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
        'baseLine = 5
        'End If

        '2.條碼code128
        Call barcode("56", "135", "128", "80", "1", "0", "3", "3", olabel.Barcode)
        '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        'Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode)

        ''4.數量
        'Call windowsfont(290, 185, 70, 0, 2, 0, "新細明體", olabel.Qty)
        ''5.有效日期
        'If olabel.MDate = "" Then

        'Else
        '    Call windowsfont(45, 250, 25, 0, 2, 0, "新細明體", olabel.MDate)
        'End If
        ''6.製造日期
        'If olabel.DDate = "" Then

        'Else
        '    Call windowsfont(45, 275, 25, 0, 2, 0, "新細明體", olabel.DDate)
        'End If

        '定義列印張數
        Call printlabel("1", olabel.PntQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub

    '驅動列印固定資產
    Private Sub SentToPrinter4(ByVal olabel As LabeData4)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(25, 50, 65, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = ""
            Dim Itemname2 As String = ""
            Dim Counter As Integer = 0

            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then
                    Itemname1 = Itemname1 & Chr
                Else
                    Itemname2 = Itemname2 & Chr
                End If
            Next

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1)
            '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "135", "128", "80", "1", "0", "3", "3", olabel.Barcode)
        '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        'Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode)

        ''4.數量
        'Call windowsfont(290, 185, 70, 0, 2, 0, "新細明體", olabel.Qty)
        ''5.有效日期
        'If olabel.MDate = "" Then

        'Else
        '    Call windowsfont(45, 250, 25, 0, 2, 0, "新細明體", olabel.MDate)
        'End If
        ''6.製造日期
        'If olabel.DDate = "" Then

        'Else
        '    Call windowsfont(45, 275, 25, 0, 2, 0, "新細明體", olabel.DDate)
        'End If

        '定義列印張數
        Call printlabel("1", olabel.PntQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub



    ''驅動列印儲位標籤
    'Private Sub SentToPrinter3(ByVal olabel As LabeData3)

    '    Dim RP As Ring = New Ring
    '    Dim Tag_W As Integer, Tag_H As Integer
    '    Dim baseLine As Integer = 5.5


    '    '定義條碼font size
    '    Tag_W = 60
    '    Tag_H = 40

    '    '開始列印時條碼機型號
    '    RP.StartPrinter(pFunction.ksParameter(10))

    '    '定義font
    '    RP.FMT(1, "65", "40", False, 0, 1)

    '    '1.條碼內容        
    '    RP.GetBIM("10", CStr(20.5 + baseLine), New Font("Arial Rounded MT", 9), olabel.Barcode)

    '    '2.條碼128碼
    '    RP.BFL("11.5", CStr(11.5 + baseLine), 1, 8, "9", "/7" + olabel.Barcode)


    '    '定義列印張數
    '    RP.PRT(olabel.PntQty, 0, 1)
    '    '結束列印
    '    RP.EndPrinter()

    'End Sub

    ''驅動列印固定資產標籤
    'Private Sub SentToPrinter4(ByVal olabel As LabeData4)

    '    Dim RP As Ring = New Ring
    '    Dim Tag_W As Integer, Tag_H As Integer
    '    Dim baseLine As Integer = 5.5

    '    '定義條碼font size
    '    Tag_W = 60
    '    Tag_H = 40

    '    '開始列印時條碼機型號
    '    RP.StartPrinter(pFunction.ksParameter(10))

    '    '定義font
    '    RP.FMT(1, "65", "40", False, 0, 1)

    '    '1.品名
    '    RP.GetBIM("9", "4", New Font("新細明體", 17, FontStyle.Bold), olabel.Itemname)

    '    '2.條碼128碼
    '    RP.BFL("11.5", CStr(11.5 + baseLine), 1, 8, "9", "/7" + olabel.Barcode)

    '    '3.條碼內容
    '    RP.GetBIM("10", CStr(20.5 + baseLine), New Font("Arial Rounded MT", 9), olabel.Barcode)

    '    '定義列印張數
    '    RP.PRT(olabel.PntQty, 0, 1)
    '    '結束列印
    '    RP.EndPrinter()

    'End Sub
End Class