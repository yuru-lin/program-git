<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產入庫自動化v100Bak
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.入庫作業 = New System.Windows.Forms.TabPage
        Me.PDA轉入 = New System.Windows.Forms.TabPage
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.La時間 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.La入庫 = New System.Windows.Forms.Label
        Me.La數量 = New System.Windows.Forms.Label
        Me.La重複 = New System.Windows.Forms.Label
        Me.La異常 = New System.Windows.Forms.Label
        Me.La作廢 = New System.Windows.Forms.Label
        Me.La出庫 = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.Bu讀取 = New System.Windows.Forms.Button
        Me.Bu同步 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.La作業 = New System.Windows.Forms.Label
        Me.Bu移除 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.電腦時間 = New System.Windows.Forms.Label
        Me.即時時間 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.PDA轉入.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.入庫作業)
        Me.TabControl1.Controls.Add(Me.PDA轉入)
        Me.TabControl1.Location = New System.Drawing.Point(2, 43)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(960, 589)
        Me.TabControl1.TabIndex = 0
        '
        '入庫作業
        '
        Me.入庫作業.Location = New System.Drawing.Point(4, 22)
        Me.入庫作業.Name = "入庫作業"
        Me.入庫作業.Padding = New System.Windows.Forms.Padding(3)
        Me.入庫作業.Size = New System.Drawing.Size(952, 563)
        Me.入庫作業.TabIndex = 0
        Me.入庫作業.Text = "入庫作業"
        Me.入庫作業.UseVisualStyleBackColor = True
        '
        'PDA轉入
        '
        Me.PDA轉入.Controls.Add(Me.DGV1)
        Me.PDA轉入.Controls.Add(Me.La時間)
        Me.PDA轉入.Controls.Add(Me.Label1)
        Me.PDA轉入.Controls.Add(Me.La入庫)
        Me.PDA轉入.Controls.Add(Me.La數量)
        Me.PDA轉入.Controls.Add(Me.La重複)
        Me.PDA轉入.Controls.Add(Me.La異常)
        Me.PDA轉入.Controls.Add(Me.La作廢)
        Me.PDA轉入.Controls.Add(Me.La出庫)
        Me.PDA轉入.Controls.Add(Me.DGV3)
        Me.PDA轉入.Controls.Add(Me.Bu讀取)
        Me.PDA轉入.Controls.Add(Me.Bu同步)
        Me.PDA轉入.Controls.Add(Me.Label10)
        Me.PDA轉入.Controls.Add(Me.Label6)
        Me.PDA轉入.Controls.Add(Me.Label5)
        Me.PDA轉入.Controls.Add(Me.Label4)
        Me.PDA轉入.Controls.Add(Me.Label3)
        Me.PDA轉入.Controls.Add(Me.La作業)
        Me.PDA轉入.Controls.Add(Me.Bu移除)
        Me.PDA轉入.Controls.Add(Me.Label9)
        Me.PDA轉入.Controls.Add(Me.Label8)
        Me.PDA轉入.Location = New System.Drawing.Point(4, 22)
        Me.PDA轉入.Name = "PDA轉入"
        Me.PDA轉入.Padding = New System.Windows.Forms.Padding(3)
        Me.PDA轉入.Size = New System.Drawing.Size(952, 563)
        Me.PDA轉入.TabIndex = 1
        Me.PDA轉入.Text = "PDA轉入"
        Me.PDA轉入.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(4, 30)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(680, 527)
        Me.DGV1.TabIndex = 87
        '
        'La時間
        '
        Me.La時間.AutoSize = True
        Me.La時間.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La時間.Location = New System.Drawing.Point(718, 11)
        Me.La時間.Name = "La時間"
        Me.La時間.Size = New System.Drawing.Size(72, 16)
        Me.La時間.TabIndex = 227
        Me.La時間.Text = "執行時間"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 21)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "條碼入出庫清點同步作業"
        '
        'La入庫
        '
        Me.La入庫.AutoSize = True
        Me.La入庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La入庫.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La入庫.Location = New System.Drawing.Point(774, 102)
        Me.La入庫.Name = "La入庫"
        Me.La入庫.Size = New System.Drawing.Size(49, 19)
        Me.La入庫.TabIndex = 213
        Me.La入庫.Text = "入庫"
        '
        'La數量
        '
        Me.La數量.AutoSize = True
        Me.La數量.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La數量.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La數量.Location = New System.Drawing.Point(774, 83)
        Me.La數量.Name = "La數量"
        Me.La數量.Size = New System.Drawing.Size(49, 19)
        Me.La數量.TabIndex = 212
        Me.La數量.Text = "數量"
        '
        'La重複
        '
        Me.La重複.AutoSize = True
        Me.La重複.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La重複.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La重複.Location = New System.Drawing.Point(774, 159)
        Me.La重複.Name = "La重複"
        Me.La重複.Size = New System.Drawing.Size(49, 19)
        Me.La重複.TabIndex = 225
        Me.La重複.Text = "重複"
        Me.La重複.Visible = False
        '
        'La異常
        '
        Me.La異常.AutoSize = True
        Me.La異常.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La異常.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La異常.Location = New System.Drawing.Point(774, 140)
        Me.La異常.Name = "La異常"
        Me.La異常.Size = New System.Drawing.Size(49, 19)
        Me.La異常.TabIndex = 223
        Me.La異常.Text = "異常"
        '
        'La作廢
        '
        Me.La作廢.AutoSize = True
        Me.La作廢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La作廢.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La作廢.Location = New System.Drawing.Point(774, 121)
        Me.La作廢.Name = "La作廢"
        Me.La作廢.Size = New System.Drawing.Size(49, 19)
        Me.La作廢.TabIndex = 221
        Me.La作廢.Text = "作廢"
        '
        'La出庫
        '
        Me.La出庫.AutoSize = True
        Me.La出庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La出庫.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La出庫.Location = New System.Drawing.Point(886, 102)
        Me.La出庫.Name = "La出庫"
        Me.La出庫.Size = New System.Drawing.Size(49, 19)
        Me.La出庫.TabIndex = 214
        Me.La出庫.Text = "出庫"
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(717, 262)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(230, 202)
        Me.DGV3.TabIndex = 210
        '
        'Bu讀取
        '
        Me.Bu讀取.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu讀取.Location = New System.Drawing.Point(716, 30)
        Me.Bu讀取.Name = "Bu讀取"
        Me.Bu讀取.Size = New System.Drawing.Size(230, 50)
        Me.Bu讀取.TabIndex = 209
        Me.Bu讀取.Text = "讀取待轉區資料"
        Me.Bu讀取.UseVisualStyleBackColor = True
        '
        'Bu同步
        '
        Me.Bu同步.Enabled = False
        Me.Bu同步.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu同步.ForeColor = System.Drawing.Color.Red
        Me.Bu同步.Location = New System.Drawing.Point(716, 470)
        Me.Bu同步.Name = "Bu同步"
        Me.Bu同步.Size = New System.Drawing.Size(230, 50)
        Me.Bu同步.TabIndex = 211
        Me.Bu同步.Text = "同步至資料庫"
        Me.Bu同步.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(717, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 19)
        Me.Label10.TabIndex = 226
        Me.Label10.Text = "重複："
        Me.Label10.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(717, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = "儲位數量"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(717, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 216
        Me.Label5.Text = "數量："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(717, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 19)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "入庫："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(829, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 218
        Me.Label3.Text = "出庫："
        '
        'La作業
        '
        Me.La作業.AutoSize = True
        Me.La作業.Font = New System.Drawing.Font("新細明體", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La作業.ForeColor = System.Drawing.Color.Red
        Me.La作業.Location = New System.Drawing.Point(719, 523)
        Me.La作業.Name = "La作業"
        Me.La作業.Size = New System.Drawing.Size(87, 35)
        Me.La作業.TabIndex = 219
        Me.La作業.Text = "作業"
        '
        'Bu移除
        '
        Me.Bu移除.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu移除.ForeColor = System.Drawing.Color.Red
        Me.Bu移除.Location = New System.Drawing.Point(796, 209)
        Me.Bu移除.Name = "Bu移除"
        Me.Bu移除.Size = New System.Drawing.Size(150, 30)
        Me.Bu移除.TabIndex = 220
        Me.Bu移除.Text = "移除異常條碼"
        Me.Bu移除.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(717, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 19)
        Me.Label9.TabIndex = 224
        Me.Label9.Text = "異常："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(717, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 222
        Me.Label8.Text = "作廢："
        '
        '電腦時間
        '
        Me.電腦時間.AutoSize = True
        Me.電腦時間.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.電腦時間.ForeColor = System.Drawing.Color.Red
        Me.電腦時間.Location = New System.Drawing.Point(780, 2)
        Me.電腦時間.Name = "電腦時間"
        Me.電腦時間.Size = New System.Drawing.Size(89, 19)
        Me.電腦時間.TabIndex = 85
        Me.電腦時間.Text = "電腦時間"
        '
        '即時時間
        '
        '
        '生產入庫自動化v100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 637)
        Me.Controls.Add(Me.電腦時間)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "生產入庫自動化v100"
        Me.Text = "生產入庫自動化v100"
        Me.TabControl1.ResumeLayout(False)
        Me.PDA轉入.ResumeLayout(False)
        Me.PDA轉入.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents 入庫作業 As System.Windows.Forms.TabPage
    Friend WithEvents PDA轉入 As System.Windows.Forms.TabPage
    Friend WithEvents La入庫 As System.Windows.Forms.Label
    Friend WithEvents La數量 As System.Windows.Forms.Label
    Friend WithEvents La重複 As System.Windows.Forms.Label
    Friend WithEvents La異常 As System.Windows.Forms.Label
    Friend WithEvents La作廢 As System.Windows.Forms.Label
    Friend WithEvents La出庫 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu讀取 As System.Windows.Forms.Button
    Friend WithEvents Bu同步 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents La作業 As System.Windows.Forms.Label
    Friend WithEvents Bu移除 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents La時間 As System.Windows.Forms.Label
    Friend WithEvents 電腦時間 As System.Windows.Forms.Label
    Friend WithEvents 即時時間 As System.Windows.Forms.Timer
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
