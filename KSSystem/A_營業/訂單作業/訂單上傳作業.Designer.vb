<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 訂單上傳作業
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
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Bu讀取上傳 = New System.Windows.Forms.Button
        Me.客戶 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 85)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(915, 503)
        Me.DGV1.TabIndex = 1
        '
        'Bu讀取上傳
        '
        Me.Bu讀取上傳.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu讀取上傳.Location = New System.Drawing.Point(812, 27)
        Me.Bu讀取上傳.Name = "Bu讀取上傳"
        Me.Bu讀取上傳.Size = New System.Drawing.Size(115, 38)
        Me.Bu讀取上傳.TabIndex = 2
        Me.Bu讀取上傳.Text = "Excel讀取上傳"
        Me.Bu讀取上傳.UseVisualStyleBackColor = True
        '
        '客戶
        '
        Me.客戶.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.客戶.FormattingEnabled = True
        Me.客戶.Items.AddRange(New Object() {"全聯", "好市多", "嘉珍香"})
        Me.客戶.Location = New System.Drawing.Point(662, 35)
        Me.客戶.Name = "客戶"
        Me.客戶.Size = New System.Drawing.Size(120, 24)
        Me.客戶.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(591, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "客戶："
        Me.Label1.Visible = False
        '
        '訂單上傳作業
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 600)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.客戶)
        Me.Controls.Add(Me.Bu讀取上傳)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "訂單上傳作業"
        Me.Text = "訂單上傳作業"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu讀取上傳 As System.Windows.Forms.Button
    Friend WithEvents 客戶 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
