using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class OglasSezonski
    {
        public virtual int OglasId { get; protected set; }
        public virtual Oglas Oglas { get; set; }

        public virtual string Sezona { get; set; } = string.Empty;
        public virtual string Lokacija { get; set; } = string.Empty;

        public OglasSezonski()
        {
        }
    }
}
