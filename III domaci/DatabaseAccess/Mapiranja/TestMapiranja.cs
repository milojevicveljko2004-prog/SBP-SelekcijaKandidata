using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mapiranja
{
    public class TestMapiranja : ClassMap<Test>
    {
        public TestMapiranja()
        {

            Table("TEST");

            Id(x => x.TestId, "TEST_ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Rezultat, "REZULTAT");
            Map(x => x.DatumTestiranja, "DATUM_TESTIRANJA");
            Map(x => x.VrstaTestiranja, "VRSTA_TESTIRANJA");
            Map(x => x.Komentar, "KOMENTAR");

            References(x => x.CV)
                .Column("CV_ID")
                .Not.Nullable();
        }
    }
}
