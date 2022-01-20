Imports MySql.Data
Public Class Form_reprint
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form_reprint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
        refresh_tabel(DataGridView1)
    End Sub

    Private Sub refresh_tabel(ByRef statusView As DataGridView)
        'perintah untuk me-refresh data pada datagridview1
        Dim myCommand As New MySql.Data.MySqlClient.MySqlCommand
        Dim myAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim myData As New DataTable
        Dim SQL As String
        Dim whereQuery As String = _
            "where no_faktur like '%" & TextBox1.Text & "%'" & _
            " and atas_nama like '%" & TextBox2.Text & "%'" & _
            " and dgn_telp like '%" & TextBox4.Text & "%'"
        '" and tgl_faktur = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "'" & _

        SQL = "select no_faktur, tgl_faktur, atas_nama, dgn_telp, nama_user " & _
            "from faktur " & whereQuery & " order by no_faktur desc"
        Try
            myCommand.Connection = conn
            myCommand.CommandText = SQL

            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(myData)

            statusView.DataSource = myData
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            DataGridView1.Columns(0).Width = 120
            DataGridView1.Columns(1).Width = 80
            DataGridView1.Columns(2).Width = 180
            DataGridView1.Columns(3).Width = 80
            DataGridView1.Columns(4).Width = 70


            DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight

            DataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            DataGridView1.Columns(1).DefaultCellStyle.Format = "dd-MMM-yyyy"

            DataGridView1.Columns(0).HeaderText = "Receipt #"
            DataGridView1.Columns(1).HeaderText = "Receipt Date"
            DataGridView1.Columns(2).HeaderText = "Customer Name"
            DataGridView1.Columns(3).HeaderText = "Customer Phone"
            DataGridView1.Columns(4).HeaderText = "Cashier"

        Catch myerror As MySql.Data.MySqlClient.MySqlException
            MsgBox("There was an error reading from the database: " & myerror.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        kirim_no_faktur = DataGridView1.CurrentRow.Cells(0).Value
        cetak_faktur.Show()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        refresh_tabel(DataGridView1)
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        refresh_tabel(DataGridView1)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        refresh_tabel(DataGridView1)
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        refresh_tabel(DataGridView1)
    End Sub
End Class