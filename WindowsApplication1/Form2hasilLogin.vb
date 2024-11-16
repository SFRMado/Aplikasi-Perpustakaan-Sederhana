Public Class Form2hasilLogin

    Dim table_contoh As DataTable = New DataTable()
    Dim idColumn As DataColumn = New DataColumn("No", GetType(Integer))
    Dim dt_row As DataRow
    Private Sub TampilData_Awal()
        Try
            table_contoh.Columns.Add(idColumn)
            table_contoh.PrimaryKey = New DataColumn() {idColumn}
            table_contoh.Columns.Add(New DataColumn("Kode", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Judul", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Tahun", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Penerbit", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Penulis", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Halaman", GetType(String)))


            DataGridView.DataSource = table_contoh
            DataGridView.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Clear_Isian()
        txtKode.Text = ""
        txtJudul.Text = ""
        txtTahun.Text = ""
        txtPenerbit.Text = ""
        txtPenulis.Text = ""
        txtHalaman.Text = ""
    End Sub
    Private Sub Form2hasilLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TampilData_Awal()
    End Sub

    Private Sub btn_Tambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Tambah.Click
        Try

            Dim No As String = 0
            If table_contoh.Rows.Count > 0 Then
                Dim row As DataGridViewRow = DataGridView.Rows(DataGridView.Rows.Count() - 2)
                No = row.Cells(0).Value.ToString
            End If

            If btn_Tambah.Text = "Tambah" Then
                table_contoh.Rows.Add(No + 1, txtKode.Text, txtJudul.Text, txtTahun.Text, txtPenerbit.Text, txtPenulis.Text, txtHalaman.Text)
            Else
                table_contoh.Rows.Find(lblID.Text)("Kode") = txtKode.Text
                table_contoh.Rows.Find(lblID.Text)("Judul") = txtJudul.Text
                table_contoh.Rows.Find(lblID.Text)("Tahun") = txtTahun.Text
                table_contoh.Rows.Find(lblID.Text)("Penerbit") = txtPenerbit.Text
                table_contoh.Rows.Find(lblID.Text)("Penulis") = txtPenulis.Text
                table_contoh.Rows.Find(lblID.Text)("Halaman") = txtHalaman.Text
                btn_Tambah.Text = "Tambah"
                btn_Hapus.Visible = False
            End If


            DataGridView.DataSource = table_contoh
            DataGridView.Show()
            Clear_Isian()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim result() As DataRow = table_contoh.Select("Judul like '%" & txtJudul.Text & "%'")
            ' Loop.
            Dim table_cari As DataTable = New DataTable()
            Dim idcari As DataColumn = New DataColumn("No", GetType(Integer))
            table_cari.Columns.Add(idcari)
            table_cari.PrimaryKey = New DataColumn() {idcari}
            table_contoh.Columns.Add(New DataColumn("Kode", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Judul", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Tahun", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Penerbit", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Penulis", GetType(String)))
            table_contoh.Columns.Add(New DataColumn("Halaman", GetType(String)))

            For Each row As DataRow In result
                table_cari.Rows.Add(row(0), row(1), row(2), row(3))
            Next

            If table_cari.Rows.Count = 0 Then
                DataGridView.DataSource = table_contoh
            Else
                DataGridView.DataSource = table_cari
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub DataGridVieW_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView.Rows(e.RowIndex)
            lblrow.Text = e.RowIndex.ToString
            lblID.Text = row.Cells(0).Value.ToString
            txtKode.Text = row.Cells(1).Value.ToString
            txtJudul.Text = row.Cells(2).Value.ToString
            txtTahun.Text = row.Cells(3).Value.ToString
            txtPenerbit.Text = row.Cells(4).Value.ToString
            txtPenulis.Text = row.Cells(5).Value.ToString
            txtHalaman.Text = row.Cells(6).Value.ToString
            btn_Tambah.Text = "Ubah"
            btn_Hapus.Visible = True
        End If
    End Sub

    Private Sub lblID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblID.Click

    End Sub

    Private Sub txtKode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtKode.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.FromArgb(100, 0, 0, 0)
    End Sub
End Class