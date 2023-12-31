﻿using Data.Entities.Interfaces;

namespace Data.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : IHasId<TKey>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}
