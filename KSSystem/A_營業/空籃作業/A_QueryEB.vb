Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class A_QueryEB    
    Dim ksDataSet As DataSet = New DataSet
    Private Sub A_QueryEB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        SelectCarDr()
    End Sub

    Private Sub SelectCarDr()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet1 As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim X As Integer

        sql = "SELECT T0.[lastName] FROM OHEM T0  INNER JOIN HEM6 T1 ON T0.empID = T1.empID where(T1.[roleID] = 1 And T0.status = 1) union all  select T0.cardname from OCRD T0 where T0.QryGroup20='Y'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet1, "DT1")

        U_CarDr1.DataSource = ksDataSet1.Tables("DT1")
        U_CarDr1.DisplayMember = "lastName"
        U_CarDr1.ValueMember = "lastName"

    End Sub

    Private Sub SelectType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectType.SelectedIndexChanged
        If DGV1.RowCount > 0 Then
            ksDataSet.Clear()
        End If
        Select Case SelectType.SelectedIndex
            Case "0"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = True
                U_CarDr1.Enabled = True
            Case "1"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = False
                U_CarDr1.Enabled = False
            Case "2"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = True
                U_CarDr1.Enabled = True
            Case "3"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = True
                U_CarDr1.Enabled = True
            Case "4"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = False
                U_CarDr1.Enabled = False
            Case "5"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = False
                U_CarDr1.Enabled = False
            Case "6"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = True
                U_CarDr1.Enabled = True
            Case "7"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = True
                U_CarDr1.Enabled = True
            Case "8"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = False
                CheckBox2.Enabled = True
                CardCode.Enabled = True
                CheckBox3.Enabled = False
                U_CarDr1.Enabled = False
            Case "9"
                CheckBox1.Enabled = True
                FromDate.Enabled = True
                ToDate.Enabled = True
                CheckBox2.Enabled = True
                CheckBox2.Checked = True
                CardCode.Enabled = True
                CheckBox3.Enabled = False
                U_CarDr1.Enabled = False
        End Select

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If DGV1.RowCount > 0 Then
            ksDataSet.Clear()
        End If
        Select Case SelectType.SelectedIndex
            Case "0"
                OutDetail()
            Case "1"
                OutStatistic()
            Case "2"
                InDetail()
            Case "3"
                InStatistic()
            Case "4"
                AdjustDetail()
            Case "5"
                AdjustStatistic()
            Case "6"
                CarDrDetail()
            Case "7"
                CarDrStatistic()
            Case "8"
                EBStatistic()
            Case "9"
                EBStatement()
        End Select
    End Sub

    Private Sub OutDetail()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [DocDueDate] as '日期',[DocNum] as '單號',[CardCode] as '客戶編號',[AddID] as '客戶簡稱',[U_CarDr1] as '司機',[U_N2] as '數量' FROM [@EBout] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDueDate] >='" & FromDate.Value.Date & "' and  [DocDueDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            If CheckBox3.Checked = True Then
                sql += " and [U_CarDr1] ='" & U_CarDr1.Text & "'"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "OutDetail")
            DGV1.DataSource = ksDataSet.Tables("OutDetail")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub OutStatistic()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [CardCode] as '客戶編號',[AddID] as '客戶簡稱',sum([U_N2]) as '發出數量' FROM [@EBout] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDueDate] >='" & FromDate.Value.Date & "' and  [DocDueDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            sql += " GROUP BY [CardCode],[AddID]"

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "OutStatistic")
            DGV1.DataSource = ksDataSet.Tables("OutStatistic")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub InDetail()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [DocDate] as '日期',[DocNum] as '單號',[CardCode] as '客戶編號',[AddID] as '客戶簡稱',[U_CarDr1] as '司機',[InNum] as '數量',[Bonus] as '特殊獎金',[Descr] as '說明' FROM [@EBin] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDate] >='" & FromDate.Value.Date & "' and  [DocDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            If CheckBox3.Checked = True Then
                sql += " and [U_CarDr1] ='" & U_CarDr1.Text & "'"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "InDetail")
            DGV1.DataSource = ksDataSet.Tables("InDetail")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub InStatistic()
        Dim DataAdapter1 As SqlDataAdapter
        ' Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [CardCode] as '客戶編號',[AddID] as '客戶簡稱',[U_CarDr1] as '司機',sum([InNum]) as '數量' FROM [@EBin] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDate] >='" & FromDate.Value.Date & "' and  [DocDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            If CheckBox3.Checked = True Then
                sql += " and [U_CarDr1] ='" & U_CarDr1.Text & "'"
            End If

            sql += " GROUP BY [CardCode],[AddID],[U_CarDr1]"
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "InStatistic")
            DGV1.DataSource = ksDataSet.Tables("InStatistic")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub AdjustDetail()
        Dim DataAdapter1 As SqlDataAdapter
        ' Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [DocNum] as '單號',[DocDate] as '日期',[CardCode] as '客戶編號',[AddID] as '客戶簡稱', [IncDec] as '增減',[AmtNum] as '數量',[Descr] as '說明' FROM [@EBadjust] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDate] >='" & FromDate.Value.Date & "' and  [DocDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "AdjustDetail")
            DGV1.DataSource = ksDataSet.Tables("AdjustDetail")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub AdjustStatistic()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [CardCode] as '客戶編號',[AddID] as '客戶簡稱',case isnull(sum(case [IncDec] when '增加' then [AmtNum]  end),0) when 0 then 0 else sum(case [IncDec] when '增加' then [AmtNum]  end) end as '增加', case isnull(sum(case [IncDec] when '減少' then [AmtNum] end),0) when 0 then 0 else sum(case [IncDec] when '減少' then [AmtNum] end) end as '減少',((case isnull(sum(case [IncDec] when '增加' then [AmtNum]  end),0) when 0 then 0 else sum(case [IncDec] when '增加' then [AmtNum]  end) end) - (case isnull(sum(case [IncDec] when '減少' then [AmtNum] end),0) when 0 then 0 else sum(case [IncDec] when '減少' then [AmtNum] end) end)) as '調整合計' FROM [dbo].[@EBadjust] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDate] >='" & FromDate.Value.Date & "' and  [DocDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            sql += "GROUP BY [CardCode],[AddID]"

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "AdjustStatistic")
            DGV1.DataSource = ksDataSet.Tables("AdjustStatistic")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub CarDrDetail()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [DocDate] as '日期',[DocNum] as '單號',[CardCode] as '客戶編號',[AddID] as '客戶簡稱',[U_CarDr1] as '司機',[InNum] as '數量',[Bonus] as '特殊獎金',[Descr] as '說明' FROM [@EBin] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDate] >='" & FromDate.Value.Date & "' and  [DocDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            If CheckBox3.Checked = True Then
                sql += " and [U_CarDr1] ='" & U_CarDr1.Text & "'"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "CarDrDetail")
            DGV1.DataSource = ksDataSet.Tables("CarDrDetail")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub CarDrStatistic()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT [U_CarDr1] as '司機',[CardCode] as '客戶編號',[AddID] as '客戶簡稱',sum([InNum]) as '數量' FROM [@EBin] WHERE sid > 0  "

            If CheckBox1.Checked = True Then
                sql += " and [DocDate] >='" & FromDate.Value.Date & "' and  [DocDate] <='" & ToDate.Value.Date & "'"
            End If

            If CheckBox2.Checked = True Then
                sql += " and [CardCode] ='" & CardCode.Text & "'"
            End If

            If CheckBox3.Checked = True Then
                sql += " and [U_CarDr1] ='" & U_CarDr1.Text & "'"
            End If

            sql += " GROUP BY [U_CarDr1],[CardCode],[AddID]"
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "CarDrStatistic")
            DGV1.DataSource = ksDataSet.Tables("CarDrStatistic")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub EBStatistic()
        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim FromDates As Date
        Dim CCode As String
        Try

            If CheckBox1.Checked = True Then
                FromDates = FromDate.Value.Date
            Else
                FromDates = Today.Date
            End If

            If CheckBox2.Checked = True Then
                CCode = CardCode.Text
            Else
                CCode = ""
            End If

            sql = "exec L20110502A '" & FromDates & "' , '" & CCode & "' "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "EBStatistic")
            DGV1.DataSource = ksDataSet.Tables("EBStatistic")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub EBStatement()
        If CardCode.Text = "" Then
            MsgBox("客戶編號為必填!請輸入客編!", 16, "錯誤")
            Exit Sub
        End If

        Dim DataAdapter1 As SqlDataAdapter
        'Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim CCode As String = CardCode.Text
        Try
            sql = "exec L20110502B '" & FromDate.Value.Date & "' , '" & ToDate.Value.Date & "', '" & CCode & "' "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "EBStatement")
            DGV1.DataSource = ksDataSet.Tables("EBStatement")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try
        DGV1.AutoResizeColumns()
    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub btnToReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToReport.Click
        If SelectType.SelectedIndex = -1 Then
            Exit Sub
        End If

        If DGV1.RowCount <= 0 Then
            Exit Sub
        End If

        A_ReportViewer.MdiParent = MainForm

        Select Case SelectType.SelectedIndex
            Case "0"
                A_ReportViewer.Source = "OutDetail"
                A_ReportViewer.dt = ksDataSet.Tables("OutDetail")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "1"
                A_ReportViewer.Source = "OutStatistic"
                A_ReportViewer.dt = ksDataSet.Tables("OutStatistic")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "2"
                A_ReportViewer.Source = "InDetail"
                A_ReportViewer.dt = ksDataSet.Tables("InDetail")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "3"
                A_ReportViewer.Source = "InStatistic"
                A_ReportViewer.dt = ksDataSet.Tables("InStatistic")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "4"
                A_ReportViewer.Source = "AdjustDetail"
                A_ReportViewer.dt = ksDataSet.Tables("AdjustDetail")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "5"
                A_ReportViewer.Source = "AdjustStatistic"
                A_ReportViewer.dt = ksDataSet.Tables("AdjustStatistic")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "6"
                A_ReportViewer.Source = "CarDrDetail"
                A_ReportViewer.dt = ksDataSet.Tables("CarDrDetail")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "7"
                A_ReportViewer.Source = "CarDrStatistic"
                A_ReportViewer.dt = ksDataSet.Tables("CarDrStatistic")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
            Case "8"               
                A_ReportViewer.Source = "EBStatistic"
                A_ReportViewer.dt = ksDataSet.Tables("EBStatistic")
            Case "9"
                A_ReportViewer.Source = "EBStatement"
                A_ReportViewer.dt = ksDataSet.Tables("EBStatement")
                A_ReportViewer.strPara(0) = FromDate.Value.Date
                A_ReportViewer.strPara(1) = ToDate.Value.Date
        End Select

        A_ReportViewer.Show()

    End Sub
End Class