<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_CalcBomNeeds
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
        Me.ClearBtn = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Quty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CalBtn = New System.Windows.Forms.Button
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.AddBtn = New System.Windows.Forms.Button
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.ToExcelBtn = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClearBtn
        '
        Me.ClearBtn.Location = New System.Drawing.Point(697, 527)
        Me.ClearBtn.Name = "ClearBtn"
        Me.ClearBtn.Size = New System.Drawing.Size(75, 23)
        Me.ClearBtn.TabIndex = 40
        Me.ClearBtn.Text = "清除全部"
        Me.ClearBtn.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "統計明細："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(395, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "品項明細："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "預計生產品項："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 50)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(370, 222)
        Me.DGV1.TabIndex = 34
        '
        'Quty
        '
        Me.Quty.Location = New System.Drawing.Point(521, 6)
        Me.Quty.Name = "Quty"
        Me.Quty.Size = New System.Drawing.Size(100, 22)
        Me.Quty.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(465, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "數量："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(237, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "產品說明："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "產品號碼："
        '
        'CalBtn
        '
        Me.CalBtn.Location = New System.Drawing.Point(693, 278)
        Me.CalBtn.Name = "CalBtn"
        Me.CalBtn.Size = New System.Drawing.Size(75, 23)
        Me.CalBtn.TabIndex = 29
        Me.CalBtn.Text = "計算"
        Me.CalBtn.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(15, 304)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(753, 217)
        Me.DGV3.TabIndex = 28
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(388, 50)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(380, 222)
        Me.DGV2.TabIndex = 27
        '
        'AddBtn
        '
        Me.AddBtn.Location = New System.Drawing.Point(627, 5)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(75, 23)
        Me.AddBtn.TabIndex = 26
        Me.AddBtn.Text = "新增"
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Location = New System.Drawing.Point(322, 6)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemNameTxt.TabIndex = 25
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Location = New System.Drawing.Point(93, 6)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemCodeTxt.TabIndex = 24
        '
        'ToExcelBtn
        '
        Me.ToExcelBtn.Location = New System.Drawing.Point(15, 527)
        Me.ToExcelBtn.Name = "ToExcelBtn"
        Me.ToExcelBtn.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn.TabIndex = 41
        Me.ToExcelBtn.Text = "匯出Excel"
        Me.ToExcelBtn.UseVisualStyleBackColor = True
        '
        'B_CalcBomNeeds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.ToExcelBtn)
        Me.Controls.Add(Me.ClearBtn)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Quty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CalBtn)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.AddBtn)
        Me.Name = "B_CalcBomNeeds"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生產需求計算"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClearBtn As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Quty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CalBtn As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents AddBtn As System.Windows.Forms.Button
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents ToExcelBtn As System.Windows.Forms.Button
End Class
