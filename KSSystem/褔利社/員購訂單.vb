Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Linq

Imports System.Collections.Specialized
Imports Microsoft.Reporting.WinForms
Imports System.Collections.Generic

Public Class 員購訂單
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim sqlReader As SqlDataReader
    Dim sqlReader1 As SqlDataReader
    Dim B_存編 As String = String.Empty
    Dim B_品名 As String = String.Empty
    Dim B_條碼 As String = String.Empty
    Dim B_數量 As Integer
    Dim B_重量 As String = String.Empty
    Dim B_單價 As String = String.Empty
    Dim B_計價單位 As String = String.Empty
    Dim B_製造日期 As String = String.Empty
    Dim B_下單日期 As String = String.Empty
    Dim B_溫層 As String = String.Empty
    Dim SaleGroupType As String = String.Empty


    Private Sub 員購定單_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        '員工編號.Focus()

        'GV初始化
        GetDGV1Data()

        初始化()

        條碼.Enabled = False
        員工編號.Focus()

    End Sub

    ''Private Sub 員工編號_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal x As System.Windows.Forms.KeyEventArgs) Handles 員工編號.TextChanged
    'Private Sub 員工編號_KeyUp(ByVal sender As Object, ByVal x As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    '    If x.KeyCode = Keys.Enter Then
    '        'If e.KeyCode = Keys.Enter Then : Select員工編號() : End If
    '        'If Select員工編號() Then
    '        '    AddItemBtn.Enabled = True
    '        'End If
    '    End If


    '    'strLen=Len("Taiwan")
    '    'If Len(員工編號.Text) = 8 Then
    '    '    If Select員工編號() Then
    '    '        AddItemBtn.Enabled = True
    '    '    End If
    '    'End If
    'End Sub


    '快捷鍵設定

    'Private Sub 員購定單_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    '編制數字鍵區執行作業
    '    'Me.KeyPreview = False

    '    If 員工編號.Text <> "" Then
    '        If e.KeyCode = Keys.Enter Then
    '            'If e.KeyCode = Keys.Enter Then : Select員工編號() : End If
    '            If Select員工編號() Then
    '                AddItemBtn.Enabled = True
    '            End If
    '        End If
    '    End If

    '    If 條碼.Text <> "" Then
    '        If e.KeyCode = Keys.Enter Then
    '            'Select條碼()
    '            If Select條碼() Then
    '                SaveBtn.Enabled = True
    '            End If
    '        End If
    '    End If


    'End Sub


