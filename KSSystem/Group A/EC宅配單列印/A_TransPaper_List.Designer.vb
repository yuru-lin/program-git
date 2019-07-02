<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_TransPaper_List
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
        Me.ddlSource = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSerch = New System.Windows.Forms.Button
        Me.laSource = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ddlState = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnDelivery = New System.Windows.Forms.Button
        Me.ddlTransType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtTransNo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ddlnum = New System.Windows.Forms.ComboBox
        Me.btnDel = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtOrderID = New System.Windows.Forms.TextBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 158)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(790, 312)
        Me.DGV1.TabIndex = 175
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "訂單編號："
        '
        'laID
        '
        Me.laID.AutoSize = True
        Me.laID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laID.ForeColor = System.Drawing.Color.OrangeRed
        Me.laID.Location = New System.Drawing.Point(88, 135)
        Me.laID.Name = "laID"
        Me.laID.Size = New System.Drawing.Size(40, 16)
        Me.laID.TabIndex = 183
        Me.laID.Text = "編號"
        '
        'ddlSource
        '
        Me.ddlSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSource.FormattingEnabled = True
        Me.ddlSource.Items.AddRange(New Object() {"全選", "shop.gugugoo.com", "MOMO購物網", "PC-HOME線上購物", "YAHOO!購物中心", "活動預購單", "CHT優購網", "東森購物網", "其他未定義", "傳真訂購單"})
        Me.ddlSource.Location = New System.Drawing.Point(213, 23)
        Me.ddlSource.Name = "ddlSource"
        Me.ddlSource.Size = New System.Drawing.Size(193, 20)
        Me.ddlSource.TabIndex = 191
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 21)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "通     路     名      稱："
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.Location = New System.Drawing.Point(419, 86)
        Me.btnSerch.Name = "btnSerch"
        Me.btnSerch.Size = New System.Drawing.Size(73, 38)
        Me.btnSerch.TabIndex = 192
        Me.btnSerch.Text = "查詢"
        Me.btnSerch.UseVisualStyleBackColor = True
        '
        'laSource
        '
        Me.laSource.AutoSize = True
        Me.laSource.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laSource.ForeColor = System.Drawing.Color.OrangeRed
        Me.laSource.Location = New System.Drawing.Point(268, 135)
        Me.laSource.Name = "laSource"
        Me.laSource.Size = New System.Drawing.Size(40, 16)
        Me.laSource.TabIndex = 194
        Me.laSource.Text = "通路"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(186, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 193
        Me.Label4.Text = "通路名稱："
        '
        'ddlState
        '
        Me.ddlState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlState.FormattingEnabled = True
        Me.ddlState.Items.AddRange(New Object() {"全選", "已回傳B1", "已出貨"})
        Me.ddlState.Location = New System.Drawing.Point(213, 60)
        Me.ddlState.Name = "ddlState"
        Me.ddlState.Size = New System.Drawing.Size(193, 20)
        Me.ddlState.TabIndex = 196
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 21)
        Me.Label3.TabIndex = 195
        Me.Label3.Text = "狀                        態："
        '
        'btnDelivery
        '
        Me.btnDelivery.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDelivery.Location = New System.Drawing.Point(504, 479)
        Me.btnDelivery.Name = "btnDelivery"
        Me.btnDelivery.Size = New System.Drawing.Size(91, 73)
        Me.btnDelivery.TabIndex = 200
        Me.btnDelivery.Text = "列印宅配單"
        Me.btnDelivery.UseVisualStyleBackColor = True
        '
        'ddlTransType
        '
        Me.ddlTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlTransType.FormattingEnabled = True
        Me.ddlTransType.Items.AddRange(New Object() {"黑貓宅急便", "客樂得"})
        Me.ddlTransType.Location = New System.Drawing.Point(166, 483)
        Me.ddlTransType.Name = "ddlTransType"
        Me.ddlTransType.Size = New System.Drawing.Size(193, 20)
        Me.ddlTransType.TabIndex = 202
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 482)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 21)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "宅 配 單 種 類："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 515)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 21)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "最新宅配單號："
        '
        'txtTransNo
        '
        Me.txtTransNo.Location = New System.Drawing.Point(166, 513)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.Size = New System.Drawing.Size(193, 22)
        Me.txtTransNo.TabIndex = 204
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(366, 523)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 12)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "(格式：XX-XXXX-XXX)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 549)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 21)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "列   印   數  量："
        '
        'ddlnum
        '
        Me.ddlnum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlnum.FormattingEnabled = True
        Me.ddlnum.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"})
        Me.ddlnum.Location = New System.Drawing.Point(166, 549)
        Me.ddlnum.Name = "ddlnum"
        Me.ddlnum.Size = New System.Drawing.Size(76, 20)
        Me.ddlnum.TabIndex = 207
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(614, 479)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(91, 73)
        Me.btnDel.TabIndex = 208
        Me.btnDel.Text = "刪除宅配記錄"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(192, 21)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = "訂單編號(關鍵字)："
        '
        'txtOrderID
        '
        Me.txtOrderID.Location = New System.Drawing.Point(213, 94)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.Size = New System.Drawing.Size(193, 22)
        Me.txtOrderID.TabIndex = 210
        '
        'A_TransPaper_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.txtOrderID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.ddlnum)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTransNo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ddlTransType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnDelivery)
        Me.Controls.Add(Me.ddlState)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.laSource)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ddlSource)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSerch)
        Me.Controls.Add(Me.laID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "A_TransPaper_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EC宅配單列印"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents laID As System.Windows.Forms.Label
    Friend WithEvents ddlSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSerch As System.Windows.Forms.Button
    Friend WithEvents laSource As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ddlState As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnDelivery As System.Windows.Forms.Button
    Friend WithEvents ddlTransType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ddlnum As System.Windows.Forms.ComboBox
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOrderID As System.Windows.Forms.TextBox
End Class
