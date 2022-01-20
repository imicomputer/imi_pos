Imports MySql.Data.MySqlClient

Public Class Form_supervisi
    Dim currentRow As Integer

    Private Sub refresh_tabel(ByRef statusView As DataGridView)
        Try
            'perintah untuk me-refresh data pada datagridview1
            Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
            Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim myData As New DataTable
            Dim SQL As String
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            SQL = "SELECT `faktur_detail`.`Id_fak_treatment`,`faktur_detail`.`no_faktur`," & _
              "`faktur_detail`.`id_produk`, `produk`.`nama`, `faktur_detail`.`harga`," & _
              "`faktur_detail`.`jml_beli`," & _
              "`faktur_detail`.`total`, `faktur_detail`.`diskon`," & _
              "`faktur_detail`.`tot_stlh_diskon`,`faktur_detail`.`free`,`produk`.`pengurang_stok`" & _
            " FROM `faktur_detail` LEFT JOIN" & _
              "`produk` ON `faktur_detail`.`id_produk` = `produk`.`Id`" & _
            "where `faktur_detail`.`no_faktur`='" & TextBox1.Text & "';"
            myCommand.Connection = conn
            myCommand.CommandText = SQL

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            statusView.DataSource = myData
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(2).Width = 80
            DataGridView1.Columns(3).Width = 200
            DataGridView1.Columns(4).Width = 65
            DataGridView1.Columns(5).Width = 60
            DataGridView1.Columns(6).Width = 80
            DataGridView1.Columns(7).Width = 80
            DataGridView1.Columns(8).Width = 80
            DataGridView1.Columns(9).Width = 80

            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "No Faktur"
            DataGridView1.Columns(2).HeaderText = "Kode Produk"
            DataGridView1.Columns(3).HeaderText = "Nama Produk"
            DataGridView1.Columns(4).HeaderText = "Harga"
            DataGridView1.Columns(5).HeaderText = "Jml Beli"
            DataGridView1.Columns(6).HeaderText = "Total"
            DataGridView1.Columns(7).HeaderText = "Diskon   "
            DataGridView1.Columns(8).HeaderText = "Sub Total"
            DataGridView1.Columns(9).HeaderText = "free"
            DataGridView1.Columns(10).HeaderText = "Sts Barang"

            diskonek()
        Catch myerror As MySql.Data.MySqlClient.MySqlException
            MsgBox("There was an error reading from the database: " & myerror.Message)
        End Try
    End Sub
    

    Private Sub Form_supervisi_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox1.Text = Form_kasir_sentuh.TextBox1.Text
        TextBox2.Text = Form_kasir_sentuh.TextBox2.Text
        TextBox3.Text = Form_kasir_sentuh.TextBox3.Text
        TextBox4.Text = Format(Now, "yyyy-MM-dd")
        Button2.Enabled = True
        refresh_tabel(DataGridView1)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Cursor = Cursors.WaitCursor
        'Button2.Enabled = False
        'Form_kasir.preview_detail()
        'Cursor = Cursors.Arrow
        'login_supervisor.Close()
        Me.Close()
        'Form_kasir.Button3.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'perintah tombol delete (hapus data)
        Dim id As String
        Dim strDeleted, strupdate As Boolean
        Dim jawab As New MsgBoxResult

        id = DataGridView1.CurrentRow.Cells(0).Value
        jawab = MsgBox("Hapus data dengan id no " & id & " ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Hapus data")
        If jawab = MsgBoxResult.Yes Then
            If id <> "" Then
                'jika pengurang_stok = 1 maka stok dikembalikan kembali 
                If CBool(DataGridView1.CurrentRow.Cells(10).Value) Then
                    'update stok
                    sql = "UPDATE `pos`.`produk` SET `stok`= `stok`+" & DataGridView1.CurrentRow.Cells(5).Value & "  WHERE `Id`='" & DataGridView1.CurrentRow.Cells(2).Value & "';"
                    strupdate = ExecNonQuery(sql)
                    If strupdate = "True" Then

                    Else
                        MsgBox(strDeleted)
                    End If
                End If
                'hapus detail faktur
                strDeleted = ExecNonQuery("DELETE FROM faktur_detail WHERE Id_fak_treatment= " & id & "")
                If strDeleted = "True" Then
                    MsgBox("Data Telah di hapus", MsgBoxStyle.Information)
                    refresh_tabel(DataGridView1)
                Else
                    MsgBox(strDeleted)
                End If
            Else
                MsgBox("Silahkan pilih data yang ingin anda hapus", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("Data batal di hapus !", MsgBoxStyle.Information, "info")
        End If

    End Sub
End Class