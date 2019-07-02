<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_PDA上傳轉入
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
        Me.btnUndel = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.ScanedDataGridView = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.同步至入庫區 = New System.Windows.Forms.Button
        Me.讀取待轉區資料 = New System.Windows.Forms.Button
        Me.btndelete = New System.Windows.Forms.Button
        Me.舊PDA = New System.Windows.Forms.RadioButton
        Me.新PDA = New System.Windows.Forms.RadioButton
        Me.條碼庫 = New System.Windows.Forms.RadioButton
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.上頁 = New System.Windows.Forms.Button
        Me.清除已入庫條碼 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.待轉數量 = New System.Windows.Forms.Label
        Me.已入庫數 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.LocCuntView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScanedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToExcelBtn
        '
        Me.ToExcelBtn.Enabled = False
        Me.ToExcelBtn.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.ToExcelBtn.Location = New System.Drawing.Point(47, 164)
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
        Me.DelPDA.Location = New System.Drawing.Point(148, 164)
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
        Me.Label9.Location = New System.Drawing.Point(660, 354)
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
        Me.LocCuntView.Location = New System.Drawing.Point(6, 21)
        Me.LocCuntView.Name = "LocCuntView"
        Me.LocCuntView.ReadOnly = True
        Me.LocCuntView.RowTemplate.Height = 24
        Me.LocCuntView.Size = New System.Drawing.Size(48, 42)
        Me.LocCuntView.TabIndex = 58
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(47, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(173, 64)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "*請仔細檢查 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作業別、條碼、儲位!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "如發現有誤!請勿同步!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請使用 ""作廢"" 按鈕"
        '
        'btnUndel
        '
        Me.btnUndel.Enabled = False
        Me.btnUndel.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.btnUndel.Location = New System.Drawing.Point(148, 121)
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
        Me.btnDel.Location = New System.Drawing.Point(47, 121)
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
        Me.ScanedDataGridView.Location = New System.Drawing.Point(60, 21)
        Me.ScanedDataGridView.Name = "ScanedDataGridView"
        Me.ScanedDataGridView.ReadOnly = True
        Me.ScanedDataGridView.RowHeadersWidth = 25
        Me.ScanedDataGridView.RowTemplate.Height = 24
        Me.ScanedDataGridView.Size = New System.Drawing.Size(48, 42)
        Me.ScanedDataGridView.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(-3, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "入庫項目"
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
        '同步至入庫區
        '
        Me.同步至入庫區.Enabled = False
        Me.同步至入庫區.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.同步至入庫區.Location = New System.Drawing.Point(660, 293)
        Me.同步至入庫區.Name = "同步至入庫區"
        Me.同步至入庫區.Size = New System.Drawing.Size(212, 52)
        Me.同步至入庫區.TabIndex = 43
        Me.同步至入庫區.Text = "同步至入庫區"
        Me.同步至入庫區.UseVisualStyleBackColor = True
        '
        '讀取待轉區資料
        '
        Me.讀取待轉區資料.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.讀取待轉區資料.Location = New System.Drawing.Point(660, 122)
        Me.讀取待轉區資料.Name = "讀取待轉區資料"
        Me.讀取待轉區資料.Size = New System.Drawing.Size(212, 52)
        Me.讀取待轉區資料.TabIndex = 62
        Me.讀取待轉區資料.Text = "讀取待轉區資料"
        Me.讀取待轉區資料.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Enabled = False
        Me.btndelete.Location = New System.Drawing.Point(148, 89)
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
        Me.舊PDA.Location = New System.Drawing.Point(6, 69)
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
        Me.新PDA.Location = New System.Drawing.Point(6, 95)
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
        Me.條碼庫.Location = New System.Drawing.Point(6, 121)
        Me.條碼庫.Name = "條碼庫"
        Me.條碼庫.Size = New System.Drawing.Size(74, 20)
        Me.條碼庫.TabIndex = 189
        Me.條碼庫.Text = "條碼庫"
        Me.條碼庫.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(1, 81)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 20
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(653, 488)
        Me.DGV1.TabIndex = 190
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(660, 376)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 20
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(212, 150)
        Me.DGV2.TabIndex = 191
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.LocCuntView)
        Me.GroupBox1.Controls.Add(Me.ScanedDataGridView)
        Me.GroupBox1.Controls.Add(Me.舊PDA)
        Me.GroupBox1.Controls.Add(Me.條碼庫)
        Me.GroupBox1.Controls.Add(Me.btndelete)
        Me.GroupBox1.Controls.Add(Me.新PDA)
        Me.GroupBox1.Controls.Add(Me.btnDel)
        Me.GroupBox1.Controls.Add(Me.btnUndel)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DelPDA)
        Me.GroupBox1.Controls.Add(Me.ToExcelBtn)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 272)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 290)
        Me.GroupBox1.TabIndex = 192
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        '上頁
        '
        Me.上頁.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.上頁.Location = New System.Drawing.Point(777, 532)
        Me.上頁.Name = "上頁"
        Me.上頁.Size = New System.Drawing.Size(95, 37)
        Me.上頁.TabIndex = 193
        Me.上頁.Text = "上頁"
        Me.上頁.UseVisualStyleBackColor = True
        '
        '清除已入庫條碼
        '
        Me.清除已入庫條碼.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.清除已入庫條碼.Location = New System.Drawing.Point(660, 180)
        Me.清除已入庫條碼.Name = "清除已入庫條碼"
        Me.清除已入庫條碼.Size = New System.Drawing.Size(115, 37)
        Me.清除已入庫條碼.TabIndex = 190
        Me.清除已入庫條碼.Text = "清除已入庫條碼"
        Me.清除已入庫條碼.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Button2.Location = New System.Drawing.Point(757, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 37)
        Me.Button2.TabIndex = 194
        Me.Button2.Text = "清除已入庫條碼"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        '待轉數量
        '
        Me.待轉數量.AutoSize = True
        Me.待轉數量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.待轉數量.Location = New System.Drawing.Point(661, 41)
        Me.待轉數量.Name = "待轉數量"
        Me.待轉數量.Size = New System.Drawing.Size(72, 16)
        Me.待轉數量.TabIndex = 195
        Me.待轉數量.Text = "待轉數量"
        '
        '已入庫數
        '
        Me.已入庫數.AutoSize = True
        Me.已入庫數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.已入庫數.Location = New System.Drawing.Point(661, 63)
        Me.已入庫數.Name = "已入庫數"
        Me.已入庫數.Size = New System.Drawing.Size(72, 16)
        Me.已入庫數.TabIndex = 196
        Me.已入庫數.Text = "已入庫數"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(661, 553)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 198
        Me.Label2.Text = "v 100"
        '
        'A_PDA上傳轉入
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 574)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.已入庫數)
        Me.Controls.Add(Me.待轉數量)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.清除已入庫條碼)
        Me.Controls.Add(Me.上頁)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.讀取待轉區資料)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.同步至入庫區)
        Me.Name = "A_PDA上傳轉入"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDA入庫同步"
        CType(Me.LocCuntView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScanedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToExcelBtn As System.Windows.Forms.Button
    Friend WithEvents DelPDA As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LocCuntView As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnUndel As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents ScanedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 同步至入庫區 As System.Windows.Forms.Button
    Friend WithEvents 讀取待轉區資料 As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents 舊PDA As System.Windows.Forms.RadioButton
    Friend WithEvents 新PDA As System.Windows.Forms.RadioButton
    Friend WithEvents 條碼庫 As System.Windows.Forms.RadioButton
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents 上頁 As System.Windows.Forms.Button
    Friend WithEvents 清除已入庫條碼 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents 待轉數量 As System.Windows.Forms.Label
    Friend WithEvents 已入庫數 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
