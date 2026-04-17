using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_pelaporan_keracunan_MBG
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Apakah anda yakin ingin keluar dari Dashboard Admin?",
                          "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Form1 halamanUtama = new Form1();
                halamanUtama.Show();
                this.Dispose();
            }
        }

        private void LoadDataLaporan()
        {
            string connString = @"Data Source=TERABYTE\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";

            string query = @"SELECT L.id_laporan, M.nama_pelapor, M.kontak, M.kota_kab, L.lokasi_kejadian, L.tanggal, L.jumlah_korban, L.gejala, L.status_validasi 
                 FROM Laporan L 
                 JOIN Masyarakat M ON L.id_masyarakat = M.id_masyarakat";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Reset dan isi tabel
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;

                    // Opsional: ID Laporan gausah dilihatin ke admin biar rapi
                    if (dataGridView1.Columns.Contains("id_laporan"))
                        dataGridView1.Columns["id_laporan"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal narik data cik: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataLaporan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataLaporan(); 
            MessageBox.Show("Data Berhasil Diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTerima_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idLaporan = dataGridView1.SelectedRows[0].Cells["id_laporan"].Value.ToString();

                DialogResult dr = MessageBox.Show("Validasi laporan dengan ID " + idLaporan + " ini?",
                                  "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    string connString = @"Data Source=TERABYTE\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            conn.Open();
                            string query = "UPDATE Laporan SET status_validasi = 'Diterima' WHERE id_laporan = @id";

                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idLaporan);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Laporan Berhasil Divalidasi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataLaporan();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal update data: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih dulu baris laporan yang mau diterima di tabel!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTolak_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idLaporan = dataGridView1.SelectedRows[0].Cells["id_laporan"].Value.ToString();
                string nama = dataGridView1.SelectedRows[0].Cells["nama_pelapor"].Value.ToString();

                DialogResult dr = MessageBox.Show($"Yakin mau menolak laporan dari {nama}?", "Konfirmasi Tolak", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    string connString = @"Data Source=TERABYTE\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            conn.Open();
                            string query = "UPDATE Laporan SET status_validasi = 'Ditolak' WHERE id_laporan = @id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idLaporan);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Laporan telah ditolak.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataLaporan();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal tolak: " + ex.Message); }
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idLaporan = dataGridView1.SelectedRows[0].Cells["id_laporan"].Value.ToString();

                DialogResult dr = MessageBox.Show("PERINGATAN: Data yang dihapus tidak bisa dikembalikan. Hapus laporan ini?",
                                  "Hapus Permanen", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dr == DialogResult.Yes)
                {
                    string connString = @"Data Source=TERABYTE\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connString))
                        {
                            conn.Open();
                            string query = "DELETE FROM Laporan WHERE id_laporan = @id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idLaporan);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Data berhasil dihapus dari database!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataLaporan(); 
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Gagal hapus: " + ex.Message); }
                }
            }
        }
    }
}
