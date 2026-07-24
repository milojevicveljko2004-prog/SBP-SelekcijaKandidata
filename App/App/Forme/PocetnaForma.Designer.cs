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
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(73, 148);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(329, 40);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "SELEKCIJA KANDIDATA";
            // 
            // btnOglasi
            // 
            this.btnOglasi.BackColor = System.Drawing.Color.Aquamarine;
            this.btnOglasi.Location = new System.Drawing.Point(115, 251);
            this.btnOglasi.Name = "btnOglasi";
            this.btnOglasi.Size = new System.Drawing.Size(239, 61);
            this.btnOglasi.TabIndex = 3;
            this.btnOglasi.Text = "OGLASI";
            this.btnOglasi.UseVisualStyleBackColor = false;
            this.btnOglasi.Click += new System.EventHandler(this.btnOglasi_Click);
            // 
            // btnCVPrijave
            // 
            this.btnCVPrijave.BackColor = System.Drawing.Color.Aquamarine;
            this.btnCVPrijave.Location = new System.Drawing.Point(115, 334);
            this.btnCVPrijave.Name = "btnCVPrijave";
            this.btnCVPrijave.Size = new System.Drawing.Size(239, 61);
            this.btnCVPrijave.TabIndex = 4;
            this.btnCVPrijave.Text = "CV PRIJAVE";
            this.btnCVPrijave.UseVisualStyleBackColor = false;
            this.btnCVPrijave.Click += new System.EventHandler(this.btnCVPrijave_Click);
            // 
            // PocetnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(511, 620);
            this.Controls.Add(this.btnCVPrijave);
            this.Controls.Add(this.btnOglasi);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(527, 659);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(527, 659);
            this.Name = "PocetnaForma";
            this.Text = "POCETNA STRANICA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOglasi;
        private System.Windows.Forms.Button btnCVPrijave;
    }
}

