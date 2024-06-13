using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace aplikasiUlangan
{
    public partial class FCetak : Form
    {
        public FCetak()
        {
            InitializeComponent();
        }

        int baris = -1;
        String KDKelas,
            KDUlangan,
            namaUlangan;

        private void selectData()
        {
            if (cmbKDUlangan.Text.Trim() != "" && cmbKDKelas.Text.Trim() != "")
            {
                SQL.tampilgrid("SELECT thasil.nisn AS 'NISN', tsiswa.nama AS 'Nama', tkelas.nama AS 'Kelas', thasil.hasil AS 'Nilai' FROM thasil INNER JOIN tsiswa ON thasil.nisn = tsiswa.nisn INNER JOIN tkelas ON tsiswa.kelas = tkelas.kd_kelas WHERE thasil.kd_kelas = '" + cmbKDKelas.Text + "' AND thasil.kd_ulangan = '" + cmbKDUlangan.Text + "'; ", dgPrint);
            }
        }

        private void pilihCMB(ComboBox CMB, String namaKolom, String namaTabel)
        {
            CMB.Items.Clear();
            SQL.CRUD("SELECT "+namaKolom+" FROM "+namaTabel+"; ");

            foreach (DataRow baris in SQL.ds.Tables[0].Rows)
            {
                String item = baris[""+namaKolom+""].ToString();
                CMB.Items.Add(item);
            }
        }

        private void FCetak_Activated(object sender, EventArgs e)
        {
            logika.judul(label3, panel1);

            SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', nama AS 'Nama Kelas' FROM tkelas", dgvTKelas);
            SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', nama AS 'Nama Ulangan' FROM tulangan", dgvTUlangan);
        }

        private void FCetak_Resize(object sender, EventArgs e)
        {
            logika.judul(label3, panel1);
        }

        private void cmbKDKelas_Click(object sender, EventArgs e)
        {
            pilihCMB(cmbKDKelas, "kd_kelas", "tkelas");
        }

        private void cmbKDUlangan_Click(object sender, EventArgs e)
        {
            pilihCMB(cmbKDUlangan, "kd_ulangan", "tulangan");
        }

        private void cmbtabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            logika.warnaiText(txtcari);
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
            cmbtabel.Items.Add("tkelas");
            cmbtabel.Items.Add("tulangan");
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            if (txtcari.Text != "Cari...")
            {
                if (cmbtabel.Text == "tulangan")
                {
                    SQL.tampilgrid("SELECT kd_ulangan AS 'Kode Ulangan', jenis AS 'Jenis', kd_mapel AS 'Kode Mapel', waktu AS 'Waktu', tanggal AS 'Tanggal' FROM tulangan WHERE nama LIKE '%" + txtcari.Text + "%';", dgvTUlangan);
                }
                else
                {
                    SQL.tampilgrid("SELECT kd_kelas AS 'Kode Kelas', nama AS 'Nama' FROM tkelas WHERE nama LIKE '%" + txtcari.Text + "%';", dgvTKelas);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbKDKelas.Text.Trim() == "" || cmbKDUlangan.Text.Trim() == "" || dgPrint.Rows.Count == 0)
            {
                MessageBox.Show("Mohon isi form dengan benar", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SQL.CRUD("SELECT nama FROM tulangan WHERE kd_ulangan = 'MTK-001'; ");
                string namaUlangan = SQL.ds.Tables[0].Rows[0]["nama"].ToString();
                Console.WriteLine("Output console: " + namaUlangan);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*",
                    Title = "Save DataGridView as PDF"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                            PdfWriter.GetInstance(pdfDoc, stream);
                            pdfDoc.Open();

                            // Judul PDF
                            Paragraph title = new Paragraph("Nilai "+namaUlangan+"");
                            title.Alignment = Element.ALIGN_CENTER;
                            pdfDoc.Add(title);
                            pdfDoc.Add(new Chunk("\n")); // Spasi

                            PdfPTable pdfTable = new PdfPTable(dgPrint.Columns.Count);

                            // Menambahkan header dengan warna latar belakang kuning untuk kolom NISN dan Hasil
                            foreach (DataGridViewColumn column in dgPrint.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                if (column.HeaderText == "NISN" || column.HeaderText == "Nilai" || column.HeaderText == "Nama" || column.HeaderText == "Kelas")
                                {
                                    cell.BackgroundColor = BaseColor.YELLOW;
                                }
                                pdfTable.AddCell(cell);
                            }

                            // Menambahkan baris data
                            foreach (DataGridViewRow row in dgPrint.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value?.ToString());
                                }
                            }

                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("Data berhasil disimpan sebagai PDF.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan saat menyimpan data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgPrint.Rows.Count == 0)
            {
                MessageBox.Show("Data belum ada", "Galat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTKelas_Click(object sender, EventArgs e)
        {
            if (dgvTKelas.Rows.Count != 0)
            {
                baris = dgvTKelas.CurrentRow.Index;
                cmbKDKelas.Text = dgvTKelas.Rows[baris].Cells[0].Value.ToString();
            }
        }

        private void dgvTUlangan_Click(object sender, EventArgs e)
        {
            if (dgvTUlangan.Rows.Count != 0)
            {
                baris = dgvTUlangan.CurrentRow.Index;
                cmbKDUlangan.Text = dgvTUlangan.Rows[baris].Cells[0].Value.ToString();
            }
        }

        private void cmbKDKelas_TextChanged(object sender, EventArgs e)
        {
            selectData();
            KDKelas = cmbKDKelas.Text;
        }

        private void cmbKDUlangan_TextChanged(object sender, EventArgs e)
        {

            selectData();
            KDUlangan = cmbKDKelas.Text;
        }
    }
}
