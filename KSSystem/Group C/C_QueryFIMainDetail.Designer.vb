<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_QueryFIMainDetail
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtFI101 = New System.Windows.Forms.TextBox
        Me.RRB2 = New System.Windows.Forms.RadioButton
        Me.RRB1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cobStatus = New System.Windows.Forms.ComboBox
        Me.btnsearch = New System.Windows.Forms.Button
        Me.RB2 = New System.Windows.Forms.RadioButton
        Me.RB1 = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgvBarcode = New System.Windows.Forms.DataGridView
        Me.dgvSourceList = New System.Windows.Forms.DataGridView
        Me.dgvSourceMain = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btndelete = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.cobUpdateStatus = New System.Windows.Forms.ComboBox
        Me.btnConfirm = New System.Windows.Forms.Button
        Me.btnConfonDetail = New System.Windows.Forms.Button
        Me.cobUpdateDetail = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSourceList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnsearch)
        Me.Panel1.Controls.Add(Me.RB2)
        Me.Panel1.Controls.Add(Me.RB1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 43)
        Me.Panel1.TabIndex = 170
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtFI101)
        Me.Panel2.Controls.Add(Me.RRB2)
        Me.Panel2.Controls.Add(Me.RRB1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cobStatus)
        Me.Panel2.Location = New System.Drawing.Point(149, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(508, 35)
        Me.Panel2.TabIndex = 187
        '
        'txtFI101
        '
        Me.txtFI101.Location = New System.Drawing.Point(366, 5)
        Me.txtFI101.Name = "txtFI101"
        Me.txtFI101.Size = New System.Drawing.Size(134, 22)
        Me.txtFI101.TabIndex = 53
        '
        'RRB2
        '
        Me.RRB2.AutoSize = True
        Me.RRB2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.RRB2.Location = New System.Drawing.Point(263, 6)
        Me.RRB2.Name = "RRB2"
        Me.RRB2.Size = New System.Drawing.Size(106, 20)
        Me.RRB2.TabIndex = 52
        Me.RRB2.Text = "生產單號："
        Me.RRB2.UseVisualStyleBackColor = True
        '
        'RRB1
        '
        Me.RRB1.AutoSize = True
        Me.RRB1.Checked = True
        Me.RRB1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.RRB1.Location = New System.Drawing.Point(3, 6)
        Me.RRB1.Name = "RRB1"
        Me.RRB1.Size = New System.Drawing.Size(138, 20)
        Me.RRB1.TabIndex = 51
        Me.RRB1.TabStop = True
        Me.RRB1.Text = "生產單號狀態："
        Me.RRB1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(90, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 16)
        Me.Label1.TabIndex = 45
        '
        'cobStatus
        '
        Me.cobStatus.FormattingEnabled = True
        Me.cobStatus.Items.AddRange(New Object() {"1:進行中 ", "2:已產生 ", "3:已確認 ", "4:已入B1"})
        Me.cobStatus.Location = New System.Drawing.Point(141, 6)
        Me.cobStatus.Name = "cobStatus"
        Me.cobStatus.Size = New System.Drawing.Size(103, 20)
        Me.cobStatus.TabIndex = 50
        '
        'btnsearch
        '
        Me.btnsearch.Location = New System.Drawing.Point(675, 9)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(75, 23)
        Me.btnsearch.TabIndex = 49
        Me.btnsearch.Text = "查詢"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB2.Location = New System.Drawing.Point(79, 10)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(58, 20)
        Me.RB2.TabIndex = 1
        Me.RB2.Text = "加工"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.RB1.Location = New System.Drawing.Point(13, 10)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(58, 20)
        Me.RB1.TabIndex = 0
        Me.RB1.TabStop = True
        Me.RB1.Text = "電宰"
        Me.RB1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(226, 539)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "項"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(198, 539)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 12)
        Me.Label8.TabIndex = 178
        Me.Label8.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(160, 539)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 177
        Me.Label9.Text = "共"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(575, 539)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 176
        Me.Label5.Text = "項"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(547, 539)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 12)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(509, 539)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 174
        Me.Label6.Text = "共"
        '
        'dgvBarcode
        '
        Me.dgvBarcode.AllowUserToAddRows = False
        Me.dgvBarcode.AllowUserToDeleteRows = False
        Me.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBarcode.Location = New System.Drawing.Point(598, 152)
        Me.dgvBarcode.Name = "dgvBarcode"
        Me.dgvBarcode.ReadOnly = True
        Me.dgvBarcode.RowHeadersVisible = False
        Me.dgvBarcode.RowTemplate.Height = 24
        Me.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBarcode.Size = New System.Drawing.Size(174, 206)
        Me.dgvBarcode.TabIndex = 173
        '
        'dgvSourceList
        '
        Me.dgvSourceList.AllowUserToAddRows = False
        Me.dgvSourceList.AllowUserToDeleteRows = False
        Me.dgvSourceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceList.Location = New System.Drawing.Point(14, 152)
        Me.dgvSourceList.Name = "dgvSourceList"
        Me.dgvSourceList.ReadOnly = True
        Me.dgvSourceList.RowHeadersVisible = False
        Me.dgvSourceList.RowTemplate.Height = 24
        Me.dgvSourceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSourceList.Size = New System.Drawing.Size(578, 384)
        Me.dgvSourceList.TabIndex = 172
        '
        'dgvSourceMain
        '
        Me.dgvSourceMain.AllowUserToAddRows = False
        Me.dgvSourceMain.AllowUserToDeleteRows = False
        Me.dgvSourceMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSourceMain.Location = New System.Drawing.Point(12, 78)
        Me.dgvSourceMain.Name = "dgvSourceMain"
        Me.dgvSourceMain.ReadOnly = True
        Me.dgvSourceMain.RowHeadersVisible = False
        Me.dgvSourceMain.RowTemplate.Height = 24
        Me.dgvSourceMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSourceMain.Size = New System.Drawing.Size(760, 56)
        Me.dgvSourceMain.TabIndex = 171
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(598, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "同步明細"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "生產明細表"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 63)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 12)
        Me.Label10.TabIndex = 181
        Me.Label10.Text = "生產單號"
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(683, 364)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(89, 23)
        Me.btndelete.TabIndex = 184
        Me.btndelete.Text = "刪除同步條碼"
        Me.btndelete.UseVisualStyleBackColor = True
        Me.btndelete.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 559)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 12)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "狀態改為："
        Me.Label11.Visible = False
        '
        'cobUpdateStatus
        '
        Me.cobUpdateStatus.FormattingEnabled = True
        Me.cobUpdateStatus.Items.AddRange(New Object() {"1:進行中 ", "2:已產生 ", "3:已確認 ", "4:已入B1"})
        Me.cobUpdateStatus.Location = New System.Drawing.Point(77, 555)
        Me.cobUpdateStatus.Name = "cobUpdateStatus"
        Me.cobUpdateStatus.Size = New System.Drawing.Size(121, 20)
        Me.cobUpdateStatus.TabIndex = 51
        Me.cobUpdateStatus.Visible = False
        '
        'btnConfirm
        '
        Me.btnConfirm.Location = New System.Drawing.Point(198, 554)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirm.TabIndex = 186
        Me.btnConfirm.Text = "確認"
        Me.btnConfirm.UseVisualStyleBackColor = True
        Me.btnConfirm.Visible = False
        '
        'btnConfonDetail
        '
        Me.btnConfonDetail.Location = New System.Drawing.Point(517, 553)
        Me.btnConfonDetail.Name = "btnConfonDetail"
        Me.btnConfonDetail.Size = New System.Drawing.Size(75, 23)
        Me.btnConfonDetail.TabIndex = 189
        Me.btnConfonDetail.Text = "確認"
        Me.btnConfonDetail.UseVisualStyleBackColor = True
        Me.btnConfonDetail.Visible = False
        '
        'cobUpdateDetail
        '
        Me.cobUpdateDetail.FormattingEnabled = True
        Me.cobUpdateDetail.Items.AddRange(New Object() {"1:處理中", "2:已列印", "3: 已清點", "4:已入庫", "5:標註作廢", "6:確認作廢"})
        Me.cobUpdateDetail.Location = New System.Drawing.Point(396, 554)
        Me.cobUpdateDetail.Name = "cobUpdateDetail"
        Me.cobUpdateDetail.Size = New System.Drawing.Size(121, 20)
        Me.cobUpdateDetail.TabIndex = 187
        Me.cobUpdateDetail.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(331, 558)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 12)
        Me.Label12.TabIndex = 188
        Me.Label12.Text = "狀態改為："
        Me.Label12.Visible = False
        '
        'C_QueryFIMainDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 588)
        Me.Controls.Add(Me.btnConfonDetail)
        Me.Controls.Add(Me.cobUpdateDetail)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnConfirm)
        Me.Controls.Add(Me.cobUpdateStatus)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvBarcode)
        Me.Controls.Add(Me.dgvSourceList)
        Me.Controls.Add(Me.dgvSourceMain)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "C_QueryFIMainDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "生產單明細"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvBarcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSourceList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cobStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvBarcode As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSourceList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSourceMain As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cobUpdateStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFI101 As System.Windows.Forms.TextBox
    Friend WithEvents RRB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RRB1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnConfonDetail As System.Windows.Forms.Button
    Friend WithEvents cobUpdateDetail As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
