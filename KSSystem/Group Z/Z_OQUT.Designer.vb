<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Z_OQUT
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
        Me.CommentsTxt = New System.Windows.Forms.TextBox
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.AddItemBtn = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.EmpName = New System.Windows.Forms.Label
        Me.KSEmpID = New System.Windows.Forms.TextBox
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.Label11 = New System.Windows.Forms.Label
        Me.sapEmpId = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CommentsTxt
        '
        Me.CommentsTxt.Location = New System.Drawing.Point(71, 503)
        Me.CommentsTxt.Name = "CommentsTxt"
        Me.CommentsTxt.Size = New System.Drawing.Size(408, 22)
        Me.CommentsTxt.TabIndex = 41
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Location = New System.Drawing.Point(325, 446)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemNameTxt.TabIndex = 38
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Location = New System.Drawing.Point(97, 446)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemCodeTxt.TabIndex = 37
        '
        'AddItemBtn
        '
        Me.AddItemBtn.Location = New System.Drawing.Point(411, 474)
        Me.AddItemBtn.Name = "AddItemBtn"
        Me.AddItemBtn.Size = New System.Drawing.Size(75, 23)
        Me.AddItemBtn.TabIndex = 40
        Me.AddItemBtn.Text = "新增項目"
        Me.AddItemBtn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(237, 449)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "項目名稱："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 423)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "新增項目："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(253, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 36)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "※編號、名稱 擇一輸入即可 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "客戶名稱按Tab鍵可模糊查詢"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "歷史交易資料："
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(404, 68)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 33
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "客戶名稱："
        '
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(103, 40)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(140, 22)
        Me.CardName.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "客戶編號："
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(103, 6)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(140, 22)
        Me.CardCode.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(135, 537)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "員工編號："
        '
        'EmpName
        '
        Me.EmpName.AutoSize = True
        Me.EmpName.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.EmpName.Location = New System.Drawing.Point(336, 537)
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Size = New System.Drawing.Size(0, 16)
        Me.EmpName.TabIndex = 27
        '
        'KSEmpID
        '
        Me.KSEmpID.Location = New System.Drawing.Point(229, 534)
        Me.KSEmpID.Name = "KSEmpID"
        Me.KSEmpID.Size = New System.Drawing.Size(100, 22)
        Me.KSEmpID.TabIndex = 26
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(411, 534)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 25
        Me.SaveBtn.Text = "儲存"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(9, 94)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(470, 326)
        Me.DGV1.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 506)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "備註："
        '
        'sapEmpId
        '
        Me.sapEmpId.AutoSize = True
        Me.sapEmpId.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.sapEmpId.Location = New System.Drawing.Point(122, 541)
        Me.sapEmpId.Name = "sapEmpId"
        Me.sapEmpId.Size = New System.Drawing.Size(16, 16)
        Me.sapEmpId.TabIndex = 43
        Me.sapEmpId.Text = "0"
        Me.sapEmpId.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 449)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "存編："
        '
        'Z_OQUT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 562)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.sapEmpId)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CommentsTxt)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.AddItemBtn)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CardName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.EmpName)
        Me.Controls.Add(Me.KSEmpID)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "Z_OQUT"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速訂單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CommentsTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents AddItemBtn As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EmpName As System.Windows.Forms.Label
    Friend WithEvents KSEmpID As System.Windows.Forms.TextBox
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents sapEmpId As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
