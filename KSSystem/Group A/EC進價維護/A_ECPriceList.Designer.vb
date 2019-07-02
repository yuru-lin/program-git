<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_ECPriceList
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
        Me.btnADD = New System.Windows.Forms.Button
        Me.ddlExamine = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ddlType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtProName = New System.Windows.Forms.TextBox
        Me.ddlPriceType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSerch.Location = New System.Drawing.Point(304, 169)
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
        Me.DGV1.Location = New System.Drawing.Point(6, 213)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(791, 361)
        Me.DGV1.TabIndex = 175
        '
        'btnADD
        '
        Me.btnADD.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnADD.Location = New System.Drawing.Point(392, 170)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(119, 38)
        Me.btnADD.TabIndex = 179
        Me.btnADD.Text = "新增價格"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'ddlExamine
        '
        Me.ddlExamine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlExamine.FormattingEnabled = True
        Me.ddlExamine.Items.AddRange(New Object() {"全選", "送審中", "已覆核", "退回"})
        Me.ddlExamine.Location = New System.Drawing.Point(185, 84)
        Me.ddlExamine.Name = "ddlExamine"
        Me.ddlExamine.Size = New System.Drawing.Size(193, 20)
        Me.ddlExamine.TabIndex = 181
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 21)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "狀                       態："
        '
        'ddlType
        '
        Me.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlType.FormattingEnabled = True
        Me.ddlType.Items.AddRange(New Object() {"全選", "生鮮品", "調理品"})
        Me.ddlType.Location = New System.Drawing.Point(185, 52)
        Me.ddlType.Name = "ddlType"
        Me.ddlType.Size = New System.Drawing.Size(193, 20)
        Me.ddlType.TabIndex = 183
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(188, 21)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "類                       型："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 184
        Me.Label8.Text = "EC進價清單："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 21)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "商品名稱(關鍵字)："
        '
        'txtProName
        '
        Me.txtProName.Location = New System.Drawing.Point(185, 19)
        Me.txtProName.Name = "txtProName"
        Me.txtProName.Size = New System.Drawing.Size(193, 22)
        Me.txtProName.TabIndex = 186
        '
        'ddlPriceType
        '
        Me.ddlPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlPriceType.FormattingEnabled = True
        Me.ddlPriceType.Items.AddRange(New Object() {"全選", "常態", "活動"})
        Me.ddlPriceType.Location = New System.Drawing.Point(185, 118)
        Me.ddlPriceType.Name = "ddlPriceType"
        Me.ddlPriceType.Size = New System.Drawing.Size(193, 20)
        Me.ddlPriceType.TabIndex = 188
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(190, 21)
        Me.Label4.TabIndex = 187
        Me.Label4.Text = "價     格     類     型："
        '
        'A_ECPriceList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.ddlPriceType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtProName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ddlType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ddlExamine)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnADD)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.btnSerch)
        Me.Name = "A_ECPriceList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EC進價維護清單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSerch As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents ddlExamine As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddlType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtProName As System.Windows.Forms.TextBox
    Friend WithEvents ddlPriceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
