using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forme
{
    public partial class IzmeniTest_zaCV_Form : Form
    {
        TestBasic test;
        CVBasic cv;

        public IzmeniTest_zaCV_Form(TestBasic test, CVBasic cv)
        {
            InitializeComponent();
            this.test = test;
            this.cv = cv;
        }

        private void IzmeniTest_zaCV_Form_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = "IZMENA TESTA ZA CV sa ID = " + this.cv.CvId;
        }

        public void popuniPodacima()
        {
            numericRezultat.Value = this.test.Rezultat;
            dateDatumTestiranja.Value = this.test.DatumTestiranja;
            textBoxVrstaTestiranja.Text = this.test.VrstaTestiranja;
            richTextBoxKomentar.Text = this.test.Komentar;
        }

        private void btnIzmenitest_Click(object sender, EventArgs e)
        {
            string poruka = $"Da li zelite da izmenite test {this.test.VrstaTestiranja}?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //VALIDACIJA
                if (string.IsNullOrWhiteSpace(textBoxVrstaTestiranja.Text))
                {
                    MessageBox.Show(
                            "Vrsta testiranja je obavezno polje!",
                            "Nedostaju podaci",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                    return;
                }

                if (numericRezultat.Value < 0 || numericRezultat.Value > 100)
                {
                    MessageBox.Show(
                            "Rezultat mora biti izmedju 1 i 100.",
                            "Greska",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                    return;
                }

                this.test.Rezultat = numericRezultat.Value;
                this.test.DatumTestiranja = dateDatumTestiranja.Value;
                this.test.VrstaTestiranja = textBoxVrstaTestiranja.Text.Trim();
                this.test.Komentar = richTextBoxKomentar.Text.Trim();

                DTOManager.izmeniTest(this.test);

                MessageBox.Show(
                    $"Uspesno ste dodali izmenili test sa ID={this.test.TestId}!",
                    "Uspesno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {

            }
        }
    }
}
