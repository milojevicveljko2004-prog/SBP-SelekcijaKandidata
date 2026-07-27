using App.Entiteti.Enums;
using System;
using System.Collections.Generic;

namespace App.Entiteti
{
    public class Odluka
    {
        public virtual int OdlukaId { get; protected set; }

        public virtual CV CV { get; set; }
        public virtual StatusOdluke Status { get; set; }
        public virtual DateTime DatumDonosenjaOdluke { get; set; }
        public virtual decimal? PonudjenaPlata { get; set; }
        public virtual bool? PrihvatioPonudu { get; set; }
        public virtual DateTime? DatumPocetkaRada { get; set; }
        public virtual string RazlogOdbijanja { get; set; }
    }
}
