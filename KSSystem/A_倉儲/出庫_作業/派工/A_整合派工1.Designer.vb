<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_整合派工作業
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
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.查詢草稿 = New System.Windows.Forms.Button
        Me.草稿單派工作業 = New System.Windows.Forms.Button
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(5, 319)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 23
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(950, 339)
        Me.DGV2.TabIndex = 97
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(5, 62)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 23
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(950, 251)
        Me.DGV1.TabIndex = 96
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"銷售出庫", "單據領料", "存貨領用", "寄庫出庫"})
        Me.ComboBox1.Location = New System.Drawing.Point(101, 7)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 24)
        Me.ComboBox1.TabIndex = 125
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(2, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 19)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "作業類別："
        '
        '查詢草稿
        '
        Me.查詢草稿.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢草稿.Location = New System.Drawing.Point(228, 6)
        Me.查詢草稿.Name = "查詢草稿"
        Me.查詢草稿.Size = New System.Drawing.Size(95, 25)
        Me.查詢草稿.TabIndex = 123
        Me.查詢草稿.Text = "查詢草稿"
        Me.查詢草稿.UseVisualStyleBackColor = True
        '
        '草稿單派工作業
        '
        Me.草稿單派工作業.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.草稿單派工作業.Location = New System.Drawing.Point(860, 6)
        Me.草稿單派工作業.Name = "草稿單派工作業"
        Me.草稿單派工作業.Size = New System.Drawing.Size(95, 50)
        Me.草稿單派工作業.TabIndex = 126
        Me.草稿單派工作業.Text = "草稿單" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "派工作業"
        Me.草稿單派工作業.UseVisualStyleBackColor = True
        '
        'A_整合派工作業
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 661)
        Me.Controls.Add(Me.草稿單派工作業)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.查詢草稿)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "A_整合派工作業"
        Me.Text = "整合派工作業"
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents 查詢草稿 As System.Windows.Forms.Button
    Friend WithEvents 草稿單派工作業 As System.Windows.Forms.Button
End Class
