Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Data.OleDb
Imports System.Data.DataRow
Imports System.Transactions
Imports System.Drawing.Drawing2D

Public Class FdCk_Kind
    Public pFunction = New publicFunction
    Dim sTable As DataTable
    Dim connection As SqlConnection = Login.DBConn
    Dim ds_kind As New DataSet
    Dim adapter As SqlDataAdapter

    Private Sub FdCk_Kind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim DBConn As SqlConnection = Login.DBConn
        Dim xcmd As SqlCommand = New SqlCommand()
        Dim zcmd As SqlCommand = New SqlCommand()
        Dim cmd As SqlCommand = New SqlCommand()
        Dim prm As New SqlParameter
        '===========================================SAP B1-RUN Z_FdCkdetail_Report Procedure帶回資料===============================================
        cmd.Connection = DBConn
        cmd.CommandText = "[Z_FdCkdetail_Report]"
        cmd.CommandType = CommandType.StoredProcedure

        prm.ParameterName = "@SerialID_"
        prm.SqlDbType = SqlDbType.NVarChar
        cmd.Parameters.Add(New SqlParameter("@SerialID_", SqlDbType.NVarChar))
        cmd.Parameters("@SerialID_").Value = Trim(FD23.Text)

        Dim K_adp As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim DsKind As DataSet = New DataSet("FdCkkind")

        K_adp.Fill(DsKind)
        FdCkKindGridView.DataSource = DsKind.Tables(0)
        DBConn.Close()

        '===========================================SAP B1-RUN Z_FdCk_Report Procedure帶回資料=====================================================

        zcmd.Connection = DBConn
        zcmd.CommandText = "[Z_FdCk_Report]"
        zcmd.CommandType = CommandType.StoredProcedure

        prm.ParameterName = "@SerialID_"
        prm.SqlDbType = SqlDbType.NVarChar
        zcmd.Parameters.Add(New SqlParameter("@SerialID_", SqlDbType.NVarChar))
        zcmd.Parameters("@SerialID_").Value = FD23.Text

        Dim S_adp As SqlDataAdapter = New SqlDataAdapter(zcmd)
        Dim DsSum As DataSet = New DataSet("FdCkSum")

        S_adp.Fill(DsSum)
        FdCkSumForm.DataSource = DsSum.Tables(0)
        DBConn.Close()

        '===========================================SAP B1-RUN Z_FdCkReturnDerail_Report帶回資料=====================================================
        xcmd.Connection = DBConn
        xcmd.CommandText = "[Z_FdCkReturnDerail_Report]"
        xcmd.CommandType = CommandType.StoredProcedure

        prm.ParameterName = "@SerialID_"
        prm.SqlDbType = SqlDbType.NVarChar
        xcmd.Parameters.Add(New SqlParameter("@SerialID_", SqlDbType.NVarChar))
        xcmd.Parameters("@SerialID_").Value = FD23.Text

        Dim SR_adp As SqlDataAdapter = New SqlDataAdapter(xcmd)
        Dim DsRSum As DataSet = New DataSet("FdCkReturnQty")

        SR_adp.Fill(DsRSum)
        FdCkReturnQty.DataSource = DsRSum.Tables(0)
        DBConn.Close()
        '==========================================================================================================================================
        'FdCkKindGridView.Columns("契養批號").ReadOnly = True
        'FdCkKindGridView.Columns("隻種類").ReadOnly = True
        'FdCkKindGridView.Columns("公雞數").ReadOnly = True
        'FdCkKindGridView.Columns("母雞數").ReadOnly = True
        'FdCkKindGridView.Columns("公母總數").ReadOnly = True
        'FdCkKindGridView.Columns("不分均重").ReadOnly = True

        '契養批號	隻種類	公雞數	母雞數	公母總數	抓回公的重量均重	抓回母的重量均重	不分均重	總均重
        FdCkKindGridView.Columns("契養批號").ReadOnly = True
        FdCkKindGridView.Columns("隻種類").ReadOnly = True
        FdCkKindGridView.Columns("公雞數").ReadOnly = True
        FdCkKindGridView.Columns("母雞數").ReadOnly = True
        FdCkKindGridView.Columns("公母總數").ReadOnly = True
        FdCkKindGridView.Columns("抓回公的重量均重").ReadOnly = True
        FdCkKindGridView.Columns("抓回母的重量均重").ReadOnly = True
        FdCkKindGridView.Columns("不分均重").ReadOnly = True
        FdCkKindGridView.Columns("總均重").ReadOnly = True

        FdCkSumForm.Columns("契養批號").ReadOnly = True
        FdCkSumForm.Columns("入雞隻數").ReadOnly = True
        FdCkSumForm.Columns("抓雞隻數").ReadOnly = True
        FdCkSumForm.Columns("飼料重量").ReadOnly = True
        FdCkSumForm.Columns("雛雞款").ReadOnly = True
        FdCkSumForm.Columns("飼料款").ReadOnly = True
        FdCkSumForm.Columns("抓回重量").ReadOnly = True
        FdCkSumForm.Columns("毛雞款").ReadOnly = True
        FdCkSumForm.Columns("客戶編號1").ReadOnly = True
        FdCkSumForm.Columns("客戶名稱").ReadOnly = True
        FdCkSumForm.Columns("客戶編號2").ReadOnly = True
        FdCkSumForm.Columns("雞場坪數").ReadOnly = True

        FdCkReturnQty.Columns("契養批號").ReadOnly = True
        FdCkReturnQty.Columns("隻種類").ReadOnly = True
        FdCkReturnQty.Columns("抓回隻數").ReadOnly = True
        FdCkReturnQty.Columns("抓回重量").ReadOnly = True
        FdCkReturnQty.Columns("不分均重").ReadOnly = True

        '設定textbox只可讀取
        FD23.ReadOnly = True
        FD23.BackColor = Color.Yellow
        Dim cmd2 As SqlCommand = New SqlCommand
        Dim s As String
        Try
            If connection.State = ConnectionState.Closed Then
                'MessageBox.Show("資料庫連線關閉!")
                connection.Open()
            Else
                'MessageBox.Show("資料庫連線開啟!!")
            End If

            cmd2.Connection = connection
            cmd2.CommandText = "select top 1 case  flag  when 'c' then '已結單' else '未結單' end [狀態]  from [KaiShingPlug].[dbo].[FdCk] where SerialID = '" + FD23.Text + "'"
            Dim lrd As SqlDataReader = cmd2.ExecuteReader()
            While lrd.Read()
                s = Convert.ToString(lrd("狀態"))
            End While
        Catch ex As Exception
            MessageBox.Show("Error while retrieving records on table..." & ex.Message, "Load Records")
        Finally
            connection.Close()
        End Try

        If (s = "已結單") Then
            updateKind_Btn.Enabled = False
        Else
            updateKind_Btn.Enabled = True
        End If
        'datareload()   暫時移除-Phil-20140319

        FdCkKindGridView.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        FdCkKindGridView.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        FdCkSumForm.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        FdCkSumForm.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        FdCkReturnQty.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)
        FdCkReturnQty.DefaultCellStyle.Font = New Font("Arial", 10, FontStyle.Bold)

        Visibledatagird()
        GridRowFont()
        'connection.Close()
        'GetFdCkDGV3Data()
    End Sub


