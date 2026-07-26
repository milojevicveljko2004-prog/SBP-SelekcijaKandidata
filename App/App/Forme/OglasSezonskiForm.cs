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
    public partial class OglasSezonskiForm : Form
    {
        OglasBasic oglas;
        OglasSezonskiBasic oglasSezonski;

        public OglasSezonskiForm(OglasBasic ob)
        {
            InitializeComponent();
            this.oglas = ob;
        }

        private void OglasSezonskiForm_Load(object sender, EventArgs e)
        {
            this.oglasSezonski = DTOManager.vratiOglasSezonski(this.oglas.OglasId);

            if (this.oglasSezonski == null)
            {
                // Forma je prazna i dugme Sacuvaj dodaje podatke
                this.Text = "DODAVANJE PODATAKA O SEZONSKOM OGLASU";
            }
            else
            {
                // Popuni polja i dugme Sacuvaj menja podatke
                this.Text = "IZMENA PODATAKA O SEZONSKOM OGLASU";

                textBoxSezona.Text = this.oglasSezonski.Sezona;
                textBoxLokacija.Text = this.oglasSezonski.Lokacija;
            }
        }

        private void btnSacuvajSezonski_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da sacuvate sezonski oglas?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //VALIDACIJA
                if (string.IsNullOrWhiteSpace(textBoxSezona.Text) ||
                    string.IsNullOrWhiteSpace(textBoxLokacija.Text))
                {
                    MessageBox.Show("Sezona i lokacija su obavezni.", "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (this.oglasSezonski == null)
                {
                    //DODAVANJE
                    OglasSezonskiBasic noviOglas = new OglasSezonskiBasic();
                    noviOglas.OglasId = this.oglas.OglasId;
                    noviOglas.Sezona = textBoxSezona.Text.Trim();
                    noviOglas.Lokacija = textBoxLokacija.Text.Trim();

                    //DTOManager.dodajOglasSezonski(noviOglas);
                }
                else
                {
                    //IZMENA
                    this.oglasSezonski.Sezona = textBoxSezona.Text.Trim();
                    this.oglasSezonski.Lokacija = textBoxLokacija.Text.Trim();

                    DTOManager.izmeniOglasSezonski(this.oglasSezonski);
                }

                MessageBox.Show("Podaci su uspesno sacuvani.", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            //samo zatvaranje forme
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
