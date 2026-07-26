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
    public partial class OglasPraksaForm : Form
    {
        OglasBasic oglas;
        OglasPraksaBasic oglasPraksa;

        public OglasPraksaForm(OglasBasic ob)
        {
            InitializeComponent();
            this.oglas = ob;
        }

        private void OglasPraksaForm_Load(object sender, EventArgs e)
        {
            this.oglasPraksa = DTOManager.vratiOglasPrakse(this.oglas.OglasId);

            if (this.oglasPraksa == null)
            {
                // Forma je prazna i dugme Sacuvaj dodaje podatke
                this.Text = "DODAVANJE PODATAKA O PRAKSI";
            }
            else
            {
                // Popuni polja i dugme Sacuvaj menja podatke
                this.Text = "IZMENA PODATAKA O PRAKSI";

                textBoxMentorIme.Text = this.oglasPraksa.MentorIme;
                textBoxMentorPrezime.Text = this.oglasPraksa.MentorPrezime;
                numericDuzinaTrajanja.Value = this.oglasPraksa.DuzinaTrajanja;
            }
        }

        private void btnSacuvajPraksu_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da sacuvate oglas prakse?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //VALIDACIJA
                if (string.IsNullOrWhiteSpace(textBoxMentorIme.Text) ||
                    string.IsNullOrWhiteSpace(textBoxMentorPrezime.Text))
                {
                    MessageBox.Show("Ime i prezime mentora su obavezni.", "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (this.oglasPraksa == null)
                {
                    //DODAVANJE
                    OglasPraksaBasic novaPraksa = new OglasPraksaBasic();
                    novaPraksa.OglasId = this.oglas.OglasId;
                    novaPraksa.MentorIme = textBoxMentorIme.Text.Trim();
                    novaPraksa.MentorPrezime = textBoxMentorPrezime.Text.Trim();
                    novaPraksa.DuzinaTrajanja = (int)numericDuzinaTrajanja.Value;

                    //DTOManager.dodajOglasPraksu(novaPraksa);
                }
                else
                {
                    //IZMENA
                    this.oglasPraksa.MentorIme = textBoxMentorIme.Text.Trim();
                    this.oglasPraksa.MentorPrezime = textBoxMentorPrezime.Text.Trim();
                    this.oglasPraksa.DuzinaTrajanja = (int)numericDuzinaTrajanja.Value;

                    DTOManager.izmeniOglasPraksu(this.oglasPraksa);
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
