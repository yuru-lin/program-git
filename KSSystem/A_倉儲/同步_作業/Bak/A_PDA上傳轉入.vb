Imports System
Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServerCe.Client

Public Class A_PDA上傳轉入
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim PDA條碼明細 As DataSet = New DataSet
    Dim PDA儲位統計 As DataSet = New DataSet

    '修改加快回傳方式_Phil_20140501
    Dim DrfNumsDePDA01 As String = ""
    Dim DrfNumsUpPDA01 As String = ""
    Dim DrfNumsUpPDAN3 As String = ""   '序號N3
    Dim DrfNumsUpPDAB3 As String = ""   '批次B3


    Dim Cnt0 As Integer = 0


    Private Sub A_PDA上傳轉入_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

        同步至入庫區.Enabled = False
        清除已入庫條碼.Enabled = False

        待轉數量.Text = "待轉數量：0"
        已入庫數.Text = "入庫條碼：0"

    End Sub

    Private Sub 上頁_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上頁.Click
        C_生產入庫.Show()
        Me.Close()
    End Sub

    Private Sub 同歩初始()
        If Cnt0 = 0 And DGV1.RowCount > 0 Then
            同步至入庫區.Enabled = True
        Else
            同步至入庫區.Enabled = False
        End If

        If Cnt0 > 0 Then
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
        DGV1View()
        DGV2View()
        同歩初始()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If



    End Sub

    Private Sub DGV1View()

        If DGV1.RowCount > 0 Then
            PDA條碼明細.Tables("PDADGV1").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            Dim TmpsN3 As String = "" : Dim TmpsB3 As String = ""
            TmpsN3 = Format(Replace(Replace("#SyncInPDAN3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")
            TmpsB3 = Format(Replace(Replace("#SyncInPDAB3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")

            sql = "    IF (OBJECT_ID('tempdb.." & TmpsN3 & "') IS NOT NULL)  DROP TABLE " & TmpsN3 & " "
            sql += "   IF (OBJECT_ID('tempdb.." & TmpsB3 & "') IS NOT NULL)  DROP TABLE " & TmpsB3 & " "

            sql += "   SELECT DISTINCT T1.[DistNumber] INTO " & TmpsN3 & " "    '序號暫存，檢查是否已入庫
            sql += "     FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            sql += "    WHERE EXISTS(SELECT DISTINCT TX.[PDA03] FROM [KaiShingPlug].[dbo].[PDA_InData] TX WHERE TX.[PDA06] = '2' AND LEFT(TX.[PDA02],1)  = '1' AND T1.[DistNumber] = TX.[PDA03] ) "

            sql += "   SELECT DISTINCT T1.[DistNumber] INTO " & TmpsB3 & " "    '批次暫存，檢查是否已入庫 20140806增加
            sql += "     FROM [OBTN] T1 INNER JOIN [OBTQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            sql += "    WHERE EXISTS(SELECT DISTINCT TX.[PDA03] FROM [KaiShingPlug].[dbo].[PDA_InData] TX WHERE TX.[PDA06] = '2' AND LEFT(TX.[PDA02],1)  = '2' AND T1.[DistNumber] = TX.[PDA03] )   "

            sql += "   SELECT P0.[PDA01], P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
            sql += "          CASE ISNULL(P1.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS 'PDA90' "
            sql += "     FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & TmpsN3 & " ) P1 ON P0.[PDA03] = P1.[DistNumber] "    '序號串接
            'sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],1) = '1' "
            sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],1) = '1' "   '修改數據資料增加出庫作業用
            sql += "   UNION ALL "
            sql += "   SELECT P0.[PDA01], P0.[PDA02], P0.[PDA03], P0.[PDA04], CONVERT(nvarchar(20),P0.[PDA05],120) AS 'PDA05', P0.[PDA06], P0.[PDA07], P0.[PDA08], P0.[PDA09], P0.[PDA10], P0.[PDA11], P0.[PDA12], "
            sql += "          CASE ISNULL(P2.[DistNumber],'') WHEN  ''  THEN '未入庫' ELSE '已入庫' END AS 'PDA90' "
            sql += "     FROM [KaiShingPlug].[dbo].[PDA_InData] P0 LEFT  JOIN ( SELECT * FROM " & TmpsB3 & " ) P2 ON P0.[PDA03] = P2.[DistNumber] "    '批次串接 20140806增加
            'sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],1) = '2' "
            sql += "    WHERE P0.[PDA06] = '2' AND LEFT(P0.[PDA02],1) = '2' "   '修改數據資料增加出庫作業用

            sql += "   IF (OBJECT_ID('tempdb.." & TmpsN3 & "') IS NOT NULL)  DROP TABLE " & TmpsN3 & " "
            sql += "   IF (OBJECT_ID('tempdb.." & TmpsB3 & "') IS NOT NULL)  DROP TABLE " & TmpsB3 & " "

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(PDA條碼明細, "PDADGV1")
            DGV1.DataSource = PDA條碼明細.Tables("PDADGV1")
        Catch ex As Exception
            MsgBox("PDA條碼明細：" & ex.Message)
            Exit Sub
        End Try

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "PDA02" : column.HeaderText = "作業單別" : column.DisplayIndex = 0 : column.Visible = True
                Case "PDA03" : column.HeaderText = "條　　碼" : column.DisplayIndex = 1 : column.Visible = True
                Case "PDA04" : column.HeaderText = "儲　　位" : column.DisplayIndex = 2 : column.Visible = True
                Case "PDA05" : column.HeaderText = "作業日期" : column.DisplayIndex = 3 : column.Visible = True
                Case "PDA90" : column.HeaderText = "是否入庫" : column.DisplayIndex = 4 : column.Visible = True     '非資料表內
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

    Private Sub DGV1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.Sorted
        DGV1_ListStatus()
    End Sub

    Private Sub DGV1_ListStatus()

        Cnt0 = 0
        For i As Integer = 0 To DGV1.RowCount - 1   '以黃底顯示
            If DGV1.Rows(i).Cells("PDA90").Value = "已入庫" Then
                DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Cnt0 += 0 + 1
            End If
        Next

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
            sql = "  SELECT [PDA04], COUNT([PDA04]) AS 'COUNT' FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE [PDA06] = '2' AND LEFT([PDA02],1) IN ('1','2') GROUP BY [PDA04] "      '修改數據資料增加出庫作業用
            'sql = "  SELECT [PDA04], COUNT([PDA04]) AS 'COUNT' FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE [PDA06] = '2' AND LEFT([PDA02],1) IN ('1','2') GROUP BY [PDA04] "      '修改數據資料增加出庫作業用


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
        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料。", 48, "警告")
            Exit Sub
        End If

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
        DrfNumsUpPDAN3 = "" '序號N3
        DrfNumsUpPDAB3 = "" '批次B3

        For Each oRowUp As DataRow In dtPDAIn.Rows
            If oRowUp.Item("PDA90") = "未入庫" Then
                If DrfNumsUpPDA01 = "" Then     'PDA 序列
                    DrfNumsUpPDA01 = DrfNumsUpPDA01 + Format(oRowUp.Item("PDA01"), "")
                Else
                    DrfNumsUpPDA01 = DrfNumsUpPDA01 + "','" + Format(oRowUp.Item("PDA01"), "")
                End If

                Select Case Microsoft.VisualBasic.Left(oRowUp.Item("PDA02"), 1)
                    Case "1"
                        If DrfNumsUpPDAN3 = "" Then     'PDA 條碼
                            DrfNumsUpPDAN3 = DrfNumsUpPDAN3 + Format(oRowUp.Item("PDA03"), "")
                        Else
                            DrfNumsUpPDAN3 = DrfNumsUpPDAN3 + "','" + Format(oRowUp.Item("PDA03"), "")
                        End If
                    Case "2"
                        If DrfNumsUpPDAB3 = "" Then     'PDA 條碼
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
                    sql += "     '" & oRow.Item("PDA09") & "')"     'PDA09 作廢人員

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                    '(2) 若為電宰或加工待入庫單, 則修改該項之狀態
                    'Select Case Microsoft.VisualBasic.Left(oRow.Item("PDA02"), 1)
                    '    Case "1"
                    '        sql = "  UPDATE [@FinishItem1]                    SET  [FI103] = '3' WHERE [FI106] = '" & oRow.Item("PDA03") & "' "
                    '        sql += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET  [PDA06] = '3' WHERE [PDA01] = '" & oRow.Item("PDA01") & "' "

                    '        SQLCmd.Connection = DBConn
                    '        SQLCmd.CommandText = sql
                    '        SQLCmd.Transaction = tran
                    '        SQLCmd.ExecuteNonQuery()
                    '    Case "2"
                    '        sql = "  UPDATE [@FinishItem2]                    SET  [FI103] = '3' WHERE [FI106] = '" & oRow.Item("PDA03") & "' "
                    '        sql += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET  [PDA06] = '3' WHERE [PDA01] = '" & oRow.Item("PDA01") & "' "

                    '        SQLCmd.Connection = DBConn
                    '        SQLCmd.CommandText = sql
                    '        SQLCmd.Transaction = tran
                    '        SQLCmd.ExecuteNonQuery()
                    'End Select

                Next

                sql = "       UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3' WHERE [PDA01] IN ('" & DrfNumsUpPDA01 & "') "
                If DrfNumsUpPDAN3 <> "" Then '序號N3
                    sql += "  UPDATE [@FinishItem1]                    SET [FI103] = '3' WHERE [FI106] IN ('" & DrfNumsUpPDAN3 & "') "
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

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim dtPDAIn As DataTable = PDA條碼明細.Tables("PDADGV1")

        DrfNumsDePDA01 = ""

        For Each oRow As DataRow In dtPDAIn.Rows
            If oRow.Item("PDA90") = "已入庫" Then
                If DrfNumsDePDA01 = "" Then
                    DrfNumsDePDA01 = DrfNumsDePDA01 + Format(oRow.Item("PDA01"), "")
                Else
                    DrfNumsDePDA01 = DrfNumsDePDA01 + "','" + Format(oRow.Item("PDA01"), "")
                End If
            End If
        Next

        'MsgBox("資料!" & DrfNums1, MsgBoxStyle.OkOnly, "清除成功")

        Try
            'For Each oRow As DataRow In dtPDAIn.Rows
            '    If oRow.Item("PDA90") = "已入庫" Then
            '(2) 若為電宰或加工待入庫單, 則修改該項之狀態
            sql = " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET  [PDA06] = '6' WHERE [PDA01] IN ('" & DrfNumsDePDA01 & "') "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            '    End If
            'Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("清除已入庫資料時錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("清除已入庫資料!", MsgBoxStyle.OkOnly, "清除成功")

    End Sub

End Class