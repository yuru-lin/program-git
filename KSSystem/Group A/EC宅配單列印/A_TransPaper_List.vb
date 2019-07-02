Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Text
Imports System.Drawing

Public Class A_TransPaper_List

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim strAtttibuteType As String = String.Empty
    Dim strAtttibuteName As String = String.Empty
    Dim strOrderSource As String = String.Empty
    Dim strOrderName As String = String.Empty
    Dim strOrderType As String = String.Empty
    Dim strMEMO As String = String.Empty
    Dim strTotal As String = String.Empty
    Dim strPayClas As String = String.Empty
    Dim strGetName As String = String.Empty
    Dim strGetTel As String = String.Empty
    Dim strGetAddresss As String = String.Empty
    Dim strNewTransNo As String = String.Empty
    Dim strTransNo As String = String.Empty
    Private Sub A_TransPaper_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '初次控制項管理
        初始化()
        ddlSource.SelectedIndex = 0
        ddlState.SelectedIndex = 1
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
        laSource.Text = DGV1.CurrentRow.Cells("來源").Value

        strGetName = DGV1.CurrentRow.Cells("收件人姓名").Value
        strGetTel = DGV1.CurrentRow.Cells("收件人聯絡電話").Value
        strGetAddresss = DGV1.CurrentRow.Cells("收件人地址").Value
        strTransNo = DGV1.CurrentRow.Cells("宅配單號").Value

        strMEMO = DGV1.CurrentRow.Cells("訂單備註").Value
        strTotal = DGV1.CurrentRow.Cells("應收金額").Value
        strPayClas = DGV1.CurrentRow.Cells("付款方式").Value


       
        btnDelivery.Enabled = True

        If strTransNo <> "" Then
            btnDel.Enabled = True
        End If

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
        '來源
        If ddlSource.SelectedIndex <> 0 Then
            Select Case ddlSource.SelectedIndex
                Case "1"
                    strWhere += " AND (E.SourceName='shop.gugugoo.com')"
                Case "2"
                    strWhere += " AND (E.SourceName='MOMO購物網')"
                Case "3"
                    strWhere += " AND (E.SourceName='PC-HOME線上購物')"
                Case "4"
                    strWhere += " AND (E.SourceName='YAHOO!購物中心')"
                Case "5"
                    strWhere += " AND (E.SourceName='活動預購單')"
                Case "6"
                    strWhere += " AND (E.SourceName='CHT優購網')"
                Case "7"
                    strWhere += " AND (E.SourceName='東森購物網')"
                Case "8"
                    strWhere += " AND (E.SourceName='其他未定義')"
                Case "9"
                    strWhere += " AND (E.SourceName='傳真訂購單')"
            End Select
        End If

        '狀態
        If ddlState.SelectedIndex <> 0 Then
            Select Case ddlState.SelectedIndex
                Case "1"
                    strWhere += " AND (ED.State='1')"
                Case "2"
                    strWhere += " AND (ED.State='2')"
            End Select
        Else
            strWhere += " AND (ED.State in ('1','2'))"
        End If

        '訂單編號(關鍵字)
        If txtOrderID.Text <> "" Then
           
            strWhere += " AND (ED.ID Like '%" + txtOrderID.Text + "%')"
            
        End If


        Using TransactionMonitor As New System.Transactions.TransactionScope



            sql += " Select E.ID AS '訂單編號', Count(ED.ID) AS '筆數',  "
            'sql += " CASE ED.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END  "
            'sql += " + CASE E.OrderType When '1' Then '(常態)' When '2' Then '(活動)' When '3' Then '(缺料)' END AS '訂單類型',"
            sql += " E.GetName AS '收件人姓名', "
            sql += " E.GetTel AS '收件人聯絡電話', "
            sql += " E.GetAddress AS '收件人地址', "
            sql += " E.SourceName AS '來源', "
            'sql += " CASE E.OrderType When '1' Then '常態' When '2' Then '活動' When '3' Then '缺料' END AS '訂單類型', "
            'sql += " E.OrderType AS '訂單類型代碼', "
            'sql += " CASE ED.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END AS '商品屬性', "
            'sql += " ED.AtttibuteType  AS '商品屬性代碼', "
            sql += " CASE ED.State When '1' Then '已回傳B1' When '2' Then '已出貨' END AS '狀態', "
            sql += " E.AddDate, MEMO AS '訂單備註',  E.Total AS '應收金額', E.PayClass AS '付款方式',   "
            sql += " ISNULL(ET.TransNo,'') AS '宅配單號' "
            sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
            sql += " INNER JOIN  [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
            sql += " LEFT JOIN  KS_A_ECTransRecord ET ON ET.OrderID=ED.ID AND  ET.[State]<>'9' "
            sql += " Where 1=1 AND E.OrderType NOT IN('4','5','6') "
            sql += strWhere
            sql += " Group By E.ID, E.SourceName, ED.State, E.GetName, E.GetTel, E.GetAddress, E.AddDate, MEMO, E.Total, E.PayClass, ET.TransNo "
            sql += " ORDER BY E.AddDate DESC  "

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
                    column.Width = 90
                Case "筆數"
                    column.HeaderText = "筆數"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 55
                Case "訂單類型"
                    column.HeaderText = "訂單類型"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.Width = 110
                Case "收件人姓名"
                    column.HeaderText = "收件人姓名"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 100
                Case "收件人聯絡電話"
                    column.HeaderText = "收件人聯絡電話"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                    column.Width = 120
                Case "收件人地址"
                    column.HeaderText = "收件人地址"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Width = 180
                Case "來源"
                    column.HeaderText = "來源"
                    column.DisplayIndex = 6
                    column.Visible = True
                    column.Width = 130
                Case "狀態"
                    column.HeaderText = "狀態"
                    column.DisplayIndex = 7
                    column.Visible = True
                    column.Width = 60
                Case "宅配單號"
                    column.HeaderText = "宅配單號"
                    column.DisplayIndex = 8
                    column.Visible = True
                    column.Width = 90
                
                Case Else
                    column.Visible = False
            End Select
        Next
        'DGV1.AutoResizeColumns()


    End Sub
