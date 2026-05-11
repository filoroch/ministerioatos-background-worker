public class CongregacaoService(ICongregacaoRepository repository) : ICongregacaoService
{
    private readonly ICongregacaoRepository _repository = repository;
    public Task<IEnumerable<Congregacao>> GetAllCongregacoes()
    {
        throw new NotImplementedException();
    }

    public async Task<Congregacao> GetCongregacaoByIdAsync(int id)
    {
        var congregacao = await _repository.GetByIdAsync(id);
        return congregacao;
    }

    public Task<IEnumerable<Congregacao>> GetCongregacaoByTituloAsync(string titulo)
    {
        throw new NotImplementedException();
    }
}