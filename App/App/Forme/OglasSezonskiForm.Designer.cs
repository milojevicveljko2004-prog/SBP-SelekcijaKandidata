namespace App.Forme
{
    partial class OglasSezonskiForm
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
            this.textBoxLokacija = new System.Windows.Forms.TextBox();
            this.textBoxSezona = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.btnSacuvajSezonski = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOtkazi);
            this.groupBox1.Controls.Add(this.textBoxLokacija);
            this.groupBox1.Controls.Add(this.btnSacuvajSezonski);
            this.groupBox1.Controls.Add(this.textBoxSezona);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o sezonskom oglasu";
            // 
            // textBoxLokacija
            // 
            this.textBoxLokacija.Location = new System.Drawing.Point(124, 86);
            this.textBoxLokacija.Name = "textBoxLokacija";
            this.textBoxLokacija.Size = new System.Drawing.Size(174, 20);
            this.textBoxLokacija.TabIndex = 8;
            // 
            // textBoxSezona
            // 
            this.textBoxSezona.Location = new System.Drawing.Point(124, 40);
            this.textBoxSezona.Name = "textBoxSezona";
            this.textBoxSezona.Size = new System.Drawing.Size(174, 20);
            this.textBoxSezona.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lokacija:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sezona:";
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.BackColor = System.Drawing.Color.Turquoise;
            this.btnOtkazi.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtkazi.Location = new System.Drawing.Point(200, 134);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(98, 34);
            this.btnOtkazi.TabIndex = 9;
            this.btnOtkazi.Text = "Otkazi";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // btnSacuvajSezonski
            // 
            this.btnSacuvajSezonski.BackColor = System.Drawing.Color.Turquoise;
            this.btnSacuvajSezonski.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajSezonski.Location = new System.Drawing.Point(51, 134);
            this.btnSacuvajSezonski.Name = "btnSacuvajSezonski";
            this.btnSacuvajSezonski.Size = new System.Drawing.Size(98, 34);
            this.btnSacuvajSezonski.TabIndex = 8;
            this.btnSacuvajSezonski.Text = "Sacuvaj";
            this.btnSacuvajSezonski.UseVisualStyleBackColor = false;
            this.btnSacuvajSezonski.Click += new System.EventHandler(this.btnSacuvajSezonski_Click);
            // 
            // OglasSezonskiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(383, 222);
            this.Controls.Add(this.groupBox1);
            this.Name = "OglasSezonskiForm";
            this.Text = "OglasSezonskiForm";
            this.Load += new System.EventHandler(this.OglasSezonskiForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxLokacija;
        private System.Windows.Forms.TextBox textBoxSezona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnSacuvajSezonski;
    }
}