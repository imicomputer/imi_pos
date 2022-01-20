<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cetak_faktur
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.dsCetakFaktur = New project_pos.dsCetakFaktur
        Me.cetak_fakturBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cetak_fakturTableAdapter = New project_pos.dsCetakFakturTableAdapters.cetak_fakturTableAdapter
        CType(Me.dsCetakFaktur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cetak_fakturBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsCetakFaktur_cetak_faktur"
        ReportDataSource1.Value = Me.cetak_fakturBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "project_pos.Print_Faktur.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(464, 273)
        Me.ReportViewer1.TabIndex = 0
        '
        'dsCetakFaktur
        '
        Me.dsCetakFaktur.DataSetName = "dsCetakFaktur"
        Me.dsCetakFaktur.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cetak_fakturBindingSource
        '
        Me.cetak_fakturBindingSource.DataMember = "cetak_faktur"
        Me.cetak_fakturBindingSource.DataSource = Me.dsCetakFaktur
        '
        'cetak_fakturTableAdapter
        '
        Me.cetak_fakturTableAdapter.ClearBeforeFill = True
        '
        'cetak_faktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 273)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "cetak_faktur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cetak Faktur Penjualan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dsCetakFaktur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cetak_fakturBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cetak_fakturBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsCetakFaktur As project_pos.dsCetakFaktur
    Friend WithEvents cetak_fakturTableAdapter As project_pos.dsCetakFakturTableAdapters.cetak_fakturTableAdapter
End Class
