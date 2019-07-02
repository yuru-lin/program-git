Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 磅秤品項設定v100   '20141120   
    '    '------>DGV<------
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet

    '------>變數<------
    'Dim 作業單位 As String = ""

    '    '------>變數<------
    '    Dim Process As String   '製程--存貨0/代工1
    '    Dim Frozen As String    '凍藏--冷藏0/冷凍1
    '    Dim Category As String  '類別--全雞/分切/內臟
    '    Dim OrderNum As String
    Dim 雞種代號s As String = ""
    Dim 存編代號s As String = ""
    Dim 作業台號s As Byte = 99
    Dim 冷凍冷藏s As String = ""

    Dim sss3 As String = "T"

    Private Sub 磅秤品項設定v100_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Select Case IDNumber.ToUpper()
            Case "MANAGER" : RB電宰.Checked = True : GB單位.Visible = True
            Case "KS-14" : RB電宰.Checked = True
            Case "KS9491" : RB電宰.Checked = True
            Case "KS-21" : RB加工.Checked = True
            Case Else : RB電宰.Checked = True
        End Select

        載入雞種()
        查詢存編UpDGV_初始化()
        製造單號.Text = ""
        製單品項.Text = ""

    End Sub

    Private Sub RB單位初始化_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB電宰.CheckedChanged, RB加工.CheckedChanged
        If RB電宰.Checked = True Then : 作業單位.Text = "電宰" : End If
        If RB加工.Checked = True Then : 作業單位.Text = "加工" : End If
        初始化()

    End Sub

    Private Sub 初始化()

        品WT21.Text = "" : 品WT22.Text = "" : 品WT23.Text = ""
        Wr雞種.Text = "" : Wr代號.Text = "" : Wr凍藏.Text = "" : Wr類別.Text = "" : LWr凍藏.Text = ""

        Bu01.Enabled = True : Bu02.Enabled = True : Bu03.Enabled = True : Bu04.Enabled = True : Bu05.Enabled = True
        Bu06.Enabled = True : Bu07.Enabled = True : Bu08.Enabled = True : Bu09.Enabled = True : Bu10.Enabled = True

        Select Case 作業單位.Text
            Case "電宰"
                Bu01.Visible = True : Bu02.Visible = True : Bu03.Visible = True : Bu04.Visible = True : Bu05.Visible = True
                Bu06.Visible = True : Bu07.Visible = True : Bu08.Visible = True : Bu09.Visible = True : Bu10.Visible = True
            Case "加工"
                Bu01.Visible = True : Bu02.Visible = False : Bu03.Visible = False : Bu04.Visible = False : Bu05.Visible = False
                Bu06.Visible = False : Bu07.Visible = False : Bu08.Visible = False : Bu09.Visible = False : Bu10.Visible = False
        End Select

    End Sub

    Private Sub 查詢存編UpDGV_初始化()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "SELECT T0.[OrderNum] AS '槽位', T1.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[U_CK02] AS '製單', T0.[Frozen] AS '凍藏', T0.[Category] AS '類別' "
        SQLCmd.CommandText += "  FROM [Z_KS_ScaleOITMList] T0 LEFT JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLCmd.CommandText += " WHERE T0.[U_CK02] = '99999999'"

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "存編代號s")
        存編Up.DataSource = DataSetDGV.Tables("存編代號s")

        存編Up.AutoResizeColumns()

    End Sub

    '------>載入雞種<------
    Private Sub 載入雞種()
        If DataSetDGV.Tables.Contains("雞種代號sALL") Then : DataSetDGV.Tables("雞種代號sALL").Clear() : End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Try
            SQLCmd.CommandText = "    SELECT [No] AS '代號', [Kind] AS '雞種' FROM [Z_KS_CKind]  ORDER BY [Sid] "
            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "雞種代號sALL")

            If DataSetDGV.Tables("雞種代號sALL").Rows.Count > 0 Then

                雞種s.DataSource = DataSetDGV.Tables("雞種代號sALL")
                雞種s.DisplayMember = "雞種"
                雞種s.SelectedIndex = -1
            Else

                雞種s.Text = ""
                MsgBox("無雞種資料")
            End If
        Catch ex As Exception
            MsgBox("載入雞種: " & ex.Message)
            Exit Sub
        End Try
    End Sub

    'Private Sub 作業製單_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 作業製單.TextChanged
    '    If Microsoft.VisualBasic.Left(製造單號.Text, 1) = "1" Then
    '        Dim 雞種 As DataTable = DataSetDGV.Tables("雞種代號sALL")
    '        Dim oCriteria As String = " 代號 = '" & Microsoft.VisualBasic.Mid(製單.CurrentRow.Cells("存編").Value, 5, 1) & "' "
    '        Dim foundRow() As DataRow

    '        foundRow = 雞種.Select(oCriteria)
    '        If foundRow.Length > 0 Then
    '            '雞種s.Text = foundRow(0)("雞種")
    '            Label28.Text = foundRow(0)("雞種")
    '        Else
    '            '雞種s.Text = ""
    '        End If
    '        'End If

    '    Else
    '    End If

    'End Sub

    Private Sub 雞種s_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雞種s.SelectedIndexChanged
        If 雞種s.Text <> "System.Data.DataRowView" Then
            Dim dt As DataTable = DataSetDGV.Tables("雞種代號sALL")
            Dim oCriteria As String = "雞種 = '" & 雞種s.Text & "'"
            Dim foundRow() As DataRow

            foundRow = dt.Select(oCriteria)
            If foundRow.Length > 0 Then
                雞種代號s = foundRow(0)("代號")
            Else
                雞種代號s = ""
            End If
        End If

    End Sub

    '------>載入製單<------
    Private Sub 查詢製單_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢製單.Click
        查詢製單DGV()
    End Sub

    Private Sub 查詢製單DGV()
        If 製單.RowCount > 0 Then : DataSetDGV.Tables("UCK02").Clear() : End If

        Dim SQLQuery As String = ""
        Dim strWHERE As String = ""
        Select Case 作業單位.Text
            Case "電宰" : strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('1','2','3','4','5','6','X') "
            Case "加工" : strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('2','3','5','6','X','7','8') "
        End Select

        SQLQuery = "   SELECT T0.[U_M03] AS '製造單號', T1.[ItemName] AS '雞種', T0.[U_M04] AS '啟用否', T0.[ItemCode] AS '存編' "
        SQLQuery += "    FROM [OWOR] T0 INNER JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLQuery += "   WHERE     SUBSTRING(T0.[U_M03],2,6) = '" & Format(DocDate.Value.Date, "yyMMdd") & "' "
        SQLQuery += "         AND T0.[Status] = 'R' "
        SQLQuery += strWHERE
        SQLQuery += "         AND T0.[U_M04] IN ('Y','N') "
        SQLQuery += "ORDER BY SUBSTRING(T0.[U_M03],2,6), SUBSTRING(T0.[U_M03],1,1), SUBSTRING(T0.[U_M03],8,3) "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = SQLQuery
        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "UCK02")
        製單.DataSource = DataSetDGV.Tables("UCK02")

        製單.AutoResizeColumns()

        If 製單.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 製單_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 製單.CellClick

        If 製單.RowCount = 0 Then : 製造單號.Text = "" : Exit Sub
        Else
            製造單號.Text = 製單.CurrentRow.Cells("製造單號").Value
            製單品項.Text = 製單.CurrentRow.Cells("雞種").Value
            'Label27.Text = Microsoft.VisualBasic.Mid(製單.CurrentRow.Cells("存編").Value, 5, 1)

            If Microsoft.VisualBasic.Left(製造單號.Text, 1) Like "[1,2,3,7,8,X]" Then
                存編代號s = "25"    '存貨
            Else
                存編代號s = "31"    '代工
            End If

        End If

    End Sub

    Private Sub Bu製單選定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu製單選定.Click

        If 製造單號.Text = "" Then : Exit Sub : End If

        If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1").Clear() : End If
        If 存編Up.RowCount > 0 Then : DataSetDGV.Tables("存編代號s").Clear() : End If

        Select Case Bu製單選定.Text
            Case "製單選定"
                製單.Visible = False
                參數.Visible = True
                Bu製單選定.Text = "製單更換"
            Case "製單更換"
                製單.Visible = True
                參數.Visible = False
                Bu製單選定.Text = "製單選定"
                製造單號.Text = ""
                製單品項.Text = ""

        End Select

        'DataSetDGV.Tables("ItemCode1").Clear()
        'DataSetDGV.Tables("存編代號s").Clear()
        初始化()

        If Microsoft.VisualBasic.Left(製造單號.Text, 1) = "1" Or Microsoft.VisualBasic.Left(製造單號.Text, 1) = "4" Then
            Dim 雞種 As DataTable = DataSetDGV.Tables("雞種代號sALL")
            Dim oCriteria As String = " 代號 = '" & Microsoft.VisualBasic.Mid(製單.CurrentRow.Cells("存編").Value, 5, 1) & "' "
            Dim foundRow() As DataRow

            foundRow = 雞種.Select(oCriteria)
            If foundRow.Length > 0 Then
                雞種s.Text = foundRow(0)("雞種")
                雞種s.Enabled = False
            Else
                雞種s.Text = ""
            End If

        Else
            雞種s.Enabled = True
            雞種s.SelectedIndex = 0
        End If

    End Sub


    '------>載入存編<------
    Private Sub 查詢存編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢存編.Click

        Wr雞種.Text = "" : Wr代號.Text = "" : Wr凍藏.Text = "" : Wr類別.Text = ""

        If 雞種代號s = "" Then : MsgBox("未選擇雞種", 48, "警告") : Exit Sub : End If
        If 存編代號s = "" Then : MsgBox("未選擇製單", 48, "警告") : Exit Sub : End If
        If 凍藏s.Text = "" Then : MsgBox("未選擇冷凍冷藏", 48, "警告") : Exit Sub : End If
        If 類別s.Text = "" Then : MsgBox("未選擇類別", 48, "警告") : Exit Sub : End If

        Wr雞種.Text = 雞種s.Text
        Wr代號.Text = 雞種代號s
        Wr凍藏.Text = 凍藏s.Text
        Wr類別.Text = 類別s.Text
        LWr凍藏.Text = 凍藏s.SelectedIndex + 1

        查詢存編DGV()
    End Sub

    Private Sub 查詢存編DGV()
        If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1").Clear() : End If

        'Select Case 凍藏s.SelectedIndex
        '    Case "0" : 冷凍冷藏s = "('1')"
        '    Case "1" : 冷凍冷藏s = "('2','3')"
        'End Select

        Select Case Wr凍藏.Text
            Case "冷凍" : 冷凍冷藏s = "('1')"
            Case "冷藏" : 冷凍冷藏s = "('2','3')"
        End Select

        Dim 類別ss As String = ""
        Select Case 類別s.Text
            Case "全雞" : 類別ss = "('1','2')"
            Case "內臟" : 類別ss = "('1')"
                'Case "分切" : 類別ss = "('1','2')"
        End Select


        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = ""
        Dim str品T2W1 As String = "ALL" : Dim str品T2W2 As String = "ALL" : Dim str品T2W3 As String = "ALL"
        If 品WT21.Text <> "" Then : str品T2W1 = 品WT21.Text : End If
        If 品WT22.Text <> "" Then : str品T2W2 = 品WT22.Text : End If
        If 品WT23.Text <> "" Then : str品T2W3 = 品WT23.Text : End If

        If 包含查詢.Checked Then

            strWHERE1 += " AND ([ItemName] Like '%" & str品T2W1 & "%'  "
            strWHERE2 += " OR   [ItemName] Like '%" & str品T2W2 & "%'  "
            strWHERE3 += " OR   [ItemName] Like '%" & str品T2W3 & "%') "
        Else

            If 品WT21.Text <> "" Then : strWHERE1 += " AND [ItemName] Like '%" & 品WT21.Text & "%' " : End If
            If 品WT22.Text <> "" Then : strWHERE2 += " AND [ItemName] Like '%" & 品WT22.Text & "%' " : End If
            If 品WT23.Text <> "" Then : strWHERE3 += " AND [ItemName] Like '%" & 品WT23.Text & "%' " : End If
        End If

        Dim SQLQuery As String = ""
        SQLQuery = "  SELECT [ItemName] AS '品名', [ItemCode] AS '存編' "
        SQLQuery += "   FROM [OITM] "
        SQLQuery += "  WHERE SUBSTRING([ItemCode],1,2)  = '" & 存編代號s & "' AND "
        SQLQuery += "        SUBSTRING([ItemCode],3,1) IN  " & 冷凍冷藏s & "  AND "
        SQLQuery += "        SUBSTRING([ItemCode],4,1) IN  " & 類別ss & "     AND "
        SQLQuery += "        SUBSTRING([ItemCode],5,1)  = '" & Wr代號.Text & "'   "
        SQLQuery += strWHERE1 + strWHERE2 + strWHERE3
        SQLQuery += "    AND [ManSerNum] = 'Y' AND [validFor] = 'Y' AND [U_CancelFI] = 'Y' "
        If Microsoft.VisualBasic.Left(製造單號.Text, 1) = "1" Then
            SQLQuery += "    AND [SalPackMsr] <> '盒' "
        End If


        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = SQLQuery
        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "ItemCode1")
        存編.DataSource = DataSetDGV.Tables("ItemCode1")
        存編.AutoResizeColumns()

        If 存編.RowCount = 0 Then : MsgBox("查無資料。", 48, "警告") : End If

    End Sub

    Private Sub Bu01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu01.Click
        作業台號s = 1 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu02.Click
        作業台號s = 2 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu03.Click
        作業台號s = 3 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu04.Click
        作業台號s = 4 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu05.Click
        作業台號s = 5 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu06.Click
        作業台號s = 6 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu07.Click
        作業台號s = 7 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu08.Click
        作業台號s = 8 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu09.Click
        作業台號s = 9 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu10.Click
        作業台號s = 10 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub 查詢存編UpDGV22()
        作業台號s = 99 : Bu()
    End Sub

    Private Sub Bu()

        Bu01.Enabled = True : Bu02.Enabled = True : Bu03.Enabled = True : Bu04.Enabled = True : Bu05.Enabled = True
        Bu06.Enabled = True : Bu07.Enabled = True : Bu08.Enabled = True : Bu09.Enabled = True : Bu10.Enabled = True

        Select Case 作業台號s
            Case "1" : Bu01.Enabled = False
            Case "2" : Bu02.Enabled = False
            Case "3" : Bu03.Enabled = False
            Case "4" : Bu04.Enabled = False
            Case "5" : Bu05.Enabled = False
            Case "6" : Bu06.Enabled = False
            Case "7" : Bu07.Enabled = False
            Case "8" : Bu08.Enabled = False
            Case "9" : Bu09.Enabled = False
            Case "10" : Bu10.Enabled = False
            Case "99"
        End Select

    End Sub

    Private Sub 查詢存編UpDGV()

        If 存編代號s = "" Then : MsgBox("未選擇製單", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
        If 凍藏s.SelectedIndex = -1 Then : MsgBox("未選擇冷凍冷藏", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
        If 類別s.Text = "" Then : MsgBox("未選擇類別", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If

        If 存編Up.RowCount > 0 Then : DataSetDGV.Tables("存編代號s").Clear() : End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        'SQLCmd.CommandText = "  SELECT [ItemCode] AS '存編', [ItemName] AS '品名' "
        'SQLCmd.CommandText += "   FROM [OITM] "
        'SQLCmd.CommandText += "  WHERE SUBSTRING([ItemCode],1,2) = '" & 存編代號s & "' AND  SUBSTRING([ItemCode],3,1) IN '" & 冷凍冷藏s & "' AND SUBSTRING([ItemCode],5,1) = '" & 雞種代號s & "' "
        'SQLCmd.CommandText += "    AND ([ItemName] Like '%" & 品名1.Text & "%' OR [ItemName] Like '%" & 品名2.Text & "%') "
        'SQLCmd.CommandText += "    AND [ManSerNum] = 'Y' AND [validFor] = 'Y' "

        SQLCmd.CommandText = "SELECT T0.[OrderNum] AS '槽位', T1.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[U_CK02] AS '製單', T0.[Frozen] AS '凍藏', T0.[Category] AS '類別', [Sid] AS 'Sid' "
        SQLCmd.CommandText += "  FROM [Z_KS_ScaleOITMList] T0 LEFT JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLCmd.CommandText += " WHERE T0.[U_CK02] = '" & 製造單號.Text & "' AND T0.[Frozen] = '" & 凍藏s.SelectedIndex + 1 & "' AND T0.[Category] = '" & 類別s.Text & "' AND T0.[OrderNum] = '" & 作業台號s & "' AND T0.[Cancel] = 'Y' "


        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "存編代號s")
        存編Up.DataSource = DataSetDGV.Tables("存編代號s")

        存編Up.AutoResizeColumns()

        'If 存編Up.RowCount = 0 Then
        '    MsgBox("查無資料。", 48, "警告")
        'End If

        If sss3 = "T" Then
            MsgBox("查詢完成", , "查詢完成")
            sss3 = "T"
        End If



        'MsgBox("查詢完成", , "查詢完成")

    End Sub

    Private Sub 新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增.Click

        If 作業台號s = 99 Then
            MsgBox("未選擇槽位", 48, "警告")
            Exit Sub
        End If

        UP存編DGV()

    End Sub

    Private Sub UP存編DGV()

        'If T2DGV2.RowCount = 0 Then
        '    新增存編TF = False
        '    '查詢客編T2DGV2()
        'End If

        For Each oRow As DataGridViewRow In 存編.SelectedRows
            Dim Row As DataRow
            Row = DataSetDGV.Tables("存編代號s").NewRow
            Row.Item("製單") = 製造單號.Text
            'Row.Item("凍藏") = 凍藏s.SelectedIndex + 1
            Row.Item("凍藏") = LWr凍藏.Text
            Row.Item("類別") = 類別s.Text
            Row.Item("槽位") = 作業台號s
            Row.Item("存編") = oRow.Cells("存編").Value
            Row.Item("品名") = oRow.Cells("品名").Value

            DataSetDGV.Tables("存編代號s").Rows.Add(Row)
            存編Up.AutoResizeColumns()
        Next

        UP存編資料()
        '查詢存編UpDGV()
        '新增存編TF = True

        'For Each oRow As DataGridViewRow In T2DGV1.SelectedRows
        '    'Dim Row As DataRow
        '    'Row = DataSetDGV.Tables("T2DGV2").NewRow
        '    'oRow.Cells("客編D1").Value
        '    'oRow.Cells("名稱D1").Value

        '    DataSetDGV.Tables("T2DGV1").Rows.Add(oRow)
        '    T2DGV1.AutoResizeColumns()
        'Next

    End Sub

    Private Sub UP存編資料()

        If 存編Up.RowCount = 0 Then
            '新增存編TF = False
            '查詢客編T2DGV2()
            MsgBox("沒有資料可更新")
            Exit Sub

        End If


        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        'If LineNum000.Text <> "" And ItemCode00.Text <> "" Then
        '    '-->刪除存編明細<--
        '    SQLCmd.CommandText = "  DELETE FROM [Z_KS_ScaleOITMList] WHERE [MainSid] = '" & SidTxT.Text & "' AND [OrderNum] = '" & OrderNum & "' "
        '    '-->更新存編<--
        '    SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum000.Text & "','" & ItemCode00.Text & "') "
        'End If

        'If LineNum001.Text <> "" And ItemCode01.Text <> "" Then
        '    SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum001.Text & "','" & ItemCode01.Text & "') "
        'End If


        SQLCmd.CommandText = "   UPDATE [Z_KS_ScaleOITMList] SET "
        SQLCmd.CommandText += "         [Cancel]   = 'N' "
        SQLCmd.CommandText += "   WHERE [U_CK02]   = '" & 製造單號.Text & "'             AND "
        'SQLCmd.CommandText += "         [Frozen]   = '" & (凍藏s.SelectedIndex + 1) & "' AND "  'LWr凍藏.Text
        SQLCmd.CommandText += "         [Frozen]   = '" & LWr凍藏.Text & "' AND "
        SQLCmd.CommandText += "         [Category] = '" & 類別s.Text & "'                AND "
        SQLCmd.CommandText += "         [OrderNum] = '" & 作業台號s & "'                 AND "
        SQLCmd.CommandText += "         [Cancel]   = 'Y' "

        For i As Integer = 0 To 存編Up.RowCount - 1
            'SQLCmd.CommandText = "  DELETE FROM [Z_KS_ScaleOITMList] WHERE [MainSid] = '" & SidTxT.Text & "' AND [OrderNum] = '" & OrderNum & "' "
            SQLCmd.CommandText += "  INSERT INTO [Z_KS_ScaleOITMList] ([U_CK02],[Frozen],[Category],[OrderNum],[ItemCode],[Cancel]) VALUES "
            SQLCmd.CommandText += " ('" & 製造單號.Text & "'                      , "
            'SQLCmd.CommandText += "  '" & (凍藏s.SelectedIndex + 1) & "'          , "
            SQLCmd.CommandText += "  '" & LWr凍藏.Text & "'                       , "
            SQLCmd.CommandText += "  '" & 類別s.Text & "'                         , "
            SQLCmd.CommandText += "  '" & 作業台號s & "'                          , "
            SQLCmd.CommandText += "  '" & 存編Up.Rows(i).Cells("存編").Value & "' , "
            SQLCmd.CommandText += "  'Y'                                          ) "

        Next

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        sss3 = "F"

        查詢存編UpDGV()

        'If UP存編資料TF = True Then
        MsgBox("存編更新完成")
        'End If

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

        'Dim DBConn As SqlConnection = Login.DBConn
        'Dim SQLCmd As SqlCommand = New SqlCommand
        'SQLCmd.Connection = DBConn

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