Imports MySql.Data.MySqlClient
Public Class Form_kasir_sentuh
    Dim currentRow As Integer
    Dim no_faktur, no_baru, str_cari, tgl_simpan, sts_aktive, totalin As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FlowLayoutPanel1.Visible = True
        FlowLayoutPanel2.Visible = False
    End Sub

    Private Sub pilih_produk(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim thisButton As Button
        Dim StrTemp() As String
        thisButton = sender
        StrTemp = thisButton.Text.Split("[")
        'MsgBox(StrTemp(1).Substring(0, StrTemp(1).Length - 1))
        Form_produk_detail.Label7.Text = StrTemp(1).Substring(0, StrTemp(1).Length - 1)
        Form_produk_detail.txt_jenisbarang.Text = thisButton.Tag
        Form_produk_detail.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        FlowLayoutPanel2.Visible = True
        FlowLayoutPanel1.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        FlowLayoutPanel2.Visible = False
        FlowLayoutPanel1.Visible = False
        Dim jml As Integer
        jml = FlowLayoutPanel1.Controls.Count
        For i = 1 To jml
            FlowLayoutPanel1.Controls.RemoveByKey("produk")
        Next
        jml = FlowLayoutPanel2.Controls.Count
        For i = 1 To jml
            FlowLayoutPanel2.Controls.RemoveByKey("treatment")
        Next
        buat_tombol("produk")
        buat_tombol("treatment")
    End Sub

    Private Function hitung_diskon(ByVal dbltotal As Double, ByVal strJenisDiskon As String, ByVal dblJmlDiskon As Double)
        hitung_diskon = 0
        If frmPemanggil <> Nothing Then
            If strJenisDiskon = "persentase" Then
                hitung_diskon = (dbltotal * dblJmlDiskon)
            ElseIf strJenisDiskon = "voucher" Then
                hitung_diskon = (dblJmlDiskon)
            End If
        End If
    End Function

    Private Sub Form_kasir_sentuh_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If frmPemanggil = "Form_kasir_sentuh" Then
            If TextBox5.Tag < TextBox4.Tag Then
                TextBox5.Tag = hitung_diskon(Val(TextBox4.Tag), Form_diskon.TextBox1.Text.ToLower, Val(Form_diskon.TextBox2.Text))
            Else
                TextBox5.Tag = 0
                'MsgBox("Diskon yang di berikan tidak boleh lebih besar dari Total transaksi", MsgBoxStyle.Exclamation, "Warning")
                jdiskon = Nothing
                ndiskon = Nothing
            End If
        ElseIf TextBox5.Tag > 0 Then
            frmPemanggil = "Form_kasir_sentuh_update"

            TextBox5.Tag = hitung_diskon(Val(TextBox4.Tag), jdiskon.ToLower, ndiskon)
        ElseIf frmPemanggil = "cetak_faktur" Then
            TextBox4.Tag = 0

            TextBox5.Tag = 0
        Else
            TextBox5.Tag = 0
        End If

        TextBox4.Text = "Rp." & FormatNumber(TextBox4.Tag, 2)
        TextBox5.Text = "Rp." & FormatNumber(TextBox5.Tag, 2)

        TextBox6.Tag = TextBox4.Tag - TextBox5.Tag
        TextBox6.Text = "Rp." & Trim(FormatNumber(TextBox6.Tag).ToString)

        frmPemanggil = Nothing

        tampil_detil_faktur(TextBox1.Text)
    End Sub

    Private Sub Form_kasir_sentuh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'nokasir = My.Settings.kasirNo
        'nama_user = "Yusuf"
        Label5.Text = "[" & nokasir & "]"
        Label6.Text = "[" & nama_user & "]"
        FlowLayoutPanel1.Visible = False
        FlowLayoutPanel2.Visible = False
        buat_tombol("produk")
        buat_tombol("treatment")

        generate_Nofaktur()
        refresh_total(0, 0)
        tampil_detil_faktur(TextBox1.Text)
    End Sub

    Public Sub tampil_detil_faktur(ByVal strNoFaktur As String)
        Dim strTrimmedNamaProduk As String
        Dim pgj_jarak As Integer
        Dim adaData As Boolean = False
        'tampilkan detil faktur
        RichTextBox1.Text = ""
        RichTextBox1.AppendText("No Faktur : " & strNoFaktur & vbCrLf & vbCrLf)
        RichTextBox1.AppendText("Pembeli : " & TextBox2.Text & vbCrLf)
        RichTextBox1.AppendText("Telepon : " & TextBox3.Text & vbCrLf)
        RichTextBox1.AppendText(StrDup(40, "=") & vbCrLf)

        ambildata_detil_faktur(TextBox1.Text)
        For Each DTrow As DataRow In DTset.Tables(0).Rows
            If DTrow.Item("nama").ToString.Length > 35 Then
                strTrimmedNamaProduk = DTrow.Item("nama").ToString.Substring(0, 32) & "..."
            Else
                strTrimmedNamaProduk = DTrow.Item("nama")
            End If
            RichTextBox1.AppendText("[" & DTrow.Item("id_produk") & "] " & strTrimmedNamaProduk & vbCrLf)
            RichTextBox1.AppendText("Rp." & FormatNumber(DTrow.Item("harga"), 2) & " x " & DTrow.Item("jml_beli"))
            If Val(DTrow.Item("diskon")) > 0 Then
                RichTextBox1.AppendText(" (Disc. Rp." & FormatNumber(DTrow.Item("diskon"), 2) & ")" & vbCrLf)
            Else
                RichTextBox1.AppendText(vbCrLf)
            End If
            pgj_jarak = (55 - Len(Trim(DTrow.Item("tot_stlh_diskon"))))
            RichTextBox1.AppendText(StrDup(pgj_jarak, " ") & "Rp." & Trim(FormatNumber(DTrow.Item("tot_stlh_diskon"), 2).ToString).PadLeft("12", " ") & vbCrLf & vbCrLf)
            adaData = True
        Next

        'Isi nilai Sub, Diskon, dan Total
        If adaData = True Then
            RichTextBox1.AppendText(StrDup(40, "=") & vbCrLf)
            ambildata_detil_footer(TextBox1.Text)
            For Each dtrow As DataRow In DTset.Tables(0).Rows
                'cetak total kolom total
                pgj_jarak = (43 - Len(Trim(dtrow.Item("t_tsd"))))

                refresh_total(dtrow.Item("t_tsd"), Val(TextBox5.Tag))
            Next
        End If
    End Sub

    Sub refresh_total(ByVal dblSub As Double, ByVal dblDisc As Double)
        TextBox4.Tag = dblSub.ToString
        TextBox4.Text = "Rp." & Trim(FormatNumber(TextBox4.Tag, 2)).ToString

        TextBox5.Tag = dblDisc.ToString
        TextBox5.Text = "Rp." & Trim(FormatNumber(TextBox5.Tag, 2)).ToString

        TextBox6.Tag = TextBox4.Tag - TextBox5.Tag
        TextBox6.Text = "Rp." & Trim(FormatNumber(TextBox6.Tag).ToString)
    End Sub

    Private Sub buat_tombol(ByVal btnname As String)
        Dim lebar, r, g, b As Integer
        Dim rand As New Random(-1)

        lebar = FlowLayoutPanel2.Width - 50
        'Isi panel 1
        'ambil data barang untuk ngebuat tombol
        If btnname.ToLower = "produk" Then
            ambildata_produk(1)
        ElseIf btnname.ToLower = "treatment" Then
            ambildata_produk(0)
        End If

        For Each DTrow As DataRow In DTset.Tables(0).Rows
            Dim newbutton As New Button

            newbutton.Width = lebar / 4
            newbutton.Height = 60

            newbutton.Name = btnname
            newbutton.Text = DTrow.Item("nama") & vbCrLf & "[" & DTrow.Item("id") & "]"
            AddHandler newbutton.Click, AddressOf pilih_produk

            r = rand.Next(100, 250)
            g = rand.Next(100, 250)
            b = rand.Next(100, 250)
            newbutton.BackColor = Color.FromArgb(r, g, b)

            If btnname.ToLower = "produk" Then
                If Val(DTrow.Item("stok")) < 1 Then
                    newbutton.Enabled = False
                End If
                newbutton.ForeColor = Color.Black
                'newbutton.BackColor = Color.Silver
                newbutton.Cursor = Cursors.Hand
                newbutton.Tag = "1"
                FlowLayoutPanel1.Controls.Add(newbutton)
            ElseIf btnname.ToLower = "treatment" Then
                newbutton.ForeColor = Color.Black
                'newbutton.BackColor = Color.Silver
                newbutton.Cursor = Cursors.Hand
                newbutton.Tag = "0"
                FlowLayoutPanel2.Controls.Add(newbutton)
            End If
        Next
    End Sub

    Private Sub Form_kasir_sentuh_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        PictureBox1.Left = (SplitContainer1.Panel2.Width - PictureBox1.Width) / 2
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim jawab As MsgBoxResult
        jawab = MsgBox("Yakin akan keluar dari program ini ?", MsgBoxStyle.YesNo, "Exit")
        If jawab = vbYes Then
            Try
                'Cek Faktur Kosong
                konek(My.Settings.serverDB.ToString, _
                      My.Settings.penggunaDB.ToString, _
                      My.Settings.kunciDB, _
                      My.Settings.namaDB)

                DTset = New DataSet
                sql = "SELECT COUNT(f.no_faktur) " & _
                    "FROM faktur f INNER JOIN faktur_detail fd " & _
                        "ON f.no_faktur = fd.no_faktur " & _
                    "WHERE f.no_faktur = '" & TextBox1.Text & "'"
                DTadapter.SelectCommand = New MySqlCommand(sql, conn)
                DTadapter.Fill(DTset, "faktur")
                DTtable = DTset.Tables("faktur")

                'Hapus Faktur Kosong
                If DTtable.Rows(currentRow).Item(0) < 1 Then
                    sql = "DELETE FROM faktur " & _
                        "WHERE no_faktur = '" & TextBox1.Text & "'"
                    ExecNonQuery(sql)
                End If

                diskonek()

                End
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(TimeOfDay, "hh:mm:ss")
        Label2.Text = Format(Now, "ddd, dd MMM yyyy")
    End Sub

    Sub generate_Nofaktur()
        If TextBox1.Text = Nothing Then
            str_cari = nokasir & Format(Now, "yyyyMMdd")

            'Try
            If CariData_faktur(str_cari) > 0 Then
                no_baru = Val(Strings.Right(LihatData(), 4)) + 1
                no_baru = no_baru.ToString.PadLeft(5, "0")
                TextBox1.Text = str_cari & no_baru
            Else
                no_baru = "00001"
                TextBox1.Text = str_cari & no_baru
            End If

            'Simpan data Faktur Awal
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            'Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim strSave As Boolean
            'Dim strSave As MySqlException
            tgl_simpan = Format(Now, "yyyy-MM-dd")

            'Simpan Faktur baru
            sql = "INSERT INTO `pos`.`faktur` (`no_faktur`, `tgl_faktur`, `atas_nama`, `dgn_telp`, `nama_user`) VALUES ('" & TextBox1.Text & "', '" & tgl_simpan & "', '" & Replace(TextBox2.Text, "'", "''") & "', '" & TextBox3.Text & "', '" & nama_user & "');"
            strSave = ExecNonQuery(sql)
            diskonek()
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

        End If

    End Sub

    Private Function LihatData()
        With DTset.Tables("faktur")
            LihatData = .Rows(currentRow)("no_faktur").ToString
        End With
    End Function

    Private Function CariData_faktur(ByVal strNoFaktur As String) As Integer
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)

            DTset = New DataSet
            sql = "select * from faktur where left(no_faktur,11)='" & strNoFaktur & "' order by no_faktur desc"
            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            DTadapter.Fill(DTset, "faktur")
            DTtable = DTset.Tables("faktur")

            CariData_faktur = DTtable.Rows.Count

            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form_Find_pelanggan.ShowDialog()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)

            'Update Faktur
            sql = "UPDATE faktur " & _
                "SET `atas_nama`='" & TextBox2.Text & "', " & _
                    "`dgn_telp`='" & _TextBox3.Text & "' " & _
                "WHERE no_faktur='" & TextBox1.Text & "'"
            ExecNonQuery(sql)

            'Ambil data Diskon
            If idDiskon.Trim <> "" Then
                sql = "SELECT `id`, `nama`, `jenis`, `jml` FROM diskon " & _
                    "WHERE `id`='" & idDiskon & "'"
                DTadapter.SelectCommand = New MySqlCommand(sql, conn)
                DTadapter.Fill(DTset, "diskon")
                DTtable = DTset.Tables("diskon")

                'Update Diskon
                sql = "INSERT INTO faktur_diskon_detil " & _
                        "(`no_faktur`, `id_diskon`, `nama_diskon`, `jenis_diskon`, `jml_diskon`) " & _
                    "VALUES ( " & _
                        "'" & TextBox1.Text & "', " & _
                        "'" & DTtable.Rows(0).Item(0).ToString.Trim & "', " & _
                        "'" & DTtable.Rows(0).Item(1).ToString.Trim & "', " & _
                        "'" & DTtable.Rows(0).Item(2).ToString.Trim & "', " & _
                        "'" & Val(TextBox5.Tag) & "' " & _
                    ")"
                ExecNonQuery(sql)
            End If

            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        kirim_no_faktur = TextBox1.Text
        TextBox1.Text = Nothing

        cetak_faktur.ShowDialog()

        refresh_total(0, 0)
        generate_Nofaktur()

        'TextBox1.Text = ""
        TextBox2.Text = "Guest"
        TextBox3.Text = ""

        tampil_detil_faktur(TextBox1.Text)
        frmPemanggil = cetak_faktur.Name
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        login_supervisor.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Val(TextBox4.Tag) > 0 Then
            frmPemanggil = Me.Text
            Form_diskon.ShowDialog()
        Else
            MsgBox("Belum terdapat transaksi, Diskon tidak dapat di berikan", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub TextBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.Click
        virtualBuka(TextBox3)
    End Sub
End Class