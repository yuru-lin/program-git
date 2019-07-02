Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Drawing.Drawing2D

Public Class FdCk_Expense
    Dim connection As SqlConnection = Login.DBConn
    Dim ConnetionString As String
    Dim ds_expense As New DataSet
    Dim adapter As SqlDataAdapter
    Dim changes As DataSet
    Dim sql As String
    Dim i As Int32
    Dim cmdBuilder As SqlCommandBuilder

    Private Sub FdCk_Expense_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connection As SqlConnection = Login.DBConn
        Dim cmd As SqlCommand = New SqlCommand
        Dim s As String
        GetFdCkExpenseDGVData()
        FdCkExpGridView.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        FdCkExpGridView.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        Try
            If connection.State = ConnectionState.Closed Then
                'MessageBox.Show("資料庫連線關閉!")
                connection.Open()
            Else
                'MessageBox.Show("資料庫連線開啟!!")
            End If
            cmd.Connection = connection
            cmd.CommandText = "select top 1 case  flag  when 'c' then '已結單' else '未結單' end [狀態]  from [KaiShingPlug].[dbo].[FdCk] where SerialID='" + FD6.Text + "'"
            Dim lrd As SqlDataReader = cmd.ExecuteReader()
            While lrd.Read()
                s = Convert.ToString(lrd("狀態"))
            End While
        Catch ex As Exception
            MessageBox.Show("Error while retrieving records on table..." & ex.Message, "Load Records")
        Finally
            connection.Close()
        End Try

        If (s = "已結單") Then
            Updatebtn.Enabled = False
        Else
            Updatebtn.Enabled = True
        End If

        '設定textbox只可讀取
        FD6.ReadOnly = True
        FD6.BackColor = Color.Yellow

        'Lock(User於datagrid上做修改紀錄, 防止出現error)
        FdCkExpGridView.Columns("契養批號").ReadOnly = True
        FdCkExpGridView.Columns("入雞隻數").ReadOnly = True
        FdCkExpGridView.Columns("抓雞隻數").ReadOnly = True
        FdCkExpGridView.Columns("入雞日期").ReadOnly = True
        FdCkExpGridView.Columns("抓雞日期").ReadOnly = True
        FdCkExpGridView.Columns("日齡").ReadOnly = True
        FdCkExpGridView.Columns("育成率").ReadOnly = True
        FdCkExpGridView.Columns("飼料重量").ReadOnly = True
        FdCkExpGridView.Columns("抓回重量").ReadOnly = True
        FdCkExpGridView.Columns("換肉率").ReadOnly = True
        FdCkExpGridView.Columns("雞場坪數").ReadOnly = True
        FdCkExpGridView.Columns("每隻坪數").ReadOnly = True
        FdCkExpGridView.Columns("每隻運費").ReadOnly = True
        FdCkExpGridView.Columns("每隻飼料量").ReadOnly = True
        FdCkExpGridView.Columns("毛雞款").ReadOnly = True
        FdCkExpGridView.Columns("雛雞款").ReadOnly = True
        FdCkExpGridView.Columns("飼料款").ReadOnly = True
        FdCkExpGridView.Columns("粗糠").ReadOnly = True
        FdCkExpGridView.Columns("防疫工資").ReadOnly = True
        FdCkExpGridView.Columns("水電費瓦斯").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商1").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商1金額").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商2").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商2金額").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商3").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商3金額").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商4").ReadOnly = True
        FdCkExpGridView.Columns("雞藥廠商4金額").ReadOnly = True
        FdCkExpGridView.Columns("租金-代工費").ReadOnly = True
        FdCkExpGridView.Columns("抓雞工資").ReadOnly = True
        FdCkExpGridView.Columns("備註").ReadOnly = True
        FdCkExpGridView.Columns("一期").ReadOnly = True
        FdCkExpGridView.Columns("二期").ReadOnly = True
        FdCkExpGridView.Columns("三期").ReadOnly = True
        FdCkExpGridView.Columns("四期").ReadOnly = True
        FdCkExpGridView.Columns("運費金額").ReadOnly = True
        FdCkExpGridView.Columns("狀態").ReadOnly = True
        Visibledatagird()
    End Sub

#Region "判斷已結單批號顯示顏色"
    Private Sub FdCkExpGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles FdCkExpGridView.CellFormatting
        Dim drv As DataRowView
        If e.RowIndex >= 0 Then
            If e.RowIndex <= ds_expense.Tables(0).Rows.Count - 1 Then
                drv = ds_expense.Tables(0).DefaultView.Item(e.RowIndex)
                Dim c As Color
                If drv.Item("狀態").ToString = "已結單" Then
                    c = Color.Red
                Else
                    c = Color.White
                End If
                e.CellStyle.BackColor = c
            End If
        End If
    End Sub