#Region "查詢資料功能"
    Private Sub querykind_btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles querykind_btn.Click
      
        '修改部分

        'Dim sql As String = Nothing
        'Dim sqlCmd As SqlCommand

        'Sql = " select t1.SerialID [契養批號]," & _
        '       "t1.CkKind_List [隻種類]," & _
        '       "t1.FatherCk [公隻數]," & _
        '       "t1.MotherCk [母隻數]," & _
        '       "t1.SumCk [公母總數]," & _
        '       "t1.FatherCk_Avg [抓回公的重量均重]," & _
        '       "t1.MotherCk_Avg [抓回母的重量均重]," & _
        '       "t2.Ck_avg  [不分均重]," & _
        '       "t1.Ck_Avg  [總平均]" & _
        '       "from [KaiShingPlug].[dbo].[FdCkDetail] t1 left join [KaiShingPlug].[dbo].[FdCkReturnDetail] t2" & _
        '       " on t1.SerialID = t2.SerialID  and t1.CkKind_List = t2.Ckkind " & _
        '       "Where t1.SerialID='" + FD23.Text + "'"
        'sqlCmd = New SqlCommand(Sql, connection)

        adapter = New SqlDataAdapter(" select t1.SerialID [契養批號]," & _
               "t1.CkKind_List [隻種類]," & _
               "t1.FatherCk [公隻數]," & _
               "t1.MotherCk [母隻數]," & _
               "t1.SumCk [公母總數]," & _
               "t1.FatherCk_Avg [抓回公的重量均重]," & _
               "t1.MotherCk_Avg [抓回母的重量均重]," & _
               "t2.CkReg_avg  [不分均重]," & _
               "t1.Ck_Avg  [總平均]" & _
               "from [KaiShingPlug].[dbo].[FdCkDetail] t1 left join [KaiShingPlug].[dbo].[FdCkReturnDetail] t2" & _
               " on t1.SerialID = t2.SerialID  and t1.CkKind_List = t2.Ckkind " & _
               "Where t1.SerialID='" + FD23.Text + "' ", connection)

        adapter.Fill(ds_kind)
        FdCkKindGridView.DataSource = ds_kind.Tables(0)
        ds_kind.Tables(0).Clear()
        Try
            adapter.Fill(ds_kind)
            FdCkKindGridView.DataSource = ds_kind.Tables(0)
            MsgBox("查詢資料成功")
        Catch ex As Exception
            MsgBox("查詢資料失敗")
        End Try
        connection.Close()
    End Sub
