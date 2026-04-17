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
        public static string namaLengkap = "";
        public static string noKontak = "";
        public static string kotaKab = "";

        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxKotaKab.Items.Add("Manado");
            comboBoxKotaKab.Items.Add("Kota Yogyakarta");
            comboBoxKotaKab.Items.Add("sleman");
            comboBoxKotaKab.Items.Add("Bandung");
            comboBoxKotaKab.Items.Add("Jakarta");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            namaLengkap = txtBoxNamaLengkap.Text;
            noKontak = txtBoxNomorKontak.Text;
            kotaKab = comboBoxKotaKab.SelectedItem.ToString();

            if (string.IsNullOrEmpty(txtBoxNamaLengkap.Text) || string.IsNullOrEmpty(txtBoxNomorKontak.Text) || comboBoxKotaKab.SelectedIndex == -1)
            {
                MessageBox.Show("isi semua datanya!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form2 formKejadian = new Form2();

            

            formKejadian.Show();
            this.Hide(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 login = new Form4();
            login.ShowDialog();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

