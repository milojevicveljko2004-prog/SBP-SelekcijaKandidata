namespace App.Forme
{
    partial class OglasiForm
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
            System.Windows.Forms.ColumnHeader colNazivPozicije;
            this.groupBoxListaOglasa = new System.Windows.Forms.GroupBox();
            this.listaOglasa = new System.Windows.Forms.ListView();
            this.colOglasId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVrstaOglasa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpis = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colZahtevi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMinPlata = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaxPlata = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatumObjave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatumZatvaranja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxPodaciOOglasu = new System.Windows.Forms.GroupBox();
            this.btnObrisiOglas = new System.Windows.Forms.Button();
            this.btnIzmeniOglas = new System.Windows.Forms.Button();
            this.btnDodajOglas = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCVPrijaveZaOglas = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPosebniPodaci = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            colNazivPozicije = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxListaOglasa.SuspendLayout();
            this.groupBoxPodaciOOglasu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colNazivPozicije
            // 
            colNazivPozicije.Text = "Naziv pozicije";
            colNazivPozicije.Width = 130;
            // 
            // groupBoxListaOglasa
            // 
            this.groupBoxListaOglasa.Controls.Add(this.listaOglasa);
            this.groupBoxListaOglasa.Location = new System.Drawing.Point(14, 20);
            this.groupBoxListaOglasa.Name = "groupBoxListaOglasa";
            this.groupBoxListaOglasa.Size = new System.Drawing.Size(1015, 601);
            this.groupBoxListaOglasa.TabIndex = 24;
            this.groupBoxListaOglasa.TabStop = false;
            this.groupBoxListaOglasa.Text = "Lista oglasa";
            this.groupBoxListaOglasa.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // listaOglasa
            // 
            this.listaOglasa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOglasId,
            colNazivPozicije,
            this.colVrstaOglasa,
            this.colOpis,
            this.colZahtevi,
            this.colMinPlata,
            this.colMaxPlata,
            this.colDatumObjave,
            this.colDatumZatvaranja,
            this.colStatus});
            this.listaOglasa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listaOglasa.FullRowSelect = true;
            this.listaOglasa.GridLines = true;
            this.listaOglasa.HideSelection = false;
            this.listaOglasa.Location = new System.Drawing.Point(3, 16);
            this.listaOglasa.Margin = new System.Windows.Forms.Padding(4);
            this.listaOglasa.Name = "listaOglasa";
            this.listaOglasa.Size = new System.Drawing.Size(1009, 582);
            this.listaOglasa.TabIndex = 4;
            this.listaOglasa.UseCompatibleStateImageBehavior = false;
            this.listaOglasa.View = System.Windows.Forms.View.Details;
            // 
            // colOglasId
            // 
            this.colOglasId.Text = "ID";
            this.colOglasId.Width = 45;
            // 
            // colVrstaOglasa
            // 
            this.colVrstaOglasa.Text = "Vrsta oglasa";
            this.colVrstaOglasa.Width = 80;
            // 
            // colOpis
            // 
            this.colOpis.Text = "Opis";
            this.colOpis.Width = 130;
            // 
            // colZahtevi
            // 
            this.colZahtevi.Text = "Zahtevi";
            this.colZahtevi.Width = 130;
            // 
            // colMinPlata
            // 
            this.colMinPlata.Text = "Min. plata";
            this.colMinPlata.Width = 70;
            // 
            // colMaxPlata
            // 
            this.colMaxPlata.Text = "Max. plata";
            this.colMaxPlata.Width = 70;
            // 
            // colDatumObjave
            // 
            this.colDatumObjave.Text = "Objavljen";
            this.colDatumObjave.Width = 120;
            // 
            // colDatumZatvaranja
            // 
            this.colDatumZatvaranja.Text = "Datum zatvaranja";
            this.colDatumZatvaranja.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 110;
            // 
            // groupBoxPodaciOOglasu
            // 
            this.groupBoxPodaciOOglasu.Controls.Add(this.btnObrisiOglas);
            this.groupBoxPodaciOOglasu.Controls.Add(this.btnIzmeniOglas);
            this.groupBoxPodaciOOglasu.Controls.Add(this.btnDodajOglas);
            this.groupBoxPodaciOOglasu.Location = new System.Drawing.Point(1035, 20);
            this.groupBoxPodaciOOglasu.Name = "groupBoxPodaciOOglasu";
            this.groupBoxPodaciOOglasu.Size = new System.Drawing.Size(234, 220);
            this.groupBoxPodaciOOglasu.TabIndex = 37;
            this.groupBoxPodaciOOglasu.TabStop = false;
            this.groupBoxPodaciOOglasu.Text = "Podaci o oglasu";
            this.groupBoxPodaciOOglasu.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // btnObrisiOglas
            // 
            this.btnObrisiOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnObrisiOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiOglas.Location = new System.Drawing.Point(25, 160);
            this.btnObrisiOglas.Name = "btnObrisiOglas";
            this.btnObrisiOglas.Size = new System.Drawing.Size(175, 46);
            this.btnObrisiOglas.TabIndex = 2;
            this.btnObrisiOglas.Text = "Obrisi oglas";
            this.btnObrisiOglas.UseVisualStyleBackColor = false;
            this.btnObrisiOglas.Click += new System.EventHandler(this.btnObrisiOglas_Click);
            // 
            // btnIzmeniOglas
            // 
            this.btnIzmeniOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnIzmeniOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniOglas.Location = new System.Drawing.Point(25, 94);
            this.btnIzmeniOglas.Name = "btnIzmeniOglas";
            this.btnIzmeniOglas.Size = new System.Drawing.Size(175, 46);
            this.btnIzmeniOglas.TabIndex = 1;
            this.btnIzmeniOglas.Text = "Izmeni oglas";
            this.btnIzmeniOglas.UseVisualStyleBackColor = false;
            this.btnIzmeniOglas.Click += new System.EventHandler(this.btnIzmeniOglas_Click);
            // 
            // btnDodajOglas
            // 
            this.btnDodajOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnDodajOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajOglas.Location = new System.Drawing.Point(25, 28);
            this.btnDodajOglas.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajOglas.Name = "btnDodajOglas";
            this.btnDodajOglas.Size = new System.Drawing.Size(175, 46);
            this.btnDodajOglas.TabIndex = 0;
            this.btnDodajOglas.Text = "Dodaj oglas";
            this.btnDodajOglas.UseVisualStyleBackColor = false;
            this.btnDodajOglas.Click += new System.EventHandler(this.btnDodajOglas_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCVPrijaveZaOglas);
            this.groupBox2.Location = new System.Drawing.Point(1035, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 93);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CV prijave";
            // 
            // btnCVPrijaveZaOglas
            // 
            this.btnCVPrijaveZaOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnCVPrijaveZaOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCVPrijaveZaOglas.Location = new System.Drawing.Point(25, 29);
            this.btnCVPrijaveZaOglas.Name = "btnCVPrijaveZaOglas";
            this.btnCVPrijaveZaOglas.Size = new System.Drawing.Size(175, 46);
            this.btnCVPrijaveZaOglas.TabIndex = 0;
            this.btnCVPrijaveZaOglas.Text = "CV prijave za oglas";
            this.btnCVPrijaveZaOglas.UseVisualStyleBackColor = false;
            this.btnCVPrijaveZaOglas.Click += new System.EventHandler(this.btnCVPrijaveZaOglas_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPosebniPodaci);
            this.groupBox1.Location = new System.Drawing.Point(1035, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 93);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posebni podaci";
            // 
            // btnPosebniPodaci
            // 
            this.btnPosebniPodaci.BackColor = System.Drawing.Color.Turquoise;
            this.btnPosebniPodaci.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPosebniPodaci.Location = new System.Drawing.Point(25, 29);
            this.btnPosebniPodaci.Name = "btnPosebniPodaci";
            this.btnPosebniPodaci.Size = new System.Drawing.Size(175, 46);
            this.btnPosebniPodaci.TabIndex = 0;
            this.btnPosebniPodaci.Text = "Posebni podaci";
            this.btnPosebniPodaci.UseVisualStyleBackColor = false;
            this.btnPosebniPodaci.Click += new System.EventHandler(this.btnPosebniPodaci_Click);
            // 
            // OglasiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1278, 648);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxPodaciOOglasu);
            this.Controls.Add(this.groupBoxListaOglasa);
            this.Location = new System.Drawing.Point(696, 20);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1294, 687);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1294, 687);
            this.Name = "OglasiForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "LISTA OGLASA";
            this.Load += new System.EventHandler(this.OglasiForm_Load);
            this.groupBoxListaOglasa.ResumeLayout(false);
            this.groupBoxPodaciOOglasu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxListaOglasa;
        private System.Windows.Forms.ListView listaOglasa;
        private System.Windows.Forms.ColumnHeader colOglasId;
        private System.Windows.Forms.ColumnHeader colVrstaOglasa;
        private System.Windows.Forms.ColumnHeader colMinPlata;
        private System.Windows.Forms.ColumnHeader colMaxPlata;
        private System.Windows.Forms.ColumnHeader colDatumObjave;
        private System.Windows.Forms.ColumnHeader colDatumZatvaranja;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.GroupBox groupBoxPodaciOOglasu;
        private System.Windows.Forms.Button btnObrisiOglas;
        private System.Windows.Forms.Button btnIzmeniOglas;
        private System.Windows.Forms.Button btnDodajOglas;
        private System.Windows.Forms.ColumnHeader colOpis;
        private System.Windows.Forms.ColumnHeader colZahtevi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCVPrijaveZaOglas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPosebniPodaci;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}