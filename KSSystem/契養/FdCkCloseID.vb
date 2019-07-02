Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class FdCkCloseID
    Private Sub FdCkCloseID_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SelectCName()
    End Sub

    Private Sub SelectCName()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim DataAdapter1 As SqlDataAdapter
        Dim ks1DataSet As DataSet = New DataSet

        sql = "SELECT T0.[CstmrCode] as '客編', T0.[CstmrName] as '名稱', T0.[U_C02] as '契養批號' FROM OCTR T0 WHERE T0.[Status] = 'D'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ks1DataSet, "DT1")

        FdCkCloseIDGV.DataSource = ks1DataSet.Tables("DT1")
        FdCkCloseIDGV.AutoResizeColumns()
    End Sub

    Private Sub FdCkCloseIDSelectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FdCkCloseIDSelectBtn.Click
        Dim SerialID As String
        Dim CardName As String
        Dim I_CardCode As String

        SerialID = FdCkCloseIDGV.CurrentRow.Cells("契養批號").Value
        I_CardCode = FdCkCloseIDGV.CurrentRow.Cells("客編").Value
        CardName = FdCkCloseIDGV.CurrentRow.Cells("名稱").Value

        '===========================================將系統自動產生的結算契養批號也insert到契養結算報表 乙諒===============================================
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Dim Sql As String

        '寫入前判斷契養批號是否有重複寫入
        Sql = "SELECT * FROM  KaiShingPlug.dbo.FdCk  WHERE  [SerialID] = '" + SerialID + "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = Sql

        If DBConn.State = ConnectionState.Closed Then
            'MessageBox.Show("資料庫連線關閉!")
            DBConn.Open()
        Else
            'MessageBox.Show("資料庫連線開啟!!")
        End If

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

        '設定資料庫連線  insert到主表單，表頭資料
        Dim insertcommand As SqlCommand = DBConn.CreateCommand()
        Dim insertdetailcommand As SqlCommand = DBConn.CreateCommand()

        insertcommand.CommandText = "INSERT INTO  KaiShingPlug.dbo.FdCk(SerialID,CardName,I_CardCode) " & _
        "VALUES (@SerialID,@CustID,@CustNo1)"
        Try
            insertcommand.Parameters.Add("@SerialID", Data.SqlDbType.VarChar).Value = SerialID      '契養批號
            insertcommand.Parameters.Add("@CustID", Data.SqlDbType.VarChar).Value = CardName         '客戶名稱
            insertcommand.Parameters.Add("@CustNo1", Data.SqlDbType.VarChar).Value = I_CardCode        '客戶編號1
            insertcommand.ExecuteNonQuery()
            MsgBox("資料insert成功")
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show("資料inert錯誤...." & ex.Message, "Insert Records")
        End Try
        DBConn.Close()
        '=============================================================================================================================
        Me.Close()
    End Sub
End Class