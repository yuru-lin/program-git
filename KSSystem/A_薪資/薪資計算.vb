Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns
Imports System.Linq

Public Class 薪資計算
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 薪資計算_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12)
        DGV1.DefaultCellStyle.Font = New Font("Arial", 12)
        DGV1.AlternatingRowsDefaultCellStyle.BackColor = Color.YellowGreen

        資料初始化()
    End Sub

    Private Sub 資料初始化()
        Dim yyyymm As Date
        yyyymm = DateTime.Parse(Now().ToString("yyyy-MM-01")).AddMonths(-1).ToShortDateString()
        月份.Text = Format(yyyymm, "yyyy/M")
    End Sub

    Private Sub 查詢1()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV1").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLAdd As String = ""

        SQLAdd = "  DECLARE	@return_value0 int "
        SQLAdd += "    EXEC	@return_value0 = [salary].[dbo].[calc_month_work] "
        SQLAdd += "         @q_ym = N'" & 月份.Text & "' "
        SQLAdd += "  SELECT	'人事計算' AS '種類','Return Value' = @return_value0, GETDATE() AS '時間' "

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = SQLAdd

            'SQLCmd.CommandType = CommandType.StoredProcedure
            'SQLCmd.CommandType.StoredProcedure()
            SQLCmd.ResetCommandTimeout()
            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 查詢2()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV1").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "  DECLARE	@return_value1 int "
            SQLCmd.CommandText += "    EXEC	@return_value1 = [salary].[dbo].[trans_overtime2] @q_ym = N'" & 月份.Text & "' "
            SQLCmd.CommandText += "  SELECT	'薪資計算1' AS '種類', 'Return Value' = @return_value1, GETDATE() AS '時間' "

            'SQLCmd.CommandType = CommandType.StoredProcedure
            SQLCmd.ResetCommandTimeout()
            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 查詢3()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV1").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "  DECLARE	@return_value2 int "
            SQLCmd.CommandText += "    EXEC	@return_value2 = [salary].[dbo].[calc_salary]    @q_ym = N'" & 月份.Text & "' "
            SQLCmd.CommandText += "  SELECT	'薪資計算2' AS '種類', 'Return Value' = @return_value2, GETDATE() AS '時間' "

            'SQLCmd.CommandType = CommandType.StoredProcedure
            'SQLCmd.ResetCommandTimeout()
            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        DGV1.AutoResizeColumns()

    End Sub
    Private Sub 全部計算Bn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 全部計算Bn.Click
        查詢1()
        查詢2()
        查詢3()
    End Sub

    Private Sub 人事計算Bn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 人事計算Bn.Click
        查詢1()
    End Sub

    Private Sub 薪資計算Bn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 薪資計算Bn.Click
        查詢2()
        查詢3()
    End Sub
End Class