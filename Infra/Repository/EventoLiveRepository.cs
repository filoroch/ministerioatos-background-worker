public class EventoLiveRepository : IEventoLiveRepository
{
    private readonly NHibernate.ISession session;

    public EventoLiveRepository(NHibernate.ISession _session)
    {
        session = _session;
    }
    
    public Task<ICollection<EventoLives>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EventoLives> GetByIdAsync(int id)
    {
        var target = session.Query<EventoLives>()
            .Where(eventoLive => eventoLive.Id == id)
            .FirstOrDefault();

        if (target == null)
        {
            throw new Exception("O valor não pode ser nulo");
        }

       return target;
    }

    public Task<ICollection<EventoLives>> GetByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public async Task SaveOrUpdateAsync(EventoLives eventoLive)
    {
        // if (eventoLive.Id != null)
        // {
        //     eventoLive = await GetByIdAsync(eventoLive.Id);
        // }
        
        await session.SaveOrUpdateAsync(eventoLive);
    }
}