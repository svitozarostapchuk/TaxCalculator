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
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            TaxBandRepository = taxBandRepository ?? throw new ArgumentNullException(nameof(taxBandRepository));
        }

        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();
    }
}
