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
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.date_datumZatvaranja = new System.Windows.Forms.DateTimePicker();
            this.statusOglasaBox = new System.Windows.Forms.ComboBox();
            this.vrstaOglasaBox = new System.Windows.Forms.ComboBox();
            this.btnDodajOglas = new System.Windows.Forms.Button();
            this.textBoxNazivPozicije = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDatumZatvaranja = new System.Windows.Forms.Label();
            this.lblMaxPlata = new System.Windows.Forms.Label();
            this.lblMinPlata = new System.Windows.Forms.Label();
            this.lblZahtevi = new System.Windows.Forms.Label();
            this.lblOpis = new System.Windows.Forms.Label();
            this.lblVrstaOglasa = new System.Windows.Forms.Label();
            this.lblNazivPozicije = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.richTextBoxOpis = new System.Windows.Forms.RichTextBox();
            this.richTextBoxZahtevi = new System.Windows.Forms.RichTextBox();
            this.groupBoxPraksa = new System.Windows.Forms.GroupBox();
            this.groupBoxPrivremeni = new System.Windows.Forms.GroupBox();
            this.groupBoxSezonski = new System.Windows.Forms.GroupBox();
            this.numericDuzinaTrajanja = new System.Windows.Forms.NumericUpDown();
            this.textBoxMentorPrezime = new System.Windows.Forms.TextBox();
            this.textBoxMentorIme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDatumZavrsetka = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateDatumPocetka = new System.Windows.Forms.DateTimePicker();
            this.textBoxProjekat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxLokacija = new System.Windows.Forms.TextBox();
            this.textBoxSezona = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxPraksa.SuspendLayout();
            this.groupBoxPrivremeni.SuspendLayout();
            this.groupBoxSezonski.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuzinaTrajanja)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxSezonski);
            this.groupBox1.Controls.Add(this.groupBoxPraksa);
            this.groupBox1.Controls.Add(this.groupBoxPrivremeni);
            this.groupBox1.Controls.Add(this.richTextBoxZahtevi);
            this.groupBox1.Controls.Add(this.richTextBoxOpis);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.date_datumZatvaranja);
            this.groupBox1.Controls.Add(this.statusOglasaBox);
            this.groupBox1.Controls.Add(this.vrstaOglasaBox);
            this.groupBox1.Controls.Add(this.btnDodajOglas);
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
            this.groupBox1.Size = new System.Drawing.Size(711, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o oglasu";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(384, 76);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(165, 20);
            this.numericUpDown2.TabIndex = 23;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(384, 33);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(165, 20);
            this.numericUpDown1.TabIndex = 22;
            // 
            // date_datumZatvaranja
            // 
            this.date_datumZatvaranja.Location = new System.Drawing.Point(424, 128);
            this.date_datumZatvaranja.Name = "date_datumZatvaranja";
            this.date_datumZatvaranja.Size = new System.Drawing.Size(200, 20);
            this.date_datumZatvaranja.TabIndex = 21;
            // 
            // statusOglasaBox
            // 
            this.statusOglasaBox.FormattingEnabled = true;
            this.statusOglasaBox.Items.AddRange(new object[] {
            "AKTIVAN,",
            "ZATVOREN,",
            "U_PROCESU_SELEKCIJE"});
            this.statusOglasaBox.Location = new System.Drawing.Point(106, 313);
            this.statusOglasaBox.Name = "statusOglasaBox";
            this.statusOglasaBox.Size = new System.Drawing.Size(165, 21);
            this.statusOglasaBox.TabIndex = 20;
            // 
            // vrstaOglasaBox
            // 
            this.vrstaOglasaBox.FormattingEnabled = true;
            this.vrstaOglasaBox.Items.AddRange(new object[] {
            "STALNI",
            "PRIVREMENI",
            "PRAKSA",
            "SEZONSKI"});
            this.vrstaOglasaBox.Location = new System.Drawing.Point(106, 75);
            this.vrstaOglasaBox.Name = "vrstaOglasaBox";
            this.vrstaOglasaBox.Size = new System.Drawing.Size(165, 21);
            this.vrstaOglasaBox.TabIndex = 19;
            this.vrstaOglasaBox.SelectedIndexChanged += new System.EventHandler(this.vrstaOglasaBox_SelectedIndexChanged);
            // 
            // btnDodajOglas
            // 
            this.btnDodajOglas.BackColor = System.Drawing.Color.Aquamarine;
            this.btnDodajOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajOglas.Location = new System.Drawing.Point(379, 347);
            this.btnDodajOglas.Name = "btnDodajOglas";
            this.btnDodajOglas.Size = new System.Drawing.Size(170, 41);
            this.btnDodajOglas.TabIndex = 18;
            this.btnDodajOglas.Text = "Dodaj";
            this.btnDodajOglas.UseVisualStyleBackColor = false;
            this.btnDodajOglas.Click += new System.EventHandler(this.btnDodajOglas_Click);
            // 
            // textBoxNazivPozicije
            // 
            this.textBoxNazivPozicije.Location = new System.Drawing.Point(106, 35);
            this.textBoxNazivPozicije.Name = "textBoxNazivPozicije";
            this.textBoxNazivPozicije.Size = new System.Drawing.Size(165, 20);
            this.textBoxNazivPozicije.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 321);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // lblDatumZatvaranja
            // 
            this.lblDatumZatvaranja.AutoSize = true;
            this.lblDatumZatvaranja.Location = new System.Drawing.Point(311, 134);
            this.lblDatumZatvaranja.Name = "lblDatumZatvaranja";
            this.lblDatumZatvaranja.Size = new System.Drawing.Size(93, 13);
            this.lblDatumZatvaranja.TabIndex = 7;
            this.lblDatumZatvaranja.Text = "Datum zatvaranja:";
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
            // lblMinPlata
            // 
            this.lblMinPlata.AutoSize = true;
            this.lblMinPlata.Location = new System.Drawing.Point(311, 78);
            this.lblMinPlata.Name = "lblMinPlata";
            this.lblMinPlata.Size = new System.Drawing.Size(53, 13);
            this.lblMinPlata.TabIndex = 4;
            this.lblMinPlata.Text = "Min plata:";
            // 
            // lblZahtevi
            // 
            this.lblZahtevi.AutoSize = true;
            this.lblZahtevi.Location = new System.Drawing.Point(18, 216);
            this.lblZahtevi.Name = "lblZahtevi";
            this.lblZahtevi.Size = new System.Drawing.Size(46, 13);
            this.lblZahtevi.TabIndex = 3;
            this.lblZahtevi.Text = "Zahtevi:";
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
            // lblVrstaOglasa
            // 
            this.lblVrstaOglasa.AutoSize = true;
            this.lblVrstaOglasa.Location = new System.Drawing.Point(15, 78);
            this.lblVrstaOglasa.Name = "lblVrstaOglasa";
            this.lblVrstaOglasa.Size = new System.Drawing.Size(68, 13);
            this.lblVrstaOglasa.TabIndex = 1;
            this.lblVrstaOglasa.Text = "Vrsta oglasa:";
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
            // richTextBoxOpis
            // 
            this.richTextBoxOpis.Location = new System.Drawing.Point(106, 125);
            this.richTextBoxOpis.Name = "richTextBoxOpis";
            this.richTextBoxOpis.Size = new System.Drawing.Size(165, 64);
            this.richTextBoxOpis.TabIndex = 24;
            this.richTextBoxOpis.Text = "";
            // 
            // richTextBoxZahtevi
            // 
            this.richTextBoxZahtevi.Location = new System.Drawing.Point(106, 213);
            this.richTextBoxZahtevi.Name = "richTextBoxZahtevi";
            this.richTextBoxZahtevi.Size = new System.Drawing.Size(165, 64);
            this.richTextBoxZahtevi.TabIndex = 25;
            this.richTextBoxZahtevi.Text = "";
            // 
            // groupBoxPraksa
            // 
            this.groupBoxPraksa.Controls.Add(this.numericDuzinaTrajanja);
            this.groupBoxPraksa.Controls.Add(this.textBoxMentorPrezime);
            this.groupBoxPraksa.Controls.Add(this.textBoxMentorIme);
            this.groupBoxPraksa.Controls.Add(this.label3);
            this.groupBoxPraksa.Controls.Add(this.label2);
            this.groupBoxPraksa.Controls.Add(this.label1);
            this.groupBoxPraksa.Location = new System.Drawing.Point(304, 166);
            this.groupBoxPraksa.Name = "groupBoxPraksa";
            this.groupBoxPraksa.Size = new System.Drawing.Size(377, 153);
            this.groupBoxPraksa.TabIndex = 27;
            this.groupBoxPraksa.TabStop = false;
            this.groupBoxPraksa.Text = "Dodatni podaci za praksu";
            // 
            // groupBoxPrivremeni
            // 
            this.groupBoxPrivremeni.Controls.Add(this.dateDatumZavrsetka);
            this.groupBoxPrivremeni.Controls.Add(this.label4);
            this.groupBoxPrivremeni.Controls.Add(this.dateDatumPocetka);
            this.groupBoxPrivremeni.Controls.Add(this.textBoxProjekat);
            this.groupBoxPrivremeni.Controls.Add(this.label5);
            this.groupBoxPrivremeni.Controls.Add(this.label6);
            this.groupBoxPrivremeni.Location = new System.Drawing.Point(304, 174);
            this.groupBoxPrivremeni.Name = "groupBoxPrivremeni";
            this.groupBoxPrivremeni.Size = new System.Drawing.Size(377, 151);
            this.groupBoxPrivremeni.TabIndex = 28;
            this.groupBoxPrivremeni.TabStop = false;
            this.groupBoxPrivremeni.Text = "Dodatni podaci za privremeni oglas";
            // 
            // groupBoxSezonski
            // 
            this.groupBoxSezonski.Controls.Add(this.textBoxLokacija);
            this.groupBoxSezonski.Controls.Add(this.textBoxSezona);
            this.groupBoxSezonski.Controls.Add(this.label7);
            this.groupBoxSezonski.Controls.Add(this.label8);
            this.groupBoxSezonski.Location = new System.Drawing.Point(304, 181);
            this.groupBoxSezonski.Name = "groupBoxSezonski";
            this.groupBoxSezonski.Size = new System.Drawing.Size(377, 153);
            this.groupBoxSezonski.TabIndex = 29;
            this.groupBoxSezonski.TabStop = false;
            this.groupBoxSezonski.Text = "Dodatni podaci za sezonski oglas";
            // 
            // numericDuzinaTrajanja
            // 
            this.numericDuzinaTrajanja.Location = new System.Drawing.Point(138, 121);
            this.numericDuzinaTrajanja.Name = "numericDuzinaTrajanja";
            this.numericDuzinaTrajanja.Size = new System.Drawing.Size(174, 20);
            this.numericDuzinaTrajanja.TabIndex = 11;
            // 
            // textBoxMentorPrezime
            // 
            this.textBoxMentorPrezime.Location = new System.Drawing.Point(138, 72);
            this.textBoxMentorPrezime.Name = "textBoxMentorPrezime";
            this.textBoxMentorPrezime.Size = new System.Drawing.Size(174, 20);
            this.textBoxMentorPrezime.TabIndex = 10;
            // 
            // textBoxMentorIme
            // 
            this.textBoxMentorIme.Location = new System.Drawing.Point(138, 33);
            this.textBoxMentorIme.Name = "textBoxMentorIme";
            this.textBoxMentorIme.Size = new System.Drawing.Size(174, 20);
            this.textBoxMentorIme.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Duzina trajanja:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Prezime mentora:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ime mentora:";
            // 
            // dateDatumZavrsetka
            // 
            this.dateDatumZavrsetka.Location = new System.Drawing.Point(151, 114);
            this.dateDatumZavrsetka.Name = "dateDatumZavrsetka";
            this.dateDatumZavrsetka.Size = new System.Drawing.Size(200, 20);
            this.dateDatumZavrsetka.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Datum zavrsetka:";
            // 
            // dateDatumPocetka
            // 
            this.dateDatumPocetka.Location = new System.Drawing.Point(151, 74);
            this.dateDatumPocetka.Name = "dateDatumPocetka";
            this.dateDatumPocetka.Size = new System.Drawing.Size(200, 20);
            this.dateDatumPocetka.TabIndex = 14;
            // 
            // textBoxProjekat
            // 
            this.textBoxProjekat.Location = new System.Drawing.Point(151, 31);
            this.textBoxProjekat.Name = "textBoxProjekat";
            this.textBoxProjekat.Size = new System.Drawing.Size(200, 20);
            this.textBoxProjekat.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Datum pocetka:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Projekat:";
            // 
            // textBoxLokacija
            // 
            this.textBoxLokacija.Location = new System.Drawing.Point(146, 89);
            this.textBoxLokacija.Name = "textBoxLokacija";
            this.textBoxLokacija.Size = new System.Drawing.Size(174, 20);
            this.textBoxLokacija.TabIndex = 12;
            // 
            // textBoxSezona
            // 
            this.textBoxSezona.Location = new System.Drawing.Point(146, 43);
            this.textBoxSezona.Name = "textBoxSezona";
            this.textBoxSezona.Size = new System.Drawing.Size(174, 20);
            this.textBoxSezona.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Lokacija:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Sezona:";
            // 
            // DodajOglasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(757, 455);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(773, 494);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(773, 494);
            this.Name = "DodajOglasForm";
            this.Text = "DODAVANJE OGLASA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxPraksa.ResumeLayout(false);
            this.groupBoxPraksa.PerformLayout();
            this.groupBoxPrivremeni.ResumeLayout(false);
            this.groupBoxPrivremeni.PerformLayout();
            this.groupBoxSezonski.ResumeLayout(false);
            this.groupBoxSezonski.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuzinaTrajanja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private System.Windows.Forms.ComboBox vrstaOglasaBox;
        private System.Windows.Forms.ComboBox statusOglasaBox;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker date_datumZatvaranja;
        private System.Windows.Forms.RichTextBox richTextBoxZahtevi;
        private System.Windows.Forms.RichTextBox richTextBoxOpis;
        private System.Windows.Forms.GroupBox groupBoxPrivremeni;
        private System.Windows.Forms.GroupBox groupBoxSezonski;
        private System.Windows.Forms.GroupBox groupBoxPraksa;
        private System.Windows.Forms.NumericUpDown numericDuzinaTrajanja;
        private System.Windows.Forms.TextBox textBoxMentorPrezime;
        private System.Windows.Forms.TextBox textBoxMentorIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDatumZavrsetka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateDatumPocetka;
        private System.Windows.Forms.TextBox textBoxProjekat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLokacija;
        private System.Windows.Forms.TextBox textBoxSezona;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}