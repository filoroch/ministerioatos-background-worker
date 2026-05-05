/// <summary>
/// Representa o contrato base e os endpoints ultilizados pela Youtube Data API
/// </summary>
public interface IYoutube
{
    /// <summary>
    /// Metodo generico que retorna as livestreams do Youtube como objeto LiveStream
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    // Task<List<T>> GetLivestreamsAsync<T>();

    /// <summary>
    /// Retorna transmissões em um intervalo de datas específico.
    /// </summary>
    Task<List<T>> GetCompletedLivestreamsAsync<T>();

    // void GetLivestreams(DateOnly startDate, DateOnly endDate);
    // void ScheduleLive(CreateScheduleLiveCommander commander);
    // void SetThumbnailOnLive(SetThumbnailOnLiveCommander commander);
}