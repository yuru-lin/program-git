<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectItem
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
        Me.FinalSelectBtn = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGVName = New System.Windows.Forms.DataGridView
        CType(Me.DGVName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FinalSelectBtn
        '
        Me.FinalSelectBtn.Location = New System.Drawing.Point(247, 279)
        Me.FinalSelectBtn.Name = "FinalSelectBtn"
        Me.FinalSelectBtn.Size = New System.Drawing.Size(75, 23)
        Me.FinalSelectBtn.TabIndex = 8
        Me.FinalSelectBtn.Text = "選擇"
        Me.FinalSelectBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "請選擇項目："
        '
        'DGVName
        '
        Me.DGVName.AllowUserToAddRows = False
        Me.DGVName.AllowUserToDeleteRows = False
        Me.DGVName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVName.Location = New System.Drawing.Point(12, 30)
        Me.DGVName.Name = "DGVName"
        Me.DGVName.ReadOnly = True
        Me.DGVName.RowHeadersVisible = False
        Me.DGVName.RowTemplate.Height = 24
        Me.DGVName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVName.Size = New System.Drawing.Size(310, 243)
        Me.DGVName.TabIndex = 6
        '
        'SelectItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 312)
        Me.Controls.Add(Me.FinalSelectBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGVName)
        Me.Name = "SelectItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "選擇項目"
        Me.TopMost = True
        CType(Me.DGVName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FinalSelectBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DGVName As System.Windows.Forms.DataGridView
End Class
