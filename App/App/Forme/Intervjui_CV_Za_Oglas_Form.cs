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
    public partial class Intervjui_CV_Za_Oglas_Form : Form
    {
        CVBasic cv;

        public Intervjui_CV_Za_Oglas_Form(CVBasic cv)
        {
            InitializeComponent();
            this.cv = cv;
        }

        private void Intervjui_CV_Za_Oglas_Form_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            listIntervjui.Items.Clear();
            List<IntervjuPregled> intervjui = DTOManager.vratiIntervjueCVPrijave(this.cv.CvId);

            foreach (IntervjuPregled i in intervjui)
            {
                ListViewItem item = new ListViewItem(new string[] { i.IntervjuId.ToString(), i.Datum.ToString(),
                i.Vreme.ToString(), i.Tip.ToString(), i.Lokacija, i.ZaposleniIme, i.ZaposleniPrezime, 
                i.Ocena.ToString(), i.Napomene});

                listIntervjui.Items.Add(item);
            }

        }

        private void btnDodajOglas_Click(object sender, EventArgs e)
        {
            DodajIntervju_zaCV_Form form = new DodajIntervju_zaCV_Form(this.cv);
            form.ShowDialog();
            this.popuniPodacima(); //osvezava se listview
        }

        private void btnIzmeniOglas_Click(object sender, EventArgs e)
        {
            if (listIntervjui.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite intervju koji zelite da menjate!");
                return;
            }

            int intervjuId = Int32.Parse(listIntervjui.SelectedItems[0].SubItems[0].Text);
            IntervjuBasic ib = DTOManager.vratiIntervju(intervjuId);

            IzmeniIntervju_zaCV_Form form = new IzmeniIntervju_zaCV_Form(ib, this.cv);
            form.ShowDialog();
            this.popuniPodacima(); //osvezava se listview
        }

        private void btnObrisiOglas_Click(object sender, EventArgs e)
        {
            if (listIntervjui.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite intervju koji zelite da obrisete iz CV-ja!");
                return;
            }

            int intervjuId = Int32.Parse(listIntervjui.SelectedItems[0].SubItems[0].Text);

            string poruka = "Da li zelite da obrisete izabrani intervju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiIntervju(intervjuId);
                MessageBox.Show("Brisanje intervjua iz CV-ja je uspesno obavljeno!");
                this.popuniPodacima(); //osvezava se listView
            }
            else
            {
                //nista se ne desi, korisnik je kliknuo Cancel
            }
        }
    }
}