#End Region

#Region "取得FdCkKindGridView資料"
    Private Sub GetFdCkDGV3Data()
        '判斷 dataset有值Reload時候datagrid清空
        If ds_kind.Tables.Count = 0 Then
            Exit Sub
        Else
            ds_kind.Tables(0).Clear()
        End If
        'adapter = New SqlDataAdapter("select SerialID [契養批號],CkKind_List [隻種類],FatherCk [公隻數],MotherCk [母隻數],SumCk [公母總數],FatherCk_Avg [抓回公的重量均重],MotherCk_Avg [抓回母的重量均重],Regard_Avg [不分均重],Ck_Avg [總平均]  from [KaiShingPlug].[dbo].[FdCkDetail] where serialID='" + FD23.Text + "'", connection)

        adapter = New SqlDataAdapter(" select t1.SerialID [契養批號]," & _
               "t1.CkKind_List [隻種類]," & _
               "t1.FatherCk [公隻數]," & _
               "t1.MotherCk [母隻數]," & _
               "t1.SumCk [公母總數]," & _
               "t1.FatherCk_Avg [抓回公的重量均重]," & _
               "t1.MotherCk_Avg [抓回母的重量均重]," & _
               "t2.CkReg_avg  [不分均重]," & _
               "t1.Ck_Avg  [總平均]" & _
               "from [KaiShingPlug].[dbo].[FdCkDetail] t1 left join [KaiShingPlug].[dbo].[FdCkReturnDetail] t2" & _
               " on t1.SerialID = t2.SerialID  and t1.CkKind_List = t2.Ckkind where t1.serialID='" + FD23.Text + "'", connection)
        adapter.Fill(ds_kind)
        FdCkKindGridView.DataSource = ds_kind.Tables(0)
        connection.Close()
    End Sub
#End Region

