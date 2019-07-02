Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 數量差異表

    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim DataAdapterDGV As SqlDataAdapter
    Dim SqlDataAdapter1 As New SqlDataAdapter

    Private Sub 數量差異表_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If Unit.Text = "" Then
            MsgBox("請選擇單位！", 16, "錯誤")
            Unit.Focus()
            Exit Sub
        End If

        If Year.Text = "" Then
            MsgBox("請選擇年度！", 16, "錯誤")
            Year.Focus()
            Exit Sub
        End If

        If Month.Text = "" Then
            MsgBox("請選擇月份！", 16, "錯誤")
            Month.Focus()
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub GetDGV1Data()  '取得查詢資料

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  SELECT [Unit] AS '單位',[ItemName] AS '品項',[Year] AS '年度',[Month] AS '月份',[Week] AS '週別',[FromDate] AS '起始日',[ToDate] AS '結束日',[ReckonQty] AS '預估數量',[RealQty] AS '實際數量',[Comments] AS '備註' "
            sql += " FROM [KaiShingPlug].[dbo].[Z_KS_QtyDifference] "
            sql += " WHERE [Unit] = '" & Unit.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

        DGV1Display()

    End Sub

    Private Sub DGV1Display()  '載入DGV1資料畫面

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "單位"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "品項"
                    column.HeaderText = "品項"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "年度"
                    column.HeaderText = " 年度"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "月份"
                    column.HeaderText = "月份"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "週別"
                    column.HeaderText = "週別"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "起始日"
                    column.HeaderText = "起始日"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case "結束日"
                    column.HeaderText = "結束日"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "預估數量"
                    column.HeaderText = "預估數量"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case "實際數量"
                    column.HeaderText = "實際數量"
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                Case "備註"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 9
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增.Click

        If Unit.Text = "" Then
            MsgBox("請選擇單位！", 16, "錯誤")
            Unit.Focus()
            Exit Sub
        End If

        If ItemName.Text = "" Then
            MsgBox("品項未填！", 16, "錯誤")
            ItemName.Focus()
            Exit Sub
        End If

        If Year.Text = "" Then
            MsgBox("請選擇年度！", 16, "錯誤")
            Year.Focus()
            Exit Sub
        End If

        If Month.Text = "" Then
            MsgBox("請選擇月份！", 16, "錯誤")
            Month.Focus()
            Exit Sub
        End If


        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()


        Try
            '第一週
            If FromDate1.Text <> "" Then
                sql += " INSERT INTO [KaiShingPlug].[dbo].[Z_KS_QtyDifference] ([Unit],[ItemName],[Year],[Month],[Week],[FromDate],[ToDate],[ReckonQty],[RealQty],[Comments]) VALUES "
                sql += " ('" & Unit.Text & "'        ,"
                sql += "  '" & ItemName.Text & "'    ,"
                sql += "  '" & Year.Text & "'        ,"
                sql += "  '" & Month.Text & "'       ,"
                sql += "  '" & Week1.Text & "'       ,"
                sql += "  '" & FromDate1.Text & "'   ,"
                sql += "  '" & ToDate1.Text & "'     ,"
                sql += "  '" & ReckonQty1.Text & "'  ,"
                sql += "  '" & RealQty1.Text & "'    ,"
                sql += "  '" & Comments1.Text & "'   )"
            End If


            '第二週
            If FromDate2.Text <> "" Then
                sql += " INSERT INTO [KaiShingPlug].[dbo].[Z_KS_QtyDifference] ([Unit],[ItemName],[Year],[Month],[Week],[FromDate],[ToDate],[ReckonQty],[RealQty],[Comments]) VALUES "
                sql += " ('" & Unit.Text & "'        ,"
                sql += "  '" & ItemName.Text & "'    ,"
                sql += "  '" & Year.Text & "'        ,"
                sql += "  '" & Month.Text & "'       ,"
                sql += "  '" & Week2.Text & "'       ,"
                sql += "  '" & FromDate2.Text & "'   ,"
                sql += "  '" & ToDate2.Text & "'     ,"
                sql += "  '" & ReckonQty2.Text & "'  ,"
                sql += "  '" & RealQty2.Text & "'    ,"
                sql += "  '" & Comments2.Text & "'   )"
            End If


            '第三週
            If FromDate3.Text <> "" Then
                sql += " INSERT INTO [KaiShingPlug].[dbo].[Z_KS_QtyDifference] ([Unit],[ItemName],[Year],[Month],[Week],[FromDate],[ToDate],[ReckonQty],[RealQty],[Comments]) VALUES "
                sql += " ('" & Unit.Text & "'        ,"
                sql += "  '" & ItemName.Text & "'    ,"
                sql += "  '" & Year.Text & "'        ,"
                sql += "  '" & Month.Text & "'       ,"
                sql += "  '" & Week3.Text & "'       ,"
                sql += "  '" & FromDate3.Text & "'   ,"
                sql += "  '" & ToDate3.Text & "'     ,"
                sql += "  '" & ReckonQty3.Text & "'  ,"
                sql += "  '" & RealQty3.Text & "'    ,"
                sql += "  '" & Comments3.Text & "'   )"
            End If


            '第四週
            If FromDate4.Text <> "" Then
                sql += " INSERT INTO [KaiShingPlug].[dbo].[Z_KS_QtyDifference] ([Unit],[ItemName],[Year],[Month],[Week],[FromDate],[ToDate],[ReckonQty],[RealQty],[Comments]) VALUES "
                sql += " ('" & Unit.Text & "'        ,"
                sql += "  '" & ItemName.Text & "'    ,"
                sql += "  '" & Year.Text & "'        ,"
                sql += "  '" & Month.Text & "'       ,"
                sql += "  '" & Week4.Text & "'       ,"
                sql += "  '" & FromDate4.Text & "'   ,"
                sql += "  '" & ToDate4.Text & "'     ,"
                sql += "  '" & ReckonQty4.Text & "'  ,"
                sql += "  '" & RealQty4.Text & "'    ,"
                sql += "  '" & Comments4.Text & "'   )"
            End If


            '第五週
            If FromDate5.Text <> "" Then
                sql += " INSERT INTO [KaiShingPlug].[dbo].[Z_KS_QtyDifference] ([Unit],[ItemName],[Year],[Month],[Week],[FromDate],[ToDate],[ReckonQty],[RealQty],[Comments]) VALUES "
                sql += " ('" & Unit.Text & "'        ,"
                sql += "  '" & ItemName.Text & "'    ,"
                sql += "  '" & Year.Text & "'        ,"
                sql += "  '" & Month.Text & "'       ,"
                sql += "  '" & Week5.Text & "'       ,"
                sql += "  '" & FromDate5.Text & "'   ,"
                sql += "  '" & ToDate5.Text & "'     ,"
                sql += "  '" & ReckonQty5.Text & "'  ,"
                sql += "  '" & RealQty5.Text & "'    ,"
                sql += "  '" & Comments5.Text & "'   )"
            End If


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()

        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub

        End Try


        GetDGV1Data()


        Unit.Text = ""
        ItemName.Text = ""
        Year.Text = ""
        Month.Text = ""
        FromDate1.Text = ""
        FromDate2.Text = ""
        FromDate3.Text = ""
        FromDate4.Text = ""
        FromDate5.Text = ""
        ToDate1.Text = ""
        ToDate2.Text = ""
        ToDate3.Text = ""
        ToDate4.Text = ""
        ToDate5.Text = ""
        ReckonQty1.Text = ""
        ReckonQty2.Text = ""
        ReckonQty3.Text = ""
        ReckonQty4.Text = ""
        ReckonQty5.Text = ""
        RealQty1.Text = ""
        RealQty2.Text = ""
        RealQty3.Text = ""
        RealQty4.Text = ""
        RealQty5.Text = ""
        Comments1.Text = ""
        Comments2.Text = ""
        Comments3.Text = ""
        Comments4.Text = ""
        Comments5.Text = ""

    End Sub

    Private Sub 修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改.Click

        查詢.Enabled = True    '開啟查詢
        新增.Enabled = False   '關閉新增
        修改.Enabled = False   '關閉修改
        更新.Enabled = True    '開啟更新

    End Sub

    Private Sub 更新_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 更新.Click

        DGV1_Update()
        DB_Update()


        查詢.Enabled = True   '開啟查詢
        新增.Enabled = True   '開啟新增
        修改.Enabled = True   '開啟修改
        更新.Enabled = True   '開啟更新

        Unit.Text = ""
        ItemName.Text = ""
        Year.Text = ""
        Month.Text = ""
        FromDate1.Text = ""
        FromDate2.Text = ""
        FromDate3.Text = ""
        FromDate4.Text = ""
        FromDate5.Text = ""
        ToDate1.Text = ""
        ToDate2.Text = ""
        ToDate3.Text = ""
        ToDate4.Text = ""
        ToDate5.Text = ""
        ReckonQty1.Text = ""
        ReckonQty2.Text = ""
        ReckonQty3.Text = ""
        ReckonQty4.Text = ""
        ReckonQty5.Text = ""
        RealQty1.Text = ""
        RealQty2.Text = ""
        RealQty3.Text = ""
        RealQty4.Text = ""
        RealQty5.Text = ""
        Comments1.Text = ""
        Comments2.Text = ""
        Comments3.Text = ""
        Comments4.Text = ""
        Comments5.Text = ""

    End Sub

    Private Sub DGV1_Update()

            DGV1.CurrentRow.Cells("單位").Value = Unit.Text
            DGV1.CurrentRow.Cells("品項").Value = ItemName.Text
            DGV1.CurrentRow.Cells("年度").Value = Year.Text
            DGV1.CurrentRow.Cells("月份").Value = Month.Text


        For i As Integer = 0 To DGV1.RowCount - 1

            If (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then

                If DGV1.Rows(i).Cells("週別").Value = "1" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    DGV1.Rows(i).Cells("起始日").Value = FromDate1.Text
                    DGV1.Rows(i).Cells("結束日").Value = ToDate1.Text
                    DGV1.Rows(i).Cells("預估數量").Value = ReckonQty1.Text
                    DGV1.Rows(i).Cells("實際數量").Value = RealQty1.Text
                    DGV1.Rows(i).Cells("備註").Value = Comments1.Text
                End If

                If DGV1.Rows(i).Cells("週別").Value = "2" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    DGV1.Rows(i).Cells("起始日").Value = FromDate2.Text
                    DGV1.Rows(i).Cells("結束日").Value = ToDate2.Text
                    DGV1.Rows(i).Cells("預估數量").Value = ReckonQty2.Text
                    DGV1.Rows(i).Cells("實際數量").Value = RealQty2.Text
                    DGV1.Rows(i).Cells("備註").Value = Comments2.Text
                End If

                If DGV1.Rows(i).Cells("週別").Value = "3" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    DGV1.Rows(i).Cells("起始日").Value = FromDate3.Text
                    DGV1.Rows(i).Cells("結束日").Value = ToDate3.Text
                    DGV1.Rows(i).Cells("預估數量").Value = ReckonQty3.Text
                    DGV1.Rows(i).Cells("實際數量").Value = RealQty3.Text
                    DGV1.Rows(i).Cells("備註").Value = Comments3.Text
                End If

                If DGV1.Rows(i).Cells("週別").Value = "4" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    DGV1.Rows(i).Cells("起始日").Value = FromDate4.Text
                    DGV1.Rows(i).Cells("結束日").Value = ToDate4.Text
                    DGV1.Rows(i).Cells("預估數量").Value = ReckonQty4.Text
                    DGV1.Rows(i).Cells("實際數量").Value = RealQty4.Text
                    DGV1.Rows(i).Cells("備註").Value = Comments4.Text
                End If

                If DGV1.Rows(i).Cells("週別").Value = "5" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    DGV1.Rows(i).Cells("起始日").Value = FromDate5.Text
                    DGV1.Rows(i).Cells("結束日").Value = ToDate5.Text
                    DGV1.Rows(i).Cells("預估數量").Value = ReckonQty5.Text
                    DGV1.Rows(i).Cells("實際數量").Value = RealQty5.Text
                    DGV1.Rows(i).Cells("備註").Value = Comments5.Text

                End If

            End If
        Next

        'If DGV1.CurrentRow.Cells("週別").Value = 1 Then
        '    DGV1.CurrentRow.Cells("起始日").Value = FromDate1.Text
        '    DGV1.CurrentRow.Cells("結束日").Value = ToDate1.Text
        'End If

        'If DGV1.CurrentRow.Cells("週別").Value = 2 Then
        '    DGV1.CurrentRow.Cells("起始日").Value = FromDate2.Text
        '    DGV1.CurrentRow.Cells("結束日").Value = ToDate2.Text
        'End If

    End Sub

    Private Sub DB_Update()

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To DGV1.RowCount - 1

                If DGV1.Rows(i).Cells("週別").Value = "1" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    sql += " UPDATE [KaiShingPlug].[dbo].[Z_KS_QtyDifference] SET "
                    sql += "       [Unit]       = '" & DGV1.Rows(i).Cells("單位").Value() & "'       , "
                    sql += "       [ItemName]   = '" & DGV1.Rows(i).Cells("品項").Value() & "'       , "
                    sql += "       [Year]       = '" & DGV1.Rows(i).Cells("年度").Value() & "'       , "
                    sql += "       [Month]      = '" & DGV1.Rows(i).Cells("月份").Value() & "'       , "
                    sql += "       [FromDate]   = '" & DGV1.Rows(i).Cells("起始日").Value() & "'     , "
                    sql += "       [ToDate]     = '" & DGV1.Rows(i).Cells("結束日").Value() & "'     , "
                    sql += "       [ReckonQty]  = '" & DGV1.Rows(i).Cells("預估數量").Value() & "'   , "
                    sql += "       [RealQty]    = '" & DGV1.Rows(i).Cells("實際數量").Value() & "'   , "
                    sql += "       [Comments]   = '" & DGV1.Rows(i).Cells("備註").Value() & "'         "
                    sql += " WHERE [Unit]       = '" & Unit.Text & "' AND [ItemName] = '" & ItemName.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "' AND [Week] = '" & Week1.Text & "'  "
                End If


                If DGV1.Rows(i).Cells("週別").Value = "2" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    sql += " UPDATE [KaiShingPlug].[dbo].[Z_KS_QtyDifference] SET "
                    sql += "       [Unit]       = '" & DGV1.Rows(i).Cells("單位").Value() & "'       , "
                    sql += "       [ItemName]   = '" & DGV1.Rows(i).Cells("品項").Value() & "'       , "
                    sql += "       [Year]       = '" & DGV1.Rows(i).Cells("年度").Value() & "'       , "
                    sql += "       [Month]      = '" & DGV1.Rows(i).Cells("月份").Value() & "'       , "
                    sql += "       [FromDate]   = '" & DGV1.Rows(i).Cells("起始日").Value() & "'     , "
                    sql += "       [ToDate]     = '" & DGV1.Rows(i).Cells("結束日").Value() & "'     , "
                    sql += "       [ReckonQty]  = '" & DGV1.Rows(i).Cells("預估數量").Value() & "'   , "
                    sql += "       [RealQty]    = '" & DGV1.Rows(i).Cells("實際數量").Value() & "'   , "
                    sql += "       [Comments]   = '" & DGV1.Rows(i).Cells("備註").Value() & "'         "
                    sql += " WHERE [Unit]       = '" & Unit.Text & "' AND [ItemName] = '" & ItemName.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "' AND [Week] = '" & Week2.Text & "'  "
                End If

                If DGV1.Rows(i).Cells("週別").Value = "3" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    sql += " UPDATE [KaiShingPlug].[dbo].[Z_KS_QtyDifference] SET "
                    sql += "       [Unit]       = '" & DGV1.Rows(i).Cells("單位").Value() & "'       , "
                    sql += "       [ItemName]   = '" & DGV1.Rows(i).Cells("品項").Value() & "'       , "
                    sql += "       [Year]       = '" & DGV1.Rows(i).Cells("年度").Value() & "'       , "
                    sql += "       [Month]      = '" & DGV1.Rows(i).Cells("月份").Value() & "'       , "
                    sql += "       [FromDate]   = '" & DGV1.Rows(i).Cells("起始日").Value() & "'     , "
                    sql += "       [ToDate]     = '" & DGV1.Rows(i).Cells("結束日").Value() & "'     , "
                    sql += "       [ReckonQty]  = '" & DGV1.Rows(i).Cells("預估數量").Value() & "'   , "
                    sql += "       [RealQty]    = '" & DGV1.Rows(i).Cells("實際數量").Value() & "'   , "
                    sql += "       [Comments]   = '" & DGV1.Rows(i).Cells("備註").Value() & "'         "
                    sql += " WHERE [Unit]       = '" & Unit.Text & "' AND [ItemName] = '" & ItemName.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "' AND [Week] = '" & Week3.Text & "'  "
                End If

                If DGV1.Rows(i).Cells("週別").Value = "4" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    sql += " UPDATE [KaiShingPlug].[dbo].[Z_KS_QtyDifference] SET "
                    sql += "       [Unit]       = '" & DGV1.Rows(i).Cells("單位").Value() & "'       , "
                    sql += "       [ItemName]   = '" & DGV1.Rows(i).Cells("品項").Value() & "'       , "
                    sql += "       [Year]       = '" & DGV1.Rows(i).Cells("年度").Value() & "'       , "
                    sql += "       [Month]      = '" & DGV1.Rows(i).Cells("月份").Value() & "'       , "
                    sql += "       [FromDate]   = '" & DGV1.Rows(i).Cells("起始日").Value() & "'     , "
                    sql += "       [ToDate]     = '" & DGV1.Rows(i).Cells("結束日").Value() & "'     , "
                    sql += "       [ReckonQty]  = '" & DGV1.Rows(i).Cells("預估數量").Value() & "'   , "
                    sql += "       [RealQty]    = '" & DGV1.Rows(i).Cells("實際數量").Value() & "'   , "
                    sql += "       [Comments]   = '" & DGV1.Rows(i).Cells("備註").Value() & "'         "
                    sql += " WHERE [Unit]       = '" & Unit.Text & "' AND [ItemName] = '" & ItemName.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "' AND [Week] = '" & Week4.Text & "'  "
                End If

                If DGV1.Rows(i).Cells("週別").Value = "5" And (Trim(DGV1.Rows(i).Cells("單位").Value) = Unit.Text) And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                    sql += " UPDATE [KaiShingPlug].[dbo].[Z_KS_QtyDifference] SET "
                    sql += "       [Unit]       = '" & DGV1.Rows(i).Cells("單位").Value() & "'       , "
                    sql += "       [ItemName]   = '" & DGV1.Rows(i).Cells("品項").Value() & "'       , "
                    sql += "       [Year]       = '" & DGV1.Rows(i).Cells("年度").Value() & "'       , "
                    sql += "       [Month]      = '" & DGV1.Rows(i).Cells("月份").Value() & "'       , "
                    sql += "       [FromDate]   = '" & DGV1.Rows(i).Cells("起始日").Value() & "'     , "
                    sql += "       [ToDate]     = '" & DGV1.Rows(i).Cells("結束日").Value() & "'     , "
                    sql += "       [ReckonQty]  = '" & DGV1.Rows(i).Cells("預估數量").Value() & "'   , "
                    sql += "       [RealQty]    = '" & DGV1.Rows(i).Cells("實際數量").Value() & "'   , "
                    sql += "       [Comments]   = '" & DGV1.Rows(i).Cells("備註").Value() & "'         "
                    sql += " WHERE [Unit]       = '" & Unit.Text & "' AND [ItemName] = '" & ItemName.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "' AND [Week] = '" & Week5.Text & "'  "
                End If


                'sql += "       [FromDate]       = '" & DGV1.Rows(i).Cells("起始日").Value() & "'     , "
                'sql += "       [ToDate]     = '" & DGV1.Rows(i).Cells("結束日").Value() & "'     , "
                'sql += "       [ReckonQty]  = '" & DGV1.Rows(i).Cells("預估數量").Value() & "'    ,   "
                'sql += "       [RealQty]  = '" & DGV1.Rows(i).Cells("實際數量").Value() & "'    ,   "
                'sql += "       [Comments]  = '" & DGV1.Rows(i).Cells("備註").Value() & "'       "
                'sql += " WHERE [ItemName] = '" & ItemName.Text & "' AND [Year] = '" & Year.Text & "' AND [Month] = '" & Month.Text & "'  "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        If 修改.Enabled = False Then

            Unit.Text = ""
            ItemName.Text = ""
            Year.Text = ""
            Month.Text = ""
            FromDate1.Text = ""
            FromDate2.Text = ""
            FromDate3.Text = ""
            FromDate4.Text = ""
            FromDate5.Text = ""
            ToDate1.Text = ""
            ToDate2.Text = ""
            ToDate3.Text = ""
            ToDate4.Text = ""
            ToDate5.Text = ""
            ReckonQty1.Text = ""
            ReckonQty2.Text = ""
            ReckonQty3.Text = ""
            ReckonQty4.Text = ""
            ReckonQty5.Text = ""
            RealQty1.Text = ""
            RealQty2.Text = ""
            RealQty3.Text = ""
            RealQty4.Text = ""
            RealQty5.Text = ""
            Comments1.Text = ""
            Comments2.Text = ""
            Comments3.Text = ""
            Comments4.Text = ""
            Comments5.Text = ""

            Unit.Text = DGV1.CurrentRow.Cells("單位").Value
            ItemName.Text = DGV1.CurrentRow.Cells("品項").Value
            Year.Text = DGV1.CurrentRow.Cells("年度").Value
            Month.Text = DGV1.CurrentRow.Cells("月份").Value


            For i As Integer = 0 To DGV1.RowCount - 1
                If (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then

                    If DGV1.Rows(i).Cells("週別").Value = "1" And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                        FromDate1.Text = DGV1.Rows(i).Cells("起始日").Value
                        ToDate1.Text = DGV1.Rows(i).Cells("結束日").Value
                        ReckonQty1.Text = DGV1.Rows(i).Cells("預估數量").Value
                        RealQty1.Text = DGV1.Rows(i).Cells("實際數量").Value
                        Comments1.Text = DGV1.Rows(i).Cells("備註").Value
                    End If

                    If DGV1.Rows(i).Cells("週別").Value = "2" And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                        FromDate2.Text = DGV1.Rows(i).Cells("起始日").Value
                        ToDate2.Text = DGV1.Rows(i).Cells("結束日").Value
                        ReckonQty2.Text = DGV1.Rows(i).Cells("預估數量").Value
                        RealQty2.Text = DGV1.Rows(i).Cells("實際數量").Value
                        Comments2.Text = DGV1.Rows(i).Cells("備註").Value
                    End If

                    If DGV1.Rows(i).Cells("週別").Value = "3" And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                        FromDate3.Text = DGV1.Rows(i).Cells("起始日").Value
                        ToDate3.Text = DGV1.Rows(i).Cells("結束日").Value
                        ReckonQty3.Text = DGV1.Rows(i).Cells("預估數量").Value
                        RealQty3.Text = DGV1.Rows(i).Cells("實際數量").Value
                        Comments3.Text = DGV1.Rows(i).Cells("備註").Value
                    End If

                    If DGV1.Rows(i).Cells("週別").Value = "4" And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                        FromDate4.Text = DGV1.Rows(i).Cells("起始日").Value
                        ToDate4.Text = DGV1.Rows(i).Cells("結束日").Value
                        ReckonQty4.Text = DGV1.Rows(i).Cells("預估數量").Value
                        RealQty4.Text = DGV1.Rows(i).Cells("實際數量").Value
                        Comments4.Text = DGV1.Rows(i).Cells("備註").Value
                    End If

                    If DGV1.Rows(i).Cells("週別").Value = "5" And (Trim(DGV1.Rows(i).Cells("品項").Value) = ItemName.Text) And (Trim(DGV1.Rows(i).Cells("年度").Value) = Year.Text) And (Trim(DGV1.Rows(i).Cells("月份").Value) = Month.Text) Then
                        FromDate5.Text = DGV1.Rows(i).Cells("起始日").Value
                        ToDate5.Text = DGV1.Rows(i).Cells("結束日").Value
                        ReckonQty5.Text = DGV1.Rows(i).Cells("預估數量").Value
                        RealQty5.Text = DGV1.Rows(i).Cells("實際數量").Value
                        Comments5.Text = DGV1.Rows(i).Cells("備註").Value
                    End If

                End If
            Next

            'If DGV1.CurrentRow.Cells("週別").Value = 1 Then
            '    FromDate1.Text = DGV1.CurrentRow.Cells("起始日").Value
            '    ToDate1.Text = DGV1.CurrentRow.Cells("結束日").Value
            'End If

            'If DGV1.CurrentRow.Cells("週別").Value = 2 Then
            '    FromDate2.Text = DGV1.CurrentRow.Cells("起始日").Value
            '    ToDate2.Text = DGV1.CurrentRow.Cells("結束日").Value
            'End If

        End If

    End Sub

    Private Sub 查詢2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢2.Click

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If


        '取得查詢資料
        GetDGV2Data()


        'For i As Integer = 0 To DGV2.RowCount - 1

        '    If DGV2.Rows(i).Cells("第1週 差異數").Value Is  DBNull.Value Then
        '        Me.DGV2.Columns("第1週 差異數").Visible = False
        '    End If

        '    If DGV2.Rows(i).Cells("第5週 差異數").Value Is DBNull.Value Then
        '        Me.DGV2.Columns("第5週 差異數").Visible = False
        '    End If
        'Next

    End Sub

    Private Sub GetDGV2Data()  '取得查詢資料

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "EXEC [dbo].[數量差異表] '" & Unit2.Text & "' , '" & Year2.Text & "' , '" & Month2.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()
        End Using

        DGV2Display()

    End Sub

    Private Sub DGV2Display()  '載入DGV2資料畫面

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "單位"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "品項"
                    column.HeaderText = "品項"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "年度"
                    column.HeaderText = " 年度"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "月份"
                    column.HeaderText = "月份"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "第1週 預估數"
                    column.HeaderText = "第1週 預估數"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "第1週 實際數"
                    column.HeaderText = "第1週 實際數"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case "第1週 差異數"
                    column.HeaderText = "第1週 差異數"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "第2週 預估數"
                    column.HeaderText = "第2週 預估數"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case "第2週 實際數"
                    column.HeaderText = "第2週 實際數"
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                Case "第2週 差異數"
                    column.HeaderText = "第2週 差異數"
                    column.DisplayIndex = 9
                    column.ReadOnly = True
                Case "第3週 預估數"
                    column.HeaderText = "第3週 預估數"
                    column.DisplayIndex = 10
                    column.ReadOnly = True
                Case "第3週 實際數"
                    column.HeaderText = "第3週 實際數"
                    column.DisplayIndex = 11
                    column.ReadOnly = True
                Case "第3週 差異數"
                    column.HeaderText = "第3週 差異數"
                    column.DisplayIndex = 12
                    column.ReadOnly = True
                Case "第4週 預估數"
                    column.HeaderText = "第4週 預估數"
                    column.DisplayIndex = 13
                    column.ReadOnly = True
                Case "第4週 實際數"
                    column.HeaderText = "第4週 實際數"
                    column.DisplayIndex = 14
                    column.ReadOnly = True
                Case "第4週 差異數"
                    column.HeaderText = "第4週 差異數"
                    column.DisplayIndex = 15
                    column.ReadOnly = True
                Case "第5週 預估數"
                    column.HeaderText = "第5週 預估數"
                    column.DisplayIndex = 16
                    column.ReadOnly = True
                Case "第5週 實際數"
                    column.HeaderText = "第5週 實際數"
                    column.DisplayIndex = 17
                    column.ReadOnly = True
                Case "第5週 差異數"
                    column.HeaderText = "第5週 差異數"
                    column.DisplayIndex = 18
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.AutoResizeColumns()

    End Sub
End Class