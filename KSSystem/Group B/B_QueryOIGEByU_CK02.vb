Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QueryOIGEByU_CK02

    Dim DataAdapterDGV, DataAdapter1 As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_QueryOIGEByU_CK02_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        If Login.LoginType = 2 Then
            SaveBtn.Enabled = False
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click        

        If txtM03.Text = "" Then
            MsgBox("製造單號未填!", 16, "錯誤")
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
        SearchM03()
        SearchQry()
    End Sub

    Private Sub SearchM03()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
       
        sql = "SELECT T0.DocNum, T0.U_M03 FROM OWOR T0 WHERE T0.U_M03 = '" & txtM03.Text & "'"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        sqlReader = SQLCmd.ExecuteReader
        sqlReader.Read()
        If sqlReader.HasRows() Then           
            lbDocNum.Text = sqlReader.Item("DocNum").ToString
            lbM03.Text = sqlReader.Item("U_M03").ToString
        End If
        
        sqlReader.Close()

    End Sub

    Private Sub SearchQry()

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        'sql = "SELECT T0.[DocEntry] ,T0.DocDate , T1.[ItemCode], T1.[Dscription], dbo.getRoundN(sum(T1.[Quantity]),0) as '數量', dbo.getRoundN(sum(T1.[U_p2]),2) as '重量' FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[U_CK02] = '" & txtM03.Text & "' GROUP BY T0.[DocEntry],T0.DocDate, T1.[ItemCode], T1.[Dscription]"
        'sql = "    SELECT T0.[DocEntry] ,T0.DocDate , T1.[ItemCode], T1.[Dscription], ISNULL(T3.[總隻數],0) AS '數量', dbo.getRoundN(sum(T1.[Quantity]),0) as '件數', dbo.getRoundN(sum(T1.[U_p2]),2) as '重量' "
        'sql += "     FROM [OIGE] T0 INNER JOIN [IGE1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
        'sql += "                    INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
        'sql += "                     LEFT JOIN (SELECT T0.[DocEntry] , T1.[ItemCode], dbo.getRoundN(T2.[SalPackUn] *(sum(T1.[Quantity])),0) AS '總隻數' "
        'sql += "                                  FROM [OIGE] T0 INNER JOIN [IGE1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
        'sql += "                                                 INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
        'sql += "                                 WHERE T0.[U_CK02] = '" & txtM03.Text & "' AND T2.[SalPackMsr] = '隻' "
        'sql += "                              GROUP BY T0.[DocEntry], T1.[ItemCode], T2.[SalPackUn]) T3 ON T0.[DocEntry] = T3.[DocEntry] AND T1.[ItemCode] = T3.[ItemCode] "
        'sql += "    WHERE T0.[U_CK02] = '" & txtM03.Text & "' "
        'sql += " GROUP BY T0.[DocEntry], T0.[DocDate], T1.[ItemCode], T1.[Dscription], T3.[總隻數] "
        'sql += " ORDER BY 1, 3 "

        sql = "    SELECT T0.[DocEntry] ,T0.DocDate , T1.[ItemCode], T1.[Dscription], dbo.getRoundN((T2.[SalPackUn] * T1.[Quantity]),0)  AS '數量', ISNULL(T2.[SalPackMsr],'') AS '單位', "
        sql += "          dbo.getRoundN(T1.[Quantity],0) as '件數', dbo.getRoundN(T1.[U_p2],2) as '重量' "
        sql += "     FROM [OIGE] T0 INNER JOIN [IGE1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
        sql += "                    INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
        sql += "    WHERE T0.[U_CK02] = '" & txtM03.Text & "' AND T0.[U_CK01] = '5'"
        sql += "   UNION ALL"
        sql += "   SELECT T0.[DocEntry] ,T0.DocDate , T1.[ItemCode], T1.[Dscription], dbo.getRoundN((-T2.[SalPackUn] * T1.[Quantity]),0) AS '數量', ISNULL(T2.[SalPackMsr],'') AS '單位', "
        sql += "          dbo.getRoundN(-T1.[Quantity],0) as '件數', dbo.getRoundN(-T1.[U_p2],2) as '重量' "
        sql += "     FROM [OIGN] T0 INNER JOIN [IGN1] T1 ON T0.[DocEntry] = T1.[DocEntry] "
        sql += "                    INNER JOIN [OITM] T2 ON T1.[ItemCode] = T2.[ItemCode] "
        sql += "    WHERE T0.[U_CK02] = '" & txtM03.Text & "' AND T0.[U_CK06] = '2'"
        sql += " ORDER BY 1, 3 "


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        
        DGV1Display()
    End Sub
    Private Sub DGV1Display()

        If DGV1.RowCount <= 0 Then
            MsgBox("查無資料!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True

            Select Case column.Name
                Case "DocEntry"
                    column.HeaderText = "發貨文件號碼"
                    column.DisplayIndex = 0

                Case "DocDate"
                    column.HeaderText = "文件日期"
                    column.DisplayIndex = 1

                Case "ItemCode"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 2

                Case "Dscription"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 3

                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 4

                Case "單位"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 5

                Case "件數"
                    column.HeaderText = "件數"
                    column.DisplayIndex = 6

                Case "重量"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###.##"                
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV1.AutoResizeColumns()

        Dim TotalOnly As Integer = 0
        Dim TotalCount As Integer = 0
        Dim TotalKG As Double = 0
        For i As Integer = 0 To DGV1.RowCount - 1
            'If Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "25" Or Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "21" Or Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "31" Then
            If Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "21" Or _
               Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "24" Or _
               Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "25" Or _
               Microsoft.VisualBasic.Left(DGV1.Rows(i).Cells("ItemCode").Value, 2) = "31" Then
                If DGV1.Rows(i).Cells("單位").Value = "隻" Then
                    TotalOnly += DGV1.Rows(i).Cells("數量").Value
                End If
                'TotalOnly += DGV1.Rows(i).Cells("數量").Value
                TotalCount += DGV1.Rows(i).Cells("件數").Value
                TotalKG += DGV1.Rows(i).Cells("重量").Value
            End If
        Next

        txtM7.Text = TotalKG
        txtM12.Text = TotalOnly
        txtM99.Text = TotalCount

    End Sub

    Private Sub SaveBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBtn.Click
        If DGV1.RowCount <= 0 Then
            MsgBox("無資料!", 16, "錯誤")
            Exit Sub
        End If

        If lbM03.Text = "" Then
            MsgBox("資料未選!", 16, "錯誤")
            Exit Sub
        End If

        Dim oAns As Integer
        oAns = MsgBox("確認要更新至SAP B1 ?" & vbCrLf & "單號：" & lbDocNum.Text + vbCrLf & "製單：" & lbM03.Text, 36, "更新")
        If oAns = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim ErrCode As Long
        Dim ErrMsg As String
        Dim oProductionOrders As SAPbobsCOM.ProductionOrders
        Dim RetVal As Long

        oProductionOrders = Login.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oProductionOrders)

        oProductionOrders.GetByKey(lbDocNum.Text)
        oProductionOrders.UserFields.Fields.Item("U_M07").Value = txtM7.Text
        oProductionOrders.UserFields.Fields.Item("U_M12").Value = txtM12.Text

        RetVal = oProductionOrders.Update()

        If RetVal <> 0 Then
            ErrCode = Login.oCompany.GetLastErrorCode()
            ErrMsg = Login.oCompany.GetLastErrorDescription()
            MsgBox("更新至B1錯誤! " & vbCrLf & ErrCode & vbCrLf & " " & ErrMsg, 16, "錯誤")
            ClearAll()
            Exit Sub
        End If

        MsgBox("更新至B1完成!!" & vbCrLf & "單號：" & lbDocNum.Text, 64, "完成")

        ClearAll()
    End Sub

    Private Sub ClearAll()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
        lbDocNum.Text = ""
        lbM03.Text = ""
        txtM7.Text = ""
        txtM12.Text = ""
        txtM99.Text = ""
    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub DGV1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

End Class