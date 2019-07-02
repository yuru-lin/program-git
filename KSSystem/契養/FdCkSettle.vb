Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Imports System.Collections.Generic
Imports System.Drawing.Drawing2D

Public Class FdCkSettle
    Dim ds_Settle As New DataSet
    Dim adapter As SqlDataAdapter
    Dim changes As DataSet
    Dim sql As String
    Dim i As Int32
    Dim cmdBuilder As SqlCommandBuilder
    Dim connection As SqlConnection = Login.DBConn

    '新增
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        FD29.Tag = "國興" ' This can be set with the designer
        FD29.Text = CStr(FD29.Tag)
        FD30.Tag = "國興"
        FD30.Text = CStr(FD30.Tag)
        FD31.Tag = "國興"
        FD31.Text = CStr(FD31.Tag)
    End Sub

    'textbox設為預設值
    Private Sub OnFD29TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FD29.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        If String.IsNullOrEmpty(FD29.Text) Then
            textbox.Text = CStr(textbox.Tag)
        End If
    End Sub

    Private Sub OnFD30TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FD30.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        If String.IsNullOrEmpty(FD30.Text) Then
            textbox.Text = CStr(textbox.Tag)
        End If
    End Sub

    Private Sub OnFD31TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FD31.TextChanged
        Dim textbox As TextBox = DirectCast(sender, TextBox)
        If String.IsNullOrEmpty(FD31.Text) Then
            textbox.Text = CStr(textbox.Tag)
        End If
    End Sub

    Private Sub FdCkSettle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '=======================================================================================================
        初始化()
        '取得資料
        GetFdCkSettleDGVData()
        FdCkSettleGridView.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        FdCkSettleGridView.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        'datagrid 加入 button按鈕
        Dim buttonColumn As New DataGridViewButtonColumn
        With buttonColumn
            '.HeaderText = "Details"
            .Name = "費用"
            .Text = "輸入費用明細"
            .UseColumnTextForButtonValue = True
        End With
        FdCkSettleGridView.Columns.Insert(0, buttonColumn)

        '隱藏設定,取消結單, 只能讓manager、ks08、ks06管理者看見
        If (Login.LogonUserName = "manager" Or Login.LogonUserName = "ks06" Or Login.LogonUserName = "ks08") Then
            CancelClosebtn.Visible = True
        Else
            CancelClosebtn.Visible = False
        End If
        '將結單先鎖住
        'Closebtn.Enabled = False
        '設定textbox只可讀取

        FD1.ReadOnly = True
        FD1.BackColor = Color.Yellow

        FD2.ReadOnly = True
        FD2.BackColor = Color.Yellow

        FD4.ReadOnly = True
        FD4.BackColor = Color.Yellow

        FD5.ReadOnly = True
        FD5.BackColor = Color.Yellow

        FD11.ReadOnly = True
        FD11.BackColor = Color.Yellow

        FD12.ReadOnly = True
        FD12.BackColor = Color.Yellow

        FD13.ReadOnly = True
        FD13.BackColor = Color.Yellow

        CustID.ReadOnly = True
        CustID.BackColor = Color.Yellow

        CustNo1.ReadOnly = True
        CustNo1.BackColor = Color.Yellow

        CustNo2.ReadOnly = True
        CustNo2.BackColor = Color.Yellow

        GrowRateTxt.ReadOnly = True
        GrowRateTxt.BackColor = Color.Yellow

        ConvertRateTxt.ReadOnly = True
        ConvertRateTxt.BackColor = Color.Yellow

        CkdaysTxt.ReadOnly = True
        CkdaysTxt.BackColor = Color.Yellow

        FD10.ReadOnly = True
        FD10.BackColor = Color.Yellow

        FD7.ReadOnly = True
        FD7.BackColor = Color.Yellow

        FD8.ReadOnly = True
        FD8.BackColor = Color.Yellow

        FD3.ReadOnly = True
        FD3.BackColor = Color.Yellow
        'lock User於datagrid上做修改紀錄，防止出現error
        FdCkSettleGridView.Columns("契養批號").ReadOnly = True
        FdCkSettleGridView.Columns("入雞隻數").ReadOnly = True
        FdCkSettleGridView.Columns("抓雞隻數").ReadOnly = True
        FdCkSettleGridView.Columns("入雞日期").ReadOnly = True
        FdCkSettleGridView.Columns("抓雞日期").ReadOnly = True
        FdCkSettleGridView.Columns("日齡").ReadOnly = True
        FdCkSettleGridView.Columns("育成率").ReadOnly = True
        FdCkSettleGridView.Columns("飼料重量").ReadOnly = True
        FdCkSettleGridView.Columns("抓回重量").ReadOnly = True
        FdCkSettleGridView.Columns("換肉率").ReadOnly = True
        FdCkSettleGridView.Columns("雞場坪數").ReadOnly = True
        FdCkSettleGridView.Columns("每隻坪數").ReadOnly = True
        FdCkSettleGridView.Columns("每隻運費").ReadOnly = True
        FdCkSettleGridView.Columns("每隻飼料量").ReadOnly = True
        FdCkSettleGridView.Columns("毛雞款").ReadOnly = True
        FdCkSettleGridView.Columns("雛雞款").ReadOnly = True
        FdCkSettleGridView.Columns("飼料款").ReadOnly = True
        FdCkSettleGridView.Columns("粗糠").ReadOnly = True
        FdCkSettleGridView.Columns("防疫工資").ReadOnly = True
        FdCkSettleGridView.Columns("水電費瓦斯").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商1").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商1金額").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商2").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商2金額").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商3").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商3金額").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商4").ReadOnly = True
        FdCkSettleGridView.Columns("雞藥廠商4金額").ReadOnly = True
        FdCkSettleGridView.Columns("租金-代工費").ReadOnly = True
        FdCkSettleGridView.Columns("抓雞工資").ReadOnly = True
        FdCkSettleGridView.Columns("備註").ReadOnly = True
        FdCkSettleGridView.Columns("一期").ReadOnly = True
        FdCkSettleGridView.Columns("二期").ReadOnly = True
        FdCkSettleGridView.Columns("三期").ReadOnly = True
        FdCkSettleGridView.Columns("四期").ReadOnly = True
        FdCkSettleGridView.Columns("運費").ReadOnly = True
        FdCkSettleGridView.Columns("客戶編號1").ReadOnly = True
        FdCkSettleGridView.Columns("客戶名稱").ReadOnly = True
        FdCkSettleGridView.Columns("客戶編號2").ReadOnly = True
        FdCkSettleGridView.Columns("狀態").ReadOnly = True
        Visibledatagird()
    End Sub

