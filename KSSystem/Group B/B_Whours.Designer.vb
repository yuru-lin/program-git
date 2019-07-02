<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_Whours
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
        Me.Floor = New System.Windows.Forms.ComboBox
        Me.Floor_tb = New System.Windows.Forms.Label
        Me.WDate = New System.Windows.Forms.DateTimePicker
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.Button_01 = New System.Windows.Forms.Button
        Me.DGV_IN = New System.Windows.Forms.DataGridView
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button_02 = New System.Windows.Forms.Button
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RB32 = New System.Windows.Forms.RadioButton
        Me.RB31 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RB41 = New System.Windows.Forms.RadioButton
        Me.RB42 = New System.Windows.Forms.RadioButton
        Me.RB33 = New System.Windows.Forms.RadioButton
        CType(Me.DGV_IN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Floor
        '
        Me.Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Floor.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor.FormattingEnabled = True
        Me.Floor.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.Floor.Location = New System.Drawing.Point(240, 8)
        Me.Floor.Name = "Floor"
        Me.Floor.Size = New System.Drawing.Size(68, 21)
        Me.Floor.TabIndex = 75
        Me.Floor.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(189, 9)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 76
        Me.Floor_tb.Text = "樓層："
        '
        'WDate
        '
        Me.WDate.Location = New System.Drawing.Point(57, 7)
        Me.WDate.Name = "WDate"
        Me.WDate.Size = New System.Drawing.Size(126, 22)
        Me.WDate.TabIndex = 73
        Me.WDate.TabStop = False
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(7, 9)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 74
        Me.dateDocDate_tb.Text = "日期："
        '
        'Button_01
        '
        Me.Button_01.Location = New System.Drawing.Point(313, 8)
        Me.Button_01.Name = "Button_01"
        Me.Button_01.Size = New System.Drawing.Size(87, 22)
        Me.Button_01.TabIndex = 77
        Me.Button_01.TabStop = False
        Me.Button_01.Text = "查詢"
        Me.Button_01.UseVisualStyleBackColor = True
        '
        'DGV_IN
        '
        Me.DGV_IN.AllowUserToAddRows = False
        Me.DGV_IN.AllowUserToDeleteRows = False
        Me.DGV_IN.AllowUserToResizeRows = False
        Me.DGV_IN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_IN.Location = New System.Drawing.Point(10, 35)
        Me.DGV_IN.MultiSelect = False
        Me.DGV_IN.Name = "DGV_IN"
        Me.DGV_IN.ReadOnly = True
        Me.DGV_IN.RowHeadersVisible = False
        Me.DGV_IN.RowHeadersWidth = 25
        Me.DGV_IN.RowTemplate.Height = 24
        Me.DGV_IN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_IN.Size = New System.Drawing.Size(215, 354)
        Me.DGV_IN.TabIndex = 120
        Me.DGV_IN.TabStop = False
        '
        'DGV1
        '
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV1.Location = New System.Drawing.Point(231, 35)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(721, 354)
        Me.DGV1.TabIndex = 119
        Me.DGV1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(10, 453)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(134, 22)
        Me.TextBox1.TabIndex = 122
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(10, 481)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(134, 22)
        Me.TextBox2.TabIndex = 123
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(150, 396)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 125
        Me.Button1.Text = "查詢項目"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_02
        '
        Me.Button_02.Location = New System.Drawing.Point(865, 9)
        Me.Button_02.Name = "Button_02"
        Me.Button_02.Size = New System.Drawing.Size(87, 22)
        Me.Button_02.TabIndex = 78
        Me.Button_02.TabStop = False
        Me.Button_02.Text = "更新"
        Me.Button_02.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(290, 396)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(155, 22)
        Me.TextBox3.TabIndex = 126
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(290, 424)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(155, 22)
        Me.TextBox4.TabIndex = 127
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(345, 452)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 22)
        Me.TextBox5.TabIndex = 128
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(345, 480)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 22)
        Me.TextBox6.TabIndex = 129
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(345, 508)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 22)
        Me.TextBox7.TabIndex = 130
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(345, 536)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(100, 22)
        Me.TextBox8.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(228, 402)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "存編："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(228, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "品名："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(228, 458)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 134
        Me.Label3.Text = "預估訂單量："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(228, 486)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 16)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "數量/1H/1人："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(228, 514)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "預估人數："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(228, 542)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "預估工時："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 585)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(64, 585)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "Label8"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RB33)
        Me.Panel1.Controls.Add(Me.RB31)
        Me.Panel1.Controls.Add(Me.RB32)
        Me.Panel1.Location = New System.Drawing.Point(10, 424)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(212, 23)
        Me.Panel1.TabIndex = 140
        '
        'RB32
        '
        Me.RB32.AutoSize = True
        Me.RB32.Checked = True
        Me.RB32.Location = New System.Drawing.Point(3, 3)
        Me.RB32.Name = "RB32"
        Me.RB32.Size = New System.Drawing.Size(47, 16)
        Me.RB32.TabIndex = 0
        Me.RB32.TabStop = True
        Me.RB32.Text = "冷藏"
        Me.RB32.UseVisualStyleBackColor = True
        '
        'RB31
        '
        Me.RB31.AutoSize = True
        Me.RB31.Location = New System.Drawing.Point(70, 3)
        Me.RB31.Name = "RB31"
        Me.RB31.Size = New System.Drawing.Size(47, 16)
        Me.RB31.TabIndex = 1
        Me.RB31.Text = "冷凍"
        Me.RB31.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RB42)
        Me.Panel2.Controls.Add(Me.RB41)
        Me.Panel2.Location = New System.Drawing.Point(10, 395)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(134, 23)
        Me.Panel2.TabIndex = 141
        '
        'RB41
        '
        Me.RB41.AutoSize = True
        Me.RB41.Checked = True
        Me.RB41.Location = New System.Drawing.Point(3, 4)
        Me.RB41.Name = "RB41"
        Me.RB41.Size = New System.Drawing.Size(47, 16)
        Me.RB41.TabIndex = 2
        Me.RB41.TabStop = True
        Me.RB41.Text = "全雞"
        Me.RB41.UseVisualStyleBackColor = True
        '
        'RB42
        '
        Me.RB42.AutoSize = True
        Me.RB42.Location = New System.Drawing.Point(70, 3)
        Me.RB42.Name = "RB42"
        Me.RB42.Size = New System.Drawing.Size(47, 16)
        Me.RB42.TabIndex = 3
        Me.RB42.Text = "分切"
        Me.RB42.UseVisualStyleBackColor = True
        '
        'RB33
        '
        Me.RB33.AutoSize = True
        Me.RB33.Location = New System.Drawing.Point(140, 4)
        Me.RB33.Name = "RB33"
        Me.RB33.Size = New System.Drawing.Size(47, 16)
        Me.RB33.TabIndex = 2
        Me.RB33.Text = "預解"
        Me.RB33.UseVisualStyleBackColor = True
        '
        'B_Whours
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 610)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DGV_IN)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Button_02)
        Me.Controls.Add(Me.Button_01)
        Me.Controls.Add(Me.Floor)
        Me.Controls.Add(Me.Floor_tb)
        Me.Controls.Add(Me.WDate)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Name = "B_Whours"
        Me.Text = "B_Whours"
        CType(Me.DGV_IN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents WDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents Button_01 As System.Windows.Forms.Button
    Friend WithEvents DGV_IN As System.Windows.Forms.DataGridView
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button_02 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RB31 As System.Windows.Forms.RadioButton
    Friend WithEvents RB32 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RB42 As System.Windows.Forms.RadioButton
    Friend WithEvents RB41 As System.Windows.Forms.RadioButton
    Friend WithEvents RB33 As System.Windows.Forms.RadioButton
End Class
