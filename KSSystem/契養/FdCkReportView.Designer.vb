<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FdCkReportView
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
        Me.V_FdCkBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KaiShingPlugDataSet = New KSSystem.KaiShingPlugDataSet
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.V_FdCkTableAdapter = New KSSystem.KaiShingPlugDataSetTableAdapters.V_FdCkTableAdapter
        CType(Me.V_FdCkBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KaiShingPlugDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'V_FdCkBindingSource
        '
        Me.V_FdCkBindingSource.DataMember = "V_FdCk"
        Me.V_FdCkBindingSource.DataSource = Me.KaiShingPlugDataSet
        '
        'KaiShingPlugDataSet
        '
        Me.KaiShingPlugDataSet.DataSetName = "KaiShingPlugDataSet"
        Me.KaiShingPlugDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.AutoSize = True
        ReportDataSource1.Name = "KaiShingPlugDataSet_V_FdCk"
        ReportDataSource1.Value = Me.V_FdCkBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "KSSystem.FdCKReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(1, -2)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(2)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(825, 634)
        Me.ReportViewer1.TabIndex = 2
        '
        'V_FdCkTableAdapter
        '
        Me.V_FdCkTableAdapter.ClearBeforeFill = True
        '
        'FdCkReportView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 562)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "FdCkReportView"
        Me.Text = "FdCkReportView"
        CType(Me.V_FdCkBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KaiShingPlugDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents V_FdCkBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KaiShingPlugDataSet As KSSystem.KaiShingPlugDataSet
    Friend WithEvents V_FdCkTableAdapter As KSSystem.KaiShingPlugDataSetTableAdapters.V_FdCkTableAdapter
End Class
