Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class C_QuerySRNInPDAIn
    Dim ks1DataSet As DataSet = New DataSet

    Private Sub C_QuerySRNInPDAIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV3.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If enterPDA03.Text = "" Then
            MsgBox("請輸入條碼")
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ks1DataSet.Tables("DT1").Clear()
        End If

        If DGV2.RowCount > 0 Then
            ks1DataSet.Tables("DT2").Clear()
        End If

        If DGV3.RowCount > 0 Then
            ks1DataSet.Tables("DT3").Clear()
        End If

        LoadDGV1()
        LoadDGV2()
        LoadDGV3()
    End Sub

    Private Sub LoadDGV1()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If RB1.Checked = True Then
                sql = "SELECT FI101 as '生產單號',FI102 as '製單號',CASE FI103 when '1' then '處理中' when '2' then '已列印' when '3' then '已清點' when '4' then '已入庫' when '5' then '標註作廢' when '6' then '確認作廢' end as '狀態' ,FI105 as '文件日期',FI106 as '條碼',FI107 as '存貨編號',FI108 as '品名',FI109 as '實際製造日期',FI110 as '標示製造日期',FI111 as '有效日期',FI117 as '隻數',FI118 as '重量',FI119 as '客戶代碼',FI123 as '單位',FI127 as '標簽列印名稱' FROM [@FinishItem1] Where FI106 = '" & enterPDA03.Text & "' "
            End If

            If RB2.Checked = True Then
                sql = "SELECT FI101 as '生產單號',FI102 as '製單號',CASE FI103 when '1' then '處理中' when '2' then '已列印' when '3' then '已清點' when '4' then '已入庫' when '5' then '標註作廢' when '6' then '確認作廢' end as '狀態' ,FI105 as '文件日期',FI106 as '條碼',FI107 as '存貨編號',FI108 as '品名',FI109 as '實際製造日期',FI110 as '標示製造日期',FI111 as '有效日期',FI117 as '隻數',FI118 as '重量',FI119 as '客戶代碼',FI123 as '單位',FI127 as '標簽列印名稱' FROM [@FinishItem2] Where FI106 = '" & enterPDA03.Text & "' "
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT1")
            DGV1.DataSource = ks1DataSet.Tables("DT1")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        DGV1.AutoResizeColumns()

    End Sub

    Private Sub LoadDGV2()

        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            sql = "SELECT PDA02 as '作業別',PDA03 as '條碼',PDA04 as '儲位' , CASE PDA06 when '1' then '建立' when '2' then '已清點' when '3' then '已同步' when '4' then '已入庫' when '5' then '作廢' end as '狀態' FROM [@ksPDAIn] where PDA03 = '" & enterPDA03.Text & "' "
            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT2")
            DGV2.DataSource = ks1DataSet.Tables("DT2")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        DGV2.AutoResizeColumns()

    End Sub

    Private Sub LoadDGV3()
        Dim DataAdapter1 As SqlDataAdapter
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Try
            If RB1.Checked = True Then
                sql = "SELECT T0.[ItemCode] as '存編', T2.[ItemName] as '品名', T0.[DistNumber] as '序號',sum(T1.Quantity) as '可用數'  ,T0.[InDate] as '許可日期', T0.[MnfDate] as '製造日期', T0.[ExpDate] as '到期日', T0.[U_MC] as '客戶代碼', T0.[U_M2] as '儲位', T0.[U_M1] as '重量', T0.[U_M8] as '製單編號' FROM OSRN T0  LEFT JOIN OSRQ T1 ON T0.ItemCode = T1.ItemCode AND T0.SysNumber = T1.SysNumber INNER JOIN OITM T2 ON T0.ItemCode = T2.ItemCode WHERE T0.[DistNumber] = '" & enterPDA03.Text & "' Group By T0.[ItemCode], T2.[ItemName], T0.[DistNumber],T0.[InDate], T0.[MnfDate], T0.[ExpDate], T0.[U_MC], T0.[U_M2], T0.[U_M1], T0.[U_M8]"
            End If

            If RB2.Checked = True Then
                sql = "SELECT T0.[ItemCode] as '存編', T2.[ItemName] as '品名', T0.[DistNumber] as '序號',sum(T1.Quantity) as '可用數'  ,T0.[InDate] as '許可日期', T0.[MnfDate] as '製造日期', T0.[ExpDate] as '到期日', T0.[U_MC] as '客戶代碼', T0.[U_M2] as '儲位', T0.[U_M1] as '重量', T0.[U_M8] as '製單編號' FROM OBTN T0  LEFT JOIN OBTQ T1 ON T0.ItemCode = T1.ItemCode AND T0.SysNumber = T1.SysNumber INNER JOIN OITM T2 ON T0.ItemCode = T2.ItemCode WHERE T0.[DistNumber] = '" & enterPDA03.Text & "' Group By T0.[ItemCode], T2.[ItemName], T0.[DistNumber],T0.[InDate], T0.[MnfDate], T0.[ExpDate], T0.[U_MC], T0.[U_M2], T0.[U_M1], T0.[U_M8]"
            End If

            DataAdapter1 = New SqlDataAdapter(sql, DBConn)
            DataAdapter1.Fill(ks1DataSet, "DT3")
            DGV3.DataSource = ks1DataSet.Tables("DT3")
        Catch ex As Exception
            MsgBox("錯誤: " & ex.Message)
            End
        End Try

        DGV3.AutoResizeColumns()
    End Sub
End Class