/// <summary>
/// Representa o contrato base e os endpoints ultilizados pela Youtube Data API
/// </summary>
public interface IYoutube
{
    Task<List<string>> GetLivestreams();
    void GetLivestreams(DateOnly startDate, DateOnly endDate);
    void ScheduleLive(CreateScheduleLiveCommander commander);
    void SetThumbnailOnLive(SetThumbnailOnLiveCommander commander);
}