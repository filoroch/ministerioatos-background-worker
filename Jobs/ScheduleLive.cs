using Quartz;
using MinisterioAtos_JobScheduler;

public class ScheduleLive : YoutubeJob
{
    public ScheduleLive(ILogger<ScheduleLive> logger)
    {
        Logger = logger;
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
    public override Task Execute(IJobExecutionContext context)
    {
        Logger.LogInformation($"Iniciando o agendamento de livestream do YT em {DateTime.Now}");
        return Task.CompletedTask;
    }
}