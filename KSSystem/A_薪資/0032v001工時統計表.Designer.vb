<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 工時統計表v001
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
        Me.dt統計日期1 = New System.Windows.Forms.DateTimePicker
        Me.dt統計日期2 = New System.Windows.Forms.DateTimePicker
        Me.cb統計部門 = New System.Windows.Forms.ComboBox
        Me.btn統計查尋 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rb月結 = New System.Windows.Forms.RadioButton
        Me.rb日結 = New System.Windows.Forms.RadioButton
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        Me.btn統計列印 = New System.Windows.Forms.Button
        Me.btn統計匯出Excel = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV統計 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Cb2印表機 = New System.Windows.Forms.ComboBox
        Me.btn明細列印 = New System.Windows.Forms.Button
        Me.btn明細匯出Excel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cb明細部門 = New System.Windows.Forms.ComboBox
        Me.dt明細日期1 = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dt明細日期2 = New System.Windows.Forms.DateTimePicker
        Me.btn明細查尋 = New System.Windows.Forms.Button
        Me.DGV明細 = New System.Windows.Forms.DataGridView
        Me.All公司 = New System.Windows.Forms.CheckBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV統計, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt統計日期1
        '
        Me.dt統計日期1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.dt統計日期1.Location = New System.Drawing.Point(38, 46)
        Me.dt統計日期1.Name = "dt統計日期1"
        Me.dt統計日期1.Size = New System.Drawing.Size(133, 27)
        Me.dt統計日期1.TabIndex = 0
        '
        'dt統計日期2
        '
        Me.dt統計日期2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.dt統計日期2.Location = New System.Drawing.Point(205, 46)
        Me.dt統計日期2.Name = "dt統計日期2"
        Me.dt統計日期2.Size = New System.Drawing.Size(132, 27)
        Me.dt統計日期2.TabIndex = 1
        '
        'cb統計部門
        '
        Me.cb統計部門.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb統計部門.Enabled = False
        Me.cb統計部門.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cb統計部門.FormattingEnabled = True
        Me.cb統計部門.Location = New System.Drawing.Point(54, 14)
        Me.cb統計部門.Name = "cb統計部門"
        Me.cb統計部門.Size = New System.Drawing.Size(212, 24)
        Me.cb統計部門.TabIndex = 2
        '
        'btn統計查尋
        '
        Me.btn統計查尋.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn統計查尋.Location = New System.Drawing.Point(343, 49)
        Me.btn統計查尋.Name = "btn統計查尋"
        Me.btn統計查尋.Size = New System.Drawing.Size(75, 24)
        Me.btn統計查尋.TabIndex = 3
        Me.btn統計查尋.Text = "查尋"
        Me.btn統計查尋.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(986, 650)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Cb1印表機)
        Me.TabPage1.Controls.Add(Me.btn統計列印)
        Me.TabPage1.Controls.Add(Me.btn統計匯出Excel)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.DGV統計)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cb統計部門)
        Me.TabPage1.Controls.Add(Me.dt統計日期1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.dt統計日期2)
        Me.TabPage1.Controls.Add(Me.btn統計查尋)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(978, 620)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "工時統計"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rb月結)
        Me.GroupBox1.Controls.Add(Me.rb日結)
        Me.GroupBox1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(272, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(160, 44)
        Me.GroupBox1.TabIndex = 316
        Me.GroupBox1.TabStop = False
        '
        'rb月結
        '
        Me.rb月結.AutoSize = True
        Me.rb月結.Location = New System.Drawing.Point(86, 18)
        Me.rb月結.Name = "rb月結"
        Me.rb月結.Size = New System.Drawing.Size(74, 20)
        Me.rb月結.TabIndex = 1
        Me.rb月結.TabStop = True
        Me.rb月結.Text = "月統計"
        Me.rb月結.UseVisualStyleBackColor = True
        '
        'rb日結
        '
        Me.rb日結.AutoSize = True
        Me.rb日結.Checked = True
        Me.rb日結.Location = New System.Drawing.Point(6, 16)
        Me.rb日結.Name = "rb日結"
        Me.rb日結.Size = New System.Drawing.Size(74, 20)
        Me.rb日結.TabIndex = 0
        Me.rb日結.TabStop = True
        Me.rb日結.Text = "日統計"
        Me.rb日結.UseVisualStyleBackColor = True
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(653, 13)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(250, 24)
        Me.Cb1印表機.TabIndex = 313
        '
        'btn統計列印
        '
        Me.btn統計列印.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btn統計列印.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn統計列印.Location = New System.Drawing.Point(906, 10)
        Me.btn統計列印.Name = "btn統計列印"
        Me.btn統計列印.Size = New System.Drawing.Size(70, 30)
        Me.btn統計列印.TabIndex = 217
        Me.btn統計列印.Text = "列印"
        Me.btn統計列印.UseVisualStyleBackColor = False
        '
        'btn統計匯出Excel
        '
        Me.btn統計匯出Excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn統計匯出Excel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn統計匯出Excel.Location = New System.Drawing.Point(880, 46)
        Me.btn統計匯出Excel.Name = "btn統計匯出Excel"
        Me.btn統計匯出Excel.Size = New System.Drawing.Size(95, 30)
        Me.btn統計匯出Excel.TabIndex = 216
        Me.btn統計匯出Excel.Text = "匯出Excel"
        Me.btn統計匯出Excel.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(177, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "到"
        '
        'DGV統計
        '
        Me.DGV統計.AllowUserToAddRows = False
        Me.DGV統計.AllowUserToDeleteRows = False
        Me.DGV統計.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV統計.Location = New System.Drawing.Point(6, 82)
        Me.DGV統計.Name = "DGV統計"
        Me.DGV統計.ReadOnly = True
        Me.DGV統計.RowTemplate.Height = 24
        Me.DGV統計.Size = New System.Drawing.Size(967, 535)
        Me.DGV統計.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(8, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "部門"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "從"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Cb2印表機)
        Me.TabPage2.Controls.Add(Me.btn明細列印)
        Me.TabPage2.Controls.Add(Me.btn明細匯出Excel)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.cb明細部門)
        Me.TabPage2.Controls.Add(Me.dt明細日期1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.dt明細日期2)
        Me.TabPage2.Controls.Add(Me.btn明細查尋)
        Me.TabPage2.Controls.Add(Me.DGV明細)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(978, 620)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "加班明細"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Cb2印表機
        '
        Me.Cb2印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb2印表機.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Cb2印表機.FormattingEnabled = True
        Me.Cb2印表機.Location = New System.Drawing.Point(653, 13)
        Me.Cb2印表機.Name = "Cb2印表機"
        Me.Cb2印表機.Size = New System.Drawing.Size(250, 24)
        Me.Cb2印表機.TabIndex = 314
        '
        'btn明細列印
        '
        Me.btn明細列印.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btn明細列印.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn明細列印.Location = New System.Drawing.Point(906, 10)
        Me.btn明細列印.Name = "btn明細列印"
        Me.btn明細列印.Size = New System.Drawing.Size(70, 30)
        Me.btn明細列印.TabIndex = 215
        Me.btn明細列印.Text = "列印"
        Me.btn明細列印.UseVisualStyleBackColor = False
        '
        'btn明細匯出Excel
        '
        Me.btn明細匯出Excel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn明細匯出Excel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btn明細匯出Excel.Location = New System.Drawing.Point(880, 46)
        Me.btn明細匯出Excel.Name = "btn明細匯出Excel"
        Me.btn明細匯出Excel.Size = New System.Drawing.Size(95, 30)
        Me.btn明細匯出Excel.TabIndex = 214
        Me.btn明細匯出Excel.Text = "匯出Excel"
        Me.btn明細匯出Excel.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(177, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "到"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(8, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "部門"
        '
        'cb明細部門
        '
        Me.cb明細部門.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb明細部門.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cb明細部門.FormattingEnabled = True
        Me.cb明細部門.Location = New System.Drawing.Point(54, 14)
        Me.cb明細部門.Name = "cb明細部門"
        Me.cb明細部門.Size = New System.Drawing.Size(212, 24)
        Me.cb明細部門.TabIndex = 12
        '
        'dt明細日期1
        '
        Me.dt明細日期1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.dt明細日期1.Location = New System.Drawing.Point(38, 46)
        Me.dt明細日期1.Name = "dt明細日期1"
        Me.dt明細日期1.Size = New System.Drawing.Size(133, 27)
        Me.dt明細日期1.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(8, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "從"
        '
        'dt明細日期2
        '
        Me.dt明細日期2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.dt明細日期2.Location = New System.Drawing.Point(205, 46)
        Me.dt明細日期2.Name = "dt明細日期2"
        Me.dt明細日期2.Size = New System.Drawing.Size(132, 27)
        Me.dt明細日期2.TabIndex = 11
        '
        'btn明細查尋
        '
        Me.btn明細查尋.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btn明細查尋.Location = New System.Drawing.Point(343, 49)
        Me.btn明細查尋.Name = "btn明細查尋"
        Me.btn明細查尋.Size = New System.Drawing.Size(75, 24)
        Me.btn明細查尋.TabIndex = 13
        Me.btn明細查尋.Text = "查尋"
        Me.btn明細查尋.UseVisualStyleBackColor = True
        '
        'DGV明細
        '
        Me.DGV明細.AllowUserToAddRows = False
        Me.DGV明細.AllowUserToDeleteRows = False
        Me.DGV明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV明細.Location = New System.Drawing.Point(6, 82)
        Me.DGV明細.Name = "DGV明細"
        Me.DGV明細.ReadOnly = True
        Me.DGV明細.RowTemplate.Height = 24
        Me.DGV明細.Size = New System.Drawing.Size(967, 535)
        Me.DGV明細.TabIndex = 0
        '
        'All公司
        '
        Me.All公司.AutoSize = True
        Me.All公司.BackColor = System.Drawing.Color.White
        Me.All公司.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.All公司.Location = New System.Drawing.Point(443, 44)
        Me.All公司.Name = "All公司"
        Me.All公司.Size = New System.Drawing.Size(91, 20)
        Me.All公司.TabIndex = 317
        Me.All公司.Text = "全部公司"
        Me.All公司.UseVisualStyleBackColor = False
        Me.All公司.Visible = False
        '
        '工時統計表v001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 646)
        Me.Controls.Add(Me.All公司)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "工時統計表v001"
        Me.Text = "工時統計表"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV統計, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DGV明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dt統計日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dt統計日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cb統計部門 As System.Windows.Forms.ComboBox
    Friend WithEvents btn統計查尋 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DGV統計 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cb明細部門 As System.Windows.Forms.ComboBox
    Friend WithEvents dt明細日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dt明細日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btn明細查尋 As System.Windows.Forms.Button
    Friend WithEvents btn明細匯出Excel As System.Windows.Forms.Button
    Private WithEvents btn明細列印 As System.Windows.Forms.Button
    Private WithEvents btn統計列印 As System.Windows.Forms.Button
    Friend WithEvents btn統計匯出Excel As System.Windows.Forms.Button
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents Cb2印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rb月結 As System.Windows.Forms.RadioButton
    Friend WithEvents rb日結 As System.Windows.Forms.RadioButton
    Friend WithEvents All公司 As System.Windows.Forms.CheckBox
End Class
