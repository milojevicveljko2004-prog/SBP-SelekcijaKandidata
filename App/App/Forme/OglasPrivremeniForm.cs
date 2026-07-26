using App.Entiteti;
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
    public partial class OglasPrivremeniForm : Form
    {
        OglasBasic oglas;
        OglasPrivremeniBasic oglasPrivremeni;

        public OglasPrivremeniForm(OglasBasic ob)
        {
            InitializeComponent();
            this.oglas = ob;
        }

        private void OglasPrivremeniForm_Load(object sender, EventArgs e)
        {
            this.oglasPrivremeni = DTOManager.vratiOglasPrivremeni(this.oglas.OglasId);

            if (this.oglasPrivremeni == null)
            {
                // Forma je prazna i dugme Sacuvaj dodaje podatke
                this.Text = "DODAVANJE PODATAKA O PRIVREMENOM OGLASU";
            }
            else
            {
                // Popuni polja i dugme Sacuvaj menja podatke
                this.Text = "IZMENA PODATAKA O PRIVREMENOM OGLASU";

                textBoxProjekat.Text = this.oglasPrivremeni.Projekat;
                dateDatumPocetka.Value = this.oglasPrivremeni.DatumPocetka;
                dateDatumZavrsetka.Value = this.oglasPrivremeni.DatumZavrsetka;
            }
        }

        private void btnSacuvajPrivremeni_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da sacuvate privremeni oglas?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //VALIDACIJA
                if (string.IsNullOrWhiteSpace(textBoxProjekat.Text))
                {
                    MessageBox.Show("Ime projekta je obavezno.", "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                //datumi svakako ne mogu da budu prazni, ali proverava se da li je DatumPocetka<DatumZavrsetka
                if (dateDatumPocetka.Value > dateDatumZavrsetka.Value)
                {
                    MessageBox.Show("Datum pocetka mora biti pre datuma zavrsetka!", "Greska",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                if (this.oglasPrivremeni == null)
                {
                    //DODAVANJE
                    OglasPrivremeniBasic noviOglas = new OglasPrivremeniBasic();
                    noviOglas.OglasId = this.oglas.OglasId;
                    noviOglas.Projekat = textBoxProjekat.Text.Trim();
                    noviOglas.DatumPocetka = dateDatumPocetka.Value;
                    noviOglas.DatumZavrsetka = dateDatumZavrsetka.Value;

                    //DTOManager.dodajOglasPrivremeni(noviOglas);
                }
                else
                {
                    //IZMENA
                    this.oglasPrivremeni.Projekat = textBoxProjekat.Text.Trim();
                    this.oglasPrivremeni.DatumPocetka = dateDatumPocetka.Value;
                    this.oglasPrivremeni.DatumZavrsetka = dateDatumZavrsetka.Value;

                    DTOManager.izmeniOglasPrivremeni(this.oglasPrivremeni);
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
