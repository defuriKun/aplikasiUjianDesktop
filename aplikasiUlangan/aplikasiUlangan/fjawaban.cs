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
    public partial class fjawaban : Form
    {
        public fjawaban()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT id AS 'ID Akun', kd_soal AS 'Kode Soal', jawab AS 'Jawaban' FROM tjawaban", dgvtjawaban);
            SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas' FROM tsiswa", dgvtsiswa);
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
        }

        private void txtcari_Leave(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);

            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tjawaban")
                {
                    SQL.tampilgrid("SELECT id AS 'ID Akun', kd_soal AS 'Kode Soal', jawab AS 'Jawaban' FROM tjawaban WHERE id LIKE '%" + txtcari.Text + "%'", dgvtjawaban);
                }
                else
                {
                    SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas' FROM tsiswa WHERE id LIKE '%" + txtcari.Text + "%'", dgvtsiswa);
                }
            }
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("tjawaban");
            cmbtabel.Items.Add("tsiswa");
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

        private void fjawaban_Shown(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
            tampilData();
        }

        private void txtcari_Enter_1(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);

        }

        private void txtcari_Leave_1(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }
    }
}