#Region "'限定掃瞄器輸入"
    'Private Sub FD1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles 員工編號.KeyPress
    Private Sub 員工編號_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 員工編號.KeyUp
        '編制數字鍵區執行作業
        'Me.KeyPreview = False
        'If e.KeyCode = Keys.NumPad0 Or e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.NumPad4 Or _
        '   e.KeyCode = Keys.NumPad5 Or e.KeyCode = Keys.NumPad6 Or e.KeyCode = Keys.NumPad7 Or e.KeyCode = Keys.NumPad8 Or e.KeyCode = Keys.NumPad9 Or _
        '   e.KeyCode = Keys.D0 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.D3 Or e.KeyCode = Keys.D4 Or _
        '   e.KeyCode = Keys.D5 Or e.KeyCode = Keys.D6 Or e.KeyCode = Keys.D7 Or e.KeyCode = Keys.D8 Or e.KeyCode = Keys.D9 Then
        '    MsgBox("禁止手Kye輸入", 16, "錯誤")
        '    員工編號.Text = ""
        '    員工編號.Focus()
        '    Exit Sub
        'End If

        If 員工編號.Text <> "" And Len(員工編號.Text) = 8 Then
            If e.KeyCode = Keys.Enter Then
                If Select員工編號() Then
                    AddItemBtn.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub 條碼_S_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles 條碼.KeyUp
        '編制數字鍵區執行作業
        'Me.KeyPreview = False
        'If e.KeyCode = Keys.NumPad0 Or e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.NumPad3 Or e.KeyCode = Keys.NumPad4 Or _
        '   e.KeyCode = Keys.NumPad5 Or e.KeyCode = Keys.NumPad6 Or e.KeyCode = Keys.NumPad7 Or e.KeyCode = Keys.NumPad8 Or e.KeyCode = Keys.NumPad9 Or _
        '   e.KeyCode = Keys.D0 Or e.KeyCode = Keys.D1 Or e.KeyCode = Keys.D2 Or e.KeyCode = Keys.D3 Or e.KeyCode = Keys.D4 Or _
        '   e.KeyCode = Keys.D5 Or e.KeyCode = Keys.D6 Or e.KeyCode = Keys.D7 Or e.KeyCode = Keys.D8 Or e.KeyCode = Keys.D9 Then
        '    MsgBox("禁止手Kye輸入", 16, "錯誤")
        '    條碼.Text = ""
        '    條碼.Focus()
        '    Exit Sub
        'End If

        If 條碼.Text <> "" Then
            If e.KeyCode = Keys.Enter Then
                If Select條碼() Then
                    SaveBtn.Enabled = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "Select部分"
    Function Select員工編號() As Boolean

        Dim IsSelect As Boolean = False

        If 員工編號.Text = "" Then
            MsgBox("請輸入員工編號", 16, "錯誤")
            Exit Function
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = " SELECT * FROM ( "
            sql += " SELECT [lastName], [pager] AS 'EmpID', '0' AS SaleGroupType FROM [OHEM] "
            sql += " UNION ALL "
            sql += " SELECT [lastName], [EmpID], SaleGroupType FROM [KS_A_OHEM_O] "
            sql += " ) E WHERE E.[EmpID] = '" & 員工編號.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無此人", 16, "錯誤")
                條碼.Enabled = False
                員工姓名.Text = ""
                員工編號.Text = ""
                員工編號.Focus()
            Else
                員工姓名.Text = sqlReader.Item("lastName")
                SaleGroupType = sqlReader.Item("SaleGroupType")
                員工編號.Enabled = False
                條碼.Enabled = True
                條碼.Focus()
                sqlReader.Close()
                IsSelect = True
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

        '回傳是否select到資料
        Return IsSelect

    End Function

    Function Select條碼() As Boolean

        Dim IsSelect As Boolean = False

        If 條碼.Text = "" Then
            MsgBox("請輸入條碼", 16, "錯誤")
            Exit Function
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Using TransactionMonitor As New System.Transactions.TransactionScope
            '電宰品
            'sql = "  SELECT [FI107] AS '存編', [FI108] AS '品名', [FI106] AS '條碼', '1' AS '數量', [FI118] AS '重量' , ISNULL(W.Price,0.0000) AS '單價'   "
            'sql += " , ISNULL(W.U_P7,'1') AS '計價單位', Convert(varchar,T1.MnfDate,111) AS '製造日期', CONVERT(varchar,GETDATE(),111) AS '下單日期'  "
            'sql += " , CASE WHEN DATEDIFF (day,CONVERT(datetime,T1.MnfDate),CONVERT(datetime,GETDATE()))>=2 THEN '冷凍' ELSE '冷藏' END AS '溫層' "
            'sql += " FROM [@FinishItem1] F  "
            'sql += " LEFT JOIN KS_A_WelfarePrice W ON F.[FI107]=W.ProCode AND W.Examine='2'  "
            'sql += " LEFT JOIN [OSRN] T1  ON  F.[FI106] = T1.[DistNumber] "
            'sql += " INNER JOIN [OSRQ] T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            'sql += " WHERE F.[FI106] = '" & 條碼.Text & "' "

            sql = "    SELECT T1.[ItemCode] AS '存編', T3.[ItemName] AS '品名', T1.[DistNumber] AS '條碼', SUM(T2.[Quantity]) AS '數量', T1.[U_M1] AS '重量', "
            sql += "          ISNULL(W.[Price],0.0000) AS '單價', ISNULL(W.[U_P7],'1') AS '計價單位', "
            sql += "          CONVERT(VARCHAR(12),T1.[MnfDate],111) AS '製造日期', CONVERT(VARCHAR(12),GETDATE(),111) AS '下單日期', "
            sql += "          CASE WHEN DATEDIFF (day,CONVERT(DateTime,T1.[MnfDate]),CONVERT(DateTime,GETDATE())) >= 2 THEN '冷凍' ELSE '冷藏' END AS '溫層' "
            sql += "     FROM [OSRN] T1 INNER JOIN [OSRQ]              T2 ON T1.[ItemCode] = T2.[ItemCode] AND T1.[SysNumber] = T2.[SysNumber] AND T1.[AbsEntry] = T2.[MdAbsEntry] "
            sql += "                    INNER JOIN [OITM]              T3 ON T1.[ItemCode] = T3.[ItemCode] "
            sql += "                    LEFT  JOIN [KS_A_WelfarePrice] W  ON T1.[ItemCode] = W.ProCode AND W.Examine = '2' "
            sql += "    WHERE T1.[DistNumber] = '" & 條碼.Text & "' AND T2.[Quantity] > 0 AND T1.[U_M2] = 'J21K' "
            sql += " GROUP BY T1.[ItemCode], T3.[ItemName], T1.[DistNumber], T1.[U_M1], W.[Price], W.[U_P7], T1.[MnfDate] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                MsgBox("查無條碼或無庫存", 16, "錯誤")
                條碼.Text = ""
                條碼.Focus()
            Else

                B_存編 = sqlReader.Item("存編")
                B_品名 = sqlReader.Item("品名")
                B_條碼 = sqlReader.Item("條碼")
                B_數量 = sqlReader.Item("數量")
                B_重量 = sqlReader.Item("重量")
                B_單價 = sqlReader.Item("單價")
                B_計價單位 = sqlReader.Item("計價單位")
                B_製造日期 = sqlReader.Item("製造日期")
                B_下單日期 = sqlReader.Item("下單日期")
                B_溫層 = sqlReader.Item("溫層")

                sqlReader.Close()
                If Not Select條碼是否已購買() Then '表示條碼重複
                    MsgBox("此條碼發生重覆狀況", 16, "錯誤")
                    清除商品資料暫存檔()
                    條碼.Text = ""
                    條碼.Focus()
                    Exit Function
                End If

                If Not 新增項目() Then '表示已經刷入過
                    MsgBox(條碼.Text & "此條碼重複刷入", 16, "錯誤")
                    清除商品資料暫存檔()
                    條碼.Text = ""
                    條碼.Focus()
                    Exit Function
                End If

                條碼.Enabled = True
                條碼.Text = ""
                條碼.Focus()
                IsSelect = True
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

        '回傳是否select到資料
        Return IsSelect

    End Function

    Function Select條碼是否已購買() As Boolean

        Dim IsSelect As Boolean = False

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim oDT As DataTable = New DataTable

        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = " SELECT Barcode FROM [KS_Z_Welfare] WHERE [Barcode] = '" & 條碼.Text & "' "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(oDT)

            If oDT.Rows.Count > 0 Then
                IsSelect = False
            Else
                IsSelect = True
            End If

            oDT.Clear()

            TransactionMonitor.Complete()
        End Using

        '回傳是否select到資料
        Return IsSelect

    End Function
