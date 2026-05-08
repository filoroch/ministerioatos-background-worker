using NHibernate.Linq;

public class CongregacaoRepository : ICongregacaoRepository
{
    private readonly NHibernate.ISession session;
    public CongregacaoRepository(NHibernate.ISession _session)
    {
        session = _session;
    }
    public async Task<ICollection<Congregacao>> GetAllAsync()
    {
        var query = await session
            .Query<Congregacao>()
            .ToListAsync();

        return query;
    }

    public async Task<Congregacao> GetByIdAsync(int id)
    {
        var query = await session
            .Query<Congregacao>()
            .Where(c => c.Id == id)
            .FirstAsync();

        return query;
    }

    public Task<ICollection<Congregacao>> GetByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public Task SaveOrUpdateAsync(Congregacao congregacao)
    {
        throw new NotImplementedException();
    }
}