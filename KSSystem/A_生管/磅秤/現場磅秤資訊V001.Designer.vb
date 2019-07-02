<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 現場磅秤資訊V001
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.樓層 = New System.Windows.Forms.ComboBox
        Me.時段 = New System.Windows.Forms.ComboBox
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.Period_tb = New System.Windows.Forms.Label
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.Floor_tb = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.DGV4 = New System.Windows.Forms.DataGridView
        Me.即時時間 = New System.Windows.Forms.Timer(Me.components)
        Me.電腦時間 = New System.Windows.Forms.Label
        Me.目前時段 = New System.Windows.Forms.Label
        Me.下個時段 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Bu查詢)
        Me.GroupBox1.Controls.Add(Me.樓層)
        Me.GroupBox1.Controls.Add(Me.時段)
        Me.GroupBox1.Controls.Add(Me.日期)
        Me.GroupBox1.Controls.Add(Me.Period_tb)
        Me.GroupBox1.Controls.Add(Me.dateDocDate_tb)
        Me.GroupBox1.Controls.Add(Me.Floor_tb)
        Me.GroupBox1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(584, 331)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "參數"
        Me.GroupBox1.Visible = False
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(212, 19)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.Bu查詢.TabIndex = 81
        Me.Bu查詢.TabStop = False
        Me.Bu查詢.Text = "查詢"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        '樓層
        '
        Me.樓層.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.樓層.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.樓層.FormattingEnabled = True
        Me.樓層.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.樓層.Location = New System.Drawing.Point(56, 55)
        Me.樓層.Name = "樓層"
        Me.樓層.Size = New System.Drawing.Size(150, 27)
        Me.樓層.TabIndex = 84
        Me.樓層.TabStop = False
        Me.樓層.Visible = False
        '
        '時段
        '
        Me.時段.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.時段.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.時段.FormattingEnabled = True
        Me.時段.Items.AddRange(New Object() {"06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "24:00"})
        Me.時段.Location = New System.Drawing.Point(56, 88)
        Me.時段.Name = "時段"
        Me.時段.Size = New System.Drawing.Size(150, 27)
        Me.時段.TabIndex = 82
        Me.時段.TabStop = False
        '
        '日期
        '
        Me.日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(56, 22)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(150, 27)
        Me.日期.TabIndex = 80
        Me.日期.TabStop = False
        '
        'Period_tb
        '
        Me.Period_tb.AutoSize = True
        Me.Period_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period_tb.Location = New System.Drawing.Point(5, 93)
        Me.Period_tb.Name = "Period_tb"
        Me.Period_tb.Size = New System.Drawing.Size(56, 16)
        Me.Period_tb.TabIndex = 86
        Me.Period_tb.Text = "時段："
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(6, 26)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 83
        Me.dateDocDate_tb.Text = "日期："
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(5, 58)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 85
        Me.Floor_tb.Text = "樓層："
        Me.Floor_tb.Visible = False
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV3.ColumnHeadersHeight = 36
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("細明體", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV3.Location = New System.Drawing.Point(0, 45)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV3.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV3.RowHeadersWidth = 25
        Me.DGV3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(1562, 430)
        Me.DGV3.TabIndex = 82
        Me.DGV3.TabStop = False
        '
        'DGV4
        '
        Me.DGV4.AllowUserToAddRows = False
        Me.DGV4.AllowUserToDeleteRows = False
        Me.DGV4.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV4.ColumnHeadersHeight = 36
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("細明體", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DGV4.Location = New System.Drawing.Point(0, 519)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV4.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DGV4.RowHeadersWidth = 25
        Me.DGV4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV4.RowTemplate.Height = 24
        Me.DGV4.Size = New System.Drawing.Size(1562, 327)
        Me.DGV4.TabIndex = 83
        Me.DGV4.TabStop = False
        '
        '即時時間
        '
        '
        '電腦時間
        '
        Me.電腦時間.AutoSize = True
        Me.電腦時間.Font = New System.Drawing.Font("新細明體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.電腦時間.ForeColor = System.Drawing.Color.Red
        Me.電腦時間.Location = New System.Drawing.Point(944, 9)
        Me.電腦時間.Name = "電腦時間"
        Me.電腦時間.Size = New System.Drawing.Size(147, 32)
        Me.電腦時間.TabIndex = 84
        Me.電腦時間.Text = "電腦時間"
        '
        '目前時段
        '
        Me.目前時段.AutoSize = True
        Me.目前時段.Font = New System.Drawing.Font("新細明體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.目前時段.ForeColor = System.Drawing.Color.Red
        Me.目前時段.Location = New System.Drawing.Point(3, 10)
        Me.目前時段.Name = "目前時段"
        Me.目前時段.Size = New System.Drawing.Size(180, 32)
        Me.目前時段.TabIndex = 85
        Me.目前時段.Text = "目前時段："
        '
        '下個時段
        '
        Me.下個時段.AutoSize = True
        Me.下個時段.Font = New System.Drawing.Font("新細明體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.下個時段.ForeColor = System.Drawing.Color.Red
        Me.下個時段.Location = New System.Drawing.Point(3, 484)
        Me.下個時段.Name = "下個時段"
        Me.下個時段.Size = New System.Drawing.Size(180, 32)
        Me.下個時段.TabIndex = 86
        Me.下個時段.Text = "下個時段："
        '
        '現場磅秤資訊V001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1574, 847)
        Me.Controls.Add(Me.下個時段)
        Me.Controls.Add(Me.目前時段)
        Me.Controls.Add(Me.電腦時間)
        Me.Controls.Add(Me.DGV4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGV3)
        Me.Name = "現場磅秤資訊V001"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "現場磅秤資訊V001"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents 樓層 As System.Windows.Forms.ComboBox
    Friend WithEvents 時段 As System.Windows.Forms.ComboBox
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Period_tb As System.Windows.Forms.Label
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents 即時時間 As System.Windows.Forms.Timer
    Friend WithEvents 電腦時間 As System.Windows.Forms.Label
    Friend WithEvents 目前時段 As System.Windows.Forms.Label
    Friend WithEvents 下個時段 As System.Windows.Forms.Label
End Class
