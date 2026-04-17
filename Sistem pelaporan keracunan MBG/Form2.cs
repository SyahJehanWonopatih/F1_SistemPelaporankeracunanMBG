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
    public partial class Form2 : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxLokasi.Text))
            {
                MessageBox.Show("Lokasi Harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form3 formGejala = new Form3();
            formGejala.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formAwal = (Form1)Application.OpenForms["Form1"];
            formAwal.Show();
            this.Hide();
        }
    }
}
