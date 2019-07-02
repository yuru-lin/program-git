Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class StorePlaceBasicData

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub StorePlaceBasicData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '取得下拉式選單資料
        Select_ddlStoreClass() '庫位別
        Select_ddlStorePlaceType() '庫位所在位置別
        Select_ddlStoreType() '可存放類型別
        Select_ddlType() '別類別
        Select_ddlClassType() '所在區域別

        初始化()
    End Sub

#Region "下拉式相關"
    Private Sub Select_ddlStoreClass()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = " SELECT SUBSTRING(U_Pcode,1,1) AS 'TYPE' FROM [@WPLACE] GROUP BY SUBSTRING(U_Pcode,1,1) "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ddlStoreClass.DataSource = ksSelectDataSet.Tables("DT1")
        ddlStoreClass.DisplayMember = "TYPE"


    End Sub

    Private Sub Select_ddlStorePlaceType()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT ID, Name From [KaiShingPlug].[dbo].[C_StoreHouseType] WHERE [Type]='P' AND [State]='1' Order By [Sort] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ddlStorePlaceType.DataSource = ksSelectDataSet.Tables("DT1")
        ddlStorePlaceType.DisplayMember = "Name"
        ddlStorePlaceType.ValueMember = "ID"


    End Sub

    Private Sub Select_ddlStoreType()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT ID, Name From [KaiShingPlug].[dbo].[C_StoreHouseType] WHERE [Type]='S' AND [State]='1' Order By [Sort] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ddlStoreType.DataSource = ksSelectDataSet.Tables("DT1")
        ddlStoreType.DisplayMember = "Name"
        ddlStoreType.ValueMember = "ID"


    End Sub

    Private Sub Select_ddlType()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT ID, Name From [KaiShingPlug].[dbo].[C_StoreHouseType] WHERE [Type]='T' AND [State]='1' Order By [Sort] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ddlType.DataSource = ksSelectDataSet.Tables("DT1")
        ddlType.DisplayMember = "Name"
        ddlType.ValueMember = "ID"


    End Sub

    Private Sub Select_ddlClassType()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT ID, Name From [KaiShingPlug].[dbo].[C_StoreHouseType] WHERE [Type]='C' AND [State]='1' Order By [Sort] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ddlClassType.DataSource = ksSelectDataSet.Tables("DT1")
        ddlClassType.DisplayMember = "Name"
        ddlClassType.ValueMember = "ID"


    End Sub
#End Region

