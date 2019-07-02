Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 時段入庫比對
    Dim DataAdapterDGV As SqlDataAdapter
    'Dim 下拉明細 As DataSet = New DataSet
    Dim 顯示資料 As DataSet = New DataSet
    Dim 單位 As String = ""
    Dim 資料 As String = "無"

    Private Sub 時段入庫比對_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If KS09KS10KS16 Then
        Select Case UCase(Login.LogonUserName)
            'Case "MANAGER"
            '    單位 = "ALL"
            Case "KS09", "KS10", "KS16", "MANAGER"
                單位 = "倉庫"
                Lt2單位.Text = "倉庫"
            Case "KS9491", "KS9493"
                單位 = "生產"
                Lt2單位.Text = "生產"
            Case "KS14", "KS22"
                單位 = "生管"
                Lt2單位.Text = "生管"
            Case "KS17", "KS18", "KS08"
                單位 = "營業"
                Lt2單位.Text = "營業"
            Case Else
                單位 = ""
                Lt2單位.Text = ""
        End Select

        Schedule載入()
        初始作業()

    End Sub

    Private Sub 初始作業()
        'Select Case 單位
        '    Case "ALL"

        '    Case "倉庫"
        '        Tb3其他.Enabled = True

        '    Case "生產"
        '        Cb2_1.Enabled = True
        '        Cb2_2.Enabled = True
        '        Cb2_3.Enabled = True
        '        Cb2_4.Enabled = True
        '        Cb2_5.Enabled = True
        '        Tb2其他.Enabled = True

        '    Case Else
        'End Select
        Rb2正常.Checked = False : Rb2異常.Checked = False
        Cb2_1.Checked = False : Cb2_2.Checked = False : Cb2_3.Checked = False : Cb2_4.Checked = False : Cb2_5.Checked = False
        Cb2_6.Checked = False : Cb2_7.Checked = False
        Tb2其他.Text = ""


        Cb3_01.Checked = False : Cb3_02.Checked = False : Cb3_03.Checked = False : Cb3_04.Checked = False : Cb3_05.Checked = False
        Cb3_06.Checked = False : Cb3_07.Checked = False : Cb3_08.Checked = False : Cb3_09.Checked = False : Cb3_10.Checked = False
        Cb3_11.Checked = False : Cb3_12.Checked = False : Cb3_13.Checked = False : Cb3_14.Checked = False : Cb3_15.Checked = False
        Cb3_16.Checked = False : Cb3_17.Checked = False : Cb3_18.Checked = False : Cb3_19.Checked = False : Cb3_20.Checked = False
        Cb3_21.Checked = False : Cb3_22.Checked = False : Cb3_23.Checked = False : Cb3_24.Checked = False : Cb3_25.Checked = False
        Cb3_26.Checked = False : Cb3_27.Checked = False : Cb3_28.Checked = False : Cb3_29.Checked = False : Cb3_30.Checked = False
        Tb3其他.Text = ""

        Cb4_01.Checked = False : Cb4_02.Checked = False : Cb4_03.Checked = False : Cb4_04.Checked = False : Cb4_05.Checked = False
        Cb4_06.Checked = False : Cb4_07.Checked = False : Cb4_08.Checked = False : Cb4_09.Checked = False : Cb4_10.Checked = False
        Cb4_11.Checked = False : Cb4_12.Checked = False : Cb4_13.Checked = False
        Tb4其他.Text = ""

        Cb5_01.Checked = False : Cb5_02.Checked = False : Cb5_03.Checked = False : Cb5_04.Checked = False : Cb5_05.Checked = False
        Cb5_06.Checked = False : Cb5_07.Checked = False : Cb5_08.Checked = False : Cb5_09.Checked = False : Cb5_10.Checked = False
        Cb5_11.Checked = False : Cb5_12.Checked = False : Cb5_13.Checked = False
        Tb5其他.Text = ""

        Lt2記錄.Text = "" : Lt3記錄.Text = "" : Lt4記錄.Text = "" : Lt5記錄.Text = "" : Lt5鎖定.Text = ""


    End Sub

    Private Sub Schedule載入()
        Dim SQLQuery As String = ""
        SQLQuery = PM_Lists.Schedule_Lists()

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(顯示資料, "Schedule")

            時段.DataSource = 顯示資料.Tables("Schedule").Copy
            時段.DisplayMember = "類別" '名稱
            時段.ValueMember = "代碼"      '編號
            時段.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("Schedule: " & ex.Message)
            Exit Sub
        End Try
    End Sub



    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        If CB時段.Checked = False Then : If 時段.SelectedIndex = -1 Then : Exit Sub : End If : End If
        初始作業()
        時段比對查詢(1)
        時段異常記錄查詢()
        '時段異常記錄查詢("生產")
        時段明細查詢()
        If CB歷史.Checked = False Then
            時段比對查詢(2)
        Else
            時段比對查詢(3)
        End If

        If T2DGV.RowCount > 0 Then
            資料 = "有"
            T2DGV.CurrentCell = T2DGV.Rows(0).Cells(0)
            倉庫時段異常記錄查詢2()
        Else
            資料 = "無" : 初始作業()
        End If

    End Sub


    Private Sub 時段異常記錄查詢()
        If CB時段.Checked = True Then : Exit Sub : End If
        If T2DGV.RowCount > 0 Then : 顯示資料.Tables("異常記錄").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""
        'SQLQuery2 = " ( SELECT ISNULL([生產],'') AS '生產' "
        'SQLQuery2 += "   FROM [KaiShingPlug].[dbo].[存_排程異常記錄] "
        'SQLQuery2 += "  WHERE [日期] = '" & Format(日期.Value.Date, "yyyy-MM-dd") & "' AND [樓層] = '二樓' AND [時段] = '" & 時段.Text & "' AND [單位] = '生產' AND [啟用] = 'Y' ) "

        'SQLQuery = "  SELECT [日期],[樓層],[時段],[正常否],[異常],[其他],ISNULL(" & SQLQuery2 & ",'') AS '生產' "
        'SQLQuery += "   FROM [KaiShingPlug].[dbo].[存_排程異常記錄] "
        'SQLQuery += "  WHERE [日期] = '" & Format(日期.Value.Date, "yyyy-MM-dd") & "' AND [樓層] = '二樓' AND [時段] = '" & 時段.Text & "' AND [啟用] = 'Y'  " & vbCrLf

        SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_時段比對01v2] "
        SQLQuery += " N'" & Lt2日期.Text & "',N'" & Lt2樓層.Text & "',N'" & Lt2時段.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "異常記錄") : T2DGV.DataSource = 顯示資料.Tables("異常記錄") : T2DGV.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("倉庫時段異常記錄查詢：" & ex.Message)
        End Try
    End Sub

    Private Sub 倉庫時段異常記錄查詢2()
        If T2DGV.CurrentRow.Cells("正常否").Value = "Y" Then : Rb2正常.Checked = True : Else : Rb2異常.Checked = True : End If
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 1, 1) = "1" Then : Cb2_1.Checked = True : Else : Cb2_1.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 2, 1) = "1" Then : Cb2_2.Checked = True : Else : Cb2_2.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 3, 1) = "1" Then : Cb2_3.Checked = True : Else : Cb2_3.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 4, 1) = "1" Then : Cb2_4.Checked = True : Else : Cb2_4.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 5, 1) = "1" Then : Cb2_5.Checked = True : Else : Cb2_5.Checked = False : End If
        Tb2其他.Text = T2DGV.CurrentRow.Cells("其他_倉庫").Value
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 6, 1) = "1" Then : Cb2_6.Checked = True : Else : Cb2_6.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("倉庫").Value, 7, 1) = "1" Then : Cb2_7.Checked = True : Else : Cb2_7.Checked = False : End If
        If T2DGV.CurrentRow.Cells("倉庫").Value = "" Then : Lt2記錄.Text = "" : Else : Lt2記錄.Text = "已存檔" : End If

        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 1, 1) = "1" Then : Cb3_01.Checked = True : Else : Cb3_01.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 2, 1) = "1" Then : Cb3_02.Checked = True : Else : Cb3_02.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 3, 1) = "1" Then : Cb3_03.Checked = True : Else : Cb3_03.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 4, 1) = "1" Then : Cb3_04.Checked = True : Else : Cb3_04.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 5, 1) = "1" Then : Cb3_05.Checked = True : Else : Cb3_05.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 6, 1) = "1" Then : Cb3_06.Checked = True : Else : Cb3_06.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 7, 1) = "1" Then : Cb3_07.Checked = True : Else : Cb3_07.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 8, 1) = "1" Then : Cb3_08.Checked = True : Else : Cb3_08.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 9, 1) = "1" Then : Cb3_09.Checked = True : Else : Cb3_09.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 10, 1) = "1" Then : Cb3_10.Checked = True : Else : Cb3_10.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 11, 1) = "1" Then : Cb3_11.Checked = True : Else : Cb3_11.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 12, 1) = "1" Then : Cb3_12.Checked = True : Else : Cb3_12.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 13, 1) = "1" Then : Cb3_13.Checked = True : Else : Cb3_13.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 14, 1) = "1" Then : Cb3_14.Checked = True : Else : Cb3_14.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 15, 1) = "1" Then : Cb3_15.Checked = True : Else : Cb3_15.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 16, 1) = "1" Then : Cb3_16.Checked = True : Else : Cb3_16.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 17, 1) = "1" Then : Cb3_17.Checked = True : Else : Cb3_17.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 18, 1) = "1" Then : Cb3_18.Checked = True : Else : Cb3_18.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 19, 1) = "1" Then : Cb3_19.Checked = True : Else : Cb3_19.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 20, 1) = "1" Then : Cb3_20.Checked = True : Else : Cb3_20.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 21, 1) = "1" Then : Cb3_21.Checked = True : Else : Cb3_21.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 22, 1) = "1" Then : Cb3_22.Checked = True : Else : Cb3_22.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 23, 1) = "1" Then : Cb3_23.Checked = True : Else : Cb3_23.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 24, 1) = "1" Then : Cb3_24.Checked = True : Else : Cb3_24.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 25, 1) = "1" Then : Cb3_25.Checked = True : Else : Cb3_25.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 26, 1) = "1" Then : Cb3_26.Checked = True : Else : Cb3_26.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 27, 1) = "1" Then : Cb3_27.Checked = True : Else : Cb3_27.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 28, 1) = "1" Then : Cb3_28.Checked = True : Else : Cb3_28.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 29, 1) = "1" Then : Cb3_29.Checked = True : Else : Cb3_29.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生產").Value, 30, 1) = "1" Then : Cb3_30.Checked = True : Else : Cb3_30.Checked = False : End If
        Tb3其他.Text = T2DGV.CurrentRow.Cells("其他_生產").Value
        If T2DGV.CurrentRow.Cells("生產").Value = "" Then : Lt3記錄.Text = "" : Else : Lt3記錄.Text = "已存檔" : End If


        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 1, 1) = "1" Then : Cb4_01.Checked = True : Else : Cb4_01.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 2, 1) = "1" Then : Cb4_02.Checked = True : Else : Cb4_02.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 3, 1) = "1" Then : Cb4_03.Checked = True : Else : Cb4_03.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 4, 1) = "1" Then : Cb4_04.Checked = True : Else : Cb4_04.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 5, 1) = "1" Then : Cb4_05.Checked = True : Else : Cb4_05.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 6, 1) = "1" Then : Cb4_06.Checked = True : Else : Cb4_06.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 7, 1) = "1" Then : Cb4_07.Checked = True : Else : Cb4_07.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 8, 1) = "1" Then : Cb4_08.Checked = True : Else : Cb4_08.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 9, 1) = "1" Then : Cb4_09.Checked = True : Else : Cb4_09.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 10, 1) = "1" Then : Cb4_10.Checked = True : Else : Cb4_10.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 11, 1) = "1" Then : Cb4_11.Checked = True : Else : Cb4_11.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 12, 1) = "1" Then : Cb4_12.Checked = True : Else : Cb4_12.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("生管").Value, 13, 1) = "1" Then : Cb4_13.Checked = True : Else : Cb4_13.Checked = False : End If
        Tb4其他.Text = T2DGV.CurrentRow.Cells("其他_生管").Value
        If T2DGV.CurrentRow.Cells("生管").Value = "" Then : Lt4記錄.Text = "" : Else : Lt4記錄.Text = "已存檔" : End If

        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 1, 1) = "1" Then : Cb5_01.Checked = True : Else : Cb5_01.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 2, 1) = "1" Then : Cb5_02.Checked = True : Else : Cb5_02.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 3, 1) = "1" Then : Cb5_03.Checked = True : Else : Cb5_03.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 4, 1) = "1" Then : Cb5_04.Checked = True : Else : Cb5_04.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 5, 1) = "1" Then : Cb5_05.Checked = True : Else : Cb5_05.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 6, 1) = "1" Then : Cb5_06.Checked = True : Else : Cb5_06.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 7, 1) = "1" Then : Cb5_07.Checked = True : Else : Cb5_07.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 8, 1) = "1" Then : Cb5_08.Checked = True : Else : Cb5_08.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 9, 1) = "1" Then : Cb5_09.Checked = True : Else : Cb5_09.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 10, 1) = "1" Then : Cb5_10.Checked = True : Else : Cb5_10.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 11, 1) = "1" Then : Cb5_11.Checked = True : Else : Cb5_11.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 12, 1) = "1" Then : Cb5_12.Checked = True : Else : Cb5_12.Checked = False : End If
        If Mid(T2DGV.CurrentRow.Cells("營業").Value, 13, 1) = "1" Then : Cb5_13.Checked = True : Else : Cb5_13.Checked = False : End If
        Tb5其他.Text = T2DGV.CurrentRow.Cells("其他_營業").Value
        If T2DGV.CurrentRow.Cells("營業").Value = "" Then : Lt5記錄.Text = "" : Else : Lt5記錄.Text = "已存檔" : End If
        If T2DGV.CurrentRow.Cells("鎖定").Value = "N" Then : Lt5鎖定.Text = "未鎖定" : Else : Lt5鎖定.Text = "已鎖定" : End If

    End Sub


    Private Sub 時段明細查詢()
        If DGV4.RowCount > 0 Then : 顯示資料.Tables("明細記錄").Clear() : End If '清除DGV1資料
        If CB時段.Checked = True Then : Exit Sub : End If
        Dim SQLQuery As String = ""
        SQLQuery = "   SELECT [生產單號],[製造單號],[日期],[條碼],[存編],[品名],[客戶],[時段],[時段代碼],[過磅應完成時間],[實際過磅時間],[需刷人時間],[實際刷人時間],[差距分鐘] "
        SQLQuery += "    FROM [KaiShingPlug].[dbo].[檢_刷入庫時間] T0 "
        SQLQuery += "   WHERE T0.[日期] = '" & Format(日期.Value.Date, "yyyy-MM-dd") & "' AND T0.[時段代碼] =  '" & 時段.SelectedValue & "' "
        Select Case 樓層.SelectedIndex
            Case "0" : SQLQuery += " AND (SUBSTRING([條碼], 1, 1) IN ('E', 'W', 'F')) "
            Case "1" : SQLQuery += " AND (SUBSTRING([條碼], 1, 1) IN ('R', 'Q', 'C', 'M')) "
            Case "2" : SQLQuery += " AND (SUBSTRING([條碼], 1, 1) IN ('J', 'N')) "
        End Select

        'MsgBox(SQLQuery)
        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "明細記錄") : DGV4.DataSource = 顯示資料.Tables("明細記錄") : DGV4.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("時段明細查詢：" & ex.Message)
        End Try
    End Sub

    Private Sub 時段比對查詢(ByVal Type As String)
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""
        Dim 樓層I As Integer : Dim 時段I As Integer
        If CB時段.Checked = True Then
            樓層I = 樓層.SelectedIndex
            時段I = 99
            'Lt2日期.Text = ""
            Lt2日期.Text = Format(日期.Value.Date, "yyyy-MM-dd")
            'Lt2樓層.Text = ""
            Lt2樓層.Text = 樓層.Text
            Lt2時段.Text = ""
        Else
            樓層I = 樓層.SelectedIndex
            時段I = 時段.SelectedValue
            Lt2日期.Text = Format(日期.Value.Date, "yyyy-MM-dd")
            'Lt2樓層.Text = "二樓"
            Lt2樓層.Text = 樓層.Text
            Lt2時段.Text = 時段.Text
        End If

        Select Case Type
            Case "1"
                If DGV1.RowCount > 0 Then : 顯示資料.Tables("時段排程").Clear() : End If '清除DGV1資料
                SQLQuery += " EXEC [dbo].[預_時段比對01v] "
                'SQLQuery += " N'" & Type & "',N'1',N'" & 時段I & "',N'" & Format(日期.Value, "yyyy-MM-dd") & "',N'2' "
                SQLQuery += " N'" & Type & "',N'" & 樓層I & "',N'" & 時段I & "',N'" & Format(日期.Value, "yyyy-MM-dd") & "',N'2' "
                '                   作業            樓層             時段                    日期                             製單
            Case "2", "3"
                If DGV3.RowCount > 0 Then : 顯示資料.Tables("時段比對").Clear() : End If '清除DGV3資料
                SQLQuery += " EXEC [dbo].[預_時段比對01v] "
                'SQLQuery += " N'" & Type & "',N'1',N'" & 時段I & "',N'" & Format(日期.Value, "yyyy-MM-dd") & "',N'2' "
                SQLQuery += " N'" & Type & "',N'" & 樓層I & "',N'" & 時段I & "',N'" & Format(日期.Value, "yyyy-MM-dd") & "',N'2' "
                'Case "3"
        End Select
        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            Select Case Type
                Case "1"
                    DataAdapterDGV.Fill(顯示資料, "時段排程") : DGV1.DataSource = 顯示資料.Tables("時段排程") : DGV1.AutoResizeColumns()
                Case "2", "3"
                    DataAdapterDGV.Fill(顯示資料, "時段比對") : DGV3.DataSource = 顯示資料.Tables("時段比對") : DGV3.AutoResizeColumns()
            End Select
            DGV3Display()
        Catch ex As Exception
            MsgBox("時段比對查詢：" & ex.Message)
        End Try
    End Sub

    Private Sub DGV3Display()
        '--載入資料畫面
        For Each column As DataGridViewColumn In DGV3.Columns

            'DGV1.AllowUserToAddRows = False
            'DGV1.AllowUserToDeleteRows = False
            'column.ReadOnly = True  'DataGridView 設定單元格不可編輯
            column.Visible = True
            Select Case column.Name
                Case "時段" : column.HeaderText = "時段" : column.DisplayIndex = 0
                Case "時段代碼" : column.HeaderText = "時段代碼" : column.DisplayIndex = 1
                Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 2
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 3 : column.Visible = False
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 4 : column.Visible = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5
                Case "排程數量" : column.HeaderText = "排程數量" : column.DisplayIndex = 6
                Case "實際數量" : column.HeaderText = "實際數量" : column.DisplayIndex = 7
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 8 : column.Visible = False
                Case "件數量" : column.HeaderText = "件數量" : column.DisplayIndex = 9 : column.Visible = False
                Case "未入庫數量" : column.HeaderText = "未入庫數量" : column.DisplayIndex = 10
                Case "差異排程數量" : column.HeaderText = "差異排程數量" : column.DisplayIndex = 11
                Case "最後時間" : column.HeaderText = "最後時間" : column.DisplayIndex = 12
                Case "記錄時間" : column.HeaderText = "記錄時間" : column.DisplayIndex = 13
                Case Else
                    column.Visible = False

            End Select
        Next

        DGV3.AutoResizeColumns()

    End Sub



    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click
        'If La月份.Text = "" Then : Exit Sub : End If
        If DGV3.RowCount = 0 Then : Exit Sub : End If
        DataToExcel(DGV3, "時段比對異常" & Replace(時段.Text, ":", ""))
    End Sub

    Private Sub Bu7匯出_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu7匯出.Click
        If DGV7.RowCount = 0 Then : Exit Sub : End If
        DataToExcel(DGV7, "時段比對異常統計")
    End Sub

    Private Sub Bu存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2存檔.Click, Bu3存檔.Click, Bu4存檔.Click, Bu5存檔.Click
        Bu2存檔_作業(單位)
        '初始作業()
        時段異常記錄查詢()
        倉庫時段異常記錄查詢2()
        MsgBox("存檔結束")

    End Sub

    Private Sub Bu2存檔_作業(ByVal Type As String)


        Dim DCb2 As String = "" : Dim DCb2_5_其他 As String = "" : Dim DRb2 As String = ""
        Dim DCb2_1 As String = "0" : Dim DCb2_2 As String = "0" : Dim DCb2_3 As String = "0" : Dim DCb2_4 As String = "0" : Dim DCb2_5 As String = "0"
        Dim DCb2_6 As String = "0" : Dim DCb2_7 As String = "0"

        Dim DCb3 As String = "" : Dim DCb3_30_其他 As String = ""
        Dim DCb3_01 As String = "0" : Dim DCb3_02 As String = "0" : Dim DCb3_03 As String = "0" : Dim DCb3_04 As String = "0" : Dim DCb3_05 As String = "0"
        Dim DCb3_06 As String = "0" : Dim DCb3_07 As String = "0" : Dim DCb3_08 As String = "0" : Dim DCb3_09 As String = "0" : Dim DCb3_10 As String = "0"
        Dim DCb3_11 As String = "0" : Dim DCb3_12 As String = "0" : Dim DCb3_13 As String = "0" : Dim DCb3_14 As String = "0" : Dim DCb3_15 As String = "0"
        Dim DCb3_16 As String = "0" : Dim DCb3_17 As String = "0" : Dim DCb3_18 As String = "0" : Dim DCb3_19 As String = "0" : Dim DCb3_20 As String = "0"
        Dim DCb3_21 As String = "0" : Dim DCb3_22 As String = "0" : Dim DCb3_23 As String = "0" : Dim DCb3_24 As String = "0" : Dim DCb3_25 As String = "0"
        Dim DCb3_26 As String = "0" : Dim DCb3_27 As String = "0" : Dim DCb3_28 As String = "0" : Dim DCb3_29 As String = "0" : Dim DCb3_30 As String = "0"

        Dim DCb4 As String = "" : Dim DCb4_11_其他 As String = ""
        Dim DCb4_01 As String = "0" : Dim DCb4_02 As String = "0" : Dim DCb4_03 As String = "0" : Dim DCb4_04 As String = "0" : Dim DCb4_05 As String = "0"
        Dim DCb4_06 As String = "0" : Dim DCb4_07 As String = "0" : Dim DCb4_08 As String = "0" : Dim DCb4_09 As String = "0" : Dim DCb4_10 As String = "0"
        Dim DCb4_11 As String = "0" : Dim DCb4_12 As String = "0" : Dim DCb4_13 As String = "0"

        Dim DCb5 As String = "" : Dim DCb5_13_其他 As String = ""
        Dim DCb5_01 As String = "0" : Dim DCb5_02 As String = "0" : Dim DCb5_03 As String = "0" : Dim DCb5_04 As String = "0" : Dim DCb5_05 As String = "0"
        Dim DCb5_06 As String = "0" : Dim DCb5_07 As String = "0" : Dim DCb5_08 As String = "0" : Dim DCb5_09 As String = "0" : Dim DCb5_10 As String = "0"
        Dim DCb5_11 As String = "0" : Dim DCb5_12 As String = "0" : Dim DCb5_13 As String = "0"


        Select Case Type '單位
            Case "倉庫"
                If Lt2日期.Text <> "" And Lt2樓層.Text <> "" And Lt2時段.Text <> "" Then
                    If Cb2_1.Checked = True Then : DCb2_1 = "1" : End If
                    If Cb2_2.Checked = True Then : DCb2_2 = "1" : End If
                    If Cb2_3.Checked = True Then : DCb2_3 = "1" : End If
                    If Cb2_4.Checked = True Then : DCb2_4 = "1" : End If
                    If Cb2_6.Checked = True Then : DCb2_6 = "1" : End If
                    If Cb2_7.Checked = True Then : DCb2_7 = "1" : End If
                    If Cb2_5.Checked = True Then : DCb2_5 = "1" : End If : DCb2_5_其他 = Tb2其他.Text
                    DCb2 = DCb2_1 + DCb2_2 + DCb2_3 + DCb2_4 + DCb2_5 + DCb2_6 + DCb2_7
                    If Rb2正常.Checked = True Then : DRb2 = "Y" : Else : DRb2 = "N" : End If
                End If
            Case "生產"
                If Cb3_01.Checked = True Then : DCb3_01 = "1" : End If : If Cb3_02.Checked = True Then : DCb3_02 = "1" : End If
                If Cb3_03.Checked = True Then : DCb3_03 = "1" : End If : If Cb3_04.Checked = True Then : DCb3_04 = "1" : End If
                If Cb3_05.Checked = True Then : DCb3_05 = "1" : End If : If Cb3_06.Checked = True Then : DCb3_06 = "1" : End If
                If Cb3_07.Checked = True Then : DCb3_07 = "1" : End If : If Cb3_08.Checked = True Then : DCb3_08 = "1" : End If
                If Cb3_09.Checked = True Then : DCb3_09 = "1" : End If : If Cb3_10.Checked = True Then : DCb3_10 = "1" : End If
                If Cb3_11.Checked = True Then : DCb3_11 = "1" : End If : If Cb3_12.Checked = True Then : DCb3_12 = "1" : End If
                If Cb3_13.Checked = True Then : DCb3_13 = "1" : End If : If Cb3_14.Checked = True Then : DCb3_14 = "1" : End If
                If Cb3_15.Checked = True Then : DCb3_15 = "1" : End If : If Cb3_16.Checked = True Then : DCb3_16 = "1" : End If
                If Cb3_17.Checked = True Then : DCb3_17 = "1" : End If : If Cb3_18.Checked = True Then : DCb3_18 = "1" : End If
                If Cb3_19.Checked = True Then : DCb3_19 = "1" : End If : If Cb3_20.Checked = True Then : DCb3_20 = "1" : End If
                If Cb3_21.Checked = True Then : DCb3_21 = "1" : End If : If Cb3_22.Checked = True Then : DCb3_22 = "1" : End If
                If Cb3_23.Checked = True Then : DCb3_23 = "1" : End If : If Cb3_24.Checked = True Then : DCb3_24 = "1" : End If
                If Cb3_25.Checked = True Then : DCb3_25 = "1" : End If : If Cb3_26.Checked = True Then : DCb3_26 = "1" : End If
                If Cb3_27.Checked = True Then : DCb3_27 = "1" : End If : If Cb3_28.Checked = True Then : DCb3_28 = "1" : End If
                If Cb3_29.Checked = True Then : DCb3_29 = "1" : End If
                If Cb3_30.Checked = True Then : DCb3_30 = "1" : End If : DCb3_30_其他 = Tb3其他.Text
                DCb3 = DCb3_01 + DCb3_02 + DCb3_03 + DCb3_04 + DCb3_05 + DCb3_06 + DCb3_07 + DCb3_08 + DCb3_09 + DCb3_10
                DCb3 += DCb3_11 + DCb3_12 + DCb3_13 + DCb3_14 + DCb3_15 + DCb3_16 + DCb3_17 + DCb3_18 + DCb3_19 + DCb3_20
                DCb3 += DCb3_21 + DCb3_22 + DCb3_23 + DCb3_24 + DCb3_25 + DCb3_26 + DCb3_27 + DCb3_28 + DCb3_29 + DCb3_30
            Case "生管"
                If Cb4_01.Checked = True Then : DCb4_01 = "1" : End If : If Cb4_02.Checked = True Then : DCb4_02 = "1" : End If
                If Cb4_03.Checked = True Then : DCb4_03 = "1" : End If : If Cb4_04.Checked = True Then : DCb4_04 = "1" : End If
                If Cb4_05.Checked = True Then : DCb4_05 = "1" : End If : If Cb4_06.Checked = True Then : DCb4_06 = "1" : End If
                If Cb4_07.Checked = True Then : DCb4_07 = "1" : End If : If Cb4_08.Checked = True Then : DCb4_08 = "1" : End If
                If Cb4_09.Checked = True Then : DCb4_09 = "1" : End If : If Cb4_10.Checked = True Then : DCb4_10 = "1" : End If
                If Cb4_11.Checked = True Then : DCb4_11 = "1" : End If : DCb4_11_其他 = Tb4其他.Text
                If Cb4_12.Checked = True Then : DCb4_12 = "1" : End If : If Cb4_13.Checked = True Then : DCb4_13 = "1" : End If
                DCb4 = DCb4_01 + DCb4_02 + DCb4_03 + DCb4_04 + DCb4_05 + DCb4_06 + DCb4_07 + DCb4_08 + DCb4_09 + DCb4_10
                DCb4 += DCb4_11 + DCb4_12 + DCb4_13
            Case "營業"
                If Cb5_01.Checked = True Then : DCb5_01 = "1" : End If : If Cb5_02.Checked = True Then : DCb5_02 = "1" : End If
                If Cb5_03.Checked = True Then : DCb5_03 = "1" : End If : If Cb5_04.Checked = True Then : DCb5_04 = "1" : End If
                If Cb5_05.Checked = True Then : DCb5_05 = "1" : End If : If Cb5_06.Checked = True Then : DCb5_06 = "1" : End If
                If Cb5_07.Checked = True Then : DCb5_07 = "1" : End If : If Cb5_08.Checked = True Then : DCb5_08 = "1" : End If
                If Cb5_09.Checked = True Then : DCb5_09 = "1" : End If : If Cb5_10.Checked = True Then : DCb5_10 = "1" : End If
                If Cb5_11.Checked = True Then : DCb5_11 = "1" : End If : If Cb5_12.Checked = True Then : DCb5_12 = "1" : End If
                If Cb5_13.Checked = True Then : DCb5_13 = "1" : End If : DCb5_13_其他 = Tb5其他.Text
                DCb5 = DCb5_01 + DCb5_02 + DCb5_03 + DCb5_04 + DCb5_05 + DCb5_06 + DCb5_07 + DCb5_08 + DCb5_09 + DCb5_10
                DCb5 += DCb5_11 + DCb5_12 + DCb5_13

            Case Else
        End Select

        Dim SQLADD表頭 As String = "" : Dim SQLUP1 As String = "" : Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        Select Case Type '單位
            Case "倉庫"
                SQLUP1 = "  UPDATE [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLUP1 += "    SET [啟用]     = 'N', [修改時間] = GETDATE() "
                SQLUP1 += "  WHERE [日期] = '" & Lt2日期.Text & "' AND [樓層] = '" & Lt2樓層.Text & "' AND [時段] = '" & Lt2時段.Text & "' AND [單位] = '" & 單位 & "' AND [啟用] = 'Y' " & vbCrLf
                SQLADD1 = "  INSERT INTO [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLADD1 += " ([日期],[樓層],[時段],[單位],[正常否],[異常],[其他],[啟用],[新增時間],[輸入者]) VALUES "
                SQLADD1 += " ('" & Lt2日期.Text & "','" & Lt2樓層.Text & "','" & Lt2時段.Text & "','" & 單位 & "','" & DRb2 & "', "
                SQLADD1 += "  '" & DCb2 & "','" & DCb2_5_其他 & "','Y',GETDATE(),'" & UCase(Login.LogonUserName) & "' ) " & vbCrLf
            Case "生產"
                SQLUP1 = "  UPDATE [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLUP1 += "    SET [啟用]     = 'N', [修改時間] = GETDATE() "
                SQLUP1 += "  WHERE [日期] = '" & Lt2日期.Text & "' AND [樓層] = '" & Lt2樓層.Text & "' AND [時段] = '" & Lt2時段.Text & "' AND [單位] = '" & 單位 & "' AND [啟用] = 'Y' " & vbCrLf
                SQLADD1 = "  INSERT INTO [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLADD1 += " ([日期],[樓層],[時段],[單位],[異常],[其他],[啟用],[新增時間],[輸入者]) VALUES "
                SQLADD1 += " ('" & Lt2日期.Text & "','" & Lt2樓層.Text & "','" & Lt2時段.Text & "','" & 單位 & "', "
                SQLADD1 += "  '" & DCb3 & "','" & DCb3_30_其他 & "','Y',GETDATE(),'" & UCase(Login.LogonUserName) & "' ) " & vbCrLf
            Case "生管"
                SQLUP1 = "  UPDATE [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLUP1 += "    SET [啟用]     = 'N', [修改時間] = GETDATE() "
                SQLUP1 += "  WHERE [日期] = '" & Lt2日期.Text & "' AND [樓層] = '" & Lt2樓層.Text & "' AND [時段] = '" & Lt2時段.Text & "' AND [單位] = '" & 單位 & "' AND [啟用] = 'Y' " & vbCrLf
                SQLADD1 = "  INSERT INTO [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLADD1 += " ([日期],[樓層],[時段],[單位],[異常],[其他],[啟用],[新增時間],[輸入者]) VALUES "
                SQLADD1 += " ('" & Lt2日期.Text & "','" & Lt2樓層.Text & "','" & Lt2時段.Text & "','" & 單位 & "', "
                SQLADD1 += "  '" & DCb4 & "','" & DCb4_11_其他 & "','Y',GETDATE(),'" & UCase(Login.LogonUserName) & "' ) " & vbCrLf
            Case "營業"
                SQLUP1 = "  UPDATE [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLUP1 += "    SET [啟用]     = 'N', [修改時間] = GETDATE() "
                SQLUP1 += "  WHERE [日期] = '" & Lt2日期.Text & "' AND [樓層] = '" & Lt2樓層.Text & "' AND [時段] = '" & Lt2時段.Text & "' AND [單位] = '" & 單位 & "' AND [啟用] = 'Y' " & vbCrLf
                SQLADD1 = "  INSERT INTO [KaiShingPlug].[dbo].[存_排程異常記錄] "
                SQLADD1 += " ([日期],[樓層],[時段],[單位],[異常],[其他],[啟用],[新增時間],[輸入者]) VALUES "
                SQLADD1 += " ('" & Lt2日期.Text & "','" & Lt2樓層.Text & "','" & Lt2時段.Text & "','" & 單位 & "', "
                SQLADD1 += "  '" & DCb5 & "','" & DCb5_13_其他 & "','Y',GETDATE(),'" & UCase(Login.LogonUserName) & "' ) " & vbCrLf
            Case Else
        End Select


        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLUP1 + SQLADD1 + SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Bu4鎖定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu4鎖定.Click
        If Lt5記錄.Text = "已存檔" Then
            If CStr(日期.Text) <> "" And Lt5記錄.Text = "已存檔" And Lt2單位.Text = "營業" Then
                Dim oAns As Integer
                oAns = MsgBox("是否確定鎖定資料" & 日期.Text, MsgBoxStyle.YesNo, "鎖定日期")
                If oAns = MsgBoxResult.Yes Then  'Yes執行區
                    Bu4鎖定_作業()
                    'Bu查詢.PerformClick()
                    時段異常記錄查詢()
                    倉庫時段異常記錄查詢2()
                    MsgBox("鎖定完成")
                End If
            End If
        Else
            MsgBox("請先存檔後在按鎖定資料")
        End If
    End Sub

    Private Sub Bu4鎖定_作業()
        Dim SQLUP1 As String = ""

        SQLUP1 = "  UPDATE [KaiShingPlug].[dbo].[存_排程異常記錄] "
        SQLUP1 += "    SET [鎖定]     = 'Y', [修改時間] = GETDATE() "
        SQLUP1 += "  WHERE [日期] = '" & Lt2日期.Text & "' AND [樓層] = '" & Lt2樓層.Text & "' AND [啟用] = 'Y' " & vbCrLf
        'SQLUP1 += "  WHERE [日期] = '" & Lt2日期.Text & "' AND [樓層] = '" & Lt2樓層.Text & "' AND [時段] = '" & Lt2時段.Text & "' AND [啟用] = 'Y' " & vbCrLf

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLUP1 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Bu7查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu7查詢.Click
        Bu7查詢_作業(單位)
    End Sub

    Private Sub Bu7查詢_作業(ByVal Type As String)
        If DGV7.RowCount > 0 Then : 顯示資料.Tables("異常統計").Clear() : End If '清除DGV資料
        Dim SQLQuery As String = "" : Dim SQLUP1 As String = "" : Dim SQLADD1 As String = "" : Dim SQLADD2 As String = ""

        'Select Case Type '單位
        '    Case "倉庫"
        '    Case "生產"
        '    Case "生管"
        '    Case "營業"
        '    Case Else
        'End Select

        SQLQuery += " EXEC [KaiShingPlug].[dbo].[預_時段比對01v3] "
        SQLQuery += " N'" & Format(D7日期1.Value, "yyyy-MM-dd") & "',N'" & Format(D7日期2.Value, "yyyy-MM-dd") & "',N'" & Lt2樓層.Text & "',N'" & Type & "' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "異常統計") : DGV7.DataSource = 顯示資料.Tables("異常統計") : DGV7.AutoResizeColumns()
            DGV7Display(單位)
        Catch ex As Exception
            MsgBox("時段比對查詢異常：" & ex.Message)
        End Try




    End Sub

    Private Sub DGV7Display(ByVal Type As String)
        '--載入資料畫面
        For Each column As DataGridViewColumn In DGV7.Columns
            column.Visible = True
            Select Case Type '單位
                Case "倉庫"
                    Select Case column.Name
                        Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 0
                        Case "總計" : column.HeaderText = "總計" : column.DisplayIndex = 1
                        Case "結束" : column.HeaderText = "結束" : column.DisplayIndex = 2 : column.Visible = False
                        Case "01" : column.HeaderText = "01.排程數與實際產出有差異" : column.DisplayIndex = 3
                        Case "02" : column.HeaderText = "02.有排程,無產出" : column.DisplayIndex = 4
                        Case "03" : column.HeaderText = "03.庫區延遲入庫" : column.DisplayIndex = 5
                        Case "04" : column.HeaderText = "04.排程單位與產出單位不同" : column.DisplayIndex = 6
                        Case "06" : column.HeaderText = "05.生產延遲磅入" : column.DisplayIndex = 7
                        Case "07" : column.HeaderText = "06.庫區時間內上傳,行政未即時回存" : column.DisplayIndex = 8
                        Case "05" : column.HeaderText = "07.其他" : column.DisplayIndex = 9
                        Case Else
                            column.Visible = False
                    End Select
                Case "生產"
                    Select Case column.Name
                        Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 0
                        Case "總計" : column.HeaderText = "總計" : column.DisplayIndex = 1
                        Case "結束" : column.HeaderText = "結束" : column.DisplayIndex = 2 : column.Visible = False
                        Case "01" : column.HeaderText = "01" : column.DisplayIndex = 3
                        Case "02" : column.HeaderText = "02" : column.DisplayIndex = 4
                        Case "03" : column.HeaderText = "03" : column.DisplayIndex = 5
                        Case "04" : column.HeaderText = "04" : column.DisplayIndex = 6
                        Case "05" : column.HeaderText = "05" : column.DisplayIndex = 7
                        Case "06" : column.HeaderText = "06" : column.DisplayIndex = 8
                        Case "07" : column.HeaderText = "07" : column.DisplayIndex = 9
                        Case "08" : column.HeaderText = "08" : column.DisplayIndex = 10
                        Case "09" : column.HeaderText = "09" : column.DisplayIndex = 11
                        Case "10" : column.HeaderText = "10" : column.DisplayIndex = 12
                        Case "11" : column.HeaderText = "11" : column.DisplayIndex = 13
                        Case "12" : column.HeaderText = "12" : column.DisplayIndex = 14
                        Case "13" : column.HeaderText = "13" : column.DisplayIndex = 15
                        Case "14" : column.HeaderText = "14" : column.DisplayIndex = 16
                        Case "15" : column.HeaderText = "15" : column.DisplayIndex = 17
                        Case "16" : column.HeaderText = "16" : column.DisplayIndex = 18
                        Case "17" : column.HeaderText = "17" : column.DisplayIndex = 19
                        Case "18" : column.HeaderText = "18" : column.DisplayIndex = 20
                        Case "19" : column.HeaderText = "19" : column.DisplayIndex = 21
                        Case "20" : column.HeaderText = "20" : column.DisplayIndex = 22
                        Case "21" : column.HeaderText = "21" : column.DisplayIndex = 23
                        Case "22" : column.HeaderText = "22" : column.DisplayIndex = 24
                        Case "23" : column.HeaderText = "23" : column.DisplayIndex = 25
                        Case "24" : column.HeaderText = "24" : column.DisplayIndex = 26
                        Case "25" : column.HeaderText = "25" : column.DisplayIndex = 27
                        Case "26" : column.HeaderText = "26" : column.DisplayIndex = 28
                        Case "27" : column.HeaderText = "27" : column.DisplayIndex = 29
                        Case "28" : column.HeaderText = "28" : column.DisplayIndex = 30
                        Case "29" : column.HeaderText = "29" : column.DisplayIndex = 31
                        Case "30" : column.HeaderText = "30" : column.DisplayIndex = 32
                        Case Else
                            column.Visible = False
                    End Select
                Case "生管"
                    Select Case column.Name
                        Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 0
                        Case "總計" : column.HeaderText = "總計" : column.DisplayIndex = 1
                        Case "結束" : column.HeaderText = "結束" : column.DisplayIndex = 2 : column.Visible = False
                        Case "01" : column.HeaderText = "01" : column.DisplayIndex = 3
                        Case "02" : column.HeaderText = "02" : column.DisplayIndex = 4
                        Case "03" : column.HeaderText = "03" : column.DisplayIndex = 5
                        Case "04" : column.HeaderText = "04" : column.DisplayIndex = 6
                        Case "05" : column.HeaderText = "05" : column.DisplayIndex = 7
                        Case "06" : column.HeaderText = "06" : column.DisplayIndex = 8
                        Case "07" : column.HeaderText = "07" : column.DisplayIndex = 9
                        Case "08" : column.HeaderText = "08" : column.DisplayIndex = 10
                        Case "09" : column.HeaderText = "09" : column.DisplayIndex = 11
                        Case "10" : column.HeaderText = "10" : column.DisplayIndex = 12
                        Case "11" : column.HeaderText = "11" : column.DisplayIndex = 13
                        Case "12" : column.HeaderText = "12" : column.DisplayIndex = 14
                        Case "13" : column.HeaderText = "13" : column.DisplayIndex = 15
                        Case Else
                            column.Visible = False
                    End Select
                Case "營業"
                    Select Case column.Name
                        Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 0
                        Case "總計" : column.HeaderText = "總計" : column.DisplayIndex = 1
                        Case "結束" : column.HeaderText = "結束" : column.DisplayIndex = 2 : column.Visible = False
                        Case "01" : column.HeaderText = "01" : column.DisplayIndex = 3
                        Case "02" : column.HeaderText = "02" : column.DisplayIndex = 4
                        Case "03" : column.HeaderText = "03" : column.DisplayIndex = 5
                        Case "04" : column.HeaderText = "04" : column.DisplayIndex = 6
                        Case "05" : column.HeaderText = "05" : column.DisplayIndex = 7
                        Case "06" : column.HeaderText = "06" : column.DisplayIndex = 8
                        Case "07" : column.HeaderText = "07" : column.DisplayIndex = 9
                        Case "08" : column.HeaderText = "08" : column.DisplayIndex = 10
                        Case "09" : column.HeaderText = "09" : column.DisplayIndex = 11
                        Case "10" : column.HeaderText = "10" : column.DisplayIndex = 12
                        Case "11" : column.HeaderText = "11" : column.DisplayIndex = 13
                        Case "12" : column.HeaderText = "12" : column.DisplayIndex = 14
                        Case "13" : column.HeaderText = "13" : column.DisplayIndex = 15
                        Case Else
                            column.Visible = False
                    End Select
                Case Else
            End Select
        Next

        DGV7.AutoResizeColumns()

    End Sub


End Class