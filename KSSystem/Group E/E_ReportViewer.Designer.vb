<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class E_ReportViewer
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
        Me.dtPayment1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportDataSet = New KSSystem.ReportDataSet
        Me.dtPayment2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtPayment3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rvPaymentType1 = New Microsoft.Reporting.WinForms.ReportViewer
        CType(Me.dtPayment1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtPayment2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtPayment3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtPayment1BindingSource
        '
        Me.dtPayment1BindingSource.DataMember = "dtPayment1"
        Me.dtPayment1BindingSource.DataSource = Me.ReportDataSet
        '
        'ReportDataSet
        '
        Me.ReportDataSet.DataSetName = "ReportDataSet"
        Me.ReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dtPayment2BindingSource
        '
        Me.dtPayment2BindingSource.DataMember = "dtPayment2"
        Me.dtPayment2BindingSource.DataSource = Me.ReportDataSet
        '
        'dtPayment3BindingSource
        '
        Me.dtPayment3BindingSource.DataMember = "dtPayment3"
        Me.dtPayment3BindingSource.DataSource = Me.ReportDataSet
        '
        'rvPaymentType1
        '
        Me.rvPaymentType1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "ReportDataSet_dtPayment1"
        ReportDataSource1.Value = Me.dtPayment1BindingSource
        ReportDataSource2.Name = "ReportDataSet_dtPayment2"
        ReportDataSource2.Value = Me.dtPayment2BindingSource
        ReportDataSource3.Name = "ReportDataSet_dtPayment3"
        ReportDataSource3.Value = Me.dtPayment3BindingSource
        Me.rvPaymentType1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.rvPaymentType1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.rvPaymentType1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.rvPaymentType1.LocalReport.ReportEmbeddedResource = "KSSystem.E_rpPayment.rdlc"
        Me.rvPaymentType1.Location = New System.Drawing.Point(0, 0)
        Me.rvPaymentType1.Name = "rvPaymentType1"
        Me.rvPaymentType1.Size = New System.Drawing.Size(824, 562)
        Me.rvPaymentType1.TabIndex = 4
        Me.rvPaymentType1.Visible = False
        '
        'E_ReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 562)
        Me.Controls.Add(Me.rvPaymentType1)
        Me.Name = "E_ReportViewer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "報表"
        CType(Me.dtPayment1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtPayment2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtPayment3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvPaymentType1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dtPayment1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportDataSet As KSSystem.ReportDataSet
    Friend WithEvents dtPayment2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dtPayment3BindingSource As System.Windows.Forms.BindingSource
End Class
