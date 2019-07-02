<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 薪資計算
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
        Me.月份 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.人事計算Bn = New System.Windows.Forms.Button
        Me.薪資計算Bn = New System.Windows.Forms.Button
        Me.全部計算Bn = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '月份
        '
        Me.月份.BackColor = System.Drawing.SystemColors.Window
        Me.月份.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.月份.Location = New System.Drawing.Point(119, 6)
        Me.月份.Margin = New System.Windows.Forms.Padding(4)
        Me.月份.Name = "月份"
        Me.月份.ReadOnly = True
        Me.月份.Size = New System.Drawing.Size(148, 27)
        Me.月份.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "計算月份："
        '
        '人事計算Bn
        '
        Me.人事計算Bn.Location = New System.Drawing.Point(301, 3)
        Me.人事計算Bn.Name = "人事計算Bn"
        Me.人事計算Bn.Size = New System.Drawing.Size(100, 33)
        Me.人事計算Bn.TabIndex = 2
        Me.人事計算Bn.Text = "人事計算"
        Me.人事計算Bn.UseVisualStyleBackColor = True
        '
        '薪資計算Bn
        '
        Me.薪資計算Bn.Location = New System.Drawing.Point(301, 42)
        Me.薪資計算Bn.Name = "薪資計算Bn"
        Me.薪資計算Bn.Size = New System.Drawing.Size(100, 33)
        Me.薪資計算Bn.TabIndex = 3
        Me.薪資計算Bn.Text = "薪資計算"
        Me.薪資計算Bn.UseVisualStyleBackColor = True
        '
        '全部計算Bn
        '
        Me.全部計算Bn.Location = New System.Drawing.Point(425, 3)
        Me.全部計算Bn.Name = "全部計算Bn"
        Me.全部計算Bn.Size = New System.Drawing.Size(100, 72)
        Me.全部計算Bn.TabIndex = 4
        Me.全部計算Bn.Text = "全部計算"
        Me.全部計算Bn.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(16, 96)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(509, 150)
        Me.DGV1.TabIndex = 5
        '
        '薪資計算
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 263)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.全部計算Bn)
        Me.Controls.Add(Me.薪資計算Bn)
        Me.Controls.Add(Me.人事計算Bn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.月份)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "薪資計算"
        Me.Text = "薪資計算"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 月份 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 人事計算Bn As System.Windows.Forms.Button
    Friend WithEvents 薪資計算Bn As System.Windows.Forms.Button
    Friend WithEvents 全部計算Bn As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
End Class
