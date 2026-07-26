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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace App.Forme
{
    public partial class DodajOglasForm : Form
    {
        OglasBasic oglas;
        public DodajOglasForm()
        {
            InitializeComponent();
            oglas = new OglasBasic();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnDodajOglas_Click(object sender, EventArgs e)
        {
            // Provera zajednickih obaveznih polja
            if (string.IsNullOrWhiteSpace(textBoxNazivPozicije.Text) ||
                vrstaOglasaBox.SelectedItem == null ||
                statusOglasaBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Naziv pozicije, vrsta oglasa i status su obavezni.",
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
                    $"Minimalna plata ({minPlata.Value}) ne moze biti veca " +
                    $"od maksimalne plate ({maxPlata.Value}).",
                    "Neispravan unos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                numericUpDown1.Focus();
                return;
            }

            VrstaOglasa vrsta = (VrstaOglasa)vrstaOglasaBox.SelectedItem;

            // Pravi OglasBasic ili jedan od njegovih podtipova
            // ako se javi greska izbacice odgovarajuci MessageBox, vratice null i nece se dodati oglas
            OglasBasic noviOglas = kreirajOglasIzForme(vrsta, minPlata, maxPlata);

            // Posebna validacija nije prosla
            if (noviOglas == null)
                return;

            DialogResult result = MessageBox.Show(
                "Da li zelite da dodate novi oglas?",
                "Pitanje",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
                return;

            try
            {
                //noviOglas je neka vrsta oglasa. Metoda dodajOglas ce da proveri koja tacno vrsta
                //i na osnovu stvarnog tipa ce da doda odgovarajuci entitet
                DTOManager.dodajOglas(noviOglas);

                MessageBox.Show(
                    "Uspesno ste dodali novi oglas!",
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

        //Promena vrste oglasa na select polju
        private void vrstaOglasaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prvo se svi group box-ovi zatvaraju
            groupBoxPraksa.Visible = false;
            groupBoxPrivremeni.Visible = false;
            groupBoxSezonski.Visible = false;

            if (vrstaOglasaBox.SelectedItem == null)
                return;

            //u zavisnosti od toga koja vrsta oglasa je odabrana prikazace se dodatni podaci
            VrstaOglasa vrsta = (VrstaOglasa)vrstaOglasaBox.SelectedItem;

            switch (vrsta)
            {
                case VrstaOglasa.PRAKSA:
                    groupBoxPraksa.Visible = true;
                    groupBoxPraksa.BringToFront();
                    break;

                case VrstaOglasa.PRIVREMENI:
                    groupBoxPrivremeni.Visible = true;
                    groupBoxPraksa.BringToFront();
                    break;

                case VrstaOglasa.SEZONSKI:
                    groupBoxSezonski.Visible = true;
                    groupBoxPraksa.BringToFront();
                    break;

                case VrstaOglasa.STALNI:
                    // Nema dodatnih polja za STALNI
                    break;

            }
        }

        //metoda za pravljenje odgovarajuceg DTO objekta
        private OglasBasic kreirajOglasIzForme(
            VrstaOglasa vrsta,
            decimal? minPlata,
            decimal? maxPlata)
        {
            OglasBasic noviOglas;

            switch (vrsta)
            {
                case VrstaOglasa.PRAKSA:
                    {
                        if (string.IsNullOrWhiteSpace(textBoxMentorIme.Text) ||
                            string.IsNullOrWhiteSpace(textBoxMentorPrezime.Text))
                        {
                            MessageBox.Show(
                                "Ime i prezime mentora su obavezni.",
                                "Nedostaju podaci",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return null;
                        }

                        if (numericDuzinaTrajanja.Value <= 0)
                        {
                            MessageBox.Show(
                                "Dužina prakse mora biti veća od nule.",
                                "Neispravan unos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

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
                            MessageBox.Show(
                                "Naziv projekta je obavezan.",
                                "Nedostaju podaci",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return null;
                        }

                        if (dateDatumPocetka.Value.Date >
                            dateDatumZavrsetka.Value.Date)
                        {
                            MessageBox.Show(
                                "Datum pocetka ne moze biti posle datuma zavrsetka.",
                                "Neispravan period",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return null;
                        }

                        noviOglas = new OglasPrivremeniBasic
                        {
                            Projekat = textBoxProjekat.Text.Trim(),
                            DatumPocetka = dateDatumPocetka.Value,
                            DatumZavrsetka = dateDatumZavrsetka.Value
                        };

                        break;
                    }

                case VrstaOglasa.SEZONSKI:
                    {
                        if (string.IsNullOrWhiteSpace(textBoxSezona.Text) ||
                            string.IsNullOrWhiteSpace(textBoxLokacija.Text))
                        {
                            MessageBox.Show(
                                "Sezona i lokacija su obavezne.",
                                "Nedostaju podaci",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

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
                    {
                        noviOglas = new OglasBasic();
                        break;
                    }

                default:
                    {
                        MessageBox.Show("Izaberite ispravnu vrstu oglasa.");
                        return null;
                    }
            }

            // Zajednički podaci popunjavaju se za svaki tip oglasa
            noviOglas.NazivPozicije =
                textBoxNazivPozicije.Text.Trim();

            noviOglas.VrstaOglasa = vrsta;

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
            noviOglas.DatumObjave = DateTime.Now;

            noviOglas.DatumZatvaranja =
                date_datumZatvaranja.Checked
                    ? date_datumZatvaranja.Value
                    : (DateTime?)null;

            //datum objave ne sme da bude veci od datuma zatvaranja
            if (noviOglas.DatumZatvaranja.HasValue &&
                noviOglas.DatumZatvaranja.Value.Date < noviOglas.DatumObjave.Date)
            {
                MessageBox.Show(
                    "Datum zatvaranja ne moze biti pre datuma objave.",
                    "Greska",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return null;
            }

            noviOglas.Status =
                (StatusOglasa)statusOglasaBox.SelectedItem;

            return noviOglas;
        }
    }
}
