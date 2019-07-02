Public Class MainForm

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.IsMdiContainer = True

        Login.MdiParent = Me
        Login.Show()

    End Sub

    Private Sub MainFormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If MessageBox.Show("確定要離開系統?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            Closeing()
        End If

    End Sub

    Private Sub Closeing()
        If Login.oCompany.Connected = True Then
            Login.oCompany.Disconnect()
            Login.oCompany = Nothing            
        End If
        Login.DBConn.Close()
        Login.DBConn.Dispose()
        Login.DBConn = Nothing
        End
    End Sub

    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        AboutForm.MdiParent = Me
        AboutForm.Show()

    End Sub
  
    Private Sub 主功能表MToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 主功能表MToolStripMenuItem.Click
        If MainMenuList.Visible = True Then
            Exit Sub
        Else
            MainMenuList.MdiParent = Me
            MainMenuList.Show()
        End If
    End Sub

    Private Sub 結束XToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 結束XToolStripMenuItem.Click
        If MessageBox.Show("確定要離開系統?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        Else
            Closeing()
        End If
    End Sub

    Private Sub TestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 匯出ExcelToolStripMenuItem.Click
        Dim DGView As DataGridView = CType(ContextMenuStrip1.SourceControl, DataGridView)
        DataToExcel(DGView, "")
    End Sub

    Private Sub 複製ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 複製ToolStripMenuItem.Click
        Dim DGView As DataGridView = CType(ContextMenuStrip1.SourceControl, DataGridView)
        CopyDGV(DGView)
    End Sub


End Class
