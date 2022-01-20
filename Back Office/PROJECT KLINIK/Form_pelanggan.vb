Public Class Form_pelanggan
    Dim intChangesCounter As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refresh_table()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        refresh_table()
    End Sub

    Private Sub refresh_table()
        Try
            'TODO: This line of code loads data into the 'PosFakturDataSet.pelanggan' table. You can move, or remove it, as needed.
            Me.PelangganTableAdapter.FillByDataPelanggan(Me.PosFakturDataSet.pelanggan, _
                "%" & TextBox1.Text & "%", "%" & TextBox2.Text & "%", "%" & TextBox3.Text & "%")

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        refresh_table()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Ubah data Lama
        If Me.PosFakturDataSet.pelanggan.GetChanges() IsNot Nothing Then
            intChangesCounter = Me.PelangganTableAdapter.Update(Me.PosFakturDataSet.pelanggan)
            MsgBox(intChangesCounter.ToString & " Record(s) Processed")
        End If
        Button2.Enabled = False
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        refresh_table()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        refresh_table()
    End Sub
End Class