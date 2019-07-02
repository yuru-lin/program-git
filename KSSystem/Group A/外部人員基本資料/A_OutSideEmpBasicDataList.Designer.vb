<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_OutSideEmpBasicDataList
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
        Me.ddlstatus = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ddlSaleGroupType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.laEmpID = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.laName = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnDel = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSerch
        '
        Me.btnSerch.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSerch.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSerch.Location = New System.Drawing.Point(371, 68)
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
        Me.DGV1.Location = New System.Drawing.Point(6, 174)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(791, 412)
        Me.DGV1.TabIndex = 175
        '
        'btnADD
        '
        Me.btnADD.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnADD.Location = New System.Drawing.Point(370, 122)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(162, 38)
        Me.btnADD.TabIndex = 179
        Me.btnADD.Text = "新增基本資料"
        Me.btnADD.UseVisualStyleBackColor = True
        '
        'ddlstatus
        '
        Me.ddlstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlstatus.FormattingEnabled = True
        Me.ddlstatus.Items.AddRange(New Object() {"全選", "已離職", "任職中"})
        Me.ddlstatus.Location = New System.Drawing.Point(154, 84)
        Me.ddlstatus.Name = "ddlstatus"
        Me.ddlstatus.Size = New System.Drawing.Size(193, 20)
        Me.ddlstatus.TabIndex = 181
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "狀態："
        '
        'ddlSaleGroupType
        '
        Me.ddlSaleGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlSaleGroupType.FormattingEnabled = True
        Me.ddlSaleGroupType.Items.AddRange(New Object() {"全選", "守衛", "獸醫師", "玖鼎"})
        Me.ddlSaleGroupType.Location = New System.Drawing.Point(153, 52)
        Me.ddlSaleGroupType.Name = "ddlSaleGroupType"
        Me.ddlSaleGroupType.Size = New System.Drawing.Size(193, 20)
        Me.ddlSaleGroupType.TabIndex = 183
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(78, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "類型："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 184
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 21)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "姓名(關鍵字)："
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(152, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(193, 22)
        Me.txtName.TabIndex = 186
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(541, 122)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(162, 38)
        Me.Button1.TabIndex = 187
        Me.Button1.Text = "修改基本資料"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'laEmpID
        '
        Me.laEmpID.AutoSize = True
        Me.laEmpID.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laEmpID.ForeColor = System.Drawing.Color.OrangeRed
        Me.laEmpID.Location = New System.Drawing.Point(67, 146)
        Me.laEmpID.Name = "laEmpID"
        Me.laEmpID.Size = New System.Drawing.Size(52, 21)
        Me.laEmpID.TabIndex = 204
        Me.laEmpID.Text = "員編"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 21)
        Me.Label4.TabIndex = 203
        Me.Label4.Text = "員編："
        '
        'laName
        '
        Me.laName.AutoSize = True
        Me.laName.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laName.ForeColor = System.Drawing.Color.OrangeRed
        Me.laName.Location = New System.Drawing.Point(276, 146)
        Me.laName.Name = "laName"
        Me.laName.Size = New System.Drawing.Size(52, 21)
        Me.laName.TabIndex = 206
        Me.laName.Text = "姓名"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(216, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 21)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "姓名："
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(716, 121)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(73, 39)
        Me.btnDel.TabIndex = 207
        Me.btnDel.Text = "刪除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'A_OutSideEmpBasicDataList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.laName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.laEmpID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ddlSaleGroupType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ddlstatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnADD)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.btnSerch)
        Me.Name = "A_OutSideEmpBasicDataList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "員購價維護清單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSerch As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents ddlstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddlSaleGroupType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents laEmpID As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents laName As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDel As System.Windows.Forms.Button
End Class
