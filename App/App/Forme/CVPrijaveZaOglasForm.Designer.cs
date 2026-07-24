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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.listCVPrijaveZaOglas = new System.Windows.Forms.ListView();
            this.colCvId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatumPodnosenja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listCVPrijaveZaOglas);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 318);
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
            this.colStatus});
            this.listCVPrijaveZaOglas.FullRowSelect = true;
            this.listCVPrijaveZaOglas.GridLines = true;
            this.listCVPrijaveZaOglas.HideSelection = false;
            this.listCVPrijaveZaOglas.Location = new System.Drawing.Point(6, 19);
            this.listCVPrijaveZaOglas.Name = "listCVPrijaveZaOglas";
            this.listCVPrijaveZaOglas.Size = new System.Drawing.Size(655, 293);
            this.listCVPrijaveZaOglas.TabIndex = 0;
            this.listCVPrijaveZaOglas.UseCompatibleStateImageBehavior = false;
            this.listCVPrijaveZaOglas.View = System.Windows.Forms.View.Details;
            // 
            // colCvId
            // 
            this.colCvId.Text = "ID";
            this.colCvId.Width = 40;
            // 
            // colIme
            // 
            this.colIme.Text = "Ime";
            this.colIme.Width = 85;
            // 
            // colPrezime
            // 
            this.colPrezime.Text = "Prezime";
            this.colPrezime.Width = 85;
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
            this.colStatus.Width = 80;
            // 
            // CVPrijaveZaOglasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(880, 345);
            this.Controls.Add(this.groupBox1);
            this.Name = "CVPrijaveZaOglasForm";
            this.Text = "CV PRIJAVE ZA OGLAS";
            this.Load += new System.EventHandler(this.CVPrijaveZaOglasForm_Load);
            this.groupBox1.ResumeLayout(false);
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
    }
}