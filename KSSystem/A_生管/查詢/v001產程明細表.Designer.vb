<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001產程明細表
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
        Me.查詢 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.製單類別 = New System.Windows.Forms.ComboBox
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        Me.列印 = New System.Windows.Forms.Button
        Me.匯出Excel = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '日期1
        '
        Me.日期1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期1.Location = New System.Drawing.Point(66, 21)
        Me.日期1.Name = "日期1"
        Me.日期1.Size = New System.Drawing.Size(157, 27)
        Me.日期1.TabIndex = 0
        '
        '日期2
        '
        Me.日期2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期2.Location = New System.Drawing.Point(253, 21)
        Me.日期2.Name = "日期2"
        Me.日期2.Size = New System.Drawing.Size(157, 27)
        Me.日期2.TabIndex = 1
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(621, 12)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(94, 44)
        Me.查詢.TabIndex = 2
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(-1, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "日期："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "至"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(3, 73)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(1308, 692)
        Me.DGV1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(414, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "製單類別："
        '
        '製單類別
        '
        Me.製單類別.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.製單類別.FormattingEnabled = True
        Me.製單類別.Items.AddRange(New Object() {"", "1", "2", "3", "4", "D"})
        Me.製單類別.Location = New System.Drawing.Point(525, 21)
        Me.製單類別.Name = "製單類別"
        Me.製單類別.Size = New System.Drawing.Size(88, 27)
        Me.製單類別.TabIndex = 8
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(739, 21)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(357, 29)
        Me.Cb1印表機.TabIndex = 1035
        '
        '列印
        '
        Me.列印.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.列印.Location = New System.Drawing.Point(1101, 12)
        Me.列印.Name = "列印"
        Me.列印.Size = New System.Drawing.Size(94, 44)
        Me.列印.TabIndex = 1034
        Me.列印.Text = "列印"
        Me.列印.UseVisualStyleBackColor = True
        '
        '匯出Excel
        '
        Me.匯出Excel.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.匯出Excel.Location = New System.Drawing.Point(1209, 12)
        Me.匯出Excel.Name = "匯出Excel"
        Me.匯出Excel.Size = New System.Drawing.Size(94, 44)
        Me.匯出Excel.TabIndex = 1036
        Me.匯出Excel.Text = "Excel"
        Me.匯出Excel.UseVisualStyleBackColor = True
        '
        'v001產程明細表
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 770)
        Me.Controls.Add(Me.匯出Excel)
        Me.Controls.Add(Me.製單類別)
        Me.Controls.Add(Me.日期2)
        Me.Controls.Add(Me.日期1)
        Me.Controls.Add(Me.Cb1印表機)
        Me.Controls.Add(Me.列印)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.查詢)
        Me.Name = "v001產程明細表"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "產程明細表"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents 日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 製單類別 As System.Windows.Forms.ComboBox
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents 列印 As System.Windows.Forms.Button
    Friend WithEvents 匯出Excel As System.Windows.Forms.Button
End Class
