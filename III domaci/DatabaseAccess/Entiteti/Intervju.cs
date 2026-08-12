using DatabaseAccess.Entiteti.Enums;

namespace DatabaseAccess.Entiteti
{
    public class Intervju
    {
        public virtual int IntervjuId { get; protected set; }

        public virtual DateTime Datum { get; set; }
        public virtual DateTime Vreme { get; set; }
        public virtual TipIntervjua Tip { get; set; }
        public virtual string Lokacija { get; set; } = string.Empty;
        public virtual string ZaposleniIme { get; set; } = string.Empty;
        public virtual string ZaposleniPrezime { get; set; } = string.Empty;
        public virtual int Ocena { get; set; }
        public virtual string Napomene { get; set; }

        public virtual CV CV { get; set; }

        public Intervju()
        {
        }
    }
}
