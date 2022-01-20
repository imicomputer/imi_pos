Imports MySql.Data.MySqlClient

Module koneksi
    
    'buat variabel koneksi
    Public conn As New MySql.Data.MySqlClient.MySqlConnection
    Public DTadapter As New MySqlDataAdapter
    Public DTset As DataSet
    Public DTrow As DataRow
    Public CMD As MySqlCommand
    Public DTreader As MySqlDataReader
    Public DTtable As New DataTable
    Public CMDbuild As MySqlCommandBuilder
    'Public bs As BindingSource
    Public sql As String
    Public nokasir As String
    Public sts_user As String
    Public nama_user As String
    Dim currentRow As Integer
    Private strkoneksi As String
    Public kirim_no_faktur As String
    Public supervisor_cmd As String
    Public simpan_warna As String
    'buat diskon
    Public frmPemanggil As String = Nothing
    Public jdiskon As String = ""
    Public ndiskon As Double
    Public idDiskon As String = ""

    'sub program untuk melakukan koneksi ke my sql server
    Public Sub konek(ByVal server As String, ByVal user As String, ByVal pass As String, ByVal db As String)
        If conn.State = ConnectionState.Closed Then
            Dim myString As String = "server=" & server _
            & ";user=" & user _
            & ";password=" & pass _
            & ";database=" & db
            Try
                conn.ConnectionString = myString
                conn.Open()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    'sub program untuk memutus koneksi dengan mysql
    Public Sub diskonek()
        Try
            conn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox(ex.Message)
        End Try
    End Sub
    'sub program untuk menjalankan query perintah SQL
    Public Function ExecNonQuery(ByVal strSQL As String)
        Try
            With conn
                If .State = ConnectionState.Open Then .Close()
                konek(My.Settings.serverDB.ToString, _
                      My.Settings.penggunaDB.ToString, _
                      My.Settings.kunciDB, _
                      My.Settings.namaDB)
            End With
            Dim cmd As MySqlCommand = New MySqlCommand(strSQL, conn)
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As MySqlException
            Return ex
        Finally
            conn.Close()
        End Try
    End Function

    Public Sub ambildata_produk(ByVal jns As Integer, Optional ByVal strIdProduk As String = "")
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            DTset = New DataSet

            sql = "select * from produk where pengurang_stok=" & jns
            If strIdProduk <> "" Then
                sql = sql & " and id= '" & strIdProduk & "'"
            End If

            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            DTadapter.Fill(DTset, "produk")

            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub
    Public Sub ambildata_diskon()
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            DTset = New DataSet

            sql = "select `jenis`,`nama`,`jml`, `id` from diskon order by `jenis`, `jml`"

            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            DTadapter.Fill(DTset, "diskon")

            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub
    Public Sub ambildata_detil_faktur(ByVal strNoFaktur As String)
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            DTset = New DataSet

            sql = "SELECT faktur.no_faktur, faktur.tgl_faktur, faktur.atas_nama, faktur.dgn_telp, " & _
                  "faktur.nama_user, faktur_detail.id_produk, produk.nama, faktur_detail.harga, " & _
                  "faktur_detail.jml_beli, faktur_detail.total, faktur_detail.diskon, " & _
                  "faktur_detail.tot_stlh_diskon, faktur_detail.free, produk.ket " & _
                    "FROM produk INNER JOIN " & _
                    "faktur_detail ON produk.Id = faktur_detail.id_produk INNER JOIN " & _
                     "faktur ON faktur_detail.no_faktur = faktur.no_faktur " & _
                    "WHERE     (faktur.no_faktur = '" & strNoFaktur & "')"


            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            DTadapter.Fill(DTset, "faktur")
            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub
    Public Sub ambildata_detil_footer(ByVal strNoFaktur As String)
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            DTset = New DataSet

            sql = "SELECT  Sum(`faktur_detail`.`tot_stlh_diskon`) AS `t_tsd` " & _
                  "FROM `faktur_detail` " & _
                  "WHERE `faktur_detail`.`no_faktur` = '" & strNoFaktur & " '"
            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            DTadapter.Fill(DTset, "footer")
            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub
    Sub virtualBuka(ByVal objform As TextBox)
        objform.Focus()
        System.Diagnostics.Process.Start("osk")
    End Sub
    Sub virtualTutup()
        For Each OSKInstance As Process In Process.GetProcessesByName("osk").ToArray
            OSKInstance.Kill()
        Next
    End Sub
    Function GetRandomColor() As Color
        Dim rand As New Random
        Return Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, _
            256))
    End Function
End Module
