namespace App.Forme
{
    partial class Testovi_CV_ZaOglas_Form
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
            this.listTestovi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnObrisiTest = new System.Windows.Forms.Button();
            this.btnIzmeniTest = new System.Windows.Forms.Button();
            this.btnDodajTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listTestovi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(609, 402);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Testovi za CV";
            // 
            // listTestovi
            // 
            this.listTestovi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9});
            this.listTestovi.FullRowSelect = true;
            this.listTestovi.GridLines = true;
            this.listTestovi.HideSelection = false;
            this.listTestovi.Location = new System.Drawing.Point(6, 19);
            this.listTestovi.Name = "listTestovi";
            this.listTestovi.Size = new System.Drawing.Size(595, 377);
            this.listTestovi.TabIndex = 0;
            this.listTestovi.UseCompatibleStateImageBehavior = false;
            this.listTestovi.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rezultat";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Datum testiranja";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Vrsta testiranja";
            this.columnHeader4.Width = 145;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Komentar";
            this.columnHeader9.Width = 230;
            // 
            // btnObrisiTest
            // 
            this.btnObrisiTest.BackColor = System.Drawing.Color.Turquoise;
            this.btnObrisiTest.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObrisiTest.Location = new System.Drawing.Point(648, 178);
            this.btnObrisiTest.Name = "btnObrisiTest";
            this.btnObrisiTest.Size = new System.Drawing.Size(175, 46);
            this.btnObrisiTest.TabIndex = 8;
            this.btnObrisiTest.Text = "Obrisi test";
            this.btnObrisiTest.UseVisualStyleBackColor = false;
            this.btnObrisiTest.Click += new System.EventHandler(this.btnObrisiTest_Click);
            // 
            // btnIzmeniTest
            // 
            this.btnIzmeniTest.BackColor = System.Drawing.Color.Turquoise;
            this.btnIzmeniTest.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniTest.Location = new System.Drawing.Point(648, 112);
            this.btnIzmeniTest.Name = "btnIzmeniTest";
            this.btnIzmeniTest.Size = new System.Drawing.Size(175, 46);
            this.btnIzmeniTest.TabIndex = 7;
            this.btnIzmeniTest.Text = "Izmeni test";
            this.btnIzmeniTest.UseVisualStyleBackColor = false;
            this.btnIzmeniTest.Click += new System.EventHandler(this.btnIzmeniTest_Click);
            // 
            // btnDodajTest
            // 
            this.btnDodajTest.BackColor = System.Drawing.Color.Turquoise;
            this.btnDodajTest.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajTest.Location = new System.Drawing.Point(648, 45);
            this.btnDodajTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnDodajTest.Name = "btnDodajTest";
            this.btnDodajTest.Size = new System.Drawing.Size(175, 46);
            this.btnDodajTest.TabIndex = 6;
            this.btnDodajTest.Text = "Dodaj test";
            this.btnDodajTest.UseVisualStyleBackColor = false;
            this.btnDodajTest.Click += new System.EventHandler(this.btnDodajTest_Click);
            // 
            // Testovi_CV_ZaOglas_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(854, 429);
            this.Controls.Add(this.btnObrisiTest);
            this.Controls.Add(this.btnIzmeniTest);
            this.Controls.Add(this.btnDodajTest);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(870, 468);
            this.MinimumSize = new System.Drawing.Size(870, 468);
            this.Name = "Testovi_CV_ZaOglas_Form";
            this.Text = "Testovi_CV_ZaOglas_Form";
            this.Load += new System.EventHandler(this.Testovi_CV_ZaOglas_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listTestovi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnObrisiTest;
        private System.Windows.Forms.Button btnIzmeniTest;
        private System.Windows.Forms.Button btnDodajTest;
    }
}