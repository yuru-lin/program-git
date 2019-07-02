Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 訂單上傳作業

    Private Sub Bu讀取上傳_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu讀取上傳.Click
        Select Case 客戶.Text
            Case "全聯" : 上傳作業()
            Case "好市多" : 上傳作業()
            Case "嘉珍香" : 上傳作業()
            Case Else
        End Select

    End Sub

    Private Sub 上傳作業()
        Dim openfile As New OpenFileDialog()

        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"
        openfile.Filter = "Excel files(*.xls)|*.xls"        '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then : Exit Sub : End If

        Dim connectionString As String = " Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1' "
        'Dim strSQL As String = " SELECT * FROM [Sheet1$] "
        Dim strSQL As String = ""
        Select Case 客戶.Text
            Case "全聯", "好市多"
                strSQL = " SELECT * FROM [Sheet1$] "
            Case "嘉珍香"
                strSQL = " SELECT * FROM [上傳區$] "
            Case Else
        End Select
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open()

            Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)
            Dim dTable As DataTable = New DataTable()
            dataAdapter.Fill(dTable)
            DGV1.DataSource = dTable
            Select Case 客戶.Text
                Case "全聯" : DGV1.Rows.Remove(DGV1.Rows(0))
                Case "好市多"
                Case "嘉珍香" : DGV1.Rows.Remove(DGV1.Rows(0))
                Case Else
            End Select
            dTable.Dispose()
            dataAdapter.Dispose()
            dbCommand.Dispose()
            excelConnection.Close() : excelConnection.Dispose()
            DGV1欄位()
            DGV1資料回寫暫存()

        Catch ex As Exception
            MsgBox("讀取Excel 錯誤：" & ex.Message) : Exit Sub
        End Try
    End Sub

    Private Sub DGV1欄位()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case 客戶.Text
                Case "全聯"
                    Select Case column.Name
                        Case "F1" : column.HeaderText = "序號"
                        Case "F2" : column.HeaderText = "營業所代號"
                        Case "F3" : column.HeaderText = "營業所名稱"
                        Case "F4" : column.HeaderText = "單號"
                        Case "F5" : column.HeaderText = "訂貨日期"
                        Case "F6" : column.HeaderText = "到貨日期"
                        Case "F7" : column.HeaderText = "貨號"
                        Case "F8" : column.HeaderText = "呼出碼"
                        Case "F9" : column.HeaderText = "條碼"
                        Case "F10" : column.HeaderText = "品名"
                        Case "F11" : column.HeaderText = "規格"
                        Case "F12" : column.HeaderText = "訂貨單位"
                        Case "F13" : column.HeaderText = "售價"
                        Case "F14" : column.HeaderText = "進價"
                        Case "F15" : column.HeaderText = "訂貨量"
                        Case "F16" : column.HeaderText = "特賣註記"
                        Case "F17" : column.HeaderText = "出貨盒數"
                        Case "F18" : column.HeaderText = "出貨數量"
                        Case "F19" : column.HeaderText = "指定出貨地點代號"
                        Case "F20" : column.HeaderText = "指定出貨地點名稱"
                        Case "F21" : column.HeaderText = "訂單備註"
                        Case "F22" : column.HeaderText = "路線名稱"
                        Case "F23" : column.HeaderText = "商品分類名稱"
                        Case Else
                            column.Visible = False
                    End Select
                Case "好市多"
                    Select Case column.Name
                        Case "F1" : column.HeaderText = "訂單資訊"
                        Case Else
                            column.Visible = False
                    End Select
                Case "嘉珍香"
                    Select Case column.Name
                        Case "F1" : column.HeaderText = "KID"
                        Case "F2" : column.HeaderText = "客編"
                        Case "F3" : column.HeaderText = "客名"
                        Case "F4" : column.HeaderText = "送貨地"
                        Case "F5" : column.HeaderText = "送貨日"
                        Case "F6" : column.HeaderText = "送貨日西"
                        Case "F7" : column.HeaderText = "NO"
                        Case "F8" : column.HeaderText = "存編"
                        Case "F9" : column.HeaderText = "名稱"
                        Case "F10" : column.HeaderText = "名稱2"
                        Case "F11" : column.HeaderText = "數量"
                        Case "F12" : column.HeaderText = "單位"
                        Case "F13" : column.HeaderText = "價格"
                        Case "F14" : column.HeaderText = "計價單位"
                        Case "F15" : column.HeaderText = "計價代碼"
                        Case "F16" : column.HeaderText = "備註"
                        Case Else
                            column.Visible = False
                    End Select
                Case Else
            End Select
        Next

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub DGV1資料回寫暫存()

        Dim SQLADD As String = "" : Dim SQLDEL As String = ""
        Dim KID As Integer = 0 : Dim SID As Integer = 0
        Dim DocDate As String = "" : Dim DocNo As String = "" : Dim Del As String = "Y"

        If DGV1.RowCount > 0 Then
            For i = 0 To DGV1.RowCount - 1
                Select Case 客戶.Text
                    Case "全聯"
                        SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[全聯訂單] ([序號], [營業所代號], [營業所名稱], [單號], [訂貨日期], [到貨日期], [貨號], [呼出碼], [條碼], [品名], [規格], [訂貨單位], [售價], [進價], [訂貨量], [特賣註記], [出貨盒數], [出貨數量], [指定出貨地點代號], [指定出貨地點名稱], [訂單備註], [路線名稱], [商品分類名稱], [新增時間], [啟用否])  "
                        SQLADD += " VALUES ('" & DGV1.Rows(i).Cells("F1").Value & "',  '" & DGV1.Rows(i).Cells("F2").Value & "',  '" & DGV1.Rows(i).Cells("F3").Value & "',  '" & DGV1.Rows(i).Cells("F4").Value & "',  '" & DGV1.Rows(i).Cells("F5").Value & "',  '" & DGV1.Rows(i).Cells("F6").Value & "',  '" & DGV1.Rows(i).Cells("F7").Value & "',  '" & DGV1.Rows(i).Cells("F8").Value & "',  "
                        SQLADD += "         '" & DGV1.Rows(i).Cells("F9").Value & "',  '" & DGV1.Rows(i).Cells("F10").Value & "', '" & DGV1.Rows(i).Cells("F11").Value & "', '" & DGV1.Rows(i).Cells("F12").Value & "', '" & DGV1.Rows(i).Cells("F13").Value & "', '" & DGV1.Rows(i).Cells("F14").Value & "', '" & DGV1.Rows(i).Cells("F15").Value & "', '" & DGV1.Rows(i).Cells("F16").Value & "', "
                        SQLADD += "         '" & DGV1.Rows(i).Cells("F17").Value & "', '" & DGV1.Rows(i).Cells("F18").Value & "', '" & DGV1.Rows(i).Cells("F19").Value & "', '" & DGV1.Rows(i).Cells("F20").Value & "', '" & DGV1.Rows(i).Cells("F21").Value & "', '" & DGV1.Rows(i).Cells("F22").Value & "', '" & DGV1.Rows(i).Cells("F23").Value & "',  "
                        SQLADD += "         GETDATE(), 'Y' ) "

                    Case "好市多"
                        If "M96972798" = Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("F1").Value, 9) Then
                            If DocDate = Microsoft.VisualBasic.Mid(DGV1.Rows(i).Cells("F1").Value, 86, 8) Then : Del = "N" : Else : Del = "Y" : End If
                            DocDate = Microsoft.VisualBasic.Mid(DGV1.Rows(i).Cells("F1").Value, 86, 8)
                            DocNo = Microsoft.VisualBasic.Mid(DGV1.Rows(i).Cells("F1").Value, 25, 12)
                            KID = KID + 1
                            SID = 0
                            If Del = "Y" Then
                                SQLADD += " UPDATE [KaiShingPlug].[dbo].[營_訂單暫存] SET [YesNo] = 'D' "
                                SQLADD += "   FROM [KaiShingPlug].[dbo].[營_訂單暫存] T0 "
                                SQLADD += "  WHERE T0.[DocDate] = '" & DocDate & "' AND [Client] = '好市多' " & vbCrLf
                                'SQLADD += "  WHERE T0.[DocDate] = '" & DocDate & "' AND [Client] = '好市多' AND [YesNo] = 'Y' " & vbCrLf
                            End If
                        Else : SID = SID + 1 : End If
                        SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[營_訂單暫存] ([KID],[SID],[Client],[DocDate],[DocNo],[Text],[Date],[YesNo]) "
                        SQLADD += " VALUES ('" & KID & "', '" & SID & "', '" & 客戶.Text & "', '" & DocDate & "', '" & DocNo & "', '" & DGV1.Rows(i).Cells("F1").Value & "',"
                        SQLADD += "         GETDATE(), 'Y' ) " & vbCrLf

                    Case "嘉珍香"
                        If DGV1.Rows(i).Cells("F2").Value <> "" And DGV1.Rows(i).Cells("F11").Value <> 0 Then
                            SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[營_訂單暫存] ([KID],[SID],[Client],[DocDate],[DocNo],[Text],[Date],[YesNo],[CardCode],[ShipToCode],[ItemCode],[ItemName],[ItemName2],[Quantity],[SalPackMsr],[Comments],[U_P8],[U_P7])  "
                            SQLADD += " VALUES ('" & DGV1.Rows(i).Cells("F1").Value & "',  '" & DGV1.Rows(i).Cells("F7").Value & "',  '嘉珍香',  '" & DGV1.Rows(i).Cells("F6").Value & "', "
                            SQLADD += "         '0',                                       '" & DGV1.Rows(i).Cells("F3").Value & "',  GETDATE(), 'Y',  "
                            SQLADD += "         '" & DGV1.Rows(i).Cells("F2").Value & "',  '" & DGV1.Rows(i).Cells("F4").Value & "',  '" & DGV1.Rows(i).Cells("F8").Value & "', "
                            SQLADD += "         '" & DGV1.Rows(i).Cells("F9").Value & "',  '" & DGV1.Rows(i).Cells("F10").Value & "', '" & DGV1.Rows(i).Cells("F11").Value & "', "
                            SQLADD += "         '" & UCase(DGV1.Rows(i).Cells("F12").Value) & "', '" & DGV1.Rows(i).Cells("F16").Value & "', '" & DGV1.Rows(i).Cells("F13").Value & "', '" & DGV1.Rows(i).Cells("F15").Value & "') " & vbCrLf
                            DocDate = CStr(DGV1.Rows(i).Cells("F6").Value)
                        End If

                    Case Else
                End Select
            Next
        End If

        Select Case 客戶.Text
            Case "全聯" : SQLDEL = ""
            Case "好市多" : SQLDEL = ""
            Case "嘉珍香"
                SQLDEL = "  UPDATE [KaiShingPlug].[dbo].[營_訂單暫存] SET [YesNo] = 'D' "
                SQLDEL += "   FROM [KaiShingPlug].[dbo].[營_訂單暫存] T0 "
                SQLDEL += "  WHERE T0.[DocDate] = '" & DocDate & "' AND [Client] = '嘉珍香' AND [YesNo] = 'Y' " & vbCrLf
            Case Else
        End Select

        'MsgBox(SQLDEL)

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLDEL + SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        MsgBox("回存成功!")

    End Sub
End Class