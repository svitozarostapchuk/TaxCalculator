using Data.Entities.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IHasId<TKey>
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }
}
