<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 訂單自動比對V100
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
        Me.過帳日期 = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.電腦時間 = New System.Windows.Forms.Label
        Me.提單 = New System.Windows.Forms.DataGridView
        Me.即時時間 = New System.Windows.Forms.Timer(Me.components)
        Me.查詢 = New System.Windows.Forms.Button
        Me.異常 = New System.Windows.Forms.DataGridView
        Me.異常2 = New System.Windows.Forms.DataGridView
        CType(Me.提單, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.異常, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.異常2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '過帳日期
        '
        Me.過帳日期.CustomFormat = "yyyy-MM-dd"
        Me.過帳日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.過帳日期.Location = New System.Drawing.Point(369, 2)
        Me.過帳日期.Name = "過帳日期"
        Me.過帳日期.Size = New System.Drawing.Size(130, 27)
        Me.過帳日期.TabIndex = 188
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "日期："
        Me.Label7.Visible = False
        '
        '電腦時間
        '
        Me.電腦時間.AutoSize = True
        Me.電腦時間.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.電腦時間.ForeColor = System.Drawing.Color.Red
        Me.電腦時間.Location = New System.Drawing.Point(665, 6)
        Me.電腦時間.Name = "電腦時間"
        Me.電腦時間.Size = New System.Drawing.Size(89, 19)
        Me.電腦時間.TabIndex = 187
        Me.電腦時間.Text = "電腦時間"
        '
        '提單
        '
        Me.提單.AllowUserToAddRows = False
        Me.提單.AllowUserToDeleteRows = False
        Me.提單.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.提單.Location = New System.Drawing.Point(12, 35)
        Me.提單.Name = "提單"
        Me.提單.ReadOnly = True
        Me.提單.RowHeadersVisible = False
        Me.提單.RowTemplate.Height = 24
        Me.提單.Size = New System.Drawing.Size(910, 402)
        Me.提單.TabIndex = 190
        '
        '即時時間
        '
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(12, 4)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(75, 26)
        Me.查詢.TabIndex = 191
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        '異常
        '
        Me.異常.AllowUserToAddRows = False
        Me.異常.AllowUserToDeleteRows = False
        Me.異常.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.異常.Location = New System.Drawing.Point(12, 443)
        Me.異常.Name = "異常"
        Me.異常.ReadOnly = True
        Me.異常.RowTemplate.Height = 24
        Me.異常.Size = New System.Drawing.Size(668, 170)
        Me.異常.TabIndex = 192
        '
        '異常2
        '
        Me.異常2.AllowUserToAddRows = False
        Me.異常2.AllowUserToDeleteRows = False
        Me.異常2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.異常2.Location = New System.Drawing.Point(686, 443)
        Me.異常2.Name = "異常2"
        Me.異常2.ReadOnly = True
        Me.異常2.RowTemplate.Height = 24
        Me.異常2.Size = New System.Drawing.Size(236, 170)
        Me.異常2.TabIndex = 193
        '
        '訂單自動比對V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 617)
        Me.Controls.Add(Me.異常2)
        Me.Controls.Add(Me.異常)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.提單)
        Me.Controls.Add(Me.過帳日期)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.電腦時間)
        Me.MaximumSize = New System.Drawing.Size(950, 660)
        Me.MinimumSize = New System.Drawing.Size(950, 660)
        Me.Name = "訂單自動比對V100"
        Me.Text = "訂單自動比對V100"
        CType(Me.提單, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.異常, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.異常2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 過帳日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 電腦時間 As System.Windows.Forms.Label
    Friend WithEvents 提單 As System.Windows.Forms.DataGridView
    Friend WithEvents 即時時間 As System.Windows.Forms.Timer
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents 異常 As System.Windows.Forms.DataGridView
    Friend WithEvents 異常2 As System.Windows.Forms.DataGridView
End Class
