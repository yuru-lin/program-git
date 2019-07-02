Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class A_Welfare_List

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim strSaleGroupType As String = String.Empty
    Dim strAtttibuteType As String = String.Empty
    Dim strOrderSource As String = String.Empty
    Dim strOrderName As String = String.Empty
    Dim strOrderType As String = String.Empty

    Private Sub A_Welfare_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '初次控制項管理
        初始化()
        ddlSource.SelectedIndex = 0
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

        laID.Text = DGV1.CurrentRow.Cells("編號").Value
        laCardCode.Text = DGV1.CurrentRow.Cells("客戶編號").Value
        laCardName.Text = DGV1.CurrentRow.Cells("客戶名稱").Value
        laSource.Text = DGV1.CurrentRow.Cells("資料來源").Value

        If laSource.Text.Length > 4 Then
            If laSource.Text.Substring(0, 4) = "網路通路" Then
                laSource.Text = "網路通路"
            End If
        End If

        Select Case laSource.Text
            Case "網路通路"
                strAtttibuteType = DGV1.CurrentRow.Cells("商品屬性").Value
                strOrderSource = DGV1.CurrentRow.Cells("EC訂單來源").Value
                strOrderName = DGV1.CurrentRow.Cells("訂單類型").Value
                strOrderType = DGV1.CurrentRow.Cells("訂單類型代碼").Value
            Case "員購"
                strSaleGroupType = DGV1.CurrentRow.Cells("群組編號").Value
        End Select


        btnInsert.Enabled = True
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
            Sql = " EXEC [KaiShingEc].[dbo].[Trans_KS_Z_ECOrder&KS_Z_ECOrderDetail] "

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

        '組Where條件
        '狀態
        If ddlSource.SelectedIndex <> 0 Then
            Select Case ddlSource.SelectedIndex
                Case "1"
                    strWhere += " AND (資料來源='網路通路')"
                Case "2"
                    strWhere += " AND (資料來源='員購')"
            End Select
        End If

        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = " Select * from  "
            sql += " ((Select Convert(varchar,Z.[AddDate],111) AS '編號', Count(ProCode) AS '筆數',  "
            sql += " CASE Z.[State] When '1' Then '未覆核' When '2' Then '已覆核' When '3' Then '已回傳B1' When '4' Then '出庫完成' END AS '狀態','員購' AS '資料來源',  "
            sql += " S.[CardName] AS '客戶名稱',  "
            sql += " S.[CardCode] AS '客戶編號',  "
            sql += " Convert(varchar,Z.[AddDate],111) AS '日期',  "
            sql += " Z.[SaleGroupType] AS '群組編號', "
            sql += " '' AS 'EC訂單來源', "
            sql += " '' AS '訂單類型', "
            sql += " '' AS '訂單類型代碼', "
            sql += " '' AS '商品屬性' "
            sql += " From KS_Z_Welfare  Z  "
            sql += " Left Join  KS_Z_SaleGroupType S ON Z.SaleGroupType=S.ID AND S.[State]='1'  "
            sql += " Where Z.[State]='2'  "
            sql += " Group By Convert(varchar,Z.[AddDate],111),Z.[State], S.[CardCode], S.[CardName], Z.[SaleGroupType]  "
            sql += " )  "
            sql += " UNION  "
            sql += " (Select Convert(varchar,AddDate,111) AS '編號', Count(ED.ID) AS '筆數',  "
            sql += " CASE ED.AtttibuteType When '0' Then '生鮮品' When '1' Then '調理品' END  "
            'sql += " + CASE E.OrderType When '1' Then '(常態)' When '2' Then '(活動)' When '3' Then '(缺料)' END AS '狀態','網路通路('+ E.SourceName +')' AS '資料來源',"
            sql += "  + CASE E.OrderType When '1' Then '(常態)' When '2' Then '(活動)' When '3' Then '(缺料)' END AS '狀態','網路通路' AS '資料來源',"
            sql += " '品牌人股份有限公司' AS '客戶名稱', "
            sql += " 'A401271000' AS '客戶編號', "
            sql += " Convert(varchar,E.AddDate,111) AS '日期',   "
            sql += " '' AS '群組編號', "
            sql += " E.SourceName AS 'EC訂單來源', "
            sql += " CASE E.OrderType When '1' Then '常態' When '2' Then '活動' When '3' Then '缺料' END AS '訂單類型', "
            sql += " E.OrderType  AS '訂單類型代碼', "
            sql += " ED.AtttibuteType AS '商品屬性' "
            sql += " From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
            sql += " INNER JOIN  [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
            sql += " Where State = '0' AND convert(varchar(10),AddDate,112)<>convert(varchar(10),getdate(),112) AND E.OrderType NOT IN('4','5','6')  "
            If Login.DBServer = "192.168.0.34" Then
                sql += " AND E.HTTP <> 'smc.gugugoo.com' "
            End If
            sql += " Group By ED.AtttibuteType, E.OrderType, Convert(varchar,AddDate,111), E.SourceName ) "
            sql += " ) a WHERE 1=1 "
            sql += strWhere
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
                Case "編號"
                    column.HeaderText = "編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 80
                Case "筆數"
                    column.HeaderText = "筆數"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 55
                Case "狀態"
                    column.HeaderText = " 狀態/訂單類型"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.Width = 110
                Case "資料來源"
                    column.HeaderText = " 資料來源"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 130
                Case "客戶名稱"
                    column.HeaderText = " 客戶名稱"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                    column.Width = 120
                Case "客戶編號"
                    column.HeaderText = " 客戶編號"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Width = 85
                Case "日期"
                    column.HeaderText = " 日期"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                    column.Width = 75
                Case "群組編號"
                    column.HeaderText = " 群組編號"
                    column.DisplayIndex = 7
                    column.Visible = False
                Case "EC訂單來源"
                    column.HeaderText = " EC訂單來源"
                    column.DisplayIndex = 8
                    column.Visible = False
                Case "訂單類型"
                    column.HeaderText = " 訂單類型"
                    column.DisplayIndex = 9
                    column.Visible = False
                Case "訂單類型代碼"
                    column.HeaderText = " 訂單類型代碼"
                    column.DisplayIndex = 10
                    column.Visible = False
                Case "商品屬性"
                    column.HeaderText = " 商品屬性"
                    column.DisplayIndex = 11
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
        laCardCode.Text = ""
        laCardName.Text = ""
        laSource.Text = ""
        strSaleGroupType = ""
        strAtttibuteType = ""
        strOrderSource = ""
        strOrderName = ""
        strOrderType = ""
        btnInsert.Enabled = False
        btnDel.Enabled = False
    End Sub



    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If laID.Text = "" Then
            MsgBox("失敗：請選擇欲補印之日期!!", 16, "錯誤")
            Exit Sub
        End If

        Select Case laSource.Text
            Case "網路通路"
                A_AUTO_ORDR.Source = "EC"
                A_AUTO_ORDR.KEY = laID.Text
                A_AUTO_ORDR.CardCode = laCardCode.Text
                A_AUTO_ORDR.CardName = laCardName.Text
                A_AUTO_ORDR.strAtttibuteType = strAtttibuteType
                A_AUTO_ORDR.strOrderName = strOrderName
                A_AUTO_ORDR.strOrderType = strOrderType
                A_AUTO_ORDR.strOrderSource = strOrderSource
                A_AUTO_ORDR.MdiParent = MainForm
                A_AUTO_ORDR.Show()
                Me.Close()
            Case "員購"
                A_AUTO_ORDR.Source = "Welfare"
                A_AUTO_ORDR.KEY = laID.Text
                A_AUTO_ORDR.CardCode = laCardCode.Text
                A_AUTO_ORDR.CardName = laCardName.Text
                A_AUTO_ORDR.strSaleGroupType = strSaleGroupType
                A_AUTO_ORDR.MdiParent = MainForm
                A_AUTO_ORDR.Show()
                Me.Close()
        End Select


    End Sub

    Private Sub btnSerch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerch.Click
        '取得查詢資料
        GetDGV1Data()
        初始化()
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
            Select Case laSource.Text
                Case "員購"
                    sql = " UPDATE [KS_Z_Welfare]       SET [State]= '9'                                                                WHERE Convert(Varchar, AddDate, 111)='" + laID.Text + "' AND State='2' AND SaleGroupType='" + strSaleGroupType + "' "
                Case "網路通路"
                    sql = " UPDATE E SET E.[State]= '9', E.AlterDate=getdate(), E.AlterUser='" + Login.LogonUserName + "'  From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] E INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] EC ON E.ID=EC.ID WHERE Convert(Varchar, AddDate, 111) ='" + laID.Text + "' AND E.State='0' AND E.AtttibuteType='" + strAtttibuteType + "' "
            End Select



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

        MsgBox("刪除成功!!", 64, "完成")
        初始化()
        '重新取得查詢資料
        GetDGV1Data()
    End Sub
End Class