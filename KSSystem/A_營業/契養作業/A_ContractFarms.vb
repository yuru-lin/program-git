Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_ContractFarms
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub A_ContractFarms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ItemDGV.ContextMenuStrip = MainForm.ContextMenuStrip1
        If Login.LoginType = 2 Then
            AddToB1Btn.Enabled = False
        End If
    End Sub

    Private Sub CardCodet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardCode.LostFocus
        SelectCardCode()
        If ItemDGV.RowCount > 0 Then
            ClearAll()
        End If
    End Sub

    Private Sub CardName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardName.LostFocus
        SelectCardName()
        If ItemDGV.RowCount > 0 Then
            ClearAll()
        End If
    End Sub

    Private Sub ClearAll()
        CardName.Text = ""
        CardCode.Text = ""
        ks1DataSetDGV.Tables("DT1").Clear()
        StartDate.Value = Today
        EndDate.Value = Today
        U_C01.Text = ""
        U_C02.Text = ""
    End Sub

    Private Sub SelectCardCode()
        If CardCode.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'C' and left([CardCode],2) = 'A2' and [CardCode] = '" & CardCode.Text & "'"
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()
        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            MsgBox("查無此人", 16, "錯誤")
            CardName.Text = ""
            CardCode.Text = ""
            CardCode.Focus()
        Else
            CardName.Text = sqlReader.Item("CardName")
            sqlReader.Close()
        End If
    End Sub

    Private Sub SelectCardName()
        If CardName.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        If DBConn.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            DBConn.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If


        sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'C' and left([CardCode],2) = 'A2' and [CardName] = '" & CardName.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            SelectCustForFarm.Show()
        Else
            CardCode.Text = sqlReader.Item("CardCode")
            sqlReader.Close()
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If CardCode.Text = "" Then
            MsgBox("客戶編號未填!", 16, "錯誤")
            CardCode.Focus()
            Exit Sub
        End If
        If CardName.Text = "" Then
            MsgBox("客戶名稱未填!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If

        If CodeBox.Text = "" Then
            MsgBox("合約別碼未填!", 16, "錯誤")
            CodeBox.Focus()
            Exit Sub
        End If


        If ItemDGV.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        sql = "SELECT T0.[itemCode] as '項目號碼', T0.[itemName] as '項目說明', T0.[internalSN] as '序號' FROM OINS T0 WHERE T0.[customer] = '" & CardCode.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        ItemDGV.DataSource = ks1DataSetDGV.Tables("DT1")
        ItemDGV.AutoResizeColumns()
        AddU_C01()
        AddU_C03()

    End Sub

    Private Sub AddU_C03()
        Dim C01 As String = "" : Dim C02 As String = "" : Dim C01s As String = "" : Dim C02s As String = ""
        C01s = U_C01.Text : C02s = U_C02.Text
        C01 = C01s & UCase(CodeBox.Text) : C02 = Mid(C02s, 1, 10) & UCase(CodeBox.Text) & Mid(C02s, 11, 14)
        U_C01.Text = C01 : U_C02.Text = C02
    End Sub


    Private Sub AddU_C01()
        If CardCode.Text = "" Then
            MsgBox("客戶編號未填!", 16, "錯誤")
            CardCode.Focus()
            Exit Sub
        End If
        If CardName.Text = "" Then
            MsgBox("客戶名稱未填!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "M91105A"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.Parameters.Add(New SqlParameter("@dt", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@Ct", SqlDbType.NVarChar))
        SQLCmd.Parameters("@dt").Value = StartDate.Value.Date
        SQLCmd.Parameters("@Ct").Value = CardCode.Text


        If DBConn.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            DBConn.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            MsgBox("合約編號錯誤!", 16, "錯誤")
            Exit Sub
        Else
            U_C01.Text = sqlReader.Item("U_C01")
            sqlReader.Close()
        End If
        AddU_C02()
    End Sub

    Private Sub AddU_C02()
        If CardCode.Text = "" Then
            MsgBox("客戶編號未填!", 16, "錯誤")
            CardCode.Focus()
            Exit Sub
        End If
        If CardName.Text = "" Then
            MsgBox("客戶名稱未填!", 16, "錯誤")
            CardName.Focus()
            Exit Sub
        End If
        If U_C01.Text = "" Then
            MsgBox("合約編號錯誤!", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader

        sql = "M91106A"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.Parameters.Add(New SqlParameter("@dt", SqlDbType.NVarChar))
        SQLCmd.Parameters("@dt").Value = U_C01.Text

        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If Not sqlReader.HasRows() Then
            sqlReader.Close()
            MsgBox("契養批號錯誤!", 16, "錯誤")
            Exit Sub
        Else
            U_C02.Text = sqlReader.Item("U_C02")
            sqlReader.Close()
        End If

        '查詢完成，將資料庫連線關閉 add 2014/01/20
        DBConn.Close()
    End Sub

    Private Sub AddToB1Btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToB1Btn.Click

        '===========================================將系統自動產生的契養批號也insert到契養結算報表 乙諒===============================================
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim Sql As String

        If U_C02.Text = "" Then
            MessageBox.Show("新增失敗：請產生契養批號!!")
            Exit Sub
        End If

        '寫入前判斷契養批號是否有重複寫入
        Sql = "SELECT * FROM  KaiShingPlug.dbo.FdCk  WHERE  [SerialID] = '" & U_C02.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = Sql

        DBConn.Open() 'add 2014/01/20
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            sqlReader.Close()
            MsgBox("契養批號重複寫入!")
            DBConn.Close()
            Return
        Else
            sqlReader.Close()
        End If

        Dim insertcommand As SqlCommand = DBConn.CreateCommand()
        Dim insertdetailcommand As SqlCommand = DBConn.CreateCommand()

        insertcommand.CommandText = "INSERT INTO  KaiShingPlug.dbo.FdCk(SerialID) " & _
        "VALUES (@SerialID)"
        Try
            insertcommand.Parameters.Add("@SerialID", Data.SqlDbType.VarChar).Value = U_C02.Text()
            insertcommand.ExecuteNonQuery()
            MsgBox("資料insert成功")
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("資料inert錯誤...." & ex.Message, "Insert Records")
            DBConn.Close()
        Finally
            DBConn.Close()
        End Try

        '=============================================================================================================================

        If ItemDGV.RowCount <= 0 Then
            MsgBox("無項目資料!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要新增至SAP B1 ?", 36, "新增")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oScts As SAPbobsCOM.ServiceContracts
        Dim RetVal As Long

        oScts = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oServiceContracts) 'BoObjectTypes Service Contracts

        oScts.CustomerCode = CardCode.Text
        oScts.StartDate = StartDate.Value.Date
        oScts.EndDate = EndDate.Value.Date
        oScts.UserFields.Fields.Item("U_C01").Value = U_C01.Text
        oScts.UserFields.Fields.Item("U_C02").Value = U_C02.Text

        For i As Integer = 0 To ItemDGV.RowCount - 1

            oScts.Lines.SetCurrentLine(i)
            oScts.Lines.ItemCode = ItemDGV.Rows(i).Cells("項目號碼").Value '項目號碼
            oScts.Lines.InternalSerialNum = ItemDGV.Rows(i).Cells("序號").Value
            oScts.Lines.Add()
        Next
        RetVal = oScts.Add

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("新增至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        MsgBox("新增至B1完成!!", 64, "完成")
        ClearAll()

    End Sub
End Class
