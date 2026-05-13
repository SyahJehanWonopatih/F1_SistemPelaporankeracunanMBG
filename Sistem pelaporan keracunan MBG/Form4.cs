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
    public partial class Form4 : Form
    {

        private readonly Color BgDark = Color.FromArgb(15, 17, 26);
        private readonly Color SidePanel = Color.FromArgb(22, 25, 41);
        private readonly Color Border = Color.FromArgb(42, 45, 62);
        private readonly Color AccentBlue = Color.FromArgb(99, 102, 241);
        private readonly Color AccentGreen = Color.FromArgb(34, 197, 94);
        private readonly Color TextPrimary = Color.FromArgb(226, 232, 240);
        private readonly Color TextMuted = Color.FromArgb(74, 85, 104);
        private readonly Color InputBg = Color.FromArgb(30, 34, 55);

        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;" +
            "Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;" +
            "Integrated Security=True";

        private TextBox _txtNama, _txtKontak, _txtLokasi, _txtGejala, _txtKorban;
        private ComboBox _cmbKota;
        private DateTimePicker _dtpTanggal;

        public Form4()
        {
            InitializeComponent();
            BuildUI();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(_txtNama.Text) ||
        string.IsNullOrWhiteSpace(_txtKontak.Text) ||
        string.IsNullOrWhiteSpace(_txtLokasi.Text) ||
        string.IsNullOrWhiteSpace(_txtGejala.Text) ||
        string.IsNullOrWhiteSpace(_txtKorban.Text))
        {
                MessageBox.Show("Semua field harus diisi.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string qMasyarakat = @"
                INSERT INTO Masyarakat (nama_pelapor, kontak, alamat, kota_kab)
                VALUES (@nama, @kontak, @alamat, @kota);
                SELECT SCOPE_IDENTITY();";

                    int idMasyarakat;
                    using (SqlCommand cmd = new SqlCommand(qMasyarakat, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", _txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@kontak", _txtKontak.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", _txtLokasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@kota", _cmbKota.SelectedItem.ToString());
                        idMasyarakat = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string qLaporan = @"
                INSERT INTO Laporan
                    (id_masyarakat, lokasi_kejadian, tanggal, jumlah_korban, gejala, status_validasi)
                VALUES
                    (@idMasy, @lokasi, @tanggal, @korban, @gejala, 'Pending')";

                    using (SqlCommand cmd = new SqlCommand(qLaporan, conn))
                    {
                        cmd.Parameters.AddWithValue("@idMasy", idMasyarakat);
                        cmd.Parameters.AddWithValue("@lokasi", _txtLokasi.Text.Trim());
                        cmd.Parameters.AddWithValue("@tanggal", _dtpTanggal.Value.Date);
                        cmd.Parameters.AddWithValue("@korban", int.Parse(_txtKorban.Text));
                        cmd.Parameters.AddWithValue("@gejala", _txtGejala.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Laporan berhasil dikirim!\nStatus: Pending.",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                new Form1().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal kirim laporan:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtGejala_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuildUI()
        {
            this.Text = "Form Laporan MBG";
            this.Size = new Size(900, 620);
            this.MinimumSize = new Size(900, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = BgDark;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Font = new Font("Segoe UI", 9f);
            this.Controls.Clear();

            Panel main = new Panel
            {
                BackColor = BgDark,
                Dock = DockStyle.Fill,
                Padding = new Padding(40, 20, 40, 20),
                AutoScroll = true
            };
            this.Controls.Add(main);

            Panel sidebar = new Panel
            {
                Width = 220,
                BackColor = SidePanel,
                Dock = DockStyle.Left
            };
            this.Controls.Add(sidebar);

            // ═══ ISI SIDEBAR ═════════════════════════════════════════
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

            sidebar.Controls.Add(new Label
            {
                Text = "MENU",
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = TextMuted,
                Location = new Point(20, 230),
                Size = new Size(180, 20),
                BackColor = Color.Transparent
            });

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
                BackColor = AccentGreen
            });
            menuActive.Controls.Add(new Label
            {
                Text = "Form Laporan",
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = TextPrimary,
                Location = new Point(16, 10),
                Size = new Size(180, 20),
                BackColor = Color.Transparent
            });
            sidebar.Controls.Add(menuActive);

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

            // Card container — center di tengah main panel
            Panel card = new Panel
            {
                BackColor = Color.FromArgb(22, 25, 41),
                Size = new Size(680, 460),
                Anchor = AnchorStyles.None  // biar bisa di-center
            };

            // Center card saat form resize
            main.Resize += (s, e) => {
                card.Location = new Point(
                    (main.ClientSize.Width - card.Width) / 2,
                    (main.ClientSize.Height - card.Height) / 2
                );
            };
            // Set posisi awal
            card.Location = new Point(
                (main.ClientSize.Width - 680) / 2,
                (main.ClientSize.Height - 460) / 2
            );
            main.Controls.Add(card);

            // Heading di dalam card
            card.Controls.Add(new Label
            {
                Text = "Form Laporan Keracunan",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = TextPrimary,
                Location = new Point(30, 20),
                Size = new Size(500, 34),
                BackColor = Color.Transparent
            });

            card.Controls.Add(new Label
            {
                Text = "Isi data dengan lengkap dan benar.",
                Font = new Font("Segoe UI", 9f),
                ForeColor = TextMuted,
                Location = new Point(30, 56),
                Size = new Size(400, 20),
                BackColor = Color.Transparent
            });

            // Divider
            card.Controls.Add(new Panel
            {
                Size = new Size(620, 1),
                Location = new Point(30, 84),
                BackColor = Border
            });

            int col1 = 30, col2 = 360, startY = 100, gap = 88;

            // ── Kolom Kiri ───────────────────────────────────────────
            AddLabel(card, "Nama Pelapor", col1, startY);
            _txtNama = AddTextBox(card, col1, startY + 24, 290);
            _txtNama.KeyPress += (s, e) => {
                bool ok = char.IsLetter(e.KeyChar) || e.KeyChar == ' '
                       || e.KeyChar == (char)Keys.Back;
                if (!ok) e.Handled = true;
            };

            AddLabel(card, "Nomor Kontak", col1, startY + gap);
            _txtKontak = AddTextBox(card, col1, startY + gap + 24, 290);
            _txtKontak.KeyPress += (s, e) => {
                bool ok = char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back;
                if (!ok) e.Handled = true;
            };

            AddLabel(card, "Kota / Kabupaten", col1, startY + gap * 2);
            _cmbKota = new ComboBox
            {
                Location = new Point(col1, startY + gap * 2 + 24),
                Size = new Size(290, 36),
                BackColor = InputBg,
                ForeColor = TextPrimary,
                Font = new Font("Segoe UI", 10f),
                FlatStyle = FlatStyle.Flat,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cmbKota.Items.AddRange(new object[] {
    "Yogyakarta", "Jakarta", "Bandung",
    "Manado", "Surabaya", "Mojokerto", "Riau"
});
            _cmbKota.SelectedIndex = 0;
            card.Controls.Add(_cmbKota);

            AddLabel(card, "Jumlah Korban", col1, startY + gap * 3);
            _txtKorban = AddTextBox(card, col1, startY + gap * 3 + 24, 290);
            _txtKorban.KeyPress += (s, e) => {
                bool ok = char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back;
                if (!ok) e.Handled = true;
            };

            // ── Kolom Kanan ──────────────────────────────────────────
            AddLabel(card, "Lokasi Kejadian", col2, startY);
            _txtLokasi = AddTextBox(card, col2, startY + 24, 290);
            _txtLokasi.KeyPress += (s, e) => {
                bool ok = char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == ' '
                       || e.KeyChar == (char)Keys.Back;
                if (!ok) e.Handled = true;
            };

            AddLabel(card, "Tanggal Kejadian", col2, startY + gap);
            _dtpTanggal = new DateTimePicker
            {
                Location = new Point(col2, startY + gap + 24),
                Size = new Size(290, 36),
                Font = new Font("Segoe UI", 10f),
                Format = DateTimePickerFormat.Long,
                MaxDate = DateTime.Today,
                MinDate = DateTime.Today.AddDays(-7),
                Value = DateTime.Today
            };
            card.Controls.Add(_dtpTanggal);

            AddLabel(card, "Deskripsi Gejala", col2, startY + gap * 2);
            _txtGejala = new TextBox
            {
                Location = new Point(col2, startY + gap * 2 + 24),
                Size = new Size(290, 80),
                BackColor = InputBg,
                ForeColor = TextPrimary,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                Multiline = true
            };
            _txtGejala.KeyPress += (s, e) => {
                bool ok = char.IsLetter(e.KeyChar) || e.KeyChar == ' '
                       || e.KeyChar == (char)Keys.Back || e.KeyChar == '\r';
                if (!ok) e.Handled = true;
            };
            card.Controls.Add(_txtGejala);

            // ── Divider bawah ─────────────────────────────────────────
            card.Controls.Add(new Panel
            {
                Size = new Size(620, 1),
                Location = new Point(30, 390),
                BackColor = Border
            });

            // ── Tombol ───────────────────────────────────────────────
            Button btnBack = new Button
            {
                Text = "← Kembali",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 40),
                Location = new Point(30, 406),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBack.Click += (s, e) => this.Close();
            card.Controls.Add(btnBack);

            Button btnKirim = new Button
            {
                Text = "✔  Kirim Laporan",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = AccentGreen,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(180, 40),
                Location = new Point(470, 406),
                Cursor = Cursors.Hand
            };
            btnKirim.FlatAppearance.BorderSize = 0;
            btnKirim.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 163, 74);
            btnKirim.Click += button1_Click;
            card.Controls.Add(btnKirim);
        }

        // ── Helper label ─────────────────────────────────────────────
        private void AddLabel(Panel parent, string text, int x, int y)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = TextMuted,
                Location = new Point(x, y),
                Size = new Size(280, 20),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });
        }

        // ── Helper textbox ───────────────────────────────────────────
        private TextBox AddTextBox(Panel parent, int x, int y, int width)
        {
            TextBox tb = new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 36),
                BackColor = InputBg,
                ForeColor = Color.FromArgb(226, 232, 240),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            parent.Controls.Add(tb);
            return tb;
        }



    }
}
