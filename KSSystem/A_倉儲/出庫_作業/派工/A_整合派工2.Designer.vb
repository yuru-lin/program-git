<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_草稿派工作業
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
        Me.回上頁 = New System.Windows.Forms.Button
        Me.DGV21 = New System.Windows.Forms.DataGridView
        Me.客戶 = New System.Windows.Forms.Label
        Me.備註 = New System.Windows.Forms.Label
        Me.DGV22 = New System.Windows.Forms.DataGridView
        Me.DTP2 = New System.Windows.Forms.DateTimePicker
        Me.DTP1 = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.草稿 = New System.Windows.Forms.Label
        Me.提單 = New System.Windows.Forms.Label
        Me.DGV23 = New System.Windows.Forms.DataGridView
        Me.存編 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.品名 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.儲位 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.數量 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.派入 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DGV21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV23, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '回上頁
        '
        Me.回上頁.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.回上頁.Location = New System.Drawing.Point(885, -1)
        Me.回上頁.Name = "回上頁"
        Me.回上頁.Size = New System.Drawing.Size(75, 23)
        Me.回上頁.TabIndex = 194
        Me.回上頁.Text = "回上頁"
        Me.回上頁.UseVisualStyleBackColor = True
        '
        'DGV21
        '
        Me.DGV21.AllowUserToAddRows = False
        Me.DGV21.AllowUserToDeleteRows = False
        Me.DGV21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV21.Location = New System.Drawing.Point(2, 68)
        Me.DGV21.MultiSelect = False
        Me.DGV21.Name = "DGV21"
        Me.DGV21.ReadOnly = True
        Me.DGV21.RowHeadersWidth = 23
        Me.DGV21.RowTemplate.Height = 24
        Me.DGV21.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV21.Size = New System.Drawing.Size(602, 250)
        Me.DGV21.TabIndex = 195
        '
        '客戶
        '
        Me.客戶.AutoSize = True
        Me.客戶.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.客戶.Location = New System.Drawing.Point(3, 5)
        Me.客戶.Name = "客戶"
        Me.客戶.Size = New System.Drawing.Size(40, 16)
        Me.客戶.TabIndex = 196
        Me.客戶.Text = "客戶"
        '
        '備註
        '
        Me.備註.AutoEllipsis = True
        Me.備註.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.備註.Location = New System.Drawing.Point(3, 25)
        Me.備註.Name = "備註"
        Me.備註.Size = New System.Drawing.Size(954, 40)
        Me.備註.TabIndex = 197
        Me.備註.Text = "備註"
        '
        'DGV22
        '
        Me.DGV22.AllowUserToAddRows = False
        Me.DGV22.AllowUserToDeleteRows = False
        Me.DGV22.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV22.Location = New System.Drawing.Point(2, 408)
        Me.DGV22.Name = "DGV22"
        Me.DGV22.RowHeadersWidth = 23
        Me.DGV22.RowTemplate.Height = 24
        Me.DGV22.Size = New System.Drawing.Size(958, 250)
        Me.DGV22.TabIndex = 198
        '
        'DTP2
        '
        Me.DTP2.Location = New System.Drawing.Point(55, 345)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(134, 22)
        Me.DTP2.TabIndex = 200
        '
        'DTP1
        '
        Me.DTP1.Location = New System.Drawing.Point(55, 322)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(134, 22)
        Me.DTP1.TabIndex = 199
        Me.DTP1.Value = New Date(2008, 1, 1, 0, 0, 0, 0)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(4, 348)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 202
        Me.Label16.Text = "結束："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(4, 325)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 201
        Me.Label15.Text = "開始："
        '
        '草稿
        '
        Me.草稿.AutoSize = True
        Me.草稿.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.草稿.Location = New System.Drawing.Point(375, 5)
        Me.草稿.Name = "草稿"
        Me.草稿.Size = New System.Drawing.Size(40, 16)
        Me.草稿.TabIndex = 203
        Me.草稿.Text = "草稿"
        '
        '提單
        '
        Me.提單.AutoSize = True
        Me.提單.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.提單.Location = New System.Drawing.Point(502, 5)
        Me.提單.Name = "提單"
        Me.提單.Size = New System.Drawing.Size(40, 16)
        Me.提單.TabIndex = 204
        Me.提單.Text = "提單"
        '
        'DGV23
        '
        Me.DGV23.AllowUserToAddRows = False
        Me.DGV23.AllowUserToDeleteRows = False
        Me.DGV23.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV23.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.存編, Me.品名, Me.儲位, Me.數量})
        Me.DGV23.Location = New System.Drawing.Point(611, 69)
        Me.DGV23.Name = "DGV23"
        Me.DGV23.ReadOnly = True
        Me.DGV23.RowHeadersWidth = 25
        Me.DGV23.RowTemplate.Height = 24
        Me.DGV23.Size = New System.Drawing.Size(349, 333)
        Me.DGV23.TabIndex = 205
        '
        '存編
        '
        Me.存編.Frozen = True
        Me.存編.HeaderText = "存編"
        Me.存編.Name = "存編"
        Me.存編.ReadOnly = True
        '
        '品名
        '
        Me.品名.Frozen = True
        Me.品名.HeaderText = "品名"
        Me.品名.Name = "品名"
        Me.品名.ReadOnly = True
        '
        '儲位
        '
        Me.儲位.Frozen = True
        Me.儲位.HeaderText = "儲位"
        Me.儲位.Name = "儲位"
        Me.儲位.ReadOnly = True
        '
        '數量
        '
        Me.數量.Frozen = True
        Me.數量.HeaderText = "數量"
        Me.數量.Name = "數量"
        Me.數量.ReadOnly = True
        '
        '派入
        '
        Me.派入.Location = New System.Drawing.Point(529, 379)
        Me.派入.Name = "派入"
        Me.派入.Size = New System.Drawing.Size(75, 23)
        Me.派入.TabIndex = 206
        Me.派入.Text = "派入"
        Me.派入.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(804, -1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 207
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'A_草稿派工作業
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.派入)
        Me.Controls.Add(Me.DGV23)
        Me.Controls.Add(Me.提單)
        Me.Controls.Add(Me.草稿)
        Me.Controls.Add(Me.客戶)
        Me.Controls.Add(Me.DGV22)
        Me.Controls.Add(Me.DTP2)
        Me.Controls.Add(Me.備註)
        Me.Controls.Add(Me.DTP1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DGV21)
        Me.Controls.Add(Me.回上頁)
        Me.Name = "A_草稿派工作業"
        Me.Text = "草稿派工作業"
        CType(Me.DGV21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV23, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 回上頁 As System.Windows.Forms.Button
    Friend WithEvents DGV21 As System.Windows.Forms.DataGridView
    Friend WithEvents 客戶 As System.Windows.Forms.Label
    Friend WithEvents 備註 As System.Windows.Forms.Label
    Friend WithEvents DGV22 As System.Windows.Forms.DataGridView
    Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents 草稿 As System.Windows.Forms.Label
    Friend WithEvents 提單 As System.Windows.Forms.Label
    Friend WithEvents DGV23 As System.Windows.Forms.DataGridView
    Friend WithEvents 派入 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents 存編 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 品名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 儲位 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 數量 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
