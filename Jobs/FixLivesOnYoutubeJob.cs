using MinisterioAtos_JobScheduler;
using Quartz;
using Quartz.Logging;

public class FixLivesOnYoutubeJob : YoutubeJob
{
    //private readonly IEventoLiveService _eventoLivesService;
    private readonly IYoutube _youtubeService;

    public FixLivesOnYoutubeJob(IYoutube youtubeService, ILogger<FixLivesOnYoutubeJob> logger)
    {
        //_eventoLivesService = eventoLivesService;
        _youtubeService = youtubeService;
        Logger = logger;
    }

    public override async Task Execute(IJobExecutionContext context)
    {
        Logger.LogInformation("Recuperando dados do youtube");
        // Buscar as ultimas lives da semana
        var lives = await _youtubeService.GetCompletedLivestreamsAsync<YoutubeItem>();

        if (lives == null || lives.Count <= 0)
        {
            throw new Exception("Nenhuma live no youtube nesse periodo");
        }

        foreach (var video in lives)
        {
            Console.WriteLine($"Titulo: {video.Snippet.Title} | Publicado em: {video.Snippet.publishedAt}");
        }      

        // Verificar quais estão registradas
        // Para as não registradas, criar o agendamento correspondente
        // Para as registradas, validar os dados
    }
}