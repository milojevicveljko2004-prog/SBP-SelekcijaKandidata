using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class OglasPrivremeniMapiranja : SubclassMap<OglasPrivremeni>
    {
        public OglasPrivremeniMapiranja()
        {
            Table("OGLAS_PRIVREMENI");

            KeyColumn("OGLAS_ID");

            Map(x => x.Projekat, "PROJEKAT");
            Map(x => x.DatumPocetka, "DATUM_POCETKA");
            Map(x => x.DatumZavrsetka, "DATUM_ZAVRSETKA");
        }
    }
}
