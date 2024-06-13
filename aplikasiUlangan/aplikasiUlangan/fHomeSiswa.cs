using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Data;
using System.Collections.Generic;

namespace aplikasiUlangan
{
    public partial class fHomeSiswa : Form
    {
        string namaUlangan;

        byte jumlahCheckbox = 0,
            jumlahlbl = 0,
            bariske;

        short y = 230;

        int jumlahUlangan;

        Label lblSoal = new Label();
        Label lblSisaWaktu = new Label();

        private Dictionary<string, string> jawabanPengguna = new Dictionary<string, string>();

        public fHomeSiswa()
        {
            InitializeComponent();
            jumlahUlangan = SQL.getRowCount("SELECT * FROM tulangan");
        }

        private void logout()
        {
            DialogResult result = MessageBox.Show("Apakah kamu ingin keluar?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private PictureBox cekbox()
        {
            PictureBox pictureBox = new PictureBox
            {
                Name = $"pictureBox{jumlahCheckbox}",
                Size = new Size(8, 8),
                Location = new Point(55, y + 7),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile("dot.png"),
                BackColor = Color.White
            };

            panel1.Controls.Add(pictureBox);

            jumlahCheckbox++;

            return pictureBox;
        }

        private void submitJawaban()
        {
            foreach (var kvp in jawabanPengguna)
            {
                string kdSoal = kvp.Key;
                string jawaban = kvp.Value;

                SQL.CRUD("INSERT INTO tjawaban VALUES('" + SQL.idUser + "', '" + kdSoal + "', '" + jawaban + "')");
            }

            jawabanPengguna.Clear();

            SQL.jumlahSelesai++;
        }

        private void labelHiasan()
        {
            Label label = new Label
            {
                Name = "labelHiasan",
                Location = new Point(76, y + 20)
            };

            panel1.Controls.Add(label);
        }

        private Label labelUlangan()
        {
            Label label = new Label
            {
                Text = namaUlangan,
                Name = $"lbl{jumlahlbl}",
                Location = new Point(76, y),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 12, FontStyle.Underline),
                ForeColor = Color.Blue,
                AutoSize = true
            };

            panel1.Controls.Add(label);

            label.Click += Label_Click;
            label.MouseHover += Label_Hover;
            label.MouseLeave += Label_Leave;

            jumlahlbl++;
            y += 30;

            return label;
        }

        private void fsiswaUlanganDiClose(object sender, FormClosingEventArgs e)
        {
            SQL.noSoal = 1;

            Application.Exit();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            List<string> kdSoal = new List<string>();

            Label labeldiKlik = sender as Label;
            SQL.namaTabel = labeldiKlik.Text;
            namaUlangan = labeldiKlik.Text;
            SQL.kdUlangan = labeldiKlik.Text;

            SQL.CRUD("SELECT * FROM theadsoal WHERE kd_ulangan = '" + SQL.kdUlangan + "'");

            foreach (DataRow row in SQL.ds.Tables[0].Rows)
            {
                string isiKDSoal = row["kd_soal"].ToString();
                kdSoal.Add(isiKDSoal);
            }

            int jumlahSoal = kdSoal.Count;
            int dikerjain = 0;

            for (int i = 0; i < jumlahSoal; i++)
            {
                int baris = SQL.getRowCount("SELECT * FROM `tjawaban` WHERE id = '" + SQL.idUser + "' AND kd_soal = '" + kdSoal[i] + "';");

                dikerjain += baris;
            }

            DialogResult result = MessageBox.Show($"Apakah anda ingin mengerjakan {namaUlangan}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dikerjain >= 1)
                {
                    MessageBox.Show("Ulangan sudah dikerjakan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Hide();
                    Form fMengerjakan = new fmengerjakan();
                    fMengerjakan.ShowDialog();
                    Close();
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            submitJawaban();

            Close();

            fHomeSiswa fUlanganBaru = new fHomeSiswa();
            fUlanganBaru.ShowDialog();

            SQL.jumlahSelesai += 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            logout();
        }

        private void fsiswaUlangan_Activated(object sender, EventArgs e)
        {

            lbljumlahulangan.Text = $"{SQL.jumlahSelesai} dari {jumlahUlangan}";
            lblid.Text = $"Selamat datang {SQL.idUser}";

            if (SQL.jumlahSelesai == 0 && jumlahUlangan == 0)
            {
                progressBar1.Value = 100;
            }
            else
            {
                double progressPercentage = (double)SQL.jumlahSelesai / jumlahUlangan * 100;
                progressBar1.Value = (int)progressPercentage;
            }

            SQL.CRUD("SELECT * FROM tulangan;");

            for (int i = 0; i < jumlahUlangan; i++)
            {
                if (SQL.ds.Tables.Count > 0 && SQL.ds.Tables[0].Rows.Count > bariske)
                {
                    object value = SQL.ds.Tables[0].Rows[bariske][0];
                    namaUlangan = value.ToString();
                    cekbox();
                    labelUlangan();
                }
                bariske++;
            }

            labelHiasan();
        }

        private void fHomeSiswa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Label_Hover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.ForeColor = Color.Orange;
            }
        }

        private void Label_Leave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                label.ForeColor = Color.Blue;
            }
        }
    }
}
