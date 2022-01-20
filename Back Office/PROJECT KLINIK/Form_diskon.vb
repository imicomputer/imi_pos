Public Class Form_diskon
    Dim intChangesCounter As Integer

    Private Sub Form_diskon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refresh_table()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        refresh_table()
    End Sub

    Private Sub refresh_table()
        Try
            'TODO: This line of code loads data into the 'PosFakturDataSet.diskon' table. You can move, or remove it, as needed.
            Me.DiskonTableAdapter.Fill(Me.PosFakturDataSet.diskon)

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Button1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Ubah Data Lama
        If Me.PosFakturDataSet.diskon.GetChanges() IsNot Nothing Then
            intChangesCounter = Me.DiskonTableAdapter.Update(Me.PosFakturDataSet.diskon)
            MsgBox(intChangesCounter.ToString & " Record(s) Processed")
        End If

        Button1.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Me.DiskonTableAdapter.FillByNama(Me.PosFakturDataSet.diskon, "%" & TextBox1.Text.Replace("'", "''") & "%")
    End Sub
End Class