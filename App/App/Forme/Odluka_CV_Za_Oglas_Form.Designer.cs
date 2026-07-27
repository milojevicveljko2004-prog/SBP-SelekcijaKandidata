namespace App.Forme
{
    partial class Odluka_CV_Za_Oglas_Form
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
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxNe = new System.Windows.Forms.CheckBox();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.btnSacuvajOdluku = new System.Windows.Forms.Button();
            this.richTextBoxRazlogOdbijanja = new System.Windows.Forms.RichTextBox();
            this.dateDatumPocetkaRada = new System.Windows.Forms.DateTimePicker();
            this.checkBoxDa = new System.Windows.Forms.CheckBox();
            this.numericPonudjenaPlata = new System.Windows.Forms.NumericUpDown();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPonudjenaPlata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBoxNe);
            this.groupBox1.Controls.Add(this.btnOtkazi);
            this.groupBox1.Controls.Add(this.btnSacuvajOdluku);
            this.groupBox1.Controls.Add(this.richTextBoxRazlogOdbijanja);
            this.groupBox1.Controls.Add(this.dateDatumPocetkaRada);
            this.groupBox1.Controls.Add(this.checkBoxDa);
            this.groupBox1.Controls.Add(this.numericPonudjenaPlata);
            this.groupBox1.Controls.Add(this.comboBoxStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 443);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odluka za CV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ponuda je prihvacena:";
            // 
            // checkBoxNe
            // 
            this.checkBoxNe.AutoSize = true;
            this.checkBoxNe.Location = new System.Drawing.Point(250, 139);
            this.checkBoxNe.Name = "checkBoxNe";
            this.checkBoxNe.Size = new System.Drawing.Size(40, 17);
            this.checkBoxNe.TabIndex = 14;
            this.checkBoxNe.Text = "Ne";
            this.checkBoxNe.UseVisualStyleBackColor = true;
            this.checkBoxNe.CheckedChanged += new System.EventHandler(this.checkBoxNe_CheckedChanged);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.BackColor = System.Drawing.Color.Turquoise;
            this.btnOtkazi.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtkazi.Location = new System.Drawing.Point(250, 371);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(135, 47);
            this.btnOtkazi.TabIndex = 13;
            this.btnOtkazi.Text = "Otkazi";
            this.btnOtkazi.UseVisualStyleBackColor = false;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // btnSacuvajOdluku
            // 
            this.btnSacuvajOdluku.BackColor = System.Drawing.Color.Turquoise;
            this.btnSacuvajOdluku.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajOdluku.Location = new System.Drawing.Point(61, 371);
            this.btnSacuvajOdluku.Name = "btnSacuvajOdluku";
            this.btnSacuvajOdluku.Size = new System.Drawing.Size(135, 47);
            this.btnSacuvajOdluku.TabIndex = 12;
            this.btnSacuvajOdluku.Text = "Sacuvaj";
            this.btnSacuvajOdluku.UseVisualStyleBackColor = false;
            this.btnSacuvajOdluku.Click += new System.EventHandler(this.btnSacuvajOdluku_Click);
            // 
            // richTextBoxRazlogOdbijanja
            // 
            this.richTextBoxRazlogOdbijanja.Location = new System.Drawing.Point(185, 241);
            this.richTextBoxRazlogOdbijanja.Name = "richTextBoxRazlogOdbijanja";
            this.richTextBoxRazlogOdbijanja.Size = new System.Drawing.Size(200, 96);
            this.richTextBoxRazlogOdbijanja.TabIndex = 11;
            this.richTextBoxRazlogOdbijanja.Text = "";
            // 
            // dateDatumPocetkaRada
            // 
            this.dateDatumPocetkaRada.Location = new System.Drawing.Point(185, 185);
            this.dateDatumPocetkaRada.Name = "dateDatumPocetkaRada";
            this.dateDatumPocetkaRada.Size = new System.Drawing.Size(200, 20);
            this.dateDatumPocetkaRada.TabIndex = 10;
            // 
            // checkBoxDa
            // 
            this.checkBoxDa.AutoSize = true;
            this.checkBoxDa.Location = new System.Drawing.Point(185, 139);
            this.checkBoxDa.Name = "checkBoxDa";
            this.checkBoxDa.Size = new System.Drawing.Size(40, 17);
            this.checkBoxDa.TabIndex = 9;
            this.checkBoxDa.Text = "Da";
            this.checkBoxDa.UseVisualStyleBackColor = true;
            this.checkBoxDa.CheckedChanged += new System.EventHandler(this.checkBoxDa_CheckedChanged);
            // 
            // numericPonudjenaPlata
            // 
            this.numericPonudjenaPlata.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPonudjenaPlata.Location = new System.Drawing.Point(185, 88);
            this.numericPonudjenaPlata.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericPonudjenaPlata.Name = "numericPonudjenaPlata";
            this.numericPonudjenaPlata.Size = new System.Drawing.Size(200, 20);
            this.numericPonudjenaPlata.TabIndex = 8;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(185, 34);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(200, 21);
            this.comboBoxStatus.TabIndex = 6;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Razlog odbijanja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Datum pocetka rada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ponudjena plata:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status odluke:";
            // 
            // Odluka_CV_Za_Oglas_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(489, 474);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(505, 513);
            this.MinimumSize = new System.Drawing.Size(505, 513);
            this.Name = "Odluka_CV_Za_Oglas_Form";
            this.Text = "Odluka_CV_Za_Oglas_Form";
            this.Load += new System.EventHandler(this.Odluka_CV_Za_Oglas_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPonudjenaPlata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox richTextBoxRazlogOdbijanja;
        private System.Windows.Forms.DateTimePicker dateDatumPocetkaRada;
        private System.Windows.Forms.CheckBox checkBoxDa;
        private System.Windows.Forms.NumericUpDown numericPonudjenaPlata;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnSacuvajOdluku;
        private System.Windows.Forms.CheckBox checkBoxNe;
        private System.Windows.Forms.Label label4;
    }
}