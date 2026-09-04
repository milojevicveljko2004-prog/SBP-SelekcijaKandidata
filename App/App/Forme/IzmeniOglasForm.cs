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
        private VrstaOglasa staraVrsta;

        public IzmeniOglasForm(OglasBasic ob)
        {
            InitializeComponent();
            this.oglas = ob; //ovde this.oglas sadrzi samo osnovne podatke i id

            //zabranjuje korisniku da pise u select polje
            vrstaOglasaBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusOglasaBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //izvlacenje vrednosti iz enuma da bi se kasnije lakse cast-ovalo
            vrstaOglasaBox.DataSource = Enum.GetValues(typeof(VrstaOglasa));
            statusOglasaBox.DataSource = Enum.GetValues(typeof(StatusOglasa));

            //dodaje se checkBox da bi se znalo da li je datum null. Ako nije cekirano onda je null.
            date_datumZatvaranja.ShowCheckBox = true;

            //sakrivanje dodatnih polja
            groupBoxPrivremeni.Visible = false;
            groupBoxPraksa.Visible = false;
            groupBoxSezonski.Visible = false;
        }

        private void IzmeniOglasForm_Load(object sender, EventArgs e)
        {
            this.oglas = DTOManager.vratiOglas(this.oglas.OglasId); //ovde dobija dodatne podatke

            if (this.oglas == null)
            {
                MessageBox.Show("Oglas nije pronađen.");
                Close();
                return;
            }

            //Pamti se vrsta koja trenutno postoji u bazi
            this.staraVrsta = this.oglas.VrstaOglasa;

            this.Text = $"AZURIRANJE OGLASA {oglas.NazivPozicije.ToUpper()}";

            popuniPodacima();
            popuniPosebneKontrole();
            prikaziOdgovarajucaPolja(this.oglas.VrstaOglasa);
        }

        public void popuniPodacima()
        {
            textBoxNazivPozicije.Text = oglas.NazivPozicije;
            vrstaOglasaBox.Text = oglas.VrstaOglasa.ToString();
            richTextBoxOpis.Text = oglas.Opis;
            richTextBoxZahtevi.Text = oglas.Zahtevi;
            numericUpDown2.Text = oglas.MinPlata?.ToString() ?? "";
            numericUpDown1.Text = oglas.MaxPlata?.ToString() ?? "";
            date_datumZatvaranja.Text = oglas.DatumZatvaranja?.ToString() ?? "";
            statusOglasaBox.Text = oglas.Status.ToString();
        }

        private void popuniPosebneKontrole()
        {
            if (this.oglas is OglasPraksaBasic praksa)
            {
                textBoxMentorIme.Text = praksa.MentorIme;
                textBoxMentorPrezime.Text = praksa.MentorPrezime;
                numericDuzinaTrajanja.Value = praksa.DuzinaTrajanja;
            }
            else if (this.oglas is OglasPrivremeniBasic privremeni)
            {
                textBoxProjekat.Text = privremeni.Projekat;
                dateDatumPocetka.Value = privremeni.DatumPocetka;
                dateDatumZavrsetka.Value = privremeni.DatumZavrsetka;
            }
            else if (this.oglas is OglasSezonskiBasic sezonski)
            {
                textBoxSezona.Text = sezonski.Sezona;
                textBoxLokacija.Text = sezonski.Lokacija;
            }
        }

        private bool popuniPosebnePodatke()
        {
            if (this.oglas is OglasPraksaBasic praksa)
            {
                if (string.IsNullOrWhiteSpace(textBoxMentorIme.Text) ||
                    string.IsNullOrWhiteSpace(textBoxMentorPrezime.Text))
                {
                    MessageBox.Show(
                        "Ime i prezime mentora su obavezni.",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (numericDuzinaTrajanja.Value <= 0)
                {
                    MessageBox.Show(
                        "Dužina trajanja mora biti veća od nule.",
                        "Neispravan unos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                praksa.MentorIme = textBoxMentorIme.Text.Trim();
                praksa.MentorPrezime = textBoxMentorPrezime.Text.Trim();
                praksa.DuzinaTrajanja = (int)numericDuzinaTrajanja.Value;
            }
            else if (this.oglas is OglasPrivremeniBasic privremeni)
            {
                if (string.IsNullOrWhiteSpace(textBoxProjekat.Text))
                {
                    MessageBox.Show(
                        "Naziv projekta je obavezan.",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (dateDatumPocetka.Value.Date >
                    dateDatumZavrsetka.Value.Date)
                {
                    MessageBox.Show(
                        "Datum početka ne može biti posle datuma završetka.",
                        "Neispravan period",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                privremeni.Projekat = textBoxProjekat.Text.Trim();
                privremeni.DatumPocetka = dateDatumPocetka.Value.Date;
                privremeni.DatumZavrsetka = dateDatumZavrsetka.Value.Date;
            }
            else if (this.oglas is OglasSezonskiBasic sezonski)
            {
                if (string.IsNullOrWhiteSpace(textBoxSezona.Text) ||
                    string.IsNullOrWhiteSpace(textBoxLokacija.Text))
                {
                    MessageBox.Show(
                        "Sezona i lokacija su obavezne.",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                sezonski.Sezona = textBoxSezona.Text.Trim();
                sezonski.Lokacija = textBoxLokacija.Text.Trim();
            }

            return true;
        }

        private void prikaziOdgovarajucaPolja(VrstaOglasa vrsta)
        {
            groupBoxPraksa.Visible = false;
            groupBoxPrivremeni.Visible = false;
            groupBoxSezonski.Visible = false;

            switch (vrsta)
            {
                case VrstaOglasa.PRAKSA:
                    groupBoxPraksa.Visible = true;
                    groupBoxPraksa.BringToFront();
                    break;

                case VrstaOglasa.PRIVREMENI:
                    groupBoxPrivremeni.Visible = true;
                    groupBoxPrivremeni.BringToFront();
                    break;

                case VrstaOglasa.SEZONSKI:
                    groupBoxSezonski.Visible = true;
                    groupBoxSezonski.BringToFront();
                    break;
            }
        }

        private void btnIzmeniOglas_Click(object sender, EventArgs e)
        {
            // Zajednicka obavezna polja
            if (string.IsNullOrWhiteSpace(textBoxNazivPozicije.Text) ||
                statusOglasaBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Naziv pozicije i status su obavezni.",
                    "Nedostaju podaci",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            decimal? minPlata = numericUpDown2.Value == 0
                ? (decimal?)null
                : numericUpDown2.Value;

            decimal? maxPlata = numericUpDown1.Value == 0
                ? (decimal?)null
                : numericUpDown1.Value;

            if (minPlata.HasValue &&
                maxPlata.HasValue &&
                minPlata.Value > maxPlata.Value)
            {
                MessageBox.Show(
                    "Minimalna plata ne moze biti veca od maksimalne plate.",
                    "Neispravan unos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                numericUpDown1.Focus();
                return;
            }

            //DateTime? datumZatvaranja =
            //    date_datumZatvaranja.Checked
            //        ? date_datumZatvaranja.Value.Date
            //        : (DateTime?)null;

            //mora ovako da bi izabrani datum predstavljao kraj dana
            DateTime? datumZatvaranja =
                date_datumZatvaranja.Checked
                    ? date_datumZatvaranja.Value.Date
                        .AddDays(1)
                        .AddSeconds(-1)
                    : (DateTime?)null;

            if (datumZatvaranja.HasValue &&
                datumZatvaranja.Value.Date < this.oglas.DatumObjave.Date)
            {
                MessageBox.Show(
                    "Datum zatvaranja ne moze biti pre datuma objave.",
                    "Neispravan datum",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Posebna polja i validacija
            if (!popuniPosebnePodatke())
                return;

            DialogResult result = MessageBox.Show(
                "Da li zelite da izvrsite izmenu oglasa?",
                "Pitanje",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
                return;

            // Zajednicka svojstva
            this.oglas.NazivPozicije = textBoxNazivPozicije.Text.Trim();

            this.oglas.Opis =
                string.IsNullOrWhiteSpace(richTextBoxOpis.Text)
                    ? null
                    : richTextBoxOpis.Text.Trim();

            this.oglas.Zahtevi =
                string.IsNullOrWhiteSpace(richTextBoxZahtevi.Text)
                    ? null
                    : richTextBoxZahtevi.Text.Trim();

            this.oglas.MinPlata = minPlata;
            this.oglas.MaxPlata = maxPlata;
            this.oglas.DatumZatvaranja = datumZatvaranja;

            this.oglas.Status = (StatusOglasa)statusOglasaBox.SelectedItem;

            try
            {

                OglasBasic izmenjeniOglas = kreirajIzmenjeniOglas(minPlata, maxPlata, datumZatvaranja);

                if (izmenjeniOglas == null)
                    return;

                DTOManager.izmeniOglas(izmenjeniOglas, this.staraVrsta);

                MessageBox.Show(
                    $"Uspesno ste izmenili oglas sa ID={this.oglas.OglasId}!",
                    "Uspesno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(
                    ec.Message,
                    "Greska",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Kada se promeni vrsta oglasa u select polju
        private void vrstaOglasaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vrstaOglasaBox.SelectedItem == null)
                return;

            VrstaOglasa vrsta = (VrstaOglasa)vrstaOglasaBox.SelectedItem;

            prikaziOdgovarajucaPolja(vrsta); //na osnovu vrste odabranog oglasa
        }

        private OglasBasic kreirajIzmenjeniOglas(
            decimal? minPlata,
            decimal? maxPlata,
            DateTime? datumZatvaranja)
        {
            VrstaOglasa novaVrsta = (VrstaOglasa)vrstaOglasaBox.SelectedItem;

            OglasBasic noviOglas;

            switch (novaVrsta)
            {
                case VrstaOglasa.PRAKSA:
                    {
                        if (string.IsNullOrWhiteSpace(textBoxMentorIme.Text) ||
                            string.IsNullOrWhiteSpace(textBoxMentorPrezime.Text))
                        {
                            MessageBox.Show("Ime i prezime mentora su obavezni.");

                            return null;
                        }

                        if (numericDuzinaTrajanja.Value <= 0)
                        {
                            MessageBox.Show("Duzina trajanja mora biti veca od nule.");

                            return null;
                        }

                        noviOglas = new OglasPraksaBasic
                        {
                            MentorIme = textBoxMentorIme.Text.Trim(),
                            MentorPrezime = textBoxMentorPrezime.Text.Trim(),
                            DuzinaTrajanja = (int)numericDuzinaTrajanja.Value
                        };

                        break;
                    }

                case VrstaOglasa.PRIVREMENI:
                    {
                        if (string.IsNullOrWhiteSpace(textBoxProjekat.Text))
                        {
                            MessageBox.Show("Naziv projekta je obavezan.");
                            return null;
                        }

                        if (dateDatumPocetka.Value.Date >
                            dateDatumZavrsetka.Value.Date)
                        {
                            MessageBox.Show("Datum pocetka ne moze biti posle datuma zavrsetka.");

                            return null;
                        }

                        noviOglas = new OglasPrivremeniBasic
                        {
                            Projekat = textBoxProjekat.Text.Trim(),
                            DatumPocetka = dateDatumPocetka.Value.Date,
                            DatumZavrsetka = dateDatumZavrsetka.Value.Date
                        };

                        break;
                    }

                case VrstaOglasa.SEZONSKI:
                    {
                        if (string.IsNullOrWhiteSpace(textBoxSezona.Text) ||
                            string.IsNullOrWhiteSpace(textBoxLokacija.Text))
                        {
                            MessageBox.Show("Sezona i lokacija su obavezne.");

                            return null;
                        }

                        noviOglas = new OglasSezonskiBasic
                        {
                            Sezona = textBoxSezona.Text.Trim(),
                            Lokacija = textBoxLokacija.Text.Trim()
                        };

                        break;
                    }

                case VrstaOglasa.STALNI:
                    noviOglas = new OglasBasic();
                    break;

                default:
                    return null;
            }

            //Zajednicki podaci:

            noviOglas.OglasId = this.oglas.OglasId; //cuva se isti ID

            noviOglas.NazivPozicije = textBoxNazivPozicije.Text.Trim();

            noviOglas.VrstaOglasa = novaVrsta;

            noviOglas.Opis =
                string.IsNullOrWhiteSpace(richTextBoxOpis.Text)
                    ? null
                    : richTextBoxOpis.Text.Trim();

            noviOglas.Zahtevi =
                string.IsNullOrWhiteSpace(richTextBoxZahtevi.Text)
                    ? null
                    : richTextBoxZahtevi.Text.Trim();

            noviOglas.MinPlata = minPlata;
            noviOglas.MaxPlata = maxPlata;

            // Datum objave se ne menja
            noviOglas.DatumObjave = this.oglas.DatumObjave;
            noviOglas.DatumZatvaranja = datumZatvaranja;

            noviOglas.Status = (StatusOglasa)statusOglasaBox.SelectedItem;

            return noviOglas;
        }
    }
}
