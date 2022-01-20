Imports System.Windows.Forms

Public Class Menuutama
    Private m_ChildFormNumber As Integer

    Private Sub PenggunaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub LaporanPenjualanToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Form_Laporan_Penjualan.MdiParent = Me
        Form_Laporan_Penjualan.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Menuutama_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form_login.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = FormatDateTime(Now, DateFormat.LongDate) & " - " & FormatDateTime(TimeOfDay, DateFormat.LongTime)
    End Sub

    Private Sub KeluarToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DataBarangDanJasaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataBarangDanJasaToolStripMenuItem.Click
        Form_product.MdiParent = Me
        Form_product.Show()
    End Sub

    Private Sub PaketProdukToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaketProdukToolStripMenuItem.Click
        MsgBox("Maaf, Modul ini sedang dalam tahap pengembangan!")
        'Form_paket.MdiParent = Me
        'Form_paket.Show()
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PelangganToolStripMenuItem.Click
        Form_pelanggan.MdiParent = Me
        Form_pelanggan.Show()
    End Sub

    Private Sub PenggunaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenggunaToolStripMenuItem.Click
        If sts_user.ToLower = "admin" Then
            Form_user.MdiParent = Me
            Form_user.Show()
        Else
            MsgBox("Hanya Admin yang boleh mengubah data Pengguna", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "peringatan")
        End If
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanToolStripMenuItem.Click
        Form_Laporan_Penjualan.MdiParent = Me
        Form_Laporan_Penjualan.Show()
    End Sub

    Private Sub ArrangeAllStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeAllStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileHorizontalyToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileHorizontalyToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVerticalyToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileVerticalyToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub DiskonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiskonToolStripMenuItem.Click
        Form_diskon.MdiParent = Me
        Form_diskon.Show()
    End Sub
End Class
