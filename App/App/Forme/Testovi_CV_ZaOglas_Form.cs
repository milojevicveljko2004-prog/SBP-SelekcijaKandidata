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
    public partial class Testovi_CV_ZaOglas_Form : Form
    {
        CVBasic cv;

        public Testovi_CV_ZaOglas_Form(CVBasic cv)
        {
            InitializeComponent();
            this.cv = cv;
        }

        private void Testovi_CV_ZaOglas_Form_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public void popuniPodacima()
        {
            listTestovi.Items.Clear();
            List<TestPregled> testovi = DTOManager.vratiTestoveCVPrijave(this.cv.CvId);

            foreach (TestPregled t in testovi)
            {
                ListViewItem item = new ListViewItem(new string[] { t.TestId.ToString(), t.Rezultat.ToString(),
                t.DatumTestiranja.ToString(), t.VrstaTestiranja, t.Komentar });

                listTestovi.Items.Add(item);
            }

        }

        private void btnDodajTest_Click(object sender, EventArgs e)
        {
            DodajTest_zaCV_Form form = new DodajTest_zaCV_Form(this.cv);
            form.ShowDialog();
            popuniPodacima();
        }

        private void btnIzmeniTest_Click(object sender, EventArgs e)
        {
            if (listTestovi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite test koji zelite da menjate!");
                return;
            }

            int testId = Int32.Parse(listTestovi.SelectedItems[0].SubItems[0].Text);
            TestBasic tb = DTOManager.vratiTest(testId);

            IzmeniTest_zaCV_Form form = new IzmeniTest_zaCV_Form(tb, this.cv);
            form.ShowDialog();
            popuniPodacima();
        }

        private void btnObrisiTest_Click(object sender, EventArgs e)
        {
            if (listTestovi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite test koji zelite da obrisete!");
                return;
            }

            int idTesta = Int32.Parse(listTestovi.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li zelite da obrisete izabrani test?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiTest(idTesta);
                MessageBox.Show("Brisanje testa je uspesno obavljeno!");
                this.popuniPodacima(); //osvezava se listView
            }
            else
            {
                //nista se ne desi, korisnik je kliknuo Cancel
            }
        }
    }
}
