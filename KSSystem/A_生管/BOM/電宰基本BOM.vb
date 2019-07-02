Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq


'Size 902,600   Mis Size 935,600

Public Class 電宰基本BOM
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim 新增或修改 As String = ""

    Private Sub 電宰基本BOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        初始化()

    End Sub

    Private Sub 初始化()
        存編T1.Text = "" : 品名T1.Text = "" : 設定T1.Text = "" ': 版本T1.Text = ""
        存編T2.Text = "" : 品名T2.Text = "" ': 版本T2.Text = ""

    End Sub

    Private Sub TP2初始化() '載入T1資料至T2
        存編T2.Text = "" : 品名T2.Text = "" ': 版本T2.Text = ""
        存編T2.Text = Microsoft.VisualBasic.Left(存編T1.Text, 13)
        品名T2.Text = 品名T1.Text
        '版本T2.Text = 版本T1.Text

    End Sub

    'DGV執行區
    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = -1 Then : Exit Sub : End If      '無資料不執行下方
        存編T1.Text = DGV1.CurrentRow.Cells("存編").Value
        品名T1.Text = DGV1.CurrentRow.Cells("品名").Value
        設定T1.Text = DGV1.CurrentRow.Cells("設定").Value

    End Sub

    'DGV執行區
    Private Sub DGV21_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV21.CellClick
        If DGV21.RowCount = -1 Then : Exit Sub : End If      '無資料不執行下方
        存編T2D21.Text = DGV21.CurrentRow.Cells("存編").Value
        品名T2D21.Text = DGV21.CurrentRow.Cells("品名").Value

    End Sub


    'TP1執行區
    Private Sub 查看0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查看0.Click
        'If 設定T1.Text = "" Then
        '    MsgBox("錯誤，未新增製程資料無法查看")
        '    Exit Sub
        'End If
        '新增或修改 = ""
        'TP2初始化()
        'If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If '清除DGV2資料
        '查詢1已設定之存編()
        ''DGV2.AutoResizeColumns()
        'DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        'DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        'DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯
        '存檔1.Visible = False
        'Me.TabControl1.SelectedTab = Me.TabPage2

    End Sub

    Private Sub 新增0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增0.Click
        'If 設定T1.Text = "啟用" Or 設定T1.Text = "送簽" Or 設定T1.Text = "退簽" Then : MsgBox("錯誤，製程資料已新增") : Exit Sub : End If
        'Select Case 設定T1.Text
        '    Case "V"
        '        MsgBox("錯誤，資料已新增")
        '        Exit Sub
        '    Case Else
        'End Select

        If 存編T1.Text = "" Then
            MsgBox("錯誤，無選擇資料")
            Exit Sub
        End If

        新增或修改 = "新增"
        'If 版本T1.Text = 0 Then
        '    版本T1.Text = 版本T1.Text + 1
        'End If
        TP2初始化()
        If DGV22.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If '清除DGV2資料
        查詢1已設定之存編()
        'DGV2.AllowUserToAddRows = True      'DataGridView 設定單元格不可新增
        'DGV2.AllowUserToDeleteRows = True   'DataGridView 設定單元格不可刪除
        'DGV2.ReadOnly = False               'DataGridView 設定單元格不可編輯
        存檔T2.Visible = True
        Me.TabControl1.SelectedTab = Me.TabPage2

    End Sub

    Private Sub 修改0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 修改0.Click
        'If 設定T1.Text = "" Then
        '    MsgBox("錯誤，未新增製程資料無法修改")
        '    Exit Sub
        'End If
        '新增或修改 = "修改"
        'TP2初始化()
        'If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If '清除DGV2資料
        'Me.TabControl1.SelectedTab = Me.TabPage2

    End Sub

    Private Sub 查詢0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢0.Click
        查詢0已設定之存編()

    End Sub

    Private Sub 查詢0已設定之存編()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV1").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = ""

        If W保存方式.SelectedIndex > 0 Then
            strWHERE1 += "      AND SUBSTRING(T0.[ItemCode],3,1) = '" & Microsoft.VisualBasic.Left(W保存方式.Text, 1) & "' "
        End If

        'If W產品類別.SelectedIndex > 0 Then
        '    strWHERE2 += "      AND SUBSTRING(T0.[ItemCode],5,1) = '" & Microsoft.VisualBasic.Left(W產品類別.Text, 1) & "' "
        'End If

        If W品名.Text <> "" Then
            strWHERE3 += "      AND T0.[ItemName] Like '%" & W品名.Text & "%' "
        End If

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT CASE WHEN ISNULL(T1.[ItemCode],'') = ''   THEN '' ELSE 'V' END AS '設定', T0.[ItemName] AS '品名', T0.[ItemCode] AS '存編' "
            SQLCmd.CommandText += "     FROM [OITM] T0 LEFT  JOIN [KaiShingPlug].[dbo].[KS_ITT0] T1 ON SUBSTRING(T0.[ItemCode],1,13) = SUBSTRING(T1.[ItemCode],1,13)"
            SQLCmd.CommandText += "    WHERE SUBSTRING(T0.[ItemCode],1,2) IN ('25','31') AND SUBSTRING(T0.[ItemCode],4,1) IN ('1','2')  AND T0.[ManSerNum] = 'Y' "
            SQLCmd.CommandText += "      AND T0.[ItemCode] NOT Like '%-1%'  AND T0.[ItemCode] NOT Like '%-2%' "
            SQLCmd.CommandText += "      AND T0.[ItemName] NOT Like '%xxx%' AND T0.[ItemName] NOT Like '%xx%' "
            SQLCmd.CommandText += strWHERE1
            'SQLCmd.CommandText += strWHERE2
            SQLCmd.CommandText += strWHERE3
            SQLCmd.CommandText += " ORDER BY 3, 2 "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")
            DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'TP2執行區
    Private Sub 存檔T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔T2.Click

        If 類別T2D21.SelectedIndex = -1 Or 類別T2D21.SelectedIndex = 0 Or 順序T2D21.Text = "" Or 存編T2D21.Text = "" Or 數量T2D21.Text = "" Or 單位T2D21.Text = "" Then
            MsgBox("錯誤，資料")
            Exit Sub
        End If

        If 設定T1.Text = "" Then
            存檔1Save製程()
            設定T1.Text = "V"
        End If
        存檔1Save製程2()
        查詢1已設定之存編()
        '新增或修改 = ""
        '查詢0已設定之存編()
        'Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub 離開T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 離開T2.Click
        新增或修改 = ""
        類別T2D21.SelectedIndex = 0 : 順序T2D21.Text = "" : 存編T2D21.Text = "" : 品名T2D21.Text = "" : 數量T2D21.Text = "" : 單位T2D21.Text = ""
        品WT21.Text = "" : 品WT22.Text = "" : 品WT23.Text = ""

        If DGV21.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV21").Clear() : End If '清除DGV21資料
        If DGV22.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV22").Clear() : End If '清除DGV22資料

        查詢0已設定之存編()

        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub 查詢T2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢T2.Click
        查詢T2DGV21存編()
        'Me.TabControl1.SelectedTab = Me.TabPage5
    End Sub

    Private Sub 查詢1已設定之存編()
        If DGV22.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV22").Clear() : End If '清除DGV2資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT T1.[Category]  AS '類別', T1.[Order] AS '順序', T1.[CItemCode]AS '存編', T2.[ItemName] AS '品名',"
            SQLCmd.CommandText += "          T1.[CQuantity] AS '數量', T1.[CInvntryUom] AS '單位'"
            SQLCmd.CommandText += "     FROM [KaiShingPlug].[dbo].[KS_ITT0] T0 INNER JOIN [KaiShingPlug].[dbo].[KS_ITT1] T1 ON T0.[ItemCode]  = T1.[ItemCode] "
            SQLCmd.CommandText += "                                            INNER JOIN [OITM]                         T2 ON T1.[CItemCode] = T2.[ItemCode]"
            SQLCmd.CommandText += "    WHERE T1.[ItemCode] = '" & 存編T2.Text & "' AND T1.[Cancel] = 'N' "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV22")
            DGV22.DataSource = ks1DataSetDGV.Tables("DGV22")
            DGV22.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 查詢T2DGV21存編()
        If DGV21.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV21").Clear() : End If '清除DGV1資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = ""
        Dim str品T2W1 As String = "ALL" : Dim str品T2W2 As String = "ALL" : Dim str品T2W3 As String = "ALL"
        If 品WT21.Text <> "" Then : str品T2W1 = 品WT21.Text : End If
        If 品WT22.Text <> "" Then : str品T2W2 = 品WT22.Text : End If
        If 品WT23.Text <> "" Then : str品T2W3 = 品WT23.Text : End If

        If 包含查詢.Checked Then

            strWHERE1 += " AND (T0.[ItemName] Like '%" & str品T2W1 & "%'  "
            strWHERE2 += " OR   T0.[ItemName] Like '%" & str品T2W2 & "%'  "
            strWHERE3 += " OR   T0.[ItemName] Like '%" & str品T2W3 & "%') "
        Else

            If 品WT21.Text <> "" Then : strWHERE1 += " AND T0.[ItemName] Like '%" & 品WT21.Text & "%' " : End If
            If 品WT22.Text <> "" Then : strWHERE2 += " AND T0.[ItemName] Like '%" & 品WT22.Text & "%' " : End If
            If 品WT23.Text <> "" Then : strWHERE3 += " AND T0.[ItemName] Like '%" & 品WT23.Text & "%' " : End If
        End If

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT T0.[ItemName] AS '品名', T0.[ItemCode] AS '存編' "
            SQLCmd.CommandText += "     FROM [OITM] T0 "
            SQLCmd.CommandText += "    WHERE SUBSTRING(T0.[ItemCode],1,2) IN ('22','52') AND SUBSTRING(T0.[ItemCode],16,2) <> '-1' "
            SQLCmd.CommandText += "          AND T0.[ItemName] NOT Like '%價差%' AND T0.[ItemName] NOT Like '%xxx%' AND T0.[ItemName] NOT Like '%xx%' AND T0.[ItemName] NOT Like '%折扣%' "
            SQLCmd.CommandText += strWHERE1 : SQLCmd.CommandText += strWHERE2 : SQLCmd.CommandText += strWHERE3
            SQLCmd.CommandText += " ORDER BY 1 "


            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV21")
            DGV21.DataSource = ks1DataSetDGV.Tables("DGV21")
            DGV21.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 存檔1Save製程()
        Dim DBConn1 As SqlConnection = Login.DBConn
        Dim SQLCmd1 As SqlCommand = New SqlCommand
        'Dim getDateTime As String = Format(Now(), "yyyy/MM/dd hh:mm:ss tt")

        Try
            SQLCmd1.Connection = DBConn1

            SQLCmd1.CommandText = "   INSERT INTO [KaiShingPlug].[dbo].[KS_ITT0] "
            SQLCmd1.CommandText += "  ([ItemCode]) VALUES "
            SQLCmd1.CommandText += "  ('" & 存編T2.Text & "' ) " 'ItemCode

            SQLCmd1.Parameters.Clear()
            SQLCmd1.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 存檔1Save製程2()
        Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        'Dim Row As DataRow
        'Row = ks1DataSetDGV.Tables("DGV21").NewRow
        'Row.Item("類別") = 類別T2D21.Text
        'Row.Item("順序") = 順序T2D21.Text
        'Row.Item("存編") = 存編T2D21.Text
        'Row.Item("品名") = 品名T2D21.Text
        'Row.Item("數量") = 數量T2D21.Text
        'Row.Item("單位") = 單位T2D21.Text

        'ks1DataSetDGV.Tables("DGV21").Rows.Add(Row)

        Try
            SQLCmd2.Connection = DBConn2

            SQLCmd2.CommandText = "   INSERT INTO [KaiShingPlug].[dbo].[KS_ITT1] "
            SQLCmd2.CommandText += "  ( [ItemCode],[ItemName],[Category],[Order],[CItemCode],[CQuantity],[CInvntryUom],[Cancel]) VALUES "
            SQLCmd2.CommandText += "  ('" & 存編T2.Text & "'    , " 'ItemCode
            SQLCmd2.CommandText += "   '" & 品名T2.Text & "'    , " 'ItemName
            SQLCmd2.CommandText += "   '" & 類別T2D21.Text & "' , " 'Category
            SQLCmd2.CommandText += "   '" & 順序T2D21.Text & "' , " 'Order
            SQLCmd2.CommandText += "   '" & 存編T2D21.Text & "' , " 'CItemCode
            SQLCmd2.CommandText += "   '" & 數量T2D21.Text & "' , " 'CQuantity
            SQLCmd2.CommandText += "   '" & 單位T2D21.Text & "' , " 'CInvntryUom
            SQLCmd2.CommandText += "   'N' )                      " 'Cancel

            SQLCmd2.Parameters.Clear()
            SQLCmd2.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


End Class