Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServerCe.Client

Public Class C_SyncOutByPDA
    Dim PDADBConn As SqlCeConnection
    Dim daPDA As SqlCeDataAdapter
    Dim dsPDA As New DataSet

    Private Sub C_SyncOutByPDA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ScanedDataGridView.ContextMenuStrip = MainForm.ContextMenuStrip1
        BtnFalse()
        btnReadPDA.Enabled = False
        MsgBox("很抱歉，目前此功能暫停使用。", 48, "警告")
    End Sub

    Private Sub BtnTrue()
        btnSync.Enabled = True
        btnDel.Enabled = True
        btnUndel.Enabled = True
        UpdQty.Enabled = True
        DelPDA.Enabled = True
    End Sub
    Private Sub BtnFalse()
        btnSync.Enabled = False
        btnDel.Enabled = False
        btnUndel.Enabled = False
        UpdQty.Enabled = False
        DelPDA.Enabled = False
    End Sub

    Private Sub btnReadPDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadPDA.Click
        If ScanedDataGridView.RowCount > 0 Then
            dsPDA.Tables("OBList").Clear()
        End If

        Try
            PDADBConn = New SqlCeConnection("Data Source='Mobile Device\My Documents\KSPDA.sdf';password='ks1234'")
            PDADBConn.Open()
        Catch ex As Exception
            MsgBox("讀取PDA失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
        
        '讀入PDA資料庫資料, 並顯示在ScanedDataGridView
        daPDA = New SqlCeDataAdapter("select * from [@ksOBList]", PDADBConn)
        daPDA.Fill(dsPDA, "OBList")
        ScanedDataGridView.DataSource = dsPDA.Tables("OBList")
        '設定ScanedDataGridView顯示格式
        setDGVDisplay()
        setDGVListStatus()
        ScanedDataGridView.AutoResizeColumns()

        If ScanedDataGridView.RowCount > 0 Then
            BtnTrue()
        Else
            BtnFalse()
        End If
    End Sub

    '設定ScanedDataGridView顯示
    Private Sub setDGVDisplay()
        With ScanedDataGridView
            '設定dgvFinishItemMain欄位標題及順序
            .Columns("OBID").Visible = False
            .Columns("OB01").Visible = False
            .Columns("OB02").Visible = False
            .Columns("OB03").Visible = True : .Columns("OB03").HeaderText = "條碼" : .Columns("OB03").DisplayIndex = 2 : .Columns("OB03").ReadOnly = True
            .Columns("OB04").Visible = True : .Columns("OB04").HeaderText = "儲位" : .Columns("OB04").DisplayIndex = 4 : .Columns("OB04").ReadOnly = True
            .Columns("OB05").Visible = True : .Columns("OB05").HeaderText = "數量" : .Columns("OB05").DisplayIndex = 5
            .Columns("OB06").Visible = False
            .Columns("OB07").Visible = True : .Columns("OB07").HeaderText = "作業單別" : .Columns("OB07").DisplayIndex = 1 : .Columns("OB07").ReadOnly = True
            .Columns("OB08").Visible = True : .Columns("OB08").HeaderText = "來源單號" : .Columns("OB08").DisplayIndex = 6
            .Columns("OB09").Visible = True : .Columns("OB09").HeaderText = "來源單列號" : .Columns("OB09").DisplayIndex = 7
            .Columns("OB10").Visible = False
            .Columns("OB11").Visible = False
            .Columns("OB12").Visible = False
            .Columns("OB13").Visible = False
            .Columns("OB14").Visible = True : .Columns("OB14").HeaderText = "倉庫" : .Columns("OB14").DisplayIndex = 3 : .Columns("OB14").ReadOnly = True
            .Columns("OB15").Visible = False
            .Columns("OB16").Visible = False
        End With
        ScanedDataGridView.AutoResizeColumns()
        Label8.Text = ScanedDataGridView.RowCount
    End Sub

    '將ScanedDataGridView中不在原選取清單之外加項目以黃底顯示, 清單中未掃瞄項目以藍底顯示, '已取消之外加項目以紅底顯示
    Private Sub setDGVListStatus()
        For i As Integer = 0 To ScanedDataGridView.RowCount - 1
            Select Case ScanedDataGridView.Rows(i).Cells("OB10").Value
                Case "2"    '清單中未掃瞄項目以藍底顯示
                    ScanedDataGridView.Rows(i).DefaultCellStyle.BackColor = Color.LightSteelBlue
                Case "6"    '外加項目以黃底顯示
                    ScanedDataGridView.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Case "8"    '已取消之外加項目以紅底顯示
                    ScanedDataGridView.Rows(i).DefaultCellStyle.BackColor = Color.IndianRed
            End Select
        Next
    End Sub

    Private Sub btnSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSync.Click
       
    End Sub

    Private Sub Sync()
        Dim dtPDA As DataTable = dsPDA.Tables("OBList")

        If dtPDA.Rows.Count > 0 Then
            Dim oAns As Integer
            oAns = MsgBox("確定開始同步上傳嗎?", MsgBoxStyle.OkCancel, "確認同步上傳")
            If oAns = MsgBoxResult.Cancel Then
                Exit Sub
            End If

            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn
            Dim X As Integer
            Dim getDay As Date = Today
            Dim oBorS As String '點選項目採用批次或序號管理, 序號:S, 批次:B
            Dim sqlReader As SqlDataReader

            '檢查掃瞄項目(包括挑選清單及外加)是否超過原來挑選清單數(例:前置作業時,單號1選取5件條碼, 掃瞄項目也必須剛好為5件
            'Dim da As SqlDataAdapter
            'Dim ds As DataSet = New DataSet
            'sql = "SELECT distinct OB07, OB08 FROM [@ksOBList]"
            'da = New SqlDataAdapter(sql, DBConn)
            'da.Fill(ds, "OBMain")


            '1.將PDA資料同步至資料庫, 並進行必要資料更新
            '  (1)確認掃瞄部份：原挑選清單中項目UPDATE狀態為3:已清點
            '  (2)原挑選清單中未掃瞄者則UPDATE狀態為5:取消
            '  (3)外加項目Insert回資料庫(狀態為7:外加清點)
            '  (4)外加取消部份同樣Insert回資料庫(狀態為8:外加取消)
            For Each oRow As DataRow In dtPDA.Rows
                Select Case oRow.Item("OB10")
                    Case "2"    '原挑選清單中未掃瞄者則UPDATE狀態為5:取消
                        'sql = "UPDATE [@ksOBList] set  OB10='5', OB12='" & getDay & "' where OBID = '" & oRow.Item("OBID") & "'"
                        'SQLCmd.CommandText = sql
                        'X = SQLCmd.ExecuteNonQuery
                        'If X = -1 Then
                        '    MessageBox.Show("btnSync_Click: 同步PDA資料至伺服器資料庫時錯誤 (原挑選清單中未掃瞄)!")
                        '    Exit Sub
                        'End If




                        '================================================================

                        '檢查點選項目採用批次或序號管理


                        sql = "select ManSerNum, ManBtchNum from OITM where ItemCode='" & oRow.Item("OB01") & "'"
                        SQLCmd = New SqlCommand(sql, DBConn)
                        sqlReader = SQLCmd.ExecuteReader
                        sqlReader.Read()

                        If sqlReader.HasRows() Then
                            If sqlReader.Item("ManSerNum") = "Y" Then   '序號管理
                                oBorS = "S"
                            ElseIf sqlReader.Item("ManBtchNum") = "Y" Then  '批次管理
                                oBorS = "B"
                            Else
                                sqlReader.Close()
                                Exit Sub   '該項未啟用序號或批次管理, 即無條碼, 無需載入
                            End If
                            sqlReader.Close()
                        Else
                            MsgBox("項目基本資料主檔中找不到點選項目, 請檢查!", MsgBoxStyle.OkOnly, "資料錯誤")
                            sqlReader.Close()
                            Exit Sub
                        End If
                        sql = "UPDATE OBTN set U_M7 = 0 where ItemCode = '" & oRow.Item("OB01") & "' and DistNumber = '" & oRow.Item("OB03") & "' "
                        SQLCmd = New SqlCommand(sql, DBConn)
                        X = SQLCmd.ExecuteNonQuery
                        If X = -1 Then
                            MessageBox.Show("(減少)出庫前置作業選取條碼之預約量錯誤[OBTN]!!")
                        End If

                        '======================================================================



                        '清除條碼
                        sql = "Delete from [@ksOBList] where OBID=" & oRow.Item("OBID")
                        SQLCmd = New SqlCommand(sql, DBConn)
                        X = SQLCmd.ExecuteNonQuery
                        If X = -1 Then
                            MessageBox.Show("btnUnselect_Click: 刪除出庫前置作業選取條碼資料錯誤[@ksOBList]!")
                            Exit Sub
                        End If

                    Case "3"    '確認掃瞄部份：原挑選清單中項目UPDATE狀態為3:已清點
                        sql = "UPDATE [@ksOBList] set  OB10 = '3', OB12='" & getDay & "' where OBID = '" & oRow.Item("OBID") & "'"
                        SQLCmd.CommandText = sql
                        X = SQLCmd.ExecuteNonQuery
                        If X = -1 Then
                            MessageBox.Show("btnSync_Click: 同步PDA資料至伺服器資料庫時錯誤 (原挑選清單中已掃瞄)!")
                            Exit Sub
                        End If

                    Case "6"    '外加項目Insert回資料庫(狀態為7:外加清點)
                        sql = "INSERT INTO [@ksOBList] (OB03,OB04,OB07,OB10,OB12,OB13,OB05,OB08,OB09) VALUES " _
                                & "('" & oRow.Item("OB03") & "', '" & oRow.Item("OB04") & "', '" & oRow.Item("OB07") & "', '3', '" _
                                & getDay & "', '" & Login.LogonUserName & "','" & oRow.Item("OB05") & "','" & oRow.Item("OB08") & "','" & oRow.Item("OB09") & "')"
                        SQLCmd.CommandText = sql
                        X = SQLCmd.ExecuteNonQuery
                        If X = -1 Then
                            MessageBox.Show("btnSync_Click: 同步PDA資料至伺服器資料庫時錯誤 (外加項目)!")
                            Exit Sub
                        End If

                    Case "8"    '外加取消部份同樣Insert回資料庫(狀態為8:外加取消)
                        'sql = "INSERT INTO [@ksOBList] (OB03,OB04,OB07,OB10,OB12,OB13) VALUES " _
                        '        & "('" & oRow.Item("OB03") & "', '" & oRow.Item("OB04") & "', '" & oRow.Item("OB07") & "', '8', '" _
                        '        & getDay & "', '" & lblID.Text & "')"
                        'SQLCmd.CommandText = sql
                        'X = SQLCmd.ExecuteNonQuery
                        'If X = -1 Then
                        '    MessageBox.Show("btnSync_Click: 同步PDA資料至伺服器資料庫時錯誤 (外加取消項目)!")
                        '    Exit Sub
                        'End If
                        '清除條碼
                        sql = "Delete from [@ksOBList] where OB03=" & oRow.Item("OB03")
                        SQLCmd = New SqlCommand(sql, DBConn)
                        X = SQLCmd.ExecuteNonQuery
                        If X = -1 Then
                            MessageBox.Show("btnUnselect_Click: 刪除出庫前置作業選取條碼資料錯誤[@ksOBList]!")
                            Exit Sub
                        End If

                End Select
            Next

            '2.刪除PDA中資料
            Dim SQLCeCmd As SqlCeCommand = New SqlCeCommand
            SQLCeCmd.CommandType = CommandType.Text
            SQLCeCmd.CommandText = "DELETE FROM [@ksOBList]"
            SQLCeCmd.Connection = PDADBConn
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnSync_Click: 刪除PDA中資料時錯誤!")
                Exit Sub
            End If

            MsgBox("PDA資料同步完畢!", MsgBoxStyle.OkOnly, "同步完畢")
            Me.Close()

        End If
    End Sub

    '取消PDA中掃瞄之外加項目
    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        '只有條碼狀態為6:外加, 才可進行取消
        If ScanedDataGridView.CurrentRow.Cells("OB10").Value <> "6" Then
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認取消此外加條碼?", MsgBoxStyle.OkCancel, "取消外加")
        If oAns = MsgBoxResult.Ok Then
            Dim sql As String
            Dim SQLCeCmd As SqlCeCommand
            Dim X As Integer
            sql = "UPDATE [@ksOBList] set  OB10='8' where OB03 = '" & ScanedDataGridView.CurrentRow.Cells("OB03").Value & "'"
            SQLCeCmd = New SqlCeCommand(sql, PDADBConn)
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnDel_Click: 取消PDA外加條碼錯誤[@ksOBList]!")
            Else
                '清除FI, FinishItem1DataGridView原有資料
                Dim curIndex As Integer = ScanedDataGridView.CurrentRow.Index
                dsPDA.Tables("OBList").Rows(curIndex).Item("OB10") = "8"

                setDGVListStatus()  '重新顯示項目以黃/紅/藍底顯示
                ScanedDataGridView.Rows(curIndex).Cells("OB03").Selected = True
                ScanedDataGridView.FirstDisplayedScrollingRowIndex = curIndex
            End If
        End If
    End Sub

    '復原作廢
    Private Sub btnUndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndel.Click
        '若條碼狀態不為8:取消外加, 則離開
        If ScanedDataGridView.CurrentRow.Cells("OB10").Value <> "8" Then
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認回復此外加條碼?", MsgBoxStyle.OkCancel, "回復外加")
        If oAns = MsgBoxResult.Ok Then
            Dim sql As String
            Dim SQLCeCmd As SqlCeCommand
            Dim X As Integer
            sql = "UPDATE [@ksOBList] set  OB10='6' where OB03 = '" & ScanedDataGridView.CurrentRow.Cells("OB03").Value & "'"
            SQLCeCmd = New SqlCeCommand(sql, PDADBConn)
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnUnDel_Click: 回復已取消之PDA外加條碼錯誤[@ksOBList]!")
            Else
                '清除FI, FinishItem1DataGridView原有資料
                Dim curIndex As Integer = ScanedDataGridView.CurrentRow.Index
                dsPDA.Tables("OBList").Rows(curIndex).Item("OB10") = "6"

                setDGVListStatus()  '重新顯示作廢項目以黃/紅底顯示
                ScanedDataGridView.Rows(curIndex).Cells("OB03").Selected = True
                ScanedDataGridView.FirstDisplayedScrollingRowIndex = curIndex
            End If
        End If
    End Sub

    Private Sub UpdQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdQty.Click

        Dim SQLceCmd As SqlCeCommand = New SqlCeCommand
        Dim sql As String
        Dim X As Integer
        PDADBConn = New SqlCeConnection("Data Source='Mobile Device\My Documents\KSPDA.sdf';password='ks1234'")
        PDADBConn.Open()

        For i As Integer = 0 To ScanedDataGridView.RowCount - 1

            sql = "Update [@ksOBList] set OB05 = '" & ScanedDataGridView.Rows(i).Cells("OB05").Value & "', OB08 = '" & ScanedDataGridView.Rows(i).Cells("OB08").Value & "', OB09 = '" & ScanedDataGridView.Rows(i).Cells("OB09").Value & "' where OB10 = '6'"
            SQLceCmd.Connection = PDADBConn
            SQLceCmd.CommandText = sql
            X = SQLceCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show(" 更新欄位時錯誤!!")
                'Exit Sub
            End If
        Next

        MessageBox.Show(" 更新欄位完成 !")
    End Sub

    Private Sub DelPDA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelPDA.Click
        Dim oAns As Integer
        oAns = MsgBox("確認刪除PDA裡面所有資料嗎?", MsgBoxStyle.OkCancel, "刪除資料")
        If oAns = MsgBoxResult.Ok Then
            '2.刪除PDA中資料
            Dim SQLCeCmd As SqlCeCommand = New SqlCeCommand
            Dim X As Integer
            SQLCeCmd.CommandType = CommandType.Text
            SQLCeCmd.CommandText = "DELETE FROM [@ksOBList]"
            SQLCeCmd.Connection = PDADBConn
            X = SQLCeCmd.ExecuteNonQuery
            If X = -1 Then
                MessageBox.Show("btnSync_Click: 刪除PDA中資料時錯誤!")
                Exit Sub
            End If

            MsgBox("刪除PDA中資料完畢!", MsgBoxStyle.OkOnly, "刪除PDA中資料完畢")
            Me.Close()
        End If
    End Sub
End Class