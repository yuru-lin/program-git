Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 派工作業bak
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 派工作業bak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        '排程領料扣帳作業
    End Sub

    Private Sub Button_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_01.Click
        '查詢排工單

        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        If Period2.SelectedIndex = -1 Then
            MsgBox("請選擇時段!", 16, "錯誤")
            Period.Focus()
            Exit Sub
        End If

        SearchDGV1()

    End Sub

    Private Sub SearchDGV1()
        '--查詢領料品項
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Dim M01, M02 As String : M01 = "" : M02 = ""

            Select Case Period2.SelectedIndex
                Case 0 : M01 = "0" : M02 = "6"
                Case 1 : M01 = "7" : M02 = "10"
                Case 2 : M01 = "11" : M02 = "14"
                Case 3 : M01 = "15" : M02 = "18"
                Case 4 : M01 = "19" : M02 = "22"
                Case 5 : M01 = "23" : M02 = "26"
                Case 6 : M01 = "27" : M02 = "30"
                Case 7 : M01 = "31" : M02 = "35"
            End Select

            'M01 = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(M01, 3), 1)


            'sql = " SELECT [LineNum]  AS '列號', [CodLineNum]  AS '對應', [U_CK02] AS '製單', [CardName] AS '客戶', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity] AS '數量',[Source] AS '來源', [Remarks] AS '備註' FROM [Z_KS_SPicking] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2 "
            '20121231移除對應及列號
            'sql = " SELECT '' AS '區別', T0.[U_CK02] AS '製單', T0.[CodLineNum] AS '對應', T0.[LineNum] AS '列號', T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[Source] AS '來源', SUM(T0.[Quantity]) AS '數量' "
            sql = " SELECT DISTINCT '' AS '區別', T0.[U_CK02] AS '製單', T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[Source] AS '來源', SUM(T0.[Quantity]) AS '數量' "

            sql += "  FROM [Z_KS_SPicking] T0 "
            sql += " WHERE T0.[DocDate]  = '" & dateDocDate.Value.Date & "'         AND [Floor]  = '" & Floor.SelectedIndex & "' AND "
            If RadioButton2.Checked = True Then     '冷凍
                sql += "   SUBSTRING(T0.[ItemCode],3,1) = '1' AND"
            End If
            If RadioButton3.Checked = True Then     '冷藏
                sql += "   SUBSTRING(T0.[ItemCode],3,1) IN ('2','3') AND"
            End If
            'sql += "       [Period]  = '" & Period.SelectedIndex & "'   AND [Cancel] = 'Y' "
            sql += "       ([Period] Between '" & M01 & "' AND '" & M02 & "')   AND [Cancel] = 'Y' "
            '20121231移除對應及列號
            'sql += " GROUP BY T0.[U_CK02], T0.[CodLineNum], T0.[LineNum], T0.[ItemCode], T0.[ItemName], T0.[Source] "
            sql += " GROUP BY T0.[U_CK02], T0.[ItemCode], T0.[ItemName], T0.[Source] "

            sql += " ORDER BY 2, 3, 4 "

            'If CheckBox1.Checked Then
            '    sql += "AND [CodLineNum] = '" & PLineNum.Text & "'"
            'End If

            'sql += "AND [Cancel] = 'Y' ORDER BY 2 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()

            'DGV1.AutoResizeColumns()

            'DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

            SearchDGV1_2()

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub SearchDGV1_2()

        For Each column As DataGridViewColumn In DGV1.Columns

            column.Visible = True

            Select Case column.Name

                Case "區別" : column.HeaderText = "區別" : column.DisplayIndex = 0 : column.ReadOnly = False : column.Visible = True
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = True
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2 : column.ReadOnly = True : column.Visible = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3 : column.ReadOnly = True : column.Visible = True
                Case "來源" : column.HeaderText = "來源" : column.DisplayIndex = 4 : column.ReadOnly = True : column.Visible = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 5 : column.ReadOnly = True : column.Visible = True
                    'Case "對應" : column.HeaderText = "對應" : column.DisplayIndex = 6 : column.ReadOnly = True : column.Visible = False
                    'Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 7 : column.ReadOnly = True : column.Visible = False

                Case Else

                    column.Visible = False

            End Select

        Next

        DGV1.AutoResizeColumns()
        DGV1.AllowUserToAddRows = False
        'DGV1.AllowUserToDeleteRows = False
        'DGV1.ReadOnly = True  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        ' ''選擇領料品項
        ''If DGV1.RowCount = -1 Then
        ''    Exit Sub
        ''End If

        ' ''點選作業單後, 顯示明細資料在PDGV22

        ''If DGV2.RowCount > 0 Then
        ''    ks1DataSetDGV.Tables("DGV2").Clear()
        ''End If

        ''SearchDGV2()              '載入選取製單之生產明細單 


        '/**-- 20121231更新 --**/
        '選擇領料品項
        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        '點選作業單後, 顯示明細資料在PDGV22
        ''Label4.Text = DGV1.CurrentRow.Cells("存編").Value
        ''Label5.Text = DGV1.CurrentRow.Cells("品名").Value
        ''Label7.Text = DGV1.CurrentRow.Cells("數量").Value

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        If DGV1.CurrentRow.Cells("來源").Value = "預解" Then
            TextBox1.Text = "J211"
        Else
            TextBox1.Text = DGV1.CurrentRow.Cells("來源").Value
        End If

        SearchDGV2()              '載入選取製單之生產明細單 

    End Sub

    Private Sub SearchDGV2()
        '--儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            ' ''sql = " SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] LEFT JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] WHERE T1.[Quantity] > 0 AND T2.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T1.[Quantity] > 0 and T0.[U_M2] Like '&" & ComboBox1.Text & "&' AND T2.[ItemName] Like '%" & TextBox1.Text & "%' ) GROUP BY T0.[ItemCode], T2.[ItemName], T0.[MnfDate] ORDER BY T0.[ItemCode], T0.[MnfDate] "
            ''sql = "    SELECT T0.[MnfDate] AS '製造日期', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' "
            ''sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            ''sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] Like '%J211%' "
            ''sql += " GROUP BY T0.[MnfDate] ORDER BY T0.[MnfDate] "

            '/**-- 20121231更新 --**/
            'sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量' "
            'sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            'sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            If DGV1.CurrentRow.Cells("來源").Value = "" Then
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            Else
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] = '" & TextBox1.Text & "' "
            End If
            sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            TransactionMonitor.Complete()

            DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        'MsgBox("查詢完成")

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '/**-- 20121231更新 --**/
        '--儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            If CheckBox1.Checked = True Then
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] Like '%" & TextBox1.Text & "%' "
            Else
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] =    '" & TextBox1.Text & "' "
            End If
            sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            TransactionMonitor.Complete()

            DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '/**-- 20121231更新 --**/
        '--儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            TransactionMonitor.Complete()

            DGV2.AutoResizeColumns()

            DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        TextBox1.Text = ""

        MsgBox("查詢完成")


    End Sub



    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可列印")
            Exit Sub
        End If

        Dim Period_1 As String = ""

        'Select Case Period.SelectedIndex
        '    Case 0 : Period_1 = "06:00"
        '    Case 1 : Period_1 = "06:30"
        '    Case 2 : Period_1 = "07:00"
        '    Case 3 : Period_1 = "07:30"
        '    Case 4 : Period_1 = "08:00"
        '    Case 5 : Period_1 = "08:30"
        '    Case 6 : Period_1 = "09:00"
        '    Case 7 : Period_1 = "09:30"
        '    Case 8 : Period_1 = "10:00"
        '    Case 9 : Period_1 = "10:30"
        '    Case 10 : Period_1 = "11:00"
        '    Case 11 : Period_1 = "11:30"
        '    Case 12 : Period_1 = "12:00"
        '    Case 13 : Period_1 = "12:30"
        '    Case 14 : Period_1 = "13:00"
        '    Case 15 : Period_1 = "13:30"
        '    Case 16 : Period_1 = "14:00"
        '    Case 17 : Period_1 = "14:30"
        '    Case 18 : Period_1 = "15:00"
        '    Case 19 : Period_1 = "15:30"
        '    Case 20 : Period_1 = "16:00"
        '    Case 21 : Period_1 = "16:30"
        '    Case 22 : Period_1 = "17:00"
        '    Case 23 : Period_1 = "17:30"
        '    Case 24 : Period_1 = "18:00"
        '    Case 25 : Period_1 = "18:30"
        '    Case 26 : Period_1 = "19:00"
        '    Case 27 : Period_1 = "19:30"
        '    Case 28 : Period_1 = "20:00"
        '    Case 29 : Period_1 = "20:30"
        '    Case 30 : Period_1 = "21:00"
        '    Case 31 : Period_1 = "21:30"
        '    Case 32 : Period_1 = "22:00"
        '    Case 33 : Period_1 = "22:30"
        '    Case 34 : Period_1 = "23:00"
        '    Case 35 : Period_1 = "23:30"
        '    Case 36 : Period_1 = "24:00"
        'End Select

        Select Case Period2.SelectedIndex
            Case 0 : Period_1 = "06:00~09:00"
            Case 1 : Period_1 = "09:30~11:00"
            Case 2 : Period_1 = "11:30~13:00"
            Case 3 : Period_1 = "13:30~15:00"
            Case 4 : Period_1 = "15:30~17:00"
            Case 5 : Period_1 = "17:30~19:00"
            Case 6 : Period_1 = "19:30~21:00"
            Case 7 : Period_1 = "21:30~23:30"
        End Select

        B_ReportViewer.MdiParent = MainForm
        B_ReportViewer.Source = "Dispatching"
        'B_ReportViewer.Size.Width.ToString("21.59")
        'B_ReportViewer.Size.Height.ToString("13.97")

        B_ReportViewer.strPara(0) = Format(dateDocDate.Value.Date, "MM月dd日")
        B_ReportViewer.strPara(1) = Floor.Text
        'B_ReportViewer.strPara(2) = Format(Period.Text).ToString
        B_ReportViewer.strPara(2) = Period_1

        'B_ReportViewer.dt = ks1DataSetDGV.Tables("DT1")
        B_ReportViewer.dt = ks1DataSetDGV.Tables("DT1").DefaultView.ToTable()


        B_ReportViewer.Show()

    End Sub



End Class