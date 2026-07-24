namespace App.Forme
{
    partial class DodajOglasForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblNazivPozicije = new System.Windows.Forms.Label();
            this.lblVrstaOglasa = new System.Windows.Forms.Label();
            this.lblOpis = new System.Windows.Forms.Label();
            this.lblZahtevi = new System.Windows.Forms.Label();
            this.lblMinPlata = new System.Windows.Forms.Label();
            this.lblMaxPlata = new System.Windows.Forms.Label();
            this.lblDatumZatvaranja = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.textBoxNazivPozicije = new System.Windows.Forms.TextBox();
            this.textBoxVrstaOglasa = new System.Windows.Forms.TextBox();
            this.textBoxMaxPlata = new System.Windows.Forms.TextBox();
            this.textBoxZahtevi = new System.Windows.Forms.TextBox();
            this.textBoxOpis = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxDatumZatvaranja = new System.Windows.Forms.TextBox();
            this.textBoxMinPlata = new System.Windows.Forms.TextBox();
            this.btnDodajOglas = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajOglas);
            this.groupBox1.Controls.Add(this.textBoxMinPlata);
            this.groupBox1.Controls.Add(this.textBoxDatumZatvaranja);
            this.groupBox1.Controls.Add(this.textBoxStatus);
            this.groupBox1.Controls.Add(this.textBoxOpis);
            this.groupBox1.Controls.Add(this.textBoxZahtevi);
            this.groupBox1.Controls.Add(this.textBoxMaxPlata);
            this.groupBox1.Controls.Add(this.textBoxVrstaOglasa);
            this.groupBox1.Controls.Add(this.textBoxNazivPozicije);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblDatumZatvaranja);
            this.groupBox1.Controls.Add(this.lblMaxPlata);
            this.groupBox1.Controls.Add(this.lblMinPlata);
            this.groupBox1.Controls.Add(this.lblZahtevi);
            this.groupBox1.Controls.Add(this.lblOpis);
            this.groupBox1.Controls.Add(this.lblVrstaOglasa);
            this.groupBox1.Controls.Add(this.lblNazivPozicije);
            this.groupBox1.Location = new System.Drawing.Point(23, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci o oglasu";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblNazivPozicije
            // 
            this.lblNazivPozicije.AutoSize = true;
            this.lblNazivPozicije.Location = new System.Drawing.Point(18, 38);
            this.lblNazivPozicije.Name = "lblNazivPozicije";
            this.lblNazivPozicije.Size = new System.Drawing.Size(75, 13);
            this.lblNazivPozicije.TabIndex = 0;
            this.lblNazivPozicije.Text = "Naziv pozicije:";
            // 
            // lblVrstaOglasa
            // 
            this.lblVrstaOglasa.AutoSize = true;
            this.lblVrstaOglasa.Location = new System.Drawing.Point(15, 78);
            this.lblVrstaOglasa.Name = "lblVrstaOglasa";
            this.lblVrstaOglasa.Size = new System.Drawing.Size(68, 13);
            this.lblVrstaOglasa.TabIndex = 1;
            this.lblVrstaOglasa.Text = "Vrsta oglasa:";
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Location = new System.Drawing.Point(18, 128);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(31, 13);
            this.lblOpis.TabIndex = 2;
            this.lblOpis.Text = "Opis:";
            // 
            // lblZahtevi
            // 
            this.lblZahtevi.AutoSize = true;
            this.lblZahtevi.Location = new System.Drawing.Point(18, 176);
            this.lblZahtevi.Name = "lblZahtevi";
            this.lblZahtevi.Size = new System.Drawing.Size(46, 13);
            this.lblZahtevi.TabIndex = 3;
            this.lblZahtevi.Text = "Zahtevi:";
            // 
            // lblMinPlata
            // 
            this.lblMinPlata.AutoSize = true;
            this.lblMinPlata.Location = new System.Drawing.Point(311, 78);
            this.lblMinPlata.Name = "lblMinPlata";
            this.lblMinPlata.Size = new System.Drawing.Size(53, 13);
            this.lblMinPlata.TabIndex = 4;
            this.lblMinPlata.Text = "Min plata:";
            // 
            // lblMaxPlata
            // 
            this.lblMaxPlata.AutoSize = true;
            this.lblMaxPlata.Location = new System.Drawing.Point(311, 35);
            this.lblMaxPlata.Name = "lblMaxPlata";
            this.lblMaxPlata.Size = new System.Drawing.Size(56, 13);
            this.lblMaxPlata.TabIndex = 5;
            this.lblMaxPlata.Text = "Max plata:";
            // 
            // lblDatumZatvaranja
            // 
            this.lblDatumZatvaranja.AutoSize = true;
            this.lblDatumZatvaranja.Location = new System.Drawing.Point(311, 141);
            this.lblDatumZatvaranja.Name = "lblDatumZatvaranja";
            this.lblDatumZatvaranja.Size = new System.Drawing.Size(93, 13);
            this.lblDatumZatvaranja.TabIndex = 7;
            this.lblDatumZatvaranja.Text = "Datum zatvaranja:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 216);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // textBoxNazivPozicije
            // 
            this.textBoxNazivPozicije.Location = new System.Drawing.Point(106, 35);
            this.textBoxNazivPozicije.Name = "textBoxNazivPozicije";
            this.textBoxNazivPozicije.Size = new System.Drawing.Size(165, 20);
            this.textBoxNazivPozicije.TabIndex = 9;
            // 
            // textBoxVrstaOglasa
            // 
            this.textBoxVrstaOglasa.Location = new System.Drawing.Point(106, 71);
            this.textBoxVrstaOglasa.Name = "textBoxVrstaOglasa";
            this.textBoxVrstaOglasa.Size = new System.Drawing.Size(165, 20);
            this.textBoxVrstaOglasa.TabIndex = 10;
            // 
            // textBoxMaxPlata
            // 
            this.textBoxMaxPlata.Location = new System.Drawing.Point(405, 28);
            this.textBoxMaxPlata.Name = "textBoxMaxPlata";
            this.textBoxMaxPlata.Size = new System.Drawing.Size(165, 20);
            this.textBoxMaxPlata.TabIndex = 11;
            // 
            // textBoxZahtevi
            // 
            this.textBoxZahtevi.Location = new System.Drawing.Point(106, 169);
            this.textBoxZahtevi.Name = "textBoxZahtevi";
            this.textBoxZahtevi.Size = new System.Drawing.Size(165, 20);
            this.textBoxZahtevi.TabIndex = 12;
            // 
            // textBoxOpis
            // 
            this.textBoxOpis.Location = new System.Drawing.Point(106, 121);
            this.textBoxOpis.Name = "textBoxOpis";
            this.textBoxOpis.Size = new System.Drawing.Size(165, 20);
            this.textBoxOpis.TabIndex = 13;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(106, 209);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(165, 20);
            this.textBoxStatus.TabIndex = 15;
            // 
            // textBoxDatumZatvaranja
            // 
            this.textBoxDatumZatvaranja.Location = new System.Drawing.Point(410, 138);
            this.textBoxDatumZatvaranja.Name = "textBoxDatumZatvaranja";
            this.textBoxDatumZatvaranja.Size = new System.Drawing.Size(165, 20);
            this.textBoxDatumZatvaranja.TabIndex = 16;
            // 
            // textBoxMinPlata
            // 
            this.textBoxMinPlata.Location = new System.Drawing.Point(405, 71);
            this.textBoxMinPlata.Name = "textBoxMinPlata";
            this.textBoxMinPlata.Size = new System.Drawing.Size(165, 20);
            this.textBoxMinPlata.TabIndex = 17;
            // 
            // btnDodajOglas
            // 
            this.btnDodajOglas.BackColor = System.Drawing.Color.Aquamarine;
            this.btnDodajOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajOglas.Location = new System.Drawing.Point(384, 188);
            this.btnDodajOglas.Name = "btnDodajOglas";
            this.btnDodajOglas.Size = new System.Drawing.Size(170, 41);
            this.btnDodajOglas.TabIndex = 18;
            this.btnDodajOglas.Text = "Dodaj";
            this.btnDodajOglas.UseVisualStyleBackColor = false;
            this.btnDodajOglas.Click += new System.EventHandler(this.btnDodajOglas_Click);
            // 
            // DodajOglasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(676, 289);
            this.Controls.Add(this.groupBox1);
            this.Name = "DodajOglasForm";
            this.Text = "DODAVANJE OGLASA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxMinPlata;
        private System.Windows.Forms.TextBox textBoxDatumZatvaranja;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxOpis;
        private System.Windows.Forms.TextBox textBoxZahtevi;
        private System.Windows.Forms.TextBox textBoxMaxPlata;
        private System.Windows.Forms.TextBox textBoxVrstaOglasa;
        private System.Windows.Forms.TextBox textBoxNazivPozicije;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDatumZatvaranja;
        private System.Windows.Forms.Label lblMaxPlata;
        private System.Windows.Forms.Label lblMinPlata;
        private System.Windows.Forms.Label lblZahtevi;
        private System.Windows.Forms.Label lblOpis;
        private System.Windows.Forms.Label lblVrstaOglasa;
        private System.Windows.Forms.Label lblNazivPozicije;
        private System.Windows.Forms.Button btnDodajOglas;
    }
}