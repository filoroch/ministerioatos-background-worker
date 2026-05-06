public class EventoService : IEventoService
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

    public Task<ICollection<Evento>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var eventsByRange = repository.GetByDateRange(startDate, endDate);
        return eventsByRange;
    }

    public Task<ICollection<Evento>> GetEventosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Evento>> GetEventsByStatusAsync()
    {
        throw new NotImplementedException();
    }
}