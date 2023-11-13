using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ITaxBandRepository
    {
        public IQueryable<TaxBand> GetAll();
    }
}
