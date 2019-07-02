Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class IDMgn
    Dim idDataAdapter As SqlDataAdapter
    Dim idBindingSource As BindingSource = New BindingSource
    Dim ksDataSet As DataSet = New DataSet
    Public pFunction = New publicFunction

    Private Sub IDMgn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvID.ContextMenuStrip = MainForm.ContextMenuStrip1
        '載入帳號相關資料
        LoadIDList()
        '設定dgvID顯示
        setDGVListDisplay()
    End Sub

    '載入帳號相關資料至dgvID
    Private Sub LoadIDList()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim oToday As Date = Today

        Try
            sql = "select * from [@ksLogin]"
            idDataAdapter = New SqlDataAdapter(sql, DBConn)
            idDataAdapter.Fill(ksDataSet, "ID")
            idBindingSource.DataSource = ksDataSet.Tables("ID")
            dgvID.DataSource = idBindingSource
            'cbbPONum.SelectedIndex = 0
        Catch ex As Exception
            MsgBox("LoadPO: " & ex.Message)
            End
        End Try
    End Sub

    '將dgvID修改結果存回資料庫
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ksSqlCommandBuilder As SqlCommandBuilder
        ksSqlCommandBuilder = New SqlCommandBuilder(idDataAdapter)
        idDataAdapter.Update(ksDataSet, "ID")
        MsgBox("變更成功!", MsgBoxStyle.OkOnly, "變更成功")
    End Sub

    '設定dgvID顯示
    Private Sub setDGVListDisplay()
        With dgvID
            '設定FinishItem1DataGridView欄位標題及順序
            .Columns("LOG01").HeaderText = "帳號" : .Columns("LOG01").DisplayIndex = 0
            '.Columns("LOG02").Visible = False
            .Columns("LOG02").HeaderText = "密碼" : .Columns("LOG02").DisplayIndex = 2
            .Columns("LOG03").HeaderText = "上次登入" : .Columns("LOG03").DisplayIndex = 5
            .Columns("LOG04").HeaderText = "錯誤次數" : .Columns("LOG04").DisplayIndex = 6
            .Columns("LOG05").HeaderText = "狀態" : .Columns("LOG05").DisplayIndex = 4
            .Columns("LOG06").HeaderText = "權限" : .Columns("LOG06").DisplayIndex = 3
            .Columns("LOG07").HeaderText = "姓名" : .Columns("LOG07").DisplayIndex = 1
        End With
        dgvID.AutoResizeColumns()

    End Sub

    Private Sub btnChangePWD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePWD.Click
        Dim newPwd1, newPwd2 As String

        newPwd1 = InputBox("輸入新密碼：", "變更密碼", "")
        If newPwd1 = "" Then
            Exit Sub
        End If
        newPwd2 = InputBox("請再輸入一次新密碼：", "確認密碼", "")
        If newPwd1 = "" Then
            Exit Sub
        End If

        If newPwd1 <> newPwd2 Then
            MsgBox("輸入密碼不符!", MsgBoxStyle.OkOnly, "密碼錯誤")
        Else
            dgvID.CurrentRow.Cells("LOG02").Value = pFunction.encyPwd(newPwd1)
            idBindingSource.EndEdit()
            MsgBox("密碼已變更, 須存檔後才生效!", MsgBoxStyle.OkOnly, "變更成功")
        End If
    End Sub
End Class