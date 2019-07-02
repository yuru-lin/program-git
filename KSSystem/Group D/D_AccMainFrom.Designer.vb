<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D_AccMainFrom
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.ToExcelBtn3 = New System.Windows.Forms.Button
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.SubSum = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.AddSum = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.OpeningSum = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.NameTab = New System.Windows.Forms.Label
        Me.AccSum = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ToExcelBtn1 = New System.Windows.Forms.Button
        Me.ToExcelBtn2 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.AccNum = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.AccType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(542, 338)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "分錄："
        '
        'ToExcelBtn3
        '
        Me.ToExcelBtn3.Location = New System.Drawing.Point(898, 626)
        Me.ToExcelBtn3.Name = "ToExcelBtn3"
        Me.ToExcelBtn3.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn3.TabIndex = 56
        Me.ToExcelBtn3.Text = "匯出Excel"
        Me.ToExcelBtn3.UseVisualStyleBackColor = True
        '
        'DGV3
        '
        Me.DGV3.AllowUserToAddRows = False
        Me.DGV3.AllowUserToDeleteRows = False
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(545, 360)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.ReadOnly = True
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV3.Size = New System.Drawing.Size(428, 260)
        Me.DGV3.TabIndex = 55
        '
        'SubSum
        '
        Me.SubSum.AutoSize = True
        Me.SubSum.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SubSum.ForeColor = System.Drawing.Color.Green
        Me.SubSum.Location = New System.Drawing.Point(695, 48)
        Me.SubSum.Name = "SubSum"
        Me.SubSum.Size = New System.Drawing.Size(13, 13)
        Me.SubSum.TabIndex = 54
        Me.SubSum.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Green
        Me.Label14.Location = New System.Drawing.Point(591, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "本期貸項總額："
        '
        'AddSum
        '
        Me.AddSum.AutoSize = True
        Me.AddSum.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.AddSum.ForeColor = System.Drawing.Color.Green
        Me.AddSum.Location = New System.Drawing.Point(502, 48)
        Me.AddSum.Name = "AddSum"
        Me.AddSum.Size = New System.Drawing.Size(13, 13)
        Me.AddSum.TabIndex = 52
        Me.AddSum.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Green
        Me.Label12.Location = New System.Drawing.Point(398, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "本期借項總額："
        '
        'OpeningSum
        '
        Me.OpeningSum.AutoSize = True
        Me.OpeningSum.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.OpeningSum.ForeColor = System.Drawing.Color.Green
        Me.OpeningSum.Location = New System.Drawing.Point(309, 48)
        Me.OpeningSum.Name = "OpeningSum"
        Me.OpeningSum.Size = New System.Drawing.Size(13, 13)
        Me.OpeningSum.TabIndex = 50
        Me.OpeningSum.Text = "0"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Green
        Me.Label10.Location = New System.Drawing.Point(231, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "期初總額："
        '
        'NameTab
        '
        Me.NameTab.AutoSize = True
        Me.NameTab.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.NameTab.Location = New System.Drawing.Point(75, 341)
        Me.NameTab.Name = "NameTab"
        Me.NameTab.Size = New System.Drawing.Size(0, 16)
        Me.NameTab.TabIndex = 48
        '
        'AccSum
        '
        Me.AccSum.AutoSize = True
        Me.AccSum.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.AccSum.ForeColor = System.Drawing.Color.Green
        Me.AccSum.Location = New System.Drawing.Point(875, 48)
        Me.AccSum.Name = "AccSum"
        Me.AccSum.Size = New System.Drawing.Size(13, 13)
        Me.AccSum.TabIndex = 46
        Me.AccSum.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(784, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "期末總餘額："
        '
        'ToExcelBtn1
        '
        Me.ToExcelBtn1.Location = New System.Drawing.Point(898, 331)
        Me.ToExcelBtn1.Name = "ToExcelBtn1"
        Me.ToExcelBtn1.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn1.TabIndex = 44
        Me.ToExcelBtn1.Text = "匯出Excel"
        Me.ToExcelBtn1.UseVisualStyleBackColor = True
        '
        'ToExcelBtn2
        '
        Me.ToExcelBtn2.Location = New System.Drawing.Point(464, 626)
        Me.ToExcelBtn2.Name = "ToExcelBtn2"
        Me.ToExcelBtn2.Size = New System.Drawing.Size(75, 23)
        Me.ToExcelBtn2.TabIndex = 43
        Me.ToExcelBtn2.Text = "匯出Excel"
        Me.ToExcelBtn2.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(14, 360)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(525, 260)
        Me.DGV2.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "明細："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "資料："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(13, 65)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(960, 260)
        Me.DGV1.TabIndex = 39
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(898, 10)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 38
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(701, 10)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(120, 22)
        Me.ToDate.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(671, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "至"
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(545, 10)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(120, 22)
        Me.FromDate.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(451, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "資料期間："
        '
        'AccNum
        '
        Me.AccNum.FormattingEnabled = True
        Me.AccNum.Location = New System.Drawing.Point(325, 11)
        Me.AccNum.Name = "AccNum"
        Me.AccNum.Size = New System.Drawing.Size(120, 20)
        Me.AccNum.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(231, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "總帳科目："
        '
        'AccType
        '
        Me.AccType.FormattingEnabled = True
        Me.AccType.Items.AddRange(New Object() {"應收付帳款", "應收付票據", "預收付貨款訂金請求", "預收付貨款訂金發票", "暫估應付帳款"})
        Me.AccType.Location = New System.Drawing.Point(105, 11)
        Me.AccType.Name = "AccType"
        Me.AccType.Size = New System.Drawing.Size(120, 20)
        Me.AccType.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "科目類型："
        '
        'D_AccMainFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ToExcelBtn3)
        Me.Controls.Add(Me.DGV3)
        Me.Controls.Add(Me.SubSum)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.AddSum)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.OpeningSum)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NameTab)
        Me.Controls.Add(Me.AccSum)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToExcelBtn1)
        Me.Controls.Add(Me.ToExcelBtn2)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.AccNum)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AccType)
        Me.Controls.Add(Me.Label1)
        Me.Name = "D_AccMainFrom"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "會科餘額明細"
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToExcelBtn3 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents SubSum As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents AddSum As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents OpeningSum As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NameTab As System.Windows.Forms.Label
    Friend WithEvents AccSum As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToExcelBtn1 As System.Windows.Forms.Button
    Friend WithEvents ToExcelBtn2 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AccNum As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AccType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