#End Region
#Region "Event"
    Private Sub 出貨()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim sql As String = String.Empty
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            '===========================================修改資料庫作業Begin===============================================

            sql = " UPDATE E SET E.[State]= '2', E.AlterDate=getdate(), E.AlterUser='" + Login.LogonUserName + "'  From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] E INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] EC ON E.ID=EC.ID WHERE E.ID ='" + laID.Text + "' AND E.State='1'"


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("狀態修改失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '===========================================修改資料庫作業END===============================================

        'MsgBox("狀態修改成功!!", 64, "完成")
        初始化()
        '重新取得查詢資料
        GetDGV1Data()
    End Sub

    Private Sub 取宅配單號()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim Sql As String = String.Empty
        Dim oDT As DataTable = New DataTable


        '===========================判斷該存領編號有無使用,取得最新流水號 Begin=======================================
        Sql = " SELECT TOP 1 TransNo "
        Sql += " FROM KS_A_ECTransRecord "
        Sql += " WHERE Type='" + Convert.ToString(ddlTransType.SelectedIndex + 1) + "'"
        Sql += " Order By AddDate Desc "

        SQLCmd.CommandText = Sql

        DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
        DataAdapterDGV.Fill(oDT)

        '取得最新宅配單號
        If oDT.Rows.Count > 0 Then
            strNewTransNo = oDT.Rows(0).Item("TransNo")
            取得最新宅配單號()
        Else
            strNewTransNo = ""
        End If
    End Sub

    Private Sub 取得最新宅配單號()
        strNewTransNo = strNewTransNo.Substring(0, 2) + strNewTransNo.Substring(3, 4) + strNewTransNo.Substring(8, 3)
        strNewTransNo = Microsoft.VisualBasic.Right("00000000" + Convert.ToString(Convert.ToInt32(strNewTransNo) + 1), 9)
        strNewTransNo = strNewTransNo.Substring(0, 2) + "-" + strNewTransNo.Substring(2, 4) + "-" + strNewTransNo.Substring(6, 3)
        txtTransNo.Text = strNewTransNo
    End Sub

    Private Sub 宅配記錄存檔()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim sql As String = String.Empty
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            '===========================================新增資料庫作業Begin===============================================

            sql = String.Format(" INSERT INTO [KS_A_ECTransRecord] ([OrderID],[TransNo] " & _
         ",[Type],[AddDate],[AddUser]) VALUES ('{0}','{1}','{2}',getdate(),'{3}') " _
         , laID.Text _
         , strNewTransNo _
         , ddlTransType.SelectedIndex + 1 _
         , Login.LogonUserName)


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '===========================================新增資料庫作業END===============================================
    End Sub
#End Region

#Region "按鈕事件"
    Private Sub btnSerch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click
        '取得查詢資料
        GetDGV1Data()
        初始化()
    End Sub

    Private Sub btnDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelivery.Click

        If txtTransNo.Text = "" Then
            MsgBox("請輸入印表機內最新宅配單號!", 16, "錯誤")
            txtTransNo.Focus()
            Exit Sub
        End If
        Try
            For i As Integer = 1 To ddlnum.SelectedIndex + 1
                'Dim NewMDIChild As New A_ReportViewer
                'NewMDIChild.MdiParent = MainForm
                'NewMDIChild.Source = "EC_Delivery"

                'NewMDIChild.strPara(0) = strGetName
                'NewMDIChild.strPara(1) = strGetTel
                'NewMDIChild.strPara(2) = strGetAddresss
                'NewMDIChild.strPara(3) = strMEMO

                'If strPayClas = "貨到付款" Then
                '    NewMDIChild.strPara(4) = strTotal
                'Else
                '    NewMDIChild.strPara(4) = ""
                'End If

                'NewMDIChild.Show()

                Dim AutoPrint As New AutoPrint
                Dim report As New LocalReport()
                '報表絕對路徑
                report.ReportPath = "C:\Users\M01\Desktop\外掛程式\外掛整合程式\凱馨外掛系統\KSSystem\Group A\報表\A_EC_Delivery_Report.rdlc"

                Dim paras(4) As Microsoft.Reporting.WinForms.ReportParameter
                paras(0) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_0", strGetName)
                paras(1) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_1", strGetTel)
                paras(2) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_2", strGetAddresss)
                paras(3) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_3", strMEMO)

                If strPayClas = "貨到付款" Then
                    paras(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", strTotal)
                Else
                    paras(4) = New Microsoft.Reporting.WinForms.ReportParameter("Report_Parameter_4", "")
                End If

                report.SetParameters(paras)

                AutoPrint.Export(report)
                AutoPrint.Print()

                strNewTransNo = txtTransNo.Text
                宅配記錄存檔()
                取得最新宅配單號()

            Next
            出貨()
        Catch ex As Exception
            MsgBox("錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
    End Sub


   
    Private Sub ddlTransType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTransType.SelectedIndexChanged
        取宅配單號()
    End Sub
#End Region

    Private Sub 初始化()
        laID.Text = ""
        laSource.Text = ""


        strAtttibuteType = ""
        strOrderSource = ""
        strOrderName = ""
        strOrderType = ""

        btnDelivery.Enabled = False
        btnDel.Enabled = False

        ddlTransType.SelectedIndex = 0
        ddlnum.SelectedIndex = 0

        取宅配單號()

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

            sql = " UPDATE [KS_A_ECTransRecord] SET [State]= '9', AddDate=getdate(), AddUser='" + Login.LogonUserName + "'  WHERE OrderID ='" + laID.Text + "' AND TransNo='" + strTransNo + "'"


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