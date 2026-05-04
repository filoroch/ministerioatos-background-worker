/// <summary>
/// Implementação do contrato do Youtube aplicado a API
/// </summary>
public class YoutubeAPIService : IYoutube
{
    private readonly string BaseEndpoint = Environment.GetEnvironmentVariable("YOUTUBE:ENDPOINT");
    private readonly string ApiKey = Environment.GetEnvironmentVariable("YOUTUBE:APIKEY");

    public YoutubeAPIService(string baseEndpoint, string apiKey)
    {
        BaseEndpoint = baseEndpoint;
        ApiKey = apiKey;
    }

    public void GetLivestreams(DateOnly startDate, DateOnly endDate)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetLivestreamsAsync<T>()
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetLivestreamsAsync<T>(DateOnly startDate, DateOnly endDate)
    {
        throw new NotImplementedException();
    }

    public void ScheduleLive(CreateScheduleLiveCommander commander)
    {
        throw new NotImplementedException();
    }

    public void SetThumbnailOnLive(SetThumbnailOnLiveCommander commander)
    {
        throw new NotImplementedException();
    }
}