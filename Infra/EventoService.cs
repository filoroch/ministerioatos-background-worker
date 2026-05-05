public class EventoService : IEventService
{

    private readonly IEventoRepository repository;

    public EventoService(IEventoRepository _repository)
    {
        repository = _repository;
    }

    public Task<ICollection<Evento>> GetByCongregacaoAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Evento>> GetEventsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Evento>> GetEventsByStatusAsync()
    {
        throw new NotImplementedException();
    }
}