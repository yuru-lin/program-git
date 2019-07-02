<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 營業訂單V104
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
        Me.La客戶 = New System.Windows.Forms.Label
        Me.DT1日期 = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.CB1客戶 = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
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
        Me.T2訂單明細 = New System.Windows.Forms.DataGridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.TB2備註 = New System.Windows.Forms.TextBox
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
        Me.Bu2放棄 = New System.Windows.Forms.Button
        Me.TP查詢 = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.Bu回存草稿 = New System.Windows.Forms.Button
        Me.CB人員 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.LA生產 = New System.Windows.Forms.Label
        Me.TB訂單單號 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.DocDueDate = New System.Windows.Forms.DateTimePicker
        Me.LA地點 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TP客戶.SuspendLayout()
        CType(Me.T1客戶明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP品項.SuspendLayout()
        CType(Me.T2訂單明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2品項明細, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Location = New System.Drawing.Point(5, 89)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(970, 562)
        Me.TabControl1.TabIndex = 10
        '
        'TP客戶
        '
        Me.TP客戶.Controls.Add(Me.La客戶)
        Me.TP客戶.Controls.Add(Me.DT1日期)
        Me.TP客戶.Controls.Add(Me.Label17)
        Me.TP客戶.Controls.Add(Me.CB1客戶)
        Me.TP客戶.Controls.Add(Me.Label16)
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
        Me.TP客戶.Size = New System.Drawing.Size(962, 529)
        Me.TP客戶.TabIndex = 0
        Me.TP客戶.Text = "客戶查詢"
        Me.TP客戶.UseVisualStyleBackColor = True
        '
        'La客戶
        '
        Me.La客戶.AutoSize = True
        Me.La客戶.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La客戶.Location = New System.Drawing.Point(2, 113)
        Me.La客戶.Name = "La客戶"
        Me.La客戶.Size = New System.Drawing.Size(49, 19)
        Me.La客戶.TabIndex = 1008
        Me.La客戶.Text = "客戶"
        '
        'DT1日期
        '
        Me.DT1日期.Location = New System.Drawing.Point(63, 19)
        Me.DT1日期.Name = "DT1日期"
        Me.DT1日期.Size = New System.Drawing.Size(135, 27)
        Me.DT1日期.TabIndex = 1007
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(2, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 19)
        Me.Label17.TabIndex = 1006
        Me.Label17.Text = "日期："
        '
        'CB1客戶
        '
        Me.CB1客戶.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB1客戶.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB1客戶.FormattingEnabled = True
        Me.CB1客戶.Items.AddRange(New Object() {"全聯", "好市多", "嘉珍香"})
        Me.CB1客戶.Location = New System.Drawing.Point(63, 59)
        Me.CB1客戶.Name = "CB1客戶"
        Me.CB1客戶.Size = New System.Drawing.Size(135, 24)
        Me.CB1客戶.TabIndex = 104
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(2, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 19)
        Me.Label16.TabIndex = 1005
        Me.Label16.Text = "客戶："
        '
        'TB1名稱3
        '
        Me.TB1名稱3.Location = New System.Drawing.Point(91, 361)
        Me.TB1名稱3.Name = "TB1名稱3"
        Me.TB1名稱3.Size = New System.Drawing.Size(122, 27)
        Me.TB1名稱3.TabIndex = 24
        Me.TB1名稱3.Visible = False
        '
        'Bu110大
        '
        Me.Bu110大.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu110大.Location = New System.Drawing.Point(106, 480)
        Me.Bu110大.Name = "Bu110大"
        Me.Bu110大.Size = New System.Drawing.Size(84, 37)
        Me.Bu110大.TabIndex = 102
        Me.Bu110大.Text = "10大"
        Me.Bu110大.UseVisualStyleBackColor = True
        Me.Bu110大.Visible = False
        '
        'Bu1超市
        '
        Me.Bu1超市.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1超市.Location = New System.Drawing.Point(107, 437)
        Me.Bu1超市.Name = "Bu1超市"
        Me.Bu1超市.Size = New System.Drawing.Size(84, 37)
        Me.Bu1超市.TabIndex = 101
        Me.Bu1超市.Text = "超市"
        Me.Bu1超市.UseVisualStyleBackColor = True
        Me.Bu1超市.Visible = False
        '
        'Bu1常用
        '
        Me.Bu1常用.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1常用.Location = New System.Drawing.Point(107, 394)
        Me.Bu1常用.Name = "Bu1常用"
        Me.Bu1常用.Size = New System.Drawing.Size(84, 37)
        Me.Bu1常用.TabIndex = 100
        Me.Bu1常用.Text = "常用"
        Me.Bu1常用.UseVisualStyleBackColor = True
        Me.Bu1常用.Visible = False
        '
        'Bu1確定
        '
        Me.Bu1確定.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1確定.Location = New System.Drawing.Point(114, 158)
        Me.Bu1確定.Name = "Bu1確定"
        Me.Bu1確定.Size = New System.Drawing.Size(84, 37)
        Me.Bu1確定.TabIndex = 20
        Me.Bu1確定.Text = "確定"
        Me.Bu1確定.UseVisualStyleBackColor = True
        '
        'TB1名稱2
        '
        Me.TB1名稱2.Location = New System.Drawing.Point(91, 333)
        Me.TB1名稱2.Name = "TB1名稱2"
        Me.TB1名稱2.Size = New System.Drawing.Size(122, 27)
        Me.TB1名稱2.TabIndex = 23
        Me.TB1名稱2.Visible = False
        '
        'TB1名稱1
        '
        Me.TB1名稱1.Location = New System.Drawing.Point(91, 305)
        Me.TB1名稱1.Name = "TB1名稱1"
        Me.TB1名稱1.Size = New System.Drawing.Size(122, 27)
        Me.TB1名稱1.TabIndex = 22
        Me.TB1名稱1.Visible = False
        '
        'Bu1查詢
        '
        Me.Bu1查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1查詢.Location = New System.Drawing.Point(114, 103)
        Me.Bu1查詢.Name = "Bu1查詢"
        Me.Bu1查詢.Size = New System.Drawing.Size(84, 37)
        Me.Bu1查詢.TabIndex = 25
        Me.Bu1查詢.Text = "查詢"
        Me.Bu1查詢.UseVisualStyleBackColor = True
        '
        'TB1客編0
        '
        Me.TB1客編0.Location = New System.Drawing.Point(91, 277)
        Me.TB1客編0.Name = "TB1客編0"
        Me.TB1客編0.Size = New System.Drawing.Size(122, 27)
        Me.TB1客編0.TabIndex = 21
        Me.TB1客編0.Visible = False
        '
        'T1客戶明細
        '
        Me.T1客戶明細.AllowUserToAddRows = False
        Me.T1客戶明細.AllowUserToDeleteRows = False
        Me.T1客戶明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1客戶明細.Location = New System.Drawing.Point(222, 6)
        Me.T1客戶明細.MultiSelect = False
        Me.T1客戶明細.Name = "T1客戶明細"
        Me.T1客戶明細.ReadOnly = True
        Me.T1客戶明細.RowHeadersVisible = False
        Me.T1客戶明細.RowTemplate.Height = 24
        Me.T1客戶明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1客戶明細.Size = New System.Drawing.Size(737, 489)
        Me.T1客戶明細.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 308)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "客戶名稱："
        Me.Label6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "客戶編號："
        Me.Label7.Visible = False
        '
        'TP品項
        '
        Me.TP品項.Controls.Add(Me.T2訂單明細)
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
        Me.TP品項.Controls.Add(Me.Bu2放棄)
        Me.TP品項.Location = New System.Drawing.Point(4, 29)
        Me.TP品項.Name = "TP品項"
        Me.TP品項.Padding = New System.Windows.Forms.Padding(3)
        Me.TP品項.Size = New System.Drawing.Size(962, 529)
        Me.TP品項.TabIndex = 1
        Me.TP品項.Text = "輸入品項"
        Me.TP品項.UseVisualStyleBackColor = True
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
        Me.T2訂單明細.Size = New System.Drawing.Size(953, 480)
        Me.T2訂單明細.TabIndex = 1003
        Me.T2訂單明細.TabStop = False
        Me.T2訂單明細.VirtualMode = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(667, 408)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 16)
        Me.Label13.TabIndex = 1006
        Me.Label13.Text = "備註"
        Me.Label13.Visible = False
        '
        'TB2備註
        '
        Me.TB2備註.BackColor = System.Drawing.SystemColors.Window
        Me.TB2備註.Location = New System.Drawing.Point(710, 405)
        Me.TB2備註.Multiline = True
        Me.TB2備註.Name = "TB2備註"
        Me.TB2備註.Size = New System.Drawing.Size(246, 81)
        Me.TB2備註.TabIndex = 1005
        Me.TB2備註.Visible = False
        '
        'Bu2新增
        '
        Me.Bu2新增.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2新增.Location = New System.Drawing.Point(670, 492)
        Me.Bu2新增.Name = "Bu2新增"
        Me.Bu2新增.Size = New System.Drawing.Size(84, 30)
        Me.Bu2新增.TabIndex = 1
        Me.Bu2新增.Text = "新增"
        Me.Bu2新增.UseVisualStyleBackColor = True
        Me.Bu2新增.Visible = False
        '
        'CB2包含查詢
        '
        Me.CB2包含查詢.AutoSize = True
        Me.CB2包含查詢.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2包含查詢.Location = New System.Drawing.Point(811, 304)
        Me.CB2包含查詢.Name = "CB2包含查詢"
        Me.CB2包含查詢.Size = New System.Drawing.Size(82, 17)
        Me.CB2包含查詢.TabIndex = 15
        Me.CB2包含查詢.Text = "包含查詢"
        Me.CB2包含查詢.UseVisualStyleBackColor = True
        Me.CB2包含查詢.Visible = False
        '
        'TB2品名3
        '
        Me.TB2品名3.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名3.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名3.Location = New System.Drawing.Point(837, 379)
        Me.TB2品名3.Name = "TB2品名3"
        Me.TB2品名3.Size = New System.Drawing.Size(120, 23)
        Me.TB2品名3.TabIndex = 14
        Me.TB2品名3.Visible = False
        '
        'TB2品名2
        '
        Me.TB2品名2.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名2.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名2.Location = New System.Drawing.Point(710, 379)
        Me.TB2品名2.Name = "TB2品名2"
        Me.TB2品名2.Size = New System.Drawing.Size(120, 23)
        Me.TB2品名2.TabIndex = 13
        Me.TB2品名2.Visible = False
        '
        'TB2品名1
        '
        Me.TB2品名1.BackColor = System.Drawing.SystemColors.Window
        Me.TB2品名1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB2品名1.Location = New System.Drawing.Point(710, 352)
        Me.TB2品名1.Name = "TB2品名1"
        Me.TB2品名1.Size = New System.Drawing.Size(246, 23)
        Me.TB2品名1.TabIndex = 12
        Me.TB2品名1.Visible = False
        '
        'CB2製程
        '
        Me.CB2製程.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2製程.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2製程.FormattingEnabled = True
        Me.CB2製程.Location = New System.Drawing.Point(710, 327)
        Me.CB2製程.Name = "CB2製程"
        Me.CB2製程.Size = New System.Drawing.Size(95, 21)
        Me.CB2製程.TabIndex = 11
        Me.CB2製程.Visible = False
        '
        'CB2保存
        '
        Me.CB2保存.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB2保存.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB2保存.FormattingEnabled = True
        Me.CB2保存.Location = New System.Drawing.Point(710, 301)
        Me.CB2保存.Name = "CB2保存"
        Me.CB2保存.Size = New System.Drawing.Size(95, 21)
        Me.CB2保存.TabIndex = 10
        Me.CB2保存.Visible = False
        '
        'Bu2查詢
        '
        Me.Bu2查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2查詢.Location = New System.Drawing.Point(872, 319)
        Me.Bu2查詢.Name = "Bu2查詢"
        Me.Bu2查詢.Size = New System.Drawing.Size(84, 30)
        Me.Bu2查詢.TabIndex = 16
        Me.Bu2查詢.Text = "查詢"
        Me.Bu2查詢.UseVisualStyleBackColor = True
        Me.Bu2查詢.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(671, 300)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 26)
        Me.Label10.TabIndex = 177
        Me.Label10.Text = "保存" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "方式"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(667, 328)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 16)
        Me.Label11.TabIndex = 178
        Me.Label11.Text = "製程"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(667, 355)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 16)
        Me.Label12.TabIndex = 179
        Me.Label12.Text = "品名"
        Me.Label12.Visible = False
        '
        'T2品項明細
        '
        Me.T2品項明細.AllowUserToAddRows = False
        Me.T2品項明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2品項明細.Location = New System.Drawing.Point(4, 301)
        Me.T2品項明細.MultiSelect = False
        Me.T2品項明細.Name = "T2品項明細"
        Me.T2品項明細.RowHeadersVisible = False
        Me.T2品項明細.RowTemplate.Height = 24
        Me.T2品項明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2品項明細.Size = New System.Drawing.Size(663, 221)
        Me.T2品項明細.TabIndex = 1004
        Me.T2品項明細.TabStop = False
        Me.T2品項明細.VirtualMode = True
        Me.T2品項明細.Visible = False
        '
        'Bu2放棄
        '
        Me.Bu2放棄.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2放棄.Location = New System.Drawing.Point(872, 492)
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
        Me.TP查詢.Size = New System.Drawing.Size(962, 529)
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
        Me.Bu回存草稿.Location = New System.Drawing.Point(862, 29)
        Me.Bu回存草稿.Name = "Bu回存草稿"
        Me.Bu回存草稿.Size = New System.Drawing.Size(90, 70)
        Me.Bu回存草稿.TabIndex = 1002
        Me.Bu回存草稿.TabStop = False
        Me.Bu回存草稿.Text = "儲存" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "草稿單"
        Me.Bu回存草稿.UseVisualStyleBackColor = False
        Me.Bu回存草稿.Visible = False
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
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(489, 91)
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
        'TB訂單單號
        '
        Me.TB訂單單號.BackColor = System.Drawing.Color.White
        Me.TB訂單單號.Location = New System.Drawing.Point(87, 60)
        Me.TB訂單單號.Name = "TB訂單單號"
        Me.TB訂單單號.ReadOnly = True
        Me.TB訂單單號.Size = New System.Drawing.Size(197, 22)
        Me.TB訂單單號.TabIndex = 1003
        Me.TB訂單單號.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(2, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 16)
        Me.Label14.TabIndex = 1004
        Me.Label14.Text = "訂單單號："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(489, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 16)
        Me.Label15.TabIndex = 1006
        Me.Label15.Text = "過帳日期："
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
        'DocDate
        '
        Me.DocDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDate.Location = New System.Drawing.Point(575, 57)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(131, 27)
        Me.DocDate.TabIndex = 1007
        '
        'DocDueDate
        '
        Me.DocDueDate.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDueDate.Location = New System.Drawing.Point(575, 87)
        Me.DocDueDate.Name = "DocDueDate"
        Me.DocDueDate.Size = New System.Drawing.Size(131, 27)
        Me.DocDueDate.TabIndex = 1008
        '
        'LA地點
        '
        Me.LA地點.AutoSize = True
        Me.LA地點.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LA地點.Location = New System.Drawing.Point(795, 32)
        Me.LA地點.Name = "LA地點"
        Me.LA地點.Size = New System.Drawing.Size(76, 16)
        Me.LA地點.TabIndex = 1010
        Me.LA地點.Text = "送貨地點"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(712, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 16)
        Me.Label19.TabIndex = 1009
        Me.Label19.Text = "送貨地點："
        '
        '營業訂單V104
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 647)
        Me.Controls.Add(Me.Bu回存草稿)
        Me.Controls.Add(Me.LA地點)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DocDueDate)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TB訂單單號)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LA生產)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CB人員)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label9)
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
        Me.Name = "營業訂單V104"
        Me.Text = "營業訂單系統"
        Me.TabControl1.ResumeLayout(False)
        Me.TP客戶.ResumeLayout(False)
        Me.TP客戶.PerformLayout()
        CType(Me.T1客戶明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP品項.ResumeLayout(False)
        Me.TP品項.PerformLayout()
        CType(Me.T2訂單明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2品項明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
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
    Friend WithEvents CB1客戶 As System.Windows.Forms.ComboBox
    Friend WithEvents TB訂單單號 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DT1日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents La客戶 As System.Windows.Forms.Label
    Friend WithEvents LA地點 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
