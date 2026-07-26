using App.Entiteti;
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
    public partial class IzmeniCV_ZaOglas_Form : Form
    {
        CVBasic cv;
        OglasBasic oglas;
        public IzmeniCV_ZaOglas_Form(CVBasic cvb, OglasBasic ob)
        {
            InitializeComponent();
            this.cv = cvb;
            this.oglas = ob;

            //ne dozvoljava se promena datuma podnosenja prijave
            date_DatumPodnosenja.Enabled = false;

            //zabranjuje korisniku da pise u select polje
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            //izvlacenje vrednosti iz enuma da bi se kasnije lakse cast-ovalo
            comboBoxStatus.DataSource = Enum.GetValues(typeof(CVStatus));
        }

        private void IzmeniCV_ZaOglas_Form_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            this.Text = "IZMENA CV-a ZA OGLAS " + this.oglas.NazivPozicije;
        }

        public void popuniPodacima()
        {
            textBoxIme.Text = this.cv.Ime;
            textBoxPrezime.Text = this.cv.Prezime;
            textBoxEmail.Text = this.cv.Email;
            textBoxTelefon.Text = this.cv.Telefon;
            date_DatumPodnosenja.Value = this.cv.DatumPodnosenja;
            comboBoxStatus.Text = this.cv.Status.ToString();
        }

        private void btnIzmeniCV_zaOglas_Click(object sender, EventArgs e)
        {
            string poruka = $"Da li zelite da izmenite CV sa ID={this.cv.CvId}?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                //NOT NULL polja ne smeju da budu prazna
                if (string.IsNullOrWhiteSpace(textBoxIme.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPrezime.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(textBoxTelefon.Text) ||
                    comboBoxStatus.SelectedItem == null)
                {
                    MessageBox.Show(
                        "Sva polja su obavezna!",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                this.cv.Ime = textBoxIme.Text.Trim();
                this.cv.Prezime = textBoxPrezime.Text.Trim();
                this.cv.Email = textBoxEmail.Text.Trim();
                this.cv.Telefon = textBoxTelefon.Text.Trim();
                //this.cv.DatumPodnosenja = date_DatumPodnosenja.Value; //svakako se ne menja
                this.cv.Status = (CVStatus)comboBoxStatus.SelectedItem;

                DTOManager.izmeniCV(this.cv);

                MessageBox.Show(
                    "Uspesno ste izmenili CV!",
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
