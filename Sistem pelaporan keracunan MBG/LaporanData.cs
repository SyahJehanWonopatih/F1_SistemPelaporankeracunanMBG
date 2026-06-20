using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_pelaporan_keracunan_MBG
{
    public class LaporanData
    {
        public int IdLaporan { get; set; }
        public string NamaPelapor { get; set; }
        public string Kontak { get; set; }
        public string KotaKab { get; set; }
        public string LokasiKejadian { get; set; }
        public DateTime Tanggal { get; set; }
        public int JumlahKorban { get; set; }
        public string Gejala { get; set; }
        public string StatusValidasi { get; set; }
    }
}
