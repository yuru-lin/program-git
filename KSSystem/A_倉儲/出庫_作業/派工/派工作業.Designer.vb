<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 派工作業
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
        Me.Floor = New System.Windows.Forms.ComboBox
        Me.Floor_tb = New System.Windows.Forms.Label
        Me.dateDocDate = New System.Windows.Forms.DateTimePicker
        Me.Period = New System.Windows.Forms.ComboBox
        Me.Period_tb = New System.Windows.Forms.Label
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.Button_01 = New System.Windows.Forms.Button
        Me.PrintBtn = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Period2 = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.存檔 = New System.Windows.Forms.Button
        Me.DGV4 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGV5 = New System.Windows.Forms.DataGridView
        Me.單號2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(89, 80)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(491, 312)
        Me.DGV1.TabIndex = 51
        '
        'Floor
        '
        Me.Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Floor.FormattingEnabled = True
        Me.Floor.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.Floor.Location = New System.Drawing.Point(52, 30)
        Me.Floor.Name = "Floor"
        Me.Floor.Size = New System.Drawing.Size(125, 20)
        Me.Floor.TabIndex = 77
        Me.Floor.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(1, 32)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 78
        Me.Floor_tb.Text = "樓層："
        '
        'dateDocDate
        '
        Me.dateDocDate.Location = New System.Drawing.Point(52, 5)
        Me.dateDocDate.Name = "dateDocDate"
        Me.dateDocDate.Size = New System.Drawing.Size(125, 22)
        Me.dateDocDate.TabIndex = 73
        Me.dateDocDate.TabStop = False
        '
        'Period
        '
        Me.Period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Period.FormattingEnabled = True
        Me.Period.Items.AddRange(New Object() {"06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "24:00"})
        Me.Period.Location = New System.Drawing.Point(846, 56)
        Me.Period.Name = "Period"
        Me.Period.Size = New System.Drawing.Size(125, 20)
        Me.Period.TabIndex = 75
        Me.Period.TabStop = False
        Me.Period.Visible = False
        '
        'Period_tb
        '
        Me.Period_tb.AutoSize = True
        Me.Period_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period_tb.Location = New System.Drawing.Point(1, 56)
        Me.Period_tb.Name = "Period_tb"
        Me.Period_tb.Size = New System.Drawing.Size(56, 16)
        Me.Period_tb.TabIndex = 74
        Me.Period_tb.Text = "時段："
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(1, 7)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 76
        Me.dateDocDate_tb.Text = "日期："
        '
        'Button_01
        '
        Me.Button_01.Location = New System.Drawing.Point(183, 5)
        Me.Button_01.Name = "Button_01"
        Me.Button_01.Size = New System.Drawing.Size(73, 22)
        Me.Button_01.TabIndex = 79
        Me.Button_01.TabStop = False
        Me.Button_01.Text = "查詢製單"
        Me.Button_01.UseVisualStyleBackColor = True
        '
        'PrintBtn
        '
        Me.PrintBtn.Location = New System.Drawing.Point(665, 54)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(73, 22)
        Me.PrintBtn.TabIndex = 80
        Me.PrintBtn.TabStop = False
        Me.PrintBtn.Text = "列印"
        Me.PrintBtn.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DGV2.Location = New System.Drawing.Point(89, 398)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(883, 209)
        Me.DGV2.TabIndex = 81
        '
        'Period2
        '
        Me.Period2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Period2.FormattingEnabled = True
        Me.Period2.Items.AddRange(New Object() {"1.   06:00~09:00", "2.   09:30~11:00", "3.   11:30~13:00", "4.   13:30~15:00", "5.   15:30~17:00", "6.   17:30~19:00", "7.   19:30~21:00", "8.   21:30~23:00", "9.   04:00~05:30"})
        Me.Period2.Location = New System.Drawing.Point(52, 54)
        Me.Period2.Name = "Period2"
        Me.Period2.Size = New System.Drawing.Size(125, 20)
        Me.Period2.TabIndex = 82
        Me.Period2.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(763, 7)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(81, 23)
        Me.TextBox1.TabIndex = 91
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(898, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 22)
        Me.Button2.TabIndex = 95
        Me.Button2.TabStop = False
        Me.Button2.Text = "所有庫位"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(898, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 22)
        Me.Button1.TabIndex = 93
        Me.Button1.TabStop = False
        Me.Button1.Text = "查詢庫位"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(850, 11)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox1.TabIndex = 94
        Me.CheckBox1.Text = "包含"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(711, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "來源："
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Location = New System.Drawing.Point(179, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(183, 32)
        Me.Panel1.TabIndex = 96
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(119, 6)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(58, 20)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "冷藏"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(61, 6)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(58, 20)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "冷凍"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(5, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 20)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "全部"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(4, 80)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.RowHeadersVisible = False
        Me.DGV3.RowHeadersWidth = 25
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(79, 312)
        Me.DGV3.TabIndex = 97
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(420, 6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(81, 23)
        Me.TextBox2.TabIndex = 99
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(368, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "區別："
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(507, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(73, 22)
        Me.Button4.TabIndex = 100
        Me.Button4.TabStop = False
        Me.Button4.Text = "查詢區別"
        Me.Button4.UseVisualStyleBackColor = True
        '
        '存檔
        '
        Me.存檔.Location = New System.Drawing.Point(586, 54)
        Me.存檔.Name = "存檔"
        Me.存檔.Size = New System.Drawing.Size(73, 22)
        Me.存檔.TabIndex = 102
        Me.存檔.TabStop = False
        Me.存檔.Text = "存檔"
        Me.存檔.UseVisualStyleBackColor = True
        '
        'DGV4
        '
        Me.DGV4.AllowUserToAddRows = False
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV4.Location = New System.Drawing.Point(586, 82)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.RowHeadersWidth = 25
        Me.DGV4.RowTemplate.Height = 24
        Me.DGV4.Size = New System.Drawing.Size(386, 310)
        Me.DGV4.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "單號："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(237, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "單號"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(322, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "製號"
        Me.Label4.Visible = False
        '
        'DGV5
        '
        Me.DGV5.AllowUserToAddRows = False
        Me.DGV5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV5.Location = New System.Drawing.Point(4, 398)
        Me.DGV5.Name = "DGV5"
        Me.DGV5.RowHeadersVisible = False
        Me.DGV5.RowHeadersWidth = 25
        Me.DGV5.RowTemplate.Height = 24
        Me.DGV5.Size = New System.Drawing.Size(79, 49)
        Me.DGV5.TabIndex = 107
        Me.DGV5.Visible = False
        '
        '單號2
        '
        Me.單號2.AutoSize = True
        Me.單號2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.單號2.Location = New System.Drawing.Point(1, 521)
        Me.單號2.Name = "單號2"
        Me.單號2.Size = New System.Drawing.Size(48, 16)
        Me.單號2.TabIndex = 108
        Me.單號2.Text = "單號2"
        Me.單號2.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 537)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "派次："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(49, 537)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "派次"
        '
        '派工作業
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.單號2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.Button_01)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV4)
        Me.Controls.Add(Me.存檔)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Period2)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Floor)
        Me.Controls.Add(Me.Floor_tb)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.Period)
        Me.Controls.Add(Me.Period_tb)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "派工作業"
        Me.Text = "快速預領單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents dateDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Period As System.Windows.Forms.ComboBox
    Friend WithEvents Period_tb As System.Windows.Forms.Label
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents Button_01 As System.Windows.Forms.Button
    Friend WithEvents PrintBtn As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Period2 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents 存檔 As System.Windows.Forms.Button
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGV5 As System.Windows.Forms.DataGridView
    Friend WithEvents 單號2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
