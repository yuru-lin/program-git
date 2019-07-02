Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_整合派工作業
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet

    Private Sub A_整合派工作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub 查詢草稿_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢草稿.Click
        If ComboBox1.SelectedIndex = -1 Then : MsgBox("未選取查詢項目", 48, "警告") : ComboBox1.Focus() : Exit Sub : End If
        查詢文件草稿單號()

    End Sub

    Public Sub 查詢文件草稿單號()
        If DGV1.RowCount > 0 Then : DataSetDGV.Tables("DGV1").Clear() : End If
        If DGV2.RowCount > 0 Then : DataSetDGV.Tables("DGV2").Clear() : End If

        Dim SQLQuery As String = ""
        Select Case ComboBox1.SelectedIndex
            Case "0" '銷售出庫
                SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'AA',NULL "
            Case "1" '單據領料
                SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'AB',NULL "
            Case "2" '存貨領用
                SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'AC',NULL "
            Case "3" '寄庫出庫
                SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'AD',NULL "
            Case Else
                Exit Sub
        End Select

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 120000

            DataAdapterDGV = New SqlDataAdapter(SQLCmd)
            DataAdapterDGV.Fill(DataSetDGV, "DGV1")
            DGV1.DataSource = DataSetDGV.Tables("DGV1")
            DGV1.AutoResizeColumns()
            If DGV1.RowCount = 0 Then : MsgBox("查無資料。", 48, "警告") : End If

        Catch ex As Exception
            MsgBox("提單載入異常：" & ex.Message) : Exit Sub
        End Try

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = 0 Then : Exit Sub : End If
        查品項()
    End Sub

    Private Sub 查品項()
        If DGV2.RowCount > 0 Then : DataSetDGV.Tables("DGV2").Clear() : End If

        Dim SQLQuery As String = ""
        Select Case ComboBox1.SelectedIndex
            Case "0", "1", "3"
                SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'BA','" & DGV1.CurrentRow.Cells("草稿單號").Value & "' "
                'Case "0" '銷售出庫
                '    SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'BA','" & DGV1.CurrentRow.Cells("草稿單號").Value & "' "
                'Case "1" '單據領料
                '    SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'BB','" & DGV1.CurrentRow.Cells("草稿單號").Value & "' "
            Case "2" '存貨領用
                SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'BC','" & DGV1.CurrentRow.Cells("草稿單號").Value & "' "
                'Case "3" '寄庫出庫
                '    SQLQuery = " EXEC [KaiShing].[dbo].[預_整合派工作業01v] 'BD','" & DGV1.CurrentRow.Cells("草稿單號").Value & "' "
            Case Else
                Exit Sub
        End Select

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 120000

            DataAdapterDGV = New SqlDataAdapter(SQLCmd)
            DataAdapterDGV.Fill(DataSetDGV, "DGV2")
            DGV2.DataSource = DataSetDGV.Tables("DGV2")
            DGV2整列資訊()
            'DGV2.AutoResizeColumns()
            If DGV2.RowCount = 0 Then : MsgBox("查無資料。", 48, "警告") : End If

        Catch ex As Exception
            MsgBox("品項載入異常：" & ex.Message) : Exit Sub
        End Try

    End Sub

    Private Sub DGV2整列資訊()
        If DGV2.RowCount <= 0 Then : MsgBox("查無品項!請重新檢查!", 16, "錯誤") : Exit Sub : End If

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name

                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 0 : column.Visible = False
                Case "管理" : column.HeaderText = "管理" : column.DisplayIndex = 1
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3
                Case "出庫數" : column.HeaderText = "出庫數" : column.DisplayIndex = 4
                Case "庫位" : column.HeaderText = "庫位" : column.DisplayIndex = 5
                Case "庫存量" : column.HeaderText = "庫存量" : column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()
    End Sub

    Private Sub 草稿單派工作業_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 草稿單派工作業.Click

        If DGV2.RowCount <= 0 Then
            MsgBox("查無品項!請重新檢查!", 16, "錯誤")
            Exit Sub
        End If
        A_草稿派工作業.草稿.Text = "草稿：" & DGV1.CurrentRow.Cells("草稿單號").Value
        A_草稿派工作業.提單.Text = "提單：" & DGV1.CurrentRow.Cells("提單號").Value
        A_草稿派工作業.備註.Text = "備註：" & DGV1.CurrentRow.Cells("備註").Value
        A_草稿派工作業.DGV21.DataSource = DataSetDGV.Tables("DGV2")
        A_草稿派工作業.MdiParent = MainForm
        A_草稿派工作業.Show()
        Me.Hide()
     
    End Sub
End Class