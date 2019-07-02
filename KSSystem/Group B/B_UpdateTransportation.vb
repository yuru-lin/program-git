Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_UpdateTransportation
    Public Source As String
    Dim dsPDAIn As New DataTable
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim DataAdapterDGV As SqlDataAdapter
    Dim udCarEntry As String

    Private Sub B_UpdateTransportation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvSearch.ContextMenuStrip = MainForm.ContextMenuStrip1
        dgvDetail.ContextMenuStrip = MainForm.ContextMenuStrip1

        dateDocDate.Value = dateDocDate.Value.Date.AddDays(1)
        dateDocDateSearch.Value = dateDocDateSearch.Value.Date.AddDays(1)


        Label4.ForeColor = Color.Red
        Label7.ForeColor = Color.Red
        Label18.ForeColor = Color.Red
        Label37.ForeColor = Color.Red
        Label24.ForeColor = Color.Red

        Label46.ForeColor = Color.Purple
        Label31.ForeColor = Color.Purple
        Label29.ForeColor = Color.Purple

        
    End Sub

    Private Sub B_AddTransportationClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If txtCarEntry.Text = "" Then
            If MessageBox.Show("確定要離開?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        Else
            If MessageBox.Show("資料尚未儲存至資料庫" & vbCrLf & "確定要離開?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub cobSourceFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobSourceFrom.SelectedIndexChanged
        SourceFrom()
    End Sub
    Private Sub cobU_M03Number_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobU_M03Number.SelectedIndexChanged
        setU_M03()
    End Sub
    Private Sub cobRainPercent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cobRainPercent.SelectedIndexChanged
        setRainPercent()
    End Sub
    Private Sub dateDocDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateDocDate.ValueChanged
        setU_M03()
    End Sub


    Private Sub txtMeasuredByKS_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeasuredByKS.TextChanged
        CalcWeightDiff()
    End Sub
    Private Sub txtTotalWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalWeight.TextChanged
        CalcWeightDiff()
    End Sub
    Private Sub txtCatchCntNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCatchCntNumber.TextChanged
        CalcRealCntNumber()
        RealAvgWeight()
    End Sub
    Private Sub txtDeathNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeathNumber.TextChanged
        CalcRealCntNumber()
        DeathWeight()
    End Sub
    Private Sub txtDropNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDropNumber.TextChanged
        CalcRealCntNumber()
        DropWeight()
    End Sub
    Private Sub txtPreCntNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPreCntNumber.Leave
        If txtPreCntNumber.Text > "5000" Then
            MsgBox("預抓羽數大於5000", 48, "警告")
        End If
    End Sub
    Private Sub txtPackNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPackNumber.TextChanged
        CalcCntDiff()
    End Sub
    Private Sub txtRealCntNumber_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRealCntNumber.TextChanged
        CalcCntDiff()
    End Sub
    Private Sub txtMeasuredWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeasuredWeight.TextChanged
        CalcRainWeight()
        RealAvgWeight()
        CalcTotalRealWeight()
        CalcRealWeightDiff()
    End Sub
    Private Sub txtRainPercent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRainPercent.TextChanged
        CalcRainWeight()
    End Sub
    Private Sub txtRealAvgWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRealAvgWeight.TextChanged
        DeathWeight()
        DropWeight()
    End Sub
    Private Sub lblU_M03_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblU_M03.TextChanged
        setU_M03()
    End Sub
    Private Sub txtDeathWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDeathWeight.TextChanged
        CalcTotalRealWeight()
    End Sub
    Private Sub txtDropWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDropWeight.TextChanged
        CalcTotalRealWeight()
    End Sub
    Private Sub txtRainWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRainWeight.TextChanged
        CalcTotalRealWeight()
    End Sub
    Private Sub txtTotalRealWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalRealWeight.TextChanged
        CalcRealWeightDiff()
    End Sub
   

    '設定單號
    Private Sub setCarEntry()
        Dim FormatDate As String
        FormatDate = Format(dateDocDate.Value.Date, "yyMMdd")

        Dim EntryNum As String

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT top 1 [CarEntry],left([CarEntry],6) as '左日期',right([CarEntry],2) as '右序號'  FROM [@Transportation] Order By [CarEntry] DESC"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            If sqlReader.Item("左日期") = FormatDate Then
                EntryNum = sqlReader.Item("CarEntry") + 1
            Else
                EntryNum = FormatDate & "01"
            End If
        Else
            EntryNum = FormatDate & "01"
        End If

        sqlReader.Close()

        txtCarEntry.Text = EntryNum
    End Sub

    '檢查單號重複
    Private Function chkCarEntry(ByVal CarEntry As String)
        Dim AnsHasRow As Boolean

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT [CarEntry] FROM [@Transportation] WHERE [CarEntry] = '" & CarEntry & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            AnsHasRow = True
        Else
            AnsHasRow = False
        End If

        sqlReader.Close()

        Return AnsHasRow

    End Function


    '選擇契養批號
    Private Sub SourceFrom()
        Select Case cobSourceFrom.SelectedIndex
            Case 0
                lblU_M03.Text = "1"
                SelectFarmName.Source = "Update"
                SelectFarmName.MdiParent = MainForm
                SelectFarmName.Show()
            Case 1
                lblU_M03.Text = "1"
            Case 2
                lblU_M03.Text = "4"
            Case -1
                lblU_M03.Text = "0"
        End Select
    End Sub

    '計算磅差
    Private Sub CalcWeightDiff()
        Dim MeasuredByKS, TotalWeight As Integer

        If txtMeasuredByKS.Text = "" Then
            MeasuredByKS = 0
        Else
            MeasuredByKS = CInt(Trim(txtMeasuredByKS.Text))
        End If

        If txtTotalWeight.Text = "" Then
            TotalWeight = 0
        Else
            TotalWeight = CInt(Trim(txtTotalWeight.Text))
        End If

        txtWeightDiff.Text = MeasuredByKS - TotalWeight
    End Sub

    '設定製單編號
    Private Sub setU_M03()
        If lblU_M03.Text = "0" Or cobU_M03Number.SelectedIndex = -1 Then
            txtU_M03.Text = ""
            Exit Sub
        End If

        txtU_M03.Text = lblU_M03.Text & Format(dateDocDate.Value.Date, "yyMMdd") & "00" & cobU_M03Number.Text
    End Sub

    '計算實際羽數
    Private Sub CalcRealCntNumber()
        Dim CatchCntNumber, DeathNumber, DropNumber As Integer

        If txtCatchCntNumber.Text = "" Then
            CatchCntNumber = 0
        Else
            CatchCntNumber = CInt(Trim(txtCatchCntNumber.Text))
        End If

        If txtDeathNumber.Text = "" Then
            DeathNumber = 0
        Else
            DeathNumber = CInt(Trim(txtDeathNumber.Text))
        End If

        If txtDropNumber.Text = "" Then
            DropNumber = 0
        Else
            DropNumber = CInt(Trim(txtDropNumber.Text))
        End If

        txtRealCntNumber.Text = CatchCntNumber - DeathNumber - DropNumber
    End Sub

    '計算羽數差異
    Private Sub CalcCntDiff()
        Dim PackNumber, RealCntNumber As Integer

        If txtPackNumber.Text = "" Then
            PackNumber = 0
        Else
            PackNumber = CInt(Trim(txtPackNumber.Text))
        End If

        If txtRealCntNumber.Text = "" Then
            RealCntNumber = 0
        Else
            RealCntNumber = CInt(Trim(txtRealCntNumber.Text))
        End If

        txtCntDiff.Text = RealCntNumber - PackNumber
    End Sub

    '設定含水%數
    Private Sub setRainPercent()
        Select Case cobRainPercent.SelectedIndex
            Case 0
                txtRainPercent.Text = "0"
            Case 1
                txtRainPercent.Text = "0"
            Case 2
                txtRainPercent.Text = "4"
            Case 3
                txtRainPercent.Text = "2"
            Case 4
                txtRainPercent.Text = "1"
        End Select
    End Sub

    '計算含水重
    Private Sub CalcRainWeight()
        Dim MeasuredWeight, RainPercent As Integer

        If txtMeasuredWeight.Text = "" Then
            MeasuredWeight = 0
        Else
            MeasuredWeight = CInt(Trim(txtMeasuredWeight.Text))
        End If

        If txtRainPercent.Text = "" Then
            RainPercent = 0
        Else
            RainPercent = CInt(Trim(txtRainPercent.Text))
        End If

        txtRainWeight.Text = MeasuredWeight * RainPercent / 100
    End Sub

    '計算死亡重
    Private Sub DeathWeight()
        Dim DeathNumber As Integer
        Dim RealAvgWeight As Double

        If txtDeathNumber.Text = "" Then
            DeathNumber = 0
        Else
            DeathNumber = CInt(Trim(txtDeathNumber.Text))
        End If

        If txtRealAvgWeight.Text = "" Then
            RealAvgWeight = 0
        Else
            RealAvgWeight = CDbl(Trim(txtRealAvgWeight.Text))
        End If

        txtDeathWeight.Text = DeathNumber * RealAvgWeight
    End Sub

    '計算廢棄重
    Private Sub DropWeight()
        Dim DropNumber As Integer
        Dim RealAvgWeight As Double

        If txtDropNumber.Text = "" Then
            DropNumber = 0
        Else
            DropNumber = CInt(Trim(txtDropNumber.Text))
        End If

        If txtRealAvgWeight.Text = "" Then
            RealAvgWeight = 0
        Else
            RealAvgWeight = CDbl(Trim(txtRealAvgWeight.Text))
        End If

        txtDropWeight.Text = DropNumber * RealAvgWeight
    End Sub

    '計算實際平均重
    Private Sub RealAvgWeight()
        Dim MeasuredWeight, CatchCntNumber As Integer
        Dim Ans As Double

        If txtMeasuredWeight.Text = "" Then
            MeasuredWeight = 0
        Else
            MeasuredWeight = CInt(Trim(txtMeasuredWeight.Text))
        End If

        If txtCatchCntNumber.Text = "" Then
            CatchCntNumber = 0
        Else
            CatchCntNumber = CInt(Trim(txtCatchCntNumber.Text))
        End If

        If CatchCntNumber = 0 Then
            Exit Sub
        Else
            Ans = MeasuredWeight / CatchCntNumber
            txtRealAvgWeight.Text = Format(Ans, "#0.##")
        End If

    End Sub

    '計算實際總重(磅單重-死亡重-廢棄重-含水重)
    Private Sub CalcTotalRealWeight()

        Dim MeasuredWeight As Integer
        Dim DeathWeight, DropWeight, RainWeight As Double

        If txtMeasuredWeight.Text = "" Then
            MeasuredWeight = 0
        Else
            MeasuredWeight = CInt(Trim(txtMeasuredWeight.Text))
        End If

        If txtDeathWeight.Text = "" Then
            DeathWeight = 0
        Else
            DeathWeight = CDbl(Trim(txtDeathWeight.Text))
        End If

        If txtDropWeight.Text = "" Then
            DropWeight = 0
        Else
            DropWeight = CDbl(Trim(txtDropWeight.Text))
        End If

        If txtRainWeight.Text = "" Then
            RainWeight = 0
        Else
            RainWeight = CDbl(Trim(txtRainWeight.Text))
        End If

        txtTotalRealWeight.Text = MeasuredWeight - DeathWeight - DropWeight - RainWeight
    End Sub

    '計算重量差異
    Private Sub CalcRealWeightDiff()
        Dim MeasuredWeight As Integer
        Dim TotalRealWeight As Double

        If txtMeasuredWeight.Text = "" Then
            MeasuredWeight = 0
        Else
            MeasuredWeight = CInt(Trim(txtMeasuredWeight.Text))
        End If

        If txtTotalRealWeight.Text = "" Then
            TotalRealWeight = 0
        Else
            TotalRealWeight = CDbl(Trim(txtTotalRealWeight.Text))
        End If

        txtRealWeightDiff.Text = Format(MeasuredWeight - TotalRealWeight, "#0.##")
    End Sub


    '計算單號磅單總重
    Private Sub CalcTotalWeight()
        If dgvDetail.RowCount < 0 Then
            Exit Sub
        End If
        Dim Addsum As Integer = 0
        For i As Integer = 0 To dgvDetail.RowCount - 1
            Addsum += dgvDetail.Rows(i).Cells("磅單重").FormattedValue()
        Next
        txtTotalWeight.Text = Addsum
    End Sub

    '限制輸入數字並只到小數點後2位
    Private Sub txtPricePerTWKG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 2 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtRealAvgWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRealAvgWeight.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 2 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtAvgWeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAvgWeight.KeyPress

        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = Chr(8) Then
            If e.KeyChar = "." And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                e.Handled = True
            Else
                If e.KeyChar <> Chr(8) And InStr(CType(sender, System.Windows.Forms.TextBox).Text, ".") > 0 Then
                    Dim sAry() As String = CType(sender, System.Windows.Forms.TextBox).Text.Split(".")
                    If sAry(1).Length >= 2 Then
                        e.Handled = True
                    Else
                        e.Handled = False
                    End If
                Else
                    e.Handled = False
                End If
            End If
        ElseIf e.KeyChar = "-" And CType(sender, System.Windows.Forms.TextBox).Text = "" Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub txtCarEntry_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCarEntry.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    '清空表身
    Private Sub CleanBody()
        cobSourceFrom.SelectedIndex = -1
        txtFarmName.Text = ""
        txtFarmID.Text = ""
        cobCarEntryNumber.SelectedIndex = -1
        cobTypeName.SelectedIndex = -1
        txtPreCntNumber.Text = "0"
        txtCatchCntNumber.Text = "0"
        txtRealCntNumber.Text = "0"
        txtCntDiff.Text = "0"
        txtPackNumber.Text = "0"
        cobTypeSpecial.SelectedIndex = -1
        txtDeathNumber.Text = "0"
        txtDeathWeight.Text = "0"
        txtDropNumber.Text = "0"
        txtDropWeight.Text = "0"
        cobRainPercent.SelectedIndex = 0
        txtRainPercent.Text = "0"
        txtRainWeight.Text = "0"
        cobU_M03Number.SelectedIndex = -1
        txtU_M03.Text = ""
        txtAvgWeight.Text = "0"
        txtRealAvgWeight.Text = "0"
        txtMeasuredWeight.Text = "0"
        txtTotalRealWeight.Text = "0"
        txtRealWeightDiff.Text = "0"
        txtComments.Text = ""
        
    End Sub

    '清空表頭跟表身
    Private Sub CleanAll()
       
        txtCarEntry.Text = ""
        txtCarIDNumber.Text = ""
        txtMeasuredByKS.Text = "0"
        txtTotalWeight.Text = "0"
        txtWeightDiff.Text = "0"
        CleanBody()

        If dgvDetail.RowCount > 0 Then           
            ks1DataSetDGV.Tables("DT2").Clear()
        End If
    End Sub

    Private Sub btnUpDateDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpDateDetail.Click
        If cobTypeName.Text = "" Or txtPreCntNumber.Text = "" Or txtAvgWeight.Text = "" Then
            MsgBox("項目資料錯誤!", 16, "錯誤")
            Exit Sub
        End If

        UpdateItemDetail()
        CalcTotalWeight()
        CleanBody()
    End Sub

    Private Sub btnAddToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDB.Click

        If dgvDetail.RowCount <= 0 Then
            MsgBox("無項目資料!", 16, "錯誤")
            Exit Sub
        End If

        If txtCarEntry.Text = "" Then
            MsgBox("資料未填!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer

        oAns = MsgBox("確認要更新至資料庫 ?", 36, "更新")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            UpdateToDB()
            QueryTransport()
        End If

        CleanAll()
    End Sub

    '載入資料以便更新
    Private Sub LoadData1(ByVal useCarEntry As String)
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader


        sql = "SELECT [CarEntry] as '單號',[DocDate] as '日期',[CarIDNumber] as '車牌號',[MeasuredByKS] as '公司會磅',[TotalWeight] as '車次磅單總重',[WeightDiff] as '磅差' FROM [@Transportation] Where [CarEntry] = '" & useCarEntry & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then

            txtCarEntry.Text = sqlReader.Item("單號")
            txtCarEntry.Enabled = False
            dateDocDate.Value = sqlReader.Item("日期")
            dateDocDate.Enabled = False
            txtCarIDNumber.Text = sqlReader.Item("車牌號")
            txtMeasuredByKS.Text = sqlReader.Item("公司會磅")
            txtTotalWeight.Text = sqlReader.Item("車次磅單總重")
            txtWeightDiff.Text = sqlReader.Item("磅差")
        Else
            MsgBox("載入資料失敗!", 16, "錯誤")

        End If

        sqlReader.Close()

    End Sub

    Private Sub LoadData2(ByVal useCarEntry As String)
        If dgvDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand


        sql = "SELECT [LineNum] as '列號',[SourceFrom] as '來源',[FarmName] as '牧場名稱',[FarmID] as '牧場代號',[CarOrder] as '順序',[TypeName] as '品名',[TypeSpecial] as '特殊',[PreCntNumber] as '預抓羽數',[CatchCntNumber] as '磅單羽數',[RealCntNumber] as '實際羽數',[CntDiff] as '羽數差異',[PackNumber] as '包裝數',[DeathNumber] as '死亡數',[DeathWeight] as '死亡重',[DropNumber] as '廢棄數',[DropWeight] as '廢棄重',[RainPercent] as '含水%數',[RainWeight] as '含水重',[U_M03] as '製造單號',[AvgWeight] as '平均重',[RealAvgWeight] as '實際平均重',[MeasuredWeight] as '磅單重',[TotalRealWeight] as '實際總重',[RealWeightDiff] as '重量差異',[Comments] as '備註' FROM [@Transportation1] Where [CarEntry] = '" & useCarEntry & "' and [Cancel] = 'N'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")

        dgvDetail.DataSource = ks1DataSetDGV.Tables("DT2")
        dgvDetail.AutoResizeColumns()

    End Sub

    Private Sub dgvDetail_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetail.CellClick
        If dgvDetail.RowCount <= 0 Then
            Exit Sub
        End If

        cobSourceFrom.Text = dgvDetail.CurrentRow.Cells("來源").Value
        txtFarmName.Text = dgvDetail.CurrentRow.Cells("牧場名稱").Value
        txtFarmID.Text = dgvDetail.CurrentRow.Cells("牧場代號").Value
        cobCarEntryNumber.Text = dgvDetail.CurrentRow.Cells("順序").Value
        cobTypeName.Text = dgvDetail.CurrentRow.Cells("品名").Value
        cobTypeSpecial.Text = dgvDetail.CurrentRow.Cells("特殊").Value
        txtPreCntNumber.Text = dgvDetail.CurrentRow.Cells("預抓羽數").Value
        txtCatchCntNumber.Text = dgvDetail.CurrentRow.Cells("磅單羽數").Value
        txtRealCntNumber.Text = dgvDetail.CurrentRow.Cells("實際羽數").Value
        txtCntDiff.Text = dgvDetail.CurrentRow.Cells("羽數差異").Value
        txtPackNumber.Text = dgvDetail.CurrentRow.Cells("包裝數").Value
        txtDeathNumber.Text = dgvDetail.CurrentRow.Cells("死亡數").Value
        txtDeathWeight.Text = dgvDetail.CurrentRow.Cells("死亡重").Value
        txtDropNumber.Text = dgvDetail.CurrentRow.Cells("廢棄數").Value
        txtDropWeight.Text = dgvDetail.CurrentRow.Cells("廢棄重").Value
        txtRainPercent.Text = dgvDetail.CurrentRow.Cells("含水%數").Value
        txtRainWeight.Text = dgvDetail.CurrentRow.Cells("含水重").Value
        txtU_M03.Text = dgvDetail.CurrentRow.Cells("製造單號").Value
        txtAvgWeight.Text = dgvDetail.CurrentRow.Cells("平均重").Value
        txtRealAvgWeight.Text = dgvDetail.CurrentRow.Cells("實際平均重").Value
        txtMeasuredWeight.Text = dgvDetail.CurrentRow.Cells("磅單重").Value
        txtTotalRealWeight.Text = dgvDetail.CurrentRow.Cells("實際總重").Value
        txtRealWeightDiff.Text = dgvDetail.CurrentRow.Cells("重量差異").Value
        txtComments.Text = dgvDetail.CurrentRow.Cells("備註").Value

    End Sub

    Private Sub UpdateItemDetail()
        dgvDetail.CurrentRow.Cells("來源").Value = cobSourceFrom.Text
        dgvDetail.CurrentRow.Cells("牧場名稱").Value = txtFarmName.Text
        dgvDetail.CurrentRow.Cells("牧場代號").Value = txtFarmID.Text
        dgvDetail.CurrentRow.Cells("順序").Value = cobCarEntryNumber.Text
        dgvDetail.CurrentRow.Cells("品名").Value = cobTypeName.Text
        dgvDetail.CurrentRow.Cells("特殊").Value = cobTypeSpecial.Text
        dgvDetail.CurrentRow.Cells("預抓羽數").Value = txtPreCntNumber.Text
        dgvDetail.CurrentRow.Cells("磅單羽數").Value = txtCatchCntNumber.Text
        dgvDetail.CurrentRow.Cells("實際羽數").Value = txtRealCntNumber.Text
        dgvDetail.CurrentRow.Cells("羽數差異").Value = txtCntDiff.Text
        dgvDetail.CurrentRow.Cells("包裝數").Value = txtPackNumber.Text
        dgvDetail.CurrentRow.Cells("死亡數").Value = txtDeathNumber.Text
        dgvDetail.CurrentRow.Cells("死亡重").Value = txtDeathWeight.Text
        dgvDetail.CurrentRow.Cells("廢棄數").Value = txtDropNumber.Text
        dgvDetail.CurrentRow.Cells("廢棄重").Value = txtDropWeight.Text
        dgvDetail.CurrentRow.Cells("含水%數").Value = txtRainPercent.Text
        dgvDetail.CurrentRow.Cells("含水重").Value = txtRainWeight.Text
        dgvDetail.CurrentRow.Cells("製造單號").Value = txtU_M03.Text
        dgvDetail.CurrentRow.Cells("平均重").Value = txtAvgWeight.Text
        dgvDetail.CurrentRow.Cells("實際平均重").Value = txtRealAvgWeight.Text
        dgvDetail.CurrentRow.Cells("磅單重").Value = txtMeasuredWeight.Text
        dgvDetail.CurrentRow.Cells("實際總重").Value = txtTotalRealWeight.Text
        dgvDetail.CurrentRow.Cells("重量差異").Value = txtRealWeightDiff.Text
        dgvDetail.CurrentRow.Cells("備註").Value = txtComments.Text

    End Sub

    Private Sub UpdateToDB()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [@Transportation] SET DocDate = '" & dateDocDate.Value.Date & "',CarIDNumber = '" & txtCarIDNumber.Text & "',MeasuredByKS = " & txtMeasuredByKS.Text & ",TotalWeight = " & txtTotalWeight.Text & ",WeightDiff = " & txtWeightDiff.Text & " Where [CarEntry] = '" & txtCarEntry.Text & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()


            For i As Integer = 0 To dgvDetail.RowCount - 1
                sql = "UPDATE [@Transportation1] SET DocDate = '" & dateDocDate.Value.Date & "',SourceFrom = '" & dgvDetail.Rows(i).Cells("來源").Value & "',FarmName = '" & dgvDetail.Rows(i).Cells("牧場名稱").Value & "',FarmID = '" & dgvDetail.Rows(i).Cells("牧場代號").Value & "',CarOrder = '" & dgvDetail.Rows(i).Cells("順序").Value & "',TypeName = '" & dgvDetail.Rows(i).Cells("品名").Value & "',TypeSpecial = '" & dgvDetail.Rows(i).Cells("特殊").Value & "',PreCntNumber = " & dgvDetail.Rows(i).Cells("預抓羽數").Value & ", CatchCntNumber = " & dgvDetail.Rows(i).Cells("磅單羽數").Value & ",RealCntNumber =  " & dgvDetail.Rows(i).Cells("實際羽數").Value & ",CntDiff =  " & dgvDetail.Rows(i).Cells("羽數差異").Value & ",PackNumber =  " & dgvDetail.Rows(i).Cells("包裝數").Value & ",DeathNumber =  " & dgvDetail.Rows(i).Cells("死亡數").Value & ",DeathWeight =  " & dgvDetail.Rows(i).Cells("死亡重").Value & ",DropNumber =  " & dgvDetail.Rows(i).Cells("廢棄數").Value & ",DropWeight =  " & dgvDetail.Rows(i).Cells("廢棄重").Value & ",RainPercent =  " & dgvDetail.Rows(i).Cells("含水%數").Value & ",RainWeight =  " & dgvDetail.Rows(i).Cells("含水重").Value & ",U_M03 =  '" & dgvDetail.Rows(i).Cells("製造單號").Value & "',AvgWeight =  " & dgvDetail.Rows(i).Cells("平均重").Value & ",RealAvgWeight =  " & dgvDetail.Rows(i).Cells("實際平均重").Value & ",MeasuredWeight =  " & dgvDetail.Rows(i).Cells("磅單重").Value & ",TotalRealWeight =  " & dgvDetail.Rows(i).Cells("實際總重").Value & ",RealWeightDiff =  " & dgvDetail.Rows(i).Cells("重量差異").Value & ",Comments = '" & dgvDetail.Rows(i).Cells("備註").Value & "' Where [CarEntry] = '" & txtCarEntry.Text & "' and [LineNum] = '" & dgvDetail.Rows(i).Cells("列號").Value & "' "
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("更新失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("更新至資料庫完成!", 64, "成功")
    End Sub

    Private Sub QueryTransport()
        If dgvSearch.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
        If dgvDetail.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapterDGV As SqlDataAdapter

        sql = "Select T0.[DocDate] as '日期',T0.[CarEntry] as '單號',T1.[CarOrder] as '順序',T1.[FarmName] as '牧場名稱',T1.[FarmID] as '牧場代號',T1.[RealAvgWeight] as '實際平均重',T1.[AvgWeight] as '平均重',T1.[SourceFrom] as '來源',T1.[TypeName] as '品名',T1.[TypeSpecial] as '特殊',T1.[PreCntNumber] as '預抓羽數',T1.[CatchCntNumber] as '磅單羽數',T1.[PackNumber] as '包裝數',T1.[DeathNumber] as '死亡數',T1.[DropNumber] as '廢棄數',T1.[U_M03] as '製造單號',T0.[CarIDNumber] as '車牌號',T0.[MeasuredByKS] as '公司會磅',T1.[MeasuredWeight] as '磅單重',T0.[WeightDiff] as '磅差',T1.[Comments] as '備註' From [@Transportation] T0 inner join [@Transportation1] T1 ON T0.CarEntry = T1.CarEntry Where T0.[DocDate] = '" & dateDocDateSearch.Value.Date & "' and T1.[Cancel] = 'N' Order By T1.[CarOrder], T1.[U_M03] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        dgvSearch.DataSource = ks1DataSetDGV.Tables("DT1")
        dgvSearch.AutoResizeColumns()

    End Sub

    Private Sub dgvSearch_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSearch.CellClick
        If dgvSearch.RowCount <= 0 Then
            Exit Sub
        End If

        udCarEntry = dgvSearch.CurrentRow.Cells("單號").Value

        Dim oAns As Boolean = chkCarEntry(udCarEntry)
        If oAns = True Then
            LoadData1(udCarEntry)
            LoadData2(udCarEntry)
            CleanBody()

        Else
            MsgBox("查無此單號號碼!", 16, "錯誤")
            btnUpDateDetail.Visible = False
            btnAddToDB.Visible = False
        End If

    End Sub
   
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        QueryTransport()
    End Sub

    Private Sub btnAddToDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDetail.Click
        If cobTypeName.Text = "" Or txtPreCntNumber.Text = "" Or txtAvgWeight.Text = "" Then
            MsgBox("項目資料錯誤!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增項目至資料庫 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub        
        End If

        AddItemDetail()
        LoadData2(udCarEntry)
        CalcTotalWeight()
        CleanBody()
    End Sub

    Private Sub AddItemDetail()
        Dim i As Integer
        i = FindLineNum()
        If i = 0 Then
            MsgBox("載入FindLineNum資料失敗!", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()       

        Try

            sql = "INSERT INTO [@Transportation1] (CarEntry,DocDate,LineNum,SourceFrom,FarmName,FarmID,CarOrder,TypeName,TypeSpecial,PreCntNumber,CatchCntNumber,RealCntNumber,CntDiff,PackNumber,DeathNumber,DeathWeight,DropNumber,DropWeight,RainPercent,RainWeight,U_M03,AvgWeight,RealAvgWeight,MeasuredWeight,TotalRealWeight,RealWeightDiff,Comments) VALUES " & _
                  " ('" & txtCarEntry.Text & "','" & dateDocDate.Value.Date & "'," & i & ",'" & cobSourceFrom.Text & "','" & txtFarmName.Text & "','" & txtFarmID.Text & "','" & cobCarEntryNumber.Text & "','" & cobTypeName.Text & "','" & cobTypeSpecial.Text & "', " & txtPreCntNumber.Text & ", " & txtCatchCntNumber.Text & ", " & txtRealCntNumber.Text & ", " & txtCntDiff.Text & ", " & txtPackNumber.Text & ", " & txtDeathNumber.Text & ", " & txtDeathWeight.Text & ", " & txtDropNumber.Text & ", " & txtDropWeight.Text & ", " & txtRainPercent.Text & ", " & txtRainWeight.Text & ", '" & txtU_M03.Text & "', " & txtAvgWeight.Text & ", " & txtRealAvgWeight.Text & ", " & txtMeasuredWeight.Text & ", " & txtTotalRealWeight.Text & ", " & txtRealWeightDiff.Text & ",'" & txtComments.Text & "' )"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("新增項目完成!", 64, "成功")

    End Sub

    Private Function FindLineNum()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim oReturn As Integer

        sql = "SELECT TOP 1 [LineNum] FROM [@Transportation1] Where [CarEntry] = '" & txtCarEntry.Text & "' Order By LineNum desc"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            oReturn = sqlReader.Item("LineNum") + 1
        Else            
            oReturn = 0
        End If

        sqlReader.Close()

        Return oReturn

    End Function

    Private Sub btnDeleteDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteDetail.Click
        If cobTypeName.Text = "" Or txtPreCntNumber.Text = "" Or txtAvgWeight.Text = "" Then
            MsgBox("項目資料錯誤!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要刪除項目至資料庫 ?", 36, "刪除")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        DelItemDetail()
        LoadData2(udCarEntry)
        CalcTotalWeight()
        CleanBody()
    End Sub

    Private Sub DelItemDetail()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "UPDATE [@Transportation1] SET Cancel = 'Y' Where [CarEntry] = '" & txtCarEntry.Text & "' and [LineNum] = '" & dgvDetail.CurrentRow.Cells("列號").Value & "' "
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("刪除失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("刪除項目完成!", 64, "成功")
    End Sub
End Class