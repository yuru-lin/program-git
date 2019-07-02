<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_BatchChangeSpace
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
        Me.Button4 = New System.Windows.Forms.Button
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.rbt2 = New System.Windows.Forms.RadioButton
        Me.rbt1 = New System.Windows.Forms.RadioButton
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.NewLoc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.OrgLoc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.locView = New System.Windows.Forms.DataGridView
        Me.DGV1 = New System.Windows.Forms.DataGridView
        CType(Me.locView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(366, 341)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 112
        Me.Button4.Text = "匯出Excel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(8, 468)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(533, 23)
        Me.PBar1.TabIndex = 111
        '
        'rbt2
        '
        Me.rbt2.AutoSize = True
        Me.rbt2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.rbt2.Location = New System.Drawing.Point(135, 350)
        Me.rbt2.Name = "rbt2"
        Me.rbt2.Size = New System.Drawing.Size(58, 20)
        Me.rbt2.TabIndex = 109
        Me.rbt2.Text = "代工"
        Me.rbt2.UseVisualStyleBackColor = True
        '
        'rbt1
        '
        Me.rbt1.AutoSize = True
        Me.rbt1.Checked = True
        Me.rbt1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.rbt1.Location = New System.Drawing.Point(20, 350)
        Me.rbt1.Name = "rbt1"
        Me.rbt1.Size = New System.Drawing.Size(58, 20)
        Me.rbt1.TabIndex = 108
        Me.rbt1.TabStop = True
        Me.rbt1.Text = "電宰"
        Me.rbt1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(201, 418)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 35)
        Me.Button2.TabIndex = 107
        Me.Button2.Text = "變更"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(201, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 35)
        Me.Button1.TabIndex = 106
        Me.Button1.Text = "讀取"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NewLoc
        '
        Me.NewLoc.Enabled = False
        Me.NewLoc.Location = New System.Drawing.Point(95, 427)
        Me.NewLoc.Name = "NewLoc"
        Me.NewLoc.Size = New System.Drawing.Size(100, 22)
        Me.NewLoc.TabIndex = 105
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(17, 431)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "目的儲位"
        '
        'OrgLoc
        '
        Me.OrgLoc.Location = New System.Drawing.Point(95, 381)
        Me.OrgLoc.Name = "OrgLoc"
        Me.OrgLoc.Size = New System.Drawing.Size(100, 22)
        Me.OrgLoc.TabIndex = 103
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(524, 338)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "項"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(496, 338)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(458, 338)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "共"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(17, 385)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "原先儲位"
        '
        'locView
        '
        Me.locView.AllowUserToAddRows = False
        Me.locView.AllowUserToDeleteRows = False
        Me.locView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locView.Location = New System.Drawing.Point(12, 12)
        Me.locView.Name = "locView"
        Me.locView.ReadOnly = True
        Me.locView.RowTemplate.Height = 24
        Me.locView.Size = New System.Drawing.Size(524, 323)
        Me.locView.TabIndex = 98
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(304, 370)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(232, 92)
        Me.DGV1.TabIndex = 113
        '
        'C_BatchChangeSpace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 503)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.rbt2)
        Me.Controls.Add(Me.rbt1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NewLoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.OrgLoc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.locView)
        Me.Name = "C_BatchChangeSpace"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "整批儲位變更"
        CType(Me.locView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents rbt2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NewLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OrgLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents locView As System.Windows.Forms.DataGridView
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
End Class
