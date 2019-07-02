<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產入庫V100
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
        Me.tbxWhsCode = New System.Windows.Forms.TextBox
        Me.ckbWhs = New System.Windows.Forms.CheckBox
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.Label8 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.明細件數 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblOPList = New System.Windows.Forms.Label
        Me.lblOPMain = New System.Windows.Forms.Label
        Me.btnToB1 = New System.Windows.Forms.Button
        Me.dgvSourceList = New System.Windows.Forms.DataGridView
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnsearch = New System.Windows.Forms.Button
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cobSelectType = New System.Windows.Forms.ComboBox
        Me.btnForError = New System.Windows.Forms.Button
        Me.LP01_del = New System.Windows.Forms.Label
        Me.TP01_del = New System.Windows.Forms.TextBox
        Me.BP01_del = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.DocDate2 = New System.Windows.Forms.DateTimePicker
        Me.表身內容 = New System.Windows.Forms.DataGridView
        Me.入庫件數 = New System.Windows.Forms.Label
        Me.入庫重量 = New System.Windows.Forms.Label
        Me.入庫包數 = New System.Windows.Forms.Label
        Me.儲位異常 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.待轉入區 = New System.Windows.Forms.Button
        Me.異常條碼 = New System.Windows.Forms.Label
        Me.Txx1 = New System.Windows.Forms.TextBox
        Me.Txx2 = New System.Windows.Forms.TextBox
        CType(Me.dgvSourceList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.表身內容, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbxWhsCode
        '
        Me.tbxWhsCode.Location = New System.Drawing.Point(599, 522)
        Me.tbxWhsCode.Name = "tbxWhsCode"
        Me.tbxWhsCode.Size = New System.Drawing.Size(70, 22)
        Me.tbxWhsCode.TabIndex = 166
        Me.tbxWhsCode.Text = "P01"
        Me.tbxWhsCode.Visible = False
        '
        'ckbWhs
        '
        Me.ckbWhs.AutoSize = True
        Me.ckbWhs.Location = New System.Drawing.Point(520, 525)
        Me.ckbWhs.Name = "ckbWhs"
        Me.ckbWhs.Size = New System.Drawing.Size(84, 16)
        Me.ckbWhs.TabIndex = 165
        Me.ckbWhs.Text = "指定庫別："
        Me.ckbWhs.UseVisualStyleBackColor = True
        Me.ckbWhs.Visible = False
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(12, 592)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(910, 23)
        Me.PBar1.TabIndex = 162
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(325, 527)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 12)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "過帳日期："
        '
        'DocDate
        '
        Me.DocDate.Location = New System.Drawing.Point(390, 522)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(124, 22)
        Me.DocDate.TabIndex = 159
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(225, 574)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(307, 15)
        Me.Label6.TabIndex = 153
        Me.Label6.Text = "1. 製單沒出現：表示未完工 或 條碼沒同步"
        '
        '明細件數
        '
        Me.明細件數.AutoSize = True
        Me.明細件數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.明細件數.Location = New System.Drawing.Point(783, 515)
        Me.明細件數.Name = "明細件數"
        Me.明細件數.Size = New System.Drawing.Size(76, 16)
        Me.明細件數.TabIndex = 151
        Me.明細件數.Text = "明細件數"
        Me.明細件數.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(4, 574)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 15)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "**請仔細檢查條碼有沒有錯誤"
        '
        'lblOPList
        '
        Me.lblOPList.AutoSize = True
        Me.lblOPList.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblOPList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOPList.Location = New System.Drawing.Point(125, 64)
        Me.lblOPList.Name = "lblOPList"
        Me.lblOPList.Size = New System.Drawing.Size(72, 16)
        Me.lblOPList.TabIndex = 148
        Me.lblOPList.Text = "製單明細"
        '
        'lblOPMain
        '
        Me.lblOPMain.AutoSize = True
        Me.lblOPMain.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblOPMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOPMain.Location = New System.Drawing.Point(13, 64)
        Me.lblOPMain.Name = "lblOPMain"
        Me.lblOPMain.Size = New System.Drawing.Size(40, 16)
        Me.lblOPMain.TabIndex = 147
        Me.lblOPMain.Text = "製單"
        '
        'btnToB1
        '
        Me.btnToB1.Enabled = False
        Me.btnToB1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnToB1.Location = New System.Drawing.Point(677, 537)
        Me.btnToB1.Name = "btnToB1"
        Me.btnToB1.Size = New System.Drawing.Size(95, 44)
        Me.btnToB1.TabIndex = 145
        Me.btnToB1.Text = "回存B1"
        Me.btnToB1.UseVisualStyleBackColor = True
        '
        'dgvSourceList
        '
        Me.dgvSourceList.AllowUserToAddRows = False
        Me.dgvSourceList.AllowUserToDeleteRows = False
        Me.dgvSourceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceList.Location = New System.Drawing.Point(128, 249)
        Me.dgvSourceList.MultiSelect = False
        Me.dgvSourceList.Name = "dgvSourceList"
        Me.dgvSourceList.ReadOnly = True
        Me.dgvSourceList.RowHeadersWidth = 25
        Me.dgvSourceList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSourceList.RowTemplate.Height = 24
        Me.dgvSourceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSourceList.Size = New System.Drawing.Size(803, 263)
        Me.dgvSourceList.TabIndex = 144
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(4, 83)
        Me.dgvSourceMain.MultiSelect = False
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowHeadersWidth = 20
        Me.dgvSourceMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSourceMain.Size = New System.Drawing.Size(121, 429)
        Me.dgvSourceMain.TabIndex = 143
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnsearch)
        Me.Panel1.Controls.Add(Me.RB2)
        Me.Panel1.Controls.Add(Me.RB1)
        Me.Panel1.Location = New System.Drawing.Point(12, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(231, 35)
        Me.Panel1.TabIndex = 168
        '
        'btnsearch
        '
        Me.btnsearch.Location = New System.Drawing.Point(136, 5)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 23)
        Me.btnsearch.TabIndex = 4
        Me.btnsearch.Text = "查詢"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB2.Location = New System.Drawing.Point(72, 5)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(58, 20)
        Me.RB2.TabIndex = 1
        Me.RB2.Text = "加工"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB1.Location = New System.Drawing.Point(6, 5)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(58, 20)
        Me.RB1.TabIndex = 0
        Me.RB1.TabStop = True
        Me.RB1.Text = "電宰"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(325, 551)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "收貨類型："
        '
        'cobSelectType
        '
        Me.cobSelectType.Enabled = False
        Me.cobSelectType.FormattingEnabled = True
        Me.cobSelectType.Items.AddRange(New Object() {"生產收貨", "委外加工收貨"})
        Me.cobSelectType.Location = New System.Drawing.Point(390, 547)
        Me.cobSelectType.Name = "cobSelectType"
        Me.cobSelectType.Size = New System.Drawing.Size(121, 20)
        Me.cobSelectType.TabIndex = 2
        '
        'btnForError
        '
        Me.btnForError.Location = New System.Drawing.Point(540, 546)
        Me.btnForError.Name = "btnForError"
        Me.btnForError.Size = New System.Drawing.Size(92, 23)
        Me.btnForError.TabIndex = 169
        Me.btnForError.Text = "重新更新條碼重量"
        Me.btnForError.UseVisualStyleBackColor = True
        Me.btnForError.Visible = False
        '
        'LP01_del
        '
        Me.LP01_del.AutoSize = True
        Me.LP01_del.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LP01_del.Location = New System.Drawing.Point(526, 12)
        Me.LP01_del.Name = "LP01_del"
        Me.LP01_del.Size = New System.Drawing.Size(59, 13)
        Me.LP01_del.TabIndex = 170
        Me.LP01_del.Text = "刪除庫位"
        Me.LP01_del.Visible = False
        '
        'TP01_del
        '
        Me.TP01_del.Location = New System.Drawing.Point(591, 9)
        Me.TP01_del.Name = "TP01_del"
        Me.TP01_del.Size = New System.Drawing.Size(100, 22)
        Me.TP01_del.TabIndex = 171
        Me.TP01_del.Visible = False
        '
        'BP01_del
        '
        Me.BP01_del.Location = New System.Drawing.Point(697, 7)
        Me.BP01_del.Name = "BP01_del"
        Me.BP01_del.Size = New System.Drawing.Size(75, 23)
        Me.BP01_del.TabIndex = 172
        Me.BP01_del.Text = "刪除"
        Me.BP01_del.UseVisualStyleBackColor = True
        Me.BP01_del.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(203, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 173
        Me.Label7.Text = "查詢完成"
        Me.Label7.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(697, 54)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "查詢"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 554)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 12)
        Me.Label9.TabIndex = 175
        Me.Label9.Text = "急速入庫日期："
        '
        'DocDate2
        '
        Me.DocDate2.Location = New System.Drawing.Point(91, 549)
        Me.DocDate2.Name = "DocDate2"
        Me.DocDate2.Size = New System.Drawing.Size(124, 22)
        Me.DocDate2.TabIndex = 174
        '
        '表身內容
        '
        Me.表身內容.AllowUserToAddRows = False
        Me.表身內容.AllowUserToDeleteRows = False
        Me.表身內容.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.表身內容.Location = New System.Drawing.Point(128, 83)
        Me.表身內容.MultiSelect = False
        Me.表身內容.Name = "表身內容"
        Me.表身內容.ReadOnly = True
        Me.表身內容.RowHeadersWidth = 25
        Me.表身內容.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.表身內容.RowTemplate.Height = 24
        Me.表身內容.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.表身內容.Size = New System.Drawing.Size(803, 162)
        Me.表身內容.TabIndex = 176
        '
        '入庫件數
        '
        Me.入庫件數.AutoSize = True
        Me.入庫件數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫件數.Location = New System.Drawing.Point(4, 515)
        Me.入庫件數.Name = "入庫件數"
        Me.入庫件數.Size = New System.Drawing.Size(76, 16)
        Me.入庫件數.TabIndex = 177
        Me.入庫件數.Text = "入庫件數"
        Me.入庫件數.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '入庫重量
        '
        Me.入庫重量.AutoSize = True
        Me.入庫重量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫重量.Location = New System.Drawing.Point(112, 515)
        Me.入庫重量.Name = "入庫重量"
        Me.入庫重量.Size = New System.Drawing.Size(76, 16)
        Me.入庫重量.TabIndex = 177
        Me.入庫重量.Text = "入庫重量"
        Me.入庫重量.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '入庫包數
        '
        Me.入庫包數.AutoSize = True
        Me.入庫包數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.入庫包數.Location = New System.Drawing.Point(218, 515)
        Me.入庫包數.Name = "入庫包數"
        Me.入庫包數.Size = New System.Drawing.Size(76, 16)
        Me.入庫包數.TabIndex = 178
        Me.入庫包數.Text = "入庫包數"
        Me.入庫包數.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.入庫包數.Visible = False
        '
        '儲位異常
        '
        Me.儲位異常.AutoSize = True
        Me.儲位異常.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.儲位異常.Location = New System.Drawing.Point(783, 537)
        Me.儲位異常.Name = "儲位異常"
        Me.儲位異常.Size = New System.Drawing.Size(112, 16)
        Me.儲位異常.TabIndex = 179
        Me.儲位異常.Text = "儲位異常：  0"
        Me.儲位異常.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(285, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label3.Visible = False
        '
        '待轉入區
        '
        Me.待轉入區.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.待轉入區.Location = New System.Drawing.Point(856, 4)
        Me.待轉入區.Name = "待轉入區"
        Me.待轉入區.Size = New System.Drawing.Size(75, 41)
        Me.待轉入區.TabIndex = 5
        Me.待轉入區.Text = "待轉" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "入區"
        Me.待轉入區.UseVisualStyleBackColor = True
        '
        '異常條碼
        '
        Me.異常條碼.AutoSize = True
        Me.異常條碼.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold)
        Me.異常條碼.Location = New System.Drawing.Point(783, 554)
        Me.異常條碼.Name = "異常條碼"
        Me.異常條碼.Size = New System.Drawing.Size(112, 16)
        Me.異常條碼.TabIndex = 181
        Me.異常條碼.Text = "異常條碼：  0"
        Me.異常條碼.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Txx1
        '
        Me.Txx1.Location = New System.Drawing.Point(348, 3)
        Me.Txx1.Name = "Txx1"
        Me.Txx1.Size = New System.Drawing.Size(172, 22)
        Me.Txx1.TabIndex = 182
        Me.Txx1.Visible = False
        '
        'Txx2
        '
        Me.Txx2.Location = New System.Drawing.Point(348, 26)
        Me.Txx2.Name = "Txx2"
        Me.Txx2.Size = New System.Drawing.Size(172, 22)
        Me.Txx2.TabIndex = 183
        Me.Txx2.Visible = False
        '
        '生產入庫V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 622)
        Me.Controls.Add(Me.Txx2)
        Me.Controls.Add(Me.Txx1)
        Me.Controls.Add(Me.異常條碼)
        Me.Controls.Add(Me.待轉入區)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.儲位異常)
        Me.Controls.Add(Me.入庫包數)
        Me.Controls.Add(Me.入庫重量)
        Me.Controls.Add(Me.入庫件數)
        Me.Controls.Add(Me.表身內容)
        Me.Controls.Add(Me.DocDate2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BP01_del)
        Me.Controls.Add(Me.TP01_del)
        Me.Controls.Add(Me.LP01_del)
        Me.Controls.Add(Me.btnForError)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cobSelectType)
        Me.Controls.Add(Me.tbxWhsCode)
        Me.Controls.Add(Me.ckbWhs)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.明細件數)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblOPList)
        Me.Controls.Add(Me.lblOPMain)
        Me.Controls.Add(Me.btnToB1)
        Me.Controls.Add(Me.dgvSourceList)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Name = "生產入庫V100"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生產入庫-製單"
        CType(Me.dgvSourceList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.表身內容, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbxWhsCode As System.Windows.Forms.TextBox
    Friend WithEvents ckbWhs As System.Windows.Forms.CheckBox
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 明細件數 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOPList As System.Windows.Forms.Label
    Friend WithEvents lblOPMain As System.Windows.Forms.Label
    Friend WithEvents btnToB1 As System.Windows.Forms.Button
    Friend WithEvents dgvSourceList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnForError As System.Windows.Forms.Button
    Friend WithEvents LP01_del As System.Windows.Forms.Label
    Friend WithEvents TP01_del As System.Windows.Forms.TextBox
    Friend WithEvents BP01_del As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DocDate2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents cobSelectType As System.Windows.Forms.ComboBox
    Friend WithEvents 表身內容 As System.Windows.Forms.DataGridView
    Friend WithEvents 入庫件數 As System.Windows.Forms.Label
    Friend WithEvents 入庫重量 As System.Windows.Forms.Label
    Friend WithEvents 入庫包數 As System.Windows.Forms.Label
    Friend WithEvents 儲位異常 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 待轉入區 As System.Windows.Forms.Button
    Friend WithEvents 異常條碼 As System.Windows.Forms.Label
    Friend WithEvents Txx1 As System.Windows.Forms.TextBox
    Friend WithEvents Txx2 As System.Windows.Forms.TextBox
End Class
