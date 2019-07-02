<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 分時領料V002
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
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.Cb時段1 = New System.Windows.Forms.ComboBox
        Me.Cb數層 = New System.Windows.Forms.ComboBox
        Me.Floor_tb = New System.Windows.Forms.Label
        Me.Dt日期 = New System.Windows.Forms.DateTimePicker
        Me.Period_tb = New System.Windows.Forms.Label
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TP單據查詢 = New System.Windows.Forms.TabPage
        Me.Bu1補印 = New System.Windows.Forms.Button
        Me.Bu1刪除 = New System.Windows.Forms.Button
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        Me.Bu1取消 = New System.Windows.Forms.Button
        Me.Bu1全選 = New System.Windows.Forms.Button
        Me.Bu1派工 = New System.Windows.Forms.Button
        Me.La1派次 = New System.Windows.Forms.Label
        Me.T1派工列印 = New System.Windows.Forms.DataGridView
        Me.T1派工明細 = New System.Windows.Forms.DataGridView
        Me.T1已派明細 = New System.Windows.Forms.DataGridView
        Me.TP領料作業 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.T_02 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Bu2取消 = New System.Windows.Forms.Button
        Me.T_01 = New System.Windows.Forms.Label
        Me.Bu2全選 = New System.Windows.Forms.Button
        Me.T2派工單號 = New System.Windows.Forms.DataGridView
        Me.Bu2所有庫位 = New System.Windows.Forms.Button
        Me.Bu2查詢庫位 = New System.Windows.Forms.Button
        Me.Cb2包含儲位 = New System.Windows.Forms.CheckBox
        Me.Tb2儲位 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.T2庫存數量 = New System.Windows.Forms.DataGridView
        Me.T2派工明細 = New System.Windows.Forms.DataGridView
        Me.Lt作業 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.PrintDialog = New System.Windows.Forms.PrintDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.La領料 = New System.Windows.Forms.Label
        Me.Bu作業選擇 = New System.Windows.Forms.Button
        Me.Cb時段2 = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TP單據查詢.SuspendLayout()
        CType(Me.T1派工列印, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1派工明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1已派明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP領料作業.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.T2派工單號, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2庫存數量, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2派工明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(717, 4)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.Bu查詢.TabIndex = 88
        Me.Bu查詢.TabStop = False
        Me.Bu查詢.Text = "查詢排程"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        'Cb時段1
        '
        Me.Cb時段1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb時段1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb時段1.FormattingEnabled = True
        Me.Cb時段1.Location = New System.Drawing.Point(470, 6)
        Me.Cb時段1.Name = "Cb時段1"
        Me.Cb時段1.Size = New System.Drawing.Size(110, 24)
        Me.Cb時段1.TabIndex = 89
        Me.Cb時段1.TabStop = False
        '
        'Cb數層
        '
        Me.Cb數層.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb數層.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb數層.FormattingEnabled = True
        Me.Cb數層.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.Cb數層.Location = New System.Drawing.Point(264, 6)
        Me.Cb數層.Name = "Cb數層"
        Me.Cb數層.Size = New System.Drawing.Size(149, 24)
        Me.Cb數層.TabIndex = 86
        Me.Cb數層.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(213, 10)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 87
        Me.Floor_tb.Text = "樓層："
        '
        'Dt日期
        '
        Me.Dt日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Dt日期.Location = New System.Drawing.Point(58, 5)
        Me.Dt日期.Name = "Dt日期"
        Me.Dt日期.Size = New System.Drawing.Size(149, 27)
        Me.Dt日期.TabIndex = 83
        Me.Dt日期.TabStop = False
        '
        'Period_tb
        '
        Me.Period_tb.AutoSize = True
        Me.Period_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Period_tb.Location = New System.Drawing.Point(419, 10)
        Me.Period_tb.Name = "Period_tb"
        Me.Period_tb.Size = New System.Drawing.Size(180, 16)
        Me.Period_tb.TabIndex = 84
        Me.Period_tb.Text = "時段：                             ~"
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(7, 10)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 85
        Me.dateDocDate_tb.Text = "日期："
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TP單據查詢)
        Me.TabControl1.Controls.Add(Me.TP領料作業)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(1, 37)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1182, 599)
        Me.TabControl1.TabIndex = 90
        '
        'TP單據查詢
        '
        Me.TP單據查詢.Controls.Add(Me.Bu1補印)
        Me.TP單據查詢.Controls.Add(Me.Bu1刪除)
        Me.TP單據查詢.Controls.Add(Me.Cb1印表機)
        Me.TP單據查詢.Controls.Add(Me.Bu1取消)
        Me.TP單據查詢.Controls.Add(Me.Bu1全選)
        Me.TP單據查詢.Controls.Add(Me.Bu1派工)
        Me.TP單據查詢.Controls.Add(Me.La1派次)
        Me.TP單據查詢.Controls.Add(Me.T1派工列印)
        Me.TP單據查詢.Controls.Add(Me.T1派工明細)
        Me.TP單據查詢.Controls.Add(Me.T1已派明細)
        Me.TP單據查詢.Location = New System.Drawing.Point(4, 4)
        Me.TP單據查詢.Name = "TP單據查詢"
        Me.TP單據查詢.Padding = New System.Windows.Forms.Padding(3)
        Me.TP單據查詢.Size = New System.Drawing.Size(1174, 569)
        Me.TP單據查詢.TabIndex = 0
        Me.TP單據查詢.Text = "單據查詢"
        Me.TP單據查詢.UseVisualStyleBackColor = True
        '
        'Bu1補印
        '
        Me.Bu1補印.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1補印.Location = New System.Drawing.Point(1084, 526)
        Me.Bu1補印.Name = "Bu1補印"
        Me.Bu1補印.Size = New System.Drawing.Size(84, 37)
        Me.Bu1補印.TabIndex = 1086
        Me.Bu1補印.Text = "補印"
        Me.Bu1補印.UseVisualStyleBackColor = True
        '
        'Bu1刪除
        '
        Me.Bu1刪除.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1刪除.Location = New System.Drawing.Point(1084, 335)
        Me.Bu1刪除.Name = "Bu1刪除"
        Me.Bu1刪除.Size = New System.Drawing.Size(84, 37)
        Me.Bu1刪除.TabIndex = 1085
        Me.Bu1刪除.Text = "刪除"
        Me.Bu1刪除.UseVisualStyleBackColor = True
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(896, 3)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(272, 24)
        Me.Cb1印表機.TabIndex = 1084
        '
        'Bu1取消
        '
        Me.Bu1取消.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1取消.Location = New System.Drawing.Point(97, 7)
        Me.Bu1取消.Name = "Bu1取消"
        Me.Bu1取消.Size = New System.Drawing.Size(84, 30)
        Me.Bu1取消.TabIndex = 1074
        Me.Bu1取消.Text = "全取消"
        Me.Bu1取消.UseVisualStyleBackColor = True
        '
        'Bu1全選
        '
        Me.Bu1全選.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1全選.Location = New System.Drawing.Point(7, 7)
        Me.Bu1全選.Name = "Bu1全選"
        Me.Bu1全選.Size = New System.Drawing.Size(84, 30)
        Me.Bu1全選.TabIndex = 1073
        Me.Bu1全選.Text = "全選"
        Me.Bu1全選.UseVisualStyleBackColor = True
        '
        'Bu1派工
        '
        Me.Bu1派工.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1派工.Location = New System.Drawing.Point(806, 6)
        Me.Bu1派工.Name = "Bu1派工"
        Me.Bu1派工.Size = New System.Drawing.Size(84, 37)
        Me.Bu1派工.TabIndex = 1068
        Me.Bu1派工.Text = "派工"
        Me.Bu1派工.UseVisualStyleBackColor = True
        '
        'La1派次
        '
        Me.La1派次.AutoSize = True
        Me.La1派次.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La1派次.Location = New System.Drawing.Point(1128, 30)
        Me.La1派次.Name = "La1派次"
        Me.La1派次.Size = New System.Drawing.Size(40, 16)
        Me.La1派次.TabIndex = 1068
        Me.La1派次.Text = "派次"
        Me.La1派次.Visible = False
        '
        'T1派工列印
        '
        Me.T1派工列印.AllowUserToAddRows = False
        Me.T1派工列印.AllowUserToDeleteRows = False
        Me.T1派工列印.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1派工列印.Location = New System.Drawing.Point(721, 67)
        Me.T1派工列印.MultiSelect = False
        Me.T1派工列印.Name = "T1派工列印"
        Me.T1派工列印.ReadOnly = True
        Me.T1派工列印.RowHeadersVisible = False
        Me.T1派工列印.RowTemplate.Height = 24
        Me.T1派工列印.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1派工列印.Size = New System.Drawing.Size(435, 228)
        Me.T1派工列印.TabIndex = 1072
        Me.T1派工列印.Visible = False
        '
        'T1派工明細
        '
        Me.T1派工明細.AllowUserToAddRows = False
        Me.T1派工明細.AllowUserToDeleteRows = False
        Me.T1派工明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1派工明細.Location = New System.Drawing.Point(7, 48)
        Me.T1派工明細.MultiSelect = False
        Me.T1派工明細.Name = "T1派工明細"
        Me.T1派工明細.RowHeadersVisible = False
        Me.T1派工明細.RowTemplate.Height = 24
        Me.T1派工明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1派工明細.Size = New System.Drawing.Size(1161, 281)
        Me.T1派工明細.TabIndex = 1070
        '
        'T1已派明細
        '
        Me.T1已派明細.AllowUserToAddRows = False
        Me.T1已派明細.AllowUserToDeleteRows = False
        Me.T1已派明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1已派明細.Location = New System.Drawing.Point(7, 332)
        Me.T1已派明細.MultiSelect = False
        Me.T1已派明細.Name = "T1已派明細"
        Me.T1已派明細.ReadOnly = True
        Me.T1已派明細.RowHeadersVisible = False
        Me.T1已派明細.RowTemplate.Height = 24
        Me.T1已派明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1已派明細.Size = New System.Drawing.Size(1071, 231)
        Me.T1已派明細.TabIndex = 1071
        '
        'TP領料作業
        '
        Me.TP領料作業.Controls.Add(Me.GroupBox1)
        Me.TP領料作業.Controls.Add(Me.T2派工單號)
        Me.TP領料作業.Controls.Add(Me.Bu2所有庫位)
        Me.TP領料作業.Controls.Add(Me.Bu2查詢庫位)
        Me.TP領料作業.Controls.Add(Me.Cb2包含儲位)
        Me.TP領料作業.Controls.Add(Me.Tb2儲位)
        Me.TP領料作業.Controls.Add(Me.Label3)
        Me.TP領料作業.Controls.Add(Me.T2庫存數量)
        Me.TP領料作業.Controls.Add(Me.T2派工明細)
        Me.TP領料作業.Location = New System.Drawing.Point(4, 4)
        Me.TP領料作業.Name = "TP領料作業"
        Me.TP領料作業.Padding = New System.Windows.Forms.Padding(3)
        Me.TP領料作業.Size = New System.Drawing.Size(1174, 569)
        Me.TP領料作業.TabIndex = 1
        Me.TP領料作業.Text = "領料作業"
        Me.TP領料作業.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.T_02)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Bu2取消)
        Me.GroupBox1.Controls.Add(Me.T_01)
        Me.GroupBox1.Controls.Add(Me.Bu2全選)
        Me.GroupBox1.Location = New System.Drawing.Point(936, 331)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(232, 232)
        Me.GroupBox1.TabIndex = 1093
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "時間"
        Me.GroupBox1.Visible = False
        '
        'T_02
        '
        Me.T_02.AutoSize = True
        Me.T_02.Location = New System.Drawing.Point(6, 51)
        Me.T_02.Name = "T_02"
        Me.T_02.Size = New System.Drawing.Size(41, 16)
        Me.T_02.TabIndex = 2
        Me.T_02.Text = "T_02"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "查庫存"
        '
        'Bu2取消
        '
        Me.Bu2取消.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2取消.Location = New System.Drawing.Point(99, 196)
        Me.Bu2取消.Name = "Bu2取消"
        Me.Bu2取消.Size = New System.Drawing.Size(84, 30)
        Me.Bu2取消.TabIndex = 1087
        Me.Bu2取消.Text = "全取消"
        Me.Bu2取消.UseVisualStyleBackColor = True
        Me.Bu2取消.Visible = False
        '
        'T_01
        '
        Me.T_01.AutoSize = True
        Me.T_01.Location = New System.Drawing.Point(6, 35)
        Me.T_01.Name = "T_01"
        Me.T_01.Size = New System.Drawing.Size(41, 16)
        Me.T_01.TabIndex = 0
        Me.T_01.Text = "T_01"
        '
        'Bu2全選
        '
        Me.Bu2全選.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2全選.Location = New System.Drawing.Point(9, 196)
        Me.Bu2全選.Name = "Bu2全選"
        Me.Bu2全選.Size = New System.Drawing.Size(84, 30)
        Me.Bu2全選.TabIndex = 1086
        Me.Bu2全選.Text = "全選"
        Me.Bu2全選.UseVisualStyleBackColor = True
        Me.Bu2全選.Visible = False
        '
        'T2派工單號
        '
        Me.T2派工單號.AllowUserToAddRows = False
        Me.T2派工單號.AllowUserToDeleteRows = False
        Me.T2派工單號.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2派工單號.Location = New System.Drawing.Point(7, 48)
        Me.T2派工單號.MultiSelect = False
        Me.T2派工單號.Name = "T2派工單號"
        Me.T2派工單號.ReadOnly = True
        Me.T2派工單號.RowHeadersVisible = False
        Me.T2派工單號.RowTemplate.Height = 24
        Me.T2派工單號.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2派工單號.Size = New System.Drawing.Size(202, 280)
        Me.T2派工單號.TabIndex = 1092
        '
        'Bu2所有庫位
        '
        Me.Bu2所有庫位.Location = New System.Drawing.Point(1099, 3)
        Me.Bu2所有庫位.Name = "Bu2所有庫位"
        Me.Bu2所有庫位.Size = New System.Drawing.Size(70, 45)
        Me.Bu2所有庫位.TabIndex = 1091
        Me.Bu2所有庫位.TabStop = False
        Me.Bu2所有庫位.Text = "所有" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "庫位"
        Me.Bu2所有庫位.UseVisualStyleBackColor = True
        '
        'Bu2查詢庫位
        '
        Me.Bu2查詢庫位.Location = New System.Drawing.Point(1027, 3)
        Me.Bu2查詢庫位.Name = "Bu2查詢庫位"
        Me.Bu2查詢庫位.Size = New System.Drawing.Size(70, 45)
        Me.Bu2查詢庫位.TabIndex = 1089
        Me.Bu2查詢庫位.TabStop = False
        Me.Bu2查詢庫位.Text = "查詢" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "庫位"
        Me.Bu2查詢庫位.UseVisualStyleBackColor = True
        '
        'Cb2包含儲位
        '
        Me.Cb2包含儲位.AutoSize = True
        Me.Cb2包含儲位.Checked = True
        Me.Cb2包含儲位.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Cb2包含儲位.Location = New System.Drawing.Point(970, 6)
        Me.Cb2包含儲位.Name = "Cb2包含儲位"
        Me.Cb2包含儲位.Size = New System.Drawing.Size(59, 20)
        Me.Cb2包含儲位.TabIndex = 1090
        Me.Cb2包含儲位.Text = "包含"
        Me.Cb2包含儲位.UseVisualStyleBackColor = True
        '
        'Tb2儲位
        '
        Me.Tb2儲位.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Tb2儲位.Location = New System.Drawing.Point(883, 5)
        Me.Tb2儲位.Name = "Tb2儲位"
        Me.Tb2儲位.Size = New System.Drawing.Size(81, 23)
        Me.Tb2儲位.TabIndex = 1087
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(831, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 1088
        Me.Label3.Text = "來源："
        '
        'T2庫存數量
        '
        Me.T2庫存數量.AllowUserToAddRows = False
        Me.T2庫存數量.AllowUserToDeleteRows = False
        Me.T2庫存數量.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2庫存數量.Location = New System.Drawing.Point(7, 331)
        Me.T2庫存數量.MultiSelect = False
        Me.T2庫存數量.Name = "T2庫存數量"
        Me.T2庫存數量.ReadOnly = True
        Me.T2庫存數量.RowHeadersVisible = False
        Me.T2庫存數量.RowTemplate.Height = 24
        Me.T2庫存數量.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2庫存數量.Size = New System.Drawing.Size(923, 234)
        Me.T2庫存數量.TabIndex = 1086
        '
        'T2派工明細
        '
        Me.T2派工明細.AllowUserToAddRows = False
        Me.T2派工明細.AllowUserToDeleteRows = False
        Me.T2派工明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2派工明細.Location = New System.Drawing.Point(211, 48)
        Me.T2派工明細.MultiSelect = False
        Me.T2派工明細.Name = "T2派工明細"
        Me.T2派工明細.ReadOnly = True
        Me.T2派工明細.RowHeadersVisible = False
        Me.T2派工明細.RowTemplate.Height = 24
        Me.T2派工明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2派工明細.Size = New System.Drawing.Size(958, 280)
        Me.T2派工明細.TabIndex = 1086
        '
        'Lt作業
        '
        Me.Lt作業.AutoSize = True
        Me.Lt作業.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt作業.Location = New System.Drawing.Point(1052, 7)
        Me.Lt作業.Name = "Lt作業"
        Me.Lt作業.Size = New System.Drawing.Size(42, 16)
        Me.Lt作業.TabIndex = 1067
        Me.Lt作業.Text = "未選"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(967, 7)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(93, 16)
        Me.Label31.TabIndex = 1066
        Me.Label31.Text = "目前作業："
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(967, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 1068
        Me.Label1.Text = "領料："
        Me.Label1.Visible = False
        '
        'La領料
        '
        Me.La領料.AutoSize = True
        Me.La領料.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La領料.Location = New System.Drawing.Point(1016, 24)
        Me.La領料.Name = "La領料"
        Me.La領料.Size = New System.Drawing.Size(40, 16)
        Me.La領料.TabIndex = 1069
        Me.La領料.Text = "領料"
        Me.La領料.Visible = False
        '
        'Bu作業選擇
        '
        Me.Bu作業選擇.Enabled = False
        Me.Bu作業選擇.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu作業選擇.Location = New System.Drawing.Point(861, 3)
        Me.Bu作業選擇.Name = "Bu作業選擇"
        Me.Bu作業選擇.Size = New System.Drawing.Size(100, 30)
        Me.Bu作業選擇.TabIndex = 1086
        Me.Bu作業選擇.Text = "單據查詢"
        Me.Bu作業選擇.UseVisualStyleBackColor = True
        '
        'Cb時段2
        '
        Me.Cb時段2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb時段2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb時段2.FormattingEnabled = True
        Me.Cb時段2.Location = New System.Drawing.Point(601, 6)
        Me.Cb時段2.Name = "Cb時段2"
        Me.Cb時段2.Size = New System.Drawing.Size(110, 24)
        Me.Cb時段2.TabIndex = 1087
        Me.Cb時段2.TabStop = False
        '
        '分時領料V002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 637)
        Me.Controls.Add(Me.Bu查詢)
        Me.Controls.Add(Me.Cb時段1)
        Me.Controls.Add(Me.Cb時段2)
        Me.Controls.Add(Me.Lt作業)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Bu作業選擇)
        Me.Controls.Add(Me.La領料)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Cb數層)
        Me.Controls.Add(Me.Floor_tb)
        Me.Controls.Add(Me.Dt日期)
        Me.Controls.Add(Me.Period_tb)
        Me.Controls.Add(Me.dateDocDate_tb)
        Me.Name = "分時領料V002"
        Me.Text = "分時領料"
        Me.TabControl1.ResumeLayout(False)
        Me.TP單據查詢.ResumeLayout(False)
        Me.TP單據查詢.PerformLayout()
        CType(Me.T1派工列印, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1派工明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1已派明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP領料作業.ResumeLayout(False)
        Me.TP領料作業.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.T2派工單號, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2庫存數量, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2派工明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents Cb時段1 As System.Windows.Forms.ComboBox
    Friend WithEvents Cb數層 As System.Windows.Forms.ComboBox
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents Dt日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Period_tb As System.Windows.Forms.Label
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP單據查詢 As System.Windows.Forms.TabPage
    Friend WithEvents TP領料作業 As System.Windows.Forms.TabPage
    Friend WithEvents Lt作業 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents T1派工列印 As System.Windows.Forms.DataGridView
    Friend WithEvents T1派工明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T1已派明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu1派工 As System.Windows.Forms.Button
    Friend WithEvents Bu1取消 As System.Windows.Forms.Button
    Friend WithEvents Bu1全選 As System.Windows.Forms.Button
    Friend WithEvents La1派次 As System.Windows.Forms.Label
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents Bu1刪除 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents La領料 As System.Windows.Forms.Label
    Friend WithEvents T2派工明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T2庫存數量 As System.Windows.Forms.DataGridView
    Friend WithEvents Tb2儲位 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Bu2所有庫位 As System.Windows.Forms.Button
    Friend WithEvents Bu2查詢庫位 As System.Windows.Forms.Button
    Friend WithEvents Cb2包含儲位 As System.Windows.Forms.CheckBox
    Friend WithEvents Bu2取消 As System.Windows.Forms.Button
    Friend WithEvents Bu2全選 As System.Windows.Forms.Button
    Friend WithEvents T2派工單號 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu作業選擇 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents T_02 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T_01 As System.Windows.Forms.Label
    Friend WithEvents Cb時段2 As System.Windows.Forms.ComboBox
    Friend WithEvents Bu1補印 As System.Windows.Forms.Button
End Class
