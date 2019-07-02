Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class D_CompareFrom

    Private Sub D_CompareFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1        
    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If AccType.SelectedIndex = -1 Then
            MsgBox("請選擇比較類型!")
            AccType.Focus()
            Exit Sub
        End If

        If AccType.SelectedIndex = 0 Or AccType.SelectedIndex = 1 Or AccType.SelectedIndex = 2 Or AccType.SelectedIndex = 5 Or AccType.SelectedIndex = 6 Or AccType.SelectedIndex = 13 Or AccType.SelectedIndex = 14 Or AccType.SelectedIndex = 15 Or AccType.SelectedIndex = 7 Or AccType.SelectedIndex = 17 Then
            Compare_1()
        End If

        If AccType.SelectedIndex = 8 Or AccType.SelectedIndex = 9 Or AccType.SelectedIndex = 10 Then
            Compare_2()
        End If

        If AccType.SelectedIndex = 3 Or AccType.SelectedIndex = 4 Or AccType.SelectedIndex = 11 Or AccType.SelectedIndex = 12 Or AccType.SelectedIndex = 16 Then
            MsgBox("抱歉，此功能尚未完成!")
            Exit Sub
        End If

    End Sub

    Private Sub Compare_1()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If AccType.SelectedIndex = 0 Then
            If Login.catalog = "KaiShing_150310" Then
                sql = "exec L20110913_01 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
            End If
            If Login.catalog = "kFS_00" Then
                sql = "exec L20110913_01_1 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
            End If
        End If

        If AccType.SelectedIndex = 1 Then
            If Login.catalog = "KaiShing_150310" Then
                sql = "exec L20110913_02 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
            End If
            If Login.catalog = "kFS_00" Then
                sql = "exec L20110913_02_1 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
            End If
        End If

        If AccType.SelectedIndex = 2 Then
            If Login.catalog = "KaiShing_150310" Then
                sql = "exec L20110913_03 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
            End If
            If Login.catalog = "kFS_00" Then
                sql = "exec L20110913_03_1 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
            End If
        End If

        If AccType.SelectedIndex = 5 Then
            sql = "exec L20110914_04 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 6 Then
            sql = "exec L20110914_05 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 13 Then
            sql = "exec L20110914_06 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 14 Then
            sql = "exec L20110914_07 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 15 Then
            sql = "exec L20110916_01 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 7 Then
            sql = "exec L20110916_02 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 17 Then
            sql = "exec L20110913_04 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If


        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        DGV1.DataSource = ksDataSet.Tables("DT1")

        Dim Count_1 As Integer = 0
        Dim Count_2 As Integer = 0
        Dim Count_3 As Integer = 0
        Dim Count_4 As Integer = 0
        Dim Count_5 As Integer = 0
        Dim Count_6 As Integer = 0
        Dim Count_7 As Integer = 0
        Dim Count_8 As Integer = 0
        Dim Count_9 As Integer = 0
        Dim Count_10 As Integer = 0
        Dim Count_11 As Integer = 0
        Dim Count_12 As Integer = 0

        For i As Integer = 0 To DGV1.RowCount - 1
            Count_1 += DGV1.Rows(i).Cells("期間1").Value
            Count_2 += DGV1.Rows(i).Cells("期間2").Value
            Count_3 += DGV1.Rows(i).Cells("期間3").Value
            Count_4 += DGV1.Rows(i).Cells("期間4").Value
            Count_5 += DGV1.Rows(i).Cells("期間5").Value
            Count_6 += DGV1.Rows(i).Cells("期間6").Value
            Count_7 += DGV1.Rows(i).Cells("期間7").Value
            Count_8 += DGV1.Rows(i).Cells("期間8").Value
            Count_9 += DGV1.Rows(i).Cells("期間9").Value
            Count_10 += DGV1.Rows(i).Cells("期間10").Value
            Count_11 += DGV1.Rows(i).Cells("期間11").Value
            Count_12 += DGV1.Rows(i).Cells("期間12").Value
        Next

        Count1.Text = "期間一合計：" + Format(Count_1, "###,##0")
        Count2.Text = "期間二合計：" + Format(Count_2, "###,##0")
        Count3.Text = "期間三合計：" + Format(Count_3, "###,##0")
        Count4.Text = "期間四合計：" + Format(Count_4, "###,##0")
        Count5.Text = "期間五合計：" + Format(Count_5, "###,##0")
        Count6.Text = "期間六合計：" + Format(Count_6, "###,##0")
        Count7.Text = "期間七合計：" + Format(Count_7, "###,##0")
        Count8.Text = "期間八合計：" + Format(Count_8, "###,##0")
        Count9.Text = "期間九合計：" + Format(Count_9, "###,##0")
        Count10.Text = "期間十合計：" + Format(Count_10, "###,##0")
        Count11.Text = "期間十一合計：" + Format(Count_11, "###,##0")
        Count12.Text = "期間十二合計：" + Format(Count_12, "###,##0")

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "會科代碼", "業務夥伴代碼"
                    column.DisplayIndex = 0
                Case "會科名稱", "業務夥伴名稱"
                    column.DisplayIndex = 1
                Case "期間1"
                    column.DisplayIndex = 2
                    column.HeaderText = FromDate1.Value.Date + "~" + ToDate1.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period1.Checked Then
                        column.Visible = True
                        Count1.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間2"
                    column.DisplayIndex = 3
                    column.HeaderText = FromDate2.Value.Date + "~" + ToDate2.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period2.Checked Then
                        column.Visible = True
                        Count2.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間3"
                    column.DisplayIndex = 4
                    column.HeaderText = FromDate3.Value.Date + "~" + ToDate3.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period3.Checked Then
                        column.Visible = True
                        Count3.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間4"
                    column.DisplayIndex = 5
                    column.HeaderText = FromDate4.Value.Date + "~" + ToDate4.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period4.Checked Then
                        column.Visible = True
                        Count4.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間5"
                    column.DisplayIndex = 6
                    column.HeaderText = FromDate5.Value.Date + "~" + ToDate5.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period5.Checked Then
                        column.Visible = True
                        Count5.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間6"
                    column.DisplayIndex = 7
                    column.HeaderText = FromDate6.Value.Date + "~" + ToDate6.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period6.Checked Then
                        column.Visible = True
                        Count6.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間7"
                    column.DisplayIndex = 8
                    column.HeaderText = FromDate7.Value.Date + "~" + ToDate7.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period7.Checked Then
                        column.Visible = True
                        Count7.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間8"
                    column.DisplayIndex = 9
                    column.HeaderText = FromDate8.Value.Date + "~" + ToDate8.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period8.Checked Then
                        column.Visible = True
                        Count8.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間9"
                    column.DisplayIndex = 10
                    column.HeaderText = FromDate9.Value.Date + "~" + ToDate9.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period9.Checked Then
                        column.Visible = True
                        Count9.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間10"
                    column.DisplayIndex = 11
                    column.HeaderText = FromDate10.Value.Date + "~" + ToDate10.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period10.Checked Then
                        column.Visible = True
                        Count10.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間11"
                    column.DisplayIndex = 12
                    column.HeaderText = FromDate11.Value.Date + "~" + ToDate11.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period11.Checked Then
                        column.Visible = True
                        Count11.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間12"
                    column.DisplayIndex = 13
                    column.HeaderText = FromDate12.Value.Date + "~" + ToDate12.Value.Date
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period12.Checked Then
                        column.Visible = True
                        Count12.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub Compare_2()
        Dim DataAdapter1 As SqlDataAdapter
        Dim ksDataSet As DataSet = New DataSet
        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        If AccType.SelectedIndex = 8 Then
            sql = "exec L20110914_01 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 9 Then
            sql = "exec L20110914_02 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        If AccType.SelectedIndex = 10 Then
            sql = "exec L20110914_03 '" & FromDate1.Value.Date & "' , '" & ToDate1.Value.Date & "' , '" & FromDate2.Value.Date & "' , '" & ToDate2.Value.Date & "' , '" & FromDate3.Value.Date & "' , '" & ToDate3.Value.Date & "' , '" & FromDate4.Value.Date & "' , '" & ToDate4.Value.Date & "' , '" & FromDate5.Value.Date & "' , '" & ToDate5.Value.Date & "' , '" & FromDate6.Value.Date & "' , '" & ToDate6.Value.Date & "' , '" & FromDate7.Value.Date & "' , '" & ToDate7.Value.Date & "' , '" & FromDate8.Value.Date & "' , '" & ToDate8.Value.Date & "' , '" & FromDate9.Value.Date & "' , '" & ToDate9.Value.Date & "' , '" & FromDate10.Value.Date & "' , '" & ToDate10.Value.Date & "' , '" & FromDate11.Value.Date & "' , '" & ToDate11.Value.Date & "' , '" & FromDate12.Value.Date & "' , '" & ToDate12.Value.Date & "'   "
        End If

        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql
        SQLCmd.CommandType = CommandType.StoredProcedure

        DataAdapter1 = New SqlDataAdapter(sql, DBConn)
        DataAdapter1.Fill(ksDataSet, "DT1")

        DGV1.DataSource = ksDataSet.Tables("DT1")

        Dim Count_1 As Integer = 0
        Dim Count_2 As Integer = 0
        Dim Count_3 As Integer = 0
        Dim Count_4 As Integer = 0
        Dim Count_5 As Integer = 0
        Dim Count_6 As Integer = 0
        Dim Count_7 As Integer = 0
        Dim Count_8 As Integer = 0
        Dim Count_9 As Integer = 0
        Dim Count_10 As Integer = 0
        Dim Count_11 As Integer = 0
        Dim Count_12 As Integer = 0
        Dim Count_13 As Integer = 0
        Dim Count_14 As Integer = 0
        Dim Count_15 As Integer = 0
        Dim Count_16 As Integer = 0
        Dim Count_17 As Integer = 0
        Dim Count_18 As Integer = 0
        Dim Count_19 As Integer = 0
        Dim Count_20 As Integer = 0
        Dim Count_21 As Integer = 0
        Dim Count_22 As Integer = 0
        Dim Count_23 As Integer = 0
        Dim Count_24 As Integer = 0


        For i As Integer = 0 To DGV1.RowCount - 1
            Count_1 += DGV1.Rows(i).Cells("期間1借項").Value
            Count_2 += DGV1.Rows(i).Cells("期間1貸項").Value
            Count_3 += DGV1.Rows(i).Cells("期間2借項").Value
            Count_4 += DGV1.Rows(i).Cells("期間2貸項").Value
            Count_5 += DGV1.Rows(i).Cells("期間3借項").Value
            Count_6 += DGV1.Rows(i).Cells("期間3貸項").Value
            Count_7 += DGV1.Rows(i).Cells("期間4借項").Value
            Count_8 += DGV1.Rows(i).Cells("期間4貸項").Value
            Count_9 += DGV1.Rows(i).Cells("期間5借項").Value
            Count_10 += DGV1.Rows(i).Cells("期間5貸項").Value
            Count_11 += DGV1.Rows(i).Cells("期間6借項").Value
            Count_12 += DGV1.Rows(i).Cells("期間6貸項").Value
            Count_13 += DGV1.Rows(i).Cells("期間7借項").Value
            Count_14 += DGV1.Rows(i).Cells("期間7貸項").Value
            Count_15 += DGV1.Rows(i).Cells("期間8借項").Value
            Count_16 += DGV1.Rows(i).Cells("期間8貸項").Value
            Count_17 += DGV1.Rows(i).Cells("期間9借項").Value
            Count_18 += DGV1.Rows(i).Cells("期間9貸項").Value
            Count_19 += DGV1.Rows(i).Cells("期間10借項").Value
            Count_20 += DGV1.Rows(i).Cells("期間10貸項").Value
            Count_21 += DGV1.Rows(i).Cells("期間11借項").Value
            Count_22 += DGV1.Rows(i).Cells("期間11貸項").Value
            Count_23 += DGV1.Rows(i).Cells("期間12借項").Value
            Count_24 += DGV1.Rows(i).Cells("期間12貸項").Value
        Next

        Count1.Text = "期間一：借項：" + Format(Count_1, "###,##0") + " 貸項：" + Format(Count_2, "###,##0")
        Count2.Text = "期間二：借項：" + Format(Count_3, "###,##0") + " 貸項：" + Format(Count_4, "###,##0")
        Count3.Text = "期間三：借項：" + Format(Count_5, "###,##0") + " 貸項：" + Format(Count_6, "###,##0")
        Count4.Text = "期間四：借項：" + Format(Count_7, "###,##0") + " 貸項：" + Format(Count_8, "###,##0")
        Count5.Text = "期間五：借項：" + Format(Count_9, "###,##0") + " 貸項：" + Format(Count_10, "###,##0")
        Count6.Text = "期間六：借項：" + Format(Count_11, "###,##0") + " 貸項：" + Format(Count_12, "###,##0")
        Count7.Text = "期間七：借項：" + Format(Count_13, "###,##0") + " 貸項：" + Format(Count_14, "###,##0")
        Count8.Text = "期間八：借項：" + Format(Count_15, "###,##0") + " 貸項：" + Format(Count_16, "###,##0")
        Count9.Text = "期間九：借項：" + Format(Count_17, "###,##0") + " 貸項：" + Format(Count_18, "###,##0")
        Count10.Text = "期間十：借項：" + Format(Count_19, "###,##0") + " 貸項：" + Format(Count_20, "###,##0")
        Count11.Text = "期間十一：借項：" + Format(Count_21, "###,##0") + " 貸項：" + Format(Count_22, "###,##0")
        Count12.Text = "期間十二：借項：" + Format(Count_23, "###,##0") + " 貸項：" + Format(Count_24, "###,##0")

        For Each column As DataGridViewColumn In DGV1.Columns
            column.Visible = True
            Select Case column.Name
                Case "會科代碼"
                    column.DisplayIndex = 0
                Case "會科名稱"
                    column.DisplayIndex = 1

                Case "期間1借項"
                    column.DisplayIndex = 2
                    column.HeaderText = FromDate1.Value.Date + "~" + ToDate1.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period1.Checked Then
                        column.Visible = True
                        Count1.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間1貸項"
                    column.DisplayIndex = 3
                    column.HeaderText = FromDate1.Value.Date + "~" + ToDate1.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period1.Checked Then
                        column.Visible = True
                        Count1.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間2借項"
                    column.DisplayIndex = 4
                    column.HeaderText = FromDate2.Value.Date + "~" + ToDate2.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period2.Checked Then
                        column.Visible = True
                        Count2.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間2貸項"
                    column.DisplayIndex = 5
                    column.HeaderText = FromDate2.Value.Date + "~" + ToDate2.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period2.Checked Then
                        column.Visible = True
                        Count2.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間3借項"
                    column.DisplayIndex = 6
                    column.HeaderText = FromDate3.Value.Date + "~" + ToDate3.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period3.Checked Then
                        column.Visible = True
                        Count3.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間3貸項"
                    column.DisplayIndex = 7
                    column.HeaderText = FromDate3.Value.Date + "~" + ToDate3.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period3.Checked Then
                        column.Visible = True
                        Count3.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間4借項"
                    column.DisplayIndex = 8
                    column.HeaderText = FromDate4.Value.Date + "~" + ToDate4.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period4.Checked Then
                        column.Visible = True
                        Count4.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間4貸項"
                    column.DisplayIndex = 9
                    column.HeaderText = FromDate4.Value.Date + "~" + ToDate4.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period4.Checked Then
                        column.Visible = True
                        Count4.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間5借項"
                    column.DisplayIndex = 10
                    column.HeaderText = FromDate5.Value.Date + "~" + ToDate5.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period5.Checked Then
                        column.Visible = True
                        Count5.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間5貸項"
                    column.DisplayIndex = 11
                    column.HeaderText = FromDate5.Value.Date + "~" + ToDate5.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period5.Checked Then
                        column.Visible = True
                        Count5.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間6借項"
                    column.DisplayIndex = 12
                    column.HeaderText = FromDate6.Value.Date + "~" + ToDate6.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period6.Checked Then
                        column.Visible = True
                        Count6.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間6貸項"
                    column.DisplayIndex = 13
                    column.HeaderText = FromDate6.Value.Date + "~" + ToDate6.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period6.Checked Then
                        column.Visible = True
                        Count6.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間7借項"
                    column.DisplayIndex = 14
                    column.HeaderText = FromDate7.Value.Date + "~" + ToDate7.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period7.Checked Then
                        column.Visible = True
                        Count7.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間7貸項"
                    column.DisplayIndex = 15
                    column.HeaderText = FromDate7.Value.Date + "~" + ToDate7.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period7.Checked Then
                        column.Visible = True
                        Count7.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間8借項"
                    column.DisplayIndex = 16
                    column.HeaderText = FromDate8.Value.Date + "~" + ToDate8.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period8.Checked Then
                        column.Visible = True
                        Count8.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間8貸項"
                    column.DisplayIndex = 17
                    column.HeaderText = FromDate8.Value.Date + "~" + ToDate8.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period8.Checked Then
                        column.Visible = True
                        Count8.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間9借項"
                    column.DisplayIndex = 18
                    column.HeaderText = FromDate9.Value.Date + "~" + ToDate9.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period9.Checked Then
                        column.Visible = True
                        Count9.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間9貸項"
                    column.DisplayIndex = 19
                    column.HeaderText = FromDate9.Value.Date + "~" + ToDate9.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period9.Checked Then
                        column.Visible = True
                        Count9.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間10借項"
                    column.DisplayIndex = 20
                    column.HeaderText = FromDate10.Value.Date + "~" + ToDate10.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period10.Checked Then
                        column.Visible = True
                        Count10.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間10貸項"
                    column.DisplayIndex = 21
                    column.HeaderText = FromDate10.Value.Date + "~" + ToDate10.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period10.Checked Then
                        column.Visible = True
                        Count10.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間11借項"
                    column.DisplayIndex = 22
                    column.HeaderText = FromDate11.Value.Date + "~" + ToDate11.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period11.Checked Then
                        column.Visible = True
                        Count11.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間11貸項"
                    column.DisplayIndex = 23
                    column.HeaderText = FromDate11.Value.Date + "~" + ToDate11.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period11.Checked Then
                        column.Visible = True
                        Count11.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case "期間12借項"
                    column.DisplayIndex = 24
                    column.HeaderText = FromDate12.Value.Date + "~" + ToDate12.Value.Date + "借項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period12.Checked Then
                        column.Visible = True
                        Count12.Visible = True
                    Else
                        column.Visible = False
                    End If
                Case "期間12貸項"
                    column.DisplayIndex = 25
                    column.HeaderText = FromDate12.Value.Date + "~" + ToDate12.Value.Date + "貸項"
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    column.DefaultCellStyle.Format = "###,##0"
                    If Period12.Checked Then
                        column.Visible = True
                        Count12.Visible = True
                    Else
                        column.Visible = False
                    End If

                Case Else
                    column.Visible = False
            End Select
        Next

        DGV1.Refresh()
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub ToExcelBtn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToExcelBtn1.Click
        Dim str As String = AccType.Text
        DataToExcel(DGV1, str)
    End Sub
End Class