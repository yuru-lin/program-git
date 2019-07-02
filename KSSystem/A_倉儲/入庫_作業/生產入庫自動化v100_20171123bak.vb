Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 生產入庫自動化v100Bak



    '暫存資料庫名
    Dim SyncPDA1 As String = ""
    Dim SyncPDA2 As String = ""
    Dim SyncPDA3 As String = ""

    '作業需求
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


    Private Sub 生產入庫自動化v100_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        即時時間.Enabled = True
        即時時間.Interval = 100

        La作業.Text = "入庫"
        SyncPDA1 = Format(Replace(Replace("#SyncPDAtmp1" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '初始
        SyncPDA2 = Format(Replace(Replace("#SyncPDAtmp2" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '整合
        SyncPDA3 = Format(Replace(Replace("#SyncPDAtmp3" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '結果


    End Sub

    Private Sub 生產入庫自動化v100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        文字初始化()



    End Sub

    Private Sub 即時時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 即時時間.Tick
        '電腦時間.Text = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        電腦時間.Text = Now()

        Select Case Format(Now(), "mm") '依分鐘為單位
            Case "00", "15", "30", "45"
                Bu讀取.PerformClick()
                '時段作業()
                '時段比對查詢(1)
                '時段比對查詢(2)
        End Select

    End Sub

    Private Sub 文字初始化()
        La數量.Text = "0筆"
        La入庫.Text = "0筆"
        La出庫.Text = "0筆"
        La作廢.Text = "0筆"
        La異常.Text = "0筆"
        La重複.Text = "0筆"
        La時間.Text = "查詢時間 0.00 秒"

        'CB作業別.Items.Clear()
        'CB顯示鮮享.Visible = False

        'Select Case La作業.Text
        '    Case "入庫"
        '        CB作業別.Visible = True
        '        Bu更換.Visible = True
        '        Bu勾選.Visible = False
        '        CB作業別.Items.Add("")
        '        CB作業別.Items.Add("11.電宰入庫")
        '        CB作業別.Items.Add("12.加工入庫")

        '    Case "出庫"
        '        CB作業別.Visible = False
        '        Bu更換.Visible = False
        '        Bu勾選.Visible = True
        '        CB作業別.Items.Add("")
        '        'CB作業別.Items.Add("")
        '        'CB作業別.Items.Add("")
        '        CB顯示鮮享.Visible = True

        '    Case "單據入庫"
        '        CB作業別.Visible = False
        '        Bu更換.Visible = False
        '        Bu勾選.Visible = False
        '        CB作業別.Items.Add("")
        '        'CB作業別.Items.Add("")
        '        'CB作業別.Items.Add("")

        'End Select

    End Sub


    'PDA作業開始
    Private Sub Bu讀取_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu讀取.Click
        dteStart = Now  ''...要計算執行時間的程式區段 ...
        清除暫存()

        Select Case La作業.Text
            Case "入庫"
                ''入庫代碼 = "'11','12'"
                '讀取條碼入庫() : DGV1選擇 = "N"
                '讀取條碼儲位()
                'DGV1_入庫檢查資料()
            Case "出庫"
                '讀取條碼出庫() : DGV1選擇 = "N"
                'DGV1_出庫檢查資料()
            Case "單據入庫"
                ''入庫代碼 = "'13'"
                '讀取條碼入庫()
                '讀取條碼儲位()
                'DGV1_入庫檢查資料()
        End Select

        Dim 執行時間s As String = "0.00"
        Dim 執行時間a As TimeSpan = Now.Subtract(dteStart)
        執行時間s = "查詢時間 " & Format(執行時間a.TotalSeconds, "###0.00" & " 秒")
        La時間.Text = 執行時間s

        DGV1.AutoResizeColumns()
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










End Class