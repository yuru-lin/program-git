Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_AddTransportation
    Public Source As String
    Dim dsPDAIn As New DataTable
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim DataAdapterDGV As SqlDataAdapter
    Dim udCarEntry As String
    Dim AnsHasRow As Boolean

    Private Sub B_AddTransportation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvDetail.ContextMenuStrip = MainForm.ContextMenuStrip1
        dateDocDate.Value = dateDocDate.Value.Date.AddDays(1)

        setCarEntry()
        cobRainPercent.SelectedIndex = 0
        btnAddToDetail.Text = "新增項目"
        btnAddToDB.Text = "新增至資料庫"
        AddColumn()

        Label48.Text = ""

        '隱藏單價
        Dim UserName As String
        UserName = Login.LogonUserName.ToUpper()
        Select Case UserName
            Case "MANAGER", "KS06"

                Label15.Visible = True
                txtPricePerTWKG.Visible = True
                Label16.Visible = True
                txtPricePerKG.Visible = True
                Label45.Visible = True
        End Select

        '設定顏色
        Label1.ForeColor = Color.Red
        Label5.ForeColor = Color.Red
        Label3.ForeColor = Color.Red
        Label2.ForeColor = Color.Red
        Label6.ForeColor = Color.Red
        Label13.ForeColor = Color.Red
        Label17.ForeColor = Color.Red
        Label39.ForeColor = Color.Red
        Label15.ForeColor = Color.Red
        Label12.ForeColor = Color.Red
        Label23.ForeColor = Color.Red
        Label47.ForeColor = Color.Red
        Label14.ForeColor = Color.Red

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
        '日期
        setCarEntry()
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
    Private Sub txtPricePerTWKG_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPricePerTWKG.TextChanged
        CalcPricePerKG()
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

        sql = "SELECT TOP 1 [CarEntry],left([CarEntry],6) as '左日期',right([CarEntry],2) as '右序號'  FROM [@Transportation] WHERE [DocDate] = '" & dateDocDate.Value.Date & "' Order By [CarEntry] DESC"
        'sql = "SELECT top 1 [CarEntry],left([CarEntry],6) as '左日期',right([CarEntry],2) as '右序號'  FROM [@Transportation] Order By [CarEntry] DESC"

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

        chkCarEntry(EntryNum)

    End Sub

    '檢查單號重複
    'Private Function chkCarEntry(ByVal CarEntry As String)
    Private Function chkCarEntry(ByVal EntryNum As String)
        'Dim AnsHasRow As Boolean

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        'sql = "SELECT [CarEntry] FROM [@Transportation] WHERE [CarEntry] = '" & CarEntry & "'"
        sql = "SELECT [CarEntry] FROM [@Transportation] WHERE [CarEntry] = '" & EntryNum & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            AnsHasRow = True

        Else
            AnsHasRow = False

        End If

        If AnsHasRow = True Then
            Label48.Text = "單號重覆"
            Label48.ForeColor = Color.Red
        Else
            Label48.Text = ""
            'Label48.ForeColor = Color.Black
        End If



        sqlReader.Close()

        Return AnsHasRow

    End Function


    '選擇契養批號
    Private Sub SourceFrom()
        Select Case cobSourceFrom.SelectedIndex
            Case 0
                lblU_M03.Text = "1"
                SelectFarmName.Source = "Add"
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

    '計算公斤單價
    Private Sub CalcPricePerKG()
        Dim PricePerTWKG As Double

        If txtPricePerTWKG.Text = "" Then
            PricePerTWKG = 0
        Else
            PricePerTWKG = CDbl(Trim(txtPricePerTWKG.Text))
        End If

        If PricePerTWKG = 0 Then
            Exit Sub
        End If

        txtPricePerKG.Text = Format(CDbl(PricePerTWKG / 0.6), "#0.####")
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
    Private Sub txtPricePerTWKG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerTWKG.KeyPress

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

    '加入欄位
    Private Sub AddColumn()
        'declaring a column named Name
        Dim SourceFrom As DataColumn = New DataColumn("來源")
        Dim FarmName As DataColumn = New DataColumn("牧場名稱")
        Dim FarmID As DataColumn = New DataColumn("牧場代號")
        Dim CarOrder As DataColumn = New DataColumn("順序")
        Dim TypeName As DataColumn = New DataColumn("品名")
        Dim TypeSpecial As DataColumn = New DataColumn("特殊")
        Dim PreCntNumber As DataColumn = New DataColumn("預抓羽數")
        Dim CatchCntNumber As DataColumn = New DataColumn("磅單羽數")
        Dim RealCntNumber As DataColumn = New DataColumn("實際羽數")
        Dim CntDiff As DataColumn = New DataColumn("羽數差異")
        Dim PackNumber As DataColumn = New DataColumn("包裝數")
        Dim DeathNumber As DataColumn = New DataColumn("死亡數")
        Dim DeathWeight As DataColumn = New DataColumn("死亡重")
        Dim DropNumber As DataColumn = New DataColumn("廢棄數")
        Dim DropWeight As DataColumn = New DataColumn("廢棄重")
        Dim RainPercent As DataColumn = New DataColumn("含水%數")
        Dim RainWeight As DataColumn = New DataColumn("含水重")
        Dim U_M03 As DataColumn = New DataColumn("製造單號")
        Dim AvgWeight As DataColumn = New DataColumn("平均重")
        Dim RealAvgWeight As DataColumn = New DataColumn("實際平均重")
        Dim MeasuredWeight As DataColumn = New DataColumn("磅單重")
        Dim TotalRealWeight As DataColumn = New DataColumn("實際總重")
        Dim RealWeightDiff As DataColumn = New DataColumn("重量差異")
        Dim PricePerTWKG As DataColumn = New DataColumn("台斤單價")
        Dim PricePerKG As DataColumn = New DataColumn("公斤單價")
        Dim Comments As DataColumn = New DataColumn("備註")

        'setting the datatype for the column
        SourceFrom.DataType = System.Type.GetType("System.String")
        FarmName.DataType = System.Type.GetType("System.String")
        FarmID.DataType = System.Type.GetType("System.String")
        CarOrder.DataType = System.Type.GetType("System.String")
        TypeName.DataType = System.Type.GetType("System.String")
        TypeSpecial.DataType = System.Type.GetType("System.String")
        PreCntNumber.DataType = System.Type.GetType("System.Decimal")
        CatchCntNumber.DataType = System.Type.GetType("System.Decimal")
        RealCntNumber.DataType = System.Type.GetType("System.Decimal")
        CntDiff.DataType = System.Type.GetType("System.Decimal")
        PackNumber.DataType = System.Type.GetType("System.Decimal")
        DeathNumber.DataType = System.Type.GetType("System.Decimal")
        DeathWeight.DataType = System.Type.GetType("System.Double")
        DropNumber.DataType = System.Type.GetType("System.Decimal")
        DropWeight.DataType = System.Type.GetType("System.Double")
        RainPercent.DataType = System.Type.GetType("System.Decimal")
        RainWeight.DataType = System.Type.GetType("System.Double")
        U_M03.DataType = System.Type.GetType("System.String")
        AvgWeight.DataType = System.Type.GetType("System.Double")
        RealAvgWeight.DataType = System.Type.GetType("System.Double")
        MeasuredWeight.DataType = System.Type.GetType("System.Double")
        TotalRealWeight.DataType = System.Type.GetType("System.Double")
        RealWeightDiff.DataType = System.Type.GetType("System.Double")
        PricePerTWKG.DataType = System.Type.GetType("System.Double")
        PricePerKG.DataType = System.Type.GetType("System.Double")
        Comments.DataType = System.Type.GetType("System.String")

        'adding the column to table
        dsPDAIn.Columns.Add(SourceFrom)
        dsPDAIn.Columns.Add(FarmName)
        dsPDAIn.Columns.Add(FarmID)
        dsPDAIn.Columns.Add(CarOrder)
        dsPDAIn.Columns.Add(TypeName)
        dsPDAIn.Columns.Add(TypeSpecial)
        dsPDAIn.Columns.Add(PreCntNumber)
        dsPDAIn.Columns.Add(CatchCntNumber)
        dsPDAIn.Columns.Add(RealCntNumber)
        dsPDAIn.Columns.Add(CntDiff)
        dsPDAIn.Columns.Add(PackNumber)
        dsPDAIn.Columns.Add(DeathNumber)
        dsPDAIn.Columns.Add(DeathWeight)
        dsPDAIn.Columns.Add(DropNumber)
        dsPDAIn.Columns.Add(DropWeight)
        dsPDAIn.Columns.Add(RainPercent)
        dsPDAIn.Columns.Add(RainWeight)
        dsPDAIn.Columns.Add(U_M03)
        dsPDAIn.Columns.Add(AvgWeight)
        dsPDAIn.Columns.Add(RealAvgWeight)
        dsPDAIn.Columns.Add(MeasuredWeight)
        dsPDAIn.Columns.Add(TotalRealWeight)
        dsPDAIn.Columns.Add(RealWeightDiff)
        dsPDAIn.Columns.Add(PricePerTWKG)
        dsPDAIn.Columns.Add(PricePerKG)
        dsPDAIn.Columns.Add(Comments)

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
        txtPricePerTWKG.Text = "0"
        txtPricePerKG.Text = "0"
        txtComments.Text = ""
    End Sub

    '清空表頭跟表身
    Private Sub CleanAll()        
        setCarEntry()
        txtCarIDNumber.Text = ""
        txtMeasuredByKS.Text = "0"
        txtTotalWeight.Text = "0"
        txtWeightDiff.Text = "0"
        CleanBody()

        If dgvDetail.RowCount > 0 Then
            dsPDAIn.Clear()
        End If
    End Sub

    Private Sub btnAddToDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToDetail.Click
        If cobTypeName.Text = "" Or txtPreCntNumber.Text = "" Or txtAvgWeight.Text = "" Then
            MsgBox("項目資料錯誤!", 16, "錯誤")
            Exit Sub
        End If

            AddItemDetail()
            CalcTotalWeight()
            CleanBody()
    End Sub

    Private Sub AddItemDetail()

        Dim Rows As DataRow
        Rows = dsPDAIn.NewRow
        Rows.Item("來源") = cobSourceFrom.Text
        Rows.Item("牧場名稱") = txtFarmName.Text
        Rows.Item("牧場代號") = txtFarmID.Text
        Rows.Item("順序") = cobCarEntryNumber.Text
        Rows.Item("品名") = cobTypeName.Text
        Rows.Item("特殊") = cobTypeSpecial.Text
        Rows.Item("預抓羽數") = txtPreCntNumber.Text
        Rows.Item("磅單羽數") = txtCatchCntNumber.Text
        Rows.Item("實際羽數") = txtRealCntNumber.Text
        Rows.Item("羽數差異") = txtCntDiff.Text
        Rows.Item("包裝數") = txtPackNumber.Text
        Rows.Item("死亡數") = txtDeathNumber.Text
        Rows.Item("死亡重") = txtDeathWeight.Text
        Rows.Item("廢棄數") = txtDropNumber.Text
        Rows.Item("廢棄重") = txtDropWeight.Text
        Rows.Item("含水%數") = txtRainPercent.Text
        Rows.Item("含水重") = txtRainWeight.Text
        Rows.Item("製造單號") = txtU_M03.Text
        Rows.Item("平均重") = txtAvgWeight.Text
        Rows.Item("實際平均重") = txtRealAvgWeight.Text
        Rows.Item("磅單重") = txtMeasuredWeight.Text
        Rows.Item("實際總重") = txtTotalRealWeight.Text
        Rows.Item("重量差異") = txtRealWeightDiff.Text
        Rows.Item("台斤單價") = txtPricePerTWKG.Text
        Rows.Item("公斤單價") = txtPricePerKG.Text
        Rows.Item("備註") = txtComments.Text
        dsPDAIn.Rows.Add(Rows)

        dgvDetail.DataSource = dsPDAIn
        dgvDetail.AutoResizeColumns()
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

        oAns = MsgBox("確認要新增至資料庫 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        Else
            AddtoDB()
        End If

        CleanAll()
    End Sub

    Private Sub AddtoDB()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        Try

            sql = "INSERT INTO [@Transportation] (CarEntry,DocDate,CarIDNumber,MeasuredByKS,TotalWeight,WeightDiff) VALUES ('" & txtCarEntry.Text & "','" & dateDocDate.Value.Date & "','" & txtCarIDNumber.Text & "'," & txtMeasuredByKS.Text & "," & txtTotalWeight.Text & "," & txtWeightDiff.Text & ")"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.Transaction = tran
            SQLCmd.ExecuteNonQuery()

            For i As Integer = 0 To dgvDetail.RowCount - 1
                sql = "INSERT INTO [@Transportation1] (CarEntry,DocDate,LineNum,SourceFrom,FarmName,FarmID,CarOrder,TypeName,TypeSpecial,PreCntNumber,CatchCntNumber,RealCntNumber,CntDiff,PackNumber,DeathNumber,DeathWeight,DropNumber,DropWeight,RainPercent,RainWeight,U_M03,AvgWeight,RealAvgWeight,MeasuredWeight,TotalRealWeight,RealWeightDiff,PricePerTWKG,PricePerKG,Comments) VALUES ('" & txtCarEntry.Text & "','" & dateDocDate.Value.Date & "'," & i & ",'" & dgvDetail.Rows(i).Cells("來源").Value & "','" & dgvDetail.Rows(i).Cells("牧場名稱").Value & "','" & dgvDetail.Rows(i).Cells("牧場代號").Value & "','" & dgvDetail.Rows(i).Cells("順序").Value & "','" & dgvDetail.Rows(i).Cells("品名").Value & "','" & dgvDetail.Rows(i).Cells("特殊").Value & "', " & dgvDetail.Rows(i).Cells("預抓羽數").Value & ", " & dgvDetail.Rows(i).Cells("磅單羽數").Value & ", " & dgvDetail.Rows(i).Cells("實際羽數").Value & ", " & dgvDetail.Rows(i).Cells("羽數差異").Value & ", " & dgvDetail.Rows(i).Cells("包裝數").Value & ", " & dgvDetail.Rows(i).Cells("死亡數").Value & ", " & dgvDetail.Rows(i).Cells("死亡重").Value & ", " & dgvDetail.Rows(i).Cells("廢棄數").Value & ", " & dgvDetail.Rows(i).Cells("廢棄重").Value & ", " & dgvDetail.Rows(i).Cells("含水%數").Value & ", " & dgvDetail.Rows(i).Cells("含水重").Value & ", '" & dgvDetail.Rows(i).Cells("製造單號").Value & "', " & dgvDetail.Rows(i).Cells("平均重").Value & ", " & dgvDetail.Rows(i).Cells("實際平均重").Value & ", " & dgvDetail.Rows(i).Cells("磅單重").Value & ", " & dgvDetail.Rows(i).Cells("實際總重").Value & ", " & dgvDetail.Rows(i).Cells("重量差異").Value & ", " & dgvDetail.Rows(i).Cells("台斤單價").Value & ", " & dgvDetail.Rows(i).Cells("公斤單價").Value & ",'" & dgvDetail.Rows(i).Cells("備註").Value & "' )"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()
            Next

            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            MsgBox("新增失敗：" & vbCrLf & ex.Message, 16, "錯誤")
            Exit Sub
        End Try

        MsgBox("新增至資料庫完成!", 64, "成功")
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


End Class