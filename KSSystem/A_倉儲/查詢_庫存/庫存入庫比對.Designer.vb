<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QuerySRNNotInB1Yet
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.補製單 = New System.Windows.Forms.ComboBox
        Me.查詢補製單 = New System.Windows.Forms.CheckBox
        Me.冷凍冷藏 = New System.Windows.Forms.ComboBox
        Me.查詢冷凍冷藏 = New System.Windows.Forms.CheckBox
        Me.顯示代工製單 = New System.Windows.Forms.CheckBox
        Me.品名 = New System.Windows.Forms.TextBox
        Me.查詢品名 = New System.Windows.Forms.CheckBox
        Me.btnsearch = New System.Windows.Forms.Button
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvSourceMain2 = New System.Windows.Forms.DataGridView
        Me.Date1 = New System.Windows.Forms.DateTimePicker
        Me.Date2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.品項總數 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSourceMain2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(598, 574)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 21)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "項"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(536, 574)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 21)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(409, 574)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(130, 21)
        Me.Label9.TabIndex = 89
        Me.Label9.Text = "差異數量   共"
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(3, 132)
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.Size = New System.Drawing.Size(877, 436)
        Me.dgvSourceMain.TabIndex = 85
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(805, 59)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 170
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.補製單)
        Me.Panel1.Controls.Add(Me.查詢補製單)
        Me.Panel1.Controls.Add(Me.冷凍冷藏)
        Me.Panel1.Controls.Add(Me.查詢冷凍冷藏)
        Me.Panel1.Controls.Add(Me.顯示代工製單)
        Me.Panel1.Controls.Add(Me.品名)
        Me.Panel1.Controls.Add(Me.查詢品名)
        Me.Panel1.Controls.Add(Me.btnsearch)
        Me.Panel1.Controls.Add(Me.RB2)
        Me.Panel1.Controls.Add(Me.RB1)
        Me.Panel1.Location = New System.Drawing.Point(12, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(544, 85)
        Me.Panel1.TabIndex = 171
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(124, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "(品名)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(407, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "(補製單)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(252, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 187
        Me.Label2.Text = "(冷凍冷藏)"
        '
        '補製單
        '
        Me.補製單.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.補製單.FormattingEnabled = True
        Me.補製單.Items.AddRange(New Object() {"N", "Y"})
        Me.補製單.Location = New System.Drawing.Point(350, 31)
        Me.補製單.Name = "補製單"
        Me.補製單.Size = New System.Drawing.Size(57, 21)
        Me.補製單.TabIndex = 186
        '
        '查詢補製單
        '
        Me.查詢補製單.AutoSize = True
        Me.查詢補製單.Location = New System.Drawing.Point(331, 35)
        Me.查詢補製單.Name = "查詢補製單"
        Me.查詢補製單.Size = New System.Drawing.Size(15, 14)
        Me.查詢補製單.TabIndex = 185
        Me.查詢補製單.UseVisualStyleBackColor = True
        '
        '冷凍冷藏
        '
        Me.冷凍冷藏.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.冷凍冷藏.FormattingEnabled = True
        Me.冷凍冷藏.Items.AddRange(New Object() {"1", "2"})
        Me.冷凍冷藏.Location = New System.Drawing.Point(195, 31)
        Me.冷凍冷藏.Name = "冷凍冷藏"
        Me.冷凍冷藏.Size = New System.Drawing.Size(57, 21)
        Me.冷凍冷藏.TabIndex = 184
        '
        '查詢冷凍冷藏
        '
        Me.查詢冷凍冷藏.AutoSize = True
        Me.查詢冷凍冷藏.Location = New System.Drawing.Point(176, 35)
        Me.查詢冷凍冷藏.Name = "查詢冷凍冷藏"
        Me.查詢冷凍冷藏.Size = New System.Drawing.Size(15, 14)
        Me.查詢冷凍冷藏.TabIndex = 183
        Me.查詢冷凍冷藏.UseVisualStyleBackColor = True
        '
        '顯示代工製單
        '
        Me.顯示代工製單.AutoSize = True
        Me.顯示代工製單.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.顯示代工製單.Location = New System.Drawing.Point(3, 59)
        Me.顯示代工製單.Name = "顯示代工製單"
        Me.顯示代工製單.Size = New System.Drawing.Size(155, 20)
        Me.顯示代工製單.TabIndex = 182
        Me.顯示代工製單.Text = "是否顯示代工製單"
        Me.顯示代工製單.UseVisualStyleBackColor = True
        Me.顯示代工製單.Visible = False
        '
        '品名
        '
        Me.品名.Location = New System.Drawing.Point(24, 31)
        Me.品名.Name = "品名"
        Me.品名.Size = New System.Drawing.Size(100, 22)
        Me.品名.TabIndex = 181
        '
        '查詢品名
        '
        Me.查詢品名.AutoSize = True
        Me.查詢品名.Location = New System.Drawing.Point(3, 35)
        Me.查詢品名.Name = "查詢品名"
        Me.查詢品名.Size = New System.Drawing.Size(15, 14)
        Me.查詢品名.TabIndex = 180
        Me.查詢品名.UseVisualStyleBackColor = True
        '
        'btnsearch
        '
        Me.btnsearch.Location = New System.Drawing.Point(461, 6)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 23)
        Me.btnsearch.TabIndex = 49
        Me.btnsearch.Text = "查詢"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB2.Location = New System.Drawing.Point(69, 9)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(58, 20)
        Me.RB2.TabIndex = 1
        Me.RB2.Text = "加工"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB1.Location = New System.Drawing.Point(3, 9)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(58, 20)
        Me.RB1.TabIndex = 0
        Me.RB1.TabStop = True
        Me.RB1.Text = "電宰"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(218, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "至"
        '
        'dgvSourceMain2
        '
        Me.dgvSourceMain2.AllowUserToAddRows = False
        Me.dgvSourceMain2.AllowUserToDeleteRows = False
        Me.dgvSourceMain2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain2.Location = New System.Drawing.Point(3, 574)
        Me.dgvSourceMain2.Name = "dgvSourceMain2"
        Me.dgvSourceMain2.ReadOnly = True
        Me.dgvSourceMain2.RowTemplate.Height = 24
        Me.dgvSourceMain2.Size = New System.Drawing.Size(400, 78)
        Me.dgvSourceMain2.TabIndex = 176
        '
        'Date1
        '
        Me.Date1.Location = New System.Drawing.Point(87, 6)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(125, 22)
        Me.Date1.TabIndex = 177
        '
        'Date2
        '
        Me.Date2.Location = New System.Drawing.Point(248, 7)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(136, 22)
        Me.Date2.TabIndex = 178
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "開始日期"
        '
        '品項總數
        '
        Me.品項總數.AutoSize = True
        Me.品項總數.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.品項總數.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.品項總數.Location = New System.Drawing.Point(809, 574)
        Me.品項總數.Name = "品項總數"
        Me.品項總數.Size = New System.Drawing.Size(31, 21)
        Me.品項總數.TabIndex = 180
        Me.品項總數.Text = "０"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(699, 574)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 21)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "品項總數："
        '
        'C_QuerySRNNotInB1Yet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 661)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.品項總數)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.dgvSourceMain2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Name = "C_QuerySRNNotInB1Yet"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "未入庫明細"
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSourceMain2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvSourceMain2 As System.Windows.Forms.DataGridView
    Friend WithEvents Date1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 品名 As System.Windows.Forms.TextBox
    Friend WithEvents 查詢品名 As System.Windows.Forms.CheckBox
    Friend WithEvents 顯示代工製單 As System.Windows.Forms.CheckBox
    Friend WithEvents 查詢冷凍冷藏 As System.Windows.Forms.CheckBox
    Friend WithEvents 冷凍冷藏 As System.Windows.Forms.ComboBox
    Friend WithEvents 補製單 As System.Windows.Forms.ComboBox
    Friend WithEvents 查詢補製單 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 品項總數 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
