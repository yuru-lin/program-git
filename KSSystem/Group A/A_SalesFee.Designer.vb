<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_SalesFee
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
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.calcSumAllBtn = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.MoneyAll = New System.Windows.Forms.TextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.SubComm = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.AddComm = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Money10 = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Money9 = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Money8 = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Money7 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Money6 = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Money5 = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Money4 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Money3 = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.counttimes = New System.Windows.Forms.Label
        Me.Money2 = New System.Windows.Forms.TextBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Money1_6 = New System.Windows.Forms.Label
        Me.Money1 = New System.Windows.Forms.TextBox
        Me.Money1_5 = New System.Windows.Forms.Label
        Me.Money1_4 = New System.Windows.Forms.Label
        Me.Money1_3 = New System.Windows.Forms.Label
        Me.Money1_2 = New System.Windows.Forms.Label
        Me.Money1_1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.GetData = New System.Windows.Forms.Button
        Me.ToExcelBtn3 = New System.Windows.Forms.Button
        Me.SumAllDGV = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.ToExcelBtn2 = New System.Windows.Forms.Button
        Me.ToExcelBtn1 = New System.Windows.Forms.Button
        Me.FSFeeDGV = New System.Windows.Forms.DataGridView
        Me.Label21 = New System.Windows.Forms.Label
        Me.KSFeeDGV = New System.Windows.Forms.DataGridView
        Me.Label19 = New System.Windows.Forms.Label
        Me.OSLPList = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.SumAllDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.FSFeeDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KSFeeDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 37)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(710, 468)
        Me.TabControl1.TabIndex = 125
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel6)
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(702, 442)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "明細"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel6.Controls.Add(Me.calcSumAllBtn)
        Me.Panel6.Controls.Add(Me.Label18)
        Me.Panel6.Controls.Add(Me.Label20)
        Me.Panel6.Controls.Add(Me.MoneyAll)
        Me.Panel6.Location = New System.Drawing.Point(43, 368)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(617, 59)
        Me.Panel6.TabIndex = 140
        '
        'calcSumAllBtn
        '
        Me.calcSumAllBtn.Location = New System.Drawing.Point(497, 16)
        Me.calcSumAllBtn.Name = "calcSumAllBtn"
        Me.calcSumAllBtn.Size = New System.Drawing.Size(75, 23)
        Me.calcSumAllBtn.TabIndex = 118
        Me.calcSumAllBtn.Text = "重新計算"
        Me.calcSumAllBtn.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(163, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(198, 13)
        Me.Label18.TabIndex = 137
        Me.Label18.Text = "( 1 + 2 + 3 - 4 + 5 + 6 + 7 + 8 + 9 - 10 )"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(44, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 16)
        Me.Label20.TabIndex = 133
        Me.Label20.Text = "本月應發獎金"
        '
        'MoneyAll
        '
        Me.MoneyAll.Location = New System.Drawing.Point(370, 16)
        Me.MoneyAll.Name = "MoneyAll"
        Me.MoneyAll.ReadOnly = True
        Me.MoneyAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MoneyAll.Size = New System.Drawing.Size(118, 22)
        Me.MoneyAll.TabIndex = 135
        Me.MoneyAll.Text = "0"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel5.Controls.Add(Me.SubComm)
        Me.Panel5.Controls.Add(Me.Label34)
        Me.Panel5.Controls.Add(Me.AddComm)
        Me.Panel5.Controls.Add(Me.Label33)
        Me.Panel5.Controls.Add(Me.Label32)
        Me.Panel5.Controls.Add(Me.Money10)
        Me.Panel5.Controls.Add(Me.Label29)
        Me.Panel5.Controls.Add(Me.Money9)
        Me.Panel5.Location = New System.Drawing.Point(368, 217)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(292, 145)
        Me.Panel5.TabIndex = 115
        '
        'SubComm
        '
        Me.SubComm.Location = New System.Drawing.Point(55, 107)
        Me.SubComm.Name = "SubComm"
        Me.SubComm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SubComm.Size = New System.Drawing.Size(229, 22)
        Me.SubComm.TabIndex = 139
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label34.Location = New System.Drawing.Point(0, 110)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 16)
        Me.Label34.TabIndex = 138
        Me.Label34.Text = "內容："
        '
        'AddComm
        '
        Me.AddComm.Location = New System.Drawing.Point(55, 43)
        Me.AddComm.Name = "AddComm"
        Me.AddComm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AddComm.Size = New System.Drawing.Size(229, 22)
        Me.AddComm.TabIndex = 137
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label33.Location = New System.Drawing.Point(0, 46)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 16)
        Me.Label33.TabIndex = 136
        Me.Label33.Text = "內容："
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label32.Location = New System.Drawing.Point(0, 78)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(116, 16)
        Me.Label32.TabIndex = 133
        Me.Label32.Text = "10.額外扣項："
        '
        'Money10
        '
        Me.Money10.Location = New System.Drawing.Point(169, 75)
        Me.Money10.Name = "Money10"
        Me.Money10.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money10.Size = New System.Drawing.Size(118, 22)
        Me.Money10.TabIndex = 135
        Me.Money10.Text = "0"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label29.Location = New System.Drawing.Point(0, 14)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(107, 16)
        Me.Label29.TabIndex = 132
        Me.Label29.Text = "9.額外加項："
        '
        'Money9
        '
        Me.Money9.Location = New System.Drawing.Point(169, 11)
        Me.Money9.Name = "Money9"
        Me.Money9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money9.Size = New System.Drawing.Size(118, 22)
        Me.Money9.TabIndex = 134
        Me.Money9.Text = "0"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel4.Controls.Add(Me.Money8)
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Controls.Add(Me.Money7)
        Me.Panel4.Controls.Add(Me.Label27)
        Me.Panel4.Controls.Add(Me.Money6)
        Me.Panel4.Controls.Add(Me.Label26)
        Me.Panel4.Controls.Add(Me.Money5)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Controls.Add(Me.Money4)
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.Money3)
        Me.Panel4.Controls.Add(Me.Label31)
        Me.Panel4.Location = New System.Drawing.Point(368, 11)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(292, 200)
        Me.Panel4.TabIndex = 115
        '
        'Money8
        '
        Me.Money8.Location = New System.Drawing.Point(166, 172)
        Me.Money8.Name = "Money8"
        Me.Money8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money8.Size = New System.Drawing.Size(118, 22)
        Me.Money8.TabIndex = 127
        Me.Money8.Text = "0"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label28.Location = New System.Drawing.Point(0, 175)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(107, 16)
        Me.Label28.TabIndex = 126
        Me.Label28.Text = "8.油資補貼："
        '
        'Money7
        '
        Me.Money7.Location = New System.Drawing.Point(166, 138)
        Me.Money7.Name = "Money7"
        Me.Money7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money7.Size = New System.Drawing.Size(118, 22)
        Me.Money7.TabIndex = 125
        Me.Money7.Text = "0"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label27.Location = New System.Drawing.Point(0, 141)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(158, 16)
        Me.Label27.TabIndex = 124
        Me.Label27.Text = "7.代送貨運費補助："
        '
        'Money6
        '
        Me.Money6.Location = New System.Drawing.Point(166, 104)
        Me.Money6.Name = "Money6"
        Me.Money6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money6.Size = New System.Drawing.Size(118, 22)
        Me.Money6.TabIndex = 123
        Me.Money6.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label26.Location = New System.Drawing.Point(0, 107)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(141, 16)
        Me.Label26.TabIndex = 122
        Me.Label26.Text = "6.回收空籃獎金："
        '
        'Money5
        '
        Me.Money5.Location = New System.Drawing.Point(166, 70)
        Me.Money5.Name = "Money5"
        Me.Money5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money5.Size = New System.Drawing.Size(118, 22)
        Me.Money5.TabIndex = 121
        Me.Money5.Text = "0"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label25.Location = New System.Drawing.Point(0, 73)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 16)
        Me.Label25.TabIndex = 120
        Me.Label25.Text = "5.電話費補助："
        '
        'Money4
        '
        Me.Money4.Location = New System.Drawing.Point(166, 36)
        Me.Money4.Name = "Money4"
        Me.Money4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money4.Size = New System.Drawing.Size(118, 22)
        Me.Money4.TabIndex = 119
        Me.Money4.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label24.Location = New System.Drawing.Point(0, 39)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(90, 16)
        Me.Label24.TabIndex = 118
        Me.Label24.Text = "4.呆倒帳："
        '
        'Money3
        '
        Me.Money3.Location = New System.Drawing.Point(166, 2)
        Me.Money3.Name = "Money3"
        Me.Money3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money3.Size = New System.Drawing.Size(118, 22)
        Me.Money3.TabIndex = 117
        Me.Money3.Text = "0"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(0, 5)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(141, 16)
        Me.Label31.TabIndex = 108
        Me.Label31.Text = "3.貨款回收獎金："
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel3.Controls.Add(Me.counttimes)
        Me.Panel3.Controls.Add(Me.Money2)
        Me.Panel3.Controls.Add(Me.DGV1)
        Me.Panel3.Controls.Add(Me.Label30)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Location = New System.Drawing.Point(43, 184)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(292, 178)
        Me.Panel3.TabIndex = 115
        '
        'counttimes
        '
        Me.counttimes.AutoSize = True
        Me.counttimes.Location = New System.Drawing.Point(278, 28)
        Me.counttimes.Name = "counttimes"
        Me.counttimes.Size = New System.Drawing.Size(11, 12)
        Me.counttimes.TabIndex = 118
        Me.counttimes.Text = "0"
        '
        'Money2
        '
        Me.Money2.Location = New System.Drawing.Point(130, 3)
        Me.Money2.Name = "Money2"
        Me.Money2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money2.Size = New System.Drawing.Size(159, 22)
        Me.Money2.TabIndex = 116
        Me.Money2.Text = "0"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(5, 55)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(284, 117)
        Me.DGV1.TabIndex = 110
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label30.Location = New System.Drawing.Point(0, 6)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(124, 16)
        Me.Label30.TabIndex = 108
        Me.Label30.Text = "2.新客戶獎金："
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(3, 28)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(161, 24)
        Me.Label35.TabIndex = 0
        Me.Label35.Text = "銷售金額月達50000元發600元" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "可保留三個月"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.Panel1.Controls.Add(Me.Money1_6)
        Me.Panel1.Controls.Add(Me.Money1)
        Me.Panel1.Controls.Add(Me.Money1_5)
        Me.Panel1.Controls.Add(Me.Money1_4)
        Me.Panel1.Controls.Add(Me.Money1_3)
        Me.Panel1.Controls.Add(Me.Money1_2)
        Me.Panel1.Controls.Add(Me.Money1_1)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(43, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 167)
        Me.Panel1.TabIndex = 108
        '
        'Money1_6
        '
        Me.Money1_6.AutoSize = True
        Me.Money1_6.Location = New System.Drawing.Point(3, 150)
        Me.Money1_6.Name = "Money1_6"
        Me.Money1_6.Size = New System.Drawing.Size(0, 12)
        Me.Money1_6.TabIndex = 118
        '
        'Money1
        '
        Me.Money1.Location = New System.Drawing.Point(105, 2)
        Me.Money1.Name = "Money1"
        Me.Money1.ReadOnly = True
        Me.Money1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Money1.Size = New System.Drawing.Size(184, 22)
        Me.Money1.TabIndex = 117
        Me.Money1.Text = "0"
        '
        'Money1_5
        '
        Me.Money1_5.AutoSize = True
        Me.Money1_5.Location = New System.Drawing.Point(140, 128)
        Me.Money1_5.Name = "Money1_5"
        Me.Money1_5.Size = New System.Drawing.Size(11, 12)
        Me.Money1_5.TabIndex = 114
        Me.Money1_5.Text = "0"
        '
        'Money1_4
        '
        Me.Money1_4.AutoSize = True
        Me.Money1_4.Location = New System.Drawing.Point(92, 106)
        Me.Money1_4.Name = "Money1_4"
        Me.Money1_4.Size = New System.Drawing.Size(11, 12)
        Me.Money1_4.TabIndex = 113
        Me.Money1_4.Text = "0"
        '
        'Money1_3
        '
        Me.Money1_3.AutoSize = True
        Me.Money1_3.Location = New System.Drawing.Point(140, 84)
        Me.Money1_3.Name = "Money1_3"
        Me.Money1_3.Size = New System.Drawing.Size(11, 12)
        Me.Money1_3.TabIndex = 112
        Me.Money1_3.Text = "0"
        '
        'Money1_2
        '
        Me.Money1_2.AutoSize = True
        Me.Money1_2.Location = New System.Drawing.Point(128, 62)
        Me.Money1_2.Name = "Money1_2"
        Me.Money1_2.Size = New System.Drawing.Size(11, 12)
        Me.Money1_2.TabIndex = 111
        Me.Money1_2.Text = "0"
        '
        'Money1_1
        '
        Me.Money1_1.AutoSize = True
        Me.Money1_1.Location = New System.Drawing.Point(146, 40)
        Me.Money1_1.Name = "Money1_1"
        Me.Money1_1.Size = New System.Drawing.Size(11, 12)
        Me.Money1_1.TabIndex = 110
        Me.Money1_1.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(0, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 16)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "1.業績獎金："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 12)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "調禮品金額*20*0.0015："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 12)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "餘額*0.0015 ："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 12)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "每增加100萬加1500元："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "超過600萬發6000元："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 12)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "月銷售總金額已扣退折："
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.GetData)
        Me.TabPage2.Controls.Add(Me.ToExcelBtn3)
        Me.TabPage2.Controls.Add(Me.SumAllDGV)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(702, 442)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "業績獎金表"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(100, 412)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 24)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "*請確認明細都正確後" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  再按""取得資料"""
        '
        'GetData
        '
        Me.GetData.Location = New System.Drawing.Point(6, 413)
        Me.GetData.Name = "GetData"
        Me.GetData.Size = New System.Drawing.Size(75, 23)
        Me.GetData.TabIndex = 121
        Me.GetData.Text = "取得資料"
        Me.GetData.UseVisualStyleBackColor = True
        '
        'ToExcelBtn3
        '
        Me.ToExcelBtn3.Location = New System.Drawing.Point(621, 413)
        Me.ToExcelBtn3.Name = "ToExcelBtn3"
        Me.ToExcelBtn3.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn3.TabIndex = 120
        Me.ToExcelBtn3.Text = "匯出Excel"
        Me.ToExcelBtn3.UseVisualStyleBackColor = True
        '
        'SumAllDGV
        '
        Me.SumAllDGV.AllowUserToAddRows = False
        Me.SumAllDGV.AllowUserToDeleteRows = False
        Me.SumAllDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SumAllDGV.Location = New System.Drawing.Point(6, 6)
        Me.SumAllDGV.Name = "SumAllDGV"
        Me.SumAllDGV.ReadOnly = True
        Me.SumAllDGV.RowTemplate.Height = 24
        Me.SumAllDGV.Size = New System.Drawing.Size(690, 397)
        Me.SumAllDGV.TabIndex = 117
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.ToExcelBtn2)
        Me.TabPage3.Controls.Add(Me.ToExcelBtn1)
        Me.TabPage3.Controls.Add(Me.FSFeeDGV)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.KSFeeDGV)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(702, 442)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "銷售統計表"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'ToExcelBtn2
        '
        Me.ToExcelBtn2.Location = New System.Drawing.Point(621, 416)
        Me.ToExcelBtn2.Name = "ToExcelBtn2"
        Me.ToExcelBtn2.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn2.TabIndex = 120
        Me.ToExcelBtn2.Text = "匯出Excel"
        Me.ToExcelBtn2.UseVisualStyleBackColor = True
        '
        'ToExcelBtn1
        '
        Me.ToExcelBtn1.Location = New System.Drawing.Point(621, 209)
        Me.ToExcelBtn1.Name = "ToExcelBtn1"
        Me.ToExcelBtn1.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn1.TabIndex = 119
        Me.ToExcelBtn1.Text = "匯出Excel"
        Me.ToExcelBtn1.UseVisualStyleBackColor = True
        '
        'FSFeeDGV
        '
        Me.FSFeeDGV.AllowUserToAddRows = False
        Me.FSFeeDGV.AllowUserToDeleteRows = False
        Me.FSFeeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FSFeeDGV.Location = New System.Drawing.Point(6, 238)
        Me.FSFeeDGV.Name = "FSFeeDGV"
        Me.FSFeeDGV.ReadOnly = True
        Me.FSFeeDGV.RowTemplate.Height = 24
        Me.FSFeeDGV.Size = New System.Drawing.Size(690, 175)
        Me.FSFeeDGV.TabIndex = 112
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 219)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(252, 16)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "樂陽-業務銷售業績統計明細表："
        '
        'KSFeeDGV
        '
        Me.KSFeeDGV.AllowUserToAddRows = False
        Me.KSFeeDGV.AllowUserToDeleteRows = False
        Me.KSFeeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.KSFeeDGV.Location = New System.Drawing.Point(6, 28)
        Me.KSFeeDGV.Name = "KSFeeDGV"
        Me.KSFeeDGV.ReadOnly = True
        Me.KSFeeDGV.RowTemplate.Height = 24
        Me.KSFeeDGV.Size = New System.Drawing.Size(690, 175)
        Me.KSFeeDGV.TabIndex = 110
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(252, 16)
        Me.Label19.TabIndex = 109
        Me.Label19.Text = "凱馨-業務銷售業績統計明細表："
        '
        'OSLPList
        '
        Me.OSLPList.FormattingEnabled = True
        Me.OSLPList.Location = New System.Drawing.Point(104, 9)
        Me.OSLPList.Name = "OSLPList"
        Me.OSLPList.Size = New System.Drawing.Size(110, 20)
        Me.OSLPList.TabIndex = 124
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "業務人員："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(449, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "至"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(218, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "資料期間："
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(479, 8)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(130, 22)
        Me.ToDate.TabIndex = 120
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(313, 8)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(130, 22)
        Me.FromDate.TabIndex = 119
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(647, 8)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 118
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'A_SalesFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 512)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.OSLPList)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.SearchBtn)
        Me.Name = "A_SalesFee"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "業務業績獎金表"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.SumAllDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.FSFeeDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KSFeeDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents calcSumAllBtn As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents MoneyAll As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents SubComm As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents AddComm As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Money10 As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Money9 As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Money8 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Money7 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Money6 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Money5 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Money4 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Money3 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents counttimes As System.Windows.Forms.Label
    Friend WithEvents Money2 As System.Windows.Forms.TextBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Money1_6 As System.Windows.Forms.Label
    Friend WithEvents Money1 As System.Windows.Forms.TextBox
    Friend WithEvents Money1_5 As System.Windows.Forms.Label
    Friend WithEvents Money1_4 As System.Windows.Forms.Label
    Friend WithEvents Money1_3 As System.Windows.Forms.Label
    Friend WithEvents Money1_2 As System.Windows.Forms.Label
    Friend WithEvents Money1_1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GetData As System.Windows.Forms.Button
    Friend WithEvents ToExcelBtn3 As System.Windows.Forms.Button
    Friend WithEvents SumAllDGV As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ToExcelBtn2 As System.Windows.Forms.Button
    Friend WithEvents ToExcelBtn1 As System.Windows.Forms.Button
    Friend WithEvents FSFeeDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents KSFeeDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents OSLPList As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
End Class
