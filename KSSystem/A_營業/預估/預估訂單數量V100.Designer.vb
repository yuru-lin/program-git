<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 預估訂單數量V100
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cb客戶 = New System.Windows.Forms.ComboBox
        Me.DGV日期 = New System.Windows.Forms.DataGridView
        Me.預估數量 = New System.Windows.Forms.DataGridView
        Me.Bu選擇 = New System.Windows.Forms.Button
        Me.Bu存檔 = New System.Windows.Forms.Button
        Me.Bu放棄 = New System.Windows.Forms.Button
        CType(Me.DGV日期, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.預估數量, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 1015
        Me.Label2.Text = "客戶名稱："
        '
        'Cb客戶
        '
        Me.Cb客戶.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb客戶.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb客戶.FormattingEnabled = True
        Me.Cb客戶.Items.AddRange(New Object() {"全聯", "好市多"})
        Me.Cb客戶.Location = New System.Drawing.Point(101, 4)
        Me.Cb客戶.Name = "Cb客戶"
        Me.Cb客戶.Size = New System.Drawing.Size(153, 27)
        Me.Cb客戶.TabIndex = 1024
        '
        'DGV日期
        '
        Me.DGV日期.AllowUserToAddRows = False
        Me.DGV日期.AllowUserToDeleteRows = False
        Me.DGV日期.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV日期.Location = New System.Drawing.Point(12, 37)
        Me.DGV日期.MultiSelect = False
        Me.DGV日期.Name = "DGV日期"
        Me.DGV日期.ReadOnly = True
        Me.DGV日期.RowHeadersVisible = False
        Me.DGV日期.RowTemplate.Height = 24
        Me.DGV日期.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV日期.Size = New System.Drawing.Size(242, 588)
        Me.DGV日期.TabIndex = 1025
        '
        '預估數量
        '
        Me.預估數量.AllowUserToAddRows = False
        Me.預估數量.AllowUserToDeleteRows = False
        Me.預估數量.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.預估數量.Location = New System.Drawing.Point(260, 37)
        Me.預估數量.MultiSelect = False
        Me.預估數量.Name = "預估數量"
        Me.預估數量.RowHeadersVisible = False
        Me.預估數量.RowTemplate.Height = 24
        Me.預估數量.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.預估數量.Size = New System.Drawing.Size(912, 490)
        Me.預估數量.TabIndex = 1026
        '
        'Bu選擇
        '
        Me.Bu選擇.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu選擇.Location = New System.Drawing.Point(260, 4)
        Me.Bu選擇.Name = "Bu選擇"
        Me.Bu選擇.Size = New System.Drawing.Size(100, 27)
        Me.Bu選擇.TabIndex = 1049
        Me.Bu選擇.Text = "選擇客戶"
        Me.Bu選擇.UseVisualStyleBackColor = True
        '
        'Bu存檔
        '
        Me.Bu存檔.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu存檔.Location = New System.Drawing.Point(930, 4)
        Me.Bu存檔.Name = "Bu存檔"
        Me.Bu存檔.Size = New System.Drawing.Size(100, 27)
        Me.Bu存檔.TabIndex = 1050
        Me.Bu存檔.Text = "存檔"
        Me.Bu存檔.UseVisualStyleBackColor = True
        '
        'Bu放棄
        '
        Me.Bu放棄.BackColor = System.Drawing.Color.Red
        Me.Bu放棄.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu放棄.Location = New System.Drawing.Point(1097, 4)
        Me.Bu放棄.Name = "Bu放棄"
        Me.Bu放棄.Size = New System.Drawing.Size(75, 27)
        Me.Bu放棄.TabIndex = 1051
        Me.Bu放棄.Text = "放棄"
        Me.Bu放棄.UseVisualStyleBackColor = False
        '
        '預估訂單數量V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 637)
        Me.Controls.Add(Me.Bu放棄)
        Me.Controls.Add(Me.Bu存檔)
        Me.Controls.Add(Me.Bu選擇)
        Me.Controls.Add(Me.預估數量)
        Me.Controls.Add(Me.DGV日期)
        Me.Controls.Add(Me.Cb客戶)
        Me.Controls.Add(Me.Label2)
        Me.Name = "預估訂單數量V100"
        Me.Text = "預估訂單數量"
        CType(Me.DGV日期, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.預估數量, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cb客戶 As System.Windows.Forms.ComboBox
    Friend WithEvents DGV日期 As System.Windows.Forms.DataGridView
    Friend WithEvents 預估數量 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu選擇 As System.Windows.Forms.Button
    Friend WithEvents Bu存檔 As System.Windows.Forms.Button
    Friend WithEvents Bu放棄 As System.Windows.Forms.Button
End Class
