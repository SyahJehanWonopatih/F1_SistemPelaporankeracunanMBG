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
    public partial class Form1 : Form
    {

        private readonly Color BgDark = Color.FromArgb(15, 17, 26);
        private readonly Color SidePanel = Color.FromArgb(22, 25, 41);
        private readonly Color CardBg = Color.FromArgb(22, 25, 41);
        private readonly Color CardHover = Color.FromArgb(30, 34, 55);
        private readonly Color Border = Color.FromArgb(42, 45, 62);
        private readonly Color AccentBlue = Color.FromArgb(99, 102, 241);
        private readonly Color AccentGreen = Color.FromArgb(34, 197, 94);
        private readonly Color TextPrimary = Color.FromArgb(226, 232, 240);
        private readonly Color TextMuted = Color.FromArgb(74, 85, 104);

        public Form1()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text = "Sistem Pelaporan MBG";
            this.Size = new Size(860, 520);
            this.MinimumSize = new Size(860, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = BgDark;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Font = new Font("Segoe UI", 9f);
            this.Controls.Clear();

            // ── DEKLARASI PANEL ──────────────────────────────────────
            Panel sidebar = new Panel
            {
                Width = 240,
                BackColor = SidePanel,
                Dock = DockStyle.Left
            };

            Panel main = new Panel
            {
                BackColor = BgDark,
                Dock = DockStyle.Fill,
                Padding = new Padding(50, 0, 0, 0)
            };

            // Fill dulu, Left belakangan
            this.Controls.Add(main);
            this.Controls.Add(sidebar);

            // ── ISI SIDEBAR ───────────────────────────────────────────
            Panel logoBox = new Panel
            {
                Size = new Size(56, 56),
                Location = new Point(92, 60),
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
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = TextPrimary,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(200, 58),
                Location = new Point(20, 130),
                BackColor = Color.Transparent
            });

            sidebar.Controls.Add(new Label
            {
                Text = "Makan Bergizi Gratis",
                Font = new Font("Segoe UI", 8f),
                ForeColor = TextMuted,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(200, 20),
                Location = new Point(20, 190),
                BackColor = Color.Transparent
            });

            sidebar.Controls.Add(new Panel
            {
                Size = new Size(140, 1),
                Location = new Point(50, 224),
                BackColor = Border
            });

            sidebar.Controls.Add(new Label
            {
                Text = "v1.0.0  •  2025",
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(45, 51, 72),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(200, 20),
                Location = new Point(20, this.ClientSize.Height - 36),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                BackColor = Color.Transparent
            });

            // ── ISI MAIN ─────────────────────────────────────────────
            main.Controls.Add(new Label
            {
                Text = "Selamat Datang",
                Font = new Font("Segoe UI", 20f, FontStyle.Bold),
                ForeColor = TextPrimary,
                Location = new Point(0, 90),
                Size = new Size(400, 40),
                BackColor = Color.Transparent
            });

            main.Controls.Add(new Label
            {
                Text = "Pilih opsi di bawah untuk melanjutkan.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = TextMuted,
                Location = new Point(0, 134),
                Size = new Size(400, 22),
                BackColor = Color.Transparent
            });

            // ── CARD ADMIN ────────────────────────────────────────────
            Panel cardAdmin = MakeCard(main, 0, 185,
                "Login Admin", "Masuk sebagai administrator sistem", AccentBlue);
            EventHandler openAdmin = (s, e) => {
                var state = this.WindowState;
                this.Hide();
                using (var f = new Form2())
                {
                    f.WindowState = state;
                    f.ShowDialog();
                    if (!f.LoginSuccess) { this.Show(); this.WindowState = state; }
                }
            };
            cardAdmin.Click += openAdmin;
            foreach (Control c in cardAdmin.Controls) c.Click += openAdmin;

            // ── CARD LAPOR ────────────────────────────────────────────
            Panel cardLapor = MakeCard(main, 0, 295,
                "Melapor", "Laporkan kejadian keracunan MBG", AccentGreen);
            cardLapor.Click += (s, e) => {
                var state = this.WindowState;
                this.Hide();
                var f4 = new Form4();
                f4.WindowState = state;
                f4.ShowDialog();
                this.Show();
                this.WindowState = state;
            };
            foreach (Control c in cardLapor.Controls)
                c.Click += (s, e) => {
                    var state = this.WindowState;
                    this.Hide();
                    var f4 = new Form4();
                    f4.WindowState = state;
                    f4.ShowDialog();
                    this.Show();
                    this.WindowState = state;
                };
        }

        private Panel MakeCard(Panel parent, int x, int y, string title, string desc, Color accent)
        {
            Panel card = new Panel
            {
                Size = new Size(500, 88),
                Location = new Point(x, y),
                BackColor = CardBg,
                Cursor = Cursors.Hand,
            };

            // Accent bar kiri
            Panel bar = new Panel
            {
                Size = new Size(4, 88),
                Location = new Point(0, 0),
                BackColor = accent,
            };
            card.Controls.Add(bar);

            // Icon box
            Panel iconBox = new Panel
            {
                Size = new Size(40, 40),
                Location = new Point(22, 24),
                BackColor = Color.FromArgb(accent.R / 6, accent.G / 6, accent.B / 6 + 10),
            };
            card.Controls.Add(iconBox);

            Label iconLbl = new Label
            {
                Text = accent == Color.FromArgb(99, 102, 241) ? "⚿" : "✎",
                Font = new Font("Segoe UI", 16f),
                ForeColor = accent,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
            };
            iconBox.Controls.Add(iconLbl);

            Label titleLbl = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = TextPrimary,
                Location = new Point(76, 18),
                Size = new Size(380, 26),
                BackColor = Color.Transparent,
            };
            card.Controls.Add(titleLbl);

            Label descLbl = new Label
            {
                Text = desc,
                Font = new Font("Segoe UI", 9f),
                ForeColor = TextMuted,
                Location = new Point(76, 48),
                Size = new Size(380, 20),
                BackColor = Color.Transparent,
            };
            card.Controls.Add(descLbl);

            // Hover effect
            card.MouseEnter += (s, e) => card.BackColor = CardHover;
            card.MouseLeave += (s, e) => card.BackColor = CardBg;

            parent.Controls.Add(card);
            return card;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form4 Report = new Form4();
            Report.ShowDialog();
            this.Hide();
        }
    }
}

