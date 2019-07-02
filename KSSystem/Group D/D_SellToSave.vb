Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_SellToSave
    Dim ksDataSetDGV2 As DataSet = New DataSet

    Private Sub D_SellToSave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub DocType_SelectChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemType.SelectedIndexChanged
        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If
        If DGV2.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT2").Clear()
        End If
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If ItemType.SelectedIndex = -1 Then
            MsgBox("請選擇項目類型!")
            ItemType.Focus()
            Exit Sub
        End If


        If DGV1.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT1").Clear()
        End If


        Loading.Show()
        MsgBox("由於資料龐大，請耐心等待。", 64, "貼心提醒")
        setDGV1Load()

    End Sub

    Private Sub setDGV1Load()
        Dim ic As String

        Select Case ItemType.SelectedIndex
            Case 0
                ic = "21"
            Case 1
                ic = "22"
            Case 2
                ic = "23"
            Case 3
                ic = "25"
        End Select

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql, sql2 As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim SQLCmd2 As SqlCommand = New SqlCommand

        sql = "L20110824_STS"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure
        SQLCmd.CommandTimeout = 100000
        SQLCmd.Parameters.Add(New SqlParameter("@FromDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ToDate", SqlDbType.DateTime))
        SQLCmd.Parameters.Add(New SqlParameter("@ic", SqlDbType.NVarChar))
        SQLCmd.Parameters("@FromDate").Value = FromDate.Value.Date
        SQLCmd.Parameters("@ToDate").Value = ToDate.Value.Date
        SQLCmd.Parameters("@ic").Value = ic
        SQLCmd.ExecuteNonQuery()

        sql2 = "Select T0.m1 as '存編',T0.m2 as '品名',T0.m3 as '批序號管理',T0.m4 as '庫存單位',T0.m5 as '期初數量',T0.m6 as '期初重量',T0.m7 as '期初金額',T0.m8 as '收貨採購單數量',T0.m9 as '收貨採購單重量',T0.m10 as '收貨採購單金額',T0.m11 as '收貨單數量',T0.m12 as '收貨單重量',T0.m13 as '收貨單金額',T0.m14 as '發貨單數量',T0.m15 as '發貨單重量',T0.m16 as '發貨單金額',T0.m17 as '交貨單數量',T0.m18 as '交貨單重量',T0.m19 as '交貨單金額',T0.m20 as '銷售退貨單數量',T0.m21 as '銷售退貨單重量',T0.m22 as '銷售退貨單金額',T0.m23 as 'AR貸項通知單數量',T0.m24 as 'AR貸項通知單重量',T0.m25 as 'AR貸項通知單金額',T0.m26 as '採購退貨單數量',T0.m27 as '採購退貨單重量',T0.m28 as '採購退貨單金額',T0.m29 as 'AP貸項通知單數量',T0.m30 as 'AP貸項通知單重量',T0.m31 as 'AP貸項通知單金額',T0.m32 as '期末數量',T0.m33 as '期末重量',T0.m34 as '期末金額' From [@STS] T0"

        SQLCmd2.Connection = DBConn
        SQLCmd2.CommandText = sql2

        DataAdapter1 = New SqlDataAdapter(sql2, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT1")

        DGV1.DataSource = ksDataSetDGV2.Tables("DT1")

        setDGV1Display()
    End Sub

    Private Sub setDGV1Display()
        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "存編"
                    column.DisplayIndex = 0
                    column.Frozen = True
                Case "品名"
                    column.DisplayIndex = 1
                    column.Frozen = True
                    column.DividerWidth = 3
                Case "批序號管理"
                    column.DisplayIndex = 2
                Case "庫存單位"
                    column.DisplayIndex = 3
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                Case "期初數量"
                    column.DisplayIndex = 4
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "期初重量"
                    column.DisplayIndex = 5
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "期初金額"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "收貨採購單數量"
                    column.DisplayIndex = 7
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "收貨採購單重量"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "收貨採購單金額"
                    column.DisplayIndex = 9
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "收貨單數量"
                    column.DisplayIndex = 10
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "收貨單重量"
                    column.DisplayIndex = 11
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "收貨單金額"
                    column.DisplayIndex = 12
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "發貨單數量"
                    column.DisplayIndex = 13
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "發貨單重量"
                    column.DisplayIndex = 14
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "發貨單金額"
                    column.DisplayIndex = 15
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "交貨單數量"
                    column.DisplayIndex = 16
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "交貨單重量"
                    column.DisplayIndex = 17
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "交貨單金額"
                    column.DisplayIndex = 18
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "銷售退貨單數量"
                    column.DisplayIndex = 19
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "銷售退貨單重量"
                    column.DisplayIndex = 20
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "銷售退貨單金額"
                    column.DisplayIndex = 21
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "AR貸項通知單數量"
                    column.DisplayIndex = 22
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "AR貸項通知單重量"
                    column.DisplayIndex = 23
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "AR貸項通知單金額"
                    column.DisplayIndex = 24
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "採購退貨單數量"
                    column.DisplayIndex = 25
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "採購退貨單重量"
                    column.DisplayIndex = 26
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "採購退貨單金額"
                    column.DisplayIndex = 27
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "AP貸項通知單數量"
                    column.DisplayIndex = 28
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "AP貸項通知單重量"
                    column.DisplayIndex = 29
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "AP貸項通知單金額"
                    column.DisplayIndex = 30
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case "期末數量"
                    column.DisplayIndex = 31
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "期末重量"
                    column.DisplayIndex = 32
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "期末金額"
                    column.DisplayIndex = 33
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"

                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()


        Loading.Close()
        MsgBox("查詢已完成，謝謝您的耐心等候!!", 64, "貼心提醒")


    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick


        If DGV1.CurrentCell.ColumnIndex = "0" Or DGV1.CurrentCell.ColumnIndex = "1" Or DGV1.CurrentCell.ColumnIndex = "2" Or DGV1.CurrentCell.ColumnIndex = "3" Then
            Exit Sub
        End If

        If DGV2.RowCount > 0 Then
            ksDataSetDGV2.Tables("DT2").Clear()
            DocType.Text = ""
            SelectItemCode.Text = ""
        End If


        If DGV1.CurrentCell.ColumnIndex = "7" Or DGV1.CurrentCell.ColumnIndex = "8" Or DGV1.CurrentCell.ColumnIndex = "9" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "收貨採購單"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                OPDN()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "10" Or DGV1.CurrentCell.ColumnIndex = "11" Or DGV1.CurrentCell.ColumnIndex = "12" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "收貨單"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                OIGN()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "13" Or DGV1.CurrentCell.ColumnIndex = "14" Or DGV1.CurrentCell.ColumnIndex = "15" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "發貨單"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                OIGE()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "16" Or DGV1.CurrentCell.ColumnIndex = "17" Or DGV1.CurrentCell.ColumnIndex = "18" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "交貨單"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                ODLN()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "19" Or DGV1.CurrentCell.ColumnIndex = "20" Or DGV1.CurrentCell.ColumnIndex = "21" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "銷售退回"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                ORDN()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "22" Or DGV1.CurrentCell.ColumnIndex = "23" Or DGV1.CurrentCell.ColumnIndex = "24" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "AR貸項"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                ORIN()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "25" Or DGV1.CurrentCell.ColumnIndex = "26" Or DGV1.CurrentCell.ColumnIndex = "27" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "採購退貨"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                ORPD()
            End If
        End If

        If DGV1.CurrentCell.ColumnIndex = "28" Or DGV1.CurrentCell.ColumnIndex = "29" Or DGV1.CurrentCell.ColumnIndex = "30" Then
            If DGV1.CurrentCell.Value <> "0" Then
                DocType.Text = "AP貸項"
                SelectItemCode.Text = DGV1.CurrentRow.Cells("存編").Value + "      " + DGV1.CurrentRow.Cells("品名").Value
                ORPC()
            End If
        End If


    End Sub

    Private Sub OPDN()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM OPDN T0  INNER JOIN PDN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()

    End Sub

    Private Sub OIGN()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM OIGN T0  INNER JOIN IGN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub OIGE()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub ODLN()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM ODLN T0  INNER JOIN DLN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub ORDN()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM ORDN T0  INNER JOIN RDN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub ORIN()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM ORIN T0  INNER JOIN RIN1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub ORPD()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM ORPD T0  INNER JOIN RPD1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub ORPC()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "SELECT T0.DocNum as '單號',T0.DocDate as '過帳日期',T0.CardCode as '供應商',T0.CardName as '名稱',T1.[ItemCode] as '存編',T1.Dscription as '品名',T1.unitMsr as '庫存單位',T1.[WhsCode] as '倉別',T1.[Quantity] as '數量',T1.[NumPerMsr] as '計量單位值',T1.[Quantity]*T1.[NumPerMsr] as '庫存單位數量', T1.[U_p2]  as 'KG',T1.[LineTotal] as '列總計'  FROM ORPC T0  INNER JOIN RPC1 T1 ON T0.DocEntry = T1.DocEntry WHERE T0.[DocDate] >= '" & FromDate.Value.Date & "' and  T0.[DocDate] <= '" & ToDate.Value.Date & "' and T1.[ItemCode] = '" & DGV1.CurrentRow.Cells("存編").Value & "' and T1.WhsCode not in ('ZDW')"

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSetDGV2, "DT2")

        DGV2.DataSource = ksDataSetDGV2.Tables("DT2")

        setDGV2Display()
    End Sub

    Private Sub setDGV2Display()
        For Each column As DataGridViewColumn In DGV2.Columns
            column.Visible = True
            Select Case column.Name
                Case "單號"
                    column.DisplayIndex = 0
                Case "過帳日期"
                    column.DisplayIndex = 1
                Case "供應商"
                    column.DisplayIndex = 2
                Case "名稱"
                    column.DisplayIndex = 3
                Case "存編"
                    column.DisplayIndex = 4
                Case "品名"
                    column.DisplayIndex = 5
                Case "庫存單位"
                    column.DisplayIndex = 6
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                Case "倉別"
                    column.DisplayIndex = 7
                Case "數量"
                    column.DisplayIndex = 8
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "計量單位值"
                    column.DisplayIndex = 9
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "庫存單位數量"
                    column.DisplayIndex = 10
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "KG"
                    column.DisplayIndex = 11
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0.##"
                Case "列總計"
                    column.DisplayIndex = 12
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                Case Else
                    column.Visible = False
            End Select
        Next

        DGV2.Refresh()
        DGV2.AutoResizeColumns()

    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        Dim str As String = ItemType.Text
        DataToExcelByCopy(DGV1, str)
    End Sub

    Private Sub DataToExcelByCopy(ByVal m_DataView As DataGridView, ByVal str As String)

        Dim kk As New SaveFileDialog()
        kk.Title = "儲存EXECL文件"
        kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*"
        kk.FilterIndex = 1
        kk.FileName = str
        If kk.ShowDialog() = DialogResult.OK Then
            Dim FileName As String = kk.FileName ' + ".xls"
            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If

            Dim myExcel, myBook, myWorksheet As Object
            myExcel = CreateObject("Excel.Application")
            myBook = myExcel.Workbooks.add
            myWorksheet = myBook.worksheets(1)
            myExcel.Visible = False
            myWorksheet.Columns(1).NumberFormat = "@"

            m_DataView.MultiSelect = True
            m_DataView.SelectAll()
            Dim dataObj As DataObject = m_DataView.GetClipboardContent()
            Clipboard.SetDataObject(dataObj, True)
            m_DataView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
            m_DataView.RowHeadersVisible = False
            m_DataView.MultiSelect = False

            myWorksheet.PasteSpecial(Format:="文字", Link:=False, DisplayAsIcon:=False)
            myWorksheet.Columns.AutoFit()

            myExcel.ActiveWorkbook.SaveAs(FileName)
            myExcel.Quit()
            myExcel = Nothing
            MessageBox.Show(Me, "儲存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class