#Region "修改儲存功能"
    Private Sub updateKind_Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateKind_Btn.Click
        '================================================================================================================
        If connection.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            connection.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If
        Dim insertdetailcommand As SqlCommand = connection.CreateCommand()
        Dim inserthisdetailcommand As SqlCommand = connection.CreateCommand()
        Dim insertReturndetailcommand As SqlCommand = connection.CreateCommand()
        Dim deldetailcommand As SqlCommand = connection.CreateCommand()
        Dim delReturndetailcommand As SqlCommand = connection.CreateCommand()
        Dim Updatecommand As SqlCommand = connection.CreateCommand()

        '修改資料之前，先將資料刪除
        deldetailcommand.CommandText = "delete from  [KaiShingPlug].[dbo].[FdCkDetail] where SerialID ='" + FD23.Text + "'"
        deldetailcommand.ExecuteNonQuery()
        delReturndetailcommand.CommandText = "delete from  [KaiShingPlug].[dbo].[FdCkReturnDetail] where SerialID ='" + FD23.Text + "'"
        delReturndetailcommand.ExecuteNonQuery()
        'MessageBox.Show("刪除資料成功")


        'insertReturndetailcommand.CommandText = "INSERT INTO  [KaiShingPlug].[dbo].[FdCkReturnDetail](SerialID,Ckkind,ReturnQuantity) " & _
        '"VALUES (@SerialID,@Ckkind,@ReturnQuantity)"


        '修改部分
        insertReturndetailcommand.CommandText = "INSERT INTO  [KaiShingPlug].[dbo].[FdCkReturnDetail](SerialID,Ckkind,ReturnQuantity,BackWeight,CkReg_avg) " & _
        "VALUES (@SerialID,@Ckkind,@ReturnQuantity,@BackWeight,@CkReg_avg)"


        insertdetailcommand.CommandText = "INSERT INTO  [KaiShingPlug].[dbo].[FdCkDetail](SerialID,CkKind_List,FatherCk,MotherCk,SumCk,FatherCk_Avg,MotherCk_Avg,Regard_Avg,Ck_Avg) " & _
        "VALUES (@SerialID,@CkKind_List,@FatherCk,@MotherCk,@SumCk,@FatherCk_Avg,@MotherCk_Avg,@Regard_Avg,@Ck_Avg)"


        inserthisdetailcommand.CommandText = "INSERT INTO  [KaiShingPlug].[dbo].[FdCkDetail_His](SerialID,CkKind_List,FatherCk,MotherCk,SumCk,FatherCk_Avg,MotherCk_Avg,Regard_Avg,Ck_Avg,HisType,HisDate,HisUser) " & _
        "VALUES (@SerialID,@CkKind_List,@FatherCk,@MotherCk,@SumCk,@FatherCk_Avg,@MotherCk_Avg,@Regard_Avg,@Ck_Avg,@HisType,@HisDate,@HisUser)"

        Updatecommand.CommandText = "UPDATE  [KaiShingPlug].[dbo].[FdCk] SET InCk_Num = @InCk_Num, OutCk_Num = @OutCk_Num, Feed_weight=@Feed_weight,FCk_Cost=@FCk_Cost,Feed_Cost=@Feed_Cost ,Back_weight=@Back_weight,ECk_Cost=@ECk_Cost,I_CardCode=@I_CardCode,CardName=@CardName,P_CardCode=@P_CardCode,Square_Num=@Square_Num  where SerialID=@SerialID"

        Try
            insertdetailcommand.Parameters.Add("@SerialID", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@CkKind_List", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@FatherCk", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@MotherCk", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@SumCk", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@FatherCk_Avg", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@MotherCk_Avg", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@Regard_Avg", SqlDbType.VarChar)
            insertdetailcommand.Parameters.Add("@Ck_Avg", SqlDbType.VarChar)

            inserthisdetailcommand.Parameters.Add("@SerialID", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@CkKind_List", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@FatherCk", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@MotherCk", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@SumCk", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@FatherCk_Avg", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@MotherCk_Avg", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@Regard_Avg", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@Ck_Avg", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@HisType", SqlDbType.VarChar)
            inserthisdetailcommand.Parameters.Add("@HisDate", SqlDbType.DateTime)
            inserthisdetailcommand.Parameters.Add("@HisUser", SqlDbType.VarChar)

            For i As Integer = 0 To FdCkKindGridView.Rows.Count - 1
                insertdetailcommand.Parameters(0).Value = FdCkKindGridView.Rows(i).Cells(0).Value

                Dim a As String
                a = FdCkKindGridView.Rows(i).Cells(0).Value
                insertdetailcommand.Parameters(1).Value = FdCkKindGridView.Rows(i).Cells(1).Value
                insertdetailcommand.Parameters(2).Value = FdCkKindGridView.Rows(i).Cells(2).Value
                insertdetailcommand.Parameters(3).Value = FdCkKindGridView.Rows(i).Cells(3).Value
                insertdetailcommand.Parameters(4).Value = FdCkKindGridView.Rows(i).Cells(4).Value
                insertdetailcommand.Parameters(5).Value = FdCkKindGridView.Rows(i).Cells(5).Value
                insertdetailcommand.Parameters(6).Value = FdCkKindGridView.Rows(i).Cells(6).Value
                insertdetailcommand.Parameters(7).Value = FdCkKindGridView.Rows(i).Cells(7).Value
                'MessageBox.Show(FdCkKindGridView.Rows(i).Cells(7).Value)
                insertdetailcommand.Parameters(8).Value = FdCkKindGridView.Rows(i).Cells(8).Value

                '===================================================================也將資料搬移到his table=======================================================================
                inserthisdetailcommand.Parameters(0).Value = FdCkKindGridView.Rows(i).Cells(0).Value
                inserthisdetailcommand.Parameters(1).Value = FdCkKindGridView.Rows(i).Cells(1).Value
                inserthisdetailcommand.Parameters(2).Value = FdCkKindGridView.Rows(i).Cells(2).Value
                inserthisdetailcommand.Parameters(3).Value = FdCkKindGridView.Rows(i).Cells(3).Value
                inserthisdetailcommand.Parameters(4).Value = FdCkKindGridView.Rows(i).Cells(4).Value
                inserthisdetailcommand.Parameters(5).Value = FdCkKindGridView.Rows(i).Cells(5).Value
                inserthisdetailcommand.Parameters(6).Value = FdCkKindGridView.Rows(i).Cells(6).Value
                inserthisdetailcommand.Parameters(7).Value = FdCkKindGridView.Rows(i).Cells(7).Value
                inserthisdetailcommand.Parameters(8).Value = FdCkKindGridView.Rows(i).Cells(8).Value
                inserthisdetailcommand.Parameters(9).Value = "U"
                inserthisdetailcommand.Parameters(10).Value = DateTime.Now.ToString()
                inserthisdetailcommand.Parameters(11).Value = ""
                '=================================================================================================================================================================
                ''判斷 datagrid 出現null值，離開迴圈
                If String.IsNullOrEmpty(a) Then
                    Exit For
                Else
                    insertdetailcommand.ExecuteNonQuery()
                    inserthisdetailcommand.ExecuteNonQuery()
                End If
            Next

            '===================================================================也將資料Update回主table=======================================================================
            For j As Integer = 0 To FdCkSumForm.Rows.Count - 1
                Dim b As String
                b = FdCkSumForm.Rows(j).Cells(0).Value
                Updatecommand.Parameters.Clear()
                Updatecommand.Parameters.Add("@SerialID", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(0).Value
                Updatecommand.Parameters.Add("@InCk_Num", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(1).Value
                Updatecommand.Parameters.Add("@OutCk_Num", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(2).Value
                Updatecommand.Parameters.Add("@Feed_weight", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(3).Value
                Updatecommand.Parameters.Add("@FCk_Cost", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(4).Value
                Updatecommand.Parameters.Add("@Feed_Cost", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(5).Value
                Updatecommand.Parameters.Add("@Back_weight", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(6).Value
                Updatecommand.Parameters.Add("@ECk_Cost", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(7).Value
                Updatecommand.Parameters.Add("@I_CardCode", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(8).Value
                Updatecommand.Parameters.Add("@CardName", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(9).Value
                Updatecommand.Parameters.Add("@P_CardCode", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(10).Value
                Updatecommand.Parameters.Add("@Square_Num", Data.SqlDbType.VarChar).Value = FdCkSumForm.Rows(j).Cells(11).Value
                ''判斷 datagrid 出現null值，離開迴圈
                If String.IsNullOrEmpty(b) Then
                    Exit For
                Else
                    Updatecommand.ExecuteNonQuery()
                End If
            Next
            'MessageBox.Show("資料修改成功")
            'objTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("資料修改1錯誤...." & ex.Message, "資料新增錯誤")
            'objTrans.Rollback()
        End Try
        '===================================================================資料搬回FdCk_Return_detail=======================================================================
        Try
            insertReturndetailcommand.Parameters.Add("@SerialID", SqlDbType.VarChar)
            insertReturndetailcommand.Parameters.Add("@Ckkind", SqlDbType.VarChar)
            insertReturndetailcommand.Parameters.Add("@ReturnQuantity", SqlDbType.VarChar)
            insertReturndetailcommand.Parameters.Add("@BackWeight", SqlDbType.VarChar)
            insertReturndetailcommand.Parameters.Add("@CkReg_avg", SqlDbType.VarChar)
            For k As Integer = 0 To FdCkReturnQty.Rows.Count - 1
                Dim c As String
                c = FdCkReturnQty.Rows(k).Cells(0).Value
                'MessageBox.Show(b)
                insertReturndetailcommand.Parameters.Clear()
                insertReturndetailcommand.Parameters.Add("@SerialID", Data.SqlDbType.VarChar).Value = FdCkReturnQty.Rows(k).Cells(0).Value
                insertReturndetailcommand.Parameters.Add("@Ckkind", Data.SqlDbType.VarChar).Value = FdCkReturnQty.Rows(k).Cells(1).Value
                insertReturndetailcommand.Parameters.Add("@ReturnQuantity", Data.SqlDbType.VarChar).Value = FdCkReturnQty.Rows(k).Cells(2).Value
                insertReturndetailcommand.Parameters.Add("@BackWeight", Data.SqlDbType.VarChar).Value = FdCkReturnQty.Rows(k).Cells(3).Value
                insertReturndetailcommand.Parameters.Add("@CkReg_avg", Data.SqlDbType.VarChar).Value = FdCkReturnQty.Rows(k).Cells(4).Value
                ''判斷 datagrid 出現null值，離開迴圈
                If String.IsNullOrEmpty(c) Then
                    Exit For
                Else
                    insertReturndetailcommand.ExecuteNonQuery()
                End If
            Next
            MessageBox.Show("資料修改成功")
            'objTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("資料修改2錯誤...." & ex.Message, "資料新增錯誤")
            'objTrans.Rollback()
        End Try
        '重新取得資料
        'MessageBox.Show("資料新增成功")
        GetFdCkDGV3Data()
        '資料庫連線關閉
        connection.Close()
    End Sub
#End Region
    '關閉視窗
    Private Sub CloseFormBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseFormBtn.Click
        Close()
    End Sub

    Private Sub Visibledatagird()
        Select Case FdCkKindGridView.AllowUserToAddRows
            Case True
                FdCkKindGridView.AllowUserToAddRows = False
            Case Else
                FdCkKindGridView.AllowUserToAddRows = False
        End Select

        Select Case FdCkSumForm.AllowUserToAddRows
            Case True
                FdCkSumForm.AllowUserToAddRows = False
            Case Else
                FdCkSumForm.AllowUserToAddRows = False
        End Select

        Select Case FdCkReturnQty.AllowUserToAddRows
            Case True
                FdCkReturnQty.AllowUserToAddRows = False
            Case Else
                FdCkReturnQty.AllowUserToAddRows = False
        End Select
    End Sub

#Region "畫面一帶進去先重新查詢資料"
    Private Sub datareload()
        adapter = New SqlDataAdapter(" select t1.SerialID [契養批號]," & _
               "t1.CkKind_List [隻種類]," & _
               "t1.FatherCk [公隻數]," & _
               "t1.MotherCk [母隻數]," & _
               "t1.SumCk [公母總數]," & _
               "t1.FatherCk_Avg [抓回公的重量均重]," & _
               "t1.MotherCk_Avg [抓回母的重量均重]," & _
               "t2.CkReg_avg  [不分均重]," & _
               "t1.Ck_Avg  [總平均]" & _
               "from [KaiShingPlug].[dbo].[FdCkDetail] t1 left join [KaiShingPlug].[dbo].[FdCkReturnDetail] t2" & _
               " on t1.SerialID = t2.SerialID  and t1.CkKind_List = t2.Ckkind " & _
               "Where t1.SerialID='" + FD23.Text + "'", connection)
        adapter.Fill(ds_kind)
        FdCkKindGridView.DataSource = ds_kind.Tables(0)
        ds_kind.Tables(0).Clear()
        Try
            adapter.Fill(ds_kind)
            FdCkKindGridView.DataSource = ds_kind.Tables(0)
            'MsgBox("查詢資料成功")
        Catch ex As Exception
            MsgBox("查詢資料失敗")
        End Try
        connection.Close()
    End Sub
#End Region

#Region "背景漸層效果"
    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As New LinearGradientBrush(Me.ClientRectangle, Color.LightGray, Color.Gray, 90.0F)
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
    End Sub
#End Region

#Region "Grid美化字體"
    Private Sub GridRowFont()
        For j As Integer = 0 To FdCkKindGridView.Rows.Count - 1
            FdCkKindGridView.Rows(j).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        Next

        For j As Integer = 0 To FdCkSumForm.Rows.Count - 1
            FdCkSumForm.Rows(j).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        Next
       
        For j As Integer = 0 To FdCkReturnQty.Rows.Count - 1
            FdCkReturnQty.Rows(j).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        Next
    End Sub
#End Region

End Class

