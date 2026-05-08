using NHibernate.Linq;

public class EventoLiveRepository : IEventoLiveRepository
{
    private readonly NHibernate.ISession session;

    public EventoLiveRepository(NHibernate.ISession _session)
    {
        session = _session;
    }
    
    public async Task<ICollection<EventoLives>> GetAllAsync()
    {
        var query = await session
            .Query<EventoLives>()
            .ToListAsync();

        return query;
    }

    public async Task<EventoLives> GetByIdAsync(int id)
    {
        var target = session.Query<EventoLives>()
            .Where(eventoLive => eventoLive.Id == id)
            .FirstOrDefault();

        if (target == null)
        {
            throw new DomainException("O valor do id não pode ser nulo");
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