Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_AddSchedule

    Private Sub B_AddSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

            sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'C' and ([QryGroup7] = 'Y' OR [QryGroup8] = 'Y') and [CardCode] = '" & CardCode.Text & "'"

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

            sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'C' and ([QryGroup7] = 'Y' OR [QryGroup8] = 'Y') and [CardName] = '" & CardName.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectName.getCardName = CardName.Text
                SelectName.getCardCode = CardCode.Text
                SelectName.Source = "AddSchedule"
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
                SelectItem.Source = "AddSchedule"
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
                SelectItem.Source = "AddSchedule"
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

        AddToDB()
    End Sub

    Private Sub AddToDB()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "INSERT INTO [@ProduceSchedule] (CardCode,CardName,ItemCode,ItemName,NeedQuantity,FromDate,ToDate) VALUES ('" & CardCode.Text & "','" & CardName.Text & "','" & ItemCodeTxt.Text & "','" & ItemNameTxt.Text & "'," & NeedQuantitytxt.Text & ",'" & FromDate.Value.Date & "','" & ToDate.Value.Date & "')"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            ClearAll()
            Exit Sub
        End Try

        MsgBox("新增至資料庫完成!", 64, "成功")
        ClearAll()
    End Sub
    Private Sub ClearAll()

        CardName.Text = ""
        CardCode.Text = ""
        NeedQuantitytxt.Text = ""
        ItemCodeTxt.Text = ""
        ItemNameTxt.Text = ""
        FromDate.Value = Today
        ToDate.Value = Today

    End Sub
End Class