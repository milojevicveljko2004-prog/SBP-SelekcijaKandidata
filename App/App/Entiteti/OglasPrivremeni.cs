using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class OglasPrivremeni : Oglas
    {
        public virtual string Projekat { get; set; } = string.Empty;

        public virtual DateTime DatumPocetka { get; set; }

        public virtual DateTime DatumZavrsetka { get; set; }

        public OglasPrivremeni()
        {
        }
    }
}
