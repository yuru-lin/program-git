<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 交貨單轉出與轉入
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SyncToDB = New System.Windows.Forms.Button
        Me.btnReadExcel = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtNum = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ToExcelBtn = New System.Windows.Forms.Button
        Me.btnReSearch = New System.Windows.Forms.Button
        Me.Cb選擇 = New System.Windows.Forms.ComboBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(605, 433)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "項"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(577, 433)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(539, 433)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "共"
        '
        'SyncToDB
        '
        Me.SyncToDB.Enabled = False
        Me.SyncToDB.Location = New System.Drawing.Point(535, 460)
        Me.SyncToDB.Name = "SyncToDB"
        Me.SyncToDB.Size = New System.Drawing.Size(87, 35)
        Me.SyncToDB.TabIndex = 25
        Me.SyncToDB.Text = "同步至資料庫"
        Me.SyncToDB.UseVisualStyleBackColor = True
        '
        'btnReadExcel
        '
        Me.btnReadExcel.Location = New System.Drawing.Point(444, 460)
        Me.btnReadExcel.Name = "btnReadExcel"
        Me.btnReadExcel.Size = New System.Drawing.Size(87, 35)
        Me.btnReadExcel.TabIndex = 24
        Me.btnReadExcel.Text = "讀取Excel"
        Me.btnReadExcel.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 73)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(610, 357)
        Me.DGV1.TabIndex = 23
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(316, 36)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 30)
        Me.btnSearch.TabIndex = 186
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtNum
        '
        Me.txtNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtNum.Location = New System.Drawing.Point(203, 39)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(107, 27)
        Me.txtNum.TabIndex = 187
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 188
        Me.Label1.Text = "交貨單號："
        '
        'ToExcelBtn
        '
        Me.ToExcelBtn.Enabled = False
        Me.ToExcelBtn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ToExcelBtn.Location = New System.Drawing.Point(397, 36)
        Me.ToExcelBtn.Name = "ToExcelBtn"
        Me.ToExcelBtn.Size = New System.Drawing.Size(100, 30)
        Me.ToExcelBtn.TabIndex = 189
        Me.ToExcelBtn.Text = "匯出Excel"
        Me.ToExcelBtn.UseVisualStyleBackColor = True
        '
        'btnReSearch
        '
        Me.btnReSearch.Enabled = False
        Me.btnReSearch.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnReSearch.Location = New System.Drawing.Point(522, 36)
        Me.btnReSearch.Name = "btnReSearch"
        Me.btnReSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnReSearch.TabIndex = 190
        Me.btnReSearch.Text = "重新查詢"
        Me.btnReSearch.UseVisualStyleBackColor = True
        '
        'Cb選擇
        '
        Me.Cb選擇.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb選擇.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb選擇.FormattingEnabled = True
        Me.Cb選擇.Items.AddRange(New Object() {"銷售", "代工"})
        Me.Cb選擇.Location = New System.Drawing.Point(12, 39)
        Me.Cb選擇.Name = "Cb選擇"
        Me.Cb選擇.Size = New System.Drawing.Size(95, 27)
        Me.Cb選擇.TabIndex = 191
        '
        '交貨單轉出與轉入
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 507)
        Me.Controls.Add(Me.Cb選擇)
        Me.Controls.Add(Me.btnReSearch)
        Me.Controls.Add(Me.ToExcelBtn)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SyncToDB)
        Me.Controls.Add(Me.btnReadExcel)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "交貨單轉出與轉入"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel轉出與轉入"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SyncToDB As System.Windows.Forms.Button
    Friend WithEvents btnReadExcel As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToExcelBtn As System.Windows.Forms.Button
    Friend WithEvents btnReSearch As System.Windows.Forms.Button
    Friend WithEvents Cb選擇 As System.Windows.Forms.ComboBox
End Class
