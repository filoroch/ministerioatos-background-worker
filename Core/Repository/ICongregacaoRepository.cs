public interface ICongregacaoRepository
{
    Task<Congregacao> GetByIdAsync(int id);
    Task SaveOrUpdateAsync(Congregacao congregacao);
    //Task DeleteAsync(T element);
    Task<ICollection<Congregacao>> GetAllAsync();
    Task<ICollection<Congregacao>> GetByStatus(string status);
}