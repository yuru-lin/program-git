<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_查詢出庫資料
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
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.btnsearch = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Date1 = New System.Windows.Forms.DateTimePicker
        Me.Date2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(3, 34)
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.Size = New System.Drawing.Size(928, 575)
        Me.dgvSourceMain.TabIndex = 85
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(805, 5)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 170
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'btnsearch
        '
        Me.btnsearch.Location = New System.Drawing.Point(401, 5)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 23)
        Me.btnsearch.TabIndex = 49
        Me.btnsearch.Text = "查詢"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(218, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "至"
        '
        'Date1
        '
        Me.Date1.Location = New System.Drawing.Point(87, 6)
        Me.Date1.Name = "Date1"
        Me.Date1.Size = New System.Drawing.Size(125, 22)
        Me.Date1.TabIndex = 177
        '
        'Date2
        '
        Me.Date2.Location = New System.Drawing.Point(248, 7)
        Me.Date2.Name = "Date2"
        Me.Date2.Size = New System.Drawing.Size(136, 22)
        Me.Date2.TabIndex = 178
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "開始日期"
        '
        'C_查詢出庫資料
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 612)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Date2)
        Me.Controls.Add(Me.btnsearch)
        Me.Controls.Add(Me.Date1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Name = "C_查詢出庫資料"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查詢出庫資料"
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Date1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Date2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
