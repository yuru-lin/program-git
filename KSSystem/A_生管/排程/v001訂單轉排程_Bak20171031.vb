Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class v001訂單轉排程

    Dim MSSQL作業 As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim cb選擇客戶 As String = "Y"
    Dim 客戶ca As String
    Dim 客戶cb As String


    Private Sub 訂單轉排程_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Schedule載入() : 載入Cb初始()
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub Schedule載入()
        Dim SQLQuery As String = ""
        SQLQuery = PM_Lists.Schedule_Lists()

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "Period")

            CB時段.DataSource = 顯示資料.Tables("Period")
            CB時段.DisplayMember = "類別" '名稱
            CB時段.ValueMember = "代碼"      '編號SelectedValue
            CB時段.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("Period: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub 載入Cb初始()
        Cb客戶載入()

    End Sub

    Private Sub Cb客戶載入()

        Dim SQLQuery As String = ""
        SQLQuery = " SELECT * FROM (SELECT DISTINCT T0.[AliasName] AS '客戶名稱' FROM [Z_KS_SPdata0] T0 WHERE T0.Cancel = 'Y') T1 ORDER BY LEFT(T1.客戶名稱,1) COLLATE Chinese_Taiwan_Stroke_ci_as "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            MSSQL作業 = New SqlDataAdapter(SQLQuery, DBConn)
            MSSQL作業.Fill(顯示資料, "客戶")

            CB客戶.DataSource = 顯示資料.Tables("客戶")
            CB客戶.DisplayMember = "客戶名稱"
            CB客戶.SelectedIndex = -1

        Catch ex As Exception
            MsgBox("客戶: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub 客戶查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 客戶查詢.Click

        If DGV1.RowCount > 0 Then
            顯示資料.Tables("DT1").Clear()
        End If

        If DGV2.RowCount > 0 Then
            顯示資料.Tables("DT2").Clear()
        End If

        TB客戶編號.Text = ""
        TB客戶名稱.Text = ""
        TB簡稱.Text = ""

        '取得查詢資料
        GetDGV1Data()

    End Sub

    Private Sub GetDGV1Data()  '取得DGV1資料

        If DGV1.RowCount > 0 Then
            顯示資料.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            '草稿單
            sql = "  SELECT DISTINCT T0.[CardCode] AS '客戶代碼', T1.[CardName] AS '客戶名稱', T1.[AliasName] AS '簡稱' "
            sql += " FROM [ODRF] T0 INNER JOIN [Z_KS_SPdata0] T1 ON T0.CardCode = T1.CardCode AND T1.Cancel = 'Y' "
            sql += " WHERE T0.[DocDueDate] = '" & 日期.Value.Date & "' AND T1.[AliasName] = '" & CB客戶.Text & "' "
            sql += " UNION "
            '訂單      
            sql += " SELECT DISTINCT T0.[CardCode] AS '客戶代碼', T1.[CardName] AS '客戶名稱', T1.[AliasName] AS '簡稱' "
            sql += " FROM [ORDR] T0 INNER JOIN [Z_KS_SPdata0] T1 ON T0.CardCode = T1.CardCode AND T1.Cancel = 'Y' "
            sql += " WHERE T0.[DocDueDate] = '" & 日期.Value.Date & "' AND T1.[AliasName] = '" & CB客戶.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            MSSQL作業 = New SqlDataAdapter(sql, DBConn)
            MSSQL作業.Fill(顯示資料, "DT1")
            DGV1.DataSource = 顯示資料.Tables("DT1")
            TransactionMonitor.Complete()


            '當 選擇客戶 = "Y" 時，新增一欄 '勾選' 欄位
            If cb選擇客戶 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                checkBoxColumn.Width = 30
                DGV1.Columns.Insert(0, checkBoxColumn)
            End If

            '新增完後關閉(才不會重覆出現)
            cb選擇客戶 = "N"

        End Using

        DGV1Display()

    End Sub

    Private Sub DGV1Display()  '載入DGV1資料畫面

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True : column.ReadOnly = True

            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.ReadOnly = False
                Case "客戶代碼" : column.HeaderText = "客戶代碼" : column.DisplayIndex = 1 : column.ReadOnly = True
                Case "客戶名稱" : column.HeaderText = "客戶名稱" : column.DisplayIndex = 2 : column.ReadOnly = True
                Case "簡稱" : column.HeaderText = "簡稱" : column.DisplayIndex = 3 : column.ReadOnly = True

                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 明細查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 明細查詢.Click

        If DGV2.RowCount > 0 Then
            顯示資料.Tables("DT2").Clear()
        End If


        Dim a As Integer = 0
        客戶ca = "" : 客戶cb = ""

        For r As Integer = 0 To DGV1.RowCount - 1
            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(r).Cells("選擇").Value)
            If isSelected = True Then

                'If a = 0 Then
                'If DGV1.CurrentRow.Cells("客戶代碼").Value = DGV1.Rows(r).Cells("客戶代碼").Value And DGV1.CurrentRow.Cells("客戶名稱").Value = DGV1.Rows(r).Cells("客戶名稱").Value And DGV1.CurrentRow.Cells("簡稱").Value = DGV1.Rows(r).Cells("簡稱").Value Then
                '    TB客戶編號.Text = DGV1.CurrentRow.Cells("客戶代碼").Value
                '    TB客戶名稱.Text = DGV1.CurrentRow.Cells("客戶名稱").Value
                '    TB簡稱.Text = DGV1.CurrentRow.Cells("簡稱").Value

                If 客戶ca = "" Then
                    客戶ca = 客戶ca + Format(DGV1.Rows(r).Cells("客戶代碼").Value, "")
                Else
                    客戶ca = 客戶ca + "," + Format(DGV1.Rows(r).Cells("客戶代碼").Value, "")
                End If

                'End If

            End If

        Next

        'a = a + 1
        客戶cb = Format(Replace(客戶ca, ",", "','"), "")

        訂單明細()

        'TB客戶編號.Text = 客戶cb


        'For i = 0 To DGV1.RowCount - 1
        '    Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(i).Cells("選擇").Value)
        '    If isSelected = True Then
        '        If DGV1.Rows(i).Cells("客戶代碼").Value = DGV1.CurrentRow.Cells("客戶代碼").Value Then
        '            'If DGV1.CurrentRow.Cells("客戶代碼").Value Like 客戶cb Then
        '            TB客戶編號.Text = DGV1.CurrentRow.Cells("客戶代碼").Value
        '            'End If
        '        End If
        '    End If
        'Next



        '客戶cb = DGV1.CurrentRow.Cells("客戶代碼").Value
        'For i = 0 To DGV1.RowCount - 1
        '    Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(i).Cells("選擇").Value)
        '    If isSelected = True Then
        '        If DGV1.Rows(i).Cells("客戶代碼").Value = DGV1.CurrentRow.Cells("客戶代碼").Value Then
        '            客戶cb = 客戶cb & DGV1.Rows(i).Cells("客戶代碼").Value
        '            If 客戶cb.Substring(0, 10) = DGV1.CurrentRow.Cells("客戶代碼").Value Then
        '                TB客戶編號.Text = DGV1.CurrentRow.Cells("客戶代碼").Value
        '                TB客戶名稱.Text = DGV1.CurrentRow.Cells("客戶名稱").Value
        '                TB簡稱.Text = DGV1.CurrentRow.Cells("簡稱").Value
        '            End If
        '        End If
        '    End If
        'Next


        DGV2Display()

        TB人數.Text = ""
        CB樓層.Text = ""
        CB時段.Text = ""
        TB排程.Text = ""
        TB製單.Text = ""
        CB製單.Text = ""

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        ''TB客戶編號.Text = 客戶cb
        'Dim 客戶 As String = "[" & 客戶ca & "]"
        'Dim 客戶1 As Boolean = CStr(DGV1.CurrentRow.Cells("客戶代碼").Value) Like 客戶
        'MsgBox(DGV1.CurrentRow.Cells("客戶代碼").Value & "  " & 客戶)
        'MsgBox(客戶1)
        'If 客戶ca <> "" Then
        '    If 客戶1 Then
        '        TB客戶編號.Text = DGV1.CurrentRow.Cells("客戶代碼").Value
        '        MsgBox("1")
        '    End If
        'End If
        ''MsgBox("2")


        'If 客戶ca <> "" Then
        For i = 0 To DGV1.RowCount - 1
            Dim isSelected As Boolean = Convert.ToBoolean(DGV1.Rows(i).Cells("選擇").Value)
            If isSelected = True Then
                If DGV1.Rows(i).Cells("客戶代碼").Value = DGV1.CurrentRow.Cells("客戶代碼").Value And DGV1.Rows(i).Cells("客戶名稱").Value = DGV1.CurrentRow.Cells("客戶名稱").Value And DGV1.Rows(i).Cells("簡稱").Value = DGV1.CurrentRow.Cells("簡稱").Value Then
                    'If DGV1.CurrentRow.Cells("客戶代碼").Value Like 客戶cb Then
                    TB客戶編號.Text = DGV1.CurrentRow.Cells("客戶代碼").Value
                    TB客戶名稱.Text = DGV1.CurrentRow.Cells("客戶名稱").Value
                    TB簡稱.Text = DGV1.CurrentRow.Cells("簡稱").Value
                    'End If
                End If
            End If
        Next
        'End If
    End Sub

    Private Sub 訂單明細()

        If TB客戶編號.Text = "" Then
            MsgBox("客戶未選擇", 16, "錯誤")
            TB人數.Focus()
            Exit Sub
        End If

        If TB客戶名稱.Text = "" Then
            MsgBox("客戶未選擇", 16, "錯誤")
            TB人數.Focus()
            Exit Sub
        End If

        If TB簡稱.Text = "" Then
            MsgBox("客戶未選擇", 16, "錯誤")
            TB人數.Focus()
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = " SELECT CASE SUBSTRING(T1.存編,4,1) WHEN '1' THEN '全雞' WHEN '2' THEN '分切' WHEN '5' THEN '全雞' WHEN '6' THEN '分切' WHEN '7' THEN '全雞' WHEN '8' THEN '分切' ELSE '' END AS '類別', "
            sql += "       T1.存編, T1.品名, CAST(SUM(T1.數量) AS NUMERIC(19,0)) AS '數量', CAST(SUM(T1.數量) AS NUMERIC(19,0)) AS '生產數量', T2.[Plate_H] AS '工時基數', T2.[Weight] AS '原料基數', '0' AS '工時', '0' AS '重量',T2.[Sid] "
            sql += " FROM ( "
            sql += "       SELECT T0.[DocEntry] AS '草稿單號', T0.[CardCode] AS '客編', T0.[CardName] AS '客戶', T2.[ItemCode] AS '存編', T2.[ItemName] AS '品名', "
            sql += "              CASE T2.[SalPackMsr] WHEN '盒' THEN (T2.[SalPackUn] * T1.[Quantity]) ELSE T1.[Quantity] END AS '數量', "
            'sql += "              SUM(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] WHEN '1' THEN T1.[Quantity] WHEN '2' THEN (CASE WHEN T1.[U_P6] = '3' THEN T1.[U_P4] ELSE T1.[Quantity] END) END) AS '數量',"
            sql += "              CASE WHEN T2.[SalPackMsr] = '盒' THEN '盒' ELSE '件' END AS '單位', T0.[U_P3_Order] AS '生產訂單', T1.[U_P3] AS '生產否'"
            sql += "       FROM [ODRF] T0 INNER JOIN "
            sql += "            [DRF1] T1 ON T0.DocEntry = T1.DocEntry LEFT JOIN"
            sql += "            [OITM] T2 ON T1.ItemCode = T2.ItemCode "
            sql += "       WHERE T0.[DocDueDate] = '" & 日期.Value.Date & "' AND T0.[CardCode] IN ('" & 客戶cb & "') AND T0.[WddStatus] <> 'N' AND T0.[DocStatus] = 'O' AND T0.[ObjType] = '17' AND"
            sql += "             T0.[CANCELED] = 'N' AND (T0.[Comments] Like '%%線上撿%%' OR T0.[U_P3_Order] = 'Y') AND T1.[U_P3] = 'Y' "
            'sql += "       GROUP BY T0.[DocEntry], T0.[CardCode], T0.[CardName], T2.[ItemCode], T2.[ItemName], T2.[SalPackMsr], T0.[U_P3_Order], T1.[U_P3] "
            sql += "       UNION "
            sql += "       SELECT T0.[DocNum] AS '文件單號', T0.[CardCode] AS '客編', T0.[CardName] AS '客戶', T2.[ItemCode] AS '存編', T2.[ItemName] AS '品名', "
            sql += "              CASE T2.[SalPackMsr] WHEN '盒' THEN (T2.[SalPackUn] * T1.[Quantity]) ELSE T1.[Quantity] END AS '數量', "
            'sql += "              SUM(CASE T1.[U_P7] WHEN '0' THEN T1.[Quantity] WHEN '1' THEN T1.[Quantity] WHEN '2' THEN (CASE WHEN T1.[U_P6] = '3' THEN T1.[U_P4] ELSE T1.[Quantity] END) END) AS '數量',"
            sql += "              CASE WHEN T2.[SalPackMsr] = '盒' THEN '盒' ELSE '件' END AS '單位', T0.[U_P3_Order] AS '生產訂單', T1.[U_P3] AS '生產否'"
            sql += "       FROM [ORDR] T0 INNER JOIN"
            sql += "            [RDR1] T1 ON T0.DocEntry = T1.DocEntry LEFT JOIN "
            sql += "            [OITM] T2 ON T1.ItemCode = T2.ItemCode "
            sql += "       WHERE T0.[DocDueDate] = '" & 日期.Value.Date & "' AND T0.[CardCode] IN ('" & 客戶cb & "') AND T0.[DocStatus] = 'O' AND T0.[CANCELED] = 'N' AND "
            sql += "            (T0.[Comments] Like '%%線上撿%%' OR T0.[U_P3_Order] = 'Y') AND T1.[U_P3] = 'Y'  "
            'sql += "       GROUP BY T0.[DocNum], T0.[CardCode], T0.[CardName], T2.[ItemCode], T2.[ItemName], T2.[SalPackMsr], T0.[U_P3_Order], T1.[U_P3] "
            sql += " ) T1 LEFT JOIN [Z_KS_SPdata2] T2 ON T1.存編 = T2.ItemCode AND T2.Cancel = 'Y' AND T2.CategoryName LIKE '%" & TB簡稱.Text & "%' "
            sql += " GROUP BY T1.存編, T1.品名, T2.[Plate_H], T2.[Weight], T2.[Sid] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            MSSQL作業 = New SqlDataAdapter(sql, DBConn)
            MSSQL作業.Fill(顯示資料, "DT2")
            DGV2.DataSource = 顯示資料.Tables("DT2")
            TransactionMonitor.Complete()

        End Using

    End Sub

    Private Sub DGV2Display()  '載入DGV2資料畫面

        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True

            Select Case column.Name
                Case "類別" : column.HeaderText = "類別" : column.DisplayIndex = 0
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 1
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 3
                Case "生產數量" : column.HeaderText = "生產數量" : column.DisplayIndex = 4
                Case "工時基數" : column.HeaderText = "工時基數" : column.DisplayIndex = 5
                Case "原料基數" : column.HeaderText = "原料基數" : column.DisplayIndex = 6
                Case "工時" : column.HeaderText = "工時" : column.DisplayIndex = 7
                Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 8
                Case "Sid" : column.HeaderText = "Sid" : column.DisplayIndex = 9 : column.Visible = False
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub DGV2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellEndEdit
        ' 由編輯資料列時 計算結果


        If e.ColumnIndex = CType(sender, DataGridView).Columns("生產數量").Index Then
            If CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("生產數量").Value) > CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("數量").Value) Then
                CType(sender, DataGridView).Rows(e.RowIndex).Cells("生產數量").Value = 0
                MsgBox("超過訂單數量")
                Exit Sub
            End If

            'If CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("生產數量").Value) <> 0 And TB人數.Text <> "" And CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("工時基數").Value) <> 0 And CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("原料基數").Value) Then

            '    Dim 數量 As Single
            '    數量 = (60 / CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("工時基數").Value)) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("生產數量").Value) / TB人數.Text
            '    CType(sender, DataGridView).Rows(e.RowIndex).Cells("工時").Value = Math.Round(數量, 2)

            '    Dim 重量 As Single
            '    重量 = CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("原料基數").Value) * CSng(CType(sender, DataGridView).Rows(e.RowIndex).Cells("生產數量").Value)
            '    CType(sender, DataGridView).Rows(e.RowIndex).Cells("重量").Value = Math.Round(重量, 2)

            'End If
        End If

        重新計算工時重量()

    End Sub

    Private Sub TB人數_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB人數.TextChanged

        重新計算工時重量()

    End Sub

    Private Sub 重新計算工時重量()

        Dim 總工時 As Double

        For i As Integer = 0 To DGV2.RowCount - 1
            If DGV2.Rows(i).Cells("生產數量").Value <> 0 And TB人數.Text <> "" Then

                If DGV2.Rows(i).Cells("工時基數").Value <> 0 Then
                    DGV2.Rows(i).Cells("工時").Value = Math.Round((60 / CSng(DGV2.Rows(i).Cells("工時基數").Value)) * CSng(DGV2.Rows(i).Cells("生產數量").Value) / TB人數.Text, 2)
                End If

                If DGV2.Rows(i).Cells("原料基數").Value <> 0 Then
                    DGV2.Rows(i).Cells("重量").Value = Math.Round(CSng(DGV2.Rows(i).Cells("原料基數").Value) * CSng(DGV2.Rows(i).Cells("生產數量").Value), 2)
                End If

            Else
                DGV2.Rows(i).Cells("工時").Value = 0
                DGV2.Rows(i).Cells("重量").Value = 0

            End If

            '計算總工時
            總工時 += Math.Round(CSng(DGV2.Rows(i).Cells("工時").Value), 2)

        Next

        L總工時.Text = 總工時

    End Sub

    Private Sub CB樓層_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB樓層.SelectedIndexChanged

        排程單號()

        For i As Integer = 0 To DGV2.RowCount - 1

            Select Case CB樓層.Text

                Case "一樓"
                    TB人數.Text = "2"
                    If DGV2.Rows(i).Cells("類別").Value = "分切" Or DGV2.Rows(i).Cells("類別").Value = "" Then
                        DGV2.Rows(i).Cells("生產數量").Value = 0
                    Else
                        DGV2.Rows(i).Cells("生產數量").Value = DGV2.Rows(i).Cells("數量").Value
                    End If

                Case "二樓"
                    TB人數.Text = "12"
                    If DGV2.Rows(i).Cells("類別").Value = "全雞" Or DGV2.Rows(i).Cells("類別").Value = "" Then
                        DGV2.Rows(i).Cells("生產數量").Value = 0
                    Else
                        DGV2.Rows(i).Cells("生產數量").Value = DGV2.Rows(i).Cells("數量").Value
                    End If

                Case "三樓"
                    TB人數.Text = "8"
                    DGV2.Rows(i).Cells("生產數量").Value = DGV2.Rows(i).Cells("數量").Value
            End Select
        Next

        重新計算工時重量()

    End Sub

    Private Sub CB時段_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB時段.SelectedIndexChanged

        排程單號()

    End Sub

    Private Sub 排程日期_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 排程日期.ValueChanged

        排程單號()

        Select Case CB製單.SelectedIndex
            Case 0
            Case 1 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "001"
            Case 2 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "002"
            Case 3 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "003"
            Case 4 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "004"
            Case 5 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "005"
            Case 6 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "006"
            Case 7 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "007"
            Case 8 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "008"
            Case 9 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "001"
            Case 10 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "002"
            Case 11 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "003"
            Case 12 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "004"
            Case 13 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "005"
            Case 14 : TB製單.Text = "5" + Format(排程日期.Value.Date, "yyMMdd") + "001"
            Case 15 : TB製單.Text = "6" + Format(排程日期.Value.Date, "yyMMdd") + "001"
        End Select

    End Sub

    Private Sub 排程單號()

        If CB樓層.Text <> "" And CB時段.Text <> "" Then
            TB排程.Text = "排" + Format(排程日期.Value.Date, "yyMMdd") + Format(CB樓層.SelectedIndex + 1, "#") + Format(CB時段.SelectedValue + 1, "0#")
        End If

    End Sub

    Private Sub CB製單_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB製單.SelectedIndexChanged

        Select Case CB製單.SelectedIndex
            Case 0
            Case 1 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "001"
            Case 2 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "002"
            Case 3 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "003"
            Case 4 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "004"
            Case 5 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "005"
            Case 6 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "006"
            Case 7 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "007"
            Case 8 : TB製單.Text = "2" + Format(排程日期.Value.Date, "yyMMdd") + "008"
            Case 9 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "001"
            Case 10 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "002"
            Case 11 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "003"
            Case 12 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "004"
            Case 13 : TB製單.Text = "3" + Format(排程日期.Value.Date, "yyMMdd") + "005"
            Case 14 : TB製單.Text = "5" + Format(排程日期.Value.Date, "yyMMdd") + "001"
            Case 15 : TB製單.Text = "6" + Format(排程日期.Value.Date, "yyMMdd") + "001"
        End Select

    End Sub

    Private Function 產生列號()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = " SELECT TOP 1 [LineNum] FROM [KaiShing].[dbo].[Z_KS_Scheduling] WHERE [DocDate] = '" & 排程日期.Value.Date & "' AND [Floor] = '" & CB樓層.SelectedIndex & "' AND [Period] = '" & CB時段.SelectedValue & "' ORDER BY [LineNum] DESC "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = SQL

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("LineNum") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub 儲存_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 儲存.Click

        If TB人數.Text = "" Then
            MsgBox("人數未輸入", 16, "錯誤")
            TB人數.Focus()
            Exit Sub
        End If

        If CB樓層.Text = "" Then
            MsgBox("樓層未選擇", 16, "錯誤")
            CB樓層.Focus()
            Exit Sub
        End If

        If CB時段.Text = "" Then
            MsgBox("時段未選擇", 16, "錯誤")
            CB時段.Focus()
            Exit Sub
        End If

        If TB排程.Text = "" Then
            MsgBox("時段未選擇", 16, "錯誤")
            TB排程.Focus()
            Exit Sub
        End If

        If TB製單.Text = "" Then
            MsgBox("製單未輸入", 16, "錯誤")
            TB製單.Focus()
            Exit Sub
        End If

        '更新列號
        Dim k As Integer
        k = 產生列號()
        If k = 0 Then
            MsgBox("載入列號失敗!", 16, "錯誤")
            Exit Sub
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQL As String = ""

        For i As Integer = 0 To DGV2.RowCount - 1

            If DGV2.Rows(i).Cells("生產數量").Value <> 0 Then
                SQL += " INSERT INTO [KaiShing].[dbo].[Z_KS_Scheduling] ([DocDate],[Floor],[Period],[LineNum],[U_CK02],[CardName],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel],[OPDocNum],[CardCode],[ItemCode],[ItemSid]) VALUES "
                SQL += " ('" & 排程日期.Value.Date & "', "
                SQL += "  '" & CB樓層.SelectedIndex & "', "
                SQL += "  '" & CB時段.SelectedValue & "', "
                SQL += "  '" & k & "', "
                SQL += "  '" & TB製單.Text & "', "
                SQL += "  '" & TB客戶名稱.Text & "', "
                SQL += "  '" & DGV2.Rows(i).Cells("品名").Value & "', "
                SQL += "  '" & DGV2.Rows(i).Cells("生產數量").Value & "', "
                SQL += "  '" & TB人數.Text & "', "
                SQL += "  '" & DGV2.Rows(i).Cells("工時").Value & "', "
                SQL += "  '" & DGV2.Rows(i).Cells("重量").Value & "', "
                SQL += "  'Y', "
                SQL += "  '" & TB排程.Text & "', "
                SQL += "  '" & TB客戶編號.Text & "', "
                SQL += "  '" & DGV2.Rows(i).Cells("存編").Value & "', "
                SQL += "  '" & DGV2.Rows(i).Cells("Sid").Value & "' ) " & vbCrLf
                k = k + 1
            End If

        Next

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQL : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try


        'CB客戶.Text = ""
        TB客戶編號.Text = ""
        TB客戶名稱.Text = ""
        TB簡稱.Text = ""
        TB人數.Text = ""
        CB樓層.Text = ""
        CB時段.Text = ""
        TB排程.Text = ""
        TB製單.Text = ""
        CB製單.Text = ""

        'If DGV1.RowCount > 0 Then
        '顯示資料.Tables("DT1").Clear()
        'End If

        If DGV2.RowCount > 0 Then
            顯示資料.Tables("DT2").Clear()
        End If


    End Sub

    Private Sub ToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcel.Click

        DataToExcel(DGV2, "")

    End Sub
End Class