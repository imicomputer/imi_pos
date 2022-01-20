Imports MySql.Data.MySqlClient

Public Class Form_login
    Dim currentRow As Integer
    Public Shared user, pass, sts As String

    Private Sub CariData()
        Try
            'konek("localhost", "root", "Sparkling123", "pos")
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB.ToString, _
                  My.Settings.namaDB.ToString)
            DTset = New DataSet
            sql = "select * from pengguna where nama_user = '" & TextBox1.Text.Trim & "'"
            DTadapter.SelectCommand = New MySqlCommand(sql, conn)
            currentRow = 0
            DTadapter.Fill(DTset, "petugas")
            DTtable = DTset.Tables("petugas")
            diskonek()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LihatData()
        Try
            With DTset.Tables("petugas")
                user = .Rows(currentRow)("nama_user").ToString
                pass = .Rows(currentRow)("pass_user").ToString
                sts = .Rows(currentRow)("sts_user").ToString
                sts_user = sts
            End With

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Login()
        CariData()

        If DTtable.Rows.Count > 0 Then
            LihatData()

            If (TextBox2.Text.Trim) = pass Then
                If (sts.ToLower = "admin" Or sts.ToLower = "supervisor") Then
                    'Log User
                    sql = "UPDATE `pengguna` SET `last_login`=NOW(), `last_form_used`='back_office' WHERE `nama_user`='" & TextBox1.Text & "'"
                    ExecNonQuery(sql)

                    Menuutama.Show()
                    Me.Visible = False
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
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        Call Login()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.SelectAll()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.SelectAll()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Login()
        End If
    End Sub
End Class