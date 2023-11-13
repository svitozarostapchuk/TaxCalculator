using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class TaxBandRepository : BaseRepository<TaxBand, int>, ITaxBandRepository
    {
        public TaxBandRepository(DbContext context) : base(context)
        {
        }
    }
}
