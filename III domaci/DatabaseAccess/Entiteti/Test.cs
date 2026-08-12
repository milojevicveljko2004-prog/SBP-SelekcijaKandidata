namespace DatabaseAccess.Entiteti
{
    public class Test
    {
        public virtual int TestId { get; protected set; }

        public virtual decimal Rezultat { get; set; }
        public virtual DateTime DatumTestiranja { get; set; }
        public virtual string VrstaTestiranja { get; set; } = string.Empty;
        public virtual string Komentar { get; set; }

        public virtual CV CV { get; set; }

        public Test()
        {
        }
    }
}
