using FluentNHibernate.Mapping;

public class EventMap : ClassMap<Event>
{
    public EventMap()
    {
        Id(p => p.Id)
            .GeneratedBy.SequenceIdentity();

        Map(p => p.FirstName)
            .Length(50)
            .Not.Nullable();
            
        Map(p => p.LastName)
            .Length(50)
            .Not.Nullable();

        Map(p => p.Cpf)
            .Length(11)
            .Not.Nullable();

        Map(p => p.BirthDate)
            .Not.Nullable();
    }
}