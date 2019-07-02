<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QuerySRNDetail
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
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.Btn2 = New System.Windows.Forms.Button
        Me.Btn0 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.lb2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lb0 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView0 = New System.Windows.Forms.DataGridView
        Me.locView = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.locView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(18, 480)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(567, 23)
        Me.PBar1.TabIndex = 133
        '
        'Btn2
        '
        Me.Btn2.Enabled = False
        Me.Btn2.Location = New System.Drawing.Point(606, 417)
        Me.Btn2.Name = "Btn2"
        Me.Btn2.Size = New System.Drawing.Size(87, 35)
        Me.Btn2.TabIndex = 130
        Me.Btn2.Text = "條碼匯出"
        Me.Btn2.UseVisualStyleBackColor = True
        '
        'Btn0
        '
        Me.Btn0.Enabled = False
        Me.Btn0.Location = New System.Drawing.Point(501, 417)
        Me.Btn0.Name = "Btn0"
        Me.Btn0.Size = New System.Drawing.Size(87, 35)
        Me.Btn0.TabIndex = 129
        Me.Btn0.Text = "條碼匯出"
        Me.Btn0.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(594, 468)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 35)
        Me.Button1.TabIndex = 128
        Me.Button1.Text = "讀取Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(675, 402)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "項"
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.Location = New System.Drawing.Point(647, 402)
        Me.lb2.Name = "lb2"
        Me.lb2.Size = New System.Drawing.Size(11, 12)
        Me.lb2.TabIndex = 126
        Me.lb2.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(604, 402)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 12)
        Me.Label13.TabIndex = 125
        Me.Label13.Text = "共"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(568, 402)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "項"
        '
        'lb0
        '
        Me.lb0.AutoSize = True
        Me.lb0.Location = New System.Drawing.Point(540, 402)
        Me.lb0.Name = "lb0"
        Me.lb0.Size = New System.Drawing.Size(11, 12)
        Me.lb0.TabIndex = 123
        Me.lb0.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(502, 402)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "共"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(15, 455)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(235, 16)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Excel欄位分別為：第一欄：條碼"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(604, 28)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(87, 367)
        Me.DataGridView2.TabIndex = 120
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(601, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "錯誤條碼"
        '
        'DataGridView0
        '
        Me.DataGridView0.AllowUserToAddRows = False
        Me.DataGridView0.AllowUserToDeleteRows = False
        Me.DataGridView0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView0.Location = New System.Drawing.Point(6, 28)
        Me.DataGridView0.Name = "DataGridView0"
        Me.DataGridView0.ReadOnly = True
        Me.DataGridView0.RowHeadersVisible = False
        Me.DataGridView0.RowHeadersWidth = 20
        Me.DataGridView0.RowTemplate.Height = 24
        Me.DataGridView0.Size = New System.Drawing.Size(592, 367)
        Me.DataGridView0.TabIndex = 118
        '
        'locView
        '
        Me.locView.AllowUserToAddRows = False
        Me.locView.AllowUserToDeleteRows = False
        Me.locView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locView.Location = New System.Drawing.Point(26, 7)
        Me.locView.Name = "locView"
        Me.locView.ReadOnly = True
        Me.locView.RowTemplate.Height = 24
        Me.locView.Size = New System.Drawing.Size(119, 89)
        Me.locView.TabIndex = 132
        Me.locView.Visible = False
        '
        'C_QuerySRNDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 512)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Btn2)
        Me.Controls.Add(Me.Btn0)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lb2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb0)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView0)
        Me.Controls.Add(Me.locView)
        Me.Name = "C_QuerySRNDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "依條碼查產品明細資料"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.locView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Btn2 As System.Windows.Forms.Button
    Friend WithEvents Btn0 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lb2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lb0 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView0 As System.Windows.Forms.DataGridView
    Friend WithEvents locView As System.Windows.Forms.DataGridView
End Class
