Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class A_Scheduling

    Private Sub A_Scheduling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DatePicker.Text = Now()   '今天日期


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'RB1 = 修改排程, RB2 = 新增排程
        If RB1.Checked = True Then

        Else
            判斷排程日期()
        End If
    End Sub

    Private Sub 判斷排程日期()

        'Label2.Text = ""
        'Label3.Text = ""

        Dim a01 As Date     '今天日期
        Dim a02 As Integer  '判定星期幾

        a01 = DatePicker.Text
        a02 = Weekday(a01)

        'Label3.Text = a02 - 1
        If a02 < 5 Then
            'DatePicker.Text = DateAdd(DateInterval.Day, a02 * -1, a01)
            LDate1.Text = DateAdd(DateInterval.Day, a02 * -1, a01)
            LDate2.Text = DateAdd(DateInterval.Day, a02 * -1 + 6, a01)
        Else
            'DatePicker.Text = DateAdd(DateInterval.Day, 7 - a02, a01)
            LDate1.Text = DateAdd(DateInterval.Day, 7 - a02, a01)
            LDate2.Text = DateAdd(DateInterval.Day, 7 - a02 + 6, a01)
        End If
        'DateTimePicker1.Value.Date

    End Sub

    Private Sub RB1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB1.CheckedChanged, RB2.CheckedChanged

        If RB1.Checked = True Then
            Label1.Visible = False
            LDate1.Visible = False
        Else
        End If


    End Sub
End Class