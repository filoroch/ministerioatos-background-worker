using NHibernate.Linq;
using NHibernate.Util;

public class EventoRepository : IEventoRepository
{
    private readonly NHibernate.ISession session;

    public EventoRepository(NHibernate.ISession _session)
    {
        session = _session;
    }

    public async Task<ICollection<Evento>> GetAllAsync()
    {
        var events = await session.Query<Evento>().ToListAsync();
        return events;
    }

    public async Task<ICollection<Evento>> GetByCongregacao(Congregacao congregacao)
    {
        var eventsByCongregacao = await session
            .Query<Evento>()
            .Where(evento => evento.Congregacao.Equals(congregacao))
            .ToListAsync();

        return eventsByCongregacao;
    }

    public async Task<ICollection<Evento>> GetByCongregacao(int idCongregacao)
    {
        var eventsByCongregacao = await session
            .Query<Evento>()
            .Where(evento => evento.Congregacao.Id == idCongregacao)
            .ToListAsync();

        return eventsByCongregacao;
    }

    /// <summary>
    /// Retorna um evento por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Task<Evento> GetByIdAsync(int id)
    {
        var target = session.Query<Evento>()
            .Where(evento => evento.Id == id)
            .FirstOrDefaultAsync();

        if (target == null)
        {
            throw new Exception("O valor não pode ser nulo");
        }

       return target;
    }

    public Task<ICollection<Evento>> GetByStatus(string status)
    {
        var eventsByStatus = session.Query<Evento>()
            .Where(evento => evento.Status == status)
            .ToListAsync();
    }

    public async Task SaveOrUpdateAsync(Evento evento)
    {
        session.SaveOrUpdateAsync(evento);
    }
}