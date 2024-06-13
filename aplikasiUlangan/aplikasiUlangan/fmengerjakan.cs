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
    public partial class fmengerjakan : Form
    {
        byte totalDetik = 0,
            pengulangan = 0;

        int jumlahSoal = SQL.getRowCount("SELECT * FROM theadsoal WHERE kd_ulangan = '" + SQL.kdUlangan + "'");

        List<string> kdSoalList = new List<string>();

        private void logout()
        {
            Hide();
            Form fHomeSiswa = new fHomeSiswa();
            fHomeSiswa.ShowDialog();
            Close();
        }

        List<string> jawaban = new List<string>();

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah kamu ingin mengirim jawaban ini?", "Kirim Jawaban", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                foreach (GroupBox groupBox in pnlKonten.Controls.OfType<GroupBox>())
                {
                    bool adaPilihan = false;

                    foreach (RadioButton rb in groupBox.Controls.OfType<RadioButton>())
                    {
                        if (rb.Checked)
                        {
                            string dijawab = rb.Text;
                            jawaban.Add(dijawab);
                            adaPilihan = true;
                            break;
                        }
                    }
                    if (!adaPilihan)
                    {
                        jawaban.Add("KOSONG");
                    }
                }

                for (int i = 0; i < jumlahSoal; i++)
                {
                    SQL.CRUD($"INSERT INTO tjawaban (id, kd_soal, jawab) VALUES ('{SQL.idUser}', '{kdSoalList[i]}', '{jawaban[i]}')");
                }
                pengulangan++;

                MessageBox.Show("Jawaban telah berhasil dikirim.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DARI SINI

                int jumlahBenar = 0;

                SQL.tampilgrid("SELECT nisn FROM tsiswa WHERE id = '" + SQL.idUser + "';", dgnisn);

                for (int i = 0; i < jumlahSoal; i++)
                {
                    SQL.tampilgrid("SELECT jawab FROM tjawaban WHERE id= '" + SQL.idUser + "' AND kd_soal = '" + kdSoalList[i] + "';", dgjawaban);
                    SQL.tampilgrid("SELECT kunci FROM tdetsoal WHERE kd_soal = '" + kdSoalList[i] + "';", dgkunci);

                    if (dgjawaban.Rows[0].Cells[0].Value.ToString() == dgkunci.Rows[0].Cells[0].Value.ToString())
                    {
                        jumlahBenar++;
                    }
                }

                string nisn = dgnisn.Rows[0].Cells[0].Value.ToString();
                double hasil = (double)jumlahBenar / jumlahSoal * 100;

                SQL.CRUD("INSERT INTO thasil (nisn, kd_kelas, kd_ulangan, hasil) VALUES('" + nisn + "', '" + lblKelas.Text + "', '" + SQL.kdUlangan + "', " + hasil + ");");

                SQL.jumlahSelesai++;

                logout();
            }
        }

        public fmengerjakan()
        {
            InitializeComponent();
        }

        private void tmrUlangan_Tick(object sender, EventArgs e)
        {
            totalDetik++;

            int menit = totalDetik / 60;
            int detik = totalDetik % 60;

            labelWaktu.Text = $"{menit:D2}:{detik:D2}";

            if (labelWaktu.Text == "30:00")
            {
                foreach (GroupBox groupBox in pnlKonten.Controls.OfType<GroupBox>())
                {
                    bool adaPilihan = false;

                    foreach (RadioButton rb in groupBox.Controls.OfType<RadioButton>())
                    {
                        if (rb.Checked)
                        {
                            string dijawab = rb.Text;
                            jawaban.Add(dijawab);
                            adaPilihan = true;
                            break;
                        }
                    }
                    if (!adaPilihan)
                    {
                        jawaban.Add("KOSONG");
                    }
                }

                for (int i = 0; i < jumlahSoal; i++)
                {
                    SQL.CRUD($"INSERT INTO tjawaban (id, kd_soal, jawab) VALUES ('{SQL.idUser}', '{kdSoalList[i]}', '{jawaban[i]}')");
                }
                pengulangan++;

                MessageBox.Show("Jawaban telah berhasil dikirim.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SQL.tampilgrid("SELECT kd_soal, jawab FROM tjawaban WHERE id= '" + SQL.idUser + "';", dgjawaban);
                SQL.tampilgrid("SELECT kd_soal, kunci FROM tdetsoal;", dgkunci);
                SQL.tampilgrid("SELECT nisn FROM tsiswa WHERE id = '" + SQL.idUser + "';", dgnisn);

                int jumlahBenar = 0;

                for (int i = 0; i < jumlahSoal; i++)
                {
                    if (dgjawaban.Rows[i].Cells[1].Value.ToString() == dgkunci.Rows[i].Cells[1].Value.ToString())
                    {
                        jumlahBenar++;
                    }
                }

                string nisn = dgnisn.Rows[0].Cells[0].Value.ToString();
                double hasil = (double)jumlahBenar / jumlahSoal * 100;

                SQL.CRUD("INSERT INTO thasil (nisn, kd_kelas, kd_ulangan, hasil) VALUES('" + nisn + "', '" + lblKelas.Text + "', '" + SQL.kdUlangan + "', " + hasil + ");");

                SQL.jumlahSelesai++;
                logout();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah kamu ingin logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                logout();
            }
        }

        private void fmengerjakan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void fmengerjakan_Shown(object sender, EventArgs e)
        {
            SQL.CRUD("SELECT * FROM theadsoal WHERE kd_ulangan = '" + SQL.kdUlangan + "'");

            foreach (DataRow row in SQL.ds.Tables[0].Rows)
            {
                string kdSoal = row["kd_soal"].ToString();
                kdSoalList.Add(kdSoal);
            }

            lblNamaUlangan.Text = SQL.kdUlangan;

            SQL.CRUD("SELECT kelas FROM tsiswa WHERE id = '" + SQL.idUser + "'");
            lblKelas.Text = SQL.ds.Tables[0].Rows[0]["kelas"].ToString();
            tmrUlangan.Start();

            SQL.CRUD($"SELECT * FROM tdetsoal INNER JOIN theadsoal ON tdetsoal.kd_soal = theadsoal.kd_soal WHERE kd_ulangan = '{SQL.kdUlangan}'");

            int noSoal = 1,
                kordinatY = 70;

            foreach (DataRow row in SQL.ds.Tables[0].Rows)
            {
                string soal = row["soal"].ToString();
                string opsiA = row["opsi_a"].ToString();
                string opsiB = row["opsi_b"].ToString();
                string opsiC = row["opsi_c"].ToString();
                string opsiD = row["opsi_d"].ToString();

                GroupBox groupBoxSoal = new GroupBox();
                groupBoxSoal.Location = new Point(80, kordinatY);
                pnlKonten.Controls.Add(groupBoxSoal);

                using (Graphics g = groupBoxSoal.CreateGraphics())
                {
                    SizeF size = g.MeasureString(soal, groupBoxSoal.Font, 700);
                    groupBoxSoal.Size = new Size(800, (int)size.Height + 140);
                }
                groupBoxSoal.Text = $"{noSoal}.    {soal}";

                RadioButton rbOpsiA = new RadioButton();
                rbOpsiA.Text = $"{opsiA}";
                rbOpsiA.AutoSize = true;
                rbOpsiA.Location = new Point(40, 40);
                groupBoxSoal.Controls.Add(rbOpsiA);

                RadioButton rbOpsiB = new RadioButton();
                rbOpsiB.Text = $"{opsiB}";
                rbOpsiB.AutoSize = true;
                rbOpsiB.Location = new Point(40, 70);
                groupBoxSoal.Controls.Add(rbOpsiB);

                RadioButton rbOpsiC = new RadioButton();
                rbOpsiC.Text = $"{opsiC}";
                rbOpsiC.AutoSize = true;
                rbOpsiC.Location = new Point(40, 100);
                groupBoxSoal.Controls.Add(rbOpsiC);

                RadioButton rbOpsiD = new RadioButton();
                rbOpsiD.Text = $"{opsiD}";
                rbOpsiD.AutoSize = true;
                rbOpsiD.Location = new Point(40, 130);
                groupBoxSoal.Controls.Add(rbOpsiD);

                kordinatY += groupBoxSoal.Height + 20;

                noSoal++;
            }

            Button btnSubmit = new Button();
            btnSubmit.Text = "SUBMIT";
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.BackColor = Color.FromArgb(255, 3, 136, 87);
            btnSubmit.Location = new Point(80, kordinatY + 30);
            btnSubmit.TextAlign = ContentAlignment.MiddleCenter;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Size = new Size(100, 40);
            btnSubmit.Click += btnSubmit_Click;
            pnlKonten.Controls.Add(btnSubmit);
            btnSubmit.BringToFront();
            kordinatY += 90;

            Label lblJarak = new Label();
            lblJarak.Location = new Point(80, kordinatY);
            pnlKonten.Controls.Add(lblJarak);
        }
    }
}
