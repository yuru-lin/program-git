<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001健檢數據資料
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
        Me.讀取Excel = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.匯出Excel = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '讀取Excel
        '
        Me.讀取Excel.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.讀取Excel.Location = New System.Drawing.Point(12, 9)
        Me.讀取Excel.Name = "讀取Excel"
        Me.讀取Excel.Size = New System.Drawing.Size(110, 40)
        Me.讀取Excel.TabIndex = 0
        Me.讀取Excel.Text = "讀取Excel"
        Me.讀取Excel.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(2, 58)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(994, 600)
        Me.DGV1.TabIndex = 1
        '
        '匯出Excel
        '
        Me.匯出Excel.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.匯出Excel.Location = New System.Drawing.Point(161, 9)
        Me.匯出Excel.Name = "匯出Excel"
        Me.匯出Excel.Size = New System.Drawing.Size(110, 40)
        Me.匯出Excel.TabIndex = 2
        Me.匯出Excel.Text = "匯出Excel"
        Me.匯出Excel.UseVisualStyleBackColor = True
        '
        'v001健檢數據資料
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 660)
        Me.Controls.Add(Me.匯出Excel)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.讀取Excel)
        Me.Name = "v001健檢數據資料"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "健檢數據資料"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents 讀取Excel As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents 匯出Excel As System.Windows.Forms.Button
End Class
