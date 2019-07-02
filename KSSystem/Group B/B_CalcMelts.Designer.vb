<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_CalcMelts
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
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.txtSumOfTime = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtSumOfTotal = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.PrintBtn = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(405, 12)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(120, 22)
        Me.ToDate.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(381, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "至"
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(261, 12)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(120, 22)
        Me.FromDate.TabIndex = 50
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(173, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "資料期間："
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(525, 12)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 48
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 41)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(622, 306)
        Me.DGV1.TabIndex = 60
        '
        'txtSumOfTime
        '
        Me.txtSumOfTime.Location = New System.Drawing.Point(338, 353)
        Me.txtSumOfTime.Name = "txtSumOfTime"
        Me.txtSumOfTime.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfTime.TabIndex = 83
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(234, 356)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(104, 16)
        Me.Label15.TabIndex = 82
        Me.Label15.Text = "工時數總計："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfTotal
        '
        Me.txtSumOfTotal.Location = New System.Drawing.Point(109, 353)
        Me.txtSumOfTotal.Name = "txtSumOfTotal"
        Me.txtSumOfTotal.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfTotal.TabIndex = 81
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(21, 356)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 16)
        Me.Label18.TabIndex = 80
        Me.Label18.Text = "產出總計："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PrintBtn
        '
        Me.PrintBtn.Location = New System.Drawing.Point(559, 353)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(75, 23)
        Me.PrintBtn.TabIndex = 104
        Me.PrintBtn.Text = "列印"
        Me.PrintBtn.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "類型："
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"化製", "飼料"})
        Me.cmbType.Location = New System.Drawing.Point(102, 13)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(71, 20)
        Me.cmbType.TabIndex = 106
        '
        'B_CalcMelts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 395)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.txtSumOfTime)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSumOfTotal)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SearchBtn)
        Me.Name = "B_CalcMelts"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "計算化製/飼料"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtSumOfTime As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PrintBtn As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
End Class
