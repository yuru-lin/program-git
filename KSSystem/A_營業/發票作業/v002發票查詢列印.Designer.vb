<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v002發票查詢列印
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.查詢 = New System.Windows.Forms.Button
        Me.列印 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.DocNum = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.已列印 = New System.Windows.Forms.RadioButton
        Me.未列印 = New System.Windows.Forms.RadioButton
        Me.重新列印 = New System.Windows.Forms.Button
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Cb備註 = New System.Windows.Forms.ComboBox
        Me.修改為已列印 = New System.Windows.Forms.Button
        Me.是否列印 = New System.Windows.Forms.CheckBox
        Me.列印模式選擇 = New System.Windows.Forms.ComboBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "日期："
        '
        '日期
        '
        Me.日期.CalendarFont = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(86, 16)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(155, 27)
        Me.日期.TabIndex = 1
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(264, 12)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(100, 56)
        Me.查詢.TabIndex = 2
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        '列印
        '
        Me.列印.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.列印.Location = New System.Drawing.Point(694, 12)
        Me.列印.Name = "列印"
        Me.列印.Size = New System.Drawing.Size(98, 56)
        Me.列印.TabIndex = 4
        Me.列印.Text = "列印"
        Me.列印.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 392)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "明細"
        '
        'DocNum
        '
        Me.DocNum.AutoSize = True
        Me.DocNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocNum.ForeColor = System.Drawing.Color.Red
        Me.DocNum.Location = New System.Drawing.Point(103, 68)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.Size = New System.Drawing.Size(40, 16)
        Me.DocNum.TabIndex = 12
        Me.DocNum.Text = "單號"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "草稿單號："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle22.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV1.DefaultCellStyle = DataGridViewCellStyle22
        Me.DGV1.Location = New System.Drawing.Point(21, 88)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(986, 289)
        Me.DGV1.TabIndex = 14
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV2.DefaultCellStyle = DataGridViewCellStyle24
        Me.DGV2.Location = New System.Drawing.Point(21, 414)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(986, 278)
        Me.DGV2.TabIndex = 15
        '
        '已列印
        '
        Me.已列印.AutoSize = True
        Me.已列印.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.已列印.Location = New System.Drawing.Point(376, 30)
        Me.已列印.Name = "已列印"
        Me.已列印.Size = New System.Drawing.Size(84, 23)
        Me.已列印.TabIndex = 16
        Me.已列印.Text = "已列印"
        Me.已列印.UseVisualStyleBackColor = True
        '
        '未列印
        '
        Me.未列印.AutoSize = True
        Me.未列印.Checked = True
        Me.未列印.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.未列印.Location = New System.Drawing.Point(376, 6)
        Me.未列印.Name = "未列印"
        Me.未列印.Size = New System.Drawing.Size(84, 23)
        Me.未列印.TabIndex = 17
        Me.未列印.TabStop = True
        Me.未列印.Text = "未列印"
        Me.未列印.UseVisualStyleBackColor = True
        '
        '重新列印
        '
        Me.重新列印.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.重新列印.Location = New System.Drawing.Point(907, 12)
        Me.重新列印.Name = "重新列印"
        Me.重新列印.Size = New System.Drawing.Size(98, 56)
        Me.重新列印.TabIndex = 18
        Me.重新列印.Text = "重新列印"
        Me.重新列印.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(578, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 19
        Me.TextBox1.Text = "12"
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(578, 42)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 20
        Me.TextBox2.Text = "微軟正黑體"
        Me.TextBox2.Visible = False
        '
        'Cb備註
        '
        Me.Cb備註.Font = New System.Drawing.Font("細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb備註.FormattingEnabled = True
        Me.Cb備註.Location = New System.Drawing.Point(464, 382)
        Me.Cb備註.Margin = New System.Windows.Forms.Padding(4)
        Me.Cb備註.Name = "Cb備註"
        Me.Cb備註.Size = New System.Drawing.Size(487, 27)
        Me.Cb備註.TabIndex = 261
        Me.Cb備註.Visible = False
        '
        '修改為已列印
        '
        Me.修改為已列印.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.修改為已列印.Location = New System.Drawing.Point(801, 12)
        Me.修改為已列印.Name = "修改為已列印"
        Me.修改為已列印.Size = New System.Drawing.Size(98, 56)
        Me.修改為已列印.TabIndex = 262
        Me.修改為已列印.Text = "修改為  已列印"
        Me.修改為已列印.UseVisualStyleBackColor = True
        '
        '是否列印
        '
        Me.是否列印.AutoSize = True
        Me.是否列印.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.是否列印.Location = New System.Drawing.Point(468, 15)
        Me.是否列印.Name = "是否列印"
        Me.是否列印.Size = New System.Drawing.Size(104, 23)
        Me.是否列印.TabIndex = 263
        Me.是否列印.Text = "是否列印"
        Me.是否列印.UseVisualStyleBackColor = True
        Me.是否列印.Visible = False
        '
        '列印模式選擇
        '
        Me.列印模式選擇.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.列印模式選擇.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.列印模式選擇.FormattingEnabled = True
        Me.列印模式選擇.Items.AddRange(New Object() {"發票列印", "只印證明聯", "發票不印"})
        Me.列印模式選擇.Location = New System.Drawing.Point(376, 58)
        Me.列印模式選擇.Name = "列印模式選擇"
        Me.列印模式選擇.Size = New System.Drawing.Size(126, 24)
        Me.列印模式選擇.TabIndex = 264
        '
        'v002發票查詢列印
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 709)
        Me.Controls.Add(Me.列印模式選擇)
        Me.Controls.Add(Me.是否列印)
        Me.Controls.Add(Me.修改為已列印)
        Me.Controls.Add(Me.Cb備註)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.重新列印)
        Me.Controls.Add(Me.未列印)
        Me.Controls.Add(Me.已列印)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DocNum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.列印)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.日期)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Name = "v002發票查詢列印"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "發票查詢列印"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents 列印 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DocNum As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents 已列印 As System.Windows.Forms.RadioButton
    Friend WithEvents 未列印 As System.Windows.Forms.RadioButton
    Friend WithEvents 重新列印 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Private WithEvents Cb備註 As System.Windows.Forms.ComboBox
    Friend WithEvents 修改為已列印 As System.Windows.Forms.Button
    Friend WithEvents 是否列印 As System.Windows.Forms.CheckBox
    Friend WithEvents 列印模式選擇 As System.Windows.Forms.ComboBox
End Class
