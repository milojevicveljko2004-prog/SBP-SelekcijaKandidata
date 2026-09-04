using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{                                       //Subclass jer je izvedena klasa
    public class OglasSezonskiMapiranja : SubclassMap<OglasSezonski>
    {
        public OglasSezonskiMapiranja()
        {
            //mapiranje tabele, kljuca i svojstava

            Table("OGLAS_SEZONSKI");

            KeyColumn("OGLAS_ID");

            Map(x => x.Sezona, "SEZONA");
            Map(x => x.Lokacija, "LOKACIJA");
        }
    }
}
