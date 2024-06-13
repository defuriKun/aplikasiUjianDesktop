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
    public partial class fhasil : Form
    {
        public fhasil()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT nisn AS 'NISN', kd_kelas AS 'Kelas', kd_ulangan AS 'Kode Ulangan', hasil AS 'Nilai' FROM thasil;", dgthasil);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
        }

        private void txtcari_TextChanged_1(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);
            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "NISN")
                {
                    logika.cariQuery(txtcari, "SELECT nisn AS 'NISN', kd_kelas AS 'Kelas', kd_ulangan AS 'Kode Ulangan', hasil AS 'Nilai' FROM thasil WHERE nisn LIKE '%" + txtcari.Text + "%'", dgthasil);
                }
                else if (cmbtabel.Text == "Kelas")
                {
                    logika.cariQuery(txtcari, "SELECT nisn AS 'NISN', kd_kelas AS 'Kelas', kd_ulangan AS 'Kode Ulangan', hasil AS 'Nilai' FROM thasil WHERE kd_kelas LIKE '%" + txtcari.Text + "%'", dgthasil);
                }
                else
                {
                    logika.cariQuery(txtcari, "SELECT nisn AS 'NISN', kd_kelas AS 'Kelas', kd_ulangan AS 'Kode Ulangan', hasil AS 'Nilai' FROM thasil WHERE kd_ulangan LIKE '%" + txtcari.Text + "%'", dgthasil);
                }
            }
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void txtcari_Leave_1(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void fhasil_Shown(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
            tampilData();
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("NISN");
            cmbtabel.Items.Add("Kelas");
            cmbtabel.Items.Add("Kode Ulangan");
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            tampilData();
            logika.warnaiText(txtcari);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            KF.FCetak.ShowDialog();
        }
    }
}
