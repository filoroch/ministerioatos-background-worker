using Microsoft.IdentityModel.Tokens;

public class EventoService : IEventoService
{

    private readonly IEventoRepository repository;
    private readonly ICongregacaoService congregacaoService;

    public EventoService(IEventoRepository _repository)
    {
        repository = _repository;
    }

    public async Task<int> Create(CreateEventoCommander cmd)
    {
        if (cmd.Titulo.IsNullOrEmpty() && cmd.DataHora == null)
        {
            throw new Exception("São necessarios os valores titulo e data e hora para registrar um evento");
        }
    
        Congregacao? congregacao = null;
        if (cmd.idCongregacao.HasValue)
        {
            congregacao = await congregacaoService.GetCongregacaoByIdAsync(cmd.idCongregacao.Value);
        }

        var newEvent = new Evento
        (
            _titulo: cmd.Titulo,
            _dataHora: cmd.DataHora,
            _descricao: cmd.Descricao,
            _congregacao: congregacao
        );

        var id = await repository.SaveOrUpdateAsync(newEvent);
        return id;
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

    public async Task<ICollection<Evento>> GetEventosAsync()
    {
        var e = await repository.GetAllAsync();
        return e;
    }

    public Task<ICollection<Evento>> GetEventsByStatusAsync()
    {
        throw new NotImplementedException();
    }
}

