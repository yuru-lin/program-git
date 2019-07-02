<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QueryFromSpace
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
        Me.locView = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgvSpaceDetail = New System.Windows.Forms.DataGridView
        Me.txtSpace = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnToExcel1 = New System.Windows.Forms.Button
        Me.btnToExcel2 = New System.Windows.Forms.Button
        Me.rbt2 = New System.Windows.Forms.RadioButton
        Me.rbt1 = New System.Windows.Forms.RadioButton
        Me.btnDetail = New System.Windows.Forms.Button
        Me.btnFromExcel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rbchose1 = New System.Windows.Forms.RadioButton
        Me.rbchose2 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        CType(Me.locView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSpaceDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'locView
        '
        Me.locView.AllowUserToAddRows = False
        Me.locView.AllowUserToDeleteRows = False
        Me.locView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locView.Location = New System.Drawing.Point(12, 28)
        Me.locView.Name = "locView"
        Me.locView.ReadOnly = True
        Me.locView.RowHeadersVisible = False
        Me.locView.RowTemplate.Height = 24
        Me.locView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.locView.Size = New System.Drawing.Size(332, 400)
        Me.locView.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "儲位條碼："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(347, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "調庫記錄："
        '
        'dgvSpaceDetail
        '
        Me.dgvSpaceDetail.AllowUserToAddRows = False
        Me.dgvSpaceDetail.AllowUserToDeleteRows = False
        Me.dgvSpaceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpaceDetail.Location = New System.Drawing.Point(350, 28)
        Me.dgvSpaceDetail.Name = "dgvSpaceDetail"
        Me.dgvSpaceDetail.ReadOnly = True
        Me.dgvSpaceDetail.RowHeadersVisible = False
        Me.dgvSpaceDetail.RowTemplate.Height = 24
        Me.dgvSpaceDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSpaceDetail.Size = New System.Drawing.Size(422, 400)
        Me.dgvSpaceDetail.TabIndex = 3
        '
        'txtSpace
        '
        Me.txtSpace.Location = New System.Drawing.Point(77, 35)
        Me.txtSpace.Name = "txtSpace"
        Me.txtSpace.Size = New System.Drawing.Size(100, 22)
        Me.txtSpace.TabIndex = 5
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(177, 35)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnToExcel1
        '
        Me.btnToExcel1.Location = New System.Drawing.Point(269, 434)
        Me.btnToExcel1.Name = "btnToExcel1"
        Me.btnToExcel1.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel1.TabIndex = 7
        Me.btnToExcel1.Text = "匯出Excel"
        Me.btnToExcel1.UseVisualStyleBackColor = True
        '
        'btnToExcel2
        '
        Me.btnToExcel2.Location = New System.Drawing.Point(697, 434)
        Me.btnToExcel2.Name = "btnToExcel2"
        Me.btnToExcel2.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel2.TabIndex = 8
        Me.btnToExcel2.Text = "匯出Excel"
        Me.btnToExcel2.UseVisualStyleBackColor = True
        '
        'rbt2
        '
        Me.rbt2.AutoSize = True
        Me.rbt2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.rbt2.Location = New System.Drawing.Point(78, 7)
        Me.rbt2.Name = "rbt2"
        Me.rbt2.Size = New System.Drawing.Size(58, 20)
        Me.rbt2.TabIndex = 111
        Me.rbt2.Text = "加工"
        Me.rbt2.UseVisualStyleBackColor = True
        '
        'rbt1
        '
        Me.rbt1.AutoSize = True
        Me.rbt1.Checked = True
        Me.rbt1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.rbt1.Location = New System.Drawing.Point(11, 7)
        Me.rbt1.Name = "rbt1"
        Me.rbt1.Size = New System.Drawing.Size(58, 20)
        Me.rbt1.TabIndex = 110
        Me.rbt1.TabStop = True
        Me.rbt1.Text = "電宰"
        Me.rbt1.UseVisualStyleBackColor = True
        '
        'btnDetail
        '
        Me.btnDetail.Enabled = False
        Me.btnDetail.Location = New System.Drawing.Point(300, 519)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(75, 23)
        Me.btnDetail.TabIndex = 112
        Me.btnDetail.Text = "分析"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'btnFromExcel
        '
        Me.btnFromExcel.Enabled = False
        Me.btnFromExcel.Location = New System.Drawing.Point(109, 9)
        Me.btnFromExcel.Name = "btnFromExcel"
        Me.btnFromExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnFromExcel.TabIndex = 114
        Me.btnFromExcel.Text = "匯入Excel"
        Me.btnFromExcel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.rbt2)
        Me.Panel1.Controls.Add(Me.rbt1)
        Me.Panel1.Location = New System.Drawing.Point(12, 434)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 35)
        Me.Panel1.TabIndex = 115
        '
        'rbchose1
        '
        Me.rbchose1.AutoSize = True
        Me.rbchose1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbchose1.Location = New System.Drawing.Point(3, 10)
        Me.rbchose1.Name = "rbchose1"
        Me.rbchose1.Size = New System.Drawing.Size(106, 20)
        Me.rbchose1.TabIndex = 116
        Me.rbchose1.TabStop = True
        Me.rbchose1.Text = "自選條碼："
        Me.rbchose1.UseVisualStyleBackColor = True
        '
        'rbchose2
        '
        Me.rbchose2.AutoSize = True
        Me.rbchose2.Checked = True
        Me.rbchose2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.rbchose2.Location = New System.Drawing.Point(3, 36)
        Me.rbchose2.Name = "rbchose2"
        Me.rbchose2.Size = New System.Drawing.Size(74, 20)
        Me.rbchose2.TabIndex = 117
        Me.rbchose2.TabStop = True
        Me.rbchose2.Text = "儲位："
        Me.rbchose2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.rbchose1)
        Me.Panel2.Controls.Add(Me.rbchose2)
        Me.Panel2.Controls.Add(Me.btnFromExcel)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.txtSpace)
        Me.Panel2.Location = New System.Drawing.Point(12, 475)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(271, 67)
        Me.Panel2.TabIndex = 118
        '
        'C_QueryFromSpace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.btnToExcel2)
        Me.Controls.Add(Me.btnToExcel1)
        Me.Controls.Add(Me.dgvSpaceDetail)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.locView)
        Me.Name = "C_QueryFromSpace"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查詢儲位條碼調庫記錄"
        CType(Me.locView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSpaceDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents locView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvSpaceDetail As System.Windows.Forms.DataGridView
    Friend WithEvents txtSpace As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnToExcel1 As System.Windows.Forms.Button
    Friend WithEvents btnToExcel2 As System.Windows.Forms.Button
    Friend WithEvents rbt2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbt1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnDetail As System.Windows.Forms.Button
    Friend WithEvents btnFromExcel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbchose1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbchose2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
