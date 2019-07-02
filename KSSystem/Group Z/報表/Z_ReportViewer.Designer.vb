<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Z_ReportViewer
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.dt_KS_Z_StockApply_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportDataSet = New KSSystem.ReportDataSet
        Me.dt_加工原料肉領料單BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dt_冷藏貨庫存表BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rvStockApply = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvWelfare = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rv加工原料肉領料單 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rv冷藏貨庫存表 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dt_KS_Z_WelfareSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dt_KS_Z_WelfareBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dt_KS_Z_StockApply_DetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_加工原料肉領料單BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_冷藏貨庫存表BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_KS_Z_WelfareSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dt_KS_Z_WelfareBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dt_KS_Z_StockApply_DetailBindingSource
        '
        Me.dt_KS_Z_StockApply_DetailBindingSource.DataMember = "dt_KS_Z_StockApply_Detail"
        Me.dt_KS_Z_StockApply_DetailBindingSource.DataSource = Me.ReportDataSet
        '
        'ReportDataSet
        '
        Me.ReportDataSet.DataSetName = "ReportDataSet"
        Me.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dt_加工原料肉領料單BindingSource
        '
        Me.dt_加工原料肉領料單BindingSource.DataMember = "dt_加工原料肉領料單"
        Me.dt_加工原料肉領料單BindingSource.DataSource = Me.ReportDataSet
        '
        'dt_冷藏貨庫存表BindingSource
        '
        Me.dt_冷藏貨庫存表BindingSource.DataMember = "dt_冷藏貨庫存表"
        Me.dt_冷藏貨庫存表BindingSource.DataSource = Me.ReportDataSet
        '
        'rvStockApply
        '
        Me.rvStockApply.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ReportDataSet_dt_KS_Z_StockApply_Detail"
        ReportDataSource1.Value = Me.dt_KS_Z_StockApply_DetailBindingSource
        Me.rvStockApply.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvStockApply.LocalReport.ReportEmbeddedResource = "KSSystem.Z_StockApply_Report.rdlc"
        Me.rvStockApply.Location = New System.Drawing.Point(0, 0)
        Me.rvStockApply.Name = "rvStockApply"
        Me.rvStockApply.Size = New System.Drawing.Size(834, 562)
        Me.rvStockApply.TabIndex = 0
        Me.rvStockApply.Visible = False
        '
        'rvWelfare
        '
        Me.rvWelfare.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "ReportDataSet_dt_KS_Z_StockApply_Detail"
        ReportDataSource2.Value = Me.dt_KS_Z_StockApply_DetailBindingSource
        Me.rvWelfare.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvWelfare.LocalReport.ReportEmbeddedResource = "KSSystem.Z_StockApply_Report.rdlc"
        Me.rvWelfare.Location = New System.Drawing.Point(0, 0)
        Me.rvWelfare.Name = "rvWelfare"
        Me.rvWelfare.Size = New System.Drawing.Size(834, 562)
        Me.rvWelfare.TabIndex = 1
        Me.rvWelfare.Visible = False
        '
        'rv加工原料肉領料單
        '
        Me.rv加工原料肉領料單.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "ReportDataSet_dt_加工原料肉領料單"
        ReportDataSource3.Value = Me.dt_加工原料肉領料單BindingSource
        Me.rv加工原料肉領料單.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rv加工原料肉領料單.LocalReport.ReportEmbeddedResource = "KSSystem.Z_加工原料肉領料單_Report.rdlc"
        Me.rv加工原料肉領料單.Location = New System.Drawing.Point(0, 0)
        Me.rv加工原料肉領料單.Name = "rv加工原料肉領料單"
        Me.rv加工原料肉領料單.Size = New System.Drawing.Size(834, 562)
        Me.rv加工原料肉領料單.TabIndex = 2
        Me.rv加工原料肉領料單.Visible = False
        '
        'rv冷藏貨庫存表
        '
        Me.rv冷藏貨庫存表.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource4.Name = "ReportDataSet_dt_冷藏貨庫存表"
        ReportDataSource4.Value = Me.dt_冷藏貨庫存表BindingSource
        Me.rv冷藏貨庫存表.LocalReport.DataSources.Add(ReportDataSource4)
        Me.rv冷藏貨庫存表.LocalReport.ReportEmbeddedResource = "KSSystem.Z_冷藏貨庫存表_Report.rdlc"
        Me.rv冷藏貨庫存表.Location = New System.Drawing.Point(0, 0)
        Me.rv冷藏貨庫存表.Name = "rv冷藏貨庫存表"
        Me.rv冷藏貨庫存表.Size = New System.Drawing.Size(834, 562)
        Me.rv冷藏貨庫存表.TabIndex = 3
        Me.rv冷藏貨庫存表.Visible = False
        '
        'dt_KS_Z_WelfareSource
        '
        Me.dt_KS_Z_WelfareSource.DataMember = "dt_KS_Z_Welfare"
        Me.dt_KS_Z_WelfareSource.DataSource = Me.ReportDataSet
        '
        'dt_KS_Z_WelfareBindingSource
        '
        Me.dt_KS_Z_WelfareBindingSource.DataMember = "dt_KS_Z_Welfare"
        Me.dt_KS_Z_WelfareBindingSource.DataSource = Me.ReportDataSet
        '
        'Z_ReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.rv冷藏貨庫存表)
        Me.Controls.Add(Me.rv加工原料肉領料單)
        Me.Controls.Add(Me.rvStockApply)
        Me.Controls.Add(Me.rvWelfare)
        Me.Name = "Z_ReportViewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "報表"
        CType(Me.dt_KS_Z_StockApply_DetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_加工原料肉領料單BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_冷藏貨庫存表BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_KS_Z_WelfareSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dt_KS_Z_WelfareBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvWelfare As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportDataSet As KSSystem.ReportDataSet
    Friend WithEvents dt_KS_Z_WelfareSource As System.Windows.Forms.BindingSource
    Friend WithEvents dt_加工原料肉領料單BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvStockApply As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_KS_Z_StockApply_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dt_KS_Z_WelfareBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rv加工原料肉領料單 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rv冷藏貨庫存表 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dt_冷藏貨庫存表BindingSource As System.Windows.Forms.BindingSource
End Class
