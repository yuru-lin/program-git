Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 發票比對作業v001
    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim DGV重覆Dt As New DataTable
    Dim DGV未上傳Dt As New DataTable

    Private Sub 發票比對作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 680)
        AddDGV重覆Dt()
        AddDGV未上傳Dt()

    End Sub

    Private Sub AddDGV重覆Dt()
        Dim 文件編號 As DataColumn = New DataColumn("文件編號")
        Dim 發票號碼 As DataColumn = New DataColumn("發票號碼")
        Dim SAP發票狀態 As DataColumn = New DataColumn("SAP發票狀態")
        Dim 雲端發票狀態 As DataColumn = New DataColumn("雲端發票狀態")
        文件編號.DataType = System.Type.GetType("System.String")
        發票號碼.DataType = System.Type.GetType("System.String")
        SAP發票狀態.DataType = System.Type.GetType("System.String")
        雲端發票狀態.DataType = System.Type.GetType("System.String")
        DGV重覆Dt.Columns.Add(文件編號)
        DGV重覆Dt.Columns.Add(發票號碼)
        DGV重覆Dt.Columns.Add(SAP發票狀態)
        DGV重覆Dt.Columns.Add(雲端發票狀態)

    End Sub

    Private Sub AddDGV未上傳Dt()
        Dim 文件編號 As DataColumn = New DataColumn("文件編號")
        Dim 發票號碼 As DataColumn = New DataColumn("發票號碼")
        Dim SAP發票狀態 As DataColumn = New DataColumn("SAP發票狀態")
        文件編號.DataType = System.Type.GetType("System.String")
        發票號碼.DataType = System.Type.GetType("System.String")
        SAP發票狀態.DataType = System.Type.GetType("System.String")
        DGV未上傳Dt.Columns.Add(文件編號)
        DGV未上傳Dt.Columns.Add(發票號碼)
        DGV未上傳Dt.Columns.Add(SAP發票狀態)

    End Sub

    Private Sub Bu讀取上傳_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu讀取上傳.Click
        上傳作業()
        DGV比對載入()
        DGV重覆資料暫存() : DGV未上傳資料暫存()

    End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        DGV比對載入()
        DGV重覆資料暫存() : DGV未上傳資料暫存()

    End Sub

    Private Sub 上傳作業()
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"
        openfile.Filter = "Excel files(*.xlsx)|*.xlsx"        '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then : Exit Sub : End If
        'Dim connectionString As String = " Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1' "  '*.xls
        Dim connectionString As String = " Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1' "   '*.xlsx
        Dim strSQL As String = " SELECT * FROM [summary$] "

        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open()

            Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)
            Dim dTable As DataTable = New DataTable()
            dataAdapter.Fill(dTable)
            DGV上傳.DataSource = dTable
            DGV上傳.Rows.Remove(DGV上傳.Rows(0))
            dTable.Dispose()
            dataAdapter.Dispose()
            dbCommand.Dispose()
            excelConnection.Close() : excelConnection.Dispose()
            DGV上傳欄位()
            DGV上傳資料回寫暫存()

        Catch ex As Exception
            MsgBox("讀取Excel 錯誤：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub DGV上傳欄位()

        For Each column As DataGridViewColumn In DGV上傳.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1" : column.HeaderText = "發票狀態"
                Case "F2" : column.HeaderText = "發票號碼"
                Case "F3" : column.HeaderText = "發票日期"
                Case Else : column.Visible = False
            End Select
        Next
        DGV上傳.AutoResizeColumns()

    End Sub

    Private Sub DGV上傳資料回寫暫存()

        Dim SQLADD As String = "" : Dim SQLDEL As String = ""
        Dim KID As Integer = 0 : Dim SID As Integer = 0
        Dim DocDate As String = "" : Dim DocNo As String = "" : Dim Del As String = "Y"

        SQLADD += " TRUNCATE TABLE [KaiShingPlug].[dbo].[會_發票比對] "
        If DGV上傳.RowCount > 0 Then
            For i = 0 To DGV上傳.RowCount - 1
                SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[會_發票比對] ([發票狀態],[發票號碼],[發票日期])  "
                SQLADD += " VALUES ('" & DGV上傳.Rows(i).Cells("F1").Value & "',  '" & DGV上傳.Rows(i).Cells("F2").Value & "',  '" & DGV上傳.Rows(i).Cells("F3").Value & "') "
            Next
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLDEL + SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("回存成功!")

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub DGV比對載入()
        If DGV比對.RowCount > 0 Then : 顯示資料.Tables("DGV比對").Clear() : End If '清除資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_會_發票比對] 'B' "


        Try
            Dim DBConn As SqlConnection = Login.DBConn
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "DGV比對")
            DGV比對.DataSource = 顯示資料.Tables("DGV比對")
            DGV比對.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("分時領料：" & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub DGV重覆資料暫存()
        If DGV重覆.RowCount > 0 Then : DGV重覆Dt.Clear() : End If
        If DGV比對.RowCount > 0 Then   '加到DGV重覆Dt
            For i = 0 To DGV比對.RowCount - 1
                Dim Row As DataRow
                Row = DGV重覆Dt.NewRow
                If DGV比對.Rows(i).Cells("重覆").Value = "重覆" Then
                    Row.Item("文件編號") = DGV比對.Rows(i).Cells("文件編號").Value
                    Row.Item("發票號碼") = DGV比對.Rows(i).Cells("發票號碼").Value
                    Row.Item("SAP發票狀態") = DGV比對.Rows(i).Cells("SAP發票狀態").Value
                    Row.Item("雲端發票狀態") = DGV比對.Rows(i).Cells("雲端發票狀態").Value
                    DGV重覆Dt.Rows.Add(Row)
                End If
            Next
        End If

        DGV重覆.DataSource = DGV重覆Dt
        DGV重覆.AutoResizeColumns()

    End Sub

    Private Sub DGV未上傳資料暫存()
        If DGV未上傳.RowCount > 0 Then : DGV未上傳Dt.Clear() : End If
        If DGV比對.RowCount > 0 Then   '加到DGV未上傳Dt
            For i = 0 To DGV比對.RowCount - 1
                Dim Row As DataRow
                Row = DGV未上傳Dt.NewRow
                If DGV比對.Rows(i).Cells("雲端發票狀態").Value = "無上傳資料" Then
                    Row.Item("文件編號") = DGV比對.Rows(i).Cells("文件編號").Value
                    Row.Item("發票號碼") = DGV比對.Rows(i).Cells("發票號碼").Value
                    Row.Item("SAP發票狀態") = DGV比對.Rows(i).Cells("SAP發票狀態").Value
                    DGV未上傳Dt.Rows.Add(Row)
                End If
            Next
        End If

        DGV未上傳.DataSource = DGV未上傳Dt
        DGV未上傳.AutoResizeColumns()
    End Sub





End Class