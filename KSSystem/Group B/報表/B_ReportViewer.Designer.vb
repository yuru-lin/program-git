<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B_ReportViewer
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
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource8 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource9 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource10 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource11 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource12 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource13 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource14 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource15 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource16 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource17 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.dtThroughputBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportDataSet = New KSSystem.ReportDataSet
        Me.dtMeltsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtTransportBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtFeedingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtSchedulingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtSPickingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtSPicking1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtDispatchingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rvThroghput = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvMelts = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvTransport = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvFeeding = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvOrderPicking = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking3 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking4 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking5 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking6 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking7 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvDispatching = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking8 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.rvSPicking9 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.dtThroughputBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtMeltsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtTransportBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFeedingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSchedulingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSPickingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSPicking1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtDispatchingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtThroughputBindingSource
        '
        Me.dtThroughputBindingSource.DataMember = "dtThroughput"
        Me.dtThroughputBindingSource.DataSource = Me.ReportDataSet
        '
        'ReportDataSet
        '
        Me.ReportDataSet.DataSetName = "ReportDataSet"
        Me.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtMeltsBindingSource
        '
        Me.dtMeltsBindingSource.DataMember = "dtMelts"
        Me.dtMeltsBindingSource.DataSource = Me.ReportDataSet
        '
        'dtTransportBindingSource
        '
        Me.dtTransportBindingSource.DataMember = "dtTransport"
        Me.dtTransportBindingSource.DataSource = Me.ReportDataSet
        '
        'dtFeedingBindingSource
        '
        Me.dtFeedingBindingSource.DataMember = "dtFeeding"
        Me.dtFeedingBindingSource.DataSource = Me.ReportDataSet
        '
        'dtSchedulingBindingSource
        '
        Me.dtSchedulingBindingSource.DataMember = "dtScheduling"
        Me.dtSchedulingBindingSource.DataSource = Me.ReportDataSet
        '
        'dtSPickingBindingSource
        '
        Me.dtSPickingBindingSource.DataMember = "dtSPicking"
        Me.dtSPickingBindingSource.DataSource = Me.ReportDataSet
        '
        'dtSPicking1BindingSource
        '
        Me.dtSPicking1BindingSource.DataMember = "dtSPicking1"
        Me.dtSPicking1BindingSource.DataSource = Me.ReportDataSet
        '
        'dtDispatchingBindingSource
        '
        Me.dtDispatchingBindingSource.DataMember = "dtDispatching"
        Me.dtDispatchingBindingSource.DataSource = Me.ReportDataSet
        '
        'rvThroghput
        '
        Me.rvThroghput.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ReportDataSet_dtThroughput"
        ReportDataSource1.Value = Me.dtThroughputBindingSource
        Me.rvThroghput.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvThroghput.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpThroughput.rdlc"
        Me.rvThroghput.Location = New System.Drawing.Point(0, 0)
        Me.rvThroghput.Name = "rvThroghput"
        Me.rvThroghput.Size = New System.Drawing.Size(834, 562)
        Me.rvThroghput.TabIndex = 0
        Me.rvThroghput.Visible = False
        '
        'rvMelts
        '
        Me.rvMelts.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "ReportDataSet_dtMelts"
        ReportDataSource2.Value = Me.dtMeltsBindingSource
        Me.rvMelts.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvMelts.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpMelts.rdlc"
        Me.rvMelts.Location = New System.Drawing.Point(0, 0)
        Me.rvMelts.Name = "rvMelts"
        Me.rvMelts.Size = New System.Drawing.Size(834, 562)
        Me.rvMelts.TabIndex = 1
        Me.rvMelts.Visible = False
        '
        'rvTransport
        '
        Me.rvTransport.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "ReportDataSet_dtTransport"
        ReportDataSource3.Value = Me.dtTransportBindingSource
        Me.rvTransport.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rvTransport.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpTransport.rdlc"
        Me.rvTransport.Location = New System.Drawing.Point(0, 0)
        Me.rvTransport.Name = "rvTransport"
        Me.rvTransport.Size = New System.Drawing.Size(834, 562)
        Me.rvTransport.TabIndex = 2
        Me.rvTransport.Visible = False
        '
        'rvFeeding
        '
        Me.rvFeeding.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource4.Name = "ReportDataSet_dtMelts"
        ReportDataSource4.Value = Me.dtMeltsBindingSource
        ReportDataSource5.Name = "ReportDataSet_dtFeeding"
        ReportDataSource5.Value = Me.dtFeedingBindingSource
        Me.rvFeeding.LocalReport.DataSources.Add(ReportDataSource4)
        Me.rvFeeding.LocalReport.DataSources.Add(ReportDataSource5)
        Me.rvFeeding.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpFeeding .rdlc"
        Me.rvFeeding.Location = New System.Drawing.Point(0, 0)
        Me.rvFeeding.Name = "rvFeeding"
        Me.rvFeeding.Size = New System.Drawing.Size(834, 562)
        Me.rvFeeding.TabIndex = 3
        Me.rvFeeding.Visible = False
        '
        'rvOrderPicking
        '
        Me.rvOrderPicking.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource6.Name = "ReportDataSet_dtScheduling"
        ReportDataSource6.Value = Me.dtSchedulingBindingSource
        ReportDataSource7.Name = "ReportDataSet_dtSPicking"
        ReportDataSource7.Value = Me.dtSPickingBindingSource
        Me.rvOrderPicking.LocalReport.DataSources.Add(ReportDataSource6)
        Me.rvOrderPicking.LocalReport.DataSources.Add(ReportDataSource7)
        Me.rvOrderPicking.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpOrderPicking.rdlc"
        Me.rvOrderPicking.Location = New System.Drawing.Point(0, 0)
        Me.rvOrderPicking.Name = "rvOrderPicking"
        Me.rvOrderPicking.Size = New System.Drawing.Size(834, 562)
        Me.rvOrderPicking.TabIndex = 4
        Me.rvOrderPicking.Visible = False
        '
        'rvSPicking1
        '
        Me.rvSPicking1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource8.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource8.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking1.LocalReport.DataSources.Add(ReportDataSource8)
        Me.rvSPicking1.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking1.rdlc"
        Me.rvSPicking1.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking1.Name = "rvSPicking1"
        Me.rvSPicking1.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking1.TabIndex = 5
        Me.rvSPicking1.Visible = False
        '
        'rvSPicking2
        '
        Me.rvSPicking2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource9.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource9.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking2.LocalReport.DataSources.Add(ReportDataSource9)
        Me.rvSPicking2.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking2.rdlc"
        Me.rvSPicking2.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking2.Name = "rvSPicking2"
        Me.rvSPicking2.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking2.TabIndex = 6
        Me.rvSPicking2.Visible = False
        '
        'rvSPicking3
        '
        Me.rvSPicking3.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource10.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource10.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking3.LocalReport.DataSources.Add(ReportDataSource10)
        Me.rvSPicking3.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking3.rdlc"
        Me.rvSPicking3.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking3.Name = "rvSPicking3"
        Me.rvSPicking3.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking3.TabIndex = 7
        Me.rvSPicking3.Visible = False
        '
        'rvSPicking4
        '
        Me.rvSPicking4.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource11.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource11.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking4.LocalReport.DataSources.Add(ReportDataSource11)
        Me.rvSPicking4.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking4.rdlc"
        Me.rvSPicking4.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking4.Name = "rvSPicking4"
        Me.rvSPicking4.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking4.TabIndex = 8
        Me.rvSPicking4.Visible = False
        '
        'rvSPicking5
        '
        Me.rvSPicking5.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource12.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource12.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking5.LocalReport.DataSources.Add(ReportDataSource12)
        Me.rvSPicking5.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking5.rdlc"
        Me.rvSPicking5.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking5.Name = "rvSPicking5"
        Me.rvSPicking5.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking5.TabIndex = 9
        Me.rvSPicking5.Visible = False
        '
        'rvSPicking6
        '
        Me.rvSPicking6.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource13.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource13.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking6.LocalReport.DataSources.Add(ReportDataSource13)
        Me.rvSPicking6.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking6.rdlc"
        Me.rvSPicking6.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking6.Name = "rvSPicking6"
        Me.rvSPicking6.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking6.TabIndex = 10
        Me.rvSPicking6.Visible = False
        '
        'rvSPicking7
        '
        Me.rvSPicking7.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource14.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource14.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking7.LocalReport.DataSources.Add(ReportDataSource14)
        Me.rvSPicking7.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking7.rdlc"
        Me.rvSPicking7.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking7.Name = "rvSPicking7"
        Me.rvSPicking7.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking7.TabIndex = 11
        Me.rvSPicking7.Visible = False
        '
        'rvDispatching
        '
        Me.rvDispatching.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource15.Name = "ReportDataSet_dtDispatching"
        ReportDataSource15.Value = Me.dtDispatchingBindingSource
        Me.rvDispatching.LocalReport.DataSources.Add(ReportDataSource15)
        Me.rvDispatching.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpDispatching.rdlc"
        Me.rvDispatching.Location = New System.Drawing.Point(0, 0)
        Me.rvDispatching.Name = "rvDispatching"
        Me.rvDispatching.Size = New System.Drawing.Size(834, 562)
        Me.rvDispatching.TabIndex = 12
        Me.rvDispatching.Visible = False
        Me.rvDispatching.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        '
        'rvSPicking8
        '
        Me.rvSPicking8.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource16.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource16.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking8.LocalReport.DataSources.Add(ReportDataSource16)
        Me.rvSPicking8.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking8.rdlc"
        Me.rvSPicking8.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking8.Name = "rvSPicking8"
        Me.rvSPicking8.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking8.TabIndex = 13
        Me.rvSPicking8.Visible = False
        Me.rvSPicking8.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        '
        'rvSPicking9
        '
        Me.rvSPicking9.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource17.Name = "ReportDataSet_dtSPicking1"
        ReportDataSource17.Value = Me.dtSPicking1BindingSource
        Me.rvSPicking9.LocalReport.DataSources.Add(ReportDataSource17)
        Me.rvSPicking9.LocalReport.ReportEmbeddedResource = "KSSystem.B_rpSPicking9.rdlc"
        Me.rvSPicking9.Location = New System.Drawing.Point(0, 0)
        Me.rvSPicking9.Name = "rvSPicking9"
        Me.rvSPicking9.Size = New System.Drawing.Size(834, 562)
        Me.rvSPicking9.TabIndex = 14
        Me.rvSPicking9.Visible = False
        Me.rvSPicking9.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
        '
        'B_ReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 562)
        Me.Controls.Add(Me.rvSPicking9)
        Me.Controls.Add(Me.rvSPicking8)
        Me.Controls.Add(Me.rvDispatching)
        Me.Controls.Add(Me.rvSPicking7)
        Me.Controls.Add(Me.rvSPicking6)
        Me.Controls.Add(Me.rvSPicking5)
        Me.Controls.Add(Me.rvSPicking4)
        Me.Controls.Add(Me.rvThroghput)
        Me.Controls.Add(Me.rvTransport)
        Me.Controls.Add(Me.rvSPicking3)
        Me.Controls.Add(Me.rvSPicking2)
        Me.Controls.Add(Me.rvFeeding)
        Me.Controls.Add(Me.rvOrderPicking)
        Me.Controls.Add(Me.rvSPicking1)
        Me.Controls.Add(Me.rvMelts)
        Me.Name = "B_ReportViewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "報表"
        CType(Me.dtThroughputBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtMeltsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtTransportBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFeedingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSchedulingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSPickingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSPicking1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtDispatchingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvThroghput As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtThroughputBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportDataSet As KSSystem.ReportDataSet
    Friend WithEvents rvMelts As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtMeltsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvTransport As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtTransportBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvFeeding As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtFeedingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dtSchedulingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvOrderPicking As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtSPickingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvSPicking1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtSPicking1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvSPicking2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvSPicking3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvSPicking4 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvSPicking5 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvSPicking6 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvSPicking7 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvDispatching As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtDispatchingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents rvSPicking8 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents rvSPicking9 As Microsoft.Reporting.WinForms.ReportViewer
End Class
