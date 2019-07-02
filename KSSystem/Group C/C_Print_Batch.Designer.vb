<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_Print_Batch
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MDate = New System.Windows.Forms.DateTimePicker
        Me.DDate = New System.Windows.Forms.DateTimePicker
        Me.ckbDDate = New System.Windows.Forms.CheckBox
        Me.ckbMDate = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgvFromExcel = New System.Windows.Forms.DataGridView
        Me.rb01 = New System.Windows.Forms.RadioButton
        Me.rb02 = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB3 = New System.Windows.Forms.RadioButton
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFromExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MDate
        '
        Me.MDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MDate.Location = New System.Drawing.Point(233, 376)
        Me.MDate.Name = "MDate"
        Me.MDate.Size = New System.Drawing.Size(94, 22)
        Me.MDate.TabIndex = 86
        '
        'DDate
        '
        Me.DDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DDate.Location = New System.Drawing.Point(233, 402)
        Me.DDate.Name = "DDate"
        Me.DDate.Size = New System.Drawing.Size(94, 22)
        Me.DDate.TabIndex = 85
        '
        'ckbDDate
        '
        Me.ckbDDate.AutoSize = True
        Me.ckbDDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ckbDDate.Location = New System.Drawing.Point(126, 403)
        Me.ckbDDate.Name = "ckbDDate"
        Me.ckbDDate.Size = New System.Drawing.Size(107, 20)
        Me.ckbDDate.TabIndex = 84
        Me.ckbDDate.Text = "有效日期："
        Me.ckbDDate.UseVisualStyleBackColor = True
        '
        'ckbMDate
        '
        Me.ckbMDate.AutoSize = True
        Me.ckbMDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ckbMDate.Location = New System.Drawing.Point(126, 377)
        Me.ckbMDate.Name = "ckbMDate"
        Me.ckbMDate.Size = New System.Drawing.Size(107, 20)
        Me.ckbMDate.TabIndex = 83
        Me.ckbMDate.Text = "製造日期："
        Me.ckbMDate.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(6, 374)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 26)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Excel欄位分別為：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第一欄：條碼"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(237, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "條碼內容"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 12)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Excel內容"
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSourceMain.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSourceMain.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvSourceMain.Location = New System.Drawing.Point(239, 71)
        Me.dgvSourceMain.MultiSelect = False
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSourceMain.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvSourceMain.RowHeadersVisible = False
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSourceMain.Size = New System.Drawing.Size(333, 300)
        Me.dgvSourceMain.TabIndex = 79
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(492, 413)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 30)
        Me.Button2.TabIndex = 77
        Me.Button2.Text = "列印條碼"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(492, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 30)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "讀取Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvFromExcel
        '
        Me.dgvFromExcel.AllowUserToAddRows = False
        Me.dgvFromExcel.AllowUserToDeleteRows = False
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFromExcel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvFromExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFromExcel.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgvFromExcel.Location = New System.Drawing.Point(9, 71)
        Me.dgvFromExcel.MultiSelect = False
        Me.dgvFromExcel.Name = "dgvFromExcel"
        Me.dgvFromExcel.ReadOnly = True
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFromExcel.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvFromExcel.RowHeadersVisible = False
        Me.dgvFromExcel.RowTemplate.Height = 24
        Me.dgvFromExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFromExcel.Size = New System.Drawing.Size(224, 300)
        Me.dgvFromExcel.TabIndex = 75
        '
        'rb01
        '
        Me.rb01.AutoSize = True
        Me.rb01.Checked = True
        Me.rb01.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rb01.Location = New System.Drawing.Point(7, 7)
        Me.rb01.Name = "rb01"
        Me.rb01.Size = New System.Drawing.Size(90, 20)
        Me.rb01.TabIndex = 87
        Me.rb01.TabStop = True
        Me.rb01.Text = "序號條碼"
        Me.rb01.UseVisualStyleBackColor = True
        '
        'rb02
        '
        Me.rb02.AutoSize = True
        Me.rb02.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rb02.Location = New System.Drawing.Point(97, 7)
        Me.rb02.Name = "rb02"
        Me.rb02.Size = New System.Drawing.Size(90, 20)
        Me.rb02.TabIndex = 88
        Me.rb02.Text = "批號條碼"
        Me.rb02.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rb01)
        Me.Panel1.Controls.Add(Me.rb02)
        Me.Panel1.Location = New System.Drawing.Point(14, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(196, 38)
        Me.Panel1.TabIndex = 89
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Checked = True
        Me.RB1.Location = New System.Drawing.Point(126, 430)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(47, 16)
        Me.RB1.TabIndex = 90
        Me.RB1.TabStop = True
        Me.RB1.Text = "自選"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Location = New System.Drawing.Point(173, 430)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(53, 16)
        Me.RB2.TabIndex = 91
        Me.RB2.Text = "加5天"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB3
        '
        Me.RB3.AutoSize = True
        Me.RB3.Location = New System.Drawing.Point(226, 430)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(53, 16)
        Me.RB3.TabIndex = 92
        Me.RB3.Text = "加6天"
        Me.RB3.UseVisualStyleBackColor = True
        '
        'C_Print_Batch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 455)
        Me.Controls.Add(Me.RB3)
        Me.Controls.Add(Me.RB2)
        Me.Controls.Add(Me.RB1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MDate)
        Me.Controls.Add(Me.DDate)
        Me.Controls.Add(Me.ckbDDate)
        Me.Controls.Add(Me.ckbMDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvFromExcel)
        Me.Name = "C_Print_Batch"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "批次列印條碼"
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFromExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckbDDate As System.Windows.Forms.CheckBox
    Friend WithEvents ckbMDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvFromExcel As System.Windows.Forms.DataGridView
    Friend WithEvents rb01 As System.Windows.Forms.RadioButton
    Friend WithEvents rb02 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB3 As System.Windows.Forms.RadioButton
End Class
