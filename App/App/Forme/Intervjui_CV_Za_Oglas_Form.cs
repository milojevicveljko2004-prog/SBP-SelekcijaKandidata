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
    }
}
