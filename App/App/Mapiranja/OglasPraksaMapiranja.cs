using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{                                   //Subclass jer je izvedena klasa
    public class OglasPraksaMapiranja : SubclassMap<OglasPraksa>
    {
        public OglasPraksaMapiranja()
        {
            Table("OGLAS_PRAKSA");

            KeyColumn("OGLAS_ID");

            Map(x => x.MentorIme, "MENTOR_IME");
            Map(x => x.MentorPrezime, "MENTOR_PREZIME");
            Map(x => x.DuzinaTrajanja, "DUZINA_TRAJANJA");
        }
    }
}
