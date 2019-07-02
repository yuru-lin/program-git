<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QueryFinishedORDR
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(B_QueryFinishedORDR))
        Me.DGVFinished = New System.Windows.Forms.DataGridView
        Me.UpdateBtn = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PopupNotifier1 = New PopupNotifier
        CType(Me.DGVFinished, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVFinished
        '
        Me.DGVFinished.AllowUserToAddRows = False
        Me.DGVFinished.AllowUserToDeleteRows = False
        Me.DGVFinished.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVFinished.Location = New System.Drawing.Point(12, 12)
        Me.DGVFinished.Name = "DGVFinished"
        Me.DGVFinished.ReadOnly = True
        Me.DGVFinished.RowHeadersVisible = False
        Me.DGVFinished.RowTemplate.Height = 24
        Me.DGVFinished.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVFinished.Size = New System.Drawing.Size(460, 418)
        Me.DGVFinished.TabIndex = 46
        '
        'UpdateBtn
        '
        Me.UpdateBtn.Location = New System.Drawing.Point(397, 436)
        Me.UpdateBtn.Name = "UpdateBtn"
        Me.UpdateBtn.Size = New System.Drawing.Size(75, 23)
        Me.UpdateBtn.TabIndex = 49
        Me.UpdateBtn.Text = "手動更新"
        Me.UpdateBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 441)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "自動化更新時間還有："
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PopupNotifier1
        '
        Me.PopupNotifier1.BodyColor = System.Drawing.Color.SteelBlue
        Me.PopupNotifier1.BorderColor = System.Drawing.Color.Navy
        Me.PopupNotifier1.ButtonHoverColor = System.Drawing.Color.Orange
        Me.PopupNotifier1.ContentColor = System.Drawing.Color.Red
        Me.PopupNotifier1.ContentFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupNotifier1.ContentText = ""
        Me.PopupNotifier1.GradientPower = 1000
        Me.PopupNotifier1.HeaderColor = System.Drawing.Color.Navy
        Me.PopupNotifier1.Image = CType(resources.GetObject("PopupNotifier1.Image"), System.Drawing.Image)
        Me.PopupNotifier1.ImagePosition = New System.Drawing.Point(12, 21)
        Me.PopupNotifier1.ImageSize = New System.Drawing.Size(48, 48)
        Me.PopupNotifier1.LinkHoverColor = System.Drawing.Color.Black
        Me.PopupNotifier1.OptionsMenu = Nothing
        Me.PopupNotifier1.ShowDelay = 1000
        Me.PopupNotifier1.Size = New System.Drawing.Size(400, 100)
        Me.PopupNotifier1.TextPadding = New System.Windows.Forms.Padding(5)
        Me.PopupNotifier1.TitleColor = System.Drawing.Color.White
        Me.PopupNotifier1.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupNotifier1.TitleText = ""
        '
        'B_QueryFinishedORDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 462)
        Me.Controls.Add(Me.UpdateBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGVFinished)
        Me.Name = "B_QueryFinishedORDR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "已完成單"
        CType(Me.DGVFinished, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGVFinished As System.Windows.Forms.DataGridView
    Friend WithEvents UpdateBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PopupNotifier1 As PopupNotifier
End Class
