<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PDA同步V104
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Bu讀取 = New System.Windows.Forms.Button
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.Bu上頁 = New System.Windows.Forms.Button
        Me.Bu同步 = New System.Windows.Forms.Button
        Me.La數量 = New System.Windows.Forms.Label
        Me.La入庫 = New System.Windows.Forms.Label
        Me.La出庫 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.La作業 = New System.Windows.Forms.Label
        Me.Bu移除 = New System.Windows.Forms.Button
        Me.La時間 = New System.Windows.Forms.Label
        Me.La作廢 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Bu更換 = New System.Windows.Forms.Button
        Me.CB作業別 = New System.Windows.Forms.ComboBox
        Me.La異常 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.轉Excel = New System.Windows.Forms.Button
        Me.La重複 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Bu勾選 = New System.Windows.Forms.Button
        Me.CB顯示鮮享 = New System.Windows.Forms.CheckBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "條碼出庫清點同步作業"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(306, 75)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(622, 474)
        Me.DGV1.TabIndex = 1
        '
        'Bu讀取
        '
        Me.Bu讀取.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu讀取.Location = New System.Drawing.Point(379, 232)
        Me.Bu讀取.Name = "Bu讀取"
        Me.Bu讀取.Size = New System.Drawing.Size(186, 50)
        Me.Bu讀取.TabIndex = 2
        Me.Bu讀取.Text = "讀取待轉區資料"
        Me.Bu讀取.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(698, 163)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(230, 304)
        Me.DGV3.TabIndex = 3
        '
        'Bu上頁
        '
        Me.Bu上頁.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu上頁.Location = New System.Drawing.Point(847, 555)
        Me.Bu上頁.Name = "Bu上頁"
        Me.Bu上頁.Size = New System.Drawing.Size(80, 50)
        Me.Bu上頁.TabIndex = 4
        Me.Bu上頁.Text = "上頁"
        Me.Bu上頁.UseVisualStyleBackColor = True
        '
        'Bu同步
        '
        Me.Bu同步.Enabled = False
        Me.Bu同步.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu同步.ForeColor = System.Drawing.Color.Red
        Me.Bu同步.Location = New System.Drawing.Point(306, 555)
        Me.Bu同步.Name = "Bu同步"
        Me.Bu同步.Size = New System.Drawing.Size(230, 50)
        Me.Bu同步.TabIndex = 6
        Me.Bu同步.Text = "同步至資料庫"
        Me.Bu同步.UseVisualStyleBackColor = True
        '
        'La數量
        '
        Me.La數量.AutoSize = True
        Me.La數量.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La數量.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La數量.Location = New System.Drawing.Point(261, 41)
        Me.La數量.Name = "La數量"
        Me.La數量.Size = New System.Drawing.Size(49, 19)
        Me.La數量.TabIndex = 7
        Me.La數量.Text = "數量"
        '
        'La入庫
        '
        Me.La入庫.AutoSize = True
        Me.La入庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La入庫.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La入庫.Location = New System.Drawing.Point(476, 41)
        Me.La入庫.Name = "La入庫"
        Me.La入庫.Size = New System.Drawing.Size(49, 19)
        Me.La入庫.TabIndex = 8
        Me.La入庫.Text = "入庫"
        '
        'La出庫
        '
        Me.La出庫.AutoSize = True
        Me.La出庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La出庫.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La出庫.Location = New System.Drawing.Point(588, 41)
        Me.La出庫.Name = "La出庫"
        Me.La出庫.Size = New System.Drawing.Size(49, 19)
        Me.La出庫.TabIndex = 9
        Me.La出庫.Text = "出庫"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(694, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "儲位數量"
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(12, 75)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowHeadersVisible = False
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(288, 524)
        Me.DGV2.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(531, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "出庫："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(419, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "入庫："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(204, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "總數："
        '
        'La作業
        '
        Me.La作業.AutoSize = True
        Me.La作業.Font = New System.Drawing.Font("新細明體", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La作業.ForeColor = System.Drawing.Color.Red
        Me.La作業.Location = New System.Drawing.Point(542, 564)
        Me.La作業.Name = "La作業"
        Me.La作業.Size = New System.Drawing.Size(87, 35)
        Me.La作業.TabIndex = 15
        Me.La作業.Text = "作業"
        Me.La作業.Visible = False
        '
        'Bu移除
        '
        Me.Bu移除.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu移除.ForeColor = System.Drawing.Color.Red
        Me.Bu移除.Location = New System.Drawing.Point(778, 41)
        Me.Bu移除.Name = "Bu移除"
        Me.Bu移除.Size = New System.Drawing.Size(150, 30)
        Me.Bu移除.TabIndex = 16
        Me.Bu移除.Text = "快速異常排除"
        Me.Bu移除.UseVisualStyleBackColor = True
        '
        'La時間
        '
        Me.La時間.AutoSize = True
        Me.La時間.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La時間.Location = New System.Drawing.Point(695, 564)
        Me.La時間.Name = "La時間"
        Me.La時間.Size = New System.Drawing.Size(72, 16)
        Me.La時間.TabIndex = 159
        Me.La時間.Text = "執行時間"
        '
        'La作廢
        '
        Me.La作廢.AutoSize = True
        Me.La作廢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La作廢.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La作廢.Location = New System.Drawing.Point(873, 15)
        Me.La作廢.Name = "La作廢"
        Me.La作廢.Size = New System.Drawing.Size(49, 19)
        Me.La作廢.TabIndex = 160
        Me.La作廢.Text = "作廢"
        Me.La作廢.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(816, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "作廢："
        Me.Label8.Visible = False
        '
        'Bu更換
        '
        Me.Bu更換.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu更換.Location = New System.Drawing.Point(548, 113)
        Me.Bu更換.Name = "Bu更換"
        Me.Bu更換.Size = New System.Drawing.Size(115, 29)
        Me.Bu更換.TabIndex = 203
        Me.Bu更換.Text = "更換作業別"
        Me.Bu更換.UseVisualStyleBackColor = True
        '
        'CB作業別
        '
        Me.CB作業別.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB作業別.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB作業別.FormattingEnabled = True
        Me.CB作業別.Location = New System.Drawing.Point(16, 35)
        Me.CB作業別.Name = "CB作業別"
        Me.CB作業別.Size = New System.Drawing.Size(182, 29)
        Me.CB作業別.TabIndex = 202
        '
        'La異常
        '
        Me.La異常.AutoSize = True
        Me.La異常.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La異常.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La異常.Location = New System.Drawing.Point(757, 15)
        Me.La異常.Name = "La異常"
        Me.La異常.Size = New System.Drawing.Size(49, 19)
        Me.La異常.TabIndex = 204
        Me.La異常.Text = "異常"
        Me.La異常.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(700, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 19)
        Me.Label9.TabIndex = 205
        Me.Label9.Text = "異常："
        Me.Label9.Visible = False
        '
        '轉Excel
        '
        Me.轉Excel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.轉Excel.Location = New System.Drawing.Point(563, 551)
        Me.轉Excel.Name = "轉Excel"
        Me.轉Excel.Size = New System.Drawing.Size(115, 29)
        Me.轉Excel.TabIndex = 206
        Me.轉Excel.Text = "轉Excel"
        Me.轉Excel.UseVisualStyleBackColor = True
        '
        'La重複
        '
        Me.La重複.AutoSize = True
        Me.La重複.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La重複.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La重複.Location = New System.Drawing.Point(364, 41)
        Me.La重複.Name = "La重複"
        Me.La重複.Size = New System.Drawing.Size(49, 19)
        Me.La重複.TabIndex = 207
        Me.La重複.Text = "重複"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(307, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 19)
        Me.Label10.TabIndex = 208
        Me.Label10.Text = "重複："
        '
        'Bu勾選
        '
        Me.Bu勾選.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu勾選.ForeColor = System.Drawing.Color.Red
        Me.Bu勾選.Location = New System.Drawing.Point(491, 89)
        Me.Bu勾選.Name = "Bu勾選"
        Me.Bu勾選.Size = New System.Drawing.Size(115, 29)
        Me.Bu勾選.TabIndex = 209
        Me.Bu勾選.Text = "移除勾選"
        Me.Bu勾選.UseVisualStyleBackColor = True
        Me.Bu勾選.Visible = False
        '
        'CB顯示鮮享
        '
        Me.CB顯示鮮享.AutoSize = True
        Me.CB顯示鮮享.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB顯示鮮享.ForeColor = System.Drawing.Color.Blue
        Me.CB顯示鮮享.Location = New System.Drawing.Point(447, 118)
        Me.CB顯示鮮享.Name = "CB顯示鮮享"
        Me.CB顯示鮮享.Size = New System.Drawing.Size(95, 20)
        Me.CB顯示鮮享.TabIndex = 210
        Me.CB顯示鮮享.Text = "顯示鮮享"
        Me.CB顯示鮮享.UseVisualStyleBackColor = True
        '
        'PDA同步V104
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 611)
        Me.ControlBox = False
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.CB顯示鮮享)
        Me.Controls.Add(Me.Bu勾選)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.La重複)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.La異常)
        Me.Controls.Add(Me.La作廢)
        Me.Controls.Add(Me.La出庫)
        Me.Controls.Add(Me.La入庫)
        Me.Controls.Add(Me.La數量)
        Me.Controls.Add(Me.轉Excel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Bu更換)
        Me.Controls.Add(Me.CB作業別)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.La時間)
        Me.Controls.Add(Me.Bu移除)
        Me.Controls.Add(Me.La作業)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Bu同步)
        Me.Controls.Add(Me.Bu上頁)
        Me.Controls.Add(Me.Bu讀取)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PDA同步V104"
        Me.Text = "PDA上傳轉入(出庫作業)"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu讀取 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu上頁 As System.Windows.Forms.Button
    Friend WithEvents Bu同步 As System.Windows.Forms.Button
    Friend WithEvents La數量 As System.Windows.Forms.Label
    Friend WithEvents La入庫 As System.Windows.Forms.Label
    Friend WithEvents La出庫 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents La作業 As System.Windows.Forms.Label
    Friend WithEvents Bu移除 As System.Windows.Forms.Button
    Friend WithEvents La時間 As System.Windows.Forms.Label
    Friend WithEvents La作廢 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Bu更換 As System.Windows.Forms.Button
    Friend WithEvents CB作業別 As System.Windows.Forms.ComboBox
    Friend WithEvents La異常 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents 轉Excel As System.Windows.Forms.Button
    Friend WithEvents La重複 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Bu勾選 As System.Windows.Forms.Button
    Friend WithEvents CB顯示鮮享 As System.Windows.Forms.CheckBox
End Class
