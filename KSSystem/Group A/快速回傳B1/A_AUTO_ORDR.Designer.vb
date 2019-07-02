<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_AUTO_ORDR
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
        Me.CommentsTxt = New System.Windows.Forms.TextBox
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.AddItemBtn = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.ItemU_P8Txt = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SearchBtn2 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.ItemU_P4Txt = New System.Windows.Forms.TextBox
        Me.Quantity = New System.Windows.Forms.TextBox
        Me.ItemU_P7cob = New System.Windows.Forms.ComboBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.ItemU_P3_Order = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ItemU_P6cob = New System.Windows.Forms.ComboBox
        Me.ItemU_P3cob = New System.Windows.Forms.ComboBox
        Me.U_CarDr1 = New System.Windows.Forms.ComboBox
        Me.U_CarDr3 = New System.Windows.Forms.ComboBox
        Me.U_CarDr2 = New System.Windows.Forms.ComboBox
        Me.U_CarDr1Txt = New System.Windows.Forms.TextBox
        Me.U_CarDr2Txt = New System.Windows.Forms.TextBox
        Me.U_CarDr3Txt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.DocDueDate = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.cobOwner = New System.Windows.Forms.ComboBox
        Me.laCardCode = New System.Windows.Forms.Label
        Me.laCardName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.ddlKeepName = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.laOrderSource = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CommentsTxt
        '
        Me.CommentsTxt.Location = New System.Drawing.Point(505, 690)
        Me.CommentsTxt.Multiline = True
        Me.CommentsTxt.Name = "CommentsTxt"
        Me.CommentsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentsTxt.Size = New System.Drawing.Size(209, 41)
        Me.CommentsTxt.TabIndex = 40
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemNameTxt.Location = New System.Drawing.Point(505, 540)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(209, 27)
        Me.ItemNameTxt.TabIndex = 36
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemCodeTxt.Location = New System.Drawing.Point(505, 511)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(210, 27)
        Me.ItemCodeTxt.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(431, 709)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "備註："
        '
        'AddItemBtn
        '
        Me.AddItemBtn.Location = New System.Drawing.Point(721, 513)
        Me.AddItemBtn.Name = "AddItemBtn"
        Me.AddItemBtn.Size = New System.Drawing.Size(72, 52)
        Me.AddItemBtn.TabIndex = 38
        Me.AddItemBtn.Text = "新增項目"
        Me.AddItemBtn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(426, 545)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "項目名稱："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(426, 518)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "項目編號："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 510)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "新增項目："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "交易資料："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "客戶名稱："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "客戶編號："
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.Color.Red
        Me.SaveBtn.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(686, 3)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(108, 70)
        Me.SaveBtn.TabIndex = 25
        Me.SaveBtn.Text = "儲存" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "草稿單"
        Me.SaveBtn.UseVisualStyleBackColor = False
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 93)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(788, 209)
        Me.DGV1.TabIndex = 24
        '
        'ItemU_P8Txt
        '
        Me.ItemU_P8Txt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P8Txt.Location = New System.Drawing.Point(505, 571)
        Me.ItemU_P8Txt.Name = "ItemU_P8Txt"
        Me.ItemU_P8Txt.Size = New System.Drawing.Size(48, 27)
        Me.ItemU_P8Txt.TabIndex = 43
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(721, 621)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(73, 22)
        Me.TextBox1.TabIndex = 45
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(721, 649)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(73, 22)
        Me.TextBox2.TabIndex = 44
        '
        'SearchBtn2
        '
        Me.SearchBtn2.Location = New System.Drawing.Point(721, 705)
        Me.SearchBtn2.Name = "SearchBtn2"
        Me.SearchBtn2.Size = New System.Drawing.Size(73, 23)
        Me.SearchBtn2.TabIndex = 46
        Me.SearchBtn2.Text = "查詢項目"
        Me.SearchBtn2.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(6, 527)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(414, 204)
        Me.DGV2.TabIndex = 47
        '
        'ItemU_P4Txt
        '
        Me.ItemU_P4Txt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P4Txt.Location = New System.Drawing.Point(505, 633)
        Me.ItemU_P4Txt.Name = "ItemU_P4Txt"
        Me.ItemU_P4Txt.ReadOnly = True
        Me.ItemU_P4Txt.Size = New System.Drawing.Size(48, 27)
        Me.ItemU_P4Txt.TabIndex = 48
        Me.ItemU_P4Txt.Text = "0"
        '
        'Quantity
        '
        Me.Quantity.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Quantity.Location = New System.Drawing.Point(505, 602)
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Size = New System.Drawing.Size(48, 27)
        Me.Quantity.TabIndex = 48
        '
        'ItemU_P7cob
        '
        Me.ItemU_P7cob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemU_P7cob.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P7cob.FormattingEnabled = True
        Me.ItemU_P7cob.Items.AddRange(New Object() {"庫存單位", "KG", "小單位", "重整"})
        Me.ItemU_P7cob.Location = New System.Drawing.Point(642, 572)
        Me.ItemU_P7cob.Name = "ItemU_P7cob"
        Me.ItemU_P7cob.Size = New System.Drawing.Size(72, 24)
        Me.ItemU_P7cob.TabIndex = 151
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(721, 677)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(73, 22)
        Me.TextBox3.TabIndex = 152
        '
        'ItemU_P3_Order
        '
        Me.ItemU_P3_Order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemU_P3_Order.FormattingEnabled = True
        Me.ItemU_P3_Order.Items.AddRange(New Object() {"Y", "N"})
        Me.ItemU_P3_Order.Location = New System.Drawing.Point(549, 3)
        Me.ItemU_P3_Order.Name = "ItemU_P3_Order"
        Me.ItemU_P3_Order.Size = New System.Drawing.Size(131, 20)
        Me.ItemU_P3_Order.TabIndex = 153
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(464, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "生產訂單："
        '
        'ItemU_P6cob
        '
        Me.ItemU_P6cob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemU_P6cob.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P6cob.FormattingEnabled = True
        Me.ItemU_P6cob.Location = New System.Drawing.Point(642, 602)
        Me.ItemU_P6cob.Name = "ItemU_P6cob"
        Me.ItemU_P6cob.Size = New System.Drawing.Size(72, 24)
        Me.ItemU_P6cob.TabIndex = 155
        '
        'ItemU_P3cob
        '
        Me.ItemU_P3cob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemU_P3cob.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P3cob.FormattingEnabled = True
        Me.ItemU_P3cob.Items.AddRange(New Object() {"Y", "N"})
        Me.ItemU_P3cob.Location = New System.Drawing.Point(642, 634)
        Me.ItemU_P3cob.Name = "ItemU_P3cob"
        Me.ItemU_P3cob.Size = New System.Drawing.Size(72, 24)
        Me.ItemU_P3cob.TabIndex = 156
        '
        'U_CarDr1
        '
        Me.U_CarDr1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.U_CarDr1.FormattingEnabled = True
        Me.U_CarDr1.Location = New System.Drawing.Point(328, 4)
        Me.U_CarDr1.Name = "U_CarDr1"
        Me.U_CarDr1.Size = New System.Drawing.Size(131, 20)
        Me.U_CarDr1.TabIndex = 157
        '
        'U_CarDr3
        '
        Me.U_CarDr3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.U_CarDr3.FormattingEnabled = True
        Me.U_CarDr3.Location = New System.Drawing.Point(328, 53)
        Me.U_CarDr3.Name = "U_CarDr3"
        Me.U_CarDr3.Size = New System.Drawing.Size(131, 20)
        Me.U_CarDr3.TabIndex = 158
        '
        'U_CarDr2
        '
        Me.U_CarDr2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.U_CarDr2.FormattingEnabled = True
        Me.U_CarDr2.Location = New System.Drawing.Point(328, 28)
        Me.U_CarDr2.Name = "U_CarDr2"
        Me.U_CarDr2.Size = New System.Drawing.Size(131, 20)
        Me.U_CarDr2.TabIndex = 159
        '
        'U_CarDr1Txt
        '
        Me.U_CarDr1Txt.Location = New System.Drawing.Point(461, 0)
        Me.U_CarDr1Txt.Name = "U_CarDr1Txt"
        Me.U_CarDr1Txt.Size = New System.Drawing.Size(16, 22)
        Me.U_CarDr1Txt.TabIndex = 160
        Me.U_CarDr1Txt.Visible = False
        '
        'U_CarDr2Txt
        '
        Me.U_CarDr2Txt.Location = New System.Drawing.Point(461, 26)
        Me.U_CarDr2Txt.Name = "U_CarDr2Txt"
        Me.U_CarDr2Txt.Size = New System.Drawing.Size(16, 22)
        Me.U_CarDr2Txt.TabIndex = 161
        Me.U_CarDr2Txt.Visible = False
        '
        'U_CarDr3Txt
        '
        Me.U_CarDr3Txt.BackColor = System.Drawing.Color.White
        Me.U_CarDr3Txt.Location = New System.Drawing.Point(461, 51)
        Me.U_CarDr3Txt.Name = "U_CarDr3Txt"
        Me.U_CarDr3Txt.Size = New System.Drawing.Size(16, 22)
        Me.U_CarDr3Txt.TabIndex = 162
        Me.U_CarDr3Txt.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(426, 576)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 163
        Me.Label7.Text = "單　　價："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(426, 609)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 164
        Me.Label12.Text = "數　　量："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(426, 640)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "小單位量："
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(559, 576)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 166
        Me.Label14.Text = "計價單位："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(559, 606)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "小  單  位："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(559, 638)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 168
        Me.Label16.Text = "是否生產："
        '
        'DocDueDate
        '
        Me.DocDueDate.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDueDate.Location = New System.Drawing.Point(549, 26)
        Me.DocDueDate.Name = "DocDueDate"
        Me.DocDueDate.Size = New System.Drawing.Size(131, 23)
        Me.DocDueDate.TabIndex = 169
        Me.DocDueDate.Value = New Date(2012, 4, 12, 0, 0, 0, 0)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(264, 7)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 16)
        Me.Label17.TabIndex = 170
        Me.Label17.Text = "司機 1："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(264, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 16)
        Me.Label18.TabIndex = 171
        Me.Label18.Text = "司機 3："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(264, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 16)
        Me.Label19.TabIndex = 172
        Me.Label19.Text = "司機 2："
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(465, 31)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 16)
        Me.Label20.TabIndex = 173
        Me.Label20.Text = "交貨日期："
        '
        'cobOwner
        '
        Me.cobOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cobOwner.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cobOwner.FormattingEnabled = True
        Me.cobOwner.Location = New System.Drawing.Point(549, 51)
        Me.cobOwner.Name = "cobOwner"
        Me.cobOwner.Size = New System.Drawing.Size(131, 24)
        Me.cobOwner.TabIndex = 174
        '
        'laCardCode
        '
        Me.laCardCode.AutoSize = True
        Me.laCardCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laCardCode.Location = New System.Drawing.Point(87, 7)
        Me.laCardCode.Name = "laCardCode"
        Me.laCardCode.Size = New System.Drawing.Size(40, 16)
        Me.laCardCode.TabIndex = 175
        Me.laCardCode.Text = "客編"
        '
        'laCardName
        '
        Me.laCardName.AutoSize = True
        Me.laCardName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laCardName.Location = New System.Drawing.Point(87, 33)
        Me.laCardName.Name = "laCardName"
        Me.laCardName.Size = New System.Drawing.Size(40, 16)
        Me.laCardName.TabIndex = 176
        Me.laCardName.Text = "客名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "來源明細："
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(6, 321)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(787, 186)
        Me.DGV3.TabIndex = 178
        '
        'ddlKeepName
        '
        Me.ddlKeepName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlKeepName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlKeepName.FormattingEnabled = True
        Me.ddlKeepName.Items.AddRange(New Object() {"X", "冷藏", "冷凍"})
        Me.ddlKeepName.Location = New System.Drawing.Point(642, 664)
        Me.ddlKeepName.Name = "ddlKeepName"
        Me.ddlKeepName.Size = New System.Drawing.Size(72, 24)
        Me.ddlKeepName.TabIndex = 179
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(559, 668)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "溫層："
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(471, 54)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 16)
        Me.Label21.TabIndex = 181
        Me.Label21.Text = "Key單者："
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(749, 290)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 16)
        Me.Button2.TabIndex = 183
        Me.Button2.Text = "新增項目"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'laOrderSource
        '
        Me.laOrderSource.AutoSize = True
        Me.laOrderSource.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laOrderSource.Location = New System.Drawing.Point(3, 56)
        Me.laOrderSource.Name = "laOrderSource"
        Me.laOrderSource.Size = New System.Drawing.Size(72, 16)
        Me.laOrderSource.TabIndex = 184
        Me.laOrderSource.Text = "訂單來源"
        '
        'A_AUTO_ORDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 731)
        Me.Controls.Add(Me.laOrderSource)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cobOwner)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ddlKeepName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.laCardName)
        Me.Controls.Add(Me.laCardCode)
        Me.Controls.Add(Me.DocDueDate)
        Me.Controls.Add(Me.ItemU_P3_Order)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.U_CarDr2)
        Me.Controls.Add(Me.U_CarDr3)
        Me.Controls.Add(Me.U_CarDr1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ItemU_P3cob)
        Me.Controls.Add(Me.ItemU_P6cob)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ItemU_P7cob)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Quantity)
        Me.Controls.Add(Me.ItemU_P4Txt)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ItemU_P8Txt)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.U_CarDr1Txt)
        Me.Controls.Add(Me.U_CarDr2Txt)
        Me.Controls.Add(Me.U_CarDr3Txt)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.SearchBtn2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.CommentsTxt)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.AddItemBtn)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "A_AUTO_ORDR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "營業訂單系統"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CommentsTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents AddItemBtn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ItemU_P8Txt As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents SearchBtn2 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents ItemU_P4Txt As System.Windows.Forms.TextBox
    Friend WithEvents Quantity As System.Windows.Forms.TextBox
    Friend WithEvents ItemU_P7cob As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ItemU_P3_Order As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ItemU_P6cob As System.Windows.Forms.ComboBox
    Friend WithEvents ItemU_P3cob As System.Windows.Forms.ComboBox
    Friend WithEvents U_CarDr1 As System.Windows.Forms.ComboBox
    Friend WithEvents U_CarDr3 As System.Windows.Forms.ComboBox
    Friend WithEvents U_CarDr2 As System.Windows.Forms.ComboBox
    Friend WithEvents U_CarDr1Txt As System.Windows.Forms.TextBox
    Friend WithEvents U_CarDr2Txt As System.Windows.Forms.TextBox
    Friend WithEvents U_CarDr3Txt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DocDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cobOwner As System.Windows.Forms.ComboBox
    Friend WithEvents laCardCode As System.Windows.Forms.Label
    Friend WithEvents laCardName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents ddlKeepName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents laOrderSource As System.Windows.Forms.Label
End Class
