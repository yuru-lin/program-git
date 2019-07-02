Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 派工作業
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 派工作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

        Label2.Text = ""
        單號2.Text = ""
        Label7.Text = ""
        'SearchDGV4()
        '排程領料扣帳作業
    End Sub

    Private Function 單號2_Sid()
        '查詢單號2 DocNum2 
        'Dim sql As String
        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'Dim sqlReader As SqlDataReader
        'Dim oReturn As Integer

        ''sql = " SELECT TOP 1 [Sid] FROM [Z_KS_ODRFMain] ORDER BY [Sid] DESC "

        'sql = "    SELECT TOP 1 ISNULL([DocNum2],0) AS 'DocNum2' FROM [Z_KS_ODRFCode2] "
        'sql += "    WHERE [DocDate]  = '" & dateDocDate.Value.Date & "' AND "
        'sql += "          [Floor] = '" & Floor.SelectedIndex & "' AND "
        'sql += "          [U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND "
        'sql += "          [Period] = '" & Period2.SelectedIndex & "'"
        'sql += " ORDER BY [DocNum2] DESC "

        'SQLCmd.Connection = DBConn
        'SQLCmd.CommandText = sql
        'sqlReader = SQLCmd.ExecuteReader
        'sqlReader.Read()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        SQLCmd.Connection = DBConn
        'SQLCmd.CommandText = "DELETE FROM [Z_KS_Barcode] WHERE [F4] = '" & Label12.Text & "' "

        SQLCmd.CommandText = "    SELECT TOP 1 ISNULL([DocNum2],0) AS 'DocNum2' FROM [Z_KS_ODRFCode2] "
        SQLCmd.CommandText += "    WHERE [DocDate]  = '" & dateDocDate.Value.Date & "' AND "
        SQLCmd.CommandText += "          [Floor] = '" & Floor.SelectedIndex & "' AND "
        SQLCmd.CommandText += "          [U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND "
        SQLCmd.CommandText += "          [Period] = '" & Period2.SelectedIndex & "'"
        SQLCmd.CommandText += " ORDER BY [DocNum2] DESC "

        SQLCmd.ExecuteNonQuery()
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("DocNum2") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub 單號2_Sid_Update()
        '更新Sid
        Dim i As Integer
        i = 單號2_Sid()
        If i = 0 Then
            MsgBox("載入Sid資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        單號2.Text = i
        Label7.Text = i - 1

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

        SearchDGV11()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
    End Sub

    Private Sub DGV3_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV3.CellClick

        '/**-- 20130101更新 --**/
        '選擇製造單明細

        If DGV3.RowCount = 0 Or DGV3.RowCount = -1 Then
            Exit Sub
        End If

        單號2_Sid_Update()
        '查詢派次()
        SearchDGV1()

        '單號2_Sid_Update()

    End Sub

    Private Sub SearchDGV1()
        '--查詢領料品項
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If DGV4.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV4").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Dim M01, M02 As Int16 : M01 = 0 : M02 = 0

            Select Case Period2.SelectedIndex
                'Case 0 : M01 = "0" : M02 = "6"
                'Case 1 : M01 = "7" : M02 = "10"
                'Case 2 : M01 = "11" : M02 = "14"
                'Case 3 : M01 = "15" : M02 = "18"
                'Case 4 : M01 = "19" : M02 = "22"
                'Case 5 : M01 = "23" : M02 = "26"
                'Case 6 : M01 = "27" : M02 = "30"
                'Case 7 : M01 = "31" : M02 = "35"
                Case 0 : M01 = 13 : M02 = 19
                Case 1 : M01 = 20 : M02 = 23
                Case 2 : M01 = 24 : M02 = 27
                Case 3 : M01 = 28 : M02 = 31
                Case 4 : M01 = 32 : M02 = 35
                Case 5 : M01 = 36 : M02 = 39
                Case 6 : M01 = 40 : M02 = 43
                Case 7 : M01 = 44 : M02 = 47
                Case 8 : M01 = 9 : M02 = 12
            End Select

            sql = " SELECT DISTINCT '' AS '區別', T0.[U_CK02] AS '製單', T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[Source] AS '來源', SUM(T0.[Quantity]) AS '數量', ISNULL(T1.[數量s],0) AS '派工', (SUM(T0.[Quantity]) - ISNULL(T1.[數量s],0)) AS '差異' "
            sql += "  FROM [Z_KS_SPicking] T0 LEFT  JOIN "
            sql += "      (SELECT DISTINCT T0.[U_CK02] AS '製單s', T0.[ItemCode] AS '存編s', SUM(T0.[Quantity]) AS '數量s' "
            sql += "         FROM [Z_KS_ODRFCode2] T0 "
            sql += "        WHERE T0.[DocDate]  = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND T0.[U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND T0.[Period] = '" & Period2.SelectedIndex & "' "
            sql += "     GROUP BY T0.[U_CK02], T0.[ItemCode] "
            sql += "      ) T1 ON T0.[U_CK02] = T1.[製單s] AND T0.[ItemCode] = T1.[存編s] "
            sql += "                          LEFT JOIN [KaiShingPlug].[dbo].[UB07_TimePeriod] T2 ON T0.[Period] = T2.[ID] "
            'sql += " WHERE T0.[DocDate]  = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND T0.[U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND "
            sql += " WHERE CONVERT(VARCHAR(10),T0.[DocDate],111)  = '" & Format(dateDocDate.Value.Date, "yyyy/MM/dd") & "' AND T0.[Cancel] = 'Y' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND (CAST(T2.[TimeOrder] AS INT) BETWEEN " & M01 & " AND " & M02 & ") AND "
            If RadioButton2.Checked = True Then     '冷凍
                sql += "   SUBSTRING(T0.[ItemCode],3,1) = '1'        AND"
            End If
            If RadioButton3.Checked = True Then     '冷藏
                sql += "   SUBSTRING(T0.[ItemCode],3,1) IN ('2','3') AND"
            End If
            'sql += "       (T0.[Period] Between '" & M01 & "' AND '" & M02 & "') AND T0.[Cancel] = 'Y' "
            sql += "       T0.[U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "'"
            sql += " GROUP BY T0.[U_CK02], T0.[ItemCode], T0.[ItemName], T0.[Source], T1.[數量s] "
            sql += " ORDER BY 2, 3, 4 "

            'sql = " SELECT DISTINCT '' AS '區別', T0.[U_CK02] AS '製單', T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[Source] AS '來源', SUM(T0.[Quantity]) AS '數量', ISNULL(T1.[數量s],0) AS '派工', (SUM(T0.[Quantity]) - ISNULL(T1.[數量s],0)) AS '差異' "
            'sql += "  FROM [Z_KS_SPicking] T0 LEFT  JOIN "
            'sql += "      (SELECT DISTINCT T0.[U_CK02] AS '製單s', T0.[ItemCode] AS '存編s', SUM(T0.[Quantity]) AS '數量s' "
            'sql += "         FROM [Z_KS_ODRFCode2] T0 "
            'sql += "        WHERE T0.[DocDate]  = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND T0.[U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND T0.[Period] = '" & Period2.SelectedIndex & "' "
            'sql += "     GROUP BY T0.[U_CK02], T0.[ItemCode] "
            'sql += "      ) T1 ON T0.[U_CK02] = T1.[製單s] AND T0.[ItemCode] = T1.[存編s] "
            'sql += " WHERE T0.[DocDate]  = '" & dateDocDate.Value.Date & "' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND T0.[U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND "
            'If RadioButton2.Checked = True Then     '冷凍
            '    sql += "   SUBSTRING(T0.[ItemCode],3,1) = '1'        AND"
            'End If
            'If RadioButton3.Checked = True Then     '冷藏
            '    sql += "   SUBSTRING(T0.[ItemCode],3,1) IN ('2','3') AND"
            'End If
            'sql += "       (T0.[Period] Between '" & M01 & "' AND '" & M02 & "') AND T0.[Cancel] = 'Y' "
            'sql += " GROUP BY T0.[U_CK02], T0.[ItemCode], T0.[ItemName], T0.[Source], T1.[數量s] "
            'sql += " ORDER BY 2, 3, 4 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
            TransactionMonitor.Complete()
            SearchDGV1_2()
        End Using
        MsgBox("查詢完成")
    End Sub

    Private Sub SearchDGV1_2()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "區別" : column.HeaderText = "區別" : column.DisplayIndex = 0 : column.ReadOnly = True : column.Visible = False
                Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = False
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2 : column.ReadOnly = True : column.Visible = True
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3 : column.ReadOnly = True : column.Visible = True
                Case "來源" : column.HeaderText = "來源" : column.DisplayIndex = 4 : column.ReadOnly = True : column.Visible = True
                Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 5 : column.ReadOnly = True : column.Visible = True
                Case "派工" : column.HeaderText = "派工" : column.DisplayIndex = 6 : column.ReadOnly = True : column.Visible = True
                Case "差異" : column.HeaderText = "差異" : column.DisplayIndex = 7 : column.ReadOnly = False : column.Visible = True
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        DGV1.AllowUserToAddRows = False
    End Sub

    Private Sub 查詢派次()
        If DGV5.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV5").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            'SQLCmd.CommandText = "    SELECT [F1] AS '區別', [F4] AS '草稿單號', COUNT([F2]) AS '條碼數'"
            'SQLCmd.CommandText += "     FROM [Z_KS_Barcode] "
            'SQLCmd.CommandText += "    WHERE [F3] = 'A' AND [Del] = 'N'"
            'SQLCmd.CommandText += " GROUP BY [F1], [F4] "

            SQLCmd.CommandText = "    SELECT DISTINCT [DocNum2] AS '派次' FROM [Z_KS_ODRFCode2] "
            SQLCmd.CommandText += "    WHERE [DocDate]  = '" & dateDocDate.Value.Date & "' AND "
            SQLCmd.CommandText += "          [Floor]    = '" & Floor.SelectedIndex & "' AND "
            SQLCmd.CommandText += "          [U_CK02]   = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND "
            SQLCmd.CommandText += "          [Period]   = '" & Period2.SelectedIndex & "'"
            SQLCmd.CommandText += " ORDER BY [DocNum2] DESC "



            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV5")
            DGV5.DataSource = ks1DataSetDGV.Tables("DGV5")

            DGV5.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub





    Private Sub SearchDGV11()
        '--清空DGV3內容
        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            Dim M01, M02 As Int16 : M01 = 0 : M02 = 0

            Select Case Period2.SelectedIndex
                'Case 0 : M01 = "0" : M02 = "6"
                'Case 1 : M01 = "7" : M02 = "10"
                'Case 2 : M01 = "11" : M02 = "14"
                'Case 3 : M01 = "15" : M02 = "18"
                'Case 4 : M01 = "19" : M02 = "22"
                'Case 5 : M01 = "23" : M02 = "26"
                'Case 6 : M01 = "27" : M02 = "30"
                'Case 7 : M01 = "31" : M02 = "35"
                Case 0 : M01 = 13 : M02 = 19
                Case 1 : M01 = 20 : M02 = 23
                Case 2 : M01 = 24 : M02 = 27
                Case 3 : M01 = 28 : M02 = 31
                Case 4 : M01 = 32 : M02 = 35
                Case 5 : M01 = 36 : M02 = 39
                Case 6 : M01 = 40 : M02 = 43
                Case 7 : M01 = 44 : M02 = 47
                Case 8 : M01 = 9 : M02 = 12
            End Select

            sql = "    SELECT T0.[U_CK02] AS '製單' "
            sql += "     FROM [Z_KS_SPicking] T0  LEFT JOIN [KaiShingPlug].[dbo].[UB07_TimePeriod] T2 ON T0.[Period] = T2.[ID] "
            'sql += "    WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor]  = '" & Floor.SelectedIndex & "'  AND (T0.[Period] Between '" & M01 & "' AND '" & M02 & "')   AND [Cancel] = 'Y' "
            sql += "    WHERE CONVERT(VARCHAR(10),T0.[DocDate],111)  = '" & Format(dateDocDate.Value.Date, "yyyy/MM/dd") & "' AND [Cancel] = 'Y' AND T0.[Floor] = '" & Floor.SelectedIndex & "' AND (CAST(T2.[TimeOrder] AS INT) BETWEEN " & M01 & " AND " & M02 & ") "
            sql += " GROUP BY T0.[U_CK02] "
            sql += " ORDER BY 1 "

            'MsgBox(sql)


            'sql = "    SELECT T0.[U_CK02] AS '製單' "
            'sql += "     FROM [Z_KS_SPicking] T0 "
            'sql += "    WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor]  = '" & Floor.SelectedIndex & "'  AND (T0.[Period] Between '" & M01 & "' AND '" & M02 & "')   AND [Cancel] = 'Y' "
            'sql += " GROUP BY T0.[U_CK02] "
            'sql += " ORDER BY 1 "

            'sql = "    SELECT T0.[U_CK02] AS '製造單號', ISNULL(T1.[區別],'') AS '區別'"
            'sql += "     FROM [Z_KS_SPicking] T0 LEFT JOIN "
            'sql += "         (SELECT [OPDocNum] AS '排單', [U_De] AS '區別' FROM [aKS_T1220].[dbo].[Z_KS_ODRFCode2]) "
            'sql += "                          T1 ON T0.[CodOPDocNum] = T1.[排單] "
            'sql += "    WHERE T0.[DocDate] = '" & dateDocDate.Value.Date & "' AND T0.[Floor]  = '" & Floor.SelectedIndex & "' "
            'sql += " GROUP BY T0.[CodOPDocNum], ISNULL(T1.[區別],'')"
            'sql += " ORDER BY 1--, 2 "

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV3")
            DGV3.DataSource = ks1DataSetDGV.Tables("DGV3")

            For Each column As DataGridViewColumn In DGV3.Columns
                column.Visible = True
                Select Case column.HeaderText

                    Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 0 : column.Visible = True
                        'Case "區別" : column.HeaderText = "區別" : column.DisplayIndex = 1 : column.Visible = True
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
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

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
            TextBox1.Text = "J21"
        Else
            TextBox1.Text = DGV1.CurrentRow.Cells("來源").Value
        End If

        SearchDGV2()              '載入選取製單之生產明細單 



    End Sub

    Private Sub SearchDGV2()
        '--預定儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            '/**-- 20121231更新 --**/
            'sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' "
            'sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'If DGV1.CurrentRow.Cells("來源").Value = "" Then
            '    sql += " WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            'Else
            '    If CheckBox1.Checked = True Then
            '        sql += " WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] Like '%" & TextBox1.Text & "%' "
            '    Else
            '        sql += " WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] =    '" & TextBox1.Text & "' "
            '    End If
            '    'sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] = '" & TextBox1.Text & "' "
            'End If
            'sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            sql = "  SELECT T0.[庫位], T0.[生產日期], T0.[有效日期], T0.[天數], SUM(CAST(T0.[數量] AS NUMERIC(5))) AS '數量', T0.[領料量], T0.[G1], T0.[G2], T0.[G_OK], "
            sql += "        SUM(CAST(T0.[數量2] AS NUMERIC(5))) AS '數量2', SUM(CAST(T0.[重量2] AS NUMERIC(5,2))) AS '重量2'"
            sql += " FROM ( SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '生產日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' ,"
            sql += "               ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
            sql += "               CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T1.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE CAST(T0.[U_M1] AS NUMERIC(5,2)) END AS '重量2'"
            sql += "          FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "                         LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
            sql += "                         LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
            sql += "                         LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
            sql += "                         LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
            'sql += "         WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '252126000000015' "
            If DGV1.CurrentRow.Cells("來源").Value = "" Then
                sql += "     WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            Else
                If CheckBox1.Checked = True Then
                    sql += " WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] Like '%" & TextBox1.Text & "%' "
                Else
                    sql += " WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' AND T0.[U_M2] =    '" & TextBox1.Text & "' "
                End If
            End If
            sql += "      GROUP BY T0.[U_M2], T0.[MnfDate], T0.[ExpDate], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto], T1.[Quantity], T0.[U_M1] "
            sql += " ) T0 GROUP BY T0.[庫位], T0.[生產日期], T0.[有效日期], T0.[天數], T0.[領料量], T0.[G1], T0.[G2], T0.[G_OK] ORDER BY T0.[生產日期]"


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
            DGV2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        End Using

        'MsgBox("查詢完成")

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '/**-- 20121231更新 --**/
        '--個別儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim strWhere As String = ""
        Using TransactionMonitor As New System.Transactions.TransactionScope

            If CheckBox1.Checked = True Then
                strWhere += "    AND T0.[U_M2] Like '%" & TextBox1.Text & "%' "
            Else
                strWhere += "    AND T0.[U_M2] =    '" & TextBox1.Text & "' "
            End If

            'sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量'  "
            'sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            'sql += strWhere
            'sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            sql = "  SELECT T0.[庫位], T0.[生產日期], T0.[有效日期], T0.[天數], SUM(CAST(T0.[數量] AS NUMERIC(5))) AS '數量', T0.[領料量], T0.[G1], T0.[G2], T0.[G_OK], "
            sql += "        SUM(CAST(T0.[數量2] AS NUMERIC(5))) AS '數量2', SUM(CAST(T0.[重量2] AS NUMERIC(5,2))) AS '重量2'"
            sql += " FROM ( SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '生產日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' ,"
            sql += "               ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
            sql += "               CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T1.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE CAST(T0.[U_M1] AS NUMERIC(5,2)) END AS '重量2'"
            sql += "          FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "                         LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
            sql += "                         LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
            sql += "                         LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
            sql += "                         LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
            sql += "          WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            sql += strWhere
            sql += "      GROUP BY T0.[U_M2], T0.[MnfDate], T0.[ExpDate], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto], T1.[Quantity], T0.[U_M1] "
            sql += " ) T0 GROUP BY T0.[庫位], T0.[生產日期], T0.[有效日期], T0.[天數], T0.[領料量], T0.[G1], T0.[G2], T0.[G_OK] ORDER BY T0.[生產日期]"

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
            DGV2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        End Using

        MsgBox("查詢完成")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '/**-- 20121231更新 --**/
        '--所有儲位查詢    清空DGV2內容
        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = "    SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '製造日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量'  "
            'sql += "     FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            'sql += "    WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            'sql += " GROUP BY T0.[U_M2], T0.[MnfDate] ORDER BY T0.[MnfDate] "

            sql = "  SELECT T0.[庫位], T0.[生產日期], T0.[有效日期], T0.[天數], SUM(CAST(T0.[數量] AS NUMERIC(5))) AS '數量', T0.[領料量], T0.[G1], T0.[G2], T0.[G_OK], "
            sql += "        SUM(CAST(T0.[數量2] AS NUMERIC(5))) AS '數量2', SUM(CAST(T0.[重量2] AS NUMERIC(5,2))) AS '重量2'"
            sql += " FROM ( SELECT T0.[U_M2] AS '庫位', T0.[MnfDate] AS '生產日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.MnfDate,getdate())+1 AS '天數', dbo.getRoundN(SUM(T1.[Quantity]),0) AS '數量', 0 AS '領料量' ,"
            sql += "               ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
            sql += "               CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T1.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE CAST(T0.[U_M1] AS NUMERIC(5,2)) END AS '重量2'"
            sql += "          FROM [OSRN] T0 LEFT JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] "
            sql += "                         LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
            sql += "                         LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
            sql += "                         LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
            sql += "                         LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
            sql += "          WHERE T1.[Quantity] > 0 AND T0.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' "
            sql += "      GROUP BY T0.[U_M2], T0.[MnfDate], T0.[ExpDate], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto], T1.[Quantity], T0.[U_M1] "
            sql += " ) T0 GROUP BY T0.[庫位], T0.[生產日期], T0.[有效日期], T0.[天數], T0.[領料量], T0.[G1], T0.[G2], T0.[G_OK] ORDER BY T0.[生產日期]"

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
            DGV2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText



        End Using
        TextBox1.Text = ""
        MsgBox("查詢完成")
    End Sub



    Private Sub PrintBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintBtn.Click

        If DGV4.RowCount = 0 Then
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
            Case 7 : Period_1 = "21:30~23:00"
            Case 8 : Period_1 = "04:00~05:30"
        End Select

        B_ReportViewer.MdiParent = MainForm
        B_ReportViewer.Source = "Dispatching"
        'B_ReportViewer.Size.Width.ToString("21.59")
        'B_ReportViewer.Size.Height.ToString("13.97")

        B_ReportViewer.strPara(0) = Format(dateDocDate.Value.Date, "MM月dd日")
        B_ReportViewer.strPara(1) = Floor.Text
        'B_ReportViewer.strPara(2) = Format(Period.Text).ToString
        B_ReportViewer.strPara(2) = Period_1
        B_ReportViewer.strPara(3) = TextBox2.Text
        B_ReportViewer.strPara(4) = Label2.Text

        'B_ReportViewer.dt = ks1DataSetDGV.Tables("DT1")
        B_ReportViewer.dt = ks1DataSetDGV.Tables("DGV4").DefaultView.ToTable()


        B_ReportViewer.Show()

    End Sub

    Private Sub 存檔_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔.Click
        ODRFCode2_Save()
        單號2_Sid_Update()
        '查詢派次()

    End Sub

    Private Sub ODRFCode2_Save()

        SearchDGV4()

        If DGV4.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV4").Clear()
        End If

        If TextBox2.Text = "" Then
            MsgBox("未入Key區別")
            TextBox2.Focus()
            Exit Sub
        End If

        Label2.Text = Format(DGV3.CurrentRow.Cells("製單").Value, "") + Format(TextBox2.Text, "")
        '單號2.Text = Format(DGV3.CurrentRow.Cells("製單").Value, "") + Format(TextBox2.Text, "")

        For x As Integer = 0 To DGV1.RowCount - 1
            If DGV1.Rows(x).Cells("差異").Value > 0 Then

                Dim Row As DataRow
                Row = ks1DataSetDGV.Tables("DGV4").NewRow
                Row.Item("單號") = Format(DGV3.CurrentRow.Cells("製單").Value, "") + Format(TextBox2.Text, "")
                Row.Item("派次") = 單號2.Text
                Row.Item("日期") = dateDocDate.Value.Date
                Row.Item("樓層") = Floor.SelectedIndex
                Row.Item("時段") = Period2.SelectedIndex
                Row.Item("製單") = DGV3.CurrentRow.Cells("製單").Value
                Row.Item("區別") = TextBox2.Text
                Row.Item("存編") = DGV1.Rows(x).Cells("存編").Value
                Row.Item("品名") = DGV1.Rows(x).Cells("品名").Value
                Row.Item("數量") = DGV1.Rows(x).Cells("差異").Value
                ks1DataSetDGV.Tables("DGV4").Rows.Add(Row)
                DGV4.AutoResizeColumns()
            End If
        Next

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To DGV1.RowCount - 1
                'If DGV1.Rows(i).Cells("數量").Value > 0 Then
                If DGV1.Rows(i).Cells("差異").Value > 0 Then

                    sql = " INSERT INTO [Z_KS_ODRFCode2] ([DocNum],[DocDate],[DocTime],[Floor],[Period],[U_CK02],[U_De],[ItemCode],[ItemName],[Quantity],[Cancel],[Cancel2],[DocNum2]) VALUES "
                    sql += " ('" & DGV3.CurrentRow.Cells("製單").Value & "' + '" & TextBox2.Text & "' ,"
                    sql += "  '" & dateDocDate.Value.Date & "'               ,"
                    sql += "  getdate()                                      ,"
                    sql += "  '" & Floor.SelectedIndex & "'                  ,"
                    sql += "  '" & Period2.SelectedIndex & "'                ,"
                    sql += "  '" & DGV3.CurrentRow.Cells("製單").Value & "'  ,"
                    sql += "  '" & TextBox2.Text & "'                        ,"
                    sql += "  '" & DGV1.Rows(i).Cells("存編").Value & "'     ,"
                    sql += "  '" & DGV1.Rows(i).Cells("品名").Value & "'     ,"
                    sql += "  '" & DGV1.Rows(i).Cells("差異").Value & "'     ,"
                    sql += "  'Y'                                            ,"
                    sql += "  'N'                                            ,"
                    sql += "  '" & 單號2.Text & "'                           )"

                End If

                If DGV1.Rows(i).Cells("差異").Value > 0 Then

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

    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        'If TextBox2.Text = "" Then
        '    MsgBox("未入Key區別")
        '    TextBox2.Focus()
        '    Exit Sub
        'End If

        If DGV3.RowCount = -1 Then
            MsgBox("未選擇製單")
            Exit Sub
        End If

        If Floor.SelectedIndex = -1 Then
            MsgBox("未選擇樓層")
            Exit Sub
        End If

        If Period2.SelectedIndex = -1 Then
            MsgBox("未選擇時段")
            Exit Sub
        End If

        If DGV3.RowCount = 0 Then
            MsgBox("未選擇製單")
            Exit Sub
        End If


        SearchDGV4()
    End Sub

    Private Sub SearchDGV4()
        '--清空DGV3內容

        If DGV4.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV4").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Using TransactionMonitor As New System.Transactions.TransactionScope

            'sql = " SELECT '' AS '日期', '' AS '樓層', '' AS '時段', '' AS '製單', '' AS '區別', '' AS '存編', '' AS '品名', '' AS '數量' "

            'sql = "    SELECT [OPDocNum] AS '排程單號', [U_De] AS '區別', [ItemCode] AS '存編', [ItemName] AS '品名', [U_M2] AS '庫位', [Date] AS '原料製造日期', [Quantity] AS '預領數量', [Quantity2] AS '領料數量' "
            'sql += "     FROM [aKS_T1220].[dbo].[Z_KS_ODRFCode2] "
            'sql += "    WHERE [DocDate]  = '" & dateDocDate.Value.Date & "'               AND "
            'sql += "          [OPDocNum] = '" & DGV11.CurrentRow.Cells("排單").Value & "' AND "
            'sql += "          [Cancel]   = 'Y' "
            'sql += " ORDER BY 4 "

            sql = "    SELECT [Sid] AS '編號',[DocNum] AS '單號', [DocNum2] AS '派次', [DocDate] AS '日期', ([Floor] + 1) AS '樓層', ([Period] + 1) AS '時段', [U_CK02] AS '製單', [U_De] AS '區別', [ItemCode] AS '存編', [ItemName] AS '品名', [Quantity]AS '數量'  "
            sql += "     FROM [Z_KS_ODRFCode2] "
            If TextBox2.Text <> "" Then
                sql += "    WHERE [U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND [DocDate] = '" & dateDocDate.Value.Date & "' AND [U_De] = '" & TextBox2.Text & "' AND [Cancel] = 'Y' "
            Else
                sql += "    WHERE [U_CK02] = '" & DGV3.CurrentRow.Cells("製單").Value & "' AND [DocDate] = '" & dateDocDate.Value.Date & "' AND [Cancel] = 'Y' "
            End If
            sql += " ORDER BY 6 "

            '[Floor] = '" & Floor.SelectedIndex & "' AND [Period] = '" & Period2.SelectedIndex & "' AND

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV4")
            DGV4.DataSource = ks1DataSetDGV.Tables("DGV4")

            For Each column As DataGridViewColumn In DGV4.Columns
                column.Visible = True
                Select Case column.HeaderText

                    Case "編號" : column.HeaderText = "編號" : column.DisplayIndex = 0 : column.ReadOnly = True : column.Visible = False
                    Case "單號" : column.HeaderText = "單號" : column.DisplayIndex = 1 : column.ReadOnly = True : column.Visible = True
                    Case "派次" : column.HeaderText = "派次" : column.DisplayIndex = 2 : column.ReadOnly = True : column.Visible = True
                    Case "日期" : column.HeaderText = "日期" : column.DisplayIndex = 3 : column.ReadOnly = True : column.Visible = False
                    Case "樓層" : column.HeaderText = "樓層" : column.DisplayIndex = 4 : column.ReadOnly = True : column.Visible = True
                    Case "時段" : column.HeaderText = "時段" : column.DisplayIndex = 5 : column.ReadOnly = True : column.Visible = True
                    Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 6 : column.ReadOnly = True : column.Visible = True
                    Case "區別" : column.HeaderText = "區別" : column.DisplayIndex = 7 : column.ReadOnly = True : column.Visible = True
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 8 : column.ReadOnly = True : column.Visible = True
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 9 : column.ReadOnly = True : column.Visible = True
                    Case "數量" : column.HeaderText = "數量" : column.DisplayIndex = 10 : column.ReadOnly = True : column.Visible = True

                    Case Else
                        column.Visible = False
                End Select
            Next

            TransactionMonitor.Complete()
            DGV4.AutoResizeColumns()
            DGV4.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
            'DGV4.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
            DGV4.ReadOnly = True               'DataGridView 設定單元格不可編輯

        End Using
    End Sub

    Private Sub DGV5_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV5.CellClick

        '/**-- 20121231更新 --**/
        '選擇領料品項

        If DGV5.RowCount = 0 Or DGV5.RowCount = -1 Then
            Exit Sub
        End If

        '' ''點選作業單後, 顯示明細資料在PDGV22
        ' '' ''Label4.Text = DGV1.CurrentRow.Cells("存編").Value
        ' '' ''Label5.Text = DGV1.CurrentRow.Cells("品名").Value
        ' '' ''Label7.Text = DGV1.CurrentRow.Cells("數量").Value

        ' ''If DGV2.RowCount > 0 Then
        ' ''    ks1DataSetDGV.Tables("DGV2").Clear()
        ' ''End If

        ' ''If DGV1.CurrentRow.Cells("來源").Value = "預解" Then
        ' ''    TextBox1.Text = "J211"
        ' ''Else
        ' ''    TextBox1.Text = DGV1.CurrentRow.Cells("來源").Value
        ' ''End If

        ' ''SearchDGV2()              '載入選取製單之生產明細單 



    End Sub
End Class