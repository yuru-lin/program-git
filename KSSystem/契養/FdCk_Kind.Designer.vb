<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FdCk_Kind
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
        Me.FdCkReturnQty = New System.Windows.Forms.DataGridView
        Me.FdCkSumForm = New System.Windows.Forms.DataGridView
        Me.CloseFormBtn = New System.Windows.Forms.Button
        Me.querykind_btn = New System.Windows.Forms.Button
        Me.updateKind_Btn = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.FD23 = New System.Windows.Forms.TextBox
        Me.FdCkKindGridView = New System.Windows.Forms.DataGridView
        CType(Me.FdCkReturnQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FdCkSumForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FdCkKindGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FdCkReturnQty
        '
        Me.FdCkReturnQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FdCkReturnQty.Location = New System.Drawing.Point(12, 435)
        Me.FdCkReturnQty.Name = "FdCkReturnQty"
        Me.FdCkReturnQty.RowTemplate.Height = 24
        Me.FdCkReturnQty.Size = New System.Drawing.Size(975, 166)
        Me.FdCkReturnQty.TabIndex = 92
        '
        'FdCkSumForm
        '
        Me.FdCkSumForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FdCkSumForm.Location = New System.Drawing.Point(12, 229)
        Me.FdCkSumForm.Name = "FdCkSumForm"
        Me.FdCkSumForm.RowTemplate.Height = 24
        Me.FdCkSumForm.Size = New System.Drawing.Size(975, 190)
        Me.FdCkSumForm.TabIndex = 91
        '
        'CloseFormBtn
        '
        Me.CloseFormBtn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CloseFormBtn.Location = New System.Drawing.Point(12, 665)
        Me.CloseFormBtn.Name = "CloseFormBtn"
        Me.CloseFormBtn.Size = New System.Drawing.Size(100, 40)
        Me.CloseFormBtn.TabIndex = 89
        Me.CloseFormBtn.Text = "關閉視窗"
        Me.CloseFormBtn.UseVisualStyleBackColor = True
        '
        'querykind_btn
        '
        Me.querykind_btn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.querykind_btn.Location = New System.Drawing.Point(118, 665)
        Me.querykind_btn.Name = "querykind_btn"
        Me.querykind_btn.Size = New System.Drawing.Size(100, 40)
        Me.querykind_btn.TabIndex = 88
        Me.querykind_btn.Text = "資料重整"
        Me.querykind_btn.UseVisualStyleBackColor = True
        '
        'updateKind_Btn
        '
        Me.updateKind_Btn.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.updateKind_Btn.Location = New System.Drawing.Point(12, 619)
        Me.updateKind_Btn.Name = "updateKind_Btn"
        Me.updateKind_Btn.Size = New System.Drawing.Size(100, 40)
        Me.updateKind_Btn.TabIndex = 86
        Me.updateKind_Btn.Text = "修改儲存"
        Me.updateKind_Btn.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(239, 619)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 16)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "*契養批號 :"
        '
        'FD23
        '
        Me.FD23.Location = New System.Drawing.Point(340, 613)
        Me.FD23.Name = "FD23"
        Me.FD23.Size = New System.Drawing.Size(237, 22)
        Me.FD23.TabIndex = 83
        '
        'FdCkKindGridView
        '
        Me.FdCkKindGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.FdCkKindGridView.Location = New System.Drawing.Point(12, 8)
        Me.FdCkKindGridView.Name = "FdCkKindGridView"
        Me.FdCkKindGridView.RowTemplate.Height = 24
        Me.FdCkKindGridView.Size = New System.Drawing.Size(975, 201)
        Me.FdCkKindGridView.TabIndex = 80
        '
        'FdCk_Kind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 719)
        Me.Controls.Add(Me.FdCkReturnQty)
        Me.Controls.Add(Me.FdCkSumForm)
        Me.Controls.Add(Me.CloseFormBtn)
        Me.Controls.Add(Me.querykind_btn)
        Me.Controls.Add(Me.updateKind_Btn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FD23)
        Me.Controls.Add(Me.FdCkKindGridView)
        Me.Name = "FdCk_Kind"
        Me.Text = "FdCk_Kind"
        CType(Me.FdCkReturnQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FdCkSumForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FdCkKindGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FdCkReturnQty As System.Windows.Forms.DataGridView
    Friend WithEvents FdCkSumForm As System.Windows.Forms.DataGridView
    Friend WithEvents CloseFormBtn As System.Windows.Forms.Button
    Friend WithEvents querykind_btn As System.Windows.Forms.Button
    Friend WithEvents updateKind_Btn As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FD23 As System.Windows.Forms.TextBox
    Friend WithEvents FdCkKindGridView As System.Windows.Forms.DataGridView
End Class
