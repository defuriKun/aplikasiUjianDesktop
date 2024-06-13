
namespace aplikasiUlangan
{
    partial class fmengerjakan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmengerjakan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblKelas = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelWaktu = new System.Windows.Forms.Label();
            this.pnlKonten = new System.Windows.Forms.Panel();
            this.dgnisn = new System.Windows.Forms.DataGridView();
            this.dgjawaban = new System.Windows.Forms.DataGridView();
            this.dgkunci = new System.Windows.Forms.DataGridView();
            this.lblNamaUlangan = new System.Windows.Forms.Label();
            this.tmrUlangan = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlKonten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgnisn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgjawaban)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgkunci)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.lblKelas);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelWaktu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 56);
            this.panel1.TabIndex = 0;
            // 
            // lblKelas
            // 
            this.lblKelas.AutoSize = true;
            this.lblKelas.Location = new System.Drawing.Point(149, 20);
            this.lblKelas.Name = "lblKelas";
            this.lblKelas.Size = new System.Drawing.Size(100, 13);
            this.lblKelas.TabIndex = 3;
            this.lblKelas.Text = "ini label untuk kelas";
            this.lblKelas.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(925, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelWaktu
            // 
            this.labelWaktu.AutoSize = true;
            this.labelWaktu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWaktu.ForeColor = System.Drawing.Color.White;
            this.labelWaktu.Location = new System.Drawing.Point(456, 16);
            this.labelWaktu.Name = "labelWaktu";
            this.labelWaktu.Size = new System.Drawing.Size(61, 25);
            this.labelWaktu.TabIndex = 1;
            this.labelWaktu.Text = "00:00";
            // 
            // pnlKonten
            // 
            this.pnlKonten.AutoScroll = true;
            this.pnlKonten.BackColor = System.Drawing.Color.White;
            this.pnlKonten.Controls.Add(this.dgnisn);
            this.pnlKonten.Controls.Add(this.dgjawaban);
            this.pnlKonten.Controls.Add(this.dgkunci);
            this.pnlKonten.Controls.Add(this.lblNamaUlangan);
            this.pnlKonten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKonten.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlKonten.Location = new System.Drawing.Point(0, 56);
            this.pnlKonten.Name = "pnlKonten";
            this.pnlKonten.Size = new System.Drawing.Size(969, 585);
            this.pnlKonten.TabIndex = 1;
            // 
            // dgnisn
            // 
            this.dgnisn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgnisn.Location = new System.Drawing.Point(168, -110);
            this.dgnisn.Name = "dgnisn";
            this.dgnisn.Size = new System.Drawing.Size(240, 150);
            this.dgnisn.TabIndex = 3;
            this.dgnisn.Visible = false;
            // 
            // dgjawaban
            // 
            this.dgjawaban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgjawaban.Location = new System.Drawing.Point(558, -95);
            this.dgjawaban.Name = "dgjawaban";
            this.dgjawaban.Size = new System.Drawing.Size(240, 150);
            this.dgjawaban.TabIndex = 2;
            this.dgjawaban.Visible = false;
            // 
            // dgkunci
            // 
            this.dgkunci.AllowUserToAddRows = false;
            this.dgkunci.AllowUserToDeleteRows = false;
            this.dgkunci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgkunci.Location = new System.Drawing.Point(788, -95);
            this.dgkunci.Name = "dgkunci";
            this.dgkunci.ReadOnly = true;
            this.dgkunci.Size = new System.Drawing.Size(240, 150);
            this.dgkunci.TabIndex = 1;
            this.dgkunci.Visible = false;
            // 
            // lblNamaUlangan
            // 
            this.lblNamaUlangan.AutoSize = true;
            this.lblNamaUlangan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaUlangan.Location = new System.Drawing.Point(414, 30);
            this.lblNamaUlangan.Name = "lblNamaUlangan";
            this.lblNamaUlangan.Size = new System.Drawing.Size(138, 25);
            this.lblNamaUlangan.TabIndex = 0;
            this.lblNamaUlangan.Text = "Nama Ulangan";
            this.lblNamaUlangan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrUlangan
            // 
            this.tmrUlangan.Interval = 1000;
            this.tmrUlangan.Tick += new System.EventHandler(this.tmrUlangan_Tick);
            // 
            // fmengerjakan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 641);
            this.Controls.Add(this.pnlKonten);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmengerjakan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmengerjakan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmengerjakan_FormClosed);
            this.Shown += new System.EventHandler(this.fmengerjakan_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlKonten.ResumeLayout(false);
            this.pnlKonten.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgnisn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgjawaban)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgkunci)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelWaktu;
        private System.Windows.Forms.Panel pnlKonten;
        private System.Windows.Forms.Label lblNamaUlangan;
        private System.Windows.Forms.Timer tmrUlangan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgkunci;
        private System.Windows.Forms.DataGridView dgjawaban;
        private System.Windows.Forms.DataGridView dgnisn;
        private System.Windows.Forms.Label lblKelas;
    }
}