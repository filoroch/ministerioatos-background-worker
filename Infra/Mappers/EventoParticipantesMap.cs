using FluentNHibernate.Mapping;

public class EventoParticipantesMap : ClassMap<EventoParticipantes>
{
    public EventoParticipantesMap()
    {
        Id(p => p.Id)
            .GeneratedBy.Identity();

        References(p => p.Evento)
            .Column("id_evento")
            .Not.Nullable();

        References(p => p.Participante)
            .Column("id_participante")
            .Not.Nullable();

        Map(p => p.TipoParticipante)
            .CustomType("tipo_participante")
            .CustomType<GenericEnumMapper<EStatusEventoLive>>();

        Table("evento_lives");
    }
}