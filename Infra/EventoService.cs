public class EventoService : IEventService
{

    private readonly IEventoRepository repository;

    public EventoService(IEventoRepository _repository)
    {
        repository = _repository;
    }

    public Task<ICollection<Evento>> GetEventsAsync()
    {
        var events = repository.GetAllAsync();
        return events;
    }

    Task<ICollection<Evento>> IEventService.GetEventsByStatusAsync()
    {
        var eventsByStatus = repository.GetByStatus();
    }
}