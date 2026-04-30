public interface IYoutube
{
    void GetLivestreams();
    void GetLivestreams(DateOnly startDate, DateOnly endDate);
    void ScheduleLive(CreateScheduleLiveCommander commander);
    void SetThumbnailOnLive(SetThumbnailOnLiveCommander commander);
}