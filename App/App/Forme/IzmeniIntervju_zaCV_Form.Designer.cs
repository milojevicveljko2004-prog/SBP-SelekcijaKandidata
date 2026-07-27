namespace App.Forme
{
    partial class IzmeniIntervju_zaCV_Form
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
            this.btnIzmeniIntervju = new System.Windows.Forms.Button();
            this.numericOcena = new System.Windows.Forms.NumericUpDown();
            this.textBoxImeZaposlenog = new System.Windows.Forms.TextBox();
            this.textBoxPrezimeZaposlenog = new System.Windows.Forms.TextBox();
            this.richTextBoxNapomene = new System.Windows.Forms.RichTextBox();
            this.textBoxLokacija = new System.Windows.Forms.TextBox();
            this.comboBoxTipIntervjua = new System.Windows.Forms.ComboBox();
            this.dateVreme = new System.Windows.Forms.DateTimePicker();
            this.dateDatum = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOcena)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIzmeniIntervju);
            this.groupBox1.Controls.Add(this.numericOcena);
            this.groupBox1.Controls.Add(this.textBoxImeZaposlenog);
            this.groupBox1.Controls.Add(this.textBoxPrezimeZaposlenog);
            this.groupBox1.Controls.Add(this.richTextBoxNapomene);
            this.groupBox1.Controls.Add(this.textBoxLokacija);
            this.groupBox1.Controls.Add(this.comboBoxTipIntervjua);
            this.groupBox1.Controls.Add(this.dateVreme);
            this.groupBox1.Controls.Add(this.dateDatum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 373);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Izmeni intervju za CV";
            // 
            // btnIzmeniIntervju
            // 
            this.btnIzmeniIntervju.BackColor = System.Drawing.Color.Aquamarine;
            this.btnIzmeniIntervju.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzmeniIntervju.Location = new System.Drawing.Point(487, 248);
            this.btnIzmeniIntervju.Name = "btnIzmeniIntervju";
            this.btnIzmeniIntervju.Size = new System.Drawing.Size(181, 57);
            this.btnIzmeniIntervju.TabIndex = 19;
            this.btnIzmeniIntervju.Text = "Izmeni";
            this.btnIzmeniIntervju.UseVisualStyleBackColor = false;
            this.btnIzmeniIntervju.Click += new System.EventHandler(this.btnIzmeniIntervju_Click);
            // 
            // numericOcena
            // 
            this.numericOcena.Location = new System.Drawing.Point(547, 144);
            this.numericOcena.Name = "numericOcena";
            this.numericOcena.Size = new System.Drawing.Size(200, 20);
            this.numericOcena.TabIndex = 15;
            // 
            // textBoxImeZaposlenog
            // 
            this.textBoxImeZaposlenog.Location = new System.Drawing.Point(547, 41);
            this.textBoxImeZaposlenog.Name = "textBoxImeZaposlenog";
            this.textBoxImeZaposlenog.Size = new System.Drawing.Size(200, 20);
            this.textBoxImeZaposlenog.TabIndex = 14;
            // 
            // textBoxPrezimeZaposlenog
            // 
            this.textBoxPrezimeZaposlenog.Location = new System.Drawing.Point(547, 94);
            this.textBoxPrezimeZaposlenog.Name = "textBoxPrezimeZaposlenog";
            this.textBoxPrezimeZaposlenog.Size = new System.Drawing.Size(200, 20);
            this.textBoxPrezimeZaposlenog.TabIndex = 13;
            // 
            // richTextBoxNapomene
            // 
            this.richTextBoxNapomene.Location = new System.Drawing.Point(142, 248);
            this.richTextBoxNapomene.Name = "richTextBoxNapomene";
            this.richTextBoxNapomene.Size = new System.Drawing.Size(200, 96);
            this.richTextBoxNapomene.TabIndex = 12;
            this.richTextBoxNapomene.Text = "";
            // 
            // textBoxLokacija
            // 
            this.textBoxLokacija.Location = new System.Drawing.Point(142, 190);
            this.textBoxLokacija.Name = "textBoxLokacija";
            this.textBoxLokacija.Size = new System.Drawing.Size(200, 20);
            this.textBoxLokacija.TabIndex = 11;
            // 
            // comboBoxTipIntervjua
            // 
            this.comboBoxTipIntervjua.FormattingEnabled = true;
            this.comboBoxTipIntervjua.Items.AddRange(new object[] {
            "LICNI",
            "VIDEO",
            "TELEFONSKI"});
            this.comboBoxTipIntervjua.Location = new System.Drawing.Point(142, 136);
            this.comboBoxTipIntervjua.Name = "comboBoxTipIntervjua";
            this.comboBoxTipIntervjua.Size = new System.Drawing.Size(200, 21);
            this.comboBoxTipIntervjua.TabIndex = 10;
            // 
            // dateVreme
            // 
            this.dateVreme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateVreme.Location = new System.Drawing.Point(142, 88);
            this.dateVreme.Name = "dateVreme";
            this.dateVreme.Size = new System.Drawing.Size(200, 20);
            this.dateVreme.TabIndex = 9;
            // 
            // dateDatum
            // 
            this.dateDatum.Location = new System.Drawing.Point(142, 41);
            this.dateDatum.Name = "dateDatum";
            this.dateDatum.Size = new System.Drawing.Size(200, 20);
            this.dateDatum.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Napomene:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ocena:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Prezime zaposlenog:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ime zaposlenog:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lokacija:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tip intervjua:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vreme:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum:";
            // 
            // IzmeniIntervju_zaCV_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(822, 402);
            this.Controls.Add(this.groupBox1);
            this.Name = "IzmeniIntervju_zaCV_Form";
            this.Text = "IzmeniIntervju_zaCV_Form";
            this.Load += new System.EventHandler(this.IzmeniIntervju_zaCV_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOcena)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIzmeniIntervju;
        private System.Windows.Forms.NumericUpDown numericOcena;
        private System.Windows.Forms.TextBox textBoxImeZaposlenog;
        private System.Windows.Forms.TextBox textBoxPrezimeZaposlenog;
        private System.Windows.Forms.RichTextBox richTextBoxNapomene;
        private System.Windows.Forms.TextBox textBoxLokacija;
        private System.Windows.Forms.ComboBox comboBoxTipIntervjua;
        private System.Windows.Forms.DateTimePicker dateVreme;
        private System.Windows.Forms.DateTimePicker dateDatum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}