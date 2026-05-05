public interface IEventoLiveService
{
    /// <summary>
    /// Recupera todos os eventos registrados (por enquanto)
    /// </summary>
    /// <returns></returns>
    Task<ICollection<Evento>> GetEventsLiveAsync();
    /// <summary>
    /// Recupera os eventos com base na data fornecida
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    Task<ICollection<Evento>> GetByDateTime(DateTime dateTime);
}