#Region "GV相關"
    Private Sub GetDav1Data()

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String = String.Empty
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            
            sql = " SELECT B.ID AS '編號', PlaceID AS '儲位編號', PlaceName AS '儲位名稱', StoreClass AS '庫位別', StoreName AS '倉庫名稱' "
            sql += "     , P.Name AS '庫位所在位置', [MAX] AS '最大存放量', [Level] AS '層數' , S.Name AS '可存放類型' "
            sql += "     , T.Name AS '別類', C.Name AS '所在區域', B.MEMO AS '備註'"
            sql += "  FROM [KaiShingPlug].[dbo].[C_StorePlaceBasicData] B "
            sql += "       LEFT JOIN [KaiShingPlug].[dbo].[C_StoreHouseType] P ON B.StorePlaceType=P.ID  "
            sql += "       LEFT JOIN [KaiShingPlug].[dbo].[C_StoreHouseType] S ON B.StoreType=S.ID  "
            sql += "       LEFT JOIN [KaiShingPlug].[dbo].[C_StoreHouseType] T ON B.[Type]=T.ID  "
            sql += "       LEFT JOIN [KaiShingPlug].[dbo].[C_StoreHouseType] C ON B.ClassType=C.ID  "
            sql += " WHERE PlaceID Like '%" & TextBox1.Text & "%' AND PlaceID Like '%" & TextBox2.Text & "%'  AND PlaceID Like '%" & TextBox3.Text & "%' AND B.State='1' "
            sql += " ORDER BY PlaceID "
           
          

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
                    column.Visible = False
                Case "儲位編號"
                    column.HeaderText = "儲位編號"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 90
                Case "儲位名稱"
                    column.HeaderText = "儲位名稱"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                    column.Width = 100
                Case "庫位別"
                    column.HeaderText = "庫位別"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 70
                Case "倉庫名稱"
                    column.HeaderText = "庫名"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                    column.Width = 100
                Case "庫位所在位置"
                    column.HeaderText = "庫位所在位置"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                    column.Width = 110
                Case "最大存放量"
                    column.HeaderText = "最大量"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                    column.Width = 70
                Case "層數"
                    column.HeaderText = "層數"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                    column.Width = 60
                Case "可存放類型"
                    column.HeaderText = "可存放類型"
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                    column.Width = 100
                Case "別類"
                    column.HeaderText = "別類"
                    column.DisplayIndex = 9
                    column.ReadOnly = True
                    column.Width = 70
                Case "所在區域"
                    column.HeaderText = "所在區域"
                    column.DisplayIndex = 10
                    column.ReadOnly = True
                    column.Width = 80
                Case "備註"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 11
                    column.ReadOnly = True
                    column.Width = 100
                Case Else
                    column.Visible = False
            End Select
        Next

        'DGV1.AutoResizeColumns()
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        laID.Text = DGV1.CurrentRow.Cells("編號").Value
        txtPlaceID.Text = DGV1.CurrentRow.Cells("儲位編號").Value
        txtPlaceName.Text = DGV1.CurrentRow.Cells("儲位名稱").Value
        ddlStoreClass.Text = DGV1.CurrentRow.Cells("庫位別").Value
        txtStoreName.Text = DGV1.CurrentRow.Cells("倉庫名稱").Value
        ddlStorePlaceType.Text = DGV1.CurrentRow.Cells("庫位所在位置").Value
        txtMAX.Text = DGV1.CurrentRow.Cells("最大存放量").Value
        txtLevel.Text = DGV1.CurrentRow.Cells("層數").Value
        ddlStoreType.Text = DGV1.CurrentRow.Cells("可存放類型").Value
        ddlType.Text = DGV1.CurrentRow.Cells("別類").Value
        ddlClassType.Text = DGV1.CurrentRow.Cells("所在區域").Value
        txtMEMO.Text = DGV1.CurrentRow.Cells("備註").Value

        btnInsert.Enabled = False
        btnDel.Enabled = True
        btnUpdate.Enabled = True
    End Sub

