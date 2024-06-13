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
    public partial class fmapel : Form
    {
        public fmapel()
        {
            InitializeComponent();
        }

        int bariske = -1;

        private void bersih()
        {
            bariske = -1;
            cmbKDM.Text = "";
            txtnama.Text = "";
            txtkkm.Text = "";
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT kd_mapel AS 'Kode Mapel', nama AS 'Nama', kkm AS 'KKM' FROM tmapel", dgtmapel);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            if (txtcari.Text != "Cari...")
            {
                SQL.tampilgrid("SELECT kd_mapel AS 'Kode Mapel', nama AS 'Nama', KKM AS 'KKM' FROM tmapel WHERE nama LIKE '%" + txtcari.Text + "%'", dgtmapel);
                logika.cariBerubah(txtcari);
            }
        }

        private void dgtmapel_Click(object sender, EventArgs e)
        {
            if (dgtmapel.Rows.Count > 0)
            {
                bariske = dgtmapel.CurrentRow.Index;
                cmbKDM.Text = dgtmapel.Rows[bariske].Cells[0].Value.ToString();
                txtnama.Text = dgtmapel.Rows[bariske].Cells[1].Value.ToString();
                txtkkm.Text = dgtmapel.Rows[bariske].Cells[2].Value.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDM.Text.Trim() != "" && txtnama.Text.Trim() != "" && txtkkm.Text.Trim() != "")
                {
                    SQL.CRUD("INSERT INTO tmapel VALUES('" + cmbKDM.Text + "', '" + txtnama.Text + "', '" + Convert.ToInt32(txtkkm.Text) + "')");
                    tampilData();
                    bersih();
                }
                else
                {
                    MessageBox.Show("Silahkan isi form terlebih dahulu!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDM.Text != "")
                {
                    SQL.CRUD("UPDATE tmapel SET nama = '" + txtnama.Text + "', kkm = '" + Convert.ToInt32(txtkkm.Text) + "' WHERE kd_mapel = '" + cmbKDM.Text + "'");
                    tampilData();
                    bersih();
                }
                else
                {
                    MessageBox.Show("Silahkan pilih kd_mapel terlebih dahulu!", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (cmbKDM.Text.Trim() != "")
                {
                    SQL.hapusData("tmapel", "kd_mapel", cmbKDM.Text);
                    tampilData();
                    bersih();
                }
                else
                {
                    MessageBox.Show("Silahkan pilih kd_mapel terlebih dahulu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void txtcari_Leave(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void fmapel_Shown(object sender, EventArgs e)
        {
            tampilData();
            logika.judul(label10, panel1);
        }

        private void cmbKDM_Click(object sender, EventArgs e)
        {
            cmbKDM.Items.Clear();
            SQL.CRUD("SELECT kd_mapel FROM tmapel; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String kdMapel = baris["kd_mapel"].ToString();
                cmbKDM.Items.Add(kdMapel);
            }
        }

        private void cmbKDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKDM = cmbKDM.SelectedItem.ToString();
            string query = "SELECT * FROM tmapel WHERE kd_mapel = '" + selectedKDM + "'";
            SQL.CRUD(query);

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                cmbKDM.Text = row["kd_mapel"].ToString();
                txtnama.Text = row["nama"].ToString();
                txtkkm.Text = row["kkm"].ToString();
            }
        }
    }
}
