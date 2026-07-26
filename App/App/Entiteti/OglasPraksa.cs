using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class OglasPraksa : Oglas
    {
        public virtual string MentorIme { get; set; } = string.Empty;
        public virtual string MentorPrezime { get; set; } = string.Empty;
        public virtual int DuzinaTrajanja { get; set; }

        public OglasPraksa()
        {
        }
    }
}
