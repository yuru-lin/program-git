Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 代工轉入生產
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    '暫存資料表名稱
    Dim OutIntmp1 As String = "" : Dim OutIntmp2 As String = "" : Dim OutIntmp3 As String = "" : Dim OutIntmp4 As String = ""

    Private Sub 代工轉入生產_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OutIntmp1 = Format(Replace(Replace("#OutIntmp1" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")    '初始
        La筆數1.Text = "" : La筆數2.Text = "" : La單號.Text = ""

    End Sub

    Private Sub bu讀取_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bu讀取.Click
        'If DGV2.RowCount > 0 Then : ks1DataSetDGV.Tables("DT2").Clear() : End If

        'SyncToDB.Enabled = False
        Dim openfile As New OpenFileDialog()

        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"
        openfile.Filter = "Excel files(*.xls)|*.xls"        '只抓excel檔  

        openfile.ShowDialog()


        If openfile.FileName = "" Then : Exit Sub : End If

        Dim connectionString As String = " Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1' "
        Dim strSQL As String = " SELECT * FROM [Sheet1$] "
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open()

            Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)
            Dim dTable As DataTable = New DataTable()
            dataAdapter.Fill(dTable)
            DGV2.DataSource = dTable
            DGV2.Rows.Remove(DGV2.Rows(0))
            dTable.Dispose()
            dataAdapter.Dispose()
            dbCommand.Dispose()
            excelConnection.Close() : excelConnection.Dispose()
            DGV2欄位()
            DGV2資料回寫暫存()
            DGV2資料整合()
            DGV2資料整查核()

        Catch ex As Exception
            MsgBox("讀取Excel 錯誤：" & ex.Message) : Exit Sub
        End Try

    End Sub

    Private Sub DGV2欄位()
        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1" : column.HeaderText = "FI100"
                Case "F2" : column.HeaderText = "FI101"
                Case "F3" : column.HeaderText = "FI102"
                Case "F4" : column.HeaderText = "FI103"
                Case "F5" : column.HeaderText = "FI104"
                Case "F6" : column.HeaderText = "FI105"
                Case "F7" : column.HeaderText = "FI106"
                Case "F8" : column.HeaderText = "FI107"
                Case "F9" : column.HeaderText = "FI107K"
                Case "F10" : column.HeaderText = "FI108"
                Case "F11" : column.HeaderText = "FI109"
                Case "F12" : column.HeaderText = "FI110"
                Case "F13" : column.HeaderText = "FI111"
                Case "F14" : column.HeaderText = "FI112"
                Case "F15" : column.HeaderText = "FI113"
                Case "F16" : column.HeaderText = "FI114"
                Case "F17" : column.HeaderText = "FI115"
                Case "F18" : column.HeaderText = "FI116"
                Case "F19" : column.HeaderText = "FI117"
                Case "F20" : column.HeaderText = "FI118"
                Case "F21" : column.HeaderText = "FI119"
                Case "F22" : column.HeaderText = "FI120"
                Case "F23" : column.HeaderText = "FI121"
                Case "F24" : column.HeaderText = "FI122"
                Case "F25" : column.HeaderText = "FI123"
                Case "F26" : column.HeaderText = "FI124"
                Case "F27" : column.HeaderText = "FI125"
                Case "F28" : column.HeaderText = "FI126"
                Case "F29" : column.HeaderText = "FI127"
                Case "F30" : column.HeaderText = "FI128"
                Case "F31" : column.HeaderText = "FI129"
                Case "F32" : column.HeaderText = "FI130"
                Case "F33" : column.HeaderText = "FI131"
                Case "F34" : column.HeaderText = "FI132"
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV2.AutoResizeColumns()
        La筆數1.Text = "總件數：" & DGV2.RowCount
    End Sub

    Private Sub DGV2資料回寫暫存()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQL As String = "" : Dim SQLADD As String = "" : Dim DEL As String = " "
        DEL += "DELETE FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] WHERE [FI100] = '" & DGV2.Rows(0).Cells("F1").Value & "' "

        If DGV2.RowCount > 0 Then
            For i = 0 To DGV2.RowCount - 1
                Dim FI129 As String
                FI129 = DGV2.Rows(i).Cells("F31").Value 'F31
                'SQLADD += " INSERT INTO " & OutIntmp1 & " ([FI101], [FI102], [FI103], [FI104], [FI105], [FI106], [FI107], [FI108], [FI109], [FI110], [FI111], [FI112], [FI113], [FI114], [FI115], [FI116], [FI117], [FI118], [FI119], [FI120], [FI121], [FI122], [FI123], [FI124], [FI125], [FI126], [FI127], [FI128], [FI129], [FI130], [FI131], [FI132], [FI133], [FI134])  "
                SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] ([FI100], [FI101], [FI102], [FI103], [FI104], [FI105], [FI106], [FI107], [FI107K], [FI108], [FI109], [FI110], [FI111], [FI112], [FI113], [FI114], [FI115], [FI116], [FI117], [FI118], [FI119], [FI120], [FI121], [FI122], [FI123], [FI124], [FI125], [FI126], [FI127], [FI128], [FI129], [FI130], [FI131], [FI132])  "
                'SQLADD += " VALUES ('" & DGV2.Rows(i).Cells("F2").Value & "',  '" & DGV1.Rows(i).Cells("F3").Value & "',  '" & DGV1.Rows(i).Cells("F4").Value & "',  '" & DGV1.Rows(i).Cells("F5").Value & "',  '" & DGV1.Rows(i).Cells("F6").Value & "',  '" & DGV1.Rows(i).Cells("F8").Value & "',  "
                SQLADD += " VALUES ('" & DGV2.Rows(i).Cells("F1").Value & "',  '" & DGV2.Rows(i).Cells("F2").Value & "',  '" & DGV2.Rows(i).Cells("F3").Value & "',  '2',                                       '" & DGV2.Rows(i).Cells("F5").Value & "',  '" & DGV2.Rows(i).Cells("F6").Value & "',  '" & DGV2.Rows(i).Cells("F7").Value & "',  '" & DGV2.Rows(i).Cells("F8").Value & "',  "
                SQLADD += "         '" & DGV2.Rows(i).Cells("F9").Value & "',  '" & DGV2.Rows(i).Cells("F10").Value & "', '" & DGV2.Rows(i).Cells("F11").Value & "', '" & DGV2.Rows(i).Cells("F12").Value & "', '" & DGV2.Rows(i).Cells("F13").Value & "', '" & DGV2.Rows(i).Cells("F14").Value & "', '" & DGV2.Rows(i).Cells("F15").Value & "', '" & DGV2.Rows(i).Cells("F16").Value & "', "
                SQLADD += "         '" & DGV2.Rows(i).Cells("F17").Value & "', '" & DGV2.Rows(i).Cells("F18").Value & "', '" & DGV2.Rows(i).Cells("F19").Value & "', '" & DGV2.Rows(i).Cells("F20").Value & "', '" & DGV2.Rows(i).Cells("F21").Value & "', '" & DGV2.Rows(i).Cells("F22").Value & "', '" & DGV2.Rows(i).Cells("F23").Value & "', '" & DGV2.Rows(i).Cells("F24").Value & "', "
                SQLADD += "         '" & DGV2.Rows(i).Cells("F25").Value & "', '" & DGV2.Rows(i).Cells("F26").Value & "', '" & DGV2.Rows(i).Cells("F27").Value & "', '" & DGV2.Rows(i).Cells("F28").Value & "', '" & FI129 & "',                           '" & DGV2.Rows(i).Cells("F30").Value & "', '" & DGV2.Rows(i).Cells("F31").Value & "', '" & DGV2.Rows(i).Cells("F32").Value & "', "
                SQLADD += "         '" & DGV2.Rows(i).Cells("F33").Value & "', '" & DGV2.Rows(i).Cells("F34").Value & "' ) "
            Next
        End If
        'SQL = "    IF (OBJECT_ID('tempdb.." & OutIntmp1 & "') IS NOT NULL)  DROP TABLE " & OutIntmp1 & " " & SQLADD
        'SQL += "   SELECT * FROM " & OutIntmp1 & " "

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = DEL : SQLCmd.CommandText += SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        'MsgBox("資料庫同步成功!")

    End Sub

    Private Sub DGV2資料整合()
        If DGV1.RowCount > 0 Then : ks1DataSetDGV.Tables("明細").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = ""
        SQLQuery = "   SELECT DISTINCT [FI101],[FI102],'3' AS 'FI103',[FI104],[FI105] "
        SQLQuery += "    FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] WHERE [FI103] = '2' AND LEFT([FI107],2) = '31' AND LEFT([FI107K],2) = '25' AND [FI100] = '" & DGV2.Rows(0).Cells("F1").Value & "'  "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "明細")
            DGV1.DataSource = ks1DataSetDGV.Tables("明細")
            DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("明細：" & ex.Message)
        End Try

    End Sub

    Private Sub DGV2資料整查核()
        If DGV3.RowCount > 0 Then : ks1DataSetDGV.Tables("FI106").Clear() : End If '清除DGV1資料
        Dim DrfNum As String = "" : Dim DrfNums As String = ""
        If DGV2.RowCount > 0 Then
            For i = 0 To DGV2.RowCount - 1
                If DrfNum = "" Then
                    DrfNum = DrfNum + Format(DGV2.Rows(i).Cells("F7").Value, "")
                Else
                    DrfNum = DrfNum + "','" + Format(DGV2.Rows(i).Cells("F7").Value, "")
                End If
            Next : End If
        If DrfNum = "" Then : MsgBox("無載入條碼") : Exit Sub : End If

        Dim SQLQuery As String = ""
        SQLQuery = "   SELECT [FI106] "
        SQLQuery += "    FROM [@FinishItem1] WHERE [FI106] IN ('" & DrfNum & "') "

        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            DataAdapterDGV = New SqlDataAdapter(SQLQuery, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "FI106")
            DGV3.DataSource = ks1DataSetDGV.Tables("FI106")
            DGV3.AutoResizeColumns()
            La筆數2.Text = "總件數：" & DGV3.RowCount

        Catch ex As Exception
            MsgBox("FI106：" & ex.Message)
        End Try

    End Sub

    Private Sub Bu存入_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu存入.Click
        If DGV3.RowCount <> 0 Then : MsgBox("已有入庫條碼請先清除") : Exit Sub : End If
        DGV資料回寫生產()
        DGV2資料整查核()

    End Sub

    Private Sub DGV資料回寫生產()
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLADD1 As String = "" : Dim SQLADD2 As String = "" : Dim DEL As String = " "
        'DEL += "DELETE FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] WHERE [FI100] = '" & DGV2.Rows(0).Cells("F1").Value & "' "

        If DGV1.RowCount > 0 Then
            For i = 0 To DGV1.RowCount - 1
                SQLADD1 += " INSERT INTO [@FI1Main] ([FI101], [FI102], [FI103], [FI104], [FI105], [FI106], [FI107], [FI108], [FI109], [FI110] ) "
                SQLADD1 += " VALUES ('" & DGV1.Rows(i).Cells("FI101").Value & "', '" & DGV1.Rows(i).Cells("FI102").Value & "', '3', '" & DGV1.Rows(i).Cells("FI104").Value & "', '" & DGV1.Rows(i).Cells("FI105").Value & "', NULL, NULL, NULL, NULL, NULL ) "
            Next
        End If

        If DGV2.RowCount > 0 Then
            For i = 0 To DGV2.RowCount - 1
                Dim FI129 As String
                FI129 = DGV2.Rows(i).Cells("F31").Value 'F31
                SQLADD2 += " INSERT INTO [@FinishItem1] ([FI101], [FI102], [FI103], [FI104], [FI105], [FI106], [FI107], [FI108], [FI109], [FI110], [FI111], [FI112], [FI113], [FI114], [FI115], [FI116], [FI117], [FI118], [FI119], [FI120], [FI121], [FI122], [FI123], [FI124], [FI125], [FI126], [FI127], [FI128], [FI129], [FI130], [FI131], [FI132], [FI133], [FI134])  "
                SQLADD2 += " VALUES ('" & DGV2.Rows(i).Cells("F2").Value & "',  '" & DGV2.Rows(i).Cells("F3").Value & "',  '1',                                       '" & DGV2.Rows(i).Cells("F5").Value & "',  '" & DGV2.Rows(i).Cells("F6").Value & "',  '" & DGV2.Rows(i).Cells("F7").Value & "',  '" & DGV2.Rows(i).Cells("F9").Value & "',  "
                SQLADD2 += "         '" & DGV2.Rows(i).Cells("F10").Value & "', '" & DGV2.Rows(i).Cells("F11").Value & "', '" & DGV2.Rows(i).Cells("F12").Value & "', '" & DGV2.Rows(i).Cells("F13").Value & "', '" & DGV2.Rows(i).Cells("F14").Value & "', '" & DGV2.Rows(i).Cells("F15").Value & "', '" & DGV2.Rows(i).Cells("F16").Value & "', "
                SQLADD2 += "         '" & DGV2.Rows(i).Cells("F17").Value & "', '" & DGV2.Rows(i).Cells("F18").Value & "', '" & DGV2.Rows(i).Cells("F19").Value & "', '" & DGV2.Rows(i).Cells("F20").Value & "', '" & DGV2.Rows(i).Cells("F21").Value & "', '" & DGV2.Rows(i).Cells("F22").Value & "', '" & DGV2.Rows(i).Cells("F23").Value & "', '" & DGV2.Rows(i).Cells("F24").Value & "', "
                SQLADD2 += "         '" & DGV2.Rows(i).Cells("F25").Value & "', '" & DGV2.Rows(i).Cells("F26").Value & "', '" & DGV2.Rows(i).Cells("F27").Value & "', '" & DGV2.Rows(i).Cells("F28").Value & "', '" & FI129 & "',                           '" & DGV2.Rows(i).Cells("F30").Value & "', '" & DGV2.Rows(i).Cells("F31").Value & "', '" & DGV2.Rows(i).Cells("F32").Value & "', "
                SQLADD2 += "         '" & DGV2.Rows(i).Cells("F33").Value & "', '" & DGV2.Rows(i).Cells("F34").Value & "', NULL, NULL ) "
            Next
        End If

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD1 : SQLCmd.CommandText += SQLADD2 : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub


    Private Sub Bu入庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu入庫.Click
        If DGV2.RowCount = 0 Then : MsgBox("無資料可作業") : Exit Sub : End If
        DGV2回傳作業(1)
        Bu入庫.Enabled = False
    End Sub

    Private Sub Bu出庫_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu出庫.Click
        If DGV2.RowCount = 0 Then : MsgBox("無資料可作業") : Exit Sub : End If
        If 出庫單號1.Text = "" Then : MsgBox("無資料可作業") : Exit Sub : End If
        DGV2回傳作業(2)
        Bu出庫.Enabled = False
    End Sub

    Private Sub DGV2回傳作業(ByVal Type As String)
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLADD As String = ""

        If Type = 1 Then
            For i = 0 To DGV2.RowCount - 1
                SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[PDA_InData] ([PDA02],[PDA03],[PDA04],[PDA05],[PDA06],[PDA08],[PDA12]) VALUES "
                SQLADD += " ('11.電宰入庫', '" & DGV2.Rows(i).Cells("F7").Value & "', 'J213', GETDATE(), '2', GETDATE(),'1') "
            Next
        End If

        If Type = 2 Then
            For i = 0 To DGV2.RowCount - 1
                If Microsoft.VisualBasic.Right(DGV2.Rows(i).Cells("F2").Value, 1) <> "C" Then
                    SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[PDA_InData] ([PDA02],[PDA03],[PDA04],[PDA05],[PDA06],[PDA08],[PDA09],[PDA10],[PDA12]) VALUES "
                    SQLADD += " ('31.銷售電宰', '" & DGV2.Rows(i).Cells("F7").Value & "', '" & 出庫單號1.Text & "', GETDATE(), '2', GETDATE(), '1','1','1') "
                Else
                    If 出庫單號2.Text <> "" Then
                        SQLADD += " INSERT INTO [KaiShingPlug].[dbo].[PDA_InData] ([PDA02],[PDA03],[PDA04],[PDA05],[PDA06],[PDA08],[PDA09],[PDA10],[PDA12]) VALUES "
                        SQLADD += " ('21.領料電宰', '" & DGV2.Rows(i).Cells("F7").Value & "', '" & 出庫單號2.Text & "', GETDATE(), '2', GETDATE(), '1','1','1') "
                    End If
                End If
            Next
        End If


        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = SQLADD : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub


End Class