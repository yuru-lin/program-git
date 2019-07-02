<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產需求計算程式
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
        Me.CalBtn = New System.Windows.Forms.Button
        Me.Sumdetail = New System.Windows.Forms.DataGridView
        Me.ItemDetail = New System.Windows.Forms.DataGridView
        Me.AddBtn = New System.Windows.Forms.Button
        Me.ItemName = New System.Windows.Forms.TextBox
        Me.ItemCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Quty = New System.Windows.Forms.TextBox
        Me.ItemMain = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ToExcelBtn = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.ClearBtn = New System.Windows.Forms.Button
        Me.Quty2 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Quty3 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.列出明細 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.設定T1 = New System.Windows.Forms.Label
        Me.SalPackMsr = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.保存方式W = New System.Windows.Forms.ComboBox
        Me.DGVOITM = New System.Windows.Forms.DataGridView
        Me.查詢T1 = New System.Windows.Forms.Button
        Me.包含查詢 = New System.Windows.Forms.CheckBox
        Me.品W3 = New System.Windows.Forms.TextBox
        Me.品W2 = New System.Windows.Forms.TextBox
        Me.品W1 = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.離開T2 = New System.Windows.Forms.Button
        CType(Me.Sumdetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGVOITM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CalBtn
        '
        Me.CalBtn.BackColor = System.Drawing.Color.Red
        Me.CalBtn.ForeColor = System.Drawing.Color.White
        Me.CalBtn.Location = New System.Drawing.Point(845, 8)
        Me.CalBtn.Name = "CalBtn"
        Me.CalBtn.Size = New System.Drawing.Size(90, 50)
        Me.CalBtn.TabIndex = 11
        Me.CalBtn.Text = "計算" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "數量"
        Me.CalBtn.UseVisualStyleBackColor = False
        '
        'Sumdetail
        '
        Me.Sumdetail.AllowUserToAddRows = False
        Me.Sumdetail.AllowUserToDeleteRows = False
        Me.Sumdetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Sumdetail.Location = New System.Drawing.Point(6, 39)
        Me.Sumdetail.Name = "Sumdetail"
        Me.Sumdetail.ReadOnly = True
        Me.Sumdetail.RowTemplate.Height = 24
        Me.Sumdetail.Size = New System.Drawing.Size(929, 613)
        Me.Sumdetail.TabIndex = 10
        Me.Sumdetail.TabStop = False
        '
        'ItemDetail
        '
        Me.ItemDetail.AllowUserToAddRows = False
        Me.ItemDetail.AllowUserToDeleteRows = False
        Me.ItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItemDetail.Location = New System.Drawing.Point(14, 393)
        Me.ItemDetail.Name = "ItemDetail"
        Me.ItemDetail.ReadOnly = True
        Me.ItemDetail.RowHeadersWidth = 25
        Me.ItemDetail.RowTemplate.Height = 24
        Me.ItemDetail.Size = New System.Drawing.Size(929, 267)
        Me.ItemDetail.TabIndex = 9
        Me.ItemDetail.TabStop = False
        '
        'AddBtn
        '
        Me.AddBtn.Location = New System.Drawing.Point(480, 102)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(90, 25)
        Me.AddBtn.TabIndex = 9
        Me.AddBtn.Text = "新增"
        Me.AddBtn.UseVisualStyleBackColor = True
        '
        'ItemName
        '
        Me.ItemName.Location = New System.Drawing.Point(406, 39)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.Size = New System.Drawing.Size(417, 27)
        Me.ItemName.TabIndex = 7
        '
        'ItemCode
        '
        Me.ItemCode.Location = New System.Drawing.Point(406, 6)
        Me.ItemCode.Name = "ItemCode"
        Me.ItemCode.Size = New System.Drawing.Size(259, 27)
        Me.ItemCode.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(354, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "存編："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(354, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "品名："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(354, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "數量："
        '
        'Quty
        '
        Me.Quty.Location = New System.Drawing.Point(406, 72)
        Me.Quty.Name = "Quty"
        Me.Quty.Size = New System.Drawing.Size(100, 27)
        Me.Quty.TabIndex = 8
        '
        'ItemMain
        '
        Me.ItemMain.AllowUserToAddRows = False
        Me.ItemMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItemMain.Location = New System.Drawing.Point(355, 133)
        Me.ItemMain.Name = "ItemMain"
        Me.ItemMain.ReadOnly = True
        Me.ItemMain.RowHeadersWidth = 25
        Me.ItemMain.RowTemplate.Height = 24
        Me.ItemMain.Size = New System.Drawing.Size(580, 238)
        Me.ItemMain.TabIndex = 16
        Me.ItemMain.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(354, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "預計生產品項："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 374)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "品項明細："
        '
        'ToExcelBtn
        '
        Me.ToExcelBtn.Location = New System.Drawing.Point(90, 8)
        Me.ToExcelBtn.Name = "ToExcelBtn"
        Me.ToExcelBtn.Size = New System.Drawing.Size(90, 25)
        Me.ToExcelBtn.TabIndex = 19
        Me.ToExcelBtn.Text = "匯出Excel"
        Me.ToExcelBtn.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "統計明細："
        '
        'ClearBtn
        '
        Me.ClearBtn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ClearBtn.Location = New System.Drawing.Point(749, 6)
        Me.ClearBtn.Name = "ClearBtn"
        Me.ClearBtn.Size = New System.Drawing.Size(90, 25)
        Me.ClearBtn.TabIndex = 23
        Me.ClearBtn.Text = "清除全部"
        Me.ClearBtn.UseVisualStyleBackColor = True
        Me.ClearBtn.Visible = False
        '
        'Quty2
        '
        Me.Quty2.BackColor = System.Drawing.Color.White
        Me.Quty2.Location = New System.Drawing.Point(565, 72)
        Me.Quty2.Name = "Quty2"
        Me.Quty2.ReadOnly = True
        Me.Quty2.Size = New System.Drawing.Size(100, 27)
        Me.Quty2.TabIndex = 25
        Me.Quty2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(512, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "基數："
        '
        'Quty3
        '
        Me.Quty3.BackColor = System.Drawing.Color.White
        Me.Quty3.Location = New System.Drawing.Point(723, 72)
        Me.Quty3.Name = "Quty3"
        Me.Quty3.ReadOnly = True
        Me.Quty3.Size = New System.Drawing.Size(100, 27)
        Me.Quty3.TabIndex = 27
        Me.Quty3.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(671, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "產量："
        '
        '列出明細
        '
        Me.列出明細.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.列出明細.Location = New System.Drawing.Point(845, 102)
        Me.列出明細.Name = "列出明細"
        Me.列出明細.Size = New System.Drawing.Size(90, 25)
        Me.列出明細.TabIndex = 28
        Me.列出明細.Text = "列出明細"
        Me.列出明細.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-6, -7)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(974, 674)
        Me.TabControl1.TabIndex = 29
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.設定T1)
        Me.TabPage1.Controls.Add(Me.列出明細)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.ItemDetail)
        Me.TabPage1.Controls.Add(Me.SalPackMsr)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.保存方式W)
        Me.TabPage1.Controls.Add(Me.DGVOITM)
        Me.TabPage1.Controls.Add(Me.查詢T1)
        Me.TabPage1.Controls.Add(Me.包含查詢)
        Me.TabPage1.Controls.Add(Me.品W3)
        Me.TabPage1.Controls.Add(Me.品W2)
        Me.TabPage1.Controls.Add(Me.品W1)
        Me.TabPage1.Controls.Add(Me.ItemCode)
        Me.TabPage1.Controls.Add(Me.ItemName)
        Me.TabPage1.Controls.Add(Me.Quty)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CalBtn)
        Me.TabPage1.Controls.Add(Me.Quty3)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.AddBtn)
        Me.TabPage1.Controls.Add(Me.Quty2)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.ItemMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(943, 666)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '設定T1
        '
        Me.設定T1.AutoSize = True
        Me.設定T1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.設定T1.Location = New System.Drawing.Point(671, 12)
        Me.設定T1.Name = "設定T1"
        Me.設定T1.Size = New System.Drawing.Size(40, 16)
        Me.設定T1.TabIndex = 38
        Me.設定T1.Text = "設定"
        '
        'SalPackMsr
        '
        Me.SalPackMsr.AutoSize = True
        Me.SalPackMsr.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SalPackMsr.ForeColor = System.Drawing.Color.Red
        Me.SalPackMsr.Location = New System.Drawing.Point(829, 75)
        Me.SalPackMsr.Name = "SalPackMsr"
        Me.SalPackMsr.Size = New System.Drawing.Size(42, 16)
        Me.SalPackMsr.TabIndex = 37
        Me.SalPackMsr.Text = "單位"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(117, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 19)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "保存方式"
        '
        '保存方式W
        '
        Me.保存方式W.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.保存方式W.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.保存方式W.FormattingEnabled = True
        Me.保存方式W.Items.AddRange(New Object() {"", "1.冷凍", "2.冷藏", "3.預解", "4."})
        Me.保存方式W.Location = New System.Drawing.Point(121, 42)
        Me.保存方式W.Name = "保存方式W"
        Me.保存方式W.Size = New System.Drawing.Size(81, 27)
        Me.保存方式W.TabIndex = 36
        '
        'DGVOITM
        '
        Me.DGVOITM.AllowUserToAddRows = False
        Me.DGVOITM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVOITM.Location = New System.Drawing.Point(6, 133)
        Me.DGVOITM.Name = "DGVOITM"
        Me.DGVOITM.ReadOnly = True
        Me.DGVOITM.RowHeadersVisible = False
        Me.DGVOITM.RowHeadersWidth = 25
        Me.DGVOITM.RowTemplate.Height = 24
        Me.DGVOITM.Size = New System.Drawing.Size(343, 238)
        Me.DGVOITM.TabIndex = 34
        Me.DGVOITM.TabStop = False
        '
        '查詢T1
        '
        Me.查詢T1.Location = New System.Drawing.Point(184, 102)
        Me.查詢T1.Name = "查詢T1"
        Me.查詢T1.Size = New System.Drawing.Size(90, 25)
        Me.查詢T1.TabIndex = 33
        Me.查詢T1.Text = "查詢品項"
        Me.查詢T1.UseVisualStyleBackColor = True
        '
        '包含查詢
        '
        Me.包含查詢.AutoSize = True
        Me.包含查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.包含查詢.Location = New System.Drawing.Point(9, 107)
        Me.包含查詢.Name = "包含查詢"
        Me.包含查詢.Size = New System.Drawing.Size(95, 20)
        Me.包含查詢.TabIndex = 32
        Me.包含查詢.Text = "包含查詢"
        Me.包含查詢.UseVisualStyleBackColor = True
        '
        '品W3
        '
        Me.品W3.Location = New System.Drawing.Point(9, 75)
        Me.品W3.Name = "品W3"
        Me.品W3.Size = New System.Drawing.Size(100, 27)
        Me.品W3.TabIndex = 31
        '
        '品W2
        '
        Me.品W2.Location = New System.Drawing.Point(9, 42)
        Me.品W2.Name = "品W2"
        Me.品W2.Size = New System.Drawing.Size(100, 27)
        Me.品W2.TabIndex = 30
        '
        '品W1
        '
        Me.品W1.Location = New System.Drawing.Point(9, 9)
        Me.品W1.Name = "品W1"
        Me.品W1.Size = New System.Drawing.Size(100, 27)
        Me.品W1.TabIndex = 29
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ToExcelBtn)
        Me.TabPage2.Controls.Add(Me.ClearBtn)
        Me.TabPage2.Controls.Add(Me.離開T2)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Sumdetail)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(943, 666)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '離開T2
        '
        Me.離開T2.Location = New System.Drawing.Point(845, 6)
        Me.離開T2.Name = "離開T2"
        Me.離開T2.Size = New System.Drawing.Size(90, 25)
        Me.離開T2.TabIndex = 24
        Me.離開T2.Text = "離開"
        Me.離開T2.UseVisualStyleBackColor = True
        '
        '生產需求計算程式
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 657)
        Me.Controls.Add(Me.TabControl1)
        Me.MaximumSize = New System.Drawing.Size(985, 700)
        Me.MinimumSize = New System.Drawing.Size(985, 700)
        Me.Name = "生產需求計算程式"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生產需求明細系統"
        CType(Me.Sumdetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DGVOITM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CalBtn As System.Windows.Forms.Button
    Friend WithEvents Sumdetail As System.Windows.Forms.DataGridView
    Friend WithEvents ItemDetail As System.Windows.Forms.DataGridView
    Friend WithEvents AddBtn As System.Windows.Forms.Button
    Friend WithEvents ItemName As System.Windows.Forms.TextBox
    Friend WithEvents ItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Quty As System.Windows.Forms.TextBox
    Friend WithEvents ItemMain As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToExcelBtn As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ClearBtn As System.Windows.Forms.Button
    Friend WithEvents Quty2 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Quty3 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents 列出明細 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents 包含查詢 As System.Windows.Forms.CheckBox
    Friend WithEvents 品W3 As System.Windows.Forms.TextBox
    Friend WithEvents 品W2 As System.Windows.Forms.TextBox
    Friend WithEvents 品W1 As System.Windows.Forms.TextBox
    Friend WithEvents 查詢T1 As System.Windows.Forms.Button
    Friend WithEvents DGVOITM As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 保存方式W As System.Windows.Forms.ComboBox
    Friend WithEvents SalPackMsr As System.Windows.Forms.Label
    Friend WithEvents 離開T2 As System.Windows.Forms.Button
    Friend WithEvents 設定T1 As System.Windows.Forms.Label

End Class
