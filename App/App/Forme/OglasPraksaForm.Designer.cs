namespace App.Forme
{
    partial class OglasPraksaForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMentorIme = new System.Windows.Forms.TextBox();
            this.textBoxMentorPrezime = new System.Windows.Forms.TextBox();
            this.numericDuzinaTrajanja = new System.Windows.Forms.NumericUpDown();
            this.btnSacuvajPraksu = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuzinaTrajanja)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOtkazi);
            this.groupBox1.Controls.Add(this.btnSacuvajPraksu);
            this.groupBox1.Controls.Add(this.numericDuzinaTrajanja);
            this.groupBox1.Controls.Add(this.textBoxMentorPrezime);
            this.groupBox1.Controls.Add(this.textBoxMentorIme);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o praksi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime mentora:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prezime mentora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Duzina trajanja:";
            // 
            // textBoxMentorIme
            // 
            this.textBoxMentorIme.Location = new System.Drawing.Point(129, 36);
            this.textBoxMentorIme.Name = "textBoxMentorIme";
            this.textBoxMentorIme.Size = new System.Drawing.Size(174, 20);
            this.textBoxMentorIme.TabIndex = 3;
            // 
            // textBoxMentorPrezime
            // 
            this.textBoxMentorPrezime.Location = new System.Drawing.Point(129, 82);
            this.textBoxMentorPrezime.Name = "textBoxMentorPrezime";
            this.textBoxMentorPrezime.Size = new System.Drawing.Size(174, 20);
            this.textBoxMentorPrezime.TabIndex = 4;
            // 
            // numericDuzinaTrajanja
            // 
            this.numericDuzinaTrajanja.Location = new System.Drawing.Point(129, 129);
            this.numericDuzinaTrajanja.Name = "numericDuzinaTrajanja";
            this.numericDuzinaTrajanja.Size = new System.Drawing.Size(174, 20);
            this.numericDuzinaTrajanja.TabIndex = 5;
            // 
            // btnSacuvajPraksu
            // 
            this.btnSacuvajPraksu.BackColor = System.Drawing.Color.Turquoise;
            this.btnSacuvajPraksu.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajPraksu.Location = new System.Drawing.Point(54, 184);
            this.btnSacuvajPraksu.Name = "btnSacuvajPraksu";
            this.btnSacuvajPraksu.Size = new System.Drawing.Size(98, 34);
            this.btnSacuvajPraksu.TabIndex = 6;
            this.btnSacuvajPraksu.Text = "Sacuvaj";
            this.btnSacuvajPraksu.UseVisualStyleBackColor = false;
            this.btnSacuvajPraksu.Click += new System.EventHandler(this.btnSacuvajPraksu_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.BackColor = System.Drawing.Color.Turquoise;
            this.btnOtkazi.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtkazi.Location = new System.Drawing.Point(205, 184);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(98, 34);
            this.btnOtkazi.TabIndex = 7;
            this.btnOtkazi.Text = "Otkazi";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // OglasPraksaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(393, 265);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(409, 304);
            this.MinimumSize = new System.Drawing.Size(409, 304);
            this.Name = "OglasPraksaForm";
            this.Text = "OglasPraksaForm";
            this.Load += new System.EventHandler(this.OglasPraksaForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuzinaTrajanja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericDuzinaTrajanja;
        private System.Windows.Forms.TextBox textBoxMentorPrezime;
        private System.Windows.Forms.TextBox textBoxMentorIme;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnSacuvajPraksu;
    }
}