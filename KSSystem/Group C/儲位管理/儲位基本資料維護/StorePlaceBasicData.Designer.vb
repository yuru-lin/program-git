<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StorePlaceBasicData
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
        Me.ddlStoreType = New System.Windows.Forms.ComboBox
        Me.ddlStorePlaceType = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ddlStoreClass = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMEMO = New System.Windows.Forms.TextBox
        Me.txtPlaceName = New System.Windows.Forms.TextBox
        Me.txtPlaceID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtStoreName = New System.Windows.Forms.TextBox
        Me.lable3 = New System.Windows.Forms.Label
        Me.txtMAX = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLevel = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ddlType = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ddlClassType = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.btnInsert = New System.Windows.Forms.Button
        Me.Button_01 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.laID = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 47)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(788, 294)
        Me.DGV1.TabIndex = 25
        '
        'ddlStoreType
        '
        Me.ddlStoreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlStoreType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlStoreType.FormattingEnabled = True
        Me.ddlStoreType.Items.AddRange(New Object() {"Y", "N"})
        Me.ddlStoreType.Location = New System.Drawing.Point(661, 411)
        Me.ddlStoreType.Name = "ddlStoreType"
        Me.ddlStoreType.Size = New System.Drawing.Size(128, 24)
        Me.ddlStoreType.TabIndex = 179
        '
        'ddlStorePlaceType
        '
        Me.ddlStorePlaceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlStorePlaceType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlStorePlaceType.FormattingEnabled = True
        Me.ddlStorePlaceType.Location = New System.Drawing.Point(661, 380)
        Me.ddlStorePlaceType.Name = "ddlStorePlaceType"
        Me.ddlStorePlaceType.Size = New System.Drawing.Size(128, 24)
        Me.ddlStorePlaceType.TabIndex = 178
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(535, 415)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 16)
        Me.Label16.TabIndex = 184
        Me.Label16.Text = "可 存 放 類 型："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(535, 384)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 16)
        Me.Label15.TabIndex = 183
        Me.Label15.Text = "庫位所在位置："
        '
        'ddlStoreClass
        '
        Me.ddlStoreClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlStoreClass.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlStoreClass.FormattingEnabled = True
        Me.ddlStoreClass.Items.AddRange(New Object() {"庫存單位", "KG", "小單位", "重整"})
        Me.ddlStoreClass.Location = New System.Drawing.Point(661, 347)
        Me.ddlStoreClass.Name = "ddlStoreClass"
        Me.ddlStoreClass.Size = New System.Drawing.Size(128, 24)
        Me.ddlStoreClass.TabIndex = 177
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(535, 351)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 182
        Me.Label14.Text = "庫      位      別："
        '
        'txtMEMO
        '
        Me.txtMEMO.Location = New System.Drawing.Point(285, 508)
        Me.txtMEMO.Multiline = True
        Me.txtMEMO.Name = "txtMEMO"
        Me.txtMEMO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMEMO.Size = New System.Drawing.Size(509, 41)
        Me.txtMEMO.TabIndex = 174
        '
        'txtPlaceName
        '
        Me.txtPlaceName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPlaceName.Location = New System.Drawing.Point(286, 377)
        Me.txtPlaceName.Name = "txtPlaceName"
        Me.txtPlaceName.Size = New System.Drawing.Size(209, 27)
        Me.txtPlaceName.TabIndex = 171
        '
        'txtPlaceID
        '
        Me.txtPlaceID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtPlaceID.Location = New System.Drawing.Point(285, 348)
        Me.txtPlaceID.Name = "txtPlaceID"
        Me.txtPlaceID.Size = New System.Drawing.Size(210, 27)
        Me.txtPlaceID.TabIndex = 169
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(191, 527)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 173
        Me.Label11.Text = "備          註："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(186, 382)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 16)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = " 儲 位 名 稱："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(186, 355)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 16)
        Me.Label9.TabIndex = 170
        Me.Label9.Text = " 儲 位 編 號："
        '
        'txtStoreName
        '
        Me.txtStoreName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtStoreName.Location = New System.Drawing.Point(286, 406)
        Me.txtStoreName.Name = "txtStoreName"
        Me.txtStoreName.Size = New System.Drawing.Size(209, 27)
        Me.txtStoreName.TabIndex = 185
        '
        'lable3
        '
        Me.lable3.AutoSize = True
        Me.lable3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lable3.Location = New System.Drawing.Point(186, 411)
        Me.lable3.Name = "lable3"
        Me.lable3.Size = New System.Drawing.Size(104, 16)
        Me.lable3.TabIndex = 186
        Me.lable3.Text = " 倉 庫 名 稱："
        '
        'txtMAX
        '
        Me.txtMAX.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtMAX.Location = New System.Drawing.Point(286, 435)
        Me.txtMAX.Name = "txtMAX"
        Me.txtMAX.Size = New System.Drawing.Size(209, 27)
        Me.txtMAX.TabIndex = 187
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(186, 440)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 188
        Me.Label2.Text = "最大存放量："
        '
        'txtLevel
        '
        Me.txtLevel.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtLevel.Location = New System.Drawing.Point(286, 466)
        Me.txtLevel.Name = "txtLevel"
        Me.txtLevel.Size = New System.Drawing.Size(49, 27)
        Me.txtLevel.TabIndex = 189
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(186, 471)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 190
        Me.Label3.Text = " 層           數："
        '
        'ddlType
        '
        Me.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlType.FormattingEnabled = True
        Me.ddlType.Items.AddRange(New Object() {"Y", "N"})
        Me.ddlType.Location = New System.Drawing.Point(661, 441)
        Me.ddlType.Name = "ddlType"
        Me.ddlType.Size = New System.Drawing.Size(128, 24)
        Me.ddlType.TabIndex = 191
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(535, 445)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 16)
        Me.Label4.TabIndex = 192
        Me.Label4.Text = "別               類："
        '
        'ddlClassType
        '
        Me.ddlClassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlClassType.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlClassType.FormattingEnabled = True
        Me.ddlClassType.Items.AddRange(New Object() {"Y", "N"})
        Me.ddlClassType.Location = New System.Drawing.Point(661, 471)
        Me.ddlClassType.Name = "ddlClassType"
        Me.ddlClassType.Size = New System.Drawing.Size(128, 24)
        Me.ddlClassType.TabIndex = 193
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(535, 475)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 16)
        Me.Label5.TabIndex = 194
        Me.Label5.Text = "所   在  區  域："
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(445, 562)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 197
        Me.btnUpdate.Text = "修改"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Location = New System.Drawing.Point(538, 562)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(75, 23)
        Me.btnDel.TabIndex = 196
        Me.btnDel.Text = "刪除"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Location = New System.Drawing.Point(350, 562)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(75, 23)
        Me.btnInsert.TabIndex = 195
        Me.btnInsert.Text = "新增"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'Button_01
        '
        Me.Button_01.Location = New System.Drawing.Point(355, 17)
        Me.Button_01.Name = "Button_01"
        Me.Button_01.Size = New System.Drawing.Size(87, 22)
        Me.Button_01.TabIndex = 198
        Me.Button_01.TabStop = False
        Me.Button_01.Text = "查詢"
        Me.Button_01.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(88, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(81, 27)
        Me.TextBox1.TabIndex = 199
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 16)
        Me.Label6.TabIndex = 200
        Me.Label6.Text = " 儲位編號："
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(175, 14)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(81, 27)
        Me.TextBox2.TabIndex = 201
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(262, 14)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(81, 27)
        Me.TextBox3.TabIndex = 202
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(563, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = " 編號："
        Me.Label1.Visible = False
        '
        'laID
        '
        Me.laID.AutoSize = True
        Me.laID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.laID.Location = New System.Drawing.Point(618, 23)
        Me.laID.Name = "laID"
        Me.laID.Size = New System.Drawing.Size(40, 16)
        Me.laID.TabIndex = 204
        Me.laID.Text = "編號"
        Me.laID.Visible = False
        '
        'StorePlaceBasicData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 586)
        Me.Controls.Add(Me.laID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button_01)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.ddlClassType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ddlType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtLevel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMAX)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStoreName)
        Me.Controls.Add(Me.lable3)
        Me.Controls.Add(Me.ddlStoreType)
        Me.Controls.Add(Me.ddlStorePlaceType)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ddlStoreClass)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtMEMO)
        Me.Controls.Add(Me.txtPlaceName)
        Me.Controls.Add(Me.txtPlaceID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "StorePlaceBasicData"
        Me.Text = "儲位基本資料維護"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents ddlStoreType As System.Windows.Forms.ComboBox
    Friend WithEvents ddlStorePlaceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ddlStoreClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMEMO As System.Windows.Forms.TextBox
    Friend WithEvents txtPlaceName As System.Windows.Forms.TextBox
    Friend WithEvents txtPlaceID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStoreName As System.Windows.Forms.TextBox
    Friend WithEvents lable3 As System.Windows.Forms.Label
    Friend WithEvents txtMAX As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLevel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ddlType As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ddlClassType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents Button_01 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents laID As System.Windows.Forms.Label
End Class
