using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class Intervju
    {
        public virtual int IntervjuId { get; protected set; }

        public virtual DateTime DatumIntervjua { get; set; }
        public virtual string VremeIntervjua { get; set; }
        public virtual string TipIntervjua { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string ImeZaposlenog { get; set; }
        public virtual string PrezimeZaposlenog { get; set; }
        public virtual int? Ocena { get; set; }
        public virtual string Napomene { get; set; }

        public virtual CV CV { get; set; }

        public Intervju()
        {
        }
    }
}
