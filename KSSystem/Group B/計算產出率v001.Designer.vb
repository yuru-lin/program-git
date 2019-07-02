<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 計算產出率v001
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
        Me.txtM03 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtM11 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtItemName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DGV1 = New System.Windows.Forms.DataGridView
        Me.txtAvgKG = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtM07 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAddID = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDueDate = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtM12 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSumOfGizzard = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSumOfHeart = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSumOf2nd = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSumOfBad = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtM09 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtM08 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtM10 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtSumOfThroughput = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtSumOfTotal = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSumOfTestis = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtDiffTotal = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtDiffKG = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtSumOfEgg = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.PrintBtn = New System.Windows.Forms.Button
        Me.txtM02 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtSumOfThroughput2 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtM03
        '
        Me.txtM03.Location = New System.Drawing.Point(104, 6)
        Me.txtM03.Name = "txtM03"
        Me.txtM03.ReadOnly = True
        Me.txtM03.Size = New System.Drawing.Size(111, 22)
        Me.txtM03.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "製造單號："
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM11
        '
        Me.txtM11.Location = New System.Drawing.Point(104, 36)
        Me.txtM11.Name = "txtM11"
        Me.txtM11.Size = New System.Drawing.Size(111, 22)
        Me.txtM11.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "驗領單號："
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(104, 66)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(111, 22)
        Me.txtItemName.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "品名規格："
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.AllowUserToDeleteRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 95)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowHeadersVisible = False
        Me.DGV1.RowTemplate.Height = 24
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(622, 349)
        Me.DGV1.TabIndex = 59
        '
        'txtAvgKG
        '
        Me.txtAvgKG.Location = New System.Drawing.Point(311, 66)
        Me.txtAvgKG.Name = "txtAvgKG"
        Me.txtAvgKG.Size = New System.Drawing.Size(111, 22)
        Me.txtAvgKG.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(235, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "平均重："
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM07
        '
        Me.txtM07.Location = New System.Drawing.Point(311, 36)
        Me.txtM07.Name = "txtM07"
        Me.txtM07.Size = New System.Drawing.Size(111, 22)
        Me.txtM07.TabIndex = 63
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(219, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "投入重量："
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtAddID
        '
        Me.txtAddID.Location = New System.Drawing.Point(311, 6)
        Me.txtAddID.Name = "txtAddID"
        Me.txtAddID.Size = New System.Drawing.Size(111, 22)
        Me.txtAddID.TabIndex = 61
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(219, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "廠商簡稱："
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDueDate
        '
        Me.txtDueDate.Location = New System.Drawing.Point(518, 66)
        Me.txtDueDate.Name = "txtDueDate"
        Me.txtDueDate.Size = New System.Drawing.Size(111, 22)
        Me.txtDueDate.TabIndex = 71
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(458, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 16)
        Me.Label7.TabIndex = 70
        Me.Label7.Text = "日期："
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM12
        '
        Me.txtM12.Location = New System.Drawing.Point(518, 36)
        Me.txtM12.Name = "txtM12"
        Me.txtM12.Size = New System.Drawing.Size(111, 22)
        Me.txtM12.TabIndex = 69
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(427, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "投入隻數："
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(518, 6)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(111, 22)
        Me.txtItem.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(458, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "項目："
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfGizzard
        '
        Me.txtSumOfGizzard.Location = New System.Drawing.Point(518, 508)
        Me.txtSumOfGizzard.Name = "txtSumOfGizzard"
        Me.txtSumOfGizzard.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfGizzard.TabIndex = 89
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(426, 511)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 88
        Me.Label10.Text = "肫產成率："
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfHeart
        '
        Me.txtSumOfHeart.Location = New System.Drawing.Point(518, 479)
        Me.txtSumOfHeart.Name = "txtSumOfHeart"
        Me.txtSumOfHeart.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfHeart.TabIndex = 87
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(426, 482)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "心產成率："
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOf2nd
        '
        Me.txtSumOf2nd.Location = New System.Drawing.Point(518, 450)
        Me.txtSumOf2nd.Name = "txtSumOf2nd"
        Me.txtSumOf2nd.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOf2nd.TabIndex = 85
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(442, 453)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 16)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "次級率："
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfBad
        '
        Me.txtSumOfBad.Location = New System.Drawing.Point(311, 508)
        Me.txtSumOfBad.Name = "txtSumOfBad"
        Me.txtSumOfBad.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfBad.TabIndex = 83
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.Location = New System.Drawing.Point(235, 511)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 82
        Me.Label13.Text = "不良率："
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM09
        '
        Me.txtM09.Location = New System.Drawing.Point(311, 479)
        Me.txtM09.Name = "txtM09"
        Me.txtM09.Size = New System.Drawing.Size(111, 22)
        Me.txtM09.TabIndex = 81
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(235, 482)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 16)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "丟棄數："
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM08
        '
        Me.txtM08.Location = New System.Drawing.Point(311, 450)
        Me.txtM08.Name = "txtM08"
        Me.txtM08.Size = New System.Drawing.Size(111, 22)
        Me.txtM08.TabIndex = 79
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(235, 453)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 78
        Me.Label15.Text = "死亡數："
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtM10
        '
        Me.txtM10.Location = New System.Drawing.Point(104, 508)
        Me.txtM10.Name = "txtM10"
        Me.txtM10.Size = New System.Drawing.Size(111, 22)
        Me.txtM10.TabIndex = 77
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 511)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 16)
        Me.Label16.TabIndex = 76
        Me.Label16.Text = "會磅重量："
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfThroughput
        '
        Me.txtSumOfThroughput.Location = New System.Drawing.Point(104, 479)
        Me.txtSumOfThroughput.Name = "txtSumOfThroughput"
        Me.txtSumOfThroughput.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfThroughput.TabIndex = 75
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 482)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 74
        Me.Label17.Text = "總產成率："
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfTotal
        '
        Me.txtSumOfTotal.Location = New System.Drawing.Point(104, 450)
        Me.txtSumOfTotal.Name = "txtSumOfTotal"
        Me.txtSumOfTotal.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfTotal.TabIndex = 73
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(44, 453)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 16)
        Me.Label18.TabIndex = 72
        Me.Label18.Text = "合計："
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfTestis
        '
        Me.txtSumOfTestis.Location = New System.Drawing.Point(518, 537)
        Me.txtSumOfTestis.Name = "txtSumOfTestis"
        Me.txtSumOfTestis.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfTestis.TabIndex = 95
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(426, 540)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 16)
        Me.Label19.TabIndex = 94
        Me.Label19.Text = "佛產成率："
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDiffTotal
        '
        Me.txtDiffTotal.Location = New System.Drawing.Point(311, 537)
        Me.txtDiffTotal.Name = "txtDiffTotal"
        Me.txtDiffTotal.Size = New System.Drawing.Size(111, 22)
        Me.txtDiffTotal.TabIndex = 93
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(219, 540)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 16)
        Me.Label20.TabIndex = 92
        Me.Label20.Text = "隻數差異："
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDiffKG
        '
        Me.txtDiffKG.Location = New System.Drawing.Point(104, 537)
        Me.txtDiffKG.Name = "txtDiffKG"
        Me.txtDiffKG.Size = New System.Drawing.Size(111, 22)
        Me.txtDiffKG.TabIndex = 91
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.Location = New System.Drawing.Point(44, 540)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(56, 16)
        Me.Label21.TabIndex = 90
        Me.Label21.Text = "磅差："
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfEgg
        '
        Me.txtSumOfEgg.Location = New System.Drawing.Point(518, 566)
        Me.txtSumOfEgg.Name = "txtSumOfEgg"
        Me.txtSumOfEgg.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfEgg.TabIndex = 101
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.Location = New System.Drawing.Point(410, 569)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 16)
        Me.Label22.TabIndex = 100
        Me.Label22.Text = "蛋單產成率："
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(542, 594)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 23)
        Me.btnSave.TabIndex = 102
        Me.btnSave.Text = "儲存至資料庫"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'PrintBtn
        '
        Me.PrintBtn.Location = New System.Drawing.Point(461, 594)
        Me.PrintBtn.Name = "PrintBtn"
        Me.PrintBtn.Size = New System.Drawing.Size(75, 23)
        Me.PrintBtn.TabIndex = 103
        Me.PrintBtn.Text = "列印"
        Me.PrintBtn.UseVisualStyleBackColor = True
        '
        'txtM02
        '
        Me.txtM02.Location = New System.Drawing.Point(104, 563)
        Me.txtM02.Name = "txtM02"
        Me.txtM02.Size = New System.Drawing.Size(111, 22)
        Me.txtM02.TabIndex = 105
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(13, 566)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 16)
        Me.Label23.TabIndex = 104
        Me.Label23.Text = "生產總數："
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSumOfThroughput2
        '
        Me.txtSumOfThroughput2.Location = New System.Drawing.Point(104, 591)
        Me.txtSumOfThroughput2.Name = "txtSumOfThroughput2"
        Me.txtSumOfThroughput2.Size = New System.Drawing.Size(111, 22)
        Me.txtSumOfThroughput2.TabIndex = 107
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label24.Location = New System.Drawing.Point(13, 594)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(88, 16)
        Me.Label24.TabIndex = 106
        Me.Label24.Text = "生產總重："
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'B_CalcThroughput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 625)
        Me.Controls.Add(Me.txtSumOfThroughput2)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtM02)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.PrintBtn)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSumOfEgg)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtSumOfTestis)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtDiffTotal)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtDiffKG)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtSumOfGizzard)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSumOfHeart)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSumOf2nd)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtSumOfBad)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtM09)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtM08)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtM10)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtSumOfThroughput)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtSumOfTotal)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDueDate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtM12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAvgKG)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtM07)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAddID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.txtItemName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtM11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtM03)
        Me.Controls.Add(Me.Label5)
        Me.Name = "B_CalcThroughput"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "計算產出率"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtM03 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtM11 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtAvgKG As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtM07 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAddID As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtM12 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfGizzard As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfHeart As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSumOf2nd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfBad As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtM09 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtM08 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtM10 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfThroughput As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfTestis As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtDiffTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtDiffKG As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfEgg As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents PrintBtn As System.Windows.Forms.Button
    Friend WithEvents txtM02 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtSumOfThroughput2 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
End Class
