using Quartz;
using MinisterioAtos_JobScheduler;

/// <summary>
/// Representa uma instancia responsavel por agendar lives no youtube usando o metodo Execute
/// </summary>
public class ScheduleLive : YoutubeJob
{

    private readonly EventService _eventService;

    public ScheduleLive
    (
        ILogger<ScheduleLive> logger, 
        EventService eventService)
    {
        Logger = logger;
        _eventService = eventService;
    }

    /// <summary>
    /// - Puxa os eventos do banco
    /// - Puxa os agendamentos do banco
    /// - Verifica os eventos sem agendamento
    /// - Agenda cada evento no padrão (DIA/MES | TITULO DO EVENTO | PRELETOR)
    /// - Confirma
    /// - Chama o serviço de agendamento
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task Execute(IJobExecutionContext context)
    {
        Logger.LogInformation($"Iniciando o agendamento de livestream do YT em {DateTime.Now}");

        try
        {
            // Puxa os eventos do banco
            var events = await _eventService.GetEventsAsync();
            Logger.LogInformation($"Recebendo eventos do serviço em {DateTime.Now}");
        
            if (events == null || events.Count <= 0)
            {
                Logger.LogWarning("A lista de eventos ta vazia ou nula");    
                return;
            }

            events.ForEach(e => Logger.LogInformation(e.ToString()));
            
        } catch (Exception ex)
        {
            Logger.LogError($"Ocorreu um erro: {ex.Message}");
        }
        return;
    }
}