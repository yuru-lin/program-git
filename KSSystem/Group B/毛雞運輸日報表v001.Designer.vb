<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 毛雞運輸日報表v001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(毛雞運輸日報表v001))
        Me.dateDocDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSearch = New System.Windows.Forms.Button
        Me.dgvTransport = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvTransportDetail = New System.Windows.Forms.DataGridView
        Me.btnPrint = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvByM03 = New System.Windows.Forms.DataGridView
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtComment = New System.Windows.Forms.RichTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvTransportALL = New System.Windows.Forms.DataGridView
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.SaveBtn = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtM7 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtM10 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPlannedQty = New System.Windows.Forms.TextBox
        Me.txtM8 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.lbM03 = New System.Windows.Forms.Label
        Me.txtM12 = New System.Windows.Forms.TextBox
        Me.lbDocNum = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtM9 = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        CType(Me.dgvTransport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransportDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvByM03, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvTransportALL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dateDocDate
        '
        Me.dateDocDate.Location = New System.Drawing.Point(320, 12)
        Me.dateDocDate.Name = "dateDocDate"
        Me.dateDocDate.Size = New System.Drawing.Size(120, 22)
        Me.dateDocDate.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(264, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "日期："
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(445, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 79
        Me.btnSearch.Text = "查詢"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvTransport
        '
        Me.dgvTransport.AllowUserToAddRows = False
        Me.dgvTransport.AllowUserToDeleteRows = False
        Me.dgvTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransport.Location = New System.Drawing.Point(3, 19)
        Me.dgvTransport.Name = "dgvTransport"
        Me.dgvTransport.ReadOnly = True
        Me.dgvTransport.RowHeadersVisible = False
        Me.dgvTransport.RowTemplate.Height = 24
        Me.dgvTransport.Size = New System.Drawing.Size(732, 242)
        Me.dgvTransport.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "單號資料："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 264)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "詳細資料："
        '
        'dgvTransportDetail
        '
        Me.dgvTransportDetail.AllowUserToAddRows = False
        Me.dgvTransportDetail.AllowUserToDeleteRows = False
        Me.dgvTransportDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransportDetail.Location = New System.Drawing.Point(3, 283)
        Me.dgvTransportDetail.Name = "dgvTransportDetail"
        Me.dgvTransportDetail.ReadOnly = True
        Me.dgvTransportDetail.RowHeadersVisible = False
        Me.dgvTransportDetail.RowTemplate.Height = 24
        Me.dgvTransportDetail.Size = New System.Drawing.Size(732, 184)
        Me.dgvTransportDetail.TabIndex = 82
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(637, 444)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 23)
        Me.btnPrint.TabIndex = 84
        Me.btnPrint.Text = "列印報表"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvTransport)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dgvTransportDetail)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(740, 472)
        Me.Panel1.TabIndex = 89
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dgvByM03)
        Me.Panel2.Controls.Add(Me.btnToExcel)
        Me.Panel2.Location = New System.Drawing.Point(6, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(740, 261)
        Me.Panel2.TabIndex = 90
        '
        'dgvByM03
        '
        Me.dgvByM03.AllowUserToAddRows = False
        Me.dgvByM03.AllowUserToDeleteRows = False
        Me.dgvByM03.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvByM03.Location = New System.Drawing.Point(3, 3)
        Me.dgvByM03.Name = "dgvByM03"
        Me.dgvByM03.ReadOnly = True
        Me.dgvByM03.RowHeadersVisible = False
        Me.dgvByM03.RowTemplate.Height = 24
        Me.dgvByM03.Size = New System.Drawing.Size(732, 222)
        Me.dgvByM03.TabIndex = 84
        '
        'btnToExcel
        '
        Me.btnToExcel.Location = New System.Drawing.Point(660, 231)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(75, 23)
        Me.btnToExcel.TabIndex = 171
        Me.btnToExcel.Text = "匯出Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtComment)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.dgvTransportALL)
        Me.Panel3.Controls.Add(Me.btnPrint)
        Me.Panel3.Location = New System.Drawing.Point(6, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(740, 472)
        Me.Panel3.TabIndex = 91
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "報表備註："
        '
        'txtComment
        '
        Me.txtComment.Location = New System.Drawing.Point(6, 314)
        Me.txtComment.Name = "txtComment"
        Me.txtComment.Size = New System.Drawing.Size(370, 153)
        Me.txtComment.TabIndex = 86
        Me.txtComment.Text = resources.GetString("txtComment.Text")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "全部整合："
        '
        'dgvTransportALL
        '
        Me.dgvTransportALL.AllowUserToAddRows = False
        Me.dgvTransportALL.AllowUserToDeleteRows = False
        Me.dgvTransportALL.AllowUserToOrderColumns = True
        Me.dgvTransportALL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransportALL.Location = New System.Drawing.Point(3, 19)
        Me.dgvTransportALL.Name = "dgvTransportALL"
        Me.dgvTransportALL.RowHeadersVisible = False
        Me.dgvTransportALL.RowTemplate.Height = 24
        Me.dgvTransportALL.Size = New System.Drawing.Size(732, 273)
        Me.dgvTransportALL.TabIndex = 84
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(760, 510)
        Me.TabControl1.TabIndex = 92
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(752, 484)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "詳細資料"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(752, 484)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "依製單"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.SaveBtn)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.txtM7)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.txtM10)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.txtPlannedQty)
        Me.Panel4.Controls.Add(Me.txtM8)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.lbM03)
        Me.Panel4.Controls.Add(Me.txtM12)
        Me.Panel4.Controls.Add(Me.lbDocNum)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.txtM9)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(6, 273)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(740, 194)
        Me.Panel4.TabIndex = 172
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(289, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 12)
        Me.Label17.TabIndex = 114
        Me.Label17.Text = "(磅單羽數)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "回填至生產訂單："
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(194, 35)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 16)
        Me.Label13.TabIndex = 94
        Me.Label13.Text = "會磅重量："
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(139, 165)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveBtn.TabIndex = 91
        Me.SaveBtn.Text = "回填"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(96, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 12)
        Me.Label18.TabIndex = 112
        Me.Label18.Text = "(磅單重)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 92
        Me.Label14.Text = "投入重量："
        '
        'txtM7
        '
        Me.txtM7.Location = New System.Drawing.Point(98, 32)
        Me.txtM7.Name = "txtM7"
        Me.txtM7.Size = New System.Drawing.Size(90, 22)
        Me.txtM7.TabIndex = 93
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(289, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 12)
        Me.Label16.TabIndex = 110
        Me.Label16.Text = "(磅單羽數)"
        '
        'txtM10
        '
        Me.txtM10.Location = New System.Drawing.Point(289, 32)
        Me.txtM10.Name = "txtM10"
        Me.txtM10.Size = New System.Drawing.Size(90, 22)
        Me.txtM10.TabIndex = 95
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Blue
        Me.Label15.Location = New System.Drawing.Point(289, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 12)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "(公司會磅)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "死亡隻數："
        '
        'txtPlannedQty
        '
        Me.txtPlannedQty.Location = New System.Drawing.Point(289, 117)
        Me.txtPlannedQty.Name = "txtPlannedQty"
        Me.txtPlannedQty.Size = New System.Drawing.Size(90, 22)
        Me.txtPlannedQty.TabIndex = 108
        '
        'txtM8
        '
        Me.txtM8.Location = New System.Drawing.Point(98, 77)
        Me.txtM8.Name = "txtM8"
        Me.txtM8.Size = New System.Drawing.Size(90, 22)
        Me.txtM8.TabIndex = 97
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(194, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "計劃數量："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(194, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "投入隻數："
        '
        'lbM03
        '
        Me.lbM03.AutoSize = True
        Me.lbM03.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbM03.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbM03.Location = New System.Drawing.Point(288, 1)
        Me.lbM03.Name = "lbM03"
        Me.lbM03.Size = New System.Drawing.Size(0, 16)
        Me.lbM03.TabIndex = 105
        '
        'txtM12
        '
        Me.txtM12.Location = New System.Drawing.Point(289, 77)
        Me.txtM12.Name = "txtM12"
        Me.txtM12.Size = New System.Drawing.Size(90, 22)
        Me.txtM12.TabIndex = 99
        '
        'lbDocNum
        '
        Me.lbDocNum.AutoSize = True
        Me.lbDocNum.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbDocNum.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbDocNum.Location = New System.Drawing.Point(97, 1)
        Me.lbDocNum.Name = "lbDocNum"
        Me.lbDocNum.Size = New System.Drawing.Size(0, 16)
        Me.lbDocNum.TabIndex = 104
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "廢棄隻數："
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(194, 1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "製單編號："
        '
        'txtM9
        '
        Me.txtM9.Location = New System.Drawing.Point(98, 117)
        Me.txtM9.Name = "txtM9"
        Me.txtM9.Size = New System.Drawing.Size(90, 22)
        Me.txtM9.TabIndex = 101
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "文件號碼："
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(752, 484)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "全部整合"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'B_QueryTransportation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dateDocDate)
        Me.Controls.Add(Me.Label1)
        Me.Name = "B_QueryTransportation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "毛雞運輸日報表查詢"
        CType(Me.dgvTransport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransportDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvByM03, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvTransportALL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dateDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvTransport As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvTransportDetail As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvByM03 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvTransportALL As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtComment As System.Windows.Forms.RichTextBox
    Friend WithEvents txtPlannedQty As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbM03 As System.Windows.Forms.Label
    Friend WithEvents lbDocNum As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtM9 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtM12 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtM8 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtM10 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtM7 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