#End Region

    '查詢所有資料
    Private Sub queryDetail_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles queryDetail_btn.Click
        adapter = New SqlDataAdapter("select SerialID [契養批號], InCk_Num [入雞隻數],OutCk_Num [抓雞隻數],InCk_date [入雞日期],OutCk_date [抓雞日期],Ck_Days [日齡],Grow_Rate [育成率],Feed_weight [飼料重量],Back_weight [抓回重量],Conver_Rate [換肉率],Square_Num [雞場坪數],Ck_Square [每隻坪數],Ck_Freight [每隻運費],Ck_Feed [每隻飼料量],ECk_Cost [毛雞款],FCk_Cost [雛雞款],Feed_Cost [飼料款],Chaff [粗糠],Disease_Pay [防疫工資],Power_Bill [水電費瓦斯],CK_Medicine_R1 [雞藥廠商1],CK_Medicine_R1Amt [雞藥廠商1金額], CK_Medicine_R2 [雞藥廠商2] , CK_Medicine_R2Amt [雞藥廠商2金額],CK_Medicine_R3 [雞藥廠商3],CK_Medicine_R3Amt [雞藥廠商3金額],CK_Medicine_R4 [雞藥廠商4],CK_Medicine_R4Amt [雞藥廠商4金額],Subcontract_Pay [租金-代工費],CatchCk_Pay [抓雞工資],remark [備註],FirstStage [一期],SecondStage [二期],ThridStage [三期],FourthStage [四期],case  flag  when 'c' then '已結單' else '未結單' end [狀態]   from [KaiShingPlug].[dbo].[FdCk] where serialID='" + FD6.Text + "'", connection)
        adapter.Fill(ds_expense)
        FdCkExpGridView.DataSource = ds_expense.Tables(0)
        ds_expense.Tables(0).Clear()
        Try
            adapter.Fill(ds_expense)
            FdCkExpGridView.DataSource = ds_expense.Tables(0)
            MsgBox("查詢資料成功")
        Catch ex As Exception
            MsgBox("查詢資料失敗")
        End Try
        connection.Close()
        'Me.Refresh()
    End Sub

#Region "更新功能，需寫log紀錄"
    '更新功能
    Private Sub Updatebtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Updatebtn.Click
        '===========================================修改資料庫作業Begin===============================================
        If FD6.Text = "" Then
            MessageBox.Show("修改失敗：請選擇欲修改之契養批號!!")
            Exit Sub
        End If
        Dim updateExpensecommand As SqlCommand = connection.CreateCommand()
        'Dim DBConn As SqlConnection = connection
        Dim SQLExpenseUpdataCmd As SqlCommand = New SqlCommand
        SQLExpenseUpdataCmd.Connection = connection
        Dim UpdataExpenseSql As String = ""

        '修改資料前的確認
        Dim result = MessageBox.Show("確認修改並儲存契養批號 : " & FD6.Text, "資料", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Return
        ElseIf result = DialogResult.No Then
            Return
        ElseIf result = DialogResult.Yes Then
        End If

        '清除table紀錄
        ds_expense.Tables(0).Clear()
        If connection.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            connection.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If
        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行動作完成
            Try
                '===========================================先將要修改的資料搬到log_table Begin===============================================
                sql += "   INSERT INTO  [KaiShingPlug].[dbo].[FdCk_His] "
                sql += "   SELECT *, 'U', GETDATE() ,'" + Login.LogonUserName + "' "
                sql += "   FROM [KaiShingPlug].[dbo].[FdCk] "
                sql += "   WHERE SerialID='" + FD6.Text + "'"
                SQLExpenseUpdataCmd.Connection = connection
                SQLExpenseUpdataCmd.CommandText = sql
                SQLExpenseUpdataCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("搬入資料：" & ex.Message, "錯誤")
            End Try
            ' MsgBox("搬入資料成功!")
        End Using
        updateExpensecommand.CommandText = "UPDATE [KaiShingPlug].[dbo].[FdCk] SET Chaff = @Chaff, Disease_Pay = @Disease_Pay, Power_Bill=@Power_Bill,CK_Medicine_R1=@CK_Medicine_R1,CK_Medicine_R1Amt=@CK_Medicine_R1Amt ,CK_Medicine_R2=@CK_Medicine_R2" & _
                                                     ",CK_Medicine_R2Amt=@CK_Medicine_R2Amt,CK_Medicine_R3=@CK_Medicine_R3,CK_Medicine_R3Amt=@CK_Medicine_R3Amt,CK_Medicine_R4=@CK_Medicine_R4" & _
                                                     ",CK_Medicine_R4Amt=@CK_Medicine_R4Amt,Subcontract_Pay=@Subcontract_Pay,CatchCk_Pay=@CatchCk_Pay" & _
                                                     " where serialID = @serialID"

        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行動作完成
            Try
                updateExpensecommand.Parameters.Add("@Chaff", Data.SqlDbType.VarChar).Value = FD14.Text()
                updateExpensecommand.Parameters.Add("@Disease_Pay", Data.SqlDbType.VarChar).Value = FD15.Text()
                updateExpensecommand.Parameters.Add("@Power_Bill", Data.SqlDbType.VarChar).Value = FD16.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R1", Data.SqlDbType.VarChar).Value = FD17.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R1Amt", Data.SqlDbType.VarChar).Value = FD25.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R2", Data.SqlDbType.VarChar).Value = FD18.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R2Amt", Data.SqlDbType.VarChar).Value = FD26.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R3", Data.SqlDbType.VarChar).Value = FD19.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R3Amt", Data.SqlDbType.VarChar).Value = FD27.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R4", Data.SqlDbType.VarChar).Value = FD20.Text()
                updateExpensecommand.Parameters.Add("@CK_Medicine_R4Amt", Data.SqlDbType.VarChar).Value = FD28.Text()
                updateExpensecommand.Parameters.Add("@Subcontract_Pay", Data.SqlDbType.VarChar).Value = FD21.Text()
                updateExpensecommand.Parameters.Add("@CatchCk_Pay", Data.SqlDbType.VarChar).Value = FD22.Text()
                updateExpensecommand.Parameters.Add("@serialID", Data.SqlDbType.VarChar).Value = FD6.Text()
                updateExpensecommand.ExecuteNonQuery()
                MsgBox("資料修改成功!")
                Me.Refresh()
            Catch ex As Exception
                'tran.Commit()
                MessageBox.Show("資料修改錯誤...." & ex.Message, "Insert Records")
            End Try
            '再重新取得資料
            GetFdCkExpenseDGVData()
            初始化()
            connection.Close()
        End Using
    End Sub
