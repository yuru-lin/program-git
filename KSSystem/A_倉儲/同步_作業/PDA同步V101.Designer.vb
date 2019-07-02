<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA同步V101
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.同步至入庫區 = New System.Windows.Forms.Button
        Me.讀取待轉區資料 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.上頁 = New System.Windows.Forms.Button
        Me.清除已入庫條碼 = New System.Windows.Forms.Button
        Me.待轉數量 = New System.Windows.Forms.Label
        Me.已入庫數 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.作廢條碼 = New System.Windows.Forms.Label
        Me.轉Excel = New System.Windows.Forms.Button
        Me.CB作業別 = New System.Windows.Forms.ComboBox
        Me.Bu更換 = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(660, 353)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 19)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "儲位數量"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(-3, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "入庫項目"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(275, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 24)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "條碼入出庫清點同步作業"
        '
        '同步至入庫區
        '
        Me.同步至入庫區.Enabled = False
        Me.同步至入庫區.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.同步至入庫區.Location = New System.Drawing.Point(660, 292)
        Me.同步至入庫區.Name = "同步至入庫區"
        Me.同步至入庫區.Size = New System.Drawing.Size(212, 52)
        Me.同步至入庫區.TabIndex = 43
        Me.同步至入庫區.Text = "同步至資料庫"
        Me.同步至入庫區.UseVisualStyleBackColor = True
        '
        '讀取待轉區資料
        '
        Me.讀取待轉區資料.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.讀取待轉區資料.Location = New System.Drawing.Point(660, 121)
        Me.讀取待轉區資料.Name = "讀取待轉區資料"
        Me.讀取待轉區資料.Size = New System.Drawing.Size(212, 52)
        Me.讀取待轉區資料.TabIndex = 62
        Me.讀取待轉區資料.Text = "讀取待轉區資料"
        Me.讀取待轉區資料.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(1, 81)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersWidth = 20
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(653, 488)
        Me.DGV1.TabIndex = 190
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(660, 375)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 20
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(212, 150)
        Me.DGV2.TabIndex = 191
        '
        '上頁
        '
        Me.上頁.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.上頁.Location = New System.Drawing.Point(777, 531)
        Me.上頁.Name = "上頁"
        Me.上頁.Size = New System.Drawing.Size(95, 37)
        Me.上頁.TabIndex = 193
        Me.上頁.Text = "上頁"
        Me.上頁.UseVisualStyleBackColor = True
        '
        '清除已入庫條碼
        '
        Me.清除已入庫條碼.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.清除已入庫條碼.Location = New System.Drawing.Point(660, 179)
        Me.清除已入庫條碼.Name = "清除已入庫條碼"
        Me.清除已入庫條碼.Size = New System.Drawing.Size(115, 37)
        Me.清除已入庫條碼.TabIndex = 190
        Me.清除已入庫條碼.Text = "清除已入庫條碼"
        Me.清除已入庫條碼.UseVisualStyleBackColor = True
        '
        '待轉數量
        '
        Me.待轉數量.AutoSize = True
        Me.待轉數量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.待轉數量.Location = New System.Drawing.Point(661, 40)
        Me.待轉數量.Name = "待轉數量"
        Me.待轉數量.Size = New System.Drawing.Size(72, 16)
        Me.待轉數量.TabIndex = 195
        Me.待轉數量.Text = "待轉數量"
        '
        '已入庫數
        '
        Me.已入庫數.AutoSize = True
        Me.已入庫數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.已入庫數.Location = New System.Drawing.Point(661, 62)
        Me.已入庫數.Name = "已入庫數"
        Me.已入庫數.Size = New System.Drawing.Size(72, 16)
        Me.已入庫數.TabIndex = 196
        Me.已入庫數.Text = "已入庫數"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(661, 552)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "v 101"
        '
        '作廢條碼
        '
        Me.作廢條碼.AutoSize = True
        Me.作廢條碼.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.作廢條碼.Location = New System.Drawing.Point(661, 81)
        Me.作廢條碼.Name = "作廢條碼"
        Me.作廢條碼.Size = New System.Drawing.Size(72, 16)
        Me.作廢條碼.TabIndex = 198
        Me.作廢條碼.Text = "作廢條碼"
        '
        '轉Excel
        '
        Me.轉Excel.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.轉Excel.Location = New System.Drawing.Point(88, 49)
        Me.轉Excel.Name = "轉Excel"
        Me.轉Excel.Size = New System.Drawing.Size(115, 29)
        Me.轉Excel.TabIndex = 199
        Me.轉Excel.Text = "轉Excel"
        Me.轉Excel.UseVisualStyleBackColor = True
        '
        'CB作業別
        '
        Me.CB作業別.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB作業別.FormattingEnabled = True
        Me.CB作業別.Items.AddRange(New Object() {"11.電宰入庫", "12.加工入庫"})
        Me.CB作業別.Location = New System.Drawing.Point(221, 51)
        Me.CB作業別.Name = "CB作業別"
        Me.CB作業別.Size = New System.Drawing.Size(143, 24)
        Me.CB作業別.TabIndex = 200
        '
        'Bu更換
        '
        Me.Bu更換.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Bu更換.Location = New System.Drawing.Point(370, 49)
        Me.Bu更換.Name = "Bu更換"
        Me.Bu更換.Size = New System.Drawing.Size(115, 29)
        Me.Bu更換.TabIndex = 201
        Me.Bu更換.Text = "更換作業別"
        Me.Bu更換.UseVisualStyleBackColor = True
        '
        'A_PDA上傳轉入V101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 574)
        Me.ControlBox = False
        Me.Controls.Add(Me.Bu更換)
        Me.Controls.Add(Me.CB作業別)
        Me.Controls.Add(Me.轉Excel)
        Me.Controls.Add(Me.作廢條碼)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.已入庫數)
        Me.Controls.Add(Me.待轉數量)
        Me.Controls.Add(Me.清除已入庫條碼)
        Me.Controls.Add(Me.上頁)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.讀取待轉區資料)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.同步至入庫區)
        Me.Name = "A_PDA上傳轉入V101"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDA入庫同步"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 同步至入庫區 As System.Windows.Forms.Button
    Friend WithEvents 讀取待轉區資料 As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents 上頁 As System.Windows.Forms.Button
    Friend WithEvents 清除已入庫條碼 As System.Windows.Forms.Button
    Friend WithEvents 待轉數量 As System.Windows.Forms.Label
    Friend WithEvents 已入庫數 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 作廢條碼 As System.Windows.Forms.Label
    Friend WithEvents 轉Excel As System.Windows.Forms.Button
    Friend WithEvents CB作業別 As System.Windows.Forms.ComboBox
    Friend WithEvents Bu更換 As System.Windows.Forms.Button
End Class
