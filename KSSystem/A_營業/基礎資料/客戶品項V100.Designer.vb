<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 客戶品項V100
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
        Me.TB1確定 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TP客戶 = New System.Windows.Forms.TabPage
        Me.Bu110大 = New System.Windows.Forms.Button
        Me.Bu1超市 = New System.Windows.Forms.Button
        Me.Bu1常用 = New System.Windows.Forms.Button
        Me.TB1名稱 = New System.Windows.Forms.TextBox
        Me.Bu1查詢 = New System.Windows.Forms.Button
        Me.TB1客編 = New System.Windows.Forms.TextBox
        Me.T1客戶明細 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TP品項 = New System.Windows.Forms.TabPage
        Me.Bu2新增 = New System.Windows.Forms.Button
        Me.T2品項群組 = New System.Windows.Forms.DataGridView
        Me.T2品項新增 = New System.Windows.Forms.DataGridView
        Me.T2品項項目 = New System.Windows.Forms.DataGridView
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TP新增 = New System.Windows.Forms.TabPage
        Me.Bu2設定 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TB2群名 = New System.Windows.Forms.TextBox
        Me.Bu2品項 = New System.Windows.Forms.Button
        Me.TP查詢 = New System.Windows.Forms.TabPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.Bu2查詢 = New System.Windows.Forms.Button
        Me.TB2品名1 = New System.Windows.Forms.TextBox
        Me.CB2保存 = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CB2製程 = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CB2包含查詢 = New System.Windows.Forms.CheckBox
        Me.La2群名 = New System.Windows.Forms.Label
        Me.Bu2移除 = New System.Windows.Forms.Button
        Me.TP預設 = New System.Windows.Forms.TabPage
        Me.TP品組 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Bu4新增 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TP客組 = New System.Windows.Forms.TabPage
        Me.TB名稱 = New System.Windows.Forms.TextBox
        Me.TB客編 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.La2編碼 = New System.Windows.Forms.Label
        Me.TB2品名2 = New System.Windows.Forms.TextBox
        Me.TB2品名3 = New System.Windows.Forms.TextBox
        Me.Bu2存檔 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TP客戶.SuspendLayout()
        CType(Me.T1客戶明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP品項.SuspendLayout()
        CType(Me.T2品項群組, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2品項新增, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2品項項目, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TP新增.SuspendLayout()
        Me.TP查詢.SuspendLayout()
        Me.TP品組.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB1確定
        '
        Me.TB1確定.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB1確定.Location = New System.Drawing.Point(184, 33)
        Me.TB1確定.Name = "TB1確定"
        Me.TB1確定.Size = New System.Drawing.Size(84, 37)
        Me.TB1確定.TabIndex = 21
        Me.TB1確定.Text = "確定"
        Me.TB1確定.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TP客戶)
        Me.TabControl1.Controls.Add(Me.TP品項)
        Me.TabControl1.Controls.Add(Me.TP預設)
        Me.TabControl1.Controls.Add(Me.TP品組)
        Me.TabControl1.Controls.Add(Me.TP客組)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, -5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(974, 646)
        Me.TabControl1.TabIndex = 23
        '
        'TP客戶
        '
        Me.TP客戶.Controls.Add(Me.Bu110大)
        Me.TP客戶.Controls.Add(Me.Bu1超市)
        Me.TP客戶.Controls.Add(Me.Bu1常用)
        Me.TP客戶.Controls.Add(Me.TB1名稱)
        Me.TP客戶.Controls.Add(Me.Bu1查詢)
        Me.TP客戶.Controls.Add(Me.TB1客編)
        Me.TP客戶.Controls.Add(Me.T1客戶明細)
        Me.TP客戶.Controls.Add(Me.Label6)
        Me.TP客戶.Controls.Add(Me.Label7)
        Me.TP客戶.Controls.Add(Me.TB1確定)
        Me.TP客戶.Location = New System.Drawing.Point(4, 4)
        Me.TP客戶.Name = "TP客戶"
        Me.TP客戶.Padding = New System.Windows.Forms.Padding(3)
        Me.TP客戶.Size = New System.Drawing.Size(966, 616)
        Me.TP客戶.TabIndex = 0
        Me.TP客戶.Text = "客戶資料"
        Me.TP客戶.UseVisualStyleBackColor = True
        '
        'Bu110大
        '
        Me.Bu110大.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu110大.Location = New System.Drawing.Point(9, 300)
        Me.Bu110大.Name = "Bu110大"
        Me.Bu110大.Size = New System.Drawing.Size(84, 37)
        Me.Bu110大.TabIndex = 113
        Me.Bu110大.Text = "10大"
        Me.Bu110大.UseVisualStyleBackColor = True
        '
        'Bu1超市
        '
        Me.Bu1超市.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1超市.Location = New System.Drawing.Point(9, 257)
        Me.Bu1超市.Name = "Bu1超市"
        Me.Bu1超市.Size = New System.Drawing.Size(84, 37)
        Me.Bu1超市.TabIndex = 112
        Me.Bu1超市.Text = "超市"
        Me.Bu1超市.UseVisualStyleBackColor = True
        '
        'Bu1常用
        '
        Me.Bu1常用.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1常用.Location = New System.Drawing.Point(9, 214)
        Me.Bu1常用.Name = "Bu1常用"
        Me.Bu1常用.Size = New System.Drawing.Size(84, 37)
        Me.Bu1常用.TabIndex = 111
        Me.Bu1常用.Text = "常用"
        Me.Bu1常用.UseVisualStyleBackColor = True
        '
        'TB1名稱
        '
        Me.TB1名稱.Location = New System.Drawing.Point(91, 138)
        Me.TB1名稱.Name = "TB1名稱"
        Me.TB1名稱.Size = New System.Drawing.Size(177, 27)
        Me.TB1名稱.TabIndex = 107
        '
        'Bu1查詢
        '
        Me.Bu1查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1查詢.Location = New System.Drawing.Point(184, 171)
        Me.Bu1查詢.Name = "Bu1查詢"
        Me.Bu1查詢.Size = New System.Drawing.Size(84, 37)
        Me.Bu1查詢.TabIndex = 110
        Me.Bu1查詢.Text = "查詢"
        Me.Bu1查詢.UseVisualStyleBackColor = True
        '
        'TB1客編
        '
        Me.TB1客編.Location = New System.Drawing.Point(91, 108)
        Me.TB1客編.Name = "TB1客編"
        Me.TB1客編.Size = New System.Drawing.Size(177, 27)
        Me.TB1客編.TabIndex = 106
        '
        'T1客戶明細
        '
        Me.T1客戶明細.AllowUserToAddRows = False
        Me.T1客戶明細.AllowUserToDeleteRows = False
        Me.T1客戶明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1客戶明細.Location = New System.Drawing.Point(274, 33)
        Me.T1客戶明細.MultiSelect = False
        Me.T1客戶明細.Name = "T1客戶明細"
        Me.T1客戶明細.ReadOnly = True
        Me.T1客戶明細.RowHeadersVisible = False
        Me.T1客戶明細.RowTemplate.Height = 24
        Me.T1客戶明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1客戶明細.Size = New System.Drawing.Size(684, 577)
        Me.T1客戶明細.TabIndex = 103
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "查詢名稱："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "查詢客編："
        '
        'TP品項
        '
        Me.TP品項.Controls.Add(Me.Bu2存檔)
        Me.TP品項.Controls.Add(Me.La2編碼)
        Me.TP品項.Controls.Add(Me.Bu2新增)
        Me.TP品項.Controls.Add(Me.T2品項群組)
        Me.TP品項.Controls.Add(Me.T2品項新增)
        Me.TP品項.Controls.Add(Me.T2品項項目)
        Me.TP品項.Controls.Add(Me.TabControl2)
        Me.TP品項.Controls.Add(Me.La2群名)
        Me.TP品項.Controls.Add(Me.Bu2移除)
        Me.TP品項.Location = New System.Drawing.Point(4, 4)
        Me.TP品項.Name = "TP品項"
        Me.TP品項.Padding = New System.Windows.Forms.Padding(3)
        Me.TP品項.Size = New System.Drawing.Size(966, 616)
        Me.TP品項.TabIndex = 1
        Me.TP品項.Text = "品項設定"
        Me.TP品項.UseVisualStyleBackColor = True
        '
        'Bu2新增
        '
        Me.Bu2新增.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2新增.Location = New System.Drawing.Point(7, 576)
        Me.Bu2新增.Name = "Bu2新增"
        Me.Bu2新增.Size = New System.Drawing.Size(84, 37)
        Me.Bu2新增.TabIndex = 1012
        Me.Bu2新增.TabStop = False
        Me.Bu2新增.Text = "新增"
        Me.Bu2新增.UseVisualStyleBackColor = True
        '
        'T2品項群組
        '
        Me.T2品項群組.AllowUserToAddRows = False
        Me.T2品項群組.AllowUserToDeleteRows = False
        Me.T2品項群組.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2品項群組.Location = New System.Drawing.Point(6, 136)
        Me.T2品項群組.MultiSelect = False
        Me.T2品項群組.Name = "T2品項群組"
        Me.T2品項群組.ReadOnly = True
        Me.T2品項群組.RowHeadersVisible = False
        Me.T2品項群組.RowTemplate.Height = 24
        Me.T2品項群組.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2品項群組.Size = New System.Drawing.Size(275, 474)
        Me.T2品項群組.TabIndex = 1006
        '
        'T2品項新增
        '
        Me.T2品項新增.AllowUserToAddRows = False
        Me.T2品項新增.AllowUserToDeleteRows = False
        Me.T2品項新增.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2品項新增.Location = New System.Drawing.Point(6, 136)
        Me.T2品項新增.MultiSelect = False
        Me.T2品項新增.Name = "T2品項新增"
        Me.T2品項新增.RowHeadersVisible = False
        Me.T2品項新增.RowTemplate.Height = 24
        Me.T2品項新增.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2品項新增.Size = New System.Drawing.Size(475, 438)
        Me.T2品項新增.TabIndex = 1011
        '
        'T2品項項目
        '
        Me.T2品項項目.AllowUserToAddRows = False
        Me.T2品項項目.AllowUserToDeleteRows = False
        Me.T2品項項目.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2品項項目.Location = New System.Drawing.Point(485, 136)
        Me.T2品項項目.MultiSelect = False
        Me.T2品項項目.Name = "T2品項項目"
        Me.T2品項項目.RowHeadersVisible = False
        Me.T2品項項目.RowTemplate.Height = 24
        Me.T2品項項目.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2品項項目.Size = New System.Drawing.Size(475, 438)
        Me.T2品項項目.TabIndex = 1010
        '
        'TabControl2
        '
        Me.TabControl2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl2.Controls.Add(Me.TP新增)
        Me.TabControl2.Controls.Add(Me.TP查詢)
        Me.TabControl2.Location = New System.Drawing.Point(-4, 26)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(486, 114)
        Me.TabControl2.TabIndex = 1028
        '
        'TP新增
        '
        Me.TP新增.BackColor = System.Drawing.SystemColors.Window
        Me.TP新增.Controls.Add(Me.Bu2設定)
        Me.TP新增.Controls.Add(Me.Label4)
        Me.TP新增.Controls.Add(Me.TB2群名)
        Me.TP新增.Controls.Add(Me.Bu2品項)
        Me.TP新增.Location = New System.Drawing.Point(4, 29)
        Me.TP新增.Name = "TP新增"
        Me.TP新增.Padding = New System.Windows.Forms.Padding(3)
        Me.TP新增.Size = New System.Drawing.Size(478, 81)
        Me.TP新增.TabIndex = 0
        Me.TP新增.Text = "新增組合品名稱："
        Me.TP新增.UseVisualStyleBackColor = True
        '
        'Bu2設定
        '
        Me.Bu2設定.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2設定.Location = New System.Drawing.Point(388, 38)
        Me.Bu2設定.Name = "Bu2設定"
        Me.Bu2設定.Size = New System.Drawing.Size(84, 37)
        Me.Bu2設定.TabIndex = 1026
        Me.Bu2設定.Text = "設定"
        Me.Bu2設定.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(129, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 16)
        Me.Label4.TabIndex = 1016
        Me.Label4.Text = "新增組合品名稱："
        Me.Label4.Visible = False
        '
        'TB2群名
        '
        Me.TB2群名.Location = New System.Drawing.Point(5, 2)
        Me.TB2群名.Name = "TB2群名"
        Me.TB2群名.Size = New System.Drawing.Size(381, 27)
        Me.TB2群名.TabIndex = 1017
        '
        'Bu2品項
        '
        Me.Bu2品項.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2品項.Location = New System.Drawing.Point(3, 32)
        Me.Bu2品項.Name = "Bu2品項"
        Me.Bu2品項.Size = New System.Drawing.Size(120, 37)
        Me.Bu2品項.TabIndex = 1016
        Me.Bu2品項.Text = "新增群名"
        Me.Bu2品項.UseVisualStyleBackColor = True
        '
        'TP查詢
        '
        Me.TP查詢.BackColor = System.Drawing.SystemColors.Window
        Me.TP查詢.Controls.Add(Me.TB2品名3)
        Me.TP查詢.Controls.Add(Me.TB2品名2)
        Me.TP查詢.Controls.Add(Me.Label10)
        Me.TP查詢.Controls.Add(Me.Bu2查詢)
        Me.TP查詢.Controls.Add(Me.TB2品名1)
        Me.TP查詢.Controls.Add(Me.CB2保存)
        Me.TP查詢.Controls.Add(Me.Label12)
        Me.TP查詢.Controls.Add(Me.CB2製程)
        Me.TP查詢.Controls.Add(Me.Label11)
        Me.TP查詢.Controls.Add(Me.CB2包含查詢)
        Me.TP查詢.Location = New System.Drawing.Point(4, 29)
        Me.TP查詢.Name = "TP查詢"
        Me.TP查詢.Padding = New System.Windows.Forms.Padding(3)
        Me.TP查詢.Size = New System.Drawing.Size(478, 81)
        Me.TP查詢.TabIndex = 1
        Me.TP查詢.Text = "查詢品項"
        Me.TP查詢.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 26)
        Me.Label10.TabIndex = 1024
        Me.Label10.Text = "保存" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "方式"
        '
        'Bu2查詢
        '
        Me.Bu2查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2查詢.Location = New System.Drawing.Point(294, 20)
        Me.Bu2查詢.Name = "Bu2查詢"
        Me.Bu2查詢.Size = New System.Drawing.Size(84, 30)
        Me.Bu2查詢.TabIndex = 1030
        Me.Bu2查詢.Text = "查詢"
        Me.Bu2查詢.UseVisualStyleBackColor = True
        '
        'TB2品名1
        '
        Me.TB2品名1.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名1.Location = New System.Drawing.Point(7, 54)
        Me.TB2品名1.Name = "TB2品名1"
        Me.TB2品名1.Size = New System.Drawing.Size(193, 23)
        Me.TB2品名1.TabIndex = 1025
        '
        'CB2保存
        '
        Me.CB2保存.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2保存.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2保存.FormattingEnabled = True
        Me.CB2保存.Location = New System.Drawing.Point(45, 3)
        Me.CB2保存.Name = "CB2保存"
        Me.CB2保存.Size = New System.Drawing.Size(95, 21)
        Me.CB2保存.TabIndex = 1021
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(396, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 16)
        Me.Label12.TabIndex = 1020
        Me.Label12.Text = "查詢品項"
        Me.Label12.Visible = False
        '
        'CB2製程
        '
        Me.CB2製程.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2製程.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2製程.FormattingEnabled = True
        Me.CB2製程.Location = New System.Drawing.Point(45, 29)
        Me.CB2製程.Name = "CB2製程"
        Me.CB2製程.Size = New System.Drawing.Size(95, 21)
        Me.CB2製程.TabIndex = 1022
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 16)
        Me.Label11.TabIndex = 1025
        Me.Label11.Text = "製程"
        '
        'CB2包含查詢
        '
        Me.CB2包含查詢.AutoSize = True
        Me.CB2包含查詢.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2包含查詢.Location = New System.Drawing.Point(206, 33)
        Me.CB2包含查詢.Name = "CB2包含查詢"
        Me.CB2包含查詢.Size = New System.Drawing.Size(82, 17)
        Me.CB2包含查詢.TabIndex = 1020
        Me.CB2包含查詢.Text = "包含查詢"
        Me.CB2包含查詢.UseVisualStyleBackColor = True
        '
        'La2群名
        '
        Me.La2群名.AutoSize = True
        Me.La2群名.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La2群名.Location = New System.Drawing.Point(481, 114)
        Me.La2群名.Name = "La2群名"
        Me.La2群名.Size = New System.Drawing.Size(109, 19)
        Me.La2群名.TabIndex = 1027
        Me.La2群名.Text = "群組品名稱"
        '
        'Bu2移除
        '
        Me.Bu2移除.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2移除.Location = New System.Drawing.Point(485, 576)
        Me.Bu2移除.Name = "Bu2移除"
        Me.Bu2移除.Size = New System.Drawing.Size(84, 37)
        Me.Bu2移除.TabIndex = 1006
        Me.Bu2移除.TabStop = False
        Me.Bu2移除.Text = "移除"
        Me.Bu2移除.UseVisualStyleBackColor = True
        '
        'TP預設
        '
        Me.TP預設.Location = New System.Drawing.Point(4, 4)
        Me.TP預設.Name = "TP預設"
        Me.TP預設.Size = New System.Drawing.Size(966, 616)
        Me.TP預設.TabIndex = 2
        Me.TP預設.Text = "品項預設"
        Me.TP預設.UseVisualStyleBackColor = True
        '
        'TP品組
        '
        Me.TP品組.Controls.Add(Me.Button2)
        Me.TP品組.Controls.Add(Me.Button1)
        Me.TP品組.Controls.Add(Me.Bu4新增)
        Me.TP品組.Controls.Add(Me.DataGridView1)
        Me.TP品組.Controls.Add(Me.Label3)
        Me.TP品組.Controls.Add(Me.TextBox1)
        Me.TP品組.Location = New System.Drawing.Point(4, 4)
        Me.TP品組.Name = "TP品組"
        Me.TP品組.Size = New System.Drawing.Size(966, 616)
        Me.TP品組.TabIndex = 3
        Me.TP品組.Text = "品項群組"
        Me.TP品組.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button2.Location = New System.Drawing.Point(747, 137)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 37)
        Me.Button2.TabIndex = 1015
        Me.Button2.Text = "刪除"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(747, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 37)
        Me.Button1.TabIndex = 1014
        Me.Button1.Text = "修改"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Bu4新增
        '
        Me.Bu4新增.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu4新增.Location = New System.Drawing.Point(188, 120)
        Me.Bu4新增.Name = "Bu4新增"
        Me.Bu4新增.Size = New System.Drawing.Size(84, 37)
        Me.Bu4新增.TabIndex = 116
        Me.Bu4新增.Text = "新增"
        Me.Bu4新增.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(278, 31)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.Size = New System.Drawing.Size(463, 582)
        Me.DataGridView1.TabIndex = 1013
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 16)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "新增組合品名稱："
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 87)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(265, 27)
        Me.TextBox1.TabIndex = 115
        '
        'TP客組
        '
        Me.TP客組.Location = New System.Drawing.Point(4, 4)
        Me.TP客組.Name = "TP客組"
        Me.TP客組.Size = New System.Drawing.Size(966, 616)
        Me.TP客組.TabIndex = 4
        Me.TP客組.Text = "客戶群組"
        Me.TP客組.UseVisualStyleBackColor = True
        '
        'TB名稱
        '
        Me.TB名稱.BackColor = System.Drawing.Color.White
        Me.TB名稱.Location = New System.Drawing.Point(309, 2)
        Me.TB名稱.Name = "TB名稱"
        Me.TB名稱.ReadOnly = True
        Me.TB名稱.Size = New System.Drawing.Size(431, 22)
        Me.TB名稱.TabIndex = 1005
        Me.TB名稱.TabStop = False
        '
        'TB客編
        '
        Me.TB客編.BackColor = System.Drawing.Color.White
        Me.TB客編.Location = New System.Drawing.Point(88, 2)
        Me.TB客編.Name = "TB客編"
        Me.TB客編.ReadOnly = True
        Me.TB客編.Size = New System.Drawing.Size(130, 22)
        Me.TB客編.TabIndex = 1004
        Me.TB客編.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(224, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 1003
        Me.Label2.Text = "客戶名稱："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 1002
        Me.Label1.Text = "客戶編號："
        '
        'La2編碼
        '
        Me.La2編碼.AutoSize = True
        Me.La2編碼.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La2編碼.Location = New System.Drawing.Point(481, 93)
        Me.La2編碼.Name = "La2編碼"
        Me.La2編碼.Size = New System.Drawing.Size(109, 19)
        Me.La2編碼.TabIndex = 1029
        Me.La2編碼.Text = "群組品編碼"
        Me.La2編碼.Visible = False
        '
        'TB2品名2
        '
        Me.TB2品名2.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名2.Location = New System.Drawing.Point(206, 54)
        Me.TB2品名2.Name = "TB2品名2"
        Me.TB2品名2.Size = New System.Drawing.Size(130, 23)
        Me.TB2品名2.TabIndex = 1026
        Me.TB2品名2.Visible = False
        '
        'TB2品名3
        '
        Me.TB2品名3.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名3.Location = New System.Drawing.Point(342, 54)
        Me.TB2品名3.Name = "TB2品名3"
        Me.TB2品名3.Size = New System.Drawing.Size(130, 23)
        Me.TB2品名3.TabIndex = 1027
        Me.TB2品名3.Visible = False
        '
        'Bu2存檔
        '
        Me.Bu2存檔.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2存檔.Location = New System.Drawing.Point(876, 72)
        Me.Bu2存檔.Name = "Bu2存檔"
        Me.Bu2存檔.Size = New System.Drawing.Size(84, 37)
        Me.Bu2存檔.TabIndex = 1030
        Me.Bu2存檔.TabStop = False
        Me.Bu2存檔.Text = "存檔"
        Me.Bu2存檔.UseVisualStyleBackColor = True
        '
        '客戶品項V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 637)
        Me.Controls.Add(Me.TB名稱)
        Me.Controls.Add(Me.TB客編)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "客戶品項V100"
        Me.Text = "客戶品項V100"
        Me.TabControl1.ResumeLayout(False)
        Me.TP客戶.ResumeLayout(False)
        Me.TP客戶.PerformLayout()
        CType(Me.T1客戶明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP品項.ResumeLayout(False)
        Me.TP品項.PerformLayout()
        CType(Me.T2品項群組, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2品項新增, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2品項項目, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.TP新增.ResumeLayout(False)
        Me.TP新增.PerformLayout()
        Me.TP查詢.ResumeLayout(False)
        Me.TP查詢.PerformLayout()
        Me.TP品組.ResumeLayout(False)
        Me.TP品組.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TB1確定 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP客戶 As System.Windows.Forms.TabPage
    Friend WithEvents TP品項 As System.Windows.Forms.TabPage
    Friend WithEvents Bu110大 As System.Windows.Forms.Button
    Friend WithEvents Bu1超市 As System.Windows.Forms.Button
    Friend WithEvents Bu1常用 As System.Windows.Forms.Button
    Friend WithEvents TB1名稱 As System.Windows.Forms.TextBox
    Friend WithEvents Bu1查詢 As System.Windows.Forms.Button
    Friend WithEvents TB1客編 As System.Windows.Forms.TextBox
    Friend WithEvents T1客戶明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TP預設 As System.Windows.Forms.TabPage
    Friend WithEvents TP品組 As System.Windows.Forms.TabPage
    Friend WithEvents TP客組 As System.Windows.Forms.TabPage
    Friend WithEvents TB名稱 As System.Windows.Forms.TextBox
    Friend WithEvents TB客編 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Bu2新增 As System.Windows.Forms.Button
    Friend WithEvents Bu2移除 As System.Windows.Forms.Button
    Friend WithEvents T2品項新增 As System.Windows.Forms.DataGridView
    Friend WithEvents T2品項項目 As System.Windows.Forms.DataGridView
    Friend WithEvents T2品項群組 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Bu4新增 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Bu2品項 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TB2群名 As System.Windows.Forms.TextBox
    Friend WithEvents TB2品名1 As System.Windows.Forms.TextBox
    Friend WithEvents Bu2查詢 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CB2包含查詢 As System.Windows.Forms.CheckBox
    Friend WithEvents CB2製程 As System.Windows.Forms.ComboBox
    Friend WithEvents CB2保存 As System.Windows.Forms.ComboBox
    Friend WithEvents Bu2設定 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents La2群名 As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TP新增 As System.Windows.Forms.TabPage
    Friend WithEvents TP查詢 As System.Windows.Forms.TabPage
    Friend WithEvents La2編碼 As System.Windows.Forms.Label
    Friend WithEvents TB2品名3 As System.Windows.Forms.TextBox
    Friend WithEvents TB2品名2 As System.Windows.Forms.TextBox
    Friend WithEvents Bu2存檔 As System.Windows.Forms.Button
End Class
