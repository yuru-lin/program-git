Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Transactions

Public Class v001出貨單查詢

    Dim DataAdapterDGV As SqlDataAdapter
    Dim KsDataSet As DataSet = New DataSet
    Dim KsDataSetDGV As DataSet = New DataSet

    Private Sub v001出貨單查詢_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        司機資料載入_()
        司機.SelectedIndex = -1

    End Sub

    Private Sub 司機資料載入_()

        Dim SQL As String = ""

        SQL = "  SELECT T0.[lastName] AS '司機', CAST(T0.[empID] AS NVARCHAR(10)) AS '編號', T1.[roleID] "
        SQL += " FROM [OHEM] T0 INNER JOIN "
        SQL += "      [HEM6] T1 ON T0.[empID] = T1.[empID] "
        SQL += " WHERE T1.[roleID] = 1 AND T0.[Status] = 1 "
        SQL += " UNION ALL "
        SQL += " SELECT T0.[CardName], T0.[CardCode], T0.[lictradnum] "
        SQL += " FROM [OCRD] T0 "
        SQL += " WHERE T0.[QryGroup20] = 'Y' "
        SQL += " UNION ALL "
        SQL += " SELECT '' AS '司機', '' AS '編號', '' AS 'xxx' "

        Dim DBConn As SqlConnection = Login.DBConn
        Try
            DataAdapterDGV = New SqlDataAdapter(SQL, DBConn)
            DataAdapterDGV.Fill(KsDataSet, "司機明細")
            司機.DataSource = KsDataSet.Tables("司機明細").Copy : 司機.DisplayMember = "司機"

        Catch ex As Exception
            MsgBox("司機明細：" & ex.Message)
            Exit Sub
        End Try

    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click

        If DGV1.RowCount > 0 Then
            KsDataSetDGV.Tables("DT1").Clear()
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "  SELECT T0.[CardName] AS '客戶名稱', T1.[Dscription] AS '品名', CAST(T1.[Quantity] AS INT) AS '數量', T0.[Comments] AS '備註', "
        sql += " SUBSTRING(T0.[U_Dnum],5,2) + '/' + SUBSTRING(T0.[U_Dnum],7,2) + ' #' + "
        sql += " CASE WHEN SUBSTRING(T0.[U_Dnum],10,1) = 0 THEN SUBSTRING(T0.[U_Dnum],11,2) ELSE SUBSTRING(T0.[U_Dnum],10,3) END AS '提貨單號' "
        sql += " FROM ODRF T0 INNER JOIN "
        sql += "      DRF1 T1 ON T0.[DocEntry] = T1.[DocEntry] "
        sql += " WHERE  T0.[ObjType] = '15' AND (T0.[U_CarDr1] = '" & 司機.Text & "' OR T0.[U_CarDr2] = '" & 司機.Text & "' OR T0.[U_CarDr3] = '" & 司機.Text & "') AND "
        sql += "       (T0.[DocDueDate] >= '" & 日期1.Value.Date & "' AND T0.[DocDueDate] <= '" & 日期2.Value.Date & "') "
        sql += " ORDER BY T0.[U_Dnum] "

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(KsDataSetDGV, "DT1")
        DGV1.DataSource = KsDataSetDGV.Tables("DT1")

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub 匯出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出Excel.Click

        DataToExcel(DGV1, "")

    End Sub
End Class