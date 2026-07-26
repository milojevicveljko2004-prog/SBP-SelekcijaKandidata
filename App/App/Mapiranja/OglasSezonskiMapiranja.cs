using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
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
