<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 營業訂單V103
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB客編 = New System.Windows.Forms.TextBox
        Me.TB名稱 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CB1司機 = New System.Windows.Forms.ComboBox
        Me.CB2司機 = New System.Windows.Forms.ComboBox
        Me.CB3司機 = New System.Windows.Forms.ComboBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TP客戶 = New System.Windows.Forms.TabPage
        Me.TB1名稱3 = New System.Windows.Forms.TextBox
        Me.Bu110大 = New System.Windows.Forms.Button
        Me.Bu1超市 = New System.Windows.Forms.Button
        Me.Bu1常用 = New System.Windows.Forms.Button
        Me.Bu1確定 = New System.Windows.Forms.Button
        Me.TB1名稱2 = New System.Windows.Forms.TextBox
        Me.TB1名稱1 = New System.Windows.Forms.TextBox
        Me.Bu1查詢 = New System.Windows.Forms.Button
        Me.TB1客編0 = New System.Windows.Forms.TextBox
        Me.T1客戶明細 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TP品項 = New System.Windows.Forms.TabPage
        Me.Bu2新增 = New System.Windows.Forms.Button
        Me.CB2包含查詢 = New System.Windows.Forms.CheckBox
        Me.TB2品名3 = New System.Windows.Forms.TextBox
        Me.TB2品名2 = New System.Windows.Forms.TextBox
        Me.TB2品名1 = New System.Windows.Forms.TextBox
        Me.CB2製程 = New System.Windows.Forms.ComboBox
        Me.CB2保存 = New System.Windows.Forms.ComboBox
        Me.Bu2查詢 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.T2品項明細 = New System.Windows.Forms.DataGridView
        Me.T2訂單明細 = New System.Windows.Forms.DataGridView
        Me.Bu2放棄 = New System.Windows.Forms.Button
        Me.TP查詢 = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.Bu回存草稿 = New System.Windows.Forms.Button
        Me.CB人員 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.DocDueDate = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.LA生產 = New System.Windows.Forms.Label
        Me.TB2備註 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TP客戶.SuspendLayout()
        CType(Me.T1客戶明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP品項.SuspendLayout()
        CType(Me.T2品項明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2訂單明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "客戶編號："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "客戶名稱："
        '
        'TB客編
        '
        Me.TB客編.BackColor = System.Drawing.Color.White
        Me.TB客編.Location = New System.Drawing.Point(87, 5)
        Me.TB客編.Name = "TB客編"
        Me.TB客編.ReadOnly = True
        Me.TB客編.Size = New System.Drawing.Size(197, 22)
        Me.TB客編.TabIndex = 1000
        Me.TB客編.TabStop = False
        '
        'TB名稱
        '
        Me.TB名稱.BackColor = System.Drawing.Color.White
        Me.TB名稱.Location = New System.Drawing.Point(87, 33)
        Me.TB名稱.Name = "TB名稱"
        Me.TB名稱.ReadOnly = True
        Me.TB名稱.Size = New System.Drawing.Size(197, 22)
        Me.TB名稱.TabIndex = 1001
        Me.TB名稱.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(288, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "司機 1："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "司機 2："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(288, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "司機 3："
        '
        'CB1司機
        '
        Me.CB1司機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB1司機.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB1司機.FormattingEnabled = True
        Me.CB1司機.Location = New System.Drawing.Point(354, 2)
        Me.CB1司機.Name = "CB1司機"
        Me.CB1司機.Size = New System.Drawing.Size(131, 24)
        Me.CB1司機.TabIndex = 10
        '
        'CB2司機
        '
        Me.CB2司機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2司機.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2司機.FormattingEnabled = True
        Me.CB2司機.Location = New System.Drawing.Point(354, 29)
        Me.CB2司機.Name = "CB2司機"
        Me.CB2司機.Size = New System.Drawing.Size(131, 24)
        Me.CB2司機.TabIndex = 11
        '
        'CB3司機
        '
        Me.CB3司機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB3司機.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB3司機.FormattingEnabled = True
        Me.CB3司機.Location = New System.Drawing.Point(354, 56)
        Me.CB3司機.Name = "CB3司機"
        Me.CB3司機.Size = New System.Drawing.Size(131, 24)
        Me.CB3司機.TabIndex = 12
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TP客戶)
        Me.TabControl1.Controls.Add(Me.TP品項)
        Me.TabControl1.Controls.Add(Me.TP查詢)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-2, 60)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(970, 586)
        Me.TabControl1.TabIndex = 10
        '
        'TP客戶
        '
        Me.TP客戶.Controls.Add(Me.TB1名稱3)
        Me.TP客戶.Controls.Add(Me.Bu110大)
        Me.TP客戶.Controls.Add(Me.Bu1超市)
        Me.TP客戶.Controls.Add(Me.Bu1常用)
        Me.TP客戶.Controls.Add(Me.Bu1確定)
        Me.TP客戶.Controls.Add(Me.TB1名稱2)
        Me.TP客戶.Controls.Add(Me.TB1名稱1)
        Me.TP客戶.Controls.Add(Me.Bu1查詢)
        Me.TP客戶.Controls.Add(Me.TB1客編0)
        Me.TP客戶.Controls.Add(Me.T1客戶明細)
        Me.TP客戶.Controls.Add(Me.Label6)
        Me.TP客戶.Controls.Add(Me.Label7)
        Me.TP客戶.Location = New System.Drawing.Point(4, 29)
        Me.TP客戶.Name = "TP客戶"
        Me.TP客戶.Padding = New System.Windows.Forms.Padding(3)
        Me.TP客戶.Size = New System.Drawing.Size(962, 553)
        Me.TP客戶.TabIndex = 0
        Me.TP客戶.Text = "客戶查詢"
        Me.TP客戶.UseVisualStyleBackColor = True
        '
        'TB1名稱3
        '
        Me.TB1名稱3.Location = New System.Drawing.Point(91, 165)
        Me.TB1名稱3.Name = "TB1名稱3"
        Me.TB1名稱3.Size = New System.Drawing.Size(122, 27)
        Me.TB1名稱3.TabIndex = 24
        '
        'Bu110大
        '
        Me.Bu110大.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu110大.Location = New System.Drawing.Point(9, 296)
        Me.Bu110大.Name = "Bu110大"
        Me.Bu110大.Size = New System.Drawing.Size(84, 37)
        Me.Bu110大.TabIndex = 102
        Me.Bu110大.Text = "10大"
        Me.Bu110大.UseVisualStyleBackColor = True
        '
        'Bu1超市
        '
        Me.Bu1超市.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1超市.Location = New System.Drawing.Point(10, 253)
        Me.Bu1超市.Name = "Bu1超市"
        Me.Bu1超市.Size = New System.Drawing.Size(84, 37)
        Me.Bu1超市.TabIndex = 101
        Me.Bu1超市.Text = "超市"
        Me.Bu1超市.UseVisualStyleBackColor = True
        '
        'Bu1常用
        '
        Me.Bu1常用.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1常用.Location = New System.Drawing.Point(10, 210)
        Me.Bu1常用.Name = "Bu1常用"
        Me.Bu1常用.Size = New System.Drawing.Size(84, 37)
        Me.Bu1常用.TabIndex = 100
        Me.Bu1常用.Text = "常用"
        Me.Bu1常用.UseVisualStyleBackColor = True
        '
        'Bu1確定
        '
        Me.Bu1確定.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1確定.Location = New System.Drawing.Point(129, 6)
        Me.Bu1確定.Name = "Bu1確定"
        Me.Bu1確定.Size = New System.Drawing.Size(84, 37)
        Me.Bu1確定.TabIndex = 20
        Me.Bu1確定.Text = "確定"
        Me.Bu1確定.UseVisualStyleBackColor = True
        '
        'TB1名稱2
        '
        Me.TB1名稱2.Location = New System.Drawing.Point(91, 137)
        Me.TB1名稱2.Name = "TB1名稱2"
        Me.TB1名稱2.Size = New System.Drawing.Size(122, 27)
        Me.TB1名稱2.TabIndex = 23
        '
        'TB1名稱1
        '
        Me.TB1名稱1.Location = New System.Drawing.Point(91, 109)
        Me.TB1名稱1.Name = "TB1名稱1"
        Me.TB1名稱1.Size = New System.Drawing.Size(122, 27)
        Me.TB1名稱1.TabIndex = 22
        '
        'Bu1查詢
        '
        Me.Bu1查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1查詢.Location = New System.Drawing.Point(129, 210)
        Me.Bu1查詢.Name = "Bu1查詢"
        Me.Bu1查詢.Size = New System.Drawing.Size(84, 37)
        Me.Bu1查詢.TabIndex = 25
        Me.Bu1查詢.Text = "查詢"
        Me.Bu1查詢.UseVisualStyleBackColor = True
        '
        'TB1客編0
        '
        Me.TB1客編0.Location = New System.Drawing.Point(91, 81)
        Me.TB1客編0.Name = "TB1客編0"
        Me.TB1客編0.Size = New System.Drawing.Size(122, 27)
        Me.TB1客編0.TabIndex = 21
        '
        'T1客戶明細
        '
        Me.T1客戶明細.AllowUserToAddRows = False
        Me.T1客戶明細.AllowUserToDeleteRows = False
        Me.T1客戶明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1客戶明細.Location = New System.Drawing.Point(219, 6)
        Me.T1客戶明細.MultiSelect = False
        Me.T1客戶明細.Name = "T1客戶明細"
        Me.T1客戶明細.ReadOnly = True
        Me.T1客戶明細.RowHeadersVisible = False
        Me.T1客戶明細.RowTemplate.Height = 24
        Me.T1客戶明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1客戶明細.Size = New System.Drawing.Size(737, 530)
        Me.T1客戶明細.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "客戶名稱："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "客戶編號："
        '
        'TP品項
        '
        Me.TP品項.Controls.Add(Me.Label13)
        Me.TP品項.Controls.Add(Me.TB2備註)
        Me.TP品項.Controls.Add(Me.Bu2新增)
        Me.TP品項.Controls.Add(Me.CB2包含查詢)
        Me.TP品項.Controls.Add(Me.TB2品名3)
        Me.TP品項.Controls.Add(Me.TB2品名2)
        Me.TP品項.Controls.Add(Me.TB2品名1)
        Me.TP品項.Controls.Add(Me.CB2製程)
        Me.TP品項.Controls.Add(Me.CB2保存)
        Me.TP品項.Controls.Add(Me.Bu2查詢)
        Me.TP品項.Controls.Add(Me.Label10)
        Me.TP品項.Controls.Add(Me.Label11)
        Me.TP品項.Controls.Add(Me.Label12)
        Me.TP品項.Controls.Add(Me.T2品項明細)
        Me.TP品項.Controls.Add(Me.T2訂單明細)
        Me.TP品項.Controls.Add(Me.Bu2放棄)
        Me.TP品項.Location = New System.Drawing.Point(4, 29)
        Me.TP品項.Name = "TP品項"
        Me.TP品項.Padding = New System.Windows.Forms.Padding(3)
        Me.TP品項.Size = New System.Drawing.Size(962, 553)
        Me.TP品項.TabIndex = 1
        Me.TP品項.Text = "輸入品項"
        Me.TP品項.UseVisualStyleBackColor = True
        '
        'Bu2新增
        '
        Me.Bu2新增.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2新增.Location = New System.Drawing.Point(670, 514)
        Me.Bu2新增.Name = "Bu2新增"
        Me.Bu2新增.Size = New System.Drawing.Size(84, 30)
        Me.Bu2新增.TabIndex = 1
        Me.Bu2新增.Text = "新增"
        Me.Bu2新增.UseVisualStyleBackColor = True
        '
        'CB2包含查詢
        '
        Me.CB2包含查詢.AutoSize = True
        Me.CB2包含查詢.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2包含查詢.Location = New System.Drawing.Point(811, 326)
        Me.CB2包含查詢.Name = "CB2包含查詢"
        Me.CB2包含查詢.Size = New System.Drawing.Size(82, 17)
        Me.CB2包含查詢.TabIndex = 15
        Me.CB2包含查詢.Text = "包含查詢"
        Me.CB2包含查詢.UseVisualStyleBackColor = True
        '
        'TB2品名3
        '
        Me.TB2品名3.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名3.Location = New System.Drawing.Point(837, 401)
        Me.TB2品名3.Name = "TB2品名3"
        Me.TB2品名3.Size = New System.Drawing.Size(120, 23)
        Me.TB2品名3.TabIndex = 14
        '
        'TB2品名2
        '
        Me.TB2品名2.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名2.Location = New System.Drawing.Point(710, 401)
        Me.TB2品名2.Name = "TB2品名2"
        Me.TB2品名2.Size = New System.Drawing.Size(120, 23)
        Me.TB2品名2.TabIndex = 13
        '
        'TB2品名1
        '
        Me.TB2品名1.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名1.Location = New System.Drawing.Point(710, 374)
        Me.TB2品名1.Name = "TB2品名1"
        Me.TB2品名1.Size = New System.Drawing.Size(246, 23)
        Me.TB2品名1.TabIndex = 12
        '
        'CB2製程
        '
        Me.CB2製程.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2製程.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2製程.FormattingEnabled = True
        Me.CB2製程.Location = New System.Drawing.Point(710, 349)
        Me.CB2製程.Name = "CB2製程"
        Me.CB2製程.Size = New System.Drawing.Size(95, 21)
        Me.CB2製程.TabIndex = 11
        '
        'CB2保存
        '
        Me.CB2保存.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2保存.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2保存.FormattingEnabled = True
        Me.CB2保存.Location = New System.Drawing.Point(710, 323)
        Me.CB2保存.Name = "CB2保存"
        Me.CB2保存.Size = New System.Drawing.Size(95, 21)
        Me.CB2保存.TabIndex = 10
        '
        'Bu2查詢
        '
        Me.Bu2查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2查詢.Location = New System.Drawing.Point(873, 343)
        Me.Bu2查詢.Name = "Bu2查詢"
        Me.Bu2查詢.Size = New System.Drawing.Size(84, 30)
        Me.Bu2查詢.TabIndex = 16
        Me.Bu2查詢.Text = "查詢"
        Me.Bu2查詢.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(671, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 26)
        Me.Label10.TabIndex = 177
        Me.Label10.Text = "保存" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "方式"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(667, 350)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 16)
        Me.Label11.TabIndex = 178
        Me.Label11.Text = "製程"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(667, 377)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 16)
        Me.Label12.TabIndex = 179
        Me.Label12.Text = "品名"
        '
        'T2品項明細
        '
        Me.T2品項明細.AllowUserToAddRows = False
        Me.T2品項明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2品項明細.Location = New System.Drawing.Point(4, 323)
        Me.T2品項明細.MultiSelect = False
        Me.T2品項明細.Name = "T2品項明細"
        Me.T2品項明細.RowHeadersVisible = False
        Me.T2品項明細.RowTemplate.Height = 24
        Me.T2品項明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2品項明細.Size = New System.Drawing.Size(663, 221)
        Me.T2品項明細.TabIndex = 1004
        Me.T2品項明細.TabStop = False
        Me.T2品項明細.VirtualMode = True
        '
        'T2訂單明細
        '
        Me.T2訂單明細.AllowUserToAddRows = False
        Me.T2訂單明細.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.T2訂單明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2訂單明細.Location = New System.Drawing.Point(4, 6)
        Me.T2訂單明細.MultiSelect = False
        Me.T2訂單明細.Name = "T2訂單明細"
        Me.T2訂單明細.RowHeadersVisible = False
        Me.T2訂單明細.RowTemplate.Height = 24
        Me.T2訂單明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2訂單明細.Size = New System.Drawing.Size(952, 311)
        Me.T2訂單明細.TabIndex = 1003
        Me.T2訂單明細.TabStop = False
        Me.T2訂單明細.VirtualMode = True
        '
        'Bu2放棄
        '
        Me.Bu2放棄.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2放棄.Location = New System.Drawing.Point(875, 514)
        Me.Bu2放棄.Name = "Bu2放棄"
        Me.Bu2放棄.Size = New System.Drawing.Size(84, 30)
        Me.Bu2放棄.TabIndex = 21
        Me.Bu2放棄.TabStop = False
        Me.Bu2放棄.Text = "放棄"
        Me.Bu2放棄.UseVisualStyleBackColor = True
        '
        'TP查詢
        '
        Me.TP查詢.Location = New System.Drawing.Point(4, 29)
        Me.TP查詢.Name = "TP查詢"
        Me.TP查詢.Padding = New System.Windows.Forms.Padding(3)
        Me.TP查詢.Size = New System.Drawing.Size(962, 553)
        Me.TP查詢.TabIndex = 2
        Me.TP查詢.Text = "查詢品項"
        Me.TP查詢.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(489, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "生產訂單："
        '
        'Bu回存草稿
        '
        Me.Bu回存草稿.BackColor = System.Drawing.Color.Red
        Me.Bu回存草稿.Font = New System.Drawing.Font("微軟正黑體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu回存草稿.Location = New System.Drawing.Point(869, 10)
        Me.Bu回存草稿.Name = "Bu回存草稿"
        Me.Bu回存草稿.Size = New System.Drawing.Size(90, 70)
        Me.Bu回存草稿.TabIndex = 1002
        Me.Bu回存草稿.TabStop = False
        Me.Bu回存草稿.Text = "儲存" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "草稿單"
        Me.Bu回存草稿.UseVisualStyleBackColor = False
        '
        'CB人員
        '
        Me.CB人員.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB人員.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB人員.FormattingEnabled = True
        Me.CB人員.Location = New System.Drawing.Point(575, 29)
        Me.CB人員.Name = "CB人員"
        Me.CB人員.Size = New System.Drawing.Size(131, 24)
        Me.CB人員.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(494, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Key單者："
        '
        'DocDueDate
        '
        Me.DocDueDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDueDate.Location = New System.Drawing.Point(575, 55)
        Me.DocDueDate.Name = "DocDueDate"
        Me.DocDueDate.Size = New System.Drawing.Size(131, 27)
        Me.DocDueDate.TabIndex = 14
        Me.DocDueDate.Value = New Date(2015, 5, 27, 0, 0, 0, 0)
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(489, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 16)
        Me.Label20.TabIndex = 175
        Me.Label20.Text = "交貨日期："
        '
        'LA生產
        '
        Me.LA生產.AutoSize = True
        Me.LA生產.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LA生產.Location = New System.Drawing.Point(572, 5)
        Me.LA生產.Name = "LA生產"
        Me.LA生產.Size = New System.Drawing.Size(76, 16)
        Me.LA生產.TabIndex = 176
        Me.LA生產.Text = "生產訂單"
        '
        'TB2備註
        '
        Me.TB2備註.BackColor = System.Drawing.SystemColors.Window
        Me.TB2備註.Location = New System.Drawing.Point(710, 427)
        Me.TB2備註.Multiline = True
        Me.TB2備註.Name = "TB2備註"
        Me.TB2備註.Size = New System.Drawing.Size(246, 81)
        Me.TB2備註.TabIndex = 1005
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(667, 430)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 16)
        Me.Label13.TabIndex = 1006
        Me.Label13.Text = "備註"
        '
        '營業訂單V103
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 637)
        Me.Controls.Add(Me.LA生產)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DocDueDate)
        Me.Controls.Add(Me.CB人員)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Bu回存草稿)
        Me.Controls.Add(Me.CB3司機)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CB2司機)
        Me.Controls.Add(Me.CB1司機)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TB名稱)
        Me.Controls.Add(Me.TB客編)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "營業訂單V103"
        Me.Text = "營業訂單系統"
        Me.TabControl1.ResumeLayout(False)
        Me.TP客戶.ResumeLayout(False)
        Me.TP客戶.PerformLayout()
        CType(Me.T1客戶明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP品項.ResumeLayout(False)
        Me.TP品項.PerformLayout()
        CType(Me.T2品項明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2訂單明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB客編 As System.Windows.Forms.TextBox
    Friend WithEvents TB名稱 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CB1司機 As System.Windows.Forms.ComboBox
    Friend WithEvents CB2司機 As System.Windows.Forms.ComboBox
    Friend WithEvents CB3司機 As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP客戶 As System.Windows.Forms.TabPage
    Friend WithEvents TP品項 As System.Windows.Forms.TabPage
    Friend WithEvents Bu1確定 As System.Windows.Forms.Button
    Friend WithEvents TB1名稱2 As System.Windows.Forms.TextBox
    Friend WithEvents TB1名稱1 As System.Windows.Forms.TextBox
    Friend WithEvents Bu1查詢 As System.Windows.Forms.Button
    Friend WithEvents TB1客編0 As System.Windows.Forms.TextBox
    Friend WithEvents T1客戶明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Bu1超市 As System.Windows.Forms.Button
    Friend WithEvents Bu1常用 As System.Windows.Forms.Button
    Friend WithEvents Bu110大 As System.Windows.Forms.Button
    Friend WithEvents Bu回存草稿 As System.Windows.Forms.Button
    Friend WithEvents TB1名稱3 As System.Windows.Forms.TextBox
    Friend WithEvents Bu2放棄 As System.Windows.Forms.Button
    Friend WithEvents T2訂單明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CB人員 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DocDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents LA生產 As System.Windows.Forms.Label
    Friend WithEvents TP查詢 As System.Windows.Forms.TabPage
    Friend WithEvents T2品項明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Bu2查詢 As System.Windows.Forms.Button
    Friend WithEvents CB2製程 As System.Windows.Forms.ComboBox
    Friend WithEvents CB2保存 As System.Windows.Forms.ComboBox
    Friend WithEvents TB2品名1 As System.Windows.Forms.TextBox
    Friend WithEvents TB2品名3 As System.Windows.Forms.TextBox
    Friend WithEvents TB2品名2 As System.Windows.Forms.TextBox
    Friend WithEvents CB2包含查詢 As System.Windows.Forms.CheckBox
    Friend WithEvents Bu2新增 As System.Windows.Forms.Button
    Friend WithEvents TB2備註 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
