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
    public partial class OglasiForm : Form
    {
        public OglasiForm()
        {
            InitializeComponent();
        }
        private void OglasiForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listaOglasa.Items.Clear();
            List<OglasPregled> oglasi = DTOManager.vratiSveOglase();

            foreach (OglasPregled o in oglasi)
            {
                ListViewItem item = new ListViewItem(new string[] { o.OglasId.ToString(), o.NazivPozicije,
                    o.VrstaOglasa.ToString(), o.Opis, o.Zahtevi, o.MinPlata.ToString(), o.MaxPlata.ToString(), o.DatumObjave.ToString(),
                    o.DatumZatvaranja.ToString(), o.Status.ToString() });

                listaOglasa.Items.Add(item);

            }

            listaOglasa.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void btnDodajOglas_Click(object sender, EventArgs e)
        {
            DodajOglasForm formaDodaj = new DodajOglasForm();
            formaDodaj.ShowDialog();
            this.popuniPodacima(); //osvezava se listView
        }

        private void btnIzmeniOglas_Click(object sender, EventArgs e)
        {
            if (listaOglasa.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite oglas cije podatke zelite da izmenite!");
                return;
            }

            int idOglasa = Int32.Parse(listaOglasa.SelectedItems[0].SubItems[0].Text);
            OglasBasic ob = DTOManager.vratiOglas(idOglasa);

            IzmeniOglasForm formaIzmeni = new IzmeniOglasForm(ob);
            formaIzmeni.ShowDialog();
            this.popuniPodacima(); //osvezava se listView
        }

        private void btnObrisiOglas_Click(object sender, EventArgs e)
        {
            if (listaOglasa.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite oglas koji zelite da obrisete!");
                return;
            }

            int idOglasa = Int32.Parse(listaOglasa.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani oglas?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiOglas(idOglasa);
                MessageBox.Show("Brisanje oglasa je uspesno obavljeno!");
                this.popuniPodacima(); //osvezava se listView
            }
            else
            {
                //nista se ne desi, korisnik je kliknuo Cancel
            }
        }

        private void btnCVPrijaveZaOglas_Click(object sender, EventArgs e)
        {
            if (listaOglasa.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite oglas za koji zelite da vidite prijave!");
                return;
            }

            int idOglasa = Int32.Parse(listaOglasa.SelectedItems[0].SubItems[0].Text);
            OglasBasic ob = DTOManager.vratiOglas(idOglasa);

            CVPrijaveZaOglasForm form = new CVPrijaveZaOglasForm(ob);
            form.ShowDialog();
        }
    }
}
