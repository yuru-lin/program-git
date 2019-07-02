<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_PDA讀取轉入
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
        Me.ToExcelBtn = New System.Windows.Forms.Button
        Me.DelPDA = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.LocCuntView = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUndel = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.ScanedDataGridView = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSync = New System.Windows.Forms.Button
        Me.btnReadPDA = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btndelete = New System.Windows.Forms.Button
        Me.舊PDA = New System.Windows.Forms.RadioButton
        Me.新PDA = New System.Windows.Forms.RadioButton
        Me.條碼庫 = New System.Windows.Forms.RadioButton
        CType(Me.LocCuntView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScanedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToExcelBtn
        '
        Me.ToExcelBtn.Enabled = False
        Me.ToExcelBtn.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.ToExcelBtn.Location = New System.Drawing.Point(536, 165)
        Me.ToExcelBtn.Name = "ToExcelBtn"
        Me.ToExcelBtn.Size = New System.Drawing.Size(95, 37)
        Me.ToExcelBtn.TabIndex = 61
        Me.ToExcelBtn.Text = "匯出Excel"
        Me.ToExcelBtn.UseVisualStyleBackColor = True
        '
        'DelPDA
        '
        Me.DelPDA.Enabled = False
        Me.DelPDA.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.DelPDA.Location = New System.Drawing.Point(637, 165)
        Me.DelPDA.Name = "DelPDA"
        Me.DelPDA.Size = New System.Drawing.Size(95, 37)
        Me.DelPDA.TabIndex = 60
        Me.DelPDA.Text = "刪除PDA資料"
        Me.DelPDA.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(532, 339)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 19)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "儲位數量"
        '
        'LocCuntView
        '
        Me.LocCuntView.AllowUserToAddRows = False
        Me.LocCuntView.AllowUserToDeleteRows = False
        Me.LocCuntView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LocCuntView.Location = New System.Drawing.Point(531, 361)
        Me.LocCuntView.Name = "LocCuntView"
        Me.LocCuntView.ReadOnly = True
        Me.LocCuntView.RowTemplate.Height = 24
        Me.LocCuntView.Size = New System.Drawing.Size(240, 165)
        Me.LocCuntView.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(536, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(173, 64)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "*請仔細檢查 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作業別、條碼、儲位!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "如發現有誤!請勿同步!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請使用 ""作廢"" 按鈕"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(469, 532)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 12)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "項 已掃描"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(426, 532)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 12)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(383, 532)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "共"
        '
        'btnUndel
        '
        Me.btnUndel.Enabled = False
        Me.btnUndel.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.btnUndel.Location = New System.Drawing.Point(637, 122)
        Me.btnUndel.Name = "btnUndel"
        Me.btnUndel.Size = New System.Drawing.Size(95, 37)
        Me.btnUndel.TabIndex = 53
        Me.btnUndel.Text = "回復"
        Me.btnUndel.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Enabled = False
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.btnDel.Location = New System.Drawing.Point(536, 122)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(95, 37)
        Me.btnDel.TabIndex = 52
        Me.btnDel.Text = "作廢"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'ScanedDataGridView
        '
        Me.ScanedDataGridView.AllowUserToAddRows = False
        Me.ScanedDataGridView.AllowUserToDeleteRows = False
        Me.ScanedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ScanedDataGridView.Location = New System.Drawing.Point(11, 64)
        Me.ScanedDataGridView.Name = "ScanedDataGridView"
        Me.ScanedDataGridView.ReadOnly = True
        Me.ScanedDataGridView.RowHeadersWidth = 25
        Me.ScanedDataGridView.RowTemplate.Height = 24
        Me.ScanedDataGridView.Size = New System.Drawing.Size(514, 465)
        Me.ScanedDataGridView.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(12, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 19)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "PDA中已掃瞄入庫項目"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(275, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 24)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "凱馨入庫清點同步作業"
        '
        'btnSync
        '
        Me.btnSync.Enabled = False
        Me.btnSync.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSync.Location = New System.Drawing.Point(539, 272)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(134, 52)
        Me.btnSync.TabIndex = 43
        Me.btnSync.Text = "同步至伺服器"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'btnReadPDA
        '
        Me.btnReadPDA.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnReadPDA.Location = New System.Drawing.Point(536, 64)
        Me.btnReadPDA.Name = "btnReadPDA"
        Me.btnReadPDA.Size = New System.Drawing.Size(196, 52)
        Me.btnReadPDA.TabIndex = 62
        Me.btnReadPDA.Text = "讀取PDA資料"
        Me.btnReadPDA.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(469, 544)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 12)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "項 錯誤(已同步過)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(426, 544)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(383, 544)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(17, 12)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "共"
        '
        'btndelete
        '
        Me.btndelete.Enabled = False
        Me.btndelete.Location = New System.Drawing.Point(679, 301)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(89, 23)
        Me.btndelete.TabIndex = 186
        Me.btndelete.Text = "刪除紅色條碼"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        '舊PDA
        '
        Me.舊PDA.AutoSize = True
        Me.舊PDA.Checked = True
        Me.舊PDA.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.舊PDA.Location = New System.Drawing.Point(531, 38)
        Me.舊PDA.Name = "舊PDA"
        Me.舊PDA.Size = New System.Drawing.Size(72, 20)
        Me.舊PDA.TabIndex = 187
        Me.舊PDA.TabStop = True
        Me.舊PDA.Text = "舊PDA"
        Me.舊PDA.UseVisualStyleBackColor = True
        '
        '新PDA
        '
        Me.新PDA.AutoSize = True
        Me.新PDA.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.新PDA.Location = New System.Drawing.Point(609, 38)
        Me.新PDA.Name = "新PDA"
        Me.新PDA.Size = New System.Drawing.Size(72, 20)
        Me.新PDA.TabIndex = 188
        Me.新PDA.Text = "新PDA"
        Me.新PDA.UseVisualStyleBackColor = True
        '
        '條碼庫
        '
        Me.條碼庫.AutoSize = True
        Me.條碼庫.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.條碼庫.Location = New System.Drawing.Point(687, 38)
        Me.條碼庫.Name = "條碼庫"
        Me.條碼庫.Size = New System.Drawing.Size(74, 20)
        Me.條碼庫.TabIndex = 189
        Me.條碼庫.Text = "條碼庫"
        Me.條碼庫.UseVisualStyleBackColor = True
        Me.條碼庫.Visible = False
        '
        'C_SyncInByPDA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 574)
        Me.Controls.Add(Me.條碼庫)
        Me.Controls.Add(Me.新PDA)
        Me.Controls.Add(Me.舊PDA)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnReadPDA)
        Me.Controls.Add(Me.ToExcelBtn)
        Me.Controls.Add(Me.DelPDA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnUndel)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.ScanedDataGridView)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSync)
        Me.Controls.Add(Me.LocCuntView)
        Me.Name = "C_SyncInByPDA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDA入庫同步"
        CType(Me.LocCuntView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScanedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToExcelBtn As System.Windows.Forms.Button
    Friend WithEvents DelPDA As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LocCuntView As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUndel As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents ScanedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSync As System.Windows.Forms.Button
    Friend WithEvents btnReadPDA As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents 舊PDA As System.Windows.Forms.RadioButton
    Friend WithEvents 新PDA As System.Windows.Forms.RadioButton
    Friend WithEvents 條碼庫 As System.Windows.Forms.RadioButton
End Class
