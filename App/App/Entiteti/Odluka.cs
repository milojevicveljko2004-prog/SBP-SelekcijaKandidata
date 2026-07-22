using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class Odluka
    {
        public virtual int OdlukaId { get; protected set; }

        public virtual string Status { get; set; }
        public virtual DateTime DatumDonosenjaOdluke { get; set; }
        public virtual decimal? PonudjenaPlata { get; set; }
        public virtual string PrihvatioPonudu { get; set; }
        public virtual DateTime? DatumPocetkaRada { get; set; }
        public virtual string RazlogOdbijanja { get; set; }

        public virtual CV CV { get; set; }

        public Odluka()
        {
        }
    }
}
