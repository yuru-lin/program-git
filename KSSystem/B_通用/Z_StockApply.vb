Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class Z_StockApply

    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim ks2DataSetDGV As DataSet = New DataSet
    Public Source As String
    Public ID As String
    Public OrderType As String

    Private Sub Z_StockApply_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Select Case Source
            Case "ADD"
                Z_StockApplyList.MdiParent = MainForm
                Z_StockApplyList.Show()
        End Select

    End Sub

    Private Sub Z_StockApply_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        DocDueDate.MinDate = DateTime.Today.AddDays(-15)
        DocDueDate.Value = DateTime.Today

        'If Login.LoginType <> 2 Then
        '    SaveBtn.Enabled = False
        'End If

        SelectDescr()
        SelectItemU_P6cob()
        小單位T.Text = ""

        Select Case Source
            Case "EDIT"
                GetDGV1Data_Edit()
                SaveBtn.Text = "修改送出"
                SaveBtn.Enabled = True
            Case "ADD"
                GetDGV1Data()
                SaveBtn.Text = "送出申請"
                SaveBtn.Enabled = False '申請按鈕先不給按
            Case "EC"
                GetDGV1Data_EC()
                SaveBtn.Text = "送出申請"
                SaveBtn.Enabled = True
        End Select

        Select Case IDLog09
            Case "研發", "資訊"
                研發領用.Visible = True
            Case Else
                研發領用.Visible = False
        End Select

    End Sub
#Region "下拉式選單事件"

    Private Sub SelectDescr()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = " select Descr as '用途',IndexID as '編號' from UFD1 where [FieldID] = '53' and [TableID]='OIGE' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            DataAdapter = New SqlDataAdapter(sql, DBConn)
            DataAdapter.Fill(ksSelectDataSet, "ddlPurpose")

            ddlPurpose.DataSource = ksSelectDataSet.Tables("ddlPurpose")
            ddlPurpose.DisplayMember = "用途"

            ddlPurpose.SelectedIndex = -1
        End Using
    End Sub

    Private Sub SelectItemU_P6cob()
        Dim DataAdapter As SqlDataAdapter
        Dim ksSelectDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = " SELECT T0.[FldValue], T0.[Descr] FROM [UFD1] T0 WHERE T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' Order by T0.[IndexID] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter = New SqlDataAdapter(sql, DBConn)
        DataAdapter.Fill(ksSelectDataSet, "DT1")

        ItemU_P6cob.DataSource = ksSelectDataSet.Tables("DT1")
        ItemU_P6cob.DisplayMember = "Descr"


    End Sub

#End Region

