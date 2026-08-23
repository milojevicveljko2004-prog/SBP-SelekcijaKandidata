using DatabaseAccess.Entiteti.Enums;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace DatabaseAccess.Mapiranja
{
    public class IntervjuMapiranja : ClassMap<Intervju>
    {
        public IntervjuMapiranja()
        {
            //mapiranje tabele, kljuca i svojstava

            Table("INTERVJU");

            Id(x => x.IntervjuId, "INTERVJU_ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Datum, "DATUM");
            Map(x => x.Vreme, "VREME");

            Map(x => x.Tip, "TIP_INTERVJUA")
                .CustomType<EnumStringType<TipIntervjua>>();

            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.ZaposleniIme, "ZAPOSLENI_IME");
            Map(x => x.ZaposleniPrezime, "ZAPOSLENI_PREZIME");
            Map(x => x.Ocena, "OCENA");
            Map(x => x.Napomene, "NAPOMENE");

            //mapiranje veza

            References(x => x.CV)
                .Column("CV_ID")
                .Not.Nullable();
        }
    }
}
