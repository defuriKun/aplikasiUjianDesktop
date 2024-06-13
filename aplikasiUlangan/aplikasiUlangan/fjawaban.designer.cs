
namespace aplikasiUlangan
{
    partial class fjawaban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fjawaban));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbtabel = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtcari = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvtsiswa = new System.Windows.Forms.DataGridView();
            this.dgvtjawaban = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtsiswa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtjawaban)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(92)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.cmbtabel);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.txtcari);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 51);
            this.panel1.TabIndex = 23;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // cmbtabel
            // 
            this.cmbtabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtabel.FormattingEnabled = true;
            this.cmbtabel.Location = new System.Drawing.Point(272, 15);
            this.cmbtabel.Name = "cmbtabel";
            this.cmbtabel.Size = new System.Drawing.Size(126, 24);
            this.cmbtabel.TabIndex = 29;
            this.cmbtabel.Text = "tjawaban";
            this.cmbtabel.SelectedIndexChanged += new System.EventHandler(this.cmbtabel_SelectedIndexChanged);
            this.cmbtabel.Click += new System.EventHandler(this.cmbtabel_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(405, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 18);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // txtcari
            // 
            this.txtcari.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcari.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtcari.Location = new System.Drawing.Point(12, 15);
            this.txtcari.Multiline = true;
            this.txtcari.Name = "txtcari";
            this.txtcari.Size = new System.Drawing.Size(254, 23);
            this.txtcari.TabIndex = 25;
            this.txtcari.Text = "Cari...";
            this.txtcari.TextChanged += new System.EventHandler(this.txtcari_TextChanged);
            this.txtcari.Enter += new System.EventHandler(this.txtcari_Enter_1);
            this.txtcari.Leave += new System.EventHandler(this.txtcari_Leave_1);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(552, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "Jawaban";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvtsiswa, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvtjawaban, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(965, 586);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // dgvtsiswa
            // 
            this.dgvtsiswa.AllowUserToAddRows = false;
            this.dgvtsiswa.AllowUserToDeleteRows = false;
            this.dgvtsiswa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvtsiswa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtsiswa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvtsiswa.Location = new System.Drawing.Point(3, 407);
            this.dgvtsiswa.Name = "dgvtsiswa";
            this.dgvtsiswa.ReadOnly = true;
            this.dgvtsiswa.Size = new System.Drawing.Size(959, 176);
            this.dgvtsiswa.TabIndex = 1;
            // 
            // dgvtjawaban
            // 
            this.dgvtjawaban.AllowUserToAddRows = false;
            this.dgvtjawaban.AllowUserToDeleteRows = false;
            this.dgvtjawaban.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvtjawaban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtjawaban.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvtjawaban.Location = new System.Drawing.Point(3, 3);
            this.dgvtjawaban.Name = "dgvtjawaban";
            this.dgvtjawaban.ReadOnly = true;
            this.dgvtjawaban.Size = new System.Drawing.Size(959, 398);
            this.dgvtjawaban.TabIndex = 0;
            // 
            // fjawaban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 637);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "fjawaban";
            this.Text = "fjawaban";
            this.Shown += new System.EventHandler(this.fjawaban_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvtsiswa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtjawaban)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtcari;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvtsiswa;
        private System.Windows.Forms.ComboBox cmbtabel;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.DataGridView dgvtjawaban;
    }
}