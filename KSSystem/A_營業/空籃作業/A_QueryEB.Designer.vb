<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_QueryEB
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.SelectType = New System.Windows.Forms.ComboBox
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.btnToReport = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.U_CarDr1 = New System.Windows.Forms.ComboBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(252, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "至"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "類型："
        '
        'SelectType
        '
        Me.SelectType.FormattingEnabled = True
        Me.SelectType.Items.AddRange(New Object() {"發出明細表", "發出統計表", "回收明細表", "回收統計表", "調整明細表", "調整統計表", "回收人回收明細表", "回收人回收統計表", "空籃餘數統計表", "客戶對帳餘額表"})
        Me.SelectType.Location = New System.Drawing.Point(74, 7)
        Me.SelectType.Name = "SelectType"
        Me.SelectType.Size = New System.Drawing.Size(175, 20)
        Me.SelectType.TabIndex = 98
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(282, 33)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(130, 22)
        Me.ToDate.TabIndex = 97
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(119, 33)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(130, 22)
        Me.FromDate.TabIndex = 96
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(647, 59)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 95
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(566, 477)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 102
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'btnToReport
        '
        Me.btnToReport.Location = New System.Drawing.Point(647, 477)
        Me.btnToReport.Name = "btnToReport"
        Me.btnToReport.Size = New System.Drawing.Size(75, 23)
        Me.btnToReport.TabIndex = 103
        Me.btnToReport.Text = "匯出報表"
        Me.btnToReport.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 88)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(710, 383)
        Me.DGV1.TabIndex = 104
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(12, 33)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox1.TabIndex = 105
        Me.CheckBox1.Text = "資料期間："
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(12, 59)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox2.TabIndex = 106
        Me.CheckBox2.Text = "客戶編號："
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(119, 58)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(130, 22)
        Me.CardCode.TabIndex = 107
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(255, 59)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox3.TabIndex = 108
        Me.CheckBox3.Text = "司機："
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'U_CarDr1
        '
        Me.U_CarDr1.FormattingEnabled = True
        Me.U_CarDr1.Location = New System.Drawing.Point(330, 59)
        Me.U_CarDr1.Name = "U_CarDr1"
        Me.U_CarDr1.Size = New System.Drawing.Size(135, 20)
        Me.U_CarDr1.TabIndex = 118
        '
        'A_QueryEB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 512)
        Me.Controls.Add(Me.U_CarDr1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.btnToReport)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SelectType)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "A_QueryEB"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "報表查詢列印"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SelectType As System.Windows.Forms.ComboBox
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents btnToReport As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents U_CarDr1 As System.Windows.Forms.ComboBox
End Class
