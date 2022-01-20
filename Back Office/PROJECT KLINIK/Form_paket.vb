Public Class Form_paket
    Dim strStatusProses As String = ""

    Private Sub Form_paket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refresh_table()

        atur_tombol(True, False)
        kunci_form(True)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Kosongkan isi form
        kosong_form()
        kunci_form(False)

        'Atur Status Tombol
        atur_tombol(False, True)

        'Tentukan Status Proses
        strStatusProses = "tambah"

        DataGridView2.Focus()
        'MsgBox("Add Rows Allowed?" & DataGridView2.AllowUserToAddRows.ToString)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Microsoft.VisualBasic.Asc(e.KeyChar) = 13 Or Microsoft.VisualBasic.Asc(e.KeyChar) = Keys.Tab Then
            'Pastikan isi Stok tidak melebihi maksimum stok produk yang tersedia

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim strIdProduk As String = ""
        Dim intJmlData As Integer = 0
        Dim ChangesCounter As Integer = 0
        Dim strMsg As String = ""

        If strStatusProses.ToLower = "tambah" Then
            ''---Simpan data Baru---''
            Try
                DataGridView2.EndEdit()

                For i = 0 To DataGridView2.Rows.Count - 1
                    strIdProduk = DataGridView2.Rows(i).Cells(0).Value

                    'Cek keberadaan data baru
                    konek(My.Settings.serverDB.ToString, _
                            My.Settings.penggunaDB.ToString, _
                            My.Settings.kunciDB.ToString, _
                            My.Settings.namaDB.ToString)
                    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT count(id) from produk where id='" & strIdProduk & "'"
                    cmd.Connection = conn
                    intJmlData = cmd.ExecuteScalar.ToString
                    diskonek()

                    If intJmlData > 0 Then
                        'MessageBox.Show("Maaf Kode Paket sudah ada, silahkan diperiksa kembali datanya")
                        strMsg &= (DataGridView2.Rows(i).Cells(0).Value & " ada " & intJmlData) & vbCrLf
                    Else
                        strMsg &= (DataGridView2.Rows(i).Cells(0).Value & " ada " & intJmlData) & vbCrLf
                        'ChangesCounter = Me.Produk_paketTableAdapter.Update(Me.PosFakturDataSet.produk_paket)
                    End If
                Next

                MsgBox(strMsg)

                MsgBox(ChangesCounter.ToString & " Record(s) Changed")
                'If Me.PosFakturDataSet.GetChanges() IsNot Nothing Then
                'Else
                '    MsgBox("Nothing was changed")
                'End If

                '--Simpan data baru--'
                'Buat produk baru untuk penampung paket
                'sql = "INSERT INTO `pos`.`produk` " & _
                '    "(`Id`, `nama`, `biaya`, `stok`, `pengurang_stok`) " & _
                '    "VALUES (" & _
                '        "'" & Trim(Replace(TextBox1.Text.ToUpper, "'", "''")) & "', " & _
                '        "'" & Trim(Replace(TextBox2.Text, "'", "''")) & "', " & _
                '        "'" & Val(Trim(TextBox3.Text)) & "', " & _
                '        "'" & Val(Trim(TextBox4.Text)) & "', " & _
                '        "" & intPengurangStok & _
                '    ");"
                'ExecNonQuery(sql)

                ''Buat detil paket atas produk baru yg dibuat
                'sql = "INSERT INTO `pos`.`paket_detail` (`id_produk_paket`) " & _
                '    "VALUES ('" & Trim(Replace(TextBox1.Text.ToUpper, "'", "''")) & "');"
                'ExecNonQuery(sql)

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                MsgBox("Data Telah di simpan", MsgBoxStyle.Information)
            End Try
        ElseIf strStatusProses.ToLower = "ubah" Then
            'Ubah data Lama
            If Me.PosFakturDataSet.produk_paket.GetChanges() IsNot Nothing Then
                ChangesCounter = Me.Produk_paketTableAdapter.Update(Me.PosFakturDataSet.produk_paket)
                MsgBox(ChangesCounter.ToString & " Record(s) Changed")
            Else
                MsgBox("Nothing was changed")
            End If

        End If

        'normalkan tampilan form
        atur_tombol(True, False)
        kunci_form(True)
        Button1.Focus()
        strStatusProses = "normal"

        refresh_table()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        atur_tombol(True, False)
        kunci_form(True)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub kunci_form(ByVal boolFormLock As Boolean)
        'TextBox1.ReadOnly = boolFormLock
        'TextBox2.ReadOnly = boolFormLock
        'TextBox3.ReadOnly = boolFormLock
        'TextBox4.ReadOnly = boolFormLock
        'CheckBox1.Enabled = Not boolFormLock

        DataGridView1.Enabled = Not boolFormLock
        DataGridView1.ReadOnly = boolFormLock

        'DataGridView2.Enabled =  boolFormLock
        DataGridView2.ReadOnly = boolFormLock
        Me.Produk_paketBindingSource.AllowNew = Not boolFormLock
    End Sub

    Private Sub kosong_form()
        'TextBox1.Text = Nothing
        'TextBox2.Text = Nothing
        'TextBox3.Text = Nothing
        'TextBox4.Text = Nothing
        'CheckBox1.Checked = False
    End Sub

    Private Sub atur_tombol(ByVal status1 As Boolean, ByVal status2 As Boolean)
        Button1.Enabled = status1
        Button2.Enabled = status1
        Button3.Enabled = status1
        Button4.Enabled = status2
        Button5.Enabled = status2
        Button6.Enabled = status1
    End Sub

    Private Sub refresh_table()
        Try
            'TODO: This line of code loads data into the 'PosFakturDataSet.produk' table. You can move, or remove it, as needed.
            Me.ProdukTableAdapter.Fill(Me.PosFakturDataSet.produk)

            'TODO: This line of code loads data into the 'PosFakturDataSet.produk_paket' table. You can move, or remove it, as needed.
            Me.Produk_paketTableAdapter.Fill(Me.PosFakturDataSet.produk_paket)

            'TODO: This line of code loads data into the 'PosFakturDataSet.paket_detail' table. You can move, or remove it, as needed.
            Me.Paket_detailTableAdapter.FillBySelectedProduk(Me.PosFakturDataSet.paket_detail, DataGridView2.CurrentRow.Cells(0).Value)

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        Try
            'TODO: This line of code loads data into the 'PosFakturDataSet.paket_detail' table. You can move, or remove it, as needed.
            Me.Paket_detailTableAdapter.FillBySelectedProduk(Me.PosFakturDataSet.paket_detail, DataGridView2.CurrentRow.Cells(0).Value)

        Catch ex As System.Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        atur_tombol(False, True)
        kunci_form(False)
        strStatusProses = "ubah"
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        refresh_table()

    End Sub
End Class