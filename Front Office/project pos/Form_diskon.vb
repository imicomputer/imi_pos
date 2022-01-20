Public Class Form_diskon
    
    Private Sub buat_tombol_diskon(ByVal btnname As String)
        Dim lebar As Integer
        lebar = FlowLayoutPanel1.Width
        'Isi panel 1
        'ambil data barang untuk ngebuat tombol
        ambildata_diskon()

        For Each DTrow As DataRow In DTset.Tables(0).Rows
            Dim newbutton As New Button

            newbutton.Width = (lebar / 5) - 10
            newbutton.Height = 50

            newbutton.Name = btnname

            AddHandler newbutton.Click, AddressOf pilih_diskon
            'AddHandler newbutton.MouseHover, AddressOf tombol_hover
            'AddHandler newbutton.MouseLeave, AddressOf tombol_leave
            If DTrow.Item("Jenis").ToString.ToLower = "persentase" Then
                newbutton.ForeColor = Color.White
                newbutton.BackColor = Color.Maroon
                newbutton.Text = FormatPercent(DTrow.Item("jml"), 0)
            ElseIf DTrow.Item("Jenis").ToString.ToLower = "voucher" Then
                newbutton.Location.Offset(0, 0)
                newbutton.ForeColor = Color.Black
                newbutton.BackColor = Color.Yellow
                newbutton.Text = FormatNumber(DTrow.Item("jml"), 0)
            End If
            newbutton.Cursor = Cursors.Hand
            newbutton.Tag = DTrow.Item("Jenis") & "|" & DTrow.Item("jml") & "|" & DTrow.Item("id")
            FlowLayoutPanel1.Controls.Add(newbutton)
        Next
    End Sub

    Private Sub Form_diskon_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load   
        buat_tombol_diskon("diskon")
    End Sub

    Sub pilih_diskon(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim thisButton As Button
        Dim StrTemp() As String
        thisButton = sender
        StrTemp = thisButton.Tag.Split("|")
        TextBox1.Text = StrTemp(0)
        TextBox2.Text = StrTemp(1)
        If jdiskon = Nothing Or frmPemanggil = "Form_kasir_sentuh" Then
            jdiskon = StrTemp(0)
            ndiskon = StrTemp(1)
            idDiskon = StrTemp(2)
        End If
        removebutton()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmPemanggil = Nothing
        removebutton()
    End Sub
    Sub removebutton()
        Dim jml As Integer
        jml = FlowLayoutPanel1.Controls.Count
        For i = 1 To jml
            FlowLayoutPanel1.Controls.RemoveByKey("diskon")
        Next
        Me.Refresh()
        Me.Close()

    End Sub
End Class