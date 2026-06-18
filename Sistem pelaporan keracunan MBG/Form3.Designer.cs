namespace Sistem_pelaporan_keracunan_MBG
{
    partial class Form3
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
            this.label4 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTolakLaporan = new System.Windows.Forms.Button();
            this.btnTerima = new System.Windows.Forms.Button();
            this.btnSelesai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(255, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Monitoring Admin MBG";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Location = new System.Drawing.Point(556, 41);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 28);
            this.btnLogout.TabIndex = 42;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(15, 329);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.Size = new System.Drawing.Size(660, 183);
            this.dgvLaporan.TabIndex = 43;
            this.dgvLaporan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(45, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 44;
            this.button1.Text = "Koneksi Database";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Transparent;
            this.btnHapus.Location = new System.Drawing.Point(227, 267);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(107, 23);
            this.btnHapus.TabIndex = 45;
            this.btnHapus.Text = "Hapus Laporan";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTolakLaporan
            // 
            this.btnTolakLaporan.BackColor = System.Drawing.Color.Transparent;
            this.btnTolakLaporan.Location = new System.Drawing.Point(396, 267);
            this.btnTolakLaporan.Name = "btnTolakLaporan";
            this.btnTolakLaporan.Size = new System.Drawing.Size(107, 23);
            this.btnTolakLaporan.TabIndex = 46;
            this.btnTolakLaporan.Text = "Tolak Laporan";
            this.btnTolakLaporan.UseVisualStyleBackColor = false;
            this.btnTolakLaporan.Click += new System.EventHandler(this.btnTolakLaporan_Click);
            // 
            // btnTerima
            // 
            this.btnTerima.BackColor = System.Drawing.Color.Transparent;
            this.btnTerima.Location = new System.Drawing.Point(544, 267);
            this.btnTerima.Name = "btnTerima";
            this.btnTerima.Size = new System.Drawing.Size(107, 23);
            this.btnTerima.TabIndex = 47;
            this.btnTerima.Text = "Terima Laporan";
            this.btnTerima.UseVisualStyleBackColor = false;
            this.btnTerima.Click += new System.EventHandler(this.btnTerima_Click);
            // 
            // btnSelesai
            // 
            this.btnSelesai.BackColor = System.Drawing.Color.Transparent;
            this.btnSelesai.Location = new System.Drawing.Point(544, 229);
            this.btnSelesai.Name = "btnSelesai";
            this.btnSelesai.Size = new System.Drawing.Size(107, 23);
            this.btnSelesai.TabIndex = 48;
            this.btnSelesai.Text = "Selesai";
            this.btnSelesai.UseVisualStyleBackColor = false;
            this.btnSelesai.Click += new System.EventHandler(this.btnSelesai_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(687, 524);
            this.Controls.Add(this.btnSelesai);
            this.Controls.Add(this.btnTerima);
            this.Controls.Add(this.btnTolakLaporan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTolakLaporan;
        private System.Windows.Forms.Button btnTerima;
        private System.Windows.Forms.Button btnSelesai;
    }
}