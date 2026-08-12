using DatabaseAccess.Entiteti.Enums;

namespace DatabaseAccess.Entiteti
{
    public class CV
    {
        public virtual int CvId { get; protected set; }

        public virtual string Ime { get; set; } = string.Empty;
        public virtual string Prezime { get; set; } = string.Empty;
        public virtual string Email { get; set; } = string.Empty;
        public virtual string Telefon { get; set; } = string.Empty;
        public virtual DateTime DatumPodnosenja { get; set; }
        public virtual CVStatus Status { get; set; }

        public virtual Oglas Oglas { get; set; }

        public virtual IList<Intervju> Intervjui { get; set; }
        public virtual IList<Test> Testovi { get; set; }

        public virtual Odluka Odluka { get; set; }

        public CV()
        {
            Intervjui = new List<Intervju>();
            Testovi = new List<Test>();
        }
    }
}
