<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 查詢生產訂單v001
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(查詢生產訂單v001))
        Me.DGV_Qordr = New System.Windows.Forms.DataGridView
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DGV_oDraft = New System.Windows.Forms.DataGridView
        Me.DGVDetail = New System.Windows.Forms.DataGridView
        Me.Label4 = New System.Windows.Forms.Label
        Me.UpdateBtn = New System.Windows.Forms.Button
        Me.DetailLbl = New System.Windows.Forms.Label
        Me.FinishedBtn = New System.Windows.Forms.Button
        Me.PopupNotifier1 = New PopupNotifier
        CType(Me.DGV_Qordr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_oDraft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Qordr
        '
        Me.DGV_Qordr.AllowUserToAddRows = False
        Me.DGV_Qordr.AllowUserToDeleteRows = False
        Me.DGV_Qordr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Qordr.Location = New System.Drawing.Point(14, 150)
        Me.DGV_Qordr.Name = "DGV_Qordr"
        Me.DGV_Qordr.ReadOnly = True
        Me.DGV_Qordr.RowHeadersVisible = False
        Me.DGV_Qordr.RowTemplate.Height = 24
        Me.DGV_Qordr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_Qordr.Size = New System.Drawing.Size(958, 198)
        Me.DGV_Qordr.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 682)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "自動化更新時間還有："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "草稿單："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "正式單："
        '
        'DGV_oDraft
        '
        Me.DGV_oDraft.AllowUserToAddRows = False
        Me.DGV_oDraft.AllowUserToDeleteRows = False
        Me.DGV_oDraft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_oDraft.Location = New System.Drawing.Point(12, 28)
        Me.DGV_oDraft.Name = "DGV_oDraft"
        Me.DGV_oDraft.ReadOnly = True
        Me.DGV_oDraft.RowHeadersVisible = False
        Me.DGV_oDraft.RowTemplate.Height = 24
        Me.DGV_oDraft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_oDraft.Size = New System.Drawing.Size(960, 100)
        Me.DGV_oDraft.TabIndex = 44
        '
        'DGVDetail
        '
        Me.DGVDetail.AllowUserToAddRows = False
        Me.DGVDetail.AllowUserToDeleteRows = False
        Me.DGVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDetail.Location = New System.Drawing.Point(12, 370)
        Me.DGVDetail.Name = "DGVDetail"
        Me.DGVDetail.ReadOnly = True
        Me.DGVDetail.RowHeadersVisible = False
        Me.DGVDetail.RowTemplate.Height = 24
        Me.DGVDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVDetail.Size = New System.Drawing.Size(960, 301)
        Me.DGVDetail.TabIndex = 45
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 351)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "明細："
        '
        'UpdateBtn
        '
        Me.UpdateBtn.Location = New System.Drawing.Point(192, 677)
        Me.UpdateBtn.Name = "UpdateBtn"
        Me.UpdateBtn.Size = New System.Drawing.Size(75, 23)
        Me.UpdateBtn.TabIndex = 47
        Me.UpdateBtn.Text = "手動更新"
        Me.UpdateBtn.UseVisualStyleBackColor = True
        '
        'DetailLbl
        '
        Me.DetailLbl.AutoSize = True
        Me.DetailLbl.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DetailLbl.Location = New System.Drawing.Point(72, 351)
        Me.DetailLbl.Name = "DetailLbl"
        Me.DetailLbl.Size = New System.Drawing.Size(0, 16)
        Me.DetailLbl.TabIndex = 48
        '
        'FinishedBtn
        '
        Me.FinishedBtn.Location = New System.Drawing.Point(897, 682)
        Me.FinishedBtn.Name = "FinishedBtn"
        Me.FinishedBtn.Size = New System.Drawing.Size(75, 23)
        Me.FinishedBtn.TabIndex = 49
        Me.FinishedBtn.Text = "已完成單"
        Me.FinishedBtn.UseVisualStyleBackColor = True
        '
        'PopupNotifier1
        '
        Me.PopupNotifier1.BodyColor = System.Drawing.Color.SteelBlue
        Me.PopupNotifier1.BorderColor = System.Drawing.Color.Navy
        Me.PopupNotifier1.ButtonHoverColor = System.Drawing.Color.Orange
        Me.PopupNotifier1.ContentColor = System.Drawing.Color.Red
        Me.PopupNotifier1.ContentFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupNotifier1.ContentText = ""
        Me.PopupNotifier1.GradientPower = 1000
        Me.PopupNotifier1.HeaderColor = System.Drawing.Color.Navy
        Me.PopupNotifier1.Image = CType(resources.GetObject("PopupNotifier1.Image"), System.Drawing.Image)
        Me.PopupNotifier1.ImagePosition = New System.Drawing.Point(12, 21)
        Me.PopupNotifier1.ImageSize = New System.Drawing.Size(48, 48)
        Me.PopupNotifier1.LinkHoverColor = System.Drawing.Color.Black
        Me.PopupNotifier1.OptionsMenu = Nothing
        Me.PopupNotifier1.ShowDelay = 1000
        Me.PopupNotifier1.Size = New System.Drawing.Size(400, 100)
        Me.PopupNotifier1.TextPadding = New System.Windows.Forms.Padding(5)
        Me.PopupNotifier1.TitleColor = System.Drawing.Color.White
        Me.PopupNotifier1.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupNotifier1.TitleText = ""
        '
        'B_QueryORDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 712)
        Me.Controls.Add(Me.FinishedBtn)
        Me.Controls.Add(Me.DetailLbl)
        Me.Controls.Add(Me.UpdateBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGVDetail)
        Me.Controls.Add(Me.DGV_oDraft)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_Qordr)
        Me.Name = "B_QueryORDR"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查詢生產訂單"
        CType(Me.DGV_Qordr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_oDraft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV_Qordr As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGV_oDraft As System.Windows.Forms.DataGridView
    Friend WithEvents DGVDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UpdateBtn As System.Windows.Forms.Button
    Friend WithEvents PopupNotifier1 As PopupNotifier
    Friend WithEvents DetailLbl As System.Windows.Forms.Label
    Friend WithEvents FinishedBtn As System.Windows.Forms.Button
End Class