#Region "按鈕動作"
    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click '新增項目

        If ItemCodeTxt.Text = "" Then
            MsgBox("項目編號未填!", 16, "錯誤")
            ItemCodeTxt.Focus()
            Exit Sub
        End If

        If ItemNameTxt.Text = "" Then
            MsgBox("項目名稱未填!", 16, "錯誤")
            ItemNameTxt.Focus()
            Exit Sub
        End If

        'If Quantity.Text = "" Or Convert.ToInt32(Quantity.Text) = 0 Then
        If Quantity.Text = "" Or Convert.ToDouble(Quantity.Text) = 0 Then
            MsgBox("項目訂購數量未填!", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT [ItemCode], ItemName FROM [OITM]  WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("輸入的項目編號有誤!", 16, "錯誤")
                ItemCodeTxt.Focus()
                Exit Sub
            End If

            Dim Type As String = ""

            Select Case ItemCodeTxt.Text.Substring(0, 2)
                Case "21"
                    Type = "其他品"
                Case "22"
                    Type = "其他品"
                Case "23"
                    Type = "其他品"
                Case "25"
                    If ItemCodeTxt.Text.Substring(3, 1) = "1" Or ItemCodeTxt.Text.Substring(3, 1) = "2" Then
                        Type = "電宰品"
                    ElseIf ItemCodeTxt.Text.Substring(3, 1) = "3" Then
                        Type = "加工品"
                    End If
                Case "52"
                    Type = "其他品"
                Case Else
                    Type = "其他品"
            End Select

            'If ItemCodeTxt.Text.Substring(0, 2) = "25" Then
            '    If ItemCodeTxt.Text.Substring(3, 1) = "1" Or ItemCodeTxt.Text.Substring(3, 1) = "2" Then
            '        Type = "電宰品"
            '    ElseIf ItemCodeTxt.Text.Substring(3, 1) = "3" Then
            '        Type = "加工品"
            '    End If
            'End If

            Dim Row As DataRow

            Row = ks1DataSetDGV.Tables("DT1").NewRow
            Row.Item("ProCode") = ItemCodeTxt.Text
            Row.Item("ProName") = ItemNameTxt.Text
            Row.Item("Num") = Quantity.Text
            'Row.Item("FldName") = ItemU_P6cob.Text
            If RB1.Checked = True Or RB2.Checked = True Then '電宰
                Row.Item("FldName") = ItemU_P6cob.Text
            Else
                Row.Item("FldName") = 小單位T.Text
            End If

            Row.Item("MEMO") = CommentsTxt.Text
            Row.Item("Type") = Type
            'Row.Item("Fldvalue") = ItemU_P6cob.SelectedIndex
            If RB1.Checked = True Or RB2.Checked = True Then '電宰
                Row.Item("Fldvalue") = ItemU_P6cob.SelectedIndex
            Else
                Row.Item("Fldvalue") = 0
            End If



            ks1DataSetDGV.Tables("DT1").Rows.Add(Row)

            ItemCodeTxt.Text = ""
            ItemNameTxt.Text = ""
            ItemU_P4Txt.Text = 0
            Quantity.Text = 0
            CommentsTxt.Text = ""
            小單位T.Text = ""

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

        SaveBtn.Enabled = True '開放按鈕
    End Sub

    Private Sub SearchBtn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn2.Click '查詢商品
        Dim sWhere_1 As String = String.Empty
        Dim sWhere_2 As String = String.Empty
        Dim sWhere_3 As String = String.Empty
        Dim sWhere_4 As String = String.Empty

        If DGV2.RowCount > 0 Then
            ks2DataSetDGV.Tables("DT1").Clear()
        End If

        If TextBox1.Text <> "" Then
            sWhere_1 = " AND T0.[ItemName] Like '%" & TextBox1.Text & "%' "
        End If

        If TextBox2.Text <> "" Then
            sWhere_2 = " AND T0.[ItemName] Like '%" & TextBox2.Text & "%'  "
        End If

        If TextBox3.Text <> "" Then
            sWhere_3 = " AND T0.[ItemName] Like '%" & TextBox3.Text & "%' "
        End If

        Dim sql As String = String.Empty
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'Select Case IDLog09
            '    Case "研發", "資訊", "品管"
            '        研發領用.Visible = True
            '    Case Else
            '        研發領用.Visible = False
            'End Select

            Select Case IDLog09
                '開放庫存為 0 可查詢
                Case "資訊", "品管", "總經理室"
                    sWhere_4 = ""
                Case Else
                    sWhere_4 = " AND T0.[OnHand] > 0 "
            End Select


            If RB1.Checked = True Then '電宰
                If 研發領用.Checked = False Then
                    sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.[ItemName] AS 'Dscription', T0.[OnHand], "
                    sql += "       T0.[SalPackUn] AS 'U_P4', T0.[SalPackMsr] AS 'U_P6'  "
                    sql += " FROM [OITM] T0  "
                    sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                    sql += "   AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2','5','6','7') "
                    'If IDLog09 = "總務" Or "09441801" = UCase(Login.LogonUserName) Then
                    If IDLog09 = "總務" Then
                    Else
                        sql += " AND T0.[ItemName] Not Like '%XXX%' "
                        sql += " AND T0.[ItemName] Not Like '%領改%' "
                        sql += " AND T0.[ItemName] Not Like '%004%' "
                        sql += " AND T0.[ItemName] Not Like '%-G%' "
                    End If
                    'sql += " AND T0.[OnHand] > 0 "
                    sql += sWhere_4
                    sql += sWhere_1
                    sql += sWhere_2
                    sql += sWhere_3
                Else
                    sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.ItemName AS 'Dscription', T0.[OnHand], "
                    sql += " T0.SalPackUn AS 'U_P4', T0.SalPackMsr AS 'U_P6'  "
                    sql += " FROM [OITM] T0  "
                    sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                    sql += " AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2','3','5','6','7') AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                    sql += " AND T0.[ItemName] Not Like '%領改%'   "
                    sql += " AND T0.[ItemCode] IN ('252110000034000','252120000034000','252130000034000','252140000034000','2521N0000034000','252210Z20004100','252220Z20004100','252230Z20004100','2521Q0000034000','2100060100041','2522Q0Z20004100') "
                End If
            End If

            If RB2.Checked = True Then '加工
                sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.[ItemName] AS 'Dscription', T0.[OnHand], "
                sql += "       T0.[SalPackUn] AS 'U_P4', T0.[SalUnitMsr] AS 'U_P6'  "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) = '25' "
                sql += " AND SUBSTRING(T0.[ItemCode],4,1) ='3' AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                sql += " AND  T0.[ItemName] Not Like '%領改%'   "
                'sql += " AND T0.[OnHand] > 0 "
                sql += sWhere_4
                sql += " AND (LEN(T0.[ItemCode]) = 15 OR LEN(T0.[ItemCode]) = 16) "
                sql += sWhere_1
                sql += sWhere_2
                sql += sWhere_3
            End If

            If RB3.Checked = True Then '其他
                sql = " SELECT T0.[ItemCode] AS 'ItemCode', T0.[ItemName] AS 'Dscription', T0.[OnHand], "
                sql += "       T0.[SalPackUn] AS 'U_P4', T0.[InvntryUom] AS 'U_P6'  "
                sql += " FROM [OITM] T0  "
                sql += " WHERE SUBSTRING(T0.[ItemCode],1,2) IN ('21','22','23','24','52') "
                sql += " AND T0.[ItemName] Not Like '%XXX%' "
                'sql += " AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2') AND T0.[ItemName] Not Like '%XXX%' AND T0.[ItemName] Not Like '%004%' AND T0.[ItemName] Not Like '%-G%' "
                'sql += " AND T0.[ItemName] Not Like '%領改%'   "
                'sql += " AND T0.[OnHand] > 0 "
                sql += sWhere_4
                sql += sWhere_1
                sql += sWhere_2
                sql += sWhere_3
            End If


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks2DataSetDGV, "DT1")

            DGV2.DataSource = ks2DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV2Display()
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click '按下送出申請
        If ddldepart.SelectedIndex = -1 Then
            MsgBox("請選擇申請部門!", 16, "錯誤")
            ddldepart.Focus()
            Exit Sub
        End If

        If ddlPurpose.SelectedValue Is Nothing Then
            MsgBox("請選擇領用用途!", 16, "錯誤")
            ddlPurpose.Focus()
            Exit Sub
        End If

        If DGV1.RowCount <= 0 Then
            MsgBox("無新增任何項目資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer

        oAns = MsgBox("確認要送出申請 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        '鎖住按鈕
        SaveBtn.Enabled = False

        Select Case Source
            Case "EDIT" '修改
                EditData()
            Case "ADD", "EC" '新增
                InsertData()
        End Select

        
    End Sub

    Private Sub InsertData()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn



        '取得最新存領編號
        Dim ID As String = String.Empty
        Dim Sql As String = String.Empty
        Dim SerNum As String = String.Empty '流水號
        Dim oDT As DataTable = New DataTable

        ID = Now.ToString("yyyyMMdd").Substring(2, 6)

        '===========================判斷該存領編號有無使用,取得最新流水號 Begin=======================================
        Sql = " SELECT TOP 1 ID "
        Sql += " FROM KS_Z_StockApply "
        Sql += " WHERE SUBSTRING([ID],1,6) = '" & ID & "' "
        Sql += " Order By ID Desc "
        'Sql += " Order By AddDate Desc "

        SQLCmd.CommandText = Sql

        DataAdapterDGV = New SqlDataAdapter(Sql, DBConn)
        DataAdapterDGV.Fill(oDT)

        '判斷是否重設流水號
        If oDT.Rows.Count > 0 Then
            Dim SerNum_tmp As String = String.Empty

            SerNum_tmp = ("00" + Convert.ToString(Convert.ToInt32(Convert.ToString(oDT.Rows(0).Item("ID")).Substring(6, 3)) + 1))
            SerNum = SerNum_tmp.Substring(Len(SerNum_tmp) - 3, 3)

        Else
            SerNum = "001"
        End If
        '===========================判斷該存領編號有無使用,取得最新流水號 END=======================================


        '===========================================寫入資料庫作業Begin===============================================

        '寫入主Table      20190528-增加[PrintCount]
        SQLCmd.CommandText = String.Format(" INSERT INTO [KS_Z_StockApply] ([ID],[DepartType] " & _
         ",[IndexID],[Examine],[MEMO],[AddUser],[PrintCount]) VALUES ('{0}','{1}','{2}','1','{3}','{4}','0') " _
         , ID + SerNum _
         , ddldepart.SelectedIndex _
         , ddlPurpose.SelectedValue(1) _
         , Comments2Txt.Text _
         , Login.LogonUserName)

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()


        '寫入明細Table
        Dim Type As Integer
        For i As Integer = 0 To DGV1.RowCount - 1



            'If DGV1.Rows(i).Cells("ProCode").Value.Substring(0, 2) = "25" Then
            '    If DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "1" Or DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "2" Then
            '        Type = 1
            '    ElseIf DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "3" Then
            '        Type = 2
            '    End If
            'End If

            Select Case DGV1.Rows(i).Cells("ProCode").Value.Substring(0, 2)
                Case "21", "22", "23", "52"
                    Type = 3
                Case "25"
                    If DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) Like "[1,2]" Then
                        Type = 1
                    ElseIf DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "3" Then
                        Type = 2
                    End If
                Case Else
                    Type = 3
            End Select

            SQLCmd.CommandText = String.Format(" INSERT INTO [KS_Z_StockApply_Detail] ([ID],[ProCode] " & _
             ",[ProName],[Num],[FldValue],[GetProDate],[MEMO],[Type]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') " _
             , ID + SerNum _
             , DGV1.Rows(i).Cells("ProCode").Value _
             , DGV1.Rows(i).Cells("ProName").Value _
             , DGV1.Rows(i).Cells("Num").Value _
             , DGV1.Rows(i).Cells("FldValue").Value _
             , DocDueDate.Value.ToShortDateString _
             , DGV1.Rows(i).Cells("MEMO").Value _
             , Type)

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Next

        MsgBox("存貨領用申請送出成功!!", 64, "完成")
        Z_ReportViewer.strPara(2) = ID + SerNum
        'ks1DataSetDGV.Tables("DT2") = ks1DataSetDGV.Tables("DT1").DataSet.Copy

        'Z_ReportViewer.dt.Clear()    20190528-註解掉
        Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT1").Copy
        PrintReport()
        'ks1DataSetDGV.Tables("DT1").Clear()    20190528-註解掉

        If Source = "EC" Then
            EC送出申請()
        End If
        'GetDGV1Data()

        '===========================================寫入資料庫作業END===============================================
    End Sub

    Private Sub EditData()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn




        Dim sql As String = ""
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            '===========================================搬移資料庫作業Begin===============================================
            'sql += "   INSERT INTO  KS_Z_StockApply_His "
            'sql += "   SELECT *, 'U', GETDATE(), '" + Login.LogonUserName + "' "
            'sql += "   FROM KS_Z_StockApply "
            'sql += "   WHERE ID='" + ID + "' "

            '20190528-修改
            sql += "   INSERT INTO  KS_Z_StockApply_His "
            sql += "   SELECT [ID], [DepartType], [IndexID], [Examine], [SendOutDate], [SendOutUser], [Reason], "
            sql += "   [DocNum], [MEMO], [AddDate], [AddUser], [AlterDate], [AlterUser], "
            sql += "   'U', GETDATE(), '" + Login.LogonUserName + "', "
            sql += "   [PrintCount], [PrintLastTime] "
            sql += "   FROM KS_Z_StockApply "
            sql += "   WHERE ID='" + ID + "' "

            sql += "   INSERT INTO  KS_Z_StockApply_Detail_His "
            sql += "   SELECT *, 'U', GETDATE(), '" + Login.LogonUserName + "' "
            sql += "   FROM KS_Z_StockApply_Detail "
            sql += "   WHERE ID='" + ID + "' "
            '===========================================搬移資料庫作業END=================================================

            '===========================================刪除資料庫作業Begin===============================================
            sql += "   DELETE FROM [KS_Z_StockApply_Detail] "
            sql += "   WHERE ID='" + ID + "' "
            '===========================================刪除資料庫作業END=================================================



            '===========================================修改資料庫作業Begin===============================================

            '修改主Table
            sql += String.Format(" UPDATE [KS_Z_StockApply] SET [DepartType]= '{0}', [IndexID]='{1}', AlterDate=GETDATE(), AlterUser='{2}', MEMO='{3}' " & _
             " WHERE ID='" + ID + "' " _
             , ddldepart.SelectedIndex _
             , ddlPurpose.SelectedValue(1) _
             , Login.LogonUserName _
             , Comments2Txt.Text)

           

            '寫入明細Table
            Dim Type As Integer
            For i As Integer = 0 To DGV1.RowCount - 1

                'If DGV1.Rows(i).Cells("ProCode").Value.Substring(0, 2) = "25" Then
                '    If DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "1" Or DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "2" Then
                '        Type = 1
                '    ElseIf DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "3" Then
                '        Type = 2
                '    End If
                'End If

                Select Case DGV1.Rows(i).Cells("ProCode").Value.Substring(0, 2)
                    Case "21", "22", "23", "52"
                        Type = 3
                    Case "25"
                        If DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) Like "[1,2]" Then
                            Type = 1
                        ElseIf DGV1.Rows(i).Cells("ProCode").Value.Substring(3, 1) = "3" Then
                            Type = 2
                        End If
                    Case Else
                        Type = 3
                End Select

                sql += String.Format(" INSERT INTO [KS_Z_StockApply_Detail] ([ID],[ProCode] " & _
                 ",[ProName],[Num],[FldValue],[GetProDate],[MEMO],[Type]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') " _
                 , ID _
                 , DGV1.Rows(i).Cells("ProCode").Value _
                 , DGV1.Rows(i).Cells("ProName").Value _
                 , DGV1.Rows(i).Cells("Num").Value _
                 , DGV1.Rows(i).Cells("FldValue").Value _
                 , DocDueDate.Value.ToShortDateString _
                 , DGV1.Rows(i).Cells("MEMO").Value _
                 , Type)
            Next

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()



            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("修改失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            SaveBtn.Enabled = True
            Exit Sub
        End Try

        MsgBox("修改成功!!", 64, "完成")


        Z_StockApplyList.MdiParent = MainForm
        Z_StockApplyList.Show()
        Z_ReportViewer.strPara(2) = ks1DataSetDGV.Tables("DT1").Rows(0).Item("ID").ToString()
        'Z_ReportViewer.dt.Clear()        20190528-註解掉
        Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT1").Copy
        PrintReport()
        Me.Close()

        '===========================================寫入資料庫作業END===============================================
    End Sub

    Private Sub DGV2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount <= 0 Then
            Exit Sub
        End If

        ItemCodeTxt.Text = DGV2.CurrentRow.Cells("ItemCode").Value
        ItemNameTxt.Text = DGV2.CurrentRow.Cells("Dscription").Value
        SelectItemCode()

        Dim U_P4s As Integer = DGV2.CurrentRow.Cells("U_P4").Value
        ItemU_P4Txt.Text = U_P4s 'DGV2.CurrentRow.Cells("U_P4").Value
        'ItemU_P6cob.Text = DGV2.CurrentRow.Cells("U_P6").Value
        If RB1.Checked = True Or RB2.Checked = True Then '電宰
            ItemU_P6cob.Text = DGV2.CurrentRow.Cells("U_P6").Value
        Else
            小單位T.Text = DGV2.CurrentRow.Cells("U_P6").Value
        End If



        Quantity.Text = 0      '數量
    End Sub

    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()

    End Sub

    Private Sub ItemNameTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()

    End Sub

    Private Sub SelectItemCode()

        If ItemCodeTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            If RB1.Checked = True Or RB2.Checked = True Then '電宰
                sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2','3') "
            Else
                sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) IN ('21','22','23','52') "
            End If


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                'sqlReader.Close()

                'SelectItem.getItemName = ItemNameTxt.Text
                'SelectItem.getItemCode = ItemCodeTxt.Text
                'SelectItem.Source = "ORDR"
                'SelectItem.MdiParent = MainForm
                'SelectItem.Show()
                MsgBox("輸入的項目編號有誤!", 16, "錯誤")
            Else
                ItemNameTxt.Text = sqlReader.Item("ItemName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemName()

        If ItemNameTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [ItemCode]  FROM [OITM] WHERE [ItemName] = '" & ItemNameTxt.Text & "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "ORDR"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemCodeTxt.Text = sqlReader.Item("ItemCode")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub
#End Region

#Region "取得DataGridView資料"
    Private Sub GetDGV1Data()

        If DGV1.RowCount > 0 Then
            Exit Sub
        Else
            If DGV1.RowCount <> 0 Then
                ks1DataSetDGV.Tables("DT1").Clear()
            End If
        End If

            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Using TransactionMonitor As New System.Transactions.TransactionScope


                sql = "    Select ProCode, ProName, Num, Fldvalue, '' as 'FldName', Type, ZSD.MEMO From KS_Z_StockApply_Detail ZSD "
                sql += "     Inner Join KS_Z_StockApply ZS On ZSD.ID=ZS.ID "
                sql += "    Where AddUser='" & Login.LogonUserName & "' and Examine='0'  "


                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql

                DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
                DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

                DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
                TransactionMonitor.Complete()
            End Using
            DGV1Display()
    End Sub
    '取得修改資料
    Private Sub GetDGV1Data_Edit()


        If DGV1.RowCount > 0 Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = "    Select ZS.ID, ZS.DepartType, ZS.IndexID, ZS.MEMO AS '用途備註', ProCode, ProName, Num, ZSD.Fldvalue, T0.Descr as 'FldName',  "    '20190528-刪除 '' AS MEMO 欄位
            sql += "    CASE [Type]  "
            sql += "   	    WHEN '1' THEN '電宰品' "
            sql += "    	WHEN '2' THEN '加工品' "
            sql += "    	WHEN '3' THEN '其他品' "
            sql += "    END AS 'Type', ZSD.MEMO, GetProDate From KS_Z_StockApply_Detail ZSD "
            sql += "    INNER JOIN KS_Z_StockApply ZS On ZSD.ID=ZS.ID  "
            sql += "    LEFT JOIN UFD1 T0 ON ZSD.Fldvalue=T0.FldValue AND T0.[TableID] = 'RDR1' AND T0.[FieldID] = '9' "
            sql += "    Where ZSD.ID='" + ID + "'  "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

        Try
            DocDueDate.Value = ks1DataSetDGV.Tables("DT1").Rows(0).Item("GetProDate")
        Catch ex As Exception
            DocDueDate.MinDate = DateTime.Today.AddDays(-15)
        End Try


        ddldepart.SelectedIndex = ks1DataSetDGV.Tables("DT1").Rows(0).Item("DepartType")
        ddlPurpose.SelectedIndex = ks1DataSetDGV.Tables("DT1").Rows(0).Item("IndexID")
        Comments2Txt.Text = ks1DataSetDGV.Tables("DT1").Rows(0).Item("用途備註")

        DGV1Display()
    End Sub
    '取得修改資料
    Private Sub GetDGV1Data_EC()

        If DGV1.RowCount > 0 Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = "    Select E.ID, ProtModel AS 'ProCode', ProName, '0' AS 'DepartType' ,  "
            sql += "    CASE OrderType When '4' Then '10' When '5' Then '9' When '6' Then '1' END AS 'IndexID',  "
            sql += "   	CASE ED.AtttibuteType When '0' Then '電宰品' When '1' Then '加工品' End AS 'Type', "
            sql += "    '提供給品牌人。'+E.MEMO AS '用途備註', "
            sql += "    CASE  ED.AtttibuteType When '0' Then T0.[SalPackMsr] When '1' Then T0.[SalUnitMsr] END AS 'FldName', "
            sql += "    CASE  ED.AtttibuteType When '0' Then U1.[FldValue] When '1' Then U2.[FldValue] END AS 'Fldvalue', "
            sql += "    ED.[Count] AS 'Num','' AS MEMO   "
            sql += "    From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] ED "
            sql += "    INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] E ON ED.ID=E.ID "
            sql += "    INNER JOIN OITM T0 ON ED.ProtModel=T0.ItemCode "
            sql += "    LEFT Join UFD1 U1 ON T0.[SalPackMsr]=U1.Descr AND U1.[TableID] = 'RDR1' AND U1.[FieldID] = '9' "
            sql += "    LEFT Join UFD1 U2 ON T0.[SalUnitMsr]=U2.Descr AND U2.[TableID] = 'RDR1' AND U2.[FieldID] = '9' "
            sql += "    Where E.ID='" + ID + "'  "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

        Try
            DocDueDate.Value = ks1DataSetDGV.Tables("DT1").Rows(0).Item("GetProDate")
        Catch ex As Exception
            DocDueDate.MinDate = DateTime.Today.AddDays(-15)
        End Try


        ddldepart.SelectedIndex = ks1DataSetDGV.Tables("DT1").Rows(0).Item("DepartType")
        ddlPurpose.SelectedIndex = ks1DataSetDGV.Tables("DT1").Rows(0).Item("IndexID")
        Comments2Txt.Text = ks1DataSetDGV.Tables("DT1").Rows(0).Item("用途備註")

        DGV1Display()
    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "ProCode"
                    column.HeaderText = "產品編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 150
                Case "ProName"
                    column.HeaderText = "產品名稱"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 180
                Case "Num"
                    column.HeaderText = " 數量"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    column.Width = 60
                Case "FldName"
                    column.HeaderText = "小單位(中文)"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                Case "Type"
                    column.HeaderText = "存貨類型"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case "MEMO"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 5
                    'column.ReadOnly = True
                Case "Fldvalue"
                    column.HeaderText = "小單位(代碼)"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                    column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next

        'Dim column0 As New DataGridViewCheckBoxColumn()
        'column0.Name = "CheckBoxes"
        'column0.HeaderText = "核選方塊測試"
        'column0.DisplayIndex = 0
        'DGV1.Columns.Add(column0)




    End Sub

    Private Sub DGV2Display()

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "產品編號"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                Case "Dscription"
                    column.HeaderText = "產品名稱"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                Case "U_P4"
                    column.HeaderText = "小單位數量"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.DefaultCellStyle.Format = "##.##"
                Case "U_P6"
                    column.HeaderText = "小單位"
                    column.DisplayIndex = 4
                    column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub
#End Region

    
    Private Sub PrintReport()
        '20150910 停止送出列印
        'Dim DepartType As String = String.Empty

        'Select Case ddldepart.SelectedIndex
        '    Case 0
        '        DepartType = "營業"
        '    Case 1
        '        DepartType = "生管"
        '    Case 2
        '        DepartType = "人事"
        '    Case 3
        '        DepartType = "倉庫"
        '    Case 4
        '        DepartType = "會計"
        '    Case 5
        '        DepartType = "採購"
        '    Case 6
        '        DepartType = "總經理室"
        '    Case 7
        '        DepartType = "研發"
        '    Case 8
        '        DepartType = "設計"
        '    Case 9
        '        DepartType = "品管"
        '    Case 10
        '        DepartType = "加工"
        '    Case 11
        '        DepartType = "資訊"
        'End Select

        'Z_ReportViewer.MdiParent = MainForm
        'Z_ReportViewer.Source = "StockApply"
        'Z_ReportViewer.strPara(0) = DepartType
        'Z_ReportViewer.strPara(1) = ddlPurpose.SelectedValue(0) + "," + Comments2Txt.Text


        ''Z_ReportViewer.dt = ks1DataSetDGV.Tables("DT1")

        'Z_ReportViewer.Show()

    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged, RB2.CheckedChanged, RB3.CheckedChanged

        If RB1.Checked = True Or RB2.Checked = True Then '電宰
            ItemU_P6cob.Visible = True
            小單位T.Visible = False
        Else
            ItemU_P6cob.Visible = False
            小單位T.Visible = True
        End If

    End Sub

    Private Sub EC送出申請()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim sql As String = String.Empty
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            '===========================================修改資料庫作業Begin===============================================

            sql = " UPDATE E SET E.[State]= '2', E.AlterDate=getdate(), E.AlterUser='" + Login.LogonUserName + "'  From [KaiShingEc].[dbo].[KS_Z_ECOrderDetail] E INNER JOIN [KaiShingEc].[dbo].[KS_Z_ECOrder] EC ON E.ID=EC.ID WHERE E.ID ='" + ID + "' "


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

        A_ECStockApplyList.MdiParent = MainForm
        A_ECStockApplyList.Show()
        Me.Close()
    End Sub

End Class