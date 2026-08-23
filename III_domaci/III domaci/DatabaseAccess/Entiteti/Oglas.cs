using DatabaseAccess.Entiteti.Enums;

namespace DatabaseAccess.Entiteti
{
    public class Oglas
    {
        public virtual int OglasId { get; protected set; }

        public virtual string NazivPozicije { get; set; } = string.Empty;

        public virtual VrstaOglasa VrstaOglasa { get; set; }

        public virtual string Opis { get; set; }

        public virtual string Zahtevi { get; set; }

        public virtual decimal? MinPlata { get; set; }

        public virtual decimal? MaxPlata { get; set; }

        public virtual DateTime DatumObjave { get; set; }

        public virtual DateTime? DatumZatvaranja { get; set; }

        public virtual StatusOglasa Status { get; set; }

        public virtual IList<CV> CVjevi { get; set; }

        public Oglas()
        {
            CVjevi = new List<CV>();
        }
    }
}
