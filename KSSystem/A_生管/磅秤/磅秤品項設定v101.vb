Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports Microsoft.VisualBasic

'v101
'20150115加入加工作業及改寫作業方式 
'原存KaiShing 改存KaiShingPlug
'20150116 修改完成
Public Class 磅秤品項設定v101
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet
    Dim dt1 As DataTable = New DataTable
    Dim dt2 As DataTable = New DataTable

    '------>變數<------
    Dim 單位代碼 As String = ""
    Dim 機台代碼 As Byte = 99   '1~10分級槽, 81~90加工, 99無作業
    Dim 雞種代碼 As String = ""
    Dim 存編代碼 As String = ""
    Dim 凍藏代碼 As String = ""
    Dim 廠別代碼 As String = "" '1= 序號,2= 批次


    Dim 新增CB存編Up As String = "Y" : Dim 新增CB存編 As String = "Y"

    Private Sub 磅秤品項設定v101_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Select Case IDNumber.ToUpper()
            Case "MANAGER" ': RB電宰.Checked = True : RB電宰.Visible = True : RB加工.Visible = True : RB加批.Visible = True ': GB單位.Visible = True
                Select Case UCase(Login.LogonCompanySr) '主機名稱
                    Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                        RB加批.Checked = True : RB電宰.Visible = False : RB加工.Visible = True : RB加批.Visible = True
                    Case Else
                        RB電宰.Checked = True : RB電宰.Visible = True : RB加工.Visible = True : RB加批.Visible = True
                End Select
            Case "KS14" : RB電宰.Checked = True : RB電宰.Visible = True : RB加工.Visible = True
            Case "KS9491" : RB電宰.Checked = True : RB電宰.Visible = True
            Case "KS22" : RB加工.Checked = True : RB加工.Visible = True : RB加批.Visible = True
            Case Else
                RB電宰.Checked = True
        End Select
        製單品項.Text = ""
        載入雞種_初始化()
        查詢存編UpDGV_初始化() : 新增CB存編Up = "N"

    End Sub

    Private Sub RB單位初始化_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB電宰.CheckedChanged, RB加工.CheckedChanged, RB加批.CheckedChanged
        If RB電宰.Checked = True Then : 作業單位.Text = "電宰" : 廠別代碼 = "1" : End If
        If RB加工.Checked = True Then : 作業單位.Text = "加工" : 廠別代碼 = "2" : End If
        If RB加批.Checked = True Then : 作業單位.Text = "加批" : 廠別代碼 = "2" : End If
        作業初始化()

    End Sub

    Private Sub 作業初始化()

        '製單品項.Text = ""
        品WT211.Text = "" : 品WT221.Text = "" : 品WT231.Text = ""
        品WT21.Text = "" : 品WT22.Text = "" : 品WT23.Text = ""
        Wr雞種.Text = "" : Wr代號.Text = "" : Wr凍藏.Text = "" : Wr類別.Text = ""

        Bu01.Enabled = True : Bu02.Enabled = True : Bu03.Enabled = True : Bu04.Enabled = True : Bu05.Enabled = True
        Bu06.Enabled = True : Bu07.Enabled = True : Bu08.Enabled = True : Bu09.Enabled = True : Bu10.Enabled = True

        Select Case 作業單位.Text
            Case "電宰"
                Bu01.Visible = True : Bu02.Visible = True : Bu03.Visible = True : Bu04.Visible = True : Bu05.Visible = True
                Bu06.Visible = True : Bu07.Visible = True : Bu08.Visible = True : Bu09.Visible = True : Bu10.Visible = True
            Case "加工"
                Bu01.Visible = True : Bu02.Visible = False : Bu03.Visible = False : Bu04.Visible = False : Bu05.Visible = False
                Bu06.Visible = False : Bu07.Visible = False : Bu08.Visible = False : Bu09.Visible = False : Bu10.Visible = False
            Case "加批"
                Bu01.Visible = False : Bu02.Visible = True : Bu03.Visible = False : Bu04.Visible = False : Bu05.Visible = False
                Bu06.Visible = False : Bu07.Visible = False : Bu08.Visible = False : Bu09.Visible = False : Bu10.Visible = False
        End Select

    End Sub

    Private Sub Bu01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu01.Click
        Select Case 作業單位.Text
            Case "電宰" : 機台代碼 = 1 : 查詢存編UpDGV() : Bu()
            Case "加工" : 機台代碼 = 81 : 查詢存編UpDGV() : Bu()
        End Select
    End Sub
    Private Sub Bu02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu02.Click
        Select Case 作業單位.Text
            Case "電宰" : 機台代碼 = 2 : 查詢存編UpDGV() : Bu()
            Case "加批" : 機台代碼 = 82 : 查詢存編UpDGV() : Bu()
        End Select
        '機台代碼 = 2 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu03.Click
        機台代碼 = 3 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu04_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu04.Click
        機台代碼 = 4 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu05_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu05.Click
        機台代碼 = 5 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu06_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu06.Click
        機台代碼 = 6 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu07_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu07.Click
        機台代碼 = 7 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu08_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu08.Click
        機台代碼 = 8 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu09_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu09.Click
        機台代碼 = 9 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub Bu10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu10.Click
        機台代碼 = 10 : 查詢存編UpDGV() : Bu()
    End Sub
    Private Sub 查詢存編UpDGV22()
        機台代碼 = 99 : Bu()
    End Sub

    Private Sub Bu()
        Bu01.Enabled = True : Bu02.Enabled = True : Bu03.Enabled = True : Bu04.Enabled = True : Bu05.Enabled = True
        Bu06.Enabled = True : Bu07.Enabled = True : Bu08.Enabled = True : Bu09.Enabled = True : Bu10.Enabled = True

        Select Case 機台代碼
            Case "1", "81" : Bu01.Enabled = False
            Case "2", "82" : Bu02.Enabled = False
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
        存編資料比對()

    End Sub

    '------>載入雞種<------
    Private Sub 載入雞種_初始化()
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

    Private Sub 雞種s_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 雞種s.SelectedIndexChanged
        If 雞種s.Text <> "System.Data.DataRowView" Then
            Dim dt As DataTable = DataSetDGV.Tables("雞種代號sALL")
            Dim oCriteria As String = "雞種 = '" & 雞種s.Text & "'"
            Dim foundRow() As DataRow

            foundRow = dt.Select(oCriteria)
            If foundRow.Length > 0 Then
                雞種代碼 = foundRow(0)("代號")
            Else
                雞種代碼 = ""
            End If
        End If

    End Sub

    '------>作業存編<------
    Private Sub 查詢存編UpDGV_初始化()

        If 存編Up.RowCount > 0 Then : DataSetDGV.Tables("存編Up").Clear() : End If '清除存編Up資料
        Dim SQLADD As String = ""

        SQLADD = " SELECT T0.[OrderNum] AS '槽位', T1.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[U_CK02] AS '製單', T0.[Frozen] AS '凍藏', T0.[Category] AS '類別', [Sid] AS 'ID碼' "
        SQLADD += "  FROM [KaiShingPlug].[dbo].[Z_KS_ScaleOITMList] T0 LEFT JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLADD += " WHERE T0.[U_CK02] = '99999999'"

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "存編Up")
            存編Up.DataSource = DataSetDGV.Tables("存編Up")
            If 新增CB存編Up = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                存編Up.Columns.Insert(0, checkBoxColumn)
            End If
            查詢存編UpDGV_Play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 查詢存編UpDGV()
        If 存編代碼 = "" Then : MsgBox("未選擇製單", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
         Select 作業單位.Text
            Case "電宰", "加工"
                'If 凍藏s.SelectedIndex = -1 Then : MsgBox("未選擇冷凍冷藏", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
                'If Wr類別.Text = "" Then : MsgBox("未選擇類別", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
                Select Case UCase(Login.LogonCompanySr) '主機名稱
                    Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                    Case Else
                        'If 凍藏s.SelectedIndex = -1 Then : MsgBox("未選擇冷凍冷藏", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
                        'If Wr類別.Text = "" Then : MsgBox("未選擇類別", 48, "警告") : 查詢存編UpDGV22() : Exit Sub : End If
                End Select
            Case "加批"
        End Select

        If 存編Up.RowCount > 0 Then : DataSetDGV.Tables("存編Up").Clear() : End If
        Dim SQLADD As String = ""

        SQLADD = "SELECT T0.[OrderNum] AS '槽位', T1.[ItemName] AS '品名', T0.[ItemCode] AS '存編', T0.[U_CK02] AS '製單', T0.[Frozen] AS '凍藏', T0.[Category] AS '類別', [Sid] AS 'ID碼' "
        SQLADD += "  FROM [KaiShingPlug].[dbo].[Z_KS_ScaleOITMList] T0 LEFT JOIN [OITM] T1 ON T0.[ItemCode] = T1.[ItemCode] "
        SQLADD += " WHERE T0.[U_CK02] = '" & 製造單號.Text & "' AND T0.[Frozen] = '" & Wr凍藏代.Text & "' AND T0.[Category] = '" & Wr類別.Text & "' AND T0.[OrderNum] = '" & 機台代碼 & "' AND T0.[Cancel] = 'Y' "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "存編Up")
            存編Up.DataSource = DataSetDGV.Tables("存編Up")
            If 新增CB存編Up = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                存編Up.Columns.Insert(0, checkBoxColumn)
            End If
            查詢存編UpDGV_Play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'If sss3 = "T" Then
        '    MsgBox("查詢完成", , "查詢完成")
        '    sss3 = "T"
        'End If

    End Sub

    Private Sub 查詢存編UpDGV_Play()
        For Each column As DataGridViewColumn In 存編Up.Columns
            column.Visible = True : column.ReadOnly = True

            Select Case 作業單位.Text
                Case "電宰", "加工"
                    Select Case column.Name
                        Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                        Case "槽位" : column.HeaderText = "槽位" : column.DisplayIndex = 1
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 3
                        Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 4
                        Case "凍藏" : column.HeaderText = "凍藏" : column.DisplayIndex = 5 : column.Visible = True
                        Case "類別" : column.HeaderText = "類別" : column.DisplayIndex = 6 : column.Visible = True
                        Case "ID碼" : column.HeaderText = "ID碼" : column.DisplayIndex = 7
                        Case Else
                            column.Visible = False
                    End Select
                Case "加批"
                    Select Case column.Name
                        Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                        Case "槽位" : column.HeaderText = "槽位" : column.DisplayIndex = 1
                        Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 2
                        Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 3
                        Case "製單" : column.HeaderText = "製單" : column.DisplayIndex = 4
                        Case "凍藏" : column.HeaderText = "凍藏" : column.DisplayIndex = 5 : column.Visible = False
                        Case "類別" : column.HeaderText = "類別" : column.DisplayIndex = 6 : column.Visible = False
                        Case "ID碼" : column.HeaderText = "ID碼" : column.DisplayIndex = 7
                        Case Else
                            column.Visible = False
                    End Select
            End Select

        Next
        存編Up.AutoResizeColumns()

    End Sub

    '------>載入製單<------
    Private Sub 查詢製單_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢製單.Click
        查詢製單DGV()
    End Sub

    Private Sub 查詢製單DGV()
        If 製單.RowCount > 0 Then : DataSetDGV.Tables("UCK02").Clear() : End If
        Dim SQLQuery As String = "" : Dim strWHERE As String = ""
        Select Case 作業單位.Text
            Case "電宰" : strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('1','2','3','4','5','6','X') "
            Case "加工" ': strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('2','3','7','9') "
                Select Case UCase(Login.LogonCompanySr) '主機名稱
                    Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                        : strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('1','2','3','4','5','6','X') "
                    Case Else
                        strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('2','3','7','9') "
                End Select
            Case "加批" : strWHERE += "         AND LEFT(T0.[U_M03],1) IN ('7','8','9','C','Y') "
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

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "UCK02")
            製單.DataSource = DataSetDGV.Tables("UCK02")
            製單.AutoResizeColumns()

            If 製單.RowCount = 0 Then
                MsgBox("查無資料。", 48, "警告")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 製單_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles 製單.CellClick
        If 製單.RowCount = 0 Then : 製造單號.Text = "" : Exit Sub
        Else
            製造單號.Text = 製單.CurrentRow.Cells("製造單號").Value
            製單品項.Text = 製單.CurrentRow.Cells("雞種").Value
            Select 作業單位.Text
                Case "電宰", "加工"
                    If Microsoft.VisualBasic.Left(製造單號.Text, 1) Like "[1,2,3,7,8,X]" Then
                        存編代碼 = "25"    '存貨
                    Else
                        存編代碼 = "31','32"    '代工
                    End If
                    Select Case UCase(Login.LogonCompanySr) '主機名稱
                        Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                            Lt存編.Text = Microsoft.VisualBasic.Left(製單.CurrentRow.Cells("存編").Value, 13)
                        Case Else
                    End Select
                Case "加批"
                    If Microsoft.VisualBasic.Left(製造單號.Text, 1) Like "['7','8','C','Y']" Then
                        存編代碼 = "25"    '存貨
                        Lt存編.Text = Microsoft.VisualBasic.Left(製單.CurrentRow.Cells("存編").Value, 13)
                    Else
                        存編代碼 = "32"    '代工
                        Lt存編.Text = Microsoft.VisualBasic.Left(製單.CurrentRow.Cells("存編").Value, 13)
                    End If

            End Select

        End If

    End Sub

    Private Sub Bu製單選定_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu製單選定.Click
        If 製造單號.Text = "" Then : Exit Sub : End If
        If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1").Clear() : End If
        If 存編Up.RowCount > 0 Then : DataSetDGV.Tables("存編Up").Clear() : End If

        Select Case Bu製單選定.Text
            Case "製單選定"
                製單.Visible = False

                Select Case UCase(Login.LogonCompanySr) '主機名稱
                    Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                        參數2.Visible = True
                        參數2.Location = New Point(10, 93)
                    Case Else
                        Select Case 作業單位.Text
                            Case "電宰", "加工"
                                參數.Visible = True
                                'Select Case UCase(Login.LogonCompanySr) '主機名稱
                                '    Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                                '        參數2.Visible = True
                                '        參數2.Location = New Point(10, 93)
                                '    Case Else
                                '        參數.Visible = True
                                'End Select
                            Case "加批"
                                參數2.Visible = True
                                參數2.Location = New Point(10, 93)

                                '參數3.Visible = True
                                '參數3.Location = New Point(10, 93)
                        End Select

                End Select

                RB加工.Enabled = False
                RB加批.Enabled = False
                Bu製單選定.Text = "製單更換"
            Case "製單更換"
                製單.Visible = True
                參數.Visible = False
                參數2.Visible = False
                RB加工.Enabled = True
                RB加批.Enabled = True
                Bu製單選定.Text = "製單選定"
                製造單號.Text = ""
                製單品項.Text = ""
                If 存編Up.RowCount > 0 Then : DataSetDGV.Tables("存編Up").Clear() : End If
                If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1").Clear() : End If
                If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1s").Clear() : End If
                dt1.Clear() : dt2.Clear()
        End Select

        作業初始化()

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

        If RB加工.Checked = True Then : Bu01.PerformClick() : End If
        If RB加批.Checked = True Then : Bu02.PerformClick() : End If


    End Sub

    '------>載入存編<------
    Private Sub 查詢存編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢存編.Click

        Wr雞種.Text = "" : Wr代號.Text = "" : Wr凍藏.Text = "" : Wr類別.Text = ""

        If 雞種代碼 = "" Then : MsgBox("未選擇雞種", 48, "警告") : Exit Sub : End If
        If 存編代碼 = "" Then : MsgBox("未選擇製單", 48, "警告") : Exit Sub : End If
        If 凍藏s.Text = "" Then : MsgBox("未選擇冷凍冷藏", 48, "警告") : Exit Sub : End If
        If 類別s.Text = "" Then : MsgBox("未選擇類別", 48, "警告") : Exit Sub : End If

        Wr雞種.Text = 雞種s.Text
        Wr代號.Text = 雞種代碼
        Wr凍藏.Text = 凍藏s.Text
        Wr凍藏代.Text = 凍藏s.SelectedIndex + 1
        Wr類別.Text = 類別s.Text

        查詢存編DGV() : 新增CB存編 = "N"
        查詢存編UpDGV()
        存編資料比對()

    End Sub

    Private Sub Bu2查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu2查詢.Click, Bu3查詢.Click
        Wr凍藏代.Text = "" : Wr類別.Text = ""

        查詢存編DGV() : 新增CB存編 = "N"
        查詢存編UpDGV()
        存編資料比對()
    End Sub

    Private Sub 查詢存編DGV()
        If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1").Clear() : End If
        If 存編.RowCount > 0 Then : DataSetDGV.Tables("ItemCode1s").Clear() : End If
        dt1.Clear() : dt2.Clear()

        Dim SQLQuery As String = ""

        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = "" : Dim strWHERE4 As String = ""
        Dim str品T2W1 As String = "ALL" : Dim str品T2W2 As String = "ALL" : Dim str品T2W3 As String = "ALL"
        If 品WT21.Text <> "" Then : str品T2W1 = 品WT21.Text : End If
        If 品WT22.Text <> "" Then : str品T2W2 = 品WT22.Text : End If
        If 品WT23.Text <> "" Then : str品T2W3 = 品WT23.Text : End If

        Dim 存編W1 As String = "ALL"
        If Lt存編.Text <> "" Then
            存編W1 = Lt存編.Text
        End If

        If 包含查詢.Checked Then
            strWHERE1 += " AND ([ItemName] Like '%" & str品T2W1 & "%'  "
            strWHERE2 += " OR   [ItemName] Like '%" & str品T2W2 & "%'  "
            strWHERE3 += " OR   [ItemName] Like '%" & str品T2W3 & "%') "
        Else
            If 品WT21.Text <> "" Then : strWHERE1 += " AND [ItemName] Like '%" & 品WT21.Text & "%' " : End If
            If 品WT22.Text <> "" Then : strWHERE2 += " AND [ItemName] Like '%" & 品WT22.Text & "%' " : End If
            If 品WT23.Text <> "" Then : strWHERE3 += " AND [ItemName] Like '%" & 品WT23.Text & "%' " : End If
        End If

        Select Case 作業單位.Text
            Case "電宰", "加工"
                Select Case UCase(Login.LogonCompanySr) '主機名稱
                    Case "MR-SAP", "192.168.200.110", "192.168.0.14"
                        If Lt存編.Text = "" Then
                            strWHERE4 += ""
                        Else
                            strWHERE4 += "    AND (LEFT([ItemCode],13) = '" & 存編W1 & "' OR 'ALL' = '" & 存編W1 & "' ) "
                        End If

                        SQLQuery = "    SELECT [ItemName] AS '品名', [ItemCode] AS '存編' "
                        SQLQuery += "     FROM [OITM] "
                        SQLQuery += "    WHERE SUBSTRING([ItemCode],1,2) IN ('" & 存編代碼 & "') "
                        SQLQuery += "      AND [ItemCode] NOT LIKE  '%-1' AND [ItemName] NOT LIKE  'XX%' AND [ItemName] NOT LIKE  'xxx%'"
                        SQLQuery += strWHERE1 + strWHERE2 + strWHERE3 + strWHERE4
                        'SQLQuery += "    AND (LEFT([ItemCode],13) = '" & 存編W1 & "' OR 'ALL' = '" & 存編W1 & "' ) "
                        SQLQuery += "      AND [ManSerNum] = 'Y' AND [validFor] = 'Y' AND [U_CancelFI] = 'Y' "
                    Case Else
                        Select Case Wr凍藏.Text
                            Case "冷凍" : 凍藏代碼 = "('1')"
                            Case "冷藏" : 凍藏代碼 = "('2','3')"
                        End Select

                        Select Case 作業單位.Text
                            Case "電宰" : strWHERE4 += " SUBSTRING([ItemCode],4,1)  =  '1'          AND "
                                'Select Case Wr類別.Text
                                '    'Case "全雞" : strWHERE4 += " SUBSTRING([ItemCode],4,1)  =  '1'          AND "
                                '    'Case "內臟" : strWHERE4 += " SUBSTRING([ItemCode],4,1)  =  '2'          AND "
                                '    'Case "分切" : strWHERE4 += " SUBSTRING([ItemCode],4,1)  =  '2'          AND "
                                'End Select
                            Case "加工" : strWHERE4 += " SUBSTRING([ItemCode],4,1) IN ('1','2','3') AND "
                        End Select

                        SQLQuery = "  SELECT [ItemName] AS '品名', [ItemCode] AS '存編' "
                        SQLQuery += "   FROM [OITM] "
                        SQLQuery += "  WHERE SUBSTRING([ItemCode],1,2) IN ('" & 存編代碼 & "') AND "
                        SQLQuery += "        SUBSTRING([ItemCode],3,1) IN   " & 凍藏代碼 & "   AND "
                        'SQLQuery += "        SUBSTRING([ItemCode],4,1)  = '1'                AND "
                        SQLQuery += strWHERE4
                        SQLQuery += "        SUBSTRING([ItemCode],5,1)  = '" & Wr代號.Text & "'  "
                        SQLQuery += strWHERE1 + strWHERE2 + strWHERE3
                        SQLQuery += "    AND [ManSerNum] = 'Y' AND [validFor] = 'Y' AND [U_CancelFI] = 'Y' "
                End Select
            Case "加批"
                If Lt存編.Text = "" Then
                    strWHERE4 += ""
                Else
                    strWHERE4 += "    AND (LEFT([ItemCode],13) = '" & 存編W1 & "' OR 'ALL' = '" & 存編W1 & "' ) "
                End If

                SQLQuery = "    SELECT [ItemName] AS '品名', [ItemCode] AS '存編' "
                SQLQuery += "     FROM [OITM] "
                SQLQuery += "    WHERE SUBSTRING([ItemCode],1,2) IN ('" & 存編代碼 & "') "
                SQLQuery += "      AND [ItemCode] NOT LIKE  '%-1' AND [ItemName] NOT LIKE  'XX%' AND [ItemName] NOT LIKE  'xxx%'"
                SQLQuery += strWHERE1 + strWHERE2 + strWHERE3 + strWHERE4
                'SQLQuery += "    AND (LEFT([ItemCode],13) = '" & 存編W1 & "' OR 'ALL' = '" & 存編W1 & "' ) "
                SQLQuery += "      AND [ManBtchNum] = 'Y' AND [validFor] = 'Y' AND [U_CancelFI] = 'Y' "

        End Select

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "ItemCode1")
            DataAdapterDGV.Fill(DataSetDGV, "ItemCode1s")
            dt1 = DataSetDGV.Tables("ItemCode1")
            dt2 = DataSetDGV.Tables("ItemCode1s")
            存編.DataSource = dt1
            '存編.DataSource = DataSetDGV.Tables("ItemCode1")
            If 新增CB存編 = "Y" Then
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Name = "選擇"
                存編.Columns.Insert(0, checkBoxColumn)
            End If
            查詢存編DGV_Play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If 存編.RowCount = 0 Then : MsgBox("查無資料。", 48, "警告") : End If

    End Sub

    Private Sub 查詢存編DGV_Play()
        For Each column As DataGridViewColumn In 存編.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "    " : column.DisplayIndex = 0 : column.Width = 30 : column.ReadOnly = False
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 1
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2
                Case Else
                    column.Visible = False
            End Select
        Next
        存編.AutoResizeColumns()

    End Sub

    Private Sub 存編資料比對()
        'If 存編.RowCount = 0 Then : Exit Sub : End If '清除dt1資料
        If 存編.RowCount > 0 Then : dt1.Clear() : End If '清除dt1資料
        dt1 = dt2.Copy : 存編.DataSource = dt1

        Dim counti As Integer = 存編Up.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim countx As Integer = 存編.Rows.Count
            For x As Integer = countx - 1 To 0 Step -1
                If 存編Up.Rows(i).Cells("存編").Value = 存編.Rows(x).Cells("存編").Value Then
                    存編.Rows.Remove(存編.Rows(x))
                End If
            Next
        Next
        查詢存編DGV_Play()

    End Sub

    Private Sub 新增_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增.Click
        If 存編.RowCount = 0 Then : MsgBox("未選擇存編", 48, "警告") : Exit Sub : End If
        If 機台代碼 = 99 Then : MsgBox("未選擇槽位", 48, "警告") : Exit Sub : End If
        UP存編資料()
        查詢存編UpDGV()

        存編資料比對()
    End Sub

    Private Sub UP存編資料()
        Dim SQLADD As String = ""

        Dim counti As Integer = 存編.Rows.Count
        For i As Integer = counti - 1 To 0 Step -1
            Dim isSelected As Boolean = Convert.ToBoolean(存編.Rows(i).Cells("選擇").Value)
            If isSelected Then
                SQLADD += "   INSERT INTO [KaiShingPlug].[dbo].[Z_KS_ScaleOITMList] ([U_CK02],[Frozen],[Category],[OrderNum],[ItemCode],[Cancel],[Site]) VALUES "
                SQLADD += " ('" & 製造單號.Text & "', "
                SQLADD += "  '" & Wr凍藏代.Text & "', "
                SQLADD += "  '" & Wr類別.Text & "', "
                SQLADD += "  '" & 機台代碼 & "', "
                SQLADD += "  '" & 存編.Rows(i).Cells("存編").Value & "', "
                SQLADD += "  'Y', '" & 廠別代碼 & "' ) " & vbCrLf
            End If

        Next

        'For Each oRow As DataGridViewRow In 存編.Rows
        '    Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
        '    If isSelected Then
        '        SQLADD += "  '" & oRow.Cells("存編").Value & "' , "
        '    End If
        'Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("存編更新完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        查詢存編UpDGV()

    End Sub

    Private Sub 移除存編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 移除存編.Click

        移除存編.Enabled = False
        If 移除存編.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要刪除?", MsgBoxStyle.YesNo, "確認刪除")
            If oAns = MsgBoxResult.Yes Then     'Yes執行區
                Del存編資料()
                查詢存編UpDGV()
                存編資料比對()
            End If
        End If
        移除存編.Enabled = True


    End Sub


    Private Sub Del存編資料()
        Dim SQLADD As String = ""
        For Each oRow As DataGridViewRow In 存編Up.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected Then
                SQLADD += "   UPDATE [KaiShingPlug].[dbo].[Z_KS_ScaleOITMList] SET [Cancel] = 'N' WHERE [Sid] = '" & oRow.Cells("ID碼").Value & "' AND [Cancel]   = 'Y' " & vbCrLf
            End If
        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            MsgBox("存編更新完成")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub 品WT211_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 品WT211.TextChanged
        品WT21.Text = 品WT211.Text
    End Sub

    Private Sub 品WT221_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 品WT221.TextChanged
        品WT22.Text = 品WT221.Text
    End Sub

    Private Sub 品WT231_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 品WT231.TextChanged
        品WT23.Text = 品WT231.Text
    End Sub
End Class