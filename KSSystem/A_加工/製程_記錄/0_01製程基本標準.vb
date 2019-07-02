Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

'Size 902,600   Mis Size 935,600

Public Class _0_01製程基本標準
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim 新增或修改 As String = ""

    Private Sub _0_01製程基本標準_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        初始化()

    End Sub

    Private Sub 初始化()
        存編T1.Text = "" : 品名T1.Text = "" : 設定T1.Text = "" : 版本T1.Text = ""
        存編T2.Text = "" : 品名T2.Text = "" : 版本T2.Text = ""

    End Sub

    Private Sub TP2初始化() '載入T1資料至T2
        存編T2.Text = "" : 品名T2.Text = "" : 版本T2.Text = ""
        存編T2.Text = 存編T1.Text
        品名T2.Text = 品名T1.Text
        版本T2.Text = 版本T1.Text

    End Sub

    'TP1執行區
    Private Sub 查看0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查看0.Click
        If 設定T1.Text = "" Then
            MsgBox("錯誤，未新增製程資料無法查看")
            Exit Sub
        End If
        新增或修改 = ""
        TP2初始化()
        If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If '清除DGV2資料
        查詢1已設定之存編()
        'DGV2.AutoResizeColumns()
        DGV2.AllowUserToAddRows = False    'DataGridView 設定單元格不可新增
        DGV2.AllowUserToDeleteRows = False 'DataGridView 設定單元格不可刪除
        DGV2.ReadOnly = True               'DataGridView 設定單元格不可編輯
        存檔1.Visible = False
        Me.TabControl1.SelectedTab = Me.TabPage2

    End Sub

    Private Sub 新增0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 新增0.Click
        'If 設定T1.Text = "啟用" Or 設定T1.Text = "送簽" Or 設定T1.Text = "退簽" Then : MsgBox("錯誤，製程資料已新增") : Exit Sub : End If
        Select Case 設定T1.Text
            Case "啟用", "送簽", "退簽"
                MsgBox("錯誤，製程資料已新增")
                Exit Sub
            Case Else
        End Select

        新增或修改 = "新增"
        If 版本T1.Text = 0 Then
            版本T1.Text = 版本T1.Text + 1
        End If
        TP2初始化()
        If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If '清除DGV2資料
        查詢1已設定之存編()
        DGV2.AllowUserToAddRows = True      'DataGridView 設定單元格不可新增
        DGV2.AllowUserToDeleteRows = True   'DataGridView 設定單元格不可刪除
        DGV2.ReadOnly = False               'DataGridView 設定單元格不可編輯
        存檔1.Visible = True
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

        Dim strWHERE1 As String = "" : Dim strWHERE2 As String = "" : Dim strWHERE3 As String = "" : Dim strWHERE4 As String = "" : Dim strWHERE5 As String = ""
        Dim str品T2W1 As String = "ALL" : Dim str品T2W2 As String = "ALL" : Dim str品T2W3 As String = "ALL"
        If 品名WT11.Text <> "" Then : str品T2W1 = 品名WT11.Text : End If
        If 品名WT12.Text <> "" Then : str品T2W2 = 品名WT12.Text : End If
        If 品名WT13.Text <> "" Then : str品T2W3 = 品名WT13.Text : End If

        If W保存方式.SelectedIndex > 0 Then
            strWHERE1 += "      AND SUBSTRING(T0.[ItemCode],3,1) = '" & Microsoft.VisualBasic.Left(W保存方式.Text, 1) & "' "
        End If

        If W產品類別.SelectedIndex > 0 Then
            strWHERE2 += "      AND SUBSTRING(T0.[ItemCode],5,1) = '" & Microsoft.VisualBasic.Left(W產品類別.Text, 1) & "' "
        End If

        If 包含查詢.Checked Then
            strWHERE3 += " AND (T0.[ItemName] Like '%" & str品T2W1 & "%'  "
            strWHERE4 += " OR   T0.[ItemName] Like '%" & str品T2W2 & "%'  "
            strWHERE5 += " OR   T0.[ItemName] Like '%" & str品T2W3 & "%') "
        Else
            If 品名WT11.Text <> "" Then : strWHERE3 += " AND T0.[ItemName] Like '%" & 品名WT11.Text & "%' " : End If
            If 品名WT12.Text <> "" Then : strWHERE4 += " AND T0.[ItemName] Like '%" & 品名WT12.Text & "%' " : End If
            If 品名WT13.Text <> "" Then : strWHERE5 += " AND T0.[ItemName] Like '%" & 品名WT13.Text & "%' " : End If
        End If

        'If 品名WT11.Text <> "" Then
        '    strWHERE3 += "      AND T0.[ItemName] Like '%" & 品名WT11.Text & "%' "
        'End If

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT CASE WHEN ISNULL(T1.[Enable],'') = ''   THEN ''     ELSE "
            SQLCmd.CommandText += "          CASE WHEN        T1.[Enable]     = 'Y'  THEN '啟用' ELSE "
            SQLCmd.CommandText += "          CASE WHEN        T1.[Enable]     = 'S'  THEN '送簽' ELSE "
            SQLCmd.CommandText += "          CASE WHEN        T1.[Enable]     = 'SN' THEN '退簽' ELSE "
            SQLCmd.CommandText += "          '停用' END END END END AS '設定', "
            SQLCmd.CommandText += "          T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', ISNULL(T1.[Version],'') AS '版本' "
            SQLCmd.CommandText += "     FROM [OITM] T0 LEFT  JOIN [KaiShingPlug].[dbo].[KS_PBDStd_0] T1 ON T0.[ItemCode] = T1.[ItemCode] "
            SQLCmd.CommandText += "    WHERE SUBSTRING(T0.[ItemCode],1,4) IN ('2503','2513','2523','3203','3213','3223') AND SUBSTRING(T0.[ItemCode],16,2) <> '-1' "
            SQLCmd.CommandText += strWHERE1
            SQLCmd.CommandText += strWHERE2
            SQLCmd.CommandText += strWHERE3
            SQLCmd.CommandText += strWHERE4
            SQLCmd.CommandText += strWHERE5

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
    Private Sub 存檔1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 存檔1.Click
        存檔1Save製程()
        存檔1Save製程2()

        新增或修改 = ""
        查詢0已設定之存編()
        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub 離開1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 離開1.Click
        新增或修改 = ""
        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub 查詢1已設定之存編()
        If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If '清除DGV2資料

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn

            SQLCmd.CommandText = "    SELECT T1.[StationID] AS '工站編號', T1.[Location] AS '作業地點', T1.[ProductionItem] AS '作業內容', T1.[ProductionUnit] AS '生產單位', "
            SQLCmd.CommandText += "          T1.[Person] AS '作業人數', T1.[Quantity] AS '生產數量', T1.[Note] AS '注意事項' "
            SQLCmd.CommandText += "     FROM [KaiShingPlug].[dbo].[KS_PBDStd_0] T0 INNER JOIN [KaiShingPlug].[dbo].[KS_PBDStd_1] T1 ON T0.[ItemCode] = T1.[ItemCode] "
            SQLCmd.CommandText += "    WHERE T1.[ItemCode] = '" & 存編T1.Text & "' AND T1.[Version] = '" & 版本T1.Text & "' "

            SQLCmd.CommandTimeout = 100000

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV2.DataSource = ks1DataSetDGV.Tables("DGV2")
            DGV2.AutoResizeColumns()

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

            SQLCmd1.CommandText = "   INSERT INTO [KaiShingPlug].[dbo].[KS_PBDStd_0] "
            SQLCmd1.CommandText += "  ([ItemCode],[ItemName],[Version],[Note],[Enable],[Modify],[AddDateTime],[ModifyDateTime]) VALUES "
            SQLCmd1.CommandText += "  ('" & 存編T2.Text & "' , " 'ItemCode
            SQLCmd1.CommandText += "   '" & 品名T2.Text & "' , " 'ItemName
            SQLCmd1.CommandText += "   '" & 版本T2.Text & "' , " 'Version
            SQLCmd1.CommandText += "   '" & 備註T2.Text & "' , " 'Note
            SQLCmd1.CommandText += "   'S', 'N' ,              " '啟用, 修改
            SQLCmd1.CommandText += "   GetDate()             , " 'AddDateTime
            SQLCmd1.CommandText += "   GetDate()             ) " 'ModifyDateTime

            SQLCmd1.Parameters.Clear()
            SQLCmd1.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub 存檔1Save製程2()
        Dim DBConn2 As SqlConnection = Login.DBConn
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        Try
            SQLCmd2.Connection = DBConn2
            For i As Integer = 0 To DGV2.RowCount - 1
                If DGV2.Rows(i).Cells("工站編號").Value <> "" Then

                    SQLCmd2.CommandText = "   INSERT INTO [KaiShingPlug].[dbo].[KS_PBDStd_1] "
                    SQLCmd2.CommandText += "  ([ItemCode],[Version],[StationID],[Location],[ProductionItem],[ProductionUnit],[Person],[Quantity],[Note]) VALUES "
                    SQLCmd2.CommandText += "  ('" & 存編T2.Text & "'                             , " 'ItemCode
                    SQLCmd2.CommandText += "   '" & 版本T2.Text & "'                             , " 'Version
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("工站編號").Value & "'    , " 'StationID
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("作業地點").Value & "'    , " 'Location
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("作業內容").Value & "'    , " 'ProductionItem
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("生產單位").Value & "'    , " 'ProductionUnit
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("作業人數").Value & "'    , " 'Person
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("生產數量").Value & "'    , " 'Quantity
                    SQLCmd2.CommandText += "   '" & DGV2.Rows(i).Cells("注意事項").Value & "'    ) " 'Note

                    SQLCmd2.Parameters.Clear()
                    SQLCmd2.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'DGV執行區
    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = -1 Then : Exit Sub : End If      '無資料不執行下方
        存編T1.Text = DGV1.CurrentRow.Cells("存編").Value
        品名T1.Text = DGV1.CurrentRow.Cells("品名").Value
        設定T1.Text = DGV1.CurrentRow.Cells("設定").Value
        版本T1.Text = DGV1.CurrentRow.Cells("版本").Value

    End Sub

End Class