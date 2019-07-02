Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 出庫作業V101Bak20160726   '20140917
    Dim DataAdapterDGV, DataDGV5 As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    '內部分類用
    Dim 入庫出貨 As String = ""         '0:.入庫,        1:.出貨
    Dim 作業編號 As String = ""         '0:.排程領料,    1:.單據領料,    2:.銷售出庫
    Dim 作業別號 As String = ""         '0:.排程領料=21, 1:.單據領料=22, 2:.銷售出庫
    Dim 作業查詢 As String = ""         '
    Dim 查詢編號 As String = ""
    Dim 查詢別號 As String = ""

    '回傳SAP資訊
    Dim 出貨別類 As String = ""
    Dim 是否成功 As String = ""
    Dim 回傳單號 As String = ""
    Dim 錯誤資訊 As String = ""

    '比對作業
    Dim Cnt0 As Integer = 0 : Dim Cnt1 As Integer = 0 : Dim Cnt2 As Integer = 0 : Dim Cnt3 As Integer = 0 : Dim Cnt4 As Integer = 0 : Dim Cnt5 As Integer = 0 : Dim Cnt6 As Integer = 0

    '異常作業
    Dim 異常作業 As String = "" : Dim 變更作業 As String = ""

    '暫存資料表名稱
    '單據項目整合                 單據條碼                     檢查條碼狀態                 完整條碼狀態
    Dim Outtmp1 As String = "" : Dim Outtmp2 As String = "" : Dim Outtmp3 As String = "" : Dim Outtmp4 As String = ""

    '記算時間
    Dim dteStart As DateTime

    '列印條碼
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

    Private Sub 出庫作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        T2DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        T1DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        T1DGV4.ContextMenuStrip = MainForm.ContextMenuStrip1

        '初始化
        入庫出貨 = T1入出.Text
        TabContro初始化() : TabContro初始化()
        作業T1.Text = ""
        DGV初始化()
        文字初始化()
        下拉作業T1初始化()
        If UCase(Login.LogonUserName) = "MANAGER" Or UCase(Login.LogonUserName) = "KS09" Then
            參數2.Visible = True
            T1參數1.Visible = True
        End If
    End Sub

    Private Sub TabContro初始化()
        Me.TabControl1.SelectedTab = Me.TabPage4
        Me.TabControl1.SelectedTab = Me.TabPage2
        Me.TabControl1.SelectedTab = Me.TabPage1

        'TabControl1.TabPages.Remove(TabPage2)
        'TabControl1.TabPages.Remove(TabPage3)
        'TabControl1.TabPages.Remove(TabPage4)

    End Sub

    Private Sub DGV初始化()
        'RowHeadersVisible = 移除列首行, AllowUserToResizeRows = 停用列調整, MultiSelect = 停用多列選擇
        'T1DGV
        T1DGV1.RowHeadersVisible = False : T1DGV1.AllowUserToResizeRows = False : T1DGV1.MultiSelect = False
        T1DGV2.RowHeadersVisible = False : T1DGV2.AllowUserToResizeRows = False : T1DGV2.MultiSelect = False

        'T2DGV
        T2DGV1.RowHeadersVisible = False : T2DGV1.AllowUserToResizeRows = False ': T2DGV1.MultiSelect = False
        T2DGV2.RowHeadersVisible = False : T2DGV2.AllowUserToResizeRows = False : T2DGV2.MultiSelect = False
        T2DGV3.RowHeadersVisible = False : T2DGV3.AllowUserToResizeRows = False : T2DGV3.MultiSelect = False

    End Sub

    Private Sub 文字初始化()
        'T1
        草稿T1.Text = ""    '已選作業草稿
        移除作業T1.Text = "" : 移除草稿T1.Text = ""

        'T2 T1傳入T2
        草稿T2.Text = ""    '1,2
        日期T2.Text = ""    '1,2
        代碼T2.Text = ""    '1,2
        製單T2.Text = ""    '1,2
        備註T2.Text = ""    '1,2
        日記T2.Text = ""    '1,2
        '   交貨需求資料
        T2DGV3.Visible = False
        提單T2.Text = ""    '2
        客編T2.Text = ""    '2
        客戶T2.Text = ""    '2
        '   異常說明
        未入T2.Text = ""
        已出T2.Text = ""
        重覆T2.Text = ""
        品項T2.Text = ""
        數量T2.Text = ""
        價格T2.Text = ""

        'T3
        重覆T3.Text = ""
        未入T3.Text = ""
        出庫T3.Text = ""

        '其他
        回傳單號 = ""
        是否成功 = ""
        錯誤資訊 = ""
        異常作業 = ""
        發貨作業T2.Visible = False
        Cnt0 = 0 : Cnt1 = 0 : Cnt2 = 0 : Cnt3 = 0 : Cnt4 = 0 : Cnt5 = 0 : Cnt6 = 0
        驗收數量L2.Visible = False : 驗收數量T2.Visible = False

    End Sub

    Private Sub 下拉作業T1初始化()
        作業選項T1.Items.Clear()
        Select Case 入庫出貨
            Case "出貨"
                '作業選項T1.Items.Add("0.排程領料")  '0
                作業選項T1.Items.Add("1.單據領料")  '1
                作業選項T1.Items.Add("2.銷售出庫")  '2
                作業選項T1.Items.Add("3.存貨領用")  '3
                作業選項T1.Items.Add("4.寄庫出庫")  '5
            Case "入庫"
                作業選項T1.Items.Add("0.採購入庫")  '4
                發貨作業T2.Text = "入庫"
        End Select
    End Sub

    Private Sub 待轉入區T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 待轉入區T1.Click
        'A_PDA上傳轉入.MdiParent = MainForm
        'A_PDA上傳轉入.Show()
        'PDA同步V103.La作業.Text = "出庫"
        Select Case 入庫出貨
            Case "出貨"
                PDA同步V103.La作業.Text = "出庫"
            Case "入庫"
                PDA同步V103.La作業.Text = "單據入庫"
        End Select
        PDA同步V103.MdiParent = MainForm
        PDA同步V103.Show()
        Me.Hide()
    End Sub

    Private Sub 回傳SAP機制()
        Select Case 作業編號    '回傳OIGE(60,)發貨 = [0,1,3], 回傳ODLN(15) 交貨 = [2],[5(寄庫)]
            Case "0", "1", "3"
                同步SAP1()
            Case "2", "5"
                同步SAP2()
            Case "4"
                同步SAP3()
        End Select

    End Sub

    Private Sub 同步SAP1()  '出貨作業別類 = ["領料","領用"]
        Dim RetVal As Long

        '文件開始 表頭
        Dim OIGEAdd As SAPbobsCOM.Documents
        OIGEAdd = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit) 'OIGE = 60   發貨
        OIGEAdd.TaxDate = 日期T2.Text                                   '文件日期
        OIGEAdd.DocDate = 日期T2.Text                                   '過帳日期
        OIGEAdd.Comments = 備註T2.Text & vbCrLf & 說明T2.Text           '備註
        OIGEAdd.JournalMemo = 日記T2.Text                               '日記帳備註
        OIGEAdd.UserFields.Fields.Item("U_CK01").Value = 代碼T2.Text    '發貨目的
        OIGEAdd.UserFields.Fields.Item("U_CK02").Value = 製單T2.Text    '製造單號
        'OIGEAdd.UserFields.Fields.Item("U_Cnum").Value = ""             '契養批號-??
        'OIGEAdd.UserFields.Fields.Item("U_Gnum").Value = ""             '抓雞通知單號-??
        'OIGEAdd.UserFields.Fields.Item("U_TpMoney").Value = ""          '運費-??

        '文件開始 表身
        For j As Integer = 0 To T2DGV1.RowCount - 1
            OIGEAdd.Lines.SetCurrentLine(j)
            OIGEAdd.Lines.ItemCode = Trim(T2DGV1.Rows(j).Cells("存編").Value)   '存編
            OIGEAdd.Lines.Quantity = T2DGV1.Rows(j).Cells("出庫數量").Value     '數量出庫 預出數量
            OIGEAdd.Lines.UserFields.Fields.Item("U_p2").Value = T2DGV1.Rows(j).Cells("出庫重量").Value '重量
            If 預設庫位YN.Checked = True Then
                OIGEAdd.Lines.WarehouseCode = TB預設庫位.Text
            End If


            'OIGEAdd.Lines.UserFields.Fields.Item("U_P4").Value = "" '單位2數量-??
            'OIGEAdd.Lines.UserFields.Fields.Item("U_P5").Value = "" '單位1KG-??
            'OIGEAdd.Lines.UserFields.Fields.Item("U_P6").Value = "" '小單位-??

            '文件開始 明細 S=序號, B=批次, F=無
            Dim Cnt0 As Integer = 0
            For i As Integer = 0 To T2DGV2.RowCount - 1
                If (Trim(T2DGV2.Rows(i).Cells("存編").Value) = Trim(T2DGV1.Rows(j).Cells("存編").Value)) Then
                    Select Case T2DGV2.Rows(i).Cells("管理").Value
                        Case "S"
                            OIGEAdd.Lines.SerialNumbers.SetCurrentLine(Cnt0)
                            OIGEAdd.Lines.SerialNumbers.InternalSerialNumber = T2DGV2.Rows(i).Cells("條碼").Value '條碼
                            OIGEAdd.Lines.SerialNumbers.Add()
                        Case "B"
                            OIGEAdd.Lines.BatchNumbers.SetCurrentLine(Cnt0)
                            OIGEAdd.Lines.BatchNumbers.BatchNumber = T2DGV2.Rows(i).Cells("條碼").Value '條碼
                            OIGEAdd.Lines.BatchNumbers.Quantity = T2DGV2.Rows(i).Cells("數量").FormattedValue  '數量
                            OIGEAdd.Lines.BatchNumbers.Add()
                        Case "F"
                    End Select
                    Cnt0 += 0 + 1
                End If
            Next

            OIGEAdd.Lines.Add()
        Next
        RetVal = OIGEAdd.Add

        '文件結束 作業確認
        Select Case RetVal
            Case 0
                是否成功 = "Y"
                回傳單號 = Login.oCompany.GetNewObjectKey()
                '移除草稿單號
                Select Case 作業編號
                    Case "1"    '1.單據領料
                        Dim odraft As SAPbobsCOM.Documents
                        odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                        odraft.GetByKey(草稿T2.Text)
                        odraft.Remove()
                End Select

            Case Else
                是否成功 = "N"
                錯誤資訊 = Login.oCompany.GetLastErrorCode() & vbCrLf & "                    " & Login.oCompany.GetLastErrorDescription()
        End Select

    End Sub

    Private Sub 同步SAP2()  '出貨作業別類 = ["銷售"]
        Dim RetVal As Long

        '文件開始
        Dim oDelv As SAPbobsCOM.Documents
        oDelv = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDeliveryNotes)   'ODLN = 15   交貨

        oDelv.CardCode = Trim(客編T2.Text)
        oDelv.DocDueDate = 日期T2.Text
        oDelv.DocDate = 日期T2.Text                               '過帳日期
        If IsDBNull(T1DGV1.CurrentRow.Cells("提單").Value) Then : Else : oDelv.UserFields.Fields.Item("U_Dnum").Value = 提單T2.Text : End If
        oDelv.Comments = 備註T2.Text & vbCrLf & 說明T2.Text           '備註

        If IsDBNull(T1DGV1.CurrentRow.Cells("附件").Value) Then : Else : oDelv.UserFields.Fields.Item("U_attachment").Value = T1DGV1.CurrentRow.Cells("附件").Value : End If
        oDelv.UserFields.Fields.Item("U_CK01").Value = 代碼T2.Text    '發貨目的
        If IsDBNull(T1DGV1.CurrentRow.Cells("契養批號").Value) Then : Else : oDelv.UserFields.Fields.Item("U_Cnum").Value = T1DGV1.CurrentRow.Cells("契養批號").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("前期空籃").Value) Then : Else : oDelv.UserFields.Fields.Item("U_N1").Value = T1DGV1.CurrentRow.Cells("前期空籃").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("本期空籃").Value) Then : Else : oDelv.UserFields.Fields.Item("U_N2").Value = T1DGV1.CurrentRow.Cells("本期空籃").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("本期收回").Value) Then : Else : oDelv.UserFields.Fields.Item("U_N3").Value = T1DGV1.CurrentRow.Cells("本期收回").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("司機1").Value) Then : Else : oDelv.UserFields.Fields.Item("U_CarDr1").Value = T1DGV1.CurrentRow.Cells("司機1").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("司機2").Value) Then : Else : oDelv.UserFields.Fields.Item("U_CarDr2").Value = T1DGV1.CurrentRow.Cells("司機2").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("司機3").Value) Then : Else : oDelv.UserFields.Fields.Item("U_CarDr3").Value = T1DGV1.CurrentRow.Cells("司機3").Value : End If
        If IsDBNull(T1DGV1.CurrentRow.Cells("好市多訂單編號").Value) Then : Else : oDelv.UserFields.Fields.Item("U_COSCO").Value = T1DGV1.CurrentRow.Cells("好市多訂單編號").Value : End If
        oDelv.UserFields.Fields.Item("U_Dlst").Value = T1DGV1.CurrentRow.Cells("出貨單回簽否").Value
        oDelv.UserFields.Fields.Item("U_updnum").Value = T1DGV1.CurrentRow.Cells("更新空籃數").Value
        If IsDBNull(T1DGV1.CurrentRow.Cells("運費").Value) Then : Else : oDelv.UserFields.Fields.Item("U_TpMoney").Value = T1DGV1.CurrentRow.Cells("運費").Value : End If

        '文件開始 表身
        For j As Integer = 0 To T2DGV1.RowCount - 1
            oDelv.Lines.SetCurrentLine(j)
            oDelv.Lines.ItemCode = T2DGV1.Rows(j).Cells("存編").Value
            oDelv.Lines.Quantity = T2DGV1.Rows(j).Cells("出庫數量").Value
            oDelv.Lines.BaseType = T2DGV1.Rows(j).Cells("BaseType").Value   '17

            If IsDBNull(T2DGV1.Rows(j).Cells("BaseEntry").Value) Then : Else : oDelv.Lines.BaseEntry = T2DGV1.Rows(j).Cells("BaseEntry").Value : End If
            If IsDBNull(T2DGV1.Rows(j).Cells("BaseLine").Value) Then : Else : oDelv.Lines.BaseLine = T2DGV1.Rows(j).Cells("BaseLine").Value : End If
            If IsDBNull(T2DGV1.Rows(j).Cells("員工").Value) Then : Else : oDelv.Lines.UserFields.Fields.Item("U_P1").Value = T2DGV1.Rows(j).Cells("員工").Value : End If
            If IsDBNull(T2DGV1.Rows(j).Cells("入雛日").Value) Then : Else : oDelv.Lines.UserFields.Fields.Item("U_Cdate").Value = T2DGV1.Rows(j).Cells("入雛日").Value : End If
            If IsDBNull(T2DGV1.Rows(j).Cells("出庫重量").Value) Then : Else : oDelv.Lines.UserFields.Fields.Item("U_p2").Value = T2DGV1.Rows(j).Cells("出庫重量").Value : End If

            'oDelv.Lines.WarehouseCode = ""
            oDelv.Lines.UserFields.Fields.Item("U_P3").Value = T2DGV1.Rows(j).Cells("生產否").Value
            oDelv.Lines.UserFields.Fields.Item("U_P4").Value = T2DGV1.Rows(j).Cells("單位2數量").FormattedValue
            oDelv.Lines.UserFields.Fields.Item("U_P5").Value = T2DGV1.Rows(j).Cells("單位1KG").Value
            oDelv.Lines.UserFields.Fields.Item("U_P6").Value = T2DGV1.Rows(j).Cells("小單位").Value
            oDelv.Lines.UserFields.Fields.Item("U_P7").Value = T2DGV1.Rows(j).Cells("計價單位").Value
            oDelv.Lines.UserFields.Fields.Item("U_P8").Value = T2DGV1.Rows(j).Cells("銷售金額").FormattedValue
            oDelv.Lines.UserFields.Fields.Item("U_Omoney").Value = T2DGV1.Rows(j).Cells("付款方法").Value

            '文件開始 明細 S=序號, B=批次, F=無
            Dim Cnt0 As Integer = 0
            For i As Integer = 0 To T2DGV2.RowCount - 1
                If (Trim(T2DGV2.Rows(i).Cells("存編").Value) = Trim(T2DGV1.Rows(j).Cells("存編").Value)) And _
                   (Trim(T2DGV2.Rows(i).Cells("銷售").Value) = Trim(T2DGV1.Rows(j).Cells("銷售").Value)) Then
                    Select Case T2DGV2.Rows(i).Cells("管理").Value
                        Case "S"
                            oDelv.Lines.SerialNumbers.SetCurrentLine(Cnt0)
                            oDelv.Lines.SerialNumbers.InternalSerialNumber = T2DGV2.Rows(i).Cells("條碼").Value '條碼
                            oDelv.Lines.SerialNumbers.Add()
                        Case "B"
                            oDelv.Lines.BatchNumbers.SetCurrentLine(Cnt0)
                            oDelv.Lines.BatchNumbers.BatchNumber = T2DGV2.Rows(i).Cells("條碼").Value '條碼
                            oDelv.Lines.BatchNumbers.Quantity = T2DGV2.Rows(i).Cells("數量").FormattedValue  '數量
                            oDelv.Lines.BatchNumbers.Add()
                        Case "F"
                    End Select
                    Cnt0 += 0 + 1
                End If
            Next

            'If IsDBNull(T2DGV1.Rows(j).Cells("實際金額").Value) Then : Else : oDelv.Lines.UnitPrice = T2DGV1.Rows(j).Cells("實際金額").Value : End If
            oDelv.Lines.UnitPrice = T2DGV1.Rows(j).Cells("實際金額").Value
            'oDelv.Lines.
            'oDelv.Lines.LineTotal = T2DGV1.Rows(j).Cells("實際金額").Value
            oDelv.Lines.Add()
        Next
        RetVal = oDelv.Add

        '文件結束 作業確認
        Select Case RetVal
            Case 0
                是否成功 = "Y"
                回傳單號 = Login.oCompany.GetNewObjectKey()
                '移除草稿單號
                Dim odraft As SAPbobsCOM.Documents
                odraft = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts)
                odraft.GetByKey(草稿T2.Text)
                odraft.Remove()
            Case Else
                是否成功 = "N"
                錯誤資訊 = Login.oCompany.GetLastErrorCode() & vbCrLf & "                    " & Login.oCompany.GetLastErrorDescription()
        End Select

    End Sub

    Private Sub 同步SAP3()  '入庫作業別類 = ["採購"]

    End Sub

    Private Sub 查詢單據_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢單據T1.Click
        If 作業選項T1.SelectedIndex = -1 Then : Exit Sub : End If
        草稿T1.Text = ""    '已選作業草稿
        Select Case 作業選項T1.Text
            Case "0.排程領料" : 作業T1.Text = "排程領料" : 作業編號 = "0" : 出貨別類 = "發貨" : 作業別號 = " =   '25' "       '領料  23,24
            Case "1.單據領料" : 作業T1.Text = "單據領料" : 作業編號 = "1" : 出貨別類 = "發貨" : 作業別號 = " IN ('21','22') " '領料
            Case "2.銷售出庫" : 作業T1.Text = "銷售出庫" : 作業編號 = "2" : 出貨別類 = "交貨" : 作業別號 = " IN ('31','32') " '銷售
            Case "3.存貨領用" : 作業T1.Text = "存貨領用" : 作業編號 = "3" : 出貨別類 = "發貨" : 作業別號 = " IN ('41','42') " '領用
            Case "0.採購入庫" : 作業T1.Text = "採購入庫" : 作業編號 = "4" : 出貨別類 = "入庫" ': 作業別號 = " IN ('41','42')" '採購入庫
            Case "4.寄庫出庫" : 作業T1.Text = "寄庫出庫" : 作業編號 = "5" : 出貨別類 = "交貨" : 作業別號 = " =   '51' "       '寄庫出庫

        End Select

        查詢單據()

    End Sub

    Private Sub 查詢單據()
        If T1DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV1").Clear() : End If '清除DGV1資料
        Dim SQLADD As String = ""

        Select Case 作業編號
            Case "0"    '0.排程領料
            Case "1"    '1.單據領料
                SQLADD = "     SELECT '' AS '選擇', T0.[DocEntry] AS '草稿', CONVERT(varchar(10), T0.[DocDueDate], 120) AS '日期', T0.[U_CK01] '代碼', ISNULL(T0.[U_CK02],'') AS '製單', ISNULL(T0.[Comments],'') AS '備註', T0.[JrnlMemo] '日記', '' AS '提單' "
                SQLADD += "      FROM [ODRF] T0 "
                SQLADD += "     WHERE T0.[ObjType] = '60' AND T0.[U_CK01] = '5' AND T0.[DocStatus] = 'O' ORDER BY T0.[DocEntry] DESC "
            Case "2"    '2.銷售出庫
                SQLADD = "    SELECT DISTINCT T0.[DocEntry] AS '草稿', CONVERT(varchar(10), T0.[DocDueDate], 120) AS '日期', T0.[U_CK01] '代碼', ISNULL(T0.[U_CK02],'') AS '製單', T0.[Comments] AS '備註', T0.[JrnlMemo] '日記', "
                SQLADD += "          T0.[U_Dnum] AS '提單', T0.[CardCode] AS '客編', T0.[CardName] AS '客戶', T0.[U_Dlst] AS '出貨單回簽否', T0.[U_Cnum] AS '契養批號', T0.[U_TpMoney] AS '運費', "
                SQLADD += "          T0.[U_CarDr1] AS '司機1', T0.[U_CarDr2] AS '司機2', T0.[U_CarDr2] AS '司機3', T0.[U_attachment] AS '附件', T0.[U_updnum] AS '更新空籃數', T0.[U_N1] AS '前期空籃', T0.[U_N2] AS '本期空籃', T0.[U_N3] AS '本期收回', "
                SQLADD += "          T0.[U_COSCO] AS '好市多訂單編號' "
                SQLADD += "     FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                SQLADD += "    WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O' "
                SQLADD += " ORDER BY T0.[U_Dnum] DESC "
            Case "3"    '3.存貨領用
                SQLADD = "    SELECT DISTINCT K.[ID] AS '草稿', CONVERT(varchar(10),KD.[GetProDate],120) AS '日期', UF.[IndexID] AS '代碼', '' AS '提單', "
                SQLADD += "          CASE [DepartType] WHEN '0' THEN '營業'     WHEN '1' THEN '生管' WHEN '2' THEN '人事' WHEN '3' THEN '倉庫' WHEN '4'  THEN '會計' WHEN '5'  THEN '採購' "
                SQLADD += "                            WHEN '6' THEN '總經理室' WHEN '7' THEN '研發' WHEN '8' THEN '設計' WHEN '9' THEN '品管' WHEN '10' THEN '加工' WHEN '11' THEN '資訊' END AS '部門' , "
                SQLADD += "          UF.[Descr] AS '出庫', K.MEMO AS '備註' "
                SQLADD += "     FROM [KS_Z_StockApply] K LEFT JOIN [KS_Z_StockApply_Detail] KD ON K.[ID]      = KD.[ID] "
                SQLADD += "                              LEFT JOIN [UFD1]                   UF ON K.[IndexID] = UF.[IndexID] AND UF.[FieldID] = '53' AND UF.[TableID]='OIGE' "
                SQLADD += "    WHERE K.[Examine] = '1' ORDER BY CONVERT(varchar(10),KD.[GetProDate],120) DESC, K.[ID] "
            Case "4"    '0.採購入庫
                SQLADD = "     SELECT DISTINCT T0.[DocEntry] AS '草稿', CONVERT(varchar(10), T0.[DocDueDate], 120) AS '日期', T0.[U_CK01] '代碼', T0.[Comments] AS '備註', T0.[JrnlMemo] '日記', "
                SQLADD += "          T0.[U_Dnum] AS '提單', T0.[CardCode] AS '客編', T0.[CardName] AS '客戶' "
                'SQLADD += "        , T0.[U_Dlst] AS '出貨單回簽否', T0.[U_Cnum] AS '契養批號', T0.[U_TpMoney] AS '運費', , ISNULL(T0.[U_CK02],'') AS '製單'"
                'SQLADD += "          T0.[U_CarDr1] AS '司機1', T0.[U_CarDr2] AS '司機2', T0.[U_CarDr2] AS '司機3', T0.[U_attachment] AS '附件', T0.[U_updnum] AS '更新空籃數', T0.[U_N1] AS '前期空籃', T0.[U_N2] AS '本期空籃', T0.[U_N3] AS '本期收回', "
                'SQLADD += "          T0.[U_COSCO] AS '好市多訂單編號' "
                SQLADD += "     FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                SQLADD += "    WHERE T0.[ObjType] = '20' AND T0.[DocStatus] = 'O' AND T0.[U_CK06] = '16' AND T0.[CardName] Like '%鮮享%' "
                SQLADD += " ORDER BY T0.[U_Dnum] DESC "
                'T0.ObjType='20' AND T0.DocStatus = 'O' AND T0.U_CK06 = '16'  AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O'
            Case "5"    '4.寄庫出庫
                'SQLADD = "    SELECT DISTINCT T0.[DocEntry], T0.[DocNum], T0.[CardCode], T0.[CardName], T0.[DocDate], T0.[TaxDate], T0.[DocDueDate], T0.[U_attachment], T0.[U_CK01], T0.[U_Cnum], T0.[U_N1], T0.[U_N2], T0.[U_N3], T0.[U_CarDr1], T0.[U_CarDr2], T0.[U_CarDr3], T0.[U_Dlst], T0.[U_updnum], T0.[U_TpMoney], T0.[Comments], T0.[U_Dnum] "
                SQLADD = "    SELECT DISTINCT T0.[DocEntry] AS '草稿', CONVERT(varchar(10), T0.[DocDueDate], 120) AS '日期', T0.[U_CK01] '代碼', ISNULL(T0.[U_CK02],'') AS '製單', T0.[Comments] AS '備註', T0.[JrnlMemo] '日記', "
                SQLADD += "          T0.[U_Dnum] AS '提單', T0.[CardCode] AS '客編', T0.[CardName] AS '客戶', T0.[U_Dlst] AS '出貨單回簽否', T0.[U_Cnum] AS '契養批號', T0.[U_TpMoney] AS '運費', "
                SQLADD += "          T0.[U_CarDr1] AS '司機1', T0.[U_CarDr2] AS '司機2', T0.[U_CarDr2] AS '司機3', T0.[U_attachment] AS '附件', T0.[U_updnum] AS '更新空籃數', T0.[U_N1] AS '前期空籃', T0.[U_N2] AS '本期空籃', T0.[U_N3] AS '本期收回', "
                SQLADD += "          T0.[U_COSCO] AS '好市多訂單編號' "
                SQLADD += "     FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                'sql += "      WHERE T0.[ObjType] = '15' AND (T1.[WhsCode] = 'O01' OR T1.[WhsCode] = 'K05' OR T1.[WhsCode] = 'S05')      AND T0.[DocStatus] = 'O' "
                SQLADD += "    WHERE T0.[ObjType] = '15' AND T1.[WhsCode] IN ('O01','K05','S05') AND T0.[DocStatus] = 'O' "
                SQLADD += " ORDER BY T0.[U_Dnum] DESC "
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV1")
            T1DGV1.DataSource = ks1DataSetDGV.Tables("T1DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        查詢單據_Play()

    End Sub

    Private Sub 查詢單據_Play()
        '--載入資料畫面

        For Each column As DataGridViewColumn In T1DGV1.Columns
            column.Visible = True
            Select Case 作業編號
                Case "0"    '0.排程領料
                Case "1"    '1.單據領料
                    Select Case column.Name
                        Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "提單" : column.HeaderText = "提單" : column.DisplayIndex = 2 : column.Frozen = False : column.Visible = False
                        Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 3
                        Case Else
                            column.Visible = False
                    End Select
                Case "2", "5"    '2.銷售出庫, 4.寄庫出庫
                    Select Case column.Name
                        Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "提單" : column.HeaderText = "提單" : column.DisplayIndex = 2 : column.Frozen = True
                        Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 3
                        Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 4
                        Case Else
                            column.Visible = False
                    End Select
                Case "3"    '3.存貨領用
                    Select Case column.Name
                        Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "提單" : column.HeaderText = "提單" : column.DisplayIndex = 2 : column.Frozen = False : column.Visible = False
                        Case "部門" : column.HeaderText = "部門" : column.DisplayIndex = 3
                        Case "出庫" : column.HeaderText = "出庫" : column.DisplayIndex = 4
                        Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 5
                        Case Else
                            column.Visible = False
                    End Select
                Case "4"    '0.採購入庫
                    Select Case column.Name
                        Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "提單" : column.HeaderText = "提單" : column.DisplayIndex = 2 : column.Frozen = True
                        Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 3
                        Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 4
                        Case Else
                            column.Visible = False
                    End Select
                    'Case "5"    '4.寄庫出庫
                    '    Select Case column.Name
                    '        Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 0 : column.Frozen = True
                    '        Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Frozen = True
                    '        Case "提單" : column.HeaderText = "提單" : column.DisplayIndex = 2 : column.Frozen = True
                    '        Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 3
                    '        Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 4
                    '        Case Else
                    '            column.Visible = False
                    '    End Select

                Case Else
                    column.Visible = False
            End Select
        Next

        T1DGV1.AutoResizeColumns()

    End Sub

    Private Sub 草稿比對T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 草稿比對T1.Click
        If 草稿T1.Text = "" Then : Exit Sub : End If
        If T1CB鎖定.Checked = True And T1TB鎖定庫位.Text = "" Then
            Exit Sub
        End If
        預設庫位YN.Checked = False

        Select Case 作業編號
            Case "0"    '0.排程領料
            Case "1"    '1.單據領料
                草稿T2.Text = T1DGV1.CurrentRow.Cells("草稿").Value
                日期T2.Text = T1DGV1.CurrentRow.Cells("日期").Value
                代碼T2.Text = T1DGV1.CurrentRow.Cells("代碼").Value
                製單T2.Text = T1DGV1.CurrentRow.Cells("製單").Value
                備註T2.Text = T1DGV1.CurrentRow.Cells("備註").Value
                日記T2.Text = T1DGV1.CurrentRow.Cells("日記").Value

            Case "2", "5"    '2.銷售出庫, 4.寄庫出庫
                If IsDBNull(T1DGV1.CurrentRow.Cells("提單").Value) = True Then : MsgBox("草稿：" & 草稿T1.Text & "  無提單號碼，無法作業", 16, "錯誤") : Exit Sub : End If
                草稿T2.Text = T1DGV1.CurrentRow.Cells("草稿").Value
                日期T2.Text = T1DGV1.CurrentRow.Cells("日期").Value
                代碼T2.Text = T1DGV1.CurrentRow.Cells("代碼").Value
                製單T2.Text = T1DGV1.CurrentRow.Cells("製單").Value
                備註T2.Text = T1DGV1.CurrentRow.Cells("備註").Value
                日記T2.Text = T1DGV1.CurrentRow.Cells("日記").Value

                提單T2.Text = T1DGV1.CurrentRow.Cells("提單").Value
                客編T2.Text = T1DGV1.CurrentRow.Cells("客編").Value
                客戶T2.Text = T1DGV1.CurrentRow.Cells("客戶").Value

            Case "3"    '3.存貨領用  
                草稿T2.Text = T1DGV1.CurrentRow.Cells("草稿").Value
                日期T2.Text = T1DGV1.CurrentRow.Cells("日期").Value
                代碼T2.Text = T1DGV1.CurrentRow.Cells("代碼").Value
                備註T2.Text = T1DGV1.CurrentRow.Cells("備註").Value
                日記T2.Text = "發貨"

            Case "4"    '0.採購入庫
                草稿T2.Text = T1DGV1.CurrentRow.Cells("草稿").Value
                日期T2.Text = T1DGV1.CurrentRow.Cells("日期").Value
                代碼T2.Text = T1DGV1.CurrentRow.Cells("代碼").Value
                製單T2.Text = T1DGV1.CurrentRow.Cells("製單").Value
                備註T2.Text = T1DGV1.CurrentRow.Cells("備註").Value
                日記T2.Text = T1DGV1.CurrentRow.Cells("日記").Value

                提單T2.Text = T1DGV1.CurrentRow.Cells("提單").Value
                客編T2.Text = T1DGV1.CurrentRow.Cells("客編").Value
                客戶T2.Text = T1DGV1.CurrentRow.Cells("客戶").Value
                'Case "5"    '4.寄庫出庫
                '    If IsDBNull(T1DGV1.CurrentRow.Cells("提單").Value) = True Then : MsgBox("草稿：" & 草稿T1.Text & "  無提單號碼，無法作業", 16, "錯誤") : Exit Sub : End If
                '    草稿T2.Text = T1DGV1.CurrentRow.Cells("草稿").Value
                '    日期T2.Text = T1DGV1.CurrentRow.Cells("日期").Value
                '    代碼T2.Text = T1DGV1.CurrentRow.Cells("代碼").Value
                '    製單T2.Text = T1DGV1.CurrentRow.Cells("製單").Value
                '    備註T2.Text = T1DGV1.CurrentRow.Cells("備註").Value
                '    日記T2.Text = T1DGV1.CurrentRow.Cells("日記").Value

                '    提單T2.Text = T1DGV1.CurrentRow.Cells("提單").Value
                '    客編T2.Text = T1DGV1.CurrentRow.Cells("客編").Value
                '    客戶T2.Text = T1DGV1.CurrentRow.Cells("客戶").Value


        End Select
        dteStart = Now  ''...要計算執行時間的程式區段 ...
        作業查詢 = "草稿比對"
        T2查詢作業()

        'TabControl1.TabPages.Add(TabPage2)
        Me.TabControl1.SelectedTab = Me.TabPage2
        'TabControl1.TabPages.Remove(TabPage1)

        T2DGV1異常檢查()
        T2DGV2異常檢查()

        Dim 執行時間s As String = "0.00"
        Dim 執行時間a As TimeSpan = Now.Subtract(dteStart)
        執行時間s = "查詢時間 " & Format(執行時間a.TotalSeconds, "###0.00" & " 秒")
        T2執行時間.Text = 執行時間s

        'If Cnt0 = 0 And Cnt1 = 0 And Cnt2 = 0 And Cnt3 = 0 And Cnt4 = 0 And Cnt5 = 0 Then
        '    '查看異常T2.Visible = False
        '    '發貨作業T2.Visible = True
        '    If Login.LoginType = 2 Then : 發貨作業T2.Enabled = False : Else : 發貨作業T2.Enabled = True : End If '未SAP權限登入無法執行入庫
        'Else
        '    'If UCase(GetHostName()) = "KS-I11" Or UCase(GetHostName()) = "MIS-03" Or UCase(GetHostName()) = "MIS-06" Or UCase(GetHostName()) = "KS-NB-T1" Then
        '    '    查看異常T2.Visible = True
        '    'Else
        '    '    查看異常T2.Visible = False
        '    'End If
        '    發貨作業T2.Visible = False
        'End If

        'If Cnt6 <> 0 Then : 驗收數量L2.Visible = True : 驗收數量T2.Visible = True : End If

        T2發貨作業()
        If UCase(Login.LogonUserName) <> "MANAGER" Then
            T2查詢明細_Play()
        End If


        For i As Integer = 0 To T2DGV1.ColumnCount - 1
            T2DGV1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        T2DGV1.AutoResizeColumns() : T2DGV2.AutoResizeColumns() : T2DGV3.AutoResizeColumns()
        作業查詢 = ""

    End Sub

    Private Sub T2發貨作業()
        If Cnt0 = 0 And Cnt1 = 0 And Cnt2 = 0 And Cnt3 = 0 And Cnt4 = 0 And Cnt5 = 0 Then
            '查看異常T2.Visible = False
            發貨作業T2.Visible = True
            If Login.LoginType = 2 Then : 發貨作業T2.Enabled = False : Else : 發貨作業T2.Enabled = True : End If '未SAP權限登入無法執行入庫
        Else
            'If UCase(GetHostName()) = "KS-I11" Or UCase(GetHostName()) = "MIS-03" Or UCase(GetHostName()) = "MIS-06" Or UCase(GetHostName()) = "KS-NB-T1" Then
            '    查看異常T2.Visible = True
            'Else
            '    查看異常T2.Visible = False
            'End If
            發貨作業T2.Visible = False
        End If
    End Sub

    Private Sub T2查詢作業()
        T2查詢單據暫存作業()    '暫存相關資料
        T2查詢單據條碼()        '條碼資料
        T2查詢單據明細()        '單據整合   單據整合條碼

        'For i As Integer = 0 To T2DGV1.ColumnCount - 1
        '    T2DGV1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        'Next

        Select Case 作業編號
            Case "0"    '0.排程領料
            Case "1", "2", "3", "4", "5"   '1.單據領料, 2.銷售出庫, 0.採購入庫, 4.寄庫出庫
                T2查詢單據非單據品項()
                If Format(T2DGV3.RowCount, "") > 0 Then
                    T2DGV3.Visible = True
                End If
                'Case "3"    '3.存貨領用
        End Select

    End Sub

    Private Sub T2DGV1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles T2DGV1.Sorted
        T2DGV1異常檢查()
    End Sub

    Private Sub T2DGV1異常檢查()
        Cnt0 = 0 : Cnt4 = 0 : Cnt5 = 0 : Cnt6 = 0
        For i As Integer = 0 To T2DGV1.RowCount - 1   '以黃底顯示
            If T2DGV1.Rows(i).Cells("預出數量").Value <> T2DGV1.Rows(i).Cells("出庫數量").Value Then
                T2DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Cnt0 += 0 + 1
            End If : Next

        Select Case 作業編號
            Case "2", "5"    '2.銷售出庫, 4.寄庫出庫
                For i As Integer = 0 To T2DGV1.RowCount - 1   '未Key銷售金額
                    If IsDBNull(T2DGV1.Rows(i).Cells("銷售金額").Value) = True Then
                        Cnt5 += 0 + 1
                    End If : Next
        End Select

        Select Case 作業編號
            Case "2", "5"    '2.銷售出庫, 4.寄庫出庫
                For i As Integer = 0 To T2DGV1.RowCount - 1   '未Key銷售金額
                    If T2DGV1.Rows(i).Cells("銷售金額").Value = 0 Then
                        'Cnt5 += 0 + 1
                        T2DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Violet
                    End If : Next
        End Select

        'For i As Integer = 0 To T2DGV1.RowCount - 1   '庫存管理 = F
        '    If T2DGV1.Rows(i).Cells("管理").Value = "F" Then
        '        Cnt6 += 0 + 1
        '    End If : Next

        T2DGV1.ClearSelection()

        數量T2.Text = Cnt0 & " 筆品項未達出庫數量"
        價格T2.Text = Cnt5 & " 筆項目價格未輸入"
        '管理T2.Text = Cnt6 & " 筆需輸入驗收數量"

        Select Case 作業編號
            Case "0"     '0.排程領料
                品項T2.Text = "0 筆非單據品項"
            Case "1", "2", "5"   '1.單據領料, 2.銷售出庫, 4.寄庫出庫
                Cnt4 = T2DGV3.RowCount
                品項T2.Text = Cnt4 & " 筆非單據品項"
            Case "3"    '3.存貨領用
                品項T2.Text = "0 筆非單據品項"
        End Select

    End Sub

    Private Sub T2DGV2_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles T2DGV2.Sorted
        T2DGV2異常檢查()
    End Sub

    Private Sub T2DGV2異常檢查()

        Cnt1 = 0 : Cnt2 = 0 : Cnt3 = 0

        For i As Integer = 0 To T2DGV2.RowCount - 1   '以黃底顯示
            If T2DGV2.Rows(i).Cells("重覆").Value = "是" Then
                T2DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Cnt1 += 0 + 1
            End If : Next

        For i As Integer = 0 To T2DGV2.RowCount - 1   '以紅底顯示
            If T2DGV2.Rows(i).Cells("狀態").Value = "未入庫" Then
                T2DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                Cnt2 += 0 + 1
            End If : Next

        For i As Integer = 0 To T2DGV2.RowCount - 1   '以Blue底顯示
            If T2DGV2.Rows(i).Cells("狀態").Value = "出庫" Then
                T2DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Blue
                Cnt3 += 0 + 1
            End If : Next

        T2DGV2.ClearSelection()

        重覆T2.Text = Cnt1 & " 筆"
        未入T2.Text = Cnt2 & " 筆"
        已出T2.Text = Cnt3 & " 筆"

    End Sub

    Private Sub T2查詢單據暫存作業()
        Dim SQLQuery As String = ""
        Outtmp2 = Format(Replace(Replace("#SyncOuttmp2" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")
        Outtmp3 = Format(Replace(Replace("#SyncOuttmp3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")
        Select Case 入庫出貨
            Case "出貨"
                '列出草稿條碼
                SQLQuery = "  IF (OBJECT_ID('tempdb.." & Outtmp2 & "') IS NOT NULL)  DROP TABLE " & Outtmp2 & " "
                SQLQuery += " SELECT [OUTID] AS 'ID', UPPER([OUT02]) AS 'DistNumber', [OUT03] AS 'Quantity', [OUT05] AS 'Gift' INTO " & Outtmp2 & " "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] "
                'SQLQuery += "  WHERE [OUT04] = '" & 草稿T2.Text & "' AND [OUT06] = '3' AND SUBSTRING([OUT01],1,2) " & 作業別號 & " "
                Select Case 作業查詢
                    Case "條碼明細" : SQLQuery += "  WHERE [OUT04] = '" & 移除草稿T1.Text & "' AND [OUT06] = '3' AND SUBSTRING([OUT01],1,2) " & 查詢別號 & " "
                    Case "草稿比對" : SQLQuery += "  WHERE [OUT04] = '" & 草稿T2.Text & "'     AND [OUT06] = '3' AND SUBSTRING([OUT01],1,2) " & 作業別號 & " "
                End Select

                '列出條碼資訊
                SQLQuery += "  IF (OBJECT_ID('tempdb.." & Outtmp3 & "') IS NOT NULL)  DROP TABLE " & Outtmp3 & " "
                SQLQuery += " SELECT * INTO " & Outtmp3 & " FROM ( "
                SQLQuery += "       SELECT 'S' AS '管理', T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], ISNULL(T2.[Quantity],9999) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate], T2.[WhsCode] "
                SQLQuery += "         FROM [OSRN] T1 INNER JOIN [OSRQ]          T2 ON T1.[ItemCode]   = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLQuery += "                        INNER JOIN [OITM]          T3 ON T1.[ItemCode]   = T3.[ItemCode] "
                SQLQuery += "                        INNER JOIN " & Outtmp2 & " T4 ON T1.[DistNumber] = T4.[DistNumber] "
                SQLQuery += " UNION ALL"
                SQLQuery += "       SELECT 'B' AS '管理', T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], ISNULL(T2.[Quantity],9999) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate], T2.[WhsCode] "
                SQLQuery += "         FROM [OBTN] T1 INNER JOIN [OBTQ]          T2 ON T1.[ItemCode]   = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLQuery += "                        INNER JOIN [OITM]          T3 ON T1.[ItemCode]   = T3.[ItemCode] "
                SQLQuery += "                        INNER JOIN " & Outtmp2 & " T4 ON T1.[DistNumber] = T4.[DistNumber] ) T0 "

            Case "入庫"
                '列出草稿條碼
                SQLQuery = "  IF (OBJECT_ID('tempdb.." & Outtmp2 & "') IS NOT NULL)  DROP TABLE " & Outtmp2 & " "
                SQLQuery += " SELECT [INID] AS 'ID', [IN02] AS 'DistNumber', [IN04] AS 'U_M2', '1' AS 'Quantity', '1' AS 'Gift' INTO " & Outtmp2 & " "
                SQLQuery += "   FROM [KaiShingPlug].[dbo].[PDA_InData_SAP] WHERE LEFT([IN01],2) = '13' AND [IN04] = '3' "

                '列出條碼資訊
                SQLQuery += "  IF (OBJECT_ID('tempdb.." & Outtmp3 & "') IS NOT NULL)  DROP TABLE " & Outtmp3 & " "
                SQLQuery += " SELECT * INTO " & Outtmp3 & " FROM ( "
                SQLQuery += "       SELECT 'S' AS '管理', T0.[FI107K] AS 'ItemCode', T0.[FI108] AS 'ItemName', T0.[U_M2], '1' AS 'Quantity', T0.[FI118] AS 'U_M1', '' AS 'U_M8', T0.[FI110] AS 'MnfDate' "
                SQLQuery += "         FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] T0 INNER JOIN " & Outtmp2 & " T4 ON T0.[DistNumber] = T4.[DistNumber] ) T0 "

                ' Select Case [Sid]
                ',[FI100],[FI101],[FI102],[FI103],[FI104],[FI105],[FI106],[FI107],[FI107K],[FI108],[FI109],[FI110],[FI111],[FI112],[FI113],[FI114],[FI115]
                ',[FI116],[FI117],[FI118],[FI119],[FI120],[FI121],[FI122],[FI123],[FI124],[FI125],[FI126],[FI127],[FI128],[FI129],[FI130]
                ',[FI131],[FI132]
                '  FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode]

        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T2查詢單據條碼()
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = "" : Dim 實際編號 As String = ""
        Outtmp4 = Format(Replace(Replace("#SyncOuttmp4" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")

        Select Case 作業查詢
            Case "條碼明細"
                If T1DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV3").Clear() : End If '清除T1DGV3資料
                If T1DGV4.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV4").Clear() : End If '清除T1DGV3資料
                實際編號 = 查詢編號
            Case "草稿比對" : If T2DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV2").Clear() : End If '清除T2DGV2資料
                實際編號 = 作業編號
        End Select
        'If T2DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV2").Clear() : End If '清除T2DGV2資料

        SQLQuery = "  IF (OBJECT_ID('tempdb.." & Outtmp4 & "') IS NOT NULL)  DROP TABLE " & Outtmp4 & " "
        Select Case 實際編號
            Case "0"    '0.排程領料
            Case "1", "2", "3", "5"    '1.單據領料, 2.銷售出庫, 3.存貨領用, 4.寄庫出庫
                SQLQuery += "    SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[DistNumber] AS '條碼', CAST(ISNULL(T0.[Quantity],9999) AS NUMERIC(15,4)) AS '數量',  CAST(ISNULL(T1.[Quantity],0) AS NUMERIC(15,4)) AS '庫存', "
                SQLQuery += "          (CASE WHEN T1.[管理] = 'S' THEN ISNULL(T1.[U_M1],'異常') ELSE CASE WHEN T1.[管理] = 'B' THEN ISNULL(T1.[U_M1],0)      ELSE '異常' END END) AS '重量', "
                SQLQuery += "           T1.[WhsCode] AS '庫位', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', "
                SQLQuery += "          (CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity]  = 0 THEN '出庫' ELSE CASE WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END) AS '狀態', "
                SQLQuery += "          (CASE WHEN T2.[狀態] = '1' THEN (CASE WHEN (T1.[管理] = 'B' OR T1.[管理] = 'F') THEN '否' ELSE '是' END) ELSE CASE WHEN T2.[狀態] = '0' THEN '否' END END) AS '重覆', "
                Select Case 實際編號 '銷售別類
                    Case "1", "3", "5"    '1.單據領料, 3.存貨領用, 4.寄庫出庫
                        SQLQuery += "   '銷售' AS '銷售', "
                    Case "2"         '2.銷售出庫
                        SQLQuery += "  (CASE WHEN ISNULL(T0.[Gift],0) = 1 THEN '銷售' ELSE CASE WHEN ISNULL(T0.[Gift],0) = 2 THEN '贈品' ELSE '不知' END END) AS '銷售', "
                End Select
                SQLQuery += "           ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T5.[M_NO],'') AS 'G_OK', ISNULL(T1.[管理],'') AS '管理', T0.[ID] "
                SQLQuery += "           INTO " & Outtmp4 & " "
                'SQLQuery += "      FROM " & Outtmp2 & " T0 LEFT JOIN ( SELECT * FROM " & Outtmp3 & " WHERE [WhsCode] = 'K02' ) T1 ON T0.[DistNumber] = T1.[DistNumber] "
                SQLQuery += "      FROM " & Outtmp2 & " T0 LEFT JOIN ( SELECT * FROM " & Outtmp3 & " "
                If T1CB鎖定.Checked = True Then
                    SQLQuery += "                                                                     WHERE [WhsCode] = '" & T1TB鎖定庫位.Text & "' "
                End If
                SQLQuery += "                                        ) T1 ON T0.[DistNumber] = T1.[DistNumber] "
                SQLQuery += "                              LEFT JOIN ( SELECT T0.[DistNumber], CASE WHEN COUNT(ISNULL(T0.[DistNumber],0)) > 1 THEN '1'  ELSE '0' END '狀態' "
                SQLQuery += "                                            FROM " & Outtmp2 & " T0 GROUP BY T0.[DistNumber] ) T2 ON T0.[DistNumber] = T2.[DistNumber] "
                SQLQuery += "                              LEFT JOIN [z_format_G]    T4 ON T1.[U_M8] = T4.[M_NO] "
                SQLQuery += "                              LEFT JOIN [z_format_G_OK] T5 ON T1.[U_M8] = T5.[M_NO] "
                SQLQuery += "  GROUP BY T1.[ItemCode], T1.[ItemName], T0.[Quantity], T1.[Quantity], T1.[MnfDate], T0.[DistNumber], T1.[U_M1], T1.[WhsCode], T1.[U_M2], T1.[U_M8], T4.[M_NO], T5.[M_NO], T1.[管理], T0.[Gift], T2.[狀態], T0.[ID] "
                SQLQuery += "  ORDER BY COUNT(T0.[DistNumber]) DESC ,T0.[DistNumber] "
                'Case "3"    '3.存貨領用
            Case "4"        '0.採購入庫
                'SQLQuery += "    SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[DistNumber] AS '條碼', CAST(ISNULL(T0.[Quantity],9999) AS NUMERIC(15,4)) AS '數量',  CAST(ISNULL(T1.[Quantity],0) AS NUMERIC(15,4)) AS '庫存', "
                'SQLQuery += "          (CASE WHEN T1.[管理] = 'S' THEN ISNULL(T1.[U_M1],'異常') ELSE CASE WHEN T1.[管理] = 'B' THEN ISNULL(T1.[U_M1],0)      ELSE '異常' END END) AS '重量', "
                'SQLQuery += "           T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', "
                'SQLQuery += "          (CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity]  = 0 THEN '出庫' ELSE CASE WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END) AS '狀態', "
                'SQLQuery += "          (CASE WHEN T2.[狀態] = '1' THEN (CASE WHEN (T1.[管理] = 'B' OR T1.[管理] = 'F') THEN '否' ELSE '是' END) ELSE CASE WHEN T2.[狀態] = '0' THEN '否' END END) AS '重覆', "
                'Select Case 實際編號 '銷售別類
                '    Case "1", "3"    '1.單據領料, 3.存貨領用
                '        SQLQuery += "   '銷售' AS '銷售', "
                '    Case "2"         '2.銷售出庫
                '        SQLQuery += "  (CASE WHEN ISNULL(T0.[Gift],0) = 1 THEN '銷售' ELSE CASE WHEN ISNULL(T0.[Gift],0) = 2 THEN '贈品' ELSE '不知' END END) AS '銷售', "
                'End Select
                SQLQuery += "    SELECT T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[DistNumber] AS '條碼', CAST(ISNULL(T0.[Quantity],9999) AS NUMERIC(15,4)) AS '數量',  CAST(ISNULL(T1.[Quantity],0) AS NUMERIC(15,4)) AS '庫存', "
                SQLQuery += "          (CASE WHEN T1.[管理] = 'S' THEN ISNULL(T1.[U_M1],'異常') ELSE CASE WHEN T1.[管理] = 'B' THEN ISNULL(T1.[U_M1],0)      ELSE '異常' END END) AS '重量', "
                SQLQuery += "           T1.[WhsCode] AS '庫位', T1.[U_M2] AS '儲位', T1.[MnfDate] AS '製造日期', T1.[U_M8] AS '製造單號', "
                SQLQuery += "          (CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity]  = 0 THEN '出庫' ELSE CASE WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END) AS '狀態', "
                SQLQuery += "          (CASE WHEN T2.[狀態] = '1' THEN (CASE WHEN (T1.[管理] = 'B' OR T1.[管理] = 'F') THEN '否' ELSE '是' END) ELSE CASE WHEN T2.[狀態] = '0' THEN '否' END END) AS '重覆', "
                SQLQuery += "   '銷售' AS '銷售', "
                SQLQuery += "           ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T5.[M_NO],'') AS 'G_OK', ISNULL(T1.[管理],'') AS '管理', T0.[ID] "
                SQLQuery += "           INTO " & Outtmp4 & " "
                SQLQuery += "      FROM " & Outtmp2 & " T0 LEFT JOIN ( SELECT * FROM " & Outtmp3 & ") T1 ON T0.[DistNumber] = T1.[DistNumber] "
                SQLQuery += "                              LEFT JOIN ( SELECT T0.[DistNumber], CASE WHEN COUNT(ISNULL(T0.[DistNumber],0)) > 1 THEN '1'  ELSE '0' END '狀態' "
                SQLQuery += "                                            FROM " & Outtmp2 & " T0 GROUP BY T0.[DistNumber] ) T2 ON T0.[DistNumber] = T2.[DistNumber] "
                'SQLQuery += "                              LEFT JOIN [z_format_G]    T4 ON T1.[U_M8] = T4.[M_NO] "
                'SQLQuery += "                              LEFT JOIN [z_format_G_OK] T5 ON T1.[U_M8] = T5.[M_NO] "
                'SQLQuery += "  GROUP BY T1.[ItemCode], T1.[ItemName], T0.[Quantity], T1.[Quantity], T1.[MnfDate], T0.[DistNumber], T1.[U_M1], T1.[U_M2], T1.[U_M8], T4.[M_NO], T5.[M_NO], T1.[管理], T0.[Gift], T2.[狀態], T0.[ID] "
                SQLQuery += "  GROUP BY T1.[ItemCode], T1.[ItemName], T0.[Quantity], T1.[Quantity], T1.[MnfDate], T0.[DistNumber], T1.[U_M1], T1.[WhsCode], T1.[U_M2], T1.[U_M8], T1.[管理], T0.[Gift], T2.[狀態], T0.[ID] "
                SQLQuery += "  ORDER BY COUNT(T0.[DistNumber]) DESC ,T0.[DistNumber] "

        End Select
        SQLQuery += " SELECT * FROM " & Outtmp4 & " "
        SQLQuery2 = " SELECT [存編], [品名], SUM(CAST([數量] AS NUMERIC(10,2))) AS '數量', SUM(CAST([重量] AS NUMERIC(10,2))) AS '重量' FROM " & Outtmp4 & " GROUP BY [存編], [品名] "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            Select Case 作業查詢
                Case "條碼明細"
                    DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV3") : T1DGV3.DataSource = ks1DataSetDGV.Tables("T1DGV3") : T1DGV3.AutoResizeColumns()

                    SQLCmd2.Connection = DBConn : SQLCmd2.CommandText = SQLQuery2 : SQLCmd2.CommandTimeout = 100000
                    SQLCmd2.Parameters.Clear() : SQLCmd2.ExecuteNonQuery()
                    DataAdapterDGV = New SqlDataAdapter(SQLCmd2.CommandText, DBConn)
                    DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV4") : T1DGV4.DataSource = ks1DataSetDGV.Tables("T1DGV4") : T1DGV4.AutoResizeColumns()
                Case "草稿比對" : DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV2") : T2DGV2.DataSource = ks1DataSetDGV.Tables("T2DGV2")
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T2查詢單據明細()    '品項資料
        If T2DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV1").Clear() : End If '清除T2DGV1資料
        If T2DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV1").Columns.Clear() : End If '清除T2DGV1資料

        Dim SQLQuery As String = ""
        Outtmp1 = Format(Replace(Replace("#SyncOuttmp1" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")

        SQLQuery = "  IF (OBJECT_ID('tempdb.." & Outtmp1 & "') IS NOT NULL)  DROP TABLE " & Outtmp1 & " "
        Select Case 作業編號
            Case "0"    '0.排程領料
            Case "1", "2", "5"    '1.單據領料, 2.銷售出庫, 4.寄庫出庫
                '先寫暫存 Outtmp1
                SQLQuery += "   SELECT S1.[DocEntry] AS '草稿單號', S1.[LineNum] AS '列號', S1.[ItemCode] AS '存編', S1.[Dscription] AS '品名', dbo.getRoundN(S1.[Quantity],4) AS '預出數量', "
                SQLQuery += "          S1.[U_P4] AS '單位2數量', S1.[U_P5] AS '單位1KG', S1.[U_P6] AS '小單位' ,S1.[U_P7] AS '計價單位', S1.[U_P8] AS '銷售金額', S1.[U_Omoney] AS '付款方法', "
                SQLQuery += "          S1.[U_P1] AS '員工', S1.[U_Cdate] AS '入雛日', S1.[U_P3] AS '生產否', S1.[BaseType], S1.[BaseEntry], S1.[BaseLine], "
                'SQLQuery += "         (CASE WHEN SUBSTRING(S1.[ItemCode],1,1) IN ('2','3') THEN '銷售' ELSE "
                'SQLQuery += "          CASE WHEN S1.[U_P8] = 0 THEN '贈品' ELSE '銷售' END END) AS '銷售', "
                'SQLQuery += "         (CASE WHEN S1.[U_P8] = 0 THEN '贈品' ELSE '銷售' END ) AS '銷售',"

                Select Case 作業編號 '銷售別類
                    Case "1", "3", "5"    '1.單據領料, 3.存貨領用, 4.寄庫出庫
                        SQLQuery += " '銷售' AS '銷售', "
                    Case "2"         '2.銷售出庫
                        'SQLQuery += "  (CASE WHEN ISNULL(T0.[Gift],0) = 1 THEN '銷售' ELSE CASE WHEN ISNULL(T0.[Gift],0) = 2 THEN '贈品' ELSE '不知' END END) AS '銷售', "
                        SQLQuery += " (CASE WHEN S1.[U_P8] = 0 THEN '贈品' ELSE '銷售' END ) AS '銷售',"

                End Select
                'F = 無管理,S = 序號,B = 批次

                SQLQuery += "         (CASE WHEN (S2.[ManSerNum] = 'N' AND S2.[ManBtchNum] = 'N') THEN 'F' ELSE "
                SQLQuery += "          CASE WHEN (S2.[ManSerNum] = 'Y' AND S2.[ManBtchNum] = 'N') THEN 'S' ELSE "
                SQLQuery += "          CASE WHEN (S2.[ManSerNum] = 'N' AND S2.[ManBtchNum] = 'Y') THEN 'B' ELSE 'X' END END END) AS '管理' INTO " & Outtmp1 & " "
                SQLQuery += "     FROM [DRF1] S1 LEFT JOIN [OITM] S2 ON S1.[ItemCode] = S2.[ItemCode] WHERE S1.[DocEntry] = '" & 草稿T2.Text & "' "
                '整合 Outtmp1 及 Outtmp4
                Select Case 作業編號
                    Case "1"    '1.單據領料
                        SQLQuery += "   SELECT S1.[草稿單號], S1.[列號], S1.[存編], S1.[品名], S1.[預出數量], (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END) AS '出庫數量', "
                        SQLQuery += "          dbo.getRoundN((ISNULL((CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE ISNULL(S2.[數量],0) END),0))- S1.[預出數量],4) AS '差異數', dbo.getRoundN(ISNULL(S2.[重量],0),2) AS '出庫重量', "
                        SQLQuery += "          S1.[單位2數量], S1.[單位1KG], S1.[小單位], S1.[計價單位], S1.[銷售金額], S1.[付款方法], S1.[員工], S1.[入雛日], S1.[生產否], S1.[BaseType], S1.[BaseEntry], S1.[BaseLine], 0 AS '實際金額', S1.[銷售], S1.[管理] "
                        SQLQuery += "     FROM " & Outtmp1 & " S1 LEFT  JOIN ("
                        SQLQuery += "          SELECT T1.[存編], SUM(CAST(T1.[數量] AS NUMERIC(15,4))) AS '數量', SUM(CAST(T1.[重量] AS NUMERIC(15,2))) AS '重量', T1.[銷售] "
                        SQLQuery += "            FROM " & Outtmp4 & " T1 GROUP BY T1.[存編], T1.[銷售] ) S2 ON S1.[存編] = S2.[存編] AND S1.[銷售] = S2.[銷售] ORDER BY 2 "
                        'Case "2"    '2.銷售出庫
                        '    SQLQuery += "   SELECT S1.[草稿單號], S1.[列號], S1.[存編], S1.[品名], S1.[預出數量], (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END) AS '出庫數量', "
                        '    SQLQuery += "          dbo.getRoundN((ISNULL((CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE ISNULL(S2.[數量],0) END),0))- S1.[預出數量],4) AS '差異數', dbo.getRoundN(ISNULL(S2.[重量],0),2) AS '出庫重量', "
                        '    SQLQuery += "          S1.[單位2數量], S1.[單位1KG], S1.[小單位], S1.[計價單位], S1.[銷售金額], S1.[付款方法], S1.[員工], S1.[入雛日], S1.[生產否], S1.[BaseType], S1.[BaseEntry], S1.[BaseLine], "
                        '    SQLQuery += "             (CASE WHEN ISNULL(S2.[數量],0) <> 0 THEN"
                        '    SQLQuery += "              CASE WHEN S1.[計價單位] = '0' THEN S1.[銷售金額] ELSE "
                        '    SQLQuery += "              CASE WHEN S1.[計價單位] = '1' THEN (S1.[銷售金額] * S2.[重量] / S2.[數量]) ELSE "
                        '    'SQLQuery += "             CASE WHEN S1.[計價單位] = '2' THEN NULLIF((S1.[銷售金額] * S1.[單位2數量] / S2.[數量]),0) ELSE '異常' END END END),0) AS '實際金額', "
                        '    SQLQuery += "              CASE WHEN S1.[計價單位] = '2' THEN (S1.[銷售金額] * S1.[單位2數量] / (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END)) ELSE '異常' END END END END) AS '實際金額', "
                        '    SQLQuery += "          S1.[銷售], S1.[管理] "
                        '    SQLQuery += "     FROM " & Outtmp1 & " S1 LEFT  JOIN ("
                        '    SQLQuery += "          SELECT T1.[存編], SUM(CAST(T1.[數量] AS NUMERIC(15,4))) AS '數量', SUM(CAST(T1.[重量] AS NUMERIC(15,2))) AS '重量', T1.[銷售] "
                        '    SQLQuery += "            FROM " & Outtmp4 & " T1 GROUP BY T1.[存編], T1.[銷售] ) S2 ON S1.[存編] = S2.[存編] AND S1.[銷售] = S2.[銷售] ORDER BY 2 "
                    Case "2", "5"    '2.銷售出庫, 4.寄庫出庫
                        SQLQuery += "   SELECT S1.[草稿單號], S1.[列號], S1.[存編], S1.[品名], S1.[預出數量], (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END) AS '出庫數量', "
                        SQLQuery += "          dbo.getRoundN((ISNULL((CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE ISNULL(S2.[數量],0) END),0))- S1.[預出數量],4) AS '差異數', dbo.getRoundN(ISNULL(S2.[重量],0),2) AS '出庫重量', "
                        SQLQuery += "          S1.[單位2數量], S1.[單位1KG], S1.[小單位], S1.[計價單位], S1.[銷售金額], S1.[付款方法], S1.[員工], S1.[入雛日], S1.[生產否], S1.[BaseType], S1.[BaseEntry], S1.[BaseLine], "
                        ''SQLQuery += "             (CASE WHEN ISNULL(S2.[數量],0) <> 0 THEN"
                        'SQLQuery += "             (CASE WHEN S1.[計價單位] = '0' THEN  S1.[銷售金額] * S2.[數量] ELSE "
                        'SQLQuery += "              CASE WHEN S1.[計價單位] = '1' THEN (S1.[銷售金額] * S2.[重量] / S2.[數量]) ELSE "
                        ''SQLQuery += "             CASE WHEN S1.[計價單位] = '2' THEN NULLIF((S1.[銷售金額] * S1.[單位2數量] / S2.[數量]),0) ELSE '異常' END END END),0) AS '實際金額', "
                        ''SQLQuery += "              CASE WHEN S1.[計價單位] = '2' THEN (S1.[銷售金額] * S1.[單位2數量] / (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END)) ELSE '異常' END END END END) AS '實際金額', "
                        'SQLQuery += "              CASE WHEN S1.[計價單位] = '2' THEN (S1.[銷售金額] * S1.[單位2數量] / (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END)) ELSE '異常' END END END ) AS '實際金額', "

                        'SQLQuery += "         CASE S1.[計價單位] WHEN '0' THEN (CASE WHEN RIGHT(S1.[存編],2) = '-1' THEN S1.[銷售金額] * -1 ELSE S1.[銷售金額] END) "
                        Select Case 作業編號
                            Case "2"
                                SQLQuery += "         CASE S1.[計價單位] WHEN '0' THEN CAST(S1.[銷售金額] AS NUMERIC(15,4)) "
                                SQLQuery += "                            WHEN '1' THEN NULLIF((CAST(S1.[銷售金額] AS NUMERIC(15,4)) * CAST(S2.[重量]      AS NUMERIC(15,4)) / CAST(S2.[數量] AS NUMERIC(15,4))),0) "
                                'SQLQuery += "                            WHEN '2' THEN NULLIF((S1.[銷售金額] * S1.[單位2數量] / (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END)),0) "
                                SQLQuery += "                            WHEN '2' THEN         CAST(S1.[銷售金額] AS NUMERIC(15,4)) * CAST(S1.[單位2數量] AS NUMERIC(15,4)) / NULLIF(CASE WHEN S1.[管理] = 'F' THEN CAST(S1.[預出數量] AS NUMERIC(15,4)) ELSE CAST(ISNULL(S2.[數量],0) AS NUMERIC(15,4)) END,0) "
                                SQLQuery += "         ELSE 0 END AS '實際金額', "
                            Case "5"
                                SQLQuery += "         CASE S1.[計價單位] WHEN '0' THEN S1.[銷售金額] "
                                SQLQuery += "                            WHEN '1' THEN CASE WHEN S1.[銷售金額] <> 0 THEN NULLIF((S1.[銷售金額] * S2.[重量] / S2.[數量]),0) ELSE 0 END "
                                SQLQuery += "                            WHEN '2' THEN CASE WHEN S1.[銷售金額] <> 0 THEN NULLIF((S1.[銷售金額] * S1.[單位2數量] / (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END)),0) ELSE 0 END "
                                SQLQuery += "         ELSE 0 END AS '實際金額', "
                        End Select
                        SQLQuery += "          S1.[銷售], S1.[管理] "
                        SQLQuery += "     FROM " & Outtmp1 & " S1 LEFT  JOIN ("
                        SQLQuery += "          SELECT T1.[存編], SUM(CAST(T1.[數量] AS NUMERIC(15,4))) AS '數量', SUM(CAST(T1.[重量] AS NUMERIC(15,2))) AS '重量', T1.[銷售] "
                        SQLQuery += "            FROM " & Outtmp4 & " T1 GROUP BY T1.[存編], T1.[銷售] ) S2 ON S1.[存編] = S2.[存編] AND S1.[銷售] = S2.[銷售] ORDER BY 2 "

                End Select
            Case "3"    '3.存貨領用
                '先寫暫存 Outtmp1
                SQLQuery += "    SELECT S1.[ID] AS '草稿單號', (Row_Number() OVER (partition by ID order by ID Asc, ProCode ASC) - 1) as '列號', S1.[ProCode] AS '存編', S1.[ProName] AS '品名', "
                SQLQuery += "           dbo.getRoundN(S1.[Num],4) AS '預出數量', '銷售' AS '銷售',"
                SQLQuery += "         (CASE WHEN (S2.[ManSerNum] = 'N' AND S2.[ManBtchNum] = 'N') THEN 'F' ELSE CASE WHEN (S2.[ManSerNum] = 'Y' AND S2.[ManBtchNum] = 'N') THEN 'S' ELSE "
                SQLQuery += "          CASE WHEN (S2.[ManSerNum] = 'N' AND S2.[ManBtchNum] = 'Y') THEN 'B' ELSE 'X' END END END) AS '管理' INTO " & Outtmp1 & " "
                SQLQuery += "     FROM [KS_Z_StockApply_Detail] S1 LEFT JOIN [OITM] S2 ON S1.[ProCode] = S2.[ItemCode]"
                SQLQuery += "    WHERE S1.[ID] = '" & 草稿T2.Text & "' "
                '整合 Outtmp1 及 Outtmp4
                SQLQuery += "   SELECT S1.[草稿單號], S1.[列號], S1.[存編], S1.[品名], S1.[預出數量], (CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE dbo.getRoundN(ISNULL(S2.[數量],0),4) END) AS '出庫數量', "
                SQLQuery += "          dbo.getRoundN((ISNULL((CASE WHEN S1.[管理] = 'F' THEN S1.[預出數量] ELSE ISNULL(S2.[數量],0) END),0))- S1.[預出數量],4) AS '差異數', dbo.getRoundN(ISNULL(S2.[重量],0),2) AS '出庫重量', S1.[銷售], S1.[管理] "
                SQLQuery += "     FROM " & Outtmp1 & " S1 LEFT  JOIN ("
                SQLQuery += "          SELECT T1.[存編], SUM(CAST(T1.[數量] AS NUMERIC(15,4))) AS '數量', SUM(CAST(T1.[重量] AS NUMERIC(15,2))) AS '重量', T1.[銷售] "
                SQLQuery += "            FROM " & Outtmp4 & " T1 GROUP BY T1.[存編], T1.[銷售] ) S2 ON S1.[存編] = S2.[存編] AND S1.[銷售] = S2.[銷售] ORDER BY 2 "
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV1")
            T2DGV1.DataSource = ks1DataSetDGV.Tables("T2DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'T2查詢明細_Play()

    End Sub


    Private Sub T2查詢明細_Play()
        '--載入資料畫面
        For Each column As DataGridViewColumn In T2DGV1.Columns
            column.Visible = True
            Select Case 作業編號
                Case "0"    '0.排程領料
                Case "1", "3"    '1.單據領料, 3.存貨領用
                    Select Case column.Name
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "預出數量" : column.HeaderText = "預出數量" : column.DisplayIndex = 2
                        Case "出庫數量" : column.HeaderText = "出庫數量" : column.DisplayIndex = 3
                        Case "差異數" : column.HeaderText = "差異數" : column.DisplayIndex = 4
                        Case "出庫重量" : column.HeaderText = "出庫重量" : column.DisplayIndex = 5
                        Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 6
                        Case Else
                            column.Visible = False
                    End Select
                Case "2", "5"    '2.銷售出庫, 4.寄庫出庫
                    Select Case column.Name
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "預出數量" : column.HeaderText = "預出數量" : column.DisplayIndex = 2
                        Case "出庫數量" : column.HeaderText = "出庫數量" : column.DisplayIndex = 3
                        Case "差異數" : column.HeaderText = "差異數" : column.DisplayIndex = 4
                        Case "出庫重量" : column.HeaderText = "出庫重量" : column.DisplayIndex = 5
                        Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 6
                        Case "銷售" : column.HeaderText = "銷售" : column.DisplayIndex = 7
                        Case Else
                            column.Visible = False
                    End Select
                    'Case "3"    '3.存貨領用

                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T2查詢單據非單據品項()
        If T2DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV3").Clear() : End If '清除T2DGV3資料
        Dim SQLQuery As String = ""

        Select Case 作業編號
            Case "0" : Exit Sub    '0.排程領料
            Case "1", "2", "3", "5"    '1.單據領料, '2.銷售出庫, 3.存貨領用, 4.寄庫出庫
                SQLQuery = " SELECT T0.[存編], T0.[品名] FROM " & Outtmp4 & " T0 EXCEPT SELECT T0.[存編], T0.[品名] FROM " & Outtmp1 & " T0 "
                'Case "3" : Exit Sub    '3.存貨領用
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV3")
            T2DGV3.DataSource = ks1DataSetDGV.Tables("T2DGV3")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'T1_DGV動作
    Private Sub T1DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV1.CellClick
        If T1DGV1.RowCount = 0 Then : Exit Sub : End If
        草稿T1.Text = T1DGV1.CurrentRow.Cells("草稿").Value

    End Sub

    Private Sub 單據條碼T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 單據條碼T1.Click
        T1查詢單據條碼件數()

    End Sub

    Private Sub T1查詢單據條碼件數()
        If T1DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV2").Clear() : End If '清除T1DGV2資料
        Dim SQLQuery As String = ""

        SQLQuery = "  SELECT [OUT01] AS '作業別', [OUT04] AS '草稿單號', COUNT([OUT02]) AS '條碼數量' FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] WHERE [OUT06] = '3' GROUP BY [OUT01], [OUT04] "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV2")
            T1DGV2.DataSource = ks1DataSetDGV.Tables("T1DGV2")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 條碼明細T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 條碼明細T1.Click
        If 移除作業T1.Text = "" Then : Exit Sub : End If
        作業查詢 = "條碼明細"
        T2查詢單據暫存作業()
        T2查詢單據條碼()
        作業查詢 = ""

    End Sub

    Private Sub 顯示項目T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 顯示項目T1.Click

        Select Case 顯示項目T1.Text
            Case "明細"
                顯示項目T1.Text = "件數"
                T1DGV3.Visible = False
                T1DGV4.Visible = True
                T1DGV4.AutoResizeColumns()
            Case "件數"
                顯示項目T1.Text = "明細"
                T1DGV3.Visible = True
                T1DGV4.Visible = False
                T1DGV3.AutoResizeColumns()
        End Select

    End Sub

    Private Sub T1DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV2.CellClick
        If T1DGV2.RowCount = 0 Then : Exit Sub : End If
        If T1DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV3").Clear() : End If '清除T1DGV3資料
        If T1DGV4.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV4").Clear() : End If '清除T1DGV3資料
        移除作業T1.Text = T1DGV2.CurrentRow.Cells("作業別").Value
        移除草稿T1.Text = T1DGV2.CurrentRow.Cells("草稿單號").Value
        Select Case 移除作業T1.Text
            Case "25.分時領料" : 查詢別號 = " =   '25'" : 查詢編號 = "0"       '領料  23,24
            Case "21.領料電宰", "22.領料加工" : 查詢別號 = " IN ('21','22')" : 查詢編號 = "1" '領料
            Case "31.銷售電宰", "32.銷售加工" : 查詢別號 = " IN ('31','32')" : 查詢編號 = "2" '銷售
            Case "41.存領電宰", "42.存領加工" : 查詢別號 = " IN ('41','42')" : 查詢編號 = "3" '領用
            Case "51.寄庫出庫", "52.寄庫出庫" : 查詢別號 = " IN ('51','52')" : 查詢編號 = "5" '領用
        End Select

    End Sub

    Private Sub 單據移除T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 單據移除T1.Click
        If 移除作業T1.Text = "" Then : Exit Sub : End If

        Dim oAns As Integer
        oAns = MsgBox("確定註記作廢此條碼?" & Chr(13) & 移除作業T1.Text & vbCrLf & 移除草稿T1.Text, MsgBoxStyle.OkCancel + 16, "註記作廢")
        If oAns = MsgBoxResult.Ok Then
            T1移除單據條碼明細()
            T1查詢單據條碼件數()
            移除作業T1.Text = "" : 移除草稿T1.Text = ""
            If T1DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV3").Clear() : End If '清除T1DGV3資料
        End If

    End Sub

    Private Sub T1移除單據條碼明細()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT06] = '6' FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] WHERE [OUT01] = '" & 移除作業T1.Text & "' AND [OUT04] = '" & 移除草稿T1.Text & "' AND [OUT06] = '3' "

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 單據更換T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 單據更換T1.Click
        If 移除草稿T1.Text = "" Then : MsgBox("未選更換單據", 16, "錯誤") : Exit Sub : End If
        If 草稿T1.Text = "" Then : MsgBox("未選目地單據", 16, "錯誤") : Exit Sub : End If
        Dim 作業比對 As String = ""
        Select Case Mid(移除作業T1.Text, 1, 2)
            Case "21", "22" : 作業比對 = "1"
            Case "31", "32" : 作業比對 = "2"
            Case "41", "42" : 作業比對 = "3"
            Case "51", "52" : 作業比對 = "5"
            Case Else : 作業比對 = ""
        End Select
        If 作業編號 <> 作業比對 Then : MsgBox("作業項目不同，無法更換", 16, "錯誤") : Exit Sub : End If

        Dim oAns As Integer
        oAns = MsgBox("確定更換草稿號碼?" & Chr(13) & vbCrLf & "原目單號：" & 移除草稿T1.Text & vbCrLf & "移至單號：" & 草稿T1.Text, MsgBoxStyle.OkCancel + 16, "更換草稿號碼")
        If oAns = MsgBoxResult.Ok Then
            T1更換草稿號碼()
            T1查詢單據條碼件數()
            草稿T1.Text = "" : 移除作業T1.Text = "" : 移除草稿T1.Text = ""
            If T1DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV3").Clear() : End If '清除T1DGV3資料
            If T1DGV4.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV4").Clear() : End If '清除T1DGV3資料
        End If

    End Sub

    Private Sub T1更換草稿號碼()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT04] = '" & 草稿T1.Text & "' FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] WHERE [OUT01] = '" & 移除作業T1.Text & "' AND [OUT04] = '" & 移除草稿T1.Text & "' AND [OUT06] = '3' "

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'T2_DGV動作
    Private Sub T2DGV清除作業()
        'T2DGV清除單據暫存作業()
        If T2DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV1").Clear() : End If '清除T2DGV1資料
        If T2DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV2").Clear() : End If '清除T2DGV2資料
        If T2DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV3").Clear() : End If '清除T2DGV3資料
    End Sub

    Private Sub T2DGV清除單據暫存作業()
        Dim SQLQuery As String = ""

        SQLQuery = "   IF (OBJECT_ID('tempdb.." & Outtmp1 & "') IS NOT NULL)  DROP TABLE " & Outtmp1 & " "
        SQLQuery += "  IF (OBJECT_ID('tempdb.." & Outtmp2 & "') IS NOT NULL)  DROP TABLE " & Outtmp2 & " "
        SQLQuery += "  IF (OBJECT_ID('tempdb.." & Outtmp3 & "') IS NOT NULL)  DROP TABLE " & Outtmp3 & " "
        SQLQuery += "  IF (OBJECT_ID('tempdb.." & Outtmp4 & "') IS NOT NULL)  DROP TABLE " & Outtmp4 & " "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'T2_作業
    Private Sub 發貨作業T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 發貨作業T2.Click
        If 登入系統 <> "0" Then : MsgBox("非SAP權限帳號登入無法作業!", 16, "錯誤") : Exit Sub : End If
        If 草稿T1.Text <> 草稿T2.Text Then : MsgBox("單號錯誤無法作業@@", 16, "錯誤") : Exit Sub : End If

        dteStart = Now  ''...要計算執行時間的程式區段 ...
        回傳SAP機制()

        Dim 執行時間s As String = "0.00"
        Dim 執行時間a As TimeSpan = Now.Subtract(dteStart)
        執行時間s = "作業時間 " & Format(執行時間a.TotalSeconds, "###0.00" & " 秒")
        Select Case 是否成功
            Case "Y"
                T2條碼出庫更新作業()
                MsgBox("SAP" & 出貨別類 & "單新增完成!!" & vbCrLf & "" & 出貨別類 & "單號：" & 回傳單號 & vbCrLf & 執行時間s, 64, "完成")
            Case "N"
                MsgBox("SAP" & 出貨別類 & "單錯誤說明!!" & vbCrLf & "錯誤說明：" & 錯誤資訊 & vbCrLf & 執行時間s, 16, "錯誤")
                Exit Sub
        End Select

        文字初始化()
        查詢單據()
        T2DGV清除作業()
        Me.TabControl1.SelectedTab = Me.TabPage1
        單據條碼T1.PerformClick()
        T1CB鎖定.Checked = False : T1TB鎖定庫位.Text = ""

    End Sub

    Private Sub T2條碼出庫更新作業()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT07] = '" & 回傳單號 & "', [OUT06] = '4' "
            SQLCmd.CommandText += "  FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] S0 INNER JOIN " & Outtmp2 & " S1 ON S0.[OUT02] = S1.[DistNumber] AND [OUT06] = '3' AND [OUT04] = '" & 草稿T2.Text & "' "

            Select Case 作業編號
                Case "3"    '3.存貨領用 ID = 2 已出庫
                    SQLCmd.CommandText += " UPDATE [KS_Z_StockApply_Detail] SET [ID] = '2' FROM [KS_Z_StockApply_Detail] WHERE [ID] = '" & 草稿T2.Text & "' "
            End Select

            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub 放棄作業T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 放棄作業T2.Click
        文字初始化()
        T2DGV清除作業()
        Me.TabControl1.SelectedTab = Me.TabPage1
        T1CB鎖定.Checked = False : T1TB鎖定庫位.Text = ""

    End Sub

    'T4相關作業
    Private Sub 查看異常T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查看異常T2.Click
        If T2DGV2.RowCount = 0 Then : MsgBox("無條碼可改", 16, "錯誤") : Exit Sub : End If

        草稿T4.Text = 草稿T2.Text
        T2DGV清除作業()
        異常作業 = "列出全部"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        Me.TabControl1.SelectedTab = Me.TabPage4
        T4DGV1.AutoResizeColumns()
    End Sub

    Private Sub T4列出全部_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4列出全部.Click
        異常作業 = "列出全部"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        T4DGV1.AutoResizeColumns()
    End Sub

    Private Sub T4列出重覆_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4列出重覆.Click
        異常作業 = "列出重覆"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        T4DGV1.AutoResizeColumns()
    End Sub

    Private Sub T4列出已出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4列出已出.Click
        異常作業 = "列出已出"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        T4DGV1.AutoResizeColumns()
    End Sub

    Private Sub T4非單品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4非單品項.Click
        異常作業 = "非單品項"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        T4DGV1.AutoResizeColumns()
    End Sub

    Private Sub T4查詢單據條碼異常()
        If T4DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T4DGV1").Clear() : End If '清除T4DGV1資料

        Dim SQLQuery As String = ""
        Select Case 異常作業
            Case "列出全部", "變更銷售"
                SQLQuery = " SELECT '' AS '選擇', * FROM " & Outtmp4 & " "
            Case "列出重覆"
                SQLQuery = " SELECT '' AS '選擇', * FROM " & Outtmp4 & " WHERE [重覆] = '是' "
            Case "列出已出"
                SQLQuery = " SELECT '' AS '選擇', * FROM " & Outtmp4 & " WHERE [狀態] = '出庫' "
            Case "非單品項"
                Select Case 作業編號
                    Case "0" : Exit Sub    '0.排程領料
                    Case "1", "2", "5"    '1.單據領料, 2.銷售出庫, 4.寄庫出庫
                        SQLQuery = " SELECT T0.[存編], T0.[品名] FROM " & Outtmp4 & " T0 EXCEPT SELECT T0.[存編], T0.[品名] FROM " & Outtmp1 & " T0 "
                    Case "3" : Exit Sub    '3.存貨領用
                End Select
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T4DGV1")
            T4DGV1.DataSource = ks1DataSetDGV.Tables("T4DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        T4查詢單據條碼異常_Play()

    End Sub

    Private Sub T4查詢單據條碼異常_Play()
        '--載入資料畫面
        For Each column As DataGridViewColumn In T4DGV1.Columns
            column.Visible = True
            Select Case 異常作業
                Case "列出全部", "列出重覆", "列出已出", "變更銷售"
                    Select Case column.Name
                        'Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "條碼" : column.HeaderText = "條碼" : column.DisplayIndex = 2
                        Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3
                        Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 4
                        Case "儲位" : column.HeaderText = "儲位" : column.DisplayIndex = 5
                        Case "製造日期" : column.HeaderText = "製造日期" : column.DisplayIndex = 6
                        Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 7
                        Case "出庫" : column.HeaderText = "出庫" : column.DisplayIndex = 8
                        Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 9
                        Case "銷售" : column.HeaderText = "銷售" : column.DisplayIndex = 10
                        Case Else
                            column.Visible = False
                    End Select
                Case "非單品項"
                    Select Case column.Name
                        'Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 0 : column.Frozen = True
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1 : column.Frozen = True
                        Case "件數" : column.HeaderText = "件數" : column.DisplayIndex = 2
                        Case Else
                            column.Visible = False
                    End Select
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T4變更銷售始化()
        T4條碼.Text = ""
        T4存編.Text = ""
        T4品名.Text = ""
        T4銷售.Text = ""
        T4ID.Text = ""
    End Sub



    Private Sub T4變更銷售_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4變更銷售.Click
        'If T4DGV1.RowCount = 0 Then : Exit Sub : End If
        T4變更銷售始化()
        T4變更銷售.Enabled = False

        T4列出重覆.Visible = False
        T4列出已出.Visible = False
        T4非單品項.Visible = False
        T4列出全部.Visible = False
        T4移除條碼.Visible = False
        T4回主畫面.Visible = False

        'T4銷售修改.Visible = True
        'T4贈品修改.Visible = True
        T4修改品項.Visible = True
        T4結束作業.Visible = True

        異常作業 = "變更銷售"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        T4DGV1.AutoResizeColumns()

    End Sub

    Private Sub T4結束作業_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4結束作業.Click
        T4變更銷售始化()
        T4變更銷售.Enabled = True

        T4列出重覆.Visible = True
        T4列出已出.Visible = True
        T4非單品項.Visible = True
        T4列出全部.Visible = True
        T4移除條碼.Visible = True
        T4回主畫面.Visible = True

        T4銷售修改.Visible = False
        T4贈品修改.Visible = False
        T4修改品項.Visible = False
        T4結束作業.Visible = False

        異常作業 = "列出全部"
        T4作業.Text = 異常作業
        T4查詢單據條碼異常()
        T4DGV1.AutoResizeColumns()
    End Sub

    Private Sub T4DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T4DGV1.CellClick
        If T4DGV1.RowCount = 0 Then : Exit Sub : End If
        If T4變更銷售.Enabled = True Then : Exit Sub : End If
        T4條碼.Text = T4DGV1.CurrentRow.Cells("條碼").Value
        T4存編.Text = T4DGV1.CurrentRow.Cells("存編").Value
        T4品名.Text = T4DGV1.CurrentRow.Cells("品名").Value
        T4銷售.Text = T4DGV1.CurrentRow.Cells("銷售").Value
        T4ID.Text = T4DGV1.CurrentRow.Cells("ID").Value

        Select Case T4銷售.Text
            Case "銷售"
                T4銷售修改.Visible = False
                T4贈品修改.Visible = True
            Case "贈品"
                T4銷售修改.Visible = True
                T4贈品修改.Visible = False
            Case Else
                T4銷售修改.Visible = False
                T4贈品修改.Visible = False
        End Select

    End Sub

    Private Sub T4銷售修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4銷售修改.Click
        變更作業 = "銷售"
        T4條碼移除更新作業()
        T4變更銷售始化()
        T4銷售修改.Visible = False
        T4贈品修改.Visible = False
    End Sub

    Private Sub T4贈品修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4贈品修改.Click
        變更作業 = "贈品"
        T4條碼移除更新作業()
        T4變更銷售始化()
        T4銷售修改.Visible = False
        T4贈品修改.Visible = False
    End Sub

    Private Sub T4移除條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4移除條碼.Click
        If T4DGV1.RowCount = 0 Then : Exit Sub : End If

        Dim oAns As Integer
        oAns = MsgBox("確定移除條碼嗎?", MsgBoxStyle.OkCancel, "移除條碼")
        If oAns = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        T4條碼移除更新作業()

    End Sub

    Private Sub T4條碼移除更新作業()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn
            For Each oRow As DataGridViewRow In T4DGV1.SelectedRows
                Select Case 異常作業
                    Case "列出全部", "列出重覆", "列出已出"
                        SQLCmd.CommandText += " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT06] = '5' "
                        SQLCmd.CommandText += "   FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] WHERE [OUT06] = '3' AND [OUTID] = '" & oRow.Cells("ID").Value & "' AND [OUT04] = '" & 草稿T4.Text & "' " & vbCrLf
                        SQLCmd.CommandText += " DELETE FROM " & Outtmp4 & " WHERE [ID] = '" & oRow.Cells("ID").Value & "' " & vbCrLf
                    Case "非單品項"
                        SQLCmd.CommandText += " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT06] = '5' "
                        SQLCmd.CommandText += "   FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] S0 INNER JOIN " & Outtmp4 & " S1 ON S0.[OUT02] = S1.[條碼] AND [OUT06] = '3' AND [OUT04] = '" & 草稿T4.Text & "' "
                        SQLCmd.CommandText += "  WHERE S1.[存編] = '" & oRow.Cells("存編").Value & "' " & vbCrLf
                        SQLCmd.CommandText += " DELETE FROM " & Outtmp4 & " WHERE [存編] = '" & oRow.Cells("存編").Value & "' " & vbCrLf
                    Case "變更銷售"
                        'T4條碼變更更新作業()
                        Select Case 變更作業
                            Case "銷售"
                                SQLCmd.CommandText += " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT05] = '1' "
                                SQLCmd.CommandText += "   FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] WHERE [OUT06] = '3' AND [OUTID] = '" & T4ID.Text & "' AND [OUT04] = '" & 草稿T4.Text & "' " & vbCrLf
                                SQLCmd.CommandText += " UPDATE " & Outtmp4 & " SET [銷售] = '銷售' "
                                SQLCmd.CommandText += "   FROM " & Outtmp4 & " WHERE [ID] = '" & T4ID.Text & "' " & vbCrLf
                            Case "贈品"
                                SQLCmd.CommandText += " UPDATE [KaiShingPlug].[dbo].[PDA_OutData_SAP] SET [OUT05] = '2' "
                                SQLCmd.CommandText += "   FROM [KaiShingPlug].[dbo].[PDA_OutData_SAP] WHERE [OUT06] = '3' AND [OUTID] = '" & T4ID.Text & "' AND [OUT04] = '" & 草稿T4.Text & "' " & vbCrLf
                                SQLCmd.CommandText += " UPDATE " & Outtmp4 & " SET [銷售] = '贈品' "
                                SQLCmd.CommandText += "   FROM " & Outtmp4 & " WHERE [ID] = '" & T4ID.Text & "' " & vbCrLf
                        End Select
                End Select
                'SQLCmd.ExecuteNonQuery()
            Next
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        T4查詢單據條碼異常()

    End Sub

    Private Sub T4重新比對_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4重新比對.Click
        If 草稿T2.Text = "" Then : Exit Sub : End If : 草稿T4.Text = ""

        dteStart = Now  ''...要計算執行時間的程式區段 ...

        T2查詢作業()

        Dim 執行時間s As String = "0.00"
        Dim 執行時間a As TimeSpan = Now.Subtract(dteStart)
        執行時間s = "查詢時間 " & Format(執行時間a.TotalSeconds, "###0.00" & " 秒")
        T2執行時間.Text = 執行時間s

        Me.TabControl1.SelectedTab = Me.TabPage2

        T2DGV1.AutoResizeColumns()
        T2DGV2.AutoResizeColumns()
    End Sub

    Private Sub T4回主畫面_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T4回主畫面.Click
        草稿T4.Text = ""
        文字初始化()
        If T4DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T4DGV1").Clear() : End If '清除T4DGV1資料
        Me.TabControl1.SelectedTab = Me.TabPage1
        T1CB鎖定.Checked = False : T1TB鎖定庫位.Text = ""

    End Sub

    Private Sub 列印單號T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 列印單號T1.Click
        If 草稿T1.Text = "" Then
            Exit Sub
        End If

        列印文件單號()
    End Sub

    Structure LabeData  '標籤定義
        Dim PntQty As Integer   '張數
        Dim Itemname As String  '名稱
        Dim Barcode As String   '條碼
    End Structure

    Private Sub 列印文件單號()
        '固定資產
        Dim oAns As Integer
        oAns = MsgBox("確定列印條碼嗎?", MsgBoxStyle.OkCancel, "確認列印")
        If oAns = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If PrintDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PrinterName = PrintDialog.PrinterSettings.PrinterName
        End If

        Dim labelData As String = ""

        Dim olabel As LabeData = New LabeData
        With olabel
            .PntQty = 1             '張數
            .Itemname = 草稿T1.Text '名稱
            .Barcode = 草稿T1.Text  '條碼
        End With
        SentToPrinter(olabel)

    End Sub

    Private Sub SentToPrinter(ByVal olabel As LabeData)

        Dim baseLine As Integer = 0

        Call openport(PrinterName) '指定電腦端的輸出埠
        Call setup("60", "42", "4.0", "7", "0", "2", "0") '設定標籤的寬度、高度、列印速度、列印濃度、感應器類別、gap/black mark 垂直間距、gap/black mark 偏移距離)單位 mm
        Call clearbuffer() '清除
        Call sendcommand("DIRECTION 0") 'SET 出紙方向
        Call sendcommand("SET CUTTER OFF") ' Or the number of printout per cut'

        If System.Text.Encoding.Default.GetBytes(olabel.Itemname).Length <= 14 Then
            Call windowsfont(70, 60, 80, 0, 2, 0, "新細明體", olabel.Itemname)
        Else
            Dim Itemname1 As String = "" : Dim Itemname2 As String = "" : Dim Counter As Integer = 0
            For Each Chr As Char In olabel.Itemname
                Counter = Counter + System.Text.Encoding.GetEncoding("Big5").GetBytes(Chr.ToString()).Length
                If Counter <= 14 Then   '超過14個字元分二列
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
        Call barcode("70", "150", "128", "80", "1", "0", "3", "3", olabel.Barcode) '列印條碼 x,y,條碼類型,高度,是否列印條碼碼文,條碼旋轉角度,條碼窄,條碼寬, 容 以點(point)表示
        Call printlabel("1", olabel.PntQty) '定義列印張數

        '結束列印
        Call closeport() '關閉指定的電腦端輸出埠

    End Sub

    Private Sub 轉出檔案T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉出檔案T2.Click
        DataToExcel(T2DGV2, "")
    End Sub



End Class
