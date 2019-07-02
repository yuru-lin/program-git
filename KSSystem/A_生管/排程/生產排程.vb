Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class 生產排程

    Dim DataAdapterDGV, DataDGV As SqlDataAdapter
    Dim Tab1DataSetDGV As DataSet = New DataSet

    Private Sub 生產排程_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Tab_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab.SelectedIndexChanged
        Select Case Tab.SelectedIndex
            Case 0  '生產排程
                DGV1.Visible = True

            Case 1  '生產領料
                DGV1.Visible = True

            Case 2  '領料總表
                DGV1.Visible = False

            Case 3  '排程總表
                DGV1.Visible = False

        End Select
    End Sub

    '------>分頁結束<------







    '------><------




End Class