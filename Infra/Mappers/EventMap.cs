using FluentNHibernate.Mapping;

public class EventMap : ClassMap<Event>
{
    public EventMap()
    {
        Id(p => p.Id)
            .GeneratedBy.SequenceIdentity();

        Map(p => p.Titulo)
            .Length(50)
            .Not.Nullable();

        Map(e => e.Descricao)
            .Length(50);

        Map(e => e.DataHora)
            .Not.Nullable();

        References(x => x.Congregacao)
            .Column("id_congregacao") 
            .Cascade.None()      // Define comportamento de salvamento em cascata
            .Not.Nullable();     // Define se o campo no banco aceita null

        Map(p => p.Status)
            .CustomSqlType("status") // Nome do tipo criado no banco (ex: Postgres)
            .CustomType<GenericEnumMapper<StatusEvento>>();
        
        Table("eventos");

    }
}