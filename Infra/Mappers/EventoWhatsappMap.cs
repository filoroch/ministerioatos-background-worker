using FluentNHibernate.Mapping;

public class EventoWhatsappMap : ClassMap<EventoWhatsapp>
{
    public EventoWhatsappMap()
    {
        Id(e => e.Id)
            .GeneratedBy.SequenceIdentity();

        References(e => e.Evento)
            .Column("id_evento")
            .Not.Nullable();

        Map(e => e.Mensagem)
            .Not.Nullable();

        Map(e => e.Status)
            .CustomSqlType("status") // Nome do tipo criado no banco (ex: Postgres)
            .CustomType<GenericEnumMapper<EEventoWhatsappStatus>>();

        Table("eventos_whatsapp");
    }
}