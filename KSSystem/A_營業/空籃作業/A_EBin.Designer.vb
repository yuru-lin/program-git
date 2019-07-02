<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_EBin
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
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.ClearBtn = New System.Windows.Forms.Button
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CU_CarDr1 = New System.Windows.Forms.TextBox
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(12, 175)
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.Size = New System.Drawing.Size(710, 325)
        Me.dgvSourceMain.TabIndex = 121
        '
        'ClearBtn
        '
        Me.ClearBtn.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ClearBtn.Location = New System.Drawing.Point(487, 147)
        Me.ClearBtn.Name = "ClearBtn"
        Me.ClearBtn.Size = New System.Drawing.Size(80, 22)
        Me.ClearBtn.TabIndex = 119
        Me.ClearBtn.Text = "全部清除"
        Me.ClearBtn.UseVisualStyleBackColor = True
        '
        'SendBtn
        '
        Me.SendBtn.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SendBtn.Location = New System.Drawing.Point(626, 147)
        Me.SendBtn.Name = "SendBtn"
        Me.SendBtn.Size = New System.Drawing.Size(80, 22)
        Me.SendBtn.TabIndex = 118
        Me.SendBtn.Text = "存檔"
        Me.SendBtn.UseVisualStyleBackColor = True
        '
        'U_CarDr1
        '
        Me.U_CarDr1.FormattingEnabled = True
        Me.U_CarDr1.Location = New System.Drawing.Point(338, 91)
        Me.U_CarDr1.Name = "U_CarDr1"
        Me.U_CarDr1.Size = New System.Drawing.Size(135, 20)
        Me.U_CarDr1.TabIndex = 117
        '
        'AddID
        '
        Me.AddID.Enabled = False
        Me.AddID.FormattingEnabled = True
        Me.AddID.Location = New System.Drawing.Point(338, 65)
        Me.AddID.Name = "AddID"
        Me.AddID.Size = New System.Drawing.Size(135, 20)
        Me.AddID.TabIndex = 116
        '
        'CardCode
        '
        Me.CardCode.FormattingEnabled = True
        Me.CardCode.Location = New System.Drawing.Point(103, 65)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(135, 20)
        Me.CardCode.TabIndex = 115
        '
        'DocDate
        '
        Me.DocDate.Location = New System.Drawing.Point(338, 37)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(135, 22)
        Me.DocDate.TabIndex = 114
        '
        'Descr
        '
        Me.Descr.Location = New System.Drawing.Point(103, 119)
        Me.Descr.Name = "Descr"
        Me.Descr.Size = New System.Drawing.Size(603, 22)
        Me.Descr.TabIndex = 113
        '
        'Bonus
        '
        Me.Bonus.Location = New System.Drawing.Point(571, 93)
        Me.Bonus.Name = "Bonus"
        Me.Bonus.Size = New System.Drawing.Size(135, 22)
        Me.Bonus.TabIndex = 112
        '
        'InNum
        '
        Me.InNum.Location = New System.Drawing.Point(571, 65)
        Me.InNum.Name = "InNum"
        Me.InNum.Size = New System.Drawing.Size(135, 22)
        Me.InNum.TabIndex = 111
        '
        'DocNum
        '
        Me.DocNum.Location = New System.Drawing.Point(103, 37)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.Size = New System.Drawing.Size(135, 22)
        Me.DocNum.TabIndex = 110
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label10.Location = New System.Drawing.Point(41, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "說明："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label9.Location = New System.Drawing.Point(479, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "特殊獎金："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(479, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "回收數量："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(244, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "司機姓名："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label6.Location = New System.Drawing.Point(244, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "客戶簡稱："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(9, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "客戶編號："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(244, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "回收日期："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "回收單號："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(334, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 24)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "回收單作業"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(9, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "司機編號："
        Me.Label2.Visible = False
        '
        'CU_CarDr1
        '
        Me.CU_CarDr1.Enabled = False
        Me.CU_CarDr1.Location = New System.Drawing.Point(103, 91)
        Me.CU_CarDr1.Name = "CU_CarDr1"
        Me.CU_CarDr1.Size = New System.Drawing.Size(135, 22)
        Me.CU_CarDr1.TabIndex = 123
        Me.CU_CarDr1.Visible = False
        '
        'A_EBin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 512)
        Me.Controls.Add(Me.CU_CarDr1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.ClearBtn)
        Me.Controls.Add(Me.SendBtn)
        Me.Controls.Add(Me.U_CarDr1)
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
        Me.Controls.Add(Me.Label3)
        Me.Name = "A_EBin"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "回收單作業"
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents ClearBtn As System.Windows.Forms.Button
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CU_CarDr1 As System.Windows.Forms.TextBox
End Class
