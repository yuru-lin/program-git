Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class B_QueryFinishedORDR
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim QUAnow As Integer = 60
    Dim DrfRowCnt As Integer = 0

    Private Sub B_QueryFinishedORDR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGVFinished.ContextMenuStrip = MainForm.ContextMenuStrip1
        QueryFinished()
        PopupAlert()
        Timer1.Enabled = True
    End Sub

    Private Sub QueryFinished()

        If DGVFinished.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "exec L20111004 '3' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGVFinished.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        'DGV1Display()
        For Each column As DataGridViewColumn In DGVFinished.Columns
            column.Visible = True
            Select Case column.Name
                Case "1樓完成否"
                    column.DisplayIndex = 0
                Case "2樓完成否"
                    column.DisplayIndex = 1
                Case "訂單單號"
                    column.DisplayIndex = 2
                Case "交貨日期"
                    column.DisplayIndex = 3
                Case "客戶名稱"
                    column.DisplayIndex = 4
                Case "備註"
                    column.DisplayIndex = 5

                Case Else
                    column.Visible = False
            End Select
        Next
        DGVFinished.AutoResizeColumns()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If QUAnow >= 0 Then
            Label1.Text = "自動化更新時間還有：" & QUAnow & "秒"
            QUAnow = QUAnow - 1
        End If
        If QUAnow < 0 Then
            Label1.Text = "同步中..."
            QueryFinished()
            PopupAlert()
            QUAnow = 60
        End If

        'Timer1.Enabled = False
    End Sub

    Private Sub UpdateBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBtn.Click
        QueryFinished()
        PopupAlert()
    End Sub

    Private Sub PopupAlert()

        Dim NewCntDrf As Integer = 0

        Dim CText As String = "您有" + vbCrLf

        If DGVFinished.RowCount > DrfRowCnt Then
            NewCntDrf = DGVFinished.RowCount - DrfRowCnt
            'DrfRowCnt = DGV_oDraft.RowCount
        End If

      

        DrfRowCnt = DGVFinished.RowCount


        If NewCntDrf > 0 Then
            If NewCntDrf > 0 Then
                CText += CStr(NewCntDrf) + "筆 已完成訂單 " + vbCrLf
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
        Me.Focus()
        PopupNotifier1.hide()
    End Sub

    Private Sub PopupNotifier1_Close() ' Handles PopupNotifier1.Close
        PopupNotifier1.Hide()
    End Sub
End Class