#End Region

#Region "GV相關"
    Private Sub GetDGV1Data()

        If DGV1.RowCount > 0 Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope


            sql = "  SELECT [ProCode] AS '存編', [ProName] AS '品名', [Barcode] AS '條碼', [Num] AS '數量', [Weight] AS '重量', [Price] AS '單價', [U_P7] AS '計價單位', [EmpName] AS '員工姓名', [EmpID] AS '員工編號'    "
            sql += "      , CONVERT(VARCHAR(12),[AddDate],111) AS '下單日期',  CONVERT(VARCHAR(12),[MnfDate],111) AS '製造日期', [KeepName] AS '溫層'"
            sql += "   FROM [KS_Z_Welfare] "
            sql += "  WHERE [AddUser] = '" & Login.LogonUserName & "' AND [state] = '0' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
        End Using
        DGV1Display()
    End Sub

    Private Sub DGV1Display()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                    column.ReadOnly = True
                    column.Width = 150
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                    column.ReadOnly = True
                    column.Width = 180
                Case "溫層"
                    column.HeaderText = "溫層"
                    column.DisplayIndex = 2
                    column.ReadOnly = True
                Case "條碼"
                    column.HeaderText = " 條碼"
                    column.DisplayIndex = 3
                    column.ReadOnly = True
                    column.Width = 150
                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                Case "重量"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 5
                    column.ReadOnly = True
                Case "單價"
                    column.HeaderText = "單價"
                    column.DisplayIndex = 6
                    column.ReadOnly = True
                Case "計價單位"
                    column.HeaderText = "計價單位"
                    column.DisplayIndex = 7
                    column.ReadOnly = True
                Case "製造日期"
                    column.HeaderText = "製造日期"
                    column.DisplayIndex = 8
                    column.ReadOnly = True
                Case "下單日期"
                    column.HeaderText = "下單日期"
                    column.DisplayIndex = 9
                    column.ReadOnly = True

                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

#End Region

