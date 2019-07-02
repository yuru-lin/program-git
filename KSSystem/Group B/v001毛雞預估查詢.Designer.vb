<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001毛雞預估查詢
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.查詢 = New System.Windows.Forms.Button
        Me.列印 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.DocNum = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "日期："
        '
        '日期
        '
        Me.日期.CalendarFont = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(92, 18)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(155, 27)
        Me.日期.TabIndex = 2
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(263, 12)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(90, 44)
        Me.查詢.TabIndex = 3
        Me.查詢.Text = "查詢"
        Me.查詢.UseVisualStyleBackColor = True
        '
        '列印
        '
        Me.列印.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.列印.Location = New System.Drawing.Point(998, 12)
        Me.列印.Name = "列印"
        Me.列印.Size = New System.Drawing.Size(90, 44)
        Me.列印.TabIndex = 4
        Me.列印.Text = "列印"
        Me.列印.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(18, 93)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(1088, 198)
        Me.DGV1.TabIndex = 5
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(18, 312)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(1088, 438)
        Me.DGV2.TabIndex = 6
        '
        'DocNum
        '
        Me.DocNum.AutoSize = True
        Me.DocNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DocNum.ForeColor = System.Drawing.Color.Red
        Me.DocNum.Location = New System.Drawing.Point(108, 68)
        Me.DocNum.Name = "DocNum"
        Me.DocNum.Size = New System.Drawing.Size(40, 16)
        Me.DocNum.TabIndex = 14
        Me.DocNum.Text = "單號"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "製單單號："
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(623, 27)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(357, 29)
        Me.Cb1印表機.TabIndex = 1033
        '
        'v001毛雞預估查詢
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 762)
        Me.Controls.Add(Me.Cb1印表機)
        Me.Controls.Add(Me.DocNum)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.列印)
        Me.Controls.Add(Me.查詢)
        Me.Controls.Add(Me.日期)
        Me.Controls.Add(Me.Label1)
        Me.Name = "v001毛雞預估查詢"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "毛雞預估查詢"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents 列印 As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents DocNum As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
End Class
