using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class OglasPraksaMapiranja : SubclassMap<OglasPraksa>
    {
        public OglasPraksaMapiranja()
        {
            Table("OGLAS_PRAKSA");

            KeyColumn("OGLAS_ID");

            Map(x => x.MentorIme, "MENTOR_IME");
            Map(x => x.MentorPrezime, "MENTOR_PREZIME");
            Map(x => x.DuzinaTrajanja, "DUZINA_TRAJANJA");
        }
    }
}
