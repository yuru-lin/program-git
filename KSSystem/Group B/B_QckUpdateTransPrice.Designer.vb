<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QckUpdateTransPrice
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
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dateDocDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvTransport = New System.Windows.Forms.DataGridView
        Me.Label45 = New System.Windows.Forms.Label
        Me.txtPricePerKG = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPricePerTWKG = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.btnAddToDB = New System.Windows.Forms.Button
        Me.BtnToExcel = New System.Windows.Forms.Button
        Me.lblEntry = New System.Windows.Forms.Label
        CType(Me.dgvTransport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(295, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 82
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dateDocDate
        '
        Me.dateDocDate.Location = New System.Drawing.Point(170, 12)
        Me.dateDocDate.Name = "dateDocDate"
        Me.dateDocDate.Size = New System.Drawing.Size(120, 22)
        Me.dateDocDate.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "日期："
        '
        'dgvTransport
        '
        Me.dgvTransport.AllowUserToAddRows = False
        Me.dgvTransport.AllowUserToDeleteRows = False
        Me.dgvTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransport.Location = New System.Drawing.Point(12, 41)
        Me.dgvTransport.Name = "dgvTransport"
        Me.dgvTransport.ReadOnly = True
        Me.dgvTransport.RowHeadersVisible = False
        Me.dgvTransport.RowTemplate.Height = 24
        Me.dgvTransport.Size = New System.Drawing.Size(460, 150)
        Me.dgvTransport.TabIndex = 83
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label45.Location = New System.Drawing.Point(321, 239)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(61, 12)
        Me.Label45.TabIndex = 132
        Me.Label45.Text = "(台斤 / 0.6)"
        '
        'txtPricePerKG
        '
        Me.txtPricePerKG.Enabled = False
        Me.txtPricePerKG.Location = New System.Drawing.Point(254, 229)
        Me.txtPricePerKG.Name = "txtPricePerKG"
        Me.txtPricePerKG.Size = New System.Drawing.Size(60, 22)
        Me.txtPricePerKG.TabIndex = 129
        Me.txtPricePerKG.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(166, 232)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 131
        Me.Label16.Text = "公斤單價："
        '
        'txtPricePerTWKG
        '
        Me.txtPricePerTWKG.Location = New System.Drawing.Point(100, 229)
        Me.txtPricePerTWKG.Name = "txtPricePerTWKG"
        Me.txtPricePerTWKG.Size = New System.Drawing.Size(60, 22)
        Me.txtPricePerTWKG.TabIndex = 128
        Me.txtPricePerTWKG.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 232)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(88, 16)
        Me.Label15.TabIndex = 130
        Me.Label15.Text = "台斤單價："
        '
        'btnAddToDB
        '
        Me.btnAddToDB.Location = New System.Drawing.Point(18, 257)
        Me.btnAddToDB.Name = "btnAddToDB"
        Me.btnAddToDB.Size = New System.Drawing.Size(90, 23)
        Me.btnAddToDB.TabIndex = 133
        Me.btnAddToDB.Text = "新增至資料庫"
        Me.btnAddToDB.UseVisualStyleBackColor = True
        '
        'BtnToExcel
        '
        Me.BtnToExcel.Location = New System.Drawing.Point(382, 257)
        Me.BtnToExcel.Name = "BtnToExcel"
        Me.BtnToExcel.Size = New System.Drawing.Size(90, 23)
        Me.BtnToExcel.TabIndex = 134
        Me.BtnToExcel.Text = "匯出Excel"
        Me.BtnToExcel.UseVisualStyleBackColor = True
        '
        'lblEntry
        '
        Me.lblEntry.AutoSize = True
        Me.lblEntry.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.lblEntry.Location = New System.Drawing.Point(15, 198)
        Me.lblEntry.Name = "lblEntry"
        Me.lblEntry.Size = New System.Drawing.Size(0, 16)
        Me.lblEntry.TabIndex = 135
        '
        'B_QckUpdateTransPrice
        '
        Me.AcceptButton = Me.btnAddToDB
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 292)
        Me.Controls.Add(Me.lblEntry)
        Me.Controls.Add(Me.BtnToExcel)
        Me.Controls.Add(Me.btnAddToDB)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.txtPricePerKG)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPricePerTWKG)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dgvTransport)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "B_QckUpdateTransPrice"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "更新單價"
        CType(Me.dgvTransport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dateDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvTransport As System.Windows.Forms.DataGridView
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtPricePerKG As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPricePerTWKG As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnAddToDB As System.Windows.Forms.Button
    Friend WithEvents BtnToExcel As System.Windows.Forms.Button
    Friend WithEvents lblEntry As System.Windows.Forms.Label
End Class
