Imports MySql.Data.MySqlClient
Public Class Form_Find_pelanggan
    Dim currentRow As Integer
    Private Sub Form_Find_pelanggan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'DsPelanggan.pelanggan' table. You can move, or remove it, as needed.
        Me.PelangganTableAdapter.Fill(Me.DsPelanggan.pelanggan)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'tampilkan detail faktur
        Form_kasir_sentuh.tampil_detil_faktur(Form_kasir_sentuh.TextBox1.Text)
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Me.PelangganTableAdapter.FillByNamaAndTelepon( _
            Me.DsPelanggan.pelanggan, _
            "%" & Replace(TextBox1.Text, "'", "''") & "%", _
            "%" & Replace(TextBox2.Text, "'", "") & "%")
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Me.PelangganTableAdapter.FillByNamaAndTelepon( _
            Me.DsPelanggan.pelanggan, _
            "%" & Replace(TextBox1.Text, "'", "''") & "%", _
            "%" & Replace(TextBox2.Text, "'", "") & "%")
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Form_kasir_sentuh.TextBox2.Text = DataGridView1.CurrentRow.Cells(0).Value
        Form_kasir_sentuh.TextBox3.Text = DataGridView1.CurrentRow.Cells(1).Value

        Form_kasir_sentuh.tampil_detil_faktur(Form_kasir_sentuh.TextBox1.Text)
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        virtualBuka(TextBox1)
    End Sub
End Class