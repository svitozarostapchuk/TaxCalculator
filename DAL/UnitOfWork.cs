using Data.Contexts;
using Data.Repositories.Interfaces;

namespace TaxCalculator.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly TaxCalculatorContext _dbContext;

        public ITaxBandRepository TaxBandRepository { get; }

        public UnitOfWork(TaxCalculatorContext dbContext, ITaxBandRepository taxBandRepository)
        {
            _dbContext = dbContext;
            TaxBandRepository = taxBandRepository;
        }

        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
