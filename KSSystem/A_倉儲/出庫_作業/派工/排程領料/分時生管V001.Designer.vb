<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 分時生管V001
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
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.Dt日期 = New System.Windows.Forms.DateTimePicker
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.T1派工明細 = New System.Windows.Forms.DataGridView
        Me.T1項目明細A = New System.Windows.Forms.DataGridView
        Me.La單號 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.T1項目明細B = New System.Windows.Forms.DataGridView
        Me.Bu同意 = New System.Windows.Forms.Button
        Me.La同意 = New System.Windows.Forms.Label
        Me.La發貨 = New System.Windows.Forms.Label
        CType(Me.T1派工明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1項目明細A, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1項目明細B, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(218, 2)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.Bu查詢.TabIndex = 91
        Me.Bu查詢.TabStop = False
        Me.Bu查詢.Text = "查詢製單"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        'Dt日期
        '
        Me.Dt日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Dt日期.Location = New System.Drawing.Point(63, 7)
        Me.Dt日期.Name = "Dt日期"
        Me.Dt日期.Size = New System.Drawing.Size(149, 27)
        Me.Dt日期.TabIndex = 89
        Me.Dt日期.TabStop = False
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(12, 9)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 90
        Me.dateDocDate_tb.Text = "日期："
        '
        'T1派工明細
        '
        Me.T1派工明細.AllowUserToAddRows = False
        Me.T1派工明細.AllowUserToDeleteRows = False
        Me.T1派工明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1派工明細.Location = New System.Drawing.Point(11, 40)
        Me.T1派工明細.MultiSelect = False
        Me.T1派工明細.Name = "T1派工明細"
        Me.T1派工明細.RowHeadersVisible = False
        Me.T1派工明細.RowTemplate.Height = 24
        Me.T1派工明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1派工明細.Size = New System.Drawing.Size(307, 592)
        Me.T1派工明細.TabIndex = 1071
        '
        'T1項目明細A
        '
        Me.T1項目明細A.AllowUserToAddRows = False
        Me.T1項目明細A.AllowUserToDeleteRows = False
        Me.T1項目明細A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1項目明細A.Location = New System.Drawing.Point(324, 40)
        Me.T1項目明細A.MultiSelect = False
        Me.T1項目明細A.Name = "T1項目明細A"
        Me.T1項目明細A.ReadOnly = True
        Me.T1項目明細A.RowHeadersVisible = False
        Me.T1項目明細A.RowTemplate.Height = 24
        Me.T1項目明細A.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1項目明細A.Size = New System.Drawing.Size(858, 294)
        Me.T1項目明細A.TabIndex = 1072
        '
        'La單號
        '
        Me.La單號.AutoSize = True
        Me.La單號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La單號.Location = New System.Drawing.Point(414, 14)
        Me.La單號.Name = "La單號"
        Me.La單號.Size = New System.Drawing.Size(88, 16)
        Me.La單號.TabIndex = 1074
        Me.La單號.Text = "分時領料單"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(321, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 16)
        Me.Label13.TabIndex = 1073
        Me.Label13.Text = "分時領料單："
        '
        'T1項目明細B
        '
        Me.T1項目明細B.AllowUserToAddRows = False
        Me.T1項目明細B.AllowUserToDeleteRows = False
        Me.T1項目明細B.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1項目明細B.Location = New System.Drawing.Point(324, 340)
        Me.T1項目明細B.MultiSelect = False
        Me.T1項目明細B.Name = "T1項目明細B"
        Me.T1項目明細B.ReadOnly = True
        Me.T1項目明細B.RowHeadersVisible = False
        Me.T1項目明細B.RowTemplate.Height = 24
        Me.T1項目明細B.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1項目明細B.Size = New System.Drawing.Size(858, 292)
        Me.T1項目明細B.TabIndex = 1075
        '
        'Bu同意
        '
        Me.Bu同意.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu同意.Location = New System.Drawing.Point(647, 2)
        Me.Bu同意.Name = "Bu同意"
        Me.Bu同意.Size = New System.Drawing.Size(100, 30)
        Me.Bu同意.TabIndex = 1076
        Me.Bu同意.TabStop = False
        Me.Bu同意.Text = "同意"
        Me.Bu同意.UseVisualStyleBackColor = True
        '
        'La同意
        '
        Me.La同意.AutoSize = True
        Me.La同意.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La同意.Location = New System.Drawing.Point(553, 14)
        Me.La同意.Name = "La同意"
        Me.La同意.Size = New System.Drawing.Size(56, 16)
        Me.La同意.TabIndex = 1077
        Me.La同意.Text = "同意否"
        '
        'La發貨
        '
        Me.La發貨.AutoSize = True
        Me.La發貨.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La發貨.Location = New System.Drawing.Point(553, -2)
        Me.La發貨.Name = "La發貨"
        Me.La發貨.Size = New System.Drawing.Size(72, 16)
        Me.La發貨.TabIndex = 1078
        Me.La發貨.Text = "發貨單號"
        Me.La發貨.Visible = False
        '
        '分時生管V001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 637)
        Me.Controls.Add(Me.La發貨)
        Me.Controls.Add(Me.La同意)
        Me.Controls.Add(Me.Bu同意)
        Me.Controls.Add(Me.T1項目明細B)
        Me.Controls.Add(Me.La單號)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.T1項目明細A)
        Me.Controls.Add(Me.T1派工明細)
        Me.Controls.Add(Me.Bu查詢)
        Me.Controls.Add(Me.Dt日期)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Name = "分時生管V001"
        Me.Text = "分時生管"
        CType(Me.T1派工明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1項目明細A, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1項目明細B, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents Dt日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents T1派工明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T1項目明細A As System.Windows.Forms.DataGridView
    Friend WithEvents La單號 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents T1項目明細B As System.Windows.Forms.DataGridView
    Friend WithEvents Bu同意 As System.Windows.Forms.Button
    Friend WithEvents La同意 As System.Windows.Forms.Label
    Friend WithEvents La發貨 As System.Windows.Forms.Label
End Class
