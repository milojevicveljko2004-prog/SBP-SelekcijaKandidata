using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class OglasPrivremeni
    {
        public virtual int OglasId { get; protected set; }
        public virtual Oglas Oglas { get; set; }

        public virtual string Projekat { get; set; } = string.Empty;
        public virtual string PeriodAngazovanja { get; set; } = string.Empty;

        public OglasPrivremeni()
        {
        }
    }
}
