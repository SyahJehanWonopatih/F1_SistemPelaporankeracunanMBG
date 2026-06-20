using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
