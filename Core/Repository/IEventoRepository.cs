public interface IEventoRepository
{
    Task<Evento> GetByIdAsync(int id);
    Task<ICollection<Evento>> GetByCongregacao(Congregacao Congregacao);
    Task<ICollection<Evento>> GetByCongregacao(int idCongregacao);
    Task SaveOrUpdateAsync(Evento evento);
    //Task DeleteAsync(T element);
    Task<ICollection<Evento>> GetAllAsync();
    Task<ICollection<Evento>> GetByStatus(string status);
}