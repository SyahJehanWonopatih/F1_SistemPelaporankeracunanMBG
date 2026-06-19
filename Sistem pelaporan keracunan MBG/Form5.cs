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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form6 formCetak = new Form6(
                dateTimePicker1.Value.Date,
                dateTimePicker2.Value.Date
            );
            formCetak.Show();
        }
    }
}
