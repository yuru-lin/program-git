<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 生產入庫V103
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
        Me.Bu查詢 = New System.Windows.Forms.Button
        Me.Rb加工 = New System.Windows.Forms.RadioButton
        Me.Rb電宰 = New System.Windows.Forms.RadioButton
        Me.製單單號 = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.製單單號, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Bu查詢)
        Me.Panel1.Controls.Add(Me.Rb加工)
        Me.Panel1.Controls.Add(Me.Rb電宰)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(217, 35)
        Me.Panel1.TabIndex = 169
        '
        'Bu查詢
        '
        Me.Bu查詢.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu查詢.Location = New System.Drawing.Point(136, 1)
        Me.Bu查詢.Name = "Bu查詢"
        Me.Bu查詢.Size = New System.Drawing.Size(75, 30)
        Me.Bu查詢.TabIndex = 4
        Me.Bu查詢.Text = "查詢"
        Me.Bu查詢.UseVisualStyleBackColor = True
        '
        'Rb加工
        '
        Me.Rb加工.AutoSize = True
        Me.Rb加工.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Rb加工.Location = New System.Drawing.Point(72, 6)
        Me.Rb加工.Name = "Rb加工"
        Me.Rb加工.Size = New System.Drawing.Size(58, 20)
        Me.Rb加工.TabIndex = 1
        Me.Rb加工.Text = "加工"
        Me.Rb加工.UseVisualStyleBackColor = True
        '
        'Rb電宰
        '
        Me.Rb電宰.AutoSize = True
        Me.Rb電宰.Checked = True
        Me.Rb電宰.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Rb電宰.Location = New System.Drawing.Point(6, 6)
        Me.Rb電宰.Name = "Rb電宰"
        Me.Rb電宰.Size = New System.Drawing.Size(58, 20)
        Me.Rb電宰.TabIndex = 0
        Me.Rb電宰.TabStop = True
        Me.Rb電宰.Text = "電宰"
        Me.Rb電宰.UseVisualStyleBackColor = True
        '
        '製單單號
        '
        Me.製單單號.AllowUserToAddRows = False
        Me.製單單號.AllowUserToDeleteRows = False
        Me.製單單號.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.製單單號.Location = New System.Drawing.Point(3, 61)
        Me.製單單號.MultiSelect = False
        Me.製單單號.Name = "製單單號"
        Me.製單單號.ReadOnly = True
        Me.製單單號.RowHeadersWidth = 20
        Me.製單單號.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.製單單號.RowTemplate.Height = 24
        Me.製單單號.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.製單單號.Size = New System.Drawing.Size(146, 429)
        Me.製單單號.TabIndex = 170
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "製單"
        '
        '生產入庫V103
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1334, 637)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.製單單號)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "生產入庫V103"
        Me.Text = "生產入庫-現場比對入庫"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.製單單號, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Bu查詢 As System.Windows.Forms.Button
    Friend WithEvents Rb加工 As System.Windows.Forms.RadioButton
    Friend WithEvents Rb電宰 As System.Windows.Forms.RadioButton
    Friend WithEvents 製單單號 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
