using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace App.Entiteti
{
    public class CV
    {
        public virtual int CvId { get; protected set; }

        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefon { get; set; }
        public virtual DateTime DatumPodnosenja { get; set; }
        public virtual string Status { get; set; }

        public virtual Oglas Oglas { get; set; }

        public virtual IList<Intervju> Intervjui { get; set; }
        public virtual IList<Test> Testovi { get; set; }

        public virtual Odluka Odluka { get; set; }

        public CV()
        {
            Intervjui = new List<Intervju>();
            Testovi = new List<Test>();
        }
    }
}
