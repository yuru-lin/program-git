<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_UpdateEBin
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
        Me.SelectU_CarDr1 = New System.Windows.Forms.ComboBox
        Me.SelectDocDate = New System.Windows.Forms.DateTimePicker
        Me.SelectDocNum = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.SendBtn = New System.Windows.Forms.Button
        Me.U_CarDr1 = New System.Windows.Forms.ComboBox
        Me.AddID = New System.Windows.Forms.ComboBox
        Me.CardCode = New System.Windows.Forms.ComboBox
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.Descr = New System.Windows.Forms.TextBox
        Me.Bonus = New System.Windows.Forms.TextBox
        Me.InNum = New System.Windows.Forms.TextBox
        Me.DocNum = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SelectCU_CarDr1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CU_CarDr1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectU_CarDr1
        '
        Me.SelectU_CarDr1.FormattingEnabled = True
        Me.SelectU_CarDr1.Location = New System.Drawing.Point(333, 12)
        Me.SelectU_CarDr1.Name = "SelectU_CarDr1"
        Me.SelectU_CarDr1.Size = New System.Drawing.Size(220, 20)
        Me.SelectU_CarDr1.TabIndex = 125
        '
        'SelectDocDate
        '
        Me.SelectDocDate.Location = New System.Drawing.Point(112, 11)
        Me.SelectDocDate.Name = "SelectDocDate"
        Me.SelectDocDate.Size = New System.Drawing.Size(110, 22)
        Me.SelectDocDate.TabIndex = 123
        '
        'SelectDocNum
        '
        Me.SelectDocNum.Location = New System.Drawing.Point(112, 37)
        Me.SelectDocNum.Name = "SelectDocNum"
        Me.SelectDocNum.Size = New System.Drawing.Size(110, 22)
        Me.SelectDocNum.TabIndex = 122
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(12, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox1.TabIndex = 126
        Me.CheckBox1.Text = "回收日期："
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(12, 38)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox2.TabIndex = 127
        Me.CheckBox2.Text = "回收單號："
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(231, 11)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox3.TabIndex = 128
        Me.CheckBox3.Text = "司機姓名："
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(647, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 129
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(12, 67)
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSourceMain.Size = New System.Drawing.Size(710, 283)
        Me.dgvSourceMain.TabIndex = 130
        '
        'SendBtn
        '
        Me.SendBtn.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SendBtn.Location = New System.Drawing.Point(642, 480)
        Me.SendBtn.Name = "SendBtn"
        Me.SendBtn.Size = New System.Drawing.Size(80, 22)
        Me.SendBtn.TabIndex = 147
        Me.SendBtn.Text = "存檔"
        Me.SendBtn.UseVisualStyleBackColor = True
        '
        'U_CarDr1
        '
        Me.U_CarDr1.FormattingEnabled = True
        Me.U_CarDr1.Location = New System.Drawing.Point(340, 415)
        Me.U_CarDr1.Name = "U_CarDr1"
        Me.U_CarDr1.Size = New System.Drawing.Size(150, 20)
        Me.U_CarDr1.TabIndex = 146
        '
        'AddID
        '
        Me.AddID.FormattingEnabled = True
        Me.AddID.Location = New System.Drawing.Point(340, 389)
        Me.AddID.Name = "AddID"
        Me.AddID.Size = New System.Drawing.Size(150, 20)
        Me.AddID.TabIndex = 145
        '
        'CardCode
        '
        Me.CardCode.FormattingEnabled = True
        Me.CardCode.Location = New System.Drawing.Point(95, 389)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(135, 20)
        Me.CardCode.TabIndex = 144
        '
        'DocDate
        '
        Me.DocDate.Enabled = False
        Me.DocDate.Location = New System.Drawing.Point(340, 361)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(150, 22)
        Me.DocDate.TabIndex = 143
        '
        'Descr
        '
        Me.Descr.Location = New System.Drawing.Point(95, 443)
        Me.Descr.Multiline = True
        Me.Descr.Name = "Descr"
        Me.Descr.Size = New System.Drawing.Size(383, 59)
        Me.Descr.TabIndex = 142
        '
        'Bonus
        '
        Me.Bonus.Location = New System.Drawing.Point(587, 389)
        Me.Bonus.Name = "Bonus"
        Me.Bonus.Size = New System.Drawing.Size(135, 22)
        Me.Bonus.TabIndex = 141
        '
        'InNum
        '
        Me.InNum.Location = New System.Drawing.Point(587, 361)
        Me.InNum.Name = "InNum"
        Me.InNum.Size = New System.Drawing.Size(135, 22)
        Me.InNum.TabIndex = 140
        '
        'DocNum
        '
        Me.DocNum.Location = New System.Drawing.Point(95, 361)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.Size = New System.Drawing.Size(135, 22)
        Me.DocNum.TabIndex = 139
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(41, 446)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 138
        Me.Label10.Text = "說明："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(501, 392)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "特殊獎金："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(501, 364)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 136
        Me.Label8.Text = "回收數量："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(254, 419)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 135
        Me.Label7.Text = "司機姓名："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(254, 391)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "客戶簡稱："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(9, 391)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "客戶編號："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(254, 364)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "回收日期："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(9, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "回收單號："
        '
        'SelectCU_CarDr1
        '
        Me.SelectCU_CarDr1.Enabled = False
        Me.SelectCU_CarDr1.Location = New System.Drawing.Point(333, 38)
        Me.SelectCU_CarDr1.Name = "SelectCU_CarDr1"
        Me.SelectCU_CarDr1.Size = New System.Drawing.Size(110, 22)
        Me.SelectCU_CarDr1.TabIndex = 148
        Me.SelectCU_CarDr1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(247, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "司機編號："
        Me.Label2.Visible = False
        '
        'CU_CarDr1
        '
        Me.CU_CarDr1.Enabled = False
        Me.CU_CarDr1.Location = New System.Drawing.Point(95, 416)
        Me.CU_CarDr1.Name = "CU_CarDr1"
        Me.CU_CarDr1.Size = New System.Drawing.Size(135, 22)
        Me.CU_CarDr1.TabIndex = 151
        Me.CU_CarDr1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(9, 419)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "司機編號："
        Me.Label3.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(556, 419)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 22)
        Me.Button1.TabIndex = 153
        Me.Button1.Text = "修改"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button2.Location = New System.Drawing.Point(642, 419)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 22)
        Me.Button2.TabIndex = 154
        Me.Button2.Text = "取消"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'A_UpdateEBin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 512)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.U_CarDr1)
        Me.Controls.Add(Me.CU_CarDr1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SelectCU_CarDr1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SelectU_CarDr1)
        Me.Controls.Add(Me.SelectDocDate)
        Me.Controls.Add(Me.SelectDocNum)
        Me.Controls.Add(Me.SendBtn)
        Me.Controls.Add(Me.AddID)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Descr)
        Me.Controls.Add(Me.Bonus)
        Me.Controls.Add(Me.InNum)
        Me.Controls.Add(Me.DocNum)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Name = "A_UpdateEBin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "回收單修改"
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SelectU_CarDr1 As System.Windows.Forms.ComboBox
    Friend WithEvents SelectDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SelectDocNum As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents SendBtn As System.Windows.Forms.Button
    Friend WithEvents U_CarDr1 As System.Windows.Forms.ComboBox
    Friend WithEvents AddID As System.Windows.Forms.ComboBox
    Friend WithEvents CardCode As System.Windows.Forms.ComboBox
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Descr As System.Windows.Forms.TextBox
    Friend WithEvents Bonus As System.Windows.Forms.TextBox
    Friend WithEvents InNum As System.Windows.Forms.TextBox
    Friend WithEvents DocNum As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelectCU_CarDr1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CU_CarDr1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
