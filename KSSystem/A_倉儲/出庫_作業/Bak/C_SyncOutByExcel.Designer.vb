<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_SyncOutByExcel
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
        Me.toExcBtn = New System.Windows.Forms.Button
        Me.ChkBox1 = New System.Windows.Forms.CheckBox
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.DataGridView4 = New System.Windows.Forms.DataGridView
        Me.DataGridView3 = New System.Windows.Forms.DataGridView
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DrfNum = New System.Windows.Forms.TextBox
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.cobSelectType = New System.Windows.Forms.ComboBox
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.DGV5 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toExcBtn
        '
        Me.toExcBtn.Location = New System.Drawing.Point(821, 493)
        Me.toExcBtn.Name = "toExcBtn"
        Me.toExcBtn.Size = New System.Drawing.Size(87, 35)
        Me.toExcBtn.TabIndex = 115
        Me.toExcBtn.Text = "匯出Excel"
        Me.toExcBtn.UseVisualStyleBackColor = True
        '
        'ChkBox1
        '
        Me.ChkBox1.AutoSize = True
        Me.ChkBox1.Location = New System.Drawing.Point(181, 508)
        Me.ChkBox1.Name = "ChkBox1"
        Me.ChkBox1.Size = New System.Drawing.Size(104, 16)
        Me.ChkBox1.TabIndex = 114
        Me.ChkBox1.Text = "寄庫品條碼加A"
        Me.ChkBox1.UseVisualStyleBackColor = True
        Me.ChkBox1.Visible = False
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(178, 530)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(730, 23)
        Me.PBar1.TabIndex = 113
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(711, 189)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 16)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "被出庫或數量不足"
        Me.Label13.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(711, 322)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "未入庫"
        Me.Label12.Visible = False
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Location = New System.Drawing.Point(714, 341)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.RowHeadersVisible = False
        Me.DataGridView4.RowTemplate.Height = 24
        Me.DataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView4.Size = New System.Drawing.Size(191, 114)
        Me.DataGridView4.TabIndex = 110
        Me.DataGridView4.Visible = False
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(714, 208)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.RowTemplate.Height = 24
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView3.Size = New System.Drawing.Size(190, 111)
        Me.DataGridView3.TabIndex = 109
        Me.DataGridView3.Visible = False
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(714, 153)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 35)
        Me.Button5.TabIndex = 108
        Me.Button5.Text = "分析錯誤條碼"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(818, 153)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 35)
        Me.Button4.TabIndex = 107
        Me.Button4.Text = "錯誤條碼匯出"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(711, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "錯誤條碼"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(714, 39)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView2.Size = New System.Drawing.Size(191, 108)
        Me.DataGridView2.TabIndex = 105
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(179, 493)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(175, 12)
        Me.Label11.TabIndex = 99
        Me.Label11.Text = "Excel欄位分別為：第一欄：條碼"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(885, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 16)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "項"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(626, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "項目數"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(862, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "共"
        Me.Label10.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(442, 499)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "草稿單號："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(392, 499)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "請輸入"
        '
        'DrfNum
        '
        Me.DrfNum.Location = New System.Drawing.Point(526, 497)
        Me.DrfNum.Name = "DrfNum"
        Me.DrfNum.Size = New System.Drawing.Size(100, 22)
        Me.DrfNum.TabIndex = 93
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(178, 39)
        Me.dgvSourceMain.MultiSelect = False
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowHeadersVisible = False
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.Size = New System.Drawing.Size(530, 448)
        Me.dgvSourceMain.TabIndex = 92
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(728, 493)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 35)
        Me.Button2.TabIndex = 89
        Me.Button2.Text = "同步至伺服器"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(638, 493)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 35)
        Me.Button1.TabIndex = 88
        Me.Button1.Text = "讀取Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(2, 30)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(170, 286)
        Me.DataGridView1.TabIndex = 87
        Me.DataGridView1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cobSelectType)
        Me.Panel1.Controls.Add(Me.RB2)
        Me.Panel1.Controls.Add(Me.RB1)
        Me.Panel1.Location = New System.Drawing.Point(148, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(352, 30)
        Me.Panel1.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(135, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "出庫類型："
        '
        'cobSelectType
        '
        Me.cobSelectType.FormattingEnabled = True
        Me.cobSelectType.Items.AddRange(New Object() {"領料出庫", "銷售出庫", "存貨領用", "寄庫品出庫", "委外代工出庫"})
        Me.cobSelectType.Location = New System.Drawing.Point(223, 3)
        Me.cobSelectType.Name = "cobSelectType"
        Me.cobSelectType.Size = New System.Drawing.Size(121, 20)
        Me.cobSelectType.TabIndex = 2
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB2.Location = New System.Drawing.Point(70, 3)
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
        Me.RB1.Location = New System.Drawing.Point(4, 3)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(58, 20)
        Me.RB1.TabIndex = 0
        Me.RB1.TabStop = True
        Me.RB1.Text = "電宰"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'DGV5
        '
        Me.DGV5.AllowUserToAddRows = False
        Me.DGV5.AllowUserToDeleteRows = False
        Me.DGV5.AllowUserToResizeRows = False
        Me.DGV5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV5.Location = New System.Drawing.Point(2, 39)
        Me.DGV5.MultiSelect = False
        Me.DGV5.Name = "DGV5"
        Me.DGV5.ReadOnly = True
        Me.DGV5.RowHeadersVisible = False
        Me.DGV5.RowTemplate.Height = 24
        Me.DGV5.Size = New System.Drawing.Size(170, 514)
        Me.DGV5.TabIndex = 117
        '
        'C_SyncOutByExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 562)
        Me.Controls.Add(Me.DrfNum)
        Me.Controls.Add(Me.DGV5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.toExcBtn)
        Me.Controls.Add(Me.ChkBox1)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DataGridView4)
        Me.Controls.Add(Me.DataGridView3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "C_SyncOutByExcel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel出庫同步"
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toExcBtn As System.Windows.Forms.Button
    Friend WithEvents ChkBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DrfNum As System.Windows.Forms.TextBox
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cobSelectType As System.Windows.Forms.ComboBox
    Friend WithEvents DGV5 As System.Windows.Forms.DataGridView
End Class
