namespace Sistem_pelaporan_keracunan_MBG
{
    partial class Form7
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
            this.BtnPilihFile = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPilihFile
            // 
            this.BtnPilihFile.Location = new System.Drawing.Point(187, 174);
            this.BtnPilihFile.Name = "BtnPilihFile";
            this.BtnPilihFile.Size = new System.Drawing.Size(75, 23);
            this.BtnPilihFile.TabIndex = 0;
            this.BtnPilihFile.Text = "Pilih File";
            this.BtnPilihFile.UseVisualStyleBackColor = true;
            this.BtnPilihFile.Click += new System.EventHandler(this.BtnPilihFile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Import DB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtnPilihFile);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPilihFile;
        private System.Windows.Forms.Button button2;
    }
}