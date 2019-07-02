Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class C_QuerySRNFromDraft
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim TypeSelect As String

    Private Sub C_QuerySRNFromDraft_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        If DrfNum.Text = "" Then
            MsgBox("請輸入草稿編號")
            Exit Sub
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            Dim DrfNums As String = Format(Replace(DrfNum.Text, ",", "','"), "")

            'sql = " SELECT T1.[ItemCode], T1.[Dscription], T2.[OnHand], T2.[ManSerNum], T2.[ManBtchNum] "

            sql = " SELECT T1.[ItemCode], T1.[Dscription], dbo.getRoundN(SUM(T1.[Quantity]),0) AS 'Quantity', dbo.getRoundN(T2.[OnHand],0) AS 'OnHand' "
            sql += "  FROM [ODRF] T0 INNER JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
            sql += "                 INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
            sql += " WHERE T0.[DocEntry] IN ('" & DrfNums & "') AND (T2.[ManSerNum] = 'Y' OR T2.[ManBtchNum] ='Y') "
            sql += " GROUP BY T1.[ItemCode], T1.[Dscription], T2.[OnHand] "
            'sql += " WHERE T0.[DocEntry] = '" & DrfNum.Text & "' "
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            DGV1.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        setdgvSourceMainDisplay()

        '查庫存()

    End Sub

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn2.Click

        Dim DrfNums2 As String
        DrfNums2 = Format(DGV5.CurrentRow.Cells("草稿單號").Value, "")

        If DrfNums2 = "" Then
            MsgBox("請選擇草稿編號")
            Exit Sub
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            'Dim DrfNums As String = Format(Replace(DrfNum.Text, ",", "','"), "")

            'sql = " SELECT T1.[ItemCode], T1.[Dscription], T2.[OnHand], T2.[ManSerNum], T2.[ManBtchNum] "

            sql = " SELECT T1.[LineNum], T1.[ItemCode], T1.[Dscription], dbo.getRoundN(SUM(T1.[Quantity]),0) AS 'Quantity', dbo.getRoundN(T2.[OnHand],0) AS 'OnHand' "
            sql += "  FROM [ODRF] T0 INNER JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
            sql += "                 INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
            sql += " WHERE T0.[DocEntry] = '" & DrfNums2 & "' AND (T2.[ManSerNum] = 'Y' OR T2.[ManBtchNum] ='Y') "
            sql += " GROUP BY T1.[LineNum], T1.[ItemCode], T1.[Dscription], T2.[OnHand] "
            sql += " ORDER BY 1 "
            'sql += " WHERE T0.[DocEntry] = '" & DrfNum.Text & "' "
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            DGV1.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        setdgvSourceMainDisplay2()

    End Sub

    Private Sub setdgvSourceMainDisplay()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無此草稿單號!請重新檢查!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                Case "Dscription"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                Case "Quantity"
                    column.HeaderText = "出貨數量"
                    column.DisplayIndex = 2
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        Label9.Text = DGV1.RowCount
    End Sub

    Private Sub setdgvSourceMainDisplay2()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無此草稿單號!請重新檢查!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "LineNum"
                    column.HeaderText = "列號"
                    column.DisplayIndex = 0 : column.Visible = False
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 1
                Case "Dscription"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 2
                Case "Quantity"
                    column.HeaderText = "出貨數量"
                    column.DisplayIndex = 3
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 4
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        Label9.Text = DGV1.RowCount
    End Sub


    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        '建立生產明細單
        If DGV1.RowCount = 0 Then
            Exit Sub
        End If
        查庫存()
        'LoadSourceList()               '載入選取製單之生產明細單
        'LoadDGV3()
    End Sub

    Private Sub 查庫存()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = " DECLARE @DocEntry varchar(10) "
            SQLCmd.CommandText = " DECLARE @FromDate DateTime "
            SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            SQLCmd.CommandText += "DECLARE @ItemCode varchar(20) "
            SQLCmd.CommandText += "SET NOCOUNT ON "
            'SQLCmd.CommandText += "SET @DocEntry = '" & DrfNum.Text & "' "
            SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @ItemCode = '" & Format(DGV1.CurrentRow.Cells("ItemCode").Value, "") & "' "

            If Login.LogonCompanyDB = "KaiShing" Then
                SQLCmd.CommandText += "  SELECT '生鮮' AS'類別', T0.[ItemCode]   AS '存編', T0.[ItemName] AS '品名', T1.[WhsCode] AS '倉庫', T2.[U_M2] AS '儲位',COUNT(T2.[U_M2]) AS '件數', "
                SQLCmd.CommandText += "         dbo.getRoundN(SUM(ISNULL(T1.[Quantity],0)),0) AS '數量',T0.[InvntryUom] AS '單位', dbo.getRoundN(SUM(CAST(ISNULL(T2.[U_M1],0) AS float)),2) AS '重量',  "
                SQLCmd.CommandText += "         T2.[MnfDate] AS '生產日期', DATEDIFF(DAY,T2.[MnfDate],GETDATE()) AS '天數', T2.[U_M8] AS '製單編號', ISNULL(T3.[M_NO],'') AS 'G1', "
                SQLCmd.CommandText += "         ISNULL(CASE WHEN T2.[MnfDate]='2010.12.11' THEN '烏' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2009.11.06' THEN '土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2009.12.05' THEN '土'     WHEN T2.[MnfDate]='2010.04.28' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.07.24' THEN '土'     WHEN T2.[MnfDate]='2010.07.26' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.08.02' THEN '土'     WHEN T2.[MnfDate]='2010.08.20' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.08.25' THEN '土'     WHEN T2.[MnfDate]='2010.08.31' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.09.06' THEN '土'     WHEN T2.[MnfDate]='2010.10.23' THEN '土'"
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.11.01' THEN '土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2009.06.15' THEN '人土'   WHEN T2.[MnfDate]='2009.11.17' THEN '人土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.07.23' THEN '人土'   WHEN T2.[MnfDate]='2010.07.27' THEN '人土' "
                SQLCmd.CommandText += "                     WHEN T2.[MnfDate]='2010.10.14' THEN '白露花' WHEN T2.[MnfDate]='2010.10.26' THEN '白露花' "
                SQLCmd.CommandText += "                     ELSE NULL END,'') AS 'G2' "
                SQLCmd.CommandText += "    FROM [OITM] T0 INNER JOIN [OSRQ]       T1 ON T0.[ItemCode]   = T1.[ItemCode] "
                SQLCmd.CommandText += "                   INNER JOIN [OSRN]       T2 ON T1.[MdAbsEntry] = T2.[AbsEntry] "
                SQLCmd.CommandText += "                   LEFT  JOIN [z_format_G] T3 ON T2.[U_M8]       = T3.[M_NO]     "
                'SQLCmd.CommandText += "   WHERE EXISTS( SELECT S1.[ItemCode] AS '存編' FROM [DRF1] S1 WHERE S1.[DocEntry] = @DocEntry AND T0.[ItemCode] = S1.[ItemCode]) AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate )"
                SQLCmd.CommandText += "   WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate )"
                SQLCmd.CommandText += "GROUP BY T0.[ItemCode], T0.[ItemName], T1.[WhsCode], T2.[U_M2], T0.[InvntryUom], T2.[MnfDate], T2.[U_M8], T3.[M_NO] "
                SQLCmd.CommandText += "UNION ALL "
            End If

            SQLCmd.CommandText += "  SELECT '調理' AS'類別', T0.[ItemCode]   AS '存編', T0.[ItemName] AS '品名', T1.[WhsCode] AS '倉庫', T2.[U_M2] AS '儲位',COUNT(T2.[U_M2]) AS '件數', "
            SQLCmd.CommandText += "         dbo.getRoundN(SUM(ISNULL(T1.[Quantity],0)),0) AS '數量', T0.[InvntryUom] AS '單位', dbo.getRoundN(SUM(CAST(ISNULL(T2.[U_M1],0) AS float)),2) AS '重量',  "
            SQLCmd.CommandText += "         T2.[MnfDate] AS '生產日期', DATEDIFF(DAY,T2.[MnfDate],GETDATE()) AS '天數', ISNULL(T2.[U_M8],'') AS '製單編號', '' AS 'G1', '' AS 'G2' "
            SQLCmd.CommandText += "    FROM [OITM] T0 INNER JOIN [OBTQ]       T1 ON T0.[ItemCode]   = T1.[ItemCode] "
            SQLCmd.CommandText += "                   INNER JOIN [OBTN]       T2 ON T1.[MdAbsEntry] = T2.[AbsEntry] "
            'SQLCmd.CommandText += "   WHERE EXISTS( SELECT S1.[ItemCode] AS '存編' FROM [DRF1] S1 WHERE S1.[DocEntry] = @DocEntry AND T0.[ItemCode] = S1.[ItemCode]) AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate )"
            SQLCmd.CommandText += "   WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T2.[MnfDate] Between @FromDate AND @ToDate ) AND T1.[WhsCode] IN ('S01','S04','S06','T02') "
            SQLCmd.CommandText += "GROUP BY T0.[ItemCode], T0.[ItemName], T1.[WhsCode], T2.[U_M2], T0.[InvntryUom], T2.[MnfDate], T2.[U_M8] "
            SQLCmd.CommandText += "ORDER BY 5, 2"


            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")

            DGV2.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub









    Private Sub LoadSourceList()

        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If DGV1.CurrentRow.Cells("ManSerNum").Value = "Y" Then

                'sql = "SELECT T0.itemcode,T2.itemname,T0.U_M2, T0.MnfDate, T0.ExpDate,Count(T0.U_M2) as 'Qty' FROM OSRN T0 left join OSRQ T1 on T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.itemcode = T2.itemcode left join [@FinishItem1] T3 ON T0.itemcode = [FI117] and  where T1.Quantity > 0 and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' Group By T0.itemcode,T2.itemname,T0.U_M2, T0.MnfDate, T0.ExpDate"
                sql = " SELECT T3.[FI102], T0.ItemCode, T2.ItemName, T0.U_M2, T0.MnfDate, T0.ExpDate, Count(T0.U_M2) as 'Qty' FROM OSRN T0 left join OSRQ T1 on T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.ItemCode = T2.ItemCode left join [@FinishItem1] T3 ON T0.[DistNumber] = T3.[FI106] where T1.Quantity > 0 and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' Group By T0.ItemCode, T2.ItemName, T0.U_M2, T0.MnfDate, T0.ExpDate, T3.FI102 "

            ElseIf DGV1.CurrentRow.Cells("ManBtchNum").Value = "Y" Then

                'sql = "SELECT T0.itemcode,T2.itemname,T0.U_M2, T0.MnfDate, T0.ExpDate,Count(T0.U_M2) as 'Qty',SUM(T1.Quantity) as 'Sum' FROM OBTN T0 left join OBTQ T1 on T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.itemcode = T2.itemcode where T1.Quantity > 0 and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' Group By T0.itemcode,T2.itemname,T0.U_M2, T0.MnfDate, T0.ExpDate"
                sql = " SELECT T3.[FI102], T0.ItemCode, T2.ItemName, T0.U_M2, T0.MnfDate, T0.ExpDate, Count(T0.U_M2) as 'Qty', SUM(T1.Quantity) as 'Sum' FROM OBTN T0 left join OBTQ T1 on T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.ItemCode = T2.ItemCode left join [@FinishItem2] T3 ON T0.[DistNumber] = T3.[FI106]  where T1.Quantity > 0 and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' Group By T0.ItemCode, T2.ItemName, T0.U_M2, T0.MnfDate, T0.ExpDate, T3.[FI102] "

            Else
                Exit Sub
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            DGV2.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        setdgvSourceListDisplay()     '設定dgvSourceList顯示格式
    End Sub

    Private Sub setdgvSourceListDisplay()

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "FI102"
                    column.HeaderText = "製造單"
                    column.DisplayIndex = 0
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 1
                Case "ItemName"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 2
                Case "U_M2"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 3
                Case "MnfDate"
                    column.HeaderText = "生產日期"
                    column.DisplayIndex = 4
                Case "ExpDate"
                    column.HeaderText = "有效日期"
                    column.DisplayIndex = 5
                Case "Qty"
                    column.HeaderText = "條碼數量"
                    column.DisplayIndex = 6
                Case "Sum"
                    column.HeaderText = "包裝數量"
                    column.DisplayIndex = 7
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()
        Label4.Text = DGV2.RowCount
    End Sub

    Private Sub LoadDGV3()

        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If DGV1.CurrentRow.Cells("ManSerNum").Value = "Y" Then

                sql = "SELECT T0.U_M2,Count(T0.U_M2) as 'Qty' FROM OSRN T0 left join OSRQ T1 on T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.itemcode = T2.itemcode where T1.Quantity > 0 and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' Group By T0.U_M2 "

            ElseIf DGV1.CurrentRow.Cells("ManBtchNum").Value = "Y" Then

                sql = "SELECT T0.U_M2,Count(T0.U_M2) as 'Qty',SUM(T1.Quantity) as 'Sum' FROM OBTN T0 left join OBTQ T1 on T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber left join OITM T2 ON T0.itemcode = T2.itemcode where T1.Quantity > 0 and T0.ItemCode = '" & DGV1.CurrentRow.Cells("ItemCode").Value & "' Group By T0.U_M2 "

            Else
                Exit Sub
            End If        

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            DGV3.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        setDGV3Display()     '設定dgvSourceList顯示格式
    End Sub

    Private Sub setDGV3Display()

        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True
            Select Case column.Name
                Case "U_M2"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 0
                Case "Qty"
                    column.HeaderText = "條碼數量"
                    column.DisplayIndex = 1
                Case "Sum"
                    column.HeaderText = "包裝數量"
                    column.DisplayIndex = 2
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV3.AutoResizeColumns()
        Label13.Text = DGV3.RowCount
    End Sub

    Private Sub toExcBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toExcBtn.Click
        DataToExcel(DGV1, "")
    End Sub





    Private Sub 查詢草稿_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢草稿.Click
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("未選取查詢項目", 48, "警告")
            ComboBox1.Focus()
            Exit Sub
        End If

        查詢文件草稿單號()

    End Sub

    Private Sub 查詢文件草稿單號()
        If DGV5.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV5").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn


        '1:領料出庫, C0= 2:銷售出庫, 3:存貨領用, C1= 4:寄庫品出庫, 5.委外代工出庫 ,6:採購入庫 ,7.生產調整        ''Select Case cobSelectType.SelectedIndex
        Select Case ComboBox1.SelectedIndex
            Case "0" ': TypeSelect = "2"    '銷售出庫
                sql = "     SELECT DISTINCT T0.[DocEntry] AS '草稿單號'"
                sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O' "
                sql += "  ORDER BY T0.[DocEntry] "

                'sql = "     SELECT DISTINCT T0.[DocEntry], T0.[DocNum], T0.[CardCode], T0.[CardName], T0.[DocDate], T0.[TaxDate], T0.[DocDueDate], T0.[U_attachment], T0.[U_CK01], T0.[U_Cnum], T0.[U_N1], T0.[U_N2], T0.[U_N3], T0.[U_CarDr1], T0.[U_CarDr2], T0.[U_CarDr3], T0.[U_Dlst], T0.[U_updnum], T0.[U_TpMoney], T0.[Comments], T0.[U_Dnum] "
                'sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                'sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O' "
                'sql += "  ORDER BY T0.[U_Dnum] DESC "
                'Case "1" : TypeSelect = "4"    '寄庫品出庫
                '    sql = "     SELECT DISTINCT T0.[DocEntry], T0.[DocNum], T0.[CardCode], T0.[CardName], T0.[DocDate], T0.[TaxDate], T0.[DocDueDate], T0.[U_attachment], T0.[U_CK01], T0.[U_Cnum], T0.[U_N1], T0.[U_N2], T0.[U_N3], T0.[U_CarDr1], T0.[U_CarDr2], T0.[U_CarDr3], T0.[U_Dlst], T0.[U_updnum], T0.[U_TpMoney], T0.[Comments], T0.[U_Dnum] "
                '    sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                '   'sql += "     WHERE T0.[ObjType] = '15' AND (T1.[WhsCode] = 'O01' OR T1.[WhsCode] = 'K05' OR T1.[WhsCode] = 'S05')      AND T0.[DocStatus] = 'O' "
                '    sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] IN ('O01','K05','S05')                                         AND T0.[DocStatus] = 'O' "
                '    sql += "  ORDER BY T0.[U_Dnum] DESC "
        End Select

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DGV5")
        DGV5.DataSource = ks1DataSetDGV.Tables("DGV5")

        DGV5.AutoResizeColumns()
        If DGV5.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 加入查詢列_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 加入查詢列.Click

        ''Dim DocEntry As String = ""
        'For i As Integer = 0 To DGV5.RowCount - 1   '以黃底顯示
        '    DrfNum.Text = DrfNum.Text + DGV5.Rows(i).Cells("草稿單號").Value
        '    'If DGV5.Rows(i).Cells("預出數量").Value <> DGV5.Rows(i).Cells("出庫數量").Value Then
        '    '    DGV5.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
        '    'DocEntry += 0 + 1
        '    'End If
        'Next



        For Each oRow As DataGridViewRow In DGV5.SelectedRows

            If DrfNum.Text = "" Then
                DrfNum.Text = DrfNum.Text + Format(oRow.Cells("草稿單號").Value, "")
            Else
                DrfNum.Text = DrfNum.Text + "," + Format(oRow.Cells("草稿單號").Value, "")
            End If

        Next






    End Sub

    Private Sub 清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除.Click
        DrfNum.Text = ""
    End Sub


    Private Sub 查庫位_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查庫位.Click

        If DGV2.RowCount = 0 Then
            Exit Sub
        End If

        Dim UM2 As String
        UM2 = Format(DGV2.CurrentRow.Cells("儲位").Value, "")

        If UM2 = "" Then
            MsgBox("請選擇儲位")
            Exit Sub
        End If



        查單庫位.MdiParent = MainForm
        查單庫位.UM2s.Text = UM2
        查單庫位.Show()

    End Sub


End Class