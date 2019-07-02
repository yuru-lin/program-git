<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_EC_List
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
        Me.btnPackPrint = New System.Windows.Forms.Button
        Me.btnDetailPrint = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 129)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(686, 339)
        Me.DGV1.TabIndex = 175
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "訂單日期："
        '
        'laID
        '
        Me.laID.AutoSize = True
        Me.laID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laID.ForeColor = System.Drawing.Color.OrangeRed
        Me.laID.Location = New System.Drawing.Point(88, 104)
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
        Me.ddlSource.Location = New System.Drawing.Point(129, 23)
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
        Me.Label2.Size = New System.Drawing.Size(115, 21)
        Me.Label2.TabIndex = 190
        Me.Label2.Text = "通路名稱："
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.Location = New System.Drawing.Point(335, 43)
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
        Me.laSource.Location = New System.Drawing.Point(258, 104)
        Me.laSource.Name = "laSource"
        Me.laSource.Size = New System.Drawing.Size(40, 16)
        Me.laSource.TabIndex = 194
        Me.laSource.Text = "通路"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 104)
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
        Me.ddlState.Location = New System.Drawing.Point(129, 60)
        Me.ddlState.Name = "ddlState"
        Me.ddlState.Size = New System.Drawing.Size(193, 20)
        Me.ddlState.TabIndex = 196
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 21)
        Me.Label3.TabIndex = 195
        Me.Label3.Text = "狀        態："
        '
        'btnPackPrint
        '
        Me.btnPackPrint.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPackPrint.Location = New System.Drawing.Point(698, 129)
        Me.btnPackPrint.Name = "btnPackPrint"
        Me.btnPackPrint.Size = New System.Drawing.Size(91, 73)
        Me.btnPackPrint.TabIndex = 197
        Me.btnPackPrint.Text = "列印檢貨單"
        Me.btnPackPrint.UseVisualStyleBackColor = True
        '
        'btnDetailPrint
        '
        Me.btnDetailPrint.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDetailPrint.Location = New System.Drawing.Point(698, 218)
        Me.btnDetailPrint.Name = "btnDetailPrint"
        Me.btnDetailPrint.Size = New System.Drawing.Size(91, 73)
        Me.btnDetailPrint.TabIndex = 198
        Me.btnDetailPrint.Text = "列印出貨明細"
        Me.btnDetailPrint.UseVisualStyleBackColor = True
        '
        'A_EC_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.btnDetailPrint)
        Me.Controls.Add(Me.btnPackPrint)
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
        Me.Name = "A_EC_List"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EC出貨表單列印"
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
    Friend WithEvents btnPackPrint As System.Windows.Forms.Button
    Friend WithEvents btnDetailPrint As System.Windows.Forms.Button
End Class
