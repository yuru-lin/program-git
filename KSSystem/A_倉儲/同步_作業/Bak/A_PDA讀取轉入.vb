Imports System
Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServerCe.Client

Public Class A_PDA讀取轉入
    Dim PDADBConn As SqlCeConnection
    Dim daPDAIn, LocCunt As SqlCeDataAdapter
    Dim daPDAInSql, LocCuntSql As SqlDataAdapter
    Dim dsPDAIn As New DataSet
    Dim LocCIn As New DataSet
    Dim ErrorAmount As Integer = 0

    Private Sub A_PDA讀取轉入_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ScanedDataGridView.ContextMenuStrip = MainForm.ContextMenuStrip1
        LocCuntView.ContextMenuStrip = MainForm.ContextMenuStrip1
        BtnFalse()
    End Sub

    Private Sub btnReadPDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPDA.Click

        'dsPDAIn.Clear()
        'LocCIn.Clear()

        ReadPDA()

    End Sub

    Private Sub ReadPDA()

        If ScanedDataGridView.RowCount > 0 Then
            dsPDAIn.Tables("DBPDAIn").Clear()
        End If

        If LocCuntView.RowCount > 0 Then
            LocCIn.Tables("LocCuntIn").Clear()
        End If

        ErrorAmount = 0

        Try     '連線PDA資料庫
            If 舊PDA.Checked = True Then
                PDADBConn = New SqlCeConnection("Data Source='Mobile Device\My Documents\KSPDA.sdf';password='ks1234'")
                'PDADBConn = New SqlCeConnection("Data Source='Mobile Device\FLASH\KSPDA.sdf';password='ks1234'")
            Else
                PDADBConn = New SqlCeConnection("Data Source='Mobile Device\Storage Card\KSPDA.sdf';password='ks1234'")
            End If

            PDADBConn.Open()
        Catch ex As Exception
            MsgBox("讀取PDA失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        '讀入PDA資料庫資料, 並顯示在ScanedDataGridView
        daPDAIn = New SqlCeDataAdapter(" SELECT * FROM [@ksPDAIn]", PDADBConn)
        daPDAIn.Fill(dsPDAIn, "DBPDAIn")
        ScanedDataGridView.DataSource = dsPDAIn.Tables("DBPDAIn")
        '設定ScanedDataGridView顯示格式
        setDGVDisplay()
        setDGVListStatus()
        ScanedDataGridView.AutoResizeColumns()

        '讀入資料並Count    儲位統計
        LocCunt = New SqlCeDataAdapter(" SELECT PDA04, COUNT(PDA04) AS Cunt FROM [@ksPDAIn] group by PDA04", PDADBConn)
        LocCunt.Fill(LocCIn, "LocCuntIn")
        LocCuntView.DataSource = LocCIn.Tables("LocCuntIn")
        '設定LocCuntView顯示格式
        setCuntDisplay()
        LocCuntView.AutoResizeColumns()


        If ScanedDataGridView.RowCount > 0 Then
            BtnTrue()
            ChkForPDA03()
        Else
            BtnFalse()
        End If

    End Sub
    '設定ScanedDataGridView顯示
    Private Sub setDGVDisplay()
        With ScanedDataGridView
            '設定dgvFinishItemMain欄位標題及順序
            .Columns("PDA01").Visible = False
            .Columns("PDA02").Visible = True : .Columns("PDA02").HeaderText = "作業單別" : .Columns("PDA02").DisplayIndex = 0
            .Columns("PDA03").Visible = True : .Columns("PDA03").HeaderText = "條碼" : .Columns("PDA03").DisplayIndex = 1
            .Columns("PDA04").Visible = True : .Columns("PDA04").HeaderText = "儲位" : .Columns("PDA04").DisplayIndex = 2
            .Columns("PDA05").Visible = True : .Columns("PDA05").HeaderText = "作業日期" : .Columns("PDA05").DisplayIndex = 3
            .Columns("PDA06").Visible = False
            .Columns("PDA07").Visible = False
            .Columns("PDA08").Visible = False
            .Columns("PDA09").Visible = False
            '.Columns("PDA10").Visible = False
            '.Columns("PDA11").Visible = False
            '.Columns("PDA12").Visible = False
        End With
        ScanedDataGridView.AutoResizeColumns()
        Label6.Text = ScanedDataGridView.RowCount

    End Sub
    '將ScanedDataGridView中標示為作廢之項目以黃底顯示
    Private Sub setDGVListStatus()
        For i As Integer = 0 To ScanedDataGridView.RowCount - 1

            Select Case ScanedDataGridView.Rows(i).Cells("PDA06").Value
                Case "5"    '標記作廢項目以黃底顯示
                    ScanedDataGridView.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End Select
        Next
    End Sub
    '設定LocCuntView顯示
    Private Sub setCuntDisplay()

        '設定LocCuntView欄位標題及順序
        For Each column As DataGridViewColumn In LocCuntView.Columns
            column.Visible = True
            Select Case column.HeaderText
                Case "PDA04"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 0
                Case "Cunt"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 1
                Case Else
                    column.Visible = False
            End Select

        Next
        LocCuntView.AutoResizeColumns()

    End Sub

    Private Sub btnSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSync.Click
        If ScanedDataGridView.RowCount <= 0 Then
            Exit Sub
        End If

        If ErrorAmount > 0 Then
            MsgBox("有" & ErrorAmount & "個條碼已同步過!請檢查", 16, "錯誤")
            Exit Sub
        End If

        Sync()
    End Sub

    Private Sub Sync()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Dim dtPDAIn As DataTable = dsPDAIn.Tables("DBPDAIn")

        If dtPDAIn.Rows.Count > 0 Then
            Try
                '1.將PDA資料同步至資料庫, 並進行必要資料更新
                For Each oRow As DataRow In dtPDAIn.Rows
                    '(1) 利用Insert命令逐筆複製至Server資料庫[@ksPDAIn]中
                    If oRow.Item("PDA06") = "5" Then
                    Else
                        If ErrorAmount = 0 Then
                            sql = "INSERT INTO [@ksPDAIn] (PDA02,PDA03,PDA04,PDA05,PDA06,PDA07,PDA08,PDA09) VALUES ('" & oRow.Item("PDA02") & "', '" & oRow.Item("PDA03") & "', '" & oRow.Item("PDA04") & "','" & oRow.Item("PDA05") & "', '" & oRow.Item("PDA06") & "', '" & oRow.Item("PDA07") & "','" & Login.LogonUserName & "', '" & oRow.Item("PDA09") & "')"
                            SQLCmd.Connection = DBConn
                            SQLCmd.CommandText = sql
                            SQLCmd.Transaction = tran
                            SQLCmd.ExecuteNonQuery()
                            '(2) 若為電宰或加工待入庫單, 則修改該項之狀態
                            Select Case Microsoft.VisualBasic.Left(oRow.Item("PDA02"), 1)
                                Case "1"
                                    sql = "UPDATE [@FinishItem1] set  FI103 = '3' where FI106 = '" & oRow.Item("PDA03") & "'"
                                    SQLCmd.Connection = DBConn
                                    SQLCmd.CommandText = sql
                                    SQLCmd.Transaction = tran
                                    SQLCmd.ExecuteNonQuery()
                                Case "2"
                                    sql = "UPDATE [@FinishItem2] set  FI103 = '3' where FI106 = '" & oRow.Item("PDA03") & "'"
                                    SQLCmd.Connection = DBConn
                                    SQLCmd.CommandText = sql
                                    SQLCmd.Transaction = tran
                                    SQLCmd.ExecuteNonQuery()
                            End Select
                        End If
                    End If
                Next
                tran.Commit()
            Catch ex As Exception
                tran.Rollback()
                MsgBox("同步PDA資料至伺服器資料庫時錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
                Exit Sub
            End Try
            '2.刪除PDA中資料

            Dim X1 As Integer
            Dim SQLCeCmd As SqlCeCommand = New SqlCeCommand
            SQLCeCmd.CommandType = CommandType.Text
            SQLCeCmd.CommandText = "DELETE FROM [@ksPDAIn]"
            SQLCeCmd.Connection = PDADBConn
            X1 = SQLCeCmd.ExecuteNonQuery
            If X1 = -1 Then
                MessageBox.Show("btnIn1_Click: 刪除PDA中資料時錯誤!")
                Exit Sub
            End If

            MsgBox("PDA資料同步完畢!", MsgBoxStyle.OkOnly, "同步成功")
            dsPDAIn.Tables("DBPDAIn").Clear()
            BtnFalse()

        End If
    End Sub

    Private Sub BtnTrue()
        btnSync.Enabled = True
        btnDel.Enabled = True
        btnUndel.Enabled = True
        DelPDA.Enabled = True
        ToExcelBtn.Enabled = True
    End Sub
    Private Sub BtnFalse()
        btnSync.Enabled = False
        btnDel.Enabled = False
        btnUndel.Enabled = False
        DelPDA.Enabled = False
        ToExcelBtn.Enabled = False
        btndelete.Enabled = False
    End Sub

    '作廢PDA中已掃瞄項目
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        '若條碼狀態為5:作廢, 則離開
        If ScanedDataGridView.CurrentRow.Cells("PDA06").Value = "5" Then
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認作廢此條碼?", MsgBoxStyle.OkCancel, "掃瞄作廢")
        If oAns = MsgBoxResult.Ok Then
            Dim sql As String
            Dim SQLCeCmd As SqlCeCommand
            Dim X As Integer
            sql = "UPDATE [@ksPDAIn] set  PDA06='5', PDA09='" & Login.LogonUserName & "' where PDA03 = '" & ScanedDataGridView.CurrentRow.Cells("PDA03").Value & "'"
            SQLCeCmd = New SqlCeCommand(sql, PDADBConn)
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnDel_Click: PDA資料註記作廢錯誤[@ksPDAIn]!")
            Else
                '清除FI, FinishItem1DataGridView原有資料
                Dim curIndex As Integer = ScanedDataGridView.CurrentRow.Index
                dsPDAIn.Tables("DBPDAIn").Clear()
                daPDAIn.Fill(dsPDAIn, "DBPDAIn")
                ScanedDataGridView.DataSource = dsPDAIn.Tables("DBPDAIn")
                '設定ScanedDataGridView顯示格式
                setDGVDisplay()
                setDGVListStatus()  '重新顯示作廢項目以黃/紅底顯示
                ScanedDataGridView.Rows(curIndex).Cells("PDA03").Selected = True
                ScanedDataGridView.FirstDisplayedScrollingRowIndex = curIndex
            End If
        End If
    End Sub

    '復原作廢
    Private Sub btnUndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndel.Click
        '若條碼狀態不為5:作廢, 則離開
        If ScanedDataGridView.CurrentRow.Cells("PDA06").Value <> "5" Then
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認復原此條碼為不作廢?", MsgBoxStyle.OkCancel, "復原作廢")
        If oAns = MsgBoxResult.Ok Then
            Dim sql As String
            Dim SQLCeCmd As SqlCeCommand
            Dim X As Integer
            sql = "UPDATE [@ksPDAIn] set PDA06='2', PDA09='" & Login.LogonUserName & "' where PDA03 = '" & ScanedDataGridView.CurrentRow.Cells("PDA03").Value & "'"
            SQLCeCmd = New SqlCeCommand(sql, PDADBConn)
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnDel_Click: PDA資料復原作廢錯誤[@ksPDAIn]!")
            Else
                '清除FI, FinishItem1DataGridView原有資料
                Dim curIndex As Integer = ScanedDataGridView.CurrentRow.Index
                dsPDAIn.Tables("DBPDAIn").Clear()
                daPDAIn.Fill(dsPDAIn, "DBPDAIn")
                ScanedDataGridView.DataSource = dsPDAIn.Tables("DBPDAIn")
                '設定ScanedDataGridView顯示格式
                setDGVDisplay()
                setDGVListStatus()  '重新顯示作廢項目以黃/紅底顯示
                ScanedDataGridView.Rows(curIndex).Cells("PDA03").Selected = True
                ScanedDataGridView.FirstDisplayedScrollingRowIndex = curIndex
            End If
        End If
    End Sub

    Private Sub DelPDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelPDA.Click

        Dim oAns As Integer
        oAns = MsgBox("確認刪除PDA裡面所有資料嗎?", MsgBoxStyle.OkCancel, "刪除資料")
        If oAns = MsgBoxResult.Ok Then
            '2.刪除PDA中資料
            Dim SQLCeCmd As SqlCeCommand = New SqlCeCommand
            Dim x As Integer
            SQLCeCmd.CommandType = CommandType.Text
            SQLCeCmd.CommandText = "DELETE FROM [@ksPDAIn]"
            SQLCeCmd.Connection = PDADBConn
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnIn1_Click: 刪除PDA中資料時錯誤!")
                Exit Sub
            End If

            MsgBox("刪除PDA中資料完畢!", MsgBoxStyle.OkOnly, "刪除成功")
            Me.Close()
        End If
    End Sub

    Private Sub ToExcelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn.Click
        DataToExcel(ScanedDataGridView, "")
    End Sub

    Private Sub ChkForPDA03()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand
        Dim sqlReader As SqlDataReader

        For i As Integer = 0 To ScanedDataGridView.RowCount - 1
            sql = "select * from [@ksPDAIn] where PDA03 = '" & ScanedDataGridView.Rows(i).Cells("PDA03").FormattedValue & "' and left(PDA02,1) = '" & Microsoft.VisualBasic.Left(ScanedDataGridView.Rows(i).Cells("PDA02").Value, 1) & "' "
            SQLCmd = New SqlCommand(sql, DBConn)
            sqlReader = SQLCmd.ExecuteReader

            If sqlReader.HasRows() Then
                sqlReader.Close()
                ErrorAmount += 1
                ScanedDataGridView.Rows(i).DefaultCellStyle.BackColor = Color.Red
            Else
                sqlReader.Close()
            End If
        Next

        Label4.Text = ErrorAmount

        If ErrorAmount > 0 Then
            btndelete.Enabled = True
        End If
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If ErrorAmount = 0 Then
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("是否要刪除紅色條碼?", 36, "警告")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            DeletePDAIn()
        End If
    End Sub

    Private Sub DeletePDAIn()

        Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCeCmd As SqlCeCommand = New SqlCeCommand
        Dim tran As SqlCeTransaction = PDADBConn.BeginTransaction()

        Try
            For i As Integer = 0 To ScanedDataGridView.RowCount - 1
                If ScanedDataGridView.Rows(i).DefaultCellStyle.BackColor = Color.Red Then
                    sql = "delete from [@ksPDAIn] where PDA02 = '" & ScanedDataGridView.Rows(i).Cells("PDA02").Value & "' and PDA03 = '" & ScanedDataGridView.Rows(i).Cells("PDA03").Value & "' "
                    SQLCeCmd.Connection = PDADBConn
                    SQLCeCmd.CommandText = sql
                    SQLCeCmd.Transaction = tran
                    SQLCeCmd.ExecuteNonQuery()
                End If
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除紅色條碼失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
        MsgBox("刪除紅色條碼成功!", 64, "完成")
        ErrorAmount = 0
        ReadPDA()
    End Sub


End Class