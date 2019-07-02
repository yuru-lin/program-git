<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 代工轉入生產
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
        Me.bu讀取 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.La張數 = New System.Windows.Forms.Label
        Me.La筆數1 = New System.Windows.Forms.Label
        Me.Bu存入 = New System.Windows.Forms.Button
        Me.La單號 = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.La筆數2 = New System.Windows.Forms.Label
        Me.Bu入庫 = New System.Windows.Forms.Button
        Me.Bu出庫 = New System.Windows.Forms.Button
        Me.出庫單號1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.出庫單號2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bu讀取
        '
        Me.bu讀取.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.bu讀取.Location = New System.Drawing.Point(566, 12)
        Me.bu讀取.Name = "bu讀取"
        Me.bu讀取.Size = New System.Drawing.Size(87, 35)
        Me.bu讀取.TabIndex = 25
        Me.bu讀取.Text = "讀取Excel"
        Me.bu讀取.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 12)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(548, 202)
        Me.DGV1.TabIndex = 26
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(12, 220)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersVisible = False
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(761, 390)
        Me.DGV2.TabIndex = 27
        '
        'La張數
        '
        Me.La張數.AutoSize = True
        Me.La張數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La張數.Location = New System.Drawing.Point(566, 198)
        Me.La張數.Name = "La張數"
        Me.La張數.Size = New System.Drawing.Size(40, 16)
        Me.La張數.TabIndex = 28
        Me.La張數.Text = "張數"
        '
        'La筆數1
        '
        Me.La筆數1.AutoSize = True
        Me.La筆數1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La筆數1.Location = New System.Drawing.Point(677, 198)
        Me.La筆數1.Name = "La筆數1"
        Me.La筆數1.Size = New System.Drawing.Size(40, 16)
        Me.La筆數1.TabIndex = 29
        Me.La筆數1.Text = "筆數"
        '
        'Bu存入
        '
        Me.Bu存入.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu存入.Location = New System.Drawing.Point(835, 12)
        Me.Bu存入.Name = "Bu存入"
        Me.Bu存入.Size = New System.Drawing.Size(87, 35)
        Me.Bu存入.TabIndex = 30
        Me.Bu存入.Text = "存入生產"
        Me.Bu存入.UseVisualStyleBackColor = True
        '
        'La單號
        '
        Me.La單號.AutoSize = True
        Me.La單號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La單號.Location = New System.Drawing.Point(566, 65)
        Me.La單號.Name = "La單號"
        Me.La單號.Size = New System.Drawing.Size(40, 16)
        Me.La單號.TabIndex = 31
        Me.La單號.Text = "單號"
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(779, 220)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowHeadersVisible = False
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(143, 390)
        Me.DGV3.TabIndex = 32
        '
        'La筆數2
        '
        Me.La筆數2.AutoSize = True
        Me.La筆數2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.La筆數2.Location = New System.Drawing.Point(826, 198)
        Me.La筆數2.Name = "La筆數2"
        Me.La筆數2.Size = New System.Drawing.Size(40, 16)
        Me.La筆數2.TabIndex = 33
        Me.La筆數2.Text = "筆數"
        '
        'Bu入庫
        '
        Me.Bu入庫.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu入庫.Location = New System.Drawing.Point(835, 76)
        Me.Bu入庫.Name = "Bu入庫"
        Me.Bu入庫.Size = New System.Drawing.Size(87, 35)
        Me.Bu入庫.TabIndex = 34
        Me.Bu入庫.Text = "存入入庫"
        Me.Bu入庫.UseVisualStyleBackColor = True
        '
        'Bu出庫
        '
        Me.Bu出庫.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu出庫.Location = New System.Drawing.Point(835, 135)
        Me.Bu出庫.Name = "Bu出庫"
        Me.Bu出庫.Size = New System.Drawing.Size(87, 35)
        Me.Bu出庫.TabIndex = 35
        Me.Bu出庫.Text = "存入出庫"
        Me.Bu出庫.UseVisualStyleBackColor = True
        '
        '出庫單號1
        '
        Me.出庫單號1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.出庫單號1.Location = New System.Drawing.Point(701, 125)
        Me.出庫單號1.Name = "出庫單號1"
        Me.出庫單號1.Size = New System.Drawing.Size(128, 33)
        Me.出庫單號1.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(601, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 21)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "交貨單號"
        '
        '出庫單號2
        '
        Me.出庫單號2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.出庫單號2.Location = New System.Drawing.Point(701, 162)
        Me.出庫單號2.Name = "出庫單號2"
        Me.出庫單號2.Size = New System.Drawing.Size(128, 33)
        Me.出庫單號2.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(601, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 21)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "領料單號"
        '
        '代工轉入生產
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 622)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.出庫單號2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.出庫單號1)
        Me.Controls.Add(Me.Bu出庫)
        Me.Controls.Add(Me.Bu入庫)
        Me.Controls.Add(Me.La筆數2)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.La單號)
        Me.Controls.Add(Me.Bu存入)
        Me.Controls.Add(Me.La筆數1)
        Me.Controls.Add(Me.La張數)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.bu讀取)
        Me.Name = "代工轉入生產"
        Me.Text = "代工轉入生產"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bu讀取 As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents La張數 As System.Windows.Forms.Label
    Friend WithEvents La筆數1 As System.Windows.Forms.Label
    Friend WithEvents Bu存入 As System.Windows.Forms.Button
    Friend WithEvents La單號 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents La筆數2 As System.Windows.Forms.Label
    Friend WithEvents Bu入庫 As System.Windows.Forms.Button
    Friend WithEvents Bu出庫 As System.Windows.Forms.Button
    Friend WithEvents 出庫單號1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 出庫單號2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
