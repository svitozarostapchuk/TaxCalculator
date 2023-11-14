using Data.Repositories.Interfaces;

namespace TaxCalculator.Data
{
    public interface IUnitOfWork
    {
        ITaxBandRepository TaxBandRepository { get; }

        public Task CommitAsync();
    }
}
