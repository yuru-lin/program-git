Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 排程顯示V100
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet


    Private Sub 排程顯示_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 時段()
     
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '排程廠商All()

        If Floor.SelectedIndex <> -1 Then
            排程All()
        Else
            MsgBox("未選樓層")
        End If

    End Sub

    'Private Sub 排程廠商All()
    '    If DGV1.RowCount > 0 Then : DataSetDGV.Tables("TDT1").Clear() : End If

    '    Dim sql As String
    '    Dim DBConn As SqlConnection = Login.DBConn
    '    Dim SQLCmd As SqlCommand = New SqlCommand
    '    Using TransactionMonitor As New System.Transactions.TransactionScope

    '        sql = "  DECLARE @a VARCHAR(10) "
    '        sql += " DECLARE @b VARCHAR(10) "
    '        sql += " SET NOCOUNT ON "
    '        sql += " SET @a = '2016-01-01' "
    '        sql += " SET @b = '1' "
    '        sql += " SELECT DISTINCT [廠商],'' AS '0630','' AS '0700','' AS '0730','' AS '0800','' AS '0830','' AS '0900','' AS '0930' "
    '        sql += "   FROM [TT_KaiShing].[dbo].[生產排程] "
    '        sql += "  WHERE [日期] = @a AND [樓層] = @b ORDER BY 1 "

    '        SQLCmd.Connection = DBConn
    '        SQLCmd.CommandText = sql

    '        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
    '        DataAdapterDGV.Fill(DataSetDGV, "TDT1")
    '        DGV1.DataSource = DataSetDGV.Tables("TDT1")
    '        TransactionMonitor.Complete()

    '        DGV1.Refresh()
    '        DGV1.AutoResizeColumns()

    '        DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
    '        DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
    '        DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

    '    End Using

    'End Sub

    Private Sub 排程All()
        If DGV2.RowCount > 0 Then : DataSetDGV.Tables("TDT2").Clear() : End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "exec z_SPdataAll2 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "
            'sql = "exec z_SPdataAll3 '2016-01-01' , '1' "
            sql = "exec z_SPdataAll3 '" & dateDocDate.Value.Date & "' , '" & Floor.SelectedIndex & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "TDT2")
            DGV2.DataSource = DataSetDGV.Tables("TDT2")
            TransactionMonitor.Complete()

            DGV2.Refresh()
            'DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'Label28.Text = Floor.Text
        'Label27.Text = TimeOfDay.ToShortTimeString
        查詢單據_Play()
        MsgBox("查詢完成")

    End Sub

    Private Sub 查詢單據_Play()
        '--載入資料畫面

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                'Case "草稿" : column.HeaderText = "草稿" : column.DisplayIndex = 0 : column.Frozen = True
                'Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Frozen = True
                'Case "提單" : column.HeaderText = "提單" : column.DisplayIndex = 2 : column.Frozen = False : column.Visible = False
                'Case "備註" : column.HeaderText = "備註" : column.DisplayIndex = 3


                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0 : column.Frozen = True
                Case "客戶" : column.HeaderText = "客戶" : column.DisplayIndex = 1 : column.Frozen = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2 : column.Frozen = True
                Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 3 : column.Frozen = True
                    'Case "0630" : column.HeaderText = "0630" : column.DisplayIndex = 4
                    'Case "0700" : column.HeaderText = "0700" : column.DisplayIndex = 5
                    'Case "0730" : column.HeaderText = "0730" : column.DisplayIndex = 6
                    'Case "0800" : column.HeaderText = "0800" : column.DisplayIndex = 7
                    'Case "0830" : column.HeaderText = "0830" : column.DisplayIndex = 8
                    'Case "0900" : column.HeaderText = "0900" : column.DisplayIndex = 9
                    'Case "0930" : column.HeaderText = "0930" : column.DisplayIndex = 10
                    'Case "1000" : column.HeaderText = "1000" : column.DisplayIndex = 11
                    'Case "1030" : column.HeaderText = "1030" : column.DisplayIndex = 12
                    'Case "1100" : column.HeaderText = "1100" : column.DisplayIndex = 13
                    'Case "1130" : column.HeaderText = "1130" : column.DisplayIndex = 14
                    'Case "1200" : column.HeaderText = "1200" : column.DisplayIndex = 15
                    'Case "1230" : column.HeaderText = "1230" : column.DisplayIndex = 16
                    'Case "1300" : column.HeaderText = "1300" : column.DisplayIndex = 17
                    'Case "1330" : column.HeaderText = "1330" : column.DisplayIndex = 18
                    'Case "1400" : column.HeaderText = "1400" : column.DisplayIndex = 19
                    'Case "1430" : column.HeaderText = "1430" : column.DisplayIndex = 20
                    'Case "1500" : column.HeaderText = "1500" : column.DisplayIndex = 21
                    'Case "1530" : column.HeaderText = "1530" : column.DisplayIndex = 22
                    'Case "1600" : column.HeaderText = "1600" : column.DisplayIndex = 23
                    'Case "1630" : column.HeaderText = "1630" : column.DisplayIndex = 24
                    'Case "1700" : column.HeaderText = "1700" : column.DisplayIndex = 25
                    'Case "1730" : column.HeaderText = "1730" : column.DisplayIndex = 26
                    'Case "1800" : column.HeaderText = "1800" : column.DisplayIndex = 27
                    'Case "1830" : column.HeaderText = "1830" : column.DisplayIndex = 28
                    'Case "1900" : column.HeaderText = "1900" : column.DisplayIndex = 29
                    'Case "1930" : column.HeaderText = "1930" : column.DisplayIndex = 30
                    'Case "2000" : column.HeaderText = "2000" : column.DisplayIndex = 31
                    'Case "2030" : column.HeaderText = "2030" : column.DisplayIndex = 32
                    'Case "2100" : column.HeaderText = "2100" : column.DisplayIndex = 33
                    'Case "2130" : column.HeaderText = "2130" : column.DisplayIndex = 34
                    '								
                Case Else
                    'column.Visible = False
            End Select


        Next

        DGV2.AutoResizeColumns()

    End Sub



End Class