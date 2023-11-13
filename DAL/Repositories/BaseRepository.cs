using Data.Entities.Interfaces;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IHasId<TKey>
    {
        internal protected DbContext Context { get; }

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<TEntity> GetAll() => Context.Set<TEntity>();
    }
}
