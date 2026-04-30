using MinisterioAtos_JobScheduler;
using Quartz;

public class UpdateLivestream : YoutubeJob
{
    private readonly YoutubeService _youtubeService;
    /// <summary>
    /// - Busca os dados das liv
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override async Task Execute(IJobExecutionContext context)
    {
        try
        {
            var lastLivestreansOnWeek = await _youtubeService.GetLivestreams();
        }
    }
}

