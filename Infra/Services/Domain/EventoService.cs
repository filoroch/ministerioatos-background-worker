using Microsoft.IdentityModel.Tokens;
using MinisterioAtos.Application.Commanders.Evento;
using NHibernate.Util;

public class EventoService(
    IEventoRepository repository, 
    ICongregacaoService congregacaoService, 
    ILogger<EventoService> logger
) : IEventoService
{

    private readonly IEventoRepository _repository = repository;
    private readonly ICongregacaoService _congregacaoService = congregacaoService;
    private readonly ILogger<EventoService> _logger = logger;

    public async Task<OutputEventoCommander> Create(InputEventoCommander cmd)
    {
        if (string.IsNullOrEmpty(cmd.Titulo) && cmd.DataHora == null)
        {
            throw new Exception("São necessarios os valores titulo e data e hora para registrar um evento");
        }
    
        Congregacao? congregacao = null;
        if (cmd.idCongregacao.HasValue)
        {
            congregacao = await _congregacaoService.GetCongregacaoByIdAsync(cmd.idCongregacao.Value);
        }

        var newEvent = new Evento(
            _titulo: cmd.Titulo,
            _dataHora: cmd.DataHora,
            _descricao: cmd.Descricao,
            _congregacao: congregacao
        );

        var entity = await _repository.SaveAsync(newEvent);

        return new OutputEventoCommander(
            Titulo: entity.Titulo, 
            Descricao: entity.Descricao,
            DataHora: entity.DataHora, 
            Congregacao: entity.Congregacao?.ToString()
        );
    }

    public Task<ICollection<OutputEventoCommander>> GetByCongregacaoAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<OutputEventoCommander>> GetByDateRange(DateTime startDate, DateTime endDate)
    {
        var eventsByRange = await _repository.GetByDateRange(startDate, endDate);
        var output = new List<OutputEventoCommander>();

        foreach (var events in eventsByRange)
        {
            output.Add(new OutputEventoCommander(events.Titulo, events.Descricao, events.DataHora, events.Congregacao.ToString()));    
        }
            
        return output;
    }

    public async Task<ICollection<OutputEventoCommander>> GetEventosAsync()
    {
        var e = await _repository.GetAllAsync();
        return e;
    }

    public Task<ICollection<OutputEventoCommander>> GetEventsByStatusAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OutputEventoCommander> Update(InputEventoCommander cmd)
    {
        throw new NotImplementedException();
    }
}

