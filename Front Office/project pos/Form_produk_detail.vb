Imports MySql.Data.MySqlClient
Public Class Form_produk_detail
    Private Function hitung_diskon(ByVal dblHargaProduk As Double, ByVal intJmlBeli As Integer, ByVal strJenisDiskon As String, ByVal dblJmlDiskon As Double)
        hitung_diskon = 0

        If frmPemanggil <> Nothing Then
            If strJenisDiskon = "persentase" Then
                hitung_diskon = ((dblHargaProduk * intJmlBeli) * dblJmlDiskon)
            ElseIf strJenisDiskon = "voucher" Then
                hitung_diskon = (dblJmlDiskon)
            End If
        End If
    End Function

    Private Sub Form_produk_detail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If frmPemanggil = "Rincian Produk" Then
            TextBox2.Text = hitung_diskon(Val(Label9.Text), Val(TextBox1.Text), Form_diskon.TextBox1.Text.ToLower, Val(Form_diskon.TextBox2.Text))
        End If
        Me.Refresh()
        TextBox1.Focus()
        TextBox1.SelectAll()
    End Sub

    Private Sub Form_produk_detail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = 0
        TextBox2.Text = 0

        ambildata_produk(txt_jenisbarang.Text, Label7.Text)
        With DTset.Tables("produk")
            Label8.Text = .Rows(0).Item("nama").ToString
            Label9.Text = .Rows(0).Item("biaya").ToString
            Label10.Text = .Rows(0).Item("stok").ToString
            Label11.Text = .Rows(0).Item("ket").ToString
        End With

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmPemanggil = Nothing
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmPemanggil = Nothing
        'Cek Isi Jumlah Pembelian
        If Val(TextBox1.Text) < 1 Then
            MsgBox("Jumlah harus diisi", MsgBoxStyle.Exclamation)
            TextBox1.Focus()
            TextBox1.SelectAll()
        Else
            'Cek Jenis Produk
            If Val(txt_jenisbarang.Text) = 1 Then
                If Val(TextBox1.Text) > Val(Label10.Text) Then
                    MsgBox("Persediaan tidak mencukupi", MsgBoxStyle.Information)
                    TextBox1.Focus()
                    TextBox1.SelectAll()
                ElseIf (Val(Label9.Text) * Val(TextBox1.Text)) - Val(TextBox2.Text) < 0 Then
                    MsgBox("Nilai Diskon Melebihi Jumlah Beli", MsgBoxStyle.Critical)
                Else
                    simpan_detil_faktur()
                End If
            Else
                simpan_detil_faktur()
            End If
        End If
    End Sub

    Private Sub simpan_detil_faktur()
        Try
            Dim intJmlProdukAkhir As Integer
            Dim dblTotal As Double = (Val(Label9.Text) * Val(TextBox1.Text))

            'Simpan data Detil Faktur
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)

            sql = "INSERT INTO `pos`.`faktur_detail` " & _
                    "(`no_faktur`, " & _
                    "`id_produk`, " & _
                    "`harga`, " & _
                    "`jml_beli`, " & _
                    "`total`, " & _
                    "`diskon`, " & _
                    "`tot_stlh_diskon`, " & _
                    "`free`) " & _
                "VALUES (" & _
                    "'" & Form_kasir_sentuh.TextBox1.Text & "', " & _
                    "'" & Label7.Text & "', " & _
                    "'" & Label9.Text & "', " & _
                    "'" & TextBox1.Text & "', " & _
                    "'" & dblTotal & "', " & _
                    "'" & TextBox2.Text & "', " & _
                    "'" & (Val(dblTotal) - Val(TextBox2.Text)) & "', " & _
                    "'0');"
            ExecNonQuery(sql)

            'Jika Produk berupa Barang akan kurangi stok
            If txt_jenisbarang.Text = "1" Then
                intJmlProdukAkhir = (Val(Label10.Text) - Val(TextBox1.Text))
            Else
                intJmlProdukAkhir = Val(Label10.Text)
            End If

            sql = "UPDATE `pos`.`produk` SET stok = (" & Val(intJmlProdukAkhir) & ") WHERE id='" & Label7.Text & "'"
            ExecNonQuery(sql)

            diskonek()
            Form_kasir_sentuh.tampil_detil_faktur(Form_kasir_sentuh.TextBox1.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 13) Then
            If TextBox1.Text = Nothing Then
                TextBox1.Focus()
            Else
                Button1.Focus()
            End If
        End If
    End Sub

    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.ForeColor = Color.Yellow
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.LostFocus
        Button1.ForeColor = Color.White
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If txt_jenisbarang.Text = 1 Then
            If Val(TextBox1.Text) > Val(Label10.Text) Then
                TextBox1.Text = Label10.Text
                TextBox1.Focus()
                TextBox1.SelectAll()
            Else
                TextBox2.Text = hitung_diskon(Val(Label9.Text), Val(TextBox1.Text), Form_diskon.TextBox1.Text.ToLower, Val(Form_diskon.TextBox2.Text))
            End If
        Else
            TextBox2.Text = hitung_diskon(Val(Label9.Text), Val(TextBox1.Text), Form_diskon.TextBox1.Text.ToLower, Val(Form_diskon.TextBox2.Text))
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmPemanggil = Me.Text
        Form_diskon.ShowDialog()
    End Sub
End Class