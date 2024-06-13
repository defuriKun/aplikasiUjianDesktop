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
    public partial class fsoal : Form
    {
        public fsoal()
        {
            InitializeComponent();
        }

        int bariske = -1;

        public void tampilData()
        {
            SQL.tampilgrid("SELECT kd_soal AS 'Kode Soal', soal AS 'Soal', opsi_a AS 'Pilihan A', opsi_b AS 'Pilihan B', opsi_c AS 'Pilihan C', opsi_d AS 'Pilihan D', kunci AS 'Kunci Jawaban' FROM tdetsoal", dgtdetsoal);
            SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', kd_soal AS 'Kode Soal' FROM theadsoal", dgtheadsoal);
            SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan' FROM tulangan", dgtulangan);
        }

         private void bersih()
        {
            cmbKDSoal.Text = "";
            cmbKDU.Text = "";
            txtsoal.Text = "";
            txtopsia.Text = "";
            txtopsib.Text = "";
            txtopsic.Text = "";
            txtopsid.Text = "";
            txtkunci.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtsoal.Text.Trim() != "" && txtopsia.Text.Trim() != "" && txtopsib.Text.Trim() != "" && txtopsic.Text.Trim() != "" && txtopsid.Text.Trim() != "" && txtkunci.Text.Trim() != "")
                {
                    SQL.CRUD("INSERT INTO theadsoal (kd_ulangan, kd_soal) VALUES ('" + cmbKDU.Text + "', '"+ cmbKDSoal.Text+"' );");
                    SQL.CRUD("INSERT INTO tdetsoal VALUES('"+ cmbKDSoal.Text+"', '" + txtsoal.Text + "','" + txtopsia.Text + "', '" + txtopsib.Text + "', '" + txtopsic.Text + "', '" + txtopsid.Text + "', '" + txtkunci.Text + "');");
                    SQL.tampilgrid("SELECT kd_soal AS 'Kode Soal', soal AS 'Soal', opsi_a AS 'Pilihan A', opsi_b AS 'Pilihan B', opsi_c AS 'Pilihan C', opsi_d AS 'Pilihan D', kunci AS 'Kunci Jawaban' FROM tdetsoal", dgtdetsoal);
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', kd_soal AS 'Kode Soal' FROM theadsoal", dgtheadsoal);
                    bersih();
                }
                else
                {
                    MessageBox.Show("Pastikan form sudah diisi dengan benar!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("tdetsoal");
            cmbtabel.Items.Add("tulangan");
            cmbtabel.Items.Add("theadsoal");
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            logika.warnaiText(txtcari);
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

        private void txtcari_TextChanged_1(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);

            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tdetsoal")
                {
                    logika.cariQuery(txtcari, "SELECT kd_soal AS 'Kode Soal', soal AS 'Soal', opsi_a AS 'Pilihan A', opsi_b AS 'Pilihan B', opsi_c AS 'Pilihan C', opsi_d AS 'Pilihan D', kunci AS 'Kunci Jawaban' FROM " + cmbtabel.Text + " WHERE kd_soal LIKE '%" + txtcari.Text + "%'", dgtdetsoal);
                }
                else if (cmbtabel.Text == "tulangan")
                {
                    logika.cariQuery(txtcari, "SELECT kd_ulangan AS 'Kode Ulangan' FROM " + cmbtabel.Text + " WHERE kd_ulangan LIKE '%" + txtcari.Text + "%'", dgtulangan);
                }
                else
                {
                    logika.cariQuery(txtcari, "SELECT kd_ulangan AS 'Kode Ulangan', kd_soal AS 'Kode Soal' FROM " + cmbtabel.Text + " WHERE kd_soal LIKE '%" + txtcari.Text + "%'", dgtheadsoal);
                }
            }
        }

        private void dgtulangan_Click_1(object sender, EventArgs e)
        {
            if (dgtulangan.Rows.Count > 0)
            {
                bariske = dgtulangan.CurrentRow.Index;

                cmbKDU.Text = dgtulangan.Rows[bariske].Cells[0].Value.ToString();
            }
        }

        private void dgtheadsoal_Click_1(object sender, EventArgs e)
        {
            if (dgtheadsoal.Rows.Count > 0)
            {
                bariske = dgtheadsoal.CurrentRow.Index;

                cmbKDU.Text = dgtheadsoal.Rows[bariske].Cells[0].Value.ToString();
                cmbKDSoal.Text = dgtheadsoal.Rows[bariske].Cells[1].Value.ToString();
            }
        }

        private void dgtdetsoal_Click(object sender, EventArgs e)
        {
            if (dgtdetsoal.Rows.Count > 0)
            {
                bariske = dgtdetsoal.CurrentRow.Index;

                cmbKDSoal.Text = dgtdetsoal.Rows[bariske].Cells[0].Value.ToString();
                txtsoal.Text = dgtdetsoal.Rows[bariske].Cells[1].Value.ToString();
                txtopsia.Text = dgtdetsoal.Rows[bariske].Cells[2].Value.ToString();
                txtopsib.Text = dgtdetsoal.Rows[bariske].Cells[3].Value.ToString();
                txtopsic.Text = dgtdetsoal.Rows[bariske].Cells[4].Value.ToString();
                txtopsid.Text = dgtdetsoal.Rows[bariske].Cells[5].Value.ToString();
                txtkunci.Text = dgtdetsoal.Rows[bariske].Cells[6].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDSoal.Text.Trim() != "")
                {
                    SQL.CRUD("UPDATE tdetsoal SET soal='" + txtsoal.Text + "',opsi_a='" + txtopsia.Text + "',opsi_b='" + txtopsib.Text + "',opsi_c='" + txtopsic.Text + "',opsi_d='" + txtopsid.Text + "', kunci='" + txtkunci.Text + "' WHERE kd_soal='" + cmbKDSoal.Text + "'");
                    SQL.tampilgrid("SELECT kd_soal AS 'Kode Soal', soal AS 'Soal', opsi_a AS 'Pilihan A', opsi_b AS 'Pilihan B', opsi_c AS 'Pilihan C', opsi_d AS 'Pilihan D', kunci AS 'Kunci Jawaban' FROM tdetsoal", dgtdetsoal);
                    bersih();
                }
                else
                {
                    MessageBox.Show("Pilih kd_soal!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDSoal.Text.Trim() != "")
                {
                    SQL.hapusData("tdetsoal", "kd_soal", cmbKDSoal.Text);
                    SQL.hapusData("theadsoal", "kd_soal", cmbKDSoal.Text);
                    SQL.tampilgrid("SELECT kd_soal AS 'Kode Soal', soal AS 'Soal', opsi_a AS 'Pilihan A', opsi_b AS 'Pilihan B', opsi_c AS 'Pilihan C', opsi_d AS 'Pilihan D', kunci AS 'Kunci Jawaban' FROM tdetsoal", dgtdetsoal);
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', kd_soal AS 'Kode Soal' FROM theadsoal", dgtheadsoal);
                    txtcari.Text = "Cari...";
                    bersih();
                }
                else
                {
                    MessageBox.Show("Pilih kd_soal!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void fsoal_Shown(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
            tampilData();
        }

        private void cmbKDSoal_Click(object sender, EventArgs e)
        {
            cmbKDSoal.Items.Clear();
            SQL.CRUD("SELECT kd_soal FROM theadsoal; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String kdSoal = baris["kd_soal"].ToString();
                cmbKDSoal.Items.Add(kdSoal);
            }
        }

        private void cmbKDU_Click(object sender, EventArgs e)
        {
            cmbKDU.Items.Clear();
            SQL.CRUD("SELECT kd_ulangan AS 'Kode Ulangan' FROM tulangan;");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String KDU = baris["Kode Ulangan"].ToString();
                cmbKDU.Items.Add(KDU);
            }
        }

        private void cmbKDSoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKDS = cmbKDSoal.SelectedItem.ToString();
            SQL.CRUD("SELECT * FROM tdetsoal WHERE kd_soal = '" + selectedKDS + "'");

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                cmbKDSoal.Text = row["kd_soal"].ToString();
                txtsoal.Text = row["soal"].ToString();
                txtopsia.Text = row["opsi_a"].ToString();
                txtopsib.Text = row["opsi_b"].ToString();
                txtopsic.Text = row["opsi_c"].ToString();
                txtopsid.Text = row["opsi_d"].ToString();
                txtkunci.Text = row["kunci"].ToString();
            }
        }
    }
}
