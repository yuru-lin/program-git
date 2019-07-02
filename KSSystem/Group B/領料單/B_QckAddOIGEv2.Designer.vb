<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QckAddOIGEv2
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
        Me.DGV11 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(181, 59)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(354, 299)
        Me.DGV1.TabIndex = 51
        '
        'Floor
        '
        Me.Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Floor.FormattingEnabled = True
        Me.Floor.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.Floor.Location = New System.Drawing.Point(52, 32)
        Me.Floor.Name = "Floor"
        Me.Floor.Size = New System.Drawing.Size(125, 20)
        Me.Floor.TabIndex = 77
        Me.Floor.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(1, 34)
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
        Me.Period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.Period.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Period.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period.FormattingEnabled = True
        Me.Period.Items.AddRange(New Object() {"06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "24:00"})
        Me.Period.Location = New System.Drawing.Point(233, 5)
        Me.Period.Name = "Period"
        Me.Period.Size = New System.Drawing.Size(65, 20)
        Me.Period.TabIndex = 75
        Me.Period.TabStop = False
        '
        'Period_tb
        '
        Me.Period_tb.AutoSize = True
        Me.Period_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period_tb.Location = New System.Drawing.Point(180, 7)
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
        Me.Button_01.Location = New System.Drawing.Point(183, 31)
        Me.Button_01.Name = "Button_01"
        Me.Button_01.Size = New System.Drawing.Size(73, 22)
        Me.Button_01.TabIndex = 79
        Me.Button_01.TabStop = False
        Me.Button_01.Text = "查詢"
        Me.Button_01.UseVisualStyleBackColor = True
        '
        'PrintBtn
        '
        Me.PrintBtn.Location = New System.Drawing.Point(462, 30)
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
        Me.DGV2.Location = New System.Drawing.Point(541, 59)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(337, 271)
        Me.DGV2.TabIndex = 81
        '
        'DGV11
        '
        Me.DGV11.AllowUserToAddRows = False
        Me.DGV11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV11.Location = New System.Drawing.Point(4, 59)
        Me.DGV11.Name = "DGV11"
        Me.DGV11.RowHeadersVisible = False
        Me.DGV11.RowHeadersWidth = 24
        Me.DGV11.RowTemplate.Height = 24
        Me.DGV11.Size = New System.Drawing.Size(171, 479)
        Me.DGV11.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "排單"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "製單"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(673, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(81, 23)
        Me.TextBox1.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(621, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "來源："
        Me.Label3.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(808, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 22)
        Me.Button1.TabIndex = 87
        Me.Button1.TabStop = False
        Me.Button1.Text = "查詢庫位"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(760, 9)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox1.TabIndex = 88
        Me.CheckBox1.Text = "包含"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(181, 364)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.RowHeadersVisible = False
        Me.DGV3.RowHeadersWidth = 24
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(697, 176)
        Me.DGV3.TabIndex = 89
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(808, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(73, 22)
        Me.Button2.TabIndex = 90
        Me.Button2.TabStop = False
        Me.Button2.Text = "所有庫位"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(4, 546)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(354, 104)
        Me.Panel1.TabIndex = 91
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "區別"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(174, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "數量"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(174, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "品名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(174, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "存編"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(670, 338)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "區別："
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(722, 336)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(81, 23)
        Me.TextBox2.TabIndex = 93
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(541, 336)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(73, 22)
        Me.Button3.TabIndex = 94
        Me.Button3.TabStop = False
        Me.Button3.Text = "存檔"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(805, 336)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(73, 22)
        Me.Button4.TabIndex = 95
        Me.Button4.TabStop = False
        Me.Button4.Text = "查詢"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'B_QckAddOIGEv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 662)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV11)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.Button_01)
        Me.Controls.Add(Me.Floor)
        Me.Controls.Add(Me.Floor_tb)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.Period)
        Me.Controls.Add(Me.Period_tb)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "B_QckAddOIGEv2"
        Me.Text = "快速預領單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents DGV11 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
