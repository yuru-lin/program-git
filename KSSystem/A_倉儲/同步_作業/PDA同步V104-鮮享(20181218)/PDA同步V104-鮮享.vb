Imports System
Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServerCe.Client
Imports System.Net.Dns

Public Class PDA同步V104    '20181122改寫
    Dim DataAdapterDGV As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet
    Dim 選擇作業 As String = "Y"

    'Cnt0=未入庫數,Cnt1=已出庫數,Cnt2=作廢數量,Cnt3=查無條碼,Cnt4=重複條碼,Cnt5=總數量
    Dim Cnt0 As Integer = 0 : Dim Cnt1 As Integer = 0 : Dim Cnt2 As Integer = 0 : Dim Cnt3 As Integer = 0 : Dim Cnt4 As Integer = 0 : Dim Cnt5 As Integer = 0
    '暫存資料庫名
    Dim SyncPDA1 As String = "" : Dim SyncPDA2 As String = "" : Dim SyncPDA3 As String = ""

    Private Sub Bu上頁_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu上頁.Click
        出庫作業V001.Show()
        出庫作業V001.單據條碼T1.PerformClick()
        Me.Close()

    End Sub

    Private Sub PDA同步V104_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "PDA上傳轉入(出庫作業) v1.04"
        文字初始化()
        CB作業別.SelectedIndex = 0

    End Sub

    Private Sub 文字初始化()
        La數量.Text = "0筆"
        La入庫.Text = "0筆"
        La出庫.Text = "0筆"
        La作廢.Text = "0筆"
        La異常.Text = "0筆"
        La重複.Text = "0筆"
        La時間.Text = "查詢時間: 0.00 秒"

        CB作業別.Items.Clear()
        CB作業別.Items.Add("請選擇")    '0
        CB作業別.Items.Add("0.不分類")  '1 ALL
        CB作業別.Items.Add("1.銷售")    '2 31.銷售電宰,32.銷售加工
        CB作業別.Items.Add("2.領料")    '3 21.領料電宰,22.領料加工,24.分時電宰
        CB作業別.Items.Add("3.存領")    '4 41.存領電宰,42.存領加工
        CB作業別.Items.Add("4.寄庫")    '5 51.寄庫出庫

    End Sub

    Private Sub CB作業別_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CB作業別.SelectedIndexChanged
        執行作業()
    End Sub

    Private Sub 執行作業()
        Dim TimeA As DateTime : TimeA = Now()
        Dim 作業代碼 As String = ""
        Select Case CB作業別.SelectedIndex
            Case "1" : 作業代碼 = "1" : 出庫條碼載入作業("1")
            Case "2" : 作業代碼 = "2" : 出庫條碼載入作業("2")
            Case "3" : 作業代碼 = "3" : 出庫條碼載入作業("3")
            Case "4" : 作業代碼 = "4" : 出庫條碼載入作業("4")
            Case "5" : 作業代碼 = "5" : 出庫條碼載入作業("5")
            Case Else
                La時間.Text = "查詢時間: " & Format((Now() - TimeA).TotalSeconds, "0.00") & " 秒"
                Exit Sub
        End Select
        出庫條碼調整作業()
        If DGV1.RowCount > 0 Then : Bu同步.Enabled = True : Else : Bu同步.Enabled = False : End If
        La時間.Text = "查詢時間: " & Format((Now() - TimeA).TotalSeconds, "0.00") & " 秒"
    End Sub

    Private Sub 出庫條碼載入作業(ByVal Dt1 As String)
        If DGV2.RowCount > 0 Then : 顯示資料.Tables("PDA轉出").Clear() : DGV1.DataSource = Nothing : DGV2.DataSource = Nothing : End If '清除DGV資料
        Dim SQLQuery As String = ""
        SQLQuery = " EXEC [dbo].[預_轉PDA同步作業01v] '" & Dt1 & "' "
        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd)
            DataAdapterDGV.Fill(顯示資料, "PDA轉出")

            DGV1.DataSource = 顯示資料.Tables("PDA轉出").Copy
            DGV2.DataSource = 顯示資料.Tables("PDA轉出").Copy

            If 選擇作業 = "Y" Then
                Dim CBxColumn1 As New DataGridViewCheckBoxColumn() : CBxColumn1.Name = "選擇" : CBxColumn1.Width = 30 : DGV1.Columns.Insert(0, CBxColumn1)
                Dim CBxColumn2 As New DataGridViewCheckBoxColumn() : CBxColumn2.Name = "選擇" : CBxColumn2.Width = 30 : DGV2.Columns.Insert(0, CBxColumn2)
            End If
            選擇作業 = "N"

            For i As Integer = 0 To DGV2.ColumnCount - 1
                DGV2.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

        Catch ex As Exception
            MsgBox("出庫條碼載入作業：" & ex.Message)
        End Try

    End Sub

    Private Sub 出庫條碼調整作業()
        DGV2出庫條碼調整作業()
        DGV1出庫條碼調整作業()
        DGV2出庫條碼顯示()
        'DGV1出庫條碼顯示()
        DGV2異常檢查()
        DGV1異常檢查()
        DGV1.AutoResizeColumns()
        DGV2.AutoResizeColumns()
        If DGV2.Rows.Count > 0 Then : DGV2.CurrentCell = DGV2.Rows(0).Cells(5) : End If
        If DGV1.Rows.Count > 0 Then : DGV1.CurrentCell = DGV1.Rows(0).Cells(4) : End If

        La數量.Text = Cnt5 & "筆"
        La入庫.Text = Cnt0 & "筆"
        La出庫.Text = Cnt1 & "筆"
        La作廢.Text = Cnt2 & "筆"
        La異常.Text = Cnt3 & "筆"
        La重複.Text = Cnt4 & "筆"

    End Sub

    Private Sub DGV2出庫條碼調整作業()
        Cnt0 = 0 : Cnt1 = 0 : Cnt4 = 0 : Cnt5 = 0
        If DGV2.RowCount > 0 Then
            Dim count As Integer = DGV2.Rows.Count
            For i As Integer = count - 1 To 0 Step -1
                If DGV2.Rows(i).Cells("管理").Value = "A" Then
                    If (DGV2.Rows(i).Cells("總數").Value = DGV2.Rows(i).Cells("入庫否").Value) And _
                        DGV2.Rows(i).Cells("出庫否").Value = 0 And _
                        DGV2.Rows(i).Cells("重複").Value = 0 Then
                        DGV2.Rows(i).Cells("選擇").Value = True
                    Else
                        DGV2.Rows(i).Cells("選擇").Value = False
                        DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                    Cnt5 += DGV2.Rows(i).Cells("總數").Value
                    Cnt0 += DGV2.Rows(i).Cells("入庫否").Value
                    Cnt1 += DGV2.Rows(i).Cells("出庫否").Value
                    Cnt4 += DGV2.Rows(i).Cells("重複").Value
                Else : DGV2.Rows.Remove(DGV2.Rows(i))
                End If
            Next
        End If

    End Sub

    Private Sub DGV1出庫條碼調整作業()
        If DGV1.RowCount > 0 Then
            '移除異常條碼
            Dim count2 As Integer = DGV2.Rows.Count
            For x As Integer = count2 - 1 To 0 Step -1
                If DGV2.Rows(x).Cells("管理").Value = "A" And DGV2.Rows(x).Cells("選擇").Value = False Then  '迴1開始
                    Dim count1 As Integer = DGV1.Rows.Count
                    For i As Integer = count1 - 1 To 0 Step -1
                        If DGV1.Rows(i).Cells("管理").Value = "B" Or DGV1.Rows(i).Cells("管理").Value = "S" Then  '迴2開始

                            '迴3開始
                            If DGV2.Rows(x).Cells("作業").Value = DGV1.Rows(i).Cells("作業").Value And _
                               DGV2.Rows(x).Cells("交貨草稿").Value = DGV1.Rows(i).Cells("交貨草稿").Value Then
                                DGV1.Rows.Remove(DGV1.Rows(i))
                            End If
                            '迴3結束

                        Else : DGV1.Rows.Remove(DGV1.Rows(i))
                        End If '迴2結束
                    Next
                End If  '迴1結束
            Next

            '移除管理=A作業
            Dim count3 As Integer = DGV1.Rows.Count
            For i As Integer = count3 - 1 To 0 Step -1
                If DGV1.Rows(i).Cells("管理").Value = "A" Then  '迴2開始
                    DGV1.Rows.Remove(DGV1.Rows(i))
                Else
                    DGV1.Rows(i).Cells("選擇").Value = False
                End If
            Next
        End If

    End Sub

    Private Sub DGV1出庫條碼顯示()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True : column.ReadOnly = False : column.Visible = True
                Case "代碼" : column.HeaderText = "代碼" : column.DisplayIndex = 1
                Case "交貨草稿" : column.HeaderText = "交貨草稿" : column.DisplayIndex = 2
                Case "條碼" : column.HeaderText = "條碼" : column.DisplayIndex = 3
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 4
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 5
                Case "出庫數量" : column.HeaderText = "出庫數量" : column.DisplayIndex = 6
                Case "庫存數量" : column.HeaderText = "庫存數量" : column.DisplayIndex = 7
                Case "重量" : column.HeaderText = "重量" : column.DisplayIndex = 8
                Case "庫位" : column.HeaderText = "庫位" : column.DisplayIndex = 9
                Case "儲位" : column.HeaderText = "儲位" : column.DisplayIndex = 10
                Case "生產日期" : column.HeaderText = "生產日期" : column.DisplayIndex = 11
                Case "製造單號" : column.HeaderText = "製造單號" : column.DisplayIndex = 12
                Case "重複" : column.HeaderText = "重複" : column.DisplayIndex = 13
                Case "入庫否" : column.HeaderText = "入庫否" : column.DisplayIndex = 14
                Case "出庫否" : column.HeaderText = "出庫否" : column.DisplayIndex = 15
                Case "G1" : column.HeaderText = "G1" : column.DisplayIndex = 16
                Case "管理" : column.HeaderText = "管理" : column.DisplayIndex = 17
                Case "Gift" : column.HeaderText = "Gift" : column.DisplayIndex = 18
                Case "ID" : column.HeaderText = "ID" : column.DisplayIndex = 19
                Case "作業" : column.HeaderText = "作業" : column.DisplayIndex = 20

                Case Else : column.Visible = False
            End Select
        Next
    End Sub

    Private Sub DGV2出庫條碼顯示()
        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True : column.ReadOnly = True
            Select Case column.Name
                Case "選擇" : column.HeaderText = "選擇" : column.DisplayIndex = 0 : column.Frozen = True : column.ReadOnly = False : column.Visible = True
                Case "交貨草稿" : column.HeaderText = "交貨草稿" : column.DisplayIndex = 1 : column.Visible = True
                Case "總數" : column.HeaderText = "總數" : column.DisplayIndex = 2 : column.Visible = True
                Case "重複" : column.HeaderText = "重複" : column.DisplayIndex = 3 : column.Visible = True
                Case "入庫否" : column.HeaderText = "入庫否" : column.DisplayIndex = 4 : column.Visible = True
                Case "出庫否" : column.HeaderText = "出庫否" : column.DisplayIndex = 5 : column.Visible = True
                Case "作業" : column.HeaderText = "作業" : column.DisplayIndex = 6 : column.Visible = True
                Case Else : column.Visible = False
            End Select
        Next
    End Sub

    Private Sub DGV1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV1.Sorted
        DGV1異常檢查()
    End Sub

    Private Sub DGV1異常檢查()
        Dim count As Integer = DGV1.Rows.Count
        For i As Integer = 0 To count - 1
            If DGV1.Rows(i).Cells("管理").Value = "B" Or DGV1.Rows(i).Cells("管理").Value = "S" Then
                If DGV1.Rows(i).Cells("重複").Value = "重複" Then
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                End If
                If DGV1.Rows(i).Cells("入庫否").Value = "未入庫" Then
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Silver
                End If
                If DGV1.Rows(i).Cells("出庫否").Value = "出庫" Then
                    DGV1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Next
    End Sub

    Private Sub DGV2_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV2.Sorted
        DGV2異常檢查()
    End Sub

    Private Sub DGV2異常檢查()
        If DGV2.RowCount > 0 Then
            Dim count As Integer = DGV2.Rows.Count
            For i As Integer = count - 1 To 0 Step -1
                If DGV2.Rows(i).Cells("管理").Value = "A" Then
                    If (DGV2.Rows(i).Cells("總數").Value = DGV2.Rows(i).Cells("入庫否").Value) And _
                        DGV2.Rows(i).Cells("出庫否").Value = 0 And _
                        DGV2.Rows(i).Cells("重複").Value = 0 Then
                        DGV2.Rows(i).Cells("選擇").Value = True
                    Else
                        DGV2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        'MsgBox(DGV1.CurrentCell.RowIndex() & vbCrLf & DGV1.CurrentCell.ColumnIndex())

    End Sub

    Private Sub DGV2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV2.CellClick
        If DGV2.RowCount > 0 Then
            If DGV2.Rows(DGV2.CurrentCell.RowIndex()).Cells("選擇").Value = True Then
                DGV2.Rows(DGV2.CurrentCell.RowIndex()).Cells("選擇").Value = False
            Else
                DGV2.Rows(DGV2.CurrentCell.RowIndex()).Cells("選擇").Value = True
            End If
            DGV1.DataSource = Nothing
            DGV1.DataSource = 顯示資料.Tables("PDA轉出").Copy
            DGV1出庫條碼調整作業()
            DGV1異常檢查()
            DGV1.AutoResizeColumns()
            If DGV1.RowCount > 0 Then : DGV1.CurrentCell = DGV1.Rows(0).Cells(4) : End If
            If DGV1.RowCount > 0 Then : Bu同步.Enabled = True : Else : Bu同步.Enabled = False : End If
        End If

    End Sub

    Private Sub Bu同步_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu同步.Click
        If DGV1.RowCount > 0 Then
            同步入出庫條碼() : Bu上頁.PerformClick()
        End If

    End Sub

    Private Sub 同步入出庫條碼()
        Dim SQLQuery As String = "" : Dim SQLAdd As String = "" : Dim 已轉出 As String = "" : Dim 轉調庫 As String = ""
        Dim count As Integer = DGV1.Rows.Count
        For i As Integer = 0 To count - 1
            If DGV1.Rows(i).Cells("管理").Value = "B" Or DGV1.Rows(i).Cells("管理").Value = "S" Then
                '
                If DGV1.Rows(i).Cells("重複").Value = "" And _
                   DGV1.Rows(i).Cells("入庫否").Value = "已入庫" And _
                   DGV1.Rows(i).Cells("出庫否").Value = "在庫" Then
                    SQLQuery += "  INSERT INTO [KaiShingPlug].[dbo].[PDA_OutData_SAP] ([OUT01], [OUT02], [OUT03], [OUT04], [OUT05], [OUT06], [OUTDT]) VALUES "
                    SQLQuery += "  ( '" & DGV1.Rows(i).Cells("代碼").Value & "'    , '" & DGV1.Rows(i).Cells("條碼").Value & "', "
                    SQLQuery += "    '" & DGV1.Rows(i).Cells("出庫數量").Value & "', '" & DGV1.Rows(i).Cells("交貨草稿").Value & "', "
                    SQLQuery += "    '" & DGV1.Rows(i).Cells("Gift").Value & "','3', GETDATE()) " & vbCrLf
                    If 已轉出 = "" Then : 已轉出 = DGV1.Rows(i).Cells("ID").Value : Else : 已轉出 += "," & DGV1.Rows(i).Cells("ID").Value : End If
                    '凱馨需求21,24作業條碼轉調庫作業
                    If Login.LogonCompanyDB = "KaiShing" Then
                        If DGV1.Rows(i).Cells("代碼").Value = "21.領料電宰" Or DGV1.Rows(i).Cells("代碼").Value = "24.分時電宰" Then
                            SQLAdd += " INSERT INTO [Z_KS_Barcode] ([Del],[F1],[F2],[F3],[F4],[InDaetTime]) VALUES "
                            SQLAdd += " ('N',CONVERT(VARCHAR(8),GETDATE(),112),"           ' 刪除,單號
                            SQLAdd += "  '" & DGV1.Rows(i).Cells("條碼").Value & "',"      ' 條碼
                            SQLAdd += "  'G','K006-' + CONVERT(VARCHAR(8),GETDATE(),112)," ' 作業,儲位
                            SQLAdd += "  GETDATE()) " & vbCrLf                             ' 同步時間
                        End If
                    End If
                    '凱馨需求作業結束
                End If

            End If
        Next
        SQLQuery += " UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '3', [PDA05] = GETDATE() WHERE [PDA01] IN (SELECT VALUE FROM [dbo].[SplitWords] ('" & 已轉出 & "')) "

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery & vbCrLf & SQLAdd : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("同步入出庫條碼" & ex.Message)
        End Try

    End Sub

    Private Sub Bu移除_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu移除.Click
        If DGV1.RowCount > 0 Then
            異常排除條碼()
            執行作業()
        End If

    End Sub

    Private Sub 異常排除條碼()
        Dim SQLQuery As String = "" : Dim 已轉出1 As String = "" : Dim 已轉出2 As String = ""
        For Each oRow As DataGridViewRow In DGV1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(oRow.Cells("選擇").Value)
            If isSelected = True Then
                If oRow.Cells("管理").Value = "B" Or oRow.Cells("管理").Value = "S" Then
                    If oRow.Cells("重複").Value = "重複" And oRow.Cells("入庫否").Value = "已入庫 Then" Then
                        If 已轉出1 = "" Then : 已轉出1 = oRow.Cells("ID").Value : Else : 已轉出1 += "," & oRow.Cells("ID").Value : End If
                    End If
                    If oRow.Cells("出庫否").Value = "出庫" Then
                        If 已轉出2 = "" Then : 已轉出2 = oRow.Cells("ID").Value : Else : 已轉出2 += "," & oRow.Cells("ID").Value : End If
                    End If


                End If
            End If
        Next

        'Dim count As Integer = DGV1.Rows.Count
        'For i As Integer = 0 To count - 1
        '    If DGV1.Rows(i).Cells("管理").Value = "B" Or DGV1.Rows(i).Cells("管理").Value = "S" Then
        '        If DGV1.Rows(i).Cells("重複").Value = "" Then
        '            If 已轉出1 = "" Then : 已轉出1 = DGV1.Rows(i).Cells("ID").Value : Else : 已轉出1 += "," & DGV1.Rows(i).Cells("ID").Value : End If
        '        End If
        '        If DGV1.Rows(i).Cells("出庫否").Value = "出庫" Then
        '            If 已轉出2 = "" Then : 已轉出2 = DGV1.Rows(i).Cells("ID").Value : Else : 已轉出2 += "," & DGV1.Rows(i).Cells("ID").Value : End If
        '        End If
        '    End If
        'Next
        If 已轉出1 <> "" Then
            SQLQuery += "      UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA05] = GETDATE() WHERE [PDA01] IN (SELECT VALUE FROM [dbo].[SplitWords] ('" & 已轉出1 & "')) " & vbCrLf
        End If
        If 已轉出2 <> "" Then
            SQLQuery += "      UPDATE [KaiShingPlug].[dbo].[PDA_InData] SET [PDA06] = '6', [PDA05] = GETDATE() WHERE [PDA01] IN (SELECT VALUE FROM [dbo].[SplitWords] ('" & 已轉出2 & "')) "
        End If
        MsgBox(SQLQuery)

        Try
            Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox("異常排除條碼" & ex.Message)
        End Try

    End Sub

    Private Sub 轉Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉Excel.Click
        DataToExcel(DGV1, "")

    End Sub
End Class

