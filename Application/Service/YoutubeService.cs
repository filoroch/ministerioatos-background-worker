public class YoutubeService : IYoutube
{
    /// <summary>
    /// Url do endpoint base
    /// </summary>
    private readonly string _youtubeApiEndpoint = "";
    private readonly string _youtubeLivestreamsApiEndpoint = "https://www.googleapis.com/youtube/v3/liveBroadcasts";

    /// <summary>
    /// Url do endpoint base
    /// </summary>
    private readonly string _apiKey = "";

    /// <summary>
    /// id do canal do youtube
    /// </summary>
    private readonly string _idChannel = "";

    public void GetLivestreams(DateOnly startDate, DateOnly endDate)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetLivestreams()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Recebe os dados para agendamento, tenta fazer um post na api do youtube, retorna os dados
    /// </summary>
    /// <param name="commander"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void ScheduleLive(CreateScheduleLiveCommander commander)
    {
        throw new NotImplementedException();
    }

    public void SetThumbnailOnLive(SetThumbnailOnLiveCommander commander)
    {
        throw new NotImplementedException();
    }
}


