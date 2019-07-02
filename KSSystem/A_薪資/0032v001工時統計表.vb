Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Dns
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.PowerPacks.Printing
Imports Microsoft.Reporting.WinForms

Public Class 工時統計表v001
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim dt1 As DataTable = New DataTable
    Dim 下拉明細 As DataSet = New DataSet
    Dim 統計代碼 As String = ""
    Dim 部門代碼1 As String = ""
    Dim 部門代碼2 As String = ""
    Dim 明細日期開始 As String = ""
    Dim 明細日期結束 As String = ""
    Dim 統計日期開始 As String = ""
    Dim 統計日期結束 As String = ""
    Dim 公司ALL As String = "ALL"
    Dim 部門代碼x As String = ""


    Private Sub 工時統計表v001_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        載入部門_初始化() : Cb印表機()
        If MainMenuList.UserName.Text Then

        End If


        Select Case MainMenuList.UserName.Text
            Case "1122"
                部門代碼x = "UE00,UE01,UE03"
            Case "1123"
                部門代碼x = "UE00,UE01,UE02,UE03,UE05"
        End Select



    End Sub

    Private Sub 載入部門_初始化()
        If 下拉明細.Tables.Contains("部門") Then : 下拉明細.Tables("部門").Clear() : End If

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand : SQLCmd.Connection = DBConn
        Dim SQLQuery As String = ""
        SQLQuery = "  SELECT '全部' AS '名稱', 'ALL' AS '代碼','ALL' AS '單位'"
        SQLQuery += " UNION ALL"
        SQLQuery += " SELECT [名稱],[代碼],[單位] FROM [Payroll].[dbo].[檢_部門單位] "

        Try
            SQLCmd.CommandText = SQLQuery : SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(下拉明細, "部門")

            If 下拉明細.Tables("部門").Rows.Count > 0 Then
                cb統計部門.DataSource = 下拉明細.Tables("部門") : cb統計部門.DisplayMember = "名稱" : cb統計部門.SelectedIndex = 0
                cb明細部門.DataSource = 下拉明細.Tables("部門") : cb明細部門.DisplayMember = "名稱" : cb明細部門.SelectedIndex = 0
            Else
                cb統計部門.Text = "" : cb明細部門.Text = "" : MsgBox("無部門資料")
            End If
        Catch ex As Exception
            MsgBox("載入部門: " & ex.Message) : Exit Sub
        End Try
    End Sub

    Public Sub 選擇部門()
        If cb統計部門.SelectedIndex <> -1 Then
            Dim dt As DataTable = 下拉明細.Tables("部門")
            Dim oCriteria1 As String = "[名稱] = '" & UCase(cb統計部門.Text) & "'"
            Dim oCriteria2 As String = "[名稱] = '" & UCase(cb明細部門.Text) & "'"
            Dim foundRow1() As DataRow
            Dim foundRow2() As DataRow

            foundRow1 = dt.Select(oCriteria1)
            foundRow2 = dt.Select(oCriteria2)
            If foundRow1.Length > 0 Then
                部門代碼1 = foundRow1(0)("代碼")
                'MsgBox(部門代碼1)
            End If
            If foundRow2.Length > 0 Then
                部門代碼2 = foundRow2(0)("代碼")
                'MsgBox(部門代碼2)
            End If : End If

    End Sub

    Private Sub btn統計查尋_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn統計查尋.Click
        If DGV統計.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV1").Clear() : End If
        Dim sql As String = ""
        Dim Type As String
        Type = "1"
        If rb日結.Checked = True Then
            統計代碼 = "1"
        ElseIf rb月結.Checked = True Then
            統計代碼 = "2"
        End If
        '選擇部門()
        統計日期開始 = Format(dt統計日期1.Value.Date, "yyyy-MM-dd")
        統計日期結束 = Format(dt統計日期2.Value.Date, "yyyy-MM-dd")
        'Dim 公司ALL As String = ""
        'If All公司.Checked = True Then
        '    公司ALL = "ALL"
        'Else
        '    公司ALL = 公司名稱
        'End If

        sql = "     EXEC [Payroll].[dbo].[預_工時統計]  N'" & Type & "',N'" & 統計代碼 & "',N'" & 統計日期開始 & "',N'" & 統計日期結束 & "',N'" & 部門代碼x & "',N'" & 公司ALL & "'  "
        'MsgBox(sql)

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = sql : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV統計.DataSource = ks1DataSetDGV.Tables("DGV1")
        Catch ex As Exception
            MsgBox("工時統計查尋錯誤: " & ex.Message)
            Exit Sub
        End Try

        DGV統計.AutoResizeColumns()

        For Each column As DataGridViewColumn In DGV統計.Columns
            column.Visible = True
            Select Case column.Name
                Case "公司代碼" : column.DisplayIndex = 0
                Case "部門" : column.DisplayIndex = 1
                Case "日期" : column.DisplayIndex = 2
                Case "上班人數" : column.DisplayIndex = 3
                Case "加班人數" : column.DisplayIndex = 4
                Case "平日加班總時數" : column.DisplayIndex = 5
                Case "假日加班總時數" : column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub btn明細查尋_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn明細查尋.Click
        If DGV明細.RowCount > 0 Then : ks1DataSetDGV.Tables("DGV2").Clear() : End If
        Dim sql As String = ""
        Dim Type As String
        Type = "2"
        '選擇部門()
        明細日期開始 = Format(dt明細日期1.Value.Date, "yyyy-MM-dd")
        明細日期結束 = Format(dt明細日期2.Value.Date, "yyyy-MM-dd")
        'Dim 部門代碼x As String = ""
        '部門代碼x = "UE01,UE03,UE00"

        sql = "     EXEC [Payroll].[dbo].[預_工時統計] '" & Type & "','','" & 明細日期開始 & "','" & 明細日期結束 & "','" & 部門代碼x & "','" & 公司ALL & "'"

        Dim DBConn As SqlConnection = Login.DBConn : Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = sql : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV2")
            DGV明細.DataSource = ks1DataSetDGV.Tables("DGV2")
        Catch ex As Exception
            MsgBox("加班明細查尋錯誤: " & ex.Message)
            Exit Sub
        End Try

        DGV明細.AutoResizeColumns()

        For Each column As DataGridViewColumn In DGV明細.Columns
            column.Visible = True
            Select Case column.Name
                Case "公司代碼" : column.DisplayIndex = 0
                Case "部門" : column.DisplayIndex = 1
                Case "職位" : column.DisplayIndex = 2
                Case "日期" : column.DisplayIndex = 3
                Case "員工編號" : column.DisplayIndex = 4
                Case "員工姓名" : column.DisplayIndex = 5
                Case "上班時間" : column.DisplayIndex = 6
                Case "上班刷卡" : column.DisplayIndex = 7
                Case "下班時間" : column.DisplayIndex = 8
                Case "下班刷卡" : column.DisplayIndex = 9
                Case "平日加班總時數" : column.DisplayIndex = 10
                Case "假日加班總時數" : column.DisplayIndex = 11
                Case "請假時數" : column.DisplayIndex = 12
                Case Else
                    column.Visible = False
            End Select
        Next

    End Sub

    Private Sub btn統計匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn統計匯出Excel.Click
        If DGV統計.RowCount > 0 Then
            DataToExcel(DGV統計, "工時統計-" & 公司ALL)
        Else
            MsgBox("無工時統計資料!", MsgBoxStyle.OkOnly, "工時統計") : Exit Sub : End If
    End Sub

    Private Sub btn明細匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn明細匯出Excel.Click
        If DGV明細.RowCount > 0 Then
            DataToExcel(DGV明細, "加班明細-" & 公司ALL)
        Else
            MsgBox("無加班明細資料!", MsgBoxStyle.OkOnly, "加班明細") : Exit Sub : End If
    End Sub

    Private Sub Cb印表機()
        Dim 預設印表機 As New PrintDocument()
        'Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName
        Dim i As Integer : Dim 所有印表機 As String
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            所有印表機 = PrinterSettings.InstalledPrinters.Item(i)
            Cb1印表機.Items.Add(所有印表機)
            Cb2印表機.Items.Add(所有印表機)
        Next
        Cb1印表機.Text = 預設印表機.PrinterSettings.PrinterName
        Cb2印表機.Text = 預設印表機.PrinterSettings.PrinterName
    End Sub

    Private Sub btn統計列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn統計列印.Click
        Dim printDoc As New PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        If DGV統計.RowCount > 0 Then
            Dim newRpt As 計薪Print = New 計薪Print
            'newRpt.strPara(0) = 主要介面.TS公司.Text
            newRpt.strPara(0) = "ALL"
            newRpt.strPara(1) = "工時統計表-部門工時統計 "
            newRpt.strPara(2) = 統計日期開始 & " 至 " & 統計日期結束
            newRpt.strPara(3) = ""
            newRpt.strPara(4) = ""

            newRpt.TYPE = "1" 'A4直式列印

            newRpt.StartupPath = "\1.人事作業\出勤管理\加班管理\0032v001工時統計表-統計.rdlc"

            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("工時統計表-統計之報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            newRpt.dt = ks1DataSetDGV.Tables("DGV1")
            newRpt.printerName = Cb1印表機.Text
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無工時統計資料!", MsgBoxStyle.OkOnly, "工時統計") : Exit Sub : End If
    End Sub

    Private Sub btn明細列印_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn明細列印.Click
        Dim printDoc As New PrintDocument()
        Dim sDefaultPrinter As String = printDoc.PrinterSettings.PrinterName

        If DGV明細.RowCount > 0 Then
            Dim newRpt As 計薪Print = New 計薪Print
            'newRpt.strPara(0) = 主要介面.TS公司.Text
            newRpt.strPara(0) = "ALL"
            newRpt.strPara(1) = "工時統計表-部門加班明細 "
            newRpt.strPara(2) = 明細日期開始 & " 至 " & 明細日期結束
            newRpt.strPara(3) = ""
            newRpt.strPara(4) = ""

            newRpt.TYPE = "2" 'A4橫式列印

            newRpt.StartupPath = "\1.人事作業\出勤管理\加班管理\0032v001工時統計表-明細.rdlc"

            If Not IO.File.Exists(Application.StartupPath & newRpt.StartupPath) Then : MsgBox("工時統計表-明細之報表格式檔不存在, 無法列印!", MsgBoxStyle.OkOnly, "檔案錯誤") : Exit Sub : End If

            newRpt.dt = ks1DataSetDGV.Tables("DGV2")
            newRpt.printerName = Cb2印表機.Text
            newRpt.Run()
            newRpt.Dispose()
        Else
            MsgBox("無加班明細資料!", MsgBoxStyle.OkOnly, "加班明細") : Exit Sub : End If
    End Sub
End Class