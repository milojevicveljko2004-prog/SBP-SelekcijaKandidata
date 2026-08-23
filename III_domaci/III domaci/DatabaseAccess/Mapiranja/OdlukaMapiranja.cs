using DatabaseAccess.Entiteti.Enums;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace DatabaseAccess.Mapiranja
{
    public class OdlukaMapiranja : ClassMap<Odluka>
    {
        public OdlukaMapiranja()
        {
            Table("ODLUKA");

            Id(x => x.OdlukaId, "ODLUKA_ID")
                .GeneratedBy.TriggerIdentity();

            Map(x => x.Status, "STATUS")
                .CustomType<EnumStringType<StatusOdluke>>();

            Map(x => x.DatumDonosenjaOdluke, "DATUM_DONOSENJA_ODLUKE");
            Map(x => x.PonudjenaPlata, "PONUDJENA_PLATA");
            Map(x => x.PrihvatioPonudu, "PRIHVATIO_PONUDU");
            Map(x => x.DatumPocetkaRada, "DATUM_POCETKA_RADA");
            Map(x => x.RazlogOdbijanja, "RAZLOG_ODBIJANJA");

            References(x => x.CV)
                .Column("CV_ID")
                .Unique()
                .Not.Nullable();
        }
    }
}
