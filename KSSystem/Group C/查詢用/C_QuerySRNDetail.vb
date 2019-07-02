Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class C_QuerySRNDetail
    Dim dsPDAIn As New DataSet
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QuerySRNDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView0.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView2.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "Excel files(*.xls)|*.xls"    '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        ' if you don't want to sho the header row (first row) in the grid
        ' use 'HDR=NO' in the string

        Dim strSQL As String = "SELECT * FROM [Sheet1$]"
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        ' create data table
        Dim dTable As System.Data.DataTable = New System.Data.DataTable()
        dataAdapter.Fill(dTable)

        ' bind the datasource
        'dataBingingSrc.DataSource = dTable
        ' assign the dataBindingSrc to the DataGridView
        'DataGridView1.DataSource = dataBingingSrc
        locView.DataSource = dTable
        ' dispose used objects
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        'setdgvDisplay()

        joinAllTable()
    End Sub

    Private Sub joinAllTable()


        If locView.Rows.Count > 0 Then
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Dim sqlReader1 As SqlDataReader
            Dim dsPDAIn2 As New System.Data.DataTable
            Dim Q2 As Integer = 0
            Dim Name2 As DataColumn = New DataColumn("條碼")
            'declaring a column named Name
            Name2.DataType = System.Type.GetType("System.String")
            'setting the datatype for the column
            dsPDAIn2.Columns.Add(Name2)
            'adding the column to table
            PBar1.Minimum = 0
            PBar1.Maximum = locView.Rows.Count - 1

            '1.將EXCEL資料同步至資料庫

            For i As Integer = 0 To locView.RowCount - 1
                Try

                    'sql = "SELECT T0.U_M8  AS '製造單號',T0.ItemCode AS '存編',T1.ItemName AS '品名',T0.U_M1 AS '重量',T0.DistNumber AS '條碼',T0.MnfDate AS '製造日期',T0.ExpDate AS '有效日期',T0.U_M2 AS '儲位',T0.U_MC AS '客戶代碼'  FROM OSRN T0 INNER JOIN OITM T1 ON T0.ItemCode = T1.ItemCode WHERE T0.DistNumber ='" & locView.Rows(i).Cells("F1").FormattedValue & "' "
                    sql = "  SELECT '電宰' AS '品項', T0.[U_M8]  AS '製造單號', T0.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[U_M1] AS '重量', T0.[DistNumber] AS '條碼', T0.[MnfDate] AS '製造日期', T0.[ExpDate] AS '有效日期', T0.[U_M2] AS '儲位', T0.[U_MC] AS '客戶代碼' "
                    sql += "       , ISNULL(T3.[M_NO],'') AS 'G1', "
                    sql += "         ISNULL(CASE WHEN T0.[MnfDate]='2010.12.11' THEN '烏' "
                    sql += "                     WHEN T0.[MnfDate]='2009.11.06' THEN '土' "
                    sql += "                     WHEN T0.[MnfDate]='2009.12.05' THEN '土'     WHEN T0.[MnfDate]='2010.04.28' THEN '土'"
                    sql += "                     WHEN T0.[MnfDate]='2010.07.24' THEN '土'     WHEN T0.[MnfDate]='2010.07.26' THEN '土'"
                    sql += "                     WHEN T0.[MnfDate]='2010.08.02' THEN '土'     WHEN T0.[MnfDate]='2010.08.20' THEN '土'"
                    sql += "                     WHEN T0.[MnfDate]='2010.08.25' THEN '土'     WHEN T0.[MnfDate]='2010.08.31' THEN '土'"
                    sql += "                     WHEN T0.[MnfDate]='2010.09.06' THEN '土'     WHEN T0.[MnfDate]='2010.10.23' THEN '土'"
                    sql += "                     WHEN T0.[MnfDate]='2010.11.01' THEN '土' "
                    sql += "                     WHEN T0.[MnfDate]='2009.06.15' THEN '人土'   WHEN T0.[MnfDate]='2009.11.17' THEN '人土' "
                    sql += "                     WHEN T0.[MnfDate]='2010.07.23' THEN '人土'   WHEN T0.[MnfDate]='2010.07.27' THEN '人土' "
                    sql += "                     WHEN T0.[MnfDate]='2010.10.14' THEN '白露花' WHEN T0.[MnfDate]='2010.10.26' THEN '白露花' "
                    sql += "                     ELSE NULL END,'') AS 'G2' "
                    sql += "   FROM [OSRN] T0 INNER JOIN [OITM]       T1 ON T0.[ItemCode] = T1.[ItemCode] "
                    sql += "                  LEFT  JOIN [z_format_G] T3 ON T0.[U_M8]     = T3.[M_NO] "
                    sql += "  WHERE T0.[DistNumber] = '" & locView.Rows(i).Cells("F1").FormattedValue & "' "
                    sql += "  UNION  "
                    sql += " SELECT '加工' AS '品項', T0.[U_M8]  AS '製造單號', T0.[ItemCode] AS '存編', T1.[ItemName] AS '品名', T0.[U_M1] AS '重量', T0.[DistNumber] AS '條碼', T0.[MnfDate] AS '製造日期', T0.[ExpDate] AS '有效日期', T0.[U_M2] AS '儲位', T0.[U_MC] AS '客戶代碼' "
                    sql += "       , '' AS 'G1', '' AS 'G2' "
                    sql += "   FROM [OBTN] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
                    sql += "  WHERE T0.[DistNumber] = '" & locView.Rows(i).Cells("F1").FormattedValue & "' "

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql

                    sqlReader1 = SQLCmd.ExecuteReader
                    sqlReader1.Read()

                    If sqlReader1.HasRows() Then
                        sqlReader1.Close()
                        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
                        DataAdapter1.Fill(ks1DataSet, "DT1")
                    Else
                        sqlReader1.Close()

                        Q2 = Q2 + 1
                        Dim Row(Q2) As DataRow
                        Row(Q2) = dsPDAIn2.NewRow
                        Row(Q2).Item("條碼") = locView.Rows(i).Cells("F1").FormattedValue
                        dsPDAIn2.Rows.Add(Row(Q2))

                    End If

                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                    End
                End Try

                PBar1.Value = i
            Next

            If Q2 > 0 Then
                Btn2.Enabled = True
            End If

            DataGridView0.DataSource = ks1DataSet.Tables("DT1")
            DataGridView2.DataSource = dsPDAIn2
            lb0.Text = DataGridView0.RowCount
            lb2.Text = DataGridView2.RowCount

            DataGridView0.AutoResizeColumns()
            If DataGridView0.RowCount > 0 Then
                Btn0.Enabled = True
            End If

        End If

    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        DataToExcel(DataGridView0, "")
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        DataToExcel(DataGridView2, "")
    End Sub
End Class