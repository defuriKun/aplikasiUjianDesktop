using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasiUlangan
{
    public partial class fadmin : Form
    {
        int index = -1;

        public fadmin()
        {
            InitializeComponent();
        }

        private void gantiForm()
        {
            if (index == 1)
            {
                KF.untukform(KF.fhasil, pnlkonten);
                KF.fhasil.tampilData();
            }
            else if (index == 2)
            {
                KF.untukform(KF.fulangan, pnlkonten);
                KF.fulangan.tampilData();
            }
            else if (index == 3)
            {
                KF.untukform(KF.fsoal, pnlkonten);
                KF.fsoal.tampilData();
            }
            else if (index == 4)
            {
                KF.untukform(KF.fjawaban, pnlkonten);
                KF.fjawaban.tampilData();
            }
            else if (index == 5)
            {
                KF.untukform(KF.fuser, pnlkonten);
                KF.fuser.tampilData();
            }
            else if (index == 6)
            {
                KF.untukform(KF.fsiswa, pnlkonten);
                KF.fsiswa.tampilData(); 
            }
            else if (index == 7)
            {
                KF.untukform(KF.fguru, pnlkonten);
                KF.fguru.tampilData();
            }
            else if (index == 8)
            {
                KF.untukform(KF.fmapel, pnlkonten);
                KF.fmapel.tampilData();
            }
            else
            {
                KF.untukform(KF.fkelas, pnlkonten);
                KF.fkelas.tampilData();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pnlanimasi.Width == 80)
            {
                while (pnlanimasi.Width > 0)
                {
                    pnlanimasi.Width--;
                }

                pictureBox13.Visible = false;
            }
            else
            {
                while (pnlanimasi.Width < 80)
                {
                    pnlanimasi.Width++;
                }

                pictureBox13.Visible = true;
            }

            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pnlkonten.Location.X == 137)
            {
                while (pnlkonten.Location.X != 57)
                {
                    Point currentLocation = pnlkonten.Location;
                    currentLocation.X -= 2;
                    pnlkonten.Location = currentLocation;
                }
            }
            else
            {
                while (pnlkonten.Location.X != 137)
                {
                    Point currentLocation = pnlkonten.Location;
                    currentLocation.X += 2;
                    pnlkonten.Location = currentLocation;
                }
            }

            if (pnlkonten.Width == 981)
            {
                while (pnlkonten.Width != 1061)
                {
                    pnlkonten.Width += 2;
                    if (pnlkonten.Width > 1061)
                    {
                        pnlkonten.Width = 1061;
                    }
                    timer2.Stop();
                }
            }
            else
            {
                while (pnlkonten.Width != 981)
                {
                    pnlkonten.Width -= 2;
                    if (pnlkonten.Width < 981)
                    {
                        pnlkonten.Width = 981;
                    }
                    timer2.Stop();
                }
            }
        }

        private void hasilPutih()
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            panel10.BackColor = Color.White;
        }

        private void hasilNormal()
        {
            button2.BackColor = Color.FromArgb(74, 85, 162);
            button2.ForeColor = Color.White;
            panel10.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void ulanganPutih()
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            panel9.BackColor = Color.White;
        }
        private void ulanganNormal()
        {
            button1.BackColor = Color.FromArgb(74, 85, 162);
            button1.ForeColor = Color.White;
            panel9.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void soalPutih()
        {
            btnujian.BackColor = Color.White;
            btnujian.ForeColor = Color.Black;
            panel1.BackColor = Color.White;
        }

        private void soalNormal()
        {
            btnujian.BackColor = Color.FromArgb(74, 85, 162);
            btnujian.ForeColor = Color.White;
            panel1.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void jawabanPutih()
        {
            btnsoal.BackColor = Color.White;
            btnsoal.ForeColor = Color.Black;
            panel2.BackColor = Color.White;
        }

        private void jawabanNormal()
        {
            btnsoal.BackColor = Color.FromArgb(74, 85, 162);
            btnsoal.ForeColor = Color.White;
            panel2.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void userPutih()
        {
            btnuser.BackColor = Color.White;
            btnuser.ForeColor = Color.Black;
            panel3.BackColor = Color.White;
        }

        private void userNormal()
        {
            btnuser.BackColor = Color.FromArgb(74, 85, 162);
            btnuser.ForeColor = Color.White;
            panel3.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void siswaPutih()
        {
            btnsiswa.BackColor = Color.White;
            btnsiswa.ForeColor = Color.Black;
            panel7.BackColor = Color.White;
        }

        private void siswaNormal()
        {
            btnsiswa.BackColor = Color.FromArgb(74, 85, 162);
            btnsiswa.ForeColor = Color.White;
            panel7.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void gurulPutih()
        {
            btnguru.BackColor = Color.White;
            btnguru.ForeColor = Color.Black;
            panel6.BackColor = Color.White;
        }

        private void guruNormal()
        {
            btnguru.BackColor = Color.FromArgb(74, 85, 162);
            btnguru.ForeColor = Color.White;
            panel6.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void mapelPutih()
        {
            btnmapel.BackColor = Color.White;
            btnmapel.ForeColor = Color.Black;
            panel5.BackColor = Color.White;
        }

        private void mapelNormal()
        {
            btnmapel.BackColor = Color.FromArgb(74, 85, 162);
            btnmapel.ForeColor = Color.White;
            panel5.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void kelasPutih()
        {
            btnkelas.BackColor = Color.White;
            btnkelas.ForeColor = Color.Black;
            panel8.BackColor = Color.White;
        }

        private void kelasNormal()
        {
            btnkelas.BackColor = Color.FromArgb(74, 85, 162);
            btnkelas.ForeColor = Color.White;
            panel8.BackColor = Color.FromArgb(74, 85, 162);
        }

        private void fungsiHasil()
        {
            index = 1;
            gantiForm();

            hasilPutih();
            ulanganNormal();
            soalNormal();
            jawabanNormal();
            userNormal();
            siswaNormal();
            guruNormal();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiUlangan()
        {
            index = 2;
            gantiForm();

            hasilNormal();
            ulanganPutih();
            soalNormal();
            jawabanNormal();
            userNormal();
            siswaNormal();
            guruNormal();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiSoal()
        {
            index = 3;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalPutih();
            jawabanNormal();
            userNormal();
            siswaNormal();
            guruNormal();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiJawaban()
        {
            index = 4;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalNormal();
            jawabanPutih();
            userNormal();
            siswaNormal();
            guruNormal();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiUser()
        {
            index = 5;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalNormal();
            jawabanNormal();
            userPutih();
            siswaNormal();
            guruNormal();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiSiswa()
        {
            index = 6;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalNormal();
            jawabanNormal();
            userNormal();
            siswaPutih();
            guruNormal();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiGuru()
        {
            index = 7;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalNormal();
            jawabanNormal();
            userNormal();
            siswaNormal();
            gurulPutih();
            mapelNormal();
            kelasNormal();
        }

        private void fungsiMapel()
        {
            index = 8;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalNormal();
            jawabanNormal();
            userNormal();
            siswaNormal();
            guruNormal();
            mapelPutih();
            kelasNormal();
        }

        private void fungsiKelas()
        {
            index = 9;
            gantiForm();

            hasilNormal();
            ulanganNormal();
            soalNormal();
            jawabanNormal();
            userNormal();
            siswaNormal();
            guruNormal();
            mapelNormal();
            kelasPutih();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form login = new flogin();
                login.Show();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            fungsiHasil();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fungsiHasil();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            fungsiUlangan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fungsiUlangan();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fungsiSoal();
        }

        private void btnujian_Click(object sender, EventArgs e)
        {
            fungsiSoal();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fungsiJawaban();
        }

        private void btnsoal_Click(object sender, EventArgs e)
        {
            fungsiJawaban();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fungsiUser();
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            fungsiUser();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            fungsiSiswa();
        }

        private void btnsiswa_Click(object sender, EventArgs e)
        {
            fungsiSiswa();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            fungsiGuru();
        }

        private void btnguru_Click(object sender, EventArgs e)
        {
            fungsiGuru();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            fungsiMapel();
        }

        private void btnmapel_Click(object sender, EventArgs e)
        {
            fungsiMapel();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            fungsiKelas();
        }

        private void btnkelas_Click(object sender, EventArgs e)
        {
            fungsiKelas();
        }

        private void fadmin_Activated(object sender, EventArgs e)
        {
            if (index == -1)
            {
                index = 1;
            }
            gantiForm();
        }

        private void fadmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
