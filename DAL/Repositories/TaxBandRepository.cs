using Data.Contexts;
using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class TaxBandRepository : BaseRepository<TaxBand, int>, ITaxBandRepository
    {
        public TaxBandRepository(TaxCalculatorContext context) : base(context)
        {
        }
    }
}
