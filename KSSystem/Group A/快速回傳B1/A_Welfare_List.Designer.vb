<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_Welfare_List
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
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.laID = New System.Windows.Forms.Label
        Me.btnInsert = New System.Windows.Forms.Button
        Me.ddlSource = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSerch = New System.Windows.Forms.Button
        Me.laCardCode = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.laCardName = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.laSource = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnDel = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(18, 97)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(655, 339)
        Me.DGV1.TabIndex = 175
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "編號："
        '
        'laID
        '
        Me.laID.AutoSize = True
        Me.laID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laID.ForeColor = System.Drawing.Color.OrangeRed
        Me.laID.Location = New System.Drawing.Point(53, 72)
        Me.laID.Name = "laID"
        Me.laID.Size = New System.Drawing.Size(40, 16)
        Me.laID.TabIndex = 183
        Me.laID.Text = "編號"
        '
        'btnInsert
        '
        Me.btnInsert.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnInsert.Location = New System.Drawing.Point(690, 110)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(91, 73)
        Me.btnInsert.TabIndex = 189
        Me.btnInsert.Text = "帶入明細資料"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'ddlSource
        '
        Me.ddlSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSource.FormattingEnabled = True
        Me.ddlSource.Items.AddRange(New Object() {"全選", "網路通路", "員購(福利社)"})
        Me.ddlSource.Location = New System.Drawing.Point(83, 23)
        Me.ddlSource.Name = "ddlSource"
        Me.ddlSource.Size = New System.Drawing.Size(193, 20)
        Me.ddlSource.TabIndex = 191
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "來源："
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.Location = New System.Drawing.Point(282, 13)
        Me.btnSerch.Name = "btnSerch"
        Me.btnSerch.Size = New System.Drawing.Size(73, 38)
        Me.btnSerch.TabIndex = 192
        Me.btnSerch.Text = "查詢"
        Me.btnSerch.UseVisualStyleBackColor = True
        '
        'laCardCode
        '
        Me.laCardCode.AutoSize = True
        Me.laCardCode.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laCardCode.ForeColor = System.Drawing.Color.OrangeRed
        Me.laCardCode.Location = New System.Drawing.Point(258, 72)
        Me.laCardCode.Name = "laCardCode"
        Me.laCardCode.Size = New System.Drawing.Size(40, 16)
        Me.laCardCode.TabIndex = 194
        Me.laCardCode.Text = "編號"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 193
        Me.Label4.Text = "客戶編號："
        '
        'laCardName
        '
        Me.laCardName.AutoSize = True
        Me.laCardName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laCardName.ForeColor = System.Drawing.Color.OrangeRed
        Me.laCardName.Location = New System.Drawing.Point(466, 72)
        Me.laCardName.Name = "laCardName"
        Me.laCardName.Size = New System.Drawing.Size(40, 16)
        Me.laCardName.TabIndex = 196
        Me.laCardName.Text = "名稱"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(381, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 195
        Me.Label6.Text = "客戶編號："
        '
        'laSource
        '
        Me.laSource.AutoSize = True
        Me.laSource.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laSource.ForeColor = System.Drawing.Color.OrangeRed
        Me.laSource.Location = New System.Drawing.Point(713, 72)
        Me.laSource.Name = "laSource"
        Me.laSource.Size = New System.Drawing.Size(40, 16)
        Me.laSource.TabIndex = 198
        Me.laSource.Text = "名稱"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(629, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 197
        Me.Label5.Text = "資料來源："
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(690, 219)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(91, 73)
        Me.btnDel.TabIndex = 199
        Me.btnDel.Text = "刪除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'A_Welfare_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.laSource)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.laCardName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.laCardCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ddlSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSerch)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.laID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "A_Welfare_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速回傳B1"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents laID As System.Windows.Forms.Label
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents ddlSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSerch As System.Windows.Forms.Button
    Friend WithEvents laCardCode As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents laCardName As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents laSource As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDel As System.Windows.Forms.Button
End Class
