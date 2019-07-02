<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_AddFinishItem
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
        Me.dgvFI1Main = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvFinishItem1 = New System.Windows.Forms.DataGridView
        Me.ExcelBtn = New System.Windows.Forms.Button
        Me.SaveBtn = New System.Windows.Forms.Button
        CType(Me.dgvFI1Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFinishItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFI1Main
        '
        Me.dgvFI1Main.AllowUserToAddRows = False
        Me.dgvFI1Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFI1Main.Location = New System.Drawing.Point(12, 28)
        Me.dgvFI1Main.Name = "dgvFI1Main"
        Me.dgvFI1Main.ReadOnly = True
        Me.dgvFI1Main.RowTemplate.Height = 24
        Me.dgvFI1Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFI1Main.Size = New System.Drawing.Size(520, 111)
        Me.dgvFI1Main.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "主檔 ："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "明細 ："
        '
        'dgvFinishItem1
        '
        Me.dgvFinishItem1.AllowUserToAddRows = False
        Me.dgvFinishItem1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinishItem1.Location = New System.Drawing.Point(12, 161)
        Me.dgvFinishItem1.Name = "dgvFinishItem1"
        Me.dgvFinishItem1.ReadOnly = True
        Me.dgvFinishItem1.RowTemplate.Height = 24
        Me.dgvFinishItem1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinishItem1.Size = New System.Drawing.Size(520, 205)
        Me.dgvFinishItem1.TabIndex = 36
        '
        'ExcelBtn
        '
        Me.ExcelBtn.Location = New System.Drawing.Point(15, 372)
        Me.ExcelBtn.Name = "ExcelBtn"
        Me.ExcelBtn.Size = New System.Drawing.Size(75, 23)
        Me.ExcelBtn.TabIndex = 37
        Me.ExcelBtn.Text = "讀取Excel"
        Me.ExcelBtn.UseVisualStyleBackColor = True
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(457, 372)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 41
        Me.SaveBtn.Text = "儲存"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'B_AddFinishItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 407)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.ExcelBtn)
        Me.Controls.Add(Me.dgvFinishItem1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvFI1Main)
        Me.Name = "B_AddFinishItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "委外代工生產明細回存"
        CType(Me.dgvFI1Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFinishItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvFI1Main As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvFinishItem1 As System.Windows.Forms.DataGridView
    Friend WithEvents ExcelBtn As System.Windows.Forms.Button
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
End Class
