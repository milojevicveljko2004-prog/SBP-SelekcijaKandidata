using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class OglasPraksa
    {
        public virtual int OglasId { get; protected set; }
        public virtual Oglas Oglas { get; set; }

        public virtual string MentorIme { get; set; } = string.Empty;
        public virtual string MentorPrezime { get; set; } = string.Empty;
        public virtual int DuzinaTrajanja { get; set; }

        public OglasPraksa()
        {
        }
    }
}
