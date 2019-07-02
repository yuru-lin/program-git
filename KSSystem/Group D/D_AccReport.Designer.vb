<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D_AccReport
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
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToExcelBtn1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.DocType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(619, 11)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(120, 22)
        Me.ToDate.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(592, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "至"
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(469, 11)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(120, 22)
        Me.FromDate.TabIndex = 55
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(378, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "資料期間："
        '
        'ToExcelBtn1
        '
        Me.ToExcelBtn1.Location = New System.Drawing.Point(897, 629)
        Me.ToExcelBtn1.Name = "ToExcelBtn1"
        Me.ToExcelBtn1.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn1.TabIndex = 53
        Me.ToExcelBtn1.Text = "匯出Excel"
        Me.ToExcelBtn1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "資料："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 50)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DGV1.Size = New System.Drawing.Size(960, 573)
        Me.DGV1.TabIndex = 51
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(742, 11)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 50
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'DocType
        '
        Me.DocType.FormattingEnabled = True
        Me.DocType.Items.AddRange(New Object() {"收貨採購單", "採購退貨", "A\P貸項", "銷售交貨", "銷售退貨", "A\R貸項", "收貨", "發貨", "AP 發票", "AR發票"})
        Me.DocType.Location = New System.Drawing.Point(255, 12)
        Me.DocType.Name = "DocType"
        Me.DocType.Size = New System.Drawing.Size(120, 20)
        Me.DocType.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(164, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "文件類型："
        '
        'D_AccReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToExcelBtn1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.DocType)
        Me.Controls.Add(Me.Label1)
        Me.Name = "D_AccReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "會科報表"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToExcelBtn1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents DocType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
