using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class OglasSezonskiMapiranja : SubclassMap<OglasSezonski>
    {
        public OglasSezonskiMapiranja()
        {
            Table("OGLAS_SEZONSKI");

            KeyColumn("OGLAS_ID");

            Map(x => x.Sezona, "SEZONA");
            Map(x => x.Lokacija, "LOKACIJA");
        }
    }
}
