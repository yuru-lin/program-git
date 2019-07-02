<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 退貨記錄V100
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
        Me.Tp退貨作業 = New System.Windows.Forms.TabPage
        Me.Cb1印表機 = New System.Windows.Forms.ComboBox
        Me.De1開始 = New System.Windows.Forms.DateTimePicker
        Me.De1結束 = New System.Windows.Forms.DateTimePicker
        Me.Rb1日期 = New System.Windows.Forms.RadioButton
        Me.Bu1列印 = New System.Windows.Forms.Button
        Me.T1退貨明細 = New System.Windows.Forms.DataGridView
        Me.Tb1名稱 = New System.Windows.Forms.TextBox
        Me.Cb1客戶名單 = New System.Windows.Forms.ComboBox
        Me.Rb1客戶1 = New System.Windows.Forms.RadioButton
        Me.Rb1客戶2 = New System.Windows.Forms.RadioButton
        Me.Tb1客編 = New System.Windows.Forms.TextBox
        Me.Bu1刪除 = New System.Windows.Forms.Button
        Me.T1退貨單號 = New System.Windows.Forms.DataGridView
        Me.Bu1新增 = New System.Windows.Forms.Button
        Me.Bu1修改 = New System.Windows.Forms.Button
        Me.T1退貨記錄 = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.Bu1查詢 = New System.Windows.Forms.Button
        Me.Tp退單選擇 = New System.Windows.Forms.TabPage
        Me.Lt2來源 = New System.Windows.Forms.Label
        Me.Bu2放棄 = New System.Windows.Forms.Button
        Me.Lt2單號 = New System.Windows.Forms.Label
        Me.Cb2退單來源 = New System.Windows.Forms.ComboBox
        Me.Bu2選單 = New System.Windows.Forms.Button
        Me.De2日期2 = New System.Windows.Forms.DateTimePicker
        Me.Bu2查詢 = New System.Windows.Forms.Button
        Me.De2日期1 = New System.Windows.Forms.DateTimePicker
        Me.T2單號明細 = New System.Windows.Forms.DataGridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.T2選擇單號 = New System.Windows.Forms.DataGridView
        Me.Tp退貨輸入 = New System.Windows.Forms.TabPage
        Me.Lt3名稱 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Bu3數量 = New System.Windows.Forms.Button
        Me.Cb3運輸司機 = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Cb3Key單人員 = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.De3退貨 = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.Cb3退貨原因 = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Tb3備註 = New System.Windows.Forms.TextBox
        Me.Bu3放棄 = New System.Windows.Forms.Button
        Me.Bu3存檔 = New System.Windows.Forms.Button
        Me.Cb3處理方式 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Bu3刪除 = New System.Windows.Forms.Button
        Me.Bu3新增 = New System.Windows.Forms.Button
        Me.De3輸入 = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Tb3總計 = New System.Windows.Forms.TextBox
        Me.Tb3稅額 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Cb3責任單位 = New System.Windows.Forms.ComboBox
        Me.Cb3折退類別 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.T3退貨明細 = New System.Windows.Forms.DataGridView
        Me.Label8 = New System.Windows.Forms.Label
        Me.T3單號明細 = New System.Windows.Forms.DataGridView
        Me.Tp退貨數量 = New System.Windows.Forms.TabPage
        Me.Lt4合計2 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Lt4合計1 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.T4Lt1說明 = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.T4Cb2情況 = New System.Windows.Forms.ComboBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.T4Cb2結果 = New System.Windows.Forms.ComboBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.T4Cb2原因 = New System.Windows.Forms.ComboBox
        Me.T4Cb2相符 = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Lt42數量 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Lt4ID = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Lt4列號 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Lt4合計 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Bu4移除 = New System.Windows.Forms.Button
        Me.Bu4放棄 = New System.Windows.Forms.Button
        Me.Lt4可退 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Bu4輸入 = New System.Windows.Forms.Button
        Me.Lt4名稱 = New System.Windows.Forms.Label
        Me.Lt4存編 = New System.Windows.Forms.Label
        Me.Bu4存檔 = New System.Windows.Forms.Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.T4Cb1原因 = New System.Windows.Forms.ComboBox
        Me.T4Cb1類別 = New System.Windows.Forms.ComboBox
        Me.T4Lt2說明 = New System.Windows.Forms.TextBox
        Me.Lt4數量 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.T4退貨記錄 = New System.Windows.Forms.DataGridView
        Me.Label19 = New System.Windows.Forms.Label
        Me.T4輸入資料 = New System.Windows.Forms.DataGridView
        Me.Label20 = New System.Windows.Forms.Label
        Me.Lt總計 = New System.Windows.Forms.Label
        Me.Lt稅額 = New System.Windows.Forms.Label
        Me.Gb表頭資料 = New System.Windows.Forms.GroupBox
        Me.Lt運輸司機 = New System.Windows.Forms.Label
        Me.Lt司機代碼 = New System.Windows.Forms.Label
        Me.Lt退貨日期 = New System.Windows.Forms.Label
        Me.Lt退貨原因 = New System.Windows.Forms.Label
        Me.Lt退貨代碼 = New System.Windows.Forms.Label
        Me.Lt處理方式 = New System.Windows.Forms.Label
        Me.Lt類別 = New System.Windows.Forms.Label
        Me.Lt來源 = New System.Windows.Forms.Label
        Me.Lt輸入者 = New System.Windows.Forms.Label
        Me.Lt傳真 = New System.Windows.Forms.Label
        Me.Lt電話 = New System.Windows.Forms.Label
        Me.Lt備註2 = New System.Windows.Forms.Label
        Me.Lt備註1 = New System.Windows.Forms.Label
        Me.Lt聯絡人 = New System.Windows.Forms.Label
        Me.Lt過帳日期 = New System.Windows.Forms.Label
        Me.Lt責任單位 = New System.Windows.Forms.Label
        Me.Lt文件單號 = New System.Windows.Forms.Label
        Me.Lt發票日期 = New System.Windows.Forms.Label
        Me.Lt發票號碼 = New System.Windows.Forms.Label
        Me.Lt地址 = New System.Windows.Forms.Label
        Me.TB單號 = New System.Windows.Forms.TextBox
        Me.TB名稱 = New System.Windows.Forms.TextBox
        Me.TB客編 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Lt作業 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.Tp退貨作業.SuspendLayout()
        CType(Me.T1退貨明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1退貨單號, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T1退貨記錄, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tp退單選擇.SuspendLayout()
        CType(Me.T2單號明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T2選擇單號, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tp退貨輸入.SuspendLayout()
        CType(Me.T3退貨明細, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T3單號明細, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tp退貨數量.SuspendLayout()
        CType(Me.T4退貨記錄, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T4輸入資料, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Gb表頭資料.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl1.Controls.Add(Me.Tp退貨作業)
        Me.TabControl1.Controls.Add(Me.Tp退單選擇)
        Me.TabControl1.Controls.Add(Me.Tp退貨輸入)
        Me.TabControl1.Controls.Add(Me.Tp退貨數量)
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 34)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1178, 602)
        Me.TabControl1.TabIndex = 0
        '
        'Tp退貨作業
        '
        Me.Tp退貨作業.Controls.Add(Me.Cb1印表機)
        Me.Tp退貨作業.Controls.Add(Me.De1開始)
        Me.Tp退貨作業.Controls.Add(Me.De1結束)
        Me.Tp退貨作業.Controls.Add(Me.Rb1日期)
        Me.Tp退貨作業.Controls.Add(Me.Bu1列印)
        Me.Tp退貨作業.Controls.Add(Me.T1退貨明細)
        Me.Tp退貨作業.Controls.Add(Me.Tb1名稱)
        Me.Tp退貨作業.Controls.Add(Me.Cb1客戶名單)
        Me.Tp退貨作業.Controls.Add(Me.Rb1客戶1)
        Me.Tp退貨作業.Controls.Add(Me.Rb1客戶2)
        Me.Tp退貨作業.Controls.Add(Me.Tb1客編)
        Me.Tp退貨作業.Controls.Add(Me.Bu1刪除)
        Me.Tp退貨作業.Controls.Add(Me.T1退貨單號)
        Me.Tp退貨作業.Controls.Add(Me.Bu1新增)
        Me.Tp退貨作業.Controls.Add(Me.Bu1修改)
        Me.Tp退貨作業.Controls.Add(Me.T1退貨記錄)
        Me.Tp退貨作業.Controls.Add(Me.Label7)
        Me.Tp退貨作業.Controls.Add(Me.Bu1查詢)
        Me.Tp退貨作業.Location = New System.Drawing.Point(4, 4)
        Me.Tp退貨作業.Name = "Tp退貨作業"
        Me.Tp退貨作業.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp退貨作業.Size = New System.Drawing.Size(1170, 572)
        Me.Tp退貨作業.TabIndex = 0
        Me.Tp退貨作業.Text = "退貨作業"
        Me.Tp退貨作業.UseVisualStyleBackColor = True
        '
        'Cb1印表機
        '
        Me.Cb1印表機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1印表機.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb1印表機.FormattingEnabled = True
        Me.Cb1印表機.Location = New System.Drawing.Point(808, 6)
        Me.Cb1印表機.Name = "Cb1印表機"
        Me.Cb1印表機.Size = New System.Drawing.Size(357, 29)
        Me.Cb1印表機.TabIndex = 1032
        '
        'De1開始
        '
        Me.De1開始.CalendarFont = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1開始.CustomFormat = "yyyy/MM/dd"
        Me.De1開始.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1開始.Location = New System.Drawing.Point(202, 62)
        Me.De1開始.Name = "De1開始"
        Me.De1開始.Size = New System.Drawing.Size(110, 23)
        Me.De1開始.TabIndex = 1030
        '
        'De1結束
        '
        Me.De1結束.CalendarFont = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1結束.CustomFormat = "yyyy/MM/dd"
        Me.De1結束.Font = New System.Drawing.Font("新細明體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.De1結束.Location = New System.Drawing.Point(317, 62)
        Me.De1結束.Name = "De1結束"
        Me.De1結束.Size = New System.Drawing.Size(110, 23)
        Me.De1結束.TabIndex = 1031
        '
        'Rb1日期
        '
        Me.Rb1日期.AutoSize = True
        Me.Rb1日期.Checked = True
        Me.Rb1日期.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Rb1日期.Location = New System.Drawing.Point(100, 62)
        Me.Rb1日期.Name = "Rb1日期"
        Me.Rb1日期.Size = New System.Drawing.Size(111, 20)
        Me.Rb1日期.TabIndex = 1026
        Me.Rb1日期.TabStop = True
        Me.Rb1日期.Text = "單據日期："
        Me.Rb1日期.UseVisualStyleBackColor = True
        '
        'Bu1列印
        '
        Me.Bu1列印.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Bu1列印.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1列印.Location = New System.Drawing.Point(1081, 53)
        Me.Bu1列印.Name = "Bu1列印"
        Me.Bu1列印.Size = New System.Drawing.Size(84, 37)
        Me.Bu1列印.TabIndex = 1025
        Me.Bu1列印.Text = "列印"
        Me.Bu1列印.UseVisualStyleBackColor = False
        Me.Bu1列印.Visible = False
        '
        'T1退貨明細
        '
        Me.T1退貨明細.AllowUserToAddRows = False
        Me.T1退貨明細.AllowUserToDeleteRows = False
        Me.T1退貨明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1退貨明細.Location = New System.Drawing.Point(3, 349)
        Me.T1退貨明細.MultiSelect = False
        Me.T1退貨明細.Name = "T1退貨明細"
        Me.T1退貨明細.ReadOnly = True
        Me.T1退貨明細.RowHeadersVisible = False
        Me.T1退貨明細.RowTemplate.Height = 24
        Me.T1退貨明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1退貨明細.Size = New System.Drawing.Size(861, 220)
        Me.T1退貨明細.TabIndex = 1024
        '
        'Tb1名稱
        '
        Me.Tb1名稱.Location = New System.Drawing.Point(202, 5)
        Me.Tb1名稱.Name = "Tb1名稱"
        Me.Tb1名稱.Size = New System.Drawing.Size(177, 27)
        Me.Tb1名稱.TabIndex = 1011
        '
        'Cb1客戶名單
        '
        Me.Cb1客戶名單.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1客戶名單.FormattingEnabled = True
        Me.Cb1客戶名單.Items.AddRange(New Object() {"10大客戶"})
        Me.Cb1客戶名單.Location = New System.Drawing.Point(202, 34)
        Me.Cb1客戶名單.Name = "Cb1客戶名單"
        Me.Cb1客戶名單.Size = New System.Drawing.Size(175, 24)
        Me.Cb1客戶名單.TabIndex = 1021
        Me.Cb1客戶名單.Visible = False
        '
        'Rb1客戶1
        '
        Me.Rb1客戶1.AutoSize = True
        Me.Rb1客戶1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Rb1客戶1.Location = New System.Drawing.Point(100, 8)
        Me.Rb1客戶1.Name = "Rb1客戶1"
        Me.Rb1客戶1.Size = New System.Drawing.Size(111, 20)
        Me.Rb1客戶1.TabIndex = 1023
        Me.Rb1客戶1.Text = "查詢名稱："
        Me.Rb1客戶1.UseVisualStyleBackColor = True
        '
        'Rb1客戶2
        '
        Me.Rb1客戶2.AutoSize = True
        Me.Rb1客戶2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Rb1客戶2.Location = New System.Drawing.Point(100, 36)
        Me.Rb1客戶2.Name = "Rb1客戶2"
        Me.Rb1客戶2.Size = New System.Drawing.Size(111, 20)
        Me.Rb1客戶2.TabIndex = 1022
        Me.Rb1客戶2.Text = "客戶名單："
        Me.Rb1客戶2.UseVisualStyleBackColor = True
        Me.Rb1客戶2.Visible = False
        '
        'Tb1客編
        '
        Me.Tb1客編.Location = New System.Drawing.Point(469, 5)
        Me.Tb1客編.Name = "Tb1客編"
        Me.Tb1客編.Size = New System.Drawing.Size(177, 27)
        Me.Tb1客編.TabIndex = 1010
        '
        'Bu1刪除
        '
        Me.Bu1刪除.BackColor = System.Drawing.Color.Red
        Me.Bu1刪除.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1刪除.Location = New System.Drawing.Point(889, 52)
        Me.Bu1刪除.Name = "Bu1刪除"
        Me.Bu1刪除.Size = New System.Drawing.Size(84, 37)
        Me.Bu1刪除.TabIndex = 1021
        Me.Bu1刪除.Text = "刪除"
        Me.Bu1刪除.UseVisualStyleBackColor = False
        Me.Bu1刪除.Visible = False
        '
        'T1退貨單號
        '
        Me.T1退貨單號.AllowUserToAddRows = False
        Me.T1退貨單號.AllowUserToDeleteRows = False
        Me.T1退貨單號.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1退貨單號.Location = New System.Drawing.Point(3, 93)
        Me.T1退貨單號.MultiSelect = False
        Me.T1退貨單號.Name = "T1退貨單號"
        Me.T1退貨單號.ReadOnly = True
        Me.T1退貨單號.RowHeadersVisible = False
        Me.T1退貨單號.RowTemplate.Height = 24
        Me.T1退貨單號.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1退貨單號.Size = New System.Drawing.Size(861, 254)
        Me.T1退貨單號.TabIndex = 1021
        '
        'Bu1新增
        '
        Me.Bu1新增.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1新增.Location = New System.Drawing.Point(6, 51)
        Me.Bu1新增.Name = "Bu1新增"
        Me.Bu1新增.Size = New System.Drawing.Size(84, 37)
        Me.Bu1新增.TabIndex = 1020
        Me.Bu1新增.Text = "新增"
        Me.Bu1新增.UseVisualStyleBackColor = True
        Me.Bu1新增.Visible = False
        '
        'Bu1修改
        '
        Me.Bu1修改.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1修改.Location = New System.Drawing.Point(662, 51)
        Me.Bu1修改.Name = "Bu1修改"
        Me.Bu1修改.Size = New System.Drawing.Size(84, 37)
        Me.Bu1修改.TabIndex = 1019
        Me.Bu1修改.Text = "修改"
        Me.Bu1修改.UseVisualStyleBackColor = True
        Me.Bu1修改.Visible = False
        '
        'T1退貨記錄
        '
        Me.T1退貨記錄.AllowUserToAddRows = False
        Me.T1退貨記錄.AllowUserToDeleteRows = False
        Me.T1退貨記錄.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T1退貨記錄.Location = New System.Drawing.Point(869, 93)
        Me.T1退貨記錄.MultiSelect = False
        Me.T1退貨記錄.Name = "T1退貨記錄"
        Me.T1退貨記錄.ReadOnly = True
        Me.T1退貨記錄.RowHeadersVisible = False
        Me.T1退貨記錄.RowTemplate.Height = 24
        Me.T1退貨記錄.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T1退貨記錄.Size = New System.Drawing.Size(295, 476)
        Me.T1退貨記錄.TabIndex = 1020
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(384, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 1008
        Me.Label7.Text = "查詢客編："
        '
        'Bu1查詢
        '
        Me.Bu1查詢.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu1查詢.Location = New System.Drawing.Point(505, 60)
        Me.Bu1查詢.Name = "Bu1查詢"
        Me.Bu1查詢.Size = New System.Drawing.Size(84, 27)
        Me.Bu1查詢.TabIndex = 1012
        Me.Bu1查詢.Text = "查詢"
        Me.Bu1查詢.UseVisualStyleBackColor = True
        '
        'Tp退單選擇
        '
        Me.Tp退單選擇.Controls.Add(Me.Lt2來源)
        Me.Tp退單選擇.Controls.Add(Me.Bu2放棄)
        Me.Tp退單選擇.Controls.Add(Me.Lt2單號)
        Me.Tp退單選擇.Controls.Add(Me.Cb2退單來源)
        Me.Tp退單選擇.Controls.Add(Me.Bu2選單)
        Me.Tp退單選擇.Controls.Add(Me.De2日期2)
        Me.Tp退單選擇.Controls.Add(Me.Bu2查詢)
        Me.Tp退單選擇.Controls.Add(Me.De2日期1)
        Me.Tp退單選擇.Controls.Add(Me.T2單號明細)
        Me.Tp退單選擇.Controls.Add(Me.Label9)
        Me.Tp退單選擇.Controls.Add(Me.T2選擇單號)
        Me.Tp退單選擇.Location = New System.Drawing.Point(4, 4)
        Me.Tp退單選擇.Name = "Tp退單選擇"
        Me.Tp退單選擇.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp退單選擇.Size = New System.Drawing.Size(1170, 572)
        Me.Tp退單選擇.TabIndex = 1
        Me.Tp退單選擇.Text = "退單選擇"
        Me.Tp退單選擇.UseVisualStyleBackColor = True
        '
        'Lt2來源
        '
        Me.Lt2來源.AutoSize = True
        Me.Lt2來源.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt2來源.Location = New System.Drawing.Point(189, 38)
        Me.Lt2來源.Name = "Lt2來源"
        Me.Lt2來源.Size = New System.Drawing.Size(42, 16)
        Me.Lt2來源.TabIndex = 1029
        Me.Lt2來源.Text = "來源"
        '
        'Bu2放棄
        '
        Me.Bu2放棄.BackColor = System.Drawing.Color.Red
        Me.Bu2放棄.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2放棄.Location = New System.Drawing.Point(888, 24)
        Me.Bu2放棄.Name = "Bu2放棄"
        Me.Bu2放棄.Size = New System.Drawing.Size(84, 37)
        Me.Bu2放棄.TabIndex = 1028
        Me.Bu2放棄.Text = "放棄"
        Me.Bu2放棄.UseVisualStyleBackColor = False
        '
        'Lt2單號
        '
        Me.Lt2單號.AutoSize = True
        Me.Lt2單號.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt2單號.Location = New System.Drawing.Point(8, 4)
        Me.Lt2單號.Name = "Lt2單號"
        Me.Lt2單號.Size = New System.Drawing.Size(49, 19)
        Me.Lt2單號.TabIndex = 1025
        Me.Lt2單號.Text = "單號"
        '
        'Cb2退單來源
        '
        Me.Cb2退單來源.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb2退單來源.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb2退單來源.FormattingEnabled = True
        Me.Cb2退單來源.Items.AddRange(New Object() {"AR發票", "交貨單"})
        Me.Cb2退單來源.Location = New System.Drawing.Point(288, 32)
        Me.Cb2退單來源.Name = "Cb2退單來源"
        Me.Cb2退單來源.Size = New System.Drawing.Size(121, 27)
        Me.Cb2退單來源.TabIndex = 1023
        '
        'Bu2選單
        '
        Me.Bu2選單.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2選單.Location = New System.Drawing.Point(8, 26)
        Me.Bu2選單.Name = "Bu2選單"
        Me.Bu2選單.Size = New System.Drawing.Size(168, 37)
        Me.Bu2選單.TabIndex = 1024
        Me.Bu2選單.Text = "選擇單據"
        Me.Bu2選單.UseVisualStyleBackColor = True
        Me.Bu2選單.Visible = False
        '
        'De2日期2
        '
        Me.De2日期2.CustomFormat = "yyyy/MM/dd"
        Me.De2日期2.Location = New System.Drawing.Point(415, 34)
        Me.De2日期2.Name = "De2日期2"
        Me.De2日期2.Size = New System.Drawing.Size(133, 27)
        Me.De2日期2.TabIndex = 1023
        '
        'Bu2查詢
        '
        Me.Bu2查詢.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu2查詢.Location = New System.Drawing.Point(575, 23)
        Me.Bu2查詢.Name = "Bu2查詢"
        Me.Bu2查詢.Size = New System.Drawing.Size(84, 37)
        Me.Bu2查詢.TabIndex = 1019
        Me.Bu2查詢.Text = "查詢"
        Me.Bu2查詢.UseVisualStyleBackColor = True
        '
        'De2日期1
        '
        Me.De2日期1.CustomFormat = "yyyy/MM/dd"
        Me.De2日期1.Location = New System.Drawing.Point(415, 3)
        Me.De2日期1.Name = "De2日期1"
        Me.De2日期1.Size = New System.Drawing.Size(133, 27)
        Me.De2日期1.TabIndex = 1019
        '
        'T2單號明細
        '
        Me.T2單號明細.AllowUserToAddRows = False
        Me.T2單號明細.AllowUserToDeleteRows = False
        Me.T2單號明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2單號明細.Location = New System.Drawing.Point(3, 267)
        Me.T2單號明細.MultiSelect = False
        Me.T2單號明細.Name = "T2單號明細"
        Me.T2單號明細.ReadOnly = True
        Me.T2單號明細.RowHeadersVisible = False
        Me.T2單號明細.RowTemplate.Height = 24
        Me.T2單號明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2單號明細.Size = New System.Drawing.Size(1161, 302)
        Me.T2單號明細.TabIndex = 1022
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(316, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 1020
        Me.Label9.Text = "日期選擇："
        '
        'T2選擇單號
        '
        Me.T2選擇單號.AllowUserToAddRows = False
        Me.T2選擇單號.AllowUserToDeleteRows = False
        Me.T2選擇單號.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T2選擇單號.Location = New System.Drawing.Point(3, 65)
        Me.T2選擇單號.MultiSelect = False
        Me.T2選擇單號.Name = "T2選擇單號"
        Me.T2選擇單號.ReadOnly = True
        Me.T2選擇單號.RowHeadersVisible = False
        Me.T2選擇單號.RowTemplate.Height = 24
        Me.T2選擇單號.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T2選擇單號.Size = New System.Drawing.Size(1161, 200)
        Me.T2選擇單號.TabIndex = 1021
        '
        'Tp退貨輸入
        '
        Me.Tp退貨輸入.Controls.Add(Me.Lt3名稱)
        Me.Tp退貨輸入.Controls.Add(Me.Label30)
        Me.Tp退貨輸入.Controls.Add(Me.Bu3數量)
        Me.Tp退貨輸入.Controls.Add(Me.Cb3運輸司機)
        Me.Tp退貨輸入.Controls.Add(Me.Label17)
        Me.Tp退貨輸入.Controls.Add(Me.Cb3Key單人員)
        Me.Tp退貨輸入.Controls.Add(Me.Label14)
        Me.Tp退貨輸入.Controls.Add(Me.De3退貨)
        Me.Tp退貨輸入.Controls.Add(Me.Label16)
        Me.Tp退貨輸入.Controls.Add(Me.Cb3退貨原因)
        Me.Tp退貨輸入.Controls.Add(Me.Label15)
        Me.Tp退貨輸入.Controls.Add(Me.Tb3備註)
        Me.Tp退貨輸入.Controls.Add(Me.Bu3放棄)
        Me.Tp退貨輸入.Controls.Add(Me.Bu3存檔)
        Me.Tp退貨輸入.Controls.Add(Me.Cb3處理方式)
        Me.Tp退貨輸入.Controls.Add(Me.Label13)
        Me.Tp退貨輸入.Controls.Add(Me.Bu3刪除)
        Me.Tp退貨輸入.Controls.Add(Me.Bu3新增)
        Me.Tp退貨輸入.Controls.Add(Me.De3輸入)
        Me.Tp退貨輸入.Controls.Add(Me.Label12)
        Me.Tp退貨輸入.Controls.Add(Me.Tb3總計)
        Me.Tp退貨輸入.Controls.Add(Me.Tb3稅額)
        Me.Tp退貨輸入.Controls.Add(Me.Label10)
        Me.Tp退貨輸入.Controls.Add(Me.Label11)
        Me.Tp退貨輸入.Controls.Add(Me.Cb3責任單位)
        Me.Tp退貨輸入.Controls.Add(Me.Cb3折退類別)
        Me.Tp退貨輸入.Controls.Add(Me.Label3)
        Me.Tp退貨輸入.Controls.Add(Me.T3退貨明細)
        Me.Tp退貨輸入.Controls.Add(Me.Label8)
        Me.Tp退貨輸入.Controls.Add(Me.T3單號明細)
        Me.Tp退貨輸入.Location = New System.Drawing.Point(4, 4)
        Me.Tp退貨輸入.Name = "Tp退貨輸入"
        Me.Tp退貨輸入.Size = New System.Drawing.Size(1170, 572)
        Me.Tp退貨輸入.TabIndex = 2
        Me.Tp退貨輸入.Text = "退貨輸入"
        Me.Tp退貨輸入.UseVisualStyleBackColor = True
        '
        'Lt3名稱
        '
        Me.Lt3名稱.AutoSize = True
        Me.Lt3名稱.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt3名稱.Location = New System.Drawing.Point(782, 68)
        Me.Lt3名稱.Name = "Lt3名稱"
        Me.Lt3名稱.Size = New System.Drawing.Size(42, 16)
        Me.Lt3名稱.TabIndex = 1048
        Me.Lt3名稱.Text = "名稱"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label30.Location = New System.Drawing.Point(697, 68)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(93, 16)
        Me.Label30.TabIndex = 1047
        Me.Label30.Text = "存編名稱："
        '
        'Bu3數量
        '
        Me.Bu3數量.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu3數量.Location = New System.Drawing.Point(979, 93)
        Me.Bu3數量.Name = "Bu3數量"
        Me.Bu3數量.Size = New System.Drawing.Size(84, 37)
        Me.Bu3數量.TabIndex = 1043
        Me.Bu3數量.Text = "數量"
        Me.Bu3數量.UseVisualStyleBackColor = True
        '
        'Cb3運輸司機
        '
        Me.Cb3運輸司機.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3運輸司機.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb3運輸司機.FormattingEnabled = True
        Me.Cb3運輸司機.Location = New System.Drawing.Point(433, 31)
        Me.Cb3運輸司機.Name = "Cb3運輸司機"
        Me.Cb3運輸司機.Size = New System.Drawing.Size(261, 27)
        Me.Cb3運輸司機.TabIndex = 1041
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(347, 35)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 16)
        Me.Label17.TabIndex = 1042
        Me.Label17.Text = "運輸司機："
        '
        'Cb3Key單人員
        '
        Me.Cb3Key單人員.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3Key單人員.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb3Key單人員.FormattingEnabled = True
        Me.Cb3Key單人員.Location = New System.Drawing.Point(782, 31)
        Me.Cb3Key單人員.Name = "Cb3Key單人員"
        Me.Cb3Key單人員.Size = New System.Drawing.Size(131, 27)
        Me.Cb3Key單人員.TabIndex = 1020
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(701, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 1021
        Me.Label14.Text = "Key單者："
        '
        'De3退貨
        '
        Me.De3退貨.CustomFormat = "yyyy/MM/dd"
        Me.De3退貨.Location = New System.Drawing.Point(656, 3)
        Me.De3退貨.Name = "De3退貨"
        Me.De3退貨.Size = New System.Drawing.Size(133, 27)
        Me.De3退貨.TabIndex = 1039
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(571, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 16)
        Me.Label16.TabIndex = 1040
        Me.Label16.Text = "退貨日期："
        '
        'Cb3退貨原因
        '
        Me.Cb3退貨原因.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3退貨原因.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb3退貨原因.FormattingEnabled = True
        Me.Cb3退貨原因.Location = New System.Drawing.Point(433, 62)
        Me.Cb3退貨原因.Name = "Cb3退貨原因"
        Me.Cb3退貨原因.Size = New System.Drawing.Size(261, 27)
        Me.Cb3退貨原因.TabIndex = 1038
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(347, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 16)
        Me.Label15.TabIndex = 1037
        Me.Label15.Text = "退貨原因："
        '
        'Tb3備註
        '
        Me.Tb3備註.BackColor = System.Drawing.Color.White
        Me.Tb3備註.Location = New System.Drawing.Point(979, 143)
        Me.Tb3備註.Multiline = True
        Me.Tb3備註.Name = "Tb3備註"
        Me.Tb3備註.Size = New System.Drawing.Size(188, 246)
        Me.Tb3備註.TabIndex = 1020
        Me.Tb3備註.TabStop = False
        '
        'Bu3放棄
        '
        Me.Bu3放棄.BackColor = System.Drawing.Color.Red
        Me.Bu3放棄.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu3放棄.Location = New System.Drawing.Point(1084, 532)
        Me.Bu3放棄.Name = "Bu3放棄"
        Me.Bu3放棄.Size = New System.Drawing.Size(84, 37)
        Me.Bu3放棄.TabIndex = 1027
        Me.Bu3放棄.Text = "放棄"
        Me.Bu3放棄.UseVisualStyleBackColor = False
        '
        'Bu3存檔
        '
        Me.Bu3存檔.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu3存檔.Location = New System.Drawing.Point(979, 532)
        Me.Bu3存檔.Name = "Bu3存檔"
        Me.Bu3存檔.Size = New System.Drawing.Size(84, 37)
        Me.Bu3存檔.TabIndex = 1024
        Me.Bu3存檔.Text = "存檔"
        Me.Bu3存檔.UseVisualStyleBackColor = True
        '
        'Cb3處理方式
        '
        Me.Cb3處理方式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3處理方式.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb3處理方式.FormattingEnabled = True
        Me.Cb3處理方式.Items.AddRange(New Object() {"", "轉生產領改", "轉員工餐廳", "轉開心店", "轉作廢"})
        Me.Cb3處理方式.Location = New System.Drawing.Point(188, 33)
        Me.Cb3處理方式.Name = "Cb3處理方式"
        Me.Cb3處理方式.Size = New System.Drawing.Size(153, 27)
        Me.Cb3處理方式.TabIndex = 1036
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(102, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 16)
        Me.Label13.TabIndex = 1035
        Me.Label13.Text = "處理方式："
        '
        'Bu3刪除
        '
        Me.Bu3刪除.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu3刪除.Location = New System.Drawing.Point(3, 59)
        Me.Bu3刪除.Name = "Bu3刪除"
        Me.Bu3刪除.Size = New System.Drawing.Size(84, 30)
        Me.Bu3刪除.TabIndex = 1034
        Me.Bu3刪除.Text = "刪除"
        Me.Bu3刪除.UseVisualStyleBackColor = True
        '
        'Bu3新增
        '
        Me.Bu3新增.Font = New System.Drawing.Font("新細明體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu3新增.Location = New System.Drawing.Point(4, 373)
        Me.Bu3新增.Name = "Bu3新增"
        Me.Bu3新增.Size = New System.Drawing.Size(84, 30)
        Me.Bu3新增.TabIndex = 1033
        Me.Bu3新增.Text = "新增"
        Me.Bu3新增.UseVisualStyleBackColor = True
        '
        'De3輸入
        '
        Me.De3輸入.CustomFormat = "yyyy/MM/dd"
        Me.De3輸入.Location = New System.Drawing.Point(432, 1)
        Me.De3輸入.Name = "De3輸入"
        Me.De3輸入.Size = New System.Drawing.Size(133, 27)
        Me.De3輸入.TabIndex = 1025
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(347, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 16)
        Me.Label12.TabIndex = 1026
        Me.Label12.Text = "輸入日期："
        '
        'Tb3總計
        '
        Me.Tb3總計.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tb3總計.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb3總計.Location = New System.Drawing.Point(1034, 4)
        Me.Tb3總計.Name = "Tb3總計"
        Me.Tb3總計.ReadOnly = True
        Me.Tb3總計.Size = New System.Drawing.Size(130, 27)
        Me.Tb3總計.TabIndex = 1026
        Me.Tb3總計.TabStop = False
        Me.Tb3總計.Text = "0"
        Me.Tb3總計.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Tb3稅額
        '
        Me.Tb3稅額.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Tb3稅額.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tb3稅額.Location = New System.Drawing.Point(1034, 34)
        Me.Tb3稅額.Name = "Tb3稅額"
        Me.Tb3稅額.ReadOnly = True
        Me.Tb3稅額.Size = New System.Drawing.Size(130, 27)
        Me.Tb3稅額.TabIndex = 1020
        Me.Tb3稅額.TabStop = False
        Me.Tb3稅額.Text = "0"
        Me.Tb3稅額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(984, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 16)
        Me.Label10.TabIndex = 1025
        Me.Label10.Text = "總計："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(984, 38)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 16)
        Me.Label11.TabIndex = 1024
        Me.Label11.Text = "稅額："
        '
        'Cb3責任單位
        '
        Me.Cb3責任單位.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3責任單位.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb3責任單位.FormattingEnabled = True
        Me.Cb3責任單位.Items.AddRange(New Object() {"營業", "生產", "倉儲", "其他", "營業+生產", "營業+倉儲", "生產+倉儲", "營業+生產+倉儲"})
        Me.Cb3責任單位.Location = New System.Drawing.Point(188, 62)
        Me.Cb3責任單位.Name = "Cb3責任單位"
        Me.Cb3責任單位.Size = New System.Drawing.Size(153, 27)
        Me.Cb3責任單位.TabIndex = 1022
        '
        'Cb3折退類別
        '
        Me.Cb3折退類別.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb3折退類別.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Cb3折退類別.FormattingEnabled = True
        Me.Cb3折退類別.Items.AddRange(New Object() {"折讓", "退貨"})
        Me.Cb3折退類別.Location = New System.Drawing.Point(188, 4)
        Me.Cb3折退類別.Name = "Cb3折退類別"
        Me.Cb3折退類別.Size = New System.Drawing.Size(153, 27)
        Me.Cb3折退類別.TabIndex = 1020
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(102, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 1021
        Me.Label3.Text = "責任單位："
        '
        'T3退貨明細
        '
        Me.T3退貨明細.AllowUserToAddRows = False
        Me.T3退貨明細.AllowUserToDeleteRows = False
        Me.T3退貨明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T3退貨明細.Location = New System.Drawing.Point(3, 93)
        Me.T3退貨明細.MultiSelect = False
        Me.T3退貨明細.Name = "T3退貨明細"
        Me.T3退貨明細.RowHeadersVisible = False
        Me.T3退貨明細.RowTemplate.Height = 24
        Me.T3退貨明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T3退貨明細.Size = New System.Drawing.Size(970, 274)
        Me.T3退貨明細.TabIndex = 1022
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(102, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 16)
        Me.Label8.TabIndex = 1019
        Me.Label8.Text = "選擇類別："
        '
        'T3單號明細
        '
        Me.T3單號明細.AllowUserToAddRows = False
        Me.T3單號明細.AllowUserToDeleteRows = False
        Me.T3單號明細.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T3單號明細.Location = New System.Drawing.Point(94, 369)
        Me.T3單號明細.MultiSelect = False
        Me.T3單號明細.Name = "T3單號明細"
        Me.T3單號明細.RowHeadersVisible = False
        Me.T3單號明細.RowTemplate.Height = 24
        Me.T3單號明細.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T3單號明細.Size = New System.Drawing.Size(879, 200)
        Me.T3單號明細.TabIndex = 1022
        '
        'Tp退貨數量
        '
        Me.Tp退貨數量.Controls.Add(Me.Lt4合計2)
        Me.Tp退貨數量.Controls.Add(Me.Label39)
        Me.Tp退貨數量.Controls.Add(Me.Lt4合計1)
        Me.Tp退貨數量.Controls.Add(Me.Label38)
        Me.Tp退貨數量.Controls.Add(Me.T4Lt1說明)
        Me.Tp退貨數量.Controls.Add(Me.Label36)
        Me.Tp退貨數量.Controls.Add(Me.T4Cb2情況)
        Me.Tp退貨數量.Controls.Add(Me.Label35)
        Me.Tp退貨數量.Controls.Add(Me.T4Cb2結果)
        Me.Tp退貨數量.Controls.Add(Me.Label34)
        Me.Tp退貨數量.Controls.Add(Me.T4Cb2原因)
        Me.Tp退貨數量.Controls.Add(Me.T4Cb2相符)
        Me.Tp退貨數量.Controls.Add(Me.Label32)
        Me.Tp退貨數量.Controls.Add(Me.Label33)
        Me.Tp退貨數量.Controls.Add(Me.Lt42數量)
        Me.Tp退貨數量.Controls.Add(Me.Label27)
        Me.Tp退貨數量.Controls.Add(Me.Lt4ID)
        Me.Tp退貨數量.Controls.Add(Me.Label29)
        Me.Tp退貨數量.Controls.Add(Me.Lt4列號)
        Me.Tp退貨數量.Controls.Add(Me.Label28)
        Me.Tp退貨數量.Controls.Add(Me.Lt4合計)
        Me.Tp退貨數量.Controls.Add(Me.Label25)
        Me.Tp退貨數量.Controls.Add(Me.Bu4移除)
        Me.Tp退貨數量.Controls.Add(Me.Bu4放棄)
        Me.Tp退貨數量.Controls.Add(Me.Lt4可退)
        Me.Tp退貨數量.Controls.Add(Me.Label26)
        Me.Tp退貨數量.Controls.Add(Me.Bu4輸入)
        Me.Tp退貨數量.Controls.Add(Me.Lt4名稱)
        Me.Tp退貨數量.Controls.Add(Me.Lt4存編)
        Me.Tp退貨數量.Controls.Add(Me.Bu4存檔)
        Me.Tp退貨數量.Controls.Add(Me.Label24)
        Me.Tp退貨數量.Controls.Add(Me.T4Cb1原因)
        Me.Tp退貨數量.Controls.Add(Me.T4Cb1類別)
        Me.Tp退貨數量.Controls.Add(Me.T4Lt2說明)
        Me.Tp退貨數量.Controls.Add(Me.Lt4數量)
        Me.Tp退貨數量.Controls.Add(Me.Label21)
        Me.Tp退貨數量.Controls.Add(Me.Label22)
        Me.Tp退貨數量.Controls.Add(Me.Label23)
        Me.Tp退貨數量.Controls.Add(Me.Label18)
        Me.Tp退貨數量.Controls.Add(Me.T4退貨記錄)
        Me.Tp退貨數量.Controls.Add(Me.Label19)
        Me.Tp退貨數量.Controls.Add(Me.T4輸入資料)
        Me.Tp退貨數量.Controls.Add(Me.Label20)
        Me.Tp退貨數量.Location = New System.Drawing.Point(4, 4)
        Me.Tp退貨數量.Name = "Tp退貨數量"
        Me.Tp退貨數量.Size = New System.Drawing.Size(1170, 572)
        Me.Tp退貨數量.TabIndex = 3
        Me.Tp退貨數量.Text = "退貨數量"
        Me.Tp退貨數量.UseVisualStyleBackColor = True
        '
        'Lt4合計2
        '
        Me.Lt4合計2.AutoSize = True
        Me.Lt4合計2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4合計2.ForeColor = System.Drawing.Color.Black
        Me.Lt4合計2.Location = New System.Drawing.Point(87, 158)
        Me.Lt4合計2.Name = "Lt4合計2"
        Me.Lt4合計2.Size = New System.Drawing.Size(42, 16)
        Me.Lt4合計2.TabIndex = 1071
        Me.Lt4合計2.Text = "合計"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(4, 158)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(93, 16)
        Me.Label39.TabIndex = 1070
        Me.Label39.Text = "退貨總量："
        '
        'Lt4合計1
        '
        Me.Lt4合計1.AutoSize = True
        Me.Lt4合計1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4合計1.ForeColor = System.Drawing.Color.Red
        Me.Lt4合計1.Location = New System.Drawing.Point(742, 158)
        Me.Lt4合計1.Name = "Lt4合計1"
        Me.Lt4合計1.Size = New System.Drawing.Size(42, 16)
        Me.Lt4合計1.TabIndex = 1069
        Me.Lt4合計1.Text = "合計"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Red
        Me.Label38.Location = New System.Drawing.Point(659, 158)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(93, 16)
        Me.Label38.TabIndex = 1068
        Me.Label38.Text = "輸入總量："
        '
        'T4Lt1說明
        '
        Me.T4Lt1說明.BackColor = System.Drawing.Color.White
        Me.T4Lt1說明.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Lt1說明.Location = New System.Drawing.Point(251, 36)
        Me.T4Lt1說明.Multiline = True
        Me.T4Lt1說明.Name = "T4Lt1說明"
        Me.T4Lt1說明.ReadOnly = True
        Me.T4Lt1說明.Size = New System.Drawing.Size(155, 135)
        Me.T4Lt1說明.TabIndex = 1067
        Me.T4Lt1說明.TabStop = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(164, 134)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(93, 16)
        Me.Label36.TabIndex = 1066
        Me.Label36.Text = "補充說明："
        '
        'T4Cb2情況
        '
        Me.T4Cb2情況.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T4Cb2情況.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Cb2情況.FormattingEnabled = True
        Me.T4Cb2情況.Location = New System.Drawing.Point(500, 97)
        Me.T4Cb2情況.Name = "T4Cb2情況"
        Me.T4Cb2情況.Size = New System.Drawing.Size(153, 27)
        Me.T4Cb2情況.TabIndex = 1064
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Red
        Me.Label35.Location = New System.Drawing.Point(412, 102)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(93, 16)
        Me.Label35.TabIndex = 1065
        Me.Label35.Text = "退貨情況："
        '
        'T4Cb2結果
        '
        Me.T4Cb2結果.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T4Cb2結果.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Cb2結果.FormattingEnabled = True
        Me.T4Cb2結果.Location = New System.Drawing.Point(500, 129)
        Me.T4Cb2結果.Name = "T4Cb2結果"
        Me.T4Cb2結果.Size = New System.Drawing.Size(153, 27)
        Me.T4Cb2結果.TabIndex = 1062
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(412, 134)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(93, 16)
        Me.Label34.TabIndex = 1063
        Me.Label34.Text = "確認結果："
        '
        'T4Cb2原因
        '
        Me.T4Cb2原因.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T4Cb2原因.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Cb2原因.FormattingEnabled = True
        Me.T4Cb2原因.Location = New System.Drawing.Point(500, 66)
        Me.T4Cb2原因.Name = "T4Cb2原因"
        Me.T4Cb2原因.Size = New System.Drawing.Size(153, 27)
        Me.T4Cb2原因.TabIndex = 1059
        '
        'T4Cb2相符
        '
        Me.T4Cb2相符.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T4Cb2相符.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Cb2相符.FormattingEnabled = True
        Me.T4Cb2相符.Location = New System.Drawing.Point(500, 36)
        Me.T4Cb2相符.Name = "T4Cb2相符"
        Me.T4Cb2相符.Size = New System.Drawing.Size(153, 27)
        Me.T4Cb2相符.TabIndex = 1058
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(412, 71)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 16)
        Me.Label32.TabIndex = 1061
        Me.Label32.Text = "確認原因："
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.White
        Me.Label33.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Red
        Me.Label33.Location = New System.Drawing.Point(412, 41)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 16)
        Me.Label33.TabIndex = 1060
        Me.Label33.Text = "相符原因："
        '
        'Lt42數量
        '
        Me.Lt42數量.BackColor = System.Drawing.Color.White
        Me.Lt42數量.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt42數量.Location = New System.Drawing.Point(658, 95)
        Me.Lt42數量.Name = "Lt42數量"
        Me.Lt42數量.Size = New System.Drawing.Size(94, 30)
        Me.Lt42數量.TabIndex = 1056
        Me.Lt42數量.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(659, 73)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(93, 16)
        Me.Label27.TabIndex = 1057
        Me.Label27.Text = "退貨數量："
        '
        'Lt4ID
        '
        Me.Lt4ID.AutoSize = True
        Me.Lt4ID.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4ID.Location = New System.Drawing.Point(89, 135)
        Me.Lt4ID.Name = "Lt4ID"
        Me.Lt4ID.Size = New System.Drawing.Size(26, 16)
        Me.Lt4ID.TabIndex = 1054
        Me.Lt4ID.Text = "ID"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label29.Location = New System.Drawing.Point(1, 135)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(97, 16)
        Me.Label29.TabIndex = 1053
        Me.Label29.Text = " ID 編  號："
        '
        'Lt4列號
        '
        Me.Lt4列號.AutoSize = True
        Me.Lt4列號.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4列號.Location = New System.Drawing.Point(1117, 10)
        Me.Lt4列號.Name = "Lt4列號"
        Me.Lt4列號.Size = New System.Drawing.Size(42, 16)
        Me.Lt4列號.TabIndex = 1052
        Me.Lt4列號.Text = "列號"
        Me.Lt4列號.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label28.Location = New System.Drawing.Point(1032, 10)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(94, 16)
        Me.Label28.TabIndex = 1051
        Me.Label28.Text = "列       號："
        Me.Label28.Visible = False
        '
        'Lt4合計
        '
        Me.Lt4合計.AutoSize = True
        Me.Lt4合計.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4合計.ForeColor = System.Drawing.Color.Red
        Me.Lt4合計.Location = New System.Drawing.Point(742, 135)
        Me.Lt4合計.Name = "Lt4合計"
        Me.Lt4合計.Size = New System.Drawing.Size(42, 16)
        Me.Lt4合計.TabIndex = 1047
        Me.Lt4合計.Text = "合計"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(659, 135)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(93, 16)
        Me.Label25.TabIndex = 1044
        Me.Label25.Text = "合計數量："
        '
        'Bu4移除
        '
        Me.Bu4移除.BackColor = System.Drawing.Color.White
        Me.Bu4移除.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu4移除.ForeColor = System.Drawing.Color.Red
        Me.Bu4移除.Location = New System.Drawing.Point(451, 532)
        Me.Bu4移除.Name = "Bu4移除"
        Me.Bu4移除.Size = New System.Drawing.Size(84, 37)
        Me.Bu4移除.TabIndex = 1055
        Me.Bu4移除.Text = "移除"
        Me.Bu4移除.UseVisualStyleBackColor = False
        '
        'Bu4放棄
        '
        Me.Bu4放棄.BackColor = System.Drawing.Color.Red
        Me.Bu4放棄.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu4放棄.Location = New System.Drawing.Point(1084, 532)
        Me.Bu4放棄.Name = "Bu4放棄"
        Me.Bu4放棄.Size = New System.Drawing.Size(84, 37)
        Me.Bu4放棄.TabIndex = 1028
        Me.Bu4放棄.Text = "放棄"
        Me.Bu4放棄.UseVisualStyleBackColor = False
        '
        'Lt4可退
        '
        Me.Lt4可退.AutoSize = True
        Me.Lt4可退.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4可退.Location = New System.Drawing.Point(276, 98)
        Me.Lt4可退.Name = "Lt4可退"
        Me.Lt4可退.Size = New System.Drawing.Size(42, 16)
        Me.Lt4可退.TabIndex = 1049
        Me.Lt4可退.Text = "可退"
        Me.Lt4可退.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label26.Location = New System.Drawing.Point(193, 98)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 16)
        Me.Label26.TabIndex = 1050
        Me.Label26.Text = "可退數量："
        Me.Label26.Visible = False
        '
        'Bu4輸入
        '
        Me.Bu4輸入.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu4輸入.Location = New System.Drawing.Point(758, 90)
        Me.Bu4輸入.Name = "Bu4輸入"
        Me.Bu4輸入.Size = New System.Drawing.Size(84, 37)
        Me.Bu4輸入.TabIndex = 1048
        Me.Bu4輸入.Text = "輸入"
        Me.Bu4輸入.UseVisualStyleBackColor = True
        '
        'Lt4名稱
        '
        Me.Lt4名稱.AutoSize = True
        Me.Lt4名稱.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4名稱.Location = New System.Drawing.Point(345, 10)
        Me.Lt4名稱.Name = "Lt4名稱"
        Me.Lt4名稱.Size = New System.Drawing.Size(42, 16)
        Me.Lt4名稱.TabIndex = 1046
        Me.Lt4名稱.Text = "名稱"
        '
        'Lt4存編
        '
        Me.Lt4存編.AutoSize = True
        Me.Lt4存編.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4存編.Location = New System.Drawing.Point(94, 10)
        Me.Lt4存編.Name = "Lt4存編"
        Me.Lt4存編.Size = New System.Drawing.Size(42, 16)
        Me.Lt4存編.TabIndex = 1045
        Me.Lt4存編.Text = "存編"
        '
        'Bu4存檔
        '
        Me.Bu4存檔.Font = New System.Drawing.Font("新細明體", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Bu4存檔.Location = New System.Drawing.Point(917, 532)
        Me.Bu4存檔.Name = "Bu4存檔"
        Me.Bu4存檔.Size = New System.Drawing.Size(84, 37)
        Me.Bu4存檔.TabIndex = 1044
        Me.Bu4存檔.Text = "存檔"
        Me.Bu4存檔.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label24.Location = New System.Drawing.Point(177, 73)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 16)
        Me.Label24.TabIndex = 1043
        '
        'T4Cb1原因
        '
        Me.T4Cb1原因.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T4Cb1原因.Enabled = False
        Me.T4Cb1原因.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Cb1原因.FormattingEnabled = True
        Me.T4Cb1原因.Location = New System.Drawing.Point(92, 66)
        Me.T4Cb1原因.Name = "T4Cb1原因"
        Me.T4Cb1原因.Size = New System.Drawing.Size(153, 27)
        Me.T4Cb1原因.TabIndex = 1023
        '
        'T4Cb1類別
        '
        Me.T4Cb1類別.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.T4Cb1類別.Enabled = False
        Me.T4Cb1類別.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Cb1類別.FormattingEnabled = True
        Me.T4Cb1類別.Location = New System.Drawing.Point(92, 36)
        Me.T4Cb1類別.Name = "T4Cb1類別"
        Me.T4Cb1類別.Size = New System.Drawing.Size(153, 27)
        Me.T4Cb1類別.TabIndex = 1023
        '
        'T4Lt2說明
        '
        Me.T4Lt2說明.BackColor = System.Drawing.Color.White
        Me.T4Lt2說明.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.T4Lt2說明.Location = New System.Drawing.Point(860, 36)
        Me.T4Lt2說明.Multiline = True
        Me.T4Lt2說明.Name = "T4Lt2說明"
        Me.T4Lt2說明.Size = New System.Drawing.Size(299, 135)
        Me.T4Lt2說明.TabIndex = 1042
        Me.T4Lt2說明.TabStop = False
        '
        'Lt4數量
        '
        Me.Lt4數量.BackColor = System.Drawing.Color.White
        Me.Lt4數量.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt4數量.Location = New System.Drawing.Point(93, 98)
        Me.Lt4數量.Name = "Lt4數量"
        Me.Lt4數量.ReadOnly = True
        Me.Lt4數量.Size = New System.Drawing.Size(94, 30)
        Me.Lt4數量.TabIndex = 1020
        Me.Lt4數量.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(4, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(93, 16)
        Me.Label21.TabIndex = 1041
        Me.Label21.Text = "退貨原因："
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(749, 41)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 16)
        Me.Label22.TabIndex = 1040
        Me.Label22.Text = "補充說明："
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.White
        Me.Label23.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 41)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(94, 16)
        Me.Label23.TabIndex = 1039
        Me.Label23.Text = "類       別："
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(260, 10)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(93, 16)
        Me.Label18.TabIndex = 1038
        Me.Label18.Text = "存編名稱："
        '
        'T4退貨記錄
        '
        Me.T4退貨記錄.AllowUserToAddRows = False
        Me.T4退貨記錄.AllowUserToDeleteRows = False
        Me.T4退貨記錄.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T4退貨記錄.Location = New System.Drawing.Point(451, 177)
        Me.T4退貨記錄.MultiSelect = False
        Me.T4退貨記錄.Name = "T4退貨記錄"
        Me.T4退貨記錄.RowHeadersVisible = False
        Me.T4退貨記錄.RowTemplate.Height = 24
        Me.T4退貨記錄.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T4退貨記錄.Size = New System.Drawing.Size(708, 353)
        Me.T4退貨記錄.TabIndex = 1023
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(5, 103)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 16)
        Me.Label19.TabIndex = 1037
        Me.Label19.Text = "退貨數量："
        '
        'T4輸入資料
        '
        Me.T4輸入資料.AllowUserToAddRows = False
        Me.T4輸入資料.AllowUserToDeleteRows = False
        Me.T4輸入資料.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T4輸入資料.Location = New System.Drawing.Point(0, 177)
        Me.T4輸入資料.MultiSelect = False
        Me.T4輸入資料.Name = "T4輸入資料"
        Me.T4輸入資料.RowHeadersVisible = False
        Me.T4輸入資料.RowTemplate.Height = 24
        Me.T4輸入資料.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.T4輸入資料.Size = New System.Drawing.Size(445, 392)
        Me.T4輸入資料.TabIndex = 1023
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 16)
        Me.Label20.TabIndex = 1036
        Me.Label20.Text = "存貨編號："
        '
        'Lt總計
        '
        Me.Lt總計.AutoSize = True
        Me.Lt總計.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt總計.Location = New System.Drawing.Point(62, 273)
        Me.Lt總計.Name = "Lt總計"
        Me.Lt總計.Size = New System.Drawing.Size(29, 12)
        Me.Lt總計.TabIndex = 1023
        Me.Lt總計.Text = "總計"
        '
        'Lt稅額
        '
        Me.Lt稅額.AutoSize = True
        Me.Lt稅額.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt稅額.Location = New System.Drawing.Point(6, 273)
        Me.Lt稅額.Name = "Lt稅額"
        Me.Lt稅額.Size = New System.Drawing.Size(29, 12)
        Me.Lt稅額.TabIndex = 1022
        Me.Lt稅額.Text = "稅額"
        '
        'Gb表頭資料
        '
        Me.Gb表頭資料.Controls.Add(Me.Lt運輸司機)
        Me.Gb表頭資料.Controls.Add(Me.Lt司機代碼)
        Me.Gb表頭資料.Controls.Add(Me.Lt退貨日期)
        Me.Gb表頭資料.Controls.Add(Me.Lt退貨原因)
        Me.Gb表頭資料.Controls.Add(Me.Lt退貨代碼)
        Me.Gb表頭資料.Controls.Add(Me.Lt處理方式)
        Me.Gb表頭資料.Controls.Add(Me.Lt類別)
        Me.Gb表頭資料.Controls.Add(Me.Lt來源)
        Me.Gb表頭資料.Controls.Add(Me.Lt輸入者)
        Me.Gb表頭資料.Controls.Add(Me.Lt總計)
        Me.Gb表頭資料.Controls.Add(Me.Lt傳真)
        Me.Gb表頭資料.Controls.Add(Me.Lt電話)
        Me.Gb表頭資料.Controls.Add(Me.Lt備註2)
        Me.Gb表頭資料.Controls.Add(Me.Lt稅額)
        Me.Gb表頭資料.Controls.Add(Me.Lt備註1)
        Me.Gb表頭資料.Controls.Add(Me.Lt聯絡人)
        Me.Gb表頭資料.Controls.Add(Me.Lt過帳日期)
        Me.Gb表頭資料.Controls.Add(Me.Lt責任單位)
        Me.Gb表頭資料.Controls.Add(Me.Lt文件單號)
        Me.Gb表頭資料.Controls.Add(Me.Lt發票日期)
        Me.Gb表頭資料.Controls.Add(Me.Lt發票號碼)
        Me.Gb表頭資料.Controls.Add(Me.Lt地址)
        Me.Gb表頭資料.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Gb表頭資料.Location = New System.Drawing.Point(733, 271)
        Me.Gb表頭資料.Name = "Gb表頭資料"
        Me.Gb表頭資料.Size = New System.Drawing.Size(193, 288)
        Me.Gb表頭資料.TabIndex = 1019
        Me.Gb表頭資料.TabStop = False
        Me.Gb表頭資料.Text = "表頭資料"
        Me.Gb表頭資料.Visible = False
        '
        'Lt運輸司機
        '
        Me.Lt運輸司機.AutoSize = True
        Me.Lt運輸司機.Location = New System.Drawing.Point(62, 160)
        Me.Lt運輸司機.Name = "Lt運輸司機"
        Me.Lt運輸司機.Size = New System.Drawing.Size(53, 12)
        Me.Lt運輸司機.TabIndex = 1030
        Me.Lt運輸司機.Text = "運輸司機"
        '
        'Lt司機代碼
        '
        Me.Lt司機代碼.AutoSize = True
        Me.Lt司機代碼.Location = New System.Drawing.Point(6, 160)
        Me.Lt司機代碼.Name = "Lt司機代碼"
        Me.Lt司機代碼.Size = New System.Drawing.Size(53, 12)
        Me.Lt司機代碼.TabIndex = 1029
        Me.Lt司機代碼.Text = "司機代碼"
        '
        'Lt退貨日期
        '
        Me.Lt退貨日期.AutoSize = True
        Me.Lt退貨日期.Location = New System.Drawing.Point(77, 32)
        Me.Lt退貨日期.Name = "Lt退貨日期"
        Me.Lt退貨日期.Size = New System.Drawing.Size(53, 12)
        Me.Lt退貨日期.TabIndex = 1028
        Me.Lt退貨日期.Text = "退貨日期"
        '
        'Lt退貨原因
        '
        Me.Lt退貨原因.AutoSize = True
        Me.Lt退貨原因.Location = New System.Drawing.Point(62, 148)
        Me.Lt退貨原因.Name = "Lt退貨原因"
        Me.Lt退貨原因.Size = New System.Drawing.Size(53, 12)
        Me.Lt退貨原因.TabIndex = 1027
        Me.Lt退貨原因.Text = "退貨原因"
        '
        'Lt退貨代碼
        '
        Me.Lt退貨代碼.AutoSize = True
        Me.Lt退貨代碼.Location = New System.Drawing.Point(6, 148)
        Me.Lt退貨代碼.Name = "Lt退貨代碼"
        Me.Lt退貨代碼.Size = New System.Drawing.Size(53, 12)
        Me.Lt退貨代碼.TabIndex = 1026
        Me.Lt退貨代碼.Text = "退貨代碼"
        '
        'Lt處理方式
        '
        Me.Lt處理方式.AutoSize = True
        Me.Lt處理方式.Location = New System.Drawing.Point(6, 200)
        Me.Lt處理方式.Name = "Lt處理方式"
        Me.Lt處理方式.Size = New System.Drawing.Size(53, 12)
        Me.Lt處理方式.TabIndex = 1025
        Me.Lt處理方式.Text = "處理方式"
        '
        'Lt類別
        '
        Me.Lt類別.AutoSize = True
        Me.Lt類別.Location = New System.Drawing.Point(62, 261)
        Me.Lt類別.Name = "Lt類別"
        Me.Lt類別.Size = New System.Drawing.Size(29, 12)
        Me.Lt類別.TabIndex = 1024
        Me.Lt類別.Text = "類別"
        '
        'Lt來源
        '
        Me.Lt來源.AutoSize = True
        Me.Lt來源.Location = New System.Drawing.Point(6, 261)
        Me.Lt來源.Name = "Lt來源"
        Me.Lt來源.Size = New System.Drawing.Size(29, 12)
        Me.Lt來源.TabIndex = 12
        Me.Lt來源.Text = "來源"
        '
        'Lt輸入者
        '
        Me.Lt輸入者.AutoSize = True
        Me.Lt輸入者.Location = New System.Drawing.Point(129, 260)
        Me.Lt輸入者.Name = "Lt輸入者"
        Me.Lt輸入者.Size = New System.Drawing.Size(41, 12)
        Me.Lt輸入者.TabIndex = 11
        Me.Lt輸入者.Text = "輸入者"
        '
        'Lt傳真
        '
        Me.Lt傳真.AutoSize = True
        Me.Lt傳真.Location = New System.Drawing.Point(6, 128)
        Me.Lt傳真.Name = "Lt傳真"
        Me.Lt傳真.Size = New System.Drawing.Size(29, 12)
        Me.Lt傳真.TabIndex = 10
        Me.Lt傳真.Text = "傳真"
        '
        'Lt電話
        '
        Me.Lt電話.AutoSize = True
        Me.Lt電話.Location = New System.Drawing.Point(6, 116)
        Me.Lt電話.Name = "Lt電話"
        Me.Lt電話.Size = New System.Drawing.Size(29, 12)
        Me.Lt電話.TabIndex = 9
        Me.Lt電話.Text = "電話"
        '
        'Lt備註2
        '
        Me.Lt備註2.AutoSize = True
        Me.Lt備註2.Location = New System.Drawing.Point(6, 224)
        Me.Lt備註2.Name = "Lt備註2"
        Me.Lt備註2.Size = New System.Drawing.Size(83, 12)
        Me.Lt備註2.TabIndex = 8
        Me.Lt備註2.Text = "備註_退貨說明"
        '
        'Lt備註1
        '
        Me.Lt備註1.AutoSize = True
        Me.Lt備註1.Location = New System.Drawing.Point(6, 212)
        Me.Lt備註1.Name = "Lt備註1"
        Me.Lt備註1.Size = New System.Drawing.Size(75, 12)
        Me.Lt備註1.TabIndex = 7
        Me.Lt備註1.Text = "備註_AR發票"
        '
        'Lt聯絡人
        '
        Me.Lt聯絡人.AutoSize = True
        Me.Lt聯絡人.Location = New System.Drawing.Point(6, 104)
        Me.Lt聯絡人.Name = "Lt聯絡人"
        Me.Lt聯絡人.Size = New System.Drawing.Size(41, 12)
        Me.Lt聯絡人.TabIndex = 6
        Me.Lt聯絡人.Text = "聯絡人"
        '
        'Lt過帳日期
        '
        Me.Lt過帳日期.AutoSize = True
        Me.Lt過帳日期.Location = New System.Drawing.Point(6, 32)
        Me.Lt過帳日期.Name = "Lt過帳日期"
        Me.Lt過帳日期.Size = New System.Drawing.Size(53, 12)
        Me.Lt過帳日期.TabIndex = 5
        Me.Lt過帳日期.Text = "過帳日期"
        '
        'Lt責任單位
        '
        Me.Lt責任單位.AutoSize = True
        Me.Lt責任單位.Location = New System.Drawing.Point(6, 80)
        Me.Lt責任單位.Name = "Lt責任單位"
        Me.Lt責任單位.Size = New System.Drawing.Size(53, 12)
        Me.Lt責任單位.TabIndex = 4
        Me.Lt責任單位.Text = "責任單位"
        '
        'Lt文件單號
        '
        Me.Lt文件單號.AutoSize = True
        Me.Lt文件單號.Location = New System.Drawing.Point(6, 20)
        Me.Lt文件單號.Name = "Lt文件單號"
        Me.Lt文件單號.Size = New System.Drawing.Size(53, 12)
        Me.Lt文件單號.TabIndex = 3
        Me.Lt文件單號.Text = "文件單號"
        '
        'Lt發票日期
        '
        Me.Lt發票日期.AutoSize = True
        Me.Lt發票日期.Location = New System.Drawing.Point(6, 68)
        Me.Lt發票日期.Name = "Lt發票日期"
        Me.Lt發票日期.Size = New System.Drawing.Size(53, 12)
        Me.Lt發票日期.TabIndex = 2
        Me.Lt發票日期.Text = "發票日期"
        '
        'Lt發票號碼
        '
        Me.Lt發票號碼.AutoSize = True
        Me.Lt發票號碼.Location = New System.Drawing.Point(6, 56)
        Me.Lt發票號碼.Name = "Lt發票號碼"
        Me.Lt發票號碼.Size = New System.Drawing.Size(53, 12)
        Me.Lt發票號碼.TabIndex = 1
        Me.Lt發票號碼.Text = "發票號碼"
        '
        'Lt地址
        '
        Me.Lt地址.AutoSize = True
        Me.Lt地址.Location = New System.Drawing.Point(6, 140)
        Me.Lt地址.Name = "Lt地址"
        Me.Lt地址.Size = New System.Drawing.Size(29, 12)
        Me.Lt地址.TabIndex = 0
        Me.Lt地址.Text = "地址"
        '
        'TB單號
        '
        Me.TB單號.BackColor = System.Drawing.Color.White
        Me.TB單號.Location = New System.Drawing.Point(760, 6)
        Me.TB單號.Name = "TB單號"
        Me.TB單號.ReadOnly = True
        Me.TB單號.Size = New System.Drawing.Size(130, 22)
        Me.TB單號.TabIndex = 1018
        Me.TB單號.TabStop = False
        '
        'TB名稱
        '
        Me.TB名稱.BackColor = System.Drawing.Color.White
        Me.TB名稱.Location = New System.Drawing.Point(307, 6)
        Me.TB名稱.Name = "TB名稱"
        Me.TB名稱.ReadOnly = True
        Me.TB名稱.Size = New System.Drawing.Size(360, 22)
        Me.TB名稱.TabIndex = 1016
        Me.TB名稱.TabStop = False
        '
        'TB客編
        '
        Me.TB客編.BackColor = System.Drawing.Color.White
        Me.TB客編.Location = New System.Drawing.Point(86, 6)
        Me.TB客編.Name = "TB客編"
        Me.TB客編.ReadOnly = True
        Me.TB客編.Size = New System.Drawing.Size(130, 22)
        Me.TB客編.TabIndex = 1015
        Me.TB客編.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(675, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 16)
        Me.Label5.TabIndex = 1017
        Me.Label5.Text = "退貨單號："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 16)
        Me.Label1.TabIndex = 1013
        Me.Label1.Text = "客戶編號："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(222, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 1014
        Me.Label2.Text = "客戶名稱："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 1019
        Me.Label4.Text = "選擇類別："
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"營業", "生產", "倉儲", "其他", "營業+生產", "營業+倉儲", "生產+倉儲", "營業+生產+倉儲"})
        Me.ComboBox1.Location = New System.Drawing.Point(94, 35)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 27)
        Me.ComboBox1.TabIndex = 1022
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("新細明體", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"折讓", "退貨"})
        Me.ComboBox2.Location = New System.Drawing.Point(94, 5)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 27)
        Me.ComboBox2.TabIndex = 1020
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 16)
        Me.Label6.TabIndex = 1021
        Me.Label6.Text = "責任單位："
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(371, 65)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.Size = New System.Drawing.Size(601, 501)
        Me.DataGridView1.TabIndex = 1022
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 65)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 24
        Me.DataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.Size = New System.Drawing.Size(365, 501)
        Me.DataGridView2.TabIndex = 1022
        '
        'Lt作業
        '
        Me.Lt作業.AutoSize = True
        Me.Lt作業.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lt作業.Location = New System.Drawing.Point(981, 9)
        Me.Lt作業.Name = "Lt作業"
        Me.Lt作業.Size = New System.Drawing.Size(42, 16)
        Me.Lt作業.TabIndex = 1057
        Me.Lt作業.Text = "未選"
        Me.Lt作業.Visible = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(896, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(93, 16)
        Me.Label31.TabIndex = 1056
        Me.Label31.Text = "目前作業："
        Me.Label31.Visible = False
        '
        '退貨記錄V100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 637)
        Me.Controls.Add(Me.Lt作業)
        Me.Controls.Add(Me.TB單號)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TB名稱)
        Me.Controls.Add(Me.TB客編)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Gb表頭資料)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "退貨記錄V100"
        Me.Text = "退貨作業"
        Me.TabControl1.ResumeLayout(False)
        Me.Tp退貨作業.ResumeLayout(False)
        Me.Tp退貨作業.PerformLayout()
        CType(Me.T1退貨明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1退貨單號, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T1退貨記錄, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tp退單選擇.ResumeLayout(False)
        Me.Tp退單選擇.PerformLayout()
        CType(Me.T2單號明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T2選擇單號, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tp退貨輸入.ResumeLayout(False)
        Me.Tp退貨輸入.PerformLayout()
        CType(Me.T3退貨明細, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T3單號明細, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tp退貨數量.ResumeLayout(False)
        Me.Tp退貨數量.PerformLayout()
        CType(Me.T4退貨記錄, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T4輸入資料, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Gb表頭資料.ResumeLayout(False)
        Me.Gb表頭資料.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tp退貨作業 As System.Windows.Forms.TabPage
    Friend WithEvents Tp退單選擇 As System.Windows.Forms.TabPage
    Friend WithEvents TB單號 As System.Windows.Forms.TextBox
    Friend WithEvents TB名稱 As System.Windows.Forms.TextBox
    Friend WithEvents TB客編 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tb1名稱 As System.Windows.Forms.TextBox
    Friend WithEvents Bu1查詢 As System.Windows.Forms.Button
    Friend WithEvents Tb1客編 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents T1退貨記錄 As System.Windows.Forms.DataGridView
    Friend WithEvents T1退貨單號 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu1刪除 As System.Windows.Forms.Button
    Friend WithEvents Bu1新增 As System.Windows.Forms.Button
    Friend WithEvents Bu1修改 As System.Windows.Forms.Button
    Friend WithEvents Tp退貨輸入 As System.Windows.Forms.TabPage
    Friend WithEvents T2選擇單號 As System.Windows.Forms.DataGridView
    Friend WithEvents T2單號明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu2查詢 As System.Windows.Forms.Button
    Friend WithEvents De2日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Gb表頭資料 As System.Windows.Forms.GroupBox
    Friend WithEvents Lt備註2 As System.Windows.Forms.Label
    Friend WithEvents Lt備註1 As System.Windows.Forms.Label
    Friend WithEvents Lt聯絡人 As System.Windows.Forms.Label
    Friend WithEvents Lt過帳日期 As System.Windows.Forms.Label
    Friend WithEvents Lt責任單位 As System.Windows.Forms.Label
    Friend WithEvents Lt文件單號 As System.Windows.Forms.Label
    Friend WithEvents Lt發票日期 As System.Windows.Forms.Label
    Friend WithEvents Lt發票號碼 As System.Windows.Forms.Label
    Friend WithEvents Lt地址 As System.Windows.Forms.Label
    Friend WithEvents De2日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents T3退貨明細 As System.Windows.Forms.DataGridView
    Friend WithEvents T3單號明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Cb3折退類別 As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Lt輸入者 As System.Windows.Forms.Label
    Friend WithEvents Lt傳真 As System.Windows.Forms.Label
    Friend WithEvents Lt電話 As System.Windows.Forms.Label
    Friend WithEvents Cb1客戶名單 As System.Windows.Forms.ComboBox
    Friend WithEvents Rb1客戶1 As System.Windows.Forms.RadioButton
    Friend WithEvents Rb1客戶2 As System.Windows.Forms.RadioButton
    Friend WithEvents Bu2選單 As System.Windows.Forms.Button
    Friend WithEvents Cb2退單來源 As System.Windows.Forms.ComboBox
    Friend WithEvents Lt2單號 As System.Windows.Forms.Label
    Friend WithEvents Lt來源 As System.Windows.Forms.Label
    Friend WithEvents Cb3責任單位 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tb3稅額 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Lt總計 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Lt稅額 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Bu3存檔 As System.Windows.Forms.Button
    Friend WithEvents Tb3總計 As System.Windows.Forms.TextBox
    Friend WithEvents Lt類別 As System.Windows.Forms.Label
    Friend WithEvents De3輸入 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Bu3放棄 As System.Windows.Forms.Button
    Friend WithEvents Bu2放棄 As System.Windows.Forms.Button
    Friend WithEvents Bu3刪除 As System.Windows.Forms.Button
    Friend WithEvents Bu3新增 As System.Windows.Forms.Button
    Friend WithEvents Tb3備註 As System.Windows.Forms.TextBox
    Friend WithEvents Lt處理方式 As System.Windows.Forms.Label
    Friend WithEvents T1退貨明細 As System.Windows.Forms.DataGridView
    Friend WithEvents Cb3Key單人員 As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Bu1列印 As System.Windows.Forms.Button
    Friend WithEvents Cb3退貨原因 As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Cb3處理方式 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Lt退貨代碼 As System.Windows.Forms.Label
    Friend WithEvents Lt退貨原因 As System.Windows.Forms.Label
    Friend WithEvents De3退貨 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Lt2來源 As System.Windows.Forms.Label
    Friend WithEvents Lt退貨日期 As System.Windows.Forms.Label
    Friend WithEvents De1開始 As System.Windows.Forms.DateTimePicker
    Friend WithEvents De1結束 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Rb1日期 As System.Windows.Forms.RadioButton
    Friend WithEvents Cb3運輸司機 As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Cb1印表機 As System.Windows.Forms.ComboBox
    Friend WithEvents Lt運輸司機 As System.Windows.Forms.Label
    Friend WithEvents Lt司機代碼 As System.Windows.Forms.Label
    Friend WithEvents Tp退貨數量 As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents T4退貨記錄 As System.Windows.Forms.DataGridView
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents T4輸入資料 As System.Windows.Forms.DataGridView
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents T4Cb1原因 As System.Windows.Forms.ComboBox
    Friend WithEvents T4Cb1類別 As System.Windows.Forms.ComboBox
    Friend WithEvents T4Lt2說明 As System.Windows.Forms.TextBox
    Friend WithEvents Lt4數量 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Bu3數量 As System.Windows.Forms.Button
    Friend WithEvents Bu4存檔 As System.Windows.Forms.Button
    Friend WithEvents Lt4存編 As System.Windows.Forms.Label
    Friend WithEvents Lt4名稱 As System.Windows.Forms.Label
    Friend WithEvents Lt4合計 As System.Windows.Forms.Label
    Friend WithEvents Bu4輸入 As System.Windows.Forms.Button
    Friend WithEvents Lt4可退 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Bu4放棄 As System.Windows.Forms.Button
    Friend WithEvents Lt4列號 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Lt4ID As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Bu4移除 As System.Windows.Forms.Button
    Friend WithEvents Lt3名稱 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Lt作業 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents T4Cb2情況 As System.Windows.Forms.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents T4Cb2結果 As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents T4Cb2原因 As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Lt42數量 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents T4Lt1說明 As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Lt4合計1 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Lt4合計2 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents T4Cb2相符 As System.Windows.Forms.ComboBox
End Class
