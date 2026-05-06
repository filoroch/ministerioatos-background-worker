public class EventoLiveService : IEventoLiveService
{
    private readonly IEventoParticipantes eventoParticipantes;
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