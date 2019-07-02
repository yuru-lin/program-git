Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QuerySRNNotInB1Yet
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QuerySRNNotInB1Yet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvSourceMain2.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        If dgvSourceMain.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        If dgvSourceMain2.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        '20190603-修改
        If 查詢品名.Checked = False And 查詢冷凍冷藏.Checked = False And 查詢補製單.Checked = False Then
            LoadSourceMain()
            LoadSourceMain2()
        Else
            LoadSourceMain3()
            'LoadSourceMain2()
        End If
        'LoadSourceMain()
        'LoadSourceMain2()
    End Sub

    '依作業類別載入欲入庫製單號, 並指派給dgvSourceMain 
    Private Sub LoadSourceMain()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        '20190603-修改zHLnvetoryThan預存程式
        If RB1.Checked = True Then
            'sql = "SELECT T1.FI101 as '生產單號', T1.FI102 as '製單單號',T1.FI107 as '存貨編號',T1.FI108 as '品名',T1.FI106 as '條碼',T1.FI105 as '文件日期' FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.FI101 = T1.FI101 WHERE (T0.FI103 = '3') AND (T1.FI103 < '4')"
            'sql = "exec zHLnvetoryThan '" & TextBox1.Text & "','" & TextBox2.Text & "' "
            sql = "exec zHLnvetoryThan '" & Format(Date1.Value.Date, "yyMMdd") & "','" & Format(Date2.Value.Date, "yyMMdd") & "' "

        End If

        If RB2.Checked = True Then
            'sql = " SELECT T1.[FI105] as '生產日期', T1.[FI102] as '製造單號', T1.FI101 as '生產單號', T1.FI106 as '未入庫條碼', T1.FI107 as '存編', T1.FI108 as '品名', "
            'sql += "       CASE T1.[FI103] When '1' Then '處理中' When '2' Then '已列印' When '3' Then '已清點' When '4' Then '以入庫' Else '無' End as '狀態' "
            'sql += "  FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.FI101 = T1.FI101 "
            'sql += " WHERE (T0.FI103 = '3') AND (T1.FI103 < '4')"
            'sql += " WHERE T1.FI103 <= '4' AND (SUBSTRING(T0.[FI102],2,6) BETWEEN '" & Format(Date1.Value.Date, "yyMMdd") & "' AND '" & Format(Date2.Value.Date, "yyMMdd") & "' ) "
            Dim Whe代工製單 As String = ""
            If 顯示代工製單.Checked = False Then
                Whe代工製單 = " SUBSTRING(T0.[FI102],1,1) <> 'C' AND "
            End If

            '20190603-修改後
            sql = "  SELECT * "
            sql += " FROM( "
            sql += "       SELECT T0.[FI105] AS '生產日期', T0.[FI102] AS '製造單號', '' AS '補製單', T0.[FI101] AS '生產單號', T0.[FI106] AS '未入庫條碼', T0.[FI107] AS '存編', T0.[FI108] AS '品名', "
            sql += "              CASE T0.[FI103] WHEN '1' THEN '處理中' WHEN '2' THEN '已列印' WHEN '3' THEN '已清點' WHEN '4' THEN '以入庫' ELSE '無' END AS '狀態', '' AS '時間', '' AS '時段' "
            sql += "       FROM [@FinishItem2] T0 LEFT OUTER JOIN [OBTN] T1     ON T0.[FI106] = T1.[DistNumber] "
            sql += "                              LEFT OUTER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
            sql += "       WHERE SUBSTRING(T0.[FI102],2,6) >= '" & Format(Date1.Value.Date, "yyMMdd") & "' AND SUBSTRING(T0.[FI102],2,6) <= '" & Format(Date2.Value.Date, "yyMMdd") & "' AND "
            sql += "             T0.[FI103] IN ('1','2','3','4') AND "
            sql += Whe代工製單
            sql += "             T1.[DistNumber] IS NULL "
            sql += " ) A LEFT OUTER JOIN "
            sql += " ( "
            sql += "       SELECT T0.[FI107] AS '存編', COUNT(T0.[FI107]) AS '總數量' "
            sql += "       FROM [@FinishItem2] T0 LEFT OUTER JOIN [OBTN] T1     ON T0.[FI106] = T1.[DistNumber] "
            sql += "                              LEFT OUTER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
            sql += "       WHERE SUBSTRING(T0.[FI102],2,6) >= '" & Format(Date1.Value.Date, "yyMMdd") & "' AND SUBSTRING(T0.[FI102],2,6) <= '" & Format(Date2.Value.Date, "yyMMdd") & "' AND "
            sql += "             T0.[FI103] IN ('1','2','3','4') AND "
            sql += Whe代工製單
            sql += "             T1.[DistNumber] IS NULL "
            sql += "       GROUP BY T0.[FI107] "
            sql += " ) B ON A.存編 = B.存編"


            '原始
            'sql = "     SELECT T0.[FI105] AS '生產日期', T0.[FI102] AS '製造單號', '' AS '補製單', T0.[FI101] AS '生產單號', T0.[FI106] AS '未入庫條碼', T0.[FI107] AS '存編', T0.[FI108] AS '品名', "
            'sql += "           CASE T0.[FI103] WHEN '1' THEN '處理中' WHEN '2' THEN '已列印' WHEN '3' THEN '已清點' WHEN '4' THEN '以入庫' ELSE '無' END AS '狀態', '' AS '時間', '' AS '時段' "
            'sql += "      FROM [@FinishItem2] T0 LEFT OUTER JOIN [OBTN] T1     ON T0.[FI106] = T1.[DistNumber] "
            'sql += "                             LEFT OUTER JOIN [@FI2Main] T2 ON T0.[FI101] = T2.[FI101] AND T0.[FI102] = T2.[FI102] "
            'sql += "     WHERE SUBSTRING(T0.[FI102],2,6) BETWEEN '" & Format(Date1.Value.Date, "yyMMdd") & "' AND '" & Format(Date2.Value.Date, "yyMMdd") & "' AND "
            'sql += "           T0.[FI103]                IN ('1','2','3','4') AND "
            'sql += Whe代工製單
            'sql += "           T1.[DistNumber]           IS NULL "
            'sql += "  ORDER BY T0.[FI102], T0.[FI101] "
        End If

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")
        dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")


        'dgvSourceMain.AutoResizeColumns()
        dgvSourceMainDisplay()
        Label8.Text = dgvSourceMain.RowCount
    End Sub

    Private Sub LoadSourceMain3()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        '20190603-修改zHLnvetoryThan3預存程式
        If RB1.Checked = True Then
            'sql = "SELECT T1.FI101 as '生產單號', T1.FI102 as '製單單號',T1.FI107 as '存貨編號',T1.FI108 as '品名',T1.FI106 as '條碼',T1.FI105 as '文件日期' FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.FI101 = T1.FI101 WHERE (T0.FI103 = '3') AND (T1.FI103 < '4')"
            'sql = "exec zHLnvetoryThan '" & TextBox1.Text & "','" & TextBox2.Text & "' "
            sql = "exec zHLnvetoryThan3 '" & Format(Date1.Value.Date, "yyMMdd") & "' , '" & Format(Date2.Value.Date, "yyMMdd") & "' , '" & "%" & Format(品名.Text, "") & "%" & "' , '" & 冷凍冷藏.Text & "' , '" & 補製單.Text & "' "

        End If

        If RB2.Checked = True Then
            '20190603-修改後
            sql = "  SELECT * "
            sql += " FROM( "
            sql += "       SELECT T1.[FI105] AS '生產日期', T1.[FI102] AS '製造單號', '' AS '補製單', T1.[FI101] AS '生產單號', T1.[FI106] AS '未入庫條碼', T1.[FI107] AS '存編', T1.[FI108] AS '品名', "
            sql += "              CASE T1.[FI103] WHEN '1' THEN '處理中' WHEN '2' THEN '已列印' WHEN '3' THEN '已清點' WHEN '4' THEN '以入庫' ELSE '無' END AS '狀態', '' AS '時間' "
            sql += "       FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.[FI101] = T1.[FI101] "
            sql += "       WHERE (T0.[FI103] = '3') AND (T1.[FI103] < '4') "
            sql += " ) A INNER JOIN"
            sql += " ("
            sql += "       SELECT T1.[FI107] AS '存編', COUNT(T1.[FI107]) AS '總數量' "
            sql += "       FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.[FI101] = T1.[FI101] "
            sql += "       WHERE (T0.[FI103] = '3') AND (T1.[FI103] < '4') "
            sql += "       GROUP BY T1.[FI107]"
            sql += " ) B ON A.存編 = B.存編"


            '原始
            'sql = "  SELECT T1.[FI105] as '生產日期', T1.[FI102] as '製造單號', T1.FI101 as '生產單號', T1.FI106 as '未入庫條碼', T1.FI107 as '存編', T1.FI108 as '品名', "
            'sql += " CASE T1.[FI103] When '1' Then '處理中' When '2' Then '已列印' When '3' Then '已清點' When '4' Then '以入庫' Else '無' End as '狀態' "
            'sql += " FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.FI101 = T1.FI101 "
            'sql += " WHERE (T0.FI103 = '3') AND (T1.FI103 < '4') "
        End If

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")
        dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")

        'dgvSourceMain.AutoResizeColumns()
        dgvSourceMainDisplay()
        Label8.Text = dgvSourceMain.RowCount
    End Sub


    Private Sub LoadSourceMain2()

        Dim DataAdapter2 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try

            If RB1.Checked = True Then
                'sql = "SELECT T1.FI101 as '生產單號', T1.FI102 as '製單單號',T1.FI107 as '存貨編號',T1.FI108 as '品名',T1.FI106 as '條碼',T1.FI105 as '文件日期' FROM [@FI1Main] T0 INNER JOIN [@FinishItem1] T1 ON T0.FI101 = T1.FI101 WHERE (T0.FI103 = '3') AND (T1.FI103 < '4')"
                'sql = "exec zHLnvetoryThan2 '" & TextBox1.Text & "','" & TextBox2.Text & "' "
                sql = "exec zHLnvetoryThan2 '" & Format(Date1.Value.Date, "yyMMdd") & "','" & Format(Date2.Value.Date, "yyMMdd") & "' "
            End If

            If RB2.Checked = True Then
                'sql = "SELECT T1.FI101 as '生產單號', T1.FI102 as '製單單號', T1.FI107 as '存貨編號', T1.FI108 as '品名', T1.FI106 as '條碼',T1.FI105 as '文件日期' FROM [@FI2Main] T0 INNER JOIN [@FinishItem2] T1 ON T0.FI101 = T1.FI101 WHERE (T0.FI103 = '3') AND (T1.FI103 < '4')"
                sql = "SELECT '' as '生產數', '' as '作廢數', '' as '入庫數', '' as '作廢入庫', '' as '差異數' "
            End If

            DataAdapter2 = New SqlDataAdapter(sql, DBConn)
            DataAdapter2.Fill(ks1DataSet, "DT2")
            dgvSourceMain2.DataSource = ks1DataSet.Tables("DT2")

            dgvSourceMain2.AutoResizeColumns()
            Label8.Text = dgvSourceMain.RowCount
            MsgBox("查詢完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(dgvSourceMain, "")
    End Sub

    Private Sub RB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged, RB2.CheckedChanged
        顯示代工製單.Visible = False
        顯示代工製單.Checked = False
        If RB2.Checked = True Then
            顯示代工製單.Visible = True
        End If
    End Sub
    '20190603-增加
    Private Sub CheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢品名.CheckedChanged, 查詢冷凍冷藏.CheckedChanged, 查詢補製單.CheckedChanged

        If 查詢品名.Checked = False Then
            品名.Text = ""
        End If

        If 查詢冷凍冷藏.Checked = False Then
            冷凍冷藏.Text = ""
        End If

        If 查詢補製單.Checked = False Then
            補製單.Text = ""
        End If

    End Sub
    '20190603-增加
    Private Sub dgvSourceMain_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSourceMain.CellClick

        For i = 0 To dgvSourceMain.RowCount - 1
            If dgvSourceMain.Rows(i).Cells("存編").Value = dgvSourceMain.CurrentRow.Cells("存編").Value Then
                品項總數.Text = dgvSourceMain.CurrentRow.Cells("總數量").Value
            End If
        Next

    End Sub
    '20190603-增加 20190619修改
    Private Sub dgvSourceMainDisplay()

        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True

            If 查詢品名.Checked = False And 查詢冷凍冷藏.Checked = False And 查詢補製單.Checked = False Then
                Select Case column.Name
                    Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 0
                    Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 1
                    Case "補製單" : column.HeaderText = "補製單" : column.DisplayIndex = 2
                    Case "生產單號" : column.HeaderText = "生產單號" : column.DisplayIndex = 3
                    Case "未入庫條碼" : column.HeaderText = "未入庫條碼" : column.DisplayIndex = 4
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 5
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 6
                    Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 7
                    Case "時間" : column.HeaderText = "時間" : column.DisplayIndex = 8
                    Case "時段" : column.HeaderText = "時段" : column.DisplayIndex = 9
                    Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 10 : column.Visible = False
                    Case Else
                        column.Visible = False
                End Select
            Else
                Select Case column.Name
                    Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 0
                    Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 1
                    Case "補製單" : column.HeaderText = "補製單" : column.DisplayIndex = 2
                    Case "生產單號" : column.HeaderText = "生產單號" : column.DisplayIndex = 3
                    Case "未入庫條碼" : column.HeaderText = "未入庫條碼" : column.DisplayIndex = 4
                    Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 5
                    Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 6
                    Case "狀態" : column.HeaderText = "狀態" : column.DisplayIndex = 7
                    Case "時間" : column.HeaderText = "時間" : column.DisplayIndex = 8
                    Case "總數量" : column.HeaderText = "總數量" : column.DisplayIndex = 9 : column.Visible = False
                    Case Else
                        column.Visible = False
                End Select
            End If
        Next

        dgvSourceMain.AutoResizeColumns()

    End Sub
End Class