using FluentNHibernate.Conventions.Inspections;
using MinisterioAtos_JobScheduler;
using NHibernate.Util;
using Quartz;
using Quartz.Logging;

public class FixLivesOnYoutubeJob : YoutubeJob
{
    private readonly IEventoService _eventoService;
    private readonly IEventoLiveService _eventoLiveService;
    private readonly IYoutube _youtubeService;

    public FixLivesOnYoutubeJob
    (
        IEventoService eventoService, 
        IEventoLiveService _eventoLiveService,
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

        Logger.LogInformation("Recuperando dados dos eventos");
        var events = await _eventoService.GetByDateRange(DateTime.Parse("01/05/2026"), DateTime.Parse("29/05/2026"));
        
        var eventsWithDateLive = events.Join(
            lives,
            evento => evento.DataHora.Date,             // Chave 1: Data do evento (sem a hora)
            live => live.Snippet.publishedAt.Date,     // Chave 2: Data da live (sem a hora)
            (evento, live) => evento                  // Resultado: Queremos apenas o objeto evento
        )
        .ToList();

        
    }
}