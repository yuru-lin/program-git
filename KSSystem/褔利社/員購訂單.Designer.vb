<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 員購訂單
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
        Me.AddItemBtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.員工編號 = New System.Windows.Forms.TextBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.員工姓名 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.條碼 = New System.Windows.Forms.TextBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.SaveBtn = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AddItemBtn
        '
        Me.AddItemBtn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.AddItemBtn.Location = New System.Drawing.Point(272, 40)
        Me.AddItemBtn.Name = "AddItemBtn"
        Me.AddItemBtn.Size = New System.Drawing.Size(132, 29)
        Me.AddItemBtn.TabIndex = 40
        Me.AddItemBtn.Text = "新增項目"
        Me.AddItemBtn.UseVisualStyleBackColor = True
        Me.AddItemBtn.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(410, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 19)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "員工編號："
        '
        '員工編號
        '
        Me.員工編號.BackColor = System.Drawing.SystemColors.Window
        Me.員工編號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.員工編號.Location = New System.Drawing.Point(508, 9)
        Me.員工編號.Name = "員工編號"
        Me.員工編號.Size = New System.Drawing.Size(183, 27)
        Me.員工編號.TabIndex = 1
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 107)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(965, 530)
        Me.DGV1.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(694, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 19)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "員工姓名："
        '
        '員工姓名
        '
        Me.員工姓名.Enabled = False
        Me.員工姓名.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.員工姓名.Location = New System.Drawing.Point(794, 9)
        Me.員工姓名.Name = "員工姓名"
        Me.員工姓名.Size = New System.Drawing.Size(183, 27)
        Me.員工姓名.TabIndex = 45
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(272, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 29)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "查詢"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(410, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 19)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "輸入條碼："
        '
        '條碼
        '
        Me.條碼.BackColor = System.Drawing.SystemColors.Window
        Me.條碼.Enabled = False
        Me.條碼.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.條碼.Location = New System.Drawing.Point(508, 42)
        Me.條碼.Name = "條碼"
        Me.條碼.Size = New System.Drawing.Size(183, 27)
        Me.條碼.TabIndex = 49
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(12, 8)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(163, 27)
        Me.DateTimePicker1.TabIndex = 51
        '
        'SaveBtn
        '
        Me.SaveBtn.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(878, 41)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(99, 60)
        Me.SaveBtn.TabIndex = 25
        Me.SaveBtn.Text = "下單"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        '員購訂單
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 649)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.條碼)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.員工姓名)
        Me.Controls.Add(Me.員工編號)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.AddItemBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "員購訂單"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速訂單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AddItemBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 員工編號 As System.Windows.Forms.TextBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 員工姓名 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents 條碼 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
End Class
