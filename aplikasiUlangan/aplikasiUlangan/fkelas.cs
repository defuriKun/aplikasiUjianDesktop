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
    public partial class fkelas : Form
    {
        public fkelas()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', nama AS 'Nama Kelas', wakel AS 'NIP Wakel' FROM tkelas", dgtkelas);
            SQL.tampilgrid("SELECT nip as 'NIP', nama AS 'Nama' FROM tguru", dgwali);

            dgtkelas.Columns["Kode Kelas"].DisplayIndex = 0;
            dgtkelas.Columns["Nama Kelas"].DisplayIndex = 1;
            dgtkelas.Columns["NIP Wakel"].DisplayIndex = 2;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        int bariske = -1;

        private void bersih()
        {
            cmbKDK.Text = "";
            txtNamaKelas.Text = "";
            cmbNIP.Text = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void dgkelas_Click(object sender, EventArgs e)
        {
            if (dgtkelas.Rows.Count > 0)
            {
                bariske = dgtkelas.CurrentRow.Index;
                cmbKDK.Text = dgtkelas.Rows[bariske].Cells[0].Value.ToString();
                txtNamaKelas.Text = dgtkelas.Rows[bariske].Cells[1].Value.ToString();
                cmbNIP.Text = dgtkelas.Rows[bariske].Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNIP.Text.Trim() != "" && txtNamaKelas.Text.Trim() != "" && cmbKDK.Text.Trim() != "")
                {
                    SQL.CRUD("INSERT INTO tkelas VALUES('" + cmbKDK.Text + "', '"+txtNamaKelas.Text+"', '" + cmbNIP.Text + "');");
                    SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', wakel AS 'NIP Wakel' FROM tkelas", dgtkelas);
                    bersih();
                }
                else
                {
                    MessageBox.Show("Isi semua form", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (cmbNIP.Text.Trim() != "" && cmbKDK.Text.Trim() != "")
                {
                    SQL.CRUD("UPDATE tkelas SET wakel='" + cmbNIP.Text + "', nama = '"+txtNamaKelas.Text+"' WHERE kd_kelas='" + cmbKDK.Text + "';");
                    SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', wakel AS 'NIP Wakel' FROM tkelas", dgtkelas);
                    bersih();
                    tampilData();
                }
                else
                {
                    MessageBox.Show("Isi semua form", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);

            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tkelas")
                {
                    SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', nama AS 'Nama Kelas', wakel AS 'NIP Wakel' FROM tkelas WHERE nama LIKE '%"+txtcari.Text+"%'", dgtkelas);
                }
                else
                {
                    SQL.tampilgrid("SELECT nip AS 'NIP', nama AS 'Nama' FROM tguru WHERE nama LIKE '%" + txtcari.Text + "%'", dgwali);
                }
            }
        }

        private void txtcari_Leave(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            logika.warnaiText(txtcari);
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("tkelas");
            cmbtabel.Items.Add("tguru");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbKDK.Text.Trim() != "")
                {
                    SQL.hapusData("tkelas", "kd_kelas", cmbKDK.Text);
                    SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', wakel AS 'NIP Wakel' FROM tkelas", dgtkelas);

                }
                else
                {
                    MessageBox.Show("Pilih kd_kelas!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgwali_Click(object sender, EventArgs e)
        {
            if (dgwali.Rows.Count > 0)
            {
                bariske = dgwali.CurrentRow.Index;
                cmbNIP.Text = dgwali.Rows[bariske].Cells[0].Value.ToString();
            }
        }

        private void cmbKDK_Click(object sender, EventArgs e)
        {
            cmbKDK.Items.Clear();
            SQL.CRUD("SELECT kd_kelas FROM tkelas; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String kdKelas = baris["kd_kelas"].ToString();
                cmbKDK.Items.Add(kdKelas);
            }
        }

        private void cmbKDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKDK = cmbKDK.SelectedItem.ToString();
            string query = "SELECT * FROM tkelas WHERE kd_kelas = '" + selectedKDK + "'";
            SQL.CRUD(query);

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                cmbKDK.Text = row["kd_kelas"].ToString();
                cmbNIP.Text = row["wakel"].ToString();
            }
        }

        private void fkelas_Shown(object sender, EventArgs e)
        {
            tampilData();
            logika.judul(label10, panel1);
        }

        private void cmbNIP_Click(object sender, EventArgs e)
        {
            cmbNIP.Items.Clear();
            SQL.CRUD("SELECT nip FROM tguru;");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String nip = baris["nip"].ToString();
                cmbNIP.Items.Add(nip);
            }
        }
    }
}
