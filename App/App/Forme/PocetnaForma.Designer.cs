namespace App
{
    partial class PocetnaForma
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOglasi = new System.Windows.Forms.Button();
            this.btnCVPrijave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(113, 284);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(423, 50);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "SELEKCIJA KANDIDATA";
            // 
            // btnOglasi
            // 
            this.btnOglasi.BackColor = System.Drawing.Color.Aquamarine;
            this.btnOglasi.Location = new System.Drawing.Point(156, 416);
            this.btnOglasi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOglasi.Name = "btnOglasi";
            this.btnOglasi.Size = new System.Drawing.Size(319, 75);
            this.btnOglasi.TabIndex = 3;
            this.btnOglasi.Text = "OGLASI";
            this.btnOglasi.UseVisualStyleBackColor = false;
            this.btnOglasi.Click += new System.EventHandler(this.btnOglasi_Click);
            // 
            // btnCVPrijave
            // 
            this.btnCVPrijave.BackColor = System.Drawing.Color.Aquamarine;
            this.btnCVPrijave.Location = new System.Drawing.Point(156, 518);
            this.btnCVPrijave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCVPrijave.Name = "btnCVPrijave";
            this.btnCVPrijave.Size = new System.Drawing.Size(319, 75);
            this.btnCVPrijave.TabIndex = 4;
            this.btnCVPrijave.Text = "CV PRIJAVE";
            this.btnCVPrijave.UseVisualStyleBackColor = false;
            this.btnCVPrijave.Click += new System.EventHandler(this.btnCVPrijave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::App.Properties.Resources.Profiling_amico__1_;
            this.pictureBox1.Location = new System.Drawing.Point(122, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PocetnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(679, 753);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCVPrijave);
            this.Controls.Add(this.btnOglasi);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(697, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(697, 800);
            this.Name = "PocetnaForma";
            this.Text = "POCETNA STRANICA";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOglasi;
        private System.Windows.Forms.Button btnCVPrijave;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

