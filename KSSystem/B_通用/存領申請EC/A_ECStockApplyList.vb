Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_ECStockApplyList

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim strAtttibuteType As String = String.Empty
    Dim strOrderType As String = String.Empty

    Private Sub A_ECStockApplyList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '初次控制項管理
        初始化()
        ExecSP() '轉入EC正式機訂單資料
        GetDGV1Data()
    End Sub


#Region "按鈕動作"

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)  '查詢

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick '點選GV
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        laID.Text = DGV1.CurrentRow.Cells("訂單編號").Value
        strOrderType = DGV1.CurrentRow.Cells("訂單類型代碼").Value


        btnApply.Enabled = True
        btnDel.Enabled = True

    End Sub

#End Region

#Region "取得DataGridView資料"
    Private Sub ExecSP()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        Dim Sql As String = ""

        Try
            Sql = " EXEC [KaiShingEc].dbo.[Trans_KS_Z_ECOrder&KS_Z_ECOrderDetail] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = Sql
            SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("EC正式機訂單資料轉入失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
    End Sub

    Private Sub GetDGV1Data()

        Dim strWhere As String = ""
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Using TransactionMonitor As New System.Transactions.TransactionScope



            sql = " Select E.ID AS '訂單編號', Count(ED.ID) AS '筆數',  "
            sql += " '品牌人股份有限公司' AS '客戶名稱', "
            sql += " 'A401271000' AS '客戶編號', "
            sql += " E.SourceName AS '來源', "
            sql += " CASE E.OrderType When '4' Then '展覽領用' When '5' Then '試吃領用' When '6' Then '送樣出貨' END AS '訂單類型', "
            sql += " E.OrderType AS '訂單類型代碼' "
            sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
            sql += " INNER JOIN  [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
            sql += " INNER JOIN OITM T0 ON ED.ProtModel=T0.ItemCode "
            sql += " Where E.OrderType IN('4','5','6') AND ED.State<>'2' "
            If Login.DBServer = "192.168.0.34" Then
                sql += " AND E.HTTP<>'smc.gugugoo.com' "
            End If
            sql += " Group By E.ID, E.SourceName, E.OrderType, E.AddDate "
            sql += " ORDER BY E.AddDate DESC "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV1Display()
    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "訂單編號"
                    column.HeaderText = "訂單編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 80
                Case "筆數"
                    column.HeaderText = "筆數"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 55
                Case "訂單類型"
                    column.HeaderText = " 訂單類型"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.Width = 110
                Case "客戶名稱"
                    column.HeaderText = " 客戶名稱"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 120
                Case "客戶編號"
                    column.HeaderText = " 客戶編號"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                    column.Width = 85
                Case "來源"
                    column.HeaderText = " 來源"
                    column.DisplayIndex = 5
                    column.Visible = True
                    column.Width = 130
                Case "訂單類型代碼"
                    column.HeaderText = " 訂單類型代碼"
                    column.DisplayIndex = 6
                    column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        'DGV1.AutoResizeColumns()


    End Sub
#End Region

    Private Sub 初始化()
        laID.Text = ""

        btnApply.Enabled = False
        btnDel.Enabled = False
    End Sub
    
    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If laID.Text = "" Then
            MsgBox("請選擇欲申請之訂單編號!!", 16, "錯誤")
            Exit Sub
        End If

        Z_StockApply.Source = "EC"
        Z_StockApply.ID = laID.Text
        Z_StockApply.OrderType = strOrderType
        Z_StockApply.MdiParent = MainForm
        Z_StockApply.Show()
        Me.Close()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim sql As String = String.Empty
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            '===========================================修改資料庫作業Begin===============================================

            '修改主Table

            sql = " UPDATE [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] SET [State]= '9', AlterDate=getdate(), AlterUser='" + Login.LogonUserName + "'  WHERE ID ='" + laID.Text + "' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()



            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '===========================================修改資料庫作業END===============================================

        MsgBox("刪除成功!!", 16, "錯誤")
        初始化()
        '重新取得查詢資料
        GetDGV1Data()
    End Sub
End Class