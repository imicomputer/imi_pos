Imports MySql.Data.MySqlClient
Public Class Form_login
    Dim currentRow As Integer
    Public Shared user, pass, sts As String

    Private Sub CariData()
        Try
            konek(My.Settings.serverDB.ToString, _
                  My.Settings.penggunaDB.ToString, _
                  My.Settings.kunciDB, _
                  My.Settings.namaDB)
            DTset = New DataSet
            sql = "select * from pengguna where nama_user = '" & TextBox1.Text.Trim & "'"
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

    Private Sub Login()
        Me.Cursor = Cursors.WaitCursor
        CariData()
        If DTtable.Rows.Count > 0 Then
            LihatData()
            If (TextBox2.Text.Trim) = pass Then
                If (sts.ToLower = "admin" Or sts.ToLower = "supervisor" Or sts.ToLower = "kasir") Then
                    sql = "UPDATE `pos`.`pengguna` SET `last_login`=CAST(now() as datetime) " & _
                        "WHERE `nama_user`='" & TextBox1.Text & "'"
                    ExecNonQuery(sql)

                    nokasir = My.Settings.kasirNo
                    sts_user = sts
                    nama_user = TextBox1.Text.Trim
                    Form_kasir_sentuh.Show()
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
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Login()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.SelectAll()
    End Sub

    Private Sub TextBox1_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.SelectAll()
    End Sub

    Private Sub TextBox2_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Login()
        End If
    End Sub

    Private Sub Form_login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label4.Text = "[" & My.Settings.kasirNo & "]"
    End Sub
End Class