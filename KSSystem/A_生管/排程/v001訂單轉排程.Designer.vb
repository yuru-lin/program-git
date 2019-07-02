<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001訂單轉排程
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.CB客戶 = New System.Windows.Forms.ComboBox
        Me.客戶查詢 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.明細查詢 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.TB客戶編號 = New System.Windows.Forms.TextBox
        Me.TB客戶名稱 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CB樓層 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CB時段 = New System.Windows.Forms.ComboBox
        Me.TB排程 = New System.Windows.Forms.TextBox
        Me.儲存 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TB人數 = New System.Windows.Forms.TextBox
        Me.L總工時 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TB製單 = New System.Windows.Forms.TextBox
        Me.CB製單 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TB簡稱 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.排程日期 = New System.Windows.Forms.DateTimePicker
        Me.ToExcel = New System.Windows.Forms.Button
        Me.CB訂單 = New System.Windows.Forms.CheckBox
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "日期(起)："
        '
        '日期
        '
        Me.日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(90, 10)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(152, 27)
        Me.日期.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "客　 戶："
        '
        'CB客戶
        '
        Me.CB客戶.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB客戶.FormattingEnabled = True
        Me.CB客戶.Location = New System.Drawing.Point(90, 85)
        Me.CB客戶.Name = "CB客戶"
        Me.CB客戶.Size = New System.Drawing.Size(152, 24)
        Me.CB客戶.TabIndex = 3
        '
        '客戶查詢
        '
        Me.客戶查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.客戶查詢.Location = New System.Drawing.Point(249, 12)
        Me.客戶查詢.Name = "客戶查詢"
        Me.客戶查詢.Size = New System.Drawing.Size(66, 56)
        Me.客戶查詢.TabIndex = 5
        Me.客戶查詢.Text = "客戶查詢"
        Me.客戶查詢.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(320, 43)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(804, 533)
        Me.DGV2.TabIndex = 6
        '
        '明細查詢
        '
        Me.明細查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.明細查詢.Location = New System.Drawing.Point(211, 594)
        Me.明細查詢.Name = "明細查詢"
        Me.明細查詢.Size = New System.Drawing.Size(103, 54)
        Me.明細查詢.TabIndex = 7
        Me.明細查詢.Text = "明細查詢"
        Me.明細查詢.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV1.Location = New System.Drawing.Point(15, 123)
        Me.DGV1.Name = "DGV1"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(299, 458)
        Me.DGV1.TabIndex = 15
        '
        'TB客戶編號
        '
        Me.TB客戶編號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB客戶編號.Location = New System.Drawing.Point(408, 10)
        Me.TB客戶編號.Name = "TB客戶編號"
        Me.TB客戶編號.Size = New System.Drawing.Size(145, 27)
        Me.TB客戶編號.TabIndex = 16
        '
        'TB客戶名稱
        '
        Me.TB客戶名稱.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB客戶名稱.Location = New System.Drawing.Point(646, 10)
        Me.TB客戶名稱.Name = "TB客戶名稱"
        Me.TB客戶名稱.Size = New System.Drawing.Size(239, 27)
        Me.TB客戶名稱.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(324, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "客戶編號："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(562, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "客戶名稱："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(353, 631)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "樓層："
        '
        'CB樓層
        '
        Me.CB樓層.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB樓層.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB樓層.FormattingEnabled = True
        Me.CB樓層.Items.AddRange(New Object() {"一樓", "二樓", "三樓"})
        Me.CB樓層.Location = New System.Drawing.Point(402, 628)
        Me.CB樓層.Name = "CB樓層"
        Me.CB樓層.Size = New System.Drawing.Size(93, 24)
        Me.CB樓層.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(514, 633)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "時段："
        '
        'CB時段
        '
        Me.CB時段.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB時段.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB時段.FormattingEnabled = True
        Me.CB時段.Location = New System.Drawing.Point(563, 628)
        Me.CB時段.Name = "CB時段"
        Me.CB時段.Size = New System.Drawing.Size(125, 24)
        Me.CB時段.TabIndex = 23
        '
        'TB排程
        '
        Me.TB排程.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TB排程.BackColor = System.Drawing.SystemColors.Window
        Me.TB排程.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB排程.Location = New System.Drawing.Point(756, 628)
        Me.TB排程.Name = "TB排程"
        Me.TB排程.ReadOnly = True
        Me.TB排程.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TB排程.Size = New System.Drawing.Size(126, 25)
        Me.TB排程.TabIndex = 116
        Me.TB排程.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '儲存
        '
        Me.儲存.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.儲存.Location = New System.Drawing.Point(906, 628)
        Me.儲存.Name = "儲存"
        Me.儲存.Size = New System.Drawing.Size(98, 55)
        Me.儲存.TabIndex = 117
        Me.儲存.Text = "儲存"
        Me.儲存.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(706, 633)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "排程："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(733, 593)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "人數："
        '
        'TB人數
        '
        Me.TB人數.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB人數.Location = New System.Drawing.Point(789, 588)
        Me.TB人數.Name = "TB人數"
        Me.TB人數.Size = New System.Drawing.Size(93, 25)
        Me.TB人數.TabIndex = 120
        '
        'L總工時
        '
        Me.L總工時.AutoSize = True
        Me.L總工時.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L總工時.Location = New System.Drawing.Point(1026, 594)
        Me.L總工時.Name = "L總工時"
        Me.L總工時.Size = New System.Drawing.Size(18, 19)
        Me.L總工時.TabIndex = 121
        Me.L總工時.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(353, 667)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "製單："
        '
        'TB製單
        '
        Me.TB製單.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB製單.Location = New System.Drawing.Point(402, 663)
        Me.TB製單.Name = "TB製單"
        Me.TB製單.Size = New System.Drawing.Size(126, 25)
        Me.TB製單.TabIndex = 123
        '
        'CB製單
        '
        Me.CB製單.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB製單.FormattingEnabled = True
        Me.CB製單.Items.AddRange(New Object() {"手Key", "2-1", "2-2", "2-3", "2-4", "2-5", "2-6", "2-7", "2-8", "3-1", "3-2", "3-3", "3-4", "3-5", "5-1", "6-1"})
        Me.CB製單.Location = New System.Drawing.Point(534, 663)
        Me.CB製單.Name = "CB製單"
        Me.CB製單.Size = New System.Drawing.Size(83, 24)
        Me.CB製單.TabIndex = 124
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(944, 594)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 19)
        Me.Label10.TabIndex = 125
        Me.Label10.Text = "總工時："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(895, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "簡稱："
        '
        'TB簡稱
        '
        Me.TB簡稱.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TB簡稱.Location = New System.Drawing.Point(948, 10)
        Me.TB簡稱.Name = "TB簡稱"
        Me.TB簡稱.Size = New System.Drawing.Size(176, 27)
        Me.TB簡稱.TabIndex = 127
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(354, 592)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 128
        Me.Label12.Text = "排程日期："
        '
        '排程日期
        '
        Me.排程日期.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.排程日期.Location = New System.Drawing.Point(436, 588)
        Me.排程日期.Name = "排程日期"
        Me.排程日期.Size = New System.Drawing.Size(152, 25)
        Me.排程日期.TabIndex = 129
        '
        'ToExcel
        '
        Me.ToExcel.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToExcel.Location = New System.Drawing.Point(1026, 628)
        Me.ToExcel.Name = "ToExcel"
        Me.ToExcel.Size = New System.Drawing.Size(98, 55)
        Me.ToExcel.TabIndex = 130
        Me.ToExcel.Text = "Excel"
        Me.ToExcel.UseVisualStyleBackColor = True
        '
        'CB訂單
        '
        Me.CB訂單.AutoSize = True
        Me.CB訂單.Checked = True
        Me.CB訂單.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CB訂單.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CB訂單.Location = New System.Drawing.Point(646, 668)
        Me.CB訂單.Name = "CB訂單"
        Me.CB訂單.Size = New System.Drawing.Size(91, 20)
        Me.CB訂單.TabIndex = 131
        Me.CB訂單.TabStop = False
        Me.CB訂單.Text = "訂單日期"
        Me.CB訂單.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(90, 47)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(152, 27)
        Me.DateTimePicker1.TabIndex = 133
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 16)
        Me.Label13.TabIndex = 132
        Me.Label13.Text = "日期(迄)："
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.RadioButton1.Location = New System.Drawing.Point(90, 594)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(100, 20)
        Me.RadioButton1.TabIndex = 134
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "全部(預設)"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.RadioButton2.Location = New System.Drawing.Point(90, 629)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(58, 20)
        Me.RadioButton2.TabIndex = 134
        Me.RadioButton2.Text = "成件"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.RadioButton3.Location = New System.Drawing.Point(90, 663)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(58, 20)
        Me.RadioButton3.TabIndex = 134
        Me.RadioButton3.Text = "零散"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'v001訂單轉排程
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 698)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.CB訂單)
        Me.Controls.Add(Me.ToExcel)
        Me.Controls.Add(Me.排程日期)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TB簡稱)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.L總工時)
        Me.Controls.Add(Me.CB製單)
        Me.Controls.Add(Me.TB製單)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TB人數)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.儲存)
        Me.Controls.Add(Me.TB排程)
        Me.Controls.Add(Me.CB時段)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CB樓層)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TB客戶名稱)
        Me.Controls.Add(Me.TB客戶編號)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.明細查詢)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.客戶查詢)
        Me.Controls.Add(Me.CB客戶)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.日期)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "v001訂單轉排程"
        Me.Text = "訂單轉排程"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CB客戶 As System.Windows.Forms.ComboBox
    Friend WithEvents 客戶查詢 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents 明細查詢 As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents TB客戶編號 As System.Windows.Forms.TextBox
    Friend WithEvents TB客戶名稱 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CB樓層 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CB時段 As System.Windows.Forms.ComboBox
    Friend WithEvents TB排程 As System.Windows.Forms.TextBox
    Friend WithEvents 儲存 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TB人數 As System.Windows.Forms.TextBox
    Friend WithEvents L總工時 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TB製單 As System.Windows.Forms.TextBox
    Friend WithEvents CB製單 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TB簡稱 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents 排程日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToExcel As System.Windows.Forms.Button
    Friend WithEvents CB訂單 As System.Windows.Forms.CheckBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
End Class
