<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Z_Welfare_List
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
        Me.btnSerch = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.ddlState = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.laDate = New System.Windows.Forms.Label
        Me.laState = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.laCardName = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.Location = New System.Drawing.Point(297, 4)
        Me.btnSerch.Name = "btnSerch"
        Me.btnSerch.Size = New System.Drawing.Size(73, 38)
        Me.btnSerch.TabIndex = 46
        Me.btnSerch.Text = "查詢"
        Me.btnSerch.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 85)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(777, 155)
        Me.DGV1.TabIndex = 175
        '
        'ddlState
        '
        Me.ddlState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlState.FormattingEnabled = True
        Me.ddlState.Items.AddRange(New Object() {"全選", "未覆核", "已覆核", "已回傳B1", "出庫完成"})
        Me.ddlState.Location = New System.Drawing.Point(98, 14)
        Me.ddlState.Name = "ddlState"
        Me.ddlState.Size = New System.Drawing.Size(193, 20)
        Me.ddlState.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "狀態："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "日期："
        '
        'laDate
        '
        Me.laDate.AutoSize = True
        Me.laDate.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laDate.ForeColor = System.Drawing.Color.OrangeRed
        Me.laDate.Location = New System.Drawing.Point(79, 58)
        Me.laDate.Name = "laDate"
        Me.laDate.Size = New System.Drawing.Size(52, 21)
        Me.laDate.TabIndex = 183
        Me.laDate.Text = "日期"
        '
        'laState
        '
        Me.laState.AutoSize = True
        Me.laState.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laState.ForeColor = System.Drawing.Color.OrangeRed
        Me.laState.Location = New System.Drawing.Point(257, 58)
        Me.laState.Name = "laState"
        Me.laState.Size = New System.Drawing.Size(52, 21)
        Me.laState.TabIndex = 186
        Me.laState.Text = "狀態"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(186, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 21)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "狀態："
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(702, 248)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(91, 54)
        Me.btnPrint.TabIndex = 187
        Me.btnPrint.Text = "列印員購單"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(12, 246)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(680, 339)
        Me.DGV2.TabIndex = 188
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(592, 26)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(91, 54)
        Me.btnUpdate.TabIndex = 189
        Me.btnUpdate.Text = "核准"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(704, 26)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(91, 54)
        Me.btnDel.TabIndex = 200
        Me.btnDel.Text = "刪除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'laCardName
        '
        Me.laCardName.AutoSize = True
        Me.laCardName.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laCardName.ForeColor = System.Drawing.Color.OrangeRed
        Me.laCardName.Location = New System.Drawing.Point(480, 58)
        Me.laCardName.Name = "laCardName"
        Me.laCardName.Size = New System.Drawing.Size(94, 21)
        Me.laCardName.TabIndex = 202
        Me.laCardName.Text = "客戶名稱"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(366, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 21)
        Me.Label4.TabIndex = 201
        Me.Label4.Text = "客戶名稱："
        '
        'Z_Welfare_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.laCardName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.DGV2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.laState)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.laDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.ddlState)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSerch)
        Me.Name = "Z_Welfare_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "員購訂單總務覆核"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSerch As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ddlState As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents laDate As System.Windows.Forms.Label
    Friend WithEvents laState As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents laCardName As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
