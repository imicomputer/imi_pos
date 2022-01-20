Imports MySql.Data.MySqlClient
Public Class login_supervisor
    Dim currentRow As Integer
    Public Shared user, pass, sts As String

    Private Sub CariData()
        Try
            konek(My.Settings.serverDB, _
                  My.Settings.penggunaDB, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            DTset = New DataSet
            sql = "select nama_user, pass_user, sts_user " & _
                "from pengguna where nama_user = '" & TextBox1.Text.Trim & "'"
            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            currentRow = 0
            DTadapter.Fill(DTset, "petugas")
            DTtable = DTset.Tables("petugas")
            diskonek()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End
        End Try
    End Sub

    Private Sub LihatData()
        With DTset.Tables("petugas")
            user = .Rows(currentRow)("nama_user").ToString
            pass = .Rows(currentRow)("pass_user").ToString
            sts = .Rows(currentRow)("sts_user").ToString
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub login_supervisor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        TextBox1.Focus()
    End Sub

    Private Sub login_supervisor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = Nothing
        TextBox2.Text = Nothing
        If supervisor_cmd = "hapus_transaksi" Then
            Label3.Text = "Login supervisor digunakan,  apa bila terdapat kesalahan pada saat entry data"
        ElseIf supervisor_cmd = "reprint" Then
            Label3.Text = "Login Supervisor digunakan, apa bila ingin melakukan pencetakan kembali faktur"
        End If
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        CariData()
        If DTtable.Rows.Count > 0 Then
            LihatData()
            If (TextBox2.Text.Trim) = pass Then
                If (sts.ToLower = "admin" Or sts.ToLower = "supervisor") Then
                    Button1.Enabled = False
                    Button2.Enabled = False
                    Button3.Focus()
                    Panel1.Visible = True
                    'Me.Visible = False
                Else
                    MessageBox.Show("Maaf Anda tidak memiliki askses ke software ini", "SIM", MessageBoxButtons.OK)
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                End If
            Else
                MessageBox.Show("Kombinasi Username dan Password yang anda masukkan salah", "SIM", MessageBoxButtons.OK)
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            End If
        Else
            MessageBox.Show("Username yang Anda Masukkan Tidak Terdaftar", "SIM")
            TextBox2.Clear()
            TextBox1.Clear()
            TextBox1.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form_reprint.Show(Me)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form_supervisi.Show(Me)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class