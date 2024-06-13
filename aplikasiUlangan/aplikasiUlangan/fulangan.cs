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
    public partial class fulangan : Form
    {
        int bariske = -1;
        DateTime tanggal;
        public fulangan()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', nama AS 'Nama Ulangan', jenis AS 'Jenis', kd_mapel AS 'Kode Mapel', waktu AS 'Waktu', tanggal AS 'Tanggal' FROM tulangan; ", dgtulangan);
            SQL.tampilgrid("SELECT kd_mapel as 'Kode Mapel', nama as 'Nama' FROM tmapel", dgtmapel);

            dgtulangan.Columns["Kode Ulangan"].DisplayIndex = 0;
            dgtulangan.Columns["Nama Ulangan"].DisplayIndex = 1;
            dgtulangan.Columns["Jenis"].DisplayIndex = 2;
            dgtulangan.Columns["Kode Mapel"].DisplayIndex = 3;
            dgtulangan.Columns["Waktu"].DisplayIndex = 4;
            dgtulangan.Columns["Tanggal"].DisplayIndex = 5;

            // dgtulangan.Columns[0].Visible = false;
        }

        private void bersih()
        {
            cmbKDU.Text = "";
            cmbjenis.Text = "";
            cmbKDM.Text = "";
            txtNamaUlangan.Text = "";
            dtptanggal.Value = DateTime.Today;
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);

            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tulangan")
                {
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', nama AS 'Nama Ulangan', jenis AS 'Jenis', kd_mapel AS 'Kode Mapel', waktu AS 'Waktu', tanggal AS 'Tanggal' FROM tulangan WHERE nama LIKE '%" + txtcari.Text + "%';", dgtulangan);
                }
                else
                {
                    SQL.tampilgrid("SELECT kd_mapel AS 'Kode Mapel', nama AS 'Nama' FROM tmapel WHERE nama LIKE '%" + txtcari.Text + "%';", dgtmapel);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDU.Text.Trim() != "" && txtNamaUlangan.Text.Trim() != "" && cmbjenis.Text.Trim() != "" && cmbKDM.Text.Trim() != "")
                {
                    SQL.CRUD("INSERT INTO tulangan VALUES('" + cmbKDU.Text + "', '" + txtNamaUlangan.Text + "','" + cmbjenis.Text + "', '" + cmbKDM.Text + "', '30', '" + dtptanggal.Value.ToString("yyyy-MM-dd") + "');");
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', jenis AS 'Jenis', kd_mapel AS 'Kode Mapel', waktu AS 'Waktu', tanggal AS 'Tanggal' FROM tulangan; ", dgtulangan);
                    bersih();
                }
                else
                {
                    MessageBox.Show("Lengkapi form!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgtmapel_Click(object sender, EventArgs e)
        {
            if (dgtmapel.Rows.Count > 0)
            {
                bariske = dgtmapel.CurrentRow.Index;

                cmbKDM.Text = dgtmapel.Rows[bariske].Cells[0].Value.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDU.Text.Trim() != "" && txtNamaUlangan.Text.Trim() != "" && cmbjenis.Text != "" && cmbKDM.Text != "")
                {
                    SQL.CRUD("UPDATE tulangan SET kd_mapel='" + cmbKDM.Text + "', nama = '"+txtNamaUlangan.Text+"', tanggal='" + dtptanggal.Value.ToString("yyyy-MM-dd") + "' WHERE kd_ulangan='" + cmbKDU.Text + "'");
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', jenis AS 'Jenis', kd_mapel AS 'Kode Mapel', waktu AS 'Waktu', tanggal AS 'Tanggal' FROM tulangan; ", dgtulangan);

                    tampilData();
                    bersih();
                }
                else
                {
                    MessageBox.Show("Lengkapi form!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label3, panel1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDU.Text != "")
                {
                    SQL.CRUD("SELECT kd_soal FROM theadsoal WHERE kd_ulangan = '" + cmbKDU.Text + "'; ");

                    if (SQL.ds.Tables.Count > 0 && SQL.ds.Tables[0].Rows.Count > 0)
                    {
                        string[] kdSoal = new string[SQL.ds.Tables[0].Rows.Count];

                        for (int i = 0; i < SQL.ds.Tables[0].Rows.Count; i++)
                        {
                            kdSoal[i] = SQL.ds.Tables[0].Rows[i]["kd_soal"].ToString();
                            Console.WriteLine(kdSoal[i]);
                        }

                        for (int i = 0; i < kdSoal.Length; i++)
                        {
                            SQL.hapusData("tjawaban", "kd_soal", kdSoal[i]);
                        }

                        for (int i = 0; i < kdSoal.Length; i++)
                        {
                            SQL.hapusData("tdetsoal", "kd_soal", kdSoal[i]);
                        }

                        for (int i = 0; i < kdSoal.Length; i++)
                        {
                            SQL.hapusData("theadsoal", "kd_soal", kdSoal[i]);
                        }

                    }

                    SQL.hapusData("thasil", "kd_ulangan", cmbKDU.Text);
                    SQL.hapusData("tulangan", "kd_ulangan", cmbKDU.Text);
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', jenis AS 'Jenis', kd_mapel AS 'Kode Mapel', waktu AS 'Waktu', tanggal AS 'Tanggal' FROM tulangan; ", dgtulangan);
                    bersih();
                }
                else
                {
                    MessageBox.Show("Pilih kd_ulangan!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void txtcari_Leave(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("tdetulangan");
            cmbtabel.Items.Add("tmapel");
        }

        private void fulangan_Shown(object sender, EventArgs e)
        {
            tampilData();
            logika.judul(label3, panel1);
            logika.cariLeave(txtcari);
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            logika.warnaiText(txtcari);
            tampilData();
        }

        private void cmbjenis_Click(object sender, EventArgs e)
        {
            cmbjenis.Items.Clear();

            cmbjenis.Items.Add("harian");
            cmbjenis.Items.Add("sumatif");
        }

        private void dgtulangan_Click(object sender, EventArgs e)
        {
            if (dgtulangan.Rows.Count > 0)
            {
                bariske = dgtulangan.CurrentRow.Index;

                cmbKDU.Text = dgtulangan.Rows[bariske].Cells[0].Value.ToString();
                txtNamaUlangan.Text = dgtulangan.Rows[bariske].Cells[1].Value.ToString();
                cmbjenis.Text = dgtulangan.Rows[bariske].Cells[2].Value.ToString();
                cmbKDM.Text = dgtulangan.Rows[bariske].Cells[3].Value.ToString();

                var cellValue = dgtulangan.Rows[bariske].Cells[5].Value;
                if (cellValue != null && DateTime.TryParse(cellValue.ToString(), out tanggal))
                {
                    dtptanggal.Value = tanggal;
                }
                else
                {
                    MessageBox.Show("Tanggal tidak valid");
                }
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void cmbKDU_Click(object sender, EventArgs e)
        {
            cmbKDU.Items.Clear();
            SQL.CRUD("SELECT kd_ulangan FROM tulangan");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String KD = baris["kd_ulangan"].ToString();
                cmbKDU.Items.Add(KD);
            }
        }

        private void cmbKDU_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKDU = cmbKDU.SelectedItem.ToString();
            SQL.CRUD("SELECT * FROM tulangan WHERE kd_ulangan = '" + selectedKDU + "'");

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                cmbKDU.Text = row["kd_ulangan"].ToString();
                cmbjenis.Text = row["jenis"].ToString();
                cmbKDM.Text = row["kd_mapel"].ToString();

                if (DateTime.TryParse(row["tanggal"].ToString(), out DateTime tanggal))
                {
                    dtptanggal.Value = tanggal;
                }
            }
        }

        private void cmbKDM_Click(object sender, EventArgs e)
        {
            cmbKDM.Items.Clear();
            SQL.CRUD("SELECT kd_mapel FROM tmapel;");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String KDM = baris["kd_mapel"].ToString();
                cmbKDM.Items.Add(KDM);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQL.CRUD("SELECT kd_soal FROM theadsoal WHERE kd_ulangan = '" + cmbKDU.Text + "'; ");

            if (SQL.ds.Tables.Count > 0 && SQL.ds.Tables[0].Rows.Count > 0)
            {
                string[] kdSoal = new string[SQL.ds.Tables[0].Rows.Count];

                for (int i = 0; i < SQL.ds.Tables[0].Rows.Count; i++)
                {
                    kdSoal[i] = SQL.ds.Tables[0].Rows[i]["kd_soal"].ToString();
                    Console.WriteLine(kdSoal[i]);
                }
            }
        }
    }
}
