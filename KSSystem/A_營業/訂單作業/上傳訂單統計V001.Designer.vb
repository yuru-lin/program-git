<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 上傳訂單統計V001
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.D7日期2 = New System.Windows.Forms.DateTimePicker
        Me.D7日期1 = New System.Windows.Forms.DateTimePicker
        Me.DGV7 = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.Bu7匯出 = New System.Windows.Forms.Button
        CType(Me.DGV7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(374, 5)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.Bu查詢.TabIndex = 279
        Me.Bu查詢.TabStop = False
        Me.Bu查詢.Text = "查詢"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        'D7日期2
        '
        Me.D7日期2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.D7日期2.Location = New System.Drawing.Point(218, 5)
        Me.D7日期2.Name = "D7日期2"
        Me.D7日期2.Size = New System.Drawing.Size(150, 27)
        Me.D7日期2.TabIndex = 281
        Me.D7日期2.TabStop = False
        '
        'D7日期1
        '
        Me.D7日期1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.D7日期1.Location = New System.Drawing.Point(62, 5)
        Me.D7日期1.Name = "D7日期1"
        Me.D7日期1.Size = New System.Drawing.Size(150, 27)
        Me.D7日期1.TabIndex = 278
        Me.D7日期1.TabStop = False
        '
        'DGV7
        '
        Me.DGV7.AllowUserToAddRows = False
        Me.DGV7.AllowUserToDeleteRows = False
        Me.DGV7.AllowUserToResizeRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV7.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGV7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV7.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGV7.Location = New System.Drawing.Point(8, 36)
        Me.DGV7.Name = "DGV7"
        Me.DGV7.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV7.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGV7.RowHeadersWidth = 25
        Me.DGV7.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV7.RowTemplate.Height = 24
        Me.DGV7.Size = New System.Drawing.Size(964, 607)
        Me.DGV7.TabIndex = 277
        Me.DGV7.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "日期："
        '
        'Bu7匯出
        '
        Me.Bu7匯出.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu7匯出.Location = New System.Drawing.Point(877, 2)
        Me.Bu7匯出.Name = "Bu7匯出"
        Me.Bu7匯出.Size = New System.Drawing.Size(95, 30)
        Me.Bu7匯出.TabIndex = 282
        Me.Bu7匯出.Text = "匯出Excel"
        Me.Bu7匯出.UseVisualStyleBackColor = True
        '
        '上傳訂單統計V001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 647)
        Me.Controls.Add(Me.Bu7匯出)
        Me.Controls.Add(Me.Bu查詢)
        Me.Controls.Add(Me.D7日期2)
        Me.Controls.Add(Me.D7日期1)
        Me.Controls.Add(Me.DGV7)
        Me.Controls.Add(Me.Label4)
        Me.Name = "上傳訂單統計V001"
        Me.Text = "上傳訂單統計"
        CType(Me.DGV7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents D7日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents D7日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGV7 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Bu7匯出 As System.Windows.Forms.Button
End Class
