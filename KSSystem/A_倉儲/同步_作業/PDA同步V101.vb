Imports System
Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServerCe.Client
Imports System.Net.Dns

Public Class PDA同步V101
    'V101-修改PDA回存條件(11,12)及增加出庫回存(21,22,31)    放棄20141103
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim PDA條碼明細 As DataSet = New DataSet
    Dim PDA儲位統計 As DataSet = New DataSet

    '修改加快回傳方式_Phil_20140501
    Dim DrfNumsDePDA01 As String = ""
    Dim DrfNumsUpPDA01 As String = ""
    Dim DrfNumsUpPDAS3 As String = ""   '序號S3_入庫
    Dim DrfNumsUpPDAB3 As String = ""   '批次B3_入庫
    Dim DrfNumsOpPDAS3 As String = ""   '序號S3_出庫
    Dim DrfNumsOpPDAB3 As String = ""   '批次B3_出庫

    Dim Cnt0 As Integer = 0     '已入庫數
    Dim Cnt1 As Integer = 0     '已出庫數
    Dim Cnt2 As Integer = 0     '

    Dim DGV1選擇 As String = "Y"

    Private Sub PDA同步V101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

        同步至入庫區.Enabled = False
        清除已入庫條碼.Enabled = False

        待轉數量.Text = "待轉數量：0"
        已入庫數.Text = "入庫條碼：0"
        作廢條碼.Text = "作廢條碼：0"

    End Sub

    Private Sub 上頁_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上頁.Click
        生產入庫V100.Show()
        Me.Close()
    End Sub

    Private Sub 同歩初始()
        If Cnt0 = 0 And Cnt2 = 0 And DGV1.RowCount > 0 Then
            同步至入庫區.Enabled = True
        Else
            同步至入庫區.Enabled = False
        End If

        If Cnt0 > 0 Or Cnt2 > 0 Then
            清除已入庫條碼.Enabled = True
            同步至入庫區.Enabled = False
        Else
            清除已入庫條碼.Enabled = False
        End If

        '測試
        ''Dim dtPDAIn As DataTable = PDA條碼明細.Tables("PDADGV1")
        ''DrfNumsUpPDA01 = ""
        ''DrfNumsUpPDAN3 = ""
        ''DrfNumsUpPDAB3 = ""

        ''For Each oRowUp As DataRow In dtPDAIn.Rows
        ''    If oRowUp.Item("PDA90") = "未入庫" Then
        ''        If DrfNumsUpPDA01 = "" Then     'PDA 序列
        ''            DrfNumsUpPDA01 = DrfNumsUpPDA01 + Format(oRowUp.Item("PDA01"), "")
        ''        Else
        ''            DrfNumsUpPDA01 = DrfNumsUpPDA01 + "','" + Format(oRowUp.Item("PDA01"), "")
        ''        End If

        ''        Select Case Microsoft.VisualBasic.Left(oRowUp.Item("PDA02"), 1)
        ''            Case "1"
        ''                If DrfNumsUpPDAN3 = "" Then     'PDA 條碼
        ''                    DrfNumsUpPDAN3 = DrfNumsUpPDAN3 + Format(oRowUp.Item("PDA03"), "")
        ''                Else
        ''                    DrfNumsUpPDAN3 = DrfNumsUpPDAN3 + "','" + Format(oRowUp.Item("PDA03"), "")
        ''                End If
        ''            Case "2"
        ''                If DrfNumsUpPDAB3 = "" Then     'PDA 條碼
        ''                    DrfNumsUpPDAB3 = DrfNumsUpPDAB3 + Format(oRowUp.Item("PDA03"), "")
        ''                Else
        ''                    DrfNumsUpPDAB3 = DrfNumsUpPDAB3 + "','" + Format(oRowUp.Item("PDA03"), "")
        ''                End If
        ''        End Select
        ''    End If
        ''Next

        ''MsgBox("資料!" & DrfNumsUpPDA01, MsgBoxStyle.OkOnly, "清除成功")
        ''MsgBox("資料!" & DrfNumsUpPDAN3, MsgBoxStyle.OkOnly, "清除成功")
        ''MsgBox("資料!" & DrfNumsUpPDAB3, MsgBoxStyle.OkOnly, "清除成功")


    End Sub

    Private Sub 讀取待轉區資料_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 讀取待轉區資料.Click
        DGV1View() : DGV1選擇 = "N"
        DGV2View()
        同歩初始()

        If DGV1.RowCount <= 0 Then : MsgBox("查無資料。", 48, "警告") : End If

    End Sub

    Private Sub DGV1View()
        If DGV1.RowCount > 0 Then : PDA條碼明細.Tables("PDADGV1").Clear() : End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            Dim TmpsN3 As String = "" : Dim TmpsB3 As String = ""
            TmpsN3 = Format(Replace(Replace("#SyncInPDAN3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")
            TmpsB3 = Format(Replace(Replace("#SyncInPDAB3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")

            sql = "    IF (OBJECT_ID('tempdb.." & TmpsN3 & "') IS NOT NULL) DROP TABLE " & TmpsN3 & " "
            sql += "   IF (OBJECT_ID('tempdb.." & TmpsB3 & "') IS NOT NULL) DROP TABLE " & TmpsB3 & " "
            '暫存SAP條碼 _20140806增加 批次暫存, 20141018增加 T1.[Quantity] 數量整位
            sql += "   SELECT DISTINCT T1.[DistNumber] INTO " & TmpsN3 & " "
            sql += "     FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            sql += "    WHERE EXISTS(SELECT DISTINCT TX.[PDA03] FROM [KaiShingPlug].[dbo].[PDA_InData] TX WHERE TX.[PDA06] = '2' AND LEFT(TX.[PDA02],2)  = '11' AND T1.[DistNumber] = TX.[PDA03] ) "
            sql += "   SELECT DISTINCT T1.[DistNumber] INTO " & TmpsB3 & " "
            sql += "     FROM [OBTN] T1 INNER JOIN [OBTQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            sql += "    WHERE EXISTS(SELECT DISTINCT TX.[PDA03] FROM [KaiShingPlug].[dbo].[PDA_InData] TX WHERE TX.[PDA06] = '2' AND LEFT(TX.[PDA02],2)  = '12' AND T1.[DistNumber] = TX.[PDA03] )   "
            '串接_入庫  _修改數據資料 LEFT(P0.[PDA02],1) 改 LEFT(P0.[PDA02],2)  11=電宰, 12=調理
            sql += "   SELECT P0.[PDA01], P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
            sql += "          CASE ISNULL(P1.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS 'PDA90', "
            sql += "          CASE WHEN P2.[FI103] IN ('1','2','3','4') THEN '正常'   ELSE '作廢'   END AS 'PDA91'  "
            sql += "     FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & TmpsN3 & " ) P1 ON P0.[PDA03] = P1.[DistNumber] "    '序號串接
            sql += "                                               LEFT  JOIN [@FinishItem1]                   P2 ON P0.[PDA03] = P2.[FI106] "
            sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],2) = '11' "
            sql += "   UNION ALL "
            sql += "   SELECT P0.[PDA01], P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
            sql += "          CASE ISNULL(P2.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS 'PDA90', "
            sql += "          CASE WHEN P3.[FI103] IN ('1','2','3','4') THEN '正常'   ELSE '作廢'   END AS 'PDA91'  "
            sql += "     FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & TmpsB3 & " ) P2 ON P0.[PDA03] = P2.[DistNumber] "    '批次串接 20140806增加
            sql += "                                               LEFT  JOIN [@FinishItem2]                   P3 ON P0.[PDA03] = P3.[FI106] "
            sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],2) = '12' "
            ''串接_出庫  _21=領料
            'sql += "   UNION ALL "
            'sql += "   SELECT P0.[PDA01], P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
            'sql += "          CASE ISNULL(P2.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS 'PDA90', '已入庫' AS 'PDA91' "
            'sql += "     FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & TmpsB3 & " ) P2 ON P0.[PDA03] = P2.[DistNumber] "    '批次串接 20140806增加
            'sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],2) IN ('21','22') "

            sql += "   IF (OBJECT_ID('tempdb.." & TmpsN3 & "') IS NOT NULL)  DROP TABLE " & TmpsN3 & " "
            sql += "   IF (OBJECT_ID('tempdb.." & TmpsB3 & "') IS NOT NULL)  DROP TABLE " & TmpsB3 & " "

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
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
                Case "PDA90" : column.HeaderText = "是否入庫" : column.DisplayIndex = 5 : column.Visible = True : column.ReadOnly = True     '非資料表內
                Case "PDA91" : column.HeaderText = "是否作廢" : column.DisplayIndex = 6 : column.Visible = True : column.ReadOnly = True     '非資料表內

                Case Else
                    column.Visible = False
            End Select
        Next


        DGV1.AutoResizeColumns()
        DGV1_ListStatus()

        'If DGV1.RowCount <= 0 Then
        '    MsgBox("查無資料。", 48, "警告")
        'End If

        ''----xxx測試---x開始

        ''由讀取出資料庫載入本機記憶體內資料，整合運用()
        ''1-建立資料 新Table 載入 DataTables記憶體資料
        'Dim dt As DataTable = PDA條碼明細.Tables("PDADGV1")
        ''2-建立條件
        'Dim oCriteria As String = "PDA06 = '2' "
        ''3-建立新陣列表 DataRow
        'Dim FoundRow() As DataRow
        ''4-Select * Form DataTables Where 條件
        'foundRow = dt.Select(oCriteria)

        ''5-1-取得 DataRow 列數
        'Dim Row01 As Integer = FoundRow.Count
        'Dim Row02 As Integer = FoundRow.Length

        'MsgBox("查無資料" + vbCrLf & Format(Row01, "") + vbCrLf & Format(Row02, ""), 48, "警告")

        ''5-2-取得資料 寫入 Text內 FoundRow(0)("PDA03")  說明：FoundRow(內序列 0號)("欄位名")
        '待轉數量.Text = Format(FoundRow(0)("PDA03"), "")

        ''----xxx測試---x結束

    End Sub

    Private Sub DGV1View選擇()
        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.Name = "選擇"
        checkBoxColumn.Width = 30
        DGV1.Columns.Insert(0, checkBoxColumn)

    End Sub

    Private Sub DGV1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.Sorted
        DGV1_ListStatus()

    End Sub

    Private Sub DGV1_ListStatus()
        Cnt0 = 0 : Cnt1 = 0 : Cnt2 = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("PDA90").Value = "已入庫" Then '以黃底顯示
                DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Cnt0 += 0 + 1
            End If
            'If DGV1.Rows(i).Cells("PDA90").Value = "已出庫" Then '以紅底顯示
            '    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Red
            '    Cnt1 += 0 + 1
            'End If
            If DGV1.Rows(i).Cells("PDA91").Value = "作廢" Then '以淡藍底顯示
                DGV1.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
                Cnt2 += 0 + 1
            End If
        Next

        'Cnt1 = 0
        'For i As Integer = 0 To DGV1.RowCount - 1   '以紅底顯示
        '    If DGV1.Rows(i).Cells("PDA90").Value = "已出庫" Then
        '        DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Red
        '        Cnt1 += 0 + 1
        '    End If
        'Next

        ''For i As Integer = 0 To DGV1.RowCount - 1   '以淡藍底顯示
        ''    If DGV1.Rows(i).Cells("PDA90").Value = "已入庫" Then
        ''        DGV1.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        ''    End If
        ''Next

        'For i As Integer = 0 To DGV1.RowCount - 1   '以淡藍底顯示
        '    If DGV1.Rows(i).Cells("PDA91").Value = "作" Then
        '        DGV1.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    End If
        'Next

        'For i As Integer = 0 To DGV1.RowCount - 1   '以淡藍底顯示
        '    If DGV1.Rows(i).Cells("PDA91").Value = "出庫" And DGV1.Rows(i).Cells("PDA90").Value = "未入庫" Then
        '        DGV1.Rows(i).DefaultCellStyle.BackColor = Color.PaleGreen
        '    End If
        'Next

        'Dim Cnt1 As Integer = 0
        'For i As Integer = 0 To DGV3.RowCount - 1   '以紅底顯示
        '    If DGV3.Rows(i).Cells("是否同歩").Value = "已入庫" Then
        '        DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Red
        '        Cnt1 += 0 + 1
        '    End If
        'Next

        'Dim Cnt2 As Integer = 0
        'For i As Integer = 0 To DGV3.RowCount - 1   '以Blue底顯示
        '    If DGV3.Rows(i).Cells("狀態").Value = "出庫" Then
        '        DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Blue
        '        Cnt2 += 0 + 1
        '    End If
        'Next

        DGV1.ClearSelection()

        待轉數量.Text = "待轉數量：" & DGV1.RowCount
        已入庫數.Text = "入庫條碼：" & Cnt0
        作廢條碼.Text = "作廢條碼：" & Cnt2

        'Label6.Text = Format(DGV3.RowCount, "")
        'Label7.Text = Cnt0
        'Label8.Text = Cnt1
        'Label9.Text = Cnt2

    End Sub

    Private Sub DGV2View()

        If DGV2.RowCount > 0 Then
            PDA儲位統計.Tables("PDADGV2").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "  SELECT [PDA04], COUNT([PDA04]) AS 'COUNT' FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE [PDA06] = '2' AND LEFT([PDA02],2) IN ('11','12') GROUP BY [PDA04] "      '修改數據資料增加出庫作業用

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(PDA儲位統計, "PDADGV2")
            DGV2.DataSource = PDA儲位統計.Tables("PDADGV2")
        Catch ex As Exception
            MsgBox("PDA儲位統計：" & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "PDA04" : column.HeaderText = "儲　　位" : column.DisplayIndex = 0 : column.Visible = True
                Case "COUNT" : column.HeaderText = "數　　量" : column.DisplayIndex = 1 : column.Visible = True
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.AutoResizeColumns()
        'If DGV2.RowCount <= 0 Then
        '    MsgBox("查無資料。", 48, "警告")
        'End If

    End Sub

    Private Sub 同步至入庫區_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 同步至入庫區.Click
        If Cnt1 = 0 Then : Else : MsgBox("異常條碼先移除後方可同步", 16, "錯誤") : Exit Sub : End If
        If Cnt2 = 0 Then : Else : MsgBox("異常條碼先移除後方可同步", 16, "錯誤") : Exit Sub : End If
        If DGV1.RowCount <= 0 Then : MsgBox("查無資料。", 48, "警告") : Exit Sub : End If

        同步資料()

        同步至入庫區.Enabled = False
        清除已入庫條碼.Enabled = False

    End Sub

    Private Sub 同步資料()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim dtPDAIn As DataTable = PDA條碼明細.Tables("PDADGV1")

        DrfNumsUpPDA01 = ""
        DrfNumsUpPDAS3 = "" '序號S3
        DrfNumsUpPDAB3 = "" '批次B3

        For Each oRowUp As DataRow In dtPDAIn.Rows
            If oRowUp.Item("PDA90") = "未入庫" Then
                If DrfNumsUpPDA01 = "" Then     'PDA 序列
                    DrfNumsUpPDA01 = DrfNumsUpPDA01 + Format(oRowUp.Item("PDA01"), "")
                Else
                    DrfNumsUpPDA01 = DrfNumsUpPDA01 + "','" + Format(oRowUp.Item("PDA01"), "")
                End If

                Select Case Microsoft.VisualBasic.Left(oRowUp.Item("PDA02"), 2)
                    Case "11"
                        If DrfNumsUpPDAS3 = "" Then     'PDA 電宰入庫條碼
                            DrfNumsUpPDAS3 = DrfNumsUpPDAS3 + Format(oRowUp.Item("PDA03"), "")
                        Else
                            DrfNumsUpPDAS3 = DrfNumsUpPDAS3 + "','" + Format(oRowUp.Item("PDA03"), "")
                        End If
                    Case "12"
                        If DrfNumsUpPDAB3 = "" Then     'PDA 加工入庫條碼
                            DrfNumsUpPDAB3 = DrfNumsUpPDAB3 + Format(oRowUp.Item("PDA03"), "")
                        Else
                            DrfNumsUpPDAB3 = DrfNumsUpPDAB3 + "','" + Format(oRowUp.Item("PDA03"), "")
                        End If
                End Select
            End If
        Next

        'MsgBox("資料!" & DrfNumsUpPDA01, MsgBoxStyle.OkOnly, "清除成功")
        'MsgBox("資料!" & DrfNumsUpPDAN3, MsgBoxStyle.OkOnly, "清除成功")
        'MsgBox("資料!" & DrfNumsUpPDAB3, MsgBoxStyle.OkOnly, "清除成功")

        If dtPDAIn.Rows.Count > 0 Then
            Try
                '1.將PDA資料同步至資料庫, 並進行必要資料更新
                For Each oRow As DataRow In dtPDAIn.Rows

                    '(1) 利用Insert命令逐筆複製至Server資料庫[@ksPDAIn]中
                    sql = " INSERT INTO [@ksPDAIn] (PDA02,PDA03,PDA04,PDA05,PDA06,PDA07,PDA08,PDA09) VALUES "
                    sql += "    ('" & oRow.Item("PDA02") & "', "    'PDA02 作業別
                    sql += "     '" & oRow.Item("PDA03") & "', "    'PDA03 條碼
                    sql += "     '" & oRow.Item("PDA04") & "', "    'PDA04 儲位
                    sql += "     '" & oRow.Item("PDA05") & "', "    'PDA05 刷入時間
                    sql += "     '" & oRow.Item("PDA06") & "', "    'PDA06 狀態
                    sql += "     '" & oRow.Item("PDA07") & "',"     'PDA07 作業單號
                    sql += "     '" & Login.LogonUserName & "', "   'PDA08 同步人員
                    sql += "     '" & oRow.Item("PDA09") & "')"     'PDA09 數量

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                Next

                sql = "       UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3' WHERE [PDA01] IN ('" & DrfNumsUpPDA01 & "') "
                If DrfNumsUpPDAS3 <> "" Then '序號N3
                    sql += "  UPDATE [@FinishItem1]                    SET [FI103] = '3' WHERE [FI106] IN ('" & DrfNumsUpPDAS3 & "') "
                End If
                If DrfNumsUpPDAB3 <> "" Then '批次B3
                    sql += "  UPDATE [@FinishItem2]                    SET [FI103] = '3' WHERE [FI106] IN ('" & DrfNumsUpPDAB3 & "') "
                End If

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

                tran.Commit()
            Catch ex As Exception
                tran.Rollback()
                MsgBox("同步PDA資料至伺服器資料庫時錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
                Exit Sub
            End Try

            MsgBox("PDA資料同步完畢!", MsgBoxStyle.OkOnly, "同步成功")
            PDA條碼明細.Tables("PDADGV1").Clear()
            PDA儲位統計.Tables("PDADGV2").Clear()

        End If
    End Sub

    Private Sub 清除已入庫條碼_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清除已入庫條碼.Click
        清除已入庫資料()
        DGV1View()
        DGV2View()
    End Sub

    Private Sub 清除已入庫資料()

        'Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim dtPDAIn As DataTable = PDA條碼明細.Tables("PDADGV1") : DrfNumsDePDA01 = ""

        For Each oRow As DataRow In dtPDAIn.Rows
            If oRow.Item("PDA90") = "已入庫" Or oRow.Item("PDA91") = "作廢" Then
                If DrfNumsDePDA01 = "" Then
                    DrfNumsDePDA01 = DrfNumsDePDA01 + Format(oRow.Item("PDA01"), "")
                Else
                    DrfNumsDePDA01 = DrfNumsDePDA01 + "','" + Format(oRow.Item("PDA01"), "")
                End If
            End If
        Next

        Dim SQLQueryAd As String = "" : Dim SQLQueryUp As String = ""
        SQLQueryAd = " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET  [PDA06] = '6' WHERE [PDA01] IN ('" & DrfNumsDePDA01 & "')  "
        SQLQueryUp = " INSERT INTO [KaiShingPlug].[dbo].[PDA_Data_Log] (PDA02,PDA03,PDA04,PDA05,PDA13) VALUES ('入庫作業','清除作業','" & UCase(GetHostName()) & "',GETDATE(),'" & Replace(SQLQueryAd, "'", ":") & "')  "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQueryAd & vbCrLf & SQLQueryUp : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("清除已入庫資料時錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
        End Try

        'Try
        '    sql = " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET  [PDA06] = '6' WHERE [PDA01] IN ('" & DrfNumsDePDA01 & "') "

        '    SQLCmd.Connection = DBConn
        '    SQLCmd.CommandText = sql
        '    SQLCmd.Transaction = tran
        '    SQLCmd.ExecuteNonQuery()

        '    tran.Commit()
        'Catch ex As Exception
        '    tran.Rollback()
        '    MsgBox("清除已入庫資料時錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
        '    Exit Sub
        'End Try

        MsgBox("清除已入庫資料!", MsgBoxStyle.OkOnly, "清除成功")

    End Sub

    Private Sub 轉Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉Excel.Click
        DataToExcel(DGV1, "")

    End Sub

    Private Sub Bu更換_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu更換.Click
        If CB作業別.Text = "" Then : MsgBox("未選擇作業別") : Exit Sub : End If
        更換作業別()
        讀取待轉區資料.PerformClick()
    End Sub

    Private Sub 更換作業別()
        Dim 更換作業ID As String = ""
        For Each oRow As DataGridViewRow In DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then : If 更換作業ID = "" Then
                    更換作業ID = 更換作業ID + Format(oRow.Cells("PDA01").Value, "")
                Else
                    更換作業ID = 更換作業ID + "','" + Format(oRow.Cells("PDA01").Value, "")
                End If : End If
        Next

        Dim SQLQueryAd As String = "" : Dim SQLQueryUp As String = ""
        SQLQueryAd = " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA02] = '" & CB作業別.Text & "' WHERE [PDA01] IN ('" & 更換作業ID & "') "
        SQLQueryUp = " INSERT INTO [KaiShingPlug].[dbo].[PDA_Data_Log] (PDA02,PDA03,PDA04,PDA05,PDA13) VALUES ('入庫作業','更換作業','" & UCase(GetHostName()) & "',GETDATE(),'" & Replace(SQLQueryAd, "'", ":") & "') "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQueryAd & vbCrLf & SQLQueryUp : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



End Class