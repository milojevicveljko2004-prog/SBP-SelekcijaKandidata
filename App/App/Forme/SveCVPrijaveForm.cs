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
    public partial class SveCVPrijaveForm : Form
    {
        public SveCVPrijaveForm()
        {
            InitializeComponent();
        }

        private void SveCVPrijaveForm_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listCVPrijave.Items.Clear();
            List<CVPregled> CV_prijave = DTOManager.vratiSveCVPrijave();

            foreach (CVPregled cv in CV_prijave)
            {
                ListViewItem item = new ListViewItem(new string[] { cv.CvId.ToString(), cv.Ime, cv.Prezime, cv.Email, cv.Telefon,
                    cv.DatumPodnosenja.ToString(), cv.Status.ToString(), cv.OglasID.ToString() });

                listCVPrijave.Items.Add(item);
            }

            //Prikaz za ukupan broj CV prijava u textbox-u:
            textBoxUkupanBrojPrijava.Text = CV_prijave.Count.ToString();

        }

        private void btnObrisiCV_Click(object sender, EventArgs e)
        {
            if (listCVPrijave.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Izaberite CV prijavu koju zelite da obrisete.",
                    "Obavestenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            int cvId = int.Parse(listCVPrijave.SelectedItems[0].SubItems[0].Text);

            DialogResult odgovor = MessageBox.Show(
                "Da li ste sigurni da zelite da obrisete izabranu CV prijavu?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (odgovor != DialogResult.Yes)
                return;

            bool obrisano = DTOManager.ObrisiCVPrijavu(cvId);

            if (obrisano)
            {
                MessageBox.Show(
                    "CV prijava je uspesno obrisana.",
                    "Obaveštenje",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                popuniPodacima(); //azurira se list view i prikaz ukupnog broja prijava
            }
        }
    }
}
