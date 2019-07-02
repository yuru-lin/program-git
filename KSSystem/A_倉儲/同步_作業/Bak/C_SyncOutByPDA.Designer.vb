<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class C_SyncOutByPDA
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
        Me.DelPDA = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.UpdQty = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnUndel = New System.Windows.Forms.Button
        Me.btnDel = New System.Windows.Forms.Button
        Me.ScanedDataGridView = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSync = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnReadPDA = New System.Windows.Forms.Button
        CType(Me.ScanedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DelPDA
        '
        Me.DelPDA.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DelPDA.Location = New System.Drawing.Point(532, 355)
        Me.DelPDA.Name = "DelPDA"
        Me.DelPDA.Size = New System.Drawing.Size(95, 37)
        Me.DelPDA.TabIndex = 63
        Me.DelPDA.Text = "刪除PDA資料"
        Me.DelPDA.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(538, 494)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(167, 32)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "*請仔細檢查 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "作業別、條碼、儲位!"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(502, 529)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 16)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "項"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(459, 529)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(416, 529)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 16)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "共"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkRed
        Me.Label6.Location = New System.Drawing.Point(532, 292)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 60)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "*只有在外加的條碼上才" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "需要更新 ""數量""、" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """來源單號""、""來源單列號""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " 三個欄位"
        '
        'UpdQty
        '
        Me.UpdQty.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.UpdQty.Location = New System.Drawing.Point(532, 251)
        Me.UpdQty.Name = "UpdQty"
        Me.UpdQty.Size = New System.Drawing.Size(84, 38)
        Me.UpdQty.TabIndex = 57
        Me.UpdQty.Text = "更新欄位"
        Me.UpdQty.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(110, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 45)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "* 藍: 未掃瞄, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* 黃: 外加, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "* 紅: 外加取消"
        '
        'btnUndel
        '
        Me.btnUndel.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnUndel.Location = New System.Drawing.Point(10, 7)
        Me.btnUndel.Name = "btnUndel"
        Me.btnUndel.Size = New System.Drawing.Size(95, 37)
        Me.btnUndel.TabIndex = 55
        Me.btnUndel.Text = "回復外加"
        Me.btnUndel.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(9, 55)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(95, 37)
        Me.btnDel.TabIndex = 54
        Me.btnDel.Text = "取消外加"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'ScanedDataGridView
        '
        Me.ScanedDataGridView.AllowUserToAddRows = False
        Me.ScanedDataGridView.AllowUserToDeleteRows = False
        Me.ScanedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ScanedDataGridView.Location = New System.Drawing.Point(12, 60)
        Me.ScanedDataGridView.MultiSelect = False
        Me.ScanedDataGridView.Name = "ScanedDataGridView"
        Me.ScanedDataGridView.RowHeadersWidth = 15
        Me.ScanedDataGridView.RowTemplate.Height = 24
        Me.ScanedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ScanedDataGridView.Size = New System.Drawing.Size(514, 466)
        Me.ScanedDataGridView.TabIndex = 50
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(13, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 19)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "PDA中已掃瞄出庫項目"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(267, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 24)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "凱馨出庫清點同步作業"
        '
        'btnSync
        '
        Me.btnSync.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSync.Location = New System.Drawing.Point(532, 439)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(134, 52)
        Me.btnSync.TabIndex = 45
        Me.btnSync.Text = "同步至伺服器"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnDel)
        Me.Panel1.Controls.Add(Me.btnUndel)
        Me.Panel1.Location = New System.Drawing.Point(532, 141)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(227, 104)
        Me.Panel1.TabIndex = 64
        '
        'btnReadPDA
        '
        Me.btnReadPDA.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnReadPDA.Location = New System.Drawing.Point(532, 60)
        Me.btnReadPDA.Name = "btnReadPDA"
        Me.btnReadPDA.Size = New System.Drawing.Size(134, 52)
        Me.btnReadPDA.TabIndex = 65
        Me.btnReadPDA.Text = "讀取PDA資料"
        Me.btnReadPDA.UseVisualStyleBackColor = True
        '
        'C_SyncOutByPDA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.btnReadPDA)
        Me.Controls.Add(Me.DelPDA)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.UpdQty)
        Me.Controls.Add(Me.ScanedDataGridView)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSync)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "C_SyncOutByPDA"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PDA出庫同步"
        CType(Me.ScanedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DelPDA As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UpdQty As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUndel As System.Windows.Forms.Button
    Friend WithEvents btnDel As System.Windows.Forms.Button
    Friend WithEvents ScanedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSync As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnReadPDA As System.Windows.Forms.Button
End Class
