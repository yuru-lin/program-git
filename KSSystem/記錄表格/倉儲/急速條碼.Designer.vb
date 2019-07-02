<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 急速條碼
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
        Me.F01s = New System.Windows.Forms.Label
        Me.F01s中 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.DGV1 = New System.Windows.Forms.DataGridView
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'F01s
        '
        Me.F01s.AutoSize = True
        Me.F01s.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.F01s.Location = New System.Drawing.Point(398, 9)
        Me.F01s.Name = "F01s"
        Me.F01s.Size = New System.Drawing.Size(88, 16)
        Me.F01s.TabIndex = 0
        Me.F01s.Text = "急速庫儲位"
        Me.F01s.Visible = False
        '
        'F01s中
        '
        Me.F01s中.AutoSize = True
        Me.F01s中.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.F01s中.Location = New System.Drawing.Point(278, 9)
        Me.F01s中.Name = "F01s中"
        Me.F01s中.Size = New System.Drawing.Size(114, 16)
        Me.F01s中.TabIndex = 1
        Me.F01s中.Text = "急速庫儲位(中)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(212, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "急速庫："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "日期："
        '
        'DocDate
        '
        Me.DocDate.Enabled = False
        Me.DocDate.Location = New System.Drawing.Point(66, 5)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(140, 22)
        Me.DocDate.TabIndex = 4
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeColumns = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(3, 39)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(811, 487)
        Me.DGV1.TabIndex = 6
        '
        '急速條碼
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 532)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.F01s中)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.F01s)
        Me.Name = "急速條碼"
        Me.Text = "急速條碼"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents F01s As System.Windows.Forms.Label
    Friend WithEvents F01s中 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
End Class
