namespace App.Forme
{
    partial class DodajTest_zaCV_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericRezultat = new System.Windows.Forms.NumericUpDown();
            this.dateDatumTestiranja = new System.Windows.Forms.DateTimePicker();
            this.textBoxVrstaTestiranja = new System.Windows.Forms.TextBox();
            this.richTextBoxKomentar = new System.Windows.Forms.RichTextBox();
            this.btnDodajTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRezultat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDodajTest);
            this.groupBox1.Controls.Add(this.richTextBoxKomentar);
            this.groupBox1.Controls.Add(this.textBoxVrstaTestiranja);
            this.groupBox1.Controls.Add(this.dateDatumTestiranja);
            this.groupBox1.Controls.Add(this.numericRezultat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 357);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dodavanje testa za CV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rezultat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum testiranja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vrsta testiranja:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Komentar:";
            // 
            // numericRezultat
            // 
            this.numericRezultat.DecimalPlaces = 2;
            this.numericRezultat.Location = new System.Drawing.Point(138, 37);
            this.numericRezultat.Name = "numericRezultat";
            this.numericRezultat.Size = new System.Drawing.Size(200, 20);
            this.numericRezultat.TabIndex = 4;
            // 
            // dateDatumTestiranja
            // 
            this.dateDatumTestiranja.Location = new System.Drawing.Point(138, 81);
            this.dateDatumTestiranja.Name = "dateDatumTestiranja";
            this.dateDatumTestiranja.Size = new System.Drawing.Size(200, 20);
            this.dateDatumTestiranja.TabIndex = 5;
            // 
            // textBoxVrstaTestiranja
            // 
            this.textBoxVrstaTestiranja.Location = new System.Drawing.Point(138, 131);
            this.textBoxVrstaTestiranja.Name = "textBoxVrstaTestiranja";
            this.textBoxVrstaTestiranja.Size = new System.Drawing.Size(200, 20);
            this.textBoxVrstaTestiranja.TabIndex = 6;
            // 
            // richTextBoxKomentar
            // 
            this.richTextBoxKomentar.Location = new System.Drawing.Point(138, 180);
            this.richTextBoxKomentar.Name = "richTextBoxKomentar";
            this.richTextBoxKomentar.Size = new System.Drawing.Size(200, 76);
            this.richTextBoxKomentar.TabIndex = 7;
            this.richTextBoxKomentar.Text = "";
            // 
            // btnDodajTest
            // 
            this.btnDodajTest.BackColor = System.Drawing.Color.Aquamarine;
            this.btnDodajTest.Font = new System.Drawing.Font("Georgia", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodajTest.Location = new System.Drawing.Point(107, 289);
            this.btnDodajTest.Name = "btnDodajTest";
            this.btnDodajTest.Size = new System.Drawing.Size(170, 41);
            this.btnDodajTest.TabIndex = 27;
            this.btnDodajTest.Text = "Dodaj";
            this.btnDodajTest.UseVisualStyleBackColor = false;
            this.btnDodajTest.Click += new System.EventHandler(this.btnDodajTest_Click);
            // 
            // DodajTest_zaCV_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(431, 389);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(447, 428);
            this.MinimumSize = new System.Drawing.Size(447, 428);
            this.Name = "DodajTest_zaCV_Form";
            this.Text = "DodajTest_zaCV_Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRezultat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericRezultat;
        private System.Windows.Forms.RichTextBox richTextBoxKomentar;
        private System.Windows.Forms.TextBox textBoxVrstaTestiranja;
        private System.Windows.Forms.DateTimePicker dateDatumTestiranja;
        private System.Windows.Forms.Button btnDodajTest;
    }
}