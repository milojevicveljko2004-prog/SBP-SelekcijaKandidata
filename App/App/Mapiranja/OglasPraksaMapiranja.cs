using App.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapiranja
{
    public class OglasPraksaMapiranja : ClassMap<OglasPraksa>
    {
        public OglasPraksaMapiranja()
        {
            Table("OGLAS_PRAKSA");

            Id(x => x.OglasId, "OGLAS_ID")
                .GeneratedBy.Foreign("Oglas");

            HasOne(x => x.Oglas)
                .Constrained();

            Map(x => x.MentorIme, "MENTOR_IME");
            Map(x => x.MentorPrezime, "MENTOR_PREZIME");
            Map(x => x.DuzinaTrajanja, "DUZINA_TRAJANJA");
        }
    }
}
