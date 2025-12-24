using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.InterfacesRepository
{
    public interface IGenericRepository<T> where T : class
    {
        // READ
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null);

        // WRITE
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        // SOFT DELETE
        void SoftDelete(T entity);

        // FIND
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
