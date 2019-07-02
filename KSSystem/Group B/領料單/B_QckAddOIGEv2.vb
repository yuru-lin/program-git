Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QckAddOIGEv2
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_QckAddOIGEv2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub Button_01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_01.Click
        '查詢排工單

        If Floor.SelectedIndex = -1 Then
            MsgBox("請選擇樓層!", 16, "錯誤")
            Floor.Focus()
            Exit Sub
        End If

        '---------XX刪除
        '' ''If Period.SelectedIndex = -1 Then
        '' ''    MsgBox("請選擇時段!", 16, "錯誤")
        '' ''    Period.Focus()
        '' ''    Exit Sub
        '' ''End If

        '' ''SearchDGV1()
        '---------XX刪除

        SearchDGV11()

    End Sub

    Private Sub SearchDGV11()
        '--查詢領料單號
        If DGV11.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT11").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "    SELECT [CodOPDocNum] AS '排單', [U_CK02] AS '製單' "
            'sql += "     FROM [Z_KS_SPicking] "
            'sql += "    WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor]  = '" & Floor.SelectedIndex & "' "
            'sql += " GROUP BY [CodOPDocNum], [U_CK02] "
            'sql += " ORDER BY 1, 2 "

            'sql = "    SELECT T0.[CodOPDocNum] AS '排單', T0.[U_CK02] AS '製單', ISNULL(T1.[區別],'') AS '區別'"
            sql = "    SELECT T0.[CodOPDocNum] AS '排單', ISNULL(T1.[區別],'') AS '區別'"
            sql += "     FROM [Z_KS_SPicking] T0 LEFT JOIN "
            'sql += "         (SELECT [OPDocNum] AS '排單', [U_CK02] AS '製單', [U_De] AS '區別' FROM [aKS_T1220].[dbo].[Z_KS_ODRFCode2]) "
            sql += "         (SELECT [OPDocNum] AS '排單', [U_De] AS '區別' FROM [aKS_T1220].[dbo].[Z_KS_ODRFCode2]) "
            'sql += "                          T1 ON T0.[CodOPDocNum] = T1.[排單] AND T0.[U_CK02] = T1.[製單] "
            sql += "                          T1 ON T0.[CodOPDocNum] = T1.[排單] "
            sql += "    WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor]  = '" & Floor.SelectedIndex & "' "
            'sql += " GROUP BY T0.[CodOPDocNum], T0.[U_CK02] , ISNULL(T1.[區別],'')"
            sql += " GROUP BY T0.[CodOPDocNum], ISNULL(T1.[區別],'')"
            sql += " ORDER BY 1--, 2 "




            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT11")
            DGV11.DataSource = ks1DataSetDGV.Tables("DT11")
            TransactionMonitor.Complete()

            'DGV11.AutoResizeColumns()

            'DGV11.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'DGV11.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'DGV11.ReadOnly = True               'DataGridView 設定單元格不可編輯

            SearchDGV11_2()

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub SearchDGV11_2()

        For Each column As DataGridViewColumn In DGV11.Columns

            column.Visible = True

            Select Case column.Name

                Case "排單" : column.HeaderText = "排單" : column.DisplayIndex = 0 : column.ReadOnly = True : column.Visible = True
                    'Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = True
                Case "區別" : column.HeaderText = "區別" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = True


                Case Else

                    column.Visible = False

            End Select

        Next

        DGV11.AutoResizeColumns()

        DGV11.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        DGV11.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        DGV11.ReadOnly = True               'DataGridView 設定單元格不可編輯

        'DGV11.AutoResizeColumns()
        'DGV11.AllowUserToAddRows = False
        'DGV11.AllowUserToDeleteRows = False
        'DGV11.ReadOnly = True  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub DGV11_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV11.CellClick

        Dim Periods As Byte


        '選擇領料品項
        If DGV11.RowCount = -1 Then
            Exit Sub
        End If

        Label1.Text = DGV11.CurrentRow.Cells("排單").Value
        'Label2.Text = DGV11.CurrentRow.Cells("製單").Value
        Label8.Text = DGV11.CurrentRow.Cells("區別").Value
        TextBox2.Text = DGV11.CurrentRow.Cells("區別").Value

        Label4.Text = ""
        Label5.Text = ""
        Label7.Text = ""

        Periods = Microsoft.VisualBasic.Right(Label1.Text, 2) - 1
        Period.SelectedIndex = Periods


        '點選作業單後, 顯示明細資料在PDGV22

        '--清空DGV1內容
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV211").Clear()
        End If

        '--清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        SearchDGV211()              '載入選取製單之生產明細單 

        SearchDGV3()

    End Sub

    Private Sub SearchDGV211()
        '--儲位查詢    清空DGV1內容
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV211").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "    SELECT [ItemCode] AS '存編', [ItemName] AS '品名', SUM([Quantity]) AS '數量', [Source] AS '來源' "
            sql += "     FROM [Z_KS_SPicking] "
            'sql += "    WHERE [CodOPDocNum] = '" & DGV11.CurrentRow.Cells("排單").Value & "' AND [U_CK02] = '" & DGV11.CurrentRow.Cells("製單").Value & "' "
            sql += "    WHERE [CodOPDocNum] = '" & DGV11.CurrentRow.Cells("排單").Value & "' "
            sql += " GROUP BY [ItemCode],[ItemName],[Source] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV211")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV211")
            TransactionMonitor.Complete()

            'DGV1.AutoResizeColumns()

            'DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

            SearchDGV211_2()

        End Using

        'MsgBox("查詢完成")

    End Sub

    Private Sub SearchDGV211_2()

        For Each column As DataGridViewColumn In DGV1.Columns

            column.Visible = True

            Select Case column.Name

                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 3 : column.ReadOnly = True : column.Visible = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 0 : column.ReadOnly = True : column.Visible = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = True
                Case "來源" : column.HeaderText = "來源" : column.DisplayIndex = 2 : column.ReadOnly = True : column.Visible = True

                Case Else

                    column.Visible = False

            End Select

        Next

        DGV1.AutoResizeColumns()

        DGV1.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        DGV1.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        DGV1.ReadOnly = True               'DataGridView 設定單元格不可編輯

        ' ''DGV11.AutoResizeColumns()
        ' ''DGV11.AllowUserToAddRows = False
        'DGV11.AllowUserToDeleteRows = False
        'DGV11.ReadOnly = True  'DataGridView 設定單元格不可編輯

    End Sub

    Private Sub SearchDGV3()
        '--清空DGV3內容
        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "    SELECT [Sid] AS '編號', [LineNum] AS '列號', [Order] AS '順序', [CardCode] AS '客編', [CardName] AS '客戶', [AliasName] AS '別名' "
            'sql += "     FROM [Z_KS_SPdata0] "
            'sql += "    WHERE [Floor] IN ('4') AND [Cancel] = 'Y' "
            'sql += " ORDER BY 1 "

            'sql = "    SELECT [OPDocNum] AS '排程單號', [U_CK02] AS '製造單號', [U_De] AS '區別', [ItemCode] AS '存編', [ItemName] AS '品名', [U_M2] AS '庫位', [Date] AS '原料製造日期', [Quantity] AS '預領數量', [Quantity2] AS '領料數量' "
            sql = "    SELECT [OPDocNum] AS '排程單號', [U_De] AS '區別', [ItemCode] AS '存編', [ItemName] AS '品名', [U_M2] AS '庫位', [Date] AS '原料製造日期', [Quantity] AS '預領數量', [Quantity2] AS '領料數量' "
            sql += "     FROM [aKS_T1220].[dbo].[Z_KS_ODRFCode2] "
            sql += "    WHERE [DocDate]  = '" & dateDocDate.Value.Date & "'               AND "
            sql += "          [OPDocNum] = '" & DGV11.CurrentRow.Cells("排單").Value & "' AND "
            'sql += "          [U_CK02]   = '" & DGV11.CurrentRow.Cells("製單").Value & "' AND "
            sql += "          [Cancel]   = 'Y' "
            sql += " ORDER BY 4 "




            'sql += "    WHERE [OPDocNum] = '" & DGV11.CurrentRow.Cells("排單").Value & "' AND [U_CK02] = '" & DGV11.CurrentRow.Cells("製單").Value & "' "


            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

            For Each column As DataGridViewColumn In DGV3.Columns
                column.Visible = True
                Select Case column.HeaderText

                    Case "排程單號" : column.HeaderText = "排程單號" : column.DisplayIndex = 0 : column.Visible = False
                        'Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 1 : column.Visible = False
                    Case "區別" : column.HeaderText = "區別" : column.DisplayIndex = 1 : column.Visible = False
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3
                    Case "庫位" : column.HeaderText = "庫位" : column.DisplayIndex = 4
                    Case "原料製造日期" : column.HeaderText = "原料製造日期" : column.DisplayIndex = 5
                    Case "預領數量" : column.HeaderText = "預領數量" : column.DisplayIndex = 6
                    Case "領料數量" : column.HeaderText = "領料數量" : column.DisplayIndex = 7

                    Case Else
                        column.Visible = False
                End Select
            Next

            TransactionMonitor.Complete()

            DGV3.AutoResizeColumns()

            DGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            DGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using


        ' ''Dim sql As String
        ' ''Dim DBConn As SqlConnection = Login.DBConn
        ' ''Dim SQLCmd As SqlCommand = New SqlCommand
        ' ''Using TransactionMonitor As New System.Transactions.TransactionScope

        ' ''    sql = "    SELECT [ItemCode] AS '存編', [ItemName] AS '品名', SUM([Quantity]) AS '數量', [Source] AS '來源' "
        ' ''    sql += "     FROM [Z_KS_SPicking] "
        ' ''    sql += "    WHERE [CodOPDocNum] = '" & DGV11.CurrentRow.Cells("排單").Value & "' AND [U_CK02] = '" & DGV11.CurrentRow.Cells("製單").Value & "' "
        ' ''    sql += " GROUP BY [ItemCode],[ItemName],[Source] "

        ' ''    SQLCmd.Connection = DBConn
        ' ''    SQLCmd.CommandText = sql

        ' ''    DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        ' ''    DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
        ' ''    DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")
        ' ''    TransactionMonitor.Complete()

        ' ''    DGV3.AutoResizeColumns()

        ' ''    DGV3.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        ' ''    DGV3.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        ' ''    DGV3.ReadOnly = True               'DataGridView 設定單元格不可編輯

        ' ''    'SearchDGV211_2()

        ' ''End Using

        '' ''MsgBox("查詢完成")

    End Sub



    '---------XX刪除
    Private Sub SearchDGV1()
        '--查詢領料品項
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT [LineNum]  AS '列號', [CodLineNum]  AS '對應', [U_CK02] AS '製單', [CardName] AS '客戶', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity] AS '數量',[Source] AS '來源', [Remarks] AS '備註' FROM [Z_KS_SPicking] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period.SelectedIndex & "' AND [Cancel] = 'Y' ORDER BY 2 "

            sql = " SELECT '' AS '區別', T0.[U_CK02] AS '製單', T0.[CodLineNum] AS '對應', T0.[LineNum] AS '列號', T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[Source] AS '來源', SUM(T0.[Quantity]) AS '數量' "
            sql += "  FROM [Z_KS_SPicking] T0 "
            sql += " WHERE [DocDate] = '" & dateDocDate.Value.Date & "' AND [Floor]  = '" & Floor.SelectedIndex & "' AND "
            sql += "       [Period]  = '" & Period.SelectedIndex & "'   AND [Cancel] = 'Y' "
            sql += " GROUP BY T0.[U_CK02], T0.[CodLineNum], T0.[LineNum], T0.[ItemCode], T0.[ItemName], T0.[Source] "
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

    '---------XX刪除
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
                Case "對應" : column.HeaderText = "對應" : column.DisplayIndex = 6 : column.ReadOnly = True : column.Visible = False
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 7 : column.ReadOnly = True : column.Visible = False

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

        '---------XX刪除
        ' '' ''選擇領料品項
        '' ''If DGV1.RowCount = -1 Then
        '' ''    Exit Sub
        '' ''End If

        ' '' ''點選作業單後, 顯示明細資料在PDGV22

        '' ''If DGV2.RowCount > 0 Then
        '' ''    ks1DataSetDGV.Tables("DGV2").Clear()
        '' ''End If

        '' ''SearchDGV2()              '載入選取製單之生產明細單 
        '---------XX刪除

        '選擇領料品項
        If DGV1.RowCount = -1 Then
            Exit Sub
        End If

        '點選作業單後, 顯示明細資料在PDGV22

        Label4.Text = DGV1.CurrentRow.Cells("存編").Value
        Label5.Text = DGV1.CurrentRow.Cells("品名").Value
        Label7.Text = DGV1.CurrentRow.Cells("數量").Value

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

            ' '' ''sql = " SELECT T0.[ItemCode] AS '存編', T2.[ItemName] AS '品名', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] LEFT JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] WHERE T1.[Quantity] > 0 AND T2.[ItemName] Like '%" & TextBox1.Text & "%' AND T0.[U_M2] Like '%" & ComboBox1.Text & "%' or (T1.[Quantity] > 0 and T0.[U_M2] Like '&" & ComboBox1.Text & "&' AND T2.[ItemName] Like '%" & TextBox1.Text & "%' ) GROUP BY T0.[ItemCode], T2.[ItemName], T0.[MnfDate] ORDER BY T0.[ItemCode], T0.[MnfDate] "
            '' ''sql = "    SELECT T0.[MnfDate] AS '製造日期', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', dbo.getRoundN(SUM(CAST( T0.[U_M1] AS numeric(19, 4))),2) as '重量', DATEDIFF(DAY,T0.MnfDate,getdate())+1 as '天數' "
            '' ''sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            '' '' '' ''sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] Like '%J211%' "
            '' ''If DGV1.CurrentRow.Cells("來源").Value = "" Or DGV1.CurrentRow.Cells("來源").Value = "預解" Then
            '' ''    sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            '' ''Else
            '' ''    sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] = '" & DGV1.CurrentRow.Cells("來源").Value & "' "
            '' ''End If
            '' ''sql += " GROUP BY T0.[MnfDate] ORDER BY T0.[MnfDate] "


            sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '243110140000010' --AND T0.[U_M2] = 'J211' "
            If DGV1.CurrentRow.Cells("來源").Value = "" Then 'Or DGV1.CurrentRow.Cells("來源").Value = "預解" Then
                ''sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            Else
                ''sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] = '" & DGV1.CurrentRow.Cells("來源").Value & "' "
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] = '" & TextBox1.Text & "' "
            End If
            sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "



            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            TransactionMonitor.Complete()

            ''DGV2.AutoResizeColumns()

            ''DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            ''DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            ''DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        SearchDGV2_2()

        MsgBox("查詢完成")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        '--儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'If TextBox1.Text = "ALL" Or TextBox1.Text = "all" Then
            '    sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            'Else

            If CheckBox1.Checked = True Then
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] Like '%" & TextBox1.Text & "%' "
            Else
                sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] =    '" & TextBox1.Text & "' "
            End If

            'End If
            sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            TransactionMonitor.Complete()

            'DGV2.AutoResizeColumns()

            'DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        SearchDGV2_2()

        MsgBox("查詢完成")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        '--儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' "
            sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'If TextBox1.Text = "ALL" Or TextBox1.Text = "all" Then
            sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            'Else
            'sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "'   AND T0.[U_M2] = '" & TextBox1.Text & "' "
            'End If
            sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            TransactionMonitor.Complete()

            'DGV2.AutoResizeColumns()

            'DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            'DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using

        SearchDGV2_2()

        TextBox1.Text = ""

        MsgBox("查詢完成")


    End Sub

    Private Sub SearchDGV2_2()

        For Each column As DataGridViewColumn In DGV2.Columns

            column.Visible = True

            Select Case column.Name

                Case "庫位" : column.HeaderText = "庫位" : column.DisplayIndex = 0 : column.ReadOnly = True : column.Visible = True
                Case "製造日期" : column.HeaderText = "製造日期" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = True
                Case "天數" : column.HeaderText = "天數" : column.DisplayIndex = 4 : column.ReadOnly = True : column.Visible = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 2 : column.ReadOnly = True : column.Visible = True
                Case "領料量" : column.HeaderText = "領料量" : column.DisplayIndex = 3 : column.ReadOnly = False : column.Visible = True
                    'Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 5 : column.ReadOnly = True : column.Visible = True
                    'Case "對應" : column.HeaderText = "對應" : column.DisplayIndex = 6 : column.ReadOnly = True : column.Visible = False
                    'Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 7 : column.ReadOnly = True : column.Visible = False

                Case Else

                    column.Visible = False

            End Select

        Next

        DGV2.AutoResizeColumns()
        DGV2.AllowUserToAddRows = False
        'DGV1.AllowUserToDeleteRows = False
        'DGV1.ReadOnly = True  'DataGridView 設定單元格不可編輯

    End Sub


    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click

        If DGV1.RowCount = 0 Then
            MsgBox("無資料可列印")
            Exit Sub
        End If

        Dim Period_1 As String = ""

        Select Case Period.SelectedIndex
            Case 0 : Period_1 = "06:00"
            Case 1 : Period_1 = "06:30"
            Case 2 : Period_1 = "07:00"
            Case 3 : Period_1 = "07:30"
            Case 4 : Period_1 = "08:00"
            Case 5 : Period_1 = "08:30"
            Case 6 : Period_1 = "09:00"
            Case 7 : Period_1 = "09:30"
            Case 8 : Period_1 = "10:00"
            Case 9 : Period_1 = "10:30"
            Case 10 : Period_1 = "11:00"
            Case 11 : Period_1 = "11:30"
            Case 12 : Period_1 = "12:00"
            Case 13 : Period_1 = "12:30"
            Case 14 : Period_1 = "13:00"
            Case 15 : Period_1 = "13:30"
            Case 16 : Period_1 = "14:00"
            Case 17 : Period_1 = "14:30"
            Case 18 : Period_1 = "15:00"
            Case 19 : Period_1 = "15:30"
            Case 20 : Period_1 = "16:00"
            Case 21 : Period_1 = "16:30"
            Case 22 : Period_1 = "17:00"
            Case 23 : Period_1 = "17:30"
            Case 24 : Period_1 = "18:00"
            Case 25 : Period_1 = "18:30"
            Case 26 : Period_1 = "19:00"
            Case 27 : Period_1 = "19:30"
            Case 28 : Period_1 = "20:00"
            Case 29 : Period_1 = "20:30"
            Case 30 : Period_1 = "21:00"
            Case 31 : Period_1 = "21:30"
            Case 32 : Period_1 = "22:00"
            Case 33 : Period_1 = "22:30"
            Case 34 : Period_1 = "23:00"
            Case 35 : Period_1 = "23:30"
            Case 36 : Period_1 = "24:00"


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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ODRFCode2_Save()

    End Sub

    Private Sub ODRFCode2_Save()

        For x As Integer = 0 To DGV2.RowCount - 1
            If DGV2.Rows(x).Cells("領料量").Value > 0 Then

                Dim Row As DataRow
                Row = ks1DataSetDGV.Tables("DGV3").NewRow
                Row.Item("排程單號") = DGV11.CurrentRow.Cells("排單").Value
                'Row.Item("製造單號") = Label2.Text
                Row.Item("區別") = DGV11.CurrentRow.Cells("區別").Value
                Row.Item("存編") = DGV1.CurrentRow.Cells("存編").Value
                Row.Item("品名") = DGV1.CurrentRow.Cells("品名").Value
                Row.Item("庫位") = DGV2.Rows(x).Cells("庫位").Value
                Row.Item("原料製造日期") = DGV2.Rows(x).Cells("製造日期").Value
                Row.Item("預領數量") = DGV1.CurrentRow.Cells("數量").Value
                Row.Item("領料數量") = DGV2.Rows(x).Cells("領料量").Value

                ks1DataSetDGV.Tables("DGV3").Rows.Add(Row)

                DGV3.AutoResizeColumns()

            End If
        Next

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Rows(i).Cells("領料量").Value > 0 Then
                    'Else
                    sql = " INSERT INTO [Z_KS_ODRFCode2] ([DocDate],[OPDocNum],[U_De],[ItemCode],[ItemName],[U_M2],[Date],[Quantity],[Quantity2],[Cancel]) VALUES "
                    sql += " ('" & dateDocDate.Value.Date & "'                   ,"
                    sql += "  '" & Label1.Text & "'     ,"
                    sql += "  '" & Label8.Text & "'     ,"
                    sql += "  '" & Label4.Text & "'      ,"
                    sql += "  '" & Label5.Text & "'      ,"
                    sql += "  '" & DGV2.Rows(i).Cells("庫位").Value & "'         ,"
                    sql += "  '" & DGV2.Rows(i).Cells("製造日期").Value & "' ,"
                    sql += "  '" & Label7.Text & "'      ,"
                    sql += "  '" & DGV2.Rows(i).Cells("領料量").Value & "'       ,"
                    sql += "  'Y'                                                )"

                End If

                If DGV2.Rows(i).Cells("領料量").Value <> 0 Then

                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()

                End If
            Next


            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try





















        ''Dim sql As String
        ''Dim DBConn As SqlConnection = Login.DBConn
        ''Dim SQLCmd As SqlCommand = New SqlCommand
        ' ''Dim tran As SqlTransaction = DBConn.BeginTransaction()
        ''Dim X As Integer = 0

        ''Dim Cancel As String = "Y"
        ' ''Try
        ''For i As Integer = 0 To DGV2.RowCount - 1

        ''    'MsgBox("01-- " & i)

        ''    If DGV2.Rows(i).Cells("領料量").Value <> "0" Then

        ''        'MsgBox("02--" & i & "  " & DGV2.Rows(i).Cells("領料量").Value)


        ''        sql = " INSERT INTO [Z_KS_ODRFCode2] ([DocDate],[OPDocNum],[U_CK02],[U_De],[ItemCode],[ItemName],[U_M2],[Date],[Quantity],[Quantity2],[Cancel]) VALUES "
        ''        sql += " ('" & dateDocDate.Value.Date & "'                   ,"
        ''        sql += "  '" & Label1.Text & "'     ,'" & X & "',"
        ''        sql += "  '" & Label8.Text & "'     ,"
        ''        sql += "  '" & Label4.Text & "'      ,"
        ''        sql += "  '" & Label5.Text & "'      ,"
        ''        sql += "  '" & DGV2.Rows(i).Cells("庫位").Value & "'         ,"
        ''        sql += "  '" & DGV2.Rows(i).Cells("製造日期").Value & "' ,"
        ''        sql += "  '" & Label7.Text & "'      ,"
        ''        sql += "  '" & DGV2.Rows(i).Cells("領料量").Value & "'       ,"
        ''        sql += "  'Y'                                                )"

        ''        'MsgBox(DGV2.Rows(i).Cells("庫位").Value)

        ''        X = X + 1

        ''    End If
        ''Next

        ''SQLCmd.Connection = DBConn
        ''SQLCmd.CommandText = sql




        'DGV1.Rows(i).Cells("U_P3").Value()



        ''Try
        ''    For i As Integer = 0 To DGV2.RowCount - 1
        ''        If DGV2.Rows(i).Cells("領料量").Value > 0 Then

        ''            sql = " INSERT INTO [Z_KS_ODRFCode2] ([DocDate],[OPDocNum],[U_De],[ItemCode],[ItemName],[U_M2],[Date],[Quantity],[Quantity2],[Cancel]) VALUES "
        ''            sql += " ('" & dateDocDate.Value.Date & "'                   ,"
        ''            sql += "  '" & DGV11.CurrentRow.Cells("排單").Value & "'     ,"
        ''            sql += "  '" & DGV11.CurrentRow.Cells("區別").Value & "'     ,"
        ''            sql += "  '" & DGV1.CurrentRow.Cells("存編").Value & "'      ,"
        ''            sql += "  '" & DGV1.CurrentRow.Cells("品名").Value & "'      ,"
        ''            sql += "  '" & DGV2.Rows(i).Cells("庫位").Value & "'         ,"
        ''            sql += "  '" & DGV2.Rows(i).Cells("製造日期").Value & "' ,"
        ''            sql += "  '" & DGV1.CurrentRow.Cells("數量").Value & "'      ,"
        ''            sql += "  '" & DGV2.Rows(i).Cells("領料量").Value & "'       ,"
        ''            sql += "  '" & Cancel & "'                                   )"
        ''        End If
        ''    Next





        'sql = " INSERT INTO [Z_KS_Scheduling] ([DocDate],[Floor],[Period],[LineNum],[OPDocNum],[U_CK02],[CardCode],[CardName],[ItemCode],[ItemName],[Quantity],[Number],[Time],[Weight],[Cancel]) VALUES "
        'sql += " ('" & dateDocDate.Value.Date & "',"
        'sql += "  '" & Floor.SelectedIndex & "'   ,"
        'sql += "  '" & Period.SelectedIndex & "'  ,"
        'sql += "  '" & LineNum.Text & "'          ,"
        'sql += "  '" & T1OPDocNum.Text & "'       ,"
        'sql += "  '" & U_CK02.Text & "'           ,"
        'sql += "  '" & CardCode.Text & "'         ,"
        'sql += "  '" & CardName.Text & "'         ,"
        'sql += "  '" & ItemCode.Text & "'         ,"
        'sql += "  '" & ItemName2.Text & "'        ,"
        'sql += "  '" & Quantity.Text & "'         ,"
        'sql += "  '" & Number.Text & "'           ,"
        'sql += "  '" & Time.Text & "'             ,"
        'sql += "  '" & Weight.Text & "'           ,"
        'sql += "  '" & Cancel & "'                )"
        'SQLCmd.Connection = DBConn
        'SQLCmd.CommandText = sql
        'SQLCmd.Transaction = tran
        'SQLCmd.ExecuteNonQuery()
        'tran.Commit()
        'Catch ex As Exception
        '    tran.Rollback()
        '    MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
        '    Exit Sub
        'End Try






























        'For i As Integer = 0 To DGV1.RowCount - 1
        '    If DGV1.Rows(i).Cells("本次數量").Value > 0 Then
        '        oDraft.Lines.SetCurrentLine(X)
        '        oDraft.Lines.ItemCode = DGV1.Rows(i).Cells("ItemCode").Value '項目號碼
        '        oDraft.Lines.Quantity = DGV1.Rows(i).Cells("本次數量").Value '銷售數量

        '        'U_P8 = Val(DGV1.Rows(i).Cells("U_P8").Value)
        '        'MsgBox("U_P8=" & U_P8.ToString & "U_P8.LENGTH=" & U_P8.ToString.Length.ToString, 36, "XX")

        '        'Select Case DGV1.Rows(i).Cells("U_P3").Value        '是否生產
        '        '    Case "N"
        '        '        oDraft.Lines.UserFields.Fields.Item("U_P3").Value = "N"
        '        '    Case "Y"
        '        '        oDraft.Lines.UserFields.Fields.Item("U_P3").Value = "Y"
        '        'End Select

        '        oDraft.Lines.UserFields.Fields.Item("U_P3").Value = DGV1.Rows(i).Cells("U_P3").Value        '是否生產
        '        oDraft.Lines.UserFields.Fields.Item("U_P4").Value = (DGV1.Rows(i).Cells("U_P4").Value * DGV1.Rows(i).Cells("本次數量").Value)   '小單位總數
        '        oDraft.Lines.UserFields.Fields.Item("U_P6").Value = DGV1.Rows(i).Cells("U_P62").Value       '小單位
        '        oDraft.Lines.UserFields.Fields.Item("U_P7").Value = DGV1.Rows(i).Cells("U_P7").Value        '計價單位
        '        oDraft.Lines.UserFields.Fields.Item("U_P8").Value = Val(DGV1.Rows(i).Cells("U_P8").Value)   '銷售單價
        '        oDraft.Lines.UserFields.Fields.Item("U_P3_Quantity").Value = (DGV1.Rows(i).Cells("U_P4").Value * DGV1.Rows(i).Cells("本次數量").Value)    '生產數量

        '        Select Case DGV1.Rows(i).Cells("U_P7").Value
        '            Case "0"
        '                oDraft.Lines.UnitPrice = DGV1.Rows(i).Cells("U_P8").Value
        '            Case "1"
        '                oDraft.Lines.UnitPrice = 0
        '            Case "2"
        '                'U_P62 = (DGV1.Rows(i).Cells("U_P6").Value * DGV1.Rows(i).Cells("本次數量").Value)
        '                oDraft.Lines.UnitPrice = (Val(DGV1.Rows(i).Cells("U_P8").Value) * (DGV1.Rows(i).Cells("U_P4").Value * DGV1.Rows(i).Cells("本次數量").Value)) / DGV1.Rows(i).Cells("本次數量").Value
        '        End Select


        '        oDraft.Lines.Add()
        '        X = X + 1
        '    End If
        'Next


        '' ''Dim DBConn As SqlConnection = Login.DBConn
        '' ''Dim SQLCmd As SqlCommand = New SqlCommand

        '' ''Try

        '' ''    SQLCmd.Connection = DBConn

        '' ''    SQLCmd.CommandText = " INSERT INTO [Z_KS_ODRFMain] ([OPDocNum],[U_CK01],[U_CK02],[DocDate],[TaxDate],[OutLy],[Cancel]) VALUES ('" & T1OPDocNum.Text & "','5','" & T1U_CK02.Text & "','" & DocDate.Value.Date & "','" & DocDate.Value.Date & "','N','Y' ) "
        '' ''    SQLCmd.Parameters.Clear()
        '' ''    SQLCmd.ExecuteNonQuery()

        '' ''    'Try
        '' ''    For i As Integer = 0 To T1DGV3.RowCount - 1

        '' ''        SQLCmd.CommandText = " INSERT INTO [Z_KS_ODRFCode] ([SidNum],[OPDocNum],[U_CK02],[ItemCode],[ItemName],[DistNumber],[Quantity],[Cancel]) VALUES ('" & T1Sid.Text & "','" & T1OPDocNum.Text & "','" & T1U_CK02.Text & "','" & T1DGV3.Rows(i).Cells("存編").Value & "','" & T1DGV3.Rows(i).Cells("品名").Value & "','" & T1DGV3.Rows(i).Cells("條碼").Value & "','" & T1DGV3.Rows(i).Cells("數量").Value & "','Y' ) "
        '' ''        SQLCmd.Parameters.Clear()
        '' ''        SQLCmd.ExecuteNonQuery()

        '' ''    Next
        '' ''    'Catch ex As Exception
        '' ''    'End Try

        '' ''Catch ex As Exception

        '' ''    If MessageBox.Show("更新失敗：" & vbCrLf & ex.Message & vbCrLf & "是否要重試?", "錯誤", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then

        '' ''        T1Save_UpDB()

        '' ''    Else
        '' ''        SQLCmd.CommandText = "  DELETE FROM [Z_KS_ODRFMain] WHERE [OPDocNum] = '" & T1OPDocNum.Text & "' AND [U_CK02] = '" & T1U_CK02.Text & "' AND [Cancel] = 'Y' "
        '' ''        SQLCmd.CommandText += " DELETE FROM [Z_KS_ODRFCode] WHERE [OPDocNum] = '" & T1OPDocNum.Text & "' AND [U_CK02] = '" & T1U_CK02.Text & "' AND [Cancel] = 'Y' "
        '' ''        SQLCmd.Parameters.Clear()
        '' ''        SQLCmd.ExecuteNonQuery()
        '' ''        MsgBox("更新失敗", 16, "失敗")

        '' ''        Exit Sub

        '' ''    End If
        '' ''    Exit Sub
        '' ''End Try

        ' '' ''SQLCmd.CommandText += "DELETE FROM [Z_KS_Reloc2] WHERE [F1] = '" & T1CB_F1.Text & "' "
        ' '' ''SQLCmd.Parameters.Clear()
        ' '' ''SQLCmd.ExecuteNonQuery()

        '' ''T1Del_CBF1()

        '' ''T1CB_F1_All()
        '' ''ks1DataSetDGV.Tables("T1DGV2").Clear()
        '' ''ks1DataSetDGV.Tables("T1DGV3").Clear()
        '' ''T1U_CK02.Text = ""
        '' ''T1Quantity_1.Text = ""

        ' '' ''MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate, MsgBoxStyle.OkOnly, "成功")
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DGV11.CurrentRow.Cells("區別").Value = TextBox2.Text
        Label8.Text = TextBox2.Text

    End Sub
End Class