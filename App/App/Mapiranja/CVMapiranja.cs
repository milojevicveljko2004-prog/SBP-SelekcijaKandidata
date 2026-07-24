using App.Entiteti.Enums;
using App.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{
    public class CVMapiranja : ClassMap<CV>
    {
        public CVMapiranja()
        {
            //mapiranje tabele, kljuca i svojstava

            Table("CV");

            Id(x => x.CvId, "CV_ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Email, "EMAIL");
            Map(x => x.Telefon, "TELEFON");
            Map(x => x.DatumPodnosenja, "DATUM_PODNOSENJA");

            Map(x => x.Status, "STATUS")
                .CustomType<EnumStringType<CVStatus>>();

            //mapiranje veza

            References(x => x.Oglas)
                .Column("OGLAS_ID")
                .Not.Nullable();

            HasMany(x => x.Intervjui)
                .KeyColumn("CV_ID")
                .Inverse()
                .Cascade.All();

            HasMany(x => x.Testovi)
                .KeyColumn("CV_ID")
                .Inverse()
                .Cascade.All();

            HasOne(x => x.Odluka)
                .PropertyRef(x => x.CV)
                .Cascade.All();
        }
    }
}
