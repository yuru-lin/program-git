Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QueryFIMainDetail
    Dim ks1DataSet As DataSet = New DataSet
    Dim comIndex As Integer
    Dim comUpdateIndex As Integer

    Private Sub C_QueryFIMainDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceList.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvBarcode.ContextMenuStrip = MainForm.ContextMenuStrip1

        If Login.LogonUserName = "manager" Then
            Label11.Visible = True
            cobUpdateStatus.Visible = True
            btnConfirm.Visible = True
            btndelete.Visible = True
            Label12.Visible = True
            cobUpdateDetail.Visible = True
            btnConfonDetail.Visible = True
        End If
    End Sub

    Private Sub cobStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobStatus.SelectedIndexChanged
        Select Case cobStatus.SelectedIndex
            Case "0"
                comIndex = 1
            Case "1"
                comIndex = 2
            Case "2"
                comIndex = 3
            Case "3"
                comIndex = 4
        End Select

        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If
        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
       
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        LoadSourceMain()
    End Sub

    Private Sub LoadSourceMain()

        Dim DataAdapter1 As SqlDataAdapter        
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        If RB1.Checked = True Then
            sql = "SELECT [FI101] as '生產單號', [FI102] as '製單單號', [FI105] as '文件日期',case FI103 when '1' then '進行中' when '2' then'已產生列印' when '3' then'已完工確認' when '4' then'已入B1' end  as '狀態' from [@FI1Main] "
            If RRB1.Checked = True Then
                sql += " WHERE [FI103] = '" & comIndex & "' order by [FI105]"
            End If

            If RRB2.Checked = True Then
                sql += " WHERE [FI101] = '" & txtFI101.Text & "' order by [FI105]"
            End If
        End If

        If RB2.Checked = True Then
            sql = "SELECT [FI101] as '生產單號', [FI102] as '製單單號', [FI105] as '文件日期',case FI103 when '1' then '進行中' when '2' then'已產生列印' when '3' then'已完工確認' when '4' then'已入B1' end  as '狀態' from [@FI2Main] "
            If RRB1.Checked = True Then
                sql += " WHERE [FI103] = '" & comIndex & "' order by [FI105]"
            End If

            If RRB2.Checked = True Then
                sql += " WHERE [FI101] = '" & txtFI101.Text & "' order by [FI105]"
            End If
        End If

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")
        dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")
        dgvSourceMain.AutoResizeColumns()
        Label8.Text = dgvSourceMain.RowCount

    End Sub

    Private Sub dgvSourceMain_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick       
        If dgvSourceMain.RowCount = 0 Then
            Exit Sub
        End If
        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        LoadSourceList()               '載入選取製單之生產明細單
    End Sub

    Private Sub LoadSourceList()
        Dim DataAdapter2 As SqlDataAdapter        
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn

        If RB1.Checked = True Then
            sql = "SELECT [@FinishItem1].[FI106] as '條碼', [@FinishItem1].[FI107] as '存編', [@FinishItem1].[FI108] as '品名', case [@FinishItem1].[FI103] when '1' then '處理中' when '2' then '已列印' when '3' then '已清點' when '4' then '已入庫' when '5' then '標註作廢' when '6' then '確認作廢' end as '狀態', [@FinishItem1].[FI129] AS '實際生產時間' from [@FinishItem1] WHERE [@FinishItem1].[FI101] = '" & dgvSourceMain.CurrentRow.Cells("生產單號").Value & "' "
        End If

        If RB2.Checked = True Then
            sql = "SELECT [@FinishItem2].[FI106] as '條碼', [@FinishItem2].[FI107] as '存編', [@FinishItem2].[FI108] as '品名', case [@FinishItem2].[FI103] when '1' then '處理中' when '2' then '已列印' when '3' then '已清點' when '4' then '已入庫' when '5' then '標註作廢' when '6' then '確認作廢' end as '狀態', ISNULL(CAST([@FinishItem2].[FI129] AS VARCHAR(30)),'') AS '實際生產時間' from [@FinishItem2] WHERE [@FinishItem2].[FI101] = '" & dgvSourceMain.CurrentRow.Cells("生產單號").Value & "' "
        End If

        DataAdapter2 = New SqlDataAdapter(sql, DBConn)
        DataAdapter2.Fill(ks1DataSet, "DT2")
        dgvSourceList.DataSource = ks1DataSet.Tables("DT2")

        dgvSourceList.Refresh()
        dgvSourceList.AutoResizeColumns()
        Label4.Text = dgvSourceList.RowCount

    End Sub

    Private Sub dgvSourceList_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceList.CellClick        
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        If dgvSourceList.RowCount > 0 Then
            LoadBarCodeList()               '載入點選待出庫項目之可挑選條碼清單            
        End If
    End Sub

    Private Sub LoadBarCodeList()
        Dim DataAdapter3 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn

        sql = "select PDA03 as '條碼',PDA04 as '儲位',PDA06 as '狀態', PDA01 from [@ksPDAIn] where PDA03 = '" & dgvSourceList.CurrentRow.Cells("條碼").Value & "'"

        DataAdapter3 = New SqlDataAdapter(sql, DBConn)
        DataAdapter3.Fill(ks1DataSet, "DT3")
        dgvBarcode.DataSource = ks1DataSet.Tables("DT3")
        dgvBarcode.Refresh()
        dgvBarcode.AutoResizeColumns()
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If dgvBarcode.RowCount = 0 Then
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
            sql = "delete from [@ksPDAIn] where PDA01 = '" & dgvBarcode.CurrentRow.Cells("PDA01").Value & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除同步條碼失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
        MsgBox("刪除同步條碼成功!", 64, "完成")
    End Sub

    Private Sub cobUpdateStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobUpdateStatus.SelectedIndexChanged
        Select Case cobUpdateStatus.SelectedIndex
            Case "0"
                comUpdateIndex = 1
            Case "1"
                comUpdateIndex = 2
            Case "2"
                comUpdateIndex = 3
            Case "3"
                comUpdateIndex = 4
        End Select
    End Sub

    Private Sub btnConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If dgvSourceMain.RowCount = 0 Then
            Exit Sub
        End If

        If cobUpdateStatus.SelectedIndex = -1 Then
            MsgBox("請選擇變更狀態", 48, "警告")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("是否確認要變更" & dgvSourceMain.CurrentRow.Cells("生產單號").FormattedValue & "狀態?", 36, "警告")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            UpdateFI101()
        End If

    End Sub

    Private Sub UpdateFI101()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            If RB1.Checked = True Then
                sql = "Update [@FI1Main] set [FI103] = '" & comUpdateIndex & "' where [FI101] = '" & dgvSourceMain.CurrentRow.Cells("生產單號").FormattedValue & "'"
            End If

            If RB2.Checked = True Then
                sql = "Update [@FI2Main] set [FI103] = '" & comUpdateIndex & "' where [FI101] = '" & dgvSourceMain.CurrentRow.Cells("生產單號").FormattedValue & "'"
            End If

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("變更狀態失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try
        MsgBox("變更狀態成功!", 64, "完成")

        'If dgvSourceMain.RowCount > 0 Then
        '    ks1DataSet.Tables("DT1").Clear()
        'End If
        'If dgvSourceList.RowCount > 0 Then
        '    ks1DataSet.Tables("DT2").Clear()
        'End If
        'If dgvBarcode.RowCount > 0 Then
        '    ks1DataSet.Tables("DT3").Clear()
        'End If
    End Sub

    Private Sub btnConfonDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfonDetail.Click
        If dgvSourceList.RowCount = 0 Then
            Exit Sub
        End If

        If cobUpdateDetail.SelectedIndex = -1 Then
            MsgBox("請選擇變更狀態", 48, "警告")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("是否確認要變更" & dgvSourceList.CurrentRow.Cells("條碼").FormattedValue & "狀態?", 36, "警告")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            UpdateDetail()
        End If
    End Sub

    Private Sub UpdateDetail()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()



        Try
            'For Each oRow As DataGridViewRow In dgvSourceList.SelectedRows

            Dim int As Integer
            int = cobUpdateDetail.SelectedIndex + 1

            If RB1.Checked = True Then

                sql = "Update [@FinishItem1] set [FI103] = '" & int & "' where [FI106] = '" & dgvSourceList.CurrentRow.Cells("條碼").FormattedValue & "'"

                'sql = "Update [@FinishItem1] set [FI103] = '" & int & "' where [FI106] = '" & oRow.Cells("條碼").FormattedValue & "' "

                '" & oRow.Cells("條碼").Value & "'
            End If

            If RB2.Checked = True Then
                sql = "Update [@FinishItem2] set [FI103] = '" & int & "' where [FI106] = '" & dgvSourceList.CurrentRow.Cells("條碼").FormattedValue & "'"
            End If

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            '    MsgBox(oRow.Cells("條碼").FormattedValue)
            '    MsgBox(int, "測")

            'Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("變更狀態失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try





        MsgBox("變更狀態成功!", 64, "完成")

        If dgvSourceList.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If
        If dgvBarcode.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        LoadSourceList()

        'If dgvSourceMain.RowCount > 0 Then
        '    ks1DataSet.Tables("DT1").Clear()
        'End If


    End Sub

    Private Sub RRB2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RRB2.CheckedChanged

    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged

    End Sub
End Class