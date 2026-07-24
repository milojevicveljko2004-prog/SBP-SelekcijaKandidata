using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{
    public class TestMapiranja : ClassMap<Test>
    {
        public TestMapiranja()
        {
            //mapiranje tabele, kljuca i svojstava

            Table("TEST");

            Id(x => x.TestId, "TEST_ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Rezultat, "REZULTAT");
            Map(x => x.DatumTestiranja, "DATUM_TESTIRANJA");
            Map(x => x.VrstaTestiranja, "VRSTA_TESTIRANJA");
            Map(x => x.Komentar, "KOMENTAR");

            //mapiranje veza

            References(x => x.CV)
                .Column("CV_ID")
                .Not.Nullable();
        }
    }
}
