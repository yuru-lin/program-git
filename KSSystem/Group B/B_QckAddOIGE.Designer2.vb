<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_QckAddOIGE
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
        Me.ProductType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.TaxDate = New System.Windows.Forms.DateTimePicker
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.CK02 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Comm = New System.Windows.Forms.TextBox
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProductType
        '
        Me.ProductType.FormattingEnabled = True
        Me.ProductType.Items.AddRange(New Object() {"2-1 分切-土雞(全雞)", "2-2 分切-烏骨雞(全雞)", "2-3 分切-人家土雞(全雞)", "3-1 領改-土雞(全雞)", "3-2 領改-烏骨雞(全雞)", "2-2 好市多", "D-1 委外代工", "空白領料單", "3-3 好市多", "2-2 廣之鄕", "2-1 超市"})
        Me.ProductType.Location = New System.Drawing.Point(120, 12)
        Me.ProductType.Name = "ProductType"
        Me.ProductType.Size = New System.Drawing.Size(150, 20)
        Me.ProductType.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "預領單類型："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "文件日期："
        '
        'DocDate
        '
        Me.DocDate.Location = New System.Drawing.Point(108, 50)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(120, 22)
        Me.DocDate.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "過帳日期："
        '
        'TaxDate
        '
        Me.TaxDate.Location = New System.Drawing.Point(330, 50)
        Me.TaxDate.Name = "TaxDate"
        Me.TaxDate.Size = New System.Drawing.Size(120, 22)
        Me.TaxDate.TabIndex = 38
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 78)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(470, 396)
        Me.DGV1.TabIndex = 39
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(407, 527)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 40
        Me.SaveBtn.Text = "儲存"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(276, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "製單編號："
        '
        'CK02
        '
        Me.CK02.Location = New System.Drawing.Point(371, 11)
        Me.CK02.Name = "CK02"
        Me.CK02.Size = New System.Drawing.Size(111, 22)
        Me.CK02.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 483)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "備註："
        '
        'Comm
        '
        Me.Comm.Location = New System.Drawing.Point(70, 480)
        Me.Comm.Multiline = True
        Me.Comm.Name = "Comm"
        Me.Comm.Size = New System.Drawing.Size(168, 70)
        Me.Comm.TabIndex = 44
        '
        'B_QckAddOIGE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 562)
        Me.Controls.Add(Me.Comm)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CK02)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.TaxDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProductType)
        Me.Controls.Add(Me.Label3)
        Me.Name = "B_QckAddOIGE"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速新增預領單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProductType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TaxDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CK02 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Comm As System.Windows.Forms.TextBox
End Class
