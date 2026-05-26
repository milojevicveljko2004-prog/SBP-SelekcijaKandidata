using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using App.Entiteti;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdUcitavanjeOglasa_Click(object sender, EventArgs e)
        {
            try
            {
                //otvaranje sesije
                ISession s = DataLayer.GetSession();
                //tek nakon otvaranja sesije mozemo da radimo sa entitetima

                //Ucitavaju se podaci o oglasu za zadatim brojem
                Oglas o = s.Load<Oglas>(2);

                MessageBox.Show(o.VrstaOglasa);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void DodavanjeNovogOglasa_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Oglas o = new Oglas();

                //p = s.Load<Entiteti.Prodavnica>(81);

                o.NazivPozicije = "Web developer";
                o.VrstaOglasa = "PRIVREMENI";
                o.Opis = "Zaduzen za kreiranje i razvoj Web aplikacija.";
                o.Zahtevi = "HTML, CSS, JavaScript, React, PHP";
                o.MinPlata = 100000;
                o.MaxPlata = 210000;
                o.DatumObjave = DateTime.Now;
                o.Status = "AKTIVAN";

                //s.Save(p);
                s.SaveOrUpdate(o);

                s.Flush(); //sve modifikacije koje su se desile, a nisu snimljene, se forsiraju u bazu podataka
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.ToString());
            }
        }
    }
}
