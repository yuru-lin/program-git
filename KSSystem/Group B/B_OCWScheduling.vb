Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_OCWScheduling
    '
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Dim ks3DataSetDGV As DataSet = New DataSet

    '
    Dim ICodeAll, INameAll As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet

    Dim Errors As Boolean

    Private Sub B_OCWScheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '預設
        T1DGV1_All()
        T1Sid_Update()
        'T1Sid.Text = ""

        '編輯區
        T1ItemName.Enabled = False

        'Btn
        T1Update.Enabled = False
        T1Save.Enabled = False

        '特定使用者在可看到資料
        If Login.LogonUserName = "manager" Then
            T1Sid.Visible = True
            T1DGV1UpOrder.Visible = True
        End If

        T2DGV_T2Date1()

    End Sub

    Private Sub B_OCWSchedulingClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If T1Save.Enabled = True Then
            If MessageBox.Show("資料尚未儲存" & vbCrLf & "確定要離開?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Function T1Sid_Add()
        '產生Sid
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [Sid] FROM [Z_KS_CWScheduling] ORDER BY [Sid] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Sid") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub T1Sid_Update()
        '更新Sid
        Dim i As Integer
        i = T1Sid_Add()
        If i = 0 Then
            MsgBox("載入Sid資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        T1Sid.Text = i

    End Sub

    Private Sub T1DocDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1DocDate.ValueChanged
        '日期
        T1DGV1_All()

    End Sub

    Private Sub T1DGV1_All()
        '
        If T1DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("TDGV1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [Order] AS '順序' ,[Category] AS '類別' ,[CardCode] AS '廠編' ,[CardName] AS '名稱' ,[ItemCode] AS '存編' ,[ItemName] AS '雞種' ,[Gender] AS '性別' ,[Weight] AS '平均重' ,[Quantity] AS '數量' "
            sql = " SELECT * "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T1DocDate.Value.Date & "' AND [Cancel] = 'Y' ORDER BY 3 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "TDGV1")
            T1DGV1.DataSource = ks1DataSetDGV.Tables("TDGV1")

            TransactionMonitor.Complete()

        End Using

        T1DGV1_List()

    End Sub

    Private Sub T1DGV1_List()
        '設定T1DGV1欄位及順序
        For Each column As DataGridViewColumn In T1DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "Sid"
                    column.HeaderText = "Sid"
                    column.DisplayIndex = 0
                    column.Visible = False
                Case "DocDate"
                    column.HeaderText = "日期"
                    column.DisplayIndex = 1
                    column.Visible = False
                Case "Order"
                    column.HeaderText = "順序"
                    column.DisplayIndex = 2
                    column.ReadOnly = False
                    column.DefaultCellStyle.Format = "00"
                Case "Category"
                    column.HeaderText = "類別"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "CardCode"
                    column.HeaderText = " 廠編"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "CardName"
                    column.HeaderText = "名稱"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "ItemName"
                    column.HeaderText = "雞種"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case "Gender"
                    column.HeaderText = "性別"   '
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                Case "Quantity"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 9
                    column.ReadOnly = False
                    column.DefaultCellStyle.Format = "#0"
                Case "Weight"
                    column.HeaderText = "平均重"
                    column.DisplayIndex = 10
                    column.ReadOnly = False
                    column.DefaultCellStyle.Format = "#0.00"

                Case Else
                    column.Visible = False
            End Select
        Next

        T1DGV1.Refresh()
        T1DGV1.AutoResizeColumns()
        T1DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        T1DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        'T1DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub T1Category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Category.SelectedIndexChanged
        '類別
        ItemName_All()

        T1ItemName.Enabled = True

    End Sub

    Private Sub ItemName_All()
        '雞種名稱
        If T1Category.SelectedIndex = -1 Then
            Exit Sub
        End If

        '類別更換 0.契養 1.外購 2.代宰，雞種異動
        Try
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand

            sql = " SELECT [ItemCode], [ItemName] FROM [OITM] "
            sql += " WHERE [ItemName] Like '%毛雞%' AND [ItemName] Not Like '%XXX%' AND [ItemCode] Not Like '%-%' AND [ItemCode] Not Like '23%' AND "

            Select Case T1Category.SelectedIndex
                Case "0" : sql += " [ItemCode] Like '21%' "
                Case "1" : sql += " [ItemCode] Like '21%' "
                Case "2" : sql += " [ItemCode] Like '33%' "
            End Select

            sql += " ORDER BY [ItemCode] "

            If ks1DataSet.Tables.Contains("INameAll") Then

                T1ItemCode.Text = ""
                ks1DataSet.Tables("INameAll").Clear()

            End If

            INameAll = New SqlDataAdapter(sql, DBConn)
            INameAll.Fill(ks1DataSet, "INameAll")
            T1ItemName.DataSource = ks1DataSet.Tables("INameAll")
            T1ItemName.DisplayMember = "ItemName"

            T1ItemName.SelectedIndex = -1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T1ItemName_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1ItemName.SelectionChangeCommitted
        '雞種存編
        If T1ItemName.SelectedIndex = -1 Then
            Exit Sub
        End If

        Try
            Dim dt As DataTable = ks1DataSet.Tables("INameAll")
            Dim oCriteria As String = "ItemName='" & Trim(T1ItemName.Text) & "'"
            Dim foundRow() As DataRow

            foundRow = dt.Select(oCriteria)
            T1ItemCode.Text = foundRow(0)("ItemCode")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T1DGV1_Btn()
        '執行 Add Mdy Del 開啟 Save 鎖定 DocDate
        T1DocDate.Enabled = False
        T1Save.Enabled = True
    End Sub

    Private Sub T1DGV1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles T1DGV1.CellBeginEdit
        '資料表執行編輯後，才啟用存檔安鈕
        T1DGV1_Btn()

    End Sub

    Private Sub Editor_empty()
        '清空編輯區
        T1Order.Text = 0
        'T1Category.SelectedIndex = -1
        T1CardCode.Text = ""
        T1CardName.Text = ""
        T1ItemCode.Text = ""
        'T1ItemName.Enabled = False
        T1ItemName.SelectedIndex = -1
        T1Gender.SelectedIndex = -1
        T1Quantity.Text = ""
        T1Weight.Text = ""

    End Sub

    Private Sub Editor_Error()

        Errors = False

        If T1Category.Text = "" Then
            MsgBox("類別未選擇!", 16, "錯誤")
            T1Category.Focus()
            Exit Sub
        End If

        If T1ItemName.Text = "" Then
            MsgBox("雞種未選擇!", 16, "錯誤")
            T1ItemName.Focus()
            Exit Sub
        End If

        If T1Gender.Text = "" Then
            MsgBox("性別未選擇!", 16, "錯誤")
            T1Gender.Focus()
            Exit Sub
        End If

        If T1Quantity.Text = "" Then
            MsgBox("數量未填!", 16, "錯誤")
            T1Quantity.Focus()
            Exit Sub
        End If

        If T1Weight.Text = "" Then
            MsgBox("平均重未填!", 16, "錯誤")
            T1Weight.Focus()
            Exit Sub
        End If

        Errors = True

    End Sub


    Private Sub T1Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Add.Click
        '新增 Btn

        Editor_Error()

        If Errors = False Then
            Exit Sub
        End If

        T1DGV1_Add()
        T1DGV1_Btn()
        Editor_empty()

    End Sub

    Private Sub T1DGV1_Add()
        '新增至 T1DGV1
        Dim Row As DataRow
        Row = ks1DataSetDGV.Tables("TDGV1").NewRow
        Row.Item("Sid") = T1Sid.Text
        Row.Item("DocDate") = T1DocDate.Value.Date
        Row.Item("Order") = T1Order.Text
        Row.Item("Category") = T1Category.Text
        Row.Item("CardCode") = T1CardCode.Text
        Row.Item("CardName") = T1CardName.Text
        Row.Item("ItemCode") = T1ItemCode.Text
        Row.Item("ItemName") = T1ItemName.Text
        Row.Item("Gender") = T1Gender.Text
        Row.Item("Quantity") = T1Quantity.Text
        Row.Item("Weight") = T1Weight.Text
        ks1DataSetDGV.Tables("TDGV1").Rows.Add(Row)
        T1DGV1.AutoResizeColumns()

        '新增至資料庫
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim Cancel As String = "Y"
        Try
            sql = "INSERT INTO [Z_KS_CWScheduling] ([Sid],[DocDate],[Order],[Category],[CardCode],[CardName],[ItemCode],[ItemName],[Gender],[Quantity],[Weight],[Cancel]) VALUES "
            sql += " ('" & T1Sid.Text & "','" & T1DocDate.Value.Date & "','" & T1Order.Text & "','" & T1Category.Text & "','" & T1CardCode.Text & "','" & T1CardName.Text & "', '" & T1ItemCode.Text & "', '" & T1ItemName.Text & "', '" & T1Gender.Text & "', '" & T1Quantity.Text & "', '" & T1Weight.Text & "', '" & Cancel & "' )"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        T1Sid_Update()

        T1Order.Focus()

        'MsgBox("新增項目完成!", 64, "成功")

    End Sub

    Private Sub T1Mdy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Mdy.Click
        '修改 Btn
        T1DGV1_Btn()
        '
        T1Add.Enabled = False
        T1Mdy.Enabled = False
        T1Del.Enabled = False
        T1Update.Enabled = True

    End Sub

    Private Sub T1DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV1.CellClick
        'DGV1內選取列資料 同步至 編輯區
        If T1DGV1.RowCount = -1 Then
            Exit Sub
        End If

        If T1Mdy.Enabled = False Then

            T1ItemName.Enabled = True

            T1Sid.Text = T1DGV1.CurrentRow.Cells("Sid").Value
            T1Order.Text = T1DGV1.CurrentRow.Cells("Order").Value
            T1Category.Text = T1DGV1.CurrentRow.Cells("Category").Value
            T1CardCode.Text = T1DGV1.CurrentRow.Cells("CardCode").Value
            T1CardName.Text = T1DGV1.CurrentRow.Cells("CardName").Value
            T1ItemCode.Text = T1DGV1.CurrentRow.Cells("ItemCode").Value
            T1ItemName.Text = T1DGV1.CurrentRow.Cells("ItemName").Value
            T1Gender.Text = T1DGV1.CurrentRow.Cells("Gender").Value
            T1Quantity.Text = T1DGV1.CurrentRow.Cells("Quantity").Value
            T1Weight.Text = T1DGV1.CurrentRow.Cells("Weight").Value


        End If

    End Sub

    Private Sub T1Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Update.Click
        '更新 Btn
        Editor_Error()

        If Errors = False Then
            Exit Sub
        End If

        T1DGV1_Update()
        T1DGV1_UpdateDB()
        T1Sid_Update()
        Editor_empty()

        '
        T1Add.Enabled = True
        T1Mdy.Enabled = True
        T1Del.Enabled = True
        T1Update.Enabled = False

    End Sub

    Private Sub T1DGV1_Update()
        '編輯區資料 更新至 DGV1
        'T1DGV1.CurrentRow.Cells("Sid").Value = T1Sid.Text
        T1DGV1.CurrentRow.Cells("Order").Value = T1Order.Text
        T1DGV1.CurrentRow.Cells("Category").Value = T1Category.Text
        T1DGV1.CurrentRow.Cells("CardCode").Value = T1CardCode.Text
        T1DGV1.CurrentRow.Cells("CardName").Value = T1CardName.Text
        T1DGV1.CurrentRow.Cells("ItemCode").Value = T1ItemCode.Text
        T1DGV1.CurrentRow.Cells("ItemName").Value = T1ItemName.Text
        T1DGV1.CurrentRow.Cells("Gender").Value = T1Gender.Text
        T1DGV1.CurrentRow.Cells("Quantity").Value = T1Quantity.Text
        T1DGV1.CurrentRow.Cells("Weight").Value = T1Weight.Text

    End Sub

    Private Sub T1DGV1_UpdateDB()
        '資料 更新至 DB
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            sql = "  UPDATE [Z_KS_CWScheduling] SET "
            sql += " [Order]    = '" & T1DGV1.CurrentRow.Cells("Order").Value & "'    , "
            sql += " [Category] = '" & T1DGV1.CurrentRow.Cells("Category").Value & "' , "
            sql += " [CardCode] = '" & T1DGV1.CurrentRow.Cells("CardCode").Value & "' , "
            sql += " [CardName] = '" & T1DGV1.CurrentRow.Cells("CardName").Value & "' , "
            sql += " [ItemCode] = '" & T1DGV1.CurrentRow.Cells("ItemCode").Value & "' , "
            sql += " [ItemName] = '" & T1DGV1.CurrentRow.Cells("ItemName").Value & "' , "
            sql += " [Gender]   = '" & T1DGV1.CurrentRow.Cells("Gender").Value & "'   , "
            sql += " [Quantity] = '" & T1DGV1.CurrentRow.Cells("Quantity").Value & "' , "
            sql += " [Weight]   = '" & T1DGV1.CurrentRow.Cells("Weight").Value & "'     "
            sql += " WHERE [DocDate] = '" & T1DocDate.Value.Date & "' AND [Sid] = '" & T1DGV1.CurrentRow.Cells("Sid").Value & "' AND [Cancel] = 'Y' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("更新完成!", 64, "成功")

    End Sub

    Private Sub T1Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Del.Click
        '刪除 Btn
        T1Del.Enabled = False

        If T1Del.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區
                T1DGV1_Del()
                T1DGV1_All()
                T1DGV1_Btn()

            End If
        End If

        T1Del.Enabled = True

    End Sub

    Private Sub T1DGV1_Del()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For Each oRow As DataGridViewRow In T1DGV1.SelectedRows

                sql = "UPDATE [Z_KS_CWScheduling] SET [Cancel] = 'N' WHERE [DocDate] = '" & T1DocDate.Value.Date & "' AND [Sid] = '" & T1Sid.Text & "' AND [Cancel] = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("刪除完成!", 64, "成功")
    End Sub

    Private Sub T1Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1Save.Click
        '存檔 Btn
        If T1Mdy.Enabled = False Then
            MsgBox("資料更新中無法存檔!", 16, "錯誤")
            Exit Sub
        End If

        T1Save_T1DGV1()

        T1Save.Enabled = False
        T1DocDate.Enabled = True

    End Sub

    Private Sub T1Save_T1DGV1()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To T1DGV1.RowCount - 1

                sql = "  UPDATE [Z_KS_CWScheduling] SET "
                sql += " [Order]    = '" & T1DGV1.Rows(i).Cells("Order").Value & "'    , "
                sql += " [Category] = '" & T1DGV1.Rows(i).Cells("Category").Value & "' , "
                sql += " [CardCode] = '" & T1DGV1.Rows(i).Cells("CardCode").Value & "' , "
                sql += " [CardName] = '" & T1DGV1.Rows(i).Cells("CardName").Value & "' , "
                sql += " [ItemCode] = '" & T1DGV1.Rows(i).Cells("ItemCode").Value & "' , "
                sql += " [ItemName] = '" & T1DGV1.Rows(i).Cells("ItemName").Value & "' , "
                sql += " [Gender]   = '" & T1DGV1.Rows(i).Cells("Gender").Value & "'   , "
                sql += " [Quantity] = '" & T1DGV1.Rows(i).Cells("Quantity").Value & "' , "
                sql += " [Weight]   = '" & T1DGV1.Rows(i).Cells("Weight").Value & "'     "
                sql += " WHERE [DocDate] = '" & T1DocDate.Value.Date & "' AND [Sid] = '" & T1DGV1.Rows(i).Cells("Sid").Value & "' AND [Cancel] = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("存檔失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("存檔完成!", 64, "成功")
    End Sub

    Private Sub T1DGV1UpOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1DGV1UpOrder.Click
        '更新順序
        T1DGV1_All()

    End Sub










    '--排程總表----------

    Private Sub T2DocDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2DocDate.ValueChanged

        T2DGV_T2Date1()
        T2DGV_T2Clear()

    End Sub

    Private Sub T2DGV_T2Date1()

        T2Date1.Text = T2DocDate.Value.Date
        T2Date2.Text = T2DocDate.Value.Date.AddDays(1)
        T2Date3.Text = T2DocDate.Value.Date.AddDays(2)
        T2Date4.Text = T2DocDate.Value.Date.AddDays(3)
        T2Date5.Text = T2DocDate.Value.Date.AddDays(4)
        T2Date6.Text = T2DocDate.Value.Date.AddDays(5)

    End Sub

    Private Sub T2DGV_T2Clear()

        If T2DGV1.RowCount > 0 Then : ks2DataSetDGV.Tables("T2DGV1").Clear() : End If
        If T2DGV2.RowCount > 0 Then : ks2DataSetDGV.Tables("T2DGV2").Clear() : End If
        If T2DGV3.RowCount > 0 Then : ks2DataSetDGV.Tables("T2DGV3").Clear() : End If
        If T2DGV4.RowCount > 0 Then : ks2DataSetDGV.Tables("T2DGV4").Clear() : End If
        If T2DGV5.RowCount > 0 Then : ks2DataSetDGV.Tables("T2DGV5").Clear() : End If
        If T2DGV6.RowCount > 0 Then : ks2DataSetDGV.Tables("T2DGV6").Clear() : End If

    End Sub


    Private Sub T2Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2Search.Click

        T2DGV_T2Date2()

    End Sub

    Private Sub T2DGV_T2Date2()
        '
        T2DGV_T2Clear()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        'T2DGV1
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [Order] AS '順序' ,[Category] AS '類別' ,[CardCode] AS '廠編' ,[CardName] AS '名稱' ,[ItemCode] AS '存編' ,[ItemName] AS '雞種' ,[Gender] AS '性別' ,[Weight] AS '平均重' ,[Quantity] AS '數量' "
            'sql = " SELECT * "

            sql = " SELECT [ItemName] AS '雞種' ,[Gender] AS '性別' ,[Quantity] AS '數量' ,[Weight] AS '平均重' "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T2Date1.Text & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            'sql += " WHERE [DocDate] = '" & T1DocDate.Value.Date & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "T2DGV1")
            T2DGV1.DataSource = ks2DataSetDGV.Tables("T2DGV1")

            TransactionMonitor.Complete()
            T2DGV1.AutoResizeColumns()
            T2DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T2DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T2DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'T2DGV2
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemName] AS '雞種' ,[Gender] AS '性別' ,[Quantity] AS '數量' ,[Weight] AS '平均重' "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T2Date2.Text & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "T2DGV2")
            T2DGV2.DataSource = ks2DataSetDGV.Tables("T2DGV2")

            TransactionMonitor.Complete()
            T2DGV2.AutoResizeColumns()
            T2DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T2DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T2DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'T2DGV3
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemName] AS '雞種' ,[Gender] AS '性別' ,[Quantity] AS '數量' ,[Weight] AS '平均重' "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T2Date3.Text & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "T2DGV3")
            T2DGV3.DataSource = ks2DataSetDGV.Tables("T2DGV3")

            TransactionMonitor.Complete()
            T2DGV3.AutoResizeColumns()
            T2DGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T2DGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T2DGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'T2DGV4
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemName] AS '雞種' ,[Gender] AS '性別' ,[Quantity] AS '數量' ,[Weight] AS '平均重' "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T2Date4.Text & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "T2DGV4")
            T2DGV4.DataSource = ks2DataSetDGV.Tables("T2DGV4")

            TransactionMonitor.Complete()
            T2DGV4.AutoResizeColumns()
            T2DGV4.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T2DGV4.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T2DGV4.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'T2DGV5
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemName] AS '雞種' ,[Gender] AS '性別' ,[Quantity] AS '數量' ,[Weight] AS '平均重' "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T2Date5.Text & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "T2DGV5")
            T2DGV5.DataSource = ks2DataSetDGV.Tables("T2DGV5")

            TransactionMonitor.Complete()
            T2DGV5.AutoResizeColumns()
            T2DGV5.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T2DGV5.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T2DGV5.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'T2DGV6
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemName] AS '雞種' ,[Gender] AS '性別' ,[Quantity] AS '數量' ,[Weight] AS '平均重' "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T2Date6.Text & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "T2DGV6")
            T2DGV6.DataSource = ks2DataSetDGV.Tables("T2DGV6")

            TransactionMonitor.Complete()
            T2DGV6.AutoResizeColumns()
            T2DGV6.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T2DGV6.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T2DGV6.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub







    '--排程總表----------


    Private Sub T3Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3Search.Click
        T3L_Date.Text = T3DocDate.Value.Date
        T3DGV_All()
    End Sub

    Private Sub T3DGV_All()
        '
        If T3DGV1.RowCount > 0 Then : ks3DataSetDGV.Tables("T3DGV1").Clear() : End If


        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [Order] AS '順序' ,[Category] AS '類別' ,[CardCode] AS '廠編' ,[CardName] AS '名稱' ,[ItemCode] AS '存編' ,[ItemName] AS '雞種' ,[Gender] AS '性別' ,[Weight] AS '平均重' ,[Quantity] AS '數量' "
            'sql = " SELECT * "

            sql = " SELECT [ItemName] AS '雞種', [Gender] AS '性別', SUM([Quantity]) AS '數量', [Weight] AS '平均重'  "
            sql += "  FROM [Z_KS_CWScheduling] "
            sql += " WHERE [DocDate] = '" & T3DocDate.Value.Date & "' AND [Cancel] = 'Y' "
            sql += " GROUP BY [ItemName], [Gender], [Weight] ORDER BY [ItemName] "

            'sql += " WHERE [DocDate] = '" & T3DocDate.Value.Date & "' AND [Cancel] = 'Y' ORDER BY [Order] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks3DataSetDGV, "T3DGV1")
            T3DGV1.DataSource = ks3DataSetDGV.Tables("T3DGV1")

            TransactionMonitor.Complete()
            T3DGV1.AutoResizeColumns()
            T3DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            T3DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            T3DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using


    End Sub

    Private Sub T3DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T3DGV1.CellClick
        'T3DGV1內選取列資料 同步至 編輯區
        If T3DGV1.RowCount = -1 Then
            Exit Sub
        End If

        T3L_ItemName.Text = T3DGV1.CurrentRow.Cells("雞種").Value
        T3L_Weight.Text = T3DGV1.CurrentRow.Cells("平均重").Value
        T3L_Quantity.Text = T3DGV1.CurrentRow.Cells("數量").Value

        T3DGV_All2()

        'T1Sid.Text = T1DGV1.CurrentRow.Cells("Sid").Value
        'T1Order.Text = T1DGV1.CurrentRow.Cells("Order").Value
        'T1Category.Text = T1DGV1.CurrentRow.Cells("Category").Value
        'T1CardCode.Text = T1DGV1.CurrentRow.Cells("CardCode").Value
        'T1CardName.Text = T1DGV1.CurrentRow.Cells("CardName").Value
        'T1ItemCode.Text = T1DGV1.CurrentRow.Cells("ItemCode").Value
        'T1ItemName.Text = T1DGV1.CurrentRow.Cells("ItemName").Value
        'T1Gender.Text = T1DGV1.CurrentRow.Cells("Gender").Value
        'T1Quantity.Text = T1DGV1.CurrentRow.Cells("Quantity").Value
        'T1Weight.Text = T1DGV1.CurrentRow.Cells("Weight").Value


    End Sub

    Private Sub T3DGV_All2()
        '
        Select Case T3L_Weight.Text
            Case "2.20"
                T3Lab_01.Text = "1.3"
                T3Lab_02.Text = "1.4"
                T3Lab_03.Text = "1.5"
                T3Lab_04.Text = "1.6"
                T3Lab_05.Text = "1.7"
                T3Lab_06.Text = "1.8"
                T3Lab_07.Text = "1.9"
                T3Lab_08.Text = "2.0"
                T3Lab_09.Text = "2.2"
                T3Lab_10.Text = "2.4"
                T3Lab_11.Text = "2.6"
            Case "2.40"
                T3Lab_01.Text = "1.5"
                T3Lab_02.Text = "1.6"
                T3Lab_03.Text = "1.7"
                T3Lab_04.Text = "1.8"
                T3Lab_05.Text = "1.9"
                T3Lab_06.Text = "2.0"
                T3Lab_07.Text = "2.2"
                T3Lab_08.Text = "2.4"
                T3Lab_09.Text = "2.6"
                T3Lab_10.Text = "2.8"
                T3Lab_11.Text = "3.0"

            Case Else
                T3Lab_01.Text = ""
                T3Lab_02.Text = ""
                T3Lab_03.Text = ""
                T3Lab_04.Text = ""
                T3Lab_05.Text = ""
                T3Lab_06.Text = ""
                T3Lab_07.Text = ""
                T3Lab_08.Text = ""
                T3Lab_09.Text = ""
                T3Lab_10.Text = ""
                T3Lab_11.Text = ""

        End Select

        If T3L_Quantity.Text > 0 Then

            Dim T3Lab1_01s, T3Lab1_02s, T3Lab1_03s, T3Lab1_04s, T3Lab1_05s, T3Lab1_06s, T3Lab1_07s, T3Lab1_08s, T3Lab1_09s, T3Lab1_10s, T3Lab1_11s As Double

            T3Lab1_01s = Math.Round(T3L_Quantity.Text * 0.02, 0)
            T3Lab1_02s = Math.Round(T3L_Quantity.Text * 0.03, 0)
            T3Lab1_03s = Math.Round(T3L_Quantity.Text * 0.05, 0)
            T3Lab1_04s = Math.Round(T3L_Quantity.Text * 0.1, 0)
            T3Lab1_05s = Math.Round(T3L_Quantity.Text * 0.17, 0)
            T3Lab1_06s = Math.Round(T3L_Quantity.Text * 0.25, 0)
            T3Lab1_07s = Math.Round(T3L_Quantity.Text * 0.18, 0)
            T3Lab1_08s = Math.Round(T3L_Quantity.Text * 0.1, 0)
            T3Lab1_09s = Math.Round(T3L_Quantity.Text * 0.05, 0)
            T3Lab1_10s = Math.Round(T3L_Quantity.Text * 0.03, 0)
            T3Lab1_11s = Math.Round(T3L_Quantity.Text * 0.02, 0)

            T3Lab1_01.Text = T3Lab1_01s
            T3Lab1_02.Text = T3Lab1_02s
            T3Lab1_03.Text = T3Lab1_03s
            T3Lab1_04.Text = T3Lab1_04s
            T3Lab1_05.Text = T3Lab1_05s
            T3Lab1_06.Text = T3Lab1_06s
            T3Lab1_07.Text = T3Lab1_07s
            T3Lab1_08.Text = T3Lab1_08s
            T3Lab1_09.Text = T3Lab1_09s
            T3Lab1_10.Text = T3Lab1_10s
            T3Lab1_11.Text = T3Lab1_11s

            T3Lab1_All.Text = T3Lab1_01s + T3Lab1_02s + T3Lab1_03s + T3Lab1_04s + T3Lab1_05s + T3Lab1_06s + T3Lab1_07s + T3Lab1_08s + T3Lab1_09s + T3Lab1_10s + T3Lab1_11s

        End If



    End Sub



End Class   '結束
