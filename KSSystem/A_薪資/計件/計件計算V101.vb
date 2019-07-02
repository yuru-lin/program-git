Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns
Imports Microsoft.VisualBasic

Public Class 計件計算V101   '計件計算20150112
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable
    Dim dtFIM As DataTable = New DataTable
    Dim T1新增CB As String = "Y" : Dim T2新增CB As String = "Y" : Dim T3新增CB As String = "Y"    '
    Dim T3防呆1A As String = "N"    '品項   Y = 錯誤
    Dim T3防呆2A As String = "N"    '時間   Y = 錯誤
    Dim 是否計薪 As String = "Y"    '

    Private Sub 計件計算_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabContro初始化() : TabContro初始化()
        Tab1初始化() : Tab2初始化() : Tab3初始化()
        Me.TabControl1.TabPages.Remove(TabPage2)
        Me.TabControl1.TabPages.Remove(TabPage3)
        Me.TabControl1.TabPages.Remove(TabPage4)

        La目前作業.Text = "派單作業"
        La作業樓層.Text = "2F"
        作業01_派單新增_單據查詢() : T1新增CB = "N"
    End Sub

    Private Sub TabContro初始化()
        Me.TabControl1.SelectedTab = Me.TabPage4
        Me.TabControl1.SelectedTab = Me.TabPage3
        Me.TabControl1.SelectedTab = Me.TabPage2
        Me.TabControl1.SelectedTab = Me.TabPage1

    End Sub

    '作業01_派單新增
    Private Sub Tab1初始化()
        L1作業單號.Text = ""
        L1作業日期.Text = ""

    End Sub

    Private Sub 載入雞種_初始化()
        If ks1DataSetDGV.Tables.Contains("雞種代號sALL") Then : ks1DataSetDGV.Tables("雞種代號sALL").Clear() : End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Try
            SQLCmd.CommandText = "    SELECT [No] AS '代號', [Kind] AS '雞種' FROM [Z_KS_CKind]  ORDER BY [Sid] "
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "雞種代號sALL")
            If ks1DataSetDGV.Tables("雞種代號sALL").Rows.Count > 0 Then
                '雞種s.DataSource = DataSetDGV.Tables("雞種代號sALL")
                '雞種s.DisplayMember = "雞種"
                '雞種s.SelectedIndex = -1

            Else

                '雞種s.Text = ""
                MsgBox("無雞種資料")
            End If
        Catch ex As Exception
            MsgBox("載入雞種: " & ex.Message)
            Exit Sub
        End Try
    End Sub


    '作業01_派單新增_查詢
    Private Sub 作業01_派單新增_單據查詢()
        If T1DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV1").Clear() : End If '清除T1DGV1資料
        Dim SQLADD As String = ""

        'SQLADD = "     SELECT [PW00] AS '單號', [PW01] AS '日期', [PW05] AS '樓層', [PW06] AS '人數', [PW0ID] AS 'ID' FROM [KaiShingPlug].[dbo].[PB_PieceWork00] "
        SQLADD = "     SELECT [PW00] AS '單號', [PW01] AS '日期', [PW05] AS '樓層', [PW06] AS '人數', [PW0ID] AS 'ID', '0' AS '代號' FROM [KaiShingPlug].[dbo].[PB_PieceWork00] "
        SQLADD += "     WHERE [PW90] = 'Y' AND [PW91] = 'N' AND [PW05] = '" & La作業樓層.Text & "' ORDER BY 2 DESC,1 ASC "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV1")
            T1DGV1.DataSource = ks1DataSetDGV.Tables("T1DGV1")
            If T1新增CB = "Y" Then
                'Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                checkBoxColumn.Width = 30
                T1DGV1.Columns.Insert(0, checkBoxColumn)
                '---測試
                'Dim column As New DataGridViewComboBoxColumn()
                'column.Name = "下拉"
                'T1DGV1.Columns.Insert(6, checkBoxColumn2)
                ''Dim col2 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
                ''col2.HeaderText = "下拉"
                ''T1DGV1.Columns.Insert(1, col2)
                ''T1DGV1.Columns.Add(col2)
                'checkBoxColumn2.Items.Add(21)
                'checkBoxColumn2.Items.Add(22)
                '載入雞種_初始化()
                '' ''    'Dim combo As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn
                'Dim combo As New DataGridViewComboBoxColumn
                'combo.DataSource = ks1DataSetDGV.Tables("雞種代號sALL")
                'combo.DataPropertyName = "代號"
                'combo.DisplayMember = "雞種"
                'combo.ValueMember = "代號"
                'combo.HeaderText = "雞種"
                'combo.Width = 200
                'T1DGV1.Columns.Insert(7, combo)
                'T1DGV1.Columns.Add(combo)
                '' ''    '---
            End If
            作業01_派單新增_單據查詢_Play()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業01_派單新增_單據查詢_Play()

        'Dim column As New DataGridViewComboBoxColumn()

        For Each column As DataGridViewColumn In T1DGV1.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 1 : column.Width = 80
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 2 : column.Width = 150
                Case "樓層" : column.HeaderText = "樓層" : column.DisplayIndex = 3 : column.Width = 70
                Case "人數" : column.HeaderText = "人數" : column.DisplayIndex = 4 : column.Width = 70
                Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 5 : column.Width = 30 : column.Visible = False
                    'Case "代號" : column.DisplayIndex = 6 : column.Width = 80 ' : column.ReadOnly = False
                    'Case "雞種" : column.DisplayIndex = 7 : column.Width = 200 : column.ReadOnly = False
                    '    'Case "下拉" : column.DisplayIndex = 6 : column.Width = 80 : column.ReadOnly = False
                    'Case "下拉" : column.HeaderText = "下拉" : column.DisplayIndex = 6 : column.Width = 80
                    '    Dim checkBoxColumn As New DataGridViewComboBoxColumn()
                    '    'checkBoxColumn.Name = "選擇"
                    '    T1DGV1.Columns.Insert(6, checkBoxColumn)
                Case Else
                    column.Visible = False
            End Select
        Next

        'For Each column2 As DataGridViewComboBoxColumn In T1DGV1.Columns
        '    column2.Visible = True : column2.ReadOnly = True
        '    Select Case column2.Name
        '        Case "下拉" : column2.DisplayIndex = 6 : column2.Width = 80 : column2.ReadOnly = False
        '        Case Else
        '            column2.Visible = False
        '    End Select
        'Next


    End Sub

    Private Sub T1DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T1DGV1.CellClick
        If T1DGV1.RowCount = 0 Then : L1作業單號.Text = "" : Exit Sub
        Else
            L1作業單號.Text = T1DGV1.CurrentRow.Cells("單號").Value
            L1作業日期.Text = Mid(T1DGV1.CurrentRow.Cells("日期").Value, 1, 10)

            作業01_派單新增_單據人員查詢()
        End If

    End Sub

    Private Sub 作業01_派單新增_單據人員查詢()
        If T1DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV2").Clear() : End If '清除T1DGV2資料
        Dim SQLADD As String = ""

        SQLADD = "     SELECT [PW00] AS '員編', [PW01] AS '姓名' FROM [KaiShingPlug].[dbo].[PB_PieceWork02] WHERE [PW0ID] = '" & L1作業單號.Text & "' AND [PW90] = 'Y' ORDER BY 1 "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T1DGV2")
            T1DGV2.DataSource = ks1DataSetDGV.Tables("T1DGV2")
            T1DGV2.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '作業01_派單新增_按鈕
    Private Sub T1派單新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1派單新增.Click
        Tab2初始化()
        La目前作業.Text = "新增派單"
        Me.TabControl1.TabPages.Add(TabPage2)
        Me.TabControl1.SelectedTab = Me.TabPage2
        Me.TabControl1.TabPages.Remove(TabPage1)
        作業02_單據新增_新增單號查詢()
        作業02_單據新增_人員名單查詢()
        作業02_單據新增_作業人員查詢()
        作業02_單據新增_作業人員比對()
        T2新增CB = "N"

    End Sub

    Private Sub T1派單修改_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1派單修改.Click
        If L1作業單號.Text = "" Then : Exit Sub : End If
        Tab2初始化()
        La目前作業.Text = "修改派單"
        Me.TabControl1.TabPages.Add(TabPage2)
        Me.TabControl1.SelectedTab = Me.TabPage2
        Me.TabControl1.TabPages.Remove(TabPage1)
        L2作業單號.Text = L1作業單號.Text
        '作業02_單據新增_新增單號查詢()
        作業02_單據新增_人員名單查詢()
        作業02_單據新增_作業人員查詢()
        作業02_單據新增_作業人員比對()
        T2新增CB = "N"

    End Sub

    Private Sub T1派單作廢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1派單作廢.Click
        Dim CntT24 As Integer = 0
        For Each oRow As DataGridViewRow In T1DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then
                CntT24 += 0 + 1
            End If
        Next

        If CntT24 > 0 Then
            T1派單作廢.Enabled = False
            If T1派單作廢.Enabled = False Then
                Dim oAns As Integer
                oAns = MsgBox("是否要作廢派單?  作廢 " & CntT24 & "筆", MsgBoxStyle.YesNo, "確認作廢")
                If oAns = MsgBoxResult.Yes Then  'Yes執行區
                    作業01_派單新增_派單作廢回存()
                    作業01_派單新增_單據查詢()
                    If T1DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV2").Clear() : End If '清除T1DGV2資料
                End If
            End If
            T1派單作廢.Enabled = True
        Else
            MsgBox("未選擇派單無法作廢") : Exit Sub
        End If
    End Sub

    Private Sub T1輸入資料_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T1輸入資料.Click
        If L1作業單號.Text = "" Then : Exit Sub : End If
        Tab3初始化()
        La目前作業.Text = "資料輸入"
        Me.TabControl1.TabPages.Add(TabPage3)
        Me.TabControl1.SelectedTab = Me.TabPage3
        Me.TabControl1.TabPages.Remove(TabPage1)
        L3作業單號.Text = L1作業單號.Text
        L3作業日期.Text = L1作業日期.Text
        '作業03_資料輸入_品項查詢()
        T3查詢品項.Visible = False
        GroupBox2.Visible = True
        T3DGV1.Visible = False
        作業03_資料輸入_單據品項查詢()
        T3新增CB = "N"

    End Sub

    '作業01_派單新增_回存
    Private Sub 作業01_派單新增_派單作廢回存()
        Dim SQLADD As String = ""

        For Each oRow As DataGridViewRow In T1DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then
                SQLADD += " UPDATE [KaiShingPlug].[dbo].[PB_PieceWork00] SET [PW90] = 'N', [PW93] = GETDATE() "
                SQLADD += "   FROM [KaiShingPlug].[dbo].[PB_PieceWork00] WHERE [PW0ID] = '" & oRow.Cells("ID").Value & "' AND [PW00] = '" & L1作業單號.Text & "' AND [PW90] = 'Y' "
            End If
        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("刪除完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    '作業02_單據新增
    Private Sub Tab2初始化()
        If T2DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV1").Clear() : End If '清除T2DGV1資料
        If T2DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV2").Clear() : End If '清除T2DGV1資料
        'ks1DataSetDGV.Tables("T2DGVFIM").Clear()
        dt1.Clear() : dt2.Clear() : dtFIM.Clear()

        L2作業單號.Text = ""
        L2計薪薪別.Text = ""
        L2作業人數.Text = ""

    End Sub

    '作業02_單據新增_查詢
    Private Sub 作業02_單據新增_新增單號查詢()
        Dim 日期樓層 As String = Format(T1Date.Value.Date, "yyyyMMdd") & La作業樓層.Text

        If T2DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGVFIM").Clear() : End If '清除T2DGV1資料
        Dim SQLADD As String = ""

        SQLADD = "     SELECT TOP 1 [PW00] FROM [KaiShingPlug].[dbo].[PB_PieceWork00] WHERE SUBSTRING([PW00],1,10) = '" & 日期樓層 & "' ORDER BY 1 DESC "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGVFIM")
            'Dim dtFIM As DataTable = ks1DataSetDGV.Tables("T2DGVFIM")
            dtFIM = ks1DataSetDGV.Tables("T2DGVFIM")

            Dim D新增單號 As String = "" : Dim S新增單號 As String = ""
            If dtFIM.Rows.Count > 0 Then
                D新增單號 = Mid(dtFIM.Rows(0).Item("PW00"), 1, 10)
                S新增單號 = D新增單號 & CStr(Format(CInt(Mid(dtFIM.Rows(0).Item("PW00"), 11, 5)) + 1, "00000"))
            Else
                S新增單號 = 日期樓層 & "00001"
            End If
            L2作業單號.Text = S新增單號

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業02_單據新增_人員名單查詢()
        If T2DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV1").Clear() : End If '清除T2DGV1資料
        Dim SQLADD As String = ""

        SQLADD = "     SELECT [IC01] AS '姓名',[IC00] AS '員編',[ICP0] AS '薪別' FROM [KaiShingPlug].[dbo].[PB_PieceBasic03] WHERE [IC90] = 'Y' ORDER BY 3, 2 "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV1")
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV1s")
            dt1 = ks1DataSetDGV.Tables("T2DGV1")
            dt2 = ks1DataSetDGV.Tables("T2DGV1s")
            T2DGV1.DataSource = dt1
            'T2DGV1.DataSource = ks1DataSetDGV.Tables("T2DGV1")
            If T2新增CB = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                T2DGV1.Columns.Insert(0, checkBoxColumn)
            End If
            作業02_單據新增_人員名單查詢_Play()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub 作業02_單據新增_人員名單查詢_Play()
        For Each column As DataGridViewColumn In T2DGV1.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                Case "姓名" : column.HeaderText = "姓名" : column.DisplayIndex = 1 : column.Width = 90 ' : column.ReadOnly = True
                Case "員編" : column.HeaderText = "員編" : column.DisplayIndex = 2 : column.Width = 90 ' : column.ReadOnly = True
                Case "薪別" : column.HeaderText = "薪別" : column.DisplayIndex = 3 : column.Width = 70 ' : column.ReadOnly = True
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub 作業02_單據新增_作業人員查詢()
        If T2DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T2DGV2").Clear() : End If '清除T2DGV2資料
        Dim SQLADD As String = ""

        SQLADD = "     SELECT [PW0ID] AS '單號', [PW00] AS '員編', [PW01] AS '姓名', [PW02] AS '薪別' FROM [KaiShingPlug].[dbo].[PB_PieceWork02] WHERE [PW0ID] = '" & L2作業單號.Text & "' AND [PW90] = 'Y' ORDER BY 4, 2 "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T2DGV2")
            T2DGV2.DataSource = ks1DataSetDGV.Tables("T2DGV2")
            If T2新增CB = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                T2DGV2.Columns.Insert(0, checkBoxColumn)
            End If
            作業02_單據新增_作業人員查詢_Play()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業02_單據新增_作業人員查詢_Play()
        For Each column As DataGridViewColumn In T2DGV2.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                Case "姓名" : column.HeaderText = "姓名" : column.DisplayIndex = 1 : column.Width = 90
                Case "員編" : column.HeaderText = "員編" : column.DisplayIndex = 2 : column.Width = 90
                Case "薪別" : column.HeaderText = "薪別" : column.DisplayIndex = 3 : column.Width = 70
                Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 4 : column.Width = 70 : column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub 作業02_單據新增_作業人員比對()
        If T2DGV1.RowCount > 0 Then : dt1.Clear() : End If '清除dt1資料
        dt1 = dt2.Copy : T2DGV1.DataSource = dt1

        Dim counti As Integer = T2DGV2.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim countx As Integer = T2DGV1.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If T2DGV2.Rows(i).Cells("員編").Value = T2DGV1.Rows(x).Cells("員編").Value Then
                    T2DGV1.Rows.Remove(T2DGV1.Rows(x))
                End If
            Next
        Next
        作業02_單據新增_作業人員查詢_Play()
        L2作業人數.Text = T2DGV2.RowCount
        日月薪()

    End Sub

    Private Sub 日月薪()
        Dim CntT21 As Integer = 0 : Dim CntT22 As Integer = 0
        For i As Integer = 0 To T2DGV2.RowCount - 1
            If T2DGV2.Rows(i).Cells("薪別").Value = "月薪" Then
                CntT21 += 0 + 1
            End If
            If T2DGV2.Rows(i).Cells("薪別").Value = "日薪" Then
                CntT22 += 0 + 1
            End If
        Next

        If CntT21 > 0 Then
            L2計薪薪別.Text = "月薪"
        Else
            If CntT22 <> 0 Then
                L2計薪薪別.Text = "日薪"
            Else
                L2計薪薪別.Text = ""
            End If
        End If

    End Sub

    '作業02_單據新增_按鈕
    Private Sub T2人員新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2人員新增.Click
        For Each oRow As DataGridViewRow In T2DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            Dim Row As DataRow
            Row = ks1DataSetDGV.Tables("T2DGV2").NewRow
            If isSelected Then
                Row.Item("姓名") = oRow.Cells("姓名").Value
                Row.Item("員編") = oRow.Cells("員編").Value
                Row.Item("薪別") = oRow.Cells("薪別").Value
                Row.Item("單號") = L2作業單號.Text
                ks1DataSetDGV.Tables("T2DGV2").Rows.Add(Row)
            End If
        Next
        作業02_單據新增_作業人員比對()

    End Sub

    Private Sub T2人員移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2人員移除.Click
        Dim count As Integer = T2DGV2.Rows.Count
        For i As Integer = count - 1 To 0 Step -1
            Dim isSelected As Boolean = Convert.ToBoolean(T2DGV2.Rows(i).Cells("選擇").Value)
            If isSelected Then
                T2DGV2.Rows.Remove(T2DGV2.Rows(i))
            End If
        Next
        作業02_單據新增_作業人員比對()

    End Sub

    Private Sub T2單據存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2單據存檔.Click
        If L2計薪薪別.Text = "" Or L2作業人數.Text = 0 Then
            MsgBox("資料有誤") : Exit Sub
        End If
        Select Case La目前作業.Text
            Case "新增派單"
                作業02_單據新增_作業人員回存()
            Case "修改派單"
                作業02_單據新增_作業人員修改回存()
            Case Else
        End Select
        作業02_單據新增_離開初始化()
        Tab2初始化()

    End Sub

    Private Sub T2放棄新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T2放棄新增.Click
        作業02_單據新增_離開初始化()
        Tab2初始化()

    End Sub

    Private Sub 作業02_單據新增_離開初始化()
        Tab1初始化()
        '完成作業回派單作業
        La目前作業.Text = "派單作業"
        Me.TabControl1.TabPages.Add(TabPage1)
        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.TabControl1.TabPages.Remove(TabPage2)
        If T1DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV2").Clear() : End If '清除T1DGV2資料
        作業01_派單新增_單據查詢()

    End Sub

    '作業02_單據新增_回存
    Private Sub 作業02_單據新增_作業人員回存()
        Dim SQLADD As String = ""
        SQLADD = "   INSERT INTO [KaiShingPlug].[dbo].[PB_PieceWork00] ([PW90],[PW91],[PW92],[PWA1],[PWA3],[PWA5],[PW00],[PW01],[PW03],[PW05],[PW06]) VALUES "
        SQLADD += " ('Y', 'N', GETDATE(), 'N', 'N', 'N', "
        SQLADD += "  '" & L2作業單號.Text & "' ,"
        SQLADD += "  '" & Format(T1Date.Value.Date, "yyyy-MM-dd") & "', "
        SQLADD += "  '" & L2計薪薪別.Text & "', "
        SQLADD += "  '" & La作業樓層.Text & "', "
        SQLADD += "  '" & L2作業人數.Text & "') "

        For i As Integer = 0 To T2DGV2.RowCount - 1
            SQLADD += "  INSERT INTO [KaiShingPlug].[dbo].[PB_PieceWork02] ([PW0ID],[PW90],[PW92],[PW00],[PW01],[PW02]) VALUES "
            SQLADD += " ('" & L2作業單號.Text & "', 'Y', GETDATE(),    "
            SQLADD += "  '" & T2DGV2.Rows(i).Cells("員編").Value & "', "
            SQLADD += "  '" & T2DGV2.Rows(i).Cells("姓名").Value & "', "
            SQLADD += "  '" & T2DGV2.Rows(i).Cells("薪別").Value & "') "

        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("單號" & L2作業單號.Text & "新增完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業02_單據新增_作業人員修改回存()
        Dim SQLADD As String = ""
        SQLADD = "  UPDATE [KaiShingPlug].[dbo].[PB_PieceWork00] SET [PW93] = GETDATE(), [PW03] = '" & L2計薪薪別.Text & "', [PW06] = '" & L2作業人數.Text & "' "
        SQLADD += "   FROM [KaiShingPlug].[dbo].[PB_PieceWork00] WHERE [PW00]  = '" & L2作業單號.Text & "' AND [PW90] = 'Y' "

        SQLADD += " UPDATE [KaiShingPlug].[dbo].[PB_PieceWork02] SET [PW90] = 'N', [PW93] = GETDATE() "
        SQLADD += "   FROM [KaiShingPlug].[dbo].[PB_PieceWork02] WHERE [PW0ID] = '" & L2作業單號.Text & "' AND [PW90] = 'Y' "
        For i As Integer = 0 To T2DGV2.RowCount - 1
            SQLADD += "  INSERT INTO [KaiShingPlug].[dbo].[PB_PieceWork02] ([PW0ID],[PW90],[PW92],[PW00],[PW01],[PW02]) VALUES "
            SQLADD += " ('" & L2作業單號.Text & "', 'Y', GETDATE(),    "
            SQLADD += "  '" & T2DGV2.Rows(i).Cells("員編").Value & "', "
            SQLADD += "  '" & T2DGV2.Rows(i).Cells("姓名").Value & "', "
            SQLADD += "  '" & T2DGV2.Rows(i).Cells("薪別").Value & "') "

        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("單號" & L2作業單號.Text & "更新完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    '作業03_資料輸入
    Private Sub Tab3初始化()
        If T3DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T3DGV1").Clear() : End If '清除T3DGV1資料
        If T3DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T3DGV2").Clear() : End If '清除T3DGV2資料

        L3作業單號.Text = "" : L3作業日期.Text = ""
        L3品項代碼.Text = "" : L3品項品名.Text = "" : L3品項單位.Text = "" : T3生產數量.Text = ""
        L3開始時間.Text = "" : L3結束時間.Text = ""

        L3品項ID.Text = ""
        L3參數班別.Text = "" : L3參數數量.Text = ""
        L3參開始時.Text = "" : L3參開始分.Text = "" : L3參結束時.Text = "" : L3參結束分.Text = ""

        L3凍藏.Text = "" : L3品類.Text = "" : L3分類.Text = "" : L3製成.Text = "" : L3包裝.Text = ""

    End Sub

    Private Sub T3查詢品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3查詢品項.Click
        L3凍藏.Text = "" : L3品類.Text = "" : L3分類.Text = "" : L3製成.Text = "" : L3包裝.Text = ""

        T3DGV1.Visible = False
        GroupBox2.Visible = True
        T3查詢品項.Visible = False

    End Sub

    Private Sub T3列出品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3列出品項.Click

        作業03_資料輸入_品項查詢()
        T3DGV1.Visible = True
        GroupBox2.Visible = False
        T3查詢品項.Visible = True
        L3凍藏.Text = C3凍藏.Text : L3品類.Text = C3品類.Text : L3分類.Text = C3分類.Text : L3製成.Text = C3製成.Text : L3包裝.Text = C3包裝.Text

    End Sub

    Private Sub C3品類_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C3品類.SelectedValueChanged, C3品類.SelectedIndexChanged
        C3分類.Items.Clear()
        Select Case Mid(C3品類.Text, 1, 1)
            Case "1"
                C3分類.Items.Add("01. 土切存編")
                C3分類.Items.Add("02. 人土切存編")
                C3分類.Items.Add("03. 烏切存編")
                C3分類.Items.Add("04. 二翅存編")
                C3分類.Items.Add("05. 三翅存編")
                C3分類.Items.Add("06. 翅腿存編")
                C3分類.Items.Add("07. 胸肉存編")
                C3分類.Items.Add("08. 里肌存編")
                C3分類.Items.Add("09. 腿切存編")
            Case "2"
                C3分類.Items.Add("01. 全雞存編")
                C3分類.Items.Add("02. 上半身存編")
            Case "3"
                C3分類.Items.Add("01. 心存編")
                C3分類.Items.Add("02. 肫存編")
            Case Else
                C3分類.Items.Clear()
        End Select
    End Sub


    '作業03_資料輸入_查詢
    Private Sub 作業03_資料輸入_品項查詢()
        If T3DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("T3DGV1").Clear() : End If '清除T3DGV1資料
        Dim SQLADD As String = "" : Dim IC04 As String = ""
        IC04 = Mid(C3凍藏.Text, 1, 1) & Mid(C3品類.Text, 1, 1) & Mid(C3分類.Text, 1, 2) & Mid(C3製成.Text, 1, 1) & Mid(C3包裝.Text, 1, 1)

        'SQLADD = " SELECT  [IC01] AS '品名', [IC00] AS '代碼',[IC03] AS '單位' FROM [KaiShingPlug].[dbo].[PB_PieceBasic01] WHERE [IC90] = 'Y' "
        SQLADD = " SELECT  [IC01] AS '品名', [IC00] AS '代碼',[IC03] AS '單位' FROM [KaiShingPlug].[dbo].[PB_PieceBasic01] WHERE [IC04] = '" & IC04 & "' AND [IC90] = 'Y' "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T3DGV1")
            T3DGV1.DataSource = ks1DataSetDGV.Tables("T3DGV1")
            T3DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub T3DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T3DGV1.CellClick
        If T3DGV1.RowCount = 0 Then : Exit Sub
        Else
            L3品項代碼.Text = T3DGV1.CurrentRow.Cells("代碼").Value
            L3品項品名.Text = T3DGV1.CurrentRow.Cells("品名").Value
            L3品項單位.Text = T3DGV1.CurrentRow.Cells("單位").Value
        End If

    End Sub

    Private Sub 作業03_資料輸入_單據品項查詢()
        If T3DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T3DGV2").Clear() : End If '清除T3DGV2資料
        Dim SQLADD As String = ""

        SQLADD = "    SELECT [PW01] AS '班次',[PW11] AS '代碼',[PW12] AS '品名',[PW15] AS '數量',[PW14] AS '單位',CONVERT(VARCHAR(256),[PW02],120) AS '開始',CONVERT(VARCHAR(256),[PW03],120) AS '結束',CASE [PW91] WHEN 'Y' THEN '計薪' ELSE '不計' END AS '計薪否',[PW1ID] AS 'ID' "
        SQLADD += "     FROM [KaiShingPlug].[dbo].[PB_PieceWork01] "
        SQLADD += "    WHERE [PW0ID] = '" & L3作業單號.Text & "' AND [PW90] = 'Y' "
        SQLADD += " ORDER BY 1, 2, 6 "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "T3DGV2")
            T3DGV2.DataSource = ks1DataSetDGV.Tables("T3DGV2")
            'T3DGV2.AutoResizeColumns()
            If T3新增CB = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                T3DGV2.Columns.Insert(0, checkBoxColumn)
            End If
            作業03_資料輸入_單據品項查詢_Play()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業03_資料輸入_單據品項查詢_Play()
        T3DGV2.AutoResizeColumns()
        For Each column As DataGridViewColumn In T3DGV2.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                    Select Case T3新增品項.Text
                        Case "新增" : column.Visible = False
                        Case "放棄修改" : column.Visible = True
                            'Case Else : column.Visible = False
                    End Select
                Case "班次" : column.HeaderText = "班次" : column.DisplayIndex = 1 ' : column.Width = 50
                Case "代碼" : column.HeaderText = "代碼" : column.DisplayIndex = 2 ' : column.Width = 90
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3 ' : column.Width = 70
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 4 ' : column.Width = 70
                Case "單位" : column.HeaderText = "單位" : column.DisplayIndex = 5 ' : column.Width = 70
                Case "開始" : column.HeaderText = "開始" : column.DisplayIndex = 6 ': column.Width = 70
                Case "結束" : column.HeaderText = "結束" : column.DisplayIndex = 7 ': column.Width = 70
                Case "計薪否" : column.HeaderText = "計薪否" : column.DisplayIndex = 8 ': column.Width = 70
                Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 9 : column.Width = 30 : column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub T3DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles T3DGV2.CellClick
        If T3新增品項.Text = "新增" Then : Exit Sub
        Else
            L3品項ID.Text = T3DGV2.CurrentRow.Cells("ID").Value
            T3作業班別.Text = T3DGV2.CurrentRow.Cells("班次").Value
            T3生產數量.Text = T3DGV2.CurrentRow.Cells("數量").Value
            L3品項代碼.Text = T3DGV2.CurrentRow.Cells("代碼").Value
            L3品項品名.Text = T3DGV2.CurrentRow.Cells("品名").Value
            L3品項單位.Text = T3DGV2.CurrentRow.Cells("單位").Value
            T3開始H.Text = Mid(T3DGV2.CurrentRow.Cells("開始").Value, 12, 2)
            T3開始M.Text = Mid(T3DGV2.CurrentRow.Cells("開始").Value, 15, 2)
            T3結束H.Text = Mid(T3DGV2.CurrentRow.Cells("結束").Value, 12, 2)
            T3結束M.Text = Mid(T3DGV2.CurrentRow.Cells("結束").Value, 15, 2)
            If T3DGV2.CurrentRow.Cells("計薪否").Value = "計薪" Then : C3計薪.Checked = True : Else : C3計薪.Checked = False : End If

        End If

    End Sub

    '作業03_資料輸入_按鈕
    Private Sub T3新增品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3新增品項.Click
        作業03_防呆()
        Select Case T3新增品項.Text
            Case "新增"
                T3時間計算()
                If T3防呆1A = "Y" Then : MsgBox("資料未輸入或有錯誤，請先確認") : Exit Sub : End If
                If T3防呆2A = "Y" Then : MsgBox("時間未輸入或有錯誤，請先確認") : Exit Sub : End If
                作業03_資料輸入_品項回存()
                作業03_資料輸入_品項作業_初始化()
                作業03_資料輸入_單據品項查詢()
            Case "放棄修改"
                T3新增品項_初始化()
                T3新增品項.Text = "新增"
                作業03_資料輸入_品項作業_初始化()
                作業03_資料輸入_單據品項查詢_Play()
            Case Else
                MsgBox("未知動作1")
        End Select

    End Sub

    Private Sub T3修改品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3修改品項.Click
        作業03_防呆()
        Select Case T3新增品項.Text
            Case "新增"
                T3修改品項_初始化()
                T3新增品項.Text = "放棄修改"
                作業03_資料輸入_單據品項查詢_Play()
            Case "放棄修改"
                T3時間計算()
                If T3防呆1A = "Y" Then : MsgBox("資料未輸入或有錯誤，請先確認") : Exit Sub : End If
                If T3防呆2A = "Y" Then : MsgBox("時間未輸入或有錯誤，請先確認") : Exit Sub : End If
                作業03_資料輸入_品項修改回存()
                作業03_資料輸入_品項作業_初始化()
                作業03_資料輸入_單據品項查詢()
            Case Else
                MsgBox("未知動作2")
        End Select

    End Sub

    Private Sub 作業03_防呆()
        T3防呆1A = "N"

        L3參數班別.Text = T3作業班別.Text
        L3參數數量.Text = T3生產數量.Text

        If L3參數班別.Text = "" Then : T3防呆1A = "Y" : Exit Sub : Else : T3防呆1A = "N" : End If
        If L3參數數量.Text = "" Then : T3防呆1A = "Y" : Exit Sub : Else : T3防呆1A = "N" : End If
        If L3品項代碼.Text = "" Then : T3防呆1A = "Y" : Exit Sub : Else : T3防呆1A = "N" : End If

    End Sub

    Private Sub 作業03_資料輸入_品項作業_初始化()
        L3品項ID.Text = ""
        L3品項代碼.Text = "" : L3品項品名.Text = "" : L3品項單位.Text = "" : T3生產數量.Text = ""

        L3參數班別.Text = "" : L3參數數量.Text = ""
        L3參開始時.Text = "" : L3參開始分.Text = "" : L3參結束時.Text = "" : L3參結束分.Text = ""

    End Sub

    Private Sub T3新增品項_初始化()
        T3放棄新增.Enabled = True
        T3刪除品項.Visible = False
        T3DGV1.Visible = True

    End Sub

    Private Sub T3修改品項_初始化()
        T3放棄新增.Enabled = False
        T3刪除品項.Visible = True
        T3DGV1.Visible = False

    End Sub

    Private Sub T3刪除品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3刪除品項.Click
        Dim CntT23 As Integer = 0
        For Each oRow As DataGridViewRow In T3DGV2.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then
                CntT23 += 0 + 1
            End If
        Next

        If CntT23 > 0 Then
            T3刪除品項.Enabled = False
            If T3刪除品項.Enabled = False Then
                Dim oAns As Integer
                oAns = MsgBox("是否要刪除?  品項 " & CntT23 & "筆", MsgBoxStyle.YesNo, "確認刪除")
                If oAns = MsgBoxResult.Yes Then  'Yes執行區
                    作業03_資料輸入_品項刪除回存()
                    作業03_資料輸入_品項作業_初始化()
                    作業03_資料輸入_單據品項查詢()
                End If
            End If
            T3刪除品項.Enabled = True
        Else
            MsgBox("未選擇品項無法刪除") : Exit Sub
        End If

    End Sub


    Private Sub T3時間計算()
        'If T3時間H1.Text <> "" And T3時間H2.Text <> "" And T3時間M1.Text <> "" And T3時間M2.Text <> "" Then
        '    L3開始時間.Text = L3作業日期.Text & " " & T3時間H1.Text & T3時間H2.Text & ":" & T3時間M1.Text & T3時間M2.Text & ":00.000"
        'End If
        'If T3時間H3.Text <> "" And T3時間H4.Text <> "" And T3時間M3.Text <> "" And T3時間M4.Text <> "" Then
        '    L3結束時間.Text = L3作業日期.Text & " " & T3時間H3.Text & T3時間H4.Text & ":" & T3時間M3.Text & T3時間M4.Text & ":00.000"
        'End If

        L3參開始時.Text = T3開始H.Text : L3參開始分.Text = T3開始M.Text
        L3參結束時.Text = T3結束H.Text : L3參結束分.Text = T3結束M.Text

        T3防呆2A = "N"
        If L3參開始時.Text <> "" And L3參開始分.Text <> "" Then
            L3開始時間.Text = L3作業日期.Text & " " & L3參開始時.Text & ":" & L3參開始分.Text & ":00.000"
        Else
            T3防呆2A = "Y" : Exit Sub
        End If
        If L3參結束時.Text <> "" And L3參結束分.Text <> "" Then
            L3結束時間.Text = L3作業日期.Text & " " & L3參結束時.Text & ":" & L3參結束分.Text & ":00.000"
        Else
            T3防呆2A = "Y" : Exit Sub
        End If

        If L3開始時間.Text < L3結束時間.Text Then
            T3防呆2A = "N"
        Else
            T3防呆2A = "Y" ': MsgBox("時間錯誤") : Exit Sub
        End If

    End Sub

    Private Sub T3放棄新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles T3放棄新增.Click
        Tab1初始化()
        '完成作業回派單作業
        La目前作業.Text = "派單作業"
        Me.TabControl1.TabPages.Add(TabPage1)
        Me.TabControl1.SelectedTab = Me.TabPage1
        Me.TabControl1.TabPages.Remove(TabPage3)
        If T1DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("T1DGV2").Clear() : End If '清除T1DGV2資料
        作業01_派單新增_單據查詢()

    End Sub

    '作業03_資料輸入_回存
    Private Sub 作業03_資料輸入_品項回存()

        If C3計薪.Checked = True Then : 是否計薪 = "Y" : Else : 是否計薪 = "N" : End If
        Dim SQLADD As String = ""
        SQLADD = "   INSERT INTO [KaiShingPlug].[dbo].[PB_PieceWork01] ([PW0ID],[PW90],[PW91],[PW92],[PW01],[PW02],[PW03],[PW11],[PW12],[PW14],[PW15]) VALUES "
        SQLADD += " ('" & L3作業單號.Text & "', 'Y', '" & 是否計薪 & "', GETDATE(), "
        SQLADD += "  '" & T3作業班別.Text & "', "
        SQLADD += "  '" & L3開始時間.Text & "', "
        SQLADD += "  '" & L3結束時間.Text & "', "
        SQLADD += "  '" & L3品項代碼.Text & "', "
        SQLADD += "  '" & L3品項品名.Text & "', "
        SQLADD += "  '" & L3品項單位.Text & "', "
        SQLADD += "  '" & T3生產數量.Text & "') "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("品項" & L3品項品名.Text & "新增完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業03_資料輸入_品項修改回存()
        Dim SQLADD As String = ""
        If C3計薪.Checked = True Then : 是否計薪 = "Y" : Else : 是否計薪 = "N" : End If
        SQLADD += " UPDATE [KaiShingPlug].[dbo].[PB_PieceWork01] SET [PW91] = '" & 是否計薪 & "', [PW93] = GETDATE(), [PW01] = '" & T3作業班別.Text & "', [PW02] = '" & L3開始時間.Text & "', [PW03] = '" & L3結束時間.Text & "',[PW15] = '" & T3生產數量.Text & "' "
        SQLADD += "   FROM [KaiShingPlug].[dbo].[PB_PieceWork01] WHERE [PW1ID] = '" & L3品項ID.Text & "' AND [PW0ID] = '" & L3作業單號.Text & "' AND [PW90] = 'Y' "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("品項  " & L3品項品名.Text & "  更新完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 作業03_資料輸入_品項刪除回存()
        Dim SQLADD As String = ""

        For Each oRow As DataGridViewRow In T3DGV2.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then
                SQLADD += " UPDATE [KaiShingPlug].[dbo].[PB_PieceWork01] SET [PW90] = 'N', [PW93] = GETDATE() "
                SQLADD += "   FROM [KaiShingPlug].[dbo].[PB_PieceWork01] WHERE [PW1ID] = '" & oRow.Cells("ID").Value & "' AND [PW0ID] = '" & L3作業單號.Text & "' AND [PW90] = 'Y' " & vbCrLf
            End If
        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("刪除完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub






End Class