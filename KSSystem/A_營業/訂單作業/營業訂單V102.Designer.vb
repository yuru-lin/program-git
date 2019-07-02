<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_營業_訂單輸入v002
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.FixedCust = New System.Windows.Forms.ComboBox
        Me.ItemU_P8Txt = New System.Windows.Forms.TextBox
        Me.品W1 = New System.Windows.Forms.TextBox
        Me.品W2 = New System.Windows.Forms.TextBox
        Me.SearchBtn2 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.ItemU_P4Txt = New System.Windows.Forms.TextBox
        Me.Quantity = New System.Windows.Forms.TextBox
        Me.ItemU_P7cob = New System.Windows.Forms.ComboBox
        Me.品W3 = New System.Windows.Forms.TextBox
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
        Me.Label21 = New System.Windows.Forms.Label
        Me.包含查詢 = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CommentsTxt
        '
        Me.CommentsTxt.Location = New System.Drawing.Point(638, 564)
        Me.CommentsTxt.Multiline = True
        Me.CommentsTxt.Name = "CommentsTxt"
        Me.CommentsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentsTxt.Size = New System.Drawing.Size(238, 67)
        Me.CommentsTxt.TabIndex = 40
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemNameTxt.Location = New System.Drawing.Point(667, 440)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(209, 27)
        Me.ItemNameTxt.TabIndex = 36
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemCodeTxt.Location = New System.Drawing.Point(667, 411)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(210, 27)
        Me.ItemCodeTxt.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(588, 577)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "備註："
        '
        'AddItemBtn
        '
        Me.AddItemBtn.Location = New System.Drawing.Point(883, 413)
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
        Me.Label10.Location = New System.Drawing.Point(588, 445)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "項目名稱："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(588, 418)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "項目編號："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 413)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "新增項目："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(188, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(308, 12)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "※編號、名稱 擇一輸入即可  客戶名稱按Tab鍵可模糊查詢"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "歷史交易資料："
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(237, 28)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 30
        Me.SearchBtn.Text = "查詢廠商"
        Me.SearchBtn.UseVisualStyleBackColor = True
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
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(91, 30)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(140, 22)
        Me.CardName.TabIndex = 28
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
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(91, 4)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(140, 22)
        Me.CardCode.TabIndex = 26
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.Color.Red
        Me.SaveBtn.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(850, 6)
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
        Me.DGV1.Location = New System.Drawing.Point(6, 91)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(952, 314)
        Me.DGV1.TabIndex = 24
        Me.DGV1.VirtualMode = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "固定客戶："
        '
        'FixedCust
        '
        Me.FixedCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FixedCust.FormattingEnabled = True
        Me.FixedCust.Items.AddRange(New Object() {"超"})
        Me.FixedCust.Location = New System.Drawing.Point(91, 54)
        Me.FixedCust.Name = "FixedCust"
        Me.FixedCust.Size = New System.Drawing.Size(140, 20)
        Me.FixedCust.TabIndex = 42
        '
        'ItemU_P8Txt
        '
        Me.ItemU_P8Txt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P8Txt.Location = New System.Drawing.Point(667, 471)
        Me.ItemU_P8Txt.Name = "ItemU_P8Txt"
        Me.ItemU_P8Txt.Size = New System.Drawing.Size(48, 27)
        Me.ItemU_P8Txt.TabIndex = 43
        '
        '品W1
        '
        Me.品W1.Location = New System.Drawing.Point(71, 408)
        Me.品W1.Name = "品W1"
        Me.品W1.Size = New System.Drawing.Size(80, 22)
        Me.品W1.TabIndex = 45
        '
        '品W2
        '
        Me.品W2.Location = New System.Drawing.Point(157, 408)
        Me.品W2.Name = "品W2"
        Me.品W2.Size = New System.Drawing.Size(80, 22)
        Me.品W2.TabIndex = 44
        '
        'SearchBtn2
        '
        Me.SearchBtn2.Location = New System.Drawing.Point(431, 408)
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
        Me.DGV2.Location = New System.Drawing.Point(6, 436)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(576, 195)
        Me.DGV2.TabIndex = 47
        '
        'ItemU_P4Txt
        '
        Me.ItemU_P4Txt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P4Txt.Location = New System.Drawing.Point(667, 533)
        Me.ItemU_P4Txt.Name = "ItemU_P4Txt"
        Me.ItemU_P4Txt.ReadOnly = True
        Me.ItemU_P4Txt.Size = New System.Drawing.Size(48, 27)
        Me.ItemU_P4Txt.TabIndex = 48
        Me.ItemU_P4Txt.Text = "0"
        '
        'Quantity
        '
        Me.Quantity.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Quantity.Location = New System.Drawing.Point(667, 502)
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
        Me.ItemU_P7cob.Location = New System.Drawing.Point(804, 472)
        Me.ItemU_P7cob.Name = "ItemU_P7cob"
        Me.ItemU_P7cob.Size = New System.Drawing.Size(72, 24)
        Me.ItemU_P7cob.TabIndex = 151
        '
        '品W3
        '
        Me.品W3.Location = New System.Drawing.Point(243, 408)
        Me.品W3.Name = "品W3"
        Me.品W3.Size = New System.Drawing.Size(80, 22)
        Me.品W3.TabIndex = 152
        '
        'ItemU_P3_Order
        '
        Me.ItemU_P3_Order.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemU_P3_Order.FormattingEnabled = True
        Me.ItemU_P3_Order.Items.AddRange(New Object() {"Y", "N"})
        Me.ItemU_P3_Order.Location = New System.Drawing.Point(714, 6)
        Me.ItemU_P3_Order.Name = "ItemU_P3_Order"
        Me.ItemU_P3_Order.Size = New System.Drawing.Size(131, 20)
        Me.ItemU_P3_Order.TabIndex = 153
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(629, 9)
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
        Me.ItemU_P6cob.Location = New System.Drawing.Point(804, 504)
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
        Me.ItemU_P3cob.Location = New System.Drawing.Point(804, 536)
        Me.ItemU_P3cob.Name = "ItemU_P3cob"
        Me.ItemU_P3cob.Size = New System.Drawing.Size(72, 24)
        Me.ItemU_P3cob.TabIndex = 156
        '
        'U_CarDr1
        '
        Me.U_CarDr1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.U_CarDr1.FormattingEnabled = True
        Me.U_CarDr1.Location = New System.Drawing.Point(492, 7)
        Me.U_CarDr1.Name = "U_CarDr1"
        Me.U_CarDr1.Size = New System.Drawing.Size(131, 20)
        Me.U_CarDr1.TabIndex = 157
        '
        'U_CarDr3
        '
        Me.U_CarDr3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.U_CarDr3.FormattingEnabled = True
        Me.U_CarDr3.Location = New System.Drawing.Point(492, 56)
        Me.U_CarDr3.Name = "U_CarDr3"
        Me.U_CarDr3.Size = New System.Drawing.Size(131, 20)
        Me.U_CarDr3.TabIndex = 158
        '
        'U_CarDr2
        '
        Me.U_CarDr2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.U_CarDr2.FormattingEnabled = True
        Me.U_CarDr2.Location = New System.Drawing.Point(492, 31)
        Me.U_CarDr2.Name = "U_CarDr2"
        Me.U_CarDr2.Size = New System.Drawing.Size(131, 20)
        Me.U_CarDr2.TabIndex = 159
        '
        'U_CarDr1Txt
        '
        Me.U_CarDr1Txt.Location = New System.Drawing.Point(6, 21)
        Me.U_CarDr1Txt.Name = "U_CarDr1Txt"
        Me.U_CarDr1Txt.Size = New System.Drawing.Size(105, 22)
        Me.U_CarDr1Txt.TabIndex = 160
        '
        'U_CarDr2Txt
        '
        Me.U_CarDr2Txt.Location = New System.Drawing.Point(6, 49)
        Me.U_CarDr2Txt.Name = "U_CarDr2Txt"
        Me.U_CarDr2Txt.Size = New System.Drawing.Size(105, 22)
        Me.U_CarDr2Txt.TabIndex = 161
        '
        'U_CarDr3Txt
        '
        Me.U_CarDr3Txt.BackColor = System.Drawing.Color.White
        Me.U_CarDr3Txt.Location = New System.Drawing.Point(6, 77)
        Me.U_CarDr3Txt.Name = "U_CarDr3Txt"
        Me.U_CarDr3Txt.Size = New System.Drawing.Size(105, 22)
        Me.U_CarDr3Txt.TabIndex = 162
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(588, 476)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 163
        Me.Label7.Text = "單　　價："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(588, 509)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 164
        Me.Label12.Text = "數　　量："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(588, 540)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "小單位量："
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(721, 476)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 166
        Me.Label14.Text = "計價單位："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(721, 508)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "小  單  位："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(721, 540)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 168
        Me.Label16.Text = "是否生產："
        '
        'DocDueDate
        '
        Me.DocDueDate.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDueDate.Location = New System.Drawing.Point(713, 55)
        Me.DocDueDate.Name = "DocDueDate"
        Me.DocDueDate.Size = New System.Drawing.Size(131, 23)
        Me.DocDueDate.TabIndex = 169
        Me.DocDueDate.Value = New Date(2012, 4, 12, 0, 0, 0, 0)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(428, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 16)
        Me.Label17.TabIndex = 170
        Me.Label17.Text = "司機 1："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(428, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(68, 16)
        Me.Label18.TabIndex = 171
        Me.Label18.Text = "司機 3："
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(428, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 16)
        Me.Label19.TabIndex = 172
        Me.Label19.Text = "司機 2："
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(629, 60)
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
        Me.cobOwner.Location = New System.Drawing.Point(713, 30)
        Me.cobOwner.Name = "cobOwner"
        Me.cobOwner.Size = New System.Drawing.Size(132, 24)
        Me.cobOwner.TabIndex = 174
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(635, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 16)
        Me.Label21.TabIndex = 183
        Me.Label21.Text = "Key單者："
        '
        '包含查詢
        '
        Me.包含查詢.AutoSize = True
        Me.包含查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.包含查詢.Location = New System.Drawing.Point(330, 410)
        Me.包含查詢.Name = "包含查詢"
        Me.包含查詢.Size = New System.Drawing.Size(95, 20)
        Me.包含查詢.TabIndex = 184
        Me.包含查詢.Text = "包含查詢"
        Me.包含查詢.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.U_CarDr1Txt)
        Me.GroupBox1.Controls.Add(Me.U_CarDr2Txt)
        Me.GroupBox1.Controls.Add(Me.U_CarDr3Txt)
        Me.GroupBox1.Location = New System.Drawing.Point(545, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 143)
        Me.GroupBox1.TabIndex = 185
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "參數"
        '
        'A_營業_訂單輸入
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 637)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.包含查詢)
        Me.Controls.Add(Me.cobOwner)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.DocDueDate)
        Me.Controls.Add(Me.ItemU_P3_Order)
        Me.Controls.Add(Me.FixedCust)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
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
        Me.Controls.Add(Me.品W3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.SearchBtn2)
        Me.Controls.Add(Me.品W1)
        Me.Controls.Add(Me.品W2)
        Me.Controls.Add(Me.CommentsTxt)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.AddItemBtn)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CardName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "A_營業_訂單輸入"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "營業訂單系統"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FixedCust As System.Windows.Forms.ComboBox
    Friend WithEvents ItemU_P8Txt As System.Windows.Forms.TextBox
    Friend WithEvents 品W1 As System.Windows.Forms.TextBox
    Friend WithEvents 品W2 As System.Windows.Forms.TextBox
    Friend WithEvents SearchBtn2 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents ItemU_P4Txt As System.Windows.Forms.TextBox
    Friend WithEvents Quantity As System.Windows.Forms.TextBox
    Friend WithEvents ItemU_P7cob As System.Windows.Forms.ComboBox
    Friend WithEvents 品W3 As System.Windows.Forms.TextBox
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
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents 包含查詢 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
