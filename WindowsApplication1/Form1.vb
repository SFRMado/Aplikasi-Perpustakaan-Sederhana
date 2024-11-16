Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LinkLabel1.Text = "Kunjungi Website Universitas Muhammadiyah Cileungsi"
        LinkLabel1.Links.Add(0, 59, "https://umci.ac.id/")
    End Sub
    Private Sub btn_masuk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_masuk.Click
        If txtUserName.Text = "kelompok 1" And txtPassword.Text = "135" Then
            MessageBox.Show("Selamat Anda Berhasil Login!", "Berhasil")
            Form2hasilLogin.Show()
            Form2hasilLogin.Text = "HALAMAN APLIKASI"

            Me.Hide()
        ElseIf txtUserName.Text = "kelompok 1" And txtPassword.Text <> "135" Then
            MessageBox.Show("Password Tidak Sesuai", "Information")
            txtPassword.Text = ""
            txtPassword.Focus()
        Else
            MessageBox.Show("UserName Tidak Terdaftar", "Information")
            txtUserName.Text = ""
            txtPassword.Clear()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Panel2.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class