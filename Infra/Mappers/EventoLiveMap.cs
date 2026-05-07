using FluentNHibernate.Mapping;

public class EventoLivesMap : ClassMap<EventoLives>
{
    public EventoLivesMap()
    {
        Id(p => p.Id)
            .GeneratedBy.Identity();
        
        References(p => p.Evento)
            .Column("id_evento")
            .Not.Nullable();

        Map(eventoLive => eventoLive.Titulo)
            .Length(100)
            .Not.Nullable();

        Map(eventoLive => eventoLive.DataPublicacao)
            .Column("data_publicacao")
            .Not.Nullable();

        Map(p => p.UrlLive)
            .Column("url_live")
            .Length(50)
            .Not.Nullable();

        Map(p => p.UrlThumb)
            .Column("url_thumb")
            .Length(50)
            .Not.Nullable();

        Map(p => p.Status)
            .CustomType("status")
            .CustomType<GenericEnumMapper<EStatusEventoLive>>();

        Table("evento_lives");
    }
}