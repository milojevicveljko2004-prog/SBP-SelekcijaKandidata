namespace App.Forme
{
    partial class IntervjuiForm
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
            this.listIntervjui = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnObrisiOglas = new System.Windows.Forms.Button();
            this.btnIzmeniOglas = new System.Windows.Forms.Button();
            this.btnDodajOglas = new System.Windows.Forms.Button();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listIntervjui);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 402);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intervjui za CV";
            // 
            // listIntervjui
            // 
            this.listIntervjui.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10});
            this.listIntervjui.FullRowSelect = true;
            this.listIntervjui.GridLines = true;
            this.listIntervjui.HideSelection = false;
            this.listIntervjui.Location = new System.Drawing.Point(6, 19);
            this.listIntervjui.Name = "listIntervjui";
            this.listIntervjui.Size = new System.Drawing.Size(959, 377);
            this.listIntervjui.TabIndex = 0;
            this.listIntervjui.UseCompatibleStateImageBehavior = false;
            this.listIntervjui.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Datum";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Vreme";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tip intervjua";
            this.columnHeader4.Width = 105;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Lokacija";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ime zaposlenog";
            this.columnHeader5.Width = 105;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PrezimeZaposlenog";
            this.columnHeader6.Width = 125;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ocena";
            this.columnHeader7.Width = 55;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Napomene";
            this.columnHeader8.Width = 200;
            // 
            // btnObrisiOglas
            // 
            this.btnObrisiOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnObrisiOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiOglas.Location = new System.Drawing.Point(1002, 199);
            this.btnObrisiOglas.Name = "btnObrisiOglas";
            this.btnObrisiOglas.Size = new System.Drawing.Size(175, 46);
            this.btnObrisiOglas.TabIndex = 5;
            this.btnObrisiOglas.Text = "Obrisi intervju";
            this.btnObrisiOglas.UseVisualStyleBackColor = false;
            this.btnObrisiOglas.Click += new System.EventHandler(this.btnObrisiOglas_Click);
            // 
            // btnIzmeniOglas
            // 
            this.btnIzmeniOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnIzmeniOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniOglas.Location = new System.Drawing.Point(1002, 133);
            this.btnIzmeniOglas.Name = "btnIzmeniOglas";
            this.btnIzmeniOglas.Size = new System.Drawing.Size(175, 46);
            this.btnIzmeniOglas.TabIndex = 4;
            this.btnIzmeniOglas.Text = "Izmeni intervju";
            this.btnIzmeniOglas.UseVisualStyleBackColor = false;
            this.btnIzmeniOglas.Click += new System.EventHandler(this.btnIzmeniOglas_Click);
            // 
            // btnDodajOglas
            // 
            this.btnDodajOglas.BackColor = System.Drawing.Color.Turquoise;
            this.btnDodajOglas.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajOglas.Location = new System.Drawing.Point(1002, 66);
            this.btnDodajOglas.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajOglas.Name = "btnDodajOglas";
            this.btnDodajOglas.Size = new System.Drawing.Size(175, 46);
            this.btnDodajOglas.TabIndex = 3;
            this.btnDodajOglas.Text = "Dodaj intervju";
            this.btnDodajOglas.UseVisualStyleBackColor = false;
            this.btnDodajOglas.Click += new System.EventHandler(this.btnDodajOglas_Click);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "CV ID";
            this.columnHeader10.Width = 45;
            // 
            // IntervjuiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(1192, 426);
            this.Controls.Add(this.btnObrisiOglas);
            this.Controls.Add(this.btnIzmeniOglas);
            this.Controls.Add(this.btnDodajOglas);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(1208, 465);
            this.MinimumSize = new System.Drawing.Size(1208, 465);
            this.Name = "IntervjuiForm";
            this.Text = "Intervjui_CV_Za_Oglas";
            this.Load += new System.EventHandler(this.Intervjui_CV_Za_Oglas_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listIntervjui;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnObrisiOglas;
        private System.Windows.Forms.Button btnIzmeniOglas;
        private System.Windows.Forms.Button btnDodajOglas;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}