Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class B_QueryOIGE
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim QUAnow As Integer = 120
    Dim DrfRowCnt As Integer = 0
    Dim RdrRowCnt As Integer = 0

    Private Sub B_QueryOIGE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_oDraft.ContextMenuStrip = MainForm.ContextMenuStrip1        
        DGVDetail.ContextMenuStrip = MainForm.ContextMenuStrip1

        QueryDrf()
        PopupAlert()
        Timer1.Enabled = True
    End Sub

    Private Sub QueryDrf()

        If DGV_oDraft.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "exec L20111020"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV_oDraft.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        'DGV1Display()

        For Each column As DataGridViewColumn In DGV_oDraft.Columns
            column.Visible = True
            Select Case column.Name
                Case "草稿單號"
                    column.DisplayIndex = 0
                Case "交貨日期"
                    column.DisplayIndex = 1
                Case "備註"
                    column.DisplayIndex = 2
                Case "狀態"
                    column.DisplayIndex = 3
                Case "文件時間"
                    column.DisplayIndex = 4
                Case "倉庫收單"
                    column.DisplayIndex = 5
                Case "倉庫完成"
                    column.DisplayIndex = 6
                Case "倉庫暫停"
                    column.DisplayIndex = 7
                Case "現場驗收"
                    column.DisplayIndex = 8                
                
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV_oDraft.AutoResizeColumns()

    End Sub

    Private Sub QueryDetail(ByVal QType As Integer)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope
            Select Case QType
                Case 1
                    sql = "exec L20111020_1 '" & DGV_oDraft.CurrentRow.Cells("草稿單號").Value & "' "
                    DetailLbl.Text = "草稿單號：" + CStr(DGV_oDraft.CurrentRow.Cells("草稿單號").Value)               
            End Select

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")

            DGVDetail.DataSource = ks1DataSetDGV.Tables("DT3")

            TransactionMonitor.Complete()
        End Using

        For Each column As DataGridViewColumn In DGVDetail.Columns
            column.Visible = True
            Select Case column.Name
                Case "單號"
                    column.DisplayIndex = 0
                    column.HeaderText = "單號"
                Case "存編"
                    column.DisplayIndex = 1
                Case "品名"
                    column.DisplayIndex = 2
                Case "數量"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.##"
                Case "單位"
                    column.DisplayIndex = 4

                Case Else
                    column.Visible = False
            End Select
        Next

        DGVDetail.AutoResizeColumns()
    End Sub

    Private Sub DGV_oDraft_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_oDraft.CellClick
        If DGV_oDraft.RowCount = 0 Then
            Exit Sub
        End If

        If DGVDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        QueryDetail(1)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If QUAnow >= 0 Then
            Label1.Text = "自動化更新時間還有：" & QUAnow & "秒"
            QUAnow = QUAnow - 1
        End If
        If QUAnow < 0 Then
            Label1.Text = "同步中..."
            QueryDrf()            
            PopupAlert()
            QUAnow = 120
        End If

        'Timer1.Enabled = False
    End Sub

    Private Sub UpdateBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBtn.Click
        QueryDrf()        
        PopupAlert()
    End Sub

    Private Sub PopupAlert()

        Dim NewCntDrf As Integer = 0
        Dim CText As String = "您有" + vbCrLf

        If DGV_oDraft.RowCount > DrfRowCnt Then
            NewCntDrf = DGV_oDraft.RowCount - DrfRowCnt
            'DrfRowCnt = DGV_oDraft.RowCount
        End If

        DrfRowCnt = DGV_oDraft.RowCount

        If NewCntDrf > 0 Then
            If NewCntDrf > 0 Then
                CText += CStr(NewCntDrf) + "筆 草稿單新資料 " + vbCrLf
            End If
            CText += "請迅速查看"

            PopupNotifier1.TitleText = "新資料提醒"
            PopupNotifier1.ContentText = CText
            PopupNotifier1.ShowDelay = 59000 '顯示時間1千=1秒
            PopupNotifier1.AnimationDelay = 10
            PopupNotifier1.Popup()

            AddHandler PopupNotifier1.Close, AddressOf PopupNotifier1_Close

            AddHandler PopupNotifier1.Click, AddressOf PopupNotifier1_Click
        Else
            Exit Sub
        End If

    End Sub

    Private Sub PopupNotifier1_Click() ' Handles PopupNotifier1.Click
        If MainForm.WindowState <> FormWindowState.Maximized Then
            MainForm.WindowState = FormWindowState.Maximized
        End If
        If Me.WindowState <> FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Normal
        End If
        If MainForm.Focused = False Then
            MainForm.Focus()
            Me.Focus()
        Else
            Me.Focus()
        End If
        PopupNotifier1.hide()
    End Sub

    Private Sub PopupNotifier1_Close() ' Handles PopupNotifier1.Close
        PopupNotifier1.Hide()
    End Sub

End Class