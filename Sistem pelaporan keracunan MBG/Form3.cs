using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_pelaporan_keracunan_MBG
{
    public partial class Form3 : Form
    {
        private readonly Color BgDark = Color.FromArgb(15, 17, 26);
        private readonly Color SidePanel = Color.FromArgb(22, 25, 41);
        private readonly Color CardBg = Color.FromArgb(22, 25, 41);
        private readonly Color Border = Color.FromArgb(42, 45, 62);
        private readonly Color AccentBlue = Color.FromArgb(99, 102, 241);
        private readonly Color AccentGreen = Color.FromArgb(34, 197, 94);
        private readonly Color AccentRed = Color.FromArgb(239, 68, 68);
        private readonly Color AccentAmber = Color.FromArgb(245, 158, 11);
        private readonly Color TextPrimary = Color.FromArgb(226, 232, 240);
        private readonly Color TextMuted = Color.FromArgb(74, 85, 104);
        private readonly Color TableBg = Color.FromArgb(18, 21, 33);

        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;" +
            "Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;" +
            "Integrated Security=True";

        private DataGridView dgvRaporan;
        private TextBox txtSearch;
        private BindingSource _bindingSource = new BindingSource();
        private Label lblTotal;
        private BindingNavigator _navigator;


        public Form3()
        {
            InitializeComponent();
            BuildUI();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadLaporan();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvRaporan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih laporan yang ingin dihapus.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var confirm = MessageBox.Show("Yakin ingin menghapus laporan ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var id = dgvRaporan.SelectedRows[0].Cells["id_laporan"].Value;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_laporan", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Laporan berhasil dihapus.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTolakLaporan_Click(object sender, EventArgs e)
        {
            if (dgvRaporan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih laporan yang ingin ditolak.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var id = dgvRaporan.SelectedRows[0].Cells["id_laporan"].Value;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateStatusLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_laporan", id);
                    cmd.Parameters.AddWithValue("@status_validasi", "Ditolak");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Laporan berhasil ditolak.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerima_Click(object sender, EventArgs e)
        {
            if (dgvRaporan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih laporan yang ingin diterima.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var id = dgvRaporan.SelectedRows[0].Cells["id_laporan"].Value;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateStatusLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_laporan", id);
                    cmd.Parameters.AddWithValue("@status_validasi", "Di Proses");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Laporan berhasil diproses.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
            "ingin logout?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var state = this.WindowState;
                this.Close();
                var f1 = new Form1();
                f1.WindowState = state;
                f1.Show();
            }
        }

        private void BuildUI()
        {
            this.Text = "Monitoring Admin MBG";
            this.Size = new Size(1000, 620);
            this.MinimumSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = BgDark;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Font = new Font("Segoe UI", 9f);
            this.Controls.Clear();

            // ── Main panel (Fill duluan) ──────────────────────────────
            Panel main = new Panel
            {
                BackColor = BgDark,
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 20, 30, 20)
            };
            this.Controls.Add(main);

            // ── Sidebar (Left setelah main) ───────────────────────────
            Panel sidebar = new Panel
            {
                Width = 220,
                BackColor = SidePanel,
                Dock = DockStyle.Left
            };
            this.Controls.Add(sidebar);

            // ═══ ISI SIDEBAR ════════════════════════════════════════
            Panel logoBox = new Panel
            {
                Size = new Size(56, 56),
                Location = new Point(82, 50),
                BackColor = Color.FromArgb(30, 36, 64)
            };
            logoBox.Controls.Add(new Label
            {
                Text = "✦",
                Font = new Font("Segoe UI", 20f, FontStyle.Bold),
                ForeColor = AccentBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            });
            sidebar.Controls.Add(logoBox);

            sidebar.Controls.Add(new Label
            {
                Text = "Sistem Pelaporan\nMBG",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = TextPrimary,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(180, 55),
                Location = new Point(20, 118),
                BackColor = Color.Transparent
            });

            sidebar.Controls.Add(new Label
            {
                Text = "Makan Bergizi Gratis",
                Font = new Font("Segoe UI", 8f),
                ForeColor = TextMuted,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(180, 20),
                Location = new Point(20, 176),
                BackColor = Color.Transparent
            });

            sidebar.Controls.Add(new Panel
            {
                Size = new Size(130, 1),
                Location = new Point(45, 210),
                BackColor = Border
            });

            // Menu label
            sidebar.Controls.Add(new Label
            {
                Text = "MENU",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = TextMuted,
                Location = new Point(20, 230),
                Size = new Size(180, 20),
                BackColor = Color.Transparent
            });



            // Menu item aktif
            Panel menuActive = new Panel
            {
                Size = new Size(220, 40),
                Location = new Point(0, 254),
                BackColor = Color.FromArgb(30, 34, 55)
            };
            menuActive.Controls.Add(new Panel
            {
                Size = new Size(3, 40),
                Location = new Point(0, 0),
                BackColor = AccentBlue
            });
            menuActive.Controls.Add(new Label
            {
                Text = "Monitoring Laporan",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = TextPrimary,
                Location = new Point(16, 10),
                Size = new Size(180, 20),
                BackColor = Color.Transparent
            });
            sidebar.Controls.Add(menuActive);

            Panel menuCetak = new Panel
            {
                Size = new Size(220, 40),
                Location = new Point(0, 300),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };
            menuCetak.Controls.Add(new Label
            {
                Text = "Cetak Laporan",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = TextMuted,
                Location = new Point(16, 10),
                Size = new Size(180, 20),
                BackColor = Color.Transparent
            });
            EventHandler bukaCetak = (s, e) => { new Form5(this.WindowState).Show(); };
            menuCetak.Click += bukaCetak;
            menuCetak.MouseEnter += (s, e) => menuCetak.BackColor = Color.FromArgb(30, 34, 55);
            menuCetak.MouseLeave += (s, e) => menuCetak.BackColor = Color.Transparent;
            foreach (Control c in menuCetak.Controls)
            {
                c.Click += bukaCetak;
                c.MouseEnter += (s, e) => menuCetak.BackColor = Color.FromArgb(30, 34, 55);
                c.MouseLeave += (s, e) => menuCetak.BackColor = Color.Transparent;
            }
            sidebar.Controls.Add(menuCetak);

            // Logout button di bawah sidebar
            Button btnLogout = new Button
            {
                Text = "↩  Logout",
                Font = new Font("Segoe UI", 9f),
                ForeColor = AccentRed,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 38),
                Location = new Point(20, sidebar.Height - 60),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 239, 68, 68);
            btnLogout.Click += btnLogout_Click;
            sidebar.Controls.Add(btnLogout);

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

            // ═══ ISI MAIN ════════════════════════════════════════════

            // Header
            main.Controls.Add(new Label
            {
                Text = "Monitoring Laporan",
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = TextPrimary,
                Location = new Point(0, 0),
                Size = new Size(500, 38),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });

            main.Controls.Add(new Label
            {
                Text = "Kelola laporan keracunan MBG yang masuk.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = TextMuted,
                Location = new Point(0, 40),
                Size = new Size(500, 22),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });

            // ── Toolbar tombol ────────────────────────────────────────
            Panel toolbar = new Panel
            {
                Location = new Point(0, 80),
                Size = new Size(1020, 50),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            main.Controls.Add(toolbar);

            // Koneksi Database
            Button btnKoneksi = MakeButton("⟳  Refresh Data", AccentBlue, 0);
            btnKoneksi.Click += button1_Click_1;
            toolbar.Controls.Add(btnKoneksi);

            // Terima Laporan
            Button btnTerima = MakeButton("✔  Terima", AccentGreen, 170);
            btnTerima.Click += btnTerima_Click;
            toolbar.Controls.Add(btnTerima);

            // Tolak Laporan
            Button btnTolak = MakeButton("✖  Tolak", AccentAmber, 310);
            btnTolak.Click += btnTolakLaporan_Click;
            toolbar.Controls.Add(btnTolak);

            // Hapus Laporan
            Button btnHapus = MakeButton("🗑  Hapus", AccentRed, 450);
            btnHapus.Click += btnHapus_Click;
            toolbar.Controls.Add(btnHapus);

            // Backup Data
            Button btnBackup = MakeButton("💾  Backup", Color.FromArgb(139, 92, 246), 600);
            btnBackup.Click += (s, e) => BackupData();
            toolbar.Controls.Add(btnBackup);

            Button btnreset = MakeButton("↺  Reset Data", Color.FromArgb(245, 158, 11), 740);
            btnreset.Click += (s, e) => ResetData();
            toolbar.Controls.Add(btnreset);

            // ── Search bar ────────────────────────────────────────────
            Panel searchPanel = new Panel
            {
                Location = new Point(0, 138),
                Size = new Size(700, 40),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            main.Controls.Add(searchPanel);

            txtSearch = new TextBox
            {
                Location = new Point(0, 6),
                Size = new Size(280, 28),
                BackColor = Color.FromArgb(30, 34, 55),
                ForeColor = TextPrimary,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f)
                // hapus PlaceholderText
            };
            searchPanel.Controls.Add(txtSearch);
            

            Button btnSearch = new Button
            {
                Text = "🔍  Cari",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = AccentBlue,
                BackColor = Color.FromArgb(22, 25, 41),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 28),
                Location = new Point(288, 6),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderColor = AccentBlue;
            btnSearch.FlatAppearance.BorderSize = 1;
            btnSearch.Click += (s, e) => {
                string kw = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(kw)) LoadLaporan();
                else SearchLaporan1(kw);
            };
            searchPanel.Controls.Add(btnSearch);

            Button btnReset = new Button
            {
                Text = "✖  Reset",
                Font = new Font("Segoe UI", 9f),
                ForeColor = TextMuted,
                BackColor = Color.FromArgb(22, 25, 41),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(90, 28),
                Location = new Point(396, 6),
                Cursor = Cursors.Hand
            };
            btnReset.FlatAppearance.BorderColor = Border;
            btnReset.FlatAppearance.BorderSize = 1;
            btnReset.Click += (s, e) => { txtSearch.Clear(); LoadLaporan(); };
            searchPanel.Controls.Add(btnReset);

            Button btnSelesai = MakeButton("✔  Selesai", Color.FromArgb(20, 184, 166), 880);
            btnSelesai.Click += btnSelesai_Click;
            toolbar.Controls.Add(btnSelesai);

            // ── DataGridView ──────────────────────────────────────────
            dgvRaporan = new DataGridView
            {
                Location = new Point(0, 190),
                Size = new Size(900, 336),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
                                  | AnchorStyles.Right | AnchorStyles.Bottom,
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
                ColumnHeadersHeight = 40,
            };
            dgvRaporan.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = SidePanel,
                ForeColor = TextMuted,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Padding = new Padding(8, 0, 0, 0)
            };
            dgvRaporan.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = TableBg,
                ForeColor = TextPrimary,
                SelectionBackColor = Color.FromArgb(99, 102, 241, 60),
                SelectionForeColor = TextPrimary,
                Padding = new Padding(6, 0, 0, 0)
            };
            dgvRaporan.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = CardBg,
                ForeColor = TextPrimary,
                SelectionBackColor = Color.FromArgb(50, 99, 102, 241),
                SelectionForeColor = TextPrimary,
            };
            main.Controls.Add(dgvRaporan);


            lblTotal = new Label
            {
                Text = "Total Laporan: 0",
                Font = new Font("Segoe UI", 9f),
                ForeColor = TextMuted,
                Location = new Point(0, 532),
                Size = new Size(300, 20),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            main.Controls.Add(lblTotal);

            // ── Binding Navigator ─────────────────────────────────────
            _navigator = new BindingNavigator(_bindingSource)
            {
                Dock = DockStyle.Bottom,
                BackColor = SidePanel,
                ForeColor = TextPrimary
            };
            this.Controls.Add(_navigator);

            LoadLaporan();
        } 
           
        


        private Button MakeButton(string text, Color color, int x)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = color,
                BackColor = Color.FromArgb(22, 25, 41),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 38),
                Location = new Point(x, 6),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderColor = color;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(
                color.R / 5, color.G / 5, color.B / 5 + 15);
            return btn;
        }


        private void LoadLaporan()
        {
            try
            {
                dgvRaporan.DataSource = null;
                dgvRaporan.Rows.Clear();
                dgvRaporan.Columns.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        _bindingSource.DataSource = dt;
                        dgvRaporan.DataSource = _bindingSource;
                    }
                }
                // SP COUNT — output parameter
                HitungTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HitungTotal()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_CountLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter output = new SqlParameter("@total", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblTotal.Text = "Total Laporan: " + output.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hitung total:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchLaporan1(string keyword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_SearchLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@keyword", keyword);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        _bindingSource.DataSource = dt;
                        dgvRaporan.DataSource = _bindingSource;
                        lblTotal.Text = "Total Laporan: " + dt.Rows.Count;

                        if (dt.Rows.Count == 0)
                            MessageBox.Show("Data tidak ditemukan.", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencari:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackupData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                IF OBJECT_ID('dbo.Laporan_Backup') IS NOT NULL DROP TABLE dbo.Laporan_Backup;
                IF OBJECT_ID('dbo.Masyarakat_Backup') IS NOT NULL DROP TABLE dbo.Masyarakat_Backup;
                SELECT * INTO dbo.Laporan_Backup FROM dbo.Laporan;
                SELECT * INTO dbo.Masyarakat_Backup FROM dbo.Masyarakat;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Backup berhasil dibuat!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Backup gagal:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetData()
        {
            var confirm = MessageBox.Show(
                "Reset akan mengembalikan data ke kondisi backup.\nLanjutkan?",
                "Konfirmasi Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                IF OBJECT_ID('dbo.Laporan_Backup') IS NOT NULL
                BEGIN
                    DELETE FROM dbo.Laporan;
                    DELETE FROM dbo.Masyarakat;
                    SET IDENTITY_INSERT dbo.Masyarakat ON;
                    INSERT INTO dbo.Masyarakat (id_masyarakat, nama_pelapor, kontak, alamat, kota_kab)
                    SELECT id_masyarakat, nama_pelapor, kontak, alamat, kota_kab FROM dbo.Masyarakat_Backup;
                    SET IDENTITY_INSERT dbo.Masyarakat OFF;
                    SET IDENTITY_INSERT dbo.Laporan ON;
                    INSERT INTO dbo.Laporan (id_laporan, id_masyarakat, lokasi_kejadian, tanggal, jumlah_korban, gejala, status_validasi)
                    SELECT id_laporan, id_masyarakat, lokasi_kejadian, tanggal, jumlah_korban, gejala, status_validasi FROM dbo.Laporan_Backup;
                    SET IDENTITY_INSERT dbo.Laporan OFF;
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Data berhasil direset dari backup.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            if (dgvRaporan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih laporan yang ingin diselesaikan.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var id = dgvRaporan.SelectedRows[0].Cells["id_laporan"].Value;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateStatusLaporan", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_laporan", id);
                    cmd.Parameters.AddWithValue("@status_validasi", "Selesai");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Laporan berhasil diselesaikan.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLaporan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {

        }
    }
}
