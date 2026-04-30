/// <summary>
/// Representa o contrato base e os endpoints ultilizados pela Youtube Data API
/// </summary>
public interface IYoutube
{
    async Task<List<T>> GetLivestreams();
    void GetLivestreams(DateOnly startDate, DateOnly endDate);
    void ScheduleLive(CreateScheduleLiveCommander commander);
    void SetThumbnailOnLive(SetThumbnailOnLiveCommander commander);
}