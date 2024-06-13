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
    public partial class fguru : Form
    {
        public fguru()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT nip AS 'NIP', nama AS 'Nama', jk AS 'Jenis Kelamin', alamat AS 'Alamat', kd_mapel AS 'Kode Mapel', no_tlp AS 'No Telepon' FROM tguru", dgtguru);
            SQL.tampilgrid("SELECT kd_mapel AS 'Kode Mapel', nama AS 'Nama' FROM tmapel", dgtmapel);
        }

        public event EventHandler OkButtonClicked;

        private void cmbjk_Click(object sender, EventArgs e)
        {
            cmbjk.Items.Clear();
            cmbjk.Items.Add("laki-laki");
            cmbjk.Items.Add("perempuan");
        }

        private void fguru_Load(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
            tampilData();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNIP.Text.Trim() != "" && txtnama.Text.Trim() != "" && cmbjk.Text.Trim() != "" && cmbKDM.Text.Trim() != "" && txtalamat.Text.Trim() != "" && txtnotlp.Text.Trim() != "")
                {
                    string kd_mapel = cmbKDM.Text;
                    string nama = txtnama.Text;

                    SQL.CRUD("INSERT INTO tguru VALUES('" + cmbNIP.Text + "', '" + nama + "', '" + cmbjk.Text + "', '" + kd_mapel + "', '" + txtalamat.Text + "', '" + txtnotlp.Text + "');");
                    SQL.tampilgrid("SELECT nip AS 'NIP', nama AS 'Nama', jk AS 'Jenis Kelamin', alamat AS 'Alamat', kd_mapel AS 'Kode Mapel', no_tlp AS 'No Telepon' FROM tguru", dgtguru);

                    bersih();
                }
                else
                {
                    MessageBox.Show("Silahkan isi form terlebih dahulu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bersih()
        {
            cmbNIP.Text = "";
            txtnama.Text = "";
            cmbjk.Text = "";
            cmbKDM.Text = "";
            txtalamat.Text = "";
            txtnotlp.Text = "";
            bariske = -1;
        }

        int bariske = -1;

        private void dgtguru_Click(object sender, EventArgs e)
        {
            if (dgtguru.Rows.Count > 0)
            {
                bariske = dgtguru.CurrentRow.Index;
                cmbNIP.Text = dgtguru.Rows[bariske].Cells[0].Value.ToString();
                txtnama.Text = dgtguru.Rows[bariske].Cells[1].Value.ToString();
                cmbjk.Text = dgtguru.Rows[bariske].Cells[2].Value.ToString();
                txtalamat.Text = dgtguru.Rows[bariske].Cells[3].Value.ToString();
                cmbKDM.Text = dgtguru.Rows[bariske].Cells[4].Value.ToString();
                txtnotlp.Text = dgtguru.Rows[bariske].Cells[5].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNIP.Text.Trim() != "" && txtnama.Text.Trim() != "" && cmbjk.Text.Trim() != "" && cmbKDM.Text.Trim() != "" && txtalamat.Text.Trim() != "" && txtnotlp.Text.Trim() != "")
                {
                    SQL.CRUD("UPDATE tguru SET nama='" + txtnama.Text + "', jk='" + cmbjk.Text + "', kd_mapel='" + cmbKDM.Text + "', alamat = '" + txtalamat.Text + "', no_tlp='" + txtnotlp.Text + "' WHERE nip='" + cmbNIP.Text + "'");
                    SQL.tampilgrid("SELECT nip AS 'NIP', nama AS 'Nama', jk AS 'Jenis Kelamin', alamat AS 'Alamat', kd_mapel AS 'Kode Mapel', no_tlp AS 'No Telepon' FROM tguru", dgtguru);

                    bersih();
                }
                else
                {
                    MessageBox.Show("Lengkapi form!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNIP.Text.Trim() != "")
                {
                    SQL.hapusData("tguru", "nip", cmbNIP.Text);
                    SQL.tampilgrid("SELECT nip AS 'NIP', nama AS 'Nama', jk AS 'Jenis Kelamin', alamat AS 'Alamat', kd_mapel AS 'Kode Mapel', no_tlp AS 'No Telepon' FROM tguru", dgtguru);
                    bersih();

                    OkButtonClicked?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Pilih baris yang ingin dihapus!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
        }

        private void txtcari_TextChanged_1(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);
            tampilData();

            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tguru")
                {
                    SQL.tampilgrid("SELECT nip AS 'NIP', nama AS 'Nama', jk AS 'Jenis Kelamin', alamat AS 'Alamat', kd_mapel AS 'Kode Mapel', no_tlp AS 'No Telepon' FROM tguru WHERE nama LIKE  '%" + txtcari.Text + "%'", dgtguru);
                }
                else
                {
                    // SELECT kd_mapel AS 'Kode Mapel', nama AS 'Nama', kkm AS 'KKM' FROM tmapel
                    SQL.tampilgrid("SELECT kd_mapel AS 'Kode Mapel', nama AS 'Nama' FROM tmapel WHERE nama LIKE '%" + txtcari.Text + "%'", dgtmapel);
                }
            }
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void txtcari_Leave(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("tguru");
            cmbtabel.Items.Add("tmapel");
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            logika.warnaiText(txtcari);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void dgtmapel_Click(object sender, EventArgs e)
        {
            if (dgtmapel.Rows.Count > 0)
            {
                bariske = dgtmapel.CurrentRow.Index;
                cmbKDM.Text = dgtmapel.Rows[bariske].Cells[0].Value.ToString();
            }
        }

        private void cmbNIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedNIP = cmbNIP.SelectedItem.ToString();
            string query = "SELECT * FROM tguru WHERE nip = '" + selectedNIP + "'";
            SQL.CRUD(query);

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                cmbNIP.Text = row["nip"].ToString();
                txtnama.Text = row["nama"].ToString();
                cmbjk.Text = row["jk"].ToString();
                cmbKDM.Text = row["kd_mapel"].ToString();
                txtalamat.Text = row["alamat"].ToString();
                txtnotlp.Text = row["no_tlp"].ToString();
            }
        }

        private void cmbNIP_Click(object sender, EventArgs e)
        {
            cmbNIP.Items.Clear();
            SQL.CRUD("SELECT nip FROM tguru; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String nip = baris["nip"].ToString();
                cmbNIP.Items.Add(nip);
            }
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
    }
}