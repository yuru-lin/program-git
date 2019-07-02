Public Class 條碼列印V100

    '------>條碼機列印資訊_開始 <------
    Private Declare Sub openport Lib "TSCLib.dll" (ByVal PrinterName As String)
    Private Declare Sub closeport Lib "TSCLib.dll" ()
    Private Declare Sub sendcommand Lib "TSCLib.dll" (ByVal command_Renamed As String)
    Private Declare Sub setup Lib "TSCLib.dll" (ByVal LabelWidth As String, ByVal LabelHeight As String, ByVal Speed As String, ByVal Density As String, ByVal Sensor As String, ByVal Vertical As String, ByVal Offset As String)
    Private Declare Sub downloadpcx Lib "TSCLib.dll" (ByVal Filename As String, ByVal ImageName As String)
    Private Declare Sub barcode Lib "TSCLib.dll" (ByVal X As String, ByVal Y As String, ByVal CodeType As String, ByVal Height_Renamed As String, ByVal Readable As String, ByVal rotation As String, ByVal Narrow As String, ByVal Wide As String, ByVal Code As String)
    Private Declare Sub printerfont Lib "TSCLib.dll" (ByVal X As String, ByVal Y As String, ByVal FontName As String, ByVal rotation As String, ByVal Xmul As String, ByVal Ymul As String, ByVal Content As String)
    Private Declare Sub clearbuffer Lib "TSCLib.dll" ()
    Private Declare Sub printlabel Lib "TSCLib.dll" (ByVal NumberOfSet As String, ByVal NumberOfCopy As String)
    Private Declare Sub formfeed Lib "TSCLib.dll" ()
    Private Declare Sub nobackfeed Lib "TSCLib.dll" ()
    Private Declare Sub windowsfont Lib "TSCLib.dll" (ByVal X As Short, ByVal Y As Short, ByVal fontheight_Renamed As Short, ByVal rotation As Short, ByVal fontstyle As Short, ByVal fontunderline As Short, ByVal FaceName As String, ByVal TextContent As String)

    Structure LabeData  '列印標籤
        Dim PQty As Integer : Dim Itemname As String : Dim Barcode As String : Dim Weight As String : Dim Qty As String : Dim Unit As String : Dim MDate As String : Dim DDate As String
    End Structure
    '------>條碼機列印資訊__結束 <------



    Private Sub 條碼列印資訊(ByVal 作業 As String)
        Try '列印條碼標籤, 把資料填入LabeData變數中傳給printLabel()列印
            Dim olabel As LabeData = New LabeData
            'If 作業 = "1" Then
            '    With olabel
            '        .PQty = "1"
            '        .Itemname = T1退貨條碼.CurrentRow.Cells("簡稱").Value
            '        .Barcode = T1退貨條碼.CurrentRow.Cells("條碼").Value
            '        .Weight = Format(CSng(T1退貨條碼.CurrentRow.Cells("退貨重量").Value), "###0.00") & "Kg"
            '        .Qty = CInt(T1退貨條碼.CurrentRow.Cells("小單位數量").Value) & T1退貨條碼.CurrentRow.Cells("小單位").Value.ToString
            '        .Unit = T1退貨條碼.CurrentRow.Cells("小單位").Value
            '        .MDate = ""
            '        .DDate = ""
            '        'If CB製造日期.Checked Then : .MDate = "製造日期：" & Format(De製造日期.Value, "yyyy/MM/dd") : Else : .MDate = "  " : End If
            '        'If CB有效日期.Checked Then : .DDate = "有效日期：" & Format(De有效日期.Value, "yyyy/MM/dd") : Else : .DDate = "  " : End If
            '    End With
            '    'printlabel(olabel)
            '    SentToPrinter(olabel)

            '    'For j As Integer = 0 To T1退貨條碼.RowCount - 1
            '    '    With olabel
            '    '        .PQty = "1"
            '    '        .Itemname = T1退貨條碼.Rows(j).Cells("簡稱").Value.ToString
            '    '        .Barcode = T1退貨條碼.Rows(j).Cells("條碼").Value.ToString
            '    '        .Weight = Format(CSng(T1退貨條碼.Rows(j).Cells("退貨重量").Value), "###0.00") & "Kg"
            '    '        .Qty = CInt(T1退貨條碼.Rows(j).Cells("小單位數量").Value.ToString) & T1退貨條碼.Rows(j).Cells("小單位").Value.ToString
            '    '        .Unit = T1退貨條碼.Rows(j).Cells("小單位").Value.ToString
            '    '        .MDate = ""
            '    '        .DDate = ""
            '    '        'If CB製造日期.Checked Then : .MDate = "製造日期：" & Format(De製造日期.Value, "yyyy/MM/dd") : Else : .MDate = "  " : End If
            '    '        'If CB有效日期.Checked Then : .DDate = "有效日期：" & Format(De有效日期.Value, "yyyy/MM/dd") : Else : .DDate = "  " : End If
            '    '    End With
            '    '    'printlabel(olabel)
            '    '    SentToPrinter(olabel)
            '    'Next
            'End If

            'If 作業 = "3" Then
            '    For j As Integer = 0 To T3退貨條碼.RowCount - 1
            '        With olabel
            '            .PQty = "1"
            '            .Itemname = T3退貨條碼.Rows(j).Cells("簡稱").Value.ToString
            '            .Barcode = T3退貨條碼.Rows(j).Cells("條碼").Value.ToString
            '            .Weight = Format(CSng(T3退貨條碼.Rows(j).Cells("退貨重量").Value), "###0.00") & "Kg"
            '            .Qty = CInt(T3退貨條碼.Rows(j).Cells("小單位數量").Value.ToString) & T3退貨條碼.Rows(j).Cells("小單位").Value.ToString
            '            .Unit = T3退貨條碼.Rows(j).Cells("小單位").Value.ToString
            '            .MDate = ""
            '            .DDate = ""
            '            'If CB製造日期.Checked Then : .MDate = "製造日期：" & Format(De製造日期.Value, "yyyy/MM/dd") : Else : .MDate = "  " : End If
            '            'If CB有效日期.Checked Then : .DDate = "有效日期：" & Format(De有效日期.Value, "yyyy/MM/dd") : Else : .DDate = "  " : End If
            '        End With
            '        'printlabel(olabel)
            '        SentToPrinter(olabel)
            '    Next
            'End If



        Catch ex As Exception
            MsgBox("列印標籤 (" & ex.Message & ")")
            End
        End Try
    End Sub

    'Private Sub printLabel(ByVal olabel As LabeData)
    '    If 列印條碼 <> "Y" Then '不列印標籤 產生標籤列印文字檔
    '        Dim labelData As String
    '        labelData = Trim(T2列印張數.Text) & "," & olabel.Itemname & "," & olabel.Barcode & "," & olabel.Weight & "," & Trim(olabel.Qty) & Trim(olabel.Unit) & "," _
    '                    & Trim(olabel.MDate) & "," & Trim(olabel.DDate)
    '        'My.Computer.FileSystem.WriteAllText("C:\vispark\label.txt", labelData, False, System.Text.Encoding.Default)
    '        My.Computer.FileSystem.WriteAllText((Application.StartupPath & "\報表\label.txt"), labelData, False, System.Text.Encoding.Default)
    '        '(Application.StartupPath & "\vispark\label.txt")
    '    Else
    '        If (Microsoft.VisualBasic.Left(S2存編.Text, 4) = "2511" Or Microsoft.VisualBasic.Left(S2存編.Text, 4) = "2512") And Microsoft.VisualBasic.Mid(S2存編.Text, 12, 2) = "03" Then
    '            olabel.PQty = CInt(1)
    '        Else
    '            olabel.PQty = CInt(T2列印張數.Text)
    '        End If
    '        olabel.Qty = olabel.Qty & Trim(olabel.Unit)
    '        SentToPrinter(olabel)
    '    End If

    'End Sub




    '驅動列印標籤 TSC TTP-243E & TSC TTP-247
    Private Sub SentToPrinter(ByVal olabel As LabeData)
        Dim baseLine As Integer = 0
        'Select Case Bu切換.Text     '指定電腦端的輸出埠
        '    Case "冷藏" : Call openport(條碼機01)
        '    Case "冷凍" : Call openport(條碼機02)
        'End Select
        'If Lt作業.Text = "單據查詢" Then : Call openport(Cb1印表機.Text) : End If
        'If Lt作業.Text = "退貨入庫" Then : Call openport(Cb3印表機.Text) : End If

        'Call openport("TSC TTP-243E") '指定電腦端的輸出埠
        Call setup("60", "42", "7.0", "4", "0", "2", "0")
        '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        'endcommand(“QRCODE 80,80,L,4,A,0,M2,S7,”"this is qrcode”"”)

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

            Call windowsfont(40, 35, 53, 0, 2, 0, "新細明體", Itemname1) '列印文字  x,y,高,旋轉角度,(粗、斜), 底線,字型,內容
            Call windowsfont(40, 84, 53, 0, 2, 0, "新細明體", Itemname2)
            baseLine = 5
        End If

        '2.條碼code128
        Call barcode("56", "140", "128", "58", "1", "0", "3", "3", olabel.Barcode) '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬,條碼內容 以點(point)表示
        '3.重量 
        Call windowsfont(44, 228, 40, 0, 2, 0, "新細明體", olabel.Weight)
        '4.數量
        Call windowsfont(290, 200, 70, 0, 2, 0, "新細明體", olabel.Qty)
        '5.有效日期
        Call windowsfont(45, 270, 25, 0, 2, 0, "新細明體", olabel.MDate)
        '6.製造日期
        Call windowsfont(45, 295, 25, 0, 2, 0, "新細明體", olabel.DDate)
        '定義列印張數
        Call printlabel("1", olabel.PQty)

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub


End Class