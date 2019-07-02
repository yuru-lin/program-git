<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 調庫作業V101
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
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.D4區別 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D4調至庫位 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.存入條碼 = New System.Windows.Forms.Button
        Me.刪除區別 = New System.Windows.Forms.Button
        Me.查詢 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.查區別明細 = New System.Windows.Forms.Button
        Me.條碼數量 = New System.Windows.Forms.Label
        Me.出庫 = New System.Windows.Forms.Label
        Me.未入庫 = New System.Windows.Forms.Label
        Me.重覆 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.ExcelDGV = New System.Windows.Forms.DataGridView
        Me.目前區別 = New System.Windows.Forms.TextBox
        Me.調至庫位 = New System.Windows.Forms.TextBox
        Me.更新資料 = New System.Windows.Forms.Button
        Me.增加調整區別 = New System.Windows.Forms.Button
        Me.清空調整區別 = New System.Windows.Forms.Button
        Me.調庫 = New System.Windows.Forms.Button
        Me.查詢調整區別 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.庫位鎖定 = New System.Windows.Forms.CheckBox
        Me.DGV5 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.調庫2 = New System.Windows.Forms.Button
        Me.匯出Excel = New System.Windows.Forms.Button
        Me.查條碼 = New System.Windows.Forms.Button
        Me.刪除條碼 = New System.Windows.Forms.Button
        Me.查詢異常區別 = New System.Windows.Forms.Button
        Me.DGV4 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExcelDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.AllowUserToResizeColumns = False
        Me.DGV3.AllowUserToResizeRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(234, 65)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowHeadersWidth = 25
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(698, 308)
        Me.DGV3.TabIndex = 13
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeColumns = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.D4區別, Me.D4調至庫位})
        Me.DGV1.Location = New System.Drawing.Point(315, 379)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(193, 238)
        Me.DGV1.TabIndex = 14
        '
        'D4區別
        '
        Me.D4區別.DataPropertyName = "區別"
        Me.D4區別.HeaderText = "區別"
        Me.D4區別.Name = "D4區別"
        Me.D4區別.ReadOnly = True
        Me.D4區別.Width = 60
        '
        'D4調至庫位
        '
        Me.D4調至庫位.DataPropertyName = "調至庫位"
        Me.D4調至庫位.HeaderText = "調至庫位"
        Me.D4調至庫位.Name = "D4調至庫位"
        Me.D4調至庫位.ReadOnly = True
        '
        '存入條碼
        '
        Me.存入條碼.Location = New System.Drawing.Point(854, 4)
        Me.存入條碼.Name = "存入條碼"
        Me.存入條碼.Size = New System.Drawing.Size(75, 23)
        Me.存入條碼.TabIndex = 15
        Me.存入條碼.Text = "存入條碼"
        Me.存入條碼.UseVisualStyleBackColor = True
        '
        '刪除區別
        '
        Me.刪除區別.Location = New System.Drawing.Point(465, 36)
        Me.刪除區別.Name = "刪除區別"
        Me.刪除區別.Size = New System.Drawing.Size(75, 23)
        Me.刪除區別.TabIndex = 38
        Me.刪除區別.Text = "刪除區別"
        Me.刪除區別.UseVisualStyleBackColor = True
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(2, 4)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(75, 55)
        Me.查詢.TabIndex = 37
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(27, 384)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "區別："
        '
        '查區別明細
        '
        Me.查區別明細.ForeColor = System.Drawing.SystemColors.ControlText
        Me.查區別明細.Location = New System.Drawing.Point(153, 36)
        Me.查區別明細.Name = "查區別明細"
        Me.查區別明細.Size = New System.Drawing.Size(75, 23)
        Me.查區別明細.TabIndex = 41
        Me.查區別明細.Text = "查區別明細"
        Me.查區別明細.UseVisualStyleBackColor = True
        '
        '條碼數量
        '
        Me.條碼數量.AutoSize = True
        Me.條碼數量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.條碼數量.Location = New System.Drawing.Point(235, 39)
        Me.條碼數量.Name = "條碼數量"
        Me.條碼數量.Size = New System.Drawing.Size(72, 16)
        Me.條碼數量.TabIndex = 42
        Me.條碼數量.Text = "條碼數量"
        '
        '出庫
        '
        Me.出庫.AutoSize = True
        Me.出庫.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.出庫.Location = New System.Drawing.Point(391, 39)
        Me.出庫.Name = "出庫"
        Me.出庫.Size = New System.Drawing.Size(40, 16)
        Me.出庫.TabIndex = 45
        Me.出庫.Text = "出庫"
        '
        '未入庫
        '
        Me.未入庫.AutoSize = True
        Me.未入庫.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.未入庫.Location = New System.Drawing.Point(391, 23)
        Me.未入庫.Name = "未入庫"
        Me.未入庫.Size = New System.Drawing.Size(56, 16)
        Me.未入庫.TabIndex = 44
        Me.未入庫.Text = "未入庫"
        '
        '重覆
        '
        Me.重覆.AutoSize = True
        Me.重覆.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.重覆.Location = New System.Drawing.Point(391, 7)
        Me.重覆.Name = "重覆"
        Me.重覆.Size = New System.Drawing.Size(40, 16)
        Me.重覆.TabIndex = 43
        Me.重覆.Text = "重覆"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(329, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "出　庫："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(329, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "未入庫："
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(329, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 46
        Me.Label14.Text = "重　覆："
        '
        'ExcelDGV
        '
        Me.ExcelDGV.AllowUserToAddRows = False
        Me.ExcelDGV.AllowUserToDeleteRows = False
        Me.ExcelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ExcelDGV.Location = New System.Drawing.Point(6, 42)
        Me.ExcelDGV.Name = "ExcelDGV"
        Me.ExcelDGV.ReadOnly = True
        Me.ExcelDGV.RowHeadersWidth = 25
        Me.ExcelDGV.RowTemplate.Height = 24
        Me.ExcelDGV.Size = New System.Drawing.Size(247, 92)
        Me.ExcelDGV.TabIndex = 49
        '
        '目前區別
        '
        Me.目前區別.BackColor = System.Drawing.SystemColors.Window
        Me.目前區別.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.目前區別.Location = New System.Drawing.Point(78, 381)
        Me.目前區別.Name = "目前區別"
        Me.目前區別.ReadOnly = True
        Me.目前區別.Size = New System.Drawing.Size(100, 27)
        Me.目前區別.TabIndex = 51
        '
        '調至庫位
        '
        Me.調至庫位.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.調至庫位.Location = New System.Drawing.Point(78, 413)
        Me.調至庫位.MaxLength = 10
        Me.調至庫位.Name = "調至庫位"
        Me.調至庫位.Size = New System.Drawing.Size(100, 27)
        Me.調至庫位.TabIndex = 52
        '
        '更新資料
        '
        Me.更新資料.Enabled = False
        Me.更新資料.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.更新資料.Location = New System.Drawing.Point(78, 446)
        Me.更新資料.Name = "更新資料"
        Me.更新資料.Size = New System.Drawing.Size(100, 46)
        Me.更新資料.TabIndex = 53
        Me.更新資料.Text = "更新資料"
        Me.更新資料.UseVisualStyleBackColor = True
        '
        '增加調整區別
        '
        Me.增加調整區別.Location = New System.Drawing.Point(234, 379)
        Me.增加調整區別.Name = "增加調整區別"
        Me.增加調整區別.Size = New System.Drawing.Size(75, 46)
        Me.增加調整區別.TabIndex = 54
        Me.增加調整區別.Text = "增加調整" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "區別"
        Me.增加調整區別.UseVisualStyleBackColor = True
        '
        '清空調整區別
        '
        Me.清空調整區別.Location = New System.Drawing.Point(234, 571)
        Me.清空調整區別.Name = "清空調整區別"
        Me.清空調整區別.Size = New System.Drawing.Size(75, 46)
        Me.清空調整區別.TabIndex = 55
        Me.清空調整區別.Text = "清空調整" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "區別"
        Me.清空調整區別.UseVisualStyleBackColor = True
        '
        '調庫
        '
        Me.調庫.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.調庫.ForeColor = System.Drawing.Color.Red
        Me.調庫.Location = New System.Drawing.Point(234, 483)
        Me.調庫.Name = "調庫"
        Me.調庫.Size = New System.Drawing.Size(75, 73)
        Me.調庫.TabIndex = 56
        Me.調庫.Text = "調庫" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作業"
        Me.調庫.UseVisualStyleBackColor = True
        Me.調庫.Visible = False
        '
        '查詢調整區別
        '
        Me.查詢調整區別.Location = New System.Drawing.Point(234, 431)
        Me.查詢調整區別.Name = "查詢調整區別"
        Me.查詢調整區別.Size = New System.Drawing.Size(75, 46)
        Me.查詢調整區別.TabIndex = 57
        Me.查詢調整區別.Text = "查詢調整" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "區別"
        Me.查詢調整區別.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(74, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 48)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "G"
        '
        '庫位鎖定
        '
        Me.庫位鎖定.AutoSize = True
        Me.庫位鎖定.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.庫位鎖定.Location = New System.Drawing.Point(11, 416)
        Me.庫位鎖定.Name = "庫位鎖定"
        Me.庫位鎖定.Size = New System.Drawing.Size(75, 20)
        Me.庫位鎖定.TabIndex = 59
        Me.庫位鎖定.Text = "庫位："
        Me.庫位鎖定.UseVisualStyleBackColor = True
        '
        'DGV5
        '
        Me.DGV5.AllowUserToAddRows = False
        Me.DGV5.AllowUserToDeleteRows = False
        Me.DGV5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV5.Location = New System.Drawing.Point(514, 379)
        Me.DGV5.Name = "DGV5"
        Me.DGV5.ReadOnly = True
        Me.DGV5.RowHeadersVisible = False
        Me.DGV5.RowTemplate.Height = 24
        Me.DGV5.Size = New System.Drawing.Size(418, 238)
        Me.DGV5.TabIndex = 126
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeColumns = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(2, 65)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(226, 308)
        Me.DGV2.TabIndex = 127
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DocDate)
        Me.Panel1.Controls.Add(Me.調庫2)
        Me.Panel1.Location = New System.Drawing.Point(2, 497)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(183, 120)
        Me.Panel1.TabIndex = 128
        Me.Panel1.Visible = False
        '
        'DocDate
        '
        Me.DocDate.CalendarFont = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDate.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDate.Location = New System.Drawing.Point(3, 8)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(173, 30)
        Me.DocDate.TabIndex = 130
        '
        '調庫2
        '
        Me.調庫2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.調庫2.ForeColor = System.Drawing.Color.Red
        Me.調庫2.Location = New System.Drawing.Point(3, 44)
        Me.調庫2.Name = "調庫2"
        Me.調庫2.Size = New System.Drawing.Size(75, 73)
        Me.調庫2.TabIndex = 129
        Me.調庫2.Text = "調庫" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作業"
        Me.調庫2.UseVisualStyleBackColor = True
        Me.調庫2.Visible = False
        '
        '匯出Excel
        '
        Me.匯出Excel.Location = New System.Drawing.Point(854, 36)
        Me.匯出Excel.Name = "匯出Excel"
        Me.匯出Excel.Size = New System.Drawing.Size(75, 23)
        Me.匯出Excel.TabIndex = 129
        Me.匯出Excel.Text = "匯出Excel"
        Me.匯出Excel.UseVisualStyleBackColor = True
        '
        '查條碼
        '
        Me.查條碼.Location = New System.Drawing.Point(153, 4)
        Me.查條碼.Name = "查條碼"
        Me.查條碼.Size = New System.Drawing.Size(75, 23)
        Me.查條碼.TabIndex = 133
        Me.查條碼.Text = "查條碼"
        Me.查條碼.UseVisualStyleBackColor = True
        '
        '刪除條碼
        '
        Me.刪除條碼.Location = New System.Drawing.Point(559, 36)
        Me.刪除條碼.Name = "刪除條碼"
        Me.刪除條碼.Size = New System.Drawing.Size(75, 23)
        Me.刪除條碼.TabIndex = 134
        Me.刪除條碼.Text = "刪除條碼"
        Me.刪除條碼.UseVisualStyleBackColor = True
        '
        '查詢異常區別
        '
        Me.查詢異常區別.Location = New System.Drawing.Point(234, 484)
        Me.查詢異常區別.Name = "查詢異常區別"
        Me.查詢異常區別.Size = New System.Drawing.Size(75, 46)
        Me.查詢異常區別.TabIndex = 135
        Me.查詢異常區別.Text = "查詢異常" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "區別"
        Me.查詢異常區別.UseVisualStyleBackColor = True
        Me.查詢異常區別.Visible = False
        '
        'DGV4
        '
        Me.DGV4.AllowUserToAddRows = False
        Me.DGV4.AllowUserToDeleteRows = False
        Me.DGV4.AllowUserToResizeColumns = False
        Me.DGV4.AllowUserToResizeRows = False
        Me.DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV4.Location = New System.Drawing.Point(6, 156)
        Me.DGV4.Name = "DGV4"
        Me.DGV4.ReadOnly = True
        Me.DGV4.RowHeadersWidth = 25
        Me.DGV4.RowTemplate.Height = 24
        Me.DGV4.Size = New System.Drawing.Size(247, 92)
        Me.DGV4.TabIndex = 136
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(137, 546)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(137, 562)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 16)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(137, 579)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 16)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(137, 595)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 16)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "0.00"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ExcelDGV)
        Me.GroupBox1.Controls.Add(Me.DGV4)
        Me.GroupBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(570, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 258)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 143
        Me.Label7.Text = "載入存編"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "載入條碼"
        '
        '調庫作業V101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 622)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.查詢調整區別)
        Me.Controls.Add(Me.查詢異常區別)
        Me.Controls.Add(Me.刪除條碼)
        Me.Controls.Add(Me.查條碼)
        Me.Controls.Add(Me.匯出Excel)
        Me.Controls.Add(Me.存入條碼)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV5)
        Me.Controls.Add(Me.調至庫位)
        Me.Controls.Add(Me.庫位鎖定)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.調庫)
        Me.Controls.Add(Me.清空調整區別)
        Me.Controls.Add(Me.增加調整區別)
        Me.Controls.Add(Me.更新資料)
        Me.Controls.Add(Me.目前區別)
        Me.Controls.Add(Me.出庫)
        Me.Controls.Add(Me.未入庫)
        Me.Controls.Add(Me.重覆)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.條碼數量)
        Me.Controls.Add(Me.查區別明細)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.刪除區別)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.DGV3)
        Me.Name = "調庫作業V101"
        Me.Text = "調庫作業"
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExcelDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents 存入條碼 As System.Windows.Forms.Button
    Friend WithEvents 刪除區別 As System.Windows.Forms.Button
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents 查區別明細 As System.Windows.Forms.Button
    Friend WithEvents 條碼數量 As System.Windows.Forms.Label
    Friend WithEvents 出庫 As System.Windows.Forms.Label
    Friend WithEvents 未入庫 As System.Windows.Forms.Label
    Friend WithEvents 重覆 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ExcelDGV As System.Windows.Forms.DataGridView
    Friend WithEvents 目前區別 As System.Windows.Forms.TextBox
    Friend WithEvents 調至庫位 As System.Windows.Forms.TextBox
    Friend WithEvents 更新資料 As System.Windows.Forms.Button
    Friend WithEvents 增加調整區別 As System.Windows.Forms.Button
    Friend WithEvents 清空調整區別 As System.Windows.Forms.Button
    Friend WithEvents 調庫 As System.Windows.Forms.Button
    Friend WithEvents 查詢調整區別 As System.Windows.Forms.Button
    Friend WithEvents D4區別 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D4調至庫位 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 庫位鎖定 As System.Windows.Forms.CheckBox
    Friend WithEvents DGV5 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents 調庫2 As System.Windows.Forms.Button
    Friend WithEvents 匯出Excel As System.Windows.Forms.Button
    Friend WithEvents 查條碼 As System.Windows.Forms.Button
    Friend WithEvents 刪除條碼 As System.Windows.Forms.Button
    Friend WithEvents 查詢異常區別 As System.Windows.Forms.Button
    Friend WithEvents DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
