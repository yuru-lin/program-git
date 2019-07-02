<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_ContractFarms
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
        Me.Label9 = New System.Windows.Forms.Label
        Me.AddToB1Btn = New System.Windows.Forms.Button
        Me.U_C02 = New System.Windows.Forms.TextBox
        Me.U_C01 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ItemDGV = New System.Windows.Forms.DataGridView
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.EndDate = New System.Windows.Forms.DateTimePicker
        Me.StartDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.CodeBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.ItemDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 49
        Me.Label9.Text = "項目："
        '
        'AddToB1Btn
        '
        Me.AddToB1Btn.Location = New System.Drawing.Point(397, 449)
        Me.AddToB1Btn.Name = "AddToB1Btn"
        Me.AddToB1Btn.Size = New System.Drawing.Size(75, 23)
        Me.AddToB1Btn.TabIndex = 48
        Me.AddToB1Btn.Text = "新增"
        Me.AddToB1Btn.UseVisualStyleBackColor = True
        '
        'U_C02
        '
        Me.U_C02.Location = New System.Drawing.Point(283, 448)
        Me.U_C02.Name = "U_C02"
        Me.U_C02.ReadOnly = True
        Me.U_C02.Size = New System.Drawing.Size(95, 22)
        Me.U_C02.TabIndex = 47
        '
        'U_C01
        '
        Me.U_C01.Location = New System.Drawing.Point(100, 448)
        Me.U_C01.Name = "U_C01"
        Me.U_C01.ReadOnly = True
        Me.U_C01.Size = New System.Drawing.Size(95, 22)
        Me.U_C01.TabIndex = 46
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(195, 451)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "契養批號："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 451)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "合約編號："
        '
        'ItemDGV
        '
        Me.ItemDGV.AllowUserToAddRows = False
        Me.ItemDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ItemDGV.Location = New System.Drawing.Point(15, 170)
        Me.ItemDGV.Name = "ItemDGV"
        Me.ItemDGV.ReadOnly = True
        Me.ItemDGV.RowTemplate.Height = 24
        Me.ItemDGV.Size = New System.Drawing.Size(457, 273)
        Me.ItemDGV.TabIndex = 43
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(388, 141)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 42
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'EndDate
        '
        Me.EndDate.Location = New System.Drawing.Point(324, 113)
        Me.EndDate.Name = "EndDate"
        Me.EndDate.Size = New System.Drawing.Size(139, 22)
        Me.EndDate.TabIndex = 41
        '
        'StartDate
        '
        Me.StartDate.Location = New System.Drawing.Point(99, 113)
        Me.StartDate.Name = "StartDate"
        Me.StartDate.Size = New System.Drawing.Size(139, 22)
        Me.StartDate.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(237, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "結束日期："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "開始日期："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(250, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 65)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "※編號、名稱 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "擇一輸入即可 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "客戶名稱按Tab鍵" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "可模糊查詢"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "客戶名稱："
        '
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(106, 55)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(140, 22)
        Me.CardName.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "客戶編號："
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(106, 21)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(140, 22)
        Me.CardCode.TabIndex = 33
        '
        'CodeBox
        '
        Me.CodeBox.Location = New System.Drawing.Point(106, 83)
        Me.CodeBox.MaxLength = 1
        Me.CodeBox.Name = "CodeBox"
        Me.CodeBox.Size = New System.Drawing.Size(140, 22)
        Me.CodeBox.TabIndex = 50
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "合約別碼："
        '
        'A_ContractFarms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 544)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CodeBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.AddToB1Btn)
        Me.Controls.Add(Me.U_C02)
        Me.Controls.Add(Me.U_C01)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ItemDGV)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.EndDate)
        Me.Controls.Add(Me.StartDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CardName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CardCode)
        Me.Name = "A_ContractFarms"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "新增契養批號"
        CType(Me.ItemDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents AddToB1Btn As System.Windows.Forms.Button
    Friend WithEvents U_C02 As System.Windows.Forms.TextBox
    Friend WithEvents U_C01 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ItemDGV As System.Windows.Forms.DataGridView
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents EndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents StartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents CodeBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
