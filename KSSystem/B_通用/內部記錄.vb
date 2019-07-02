Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns
Imports System.Linq

Public Class 內部記錄
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim Dates As DateTime
    Dim 客戶別選舉 As String = ""
    Dim 超過十分 As String = "N"
    Dim 是否接聽 As String = "N"
    Dim 回覆分鐘 As SByte = 0
    Dim 事件T11s As String = ""
    Dim 回覆T11s As String = ""
    Dim 回覆T12s As String = ""
    Dim 回覆T12t As String = ""
    Dim 記錄時間DT1 As DateTime = Now()
    Dim 記錄時間DT2 As String = ""


    Private Sub 內部記錄_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        姓名T1.Text = IDName
        記錄時間T1.Text = ""
        記錄編號T1.Text = ""
        原始編號T1.Text = ""
        記錄編號T2.Text = ""
        原始編號T2.Text = ""
        回覆時間止.Text = ""
        '記錄時間T1.Text = Format(Now(), "yyyy-MM-dd hh:mm:ss")

        下拉選單事件T11初始化()
        下拉選單回覆T12初始化()

    End Sub

    Private Sub 資料初始化()
        事件T11s = ""
        回覆T11s = ""
        回覆T12s = ""
        回覆T12t = ""
        重新人員T1.Checked = False : 重新時間T1.Checked = False
        記錄編號T1.Text = "" : 記錄編號T2.Text = "" : 記錄時間T1.Text = "" : 客戶名稱T1.Text = "" : 客戶需求T1.Text = ""
        事件T11.Text = ""
        事件T12.Items.Clear()
        事件T12.Items.Add("")
        事件T12.Text = ""
        事件T13.Text = ""
        回覆T11.Text = "" : 回覆T12.Text = "" : 回覆T13.Text = "" : 回覆時間止.Text = ""
        超過十分 = "N" : 是否接聽 = "N"
        RB1別類1.Checked = False : RB1別類2.Checked = False : RB1別類3.Checked = False : RB1別類4.Checked = False
        RB1別類5.Checked = False : RB1別類6.Checked = False : RB1別類7.Checked = False : RB1別類8.Checked = False
        RB2Yes.Checked = False : RB2No.Checked = True
        RB3Yes.Checked = False : RB3No.Checked = False
        RB3回覆1.Checked = False : RB3回覆2.Checked = False : RB3回覆3.Checked = False

    End Sub

    Private Sub 資料初始化_存檔或放棄()
        記錄編號T1.Enabled = True
        客戶名稱T1.Enabled = True
        客戶需求T1.Enabled = True
        事件T11.Enabled = True
        事件T12.Enabled = True
        '事件T13.Enabled = True
        事件T13.ReadOnly = False
        回覆T11.Enabled = True
        回覆T12.Enabled = True

        Label8.Visible = False
        回覆T13.Visible = False
        存檔T11.Visible = True
        存檔T12.Visible = False
        存檔T13.Visible = False
        回覆時間止.Visible = False

        PL1來源.Enabled = True
        PL2超過.Visible = True
        PL3接通.Visible = True
        PL4回覆.Visible = False

        重新人員T1.Visible = False
        重新時間T1.Visible = False
        Label13.Visible = False

    End Sub
    Private Sub 下拉選單事件T11初始化2() '事件T11 = 單位
        來源T11.Items.Clear()
        來源T11.Items.Add("")
        來源T11.Items.Add("客戶")
        來源T11.Items.Add("廠商")
        來源T11.Items.Add("主管")
        來源T11.Items.Add("加工")
        來源T11.Items.Add("員工")
        來源T11.Items.Add("銀行")
        來源T11.Items.Add("不清楚")

    End Sub

    Private Sub 下拉選單事件T11初始化() '事件T11 = 單位
        事件T11.Items.Clear()
        事件T11.Items.Add("")
        事件T11.Items.Add("營業")
        事件T11.Items.Add("契養")
        事件T11.Items.Add("採購")
        事件T11.Items.Add("人事")
        事件T11.Items.Add("總務")
        事件T11.Items.Add("會計")
        事件T11.Items.Add("生產")
        事件T11.Items.Add("生管")
        事件T11.Items.Add("倉儲")
        事件T11.Items.Add("品管")
        事件T11.Items.Add("資訊")
        事件T11.Items.Add("加工")
        事件T11.Items.Add("設計")
        事件T11.Items.Add("研發")
        事件T11.Items.Add("統籌中心")
        事件T11.Items.Add("總經理室")

    End Sub

    Private Sub 下拉選單事件T12初始化() '事件T12 = 事件
        事件T12.Items.Clear()
        '事件T12.SelectedIndex = 0
        Select Case 事件T11.Text
            Case "營業"
                事件T12.Items.Add("")
                事件T12.Items.Add("訂單")
                事件T12.Items.Add("報價")
                事件T12.Items.Add("客訴")
            Case "採購"
                事件T12.Items.Add("")
                事件T12.Items.Add("報價")
            Case "人事"
                事件T12.Items.Add("")
                事件T12.Items.Add("面試")
            Case Else
                事件T12.Items.Add("")
        End Select
        下拉選單事件T12初始化2()

    End Sub

    Private Sub 下拉選單事件T12初始化2() '事件T12 = 事件
        事件T12.Items.Add("請回電")
        事件T12.Items.Add("傳真")
        事件T12.Items.Add("其他")

    End Sub

    Private Sub 下拉選單回覆T12初始化() '回覆T12 = 回覆時間
        回覆T12.Items.Clear()
        回覆T12.Items.Add("")
        回覆T12.Items.Add("半小時內")
        回覆T12.Items.Add("一小時內")
        回覆T12.Items.Add("二小時內")
        回覆T12.Items.Add("三小時內")
        回覆T12.Items.Add("四小時內")
        回覆T12.Items.Add("今下班前")
        回覆T12.Items.Add("二天內回")
        回覆T12.Items.Add("三天內回")

    End Sub

    Private Sub 下拉選單回覆T12初始化2() '回覆T12 = 回覆時間
        'Dim 記錄時間DT1 As DateTime = Now()
        'Dim 記錄時間DT2 As String = ""
        '記錄時間DT1 = Format(Now(), "yyyy-MM-dd hh:mm:ss")
        記錄時間DT1 = Now()
        記錄時間T1.Text = Format(記錄時間DT1, "yyyy-MM-dd HH:mm:ss")

        Select Case 回覆T12.SelectedIndex
            Case "1" : 記錄時間DT2 = Format(記錄時間DT1.AddMinutes(30), "yyyy-MM-dd HH:mm:ss") '30分
            Case "2" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(1), "yyyy-MM-dd HH:mm:ss")    '01時
            Case "3" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(2), "yyyy-MM-dd HH:mm:ss")    '02時
            Case "4" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(3), "yyyy-MM-dd HH:mm:ss")    '03時
            Case "5" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(4), "yyyy-MM-dd HH:mm:ss")    '04時
            Case "6" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(0), "yyyy-MM-dd 17:00:00")     '今下班前(0天
            Case "7" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(1), "yyyy-MM-dd 17:00:00")     '二天內回(2天
            Case "8" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(2), "yyyy-MM-dd 17:00:00")     '三天內回(3天
        End Select

        'MsgBox(記錄時間DT1 & vbCrLf & 記錄時間DT2)

    End Sub

    Private Sub 載入單位人員回覆T11()
        If ks1DataSetDGV.Tables.Contains("姓名T11") Then
            ks1DataSetDGV.Tables("姓名T11").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Try
            SQLCmd.CommandText = "  SELECT ''      AS '姓名' "
            SQLCmd.CommandText += " UNION ALL "
            SQLCmd.CommandText += " SELECT [LOG07] AS '姓名' FROM [@kslogin] WHERE [LOG09] = '" & 事件T11.Text & "' AND [LOG08] = '1' AND [LOG05] = 'Y' "

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "姓名T11")

            If ks1DataSetDGV.Tables("姓名T11").Rows.Count > 0 Then

                回覆T11.DataSource = ks1DataSetDGV.Tables("姓名T11")
                回覆T11.DisplayMember = "姓名"
                回覆T11.SelectedIndex = -1
            Else
                回覆T11.Text = ""
                'MsgBox("無單位人員資料")

            End If
        Catch ex As Exception
            MsgBox("人員資料: " & ex.Message)
            End
        End Try

    End Sub

    Private Sub 事件T11_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 事件T11.SelectedIndexChanged
        下拉選單事件T12初始化()
        載入單位人員回覆T11()

    End Sub

    Private Sub 存檔T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔T11.Click

        If RB1別類1.Checked = False And RB1別類2.Checked = False And RB1別類3.Checked = False And RB1別類4.Checked = False And _
           RB1別類5.Checked = False And RB1別類6.Checked = False And RB1別類7.Checked = False And RB1別類8.Checked = False Then : MsgBox("資料輸入不完全，請檢查") : Exit Sub : End If
        If RB2Yes.Checked = False And RB2No.Checked = False Then : MsgBox("資料輸入不完全，請檢查") : Exit Sub : End If
        If RB3Yes.Checked = False And RB3No.Checked = False Then : MsgBox("資料輸入不完全，請檢查") : Exit Sub : End If
        'If 事件T11.Text = "" Or 事件T12.Text = "" Or 事件T13.Text = "" Or 回覆T12.Text = "" Then : MsgBox("資料輸入不完全，請檢查") : Exit Sub : End If
        If 事件T11.Text = "" Then : MsgBox("資料輸入不完全，請檢查") : Exit Sub : End If

        If RB3Yes.Checked = False Then
            If 事件T12.Text = "" Or 事件T13.Text = "" Or 回覆T12.Text = "" Then : MsgBox("資料輸入不完全，請檢查") : Exit Sub : End If
        End If


        If RB1別類1.Checked = True Then : 客戶別選舉 = RB1別類1.Text : End If
        If RB1別類2.Checked = True Then : 客戶別選舉 = RB1別類2.Text : End If
        If RB1別類3.Checked = True Then : 客戶別選舉 = RB1別類3.Text : End If
        If RB1別類4.Checked = True Then : 客戶別選舉 = RB1別類4.Text : End If
        If RB1別類5.Checked = True Then : 客戶別選舉 = RB1別類5.Text : End If
        If RB1別類6.Checked = True Then : 客戶別選舉 = RB1別類6.Text : End If
        If RB1別類7.Checked = True Then : 客戶別選舉 = RB1別類7.Text : End If
        If RB1別類8.Checked = True Then : 客戶別選舉 = RB1別類8.Text : End If

        記錄存檔T1() : 資料初始化()
        MsgBox("存錄完成")

    End Sub

    Private Sub 記錄存檔T1()
        Dim DBConn1 As SqlConnection = Login.DBConn
        Dim SQLCmd1 As SqlCommand = New SqlCommand

        'Dim 記錄時間DT1 As DateTime = Now()
        'Dim 記錄時間DT2 As String = ""
        ''記錄時間DT1 = Format(Now(), "yyyy-MM-dd hh:mm:ss")
        '記錄時間T1.Text = Format(記錄時間DT1, "yyyy-MM-dd HH:mm:ss")

        'Select Case 回覆T12.SelectedIndex
        '    Case "1" : 記錄時間DT2 = Format(記錄時間DT1.AddMinutes(30), "yyyy-MM-dd HH:mm:ss") '30分
        '    Case "2" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(1), "yyyy-MM-dd HH:mm:ss")    '01時
        '    Case "3" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(2), "yyyy-MM-dd HH:mm:ss")    '02時
        '    Case "4" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(3), "yyyy-MM-dd HH:mm:ss")    '03時
        '    Case "5" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(4), "yyyy-MM-dd HH:mm:ss")    '04時
        '    Case "6" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(0), "yyyy-MM-dd 17:00:00")     '今下班前(0天
        '    Case "7" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(1), "yyyy-MM-dd 17:00:00")     '二天內回(2天
        '    Case "8" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(2), "yyyy-MM-dd 17:00:00")     '三天內回(3天
        'End Select

        ''MsgBox(記錄時間DT1 & vbCrLf & 記錄時間DT2)

        下拉選單回覆T12初始化2()

        If RB2Yes.Checked = True Then : 超過十分 = "Y" : End If
        If RB3Yes.Checked = True Then : 是否接聽 = "O" : End If

        Try
            SQLCmd1.Connection = DBConn1

            SQLCmd1.CommandText = "   INSERT INTO [KaiShingPlug].[dbo].[KS_MessageReport] "
            SQLCmd1.CommandText += "  ([IDs],[Operator],[WiringTime],[WiringTime2],[CardName],[ReplyUnits],[DemandEvents],[DemandContent],[ReplyStaff],[ReplyTime1],[ReplyTime2],[Cancel]) VALUES "
            SQLCmd1.CommandText += "  (''                        , " 'IDs
            SQLCmd1.CommandText += "   '" & 姓名T1.Text & "'     , " 'Operator      接線人員
            SQLCmd1.CommandText += "   '" & 記錄時間T1.Text & "' , " 'WiringTime    接線時間
            SQLCmd1.CommandText += "   '" & 超過十分 & "'        , " 'WiringTime2   接線時間_是否超過10分鐘	Y=是, N=否
            SQLCmd1.CommandText += "   '" & 客戶別選舉 & "'      , " 'CardName      客戶別類
            SQLCmd1.CommandText += "   '" & 事件T11.Text & "'    , " 'ReplyUnits    回覆單位
            SQLCmd1.CommandText += "   '" & 事件T12.Text & "'    , " 'DemandEvents  需求事件
            SQLCmd1.CommandText += "   '" & 事件T13.Text & "'    , " 'DemandContent 需求內容
            SQLCmd1.CommandText += "   '" & 回覆T11.Text & "'    , " 'ReplyStaff    回覆人員
            SQLCmd1.CommandText += "   '" & 回覆T12.Text & "'    , " 'ReplyTime1    回覆時間_指定
            SQLCmd1.CommandText += "   '" & 記錄時間DT2 & "'     , " 'ReplyTime2    回覆時間_預計
            SQLCmd1.CommandText += "   '" & 是否接聽 & "' )        " 'Cancel        是否結束	Y=已回, N=未回, O=已接聽	20140916

            SQLCmd1.Parameters.Clear()
            SQLCmd1.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 查詢T1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢T1.Click

        查詢需回覆記錄()

        Me.TabControl1.SelectedTab = Me.TabPage2
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub 查詢需回覆記錄()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV1").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT [ID] AS '記錄編號', [IDs] AS '原始編號', [CardName] AS '客戶別類', [DemandEvents] AS '分類事件', [DemandContent] AS '記載內容', [ReplyUnits] AS '回覆單位', "
            SQLCmd.CommandText += "          [ReplyStaff] AS '回覆人員', [ReplyTime1] AS '指定時間', [ReplyTime2] AS '回覆時間', [Operator] AS '記錄人員', [WiringTime] AS '記錄時間' "
            SQLCmd.CommandText += "     FROM [KaiShingPlug].[dbo].[KS_MessageReport] "
            'SQLCmd.CommandText += "    WHERE [ReplyUnits] = '" & IDLog09 & "' AND [ReplyStaff] IN ('" & IDName & "','') AND [Cancel] = 'N' "
            SQLCmd.CommandText += "    WHERE [ReplyUnits] = '" & IDLog09 & "' AND [Cancel] = 'N' "
            SQLCmd.CommandText += " ORDER BY 11 "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        查詢需回覆記錄_Play()

    End Sub

    Private Sub 查詢需回覆記錄_Play()
        '--載入資料畫面
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "記錄編號" : column.HeaderText = "記錄編號" : column.DisplayIndex = 0 : column.Visible = False
                Case "原始編號" : column.HeaderText = "原始編號" : column.DisplayIndex = 1 : column.Visible = False

                Case "客戶別類" : column.HeaderText = "客戶別類" : column.DisplayIndex = 2
                Case "分類事件" : column.HeaderText = "分類事件" : column.DisplayIndex = 3
                Case "記載內容" : column.HeaderText = "記載內容" : column.DisplayIndex = 4
                Case "回覆單位" : column.HeaderText = "回覆單位" : column.DisplayIndex = 5
                Case "回覆人員" : column.HeaderText = "回覆人員" : column.DisplayIndex = 6
                Case "指定時間" : column.HeaderText = "指定時間" : column.DisplayIndex = 7
                Case "回覆時間" : column.HeaderText = "回覆時間" : column.DisplayIndex = 8
                Case "記錄人員" : column.HeaderText = "記錄人員" : column.DisplayIndex = 9
                Case "記錄時間" : column.HeaderText = "記錄時間" : column.DisplayIndex = 10

                Case Else
                    column.Visible = False

            End Select
        Next

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        記錄編號T2.Text = DGV1.CurrentRow.Cells("記錄編號").Value
        原始編號T2.Text = DGV1.CurrentRow.Cells("原始編號").Value
    End Sub

    Private Sub 回覆T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 回覆T2.Click
        If DGV1.RowCount = -1 Then : Exit Sub : End If      '無資料不執行下方
        If 記錄編號T2.Text = "" Then : MsgBox("未選資料") : Exit Sub : End If      '無資料不執行下方

        RB1別類1.Checked = False : RB1別類2.Checked = False : RB1別類3.Checked = False : RB1別類7.Checked = False : RB1別類8.Checked = False
        RB2Yes.Checked = False : RB2No.Checked = False
        RB3Yes.Checked = False : RB3No.Checked = False

        記錄編號T1.Text = DGV1.CurrentRow.Cells("記錄編號").Value
        原始編號T1.Text = DGV1.CurrentRow.Cells("原始編號").Value
        '客戶名稱T1.Text = DGV1.CurrentRow.Cells("客戶別類").Value
        Select Case DGV1.CurrentRow.Cells("客戶別類").Value
            Case "客戶" : RB1別類1.Checked = True
            Case "廠商" : RB1別類2.Checked = True
            Case "主管" : RB1別類3.Checked = True
            Case "加工" : RB1別類4.Checked = True
            Case "員工" : RB1別類5.Checked = True
            Case "銀行" : RB1別類6.Checked = True
            Case "其他" : RB1別類7.Checked = True
            Case "不清楚" : RB1別類8.Checked = True
            Case Else : RB1別類8.Checked = True
        End Select
        '客戶需求T1.Text = DGV1.CurrentRow.Cells("客戶需求").Value
        事件T11.Text = DGV1.CurrentRow.Cells("回覆單位").Value
        事件T12.Text = DGV1.CurrentRow.Cells("分類事件").Value
        事件T13.Text = DGV1.CurrentRow.Cells("記載內容").Value
        回覆T11.Text = DGV1.CurrentRow.Cells("回覆人員").Value
        回覆T12.Text = DGV1.CurrentRow.Cells("指定時間").Value
        記錄時間T1.Text = Format(DGV1.CurrentRow.Cells("記錄時間").Value, "yyyy-MM-dd tt hh:mm:ss")
        回覆時間止.Text = "最終回覆時間" & vbCrLf & Format(DGV1.CurrentRow.Cells("回覆時間").Value, "yyyy-MM-dd tt hh:mm:ss")

        記錄編號T1.Enabled = False
        客戶名稱T1.Enabled = False
        客戶需求T1.Enabled = False
        事件T11.Enabled = False
        事件T12.Enabled = False
        '事件T13.Enabled = False
        事件T13.ReadOnly = True
        回覆T11.Enabled = False
        回覆T12.Enabled = False
        回覆T13.Enabled = False

        Label8.Visible = True
        回覆T13.Visible = True
        存檔T11.Visible = False
        存檔T12.Visible = True
        存檔T13.Visible = True
        回覆時間止.Visible = True

        PL1來源.Enabled = False
        PL2超過.Visible = False
        PL3接通.Visible = False
        PL4回覆.Visible = True

        重新人員T1.Visible = True
        重新時間T1.Visible = True
        Label13.Visible = True

        Me.TabControl1.SelectedTab = Me.TabPage1

    End Sub

    Private Sub 存檔T12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔T12.Click
        If 回覆T13.Text = "" Then : MsgBox("未輸入資料") : Exit Sub : End If

        If RB1別類1.Checked = True Then : 客戶別選舉 = RB1別類1.Text : End If
        If RB1別類2.Checked = True Then : 客戶別選舉 = RB1別類2.Text : End If
        If RB1別類3.Checked = True Then : 客戶別選舉 = RB1別類3.Text : End If
        If RB1別類4.Checked = True Then : 客戶別選舉 = RB1別類4.Text : End If
        If RB1別類5.Checked = True Then : 客戶別選舉 = RB1別類5.Text : End If
        If RB1別類6.Checked = True Then : 客戶別選舉 = RB1別類6.Text : End If
        If RB1別類7.Checked = True Then : 客戶別選舉 = RB1別類7.Text : End If
        If RB1別類8.Checked = True Then : 客戶別選舉 = RB1別類8.Text : End If

        回覆T13更新記錄()
        資料初始化_存檔或放棄()
        資料初始化()

    End Sub

    Private Sub 存檔T13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔T13.Click
        資料初始化_存檔或放棄()
        資料初始化()

    End Sub

    Private Sub 回覆T13更新記錄()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim 實回人員 As String = ""
        If 回覆T11.Text = "" Then
            實回人員 = "實際回覆人員：" + 姓名T1.Text
        End If

        Try
            SQLCmd.Connection = DBConn
            If 重新人員T1.Checked = True Or 重新時間T1.Checked = True Then
                Dim 編號T1 As String = ""
                If 原始編號T1.Text = "0" Then : 編號T1 = 記錄編號T1.Text : Else : 編號T1 = 原始編號T1.Text : End If

                'Dim 記錄時間DT1 As DateTime = Now()
                'Dim 記錄時間DT2 As String = ""
                '記錄時間T1.Text = Format(記錄時間DT1, "yyyy-MM-dd HH:mm:ss")

                'Select Case 回覆T12.SelectedIndex
                '    Case "1" : 記錄時間DT2 = Format(記錄時間DT1.AddMinutes(30), "yyyy-MM-dd HH:mm:ss") '30分
                '    Case "2" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(1), "yyyy-MM-dd HH:mm:ss")    '01時
                '    Case "3" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(2), "yyyy-MM-dd HH:mm:ss")    '02時
                '    Case "4" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(3), "yyyy-MM-dd HH:mm:ss")    '03時
                '    Case "5" : 記錄時間DT2 = Format(記錄時間DT1.AddHours(4), "yyyy-MM-dd HH:mm:ss")    '04時
                '    Case "6" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(0), "yyyy-MM-dd 17:00:00")     '今下班前(0天
                '    Case "7" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(1), "yyyy-MM-dd 17:00:00")     '二天內回(2天
                '    Case "8" : 記錄時間DT2 = Format(記錄時間DT1.AddDays(2), "yyyy-MM-dd 17:00:00")     '三天內回(3天
                'End Select

                ''MsgBox(記錄時間DT1 & vbCrLf & 記錄時間DT2)

                下拉選單回覆T12初始化2()

                SQLCmd.CommandText = "   INSERT INTO [KaiShingPlug].[dbo].[KS_MessageReport] "
                SQLCmd.CommandText += "  ([IDs],[Operator],[WiringTime],[CardName],[ReplyUnits],[DemandEvents],[DemandContent],[ReplyStaff],[ReplyTime1],[ReplyTime2],[Cancel]) VALUES "
                SQLCmd.CommandText += "  ('" & 編號T1 & "'          , " 'IDs
                SQLCmd.CommandText += "   '" & 姓名T1.Text & "'     , " 'Operator      接線人員
                SQLCmd.CommandText += "   '" & 記錄時間T1.Text & "' , " 'WiringTime    接線時間
                'SQLCmd.CommandText += "   '" & 超過十分 & "'        , " 'WiringTime2   接線時間_是否超過10分鐘	Y=是, N=否
                SQLCmd.CommandText += "   '" & 客戶別選舉 & "'      , " 'CardName      客戶別類
                SQLCmd.CommandText += "   '" & 事件T11.Text & "'    , " 'ReplyUnits    回覆單位
                SQLCmd.CommandText += "   '" & 事件T12.Text & "'    , " 'DemandEvents  需求事件
                SQLCmd.CommandText += "   '" & 回覆T13.Text & "'    , " 'DemandContent 需求內容
                SQLCmd.CommandText += "   '" & 回覆T11.Text & "'    , " 'ReplyStaff    回覆人員
                SQLCmd.CommandText += "   '" & 回覆T12.Text & "'    , " 'ReplyTime1    回覆時間_指定
                SQLCmd.CommandText += "   '" & 記錄時間DT2 & "'     , " 'ReplyTime2    回覆時間_預計
                SQLCmd.CommandText += "   'N' )                       " 'Cancel        是否結束	Y=已回, N=未回, O=已接聽	20140916

                SQLCmd.CommandText += "   UPDATE [KaiShingPlug].[dbo].[KS_MessageReport]  "
                SQLCmd.CommandText += "      SET [ReplyContent] = '" & 回覆T13.Text + vbCrLf + 實回人員 & "', [ReplyTime3] = '" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "', [Cancel] = 'Y'  "
                SQLCmd.CommandText += "    WHERE [ID] = '" & 記錄編號T1.Text & "' "

            Else
                SQLCmd.CommandText = "    UPDATE [KaiShingPlug].[dbo].[KS_MessageReport]  "
                SQLCmd.CommandText += "      SET [ReplyContent] = '" & 回覆T13.Text + vbCrLf + 實回人員 & "', [ReplyTime3] = '" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "', [Cancel] = 'Y'  "
                SQLCmd.CommandText += "    WHERE [ID] = '" & 記錄編號T1.Text & "' "

            End If

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 回去T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 回去T2.Click
        記錄編號T1.Text = ""
        Me.TabControl1.SelectedTab = Me.TabPage1

    End Sub

    Private Sub 重新人員T1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重新人員T1.CheckedChanged
        If 重新人員T1.Checked = True Then
            回覆T11s = 回覆T11.Text
            回覆T11.Enabled = True
            回覆T11.Text = ""
            事件T11s = 事件T11.Text
            事件T11.Enabled = True
            '事件T11.Text = ""
        Else
            事件T11.Text = 事件T11s
            事件T11.Enabled = False
            回覆T11.Text = 回覆T11s
            回覆T11.Enabled = False

        End If

    End Sub

    Private Sub 重新時間T1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重新時間T1.CheckedChanged
        If 重新時間T1.Checked = True Then
            回覆T12s = 回覆T12.Text
            回覆T12t = 回覆時間止.Text
            回覆T12.Enabled = True
            回覆時間止.Text = ""
        Else
            回覆T12.Text = 回覆T12s
            回覆時間止.Text = 回覆T12t
            回覆T12.Enabled = False
        End If

    End Sub



    Private Sub RB3回覆_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB3回覆1.CheckedChanged, RB3回覆2.CheckedChanged, RB3回覆3.CheckedChanged

        If RB3回覆1.Checked = True Then
            '回覆T13.Visible = False
            回覆T13.Enabled = False
            回覆T13.Text = "已回覆"
        End If

        If RB3回覆2.Checked = True Then
            '回覆T13.Visible = False
            回覆T13.Enabled = False
            回覆T13.Text = "已處理"
        End If

        If RB3回覆3.Checked = True Then
            '回覆T13.Visible = True
            回覆T13.Enabled = True
            回覆T13.Text = ""
        End If

    End Sub
End Class