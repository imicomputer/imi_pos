Imports MySql.Data
Public Class Form_product
    Dim perintah As String

    Private Sub Form_jasa_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'konek("localhost", "root", "Sparkling123", "pos")
        konek(My.Settings.serverDB.ToString, _
                My.Settings.penggunaDB.ToString, _
                My.Settings.kunciDB.ToString, _
                My.Settings.namaDB.ToString)
        perintah = "normal"
        refresh_tabel(DataGridView1)
    End Sub

    Private Sub refresh_tabel(ByRef statusView As DataGridView)
        'perintah untuk me-refresh data pada datagridview1
        Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
        Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQL As String

        SQL = "SELECT produk.* FROM produk " & _
            "LEFT OUTER JOIN paket_detail ON produk.id = paket_detail.id_produk_paket " & _
            "WHERE paket_detail.id_produk_paket IS NULL " & _
            "ORDER BY produk.id asc"
        Try
            myCommand.Connection = conn
            myCommand.CommandText = SQL

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            statusView.DataSource = myData
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.Columns(0).Width = 80
            DataGridView1.Columns(1).Width = 220
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 340
            DataGridView1.Columns(4).Width = 40
            DataGridView1.Columns(5).Width = 40
            DataGridView1.Columns(6).Width = 40
            DataGridView1.Columns(7).Width = 80

            DataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.Columns(0).HeaderText = "Kode"
            DataGridView1.Columns(1).HeaderText = "Nama Produk"
            DataGridView1.Columns(2).HeaderText = "Biaya"
            DataGridView1.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.Columns(3).HeaderText = "Keterangan"
            DataGridView1.Columns(4).HeaderText = "Min Beli"
            DataGridView1.Columns(5).HeaderText = "Bonus"
            DataGridView1.Columns(6).HeaderText = "Stok"
            DataGridView1.Columns(7).HeaderText = "Data Barang"

        Catch myerror As MySql.Data.MySqlClient.MySqlException
            MsgBox("There was an error reading from the database: " & myerror.Message)
        End Try
    End Sub

    Private Sub Data_Form_Update()
        konek(My.Settings.serverDB.ToString, _
                My.Settings.penggunaDB.ToString, _
                My.Settings.kunciDB.ToString, _
                My.Settings.namaDB.ToString)
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim jml As Integer
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT count(produk.id) from produk " & _
            "LEFT OUTER JOIN paket_detail ON produk.id = paket_detail.id_produk_paket " & _
            "WHERE paket_detail.id_produk_paket IS NULL"
        cmd.Connection = conn
        jml = cmd.ExecuteScalar.ToString
        diskonek()
        If jml > 0 Then
            'kalau datagridview1 di klik tampilkan data ke textbox
            TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
            TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value
            TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value
            TextBox5.Text = DataGridView1.CurrentRow.Cells(4).Value
            TextBox6.Text = DataGridView1.CurrentRow.Cells(5).Value
            TextBox7.Text = DataGridView1.CurrentRow.Cells(6).Value
            If DataGridView1.CurrentRow.Cells(7).Value = 1 Then
                CheckBox1.Checked = True
            Else
                CheckBox1.Checked = False
            End If
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()
        End If
        If e.KeyCode = Keys.Escape Then
            If Button6.Enabled Then
                Button6.PerformClick()
            End If
        End If
    End Sub

    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        Data_Form_Update()
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Data_Form_Update()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        aturtombol(False, True)
        kosongin()
        kunci(False)
        TextBox1.Focus()
        perintah = "add"
    End Sub

    Sub aturtombol(ByVal t1 As Boolean, ByVal t2 As Boolean)
        Button1.Enabled = t1
        Button2.Enabled = t1
        Button3.Enabled = t2
        Button4.Enabled = t2
        Button5.Enabled = t1
        Button6.Enabled = t1
        DataGridView1.Enabled = t1
    End Sub
    Sub kosongin()
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox3.Text = Nothing
        TextBox4.Text = Nothing
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = 0
        CheckBox1.Checked = False
    End Sub

    Sub kunci(ByVal kc1 As Boolean)
        TextBox1.ReadOnly = kc1
        TextBox2.ReadOnly = kc1
        TextBox3.ReadOnly = kc1
        TextBox4.ReadOnly = kc1
        TextBox5.ReadOnly = kc1
        TextBox6.ReadOnly = kc1
        TextBox7.ReadOnly = kc1
        CheckBox1.Enabled = Not kc1
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        'perintah tombol edit (ubah data)
        If (TextBox1.Text) <> Nothing Then
            perintah = "edit"
            aturtombol(False, True)
            kunci(False)
            TextBox1.ReadOnly = True
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If (e.KeyChar = Chr(13)) Then
            TextBox2.Focus()
            TextBox1.Text = TextBox1.Text.ToUpper
        End If
        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (e.KeyChar = Chr(13)) Then
            TextBox3.Focus()
        End If
        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        'textbox3 hanya boleh di isi dengan angka
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

        If (e.KeyChar = Chr(13)) Then
            TextBox4.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub
    Private Sub Button1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        Button1.Image = ImageList1.Images(1)
    End Sub
    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.Image = ImageList1.Images(0)
    End Sub
    Private Sub Button2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseHover
        Button2.Image = ImageList1.Images(1)
    End Sub
    Private Sub Button2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.Image = ImageList1.Images(0)
    End Sub
    Private Sub button3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseHover
        Button3.Image = ImageList1.Images(1)
    End Sub
    Private Sub button3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.Image = ImageList1.Images(0)
    End Sub
    Private Sub button4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        Button4.Image = ImageList1.Images(1)
    End Sub
    Private Sub button4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.MouseLeave
        Button4.Image = ImageList1.Images(0)
    End Sub
    Private Sub button5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseHover
        Button5.Image = ImageList1.Images(1)
    End Sub
    Private Sub button5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        Button5.Image = ImageList1.Images(0)
    End Sub
    Private Sub button6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.MouseHover
        Button6.Image = ImageList1.Images(1)
    End Sub
    Private Sub button6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.MouseLeave
        Try
            Button6.Image = ImageList1.Images(0)
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'perintah tombol Save (simpan)
        Dim kdjasa As String
        Dim sql As String
        Dim jawab As New MsgBoxResult

        'cek apakah data di texbox sudah diisi
        If TextBox1.Text = Nothing Then
            MsgBox("Kode treatment harus di isi", MsgBoxStyle.Information, "info")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = Nothing Then
            MsgBox("Nama treatment harus di isi", MsgBoxStyle.Information, "info")
            TextBox2.Focus()
            Exit Sub
        End If
        If TextBox3.Text = Nothing Then
            MsgBox("Biaya  harus di isi", MsgBoxStyle.Information, "info")
            TextBox3.Focus()
            Exit Sub
        End If
        If TextBox4.Text = Nothing Then
            MsgBox("Keterangan  harus di isi", MsgBoxStyle.Information, "info")
            TextBox4.Focus()
            Exit Sub
        End If
        If TextBox5.Text = Nothing Then
            MsgBox("Min Beli harus di isi", MsgBoxStyle.Information, "info")
            TextBox5.Focus()
            Exit Sub
        End If
        If TextBox5.Text > 0 Then
            If TextBox6.Text = 0 Or TextBox6.Text = Nothing Then
                MsgBox("Bonus Beli harus di isi", MsgBoxStyle.Information, "info")
                TextBox6.Focus()
                Exit Sub
            End If
        End If
        If TextBox6.Text = Nothing Then
            MsgBox("Bonus  harus di isi", MsgBoxStyle.Information, "info")
            TextBox4.Focus()
            Exit Sub
        End If
        If TextBox6.Text = Nothing Then
            MsgBox("Stok harus di isi", MsgBoxStyle.Information, "info")
            TextBox6.Focus()
            Exit Sub
        End If

        If CheckBox1.Checked = True Then
            If TextBox7.Text = 0 Or TextBox7.Text = Nothing Then
                MsgBox("Pilihan sts Stok telah di centang, Stok harus di isi", MsgBoxStyle.Information, "info")
                TextBox7.SelectionStart = 0
                TextBox7.SelectionLength = TextBox7.Text.Length
                TextBox7.Focus()
                Exit Sub
            End If
        End If

        If CheckBox1.Checked = False Then
            If TextBox7.Text > 0 Then
                MsgBox("Data tidak dapat di simpan, Pilihan sts Stok harus di centang", MsgBoxStyle.Information, "info")
                TextBox7.Focus()
                Exit Sub
            End If
        End If

        'Jika simpan data baru
        If perintah = "add" Then
            kdjasa = TextBox1.Text
            'Cek kode sudah ada apa belom
            konek(My.Settings.serverDB.ToString, _
                    My.Settings.penggunaDB.ToString, _
                    My.Settings.kunciDB.ToString, _
                    My.Settings.namaDB.ToString)
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim jml As Integer
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT count(id) from produk where id='" & kdjasa & "'"
            cmd.Connection = conn
            jml = cmd.ExecuteScalar.ToString
            diskonek()
            If jml > 0 Then
                MessageBox.Show("Maaf kode sudah ada, coba di cek kembali data nya")
            Else
                'Simpan data baru
                Dim strSave, pengurang_stok As Boolean
                If CheckBox1.Checked = True Then
                    pengurang_stok = 1
                Else
                    pengurang_stok = 0
                End If
                sql = "INSERT INTO `pos`.`produk` SET `Id`='" & Trim(Replace(TextBox1.Text.ToUpper, "'", "''")) & "', `nama`='" & Trim(Replace(TextBox2.Text, "'", "''")) & "', `biaya`=" & Trim(TextBox3.Text) & ", `ket`='" & Trim(Replace(TextBox4.Text, "'", "''")) & "', `diskon_jml_max`=" & Trim(Replace(TextBox5.Text, "'", "''")) & ", `diskon_jml`=" & Trim(Replace(TextBox6.Text, "'", "''")) & ", `stok`=" & Trim(TextBox7.Text) & ", `pengurang_stok`=" & pengurang_stok & ";"
                strSave = ExecNonQuery(sql)

                If strSave = "True" Then
                    MsgBox("Data Telah di simpan", MsgBoxStyle.Information)
                    refresh_tabel(DataGridView1)
                Else
                    MsgBox(strSave)
                End If

                'normalkan tampilan form
                aturtombol(True, False)
                kunci(True)
                Button1.Focus()
                perintah = "normal"
                refresh_tabel(DataGridView1)
            End If
        ElseIf perintah = "edit" Then   'jika ubah atau edit data maka
            'simpan perubahan data
            Dim strSave, pengurang_stok As Boolean
            If CheckBox1.Checked = True Then
                pengurang_stok = 1
            Else
                pengurang_stok = 0
            End If
            sql = "UPDATE `pos`.`produk` SET `nama`='" & Trim(Replace(TextBox2.Text, "'", "''")) & "', `biaya`=" & Trim(TextBox3.Text) & ", `ket`='" & Trim(Replace(TextBox4.Text, "'", "''")) & "', `diskon_jml_max`=" & Trim(TextBox5.Text) & ", `diskon_jml`=" & Trim(TextBox6.Text) & ", `stok`=" & Trim(TextBox7.Text) & ", `pengurang_stok`=" & pengurang_stok & " WHERE `Id`='" & Trim(TextBox1.Text) & "';"
            strSave = ExecNonQuery(sql)

            If strSave = "True" Then
                MsgBox("Data Telah di simpan", MsgBoxStyle.Information)
                refresh_tabel(DataGridView1)
            Else
                MsgBox(strSave)
            End If

            'normalkan tampilan form
            TextBox1.ReadOnly = False
            aturtombol(True, False)
            kunci(True)
            perintah = "normal"
            refresh_tabel(DataGridView1)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Perintah tombol cancel (batalkan perintah)
        aturtombol(True, False)
        kunci(True)
        refresh_tabel(DataGridView1)
        DataGridView1.Focus()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'perintah tombol exit
        diskonek()      'tutup koneksi ke database
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'perintah tombol delete (hapus data)
        Dim kdjasa As String
        Dim jawab As New MsgBoxResult

        kdjasa = TextBox1.Text
        jawab = MsgBox("Hapus data Produk [" & TextBox1.Text & "] ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Konfirmasi")
        If jawab = MsgBoxResult.Yes Then
            If kdjasa <> "" Then
                'Delete the selected record
                Dim strDeleted As Boolean

                strDeleted = ExecNonQuery("DELETE FROM produk WHERE id= '" & kdjasa & "'")

                If strDeleted = "True" Then
                    MsgBox("Data Telah di hapus", MsgBoxStyle.Information)
                    kosongin()
                    refresh_tabel(DataGridView1)
                Else
                    MsgBox(strDeleted)
                End If
            Else
                MsgBox("Silahkan pilih data yang ingin dihapus", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Data batal dihapus!", MsgBoxStyle.Information, "info")
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If (e.KeyChar = Chr(13)) Then
            TextBox5.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (e.KeyChar = Chr(13)) Then
            TextBox6.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub


    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (e.KeyChar = Chr(13)) Then
            TextBox7.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (e.KeyChar = Chr(13)) Then
            CheckBox1.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub Form_product_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        DataGridView1.Focus()
    End Sub

    Private Sub CheckBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CheckBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub
End Class