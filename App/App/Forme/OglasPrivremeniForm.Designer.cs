namespace App.Forme
{
    partial class OglasPrivremeniForm
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
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.btnSacuvajPrivremeni = new System.Windows.Forms.Button();
            this.textBoxProjekat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDatumPocetka = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDatumZavrsetka = new System.Windows.Forms.DateTimePicker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateDatumZavrsetka);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateDatumPocetka);
            this.groupBox1.Controls.Add(this.btnOtkazi);
            this.groupBox1.Controls.Add(this.btnSacuvajPrivremeni);
            this.groupBox1.Controls.Add(this.textBoxProjekat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 219);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o privremenom oglasu";
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.BackColor = System.Drawing.Color.Turquoise;
            this.btnOtkazi.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtkazi.Location = new System.Drawing.Point(204, 165);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(98, 34);
            this.btnOtkazi.TabIndex = 7;
            this.btnOtkazi.Text = "Otkazi";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // btnSacuvajPrivremeni
            // 
            this.btnSacuvajPrivremeni.BackColor = System.Drawing.Color.Turquoise;
            this.btnSacuvajPrivremeni.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajPrivremeni.Location = new System.Drawing.Point(60, 165);
            this.btnSacuvajPrivremeni.Name = "btnSacuvajPrivremeni";
            this.btnSacuvajPrivremeni.Size = new System.Drawing.Size(98, 34);
            this.btnSacuvajPrivremeni.TabIndex = 6;
            this.btnSacuvajPrivremeni.Text = "Sacuvaj";
            this.btnSacuvajPrivremeni.UseVisualStyleBackColor = false;
            this.btnSacuvajPrivremeni.Click += new System.EventHandler(this.btnSacuvajPrivremeni_Click);
            // 
            // textBoxProjekat
            // 
            this.textBoxProjekat.Location = new System.Drawing.Point(150, 36);
            this.textBoxProjekat.Name = "textBoxProjekat";
            this.textBoxProjekat.Size = new System.Drawing.Size(200, 20);
            this.textBoxProjekat.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum pocetka:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Projekat:";
            // 
            // dateDatumPocetka
            // 
            this.dateDatumPocetka.Location = new System.Drawing.Point(150, 79);
            this.dateDatumPocetka.Name = "dateDatumPocetka";
            this.dateDatumPocetka.Size = new System.Drawing.Size(200, 20);
            this.dateDatumPocetka.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Datum zavrsetka:";
            // 
            // dateDatumZavrsetka
            // 
            this.dateDatumZavrsetka.Location = new System.Drawing.Point(150, 119);
            this.dateDatumZavrsetka.Name = "dateDatumZavrsetka";
            this.dateDatumZavrsetka.Size = new System.Drawing.Size(200, 20);
            this.dateDatumZavrsetka.TabIndex = 10;
            // 
            // OglasPrivremeniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(418, 246);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(434, 285);
            this.MinimumSize = new System.Drawing.Size(434, 285);
            this.Name = "OglasPrivremeniForm";
            this.Text = "OglasPrivremeniForm";
            this.Load += new System.EventHandler(this.OglasPrivremeniForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnSacuvajPrivremeni;
        private System.Windows.Forms.TextBox textBoxProjekat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDatumZavrsetka;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDatumPocetka;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}