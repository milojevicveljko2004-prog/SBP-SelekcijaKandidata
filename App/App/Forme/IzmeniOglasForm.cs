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
    public partial class IzmeniOglasForm : Form
    {
        public OglasBasic oglas;
        public IzmeniOglasForm(OglasBasic ob)
        {
            InitializeComponent();
            this.oglas = ob;
        }

        private void IzmeniOglasForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = $"AZURIRANJE OGLASA {oglas.NazivPozicije.ToUpper()}";
        }

        public void popuniPodacima()
        {
            textBoxNazivPozicije.Text = oglas.NazivPozicije;
            textBoxVrstaOglasa.Text = oglas.VrstaOglasa.ToString();
            textBoxOpis.Text = oglas.Opis;
            textBoxZahtevi.Text = oglas.Zahtevi;
            textBoxMinPlata.Text = oglas.MinPlata?.ToString() ?? "";
            textBoxMaxPlata.Text = oglas.MaxPlata?.ToString() ?? "";
            textBoxDatumZatvaranja.Text = oglas.DatumZatvaranja?.ToString() ?? "";
            textBoxStatus.Text = oglas.Status.ToString();
        }

        private void btnIzmeniOglas_Click(object sender, EventArgs e)
        {
            string poruka = "Da li zelite da izvrsite izmenu oglasa?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                decimal? minPlata = null;
                decimal? maxPlata = null;
                DateTime? datumZatvaranja = null;

                //Minimalna plata
                if (!string.IsNullOrWhiteSpace(textBoxMinPlata.Text))
                {
                    decimal min;

                    if (!decimal.TryParse(textBoxMinPlata.Text, out min))
                    {
                        MessageBox.Show(
                            "Minimalna plata mora biti ispravan broj.",
                            "Neispravan unos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        textBoxMinPlata.Focus();
                        return;
                    }

                    minPlata = min;
                }

                // Maksimalna plata
                if (!string.IsNullOrWhiteSpace(textBoxMaxPlata.Text))
                {
                    decimal max;

                    if (!decimal.TryParse(textBoxMaxPlata.Text, out max))
                    {
                        MessageBox.Show(
                            "Maksimalna plata mora biti ispravan broj.",
                            "Neispravan unos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        textBoxMaxPlata.Focus();
                        return;
                    }

                    maxPlata = max;
                }

                // Datum zatvaranja
                if (!string.IsNullOrWhiteSpace(textBoxDatumZatvaranja.Text))
                {
                    DateTime datum;

                    if (!DateTime.TryParse(textBoxDatumZatvaranja.Text, out datum))
                    {
                        MessageBox.Show(
                            "Datum zatvaranja nije u ispravnom formatu.",
                            "Neispravan unos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        textBoxDatumZatvaranja.Focus();
                        return;
                    }

                    datumZatvaranja = datum;
                }

                // Dodatna logicka provera
                if (minPlata.HasValue &&
                    maxPlata.HasValue &&
                    minPlata.Value > maxPlata.Value)
                {
                    MessageBox.Show(
                        "Minimalna plata ne moze biti veca od maksimalne plate.",
                        "Neispravan unos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // NOT NULL polja ne smeju da budu prazna
                if (string.IsNullOrWhiteSpace(textBoxNazivPozicije.Text) ||
                    string.IsNullOrWhiteSpace(textBoxVrstaOglasa.Text) ||
                    string.IsNullOrWhiteSpace(textBoxStatus.Text))
                {
                    MessageBox.Show(
                        "Naziv pozicije, vrsta oglasa i status su obavezni.",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                this.oglas.NazivPozicije = textBoxNazivPozicije.Text.Trim();
                this.oglas.VrstaOglasa = (VrstaOglasa)Enum.Parse(typeof(VrstaOglasa), textBoxVrstaOglasa.Text.Trim());

                this.oglas.Opis = string.IsNullOrWhiteSpace(textBoxOpis.Text)
                    ? null
                    : textBoxOpis.Text.Trim();

                this.oglas.Zahtevi = string.IsNullOrWhiteSpace(textBoxZahtevi.Text)
                    ? null
                    : textBoxZahtevi.Text.Trim();

                this.oglas.MinPlata = minPlata;
                this.oglas.MaxPlata = maxPlata;
                this.oglas.DatumZatvaranja = datumZatvaranja;
                this.oglas.DatumObjave = DateTime.Now;
                this.oglas.Status = (StatusOglasa)Enum.Parse(typeof(StatusOglasa), textBoxStatus.Text.Trim());

                DTOManager.izmeniOglas(this.oglas);

                MessageBox.Show(
                    $"Uspesno ste izmenili oglas sa ID={this.oglas.OglasId}!",
                    "Uspesno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                //nista se ne desi, korisnik je kliknuo Cancel
            }
        }
    }
}
