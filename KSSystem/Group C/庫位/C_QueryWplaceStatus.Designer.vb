<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QueryWplaceStatus
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.btnSearch1 = New System.Windows.Forms.Button
        Me.btnToExcel1 = New System.Windows.Forms.Button
        Me.btnSearch2 = New System.Windows.Forms.Button
        Me.btnToExcel2 = New System.Windows.Forms.Button
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(418, 330)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "項"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(390, 330)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 12)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(352, 330)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "共"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(194, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 12)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "沒空的儲位："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "空儲位："
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(196, 26)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.Size = New System.Drawing.Size(239, 301)
        Me.DataGridView2.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(153, 330)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "項"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 330)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(17, 12)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "共"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 26)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(166, 301)
        Me.DataGridView1.TabIndex = 30
        '
        'btnSearch1
        '
        Me.btnSearch1.Location = New System.Drawing.Point(15, 352)
        Me.btnSearch1.Name = "btnSearch1"
        Me.btnSearch1.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch1.TabIndex = 40
        Me.btnSearch1.Text = "查詢"
        Me.btnSearch1.UseVisualStyleBackColor = True
        '
        'btnToExcel1
        '
        Me.btnToExcel1.Location = New System.Drawing.Point(103, 352)
        Me.btnToExcel1.Name = "btnToExcel1"
        Me.btnToExcel1.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel1.TabIndex = 41
        Me.btnToExcel1.Text = "匯出Excel"
        Me.btnToExcel1.UseVisualStyleBackColor = True
        '
        'btnSearch2
        '
        Me.btnSearch2.Location = New System.Drawing.Point(279, 352)
        Me.btnSearch2.Name = "btnSearch2"
        Me.btnSearch2.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch2.TabIndex = 42
        Me.btnSearch2.Text = "查詢"
        Me.btnSearch2.UseVisualStyleBackColor = True
        '
        'btnToExcel2
        '
        Me.btnToExcel2.Location = New System.Drawing.Point(360, 352)
        Me.btnToExcel2.Name = "btnToExcel2"
        Me.btnToExcel2.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel2.TabIndex = 43
        Me.btnToExcel2.Text = "匯出Excel"
        Me.btnToExcel2.UseVisualStyleBackColor = True
        '
        'C_QueryWplaceStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 388)
        Me.Controls.Add(Me.btnToExcel2)
        Me.Controls.Add(Me.btnSearch2)
        Me.Controls.Add(Me.btnToExcel1)
        Me.Controls.Add(Me.btnSearch1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "C_QueryWplaceStatus"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查詢目前儲位狀況"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch1 As System.Windows.Forms.Button
    Friend WithEvents btnToExcel1 As System.Windows.Forms.Button
    Friend WithEvents btnSearch2 As System.Windows.Forms.Button
    Friend WithEvents btnToExcel2 As System.Windows.Forms.Button
End Class
