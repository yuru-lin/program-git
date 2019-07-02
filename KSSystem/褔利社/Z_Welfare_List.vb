Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class Z_Welfare_List

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim strSaleGroupType As String = String.Empty

    Private Sub Z_Welfare_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '初次控制項管理
        初始化()

        '預設預查未處理件
        ddlState.SelectedIndex = 1

        GetDGV1Data()
    End Sub


#Region "按鈕動作"

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click '查詢

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick '點選GV
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        laDate.Text = DGV1.CurrentRow.Cells("日期").Value
        laState.Text = DGV1.CurrentRow.Cells("狀態").Value
        laCardName.Text = DGV1.CurrentRow.Cells("客戶名稱").Value
        strSaleGroupType = DGV1.CurrentRow.Cells("群組編號").Value

        If (Login.LogonUserName = "manager" Or Login.LogonUserName = "09441801") Then
            If laState.Text <> "未覆核" Then
                btnUpdate.Enabled = False
                btnDel.Enabled = False
            Else
                btnUpdate.Enabled = True
                btnDel.Enabled = True
            End If
        End If

        btnPrint.Enabled = True
        GetDGV2Data()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If laDate.Text = "" Or laState.Text <> "未覆核" Then
            MsgBox("失敗：請選擇欲補印之日期或狀態為『未覆核』!!", 16, "錯誤")
            Exit Sub
        End If

        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn




        Dim sql As String = String.Empty
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            '===========================================修改資料庫作業Begin===============================================

            '修改主Table
            sql = " UPDATE [KS_Z_Welfare] SET [State]= '2'  WHERE Convert(Varchar(10), AddDate, 111) = '" + laDate.Text + "'  AND State = '" + Convert.ToString(ddlState.SelectedIndex) + "' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()



            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("核准失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            btnUpdate.Enabled = False
            Exit Sub
        End Try

        MsgBox("已核准!!", 64, "完成")
        初始化()
        '重新取得查詢資料
        GetDGV1Data()
        ks1DataSetDGV.Tables("DT2").Clear()



        '===========================================修改資料庫作業END===============================================

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

        '組Where條件
        '狀態
        If ddlState.SelectedIndex <> 0 Then
            strWhere += " AND (Z.State='" + Convert.ToString(ddlState.SelectedIndex) + "') "
        End If

        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select Convert(varchar,Z.[AddDate],111) AS '日期', Count(ProCode) AS '筆數',  "
            sql += " CASE Z.[State] When '1' Then '未覆核' When '2' Then '已覆核' When '3' Then '已回傳B1' When '4' Then '出庫完成' END AS '狀態', "
            sql += " S.[CardName] AS '客戶名稱', "
            sql += " S.[CardCode] AS '客戶編號', "
            sql += " Z.[SaleGroupType] AS '群組編號' "
            sql += " From KS_Z_Welfare  Z "
            sql += " Left Join  KS_Z_SaleGroupType S ON Z.SaleGroupType=S.ID AND S.[State]='1' "
            'sql += " Where Z.State<>'9' AND convert(varchar(10),Z.AddDate,112)<>convert(varchar(10),getdate(),112) "
            sql += " Where Z.State<>'9' "

            sql += strWhere
            sql += " Group By Convert(varchar,Z.[AddDate],111),Z.[State], S.[CardCode], S.[CardName], Z.[SaleGroupType] "
            sql += " ORDER BY 日期 DESC "

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
                Case "日期"
                    column.HeaderText = "日期"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "筆數"
                    column.HeaderText = "筆數"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "狀態"
                    column.HeaderText = " 狀態"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "客戶名稱"
                    column.HeaderText = " 客戶名稱"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "客戶編號"
                    column.HeaderText = " 客戶編號"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "群組編號"
                    column.HeaderText = " 群組編號"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

       
    End Sub

    Private Sub GetDGV2Data()

        Dim strWhere As String = ""
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = "    SELECT ProCode AS '存編', ProName AS '品名', Barcode AS '條碼', Num AS '數量', Weight AS '重量', EmpName AS '員工姓名', EmpID AS '員工編號', KeepName AS '溫層' "
            sql += "     FROM KS_Z_Welfare  "
            sql += "    WHERE convert(varchar(10),AddDate,111)='" & laDate.Text & "' AND SaleGroupType='" + strSaleGroupType + "' AND State='" + Convert.ToString(ddlState.SelectedIndex) + "'"
            sql += " ORDER BY 員工編號 DESC, AddDate DESC, 存編 DESC "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")

            DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
            TransactionMonitor.Complete()
        End Using
        DGV2Display()
    End Sub

    Private Sub DGV2Display()

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 110
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 180
                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.Width = 40
                Case "員工編號"
                    column.HeaderText = "員工編號"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 80
                Case "員工姓名"
                    column.HeaderText = "員工姓名"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 80
                Case "條碼"
                    column.HeaderText = " 條碼"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Width = 110
                Case "重量"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "溫層"
                    column.HeaderText = "溫層"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub
#End Region

    Private Sub 初始化()
        laDate.Text = ""
        laState.Text = ""
        laCardName.Text = ""
        '覆核人員先限制manager和09441801
        If (Login.LogonUserName = "manager" Or Login.LogonUserName = "09441801") Then
            btnUpdate.Visible = True
            btnDel.Visible = True
            btnUpdate.Enabled = False
            btnDel.Enabled = False
        Else
            btnUpdate.Visible = False
            btnDel.Visible = False
        End If

        btnPrint.Enabled = False

    End Sub

    Private Sub PrintReport()
        Z_ReportViewer.MdiParent = MainForm
        Z_ReportViewer.Source = "Welfare"
        Z_ReportViewer.strPara(0) = laDate.Text
        Z_ReportViewer.strPara(1) = laCardName.Text

        Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT2")
        Z_ReportViewer.Show()

    End Sub



    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If laDate.Text = "" Or laState.Text = ""  Then
            MsgBox("補印失敗：請選擇欲補印之日期!!", 16, "錯誤")
            Exit Sub
        End If

        PrintReport()

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
            sql = " UPDATE [KS_Z_Welfare] SET [State]= '9'  WHERE Convert(Varchar(10), AddDate, 111)='" + laDate.Text + "'  AND State='" + Convert.ToString(ddlState.SelectedIndex) + "'"
              



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
        ks1DataSetDGV.Tables("DT2").Clear()
    End Sub
End Class