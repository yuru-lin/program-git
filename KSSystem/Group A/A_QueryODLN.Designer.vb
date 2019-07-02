<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_QueryODLN
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
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(12, 72)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(75, 20)
        Me.CheckBox3.TabIndex = 126
        Me.CheckBox3.Text = "存編："
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(119, 41)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(130, 22)
        Me.CardCode.TabIndex = 125
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(12, 42)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox2.TabIndex = 124
        Me.CheckBox2.Text = "客戶編號："
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(12, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(107, 20)
        Me.CheckBox1.TabIndex = 123
        Me.CheckBox1.Text = "資料期間："
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(249, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "至"
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(273, 11)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(130, 22)
        Me.ToDate.TabIndex = 121
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(119, 11)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(130, 22)
        Me.FromDate.TabIndex = 120
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(566, 72)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 119
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(249, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "客戶名稱："
        '
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(337, 41)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(130, 22)
        Me.CardName.TabIndex = 129
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Location = New System.Drawing.Point(87, 71)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(130, 22)
        Me.ItemCodeTxt.TabIndex = 130
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Location = New System.Drawing.Point(273, 71)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(130, 22)
        Me.ItemNameTxt.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(217, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "品名："
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(697, 527)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 134
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 99)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(760, 422)
        Me.DGV1.TabIndex = 135
        '
        'A_QueryODLN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.CardName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.btnSearch)
        Me.Name = "A_QueryODLN"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "交貨單明細表"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
End Class
