using App.Entiteti;
using App.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    #region Oglas
    public class OglasPregled
    {
        public int OglasId;
        public string NazivPozicije;
        public VrstaOglasa VrstaOglasa;
        public string Opis;
        public string Zahtevi;
        public decimal? MinPlata;
        public decimal? MaxPlata;
        public DateTime DatumObjave;
        public DateTime? DatumZatvaranja;
        public StatusOglasa Status;

        public OglasPregled()
        {

        }

        public OglasPregled(int oglasId, string NazivPozicije, VrstaOglasa VrstaOglasa, string Opis,
            string Zahtevi, decimal? MinPlata, decimal? MaxPlata, DateTime DatumObjave, DateTime? DatumZatvaranja,
            StatusOglasa Status)
        {
            this.OglasId = oglasId;
            this.NazivPozicije = NazivPozicije;
            this.VrstaOglasa = VrstaOglasa;
            this.Opis = Opis;
            this.Zahtevi = Zahtevi;
            this.MinPlata = MinPlata;
            this.MaxPlata = MaxPlata;
            this.DatumObjave = DatumObjave;
            this.DatumZatvaranja = DatumZatvaranja;
            this.Status = Status;
        }
    }

    public class OglasBasic
    {
        public int OglasId;
        public string NazivPozicije;
        public VrstaOglasa VrstaOglasa;
        public string Opis;
        public string Zahtevi;
        public decimal? MinPlata;
        public decimal? MaxPlata;
        public DateTime DatumObjave;
        public DateTime? DatumZatvaranja;
        public StatusOglasa Status;

        public virtual IList<CVBasic> CVjevi { get; set; }

        public OglasBasic()
        {
            CVjevi = new List<CVBasic>();
        }

        public OglasBasic(int oglasId, string NazivPozicije, VrstaOglasa VrstaOglasa, string Opis,
            string Zahtevi, decimal? MinPlata, decimal? MaxPlata, DateTime DatumObjave, DateTime? DatumZatvaranja,
            StatusOglasa Status) : this()
        {
            this.OglasId = oglasId;
            this.NazivPozicije = NazivPozicije;
            this.VrstaOglasa = VrstaOglasa;
            this.Opis = Opis;
            this.Zahtevi = Zahtevi;
            this.MinPlata = MinPlata;
            this.MaxPlata = MaxPlata;
            this.DatumObjave = DatumObjave;
            this.DatumZatvaranja = DatumZatvaranja;
            this.Status = Status;
        }

    }

    #endregion

    #region CV

    public class CVBasic
    {
        public int CvId;
        public string Ime;
        public string Prezime;
        public string Email;
        public string Telefon;
        public DateTime DatumPodnosenja;
        public CVStatus Status;

        public virtual IList<IntervjuBasic> Intervjui { get; set; }
        public virtual IList<TestBasic> Testovi { get; set; }

        public CVBasic()
        {
            Intervjui = new List<IntervjuBasic>();
            Testovi = new List<TestBasic>();
        }

        public CVBasic(int cvId, string ime, string prezime, string email, string telefon, DateTime datumPodnosenja, CVStatus status) : this()
        {
            CvId = cvId;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Telefon = telefon;
            DatumPodnosenja = datumPodnosenja;
            Status = status;
        }
    }

    #endregion

    #region Intervju

    public class IntervjuBasic
    {
        public int IntervjuId;
        public DateTime Datum;
        public string Vreme;
        public TipIntervjua Tip;
        public string Lokacija;
        public string ZaposleniIme;
        public string ZaposleniPrezime;
        public int Ocena;
        public string Napomene;

        public IntervjuBasic()
        {

        }

        public IntervjuBasic(int IntervjuId, DateTime Datum, string Vreme, TipIntervjua Tip, string Lokacija,
            string ZaposleniIme, string ZaposleniPrezime, int Ocena, string Napomene)
        {
            this.IntervjuId = IntervjuId;
            this.Datum = Datum;
            this.Vreme = Vreme;
            this.Tip = Tip;
            this.Lokacija = Lokacija;
            this.ZaposleniIme = ZaposleniIme;
            this.ZaposleniPrezime = ZaposleniPrezime;
            this.Ocena = Ocena;
            this.Napomene = Napomene;
        }
    }

    #endregion

    #region Test

    public class TestBasic 
    {
        public int TestId;
        public decimal Rezultat;
        public DateTime DatumTestiranja;
        public string VrstaTestiranja;
        public string Komentar;

        public TestBasic()
        {
            
        }

         public TestBasic(int TestId, decimal Rezultat, DateTime DatumTestiranja, string VrstaTestiranja, string Komentar)
         {
            this.TestId = TestId;
            this.Rezultat = Rezultat;
            this.DatumTestiranja = DatumTestiranja;
            this.VrstaTestiranja = VrstaTestiranja;
            this.Komentar = Komentar;
         }
    }

    #endregion
}
