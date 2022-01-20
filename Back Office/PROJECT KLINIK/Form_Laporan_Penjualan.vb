Public Class Form_Laporan_Penjualan
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DateValue(DateTimePicker2.Text) < DateValue(DateTimePicker1.Text) Then
            MsgBox("Tanggal Akhir harus Lebih Besar dari Tanggal Awal!", MsgBoxStyle.Exclamation)
        Else
            Try
                Me.ReportViewer1.LocalReport.EnableExternalImages = True

                'TODO: This line of code loads data into the 'posFakturDataSet.DataFaktur' table. You can move, or remove it, as needed.
                Me.DataFakturTableAdapter.FillBy(posFakturDataSet.DataFaktur, Format(DateValue(DateTimePicker1.Text), "yyyy-MM-dd"), Format(DateValue(DateTimePicker2.Text), "yyyy-MM-dd"))
                'Me.DataFakturTableAdapter.FillByTotalPerDay(posFakturDataSet.DataFaktur, Format(DateValue(DateTimePicker1.Text), "yyyy-MM-dd"), Format(DateValue(DateTimePicker2.Text), "yyyy-MM-dd"))

                Me.ReportViewer1.RefreshReport()

            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class