Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class v001健檢數據資料

    Dim dTable As DataTable = New DataTable()

    Private Sub v001健檢數據資料_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1

    End Sub

    Private Sub 讀取Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 讀取Excel.Click

        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "%HOMEPATH%\Desktop\"
        openfile.Filter = "Excel files(*.xls)|*.xls"
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & " ;Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        Dim strSQL As String
        strSQL = "  SELECT '' AS 年度代碼, F7 AS 姓名, F9 AS 員工編號, 'X001' AS 部門代號, F2 AS 部門名稱, F8 AS 性別, F10 AS 出生年月日, F15 AS 身高_cm, F16 AS 體重_kg, F18 AS 腰圍_cm, F19 AS 收縮壓, "
        strSQL += "        F20 AS 舒張壓, F65 AS 飯前血醣, F81 AS 總膽固醇, F80 AS 三酸甘油脂, F82 AS 高密度膽固醇, F83 AS 低密度膽固醇, '無' AS 抽菸習慣, F29 AS 既往病歷, '' AS 健檢過程備註說明 "
        strSQL += " FROM [Sheet1$] "
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)


        dataAdapter.Fill(dTable)

        DGV1.DataSource = dTable

        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()

        UpdateDGV1()

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click

        DataToExcel(DGV1, "New01_工作過負荷評估")

    End Sub

    Private Sub UpdateDGV1()

        For i = 0 To DGV1.RowCount - 1
            If DGV1.Rows(i).Cells("年度代碼").Value = "" Then
                DGV1.Rows(i).Cells("年度代碼").Value = Format(Now(), "yyyy") & "一般健檢"
            End If

            If DGV1.Rows(i).Cells("員工編號").Value.ToString = "" Then
                DGV1.Rows(i).Cells("員工編號").Value = "00000000"
            End If

            If DGV1.Rows(i).Cells("出生年月日").Value <> "" And DGV1.Rows(i).Cells("出生年月日").Value <> "生日" Then
                DGV1.Rows(i).Cells("出生年月日").Value = Mid(DGV1.Rows(i).Cells("出生年月日").Value, 1, 2) + 1911 & Mid(DGV1.Rows(i).Cells("出生年月日").Value, 3, 8)
            Else
                DGV1.Rows(i).Cells("出生年月日").Value = "0"
            End If

            If DGV1.Rows(i).Cells("身高_cm").Value.ToString = "" Then
                DGV1.Rows(i).Cells("身高_cm").Value = "0"
            End If

            If DGV1.Rows(i).Cells("體重_kg").Value.ToString = "" Then
                DGV1.Rows(i).Cells("體重_kg").Value = "0"
            End If

            If DGV1.Rows(i).Cells("腰圍_cm").Value.ToString = "" Then
                DGV1.Rows(i).Cells("腰圍_cm").Value = "0"
            End If

            If DGV1.Rows(i).Cells("收縮壓").Value.ToString = "" Then
                DGV1.Rows(i).Cells("收縮壓").Value = "0"
            End If

            If DGV1.Rows(i).Cells("舒張壓").Value.ToString = "" Then
                DGV1.Rows(i).Cells("舒張壓").Value = "0"
            End If

            If DGV1.Rows(i).Cells("飯前血醣").Value.ToString = "" Then
                DGV1.Rows(i).Cells("飯前血醣").Value = "0"
            End If

            If DGV1.Rows(i).Cells("總膽固醇").Value.ToString = "" Then
                DGV1.Rows(i).Cells("總膽固醇").Value = "0"
            End If

            If DGV1.Rows(i).Cells("三酸甘油脂").Value.ToString = "" Then
                DGV1.Rows(i).Cells("三酸甘油脂").Value = "0"
            End If

            If DGV1.Rows(i).Cells("高密度膽固醇").Value.ToString = "" Then
                DGV1.Rows(i).Cells("高密度膽固醇").Value = "0"
            End If

            If DGV1.Rows(i).Cells("低密度膽固醇").Value.ToString = "" Then
                DGV1.Rows(i).Cells("低密度膽固醇").Value = "0"
            End If

            If DGV1.Rows(i).Cells("既往病歷").Value.ToString = "" Then
                DGV1.Rows(i).Cells("既往病歷").Value = "無明顯異常"
            End If
        Next

    End Sub
End Class