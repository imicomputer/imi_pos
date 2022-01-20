Public Class cetak_faktur

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dsCetakFaktur.cetak_faktur' table. You can move, or remove it, as needed.
        Me.cetak_fakturTableAdapter.Fill(Me.dsCetakFaktur.cetak_faktur, kirim_no_faktur)

        Me.ReportViewer1.LocalReport.EnableExternalImages = True
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class