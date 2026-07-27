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
using System.Windows.Forms.VisualStyles;

namespace App.Forme
{
    public partial class IzmeniIntervju_zaCV_Form : Form
    {
        IntervjuBasic intervju;
        CVBasic cv;

        public IzmeniIntervju_zaCV_Form(IntervjuBasic ib, CVBasic cvb)
        {
            InitializeComponent();
            this.intervju = ib;
            this.cv = cvb;

            //omogucava da se u vreme unese tacan sat
            dateVreme.Format = DateTimePickerFormat.Custom;
            dateVreme.CustomFormat = "HH:mm";

            //zabranjuje korisniku da pise u select polje
            comboBoxTipIntervjua.DropDownStyle = ComboBoxStyle.DropDownList;

            //izvlacenje vrednosti iz enuma da bi se kasnije lakse cast-ovalo
            comboBoxTipIntervjua.DataSource = Enum.GetValues(typeof(TipIntervjua));
        }

        private void IzmeniIntervju_zaCV_Form_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = "IZMENA INTERVJUA ZA CV sa ID = " + this.cv.CvId;
        }

        public void popuniPodacima()
        {
            dateDatum.Value = this.intervju.Datum;
            dateVreme.Value = this.intervju.Vreme;
            comboBoxTipIntervjua.Text = this.intervju.Tip.ToString();
            textBoxLokacija.Text = this.intervju.Lokacija;
            textBoxImeZaposlenog.Text = this.intervju.ZaposleniIme;
            textBoxPrezimeZaposlenog.Text = this.intervju.ZaposleniPrezime;
            numericOcena.Value = this.intervju.Ocena;
            richTextBoxNapomene.Text = this.intervju.Napomene;
        }

        private void btnIzmeniIntervju_Click(object sender, EventArgs e)
        {
            string poruka = $"Da li zelite da izmenite intervju sa ID={this.intervju.IntervjuId}?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //VALIDACIJA
                if (string.IsNullOrWhiteSpace(textBoxLokacija.Text) ||
                    string.IsNullOrWhiteSpace(textBoxImeZaposlenog.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPrezimeZaposlenog.Text))
                {
                    MessageBox.Show(
                            "Lokacija, ime zaposlenog i prezime zaposlenog su obavezni!",
                            "Nedostaju podaci",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                    return;
                }

                if (numericOcena.Value < 1 || numericOcena.Value > 10)
                {
                    MessageBox.Show(
                            "Ocena mora biti u opsegu od 1 do 10.",
                            "Greska",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                    return;
                }

                this.intervju.Datum = dateDatum.Value;
                this.intervju.Vreme = dateVreme.Value;
                this.intervju.Tip = (TipIntervjua)comboBoxTipIntervjua.SelectedItem;
                this.intervju.Lokacija = textBoxLokacija.Text.Trim();
                this.intervju.ZaposleniIme = textBoxImeZaposlenog.Text.Trim();
                this.intervju.ZaposleniPrezime = textBoxPrezimeZaposlenog.Text.Trim();
                this.intervju.Ocena = (int)numericOcena.Value;
                this.intervju.Napomene = richTextBoxNapomene.Text.Trim();


                DTOManager.izmeniIntervju(this.intervju);

                MessageBox.Show(
                    $"Uspesno ste izmenili intervju sa ID={this.intervju.IntervjuId}!",
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
