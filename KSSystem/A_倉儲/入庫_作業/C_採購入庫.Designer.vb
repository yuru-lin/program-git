<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_InB1ByPurchase
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cobSelectType = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbxWhsCode = New System.Windows.Forms.TextBox
        Me.ckbWhs = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnToB1 = New System.Windows.Forms.Button
        Me.dgvBarcode = New System.Windows.Forms.DataGridView
        Me.lblBarcode = New System.Windows.Forms.Label
        Me.lblOPList = New System.Windows.Forms.Label
        Me.dgvSourceList = New System.Windows.Forms.DataGridView
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.lblOPMain = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSourceList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cobSelectType)
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(5, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(310, 35)
        Me.Panel1.TabIndex = 175
        '
        'cobSelectType
        '
        Me.cobSelectType.FormattingEnabled = True
        Me.cobSelectType.Items.AddRange(New Object() {"採購入庫"})
        Me.cobSelectType.Location = New System.Drawing.Point(87, 6)
        Me.cobSelectType.Name = "cobSelectType"
        Me.cobSelectType.Size = New System.Drawing.Size(121, 20)
        Me.cobSelectType.TabIndex = 4
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(214, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(3, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "入庫類型："
        '
        'tbxWhsCode
        '
        Me.tbxWhsCode.Location = New System.Drawing.Point(613, 458)
        Me.tbxWhsCode.Name = "tbxWhsCode"
        Me.tbxWhsCode.Size = New System.Drawing.Size(92, 22)
        Me.tbxWhsCode.TabIndex = 174
        Me.tbxWhsCode.Text = "P01"
        Me.tbxWhsCode.Visible = False
        '
        'ckbWhs
        '
        Me.ckbWhs.AutoSize = True
        Me.ckbWhs.Location = New System.Drawing.Point(613, 437)
        Me.ckbWhs.Name = "ckbWhs"
        Me.ckbWhs.Size = New System.Drawing.Size(72, 16)
        Me.ckbWhs.TabIndex = 173
        Me.ckbWhs.Text = "特別庫別"
        Me.ckbWhs.UseVisualStyleBackColor = True
        Me.ckbWhs.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(743, 338)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 172
        Me.Label7.Text = "項"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(700, 338)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 171
        Me.Label8.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(657, 338)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = "共"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(610, 418)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 12)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "*請確認條碼是否正確!"
        Me.Label1.Visible = False
        '
        'btnToB1
        '
        Me.btnToB1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnToB1.Location = New System.Drawing.Point(674, 522)
        Me.btnToB1.Name = "btnToB1"
        Me.btnToB1.Size = New System.Drawing.Size(95, 37)
        Me.btnToB1.TabIndex = 167
        Me.btnToB1.Text = "回存B1"
        Me.btnToB1.UseVisualStyleBackColor = True
        '
        'dgvBarcode
        '
        Me.dgvBarcode.AllowUserToAddRows = False
        Me.dgvBarcode.AllowUserToDeleteRows = False
        Me.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBarcode.Location = New System.Drawing.Point(5, 357)
        Me.dgvBarcode.MultiSelect = False
        Me.dgvBarcode.Name = "dgvBarcode"
        Me.dgvBarcode.ReadOnly = True
        Me.dgvBarcode.RowHeadersWidth = 25
        Me.dgvBarcode.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvBarcode.RowTemplate.Height = 24
        Me.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBarcode.Size = New System.Drawing.Size(599, 202)
        Me.dgvBarcode.TabIndex = 164
        '
        'lblBarcode
        '
        Me.lblBarcode.AutoSize = True
        Me.lblBarcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblBarcode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblBarcode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblBarcode.Location = New System.Drawing.Point(5, 338)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(52, 16)
        Me.lblBarcode.TabIndex = 166
        Me.lblBarcode.Text = "3.條碼"
        '
        'lblOPList
        '
        Me.lblOPList.AutoSize = True
        Me.lblOPList.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblOPList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOPList.Location = New System.Drawing.Point(295, 41)
        Me.lblOPList.Name = "lblOPList"
        Me.lblOPList.Size = New System.Drawing.Size(84, 16)
        Me.lblOPList.TabIndex = 165
        Me.lblOPList.Text = "2.入庫清單"
        '
        'dgvSourceList
        '
        Me.dgvSourceList.AllowUserToAddRows = False
        Me.dgvSourceList.AllowUserToDeleteRows = False
        Me.dgvSourceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceList.Location = New System.Drawing.Point(292, 60)
        Me.dgvSourceList.MultiSelect = False
        Me.dgvSourceList.Name = "dgvSourceList"
        Me.dgvSourceList.ReadOnly = True
        Me.dgvSourceList.RowHeadersWidth = 25
        Me.dgvSourceList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSourceList.RowTemplate.Height = 24
        Me.dgvSourceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSourceList.Size = New System.Drawing.Size(477, 275)
        Me.dgvSourceList.TabIndex = 163
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(5, 60)
        Me.dgvSourceMain.MultiSelect = False
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowHeadersWidth = 20
        Me.dgvSourceMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSourceMain.Size = New System.Drawing.Size(281, 275)
        Me.dgvSourceMain.TabIndex = 162
        '
        'lblOPMain
        '
        Me.lblOPMain.AutoSize = True
        Me.lblOPMain.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblOPMain.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOPMain.Location = New System.Drawing.Point(5, 41)
        Me.lblOPMain.Name = "lblOPMain"
        Me.lblOPMain.Size = New System.Drawing.Size(68, 16)
        Me.lblOPMain.TabIndex = 161
        Me.lblOPMain.Text = "1.入庫單"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(647, 8)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(122, 17)
        Me.DataGridView1.TabIndex = 169
        Me.DataGridView1.Visible = False
        '
        'C_InB1ByPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 571)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbxWhsCode)
        Me.Controls.Add(Me.ckbWhs)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnToB1)
        Me.Controls.Add(Me.dgvBarcode)
        Me.Controls.Add(Me.lblBarcode)
        Me.Controls.Add(Me.lblOPList)
        Me.Controls.Add(Me.dgvSourceList)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.lblOPMain)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "C_InB1ByPurchase"
        Me.Text = "採購入庫"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSourceList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cobSelectType As System.Windows.Forms.ComboBox
    Friend WithEvents tbxWhsCode As System.Windows.Forms.TextBox
    Friend WithEvents ckbWhs As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnToB1 As System.Windows.Forms.Button
    Friend WithEvents dgvBarcode As System.Windows.Forms.DataGridView
    Friend WithEvents lblBarcode As System.Windows.Forms.Label
    Friend WithEvents lblOPList As System.Windows.Forms.Label
    Friend WithEvents dgvSourceList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents lblOPMain As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
