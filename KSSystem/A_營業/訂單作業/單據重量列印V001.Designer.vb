<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 單據重量列印V001
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
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.Bu列印 = New System.Windows.Forms.Button
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.DGV4 = New System.Windows.Forms.DataGridView
        Me.草稿 = New System.Windows.Forms.Label
        Me.差異 = New System.Windows.Forms.Label
        Me.Lt客戶 = New System.Windows.Forms.Label
        Me.Lt編號 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Lt日期 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV1.Location = New System.Drawing.Point(6, 45)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(230, 608)
        Me.DGV1.TabIndex = 81
        Me.DGV1.TabStop = False
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV2.Location = New System.Drawing.Point(242, 424)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(737, 229)
        Me.DGV2.TabIndex = 82
        Me.DGV2.TabStop = False
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(6, 2)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(84, 37)
        Me.Bu查詢.TabIndex = 84
        Me.Bu查詢.TabStop = False
        Me.Bu查詢.Text = "查詢"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        '日期
        '
        Me.日期.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(344, 3)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(175, 33)
        Me.日期.TabIndex = 83
        Me.日期.TabStop = False
        Me.日期.Visible = False
        '
        'Bu列印
        '
        Me.Bu列印.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bu列印.Enabled = False
        Me.Bu列印.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu列印.Location = New System.Drawing.Point(888, 2)
        Me.Bu列印.Name = "Bu列印"
        Me.Bu列印.Size = New System.Drawing.Size(84, 37)
        Me.Bu列印.TabIndex = 1026
        Me.Bu列印.Text = "列印"
        Me.Bu列印.UseVisualStyleBackColor = False
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(525, 7)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(357, 29)
        Me.Cb1印表機.TabIndex = 1033
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.AllowUserToResizeRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV3.Location = New System.Drawing.Point(242, 45)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowHeadersWidth = 25
        Me.DGV3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV3.Size = New System.Drawing.Size(549, 373)
        Me.DGV3.TabIndex = 1034
        Me.DGV3.TabStop = False
        '
        'DGV4
        '
        Me.DGV4.AllowUserToAddRows = False
        Me.DGV4.AllowUserToDeleteRows = False
        Me.DGV4.AllowUserToResizeRows = False
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV4.Location = New System.Drawing.Point(797, 45)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.ReadOnly = True
        Me.DGV4.RowHeadersWidth = 25
        Me.DGV4.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV4.RowTemplate.Height = 24
        Me.DGV4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV4.Size = New System.Drawing.Size(182, 373)
        Me.DGV4.TabIndex = 1035
        Me.DGV4.TabStop = False
        '
        '草稿
        '
        Me.草稿.AutoSize = True
        Me.草稿.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.草稿.Location = New System.Drawing.Point(96, 9)
        Me.草稿.Name = "草稿"
        Me.草稿.Size = New System.Drawing.Size(0, 24)
        Me.草稿.TabIndex = 1036
        '
        '差異
        '
        Me.差異.AutoSize = True
        Me.差異.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.差異.Location = New System.Drawing.Point(182, 9)
        Me.差異.Name = "差異"
        Me.差異.Size = New System.Drawing.Size(79, 24)
        Me.差異.TabIndex = 1037
        Me.差異.Text = "差異:0"
        '
        'Lt客戶
        '
        Me.Lt客戶.AutoSize = True
        Me.Lt客戶.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt客戶.Location = New System.Drawing.Point(6, 18)
        Me.Lt客戶.Name = "Lt客戶"
        Me.Lt客戶.Size = New System.Drawing.Size(60, 24)
        Me.Lt客戶.TabIndex = 1038
        Me.Lt客戶.Text = "客戶"
        '
        'Lt編號
        '
        Me.Lt編號.AutoSize = True
        Me.Lt編號.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt編號.Location = New System.Drawing.Point(6, 42)
        Me.Lt編號.Name = "Lt編號"
        Me.Lt編號.Size = New System.Drawing.Size(60, 24)
        Me.Lt編號.TabIndex = 1039
        Me.Lt編號.Text = "編號"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lt日期)
        Me.GroupBox1.Controls.Add(Me.Lt客戶)
        Me.GroupBox1.Controls.Add(Me.Lt編號)
        Me.GroupBox1.Location = New System.Drawing.Point(325, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 201)
        Me.GroupBox1.TabIndex = 1040
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'Lt日期
        '
        Me.Lt日期.AutoSize = True
        Me.Lt日期.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt日期.Location = New System.Drawing.Point(6, 66)
        Me.Lt日期.Name = "Lt日期"
        Me.Lt日期.Size = New System.Drawing.Size(60, 24)
        Me.Lt日期.TabIndex = 1040
        Me.Lt日期.Text = "日期"
        '
        '單據重量列印V001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 657)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.差異)
        Me.Controls.Add(Me.草稿)
        Me.Controls.Add(Me.DGV4)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.Cb1印表機)
        Me.Controls.Add(Me.Bu列印)
        Me.Controls.Add(Me.Bu查詢)
        Me.Controls.Add(Me.日期)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "單據重量列印V001"
        Me.Text = "單據重量列印"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Bu列印 As System.Windows.Forms.Button
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents 草稿 As System.Windows.Forms.Label
    Friend WithEvents 差異 As System.Windows.Forms.Label
    Friend WithEvents Lt客戶 As System.Windows.Forms.Label
    Friend WithEvents Lt編號 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Lt日期 As System.Windows.Forms.Label
End Class
