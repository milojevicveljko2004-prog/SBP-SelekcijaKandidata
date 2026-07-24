using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{
    public class OglasPrivremeniMapiranja : ClassMap<OglasPrivremeni>
    {
        public OglasPrivremeniMapiranja()
        {
            Table("OGLAS_PRIVREMENI");

            Id(x => x.OglasId, "OGLAS_ID")
                .GeneratedBy.Foreign("Oglas");

            HasOne(x => x.Oglas)
                .Constrained();

            Map(x => x.Projekat, "PROJEKAT");
            Map(x => x.PeriodAngazovanja, "PERIOD_ANGAZOVANJA");
        }
    }
}
