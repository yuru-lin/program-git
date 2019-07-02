<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class v001驗收及領料及加工庫存查詢
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
        Me.TabControl2 = New System.Windows.Forms.TabControl
        Me.TabPage驗收明細 = New System.Windows.Forms.TabPage
        Me.P1DGV1 = New System.Windows.Forms.DataGridView
        Me.TabPage毛雞扣帳核對 = New System.Windows.Forms.TabPage
        Me.P2DGV2 = New System.Windows.Forms.DataGridView
        Me.驗收_日期1 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.驗收_日期2 = New System.Windows.Forms.DateTimePicker
        Me.驗收_查詢 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage驗收 = New System.Windows.Forms.TabPage
        Me.驗收_Excel = New System.Windows.Forms.Button
        Me.TabPage領料 = New System.Windows.Forms.TabPage
        Me.領料_日期1 = New System.Windows.Forms.DateTimePicker
        Me.TabControl3 = New System.Windows.Forms.TabControl
        Me.TabPage電宰 = New System.Windows.Forms.TabPage
        Me.P3DGV3 = New System.Windows.Forms.DataGridView
        Me.TabPage加工 = New System.Windows.Forms.TabPage
        Me.P4DGV4 = New System.Windows.Forms.DataGridView
        Me.領料_Excel = New System.Windows.Forms.Button
        Me.領料_查詢 = New System.Windows.Forms.Button
        Me.領料_製單 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.領料_日期2 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage加工庫存 = New System.Windows.Forms.TabPage
        Me.TabControl4 = New System.Windows.Forms.TabControl
        Me.TabPage統計 = New System.Windows.Forms.TabPage
        Me.P5DGV5 = New System.Windows.Forms.DataGridView
        Me.TabPage明細 = New System.Windows.Forms.TabPage
        Me.P6DGV6 = New System.Windows.Forms.DataGridView
        Me.加工庫存_Excel = New System.Windows.Forms.Button
        Me.加工庫存_查詢 = New System.Windows.Forms.Button
        Me.加工庫存_儲位 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.加工庫存_品名 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.加工庫存_存編 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabControl2.SuspendLayout()
        Me.TabPage驗收明細.SuspendLayout()
        CType(Me.P1DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage毛雞扣帳核對.SuspendLayout()
        CType(Me.P2DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage驗收.SuspendLayout()
        Me.TabPage領料.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage電宰.SuspendLayout()
        CType(Me.P3DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage加工.SuspendLayout()
        CType(Me.P4DGV4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage加工庫存.SuspendLayout()
        Me.TabControl4.SuspendLayout()
        Me.TabPage統計.SuspendLayout()
        CType(Me.P5DGV5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage明細.SuspendLayout()
        CType(Me.P6DGV6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage驗收明細)
        Me.TabControl2.Controls.Add(Me.TabPage毛雞扣帳核對)
        Me.TabControl2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl2.Location = New System.Drawing.Point(0, 50)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1212, 658)
        Me.TabControl2.TabIndex = 0
        Me.TabControl2.TabStop = False
        '
        'TabPage驗收明細
        '
        Me.TabPage驗收明細.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage驗收明細.Controls.Add(Me.P1DGV1)
        Me.TabPage驗收明細.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage驗收明細.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage驗收明細.Location = New System.Drawing.Point(4, 26)
        Me.TabPage驗收明細.Name = "TabPage驗收明細"
        Me.TabPage驗收明細.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage驗收明細.Size = New System.Drawing.Size(1204, 628)
        Me.TabPage驗收明細.TabIndex = 0
        Me.TabPage驗收明細.Text = "驗收明細"
        '
        'P1DGV1
        '
        Me.P1DGV1.AllowUserToAddRows = False
        Me.P1DGV1.AllowUserToDeleteRows = False
        Me.P1DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P1DGV1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P1DGV1.Location = New System.Drawing.Point(3, 3)
        Me.P1DGV1.Name = "P1DGV1"
        Me.P1DGV1.ReadOnly = True
        Me.P1DGV1.RowTemplate.Height = 24
        Me.P1DGV1.Size = New System.Drawing.Size(1198, 622)
        Me.P1DGV1.TabIndex = 0
        '
        'TabPage毛雞扣帳核對
        '
        Me.TabPage毛雞扣帳核對.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage毛雞扣帳核對.Controls.Add(Me.P2DGV2)
        Me.TabPage毛雞扣帳核對.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage毛雞扣帳核對.Location = New System.Drawing.Point(4, 26)
        Me.TabPage毛雞扣帳核對.Name = "TabPage毛雞扣帳核對"
        Me.TabPage毛雞扣帳核對.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage毛雞扣帳核對.Size = New System.Drawing.Size(1204, 628)
        Me.TabPage毛雞扣帳核對.TabIndex = 1
        Me.TabPage毛雞扣帳核對.Text = "毛雞扣帳核對"
        '
        'P2DGV2
        '
        Me.P2DGV2.AllowUserToAddRows = False
        Me.P2DGV2.AllowUserToDeleteRows = False
        Me.P2DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P2DGV2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P2DGV2.Location = New System.Drawing.Point(3, 3)
        Me.P2DGV2.Name = "P2DGV2"
        Me.P2DGV2.ReadOnly = True
        Me.P2DGV2.RowTemplate.Height = 24
        Me.P2DGV2.Size = New System.Drawing.Size(1198, 622)
        Me.P2DGV2.TabIndex = 0
        '
        '驗收_日期1
        '
        Me.驗收_日期1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.驗收_日期1.Location = New System.Drawing.Point(82, 11)
        Me.驗收_日期1.Name = "驗收_日期1"
        Me.驗收_日期1.Size = New System.Drawing.Size(170, 27)
        Me.驗收_日期1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "日期："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(258, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "至"
        '
        '驗收_日期2
        '
        Me.驗收_日期2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.驗收_日期2.Location = New System.Drawing.Point(295, 11)
        Me.驗收_日期2.Name = "驗收_日期2"
        Me.驗收_日期2.Size = New System.Drawing.Size(170, 27)
        Me.驗收_日期2.TabIndex = 4
        '
        '驗收_查詢
        '
        Me.驗收_查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.驗收_查詢.Location = New System.Drawing.Point(522, 7)
        Me.驗收_查詢.Name = "驗收_查詢"
        Me.驗收_查詢.Size = New System.Drawing.Size(82, 41)
        Me.驗收_查詢.TabIndex = 5
        Me.驗收_查詢.Text = "查詢"
        Me.驗收_查詢.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage驗收)
        Me.TabControl1.Controls.Add(Me.TabPage領料)
        Me.TabControl1.Controls.Add(Me.TabPage加工庫存)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-1, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1216, 737)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage驗收
        '
        Me.TabPage驗收.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage驗收.Controls.Add(Me.驗收_Excel)
        Me.TabPage驗收.Controls.Add(Me.Label1)
        Me.TabPage驗收.Controls.Add(Me.TabControl2)
        Me.TabPage驗收.Controls.Add(Me.驗收_查詢)
        Me.TabPage驗收.Controls.Add(Me.驗收_日期1)
        Me.TabPage驗收.Controls.Add(Me.驗收_日期2)
        Me.TabPage驗收.Controls.Add(Me.Label2)
        Me.TabPage驗收.Location = New System.Drawing.Point(4, 29)
        Me.TabPage驗收.Name = "TabPage驗收"
        Me.TabPage驗收.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage驗收.Size = New System.Drawing.Size(1208, 704)
        Me.TabPage驗收.TabIndex = 0
        Me.TabPage驗收.Text = "驗收"
        '
        '驗收_Excel
        '
        Me.驗收_Excel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.驗收_Excel.Location = New System.Drawing.Point(1091, 7)
        Me.驗收_Excel.Name = "驗收_Excel"
        Me.驗收_Excel.Size = New System.Drawing.Size(82, 41)
        Me.驗收_Excel.TabIndex = 6
        Me.驗收_Excel.Text = "Excel"
        Me.驗收_Excel.UseVisualStyleBackColor = True
        '
        'TabPage領料
        '
        Me.TabPage領料.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage領料.Controls.Add(Me.領料_日期1)
        Me.TabPage領料.Controls.Add(Me.TabControl3)
        Me.TabPage領料.Controls.Add(Me.領料_Excel)
        Me.TabPage領料.Controls.Add(Me.領料_查詢)
        Me.TabPage領料.Controls.Add(Me.領料_製單)
        Me.TabPage領料.Controls.Add(Me.Label5)
        Me.TabPage領料.Controls.Add(Me.Label3)
        Me.TabPage領料.Controls.Add(Me.領料_日期2)
        Me.TabPage領料.Controls.Add(Me.Label4)
        Me.TabPage領料.Location = New System.Drawing.Point(4, 29)
        Me.TabPage領料.Name = "TabPage領料"
        Me.TabPage領料.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage領料.Size = New System.Drawing.Size(1208, 704)
        Me.TabPage領料.TabIndex = 1
        Me.TabPage領料.Text = "領料"
        '
        '領料_日期1
        '
        Me.領料_日期1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.領料_日期1.Location = New System.Drawing.Point(82, 11)
        Me.領料_日期1.Name = "領料_日期1"
        Me.領料_日期1.Size = New System.Drawing.Size(170, 27)
        Me.領料_日期1.TabIndex = 13
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage電宰)
        Me.TabControl3.Controls.Add(Me.TabPage加工)
        Me.TabControl3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl3.Location = New System.Drawing.Point(0, 50)
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(1212, 658)
        Me.TabControl3.TabIndex = 12
        '
        'TabPage電宰
        '
        Me.TabPage電宰.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage電宰.Controls.Add(Me.P3DGV3)
        Me.TabPage電宰.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage電宰.Location = New System.Drawing.Point(4, 26)
        Me.TabPage電宰.Name = "TabPage電宰"
        Me.TabPage電宰.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage電宰.Size = New System.Drawing.Size(1204, 628)
        Me.TabPage電宰.TabIndex = 0
        Me.TabPage電宰.Text = "電宰_明細"
        '
        'P3DGV3
        '
        Me.P3DGV3.AllowUserToAddRows = False
        Me.P3DGV3.AllowUserToDeleteRows = False
        Me.P3DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P3DGV3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P3DGV3.Location = New System.Drawing.Point(3, 3)
        Me.P3DGV3.Name = "P3DGV3"
        Me.P3DGV3.ReadOnly = True
        Me.P3DGV3.RowTemplate.Height = 24
        Me.P3DGV3.Size = New System.Drawing.Size(1198, 622)
        Me.P3DGV3.TabIndex = 1
        '
        'TabPage加工
        '
        Me.TabPage加工.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage加工.Controls.Add(Me.P4DGV4)
        Me.TabPage加工.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage加工.Location = New System.Drawing.Point(4, 26)
        Me.TabPage加工.Name = "TabPage加工"
        Me.TabPage加工.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage加工.Size = New System.Drawing.Size(1204, 628)
        Me.TabPage加工.TabIndex = 1
        Me.TabPage加工.Text = "加工_明細"
        '
        'P4DGV4
        '
        Me.P4DGV4.AllowUserToAddRows = False
        Me.P4DGV4.AllowUserToDeleteRows = False
        Me.P4DGV4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P4DGV4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P4DGV4.Location = New System.Drawing.Point(3, 3)
        Me.P4DGV4.Name = "P4DGV4"
        Me.P4DGV4.ReadOnly = True
        Me.P4DGV4.RowTemplate.Height = 24
        Me.P4DGV4.Size = New System.Drawing.Size(1198, 622)
        Me.P4DGV4.TabIndex = 1
        '
        '領料_Excel
        '
        Me.領料_Excel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.領料_Excel.Location = New System.Drawing.Point(1091, 7)
        Me.領料_Excel.Name = "領料_Excel"
        Me.領料_Excel.Size = New System.Drawing.Size(82, 41)
        Me.領料_Excel.TabIndex = 11
        Me.領料_Excel.Text = "Excel"
        Me.領料_Excel.UseVisualStyleBackColor = True
        '
        '領料_查詢
        '
        Me.領料_查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.領料_查詢.Location = New System.Drawing.Point(771, 7)
        Me.領料_查詢.Name = "領料_查詢"
        Me.領料_查詢.Size = New System.Drawing.Size(82, 41)
        Me.領料_查詢.TabIndex = 10
        Me.領料_查詢.Text = "查詢"
        Me.領料_查詢.UseVisualStyleBackColor = True
        '
        '領料_製單
        '
        Me.領料_製單.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.領料_製單.Location = New System.Drawing.Point(571, 10)
        Me.領料_製單.Name = "領料_製單"
        Me.領料_製單.Size = New System.Drawing.Size(125, 30)
        Me.領料_製單.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(497, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 21)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "製單："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "日期："
        '
        '領料_日期2
        '
        Me.領料_日期2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.領料_日期2.Location = New System.Drawing.Point(295, 11)
        Me.領料_日期2.Name = "領料_日期2"
        Me.領料_日期2.Size = New System.Drawing.Size(170, 27)
        Me.領料_日期2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(258, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 21)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "至"
        '
        'TabPage加工庫存
        '
        Me.TabPage加工庫存.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage加工庫存.Controls.Add(Me.TabControl4)
        Me.TabPage加工庫存.Controls.Add(Me.加工庫存_Excel)
        Me.TabPage加工庫存.Controls.Add(Me.加工庫存_查詢)
        Me.TabPage加工庫存.Controls.Add(Me.加工庫存_儲位)
        Me.TabPage加工庫存.Controls.Add(Me.Label8)
        Me.TabPage加工庫存.Controls.Add(Me.加工庫存_品名)
        Me.TabPage加工庫存.Controls.Add(Me.Label7)
        Me.TabPage加工庫存.Controls.Add(Me.加工庫存_存編)
        Me.TabPage加工庫存.Controls.Add(Me.Label6)
        Me.TabPage加工庫存.Location = New System.Drawing.Point(4, 29)
        Me.TabPage加工庫存.Name = "TabPage加工庫存"
        Me.TabPage加工庫存.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage加工庫存.Size = New System.Drawing.Size(1208, 704)
        Me.TabPage加工庫存.TabIndex = 2
        Me.TabPage加工庫存.Text = "加工庫存"
        '
        'TabControl4
        '
        Me.TabControl4.Controls.Add(Me.TabPage統計)
        Me.TabControl4.Controls.Add(Me.TabPage明細)
        Me.TabControl4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl4.Location = New System.Drawing.Point(0, 50)
        Me.TabControl4.Name = "TabControl4"
        Me.TabControl4.SelectedIndex = 0
        Me.TabControl4.Size = New System.Drawing.Size(1212, 658)
        Me.TabControl4.TabIndex = 17
        '
        'TabPage統計
        '
        Me.TabPage統計.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage統計.Controls.Add(Me.P5DGV5)
        Me.TabPage統計.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage統計.Location = New System.Drawing.Point(4, 26)
        Me.TabPage統計.Name = "TabPage統計"
        Me.TabPage統計.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage統計.Size = New System.Drawing.Size(1204, 628)
        Me.TabPage統計.TabIndex = 0
        Me.TabPage統計.Text = "統計"
        '
        'P5DGV5
        '
        Me.P5DGV5.AllowUserToAddRows = False
        Me.P5DGV5.AllowUserToDeleteRows = False
        Me.P5DGV5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P5DGV5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P5DGV5.Location = New System.Drawing.Point(3, 3)
        Me.P5DGV5.Name = "P5DGV5"
        Me.P5DGV5.ReadOnly = True
        Me.P5DGV5.RowTemplate.Height = 24
        Me.P5DGV5.Size = New System.Drawing.Size(1198, 622)
        Me.P5DGV5.TabIndex = 3
        '
        'TabPage明細
        '
        Me.TabPage明細.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage明細.Controls.Add(Me.P6DGV6)
        Me.TabPage明細.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabPage明細.Location = New System.Drawing.Point(4, 26)
        Me.TabPage明細.Name = "TabPage明細"
        Me.TabPage明細.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage明細.Size = New System.Drawing.Size(1204, 628)
        Me.TabPage明細.TabIndex = 1
        Me.TabPage明細.Text = "明細"
        '
        'P6DGV6
        '
        Me.P6DGV6.AllowUserToAddRows = False
        Me.P6DGV6.AllowUserToDeleteRows = False
        Me.P6DGV6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.P6DGV6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.P6DGV6.Location = New System.Drawing.Point(3, 3)
        Me.P6DGV6.Name = "P6DGV6"
        Me.P6DGV6.ReadOnly = True
        Me.P6DGV6.RowTemplate.Height = 24
        Me.P6DGV6.Size = New System.Drawing.Size(1198, 622)
        Me.P6DGV6.TabIndex = 2
        '
        '加工庫存_Excel
        '
        Me.加工庫存_Excel.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.加工庫存_Excel.Location = New System.Drawing.Point(1091, 7)
        Me.加工庫存_Excel.Name = "加工庫存_Excel"
        Me.加工庫存_Excel.Size = New System.Drawing.Size(82, 41)
        Me.加工庫存_Excel.TabIndex = 16
        Me.加工庫存_Excel.Text = "Excel"
        Me.加工庫存_Excel.UseVisualStyleBackColor = True
        '
        '加工庫存_查詢
        '
        Me.加工庫存_查詢.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.加工庫存_查詢.Location = New System.Drawing.Point(857, 7)
        Me.加工庫存_查詢.Name = "加工庫存_查詢"
        Me.加工庫存_查詢.Size = New System.Drawing.Size(82, 41)
        Me.加工庫存_查詢.TabIndex = 15
        Me.加工庫存_查詢.Text = "查詢"
        Me.加工庫存_查詢.UseVisualStyleBackColor = True
        '
        '加工庫存_儲位
        '
        Me.加工庫存_儲位.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.加工庫存_儲位.Location = New System.Drawing.Point(672, 10)
        Me.加工庫存_儲位.Name = "加工庫存_儲位"
        Me.加工庫存_儲位.Size = New System.Drawing.Size(112, 30)
        Me.加工庫存_儲位.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(598, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 21)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "儲位："
        '
        '加工庫存_品名
        '
        Me.加工庫存_品名.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.加工庫存_品名.Location = New System.Drawing.Point(377, 10)
        Me.加工庫存_品名.Name = "加工庫存_品名"
        Me.加工庫存_品名.Size = New System.Drawing.Size(188, 30)
        Me.加工庫存_品名.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(303, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 21)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "品名："
        '
        '加工庫存_存編
        '
        Me.加工庫存_存編.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.加工庫存_存編.Location = New System.Drawing.Point(82, 10)
        Me.加工庫存_存編.Name = "加工庫存_存編"
        Me.加工庫存_存編.Size = New System.Drawing.Size(188, 30)
        Me.加工庫存_存編.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 21)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "存編："
        '
        'v001驗收及領料及加工庫存查詢
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 734)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "v001驗收及領料及加工庫存查詢"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "驗收/領料/加工庫存查詢"
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage驗收明細.ResumeLayout(False)
        CType(Me.P1DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage毛雞扣帳核對.ResumeLayout(False)
        CType(Me.P2DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage驗收.ResumeLayout(False)
        Me.TabPage驗收.PerformLayout()
        Me.TabPage領料.ResumeLayout(False)
        Me.TabPage領料.PerformLayout()
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage電宰.ResumeLayout(False)
        CType(Me.P3DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage加工.ResumeLayout(False)
        CType(Me.P4DGV4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage加工庫存.ResumeLayout(False)
        Me.TabPage加工庫存.PerformLayout()
        Me.TabControl4.ResumeLayout(False)
        Me.TabPage統計.ResumeLayout(False)
        CType(Me.P5DGV5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage明細.ResumeLayout(False)
        CType(Me.P6DGV6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage驗收明細 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage毛雞扣帳核對 As System.Windows.Forms.TabPage
    Friend WithEvents 驗收_日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 驗收_日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 驗收_查詢 As System.Windows.Forms.Button
    Friend WithEvents P1DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents P2DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage驗收 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage領料 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage加工庫存 As System.Windows.Forms.TabPage
    Friend WithEvents 驗收_Excel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 領料_日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 領料_製單 As System.Windows.Forms.TextBox
    Friend WithEvents 領料_查詢 As System.Windows.Forms.Button
    Friend WithEvents 領料_Excel As System.Windows.Forms.Button
    Friend WithEvents TabControl3 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage電宰 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage加工 As System.Windows.Forms.TabPage
    Friend WithEvents P3DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents P4DGV4 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents 加工庫存_存編 As System.Windows.Forms.TextBox
    Friend WithEvents 加工庫存_品名 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents 加工庫存_儲位 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents 加工庫存_查詢 As System.Windows.Forms.Button
    Friend WithEvents 加工庫存_Excel As System.Windows.Forms.Button
    Friend WithEvents TabControl4 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage統計 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage明細 As System.Windows.Forms.TabPage
    Friend WithEvents P5DGV5 As System.Windows.Forms.DataGridView
    Friend WithEvents P6DGV6 As System.Windows.Forms.DataGridView
    Friend WithEvents 領料_日期1 As System.Windows.Forms.DateTimePicker
End Class
