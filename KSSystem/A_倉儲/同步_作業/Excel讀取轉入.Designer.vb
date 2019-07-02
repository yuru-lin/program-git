<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Excel讀取轉入
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.SyncToDB = New System.Windows.Forms.Button
        Me.btnReadExcel = New System.Windows.Forms.Button
        Me.dgv1 = New System.Windows.Forms.DataGridView
        Me.btndelete = New System.Windows.Forms.Button
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(12, 401)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(139, 64)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Excel欄位分別為：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第一欄：作業別" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第二欄：條碼" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第三欄：儲位"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(12, 376)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "*請仔細檢查 作業別、條碼、儲位!"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(519, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "項"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(491, 376)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(453, 376)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "共"
        '
        'SyncToDB
        '
        Me.SyncToDB.Enabled = False
        Me.SyncToDB.Location = New System.Drawing.Point(449, 393)
        Me.SyncToDB.Name = "SyncToDB"
        Me.SyncToDB.Size = New System.Drawing.Size(87, 35)
        Me.SyncToDB.TabIndex = 25
        Me.SyncToDB.Text = "同步至資料庫"
        Me.SyncToDB.UseVisualStyleBackColor = True
        '
        'btnReadExcel
        '
        Me.btnReadExcel.Location = New System.Drawing.Point(358, 393)
        Me.btnReadExcel.Name = "btnReadExcel"
        Me.btnReadExcel.Size = New System.Drawing.Size(87, 35)
        Me.btnReadExcel.TabIndex = 24
        Me.btnReadExcel.Text = "讀取Excel"
        Me.btnReadExcel.UseVisualStyleBackColor = True
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(12, 13)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowTemplate.Height = 24
        Me.dgv1.Size = New System.Drawing.Size(524, 357)
        Me.dgv1.TabIndex = 23
        '
        'btndelete
        '
        Me.btndelete.Enabled = False
        Me.btndelete.Location = New System.Drawing.Point(356, 434)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(89, 23)
        Me.btndelete.TabIndex = 185
        Me.btndelete.Text = "刪除同步條碼"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'C_SyncInByExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 478)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SyncToDB)
        Me.Controls.Add(Me.btnReadExcel)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "C_SyncInByExcel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excel入庫同步"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SyncToDB As System.Windows.Forms.Button
    Friend WithEvents btnReadExcel As System.Windows.Forms.Button
    Friend WithEvents dgv1 As System.Windows.Forms.DataGridView
    Friend WithEvents btndelete As System.Windows.Forms.Button
End Class