#End Region


#Region "控制欄位textbox只能輸入數字"
    '限定粗糠只能輸入數字
    Private Sub FD14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD14.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD14.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD14.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定防疫工資只能輸入數字
    Private Sub FD15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD15.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD15.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD15.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定水電費瓦斯只能輸入數字
    Private Sub FD16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD16.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD16.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD16.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定雞藥廠商金額只能輸入數字
    Private Sub FD25_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD25.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD25.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD17.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定雞藥廠商金額只能輸入數字
    Private Sub FD26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD26.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD26.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD26.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定雞藥廠商金額只能輸入數字
    Private Sub FD27_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD27.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD27.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD27.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定雞藥廠商金額只能輸入數字
    Private Sub FD28_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD28.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD28.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD28.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定抓雞工資-只能輸入數字
    Private Sub FD22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD22.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD22.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD22.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '限定代工運費，只能輸入數字
    Private Sub FD21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD21.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD21.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD21.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region


#Region "將datagrid所選之值帶回所指定欄位"

    Private Sub FdCkExpGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FdCkExpGridView.CellClick '點選GV
        Dim i As Integer
        i = FdCkExpGridView.CurrentRow.Index

        ''選擇編號時，將所選dataGridView一起帶入指定欄位
        If FdCkExpGridView.Item(17, i).Value Is DBNull.Value Then  '粗糠
            FD14.Text = ""
        Else
            FD14.Text = FdCkExpGridView.Item(17, i).Value
        End If

        If FdCkExpGridView.Item(18, i).Value Is DBNull.Value Then  '防疫工資
            FD15.Text = ""
        Else
            FD15.Text = FdCkExpGridView.Item(18, i).Value
        End If

        If FdCkExpGridView.Item(19, i).Value Is DBNull.Value Then  '水電費
            FD16.Text = ""
        Else
            FD16.Text = FdCkExpGridView.Item(19, i).Value
        End If

        If FdCkExpGridView.Item(20, i).Value Is DBNull.Value Then  '雞藥廠商名稱1
            FD17.Text = ""
        Else
            FD17.Text = FdCkExpGridView.Item(20, i).Value
        End If

        If FdCkExpGridView.Item(21, i).Value Is DBNull.Value Then  '雞藥金額1
            FD25.Text = ""
        Else
            FD25.Text = FdCkExpGridView.Item(21, i).Value
        End If

        If FdCkExpGridView.Item(22, i).Value Is DBNull.Value Then  '雞藥廠商名稱2
            FD18.Text = ""
        Else
            FD18.Text = FdCkExpGridView.Item(22, i).Value
        End If

        If FdCkExpGridView.Item(23, i).Value Is DBNull.Value Then  '雞藥金額2
            FD26.Text = ""
        Else
            FD26.Text = FdCkExpGridView.Item(23, i).Value
        End If

        If FdCkExpGridView.Item(24, i).Value Is DBNull.Value Then  '雞藥廠商名稱3
            FD19.Text = ""
        Else
            FD19.Text = FdCkExpGridView.Item(24, i).Value
        End If

        If FdCkExpGridView.Item(25, i).Value Is DBNull.Value Then  '雞藥金額3
            FD27.Text = ""
        Else
            FD27.Text = FdCkExpGridView.Item(25, i).Value
        End If

        If FdCkExpGridView.Item(26, i).Value Is DBNull.Value Then   '雞藥廠商名稱4
            FD20.Text = ""
        Else
            FD20.Text = FdCkExpGridView.Item(26, i).Value
        End If

        If FdCkExpGridView.Item(27, i).Value Is DBNull.Value Then  '雞藥金額4
            FD28.Text = ""
        Else
            FD28.Text = FdCkExpGridView.Item(27, i).Value
        End If

        If FdCkExpGridView.Item(28, i).Value Is DBNull.Value Then   '租金-代工費
            FD21.Text = ""
        Else
            FD21.Text = FdCkExpGridView.Item(28, i).Value
        End If

        If FdCkExpGridView.Item(29, i).Value Is DBNull.Value Then  '抓雞工資
            FD22.Text = ""
        Else
            FD22.Text = FdCkExpGridView.Item(29, i).Value
        End If

    End Sub
