using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_pelaporan_keracunan_MBG
{
    public partial class Form7 : Form
    {
        private readonly Color BgDark = Color.FromArgb(15, 17, 26);
        private readonly Color SidePanel = Color.FromArgb(22, 25, 41);
        private readonly Color CardBg = Color.FromArgb(22, 25, 41);
        private readonly Color Border = Color.FromArgb(42, 45, 62);
        private readonly Color AccentBlue = Color.FromArgb(99, 102, 241);
        private readonly Color AccentGreen = Color.FromArgb(34, 197, 94);
        private readonly Color AccentRed = Color.FromArgb(239, 68, 68);
        private readonly Color TextPrimary = Color.FromArgb(226, 232, 240);
        private readonly Color TextMuted = Color.FromArgb(74, 85, 104);
        private readonly Color TableBg = Color.FromArgb(18, 21, 33);

        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;" +
            "Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;" +
            "Integrated Security=True";
        private DataGridView dgvPreview;
        private Button btnImportDb;
        private DataTable dtExcel;

        public Form7(FormWindowState state = FormWindowState.Normal)
        {
            InitializeComponent();
            BuildUI();
            this.WindowState = state;
        }

        private void BuildUI()
        {
            this.Text = "Import Data Excel";
            this.Size = new Size(1100, 650);
            this.MinimumSize = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = BgDark;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Font = new Font("Segoe UI", 9f);
            this.Controls.Clear();

            Panel main = new Panel { BackColor = BgDark, Dock = DockStyle.Fill, Padding = new Padding(30, 20, 30, 20) };
            Panel sidebar = new Panel { Width = 220, BackColor = SidePanel, Dock = DockStyle.Left };
            this.Controls.Add(main);
            this.Controls.Add(sidebar);

            // ═══ SIDEBAR ════════════════════════════════════════
            Panel logoBox = new Panel { Size = new Size(56, 56), Location = new Point(82, 50), BackColor = Color.FromArgb(30, 36, 64) };
            logoBox.Controls.Add(new Label { Text = "✦", Font = new Font("Segoe UI", 20f, FontStyle.Bold), ForeColor = AccentBlue, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, BackColor = Color.Transparent });
            sidebar.Controls.Add(logoBox);

            sidebar.Controls.Add(new Label { Text = "Sistem Pelaporan\nMBG", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = TextPrimary, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(180, 55), Location = new Point(20, 118), BackColor = Color.Transparent });
            sidebar.Controls.Add(new Label { Text = "Makan Bergizi Gratis", Font = new Font("Segoe UI", 8f), ForeColor = TextMuted, TextAlign = ContentAlignment.MiddleCenter, Size = new Size(180, 20), Location = new Point(20, 176), BackColor = Color.Transparent });
            sidebar.Controls.Add(new Panel { Size = new Size(130, 1), Location = new Point(45, 210), BackColor = Border });
            sidebar.Controls.Add(new Label { Text = "MENU", Font = new Font("Segoe UI", 7.5f, FontStyle.Bold), ForeColor = TextMuted, Location = new Point(20, 230), Size = new Size(180, 20), BackColor = Color.Transparent });

            Panel menuMonitoring = new Panel { Size = new Size(220, 40), Location = new Point(0, 254), BackColor = SidePanel, Cursor = Cursors.Hand };
            menuMonitoring.Controls.Add(new Label { Text = "Monitoring Laporan", Font = new Font("Segoe UI", 9.5f), ForeColor = TextMuted, Location = new Point(16, 10), Size = new Size(180, 20), BackColor = Color.Transparent });
            EventHandler bukaMonitoring = (s, e) => { this.Close(); new Form3(this.WindowState).Show(); };
            menuMonitoring.Click += bukaMonitoring;
            menuMonitoring.MouseEnter += (s, e) => menuMonitoring.BackColor = Color.FromArgb(30, 34, 55);
            menuMonitoring.MouseLeave += (s, e) => menuMonitoring.BackColor = SidePanel;
            foreach (Control c in menuMonitoring.Controls) { c.Click += bukaMonitoring; c.MouseEnter += (s, e) => menuMonitoring.BackColor = Color.FromArgb(30, 34, 55); c.MouseLeave += (s, e) => menuMonitoring.BackColor = SidePanel; }
            sidebar.Controls.Add(menuMonitoring);

            Panel menuCetak = new Panel { Size = new Size(220, 40), Location = new Point(0, 300), BackColor = SidePanel, Cursor = Cursors.Hand };
            menuCetak.Controls.Add(new Label { Text = "Cetak Laporan", Font = new Font("Segoe UI", 9.5f), ForeColor = TextMuted, Location = new Point(16, 10), Size = new Size(180, 20), BackColor = Color.Transparent });
            EventHandler bukaCetak = (s, e) => { this.Close(); new Form5(this.WindowState).Show(); };
            menuCetak.Click += bukaCetak;
            menuCetak.MouseEnter += (s, e) => menuCetak.BackColor = Color.FromArgb(30, 34, 55);
            menuCetak.MouseLeave += (s, e) => menuCetak.BackColor = SidePanel;
            foreach (Control c in menuCetak.Controls) { c.Click += bukaCetak; c.MouseEnter += (s, e) => menuCetak.BackColor = Color.FromArgb(30, 34, 55); c.MouseLeave += (s, e) => menuCetak.BackColor = SidePanel; }
            sidebar.Controls.Add(menuCetak);

            Panel menuActive = new Panel { Size = new Size(220, 40), Location = new Point(0, 346), BackColor = Color.FromArgb(30, 34, 55) };
            menuActive.Controls.Add(new Panel { Size = new Size(3, 40), Location = new Point(0, 0), BackColor = AccentBlue });
            menuActive.Controls.Add(new Label { Text = "Import Excel", Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = TextPrimary, Location = new Point(16, 10), Size = new Size(180, 20), BackColor = Color.Transparent });
            sidebar.Controls.Add(menuActive);

            Button btnBack = new Button
            {
                Text = "↩  Kembali",
                Font = new Font("Segoe UI", 9f),
                ForeColor = AccentRed,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 38),
                Location = new Point(20, sidebar.Height - 60),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 239, 68, 68);
            btnBack.Click += (s, e) => { this.Close(); new Form3(this.WindowState).Show(); };
            sidebar.Controls.Add(btnBack);

            sidebar.Controls.Add(new Label
            {
                Text = "v1.0.0  •  2025",
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(45, 51, 72),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(180, 20),
                Location = new Point(20, sidebar.Height - 28),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            });

            // ═══ MAIN ════════════════════════════════════════════
            main.Controls.Add(new Label { Text = "Import Data Excel", Font = new Font("Segoe UI", 18f, FontStyle.Bold), ForeColor = TextPrimary, Location = new Point(0, 0), Size = new Size(500, 38), BackColor = Color.Transparent });
            main.Controls.Add(new Label { Text = "Upload file Excel untuk import data laporan secara massal.", Font = new Font("Segoe UI", 9.5f), ForeColor = TextMuted, Location = new Point(0, 40), Size = new Size(600, 22), BackColor = Color.Transparent });

            Panel toolbar = new Panel { Location = new Point(0, 80), Size = new Size(900, 50), BackColor = Color.Transparent };
            main.Controls.Add(toolbar);

            Button btnPilihFile = new Button
            {
                Text = "📂  Pilih File Excel",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = AccentBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 38),
                Location = new Point(0, 6),
                Cursor = Cursors.Hand
            };
            btnPilihFile.FlatAppearance.BorderSize = 0;
            btnPilihFile.Click += BtnPilihFile_Click;
            toolbar.Controls.Add(btnPilihFile);

            btnImportDb = new Button
            {
                Text = "💾  Import ke Database",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = AccentGreen,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(200, 38),
                Location = new Point(190, 6),
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnImportDb.FlatAppearance.BorderSize = 0;
            btnImportDb.Click += button2_Click;
            toolbar.Controls.Add(btnImportDb);

            dgvPreview = new DataGridView
            {
                Location = new Point(0, 148),
                Size = new Size(900, 390),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackgroundColor = TableBg,
                GridColor = Border,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 9f),
                ForeColor = TextPrimary,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 40
            };
            dgvPreview.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = SidePanel, ForeColor = TextMuted, Font = new Font("Segoe UI", 9f, FontStyle.Bold), Padding = new Padding(8, 0, 0, 0) };
            dgvPreview.DefaultCellStyle = new DataGridViewCellStyle { BackColor = TableBg, ForeColor = TextPrimary, SelectionBackColor = Color.FromArgb(99, 102, 241, 60), SelectionForeColor = TextPrimary, Padding = new Padding(6, 0, 0, 0) };
            dgvPreview.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = CardBg, ForeColor = TextPrimary };
            main.Controls.Add(dgvPreview);
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void BtnPilihFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
                        });
                        dtExcel = result.Tables[0];
                        foreach (DataColumn col in dtExcel.Columns)
                        {
                            col.ColumnName = col.ColumnName.Trim();
                        }

                        dgvPreview.DataSource = dtExcel;
                        btnImportDb.Enabled = dtExcel.Rows.Count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membaca file Excel:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtExcel == null || dtExcel.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk diimport.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Import {dtExcel.Rows.Count} baris data ke database?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            int sukses = 0;
            int gagal = 0;

            foreach (DataRow row in dtExcel.Rows)
            {
                try
                {
                    string nama = row["nama_pelapor"].ToString().Trim();
                    string kontak = row["kontak"].ToString().Trim();
                    string alamat = row["alamat"].ToString().Trim();
                    string kota = row["kota_kab"].ToString().Trim();
                    string lokasi = row["lokasi_kejadian"].ToString().Trim();
                    string gejala = row["gejala"].ToString().Trim();

                    if (string.IsNullOrEmpty(nama)) { gagal++; continue; }

                    DateTime tanggal;
                    if (!DateTime.TryParse(row["tanggal"].ToString(), out tanggal))
                    {
                        tanggal = DateTime.Today;
                    }

                    int jumlahKorban;
                    if (!int.TryParse(row["jumlah_korban"].ToString(), out jumlahKorban))
                    {
                        jumlahKorban = 0;
                    }

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_InsertLaporan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nama_pelapor", nama);
                        cmd.Parameters.AddWithValue("@kontak", kontak);
                        cmd.Parameters.AddWithValue("@alamat", alamat);
                        cmd.Parameters.AddWithValue("@kota_kab", kota);
                        cmd.Parameters.AddWithValue("@lokasi_kejadian", lokasi);
                        cmd.Parameters.AddWithValue("@tanggal", tanggal);
                        cmd.Parameters.AddWithValue("@jumlah_korban", jumlahKorban);
                        cmd.Parameters.AddWithValue("@gejala", gejala);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    sukses++;
                }
                catch
                {
                    gagal++;
                }
            }

            MessageBox.Show($"Import selesai!\nBerhasil: {sukses}\nGagal: {gagal}", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgvPreview.DataSource = null;
            dtExcel = null;
            btnImportDb.Enabled = false;
        }
    
    }
}
