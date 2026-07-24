using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{
    public class OglasSezonskiMapiranja : ClassMap<OglasSezonski>
    {
        public OglasSezonskiMapiranja()
        {
            Table("OGLAS_SEZONSKI");

            Id(x => x.OglasId, "OGLAS_ID")
                .GeneratedBy.Foreign("Oglas");

            HasOne(x => x.Oglas)
                .Constrained();

            Map(x => x.Sezona, "SEZONA");
            Map(x => x.Lokacija, "LOKACIJA");
        }
    }
}
