using FluentNHibernate.Mapping;
using NHibernate.Type;
using DatabaseAccess.Entiteti.Enums;

namespace DatabaseAccess.Mapiranja
{
    public class OglasMapiranja : ClassMap<Oglas>
    {
        public OglasMapiranja() 
        {
            //mapiranje tabele, kljuca i svojstava

            Table("OGLAS");

            Id(x => x.OglasId, "OGLAS_ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.NazivPozicije, "NAZIV_POZICIJE");

            Map(x => x.VrstaOglasa, "VRSTA_OGLASA")
                .CustomType<EnumStringType<VrstaOglasa>>();

            Map(x => x.Opis, "OPIS");
            Map(x => x.Zahtevi, "ZAHTEVI");
            Map(x => x.MinPlata, "MIN_PLATA");
            Map(x => x.MaxPlata, "MAX_PLATA");
            Map(x => x.DatumObjave, "DATUM_OBJAVE");
            Map(x => x.DatumZatvaranja, "DATUM_ZATVARANJA");

            Map(x => x.Status, "STATUS")
                .CustomType<EnumStringType<StatusOglasa>>();

            //mapiranje veza

            HasMany(x => x.CVjevi)
            .KeyColumn("OGLAS_ID")
            .Inverse()
            .Cascade.All();

        }
    }
}
