<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QckAddOWOR
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
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.ProductType = New System.Windows.Forms.ComboBox
        Me.M03 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TaxDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItemCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPlanQty = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(407, 144)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 26
        Me.SaveBtn.Text = "儲存"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "生產類型："
        '
        'ProductType
        '
        Me.ProductType.FormattingEnabled = True
        Me.ProductType.Items.AddRange(New Object() {"2-1 分切-土雞", "2-2 分切-烏骨雞", "2-3 分切-人家土雞", "2-4 分切-土雞", "2-6 分切-肉雞", "2-7 分切-白露花", "2-8 分切-桂丁土", "3-1 領改-土雞", "3-2 領改-烏骨雞", "3-3 領改-人家土雞", "3-4 領改-桂丁土雞", "3-5 領改-白露花", "3-6 領改-肉雞", "3-7 領改-黃金雞", "4-1 代宰香草雞毛雞", "5-1 代分切-香草雞", "6-1 代領改-香草雞", "D-1 委外分切"})
        Me.ProductType.Location = New System.Drawing.Point(100, 12)
        Me.ProductType.Name = "ProductType"
        Me.ProductType.Size = New System.Drawing.Size(150, 20)
        Me.ProductType.TabIndex = 35
        '
        'M03
        '
        Me.M03.Location = New System.Drawing.Point(371, 11)
        Me.M03.Name = "M03"
        Me.M03.Size = New System.Drawing.Size(111, 22)
        Me.M03.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(276, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "製單編號："
        '
        'TaxDate
        '
        Me.TaxDate.Location = New System.Drawing.Point(330, 52)
        Me.TaxDate.Name = "TaxDate"
        Me.TaxDate.Size = New System.Drawing.Size(120, 22)
        Me.TaxDate.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "文件日期："
        '
        'DocDate
        '
        Me.DocDate.Location = New System.Drawing.Point(108, 52)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(120, 22)
        Me.DocDate.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "過帳日期："
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(107, 93)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(111, 22)
        Me.txtItemCode.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "產品號碼："
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(331, 93)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(111, 22)
        Me.txtItemName.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(236, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "產品說明："
        '
        'txtPlanQty
        '
        Me.txtPlanQty.Location = New System.Drawing.Point(107, 134)
        Me.txtPlanQty.Name = "txtPlanQty"
        Me.txtPlanQty.Size = New System.Drawing.Size(111, 22)
        Me.txtPlanQty.TabIndex = 54
        Me.txtPlanQty.Text = "9999999"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "計劃數量："
        '
        'B_QckAddOWOR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 179)
        Me.Controls.Add(Me.txtPlanQty)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.M03)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TaxDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProductType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SaveBtn)
        Me.Name = "B_QckAddOWOR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速新增生產訂單"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProductType As System.Windows.Forms.ComboBox
    Friend WithEvents M03 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TaxDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPlanQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
