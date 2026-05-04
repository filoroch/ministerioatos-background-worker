public interface IEventService
{
    Task<ICollection<Evento>> GetEventsAsync();
    Task<ICollection<Evento>> GetByCongregacaoAsync();
    Task<ICollection<Evento>> GetEventsByStatusAsync();
}