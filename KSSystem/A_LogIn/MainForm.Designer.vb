<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MainFormStatus = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.MainFormMenu = New System.Windows.Forms.MenuStrip
        Me.檔案FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.新增NToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.開啟OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.儲存SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.另存新檔AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.列印PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.預覽列印VToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.結束XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.工具TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.自訂CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.選項OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.視窗WToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.主功能表MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.說明HToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.About = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.說明ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.關於ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.測試ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.說明ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.關於ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.測試ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.說明ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.關於ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.複製ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.匯出ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MainFormStatus.SuspendLayout()
        Me.MainFormMenu.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainFormStatus
        '
        Me.MainFormStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.MainFormStatus.Location = New System.Drawing.Point(0, 724)
        Me.MainFormStatus.Name = "MainFormStatus"
        Me.MainFormStatus.Size = New System.Drawing.Size(1028, 22)
        Me.MainFormStatus.TabIndex = 1
        Me.MainFormStatus.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'MainFormMenu
        '
        Me.MainFormMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.檔案FToolStripMenuItem, Me.工具TToolStripMenuItem, Me.視窗WToolStripMenuItem, Me.說明HToolStripMenuItem})
        Me.MainFormMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainFormMenu.Name = "MainFormMenu"
        Me.MainFormMenu.Size = New System.Drawing.Size(1028, 28)
        Me.MainFormMenu.TabIndex = 2
        Me.MainFormMenu.Text = "MenuStrip1"
        '
        '檔案FToolStripMenuItem
        '
        Me.檔案FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新增NToolStripMenuItem, Me.開啟OToolStripMenuItem, Me.toolStripSeparator, Me.儲存SToolStripMenuItem, Me.另存新檔AToolStripMenuItem, Me.toolStripSeparator1, Me.列印PToolStripMenuItem, Me.預覽列印VToolStripMenuItem, Me.toolStripSeparator2, Me.結束XToolStripMenuItem})
        Me.檔案FToolStripMenuItem.Name = "檔案FToolStripMenuItem"
        Me.檔案FToolStripMenuItem.Size = New System.Drawing.Size(71, 24)
        Me.檔案FToolStripMenuItem.Text = "檔案(&F)"
        '
        '新增NToolStripMenuItem
        '
        Me.新增NToolStripMenuItem.Enabled = False
        Me.新增NToolStripMenuItem.Image = CType(resources.GetObject("新增NToolStripMenuItem.Image"), System.Drawing.Image)
        Me.新增NToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.新增NToolStripMenuItem.Name = "新增NToolStripMenuItem"
        Me.新增NToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.新增NToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.新增NToolStripMenuItem.Text = "新增(&N)"
        '
        '開啟OToolStripMenuItem
        '
        Me.開啟OToolStripMenuItem.Enabled = False
        Me.開啟OToolStripMenuItem.Image = CType(resources.GetObject("開啟OToolStripMenuItem.Image"), System.Drawing.Image)
        Me.開啟OToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.開啟OToolStripMenuItem.Name = "開啟OToolStripMenuItem"
        Me.開啟OToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.開啟OToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.開啟OToolStripMenuItem.Text = "開啟(&O)"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(191, 6)
        '
        '儲存SToolStripMenuItem
        '
        Me.儲存SToolStripMenuItem.Enabled = False
        Me.儲存SToolStripMenuItem.Image = CType(resources.GetObject("儲存SToolStripMenuItem.Image"), System.Drawing.Image)
        Me.儲存SToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.儲存SToolStripMenuItem.Name = "儲存SToolStripMenuItem"
        Me.儲存SToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.儲存SToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.儲存SToolStripMenuItem.Text = "儲存(&S)"
        '
        '另存新檔AToolStripMenuItem
        '
        Me.另存新檔AToolStripMenuItem.Enabled = False
        Me.另存新檔AToolStripMenuItem.Name = "另存新檔AToolStripMenuItem"
        Me.另存新檔AToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.另存新檔AToolStripMenuItem.Text = "另存新檔(&A)"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(191, 6)
        '
        '列印PToolStripMenuItem
        '
        Me.列印PToolStripMenuItem.Enabled = False
        Me.列印PToolStripMenuItem.Image = CType(resources.GetObject("列印PToolStripMenuItem.Image"), System.Drawing.Image)
        Me.列印PToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.列印PToolStripMenuItem.Name = "列印PToolStripMenuItem"
        Me.列印PToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.列印PToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.列印PToolStripMenuItem.Text = "列印(&P)"
        '
        '預覽列印VToolStripMenuItem
        '
        Me.預覽列印VToolStripMenuItem.Enabled = False
        Me.預覽列印VToolStripMenuItem.Image = CType(resources.GetObject("預覽列印VToolStripMenuItem.Image"), System.Drawing.Image)
        Me.預覽列印VToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.預覽列印VToolStripMenuItem.Name = "預覽列印VToolStripMenuItem"
        Me.預覽列印VToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.預覽列印VToolStripMenuItem.Text = "預覽列印(&V)"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(191, 6)
        '
        '結束XToolStripMenuItem
        '
        Me.結束XToolStripMenuItem.Name = "結束XToolStripMenuItem"
        Me.結束XToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.結束XToolStripMenuItem.Size = New System.Drawing.Size(194, 24)
        Me.結束XToolStripMenuItem.Text = "結束(&Q)"
        '
        '工具TToolStripMenuItem
        '
        Me.工具TToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.自訂CToolStripMenuItem, Me.選項OToolStripMenuItem})
        Me.工具TToolStripMenuItem.Enabled = False
        Me.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem"
        Me.工具TToolStripMenuItem.Size = New System.Drawing.Size(72, 24)
        Me.工具TToolStripMenuItem.Text = "工具(&T)"
        '
        '自訂CToolStripMenuItem
        '
        Me.自訂CToolStripMenuItem.Name = "自訂CToolStripMenuItem"
        Me.自訂CToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.自訂CToolStripMenuItem.Text = "自訂(&C)"
        '
        '選項OToolStripMenuItem
        '
        Me.選項OToolStripMenuItem.Name = "選項OToolStripMenuItem"
        Me.選項OToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.選項OToolStripMenuItem.Text = "選項(&O)"
        '
        '視窗WToolStripMenuItem
        '
        Me.視窗WToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.主功能表MToolStripMenuItem})
        Me.視窗WToolStripMenuItem.Name = "視窗WToolStripMenuItem"
        Me.視窗WToolStripMenuItem.Size = New System.Drawing.Size(79, 24)
        Me.視窗WToolStripMenuItem.Text = "視窗(&W)"
        '
        '主功能表MToolStripMenuItem
        '
        Me.主功能表MToolStripMenuItem.Name = "主功能表MToolStripMenuItem"
        Me.主功能表MToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.主功能表MToolStripMenuItem.Text = "主功能表"
        '
        '說明HToolStripMenuItem
        '
        Me.說明HToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.About})
        Me.說明HToolStripMenuItem.Name = "說明HToolStripMenuItem"
        Me.說明HToolStripMenuItem.Size = New System.Drawing.Size(75, 24)
        Me.說明HToolStripMenuItem.Text = "說明(&H)"
        '
        'About
        '
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(152, 24)
        Me.About.Text = "關於"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(44, 20)
        Me.ToolStripMenuItem2.Text = "檔案"
        '
        '說明ToolStripMenuItem
        '
        Me.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem"
        Me.說明ToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.說明ToolStripMenuItem.Text = "說明"
        '
        '關於ToolStripMenuItem
        '
        Me.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem"
        Me.關於ToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.關於ToolStripMenuItem.Text = "關於"
        '
        '測試ToolStripMenuItem
        '
        Me.測試ToolStripMenuItem.Name = "測試ToolStripMenuItem"
        Me.測試ToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.測試ToolStripMenuItem.Text = "測試"
        '
        '說明ToolStripMenuItem1
        '
        Me.說明ToolStripMenuItem1.Name = "說明ToolStripMenuItem1"
        Me.說明ToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.說明ToolStripMenuItem1.Text = "說明"
        '
        '關於ToolStripMenuItem1
        '
        Me.關於ToolStripMenuItem1.Name = "關於ToolStripMenuItem1"
        Me.關於ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.關於ToolStripMenuItem1.Text = "關於"
        '
        '測試ToolStripMenuItem1
        '
        Me.測試ToolStripMenuItem1.Name = "測試ToolStripMenuItem1"
        Me.測試ToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.測試ToolStripMenuItem1.Text = "測試"
        '
        '說明ToolStripMenuItem2
        '
        Me.說明ToolStripMenuItem2.Name = "說明ToolStripMenuItem2"
        Me.說明ToolStripMenuItem2.Size = New System.Drawing.Size(44, 20)
        Me.說明ToolStripMenuItem2.Text = "說明"
        '
        '關於ToolStripMenuItem2
        '
        Me.關於ToolStripMenuItem2.Name = "關於ToolStripMenuItem2"
        Me.關於ToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.關於ToolStripMenuItem2.Text = "關於"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.複製ToolStripMenuItem, Me.匯出ExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 74)
        '
        '複製ToolStripMenuItem
        '
        Me.複製ToolStripMenuItem.Name = "複製ToolStripMenuItem"
        Me.複製ToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.複製ToolStripMenuItem.Text = "複製"
        '
        '匯出ExcelToolStripMenuItem
        '
        Me.匯出ExcelToolStripMenuItem.Name = "匯出ExcelToolStripMenuItem"
        Me.匯出ExcelToolStripMenuItem.Size = New System.Drawing.Size(152, 24)
        Me.匯出ExcelToolStripMenuItem.Text = "匯出Excel"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.KSSystem.My.Resources.Resources.ks_Log
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.MainFormStatus)
        Me.Controls.Add(Me.MainFormMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MainFormMenu
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "凱馨外掛系統"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MainFormStatus.ResumeLayout(False)
        Me.MainFormStatus.PerformLayout()
        Me.MainFormMenu.ResumeLayout(False)
        Me.MainFormMenu.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainFormStatus As System.Windows.Forms.StatusStrip
    Friend WithEvents MainFormMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 說明ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents 關於ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 測試ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 說明ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 關於ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 測試ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 說明ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 關於ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 說明HToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents 檔案FToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 新增NToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 開啟OToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 儲存SToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 另存新檔AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 列印PToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 預覽列印VToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 結束XToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 工具TToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 自訂CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 選項OToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 視窗WToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 主功能表MToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 複製ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 匯出ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
