Imports System
Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServerCe.Client
Imports System.Net.Dns

Public Class PDA同步V103    '20150609
    'V102-改寫回傳方式
    Dim DataAdapter1 As SqlDataAdapter
    Dim PDA條碼明細 As DataSet = New DataSet
    Dim PDA儲位統計 As DataSet = New DataSet

    '暫存資料庫名
    Dim SyncPDA1 As String = ""
    Dim SyncPDA2 As String = ""
    Dim SyncPDA3 As String = ""

    Dim Cnt0 As Integer = 0     '未入庫數
    Dim Cnt1 As Integer = 0     '已出庫數
    Dim Cnt2 As Integer = 0     '作廢數量
    Dim Cnt3 As Integer = 0     '查無條碼
    Dim Cnt4 As Integer = 0     '重複條碼

    Dim 入庫代碼 As String = ""     'PDA入庫代碼 '11','12' = 電宰及加工入庫 : '13' = 採購入庫

    Dim DGV1選擇 As String = "Y"
    Dim 同步檢查 As String = "N"

    '記算時間
    Dim dteStart As DateTime

    Private Sub PDA同步V103_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        文字初始化()
        DGV初始化()

        SyncPDA1 = Format(Replace(Replace("#SyncPDAtmp1" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '初始
        SyncPDA2 = Format(Replace(Replace("#SyncPDAtmp2" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '整合
        SyncPDA3 = Format(Replace(Replace("#SyncPDAtmp3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '結果
    End Sub

    Private Sub Bu上頁_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu上頁.Click
        清除暫存()
        Select Case La作業.Text
            Case "入庫"
                生產入庫V101.Show()
                生產入庫V101.查詢製單.PerformClick()
            Case "出庫"
                出庫作業V001.Show()
                出庫作業V001.單據條碼T1.PerformClick()
            Case "單據入庫"
                出庫作業V001.Show()
                出庫作業V001.單據條碼T1.PerformClick()
        End Select
        Me.Close()
    End Sub

    Private Sub 清除暫存()
        Dim SQLQuery As String = ""
        SQLQuery = "    IF (OBJECT_ID('tempdb.." & SyncPDA1 & "') IS NOT NULL)  DROP TABLE " & SyncPDA1 & " "
        SQLQuery += "   IF (OBJECT_ID('tempdb.." & SyncPDA2 & "') IS NOT NULL)  DROP TABLE " & SyncPDA2 & " "
        SQLQuery += "   IF (OBJECT_ID('tempdb.." & SyncPDA3 & "') IS NOT NULL)  DROP TABLE " & SyncPDA3 & " "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 文字初始化()
        La數量.Text = "0筆"
        La入庫.Text = "0筆"
        La出庫.Text = "0筆"
        La作廢.Text = "0筆"
        La異常.Text = "0筆"
        La重複.Text = "0筆"
        La時間.Text = "查詢時間 0.00 秒"

        CB作業別.Items.Clear()
        CB顯示鮮享.Visible = False

        Select Case La作業.Text
            Case "入庫"
                CB作業別.Visible = True
                Bu更換.Visible = True
                Bu勾選.Visible = False
                CB作業別.Items.Add("")
                CB作業別.Items.Add("11.電宰入庫")
                CB作業別.Items.Add("12.加工入庫")

            Case "出庫"
                CB作業別.Visible = False
                Bu更換.Visible = False
                Bu勾選.Visible = True
                CB作業別.Items.Add("")
                'CB作業別.Items.Add("")
                'CB作業別.Items.Add("")
                CB顯示鮮享.Visible = True

            Case "單據入庫"
                CB作業別.Visible = False
                Bu更換.Visible = False
                Bu勾選.Visible = False
                CB作業別.Items.Add("")
                'CB作業別.Items.Add("")
                'CB作業別.Items.Add("")

        End Select

    End Sub

    Private Sub DGV初始化()
        'RowHeadersVisible = 移除列首行, AllowUserToResizeRows = 停用列調整, MultiSelect = 停用多列選擇
        DGV1.RowHeadersVisible = False : DGV1.AllowUserToResizeRows = False : DGV1.MultiSelect = False
        DGV2.RowHeadersVisible = False : DGV2.AllowUserToResizeRows = False : DGV2.MultiSelect = False
        DGV3.RowHeadersVisible = False : DGV3.AllowUserToResizeRows = False : DGV3.MultiSelect = False
    End Sub

    Private Sub Bu讀取_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu讀取.Click
        dteStart = Now  ''...要計算執行時間的程式區段 ...

        清除暫存()

        Select Case La作業.Text
            Case "入庫"
                '入庫代碼 = "'11','12'"
                讀取條碼入庫() : DGV1選擇 = "N"
                讀取條碼儲位()
                DGV1_入庫檢查資料()
            Case "出庫"
                讀取條碼出庫() : DGV1選擇 = "N"
                DGV1_出庫檢查資料()
            Case "單據入庫"
                '入庫代碼 = "'13'"
                讀取條碼入庫()
                讀取條碼儲位()
                DGV1_入庫檢查資料()
        End Select

        Dim 執行時間s As String = "0.00"
        Dim 執行時間a As TimeSpan = Now.Subtract(dteStart)
        執行時間s = "查詢時間 " & Format(執行時間a.TotalSeconds, "###0.00" & " 秒")
        La時間.Text = 執行時間s

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 讀取條碼入庫()
        If DGV1.RowCount > 0 Then : PDA條碼明細.Tables("PDADGV1").Clear() : End If
        Dim SQLQuery As String = ""
        SQLQuery = "     IF (OBJECT_ID('tempdb.." & SyncPDA1 & "') IS NOT NULL)  DROP TABLE " & SyncPDA1 & " "
        SQLQuery += "    SELECT * INTO " & SyncPDA1 & " FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE LEFT([PDA02],2) IN ('11','12','13') AND [PDA06] = '2' "

        Select Case La作業.Text
            Case "入庫"
                SQLQuery += "    IF (OBJECT_ID('tempdb.." & SyncPDA2 & "') IS NOT NULL)  DROP TABLE " & SyncPDA2 & " "
                SQLQuery += "    SELECT * INTO " & SyncPDA2 & " FROM ( "
                SQLQuery += "    SELECT DISTINCT '11' AS 'PDA02', T1.[DistNumber] "
                SQLQuery += "      FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLQuery += "                     INNER JOIN " & SyncPDA1 & " T3 ON T1.[DistNumber] = T3.[PDA03] "
                'SQLQuery += "                     INNER JOIN [OITM]           T4 ON T1.[ItemCode]   = T4.[ItemCode] AND T2.[WhsCode] = T4.[DfltWH] "
                SQLQuery += "     WHERE LEFT(T3.[PDA02],2) = '11' "
                SQLQuery += "    UNION ALL "
                SQLQuery += "    SELECT DISTINCT '12' AS 'PDA02', T1.[DistNumber] "
                SQLQuery += "      FROM [OBTN] T1 INNER JOIN [OBTQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLQuery += "                     INNER JOIN " & SyncPDA1 & " T3 ON T1.[DistNumber] = T3.[PDA03] "
                'SQLQuery += "                     INNER JOIN [OITM]           T4 ON T1.[ItemCode]   = T4.[ItemCode] AND T4.[DfltWH] = T2.[WhsCode] "
                SQLQuery += "     WHERE LEFT(T3.[PDA02],2) = '12' ) T0 "

                SQLQuery += "    IF (OBJECT_ID('tempdb.." & SyncPDA3 & "') IS NOT NULL)  DROP TABLE " & SyncPDA3 & " "
                SQLQuery += "    SELECT * INTO " & SyncPDA3 & " FROM ("
                SQLQuery += "    SELECT P0.[PDA01] AS 'ID', P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
                SQLQuery += "           CASE ISNULL(P1.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS '狀態', "
                SQLQuery += "           CASE WHEN P3.[FI103] IN ('1','2','3','4') THEN '正常'   ELSE CASE WHEN P3.[FI103] IN ('5','6')  THEN '作廢'   ELSE '異常' END END AS '狀態2' "
                SQLQuery += "      FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & SyncPDA2 & " WHERE [PDA02] = '11') P1 ON P0.[PDA03] = P1.[DistNumber] "
                SQLQuery += "                                                LEFT  JOIN [@FinishItem1]                                         P3 ON P0.[PDA03] = P3.[FI106] "
                SQLQuery += "     WHERE LEFT(P0.[PDA02],2) = '11' AND P0.[PDA06] = '2' "
                SQLQuery += "    UNION ALL "
                SQLQuery += "    SELECT P0.[PDA01] AS 'ID', P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
                SQLQuery += "           CASE ISNULL(P2.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS '狀態', "
                SQLQuery += "           CASE WHEN P3.[FI103] IN ('1','2','3','4') THEN '正常'   ELSE CASE WHEN P3.[FI103] IN ('5','6')  THEN '作廢'   ELSE '異常' END END AS '狀態2' "
                SQLQuery += "      FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & SyncPDA2 & " WHERE [PDA02] = '12') P2 ON P0.[PDA03] = P2.[DistNumber] "
                SQLQuery += "                                                LEFT  JOIN [@FinishItem2]                                         P3 ON P0.[PDA03] = P3.[FI106] "
                SQLQuery += "     WHERE LEFT(P0.[PDA02],2) = '12' AND P0.[PDA06] = '2' ) T1 "

            Case "單據入庫"         '目前限序號入庫
                SQLQuery += "    IF (OBJECT_ID('tempdb.." & SyncPDA2 & "') IS NOT NULL)  DROP TABLE " & SyncPDA2 & " "
                SQLQuery += "    SELECT * INTO " & SyncPDA2 & " FROM ( "
                SQLQuery += "    SELECT DISTINCT '11' AS 'PDA02', T1.[DistNumber] "
                SQLQuery += "      FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                SQLQuery += "                     INNER JOIN " & SyncPDA1 & " T3 ON T1.[DistNumber] = T3.[PDA03] "
                SQLQuery += "     WHERE LEFT(T3.[PDA02],2) = '13' ) T0  "

                SQLQuery += "    IF (OBJECT_ID('tempdb.." & SyncPDA3 & "') IS NOT NULL)  DROP TABLE " & SyncPDA3 & " "
                SQLQuery += "    SELECT * INTO " & SyncPDA3 & " FROM ("
                SQLQuery += "    SELECT P0.[PDA01] AS 'ID', P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
                SQLQuery += "           CASE ISNULL(P1.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS '狀態', "
                SQLQuery += "           CASE WHEN P3.[FI103] IN ('1','2','3','4') THEN '正常'   ELSE CASE WHEN P3.[FI103] IN ('5','6')  THEN '作廢'   ELSE '異常' END END AS '狀態2' "
                SQLQuery += "      FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & SyncPDA2 & " WHERE [PDA02] = '11') P1 ON P0.[PDA03] = P1.[DistNumber] "
                SQLQuery += "                                                LEFT  JOIN [@FinishItem1]                                         P3 ON P0.[PDA03] = P3.[FI106] "
                SQLQuery += "     WHERE LEFT(P0.[PDA02],2) = '13' AND P0.[PDA06] = '2' ) T1  "
        End Select

                SQLQuery += "    SELECT * FROM " & SyncPDA3 & " ORDER BY 2, 1 "

                Dim DBConn As SqlConnection = Login.DBConn
                Try
                    DataAdapter1 = New SqlDataAdapter(SQLQuery, DBConn)
                    DataAdapter1.Fill(PDA條碼明細, "PDADGV1")
                    DGV1.DataSource = PDA條碼明細.Tables("PDADGV1")
                Catch ex As Exception
                    MsgBox("PDA條碼明細：" & ex.Message)
                    Exit Sub
                End Try

                If DGV1選擇 = "Y" Then
                    DGV1View選擇()
                End If

                For Each column As DataGridViewColumn In DGV1.Columns
                    column.Visible = True
                    Select Case column.Name
                        Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                        Case "PDA02" : column.HeaderText = "作業單別" : column.DisplayIndex = 1 : column.Visible = True : column.ReadOnly = True
                        Case "PDA03" : column.HeaderText = "條　　碼" : column.DisplayIndex = 2 : column.Visible = True : column.ReadOnly = True
                        Case "PDA04" : column.HeaderText = "儲　　位" : column.DisplayIndex = 3 : column.Visible = True : column.ReadOnly = True
                        Case "PDA05" : column.HeaderText = "作業日期" : column.DisplayIndex = 4 : column.Visible = True : column.ReadOnly = True
                        Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 5 : column.Visible = True : column.ReadOnly = True     '非資料表內
                        Case "狀態2" : column.HeaderText = "狀態2" : column.DisplayIndex = 6 : column.Visible = True : column.ReadOnly = True   '非資料表內
                        Case Else
                            column.Visible = False
                    End Select
                Next
                'DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1View選擇()
        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.Name = "選擇"
        checkBoxColumn.Width = 30
        DGV1.Columns.Insert(0, checkBoxColumn)

    End Sub

    Private Sub 讀取條碼儲位()
        If DGV3.RowCount > 0 Then : PDA儲位統計.Tables("PDADGV3").Clear() : End If
        Dim SQLQuery As String = ""
        'SQLQuery = "  SELECT [PDA04], COUNT([PDA04]) AS 'COUNT' FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE [PDA06] = '2' AND LEFT([PDA02],2) IN ('11','12') GROUP BY [PDA04] "      '修改數據資料增加出庫作業用
        SQLQuery = "  SELECT [PDA04], COUNT([PDA04]) AS 'COUNT' FROM " & SyncPDA3 & " GROUP BY [PDA04] "      '修改數據資料增加出庫作業用

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapter1 = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapter1.Fill(PDA儲位統計, "PDADGV3")
            DGV3.DataSource = PDA儲位統計.Tables("PDADGV3")
        Catch ex As Exception
            MsgBox("PDA儲位統計：" & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In DGV3.Columns
            column.Visible = True
            Select Case column.Name
                Case "PDA04" : column.HeaderText = "儲　　位" : column.DisplayIndex = 0 : column.Visible = True
                Case "COUNT" : column.HeaderText = "數　　量" : column.DisplayIndex = 1 : column.Visible = True
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV3.AutoResizeColumns()

    End Sub

    Private Sub 讀取條碼出庫()
        If DGV1.RowCount > 0 Then : PDA條碼明細.Tables("PDADGV2").Clear() : End If
        Dim SQLQuery As String = ""
        SQLQuery = "    IF (OBJECT_ID('tempdb.." & SyncPDA1 & "') IS NOT NULL) DROP TABLE " & SyncPDA1 & " "
        SQLQuery += "   SELECT TX.[PDA01] AS 'ID', TX.[PDA02] AS 'ID2', TX.[PDA04] AS 'DocEntry', TX.[PDA03] AS 'DistNumber', TX.[PDA09] AS 'Quantity', TX.[PDA10] AS 'Gift' INTO " & SyncPDA1 & " "
        SQLQuery += "     FROM [KaiShingPlug].[dbo].[PDA_InData] TX "
        SQLQuery += "    WHERE TX.[PDA06] = '2' AND LEFT(TX.[PDA02],2) IN ('21','22','24','31','32','41','42','51','52') "
        If CB顯示鮮享.Checked = False Then
            SQLQuery += "  AND LEFT(TX.[PDA03],2) <> 'AA' "
        End If

        SQLQuery += "   IF (OBJECT_ID('tempdb.." & SyncPDA2 & "') IS NOT NULL) DROP TABLE " & SyncPDA2 & " "
        SQLQuery += "   SELECT * INTO " & SyncPDA2 & " FROM ( "
        SQLQuery += "         SELECT 'S' AS '管理', T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], ISNULL(T2.[Quantity],0) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
        SQLQuery += "           FROM [OSRN] T1 INNER JOIN [OSRQ] T2           ON T1.[ItemCode]   = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
        SQLQuery += "                          INNER JOIN [OITM] T3           ON T1.[ItemCode]   = T3.[ItemCode] "
        SQLQuery += "                          INNER JOIN " & SyncPDA1 & " T4 ON T1.[DistNumber] = T4.[DistNumber] "
        SQLQuery += "   UNION ALL "
        SQLQuery += "         SELECT 'B' AS '管理', T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], ISNULL(T2.[Quantity],0) AS 'Quantity', T1.[U_M1], T1.[U_M8], T1.[MnfDate] "
        SQLQuery += "           FROM [OBTN] T1 INNER JOIN [OBTQ] T2           ON T1.[ItemCode]   = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
        SQLQuery += "                          INNER JOIN [OITM] T3           ON T1.[ItemCode]   = T3.[ItemCode] "
        SQLQuery += "                          INNER JOIN " & SyncPDA1 & " T4 ON T1.[DistNumber] = T4.[DistNumber]) T0 "

        SQLQuery += "   IF (OBJECT_ID('tempdb.." & SyncPDA3 & "') IS NOT NULL) DROP TABLE " & SyncPDA3 & " "
        SQLQuery += "   SELECT T0.[ID2] AS '作業別類', T0.[DocEntry] AS '單號', T0.[DistNumber] AS '條碼', T1.[ItemCode] AS '存編', T1.[ItemName] AS '品名', "
        SQLQuery += "         (CASE WHEN T1.[管理] = 'S' THEN CAST(ISNULL(T0.[Quantity],0) AS NUMERIC(10,4)) ELSE "
        SQLQuery += "          CASE WHEN T1.[管理] = 'B' AND  CAST(ISNULL(T0.[Quantity],0) AS NUMERIC(10,4)) = 0 THEN CAST(ISNULL(T1.[Quantity],0) AS NUMERIC(10,4)) ELSE CAST(ISNULL(T0.[Quantity],0) AS NUMERIC(10,4)) END END) AS '數量', "
        'SQLQuery += "          CAST(ISNULL(T0.[Quantity],0) AS NUMERIC(10,4)) AS '數量', "
        SQLQuery += "          CAST(ISNULL(T1.[Quantity],0) AS NUMERIC(10,4)) AS '庫存', (CASE WHEN T1.[管理] = 'S' THEN ISNULL(T1.[U_M1],'異常') ELSE CASE WHEN T1.[管理] = 'B' THEN ISNULL(T1.[U_M1],0) ELSE '異常' END END) AS '重量', "
        SQLQuery += "          T1.[U_M2] AS '儲位', T1.[MnfDate] AS '生產日期', T1.[U_M8] AS '製造單號', "
        SQLQuery += "         (CASE WHEN T1.[ItemCode] IS NULL THEN '未入庫' ELSE CASE WHEN T1.[Quantity]  = 0 THEN '出庫' ELSE CASE WHEN T1.[Quantity] >= 1 THEN '庫存' ELSE '不知' END END END) AS '狀態', "
        SQLQuery += "         (CASE WHEN T2.[狀態] = '1' THEN (CASE WHEN (T1.[管理] = 'B' OR T1.[管理] = 'F') THEN '否' ELSE '是' END) ELSE CASE WHEN T2.[狀態] = '0' THEN '否' END END) AS '重覆', "
        SQLQuery += "         (CASE WHEN ISNULL(T0.[Gift],0) = 1 THEN '銷售' ELSE CASE WHEN ISNULL(T0.[Gift],0) = 2 THEN '贈品' ELSE '不知' END END) AS '銷售', "
        SQLQuery += "          ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T1.[管理],'') AS '管理', T0.[ID], T0.[Gift], "

        SQLQuery += "         (CASE WHEN T1.[管理] = 'S'                                                                                       THEN '正常' ELSE "
        SQLQuery += "          CASE WHEN T1.[管理] = 'B' AND CAST(ISNULL(T0.[Quantity],0) AS NUMERIC(10,4)) = 0                                THEN '正常' ELSE "
        SQLQuery += "          CASE WHEN (CAST(ISNULL(T0.[Quantity],0) AS NUMERIC(10,4)) - CAST(ISNULL(T1.[Quantity],0) AS NUMERIC(10,4))) = 0 THEN '正常' ELSE '異常' END END END) AS '數量異常' "
        SQLQuery += "          INTO " & SyncPDA3 & " "
        SQLQuery += "     FROM [" & SyncPDA1 & "] T0 LEFT JOIN ( SELECT * FROM " & SyncPDA2 & ") T1 ON T0.[DistNumber] = T1.[DistNumber]"
        SQLQuery += "                                LEFT JOIN ( SELECT T0.[DistNumber], CASE WHEN COUNT(ISNULL(T0.[DistNumber],0)) > 1 THEN '1'  ELSE '0' END '狀態' "
        SQLQuery += "                                              FROM " & SyncPDA2 & " T0 GROUP BY T0.[DistNumber] ) T2 ON T0.[DistNumber] = T2.[DistNumber] "
        SQLQuery += "                          LEFT JOIN [z_format_G] T4 ON T1.[U_M8] = T4.[M_NO] "
        'SQLQuery += " WHERE T1.[Quantity] <> 0 "
        SQLQuery += " GROUP BY T1.[ItemCode], T1.[ItemName], T0.[Quantity], T1.[Quantity], T1.[MnfDate], T0.[DistNumber], T1.[U_M1], T1.[U_M2], T1.[U_M8], T4.[M_NO], T1.[管理], T0.[Gift], T2.[狀態], T0.[DocEntry], T0.[ID], T0.[ID2] "
        SQLQuery += " ORDER BY COUNT(T0.[DistNumber]) DESC ,T0.[DistNumber] "
        SQLQuery += "  SELECT * FROM " & SyncPDA3 & " "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapter1 = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapter1.Fill(PDA條碼明細, "PDADGV2")
            DGV1.DataSource = PDA條碼明細.Tables("PDADGV2")
        Catch ex As Exception
            MsgBox("PDA條碼明細：" & ex.Message)
            Exit Sub
        End Try

        If DGV1選擇 = "Y" Then
            DGV1View選擇()
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Width = 30 : column.Frozen = True : column.ReadOnly = False
                Case "作業別類" : column.HeaderText = "作業別類" : column.DisplayIndex = 1 : column.Frozen = True : column.ReadOnly = True
                Case "條碼" : column.HeaderText = "條碼" : column.DisplayIndex = 2 : column.Frozen = True : column.ReadOnly = True
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 3 : column.ReadOnly = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 4 : column.ReadOnly = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5 : column.ReadOnly = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 6 : column.ReadOnly = True
                Case "庫存" : column.HeaderText = "庫存" : column.DisplayIndex = 7 : column.ReadOnly = True
                Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 8 : column.ReadOnly = True
                Case "儲位" : column.HeaderText = "儲位" : column.DisplayIndex = 9 : column.ReadOnly = True
                Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 10 : column.ReadOnly = True
                Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 11 : column.ReadOnly = True
                Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 12 : column.ReadOnly = True
                Case "重覆" : column.HeaderText = "重覆" : column.DisplayIndex = 13 : column.ReadOnly = True
                Case "銷售" : column.HeaderText = "銷售" : column.DisplayIndex = 14 : column.ReadOnly = True
                Case "數量異常" : column.HeaderText = "數量異常" : column.DisplayIndex = 15 : column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
        'DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.Sorted
        Select Case La作業.Text
            Case "入庫"
                DGV1_入庫檢查資料()
            Case "出庫"
                DGV1_出庫檢查資料()
            Case "單據入庫"
                DGV1_入庫檢查資料()
        End Select
    End Sub

    Private Sub DGV1_入庫檢查資料()

        Cnt0 = 0 : Cnt1 = 0 : Cnt2 = 0 : Cnt3 = 0 : Cnt4 = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            Select Case DGV1.Rows(i).Cells("狀態").Value
                Case "已入庫"
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow  '以黃底顯示
                    Cnt0 += 0 + 1
            End Select
            Select Case DGV1.Rows(i).Cells("狀態2").Value
                Case "作廢"
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow  '以黃底顯示
                    Cnt2 += 0 + 1
                Case "異常"
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow  '以黃底顯示
                    Cnt3 += 0 + 1
            End Select
        Next

        DGV1.ClearSelection()
        La數量.Text = DGV1.RowCount & "筆 入庫條碼"
        La入庫.Text = Cnt0 & "筆"
        La出庫.Text = Cnt1 & "筆"
        La作廢.Text = Cnt2 & "筆"
        La異常.Text = Cnt3 & "筆"
        La重複.Text = Cnt4 & "筆"
        確認是否可同步()

    End Sub

    Private Sub DGV1_出庫檢查資料()

        Cnt0 = 0 : Cnt1 = 0 : Cnt2 = 0 : Cnt3 = 0 : Cnt4 = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            Select Case DGV1.Rows(i).Cells("狀態").Value
                Case "未入庫"
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow  '以黃底顯示
                    Cnt0 += 0 + 1
                Case "出庫"
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Red     '以紅底顯示
                    Cnt1 += 0 + 1
            End Select
        Next

        DGV1.ClearSelection()
        La數量.Text = DGV1.RowCount & "筆 出庫條碼"
        La入庫.Text = Cnt0 & "筆"
        La出庫.Text = Cnt1 & "筆"
        La作廢.Text = Cnt2 & "筆"
        La異常.Text = Cnt3 & "筆"
        La重複.Text = Cnt4 & "筆"
        確認是否可同步()

    End Sub

    Private Sub 確認是否可同步()
        If DGV1.RowCount <> 0 And Cnt0 = 0 And Cnt1 = 0 And Cnt2 = 0 And Cnt3 = 0 And Cnt4 = 0 Then
            Bu同步.Enabled = True
        Else
            Bu同步.Enabled = False
        End If

    End Sub

    Private Sub Bu勾選_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu勾選.Click
        Dim 勾選作業ID As String = "" : Dim 勾選條碼 As String = ""
        For Each oRow As DataGridViewRow In DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then : If 勾選作業ID = "" Then
                    勾選作業ID = 勾選作業ID + Format(oRow.Cells("ID").Value, "")
                    勾選條碼 = 勾選條碼 + Format(oRow.Cells("條碼").Value, "")
                Else
                    勾選作業ID = 勾選作業ID + "','" + Format(oRow.Cells("ID").Value, "")
                    勾選條碼 = 勾選條碼 + "','" + Format(oRow.Cells("條碼").Value, "")
                End If : End If
        Next
        If 勾選作業ID = "" Then : MsgBox("未選擇刪除條碼") : Exit Sub : End If
        'MsgBox(勾選作業ID)
        Dim oAns As Integer
        oAns = MsgBox("是否要刪除條碼?" & vbCrLf & "刪除條碼： " & 勾選條碼, MsgBoxStyle.YesNo, "確認刪除")
        If oAns = MsgBoxResult.Yes Then  'Yes執行區
            Dim SQLQueryAd As String = "" : Dim SQLQueryUp As String = ""
            SQLQueryAd = " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6' WHERE [PDA01] IN ('" & 勾選作業ID & "') "
            SQLQueryUp = " INSERT INTO [KaiShingPlug].[dbo].[PDA_Data_Log] (PDA02,PDA03,PDA04,PDA05,PDA13) VALUES ('同步" & La作業.Text & "作業','刪除作業','" & UCase(GetHostName()) & "',GETDATE(),'" & Replace(SQLQueryAd, "'", ":") & "') "

            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            Try
                SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQueryAd & vbCrLf & SQLQueryUp : SQLCmd.CommandTimeout = 100000
                SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Bu讀取.PerformClick()
        End If
    End Sub

    Private Sub Bu更換_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu更換.Click
        If CB作業別.Text = "" Then : MsgBox("未選擇作業別") : Exit Sub : End If
        更換作業別()
        Bu讀取.PerformClick()
    End Sub

    Private Sub 更換作業別()
        Dim 更換作業ID As String = ""
        For Each oRow As DataGridViewRow In DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then : If 更換作業ID = "" Then
                    更換作業ID = 更換作業ID + Format(oRow.Cells("ID").Value, "")
                Else
                    更換作業ID = 更換作業ID + "','" + Format(oRow.Cells("ID").Value, "")
                End If : End If
        Next
        If 更換作業ID = "" Then : MsgBox("未選擇更換作業別條碼") : Exit Sub : End If

        Dim SQLQueryAd As String = "" : Dim SQLQueryUp As String = ""
        SQLQueryAd = " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA02] = '" & CB作業別.Text & "' WHERE [PDA01] IN ('" & 更換作業ID & "') "
        SQLQueryUp = " INSERT INTO [KaiShingPlug].[dbo].[PDA_Data_Log] (PDA02,PDA03,PDA04,PDA05,PDA13) VALUES ('同步" & La作業.Text & "作業','更換作業','" & UCase(GetHostName()) & "',GETDATE(),'" & Replace(SQLQueryAd, "'", ":") & "') "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQueryAd & vbCrLf & SQLQueryUp : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Bu移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu移除.Click

        If Cnt0 = 0 And Cnt1 = 0 And Cnt2 = 0 Then
            MsgBox("無異常條碼可移除", 16, "錯誤") : Exit Sub
        End If

        If Cnt3 <> 0 Then
            MsgBox("異常條碼", 16, "錯誤") : Exit Sub
        End If

        'If Cnt0 = 0 Then : MsgBox("無異常條碼可移除", 16, "錯誤") : Exit Sub : End If
        'If Cnt1 = 0 Then : MsgBox("無異常條碼可移除", 16, "錯誤") : Exit Sub : End If
        'If Cnt2 = 0 Then : MsgBox("無異常條碼可移除", 16, "錯誤") : Exit Sub : End If
        清除異常條碼()
        Bu讀取.PerformClick()
    End Sub

    Private Sub 清除異常條碼()
        Dim SQLQueryAd As String = "" : Dim SQLQueryUp As String = ""

        Select Case La作業.Text
            Case "入庫"
                SQLQueryAd = "  UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA08] = GETDATE() "
                SQLQueryAd += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] AND S1.[狀態]  = '已入庫' "
                SQLQueryAd += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA08] = GETDATE() "
                SQLQueryAd += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] AND S1.[狀態2] = '作廢' "
            Case "出庫"
                SQLQueryAd = "  UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA08] = GETDATE() "
                SQLQueryAd += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] AND S1.[狀態]  = '出庫' "
            Case "單據入庫"
                SQLQueryAd = "  UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA08] = GETDATE() "
                SQLQueryAd += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] AND S1.[狀態]  = '已入庫' "
                SQLQueryAd += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA08] = GETDATE() "
                SQLQueryAd += "   FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] AND S1.[狀態2] = '作廢' "
        End Select
        SQLQueryUp = " INSERT INTO [KaiShingPlug].[dbo].[PDA_Data_Log] (PDA02,PDA03,PDA04,PDA05,PDA13) VALUES ('同步" & La作業.Text & "作業','清除作業','" & UCase(GetHostName()) & "',GETDATE(),'" & Replace(SQLQueryAd, "'", ":") & "')  "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQueryAd & vbCrLf & SQLQueryUp : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Bu同步_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu同步.Click
        '同步檢查 = "N" : 同步入出庫條碼錯誤檢查()
        'If 同步檢查 = "Y" Then : 同步入出庫條碼() : Bu上頁.PerformClick() : End If 'Else : MsgBox("未執行同步作業") : End If

        同步入出庫條碼() : Bu上頁.PerformClick()

    End Sub
    Private Sub 同步入出庫條碼錯誤檢查()
        If Cnt0 = 0 Then : Else : MsgBox("異常條碼先移除後方可同步", 16, "錯誤") : Exit Sub : End If
        If Cnt1 = 0 Then : Else : MsgBox("異常條碼先移除後方可同步", 16, "錯誤") : Exit Sub : End If
        If Cnt2 = 0 Then : Else : MsgBox("異常條碼先移除後方可同步", 16, "錯誤") : Exit Sub : End If
        If Cnt3 = 0 Then : Else : MsgBox("異常條碼先確認後方可同步", 16, "錯誤") : Exit Sub : End If
        If DGV1.RowCount = 0 Then : MsgBox("無條碼同步", 16, "錯誤") : Exit Sub : End If
        同步檢查 = "Y"

    End Sub
    Private Sub 停止同步按鈕()
        Bu同步.Enabled = False

    End Sub

    Private Sub 同步入出庫條碼()
        Dim SQLQuery As String = "" : Dim SQLAdd As String = ""

        Select Case La作業.Text
            Case "入庫"
                '寫入入庫區
                SQLQuery = "  INSERT INTO [KaiShingPlug].[dbo].[PDA_InData_SAP] ([IN01], [IN02], [IN04], [IN06], [INDT]) "
                SQLQuery += "      SELECT [PDA02], [PDA03], [PDA04], '3' AS 'OUT06', GETDATE() AS 'OUTDT' FROM " & SyncPDA3 & " "
                '已同步資料到待出庫區[PDA_InData_SAP]
                SQLQuery += "      UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3', [PDA08] = GETDATE() "
                SQLQuery += "        FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] "
                SQLQuery += "      UPDATE [@FinishItem1]                    SET [FI103] = '3' "
                SQLQuery += "        FROM [@FinishItem1]                    S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[FI106] = S1.[PDA03] AND LEFT(S1.[PDA02],2) = '11' "
                SQLQuery += "      UPDATE [@FinishItem2]                    SET [FI103] = '3' "
                SQLQuery += "        FROM [@FinishItem2]                    S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[FI106] = S1.[PDA03] AND LEFT(S1.[PDA02],2) = '12' " & vbCrLf
            Case "出庫"
                '寫入出庫區
                SQLQuery = "  INSERT INTO [KaiShingPlug].[dbo].[PDA_OutData_SAP] ([OUT01], [OUT02], [OUT03], [OUT04], [OUT05], [OUT06], [OUTDT]) "
                SQLQuery += "      SELECT [作業別類], [條碼], [數量], [單號], [Gift], '3' AS 'OUT06', GETDATE() AS 'OUTDT' FROM " & SyncPDA3 & " "
                '已同步資料到待出庫區[PDA_OutData_SAP]
                'SQLQuery += "      UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3', [PDA08] = GETDATE() "
                SQLQuery += "      UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3', [PDA05] = GETDATE() "
                SQLQuery += "        FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] " & vbCrLf
            Case "單據入庫"
                '寫入入庫區
                SQLQuery = "  INSERT INTO [KaiShingPlug].[dbo].[PDA_InData_SAP] ([IN01], [IN02], [IN04], [IN06], [INDT]) "
                SQLQuery += "      SELECT [PDA02], [PDA03], [PDA04], '3' AS 'OUT06', GETDATE() AS 'OUTDT' FROM " & SyncPDA3 & " " & vbCrLf
                ''已同步資料到待出庫區[PDA_InData_SAP]
                'SQLQuery += "      UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3', [PDA08] = GETDATE() "
                'SQLQuery += "        FROM [KaiShingPlug].[dbo].[PDA_InData] S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[PDA01] = S1.[ID] "
                'SQLQuery += "      UPDATE [@FinishItem1]                    SET [FI103] = '3' "
                'SQLQuery += "        FROM [@FinishItem1]                    S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[FI106] = S1.[PDA03] AND LEFT(S1.[PDA02],2) = '11' "
                'SQLQuery += "      UPDATE [@FinishItem2]                    SET [FI103] = '3' "
                'SQLQuery += "        FROM [@FinishItem2]                    S0 INNER JOIN " & SyncPDA3 & " S1 ON S0.[FI106] = S1.[PDA03] AND LEFT(S1.[PDA02],2) = '12' "
        End Select

        Dim count As Integer = DGV1.Rows.Count
        For i As Integer = 0 To count - 1
            Dim 作業 As String = ""
            作業 = Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("作業別類").Value, 2)
            If 作業 = "21" Or 作業 = "24" Then
                SQLAdd += " INSERT INTO [KaiShing].[dbo].[Z_KS_Barcode] ([Del],[F1],[F2],[F3],[F4],[InDaetTime]) VALUES "
                SQLAdd += "   ('N', "
                SQLAdd += "    CONVERT(VARCHAR(8),GETDATE(),112),          "  ' 單號
                SQLAdd += "    '" & DGV1.Rows(i).Cells("條碼").Value & "', "  ' 條碼
                SQLAdd += "    'G', "
                SQLAdd += "    'K006-' + CONVERT(VARCHAR(8),GETDATE(),112) , "  ' 儲位
                SQLAdd += "    GETDATE()) " & vbCrLf                    '同步時間
            End If
        Next
        'MsgBox(SQLAdd)

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery + SQLAdd : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 轉Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉Excel.Click
        DataToExcel(DGV1, "")

    End Sub


End Class