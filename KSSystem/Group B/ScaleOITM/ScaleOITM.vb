Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class ScaleOITM
    '------><------
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet
    'Dim DataSetTxT As DataSet = New DataSet


    '------><------
    Dim Process As String   '製程--存貨0/代工1
    Dim Frozen As String    '凍藏--冷藏0/冷凍1
    Dim Category As String  '類別--全雞/分切/內臟
    Dim OrderNum As String
    Dim Chicken As String

    '------><------
    Dim AnsHasRow As Boolean
    Dim 新增客戶TF As Boolean = True
    Dim UP存編資料TF As Boolean = True

    Private Sub ScaleOITM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        載入雞種()

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
                'ChickenTxT.Text = foundRow(0)("代號")
                Chicken = foundRow(0)("代號")
            Else
                'ChickenTxT.Text = ""
                Chicken = ""
            End If
        End If

    End Sub

    Private Sub 槽號s_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 槽號s.SelectedIndexChanged
        OrderNum = (槽號s.SelectedIndex + 1)

        If 製成s.Text = "" Or 凍藏s.Text = "" Or 雞種s.Text = "" Or 類別s.Text = "" Or 規格表TxT.Text = "" Then
            Exit Sub
        Else
            查詢規格表存編()
        End If

    End Sub



    '------>查詢規格表資料<------
    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If 製成s.Text = "" Or 凍藏s.Text = "" Or Chicken = "" Or 類別s.Text = "" Or 槽號s.Text = "" Then
            MsgBox("查詢資料不完整", 48, "警告")
            Exit Sub
        End If

        '製程--存貨0/代工1
        Select Case 製成s.SelectedIndex
            Case 0 : Process = "0"
            Case 1 : Process = "1"
        End Select

        '凍藏--冷藏0/冷凍1
        Select Case 凍藏s.SelectedIndex
            Case 0 : Frozen = "0"
            Case 1 : Frozen = "1"
        End Select

        Category = 類別s.Text
        'OrderNum = (槽號s.SelectedIndex + 1)

        製成s.Enabled = False
        凍藏s.Enabled = False
        雞種s.Enabled = False
        類別s.Enabled = False

        查詢規格表()
        清空規格表存編()

    End Sub

    Private Sub 重新查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 重新查詢.Click

        製成s.Enabled = True : 製成s.SelectedIndex = -1
        凍藏s.Enabled = True : 凍藏s.SelectedIndex = -1
        雞種s.Enabled = True : 雞種s.SelectedIndex = -1
        類別s.Enabled = True : 類別s.SelectedIndex = -1
        槽號s.Enabled = True : 槽號s.SelectedIndex = -1

        客編CkB.Checked = False
        客編TxT.Text = ""
        SidTxT.Text = ""

        清空規格表存編()

        If DGV1.RowCount > 0 Then
            DataSetDGV.Tables("DGV1").Clear()
        End If

        If T2DGV1.RowCount > 0 Then
            DataSetDGV.Tables("T2DGV1").Clear()
        End If

        If T2DGV2.RowCount > 0 Then
            DataSetDGV.Tables("T2DGV2").Clear()
        End If


    End Sub


    Private Sub 查詢規格表()
        If DGV1.RowCount > 0 Then
            DataSetDGV.Tables("DGV1").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        'SQLCmd.CommandText = "    SELECT DISTINCT T0.[Specification] AS '規格表', T0.[CardCode] AS '客編' "
        'SQLCmd.CommandText = "    SELECT DISTINCT T0.[Sid] AS 'Sid', T0.[Specification] AS '規格表' "
        'SQLCmd.CommandText += "     FROM [Z_KS_ScaleOITMMain] T0 LEFT  JOIN [Z_KS_ScaleOITMList] T1 ON T0.[Sid] = T1.[MainSid] "
        SQLCmd.CommandText = "    SELECT T0.[Sid] AS 'Sid', T0.[Specification] AS '規格表' "
        SQLCmd.CommandText += "     FROM [Z_KS_ScaleOITMMain] T0"

        'sql += "    WHERE T0.[CardCode] Like '%" & CardCodes & "%' AND T0.[Process] = '" & Process & "' AND T0.[Frozen] = '" & olblMac2 & "' AND T0.[OrderNum] = '" & OrderNums & "' AND T0.[Category] = '" & Categorys & "' AND T0.[Cancel] = 'Y' "
        'SQLCmd.CommandText += "    WHERE T0.[Process] = '" & Process & "' AND T0.[Frozen] = '" & Frozen & "' AND T0.[Category] = '" & Category & "' AND T0.[OrderNum] = '" & OrderNum & "' AND T0.[Cancel] = 'Y' "
        SQLCmd.CommandText += "     WHERE T0.[Process]       = '" & Process & "'        AND T0.[Frozen] = '" & Frozen & "' AND T0.[Chicken] = '" & Chicken & "' AND T0.[Category] = '" & Category & "' AND "

        'If 客編CkB.Checked = True Then
        '    'SQLCmd.CommandText += "      AND T0.[CardCode] Like '%" & 客編TxT.Text & "%' "
        '    SQLCmd.CommandText += "           T0.[CardCode] Like '%" & 客編TxT.Text & "%' AND T0.[Cancel] = 'Y' AND T1.[OrderNum] = '" & OrderNum & "' "
        'Else
        '    SQLCmd.CommandText += "           T0.[Cancel] = 'Y' AND T1.[OrderNum] = '" & OrderNum & "' "
        'End If

        If 客編CkB.Checked = True Then
            'SQLCmd.CommandText += "      AND T0.[CardCode] Like '%" & 客編TxT.Text & "%' "
            SQLCmd.CommandText += "           T0.[CardCode] Like '%" & 客編TxT.Text & "%' AND T0.[Cancel] = 'Y' "
        Else
            SQLCmd.CommandText += "           T0.[Cancel] = 'Y' "
        End If


        SQLCmd.CommandText += " ORDER BY T0.[Sid] "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "DGV1")
        DGV1.DataSource = DataSetDGV.Tables("DGV1")

        DGV1.AutoResizeColumns()

        If DGV1.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 清空規格表存編()

        規格表TxT.Text = ""
        客編ALLTxT.Text = ""

        LineNum000.Text = "" : ItemCode00.Text = "" : ItemName00.Text = ""  '01
        LineNum001.Text = "" : ItemCode01.Text = "" : ItemName01.Text = ""  '02
        LineNum002.Text = "" : ItemCode02.Text = "" : ItemName02.Text = ""  '03
        LineNum003.Text = "" : ItemCode03.Text = "" : ItemName03.Text = ""  '04
        LineNum004.Text = "" : ItemCode04.Text = "" : ItemName04.Text = ""  '05
        LineNum005.Text = "" : ItemCode05.Text = "" : ItemName05.Text = ""  '06
        LineNum006.Text = "" : ItemCode06.Text = "" : ItemName06.Text = ""  '07
        LineNum007.Text = "" : ItemCode07.Text = "" : ItemName07.Text = ""  '08
        LineNum008.Text = "" : ItemCode08.Text = "" : ItemName08.Text = ""  '09
        LineNum009.Text = "" : ItemCode09.Text = "" : ItemName09.Text = ""  '10
        LineNum010.Text = "" : ItemCode10.Text = "" : ItemName10.Text = ""  '11
        LineNum011.Text = "" : ItemCode11.Text = "" : ItemName11.Text = ""  '12
        LineNum012.Text = "" : ItemCode12.Text = "" : ItemName12.Text = ""  '13
        LineNum013.Text = "" : ItemCode13.Text = "" : ItemName13.Text = ""  '14
        LineNum014.Text = "" : ItemCode14.Text = "" : ItemName14.Text = ""  '15


    End Sub

    '------>查詢 T1資料<------
    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick

        If DGV1.RowCount = 0 Then
            規格表TxT.Text = ""
            Exit Sub
        End If


        規格表TxT.Text = DGV1.CurrentRow.Cells("規格表").Value
        SidTxT.Text = DGV1.CurrentRow.Cells("Sid").Value


        查詢規格表客編()
        查詢規格表存編()
        查詢客編T2DGV2()

    End Sub

    Private Sub 查詢規格表客編()

        客編ALLTxT.Text = ""
        If DataSetDGV.Tables.Contains("CardCodeALL") Then
            DataSetDGV.Tables("CardCodeALL").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "    SELECT T0.[CardCode] AS '客編' "
        'SQLCmd.CommandText += "     FROM [Z_KS_ScaleOITMMain] T0 LEFT  JOIN [Z_KS_ScaleOITMList] T1 ON T0.[Sid] = T1.[MainSid] "
        SQLCmd.CommandText += "     FROM [Z_KS_ScaleOITMMain] T0  "
        SQLCmd.CommandText += "    WHERE T0.[Sid] = '" & SidTxT.Text & "' AND T0.[Cancel] = 'Y' "
        'SQLCmd.CommandText += "    WHERE T0.[Process] = '" & Process & "' AND T0.[Frozen] = '" & Frozen & "' AND T0.[Category] = '" & Category & "' AND T0.[OrderNum] = '" & OrderNum & "' AND T0.[Cancel] = 'Y' "
        'SQLCmd.CommandText += "      AND T0.[Specification] = '" & 規格表TxT.Text & "' "
        'SQLCmd.CommandText += "     WHERE T0.[Process]       = '" & Process & "'        AND T0.[Frozen] = '" & Frozen & "' AND T0.[Chicken] = '" & Chicken & "' AND T0.[Category] = '" & Category & "' AND "
        ''SQLCmd.CommandText += "           T0.[Specification] = '" & 規格表TxT.Text & "' AND T0.[Cancel] = 'Y' AND T1.[OrderNum] = '" & OrderNum & "' "
        'SQLCmd.CommandText += "           T0.[Specification] = '" & 規格表TxT.Text & "' AND T0.[Cancel] = 'Y' "

        'SQLCmd.CommandText += " ORDER BY 1 "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "CardCodeALL")

        If DataSetDGV.Tables("CardCodeALL").Rows.Count > 0 Then
            客編ALLTxT.Text = DataSetDGV.Tables("CardCodeALL").Rows(0).Item("客編")
        Else
            客編ALLTxT.Text = ""
        End If

        If DataSetDGV.Tables("CardCodeALL").Rows.Count = 0 Then
            MsgBox("查無客編資料。", 48, "警告")
        End If

    End Sub

    Private Sub 查詢規格表存編()

        '客編ALLTxT.Text = ""
        If DataSetDGV.Tables.Contains("ItemCodeALL") Then
            DataSetDGV.Tables("ItemCodeALL").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "    SELECT T1.[LineNum] AS '順序', T1.[ItemCode] AS '存編', O1.[ItemName] AS '品名' "
        SQLCmd.CommandText += "     FROM [Z_KS_ScaleOITMMain] T0 LEFT JOIN [Z_KS_ScaleOITMList] T1 ON T0.[Sid]      = T1.[MainSid]  "
        SQLCmd.CommandText += "                                  LEFT JOIN [OITM]               O1 ON T1.[ItemCode] = O1.[ItemCode] "
        SQLCmd.CommandText += "     WHERE T0.[Process]       = '" & Process & "'        AND T0.[Frozen] = '" & Frozen & "' AND T0.[Chicken] = '" & Chicken & "' AND T0.[Category] = '" & Category & "' AND "
        SQLCmd.CommandText += "           T0.[Specification] = '" & 規格表TxT.Text & "' AND T0.[Cancel] = 'Y'              AND T1.[OrderNum] = '" & OrderNum & "'     "
        SQLCmd.CommandText += " ORDER BY 1, 2 "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "ItemCodeALL")


        If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 0 Then
            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 0 Then
                LineNum000.Text = DataSetDGV.Tables("ItemCodeALL").Rows(0).Item("順序")
                ItemCode00.Text = DataSetDGV.Tables("ItemCodeALL").Rows(0).Item("存編")
                ItemName00.Text = DataSetDGV.Tables("ItemCodeALL").Rows(0).Item("品名")
            Else
                LineNum000.Text = "" : ItemCode00.Text = "" : ItemName00.Text = ""  '01
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 1 Then
                LineNum001.Text = DataSetDGV.Tables("ItemCodeALL").Rows(1).Item("順序")
                ItemCode01.Text = DataSetDGV.Tables("ItemCodeALL").Rows(1).Item("存編")
                ItemName01.Text = DataSetDGV.Tables("ItemCodeALL").Rows(1).Item("品名")
            Else
                LineNum001.Text = "" : ItemCode01.Text = "" : ItemName01.Text = ""  '02
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 2 Then
                LineNum002.Text = DataSetDGV.Tables("ItemCodeALL").Rows(2).Item("順序")
                ItemCode02.Text = DataSetDGV.Tables("ItemCodeALL").Rows(2).Item("存編")
                ItemName02.Text = DataSetDGV.Tables("ItemCodeALL").Rows(2).Item("品名")
            Else
                LineNum002.Text = "" : ItemCode02.Text = "" : ItemName02.Text = ""  '03
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 3 Then
                LineNum003.Text = DataSetDGV.Tables("ItemCodeALL").Rows(3).Item("順序")
                ItemCode03.Text = DataSetDGV.Tables("ItemCodeALL").Rows(3).Item("存編")
                ItemName03.Text = DataSetDGV.Tables("ItemCodeALL").Rows(3).Item("品名")
            Else
                LineNum003.Text = "" : ItemCode03.Text = "" : ItemName03.Text = ""  '04
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 4 Then
                LineNum004.Text = DataSetDGV.Tables("ItemCodeALL").Rows(4).Item("順序")
                ItemCode04.Text = DataSetDGV.Tables("ItemCodeALL").Rows(4).Item("存編")
                ItemName04.Text = DataSetDGV.Tables("ItemCodeALL").Rows(4).Item("品名")
            Else
                LineNum004.Text = "" : ItemCode04.Text = "" : ItemName04.Text = ""  '05
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 5 Then
                LineNum005.Text = DataSetDGV.Tables("ItemCodeALL").Rows(5).Item("順序")
                ItemCode05.Text = DataSetDGV.Tables("ItemCodeALL").Rows(5).Item("存編")
                ItemName05.Text = DataSetDGV.Tables("ItemCodeALL").Rows(5).Item("品名")
            Else
                LineNum005.Text = "" : ItemCode05.Text = "" : ItemName05.Text = ""  '06
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 6 Then
                LineNum006.Text = DataSetDGV.Tables("ItemCodeALL").Rows(6).Item("順序")
                ItemCode06.Text = DataSetDGV.Tables("ItemCodeALL").Rows(6).Item("存編")
                ItemName06.Text = DataSetDGV.Tables("ItemCodeALL").Rows(6).Item("品名")
            Else
                LineNum006.Text = "" : ItemCode06.Text = "" : ItemName06.Text = ""  '07
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 7 Then
                LineNum007.Text = DataSetDGV.Tables("ItemCodeALL").Rows(7).Item("順序")
                ItemCode07.Text = DataSetDGV.Tables("ItemCodeALL").Rows(7).Item("存編")
                ItemName07.Text = DataSetDGV.Tables("ItemCodeALL").Rows(7).Item("品名")
            Else
                LineNum007.Text = "" : ItemCode07.Text = "" : ItemName07.Text = ""  '08
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 8 Then
                LineNum008.Text = DataSetDGV.Tables("ItemCodeALL").Rows(8).Item("順序")
                ItemCode08.Text = DataSetDGV.Tables("ItemCodeALL").Rows(8).Item("存編")
                ItemName08.Text = DataSetDGV.Tables("ItemCodeALL").Rows(8).Item("品名")
            Else
                LineNum008.Text = "" : ItemCode08.Text = "" : ItemName08.Text = ""  '09
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 9 Then
                LineNum009.Text = DataSetDGV.Tables("ItemCodeALL").Rows(9).Item("順序")
                ItemCode09.Text = DataSetDGV.Tables("ItemCodeALL").Rows(9).Item("存編")
                ItemName09.Text = DataSetDGV.Tables("ItemCodeALL").Rows(9).Item("品名")
            Else
                LineNum009.Text = "" : ItemCode09.Text = "" : ItemName09.Text = ""  '10
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 10 Then
                LineNum010.Text = DataSetDGV.Tables("ItemCodeALL").Rows(10).Item("順序")
                ItemCode10.Text = DataSetDGV.Tables("ItemCodeALL").Rows(10).Item("存編")
                ItemName10.Text = DataSetDGV.Tables("ItemCodeALL").Rows(10).Item("品名")
            Else
                LineNum010.Text = "" : ItemCode10.Text = "" : ItemName10.Text = ""  '11
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 11 Then
                LineNum011.Text = DataSetDGV.Tables("ItemCodeALL").Rows(11).Item("順序")
                ItemCode11.Text = DataSetDGV.Tables("ItemCodeALL").Rows(11).Item("存編")
                ItemName11.Text = DataSetDGV.Tables("ItemCodeALL").Rows(11).Item("品名")
            Else
                LineNum011.Text = "" : ItemCode11.Text = "" : ItemName11.Text = ""  '12
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 12 Then
                LineNum012.Text = DataSetDGV.Tables("ItemCodeALL").Rows(12).Item("順序")
                ItemCode12.Text = DataSetDGV.Tables("ItemCodeALL").Rows(12).Item("存編")
                ItemName12.Text = DataSetDGV.Tables("ItemCodeALL").Rows(12).Item("品名")
            Else
                LineNum012.Text = "" : ItemCode12.Text = "" : ItemName12.Text = ""  '13
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 13 Then
                LineNum013.Text = DataSetDGV.Tables("ItemCodeALL").Rows(13).Item("順序")
                ItemCode13.Text = DataSetDGV.Tables("ItemCodeALL").Rows(13).Item("存編")
                ItemName13.Text = DataSetDGV.Tables("ItemCodeALL").Rows(13).Item("品名")
            Else
                LineNum013.Text = "" : ItemCode13.Text = "" : ItemName13.Text = ""  '14
            End If

            If DataSetDGV.Tables("ItemCodeALL").Rows.Count > 14 Then
                LineNum014.Text = DataSetDGV.Tables("ItemCodeALL").Rows(14).Item("順序")
                ItemCode14.Text = DataSetDGV.Tables("ItemCodeALL").Rows(14).Item("存編")
                ItemName14.Text = DataSetDGV.Tables("ItemCodeALL").Rows(14).Item("品名")
            Else
                LineNum014.Text = "" : ItemCode14.Text = "" : ItemName14.Text = ""  '15
            End If

        End If

        If DataSetDGV.Tables("ItemCodeALL").Rows.Count = 0 Then

            LineNum000.Text = "" : ItemCode00.Text = "" : ItemName00.Text = ""  '01
            LineNum001.Text = "" : ItemCode01.Text = "" : ItemName01.Text = ""  '02
            LineNum002.Text = "" : ItemCode02.Text = "" : ItemName02.Text = ""  '03
            LineNum003.Text = "" : ItemCode03.Text = "" : ItemName03.Text = ""  '04
            LineNum004.Text = "" : ItemCode04.Text = "" : ItemName04.Text = ""  '05
            LineNum005.Text = "" : ItemCode05.Text = "" : ItemName05.Text = ""  '06
            LineNum006.Text = "" : ItemCode06.Text = "" : ItemName06.Text = ""  '07
            LineNum007.Text = "" : ItemCode07.Text = "" : ItemName07.Text = ""  '08
            LineNum008.Text = "" : ItemCode08.Text = "" : ItemName08.Text = ""  '09
            LineNum009.Text = "" : ItemCode09.Text = "" : ItemName09.Text = ""  '10
            LineNum010.Text = "" : ItemCode10.Text = "" : ItemName10.Text = ""  '11
            LineNum011.Text = "" : ItemCode11.Text = "" : ItemName11.Text = ""  '12
            LineNum012.Text = "" : ItemCode12.Text = "" : ItemName12.Text = ""  '13
            LineNum013.Text = "" : ItemCode13.Text = "" : ItemName13.Text = ""  '14
            LineNum014.Text = "" : ItemCode14.Text = "" : ItemName14.Text = ""  '15


            MsgBox("查無存編資料。", 48, "警告")
        End If

    End Sub




    '------>查詢 T2資料<------
    Private Sub 查詢客編T2DGV2()
        If T2DGV2.RowCount > 0 Then
            DataSetDGV.Tables("T2DGV2").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim CardCode As String = Format(Replace(客編ALLTxT.Text, ",", "','"), "")

        SQLCmd.CommandText = "      SELECT DISTINCT [CardCode] AS '客編', [AddId] AS '名稱' "
        SQLCmd.CommandText += "       FROM [OCRD] "
        '製程--存貨0/代工1
        If Process = 0 Then
            SQLCmd.CommandText += "  WHERE [CardType] = 'C' AND [QryGroup7] = 'Y' AND"
        End If
        If Process = 1 Then
            SQLCmd.CommandText += "  WHERE [CardType] = 'C' AND [QryGroup8] = 'Y' AND"
        End If
        SQLCmd.CommandText += "            [CardCode] IN ('" & CardCode & "')"

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "T2DGV2")
        T2DGV2.DataSource = DataSetDGV.Tables("T2DGV2")

        T2DGV2.AutoResizeColumns()

        If T2DGV2.RowCount = 0 And 新增客戶TF = True Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub 查詢客編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢客編.Click

        'If 客編ALLTxT.Text = "" Then
        '    MsgBox("無資料可查詢", 48, "警告")
        '    Exit Sub
        'End If

        查詢客編T2DGV1()

    End Sub

    Private Sub 查詢客編T2DGV1()
        If T2DGV1.RowCount > 0 Then
            DataSetDGV.Tables("T2DGV1").Clear()
        End If

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        Dim CardCode As String = Format(Replace(客編ALLTxT.Text, ",", "','"), "")

        'SQLCmd.CommandText = "      SELECT DISTINCT 'False' AS '新增', [CardCode] AS '客編', [AddId] AS '名稱' "
        SQLCmd.CommandText = "      SELECT DISTINCT [CardCode] AS '客編', [AddId] AS '名稱' "
        SQLCmd.CommandText += "       FROM [OCRD] "

        '製程--存貨0/代工1
        If Process = 0 Then
            SQLCmd.CommandText += "  WHERE [CardType] = 'C' AND [QryGroup7] = 'Y' "
        End If
        If Process = 1 Then
            SQLCmd.CommandText += "  WHERE [CardType] = 'C' AND [QryGroup8] = 'Y' "
        End If

        If 客編ALLTxT.Text <> "" Then
            SQLCmd.CommandText += "                         AND [CardCode] NOT IN ('" & CardCode & "') "
        End If

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
        DataAdapterDGV.Fill(DataSetDGV, "T2DGV1")
        T2DGV1.DataSource = DataSetDGV.Tables("T2DGV1")

        'For Each column As DataGridViewColumn In T2DGV1.Columns
        '    column.Visible = True
        '    Select Case column.Name
        '        Case "新增" : column.HeaderText = "新增" : column.DisplayIndex = 0 : column.ReadOnly = True
        '        Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 1 : column.ReadOnly = False
        '        Case "名稱" : column.HeaderText = "名稱" : column.DisplayIndex = 2 : column.ReadOnly = False
        '        Case Else
        '            column.Visible = False
        '    End Select
        'Next
        'T2DGV1.AutoResizeColumns()
        'T2DGV1.AllowUserToAddRows = False



        T2DGV1.AutoResizeColumns()
        'Search查詢客編T2DGV1()

        If T2DGV1.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub Search查詢客編T2DGV1()
        'DataGridViewCheckBoxColumn
        For Each column As DataGridViewColumn In T2DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "新增" : column.HeaderText = "新增" : column.DisplayIndex = 0 ' : column.ReadOnly = True
                Case "客編" : column.HeaderText = "客編" : column.DisplayIndex = 1 ' : column.ReadOnly = False
                Case "名稱" : column.HeaderText = "名稱" : column.DisplayIndex = 2 ' : column.ReadOnly = False
                Case Else
                    column.Visible = False
            End Select
        Next
        T2DGV1.AutoResizeColumns()
        T2DGV1.AllowUserToAddRows = False
    End Sub


    '------><------
    Private Sub 新增客戶_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增客戶.Click

        If T2DGV2.RowCount = 0 Then
            新增客戶TF = False
            查詢客編T2DGV2()
        End If

        For Each oRow As DataGridViewRow In T2DGV1.SelectedRows
            Dim Row As DataRow
            Row = DataSetDGV.Tables("T2DGV2").NewRow
            Row.Item("客編") = oRow.Cells("客編D1").Value
            Row.Item("名稱") = oRow.Cells("名稱D1").Value

            DataSetDGV.Tables("T2DGV2").Rows.Add(Row)
            T2DGV2.AutoResizeColumns()
        Next

        新增客戶TF = True

        'For Each oRow As DataGridViewRow In T2DGV1.SelectedRows
        '    'Dim Row As DataRow
        '    'Row = DataSetDGV.Tables("T2DGV2").NewRow
        '    'oRow.Cells("客編D1").Value
        '    'oRow.Cells("名稱D1").Value

        '    DataSetDGV.Tables("T2DGV1").Rows.Add(oRow)
        '    T2DGV1.AutoResizeColumns()
        'Next

    End Sub

    Private Sub 移除客戶_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 移除客戶.Click

        ''宣告
        ''Public ReadOnly Property CurrentRow() As DataGridViewRow
        ''用途
        ''Dim instance As DataGridView
        ''Dim value As DataGridViewRow
        ''value = T2DGV2.CurrentRow.Cells
        ''T2DGV2.Rows.Remove(value)           '移除列 Row


        ''For i = 0 To DataSetDGV.Tables("T2DGV2").Rows.Count() - 1
        'For i As Integer = 0 To T2DGV1.SelectedCells.Contains(x)
        '    'if ... then
        '    'DataSetDGV.Tables("T2DGV2").Rows.Remove(DataSetDGV.Tables("T2DGV1").Rows(i))
        '    T2DGV1.Rows.Remove(T2DGV1.SelectedRows(i))
        '    'End If
        'Next

        ''For Each oRow As DataGridViewRow In T2DGV1.SelectedRows
        ''Dim Row As DataRow
        ''Row = DataSetDGV.Tables("T2DGV2").NewRow
        ''T2DGV1.Rows.Remove(T2DGV1.SelectedCells(i))
        ''DGV1.CurrentRow.Cells("客編D1").Value
        ''T2DGV1.Rows.Remove(oRow.Cells("客編D1").Value)

        ''Row.Item("名稱") = oRow.Cells("名稱D1").Value

        ''DataSetDGV.Tables("T2DGV2").Rows.Add(Row)
        'T2DGV1.AutoResizeColumns()
        ''Next




        ''T2DGV2.Rows.Remove(T2DGV2.CurrentRow)           '移除列 Row
        ''Label4.Text = Format(DGV1.RowCount, "")

        ''T2DGV2.CurrentRow.Cells("客編").Value










    End Sub

    Private Sub 存檔客編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔客編.Click
        If T2DGV2.RowCount = 0 Then
            MsgBox("無客戶資料。", 48, "警告")
            Exit Sub
        End If

        UP客戶資料()
    End Sub

    Private Sub UP客戶資料()
        '--清除客編
        客編ALLTxT.Text = ""

        For x As Integer = 0 To T2DGV2.RowCount - 1
            If 客編ALLTxT.Text = "" Then
                客編ALLTxT.Text = 客編ALLTxT.Text + Format(T2DGV2.Rows(x).Cells("客編D2").Value, "")
            Else
                客編ALLTxT.Text = 客編ALLTxT.Text + "," + Format(T2DGV2.Rows(x).Cells("客編D2").Value, "")
            End If
        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        '-->更新客編<--
        SQLCmd.CommandText += " UPDATE [Z_KS_ScaleOITMMain] SET [CardCode] = '" & 客編ALLTxT.Text & "' "
        SQLCmd.CommandText += "  WHERE [Process]  = '" & Process & "'  AND [Frozen]        = '" & Frozen & "'         AND [Chicken] = '" & Chicken & "' AND "
        SQLCmd.CommandText += "        [Category] = '" & Category & "' AND [Specification] = '" & 規格表TxT.Text & "' AND [Cancel]  = 'Y' "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        MsgBox("客編更新完成")

    End Sub



    Private Sub 存檔存編_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔存編.Click
        If (LineNum000.Text = "" Or ItemCode00.Text = "") And _
           (LineNum001.Text = "" Or ItemCode01.Text = "") And _
           (LineNum002.Text = "" Or ItemCode02.Text = "") And _
           (LineNum003.Text = "" Or ItemCode03.Text = "") And _
           (LineNum004.Text = "" Or ItemCode04.Text = "") And _
           (LineNum005.Text = "" Or ItemCode05.Text = "") And _
           (LineNum006.Text = "" Or ItemCode06.Text = "") And _
           (LineNum007.Text = "" Or ItemCode07.Text = "") And _
           (LineNum008.Text = "" Or ItemCode08.Text = "") And _
           (LineNum009.Text = "" Or ItemCode09.Text = "") And _
           (LineNum010.Text = "" Or ItemCode10.Text = "") And _
           (LineNum011.Text = "" Or ItemCode11.Text = "") And _
           (LineNum012.Text = "" Or ItemCode12.Text = "") And _
           (LineNum013.Text = "" Or ItemCode13.Text = "") And _
           (LineNum014.Text = "" Or ItemCode14.Text = "") Then
            MsgBox("無存編資料。", 48, "警告")
            Exit Sub
        End If

        UP存編資料()
        查詢規格表存編()

    End Sub

    Private Sub UP存編資料()


        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        If LineNum000.Text <> "" And ItemCode00.Text <> "" Then
            '-->刪除存編明細<--
            SQLCmd.CommandText = "  DELETE FROM [Z_KS_ScaleOITMList] WHERE [MainSid] = '" & SidTxT.Text & "' AND [OrderNum] = '" & OrderNum & "' "
            '-->更新存編<--
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum000.Text & "','" & ItemCode00.Text & "') "
        End If

        If LineNum001.Text <> "" And ItemCode01.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum001.Text & "','" & ItemCode01.Text & "') "
        End If

        If LineNum002.Text <> "" And ItemCode02.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum002.Text & "','" & ItemCode02.Text & "') "
        End If

        If LineNum003.Text <> "" And ItemCode03.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum003.Text & "','" & ItemCode03.Text & "') "
        End If

        If LineNum004.Text <> "" And ItemCode04.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum004.Text & "','" & ItemCode04.Text & "') "
        End If

        If LineNum005.Text <> "" And ItemCode05.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum005.Text & "','" & ItemCode05.Text & "') "
        End If

        If LineNum006.Text <> "" And ItemCode06.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum006.Text & "','" & ItemCode06.Text & "') "
        End If

        If LineNum007.Text <> "" And ItemCode07.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum007.Text & "','" & ItemCode07.Text & "') "
        End If

        If LineNum008.Text <> "" And ItemCode08.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum008.Text & "','" & ItemCode08.Text & "') "
        End If

        If LineNum009.Text <> "" And ItemCode00.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum009.Text & "','" & ItemCode09.Text & "') "
        End If

        If LineNum010.Text <> "" And ItemCode10.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum010.Text & "','" & ItemCode10.Text & "') "
        End If

        If LineNum011.Text <> "" And ItemCode11.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum011.Text & "','" & ItemCode11.Text & "') "
        End If

        If LineNum012.Text <> "" And ItemCode12.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum012.Text & "','" & ItemCode12.Text & "') "
        End If

        If LineNum013.Text <> "" And ItemCode13.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum013.Text & "','" & ItemCode13.Text & "') "
        End If

        If LineNum014.Text <> "" And ItemCode14.Text <> "" Then
            SQLCmd.CommandText += " INSERT INTO [Z_KS_ScaleOITMList] ([MainSid],[OrderNum],[LineNum],[ItemCode]) VALUES ('" & SidTxT.Text & "','" & OrderNum & "','" & LineNum014.Text & "','" & ItemCode14.Text & "') "
        End If

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()


        If UP存編資料TF = True Then
            MsgBox("存編更新完成")
        End If

        'For i As Integer = 0 To ExcelDGV.RowCount - 1
        '    If ExcelDGV.Rows(i).Cells("F1").FormattedValue <> "" Then
        '        F1 = Format(Replace(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 4), " ", ""), "")
        '        F2 = Format(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 6, 13), "")
        '        F3 = Format(Microsoft.VisualBasic.Mid(ExcelDGV.Rows(i).Cells("F1").FormattedValue, 1, 1), "")
        '        SQLCmd.Parameters.Clear()
        '        SQLCmd.Parameters.AddWithValue("@str_1", F1)
        '        SQLCmd.Parameters.AddWithValue("@str_2", F2)
        '        SQLCmd.Parameters.AddWithValue("@str_3", F3)
        '        SQLCmd.ExecuteNonQuery()
        '    End If
        'Next

        'MsgBox("上傳完成  上傳 " + Format(ExcelDGV.RowCount, "") + " 筆")


    End Sub

    Private Sub 新增規格表_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增規格表.Click

        If T2DGV2.RowCount = 0 Then
            MsgBox("無客戶資料。", 48, "警告")
            Exit Sub
        End If

        If (LineNum000.Text = "" Or ItemCode00.Text = "") And _
           (LineNum001.Text = "" Or ItemCode01.Text = "") And _
           (LineNum002.Text = "" Or ItemCode02.Text = "") And _
           (LineNum003.Text = "" Or ItemCode03.Text = "") And _
           (LineNum004.Text = "" Or ItemCode04.Text = "") And _
           (LineNum005.Text = "" Or ItemCode05.Text = "") And _
           (LineNum006.Text = "" Or ItemCode06.Text = "") And _
           (LineNum007.Text = "" Or ItemCode07.Text = "") And _
           (LineNum008.Text = "" Or ItemCode08.Text = "") And _
           (LineNum009.Text = "" Or ItemCode09.Text = "") And _
           (LineNum010.Text = "" Or ItemCode10.Text = "") And _
           (LineNum011.Text = "" Or ItemCode11.Text = "") And _
           (LineNum012.Text = "" Or ItemCode12.Text = "") And _
           (LineNum013.Text = "" Or ItemCode13.Text = "") And _
           (LineNum014.Text = "" Or ItemCode14.Text = "") Then
            MsgBox("無存編資料。", 48, "警告")
            Exit Sub
        End If

        Dim 規格表TxTs As String
        規格表TxTs = 規格表TxT.Text
        規格表_Check(規格表TxTs)
        If AnsHasRow = True Then
            MsgBox("規格表名稱重複，請更改!", 16, "錯誤")
            Exit Sub
        End If

        新增規格表.Enabled = False
        If 新增規格表.Enabled = False Then
            Dim oAns As Integer
            oAns = MsgBox("是否要新增  規格表名稱：" + Format(規格表TxT.Text, ""), MsgBoxStyle.YesNo, "確認新增")
            If oAns = MsgBoxResult.Yes Then
                'Yes執行區
                Add規格表()
            End If
        End If
        新增規格表.Enabled = True

    End Sub

    Private Function 取得Sid()

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "    SELECT TOP 1 ISNULL([Sid],0) AS 'Sid' FROM [Z_KS_ScaleOITMMain] "
        SQLCmd.CommandText += " ORDER BY [Sid] DESC "

        SQLCmd.ExecuteNonQuery()
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("Sid") + 1
        Else
            oReturn = 1
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub Sid_Update()
        '更新Sid
        Dim i As Integer
        i = 取得Sid()
        If i = 0 Then
            MsgBox("載入Sid資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        SidTxT.Text = i

    End Sub

    Private Function 規格表_Check(ByVal 規格表TxTs As String)


        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = "  SELECT * FROM [Z_KS_ScaleOITMMain] "
        SQLCmd.CommandText += "  WHERE [Process]  = '" & Process & "'  AND [Frozen]        = '" & Frozen & "'         AND [Chicken] = '" & Chicken & "' AND "
        SQLCmd.CommandText += "        [Category] = '" & Category & "' AND [Specification] = '" & 規格表TxTs & "' AND [Cancel]  = 'Y' "

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            AnsHasRow = True
        Else
            AnsHasRow = False
        End If

        sqlReader.Close()

        Return AnsHasRow

    End Function




    Private Sub Add規格表()

        '取得最新Sid
        Sid_Update()

        '--清除客編
        客編ALLTxT.Text = ""

        For x As Integer = 0 To T2DGV2.RowCount - 1
            If 客編ALLTxT.Text = "" Then
                客編ALLTxT.Text = 客編ALLTxT.Text + Format(T2DGV2.Rows(x).Cells("客編D2").Value, "")
            Else
                客編ALLTxT.Text = 客編ALLTxT.Text + "," + Format(T2DGV2.Rows(x).Cells("客編D2").Value, "")
            End If
        Next

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        SQLCmd.Connection = DBConn

        SQLCmd.CommandText = " INSERT INTO [Z_KS_ScaleOITMMain] ([CardCode],[Process],[Frozen],[Chicken],[Category],[Specification],[Cancel]) VALUES "
        SQLCmd.CommandText = " ('" & 客編ALLTxT.Text & "','" & Process & "','" & Frozen & "','" & Chicken & "','" & Category & "','" & 規格表TxT.Text & "','Y')"

        SQLCmd.Parameters.Clear()
        SQLCmd.ExecuteNonQuery()

        UP存編資料TF = False
        UP存編資料()
        UP存編資料TF = True

        MsgBox("新增規格表完成")

    End Sub











End Class