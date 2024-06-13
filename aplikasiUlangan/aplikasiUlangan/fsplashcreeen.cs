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
    public partial class fsplashcreeen : Form
    {
        public fsplashcreeen()
        {
            InitializeComponent();
        }

        private String data;
        private int length;

        int startpoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 2;
            progressBar1.Value = startpoint;

            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();

                this.Hide();
                Form flogin = new flogin();
                flogin.Show();
            }

            if (length < data.Length)
            {
                label4.Text = label4.Text + data.ElementAt(length);
                length++;
            }
            else
            {
                label4.Text = "";
                length = 0;
            }
        }

        private void fsplashcreeen_Load(object sender, EventArgs e)
        {
            data = label4.Text;
            label4.Text = "";

            timer1.Start();
        }
    }
}
