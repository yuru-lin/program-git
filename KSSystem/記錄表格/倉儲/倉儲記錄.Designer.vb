<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 倉儲記錄
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
        Me.DatePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.F03 = New System.Windows.Forms.TextBox
        Me.F04 = New System.Windows.Forms.TextBox
        Me.F08 = New System.Windows.Forms.TextBox
        Me.F09 = New System.Windows.Forms.TextBox
        Me.F10 = New System.Windows.Forms.TextBox
        Me.F11 = New System.Windows.Forms.TextBox
        Me.F15 = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBox9 = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.TextBox12 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button0 = New System.Windows.Forms.Button
        Me.F02 = New System.Windows.Forms.TextBox
        Me.F05 = New System.Windows.Forms.TextBox
        Me.F06 = New System.Windows.Forms.TextBox
        Me.F07 = New System.Windows.Forms.TextBox
        Me.F12 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.F13 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.F01 = New System.Windows.Forms.ComboBox
        Me.F14 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.查詢條碼 = New System.Windows.Forms.Button
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 33)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(860, 308)
        Me.DGV1.TabIndex = 0
        '
        'DatePicker1
        '
        Me.DatePicker1.Location = New System.Drawing.Point(95, 5)
        Me.DatePicker1.Name = "DatePicker1"
        Me.DatePicker1.Size = New System.Drawing.Size(140, 22)
        Me.DatePicker1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "記錄日期："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 351)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "庫　　別："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "條　　碼："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 407)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "開機日期："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 435)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "開機時間："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 463)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "開機溫度："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 491)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "關機日期："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 519)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "關機時間："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(241, 351)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "關機溫度："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(241, 379)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "品　　溫："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(241, 407)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "搬貨日期："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(241, 435)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "搬貨時間："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(485, 463)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 32)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "處置結果" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "及說明："
        '
        'F03
        '
        Me.F03.Location = New System.Drawing.Point(95, 404)
        Me.F03.Name = "F03"
        Me.F03.Size = New System.Drawing.Size(140, 22)
        Me.F03.TabIndex = 17
        '
        'F04
        '
        Me.F04.Location = New System.Drawing.Point(95, 432)
        Me.F04.Name = "F04"
        Me.F04.Size = New System.Drawing.Size(140, 22)
        Me.F04.TabIndex = 18
        '
        'F08
        '
        Me.F08.Location = New System.Drawing.Point(339, 348)
        Me.F08.Name = "F08"
        Me.F08.Size = New System.Drawing.Size(140, 22)
        Me.F08.TabIndex = 22
        '
        'F09
        '
        Me.F09.Location = New System.Drawing.Point(339, 376)
        Me.F09.Name = "F09"
        Me.F09.Size = New System.Drawing.Size(140, 22)
        Me.F09.TabIndex = 23
        '
        'F10
        '
        Me.F10.Location = New System.Drawing.Point(339, 404)
        Me.F10.Name = "F10"
        Me.F10.Size = New System.Drawing.Size(140, 22)
        Me.F10.TabIndex = 24
        '
        'F11
        '
        Me.F11.Location = New System.Drawing.Point(339, 432)
        Me.F11.Name = "F11"
        Me.F11.Size = New System.Drawing.Size(140, 22)
        Me.F11.TabIndex = 25
        '
        'F15
        '
        Me.F15.AcceptsReturn = True
        Me.F15.Location = New System.Drawing.Point(563, 460)
        Me.F15.Multiline = True
        Me.F15.Name = "F15"
        Me.F15.Size = New System.Drawing.Size(163, 98)
        Me.F15.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.TextBox9)
        Me.Panel1.Controls.Add(Me.TextBox10)
        Me.Panel1.Controls.Add(Me.TextBox12)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.TextBox11)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Location = New System.Drawing.Point(684, 376)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(198, 182)
        Me.Panel1.TabIndex = 27
        Me.Panel1.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 16)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Sid："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 16)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Pid："
        '
        'TextBox9
        '
        Me.TextBox9.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TextBox9.Location = New System.Drawing.Point(44, 2)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(140, 22)
        Me.TextBox9.TabIndex = 28
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(44, 27)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(140, 22)
        Me.TextBox10.TabIndex = 30
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(44, 77)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(140, 22)
        Me.TextBox12.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 16)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Kid1"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(44, 52)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(140, 22)
        Me.TextBox11.TabIndex = 32
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 83)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Kid2"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(485, 346)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "新增"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(485, 374)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "修改"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(485, 402)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "更新"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(485, 430)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 31
        Me.Button4.Text = "刪除"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button0
        '
        Me.Button0.Location = New System.Drawing.Point(241, 4)
        Me.Button0.Name = "Button0"
        Me.Button0.Size = New System.Drawing.Size(75, 23)
        Me.Button0.TabIndex = 32
        Me.Button0.Text = "查詢"
        Me.Button0.UseVisualStyleBackColor = True
        '
        'F02
        '
        Me.F02.Location = New System.Drawing.Point(95, 376)
        Me.F02.Name = "F02"
        Me.F02.ReadOnly = True
        Me.F02.Size = New System.Drawing.Size(140, 22)
        Me.F02.TabIndex = 35
        Me.F02.Visible = False
        '
        'F05
        '
        Me.F05.Location = New System.Drawing.Point(95, 460)
        Me.F05.Name = "F05"
        Me.F05.Size = New System.Drawing.Size(140, 22)
        Me.F05.TabIndex = 36
        '
        'F06
        '
        Me.F06.Location = New System.Drawing.Point(95, 488)
        Me.F06.Name = "F06"
        Me.F06.Size = New System.Drawing.Size(140, 22)
        Me.F06.TabIndex = 37
        '
        'F07
        '
        Me.F07.Location = New System.Drawing.Point(95, 516)
        Me.F07.Name = "F07"
        Me.F07.Size = New System.Drawing.Size(140, 22)
        Me.F07.TabIndex = 38
        '
        'F12
        '
        Me.F12.Location = New System.Drawing.Point(339, 460)
        Me.F12.Name = "F12"
        Me.F12.Size = New System.Drawing.Size(140, 22)
        Me.F12.TabIndex = 40
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(241, 463)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 16)
        Me.Label18.TabIndex = 39
        Me.Label18.Text = "搬完日期："
        '
        'F13
        '
        Me.F13.Location = New System.Drawing.Point(339, 488)
        Me.F13.Name = "F13"
        Me.F13.Size = New System.Drawing.Size(140, 22)
        Me.F13.TabIndex = 42
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(241, 491)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 16)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "搬完時間："
        '
        'F01
        '
        Me.F01.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.F01.FormattingEnabled = True
        Me.F01.Items.AddRange(New Object() {"急速庫 1號", "急速庫 2號", "急速庫 3號", "急速庫 4號", "急速庫 5號"})
        Me.F01.Location = New System.Drawing.Point(95, 348)
        Me.F01.Name = "F01"
        Me.F01.Size = New System.Drawing.Size(140, 20)
        Me.F01.TabIndex = 43
        '
        'F14
        '
        Me.F14.Location = New System.Drawing.Point(339, 516)
        Me.F14.Name = "F14"
        Me.F14.Size = New System.Drawing.Size(140, 22)
        Me.F14.TabIndex = 45
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(241, 519)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 16)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "異常狀況："
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(797, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 47
        Me.Button5.Text = "查詢所有"
        Me.Button5.UseVisualStyleBackColor = True
        '
        '查詢條碼
        '
        Me.查詢條碼.Location = New System.Drawing.Point(95, 376)
        Me.查詢條碼.Name = "查詢條碼"
        Me.查詢條碼.Size = New System.Drawing.Size(75, 23)
        Me.查詢條碼.TabIndex = 48
        Me.查詢條碼.Text = "查詢條碼"
        Me.查詢條碼.UseVisualStyleBackColor = True
        '
        '倉儲記錄
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.查詢條碼)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.F14)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.F01)
        Me.Controls.Add(Me.F13)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.F12)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.F07)
        Me.Controls.Add(Me.F06)
        Me.Controls.Add(Me.F05)
        Me.Controls.Add(Me.F02)
        Me.Controls.Add(Me.Button0)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.F15)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.F11)
        Me.Controls.Add(Me.F10)
        Me.Controls.Add(Me.F09)
        Me.Controls.Add(Me.F08)
        Me.Controls.Add(Me.F04)
        Me.Controls.Add(Me.F03)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DatePicker1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "倉儲記錄"
        Me.Text = "倉儲記錄"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents DatePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents F03 As System.Windows.Forms.TextBox
    Friend WithEvents F04 As System.Windows.Forms.TextBox
    Friend WithEvents F08 As System.Windows.Forms.TextBox
    Friend WithEvents F09 As System.Windows.Forms.TextBox
    Friend WithEvents F10 As System.Windows.Forms.TextBox
    Friend WithEvents F11 As System.Windows.Forms.TextBox
    Friend WithEvents F15 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button0 As System.Windows.Forms.Button
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents F02 As System.Windows.Forms.TextBox
    Friend WithEvents F05 As System.Windows.Forms.TextBox
    Friend WithEvents F06 As System.Windows.Forms.TextBox
    Friend WithEvents F07 As System.Windows.Forms.TextBox
    Friend WithEvents F12 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents F13 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents F01 As System.Windows.Forms.ComboBox
    Friend WithEvents F14 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents 查詢條碼 As System.Windows.Forms.Button
End Class
