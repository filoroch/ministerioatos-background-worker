using FluentNHibernate.Mapping;

public class CongregacaoMap : ClassMap<Congregacao>
{
    public CongregacaoMap()
    {
        Id(c => c.Id)
            .GeneratedBy.Identity();
        
        Map(c => c.Titulo)
            .Length(100)
            .Not.Nullable();

        Map(c => c.Rua)
            .Length(50)
            .Not.Nullable();

        Map(c => c.Area)
            .Length(50);

        Map(c => c.Numero)
            .Length(50);

        Map(c => c.Cidade) 
            .Length(50);

        Map(c => c.UF)
            .Length(2);

        Map(c => c.Status)
            .CustomType("status")
            .CustomType<GenericEnumMapper<EStatusCongregacao>>();

        Table("congregacoes");
    }
}