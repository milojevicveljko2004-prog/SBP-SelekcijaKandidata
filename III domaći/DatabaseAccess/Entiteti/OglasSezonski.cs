namespace DatabaseAccess.Entiteti
{
    public class OglasSezonski : Oglas
    {
        public virtual string Sezona { get; set; } = string.Empty;
        public virtual string Lokacija { get; set; } = string.Empty;

        public OglasSezonski()
        {
        }
    }
}
