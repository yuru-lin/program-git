Imports System
Imports System.IO

Public Class AboutForm


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbVersion.Text = Login.lbVersion1.Text
        ReadLog()
    End Sub

    Private Sub ReadLog()

        Dim sr As StreamReader = New StreamReader(Application.StartupPath & "\Log.txt", System.Text.Encoding.Default)
        tbxLog.Text = sr.ReadToEnd()
    End Sub

    Private Sub lbVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbVersion.Click
        If MessageBox.Show("確定要更新版本?" & vbCrLf & "更新完後須重新開啟程式。", "更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            If AutoUpdate.UpdateFiles() Then

                If MessageBox.Show("版本已更新，確認後請重新開啟程式。", "版本已更新", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                    Login.Closeing()
                End If
            Else
                MsgBox("沒有新版本")
                Exit Sub
            End If
        End If
    End Sub
End Class