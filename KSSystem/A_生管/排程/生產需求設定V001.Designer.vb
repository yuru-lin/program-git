<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產需求設定V001
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Bu1刪除 = New System.Windows.Forms.Button
        Me.Bu1修改 = New System.Windows.Forms.Button
        Me.T1需求 = New System.Windows.Forms.TextBox
        Me.Bu1新增 = New System.Windows.Forms.Button
        Me.L1代碼 = New System.Windows.Forms.Label
        Me.L1單位 = New System.Windows.Forms.Label
        Me.L1品名 = New System.Windows.Forms.Label
        Me.L1存編 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PL設定 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Bu1設定 = New System.Windows.Forms.Button
        Me.日期 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.L1日期 = New System.Windows.Forms.Label
        Me.L1ID = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(963, 661)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.L1ID)
        Me.TabPage1.Controls.Add(Me.L1日期)
        Me.TabPage1.Controls.Add(Me.Bu1刪除)
        Me.TabPage1.Controls.Add(Me.Bu1修改)
        Me.TabPage1.Controls.Add(Me.T1需求)
        Me.TabPage1.Controls.Add(Me.Bu1新增)
        Me.TabPage1.Controls.Add(Me.L1代碼)
        Me.TabPage1.Controls.Add(Me.L1單位)
        Me.TabPage1.Controls.Add(Me.L1品名)
        Me.TabPage1.Controls.Add(Me.L1存編)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.PL設定)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.DGV2)
        Me.TabPage1.Controls.Add(Me.Bu1設定)
        Me.TabPage1.Controls.Add(Me.日期)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.DGV1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(955, 628)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "生產需求量"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Bu1刪除
        '
        Me.Bu1刪除.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Bu1刪除.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1刪除.Location = New System.Drawing.Point(485, 44)
        Me.Bu1刪除.Name = "Bu1刪除"
        Me.Bu1刪除.Size = New System.Drawing.Size(66, 56)
        Me.Bu1刪除.TabIndex = 21
        Me.Bu1刪除.Text = "刪除"
        Me.Bu1刪除.UseVisualStyleBackColor = False
        '
        'Bu1修改
        '
        Me.Bu1修改.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1修改.Location = New System.Drawing.Point(322, 44)
        Me.Bu1修改.Name = "Bu1修改"
        Me.Bu1修改.Size = New System.Drawing.Size(66, 56)
        Me.Bu1修改.TabIndex = 20
        Me.Bu1修改.Text = "修改"
        Me.Bu1修改.UseVisualStyleBackColor = True
        '
        'T1需求
        '
        Me.T1需求.Location = New System.Drawing.Point(86, 67)
        Me.T1需求.Name = "T1需求"
        Me.T1需求.Size = New System.Drawing.Size(100, 30)
        Me.T1需求.TabIndex = 19
        '
        'Bu1新增
        '
        Me.Bu1新增.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1新增.Location = New System.Drawing.Point(238, 44)
        Me.Bu1新增.Name = "Bu1新增"
        Me.Bu1新增.Size = New System.Drawing.Size(66, 56)
        Me.Bu1新增.TabIndex = 18
        Me.Bu1新增.Text = "新增"
        Me.Bu1新增.UseVisualStyleBackColor = True
        '
        'L1代碼
        '
        Me.L1代碼.AutoSize = True
        Me.L1代碼.Location = New System.Drawing.Point(185, 44)
        Me.L1代碼.Name = "L1代碼"
        Me.L1代碼.Size = New System.Drawing.Size(47, 19)
        Me.L1代碼.TabIndex = 17
        Me.L1代碼.Text = "代碼"
        Me.L1代碼.Visible = False
        '
        'L1單位
        '
        Me.L1單位.AutoSize = True
        Me.L1單位.Location = New System.Drawing.Point(82, 44)
        Me.L1單位.Name = "L1單位"
        Me.L1單位.Size = New System.Drawing.Size(47, 19)
        Me.L1單位.TabIndex = 16
        Me.L1單位.Text = "單位"
        '
        'L1品名
        '
        Me.L1品名.AutoSize = True
        Me.L1品名.Location = New System.Drawing.Point(82, 25)
        Me.L1品名.Name = "L1品名"
        Me.L1品名.Size = New System.Drawing.Size(47, 19)
        Me.L1品名.TabIndex = 15
        Me.L1品名.Text = "品名"
        '
        'L1存編
        '
        Me.L1存編.AutoSize = True
        Me.L1存編.Location = New System.Drawing.Point(82, 6)
        Me.L1存編.Name = "L1存編"
        Me.L1存編.Size = New System.Drawing.Size(47, 19)
        Me.L1存編.TabIndex = 14
        Me.L1存編.Text = "存編"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "需求量："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 19)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "單　位："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "品　名："
        '
        'PL設定
        '
        Me.PL設定.Location = New System.Drawing.Point(2, 300)
        Me.PL設定.Name = "PL設定"
        Me.PL設定.Size = New System.Drawing.Size(230, 260)
        Me.PL設定.TabIndex = 10
        Me.PL設定.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "存　編："
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV2.Location = New System.Drawing.Point(6, 105)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(941, 176)
        Me.DGV2.TabIndex = 9
        Me.DGV2.TabStop = False
        Me.DGV2.Visible = False
        '
        'Bu1設定
        '
        Me.Bu1設定.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1設定.Location = New System.Drawing.Point(884, 43)
        Me.Bu1設定.Name = "Bu1設定"
        Me.Bu1設定.Size = New System.Drawing.Size(66, 56)
        Me.Bu1設定.TabIndex = 8
        Me.Bu1設定.Text = "查詢"
        Me.Bu1設定.UseVisualStyleBackColor = True
        '
        '日期
        '
        Me.日期.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.日期.Location = New System.Drawing.Point(778, 6)
        Me.日期.Name = "日期"
        Me.日期.Size = New System.Drawing.Size(172, 30)
        Me.日期.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(724, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "日期："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV1.Location = New System.Drawing.Point(6, 287)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(942, 333)
        Me.DGV1.TabIndex = 2
        Me.DGV1.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(955, 628)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "對應存編"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'L1日期
        '
        Me.L1日期.AutoSize = True
        Me.L1日期.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.L1日期.Location = New System.Drawing.Point(724, 43)
        Me.L1日期.Name = "L1日期"
        Me.L1日期.Size = New System.Drawing.Size(47, 19)
        Me.L1日期.TabIndex = 22
        Me.L1日期.Text = "日期"
        '
        'L1ID
        '
        Me.L1ID.AutoSize = True
        Me.L1ID.Location = New System.Drawing.Point(185, 70)
        Me.L1ID.Name = "L1ID"
        Me.L1ID.Size = New System.Drawing.Size(28, 19)
        Me.L1ID.TabIndex = 23
        Me.L1ID.Text = "ID"
        Me.L1ID.Visible = False
        '
        '生產需求設定V001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 662)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "生產需求設定V001"
        Me.Text = "生產需求設定"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu1設定 As System.Windows.Forms.Button
    Friend WithEvents 日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PL設定 As System.Windows.Forms.Panel
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents L1單位 As System.Windows.Forms.Label
    Friend WithEvents L1品名 As System.Windows.Forms.Label
    Friend WithEvents L1存編 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents L1代碼 As System.Windows.Forms.Label
    Friend WithEvents Bu1新增 As System.Windows.Forms.Button
    Friend WithEvents Bu1刪除 As System.Windows.Forms.Button
    Friend WithEvents Bu1修改 As System.Windows.Forms.Button
    Friend WithEvents T1需求 As System.Windows.Forms.TextBox
    Friend WithEvents L1日期 As System.Windows.Forms.Label
    Friend WithEvents L1ID As System.Windows.Forms.Label
End Class
