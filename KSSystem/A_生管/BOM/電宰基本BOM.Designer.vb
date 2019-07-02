<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 電宰基本BOM
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
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.設定T1 = New System.Windows.Forms.Label
        Me.品名T1 = New System.Windows.Forms.Label
        Me.存編T1 = New System.Windows.Forms.Label
        Me.查看0 = New System.Windows.Forms.Button
        Me.新增0 = New System.Windows.Forms.Button
        Me.W品名 = New System.Windows.Forms.TextBox
        Me.修改0 = New System.Windows.Forms.Button
        Me.查詢0 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.W保存方式 = New System.Windows.Forms.ComboBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.包含查詢 = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.品WT23 = New System.Windows.Forms.TextBox
        Me.品WT22 = New System.Windows.Forms.TextBox
        Me.品WT21 = New System.Windows.Forms.TextBox
        Me.DGV21 = New System.Windows.Forms.DataGridView
        Me.查詢T2 = New System.Windows.Forms.Button
        Me.品名T2D21 = New System.Windows.Forms.TextBox
        Me.存編T2D21 = New System.Windows.Forms.TextBox
        Me.單位T2D21 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.數量T2D21 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.順序T2D21 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.類別T2D21 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.離開T2 = New System.Windows.Forms.Button
        Me.存檔T2 = New System.Windows.Forms.Button
        Me.DGV22 = New System.Windows.Forms.DataGridView
        Me.品名T2 = New System.Windows.Forms.Label
        Me.存編T2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.W產品類別 = New System.Windows.Forms.ComboBox
        Me.停用0 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, -5)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(945, 700)
        Me.TabControl1.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.查看0)
        Me.TabPage1.Controls.Add(Me.新增0)
        Me.TabPage1.Controls.Add(Me.W品名)
        Me.TabPage1.Controls.Add(Me.修改0)
        Me.TabPage1.Controls.Add(Me.查詢0)
        Me.TabPage1.Controls.Add(Me.DGV1)
        Me.TabPage1.Controls.Add(Me.W保存方式)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(937, 670)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "查詢"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 19)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "品名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "保存方式"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.設定T1)
        Me.GroupBox1.Controls.Add(Me.品名T1)
        Me.GroupBox1.Controls.Add(Me.存編T1)
        Me.GroupBox1.Location = New System.Drawing.Point(478, 475)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 165)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "參數區"
        Me.GroupBox1.Visible = False
        '
        '設定T1
        '
        Me.設定T1.AutoSize = True
        Me.設定T1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.設定T1.Location = New System.Drawing.Point(6, 61)
        Me.設定T1.Name = "設定T1"
        Me.設定T1.Size = New System.Drawing.Size(47, 19)
        Me.設定T1.TabIndex = 19
        Me.設定T1.Text = "設定"
        '
        '品名T1
        '
        Me.品名T1.AutoSize = True
        Me.品名T1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.品名T1.Location = New System.Drawing.Point(6, 42)
        Me.品名T1.Name = "品名T1"
        Me.品名T1.Size = New System.Drawing.Size(47, 19)
        Me.品名T1.TabIndex = 18
        Me.品名T1.Text = "品名"
        '
        '存編T1
        '
        Me.存編T1.AutoSize = True
        Me.存編T1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.存編T1.Location = New System.Drawing.Point(6, 23)
        Me.存編T1.Name = "存編T1"
        Me.存編T1.Size = New System.Drawing.Size(47, 19)
        Me.存編T1.TabIndex = 17
        Me.存編T1.Text = "存編"
        '
        '查看0
        '
        Me.查看0.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查看0.Location = New System.Drawing.Point(647, 69)
        Me.查看0.Name = "查看0"
        Me.查看0.Size = New System.Drawing.Size(90, 30)
        Me.查看0.TabIndex = 13
        Me.查看0.Text = "查看"
        Me.查看0.UseVisualStyleBackColor = True
        '
        '新增0
        '
        Me.新增0.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.新增0.Location = New System.Drawing.Point(743, 69)
        Me.新增0.Name = "新增0"
        Me.新增0.Size = New System.Drawing.Size(90, 30)
        Me.新增0.TabIndex = 0
        Me.新增0.Text = "新增"
        Me.新增0.UseVisualStyleBackColor = True
        '
        'W品名
        '
        Me.W品名.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.W品名.Location = New System.Drawing.Point(94, 69)
        Me.W品名.Name = "W品名"
        Me.W品名.Size = New System.Drawing.Size(214, 30)
        Me.W品名.TabIndex = 11
        '
        '修改0
        '
        Me.修改0.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.修改0.Location = New System.Drawing.Point(839, 69)
        Me.修改0.Name = "修改0"
        Me.修改0.Size = New System.Drawing.Size(90, 30)
        Me.修改0.TabIndex = 1
        Me.修改0.Text = "修改"
        Me.修改0.UseVisualStyleBackColor = True
        '
        '查詢0
        '
        Me.查詢0.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢0.Location = New System.Drawing.Point(314, 69)
        Me.查詢0.Name = "查詢0"
        Me.查詢0.Size = New System.Drawing.Size(90, 30)
        Me.查詢0.TabIndex = 3
        Me.查詢0.Text = "查詢"
        Me.查詢0.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 107)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(923, 543)
        Me.DGV1.TabIndex = 4
        '
        'W保存方式
        '
        Me.W保存方式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.W保存方式.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.W保存方式.FormattingEnabled = True
        Me.W保存方式.Items.AddRange(New Object() {"", "1.冷凍", "2.冷藏", "3.預解", "4."})
        Me.W保存方式.Location = New System.Drawing.Point(94, 3)
        Me.W保存方式.Name = "W保存方式"
        Me.W保存方式.Size = New System.Drawing.Size(118, 27)
        Me.W保存方式.TabIndex = 7
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.包含查詢)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.品WT23)
        Me.TabPage2.Controls.Add(Me.品WT22)
        Me.TabPage2.Controls.Add(Me.品WT21)
        Me.TabPage2.Controls.Add(Me.DGV21)
        Me.TabPage2.Controls.Add(Me.查詢T2)
        Me.TabPage2.Controls.Add(Me.品名T2D21)
        Me.TabPage2.Controls.Add(Me.存編T2D21)
        Me.TabPage2.Controls.Add(Me.單位T2D21)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.數量T2D21)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.順序T2D21)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.類別T2D21)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.離開T2)
        Me.TabPage2.Controls.Add(Me.存檔T2)
        Me.TabPage2.Controls.Add(Me.DGV22)
        Me.TabPage2.Controls.Add(Me.品名T2)
        Me.TabPage2.Controls.Add(Me.存編T2)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(937, 670)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "新增"
        '
        '包含查詢
        '
        Me.包含查詢.AutoSize = True
        Me.包含查詢.Location = New System.Drawing.Point(104, 88)
        Me.包含查詢.Name = "包含查詢"
        Me.包含查詢.Size = New System.Drawing.Size(129, 20)
        Me.包含查詢.TabIndex = 42
        Me.包含查詢.Text = "啟用包含查詢"
        Me.包含查詢.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 19)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "品名查詢"
        '
        '品WT23
        '
        Me.品WT23.Location = New System.Drawing.Point(6, 180)
        Me.品WT23.Name = "品WT23"
        Me.品WT23.Size = New System.Drawing.Size(100, 27)
        Me.品WT23.TabIndex = 40
        '
        '品WT22
        '
        Me.品WT22.Location = New System.Drawing.Point(6, 147)
        Me.品WT22.Name = "品WT22"
        Me.品WT22.Size = New System.Drawing.Size(100, 27)
        Me.品WT22.TabIndex = 39
        '
        '品WT21
        '
        Me.品WT21.Location = New System.Drawing.Point(6, 114)
        Me.品WT21.Name = "品WT21"
        Me.品WT21.Size = New System.Drawing.Size(100, 27)
        Me.品WT21.TabIndex = 38
        '
        'DGV21
        '
        Me.DGV21.AllowUserToAddRows = False
        Me.DGV21.AllowUserToDeleteRows = False
        Me.DGV21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV21.Location = New System.Drawing.Point(7, 210)
        Me.DGV21.Name = "DGV21"
        Me.DGV21.ReadOnly = True
        Me.DGV21.RowHeadersWidth = 25
        Me.DGV21.RowTemplate.Height = 24
        Me.DGV21.Size = New System.Drawing.Size(299, 440)
        Me.DGV21.TabIndex = 37
        '
        '查詢T2
        '
        Me.查詢T2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢T2.Location = New System.Drawing.Point(216, 174)
        Me.查詢T2.Name = "查詢T2"
        Me.查詢T2.Size = New System.Drawing.Size(90, 30)
        Me.查詢T2.TabIndex = 36
        Me.查詢T2.Text = "查詢"
        Me.查詢T2.UseVisualStyleBackColor = True
        '
        '品名T2D21
        '
        Me.品名T2D21.BackColor = System.Drawing.Color.White
        Me.品名T2D21.Location = New System.Drawing.Point(273, 4)
        Me.品名T2D21.Name = "品名T2D21"
        Me.品名T2D21.ReadOnly = True
        Me.品名T2D21.Size = New System.Drawing.Size(448, 27)
        Me.品名T2D21.TabIndex = 35
        '
        '存編T2D21
        '
        Me.存編T2D21.BackColor = System.Drawing.Color.White
        Me.存編T2D21.Location = New System.Drawing.Point(63, 4)
        Me.存編T2D21.Name = "存編T2D21"
        Me.存編T2D21.ReadOnly = True
        Me.存編T2D21.Size = New System.Drawing.Size(142, 27)
        Me.存編T2D21.TabIndex = 34
        '
        '單位T2D21
        '
        Me.單位T2D21.Location = New System.Drawing.Point(621, 36)
        Me.單位T2D21.Name = "單位T2D21"
        Me.單位T2D21.Size = New System.Drawing.Size(100, 27)
        Me.單位T2D21.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(555, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 19)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "單位："
        '
        '數量T2D21
        '
        Me.數量T2D21.Location = New System.Drawing.Point(449, 36)
        Me.數量T2D21.Name = "數量T2D21"
        Me.數量T2D21.Size = New System.Drawing.Size(100, 27)
        Me.數量T2D21.TabIndex = 31
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(383, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 19)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "數量："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(211, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 19)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "品名："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 19)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "存編："
        '
        '順序T2D21
        '
        Me.順序T2D21.Location = New System.Drawing.Point(277, 37)
        Me.順序T2D21.Name = "順序T2D21"
        Me.順序T2D21.Size = New System.Drawing.Size(100, 27)
        Me.順序T2D21.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(211, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 19)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "順序："
        '
        '類別T2D21
        '
        Me.類別T2D21.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.類別T2D21.FormattingEnabled = True
        Me.類別T2D21.Items.AddRange(New Object() {"", "物料"})
        Me.類別T2D21.Location = New System.Drawing.Point(68, 40)
        Me.類別T2D21.Name = "類別T2D21"
        Me.類別T2D21.Size = New System.Drawing.Size(121, 24)
        Me.類別T2D21.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 19)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "類別："
        '
        '離開T2
        '
        Me.離開T2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.離開T2.Location = New System.Drawing.Point(843, 2)
        Me.離開T2.Name = "離開T2"
        Me.離開T2.Size = New System.Drawing.Size(90, 30)
        Me.離開T2.TabIndex = 17
        Me.離開T2.Text = "離開"
        Me.離開T2.UseVisualStyleBackColor = True
        '
        '存檔T2
        '
        Me.存檔T2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.存檔T2.Location = New System.Drawing.Point(727, 32)
        Me.存檔T2.Name = "存檔T2"
        Me.存檔T2.Size = New System.Drawing.Size(90, 30)
        Me.存檔T2.TabIndex = 16
        Me.存檔T2.Text = "存檔"
        Me.存檔T2.UseVisualStyleBackColor = True
        '
        'DGV22
        '
        Me.DGV22.AllowUserToAddRows = False
        Me.DGV22.AllowUserToDeleteRows = False
        Me.DGV22.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV22.Location = New System.Drawing.Point(312, 129)
        Me.DGV22.Name = "DGV22"
        Me.DGV22.ReadOnly = True
        Me.DGV22.RowHeadersWidth = 25
        Me.DGV22.RowTemplate.Height = 24
        Me.DGV22.Size = New System.Drawing.Size(621, 521)
        Me.DGV22.TabIndex = 15
        '
        '品名T2
        '
        Me.品名T2.AutoSize = True
        Me.品名T2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.品名T2.Location = New System.Drawing.Point(373, 107)
        Me.品名T2.Name = "品名T2"
        Me.品名T2.Size = New System.Drawing.Size(47, 19)
        Me.品名T2.TabIndex = 14
        Me.品名T2.Text = "品名"
        '
        '存編T2
        '
        Me.存編T2.AutoSize = True
        Me.存編T2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.存編T2.Location = New System.Drawing.Point(372, 76)
        Me.存編T2.Name = "存編T2"
        Me.存編T2.Size = New System.Drawing.Size(47, 19)
        Me.存編T2.TabIndex = 13
        Me.存編T2.Text = "存編"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(311, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "品名："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 19)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "存編："
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(937, 670)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(937, 670)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage5.Location = New System.Drawing.Point(4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(937, 670)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TabPage5"
        '
        'W產品類別
        '
        Me.W產品類別.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.W產品類別.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.W產品類別.FormattingEnabled = True
        Me.W產品類別.Items.AddRange(New Object() {"", "0. 半成品", "1. 全雞湯品類", "2. U全雞湯品類", "3. U切塊湯品類(雙包)", "4. 切塊湯品", "5. U切塊湯品", "6. 高湯類", "7. U高湯類", "8. U菜餚類", "9. U醉系列", "A. 蒸煮煙燻類", "B. 滷煮類", "C. 油炸類", "D. 米食類", "E. 雞精類", "F. 套餐類", "G. 組合包", "H. 樣品", "J. 乾燥類肉製品", "K. 凝膠"})
        Me.W產品類別.Location = New System.Drawing.Point(97, 208)
        Me.W產品類別.Name = "W產品類別"
        Me.W產品類別.Size = New System.Drawing.Size(214, 27)
        Me.W產品類別.TabIndex = 9
        '
        '停用0
        '
        Me.停用0.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.停用0.Location = New System.Drawing.Point(467, 205)
        Me.停用0.Name = "停用0"
        Me.停用0.Size = New System.Drawing.Size(90, 30)
        Me.停用0.TabIndex = 2
        Me.停用0.Text = "停用"
        Me.停用0.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 19)
        Me.Label9.TabIndex = 0
        '
        '電宰基本BOM
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(934, 696)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximumSize = New System.Drawing.Size(950, 735)
        Me.MinimumSize = New System.Drawing.Size(950, 735)
        Me.Name = "電宰基本BOM"
        Me.Text = "電宰基本BOM"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DGV21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV21 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV22 As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents W保存方式 As System.Windows.Forms.ComboBox
    Friend WithEvents W品名 As System.Windows.Forms.TextBox
    Friend WithEvents W產品類別 As System.Windows.Forms.ComboBox
    Friend WithEvents 包含查詢 As System.Windows.Forms.CheckBox
    Friend WithEvents 存編T2 As System.Windows.Forms.Label
    Friend WithEvents 存編T2D21 As System.Windows.Forms.TextBox
    Friend WithEvents 存檔T2 As System.Windows.Forms.Button
    Friend WithEvents 品WT21 As System.Windows.Forms.TextBox
    Friend WithEvents 品WT22 As System.Windows.Forms.TextBox
    Friend WithEvents 品WT23 As System.Windows.Forms.TextBox
    Friend WithEvents 品名T2 As System.Windows.Forms.Label
    Friend WithEvents 品名T2D21 As System.Windows.Forms.TextBox
    Friend WithEvents 查看0 As System.Windows.Forms.Button
    Friend WithEvents 查詢0 As System.Windows.Forms.Button
    Friend WithEvents 查詢T2 As System.Windows.Forms.Button
    Friend WithEvents 修改0 As System.Windows.Forms.Button
    Friend WithEvents 停用0 As System.Windows.Forms.Button
    Friend WithEvents 單位T2D21 As System.Windows.Forms.TextBox
    Friend WithEvents 順序T2D21 As System.Windows.Forms.TextBox
    Friend WithEvents 新增0 As System.Windows.Forms.Button
    Friend WithEvents 數量T2D21 As System.Windows.Forms.TextBox
    Friend WithEvents 離開T2 As System.Windows.Forms.Button
    Friend WithEvents 類別T2D21 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 設定T1 As System.Windows.Forms.Label
    Friend WithEvents 品名T1 As System.Windows.Forms.Label
    Friend WithEvents 存編T1 As System.Windows.Forms.Label

End Class
