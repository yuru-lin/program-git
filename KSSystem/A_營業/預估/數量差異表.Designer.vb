<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 數量差異表
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.更新 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.修改 = New System.Windows.Forms.Button
        Me.ItemName = New System.Windows.Forms.TextBox
        Me.查詢 = New System.Windows.Forms.Button
        Me.新增 = New System.Windows.Forms.Button
        Me.Unit = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Month = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Year = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.FromDate5 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.FromDate4 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.FromDate3 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.FromDate2 = New System.Windows.Forms.TextBox
        Me.Week1 = New System.Windows.Forms.Label
        Me.FromDate1 = New System.Windows.Forms.TextBox
        Me.Week2 = New System.Windows.Forms.Label
        Me.Week3 = New System.Windows.Forms.Label
        Me.Week4 = New System.Windows.Forms.Label
        Me.Comments5 = New System.Windows.Forms.TextBox
        Me.Week5 = New System.Windows.Forms.Label
        Me.Comments4 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Comments3 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Comments2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Comments1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.RealQty5 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.RealQty4 = New System.Windows.Forms.TextBox
        Me.ToDate1 = New System.Windows.Forms.TextBox
        Me.RealQty3 = New System.Windows.Forms.TextBox
        Me.ToDate2 = New System.Windows.Forms.TextBox
        Me.RealQty2 = New System.Windows.Forms.TextBox
        Me.ToDate3 = New System.Windows.Forms.TextBox
        Me.RealQty1 = New System.Windows.Forms.TextBox
        Me.ToDate4 = New System.Windows.Forms.TextBox
        Me.ReckonQty5 = New System.Windows.Forms.TextBox
        Me.ToDate5 = New System.Windows.Forms.TextBox
        Me.ReckonQty4 = New System.Windows.Forms.TextBox
        Me.ReckonQty1 = New System.Windows.Forms.TextBox
        Me.ReckonQty3 = New System.Windows.Forms.TextBox
        Me.ReckonQty2 = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.查詢2 = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Month2 = New System.Windows.Forms.ComboBox
        Me.Year2 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Unit2 = New System.Windows.Forms.ComboBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-1, 2)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(944, 564)
        Me.TabControl1.TabIndex = 56
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.更新)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.修改)
        Me.TabPage1.Controls.Add(Me.ItemName)
        Me.TabPage1.Controls.Add(Me.查詢)
        Me.TabPage1.Controls.Add(Me.新增)
        Me.TabPage1.Controls.Add(Me.Unit)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.DGV1)
        Me.TabPage1.Controls.Add(Me.Month)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Year)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.FromDate5)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.FromDate4)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.FromDate3)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.FromDate2)
        Me.TabPage1.Controls.Add(Me.Week1)
        Me.TabPage1.Controls.Add(Me.FromDate1)
        Me.TabPage1.Controls.Add(Me.Week2)
        Me.TabPage1.Controls.Add(Me.Week3)
        Me.TabPage1.Controls.Add(Me.Week4)
        Me.TabPage1.Controls.Add(Me.Comments5)
        Me.TabPage1.Controls.Add(Me.Week5)
        Me.TabPage1.Controls.Add(Me.Comments4)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Comments3)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Comments2)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Comments1)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.RealQty5)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.RealQty4)
        Me.TabPage1.Controls.Add(Me.ToDate1)
        Me.TabPage1.Controls.Add(Me.RealQty3)
        Me.TabPage1.Controls.Add(Me.ToDate2)
        Me.TabPage1.Controls.Add(Me.RealQty2)
        Me.TabPage1.Controls.Add(Me.ToDate3)
        Me.TabPage1.Controls.Add(Me.RealQty1)
        Me.TabPage1.Controls.Add(Me.ToDate4)
        Me.TabPage1.Controls.Add(Me.ReckonQty5)
        Me.TabPage1.Controls.Add(Me.ToDate5)
        Me.TabPage1.Controls.Add(Me.ReckonQty4)
        Me.TabPage1.Controls.Add(Me.ReckonQty1)
        Me.TabPage1.Controls.Add(Me.ReckonQty3)
        Me.TabPage1.Controls.Add(Me.ReckonQty2)
        Me.TabPage1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(936, 534)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "設定"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "單位"
        '
        '更新
        '
        Me.更新.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.更新.Location = New System.Drawing.Point(850, 389)
        Me.更新.Name = "更新"
        Me.更新.Size = New System.Drawing.Size(73, 40)
        Me.更新.TabIndex = 164
        Me.更新.Text = "更新"
        Me.更新.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(123, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 19)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "品項"
        '
        '修改
        '
        Me.修改.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.修改.Location = New System.Drawing.Point(850, 332)
        Me.修改.Name = "修改"
        Me.修改.Size = New System.Drawing.Size(73, 40)
        Me.修改.TabIndex = 163
        Me.修改.Text = "修改"
        Me.修改.UseVisualStyleBackColor = True
        '
        'ItemName
        '
        Me.ItemName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ItemName.Location = New System.Drawing.Point(83, 37)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(134, 27)
        Me.ItemName.TabIndex = 114
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(850, 217)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(73, 40)
        Me.查詢.TabIndex = 159
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        '新增
        '
        Me.新增.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.新增.Location = New System.Drawing.Point(850, 273)
        Me.新增.Name = "新增"
        Me.新增.Size = New System.Drawing.Size(73, 40)
        Me.新增.TabIndex = 158
        Me.新增.Text = "新增"
        Me.新增.UseVisualStyleBackColor = True
        '
        'Unit
        '
        Me.Unit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Unit.FormattingEnabled = True
        Me.Unit.Items.AddRange(New Object() {"營業", "契養"})
        Me.Unit.Location = New System.Drawing.Point(16, 38)
        Me.Unit.Name = "Unit"
        Me.Unit.Size = New System.Drawing.Size(60, 24)
        Me.Unit.TabIndex = 162
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(235, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 19)
        Me.Label3.TabIndex = 115
        Me.Label3.Text = "年度"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(16, 217)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(816, 295)
        Me.DGV1.TabIndex = 157
        '
        'Month
        '
        Me.Month.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Month.FormattingEnabled = True
        Me.Month.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Month.Location = New System.Drawing.Point(301, 38)
        Me.Month.Name = "Month"
        Me.Month.Size = New System.Drawing.Size(55, 24)
        Me.Month.TabIndex = 161
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(305, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 19)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "月份"
        '
        'Year
        '
        Me.Year.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Year.FormattingEnabled = True
        Me.Year.Items.AddRange(New Object() {"2016"})
        Me.Year.Location = New System.Drawing.Point(224, 38)
        Me.Year.Name = "Year"
        Me.Year.Size = New System.Drawing.Size(71, 24)
        Me.Year.TabIndex = 160
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(358, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 19)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "週別"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(431, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 19)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "期　間"
        '
        'FromDate5
        '
        Me.FromDate5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FromDate5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FromDate5.Location = New System.Drawing.Point(406, 169)
        Me.FromDate5.Name = "FromDate5"
        Me.FromDate5.Size = New System.Drawing.Size(41, 27)
        Me.FromDate5.TabIndex = 136
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(527, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 19)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "預估數量"
        '
        'FromDate4
        '
        Me.FromDate4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FromDate4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FromDate4.Location = New System.Drawing.Point(406, 136)
        Me.FromDate4.Name = "FromDate4"
        Me.FromDate4.Size = New System.Drawing.Size(41, 27)
        Me.FromDate4.TabIndex = 135
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(616, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 19)
        Me.Label8.TabIndex = 121
        Me.Label8.Text = "實際數量"
        '
        'FromDate3
        '
        Me.FromDate3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FromDate3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FromDate3.Location = New System.Drawing.Point(406, 103)
        Me.FromDate3.Name = "FromDate3"
        Me.FromDate3.Size = New System.Drawing.Size(41, 27)
        Me.FromDate3.TabIndex = 134
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(770, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 19)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "備　　註"
        '
        'FromDate2
        '
        Me.FromDate2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FromDate2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FromDate2.Location = New System.Drawing.Point(406, 70)
        Me.FromDate2.Name = "FromDate2"
        Me.FromDate2.Size = New System.Drawing.Size(41, 27)
        Me.FromDate2.TabIndex = 133
        '
        'Week1
        '
        Me.Week1.AutoSize = True
        Me.Week1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Week1.Location = New System.Drawing.Point(373, 41)
        Me.Week1.Name = "Week1"
        Me.Week1.Size = New System.Drawing.Size(18, 19)
        Me.Week1.TabIndex = 123
        Me.Week1.Text = "1"
        '
        'FromDate1
        '
        Me.FromDate1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FromDate1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FromDate1.Location = New System.Drawing.Point(406, 37)
        Me.FromDate1.Name = "FromDate1"
        Me.FromDate1.Size = New System.Drawing.Size(41, 27)
        Me.FromDate1.TabIndex = 118
        '
        'Week2
        '
        Me.Week2.AutoSize = True
        Me.Week2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Week2.Location = New System.Drawing.Point(373, 74)
        Me.Week2.Name = "Week2"
        Me.Week2.Size = New System.Drawing.Size(18, 19)
        Me.Week2.TabIndex = 124
        Me.Week2.Text = "2"
        '
        'Week3
        '
        Me.Week3.AutoSize = True
        Me.Week3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Week3.Location = New System.Drawing.Point(373, 107)
        Me.Week3.Name = "Week3"
        Me.Week3.Size = New System.Drawing.Size(18, 19)
        Me.Week3.TabIndex = 125
        Me.Week3.Text = "3"
        '
        'Week4
        '
        Me.Week4.AutoSize = True
        Me.Week4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Week4.Location = New System.Drawing.Point(373, 140)
        Me.Week4.Name = "Week4"
        Me.Week4.Size = New System.Drawing.Size(18, 19)
        Me.Week4.TabIndex = 126
        Me.Week4.Text = "4"
        '
        'Comments5
        '
        Me.Comments5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Comments5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Comments5.Location = New System.Drawing.Point(709, 169)
        Me.Comments5.Name = "Comments5"
        Me.Comments5.Size = New System.Drawing.Size(214, 27)
        Me.Comments5.TabIndex = 156
        '
        'Week5
        '
        Me.Week5.AutoSize = True
        Me.Week5.BackColor = System.Drawing.SystemColors.Control
        Me.Week5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Week5.Location = New System.Drawing.Point(372, 173)
        Me.Week5.Name = "Week5"
        Me.Week5.Size = New System.Drawing.Size(18, 19)
        Me.Week5.TabIndex = 127
        Me.Week5.Text = "5"
        '
        'Comments4
        '
        Me.Comments4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Comments4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Comments4.Location = New System.Drawing.Point(709, 136)
        Me.Comments4.Name = "Comments4"
        Me.Comments4.Size = New System.Drawing.Size(214, 27)
        Me.Comments4.TabIndex = 155
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(450, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 19)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "至"
        '
        'Comments3
        '
        Me.Comments3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Comments3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Comments3.Location = New System.Drawing.Point(709, 103)
        Me.Comments3.Name = "Comments3"
        Me.Comments3.Size = New System.Drawing.Size(214, 27)
        Me.Comments3.TabIndex = 154
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(450, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 19)
        Me.Label11.TabIndex = 129
        Me.Label11.Text = "至"
        '
        'Comments2
        '
        Me.Comments2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Comments2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Comments2.Location = New System.Drawing.Point(709, 70)
        Me.Comments2.Name = "Comments2"
        Me.Comments2.Size = New System.Drawing.Size(214, 27)
        Me.Comments2.TabIndex = 153
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(450, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 19)
        Me.Label12.TabIndex = 130
        Me.Label12.Text = "至"
        '
        'Comments1
        '
        Me.Comments1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Comments1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Comments1.Location = New System.Drawing.Point(709, 37)
        Me.Comments1.Name = "Comments1"
        Me.Comments1.Size = New System.Drawing.Size(214, 27)
        Me.Comments1.TabIndex = 152
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(450, 140)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 19)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "至"
        '
        'RealQty5
        '
        Me.RealQty5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RealQty5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RealQty5.Location = New System.Drawing.Point(619, 169)
        Me.RealQty5.Name = "RealQty5"
        Me.RealQty5.Size = New System.Drawing.Size(81, 27)
        Me.RealQty5.TabIndex = 151
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(450, 173)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 19)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "至"
        '
        'RealQty4
        '
        Me.RealQty4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RealQty4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RealQty4.Location = New System.Drawing.Point(619, 136)
        Me.RealQty4.Name = "RealQty4"
        Me.RealQty4.Size = New System.Drawing.Size(81, 27)
        Me.RealQty4.TabIndex = 150
        '
        'ToDate1
        '
        Me.ToDate1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToDate1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToDate1.Location = New System.Drawing.Point(480, 37)
        Me.ToDate1.Name = "ToDate1"
        Me.ToDate1.Size = New System.Drawing.Size(41, 27)
        Me.ToDate1.TabIndex = 137
        '
        'RealQty3
        '
        Me.RealQty3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RealQty3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RealQty3.Location = New System.Drawing.Point(619, 103)
        Me.RealQty3.Name = "RealQty3"
        Me.RealQty3.Size = New System.Drawing.Size(81, 27)
        Me.RealQty3.TabIndex = 149
        '
        'ToDate2
        '
        Me.ToDate2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToDate2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToDate2.Location = New System.Drawing.Point(480, 70)
        Me.ToDate2.Name = "ToDate2"
        Me.ToDate2.Size = New System.Drawing.Size(41, 27)
        Me.ToDate2.TabIndex = 138
        '
        'RealQty2
        '
        Me.RealQty2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RealQty2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RealQty2.Location = New System.Drawing.Point(619, 70)
        Me.RealQty2.Name = "RealQty2"
        Me.RealQty2.Size = New System.Drawing.Size(81, 27)
        Me.RealQty2.TabIndex = 148
        '
        'ToDate3
        '
        Me.ToDate3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToDate3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToDate3.Location = New System.Drawing.Point(480, 103)
        Me.ToDate3.Name = "ToDate3"
        Me.ToDate3.Size = New System.Drawing.Size(41, 27)
        Me.ToDate3.TabIndex = 139
        '
        'RealQty1
        '
        Me.RealQty1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RealQty1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RealQty1.Location = New System.Drawing.Point(619, 37)
        Me.RealQty1.Name = "RealQty1"
        Me.RealQty1.Size = New System.Drawing.Size(81, 27)
        Me.RealQty1.TabIndex = 147
        '
        'ToDate4
        '
        Me.ToDate4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToDate4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToDate4.Location = New System.Drawing.Point(480, 136)
        Me.ToDate4.Name = "ToDate4"
        Me.ToDate4.Size = New System.Drawing.Size(41, 27)
        Me.ToDate4.TabIndex = 140
        '
        'ReckonQty5
        '
        Me.ReckonQty5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ReckonQty5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReckonQty5.Location = New System.Drawing.Point(529, 169)
        Me.ReckonQty5.Name = "ReckonQty5"
        Me.ReckonQty5.Size = New System.Drawing.Size(81, 27)
        Me.ReckonQty5.TabIndex = 146
        '
        'ToDate5
        '
        Me.ToDate5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToDate5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ToDate5.Location = New System.Drawing.Point(480, 169)
        Me.ToDate5.Name = "ToDate5"
        Me.ToDate5.Size = New System.Drawing.Size(41, 27)
        Me.ToDate5.TabIndex = 141
        '
        'ReckonQty4
        '
        Me.ReckonQty4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ReckonQty4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReckonQty4.Location = New System.Drawing.Point(529, 136)
        Me.ReckonQty4.Name = "ReckonQty4"
        Me.ReckonQty4.Size = New System.Drawing.Size(81, 27)
        Me.ReckonQty4.TabIndex = 145
        '
        'ReckonQty1
        '
        Me.ReckonQty1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ReckonQty1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReckonQty1.Location = New System.Drawing.Point(529, 37)
        Me.ReckonQty1.Name = "ReckonQty1"
        Me.ReckonQty1.Size = New System.Drawing.Size(81, 27)
        Me.ReckonQty1.TabIndex = 142
        '
        'ReckonQty3
        '
        Me.ReckonQty3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ReckonQty3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReckonQty3.Location = New System.Drawing.Point(529, 103)
        Me.ReckonQty3.Name = "ReckonQty3"
        Me.ReckonQty3.Size = New System.Drawing.Size(81, 27)
        Me.ReckonQty3.TabIndex = 144
        '
        'ReckonQty2
        '
        Me.ReckonQty2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ReckonQty2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ReckonQty2.Location = New System.Drawing.Point(529, 70)
        Me.ReckonQty2.Name = "ReckonQty2"
        Me.ReckonQty2.Size = New System.Drawing.Size(81, 27)
        Me.ReckonQty2.TabIndex = 143
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Unit2)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.DGV2)
        Me.TabPage2.Controls.Add(Me.查詢2)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.Month2)
        Me.TabPage2.Controls.Add(Me.Year2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(936, 534)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "差異"
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(22, 135)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(890, 372)
        Me.DGV2.TabIndex = 70
        '
        '查詢2
        '
        Me.查詢2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢2.Location = New System.Drawing.Point(190, 72)
        Me.查詢2.Name = "查詢2"
        Me.查詢2.Size = New System.Drawing.Size(85, 48)
        Me.查詢2.TabIndex = 69
        Me.查詢2.Text = "查詢"
        Me.查詢2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(18, 97)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 19)
        Me.Label16.TabIndex = 68
        Me.Label16.Text = "月份："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(18, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 19)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "年度："
        '
        'Month2
        '
        Me.Month2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Month2.FormattingEnabled = True
        Me.Month2.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.Month2.Location = New System.Drawing.Point(85, 96)
        Me.Month2.Name = "Month2"
        Me.Month2.Size = New System.Drawing.Size(86, 24)
        Me.Month2.TabIndex = 66
        '
        'Year2
        '
        Me.Year2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Year2.FormattingEnabled = True
        Me.Year2.Items.AddRange(New Object() {"2016"})
        Me.Year2.Location = New System.Drawing.Point(85, 55)
        Me.Year2.Name = "Year2"
        Me.Year2.Size = New System.Drawing.Size(86, 24)
        Me.Year2.TabIndex = 65
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(18, 17)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(66, 19)
        Me.Label17.TabIndex = 165
        Me.Label17.Text = "單位："
        '
        'Unit2
        '
        Me.Unit2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Unit2.FormattingEnabled = True
        Me.Unit2.Items.AddRange(New Object() {"營業", "契養"})
        Me.Unit2.Location = New System.Drawing.Point(85, 16)
        Me.Unit2.Name = "Unit2"
        Me.Unit2.Size = New System.Drawing.Size(86, 24)
        Me.Unit2.TabIndex = 166
        '
        '數量差異表
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 565)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "數量差異表"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "數量差異表"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 更新 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 修改 As System.Windows.Forms.Button
    Friend WithEvents ItemName As System.Windows.Forms.TextBox
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents 新增 As System.Windows.Forms.Button
    Friend WithEvents Unit As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Month As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Year As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FromDate5 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents FromDate4 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FromDate3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents FromDate2 As System.Windows.Forms.TextBox
    Friend WithEvents Week1 As System.Windows.Forms.Label
    Friend WithEvents FromDate1 As System.Windows.Forms.TextBox
    Friend WithEvents Week2 As System.Windows.Forms.Label
    Friend WithEvents Week3 As System.Windows.Forms.Label
    Friend WithEvents Week4 As System.Windows.Forms.Label
    Friend WithEvents Comments5 As System.Windows.Forms.TextBox
    Friend WithEvents Week5 As System.Windows.Forms.Label
    Friend WithEvents Comments4 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Comments3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Comments2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Comments1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RealQty5 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RealQty4 As System.Windows.Forms.TextBox
    Friend WithEvents ToDate1 As System.Windows.Forms.TextBox
    Friend WithEvents RealQty3 As System.Windows.Forms.TextBox
    Friend WithEvents ToDate2 As System.Windows.Forms.TextBox
    Friend WithEvents RealQty2 As System.Windows.Forms.TextBox
    Friend WithEvents ToDate3 As System.Windows.Forms.TextBox
    Friend WithEvents RealQty1 As System.Windows.Forms.TextBox
    Friend WithEvents ToDate4 As System.Windows.Forms.TextBox
    Friend WithEvents ReckonQty5 As System.Windows.Forms.TextBox
    Friend WithEvents ToDate5 As System.Windows.Forms.TextBox
    Friend WithEvents ReckonQty4 As System.Windows.Forms.TextBox
    Friend WithEvents ReckonQty1 As System.Windows.Forms.TextBox
    Friend WithEvents ReckonQty3 As System.Windows.Forms.TextBox
    Friend WithEvents ReckonQty2 As System.Windows.Forms.TextBox
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents 查詢2 As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Month2 As System.Windows.Forms.ComboBox
    Friend WithEvents Year2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Unit2 As System.Windows.Forms.ComboBox
End Class