#Region "查詢所有資料"
    Private Sub Querybtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Querybtn.Click
        adapter = New SqlDataAdapter("select SerialID [契養批號], InCk_Num [入雞隻數],OutCk_Num [抓雞隻數],InCk_date [入雞日期],OutCk_date [抓雞日期],I_CardCode [客戶編號1],CardName [客戶名稱],P_CardCode [客戶編號2],Ck_Days [日齡],Grow_Rate [育成率],Feed_weight [飼料重量],Back_weight [抓回重量],Conver_Rate [換肉率],Square_Num [雞場坪數],Ck_Square [每隻坪數],Ck_Freight [每隻運費],Ck_Feed [每隻飼料量],ECk_Cost [毛雞款],FCk_Cost [雛雞款],Feed_Cost [飼料款],Chaff [粗糠],Disease_Pay [防疫工資],Power_Bill [水電費瓦斯],CK_Medicine_R1 [雞藥廠商1],CK_Medicine_R1Amt [雞藥廠商1金額], CK_Medicine_R2 [雞藥廠商2] , CK_Medicine_R2Amt [雞藥廠商2金額],CK_Medicine_R3 [雞藥廠商3],CK_Medicine_R3Amt [雞藥廠商3金額],CK_Medicine_R4 [雞藥廠商4],CK_Medicine_R4Amt [雞藥廠商4金額],Subcontract_Pay [租金-代工費],CatchCk_Pay [抓雞工資],remark [備註],FirstStage [一期],SecondStage [二期],ThridStage [三期],FourthStage [四期],TrackAmt [運費],case  flag  when 'c' then '已結單' else '未結單' end [狀態]  from [KaiShingPlug].[dbo].[FdCk]", connection)
        adapter.Fill(ds_Settle)
        FdCkSettleGridView.DataSource = ds_Settle.Tables(0)
        ds_Settle.Tables(0).Clear()
        Try
            adapter.Fill(ds_Settle)
            FdCkSettleGridView.DataSource = ds_Settle.Tables(0)
            MsgBox("查詢資料成功")
        Catch ex As Exception
            MsgBox("查詢資料失敗")
        End Try
        'GridRowFont()
        connection.Close()
    End Sub
#End Region

