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
    Public sql As String
    Public sts_user As String

    Dim currentRow As Integer
    Private strkoneksi As String

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
                End
            End Try
        End If
    End Sub

    'sub program untuk memutus koneksi dengan mysql
    Public Sub diskonek()
        Try
            conn.Close()
        Catch ex As MySql.Data.MySqlClient.MySqlException
        End Try
    End Sub
    'sub program untuk menjalankan query perintah SQL
    Public Function ExecNonQuery(ByVal strSQL As String)
        Try
            With conn
                If .State = ConnectionState.Open Then .Close()
                'konek("localhost", "root", "Sparkling123", "pos")
                konek(My.Settings.serverDB.ToString, _
                      My.Settings.penggunaDB.ToString, _
                      My.Settings.kunciDB.ToString, _
                      My.Settings.namaDB.ToString)
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

End Module
