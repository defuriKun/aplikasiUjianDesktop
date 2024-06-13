using System;
using System.Drawing;
using System.Windows.Forms;

namespace aplikasiUlangan
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
            txtid.KeyDown += OnTextBoxKeyDown;
            txtpw.KeyDown += OnTextBoxKeyDown;
            txtid.Enter += OnTextBoxEnter;
            txtid.Leave += OnTextBoxLeave;
            txtpw.Enter += OnTextBoxEnter;
            txtpw.Leave += OnTextBoxLeave;
            cbxpw.CheckedChanged += OnPasswordVisibilityChanged;
            button2.Click += (sender, e) => { txtid.Text = "Masukan username"; txtpw.Text = "Masukan password"; txtid.ForeColor = txtpw.ForeColor = Color.FromArgb(105, 105, 105); };
            pictureBox1.Click += (sender, e) => Application.Exit();
        }

        private void buatUjungMelengkung()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            int radius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            this.Region = new Region(path);
        }

        private void OnTextBoxEnter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Masukan username" || textBox.Text == "Masukan password")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void OnTextBoxLeave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = textBox == txtid ? "Masukan username" : "Masukan password";
                textBox.ForeColor = Color.FromArgb(105, 105, 105);
            }
        }

        private void OnPasswordVisibilityChanged(object sender, EventArgs e)
        {
            txtpw.UseSystemPasswordChar = !cbxpw.Checked && txtpw.Text != "Masukan password";
        }

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (txtid.Focused && e.KeyCode == Keys.Enter)
                txtpw.Focus();
            else if (txtpw.Focused && e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text) || string.IsNullOrWhiteSpace(txtpw.Text))
            {
                MessageBox.Show("Username atau password tidak boleh kosong!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string id = txtid.Text;
                string password = txtpw.Text;

                int adminCount = SQL.getRowCount($"SELECT * FROM tuser WHERE id = '{id}' AND pw = '{password}' AND lvl = 'admin';");

                if (adminCount == 1)
                {
                    SQL.idUser = id;
                    Hide(); 
                    fadmin adminForm = new fadmin();
                    adminForm.FormClosed += (s, ev) => this.Close();
                    adminForm.Show();
                    return;
                }

                int studentCount = SQL.getRowCount($"SELECT * FROM tuser WHERE id = '{id}' AND pw = '{password}' AND lvl = 'siswa';");

                if (studentCount == 1)
                {
                    SQL.idUser = id;
                    Hide();  
                    fHomeSiswa studentForm = new fHomeSiswa();
                    studentForm.FormClosed += (s, ev) => this.Close();
                    studentForm.Show();
                    return;
                }

                MessageBox.Show("Username atau password salah!", "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Galat!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbxpw.Checked = true;
        }

        private void flogin_Activated(object sender, EventArgs e)
        {
            buatUjungMelengkung();
        }
    }
}