#Region "修改、儲存資料功能"
    Private Sub Updatebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Updatebtn.Click
        '===========================================修改資料庫作業Begin===============================================
        If FD10.Text = "" Then
            MessageBox.Show("修改失敗：請選擇欲修改之契養批號!!")
            Exit Sub
        End If

        Dim updateSettlecommand As SqlCommand = connection.CreateCommand()
        'Dim DBConn As SqlConnection = connection
        Dim SQLUpdataCmd As SqlCommand = New SqlCommand
        SQLUpdataCmd.Connection = connection
        Dim Updatasql As String = ""

        '修改資料前的確認
        Dim result = MessageBox.Show("確認修改並儲存契養批號 : " & FD10.Text, "資料", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Return
        ElseIf result = DialogResult.No Then
            Return
        ElseIf result = DialogResult.Yes Then
        End If

        ds_Settle.Tables(0).Clear()
        If connection.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            connection.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If

        'Dim tran As SqlTransaction = connection.BeginTransaction()

        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行動作完成
            Try
                '===========================================先將要修改的資料搬到log_table Begin===============================================
                sql += "   INSERT INTO  [KaiShingPlug].[dbo].[FdCk_His] "
                sql += "   SELECT *, 'U', GETDATE() ,'" + Login.LogonUserName + "' "
                sql += "   FROM [KaiShingPlug].[dbo].[FdCk] "
                sql += "   WHERE SerialID='" + FD10.Text + "'"
                SQLUpdataCmd.Connection = connection
                SQLUpdataCmd.CommandText = sql
                SQLUpdataCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("搬入資料：" & ex.Message, "錯誤")
            End Try
            'MsgBox("搬入資料成功!")
        End Using

        '判斷日期入、抓雞日期大小與計算日齡，修改觸發之後，再重新計算一次日期
        Dim FirstDate As Date  '入雞日期
        Dim SecondDate As Date '抓雞日期
        FirstDate = DateTimePicker1.Value
        SecondDate = DateTimePicker2.Value

        If FirstDate > SecondDate Then
            MessageBox.Show("入雞日期不可大於抓雞日期!!")
            Return
        ElseIf SecondDate < FirstDate Then
            MessageBox.Show("抓雞日期不可小於入雞日期!!")
            Return
        Else
        End If

        Dim days As String = DateDiff(DateInterval.Day, FirstDate, SecondDate)
        CkdaysTxt.Text = days

        '判斷必填欄位
        If String.IsNullOrEmpty(FD10.Text.ToString()) Then
            MessageBox.Show("契養批號不可為空!!!")
            Return
        End If
        '判斷育成率、換肉率輸入值不可為空
        If (String.IsNullOrEmpty(FD1.Text)) Then
            MessageBox.Show("入雞隻數不可空白!")
            Return
        ElseIf (String.IsNullOrEmpty(FD2.Text)) Then
            MessageBox.Show("抓隻隻數不可空白!")
            Return
        End If
        Dim r As Single
        Dim b As Single
        r = FD1.Text
        b = FD2.Text
        GrowRateTxt.Text = Format$(b / r, "Percent") '轉換成百分比

        '判斷飼料重量、抓回重量輸入值不可為空
        If (String.IsNullOrEmpty(FD4.Text)) Then
            MessageBox.Show("飼料重量不可空白!")
            Return
        ElseIf (String.IsNullOrEmpty(FD5.Text)) Then
            MessageBox.Show("抓回重量不可空白!")
            Return
        End If
        Dim a As Single
        Dim c As Single
        a = FD4.Text
        c = FD5.Text
        ConvertRateTxt.Text = Format(a / c, "##.##") '取到小數點後兩位

        '計算每坪隻數(入雛隻數/雞場坪數)
        Dim g As Single
        If (String.IsNullOrEmpty(FD7.Text)) Then
            'MessageBox.Show("雞場坪數為空白!")
        Else
            g = FD7.Text
            FD8.Text = Format(r / g, "##.##")  '取到小數點後兩位，算出每坪隻數
            'FD8.Text = Format(r / g, "##")  '取到小數點後兩位，算出每坪隻數
        End If

        '計算每隻飼料量，換肉率x均重(抓回重量c/抓隻雞數b)
        Dim p As Single '均重
        p = Format(c / b, "##.##")
        If (String.IsNullOrEmpty(p)) Then
            'MessageBox.Show("均重為空白!")
        Else
            FD3.Text = Format(ConvertRateTxt.Text * p, "##.##")  '每隻飼料量
        End If

        updateSettlecommand.CommandText = "UPDATE [KaiShingPlug].[dbo].[FdCk] SET InCk_Num = @InCk_Num, OutCk_Num = @OutCk_Num, InCk_date=@InCk_date,OutCk_date=@OutCk_date,Ck_Days=@Ck_Days ,Grow_Rate=@Grow_Rate" & _
                                                     ",Feed_weight=@Feed_weight,Back_weight=@Back_weight,Conver_Rate=@Conver_Rate,Square_Num=@Square_Num" & _
                                                     ",Ck_Square=@Ck_Square,Ck_Freight=@Ck_Freight,Ck_Feed=@Ck_Feed,ECk_Cost=@ECk_Cost" & _
                                                     ",FCk_Cost=@FCk_Cost,Feed_Cost=@Feed_Cost" & _
                                                     ",remark=@remark,FirstStage=@FirstStage,SecondStage=@SecondStage" & _
                                                     ",ThridStage=@ThridStage,FourthStage=@FourthStage,TrackAmt=@TrackAmt,I_CardCode=@I_CardCode,CardName=@CardName,P_CardCode=@P_CardCode" & _
                                                     " where serialID = @serialID"
        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行動作完成
            Try
                updateSettlecommand.Parameters.Add("@serialID", Data.SqlDbType.VarChar).Value = FD10.Text()
                updateSettlecommand.Parameters.Add("@InCk_Num", Data.SqlDbType.VarChar).Value = FD1.Text()
                updateSettlecommand.Parameters.Add("@OutCk_Num", Data.SqlDbType.VarChar).Value = FD2.Text()
                updateSettlecommand.Parameters.Add("@InCk_date", Data.SqlDbType.Date).Value = DateTimePicker1.Text()
                updateSettlecommand.Parameters.Add("@OutCk_date", Data.SqlDbType.Date).Value = DateTimePicker2.Text()
                updateSettlecommand.Parameters.Add("@Ck_Days", Data.SqlDbType.VarChar).Value = CkdaysTxt.Text()
                updateSettlecommand.Parameters.Add("@Grow_Rate", Data.SqlDbType.VarChar).Value = GrowRateTxt.Text()
                updateSettlecommand.Parameters.Add("@Feed_weight", Data.SqlDbType.VarChar).Value = FD4.Text()
                updateSettlecommand.Parameters.Add("@Back_weight", Data.SqlDbType.VarChar).Value = FD5.Text()
                updateSettlecommand.Parameters.Add("@Conver_Rate", Data.SqlDbType.VarChar).Value = ConvertRateTxt.Text()
                updateSettlecommand.Parameters.Add("@Square_Num", Data.SqlDbType.VarChar).Value = FD7.Text()
                updateSettlecommand.Parameters.Add("@Ck_Square", Data.SqlDbType.VarChar).Value = FD8.Text()
                updateSettlecommand.Parameters.Add("@Ck_Freight", Data.SqlDbType.VarChar).Value = FD9.Text()
                updateSettlecommand.Parameters.Add("@Ck_Feed", Data.SqlDbType.VarChar).Value = FD3.Text()
                updateSettlecommand.Parameters.Add("@ECk_Cost", Data.SqlDbType.VarChar).Value = FD11.Text()
                updateSettlecommand.Parameters.Add("@FCk_Cost", Data.SqlDbType.VarChar).Value = FD12.Text()
                updateSettlecommand.Parameters.Add("@Feed_Cost", Data.SqlDbType.VarChar).Value = FD13.Text()
                updateSettlecommand.Parameters.Add("@remark", Data.SqlDbType.VarChar).Value = RemarkTxt.Text()
                updateSettlecommand.Parameters.Add("@FirstStage", Data.SqlDbType.VarChar).Value = FD29.Text()
                updateSettlecommand.Parameters.Add("@SecondStage", Data.SqlDbType.VarChar).Value = FD30.Text()
                updateSettlecommand.Parameters.Add("@ThridStage", Data.SqlDbType.VarChar).Value = FD31.Text()
                updateSettlecommand.Parameters.Add("@FourthStage", Data.SqlDbType.VarChar).Value = FD32.Text()
                updateSettlecommand.Parameters.Add("@TrackAmt", Data.SqlDbType.VarChar).Value = TrackAmt.Text()
                updateSettlecommand.Parameters.Add("@I_CardCode", Data.SqlDbType.VarChar).Value = CustNo1.Text()
                updateSettlecommand.Parameters.Add("@CardName", Data.SqlDbType.VarChar).Value = CustID.Text()
                updateSettlecommand.Parameters.Add("@P_CardCode", Data.SqlDbType.VarChar).Value = CustNo2.Text()
                updateSettlecommand.ExecuteNonQuery()
                MsgBox("資料修改成功!")
                Me.Refresh()
            Catch ex As Exception
                'tran.Commit()
                MessageBox.Show("資料修改錯誤...." & ex.Message, "Insert Records")
            End Try
            '再重新取得資料
            GetFdCkSettleDGVData()
            初始化()
            connection.Close()
        End Using
    End Sub
#End Region
#Region "刪除功能"
    Private Sub Deletebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Deletebtn.Click
        If FdCkSettle_SerialID.Text = "" Then
            MessageBox.Show("刪除失敗：請選擇欲刪除之契養批號!!")
            Exit Sub
        End If

        '刪除資料前的確認
        Dim result = MessageBox.Show("確認刪除飼養批號 : " & FdCkSettle_SerialID.Text, "caption", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Return
        ElseIf result = DialogResult.No Then
            Return
        ElseIf result = DialogResult.Yes Then
        End If

        If connection.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            connection.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If

        '確定有資料後，先將table做清空動作
        ds_Settle.Tables(0).Clear()
        Dim sql As String
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = connection.BeginTransaction()
        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行完成
            Try
                '將相關資料先寫入His,注意再補足LogonUserName     
                sql += "   INSERT INTO  [KaiShingPlug].[dbo].[FdCk_His] "
                sql += "   SELECT *, 'D', GETDATE(),'" + Login.LogonUserName + "' "
                sql += "   FROM  [KaiShingPlug].[dbo].[FdCk] "
                sql += "   WHERE SerialID='" + FdCkSettle_SerialID.Text + "' "

                '刪除資料
                sql += "   DELETE FROM [KaiShingPlug].[dbo].[FdCk] "
                sql += "   WHERE SerialID='" + FdCkSettle_SerialID.Text + "' "
                SQLCmd.Connection = connection
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("刪除失敗")
                tran.Rollback()
                Exit Sub
            End Try
            tran.Commit()
            MsgBox("刪除成功!")
            connection.Close()
            TransactionMonitor.Complete()
        End Using
        '重新取得資料
        GetFdCkSettleDGVData()
        初始化()

    End Sub
#End Region

#Region "'限定入隻雞數只能輸入數字"
    Private Sub FD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD1.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD1.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD1.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "判斷抓隻雞數只能輸入數字"
    Private Sub FD2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD2.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD2.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD2.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "限定飼料重量只能輸入數字"
    Private Sub FD4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD4.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD4.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD4.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "限定抓回重量只能輸入數字"
    Private Sub FD5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FD5.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(FD5.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And FD5.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "限定運費金額只能輸入數字"
    Private Sub TrackAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TrackAmt.KeyPress
        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(TrackAmt.Text, ".") > 0 Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "-" And TrackAmt.Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "FdCkSettleGridView 顯示輸入費用明細表按鈕"
    Public Sub FdCkSettleGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FdCkSettleGridView.CellContentClick
        If e.ColumnIndex = 0 Then
            Dim selectRow = FdCkSettleGridView.Item("契養批號", e.RowIndex).Value
            Dim selectRow1 = FdCkSettleGridView.Item("狀態", e.RowIndex).Value

            'If selectRow1 = "已結單" Then
            '    MessageBox.Show("此契養批號已結單!")
            '    Return
            'End If

            If selectRow Is DBNull.Value Then
                FdCk_Expense.FD6.Text = ""
            Else : FdCk_Expense.FD6.Text = selectRow
                FdCk_Expense.ShowDialog()
            End If
        End If
    End Sub
#End Region

#Region "取得FdCkSettleGridView資料"
    Public Sub GetFdCkSettleDGVData()
        '判斷 dataset有值Reload時候datagrid清空
        If ds_Settle.Tables.Count = 0 Then
            adapter = New SqlDataAdapter("select SerialID [契養批號], InCk_Num [入雞隻數],OutCk_Num [抓雞隻數],InCk_date [入雞日期],OutCk_date [抓雞日期],I_CardCode [客戶編號1],CardName [客戶名稱],P_CardCode [客戶編號2],Ck_Days [日齡],Grow_Rate [育成率],Feed_weight [飼料重量],Back_weight [抓回重量],Conver_Rate [換肉率],Square_Num [雞場坪數],Ck_Square [每隻坪數],Ck_Freight [每隻運費],Ck_Feed [每隻飼料量],ECk_Cost [毛雞款],FCk_Cost [雛雞款],Feed_Cost [飼料款],Chaff [粗糠],Disease_Pay [防疫工資],Power_Bill [水電費瓦斯],CK_Medicine_R1 [雞藥廠商1],CK_Medicine_R1Amt [雞藥廠商1金額], CK_Medicine_R2 [雞藥廠商2] , CK_Medicine_R2Amt [雞藥廠商2金額],CK_Medicine_R3 [雞藥廠商3],CK_Medicine_R3Amt [雞藥廠商3金額],CK_Medicine_R4 [雞藥廠商4],CK_Medicine_R4Amt [雞藥廠商4金額],Subcontract_Pay [租金-代工費],CatchCk_Pay [抓雞工資],remark [備註],FirstStage [一期],SecondStage [二期],ThridStage [三期],FourthStage [四期],TrackAmt [運費],case  flag  when 'c' then '已結單' else '未結單' end [狀態]  from [KaiShingPlug].[dbo].[FdCk]", connection)
            adapter.Fill(ds_Settle)
            FdCkSettleGridView.DataSource = ds_Settle.Tables(0)
            ' GridRowFont()
            connection.Close()
        Else
            ds_Settle.Tables(0).Clear()
            adapter = New SqlDataAdapter("select SerialID [契養批號], InCk_Num [入雞隻數],OutCk_Num [抓雞隻數],InCk_date [入雞日期],OutCk_date [抓雞日期],I_CardCode [客戶編號1],CardName [客戶名稱],P_CardCode [客戶編號2],Ck_Days [日齡],Grow_Rate [育成率],Feed_weight [飼料重量],Back_weight [抓回重量],Conver_Rate [換肉率],Square_Num [雞場坪數],Ck_Square [每隻坪數],Ck_Freight [每隻運費],Ck_Feed [每隻飼料量],ECk_Cost [毛雞款],FCk_Cost [雛雞款],Feed_Cost [飼料款],Chaff [粗糠],Disease_Pay [防疫工資],Power_Bill [水電費瓦斯],CK_Medicine_R1 [雞藥廠商1],CK_Medicine_R1Amt [雞藥廠商1金額], CK_Medicine_R2 [雞藥廠商2] , CK_Medicine_R2Amt [雞藥廠商2金額],CK_Medicine_R3 [雞藥廠商3],CK_Medicine_R3Amt [雞藥廠商3金額],CK_Medicine_R4 [雞藥廠商4],CK_Medicine_R4Amt [雞藥廠商4金額],Subcontract_Pay [租金-代工費],CatchCk_Pay [抓雞工資],remark [備註],FirstStage [一期],SecondStage [二期],ThridStage [三期],FourthStage [四期],TrackAmt [運費],case  flag  when 'c' then '已結單' else '未結單' end [狀態]  from [KaiShingPlug].[dbo].[FdCk]", connection)
            adapter.Fill(ds_Settle)
            FdCkSettleGridView.DataSource = ds_Settle.Tables(0)
            ' GridRowFont()
            connection.Close()
        End If
    End Sub
#End Region

#Region "判斷已結單批號顯示顏色"
    Private Sub FdCkSettleGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles FdCkSettleGridView.CellFormatting
        Dim drv As DataRowView
        If e.RowIndex >= 0 Then
            If e.RowIndex <= ds_Settle.Tables(0).Rows.Count - 1 Then
                drv = ds_Settle.Tables(0).DefaultView.Item(e.RowIndex)
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

    '輸入種雞明細的button觸發
    Private Sub ClickCkKindForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClickCkKindForm.Click
        If FdCkSettle_SerialID.Text = "" Then
            MessageBox.Show("請選擇欲新增種雞明細的契養批號!")
            Return
        End If
        FdCk_Kind.FD23.Text = Trim(FdCkSettle_SerialID.Text)
        FdCk_Kind.ShowDialog()
    End Sub

#Region "控制 datagrid 所select 選項"
    Private Sub FdCkSettleGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles FdCkSettleGridView.CellClick
        If FdCkSettleGridView.CurrentRow.Cells("契養批號").Value Is DBNull.Value Then
            FdCkSettle_SerialID.Text = ""
        Else : FdCkSettle_SerialID.Text = FdCkSettleGridView.CurrentRow.Cells("契養批號").Value
        End If

        Dim i As Integer
        i = FdCkSettleGridView.CurrentRow.Index
        '選擇編號時，將所選dataGridView一起帶入指定欄位

        If FdCkSettleGridView.Item(1, i).Value Is DBNull.Value Then     '契養批號-01
            FD10.Text = ""
        Else
            FD10.Text = FdCkSettleGridView.Item(1, i).Value
        End If

        If FdCkSettleGridView.Item(2, i).Value Is DBNull.Value Then     '入雞隻數-02
            FD1.Text = ""
        Else
            FD1.Text = FdCkSettleGridView.Item(2, i).Value
        End If

        If FdCkSettleGridView.Item(3, i).Value Is DBNull.Value Then     '抓雞隻數-03
            FD2.Text = ""
        Else
            FD2.Text = FdCkSettleGridView.Item(3, i).Value
        End If

        If FdCkSettleGridView.Item(4, i).Value Is DBNull.Value Then     '入雞日期-04
            DateTimePicker1.Text = ""
        Else
            DateTimePicker1.Text = FdCkSettleGridView.Item(4, i).Value
        End If

        If FdCkSettleGridView.Item(5, i).Value Is DBNull.Value Then     '抓雞日期-05
            DateTimePicker2.Text = ""
        Else
            DateTimePicker2.Text = FdCkSettleGridView.Item(5, i).Value
        End If


        '===========================================================================
        'If FdCkSettleGridView.Item(6, i).Value Is DBNull.Value Then     '日齡
        '    CkdaysTxt.Text = ""
        'Else
        '    CkdaysTxt.Text = FdCkSettleGridView.Item(6, i).Value
        'End If

        'If FdCkSettleGridView.Item(7, i).Value Is DBNull.Value Then     '育成率
        '    GrowRateTxt.Text = ""
        'Else
        '    GrowRateTxt.Text = FdCkSettleGridView.Item(7, i).Value
        'End If

        'If FdCkSettleGridView.Item(8, i).Value Is DBNull.Value Then     '飼料重量
        '    FD4.Text = ""
        'Else
        '    FD4.Text = FdCkSettleGridView.Item(8, i).Value
        'End If

        If FdCkSettleGridView.Item(6, i).Value Is DBNull.Value Then    '客戶編號1-06
            CustNo1.Text = ""
        Else
            CustNo1.Text = FdCkSettleGridView.Item(6, i).Value
        End If

        If FdCkSettleGridView.Item(7, i).Value Is DBNull.Value Then    '客戶名稱-07
            CustID.Text = ""
        Else
            CustID.Text = FdCkSettleGridView.Item(7, i).Value
        End If

        If FdCkSettleGridView.Item(8, i).Value Is DBNull.Value Then    '客戶編號2-08
            CustNo2.Text = ""
        Else
            CustNo2.Text = FdCkSettleGridView.Item(8, i).Value
        End If




        If FdCkSettleGridView.Item(12, i).Value Is DBNull.Value Then     '抓回重量-12-09
            FD5.Text = ""
        Else
            FD5.Text = FdCkSettleGridView.Item(12, i).Value
        End If

        If FdCkSettleGridView.Item(13, i).Value Is DBNull.Value Then    '換肉率-13
            ConvertRateTxt.Text = ""
        Else
            ConvertRateTxt.Text = FdCkSettleGridView.Item(13, i).Value
        End If

        If FdCkSettleGridView.Item(14, i).Value Is DBNull.Value Then    '雞場坪數-14-11
            FD7.Text = ""
        Else
            FD7.Text = FdCkSettleGridView.Item(14, i).Value
        End If

        If FdCkSettleGridView.Item(15, i).Value Is DBNull.Value Then    '每隻坪數-15-12
            FD8.Text = ""
        Else
            FD8.Text = FdCkSettleGridView.Item(15, i).Value
        End If

        If FdCkSettleGridView.Item(16, i).Value Is DBNull.Value Then    '每隻運費-16-13
            FD9.Text = ""
        Else
            FD9.Text = FdCkSettleGridView.Item(16, i).Value
        End If

        If FdCkSettleGridView.Item(17, i).Value Is DBNull.Value Then    '每隻飼料量-17-14
            FD3.Text = ""
        Else
            FD3.Text = FdCkSettleGridView.Item(17, i).Value
        End If

        If FdCkSettleGridView.Item(18, i).Value Is DBNull.Value Then    '毛雞款-18-15
            FD11.Text = ""
        Else
            FD11.Text = FdCkSettleGridView.Item(18, i).Value
        End If

        If FdCkSettleGridView.Item(19, i).Value Is DBNull.Value Then    '雛雞款-19-16
            FD12.Text = ""
        Else
            FD12.Text = FdCkSettleGridView.Item(19, i).Value
        End If

        If FdCkSettleGridView.Item(20, i).Value Is DBNull.Value Then    '飼料款-20-17
            FD13.Text = ""
        Else
            FD13.Text = FdCkSettleGridView.Item(20, i).Value
        End If

        If FdCkSettleGridView.Item(34, i).Value Is DBNull.Value Then    '備註-34-31
            RemarkTxt.Text = ""
        Else
            RemarkTxt.Text = FdCkSettleGridView.Item(34, i).Value
        End If

        If FdCkSettleGridView.Item(35, i).Value Is DBNull.Value Then    '第一期-35-32
            'If String.IsNullOrEmpty(FD29.Text.ToString()) Then
            FD29.Text = ""
            'FD29.Text = "國興".ToString()
        Else
            FD29.Text = FdCkSettleGridView.Item(35, i).Value.ToString
        End If
        ' End If

        If FdCkSettleGridView.Item(36, i).Value Is DBNull.Value Then    '第二期-36-33
            'If String.IsNullOrEmpty(FD30.Text.ToString()) Then
            FD30.Text = ""
            'FD30.Text = "國興".ToString
        Else
            FD30.Text = FdCkSettleGridView.Item(36, i).Value.ToString
        End If
        'End If

        If FdCkSettleGridView.Item(37, i).Value Is DBNull.Value Then    '第三期-37-34
            'If String.IsNullOrEmpty(FD31.Text.ToString()) Then
            FD31.Text = ""
            'FD31.Text = "國興".ToString
        Else
            FD31.Text = FdCkSettleGridView.Item(37, i).Value.ToString
            'End If
        End If

        If FdCkSettleGridView.Item(38, i).Value Is DBNull.Value Then    '第四期-38-35
            FD32.Text = ""
        Else
            FD32.Text = FdCkSettleGridView.Item(38, i).Value.ToString
        End If

        If FdCkSettleGridView.Item(39, i).Value Is DBNull.Value Then    '運費-39-36
            TrackAmt.Text = ""
        Else
            TrackAmt.Text = FdCkSettleGridView.Item(39, i).Value
        End If

        '=========================================================================
        'If FdCkSettleGridView.Item(37, i).Value Is DBNull.Value Then    '客戶編號1
        '    CustNo1.Text = ""
        'Else
        '    CustNo1.Text = FdCkSettleGridView.Item(37, i).Value
        'End If

        'If FdCkSettleGridView.Item(38, i).Value Is DBNull.Value Then    '客戶名稱
        '    CustID.Text = ""
        'Else
        '    CustID.Text = FdCkSettleGridView.Item(38, i).Value
        'End If

        'If FdCkSettleGridView.Item(39, i).Value Is DBNull.Value Then    '客戶編號2
        '    CustNo2.Text = ""
        'Else
        '    CustNo2.Text = FdCkSettleGridView.Item(39, i).Value
        'End If


        If FdCkSettleGridView.Item(9, i).Value Is DBNull.Value Then     '日齡-09-37
            CkdaysTxt.Text = ""
        Else
            CkdaysTxt.Text = FdCkSettleGridView.Item(9, i).Value
        End If

        If FdCkSettleGridView.Item(10, i).Value Is DBNull.Value Then     '育成率-10-38
            GrowRateTxt.Text = ""
        Else
            GrowRateTxt.Text = FdCkSettleGridView.Item(10, i).Value
        End If

        If FdCkSettleGridView.Item(11, i).Value Is DBNull.Value Then     '飼料重量-11-39
            FD4.Text = ""
        Else
            FD4.Text = FdCkSettleGridView.Item(11, i).Value
        End If


        If FdCkSettleGridView.Item(40, i).Value Is DBNull.Value Then    '狀態-40
            Updatebtn.Enabled = False
            Deletebtn.Enabled = False
            Closebtn.Enabled = False
            CancelClosebtn.Enabled = False
        ElseIf FdCkSettleGridView.Item(40, i).Value = "已結單" Then
            Updatebtn.Enabled = False
            Deletebtn.Enabled = False
            Closebtn.Enabled = False
            CancelClosebtn.Enabled = True
        ElseIf FdCkSettleGridView.Item(40, i).Value = "未結單" Then
            Updatebtn.Enabled = True
            Deletebtn.Enabled = True
            Closebtn.Enabled = True
            CancelClosebtn.Enabled = False
        End If

        '判斷 dataset有值Reload時候datagrid清空
        If ds_Settle.Tables.Count = 0 Then
            Exit Sub
        Else

        End If
    End Sub
#End Region

#Region "初始化"
    Private Sub 初始化()
        FD1.Text = 0             '入雞隻數
        FD2.Text = 0             '抓雞雞數
        FD3.Text = 0             '每隻飼料量 
        FD4.Text = 0             '飼料重量
        FD5.Text = 0             '抓回重量
        FD7.Text = 0             '雞場坪數
        FD8.Text = 0             '每坪隻數
        FD9.Text = 0             '每隻運費
        FD10.Text = ""           '契養批號
        FD11.Text = 0            '毛雞款
        FD12.Text = 0            '雛雞款
        FD13.Text = 0            '飼料款
        FD29.Text = ""            '一期
        FD30.Text = ""            '二期
        FD31.Text = ""            '三期
        FD32.Text = ""            '四期
        TrackAmt.Text = 0         '運費金額
        FdCkSettle_SerialID.Text = ""      '顯示刪除得飼養批號
        ConvertRateTxt.Text = 0            '換肉率
        GrowRateTxt.Text = 0               '成長率
        CkdaysTxt.Text = 0                 '日齡
        RemarkTxt.Text = ""                '備註
        CustID.Text = ""                   '客戶名稱
        CustNo1.Text = ""                  '客戶編號1
        CustNo2.Text = ""                  '客戶編號2
    End Sub
#End Region

#Region "選已結算批號初始化"
    Private Sub 初始化1()
        FD1.Text = 0             '入雞隻數
        FD2.Text = 0             '抓雞雞數
        FD3.Text = 0             '每隻飼料量 
        FD4.Text = 0             '飼料重量
        FD5.Text = 0             '抓回重量
        FD7.Text = 0             '雞場坪數
        FD8.Text = 0             '每坪隻數
        FD9.Text = 0             '每隻運費
        FD11.Text = 0            '毛雞款
        FD12.Text = 0            '雛雞款
        FD13.Text = 0            '飼料款
        FD29.Text = ""            '一期
        FD30.Text = ""            '二期
        FD31.Text = ""            '三期
        FD32.Text = ""            '四期
        TrackAmt.Text = 0         '運費金額
        FdCkSettle_SerialID.Text = ""      '顯示刪除得飼養批號
        ConvertRateTxt.Text = 0            '換肉率
        GrowRateTxt.Text = 0               '成長率
        CkdaysTxt.Text = 0                 '日齡
        RemarkTxt.Text = ""                '備註
        CustNo2.Text = ""                  '客戶編號2
    End Sub
#End Region

    Private Sub CloseFormbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseFormbtn.Click
        Close()
    End Sub

    Private Sub SearchFdID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchFdID.Click
        If My.Application.OpenForms.Item("A_ContractFarms") IsNot Nothing Then
            MessageBox.Show("新契養批號載入畫面已開啟!")
        ElseIf My.Application.OpenForms.Item("FdCkCloseID") IsNot Nothing Then
            MessageBox.Show("已結算契養批號載入畫面已開啟!")
        Else
            A_ContractFarms.ShowDialog()
            初始化()
        End If
    End Sub

    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click
        If String.IsNullOrEmpty(FD10.Text) Then
            MessageBox.Show("請選擇欲列印契養批號!")
            Return
        Else
            FdCkReportView.ShowDialog()
        End If
    End Sub

#Region "批號結單功能"
    Private Sub Closebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Closebtn.Click
        If FD10.Text = "" Then
            MessageBox.Show("結單失敗：請選擇欲修改之契養批號!!")
            Exit Sub
        End If

        Dim SQLUpdataCmd As SqlCommand = New SqlCommand
        '   SQLUpdataCmd.Connection = connection

        Dim updateSettlecommand As SqlCommand = connection.CreateCommand()
        Dim Updatasql As String

        '修改資料前的確認
        Dim result = MessageBox.Show("確認結單契養批號 : " & FD10.Text, "資料", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Return
        ElseIf result = DialogResult.No Then
            Return
        ElseIf result = DialogResult.Yes Then
        End If

        ds_Settle.Tables(0).Clear()


        If connection.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            connection.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If

        'Dim tran As SqlTransaction = connection.BeginTransaction()

        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行動作完成
            Try
                '===========================================先將要結單的資料搬到FdCkReport_table Begin===============================================
                sql += "   INSERT INTO  [KaiShingPlug].[dbo].[FdCkReport] "
                sql += "   SELECT SerialID,InCk_date,OutCk_date,InCk_Num,OutCk_Num,SumCk_Num,Grow_Rate,Feed_weight,Back_weight,Conver_Rate,Ck_Square,Square_Num,"
                sql += "   Ck_Freight,Ck_Feed,ECk_Cost,FCk_Cost,Feed_Cost,Back_Cost,Mulite_Exp,Bal_Exp,ECk_Rate,FCk_Rate,Feed_Rate,Back_Rate,Mulite_Rate,Bal_Exp_Rate,"
                sql += "   Ck_Days,Chaff,Disease_Pay,Power_Bill,FirstStage,SecondStage,ThridStage,FourthStage,CK_Medicine_R1,CK_Medicine_R2,CK_Medicine_R3,CK_Medicine_R4,CK_Medicine_R1Amt,CK_Medicine_R2Amt,"
                sql += "   CK_Medicine_R3Amt,CK_Medicine_R4Amt,Subcontract_Pay,CatchCk_Pay,TrackAmt,SumAmt,Remark,I_CardCode,CardName,P_CardCode,"
                sql += "   GETDATE(), 'C' ,'" + Login.LogonUserName + "' "
                sql += "   FROM [KaiShingPlug].[dbo].[FdCk] "
                sql += "   WHERE SerialID='" + FD10.Text + "'"
                SQLUpdataCmd.Connection = connection
                SQLUpdataCmd.CommandText = sql
                SQLUpdataCmd.ExecuteNonQuery()

                '===========================================結單修改到FdCk_table Flag Begin===============================================
                Updatasql += "UPDATE [KaiShingPlug].[dbo].[FdCk] SET Flag='C' Where SerialID ='" + FD10.Text + "' "
                updateSettlecommand.Connection = connection
                updateSettlecommand.CommandText = Updatasql
                updateSettlecommand.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("結單：" & ex.Message, "錯誤")
            End Try
            MsgBox("結單成功!")
        End Using

        '重新取得資料
        GetFdCkSettleDGVData()
    End Sub
#End Region

#Region "取消結單功能"
    Private Sub CancelClosebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelClosebtn.Click
        If FD10.Text = "" Then
            MessageBox.Show("取消結單失敗：請選擇欲修改之契養批號!!")
            Exit Sub
        End If

        Dim SQLCancelCmd As SqlCommand = connection.CreateCommand()
        Dim SQLUpdateCmd As SqlCommand = connection.CreateCommand()

        Dim CancelSql As String
        Dim UpdateSql As String

        '修改資料前的確認
        Dim result = MessageBox.Show("確認取消結單 : " & FD10.Text, "資料", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            Return
        ElseIf result = DialogResult.No Then
            Return
        ElseIf result = DialogResult.Yes Then
        End If

        ds_Settle.Tables(0).Clear()

        If connection.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            connection.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If

        'Dim tran As SqlTransaction = connection.BeginTransaction()

        Using TransactionMonitor As New System.Transactions.TransactionScope '確認執行動作完成
            Try
                '===========================================先將要結單的資料搬到FdCkReport_table Begin===============================================
                CancelSql += "delete from  [KaiShingPlug].[dbo].[FdCkReport]  Where SerialID ='" + FD10.Text + "' "
                SQLCancelCmd.Connection = connection
                SQLCancelCmd.CommandText = CancelSql
                SQLCancelCmd.ExecuteNonQuery()
                '===========================================取消結單修改到FdCk_table Flag Begin===============================================

                UpdateSql += "UPDATE [KaiShingPlug].[dbo].[FdCk] SET Flag='' Where SerialID ='" + FD10.Text + "' "
                SQLUpdateCmd.Connection = connection
                SQLUpdateCmd.CommandText = UpdateSql
                SQLUpdateCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("取消結單：" & ex.Message, "錯誤")
            End Try
            MsgBox("取消結單成功!")
        End Using

        '重新取得資料
        GetFdCkSettleDGVData()
    End Sub
#End Region

#Region "帶入已結算批號"
    Private Sub SearchCloseFdID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchCloseFdID.Click
        If My.Application.OpenForms.Item("A_ContractFarms") IsNot Nothing Then
            MessageBox.Show("新契養批號載入畫面已開啟!")
        Else
            FdCkCloseID.ShowDialog()
            初始化1()
            GetFdCkSettleDGVData()
        End If
    End Sub
#End Region

    Private Sub Visibledatagird()
        Select Case FdCkSettleGridView.AllowUserToAddRows
            Case True
                FdCkSettleGridView.AllowUserToAddRows = False
            Case Else
                FdCkSettleGridView.AllowUserToAddRows = False
        End Select
    End Sub

    '#Region "Grid美化字體"
    '    Private Sub GridRowFont()
    '        For j As Integer = 0 To FdCkSettleGridView.Rows.Count - 1
    '            FdCkSettleGridView.Rows(j).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
    '        Next
    '    End Sub
    '#End Region
#Region "背景漸層效果"
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As New LinearGradientBrush(Me.ClientRectangle, Color.LightGray, Color.Gray, 90.0F)
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
    End Sub
#End Region
End Class

