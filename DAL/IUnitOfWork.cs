using Data.Repositories.Interfaces;

namespace TaxCalculator.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ITaxBandRepository TaxBandRepository { get; }

        public Task CommitAsync();
    }
}
