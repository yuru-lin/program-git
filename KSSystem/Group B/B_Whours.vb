Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_Whours
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet



    Private Sub B_Whours_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    '----查詢基本資料

    'Dim RB11.Checked = "1"




    Private Sub SQLPDGV1Display()
        '清空DGV_IN內容
        If DGV_IN.RowCount > 0 Then
            ks1DataSetDGV.Tables("PDT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Dim jobType
            Dim jobType2

            If RB31.Checked Then
                jobType = "1"
            Else
                If RB32.Checked Then
                    jobType = "2"
                Else
                    jobType = "3"
                End If
            End If

            If RB41.Checked Then
                jobType2 = "1"
            Else
                jobType2 = "2"
            End If

            sql = "   SELECT [ItemName], [ItemCode]"
            sql += "    FROM [OITM]"
            sql += "   WHERE ([ItemCode] Like '24%' or [ItemCode] Like '25%') AND "
            sql += "          SUBSTRING([ItemCode],3,1) in ('" & jobType & "') AND "
            sql += "          SUBSTRING([ItemCode],4,1) in ('" & jobType2 & "') "
            sql += "ORDER BY 2 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "PDT1")
            DGV_IN.DataSource = ks1DataSetDGV.Tables("PDT1")
            TransactionMonitor.Complete()

            DGV_IN.AutoResizeColumns()

            DGV_IN.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV_IN.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV_IN.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SQLPDGV1Display()
    End Sub
End Class