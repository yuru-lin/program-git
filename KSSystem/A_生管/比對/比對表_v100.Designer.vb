<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 比對表_v100
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
        Me.項目 = New System.Windows.Forms.ComboBox
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Lt2日期 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ItemName = New System.Windows.Forms.TextBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(427, 4)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.Bu查詢.TabIndex = 76
        Me.Bu查詢.TabStop = False
        Me.Bu查詢.Text = "查詢"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        '項目
        '
        Me.項目.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.項目.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.項目.FormattingEnabled = True
        Me.項目.Items.AddRange(New Object() {"全部", "總單數量", "訂單數量", "出貨數量", "排程數量", "生產數量"})
        Me.項目.Location = New System.Drawing.Point(211, 5)
        Me.項目.Name = "項目"
        Me.項目.Size = New System.Drawing.Size(210, 27)
        Me.項目.TabIndex = 77
        Me.項目.TabStop = False
        '
        '日期
        '
        Me.日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(55, 6)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(150, 27)
        Me.日期.TabIndex = 78
        Me.日期.TabStop = False
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(5, 10)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 79
        Me.dateDocDate_tb.Text = "日期："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV1.Location = New System.Drawing.Point(8, 69)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(972, 587)
        Me.DGV1.TabIndex = 81
        Me.DGV1.TabStop = False
        '
        'Lt2日期
        '
        Me.Lt2日期.AutoSize = True
        Me.Lt2日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt2日期.Location = New System.Drawing.Point(580, 13)
        Me.Lt2日期.Name = "Lt2日期"
        Me.Lt2日期.Size = New System.Drawing.Size(40, 16)
        Me.Lt2日期.TabIndex = 272
        Me.Lt2日期.Text = "日期"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(533, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 271
        Me.Label3.Text = "日期："
        '
        'ItemName
        '
        Me.ItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ItemName.BackColor = System.Drawing.SystemColors.Window
        Me.ItemName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemName.Location = New System.Drawing.Point(8, 36)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ItemName.Size = New System.Drawing.Size(197, 27)
        Me.ItemName.TabIndex = 273
        Me.ItemName.TabStop = False
        Me.ItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '比對表_v100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 657)
        Me.Controls.Add(Me.ItemName)
        Me.Controls.Add(Me.Lt2日期)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.日期)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Controls.Add(Me.Bu查詢)
        Me.Controls.Add(Me.項目)
        Me.Name = "比對表_v100"
        Me.Text = "比對表"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents 項目 As System.Windows.Forms.ComboBox
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Lt2日期 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ItemName As System.Windows.Forms.TextBox
End Class
