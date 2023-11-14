using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ITaxBandRepository
    {
        public Task<IEnumerable<TaxBand>> GetAllAsync(CancellationToken cancellationToken);
    }
}
