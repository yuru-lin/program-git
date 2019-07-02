Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_草稿派工作業
    Dim DataAdapterDGV As SqlDataAdapter
    Dim DataSetDGV As DataSet = New DataSet

    Private Sub A_草稿派工作業_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV21整列資訊()
        DGV23.AutoResizeColumns()
    End Sub

    Private Sub 回上頁_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 回上頁.Click
        A_整合派工作業.Show()
        A_整合派工作業.查詢文件草稿單號()
        Me.Close()
    End Sub

    Private Sub DGV21整列資訊()

        If DGV21.RowCount <= 0 Then
            MsgBox("查無此草稿單號!請重新檢查!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV21.Columns
            column.Visible = True
            Select Case column.Name
                Case "列號" : column.HeaderText = "列號" : column.DisplayIndex = 0 : column.Visible = False
                Case "管理" : column.HeaderText = "管理" : column.DisplayIndex = 1
                Case "存編" : column.HeaderText = "存編" : column.DisplayIndex = 2
                Case "品名" : column.HeaderText = "品名" : column.DisplayIndex = 3
                Case "出庫數" : column.HeaderText = "出庫數" : column.DisplayIndex = 4
                Case "庫位" : column.HeaderText = "庫位" : column.DisplayIndex = 5
                Case "庫存量" : column.HeaderText = "庫存量" : column.DisplayIndex = 6
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV21.AutoResizeColumns()
    End Sub

    Private Sub DGV21_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV21.CellClick
        If DGV21.RowCount = 0 Then : Exit Sub : End If
        查庫存()
    End Sub

    Private Sub 查庫存()
        If DGV22.RowCount > 0 Then
            DataSetDGV.Tables("DGV22").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            Dim Tmps As String
            Tmps = Format(Replace(Replace("#IntegrateTmp" & System.Net.Dns.GetHostName(), "-", ""), " ", ""), "")

            SQLCmd.CommandText = "  DECLARE @FromDate DateTime "
            SQLCmd.CommandText += " DECLARE @ToDate   DateTime "
            SQLCmd.CommandText += " DECLARE @ItemCode varchar(20) "
            SQLCmd.CommandText += " SET NOCOUNT ON "
            SQLCmd.CommandText += " SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += " SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += " SET @ItemCode = '" & Format(DGV21.CurrentRow.Cells("存編").Value, "") & "' "
            SQLCmd.CommandText += " IF (OBJECT_ID('tempdb.." & Tmps & "') IS NOT NULL)  DROP TABLE " & Tmps & " "

            Select Case DGV21.CurrentRow.Cells("管理").Value
                Case "序號"

                    SQLCmd.CommandText += "    SELECT T0.[ItemCode] AS 'ItemCode', T2.[ItemName] AS 'ItemName', T1.[WhsCode] AS 'WhsCode', T0.[U_M2] AS 'U_M2', "
                    SQLCmd.CommandText += "           SUM(CAST(ISNULL(T1.[Quantity],0) AS INT))           AS 'Quantity', T2.[InvntryUom] as 'InvntryUom', "
                    SQLCmd.CommandText += "           SUM(CAST(ISNULL(T0.[U_M1],0)     AS NUMERIC(19,2))) AS 'U_M1',CONVERT(CHAR(10),T0.[MnfDate], 120) AS 'MnfDate',  "
                    SQLCmd.CommandText += "           CONVERT(CHAR(10),T0.[ExpDate],120) AS 'ExpDate', T0.[DistNumber], CAST(T0.[U_M8] AS NVARCHAR(12)) AS 'U_M8' "
                    SQLCmd.CommandText += "      INTO " & Tmps & " "
                    SQLCmd.CommandText += "      FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[DistNumber] NOT LIKE '2013%' "
                    SQLCmd.CommandText += "                     INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "
                    SQLCmd.CommandText += "     WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T0.[MnfDate] Between @FromDate AND @ToDate ) "
                    SQLCmd.CommandText += "  GROUP BY T0.[ItemCode], T2.[ItemName], T1.[WhsCode], T0.[U_M2], T2.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[ExpDate] "
                    '----------------------------------------------------------------------------------------------------------------
                    SQLCmd.CommandText += "   SELECT '生鮮' AS'類別', TX.[存編], TX.[品名], TX.[倉庫], ISNULL(TX.[儲位],'') AS '儲位', SUM(ISNULL(TX.[數量],0)) AS '數量', 0 AS '已派', 0 AS '派工', TX.[單位], SUM(ISNULL(TX.[重量],0)) AS '重量', TX.[製造日期], TX.[有效日期], TX.[天數], TX.[G1], TX.[G2], TX.[G_OK], SUM(ISNULL(TX.[數量2],0)) AS '2號庫數量', SUM(ISNULL(TX.[重量2],0)) AS '2號庫重量' "
                    SQLCmd.CommandText += "     FROM ( "
                    SQLCmd.CommandText += "           SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[WhsCode] AS '倉庫', T0.[U_M2] AS '儲位', "
                    SQLCmd.CommandText += "                  T0.[Quantity] AS '數量', T0.[InvntryUom] as '單位', T0.[U_M1] AS '重量', "
                    SQLCmd.CommandText += "                  T0.[MnfDate] AS '製造日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.[MnfDate], getdate())+1  AS '天數', T0.[DistNumber] AS '條碼', "
                    SQLCmd.CommandText += "                  ISNULL(T0.[U_M8],'') AS '製造單號', ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
                    SQLCmd.CommandText += "                  CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[U_M1] END AS '重量2' "
                    SQLCmd.CommandText += "             FROM ( SELECT * FROM " & Tmps & " "
                    SQLCmd.CommandText += "                  ) T0 LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
                    SQLCmd.CommandText += "                       LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
                    SQLCmd.CommandText += "        GROUP BY T0.[ItemCode], T0.[ItemName], T0.[WhsCode], T0.[U_M2], T0.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[Quantity], T0.[U_M1], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto], T0.[ExpDate] "
                    SQLCmd.CommandText += "          ) TX "
                    SQLCmd.CommandText += "GROUP BY TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], TX.[單位], TX.[製造日期], TX.[天數], TX.[G1], TX.[G2], TX.[G_OK], TX.[有效日期] "
                    SQLCmd.CommandText += "ORDER BY 5, 2 "

                Case "批次"
                    SQLCmd.CommandText += "     SELECT '調理' AS'類別', TX.[存編], TX.[品名], TX.[倉庫], ISNULL(TX.[儲位],'') AS '儲位', SUM(ISNULL(TX.[數量],0)) AS '數量', 0 AS '已派', 0 AS '派工', TX.[單位], SUM(ISNULL(TX.[重量],0)) AS '重量', ISNULL(TX.[製造日期],'') AS '製造日期', ISNULL(TX.[有效日期],'') AS '有效日期', ISNULL(TX.[天數],'') AS '天數', TX.[G1], TX.[G2], TX.[G_OK], SUM(ISNULL(TX.[數量2],0)) AS '2號庫數量', SUM(ISNULL(TX.[重量2],0)) AS '2號庫重量' "
                    SQLCmd.CommandText += "       FROM ( "
                    SQLCmd.CommandText += "             SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[WhsCode] AS '倉庫', T0.[U_M2] AS '儲位', "
                    SQLCmd.CommandText += "                    T0.[Quantity] AS '數量', T0.[InvntryUom] as '單位', T0.[U_M1] AS '重量', "
                    SQLCmd.CommandText += "                    T0.[MnfDate] AS '製造日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.[MnfDate], getdate())+1  AS '天數', T0.[DistNumber] AS '條碼', "
                    SQLCmd.CommandText += "                    ISNULL(T0.[U_M8],'') AS '製造單號', '' AS 'G1', '' AS 'G2', '' AS 'G_OK', "
                    SQLCmd.CommandText += "                    CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[U_M1] END AS '重量2' "
                    SQLCmd.CommandText += "               FROM ( "
                    SQLCmd.CommandText += "                     SELECT T0.[ItemCode] AS 'ItemCode', T2.[ItemName] AS 'ItemName', T1.[WhsCode] AS 'WhsCode', T0.[U_M2] AS 'U_M2', "
                    SQLCmd.CommandText += "                            SUM(CAST(ISNULL(T1.[Quantity],0) AS INT))           AS 'Quantity', T2.[InvntryUom] as 'InvntryUom', "
                    SQLCmd.CommandText += "                            SUM(CAST(ISNULL(T0.[U_M1],0)     AS NUMERIC(19,2))) AS 'U_M1',CONVERT(CHAR(10),T0.[MnfDate], 120) AS 'MnfDate', "
                    SQLCmd.CommandText += "                            CONVERT(CHAR(10),T0.[ExpDate], 120) AS 'ExpDate', T0.[DistNumber], CAST(T0.[U_M8] AS NVARCHAR(12)) AS 'U_M8' "
                    SQLCmd.CommandText += "                       FROM [OBTN] T0 INNER JOIN [OBTQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[DistNumber] NOT LIKE '2013%' "
                    SQLCmd.CommandText += "                                      INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "
                    SQLCmd.CommandText += "                      WHERE T0.[ItemCode] = @ItemCode AND T1.[Quantity] > 0 AND (T0.[MnfDate] Between @FromDate AND @ToDate ) AND T1.[WhsCode] IN ('S01','S04','S06') "
                    SQLCmd.CommandText += "                   GROUP BY T0.[ItemCode], T2.[ItemName], T1.[WhsCode], T0.[U_M2], T2.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[ExpDate] "
                    SQLCmd.CommandText += "                    ) T0 LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
                    SQLCmd.CommandText += "          GROUP BY T0.[ItemCode], T0.[ItemName], T0.[WhsCode], T0.[U_M2], T0.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[Quantity], T0.[U_M1], T7.[InvSto], T0.[ExpDate] "
                    SQLCmd.CommandText += "            ) TX "
                    SQLCmd.CommandText += "  GROUP BY TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], TX.[單位], TX.[製造日期], TX.[天數], TX.[G1], TX.[G2], TX.[G_OK], TX.[有效日期] "
                    SQLCmd.CommandText += "ORDER BY 5, 2 "
            End Select

            SQLCmd.CommandText += " IF (OBJECT_ID('tempdb.." & Tmps & "') IS NOT NULL)  DROP TABLE " & Tmps & " "

            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(DataSetDGV, "DGV22")
            DGV22.DataSource = DataSetDGV.Tables("DGV22")

            'DGV22.AutoResizeColumns()
            DGV22整列資訊()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV22整列資訊()

        If DGV22.RowCount <= 0 Then
            'MsgBox("查無此草稿單號!請重新檢查!", 16, "錯誤")
            Exit Sub
        End If

        For Each column As DataGridViewColumn In DGV22.Columns
            column.Visible = True
            Select Case column.Name
                Case "類別"
                    column.HeaderText = "類別"
                    column.DisplayIndex = 0 ': column.Visible = False
                Case "存編"
                    column.HeaderText = "存編"
                    column.DisplayIndex = 1
                Case "品名"
                    column.HeaderText = "品名"
                    column.DisplayIndex = 2
                Case "倉庫"
                    column.HeaderText = "倉庫"
                    column.DisplayIndex = 3
                Case "儲位"
                    column.HeaderText = "儲位"
                    column.DisplayIndex = 4
                Case "數量"
                    column.HeaderText = "數量"
                    column.DisplayIndex = 5
                Case "已派"
                    column.HeaderText = "已派"
                    column.DisplayIndex = 6 : column.ReadOnly = True
                Case "派工"
                    column.HeaderText = "派工"
                    column.DisplayIndex = 7 : column.ReadOnly = False
                Case "單位"
                    column.HeaderText = "單位"
                    column.DisplayIndex = 8
                Case "重量"
                    column.HeaderText = "重量"
                    column.DisplayIndex = 9
                Case "製造日期"
                    column.HeaderText = "製造日期"
                    column.DisplayIndex = 10
                Case "有效日期"
                    column.HeaderText = "有效日期"
                    column.DisplayIndex = 11
                Case "天數"
                    column.HeaderText = "天數"
                    column.DisplayIndex = 12
                Case "G1"
                    column.HeaderText = "G1"
                    column.DisplayIndex = 13
                Case "G2"
                    column.HeaderText = "G2"
                    column.DisplayIndex = 14
                Case "G_OK"
                    column.HeaderText = "G_OK"
                    column.DisplayIndex = 15
                Case "2號庫數量"
                    column.HeaderText = "2號庫數量"
                    column.DisplayIndex = 16
                Case "2號庫重量"
                    column.HeaderText = "2號庫重量"
                    column.DisplayIndex = 17
                Case Else
                    column.Visible = False
            End Select
        Next
        DGV22.AutoResizeColumns()
    End Sub

End Class


