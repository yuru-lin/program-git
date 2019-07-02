<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產排程
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
        Me.Button_01 = New System.Windows.Forms.Button
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.Period = New System.Windows.Forms.ComboBox
        Me.Period_tb = New System.Windows.Forms.Label
        Me.DocDate_tb = New System.Windows.Forms.Label
        Me.Tab = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Floor
        '
        Me.Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Floor.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor.FormattingEnabled = True
        Me.Floor.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.Floor.Location = New System.Drawing.Point(264, 3)
        Me.Floor.Name = "Floor"
        Me.Floor.Size = New System.Drawing.Size(70, 24)
        Me.Floor.TabIndex = 78
        Me.Floor.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(213, 9)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 79
        Me.Floor_tb.Text = "樓層："
        '
        'Button_01
        '
        Me.Button_01.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button_01.Location = New System.Drawing.Point(526, 3)
        Me.Button_01.Name = "Button_01"
        Me.Button_01.Size = New System.Drawing.Size(87, 27)
        Me.Button_01.TabIndex = 74
        Me.Button_01.TabStop = False
        Me.Button_01.Text = "查詢訂單"
        Me.Button_01.UseVisualStyleBackColor = True
        '
        'DocDate
        '
        Me.DocDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDate.Location = New System.Drawing.Point(56, 3)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(155, 27)
        Me.DocDate.TabIndex = 73
        Me.DocDate.TabStop = False
        '
        'Period
        '
        Me.Period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Period.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period.FormattingEnabled = True
        Me.Period.Items.AddRange(New Object() {"06:30", "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "24:00"})
        Me.Period.Location = New System.Drawing.Point(391, 3)
        Me.Period.Name = "Period"
        Me.Period.Size = New System.Drawing.Size(129, 24)
        Me.Period.TabIndex = 76
        Me.Period.TabStop = False
        '
        'Period_tb
        '
        Me.Period_tb.AutoSize = True
        Me.Period_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period_tb.Location = New System.Drawing.Point(340, 9)
        Me.Period_tb.Name = "Period_tb"
        Me.Period_tb.Size = New System.Drawing.Size(56, 16)
        Me.Period_tb.TabIndex = 75
        Me.Period_tb.Text = "時段："
        '
        'DocDate_tb
        '
        Me.DocDate_tb.AutoSize = True
        Me.DocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDate_tb.Location = New System.Drawing.Point(3, 9)
        Me.DocDate_tb.Name = "DocDate_tb"
        Me.DocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.DocDate_tb.TabIndex = 77
        Me.DocDate_tb.Text = "日期："
        '
        'Tab
        '
        Me.Tab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab.Controls.Add(Me.TabPage1)
        Me.Tab.Controls.Add(Me.TabPage2)
        Me.Tab.Controls.Add(Me.TabPage3)
        Me.Tab.Controls.Add(Me.TabPage4)
        Me.Tab.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Tab.Location = New System.Drawing.Point(-1, 36)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(966, 628)
        Me.Tab.TabIndex = 80
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(958, 595)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "生產排程"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(958, 595)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "生產領料"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(7, 69)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(327, 386)
        Me.DGV1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(958, 595)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "領料總表"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(958, 595)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "排程總表"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(337, 4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(615, 386)
        Me.DataGridView1.TabIndex = 81
        '
        '生產排程
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 662)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Tab)
        Me.Controls.Add(Me.Floor)
        Me.Controls.Add(Me.Floor_tb)
        Me.Controls.Add(Me.Button_01)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Period)
        Me.Controls.Add(Me.Period_tb)
        Me.Controls.Add(Me.DocDate_tb)
        Me.Name = "生產排程"
        Me.Text = "現場生產排程"
        Me.Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents Button_01 As System.Windows.Forms.Button
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Period As System.Windows.Forms.ComboBox
    Friend WithEvents Period_tb As System.Windows.Forms.Label
    Friend WithEvents DocDate_tb As System.Windows.Forms.Label
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
