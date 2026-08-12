namespace DatabaseAccess.Entiteti
{
    public class OglasPrivremeni : Oglas
    {
        public virtual string Projekat { get; set; } = string.Empty;

        public virtual DateTime DatumPocetka { get; set; }

        public virtual DateTime DatumZavrsetka { get; set; }

        public OglasPrivremeni()
        {
        }
    }
}
