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
    public partial class DodajCV_ZaOglas_Form : Form
    {
        OglasBasic oglas;
        CVBasic cv;
        public DodajCV_ZaOglas_Form(OglasBasic o)
        {
            InitializeComponent();
            this.cv = new CVBasic();
            this.oglas = o;
        }

        private void DodajCV_ZaOglas_Form_Load(object sender, EventArgs e)
        {
            this.Text = "NOVI CV ZA OGLAS " + this.oglas.NazivPozicije;
        }

        private void btnDodajCV_zaOglas_Click(object sender, EventArgs e)
        {
            string poruka = $"Da li zelite da dodate novi CV u oglas {this.oglas.NazivPozicije}?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                //NOT NULL polja ne smeju da budu prazna
                if (string.IsNullOrWhiteSpace(textBoxIme.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPrezime.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(textBoxTelefon.Text))
                {
                    MessageBox.Show(
                        "Sva polja su obavezna!",
                        "Nedostaju podaci",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                this.cv.Ime = textBoxIme.Text;
                this.cv.Prezime = textBoxPrezime.Text;
                this.cv.Email = textBoxEmail.Text;
                this.cv.Telefon = textBoxTelefon.Text;

                //ova polja se automatski podesavaju, zato nisu na formi:
                this.cv.DatumPodnosenja = DateTime.Now;
                this.cv.Status = CVStatus.PRIMLJEN;

                DTOManager.dodajCV(this.cv, this.oglas.OglasId);

                MessageBox.Show(
                    $"Uspesno ste dodali novi CV u oglas {this.oglas.NazivPozicije}!",
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
