<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 排程顯示V100
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.Floor = New System.Windows.Forms.ComboBox
        Me.Floor_tb = New System.Windows.Forms.Label
        Me.dateDocDate = New System.Windows.Forms.DateTimePicker
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeColumns = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(2, 32)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(882, 652)
        Me.DGV1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(309, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "查詢"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Floor
        '
        Me.Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Floor.Font = New System.Drawing.Font("新細明體", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor.FormattingEnabled = True
        Me.Floor.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.Floor.Location = New System.Drawing.Point(235, 3)
        Me.Floor.Name = "Floor"
        Me.Floor.Size = New System.Drawing.Size(68, 21)
        Me.Floor.TabIndex = 75
        Me.Floor.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(184, 5)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 76
        Me.Floor_tb.Text = "樓層："
        '
        'dateDocDate
        '
        Me.dateDocDate.Location = New System.Drawing.Point(52, 3)
        Me.dateDocDate.Name = "dateDocDate"
        Me.dateDocDate.Size = New System.Drawing.Size(126, 22)
        Me.dateDocDate.TabIndex = 73
        Me.dateDocDate.TabStop = False
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(2, 5)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 74
        Me.dateDocDate_tb.Text = "日期："
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeColumns = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(2, 32)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersVisible = False
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(1318, 652)
        Me.DGV2.TabIndex = 77
        '
        '排程顯示V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1320, 685)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Floor)
        Me.Controls.Add(Me.Floor_tb)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "排程顯示V100"
        Me.Text = "排程顯示"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents dateDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
End Class
