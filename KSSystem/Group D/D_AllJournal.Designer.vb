<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D_AllJournal
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
        Me.ToExcelBtn3 = New System.Windows.Forms.Button
        Me.ToExcelBtn2 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.ToExcelBtn1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToExcelBtn3
        '
        Me.ToExcelBtn3.Location = New System.Drawing.Point(897, 622)
        Me.ToExcelBtn3.Name = "ToExcelBtn3"
        Me.ToExcelBtn3.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn3.TabIndex = 79
        Me.ToExcelBtn3.Text = "匯出Excel"
        Me.ToExcelBtn3.UseVisualStyleBackColor = True
        '
        'ToExcelBtn2
        '
        Me.ToExcelBtn2.Location = New System.Drawing.Point(414, 622)
        Me.ToExcelBtn2.Name = "ToExcelBtn2"
        Me.ToExcelBtn2.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn2.TabIndex = 78
        Me.ToExcelBtn2.Text = "匯出Excel"
        Me.ToExcelBtn2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(493, 337)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "分錄："
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(496, 356)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV3.Size = New System.Drawing.Size(476, 260)
        Me.DGV3.TabIndex = 76
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(13, 356)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(476, 260)
        Me.DGV2.TabIndex = 75
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 337)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "明細："
        '
        'ToExcelBtn1
        '
        Me.ToExcelBtn1.Location = New System.Drawing.Point(897, 327)
        Me.ToExcelBtn1.Name = "ToExcelBtn1"
        Me.ToExcelBtn1.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn1.TabIndex = 73
        Me.ToExcelBtn1.Text = "匯出Excel"
        Me.ToExcelBtn1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "資料："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 61)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(960, 260)
        Me.DGV1.TabIndex = 71
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(659, 18)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 70
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(525, 18)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(120, 22)
        Me.ToDate.TabIndex = 69
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(487, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "至"
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(353, 18)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(120, 22)
        Me.FromDate.TabIndex = 67
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(251, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "資料期間："
        '
        'D_AllJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.ToExcelBtn3)
        Me.Controls.Add(Me.ToExcelBtn2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ToExcelBtn1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label3)
        Me.Name = "D_AllJournal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "總分類帳"
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToExcelBtn3 As System.Windows.Forms.Button
    Friend WithEvents ToExcelBtn2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ToExcelBtn1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
