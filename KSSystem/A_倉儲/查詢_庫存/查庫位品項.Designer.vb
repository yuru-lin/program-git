<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 查庫位品項
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.轉出Excel = New System.Windows.Forms.Button
        Me.DatePr = New System.Windows.Forms.DateTimePicker
        Me.不限日期 = New System.Windows.Forms.CheckBox
        Me.數量2 = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.R小於 = New System.Windows.Forms.RadioButton
        Me.R大於 = New System.Windows.Forms.RadioButton
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.異常 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.目前數量 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.目前品項數 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.DatePr2 = New System.Windows.Forms.DateTimePicker
        Me.選擇品項 = New System.Windows.Forms.Label
        Me.選擇儲位 = New System.Windows.Forms.Label
        Me.目前儲位 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.查詢儲位 = New System.Windows.Forms.Button
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.查詢 = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ExcelRB2 = New System.Windows.Forms.RadioButton
        Me.ExcelRB1 = New System.Windows.Forms.RadioButton
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(882, 622)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.轉出Excel)
        Me.TabPage1.Controls.Add(Me.DatePr)
        Me.TabPage1.Controls.Add(Me.不限日期)
        Me.TabPage1.Controls.Add(Me.數量2)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.DGV2)
        Me.TabPage1.Controls.Add(Me.異常)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.目前數量)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.目前品項數)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.目前儲位)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.查詢儲位)
        Me.TabPage1.Controls.Add(Me.DGV1)
        Me.TabPage1.Controls.Add(Me.查詢)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(874, 589)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "查詢儲位"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '轉出Excel
        '
        Me.轉出Excel.Location = New System.Drawing.Point(8, 62)
        Me.轉出Excel.Name = "轉出Excel"
        Me.轉出Excel.Size = New System.Drawing.Size(108, 32)
        Me.轉出Excel.TabIndex = 160
        Me.轉出Excel.Text = "轉出Excel"
        Me.轉出Excel.UseVisualStyleBackColor = True
        '
        'DatePr
        '
        Me.DatePr.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DatePr.Location = New System.Drawing.Point(610, 11)
        Me.DatePr.Name = "DatePr"
        Me.DatePr.Size = New System.Drawing.Size(177, 27)
        Me.DatePr.TabIndex = 145
        '
        '不限日期
        '
        Me.不限日期.AutoSize = True
        Me.不限日期.Checked = True
        Me.不限日期.CheckState = System.Windows.Forms.CheckState.Checked
        Me.不限日期.Location = New System.Drawing.Point(555, 7)
        Me.不限日期.Name = "不限日期"
        Me.不限日期.Size = New System.Drawing.Size(59, 36)
        Me.不限日期.TabIndex = 159
        Me.不限日期.Text = "不限" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "日期"
        Me.不限日期.UseVisualStyleBackColor = True
        '
        '數量2
        '
        Me.數量2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.數量2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.數量2.Location = New System.Drawing.Point(737, 46)
        Me.數量2.MaxLength = 3
        Me.數量2.Name = "數量2"
        Me.數量2.Size = New System.Drawing.Size(50, 27)
        Me.數量2.TabIndex = 155
        Me.數量2.Text = "3"
        Me.數量2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.R小於)
        Me.Panel2.Controls.Add(Me.R大於)
        Me.Panel2.Location = New System.Drawing.Point(672, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(71, 51)
        Me.Panel2.TabIndex = 158
        '
        'R小於
        '
        Me.R小於.AutoSize = True
        Me.R小於.Location = New System.Drawing.Point(4, 28)
        Me.R小於.Name = "R小於"
        Me.R小於.Size = New System.Drawing.Size(58, 20)
        Me.R小於.TabIndex = 1
        Me.R小於.Text = "小於"
        Me.R小於.UseVisualStyleBackColor = True
        '
        'R大於
        '
        Me.R大於.AutoSize = True
        Me.R大於.Checked = True
        Me.R大於.Location = New System.Drawing.Point(4, 4)
        Me.R大於.Name = "R大於"
        Me.R大於.Size = New System.Drawing.Size(58, 20)
        Me.R大於.TabIndex = 0
        Me.R大於.TabStop = True
        Me.R大於.Text = "大於"
        Me.R大於.UseVisualStyleBackColor = True
        '
        'DGV2
        '
        Me.DGV2.AllowUserToAddRows = False
        Me.DGV2.AllowUserToDeleteRows = False
        Me.DGV2.AllowUserToResizeColumns = False
        Me.DGV2.AllowUserToResizeRows = False
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(236, 97)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.ReadOnly = True
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(632, 489)
        Me.DGV2.TabIndex = 150
        '
        '異常
        '
        Me.異常.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.異常.Location = New System.Drawing.Point(462, 9)
        Me.異常.Name = "異常"
        Me.異常.Size = New System.Drawing.Size(75, 66)
        Me.異常.TabIndex = 157
        Me.異常.Text = "異常"
        Me.異常.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(607, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 19)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "品項數"
        '
        '目前數量
        '
        Me.目前數量.BackColor = System.Drawing.SystemColors.Window
        Me.目前數量.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.目前數量.Location = New System.Drawing.Point(386, 45)
        Me.目前數量.Name = "目前數量"
        Me.目前數量.ReadOnly = True
        Me.目前數量.Size = New System.Drawing.Size(70, 27)
        Me.目前數量.TabIndex = 154
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "數量："
        '
        '目前品項數
        '
        Me.目前品項數.BackColor = System.Drawing.SystemColors.Window
        Me.目前品項數.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.目前品項數.Location = New System.Drawing.Point(255, 45)
        Me.目前品項數.Name = "目前品項數"
        Me.目前品項數.ReadOnly = True
        Me.目前品項數.Size = New System.Drawing.Size(70, 27)
        Me.目前品項數.TabIndex = 152
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(157, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 19)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "品  項  數："
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LemonChiffon
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.DatePr2)
        Me.Panel1.Controls.Add(Me.選擇品項)
        Me.Panel1.Controls.Add(Me.選擇儲位)
        Me.Panel1.Location = New System.Drawing.Point(8, 217)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(182, 152)
        Me.Panel1.TabIndex = 149
        Me.Panel1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 19)
        Me.Label5.TabIndex = 143
        Me.Label5.Text = "目前查詢日期"
        '
        'DatePr2
        '
        Me.DatePr2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DatePr2.Location = New System.Drawing.Point(5, 122)
        Me.DatePr2.Name = "DatePr2"
        Me.DatePr2.Size = New System.Drawing.Size(162, 27)
        Me.DatePr2.TabIndex = 142
        '
        '選擇品項
        '
        Me.選擇品項.AutoSize = True
        Me.選擇品項.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.選擇品項.Location = New System.Drawing.Point(3, 29)
        Me.選擇品項.Name = "選擇品項"
        Me.選擇品項.Size = New System.Drawing.Size(85, 19)
        Me.選擇品項.TabIndex = 133
        Me.選擇品項.Text = "選擇品項"
        '
        '選擇儲位
        '
        Me.選擇儲位.AutoSize = True
        Me.選擇儲位.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.選擇儲位.Location = New System.Drawing.Point(3, 10)
        Me.選擇儲位.Name = "選擇儲位"
        Me.選擇儲位.Size = New System.Drawing.Size(85, 19)
        Me.選擇儲位.TabIndex = 132
        Me.選擇儲位.Text = "選擇儲位"
        '
        '目前儲位
        '
        Me.目前儲位.BackColor = System.Drawing.SystemColors.Window
        Me.目前儲位.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.目前儲位.Location = New System.Drawing.Point(255, 13)
        Me.目前儲位.Name = "目前儲位"
        Me.目前儲位.Size = New System.Drawing.Size(201, 27)
        Me.目前儲位.TabIndex = 146
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(157, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 19)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "查詢儲位："
        '
        '查詢儲位
        '
        Me.查詢儲位.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢儲位.Location = New System.Drawing.Point(6, 6)
        Me.查詢儲位.Name = "查詢儲位"
        Me.查詢儲位.Size = New System.Drawing.Size(146, 40)
        Me.查詢儲位.TabIndex = 148
        Me.查詢儲位.Text = "查詢儲位明細"
        Me.查詢儲位.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.AllowUserToResizeColumns = False
        Me.DGV1.AllowUserToResizeRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(6, 98)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(224, 488)
        Me.DGV1.TabIndex = 144
        '
        '查詢
        '
        Me.查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.查詢.Location = New System.Drawing.Point(793, 7)
        Me.查詢.Name = "查詢"
        Me.查詢.Size = New System.Drawing.Size(75, 66)
        Me.查詢.TabIndex = 143
        Me.查詢.Text = "查詢" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "儲位"
        Me.查詢.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ExcelRB2)
        Me.Panel3.Controls.Add(Me.ExcelRB1)
        Me.Panel3.Location = New System.Drawing.Point(118, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(139, 35)
        Me.Panel3.TabIndex = 159
        '
        'ExcelRB2
        '
        Me.ExcelRB2.AutoSize = True
        Me.ExcelRB2.Location = New System.Drawing.Point(68, 4)
        Me.ExcelRB2.Name = "ExcelRB2"
        Me.ExcelRB2.Size = New System.Drawing.Size(58, 20)
        Me.ExcelRB2.TabIndex = 1
        Me.ExcelRB2.Text = "明細"
        Me.ExcelRB2.UseVisualStyleBackColor = True
        '
        'ExcelRB1
        '
        Me.ExcelRB1.AutoSize = True
        Me.ExcelRB1.Checked = True
        Me.ExcelRB1.Location = New System.Drawing.Point(4, 4)
        Me.ExcelRB1.Name = "ExcelRB1"
        Me.ExcelRB1.Size = New System.Drawing.Size(58, 20)
        Me.ExcelRB1.TabIndex = 0
        Me.ExcelRB1.TabStop = True
        Me.ExcelRB1.Text = "項目"
        Me.ExcelRB1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(874, 589)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "異常記錄"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '查庫位品項
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 622)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "查庫位品項"
        Me.Text = "查庫位品項"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents 異常 As System.Windows.Forms.Button
    Friend WithEvents 數量2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 目前數量 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 目前品項數 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DatePr2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 選擇品項 As System.Windows.Forms.Label
    Friend WithEvents 選擇儲位 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents 目前儲位 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 查詢儲位 As System.Windows.Forms.Button
    Friend WithEvents DatePr As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents 查詢 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents R小於 As System.Windows.Forms.RadioButton
    Friend WithEvents R大於 As System.Windows.Forms.RadioButton
    Friend WithEvents 不限日期 As System.Windows.Forms.CheckBox
    Friend WithEvents 轉出Excel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ExcelRB2 As System.Windows.Forms.RadioButton
    Friend WithEvents ExcelRB1 As System.Windows.Forms.RadioButton
End Class
