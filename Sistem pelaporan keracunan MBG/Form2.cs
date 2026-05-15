using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_pelaporan_keracunan_MBG
{
    public partial class Form2 : Form
    {
       

        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";

        private readonly Color BgDark = Color.FromArgb(15, 17, 26);
        private readonly Color SidePanel = Color.FromArgb(22, 25, 41);
        private readonly Color CardBg = Color.FromArgb(22, 25, 41);
        private readonly Color Border = Color.FromArgb(42, 45, 62);
        private readonly Color AccentBlue = Color.FromArgb(99, 102, 241);
        private readonly Color TextPrimary = Color.FromArgb(226, 232, 240);
        private readonly Color TextMuted = Color.FromArgb(74, 85, 104);
        private readonly Color InputBg = Color.FromArgb(30, 34, 55);

        private TextBox txtUsername;
        private TextBox txtPassword;

        public bool LoginSuccess { get; private set; } = false;


        public Form2()
        {
            InitializeComponent();
            BuildUI();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Username dan password tidak boleh kosong.", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "SELECT COUNT(*) FROM Admin WHERE username='" + user + "' AND password='" + pass + "'";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        LoginSuccess = true; 
                        MessageBox.Show("Login berhasil!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        new Form3().Show();
                        this.Close();
                    }
                    else
                    {
                        txtPassword.Clear();
                        MessageBox.Show("Username atau password salah.", "Login Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal konek ke database:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            private Panel MakeInputBox(Panel parent, int x, int y)
        {
            Panel box = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(360, 48),
                BackColor = InputBg,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // Border kiri accent
            box.Controls.Add(new Panel
            {
                Size = new Size(3, 48),
                Location = new Point(0, 0),
                BackColor = AccentBlue
            });

            parent.Controls.Add(box);
            return box;
        }

        private void BuildUI()
        {
            this.Text = "Login Admin";
            this.Size = new Size(860, 520);
            this.MinimumSize = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = BgDark;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Font = new Font("Segoe UI", 9f);
            this.Controls.Clear();

            // ── Main panel (Fill — duluan) ────────────────────────────
            Panel main = new Panel
            {
                BackColor = BgDark,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(main);

            // ── Sidebar (Left — setelah main) ─────────────────────────
            Panel sidebar = new Panel
            {
                Width = 240,
                BackColor = SidePanel,
                Dock = DockStyle.Left
            };
            this.Controls.Add(sidebar);

            // ═══ ISI SIDEBAR ════════════════════════════════════════

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
                Location = new Point(20, 192),
                BackColor = Color.Transparent
            });

            sidebar.Controls.Add(new Panel
            {
                Size = new Size(140, 1),
                Location = new Point(50, 226),
                BackColor = Border
            });

            sidebar.Controls.Add(new Label
            {
                Text = "v1.0.0  •  2025",
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(45, 51, 72),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(200, 20),
                Location = new Point(20, sidebar.Height - 36),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            });

            // ═══ ISI MAIN ═══════════════════════════════════════════

            // Heading


            main.Controls.Add(new Label
            {
                Text = "Masukkan kredensial untuk melanjutkan.",
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = TextMuted,
                Location = new Point(50, 104),
                Size = new Size(400, 22),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });

            // ── Field Username ───────────────────────────────────────
            main.Controls.Add(new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = TextMuted,
                Location = new Point(50, 158),
                Size = new Size(200, 20),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });

            Panel userBox = MakeInputBox(main, 50, 182);
            txtUsername = new TextBox
            {
                Dock = DockStyle.Fill,
                BackColor = InputBg,
                ForeColor = TextPrimary,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10f),
                Margin = new Padding(10, 0, 10, 0)
            };
            // Padding workaround pakai panel dalam
            Panel userInner = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = InputBg,
                Padding = new Padding(12, 0, 12, 0)
            };
            userInner.Controls.Add(txtUsername);
            userBox.Controls.Add(userInner);

            // ── Field Password ───────────────────────────────────────
            main.Controls.Add(new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = TextMuted,
                Location = new Point(50, 258),
                Size = new Size(200, 20),
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            });

            Panel passBox = MakeInputBox(main, 50, 282);
            txtPassword = new TextBox
            {
                Dock = DockStyle.Fill,
                BackColor = InputBg,
                ForeColor = TextPrimary,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10f),
                PasswordChar = '●'
            };
            Panel passInner = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = InputBg,
                Padding = new Padding(12, 0, 12, 0)
            };
            passInner.Controls.Add(txtPassword);
            passBox.Controls.Add(passInner);

            // ── Tombol Login ─────────────────────────────────────────
            Button btnLogin = new Button
            {
                Text = "Login",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = AccentBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(160, 44),
                Location = new Point(50, 358),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(79, 82, 221);
            btnLogin.Click += btnLogin_Click;
            main.Controls.Add(btnLogin);


            // ── Tombol Kembali ───────────────────────────────────────
            Button btnBack = new Button
            {
                Text = "← Kembali",
                Font = new Font("Segoe UI", 9f),
                ForeColor = TextMuted,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 44),
                Location = new Point(222, 358),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBack.Click += (s, e) => { this.Close(); };
            main.Controls.Add(btnBack);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
