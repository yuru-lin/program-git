Public Class Loading
    Dim afterFormload As Boolean = False    '記錄是否在FormLoad事件中

    Private Sub Loading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        afterFormload = True
    End Sub

    
End Class