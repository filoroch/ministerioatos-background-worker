public interface ICongregacaoService
{
    Task<Congregacao> GetCongregacaoByIdAsync(int id);
    Task<IEnumerable<Congregacao>> GetAllCongregacoes();
    Task<IEnumerable<Congregacao>> GetCongregacaoByTituloAsync(string titulo);
}