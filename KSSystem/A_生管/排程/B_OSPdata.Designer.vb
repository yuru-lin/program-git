<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_OSPdata
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
        Me.SidT0 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.AliasName_0 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.DelBut_0 = New System.Windows.Forms.Button
        Me.UpdateBut_0 = New System.Windows.Forms.Button
        Me.MdyBut_0 = New System.Windows.Forms.Button
        Me.AddBut_0 = New System.Windows.Forms.Button
        Me.CardName_0 = New System.Windows.Forms.TextBox
        Me.CardCode_0 = New System.Windows.Forms.TextBox
        Me.Order_0 = New System.Windows.Forms.TextBox
        Me.LineNum_0 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DelBut_1 = New System.Windows.Forms.Button
        Me.UpdateBut_1 = New System.Windows.Forms.Button
        Me.MdyBut_1 = New System.Windows.Forms.Button
        Me.AddBut_1 = New System.Windows.Forms.Button
        Me.CategoryName_1 = New System.Windows.Forms.TextBox
        Me.Order_1 = New System.Windows.Forms.TextBox
        Me.LineNum_1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.DGV2 = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Remarks_2 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Plate_H_2 = New System.Windows.Forms.TextBox
        Me.Weight_2 = New System.Windows.Forms.TextBox
        Me.CategoryName_2 = New System.Windows.Forms.ComboBox
        Me.DGV3 = New System.Windows.Forms.DataGridView
        Me.DelBut_2 = New System.Windows.Forms.Button
        Me.UpdateBut_2 = New System.Windows.Forms.Button
        Me.MdyBut_2 = New System.Windows.Forms.Button
        Me.AddBut_2 = New System.Windows.Forms.Button
        Me.ItemCode_2 = New System.Windows.Forms.TextBox
        Me.ItemName_2 = New System.Windows.Forms.TextBox
        Me.Order_2 = New System.Windows.Forms.TextBox
        Me.LineNum_2 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Floor = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Search = New System.Windows.Forms.Button
        Me.AgainSearch = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(3, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(615, 553)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.SidT0)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.AliasName_0)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.DelBut_0)
        Me.TabPage1.Controls.Add(Me.UpdateBut_0)
        Me.TabPage1.Controls.Add(Me.MdyBut_0)
        Me.TabPage1.Controls.Add(Me.AddBut_0)
        Me.TabPage1.Controls.Add(Me.CardName_0)
        Me.TabPage1.Controls.Add(Me.CardCode_0)
        Me.TabPage1.Controls.Add(Me.Order_0)
        Me.TabPage1.Controls.Add(Me.LineNum_0)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.DGV1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(607, 527)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "客戶"
        '
        'SidT0
        '
        Me.SidT0.AutoSize = True
        Me.SidT0.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.SidT0.Location = New System.Drawing.Point(55, 504)
        Me.SidT0.Name = "SidT0"
        Me.SidT0.Size = New System.Drawing.Size(28, 16)
        Me.SidT0.TabIndex = 20
        Me.SidT0.Text = "Sid"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 504)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 16)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "列號："
        '
        'AliasName_0
        '
        Me.AliasName_0.BackColor = System.Drawing.Color.White
        Me.AliasName_0.Location = New System.Drawing.Point(58, 119)
        Me.AliasName_0.Name = "AliasName_0"
        Me.AliasName_0.Size = New System.Drawing.Size(100, 22)
        Me.AliasName_0.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(3, 119)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 16)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "別名："
        '
        'DelBut_0
        '
        Me.DelBut_0.Location = New System.Drawing.Point(87, 300)
        Me.DelBut_0.Name = "DelBut_0"
        Me.DelBut_0.Size = New System.Drawing.Size(75, 23)
        Me.DelBut_0.TabIndex = 16
        Me.DelBut_0.Text = "刪除"
        Me.DelBut_0.UseVisualStyleBackColor = True
        '
        'UpdateBut_0
        '
        Me.UpdateBut_0.Location = New System.Drawing.Point(87, 329)
        Me.UpdateBut_0.Name = "UpdateBut_0"
        Me.UpdateBut_0.Size = New System.Drawing.Size(75, 23)
        Me.UpdateBut_0.TabIndex = 15
        Me.UpdateBut_0.Text = "更新"
        Me.UpdateBut_0.UseVisualStyleBackColor = True
        '
        'MdyBut_0
        '
        Me.MdyBut_0.Location = New System.Drawing.Point(6, 329)
        Me.MdyBut_0.Name = "MdyBut_0"
        Me.MdyBut_0.Size = New System.Drawing.Size(75, 23)
        Me.MdyBut_0.TabIndex = 14
        Me.MdyBut_0.Text = "修改"
        Me.MdyBut_0.UseVisualStyleBackColor = True
        '
        'AddBut_0
        '
        Me.AddBut_0.Location = New System.Drawing.Point(6, 300)
        Me.AddBut_0.Name = "AddBut_0"
        Me.AddBut_0.Size = New System.Drawing.Size(75, 23)
        Me.AddBut_0.TabIndex = 13
        Me.AddBut_0.Text = "新增"
        Me.AddBut_0.UseVisualStyleBackColor = True
        '
        'CardName_0
        '
        Me.CardName_0.BackColor = System.Drawing.Color.White
        Me.CardName_0.Location = New System.Drawing.Point(58, 90)
        Me.CardName_0.Name = "CardName_0"
        Me.CardName_0.Size = New System.Drawing.Size(100, 22)
        Me.CardName_0.TabIndex = 11
        '
        'CardCode_0
        '
        Me.CardCode_0.BackColor = System.Drawing.Color.White
        Me.CardCode_0.Location = New System.Drawing.Point(58, 62)
        Me.CardCode_0.Name = "CardCode_0"
        Me.CardCode_0.Size = New System.Drawing.Size(100, 22)
        Me.CardCode_0.TabIndex = 10
        '
        'Order_0
        '
        Me.Order_0.BackColor = System.Drawing.Color.White
        Me.Order_0.Location = New System.Drawing.Point(58, 34)
        Me.Order_0.Name = "Order_0"
        Me.Order_0.Size = New System.Drawing.Size(100, 22)
        Me.Order_0.TabIndex = 9
        '
        'LineNum_0
        '
        Me.LineNum_0.Enabled = False
        Me.LineNum_0.Location = New System.Drawing.Point(58, 6)
        Me.LineNum_0.Name = "LineNum_0"
        Me.LineNum_0.Size = New System.Drawing.Size(100, 22)
        Me.LineNum_0.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(3, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "客戶："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "客編："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(3, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "順序："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "列號："
        '
        'DGV1
        '
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(166, 6)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.RowHeadersWidth = 25
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.Size = New System.Drawing.Size(434, 514)
        Me.DGV1.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.DelBut_1)
        Me.TabPage2.Controls.Add(Me.UpdateBut_1)
        Me.TabPage2.Controls.Add(Me.MdyBut_1)
        Me.TabPage2.Controls.Add(Me.AddBut_1)
        Me.TabPage2.Controls.Add(Me.CategoryName_1)
        Me.TabPage2.Controls.Add(Me.Order_1)
        Me.TabPage2.Controls.Add(Me.LineNum_1)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.DGV2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(607, 527)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "類別"
        '
        'DelBut_1
        '
        Me.DelBut_1.Location = New System.Drawing.Point(87, 300)
        Me.DelBut_1.Name = "DelBut_1"
        Me.DelBut_1.Size = New System.Drawing.Size(75, 23)
        Me.DelBut_1.TabIndex = 24
        Me.DelBut_1.Text = "刪除"
        Me.DelBut_1.UseVisualStyleBackColor = True
        '
        'UpdateBut_1
        '
        Me.UpdateBut_1.Location = New System.Drawing.Point(87, 329)
        Me.UpdateBut_1.Name = "UpdateBut_1"
        Me.UpdateBut_1.Size = New System.Drawing.Size(75, 23)
        Me.UpdateBut_1.TabIndex = 23
        Me.UpdateBut_1.Text = "更新"
        Me.UpdateBut_1.UseVisualStyleBackColor = True
        '
        'MdyBut_1
        '
        Me.MdyBut_1.Location = New System.Drawing.Point(6, 329)
        Me.MdyBut_1.Name = "MdyBut_1"
        Me.MdyBut_1.Size = New System.Drawing.Size(75, 23)
        Me.MdyBut_1.TabIndex = 22
        Me.MdyBut_1.Text = "修改"
        Me.MdyBut_1.UseVisualStyleBackColor = True
        '
        'AddBut_1
        '
        Me.AddBut_1.Location = New System.Drawing.Point(6, 300)
        Me.AddBut_1.Name = "AddBut_1"
        Me.AddBut_1.Size = New System.Drawing.Size(75, 23)
        Me.AddBut_1.TabIndex = 21
        Me.AddBut_1.Text = "新增"
        Me.AddBut_1.UseVisualStyleBackColor = True
        '
        'CategoryName_1
        '
        Me.CategoryName_1.Location = New System.Drawing.Point(58, 62)
        Me.CategoryName_1.Name = "CategoryName_1"
        Me.CategoryName_1.Size = New System.Drawing.Size(100, 22)
        Me.CategoryName_1.TabIndex = 20
        '
        'Order_1
        '
        Me.Order_1.Location = New System.Drawing.Point(58, 34)
        Me.Order_1.Name = "Order_1"
        Me.Order_1.Size = New System.Drawing.Size(100, 22)
        Me.Order_1.TabIndex = 19
        '
        'LineNum_1
        '
        Me.LineNum_1.Enabled = False
        Me.LineNum_1.Location = New System.Drawing.Point(58, 6)
        Me.LineNum_1.Name = "LineNum_1"
        Me.LineNum_1.Size = New System.Drawing.Size(100, 22)
        Me.LineNum_1.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(3, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "類別："
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(3, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "順序："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "列號："
        '
        'DGV2
        '
        Me.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV2.Location = New System.Drawing.Point(166, 6)
        Me.DGV2.Name = "DGV2"
        Me.DGV2.RowHeadersWidth = 25
        Me.DGV2.RowTemplate.Height = 24
        Me.DGV2.Size = New System.Drawing.Size(434, 514)
        Me.DGV2.TabIndex = 2
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Remarks_2)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Plate_H_2)
        Me.TabPage3.Controls.Add(Me.Weight_2)
        Me.TabPage3.Controls.Add(Me.CategoryName_2)
        Me.TabPage3.Controls.Add(Me.DGV3)
        Me.TabPage3.Controls.Add(Me.DelBut_2)
        Me.TabPage3.Controls.Add(Me.UpdateBut_2)
        Me.TabPage3.Controls.Add(Me.MdyBut_2)
        Me.TabPage3.Controls.Add(Me.AddBut_2)
        Me.TabPage3.Controls.Add(Me.ItemCode_2)
        Me.TabPage3.Controls.Add(Me.ItemName_2)
        Me.TabPage3.Controls.Add(Me.Order_2)
        Me.TabPage3.Controls.Add(Me.LineNum_2)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(607, 527)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "品項"
        '
        'Remarks_2
        '
        Me.Remarks_2.AcceptsTab = True
        Me.Remarks_2.BackColor = System.Drawing.Color.White
        Me.Remarks_2.Location = New System.Drawing.Point(6, 221)
        Me.Remarks_2.Multiline = True
        Me.Remarks_2.Name = "Remarks_2"
        Me.Remarks_2.Size = New System.Drawing.Size(152, 240)
        Me.Remarks_2.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(3, 202)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 16)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "備註："
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(3, 174)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "重量："
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(3, 146)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "工時："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Red
        Me.Label13.Location = New System.Drawing.Point(3, 118)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "品名："
        '
        'Plate_H_2
        '
        Me.Plate_H_2.BackColor = System.Drawing.Color.White
        Me.Plate_H_2.Location = New System.Drawing.Point(58, 146)
        Me.Plate_H_2.Name = "Plate_H_2"
        Me.Plate_H_2.Size = New System.Drawing.Size(100, 22)
        Me.Plate_H_2.TabIndex = 32
        '
        'Weight_2
        '
        Me.Weight_2.BackColor = System.Drawing.Color.White
        Me.Weight_2.Location = New System.Drawing.Point(58, 174)
        Me.Weight_2.Name = "Weight_2"
        Me.Weight_2.Size = New System.Drawing.Size(100, 22)
        Me.Weight_2.TabIndex = 31
        '
        'CategoryName_2
        '
        Me.CategoryName_2.DropDownHeight = 150
        Me.CategoryName_2.DropDownWidth = 250
        Me.CategoryName_2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CategoryName_2.FormattingEnabled = True
        Me.CategoryName_2.IntegralHeight = False
        Me.CategoryName_2.Location = New System.Drawing.Point(58, 61)
        Me.CategoryName_2.Name = "CategoryName_2"
        Me.CategoryName_2.Size = New System.Drawing.Size(100, 24)
        Me.CategoryName_2.Sorted = True
        Me.CategoryName_2.TabIndex = 30
        '
        'DGV3
        '
        Me.DGV3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV3.Location = New System.Drawing.Point(166, 6)
        Me.DGV3.Name = "DGV3"
        Me.DGV3.RowHeadersWidth = 25
        Me.DGV3.RowTemplate.Height = 24
        Me.DGV3.Size = New System.Drawing.Size(434, 514)
        Me.DGV3.TabIndex = 29
        '
        'DelBut_2
        '
        Me.DelBut_2.Location = New System.Drawing.Point(87, 467)
        Me.DelBut_2.Name = "DelBut_2"
        Me.DelBut_2.Size = New System.Drawing.Size(75, 23)
        Me.DelBut_2.TabIndex = 28
        Me.DelBut_2.Text = "刪除"
        Me.DelBut_2.UseVisualStyleBackColor = True
        '
        'UpdateBut_2
        '
        Me.UpdateBut_2.Location = New System.Drawing.Point(87, 496)
        Me.UpdateBut_2.Name = "UpdateBut_2"
        Me.UpdateBut_2.Size = New System.Drawing.Size(75, 23)
        Me.UpdateBut_2.TabIndex = 27
        Me.UpdateBut_2.Text = "更新"
        Me.UpdateBut_2.UseVisualStyleBackColor = True
        '
        'MdyBut_2
        '
        Me.MdyBut_2.Location = New System.Drawing.Point(6, 496)
        Me.MdyBut_2.Name = "MdyBut_2"
        Me.MdyBut_2.Size = New System.Drawing.Size(75, 23)
        Me.MdyBut_2.TabIndex = 26
        Me.MdyBut_2.Text = "修改"
        Me.MdyBut_2.UseVisualStyleBackColor = True
        '
        'AddBut_2
        '
        Me.AddBut_2.Location = New System.Drawing.Point(6, 467)
        Me.AddBut_2.Name = "AddBut_2"
        Me.AddBut_2.Size = New System.Drawing.Size(75, 23)
        Me.AddBut_2.TabIndex = 25
        Me.AddBut_2.Text = "新增"
        Me.AddBut_2.UseVisualStyleBackColor = True
        '
        'ItemCode_2
        '
        Me.ItemCode_2.BackColor = System.Drawing.Color.White
        Me.ItemCode_2.Location = New System.Drawing.Point(58, 90)
        Me.ItemCode_2.Name = "ItemCode_2"
        Me.ItemCode_2.Size = New System.Drawing.Size(100, 22)
        Me.ItemCode_2.TabIndex = 24
        '
        'ItemName_2
        '
        Me.ItemName_2.BackColor = System.Drawing.Color.White
        Me.ItemName_2.Location = New System.Drawing.Point(58, 118)
        Me.ItemName_2.Name = "ItemName_2"
        Me.ItemName_2.Size = New System.Drawing.Size(100, 22)
        Me.ItemName_2.TabIndex = 23
        '
        'Order_2
        '
        Me.Order_2.BackColor = System.Drawing.Color.White
        Me.Order_2.Location = New System.Drawing.Point(58, 34)
        Me.Order_2.Name = "Order_2"
        Me.Order_2.Size = New System.Drawing.Size(100, 22)
        Me.Order_2.TabIndex = 22
        '
        'LineNum_2
        '
        Me.LineNum_2.Enabled = False
        Me.LineNum_2.Location = New System.Drawing.Point(58, 6)
        Me.LineNum_2.Name = "LineNum_2"
        Me.LineNum_2.Size = New System.Drawing.Size(100, 22)
        Me.LineNum_2.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(3, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "存編："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(3, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "類別："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(3, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "順序："
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "列號："
        '
        'Floor
        '
        Me.Floor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Floor.FormattingEnabled = True
        Me.Floor.Items.AddRange(New Object() {"1樓", "2樓", "3樓", "預解", "新類"})
        Me.Floor.Location = New System.Drawing.Point(54, 5)
        Me.Floor.Name = "Floor"
        Me.Floor.Size = New System.Drawing.Size(128, 20)
        Me.Floor.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "樓層："
        '
        'Search
        '
        Me.Search.Location = New System.Drawing.Point(188, 1)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(75, 23)
        Me.Search.TabIndex = 3
        Me.Search.Text = "查詢資料"
        Me.Search.UseVisualStyleBackColor = True
        '
        'AgainSearch
        '
        Me.AgainSearch.Location = New System.Drawing.Point(275, 1)
        Me.AgainSearch.Name = "AgainSearch"
        Me.AgainSearch.Size = New System.Drawing.Size(75, 23)
        Me.AgainSearch.TabIndex = 4
        Me.AgainSearch.Text = "重查資料"
        Me.AgainSearch.UseVisualStyleBackColor = True
        '
        'B_OSPdata
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 585)
        Me.Controls.Add(Me.AgainSearch)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Floor)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "B_OSPdata"
        Me.Text = "B_OSPdata"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DGV2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DGV3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Floor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents AgainSearch As System.Windows.Forms.Button
    Friend WithEvents CardName_0 As System.Windows.Forms.TextBox
    Friend WithEvents CardCode_0 As System.Windows.Forms.TextBox
    Friend WithEvents Order_0 As System.Windows.Forms.TextBox
    Friend WithEvents LineNum_0 As System.Windows.Forms.TextBox
    Friend WithEvents CategoryName_1 As System.Windows.Forms.TextBox
    Friend WithEvents Order_1 As System.Windows.Forms.TextBox
    Friend WithEvents LineNum_1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DGV2 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents DelBut_0 As System.Windows.Forms.Button
    Friend WithEvents UpdateBut_0 As System.Windows.Forms.Button
    Friend WithEvents MdyBut_0 As System.Windows.Forms.Button
    Friend WithEvents AddBut_0 As System.Windows.Forms.Button
    Friend WithEvents DelBut_1 As System.Windows.Forms.Button
    Friend WithEvents UpdateBut_1 As System.Windows.Forms.Button
    Friend WithEvents MdyBut_1 As System.Windows.Forms.Button
    Friend WithEvents AddBut_1 As System.Windows.Forms.Button
    Friend WithEvents DGV3 As System.Windows.Forms.DataGridView
    Friend WithEvents DelBut_2 As System.Windows.Forms.Button
    Friend WithEvents UpdateBut_2 As System.Windows.Forms.Button
    Friend WithEvents MdyBut_2 As System.Windows.Forms.Button
    Friend WithEvents AddBut_2 As System.Windows.Forms.Button
    Friend WithEvents ItemCode_2 As System.Windows.Forms.TextBox
    Friend WithEvents ItemName_2 As System.Windows.Forms.TextBox
    Friend WithEvents Order_2 As System.Windows.Forms.TextBox
    Friend WithEvents LineNum_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CategoryName_2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Plate_H_2 As System.Windows.Forms.TextBox
    Friend WithEvents Weight_2 As System.Windows.Forms.TextBox
    Friend WithEvents Remarks_2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents AliasName_0 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents SidT0 As System.Windows.Forms.Label
End Class
