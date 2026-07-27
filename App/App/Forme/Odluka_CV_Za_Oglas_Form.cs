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
    public partial class Odluka_CV_Za_Oglas_Form : Form
    {
        CVBasic cv;
        OdlukaBasic odluka;
        bool odlukaPostoji;

        public Odluka_CV_Za_Oglas_Form(CVBasic cvb)
        {
            InitializeComponent();
            this.cv = cvb;

            //ne dozvoljava se upis u select polje
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            //izvlacenje vrednosti iz Enum-a zbog lakseg cast-ovanja kasnije
            comboBoxStatus.DataSource = Enum.GetValues(typeof(StatusOdluke));

            //nullable polje, treba da se omoguci korisniku da ne mora da unese datum (kada polje nije cekirano)
            dateDatumPocetkaRada.ShowCheckBox = true;
            //recimo da u pocetku nije check-irano
            dateDatumPocetkaRada.Checked = false;
        }

        private void Odluka_CV_Za_Oglas_Form_Load(object sender, EventArgs e)
        {
            Text = $"ODLUKA ZA CV: {cv.Ime} {cv.Prezime}";

            odluka = DTOManager.vratiOdlukuZaCV(cv.CvId);
            odlukaPostoji = odluka != null;

            if (!odlukaPostoji) //Odluka ne postoji i treba da se doda
            {
                odluka = new OdlukaBasic();

                odluka.DatumDonosenjaOdluke = DateTime.Now;

                btnSacuvajOdluku.Text = "Sacuvaj odluku";
            }
            else //Odluka postoji i moze samo da se promeni
            {
                popuniPodatke();

                btnSacuvajOdluku.Text = "Sacuvaj izmene";
            }

            azurirajPrikazPolja();
        }

        private void popuniPodatke()
        {
            //odabrani status
            comboBoxStatus.SelectedItem = odluka.Status;

            if (odluka.PonudjenaPlata.HasValue)
            {
                numericPonudjenaPlata.Value = odluka.PonudjenaPlata.Value;
            }
            else
            {
                numericPonudjenaPlata.Value = 0;
            }

            checkBoxDa.Checked = odluka.PrihvatioPonudu == true;

            checkBoxNe.Checked = odluka.PrihvatioPonudu == false;

            if (odluka.DatumPocetkaRada.HasValue)
            {
                dateDatumPocetkaRada.Checked = true;
                dateDatumPocetkaRada.Value = odluka.DatumPocetkaRada.Value;
            }
            else
            {
                dateDatumPocetkaRada.Checked = false;
            }

            richTextBoxRazlogOdbijanja.Text = odluka.RazlogOdbijanja ?? string.Empty;
        }

        private void checkBoxDa_CheckedChanged(object sender, EventArgs e)
        {
            //samo jedno checkBox polje moze da bude cekirano u jednom trenutku
            if (checkBoxDa.Checked)
                checkBoxNe.Checked = false;

            azurirajPrikazPolja();
        }

        private void checkBoxNe_CheckedChanged(object sender, EventArgs e)
        {
            //samo jedno checkBox polje moze da bude cekirano u jednom trenutku
            if (checkBoxNe.Checked)
                checkBoxDa.Checked = false;

            azurirajPrikazPolja();
        }

        //Neka polja ce biti skrivena u zavisnosti od odabranog statusa
        private void azurirajPrikazPolja()
        {
            if (comboBoxStatus.SelectedItem == null)
                return;

            StatusOdluke status = (StatusOdluke)comboBoxStatus.SelectedItem;

            bool izabran = status == StatusOdluke.IZABRAN;
            bool odbijen = status == StatusOdluke.ODBIJEN;

            //IZABRAN - Prikazuju se ponudjena plata i Da/Ne
            numericPonudjenaPlata.Enabled = izabran;
            checkBoxDa.Enabled = izabran;
            checkBoxNe.Enabled = izabran;

            //Prihvacena ponuda - prikazuje se datum pocetka
            dateDatumPocetkaRada.Enabled = izabran && checkBoxDa.Checked;

            //Status odbijen ili odbijena ponuda - prikazuje se razlog odbijanja
            richTextBoxRazlogOdbijanja.Enabled = odbijen || (izabran && checkBoxNe.Checked);
        }

        private bool preuzmiPodatkeSaForme()
        {
            if (comboBoxStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Izaberite status odluke.",
                    "Nedostaju podaci",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            StatusOdluke status =
                (StatusOdluke)comboBoxStatus.SelectedItem;

            odluka.Status = status;

            if (status == StatusOdluke.IZABRAN)
            {
                if (numericPonudjenaPlata.Value <= 0)
                {
                    MessageBox.Show(
                        "Ponuđena plata mora biti veća od nule.",
                        "Neispravan unos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                if (!checkBoxDa.Checked && !checkBoxNe.Checked)
                {
                    MessageBox.Show(
                        "Označite da li je ponuda prihvaćena.",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }

                odluka.PonudjenaPlata =
                    numericPonudjenaPlata.Value;

                if (checkBoxDa.Checked)
                {
                    if (!dateDatumPocetkaRada.Checked)
                    {
                        MessageBox.Show(
                            "Unesite datum početka rada.",
                            "Nedostaju podaci",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    if (dateDatumPocetkaRada.Value.Date <
                        odluka.DatumDonosenjaOdluke.Date)
                    {
                        MessageBox.Show(
                            "Datum početka rada ne može biti pre " +
                            "datuma donošenja odluke.",
                            "Neispravan datum",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    odluka.PrihvatioPonudu = true;
                    odluka.DatumPocetkaRada =
                        dateDatumPocetkaRada.Value;

                    odluka.RazlogOdbijanja = null;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(
                        richTextBoxRazlogOdbijanja.Text))
                    {
                        MessageBox.Show(
                            "Unesite razlog odbijanja ponude.",
                            "Nedostaju podaci",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    odluka.PrihvatioPonudu = false;
                    odluka.DatumPocetkaRada = null;
                    odluka.RazlogOdbijanja =
                        richTextBoxRazlogOdbijanja.Text.Trim();
                }
            }
            else
            {
                // Ponuda nije data, odnosno nije primenljiva.
                odluka.PonudjenaPlata = null;
                odluka.PrihvatioPonudu = null;
                odluka.DatumPocetkaRada = null;

                if (status == StatusOdluke.ODBIJEN)
                {
                    if (string.IsNullOrWhiteSpace(
                        richTextBoxRazlogOdbijanja.Text))
                    {
                        MessageBox.Show(
                            "Unesite razlog odbijanja kandidata.",
                            "Nedostaju podaci",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    odluka.RazlogOdbijanja =
                        richTextBoxRazlogOdbijanja.Text.Trim();
                }
                else
                {
                    odluka.RazlogOdbijanja = null;
                }
            }

            return true;
        }

        private void btnSacuvajPrivremeni_Click(object sender, EventArgs e)
        {

        }

        private void btnSacuvajOdluku_Click(object sender, EventArgs e)
        {
            if (!preuzmiPodatkeSaForme())
                return;

            string poruka;

            if (odlukaPostoji)
            {
                poruka = "Da li zelite da sacuvate izmene odluke?";
            }
            else
            {
                poruka = "Da li zelite da dodate odluku za izabrani CV?";
            }

            DialogResult result = MessageBox.Show(
                poruka,
                "Potvrda",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result != DialogResult.OK)
                return;

            try
            {
                if (odlukaPostoji)
                {
                    DTOManager.izmeniOdluku(odluka);
                }
                else
                {
                    DTOManager.dodajOdluku(odluka, cv.CvId);

                    odlukaPostoji = true;
                }

                MessageBox.Show(
                    "Odluka je uspesno sačuvana.",
                    "Uspešno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(
                    ec.Message,
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Na promenu statusa u select polju
        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            azurirajPrikazPolja();
        }
    }
}
