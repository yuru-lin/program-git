Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class B_QueryPickingItem
    Dim DataAdapterDGV As SqlDataAdapter
    Dim ks1DataSetDGV As DataSet = New DataSet

    Private Sub B_QueryPickingItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV1.ContextMenuStrip = MainForm.ContextMenuStrip1
        DGV2.ContextMenuStrip = MainForm.ContextMenuStrip1
    End Sub

    Private Sub KG_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles KG.KeyPress

        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub SearchBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        If KG.Text = "" Then
            MsgBox("請輸入規格!")
            KG.Focus()
            Exit Sub
        End If

        If CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False Then
            MsgBox("請選擇雞種!")
            Exit Sub
        End If

        If CheckBox5.Checked = False And CheckBox6.Checked = False Then
            MsgBox("請選擇等級!")
            Exit Sub
        End If

        If DGV1.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT1").Clear()
        End If

        If DGV2.RowCount > 0 Then
            ks1DataSetDGV.Tables("DT2").Clear()
        End If
        SelectFromKS()
        SelectFromFS()
    End Sub

    Private Sub SelectFromKS()

        Dim Level As String = "and SubString(T0.ItemCode,6,1) in ("
        If CheckBox5.Checked Then
            Level += "'0','3','4','5','C','D'"
        End If

        If CheckBox6.Checked Then
            Level += "'7','8','E'"
        End If
        Level += ")"

        Level = Replace(Level, "''", "','")

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "Select T0.ItemCode as '存編', T0.ItemName as '品名', dbo.getroundn(T0.OnHand,0) as '存貨量' From [KaiShing].[dbo].[OITM] T0 Where (LEFT(T0.ItemCode ,2) in ('25')) and SubString(T0.ItemCode,3,1) in ('1','2') and SubString(T0.ItemCode,4,1) in ('1','2','3') and ( "

        If CheckBox1.Checked Then
            sql += "  SubString(T0.ItemCode,5,1) = '1' "
        End If

        If CheckBox2.Checked Then
            If CheckBox1.Checked Then
                sql += "  OR "
            End If
            sql += "  SubString(T0.ItemCode,5,1) = '4' "
        End If

        If CheckBox3.Checked Then
            If CheckBox1.Checked Or CheckBox2.Checked Then
                sql += "  OR "
            End If
            sql += "  SubString(T0.ItemCode,5,1) = '2' "
        End If

        If CheckBox4.Checked Then
            If CheckBox1.Checked Or CheckBox2.Checked Or CheckBox3.Checked Then
                sql += "  OR "
            End If
            sql += "  SubString(T0.ItemCode,5,1) = 'K' "
        End If

        sql += " ) and SubString(T0.ItemCode,9,3) in ('000','003','037') and SubString(T0.ItemCode,12,2) = '00'  and SubString(T0.ItemCode,7,2) =  '" & KG.Text & "' "


        If CheckBox5.Checked Or CheckBox6.Checked Then
            sql += Level
        End If

        sql += " Order by T0.itemcode"
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT1")

        DGV1.DataSource = ks1DataSetDGV.Tables("DT1")
        DGV1.AutoResizeColumns()

    End Sub

    Private Sub SelectFromFS()

        Dim Level As String = "and SubString(T0.ItemCode,6,1) in ("
        If CheckBox5.Checked Then
            Level += "'0','3','4','5','C','D'"
        End If

        If CheckBox6.Checked Then
            Level += "'7','8','E'"
        End If
        Level += ")"

        Level = Replace(Level, "''", "','")

        Dim sql As String
        Dim DBConn As SqlConnection = Login.DBConn
        Dim SQLCmd As SqlCommand = New SqlCommand

        sql = "Select T0.ItemCode as '存編', T0.ItemName as '品名', dbo.getroundn(T0.OnHand,0) as '存貨量' From [kFS_00].[dbo].[OITM] T0 Where (LEFT(T0.ItemCode ,2) in ('21')) and SubString(T0.ItemCode,3,1) in ('1','2') and SubString(T0.ItemCode,4,1) in ('1','2','3') and ( "

        If CheckBox1.Checked Then
            sql += "  SubString(T0.ItemCode,5,1) = '1' "
        End If

        If CheckBox2.Checked Then
            If CheckBox1.Checked Then
                sql += "  OR "
            End If
            sql += "  SubString(T0.ItemCode,5,1) = '4' "
        End If

        If CheckBox3.Checked Then
            If CheckBox1.Checked Or CheckBox2.Checked Then
                sql += "  OR "
            End If
            sql += "  SubString(T0.ItemCode,5,1) = '2' "
        End If

        If CheckBox4.Checked Then
            If CheckBox1.Checked Or CheckBox2.Checked Or CheckBox3.Checked Then
                sql += "  OR "
            End If
            sql += "  SubString(T0.ItemCode,5,1) = 'K' "
        End If

        sql += " ) and SubString(T0.ItemCode,9,3) in ('000','003','037') and SubString(T0.ItemCode,12,2) = '00'  and SubString(T0.ItemCode,7,2) =  '" & KG.Text & "' "


        If CheckBox5.Checked Or CheckBox6.Checked Then
            sql += Level
        End If

        sql += " Order by T0.itemcode"
        SQLCmd.Connection = DBConn
        SQLCmd.CommandText = sql

        DataAdapterDGV = New SqlDataAdapter(sql, DBConn)
        DataAdapterDGV.Fill(ks1DataSetDGV, "DT2")

        DGV2.DataSource = ks1DataSetDGV.Tables("DT2")
        DGV2.AutoResizeColumns()
    End Sub
End Class