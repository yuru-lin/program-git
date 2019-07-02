Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns

Public Class MainMenuList
    Dim GroupType As String

    Dim DataAdapter1 As SqlDataAdapter
    Dim PDA條碼明細 As DataSet = New DataSet
    Dim 電話留言明細 As DataSet = New DataSet
    Dim 提醒時間T1 As Integer = 9000   '(秒)
    Dim 提醒時間T2 As Integer = 6000   '(秒)

    Private Sub MainMenuList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChkStatusLabel()

        'MenuList上的使用者名稱

        CompanyName.Text = Login.LogonCompanyName
        DBName1 = Login.LogonCompanyName
        CompanyDB.Text = Login.LogonCompanyDB
        DBName2 = Login.LogonCompanyDB
        'Login.CompanyDGV.CurrentRow.Cells("資料庫").Value
        'CompanyDB1.Text = Login.LogonCompanySr

        GetUserName()

        GroupType = SetGroup(Login.LogonUserName)
        SetView()
        ChkStatusLabel()

        Select Case UCase(Login.LogonCompanySr) '主機名稱
            Case "192.168.0.110", "KS-SAP-DB", "MR-SAP", "192.168.200.110"
                Select Case Login.LogonCompanyDB    '資料庫名稱
                    Case "KaiShing", "kFS_00", "myanmar"
                        DBSr.Text = "正式"
                    Case Else
                        DBSr.Text = "測試"
                End Select
            Case Else
                DBSr.Text = "測試"
        End Select

        lbVersion2.Text = "時間：" + Format(FileDateTime(Application.StartupPath & "\" & "KSSystem.exe"), "MM/dd-hh:mm")

        '提醒時間
        'Select Case UCase(GetHostName())
        'Case "KS-F2", "MIS-03", "MIS-02", "KS-I11"
        'Case "KS-F1", "KS-F2", "KS-F6", "KS-F9", "KS-F5"
        'LogonUserName  LogonCompanyName

        Select Case UCase(Login.LogonUserName)
            Case "KS-10", "KS-16" ', "MANAGER"
                待入庫數提醒時間.Enabled = True
                PDA條碼明細View()
                'Case "MANAGER"
                '    參數區.Visible = True
            Case Else
                待入庫數提醒時間.Enabled = False
        End Select




        '限內部系統使用
        'If IDLog08 = 1 Then
        '    電話提醒時間.Enabled = True
        '    留言數量View2()
        '    'Select Case UCase(GetHostName())
        '    '    Case "KS-I1", "KS-I2", "KS-I6", "KS-I7", "KS-I8", "KS-A1", "KS-A2", "KS-A3", "KS-B1", "KS-B2", "KS-B5", "KS-I5", "NB-MICHELLE", "MIS-03"
        '    '        電話提醒時間.Enabled = True
        '    '        留言數量View2()
        '    '    Case Else
        '    '        電話提醒時間.Enabled = False
        '    'End Select
        'End If

        'Select Case UCase(Login.LogonUserName)
        '    Case "KS-14"
        '        Ck提醒.Visible = True
        '        Ck提醒.Checked = True
        '        即時時間.Enabled = True
        '        即時時間.Interval = 1000
        '        '參數區.Visible = True
        '    Case Else
        '        即時時間.Enabled = False
        '        Ck提醒.Visible = False
        '        Ck提醒.Checked = False
        'End Select
        '參數區.Visible = True
    End Sub

    Private Sub 即時時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 即時時間.Tick
        La時間.Text = Format(Now(), "yyyy-MM-dd HH:mm:ss")

        Select Case Format(Now(), "mm:ss") '依分秒為單位
            'Case "05:00", "10:00", "15:00", "20:00", "25:00", "30:00", "35:00", "40:00", "45:00", "50:00", "55:00", "00:00"
            Case "10:00", "20:00", "30:00", "40:00", "50:00", "00:00"
                生管領料核准作業()
        End Select

    End Sub

    Private Sub 生管領料核准作業()
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = " EXEC [dbo].[預_分時領料明細01v] 'AEA',N'',N'','" & Format(Today(), "yyyy-MM-dd") & "',NULL "

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(PDA條碼明細, "領料核准")
            'MsgBox(PDA條碼明細.Tables("領料核准").Rows.Count)
        Catch ex As Exception
            'MsgBox("PDA條碼明細：" & ex.Message)
            Exit Sub
        End Try

        If PDA條碼明細.Tables("領料核准").Rows.Count > 0 Then
            PDA條碼明細.Tables("領料核准").Clear()
            分時生管V001.MdiParent = MainForm
            分時生管V001.Show()
            分時生管V001.Activate()
            分時生管V001.Bu查詢.PerformClick()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '分時生管V001.MdiParent = MainForm
        '分時生管V001.Show()
        '分時生管V001.Activate()
        '分時生管V001.Bu查詢.PerformClick()
        生管領料核准作業()
    End Sub


    Private Sub PDA條碼明細View()

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "  SELECT [PDA04] FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE [PDA06] = '2' AND LEFT([PDA02],2) IN ('11','12') "

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(PDA條碼明細, "PDADGV1")
        Catch ex As Exception
            MsgBox("PDA條碼明細：" & ex.Message)
            Exit Sub
        End Try

        Dim sql2 As String = ""
        Dim DBConn2 As SqlConnection = Login.DBConn
        Try
            sql2 = "  SELECT [PDA04] FROM [KaiShingPlug].[dbo].[PDA_InData] WHERE [PDA06] = '2' AND LEFT([PDA02],2) IN ('21','22','24','25','31','32') "

            DataAdapter1 = New SqlDataAdapter(sql2, DBConn2)
            DataAdapter1.Fill(PDA條碼明細, "PDADGV2")
        Catch ex As Exception
            MsgBox("PDA條碼明細：" & ex.Message)
            Exit Sub
        End Try

        If (PDA條碼明細.Tables("PDADGV1").Rows.Count + PDA條碼明細.Tables("PDADGV2").Rows.Count) <= 0 Then
            'MsgBox("查無資料。", 48, "警告")
        Else
            PopupAlert()
        End If

        PDA條碼明細.Tables("PDADGV1").Clear()
        PDA條碼明細.Tables("PDADGV2").Clear()

    End Sub

    Private Sub 待入庫數提醒時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 待入庫數提醒時間.Tick
        If 提醒時間T1 >= 0 Then
            提醒時間s.Text = "自動化更新時間還有：" & 提醒時間T1 & "秒"
            提醒時間T1 = 提醒時間T1 - 1
        End If
        If 提醒時間T1 < 0 Then
            提醒時間s.Text = "同步中..."
            PDA條碼明細View()
            'PopupAlert()
            提醒時間T1 = 9000
        End If

        'Timer1.Enabled = False
    End Sub

    Private Sub PopupAlert()

        Dim CText As String = ""
        CText = "  您有  " & Format(CStr(PDA條碼明細.Tables("PDADGV1").Rows.Count), "") + "筆" + vbCrLf
        CText += " 待入庫條碼 " + vbCrLf
        CText += " 您有  " & Format(CStr(PDA條碼明細.Tables("PDADGV2").Rows.Count), "") + "筆" + vbCrLf
        CText += " 待出庫條碼" + vbCrLf
        CText += " 請迅速查看" + vbCrLf
        CText += " 辛苦啦啦啦" + vbCrLf
        CText += " 要快點入出庫哦哦哦"

        待入庫數提醒.TitleText = "待入出庫條碼提醒"
        待入庫數提醒.ContentText = CText
        待入庫數提醒.ShowDelay = 120000 '顯示時間1千=1秒
        待入庫數提醒.AnimationDelay = 5
        待入庫數提醒.Popup()

        AddHandler 待入庫數提醒.Close, AddressOf 待入庫數提醒_Close
        AddHandler 待入庫數提醒.Click, AddressOf 待入庫數提醒_Click

    End Sub

    Private Sub 待入庫數提醒_Click()
        If MainForm.WindowState <> FormWindowState.Maximized Then
            MainForm.WindowState = FormWindowState.Maximized
        End If
        If Me.WindowState <> FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()
        待入庫數提醒.hide()
    End Sub

    Private Sub 待入庫數提醒_Close()
        待入庫數提醒.hide()
    End Sub

    Private Sub 留言數量View2()

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "  SELECT COUNT([ReplyUnits]) AS '留言數量' FROM [KaiShingPlug].[dbo].[KS_MessageReport] WHERE [ReplyUnits] = '" & IDLog09 & "' AND [Cancel] = 'N' "

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(電話留言明細, "PhoneMessage")
        Catch ex As Exception
            MsgBox("電話留言明細：" & ex.Message)
            Exit Sub
        End Try

        'If 電話留言明細.Tables("PhoneMessage").Rows.Count <= 0 Then
        If 電話留言明細.Tables("PhoneMessage").Rows(0).Item("留言數量") = 0 Then
            'MsgBox("查無資料。", 48, "警告")
        Else
            PopupAlert2()
        End If

        電話留言明細.Tables("PhoneMessage").Clear()

    End Sub

    Private Sub 電話提醒時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 電話提醒時間.Tick
        If 提醒時間T2 >= 0 Then
            提醒時間2.Text = "自動化更新時間還有：" & 提醒時間T2 & "秒"
            提醒時間T2 = 提醒時間T2 - 1
        End If
        If 提醒時間T2 < 0 Then
            提醒時間2.Text = "同步中..."
            留言數量View2()
            'PopupAlert()
            提醒時間T2 = 6000
        End If

        'Timer1.Enabled = False
    End Sub

    Private Sub PopupAlert2()

        '電話留言明細.Tables("PhoneMessage").Rows(0).Item("留言數量")

        Dim CText As String = ""
        CText = "您單位留言數量" & vbCrLf
        CText += "有  " & Format(CStr(電話留言明細.Tables("PhoneMessage").Rows(0).Item("留言數量")), "") & "筆"

        'CText = "您單位留言數量有  " & Format(CStr(電話留言明細.Tables("PhoneMessage").Rows.Count), "") + "筆" '+ vbCrLf
        'CText += "留言數量 " + vbCrLf
        'CText += "請迅速查看" + vbCrLf
        'CText += "辛苦啦" + vbCrLf
        'CText += "要快點入庫哦"

        電話提醒畫面.TitleText = "留言數量"
        電話提醒畫面.ContentText = CText
        電話提醒畫面.ShowDelay = 120000 '顯示時間1千=1秒
        電話提醒畫面.AnimationDelay = 5
        電話提醒畫面.Popup()

        AddHandler 電話提醒畫面.Close, AddressOf 電話提醒畫面_Close
        AddHandler 電話提醒畫面.Click, AddressOf 電話提醒畫面_Click

    End Sub

    Private Sub 電話提醒畫面_Click()
        If MainForm.WindowState <> FormWindowState.Maximized Then
            MainForm.WindowState = FormWindowState.Maximized
        End If
        If Me.WindowState <> FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()
        電話提醒畫面.hide()
    End Sub

    Private Sub 電話提醒畫面_Close()
        電話提醒畫面.hide()
    End Sub






    Private Function SetGroup(ByVal oName As String)

        '權限	使用者代號	使用者	            部門	                群組
        'P	    KS03	    總經理/副總/素佳	主管	                2
        'P	    KS06	    麗嵐/宗平/麗花/達斌	主管	                2
        'F	    KS07	    育如/惠卿	        會計	                8
        'L	    KS08	    麗滿/瑞棠	        營業	                3
        'L	    KS09	    佳勳/益瑋	        採購	                6
        'L	    KS10	    淑紅/惠琴	        倉儲	                9
        'F	    KS11	    美真	            財務	                7
        'F	    KS12	    佳琳/小薇	        會計	                8
        'L	    KS13	    淑純/昭其/靜宜	    契養(加工)營業/人事總務	3
        'L	    KS14	    文芊/佳淳	        生產	                5
        'L	    KS15	    千惠/巧惠	        採購	                6
        'L	    KS16	    香名/玉伶	        倉儲	                9
        'C	    KS17	    美崙	            營業	                3
        '	    KS20	    人資	            人資	                10
        'C	    KS21	    快速訂單		
        'C	    KS22	    加工生產		


        '===================
        '設定群組
        'GROUPA 營業 = KS08,KS17,KS18 and KS06=麗嵐+麗花
        'GROUPB 生管 = KS14
        'GROUPC 倉庫 = KS10,KS16 and KS09 = 阿瑋跟佳勳
        'GROUPD 會計
        'GROUPE 採購
        '===================

        oName = oName.ToUpper()

        Dim ReGroupType As String

        Select Case oName
            Case "MANAGER", "MARK", "KS03"
                ReGroupType = "ALLGROUP"    '資訊管理使用
            Case "KS08", "KS13", "KS17", "KS18"
                ReGroupType = "GROUPA"      '營業
            Case "KS14"
                ReGroupType = "GROUPB"      '生管
                MenuTree.Nodes.Item("GroupB").Nodes.Item("GroupB_5").Nodes.Item("QckUpdateTransPrice").Remove()
                MenuTree.Nodes.Item("GroupB").Nodes.Item("GroupB_6").Remove()   '移除加工作業
            Case "KS22"
                ReGroupType = "GROUPB"      '生管-加工
                MenuTree.Nodes.Item("GroupB").Nodes.Item("GroupB_5").Nodes.Item("QckUpdateTransPrice").Remove()
                'MenuTree.Nodes.Item("GroupB").Nodes.Item("GroupB_6").Remove()   '移除加工作業
            Case "KS10", "KS16"  ', "KS22"
                ReGroupType = "GROUPC"      '倉庫
            Case "KS07", "KS11", "KS12"
                ReGroupType = "GROUPD"      '會計
            Case "KS15"
                ReGroupType = "GROUPE"      '採購

            Case "KS06"
                ReGroupType = "GROUPA+B"    '營業+生管
            Case "KS09"
                ReGroupType = "GROUPC+E"    '倉庫+採購

            Case "KS51"
                ReGroupType = "GROUPC1"     '記錄 移除GroupSS_2
                MenuTree.Nodes.Item("GroupSS").Nodes.Item("GroupSS_2").Remove()
            Case "QC"
                ReGroupType = "GROUPC1"     '記錄

            Case "0"
                ReGroupType = "ALLGROUP2"
                MenuTree.Nodes.Item("GroupMan").Nodes.Item("暫無用程式").Remove()
            Case Else
                'ID筆一層功能區
                Select Case IDLog08
                    'Case "0"
                    '    Select Case oName
                    '        Case "0"
                    '            ReGroupType = "ALLGROUP2"
                    '            MenuTree.Nodes.Item("GroupZ").Nodes.Item("暫無用程式").Remove()
                    '    End Select
                    Case "1"
                        'ReGroupType = "內部"
                        Select Case IDLog06
                            Case "31"   '通用未分
                                ReGroupType = "內部"
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                                'Case "900"  '資訊
                                'Case "910"  '董事長,總經理
                                'Case "920"  '營業
                                'Case "930"  '倉儲
                            Case "939"  '倉儲   冷藏入庫使用
                                ReGroupType = "內部"
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                                'Case "940"  '生產-電宰
                            Case "949"  '生產-電宰-生管-123F生產
                                ReGroupType = "內部"
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                                'Case "950"  '生產-加工
                                'Case "960"  '採購
                                'Case "970"  '人事,總務
                                'Case "980"  '財務,會計
                            Case "989"  '薪資
                                ReGroupType = "內部"
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                            Case "990"  '品管
                                ReGroupType = "內部"
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                            Case "991"  '品管
                                ReGroupType = "內部"
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                            Case "992"  '職安
                                ReGroupType = "內部"
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部通用").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部倉庫").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部生管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部薪資").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部品管").Remove()
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部契養").Remove()
                                'MenuTree.Nodes.Item("GroupZ").Nodes.Item("內部職安").Remove()
                            Case Else
                                ReGroupType = "GROUP0"
                        End Select

                    Case "2"
                        'ID筆二層功能區
                        Select Case IDLog06
                            Case "0"        ' 0= 現場最大權限
                                'If oName = "0" Then
                                ReGroupType = "ALLGROUP2"
                                MenuTree.Nodes.Item("GroupZ").Nodes.Item("暫無用程式").Remove()
                                'End If
                                '    Case "0"
                                '        ReGroupType = "ALLGROUP2"
                                '        MenuTree.Nodes.Item("GroupZ").Nodes.Item("暫無用程式").Remove()
                                '    Case Else
                                '        ReGroupType = "GROUP0"
                                'End Select
                            Case "10"       '10= 最大權限
                                ReGroupType = "褔利社"
                            Case "20"       '20= 登入員購
                                ReGroupType = "褔利社"
                                MenuTree.Nodes.Item("褔利社系統").Nodes.Item("基本設定").Remove()
                            Case Else
                                ReGroupType = "GROUP0"
                        End Select
                    Case Else
                        ReGroupType = "GROUP0"
                End Select
                'ReGroupType = "GROUP0"
        End Select

        Return ReGroupType

    End Function

    Private Sub SetView()

        Select Case GroupType   '排除非帳號之權限目錄
            Case "ALLGROUP"  '資訊管理使用
            Case "ALLGROUP2" '現場管理使用
                'MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統
            Case "GROUPA"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                'MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUPB"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                'MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUPC"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                'MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUPC1"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                'MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUPD"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                'MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUPE"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                'MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUPC+E"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                'MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                'MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '福利社

            Case "GROUPA+B"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                'MenuTree.Nodes.Item("GroupA").Remove()      '營業
                'MenuTree.Nodes.Item("GroupB").Remove()      '生管
                'MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "內部"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                'MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "褔利社"
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                'MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

            Case "GROUP0"   '無權限
                MenuTree.Nodes.Item("GroupMan").Remove()    '管理使用
                MenuTree.Nodes.Item("GroupA").Remove()      '營業
                MenuTree.Nodes.Item("GroupB").Remove()      '生管
                MenuTree.Nodes.Item("GroupC").Remove()      '倉庫
                MenuTree.Nodes.Item("GroupD").Remove()      '會計
                MenuTree.Nodes.Item("GroupE").Remove()      '採購
                MenuTree.Nodes.Item("GroupSS").Remove()     '記錄
                MenuTree.Nodes.Item("GroupZ").Remove()      '內部系統
                MenuTree.Nodes.Item("褔利社系統").Remove()  '褔利社系統

        End Select

        If Login.LoginType <> 2 Then
            MenuTree.Nodes.Item("ChangePassWord").Remove()
        End If
    End Sub

    Private Sub MenuTree_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuTree.NodeMouseDoubleClick

        Dim MSize As Single = 0
        If IDNumber.ToUpper() = "MANAGER" Then : MSize = 50 : End If    '管理者 Size +50

        Select Case MenuTree.SelectedNode.Name
            '生產需求計算
            Case "電宰BOM"
                電宰基本BOM.MdiParent = MainForm
                電宰基本BOM.MaximumSize = New Size(950, 700 + MSize)
                電宰基本BOM.MinimumSize = New Size(950, 700 + MSize)
                電宰基本BOM.Size = New Size(950, 700 + MSize)
                電宰基本BOM.Show()

            Case "生產需求計算"
                生產需求計算程式.MdiParent = MainForm
                生產需求計算程式.MaximumSize = New Size(950 + MSize, 700)
                生產需求計算程式.MinimumSize = New Size(950 + MSize, 700)
                生產需求計算程式.Size = New Size(950 + MSize, 700)
                生產需求計算程式.Show()

            Case "生產需求統計"
                生產需求統計v001.MdiParent = MainForm
                生產需求統計v001.Show()

            Case "IDMgn"
                IDMgn.MdiParent = MainForm
                IDMgn.Show()
            Case "UP2Mgn"
                UP2Mgn.MdiParent = MainForm
                UP2Mgn.Show()
            Case "ORDR" 'A_營業_訂單輸入
                營業訂單V103.MdiParent = MainForm
                營業訂單V103.Show()
                'A_營業_訂單輸入v002.MdiParent = MainForm
                'A_營業_訂單輸入v002.Show()
                'A_ORDR.MdiParent = MainForm
                'A_ORDR.Show()

            Case "客戶品項" 'A_營業_訂單輸入
                客戶品項V100.MdiParent = MainForm
                客戶品項V100.Show()

            Case "ContractFarms"
                A_ContractFarms.MdiParent = MainForm
                A_ContractFarms.Show()
            Case "AddEBin"
                A_EBin.MdiParent = MainForm
                A_EBin.Show()
            Case "UpdateEBin"
                A_UpdateEBin.MdiParent = MainForm
                A_UpdateEBin.Show()
            Case "AddEBadjust"
                A_AddEBadjust.MdiParent = MainForm
                A_AddEBadjust.Show()
            Case "UpdateEBadjust"
                A_UpdateEBadjust.MdiParent = MainForm
                A_UpdateEBadjust.Show()
            Case "QueryEB"
                A_QueryEB.MdiParent = MainForm
                A_QueryEB.Show()
            Case "DriversFee"
                A_DriversFee.MdiParent = MainForm
                A_DriversFee.Show()
            Case "SalesFee"
                A_SalesFee.MdiParent = MainForm
                A_SalesFee.Show()
            Case "ContractSettlement"
                A_ContractSettlement.MdiParent = MainForm
                A_ContractSettlement.Show()
            Case "QueryODLN"
                A_QueryODLN.MdiParent = MainForm
                A_QueryODLN.Show()
            Case "Scheduling"
                A_Scheduling.MdiParent = MainForm
                A_Scheduling.Show()

                'Add By Justin in 20130926
            Case "快速回傳B1"
                A_Welfare_List.MdiParent = MainForm
                A_Welfare_List.Show()
                'Add By Justin in 20131011
            Case "員購價維護"
                A_WelfarePriceList.MdiParent = MainForm
                A_WelfarePriceList.Show()
                'Add By Justin in 20131015
            Case "員購價覆核"
                A_WelfarePriceExamine.MdiParent = MainForm
                A_WelfarePriceExamine.Show()
                'Add By Justin in 20131018
            Case "外部人員基本資料維護"
                A_OutSideEmpBasicDataList.MdiParent = MainForm
                A_OutSideEmpBasicDataList.Show()
                'Add By Justin in 20131210
            Case "EC出貨表單列印"
                A_EC_List.MdiParent = MainForm
                A_EC_List.Show()
                'Add By Justin in 20131217
            Case "EC進價維護"
                A_ECPriceList.MdiParent = MainForm
                A_ECPriceList.Show()
                'Add By Justin in 20131217
            Case "EC進價覆核"
                A_ECPriceExamine.MdiParent = MainForm
                A_ECPriceExamine.Show()
                'Add By Justin in 20131220
            Case "EC宅配單列印"
                A_TransPaper_List.MdiParent = MainForm
                A_TransPaper_List.Show()
                'Add By Justin in 20131223
            Case "EC存貨領用待申請清單"
                A_ECStockApplyList.MdiParent = MainForm
                A_ECStockApplyList.Show()

            Case "發票作業"
                v002發票查詢列印.MdiParent = MainForm
                v002發票查詢列印.Show()

            Case "變價作業"
                客戶變價V100.MdiParent = MainForm
                客戶變價V100.Show()

            Case "退貨作業"
                退貨作業V100.MdiParent = MainForm
                退貨作業V100.Show()

            Case "退貨記錄"
                退貨記錄V100.MdiParent = MainForm
                退貨記錄V100.Show()

            Case "檢查記錄"
                v001檢查記錄.MdiParent = MainForm
                v001檢查記錄.Show()

            Case "退貨統計"
                退貨統計V100.MdiParent = MainForm
                退貨統計V100.Show()


            Case "單據重量列印"
                單據重量列印V001.MdiParent = MainForm
                單據重量列印V001.Show()

            Case "預估數量"
                數量差異表.MdiParent = MainForm
                數量差異表.Show()


                '倉儲管理
                '1同步作業

                '3派工作業  3-1 派工查詢 
            Case "派工查詢"
                A_整合派工作業.MdiParent = MainForm
                A_整合派工作業.Show()

            Case "QueryORDR"
                查詢生產訂單v001.MdiParent = MainForm
                查詢生產訂單v001.Show()
            Case "QuickAddOWOR"
                B_QckAddOWOR.MdiParent = MainForm
                B_QckAddOWOR.Show()
            Case "QuickAddOIGE"
                B_QckAddOIGE.MdiParent = MainForm
                B_QckAddOIGE.Show()
            Case "QuickUpdateOWOR", "製單契養批單"
                快速回填生產訂單v001.MdiParent = MainForm
                If IDNumber.ToUpper() <> "MANAGER" Then
                    快速回填生產訂單v001.Size = New Size(935, 635)
                End If
                快速回填生產訂單v001.Show()
            Case "AddFinishItem"
                B_AddFinishItem.MdiParent = MainForm
                B_AddFinishItem.Show()
            Case "QueryOutside"
                B_QueryOutside.MdiParent = MainForm
                B_QueryOutside.Show()
            Case "QueryOIGE"
                B_QueryOIGE.MdiParent = MainForm
                B_QueryOIGE.Show()
            Case "QueryOIGEByU_CK02"
                B_QueryOIGEByU_CK02.MdiParent = MainForm
                B_QueryOIGEByU_CK02.Show()
            Case "CalcThroughput"
                計算產出率v001.MdiParent = MainForm
                計算產出率v001.Source = "CalcThroughput"
                計算產出率v001.Show()
            Case "CalcMelts"
                B_CalcMelts.MdiParent = MainForm
                B_CalcMelts.Show()
            Case "QueryTransportation"
                毛雞運輸日報表v001.MdiParent = MainForm
                毛雞運輸日報表v001.Show()
            Case "AddTransportation"
                B_AddTransportation.MdiParent = MainForm
                B_AddTransportation.Source = "Add"
                B_AddTransportation.Show()
            Case "UpdateTransportation"
                B_UpdateTransportation.MdiParent = MainForm
                B_UpdateTransportation.Source = "Update"
                B_UpdateTransportation.Show()
            Case "QckUpdateTransPrice"
                B_QckUpdateTransPrice.MdiParent = MainForm
                B_QckUpdateTransPrice.Show()
            Case "AddSchedule"
                B_AddSchedule.MdiParent = MainForm
                B_AddSchedule.Show()
            Case "UpdateSchedule"
                B_UpdateSchedule.MdiParent = MainForm
                B_UpdateSchedule.Show()
            Case "QuerySchedule"
                B_QuerySchedule.MdiParent = MainForm
                B_QuerySchedule.Show()

                '加工作業			GroupB_6
            Case "QueryPickingItem"     '領料查詢
                B_QueryPickingItem.MdiParent = MainForm
                B_QueryPickingItem.Show()
            Case "CalcBomNeeds"         '生產需求計算
                B_CalcBomNeeds.MdiParent = MainForm
                B_CalcBomNeeds.Show()
            Case "_0_01製程基本標準"         '生產需求計算
                _0_01製程基本標準.MdiParent = MainForm
                If IDNumber.ToUpper() <> "MANAGER" Then
                    _0_01製程基本標準.Size = New Size(902, 600)
                End If
                _0_01製程基本標準.Show()



            Case "BQuerySRNNotInB1Yet" '生產入庫比對
                C_QuerySRNNotInB1Yet.MdiParent = MainForm
                C_QuerySRNNotInB1Yet.Show()
            Case "QuickAddOIGEv2"
                'B_QckAddOIGEv2.MdiParent = MainForm
                'B_QckAddOIGEv2.Show()
                派工作業.MdiParent = MainForm
                派工作業.Show()
            Case "QuickAddOIGEv3"
                'B_QckAddOIGEv3.MdiParent = MainForm
                'B_QckAddOIGEv3.Show()
                扣帳作業.MdiParent = MainForm
                扣帳作業.Show()

                '---->現場生產排程單<----
            Case "OrderPicking"
                排程改2.MdiParent = MainForm
                排程改2.Show()
                'Case "現場生產排程單"
                '    排程改.MdiParent = MainForm
                '    排程改.Show()
                'Case "OrderPicking"
                '    B_OrderPicking.MdiParent = MainForm
                '    B_OrderPicking.Show()
                'Case "OrderPicking"
                '    生產排程.MdiParent = MainForm
                '    生產排程.Show()

            Case "排程總表"
                排程顯示V100.Show()

            Case "OSPdata"                      '現場排程基本資料
                B_OSPdata.MdiParent = MainForm
                B_OSPdata.Show()
            Case "OCWscheduling"
                'B_OCWScheduling.MdiParent = MainForm
                'B_OCWScheduling.Show()
            Case "Whours"
                B_Whours.MdiParent = MainForm
                B_Whours.Show()
                'Case "QuerySRNDetail"
                '    C_QuerySRNDetail.MdiParent = MainForm
                '    C_QuerySRNDetail.Show()
                'Case "分級槽基礎存編設定"
                '    ScaleOITM2.MdiParent = MainForm
                '    ScaleOITM2.Show()
            Case "分級槽基礎存編設定"
                '磅秤品項設定v100.作業單位.Text = "加工"
                磅秤品項設定v100.MdiParent = MainForm
                磅秤品項設定v100.Show()
            Case "分級槽基礎存編設定v101"
                '磅秤品項設定v100.作業單位.Text = "加工"
                磅秤品項設定v101.MdiParent = MainForm
                磅秤品項設定v101.Show()
            Case "現場機台過磅設定"
                '機台設定.MdiParent = MainForm
                '機台設定.Show()

            Case "磅秤品項現場生管"
                '磅秤品項設定v100.作業單位.Text = "加工"
                磅秤品項設定v100.MdiParent = MainForm
                磅秤品項設定v100.Show()

            Case "生產需求設定"
                生產需求設定V001.MdiParent = MainForm
                生產需求設定V001.Show()

            Case "Print_Single"
                C_Print_Single.MdiParent = MainForm
                C_Print_Single.Show()
            Case "Print_Batch"
                C_Print_Batch.MdiParent = MainForm
                C_Print_Batch.Show()
            Case "ChangeSpace"
                C_ChangeSpace.MdiParent = MainForm
                C_ChangeSpace.Show()
            Case "BatchChangeSpace"
                C_BatchChangeSpace.MdiParent = MainForm
                C_BatchChangeSpace.Show()
            Case "QueryChangeSpace"
                C_QueryChangeSpace.MdiParent = MainForm
                C_QueryChangeSpace.Show()
            Case "QueryFromSpace"
                C_QueryFromSpace.MdiParent = MainForm
                C_QueryFromSpace.Show()
            Case "QueryWplaceStatus"
                C_QueryWplaceStatus.MdiParent = MainForm
                C_QueryWplaceStatus.Show()
            Case "QuerySRNTradesDetail"
                C_QuerySRNTradesDetail.MdiParent = MainForm
                C_QuerySRNTradesDetail.Show()
            Case "QuerySRNStatus"
                C_QuerySRNStatus.MdiParent = MainForm
                C_QuerySRNStatus.Show()
            Case "QuerySRNDetail"
                C_QuerySRNDetail.MdiParent = MainForm
                C_QuerySRNDetail.Show()
            Case "QueryAllocateWplace"
                C_QueryAllocateWplace.MdiParent = MainForm
                C_QueryAllocateWplace.Show()
            Case "QuerySuggestWplace"
                C_QuerySuggestWplace.MdiParent = MainForm
                C_QuerySuggestWplace.Show()
                'Case "QuerySRNFromDraft"
                '    C_QuerySRNFromDraft.MdiParent = MainForm
                '    C_QuerySRNFromDraft.Show()

            Case "QuerySRNFromDraft"
                A_文件查庫存.MdiParent = MainForm
                A_文件查庫存.Show()
                '查詢出庫資料
            Case "查詢出庫資料"
                C_查詢出庫資料.MdiParent = MainForm
                C_查詢出庫資料.Show()
            Case "SyncInByExcel"
                Excel讀取轉入.MdiParent = MainForm
                Excel讀取轉入.Show()
            Case "SyncOutByExcel"
                'Dim PCN As String = "" : PCN = UCase(System.Net.Dns.GetHostName())
                'UCase(System.Net.Dns.GetHostName())
                If System.Net.Dns.GetHostName() = "MIS-03" Or UCase(System.Net.Dns.GetHostName()) = "KS-F5" Or UCase(System.Net.Dns.GetHostName()) = "KS-F1" Then
                    C_SyncOutByExcel.MdiParent = MainForm
                    C_SyncOutByExcel.Show()
                Else
                    MsgBox("很抱歉，目前此功能限KS-F1 & KS-F5作業。", 48, "警告")
                End If

                'Case "SyncInByPDA"
                '    A_PDA讀取轉入.MdiParent = MainForm
                '    A_PDA讀取轉入.Show()
                'Case "SyncOutByPDA"
                '    C_SyncOutByPDA.MdiParent = MainForm
                '    C_SyncOutByPDA.Show()
            Case "訂單自動比對"
                訂單自動比對V100.MdiParent = MainForm
                訂單自動比對V100.Show()

            Case "InB1ByManufacture"    '生產入庫
                C_生產入庫舊.MdiParent = MainForm
                C_生產入庫舊.Show()
            Case "電宰製單入庫"
                生產入庫V100.MdiParent = MainForm
                生產入庫V100.Show()
            Case "生產入庫"
                生產入庫V101.MdiParent = MainForm
                生產入庫V101.Show()
            Case "InB1BySpecial"
                C_特殊入庫.MdiParent = MainForm
                C_特殊入庫.Show()
            Case "InB1ByPurchase"
                C_InB1ByPurchase.MdiParent = MainForm
                C_InB1ByPurchase.Show()
            Case "採購入庫_鮮享作業"
                採購入庫_鮮享V100.MdiParent = MainForm
                採購入庫_鮮享V100.Show()
            Case "交貨單轉出與轉入"
                交貨單轉出與轉入.MdiParent = MainForm
                交貨單轉出與轉入.Show()
                '採購草稿單入庫
            Case "採購草稿單入庫"
                草稿單入庫轉入.MdiParent = MainForm
                草稿單入庫轉入.Show()
            Case "No代工轉入生產"
                代工轉入生產.MdiParent = MainForm
                代工轉入生產.Show()




            Case "OutB1"
                C_OutB1.MdiParent = MainForm
                C_OutB1.Show()
            Case "出庫作業"
                出庫作業V100.MdiParent = MainForm
                出庫作業V100.Show()
            Case "出庫作業v001"
                '停用
                '出庫作業V001.T1入出.Text = "出貨"
                '出庫作業V001.MdiParent = MainForm
                '出庫作業V001.MaximumSize = New Size(950, 660 + MSize)
                '出庫作業V001.MinimumSize = New Size(950, 660 + MSize)
                '出庫作業V001.Size = New Size(950, 660 + MSize)
                '出庫作業V001.Show()

                出庫作業V002.T1入出.Text = "出貨"
                出庫作業V002.MdiParent = MainForm
                出庫作業V002.MaximumSize = New Size(950, 660 + MSize)
                出庫作業V002.MinimumSize = New Size(950, 660 + MSize)
                出庫作業V002.Size = New Size(950, 660 + MSize)
                出庫作業V002.Show()
            Case "單據入庫作業"
                出庫作業V001.T1入出.Text = "入庫"
                出庫作業V001.MdiParent = MainForm
                出庫作業V001.MaximumSize = New Size(950, 660 + MSize)
                出庫作業V001.MinimumSize = New Size(950, 660 + MSize)
                出庫作業V001.Size = New Size(950, 660 + MSize)
                出庫作業V001.Show()
            Case "QueryFIMainStatus"
                C_QueryFIMainStatus.MdiParent = MainForm
                C_QueryFIMainStatus.Show()
            Case "QuerySRNInPDAIn"
                C_QuerySRNInPDAIn.MdiParent = MainForm
                C_QuerySRNInPDAIn.Show()
            Case "QuerySRNNotInB1Yet"
                C_QuerySRNNotInB1Yet.MdiParent = MainForm
                C_QuerySRNNotInB1Yet.Show()
            Case "QueryFIMainDetail"
                C_QueryFIMainDetail.MdiParent = MainForm
                C_QueryFIMainDetail.Show()
            Case "QckAddChickenOutOIGE"
                C_QckAddChickenOutOIGE.MdiParent = MainForm
                C_QckAddChickenOutOIGE.Show()
            Case "STSForInv"
                C_STSForInv.MdiParent = MainForm
                C_STSForInv.Show()
            Case "QckAddOIGEv5"
                B_QckAddOIGEv5.MdiParent = MainForm
                B_QckAddOIGEv5.Show()
            Case "Inquiry_001"
                C_Inquiry_001.MdiParent = MainForm
                C_Inquiry_001.Show()
            Case "MS223411G"
                查庫存_G.MdiParent = MainForm
                查庫存_G.Show()
            Case "調庫作業"
                調庫作業V101.MdiParent = MainForm
                調庫作業V101.Show()
            Case "查庫位品項"
                查庫位品項.MdiParent = MainForm
                查庫位品項.Show()

                'Add By Justin in 20131126
            Case "儲位基本資料維護"
                StorePlaceBasicData.MdiParent = MainForm
                StorePlaceBasicData.Show()

            Case "加工原料肉領料單"
                加工原料肉領料單.MdiParent = MainForm
                加工原料肉領料單.Show()

            Case "時段排程比對_生管", "時段排程比對_倉庫", "時段排程比對_現場", "時段排程比對_營業"
                時段入庫比對.MdiParent = MainForm
                時段入庫比對.Show()

            Case "驗收/領料/加工庫存查詢"
                If IDNumber.ToUpper() = "MANAGER" Or UCase(System.Net.Dns.GetHostName()) = "KS-F1" Then
                    v001驗收及領料及加工庫存查詢.MdiParent = MainForm
                    v001驗收及領料及加工庫存查詢.Show()
                Else
                    MsgBox("很抱歉，目前此功能限KS-F1作業。", 48, "警告")
                End If

                '---->倉庫止<----


            Case "AccMainFrom"
                D_AccMainFrom.MdiParent = MainForm
                D_AccMainFrom.Show()
            Case "SellToSave"
                D_SellToSave.MdiParent = MainForm
                D_SellToSave.Show()
            Case "JournalCheck"
                D_JournalCheck.MdiParent = MainForm
                D_JournalCheck.Show()
            Case "AccReport"
                D_AccReport.MdiParent = MainForm
                D_AccReport.Show()
            Case "CompareFrom"
                D_CompareFrom.MdiParent = MainForm
                D_CompareFrom.Show()
            Case "CostcoPayment"
                D_CostcoPayment.MdiParent = MainForm
                D_CostcoPayment.Show()
            Case "AllJournal"
                D_AllJournal.MdiParent = MainForm
                D_AllJournal.Show()
            Case "ProfitCenter"
                MsgBox("很抱歉，目前此功能尚未完成。", 48, "警告")

            Case "PaymentForm"
                E_PaymentForm.MdiParent = MainForm
                E_PaymentForm.Show()
            Case "QckAddOPOR"
                E_QckAddOPOR.MdiParent = MainForm
                E_QckAddOPOR.Show()

            Case "OQUT"
                Z_OQUT.MdiParent = MainForm
                Z_OQUT.Show()

                'Add By Jusyin in 201309XX
            Case "過磅基本設定"
                ScaleOITM_褔利社.MdiParent = MainForm
                ScaleOITM_褔利社.Show()
            Case "員購訂單"
                員購訂單.MdiParent = MainForm
                員購訂單.Show()
            Case "Z_Welfare_List"   '員購訂單總務覆核
                Z_Welfare_List.MdiParent = MainForm
                Z_Welfare_List.Show()
            Case "StockApply"   '存領定單
                Z_StockApplyList.MdiParent = MainForm
                Z_StockApplyList.Show()


            Case "ChangePassWord"
                ChangePassWord()

            Case "Test"
                testFrom.MdiParent = MainForm
                testFrom.Show()

                '記錄表格_生產
            Case "屠宰記錄"
                屠宰記錄.MdiParent = MainForm
                屠宰記錄.Show()
                '記錄表格_倉儲
            Case "倉儲記錄"
                倉儲記錄.MdiParent = MainForm
                倉儲記錄.Show()
            Case "倉儲記錄2"
                倉儲記錄2.MdiParent = MainForm
                倉儲記錄2.Show()

                'add 乙諒
                '契養報表
            Case "FdCkSettle"
                FdCkSettle.MdiParent = MainForm
                FdCkSettle.Show()


            Case "訂單輸入2"
                營業訂單V104.MdiParent = MainForm
                營業訂單V104.Show()


            Case "訂單上傳作業"
                訂單上傳作業.MdiParent = MainForm
                訂單上傳作業.Show()



                '通用
                '電話記錄
            Case "電話記錄"
                內部記錄.MdiParent = MainForm
                內部記錄.MaximumSize = New Size(900 + MSize, 500)
                內部記錄.MinimumSize = New Size(900 + MSize, 500)
                內部記錄.Size = New Size(900 + MSize, 500)
                內部記錄.Show()

            Case "生管查排程"
                現場生管查排程.MdiParent = MainForm
                現場生管查排程.Show()

                'Case "薪資計算"
                '    薪資計算.MdiParent = MainForm
                '    薪資計算.Show()

            Case "工時統計"
                工時統計表v001.MdiParent = MainForm
                工時統計表v001.Show()

            Case "計件資料"
                計件計算V102.MdiParent = MainForm
                計件計算V102.Show()

            Case "發票作廢作業"
                v001發票作廢作業.MdiParent = MainForm
                v001發票作廢作業.Show()

            Case "現場磅秤資訊"
                現場磅秤資訊V001.Show()


            Case "毛雞預估查詢"
                v001毛雞預估查詢.MdiParent = MainForm
                v001毛雞預估查詢.Show()


            Case "訂單轉排程"
                'If System.Net.Dns.GetHostName() = "MIS-03" Then
                '    v002訂單轉排程.MdiParent = MainForm
                '    v002訂單轉排程.Show()
                'Else
                v001訂單轉排程.MdiParent = MainForm
                v001訂單轉排程.Show()
                'End If

            Case "日排轉排程"
                v002訂單轉排程.MdiParent = MainForm
                v002訂單轉排程.Show()

            Case "訂單上傳統計"
                上傳訂單統計V001.MdiParent = MainForm
                上傳訂單統計V001.Show()


            Case "產程明細表"
                v001產程明細表.MdiParent = MainForm
                v001產程明細表.Show()


            Case "預估訂單數量"
                預估訂單數量V100.MdiParent = MainForm
                預估訂單數量V100.Show()

            Case "比對表_v100"
                比對表_v100.MdiParent = MainForm
                比對表_v100.Show()

            Case "入庫自動化"
                生產入庫自動化v100.MdiParent = MainForm
                生產入庫自動化v100.Show()
                'Form1.MdiParent = MainForm
                'Form1.Show()

            Case "退貨入庫"
                退貨入庫V100.MdiParent = MainForm
                退貨入庫V100.Show()

            Case "分時領料"
                分時領料V002.MdiParent = MainForm
                分時領料V002.Show()

            Case "分時領料單_生管"
                分時生管V001.MdiParent = MainForm
                分時生管V001.Show()

            Case "存領單查詢"
                v001存領單查詢.MdiParent = MainForm
                v001存領單查詢.Show()

            Case "發票比對"
                發票比對作業v001.MdiParent = MainForm
                發票比對作業v001.Show()

            Case "線上撿貨"
                線上撿貨V001.MdiParent = MainForm
                線上撿貨V001.Show()

            Case "出急速庫作業"
                指定入庫v001.MdiParent = MainForm
                指定入庫v001.Show()

            Case "冷藏貨庫存查詢表"
                v001冷藏貨庫存查詢表.MdiParent = MainForm
                v001冷藏貨庫存查詢表.Show()

            Case "健檢數據資料"
                v001健檢數據資料.MdiParent = MainForm
                v001健檢數據資料.Show()

            Case "出貨單查詢(交貨草稿)"
                v001出貨單查詢.MdiParent = MainForm
                v001出貨單查詢.Show()

        End Select

    End Sub

    Private Sub GetUserNamexx()

    End Sub



    Private Sub GetUserName()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader1 As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "Select [U_NAME] from [OUSR] where [USER_CODE] = '" & Login.LogonUserName & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            sqlReader1 = SQLCmd.ExecuteReader
            sqlReader1.Read()
            If Not sqlReader1.HasRows() Then
                UserName.Text = Login.LogonUserName
                UserName2.Text = Login.LogonUserName2
                'UserUnit.Text = Login.LogonUserUnit
                UserUnit.Text = IDLog09
                sqlReader1.Close()
            Else
                'UserName.Text = sqlReader1.Item("U_NAME")
                UserName.Text = Login.LogonUserName
                UserName2.Text = sqlReader1.Item("U_NAME")
                UserUnit.Text = ""
                sqlReader1.Close()
            End If

            If sqlReader1.IsClosed = False Then
                sqlReader1.Close()
            End If
            TransactionMonitor.Complete()
        End Using

    End Sub

    Private Sub ChkStatusLabel()
        If MainForm.ToolStripStatusLabel1.Text = "登入成功!" Then
            Timer1.Interval = 5000
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        MainForm.ToolStripStatusLabel1.Text = ""
        Timer1.Enabled = False
    End Sub

    Private Sub ChangePassWord()
        Dim newPwd1, newPwd2, EncPwd As String

        newPwd1 = InputBox("輸入新密碼：", "變更密碼", "")
        If newPwd1 = "" Then
            Exit Sub
        End If
        newPwd2 = InputBox("請再輸入一次新密碼：", "確認密碼", "")
        If newPwd1 = "" Then
            Exit Sub
        End If

        If newPwd1 <> newPwd2 Then
            MsgBox("輸入密碼不符!", MsgBoxStyle.OkOnly, "密碼錯誤")
        Else
            EncPwd = Login.pFunction.encyPwd(newPwd1)

            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Dim tran As SqlTransaction = DBConn.BeginTransaction()

            Try
                sql = "UPDATE [@kslogin] SET LOG02 = '" & EncPwd & "' Where [LOG01] = '" & Login.LogonUserName & "'"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

                tran.Commit()
            Catch ex As Exception
                tran.Rollback()
                MsgBox("變更失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                Exit Sub
            End Try

            MsgBox("密碼已變更完成!", 64, "變更成功")

        End If
    End Sub









End Class