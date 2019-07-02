Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_QueryFromSpace
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QueryFromSpace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        locView.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSpaceDetail.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSpace.Text = "" Then
            MsgBox("儲位未填!", 16, "錯誤")
            Exit Sub
        End If

        Search()
    End Sub

    Private Sub Search()
        If locView.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If rbt1.Checked Then
                sql = "SELECT T0.[ItemCode], T2.[ItemName], T0.[DistNumber], T0.[U_M2] FROM OSRN T0  left JOIN OSRQ T1 ON T0.SysNumber = T1.SysNumber and T0.ItemCode = T1.ItemCode left JOIN OITM T2 ON T0.ItemCode = T2.ItemCode WHERE T1.Quantity > 0 and T0.U_M2 = '" & txtSpace.Text & "' order by T0.ItemCode"
            End If

            If rbt2.Checked Then
                sql = "SELECT T0.[ItemCode], T2.[ItemName], T0.[DistNumber], T0.[U_M2] FROM OBTN T0  left JOIN OBTQ T1 ON T0.SysNumber = T1.SysNumber and T0.ItemCode = T1.ItemCode Left JOIN OITM T2 ON T0.ItemCode = T2.ItemCode WHERE T1.Quantity > 0 and T0.U_M2 = '" & txtSpace.Text & "' order by T0.ItemCode "
            End If
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            locView.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try

        setLocViewDisplay()
    End Sub

    '設定dgvSourceMain顯示
    Private Sub setLocViewDisplay()

        If locView.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
            btnDetail.Enabled = False
            Exit Sub
        End If

        For Each column As DataGridViewColumn In locView.Columns
            column.Visible = True
            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                Case "ItemName"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                Case "DistNumber"
                    column.HeaderText = "條碼序號"
                    column.DisplayIndex = 2
                Case "U_M2"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 3

                Case Else
                    column.Visible = False
            End Select
        Next
        locView.AutoResizeColumns()
        btnDetail.Enabled = True
    End Sub

    Private Sub btnDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        SearchDetail()
    End Sub

    Private Sub SearchDetail()
        If dgvSpaceDetail.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            For i As Integer = 0 To locView.RowCount - 1

                If rbchose1.Checked = True Then
                    sql = "SELECT T0.DistNumber as '條碼',T0.ItemCode as '存編' ,T0.ItemName as '品名' , T0.FromLoc as '原本儲位' , T0.ToLoc as '目的儲位' , T0.ChgDate as '調整日期' FROM [@ChgLocMgn] T0 Where T0.DistNumber = '" & locView.Rows(i).Cells("F1").Value & "' Order By T0.DistNumber,T0.ChgDate "
                Else
                    sql = "SELECT T0.DistNumber as '條碼',T0.ItemCode as '存編' ,T0.ItemName as '品名' , T0.FromLoc as '原本儲位' , T0.ToLoc as '目的儲位' , T0.ChgDate as '調整日期' FROM [@ChgLocMgn] T0 Where T0.DistNumber = '" & locView.Rows(i).Cells("DistNumber").Value & "' Order By T0.DistNumber,T0.ChgDate "
                End If

                DataAdapter1 = New SqlDataAdapter(sql, DBConn)
                DataAdapter1.Fill(ks1DataSet, "DT2")
                dgvSpaceDetail.DataSource = ks1DataSet.Tables("DT2")
            Next
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try

        dgvSpaceDetail.AutoResizeColumns()
    End Sub

    Private Sub rbchose2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbchose2.CheckedChanged
        If rbchose1.Checked = True Then
            btnFromExcel.Enabled = True
            btnSearch.Enabled = False
        Else
            btnFromExcel.Enabled = False
            btnSearch.Enabled = True
        End If
    End Sub

    Private Sub btnFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromExcel.Click
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        openfile.Filter = "Excel files(*.xls)|*.xls"    '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        If locView.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
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

        dataAdapter.Fill(ks1DataSet, "DT1")

        locView.DataSource = ks1DataSet.Tables("DT1")
        ks1DataSet.Tables("DT1").Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        setdgvDisplay()

        'joinAllTable()
    End Sub

    Private Sub setdgvDisplay()

        If locView.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
            btnDetail.Enabled = False
            Exit Sub
        End If

        For Each column As DataGridViewColumn In locView.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "條碼序號"
                    column.DisplayIndex = 0

                Case Else
                    column.Visible = False
            End Select
        Next
        locView.AutoResizeColumns()
        btnDetail.Enabled = True
    End Sub

    Private Sub btnToExcel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel1.Click
        DataToExcel(locView, "")
    End Sub

    Private Sub btnToExcel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel2.Click
        DataToExcel(dgvSpaceDetail, "")
    End Sub
End Class