Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class C_BatchChangeSpace
    Dim DataAdapter1 As SqlDataAdapter
    Dim ks1DataSet As DataSet = New DataSet
    Dim ADate As String

    Private Sub C_BatchChangeSpace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        locView.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub rbt1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt1.CheckedChanged
        ks1DataSet.Clear()
        OrgLoc.Clear()
        NewLoc.Clear()
        NewLoc.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub rbt2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbt2.CheckedChanged
        ks1DataSet.Clear()
        OrgLoc.Clear()
        NewLoc.Clear()
        NewLoc.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If locView.RowCount >= 0 Then
            ks1DataSet.Clear()
        End If

        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If rbt1.Checked Then
                sql = "SELECT T0.[ItemCode], T2.[ItemName], T0.[DistNumber], T0.[U_M2] FROM OSRN T0  left JOIN OSRQ T1 ON T0.SysNumber = T1.SysNumber and T0.ItemCode = T1.ItemCode left JOIN OITM T2 ON T0.ItemCode = T2.ItemCode WHERE T1.Quantity > 0 and T0.U_M2 = '" & OrgLoc.Text & "' order by T0.ItemCode"
            End If

            If rbt2.Checked Then
                sql = "SELECT T0.[ItemCode], T2.[ItemName], T0.[DistNumber], T0.[U_M2] FROM OBTN T0  left JOIN OBTQ T1 ON T0.SysNumber = T1.SysNumber and T0.ItemCode = T1.ItemCode Left JOIN OITM T2 ON T0.ItemCode = T2.ItemCode WHERE T1.Quantity > 0 and T0.U_M2 = '" & OrgLoc.Text & "' order by T0.ItemCode "
            End If
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            locView.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("LoadSourceMain: " & ex.Message)
            End
        End Try

        setLocViewDisplay()

    End Sub


    '設定dgvSourceMain顯示
    Private Sub setLocViewDisplay()

        For Each column As DataGridViewColumn In locView.Columns
            column.Visible = True
            Select Case column.Name
                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 0
                Case "ItemName"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 1
                Case "DistNumber"
                    column.HeaderText = "條碼序號"
                    column.DisplayIndex = 2
                Case "U_M2"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 3

                Case Else
                    column.Visible = False
            End Select
        Next
        locView.AutoResizeColumns()
        Label2.Text = locView.RowCount
        NewLoc.Enabled = True
        Button2.Enabled = True
        Button4.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If NewLoc.Text = "" Then
            MsgBox("目的儲位未輸入!!")
            Exit Sub
        End If

        If locView.RowCount <= 0 Then
            Exit Sub
        End If

        QryLoc()
        If DGV1.RowCount > 0 Then
            Dim oTotal As Integer
            oTotal = CInt(DGV1.CurrentRow.Cells("數量").Value) + CInt(locView.RowCount)
            If oTotal > DGV1.CurrentRow.Cells("最大數").Value Then
                Dim oAns As Integer
                oAns = MsgBox("數量已大於該儲位最大數!" & vbCrLf & "是否要繼續變更儲位?", 36, "警告")
                If oAns = MsgBoxResult.No Then
                    Exit Sub
                Else
                    QryAdate()
                    DoingSQL()
                End If
            Else
                QryAdate()
                DoingSQL()
            End If
        Else
            QryAdate()
            DoingSQL()
        End If


    End Sub

    Private Sub QryLoc()

        Dim QType As Integer
        If rbt1.Checked Then
            QType = 1
        Else
            QType = 2
        End If

        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Try
            sql = "exec L20111221 '" & NewLoc.Text & "','" & QType & "'"
            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql
            SQLCmd.CommandType = CommandType.StoredProcedure

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ksDataSet, "DT2")
            DGV1.DataSource = ksDataSet.Tables("DT2")
        Catch ex As Exception
            MsgBox("QryLoc: " & ex.Message)
            End
        End Try

        DGV1.AutoResizeColumns()
    End Sub

    Private Sub QryAdate()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        ADate = Format(Now, "yyyyMMdd")

        sql = "SELECT top 1 T0.DocNum FROM [@ChgLocMgn] T0 Order by T0.DocNum desc"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()

        If sqlReader.HasRows() Then
            If ADate = Microsoft.VisualBasic.Left(sqlReader.Item("DocNum"), 8) Then
                ADate = sqlReader.Item("DocNum") + 1
            Else
                ADate = ADate + "0001"
            End If
        Else
            ADate = ADate + "0001"
        End If
        sqlReader.Close()
    End Sub

    Private Sub DoingSQL()
        Dim SNType As String
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim tran As SqlTransaction = DBConn.BeginTransaction()

        PBar1.Minimum = 0
        PBar1.Maximum = locView.Rows.Count - 1
        Try
            For i As Integer = 0 To locView.RowCount - 1
                If rbt1.Checked Then
                    SNType = "1"
                    sql = "Update OSRN set U_M2 = '" & NewLoc.Text & "' where  DistNumber = '" & locView.Rows(i).Cells("DistNumber").Value & "'"
                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()
                End If

                If rbt2.Checked Then
                    SNType = "2"
                    sql = "Update OBTN set U_M2 = '" & NewLoc.Text & "' where  DistNumber = '" & locView.Rows(i).Cells("DistNumber").Value & "'"
                    SQLCmd.Connection = DBConn
                    SQLCmd.CommandText = sql
                    SQLCmd.Transaction = tran
                    SQLCmd.ExecuteNonQuery()
                End If

                sql = "INSERT INTO [@ChgLocMgn] (DocNum,SRNType,FromLoc,DistNumber,ItemCode,ItemName,ToLoc) VALUES ('" & ADate & "','" & SNType & "','" & locView.Rows(i).Cells("U_M2").Value & "','" & locView.Rows(i).Cells("DistNumber").Value & "','" & locView.Rows(i).Cells("ItemCode").Value & "','" & locView.Rows(i).Cells("ItemName").Value & "','" & NewLoc.Text & "')"
                SQLCmd.Connection = DBConn
                SQLCmd.CommandText = sql
                SQLCmd.Transaction = tran
                SQLCmd.ExecuteNonQuery()

                PBar1.Value = i
            Next
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            If MessageBox.Show("更新失敗：" & vbCrLf & ex.Message & vbCrLf & "是否要重試?", "錯誤", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Retry Then
                DoingSQL()
            Else
                MsgBox("更新失敗", 16, "失敗")
                Exit Sub
            End If
            Exit Sub
        End Try

        MsgBox("更新儲位資料OK!" & vbCrLf & "調整單號：" & ADate, MsgBoxStyle.OkOnly, "成功")

        ks1DataSet.Clear()
        NewLoc.Clear()
        NewLoc.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataToExcel(locView, "")
    End Sub
End Class