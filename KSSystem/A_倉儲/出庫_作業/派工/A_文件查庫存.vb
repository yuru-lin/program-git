Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class A_文件查庫存   '營業發貨及生產領料
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim TypeSelect As String
    Dim DrfNums As String = ""
    Dim DrfNums2 As String = ""
    Dim 查品項s As Integer = 0

    Private Sub A_文件查庫存_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
        ComboBox1.SelectedIndex = 0

    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click

        DrfNum.Text = ""

        For Each oRow As DataGridViewRow In DGV5.SelectedRows

            If DrfNum.Text = "" Then
                DrfNum.Text = DrfNum.Text + Format(oRow.Cells("草稿單號").Value, "")
            Else
                DrfNum.Text = DrfNum.Text + "," + Format(oRow.Cells("草稿單號").Value, "")
            End If

        Next

        If DrfNum.Text = "" Then
            MsgBox("請輸入草稿編號")
            Exit Sub
        End If

        DrfNums = Format(Replace(DrfNum.Text, ",", "','"), "")

        查品項s = 1

        查品項()

    End Sub

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn2.Click

        If DGV5.RowCount = 0 Then
            MsgBox("未查詢草稿單號!查!", 16, "錯誤")
            Exit Sub
        End If

        DrfNum.Text = ""
        DrfNum.Text = Format(DGV5.CurrentRow.Cells("草稿單號").Value, "")
        DrfNums = Format(DGV5.CurrentRow.Cells("草稿單號").Value, "")

        If DrfNums = "" Then
            MsgBox("請選擇草稿編號")
            Exit Sub
        End If

        查品項s = 2

        查品項()

    End Sub

    Private Sub 手工查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 手工查詢.Click

        DrfNums = DrfNum.Text

        If DrfNums = "" Then
            MsgBox("請選擇草稿編號")
            Exit Sub
        End If

        DrfNums = Format(Replace(DrfNum.Text, ",", "','"), "")

        查品項s = 1

        查品項()
    End Sub



    Private Sub 查品項()

        'If DGV1.RowCount > 0 Then
        '    ks1DataSetDGV.Tables("DGV1").Clear()
        'End If

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            Select Case 查品項s
                Case 1
                    sql = " SELECT '' AS 'LineNum', CASE WHEN T2.[ManSerNum] = 'Y' THEN '序號' ELSE CASE WHEN T2.[ManBtchNum] ='Y' THEN '批次' ELSE '' END END AS '別類', T1.[ItemCode], T1.[Dscription], dbo.getRoundN(SUM(T1.[Quantity]),0) AS 'Quantity', dbo.getRoundN(T2.[OnHand],0) AS 'OnHand', '' AS '儲位' "
                    sql += "  FROM [ODRF] T0 INNER JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                    sql += "                 INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
                    sql += " WHERE T0.[DocEntry] IN ('" & DrfNums & "') AND (T2.[ManSerNum] = 'Y' OR T2.[ManBtchNum] ='Y') "
                    sql += " GROUP BY T1.[LineNum], T1.[ItemCode], T1.[Dscription], T2.[OnHand], T2.[ManSerNum], T2.[ManBtchNum] "
                    sql += " ORDER BY 1 "
                Case 2
                    sql = " SELECT T1.[LineNum], CASE WHEN T2.[ManSerNum] = 'Y' THEN '序號' ELSE CASE WHEN T2.[ManBtchNum] ='Y' THEN '批次' ELSE '' END END AS '別類', T1.[ItemCode], T1.[Dscription], dbo.getRoundN(SUM(T1.[Quantity]),0) AS 'Quantity', dbo.getRoundN(T2.[OnHand],0) AS 'OnHand', '' AS '儲位' "
                    sql += "  FROM [ODRF] T0 INNER JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                    sql += "                 INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
                    sql += " WHERE T0.[DocEntry] = '" & DrfNums & "' AND (T2.[ManSerNum] = 'Y' OR T2.[ManBtchNum] ='Y') "
                    sql += " GROUP BY T1.[LineNum], T1.[ItemCode], T1.[Dscription], T2.[OnHand], T2.[ManSerNum], T2.[ManBtchNum] "
                    sql += " ORDER BY 1 "
            End Select

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            DGV1.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        setdgvSourceMainDisplay2()

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
                Case "別類"
                    column.HeaderText = "別類"
                    column.DisplayIndex = 1
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 2
                Case "Dscription"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 3
                Case "Quantity"
                    column.HeaderText = "營業出貨"
                    column.DisplayIndex = 4
                Case "OnHand"
                    column.HeaderText = "庫存量"
                    column.DisplayIndex = 5
                Case "儲位"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.AutoResizeColumns()
        Label9.Text = DGV1.RowCount
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick    ''建立生產明細單
        If DGV1.RowCount = 0 Then : Exit Sub : End If
        查庫存()
    End Sub

    Private Sub 查庫存()
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = " DECLARE @FromDate DateTime "
            SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            SQLCmd.CommandText += "DECLARE @ItemCode varchar(20) "
            SQLCmd.CommandText += "SET NOCOUNT ON "
            SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @ItemCode = '" & Format(DGV1.CurrentRow.Cells("ItemCode").Value, "") & "' "

            Select Case DGV1.CurrentRow.Cells("別類").Value
                Case "序號"
                    SQLCmd.CommandText += "   SELECT '生鮮' AS'類別', TX.[存編], TX.[品名], TX.[倉庫], ISNULL(TX.[儲位],'') AS '儲位', SUM(ISNULL(TX.[數量],0)) AS '數量', TX.[單位], SUM(ISNULL(TX.[重量],0)) AS '重量', "
                    SQLCmd.CommandText += "          ISNULL(TX.[生產日期],'') AS '生產日期', ISNULL(TX.[有效日期],'') AS '有效日期', ISNULL(TX.[天數],'') AS '天數', ISNULL(CAST(CASE WHEN DATEDIFF(DAY,GETDATE(),TX.[有效日期])+1 Between '0' AND '90' THEN DATEDIFF(DAY,GETDATE(),TX.[有效日期])+1 END AS NVARCHAR(5)),'') AS '剩餘天數', "
                    SQLCmd.CommandText += "          TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK], SUM(ISNULL(TX.[數量2],0)) AS '2號庫數量', SUM(ISNULL(TX.[重量2],0)) AS '2號庫重量' "
                    SQLCmd.CommandText += "     FROM ( "
                    SQLCmd.CommandText += "           SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[WhsCode] AS '倉庫', T0.[U_M2] AS '儲位', "
                    SQLCmd.CommandText += "                  T0.[Quantity] AS '數量', T0.[InvntryUom] as '單位', T0.[U_M1] AS '重量',  "
                    SQLCmd.CommandText += "                  T0.[MnfDate] AS '生產日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.[MnfDate], getdate())+1  AS '天數', T0.[DistNumber] AS '條碼', "
                    SQLCmd.CommandText += "                  ISNULL(T0.[U_M8],'') AS '製造單號', ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
                    SQLCmd.CommandText += "                  CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[U_M1] END AS '重量2' "
                    SQLCmd.CommandText += "             FROM ( "
                    SQLCmd.CommandText += "                   SELECT T0.[ItemCode] AS 'ItemCode', T2.[ItemName] AS 'ItemName', T1.[WhsCode] AS 'WhsCode', T0.[U_M2] AS 'U_M2', "
                    SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T1.[Quantity],0) AS INT))           AS 'Quantity', T2.[InvntryUom] as 'InvntryUom', "
                    SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T0.[U_M1],0)     AS NUMERIC(19,2))) AS 'U_M1', CONVERT(CHAR(10),T0.[MnfDate], 120) AS 'MnfDate',  "
                    SQLCmd.CommandText += "                          CONVERT(CHAR(10),T0.[ExpDate], 120) AS 'ExpDate', T0.[DistNumber], CAST(T0.[U_M8] AS NVARCHAR(12)) AS 'U_M8' "
                    SQLCmd.CommandText += "                     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[DistNumber] NOT LIKE '2013%' "
                    SQLCmd.CommandText += "                                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "
                    SQLCmd.CommandText += "                    WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T0.[MnfDate] Between @FromDate AND @ToDate ) "
                    SQLCmd.CommandText += "                 GROUP BY T0.[ItemCode], T2.[ItemName], T1.[WhsCode], T0.[U_M2], T2.[InvntryUom], T0.[MnfDate], T0.[ExpDate], T0.[DistNumber], T0.[U_M8] "
                    SQLCmd.CommandText += "                  ) T0 "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
                    SQLCmd.CommandText += "        GROUP BY T0.[ItemCode], T0.[ItemName], T0.[WhsCode], T0.[U_M2], T0.[InvntryUom], T0.[MnfDate], T0.[ExpDate], T0.[DistNumber], T0.[U_M8], T0.[Quantity], T0.[U_M1], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto] "
                    SQLCmd.CommandText += "          ) TX "
                    SQLCmd.CommandText += "GROUP BY TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], TX.[單位], TX.[生產日期], TX.[有效日期], TX.[天數], TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK] "
                    SQLCmd.CommandText += "ORDER BY 5, 2"

                Case "批次"
                    SQLCmd.CommandText += "   SELECT '調理' AS'類別', TX.[存編], TX.[品名], TX.[倉庫], ISNULL(TX.[儲位],'') AS '儲位', SUM(ISNULL(TX.[數量],0)) AS '數量', TX.[單位], SUM(ISNULL(TX.[重量],0)) AS '重量', "
                    SQLCmd.CommandText += "          ISNULL(TX.[生產日期],'') AS '生產日期', ISNULL(TX.[有效日期],'') AS '有效日期', ISNULL(TX.[天數],'') AS '天數', ISNULL(CAST(CASE WHEN DATEDIFF(DAY,GETDATE(),TX.[有效日期])+1 Between '0' AND '90' THEN DATEDIFF(DAY,GETDATE(),TX.[有效日期])+1 END AS NVARCHAR(5)),'') AS '剩餘天數', "
                    SQLCmd.CommandText += "          TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK], SUM(ISNULL(TX.[數量2],0)) AS '2號庫數量', SUM(ISNULL(TX.[重量2],0)) AS '2號庫重量' "
                    SQLCmd.CommandText += "     FROM ( "
                    SQLCmd.CommandText += "           SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[WhsCode] AS '倉庫', T0.[U_M2] AS '儲位', "
                    SQLCmd.CommandText += "                  T0.[Quantity] AS '數量', T0.[InvntryUom] as '單位', T0.[U_M1] AS '重量', "
                    SQLCmd.CommandText += "                  T0.[MnfDate] AS '生產日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.[MnfDate], getdate())+1  AS '天數', T0.[DistNumber] AS '條碼', "
                    SQLCmd.CommandText += "                  ISNULL(T0.[U_M8],'') AS '製造單號', '' AS 'G1', '' AS 'G2', '' AS 'G_OK', "
                    SQLCmd.CommandText += "                  CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[U_M1] END AS '重量2' "
                    SQLCmd.CommandText += "             FROM ( "
                    SQLCmd.CommandText += "                   SELECT T0.[ItemCode] AS 'ItemCode', T2.[ItemName] AS 'ItemName', T1.[WhsCode] AS 'WhsCode', T0.[U_M2] AS 'U_M2', "
                    SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T1.[Quantity],0) AS INT))           AS 'Quantity', T2.[InvntryUom] as 'InvntryUom', "
                    SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T0.[U_M1],0)     AS NUMERIC(19,2))) AS 'U_M1', CONVERT(CHAR(10),T0.[MnfDate], 120) AS 'MnfDate',  "
                    SQLCmd.CommandText += "                          CONVERT(CHAR(10),T0.[ExpDate], 120) AS 'ExpDate', T0.[DistNumber], CAST(T0.[U_M8] AS NVARCHAR(12)) AS 'U_M8' "
                    SQLCmd.CommandText += "                     FROM [OBTN] T0 INNER JOIN [OBTQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[DistNumber] NOT LIKE '2013%' "
                    SQLCmd.CommandText += "                                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "
                    SQLCmd.CommandText += "                    WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T0.[MnfDate] Between @FromDate AND @ToDate ) AND T1.[WhsCode] IN ('S01','S04','S06','T02') "
                    SQLCmd.CommandText += "                 GROUP BY T0.[ItemCode], T2.[ItemName], T1.[WhsCode], T0.[U_M2], T2.[InvntryUom], T0.[MnfDate], T0.[ExpDate], T0.[DistNumber], T0.[U_M8] "
                    SQLCmd.CommandText += "                  ) T0 LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
                    SQLCmd.CommandText += "        GROUP BY T0.[ItemCode], T0.[ItemName], T0.[WhsCode], T0.[U_M2], T0.[InvntryUom], T0.[MnfDate], T0.[ExpDate], T0.[DistNumber], T0.[U_M8], T0.[Quantity], T0.[U_M1], T7.[InvSto] "
                    SQLCmd.CommandText += "          ) TX "
                    SQLCmd.CommandText += "GROUP BY TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], TX.[單位], TX.[生產日期], TX.[有效日期], TX.[天數], TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK] "
                    SQLCmd.CommandText += "ORDER BY 5, 2"
            End Select

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            DGV2異常檢查()
            DGV2.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV2_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV2.Sorted
        DGV2異常檢查()
        DGV2.AutoResizeColumns()
    End Sub

    Private Sub DGV2異常檢查()
        For i As Integer = 0 To DGV2.RowCount - 1   '以黃底顯示
            If DGV2.Rows(i).Cells("有效日期").Value <= Format(Now(), "yyyy-MM-dd") Then : DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Red : End If
        Next
        For i As Integer = 0 To DGV2.RowCount - 1   '以黃底顯示
            If DGV2.Rows(i).Cells("剩餘天數").Value <> "" Then : DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow : End If
        Next

    End Sub

    Private Sub toExcBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toExcBtn.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub 查詢草稿_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢草稿.Click
        If ComboBox1.SelectedIndex = -1 Then : MsgBox("未選取查詢項目", 48, "警告") : ComboBox1.Focus() : Exit Sub : End If
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
                sql = "     SELECT DISTINCT T0.[DocEntry] AS '草稿單號' "
                sql += "      FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
                sql += "     WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.[DocStatus] = 'O' "
                sql += "  ORDER BY T0.[DocEntry] "
        End Select

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DGV5")
        DGV5.DataSource = ks1DataSetDGV.Tables("DGV5")

        DGV5.AutoResizeColumns()
        If DGV5.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 清除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除.Click
        DrfNum.Text = ""
    End Sub

    Private Sub 查庫位_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查庫位.Click

        Dim UM2 As String : UM2 = Format(DGV2.CurrentRow.Cells("儲位").Value, "")
        If UM2 = "" Then : MsgBox("請選擇儲位") : Exit Sub : End If
        查單庫位.MdiParent = MainForm
        查單庫位.UM2s.Text = UM2
        查單庫位.Show()

    End Sub

    Private Sub 存入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存入.Click

        For Each oRow1 As DataGridViewRow In DGV2.SelectedRows
            If oRow1.DefaultCellStyle.BackColor = Color.Red Then : MsgBox("有不可出貨品項") : Exit Sub : End If
        Next

        For Each oRow As DataGridViewRow In DGV2.SelectedRows
            If TextBox1.Text = "" Then
                TextBox1.Text = TextBox1.Text + "儲 " + Format(oRow.Cells("儲位").Value, "") + " 數 " + Format(oRow.Cells("數量").Value, "##0") + " 生 " + Format(oRow.Cells("生產日期").Value, "") + " 有 " + Format(oRow.Cells("有效日期").Value, "")
            Else
                TextBox1.Text = TextBox1.Text + "," + vbCrLf + "儲 " + Format(oRow.Cells("儲位").Value, "") + " 數 " + Format(oRow.Cells("數量").Value, "##0") + " 生 " + Format(oRow.Cells("生產日期").Value, "") + " 有 " + Format(oRow.Cells("有效日期").Value, "") '+ vbCrLf
            End If

        Next

        PUpdateItemDetail()

    End Sub

    Private Sub PUpdateItemDetail()
        'PDGV3.CurrentRow.Cells("列號").Value = LineNum.Text
        DGV1.CurrentRow.Cells("儲位").Value = ""
        DGV1.CurrentRow.Cells("儲位").Value = TextBox1.Text

        'PDGV3.CurrentRow.Cells("客戶").Value = P2CardName.Text
        'PDGV3.CurrentRow.Cells("存編").Value = P2ItemCode.Text
        'PDGV3.CurrentRow.Cells("品名").Value = P2ItemName.Text
        'PDGV3.CurrentRow.Cells("來源").Value = P2Source.Text
        'PDGV3.CurrentRow.Cells("數量").Value = P2Quantity.Text

    End Sub

End Class

