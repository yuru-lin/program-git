Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class ScaleOITM_褔利社
    '    '------>DGV<------
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet

    '    '------>變數<------
    Dim Chicken As String = ""
    Dim ItemCode2 As String = ""
    Dim OrderNums As Byte = 99
    'Dim Frozens As String = ""
    Dim 凍藏Ts As Byte = 99
    Dim 雞種Ts As String = ""

    Dim sss3 As String = "T"

    Private Sub ScaleOITM_褔利社_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        凍藏T.Text = "" : 類別T.Text = "" : 雞種T.Text = ""

        'ss查詢存編UpDGV()
        載入雞種()
    End Sub

    Private Sub 查詢品項_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢品項.Click

        If 凍藏s.SelectedIndex = -1 Then
            MsgBox("未選擇冷凍冷藏", 48, "警告")
            Exit Sub
        End If

        If 類別s.Text = "" Then
            MsgBox("未選擇類別", 48, "警告")
            Exit Sub
        End If

        凍藏T.Text = 凍藏s.Text
        凍藏Ts = 凍藏s.SelectedIndex + 1
        類別T.Text = 類別s.Text
        雞種T.Text = 雞種s.Text
        ss查雞種()  '雞種Ts

        ss查詢存編UpDGV()

    End Sub

    Private Sub ss查雞種()

        If 雞種s.Text <> "System.Data.DataRowView" Then
            Dim dt As DataTable = DataSetDGV.Tables("ChickenALL")
            Dim oCriteria As String = "雞種 = '" & 雞種s.Text & "'"
            Dim foundRow() As DataRow

            foundRow = dt.Select(oCriteria)
            If foundRow.Length > 0 Then
                雞種Ts = foundRow(0)("代號")
            Else
                雞種Ts = ""
            End If
        End If

    End Sub

    Private Sub ss查詢存編UpDGV()

        If 存編Up.RowCount > 0 Then
            DataSetDGV.Tables("ItemCode2").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = " SELECT T1.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[Category] AS '類別', T0.[Sid] AS 'Sid' "
        SQLCmd.CommandText += "  FROM [Z_KS_ScaleOITMList] T0 LEFT JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLCmd.CommandText += " WHERE T0.[U_CK02] = '10'  AND T0.[Frozen] = '" & 凍藏Ts & "' AND T0.[Category] = '" & 類別T.Text & "' "
        SQLCmd.CommandText += "   AND SUBSTRING(T0.[ItemCode],5,1) =  '" & 雞種Ts & "' "
        SQLCmd.CommandText += "   AND T0.[OrderNum] = '1' AND T0.[Cancel] = 'Y' "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "ItemCode2")
        存編Up.DataSource = DataSetDGV.Tables("ItemCode2")

        存編Up.AutoResizeColumns()

    End Sub

    '------>載入雞種<------
    Private Sub 載入雞種()

        If DataSetDGV.Tables.Contains("ChickenALL") Then
            DataSetDGV.Tables("ChickenALL").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Try
            SQLCmd.CommandText = "    SELECT [No] AS '代號', [Kind] AS '雞種' "
            SQLCmd.CommandText += "     FROM [Z_KS_CKind] "
            SQLCmd.CommandText += " ORDER BY [Sid] "

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "ChickenALL")

            If DataSetDGV.Tables("ChickenALL").Rows.Count > 0 Then
                雞種s.DataSource = DataSetDGV.Tables("ChickenALL")
                雞種s.DisplayMember = "雞種"
                雞種s.SelectedIndex = -1
            Else
                雞種s.Text = ""
                MsgBox("無雞種資料")
            End If

        Catch ex As Exception
            MsgBox("載入雞種: " & ex.Message)
            End
        End Try
    End Sub

    Private Sub 雞種s_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雞種s.SelectedIndexChanged

        If 雞種s.Text <> "System.Data.DataRowView" Then
            Dim dt As DataTable = DataSetDGV.Tables("ChickenALL")
            Dim oCriteria As String = "雞種 = '" & 雞種s.Text & "'"
            Dim foundRow() As DataRow

            foundRow = dt.Select(oCriteria)
            If foundRow.Length > 0 Then
                Chicken = foundRow(0)("代號")
            Else
                Chicken = ""
            End If
        End If

    End Sub

    ' '' ''------>載入製單<------
    '' ''Private Sub 查詢製單_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢製單.Click
    '' ''    查詢製單DGV()
    '' ''End Sub

    '' ''Private Sub 查詢製單DGV()
    '' ''    If 製單.RowCount > 0 Then
    '' ''        DataSetDGV.Tables("UCK02").Clear()
    '' ''    End If

    '' ''    Dim DBConn As SqlConnection = Login.DBConn
    '' ''    Dim SQLCmd As SqlCommand = New SqlCommand
    '' ''    SQLCmd.Connection = DBConn

    '' ''    SQLCmd.CommandText = "   SELECT T0.[U_M03] AS '製造單號', T1.[ItemName] AS '雞種', T0.[U_M04] AS '啟用否' " '
    '' ''    SQLCmd.CommandText += "    FROM [OWOR] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
    '' ''    SQLCmd.CommandText += "   WHERE     SUBSTRING(T0.[U_M03],2,6) = '" & Format(DocDate.Value.Date, "yyMMdd") & "' "
    '' ''    SQLCmd.CommandText += "         AND T0.[Status] = 'R' "
    '' ''    SQLCmd.CommandText += "         AND LEFT(T0.[U_M03],1) IN ('1','2','3','4','5','6','X') "
    '' ''    SQLCmd.CommandText += "         AND T0.[U_M04] IN ('Y','N') "
    '' ''    SQLCmd.CommandText += "ORDER BY SUBSTRING(T0.[U_M03],2,6), SUBSTRING(T0.[U_M03],1,1), SUBSTRING(T0.[U_M03],8,3) "

    '' ''    SQLCmd.Parameters.Clear()
    '' ''    SQLCmd.ExecuteNonQuery()

    '' ''    DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
    '' ''    DataAdapterDGV.Fill(DataSetDGV, "UCK02")
    '' ''    製單.DataSource = DataSetDGV.Tables("UCK02")

    '' ''    製單.AutoResizeColumns()

    '' ''    If 製單.RowCount = 0 Then
    '' ''        MsgBox("查無資料。", 48, "警告")
    '' ''    End If

    '' ''End Sub

    '' ''Private Sub 製單_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 製單.CellClick

    '' ''    If 製單.RowCount = 0 Then
    '' ''        製造單號.Text = ""
    '' ''        Exit Sub

    '' ''    Else
    '' ''        製造單號.Text = 製單.CurrentRow.Cells("製造單號").Value

    '' ''        If Microsoft.VisualBasic.Left(製造單號.Text, 1) Like "[1,2,3,7,8,X]" Then
    '' ''            ItemCode2 = "25"    '存貨
    '' ''        Else
    '' ''            ItemCode2 = "31"    '代工
    '' ''        End If

    '' ''    End If
    '' ''End Sub

    '------>載入存編<------
    Private Sub 查詢存編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢存編.Click

        If 雞種T.Text = "" Then
            MsgBox("未選擇雞種", 48, "警告")
            Exit Sub
        End If

        If 凍藏T.Text = "" Then
            MsgBox("未選擇冷凍冷藏", 48, "警告")
            Exit Sub
        End If

        If 類別T.Text = "" Then
            MsgBox("未選擇類別", 48, "警告")
            Exit Sub
        End If

        查詢存編DGV()

    End Sub

    Private Sub 查詢存編DGV()
        If 存編.RowCount > 0 Then
            DataSetDGV.Tables("ItemCode").Clear()
        End If

        Dim strWhere1 As String = ""

        Select Case 類別T.Text
            Case "全雞" : strWhere1 += "        SUBSTRING([ItemCode],4,1) =  '1'       AND SUBSTRING([ItemCode],6,1) <> 'Z' AND "
            Case "分切" : strWhere1 += "        SUBSTRING([ItemCode],4,1) =  '2'       AND SUBSTRING([ItemCode],6,1) <> 'Z' AND "
            Case "內臟" : strWhere1 += "        SUBSTRING([ItemCode],4,1) IN ('1','2') AND SUBSTRING([ItemCode],6,1) =  'Z' AND "
            Case Else
                Exit Sub
        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "  SELECT [ItemName] AS '品名', [ItemCode] AS '存編' "
        SQLCmd.CommandText += "   FROM [OITM] "
        SQLCmd.CommandText += "  WHERE SUBSTRING([ItemCode],1,2) =  '25'             AND "
        SQLCmd.CommandText += "        SUBSTRING([ItemCode],3,1) = '" & 凍藏Ts & "'  AND "
        SQLCmd.CommandText += strWhere1
        SQLCmd.CommandText += "        SUBSTRING([ItemCode],5,1) = '" & 雞種Ts & "'      "
        'SQLCmd.CommandText += "    AND [ItemName] Like '%員%' "

        If 品名1.Text <> "" Then
            SQLCmd.CommandText += "    AND ([ItemName] Like '%" & 品名1.Text & "%' "
        End If

        If 品名2.Text <> "" Then
            SQLCmd.CommandText += "     OR  [ItemName] Like '%" & 品名2.Text & "%' ) "
        Else
            If 品名1.Text <> "" Then
                SQLCmd.CommandText += "     )"
            End If
        End If

        SQLCmd.CommandText += "    AND [ManSerNum] = 'Y' AND [validFor] = 'Y' AND [U_CancelFI] = 'Y' "


        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "ItemCode")
        存編.DataSource = DataSetDGV.Tables("ItemCode")

        存編.AutoResizeColumns()

        If 存編.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    '' ''Private Sub Bu01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu01.Click
    '' ''    OrderNums = 1
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = False
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu02.Click
    '' ''    OrderNums = 2
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = False
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu03.Click
    '' ''    OrderNums = 3
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = False
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu04.Click
    '' ''    OrderNums = 4
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = False
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu05.Click
    '' ''    OrderNums = 5
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = False
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu06.Click
    '' ''    OrderNums = 6
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = False
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu07.Click
    '' ''    OrderNums = 7
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = False
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu08.Click
    '' ''    OrderNums = 8
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = False
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu09.Click
    '' ''    OrderNums = 9
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = False
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    '' ''Private Sub Bu10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu10.Click
    '' ''    OrderNums = 10
    '' ''    查詢存編UpDGV()

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = False

    '' ''End Sub

    '' ''Private Sub 查詢存編UpDGV22()
    '' ''    OrderNums = 99

    '' ''    Bu01.Enabled = True
    '' ''    Bu02.Enabled = True
    '' ''    Bu03.Enabled = True
    '' ''    Bu04.Enabled = True
    '' ''    Bu05.Enabled = True
    '' ''    Bu06.Enabled = True
    '' ''    Bu07.Enabled = True
    '' ''    Bu08.Enabled = True
    '' ''    Bu09.Enabled = True
    '' ''    Bu10.Enabled = True

    '' ''End Sub

    Private Sub 查詢存編UpDGV()

        If 凍藏T.Text = "" Then
            MsgBox("未選擇冷凍冷藏", 48, "警告")
            Exit Sub
        End If

        If 類別T.Text = "" Then
            MsgBox("未選擇冷凍冷藏", 48, "警告")
            Exit Sub
        End If

        If 存編Up.RowCount > 0 Then
            DataSetDGV.Tables("ItemCode2").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = " SELECT T1.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[Category] AS '類別', T0.[Sid] AS 'Sid' "
        SQLCmd.CommandText += "  FROM [Z_KS_ScaleOITMList] T0 LEFT JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLCmd.CommandText += " WHERE T0.[U_CK02] = '10'  AND T0.[Frozen] = '" & 凍藏Ts & "' AND T0.[Category] = '" & 類別T.Text & "' "
        SQLCmd.CommandText += "   AND SUBSTRING(T0.[ItemCode],5,1) =  '" & 雞種Ts & "' "
        SQLCmd.CommandText += "   AND T0.[OrderNum] = '1' AND T0.[Cancel] = 'Y' "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "ItemCode2")
        存編Up.DataSource = DataSetDGV.Tables("ItemCode2")

        存編Up.AutoResizeColumns()

        If sss3 = "T" Then
            MsgBox("查詢完成", , "查詢完成")
            sss3 = "T"
        End If

    End Sub

    Private Sub 新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增.Click

        UP存編DGV()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'For Each oRow As DataGridViewRow In 存編Up.SelectedRows
        '存編Up.Rows.Remove(oRow.Cells("存編").Value)
        DataSetDGV.Tables("ItemCode2").Rows.Remove(存編Up.CurrentRow.Cells("存編").Value)
        'DataSetDGV.Tables("ItemCode2").Rows.Remove(oRow.Cells("存編").Value)
        'Next

        'ks1DataSet.Tables("過磅明細").


        'For i As Integer = 0 To 存編Up.RowCount - 1
        '    存編Up.Rows.Remove(存編Up.Rows(i).)
        'Next
        'For i As Integer = 0 To 存編Up.RowCount - 1
        '    SQLCmd.CommandText += "  INSERT INTO [Z_KS_ScaleOITMList] ([U_CK02],[Frozen],[Category],[OrderNum],[ItemCode],[Cancel]) VALUES "
        '    SQLCmd.CommandText += " ('10'                                         , "
        '    SQLCmd.CommandText += "  '" & 凍藏Ts & "'          , "
        '    SQLCmd.CommandText += "  '" & 類別T.Text & "'                         , "
        '    SQLCmd.CommandText += "  '1'                                          , "
        '    SQLCmd.CommandText += "  '" & 存編Up.Rows(i).Cells("存編").Value & "' , "
        '    SQLCmd.CommandText += "  'Y'                                          ) "
        '    For i As Integer = 0 To 存編Up.RowCount - 1
        '        If 存編Up.Rows(i).Cells("存編").Value = 存編Up.CurrentRow.Cells("存編").Value Then
        '           存編Up.Rows(i).Cells("存編").
        '            Exit Sub
        '        End If
        '    Next
        'Next

    End Sub


    Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles 存編Up.UserDeletingRow

        Dim startingBalanceRow As DataGridViewRow = 存編Up.Rows(0)

        ' Check if the starting balance row is included in the selected rows
        If 存編Up.SelectedRows.Contains(startingBalanceRow) Then
            ' Do not allow the user to delete the Starting Balance row.
            MessageBox.Show("Cannot delete Starting Balance row!")

            ' Cancel the deletion if the Starting Balance row is included.
            e.Cancel = True
        End If
    End Sub

    Private Sub UP存編DGV()

        For i As Integer = 0 To 存編.RowCount - 1
            If Mid(存編.Rows(i).Cells("存編").Value, 5, 1) <> 雞種Ts Then
                MsgBox("雞種錯誤無法更新")
                Exit Sub
            End If
        Next

        For i As Integer = 0 To 存編.RowCount - 1
            If Mid(存編.Rows(i).Cells("存編").Value, 3, 1) <> 凍藏Ts Then
                MsgBox("冷凍冷藏錯誤無法更新")
                Exit Sub
            End If
        Next

        For Each oRow As DataGridViewRow In 存編.SelectedRows
            Dim Row As DataRow
            Row = DataSetDGV.Tables("ItemCode2").NewRow
            'Row.Item("製單") = "10"
            'Row.Item("凍藏") = 凍藏Ts
            Row.Item("類別") = 類別T.Text
            'Row.Item("槽位") = "1"
            Row.Item("存編") = oRow.Cells("存編").Value
            Row.Item("品名") = oRow.Cells("品名").Value

            DataSetDGV.Tables("ItemCode2").Rows.Add(Row)
            存編Up.AutoResizeColumns()
        Next

        'UP存編資料()

    End Sub

    Private Sub UP存編資料()

        If 存編Up.RowCount = 0 Then
            MsgBox("沒有資料可更新")
            Exit Sub
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "   UPDATE [Z_KS_ScaleOITMList] SET "
        SQLCmd.CommandText += "         [Cancel]   = 'N' "
        SQLCmd.CommandText += "   WHERE [U_CK02]   = '10'                            AND "
        SQLCmd.CommandText += "         [Frozen]   = '" & 凍藏Ts & "'                AND "
        SQLCmd.CommandText += "         [Category] = '" & 類別T.Text & "'            AND "
        SQLCmd.CommandText += "         [OrderNum] = '1'                             AND "
        SQLCmd.CommandText += "         SUBSTRING([ItemCode],5,1) = '" & 雞種Ts & "' AND "
        SQLCmd.CommandText += "         [Cancel]   = 'Y' "

        For i As Integer = 0 To 存編Up.RowCount - 1
            SQLCmd.CommandText += "  INSERT INTO [Z_KS_ScaleOITMList] ([U_CK02],[Frozen],[Category],[OrderNum],[ItemCode],[Cancel]) VALUES "
            SQLCmd.CommandText += " ('10'                                         , "
            SQLCmd.CommandText += "  '" & 凍藏Ts & "'          , "
            SQLCmd.CommandText += "  '" & 類別T.Text & "'                         , "
            SQLCmd.CommandText += "  '1'                                          , "
            SQLCmd.CommandText += "  '" & 存編Up.Rows(i).Cells("存編").Value & "' , "
            SQLCmd.CommandText += "  'Y'                                          ) "

        Next

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        sss3 = "F"

        查詢存編UpDGV()

        MsgBox("存編更新完成")

    End Sub

    Private Sub 移除存編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 移除存編.Click

        移除存編.Enabled = False

        If 移除存編.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區
                Del存編資料()

            End If
        End If

        移除存編.Enabled = True

    End Sub


    Private Sub Del存編資料()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For Each oRow As DataGridViewRow In 存編Up.SelectedRows

                sql = "   UPDATE [Z_KS_ScaleOITMList] SET "
                sql += "         [Cancel]   = 'N' "
                sql += "   WHERE [Sid]      = '" & oRow.Cells("Sid").Value & "' AND  "
                sql += "         [Cancel]   = 'Y' "

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        查詢存編UpDGV()
        'MsgBox("刪除項目完成!", 64, "成功")
    End Sub




End Class