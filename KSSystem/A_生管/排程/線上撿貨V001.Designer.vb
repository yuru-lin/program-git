<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 線上撿貨V001
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TP派單作業 = New System.Windows.Forms.TabPage
        Me.T1Pa編輯 = New System.Windows.Forms.Panel
        Me.T1Bu新增 = New System.Windows.Forms.Button
        Me.T1項目明細 = New System.Windows.Forms.DataGridView
        Me.T1Tb備註 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.T1Tb數量 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.T1Tb項目 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.T1Tb品名 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.T1Tb存編 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.T1Cx包含 = New System.Windows.Forms.CheckBox
        Me.T1Tb查3 = New System.Windows.Forms.TextBox
        Me.T1Tb查2 = New System.Windows.Forms.TextBox
        Me.T1Tb查1 = New System.Windows.Forms.TextBox
        Me.T1Bu查詢品項 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.T1Cb客戶 = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.T1Dt生產 = New System.Windows.Forms.DateTimePicker
        Me.T1La時間 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.T1La單號 = New System.Windows.Forms.Label
        Me.T1Cb樓層 = New System.Windows.Forms.ComboBox
        Me.Floor_tb = New System.Windows.Forms.Label
        Me.T1Bu存檔 = New System.Windows.Forms.Button
        Me.T1Bu編輯 = New System.Windows.Forms.Button
        Me.T1Bu移除 = New System.Windows.Forms.Button
        Me.T1Bu撿貨 = New System.Windows.Forms.Button
        Me.T1已排項目 = New System.Windows.Forms.DataGridView
        Me.T1Bu查詢 = New System.Windows.Forms.Button
        Me.T1Dt日期 = New System.Windows.Forms.DateTimePicker
        Me.dateDocDate_tb = New System.Windows.Forms.Label
        Me.T1未排項目 = New System.Windows.Forms.DataGridView
        Me.TP派單查詢 = New System.Windows.Forms.TabPage
        Me.T2Bu複製 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.T2Tb日期 = New System.Windows.Forms.Label
        Me.T2Tb時間 = New System.Windows.Forms.Label
        Me.T2Tb樓層 = New System.Windows.Forms.Label
        Me.T2Tb單號 = New System.Windows.Forms.Label
        Me.T2Bu列印 = New System.Windows.Forms.Button
        Me.T2Bu刪除 = New System.Windows.Forms.Button
        Me.T2Dt生產 = New System.Windows.Forms.DateTimePicker
        Me.T2Cb樓層 = New System.Windows.Forms.ComboBox
        Me.T2線上明細 = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.T2Bu查詢 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RB查詢 = New System.Windows.Forms.RadioButton
        Me.RB作業 = New System.Windows.Forms.RadioButton
        Me.Lt作業 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.PrintDialog = New System.Windows.Forms.PrintDialog
        Me.T2複製明細 = New System.Windows.Forms.DataGridView
        Me.T2La單號 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TP派單作業.SuspendLayout()
        Me.T1Pa編輯.SuspendLayout()
        CType(Me.T1項目明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.T1已排項目, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1未排項目, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP派單查詢.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.T2線上明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.T2複製明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP派單作業)
        Me.TabControl1.Controls.Add(Me.TP派單查詢)
        Me.TabControl1.Location = New System.Drawing.Point(-3, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1175, 612)
        Me.TabControl1.TabIndex = 0
        '
        'TP派單作業
        '
        Me.TP派單作業.Controls.Add(Me.T1Pa編輯)
        Me.TP派單作業.Controls.Add(Me.Panel2)
        Me.TP派單作業.Controls.Add(Me.T1Bu存檔)
        Me.TP派單作業.Controls.Add(Me.T1Bu編輯)
        Me.TP派單作業.Controls.Add(Me.T1Bu移除)
        Me.TP派單作業.Controls.Add(Me.T1Bu撿貨)
        Me.TP派單作業.Controls.Add(Me.T1已排項目)
        Me.TP派單作業.Controls.Add(Me.T1Bu查詢)
        Me.TP派單作業.Controls.Add(Me.T1Dt日期)
        Me.TP派單作業.Controls.Add(Me.dateDocDate_tb)
        Me.TP派單作業.Controls.Add(Me.T1未排項目)
        Me.TP派單作業.Location = New System.Drawing.Point(4, 26)
        Me.TP派單作業.Name = "TP派單作業"
        Me.TP派單作業.Padding = New System.Windows.Forms.Padding(3)
        Me.TP派單作業.Size = New System.Drawing.Size(1167, 582)
        Me.TP派單作業.TabIndex = 0
        Me.TP派單作業.Text = "派單作業"
        Me.TP派單作業.UseVisualStyleBackColor = True
        '
        'T1Pa編輯
        '
        Me.T1Pa編輯.Controls.Add(Me.T1Bu新增)
        Me.T1Pa編輯.Controls.Add(Me.T1項目明細)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb備註)
        Me.T1Pa編輯.Controls.Add(Me.Label6)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb數量)
        Me.T1Pa編輯.Controls.Add(Me.Label5)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb項目)
        Me.T1Pa編輯.Controls.Add(Me.Label4)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb品名)
        Me.T1Pa編輯.Controls.Add(Me.Label3)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb存編)
        Me.T1Pa編輯.Controls.Add(Me.Label2)
        Me.T1Pa編輯.Controls.Add(Me.T1Cx包含)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb查3)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb查2)
        Me.T1Pa編輯.Controls.Add(Me.T1Tb查1)
        Me.T1Pa編輯.Controls.Add(Me.T1Bu查詢品項)
        Me.T1Pa編輯.Controls.Add(Me.Label12)
        Me.T1Pa編輯.Controls.Add(Me.T1Cb客戶)
        Me.T1Pa編輯.Controls.Add(Me.Label1)
        Me.T1Pa編輯.Location = New System.Drawing.Point(551, 3)
        Me.T1Pa編輯.Name = "T1Pa編輯"
        Me.T1Pa編輯.Size = New System.Drawing.Size(320, 580)
        Me.T1Pa編輯.TabIndex = 1081
        Me.T1Pa編輯.Visible = False
        '
        'T1Bu新增
        '
        Me.T1Bu新增.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu新增.Location = New System.Drawing.Point(160, 125)
        Me.T1Bu新增.Name = "T1Bu新增"
        Me.T1Bu新增.Size = New System.Drawing.Size(124, 30)
        Me.T1Bu新增.TabIndex = 1095
        Me.T1Bu新增.Text = "新增"
        Me.T1Bu新增.UseVisualStyleBackColor = True
        '
        'T1項目明細
        '
        Me.T1項目明細.AllowUserToAddRows = False
        Me.T1項目明細.AllowUserToDeleteRows = False
        Me.T1項目明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1項目明細.Location = New System.Drawing.Point(3, 288)
        Me.T1項目明細.MultiSelect = False
        Me.T1項目明細.Name = "T1項目明細"
        Me.T1項目明細.ReadOnly = True
        Me.T1項目明細.RowHeadersVisible = False
        Me.T1項目明細.RowTemplate.Height = 24
        Me.T1項目明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1項目明細.Size = New System.Drawing.Size(314, 288)
        Me.T1項目明細.TabIndex = 1082
        '
        'T1Tb備註
        '
        Me.T1Tb備註.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb備註.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb備註.Location = New System.Drawing.Point(59, 156)
        Me.T1Tb備註.Multiline = True
        Me.T1Tb備註.Name = "T1Tb備註"
        Me.T1Tb備註.Size = New System.Drawing.Size(225, 47)
        Me.T1Tb備註.TabIndex = 1094
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 1093
        Me.Label6.Text = "備註："
        '
        'T1Tb數量
        '
        Me.T1Tb數量.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb數量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb數量.Location = New System.Drawing.Point(59, 126)
        Me.T1Tb數量.Name = "T1Tb數量"
        Me.T1Tb數量.Size = New System.Drawing.Size(73, 27)
        Me.T1Tb數量.TabIndex = 1092
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 1091
        Me.Label5.Text = "數量："
        '
        'T1Tb項目
        '
        Me.T1Tb項目.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb項目.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb項目.Location = New System.Drawing.Point(59, 96)
        Me.T1Tb項目.Name = "T1Tb項目"
        Me.T1Tb項目.Size = New System.Drawing.Size(225, 27)
        Me.T1Tb項目.TabIndex = 1090
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 32)
        Me.Label4.TabIndex = 1089
        Me.Label4.Text = "生產" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "項目"
        '
        'T1Tb品名
        '
        Me.T1Tb品名.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb品名.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb品名.Location = New System.Drawing.Point(59, 66)
        Me.T1Tb品名.Name = "T1Tb品名"
        Me.T1Tb品名.ReadOnly = True
        Me.T1Tb品名.Size = New System.Drawing.Size(225, 27)
        Me.T1Tb品名.TabIndex = 1088
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 1087
        Me.Label3.Text = "品名："
        '
        'T1Tb存編
        '
        Me.T1Tb存編.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb存編.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb存編.Location = New System.Drawing.Point(59, 36)
        Me.T1Tb存編.Name = "T1Tb存編"
        Me.T1Tb存編.ReadOnly = True
        Me.T1Tb存編.Size = New System.Drawing.Size(225, 27)
        Me.T1Tb存編.TabIndex = 1086
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 1085
        Me.Label2.Text = "存編："
        '
        'T1Cx包含
        '
        Me.T1Cx包含.AutoSize = True
        Me.T1Cx包含.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Cx包含.Location = New System.Drawing.Point(185, 213)
        Me.T1Cx包含.Name = "T1Cx包含"
        Me.T1Cx包含.Size = New System.Drawing.Size(82, 17)
        Me.T1Cx包含.TabIndex = 1080
        Me.T1Cx包含.Text = "包含查詢"
        Me.T1Cx包含.UseVisualStyleBackColor = True
        '
        'T1Tb查3
        '
        Me.T1Tb查3.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb查3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb查3.Location = New System.Drawing.Point(59, 261)
        Me.T1Tb查3.Name = "T1Tb查3"
        Me.T1Tb查3.Size = New System.Drawing.Size(120, 23)
        Me.T1Tb查3.TabIndex = 1079
        '
        'T1Tb查2
        '
        Me.T1Tb查2.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb查2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb查2.Location = New System.Drawing.Point(59, 234)
        Me.T1Tb查2.Name = "T1Tb查2"
        Me.T1Tb查2.Size = New System.Drawing.Size(120, 23)
        Me.T1Tb查2.TabIndex = 1078
        '
        'T1Tb查1
        '
        Me.T1Tb查1.BackColor = System.Drawing.SystemColors.Window
        Me.T1Tb查1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Tb查1.Location = New System.Drawing.Point(59, 207)
        Me.T1Tb查1.Name = "T1Tb查1"
        Me.T1Tb查1.Size = New System.Drawing.Size(120, 23)
        Me.T1Tb查1.TabIndex = 1077
        '
        'T1Bu查詢品項
        '
        Me.T1Bu查詢品項.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu查詢品項.Location = New System.Drawing.Point(185, 252)
        Me.T1Bu查詢品項.Name = "T1Bu查詢品項"
        Me.T1Bu查詢品項.Size = New System.Drawing.Size(84, 30)
        Me.T1Bu查詢品項.TabIndex = 1081
        Me.T1Bu查詢品項.Text = "查詢"
        Me.T1Bu查詢品項.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 32)
        Me.Label12.TabIndex = 1084
        Me.Label12.Text = "查詢" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "品名"
        '
        'T1Cb客戶
        '
        Me.T1Cb客戶.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Cb客戶.FormattingEnabled = True
        Me.T1Cb客戶.Items.AddRange(New Object() {"凱馨", "全聯"})
        Me.T1Cb客戶.Location = New System.Drawing.Point(59, 9)
        Me.T1Cb客戶.Name = "T1Cb客戶"
        Me.T1Cb客戶.Size = New System.Drawing.Size(149, 24)
        Me.T1Cb客戶.TabIndex = 1073
        Me.T1Cb客戶.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 16)
        Me.Label1.TabIndex = 1074
        Me.Label1.Text = "客戶："
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.T1Dt生產)
        Me.Panel2.Controls.Add(Me.T1La時間)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.T1La單號)
        Me.Panel2.Controls.Add(Me.T1Cb樓層)
        Me.Panel2.Controls.Add(Me.Floor_tb)
        Me.Panel2.Location = New System.Drawing.Point(323, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(569, 33)
        Me.Panel2.TabIndex = 1080
        Me.Panel2.Visible = False
        '
        'T1Dt生產
        '
        Me.T1Dt生產.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Dt生產.Location = New System.Drawing.Point(191, 4)
        Me.T1Dt生產.Name = "T1Dt生產"
        Me.T1Dt生產.Size = New System.Drawing.Size(149, 27)
        Me.T1Dt生產.TabIndex = 1082
        Me.T1Dt生產.TabStop = False
        '
        'T1La時間
        '
        Me.T1La時間.AutoSize = True
        Me.T1La時間.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1La時間.Location = New System.Drawing.Point(469, 9)
        Me.T1La時間.Name = "T1La時間"
        Me.T1La時間.Size = New System.Drawing.Size(42, 16)
        Me.T1La時間.TabIndex = 1072
        Me.T1La時間.Text = "時間"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(140, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 1083
        Me.Label7.Text = "生產："
        '
        'T1La單號
        '
        Me.T1La單號.AutoSize = True
        Me.T1La單號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1La單號.Location = New System.Drawing.Point(345, 9)
        Me.T1La單號.Name = "T1La單號"
        Me.T1La單號.Size = New System.Drawing.Size(42, 16)
        Me.T1La單號.TabIndex = 1070
        Me.T1La單號.Text = "單號"
        '
        'T1Cb樓層
        '
        Me.T1Cb樓層.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T1Cb樓層.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Cb樓層.FormattingEnabled = True
        Me.T1Cb樓層.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.T1Cb樓層.Location = New System.Drawing.Point(54, 5)
        Me.T1Cb樓層.Name = "T1Cb樓層"
        Me.T1Cb樓層.Size = New System.Drawing.Size(80, 24)
        Me.T1Cb樓層.TabIndex = 1070
        Me.T1Cb樓層.TabStop = False
        '
        'Floor_tb
        '
        Me.Floor_tb.AutoSize = True
        Me.Floor_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Floor_tb.Location = New System.Drawing.Point(3, 9)
        Me.Floor_tb.Name = "Floor_tb"
        Me.Floor_tb.Size = New System.Drawing.Size(56, 16)
        Me.Floor_tb.TabIndex = 1071
        Me.Floor_tb.Text = "樓層："
        '
        'T1Bu存檔
        '
        Me.T1Bu存檔.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu存檔.Location = New System.Drawing.Point(1063, 3)
        Me.T1Bu存檔.Name = "T1Bu存檔"
        Me.T1Bu存檔.Size = New System.Drawing.Size(100, 30)
        Me.T1Bu存檔.TabIndex = 1079
        Me.T1Bu存檔.TabStop = False
        Me.T1Bu存檔.Text = "列印"
        Me.T1Bu存檔.UseVisualStyleBackColor = True
        Me.T1Bu存檔.Visible = False
        '
        'T1Bu編輯
        '
        Me.T1Bu編輯.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu編輯.Location = New System.Drawing.Point(891, 3)
        Me.T1Bu編輯.Name = "T1Bu編輯"
        Me.T1Bu編輯.Size = New System.Drawing.Size(100, 30)
        Me.T1Bu編輯.TabIndex = 1078
        Me.T1Bu編輯.TabStop = False
        Me.T1Bu編輯.Text = "編輯"
        Me.T1Bu編輯.UseVisualStyleBackColor = True
        '
        'T1Bu移除
        '
        Me.T1Bu移除.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu移除.Location = New System.Drawing.Point(-1, 315)
        Me.T1Bu移除.Name = "T1Bu移除"
        Me.T1Bu移除.Size = New System.Drawing.Size(100, 30)
        Me.T1Bu移除.TabIndex = 1077
        Me.T1Bu移除.TabStop = False
        Me.T1Bu移除.Text = "移除撿貨"
        Me.T1Bu移除.UseVisualStyleBackColor = True
        '
        'T1Bu撿貨
        '
        Me.T1Bu撿貨.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu撿貨.Location = New System.Drawing.Point(0, 37)
        Me.T1Bu撿貨.Name = "T1Bu撿貨"
        Me.T1Bu撿貨.Size = New System.Drawing.Size(100, 30)
        Me.T1Bu撿貨.TabIndex = 1076
        Me.T1Bu撿貨.TabStop = False
        Me.T1Bu撿貨.Text = "排入撿貨"
        Me.T1Bu撿貨.UseVisualStyleBackColor = True
        '
        'T1已排項目
        '
        Me.T1已排項目.AllowUserToAddRows = False
        Me.T1已排項目.AllowUserToDeleteRows = False
        Me.T1已排項目.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1已排項目.Location = New System.Drawing.Point(100, 315)
        Me.T1已排項目.MultiSelect = False
        Me.T1已排項目.Name = "T1已排項目"
        Me.T1已排項目.RowHeadersVisible = False
        Me.T1已排項目.RowTemplate.Height = 24
        Me.T1已排項目.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1已排項目.Size = New System.Drawing.Size(1063, 264)
        Me.T1已排項目.TabIndex = 1075
        '
        'T1Bu查詢
        '
        Me.T1Bu查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Bu查詢.Location = New System.Drawing.Point(217, 3)
        Me.T1Bu查詢.Name = "T1Bu查詢"
        Me.T1Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.T1Bu查詢.TabIndex = 1074
        Me.T1Bu查詢.TabStop = False
        Me.T1Bu查詢.Text = "查詢"
        Me.T1Bu查詢.UseVisualStyleBackColor = True
        '
        'T1Dt日期
        '
        Me.T1Dt日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T1Dt日期.Location = New System.Drawing.Point(62, 4)
        Me.T1Dt日期.Name = "T1Dt日期"
        Me.T1Dt日期.Size = New System.Drawing.Size(149, 27)
        Me.T1Dt日期.TabIndex = 1072
        Me.T1Dt日期.TabStop = False
        '
        'dateDocDate_tb
        '
        Me.dateDocDate_tb.AutoSize = True
        Me.dateDocDate_tb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.dateDocDate_tb.Location = New System.Drawing.Point(11, 9)
        Me.dateDocDate_tb.Name = "dateDocDate_tb"
        Me.dateDocDate_tb.Size = New System.Drawing.Size(56, 16)
        Me.dateDocDate_tb.TabIndex = 1073
        Me.dateDocDate_tb.Text = "日期："
        '
        'T1未排項目
        '
        Me.T1未排項目.AllowUserToAddRows = False
        Me.T1未排項目.AllowUserToDeleteRows = False
        Me.T1未排項目.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1未排項目.Location = New System.Drawing.Point(100, 37)
        Me.T1未排項目.MultiSelect = False
        Me.T1未排項目.Name = "T1未排項目"
        Me.T1未排項目.RowHeadersVisible = False
        Me.T1未排項目.RowTemplate.Height = 24
        Me.T1未排項目.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1未排項目.Size = New System.Drawing.Size(1063, 275)
        Me.T1未排項目.TabIndex = 1071
        '
        'TP派單查詢
        '
        Me.TP派單查詢.Controls.Add(Me.GroupBox1)
        Me.TP派單查詢.Controls.Add(Me.T2複製明細)
        Me.TP派單查詢.Controls.Add(Me.T2Bu複製)
        Me.TP派單查詢.Controls.Add(Me.T2Tb單號)
        Me.TP派單查詢.Controls.Add(Me.T2Bu列印)
        Me.TP派單查詢.Controls.Add(Me.T2Bu刪除)
        Me.TP派單查詢.Controls.Add(Me.T2Dt生產)
        Me.TP派單查詢.Controls.Add(Me.T2Cb樓層)
        Me.TP派單查詢.Controls.Add(Me.T2線上明細)
        Me.TP派單查詢.Controls.Add(Me.Label9)
        Me.TP派單查詢.Controls.Add(Me.T2Bu查詢)
        Me.TP派單查詢.Controls.Add(Me.Label8)
        Me.TP派單查詢.Location = New System.Drawing.Point(4, 26)
        Me.TP派單查詢.Name = "TP派單查詢"
        Me.TP派單查詢.Padding = New System.Windows.Forms.Padding(3)
        Me.TP派單查詢.Size = New System.Drawing.Size(1167, 582)
        Me.TP派單查詢.TabIndex = 1
        Me.TP派單查詢.Text = "派單查詢"
        Me.TP派單查詢.UseVisualStyleBackColor = True
        '
        'T2Bu複製
        '
        Me.T2Bu複製.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Bu複製.Location = New System.Drawing.Point(916, 3)
        Me.T2Bu複製.Name = "T2Bu複製"
        Me.T2Bu複製.Size = New System.Drawing.Size(100, 30)
        Me.T2Bu複製.TabIndex = 1091
        Me.T2Bu複製.TabStop = False
        Me.T2Bu複製.Text = "複製"
        Me.T2Bu複製.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.T2La單號)
        Me.GroupBox1.Controls.Add(Me.T2Tb日期)
        Me.GroupBox1.Controls.Add(Me.T2Tb時間)
        Me.GroupBox1.Controls.Add(Me.T2Tb樓層)
        Me.GroupBox1.Location = New System.Drawing.Point(562, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 230)
        Me.GroupBox1.TabIndex = 1090
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "數據"
        Me.GroupBox1.Visible = False
        '
        'T2Tb日期
        '
        Me.T2Tb日期.AutoSize = True
        Me.T2Tb日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Tb日期.Location = New System.Drawing.Point(6, 23)
        Me.T2Tb日期.Name = "T2Tb日期"
        Me.T2Tb日期.Size = New System.Drawing.Size(42, 16)
        Me.T2Tb日期.TabIndex = 1087
        Me.T2Tb日期.Text = "日期"
        '
        'T2Tb時間
        '
        Me.T2Tb時間.AutoSize = True
        Me.T2Tb時間.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Tb時間.Location = New System.Drawing.Point(6, 39)
        Me.T2Tb時間.Name = "T2Tb時間"
        Me.T2Tb時間.Size = New System.Drawing.Size(42, 16)
        Me.T2Tb時間.TabIndex = 1089
        Me.T2Tb時間.Text = "時間"
        '
        'T2Tb樓層
        '
        Me.T2Tb樓層.AutoSize = True
        Me.T2Tb樓層.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Tb樓層.Location = New System.Drawing.Point(6, 55)
        Me.T2Tb樓層.Name = "T2Tb樓層"
        Me.T2Tb樓層.Size = New System.Drawing.Size(42, 16)
        Me.T2Tb樓層.TabIndex = 1088
        Me.T2Tb樓層.Text = "樓層"
        '
        'T2Tb單號
        '
        Me.T2Tb單號.AutoSize = True
        Me.T2Tb單號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Tb單號.Location = New System.Drawing.Point(568, 9)
        Me.T2Tb單號.Name = "T2Tb單號"
        Me.T2Tb單號.Size = New System.Drawing.Size(42, 16)
        Me.T2Tb單號.TabIndex = 1071
        Me.T2Tb單號.Text = "單號"
        '
        'T2Bu列印
        '
        Me.T2Bu列印.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Bu列印.Location = New System.Drawing.Point(462, 3)
        Me.T2Bu列印.Name = "T2Bu列印"
        Me.T2Bu列印.Size = New System.Drawing.Size(100, 30)
        Me.T2Bu列印.TabIndex = 1080
        Me.T2Bu列印.TabStop = False
        Me.T2Bu列印.Text = "列印"
        Me.T2Bu列印.UseVisualStyleBackColor = True
        '
        'T2Bu刪除
        '
        Me.T2Bu刪除.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Bu刪除.Location = New System.Drawing.Point(1061, 3)
        Me.T2Bu刪除.Name = "T2Bu刪除"
        Me.T2Bu刪除.Size = New System.Drawing.Size(100, 30)
        Me.T2Bu刪除.TabIndex = 1086
        Me.T2Bu刪除.Text = "刪除"
        Me.T2Bu刪除.UseVisualStyleBackColor = True
        '
        'T2Dt生產
        '
        Me.T2Dt生產.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Dt生產.Location = New System.Drawing.Point(62, 4)
        Me.T2Dt生產.Name = "T2Dt生產"
        Me.T2Dt生產.Size = New System.Drawing.Size(149, 27)
        Me.T2Dt生產.TabIndex = 1075
        Me.T2Dt生產.TabStop = False
        '
        'T2Cb樓層
        '
        Me.T2Cb樓層.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T2Cb樓層.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Cb樓層.FormattingEnabled = True
        Me.T2Cb樓層.Items.AddRange(New Object() {"ALL", "一樓", "二樓", "三樓"})
        Me.T2Cb樓層.Location = New System.Drawing.Point(268, 5)
        Me.T2Cb樓層.Name = "T2Cb樓層"
        Me.T2Cb樓層.Size = New System.Drawing.Size(80, 24)
        Me.T2Cb樓層.TabIndex = 1072
        Me.T2Cb樓層.TabStop = False
        '
        'T2線上明細
        '
        Me.T2線上明細.AllowUserToAddRows = False
        Me.T2線上明細.AllowUserToDeleteRows = False
        Me.T2線上明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2線上明細.Location = New System.Drawing.Point(6, 37)
        Me.T2線上明細.MultiSelect = False
        Me.T2線上明細.Name = "T2線上明細"
        Me.T2線上明細.RowHeadersVisible = False
        Me.T2線上明細.RowTemplate.Height = 24
        Me.T2線上明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2線上明細.Size = New System.Drawing.Size(1155, 542)
        Me.T2線上明細.TabIndex = 1072
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(217, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 1073
        Me.Label9.Text = "樓層："
        '
        'T2Bu查詢
        '
        Me.T2Bu查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2Bu查詢.Location = New System.Drawing.Point(356, 3)
        Me.T2Bu查詢.Name = "T2Bu查詢"
        Me.T2Bu查詢.Size = New System.Drawing.Size(100, 30)
        Me.T2Bu查詢.TabIndex = 1077
        Me.T2Bu查詢.TabStop = False
        Me.T2Bu查詢.Text = "查詢"
        Me.T2Bu查詢.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 1076
        Me.Label8.Text = "日期："
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RB查詢)
        Me.Panel1.Controls.Add(Me.RB作業)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 26)
        Me.Panel1.TabIndex = 1
        '
        'RB查詢
        '
        Me.RB查詢.AutoSize = True
        Me.RB查詢.Location = New System.Drawing.Point(101, 2)
        Me.RB查詢.Name = "RB查詢"
        Me.RB查詢.Size = New System.Drawing.Size(90, 20)
        Me.RB查詢.TabIndex = 1
        Me.RB查詢.Text = "派單查詢"
        Me.RB查詢.UseVisualStyleBackColor = True
        '
        'RB作業
        '
        Me.RB作業.AutoSize = True
        Me.RB作業.Checked = True
        Me.RB作業.Location = New System.Drawing.Point(5, 2)
        Me.RB作業.Name = "RB作業"
        Me.RB作業.Size = New System.Drawing.Size(90, 20)
        Me.RB作業.TabIndex = 0
        Me.RB作業.TabStop = True
        Me.RB作業.Text = "派單作業"
        Me.RB作業.UseVisualStyleBackColor = True
        '
        'Lt作業
        '
        Me.Lt作業.AutoSize = True
        Me.Lt作業.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt作業.Location = New System.Drawing.Point(291, 4)
        Me.Lt作業.Name = "Lt作業"
        Me.Lt作業.Size = New System.Drawing.Size(42, 16)
        Me.Lt作業.TabIndex = 1069
        Me.Lt作業.Text = "未選"
        Me.Lt作業.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(206, 4)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(93, 16)
        Me.Label31.TabIndex = 1068
        Me.Label31.Text = "目前作業："
        Me.Label31.Visible = False
        '
        'PrintDialog
        '
        Me.PrintDialog.UseEXDialog = True
        '
        'T2複製明細
        '
        Me.T2複製明細.AllowUserToAddRows = False
        Me.T2複製明細.AllowUserToDeleteRows = False
        Me.T2複製明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2複製明細.Location = New System.Drawing.Point(590, 37)
        Me.T2複製明細.MultiSelect = False
        Me.T2複製明細.Name = "T2複製明細"
        Me.T2複製明細.RowHeadersVisible = False
        Me.T2複製明細.RowTemplate.Height = 24
        Me.T2複製明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2複製明細.Size = New System.Drawing.Size(570, 542)
        Me.T2複製明細.TabIndex = 1092
        Me.T2複製明細.Visible = False
        '
        'T2La單號
        '
        Me.T2La單號.AutoSize = True
        Me.T2La單號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T2La單號.Location = New System.Drawing.Point(6, 105)
        Me.T2La單號.Name = "T2La單號"
        Me.T2La單號.Size = New System.Drawing.Size(42, 16)
        Me.T2La單號.TabIndex = 1090
        Me.T2La單號.Text = "單號"
        '
        '線上撿貨V001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 637)
        Me.Controls.Add(Me.Lt作業)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "線上撿貨V001"
        Me.Text = "線上撿貨"
        Me.TabControl1.ResumeLayout(False)
        Me.TP派單作業.ResumeLayout(False)
        Me.TP派單作業.PerformLayout()
        Me.T1Pa編輯.ResumeLayout(False)
        Me.T1Pa編輯.PerformLayout()
        CType(Me.T1項目明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.T1已排項目, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1未排項目, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP派單查詢.ResumeLayout(False)
        Me.TP派單查詢.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.T2線上明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.T2複製明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP派單作業 As System.Windows.Forms.TabPage
    Friend WithEvents TP派單查詢 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RB查詢 As System.Windows.Forms.RadioButton
    Friend WithEvents RB作業 As System.Windows.Forms.RadioButton
    Friend WithEvents Lt作業 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents T1未排項目 As System.Windows.Forms.DataGridView
    Friend WithEvents T1Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents T1Dt日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateDocDate_tb As System.Windows.Forms.Label
    Friend WithEvents T1已排項目 As System.Windows.Forms.DataGridView
    Friend WithEvents T1Bu撿貨 As System.Windows.Forms.Button
    Friend WithEvents T1Bu移除 As System.Windows.Forms.Button
    Friend WithEvents T1Bu編輯 As System.Windows.Forms.Button
    Friend WithEvents T1Bu存檔 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents T1Cb樓層 As System.Windows.Forms.ComboBox
    Friend WithEvents Floor_tb As System.Windows.Forms.Label
    Friend WithEvents T1La單號 As System.Windows.Forms.Label
    Friend WithEvents PrintDialog As System.Windows.Forms.PrintDialog
    Friend WithEvents T1La時間 As System.Windows.Forms.Label
    Friend WithEvents T1Pa編輯 As System.Windows.Forms.Panel
    Friend WithEvents T1Cb客戶 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents T1Cx包含 As System.Windows.Forms.CheckBox
    Friend WithEvents T1Tb查3 As System.Windows.Forms.TextBox
    Friend WithEvents T1Tb查2 As System.Windows.Forms.TextBox
    Friend WithEvents T1Tb查1 As System.Windows.Forms.TextBox
    Friend WithEvents T1Bu查詢品項 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents T1Tb備註 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents T1Tb數量 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents T1Tb項目 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents T1Tb品名 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T1Tb存編 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T1項目明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T1Bu新增 As System.Windows.Forms.Button
    Friend WithEvents T1Dt生產 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents T2Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents T2Dt生產 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents T2Cb樓層 As System.Windows.Forms.ComboBox
    Friend WithEvents T2線上明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents T2Bu刪除 As System.Windows.Forms.Button
    Friend WithEvents T2Bu列印 As System.Windows.Forms.Button
    Friend WithEvents T2Tb單號 As System.Windows.Forms.Label
    Friend WithEvents T2Tb時間 As System.Windows.Forms.Label
    Friend WithEvents T2Tb樓層 As System.Windows.Forms.Label
    Friend WithEvents T2Tb日期 As System.Windows.Forms.Label
    Friend WithEvents T2Bu複製 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents T2複製明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T2La單號 As System.Windows.Forms.Label
End Class
