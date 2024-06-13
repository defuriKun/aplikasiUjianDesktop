using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasiUlangan
{
    class KF
    {
        public static flogin flogin = new flogin();
        public static FCetak FCetak = new FCetak();
        public static fhasil fhasil = new fhasil() { TopMost = true, TopLevel = false };
        public static fulangan fulangan = new fulangan() { TopMost = true, TopLevel = false };
        public static fjawaban fjawaban = new fjawaban() { TopMost = true, TopLevel = false };
        public static fsoal fsoal = new fsoal() { TopMost = true, TopLevel = false };
        public static fuser fuser = new fuser() { TopMost = true, TopLevel = false };
        public static fsiswa fsiswa = new fsiswa() { TopMost = true, TopLevel = false };
        public static fguru fguru = new fguru() { TopMost = true, TopLevel = false };
        public static fmapel fmapel = new fmapel() { TopMost = true, TopLevel = false };
        public static fkelas fkelas = new fkelas() { TopMost = true, TopLevel = false };

        public static void untukform(Form fapa, Panel pnlapa)
        {
            pnlapa.Controls.Clear();
            pnlapa.Controls.Add(fapa);
            fapa.FormBorderStyle = FormBorderStyle.None;
            fapa.Dock = DockStyle.Fill;
            fapa.Show();
        }
    }
}
