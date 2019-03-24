using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FotoQuestGoRepository.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
	    TEntity Get(Guid id);
	    IEnumerable<TEntity> GetAll();
	    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);

        void Update(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
	    void RemoveRange(IEnumerable<TEntity> entities);
	}
}
