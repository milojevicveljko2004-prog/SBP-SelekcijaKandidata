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
            //popuniPodacima();
        }

        public void popuniPodacima()
        {
            //listCVPrijaveZaOglas.Items.Clear();
            //List<CVBasic> podaci = DTOManager.vratiCVPrijaveOglasa(this.oglas.OglasId);

            //foreach (OdeljenjeOdrasliPregled p in podaci)
            //{
            //    ListViewItem item = new ListViewItem(new string[] { p.OdeljenjeId.ToString(), p.Lokacija, p.BrojKasa.ToString(), p.InfoPult });
            //    odeljenja.Items.Add(item);

            //}

            //odeljenja.Refresh();
        }
    }
}
