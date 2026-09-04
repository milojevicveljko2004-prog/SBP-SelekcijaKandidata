using DatabaseAccess.Entiteti.Enums;
using ISession = NHibernate.ISession;

namespace DatabaseAccess
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

                IEnumerable<DatabaseAccess.Entiteti.Oglas> sviOglasi = from o in s.Query<DatabaseAccess.Entiteti.Oglas>()
                                                                       select o;

                foreach (DatabaseAccess.Entiteti.Oglas o in sviOglasi)
                {
                    oglasi.Add(new OglasPregled(o.OglasId, o.NazivPozicije, o.VrstaOglasa, o.Opis, o.Zahtevi,
                        o.MinPlata, o.MaxPlata, o.DatumObjave, o.DatumZatvaranja, o.Status));
                }

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom prikazivanja oglasa: " + ec.Message, ec);
            }

            return oglasi;
        }

        public static void dodajOglas(OglasBasic p)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                p.DatumObjave = DateTime.Now;
                normalizujDatumZatvaranja(p);

                Oglas o;

                OglasPraksaBasic praksa = p as OglasPraksaBasic;
                OglasPrivremeniBasic privremeni = p as OglasPrivremeniBasic;
                OglasSezonskiBasic sezonski = p as OglasSezonskiBasic;

                if (praksa != null)
                {
                    o = new OglasPraksa
                    {
                        MentorIme = praksa.MentorIme,
                        MentorPrezime = praksa.MentorPrezime,
                        DuzinaTrajanja = praksa.DuzinaTrajanja
                    };
                }
                else if (privremeni != null)
                {
                    o = new OglasPrivremeni
                    {
                        Projekat = privremeni.Projekat,
                        DatumPocetka = privremeni.DatumPocetka,
                        DatumZavrsetka = privremeni.DatumZavrsetka
                    };
                }
                else if (sezonski != null)
                {
                    o = new OglasSezonski
                    {
                        Sezona = sezonski.Sezona,
                        Lokacija = sezonski.Lokacija
                    };
                }
                else
                {
                    o = new Oglas();
                }

                o.NazivPozicije = p.NazivPozicije;
                o.VrstaOglasa = p.VrstaOglasa;
                o.Opis = p.Opis;
                o.Zahtevi = p.Zahtevi;
                o.MinPlata = p.MinPlata;
                o.MaxPlata = p.MaxPlata;
                o.DatumObjave = p.DatumObjave;
                o.DatumZatvaranja = p.DatumZatvaranja;
                o.Status = p.Status;

                s.Save(o);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom dodavanja oglasa: " + ec.Message, ec);
            }
        }

        public static OglasBasic izmeniOglas(OglasBasic p, VrstaOglasa staraVrsta)
        {
            using (ISession s = DataLayer.GetSession())
            using (ITransaction transaction = s.BeginTransaction())
            {
                try
                {
                    normalizujDatumZatvaranja(p);

                    obrisiPosebanRed(s, p.OglasId, staraVrsta);

                    int brojIzmenjenih = s.CreateSQLQuery(@"
                    UPDATE OGLAS
                    SET NAZIV_POZICIJE = :naziv,
                    VRSTA_OGLASA = :vrsta,
                    OPIS = :opis,
                    ZAHTEVI = :zahtevi,
                    MIN_PLATA = :minPlata,
                    MAX_PLATA = :maxPlata,
                    DATUM_ZATVARANJA = :datumZatvaranja,
                    STATUS = :status
                    WHERE OGLAS_ID = :id")
                        .SetParameter("naziv", p.NazivPozicije)
                        .SetParameter("vrsta", p.VrstaOglasa.ToString())
                        .SetParameter("opis", p.Opis, NHibernateUtil.String)
                        .SetParameter("zahtevi", p.Zahtevi, NHibernateUtil.String)
                        .SetParameter("minPlata", p.MinPlata, NHibernateUtil.Decimal)
                        .SetParameter("maxPlata", p.MaxPlata, NHibernateUtil.Decimal)
                        .SetParameter("datumZatvaranja", p.DatumZatvaranja, NHibernateUtil.DateTime)
                        .SetParameter("status", p.Status.ToString())
                        .SetParameter("id", p.OglasId)
                        .ExecuteUpdate();

                    if (brojIzmenjenih == 0)
                    {
                        throw new Exception($"Oglas sa ID={p.OglasId} ne postoji.");
                    }

                    dodajPosebanRed(s, p);

                    transaction.Commit();

                    return p;
                }
                catch (Exception ec)
                {
                    if (transaction.IsActive)
                        transaction.Rollback();

                    throw new Exception(
                        "Greska prilikom izmene oglasa: " +
                        ec.Message,
                        ec);
                }
            }
        }

        private static void normalizujDatumZatvaranja(OglasBasic oglas)
        {
            if (!oglas.DatumZatvaranja.HasValue)
                return;

            oglas.DatumZatvaranja = oglas.DatumZatvaranja.Value.Date
                .AddDays(1)
                .AddSeconds(-1);

            if (oglas.DatumZatvaranja.Value.Date < oglas.DatumObjave.Date)
            {
                throw new ArgumentException(
                    "Datum zatvaranja ne moze biti pre datuma objave.");
            }
        }

        private static void obrisiPosebanRed(
            ISession s,
            int oglasId,
            VrstaOglasa vrsta)
        {
            string sql;

            switch (vrsta)
            {
                case VrstaOglasa.PRAKSA:
                    sql = @"
                DELETE FROM OGLAS_PRAKSA
                WHERE OGLAS_ID = :id";
                    break;

                case VrstaOglasa.PRIVREMENI:
                    sql = @"
                DELETE FROM OGLAS_PRIVREMENI
                WHERE OGLAS_ID = :id";
                    break;

                case VrstaOglasa.SEZONSKI:
                    sql = @"
                DELETE FROM OGLAS_SEZONSKI
                WHERE OGLAS_ID = :id";
                    break;

                case VrstaOglasa.STALNI:
                    return;

                default:
                    throw new Exception("Nepoznata vrsta oglasa.");
            }

            s.CreateSQLQuery(sql)
                .SetParameter("id", oglasId)
                .ExecuteUpdate();
        }

        private static void dodajPosebanRed(
            ISession s,
            OglasBasic p)
        {
            if (p is OglasPraksaBasic praksa)
            {
                s.CreateSQLQuery(@"
            INSERT INTO OGLAS_PRAKSA
                (
                    OGLAS_ID,
                    MENTOR_IME,
                    MENTOR_PREZIME,
                    DUZINA_TRAJANJA
                )
            VALUES
                (
                    :id,
                    :ime,
                    :prezime,
                    :trajanje
                )")
                    .SetParameter("id", p.OglasId)
                    .SetParameter("ime", praksa.MentorIme)
                    .SetParameter("prezime", praksa.MentorPrezime)
                    .SetParameter("trajanje", praksa.DuzinaTrajanja)
                    .ExecuteUpdate();
            }
            else if (p is OglasPrivremeniBasic privremeni)
            {
                s.CreateSQLQuery(@"
            INSERT INTO OGLAS_PRIVREMENI
                (
                    OGLAS_ID,
                    PROJEKAT,
                    DATUM_POCETKA,
                    DATUM_ZAVRSETKA
                )
            VALUES
                (
                    :id,
                    :projekat,
                    :pocetak,
                    :zavrsetak
                )")
                    .SetParameter("id", p.OglasId)
                    .SetParameter("projekat", privremeni.Projekat)
                    .SetParameter("pocetak", privremeni.DatumPocetka)
                    .SetParameter("zavrsetak", privremeni.DatumZavrsetka)
                    .ExecuteUpdate();
            }
            else if (p is OglasSezonskiBasic sezonski)
            {
                s.CreateSQLQuery(@"
            INSERT INTO OGLAS_SEZONSKI
                (
                    OGLAS_ID,
                    SEZONA,
                    LOKACIJA
                )
            VALUES
                (
                    :id,
                    :sezona,
                    :lokacija
                )")
                    .SetParameter("id", p.OglasId)
                    .SetParameter("sezona", sezonski.Sezona)
                    .SetParameter("lokacija", sezonski.Lokacija)
                    .ExecuteUpdate();
            }
            else if (p.VrstaOglasa != VrstaOglasa.STALNI)
            {
                throw new Exception(
                    "DTO objekat ne odgovara izabranoj vrsti oglasa.");
            }
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
                throw new Exception("Greska prilikom brisanja oglasa: " + ec.Message, ec);
            }
        }

        public static OglasBasic vratiOglas(int id)
        {
            using (ISession s = DataLayer.GetSession())
            {
                Oglas o = s.Get<Oglas>(id);

                if (o == null)
                    return null;

                OglasBasic rezultat;

                if (o is OglasPraksa praksa)
                {
                    rezultat = new OglasPraksaBasic
                    {
                        MentorIme = praksa.MentorIme,
                        MentorPrezime = praksa.MentorPrezime,
                        DuzinaTrajanja = praksa.DuzinaTrajanja
                    };
                }
                else if (o is OglasPrivremeni privremeni)
                {
                    rezultat = new OglasPrivremeniBasic
                    {
                        Projekat = privremeni.Projekat,
                        DatumPocetka = privremeni.DatumPocetka,
                        DatumZavrsetka = privremeni.DatumZavrsetka
                    };
                }
                else if (o is OglasSezonski sezonski)
                {
                    rezultat = new OglasSezonskiBasic
                    {
                        Sezona = sezonski.Sezona,
                        Lokacija = sezonski.Lokacija
                    };
                }
                else
                {
                    rezultat = new OglasBasic();
                }

                rezultat.OglasId = o.OglasId;
                rezultat.NazivPozicije = o.NazivPozicije;
                rezultat.VrstaOglasa = o.VrstaOglasa;
                rezultat.Opis = o.Opis;
                rezultat.Zahtevi = o.Zahtevi;
                rezultat.MinPlata = o.MinPlata;
                rezultat.MaxPlata = o.MaxPlata;
                rezultat.DatumObjave = o.DatumObjave;
                rezultat.DatumZatvaranja = o.DatumZatvaranja;
                rezultat.Status = o.Status;

                return rezultat;
            }
        }

        #endregion

        #region OglasPraksa

        public static OglasPraksaBasic vratiOglasPrakse(int id)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                OglasPraksa o = s.Get<OglasPraksa>(id);

                if (o == null)
                    return null;

                return new OglasPraksaBasic(
                    o.OglasId,
                    o.MentorIme,
                    o.MentorPrezime,
                    o.DuzinaTrajanja
                );
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja oglasa prakse: " + ec.Message, ec);
            }
            finally
            {
                s?.Close();
            }
        }

        public static OglasPraksaBasic izmeniOglasPraksu(OglasPraksaBasic opb)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OglasPraksa o = s.Get<OglasPraksa>(opb.OglasId);

                if (o == null)
                {
                    throw new Exception($"Podaci o praksi za oglas sa ID-em {opb.OglasId} ne postoje.");
                }

                o.MentorIme = opb.MentorIme;
                o.MentorPrezime = opb.MentorPrezime;
                o.DuzinaTrajanja = opb.DuzinaTrajanja;

                s.Update(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene oglasa prakse: " + ec.Message, ec);
            }

            return opb;
        }

        #endregion

        #region OglasPrivremeni
        public static OglasPrivremeniBasic vratiOglasPrivremeni(int id)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                OglasPrivremeni o = s.Get<OglasPrivremeni>(id);

                if (o == null)
                    return null;

                return new OglasPrivremeniBasic(
                    o.OglasId,
                    o.Projekat,
                    o.DatumPocetka,
                    o.DatumZavrsetka
                );
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja privremenog oglasa: " + ec.Message, ec);
            }
            finally
            {
                s?.Close();
            }
        }

        public static OglasPrivremeniBasic izmeniOglasPrivremeni(OglasPrivremeniBasic opb)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OglasPrivremeni o = s.Get<OglasPrivremeni>(opb.OglasId);

                if (o == null)
                {
                    throw new Exception($"Podaci o privremenom oglasu sa ID-em {opb.OglasId} ne postoje.");
                }

                if (opb.DatumPocetka > opb.DatumZavrsetka)
                {
                    throw new Exception(
                        "Datum pocetka ne moze biti posle datuma zavrsetka.");
                }

                o.Projekat = opb.Projekat;
                o.DatumPocetka = opb.DatumPocetka;
                o.DatumZavrsetka = opb.DatumZavrsetka;

                s.Update(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene privremenog oglasa: " + ec.Message, ec);
            }

            return opb;
        }

        #endregion

        #region OglasSezonski

        public static OglasSezonskiBasic vratiOglasSezonski(int id)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                OglasSezonski o = s.Get<OglasSezonski>(id);

                if (o == null)
                    return null;

                return new OglasSezonskiBasic(
                    o.OglasId,
                    o.Sezona,
                    o.Lokacija
                );
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja sezonskog oglasa: " + ec.Message, ec);
            }
            finally
            {
                s?.Close();
            }
        }

        public static OglasSezonskiBasic izmeniOglasSezonski(OglasSezonskiBasic opb)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                OglasSezonski o = s.Get<OglasSezonski>(opb.OglasId);

                if (o == null)
                {
                    throw new Exception($"Podaci o sezonskom oglasu sa ID-em {opb.OglasId} ne postoje.");
                }

                o.Sezona = opb.Sezona;
                o.Lokacija = opb.Lokacija;

                s.Update(o);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene sezonskog oglasa: " + ec.Message, ec);
            }

            return opb;
        }

        #endregion

        #region CV

        public static List<CVPregled> vratiCVPrijaveOglasa(int oglasId)
        {
            List<CVPregled> prijave = new List<CVPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    IList<CV> cvPrijave = s.Query<CV>()
                        .Where(cv => cv.Oglas.OglasId == oglasId)
                        .OrderByDescending(cv => cv.DatumPodnosenja)
                        .ToList();

                    foreach (CV cv in cvPrijave)
                    {
                        CVPregled pregled = new CVPregled
                        {
                            CvId = cv.CvId,
                            Ime = cv.Ime,
                            Prezime = cv.Prezime,
                            Email = cv.Email,
                            Telefon = cv.Telefon,
                            DatumPodnosenja = cv.DatumPodnosenja,
                            Status = cv.Status,
                            OglasID = cv.Oglas.OglasId
                        };

                        prijave.Add(pregled);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Greska prilikom ucitavanja CV prijava za izabrani oglas.",
                    ex);
            }

            return prijave;
        }

        public static void dodajCV(CVBasic cv, int oglasId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Oglas oglas = s.Load<Oglas>(oglasId);

                CV c = new CV();

                c.Ime = cv.Ime;
                c.Prezime = cv.Prezime;
                c.Email = cv.Email;
                c.Telefon = cv.Telefon;
                c.DatumPodnosenja = cv.DatumPodnosenja;
                c.Status = cv.Status;
                c.Oglas = oglas;

                s.Save(c);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom dodavanja oglasa: " + ec.Message, ec);
            }
        }

        public static void izmeniCV(CVBasic cv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CV c = s.Load<CV>(cv.CvId);

                c.Ime = cv.Ime;
                c.Prezime = cv.Prezime;
                c.Email = cv.Email;
                c.Telefon = cv.Telefon;
                c.Status = cv.Status;

                s.Update(c);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene CV-ja za oglas: " + ec.Message, ec);
            }
        }

        public static void obrisiCV(int CvId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CV cv = s.Load<CV>(CvId);

                s.Delete(cv);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom brisanja CV-ja za oglas: " + ec.Message, ec);
            }
        }

        public static Result<bool, ErrorMessage> ObrisiCVPrijavu(int cvId)
        {
            try
            {
                using (ISession session = DataLayer.GetSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    CV cv = session.Get<CV>(cvId);

                    if (cv == null)
                    {
                        return "Izabrana CV prijava vise ne postoji.".ToError(404);
                    }

                    session.Delete(cv);
                    transaction.Commit();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return ex.HandleError().ToError(500);
            }
        }

        public static CVBasic vratiCV(int idCv)
        {
            CVBasic cvb = new CVBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                CV cv = s.Load<CV>(idCv);
                cvb = new CVBasic(cv.CvId, cv.Ime, cv.Prezime, cv.Email, cv.Telefon, cv.DatumPodnosenja, cv.Status);

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja oglasa: " + ec.Message, ec);
            }

            return cvb;
        }

        public static Result<List<CVPregled>, ErrorMessage> vratiSveCVPrijave()
        {
            List<CVPregled> rezultat = new List<CVPregled>();

            try
            {
                using (ISession session = DataLayer.GetSession())
                {
                    IList<CV> prijave = session.Query<CV>().ToList();

                    foreach (CV cv in prijave)
                    {
                        rezultat.Add(new CVPregled(
                            cv.CvId,
                            cv.Ime,
                            cv.Prezime,
                            cv.Email,
                            cv.Telefon,
                            cv.DatumPodnosenja,
                            cv.Status,
                            cv.Oglas.OglasId
                        ));
                    }
                }

                return rezultat;
            }
            catch (Exception ex)
            {
                return ex.HandleError().ToError(500);
            }
        }

        #endregion

        #region Intervju

        public static List<IntervjuPregled> vratiIntervjueCVPrijave(int idCv)
        {
            List<IntervjuPregled> intervjui = new List<IntervjuPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    IList<Intervju> intervjui_cv = s.Query<Intervju>()
                        .Where(i => i.CV.CvId == idCv)
                        .ToList();

                    foreach (Intervju i in intervjui_cv)
                    {
                        IntervjuPregled intervju = new IntervjuPregled
                        {
                            IntervjuId = i.IntervjuId,
                            Datum = i.Datum,
                            Vreme = i.Vreme,
                            Tip = i.Tip,
                            Lokacija = i.Lokacija,
                            ZaposleniIme = i.ZaposleniIme,
                            ZaposleniPrezime = i.ZaposleniPrezime,
                            Ocena = i.Ocena,
                            Napomene = i.Napomene,
                            CVid = i.CV.CvId
                        };

                        intervjui.Add(intervju);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Greska prilikom ucitavanja intervjua za odabrani CV.",
                    ex);
            }

            return intervjui;
        }

        public static void dodajIntervju(IntervjuBasic intervju, int idCv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CV cv = s.Load<CV>(idCv);

                Intervju i = new Intervju();

                i.CV = cv;
                i.Datum = intervju.Datum;
                i.Vreme = intervju.Vreme;
                i.Tip = intervju.Tip;
                i.Lokacija = intervju.Lokacija;
                i.ZaposleniIme = intervju.ZaposleniIme;
                i.ZaposleniPrezime = intervju.ZaposleniPrezime;
                i.Ocena = intervju.Ocena;
                i.Napomene = intervju.Napomene;

                s.Save(i);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom dodavanja intervjua za CV: " + ec.Message, ec);
            }
        }
        public static void izmeniIntervju(IntervjuBasic intervju)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Intervju i = s.Load<Intervju>(intervju.IntervjuId);

                i.Datum = intervju.Datum;
                i.Vreme = intervju.Vreme;
                i.Tip = intervju.Tip;
                i.Lokacija = intervju.Lokacija;
                i.ZaposleniIme = intervju.ZaposleniIme;
                i.ZaposleniPrezime = intervju.ZaposleniPrezime;
                i.Ocena = intervju.Ocena;
                i.Napomene = intervju.Napomene;

                s.Update(i);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene intervjua za CV: " + ec.Message, ec);
            }
        }

        public static void obrisiIntervju(int intervjuId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Intervju intervju = s.Load<Intervju>(intervjuId);

                s.Delete(intervju);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom brisanja intervjua za CV: " + ec.Message, ec);
            }
        }

        public static IntervjuBasic vratiIntervju(int id)
        {
            IntervjuBasic ib = new IntervjuBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Intervju intervju = s.Load<Intervju>(id);
                ib = new IntervjuBasic(intervju.IntervjuId, intervju.Datum, intervju.Vreme, intervju.Tip, intervju.Lokacija,
                     intervju.ZaposleniIme, intervju.ZaposleniPrezime, intervju.Ocena, intervju.Napomene);

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja intervjua: " + ec.Message, ec);
            }

            return ib;
        }

        #endregion

        #region Test

        public static List<TestPregled> vratiTestoveCVPrijave(int idCv)
        {
            List<TestPregled> testovi = new List<TestPregled>();

            try
            {
                using (ISession s = DataLayer.GetSession())
                {
                    IList<Test> testovi_cv = s.Query<Test>()
                        .Where(i => i.CV.CvId == idCv)
                        .ToList();

                    foreach (Test t in testovi_cv)
                    {
                        TestPregled test = new TestPregled
                        {
                            TestId = t.TestId,
                            Rezultat = t.Rezultat,
                            DatumTestiranja = t.DatumTestiranja,
                            VrstaTestiranja = t.VrstaTestiranja,
                            Komentar = t.Komentar,
                            CVid = t.CV.CvId
                        };

                        testovi.Add(test);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Greska prilikom ucitavanja testova za odabrani CV.",
                    ex);
            }

            return testovi;
        }

        public static void dodajTest(TestBasic test, int idCv)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                CV cv = s.Load<CV>(idCv);

                Test t = new Test();

                t.CV = cv;
                t.Rezultat = test.Rezultat;
                t.DatumTestiranja = test.DatumTestiranja;
                t.VrstaTestiranja = test.VrstaTestiranja;
                t.Komentar = test.Komentar;

                s.Save(t);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom dodavanja testa za CV: " + ec.Message, ec);
            }
        }

        public static void izmeniTest(TestBasic test)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Test t = s.Load<Test>(test.TestId);

                t.Rezultat = test.Rezultat;
                t.DatumTestiranja = test.DatumTestiranja;
                t.VrstaTestiranja = test.VrstaTestiranja;
                t.Komentar = test.Komentar;

                s.Update(t);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom izmene testa za CV: " + ec.Message, ec);
            }
        }

        public static void obrisiTest(int testId)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Test test = s.Load<Test>(testId);

                s.Delete(test);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom brisanja testa za CV: " + ec.Message, ec);
            }
        }

        public static TestBasic vratiTest(int id)
        {
            TestBasic tb = new TestBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Test test = s.Load<Test>(id);
                tb = new TestBasic(test.TestId, test.Rezultat, test.DatumTestiranja, test.VrstaTestiranja, test.Komentar);

                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception("Greska prilikom vracanja testa: " + ec.Message, ec);
            }

            return tb;
        }

        #endregion

        #region Odluka

        public static OdlukaBasic vratiOdlukuZaCV(int cvId)
        {
            using (ISession s = DataLayer.GetSession())
            {
                try
                {
                    Odluka o = s.Query<Odluka>()
                        .FirstOrDefault(x => x.CV.CvId == cvId);

                    if (o == null)
                        return null;

                    return new OdlukaBasic
                    {
                        OdlukaId = o.OdlukaId,
                        Status = o.Status,
                        DatumDonosenjaOdluke = o.DatumDonosenjaOdluke,
                        PonudjenaPlata = o.PonudjenaPlata,
                        PrihvatioPonudu = o.PrihvatioPonudu,
                        DatumPocetkaRada = o.DatumPocetkaRada,
                        RazlogOdbijanja = o.RazlogOdbijanja
                    };
                }
                catch (Exception ec)
                {
                    throw new Exception(
                        "Greska prilikom vracanja odluke: "
                        + ec.Message, ec);
                }
            }
        }

        public static void dodajOdluku(OdlukaBasic ob, int cvId)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                CV cv = s.Get<CV>(cvId);

                if (cv == null)
                {
                    throw new Exception($"CV sa ID-em {cvId} ne postoji.");
                }

                bool odlukaPostoji = s.Query<Odluka>()
                    .Any(x => x.CV.CvId == cvId);

                if (odlukaPostoji)
                {
                    throw new Exception("Za izabrani CV vec postoji odluka.");
                }

                Odluka o = new Odluka
                {
                    CV = cv,
                    Status = ob.Status,
                    DatumDonosenjaOdluke = ob.DatumDonosenjaOdluke,
                    PonudjenaPlata = ob.PonudjenaPlata,
                    PrihvatioPonudu = ob.PrihvatioPonudu,
                    DatumPocetkaRada = ob.DatumPocetkaRada,
                    RazlogOdbijanja = ob.RazlogOdbijanja
                };

                s.Save(o);

                ob.OdlukaId = o.OdlukaId;

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                throw new Exception(
                    "Greska prilikom dodavanja odluke: "
                    + ec.Message, ec);
            }
        }

        public static void izmeniOdluku(OdlukaBasic ob)
        {
            ISession s = null;

            try
            {
                s = DataLayer.GetSession();

                Odluka o = s.Get<Odluka>(ob.OdlukaId);

                if (o == null)
                {
                    throw new Exception($"Odluka sa ID-em {ob.OdlukaId} ne postoji.");
                }

                o.Status = ob.Status;
                o.PonudjenaPlata = ob.PonudjenaPlata;
                o.PrihvatioPonudu = ob.PrihvatioPonudu;
                o.DatumPocetkaRada = ob.DatumPocetkaRada;
                o.RazlogOdbijanja = ob.RazlogOdbijanja;

                s.Update(o);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                throw new Exception(
                    "Greska prilikom izmene odluke: "
                    + ec.Message, ec);
            }
        }

        #endregion
    }
}
