<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Z_StockApplyList
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
        Me.ddlPurpose = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.ddldepart = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnADD = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.BtnEdit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.laID = New System.Windows.Forms.Label
        Me.laExamine = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.次數 = New System.Windows.Forms.TextBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.Location = New System.Drawing.Point(39, 90)
        Me.btnSerch.Name = "btnSerch"
        Me.btnSerch.Size = New System.Drawing.Size(73, 38)
        Me.btnSerch.TabIndex = 46
        Me.btnSerch.Text = "查詢"
        Me.btnSerch.UseVisualStyleBackColor = True
        '
        'ddlPurpose
        '
        Me.ddlPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlPurpose.FormattingEnabled = True
        Me.ddlPurpose.Location = New System.Drawing.Point(127, 6)
        Me.ddlPurpose.Name = "ddlPurpose"
        Me.ddlPurpose.Size = New System.Drawing.Size(131, 20)
        Me.ddlPurpose.TabIndex = 157
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 21)
        Me.Label17.TabIndex = 170
        Me.Label17.Text = "領用用途："
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 191)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(791, 339)
        Me.DGV1.TabIndex = 175
        '
        'ddldepart
        '
        Me.ddldepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddldepart.FormattingEnabled = True
        Me.ddldepart.Items.AddRange(New Object() {"全選", "營業", "生管", "人事", "倉庫", "會計", "採購", "總經理室", "研發", "設計", "品管", "加工", "資訊", "董事長室"})
        Me.ddldepart.Location = New System.Drawing.Point(127, 46)
        Me.ddldepart.Name = "ddldepart"
        Me.ddldepart.Size = New System.Drawing.Size(131, 20)
        Me.ddldepart.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 21)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "部門別："
        '
        'btnADD
        '
        Me.btnADD.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnADD.Location = New System.Drawing.Point(127, 89)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(73, 38)
        Me.btnADD.TabIndex = 179
        Me.btnADD.Text = "新增"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(609, 145)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(73, 39)
        Me.btnDel.TabIndex = 180
        Me.btnDel.Text = "刪除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'BtnEdit
        '
        Me.BtnEdit.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BtnEdit.Location = New System.Drawing.Point(522, 146)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(73, 39)
        Me.BtnEdit.TabIndex = 181
        Me.BtnEdit.Text = "修改"
        Me.BtnEdit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 21)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "存領編號："
        '
        'laID
        '
        Me.laID.AutoSize = True
        Me.laID.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laID.ForeColor = System.Drawing.Color.OrangeRed
        Me.laID.Location = New System.Drawing.Point(123, 164)
        Me.laID.Name = "laID"
        Me.laID.Size = New System.Drawing.Size(52, 21)
        Me.laID.TabIndex = 183
        Me.laID.Text = "編號"
        '
        'laExamine
        '
        Me.laExamine.AutoSize = True
        Me.laExamine.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laExamine.ForeColor = System.Drawing.Color.OrangeRed
        Me.laExamine.Location = New System.Drawing.Point(417, 164)
        Me.laExamine.Name = "laExamine"
        Me.laExamine.Size = New System.Drawing.Size(52, 21)
        Me.laExamine.TabIndex = 186
        Me.laExamine.Text = "狀態"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(346, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 21)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "狀態："
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(698, 130)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(91, 54)
        Me.btnPrint.TabIndex = 187
        Me.btnPrint.Text = "補印存領單"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        '次數
        '
        Me.次數.Location = New System.Drawing.Point(735, 536)
        Me.次數.Name = "次數"
        Me.次數.Size = New System.Drawing.Size(62, 22)
        Me.次數.TabIndex = 189
        Me.次數.Visible = False
        '
        'Z_StockApplyList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.次數)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.laExamine)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.laID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnEdit)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnADD)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.ddldepart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ddlPurpose)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnSerch)
        Me.Name = "Z_StockApplyList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "存貨領用申請列表"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSerch As System.Windows.Forms.Button
    Friend WithEvents ddlPurpose As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ddldepart As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents laID As System.Windows.Forms.Label
    Friend WithEvents laExamine As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents 次數 As System.Windows.Forms.TextBox
End Class
