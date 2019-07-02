<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D_CostcoPayment
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
        Me.OutputBtn = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToTxt = New System.Windows.Forms.RichTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.FromTxt = New System.Windows.Forms.RichTextBox
        Me.InputTxtBtn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OutputBtn
        '
        Me.OutputBtn.Location = New System.Drawing.Point(897, 615)
        Me.OutputBtn.Name = "OutputBtn"
        Me.OutputBtn.Size = New System.Drawing.Size(75, 23)
        Me.OutputBtn.TabIndex = 47
        Me.OutputBtn.Text = "匯出文字檔"
        Me.OutputBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 339)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "應匯出資料："
        '
        'ToTxt
        '
        Me.ToTxt.Location = New System.Drawing.Point(12, 358)
        Me.ToTxt.Name = "ToTxt"
        Me.ToTxt.Size = New System.Drawing.Size(960, 251)
        Me.ToTxt.TabIndex = 45
        Me.ToTxt.Text = ""
        Me.ToTxt.WordWrap = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(136, 16)
        Me.Label15.TabIndex = 44
        Me.Label15.Text = "文字檔內容資料："
        '
        'FromTxt
        '
        Me.FromTxt.Location = New System.Drawing.Point(14, 81)
        Me.FromTxt.Name = "FromTxt"
        Me.FromTxt.Size = New System.Drawing.Size(960, 251)
        Me.FromTxt.TabIndex = 43
        Me.FromTxt.Text = ""
        Me.FromTxt.WordWrap = False
        '
        'InputTxtBtn
        '
        Me.InputTxtBtn.Location = New System.Drawing.Point(12, 24)
        Me.InputTxtBtn.Name = "InputTxtBtn"
        Me.InputTxtBtn.Size = New System.Drawing.Size(75, 23)
        Me.InputTxtBtn.TabIndex = 42
        Me.InputTxtBtn.Text = "匯入文字檔"
        Me.InputTxtBtn.UseVisualStyleBackColor = True
        '
        'D_CostcoPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.OutputBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToTxt)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.FromTxt)
        Me.Controls.Add(Me.InputTxtBtn)
        Me.Name = "D_CostcoPayment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "關貿請款"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OutputBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToTxt As System.Windows.Forms.RichTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents FromTxt As System.Windows.Forms.RichTextBox
    Friend WithEvents InputTxtBtn As System.Windows.Forms.Button
End Class
