Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class Excel讀取轉入
    Dim dsPDAIn As New DataSet
    Dim red As Integer = 0
    Dim red2 As Integer = 0
    Dim OldName, NewName As String  '更名使用_20140303_Phil
    Dim 入庫YesNo As String = "Yes"

    Private Sub Excel讀取轉入_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgv1.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadExcel.Click
        SyncToDB.Enabled = False
        入庫YesNo = "Yes"
        Dim openfile As New OpenFileDialog()
        'openfile.InitialDirectory = "..\"                  '開啟時預設的資料夾路徑   

        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"   '開啟使用者桌面路徑_20140303_Phil
        openfile.Filter = "Excel files(*.xls)|*.xls"        '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        '20140303_Phil_查看資料用
        'Dim open1 As String = openfile.SafeFileName                                    '取得檔案名稱及副檔名
        'Dim open2 As String = Replace(openfile.FileName, openfile.SafeFileName, "")    '取得路址
        'Dim open3 As String = openfile.FileName                                        '完整路址、檔案名稱及副檔名
        'Dim open4 As String = Replace(openfile.SafeFileName, ".xls", "")               '取得檔案名稱

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        Dim strSQL As String = "SELECT * FROM [Sheet1$] "
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

        dgv1.DataSource = dTable
        ' dispose used objects
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        red = 0
        setdgvDisplay()

        '20140303_Phil
        OldName = openfile.FileName
        'NewName = Format(Replace(openfile.FileName, openfile.SafeFileName, "") & "備份\入庫\" & Replace(openfile.SafeFileName, ".xls", "") & Format(Now(), "yyyyMMdd-hhmmssfff") & ".xls", "")
        NewName = Format(Environ("HOMEPATH") & "\Desktop\備份\入庫\" & Replace(openfile.SafeFileName, ".xls", "") & Format(Now(), "yyyyMMdd-hhmmssfff") & ".xls", "")

        'IO.File.Move(OldName, NewName) '移動及更改檔案名稱1_20140303_Phil
        'Rename(OldName, NewName)       '移動及更改檔案名稱2_20140303_Phil

    End Sub
    '設定dgvSourceMain顯示
    Private Sub setdgvDisplay()

        For Each column As DataGridViewColumn In dgv1.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "作業別"
                Case "F2"
                    column.HeaderText = "條碼"
                Case "F3"
                    column.HeaderText = "儲位"

                Case Else
                    column.Visible = False
            End Select
        Next
        dgv1.AutoResizeColumns()
        Label4.Text = dgv1.RowCount

        If dgv1.RowCount > 0 Then
            chkSRN()
            If UCase(GetHostName()) <> "KS-F1" Then
                chkSRN2()
            End If

        End If

    End Sub

    Private Sub chkSRN()
        red = 0
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand
        Dim sqlReader As SqlDataReader

        For i As Integer = 0 To dgv1.RowCount - 1
            sql = "select * from [@ksPDAIn] where PDA03 = '" & dgv1.Rows(i).Cells("F2").Value & "' and left(PDA02,2) = '" & Microsoft.VisualBasic.Left(dgv1.Rows(i).Cells("F1").Value, 2) & "'"
            SQLCmd = New SqlCommand(sql, DBConn)
            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If sqlReader.HasRows() Then
                red += 1
                dgv1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                sqlReader.Close()
            Else
                dgv1.Rows(i).DefaultCellStyle.BackColor = Color.White
                sqlReader.Close()
            End If

        Next

        If red = 0 Then
            SyncToDB.Enabled = True
            btndelete.Enabled = False
        Else
            MsgBox("有" & red & "個條碼已同步!", 16, "錯誤")
            SyncToDB.Enabled = False
            btndelete.Enabled = True
        End If
    End Sub

    Private Sub chkSRN2()
        For i As Integer = 0 To dgv1.RowCount - 1
            If Microsoft.VisualBasic.Left(dgv1.Rows(i).Cells("F1").Value, 2) = "12" Then
                入庫YesNo = "No"
            End If
        Next

    End Sub


    Private Sub SyncToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncToDB.Click

        'If 入庫YesNo = "No" Then
        '    MsgBox("加工條碼無法手動入庫，請移除", 16, "錯誤")
        '    Exit Sub
        'End If

        If dgv1.Rows.Count <= 0 Then
            MsgBox("無資料可同步!", 16, "錯誤")
            Exit Sub
        End If

        Sync()

    End Sub

    Private Sub Sync()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To dgv1.RowCount - 1
                '(1) 利用Insert命令逐筆複製至Server資料庫[@ksPDAIn]中
                sql = "INSERT INTO [@ksPDAIn] ([PDA02],[PDA03],[PDA04],[PDA06]) VALUES " _
                & "('" & dgv1.Rows(i).Cells("F1").Value & "', '" & dgv1.Rows(i).Cells("F2").Value & "', '" & dgv1.Rows(i).Cells("F3").Value & "', '2')"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

                '(2) 若為電宰或加工待入庫單, 則修改該項之狀態
                Select Case Microsoft.VisualBasic.Left(dgv1.Rows(i).Cells("F1").Value, 2)
                    Case "11"
                        sql = "UPDATE [@FinishItem1] set  FI103 = '3' where FI106 = '" & dgv1.Rows(i).Cells("F2").Value & "' and FI103 < '3'"
                        SQLCmd.Connection = DBConn
                        SQLCmd.CommandText = sql
                        SQLCmd.Transaction = tran
                        SQLCmd.ExecuteNonQuery()
                    Case "12"
                        sql = "UPDATE [@FinishItem2] set  FI103 = '3' where FI106 = '" & dgv1.Rows(i).Cells("F2").Value & "' and FI103 < '3'"
                        SQLCmd.Connection = DBConn
                        SQLCmd.CommandText = sql
                        SQLCmd.Transaction = tran
                        SQLCmd.ExecuteNonQuery()
                End Select
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("Excel資料同步失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("Excel資料同步完畢!", MsgBoxStyle.OkOnly, "同步成功")
        'Rename(OldName, NewName)       '移動及更改檔案名稱2_20140303_Phil

        SyncToDB.Enabled = False '停用同步_20140305_Phil

    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If red = 0 Then
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("是否要刪除同步條碼?", 36, "警告")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            DeletePDAIn()
        End If

    End Sub

    Private Sub DeletePDAIn()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To dgv1.RowCount - 1

                If dgv1.Rows(i).DefaultCellStyle.BackColor = Color.Red Then
                    'sql = "DELETE FROM [@ksPDAIn] WHERE [PDA02] = '" & dgv1.Rows(i).Cells("F1").Value & "' AND [PDA03] = '" & dgv1.Rows(i).Cells("F2").Value & "' "
                    sql = "DELETE FROM [@ksPDAIn] WHERE [PDA03] = '" & Trim(dgv1.Rows(i).Cells("F2").Value) & "' "

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()
                End If
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除同步條碼失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
        MsgBox("刪除同步條碼成功!", 64, "完成")
        red = 0
        chkSRN()
    End Sub


End Class