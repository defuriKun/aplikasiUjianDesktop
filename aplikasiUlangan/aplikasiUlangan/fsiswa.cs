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
    public partial class fsiswa : Form
    {
        public fsiswa()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas', jk AS 'Jenis Kelamin', alamat AS 'Alamat', tlp_wali AS 'No Telepon Wali' FROM tsiswa", dgvtsiswa);
            SQL.tampilgrid("SELECT id AS 'ID Akun', pw AS 'Password' FROM tuser WHERE lvl='siswa'", dgvtuser);
            SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', wakel AS 'Wali Kelas' FROM tkelas", dgvtkelas);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        int bariske = -1;

        private void bersih()
        {
            bariske = -1;
            cmbNISN.Text = "";
            cmbID.Text = "";
            txtnama.Text = "";
            cmbKelas.Text = "";
            cmbjk.Text = "";
            txtalamat.Text = "";
            txtnotlp.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNISN.Text.Trim() != "" && cmbID.Text.Trim() != "" && txtnama.Text.Trim() != "" && cmbKelas.Text.Trim() != "" && cmbjk.Text.Trim() != "" && txtalamat.Text.Trim() != "" && txtnotlp.Text.Trim() != "")
                {
                    SQL.CRUD("INSERT INTO tsiswa VALUES('" + cmbNISN.Text + "', '" + cmbID.Text + "', '" + txtnama.Text + "', '" + cmbKelas.Text + "', '" + cmbjk.Text + "', '" + txtalamat.Text + "', '" + txtnotlp.Text + "');");
                }
                else
                {
                    MessageBox.Show("Silahkan lengkapi form terlebih dahulu!", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                bersih();
                SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas', jk AS 'Jenis Kelamin', alamat AS 'Alamat', tlp_wali AS 'No Telepon Wali' FROM tsiswa", dgvtsiswa);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbjk_Click(object sender, EventArgs e)
        {
            cmbjk.Items.Clear();
            cmbjk.Items.Add("laki-laki");
            cmbjk.Items.Add("perempuan");
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            SQL.tampilgrid("SELECT * FROM tsiswa WHERE nama LIKE '%" + txtcari.Text + "%'", dgvtsiswa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNISN.Text.Trim() != "")
                {
                    SQL.CRUD("UPDATE tsiswa SET id='" + cmbID.Text + "', nama='" + txtnama.Text + "', kelas='" + cmbKelas.Text + "', jk='" + cmbjk.Text + "', alamat='" + txtalamat.Text + "', tlp_wali='" + txtnotlp.Text + "' WHERE nisn='" + cmbNISN.Text + "'");
                    SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas', jk AS 'Jenis Kelamin', alamat AS 'Alamat', tlp_wali AS 'No Telepon Wali' FROM tsiswa", dgvtsiswa);
                    bersih();
                }
                else
                {
                    MessageBox.Show("Silahkan pilih nisn terlebih dahulu!", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception a)
            {
                    MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgtsiswa_Click(object sender, EventArgs e)
        {
            if (dgvtsiswa.Rows.Count > 0)
            {
                bariske = dgvtsiswa.CurrentRow.Index;

                cmbNISN.Text = dgvtsiswa.Rows[bariske].Cells[0].Value.ToString();
                cmbID.Text = dgvtsiswa.Rows[bariske].Cells[1].Value.ToString();
                txtnama.Text = dgvtsiswa.Rows[bariske].Cells[2].Value.ToString();
                cmbKelas.Text = dgvtsiswa.Rows[bariske].Cells[3].Value.ToString();
                cmbjk.Text = dgvtsiswa.Rows[bariske].Cells[4].Value.ToString();
                txtalamat.Text = dgvtsiswa.Rows[bariske].Cells[5].Value.ToString();
                txtnotlp.Text = dgvtsiswa.Rows[bariske].Cells[6].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbNISN.Text.Trim() != "")
                {
                    SQL.hapusData("tsiswa", "nisn", cmbNISN.Text);
                }
                else
                {
                    MessageBox.Show("Silahkan pilih nisn terlebih dahulu!", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                bersih();
                SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas', jk AS 'Jenis Kelamin', alamat AS 'Alamat', tlp_wali AS 'No Telepon Wali' FROM tsiswa", dgvtsiswa);
            }
            catch (Exception a)
            {
                    MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void txtcari_TextChanged_1(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);

            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tsiswa")
                {
                    SQL.tampilgrid("SELECT nisn AS 'NISN', id AS 'ID Akun', nama AS 'Nama', kelas AS 'Kelas', jk AS 'Jenis Kelamin', alamat AS 'Alamat', tlp_wali AS 'No Telepon Wali' FROM tsiswa WHERE nama LIKE '%" + txtcari.Text + "%';", dgvtsiswa);
                }
                else if (cmbtabel.Text == "tuser")
                {
                    SQL.tampilgrid("SELECT id AS 'ID Akun', pw AS 'Password' FROM tuser WHERE id LIKE '%" + txtcari.Text + "%' AND lvl='siswa'", dgvtuser);
                }
                else
                {
                    SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', wali AS 'Wali' FROM tkelas WHERE kd_kelas LIKE ", dgvtkelas);
                }
            }
        }

        private void txtcari_Leave(object sender, EventArgs e)
        {
            logika.cariLeave(txtcari);
        }

        private void cmbtabel_Click(object sender, EventArgs e)
        {
            cmbtabel.Items.Clear();
            cmbtabel.Items.Add("tsiswa");
            cmbtabel.Items.Add("tuser");
            cmbtabel.Items.Add("tkelas");
        }

        private void fsiswa_Activated(object sender, EventArgs e)
        {
            SQL.tampilgrid("SELECT * FROM tsiswa", dgvtsiswa);
            SQL.tampilgrid("SELECT id, pw FROM tuser WHERE lvl='siswa'", dgvtuser);
            SQL.tampilgrid("SELECT * FROM tkelas", dgvtkelas);
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            logika.warnaiText(txtcari);
        }

        private void dgvtkelas_Click(object sender, EventArgs e)
        {
            if (dgvtkelas.Rows.Count > 0)
            {
                bariske = dgvtkelas.CurrentRow.Index;
                cmbKelas.Text = dgvtkelas.Rows[bariske].Cells[0].Value.ToString();
            }
        }

        private void dgvtuser_Click(object sender, EventArgs e)
        {
            if (dgvtuser.Rows.Count > 0)
            {
                int bariske = dgvtuser.CurrentRow.Index;
                cmbID.Text = dgvtuser.Rows[bariske].Cells[0].Value.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tampilData();
        }

        private void cmbID_Click(object sender, EventArgs e)
        {
            cmbID.Items.Clear();
            SQL.CRUD("SELECT id FROM tuser WHERE lvl = 'siswa'; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String id = baris["id"].ToString();
                cmbID.Items.Add(id);
            }
        }

        private void cmbNISN_Click(object sender, EventArgs e)
        {
            cmbNISN.Items.Clear();
            SQL.CRUD("SELECT nisn FROM tsiswa; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String NISN = baris["nisn"].ToString();
                cmbNISN.Items.Add(NISN);
            }
        }

        private void cmbNISN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedNISN = cmbNISN.SelectedItem.ToString();
            string query = "SELECT * FROM tsiswa WHERE nisn = '" + selectedNISN + "'";
            SQL.CRUD(query);

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                cmbID.Text = row["id"].ToString();
                txtnama.Text = row["nama"].ToString();
                cmbKelas.Text = row["kelas"].ToString();
                cmbjk.Text = row["jk"].ToString();
                txtalamat.Text = row["alamat"].ToString();
                txtnotlp.Text = row["tlp_wali"].ToString();
            }
        }

        private void fsiswa_Shown(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
            tampilData();
        }

        private void cmbKelas_Click(object sender, EventArgs e)
        {
            cmbKelas.Items.Clear();
            SQL.CRUD("SELECT kd_kelas FROM tkelas;");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String KDK = baris["kd_kelas"].ToString();
                cmbKelas.Items.Add(KDK);
            }
        }
    }
}
