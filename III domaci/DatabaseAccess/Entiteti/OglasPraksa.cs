namespace DatabaseAccess.Entiteti
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
