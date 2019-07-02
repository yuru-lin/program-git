<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QueryChangeSpace
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
        Me.LocCode = New System.Windows.Forms.TextBox
        Me.cbxLocCode = New System.Windows.Forms.CheckBox
        Me.ItemCode = New System.Windows.Forms.TextBox
        Me.cbxItemCode = New System.Windows.Forms.CheckBox
        Me.cbxDoc = New System.Windows.Forms.CheckBox
        Me.cbxDate = New System.Windows.Forms.CheckBox
        Me.DTP1 = New System.Windows.Forms.DateTimePicker
        Me.DTP2 = New System.Windows.Forms.DateTimePicker
        Me.TxtBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnExl2 = New System.Windows.Forms.Button
        Me.BtnExl1 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.QuyBtn = New System.Windows.Forms.Button
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LocCode
        '
        Me.LocCode.Location = New System.Drawing.Point(363, 37)
        Me.LocCode.Name = "LocCode"
        Me.LocCode.Size = New System.Drawing.Size(100, 22)
        Me.LocCode.TabIndex = 40
        '
        'cbxLocCode
        '
        Me.cbxLocCode.AutoSize = True
        Me.cbxLocCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cbxLocCode.Location = New System.Drawing.Point(256, 38)
        Me.cbxLocCode.Name = "cbxLocCode"
        Me.cbxLocCode.Size = New System.Drawing.Size(107, 20)
        Me.cbxLocCode.TabIndex = 39
        Me.cbxLocCode.Text = "目的儲位："
        Me.cbxLocCode.UseVisualStyleBackColor = True
        '
        'ItemCode
        '
        Me.ItemCode.Location = New System.Drawing.Point(150, 36)
        Me.ItemCode.Name = "ItemCode"
        Me.ItemCode.Size = New System.Drawing.Size(100, 22)
        Me.ItemCode.TabIndex = 38
        '
        'cbxItemCode
        '
        Me.cbxItemCode.AutoSize = True
        Me.cbxItemCode.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cbxItemCode.Location = New System.Drawing.Point(45, 37)
        Me.cbxItemCode.Name = "cbxItemCode"
        Me.cbxItemCode.Size = New System.Drawing.Size(107, 20)
        Me.cbxItemCode.TabIndex = 37
        Me.cbxItemCode.Text = "存貨編號："
        Me.cbxItemCode.UseVisualStyleBackColor = True
        '
        'cbxDoc
        '
        Me.cbxDoc.AutoSize = True
        Me.cbxDoc.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cbxDoc.Location = New System.Drawing.Point(464, 11)
        Me.cbxDoc.Name = "cbxDoc"
        Me.cbxDoc.Size = New System.Drawing.Size(107, 20)
        Me.cbxDoc.TabIndex = 36
        Me.cbxDoc.Text = "調整單號："
        Me.cbxDoc.UseVisualStyleBackColor = True
        '
        'cbxDate
        '
        Me.cbxDate.AutoSize = True
        Me.cbxDate.Checked = True
        Me.cbxDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxDate.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.cbxDate.Location = New System.Drawing.Point(45, 11)
        Me.cbxDate.Name = "cbxDate"
        Me.cbxDate.Size = New System.Drawing.Size(123, 20)
        Me.cbxDate.TabIndex = 35
        Me.cbxDate.Text = "請選擇期間："
        Me.cbxDate.UseVisualStyleBackColor = True
        '
        'DTP1
        '
        Me.DTP1.Location = New System.Drawing.Point(170, 10)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(130, 22)
        Me.DTP1.TabIndex = 26
        '
        'DTP2
        '
        Me.DTP2.Location = New System.Drawing.Point(328, 10)
        Me.DTP2.Name = "DTP2"
        Me.DTP2.Size = New System.Drawing.Size(130, 22)
        Me.DTP2.TabIndex = 27
        '
        'TxtBox1
        '
        Me.TxtBox1.Location = New System.Drawing.Point(571, 10)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.Size = New System.Drawing.Size(100, 22)
        Me.TxtBox1.TabIndex = 34
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(302, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "至"
        '
        'BtnExl2
        '
        Me.BtnExl2.Location = New System.Drawing.Point(697, 529)
        Me.BtnExl2.Name = "BtnExl2"
        Me.BtnExl2.Size = New System.Drawing.Size(75, 23)
        Me.BtnExl2.TabIndex = 33
        Me.BtnExl2.Text = "匯出Excel"
        Me.BtnExl2.UseVisualStyleBackColor = True
        '
        'BtnExl1
        '
        Me.BtnExl1.Location = New System.Drawing.Point(697, 250)
        Me.BtnExl1.Name = "BtnExl1"
        Me.BtnExl1.Size = New System.Drawing.Size(75, 23)
        Me.BtnExl1.TabIndex = 32
        Me.BtnExl1.Text = "匯出Excel"
        Me.BtnExl1.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(12, 279)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(760, 244)
        Me.DGV2.TabIndex = 30
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 66)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(760, 178)
        Me.DGV1.TabIndex = 29
        '
        'QuyBtn
        '
        Me.QuyBtn.Location = New System.Drawing.Point(697, 37)
        Me.QuyBtn.Name = "QuyBtn"
        Me.QuyBtn.Size = New System.Drawing.Size(75, 23)
        Me.QuyBtn.TabIndex = 25
        Me.QuyBtn.Text = "查詢"
        Me.QuyBtn.UseVisualStyleBackColor = True
        '
        'C_QueryChangeSpace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.LocCode)
        Me.Controls.Add(Me.cbxLocCode)
        Me.Controls.Add(Me.ItemCode)
        Me.Controls.Add(Me.cbxItemCode)
        Me.Controls.Add(Me.cbxDoc)
        Me.Controls.Add(Me.cbxDate)
        Me.Controls.Add(Me.DTP1)
        Me.Controls.Add(Me.DTP2)
        Me.Controls.Add(Me.TxtBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnExl2)
        Me.Controls.Add(Me.BtnExl1)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.QuyBtn)
        Me.Name = "C_QueryChangeSpace"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "儲位變更查詢"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LocCode As System.Windows.Forms.TextBox
    Friend WithEvents cbxLocCode As System.Windows.Forms.CheckBox
    Friend WithEvents ItemCode As System.Windows.Forms.TextBox
    Friend WithEvents cbxItemCode As System.Windows.Forms.CheckBox
    Friend WithEvents cbxDoc As System.Windows.Forms.CheckBox
    Friend WithEvents cbxDate As System.Windows.Forms.CheckBox
    Friend WithEvents DTP1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnExl2 As System.Windows.Forms.Button
    Friend WithEvents BtnExl1 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents QuyBtn As System.Windows.Forms.Button
End Class
