<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 指定入庫
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
        Me.BtnExl1 = New System.Windows.Forms.Button
        Me.BtnExl2 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.QuyBtn = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnExl1
        '
        Me.BtnExl1.Location = New System.Drawing.Point(220, 527)
        Me.BtnExl1.Name = "BtnExl1"
        Me.BtnExl1.Size = New System.Drawing.Size(75, 23)
        Me.BtnExl1.TabIndex = 21
        Me.BtnExl1.Text = "匯出Excel"
        Me.BtnExl1.UseVisualStyleBackColor = True
        '
        'BtnExl2
        '
        Me.BtnExl2.Location = New System.Drawing.Point(732, 527)
        Me.BtnExl2.Name = "BtnExl2"
        Me.BtnExl2.Size = New System.Drawing.Size(75, 23)
        Me.BtnExl2.TabIndex = 19
        Me.BtnExl2.Text = "匯出Excel"
        Me.BtnExl2.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(301, 40)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 20
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(506, 481)
        Me.DGV2.TabIndex = 18
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(5, 40)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 20
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(290, 481)
        Me.DGV1.TabIndex = 17
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(242, 12)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(126, 22)
        Me.FromDate.TabIndex = 16
        '
        'QuyBtn
        '
        Me.QuyBtn.Location = New System.Drawing.Point(392, 12)
        Me.QuyBtn.Name = "QuyBtn"
        Me.QuyBtn.Size = New System.Drawing.Size(75, 23)
        Me.QuyBtn.TabIndex = 15
        Me.QuyBtn.Text = "查詢"
        Me.QuyBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "請輸入日期："
        '
        'C_QuerySuggestWplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 562)
        Me.Controls.Add(Me.BtnExl1)
        Me.Controls.Add(Me.BtnExl2)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.QuyBtn)
        Me.Controls.Add(Me.Label1)
        Me.Name = "C_QuerySuggestWplace"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "指定入庫建議儲位查詢"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnExl1 As System.Windows.Forms.Button
    Friend WithEvents BtnExl2 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents QuyBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
