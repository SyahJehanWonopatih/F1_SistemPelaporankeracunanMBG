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
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDataLaporan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=TERABYTE\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";

            string query = @"SELECT L.id_laporan, M.nama_pelapor, L.lokasi_kejadian, L.tanggal, L.jumlah_korban, L.gejala, L.status_validasi 
                     FROM Laporan L 
                     JOIN Masyarakat M ON L.id_masyarakat = M.id_masyarakat";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Koneksi Database Berhasil!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal!: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
