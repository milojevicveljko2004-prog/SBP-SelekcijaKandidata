using App.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using ISession = NHibernate.ISession;

namespace App
{
    public class DTOManager
    {
        #region Oglasi

        public static List<OglasPregled> vratiSveOglase()
        {
            List<OglasPregled> oglasi = new List<OglasPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IEnumerable<App.Entiteti.Oglas> sviOglasi = from o in s.Query<App.Entiteti.Oglas>()
                                                            select o;

                foreach (App.Entiteti.Oglas o in sviOglasi)
                {
                    oglasi.Add(new OglasPregled(o.OglasId, o.NazivPozicije, o.VrstaOglasa, o.Opis, o.Zahtevi, o.MinPlata, o.MaxPlata, o.DatumObjave, o.DatumZatvaranja, o.Status));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("GreSka prilikom prikazivanja oglasa: " + ec.Message, ec);
            }

            return oglasi;
        }

        public static void dodajOglas(OglasBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oglas o = new Oglas();

                o.NazivPozicije = p.NazivPozicije;
                o.VrstaOglasa = p.VrstaOglasa;
                o.Opis = p.Opis;
                o.Zahtevi = p.Zahtevi;
                o.MinPlata = p.MinPlata;
                o.MaxPlata = p.MaxPlata;
                o.DatumObjave = p.DatumObjave;
                o.DatumZatvaranja = p.DatumZatvaranja;
                o.Status = p.Status;

                s.SaveOrUpdate(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom dodavanja oglasa: " + ec.Message, ec);
            }
        }

        public static OglasBasic izmeniOglas(OglasBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oglas o = s.Load<Oglas>(p.OglasId);

                o.NazivPozicije = p.NazivPozicije;
                o.VrstaOglasa = p.VrstaOglasa;
                o.Opis = p.Opis;
                o.Zahtevi = p.Zahtevi;
                o.MinPlata = p.MinPlata;
                o.MaxPlata = p.MaxPlata;
                o.DatumObjave = p.DatumObjave;
                o.DatumZatvaranja = p.DatumZatvaranja;
                o.Status = p.Status;

                s.Update(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene oglasa: " + ec.Message, ec);
            }

            return p;
        }

        public static void obrisiOglas(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oglas o = s.Load<Oglas>(id);

                s.Delete(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }

        public static OglasBasic vratiOglas(int id)
        {
            OglasBasic ob = new OglasBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Oglas o = s.Load<Oglas>(id);
                ob = new OglasBasic(o.OglasId, o.NazivPozicije, o.VrstaOglasa, o.Opis, o.Zahtevi, 
                    o.MinPlata, o.MaxPlata, o.DatumObjave, o.DatumZatvaranja, o.Status);

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja oglasa: " + ec.Message, ec);
            }

            return ob;
        }

        #endregion
    }
}
