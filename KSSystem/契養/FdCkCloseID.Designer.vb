<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FdCkCloseID
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.FdCkCloseIDGV = New System.Windows.Forms.DataGridView
        Me.FdCkCloseIDSelectBtn = New System.Windows.Forms.Button
        CType(Me.FdCkCloseIDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "請選擇契養戶："
        '
        'FdCkCloseIDGV
        '
        Me.FdCkCloseIDGV.AllowUserToAddRows = False
        Me.FdCkCloseIDGV.AllowUserToDeleteRows = False
        Me.FdCkCloseIDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FdCkCloseIDGV.Location = New System.Drawing.Point(10, 40)
        Me.FdCkCloseIDGV.Name = "FdCkCloseIDGV"
        Me.FdCkCloseIDGV.ReadOnly = True
        Me.FdCkCloseIDGV.RowHeadersVisible = False
        Me.FdCkCloseIDGV.RowTemplate.Height = 24
        Me.FdCkCloseIDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.FdCkCloseIDGV.Size = New System.Drawing.Size(357, 243)
        Me.FdCkCloseIDGV.TabIndex = 12
        '
        'FdCkCloseIDSelectBtn
        '
        Me.FdCkCloseIDSelectBtn.Location = New System.Drawing.Point(294, 289)
        Me.FdCkCloseIDSelectBtn.Name = "FdCkCloseIDSelectBtn"
        Me.FdCkCloseIDSelectBtn.Size = New System.Drawing.Size(75, 23)
        Me.FdCkCloseIDSelectBtn.TabIndex = 13
        Me.FdCkCloseIDSelectBtn.Text = "選擇"
        Me.FdCkCloseIDSelectBtn.UseVisualStyleBackColor = True
        '
        'FdCkCloseID
        '
        Me.AccessibleName = "S"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 320)
        Me.Controls.Add(Me.FdCkCloseIDSelectBtn)
        Me.Controls.Add(Me.FdCkCloseIDGV)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FdCkCloseID"
        Me.Text = "FdCkCloseID"
        CType(Me.FdCkCloseIDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FdCkCloseIDGV As System.Windows.Forms.DataGridView
    Friend WithEvents FdCkCloseIDSelectBtn As System.Windows.Forms.Button
End Class
