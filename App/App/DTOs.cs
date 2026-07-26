using App.Entiteti;
using App.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    //Pregled klase se koriste kada se podaci trebaju samo prikazati(citanje/ispis) bez da se vracaju u bazu
    //Basic klase se koriste kada korisnik menja ili unosi nove podatke - dakle menja bazu
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

    #region OglasPraksa

    public class OglasPraksaBasic : OglasBasic
    {
        public string MentorIme;
        public string MentorPrezime;
        public int DuzinaTrajanja;

        public OglasPraksaBasic() : base()
        {

        }

        //Za kreiranje novog oglasa
        public OglasPraksaBasic(string MentorIme, string MentorPrezime, int DuzinaTrajanja) : base()
        {
            this.MentorIme = MentorIme;
            this.MentorPrezime = MentorPrezime;
            this.DuzinaTrajanja = DuzinaTrajanja;
        }

        //Za vracanje postojeceg oglasa iz baze
        public OglasPraksaBasic(
            int oglasId,
            string mentorIme,
            string mentorPrezime,
            int duzinaTrajanja) : base()
        {
            OglasId = oglasId;
            MentorIme = mentorIme;
            MentorPrezime = mentorPrezime;
            DuzinaTrajanja = duzinaTrajanja;
        }
    }

    #endregion

    #region OglasPrivremeni

    public class OglasPrivremeniBasic : OglasBasic
    {
        public string Projekat;
        public DateTime DatumPocetka;
        public DateTime DatumZavrsetka;

        public OglasPrivremeniBasic() : base()
        {
            
        }

        //Za kreiranje novog oglasa
        public OglasPrivremeniBasic(int oglasId, string projekat, DateTime datumPocetka, DateTime datumZavrsetka) : base()
        {
            this.OglasId = oglasId;
            this.Projekat = projekat;
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
        }

        //Za vracanje postojeceg oglasa iz baze
        public OglasPrivremeniBasic(string projekat, DateTime datumPocetka, DateTime datumZavrsetka) : base()
        {
            this.Projekat = projekat;
            this.DatumPocetka = datumPocetka;
            this.DatumZavrsetka = datumZavrsetka;
        }
    }

    #endregion

    #region OglasSezonski

    public class OglasSezonskiBasic : OglasBasic
    {
        public string Sezona;
        public string Lokacija;

        public OglasSezonskiBasic() : base()
        {

        }

        //Za kreiranje novog oglasa
        public OglasSezonskiBasic(string sezona, string lokacija) : base()
        {
            this.Sezona = sezona;
            this.Lokacija = lokacija;
        }

        //Za vracanje postojeceg oglasa iz baze
        public OglasSezonskiBasic(int oglasId, string sezona, string lokacija) : base()
        {
            this.OglasId = oglasId;
            this.Sezona = sezona;
            this.Lokacija = lokacija;
        }
    }

    #endregion

    #region CV

    public class CVPregled
    {
        public int CvId;
        public string Ime;
        public string Prezime;
        public string Email;
        public string Telefon;
        public DateTime DatumPodnosenja;
        public CVStatus Status;

        public CVPregled()
        { 

        }

        public CVPregled(int cvId, string ime, string prezime, string email, string telefon, DateTime datumPodnosenja, CVStatus status) : this()
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

    public class IntervjuPregled
    {
        public int IntervjuId;
        public DateTime Datum;
        public DateTime Vreme;
        public TipIntervjua Tip;
        public string Lokacija;
        public string ZaposleniIme;
        public string ZaposleniPrezime;
        public int Ocena;
        public string Napomene;

        public IntervjuPregled()
        {

        }

        public IntervjuPregled(int intervjuId, DateTime datum, DateTime vreme, TipIntervjua tip, string lokacija,
            string zaposleniIme, string zaposleniPrezime, int ocena, string napomene)
        {
            IntervjuId = intervjuId;
            Datum = datum;
            Vreme = vreme;
            Tip = tip;
            Lokacija = lokacija;
            ZaposleniIme = zaposleniIme;
            ZaposleniPrezime = zaposleniPrezime;
            Ocena = ocena;
            Napomene = napomene;
        }
    }

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
