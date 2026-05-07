public interface IEventoLiveRepository
{
    Task<EventoLives> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(EventoLives eventoLive);
    Task<ICollection<EventoLives>> GetAllAsync();
    Task<ICollection<EventoLives>> GetByStatus(string status);
}