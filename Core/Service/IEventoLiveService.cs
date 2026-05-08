public interface IEventoLiveService
{
    Task<EventoLives> GetEventoLiveByIdAsync(int id);
    Task CreateEventoLive(CreateEventLiveCommander cmd);
    void DefinePreletor();
    /// <summary>
    /// Recupera todos os eventos registrados (por enquanto)
    /// </summary>
    /// <returns></returns>
    Task<ICollection<EventoLives>> GetEventsLiveAsync();
    /// <summary>
    /// Recupera os eventos com base na data fornecida
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    Task<ICollection<EventoLives>> GetByDateTime(DateTime dateTime);
}