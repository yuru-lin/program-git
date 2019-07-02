Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Public Class A_OutSideEmpBasicData
    Dim DataAdapterDGV As SqlDataAdapter
    Dim sqlReader As SqlDataReader
    Public Source As String
    Public ID As String

    Private Sub A_OutSideEmpBasicData_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        A_OutSideEmpBasicDataList.MdiParent = MainForm
        A_OutSideEmpBasicDataList.Show()
    End Sub

    Private Sub A_OutSideEmpBasicData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        生日日期_初始化()

        Select Case Source
            Case "EDIT"
                DTtermDate.Visible = True
                chbstatus.Visible = True
                Label15.Visible = True
                DTtermDate.Value = DateTime.Today
                GetData()
                btnSave.Text = "修改"

            Case "ADD"
                DTstartDate.Value = DateTime.Today
                DTtermDate.Visible = False
                chbstatus.Visible = False
                Label15.Visible = False

                ddlSaleGroupType.SelectedIndex = 0
                ddlSex.SelectedIndex = 0
                ddlYear.SelectedValue = Now.Year - 18
                btnSave.Text = "儲存"
        End Select



    End Sub

    Private Sub GetData()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "  Select empID AS '員編', lastName AS '姓名', Convert(varchar,birthDate,112) AS '生日', status AS '狀態',   "
            sql += " [sex] AS '性別', [SaleGroupType] AS '類型', [mobile] AS '聯絡電話(手機)', [homeTel] AS '聯絡電話(市話)', [homeZip] AS '郵遞區號', [homeAddress] AS '地址',   "
            sql += " [email] AS '電子信箱', Convert(varchar,startDate,111) AS '任職日期', ISNULL(Convert(varchar,termDate,111),'') AS '離職日期', remark AS '備註' "
            sql += " From KS_A_OHEM_O "
            sql += " WHERE  empID='" + ID + "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無資料", 16, "錯誤")
            Else

                txtName.Text = Convert.ToString(sqlReader.Item("姓名"))
                ddlYear.SelectedValue = Convert.ToString(sqlReader.Item("生日")).Substring(0, 4)
                ddlMonth.SelectedValue = Convert.ToString(sqlReader.Item("生日")).Substring(4, 2)
                ddlDate.SelectedValue = Convert.ToString(sqlReader.Item("生日")).Substring(6, 2)
                ddlSex.SelectedIndex = Convert.ToInt32(sqlReader.Item("性別")) + 1
                ddlSaleGroupType.SelectedIndex = Convert.ToInt32(sqlReader.Item("類型"))
                txtMobile.Text = Convert.ToString(sqlReader.Item("聯絡電話(手機)"))
                txtTel.Text = Convert.ToString(sqlReader.Item("聯絡電話(市話)"))
                txtZip.Text = Convert.ToString(sqlReader.Item("郵遞區號"))
                txtAddress.Text = Convert.ToString(sqlReader.Item("地址"))
                txtEmail.Text = Convert.ToString(sqlReader.Item("電子信箱"))
                DTstartDate.Value = Convert.ToDateTime(sqlReader.Item("任職日期"))

                If Convert.ToString(sqlReader.Item("離職日期")) <> "" Then
                    DTtermDate.Value = Convert.ToDateTime(sqlReader.Item("離職日期"))
                End If

                txtRemark.Text = Convert.ToString(sqlReader.Item("備註"))

                Select Case Convert.ToInt32(sqlReader.Item("狀態"))
                    Case 0
                        chbstatus.Checked = True
                    Case 1
                        chbstatus.Checked = False
                End Select

                sqlReader.Close()

            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub 生日日期_初始化()
       
        Dim Bir_Y As New DataTable()
        Dim Bir_M As New DataTable()
        Dim Bir_D As New DataTable()

        Bir_Y.Columns.Add(New DataColumn("Display", System.Type.GetType("System.String")))
        Bir_Y.Columns.Add(New DataColumn("Id", System.Type.GetType("System.String")))
        Bir_M.Columns.Add(New DataColumn("Display", System.Type.GetType("System.String")))
        Bir_M.Columns.Add(New DataColumn("Id", System.Type.GetType("System.String")))
        Bir_D.Columns.Add(New DataColumn("Display", System.Type.GetType("System.String")))
        Bir_D.Columns.Add(New DataColumn("Id", System.Type.GetType("System.String")))

        For i As Integer = 0 To Now.Year - 18 - 1950 '假設從1950開始算
            Bir_Y.Rows.Add(Bir_Y.NewRow())
            For j As Integer = 0 To 1
                Bir_Y.Rows(i)(j) = (i + 1950).ToString
            Next
        Next

       
        For i As Integer = 1 To 12
            Bir_M.Rows.Add(Bir_M.NewRow())
            For j As Integer = 0 To 1
                Dim Month As String = "0" + Convert.ToString(i)
                Bir_M.Rows(i - 1)(j) = Month.Substring(Month.Length - 2, 2)
            Next
        Next
        
        For i As Integer = 1 To 31
            Bir_D.Rows.Add(Bir_D.NewRow())
            For j As Integer = 0 To 1
                Dim DD As String = "0" + Convert.ToString(i)
                Bir_D.Rows(i - 1)(j) = DD.Substring(DD.Length - 2, 2)
            Next
        Next
        

        ddlYear.DataSource = Bir_Y
        ddlYear.DisplayMember = "Display"
        ddlYear.ValueMember = "Id"
        ddlMonth.DataSource = Bir_M
        ddlMonth.DisplayMember = "Display"
        ddlMonth.ValueMember = "Id"
        ddlDate.DataSource = Bir_D
        ddlDate.DisplayMember = "Display"
        ddlDate.ValueMember = "Id"
    End Sub

    Private Sub InsertData()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        If Not CheckData() Then
            Exit Sub
        End If

        '取得最新存領編號
        Dim ID As String = String.Empty
        Dim Sql As String = String.Empty
        Dim SerNum As String = String.Empty '流水號
        Dim oDT As DataTable = New DataTable



        '===========================取得最新流水號 Begin=======================================
        Sql = " SELECT ISNULL(MAX(Convert(int,substring(empID,2,7))),0) AS NewEmpID "
        Sql += " FROM KS_A_OHEM_O "

        SQLCmd.CommandText = Sql

        DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
        DataAdapterDGV.Fill(oDT)

        '判斷是否重設流水號
        If oDT.Rows.Count > 0 Then
            Dim SerNum_tmp As String = String.Empty

            SerNum_tmp = ("000000" + Convert.ToString(Convert.ToInt32(Convert.ToString(oDT.Rows(0).Item("NewEmpID"))) + 1))
            SerNum = SerNum_tmp.Substring(Len(SerNum_tmp) - 7, 7)

        Else
            SerNum = "0000001"
        End If
        '===========================取得最新流水號 END=======================================


        '===========================================寫入資料庫作業Begin===============================================

        Try
            SQLCmd.CommandText = String.Format(" INSERT INTO [KS_A_OHEM_O] ( " & _
                    "[empID]    ,[lastName],[birthDate],[sex],[mobile],[homeTel],[homeZip],[homeAddress],[email],[SaleGroupType],[startDate],[status],[remark],[AddDate],[AddUser]) " & _
             "VALUES ('{0}'     ,'{1}'      ,'{2}'     ,'{3}','{4}'   ,'{5}'    ,'{6}'    ,'{7}'        ,'{8}'  ,'{9}'          ,'{10}'     ,'1'     ,'{11}'  ,getdate(),'{12}') " _
             , "Z" + SerNum _
             , txtName.Text _
            , (ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDate.SelectedValue + " 00:00:00.000") _
             , Convert.ToInt32(ddlSex.SelectedIndex) - 1 _
             , txtMobile.Text _
             , txtTel.Text _
             , txtZip.Text _
             , txtAddress.Text _
             , txtEmail.Text _
             , ddlSaleGroupType.SelectedIndex _
             , DTstartDate.Value.ToShortDateString _
             , txtRemark.Text _
             , Login.LogonUserName)


            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("修改失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("成功!!", 64, "完成")

        A_OutSideEmpBasicDataList.MdiParent = MainForm
        A_OutSideEmpBasicDataList.Show()
        Me.Close()

        '===========================================寫入資料庫作業END===============================================
    End Sub

    Private Sub EditData()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        If Not CheckData() Then
            Exit Sub
        End If


        Dim sql As String = ""
        Dim status As String = String.Empty
        Dim termDate As String = ""

        If chbstatus.Checked Then
            status = "status = '0' "
            termDate = "termDate='" + DTtermDate.Value.ToShortDateString + "' "
        Else
            status = "status = '1' "
            termDate = "termDate=NULL "
        End If
        Try

            '===========================================修改資料庫作業Begin===============================================

            '修改主Table
            SQLCmd.CommandText = String.Format(" UPDATE [KS_A_OHEM_O] SET " & _
                "[lastName]='{0}',[birthDate]='{1}',[sex]='{2}',[mobile]='{3}',[homeTel]='{4}',[homeZip]='{5}',[homeAddress]='{6}',[email]='{7}',[SaleGroupType]='{8}'" & _
                ",[startDate]='{9}',{10},[remark]='{11}',[AlterDate]=getdate(),[AlterUser]='{12}',{13} " & _
                " WHERE EmpID='{14}' " _
         , txtName.Text _
         , (ddlYear.SelectedValue + "-" + ddlMonth.SelectedValue + "-" + ddlDate.SelectedValue + " 00:00:00.000") _
         , Convert.ToInt32(ddlSex.SelectedIndex) - 1 _
         , txtMobile.Text _
         , txtTel.Text _
         , txtZip.Text _
         , txtAddress.Text _
         , txtEmail.Text _
         , ddlSaleGroupType.SelectedIndex _
         , DTstartDate.Value.ToShortDateString _
         , status _
         , txtRemark.Text _
         , Login.LogonUserName _
         , termDate _
         , ID)

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("修改失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("修改成功!!", 64, "完成")


        A_OutSideEmpBasicDataList.MdiParent = MainForm
        A_OutSideEmpBasicDataList.Show()
        Me.Close()

        '===========================================寫入資料庫作業END===============================================
    End Sub
    Private Function CheckData() As Boolean
        If ddlSaleGroupType.SelectedIndex = 0 Then
            MsgBox("請選擇類型", 16, "錯誤")
            Return False
        End If

        If txtName.Text = "" Then
            MsgBox("請輸入姓名", 16, "錯誤")
            Return False
        End If

        If ddlSex.SelectedIndex = 0 Then
            MsgBox("請選擇性別", 16, "錯誤")
            Return False
        End If

        Return True
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Select Case Source
            Case "EDIT"
                EditData()
            Case "ADD"
                InsertData()
        End Select
    End Sub
End Class