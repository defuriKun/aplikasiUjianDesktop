using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace aplikasiUlangan
{
    class logika
    {
        public static void sidebar(Timer timerapa, Panel pnlapa)
        {
            timerapa.Start();

            if (pnlapa.AutoScroll == false)
            {
                if (pnlapa.Width == 202)
                {
                    while (pnlapa.Width > 0)
                    {
                        pnlapa.Width -= 4;
                        if (pnlapa.Width < 0)
                        {
                            pnlapa.Width = 0;
                            timerapa.Stop();
                        }
                        timerapa.Stop();
                    }
                }
                else
                {
                    while (pnlapa.Width < 202)
                    {
                        pnlapa.Width += 4;
                        if (pnlapa.Width > 202)
                        {
                            pnlapa.Width = 202;
                            timerapa.Stop();
                        }
                        timerapa.Stop();
                    }
                }
            }
            else
            {
                pnlapa.AutoScroll = false;

                if (pnlapa.Width == 219)
                {
                    while (pnlapa.Width > 0)
                    {
                        pnlapa.Width -= 4;
                        if (pnlapa.Width < 0)
                        {
                            pnlapa.Width = 0;
                            timerapa.Stop();
                        }
                        timerapa.Stop();
                    }
                }
                else
                {
                    while (pnlapa.Width < 219)
                    {
                        pnlapa.Width += 4;
                        if (pnlapa.Width > 219)
                        {
                            pnlapa.Width = 219;
                            timerapa.Stop();
                        }
                        timerapa.Stop();
                    }
                }

                pnlapa.AutoScroll = true;
            }
        }

        public static void judul(Label namaLabel, Panel namaPanel)
        {
            namaLabel.Left = namaPanel.Width / 2 - 40;
        }

        public static void cariBerubah(TextBox txtcari)
        {
            if (txtcari.Text != "Cari...")
            {
                txtcari.ForeColor = Color.Black;
            }
        }

        public static void cariEnter(TextBox txtcari)
        {
            if (txtcari.Text == "Cari...")
            {
                txtcari.Text = "";
            }
        }

        public static void cariLeave(TextBox txtcari)
        {
            if (txtcari.Text == "")
            {
                txtcari.Text = "Cari...";
                txtcari.ForeColor = Color.Gray;
            }
        }

        public static void cariQuery(TextBox txtcari, String query, DataGridView dgv)
        {
            if (txtcari.Text != "Cari...")
            {
                SQL.tampilgrid(query, dgv);
            }
        }

        public static void warnaiText(TextBox txt)
        {
            txt.Text = "Cari...";
            txt.ForeColor = Color.Gray;
        }
    }
}
