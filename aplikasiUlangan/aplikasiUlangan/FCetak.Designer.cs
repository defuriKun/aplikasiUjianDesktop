
namespace aplikasiUlangan
{
    partial class FCetak
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCetak));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbtabel = new System.Windows.Forms.ComboBox();
            this.txtcari = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbKDUlangan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbKDKelas = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTUlangan = new System.Windows.Forms.DataGridView();
            this.dgvTKelas = new System.Windows.Forms.DataGridView();
            this.dgPrint = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTUlangan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKelas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(92)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 54);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(426, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Cetak";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(874, 559);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbtabel);
            this.panel2.Controls.Add(this.txtcari);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 553);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 39;
            this.label1.Text = "Pencarian";
            // 
            // cmbtabel
            // 
            this.cmbtabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbtabel.FormattingEnabled = true;
            this.cmbtabel.Location = new System.Drawing.Point(181, 57);
            this.cmbtabel.Name = "cmbtabel";
            this.cmbtabel.Size = new System.Drawing.Size(84, 24);
            this.cmbtabel.TabIndex = 38;
            this.cmbtabel.Text = "tkelas";
            this.cmbtabel.SelectedIndexChanged += new System.EventHandler(this.cmbtabel_SelectedIndexChanged);
            this.cmbtabel.Click += new System.EventHandler(this.cmbtabel_Click);
            // 
            // txtcari
            // 
            this.txtcari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcari.Location = new System.Drawing.Point(20, 57);
            this.txtcari.Multiline = true;
            this.txtcari.Name = "txtcari";
            this.txtcari.Size = new System.Drawing.Size(155, 23);
            this.txtcari.TabIndex = 37;
            this.txtcari.Text = "Cari...";
            this.toolTip1.SetToolTip(this.txtcari, "Cari berdasarkan nama");
            this.txtcari.TextChanged += new System.EventHandler(this.txtcari_TextChanged);
            this.txtcari.Enter += new System.EventHandler(this.txtcari_Enter);
            this.txtcari.Leave += new System.EventHandler(this.txtcari_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbKDUlangan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.cmbKDKelas);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(9, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 292);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pilih data";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(65)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(164, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 41);
            this.button1.TabIndex = 37;
            this.button1.Text = "Cetak";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbKDUlangan
            // 
            this.cmbKDUlangan.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cmbKDUlangan.FormattingEnabled = true;
            this.cmbKDUlangan.Location = new System.Drawing.Point(10, 137);
            this.cmbKDUlangan.Name = "cmbKDUlangan";
            this.cmbKDUlangan.Size = new System.Drawing.Size(237, 28);
            this.cmbKDUlangan.TabIndex = 36;
            this.cmbKDUlangan.TextChanged += new System.EventHandler(this.cmbKDUlangan_TextChanged);
            this.cmbKDUlangan.Click += new System.EventHandler(this.cmbKDUlangan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Kode Ulangan:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(6, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 21);
            this.label13.TabIndex = 33;
            this.label13.Text = "Kode Kelas:";
            // 
            // cmbKDKelas
            // 
            this.cmbKDKelas.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.cmbKDKelas.FormattingEnabled = true;
            this.cmbKDKelas.Location = new System.Drawing.Point(11, 67);
            this.cmbKDKelas.Name = "cmbKDKelas";
            this.cmbKDKelas.Size = new System.Drawing.Size(236, 28);
            this.cmbKDKelas.TabIndex = 34;
            this.cmbKDKelas.TextChanged += new System.EventHandler(this.cmbKDKelas_TextChanged);
            this.cmbKDKelas.Click += new System.EventHandler(this.cmbKDKelas_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgPrint, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(287, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.82459F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.17541F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(584, 553);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dgvTUlangan, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvTKelas, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(578, 263);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // dgvTUlangan
            // 
            this.dgvTUlangan.AllowUserToAddRows = false;
            this.dgvTUlangan.AllowUserToDeleteRows = false;
            this.dgvTUlangan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTUlangan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTUlangan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTUlangan.Location = new System.Drawing.Point(292, 3);
            this.dgvTUlangan.Name = "dgvTUlangan";
            this.dgvTUlangan.ReadOnly = true;
            this.dgvTUlangan.Size = new System.Drawing.Size(283, 257);
            this.dgvTUlangan.TabIndex = 1;
            this.dgvTUlangan.Click += new System.EventHandler(this.dgvTUlangan_Click);
            // 
            // dgvTKelas
            // 
            this.dgvTKelas.AllowUserToAddRows = false;
            this.dgvTKelas.AllowUserToDeleteRows = false;
            this.dgvTKelas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTKelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKelas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTKelas.Location = new System.Drawing.Point(3, 3);
            this.dgvTKelas.Name = "dgvTKelas";
            this.dgvTKelas.ReadOnly = true;
            this.dgvTKelas.Size = new System.Drawing.Size(283, 257);
            this.dgvTKelas.TabIndex = 0;
            this.dgvTKelas.Click += new System.EventHandler(this.dgvTKelas_Click);
            // 
            // dgPrint
            // 
            this.dgPrint.AllowUserToAddRows = false;
            this.dgPrint.AllowUserToDeleteRows = false;
            this.dgPrint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPrint.Location = new System.Drawing.Point(3, 272);
            this.dgPrint.Name = "dgPrint";
            this.dgPrint.ReadOnly = true;
            this.dgPrint.Size = new System.Drawing.Size(578, 278);
            this.dgPrint.TabIndex = 9;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Cari";
            // 
            // FCetak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 613);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FCetak";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cetak Laporan";
            this.Activated += new System.EventHandler(this.FCetak_Activated);
            this.Resize += new System.EventHandler(this.FCetak_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTUlangan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKelas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbtabel;
        private System.Windows.Forms.TextBox txtcari;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvTUlangan;
        private System.Windows.Forms.DataGridView dgvTKelas;
        private System.Windows.Forms.DataGridView dgPrint;
        private System.Windows.Forms.ComboBox cmbKDKelas;
        private System.Windows.Forms.ComboBox cmbKDUlangan;
    }
}