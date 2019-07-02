Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_EC_List

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Dim strAtttibuteType As String = String.Empty
    Dim strAtttibuteName As String = String.Empty
    Dim strOrderSource As String = String.Empty
    Dim strOrderName As String = String.Empty
    Dim strOrderType As String = String.Empty

    Private Sub A_EC_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        laID.Text = DGV1.CurrentRow.Cells("訂單日期").Value
        laSource.Text = DGV1.CurrentRow.Cells("來源").Value

        strAtttibuteName = DGV1.CurrentRow.Cells("商品屬性").Value
        strAtttibuteType = DGV1.CurrentRow.Cells("商品屬性代碼").Value
        strOrderName = DGV1.CurrentRow.Cells("訂單類型").Value
        strOrderType = DGV1.CurrentRow.Cells("訂單類型代碼").Value


        btnPackPrint.Enabled = True
        btnDetailPrint.Enabled = True

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

        Using TransactionMonitor As New System.Transactions.TransactionScope



            sql += " Select Convert(varchar,AddDate,111) AS '訂單日期', Count(ED.ID) AS '筆數',  "
            sql += " CASE ED.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END  "
            sql += " + CASE E.OrderType When '1' Then '(常態)' When '2' Then '(活動)' When '3' Then '(缺料)' END AS '訂單類型',"
            sql += " '品牌人股份有限公司' AS '客戶名稱', "
            sql += " 'A401271000' AS '客戶編號', "
            sql += " E.SourceName AS '來源', "
            sql += " CASE E.OrderType When '1' Then '常態' When '2' Then '活動' When '3' Then '缺料' END AS '訂單類型', "
            sql += " E.OrderType AS '訂單類型代碼', "
            sql += " CASE ED.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END AS '商品屬性', "
            sql += " ED.AtttibuteType  AS '商品屬性代碼', "
            sql += " CASE ED.State When '1' Then '已回傳B1' When '2' Then '已出貨' END AS '狀態' "
            sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
            sql += " INNER JOIN  [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
            sql += " Where 1=1 AND E.OrderType NOT IN('4','5','6') "
            sql += strWhere
            sql += " Group By ED.AtttibuteType, E.OrderType, Convert(varchar,AddDate,111), E.SourceName, ED.State  "
            sql += " ORDER BY 1 DESC "

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
                Case "訂單日期"
                    column.HeaderText = "訂單日期"
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
                Case "狀態"
                    column.HeaderText = " 狀態"
                    column.DisplayIndex = 6
                    column.Visible = True
                    column.Width = 60
                Case "商品屬性"
                    column.HeaderText = " 商品屬性"
                    column.DisplayIndex = 7
                    column.Visible = False
                Case "商品屬性代碼"
                    column.HeaderText = " 商品屬性代碼"
                    column.DisplayIndex = 8
                    column.Visible = False
                Case "訂單類型代碼"
                    column.HeaderText = " 訂單類型代碼"
                    column.DisplayIndex = 9
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
        laSource.Text = ""


        strAtttibuteType = ""
        strOrderSource = ""
        strOrderName = ""
        strOrderType = ""
        btnPackPrint.Enabled = False
        btnDetailPrint.Enabled = False


    End Sub

    Private Sub btnSerch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click
        '取得查詢資料
        GetDGV1Data()
        初始化()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim sql As String = String.Empty
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            '===========================================修改資料庫作業Begin===============================================

            '修改主Table
           
            sql = " UPDATE [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] SET [State]= '9', AlterDate=getdate(), AlterUser='" + Login.LogonUserName + "'  WHERE Convert(Varchar, AddDate, 111) ='" + laID.Text + "' AND State='0' AND AtttibuteType='" + strAtttibuteType + "' "


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

    Private Sub btnPackPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPackPrint.Click
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'SQLCmd.Connection = DBConn
        Dim Sql As String = String.Empty
        Dim oDT As DataTable = New DataTable
        Dim oDT1 As DataTable = New DataTable

        '===========================取得最新流水號 Begin=======================================
        Sql = " SELECT Distinct E.ID "
        Sql += " FROM [KaiShingEc].[dbo].[KS_Z_ECOrder] E INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] EC ON E.ID=EC.ID  "
        Sql += " WHERE Convert(varchar,AddDate,111)='" + laID.Text + "'  AND EC.AtttibuteType='" + strAtttibuteType + "' AND E.OrderType='" + strOrderType + "'"
        Sql += " ORDER BY 1 DESC  "

        'SQLCmd.CommandText = Sql

        DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
        DataAdapterDGV.Fill(oDT)


        If oDT.Rows.Count > 0 Then

            For i As Integer = 0 To oDT.Rows.Count - 1



                Sql = " SELECT T0.[ID], T1.[ItemCode] AS 'ItemCode', T1.[ItemName] AS 'Dscription' "
                Sql += "    , CASE T0.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END AS 'AtttibuteType' "
                Sql += "    , CASE E.OrderType When '1' Then '常態' When '2' Then '活動' When '3' Then '缺料' END AS 'OrderType' "
                Sql += "    , Sum(T0.[Count]) AS '本次數量' "
                Sql += " FROM [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] T0 INNER JOIN [OITM] T1 ON T0.[ProtModel] = T1.[ItemCode]  "
                Sql += " INNER JOIN  [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON T0.ID=E.ID "
                Sql += " WHERE T0.ID='" + oDT.Rows(i)("ID") + "'  AND T0.AtttibuteType='" + strAtttibuteType + "' AND E.OrderType='" + strOrderType + "'"
                Sql += " Group By T0.[ID], T1.[ItemCode], T1.[ItemName], T0.AtttibuteType,E.OrderType "
                Sql += " ORDER BY 1 DESC  "

                'SQLCmd.CommandText = Sql

                DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
                DataAdapterDGV.Fill(oDT1)

                Dim NewMDIChild As New A_ReportViewer
                NewMDIChild.MdiParent = MainForm
                NewMDIChild.Source = "EC"


                NewMDIChild.strPara(0) = oDT.Rows(i)("ID")
                NewMDIChild.strPara(1) = ""
                NewMDIChild.strPara(2) = strAtttibuteName


                NewMDIChild.dt = oDT1
                NewMDIChild.Show()
                oDT1.Clear()
            Next
        Else
            MsgBox("無訂單資料!!", 16, "錯誤")
        End If
    End Sub

    Private Sub btnDetailPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetailPrint.Click
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        Dim Sql As String = String.Empty
        Dim oDT As DataTable = New DataTable
        Dim oDT1 As DataTable = New DataTable

        '===========================取得最新流水號 Begin=======================================
        Sql = " SELECT Distinct E.ID "
        Sql += " FROM [KaiShingEc].[dbo].[KS_Z_ECOrder] E INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] EC ON E.ID=EC.ID  "
        Sql += " WHERE Convert(varchar,AddDate,111)='" + laID.Text + "'  AND EC.AtttibuteType='" + strAtttibuteType + "' AND E.OrderType='" + strOrderType + "'"
        Sql += " ORDER BY 1 DESC  "

        SQLCmd.CommandText = Sql

        DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
        DataAdapterDGV.Fill(oDT)


        If oDT.Rows.Count > 0 Then

            For i As Integer = 0 To oDT.Rows.Count - 1



                Sql = " Select ED.ID AS '訂單編號', ProtModel AS '商品型號', ProName AS '通路商品名稱', Count AS '數量',MEMO AS '訂單備註', "
                Sql += " SourceName AS '來源', PayClass AS '付款方式', OrderName AS '訂購人姓名', OrderTel AS '訂購人聯絡電話', "
                Sql += " GetName AS '送貨取件姓名', GetTel AS '送貨聯絡電話', GetAddress AS '送貨地址', "
                Sql += " AddDate AS '訂購時間' "
                Sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
                Sql += " INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
                Sql += " Where ED.ID='" + oDT.Rows(i)("ID") + "' AND ED.AtttibuteType='" + strAtttibuteType + "'AND E.OrderType='" + strOrderType + "'"
                Sql += " ORDER BY ProtModel DESC "

                SQLCmd.CommandText = Sql

                DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
                DataAdapterDGV.Fill(oDT1)

                Dim NewMDIChild As New A_ReportViewer
                NewMDIChild.MdiParent = MainForm
                NewMDIChild.Source = "EC_Order"


                NewMDIChild.strPara(0) = oDT.Rows(i)("ID")
                NewMDIChild.strPara(1) = oDT1.Rows(0)("訂單備註")
                NewMDIChild.strPara(2) = Convert.ToString(oDT1.Rows(0)("送貨取件姓名")).Substring(0, 1) + " * * "
                NewMDIChild.strPara(3) = strAtttibuteName
                NewMDIChild.strPara(4) = laSource.Text

                NewMDIChild.dt = oDT1
                NewMDIChild.Show()
                oDT1.Clear()
            Next
        Else
            MsgBox("無訂單資料!!", 16, "錯誤")
        End If

    End Sub

    Private Sub btnDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        Dim Sql As String = String.Empty
        Dim oDT As DataTable = New DataTable
        Dim oDT1 As DataTable = New DataTable

        '===========================取得最新流水號 Begin=======================================
        Sql = " SELECT Distinct E.ID "
        Sql += " FROM [KaiShingEc].[dbo].[KS_Z_ECOrder] E INNER JOIN KS_Z_ECOrderDetail EC ON E.ID=EC.ID  "
        Sql += " WHERE Convert(varchar,AddDate,111)='" + laID.Text + "'  AND EC.AtttibuteType='" + strAtttibuteType + "' AND E.OrderType='" + strOrderType + "'"
        Sql += " ORDER BY 1 DESC  "

        SQLCmd.CommandText = Sql

        DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
        DataAdapterDGV.Fill(oDT)


        If oDT.Rows.Count > 0 Then

            For i As Integer = 0 To oDT.Rows.Count - 1

                Sql = " Select ED.ID AS '訂單編號',MEMO AS '訂單備註', "
                Sql += " GetName AS '送貨取件姓名', GetTel AS '送貨聯絡電話', GetAddress AS '送貨地址', "
                Sql += " AddDate AS '訂購時間', E.PayClass AS '付款方式', E.Total AS '應收金額' "
                Sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
                Sql += " INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
                Sql += " Where ED.ID='" + oDT.Rows(i)("ID") + "' AND ED.AtttibuteType='" + strAtttibuteType + "'AND E.OrderType='" + strOrderType + "'"

                SQLCmd.CommandText = Sql

                DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
                DataAdapterDGV.Fill(oDT1)

                Dim NewMDIChild As New A_ReportViewer
                NewMDIChild.MdiParent = MainForm
                NewMDIChild.Source = "EC_Delivery"

                NewMDIChild.strPara(0) = oDT1.Rows(0)("送貨取件姓名")
                NewMDIChild.strPara(1) = oDT1.Rows(0)("送貨聯絡電話")
                NewMDIChild.strPara(2) = oDT1.Rows(0)("送貨地址")
                NewMDIChild.strPara(3) = oDT1.Rows(0)("訂單備註")

                If oDT1.Rows(0)("付款方式") = "貨到付款" Then
                    NewMDIChild.strPara(4) = oDT1.Rows(0)("應收金額")
                Else
                    NewMDIChild.strPara(4) = ""
                End If

                oDT1.Clear()
                NewMDIChild.Show()

            Next
        Else
            MsgBox("無訂單資料!!", 16, "錯誤")
        End If


    End Sub
End Class