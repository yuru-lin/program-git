<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QueryOutside
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
        Me.ExcelBtn = New System.Windows.Forms.Button
        Me.dgvExcel = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvDetail = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ExcelBtn
        '
        Me.ExcelBtn.Location = New System.Drawing.Point(15, 372)
        Me.ExcelBtn.Name = "ExcelBtn"
        Me.ExcelBtn.Size = New System.Drawing.Size(75, 23)
        Me.ExcelBtn.TabIndex = 40
        Me.ExcelBtn.Text = "讀取Excel"
        Me.ExcelBtn.UseVisualStyleBackColor = True
        '
        'dgvExcel
        '
        Me.dgvExcel.AllowUserToAddRows = False
        Me.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcel.Location = New System.Drawing.Point(472, 12)
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.RowTemplate.Height = 24
        Me.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcel.Size = New System.Drawing.Size(60, 13)
        Me.dgvExcel.TabIndex = 39
        Me.dgvExcel.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "明細 ："
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(15, 28)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.RowTemplate.Height = 24
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(520, 338)
        Me.dgvDetail.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(494, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 12)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "0筆"
        '
        'B_QueryOutside
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 407)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.ExcelBtn)
        Me.Controls.Add(Me.dgvExcel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "B_QueryOutside"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "委外代工分析領料單"
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExcelBtn As System.Windows.Forms.Button
    Friend WithEvents dgvExcel As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
