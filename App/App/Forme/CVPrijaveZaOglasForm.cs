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
    public partial class CVPrijaveZaOglasForm : Form
    {
        OglasBasic oglas;
        public CVPrijaveZaOglasForm(OglasBasic oglas)
        {
            InitializeComponent();
            this.oglas = oglas;
        }

        private void CVPrijaveZaOglasForm_Load(object sender, EventArgs e)
        {
            this.Text = "OGLAS " + this.oglas.NazivPozicije.ToUpper();
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listCVPrijaveZaOglas.Items.Clear();
            List<CVPregled> podaci = DTOManager.vratiCVPrijaveOglasa(this.oglas.OglasId);

            foreach (CVPregled p in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { p.CvId.ToString(), p.Ime, p.Prezime, p.Email, p.Telefon,
                    p.DatumPodnosenja.ToString(), p.Status.ToString(), p.OglasID.ToString() });

                listCVPrijaveZaOglas.Items.Add(item);

            }

        }

        private void btnDodajCV_UOglas_Click(object sender, EventArgs e)
        {
            DodajCV_ZaOglas_Form form = new DodajCV_ZaOglas_Form(this.oglas);
            form.ShowDialog();
            this.popuniPodacima();
        }

        private void btnIzmeniCV_zaOglas_Click(object sender, EventArgs e)
        {
            if (listCVPrijaveZaOglas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite CV prijavu cije podatke zelite da izmenite!");
                return;
            }

            int idCv = Int32.Parse(listCVPrijaveZaOglas.SelectedItems[0].SubItems[0].Text);
            CVBasic cvb = DTOManager.vratiCV(idCv);

            IzmeniCV_ZaOglas_Form form = new IzmeniCV_ZaOglas_Form(cvb, this.oglas);
            form.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiCV_zaOglas_Click(object sender, EventArgs e)
        {
            if (listCVPrijaveZaOglas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite CV prijavu koju zelite da obrisete iz oglasa!");
                return;
            }

            int idCv = Int32.Parse(listCVPrijaveZaOglas.SelectedItems[0].SubItems[0].Text);

            string poruka = "Da li zelite da obrisete izabranu CV prijavu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiCV(idCv);
                MessageBox.Show("Brisanje CV prijave iz oglasa je uspesno obavljeno!");
                this.popuniPodacima(); //osvezava se listView
            }
            else
            {
                //nista se ne desi, korisnik je kliknuo Cancel
            }
        }

        private void btnIntervjui_Click(object sender, EventArgs e)
        {
            if (listCVPrijaveZaOglas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite CV za koji zelite da vidite intervjue!");
                return;
            }

            int idCv = Int32.Parse(listCVPrijaveZaOglas.SelectedItems[0].SubItems[0].Text);
            CVBasic cvb = DTOManager.vratiCV(idCv);

            IntervjuiForm form = new IntervjuiForm(cvb);
            form.ShowDialog();
        }

        private void btnTestovi_Click(object sender, EventArgs e)
        {
            if (listCVPrijaveZaOglas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite CV za koji zelite da vidite testove!");
                return;
            }

            int idCv = Int32.Parse(listCVPrijaveZaOglas.SelectedItems[0].SubItems[0].Text);
            CVBasic cvb = DTOManager.vratiCV(idCv);

            TestoviForm form = new TestoviForm(cvb);
            form.ShowDialog();
        }

        private void btnOdluka_Click(object sender, EventArgs e)
        {
            if (listCVPrijaveZaOglas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite CV za koji zelite da vidite Odluku!");
                return;
            }

            int idCv = Int32.Parse(listCVPrijaveZaOglas.SelectedItems[0].SubItems[0].Text);
            CVBasic cvb = DTOManager.vratiCV(idCv);

            Odluka_CV_Za_Oglas_Form form = new Odluka_CV_Za_Oglas_Form(cvb);
            form.ShowDialog();
        }
    }
}
