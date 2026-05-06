public interface IEventoService
{
    Task<ICollection<Evento>> GetByDateRange(DateTime startDate, DateTime endDate);
    Task<ICollection<Evento>> GetEventosAsync();
    Task<ICollection<Evento>> GetByCongregacaoAsync();
    Task<ICollection<Evento>> GetEventsByStatusAsync();
}