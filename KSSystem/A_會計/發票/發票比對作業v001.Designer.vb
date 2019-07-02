<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 發票比對作業v001
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
        Me.Bu讀取上傳 = New System.Windows.Forms.Button
        Me.DGV比對 = New System.Windows.Forms.DataGridView
        Me.DGV上傳 = New System.Windows.Forms.DataGridView
        Me.DGV重覆 = New System.Windows.Forms.DataGridView
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.DGV未上傳 = New System.Windows.Forms.DataGridView
        CType(Me.DGV比對, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV上傳, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV重覆, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV未上傳, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bu讀取上傳
        '
        Me.Bu讀取上傳.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu讀取上傳.Location = New System.Drawing.Point(12, 12)
        Me.Bu讀取上傳.Name = "Bu讀取上傳"
        Me.Bu讀取上傳.Size = New System.Drawing.Size(115, 38)
        Me.Bu讀取上傳.TabIndex = 3
        Me.Bu讀取上傳.Text = "Excel讀取上傳"
        Me.Bu讀取上傳.UseVisualStyleBackColor = True
        '
        'DGV比對
        '
        Me.DGV比對.AllowUserToAddRows = False
        Me.DGV比對.AllowUserToDeleteRows = False
        Me.DGV比對.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV比對.Location = New System.Drawing.Point(11, 56)
        Me.DGV比對.MultiSelect = False
        Me.DGV比對.Name = "DGV比對"
        Me.DGV比對.ReadOnly = True
        Me.DGV比對.RowHeadersVisible = False
        Me.DGV比對.RowTemplate.Height = 24
        Me.DGV比對.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV比對.Size = New System.Drawing.Size(825, 569)
        Me.DGV比對.TabIndex = 1071
        '
        'DGV上傳
        '
        Me.DGV上傳.AllowUserToAddRows = False
        Me.DGV上傳.AllowUserToDeleteRows = False
        Me.DGV上傳.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV上傳.Location = New System.Drawing.Point(842, 1)
        Me.DGV上傳.MultiSelect = False
        Me.DGV上傳.Name = "DGV上傳"
        Me.DGV上傳.ReadOnly = True
        Me.DGV上傳.RowHeadersVisible = False
        Me.DGV上傳.RowTemplate.Height = 24
        Me.DGV上傳.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV上傳.Size = New System.Drawing.Size(330, 96)
        Me.DGV上傳.TabIndex = 1073
        Me.DGV上傳.Visible = False
        '
        'DGV重覆
        '
        Me.DGV重覆.AllowUserToAddRows = False
        Me.DGV重覆.AllowUserToDeleteRows = False
        Me.DGV重覆.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV重覆.Location = New System.Drawing.Point(840, 56)
        Me.DGV重覆.MultiSelect = False
        Me.DGV重覆.Name = "DGV重覆"
        Me.DGV重覆.ReadOnly = True
        Me.DGV重覆.RowHeadersVisible = False
        Me.DGV重覆.RowTemplate.Height = 24
        Me.DGV重覆.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV重覆.Size = New System.Drawing.Size(341, 274)
        Me.DGV重覆.TabIndex = 1074
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(219, 12)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(115, 38)
        Me.Bu查詢.TabIndex = 1075
        Me.Bu查詢.Text = "上次資料"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        'DGV未上傳
        '
        Me.DGV未上傳.AllowUserToAddRows = False
        Me.DGV未上傳.AllowUserToDeleteRows = False
        Me.DGV未上傳.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV未上傳.Location = New System.Drawing.Point(840, 336)
        Me.DGV未上傳.MultiSelect = False
        Me.DGV未上傳.Name = "DGV未上傳"
        Me.DGV未上傳.ReadOnly = True
        Me.DGV未上傳.RowHeadersVisible = False
        Me.DGV未上傳.RowTemplate.Height = 24
        Me.DGV未上傳.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV未上傳.Size = New System.Drawing.Size(341, 289)
        Me.DGV未上傳.TabIndex = 1076
        '
        '發票比對作業v001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 637)
        Me.Controls.Add(Me.DGV未上傳)
        Me.Controls.Add(Me.Bu查詢)
        Me.Controls.Add(Me.DGV重覆)
        Me.Controls.Add(Me.DGV上傳)
        Me.Controls.Add(Me.DGV比對)
        Me.Controls.Add(Me.Bu讀取上傳)
        Me.Name = "發票比對作業v001"
        Me.Text = "發票比對作業"
        CType(Me.DGV比對, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV上傳, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV重覆, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV未上傳, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bu讀取上傳 As System.Windows.Forms.Button
    Friend WithEvents DGV比對 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV上傳 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV重覆 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents DGV未上傳 As System.Windows.Forms.DataGridView
End Class
