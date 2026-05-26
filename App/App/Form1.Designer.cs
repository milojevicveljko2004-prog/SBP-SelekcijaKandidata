namespace App
{
    partial class Form1
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
            this.UcitavanjePodatakaOOglasu = new System.Windows.Forms.Button();
            this.DodavanjeNovogOglasa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UcitavanjePodatakaOOglasu
            // 
            this.UcitavanjePodatakaOOglasu.Location = new System.Drawing.Point(54, 28);
            this.UcitavanjePodatakaOOglasu.Name = "UcitavanjePodatakaOOglasu";
            this.UcitavanjePodatakaOOglasu.Size = new System.Drawing.Size(208, 40);
            this.UcitavanjePodatakaOOglasu.TabIndex = 0;
            this.UcitavanjePodatakaOOglasu.Text = "Ucitavanje podatka o oglasu";
            this.UcitavanjePodatakaOOglasu.UseVisualStyleBackColor = true;
            this.UcitavanjePodatakaOOglasu.Click += new System.EventHandler(this.cmdUcitavanjeOglasa_Click);
            // 
            // DodavanjeNovogOglasa
            // 
            this.DodavanjeNovogOglasa.Location = new System.Drawing.Point(54, 92);
            this.DodavanjeNovogOglasa.Name = "DodavanjeNovogOglasa";
            this.DodavanjeNovogOglasa.Size = new System.Drawing.Size(208, 38);
            this.DodavanjeNovogOglasa.TabIndex = 1;
            this.DodavanjeNovogOglasa.Text = "Dodavanje novog oglasa";
            this.DodavanjeNovogOglasa.UseVisualStyleBackColor = true;
            this.DodavanjeNovogOglasa.Click += new System.EventHandler(this.DodavanjeNovogOglasa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DodavanjeNovogOglasa);
            this.Controls.Add(this.UcitavanjePodatakaOOglasu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UcitavanjePodatakaOOglasu;
        private System.Windows.Forms.Button DodavanjeNovogOglasa;
    }
}

