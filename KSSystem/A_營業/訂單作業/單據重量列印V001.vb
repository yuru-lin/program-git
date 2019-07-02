Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions
Imports System.Net.Dns
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
'Imports Microsoft.VisualBasic.PowerPacks.Printing
Imports Microsoft.Reporting.WinForms

Public Class 單據重量列印V001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim 顯示資料 As DataSet = New DataSet

    Private Sub 單據重量列印V001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cb印表機()
        草稿.Text = ""
    End Sub

    Private Sub Cb印表機()
        Dim 預設印表機 As New PrintDocument()
        'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName
        Dim i As Integer : Dim 所有印表機 As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
            Cb1印表機.Items.Add(所有印表機)
        Next
        Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName

    End Sub

    Private Sub Bu查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu查詢.Click
        單據資料查詢()
    End Sub

    Private Sub 單據資料查詢()
        If DGV1.RowCount > 0 Then : 顯示資料.Tables("單據資料").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""

        'SQLQuery += "   SELECT DISTINCT T0.[DocEntry] AS '草稿', CONVERT(VARCHAR(10), T0.[DocDueDate], 120) AS '日期', T0.[U_Dnum] AS '提單', T0.[CardCode] AS '客編', T0.[CardName] AS '客戶', "
        'SQLQuery += "          T0.[U_COSCO] AS '好市多訂單編號' "
        'SQLQuery += "     FROM [ODRF] T0 LEFT JOIN [DRF1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
        'SQLQuery += "    WHERE T0.[ObjType] = '15' AND T1.[WhsCode] NOT IN ('K05','S05','O01','R01','R02','R03','R04','R05','R06') " ' AND T0.[CardName] LIKE '%好市多%' AND T0.[DocStatus] = 'O' "
        'SQLQuery += " ORDER BY T0.[U_Dnum] DESC "
        SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_單據明細重量01v] N'1',N'2',N'' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "單據資料") : DGV1.DataSource = 顯示資料.Tables("單據資料") : DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("單據資料異常：" & ex.Message)
        End Try
    End Sub

    Private Sub DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount <= 0 Then : Exit Sub : End If
        草稿.Text = DGV1.CurrentRow.Cells("草稿").Value
        Lt客戶.Text = DGV1.CurrentRow.Cells("客戶").Value
        Lt編號.Text = DGV1.CurrentRow.Cells("好市多訂單編號").Value
        Lt日期.Text = DGV1.CurrentRow.Cells("日期").Value
    End Sub

    Private Sub 草稿_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 草稿.TextChanged
        If 草稿.Text = "" Then : Exit Sub : End If
        單據明細查詢2()
        單據明細查詢()
        查詢單據非單據品項()
        DGV3異常檢查()
        MsgBox("查詢完成")
    End Sub

    Private Sub 單據明細查詢2()
        If 草稿.Text = "" Then : Exit Sub : End If
        If DGV3.RowCount > 0 Then : 顯示資料.Tables("單據內容").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = ""

        SQLQuery = " IF (OBJECT_ID('tempdb..#條碼數量Tmp')  IS NOT NULL)  DROP TABLE #條碼數量Tmp"
        SQLQuery += " CREATE TABLE #條碼數量Tmp ( "
        SQLQuery += " [順序] INT,[管理] NVARCHAR(2),[存編] NVARCHAR(20),[品名] NVARCHAR(50),[條碼] NVARCHAR(20),[儲位] NVARCHAR(15),[數量] NUMERIC(20,6),[製造單號] NVARCHAR(20),[重量]NUMERIC(20,2), "
        SQLQuery += " [生產日期] DATE,[有效日期] DATE,[庫位] NVARCHAR(8),[G1] NVARCHAR(20),[G2] NVARCHAR(20),[G_OK] NVARCHAR(20),[NO2] NVARCHAR(20)) "
        SQLQuery += " INSERT INTO #條碼數量Tmp EXEC [KaiShingPlug].[dbo].[預_單據明細重量01v] N'2',N'2',N'" & 草稿.Text & "' " & vbCrLf

        SQLQuery += " EXEC [KaiShingPlug].[dbo].[預_單據明細重量01v] N'4',N'',N'" & 草稿.Text & "' "

        'SQLQuery += "   SELECT S1.[ItemCode] AS '存編', S1.[Dscription] AS '品名', dbo.getRoundN(S1.[Quantity],4) AS '預出數量' ,dbo.getRoundN(S3.[數量],4) AS '數量',dbo.getRoundN(S3.[重量],2) AS '重量' "
        'SQLQuery += "     FROM [DRF1] S1 LEFT JOIN [OITM] S2 ON S1.[ItemCode] = S2.[ItemCode] "
        'SQLQuery += "                    LEFT JOIN (SELECT [存編],[品名],SUM([數量]) AS '數量',SUM([重量]) AS '重量' FROM #xxx  GROUP BY [存編],[品名]) S3 ON S1.[ItemCode] collate Chinese_PRC_CI_AS = S3.[存編] "
        'SQLQuery += "    WHERE S1.[DocEntry] = '481107' "
        'SQLQuery += " ORDER BY S1.[ItemCode] "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "單據內容") : DGV3.DataSource = 顯示資料.Tables("單據內容") : DGV3.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("單據內容異常：" & ex.Message)
        End Try
    End Sub

    Private Sub 單據明細查詢()
        If 草稿.Text = "" Then : Exit Sub : End If
        If DGV2.RowCount > 0 Then : 顯示資料.Tables("單據明細").Clear() : End If '清除DGV1資料
        Dim SQLQuery As String = "" : Dim SQLQuery2 As String = ""

        SQLQuery = " EXEC [KaiShingPlug].[dbo].[預_單據明細重量01v] N'3',N'',N'' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "單據明細") : DGV2.DataSource = 顯示資料.Tables("單據明細") : DGV2.AutoResizeColumns()

        Catch ex As Exception
            MsgBox("單據明細異常：" & ex.Message)
        End Try
    End Sub

    Private Sub 查詢單據非單據品項()
        If DGV4.RowCount > 0 Then : 顯示資料.Tables("T2DGV3").Clear() : End If '清除T2DGV3資料
        Dim SQLQuery As String = ""

        'SQLQuery = "  SELECT A.[存編], B.[品名], B.[數量]"
        'SQLQuery += " FROM( SELECT DISTINCT T0.[ItemCode] COLLATE Chinese_PRC_CI_AS AS '存編' FROM [DRF1] WHERE  T0 EXCEPT SELECT DISTINCT T0.[存編] COLLATE Chinese_PRC_CI_AS FROM [#條碼數量Tmp] T0) A INNER JOIN "
        'SQLQuery += "     ( SELECT T0.[存編], T0.[品名], SUM(T0.[數量]) AS '數量' FROM [#條碼數量Tmp] T0 GROUP BY T0.[存編], T0.[品名]   ) B ON A.[存編] COLLATE Chinese_PRC_CI_AS = B.[存編] COLLATE Chinese_PRC_CI_AS "
        SQLQuery += " EXEC [KaiShingPlug].[dbo].[預_單據明細重量01v] N'5',N'',N'" & 草稿.Text & "' "

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand
        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.CommandTimeout = 100000
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(顯示資料, "T2DGV3") : DGV4.DataSource = 顯示資料.Tables("T2DGV3") : DGV4.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV3_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGV3.Sorted, DGV4.Sorted
        DGV3異常檢查()
    End Sub

    Private Sub DGV3異常檢查()
        Dim Cnt0 As Integer = 0 ': Cnt4 = 0 : Cnt5 = 0 : Cnt6 = 0
        For i As Integer = 0 To DGV3.RowCount - 1   '以黃底顯示
            'If DGV3.Rows(i).Cells("預出數量").Value <> DGV3.Rows(i).Cells("數量").Value Then
            If DGV3.Rows(i).Cells("差異數量").Value <> 0 Then
                DGV3.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                Cnt0 += 0 + 1
            End If
        Next

        DGV3.ClearSelection()

        差異.Text = "差異:" & Cnt0 & " 筆及非單據品項:" & DGV4.RowCount & " 筆"

        If Cnt0 + DGV4.RowCount = 0 Then
            Bu列印.Enabled = True
        Else
            Bu列印.Enabled = False
        End If

    End Sub


    Private Sub Bu列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bu列印.Click
        Bu列印作業()
    End Sub

    Private Sub Bu列印作業()
        Dim printDoc As New PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        If 顯示資料.Tables("單據明細").Rows.Count > 0 Then

            Dim newRpt As 列印Print = New 列印Print
            newRpt.strPara(0) = Lt客戶.Text
            newRpt.strPara(1) = Lt編號.Text
            newRpt.strPara(2) = Lt日期.Text
            'newRpt.strPara(3) = Lt發票號碼.Text
            'newRpt.strPara(4) = Lt責任單位.Text
            'newRpt.strPara(5) = Lt過帳日期.Text
            'newRpt.strPara(6) = Lt聯絡人.Text
            'newRpt.strPara(7) = Lt電話.Text
            'newRpt.strPara(8) = Lt傳真.Text
            'newRpt.strPara(9) = Lt文件單號.Text & " - " & TB單號.Text
            'Dim strPara9 As String = ""
            'Select Case Lt類別.Text
            '    Case "折讓"
            '        strPara9 = "■折讓 □退貨 "
            '    Case "退貨"
            '        strPara9 = "□折讓 ■退貨 "
            'End Select
            'newRpt.strPara(10) = strPara9
            'newRpt.strPara(11) = Lt備註1.Text & vbCrLf & Lt退貨原因.Text & vbCrLf & Lt備註2.Text
            'Dim strPara12 As String = ""
            ''strPara12 = "稅額 " & CStr(StrDup(10 - Len(CStr(Lt稅額.Text)), " ")) & CStr(Lt稅額.Text) & " NTD" & vbCrLf
            ''strPara12 += "總計 " & CStr(StrDup(10 - Len(CStr(Lt總計.Text)), " ")) & CStr(Lt總計.Text) & " NTD"
            'strPara12 = CStr(Lt稅額.Text) & " NTD" & vbCrLf & CStr(Lt總計.Text) & " NTD"
            'newRpt.strPara(12) = strPara12
            'newRpt.strPara(13) = "製表：" & Lt輸入者.Text & vbCrLf & Format(Now(), "yyyy-MM-dd hh:mm")
            'newRpt.strPara(14) = Lt處理方式.Text
            'newRpt.strPara(15) = Lt運輸司機.Text

            'newRpt.strPara(0) = 主要介面.TS公司.Text
            'newRpt.strPara(1) = "單位：" & La部門.Text
            'newRpt.strPara(2) = "資料期間：" & Format(開始Date.Value, "yyyy-MM-dd") & Format(結束Date.Value, "yyyy-MM-dd")
            'newRpt.strPara(3) = "製表日期：" & Format(Now(), "yyyy-MM-dd")
            'newRpt.strPara(4) = "製表：" & 員工姓名

            newRpt.StartupPath = "\A_營業\訂單作業\單據重量列印.rdlc"
            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("退貨單之報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            newRpt.高 = "14cm"
            newRpt.dt = 顯示資料.Tables("單據明細")
            'newRpt.printerName = printDoc.PrinterSettings.PrinterName
            newRpt.printerName = Cb1印表機.Text
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("單據貨明細!", MsgBoxStyle.OkOnly, "單據明細")
        End If
    End Sub


End Class