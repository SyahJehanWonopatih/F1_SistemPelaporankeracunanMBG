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
    public partial class Form3 : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGejala.Text) || string.IsNullOrWhiteSpace(txtKorban.Text))
            {
                MessageBox.Show("Lengkapi Data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = @"Data Source=TERABYTE\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string queryMasyarakat = @"
                INSERT INTO Masyarakat (nama_pelapor, kontak, alamat, kota_kab) 
                OUTPUT INSERTED.id_masyarakat 
                VALUES (@nama, @kontak, @alamat, @kota)";

                    SqlCommand cmdMasy = new SqlCommand(queryMasyarakat, conn);
                    cmdMasy.Parameters.AddWithValue("@nama", Form1.namaLengkap);
                    cmdMasy.Parameters.AddWithValue("@kontak", Form1.noKontak);
                    cmdMasy.Parameters.AddWithValue("@alamat", Form2.lokasiKejadian);
                    cmdMasy.Parameters.AddWithValue("@kota", Form1.kotaKab);

                    int newIdMasy = (int)cmdMasy.ExecuteScalar();

                    string queryLaporan = @"
                INSERT INTO Laporan (id_masyarakat, lokasi_kejadian, tanggal, jumlah_korban, gejala) 
                VALUES (@idMasy, @lokasi, @tgl, @korban, @gejala)";

                    SqlCommand cmdLap = new SqlCommand(queryLaporan, conn);
                    cmdLap.Parameters.AddWithValue("@idMasy", newIdMasy);
                    cmdLap.Parameters.AddWithValue("@lokasi", Form2.lokasiKejadian);
                    cmdLap.Parameters.AddWithValue("@tgl", Form2.tanggalKejadian);
                    cmdLap.Parameters.AddWithValue("@korban", int.Parse(txtKorban.Text));
                    cmdLap.Parameters.AddWithValue("@gejala", txtGejala.Text);

                    cmdLap.ExecuteNonQuery(); 

                    MessageBox.Show("Laporan berhasil dikirim!.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form1 formAwal = (Form1)Application.OpenForms["Form1"];
                    formAwal.Show();
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown Error: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            form2.Show();
            this.Hide();
        }
    }
}
