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
    public partial class Form3 : Form
    {
        private readonly SqlConnection conn;
        private readonly string connectionString =
            "Data Source=TERABYTE\\SYAHJEHAN00;Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
