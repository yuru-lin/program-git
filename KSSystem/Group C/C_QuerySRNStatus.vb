Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class C_QuerySRNStatus
    Dim dsPDAIn As New DataSet
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QuerySRNStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView0.ContextMenuStrip = MainForm.ContextMenuStrip1
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
        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

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
            Dim sql As String = ""
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Dim sqlReader1 As SqlDataReader
            Dim dsPDAIn0 As New DataTable : Dim dsPDAIn1 As New DataTable : Dim dsPDAIn2 As New DataTable
            Dim Q0 As Integer = 0 : Dim Q1 As Integer = 0 : Dim Q2 As Integer = 0

            Dim Name01 As DataColumn = New DataColumn("存編") : Dim Name02 As DataColumn = New DataColumn("品名") : Dim Name03 As DataColumn = New DataColumn("條碼") : Dim Name04 As DataColumn = New DataColumn("數量")
            Dim Name11 As DataColumn = New DataColumn("存編") : Dim Name12 As DataColumn = New DataColumn("品名") : Dim Name13 As DataColumn = New DataColumn("條碼") : Dim Name14 As DataColumn = New DataColumn("數量")
            Dim Name21 As DataColumn = New DataColumn("存編") : Dim Name22 As DataColumn = New DataColumn("品名") : Dim Name23 As DataColumn = New DataColumn("條碼") : Dim Name24 As DataColumn = New DataColumn("數量")
            'declaring a column named Name

            Name01.DataType = System.Type.GetType("System.String") : Name02.DataType = System.Type.GetType("System.String") : Name03.DataType = System.Type.GetType("System.String") : Name04.DataType = System.Type.GetType("System.String")
            Name11.DataType = System.Type.GetType("System.String") : Name12.DataType = System.Type.GetType("System.String") : Name13.DataType = System.Type.GetType("System.String") : Name14.DataType = System.Type.GetType("System.String")
            Name21.DataType = System.Type.GetType("System.String") : Name22.DataType = System.Type.GetType("System.String") : Name23.DataType = System.Type.GetType("System.String") : Name24.DataType = System.Type.GetType("System.String")
            'setting the datatype for the column

            dsPDAIn0.Columns.Add(Name01) : dsPDAIn0.Columns.Add(Name02) : dsPDAIn0.Columns.Add(Name03) : dsPDAIn0.Columns.Add(Name04)
            dsPDAIn1.Columns.Add(Name11) : dsPDAIn1.Columns.Add(Name12) : dsPDAIn1.Columns.Add(Name13) : dsPDAIn1.Columns.Add(Name14)
            dsPDAIn2.Columns.Add(Name21) : dsPDAIn2.Columns.Add(Name22) : dsPDAIn2.Columns.Add(Name23) : dsPDAIn2.Columns.Add(Name24)
            'adding the column to table

            PBar1.Minimum = 0
            PBar1.Maximum = locView.Rows.Count - 1

            '1.將EXCEL資料同步至資料庫

            For i As Integer = 0 To locView.RowCount - 1
                Try

                    Select Case locView.Rows(i).Cells("F1").Value
                        Case "1"
                            'sql = "SELECT  dbo.OSRN.DistNumber, dbo.OSRN.U_M2, dbo.OSRQ.Quantity FROM dbo.OSRN inner join dbo.OSRQ on dbo.OSRQ.ItemCode = dbo.OSRN.ItemCode and OSRQ.SysNumber = OSRN.SysNumber where osrn.DistNumber = '" & locView.Rows(i).Cells("F2").FormattedValue & "' order by dbo.OSRQ.Quantity desc"
                            sql = "    SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T2.[Quantity]"
                            sql += "     FROM [OSRN] T1 INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
                            sql += "                    INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                            sql += "    WHERE T1.[DistNumber] = '" & locView.Rows(i).Cells("F2").FormattedValue & "'"
                            sql += " ORDER BY T2.[Quantity] DESC "
                        Case "2"
                            'sql = "SELECT  dbo.OBTN.DistNumber, dbo.OBTN.U_M2, dbo.OBTQ.Quantity FROM dbo.OBTN inner join dbo.OBTQ on dbo.OBTQ.ItemCode = dbo.OBTN.ItemCode and OBTQ.SysNumber = OBTN.SysNumber where obtn.DistNumber = '" & locView.Rows(i).Cells("F2").FormattedValue & "' order by dbo.OBTQ.Quantity desc"
                            sql = "    SELECT T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M2], T2.[Quantity]"
                            sql += "     FROM [OBTN] T1 INNER JOIN [OBTQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry]"
                            sql += "                    INNER JOIN [OITM] T3 ON T1.[ItemCode] = T3.[ItemCode] "
                            sql += "    WHERE T1.[DistNumber] = '" & locView.Rows(i).Cells("F2").FormattedValue & "'"
                            sql += " ORDER BY T2.[Quantity] DESC "
                    End Select

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql

                    sqlReader1 = SQLCmd.ExecuteReader
                    sqlReader1.Read()

                    If sqlReader1.HasRows() Then

                        If sqlReader1.Item("Quantity") > 0 Then
                            Q0 = Q0 + 1
                            Dim Row(Q0) As DataRow
                            Row(Q0) = dsPDAIn0.NewRow
                            'Row(Q0).Item("條碼") = locView.Rows(i).Cells("F2").FormattedValue
                            Row(Q0).Item("存編") = sqlReader1.Item("ItemCode")
                            Row(Q0).Item("品名") = sqlReader1.Item("ItemName")
                            Row(Q0).Item("條碼") = sqlReader1.Item("DistNumber")
                            Row(Q0).Item("數量") = sqlReader1.Item("Quantity")
                            dsPDAIn0.Rows.Add(Row(Q0))

                        ElseIf sqlReader1.Item("Quantity") <= 0 Then
                            Q1 = Q1 + 1
                            Dim Row(Q1) As DataRow
                            Row(Q1) = dsPDAIn1.NewRow
                            'Row(Q1).Item("條碼") = locView.Rows(i).Cells("F2").FormattedValue
                            Row(Q1).Item("存編") = sqlReader1.Item("ItemCode")
                            Row(Q1).Item("品名") = sqlReader1.Item("ItemName")
                            Row(Q1).Item("條碼") = sqlReader1.Item("DistNumber")
                            Row(Q1).Item("數量") = sqlReader1.Item("Quantity")
                            dsPDAIn1.Rows.Add(Row(Q1))
                        End If

                        sqlReader1.Close()

                    Else
                        sqlReader1.Close()

                        Q2 = Q2 + 1
                        Dim Row(Q2) As DataRow
                        Row(Q2) = dsPDAIn2.NewRow
                        'Row(Q2).Item("條碼") = locView.Rows(i).Cells("F2").FormattedValue
                        Row(Q2).Item("存編") = sqlReader1.Item("ItemCode")
                        Row(Q2).Item("品名") = sqlReader1.Item("ItemName")
                        Row(Q2).Item("條碼") = sqlReader1.Item("DistNumber")
                        Row(Q2).Item("數量") = sqlReader1.Item("Quantity")
                        dsPDAIn2.Rows.Add(Row(Q2))
                        'ks1DataSet.Tables("DT1").Clear()
                        'Exit Sub
                    End If

                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                    End
                End Try

                PBar1.Value = i
            Next

            If Q0 > 0 Then
                Btn0.Enabled = True
            End If
            If Q1 > 0 Then
                Btn1.Enabled = True
            End If
            If Q2 > 0 Then
                Btn2.Enabled = True
            End If

            DataGridView0.DataSource = dsPDAIn0
            DataGridView1.DataSource = dsPDAIn1
            DataGridView2.DataSource = dsPDAIn2
            lb0.Text = DataGridView0.RowCount
            lb1.Text = DataGridView1.RowCount
            lb2.Text = DataGridView2.RowCount

        End If

    End Sub

    Private Sub Btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn0.Click
        DataToExcel(DataGridView0, "")
    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        DataToExcel(DataGridView1, "")
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        DataToExcel(DataGridView2, "")
    End Sub
End Class