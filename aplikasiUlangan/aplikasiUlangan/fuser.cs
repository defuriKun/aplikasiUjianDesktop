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
    public partial class fuser : Form
    {
        public fuser()
        {
            InitializeComponent();
        }

        public void tampilData()
        {
            SQL.tampilgrid("SELECT id AS 'ID', pw AS 'Password', lvl AS 'Hak Akses' FROM tuser;", dgtuser);
        }

        int bariske = -1;

        private void bersih()
        {
            cmbID.Text = "";
            txtpassword.Text = "";
            cmbLevel.Text = "";
        }

        private void fuser_Shown(object sender, EventArgs e)
        {
            logika.judul(label10, panel1);
            tampilData();
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            logika.cariBerubah(txtcari);
            if (txtcari.Text != "Cari...")
            {
                SQL.tampilgrid("SELECT id AS 'ID', pw AS 'Password', lvl AS 'Hak Akses' FROM tuser WHERE id LIKE  '%" + txtcari.Text + "%'", dgtuser);
            }
        }

        private void txtcari_Enter(object sender, EventArgs e)
        {
            logika.cariEnter(txtcari);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbID.Text.Trim() == "" && txtpassword.Text.Trim() == "" && cmbLevel.Text.Trim() == "")
                {
                    MessageBox.Show("Silahkan isi form terlebih dahulu!", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SQL.CRUD("INSERT INTO tuser VALUES('" + cmbID.Text + "', '" + txtpassword.Text + "', '" + cmbLevel.Text + "');");
                    tampilData();
                    bersih();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbID.Text.Trim() == "" && txtpassword.Text.Trim() == "" && cmbLevel.Text.Trim() == "")
                {
                    MessageBox.Show("Tidak boleh ada kolom yang kosong!", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SQL.CRUD("UPDATE tuser SET pw = '"+txtpassword.Text+"', lvl = '"+cmbLevel.Text+"' WHERE tuser.id = '" + cmbID.Text + "'; ");
                    tampilData();
                    bersih();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbID.Text.Trim() == "")
                {
                    MessageBox.Show("Silahkan pilih id terlebih dahulu!", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SQL.hapusData("tuser", "id", cmbID.Text);
                tampilData();
                bersih();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            logika.sidebar(timer1, pnlsidebar);
        }

        private void cmbLevel_Click(object sender, EventArgs e)
        {
            cmbLevel.Items.Clear();
            cmbLevel.Items.Add("admin");
            cmbLevel.Items.Add("siswa");
        }

        private void dgtuser_Click_1(object sender, EventArgs e)
        {
            if (dgtuser.Rows.Count > 0)
            {
                bariske = dgtuser.CurrentRow.Index;
                cmbID.Text = dgtuser.Rows[bariske].Cells[0].Value.ToString();
                txtpassword.Text = dgtuser.Rows[bariske].Cells[1].Value.ToString();
                cmbLevel.Text = dgtuser.Rows[bariske].Cells[2].Value.ToString();
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

        private void cmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedID = cmbID.SelectedItem.ToString();
            SQL.CRUD("SELECT * FROM tuser WHERE id = '" + selectedID + "'");

            if (SQL.ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = SQL.ds.Tables[0].Rows[0];

                txtpassword.Text = row["pw"].ToString();
                cmbLevel.Text = row["lvl"].ToString();
                }
            }

        private void cmbID_Click(object sender, EventArgs e)
        {
            cmbID.Items.Clear();
            SQL.CRUD("SELECT id FROM tuser");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String ID = baris["id"].ToString();
                cmbID.Items.Add(ID);
            }
        }
    }
}
