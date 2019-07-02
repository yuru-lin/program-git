<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QuerySRNTradesDetail
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
        Me.btnExportExcel = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvDetail = New System.Windows.Forms.DataGridView
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnReadExcel = New System.Windows.Forms.Button
        Me.dgvExcel = New System.Windows.Forms.DataGridView
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Location = New System.Drawing.Point(655, 438)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(87, 35)
        Me.btnExportExcel.TabIndex = 117
        Me.btnExportExcel.Text = "匯出Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(11, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "交易內容："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(727, 414)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "項"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(699, 414)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(661, 414)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 112
        Me.Label6.Text = "共"
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Location = New System.Drawing.Point(17, 30)
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        Me.dgvDetail.RowTemplate.Height = 24
        Me.dgvDetail.Size = New System.Drawing.Size(727, 381)
        Me.dgvDetail.TabIndex = 111
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(14, 479)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(730, 23)
        Me.PBar1.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(14, 438)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 32)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Excel欄位分別為：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第一欄：條碼"
        '
        'btnReadExcel
        '
        Me.btnReadExcel.Location = New System.Drawing.Point(562, 438)
        Me.btnReadExcel.Name = "btnReadExcel"
        Me.btnReadExcel.Size = New System.Drawing.Size(87, 35)
        Me.btnReadExcel.TabIndex = 107
        Me.btnReadExcel.Text = "讀取Excel"
        Me.btnReadExcel.UseVisualStyleBackColor = True
        '
        'dgvExcel
        '
        Me.dgvExcel.AllowUserToAddRows = False
        Me.dgvExcel.AllowUserToDeleteRows = False
        Me.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcel.Location = New System.Drawing.Point(689, 14)
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.RowTemplate.Height = 24
        Me.dgvExcel.Size = New System.Drawing.Size(55, 35)
        Me.dgvExcel.TabIndex = 115
        Me.dgvExcel.Visible = False
        '
        'C_QuerySRNTradesDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 512)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvDetail)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnReadExcel)
        Me.Controls.Add(Me.dgvExcel)
        Me.Name = "C_QuerySRNTradesDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "序號交易報表查詢"
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnReadExcel As System.Windows.Forms.Button
    Friend WithEvents dgvExcel As System.Windows.Forms.DataGridView
End Class
