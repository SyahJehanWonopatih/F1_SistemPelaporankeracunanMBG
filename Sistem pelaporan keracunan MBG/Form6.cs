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
    public partial class Form6 : Form
    {
        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;" +
            "Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;" +
            "Integrated Security=True";

        private DateTime tglDari;
        private DateTime tglSampai;
        public Form6(DateTime dari, DateTime sampai)
        {
            InitializeComponent();
            tglDari = dari;
            tglSampai = sampai;

            this.Text = "Cetak Rekap Laporan MBG";
            this.WindowState = FormWindowState.Maximized;

            try
            {
                List<LaporanData> listLaporan = GetDataLaporan();

                LaporanReport report = new LaporanReport();
                report.SetDataSource(listLaporan);

                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<LaporanData> GetDataLaporan()
        {
            List<LaporanData> list = new List<LaporanData>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_ReportLaporan", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tgl_dari", tglDari);
                cmd.Parameters.AddWithValue("@tgl_sampai", tglSampai);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new LaporanData
                        {
                            IdLaporan = Convert.ToInt32(reader["id_laporan"]),
                            NamaPelapor = reader["nama_pelapor"].ToString(),
                            Kontak = reader["kontak"].ToString(),
                            KotaKab = reader["kota_kab"].ToString(),
                            LokasiKejadian = reader["lokasi_kejadian"].ToString(),
                            Tanggal = Convert.ToDateTime(reader["tanggal"]),
                            JumlahKorban = Convert.ToInt32(reader["jumlah_korban"]),
                            Gejala = reader["gejala"].ToString(),
                            StatusValidasi = reader["status_validasi"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
