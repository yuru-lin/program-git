<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_UpdateEBadjust
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
        Me.btnSearch = New System.Windows.Forms.Button
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.SelectDocDate = New System.Windows.Forms.DateTimePicker
        Me.SelectDocNum = New System.Windows.Forms.TextBox
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.IncDec = New System.Windows.Forms.ComboBox
        Me.Descr = New System.Windows.Forms.TextBox
        Me.AmtNum = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SendBtn = New System.Windows.Forms.Button
        Me.AddID = New System.Windows.Forms.ComboBox
        Me.CardCode = New System.Windows.Forms.ComboBox
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.DocNum = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(468, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 136
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(245, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox2.TabIndex = 134
        Me.CheckBox2.Text = "回收單號："
        Me.CheckBox2.UseVisualStyleBackColor = True
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
        Me.CheckBox1.TabIndex = 133
        Me.CheckBox1.Text = "回收日期："
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'SelectDocDate
        '
        Me.SelectDocDate.Location = New System.Drawing.Point(119, 11)
        Me.SelectDocDate.Name = "SelectDocDate"
        Me.SelectDocDate.Size = New System.Drawing.Size(110, 22)
        Me.SelectDocDate.TabIndex = 131
        '
        'SelectDocNum
        '
        Me.SelectDocNum.Location = New System.Drawing.Point(352, 11)
        Me.SelectDocNum.Name = "SelectDocNum"
        Me.SelectDocNum.Size = New System.Drawing.Size(110, 22)
        Me.SelectDocNum.TabIndex = 130
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(12, 40)
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSourceMain.Size = New System.Drawing.Size(710, 308)
        Me.dgvSourceMain.TabIndex = 137
        '
        'IncDec
        '
        Me.IncDec.FormattingEnabled = True
        Me.IncDec.Items.AddRange(New Object() {"增加", "減少"})
        Me.IncDec.Location = New System.Drawing.Point(229, 423)
        Me.IncDec.Name = "IncDec"
        Me.IncDec.Size = New System.Drawing.Size(135, 20)
        Me.IncDec.TabIndex = 152
        '
        'Descr
        '
        Me.Descr.Location = New System.Drawing.Point(229, 456)
        Me.Descr.Name = "Descr"
        Me.Descr.Size = New System.Drawing.Size(361, 22)
        Me.Descr.TabIndex = 151
        '
        'AmtNum
        '
        Me.AmtNum.Location = New System.Drawing.Point(456, 423)
        Me.AmtNum.Name = "AmtNum"
        Me.AmtNum.Size = New System.Drawing.Size(135, 22)
        Me.AmtNum.TabIndex = 150
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(143, 459)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 149
        Me.Label10.Text = "調整原因："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(402, 425)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 148
        Me.Label9.Text = "數量："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(175, 425)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "增減："
        '
        'SendBtn
        '
        Me.SendBtn.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SendBtn.Location = New System.Drawing.Point(647, 478)
        Me.SendBtn.Name = "SendBtn"
        Me.SendBtn.Size = New System.Drawing.Size(80, 22)
        Me.SendBtn.TabIndex = 146
        Me.SendBtn.Text = "送出"
        Me.SendBtn.UseVisualStyleBackColor = True
        '
        'AddID
        '
        Me.AddID.Enabled = False
        Me.AddID.FormattingEnabled = True
        Me.AddID.Location = New System.Drawing.Point(456, 389)
        Me.AddID.Name = "AddID"
        Me.AddID.Size = New System.Drawing.Size(135, 20)
        Me.AddID.TabIndex = 145
        '
        'CardCode
        '
        Me.CardCode.FormattingEnabled = True
        Me.CardCode.Location = New System.Drawing.Point(229, 389)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(135, 20)
        Me.CardCode.TabIndex = 144
        '
        'DocDate
        '
        Me.DocDate.Enabled = False
        Me.DocDate.Location = New System.Drawing.Point(456, 354)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(135, 22)
        Me.DocDate.TabIndex = 143
        '
        'DocNum
        '
        Me.DocNum.Location = New System.Drawing.Point(229, 354)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.Size = New System.Drawing.Size(135, 22)
        Me.DocNum.TabIndex = 142
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(370, 391)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "客戶簡稱："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(143, 391)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "客戶編號："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(370, 357)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "回收日期："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(143, 357)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "回收單號："
        '
        'A_UpdateEBadjust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 512)
        Me.Controls.Add(Me.IncDec)
        Me.Controls.Add(Me.Descr)
        Me.Controls.Add(Me.AmtNum)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SendBtn)
        Me.Controls.Add(Me.AddID)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.DocNum)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.SelectDocDate)
        Me.Controls.Add(Me.SelectDocNum)
        Me.Name = "A_UpdateEBadjust"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "調整單修改"
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents SelectDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SelectDocNum As System.Windows.Forms.TextBox
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents IncDec As System.Windows.Forms.ComboBox
    Friend WithEvents Descr As System.Windows.Forms.TextBox
    Friend WithEvents AmtNum As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SendBtn As System.Windows.Forms.Button
    Friend WithEvents AddID As System.Windows.Forms.ComboBox
    Friend WithEvents CardCode As System.Windows.Forms.ComboBox
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DocNum As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
