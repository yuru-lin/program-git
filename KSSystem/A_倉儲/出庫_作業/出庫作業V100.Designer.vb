<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 出庫作業V100
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
        Me.作業別類 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.查詢 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.存入條碼 = New System.Windows.Forms.Button
        Me.ExcelDGV = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.查區別明細 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.存草稿單號 = New System.Windows.Forms.Button
        Me.區別 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.草稿 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.查異常條碼 = New System.Windows.Forms.Button
        Me.DGV4 = New System.Windows.Forms.DataGridView
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.DGV5 = New System.Windows.Forms.DataGridView
        Me.草稿比對 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.DGV6 = New System.Windows.Forms.DataGridView
        Me.發貨作業 = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.DGV7 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.刪除區別 = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.修改區別 = New System.Windows.Forms.Button
        Me.刪除條碼 = New System.Windows.Forms.Button
        Me.未入庫 = New System.Windows.Forms.Button
        Me.匯出Excel = New System.Windows.Forms.Button
        Me.清除單號 = New System.Windows.Forms.Button
        Me.查條碼 = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.加工Rb = New System.Windows.Forms.RadioButton
        Me.電宰Rb = New System.Windows.Forms.RadioButton
        Me.作業別 = New System.Windows.Forms.Label
        Me.稿號 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExcelDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "作業類別："
        '
        '作業別類
        '
        Me.作業別類.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.作業別類.FormattingEnabled = True
        Me.作業別類.Items.AddRange(New Object() {"0.銷售出庫", "1.寄庫品出庫", "2.存貨領料出庫", "3.員購(福利社)出庫"})
        Me.作業別類.Location = New System.Drawing.Point(84, 6)
        Me.作業別類.Name = "作業別類"
        Me.作業別類.Size = New System.Drawing.Size(121, 20)
        Me.作業別類.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(292, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "目前作業："
        '
        '查詢
        '
        Me.查詢.Location = New System.Drawing.Point(211, 4)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(75, 23)
        Me.查詢.TabIndex = 3
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(374, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "作業類別"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeColumns = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(2, 65)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(203, 308)
        Me.DGV1.TabIndex = 5
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeColumns = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(211, 65)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(221, 308)
        Me.DGV2.TabIndex = 6
        '
        '存入條碼
        '
        Me.存入條碼.Location = New System.Drawing.Point(797, 4)
        Me.存入條碼.Name = "存入條碼"
        Me.存入條碼.Size = New System.Drawing.Size(75, 23)
        Me.存入條碼.TabIndex = 7
        Me.存入條碼.Text = "存入條碼"
        Me.存入條碼.UseVisualStyleBackColor = True
        '
        'ExcelDGV
        '
        Me.ExcelDGV.AllowUserToAddRows = False
        Me.ExcelDGV.AllowUserToDeleteRows = False
        Me.ExcelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExcelDGV.Location = New System.Drawing.Point(838, 23)
        Me.ExcelDGV.Name = "ExcelDGV"
        Me.ExcelDGV.ReadOnly = True
        Me.ExcelDGV.RowHeadersWidth = 25
        Me.ExcelDGV.RowTemplate.Height = 24
        Me.ExcelDGV.Size = New System.Drawing.Size(43, 23)
        Me.ExcelDGV.TabIndex = 8
        Me.ExcelDGV.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(81, 376)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "筆數"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(292, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "筆數"
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.AllowUserToResizeColumns = False
        Me.DGV3.AllowUserToResizeRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(438, 65)
        Me.DGV3.MultiSelect = False
        Me.DGV3.Name = "DGV3"
        Me.DGV3.RowHeadersWidth = 25
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(443, 308)
        Me.DGV3.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(516, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "筆數"
        '
        '查區別明細
        '
        Me.查區別明細.ForeColor = System.Drawing.SystemColors.ControlText
        Me.查區別明細.Location = New System.Drawing.Point(438, 374)
        Me.查區別明細.Name = "查區別明細"
        Me.查區別明細.Size = New System.Drawing.Size(75, 23)
        Me.查區別明細.TabIndex = 13
        Me.查區別明細.Text = "查區別明細"
        Me.查區別明細.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(825, 382)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 16)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "重覆"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(825, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "未入庫"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(825, 414)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "出庫"
        '
        '存草稿單號
        '
        Me.存草稿單號.ForeColor = System.Drawing.SystemColors.ControlText
        Me.存草稿單號.Location = New System.Drawing.Point(211, 374)
        Me.存草稿單號.Name = "存草稿單號"
        Me.存草稿單號.Size = New System.Drawing.Size(75, 23)
        Me.存草稿單號.TabIndex = 17
        Me.存草稿單號.Text = "存草稿單號"
        Me.存草稿單號.UseVisualStyleBackColor = True
        '
        '區別
        '
        Me.區別.AutoSize = True
        Me.區別.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.區別.Location = New System.Drawing.Point(258, 41)
        Me.區別.Name = "區別"
        Me.區別.Size = New System.Drawing.Size(72, 16)
        Me.區別.TabIndex = 19
        Me.區別.Text = "作業區別"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(208, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "區別："
        '
        '草稿
        '
        Me.草稿.AutoSize = True
        Me.草稿.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.草稿.Location = New System.Drawing.Point(49, 41)
        Me.草稿.Name = "草稿"
        Me.草稿.Size = New System.Drawing.Size(72, 16)
        Me.草稿.TabIndex = 21
        Me.草稿.Text = "作業草稿"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "草稿："
        '
        '查異常條碼
        '
        Me.查異常條碼.Location = New System.Drawing.Point(682, 374)
        Me.查異常條碼.Name = "查異常條碼"
        Me.查異常條碼.Size = New System.Drawing.Size(75, 23)
        Me.查異常條碼.TabIndex = 22
        Me.查異常條碼.Text = "查異常條碼"
        Me.查異常條碼.UseVisualStyleBackColor = True
        '
        'DGV4
        '
        Me.DGV4.AllowUserToAddRows = False
        Me.DGV4.AllowUserToDeleteRows = False
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV4.Location = New System.Drawing.Point(438, 65)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.ReadOnly = True
        Me.DGV4.RowHeadersWidth = 25
        Me.DGV4.RowTemplate.Height = 24
        Me.DGV4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV4.Size = New System.Drawing.Size(443, 308)
        Me.DGV4.TabIndex = 23
        Me.DGV4.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"重覆", "出庫", "全部"})
        Me.ComboBox2.Location = New System.Drawing.Point(623, 376)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(53, 20)
        Me.ComboBox2.TabIndex = 24
        '
        'DGV5
        '
        Me.DGV5.AllowUserToAddRows = False
        Me.DGV5.AllowUserToDeleteRows = False
        Me.DGV5.AllowUserToResizeColumns = False
        Me.DGV5.AllowUserToResizeRows = False
        Me.DGV5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV5.Location = New System.Drawing.Point(3, 433)
        Me.DGV5.Name = "DGV5"
        Me.DGV5.ReadOnly = True
        Me.DGV5.RowHeadersWidth = 25
        Me.DGV5.RowTemplate.Height = 24
        Me.DGV5.Size = New System.Drawing.Size(510, 187)
        Me.DGV5.TabIndex = 25
        '
        '草稿比對
        '
        Me.草稿比對.ForeColor = System.Drawing.SystemColors.ControlText
        Me.草稿比對.Location = New System.Drawing.Point(0, 374)
        Me.草稿比對.Name = "草稿比對"
        Me.草稿比對.Size = New System.Drawing.Size(75, 23)
        Me.草稿比對.TabIndex = 26
        Me.草稿比對.Text = "草稿比對"
        Me.草稿比對.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(763, 382)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "重　覆："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(763, 398)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 28
        Me.Label15.Text = "未入庫："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(763, 414)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "出　庫："
        '
        'DGV6
        '
        Me.DGV6.AllowUserToAddRows = False
        Me.DGV6.AllowUserToDeleteRows = False
        Me.DGV6.AllowUserToResizeColumns = False
        Me.DGV6.AllowUserToResizeRows = False
        Me.DGV6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV6.Location = New System.Drawing.Point(519, 433)
        Me.DGV6.Name = "DGV6"
        Me.DGV6.ReadOnly = True
        Me.DGV6.RowHeadersWidth = 25
        Me.DGV6.RowTemplate.Height = 24
        Me.DGV6.Size = New System.Drawing.Size(362, 187)
        Me.DGV6.TabIndex = 30
        Me.DGV6.Visible = False
        '
        '發貨作業
        '
        Me.發貨作業.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.發貨作業.ForeColor = System.Drawing.Color.Red
        Me.發貨作業.Location = New System.Drawing.Point(519, 550)
        Me.發貨作業.Name = "發貨作業"
        Me.發貨作業.Size = New System.Drawing.Size(70, 70)
        Me.發貨作業.TabIndex = 31
        Me.發貨作業.Text = "發貨" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作業"
        Me.發貨作業.UseVisualStyleBackColor = True
        Me.發貨作業.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(581, 414)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "異常"
        Me.Label17.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(519, 414)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 16)
        Me.Label18.TabIndex = 33
        Me.Label18.Text = "異常數："
        Me.Label18.Visible = False
        '
        'DGV7
        '
        Me.DGV7.AllowUserToAddRows = False
        Me.DGV7.AllowUserToDeleteRows = False
        Me.DGV7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV7.Location = New System.Drawing.Point(438, 4)
        Me.DGV7.Name = "DGV7"
        Me.DGV7.ReadOnly = True
        Me.DGV7.RowHeadersWidth = 25
        Me.DGV7.RowTemplate.Height = 24
        Me.DGV7.Size = New System.Drawing.Size(206, 76)
        Me.DGV7.TabIndex = 34
        Me.DGV7.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(130, 374)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        '刪除區別
        '
        Me.刪除區別.Location = New System.Drawing.Point(357, 38)
        Me.刪除區別.Name = "刪除區別"
        Me.刪除區別.Size = New System.Drawing.Size(75, 23)
        Me.刪除區別.TabIndex = 36
        Me.刪除區別.Text = "刪除區別"
        Me.刪除區別.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(690, 414)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 16)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "差異數"
        Me.Label19.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(628, 414)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "差異數："
        Me.Label20.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.修改區別)
        Me.Panel1.Controls.Add(Me.刪除條碼)
        Me.Panel1.Location = New System.Drawing.Point(623, 443)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(258, 177)
        Me.Panel1.TabIndex = 39
        Me.Panel1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.TextBox1.Location = New System.Drawing.Point(140, 51)
        Me.TextBox1.MaxLength = 3
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 42
        '
        '修改區別
        '
        Me.修改區別.Location = New System.Drawing.Point(59, 51)
        Me.修改區別.Name = "修改區別"
        Me.修改區別.Size = New System.Drawing.Size(75, 23)
        Me.修改區別.TabIndex = 41
        Me.修改區別.Text = "修改區別"
        Me.修改區別.UseVisualStyleBackColor = True
        '
        '刪除條碼
        '
        Me.刪除條碼.Location = New System.Drawing.Point(59, 3)
        Me.刪除條碼.Name = "刪除條碼"
        Me.刪除條碼.Size = New System.Drawing.Size(75, 23)
        Me.刪除條碼.TabIndex = 40
        Me.刪除條碼.Text = "刪除條碼"
        Me.刪除條碼.UseVisualStyleBackColor = True
        '
        '未入庫
        '
        Me.未入庫.Location = New System.Drawing.Point(635, 38)
        Me.未入庫.Name = "未入庫"
        Me.未入庫.Size = New System.Drawing.Size(75, 23)
        Me.未入庫.TabIndex = 40
        Me.未入庫.Text = "未入庫清單"
        Me.未入庫.UseVisualStyleBackColor = True
        Me.未入庫.Visible = False
        '
        '匯出Excel
        '
        Me.匯出Excel.Location = New System.Drawing.Point(716, 39)
        Me.匯出Excel.Name = "匯出Excel"
        Me.匯出Excel.Size = New System.Drawing.Size(75, 23)
        Me.匯出Excel.TabIndex = 130
        Me.匯出Excel.Text = "匯出Excel"
        Me.匯出Excel.UseVisualStyleBackColor = True
        '
        '清除單號
        '
        Me.清除單號.ForeColor = System.Drawing.SystemColors.ControlText
        Me.清除單號.Location = New System.Drawing.Point(357, 374)
        Me.清除單號.Name = "清除單號"
        Me.清除單號.Size = New System.Drawing.Size(75, 23)
        Me.清除單號.TabIndex = 131
        Me.清除單號.Text = "清除單號"
        Me.清除單號.UseVisualStyleBackColor = True
        '
        '查條碼
        '
        Me.查條碼.Location = New System.Drawing.Point(516, 39)
        Me.查條碼.Name = "查條碼"
        Me.查條碼.Size = New System.Drawing.Size(75, 23)
        Me.查條碼.TabIndex = 132
        Me.查條碼.Text = "查條碼"
        Me.查條碼.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.加工Rb)
        Me.Panel2.Controls.Add(Me.電宰Rb)
        Me.Panel2.Location = New System.Drawing.Point(650, -3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(145, 36)
        Me.Panel2.TabIndex = 133
        Me.Panel2.Visible = False
        '
        '加工Rb
        '
        Me.加工Rb.AutoSize = True
        Me.加工Rb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.加工Rb.Location = New System.Drawing.Point(76, 7)
        Me.加工Rb.Name = "加工Rb"
        Me.加工Rb.Size = New System.Drawing.Size(58, 20)
        Me.加工Rb.TabIndex = 1
        Me.加工Rb.Text = "加工"
        Me.加工Rb.UseVisualStyleBackColor = True
        '
        '電宰Rb
        '
        Me.電宰Rb.AutoSize = True
        Me.電宰Rb.Checked = True
        Me.電宰Rb.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.電宰Rb.Location = New System.Drawing.Point(12, 7)
        Me.電宰Rb.Name = "電宰Rb"
        Me.電宰Rb.Size = New System.Drawing.Size(58, 20)
        Me.電宰Rb.TabIndex = 0
        Me.電宰Rb.TabStop = True
        Me.電宰Rb.Text = "電宰"
        Me.電宰Rb.UseVisualStyleBackColor = True
        '
        '作業別
        '
        Me.作業別.AutoSize = True
        Me.作業別.Font = New System.Drawing.Font("新細明體", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.作業別.ForeColor = System.Drawing.Color.Red
        Me.作業別.Location = New System.Drawing.Point(174, 31)
        Me.作業別.Name = "作業別"
        Me.作業別.Size = New System.Drawing.Size(96, 27)
        Me.作業別.TabIndex = 134
        Me.作業別.Text = "作業別"
        '
        '稿號
        '
        Me.稿號.AutoSize = True
        Me.稿號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.稿號.Location = New System.Drawing.Point(146, 414)
        Me.稿號.Name = "稿號"
        Me.稿號.Size = New System.Drawing.Size(40, 16)
        Me.稿號.TabIndex = 136
        Me.稿號.Text = "稿號"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 414)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 16)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "目前比對草稿號碼："
        '
        '出庫作業
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 622)
        Me.Controls.Add(Me.稿號)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.區別)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.作業別)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.查條碼)
        Me.Controls.Add(Me.清除單號)
        Me.Controls.Add(Me.匯出Excel)
        Me.Controls.Add(Me.未入庫)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.刪除區別)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DGV7)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.發貨作業)
        Me.Controls.Add(Me.DGV6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.草稿比對)
        Me.Controls.Add(Me.DGV5)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.查異常條碼)
        Me.Controls.Add(Me.草稿)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.存草稿單號)
        Me.Controls.Add(Me.查區別明細)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.存入條碼)
        Me.Controls.Add(Me.ExcelDGV)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.作業別類)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV4)
        Me.Name = "出庫作業"
        Me.Text = "出庫作業"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExcelDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 作業別類 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents 存入條碼 As System.Windows.Forms.Button
    Friend WithEvents ExcelDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 查區別明細 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents 存草稿單號 As System.Windows.Forms.Button
    Friend WithEvents 區別 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents 草稿 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents 查異常條碼 As System.Windows.Forms.Button
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents DGV5 As System.Windows.Forms.DataGridView
    Friend WithEvents 草稿比對 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DGV6 As System.Windows.Forms.DataGridView
    Friend WithEvents 發貨作業 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DGV7 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents 刪除區別 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents 刪除條碼 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents 修改區別 As System.Windows.Forms.Button
    Friend WithEvents 未入庫 As System.Windows.Forms.Button
    Friend WithEvents 匯出Excel As System.Windows.Forms.Button
    Friend WithEvents 清除單號 As System.Windows.Forms.Button
    Friend WithEvents 查條碼 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents 加工Rb As System.Windows.Forms.RadioButton
    Friend WithEvents 電宰Rb As System.Windows.Forms.RadioButton
    Friend WithEvents 作業別 As System.Windows.Forms.Label
    Friend WithEvents 稿號 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
