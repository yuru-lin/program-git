Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class C_SyncOutByExcel
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim ks2DataSet As DataSet = New DataSet
    Dim dsPDAIn As New DataTable
    Dim SSS As String


    Private Sub C_SyncOutByExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSourceMain.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView3.ContextMenuStrip = MainForm.ContextMenuStrip1
        DataGridView4.ContextMenuStrip = MainForm.ContextMenuStrip1
        AddColumn()

        Label9.Text = "共  " + Format(dgvSourceMain.RowCount, "") + "  項"

        'If System.Net.Dns.GetHostName() = "MIS-03" Or System.Net.Dns.GetHostName() = "KS-F5" Then
        '    SSS = "11"
        'Else
        '    SSS = "22"
        'End If
        SSS = "22"

    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged
        If RB1.Checked = True Then
            Label11.Text = "Excel欄位分別為：第一欄：條碼"
        Else
            Label11.Text = "Excel欄位分別為：第一欄：條碼 第二欄：數量"
        End If

        ks1DataSet.Clear()
        dsPDAIn.Clear()
        Label12.Visible = False
        Label13.Visible = False
        DataGridView3.Visible = False
        DataGridView4.Visible = False
        DrfNum.Text = ""
    End Sub
   
    Private Sub cobSelectType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSelectType.SelectedIndexChanged
        Select Case cobSelectType.SelectedIndex
            Case "0"
                ChkBox1.Visible = False
                ks2DataSet.Clear()
            Case "1"
                ChkBox1.Visible = False
                ks2DataSet.Clear()
                LoaddgvSourceMain()
            Case "2"
                ChkBox1.Visible = False
                ks2DataSet.Clear()
            Case "3"
                ChkBox1.Visible = True
                ks2DataSet.Clear()
            Case "4"
                ChkBox1.Visible = False
                ks2DataSet.Clear()
        End Select
    End Sub

    Private Sub LoaddgvSourceMain()
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn

        Select cobSelectType.SelectedIndex
            '    Case "0"
            '        sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('5') AND T0.DocStatus = 'O' "
            Case "1"
                'sql = " SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum FROM ODRF T0  left JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
                'sql += " WHERE T0.ObjType='15' and T1.WhsCode not in ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.DocStatus = 'O'"
                sql = "  SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum "
                sql += "   FROM ODRF T0 LEFT JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
                sql += "  WHERE T0.ObjType='15' and T1.WhsCode not in ('K05','S05','O01','R01','R02','R03','R04','R05','R06') AND T0.DocStatus = 'O'"
                sql += "  ORDER BY T0.U_Dnum DESC"

                '    Case "2"
                'sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE ObjType = '60' AND U_CK01 in ('0','1','2','3','4') AND T0.DocStatus = 'O'"
            Case "3"
                sql = "  SELECT DISTINCT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_attachment, T0.U_CK01, T0.U_Cnum, T0.U_N1, T0.U_N2, T0.U_N3, T0.U_CarDr1, T0.U_CarDr2, T0.U_CarDr3, T0.U_Dlst, T0.U_updnum, T0.U_TpMoney, T0.Comments, T0.U_Dnum "
                sql += "   FROM ODRF T0  LEFT JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry "
                sql += "  WHERE T0.ObjType='15' and (T1.WhsCode='O01' or T1.WhsCode='K05' OR T1.WhsCode='S05') AND T0.DocStatus = 'O'"
                '    Case "4"
                'sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('11') AND T0.DocStatus = 'O' "
                '    Case "5"
                'sql = "SELECT T0.DocEntry, T0.DocNum, T0.CardCode, T0.CardName, T0.DocDate, T0.TaxDate, T0.DocDueDate, T0.U_CK01, T0.U_CK02, T0.U_Cnum, T0.U_Gnum, T0.U_TpMoney, T0.Comments, T0.JrnlMemo, T0.U_Dnum from ODRF T0 WHERE T0.ObjType = '60' AND T0.U_CK01 in ('14') AND T0.DocStatus = 'O' "
        End Select

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks2DataSet, "DGV5")
        DGV5.DataSource = ks2DataSet.Tables("DGV5")

        Select Case cobSelectType.SelectedIndex
            Case "0" : setdgvSourceMainDisplayType1()
            Case "1" : setdgvSourceMainDisplayType2()
            Case "2" : setdgvSourceMainDisplayType1()
            Case "3" : setdgvSourceMainDisplayType2()
            Case "4" : setdgvSourceMainDisplayType1()
            Case "5" : setdgvSourceMainDisplayType1()
        End Select

        DGV5.AutoResizeColumns()
        If DGV5.RowCount = 0 Then
            MsgBox("查無資料。", 48, "警告")
        End If

    End Sub

    Private Sub setdgvSourceMainDisplayType1()
        '存貨發貨
        For Each column As DataGridViewColumn In DGV5.Columns
            column.Visible = True
            Select Case column.Name
                Case "DocEntry"
                    column.HeaderText = "草稿號"
                    column.DisplayIndex = 0
                Case "DocDueDate"
                    column.HeaderText = "文件日期"
                    column.DisplayIndex = 1
                Case "Comments"
                    column.HeaderText = "備註"
                    column.DisplayIndex = 2
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

    Private Sub setdgvSourceMainDisplayType2()
        '營業交貨
        For Each column As DataGridViewColumn In DGV5.Columns
            column.Visible = True
            Select Case column.Name
                Case "U_Dnum"
                    column.HeaderText = "提單號"
                    column.DisplayIndex = 0
                Case "DocEntry"
                    column.HeaderText = "草稿號"
                    column.DisplayIndex = 1
                Case "CardName"
                    column.HeaderText = "客戶"
                    column.DisplayIndex = 2
                Case "DocDueDate"
                    column.HeaderText = "到期日"
                    column.DisplayIndex = 3
                Case Else
                    column.Visible = False
            End Select
        Next
    End Sub

    Private Sub DGV5_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV5.CellClick

        '回傳 -1時停止動作
        If DGV5.RowCount <= 0 Then
            Exit Sub
        End If

        DrfNum.Text = DGV5.CurrentRow.Cells("DocEntry").Value

    End Sub







    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ks1DataSet.Clear()
        dsPDAIn.Clear()
        Label12.Visible = False
        Label13.Visible = False
        DataGridView3.Visible = False
        DataGridView4.Visible = False

        If DrfNum.Text = "" Then
            MsgBox("請輸入草稿編號")
            DrfNum.Focus()
            Exit Sub
        End If

        Dim Chk As Boolean = ChkDrfNum(DrfNum.Text)        
        If Chk = True Then
            If MessageBox.Show("此草稿編號已同步過!" & vbCrLf & "是否要刪除已同步的草稿?", "選擇", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                Dim ChkDel As Boolean = DelDrfNum(DrfNum.Text)
                If ChkDel = False Then
                    Exit Sub
                Else
                    MsgBox("刪除已同步的草稿完畢!", 64, "成功")
                End If
            Else
                Exit Sub
            End If
        End If        
        ReadExcel()

    End Sub

    Private Function ChkDrfNum(ByVal DrfNum As String)
        Dim Rtn As Boolean

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand
        Dim sqlReader As SqlDataReader
        sql = "select * from [@ksOBList] where OB08 = '" & DrfNum & "'"
        SQLCmd = New SqlCommand(sql, DBConn)
        sqlReader = SQLCmd.ExecuteReader

        If sqlReader.HasRows() Then
            sqlReader.Close()
            Rtn = True
        Else
            sqlReader.Close()
            Rtn = False
        End If

        Return Rtn
    End Function

    Private Function DelDrfNum(ByVal DrfNum As String)
        Dim Rtn As Boolean = True
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()
        Try
            sql = "Delete from [@ksOBList] where OB08 = '" & DrfNum & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Rtn = False
        End Try
        Return Rtn
    End Function

    Private Sub ReadExcel()
        Dim openfile As New OpenFileDialog()
        openfile.InitialDirectory = "..\"            '開啟時預設的資料夾路徑   
        'openfile.InitialDirectory = "C:"            '開啟時預設的資料夾路徑  
        openfile.Filter = "Excel files(*.xls)|*.xls"    '只抓excel檔   
        openfile.ShowDialog()

        If openfile.FileName = "" Then
            Exit Sub
        End If

        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & openfile.FileName & ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'"

        Dim strSQL As String = "SELECT * FROM [Sheet1$]"
        Dim excelConnection As New Data.OleDb.OleDbConnection(connectionString)
        Try
            excelConnection.Open() ' this will open excel file
        Catch ex As Exception
            MsgBox(" " & ex.Message)
            Exit Sub
        End Try
        Dim dbCommand As OleDbCommand = New OleDbCommand(strSQL, excelConnection)
        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter(dbCommand)

        Dim dTable As DataTable = New DataTable()
        dataAdapter.Fill(dTable)
        DataGridView1.DataSource = dTable        
        dTable.Dispose()
        dataAdapter.Dispose()
        dbCommand.Dispose()
        excelConnection.Close()
        excelConnection.Dispose()

        joinAllTable()

    End Sub

    Private Sub joinAllTable()

        PBar1.Minimum = 0
        PBar1.Maximum = DataGridView1.Rows.Count - 1

        If DataGridView1.Rows.Count > 0 Then
            Dim sql As String
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            Dim sqlReader As SqlDataReader

            Dim Q As Integer = 0                
            Try
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    'If ChkBox1.Checked Then
                    '    If SSS = "22" Then
                    '        DataGridView1.Rows(i).Cells("F1").Value = DataGridView1.Rows(i).Cells("F1").Value + "A"
                    '    Else
                    '        DataGridView1.Rows(i).Cells("F1").Value = Microsoft.VisualBasic.Mid(DataGridView1.Rows(i).Cells("F1").Value, 6, 13) + "A"
                    '    End If
                    'End If

                    If RB1.Checked = True Then
                        sql = " SELECT dbo.OITM.ItemCode, dbo.OITM.ItemName, dbo.OSRN.DistNumber, dbo.OSRN.U_M2, dbo.OSRN.U_M8, dbo.OSRN.U_M1, dbo.OSRN.MnfDate,dbo.OSRN.ExpDate,dbo.DRF1.DocEntry, dbo.DRF1.LineNum "
                        sql += "  FROM dbo.DRF1 INNER JOIN dbo.OITM ON dbo.OITM.ItemCode = dbo.DRF1.ItemCode "
                        sql += "                INNER JOIN dbo.OSRN ON dbo.OSRN.ItemCode = dbo.DRF1.ItemCode "
                        sql += "                INNER JOIN dbo.OSRQ on dbo.OSRQ.ItemCode = dbo.OSRN.ItemCode AND OSRQ.SysNumber = OSRN.SysNumber "
                        sql += " WHERE DRF1.DocEntry   = '" & DrfNum.Text & "' AND "
                        If SSS = "22" Then
                            sql += "       OSRN.DistNumber = '" & DataGridView1.Rows(i).Cells("F1").FormattedValue & "' AND "
                        Else
                            sql += "       OSRN.DistNumber = '" & Microsoft.VisualBasic.Mid(DataGridView1.Rows(i).Cells("F1").FormattedValue, 6, 13) & "' AND "
                        End If
                        sql += "       OSRQ.Quantity > 0"
                    End If

                    If RB2.Checked = True Then
                        Dim Qyty As Integer = 0
                        If DataGridView1.Rows(i).Cells("F2").FormattedValue = "0" Then
                            Qyty = GetBTQty(DataGridView1.Rows(i).Cells("F1").FormattedValue)
                        Else
                            Qyty = DataGridView1.Rows(i).Cells("F2").FormattedValue
                        End If

                        sql = "SELECT  dbo.OITM.ItemCode, dbo.OITM.ItemName, dbo.OBTN.DistNumber, dbo.OBTN.U_M2, dbo.OBTN.U_M8, dbo.OBTN.MnfDate,dbo.OBTN.ExpDate, dbo.DRF1.DocEntry, dbo.DRF1.LineNum , '" & Qyty & "' as 'Qty' FROM dbo.DRF1 inner JOIN dbo.OITM ON dbo.OITM.ItemCode = dbo.DRF1.ItemCode inner JOIN dbo.OBTN ON dbo.OBTN.ItemCode = dbo.DRF1.ItemCode inner join dbo.OBTQ on dbo.OBTQ.ItemCode = dbo.OBTN.ItemCode and OBTQ.SysNumber = OBTN.SysNumber where DRF1.DocEntry = '" & DrfNum.Text & "' and DistNumber = '" & DataGridView1.Rows(i).Cells("F1").FormattedValue & "' and OBTQ.Quantity >= '" & Qyty & "'"
                    End If
                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    sqlReader = SQLCmd.ExecuteReader

                    If sqlReader.HasRows() Then
                        sqlReader.Close()
                        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
                        DataAdapter1.Fill(ks1DataSet, "DT1")
                    Else
                        sqlReader.Close()

                        If SSS = "22" Then

                            If DataGridView1.Rows(i).Cells("F1").FormattedValue = "" Then
                            Else
                                Q = Q + 1
                                Dim Row(Q) As DataRow
                                Row(Q) = dsPDAIn.NewRow
                                Row(Q).Item("條碼") = DataGridView1.Rows(i).Cells("F1").FormattedValue
                                dsPDAIn.Rows.Add(Row(Q))
                            End If

                        Else

                            If Microsoft.VisualBasic.Mid(DataGridView1.Rows(i).Cells("F1").FormattedValue, 6, 13) = "" Then
                            Else
                                Q = Q + 1
                                Dim Row(Q) As DataRow
                                Row(Q) = dsPDAIn.NewRow
                                Row(Q).Item("條碼") = Microsoft.VisualBasic.Mid(DataGridView1.Rows(i).Cells("F1").FormattedValue, 6, 13)
                                dsPDAIn.Rows.Add(Row(Q))
                            End If

                        End If

                            '' '' ''If DataGridView1.Rows(i).Cells("F1").FormattedValue = "" Then
                            ''If Microsoft.VisualBasic.Mid(DataGridView1.Rows(i).Cells("F1").FormattedValue, 6, 13) = "" Then

                            ''Else
                            ''    Q = Q + 1
                            ''    Dim Row(Q) As DataRow
                            ''    Row(Q) = dsPDAIn.NewRow
                            ''    '' ''Row(Q).Item("條碼") = DataGridView1.Rows(i).Cells("F1").FormattedValue
                            ''    Row(Q).Item("條碼") = Microsoft.VisualBasic.Mid(DataGridView1.Rows(i).Cells("F1").FormattedValue, 6, 13)
                            ''    dsPDAIn.Rows.Add(Row(Q))
                            ''End If

                        End If

                    PBar1.Value = i

                Next
            Catch ex As Exception
                MsgBox("讀取錯誤：" & vbCrLf & ex.Message, 16, "錯誤")
                Exit Sub
            End Try
            If Q > 0 Then
                Button2.Enabled = False

                Button4.Enabled = True
                Button5.Enabled = True
                MsgBox("條碼有錯誤!請檢查!", 16, "錯誤")

            ElseIf Q = 0 Then
                Button2.Enabled = True
            End If

            DataGridView2.DataSource = dsPDAIn

            dgvSourceMain.DataSource = ks1DataSet.Tables("DT1")
            setdgvSourceMainDisplay()
        End If



    End Sub

    Private Function GetBTQty(ByVal DistNumber As String)
        Dim RtnQty As Integer
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "select T1.Quantity From OBTN T0 left join OBTQ T1 On T0.ItemCode = T1.ItemCode and T0.SysNumber = T1.SysNumber Where T0.DistNumber = '" & DistNumber & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            RtnQty = sqlReader.Item("Quantity")
            sqlReader.Close()
        Else
            RtnQty = 0
            sqlReader.Close()
        End If

        Return RtnQty
    End Function

    Private Sub setdgvSourceMainDisplay()

        If dgvSourceMain.RowCount <= 0 Then
            MsgBox("查不到資料!請確認草稿編號是否正確!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In dgvSourceMain.Columns
            column.Visible = True
            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                Case "ItemName"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                Case "DistNumber"
                    column.HeaderText = "條碼"
                    column.DisplayIndex = 2
                Case "U_M1"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 3
                Case "Qty"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 3
                    column.ReadOnly = False
                Case "U_M2"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 4
                Case "MnfDate"
                    column.HeaderText = "製造日期"
                    column.DisplayIndex = 5
                Case "ExpDate"
                    column.HeaderText = "有效日期"
                    column.DisplayIndex = 6
                Case "U_M8"
                    column.HeaderText = "製造單號"
                    column.DisplayIndex = 7
                Case "DocEntry"
                    column.HeaderText = "草稿號碼"
                    column.DisplayIndex = 8
                Case "LineNum"
                    column.HeaderText = "行"
                    column.DisplayIndex = 9

                Case Else
                    column.Visible = False
            End Select
        Next
        dgvSourceMain.AutoResizeColumns()

        Label9.Text = "共  " + Format(dgvSourceMain.RowCount, "") + "  項"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dgvSourceMain.RowCount <= 0 Then
            MsgBox("無資料可同步", 16, "錯誤")
            Exit Sub
        End If

        If cobSelectType.SelectedIndex = -1 Then
            MsgBox("請選擇出庫類型", 16, "錯誤")
            Exit Sub
        End If

        Sync()
    End Sub

    Private Sub Sync()
        Dim Type As String
        Select Case cobSelectType.SelectedIndex
            Case "0"
                Type = "1"
            Case "1"
                Type = "2"
            Case "2"
                Type = "3"
            Case "3"
                Type = "4"
            Case "4"
                Type = "5"
        End Select

        Dim getDay As Date = Today

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try
            For i As Integer = 0 To dgvSourceMain.RowCount - 1
                If RB1.Checked = True Then
                    sql = "INSERT INTO [@ksOBList] (OB01,OB02,OB03,OB04,OB05,OB07,OB08,OB09,OB10,OB12) VALUES ('" & dgvSourceMain.Rows(i).Cells("ItemCode").Value & "','" & dgvSourceMain.Rows(i).Cells("ItemName").Value & "','" & dgvSourceMain.Rows(i).Cells("DistNumber").Value & "','" & dgvSourceMain.Rows(i).Cells("U_M2").Value & "','1','" & Type & "','" & dgvSourceMain.Rows(i).Cells("DocEntry").Value & "','" & dgvSourceMain.Rows(i).Cells("LineNum").Value & "','3','" & getDay & "')"
                End If
                If RB2.Checked = True Then
                    sql = "INSERT INTO [@ksOBList] (OB01,OB02,OB03,OB04,OB05,OB07,OB08,OB09,OB10,OB12) VALUES ('" & dgvSourceMain.Rows(i).Cells("ItemCode").Value & "','" & dgvSourceMain.Rows(i).Cells("ItemName").Value & "','" & dgvSourceMain.Rows(i).Cells("DistNumber").Value & "','" & dgvSourceMain.Rows(i).Cells("U_M2").Value & "','" & dgvSourceMain.Rows(i).Cells("Qty").FormattedValue & "','" & Type & "','" & dgvSourceMain.Rows(i).Cells("DocEntry").Value & "','" & dgvSourceMain.Rows(i).Cells("LineNum").Value & "','3','" & getDay & "')"
                End If
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("同步失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("同步EXCEL資料完畢!", 64, "成功")
        ks1DataSet.Tables("DT1").Clear()
        Label9.Text = "0"
        DrfNum.Clear()
    End Sub

    Private Sub toExcBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toExcBtn.Click
        DataToExcel(dgvSourceMain, "")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataToExcel(DataGridView2, "")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DataGridView2.RowCount <= 0 Then
            MsgBox("無資料可分析", 16, "錯誤")
            Exit Sub
        End If

        AnalysisErr()
    End Sub

    Private Sub AnalysisErr()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader1 As SqlDataReader
        Dim dsPDAIn01 As New DataTable
        Dim dsPDAIn02 As New DataTable
        Dim Q1 As Integer = 0
        Dim Q2 As Integer = 0
        Dim Name01 As DataColumn = New DataColumn("條碼")
        Dim Name02 As DataColumn = New DataColumn("條碼")
        Name01.DataType = System.Type.GetType("System.String")
        Name02.DataType = System.Type.GetType("System.String")        
        dsPDAIn01.Columns.Add(Name01)
        dsPDAIn02.Columns.Add(Name02)        

        PBar1.Minimum = 0
        PBar1.Maximum = DataGridView2.RowCount - 1

        Try
            For i As Integer = 0 To DataGridView2.RowCount - 1
                If RB1.Checked = True Then
                    sql = "SELECT T0.DistNumber FROM [OSRN] T0 where T0.DistNumber = '" & DataGridView2.Rows(i).Cells("條碼").FormattedValue & "' "
                End If

                If RB2.Checked = True Then
                    sql = "SELECT T0.DistNumber FROM [OBTN] T0 where T0.DistNumber = '" & DataGridView2.Rows(i).Cells("條碼").FormattedValue & "' "
                End If

                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql

                sqlReader1 = SQLCmd.ExecuteReader

                If sqlReader1.HasRows() Then
                    Q1 = Q1 + 1
                    Dim Row(Q1) As DataRow
                    Row(Q1) = dsPDAIn01.NewRow
                    Row(Q1).Item("條碼") = DataGridView2.Rows(i).Cells("條碼").FormattedValue
                    dsPDAIn01.Rows.Add(Row(Q1))
                    sqlReader1.Close()
                Else
                    Q2 = Q2 + 1
                    Dim Row(Q2) As DataRow
                    Row(Q2) = dsPDAIn02.NewRow
                    Row(Q2).Item("條碼") = DataGridView2.Rows(i).Cells("條碼").FormattedValue
                    dsPDAIn02.Rows.Add(Row(Q2))
                    sqlReader1.Close()
                End If

                PBar1.Value = i
            Next
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        DataGridView3.DataSource = dsPDAIn01
        DataGridView4.DataSource = dsPDAIn02

        Label12.Visible = True
        Label13.Visible = True
        DataGridView3.Visible = True
        DataGridView4.Visible = True
        Button5.Enabled = False
    End Sub

    Private Sub AddColumn()
        Dim Name As DataColumn = New DataColumn("條碼")
        Name.DataType = System.Type.GetType("System.String")
        dsPDAIn.Columns.Add(Name)
    End Sub

End Class

