Imports MySql.Data

Public Class Form1
    Dim perintah As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        konek("localhost", "root", "Sparkling123", "pos")
        perintah = "normal"
        refresh_tabel(DataGridView1)
    End Sub
    Private Sub refresh_tabel(ByRef statusView As DataGridView)
        'perintah untuk me-refresh data pada datagridview1
        Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
        Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQL As String

        SQL = "select * from barang order by id_barang desc"
        Try
            myCommand.Connection = conn
            myCommand.CommandText = SQL

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            statusView.DataSource = myData
            'DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.Columns(0).Width = 75
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 50
            DataGridView1.Columns(4).Width = 60
            DataGridView1.Columns(5).Width = 50
            DataGridView1.Columns(6).Width = 50
            DataGridView1.Columns(7).Width = 375

            DataGridView1.Columns(0).HeaderText = "Kode"
            DataGridView1.Columns(1).HeaderText = "Nama"
            DataGridView1.Columns(2).HeaderText = "Jenis"
            DataGridView1.Columns(3).HeaderText = "Ukuran"
            DataGridView1.Columns(4).HeaderText = "Kemasan"
            DataGridView1.Columns(5).HeaderText = "Stok"
            DataGridView1.Columns(6).HeaderText = "Harga"
            DataGridView1.Columns(7).HeaderText = "Keterangan"
        Catch myerror As MySql.Data.MySqlClient.MySqlException
            MsgBox("There was an error reading from the database: " & myerror.Message)
        End Try
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
        ComboBox1.Text = Nothing
        TextBox5.Text = Nothing
        TextBox6.Text = Nothing
        TextBox7.Text = Nothing
        TextBox8.Text = Nothing
    End Sub
    Sub kunci(ByVal kc1 As Boolean)
        TextBox1.ReadOnly = kc1
        TextBox2.ReadOnly = kc1
        TextBox3.ReadOnly = kc1
        TextBox4.ReadOnly = kc1
        TextBox5.ReadOnly = kc1
        TextBox6.ReadOnly = kc1
        TextBox7.ReadOnly = kc1
        TextBox8.ReadOnly = kc1
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        konek("localhost", "root", "Sparkling123", "pos")
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim jml As Integer
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT count(id_barang) from barang"
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
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(4).Value
            TextBox6.Text = DataGridView1.CurrentRow.Cells(5).Value
            TextBox7.Text = DataGridView1.CurrentRow.Cells(6).Value
            TextBox8.Text = DataGridView1.CurrentRow.Cells(7).Value
        End If
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        aturtombol(False, True)
        kosongin()
        kunci(False)
        ComboBox1.Visible = True
        TextBox1.Focus()
        perintah = "add"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'perintah tombol Save (simpan)
        Dim kdbarang As String
        Dim sql As String
        Dim jawab As New MsgBoxResult

        'cek apakah data di texbox sudah diisi
        If TextBox1.Text = Nothing Then
            MsgBox("Kode barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = Nothing Then
            MsgBox("Nama barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox2.Focus()
            Exit Sub
        End If
        If TextBox3.Text = Nothing Then
            MsgBox("Jenis barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox3.Focus()
            Exit Sub
        End If
        If TextBox4.Text = Nothing Then
            MsgBox("Ukuran barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox4.Focus()
            Exit Sub
        End If
        If ComboBox1.Text = Nothing Then
            MsgBox("Kemasan barang harus di isi", MsgBoxStyle.Information, "info")
            ComboBox1.Focus()
            Exit Sub
        End If

        If TextBox6.Text = Nothing Then
            MsgBox("Stok barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox6.Focus()
            Exit Sub
        End If
        If TextBox7.Text = Nothing Then
            MsgBox("harga barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox7.Focus()
            Exit Sub
        End If
        If TextBox8.Text = Nothing Then
            MsgBox("Keterangan barang harus di isi", MsgBoxStyle.Information, "info")
            TextBox8.Focus()
            Exit Sub
        End If
        'Jika simpan data baru
        If perintah = "add" Then
            kdbarang = TextBox1.Text
            'Cek kode sudah ada apa belom
            konek("localhost", "root", "Sparkling123", "pos")
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim jml As Integer
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT count(id_barang) from barang where id_barang='" & kdbarang & "'"
            cmd.Connection = conn
            jml = cmd.ExecuteScalar.ToString
            diskonek()
            If jml > 0 Then
                MessageBox.Show("Maaf kode sudah ada, coba di cek kembali data nya")
            Else
                'Simpan data baru
                Dim strSave As Boolean
                sql = "INSERT INTO `pos`.`barang` SET `Id_barang`='" & TextBox1.Text.ToUpper & "', `nm_barang`='" & TextBox2.Text & "', `jns_barang`='" & TextBox3.Text & "', `ukrn_barang`='" & TextBox4.Text & "', `kmsn_barang`='" & ComboBox1.Text & "', `stok_barang`=" & TextBox6.Text & ", `hrg_barang`=" & TextBox7.Text & ", `ket_barang`='" & TextBox8.Text & "';"

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
                ComboBox1.Visible = False
                Button1.Focus()
                ComboBox1.Visible = False
                perintah = "normal"
                refresh_tabel(DataGridView1)
            End If
        ElseIf perintah = "edit" Then   'jika ubah atau edit data maka
            'simpan perubahan data
            Dim strSave As Boolean
            sql = "UPDATE `pos`.`barang` SET `nm_barang`='" & TextBox2.Text & "', `jns_barang`='" & TextBox3.Text & "', `ukrn_barang`='" & TextBox4.Text & "', `kmsn_barang`='" & ComboBox1.Text & "', `stok_barang`=" & TextBox6.Text & ", `hrg_barang`=" & TextBox7.Text & ", `ket_barang`='" & TextBox8.Text & "' WHERE `Id_barang`='" & TextBox1.Text & "';"
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
            ComboBox1.Visible = False
            perintah = "normal"
            refresh_tabel(DataGridView1)

        End If


    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        'textbox5 hanya boleh di isi dengan angka
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (e.KeyChar = Chr(13)) Then
            TextBox7.Focus()
        End If
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        'textbox5 hanya boleh di isi dengan angka
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If (e.KeyChar = Chr(13)) Then
            TextBox8.Focus()
        End If

    End Sub

   
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'perintah tombol exit
        diskonek()      'tutup koneksi ke database
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox1.Text = TextBox1.Text.ToUpper
            TextBox2.Focus()
        End If
    End Sub

    
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox3.Focus()
        End If
    End Sub
    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox4.Focus()
        End If
    End Sub
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox1.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar = Chr(13) Then
            Button3.Focus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'perintah tombol edit (ubah data)
        perintah = "edit"
        aturtombol(False, True)
        kunci(False)
        ComboBox1.Visible = True
        TextBox1.ReadOnly = True
        TextBox2.Focus()

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'perintah tombol delete (hapus data)
        Dim kdbarang As String
        Dim jawab As New MsgBoxResult

        kdbarang = TextBox1.Text
        jawab = MsgBox("Hapus data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Hapus data")
        If jawab = MsgBoxResult.Yes Then
            If kdbarang <> "" Then
                'Delete the selected record
                Dim strDeleted As Boolean

                strDeleted = ExecNonQuery("DELETE FROM barang WHERE id_barang= '" & kdbarang & "'")

                If strDeleted = "True" Then
                    MsgBox("Data Telah di hapus", MsgBoxStyle.Information)
                    kosongin()
                    refresh_tabel(DataGridView1)
                Else
                    MsgBox(strDeleted)
                End If
            Else
                MsgBox("Silahkan pilih data yang ingin adan hapus", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Data batal di hapus !", MsgBoxStyle.Information, "info")
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Perintah tombol cancel (batalkan perintah)
        aturtombol(True, False)
        kunci(True)
        ComboBox1.Visible = False
        refresh_tabel(DataGridView1)
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


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub
End Class