#End Region

    '關閉視窗
#Region "關閉視窗，關掉資料庫連線"
    Private Sub CloseFormBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseFormBtn.Click
        Close()
        ds_expense.Tables(0).Clear()
    End Sub
#End Region

    '控制使用者按下x時，也關閉資料庫連線
#Region "按x關掉視窗，關掉資料庫連線"
    Private Sub MainFrom_Closed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        connection.Close()
        ds_expense.Tables(0).Clear()
    End Sub
#End Region

#Region "取得FdCkSettleGridView資料"
    Private Sub GetFdCkExpenseDGVData()
        adapter = New SqlDataAdapter("select SerialID [契養批號], InCk_Num [入雞隻數],OutCk_Num [抓雞隻數],InCk_date [入雞日期],OutCk_date [抓雞日期],Ck_Days [日齡],Grow_Rate [育成率],Feed_weight [飼料重量],Back_weight [抓回重量],Conver_Rate [換肉率],Square_Num [雞場坪數],Ck_Square [每隻坪數],Ck_Freight [每隻運費],Ck_Feed [每隻飼料量],ECk_Cost [毛雞款],FCk_Cost [雛雞款],Feed_Cost [飼料款],Chaff [粗糠],Disease_Pay [防疫工資],Power_Bill [水電費瓦斯],CK_Medicine_R1 [雞藥廠商1],CK_Medicine_R1Amt [雞藥廠商1金額], CK_Medicine_R2 [雞藥廠商2] , CK_Medicine_R2Amt [雞藥廠商2金額],CK_Medicine_R3 [雞藥廠商3],CK_Medicine_R3Amt [雞藥廠商3金額],CK_Medicine_R4 [雞藥廠商4],CK_Medicine_R4Amt [雞藥廠商4金額],Subcontract_Pay [租金-代工費],CatchCk_Pay [抓雞工資],remark [備註],FirstStage [一期],SecondStage [二期],ThridStage [三期],FourthStage [四期],TrackAmt [運費金額],case  flag  when 'c' then '已結單' else '未結單' end [狀態]   from [KaiShingPlug].[dbo].[FdCk] where serialID='" + FD6.Text + "'", connection)
        adapter.Fill(ds_expense)
        FdCkExpGridView.DataSource = ds_expense.Tables(0)
        connection.Close()
    End Sub
#End Region

#Region "初始化"
    Private Sub 初始化()
        FD14.Text = ""  '粗糠
        FD15.Text = ""  '防疫工資
        FD16.Text = ""  '水電費
        FD17.Text = ""  '雞藥廠商名稱1
        FD18.Text = ""  '雞藥廠商名稱2
        FD19.Text = ""  '雞藥廠商名稱3
        FD20.Text = ""  '雞藥廠商名稱4
        FD21.Text = ""  '租金-代工費
        FD22.Text = ""  '抓雞工資
        FD25.Text = ""  '雞藥金額1
        FD26.Text = ""  '雞藥金額2
        FD27.Text = ""  '雞藥金額3
        FD28.Text = ""  '雞藥金額4
    End Sub
#End Region

    Private Sub Visibledatagird()
        Select Case FdCkExpGridView.AllowUserToAddRows
            Case True
                FdCkExpGridView.AllowUserToAddRows = False
            Case Else
                FdCkExpGridView.AllowUserToAddRows = False
        End Select
    End Sub

#Region "背景漸層效果"
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As New LinearGradientBrush(Me.ClientRectangle, Color.LightGray, Color.Gray, 90.0F)
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
    End Sub
#End Region
End Class

