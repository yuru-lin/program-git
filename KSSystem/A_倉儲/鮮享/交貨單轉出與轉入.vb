Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 交貨單轉出與轉入
    Dim red As Integer = 0
    Dim red2 As Integer = 0
    'Dim OldName, NewName As String  '更名使用_20140303_Phil
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 交貨單轉出與轉入_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
        Cb選擇.SelectedIndex = 0
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtNum.Text = "" Then : Exit Sub : End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        Dim FI107s As String = "" : Dim DocTypes As String = ""
        Select Case Cb選擇.Text
            Case "銷售" : DocTypes = "15" : FI107s = "'21'+SUBSTRING(T0.[FI107],3,13)+'K'"
            Case "代工" : DocTypes = "60" : FI107s = "'31'+SUBSTRING(T0.[FI107],3,13)"
        End Select

        sql = "  DECLARE @DocNum varchar(20) "
        sql += " SET NOCOUNT ON "
        sql += " SET @DocNum = '" & txtNum.Text & "'"
        sql += " SELECT  T1.[DocNum] AS 'FI100', T0.[FI101], T0.[FI102], '1' AS 'FI103', T0.[FI104], ISNULL(CAST(T0.[FI105] AS varchar(20)),'') AS 'FI105' , T0.[FI106], T0.[FI107], "
        'sql += "        '21'+SUBSTRING(T0.[FI107],3,13)+'K' AS 'FI107K', T0.[FI108], ISNULL(CAST(T0.[FI109] AS varchar(20)),'') AS 'FI109', ISNULL(CAST(T0.[FI110] AS varchar(20)),'') AS 'FI110', "
        sql += "        " & FI107s & " AS 'FI107K', T0.[FI108], ISNULL(CAST(T0.[FI109] AS varchar(20)),'') AS 'FI109', ISNULL(CAST(T0.[FI110] AS varchar(20)),'') AS 'FI110', "
        sql += "         ISNULL(CAST(T0.[FI111] AS varchar(20)),'') AS 'FI111', T0.[FI112], T0.[FI113], T0.[FI114], T0.[FI115], T0.[FI116], T0.[FI117], T0.[FI118], T0.[FI119], T0.[FI120], "
        sql += "         T0.[FI121], T0.[FI122], T0.[FI123], '' AS 'FI124', T0.[FI125], T0.[FI126], T0.[FI127], T0.[FI128], ISNULL(CAST(CAST(T0.[FI129] AS DATE) AS varchar(20)),'') AS 'FI129', T0.[FI130], "
        sql += "         T0.[FI131], T0.[FI132] "
        sql += "   FROM [@FinishItem1] T0 INNER JOIN "
        sql += "   (SELECT T0.[DocNum],T0.[ItemCode],T2.[DistNumber] "
        sql += "      FROM [OITL] T0 INNER JOIN [ITL1] T1 ON T0.[LogEntry]  = T1.[LogEntry]  AND T0.[ItemCode] = T1.[ItemCode] "
        sql += "                     INNER JOIN [OSRN] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[ItemCode] = T2.[ItemCode] "
        sql += "     WHERE T0.[DocType] = '" & DocTypes & "' AND T0.[DocNum] = @DocNum "
        sql += "   ) T1 ON  T0.[FI107] = T1.[ItemCode] AND T0.[FI106] = T1.[DistNumber] "
        sql += "  WHERE T0.[FI106] IN (SELECT T2.[DistNumber] "
        sql += "                      FROM [OITL] T0 INNER JOIN [ITL1] T1 ON T0.[LogEntry]  = T1.[LogEntry]  AND T0.[ItemCode] = T1.[ItemCode] "
        sql += "                                     INNER JOIN [OSRN] T2 ON T1.[SysNumber] = T2.[SysNumber] AND T1.[ItemCode] = T2.[ItemCode] "
        sql += "                     WHERE T0.[DocType] = '" & DocTypes & "' AND T0.[DocNum] = @DocNum ) "
        sql += " AND T1.[DocNum] = @DocNum "

        'MsgBox(sql)

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")

        DGV1.AutoResizeColumns()
        Label4.Text = DGV1.RowCount
        'SyncToDB.Enabled = True
        ToExcelBtn.Enabled = True
        CloseSearch()
    End Sub

    Private Sub ToExcelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn.Click
        DataToExcel(DGV1, "")
        btnReSearch.PerformClick()
    End Sub

    Private Sub btnReadExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadExcel.Click
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        SyncToDB.Enabled = False
        Dim openfile As New OpenFileDialog()

        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"
        openfile.Filter = "Excel files(*.xls)|*.xls"        '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        Dim strSQL As String = "SELECT * FROM [Sheet1$] "
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open()
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)

        DGV1.DataSource = dTable
        DGV1.Rows.Remove(DGV1.Rows(0))
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()
        setdgvDisplay()
        CloseSearch()

        SyncToDB.Enabled = True
        ''20140303_Phil
        'OldName = openfile.FileName
        ''NewName = Format(Replace(openfile.FileName, openfile.SafeFileName, "") & "備份\入庫\" & Replace(openfile.SafeFileName, ".xls", "") & Format(Now(), "yyyyMMdd-hhmmssfff") & ".xls", "")
        'NewName = Format(Environ("HOMEPATH") & "\Desktop\備份\入庫\" & Replace(openfile.SafeFileName, ".xls", "") & Format(Now(), "yyyyMMdd-hhmmssfff") & ".xls", "")

    End Sub

    Private Sub CloseSearch()
        txtNum.Enabled = False
        btnSearch.Enabled = False
        btnReSearch.Enabled = True
        btnReadExcel.Enabled = False
    End Sub

    Private Sub setdgvDisplay()

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "F1"
                    column.HeaderText = "FI100"
                Case "F2"
                    column.HeaderText = "FI101"
                Case "F3"
                    column.HeaderText = "FI102"
                Case "F4"
                    column.HeaderText = "FI103"
                Case "F5"
                    column.HeaderText = "FI104"
                Case "F6"
                    column.HeaderText = "FI105"
                Case "F7"
                    column.HeaderText = "FI106"
                Case "F8"
                    column.HeaderText = "FI107"
                Case "F9"
                    column.HeaderText = "FI107K"
                Case "F10"
                    column.HeaderText = "FI108"
                Case "F11"
                    column.HeaderText = "FI109"
                Case "F12"
                    column.HeaderText = "FI110"
                Case "F13"
                    column.HeaderText = "FI111"
                Case "F14"
                    column.HeaderText = "FI112"
                Case "F15"
                    column.HeaderText = "FI113"
                Case "F16"
                    column.HeaderText = "FI114"
                Case "F17"
                    column.HeaderText = "FI115"
                Case "F18"
                    column.HeaderText = "FI116"
                Case "F19"
                    column.HeaderText = "FI117"
                Case "F20"
                    column.HeaderText = "FI118"
                Case "F21"
                    column.HeaderText = "FI119"
                Case "F22"
                    column.HeaderText = "FI120"
                Case "F23"
                    column.HeaderText = "FI121"
                Case "F24"
                    column.HeaderText = "FI122"
                Case "F25"
                    column.HeaderText = "FI123"
                Case "F26"
                    column.HeaderText = "FI124"
                Case "F27"
                    column.HeaderText = "FI125"
                Case "F28"
                    column.HeaderText = "FI126"
                Case "F29"
                    column.HeaderText = "FI127"
                Case "F30"
                    column.HeaderText = "FI128"
                Case "F31"
                    column.HeaderText = "FI129"
                Case "F32"
                    column.HeaderText = "FI130"
                Case "F33"
                    column.HeaderText = "FI131"
                Case "F34"
                    column.HeaderText = "FI132"
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()
        Label4.Text = DGV1.RowCount
    End Sub

    Private Sub SyncToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncToDB.Click
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Dim DEL As String = " "
        DEL += "DELETE FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] WHERE [FI100] = '" & DGV1.Rows(0).Cells("F1").Value & "' "
        If DGV1.RowCount > 0 Then
            For i = 0 To DGV1.RowCount - 1
                Dim FI129 As String
                'FI105 = DGV1.Rows(i).Cells("FI105").Value'F6
                'FI109 = DGV1.Rows(i).Cells("FI109").Value'F11
                'FI110 = DGV1.Rows(i).Cells("FI110").Value'F12
                'FI111 = DGV1.Rows(i).Cells("FI111").Value'F13
                FI129 = DGV1.Rows(i).Cells("F31").Value 'F31
                sql += " INSERT INTO [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] ([FI100], [FI101], [FI102], [FI103], [FI104], [FI105], [FI106], [FI107], [FI107K], [FI108], [FI109], [FI110], [FI111], [FI112], [FI113], [FI114], [FI115], [FI116], [FI117], [FI118], [FI119], [FI120], [FI121], [FI122], [FI123], [FI124], [FI125], [FI126], [FI127], [FI128], [FI129], [FI130], [FI131], [FI132])  "
                'sql += " VALUES ('" & DGV1.Rows(i).Cells("FI100").Value & "', '" & DGV1.Rows(i).Cells("FI101").Value & "', '" & DGV1.Rows(i).Cells("FI102").Value & "', '" & DGV1.Rows(i).Cells("FI103").Value & "', '" & DGV1.Rows(i).Cells("FI104").Value & "', '" & FI105 & "', '" & DGV1.Rows(i).Cells("FI106").Value & "', '" & DGV1.Rows(i).Cells("FI107").Value & "', "
                'sql += " '" & DGV1.Rows(i).Cells("FI107K").Value & "', '" & DGV1.Rows(i).Cells("FI108").Value & "', '" & FI109 & "', '" & FI110 & "', '" & FI111 & "', '" & DGV1.Rows(i).Cells("FI112").Value & "', '" & DGV1.Rows(i).Cells("FI113").Value & "', '" & DGV1.Rows(i).Cells("FI114").Value & "', "
                'sql += " '" & DGV1.Rows(i).Cells("FI115").Value & "', '" & DGV1.Rows(i).Cells("FI116").Value & "', '" & DGV1.Rows(i).Cells("FI117").Value & "', '" & DGV1.Rows(i).Cells("FI118").Value & "', '" & DGV1.Rows(i).Cells("FI119").Value & "', '" & DGV1.Rows(i).Cells("FI120").Value & "', '" & DGV1.Rows(i).Cells("FI121").Value & "', '" & DGV1.Rows(i).Cells("FI122").Value & "', "
                'sql += " '" & DGV1.Rows(i).Cells("FI123").Value & "', '" & DGV1.Rows(i).Cells("FI124").Value & "', '" & DGV1.Rows(i).Cells("FI125").Value & "', '" & DGV1.Rows(i).Cells("FI126").Value & "', '" & DGV1.Rows(i).Cells("FI127").Value & "', '" & DGV1.Rows(i).Cells("FI128").Value & "', '" & FI129 & "', '" & DGV1.Rows(i).Cells("FI130").Value & "', "
                'sql += " '" & DGV1.Rows(i).Cells("FI131").Value & "', '" & DGV1.Rows(i).Cells("FI132").Value & "' ) "
                sql += " VALUES ('" & DGV1.Rows(i).Cells("F1").Value & "', '" & DGV1.Rows(i).Cells("F2").Value & "', '" & DGV1.Rows(i).Cells("F3").Value & "', '" & DGV1.Rows(i).Cells("F4").Value & "', '" & DGV1.Rows(i).Cells("F5").Value & "', '" & DGV1.Rows(i).Cells("F6").Value & "', '" & DGV1.Rows(i).Cells("F7").Value & "', '" & DGV1.Rows(i).Cells("F8").Value & "', "
                sql += " '" & DGV1.Rows(i).Cells("F9").Value & "', '" & DGV1.Rows(i).Cells("F10").Value & "', '" & DGV1.Rows(i).Cells("F11").Value & "', '" & DGV1.Rows(i).Cells("F12").Value & "', '" & DGV1.Rows(i).Cells("F13").Value & "', '" & DGV1.Rows(i).Cells("F14").Value & "', '" & DGV1.Rows(i).Cells("F15").Value & "', '" & DGV1.Rows(i).Cells("F16").Value & "', "
                sql += " '" & DGV1.Rows(i).Cells("F17").Value & "', '" & DGV1.Rows(i).Cells("F18").Value & "', '" & DGV1.Rows(i).Cells("F19").Value & "', '" & DGV1.Rows(i).Cells("F20").Value & "', '" & DGV1.Rows(i).Cells("F21").Value & "', '" & DGV1.Rows(i).Cells("F22").Value & "', '" & DGV1.Rows(i).Cells("F23").Value & "', '" & DGV1.Rows(i).Cells("F24").Value & "', "
                sql += " '" & DGV1.Rows(i).Cells("F25").Value & "', '" & DGV1.Rows(i).Cells("F26").Value & "', '" & DGV1.Rows(i).Cells("F27").Value & "', '" & DGV1.Rows(i).Cells("F28").Value & "', '" & FI129 & "', '" & DGV1.Rows(i).Cells("F30").Value & "', '" & DGV1.Rows(i).Cells("F31").Value & "', '" & DGV1.Rows(i).Cells("F32").Value & "', "
                sql += " '" & DGV1.Rows(i).Cells("F33").Value & "', '" & DGV1.Rows(i).Cells("F34").Value & "' ) "
            Next
        End If

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = DEL : SQLCmd.CommandText += sql : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        MsgBox("資料庫同步成功!")
        'btnReSearch.PerformClick()
        Me.Close()

    End Sub

    Private Sub btnReSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReSearch.Click
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        txtNum.Enabled = True
        btnSearch.Enabled = True
        ToExcelBtn.Enabled = False
        btnReSearch.Enabled = False
        SyncToDB.Enabled = False
        btnReadExcel.Enabled = True
    End Sub
End Class