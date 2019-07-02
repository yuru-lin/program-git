<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E_QckAddOPOR
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
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dateDocDate = New System.Windows.Forms.DateTimePicker
        Me.Label48 = New System.Windows.Forms.Label
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCleanAll = New System.Windows.Forms.Button
        Me.cobOwner = New System.Windows.Forms.ComboBox
        Me.txtU_GetMT = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtU_TpMoney = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtU_Cnum = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtU_CK02 = New System.Windows.Forms.TextBox
        Me.cobDateType = New System.Windows.Forms.ComboBox
        Me.dateDosDueDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtComments = New System.Windows.Forms.RichTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCleanBody = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.cobU_Omoney = New System.Windows.Forms.ComboBox
        Me.cobU_P7 = New System.Windows.Forms.ComboBox
        Me.txtU_M5 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtU_M4 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtU_M2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtU_M1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtU_P8 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtU_P2 = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnAddToDetail = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 34)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(760, 157)
        Me.DGV1.TabIndex = 87
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(445, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 86
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dateDocDate
        '
        Me.dateDocDate.Location = New System.Drawing.Point(320, 6)
        Me.dateDocDate.Name = "dateDocDate"
        Me.dateDocDate.Size = New System.Drawing.Size(120, 22)
        Me.dateDocDate.TabIndex = 85
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label48.Location = New System.Drawing.Point(264, 9)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(56, 16)
        Me.Label48.TabIndex = 84
        Me.Label48.Text = "日期："
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(681, 322)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 88
        Me.SaveBtn.Text = "儲存"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnCleanAll)
        Me.Panel1.Controls.Add(Me.cobOwner)
        Me.Panel1.Controls.Add(Me.txtU_GetMT)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtU_TpMoney)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtU_Cnum)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtU_CK02)
        Me.Panel1.Controls.Add(Me.cobDateType)
        Me.Panel1.Controls.Add(Me.dateDosDueDate)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtComments)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.CardName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CardCode)
        Me.Panel1.Controls.Add(Me.SaveBtn)
        Me.Panel1.Location = New System.Drawing.Point(12, 197)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 353)
        Me.Panel1.TabIndex = 89
        '
        'btnCleanAll
        '
        Me.btnCleanAll.Location = New System.Drawing.Point(603, 322)
        Me.btnCleanAll.Name = "btnCleanAll"
        Me.btnCleanAll.Size = New System.Drawing.Size(72, 23)
        Me.btnCleanAll.TabIndex = 154
        Me.btnCleanAll.Text = "清空"
        Me.btnCleanAll.UseVisualStyleBackColor = True
        '
        'cobOwner
        '
        Me.cobOwner.FormattingEnabled = True
        Me.cobOwner.Items.AddRange(New Object() {"庫存單位", "KG", "小單位"})
        Me.cobOwner.Location = New System.Drawing.Point(365, 324)
        Me.cobOwner.Name = "cobOwner"
        Me.cobOwner.Size = New System.Drawing.Size(107, 20)
        Me.cobOwner.TabIndex = 154
        '
        'txtU_GetMT
        '
        Me.txtU_GetMT.Location = New System.Drawing.Point(381, 296)
        Me.txtU_GetMT.Name = "txtU_GetMT"
        Me.txtU_GetMT.Size = New System.Drawing.Size(70, 22)
        Me.txtU_GetMT.TabIndex = 159
        Me.txtU_GetMT.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(293, 326)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 16)
        Me.Label19.TabIndex = 153
        Me.Label19.Text = "所有人："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(293, 299)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 16)
        Me.Label18.TabIndex = 158
        Me.Label18.Text = "毛雞金額："
        '
        'txtU_TpMoney
        '
        Me.txtU_TpMoney.Location = New System.Drawing.Point(507, 296)
        Me.txtU_TpMoney.Name = "txtU_TpMoney"
        Me.txtU_TpMoney.Size = New System.Drawing.Size(70, 22)
        Me.txtU_TpMoney.TabIndex = 154
        Me.txtU_TpMoney.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(527, 274)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 157
        Me.Label16.Text = "契養編號："
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(451, 299)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 16)
        Me.Label17.TabIndex = 153
        Me.Label17.Text = "運費："
        '
        'txtU_Cnum
        '
        Me.txtU_Cnum.Location = New System.Drawing.Point(615, 271)
        Me.txtU_Cnum.Name = "txtU_Cnum"
        Me.txtU_Cnum.Size = New System.Drawing.Size(140, 22)
        Me.txtU_Cnum.TabIndex = 156
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(293, 271)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 155
        Me.Label15.Text = "製單編號："
        '
        'txtU_CK02
        '
        Me.txtU_CK02.Location = New System.Drawing.Point(381, 268)
        Me.txtU_CK02.Name = "txtU_CK02"
        Me.txtU_CK02.Size = New System.Drawing.Size(140, 22)
        Me.txtU_CK02.TabIndex = 154
        '
        'cobDateType
        '
        Me.cobDateType.FormattingEnabled = True
        Me.cobDateType.Items.AddRange(New Object() {"自訂", "40天", "2個月"})
        Me.cobDateType.Location = New System.Drawing.Point(544, 4)
        Me.cobDateType.Name = "cobDateType"
        Me.cobDateType.Size = New System.Drawing.Size(75, 20)
        Me.cobDateType.TabIndex = 153
        '
        'dateDosDueDate
        '
        Me.dateDosDueDate.Location = New System.Drawing.Point(625, 3)
        Me.dateDosDueDate.Name = "dateDosDueDate"
        Me.dateDosDueDate.Size = New System.Drawing.Size(120, 22)
        Me.dateDosDueDate.TabIndex = 91
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(460, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 90
        Me.Label14.Text = "交貨日期："
        '
        'txtComments
        '
        Me.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComments.Location = New System.Drawing.Point(60, 271)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(227, 74)
        Me.txtComments.TabIndex = 98
        Me.txtComments.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 268)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "備註："
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnCleanBody)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.cobU_Omoney)
        Me.Panel2.Controls.Add(Me.cobU_P7)
        Me.Panel2.Controls.Add(Me.txtU_M5)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtU_M4)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtU_M2)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtU_M1)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtU_P8)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtU_P2)
        Me.Panel2.Controls.Add(Me.Label37)
        Me.Panel2.Controls.Add(Me.txtQuantity)
        Me.Panel2.Controls.Add(Me.Label46)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ItemNameTxt)
        Me.Panel2.Controls.Add(Me.ItemCodeTxt)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.btnAddToDetail)
        Me.Panel2.Controls.Add(Me.DGV2)
        Me.Panel2.Location = New System.Drawing.Point(3, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(752, 234)
        Me.Panel2.TabIndex = 93
        '
        'btnCleanBody
        '
        Me.btnCleanBody.Location = New System.Drawing.Point(598, 203)
        Me.btnCleanBody.Name = "btnCleanBody"
        Me.btnCleanBody.Size = New System.Drawing.Size(72, 23)
        Me.btnCleanBody.TabIndex = 153
        Me.btnCleanBody.Text = "清空"
        Me.btnCleanBody.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label21.Location = New System.Drawing.Point(394, 203)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(139, 12)
        Me.Label21.TabIndex = 152
        Me.Label21.Text = "(重量*係數+過縣費+合車)"
        '
        'cobU_Omoney
        '
        Me.cobU_Omoney.FormattingEnabled = True
        Me.cobU_Omoney.Items.AddRange(New Object() {"現金", "支票抬頭", "支票不抬", "匯款"})
        Me.cobU_Omoney.Location = New System.Drawing.Point(534, 145)
        Me.cobU_Omoney.Name = "cobU_Omoney"
        Me.cobU_Omoney.Size = New System.Drawing.Size(75, 20)
        Me.cobU_Omoney.TabIndex = 151
        '
        'cobU_P7
        '
        Me.cobU_P7.FormattingEnabled = True
        Me.cobU_P7.Items.AddRange(New Object() {"庫存單位", "KG"})
        Me.cobU_P7.Location = New System.Drawing.Point(245, 145)
        Me.cobU_P7.Name = "cobU_P7"
        Me.cobU_P7.Size = New System.Drawing.Size(75, 20)
        Me.cobU_P7.TabIndex = 150
        '
        'txtU_M5
        '
        Me.txtU_M5.Enabled = False
        Me.txtU_M5.Location = New System.Drawing.Point(449, 178)
        Me.txtU_M5.Name = "txtU_M5"
        Me.txtU_M5.Size = New System.Drawing.Size(70, 22)
        Me.txtU_M5.TabIndex = 149
        Me.txtU_M5.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(393, 181)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "運費："
        '
        'txtU_M4
        '
        Me.txtU_M4.Location = New System.Drawing.Point(323, 178)
        Me.txtU_M4.Name = "txtU_M4"
        Me.txtU_M4.Size = New System.Drawing.Size(70, 22)
        Me.txtU_M4.TabIndex = 147
        Me.txtU_M4.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(267, 181)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "合車："
        '
        'txtU_M2
        '
        Me.txtU_M2.Location = New System.Drawing.Point(197, 178)
        Me.txtU_M2.Name = "txtU_M2"
        Me.txtU_M2.Size = New System.Drawing.Size(70, 22)
        Me.txtU_M2.TabIndex = 145
        Me.txtU_M2.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(125, 181)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "過縣費："
        '
        'txtU_M1
        '
        Me.txtU_M1.Location = New System.Drawing.Point(55, 178)
        Me.txtU_M1.Name = "txtU_M1"
        Me.txtU_M1.Size = New System.Drawing.Size(70, 22)
        Me.txtU_M1.TabIndex = 143
        Me.txtU_M1.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(-1, 181)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 142
        Me.Label13.Text = "係數："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(446, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "付款方法："
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(376, 144)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(70, 22)
        Me.txtTotal.TabIndex = 139
        Me.txtTotal.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(320, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "總計："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "計價單位："
        '
        'txtU_P8
        '
        Me.txtU_P8.Location = New System.Drawing.Point(87, 144)
        Me.txtU_P8.Name = "txtU_P8"
        Me.txtU_P8.Size = New System.Drawing.Size(70, 22)
        Me.txtU_P8.TabIndex = 135
        Me.txtU_P8.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(-1, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "未稅單價："
        '
        'txtU_P2
        '
        Me.txtU_P2.Location = New System.Drawing.Point(647, 110)
        Me.txtU_P2.Name = "txtU_P2"
        Me.txtU_P2.Size = New System.Drawing.Size(70, 22)
        Me.txtU_P2.TabIndex = 132
        Me.txtU_P2.Text = "0"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label37.Location = New System.Drawing.Point(549, 113)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(98, 16)
        Me.Label37.TabIndex = 133
        Me.Label37.Text = "重量(公斤)："
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(479, 110)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(70, 22)
        Me.txtQuantity.TabIndex = 131
        Me.txtQuantity.Text = "0"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label46.Location = New System.Drawing.Point(423, 113)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(56, 16)
        Me.Label46.TabIndex = 130
        Me.Label46.Text = "數量："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(-1, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "存編："
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Location = New System.Drawing.Point(283, 110)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemNameTxt.TabIndex = 46
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Location = New System.Drawing.Point(55, 110)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemCodeTxt.TabIndex = 45
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(195, 113)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "項目名稱："
        '
        'btnAddToDetail
        '
        Me.btnAddToDetail.Location = New System.Drawing.Point(676, 203)
        Me.btnAddToDetail.Name = "btnAddToDetail"
        Me.btnAddToDetail.Size = New System.Drawing.Size(72, 23)
        Me.btnAddToDetail.TabIndex = 33
        Me.btnAddToDetail.Text = "新增項目"
        Me.btnAddToDetail.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(3, 3)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowHeadersVisible = False
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(744, 101)
        Me.DGV2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(232, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "客戶名稱："
        '
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(320, 3)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(140, 22)
        Me.CardName.TabIndex = 91
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "客戶編號："
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(92, 3)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(140, 22)
        Me.CardCode.TabIndex = 89
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(56, 206)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 23)
        Me.Button1.TabIndex = 154
        Me.Button1.Text = "運費單價"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'E_QckAddOPOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.Label48)
        Me.Name = "E_QckAddOPOR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速新增採購草稿"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dateDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnAddToDetail As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.RichTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtU_P2 As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtU_M5 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtU_M4 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtU_M2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtU_M1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtU_P8 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cobU_Omoney As System.Windows.Forms.ComboBox
    Friend WithEvents cobU_P7 As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dateDosDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cobDateType As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtU_Cnum As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtU_CK02 As System.Windows.Forms.TextBox
    Friend WithEvents cobOwner As System.Windows.Forms.ComboBox
    Friend WithEvents txtU_GetMT As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtU_TpMoney As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnCleanAll As System.Windows.Forms.Button
    Friend WithEvents btnCleanBody As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
