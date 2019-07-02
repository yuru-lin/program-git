Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class C_QckAddChickenOutOIGE
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub C_QckAddChickenOutOIGE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvByM03.ContextMenuStrip = MainForm.ContextMenuStrip1
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ClearAll()
        QueryByM03()
    End Sub

    Private Sub QueryByM03()
        If dgvByM03.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "select T0.U_M03 as '製單單號', T0.ItemCode as '存編',T1.ItemName as '品名', cast(T0.U_M07 as numeric(19,2)) as '投入重量',cast(T0.U_M12 as numeric(19,2)) as '投入隻數',cast(T1.OnHand as numeric(19,2)) as '庫存量' From OWOR T0 left join OITM T1 ON T0.ItemCode = T1.ItemCode Where T0.U_M01 = '1' and T0.DueDate = '" & dateDocDate.Value.Date & "' Order By T0.U_M03"
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")

        dgvByM03.DataSource = ks1DataSetDGV.Tables("DT3")
        dgvByM03.AutoResizeColumns()

    End Sub

    Private Sub dgvByM03_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvByM03.CellClick
        If dgvByM03.RowCount <= 0 Then
            Exit Sub
        End If

        ClearAll()

        txtItemCode.Text = dgvByM03.CurrentRow.Cells("存編").Value
        txtItemName.Text = dgvByM03.CurrentRow.Cells("品名").Value
        lbM03.Text = dgvByM03.CurrentRow.Cells("製單單號").Value
        txtM7.Text = dgvByM03.CurrentRow.Cells("投入重量").FormattedValue
        txtM12.Text = dgvByM03.CurrentRow.Cells("投入隻數").FormattedValue

    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(dgvByM03, "")
    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If dgvByM03.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If lbM03.Text = "" Then
            MsgBox("資料未選!", 16, "錯誤")
            Exit Sub
        End If

        If txtItemCode.Text = "" Then
            MsgBox("存編未填!", 16, "錯誤")
            Exit Sub
        End If

        Dim oOige As Boolean
        oOige = ChkOIGE()
        If oOige = True Then
            MsgBox("此製單與品項已發貨過，請查看!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要更新至SAP B1 ?" & vbCrLf & "製單：" & lbM03.Text, 36, "更新")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        ToB1()
    End Sub

    Private Sub ToB1()
        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oGoodIss As SAPbobsCOM.Documents
        Dim RetVal As Long

        oGoodIss = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit)

        oGoodIss.UserFields.Fields.Item("U_CK01").Value = "5"
        oGoodIss.UserFields.Fields.Item("U_CK02").Value = lbM03.Text
        oGoodIss.DocDate = dateDocDate.Value.Date

        oGoodIss.Lines.SetCurrentLine(0)
        oGoodIss.Lines.ItemCode = txtItemCode.Text
        oGoodIss.Lines.Quantity = txtM12.Text
        oGoodIss.Lines.UserFields.Fields.Item("U_p2").Value = txtM7.Text
        
        oGoodIss.Lines.Add()

        RetVal = oGoodIss.Add

        'Check the result
        If RetVal <> 0 Then

            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("B1發貨單錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            Exit Sub
        End If

        Dim DocNum As Integer
        DocNum = Login.oCompany.GetNewObjectKey()
        MsgBox("新增至B1發貨單完成!!" + vbCrLf + "發貨單單號：" & DocNum, 64, "完成")
        ClearAll()

    End Sub

    Private Sub ClearAll()

        lbM03.Text = ""
        txtM7.Text = ""        
        txtM12.Text = ""
        txtItemCode.Text = ""
        txtItemName.Text = ""

    End Sub

    Private Function ChkOIGE()
        Dim oAns As Boolean

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "Select T0.DocEntry FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.DocEntry = T1.DocEntry Where T0.U_CK01 = '5' and T0.U_CK02 = '" & lbM03.Text & "' and T1.ItemCode = '" & txtItemCode.Text & "' and T1.Quantity = '" & txtM12.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader

        If sqlReader.HasRows() Then
            sqlReader.Close()
            oAns = True
        Else
            sqlReader.Close()
            oAns = False
        End If

        Return oAns
    End Function
End Class