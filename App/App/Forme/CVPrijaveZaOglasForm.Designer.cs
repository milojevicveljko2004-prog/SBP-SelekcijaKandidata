namespace App.Forme
{
    partial class CVPrijaveZaOglasForm
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
            this.listCVPrijaveZaOglas = new System.Windows.Forms.ListView();
            this.colCvId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatumPodnosenja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnDodajCV_UOglas = new System.Windows.Forms.Button();
            this.btnIzmeniCV_zaOglas = new System.Windows.Forms.Button();
            this.btnObrisiCV_zaOglas = new System.Windows.Forms.Button();
            this.groupBoxPodaciCV = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIntervjui = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTestovi = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOdluka = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxPodaciCV.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listCVPrijaveZaOglas);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1005, 704);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CV prijave za oglas";
            // 
            // listCVPrijaveZaOglas
            // 
            this.listCVPrijaveZaOglas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCvId,
            this.colIme,
            this.colPrezime,
            this.colEmail,
            this.colTelefon,
            this.colDatumPodnosenja,
            this.colStatus,
            this.columnHeader1});
            this.listCVPrijaveZaOglas.FullRowSelect = true;
            this.listCVPrijaveZaOglas.GridLines = true;
            this.listCVPrijaveZaOglas.HideSelection = false;
            this.listCVPrijaveZaOglas.Location = new System.Drawing.Point(8, 23);
            this.listCVPrijaveZaOglas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listCVPrijaveZaOglas.Name = "listCVPrijaveZaOglas";
            this.listCVPrijaveZaOglas.Size = new System.Drawing.Size(987, 672);
            this.listCVPrijaveZaOglas.TabIndex = 0;
            this.listCVPrijaveZaOglas.UseCompatibleStateImageBehavior = false;
            this.listCVPrijaveZaOglas.View = System.Windows.Forms.View.Details;
            // 
            // colCvId
            // 
            this.colCvId.Text = "ID";
            this.colCvId.Width = 45;
            // 
            // colIme
            // 
            this.colIme.Text = "Ime";
            this.colIme.Width = 85;
            // 
            // colPrezime
            // 
            this.colPrezime.Text = "Prezime";
            this.colPrezime.Width = 95;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 160;
            // 
            // colTelefon
            // 
            this.colTelefon.Text = "Telefon";
            this.colTelefon.Width = 100;
            // 
            // colDatumPodnosenja
            // 
            this.colDatumPodnosenja.Text = "Datum prijave";
            this.colDatumPodnosenja.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 90;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Oglas ID";
            // 
            // btnDodajCV_UOglas
            // 
            this.btnDodajCV_UOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnDodajCV_UOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajCV_UOglas.Location = new System.Drawing.Point(47, 38);
            this.btnDodajCV_UOglas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDodajCV_UOglas.Name = "btnDodajCV_UOglas";
            this.btnDodajCV_UOglas.Size = new System.Drawing.Size(213, 57);
            this.btnDodajCV_UOglas.TabIndex = 1;
            this.btnDodajCV_UOglas.Text = "Dodaj novi CV";
            this.btnDodajCV_UOglas.UseVisualStyleBackColor = false;
            this.btnDodajCV_UOglas.Click += new System.EventHandler(this.btnDodajCV_UOglas_Click);
            // 
            // btnIzmeniCV_zaOglas
            // 
            this.btnIzmeniCV_zaOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnIzmeniCV_zaOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniCV_zaOglas.Location = new System.Drawing.Point(47, 114);
            this.btnIzmeniCV_zaOglas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIzmeniCV_zaOglas.Name = "btnIzmeniCV_zaOglas";
            this.btnIzmeniCV_zaOglas.Size = new System.Drawing.Size(213, 57);
            this.btnIzmeniCV_zaOglas.TabIndex = 2;
            this.btnIzmeniCV_zaOglas.Text = "Izmeni CV";
            this.btnIzmeniCV_zaOglas.UseVisualStyleBackColor = false;
            this.btnIzmeniCV_zaOglas.Click += new System.EventHandler(this.btnIzmeniCV_zaOglas_Click);
            // 
            // btnObrisiCV_zaOglas
            // 
            this.btnObrisiCV_zaOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnObrisiCV_zaOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiCV_zaOglas.Location = new System.Drawing.Point(47, 196);
            this.btnObrisiCV_zaOglas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnObrisiCV_zaOglas.Name = "btnObrisiCV_zaOglas";
            this.btnObrisiCV_zaOglas.Size = new System.Drawing.Size(213, 57);
            this.btnObrisiCV_zaOglas.TabIndex = 3;
            this.btnObrisiCV_zaOglas.Text = "Obrisi CV";
            this.btnObrisiCV_zaOglas.UseVisualStyleBackColor = false;
            this.btnObrisiCV_zaOglas.Click += new System.EventHandler(this.btnObrisiCV_zaOglas_Click);
            // 
            // groupBoxPodaciCV
            // 
            this.groupBoxPodaciCV.Controls.Add(this.btnDodajCV_UOglas);
            this.groupBoxPodaciCV.Controls.Add(this.btnObrisiCV_zaOglas);
            this.groupBoxPodaciCV.Controls.Add(this.btnIzmeniCV_zaOglas);
            this.groupBoxPodaciCV.Location = new System.Drawing.Point(1041, 15);
            this.groupBoxPodaciCV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxPodaciCV.Name = "groupBoxPodaciCV";
            this.groupBoxPodaciCV.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxPodaciCV.Size = new System.Drawing.Size(312, 267);
            this.groupBoxPodaciCV.TabIndex = 38;
            this.groupBoxPodaciCV.TabStop = false;
            this.groupBoxPodaciCV.Text = "Podaci o oglasu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIntervjui);
            this.groupBox2.Location = new System.Drawing.Point(1041, 300);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(312, 123);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Intervjui";
            // 
            // btnIntervjui
            // 
            this.btnIntervjui.BackColor = System.Drawing.Color.Turquoise;
            this.btnIntervjui.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIntervjui.Location = new System.Drawing.Point(47, 38);
            this.btnIntervjui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIntervjui.Name = "btnIntervjui";
            this.btnIntervjui.Size = new System.Drawing.Size(213, 57);
            this.btnIntervjui.TabIndex = 4;
            this.btnIntervjui.Text = "Intervjui";
            this.btnIntervjui.UseVisualStyleBackColor = false;
            this.btnIntervjui.Click += new System.EventHandler(this.btnIntervjui_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTestovi);
            this.groupBox3.Location = new System.Drawing.Point(1041, 446);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(312, 123);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Testovi";
            // 
            // btnTestovi
            // 
            this.btnTestovi.BackColor = System.Drawing.Color.Turquoise;
            this.btnTestovi.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestovi.Location = new System.Drawing.Point(47, 38);
            this.btnTestovi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestovi.Name = "btnTestovi";
            this.btnTestovi.Size = new System.Drawing.Size(213, 57);
            this.btnTestovi.TabIndex = 4;
            this.btnTestovi.Text = "Testovi";
            this.btnTestovi.UseVisualStyleBackColor = false;
            this.btnTestovi.Click += new System.EventHandler(this.btnTestovi_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOdluka);
            this.groupBox4.Location = new System.Drawing.Point(1041, 596);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(312, 123);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Odluka";
            // 
            // btnOdluka
            // 
            this.btnOdluka.BackColor = System.Drawing.Color.Turquoise;
            this.btnOdluka.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOdluka.Location = new System.Drawing.Point(47, 38);
            this.btnOdluka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOdluka.Name = "btnOdluka";
            this.btnOdluka.Size = new System.Drawing.Size(213, 57);
            this.btnOdluka.TabIndex = 4;
            this.btnOdluka.Text = "Odluka";
            this.btnOdluka.UseVisualStyleBackColor = false;
            this.btnOdluka.Click += new System.EventHandler(this.btnOdluka_Click);
            // 
            // CVPrijaveZaOglasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1384, 737);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxPodaciCV);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1402, 784);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1402, 784);
            this.Name = "CVPrijaveZaOglasForm";
            this.Text = "CV PRIJAVE ZA OGLAS";
            this.Load += new System.EventHandler(this.CVPrijaveZaOglasForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxPodaciCV.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ListView listCVPrijaveZaOglas;
        private System.Windows.Forms.ColumnHeader colCvId;
        private System.Windows.Forms.ColumnHeader colIme;
        private System.Windows.Forms.ColumnHeader colPrezime;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colTelefon;
        private System.Windows.Forms.ColumnHeader colDatumPodnosenja;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnDodajCV_UOglas;
        private System.Windows.Forms.Button btnIzmeniCV_zaOglas;
        private System.Windows.Forms.Button btnObrisiCV_zaOglas;
        private System.Windows.Forms.GroupBox groupBoxPodaciCV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIntervjui;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTestovi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOdluka;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}