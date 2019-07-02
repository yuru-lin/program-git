Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_UpdateSchedule
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim cobSt As String


    Private Sub B_UpdateSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If CheckBox1.Checked = True Then
            If CardCodeForSearch.Text = "" Then
                MsgBox("客編未填!", 16, "錯誤")
                Exit Sub
            End If
        End If

        If CheckBox3.Checked = True Then
            If cobStatusForSearch.SelectedIndex = -1 Then
                MsgBox("狀態位選!", 16, "錯誤")
                Exit Sub
            End If
        End If

        SearchDB()
    End Sub

    Private Sub SearchDB()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If     

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter

        sql = "SELECT [sid] as '編號',[CardCode] as '客編',[CardName] as '客名',[ItemCode] as '存編',[ItemName] as '品名',[NeedQuantity] as '需求數',[FromDate] as '開始日期' ,[ToDate] as '結束日期' ,case [CurrentStatus] When 'O' then '生產中' When 'F' then '已完成' When 'C' then '取消' end as '狀態' FROM [@ProduceSchedule] Where sid > 0 "

        If CheckBox1.Checked = True Then
            sql += " and [CardCode] = '" & CardCodeForSearch.Text & "'"
        End If

        If CheckBox2.Checked = True Then
            sql += " and [ToDate] = '" & SearchDate.Value.Date & "'"
        End If

        If CheckBox3.Checked = True Then
            Dim cobS As String

            Select Case cobStatusForSearch.SelectedIndex
                Case "0"
                    cobS = "O"
                Case "1"
                    cobS = "F"
                Case "2"
                    cobS = "C"
            End Select

            sql += " and [CurrentStatus] = '" & cobS & "'"
        End If

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        DGV1.AutoResizeColumns()


    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        CardCode.Text = DGV1.CurrentRow.Cells("客編").Value
        CardName.Text = DGV1.CurrentRow.Cells("客名").Value
        ItemCodeTxt.Text = DGV1.CurrentRow.Cells("存編").Value
        ItemNameTxt.Text = DGV1.CurrentRow.Cells("品名").Value
        FromDate.Value = DGV1.CurrentRow.Cells("開始日期").Value
        ToDate.Value = DGV1.CurrentRow.Cells("結束日期").Value
        NeedQuantitytxt.Text = DGV1.CurrentRow.Cells("需求數").Value
        cobStatus.Text = DGV1.CurrentRow.Cells("狀態").Value

    End Sub

    Private Sub CardCodet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardCode.LostFocus
        SelectCardCode()
    End Sub

    Private Sub CardName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardName.LostFocus
        SelectCardName()
    End Sub

    Private Sub ItemCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemCodeTxt.LostFocus
        SelectItemCode()
    End Sub

    Private Sub ItemNameTxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemNameTxt.LostFocus
        SelectItemName()
    End Sub

    Private Sub SelectCardCode()

        If CardCode.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'C' and [CardCode] = '" & CardCode.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無此人", 16, "錯誤")
                CardName.Text = ""
                CardCode.Text = ""
                CardCode.Focus()
            Else
                CardName.Text = sqlReader.Item("CardName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

    End Sub

    Private Sub SelectCardName()

        If CardName.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'C' and [CardName] = '" & CardName.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectName.getCardName = CardName.Text
                SelectName.getCardCode = CardCode.Text
                SelectName.Source = "UpdateSchedule"
                SelectName.MdiParent = MainForm
                SelectName.Show()
            Else
                CardCode.Text = sqlReader.Item("CardCode")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemCode()

        If ItemCodeTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [ItemName] FROM [OITM] WHERE [ItemCode] = '" + ItemCodeTxt.Text + "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()

                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "UpdateSchedule"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemNameTxt.Text = sqlReader.Item("ItemName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub SelectItemName()

        If ItemNameTxt.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [ItemCode]  FROM [OITM] WHERE [ItemName] = '" & ItemNameTxt.Text & "' and left(ItemCode,2) = '25' and SUBSTRING(ItemCode,4,1) in ('1','2')"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectItem.getItemName = ItemNameTxt.Text
                SelectItem.getItemCode = ItemCodeTxt.Text
                SelectItem.Source = "UpdateSchedule"
                SelectItem.MdiParent = MainForm
                SelectItem.Show()
            Else
                ItemCodeTxt.Text = sqlReader.Item("ItemCode")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using
    End Sub

    Private Sub NeedQuantitytxt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NeedQuantitytxt.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub cobStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobStatus.SelectedIndexChanged
        Select Case cobStatus.SelectedIndex
            Case "0"
                cobSt = "O"
            Case "1"
                cobSt = "F"
            Case "2"
                cobSt = "C"
        End Select
    End Sub

    Private Sub btnAddToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDB.Click
        If CardCode.Text = "" Then
            MsgBox("客編未填!", 16, "錯誤")
            Exit Sub
        End If
        If ItemCodeTxt.Text = "" Then
            MsgBox("存編未填!", 16, "錯誤")
            Exit Sub
        End If
        If NeedQuantitytxt.Text = "" Then
            MsgBox("數量未填!", 16, "錯誤")
            Exit Sub
        End If

        UpdateToDB()
    End Sub

    Private Sub UpdateToDB()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [@ProduceSchedule] SET CardCode = '" & CardCode.Text & "',CardName = '" & CardName.Text & "',ItemCode = '" & ItemCodeTxt.Text & "' ,ItemName = '" & ItemNameTxt.Text & "' ,NeedQuantity = " & NeedQuantitytxt.Text & " ,FromDate = '" & FromDate.Value.Date & "' ,ToDate = '" & ToDate.Value.Date & "' ,CurrentStatus = '" & cobSt & "'  Where [sid] = '" & DGV1.CurrentRow.Cells("編號").Value & "' "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            ClearAll()
            Exit Sub
        End Try

        MsgBox("更新至資料庫完成!", 64, "成功")
        ClearAll()
        SearchDB()
    End Sub
    Private Sub ClearAll()

        CardName.Text = ""
        CardCode.Text = ""
        NeedQuantitytxt.Text = ""
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        FromDate.Value = Today
        ToDate.Value = Today
        cobStatus.SelectedIndex = -1

    End Sub



   
End Class