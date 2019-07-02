<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產入庫自動化v100
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
        Me.components = New System.ComponentModel.Container
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.入庫作業 = New System.Windows.Forms.TabPage
        Me.入庫單號 = New System.Windows.Forms.Label
        Me.回存入庫 = New System.Windows.Forms.Button
        Me.明細件數 = New System.Windows.Forms.Label
        Me.入庫包數 = New System.Windows.Forms.Label
        Me.入庫條碼 = New System.Windows.Forms.DataGridView
        Me.入庫重量 = New System.Windows.Forms.Label
        Me.表身 = New System.Windows.Forms.DataGridView
        Me.入庫件數 = New System.Windows.Forms.Label
        Me.製單 = New System.Windows.Forms.DataGridView
        Me.明細 = New System.Windows.Forms.DataGridView
        Me.PDA轉入 = New System.Windows.Forms.TabPage
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.La時間 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.La入庫 = New System.Windows.Forms.Label
        Me.La數量 = New System.Windows.Forms.Label
        Me.La重複 = New System.Windows.Forms.Label
        Me.La異常 = New System.Windows.Forms.Label
        Me.La作廢 = New System.Windows.Forms.Label
        Me.La出庫 = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.Bu讀取 = New System.Windows.Forms.Button
        Me.Bu同步 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.La作業 = New System.Windows.Forms.Label
        Me.Bu移除 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.電腦時間 = New System.Windows.Forms.Label
        Me.即時時間 = New System.Windows.Forms.Timer(Me.components)
        Me.序號批次選擇 = New System.Windows.Forms.Panel
        Me.查詢 = New System.Windows.Forms.Button
        Me.RB批次 = New System.Windows.Forms.RadioButton
        Me.RB序號 = New System.Windows.Forms.RadioButton
        Me.自動開啟 = New System.Windows.Forms.CheckBox
        Me.作業製單 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.收貨類型 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.過帳日期 = New System.Windows.Forms.DateTimePicker
        Me.Bu更新資料 = New System.Windows.Forms.Button
        Me.Td = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.入庫作業.SuspendLayout()
        CType(Me.入庫條碼, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.表身, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.製單, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PDA轉入.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.序號批次選擇.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.入庫作業)
        Me.TabControl1.Controls.Add(Me.PDA轉入)
        Me.TabControl1.Location = New System.Drawing.Point(2, 43)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(960, 589)
        Me.TabControl1.TabIndex = 0
        '
        '入庫作業
        '
        Me.入庫作業.Controls.Add(Me.入庫單號)
        Me.入庫作業.Controls.Add(Me.回存入庫)
        Me.入庫作業.Controls.Add(Me.明細件數)
        Me.入庫作業.Controls.Add(Me.入庫包數)
        Me.入庫作業.Controls.Add(Me.入庫條碼)
        Me.入庫作業.Controls.Add(Me.入庫重量)
        Me.入庫作業.Controls.Add(Me.表身)
        Me.入庫作業.Controls.Add(Me.入庫件數)
        Me.入庫作業.Controls.Add(Me.製單)
        Me.入庫作業.Controls.Add(Me.明細)
        Me.入庫作業.Location = New System.Drawing.Point(4, 22)
        Me.入庫作業.Name = "入庫作業"
        Me.入庫作業.Padding = New System.Windows.Forms.Padding(3)
        Me.入庫作業.Size = New System.Drawing.Size(952, 563)
        Me.入庫作業.TabIndex = 0
        Me.入庫作業.Text = "入庫作業"
        Me.入庫作業.UseVisualStyleBackColor = True
        '
        '入庫單號
        '
        Me.入庫單號.AutoSize = True
        Me.入庫單號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫單號.Location = New System.Drawing.Point(6, 501)
        Me.入庫單號.Name = "入庫單號"
        Me.入庫單號.Size = New System.Drawing.Size(76, 16)
        Me.入庫單號.TabIndex = 188
        Me.入庫單號.Text = "入庫單號"
        Me.入庫單號.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '回存入庫
        '
        Me.回存入庫.Enabled = False
        Me.回存入庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.回存入庫.Location = New System.Drawing.Point(851, 513)
        Me.回存入庫.Name = "回存入庫"
        Me.回存入庫.Size = New System.Drawing.Size(95, 44)
        Me.回存入庫.TabIndex = 187
        Me.回存入庫.Text = "回存入庫"
        Me.回存入庫.UseVisualStyleBackColor = True
        Me.回存入庫.Visible = False
        '
        '明細件數
        '
        Me.明細件數.AutoSize = True
        Me.明細件數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.明細件數.Location = New System.Drawing.Point(6, 453)
        Me.明細件數.Name = "明細件數"
        Me.明細件數.Size = New System.Drawing.Size(76, 16)
        Me.明細件數.TabIndex = 182
        Me.明細件數.Text = "明細件數"
        Me.明細件數.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '入庫包數
        '
        Me.入庫包數.AutoSize = True
        Me.入庫包數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫包數.Location = New System.Drawing.Point(6, 485)
        Me.入庫包數.Name = "入庫包數"
        Me.入庫包數.Size = New System.Drawing.Size(76, 16)
        Me.入庫包數.TabIndex = 181
        Me.入庫包數.Text = "入庫包數"
        Me.入庫包數.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.入庫包數.Visible = False
        '
        '入庫條碼
        '
        Me.入庫條碼.AllowUserToAddRows = False
        Me.入庫條碼.AllowUserToDeleteRows = False
        Me.入庫條碼.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.入庫條碼.Location = New System.Drawing.Point(115, 280)
        Me.入庫條碼.MultiSelect = False
        Me.入庫條碼.Name = "入庫條碼"
        Me.入庫條碼.ReadOnly = True
        Me.入庫條碼.RowHeadersWidth = 20
        Me.入庫條碼.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.入庫條碼.RowTemplate.Height = 24
        Me.入庫條碼.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.入庫條碼.Size = New System.Drawing.Size(730, 277)
        Me.入庫條碼.TabIndex = 180
        Me.入庫條碼.Visible = False
        '
        '入庫重量
        '
        Me.入庫重量.AutoSize = True
        Me.入庫重量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫重量.Location = New System.Drawing.Point(6, 469)
        Me.入庫重量.Name = "入庫重量"
        Me.入庫重量.Size = New System.Drawing.Size(76, 16)
        Me.入庫重量.TabIndex = 180
        Me.入庫重量.Text = "入庫重量"
        Me.入庫重量.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '表身
        '
        Me.表身.AllowUserToAddRows = False
        Me.表身.AllowUserToDeleteRows = False
        Me.表身.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.表身.Location = New System.Drawing.Point(149, 4)
        Me.表身.MultiSelect = False
        Me.表身.Name = "表身"
        Me.表身.ReadOnly = True
        Me.表身.RowHeadersWidth = 25
        Me.表身.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.表身.RowTemplate.Height = 24
        Me.表身.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.表身.Size = New System.Drawing.Size(800, 164)
        Me.表身.TabIndex = 179
        '
        '入庫件數
        '
        Me.入庫件數.AutoSize = True
        Me.入庫件數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫件數.Location = New System.Drawing.Point(6, 437)
        Me.入庫件數.Name = "入庫件數"
        Me.入庫件數.Size = New System.Drawing.Size(76, 16)
        Me.入庫件數.TabIndex = 179
        Me.入庫件數.Text = "入庫件數"
        Me.入庫件數.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '製單
        '
        Me.製單.AllowUserToAddRows = False
        Me.製單.AllowUserToDeleteRows = False
        Me.製單.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.製單.Location = New System.Drawing.Point(6, 4)
        Me.製單.MultiSelect = False
        Me.製單.Name = "製單"
        Me.製單.ReadOnly = True
        Me.製單.RowHeadersWidth = 20
        Me.製單.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.製單.RowTemplate.Height = 24
        Me.製單.Size = New System.Drawing.Size(140, 430)
        Me.製單.TabIndex = 177
        '
        '明細
        '
        Me.明細.AllowUserToAddRows = False
        Me.明細.AllowUserToDeleteRows = False
        Me.明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.明細.Location = New System.Drawing.Point(149, 171)
        Me.明細.MultiSelect = False
        Me.明細.Name = "明細"
        Me.明細.ReadOnly = True
        Me.明細.RowHeadersWidth = 25
        Me.明細.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.明細.RowTemplate.Height = 24
        Me.明細.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.明細.Size = New System.Drawing.Size(800, 263)
        Me.明細.TabIndex = 178
        '
        'PDA轉入
        '
        Me.PDA轉入.Controls.Add(Me.DGV1)
        Me.PDA轉入.Controls.Add(Me.La時間)
        Me.PDA轉入.Controls.Add(Me.Label1)
        Me.PDA轉入.Controls.Add(Me.La入庫)
        Me.PDA轉入.Controls.Add(Me.La數量)
        Me.PDA轉入.Controls.Add(Me.La重複)
        Me.PDA轉入.Controls.Add(Me.La異常)
        Me.PDA轉入.Controls.Add(Me.La作廢)
        Me.PDA轉入.Controls.Add(Me.La出庫)
        Me.PDA轉入.Controls.Add(Me.DGV3)
        Me.PDA轉入.Controls.Add(Me.Bu讀取)
        Me.PDA轉入.Controls.Add(Me.Bu同步)
        Me.PDA轉入.Controls.Add(Me.Label10)
        Me.PDA轉入.Controls.Add(Me.Label6)
        Me.PDA轉入.Controls.Add(Me.Label5)
        Me.PDA轉入.Controls.Add(Me.Label4)
        Me.PDA轉入.Controls.Add(Me.Label3)
        Me.PDA轉入.Controls.Add(Me.La作業)
        Me.PDA轉入.Controls.Add(Me.Bu移除)
        Me.PDA轉入.Controls.Add(Me.Label9)
        Me.PDA轉入.Controls.Add(Me.Label8)
        Me.PDA轉入.Location = New System.Drawing.Point(4, 22)
        Me.PDA轉入.Name = "PDA轉入"
        Me.PDA轉入.Padding = New System.Windows.Forms.Padding(3)
        Me.PDA轉入.Size = New System.Drawing.Size(952, 563)
        Me.PDA轉入.TabIndex = 1
        Me.PDA轉入.Text = "PDA轉入"
        Me.PDA轉入.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(4, 30)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(680, 527)
        Me.DGV1.TabIndex = 87
        '
        'La時間
        '
        Me.La時間.AutoSize = True
        Me.La時間.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La時間.Location = New System.Drawing.Point(718, 11)
        Me.La時間.Name = "La時間"
        Me.La時間.Size = New System.Drawing.Size(72, 16)
        Me.La時間.TabIndex = 227
        Me.La時間.Text = "執行時間"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(252, 21)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "條碼入出庫清點同步作業"
        '
        'La入庫
        '
        Me.La入庫.AutoSize = True
        Me.La入庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La入庫.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La入庫.Location = New System.Drawing.Point(774, 102)
        Me.La入庫.Name = "La入庫"
        Me.La入庫.Size = New System.Drawing.Size(49, 19)
        Me.La入庫.TabIndex = 213
        Me.La入庫.Text = "入庫"
        '
        'La數量
        '
        Me.La數量.AutoSize = True
        Me.La數量.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La數量.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La數量.Location = New System.Drawing.Point(774, 83)
        Me.La數量.Name = "La數量"
        Me.La數量.Size = New System.Drawing.Size(49, 19)
        Me.La數量.TabIndex = 212
        Me.La數量.Text = "數量"
        '
        'La重複
        '
        Me.La重複.AutoSize = True
        Me.La重複.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La重複.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La重複.Location = New System.Drawing.Point(774, 159)
        Me.La重複.Name = "La重複"
        Me.La重複.Size = New System.Drawing.Size(49, 19)
        Me.La重複.TabIndex = 225
        Me.La重複.Text = "重複"
        Me.La重複.Visible = False
        '
        'La異常
        '
        Me.La異常.AutoSize = True
        Me.La異常.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La異常.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La異常.Location = New System.Drawing.Point(774, 140)
        Me.La異常.Name = "La異常"
        Me.La異常.Size = New System.Drawing.Size(49, 19)
        Me.La異常.TabIndex = 223
        Me.La異常.Text = "異常"
        '
        'La作廢
        '
        Me.La作廢.AutoSize = True
        Me.La作廢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La作廢.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La作廢.Location = New System.Drawing.Point(774, 121)
        Me.La作廢.Name = "La作廢"
        Me.La作廢.Size = New System.Drawing.Size(49, 19)
        Me.La作廢.TabIndex = 221
        Me.La作廢.Text = "作廢"
        '
        'La出庫
        '
        Me.La出庫.AutoSize = True
        Me.La出庫.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La出庫.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.La出庫.Location = New System.Drawing.Point(886, 102)
        Me.La出庫.Name = "La出庫"
        Me.La出庫.Size = New System.Drawing.Size(49, 19)
        Me.La出庫.TabIndex = 214
        Me.La出庫.Text = "出庫"
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(717, 262)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(230, 202)
        Me.DGV3.TabIndex = 210
        '
        'Bu讀取
        '
        Me.Bu讀取.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu讀取.Location = New System.Drawing.Point(716, 30)
        Me.Bu讀取.Name = "Bu讀取"
        Me.Bu讀取.Size = New System.Drawing.Size(230, 50)
        Me.Bu讀取.TabIndex = 209
        Me.Bu讀取.Text = "讀取待轉區資料"
        Me.Bu讀取.UseVisualStyleBackColor = True
        '
        'Bu同步
        '
        Me.Bu同步.Enabled = False
        Me.Bu同步.Font = New System.Drawing.Font("微軟正黑體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu同步.ForeColor = System.Drawing.Color.Red
        Me.Bu同步.Location = New System.Drawing.Point(716, 470)
        Me.Bu同步.Name = "Bu同步"
        Me.Bu同步.Size = New System.Drawing.Size(230, 50)
        Me.Bu同步.TabIndex = 211
        Me.Bu同步.Text = "同步至資料庫"
        Me.Bu同步.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(717, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 19)
        Me.Label10.TabIndex = 226
        Me.Label10.Text = "重複："
        Me.Label10.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(717, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 19)
        Me.Label6.TabIndex = 215
        Me.Label6.Text = "儲位數量"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(717, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 19)
        Me.Label5.TabIndex = 216
        Me.Label5.Text = "數量："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(717, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 19)
        Me.Label4.TabIndex = 217
        Me.Label4.Text = "入庫："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(829, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 218
        Me.Label3.Text = "出庫："
        '
        'La作業
        '
        Me.La作業.AutoSize = True
        Me.La作業.Font = New System.Drawing.Font("新細明體", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La作業.ForeColor = System.Drawing.Color.Red
        Me.La作業.Location = New System.Drawing.Point(719, 523)
        Me.La作業.Name = "La作業"
        Me.La作業.Size = New System.Drawing.Size(87, 35)
        Me.La作業.TabIndex = 219
        Me.La作業.Text = "作業"
        '
        'Bu移除
        '
        Me.Bu移除.Font = New System.Drawing.Font("微軟正黑體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu移除.ForeColor = System.Drawing.Color.Red
        Me.Bu移除.Location = New System.Drawing.Point(796, 209)
        Me.Bu移除.Name = "Bu移除"
        Me.Bu移除.Size = New System.Drawing.Size(150, 30)
        Me.Bu移除.TabIndex = 220
        Me.Bu移除.Text = "移除異常條碼"
        Me.Bu移除.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(717, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 19)
        Me.Label9.TabIndex = 224
        Me.Label9.Text = "異常："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(717, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 19)
        Me.Label8.TabIndex = 222
        Me.Label8.Text = "作廢："
        '
        '電腦時間
        '
        Me.電腦時間.AutoSize = True
        Me.電腦時間.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.電腦時間.ForeColor = System.Drawing.Color.Red
        Me.電腦時間.Location = New System.Drawing.Point(717, 5)
        Me.電腦時間.Name = "電腦時間"
        Me.電腦時間.Size = New System.Drawing.Size(89, 19)
        Me.電腦時間.TabIndex = 85
        Me.電腦時間.Text = "電腦時間"
        '
        '即時時間
        '
        '
        '序號批次選擇
        '
        Me.序號批次選擇.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.序號批次選擇.Controls.Add(Me.查詢)
        Me.序號批次選擇.Controls.Add(Me.RB批次)
        Me.序號批次選擇.Controls.Add(Me.RB序號)
        Me.序號批次選擇.Location = New System.Drawing.Point(2, 2)
        Me.序號批次選擇.Name = "序號批次選擇"
        Me.序號批次選擇.Size = New System.Drawing.Size(200, 28)
        Me.序號批次選擇.TabIndex = 169
        Me.序號批次選擇.Visible = False
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(118, 0)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(75, 26)
        Me.查詢.TabIndex = 4
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        'RB批次
        '
        Me.RB批次.AutoSize = True
        Me.RB批次.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB批次.Location = New System.Drawing.Point(61, 2)
        Me.RB批次.Name = "RB批次"
        Me.RB批次.Size = New System.Drawing.Size(58, 20)
        Me.RB批次.TabIndex = 1
        Me.RB批次.Text = "加工"
        Me.RB批次.UseVisualStyleBackColor = True
        '
        'RB序號
        '
        Me.RB序號.AutoSize = True
        Me.RB序號.Checked = True
        Me.RB序號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB序號.Location = New System.Drawing.Point(3, 2)
        Me.RB序號.Name = "RB序號"
        Me.RB序號.Size = New System.Drawing.Size(58, 20)
        Me.RB序號.TabIndex = 0
        Me.RB序號.TabStop = True
        Me.RB序號.Text = "電宰"
        Me.RB序號.UseVisualStyleBackColor = True
        '
        '自動開啟
        '
        Me.自動開啟.AutoSize = True
        Me.自動開啟.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.自動開啟.Location = New System.Drawing.Point(208, 6)
        Me.自動開啟.Name = "自動開啟"
        Me.自動開啟.Size = New System.Drawing.Size(123, 20)
        Me.自動開啟.TabIndex = 170
        Me.自動開啟.Text = "自動入庫開啟"
        Me.自動開啟.UseVisualStyleBackColor = True
        '
        '作業製單
        '
        Me.作業製單.AutoSize = True
        Me.作業製單.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.作業製單.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.作業製單.Location = New System.Drawing.Point(75, 40)
        Me.作業製單.Name = "作業製單"
        Me.作業製單.Size = New System.Drawing.Size(88, 16)
        Me.作業製單.TabIndex = 171
        Me.作業製單.Text = "作業製單："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(337, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "收貨類型："
        '
        '收貨類型
        '
        Me.收貨類型.Enabled = False
        Me.收貨類型.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.收貨類型.FormattingEnabled = True
        Me.收貨類型.Items.AddRange(New Object() {"生產收貨", "委外加工收貨"})
        Me.收貨類型.Location = New System.Drawing.Point(421, 31)
        Me.收貨類型.Name = "收貨類型"
        Me.收貨類型.Size = New System.Drawing.Size(130, 24)
        Me.收貨類型.TabIndex = 183
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(337, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 186
        Me.Label7.Text = "過帳日期："
        '
        '過帳日期
        '
        Me.過帳日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.過帳日期.Location = New System.Drawing.Point(421, 1)
        Me.過帳日期.Name = "過帳日期"
        Me.過帳日期.Size = New System.Drawing.Size(130, 27)
        Me.過帳日期.TabIndex = 185
        '
        'Bu更新資料
        '
        Me.Bu更新資料.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu更新資料.Location = New System.Drawing.Point(616, 1)
        Me.Bu更新資料.Name = "Bu更新資料"
        Me.Bu更新資料.Size = New System.Drawing.Size(95, 44)
        Me.Bu更新資料.TabIndex = 189
        Me.Bu更新資料.Text = "更新資料"
        Me.Bu更新資料.UseVisualStyleBackColor = True
        '
        'Td
        '
        Me.Td.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Td.BackColor = System.Drawing.SystemColors.Window
        Me.Td.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Td.Location = New System.Drawing.Point(721, 24)
        Me.Td.Name = "Td"
        Me.Td.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Td.Size = New System.Drawing.Size(85, 27)
        Me.Td.TabIndex = 274
        Me.Td.TabStop = False
        Me.Td.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '生產入庫自動化v100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 637)
        Me.Controls.Add(Me.Td)
        Me.Controls.Add(Me.Bu更新資料)
        Me.Controls.Add(Me.收貨類型)
        Me.Controls.Add(Me.過帳日期)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.作業製單)
        Me.Controls.Add(Me.自動開啟)
        Me.Controls.Add(Me.序號批次選擇)
        Me.Controls.Add(Me.電腦時間)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "生產入庫自動化v100"
        Me.Text = "生產入庫自動化"
        Me.TabControl1.ResumeLayout(False)
        Me.入庫作業.ResumeLayout(False)
        Me.入庫作業.PerformLayout()
        CType(Me.入庫條碼, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.表身, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.製單, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PDA轉入.ResumeLayout(False)
        Me.PDA轉入.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.序號批次選擇.ResumeLayout(False)
        Me.序號批次選擇.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents 入庫作業 As System.Windows.Forms.TabPage
    Friend WithEvents PDA轉入 As System.Windows.Forms.TabPage
    Friend WithEvents La入庫 As System.Windows.Forms.Label
    Friend WithEvents La數量 As System.Windows.Forms.Label
    Friend WithEvents La重複 As System.Windows.Forms.Label
    Friend WithEvents La異常 As System.Windows.Forms.Label
    Friend WithEvents La作廢 As System.Windows.Forms.Label
    Friend WithEvents La出庫 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu讀取 As System.Windows.Forms.Button
    Friend WithEvents Bu同步 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents La作業 As System.Windows.Forms.Label
    Friend WithEvents Bu移除 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents La時間 As System.Windows.Forms.Label
    Friend WithEvents 電腦時間 As System.Windows.Forms.Label
    Friend WithEvents 即時時間 As System.Windows.Forms.Timer
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 序號批次選擇 As System.Windows.Forms.Panel
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents RB批次 As System.Windows.Forms.RadioButton
    Friend WithEvents RB序號 As System.Windows.Forms.RadioButton
    Friend WithEvents 表身 As System.Windows.Forms.DataGridView
    Friend WithEvents 製單 As System.Windows.Forms.DataGridView
    Friend WithEvents 明細 As System.Windows.Forms.DataGridView
    Friend WithEvents 自動開啟 As System.Windows.Forms.CheckBox
    Friend WithEvents 入庫條碼 As System.Windows.Forms.DataGridView
    Friend WithEvents 作業製單 As System.Windows.Forms.Label
    Friend WithEvents 入庫包數 As System.Windows.Forms.Label
    Friend WithEvents 入庫重量 As System.Windows.Forms.Label
    Friend WithEvents 入庫件數 As System.Windows.Forms.Label
    Friend WithEvents 明細件數 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 收貨類型 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 過帳日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 回存入庫 As System.Windows.Forms.Button
    Friend WithEvents 入庫單號 As System.Windows.Forms.Label
    Friend WithEvents Bu更新資料 As System.Windows.Forms.Button
    Friend WithEvents Td As System.Windows.Forms.TextBox
End Class
