public class EventoLiveService : IEventoLiveService
{
    private readonly IEventoLiveRepository eventoLiveRepository;

    public EventoLiveService(IEventoLiveRepository _eventoLiveRepository)
    {
        eventoLiveRepository = _eventoLiveRepository;
    }

    public async Task CreateEventoLive(CreateEventLiveCommander cmd)
    {
        await eventoLiveRepository.SaveOrUpdateAsync(
            new EventoLives(_evento: cmd.Evento, _urlLive: cmd.UrlLive)
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

    public Task<ICollection<EventoLives>> GetEventsLiveAsync()
    {
        throw new NotImplementedException();
    }
}