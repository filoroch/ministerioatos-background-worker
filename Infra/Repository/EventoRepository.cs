using NHibernate.Linq;

public class EventoRepository : IEventoRepository
{
    private readonly NHibernate.ISession session;
    private readonly ILogger<EventoRepository> _logger;

    public EventoRepository(NHibernate.ISession _session, ILogger<EventoRepository> logger)
    {
        session = _session;
        _logger = logger;
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

    public async Task<ICollection<Evento>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var events = await session
            .Query<Evento>()
            .Where(evento => evento.DataHora >= startDate)
            .Where(evento => evento.DataHora <= endDate)
            .ToListAsync();

        return events;
    }

    /// <summary>
    /// Retorna um evento por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Lança uma exceção se o valor de retorno for nulo</exception>
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

    /// <summary>
    /// Retorna uma lista de eventos com base no status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public async Task<ICollection<Evento>> GetByStatus(string status)
    {
        var eventsByStatus = await session
            .Query<Evento>()
            .Where(evento => evento.Status.ToString() == status)
            .ToListAsync();

        return eventsByStatus;
    }


    /// <summary>
    /// Salva ou atualiza aquele evento especifico no banco
    /// </summary>
    /// <param name="evento"></param>
    /// <returns></returns

    public async Task<Evento> SaveAsync(Evento evento)
    {
        // if (evento.Id != null)
        // {
        //     evento = await GetByIdAsync(evento.Id);
        // }
        await session.SaveOrUpdateAsync(evento);
        return evento;
    }
}