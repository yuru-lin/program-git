Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 現場磅秤資訊V001
    Dim DataAdapterDGV As SqlDataAdapter
    'Dim 下拉明細 As DataSet = New DataSet
    Dim 顯示資料 As DataSet = New DataSet
    Dim 單位 As String = ""
    Dim 資料 As String = "無"
    Dim 時段1 As String = "0" : Dim 時段2 As String = "1"

    Private Sub 現場磅秤資訊V001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        即時時間.Enabled = True
        即時時間.Interval = 100
       
        時段作業()
        時段比對查詢(1)
        時段比對查詢(2)
    End Sub

    Private Sub 即時時間_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 即時時間.Tick
        '電腦時間.Text = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        電腦時間.Text = Now()

        Select Case Format(Now(), "mm:ss")
            Case "00:00", "03:00", "06:00", "09:00", "12:00", "15:00", "18:00", "21:00", "24:00", "27:00", "30:00", "33:00", "36:00", "39:00", "42:00", "45:00", "48:00", "51:00", "54:00", "57:00"
                時段作業()
                時段比對查詢(1)
                時段比對查詢(2)
        End Select


    End Sub

    Private Sub 時段作業()
        日期.Value = Today()

        'Dim Dats12 As DateTime = DateTime.Now
        'Dim Dats24 As String = Dats12.ToString("HH:mm")

        Dim 時間 As String = ""
        時間 = Format(Now(), "HH:mm")
        'MsgBox(時間 & "  " & Dats24)

        If 時間 >= "06:15" And 時間 <= "07:14" Then : 時段1 = "0" : 時段2 = "1" : End If
        If 時間 >= "07:15" And 時間 <= "07:44" Then : 時段1 = "1" : 時段2 = "2" : End If
        If 時間 >= "07:45" And 時間 <= "08:14" Then : 時段1 = "2" : 時段2 = "3" : End If
        If 時間 >= "08:15" And 時間 <= "08:44" Then : 時段1 = "3" : 時段2 = "4" : End If
        If 時間 >= "08:45" And 時間 <= "09:14" Then : 時段1 = "4" : 時段2 = "5" : End If
        If 時間 >= "09:15" And 時間 <= "09:44" Then : 時段1 = "5" : 時段2 = "6" : End If
        If 時間 >= "09:45" And 時間 <= "10:14" Then : 時段1 = "6" : 時段2 = "7" : End If
        If 時間 >= "10:15" And 時間 <= "10:44" Then : 時段1 = "7" : 時段2 = "8" : End If
        If 時間 >= "10:45" And 時間 <= "11:14" Then : 時段1 = "8" : 時段2 = "9" : End If
        If 時間 >= "11:15" And 時間 <= "11:44" Then : 時段1 = "9" : 時段2 = "10" : End If
        If 時間 >= "11:45" And 時間 <= "12:14" Then : 時段1 = "10" : 時段2 = "11" : End If
        If 時間 >= "12:15" And 時間 <= "12:44" Then : 時段1 = "11" : 時段2 = "12" : End If
        If 時間 >= "12:45" And 時間 <= "13:14" Then : 時段1 = "12" : 時段2 = "13" : End If
        If 時間 >= "13:15" And 時間 <= "13:44" Then : 時段1 = "13" : 時段2 = "14" : End If
        If 時間 >= "13:45" And 時間 <= "14:14" Then : 時段1 = "14" : 時段2 = "15" : End If
        If 時間 >= "14:15" And 時間 <= "14:44" Then : 時段1 = "15" : 時段2 = "16" : End If
        If 時間 >= "14:45" And 時間 <= "15:14" Then : 時段1 = "16" : 時段2 = "17" : End If
        If 時間 >= "15:15" And 時間 <= "15:44" Then : 時段1 = "17" : 時段2 = "18" : End If
        If 時間 >= "15:45" And 時間 <= "16:14" Then : 時段1 = "18" : 時段2 = "19" : End If
        If 時間 >= "16:15" And 時間 <= "16:44" Then : 時段1 = "19" : 時段2 = "20" : End If
        If 時間 >= "16:45" And 時間 <= "17:14" Then : 時段1 = "20" : 時段2 = "21" : End If
        If 時間 >= "17:15" And 時間 <= "17:44" Then : 時段1 = "21" : 時段2 = "22" : End If
        If 時間 >= "17:45" And 時間 <= "18:14" Then : 時段1 = "22" : 時段2 = "23" : End If
        If 時間 >= "18:15" And 時間 <= "18:44" Then : 時段1 = "23" : 時段2 = "24" : End If
        If 時間 >= "18:45" And 時間 <= "19:14" Then : 時段1 = "24" : 時段2 = "25" : End If
        If 時間 >= "19:15" And 時間 <= "19:44" Then : 時段1 = "25" : 時段2 = "26" : End If
        If 時間 >= "19:45" And 時間 <= "20:14" Then : 時段1 = "26" : 時段2 = "27" : End If
        If 時間 >= "20:15" And 時間 <= "20:44" Then : 時段1 = "27" : 時段2 = "28" : End If
        If 時間 >= "20:45" And 時間 <= "21:14" Then : 時段1 = "28" : 時段2 = "29" : End If
        If 時間 >= "21:15" And 時間 <= "21:44" Then : 時段1 = "29" : 時段2 = "30" : End If
        If 時間 >= "22:45" And 時間 <= "22:14" Then : 時段1 = "30" : 時段2 = "31" : End If
        If 時間 >= "22:15" And 時間 <= "22:44" Then : 時段1 = "31" : 時段2 = "32" : End If
        If 時間 >= "23:45" And 時間 <= "23:14" Then : 時段1 = "32" : 時段2 = "33" : End If
        If 時間 >= "23:15" And 時間 <= "23:44" Then : 時段1 = "33" : 時段2 = "34" : End If
        If 時間 >= "23:45" And 時間 <= "00:14" Then : 時段1 = "34" : 時段2 = "35" : End If
        If 時間 >= "00:15" And 時間 <= "06:14" Then : 時段1 = "35" : 時段2 = "0" : End If

        時段.SelectedIndex = 時段1
        目前時段.Text = "目前時段：" & 時段.Text

        時段.SelectedIndex = 時段2
        下個時段.Text = "下個時段：" & 時段.Text

        'MsgBox(時間 & "  " & 時段1 & "  " & 時段2)

    End Sub



    Private Sub 時段比對查詢(ByVal Type As String)
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""
        'Dim 時段I As Integer
        'If CB時段.Checked = True Then
        '    時段I = 99
        '    Lt2日期.Text = ""
        '    Lt2樓層.Text = ""
        '    Lt2時段.Text = ""
        'Else
        '    時段I = 時段.SelectedIndex
        '    Lt2日期.Text = Format(日期.Value.Date, "yyyy-MM-dd")
        '    Lt2樓層.Text = "二樓"  '樓層.Text
        '    Lt2時段.Text = 時段.Text
        'End If
        Dim 樓層 As String = "1"
        Select Case UCase(GetHostName())
            Case "KS-Y1-4"
                樓層 = 0
            Case "KS-Y2-14"
                樓層 = 1
        End Select

        Select Case Type
            Case "1"
                If DGV3.RowCount > 0 Then : 顯示資料.Tables("時段排程3").Clear() : End If '清除DGV1資料
                SQLQuery += " EXEC [dbo].[預_時段比對01v] "
                SQLQuery += " N'2A',N'" & 樓層 & "',N'" & 時段1 & "',N'" & Format(日期.Value, "yyyy-MM-dd") & "',N'2' "
            Case "2"
                If DGV4.RowCount > 0 Then : 顯示資料.Tables("時段比對4").Clear() : End If '清除DGV3資料
                SQLQuery += " EXEC [dbo].[預_時段比對01v] "
                SQLQuery += " N'2A',N'" & 樓層 & "',N'" & 時段2 & "',N'" & Format(日期.Value, "yyyy-MM-dd") & "',N'2' "
        End Select
        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : Dim SQLCmd2 As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            Select Case Type
                Case "1"
                    DataAdapterDGV.Fill(顯示資料, "時段排程3") : DGV3.DataSource = 顯示資料.Tables("時段排程3") : DGV3.AutoResizeColumns()
                Case "2"
                    DataAdapterDGV.Fill(顯示資料, "時段比對4") : DGV4.DataSource = 顯示資料.Tables("時段比對4") : DGV4.AutoResizeColumns()
            End Select
            DGV3Display()
            DGV4Display()
        Catch ex As Exception
            MsgBox("時段比對查詢異常：" & ex.Message)
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
                Case "時段" : column.HeaderText = "時段" : column.DisplayIndex = 0 ': column.Visible = False
                Case "時段代碼" : column.HeaderText = "時段代碼" : column.DisplayIndex = 1 : column.Visible = False
                Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 2
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 3 : column.Visible = False
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 4 : column.Visible = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5
                Case "排程數量" : column.HeaderText = "排程" : column.DisplayIndex = 6
                Case "實際數量" : column.HeaderText = "實際" : column.DisplayIndex = 7
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 8 : column.Visible = False
                Case "件數量" : column.HeaderText = "件數量" : column.DisplayIndex = 9 : column.Visible = False
                Case "未入庫數量" : column.HeaderText = "未入庫數量" : column.DisplayIndex = 10 : column.Visible = False
                Case "差異排程數量" : column.HeaderText = "差異" : column.DisplayIndex = 11
                Case "最後時間" : column.HeaderText = "最後時間" : column.DisplayIndex = 12 : column.Visible = False
                Case "記錄時間" : column.HeaderText = "記錄時間" : column.DisplayIndex = 13 : column.Visible = False
                Case Else
                    column.Visible = False

            End Select
        Next

        DGV3.AutoResizeColumns()
        DGV3.AutoResizeRows()

    End Sub

    Private Sub DGV4Display()
        '--載入資料畫面
        For Each column As DataGridViewColumn In DGV4.Columns

            'DGV1.AllowUserToAddRows = False
            'DGV1.AllowUserToDeleteRows = False
            'column.ReadOnly = True  'DataGridView 設定單元格不可編輯
            column.Visible = True
            Select Case column.Name
                Case "時段" : column.HeaderText = "時段" : column.DisplayIndex = 0 : column.Visible = False
                Case "時段代碼" : column.HeaderText = "時段代碼" : column.DisplayIndex = 1 : column.Visible = False
                Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 2
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 3 : column.Visible = False
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 4 : column.Visible = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5
                Case "排程數量" : column.HeaderText = "排程" : column.DisplayIndex = 6
                Case "實際數量" : column.HeaderText = "實際" : column.DisplayIndex = 7
                Case "小單位" : column.HeaderText = "小單位" : column.DisplayIndex = 8 : column.Visible = False
                Case "件數量" : column.HeaderText = "件數量" : column.DisplayIndex = 9 : column.Visible = False
                Case "未入庫數量" : column.HeaderText = "未入庫數量" : column.DisplayIndex = 10 : column.Visible = False
                Case "差異排程數量" : column.HeaderText = "差異" : column.DisplayIndex = 11
                Case "最後時間" : column.HeaderText = "最後時間" : column.DisplayIndex = 12 : column.Visible = False
                Case "記錄時間" : column.HeaderText = "記錄時間" : column.DisplayIndex = 13 : column.Visible = False
                Case Else
                    column.Visible = False

            End Select
        Next

        DGV4.AutoResizeColumns()
        DGV4.AutoResizeRows()

    End Sub


End Class