#End Region

    Private Sub 初始化()
        ddlStoreClass.SelectedIndex = -1
        ddlStorePlaceType.SelectedIndex = -1
        ddlStoreType.SelectedIndex = -1
        ddlType.SelectedIndex = -1
        ddlClassType.SelectedIndex = -1

        txtPlaceID.Text = ""
        txtPlaceName.Text = ""
        txtStoreName.Text = ""
        txtMAX.Text = ""
        txtLevel.Text = ""
        txtMEMO.Text = ""
        laID.Text = ""

        btnInsert.Enabled = True
        btnUpdate.Enabled = False
        btnDel.Enabled = False

    End Sub

    Private Sub Button_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_01.Click
        GetDav1Data()
        初始化()
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If txtPlaceID.Text = "" Then
            MsgBox("請輸入儲位編號", 16, "錯誤")
            Exit Sub
        End If

        If ddlStorePlaceType.SelectedIndex = -1 Then
            MsgBox("請選擇庫位別", 16, "錯誤")
            Exit Sub
        End If

        If ddlStorePlaceType.SelectedIndex = -1 Then
            MsgBox("請選擇庫位所在位置", 16, "錯誤")
            Exit Sub
        End If

        If txtMAX.Text = "" Then
            MsgBox("請輸入最大存放量", 16, "錯誤")
            Exit Sub
        End If

        If txtLevel.Text = "" Then
            MsgBox("請輸入層數", 16, "錯誤")
            Exit Sub
        End If

        If ddlStoreType.SelectedIndex = -1 Then
            MsgBox("請選擇可存放類型", 16, "錯誤")
            Exit Sub
        End If

        If ddlType.SelectedIndex = -1 Then
            MsgBox("請選擇別類", 16, "錯誤")
            Exit Sub
        End If

        If ddlClassType.SelectedIndex = -1 Then
            MsgBox("請選擇所在區域", 16, "錯誤")
            Exit Sub
        End If

        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Try
            SQLCmd.CommandText = String.Format(" INSERT INTO [KaiShingPlug].[dbo].[C_StorePlaceBasicData] ( " & _
                    "[PlaceID]    ,[PlaceName],[StoreClass],[StoreName],[StorePlaceType],[MAX],[Level],[StoreType],[Type],[ClassType],[State],[MEMO]) " & _
             "VALUES ('{0}'      ,'{1}'       ,'{2}'       ,'{3}'      ,'{4}'           ,{5}  ,{6}    ,'{7}'      ,'{8}'  ,'{9}'     ,'1'    ,'{10}') " _
             , txtPlaceID.Text _
             , txtPlaceName.Text _
             , ddlStoreClass.SelectedItem(0) _
             , txtStoreName.Text _
             , ddlStorePlaceType.SelectedValue _
             , txtMAX.Text _
             , txtLevel.Text _
             , ddlStoreType.SelectedValue _
             , ddlType.SelectedValue _
             , ddlClassType.SelectedValue _
             , txtMEMO.Text)


            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("修改失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("新增成功!!", 64, "完成")

        初始化()
        GetDav1Data()

    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtPlaceID.Text = "" Then
            MsgBox("請輸入儲位編號", 16, "錯誤")
            Exit Sub
        End If

        If ddlStorePlaceType.SelectedIndex = -1 Then
            MsgBox("請選擇庫位別", 16, "錯誤")
            Exit Sub
        End If

        If ddlStorePlaceType.SelectedIndex = -1 Then
            MsgBox("請選擇庫位所在位置", 16, "錯誤")
            Exit Sub
        End If

        If txtMAX.Text = "" Then
            MsgBox("請輸入最大存放量", 16, "錯誤")
            Exit Sub
        End If

        If txtLevel.Text = "" Then
            MsgBox("請輸入層數", 16, "錯誤")
            Exit Sub
        End If

        If ddlStoreType.SelectedIndex = -1 Then
            MsgBox("請選擇可存放類型", 16, "錯誤")
            Exit Sub
        End If

        If ddlType.SelectedIndex = -1 Then
            MsgBox("請選擇別類", 16, "錯誤")
            Exit Sub
        End If

        If ddlClassType.SelectedIndex = -1 Then
            MsgBox("請選擇所在區域", 16, "錯誤")
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
            SQLCmd.CommandText = String.Format(" INSERT INTO [KaiShingPlug].[dbo].[C_StorePlaceBasicData] ( " & _
                  "[PlaceID]    ,[PlaceName],[StoreClass],[StoreName],[StorePlaceType],[MAX],[Level],[StoreType],[Type],[ClassType],[State],[MEMO]) " & _
           "VALUES ('{0}'      ,'{1}'       ,'{2}'       ,'{3}'      ,'{4}'           ,{5}  ,{6}    ,'{7}'      ,'{8}'  ,'{9}'     ,'1'    ,'{10}') " _
           , txtPlaceID.Text _
           , txtPlaceName.Text _
           , ddlStoreClass.SelectedItem(0) _
           , txtStoreName.Text _
           , ddlStorePlaceType.SelectedValue _
           , txtMAX.Text _
           , txtLevel.Text _
           , ddlStoreType.SelectedValue _
           , ddlType.SelectedValue _
           , ddlClassType.SelectedValue _
           , txtMEMO.Text)

            sql = String.Format(" UPDATE [KaiShingPlug].[dbo].[C_StorePlaceBasicData] SET [PlaceID]= '{0}', [PlaceName]= '{1}' , [StoreClass]= '{2}' , [StoreName]= '{3}' " & _
                                " , [StorePlaceType]= '{4}' , [MAX]= {5} , [Level]= {6} , [StoreType]= '{7}' , [Type]= '{8}' , [ClassType]= '{9}' , [MEMO]= '{10}' " & _
                                " WHERE  State='1' AND ID='{11}' " _
           , txtPlaceID.Text _
           , txtPlaceName.Text _
           , ddlStoreClass.SelectedItem(0) _
           , txtStoreName.Text _
           , ddlStorePlaceType.SelectedValue _
           , txtMAX.Text _
           , txtLevel.Text _
           , ddlStoreType.SelectedValue _
           , ddlType.SelectedValue _
           , ddlClassType.SelectedValue _
           , txtMEMO.Text _
           , laID.Text)

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("修改失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '===========================================修改資料庫作業END===============================================

        MsgBox("修改成功!!", 64, "完成")
        初始化()
        GetDav1Data()
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

           
            sql = " UPDATE [KaiShingPlug].[dbo].[C_StorePlaceBasicData] SET [State]= '9'  WHERE  State='1' AND ID='" + laID.Text + "'"
           

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
        GetDav1Data()
    End Sub

    
End Class