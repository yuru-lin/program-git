<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001發票作廢作業
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.查詢 = New System.Windows.Forms.Button
        Me.起始日 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DocNum = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.未上傳 = New System.Windows.Forms.RadioButton
        Me.已上傳 = New System.Windows.Forms.RadioButton
        Me.上傳 = New System.Windows.Forms.Button
        Me.重新上傳 = New System.Windows.Forms.Button
        Me.修改為已上傳 = New System.Windows.Forms.Button
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.結束日 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.全選 = New System.Windows.Forms.Button
        Me.取消 = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(445, 12)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(100, 56)
        Me.查詢.TabIndex = 5
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        '起始日
        '
        Me.起始日.CalendarFont = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.起始日.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.起始日.Location = New System.Drawing.Point(86, 16)
        Me.起始日.Name = "起始日"
        Me.起始日.Size = New System.Drawing.Size(155, 27)
        Me.起始日.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "日期："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV1.Location = New System.Drawing.Point(21, 88)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(971, 289)
        Me.DGV1.TabIndex = 17
        '
        'DocNum
        '
        Me.DocNum.AutoSize = True
        Me.DocNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocNum.ForeColor = System.Drawing.Color.Red
        Me.DocNum.Location = New System.Drawing.Point(103, 68)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.Size = New System.Drawing.Size(40, 16)
        Me.DocNum.TabIndex = 16
        Me.DocNum.Text = "單號"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "草稿單號："
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV2.Location = New System.Drawing.Point(22, 415)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(970, 278)
        Me.DGV2.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 393)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "明細"
        '
        '未上傳
        '
        Me.未上傳.AutoSize = True
        Me.未上傳.Checked = True
        Me.未上傳.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.未上傳.Location = New System.Drawing.Point(554, 17)
        Me.未上傳.Name = "未上傳"
        Me.未上傳.Size = New System.Drawing.Size(84, 23)
        Me.未上傳.TabIndex = 21
        Me.未上傳.TabStop = True
        Me.未上傳.Text = "未上傳"
        Me.未上傳.UseVisualStyleBackColor = True
        '
        '已上傳
        '
        Me.已上傳.AutoSize = True
        Me.已上傳.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.已上傳.Location = New System.Drawing.Point(554, 41)
        Me.已上傳.Name = "已上傳"
        Me.已上傳.Size = New System.Drawing.Size(84, 23)
        Me.已上傳.TabIndex = 20
        Me.已上傳.Text = "已上傳"
        Me.已上傳.UseVisualStyleBackColor = True
        '
        '上傳
        '
        Me.上傳.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.上傳.Location = New System.Drawing.Point(673, 12)
        Me.上傳.Name = "上傳"
        Me.上傳.Size = New System.Drawing.Size(98, 56)
        Me.上傳.TabIndex = 22
        Me.上傳.Text = "上傳"
        Me.上傳.UseVisualStyleBackColor = True
        '
        '重新上傳
        '
        Me.重新上傳.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.重新上傳.Location = New System.Drawing.Point(891, 12)
        Me.重新上傳.Name = "重新上傳"
        Me.重新上傳.Size = New System.Drawing.Size(98, 56)
        Me.重新上傳.TabIndex = 23
        Me.重新上傳.Text = "重新上傳"
        Me.重新上傳.UseVisualStyleBackColor = True
        '
        '修改為已上傳
        '
        Me.修改為已上傳.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.修改為已上傳.Location = New System.Drawing.Point(782, 12)
        Me.修改為已上傳.Name = "修改為已上傳"
        Me.修改為已上傳.Size = New System.Drawing.Size(98, 56)
        Me.修改為已上傳.TabIndex = 263
        Me.修改為已上傳.Text = "修改為  已上傳"
        Me.修改為已上傳.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        '結束日
        '
        Me.結束日.CalendarFont = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.結束日.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.結束日.Location = New System.Drawing.Point(278, 16)
        Me.結束日.Name = "結束日"
        Me.結束日.Size = New System.Drawing.Size(155, 27)
        Me.結束日.TabIndex = 264
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(244, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 21)
        Me.Label2.TabIndex = 265
        Me.Label2.Text = "至"
        '
        '全選
        '
        Me.全選.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.全選.Location = New System.Drawing.Point(181, 50)
        Me.全選.Name = "全選"
        Me.全選.Size = New System.Drawing.Size(60, 34)
        Me.全選.TabIndex = 266
        Me.全選.Text = "全選"
        Me.全選.UseVisualStyleBackColor = True
        '
        '取消
        '
        Me.取消.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.取消.Location = New System.Drawing.Point(248, 50)
        Me.取消.Name = "取消"
        Me.取消.Size = New System.Drawing.Size(60, 34)
        Me.取消.TabIndex = 267
        Me.取消.Text = "取消"
        Me.取消.UseVisualStyleBackColor = True
        '
        'v001發票作廢作業
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 714)
        Me.Controls.Add(Me.取消)
        Me.Controls.Add(Me.全選)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.結束日)
        Me.Controls.Add(Me.修改為已上傳)
        Me.Controls.Add(Me.重新上傳)
        Me.Controls.Add(Me.上傳)
        Me.Controls.Add(Me.未上傳)
        Me.Controls.Add(Me.已上傳)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.DocNum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.起始日)
        Me.Controls.Add(Me.Label1)
        Me.Name = "v001發票作廢作業"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "發票作廢作業"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents 起始日 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DocNum As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 未上傳 As System.Windows.Forms.RadioButton
    Friend WithEvents 已上傳 As System.Windows.Forms.RadioButton
    Friend WithEvents 上傳 As System.Windows.Forms.Button
    Friend WithEvents 重新上傳 As System.Windows.Forms.Button
    Friend WithEvents 修改為已上傳 As System.Windows.Forms.Button
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents 結束日 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 全選 As System.Windows.Forms.Button
    Friend WithEvents 取消 As System.Windows.Forms.Button
End Class
