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

        public IQueryable<TEntity> GetAll() => _dbContext.Set<TEntity>();
    }
}
