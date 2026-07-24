using App.Entiteti.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entiteti
{
    public class Oglas
    {
        public virtual int OglasId { get; protected set; }

        public virtual string NazivPozicije { get; set; } = string.Empty;

        public virtual VrstaOglasa VrstaOglasa { get; set; }

        public virtual string Opis { get; set; }

        public virtual string Zahtevi { get; set; }

        public virtual decimal? MinPlata { get; set; }

        public virtual decimal? MaxPlata { get; set; }

        public virtual DateTime DatumObjave { get; set; }

        public virtual DateTime? DatumZatvaranja { get; set; }

        public virtual StatusOglasa Status { get; set; }

        public virtual IList<CV> CVjevi { get; set; }

        public virtual OglasPraksa PodaciPraksa { get; set; }
        public virtual OglasPrivremeni PodaciPrivremeni { get; set; }
        public virtual OglasSezonski PodaciSezonski { get; set; }

        public Oglas()
        {
            CVjevi = new List<CV>();
        }
    }
}
