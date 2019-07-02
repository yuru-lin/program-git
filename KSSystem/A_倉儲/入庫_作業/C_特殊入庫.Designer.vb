<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_特殊入庫
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnToB1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.btnReadExcel = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.lb2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lb0 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.locView = New System.Windows.Forms.DataGridView
        Me.Label10 = New System.Windows.Forms.Label
        Me.cobSelectType = New System.Windows.Forms.ComboBox
        Me.tbxWhsCode = New System.Windows.Forms.TextBox
        Me.ckbWhs = New System.Windows.Forms.CheckBox
        Me.U_CK02 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.btnForError = New System.Windows.Forms.Button
        CType(Me.locView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(646, 411)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 52)
        Me.Label12.TabIndex = 167
        Me.Label12.Text = "紅色：沒有該61存編" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "黃色：存編開頭為25" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "綠色：存編開頭為31" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "藍色：存編非25和31"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(385, 477)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 12)
        Me.Label9.TabIndex = 165
        Me.Label9.Text = "過帳日期："
        '
        'DocDate
        '
        Me.DocDate.Location = New System.Drawing.Point(450, 472)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(120, 22)
        Me.DocDate.TabIndex = 164
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(283, 379)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(267, 16)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "*目前只能使用序號入庫!批號不行!"
        '
        'btnToB1
        '
        Me.btnToB1.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.btnToB1.Location = New System.Drawing.Point(682, 488)
        Me.btnToB1.Name = "btnToB1"
        Me.btnToB1.Size = New System.Drawing.Size(87, 35)
        Me.btnToB1.TabIndex = 162
        Me.btnToB1.Text = "回存B1"
        Me.btnToB1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(627, 391)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "錯誤條碼"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(16, 379)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(261, 16)
        Me.Label4.TabIndex = 160
        Me.Label4.Text = "*請記得將Excel第一列的中文移除"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(151, 437)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 64)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "第六欄：製造日期" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第七欄：有效日期" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第八欄：儲位" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第九欄：客戶代碼"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(19, 421)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 80)
        Me.Label1.TabIndex = 158
        Me.Label1.Text = "第一欄：製造單號" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第二欄：存編" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第三欄：品名" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第四欄：重量" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第五欄：條碼"
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(16, 529)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(753, 23)
        Me.PBar1.TabIndex = 157
        '
        'btnReadExcel
        '
        Me.btnReadExcel.Location = New System.Drawing.Point(589, 488)
        Me.btnReadExcel.Name = "btnReadExcel"
        Me.btnReadExcel.Size = New System.Drawing.Size(87, 35)
        Me.btnReadExcel.TabIndex = 154
        Me.btnReadExcel.Text = "讀取Excel"
        Me.btnReadExcel.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(752, 391)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(17, 12)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "項"
        '
        'lb2
        '
        Me.lb2.AutoSize = True
        Me.lb2.Location = New System.Drawing.Point(724, 391)
        Me.lb2.Name = "lb2"
        Me.lb2.Size = New System.Drawing.Size(11, 12)
        Me.lb2.TabIndex = 152
        Me.lb2.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(686, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 12)
        Me.Label13.TabIndex = 151
        Me.Label13.Text = "共"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(752, 379)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "項"
        '
        'lb0
        '
        Me.lb0.AutoSize = True
        Me.lb0.Location = New System.Drawing.Point(724, 379)
        Me.lb0.Name = "lb0"
        Me.lb0.Size = New System.Drawing.Size(11, 12)
        Me.lb0.TabIndex = 149
        Me.lb0.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(686, 379)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "共"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 402)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 16)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Excel欄位分別為："
        '
        'locView
        '
        Me.locView.AllowUserToAddRows = False
        Me.locView.AllowUserToDeleteRows = False
        Me.locView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locView.Location = New System.Drawing.Point(12, 12)
        Me.locView.Name = "locView"
        Me.locView.ReadOnly = True
        Me.locView.RowTemplate.Height = 24
        Me.locView.Size = New System.Drawing.Size(760, 363)
        Me.locView.TabIndex = 156
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(385, 425)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 12)
        Me.Label10.TabIndex = 169
        Me.Label10.Text = "收貨類型："
        '
        'cobSelectType
        '
        Me.cobSelectType.FormattingEnabled = True
        Me.cobSelectType.Items.AddRange(New Object() {"寄庫品收貨", "生產退料"})
        Me.cobSelectType.Location = New System.Drawing.Point(450, 421)
        Me.cobSelectType.Name = "cobSelectType"
        Me.cobSelectType.Size = New System.Drawing.Size(120, 20)
        Me.cobSelectType.TabIndex = 168
        '
        'tbxWhsCode
        '
        Me.tbxWhsCode.Location = New System.Drawing.Point(450, 500)
        Me.tbxWhsCode.Name = "tbxWhsCode"
        Me.tbxWhsCode.Size = New System.Drawing.Size(120, 22)
        Me.tbxWhsCode.TabIndex = 171
        Me.tbxWhsCode.Text = "P01"
        '
        'ckbWhs
        '
        Me.ckbWhs.AutoSize = True
        Me.ckbWhs.Location = New System.Drawing.Point(366, 503)
        Me.ckbWhs.Name = "ckbWhs"
        Me.ckbWhs.Size = New System.Drawing.Size(84, 16)
        Me.ckbWhs.TabIndex = 170
        Me.ckbWhs.Text = "指定庫別："
        Me.ckbWhs.UseVisualStyleBackColor = True
        '
        'U_CK02
        '
        Me.U_CK02.Location = New System.Drawing.Point(450, 446)
        Me.U_CK02.Name = "U_CK02"
        Me.U_CK02.Size = New System.Drawing.Size(120, 22)
        Me.U_CK02.TabIndex = 173
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(384, 451)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 12)
        Me.Label14.TabIndex = 172
        Me.Label14.Text = "製造單號："
        '
        'btnForError
        '
        Me.btnForError.Location = New System.Drawing.Point(16, 504)
        Me.btnForError.Name = "btnForError"
        Me.btnForError.Size = New System.Drawing.Size(92, 23)
        Me.btnForError.TabIndex = 174
        Me.btnForError.Text = "重新更新條碼重量"
        Me.btnForError.UseVisualStyleBackColor = True
        Me.btnForError.Visible = False
        '
        'C_InB1BySpecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.btnForError)
        Me.Controls.Add(Me.U_CK02)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.tbxWhsCode)
        Me.Controls.Add(Me.ckbWhs)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cobSelectType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnToB1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.btnReadExcel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lb2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb0)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.locView)
        Me.Name = "C_InB1BySpecial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "特殊入庫"
        CType(Me.locView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnToB1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnReadExcel As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lb2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lb0 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents locView As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cobSelectType As System.Windows.Forms.ComboBox
    Friend WithEvents tbxWhsCode As System.Windows.Forms.TextBox
    Friend WithEvents ckbWhs As System.Windows.Forms.CheckBox
    Friend WithEvents U_CK02 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnForError As System.Windows.Forms.Button
End Class
