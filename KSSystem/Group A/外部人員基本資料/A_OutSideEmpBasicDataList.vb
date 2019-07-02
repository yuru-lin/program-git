Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_OutSideEmpBasicDataList

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub A_OutSideEmpBasicDataList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        ddlSaleGroupType.SelectedIndex = 0
        ddlstatus.SelectedIndex = 2

        laEmpID.Text = ""
        laName.Text = ""

        GetDGV1Data()
        DGV1Display()
    End Sub

#Region "按鈕動作"

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click '查詢

        '取得查詢資料
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        GetDGV1Data()

    End Sub

    Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click '新增
        A_OutSideEmpBasicData.Source = "ADD"
        A_OutSideEmpBasicData.MdiParent = MainForm
        A_OutSideEmpBasicData.Show()
        Me.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If laEmpID.Text = "" Then
            MsgBox("請選擇要修改的人員!", 64, "錯誤")
            Exit Sub
        End If
        A_OutSideEmpBasicData.Source = "EDIT"
        A_OutSideEmpBasicData.ID = laEmpID.Text
        A_OutSideEmpBasicData.MdiParent = MainForm
        A_OutSideEmpBasicData.Show()
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

        '組Where條件
        '姓名(關鍵字)
        If txtName.Text <> "" Then
            strWhere += " AND (O.[lastName] like '%" + txtName.Text + "%') "
        End If

        '類型
        If ddlSaleGroupType.SelectedIndex <> 0 Then
            strWhere += " AND (O.[SaleGroupType]='" + Convert.ToString(ddlSaleGroupType.SelectedIndex) + "') "
        End If

        '狀態
        If ddlstatus.SelectedIndex <> 0 Then
            strWhere += " AND (O.[status]='" + Convert.ToString(ddlstatus.SelectedIndex - 1) + "') "
        End If

        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select empID AS '員編', lastName AS '姓名', Convert(varchar,birthDate,111) AS '生日',  "
            sql += " CASE [sex] WHEN '0' THEN '女' WHEN '1' THEN '男' END AS '性別',   "
            sql += " CASE [status] WHEN '0' THEN '已離職' WHEN '1' THEN '任職中' END AS '狀態',    "
            sql += " S.[CardName] AS '類型', [mobile] AS '聯絡電話(手機)', [homeTel] AS '聯絡電話(市話)', [homeZip]+[homeAddress] AS '居住地址', "
            sql += " [email] AS '電子信箱', Convert(varchar,startDate,111) AS '任職日期', Convert(varchar,termDate,111) AS '離職日期', "
            sql += " remark AS '備註' "
            sql += " From KS_A_OHEM_O O "
            sql += " LEFT JOIN KS_Z_SaleGroupType S ON  O.SaleGroupType=S.ID "
            sql += " Where [status]<>'9' "
            sql += strWhere
            sql += " ORDER BY 員編 DESC, 姓名 DESC "

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
                Case "員編"
                    column.HeaderText = "員編"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 80
                Case "姓名"
                    column.HeaderText = "姓名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 80
                Case "生日"
                    column.HeaderText = " 生日"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.Width = 80
                Case "性別"
                    column.HeaderText = "性別"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 60
                Case "狀態"
                    column.HeaderText = "狀態"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                    column.Width = 60
                Case "類型"
                    column.HeaderText = "類型"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Width = 60
                Case "聯絡電話(手機)"
                    column.HeaderText = "聯絡電話(手機)"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                    column.Width = 110
                Case "聯絡電話(市話)"
                    column.HeaderText = "聯絡電話(手機)"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                    column.Width = 110
                Case "居住地址"
                    column.HeaderText = "居住地址"
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                    column.Width = 200
                Case "電子信箱"
                    column.HeaderText = "電子信箱"
                    column.DisplayIndex = 9
                    column.ReadOnly = True
                    column.Width = 100
                Case "任職日期"
                    column.HeaderText = "任職日期"
                    column.DisplayIndex = 10
                    column.ReadOnly = True
                    column.Width = 80
                Case "離職日期"
                    column.HeaderText = "離職日期"
                    column.DisplayIndex = 11
                    column.ReadOnly = True
                    column.Width = 80
                Case "備註"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 12
                    column.ReadOnly = True
                    column.Width = 100
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub
#End Region

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        laEmpID.Text = DGV1.CurrentRow.Cells("員編").Value
        laName.Text = DGV1.CurrentRow.Cells("姓名").Value
    End Sub

    
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click

        '確認資料可刪除
        If laEmpID.Text = "" Then
            MsgBox("刪除失敗：請選擇欲刪除之人員!!", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            
            sql += "   UPDATE [KS_A_OHEM_O] SET [status]='9' "
            sql += "   WHERE EmpID='" + laEmpID.Text + "' "

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

        MsgBox("刪除成功!", 64, "成功")

        '重新取得資料
        GetDGV1Data()

        laEmpID.Text = ""
        laName.Text = ""
    End Sub
End Class