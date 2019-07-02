<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 查單庫位
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
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label17 = New System.Windows.Forms.Label
        Me.UM2s = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.品項數 = New System.Windows.Forms.Label
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(3, 49)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 23
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(879, 510)
        Me.DGV2.TabIndex = 96
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(0, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 122
        Me.Label17.Text = "查詢庫位："
        '
        'UM2s
        '
        Me.UM2s.BackColor = System.Drawing.SystemColors.Window
        Me.UM2s.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UM2s.Location = New System.Drawing.Point(84, 6)
        Me.UM2s.Name = "UM2s"
        Me.UM2s.ReadOnly = True
        Me.UM2s.Size = New System.Drawing.Size(122, 27)
        Me.UM2s.TabIndex = 123
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(212, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "品項數："
        '
        '品項數
        '
        Me.品項數.AutoSize = True
        Me.品項數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.品項數.Location = New System.Drawing.Point(280, 9)
        Me.品項數.Name = "品項數"
        Me.品項數.Size = New System.Drawing.Size(56, 16)
        Me.品項數.TabIndex = 125
        Me.品項數.Text = "品項數"
        '
        '查單庫位
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 562)
        Me.Controls.Add(Me.品項數)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UM2s)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.DGV2)
        Me.Name = "查單庫位"
        Me.Text = "查單庫位資料"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents UM2s As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 品項數 As System.Windows.Forms.Label
End Class
