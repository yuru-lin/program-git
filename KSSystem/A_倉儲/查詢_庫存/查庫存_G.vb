Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class 查庫存_G
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub 查庫存_G_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub 查詢_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查詢.Click
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" Then
            MsgBox("未KEY查詢項目", 48, "警告")
            TextBox1.Focus()
            Exit Sub
        End If

        查庫存()
    End Sub

    Private Sub 查庫存()
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DGV1").Clear()
        End If

        Try
            Dim DBConn As SqlConnection = Login.DBConn
            Dim SQLCmd As SqlCommand = New SqlCommand
            SQLCmd.Connection = DBConn

            Dim x4xx As String = Format(Replace(TextBox6.Text, ",", "','"), "")
            Dim x5xx As String = Format(Replace(TextBox4.Text, ",", "','"), "")
            Dim x7x8 As String = Format(Replace(TextBox5.Text, ",", "','"), "")

            SQLCmd.CommandText = " DECLARE @code NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @name NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @um2  NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @FromDate DateTime "
            SQLCmd.CommandText += "DECLARE @ToDate   DateTime "
            'SQLCmd.CommandText += "SET NOCOUNT ON "
            SQLCmd.CommandText += "SET @code     = '" & Format(TextBox1.Text, "") & "' "
            SQLCmd.CommandText += "SET @name     = '" & Format(TextBox2.Text, "") & "' "
            If TextBox3.Text <> "" Then
                SQLCmd.CommandText += "SET @um2  = '" & Format(TextBox3.Text, "") & "%' "
            Else
                SQLCmd.CommandText += "SET @um2  = '' "
            End If
            SQLCmd.CommandText += "SET @FromDate = '" & Format(DTP1.Value.Date, "yyyy-MM-dd") & "' "
            SQLCmd.CommandText += "SET @ToDate   = '" & Format(DTP2.Value.Date, "yyyy-MM-dd") & "' "

            SQLCmd.CommandText += "DECLARE @ALL1 NVARCHAR(20) "
            SQLCmd.CommandText += "DECLARE @ALL2 NVARCHAR(20) "
            SQLCmd.CommandText += "SET     @ALL1 = 'NO' "
            SQLCmd.CommandText += "SET     @ALL2 = 'NO' "

            SQLCmd.CommandText += "IF @code = '' OR @code = NULL SET @ALL1 = 'ALL' "
            SQLCmd.CommandText += "IF @um2  = '' OR @um2  = NULL SET @ALL2 = 'ALL' "

            SQLCmd.CommandText += "   SELECT '生鮮' AS'類別', TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], SUM(ISNULL(TX.[數量],0)) AS '數量', TX.[單位], SUM(ISNULL(TX.[重量],0)) AS '重量', TX.[製造日期], TX.[有效日期], TX.[天數], TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK], SUM(ISNULL(TX.[數量2],0)) AS '2號庫數量', SUM(ISNULL(TX.[重量2],0)) AS '2號庫重量' "
            SQLCmd.CommandText += "     FROM ( "
            SQLCmd.CommandText += "           SELECT T0.[ItemCode] AS '存編', T0.[ItemName] AS '品名', T0.[WhsCode] AS '倉庫', T0.[U_M2] AS '儲位', "
            SQLCmd.CommandText += "                  T0.[Quantity] AS '數量', T0.[InvntryUom] as '單位', T0.[U_M1] AS '重量', "
            SQLCmd.CommandText += "                  T0.[MnfDate] AS '製造日期', T0.[ExpDate] AS '有效日期', DATEDIFF(DAY,T0.[MnfDate], getdate())+1  AS '天數', T0.[DistNumber] AS '條碼', "
            SQLCmd.CommandText += "                  ISNULL(T0.[U_M8],'') AS '製造單號', ISNULL(T4.[M_NO],'') AS 'G1', ISNULL(T6.[Kind],'') AS 'G2', ISNULL(T5.[M_NO],'') AS 'G_OK', "
            SQLCmd.CommandText += "                  CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[Quantity] END AS '數量2', CASE WHEN ISNULL(T7.[InvSto],'0') = '0' THEN 0 ELSE T0.[U_M1] END AS '重量2' "
            SQLCmd.CommandText += "             FROM ( "
            SQLCmd.CommandText += "                   SELECT T0.[ItemCode] AS 'ItemCode', T2.[ItemName] AS 'ItemName', T1.[WhsCode] AS 'WhsCode', T0.[U_M2] AS 'U_M2', "
            SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T1.[Quantity],0) AS INT))           AS 'Quantity', T2.[InvntryUom] as 'InvntryUom', "
            SQLCmd.CommandText += "                          SUM(CAST(ISNULL(T0.[U_M1],0)     AS NUMERIC(19,2))) AS 'U_M1',CONVERT(CHAR(10),T0.[MnfDate], 120) AS 'MnfDate',  "
            SQLCmd.CommandText += "                          CONVERT(CHAR(10),T0.[ExpDate], 120) AS 'ExpDate', T0.[DistNumber], CAST(T0.[U_M8] AS NVARCHAR(12)) AS 'U_M8' "
            SQLCmd.CommandText += "                     FROM [OSRN] T0 INNER JOIN [OSRQ] T1 ON T0.[ItemCode] = T1.[ItemCode] AND T0.[SysNumber] = T1.[SysNumber] AND T0.[AbsEntry] = T1.[MdAbsEntry] AND T0.[DistNumber] NOT LIKE '2013%' "
            SQLCmd.CommandText += "                                    INNER JOIN [OITM] T2 ON T0.[ItemCode] = T2.[ItemCode] "

            SQLCmd.CommandText += "                    WHERE T1.[Quantity] > 0 AND (T0.[U_M2] Like @um2 OR @ALL2 = 'ALL') AND (T0.[MnfDate] BETWEEN @FromDate AND @ToDate) "

            If TextBox1.Text <> "" Then
                SQLCmd.CommandText += "                  AND (T0.[ItemCode] = @code OR @ALL1 = 'ALL') "
            End If
            If TextBox2.Text <> "" Then
                SQLCmd.CommandText += "                  AND (T2.[ItemName] LIKE '%'+@name+'%') "
            End If

            SQLCmd.CommandText += "                 GROUP BY T0.[ItemCode], T2.[ItemName], T1.[WhsCode], T0.[U_M2], T2.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[ExpDate] "
            SQLCmd.CommandText += "                  ) T0 "
            SQLCmd.CommandText += "                       LEFT JOIN [z_format_G]       T4 ON T0.[U_M8]       = T4.[M_NO] "
            SQLCmd.CommandText += "                       LEFT JOIN [z_format_G_OK]    T5 ON T0.[U_M8]       = T5.[M_NO] "
            SQLCmd.CommandText += "                       LEFT JOIN [z_format_MnfDate] T6 ON T0.[MnfDate]    = T6.[MnfDate] "
            SQLCmd.CommandText += "                       LEFT JOIN [z_NO2]            T7 ON T0.[DistNumber] = T7.[InvSto] "
            SQLCmd.CommandText += "        GROUP BY T0.[ItemCode], T0.[ItemName], T0.[WhsCode], T0.[U_M2], T0.[InvntryUom], T0.[MnfDate], T0.[DistNumber], T0.[U_M8], T0.[Quantity], T0.[U_M1], T4.[M_NO], T6.[Kind], T5.[M_NO], T7.[InvSto], T0.[ExpDate] "
            SQLCmd.CommandText += "          ) TX "
            SQLCmd.CommandText += "GROUP BY TX.[存編], TX.[品名], TX.[倉庫], TX.[儲位], TX.[單位], TX.[製造日期], TX.[天數], TX.[製造單號], TX.[G1], TX.[G2], TX.[G_OK], TX.[有效日期] "
            SQLCmd.CommandText += "  HAVING ([儲位] Like @um2 OR @ALL2 = 'ALL') "

            If TextBox6.Text <> "" Then
                SQLCmd.CommandText += " AND SUBSTRING([存編],4,1) IN ('" & x4xx & "') "
            End If
            If TextBox4.Text <> "" Then
                SQLCmd.CommandText += " AND SUBSTRING([存編],5,1) IN ('" & x5xx & "') "
            End If
            If TextBox5.Text <> "" Then
                SQLCmd.CommandText += " AND SUBSTRING([存編],7,2) IN ('" & x7x8 & "') "
            End If


            SQLCmd.Parameters.Clear()
            SQLCmd.ExecuteNonQuery()

            DataAdapterDGV = New SqlDataAdapter(SQLCmd.CommandText, DBConn)
            DataAdapterDGV.Fill(ks1DataSetDGV, "DGV1")
            DGV1.DataSource = ks1DataSetDGV.Tables("DGV1")

            DGV1.AutoResizeColumns()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub 轉出Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 轉出Excel.Click
        DataToExcel(DGV1, "")
    End Sub

    Private Sub 查庫位_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 查庫位.Click

        Dim UM2 As String = ""
        UM2 = Format(DGV1.CurrentRow.Cells("儲位").Value, "")

        If UM2 = "" Then
            MsgBox("請選擇儲位")
            Exit Sub
        End If

        查單庫位.MdiParent = MainForm
        查單庫位.UM2s.Text = UM2
        查單庫位.Show()

    End Sub
End Class