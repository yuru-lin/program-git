<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 退貨入庫V100
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
        Me.Lt作業 = New System.Windows.Forms.Label
        Me.TB單號 = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.TB名稱 = New System.Windows.Forms.TextBox
        Me.TB客編 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TP單據查詢 = New System.Windows.Forms.TabPage
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        Me.Bu1列印 = New System.Windows.Forms.Button
        Me.Bu1入庫 = New System.Windows.Forms.Button
        Me.T1退貨條碼 = New System.Windows.Forms.DataGridView
        Me.T1退貨明細 = New System.Windows.Forms.DataGridView
        Me.De1開始 = New System.Windows.Forms.DateTimePicker
        Me.T1退貨單號 = New System.Windows.Forms.DataGridView
        Me.De1結束 = New System.Windows.Forms.DateTimePicker
        Me.Rb1日期 = New System.Windows.Forms.RadioButton
        Me.Bu1新增 = New System.Windows.Forms.Button
        Me.Bu1查詢 = New System.Windows.Forms.Button
        Me.TP退貨條碼 = New System.Windows.Forms.TabPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.Bu2放棄 = New System.Windows.Forms.Button
        Me.La2條碼 = New System.Windows.Forms.Label
        Me.Bu2入庫 = New System.Windows.Forms.Button
        Me.Bu2刪除 = New System.Windows.Forms.Button
        Me.Bu2存檔 = New System.Windows.Forms.Button
        Me.Bu2新增 = New System.Windows.Forms.Button
        Me.Tb2重量 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Tb2退貨 = New System.Windows.Forms.TextBox
        Me.La2小單位 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.La2品名 = New System.Windows.Forms.Label
        Me.La2存編 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.T2退貨條碼 = New System.Windows.Forms.DataGridView
        Me.T2退貨明細 = New System.Windows.Forms.DataGridView
        Me.TP退貨入庫 = New System.Windows.Forms.TabPage
        Me.Cb3印表機 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB3儲位 = New System.Windows.Forms.TextBox
        Me.TB3備註 = New System.Windows.Forms.TextBox
        Me.T3過帳日期 = New System.Windows.Forms.DateTimePicker
        Me.Bu3放棄 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.回存入庫 = New System.Windows.Forms.Button
        Me.T3退貨條碼 = New System.Windows.Forms.DataGridView
        Me.T3退貨明細 = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1.SuspendLayout()
        Me.TP單據查詢.SuspendLayout()
        CType(Me.T1退貨條碼, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1退貨明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1退貨單號, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP退貨條碼.SuspendLayout()
        CType(Me.T2退貨條碼, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2退貨明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP退貨入庫.SuspendLayout()
        CType(Me.T3退貨條碼, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T3退貨明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lt作業
        '
        Me.Lt作業.AutoSize = True
        Me.Lt作業.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt作業.Location = New System.Drawing.Point(983, 8)
        Me.Lt作業.Name = "Lt作業"
        Me.Lt作業.Size = New System.Drawing.Size(42, 16)
        Me.Lt作業.TabIndex = 1065
        Me.Lt作業.Text = "未選"
        '
        'TB單號
        '
        Me.TB單號.BackColor = System.Drawing.Color.White
        Me.TB單號.Location = New System.Drawing.Point(762, 5)
        Me.TB單號.Name = "TB單號"
        Me.TB單號.ReadOnly = True
        Me.TB單號.Size = New System.Drawing.Size(130, 22)
        Me.TB單號.TabIndex = 1063
        Me.TB單號.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(898, 8)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(93, 16)
        Me.Label31.TabIndex = 1064
        Me.Label31.Text = "目前作業："
        '
        'TB名稱
        '
        Me.TB名稱.BackColor = System.Drawing.Color.White
        Me.TB名稱.Location = New System.Drawing.Point(309, 5)
        Me.TB名稱.Name = "TB名稱"
        Me.TB名稱.ReadOnly = True
        Me.TB名稱.Size = New System.Drawing.Size(360, 22)
        Me.TB名稱.TabIndex = 1061
        Me.TB名稱.TabStop = False
        '
        'TB客編
        '
        Me.TB客編.BackColor = System.Drawing.Color.White
        Me.TB客編.Location = New System.Drawing.Point(88, 5)
        Me.TB客編.Name = "TB客編"
        Me.TB客編.ReadOnly = True
        Me.TB客編.Size = New System.Drawing.Size(130, 22)
        Me.TB客編.TabIndex = 1060
        Me.TB客編.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(677, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 16)
        Me.Label5.TabIndex = 1062
        Me.Label5.Text = "退貨單號："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 1058
        Me.Label1.Text = "客戶編號："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(224, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 1059
        Me.Label2.Text = "客戶名稱："
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TP單據查詢)
        Me.TabControl1.Controls.Add(Me.TP退貨條碼)
        Me.TabControl1.Controls.Add(Me.TP退貨入庫)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1182, 600)
        Me.TabControl1.TabIndex = 1066
        '
        'TP單據查詢
        '
        Me.TP單據查詢.Controls.Add(Me.Cb1印表機)
        Me.TP單據查詢.Controls.Add(Me.Bu1列印)
        Me.TP單據查詢.Controls.Add(Me.Bu1入庫)
        Me.TP單據查詢.Controls.Add(Me.T1退貨條碼)
        Me.TP單據查詢.Controls.Add(Me.T1退貨明細)
        Me.TP單據查詢.Controls.Add(Me.De1開始)
        Me.TP單據查詢.Controls.Add(Me.T1退貨單號)
        Me.TP單據查詢.Controls.Add(Me.De1結束)
        Me.TP單據查詢.Controls.Add(Me.Rb1日期)
        Me.TP單據查詢.Controls.Add(Me.Bu1新增)
        Me.TP單據查詢.Controls.Add(Me.Bu1查詢)
        Me.TP單據查詢.Location = New System.Drawing.Point(4, 4)
        Me.TP單據查詢.Name = "TP單據查詢"
        Me.TP單據查詢.Padding = New System.Windows.Forms.Padding(3)
        Me.TP單據查詢.Size = New System.Drawing.Size(1174, 570)
        Me.TP單據查詢.TabIndex = 1
        Me.TP單據查詢.Text = "單據查詢"
        Me.TP單據查詢.UseVisualStyleBackColor = True
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(651, 7)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(250, 24)
        Me.Cb1印表機.TabIndex = 1083
        '
        'Bu1列印
        '
        Me.Bu1列印.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bu1列印.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1列印.ForeColor = System.Drawing.Color.Red
        Me.Bu1列印.Location = New System.Drawing.Point(907, 6)
        Me.Bu1列印.Name = "Bu1列印"
        Me.Bu1列印.Size = New System.Drawing.Size(130, 37)
        Me.Bu1列印.TabIndex = 1082
        Me.Bu1列印.Text = "列印條碼"
        Me.Bu1列印.UseVisualStyleBackColor = False
        '
        'Bu1入庫
        '
        Me.Bu1入庫.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1入庫.Location = New System.Drawing.Point(1081, 6)
        Me.Bu1入庫.Name = "Bu1入庫"
        Me.Bu1入庫.Size = New System.Drawing.Size(84, 37)
        Me.Bu1入庫.TabIndex = 1081
        Me.Bu1入庫.Text = "入庫"
        Me.Bu1入庫.UseVisualStyleBackColor = True
        '
        'T1退貨條碼
        '
        Me.T1退貨條碼.AllowUserToAddRows = False
        Me.T1退貨條碼.AllowUserToDeleteRows = False
        Me.T1退貨條碼.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1退貨條碼.Location = New System.Drawing.Point(339, 336)
        Me.T1退貨條碼.MultiSelect = False
        Me.T1退貨條碼.Name = "T1退貨條碼"
        Me.T1退貨條碼.ReadOnly = True
        Me.T1退貨條碼.RowHeadersVisible = False
        Me.T1退貨條碼.RowTemplate.Height = 24
        Me.T1退貨條碼.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1退貨條碼.Size = New System.Drawing.Size(826, 228)
        Me.T1退貨條碼.TabIndex = 1069
        '
        'T1退貨明細
        '
        Me.T1退貨明細.AllowUserToAddRows = False
        Me.T1退貨明細.AllowUserToDeleteRows = False
        Me.T1退貨明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1退貨明細.Location = New System.Drawing.Point(339, 49)
        Me.T1退貨明細.MultiSelect = False
        Me.T1退貨明細.Name = "T1退貨明細"
        Me.T1退貨明細.ReadOnly = True
        Me.T1退貨明細.RowHeadersVisible = False
        Me.T1退貨明細.RowTemplate.Height = 24
        Me.T1退貨明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1退貨明細.Size = New System.Drawing.Size(826, 281)
        Me.T1退貨明細.TabIndex = 1068
        '
        'De1開始
        '
        Me.De1開始.CalendarFont = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1開始.CustomFormat = "yyyy/MM/dd"
        Me.De1開始.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1開始.Location = New System.Drawing.Point(108, 6)
        Me.De1開始.Name = "De1開始"
        Me.De1開始.Size = New System.Drawing.Size(110, 23)
        Me.De1開始.TabIndex = 1035
        '
        'T1退貨單號
        '
        Me.T1退貨單號.AllowUserToAddRows = False
        Me.T1退貨單號.AllowUserToDeleteRows = False
        Me.T1退貨單號.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1退貨單號.Location = New System.Drawing.Point(6, 49)
        Me.T1退貨單號.MultiSelect = False
        Me.T1退貨單號.Name = "T1退貨單號"
        Me.T1退貨單號.ReadOnly = True
        Me.T1退貨單號.RowHeadersVisible = False
        Me.T1退貨單號.RowTemplate.Height = 24
        Me.T1退貨單號.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1退貨單號.Size = New System.Drawing.Size(327, 515)
        Me.T1退貨單號.TabIndex = 1067
        '
        'De1結束
        '
        Me.De1結束.CalendarFont = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1結束.CustomFormat = "yyyy/MM/dd"
        Me.De1結束.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1結束.Location = New System.Drawing.Point(223, 6)
        Me.De1結束.Name = "De1結束"
        Me.De1結束.Size = New System.Drawing.Size(110, 23)
        Me.De1結束.TabIndex = 1036
        '
        'Rb1日期
        '
        Me.Rb1日期.AutoSize = True
        Me.Rb1日期.Checked = True
        Me.Rb1日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Rb1日期.Location = New System.Drawing.Point(6, 6)
        Me.Rb1日期.Name = "Rb1日期"
        Me.Rb1日期.Size = New System.Drawing.Size(111, 20)
        Me.Rb1日期.TabIndex = 1034
        Me.Rb1日期.TabStop = True
        Me.Rb1日期.Text = "單據日期："
        Me.Rb1日期.UseVisualStyleBackColor = True
        '
        'Bu1新增
        '
        Me.Bu1新增.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1新增.Location = New System.Drawing.Point(438, 6)
        Me.Bu1新增.Name = "Bu1新增"
        Me.Bu1新增.Size = New System.Drawing.Size(84, 37)
        Me.Bu1新增.TabIndex = 1033
        Me.Bu1新增.Text = "設定"
        Me.Bu1新增.UseVisualStyleBackColor = True
        '
        'Bu1查詢
        '
        Me.Bu1查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1查詢.Location = New System.Drawing.Point(339, 4)
        Me.Bu1查詢.Name = "Bu1查詢"
        Me.Bu1查詢.Size = New System.Drawing.Size(84, 27)
        Me.Bu1查詢.TabIndex = 1032
        Me.Bu1查詢.Text = "查詢"
        Me.Bu1查詢.UseVisualStyleBackColor = True
        '
        'TP退貨條碼
        '
        Me.TP退貨條碼.Controls.Add(Me.Label10)
        Me.TP退貨條碼.Controls.Add(Me.Bu2放棄)
        Me.TP退貨條碼.Controls.Add(Me.La2條碼)
        Me.TP退貨條碼.Controls.Add(Me.Bu2入庫)
        Me.TP退貨條碼.Controls.Add(Me.Bu2刪除)
        Me.TP退貨條碼.Controls.Add(Me.Bu2存檔)
        Me.TP退貨條碼.Controls.Add(Me.Bu2新增)
        Me.TP退貨條碼.Controls.Add(Me.Tb2重量)
        Me.TP退貨條碼.Controls.Add(Me.Label4)
        Me.TP退貨條碼.Controls.Add(Me.Tb2退貨)
        Me.TP退貨條碼.Controls.Add(Me.La2小單位)
        Me.TP退貨條碼.Controls.Add(Me.Label9)
        Me.TP退貨條碼.Controls.Add(Me.La2品名)
        Me.TP退貨條碼.Controls.Add(Me.La2存編)
        Me.TP退貨條碼.Controls.Add(Me.Label6)
        Me.TP退貨條碼.Controls.Add(Me.Label3)
        Me.TP退貨條碼.Controls.Add(Me.T2退貨條碼)
        Me.TP退貨條碼.Controls.Add(Me.T2退貨明細)
        Me.TP退貨條碼.Location = New System.Drawing.Point(4, 4)
        Me.TP退貨條碼.Name = "TP退貨條碼"
        Me.TP退貨條碼.Padding = New System.Windows.Forms.Padding(3)
        Me.TP退貨條碼.Size = New System.Drawing.Size(1174, 570)
        Me.TP退貨條碼.TabIndex = 0
        Me.TP退貨條碼.Text = "退貨條碼"
        Me.TP退貨條碼.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 1088
        Me.Label10.Text = "小單位"
        '
        'Bu2放棄
        '
        Me.Bu2放棄.BackColor = System.Drawing.Color.Red
        Me.Bu2放棄.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2放棄.ForeColor = System.Drawing.Color.Yellow
        Me.Bu2放棄.Location = New System.Drawing.Point(1048, 3)
        Me.Bu2放棄.Name = "Bu2放棄"
        Me.Bu2放棄.Size = New System.Drawing.Size(120, 44)
        Me.Bu2放棄.TabIndex = 1087
        Me.Bu2放棄.Text = "放棄"
        Me.Bu2放棄.UseVisualStyleBackColor = False
        '
        'La2條碼
        '
        Me.La2條碼.AutoSize = True
        Me.La2條碼.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La2條碼.Location = New System.Drawing.Point(411, 178)
        Me.La2條碼.Name = "La2條碼"
        Me.La2條碼.Size = New System.Drawing.Size(42, 16)
        Me.La2條碼.TabIndex = 1081
        Me.La2條碼.Text = "條碼"
        '
        'Bu2入庫
        '
        Me.Bu2入庫.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2入庫.Location = New System.Drawing.Point(1024, 332)
        Me.Bu2入庫.Name = "Bu2入庫"
        Me.Bu2入庫.Size = New System.Drawing.Size(144, 37)
        Me.Bu2入庫.TabIndex = 1080
        Me.Bu2入庫.Text = "存檔入庫"
        Me.Bu2入庫.UseVisualStyleBackColor = True
        '
        'Bu2刪除
        '
        Me.Bu2刪除.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2刪除.Location = New System.Drawing.Point(582, 214)
        Me.Bu2刪除.Name = "Bu2刪除"
        Me.Bu2刪除.Size = New System.Drawing.Size(84, 37)
        Me.Bu2刪除.TabIndex = 1079
        Me.Bu2刪除.Text = "刪除"
        Me.Bu2刪除.UseVisualStyleBackColor = True
        '
        'Bu2存檔
        '
        Me.Bu2存檔.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2存檔.Location = New System.Drawing.Point(1084, 256)
        Me.Bu2存檔.Name = "Bu2存檔"
        Me.Bu2存檔.Size = New System.Drawing.Size(84, 37)
        Me.Bu2存檔.TabIndex = 1078
        Me.Bu2存檔.Text = "存檔"
        Me.Bu2存檔.UseVisualStyleBackColor = True
        '
        'Bu2新增
        '
        Me.Bu2新增.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2新增.Location = New System.Drawing.Point(437, 213)
        Me.Bu2新增.Name = "Bu2新增"
        Me.Bu2新增.Size = New System.Drawing.Size(84, 37)
        Me.Bu2新增.TabIndex = 1069
        Me.Bu2新增.Text = "新增"
        Me.Bu2新增.UseVisualStyleBackColor = True
        '
        'Tb2重量
        '
        Me.Tb2重量.BackColor = System.Drawing.Color.White
        Me.Tb2重量.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Tb2重量.Location = New System.Drawing.Point(301, 213)
        Me.Tb2重量.Name = "Tb2重量"
        Me.Tb2重量.Size = New System.Drawing.Size(130, 27)
        Me.Tb2重量.TabIndex = 1076
        Me.Tb2重量.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(215, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 1077
        Me.Label4.Text = "退貨重量："
        '
        'Tb2退貨
        '
        Me.Tb2退貨.BackColor = System.Drawing.Color.White
        Me.Tb2退貨.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.Tb2退貨.Location = New System.Drawing.Point(112, 213)
        Me.Tb2退貨.Name = "Tb2退貨"
        Me.Tb2退貨.Size = New System.Drawing.Size(94, 27)
        Me.Tb2退貨.TabIndex = 1067
        Me.Tb2退貨.TabStop = False
        '
        'La2小單位
        '
        Me.La2小單位.AutoSize = True
        Me.La2小單位.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La2小單位.Location = New System.Drawing.Point(63, 229)
        Me.La2小單位.Name = "La2小單位"
        Me.La2小單位.Size = New System.Drawing.Size(59, 16)
        Me.La2小單位.TabIndex = 1075
        Me.La2小單位.Text = "小單位"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 210)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 16)
        Me.Label9.TabIndex = 1074
        Me.Label9.Text = "退 貨 量："
        '
        'La2品名
        '
        Me.La2品名.AutoSize = True
        Me.La2品名.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La2品名.Location = New System.Drawing.Point(86, 194)
        Me.La2品名.Name = "La2品名"
        Me.La2品名.Size = New System.Drawing.Size(42, 16)
        Me.La2品名.TabIndex = 1073
        Me.La2品名.Text = "品名"
        '
        'La2存編
        '
        Me.La2存編.AutoSize = True
        Me.La2存編.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La2存編.Location = New System.Drawing.Point(86, 178)
        Me.La2存編.Name = "La2存編"
        Me.La2存編.Size = New System.Drawing.Size(42, 16)
        Me.La2存編.TabIndex = 1071
        Me.La2存編.Text = "存編"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 1072
        Me.Label6.Text = "存編名稱："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 1067
        Me.Label3.Text = "存貨編號："
        '
        'T2退貨條碼
        '
        Me.T2退貨條碼.AllowUserToAddRows = False
        Me.T2退貨條碼.AllowUserToDeleteRows = False
        Me.T2退貨條碼.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2退貨條碼.Location = New System.Drawing.Point(6, 256)
        Me.T2退貨條碼.MultiSelect = False
        Me.T2退貨條碼.Name = "T2退貨條碼"
        Me.T2退貨條碼.ReadOnly = True
        Me.T2退貨條碼.RowHeadersVisible = False
        Me.T2退貨條碼.RowHeadersWidth = 21
        Me.T2退貨條碼.RowTemplate.Height = 24
        Me.T2退貨條碼.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2退貨條碼.Size = New System.Drawing.Size(1012, 308)
        Me.T2退貨條碼.TabIndex = 1070
        '
        'T2退貨明細
        '
        Me.T2退貨明細.AllowUserToAddRows = False
        Me.T2退貨明細.AllowUserToDeleteRows = False
        Me.T2退貨明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2退貨明細.Location = New System.Drawing.Point(6, 6)
        Me.T2退貨明細.MultiSelect = False
        Me.T2退貨明細.Name = "T2退貨明細"
        Me.T2退貨明細.ReadOnly = True
        Me.T2退貨明細.RowHeadersVisible = False
        Me.T2退貨明細.RowTemplate.Height = 24
        Me.T2退貨明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2退貨明細.Size = New System.Drawing.Size(1012, 169)
        Me.T2退貨明細.TabIndex = 1069
        '
        'TP退貨入庫
        '
        Me.TP退貨入庫.Controls.Add(Me.Cb3印表機)
        Me.TP退貨入庫.Controls.Add(Me.Label8)
        Me.TP退貨入庫.Controls.Add(Me.TB3儲位)
        Me.TP退貨入庫.Controls.Add(Me.TB3備註)
        Me.TP退貨入庫.Controls.Add(Me.T3過帳日期)
        Me.TP退貨入庫.Controls.Add(Me.Bu3放棄)
        Me.TP退貨入庫.Controls.Add(Me.Label7)
        Me.TP退貨入庫.Controls.Add(Me.回存入庫)
        Me.TP退貨入庫.Controls.Add(Me.T3退貨條碼)
        Me.TP退貨入庫.Controls.Add(Me.T3退貨明細)
        Me.TP退貨入庫.Location = New System.Drawing.Point(4, 4)
        Me.TP退貨入庫.Name = "TP退貨入庫"
        Me.TP退貨入庫.Size = New System.Drawing.Size(1174, 570)
        Me.TP退貨入庫.TabIndex = 2
        Me.TP退貨入庫.Text = "退貨入庫"
        Me.TP退貨入庫.UseVisualStyleBackColor = True
        '
        'Cb3印表機
        '
        Me.Cb3印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3印表機.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Cb3印表機.FormattingEnabled = True
        Me.Cb3印表機.Location = New System.Drawing.Point(768, 520)
        Me.Cb3印表機.Name = "Cb3印表機"
        Me.Cb3印表機.Size = New System.Drawing.Size(250, 24)
        Me.Cb3印表機.TabIndex = 1067
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(1021, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 1086
        Me.Label8.Text = "儲位："
        '
        'TB3儲位
        '
        Me.TB3儲位.Location = New System.Drawing.Point(1024, 223)
        Me.TB3儲位.Name = "TB3儲位"
        Me.TB3儲位.Size = New System.Drawing.Size(145, 27)
        Me.TB3儲位.TabIndex = 1085
        Me.TB3儲位.Text = "K006"
        '
        'TB3備註
        '
        Me.TB3備註.Location = New System.Drawing.Point(1023, 309)
        Me.TB3備註.Multiline = True
        Me.TB3備註.Name = "TB3備註"
        Me.TB3備註.Size = New System.Drawing.Size(146, 205)
        Me.TB3備註.TabIndex = 1084
        '
        'T3過帳日期
        '
        Me.T3過帳日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T3過帳日期.Location = New System.Drawing.Point(1024, 275)
        Me.T3過帳日期.Name = "T3過帳日期"
        Me.T3過帳日期.Size = New System.Drawing.Size(130, 27)
        Me.T3過帳日期.TabIndex = 1067
        '
        'Bu3放棄
        '
        Me.Bu3放棄.BackColor = System.Drawing.Color.Red
        Me.Bu3放棄.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu3放棄.ForeColor = System.Drawing.Color.Yellow
        Me.Bu3放棄.Location = New System.Drawing.Point(1024, 6)
        Me.Bu3放棄.Name = "Bu3放棄"
        Me.Bu3放棄.Size = New System.Drawing.Size(120, 44)
        Me.Bu3放棄.TabIndex = 1083
        Me.Bu3放棄.Text = "放棄入庫"
        Me.Bu3放棄.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(1021, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 1068
        Me.Label7.Text = "過帳日期："
        '
        '回存入庫
        '
        Me.回存入庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.回存入庫.Location = New System.Drawing.Point(1024, 520)
        Me.回存入庫.Name = "回存入庫"
        Me.回存入庫.Size = New System.Drawing.Size(120, 44)
        Me.回存入庫.TabIndex = 1067
        Me.回存入庫.Text = "回存入庫"
        Me.回存入庫.UseVisualStyleBackColor = True
        '
        'T3退貨條碼
        '
        Me.T3退貨條碼.AllowUserToAddRows = False
        Me.T3退貨條碼.AllowUserToDeleteRows = False
        Me.T3退貨條碼.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T3退貨條碼.Location = New System.Drawing.Point(6, 256)
        Me.T3退貨條碼.MultiSelect = False
        Me.T3退貨條碼.Name = "T3退貨條碼"
        Me.T3退貨條碼.ReadOnly = True
        Me.T3退貨條碼.RowHeadersVisible = False
        Me.T3退貨條碼.RowTemplate.Height = 24
        Me.T3退貨條碼.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T3退貨條碼.Size = New System.Drawing.Size(1012, 258)
        Me.T3退貨條碼.TabIndex = 1082
        '
        'T3退貨明細
        '
        Me.T3退貨明細.AllowUserToAddRows = False
        Me.T3退貨明細.AllowUserToDeleteRows = False
        Me.T3退貨明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T3退貨明細.Location = New System.Drawing.Point(6, 6)
        Me.T3退貨明細.MultiSelect = False
        Me.T3退貨明細.Name = "T3退貨明細"
        Me.T3退貨明細.ReadOnly = True
        Me.T3退貨明細.RowHeadersVisible = False
        Me.T3退貨明細.RowTemplate.Height = 24
        Me.T3退貨明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T3退貨明細.Size = New System.Drawing.Size(1012, 244)
        Me.T3退貨明細.TabIndex = 1081
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(1192, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(130, 167)
        Me.Panel1.TabIndex = 1067
        '
        '退貨入庫V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 637)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Lt作業)
        Me.Controls.Add(Me.TB單號)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TB名稱)
        Me.Controls.Add(Me.TB客編)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "退貨入庫V100"
        Me.Text = "退貨入庫"
        Me.TabControl1.ResumeLayout(False)
        Me.TP單據查詢.ResumeLayout(False)
        Me.TP單據查詢.PerformLayout()
        CType(Me.T1退貨條碼, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1退貨明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1退貨單號, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP退貨條碼.ResumeLayout(False)
        Me.TP退貨條碼.PerformLayout()
        CType(Me.T2退貨條碼, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2退貨明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP退貨入庫.ResumeLayout(False)
        Me.TP退貨入庫.PerformLayout()
        CType(Me.T3退貨條碼, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T3退貨明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lt作業 As System.Windows.Forms.Label
    Friend WithEvents TB單號 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TB名稱 As System.Windows.Forms.TextBox
    Friend WithEvents TB客編 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP退貨條碼 As System.Windows.Forms.TabPage
    Friend WithEvents TP單據查詢 As System.Windows.Forms.TabPage
    Friend WithEvents De1開始 As System.Windows.Forms.DateTimePicker
    Friend WithEvents De1結束 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Rb1日期 As System.Windows.Forms.RadioButton
    Friend WithEvents Bu1新增 As System.Windows.Forms.Button
    Friend WithEvents Bu1查詢 As System.Windows.Forms.Button
    Friend WithEvents T1退貨明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T1退貨單號 As System.Windows.Forms.DataGridView
    Friend WithEvents T2退貨明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T2退貨條碼 As System.Windows.Forms.DataGridView
    Friend WithEvents La2小單位 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents La2品名 As System.Windows.Forms.Label
    Friend WithEvents La2存編 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb2重量 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tb2退貨 As System.Windows.Forms.TextBox
    Friend WithEvents Bu2存檔 As System.Windows.Forms.Button
    Friend WithEvents Bu2新增 As System.Windows.Forms.Button
    Friend WithEvents Bu2刪除 As System.Windows.Forms.Button
    Friend WithEvents TP退貨入庫 As System.Windows.Forms.TabPage
    Friend WithEvents Bu2入庫 As System.Windows.Forms.Button
    Friend WithEvents T3退貨條碼 As System.Windows.Forms.DataGridView
    Friend WithEvents T3退貨明細 As System.Windows.Forms.DataGridView
    Friend WithEvents La2條碼 As System.Windows.Forms.Label
    Friend WithEvents T1退貨條碼 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu3放棄 As System.Windows.Forms.Button
    Friend WithEvents 回存入庫 As System.Windows.Forms.Button
    Friend WithEvents T3過帳日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TB3備註 As System.Windows.Forms.TextBox
    Friend WithEvents Bu1入庫 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB3儲位 As System.Windows.Forms.TextBox
    Friend WithEvents Bu2放棄 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Bu1列印 As System.Windows.Forms.Button
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents Cb3印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
