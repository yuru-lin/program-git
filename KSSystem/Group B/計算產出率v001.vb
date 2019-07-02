Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class 計算產出率v001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Public Source As String

    Private Sub B_CalcThroughput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        If Source = "CalcThroughput" Then
            txtM03.Text = InputBox("請輸入製造單號：", "計算產出率")
            btnSave.Visible = False
        End If
    End Sub

    Private Sub txtM03_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtM03.TextChanged

        If Trim(txtM03.Text) = "" Then
            MsgBox("製造單號錯誤!", 16, "錯誤")
            Exit Sub
        End If

        Dim Ans As Boolean
        Ans = chkM03(txtM03.Text)
        If Ans = True Then
            GettxtData()
            GetdgvData()
        Else
            Exit Sub
        End If

    End Sub

    Private Function chkM03(ByVal M03 As String)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader2 As SqlDataReader
        Dim Ans As Boolean
        Using TransactionMonitor As New System.Transactions.TransactionScope
            Try
                If Source = "CalcThroughput" Then
                    sql = "select T0.M03 From [@Thtoughput] T0 where T0.M03 = '" & txtM03.Text & "'"
                Else
                    sql = "select T0.U_M03 From OWOR T0 where	T0.U_M03 = '" & txtM03.Text & "'"
                End If

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql

                sqlReader2 = SQLCmd.ExecuteReader
                If Not sqlReader2.HasRows() Then
                    Ans = False
                    If Source = "CalcThroughput" Then
                        MsgBox("chkM03失敗：該製單不在資料庫", 16, "錯誤")
                    Else
                        MsgBox("chkM03失敗：找不到製單", 16, "錯誤")
                    End If

                    sqlReader2.Close()
                Else
                    Dim rowCount As Integer = 0

                    Do While (sqlReader2.Read())
                        rowCount += 1
                    Loop

                    If rowCount = 1 Then
                        Ans = True
                    Else
                        Ans = False
                        MsgBox("chkM03失敗：多張製單" & rowCount, 16, "錯誤")
                    End If

                    sqlReader2.Close()
                End If
            Catch ex As Exception
                MsgBox("chkM03失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                Ans = False
                sqlReader2.Close()
            End Try
            TransactionMonitor.Complete()
        End Using

        Return Ans
    End Function

    Private Function chkM03_2(ByVal M03 As String)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader2 As SqlDataReader
        Dim Ans As Boolean
        Using TransactionMonitor As New System.Transactions.TransactionScope
            Try
                sql = "select T0.M03 From [@Thtoughput] T0 where T0.M03 = '" & txtM03.Text & "'"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                sqlReader2 = SQLCmd.ExecuteReader
                sqlReader2.Read()
                If Not sqlReader2.HasRows() Then
                    Ans = True
                    sqlReader2.Close()
                Else
                    Ans = False
                    'MsgBox("chkM03_2失敗：該製單已存在", 16, "錯誤")
                    sqlReader2.Close()

                    Dim oAns As Integer
                    oAns = MsgBox("製單已存在是否要更新?", MsgBoxStyle.YesNo, "確認更新")
                    If oAns = MsgBoxResult.Yes Then
                        'Yes執行區
                        AddData()
                    End If

                End If
            Catch ex As Exception
                MsgBox("chkM03_2失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                Ans = False
                sqlReader2.Close()
            End Try
            TransactionMonitor.Complete()
        End Using

        Return Ans
    End Function

    Private Sub GettxtData()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader1 As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            Try
                Select Case Source
                    Case "CalcThroughput"
                        sql = "Select * FROM [@Thtoughput] T0 where T0.M03 = '" & txtM03.Text & "'"
                    Case "QckUpdateOWOR"
                        sql = " SELECT T0.[U_M03], T2.[ItemName], T0.[U_m11], dbo.Get_addID(T0.[U_M11]) as '廠商簡稱', dbo.Get_AvgKG(T0.[U_M03]) as '平均重', CONVERT(NVARCHAR(10),T0.[DueDate],120) AS 'DueDate', T2.[ItemName], CAST(T0.[U_M07] as numeric(18,2) ) as 'U_M07', CAST(T0.[U_M12] as int) as 'U_M12', cast(T0.[U_M10] as numeric(18,2)) as 'U_M10', cast(T0.[U_M08] as int ) as 'U_M08', cast(T0.[U_M09] as int) as 'U_M09', dbo.Get_sumOf2nd(T0.[U_M03]) as '次級率', dbo.Get_sumOfHeart(T0.[U_M03]) as '心產生率', dbo.Get_sumOfGizzard(T0.[U_M03]) as '肫產生率', dbo.Get_sumOfTestis(T0.[U_M03]) as '佛產生率', dbo.Get_sumOfEgg(T0.[U_M03]) as '蛋單產生率', CASE isnull(T0.[U_M07],'0') when '0' then '0' else dbo.getRoundN((T0.[U_M08] + T0.[U_M09]) / T0.[U_M07] * 100,2) end '不良率', dbo.getRoundN( T0.[U_M10] - T0.[U_M07],2) as '磅差', dbo.Get_sumOfTotal(T0.[U_M03])as '合計', cast((dbo.Get_sumOfTotal(T0.[U_M03]) + T0.[U_M08] + T0.[U_M09]) - T0.[U_M12] as int) AS '隻數差異', dbo.getRoundN(ISNULL(T0.[U_M02],0),0) as 'U_M02' FROM [OWOR] T0 INNER JOIN [OITM] T2 on T0.[ItemCode] = T2.[ItemCode] WHERE T0.[U_M03] = '" & txtM03.Text & "'"
                    Case "QckUpdateOWOR2"
                        sql = " SELECT T0.[U_M03], T1.[ItemName], T0.[U_m11], dbo.Get_addID(T0.[U_M11]) as '廠商簡稱', CONVERT(NVARCHAR(10),T0.[DueDate],120) AS 'DueDate', T1.ItemName ,cast(T0.U_m12 as int) as  U_m12, cast(T0.U_M07 as numeric(18,2) ) as U_M07, dbo.Get_sumOfTotal(T0.U_M03)as 合計, dbo.getRoundN(ISNULL(T0.[U_M02],0),0) as U_M02 FROM OWOR T0 inner join OITM T1 on T0.itemcode = T1.itemcode where	T0.U_M03 = '" & txtM03.Text & "'"
                End Select

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql

                sqlReader1 = SQLCmd.ExecuteReader
                sqlReader1.Read()
                If Not sqlReader1.HasRows() Then
                    MsgBox("製造單號找不到資料!", 16, "錯誤")
                    sqlReader1.Close()
                    Exit Sub
                Else
                    Select Case Source
                        Case "CalcThroughput"
                            txtM11.Text = sqlReader1.Item("M11").ToString
                            txtItemName.Text = sqlReader1.Item("ItemName").ToString
                            txtAddID.Text = sqlReader1.Item("AddID").ToString
                            txtM07.Text = sqlReader1.Item("M07").ToString
                            txtAvgKG.Text = sqlReader1.Item("AvgKG").ToString
                            txtItem.Text = sqlReader1.Item("Item").ToString
                            txtM12.Text = sqlReader1.Item("M12").ToString
                            txtDueDate.Text = sqlReader1.Item("DueDate").ToString
                            txtSumOfTotal.Text = sqlReader1.Item("SumOfTotal").ToString
                            txtSumOfThroughput.Text = sqlReader1.Item("SumOfThroughput")
                            txtM10.Text = sqlReader1.Item("M10").ToString
                            txtDiffKG.Text = sqlReader1.Item("DiffKG").ToString
                            txtM08.Text = sqlReader1.Item("M08").ToString
                            txtM09.Text = sqlReader1.Item("M09").ToString
                            txtSumOfBad.Text = sqlReader1.Item("SumOfBad").ToString
                            txtDiffTotal.Text = sqlReader1.Item("DiffTotal").ToString
                            txtSumOf2nd.Text = sqlReader1.Item("SumOf2nd").ToString
                            txtSumOfHeart.Text = sqlReader1.Item("SumOfHeart").ToString
                            txtSumOfGizzard.Text = sqlReader1.Item("SumOfGizzard").ToString
                            txtSumOfTestis.Text = sqlReader1.Item("SumOfTestis").ToString
                            txtSumOfEgg.Text = sqlReader1.Item("SumOfEgg").ToString
                            'txtM02.Text = sqlReader1.Item("U_M02").ToString

                        Case "QckUpdateOWOR"
                            txtM11.Text = sqlReader1.Item("U_M11").ToString
                            txtItemName.Text = sqlReader1.Item("ItemName").ToString
                            txtAddID.Text = sqlReader1.Item("廠商簡稱").ToString
                            txtM07.Text = sqlReader1.Item("U_M07").ToString & "KG"
                            txtAvgKG.Text = sqlReader1.Item("平均重").ToString & "KG/隻"
                            txtItem.Text = sqlReader1.Item("ItemName").ToString
                            txtM12.Text = sqlReader1.Item("U_M12").ToString & "隻"
                            txtDueDate.Text = sqlReader1.Item("DueDate").ToString
                            txtSumOfTotal.Text = sqlReader1.Item("合計").ToString & "隻"
                            'txtSumOfThroughput.Text = sqlReader1.Item("U_m11")
                            txtM10.Text = sqlReader1.Item("U_M10").ToString & "KG"
                            txtDiffKG.Text = sqlReader1.Item("磅差").ToString & "KG"
                            txtM08.Text = sqlReader1.Item("U_M08").ToString & "隻"
                            txtM09.Text = sqlReader1.Item("U_M09").ToString & "隻"
                            txtSumOfBad.Text = sqlReader1.Item("不良率").ToString & "%"
                            txtDiffTotal.Text = sqlReader1.Item("隻數差異").ToString & "隻"
                            txtSumOf2nd.Text = sqlReader1.Item("次級率").ToString & "%"
                            txtSumOfHeart.Text = sqlReader1.Item("心產生率").ToString & "%"
                            txtSumOfGizzard.Text = sqlReader1.Item("肫產生率").ToString & "%"
                            txtSumOfTestis.Text = sqlReader1.Item("佛產生率").ToString & "%"
                            txtSumOfEgg.Text = sqlReader1.Item("蛋單產生率").ToString & "%"
                            txtM02.Text = sqlReader1.Item("U_M02").ToString & "箱"

                        Case "QckUpdateOWOR2"
                            txtM11.Text = sqlReader1.Item("U_M11").ToString
                            txtItemName.Text = sqlReader1.Item("ItemName").ToString
                            txtAddID.Text = sqlReader1.Item("廠商簡稱").ToString
                            txtM07.Text = sqlReader1.Item("U_M07").ToString & "KG"
                            txtItem.Text = sqlReader1.Item("ItemName").ToString
                            txtSumOfTotal.Text = sqlReader1.Item("合計").ToString & "隻"
                            'txtM12.Text = sqlReader1.Item("U_m12").ToString & "件"
                            txtM12.Text = sqlReader1.Item("U_M12").ToString & "隻"
                            txtDueDate.Text = sqlReader1.Item("DueDate").ToString
                            txtM02.Text = sqlReader1.Item("U_M02").ToString & "箱"

                    End Select

                    sqlReader1.Close()
                End If
            Catch ex As Exception
                MsgBox("GettxtData失敗：" & vbCrLf & ex.Message, 16, "錯誤")
                'sqlReader1.Close()
                Exit Sub
            End Try
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub GetdgvData()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Select Case Source
                Case "CalcThroughput"
                    sql = "Select * FROM [@Thtoughput1] T0 where T0.FI102 = '" & txtM03.Text & "'"
                Case "QckUpdateOWOR"
                    'sql = "SELECT FI102 ,case when (FI108 not Like '%心%') and (FI108 not Like '%肫%') and (FI108 not Like '%佛%') and (FI108 not Like '%蛋單%') and (FI108 not Like '%二級%') and (FI108 not Like '%次級%') then '000000000000000'  else FI107 end as 'ItemCode'  , case when (FI108 not Like '%心%') and (FI108 not Like '%肫%') and (FI108 not Like '%佛%') and (FI108 not Like '%蛋單%') and (FI108 not Like '%二級%') and (FI108 not Like '%次級%') then '主產品'  else FI108 end as 'ItemName' ,sum(CAST(FI118 as float)) as FI118, case f.U_M07 when '0' then '0' else dbo.getRoundN( sum(CAST(FI118 as float)) / f.U_M07 * 100 , 2 ) end as U_M07, sum(FI117) as SalPackUn, FI123 , dbo.getRoundN(ISNULL(f.[U_M02],0),0) as U_M02 FROM [@FinishItem1] left join [OWOR] as f ON [@FinishItem1].FI102 = f.U_M03 where  FI102 ='" & txtM03.Text & "' and FI103 <5  GROUP BY CASE WHEN (FI108 not Like '%心%') and (FI108 not Like '%肫%') and (FI108 not Like '%佛%') and (FI108 not Like '%蛋單%') and (FI108 not Like '%二級%') and (FI108 not Like '%次級%') then '000000000000000'  else FI107 end ,case when (FI108 not Like '%心%') and (FI108 not Like '%肫%') and (FI108 not Like '%佛%') and (FI108 not Like '%蛋單%') and (FI108 not Like '%二級%') and (FI108 not Like '%次級%') then '主產品'  else FI108 end  ,FI123, f.U_M07, FI102, f.U_M02 "
                    sql = " SELECT [FI102] ,case when ([FI108] not Like '%心%') and ([FI108] not Like '%肫%') and ([FI108] not Like '%佛%') and ([FI108] not Like '%蛋單%') and ([FI108] not Like '%二級%') and ([FI108] not Like '%次級%') then '000000000000000'  else [FI107] end as 'ItemCode'  ,case when ([FI108] not Like '%心%') and ([FI108] not Like '%肫%') and ([FI108] not Like '%佛%') and ([FI108] not Like '%蛋單%') and ([FI108] not Like '%二級%') and ([FI108] not Like '%次級%') then '主產品'  else [FI108] end as 'ItemName', SUM(CAST(FI118 as float)) as 'FI118', case f.[U_M07] when '0' then '0' else dbo.getRoundN(SUM(CAST([FI118] as float)) / f.[U_M07] * 100,2) end as 'U_M07', SUM([FI117]) as 'SalPackUn', [FI123], dbo.getRoundN(ISNULL(f.[U_M02],0),0) +'箱' as 'U_M02' FROM [@FinishItem1] left join [OWOR] as f ON [@FinishItem1].[FI102] = f.[U_M03] where  [FI102] = '" & txtM03.Text & "' and [FI103] <5  GROUP BY CASE WHEN ([FI108] not Like '%心%') and ([FI108] not Like '%肫%') and ([FI108] not Like '%佛%') and ([FI108] not Like '%蛋單%') and ([FI108] not Like '%二級%') and ([FI108] not Like '%次級%') then '000000000000000'  else [FI107] end ,case when ([FI108] not Like '%心%') and ([FI108] not Like '%肫%') and ([FI108] not Like '%佛%') and ([FI108] not Like '%蛋單%') and ([FI108] not Like '%二級%') and ([FI108] not Like '%次級%') then '主產品'  else [FI108] end  ,[FI123], f.[U_M07], [FI102], f.[U_M02] "
                Case "QckUpdateOWOR2"
                    sql = " SELECT [FI102] ,case when ([FI108] not Like '%油%') then '000000000000000' else [FI107] end as 'ItemCode', case when ([FI108] not Like '%油%') then '主產品'  else [FI108] end as 'ItemName' , sum(CAST([FI118] as float)) as 'FI118', case f.[U_M07] when '0' then '0' else dbo.getRoundN(SUM(CAST([FI118] as float)) / f.[U_M07] * 100,2) end as 'U_M07' ,SUM([FI117]) as SalPackUn, [FI123], dbo.getRoundN(ISNULL(f.[U_M02],0),0) +'箱' as 'U_M02' FROM  [@FinishItem1] left join [OWOR] as f ON [@FinishItem1].[FI102] = f.[U_M03] where  [FI102] ='" & txtM03.Text & "' and [FI103] <5  GROUP BY  case when ([FI108] not Like '%油%') then '000000000000000'  else [FI107] end ,case when ([FI108] not Like '%油%')  then '主產品' else [FI108] end, [FI123], f.[U_M07], [FI102], f.[U_M02] "
            End Select

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
            Exit Sub
        Else
            DGV1Display()
        End If

    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "存貨編號"
                    column.DisplayIndex = 0
                Case "ItemName"
                    column.HeaderText = "品名規格"
                    column.DisplayIndex = 1
                Case "FI118"
                    column.HeaderText = "數量(重)"
                    column.DisplayIndex = 2
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.00"
                Case "U_M07"
                    column.HeaderText = "產成率"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "0.00"
                Case "SalPackUn"
                    column.HeaderText = "包裝數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Case "FI123"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

        If Source = "CalcThroughput" Then

        Else
            Dim SumOfThroughput As Double = 0
            Dim SumOfThroughput2 As Double = 0
            For i As Integer = 0 To DGV1.RowCount - 1
                SumOfThroughput += DGV1.Rows(i).Cells("U_M07").Value
                DGV1.Rows(i).Cells("U_M07").Value = DGV1.Rows(i).Cells("U_M07").Value & "%"
                SumOfThroughput2 += DGV1.Rows(i).Cells("FI118").Value
                DGV1.Rows(i).Cells("FI118").Value = DGV1.Rows(i).Cells("FI118").Value
            Next
            txtSumOfThroughput.Text = SumOfThroughput & "%"
            txtSumOfThroughput2.Text = Format(SumOfThroughput2, "0.00") & "KG"
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Ans As Boolean
        Ans = chkM03_2(txtM03.Text)
        If Ans = True Then
            AddData()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub AddData()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            sql = "  DELETE FROM [@Thtoughput1] WHERE [FI102] = '" & txtM03.Text & "' "
            sql += " DELETE FROM [@Thtoughput]  WHERE [M03]   = '" & txtM03.Text & "' "
            sql += " INSERT INTO [@Thtoughput] VALUES('" & txtM03.Text & "', '" & txtM11.Text & "', '" & txtItemName.Text & "', '" & txtAddID.Text & "', '" & txtM07.Text & "', '" & txtAvgKG.Text & "', '" & txtItem.Text & "', '" & txtM12.Text & "', '" & txtDueDate.Text & "', '" & txtSumOfTotal.Text & "', '" & txtSumOfThroughput.Text & "', '" & txtM10.Text & "', '" & txtDiffKG.Text & "', '" & txtM08.Text & "', '" & txtM09.Text & "', '" & txtSumOfBad.Text & "', '" & txtDiffTotal.Text & "', '" & txtSumOf2nd.Text & "', '" & txtSumOfHeart.Text & "', '" & txtSumOfGizzard.Text & "', '" & txtSumOfTestis.Text & "', '" & txtSumOfEgg.Text & "') "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            For i As Integer = 0 To DGV1.RowCount - 1
                sql = " INSERT INTO [@Thtoughput1] VALUES " & "('" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("FI102").ToString & "', '" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("ItemCode").ToString & "',  '" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("ItemName").ToString & "', '" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("FI118").ToString & "', '" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("U_M07").ToString & "', '" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("SalPackUn").ToString & "', '" & ks1DataSetDGV.Tables("DT1").Rows(i).Item("FI123").ToString & "')"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("新增至資料庫已確認完成!", 64, "成功")
    End Sub

    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click

        btnSave.PerformClick()

        B_ReportViewer.MdiParent = MainForm
        B_ReportViewer.Source = "Throughput"
        B_ReportViewer.dt = ks1DataSetDGV.Tables("DT1")
        B_ReportViewer.strPara(0) = txtM03.Text
        B_ReportViewer.strPara(1) = txtM11.Text
        B_ReportViewer.strPara(2) = txtItemName.Text
        B_ReportViewer.strPara(3) = txtAddID.Text
        B_ReportViewer.strPara(4) = txtM07.Text
        B_ReportViewer.strPara(5) = txtAvgKG.Text
        B_ReportViewer.strPara(6) = txtItem.Text
        B_ReportViewer.strPara(7) = txtM12.Text
        B_ReportViewer.strPara(8) = txtDueDate.Text
        B_ReportViewer.strPara(9) = txtSumOfTotal.Text
        B_ReportViewer.strPara(10) = txtSumOfThroughput.Text
        B_ReportViewer.strPara(11) = txtM10.Text
        B_ReportViewer.strPara(12) = txtDiffKG.Text
        B_ReportViewer.strPara(13) = txtM08.Text
        B_ReportViewer.strPara(14) = txtM09.Text
        B_ReportViewer.strPara(15) = txtSumOfBad.Text
        B_ReportViewer.strPara(16) = txtDiffTotal.Text
        B_ReportViewer.strPara(17) = txtSumOf2nd.Text
        B_ReportViewer.strPara(18) = txtSumOfHeart.Text
        B_ReportViewer.strPara(19) = txtSumOfGizzard.Text
        B_ReportViewer.strPara(20) = txtSumOfTestis.Text
        B_ReportViewer.strPara(21) = txtSumOfEgg.Text
        B_ReportViewer.strPara(22) = txtSumOfThroughput2.Text
        B_ReportViewer.Show()

    End Sub


End Class