<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001檢查記錄
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
        Me.日期1 = New System.Windows.Forms.DateTimePicker
        Me.日期2 = New System.Windows.Forms.DateTimePicker
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.查詢 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '日期1
        '
        Me.日期1.CalendarFont = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期1.Location = New System.Drawing.Point(94, 15)
        Me.日期1.Name = "日期1"
        Me.日期1.Size = New System.Drawing.Size(155, 27)
        Me.日期1.TabIndex = 0
        '
        '日期2
        '
        Me.日期2.CalendarFont = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期2.Location = New System.Drawing.Point(293, 15)
        Me.日期2.Name = "日期2"
        Me.日期2.Size = New System.Drawing.Size(155, 27)
        Me.日期2.TabIndex = 1
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(16, 58)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(916, 611)
        Me.DGV1.TabIndex = 2
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(476, 7)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(84, 42)
        Me.查詢.TabIndex = 3
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 21)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "日期："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(255, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "至"
        '
        'v001檢查記錄
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 681)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.日期2)
        Me.Controls.Add(Me.日期1)
        Me.Name = "v001檢查記錄"
        Me.Text = "檢查記錄"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
