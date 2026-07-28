namespace App.Forme
{
    partial class SveCVPrijaveForm
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
            this.listCVPrijave = new System.Windows.Forms.ListView();
            this.colCvId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelefon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDatumPodnosenja = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnObrisiCV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUkupanBrojPrijava = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listCVPrijave);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 572);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sve CV prijave";
            // 
            // listCVPrijave
            // 
            this.listCVPrijave.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCvId,
            this.colIme,
            this.colPrezime,
            this.colEmail,
            this.colTelefon,
            this.colDatumPodnosenja,
            this.colStatus,
            this.columnHeader1});
            this.listCVPrijave.FullRowSelect = true;
            this.listCVPrijave.GridLines = true;
            this.listCVPrijave.HideSelection = false;
            this.listCVPrijave.Location = new System.Drawing.Point(6, 19);
            this.listCVPrijave.Name = "listCVPrijave";
            this.listCVPrijave.Size = new System.Drawing.Size(779, 547);
            this.listCVPrijave.TabIndex = 0;
            this.listCVPrijave.UseCompatibleStateImageBehavior = false;
            this.listCVPrijave.View = System.Windows.Forms.View.Details;
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
            this.colDatumPodnosenja.Width = 140;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(832, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "U tabeli su prikazane sve \r\nCV prijave svih oglasa. \r\nBrisanjem CV prijave iz ove" +
    "\r\ntabele bice trajno izbrisana iz sistema.\r\n";
            // 
            // btnObrisiCV
            // 
            this.btnObrisiCV.BackColor = System.Drawing.Color.Turquoise;
            this.btnObrisiCV.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiCV.Location = new System.Drawing.Point(836, 144);
            this.btnObrisiCV.Name = "btnObrisiCV";
            this.btnObrisiCV.Size = new System.Drawing.Size(271, 70);
            this.btnObrisiCV.TabIndex = 7;
            this.btnObrisiCV.Text = "Obrisi CV prijavu";
            this.btnObrisiCV.UseVisualStyleBackColor = false;
            this.btnObrisiCV.Click += new System.EventHandler(this.btnObrisiCV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(874, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ukupan broj CV prijava:";
            // 
            // textBoxUkupanBrojPrijava
            // 
            this.textBoxUkupanBrojPrijava.Location = new System.Drawing.Point(893, 289);
            this.textBoxUkupanBrojPrijava.Name = "textBoxUkupanBrojPrijava";
            this.textBoxUkupanBrojPrijava.Size = new System.Drawing.Size(142, 20);
            this.textBoxUkupanBrojPrijava.TabIndex = 9;
            this.textBoxUkupanBrojPrijava.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Oglas ID";
            // 
            // SveCVPrijaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1129, 650);
            this.Controls.Add(this.textBoxUkupanBrojPrijava);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnObrisiCV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1145, 689);
            this.MinimumSize = new System.Drawing.Size(1145, 689);
            this.Name = "SveCVPrijaveForm";
            this.Text = "CVPrijaveForm";
            this.Load += new System.EventHandler(this.SveCVPrijaveForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listCVPrijave;
        private System.Windows.Forms.ColumnHeader colCvId;
        private System.Windows.Forms.ColumnHeader colIme;
        private System.Windows.Forms.ColumnHeader colPrezime;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colTelefon;
        private System.Windows.Forms.ColumnHeader colDatumPodnosenja;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnObrisiCV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUkupanBrojPrijava;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}