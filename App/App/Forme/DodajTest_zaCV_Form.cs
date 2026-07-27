using App.Entiteti.Enums;
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
    public partial class DodajTest_zaCV_Form : Form
    {
        CVBasic cv;
        TestBasic test;

        public DodajTest_zaCV_Form(CVBasic cv)
        {
            InitializeComponent();
            this.cv = cv;
            this.test = new TestBasic();
        }

        private void btnDodajTest_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da dodate novi Test u CV?";
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

                DTOManager.dodajTest(this.test, this.cv.CvId);

                MessageBox.Show(
                    "Uspesno ste dodali novi test u CV!",
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
