<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_UpdateSchedule
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
        Me.btnAddToDB = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.NeedQuantitytxt = New System.Windows.Forms.TextBox
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.CardCodeForSearch = New System.Windows.Forms.TextBox
        Me.SearchDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.cobStatus = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cobStatusForSearch = New System.Windows.Forms.ComboBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddToDB
        '
        Me.btnAddToDB.Location = New System.Drawing.Point(432, 427)
        Me.btnAddToDB.Name = "btnAddToDB"
        Me.btnAddToDB.Size = New System.Drawing.Size(90, 23)
        Me.btnAddToDB.TabIndex = 75
        Me.btnAddToDB.Text = "更新至資料庫"
        Me.btnAddToDB.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 399)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "需求數量："
        '
        'NeedQuantitytxt
        '
        Me.NeedQuantitytxt.Location = New System.Drawing.Point(99, 396)
        Me.NeedQuantitytxt.Name = "NeedQuantitytxt"
        Me.NeedQuantitytxt.Size = New System.Drawing.Size(140, 22)
        Me.NeedQuantitytxt.TabIndex = 73
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(263, 361)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(107, 22)
        Me.ToDate.TabIndex = 72
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(239, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "至"
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(119, 361)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(107, 22)
        Me.FromDate.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 364)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "需完成期間："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 329)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "存編："
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Location = New System.Drawing.Point(332, 326)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemNameTxt.TabIndex = 66
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Location = New System.Drawing.Point(99, 326)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemCodeTxt.TabIndex = 65
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(244, 329)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "項目名稱："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(245, 294)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "客戶名稱："
        '
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(333, 291)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(140, 22)
        Me.CardName.TabIndex = 63
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 294)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "客戶編號："
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(99, 291)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(140, 22)
        Me.CardCode.TabIndex = 61
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 69)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(510, 216)
        Me.DGV1.TabIndex = 76
        '
        'CardCodeForSearch
        '
        Me.CardCodeForSearch.Location = New System.Drawing.Point(141, 11)
        Me.CardCodeForSearch.Name = "CardCodeForSearch"
        Me.CardCodeForSearch.Size = New System.Drawing.Size(140, 22)
        Me.CardCodeForSearch.TabIndex = 77
        '
        'SearchDate
        '
        Me.SearchDate.Location = New System.Drawing.Point(394, 11)
        Me.SearchDate.Name = "SearchDate"
        Me.SearchDate.Size = New System.Drawing.Size(107, 22)
        Me.SearchDate.TabIndex = 80
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(245, 399)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "狀態："
        '
        'cobStatus
        '
        Me.cobStatus.FormattingEnabled = True
        Me.cobStatus.Items.AddRange(New Object() {"生產中", "已完成", "取消"})
        Me.cobStatus.Location = New System.Drawing.Point(299, 397)
        Me.cobStatus.Name = "cobStatus"
        Me.cobStatus.Size = New System.Drawing.Size(121, 20)
        Me.cobStatus.TabIndex = 82
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(447, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 83
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cobStatusForSearch
        '
        Me.cobStatusForSearch.FormattingEnabled = True
        Me.cobStatusForSearch.Items.AddRange(New Object() {"生產中", "已完成", "取消"})
        Me.cobStatusForSearch.Location = New System.Drawing.Point(109, 38)
        Me.cobStatusForSearch.Name = "cobStatusForSearch"
        Me.cobStatusForSearch.Size = New System.Drawing.Size(121, 20)
        Me.cobStatusForSearch.TabIndex = 85
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(34, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox1.TabIndex = 86
        Me.CheckBox1.Text = "客戶編號："
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(34, 38)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox3.TabIndex = 87
        Me.CheckBox3.Text = "狀態："
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(287, 12)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox2.TabIndex = 88
        Me.CheckBox2.Text = "需完成日："
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'B_UpdateSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 462)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.cobStatusForSearch)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cobStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SearchDate)
        Me.Controls.Add(Me.CardCodeForSearch)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.btnAddToDB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NeedQuantitytxt)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CardName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CardCode)
        Me.Name = "B_UpdateSchedule"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "更新排程"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddToDB As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NeedQuantitytxt As System.Windows.Forms.TextBox
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents CardCodeForSearch As System.Windows.Forms.TextBox
    Friend WithEvents SearchDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cobStatusForSearch As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
End Class
