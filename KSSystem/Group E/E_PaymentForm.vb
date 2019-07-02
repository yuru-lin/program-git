Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class E_PaymentForm
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub E_PaymentForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1

        Sum小計.Text = 0
        Sum運費.Text = 0
        Sum毛雞費.Text = 0

    End Sub

    Private Sub CardCodet_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardCode.LostFocus
        SelectCardCode()
    End Sub

    Private Sub CardName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CardName.LostFocus
        SelectCardName()     
    End Sub

    Private Sub SelectCardCode()

        If CardCode.Text = "" Then
            Exit Sub
        End If

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim sqlReader As SqlDataReader
        Using TransactionMonitor As New System.Transactions.TransactionScope
            sql = "SELECT [CardName] FROM [OCRD] WHERE [CardType] = 'S' AND [CardCode] = '" & CardCode.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                sqlReader.Close()
                MsgBox("查無此人", 16, "錯誤")
                CardName.Text = ""
                CardCode.Text = ""
                CardCode.Focus()
            Else
                CardName.Text = sqlReader.Item("CardName")
                sqlReader.Close()
            End If

            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

        If CardCode.Text = "0120010102" Then
            ComboBox1.Visible = True
            ComboBox2.Visible = False
        ElseIf CardCode.Text = "0110010601" Or CardCode.Text = "0118060101" Then
            ComboBox1.Visible = True
            ComboBox2.Visible = True
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
        Using TransactionMonitor As New System.Transactions.TransactionScope

            sql = "SELECT [CardCode] FROM [OCRD] WHERE [CardType] = 'S' AND [CardName] = '" & CardName.Text & "'"

            SQLCmd.Connection = DBConn
            SQLCmd.CommandText = sql

            sqlReader = SQLCmd.ExecuteReader
            sqlReader.Read()

            If Not sqlReader.HasRows() Then
                sqlReader.Close()
                SelectName.getCardName = CardName.Text
                SelectName.getCardCode = CardCode.Text
                SelectName.Source = "E_PaymentForm"
                SelectName.MdiParent = MainForm
                SelectName.Show()
            Else
                CardCode.Text = sqlReader.Item("CardCode")
                sqlReader.Close()
            End If
            If sqlReader.IsClosed = False Then
                sqlReader.Close()
            End If
            TransactionMonitor.Complete()
        End Using

        If CardCode.Text = "0120010102" Then
            ComboBox1.Visible = True
            ComboBox2.Visible = False
        ElseIf CardCode.Text = "0110010601" Or CardCode.Text = "0118060101" Then
            ComboBox1.Visible = True
            ComboBox2.Visible = True
        End If

    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If PaymentType.SelectedIndex = -1 Then
            MsgBox("類型未選", 16, "錯誤")
            Exit Sub
        End If

        If CardCode.Text = "" Then
            MsgBox("廠商編號未填", 16, "錯誤")
            Exit Sub
        End If

        If CardCode.Text = "0120010102" Then
            If ComboBox1.Text = "" Then
                MsgBox("期號未選", 16, "錯誤")
            End If
        End If

        If CardCode.Text = "0110010601" Or CardCode.Text = "0118060101" Then
            If ComboBox1.Text = "" And ComboBox2.Text = "" Then
                MsgBox("期號或客戶未選", 16, "錯誤")
            End If
        End If


        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        Quy1()
        Quy2()
        Quy3()

        計算()

        If DGV1.RowCount = 0 Then
            MsgBox("查無相關資料!", 16, "錯誤")
        End If
    End Sub

    '類型 0.付款類,   1.毛雞類,   2.費用類    3.草稿類
    '     收貨驗收單  收貨驗收單  採購單
    Private Sub Quy1()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        Select Case PaymentType.SelectedIndex
            Case "0"
                'sql = " SELECT   T0.[DocNum] as '文件單號', T0.[DocDate] as '日期', T0.[U_Dnum] as '驗收單號',  T0.[DocDueDate] as '到期日', T1.[ItemCode] as '存編', T1.[Dscription] as '品名規格', cast(T1.[Quantity] as numeric(19,2)) as '數量', T1.[unitMsr] as '單位', cast(isnull(T1.U_P8,0) as numeric(19,4)) as '單價', cast(T1.[VatSum] as numeric(19,4)) as '稅額', cast(T1.[LineTotal] as int) as '小計',cast(isnull(T1.U_BYP,0) as numeric(19,4)) as '最近購價',T1.[OcrCode] as '利潤中心',T3.[PymntGroup] as '付款方式', T2.Descr as '備註' FROM OPDN T0  INNER JOIN PDN1 T1 ON T0.DocEntry = T1.DocEntry left join UFD1 T2 ON T2.TableID = 'PDN1' and T2.FieldID = '5' and T1.[U_Omoney] = T2.FldValue INNER JOIN OCTG T3 ON T0.GroupNum = T3.GroupNum WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                'sql = " SELECT * FROM "
                'sql = "   SELECT      CAST(T0.[DocNum] as VARCHAR) AS '文件單號', T0.[DocDate] AS '日期', T0.[U_Dnum] AS '驗收單號',  T0.[DocDueDate] AS '到期日', T1.[LineNum] AS '列號', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名規格',  CAST(T1.[Quantity] AS NUMERIC(19,2)) AS '數量', T1.[unitMsr] AS '單位',  CAST(isnull(T1.U_P8,0) AS NUMERIC(19,4)) AS '單價',  CAST(T1.[VatSum] AS NUMERIC(19,4)) AS '稅額',  CAST(T1.[LineTotal] AS INT) AS '小計',  CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', CAST(isnull(T1.U_BYP,0) AS NUMERIC(19,4)) AS '最近購價', T1.[OcrCode] AS '利潤中心', T3.[PymntGroup] AS '付款方式', T2.Descr AS '備註' "
                ' LineNum 系統編號 改 VisOrder 單據編號 _ 20161207_yachun.chang
                sql = "   SELECT      CAST(T0.[DocNum] as VARCHAR) AS '文件單號', T0.[DocDate] AS '日期', T0.[U_Dnum] AS '驗收單號',  T0.[DocDueDate] AS '到期日', T1.[VisOrder] AS '列號', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名規格',  CAST(T1.[Quantity] AS NUMERIC(19,2)) AS '數量', T1.[unitMsr] AS '單位',  CAST(isnull(T1.U_P8,0) AS NUMERIC(19,4)) AS '單價',  CAST(T1.[VatSum] AS NUMERIC(19,4)) AS '稅額',  CAST(T1.[LineTotal] AS INT) AS '小計',  CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', CAST(isnull(T1.U_BYP,0) AS NUMERIC(19,4)) AS '最近購價', T1.[OcrCode] AS '利潤中心', T3.[PymntGroup] AS '付款方式', T2.Descr AS '備註' "
                sql += "    FROM [OPDN] T0 INNER JOIN [PDN1] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT JOIN [UFD1] T2 ON T2.[TableID] = 'PDN1' AND T2.[FieldID] = '5' AND T1.[U_Omoney] = T2.[FldValue] INNER JOIN [OCTG] T3 ON T0.[GroupNum] = T3.[GroupNum] "
                sql += "   WHERE T0.[DocStatus] in ('O','C') AND (T0.[DocDate] BETWEEN '" & FromDate.Value.Date & "' AND '" & ToDate.Value.Date & "') AND  T0.[CardCode] = '" & CardCode.Text & "' "

                'If CardCode.Text = "0120010102" Or CardCode.Text = "0110010601" Then
                '    sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                'End If

                '國興
                If CardCode.Text = "0120010102" And ComboBox1.Text <> "" Then
                    sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                End If

                '福壽
                If CardCode.Text = "0110010601" Then

                    If ComboBox1.Text <> "" And ComboBox2.Text = "" Then
                        sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND T1.[Dscription] NOT LIKE '%洪嘉佑王世容埒內%' "

                    ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
                        sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND T1.[Dscription] LIKE '%洪嘉佑王世容埒內%' "

                    ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" Then
                        sql += " AND T1.[Dscription] LIKE '%洪嘉佑王世容埒內%' "
                    End If
                End If

                '茂生
                If CardCode.Text = "0118060101" Then

                    If ComboBox1.Text <> "" And ComboBox2.Text = "" Then
                        sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND T1.[Dscription] NOT LIKE '%-洪%' AND T1.[Dscription] NOT LIKE '%-埒%' "

                    ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
                        sql += " AND  T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND (T1.[Dscription] LIKE '%-洪%' OR T1.[Dscription] LIKE '%-埒%') "

                    ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" Then
                        sql += " AND (T1.[Dscription] LIKE '%-洪%' OR T1.[Dscription] LIKE '%-埒%') "
                    End If
                End If

                sql += "  UNION "
                sql += "  SELECT '退'+CAST(T0.[DocNum] as VARCHAR) AS '文件單號', T0.[DocDate] AS '日期', T0.[U_Dnum] AS '驗收單號',  T0.[DocDueDate] AS '到期日', T1.[VisOrder] AS '列號', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名規格', -CAST(T1.[Quantity] AS NUMERIC(19,2)) AS '數量', T1.[unitMsr] AS '單位', -CAST(isnull(T1.U_P8,0) AS NUMERIC(19,4)) AS '單價', -CAST(T1.[VatSum] AS NUMERIC(19,4)) AS '稅額', (CASE WHEN T1.TaxOnly = 'Y' THEN 0 ELSE -CAST(T1.[LineTotal] AS INT) END) AS '小計', -CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', CAST(isnull(T1.U_BYP,0) AS NUMERIC(19,4)) AS '最近購價', T1.[OcrCode] AS '利潤中心', ''              AS '付款方式', ''       AS '備註' "
                sql += "    FROM [ORPD] T0 INNER JOIN [RPD1] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT JOIN [UFD1] T2 ON T2.[TableID] = 'PDN1' AND T2.[FieldID] = '5' AND T1.[U_Omoney] = T2.[FldValue] INNER JOIN [OCTG] T3 ON T0.[GroupNum] = T3.[GroupNum] "
                sql += "   WHERE T0.[DocStatus] in ('O','C') AND (T0.[DocDate] BETWEEN '" & FromDate.Value.Date & "' AND '" & ToDate.Value.Date & "') AND  T0.[CardCode] = '" & CardCode.Text & "' "

                'If CardCode.Text = "0120010102" Or CardCode.Text = "0110010601" Then
                '    sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%'' "
                '    'sql += "   ORDER BY 品名規格, 日期 "
                '    sql += "   ORDER BY 文件單號, 列號 "
                'Else
                '    sql += "   ORDER BY 文件單號, 列號 "
                '    'sql += "   ORDER BY 驗收單號, 文件單號 "  Like '%" & 品WT21.Text & "%'
                'End If

                '國興
                If CardCode.Text = "0120010102" And ComboBox1.Text <> "" Then
                    sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                End If

                '福壽
                If CardCode.Text = "0110010601" Then

                    If ComboBox1.Text <> "" And ComboBox2.Text = "" Then
                        sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND T1.[Dscription] NOT LIKE '%%洪嘉佑王世容埒內%%' "

                    ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
                        sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND T1.[Dscription] LIKE '%%洪嘉佑王世容埒內%%' "

                    ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" Then
                        sql += " AND T1.[Dscription] LIKE '%%洪嘉佑王世容埒內%%' "
                    End If
                End If

                '茂生
                If CardCode.Text = "0118060101" Then

                    If ComboBox1.Text <> "" And ComboBox2.Text = "" Then
                        sql += " AND T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND T1.[Dscription] NOT LIKE '%-洪%' AND T1.[Dscription] NOT LIKE '%-埒%' "

                    ElseIf ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
                        sql += " AND  T1.[Dscription] LIKE '%" & ComboBox1.Text & "%' "
                        sql += " AND (T1.[Dscription] LIKE '%-洪%' OR T1.[Dscription] LIKE '%-埒%') "

                    ElseIf ComboBox1.Text = "" And ComboBox2.Text <> "" Then
                        sql += " AND (T1.[Dscription] LIKE '%-洪%' OR T1.[Dscription] LIKE '%-埒%') "
                    End If
                End If

                sql += "   ORDER BY 文件單號, 列號 "

                Panel1.Visible = False


            Case "1"
                sql = " DECLARE @CardCode VARCHAR(20) "
                sql += "DECLARE @FromDate DateTime "
                sql += "DECLARE @ToDate   DateTime "
                sql += "SET NOCOUNT ON "
                sql += "SET @CardCode = '" & CardCode.Text & "' "
                sql += "SET @FromDate = '" & FromDate.Value.Date & "' "
                sql += "SET @ToDate   = '" & ToDate.Value.Date & "' "

                sql += "   SELECT      CAST(T0.[DocNum] AS VARCHAR) AS '文件單號', T0.[DocDate] AS '日期', T0.[U_Dnum] AS '驗收單號', T0.[DocDueDate] AS '到期日', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名規格',  CAST(T1.[U_p2] AS NUMERIC(19,2)) AS '數量', 'KG' AS '單位', CAST(T1.[U_P8] AS NUMERIC(19,4)) as '單價',  CAST(T1.[VatSum] AS NUMERIC(19,4)) AS '稅額',  CAST(T1.[LineTotal] AS INT) AS '小計',  CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', CAST(ISNULL(T1.U_BYP,0) AS numeric(19,4)) AS '最近購價', T1.[OcrCode] AS '利潤中心', T3.[PymntGroup] AS '付款方式', T2.Descr AS '備註', T1.[VisOrder] AS '列號' "
                sql += "     FROM [OPDN] T0  INNER JOIN [PDN1] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT JOIN [UFD1] T2 ON T2.[TableID] = 'PDN1' AND T2.[FieldID] = '5' AND T1.[U_Omoney] = T2.[FldValue] INNER JOIN [OCTG] T3 ON T0.[GroupNum] = T3.[GroupNum] "
                sql += "    WHERE T0.[DocStatus] IN ('O','C') AND (T0.[DocDate] BETWEEN @FromDate AND @ToDate) AND  T0.[CardCode] = @CardCode "
                sql += " UNION "
                sql += "   SELECT '退'+CAST(T0.[DocNum] AS VARCHAR) AS '文件單號', T0.[DocDate] AS '日期', T0.[U_Dnum] AS '驗收單號', T0.[DocDueDate] AS '到期日', T1.[ItemCode] AS '存編', T1.[Dscription] AS '品名規格', -CAST(T1.[U_p2] AS NUMERIC(19,2)) AS '數量', 'KG' AS '單位', CAST(T1.[U_P8] AS NUMERIC(19,4)) as '單價', -CAST(T1.[VatSum] AS NUMERIC(19,4)) AS '稅額', (CASE WHEN T1.TaxOnly = 'Y' THEN 0 ELSE -CAST(T1.[LineTotal] AS INT) END) AS '小計', -CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', CAST(ISNULL(T1.U_BYP,0) AS numeric(19,4)) AS '最近購價', T1.[OcrCode] AS '利潤中心', ''              AS '付款方式', T2.Descr  AS '備註', T1.[VisOrder] AS '列號' "
                sql += "     FROM [ORPD] T0  INNER JOIN [RPD1] T1 ON T0.[DocEntry] = T1.[DocEntry] LEFT JOIN [UFD1] T2 ON T2.[TableID] = 'PDN1' AND T2.[FieldID] = '5' AND T1.[U_Omoney] = T2.[FldValue] INNER JOIN [OCTG] T3 ON T0.[GroupNum] = T3.[GroupNum] "
                sql += "    WHERE T0.[DocStatus] IN ('O','C') AND (T0.[DocDate] BETWEEN @FromDate AND @ToDate) AND  T0.[CardCode] = @CardCode"
                sql += " ORDER BY [驗收單號], [文件單號], [列號] "

                Panel1.Visible = True

            Case "2"
                If Login.CompanyDGV.CurrentRow.Cells("資料庫").Value = "kFS_00" Then
                    sql = " SELECT T0.[DocNum] as '文件單號',T0.[DocDate] as '日期', T0.[U_Dnum] as '驗收單號',  T0.[DocDueDate] as '到期日', T1.[ItemCode] as '存編', T1.[Dscription] as '品名規格', cast(T1.[Quantity] as numeric(19,2)) as '數量', T1.[unitMsr] as '單位', cast(isnull(T1.U_P8,0) as numeric(19,4)) as '單價', cast(T1.[VatSum] as numeric(19,4)) as '稅額', cast(T1.[LineTotal] as int) as '小計', 0                                AS '運費', cast(isnull(T1.U_BYP,0) as numeric(19,4)) as '最近購價',T1.[OcrCode] as '利潤中心',T3.[PymntGroup] as '付款方式', T2.Descr as '備註' FROM OPOR T0  INNER JOIN POR1 T1 ON T0.DocEntry = T1.DocEntry left join UFD1 T2 ON T2.TableID = 'POR1' and T2.FieldID = '5' and T1.[U_Omoney] = T2.FldValue INNER JOIN OCTG T3 ON T0.GroupNum = T3.GroupNum WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Else
                    sql = " SELECT T0.[DocNum] as '文件單號',T0.[DocDate] as '日期', T0.[U_Dnum] as '驗收單號',  T0.[DocDueDate] as '到期日', T1.[ItemCode] as '存編', T1.[Dscription] as '品名規格', cast(T1.[Quantity] as numeric(19,2)) as '數量', T1.[unitMsr] as '單位', cast(isnull(T1.U_P8,0) as numeric(19,4)) as '單價', cast(T1.[VatSum] as numeric(19,4)) as '稅額', cast(T1.[LineTotal] as int) as '小計', CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', cast(isnull(T1.U_BYP,0) as numeric(19,4)) as '最近購價',T1.[OcrCode] as '利潤中心',T3.[PymntGroup] as '付款方式', T2.Descr as '備註' FROM OPOR T0  INNER JOIN POR1 T1 ON T0.DocEntry = T1.DocEntry left join UFD1 T2 ON T2.TableID = 'POR1' and T2.FieldID = '5' and T1.[U_Omoney] = T2.FldValue INNER JOIN OCTG T3 ON T0.GroupNum = T3.GroupNum WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                End If
                'sql = " SELECT T0.[DocNum] as '文件單號',T0.[DocDate] as '日期', T0.[U_Dnum] as '驗收單號',  T0.[DocDueDate] as '到期日', T1.[ItemCode] as '存編', T1.[Dscription] as '品名規格', cast(T1.[Quantity] as numeric(19,2)) as '數量', T1.[unitMsr] as '單位', cast(isnull(T1.U_P8,0) as numeric(19,4)) as '單價', cast(T1.[VatSum] as numeric(19,4)) as '稅額', cast(T1.[LineTotal] as int) as '小計', CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', cast(isnull(T1.U_BYP,0) as numeric(19,4)) as '最近購價',T1.[OcrCode] as '利潤中心',T3.[PymntGroup] as '付款方式', T2.Descr as '備註' FROM OPOR T0  INNER JOIN POR1 T1 ON T0.DocEntry = T1.DocEntry left join UFD1 T2 ON T2.TableID = 'POR1' and T2.FieldID = '5' and T1.[U_Omoney] = T2.FldValue INNER JOIN OCTG T3 ON T0.GroupNum = T3.GroupNum WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"

                Panel1.Visible = False

            Case "3"
                sql = " SELECT '草'+cast(T0.[DocEntry] as varchar) as '文件單號',T0.[DocDate] as '日期', T0.[U_Dnum] as '驗收單號',  T0.[DocDueDate] as '到期日', T1.[ItemCode] as '存編', T1.[Dscription] as '品名規格', cast(T1.[Quantity] as numeric(19,2)) as '數量', T1.[unitMsr] as '單位', cast(isnull(T1.U_P8,0) as numeric(19,4)) as '單價', cast(T1.[VatSum] as numeric(19,4)) as '稅額', cast(T1.[LineTotal] as int) as '小計', CAST(ISNULL(T1.[U_m5],0) AS INT) AS '運費', cast(isnull(T1.U_BYP,0) as numeric(19,4)) as '最近購價',T1.[OcrCode] as '利潤中心',T3.[PymntGroup] as '付款方式', T2.Descr as '備註' FROM ODRF T0  INNER JOIN DRF1 T1 ON T0.DocEntry = T1.DocEntry left join UFD1 T2 ON T2.TableID = 'POR1' and T2.FieldID = '5' and T1.[U_Omoney] = T2.FldValue INNER JOIN OCTG T3 ON T0.GroupNum = T3.GroupNum WHERE T0.DocStatus = 'O' and T0.[ObjType] = '22' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"

                Panel1.Visible = False


        End Select

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub Quy2()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        sql = "select  T0.DocNum as '文件單號',cast((T0.PaidSum - T0.DpmAppl) as int) as '預付款'  From ODPO T0 where T0.DocStatus = 'C' and T0.CardCode = '" & CardCode.Text & "' and ((T0.PaidSum - T0.DpmAppl) > 0)"

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")

        DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
        DGV2.AutoResizeColumns()
    End Sub

    Private Sub Quy3()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If Login.CompanyDGV.CurrentRow.Cells("資料庫").Value = "kFS_00" Then
            Select Case PaymentType.SelectedIndex
                Case "0"
                    sql = "Select T0.[DocNum] as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費','0'  as '毛雞金額' From OPDN T0 WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Case "1"
                    sql = " SELECT T0.[DocEntry] as '文件單號', CAST(CASE ISNULL(SUM(T0.[U_m5]),0) WHEN 0 THEN 0 ELSE ISNULL(SUM(T0.[U_m5]),0) END AS INT) AS '運費', CAST(CASE ISNULL(SUM(T0.[LineTotal]),0) WHEN 0 THEN 0 ELSE ISNULL(SUM(T0.[LineTotal]),0) - ISNULL(SUM(T0.[U_m5]),0) END AS INT) AS '毛雞金額' FROM [PDN1] T0 INNER JOIN [OPDN] T1 ON T0.[DocEntry] = T1.[DocNum] WHERE T0.[LineStatus] = 'O' AND T0.[Dscription] Like '%毛雞%' AND (T0.[DocDate] between '" & FromDate.Value.Date & "' AND '" & ToDate.Value.Date & "') AND  T1.[CardCode] = '" & CardCode.Text & "' GROUP BY T0.[DocEntry] "
                    'sql = "Select T0.[DocNum] as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費','0' as '毛雞金額' From OPDN T0 WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Case "2"
                    sql = "Select T0.[DocNum] as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費','0' as '毛雞金額' From OPOR T0 WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Case "3"
                    sql = "Select '草'+cast(T0.[DocEntry] as varchar) as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費','0' as '毛雞金額' From ODRF T0 WHERE T0.DocStatus = 'O' and T0.[ObjType] = '22' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
            End Select
        Else
            Select Case PaymentType.SelectedIndex
                Case "0"
                    sql = "Select T0.[DocNum] as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費',cast(case isnull(T0.U_GetMT,0) when 0 then 0 else T0.U_GetMT end as int)  as '毛雞金額' From OPDN T0 WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Case "1"
                    sql = " SELECT T0.[DocEntry] as '文件單號', CAST(CASE ISNULL(SUM(T0.[U_m5]),0) WHEN 0 THEN 0 ELSE ISNULL(SUM(T0.[U_m5]),0) END AS INT) AS '運費', CAST(CASE ISNULL(SUM(T0.[LineTotal]),0) WHEN 0 THEN 0 ELSE ISNULL(SUM(T0.[LineTotal]),0) - ISNULL(SUM(T0.[U_m5]),0) END AS INT) AS '毛雞金額' FROM [PDN1] T0 INNER JOIN [OPDN] T1 ON T0.[DocEntry] = T1.[DocNum] WHERE T0.[LineStatus] = 'O' AND T0.[Dscription] Like '%毛雞%' AND (T0.[DocDate] between '" & FromDate.Value.Date & "' AND '" & ToDate.Value.Date & "') AND  T1.[CardCode] = '" & CardCode.Text & "' GROUP BY T0.[DocEntry] "
                    'sql = "Select T0.[DocNum] as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費',cast(case isnull(T0.U_GetMT,0) when 0 then 0 else T0.U_GetMT end as int) as '毛雞金額' From OPDN T0 WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Case "2"
                    sql = "Select T0.[DocNum] as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費',cast(case isnull(T0.U_GetMT,0) when 0 then 0 else T0.U_GetMT end as int) as '毛雞金額' From OPOR T0 WHERE T0.DocStatus = 'O' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
                Case "3"
                    sql = "Select '草'+cast(T0.[DocEntry] as varchar) as '文件單號', cast(case isnull(T0.U_TpMoney,0) when 0 then 0 else T0.U_TpMoney end as int) as '運費',cast(case isnull(T0.U_GetMT,0) when 0 then 0 else T0.U_GetMT end as int) as '毛雞金額' From ODRF T0 WHERE T0.DocStatus = 'O' and T0.[ObjType] = '22' and (T0.[DocDate] between '" & FromDate.Value.Date & "' and '" & ToDate.Value.Date & "') and  T0.[CardCode] = '" & CardCode.Text & "'"
            End Select
        End If

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")

        DGV3.DataSource = ks1DataSetDGV.Tables("DT3")
        DGV3.AutoResizeColumns()
    End Sub

    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        If DGV1.RowCount = 0 Then
            'MsgBox("查無相關資料!", 16, "錯誤")
            Exit Sub
        End If

        計算()
    End Sub


    Private Sub 計算()
        '計算小計及運費
        DGV1.AutoResizeColumns()
        Dim Sum1 As Integer = 0
        Dim Sum2 As Integer = 0
        Dim Sum3 As Integer = 0
        Dim Sum4 As Integer = 0
        Dim Sum5 As Integer = 0


        For i As Integer = 0 To DGV1.RowCount - 1
            Sum1 += DGV1.Rows(i).Cells("小計").Value
            Sum2 += DGV1.Rows(i).Cells("運費").Value
            Sum3 += DGV1.Rows(i).Cells("稅額").Value
        Next

        For x As Integer = 0 To DGV2.RowCount - 1
            Sum4 += DGV2.Rows(x).Cells("預付款").Value
        Next

        Sum小計.Text = Sum1
        Sum運費.Text = Sum2
        'Sum稅額.Text = Sum3
        'Sum毛雞費.Text = Sum4

        Sum5 = Sum1 + Sum3 - Sum4 - Sum2
        Sum毛雞費.Text = Sum5


    End Sub




    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        E_ReportViewer.MdiParent = MainForm
        E_ReportViewer.Source = "PaymentForm"
        E_ReportViewer.strPara(0) = Login.CompanyDGV.CurrentRow.Cells("公司名稱").Value
        E_ReportViewer.strPara(1) = CardCode.Text
        E_ReportViewer.strPara(2) = CardName.Text

        '= Format(Sum(CInt(Fields!小計.Value), "ReportDataSet_dtPayment1") + Sum(CInt(Fields!稅額.Value), "ReportDataSet_dtPayment1") - Sum(CInt(Fields!預付款.Value), "ReportDataSet_dtPayment2") - Sum(CInt(Fields!運費.Value), "ReportDataSet_dtPayment1") ,"###,##0")

        Select Case PaymentType.SelectedIndex
            Case "0"
                E_ReportViewer.strPara(3) = "付款申請單"
                E_ReportViewer.strPara(4) = "0"


            Case "1"
                If RB1.Checked = True Then
                    E_ReportViewer.strPara(3) = "毛雞付款申請單"
                    E_ReportViewer.strPara(4) = Sum毛雞費.Text
                Else
                    E_ReportViewer.strPara(3) = "付款申請單"
                    E_ReportViewer.strPara(4) = "0" 'Sum毛雞費.Text
                End If
            Case "2"
                E_ReportViewer.strPara(3) = "費用付款申請單"
                E_ReportViewer.strPara(4) = "0"


            Case "3"
                E_ReportViewer.strPara(3) = "費用付款單"
                E_ReportViewer.strPara(4) = "0"


        End Select

        E_ReportViewer.dt1 = ks1DataSetDGV.Tables("DT1").DefaultView.ToTable()
        E_ReportViewer.dt2 = ks1DataSetDGV.Tables("DT2").DefaultView.ToTable()
        E_ReportViewer.dt3 = ks1DataSetDGV.Tables("DT3").DefaultView.ToTable()

        E_ReportViewer.Show()

    End Sub
End Class