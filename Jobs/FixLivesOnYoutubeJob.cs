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
        IEventoLiveService eventoLiveService,
        IYoutube youtubeService, 
        ILogger<FixLivesOnYoutubeJob> logger)
    {
        _eventoService = eventoService;
        _eventoLiveService = eventoLiveService;
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
        var start = DateTime.Parse("01/05/2026");
        var end = DateTime.Parse("29/05/2026");
        var events = await _eventoService.GetByDateRange(start, end);

        if (events.Count <= 0)
        {
            Logger.LogError($"Nenhum evento encontrado no periodo: {start.ToString()} - {end.ToString()}");
        }

        Logger.LogInformation("Recuperando os eventos com datas correspondentes as lives no mesmo periodo");
        var newEventoLive = lives.Join(
            events, 
            live => live.Snippet.publishedAt.Date,
            evento => evento.DataHora.Date,
            (live, evento) => new CreateEventLiveCommander(
                Evento: evento, 
                UrlLive: $"https://www.youtube.com/watch?v={live.Id}"
            ) 
        ).ToList();

        foreach (var eventoLive in newEventoLive)
        {
            await _eventoLiveService.CreateEventoLive(eventoLive);
        }

        Logger.LogWarning($"JOB EXECUTADO COM SUCESSO");
    }
}