using FluentNHibernate.Conventions.Inspections;
using MinisterioAtos_JobScheduler;
using NHibernate.Util;
using Quartz;
using Quartz.Logging;

public class FixLivesOnYoutubeJob : YoutubeJob
{
    private readonly IEventoService _eventoService;
    private readonly IYoutube _youtubeService;

    public FixLivesOnYoutubeJob
    (
        IEventoService eventoService, 
        IYoutube youtubeService, 
        ILogger<FixLivesOnYoutubeJob> logger)
    {
        _eventoService = eventoService;
        _youtubeService = youtubeService;
        Logger = logger;
    }

    public override async Task Execute(IJobExecutionContext context)
    {
        Logger.LogInformation("Recuperando dados do youtube");
        var lives = await _youtubeService.GetCompletedLivestreamsAsync<YoutubeItem>();

        if (lives == null || lives.Count <= 0)
        {
            Logger.LogError("Nenhuma live no youtube nesse periodo");
            return;
        }

        var events = await _eventoService.GetByDateRange(DateTime.Parse("01/05/2026"), DateTime.Parse("29/05/2026"));
        
        // Preciso de pegar os eventos que tem correspondencia de dada (no mesmo dia) com os videos no canal
        var eventsWithDateLive = events.Join(
            lives,
            evento => evento.DataHora.Date,             // Chave 1: Data do evento (sem a hora)
            live => live.Snippet.publishedAt.Date,     // Chave 2: Data da live (sem a hora)
            (evento, live) => evento                  // Resultado: Queremos apenas o objeto evento
        )
        .ToList();

        foreach (var ev in eventsWithDateLive)
        {
            Console.WriteLine(ev.ToString());
        }
    }
}