#Region "按鈕事件部分"
    Function 新增項目() As Boolean

        Dim IsSelect As Boolean = True

        '判斷DGV是否已存在的重覆條碼
        For i As Integer = 0 To DGV1.RowCount - 1
            If Convert.ToString(DGV1.Rows(i).Cells("條碼").Value) = B_條碼 Then
                IsSelect = False
            End If
        Next

        If IsSelect Then
            Dim Row As DataRow

            Row = ks1DataSetDGV.Tables("DT1").NewRow
            Row.Item("存編") = B_存編
            Row.Item("品名") = B_品名
            Row.Item("條碼") = B_條碼
            Row.Item("數量") = B_數量
            Row.Item("重量") = B_重量
            Row.Item("單價") = B_單價
            Row.Item("計價單位") = B_計價單位
            Row.Item("製造日期") = B_製造日期
            Row.Item("下單日期") = B_下單日期
            Row.Item("溫層") = B_溫層
            ks1DataSetDGV.Tables("DT1").Rows.Add(Row)
        End If



        清除商品資料暫存檔()

        Return IsSelect
    End Function

    Private Sub AddItemBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddItemBtn.Click
        If Select條碼() Then
            SaveBtn.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Select員工編號() Then
            AddItemBtn.Enabled = True
        End If
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click


        If 員工編號.Text = "" Then
            MsgBox("請輸入員工編號!", 16, "錯誤")
            員工編號.Focus()
            Exit Sub
        End If

        If 員工姓名.Text = "" Then
            MsgBox("請輸入員工姓名!", 16, "錯誤")
            員工編號.Focus()
            Exit Sub
        End If

        If DGV1.RowCount <= 0 Then
            MsgBox("無新增任何項目資料!", 16, "錯誤")
            Exit Sub
        End If

        'Dim oAns As Integer

        'oAns = MsgBox("確認要送出 ?", 36, "新增")
        'If oAns = MsgBoxResult.No Then
        '    Exit Sub
        'End If

        '鎖住按鈕
        SaveBtn.Enabled = False

        InsertData()

    End Sub
#End Region


    Private Sub InsertData()
        '連線
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        Dim DD As String = Microsoft.VisualBasic.Right(("0" + Now.Day.ToString), 2)

        '===========================================寫入資料庫作業Begin===============================================
        For i As Integer = 0 To DGV1.RowCount - 1

            SQLCmd.CommandText = String.Format(" INSERT INTO [KS_Z_Welfare] ([ProCode],[ProName] " & _
             ",[Barcode],[Num],[Weight],[Price],[U_P7],[EmpName],[EmpID],[state],[SaleGroupType],[AddDate],[AddUser],[MnfDate],[KeepName]) VALUES ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','1','{9}',getdate(),'{10}','{11}','{12}') " _
             , DGV1.Rows(i).Cells("存編").Value _
             , DGV1.Rows(i).Cells("品名").Value _
             , DGV1.Rows(i).Cells("條碼").Value _
             , DGV1.Rows(i).Cells("數量").Value _
             , DGV1.Rows(i).Cells("重量").Value _
             , DGV1.Rows(i).Cells("單價").Value _
             , DGV1.Rows(i).Cells("計價單位").Value _
             , 員工姓名.Text _
             , 員工編號.Text _
             , SaleGroupType _
             , Login.LogonUserName _
             , DGV1.Rows(i).Cells("製造日期").Value & " 00:00:00.000" _
             , DGV1.Rows(i).Cells("溫層").Value)

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()


            SQLCmd.CommandText = String.Format(" INSERT INTO [Z_KS_Barcode] ([Del],[F1] " & _
             ",[F2],[F3],[KeepName]) VALUES ('N','{0}','{1}','Z','{2}') " _
             , "Z" + DD + "_" + SaleGroupType _
             , DGV1.Rows(i).Cells("條碼").Value _
             , DGV1.Rows(i).Cells("溫層").Value)

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

        Next

        MsgBox("下單成功!!", 64, "完成")
        '===========================================寫入資料庫作業END===============================================


        ks1DataSetDGV.Tables("DT1").Clear()
        GetDGV1Data()
        初始化()

        員工編號.Focus()

    End Sub


    Private Sub 初始化()
        '鎖住按鈕
        SaveBtn.Enabled = False
        AddItemBtn.Enabled = False
        員工姓名.Text = ""
        員工編號.Text = ""
        '員工編號.Focus()
        員工編號.Enabled = True
        條碼.Enabled = False

        員工編號.Focus()

    End Sub

    Private Sub 清除商品資料暫存檔()
        B_存編 = ""
        B_品名 = ""
        B_條碼 = ""
        B_數量 = 0
        B_重量 = ""
        B_單價 = ""
        B_計價單位 = ""
        B_製造日期 = ""
        B_下單日期 = ""
        B_溫層 = ""
    End Sub
End Class