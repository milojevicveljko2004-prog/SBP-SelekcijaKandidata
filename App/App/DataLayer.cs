using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using App.Mapiranja;

namespace App
{
    class DataLayer
    {
        //ISession omogucava rad sa NHibernate sesijama.
        //Obezbedjuje osnovne CRUD operacije(citanje resursa, upis, brisanje...)
        //ISessionFactory obezbedjuje metode za kreiranje NHibernate sesija.
        private static ISessionFactory _factory = null;
        private static object objLock = new object(); //sluzi kao Mutex. Sesija ne sme da se deli izmedju vise niti.


        //funkcija na zahtev otvara sesiju. Svaki put kada se pozove otvara se nova sesija.
        public static ISession GetSession() //f-ja koju pozivamo da bismo dobili ISession interfejs koji cemo koristiti
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock) //samo jedna nit sme da izvrsava ovaj deo koda u jednom trenutku
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        //konfiguracija i kreiranje session factory
        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ConnectionString(c =>
                    c.Is("DATA SOURCE=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;PERSIST SECURITY INFO=True;USER ID=S19751;Password=S19751"));

                return Fluently.Configure()
                    .Database(cfg.ShowSql()) //moze i bez ShowSql() ali zgodno je za debug - prikazuju se svi upiti koji idu ka bazi
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OglasMapiranja>()) //uzima i sve druge klase koje se nalaze u istom namespace-u u kom je klasa OglasMapiranja
                    //.ExposeConfiguration(BuildSchema)
                    .BuildSessionFactory();
            }
            catch (Exception ec)
            {
                System.Windows.Forms.MessageBox.Show(ec.Message);
                return null;
            }

        }
    }
}
