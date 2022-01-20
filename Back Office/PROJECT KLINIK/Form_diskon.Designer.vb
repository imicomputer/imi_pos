<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_diskon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_diskon))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.NamaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JenisDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JmlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiskonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PosFakturDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PosFakturDataSet = New PROJECT_KLINIK.posFakturDataSet
        Me.DiskonTableAdapter = New PROJECT_KLINIK.posFakturDataSetTableAdapters.diskonTableAdapter
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiskonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PosFakturDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PosFakturDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 28)
        Me.Panel1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(93, 5)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(400, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nama Diskon"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 359)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(498, 45)
        Me.Panel2.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Maroon
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(411, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 24)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "C&lose"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(93, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "&Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Green
        Me.Button1.Enabled = False
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(12, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NamaDataGridViewTextBoxColumn, Me.JenisDataGridViewTextBoxColumn, Me.JmlDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.DiskonBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(498, 331)
        Me.DataGridView1.TabIndex = 1
        '
        'NamaDataGridViewTextBoxColumn
        '
        Me.NamaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NamaDataGridViewTextBoxColumn.DataPropertyName = "nama"
        Me.NamaDataGridViewTextBoxColumn.HeaderText = "Nama"
        Me.NamaDataGridViewTextBoxColumn.Name = "NamaDataGridViewTextBoxColumn"
        Me.NamaDataGridViewTextBoxColumn.Width = 60
        '
        'JenisDataGridViewTextBoxColumn
        '
        Me.JenisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JenisDataGridViewTextBoxColumn.DataPropertyName = "jenis"
        Me.JenisDataGridViewTextBoxColumn.HeaderText = "Jenis Diskon"
        Me.JenisDataGridViewTextBoxColumn.Name = "JenisDataGridViewTextBoxColumn"
        Me.JenisDataGridViewTextBoxColumn.Width = 92
        '
        'JmlDataGridViewTextBoxColumn
        '
        Me.JmlDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JmlDataGridViewTextBoxColumn.DataPropertyName = "jml"
        Me.JmlDataGridViewTextBoxColumn.HeaderText = "Nominal"
        Me.JmlDataGridViewTextBoxColumn.Name = "JmlDataGridViewTextBoxColumn"
        Me.JmlDataGridViewTextBoxColumn.Width = 70
        '
        'DiskonBindingSource
        '
        Me.DiskonBindingSource.DataMember = "diskon"
        Me.DiskonBindingSource.DataSource = Me.PosFakturDataSetBindingSource
        '
        'PosFakturDataSetBindingSource
        '
        Me.PosFakturDataSetBindingSource.DataSource = Me.PosFakturDataSet
        Me.PosFakturDataSetBindingSource.Position = 0
        '
        'PosFakturDataSet
        '
        Me.PosFakturDataSet.DataSetName = "posFakturDataSet"
        Me.PosFakturDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DiskonTableAdapter
        '
        Me.DiskonTableAdapter.ClearBeforeFill = True
        '
        'Form_diskon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.CancelButton = Me.Button3
        Me.ClientSize = New System.Drawing.Size(498, 404)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form_diskon"
        Me.Text = "Data Diskon"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiskonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PosFakturDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PosFakturDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PosFakturDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PosFakturDataSet As PROJECT_KLINIK.posFakturDataSet
    Friend WithEvents DiskonBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DiskonTableAdapter As PROJECT_KLINIK.posFakturDataSetTableAdapters.diskonTableAdapter
    Friend WithEvents NamaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JenisDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JmlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
