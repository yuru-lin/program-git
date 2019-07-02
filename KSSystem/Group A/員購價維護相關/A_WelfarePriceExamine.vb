Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_WelfarePriceExamine

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub A_WelfarePriceExamine_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        GetDGV1Data()
        DGV1Display()
    End Sub

#Region "按鈕動作"

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)  '查詢

        '取得查詢資料
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        GetDGV1Data()

    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)  '新增
        A_WelfarePrice.Source = "ADD"
        A_WelfarePrice.MdiParent = MainForm
        A_WelfarePrice.Show()
        Me.Close()
    End Sub
#End Region

#Region "取得DataGridView資料"
    Private Sub GetDGV1Data()

        Dim strWhere As String = ""
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If


        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select ProCode AS '存貨編號', ProName AS '品名', Price AS '單價', "
            sql += " CASE [Type] WHEN '1' THEN '電宰品' WHEN '2' THEN '加工品' END AS '類型',  "
            sql += " CASE Examine WHEN '1' THEN '送審中' WHEN '2' THEN '已覆核' WHEN '3' THEN '退回' END AS '狀態',   "
            sql += " CASE U_P7 WHEN '0' THEN '庫存單位' WHEN '1' THEN 'KG' WHEN '2' THEN '小單位' WHEN '3' THEN '重整' END AS '計價單位' "
            sql += " ,Reason AS '退回原因'"
            sql += " From KS_A_WelfarePrice "
            sql += " Where Examine='1' "
            sql += " ORDER BY AddDate"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "存貨編號"
                    column.HeaderText = "存貨編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 110
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 180
                Case "單價"
                    column.HeaderText = " 單價"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.DefaultCellStyle.Format = "#0.0000"
                    column.Width = 60
                Case "退回原因"
                    column.HeaderText = "退回原因"
                    column.DisplayIndex = 3
                    column.Width = 250
                Case "類型"
                    column.HeaderText = "類型"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "計價單位"
                    column.HeaderText = "計價單位"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next


        '=============================================================自動產生DGV控制項 BEGIN======================================================================
        Dim 核可 As New DataGridViewButtonColumn()
        核可.Name = "核可"
        核可.HeaderText = ""
        核可.DisplayIndex = 0
        核可.Width = 70
        核可.Text = "核可"
        核可.UseColumnTextForButtonValue = True
        DGV1.Columns.Add(核可)

        Dim 不核可 As New DataGridViewButtonColumn()
        不核可.Name = "不核可"
        不核可.HeaderText = ""
        不核可.DisplayIndex = 1
        不核可.Width = 70
        不核可.Text = "不核可"
        不核可.UseColumnTextForButtonValue = True
        DGV1.Columns.Add(不核可)

        '=================自動產生DGV控制項 END=======================================================================
    End Sub
#End Region

    Private Sub DGV1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick
        If e.RowIndex <> -1 Then
            If DGV1.Columns(e.ColumnIndex).Name = "核可" Then

                Dim sql As String = ""
                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand
                Dim tran As SqlTransaction = DBConn.BeginTransaction()

                Try
                    sql += "   UPDATE KS_A_WelfarePrice  "
                    sql += "   SET Examine='2', Reason='', ExamineDate=GETDATE(), ExamineUser='" + Login.LogonUserName + "' "
                    sql += "   WHERE ProCode='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("存貨編號").Value) + "' AND Examine='1' "



                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()



                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    MsgBox("覆核失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                    Exit Sub
                End Try

                '重新取得資料
                GetDGV1Data()
            End If

            If DGV1.Columns(e.ColumnIndex).Name = "不核可" Then

                If Convert.ToString(DGV1.Rows(e.RowIndex).Cells("退回原因").Value) = "" Then
                    MsgBox("請輸入存編『" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("存貨編號").Value) + "』之退回原因", 16, "錯誤")
                    Exit Sub
                End If

                Dim sql As String = ""
                Dim DBConn As SqlConnection = Login.DBConn
                Dim SQLCmd As SqlCommand = New SqlCommand
                Dim tran As SqlTransaction = DBConn.BeginTransaction()

                Try
                    sql += "   UPDATE KS_A_WelfarePrice    "
                    sql += "   SET Examine='3', Reason='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("退回原因").Value) + "', ExamineDate=GETDATE(), ExamineUser='" + Login.LogonUserName + "' "
                    sql += "   WHERE ProCode='" + Convert.ToString(DGV1.Rows(e.RowIndex).Cells("存貨編號").Value) + "' AND Examine='1' "



                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()



                    tran.Commit()
                Catch ex As Exception
                    tran.Rollback()
                    MsgBox("覆核失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                    Exit Sub
                End Try

                '重新取得資料
                GetDGV1Data()
            End If
        End If
    End Sub
End Class