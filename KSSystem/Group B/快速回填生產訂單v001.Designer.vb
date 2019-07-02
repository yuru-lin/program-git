<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 快速回填生產訂單v001
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DocDate = New System.Windows.Forms.DateTimePicker
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.SearchBtn = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtM7 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtM10 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtM8 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtM12 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtM9 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CkBoxM04 = New System.Windows.Forms.CheckBox
        Me.CalcBtn = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPlannedQty = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtM02 = New System.Windows.Forms.TextBox
        Me.cmbU_M01 = New System.Windows.Forms.ComboBox
        Me.lbDocNum = New System.Windows.Forms.Label
        Me.lbM03 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Gb領改日期 = New System.Windows.Forms.GroupBox
        Me.Bu回存日期 = New System.Windows.Forms.Button
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.UCnum = New System.Windows.Forms.TextBox
        Me.SaveBtn2 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Lt日期 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Gb領改日期.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(13, 8)
        Me.DGV1.MultiSelect = False
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(898, 378)
        Me.DGV1.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 392)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "文件號碼："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(638, 392)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "到期日："
        '
        'DocDate
        '
        Me.DocDate.Location = New System.Drawing.Point(707, 389)
        Me.DocDate.Name = "DocDate"
        Me.DocDate.Size = New System.Drawing.Size(111, 22)
        Me.DocDate.TabIndex = 42
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(412, 8)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 44
        Me.SaveBtn.Text = "更新"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(834, 388)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(75, 23)
        Me.SearchBtn.TabIndex = 45
        Me.SearchBtn.Text = "查詢"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "投入重量："
        '
        'txtM7
        '
        Me.txtM7.Location = New System.Drawing.Point(89, 37)
        Me.txtM7.Name = "txtM7"
        Me.txtM7.Size = New System.Drawing.Size(111, 22)
        Me.txtM7.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(210, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "會磅重量："
        '
        'txtM10
        '
        Me.txtM10.Location = New System.Drawing.Point(295, 37)
        Me.txtM10.Name = "txtM10"
        Me.txtM10.Size = New System.Drawing.Size(111, 22)
        Me.txtM10.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "死亡隻數："
        '
        'txtM8
        '
        Me.txtM8.Location = New System.Drawing.Point(89, 63)
        Me.txtM8.Name = "txtM8"
        Me.txtM8.Size = New System.Drawing.Size(111, 22)
        Me.txtM8.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 57
        Me.Label4.Text = "投入隻數："
        '
        'txtM12
        '
        Me.txtM12.Location = New System.Drawing.Point(89, 10)
        Me.txtM12.Name = "txtM12"
        Me.txtM12.Size = New System.Drawing.Size(111, 22)
        Me.txtM12.TabIndex = 58
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "廢棄隻數："
        '
        'txtM9
        '
        Me.txtM9.Location = New System.Drawing.Point(89, 90)
        Me.txtM9.Name = "txtM9"
        Me.txtM9.Size = New System.Drawing.Size(111, 22)
        Me.txtM9.TabIndex = 60
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(192, 392)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 62
        Me.Label8.Text = "製單編號："
        '
        'CkBoxM04
        '
        Me.CkBoxM04.AutoSize = True
        Me.CkBoxM04.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.CkBoxM04.Location = New System.Drawing.Point(583, 9)
        Me.CkBoxM04.Name = "CkBoxM04"
        Me.CkBoxM04.Size = New System.Drawing.Size(91, 20)
        Me.CkBoxM04.TabIndex = 65
        Me.CkBoxM04.Text = "隱藏製單"
        Me.CkBoxM04.UseVisualStyleBackColor = True
        '
        'CalcBtn
        '
        Me.CalcBtn.Location = New System.Drawing.Point(213, 119)
        Me.CalcBtn.Name = "CalcBtn"
        Me.CalcBtn.Size = New System.Drawing.Size(193, 23)
        Me.CalcBtn.TabIndex = 66
        Me.CalcBtn.Text = "計算產出率"
        Me.CalcBtn.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(210, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "計劃數量："
        '
        'txtPlannedQty
        '
        Me.txtPlannedQty.Location = New System.Drawing.Point(295, 10)
        Me.txtPlannedQty.Name = "txtPlannedQty"
        Me.txtPlannedQty.Size = New System.Drawing.Size(111, 22)
        Me.txtPlannedQty.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(418, 392)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "生產選項："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(210, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 72
        Me.Label11.Text = "生產總數："
        '
        'txtM02
        '
        Me.txtM02.Location = New System.Drawing.Point(295, 63)
        Me.txtM02.Name = "txtM02"
        Me.txtM02.Size = New System.Drawing.Size(111, 22)
        Me.txtM02.TabIndex = 73
        '
        'cmbU_M01
        '
        Me.cmbU_M01.FormattingEnabled = True
        Me.cmbU_M01.Location = New System.Drawing.Point(501, 389)
        Me.cmbU_M01.Name = "cmbU_M01"
        Me.cmbU_M01.Size = New System.Drawing.Size(121, 20)
        Me.cmbU_M01.TabIndex = 70
        '
        'lbDocNum
        '
        Me.lbDocNum.AutoSize = True
        Me.lbDocNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbDocNum.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbDocNum.Location = New System.Drawing.Point(92, 392)
        Me.lbDocNum.Name = "lbDocNum"
        Me.lbDocNum.Size = New System.Drawing.Size(40, 16)
        Me.lbDocNum.TabIndex = 63
        Me.lbDocNum.Text = "文件"
        '
        'lbM03
        '
        Me.lbM03.AutoSize = True
        Me.lbM03.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbM03.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbM03.Location = New System.Drawing.Point(274, 392)
        Me.lbM03.Name = "lbM03"
        Me.lbM03.Size = New System.Drawing.Size(40, 16)
        Me.lbM03.TabIndex = 64
        Me.lbM03.Text = "製單"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(680, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 74
        Me.Button1.Text = "製單開關"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(13, 415)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(898, 216)
        Me.TabControl1.TabIndex = 75
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Gb領改日期)
        Me.TabPage1.Controls.Add(Me.txtM02)
        Me.TabPage1.Controls.Add(Me.txtPlannedQty)
        Me.TabPage1.Controls.Add(Me.txtM10)
        Me.TabPage1.Controls.Add(Me.txtM7)
        Me.TabPage1.Controls.Add(Me.txtM8)
        Me.TabPage1.Controls.Add(Me.txtM9)
        Me.TabPage1.Controls.Add(Me.txtM12)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.SaveBtn)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.CkBoxM04)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.CalcBtn)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(890, 190)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "生管"
        '
        'Gb領改日期
        '
        Me.Gb領改日期.Controls.Add(Me.Lt日期)
        Me.Gb領改日期.Controls.Add(Me.Bu回存日期)
        Me.Gb領改日期.Controls.Add(Me.DGV2)
        Me.Gb領改日期.Location = New System.Drawing.Point(583, 35)
        Me.Gb領改日期.Name = "Gb領改日期"
        Me.Gb領改日期.Size = New System.Drawing.Size(301, 149)
        Me.Gb領改日期.TabIndex = 75
        Me.Gb領改日期.TabStop = False
        Me.Gb領改日期.Text = "領改製造日期回傳"
        Me.Gb領改日期.Visible = False
        '
        'Bu回存日期
        '
        Me.Bu回存日期.Location = New System.Drawing.Point(6, 14)
        Me.Bu回存日期.Name = "Bu回存日期"
        Me.Bu回存日期.Size = New System.Drawing.Size(75, 23)
        Me.Bu回存日期.TabIndex = 76
        Me.Bu回存日期.Text = "回存日期"
        Me.Bu回存日期.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(6, 43)
        Me.DGV2.MultiSelect = False
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersVisible = False
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV2.Size = New System.Drawing.Size(289, 100)
        Me.DGV2.TabIndex = 76
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.UCnum)
        Me.TabPage2.Controls.Add(Me.SaveBtn2)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Location = New System.Drawing.Point(4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(890, 190)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "契養"
        '
        'UCnum
        '
        Me.UCnum.Location = New System.Drawing.Point(89, 10)
        Me.UCnum.Name = "UCnum"
        Me.UCnum.Size = New System.Drawing.Size(208, 22)
        Me.UCnum.TabIndex = 76
        '
        'SaveBtn2
        '
        Me.SaveBtn2.Location = New System.Drawing.Point(222, 38)
        Me.SaveBtn2.Name = "SaveBtn2"
        Me.SaveBtn2.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn2.TabIndex = 75
        Me.SaveBtn2.Text = "更新"
        Me.SaveBtn2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "契養批號："
        '
        'Lt日期
        '
        Me.Lt日期.AutoSize = True
        Me.Lt日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt日期.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Lt日期.Location = New System.Drawing.Point(94, 18)
        Me.Lt日期.Name = "Lt日期"
        Me.Lt日期.Size = New System.Drawing.Size(40, 16)
        Me.Lt日期.TabIndex = 76
        Me.Lt日期.Text = "日期"
        '
        '快速回填生產訂單v001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 631)
        Me.Controls.Add(Me.lbM03)
        Me.Controls.Add(Me.DocDate)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.cmbU_M01)
        Me.Controls.Add(Me.lbDocNum)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Name = "快速回填生產訂單v001"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "快速回填生產訂單"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Gb領改日期.ResumeLayout(False)
        Me.Gb領改日期.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents SearchBtn As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtM7 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtM10 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtM8 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtM12 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtM9 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CkBoxM04 As System.Windows.Forms.CheckBox
    Friend WithEvents CalcBtn As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPlannedQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtM02 As System.Windows.Forms.TextBox
    Friend WithEvents cmbU_M01 As System.Windows.Forms.ComboBox
    Friend WithEvents lbDocNum As System.Windows.Forms.Label
    Friend WithEvents lbM03 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SaveBtn2 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents UCnum As System.Windows.Forms.TextBox
    Friend WithEvents Gb領改日期 As System.Windows.Forms.GroupBox
    Friend WithEvents Bu回存日期 As System.Windows.Forms.Button
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents Lt日期 As System.Windows.Forms.Label
End Class
