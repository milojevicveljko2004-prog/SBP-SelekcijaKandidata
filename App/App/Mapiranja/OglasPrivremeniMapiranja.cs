using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
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
