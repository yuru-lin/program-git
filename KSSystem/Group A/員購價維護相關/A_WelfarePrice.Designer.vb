<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_WelfarePrice
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
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.AddItemBtn = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SearchBtn2 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.RB_冷凍 = New System.Windows.Forms.RadioButton
        Me.RB_冷藏 = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.BackColor = System.Drawing.SystemColors.Window
        Me.ItemNameTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemNameTxt.Location = New System.Drawing.Point(637, 154)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.ReadOnly = True
        Me.ItemNameTxt.Size = New System.Drawing.Size(302, 27)
        Me.ItemNameTxt.TabIndex = 36
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.BackColor = System.Drawing.SystemColors.Window
        Me.ItemCodeTxt.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ItemCodeTxt.Location = New System.Drawing.Point(637, 125)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.ReadOnly = True
        Me.ItemCodeTxt.Size = New System.Drawing.Size(302, 27)
        Me.ItemCodeTxt.TabIndex = 34
        '
        'AddItemBtn
        '
        Me.AddItemBtn.Location = New System.Drawing.Point(558, 223)
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
        Me.Label10.Location = New System.Drawing.Point(558, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "項目名稱："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(558, 132)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "項目編號："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "商品清單："
        '
        'SaveBtn
        '
        Me.SaveBtn.BackColor = System.Drawing.Color.Red
        Me.SaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.SaveBtn.Font = New System.Drawing.Font("標楷體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SaveBtn.Location = New System.Drawing.Point(768, 358)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(115, 70)
        Me.SaveBtn.TabIndex = 25
        Me.SaveBtn.Text = "送審"
        Me.SaveBtn.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(202, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(73, 22)
        Me.TextBox1.TabIndex = 45
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(279, 10)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(73, 22)
        Me.TextBox2.TabIndex = 44
        '
        'SearchBtn2
        '
        Me.SearchBtn2.Location = New System.Drawing.Point(439, 10)
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
        Me.DGV2.Location = New System.Drawing.Point(6, 96)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(546, 241)
        Me.DGV2.TabIndex = 47
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(637, 184)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(89, 27)
        Me.txtPrice.TabIndex = 48
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(357, 10)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(73, 22)
        Me.TextBox3.TabIndex = 152
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(558, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 164
        Me.Label12.Text = "單　　價："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 360)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(756, 219)
        Me.DGV1.TabIndex = 175
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "新增項目清單："
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB2.Location = New System.Drawing.Point(131, 10)
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
        Me.RB1.Location = New System.Drawing.Point(65, 10)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(58, 20)
        Me.RB1.TabIndex = 177
        Me.RB1.TabStop = True
        Me.RB1.Text = "電宰"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(558, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "溫        層："
        '
        'RB_冷凍
        '
        Me.RB_冷凍.AutoSize = True
        Me.RB_冷凍.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_冷凍.Location = New System.Drawing.Point(704, 96)
        Me.RB_冷凍.Name = "RB_冷凍"
        Me.RB_冷凍.Size = New System.Drawing.Size(58, 20)
        Me.RB_冷凍.TabIndex = 181
        Me.RB_冷凍.Text = "冷凍"
        Me.RB_冷凍.UseVisualStyleBackColor = True
        '
        'RB_冷藏
        '
        Me.RB_冷藏.AutoSize = True
        Me.RB_冷藏.Checked = True
        Me.RB_冷藏.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB_冷藏.Location = New System.Drawing.Point(638, 96)
        Me.RB_冷藏.Name = "RB_冷藏"
        Me.RB_冷藏.Size = New System.Drawing.Size(58, 20)
        Me.RB_冷藏.TabIndex = 180
        Me.RB_冷藏.TabStop = True
        Me.RB_冷藏.Text = "冷藏"
        Me.RB_冷藏.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "類型："
        '
        'A_WelfarePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 586)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RB_冷凍)
        Me.Controls.Add(Me.RB_冷藏)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RB2)
        Me.Controls.Add(Me.RB1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.SearchBtn2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.AddItemBtn)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.SaveBtn)
        Me.Name = "A_WelfarePrice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "員購價設定"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents AddItemBtn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents SearchBtn2 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RB_冷凍 As System.Windows.Forms.RadioButton
    Friend WithEvents RB_冷藏 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
