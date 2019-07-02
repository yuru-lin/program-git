<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QueryOIGEByU_CK02
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
        Me.txtM03 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtM12 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtM7 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.lbM03 = New System.Windows.Forms.Label
        Me.lbDocNum = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.txtM99 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtM03
        '
        Me.txtM03.Location = New System.Drawing.Point(193, 12)
        Me.txtM03.Name = "txtM03"
        Me.txtM03.Size = New System.Drawing.Size(111, 22)
        Me.txtM03.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(105, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "製造單號："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM12
        '
        Me.txtM12.Location = New System.Drawing.Point(336, 387)
        Me.txtM12.Name = "txtM12"
        Me.txtM12.Size = New System.Drawing.Size(111, 22)
        Me.txtM12.TabIndex = 68
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(241, 390)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "投入隻數："
        '
        'txtM7
        '
        Me.txtM7.Location = New System.Drawing.Point(108, 387)
        Me.txtM7.Name = "txtM7"
        Me.txtM7.Size = New System.Drawing.Size(111, 22)
        Me.txtM7.TabIndex = 66
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 390)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "投入重量："
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(397, 443)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 71
        Me.SaveBtn.Text = "更新"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(304, 12)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 72
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 41)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(460, 303)
        Me.DGV1.TabIndex = 73
        '
        'lbM03
        '
        Me.lbM03.AutoSize = True
        Me.lbM03.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbM03.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbM03.Location = New System.Drawing.Point(335, 357)
        Me.lbM03.Name = "lbM03"
        Me.lbM03.Size = New System.Drawing.Size(0, 16)
        Me.lbM03.TabIndex = 77
        '
        'lbDocNum
        '
        Me.lbDocNum.AutoSize = True
        Me.lbDocNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbDocNum.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbDocNum.Location = New System.Drawing.Point(107, 357)
        Me.lbDocNum.Name = "lbDocNum"
        Me.lbDocNum.Size = New System.Drawing.Size(0, 16)
        Me.lbDocNum.TabIndex = 76
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(241, 357)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "製單編號："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 357)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "文件號碼："
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(304, 443)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 78
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'txtM99
        '
        Me.txtM99.Location = New System.Drawing.Point(108, 415)
        Me.txtM99.Name = "txtM99"
        Me.txtM99.Size = New System.Drawing.Size(111, 22)
        Me.txtM99.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 418)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "領料件數："
        '
        'B_QueryOIGEByU_CK02
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 476)
        Me.Controls.Add(Me.txtM99)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.lbM03)
        Me.Controls.Add(Me.lbDocNum)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.txtM12)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtM7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtM03)
        Me.Controls.Add(Me.Label5)
        Me.Name = "B_QueryOIGEByU_CK02"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查詢領料單-依製單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtM03 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtM12 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtM7 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbM03 As System.Windows.Forms.Label
    Friend WithEvents lbDocNum As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents txtM99 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
