<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_AddSchedule
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.ItemNameTxt = New System.Windows.Forms.TextBox
        Me.ItemCodeTxt = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CardName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CardCode = New System.Windows.Forms.TextBox
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.NeedQuantitytxt = New System.Windows.Forms.TextBox
        Me.btnAddToDB = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "存編："
        '
        'ItemNameTxt
        '
        Me.ItemNameTxt.Location = New System.Drawing.Point(332, 41)
        Me.ItemNameTxt.Name = "ItemNameTxt"
        Me.ItemNameTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemNameTxt.TabIndex = 51
        '
        'ItemCodeTxt
        '
        Me.ItemCodeTxt.Location = New System.Drawing.Point(99, 41)
        Me.ItemCodeTxt.Name = "ItemCodeTxt"
        Me.ItemCodeTxt.Size = New System.Drawing.Size(140, 22)
        Me.ItemCodeTxt.TabIndex = 50
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(244, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "項目名稱："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(245, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "客戶名稱："
        '
        'CardName
        '
        Me.CardName.Location = New System.Drawing.Point(333, 6)
        Me.CardName.Name = "CardName"
        Me.CardName.Size = New System.Drawing.Size(140, 22)
        Me.CardName.TabIndex = 47
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "客戶編號："
        '
        'CardCode
        '
        Me.CardCode.Location = New System.Drawing.Point(99, 6)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.Size = New System.Drawing.Size(140, 22)
        Me.CardCode.TabIndex = 45
        '
        'ToDate
        '
        Me.ToDate.Location = New System.Drawing.Point(263, 76)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(107, 22)
        Me.ToDate.TabIndex = 57
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(239, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "至"
        '
        'FromDate
        '
        Me.FromDate.Location = New System.Drawing.Point(119, 76)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(107, 22)
        Me.FromDate.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "需完成期間："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "需求數量："
        '
        'NeedQuantitytxt
        '
        Me.NeedQuantitytxt.Location = New System.Drawing.Point(99, 111)
        Me.NeedQuantitytxt.Name = "NeedQuantitytxt"
        Me.NeedQuantitytxt.Size = New System.Drawing.Size(140, 22)
        Me.NeedQuantitytxt.TabIndex = 58
        '
        'btnAddToDB
        '
        Me.btnAddToDB.Location = New System.Drawing.Point(382, 123)
        Me.btnAddToDB.Name = "btnAddToDB"
        Me.btnAddToDB.Size = New System.Drawing.Size(90, 23)
        Me.btnAddToDB.TabIndex = 60
        Me.btnAddToDB.Text = "新增至資料庫"
        Me.btnAddToDB.UseVisualStyleBackColor = True
        '
        'B_AddSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 158)
        Me.Controls.Add(Me.btnAddToDB)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NeedQuantitytxt)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ItemNameTxt)
        Me.Controls.Add(Me.ItemCodeTxt)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CardName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CardCode)
        Me.Name = "B_AddSchedule"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "新增排程"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ItemNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents ItemCodeTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CardName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CardCode As System.Windows.Forms.TextBox
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NeedQuantitytxt As System.Windows.Forms.TextBox
    Friend WithEvents btnAddToDB As System.Windows.Forms.Button
End Class
