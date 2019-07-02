<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QckAddChickenOutOIGE
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
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dateDocDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvByM03 = New System.Windows.Forms.DataGridView
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtM7 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbM03 = New System.Windows.Forms.Label
        Me.txtM12 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtItemCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgvByM03, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(195, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 82
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dateDocDate
        '
        Me.dateDocDate.Location = New System.Drawing.Point(70, 12)
        Me.dateDocDate.Name = "dateDocDate"
        Me.dateDocDate.Size = New System.Drawing.Size(120, 22)
        Me.dateDocDate.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "日期："
        '
        'dgvByM03
        '
        Me.dgvByM03.AllowUserToAddRows = False
        Me.dgvByM03.AllowUserToDeleteRows = False
        Me.dgvByM03.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvByM03.Location = New System.Drawing.Point(12, 41)
        Me.dgvByM03.Name = "dgvByM03"
        Me.dgvByM03.ReadOnly = True
        Me.dgvByM03.RowHeadersVisible = False
        Me.dgvByM03.RowTemplate.Height = 24
        Me.dgvByM03.Size = New System.Drawing.Size(760, 222)
        Me.dgvByM03.TabIndex = 172
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(697, 269)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 173
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(98, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 12)
        Me.Label18.TabIndex = 181
        Me.Label18.Text = "(磅單重)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 174
        Me.Label14.Text = "投入重量："
        '
        'txtM7
        '
        Me.txtM7.Location = New System.Drawing.Point(100, 79)
        Me.txtM7.Name = "txtM7"
        Me.txtM7.Size = New System.Drawing.Size(100, 22)
        Me.txtM7.TabIndex = 175
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(301, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 12)
        Me.Label16.TabIndex = 180
        Me.Label16.Text = "(磅單羽數)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(206, 82)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 176
        Me.Label11.Text = "投入隻數："
        '
        'lbM03
        '
        Me.lbM03.AutoSize = True
        Me.lbM03.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbM03.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbM03.Location = New System.Drawing.Point(97, 9)
        Me.lbM03.Name = "lbM03"
        Me.lbM03.Size = New System.Drawing.Size(0, 16)
        Me.lbM03.TabIndex = 179
        '
        'txtM12
        '
        Me.txtM12.Location = New System.Drawing.Point(297, 79)
        Me.txtM12.Name = "txtM12"
        Me.txtM12.Size = New System.Drawing.Size(100, 22)
        Me.txtM12.TabIndex = 177
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 178
        Me.Label8.Text = "製單編號："
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.SaveBtn)
        Me.Panel1.Controls.Add(Me.txtItemName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtItemCode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtM12)
        Me.Panel1.Controls.Add(Me.txtM7)
        Me.Panel1.Controls.Add(Me.lbM03)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(12, 269)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 176)
        Me.Panel1.TabIndex = 182
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "回填至發貨單："
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(125, 140)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 186
        Me.SaveBtn.Text = "回填"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(297, 45)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(100, 22)
        Me.txtItemName.TabIndex = 185
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(238, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 184
        Me.Label3.Text = "品名："
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(99, 45)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(100, 22)
        Me.txtItemCode.TabIndex = 183
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(37, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "存編："
        '
        'C_QckAddChickenOutOIGE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 454)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvByM03)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "C_QckAddChickenOutOIGE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "毛雞出貨"
        CType(Me.dgvByM03, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dateDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvByM03 As System.Windows.Forms.DataGridView
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtM7 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lbM03 As System.Windows.Forms.Label
    Friend WithEvents txtM12 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
End Class
