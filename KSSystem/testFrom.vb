


Public Class testFrom


    Private Sub testFrom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MsgBox(PrintDialog1.PrinterSettings.PrinterName)
        End If
    End Sub

  
End Class