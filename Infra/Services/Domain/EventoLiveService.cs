using System.Diagnostics.Tracing;

public class EventoLiveService : IEventoLiveService
{
    private readonly IEventoLiveRepository repository;

    public EventoLiveService(IEventoLiveRepository _eventoLiveRepository)
    {
        repository = _eventoLiveRepository;
    }

    public async Task CreateEventoLive(CreateEventLiveCommander cmd)
    {
        await repository.SaveOrUpdateAsync(
            new EventoLives
            (
                _evento: cmd.Evento, 
                _urlLive: cmd.UrlLive
            )
        );
    }

    public void DefinePreletor()
    {
        // eventoParticipantes.GetPreletor();
        throw new NotImplementedException();
    }

    public Task<ICollection<EventoLives>> GetByDateTime(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public async Task<EventoLives> GetEventoLiveByIdAsync(int id)
    {
        var eventId = await repository.GetByIdAsync(id);

        if(eventId == null)
        {
            throw new DomainException("O valor do id de uma live não pode ser nulo");
        }

        return eventId;
    }

    public Task<ICollection<EventoLives>> GetEventsLiveAsync()
    {
        return repository.GetAllAsync();
    }
}