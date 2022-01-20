<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_paket
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_paket))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DataGridView0 = New System.Windows.Forms.DataGridView
        Me.IdDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NamaDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BiayaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KetDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StokDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PengurangstokDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProdukBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PosFakturDataSet = New PROJECT_KLINIK.posFakturDataSet
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IdprodukDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NamaDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JumlahDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Paket_detailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.Produk_paketBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProdukTableAdapter = New PROJECT_KLINIK.posFakturDataSetTableAdapters.produkTableAdapter
        Me.Produk_paketTableAdapter = New PROJECT_KLINIK.posFakturDataSetTableAdapters.produk_paketTableAdapter
        Me.Paket_detailTableAdapter = New PROJECT_KLINIK.posFakturDataSetTableAdapters.paket_detailTableAdapter
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NamaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BiayaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiskonjmlmaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiskonjmlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StokDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PengurangstokDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdukBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PosFakturDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Paket_detailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Produk_paketBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView0)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 177)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(935, 300)
        Me.Panel1.TabIndex = 0
        '
        'DataGridView0
        '
        Me.DataGridView0.AllowUserToAddRows = False
        Me.DataGridView0.AllowUserToDeleteRows = False
        Me.DataGridView0.AutoGenerateColumns = False
        Me.DataGridView0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn1, Me.NamaDataGridViewTextBoxColumn2, Me.BiayaDataGridViewTextBoxColumn1, Me.KetDataGridViewTextBoxColumn, Me.StokDataGridViewTextBoxColumn2, Me.PengurangstokDataGridViewTextBoxColumn})
        Me.DataGridView0.DataSource = Me.ProdukBindingSource
        Me.DataGridView0.Location = New System.Drawing.Point(519, 23)
        Me.DataGridView0.Name = "DataGridView0"
        Me.DataGridView0.ReadOnly = True
        Me.DataGridView0.Size = New System.Drawing.Size(332, 262)
        Me.DataGridView0.TabIndex = 8
        Me.DataGridView0.Visible = False
        '
        'IdDataGridViewTextBoxColumn1
        '
        Me.IdDataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn1.Name = "IdDataGridViewTextBoxColumn1"
        Me.IdDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'NamaDataGridViewTextBoxColumn2
        '
        Me.NamaDataGridViewTextBoxColumn2.DataPropertyName = "nama"
        Me.NamaDataGridViewTextBoxColumn2.HeaderText = "nama"
        Me.NamaDataGridViewTextBoxColumn2.Name = "NamaDataGridViewTextBoxColumn2"
        Me.NamaDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'BiayaDataGridViewTextBoxColumn1
        '
        Me.BiayaDataGridViewTextBoxColumn1.DataPropertyName = "biaya"
        Me.BiayaDataGridViewTextBoxColumn1.HeaderText = "biaya"
        Me.BiayaDataGridViewTextBoxColumn1.Name = "BiayaDataGridViewTextBoxColumn1"
        Me.BiayaDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'KetDataGridViewTextBoxColumn
        '
        Me.KetDataGridViewTextBoxColumn.DataPropertyName = "ket"
        Me.KetDataGridViewTextBoxColumn.HeaderText = "ket"
        Me.KetDataGridViewTextBoxColumn.Name = "KetDataGridViewTextBoxColumn"
        Me.KetDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StokDataGridViewTextBoxColumn2
        '
        Me.StokDataGridViewTextBoxColumn2.DataPropertyName = "stok"
        Me.StokDataGridViewTextBoxColumn2.HeaderText = "stok"
        Me.StokDataGridViewTextBoxColumn2.Name = "StokDataGridViewTextBoxColumn2"
        Me.StokDataGridViewTextBoxColumn2.ReadOnly = True
        '
        'PengurangstokDataGridViewTextBoxColumn
        '
        Me.PengurangstokDataGridViewTextBoxColumn.DataPropertyName = "pengurang_stok"
        Me.PengurangstokDataGridViewTextBoxColumn.HeaderText = "jenis_data_barang"
        Me.PengurangstokDataGridViewTextBoxColumn.Name = "PengurangstokDataGridViewTextBoxColumn"
        Me.PengurangstokDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProdukBindingSource
        '
        Me.ProdukBindingSource.DataMember = "produk"
        Me.ProdukBindingSource.DataSource = Me.PosFakturDataSet
        '
        'PosFakturDataSet
        '
        Me.PosFakturDataSet.DataSetName = "posFakturDataSet"
        Me.PosFakturDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(13, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 281)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Isi Paket ]"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdprodukDataGridViewTextBoxColumn, Me.NamaDataGridViewTextBoxColumn1, Me.JumlahDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.Paket_detailBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.DataGridView1.Size = New System.Drawing.Size(494, 262)
        Me.DataGridView1.TabIndex = 0
        '
        'IdprodukDataGridViewTextBoxColumn
        '
        Me.IdprodukDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IdprodukDataGridViewTextBoxColumn.DataPropertyName = "id_produk"
        Me.IdprodukDataGridViewTextBoxColumn.HeaderText = "Kode Produk"
        Me.IdprodukDataGridViewTextBoxColumn.Name = "IdprodukDataGridViewTextBoxColumn"
        Me.IdprodukDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdprodukDataGridViewTextBoxColumn.Width = 94
        '
        'NamaDataGridViewTextBoxColumn1
        '
        Me.NamaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NamaDataGridViewTextBoxColumn1.DataPropertyName = "nama"
        Me.NamaDataGridViewTextBoxColumn1.HeaderText = "Nama"
        Me.NamaDataGridViewTextBoxColumn1.Name = "NamaDataGridViewTextBoxColumn1"
        Me.NamaDataGridViewTextBoxColumn1.ReadOnly = True
        Me.NamaDataGridViewTextBoxColumn1.Width = 60
        '
        'JumlahDataGridViewTextBoxColumn
        '
        Me.JumlahDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.JumlahDataGridViewTextBoxColumn.DataPropertyName = "jumlah"
        Me.JumlahDataGridViewTextBoxColumn.HeaderText = "Jumlah"
        Me.JumlahDataGridViewTextBoxColumn.Name = "JumlahDataGridViewTextBoxColumn"
        Me.JumlahDataGridViewTextBoxColumn.ReadOnly = True
        Me.JumlahDataGridViewTextBoxColumn.Width = 65
        '
        'Paket_detailBindingSource
        '
        Me.Paket_detailBindingSource.AllowNew = True
        Me.Paket_detailBindingSource.DataMember = "paket_detail"
        Me.Paket_detailBindingSource.DataSource = Me.PosFakturDataSet
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(857, 175)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(66, 52)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Refresh Data"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Maroon
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(857, 233)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(66, 52)
        Me.Button6.TabIndex = 7
        Me.Button6.Text = "E&xit"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Silver
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.ImageIndex = 0
        Me.Button3.ImageList = Me.ImageList
        Me.Button3.Location = New System.Drawing.Point(857, 71)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(66, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "&Delete"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "buttonhitam.jpg")
        Me.ImageList.Images.SetKeyName(1, "buttonbiru.jpg")
        Me.ImageList.Images.SetKeyName(2, "button.jpg")
        Me.ImageList.Images.SetKeyName(3, "button2.jpg")
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Silver
        Me.Button5.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button5.Enabled = False
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.ImageIndex = 0
        Me.Button5.ImageList = Me.ImageList
        Me.Button5.Location = New System.Drawing.Point(857, 124)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(66, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "&Cancel"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Silver
        Me.Button4.Enabled = False
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.ImageIndex = 0
        Me.Button4.ImageList = Me.ImageList
        Me.Button4.Location = New System.Drawing.Point(857, 100)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(66, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "&Save"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageIndex = 0
        Me.Button2.ImageList = Me.ImageList
        Me.Button2.Location = New System.Drawing.Point(857, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "&Edit"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList
        Me.Button1.Location = New System.Drawing.Point(857, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "&Add"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowDrop = True
        Me.DataGridView2.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NamaDataGridViewTextBoxColumn, Me.BiayaDataGridViewTextBoxColumn, Me.DiskonjmlmaxDataGridViewTextBoxColumn, Me.DiskonjmlDataGridViewTextBoxColumn, Me.StokDataGridViewTextBoxColumn, Me.PengurangstokDataGridViewCheckBoxColumn})
        Me.DataGridView2.DataSource = Me.Produk_paketBindingSource
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(935, 177)
        Me.DataGridView2.TabIndex = 0
        '
        'Produk_paketBindingSource
        '
        Me.Produk_paketBindingSource.AllowNew = True
        Me.Produk_paketBindingSource.DataMember = "produk_paket"
        Me.Produk_paketBindingSource.DataSource = Me.PosFakturDataSet
        '
        'ProdukTableAdapter
        '
        Me.ProdukTableAdapter.ClearBeforeFill = True
        '
        'Produk_paketTableAdapter
        '
        Me.Produk_paketTableAdapter.ClearBeforeFill = True
        '
        'Paket_detailTableAdapter
        '
        Me.Paket_detailTableAdapter.ClearBeforeFill = True
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        '
        'NamaDataGridViewTextBoxColumn
        '
        Me.NamaDataGridViewTextBoxColumn.DataPropertyName = "nama"
        Me.NamaDataGridViewTextBoxColumn.HeaderText = "nama"
        Me.NamaDataGridViewTextBoxColumn.Name = "NamaDataGridViewTextBoxColumn"
        '
        'BiayaDataGridViewTextBoxColumn
        '
        Me.BiayaDataGridViewTextBoxColumn.DataPropertyName = "biaya"
        Me.BiayaDataGridViewTextBoxColumn.HeaderText = "biaya"
        Me.BiayaDataGridViewTextBoxColumn.Name = "BiayaDataGridViewTextBoxColumn"
        '
        'DiskonjmlmaxDataGridViewTextBoxColumn
        '
        Me.DiskonjmlmaxDataGridViewTextBoxColumn.DataPropertyName = "diskon_jml_max"
        Me.DiskonjmlmaxDataGridViewTextBoxColumn.HeaderText = "diskon_jml_max"
        Me.DiskonjmlmaxDataGridViewTextBoxColumn.Name = "DiskonjmlmaxDataGridViewTextBoxColumn"
        '
        'DiskonjmlDataGridViewTextBoxColumn
        '
        Me.DiskonjmlDataGridViewTextBoxColumn.DataPropertyName = "diskon_jml"
        Me.DiskonjmlDataGridViewTextBoxColumn.HeaderText = "diskon_jml"
        Me.DiskonjmlDataGridViewTextBoxColumn.Name = "DiskonjmlDataGridViewTextBoxColumn"
        '
        'StokDataGridViewTextBoxColumn
        '
        Me.StokDataGridViewTextBoxColumn.DataPropertyName = "stok"
        Me.StokDataGridViewTextBoxColumn.HeaderText = "stok"
        Me.StokDataGridViewTextBoxColumn.Name = "StokDataGridViewTextBoxColumn"
        '
        'PengurangstokDataGridViewCheckBoxColumn
        '
        Me.PengurangstokDataGridViewCheckBoxColumn.DataPropertyName = "pengurang_stok"
        Me.PengurangstokDataGridViewCheckBoxColumn.HeaderText = "pengurang_stok"
        Me.PengurangstokDataGridViewCheckBoxColumn.Name = "PengurangstokDataGridViewCheckBoxColumn"
        '
        'Form_paket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(935, 477)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form_paket"
        Me.Text = "Data Paket Produk dan Perawatan"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdukBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PosFakturDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Paket_detailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Produk_paketBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView0 As System.Windows.Forms.DataGridView
    Friend WithEvents PosFakturDataSet As PROJECT_KLINIK.posFakturDataSet
    Friend WithEvents ProdukBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProdukTableAdapter As PROJECT_KLINIK.posFakturDataSetTableAdapters.produkTableAdapter
    Friend WithEvents IdDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BiayaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KetDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StokDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PengurangstokDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents Produk_paketTableAdapter As PROJECT_KLINIK.posFakturDataSetTableAdapters.produk_paketTableAdapter
    Friend WithEvents Produk_paketBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Paket_detailTableAdapter As PROJECT_KLINIK.posFakturDataSetTableAdapters.paket_detailTableAdapter
    Friend WithEvents Paket_detailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents IdprodukDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JumlahDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NamaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BiayaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiskonjmlmaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiskonjmlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StokDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PengurangstokDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
