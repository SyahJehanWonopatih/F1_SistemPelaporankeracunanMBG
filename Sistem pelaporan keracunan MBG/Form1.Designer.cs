namespace Sistem_pelaporan_keracunan_MBG
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonSelanjutnya = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNamaLengkap = new System.Windows.Forms.TextBox();
            this.txtBoxNomorKontak = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxKotaKab = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLoginAdmin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSelanjutnya
            // 
            this.buttonSelanjutnya.BackColor = System.Drawing.Color.White;
            this.buttonSelanjutnya.Location = new System.Drawing.Point(544, 399);
            this.buttonSelanjutnya.Name = "buttonSelanjutnya";
            this.buttonSelanjutnya.Size = new System.Drawing.Size(90, 23);
            this.buttonSelanjutnya.TabIndex = 0;
            this.buttonSelanjutnya.Text = "Selanjutnya";
            this.buttonSelanjutnya.UseVisualStyleBackColor = false;
            this.buttonSelanjutnya.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(89, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nama Lengkap";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(89, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nomor Kontak";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtBoxNamaLengkap
            // 
            this.txtBoxNamaLengkap.BackColor = System.Drawing.Color.White;
            this.txtBoxNamaLengkap.ForeColor = System.Drawing.Color.Silver;
            this.txtBoxNamaLengkap.Location = new System.Drawing.Point(164, 154);
            this.txtBoxNamaLengkap.Name = "txtBoxNamaLengkap";
            this.txtBoxNamaLengkap.Size = new System.Drawing.Size(326, 20);
            this.txtBoxNamaLengkap.TabIndex = 6;
            this.txtBoxNamaLengkap.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtBoxNomorKontak
            // 
            this.txtBoxNomorKontak.BackColor = System.Drawing.Color.White;
            this.txtBoxNomorKontak.ForeColor = System.Drawing.Color.White;
            this.txtBoxNomorKontak.Location = new System.Drawing.Point(164, 218);
            this.txtBoxNomorKontak.Name = "txtBoxNomorKontak";
            this.txtBoxNomorKontak.Size = new System.Drawing.Size(326, 20);
            this.txtBoxNomorKontak.TabIndex = 7;
            this.txtBoxNomorKontak.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data Pelapor";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(89, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kota/Kab";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboBoxKotaKab
            // 
            this.comboBoxKotaKab.BackColor = System.Drawing.Color.White;
            this.comboBoxKotaKab.ForeColor = System.Drawing.Color.White;
            this.comboBoxKotaKab.FormattingEnabled = true;
            this.comboBoxKotaKab.Items.AddRange(new object[] {
            "Manado",
            "Sleman ",
            "Bantul",
            "Kotamobagu",
            "Bandung",
            "Jakarta"});
            this.comboBoxKotaKab.Location = new System.Drawing.Point(164, 276);
            this.comboBoxKotaKab.Name = "comboBoxKotaKab";
            this.comboBoxKotaKab.Size = new System.Drawing.Size(326, 21);
            this.comboBoxKotaKab.TabIndex = 13;
            this.comboBoxKotaKab.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Sistem pelaporan MBG";
            // 
            // buttonLoginAdmin
            // 
            this.buttonLoginAdmin.BackColor = System.Drawing.Color.White;
            this.buttonLoginAdmin.Location = new System.Drawing.Point(564, 12);
            this.buttonLoginAdmin.Name = "buttonLoginAdmin";
            this.buttonLoginAdmin.Size = new System.Drawing.Size(113, 32);
            this.buttonLoginAdmin.TabIndex = 16;
            this.buttonLoginAdmin.Text = "Login Admin";
            this.buttonLoginAdmin.UseVisualStyleBackColor = false;
            this.buttonLoginAdmin.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(252, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(687, 523);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLoginAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxKotaKab);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxNomorKontak);
            this.Controls.Add(this.txtBoxNamaLengkap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSelanjutnya);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSelanjutnya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNamaLengkap;
        private System.Windows.Forms.TextBox txtBoxNomorKontak;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxKotaKab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLoginAdmin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

