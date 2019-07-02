Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Dns

Public Class 草稿單入庫轉入
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet
    Dim CheckError1, CheckError2, CheckError3 As String

    Private Sub 草稿單入庫轉入_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtNum.Text = "" Then
            MsgBox("交貨單號不能空白!", 16, "錯誤")
            Exit Sub
        End If
        If txtDocNum.Text = "" Then
            MsgBox("草稿單號不能空白!", 16, "錯誤")
            Exit Sub
        End If

        Dim sql As String = " "
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        sql += " SELECT T0.[FI107K] AS 'OB01', T0.[FI108] AS 'OB02', T0.[FI106]                                    AS 'OB03', 'J212'       AS 'OB04', '1'         AS 'OB05', "
        sql += "        NULL        AS 'OB06', '6'        AS 'OB07', ISNULL(CAST(T1.[DocEntry] AS varchar(20)),'') AS 'OB08', T1.[LineNum] AS 'OB09', '3'         AS 'OB10', "
        sql += "        NULL        AS 'OB11', NULL       AS 'OB12', NULL                   AS 'OB13', NULL        AS 'OB14', NULL         AS 'OB15', T0.[FI118]  AS 'OB16' "
        sql += "   FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] T0 LEFT  JOIN [DRF1] T1 ON T0.[FI107K] = T1.[ItemCode] AND T1.[DocEntry] = '" & txtDocNum.Text & "' "
        sql += "  WHERE T0.[FI100] = '" & txtNum.Text & "' "
        sql += "  ORDER BY 9 "

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")
        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")

        DGV1.AutoResizeColumns()
        Label4.Text = DGV1.RowCount

        CloseSearch()
        CheckError()
        QuantityError()
        ItemError()

        If Label4.Text > 0 And CheckError1 = 0 And CheckError2 = 0 And CheckError3 = 0 Then
            SyncToDB.Enabled = True
        Else
            SyncToDB.Enabled = False
        End If
    End Sub

    Private Sub CloseSearch()
        txtNum.Enabled = False
        txtDocNum.Enabled = False
        btnSearch.Enabled = False
        btnReSearch.Enabled = True
    End Sub

    Private Sub CheckError()
        Dim Red As Integer = 0

        If DGV1.RowCount > 0 Then
            For i As Integer = 0 To DGV1.RowCount - 1
                If DGV1.Rows(i).Cells("OB08").Value = "" Then
                    DGV1.Rows(i).Cells("OB08").Style.BackColor = Color.Red
                    Red += 1
                End If
            Next
        End If

        lblError.Text = "異常數：" & Red
        If Red = 0 Then
            CheckError1 = 0
        Else
            CheckError1 = 1
        End If

    End Sub

    Private Sub QuantityError()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        Dim count As Integer
        count = 0

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If

        'sql = " SELECT T1.[Dscription], CAST(T1.[Quantity] AS INT) AS 'Quantity' ,T0.[Quantity2] "
        'sql += "  FROM [DRF1] T1 LEFT JOIN ( "
        'sql += "  		SELECT T0.[FI107K],T0.[FI108],COUNT(T0.[FI107K]) AS 'Quantity2' "
        'sql += " 	      FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] T0 "
        'sql += " 	     WHERE T0.[FI100] = '" & txtNum.Text & "' "
        'sql += " 	    GROUP BY T0.[FI107K],T0.[FI108] "
        'sql += "  )T0 ON T0.[FI107K] = T1.[ItemCode] "
        'sql += " WHERE T1.[DocEntry] = '" & txtDocNum.Text & "' AND ISNULL(T1.[ItemCode],'') <> '' AND (CAST(T1.[Quantity] AS INT) - T0.[Quantity2]) <> 0 "

        sql = " SELECT T1.[Dscription], CAST(T1.[Quantity] AS INT) AS 'Quantity', T0.[Quantity2] "
        sql += "  FROM [DRF1] T1 LEFT JOIN ( "
        sql += "  		SELECT T0.[FI107K], COUNT(T0.[FI107K]) AS 'Quantity2' "
        sql += " 	      FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] T0 "
        sql += " 	     WHERE T0.[FI100] = '" & txtNum.Text & "' "
        sql += " 	    GROUP BY T0.[FI107K] "
        sql += "  )T0 ON T0.[FI107K] = T1.[ItemCode] "
        sql += " WHERE T1.[DocEntry] = '" & txtDocNum.Text & "' AND ISNULL(T1.[ItemCode],'') <> '' AND (CAST(T1.[Quantity] AS INT) - T0.[Quantity2]) <> 0 "

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")
        DGV2.DataSource = ks1DataSetDGV.Tables("DT2")

        DGV2.AutoResizeColumns()
        ''比對DGV1與DGV2的數量
        'If DGV2.RowCount > 0 Then
        '    For i As Integer = 0 To DGV2.RowCount - 1
        '        For j As Integer = 0 To DGV1.RowCount - 1
        '            '品項相同，count+1
        '            If DGV1.Rows(j).Cells("Dscription").Value = DGV1.Rows(i).Cells("OB02").Value Then
        '                count += 1
        '            End If
        '        Next
        '        'count與數量不相同代表有異常
        '        If count <> DGV1.Rows(i).Cells("Quantity").Value Then
        '            DGV1.Rows(i).Cells("Quantity").Style.BackColor = Color.Red
        '        End If
        '        count = 0
        '        '重設count，並檢查下一個品項
        '    Next
        'End If

        If DGV2.RowCount = 0 Then
            CheckError2 = 0
        Else
            CheckError2 = 1
        End If
    End Sub

    Private Sub ItemError()
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If DGV3.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT3").Clear()
        End If

        sql = " SELECT T0.[FI108]  "
        sql += "  FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] T0 LEFT JOIN ( "
        sql += "        SELECT T1.[ItemCode] ,T1.[Dscription] "
        sql += "          FROM [DRF1] T1 "
        sql += "         WHERE T1.[DocEntry] = '" & txtDocNum.Text & "' "
        sql += " )T1 ON T0.[FI107K] = T1.[ItemCode] "
        sql += " WHERE T0.[FI100] = '" & txtNum.Text & "' AND ISNULL(T1.[ItemCode],'') = '' "
        sql += " GROUP BY T0.[FI107K],T0.[FI108],T1.[Dscription]  "

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT3")
        DGV3.DataSource = ks1DataSetDGV.Tables("DT3")

        DGV3.AutoResizeColumns()
        If DGV3.RowCount = 0 Then
            CheckError3 = 0
        Else
            CheckError3 = 1
        End If
    End Sub

    Private Sub SyncToDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SyncToDB.Click
        Dim sql As String = ""
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand
        'sql = "    DELETE FROM [@ksOBList] WHERE [OB08] = '" & DGV1.Rows(0).Cells("OB08").Value & "' "
        sql = "    DELETE FROM [@ksOBList] WHERE [OB08] = '" & txtDocNum.Text & "' "
        sql += "   INSERT INTO [@ksOBList] ( "
        sql += "          [OB01],[OB02],[OB03],[OB04],[OB05],[OB06],[OB07],[OB08],[OB09],[OB10], "
        sql += "          [OB11],[OB12],[OB13],[OB14],[OB15],[OB16]) "
        sql += "   SELECT T0.[FI107K] AS 'OB01', T0.[FI108] AS 'OB02', T0.[FI106]    AS 'OB03', 'J212'       AS 'OB04', '1'   AS 'OB05', "
        sql += "          NULL        AS 'OB06', '6'        AS 'OB07', T1.[DocEntry] AS 'OB08', T1.[LineNum] AS 'OB09', '3'   AS 'OB10', "
        sql += "          NULL        AS 'OB11', NULL       AS 'OB12', NULL          AS 'OB13', NULL         AS 'OB14', NULL  AS 'OB15', "
        sql += "          T0.[FI118]  AS 'OB16' "
        sql += "     FROM [KaiShingPlug].[dbo].[KS_Turn_SS_Barcode] T0 LEFT  JOIN [DRF1] T1 ON T0.[FI107K] = T1.[ItemCode] AND T1.[DocEntry] = '" & txtDocNum.Text & "' "     '草稿號編
        sql += "    WHERE T0.[FI100] = '" & txtNum.Text & "' "  '轉入之交貨單號 
        sql += " ORDER BY 9 "

        'If DGV1.RowCount > 0 Then
        '    For i = 0 To DGV1.RowCount - 1
        '        sql += " INSERT INTO [@ksOBList] ([OB01], [OB02], [OB03], [OB04], [OB05], [OB06], [OB07], [OB08], [OB09], [OB10], [OB11], [OB12], [OB13], [OB14], [OB15], [OB16])  "
        '        sql += " VALUES ('" & DGV1.Rows(i).Cells("OB01").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB02").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB03").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB04").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB05").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB06").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB07").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB08").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB09").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB10").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB11").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB12").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB13").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB14").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB16").Value & "', "
        '        sql += "         '" & DGV1.Rows(i).Cells("OB16").Value & "' ) "
        '    Next
        'End If

        Try
            SQLCmd.Connection = DBConn : SQLCmd.CommandText = sql : SQLCmd.CommandTimeout = 100000
            SQLCmd.Parameters.Clear() : SQLCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        MsgBox("資料庫同步成功!")
        btnReSearch.PerformClick()

    End Sub

    Private Sub btnReSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReSearch.Click
        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        txtNum.Text = ""
        txtDocNum.Text = ""
        txtNum.Enabled = True
        txtDocNum.Enabled = True
        btnSearch.Enabled = True
        btnReSearch.Enabled = False
        SyncToDB.Enabled = False
    End Sub
End Class