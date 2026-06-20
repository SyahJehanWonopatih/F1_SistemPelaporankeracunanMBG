using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_pelaporan_keracunan_MBG
{
    public static class Koneksi
    {
        private static string ConfigPath =>
            Path.Combine(Application.StartupPath, "server_config.txt");

        public static string GetConnectionString()
        {
            string ip = GetServerIP();
            return $"Data Source={ip}\\SYAHJEHAN00;" +
                   "Initial Catalog=Sistem_Pelaporan_Keracunan_MBG;" +
                   "User ID=mbg_user;" +
                   "Password=adminmbg123;";
        }

        private static string GetServerIP()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    string ip = File.ReadAllText(ConfigPath).Trim();
                    if (!string.IsNullOrEmpty(ip)) return ip;
                }
            }
            catch { }

            return "127.0.0.1"; // fallback kalau file ga ketemu
        }
    }
}
