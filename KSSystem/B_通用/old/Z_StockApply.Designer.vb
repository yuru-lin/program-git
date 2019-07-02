<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Z_StockApply
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
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ddldepart = New System.Windows.Forms.ComboBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SearchBtn2 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.ItemU_P4Txt = New System.Windows.Forms.TextBox
        Me.Quantity = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.ItemU_P6cob = New System.Windows.Forms.ComboBox
        Me.ddlPurpose = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.小單位T = New System.Windows.Forms.Label
        Me.DocDueDate = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.Comments2Txt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.研發領用 = New System.Windows.Forms.CheckBox
        Me.RB3 = New System.Windows.Forms.RadioButton
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CommentsTxt
        '
        Me.CommentsTxt.Location = New System.Drawing.Point(637, 162)
        Me.CommentsTxt.Multiline = True
        Me.CommentsTxt.Name = "CommentsTxt"
        Me.CommentsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.CommentsTxt.Size = New System.Drawing.Size(302, 76)
        Me.CommentsTxt.TabIndex = 40
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.BackColor = System.Drawing.SystemColors.Window
        Me.ItemNameTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemNameTxt.Location = New System.Drawing.Point(637, 99)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.ReadOnly = True
        Me.ItemNameTxt.Size = New System.Drawing.Size(302, 27)
        Me.ItemNameTxt.TabIndex = 36
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.BackColor = System.Drawing.SystemColors.Window
        Me.ItemCodeTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemCodeTxt.Location = New System.Drawing.Point(637, 70)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.ReadOnly = True
        Me.ItemCodeTxt.Size = New System.Drawing.Size(302, 27)
        Me.ItemCodeTxt.TabIndex = 34
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(558, 162)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "項目備註："
        '
        'AddItemBtn
        '
        Me.AddItemBtn.Location = New System.Drawing.Point(867, 9)
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
        Me.Label10.Location = New System.Drawing.Point(558, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "項目名稱："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(558, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "項目編號："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "商品清單："
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.Color.Red
        Me.SaveBtn.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(768, 513)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(115, 70)
        Me.SaveBtn.TabIndex = 25
        Me.SaveBtn.Text = "送出申請"
        Me.SaveBtn.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(259, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "部門別："
        '
        'ddldepart
        '
        Me.ddldepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddldepart.FormattingEnabled = True
        Me.ddldepart.Items.AddRange(New Object() {"營業", "生管", "人事", "倉庫", "會計", "採購", "總經理室", "研發", "設計", "品管", "加工", "資訊"})
        Me.ddldepart.Location = New System.Drawing.Point(328, 5)
        Me.ddldepart.Name = "ddldepart"
        Me.ddldepart.Size = New System.Drawing.Size(131, 20)
        Me.ddldepart.TabIndex = 42
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(242, 38)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(73, 22)
        Me.TextBox1.TabIndex = 45
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(319, 38)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(73, 22)
        Me.TextBox2.TabIndex = 44
        '
        'SearchBtn2
        '
        Me.SearchBtn2.Location = New System.Drawing.Point(479, 38)
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
        Me.DGV2.Location = New System.Drawing.Point(6, 64)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(546, 241)
        Me.DGV2.TabIndex = 47
        '
        'ItemU_P4Txt
        '
        Me.ItemU_P4Txt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P4Txt.Location = New System.Drawing.Point(811, 127)
        Me.ItemU_P4Txt.Name = "ItemU_P4Txt"
        Me.ItemU_P4Txt.ReadOnly = True
        Me.ItemU_P4Txt.Size = New System.Drawing.Size(54, 27)
        Me.ItemU_P4Txt.TabIndex = 48
        Me.ItemU_P4Txt.Text = "0"
        '
        'Quantity
        '
        Me.Quantity.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Quantity.Location = New System.Drawing.Point(637, 129)
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Size = New System.Drawing.Size(89, 27)
        Me.Quantity.TabIndex = 48
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(397, 38)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(73, 22)
        Me.TextBox3.TabIndex = 152
        '
        'ItemU_P6cob
        '
        Me.ItemU_P6cob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ItemU_P6cob.Enabled = False
        Me.ItemU_P6cob.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemU_P6cob.FormattingEnabled = True
        Me.ItemU_P6cob.Location = New System.Drawing.Point(869, 128)
        Me.ItemU_P6cob.Name = "ItemU_P6cob"
        Me.ItemU_P6cob.Size = New System.Drawing.Size(70, 24)
        Me.ItemU_P6cob.TabIndex = 155
        '
        'ddlPurpose
        '
        Me.ddlPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlPurpose.FormattingEnabled = True
        Me.ddlPurpose.Location = New System.Drawing.Point(560, 5)
        Me.ddlPurpose.Name = "ddlPurpose"
        Me.ddlPurpose.Size = New System.Drawing.Size(131, 20)
        Me.ddlPurpose.TabIndex = 157
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(558, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 164
        Me.Label12.Text = "數　　量："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(732, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "小單位量："
        '
        '小單位T
        '
        Me.小單位T.AutoSize = True
        Me.小單位T.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.小單位T.Location = New System.Drawing.Point(874, 132)
        Me.小單位T.Name = "小單位T"
        Me.小單位T.Size = New System.Drawing.Size(65, 16)
        Me.小單位T.TabIndex = 167
        Me.小單位T.Text = "小單位T"
        Me.小單位T.Visible = False
        '
        'DocDueDate
        '
        Me.DocDueDate.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocDueDate.Location = New System.Drawing.Point(88, 7)
        Me.DocDueDate.Name = "DocDueDate"
        Me.DocDueDate.Size = New System.Drawing.Size(131, 23)
        Me.DocDueDate.TabIndex = 169
        Me.DocDueDate.Value = New Date(2012, 4, 12, 0, 0, 0, 0)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(474, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 170
        Me.Label17.Text = "領用用途："
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 16)
        Me.Label20.TabIndex = 173
        Me.Label20.Text = "取貨日期："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 324)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(756, 259)
        Me.DGV1.TabIndex = 175
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 308)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "新增項目清單："
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB2.Location = New System.Drawing.Point(126, 38)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(58, 20)
        Me.RB2.TabIndex = 178
        Me.RB2.Text = "加工"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB1.Location = New System.Drawing.Point(69, 38)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(58, 20)
        Me.RB1.TabIndex = 177
        Me.RB1.TabStop = True
        Me.RB1.Text = "電宰"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'Comments2Txt
        '
        Me.Comments2Txt.Location = New System.Drawing.Point(768, 324)
        Me.Comments2Txt.Multiline = True
        Me.Comments2Txt.Name = "Comments2Txt"
        Me.Comments2Txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Comments2Txt.Size = New System.Drawing.Size(171, 183)
        Me.Comments2Txt.TabIndex = 180
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(765, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 179
        Me.Label3.Text = "備      註："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(558, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(385, 16)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "電宰領用 件或箱 為單位，加工領用 小單位 為單位"
        '
        '研發領用
        '
        Me.研發領用.AutoSize = True
        Me.研發領用.Location = New System.Drawing.Point(560, 42)
        Me.研發領用.Name = "研發領用"
        Me.研發領用.Size = New System.Drawing.Size(72, 16)
        Me.研發領用.TabIndex = 182
        Me.研發領用.Text = "研發領用"
        Me.研發領用.UseVisualStyleBackColor = True
        Me.研發領用.Visible = False
        '
        'RB3
        '
        Me.RB3.AutoSize = True
        Me.RB3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB3.Location = New System.Drawing.Point(181, 38)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(58, 20)
        Me.RB3.TabIndex = 183
        Me.RB3.Text = "其他"
        Me.RB3.UseVisualStyleBackColor = True
        '
        'Z_StockApply
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 586)
        Me.Controls.Add(Me.小單位T)
        Me.Controls.Add(Me.RB3)
        Me.Controls.Add(Me.研發領用)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Comments2Txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RB2)
        Me.Controls.Add(Me.RB1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.DocDueDate)
        Me.Controls.Add(Me.ddldepart)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ddlPurpose)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ItemU_P6cob)
        Me.Controls.Add(Me.Quantity)
        Me.Controls.Add(Me.ItemU_P4Txt)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
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
        Me.Controls.Add(Me.SaveBtn)
        Me.Name = "Z_StockApply"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "存貨領用申請"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddldepart As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents SearchBtn2 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents ItemU_P4Txt As System.Windows.Forms.TextBox
    Friend WithEvents Quantity As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ItemU_P6cob As System.Windows.Forms.ComboBox
    Friend WithEvents ddlPurpose As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents 小單位T As System.Windows.Forms.Label
    Friend WithEvents DocDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Comments2Txt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 研發領用 As System.Windows.Forms.CheckBox
    Friend WithEvents RB3 As System.Windows.Forms.RadioButton
End Class
