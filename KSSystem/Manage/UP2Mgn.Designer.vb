<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UP2Mgn
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.PBar1 = New System.Windows.Forms.ProgressBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.locView = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.DocEntry = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ItemCode = New System.Windows.Forms.TextBox
        Me.Dscription = New System.Windows.Forms.TextBox
        Me.U_p2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.LineNum = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        CType(Me.locView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(68, 424)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 96)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "*第一欄：單別" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "*第二欄：單號" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "*第三欄：列號碼" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "*第四欄：存編" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "第五欄：品名" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "*第六欄：公斤數"
        '
        'PBar1
        '
        Me.PBar1.Location = New System.Drawing.Point(12, 527)
        Me.PBar1.Name = "PBar1"
        Me.PBar1.Size = New System.Drawing.Size(760, 23)
        Me.PBar1.TabIndex = 36
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(574, 482)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 35)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "同步至資料庫"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'locView
        '
        Me.locView.AllowUserToAddRows = False
        Me.locView.AllowUserToDeleteRows = False
        Me.locView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locView.Location = New System.Drawing.Point(12, 12)
        Me.locView.Name = "locView"
        Me.locView.ReadOnly = True
        Me.locView.RowTemplate.Height = 24
        Me.locView.Size = New System.Drawing.Size(760, 178)
        Me.locView.TabIndex = 34
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(685, 482)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 35)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "讀取Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(734, 428)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 12)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(274, 424)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 80)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "單別請輸入：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "收貨採購單" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "收貨單" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "發貨單" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "交貨單"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(384, 440)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 64)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "銷售退回" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AR貸項" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "採購退貨" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "AP貸項"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(48, 355)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 23)
        Me.Button3.TabIndex = 42
        Me.Button3.Text = "查詢"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'DocEntry
        '
        Me.DocEntry.Location = New System.Drawing.Point(48, 327)
        Me.DocEntry.Name = "DocEntry"
        Me.DocEntry.Size = New System.Drawing.Size(100, 22)
        Me.DocEntry.TabIndex = 43
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 12)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "單號："
        '
        'ItemCode
        '
        Me.ItemCode.Enabled = False
        Me.ItemCode.Location = New System.Drawing.Point(76, 224)
        Me.ItemCode.Name = "ItemCode"
        Me.ItemCode.Size = New System.Drawing.Size(100, 22)
        Me.ItemCode.TabIndex = 45
        '
        'Dscription
        '
        Me.Dscription.Enabled = False
        Me.Dscription.Location = New System.Drawing.Point(182, 224)
        Me.Dscription.Name = "Dscription"
        Me.Dscription.Size = New System.Drawing.Size(238, 22)
        Me.Dscription.TabIndex = 46
        '
        'U_p2
        '
        Me.U_p2.Location = New System.Drawing.Point(426, 224)
        Me.U_p2.Name = "U_p2"
        Me.U_p2.Size = New System.Drawing.Size(85, 22)
        Me.U_p2.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 12)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "列號"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "存編"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(180, 209)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "品名"
        '
        'LineNum
        '
        Me.LineNum.Enabled = False
        Me.LineNum.Location = New System.Drawing.Point(32, 224)
        Me.LineNum.Name = "LineNum"
        Me.LineNum.Size = New System.Drawing.Size(38, 22)
        Me.LineNum.TabIndex = 52
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(427, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "重量"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(544, 224)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 54
        Me.Button4.Text = "更新"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'UP2Mgn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LineNum)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ItemCode)
        Me.Controls.Add(Me.U_p2)
        Me.Controls.Add(Me.Dscription)
        Me.Controls.Add(Me.DocEntry)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.locView)
        Me.Controls.Add(Me.Button1)
        Me.Name = "UP2Mgn"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "更新U_p2重量"
        CType(Me.locView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents locView As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DocEntry As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Dscription As System.Windows.Forms.TextBox
    Friend WithEvents U_p2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LineNum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
