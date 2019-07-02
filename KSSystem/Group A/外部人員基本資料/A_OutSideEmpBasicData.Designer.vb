<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A_OutSideEmpBasicData
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
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ddlYear = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ddlMonth = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ddlDate = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ddlSex = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTel = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.ddlSaleGroupType = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.DTstartDate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.DTtermDate = New System.Windows.Forms.DateTimePicker
        Me.chbstatus = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtName.Location = New System.Drawing.Point(91, 50)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(173, 30)
        Me.txtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "姓名："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "生日："
        '
        'ddlYear
        '
        Me.ddlYear.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlYear.FormattingEnabled = True
        Me.ddlYear.Location = New System.Drawing.Point(91, 95)
        Me.ddlYear.Name = "ddlYear"
        Me.ddlYear.Size = New System.Drawing.Size(94, 27)
        Me.ddlYear.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(187, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "年"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(291, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 21)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "月"
        '
        'ddlMonth
        '
        Me.ddlMonth.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlMonth.FormattingEnabled = True
        Me.ddlMonth.Location = New System.Drawing.Point(222, 95)
        Me.ddlMonth.Name = "ddlMonth"
        Me.ddlMonth.Size = New System.Drawing.Size(67, 27)
        Me.ddlMonth.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(393, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 21)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "日"
        '
        'ddlDate
        '
        Me.ddlDate.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlDate.FormattingEnabled = True
        Me.ddlDate.Location = New System.Drawing.Point(325, 95)
        Me.ddlDate.Name = "ddlDate"
        Me.ddlDate.Size = New System.Drawing.Size(67, 27)
        Me.ddlDate.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(307, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 21)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "性別："
        '
        'ddlSex
        '
        Me.ddlSex.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlSex.FormattingEnabled = True
        Me.ddlSex.Items.AddRange(New Object() {"請選擇", "0：女", "1：男"})
        Me.ddlSex.Location = New System.Drawing.Point(387, 53)
        Me.ddlSex.Name = "ddlSex"
        Me.ddlSex.Size = New System.Drawing.Size(121, 27)
        Me.ddlSex.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(171, 21)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "聯絡電話(市話)："
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(196, 144)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(173, 22)
        Me.txtTel.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(22, 185)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(171, 21)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "聯絡電話(手機)："
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(196, 185)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(173, 22)
        Me.txtMobile.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(22, 228)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 21)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "居住地址："
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(136, 228)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(68, 22)
        Me.txtZip.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(210, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 21)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "(郵遞區號)"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(136, 256)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(594, 22)
        Me.txtAddress.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(22, 294)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 21)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "電子郵件："
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(137, 294)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(322, 22)
        Me.txtEmail.TabIndex = 19
        '
        'ddlSaleGroupType
        '
        Me.ddlSaleGroupType.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ddlSaleGroupType.FormattingEnabled = True
        Me.ddlSaleGroupType.Items.AddRange(New Object() {"請選擇", "守衛", "獸醫師", "玖鼎"})
        Me.ddlSaleGroupType.Location = New System.Drawing.Point(95, 9)
        Me.ddlSaleGroupType.Name = "ddlSaleGroupType"
        Me.ddlSaleGroupType.Size = New System.Drawing.Size(121, 27)
        Me.ddlSaleGroupType.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(23, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 21)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "類型："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(254, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 21)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "任職日期："
        '
        'DTstartDate
        '
        Me.DTstartDate.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DTstartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DTstartDate.Location = New System.Drawing.Point(370, 7)
        Me.DTstartDate.Name = "DTstartDate"
        Me.DTstartDate.Size = New System.Drawing.Size(147, 30)
        Me.DTstartDate.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 344)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 21)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "備註："
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(91, 344)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemark.Size = New System.Drawing.Size(635, 101)
        Me.txtRemark.TabIndex = 27
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSave.Location = New System.Drawing.Point(683, 474)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 40)
        Me.btnSave.TabIndex = 28
        Me.btnSave.Text = "儲存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(519, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(21, 21)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "~"
        '
        'DTtermDate
        '
        Me.DTtermDate.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DTtermDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DTtermDate.Location = New System.Drawing.Point(540, 7)
        Me.DTtermDate.Name = "DTtermDate"
        Me.DTtermDate.Size = New System.Drawing.Size(145, 30)
        Me.DTtermDate.TabIndex = 30
        '
        'chbstatus
        '
        Me.chbstatus.AutoSize = True
        Me.chbstatus.Location = New System.Drawing.Point(715, 15)
        Me.chbstatus.Name = "chbstatus"
        Me.chbstatus.Size = New System.Drawing.Size(60, 16)
        Me.chbstatus.TabIndex = 31
        Me.chbstatus.Text = "已離職"
        Me.chbstatus.UseVisualStyleBackColor = True
        '
        'A_OutSideEmpBasicData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 585)
        Me.Controls.Add(Me.chbstatus)
        Me.Controls.Add(Me.DTtermDate)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.DTstartDate)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ddlSaleGroupType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMobile)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.ddlSex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ddlDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ddlMonth)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ddlYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Name = "A_OutSideEmpBasicData"
        Me.Text = "外部人員基本資料維護"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ddlYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ddlMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ddlDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ddlSex As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents ddlSaleGroupType As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DTstartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DTtermDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chbstatus As System.Windows.Forms.CheckBox
End Class
