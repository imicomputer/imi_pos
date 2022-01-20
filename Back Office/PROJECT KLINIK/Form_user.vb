Imports MySql.Data
Public Class Form_user
    Dim perintah As String

    Private Sub Form_user_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        konek("localhost", "root", "Sparkling123", "pos")
        perintah = "normal"
        refresh_tabel(DataGridView1)
        DataGridView1.Focus()
    End Sub

    Private Sub refresh_tabel(ByRef statusView As DataGridView)
        'perintah untuk me-refresh data pada datagridview1
        Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
        Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQL As String

        SQL = "select * from pengguna"
        Try
            myCommand.Connection = conn
            myCommand.CommandText = SQL

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            statusView.DataSource = myData
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.Columns(0).Width = 300
            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(2).Width = 150

            DataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True

            DataGridView1.Columns(0).HeaderText = "Nama Penguna"
            DataGridView1.Columns(1).HeaderText = "Password"
            DataGridView1.Columns(2).HeaderText = "Hak Pengguna"

        Catch myerror As MySql.Data.MySqlClient.MySqlException
            MsgBox("There was an error reading from the database: " & myerror.Message)
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        konek("localhost", "root", "Sparkling123", "pos")
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim jml As Integer
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT count(nama_user) from pengguna"
        cmd.Connection = conn
        jml = cmd.ExecuteScalar.ToString
        diskonek()
        If jml > 0 Then
            'kalau datagridview1 di klik tampilkan data ke textbox
            TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
            TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(2).Value
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        aturtombol(False, True)
        kosongin()
        kunci(False)
        TextBox1.Focus()
        perintah = "add"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'perintah tombol edit (ubah data)
        If (TextBox1.Text) <> Nothing Then
            perintah = "edit"
            aturtombol(False, True)
            kunci(False)
            TextBox1.ReadOnly = True
            TextBox2.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'perintah tombol Save (simpan)
        Dim kdjasa As String
        Dim sql As String
        Dim jawab As New MsgBoxResult

        'cek apakah data di texbox sudah diisi
        If TextBox1.Text = Nothing Then
            MsgBox("User Name harus di isi", MsgBoxStyle.Information, "info")
            TextBox1.Focus()
            Exit Sub
        End If

        If TextBox2.Text = Nothing Then
            MsgBox("Password harus di isi", MsgBoxStyle.Information, "info")
            TextBox2.Focus()
            Exit Sub
        End If
        If ComboBox1.Text = Nothing Then
            MsgBox("Status user harus di isi", MsgBoxStyle.Information, "info")
            ComboBox1.Focus()
            Exit Sub
        End If
        'Jika simpan data baru
        If perintah = "add" Then
            kdjasa = TextBox1.Text
            'Cek kode sudah ada apa belom
            konek("localhost", "root", "Sparkling123", "pos")
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim jml As Integer
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT count(nama_user) from pengguna where nama_user='" & kdjasa & "'"
            cmd.Connection = conn
            jml = cmd.ExecuteScalar.ToString
            diskonek()
            If jml > 0 Then
                MessageBox.Show("Maaf kode sudah ada, coba di cek kembali data nya")
            Else
                Try
                    'Simpan data baru
                    sql = "INSERT INTO `pos`.`pengguna` " & _
                        "SET `nama_user`='" & Trim(Replace(TextBox1.Text.ToUpper, "'", "''")) & "', " & _
                            "`pass_user`='" & Trim(Replace(TextBox2.Text, "'", "''")) & "', " & _
                            "`sts_user`='" & Trim(Replace(ComboBox1.Text.ToUpper, "'", "''")) & "', " & _
                            "`creation_date`=NOW();"
                    ExecNonQuery(sql)

                Catch ex As Exception
                    System.Windows.Forms.MessageBox.Show(ex.ToString)
                Finally
                    MsgBox("Data Telah di simpan", MsgBoxStyle.Information)
                End Try

                'normalkan tampilan form
                aturtombol(True, False)
                kunci(True)
                Button1.Focus()
                perintah = "normal"
                refresh_tabel(DataGridView1)
            End If
        ElseIf perintah = "edit" Then   'jika ubah atau edit data maka
            'simpan perubahan data
            Dim strSave As Boolean
            sql = "UPDATE `pos`.`pengguna` SET `pass_user`='" & Trim(Replace(TextBox2.Text, "'", "''")) & "', `sts_user`='" & Trim(Replace(ComboBox1.Text, "'", "''")) & "' WHERE `nama_user`='" & Trim(Replace(TextBox1.Text, "'", "''")) & "';"
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
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'perintah tombol delete (hapus data)
        Dim kdjasa As String
        Dim jawab As New MsgBoxResult

        kdjasa = TextBox1.Text
        jawab = MsgBox("Hapus data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Hapus data")
        If jawab = MsgBoxResult.Yes Then
            If kdjasa <> "" Then
                'Delete the selected record
                Dim strDeleted As Boolean

                strDeleted = ExecNonQuery("DELETE FROM pengguna WHERE nama_user= '" & kdjasa & "'")

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

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'perintah tombol exit
        diskonek()      'tutup koneksi ke database
        Me.Close()
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
        ComboBox1.Text = Nothing
    End Sub

    Sub kunci(ByVal kc1 As Boolean)
        TextBox1.ReadOnly = kc1
        TextBox2.ReadOnly = kc1
        ComboBox1.Enabled = Not kc1
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            ComboBox1.Focus()
        End If

        If e.KeyChar = Chr(27) Then
            If Button4.Enabled Then
                Button4.PerformClick()
            End If
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
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
